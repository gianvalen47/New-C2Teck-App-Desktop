import React from "react";

export type SortBy = { col: string; asc: boolean };

export default function SortableTh({
  col,
  label,
  sortBy,
  setSortBy,
  className = "",
}: {
  col: string;
  label: React.ReactNode;
  sortBy: SortBy;
  setSortBy: React.Dispatch<React.SetStateAction<SortBy>>;
  className?: string;
}) {
  const isActive = sortBy.col === col;
  return (
    <th
      className={`px-3 py-2 border-r border-slate-200 font-semibold whitespace-nowrap ${className} ${col ? 'cursor-pointer hover:bg-[#E6EEF9]' : ''}`}
      onClick={() => {
        if (!col) return;
        setSortBy(prev => (prev.col === col ? { col, asc: !prev.asc } : { col, asc: true }));
      }}
    >
      <div className="flex items-center justify-center gap-1 select-none">
        <span>{label}</span>
        {isActive && <span className="text-[10px] text-slate-500">{sortBy.asc ? '▲' : '▼'}</span>}
      </div>
    </th>
  );
}
