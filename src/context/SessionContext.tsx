import React, { createContext, useContext, useEffect, useState } from "react";
import type { SessionInfo } from "@/lib/sigecoom-api";
import { fetchSession, cambiarEmpresa, hydrateSessionSnapshot } from "@/lib/sigecoom-api";

type SessionContextValue = {
  session: SessionInfo | null;
  loading: boolean;
  reloadSession: () => Promise<void>;
  changeCompany: (codigo: string) => Promise<SessionInfo>;
};

const SessionContext = createContext<SessionContextValue | undefined>(undefined);

export function useSession() {
  const ctx = useContext(SessionContext);
  if (!ctx) throw new Error("useSession must be used inside SessionProvider");
  return ctx;
}

export function SessionProvider({ children }: { children: React.ReactNode }) {
  const [session, setSession] = useState<SessionInfo | null>(() => {
    try {
      if (typeof window === "undefined") return null;
      const raw = window.localStorage.getItem("sigecoom_session");
      if (!raw) return null;
      const parsed = JSON.parse(raw);
      return hydrateSessionSnapshot(parsed);
    } catch (_) {
      return null;
    }
  });
  const [loading, setLoading] = useState<boolean>(!session);

  const reloadSession = async () => {
    setLoading(true);
    try {
      const s = await fetchSession();
      const hydrated = hydrateSessionSnapshot(s) ?? s;
      setSession(hydrated as SessionInfo);
      try { if (typeof window !== "undefined") window.localStorage.setItem("sigecoom_session", JSON.stringify(hydrated)); } catch(_){ }
    } catch (e) {
      // ignore
    } finally {
      setLoading(false);
    }
  };

  const changeCompany = async (codigo: string) => {
    // call backend change and update context immediately
    try {
      console.info('[SessionProvider] changeCompany called', codigo);
    } catch (_) {}
    const s = await cambiarEmpresa(codigo);
    try { console.info('[SessionProvider] changeCompany response', s); } catch (_) {}
    const hydrated = hydrateSessionSnapshot(s) ?? s;
    setSession(hydrated as SessionInfo);
    try { if (typeof window !== "undefined") window.localStorage.setItem("sigecoom_session", JSON.stringify(hydrated)); } catch(_){ }
    // also dispatch event for backwards compat
    try { window.dispatchEvent(new CustomEvent('systeck-session-updated', { detail: hydrated })); } catch(_){ }
    return hydrated as SessionInfo;
  };

  useEffect(() => {
    let mounted = true;
    if (!session) {
      reloadSession().catch(() => {});
    }
    const onEvent = (ev: Event) => {
      try {
        const custom = ev as CustomEvent | undefined;
        const s = custom && custom.detail ? (custom.detail as SessionInfo) : null;
        if (s) {
          if (!mounted) return;
          try { console.info('[SessionProvider] event session-updated received', s?.empresa_actual?.codigo); } catch(_){}
          const hydrated = hydrateSessionSnapshot(s) ?? s;
          setSession(hydrated as SessionInfo);
          try { if (typeof window !== "undefined") window.localStorage.setItem("sigecoom_session", JSON.stringify(hydrated)); } catch(_){}
        } else {
          // try reading from localStorage fallback
          try {
            const raw = window.localStorage.getItem("sigecoom_session");
            if (raw) {
              const parsed = JSON.parse(raw) as SessionInfo;
              const hydrated = hydrateSessionSnapshot(parsed) ?? parsed;
              if (mounted) setSession(hydrated as SessionInfo);
            }
          } catch(_){}
        }
      } catch (_) {}
    };
    window.addEventListener('systeck-session-updated', onEvent as EventListener);
    return () => { mounted = false; window.removeEventListener('systeck-session-updated', onEvent as EventListener); };
  }, []);

  return (
    <SessionContext.Provider value={{ session, loading, reloadSession, changeCompany }}>
      {children}
    </SessionContext.Provider>
  );
}
