// C2Teck S.A.C. — Aplicación de Escritorio Empresarial (Electron)
const { app, BrowserWindow, Menu, shell, ipcMain, dialog } = require("electron");
const path = require("path");
const fs = require("fs");
const {
  startAllServices,
  stopAllServices,
  getAppUrl,
} = require("./services.cjs");

let mainWindow = null;
let loginWindow = null;
let servicesStarted = false;

// Modo standalone: solo abre URL externa (sin levantar servicios locales)
const STANDALONE_URL = process.env.C2TECK_URL;
const AUTO_START_SERVICES = !STANDALONE_URL;

function createWindow(appUrl, options = {}) {
  const {
    width = 1920,
    height = 1200,
    minWidth = 1280,
    minHeight = 768,
    isLogin = false,
    resizable = true,
    title,
  } = options;

  if (!isLogin && mainWindow && !mainWindow.isDestroyed()) {
    mainWindow.close();
  }

  if (isLogin && loginWindow && !loginWindow.isDestroyed()) {
    loginWindow.close();
  }

  const win = new BrowserWindow({
    width,
    height,
    minWidth,
    minHeight,
    useContentSize: true,
    backgroundColor: "#F5F7FA",
    title: title || "Systeck (Versión 10.6.30) — C2TECK S.A.C.",
    icon: fs.existsSync(path.join(__dirname, "icon.png"))
      ? path.join(__dirname, "icon.png")
      : undefined,
    autoHideMenuBar: true,
    frame: true,
    resizable,
    show: false,
    webPreferences: {
      preload: path.join(__dirname, "preload.cjs"),
      contextIsolation: true,
      nodeIntegration: false,
      sandbox: false,
      nativeWindowOpen: true,
    },
  });

  if (isLogin) {
    loginWindow = win;
  } else {
    mainWindow = win;
  }

  win.once("ready-to-show", () => {
    win.show();
    win.focus();
  });

  win.loadURL(appUrl);

  win.webContents.setWindowOpenHandler(({ url }) => {
    const base = new URL(appUrl).origin;
    if (!url.startsWith(base)) {
      shell.openExternal(url);
      return { action: "deny" };
    }
    return { action: "allow" };
  });

  win.on("closed", () => {
    if (isLogin) {
      loginWindow = null;
    } else {
      mainWindow = null;
    }
  });

  return win;
}

function openDesktopLoginWindow() {
  if (mainWindow && !mainWindow.isDestroyed()) {
    mainWindow.close();
    mainWindow = null;
  }

  const appUrl = STANDALONE_URL || getAppUrl();
  const loginUrl = new URL(appUrl);
  loginUrl.searchParams.set("login", "1");
  loginUrl.searchParams.set("desktop", "1");
  // Mark as new login to force the updated desktop login UI in the renderer
  loginUrl.searchParams.set("newLogin", "1");
  createWindow(loginUrl.toString(), {
    width: 580,
    height: 540,
    minWidth: 580,
    minHeight: 540,
    resizable: false,
    isLogin: true,
    title: "Acceso al Sistema — Systeck v10.6.3.0",
  });
}

function openDesktopAppWindow() {
  if (mainWindow && !mainWindow.isDestroyed()) {
    mainWindow.focus();
    return;
  }

  const appUrl = STANDALONE_URL || getAppUrl();
  createWindow(appUrl, {
    width: 1600,
    height: 900,
    minWidth: 1280,
    minHeight: 768,
    title: "Systeck (Versión 10.6.30) — C2TECK S.A.C.",
  });
}

ipcMain.on("window:minimize", () => mainWindow?.minimize());
ipcMain.on("window:maximize", () => {
  if (!mainWindow) return;
  if (mainWindow.isMaximized()) mainWindow.unmaximize();
  else mainWindow.maximize();
});
ipcMain.on("window:close", () => mainWindow?.close());
ipcMain.handle("window:isMaximized", () => mainWindow?.isMaximized() ?? false);
ipcMain.on("desktop:login-success", () => {
  if (loginWindow && !loginWindow.isDestroyed()) {
    loginWindow.close();
  }
  openDesktopAppWindow();
});

async function bootstrap() {
  Menu.setApplicationMenu(null);

  if (mainWindow && !mainWindow.isDestroyed()) {
    mainWindow.close();
    mainWindow = null;
  }

  if (loginWindow && !loginWindow.isDestroyed()) {
    loginWindow.close();
    loginWindow = null;
  }

  try {
    if (AUTO_START_SERVICES) {
      await startAllServices();
      servicesStarted = true;
    }

    openDesktopLoginWindow();
  } catch (err) {
    console.error("Error al iniciar la aplicación:", err);
    dialog.showErrorBox(
      "Error de inicio — Systeck",
      `No se pudo iniciar la aplicación de escritorio.\n\n${err.message}\n\nVerifique que Node.js y Python estén instalados, luego ejecute:\n  npm install\n  cd electron && npm install`,
    );
    app.quit();
  }
}

app.whenReady().then(bootstrap);

app.on("activate", () => {
  if (BrowserWindow.getAllWindows().length === 0) {
    openDesktopLoginWindow();
  }
});

app.on("window-all-closed", () => {
  if (process.platform !== "darwin") app.quit();
});

app.on("before-quit", () => {
  if (servicesStarted) stopAllServices();
});
