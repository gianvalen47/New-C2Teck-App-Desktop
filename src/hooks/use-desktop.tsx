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
    };
  }
}

function isElectronRenderer() {
  return typeof window !== "undefined" && /Electron/.test(navigator.userAgent);
}

export function useDesktopMode() {
  const [isDesktop, setIsDesktop] = useState(false);
  const [isMaximized, setIsMaximized] = useState(false);

  useEffect(() => {
    const params = new URLSearchParams(window.location.search);
    const desktop =
      window.c2teckDesktop?.isDesktop === true ||
      params.get("desktop") === "1" ||
      isElectronRenderer();
    setIsDesktop(desktop);

    if (desktop && window.c2teckDesktop) {
      window.c2teckDesktop.isMaximized().then(setIsMaximized);
    }
  }, []);

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
