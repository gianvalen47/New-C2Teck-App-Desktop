import { useEffect, useState } from "react";

declare global {
  interface Window {
    c2teckDesktop?: {
      isDesktop: boolean;
      version: string;
      minimize: () => void;
      maximize: () => void;
      close: () => void;
      isMaximized: () => Promise<boolean>;
      loginSuccess: () => void;
      startupReady: () => void;
      workspaceReady: () => void;
      openVersionHistory: () => Promise<void>;
    };
  }
}

function isElectronRenderer() {
  return typeof window !== "undefined" && /Electron/.test(navigator.userAgent);
}

function detectDesktopMode() {
  if (typeof window === "undefined") return false;
  const params = new URLSearchParams(window.location.search);
  return (
    window.c2teckDesktop?.isDesktop === true ||
    params.get("desktop") === "1" ||
    isElectronRenderer()
  );
}

export function useDesktopMode() {
  const [isDesktop, setIsDesktop] = useState(false);
  const [isMaximized, setIsMaximized] = useState(false);

  useEffect(() => {
    setIsDesktop(detectDesktopMode());
  }, []);

  useEffect(() => {
    if (isDesktop && window.c2teckDesktop) {
      window.c2teckDesktop.isMaximized().then(setIsMaximized);
    }
  }, [isDesktop]);

  const minimize = () => window.c2teckDesktop?.minimize();
  const maximize = async () => {
    window.c2teckDesktop?.maximize();
    if (window.c2teckDesktop) {
      setIsMaximized(await window.c2teckDesktop.isMaximized());
    }
  };
  const close = () => window.c2teckDesktop?.close();

  return { isDesktop, isMaximized, minimize, maximize, close };
}
