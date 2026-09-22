// Gestión de procesos hijo: backend FastAPI + servidor frontend
const { spawn } = require("child_process");
const http = require("http");
const net = require("net");
const path = require("path");
const fs = require("fs");

const PROJECT_ROOT = path.join(__dirname, "..");
const DEFAULT_BACKEND_PORT = Number(process.env.C2TECK_BACKEND_PORT || 8000);
let BACKEND_PORT = DEFAULT_BACKEND_PORT;
let FRONTEND_PORT = Number(process.env.C2TECK_FRONTEND_PORT || 5173);
const IS_PROD = process.env.C2TECK_DESKTOP_PROD === "1";

const processes = [];

function log(prefix, message) {
  console.log(`[${prefix}] ${message}`);
}

function resolvePython() {
  if (process.env.C2TECK_PYTHON) return process.env.C2TECK_PYTHON;
  if (process.platform === "win32") return "py";
  return "python3";
}

function buildSpawnConfig(command, args) {
  if (process.platform !== "win32") {
    return { command, args };
  }

  const shellCommand = [command, ...args]
    .map((value) => {
      const text = String(value).replace(/"/g, '\\"');
      return text.includes(" ") ? `"${text}"` : text;
    })
    .join(" ");

  return {
    command: "cmd.exe",
    args: ["/d", "/s", "/c", shellCommand],
  };
}

function spawnManaged(name, command, args, options = {}) {
  const { command: spawnCommand, args: spawnArgs } = buildSpawnConfig(command, args);
  log(name, `Iniciando: ${spawnCommand} ${spawnArgs.join(" ")}`);
  const proc = spawn(spawnCommand, spawnArgs, {
    cwd: options.cwd || PROJECT_ROOT,
    env: { ...process.env, ...options.env },
    stdio: ["ignore", "pipe", "pipe"],
    windowsHide: false,
  });

  proc.stdout?.on("data", (chunk) => {
    for (const line of chunk.toString().split(/\r?\n/)) {
      if (line.trim()) log(name, line);
    }
  });

  proc.stderr?.on("data", (chunk) => {
    for (const line of chunk.toString().split(/\r?\n/)) {
      if (line.trim()) log(`${name}-ERR`, line);
    }
  });

  proc.on("exit", (code) => log(name, `Proceso finalizado (código ${code})`));
  processes.push({ name, proc });
  return proc;
}

function waitForUrl(url, timeoutMs = 120000, intervalMs = 500) {
  const started = Date.now();
  return new Promise((resolve, reject) => {
    const check = () => {
      const req = http.get(url, (res) => {
        res.resume();
        resolve(true);
      });
      req.on("error", () => {
        if (Date.now() - started > timeoutMs) {
          reject(new Error(`Timeout esperando ${url}`));
          return;
        }
        setTimeout(check, intervalMs);
      });
      req.setTimeout(2000, () => req.destroy());
    };
    check();
  });
}

function isPortAvailable(port) {
  return new Promise((resolve) => {
    const server = net.createServer();
    server.once("error", () => resolve(false));
    server.once("listening", () => {
      server.close(() => resolve(true));
    });
    server.listen(port, "127.0.0.1");
  });
}

async function ensureLegacyAdapter() {
  const adapterUrl = "http://127.0.0.1:5041/health";
  try {
    await waitForUrl(adapterUrl, 3000, 200);
    log("adapter", "Adaptador legacy ya disponible en 127.0.0.1:5041");
    return;
  } catch (error) {
    log("adapter", "Adaptador legacy no detectado; intentando iniciar el proyecto .NET");
  }

  const projectDir = path.join(PROJECT_ROOT, "sigecoom-wcf-adapter");
  const csproj = path.join(projectDir, "sigecoom-wcf-adapter.csproj");
  if (!fs.existsSync(csproj)) {
    log("adapter", "No se encontró el proyecto .NET de adaptador legacy. Se continuará sin él.");
    return;
  }

  const dotnet = process.platform === "win32" ? "dotnet.exe" : "dotnet";
  spawnManaged("legacy-adapter", dotnet, ["run", "--project", "sigecoom-wcf-adapter", "--urls", "http://localhost:5041"], {
    cwd: PROJECT_ROOT,
  });

  try {
    await waitForUrl(adapterUrl, 30000, 1000);
    log("adapter", "Adaptador legacy levantado correctamente en 127.0.0.1:5041");
  } catch (err) {
    log("adapter", `No fue posible iniciar el adaptador legacy: ${err.message}`);
  }
}

async function ensureBackendPort() {
  let port = DEFAULT_BACKEND_PORT;
  while (!(await isPortAvailable(port))) {
    log("setup", `Puerto ${port} ocupado, probando ${port + 1}`);
    port += 1;
  }

  if (port !== BACKEND_PORT) {
    log("setup", `Usando backend en puerto ${port}`);
    BACKEND_PORT = port;
  }
}

async function ensureFrontendPort() {
  let port = Number(process.env.C2TECK_FRONTEND_PORT || 5173);
  while (!(await isPortAvailable(port))) {
    log("setup", `Puerto ${port} ocupado, probando ${port + 1}`);
    port += 1;
  }

  if (port !== FRONTEND_PORT) {
    log("setup", `Usando frontend en puerto ${port}`);
    FRONTEND_PORT = port;
  }
}

async function ensureBackendDeps() {
  const requirements = path.join(PROJECT_ROOT, "backend", "requirements.txt");
  if (!fs.existsSync(requirements)) return;

  const venvDir = path.join(PROJECT_ROOT, ".venv");
  if (!fs.existsSync(venvDir)) {
    log("setup", "Creando entorno virtual Python...");
    await new Promise((resolve, reject) => {
      const python = resolvePython();
      const proc = spawn(python, ["-m", "venv", ".venv"], {
        cwd: PROJECT_ROOT,
        stdio: "inherit",
      });
      proc.on("error", reject);
      proc.on("exit", (code) => (code === 0 ? resolve() : reject(new Error("venv failed"))));
    });
  }

  const pip = process.platform === "win32"
    ? path.join(venvDir, "Scripts", "pip.exe")
    : path.join(venvDir, "bin", "pip");

  if (fs.existsSync(pip)) {
    log("setup", "Instalando dependencias del backend...");
    await new Promise((resolve, reject) => {
      const proc = spawn(pip, ["install", "-r", "backend/requirements.txt", "-q"], {
        cwd: PROJECT_ROOT,
        stdio: "inherit",
      });
      proc.on("error", reject);
      proc.on("exit", (code) => (code === 0 ? resolve() : reject(new Error("pip install failed"))));
    });
  }
}

function getPythonExecutable() {
  const venvPython = process.platform === "win32"
    ? path.join(PROJECT_ROOT, ".venv", "Scripts", "python.exe")
    : path.join(PROJECT_ROOT, ".venv", "bin", "python");

  if (fs.existsSync(venvPython)) return venvPython;
  return resolvePython();
}

async function seedDatabaseIfNeeded() {
  const dbFile = path.join(PROJECT_ROOT, "backend", "empresa.db");
  if (fs.existsSync(dbFile) && fs.statSync(dbFile).size > 0) return;

  log("setup", "Inicializando base de datos con datos de prueba...");
  const python = getPythonExecutable();
  await new Promise((resolve, reject) => {
    const proc = spawn(python, ["backend/seed_data.py"], {
      cwd: PROJECT_ROOT,
      stdio: "inherit",
    });
    proc.on("error", reject);
    proc.on("exit", (code) => (code === 0 ? resolve() : reject(new Error("seed_data failed"))));
  });
}

async function startBackend() {
  await ensureLegacyAdapter();
  await ensureBackendDeps();
  await seedDatabaseIfNeeded();
  await ensureBackendPort();

  const python = getPythonExecutable();
  spawnManaged(
    "backend",
    python,
    ["-m", "uvicorn", "main:app", "--host", "127.0.0.1", "--port", String(BACKEND_PORT)],
    { cwd: path.join(PROJECT_ROOT, "backend") },
  );

  await waitForUrl(`http://127.0.0.1:${BACKEND_PORT}/health`);
  log("backend", `API lista en puerto ${BACKEND_PORT}`);
}

async function startFrontend() {
  if (IS_PROD) {
    const distServer = path.join(PROJECT_ROOT, ".output", "server", "index.mjs");
    if (fs.existsSync(distServer)) {
      spawnManaged("frontend", process.execPath, [distServer], {
        env: { PORT: String(FRONTEND_PORT), NITRO_PORT: String(FRONTEND_PORT) },
      });
    } else {
      spawnManaged("frontend", "npm", ["run", "preview", "--", "--port", String(FRONTEND_PORT), "--host", "127.0.0.1"], {
        cwd: PROJECT_ROOT,
      });
    }
  } else {
    const npmCommand = process.platform === "win32" ? "npm.cmd" : "npm";
    spawnManaged(
      "frontend",
      npmCommand,
      ["run", "dev", "--", "--port", String(FRONTEND_PORT), "--host", "127.0.0.1"],
      {
        cwd: PROJECT_ROOT,
        env: { ...process.env, BROWSER: "none" }, // prevent Vite from auto-opening a browser window
      },
    );
  }

  await waitForUrl(`http://127.0.0.1:${FRONTEND_PORT}/`);
  log("frontend", `Frontend listo en puerto ${FRONTEND_PORT}`);
}

async function startAllServices() {
  await ensureFrontendPort();
  await startBackend();
  await startFrontend();
}

function stopAllServices() {
  for (const { name, proc } of processes) {
    if (!proc || proc.killed) continue;
    log(name, "Deteniendo...");
    try {
      if (process.platform === "win32") {
        spawn("taskkill", ["/pid", String(proc.pid), "/f", "/t"], { shell: true });
      } else {
        proc.kill("SIGTERM");
      }
    } catch (err) {
      log(name, `Error al detener: ${err.message}`);
    }
  }
}

function getAppUrl() {
  return `http://127.0.0.1:${FRONTEND_PORT}/escritorio?desktop=1`;
}

module.exports = {
  startAllServices,
  stopAllServices,
  getAppUrl,
  BACKEND_PORT,
  FRONTEND_PORT,
};
