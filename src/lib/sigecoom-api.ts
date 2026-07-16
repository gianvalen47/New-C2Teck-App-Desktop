export type SigecoomClient = {
  id: string;
  name: string;
  ruc?: string;
  address?: string;
  phone?: string;
  email?: string;
  active: number;
  created_at: string;
};

export type SigecoomSale = {
  id: string;
  type: string;
  series?: string;
  number?: number;
  date: string;
  client_id?: string;
  items: Array<{
    code?: string;
    description: string;
    unit: string;
    quantity: number;
    price: number;
    total?: number;
  }>;
  subtotal: number;
  tax: number;
  total: number;
  extra_data?: Record<string, any>;
  status: string;
  created_at: string;
  updated_at?: string;
};

export type InventoryItem = {
  id: string;
  sku: string;
  name: string;
  description?: string;
  category?: string;
  stock: number;
  min_stock?: number;
  supplier?: string;
  cost_price?: number;
  sale_price?: number;
  unit: string;
  active: number;
  created_at: string;
  updated_at?: string;
};

export type Location = {
  id: string;
  code: string;
  warehouse: string;
  aisle?: string;
  shelf?: string;
  row?: string;
  level?: string;
  description?: string;
  capacity?: number;
  occupancy_percent?: number;
  active: number;
  created_at: string;
  updated_at?: string;
};

export type BankAccount = {
  id: string;
  bank_name: string;
  account_number: string;
  currency: string;
  active: number;
  created_at: string;
  updated_at?: string;
};

export type BankTransaction = {
  id: string;
  bank_account_id?: string;
  source: string;
  date: string;
  description: string;
  reference?: string;
  amount: number;
  direction: string;
  reconciled: boolean;
  created_at: string;
  updated_at?: string;
};

export type SigecoomJournalLine = {
  account: string;
  description?: string;
  reference?: string;
  debit: number;
  credit: number;
  cost_center?: string;
};

export type SigecoomJournalEntry = {
  id: string;
  entry_number: string;
  date: string;
  type: string;
  currency: string;
  exchange_rate?: number;
  description?: string;
  lines: SigecoomJournalLine[];
  created_at: string;
  updated_at?: string;
};

export type PurchaseRegister = {
  id: string;
  document_type: string;
  series?: string;
  number?: string;
  document_date: string;
  receipt_date: string;
  supplier_ruc: string;
  supplier_name: string;
  currency: string;
  taxable_base: number;
  igv: number;
  non_taxable: number;
  total: number;
  retention?: number;
  cost_center?: string;
  reference?: string;
  description?: string;
  status: string;
  created_at: string;
  updated_at?: string;
};

export type CajaChica = {
  id: string;
  name: string;
  responsible: string;
  assigned_fund: number;
  currency: string;
  status: string;
  location?: string;
  created_at: string;
  updated_at?: string;
};

export type Gasto = {
  id: string;
  caja_chica_id: string;
  date: string;
  concept: string;
  voucher_type?: string;
  voucher_number?: string;
  amount: number;
  category: string;
  description?: string;
  status: string;
  submitted_date?: string;
  reimbursed_date?: string;
  created_at: string;
  updated_at?: string;
};

const API_BASE_URL =
  (typeof import.meta !== "undefined" && import.meta.env?.VITE_API_URL) ||
  "http://127.0.0.1:8000";
const API_V1_PREFIX = "/api/v1";

// ============================================================================
// HEALTH CHECK
// ============================================================================

export async function checkBackendHealth(): Promise<boolean> {
  try {
    const response = await fetch(`${API_BASE_URL}/health`);
    return response.ok;
  } catch (error) {
    console.error("Backend health check failed:", error);
    return false;
  }
}

// ============================================================================
// CLIENTS API
// ============================================================================

export async function fetchSigecoomClients(): Promise<SigecoomClient[]> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/clients`);
  if (!response.ok) {
    throw new Error("No se pudo cargar clientes desde el backend");
  }
  return response.json();
}

export async function createSigecoomClient(data: {
  name: string;
  ruc?: string;
  address?: string;
  phone?: string;
  email?: string;
}): Promise<SigecoomClient> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/clients`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear el cliente");
  }
  return response.json();
}

export async function getSigecoomClient(clientId: string): Promise<SigecoomClient> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/clients/${clientId}`);
  if (!response.ok) {
    throw new Error("No se pudo cargar el cliente");
  }
  return response.json();
}

// ============================================================================
// SALES/INVOICES API
// ============================================================================

export async function fetchSigecoomSales(search?: string): Promise<SigecoomSale[]> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/sales`;
  if (search) {
    url += `?search=${encodeURIComponent(search)}`;
  }
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo cargar las ventas");
  }
  return response.json();
}

export async function createSigecoomSale(data: {
  type: string;
  series?: string;
  number?: number;
  date?: string;
  client_id?: string;
  items: Array<{
    code?: string;
    description: string;
    unit: string;
    quantity: number;
    price: number;
  }>;
  subtotal?: number;
  tax?: number;
  total?: number;
  extra_data?: Record<string, any>;
}): Promise<SigecoomSale> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/sales`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear la venta");
  }
  return response.json();
}

export async function getSigecoomSale(saleId: string): Promise<SigecoomSale> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/sales/${saleId}`);
  if (!response.ok) {
    throw new Error("No se pudo cargar la venta");
  }
  return response.json();
}

export async function issueSigecoomSale(saleId: string): Promise<SigecoomSale> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/sales/${saleId}/issue`, {
    method: "POST",
  });
  if (!response.ok) {
    throw new Error("No se pudo emitir la venta");
  }
  return response.json();
}

export async function updateSigecoomSale(saleId: string, data: {
  type?: string;
  series?: string;
  date?: string;
  client_id?: string;
  items?: Array<{
    code?: string;
    description: string;
    unit: string;
    quantity: number;
    price: number;
  }>;
  subtotal?: number;
  tax?: number;
  total?: number;
  extra_data?: Record<string, any>;
  status?: string;
}): Promise<SigecoomSale> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/sales/${saleId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar la venta");
  }
  return response.json();
}

export async function sendSigecoomSaleEmail(saleId: string, recipient?: string): Promise<SigecoomSale> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/sales/${saleId}/send-email`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ recipient }),
  });
  if (!response.ok) {
    throw new Error("No se pudo enviar el correo del comprobante");
  }
  return response.json();
}

export async function exportSigecoomSales(format = "csv", search?: string): Promise<Blob> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/sales/export?format=${encodeURIComponent(format)}`;
  if (search) {
    url += `&search=${encodeURIComponent(search)}`;
  }
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo exportar las ventas");
  }
  return response.blob();
}

export async function linkSigecoomSalePurchase(
  saleId: string,
  data: { purchase_reference?: string; supplier?: string },
): Promise<SigecoomSale> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/sales/${saleId}/link-purchase`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo vincular la compra al ingreso");
  }
  return response.json();
}

export async function fetchSigecoomJournalEntries(): Promise<SigecoomJournalEntry[]> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/journals`);
  if (!response.ok) {
    throw new Error("No se pudo cargar los asientos contables");
  }
  return response.json();
}

export async function createSigecoomJournalEntry(data: {
  entry_number: string;
  date: string;
  type: string;
  currency: string;
  exchange_rate?: number;
  description?: string;
  lines: Array<{
    account: string;
    description?: string;
    reference?: string;
    debit: number;
    credit: number;
    cost_center?: string;
  }>;
}): Promise<SigecoomJournalEntry> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/journals`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo guardar el asiento contable");
  }
  return response.json();
}

export async function fetchBankAccounts(): Promise<BankAccount[]> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/banking`);
  if (!response.ok) {
    throw new Error("No se pudo cargar las cuentas bancarias");
  }
  return response.json();
}

export async function createBankAccount(data: {
  bank_name: string;
  account_number: string;
  currency?: string;
}): Promise<BankAccount> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/banking`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear la cuenta bancaria");
  }
  return response.json();
}

export async function fetchBankTransactions(source?: string, bankAccountId?: string): Promise<BankTransaction[]> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/banking/transactions`;
  const params = new URLSearchParams();
  if (source) {
    params.set("source", source);
  }
  if (bankAccountId) {
    params.set("bank_account_id", bankAccountId);
  }
  const query = params.toString();
  if (query) {
    url += `?${query}`;
  }

  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo cargar los movimientos bancarios");
  }
  return response.json();
}

export async function createBankTransaction(data: {
  bank_account_id?: string;
  source: string;
  date?: string;
  description: string;
  reference?: string;
  amount: number;
  direction: string;
  reconciled?: boolean;
}): Promise<BankTransaction> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/banking/transactions`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear el movimiento bancario");
  }
  return response.json();
}

export async function updateBankTransaction(transactionId: string, data: {
  reconciled?: boolean;
}): Promise<BankTransaction> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/banking/transactions/${transactionId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar el movimiento bancario");
  }
  return response.json();
}

// ============================================================================
// INVENTORY API
// ============================================================================

export async function fetchInventory(search?: string): Promise<InventoryItem[]> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/inventory`;
  if (search) {
    url += `?search=${encodeURIComponent(search)}`;
  }
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo cargar el inventario");
  }
  return response.json();
}

export async function exportSigecoomInventory(format = "csv"): Promise<Blob> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/inventory/export?format=${encodeURIComponent(format)}`);
  if (!response.ok) {
    throw new Error("No se pudo exportar el inventario");
  }
  return response.blob();
}

export async function fetchSigecoomLocations(search?: string): Promise<Location[]> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/locations`;
  if (search) {
    url += `?search=${encodeURIComponent(search)}`;
  }
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo cargar las ubicaciones");
  }
  return response.json();
}

export async function createSigecoomLocation(data: {
  code: string;
  warehouse: string;
  aisle?: string;
  shelf?: string;
  row?: string;
  level?: string;
  description?: string;
  capacity?: number;
  occupancy_percent?: number;
}): Promise<Location> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/locations`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear la ubicación");
  }
  return response.json();
}

export async function updateSigecoomLocation(locationId: string, data: {
  code?: string;
  warehouse?: string;
  aisle?: string;
  shelf?: string;
  row?: string;
  level?: string;
  description?: string;
  capacity?: number;
  occupancy_percent?: number;
  active?: number;
}): Promise<Location> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/locations/${locationId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar la ubicación");
  }
  return response.json();
}

export async function deleteSigecoomLocation(locationId: string): Promise<void> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/locations/${locationId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("No se pudo eliminar la ubicación");
  }
}

export async function importSigecoomInventory(file: File): Promise<{ created: number; updated: number }> {
  const formData = new FormData();
  formData.append("file", file);
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/inventory/import`, {
    method: "POST",
    body: formData,
  });
  if (!response.ok) {
    throw new Error("No se pudo importar el inventario");
  }
  return response.json();
}

export async function createInventoryItem(data: {
  sku: string;
  name: string;
  description?: string;
  category?: string;
  stock?: number;
  min_stock?: number;
  supplier?: string;
  cost_price?: number;
  sale_price?: number;
  unit?: string;
}): Promise<InventoryItem> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/inventory`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear el artículo de inventario");
  }
  return response.json();
}

export async function updateInventoryItem(itemId: string, data: {
  name?: string;
  description?: string;
  category?: string;
  stock?: number;
  min_stock?: number;
  supplier?: string;
  cost_price?: number;
  sale_price?: number;
  active?: number;
  unit?: string;
}): Promise<InventoryItem> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/inventory/${itemId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar el artículo de inventario");
  }
  return response.json();
}

export async function deleteInventoryItem(itemId: string): Promise<void> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/inventory/${itemId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("No se pudo eliminar el artículo de inventario");
  }
}

export async function getInventoryItem(itemId: string): Promise<InventoryItem> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/inventory/${itemId}`);
  if (!response.ok) {
    throw new Error("No se pudo cargar el artículo");
  }
  return response.json();
}

// ============================================================================
// PURCHASE REGISTER API
// ============================================================================

export async function fetchPurchaseRegisters(
  statusFilter?: string,
  documentType?: string
): Promise<PurchaseRegister[]> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/purchases`;
  const params = new URLSearchParams();
  if (statusFilter) params.append("status_filter", statusFilter);
  if (documentType) params.append("document_type", documentType);
  if (params.toString()) url += `?${params.toString()}`;

  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo cargar los registros de compra");
  }
  return response.json();
}

export async function getPurchaseRegister(registerId: string): Promise<PurchaseRegister> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/purchases/${registerId}`);
  if (!response.ok) {
    throw new Error("No se pudo cargar el registro de compra");
  }
  return response.json();
}

export async function createPurchaseRegister(data: {
  document_type: string;
  series?: string;
  number?: string;
  document_date: string;
  supplier_ruc: string;
  supplier_name: string;
  currency?: string;
  taxable_base: number;
  igv: number;
  non_taxable: number;
  total: number;
  retention?: number;
  cost_center?: string;
  reference?: string;
  description?: string;
}): Promise<PurchaseRegister> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/purchases`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear el registro de compra");
  }
  return response.json();
}

export async function updatePurchaseRegister(
  registerId: string,
  data: Partial<{
    document_type: string;
    supplier_name: string;
    currency: string;
    taxable_base: number;
    igv: number;
    non_taxable: number;
    total: number;
    retention: number;
    cost_center: string;
    reference: string;
    description: string;
    status: string;
  }>
): Promise<PurchaseRegister> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/purchases/${registerId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar el registro de compra");
  }
  return response.json();
}

export async function deletePurchaseRegister(registerId: string): Promise<void> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/purchases/${registerId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("No se pudo eliminar el registro de compra");
  }
}

// ============================================================================
// CAJA CHICA API
// ============================================================================

export async function fetchCajaChica(): Promise<CajaChica[]> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica`);
  if (!response.ok) {
    throw new Error("No se pudo cargar las cajas chicas");
  }
  return response.json();
}

export async function getCajaChica(cajaId: string): Promise<CajaChica> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}`);
  if (!response.ok) {
    throw new Error("No se pudo cargar la caja chica");
  }
  return response.json();
}

export async function createCajaChica(data: {
  name: string;
  responsible: string;
  assigned_fund: number;
  currency?: string;
  location?: string;
}): Promise<CajaChica> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear la caja chica");
  }
  return response.json();
}

export async function updateCajaChica(
  cajaId: string,
  data: Partial<{
    name: string;
    responsible: string;
    assigned_fund: number;
    status: string;
    location: string;
  }>
): Promise<CajaChica> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar la caja chica");
  }
  return response.json();
}

// ============================================================================
// GASTO API
// ============================================================================

export async function fetchGastos(cajaId: string, statusFilter?: string): Promise<Gasto[]> {
  let url = `${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}/gastos`;
  if (statusFilter) url += `?status_filter=${statusFilter}`;

  const response = await fetch(url);
  if (!response.ok) {
    throw new Error("No se pudo cargar los gastos");
  }
  return response.json();
}

export async function createGasto(
  cajaId: string,
  data: {
    concept: string;
    voucher_type?: string;
    voucher_number?: string;
    amount: number;
    category: string;
    description?: string;
    date?: string;
  }
): Promise<Gasto> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}/gastos`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo crear el gasto");
  }
  return response.json();
}

export async function updateGasto(
  gastoId: string,
  data: Partial<{
    concept: string;
    amount: number;
    category: string;
    description: string;
    status: string;
    submitted_date: string;
    reimbursed_date: string;
  }>
): Promise<Gasto> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/gastos/${gastoId}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    throw new Error("No se pudo actualizar el gasto");
  }
  return response.json();
}

export async function deleteGasto(gastoId: string): Promise<void> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/gastos/${gastoId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("No se pudo eliminar el gasto");
  }
}

export async function submitGastos(cajaId: string, gastoIds: string[]): Promise<any> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}/submit`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(gastoIds),
  });
  if (!response.ok) {
    throw new Error("No se pudo presentar los gastos");
  }
  return response.json();
}

export async function reimburseGastos(cajaId: string, gastoIds: string[]): Promise<any> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}/reimburse`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(gastoIds),
  });
  if (!response.ok) {
    throw new Error("No se pudo reembolsar los gastos");
  }
  return response.json();
}

export async function getCajaBalance(cajaId: string): Promise<{
  caja_id: string;
  assigned_fund: number;
  total_gastos_pending: number;
  total_gastos_reimbursed: number;
  saldo_actual: number;
  reembolso_a_solicitar: number;
}> {
  const response = await fetch(`${API_BASE_URL}${API_V1_PREFIX}/caja-chica/${cajaId}/balance`);
  if (!response.ok) {
    throw new Error("No se pudo calcular el saldo");
  }
  return response.json();
}
