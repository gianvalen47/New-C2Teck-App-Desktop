const http = require('http');
const fs = require('fs');
const path = require('path');
const { exec } = require('child_process');

const PORT = 3333;
const ROOT_DIR = path.resolve(__dirname, '..');
const ESCRITORIO_PATH = path.join(ROOT_DIR, 'src', 'routes', 'escritorio.tsx');
const HTML_MAPPER_PATH = path.join(ROOT_DIR, 'src', 'assets', 'new-logos', 'Mapeo_Ribbon_SIGECOM.html');

function normalizeKey(v) {
  return v
    .replace(/\\n|\n/g, ' ')
    .normalize('NFD')
    .replace(/[\u0300-\u036f]/g, '')
    .toLowerCase()
    .replace(/[^a-z0-9]+/g, ' ')
    .trim();
}

function updateAliases(updates) {
  if (!fs.existsSync(ESCRITORIO_PATH)) {
    return { success: false, error: 'No se encontró escritorio.tsx en ' + ESCRITORIO_PATH };
  }

  let content = fs.readFileSync(ESCRITORIO_PATH, 'utf8');
  const match = content.match(/const SMALL_COLOR_ICON_ALIASES: Record<string, string> = \{([\s\S]*?)\n\};/);
  if (!match) {
    return { success: false, error: 'No se encontró la definición de SMALL_COLOR_ICON_ALIASES en escritorio.tsx' };
  }

  let block = match[1];

  for (const [rawLabel, iconKey] of Object.entries(updates)) {
    if (!iconKey) continue;
    const norm = normalizeKey(rawLabel);
    const regex = new RegExp(`(["']?${norm}["']?\\s*:\\s*)["'][^"']+["']`, 'i');
    if (regex.test(block)) {
      block = block.replace(regex, `$1"${iconKey}"`);
    } else {
      block += `\n  "${norm}": "${iconKey}",`;
    }
  }

  content = content.replace(match[0], `const SMALL_COLOR_ICON_ALIASES: Record<string, string> = {${block}\n};`);
  fs.writeFileSync(ESCRITORIO_PATH, content, 'utf8');
  return { success: true, count: Object.keys(updates).length };
}

function getAliases() {
  if (!fs.existsSync(ESCRITORIO_PATH)) return {};
  const content = fs.readFileSync(ESCRITORIO_PATH, 'utf8');
  const match = content.match(/const SMALL_COLOR_ICON_ALIASES: Record<string, string> = \{([\s\S]*?)\n\};/);
  if (!match) return {};

  const aliases = {};
  match[1].split('\n').forEach(line => {
    const m = line.match(/"([^"]+)":\s*"([^"]+)"/);
    if (m) aliases[normalizeKey(m[1])] = m[2];
  });
  return aliases;
}

const server = http.createServer((req, res) => {
  // Enable full CORS
  res.setHeader('Access-Control-Allow-Origin', '*');
  res.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS');
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type');

  if (req.method === 'OPTIONS') {
    res.writeHead(204);
    res.end();
    return;
  }

  const url = new URL(req.url, `http://localhost:${PORT}`);

  if (url.pathname === '/api/status') {
    res.writeHead(200, { 'Content-Type': 'application/json' });
    res.end(JSON.stringify({ ok: true, escritorioPath: ESCRITORIO_PATH }));
    return;
  }

  if (url.pathname === '/api/aliases') {
    res.writeHead(200, { 'Content-Type': 'application/json' });
    res.end(JSON.stringify({ ok: true, aliases: getAliases() }));
    return;
  }

  if (url.pathname === '/api/save' && req.method === 'POST') {
    let body = '';
    req.on('data', chunk => { body += chunk; });
    req.on('end', () => {
      try {
        const data = JSON.parse(body || '{}');
        let updates = {};
        if (data.updates) updates = data.updates;
        else if (data.label && data.iconKey) updates[data.label] = data.iconKey;

        const result = updateAliases(updates);
        res.writeHead(result.success ? 200 : 400, { 'Content-Type': 'application/json' });
        res.end(JSON.stringify(result));
      } catch (err) {
        res.writeHead(500, { 'Content-Type': 'application/json' });
        res.end(JSON.stringify({ success: false, error: String(err) }));
      }
    });
    return;
  }

  // Serve Mapeo_Ribbon_SIGECOM.html on / or /index.html
  if (url.pathname === '/' || url.pathname === '/index.html' || url.pathname === '/Mapeo_Ribbon_SIGECOM.html') {
    if (fs.existsSync(HTML_MAPPER_PATH)) {
      res.writeHead(200, { 'Content-Type': 'text/html; charset=utf-8' });
      fs.createReadStream(HTML_MAPPER_PATH).pipe(res);
      return;
    }
  }

  res.writeHead(404, { 'Content-Type': 'text/plain' });
  res.end('Not Found');
});

server.listen(PORT, () => {
  const url = `http://localhost:${PORT}`;
  console.log(`\n🚀 Servidor de Mapeo de Iconos SIGECOM corriendo en: ${url}`);
  console.log(`📁 Conectado directamente a: ${ESCRITORIO_PATH}`);
  console.log(`⚡ Cualquier cambio en la página se guardará automáticamente en escritorio.tsx!\n`);

  // Open browser automatically on Windows
  const startCmd = process.platform === 'win32' ? 'start' : 'open';
  exec(`${startCmd} ${url}`, () => {});
});
