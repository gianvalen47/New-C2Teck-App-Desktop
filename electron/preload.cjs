// Preload seguro: expone API mínima al renderer
const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld("c2teckDesktop", {
  isDesktop: true,
  version: "1.0.0",
  minimize: () => ipcRenderer.send("window:minimize"),
  maximize: () => ipcRenderer.send("window:maximize"),
  close: () => ipcRenderer.send("window:close"),
  isMaximized: () => ipcRenderer.invoke("window:isMaximized"),
  startupReady: () => ipcRenderer.send("desktop:startup-ready"),
  workspaceReady: () => ipcRenderer.send("desktop:workspace-ready"),
  loginSuccess: () => ipcRenderer.send("desktop:login-success"),
  openVersionHistory: () => ipcRenderer.invoke("external:open-version-history"),
});
