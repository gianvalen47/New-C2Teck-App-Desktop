export async function apiFetch(input: RequestInfo | URL, init?: RequestInit) {
  const sessionRaw = typeof window !== 'undefined' ? window.localStorage.getItem('sigecoom_session') : null;
  let codigo: string | null = null;
  if (sessionRaw) {
    try {
      const s = JSON.parse(sessionRaw as string);
      codigo = (s?.empresa_actual?.codigo || '').toString().trim() || null;
    } catch (_) {
      codigo = null;
    }
  }
  const myInit: RequestInit = Object.assign({}, init || {});
  // normalize headers into an object
  const headers: Record<string, any> = {};
  if (myInit.headers instanceof Headers) {
    myInit.headers.forEach((v, k) => { headers[k] = v; });
  } else if (Array.isArray(myInit.headers)) {
    (myInit.headers as Array<[string, string]>).forEach(([k, v]) => { headers[k] = v; });
  } else if (myInit.headers && typeof myInit.headers === 'object') {
    Object.assign(headers, myInit.headers as Record<string, any>);
  }
  if (codigo) {
    // prefer existing header if present (case-insensitive)
    const exists = Object.keys(headers).find(h => h.toLowerCase() === 'x-sigecoom-codemp');
    if (!exists) headers['X-Sigecoom-CodEmp'] = String(codigo);
  }
  try {
    if (typeof window !== 'undefined' && (window as any).console && codigo) {
      try { console.info(`[apiFetch] Injecting X-Sigecoom-CodEmp=${String(codigo)}`); } catch (_) {}
    }
  } catch (_) {}
  myInit.headers = headers;
  return fetch(input, myInit);
}
