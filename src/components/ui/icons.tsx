import { Printer, Mail, Receipt, Plus, FileSpreadsheet, ArrowDown, ArrowRight, FileSearch } from "lucide-react";

export function TicketPrinterIcon({ className = "h-4 w-4" }: { className?: string }) {
  return (
    <div className={`relative inline-block ${className}`}>
      <Printer className="w-full h-full text-current" />
      <div className="absolute -bottom-[2px] -right-[2px] bg-white rounded-full p-[1px]">
        <Receipt className="w-[10px] h-[10px] text-blue-600 stroke-[2.5]" />
      </div>
    </div>
  );
}

export function EmailSendIcon({ className = "h-4 w-4" }: { className?: string }) {
  return (
    <div className={`relative inline-block ${className}`}>
      <Mail className="w-full h-full text-current" />
      <div className="absolute -bottom-[2px] -right-[2px] bg-white rounded-full p-[1px]">
        <ArrowRight className="w-[10px] h-[10px] text-sky-600 stroke-[2.5]" />
      </div>
    </div>
  );
}

export function CreditNoteIcon({ className = "h-4 w-4" }: { className?: string }) {
  return (
    <div className={`relative inline-block ${className}`}>
      <Receipt className="w-full h-full text-current" />
      <div className="absolute -bottom-[2px] -right-[2px] bg-white rounded-full p-[1px]">
        <Plus className="w-[10px] h-[10px] text-emerald-600 stroke-[2.5]" />
      </div>
    </div>
  );
}

export function DownloadDocumentIcon({ className = "h-4 w-4" }: { className?: string }) {
  return (
    <div className={`relative inline-block ${className}`}>
      <FileSpreadsheet className="w-full h-full text-current" />
      <div className="absolute -bottom-[2px] -right-[2px] bg-white rounded-full p-[1px]">
        <ArrowDown className="w-[10px] h-[10px] text-slate-800 stroke-[2.5]" />
      </div>
    </div>
  );
}

export function SearchDocumentIcon({ className = "h-4 w-4" }: { className?: string }) {
  return (
    <div className={`relative inline-block ${className}`}>
      <FileSearch className="w-full h-full text-current" />
    </div>
  );
}

// Re-export some raw lucide icons for backwards-compatibility with existing code
export { FileSpreadsheet, Mail };