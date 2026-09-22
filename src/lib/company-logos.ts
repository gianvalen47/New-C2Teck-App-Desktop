// This module builds a map of available company logo URLs using Vite's import.meta.glob.
// It returns a function `getLogoUrl(code)` that resolves a code like '05' to the URL of '05.png' if available.

// Note: `import.meta.glob` is evaluated by Vite at build time. Use the newer
// `query: '?url'` + `import: 'default'` options (replaces deprecated `as: 'url'`).
// We keep the lookup tolerant to either a direct string or an object with
// a `default` export to remain compatible across Vite versions.

const modules = import.meta.glob('../assets/Logos/logoscod/*.{png,jpg,jpeg}', { eager: true, query: '?url', import: 'default' }) as Record<string, any>;

const logoByBasename: Record<string, string> = {};
Object.entries(modules).forEach(([path, mod]) => {
  const parts = path.split('/');
  const name = parts[parts.length - 1];
  // `mod` may be a string (URL) or an object like { default: url }
  let url: string | undefined;
  if (typeof mod === 'string') url = mod;
  else if (mod && typeof mod === 'object' && typeof mod.default === 'string') url = mod.default;
  if (url) {
    logoByBasename[name.toLowerCase()] = url;
  }
});

export function getLogoUrl(code?: string | null): string | null {
  if (!code) return null;
  const key = `${String(code).trim()}`.toLowerCase();
  // Build candidate basenames to increase match robustness.
  const normalized = key.replace(/^0+/, ''); // strip leading zeros for numeric-normalized match
  const pad2 = normalized.length === 1 ? normalized.padStart(2, '0') : normalized;
  const pad3 = normalized.length <= 2 ? normalized.padStart(3, '0') : normalized;

  const candidates = new Set<string>([
    `${key}.png`, `${key}.jpg`, `${key}.jpeg`,
    `${normalized}.png`, `${normalized}.jpg`, `${normalized}.jpeg`,
    `${pad2}.png`, `${pad2}.jpg`, `${pad2}.jpeg`,
    `${pad3}.png`, `${pad3}.jpg`, `${pad3}.jpeg`,
  ].map(s => s.toLowerCase()));

  for (const c of candidates) {
    if (logoByBasename[c]) return logoByBasename[c];
  }
  return null;
}
