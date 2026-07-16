#!/usr/bin/env node
/**
 * Configuración inicial para la app de escritorio C2Teck Systeck.
 * Instala dependencias Node, Electron y Python (venv + requirements).
 */
const { spawn, spawnSync } = require("child_process");
const fs = require("fs");
const path = require("path");

const ROOT = path.join(__dirname, "..");

function run(cmd, args, options = {}) {
  console.log(`\n> ${cmd} ${args.join(" ")}`);
  const result = spawnSync(cmd, args, {
    cwd: options.cwd || ROOT,
    stdio: "inherit",
    shell: true,
    ...options,
  });
  if (result.status !== 0) {
    throw new Error(`Comando falló: ${cmd} ${args.join(" ")}`);
  }
}

function resolvePython() {
  if (process.env.C2TECK_PYTHON) return process.env.C2TECK_PYTHON;
  if (process.platform === "win32") return "py";
  return "python3";
}

async function main() {
  console.log("=== C2Teck Systeck — Configuración de Escritorio ===\n");

  run("npm", ["install"]);

  const electronDir = path.join(ROOT, "electron");
  run("npm", ["install"], { cwd: electronDir });

  const python = resolvePython();
  const venvDir = path.join(ROOT, ".venv");

  if (!fs.existsSync(venvDir)) {
    run(python, ["-m", "venv", ".venv"]);
  }

  const pip =
    process.platform === "win32"
      ? path.join(venvDir, "Scripts", "pip.exe")
      : path.join(venvDir, "bin", "pip");

  run(pip, ["install", "-r", "backend/requirements.txt"]);

  const pythonExe =
    process.platform === "win32"
      ? path.join(venvDir, "Scripts", "python.exe")
      : path.join(venvDir, "bin", "python");

  const dbFile = path.join(ROOT, "backend", "empresa.db");
  if (!fs.existsSync(dbFile) || fs.statSync(dbFile).size === 0) {
    run(pythonExe, ["backend/seed_data.py"]);
  }

  console.log("\n✅ Configuración completada.");
  console.log("\nPara lanzar la aplicación de escritorio:");
  console.log("  npm run desktop");
  console.log("\nO desde la carpeta electron:");
  console.log("  cd electron && npm start");
}

main().catch((err) => {
  console.error("\n❌ Error:", err.message);
  process.exit(1);
});
