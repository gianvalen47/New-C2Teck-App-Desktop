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

  if (isLogin && loginWindow && !loginWindow.isDestroyed()) {
    loginWindow.close();
  }
  if (!isLogin && mainWindow && !mainWindow.isDestroyed()) {
    mainWindow.close();
  }

  const win = new BrowserWindow({
    width,
    height,
    minWidth,
    minHeight,
    useContentSize: true,
    backgroundColor: "#0B1120",
    title: title || "Systeck (Versión 10.6.30) — C2TECK S.A.C.",
    icon: fs.existsSync(path.join(__dirname, "icon.png"))
      ? path.join(__dirname, "icon.png")
      : undefined,
    autoHideMenuBar: true,
    frame: false,
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

  win.loadURL(appUrl);

  win.webContents.on(
    "did-fail-load",
    (_event, errorCode, errorDescription, _validatedURL, isMainFrame) => {
      if (!isMainFrame || errorCode === -3 || win.isDestroyed()) return;
      dialog.showErrorBox(
        isLogin ? "No se pudo iniciar el acceso — Systeck" : "No se pudo iniciar el escritorio — Systeck",
        `La aplicación no pudo cargar.\n\n${errorDescription} (${errorCode})`,
      );
      win.close();
    },
  );

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
  if (loginWindow && !loginWindow.isDestroyed()) {
    loginWindow.focus();
    return;
  }

  const appUrl = STANDALONE_URL || getAppUrl();
  const loginUrl = new URL(appUrl);
  loginUrl.searchParams.set("login", "1");
  loginUrl.searchParams.set("desktop", "1");
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
  const desktopUrl = new URL(appUrl);
  desktopUrl.searchParams.set("desktop", "1");
  createWindow(desktopUrl.toString(), {
    width: 1600,
    height: 900,
    minWidth: 1280,
    minHeight: 768,
    title: "Systeck (Versión 10.6.30) — C2TECK S.A.C.",
  });
}

function getWindowForSender(sender) {
  if (mainWindow && !mainWindow.isDestroyed() && mainWindow.webContents === sender) {
    return mainWindow;
  }
  if (loginWindow && !loginWindow.isDestroyed() && loginWindow.webContents === sender) {
    return loginWindow;
  }
  return null;
}

ipcMain.on("window:minimize", (event) => getWindowForSender(event.sender)?.minimize());
ipcMain.on("window:maximize", (event) => {
  const win = getWindowForSender(event.sender);
  if (!win) return;
  if (win.isMaximized()) win.unmaximize();
  else win.maximize();
});
ipcMain.on("window:close", (event) => getWindowForSender(event.sender)?.close());
ipcMain.handle("window:isMaximized", (event) => getWindowForSender(event.sender)?.isMaximized() ?? false);
ipcMain.on("desktop:startup-ready", (event) => {
  if (
    !loginWindow ||
    loginWindow.isDestroyed() ||
    loginWindow.webContents !== event.sender
  ) {
    return;
  }

  if (!loginWindow.isVisible()) {
    loginWindow.show();
    loginWindow.focus();
  }
});
ipcMain.on("desktop:workspace-ready", (event) => {
  if (
    !mainWindow ||
    mainWindow.isDestroyed() ||
    mainWindow.webContents !== event.sender
  ) {
    return;
  }

  if (!mainWindow.isVisible()) {
    mainWindow.show();
    mainWindow.focus();
  }
  if (loginWindow && !loginWindow.isDestroyed()) {
    loginWindow.close();
  }
});
ipcMain.handle("external:open-version-history", async () => {
  const versionUrl = new URL(STANDALONE_URL || getAppUrl());
  versionUrl.pathname = "/versiones";
  versionUrl.search = "";
  versionUrl.hash = "";
  await shell.openExternal(versionUrl.toString());
});
ipcMain.on("desktop:login-success", (event) => {
  if (!loginWindow || loginWindow.isDestroyed() || loginWindow.webContents !== event.sender) {
    return;
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
