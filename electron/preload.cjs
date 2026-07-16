// Preload seguro: expone API mínima al renderer
const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld("c2teckDesktop", {
  isDesktop: true,
  version: "1.0.0",
  minimize: () => ipcRenderer.send("window:minimize"),
  maximize: () => ipcRenderer.send("window:maximize"),
  close: () => ipcRenderer.send("window:close"),
  isMaximized: () => ipcRenderer.invoke("window:isMaximized"),
  loginSuccess: () => ipcRenderer.send("desktop:login-success"),
});
