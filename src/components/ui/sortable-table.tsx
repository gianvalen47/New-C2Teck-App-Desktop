import {
  Children,
  Fragment,
  cloneElement,
  forwardRef,
  isValidElement,
  useState,
  type KeyboardEvent,
  type ReactElement,
  type ReactNode,
  type ThHTMLAttributes,
  type TableHTMLAttributes,
} from "react";

type SortState = {
  columnIndex: number;
  direction: "ascending" | "descending";
};

function getNodeText(node: ReactNode): string {
  if (typeof node === "string" || typeof node === "number") return String(node);
  if (Array.isArray(node)) return node.map(getNodeText).join("");
  if (isValidElement<{ children?: ReactNode }>(node)) return getNodeText(node.props.children);
  return "";
}

function normalizeSortValue(value: string) {
  const text = value.trim();
  const isoDate = text.match(/^(\d{4})[-/](\d{1,2})[-/](\d{1,2})$/);
  if (isoDate)
    return {
      type: "date" as const,
      value: `${isoDate[1]}${isoDate[2].padStart(2, "0")}${isoDate[3].padStart(2, "0")}`,
    };

  const localDate = text.match(/^(\d{1,2})[./-](\d{1,2})[./-](\d{2,4})$/);
  if (localDate) {
    const year = localDate[3].length === 2 ? `20${localDate[3]}` : localDate[3];
    return {
      type: "date" as const,
      value: `${year}${localDate[2].padStart(2, "0")}${localDate[1].padStart(2, "0")}`,
    };
  }

  const numericText = text.replace(/^(S\/|S\/\.|\$|€|£)\s*/i, "").trim();
  const standardNumber = numericText.match(/^-?\d+(?:\.\d+)?$/);
  const groupedNumber = numericText.match(/^-?\d{1,3}(?:,\d{3})+(?:\.\d+)?$/);
  if (standardNumber || groupedNumber) {
    return { type: "number" as const, value: Number(numericText.replace(/,/g, "")) };
  }

  return { type: "text" as const, value: text };
}

function compareCellValues(left: string, right: string) {
  const a = normalizeSortValue(left);
  const b = normalizeSortValue(right);
  if (a.type === b.type && (a.type === "number" || a.type === "date")) {
    return a.value < b.value ? -1 : a.value > b.value ? 1 : 0;
  }
  return a.value.toString().localeCompare(b.value.toString(), "es", {
    numeric: true,
    sensitivity: "base",
  });
}

function flattenRows(children: ReactNode): ReactElement<{ children?: ReactNode }>[] | null {
  const elements: ReactElement<{ children?: ReactNode }>[] = [];
  const collect = (nodes: ReactNode) => {
    Children.toArray(nodes).forEach((node) => {
      if (!isValidElement<{ children?: ReactNode }>(node)) return;
      if (node.type === "tr") {
        elements.push(node as ReactElement<{ children?: ReactNode }>);
      } else if (node.type === Fragment) {
        collect(node.props.children);
      }
    });
  };
  collect(children);
  return elements.length ? elements : null;
}

export const SortableTable = forwardRef<HTMLTableElement, TableHTMLAttributes<HTMLTableElement>>(
  ({ children, ...props }, ref) => {
    const [sort, setSort] = useState<SortState | null>(null);
    let headerColumnIndex = 0;

    const enhanceNode = (node: ReactNode): ReactNode => {
      if (Array.isArray(node)) return node.map((child) => enhanceNode(child));
      if (!isValidElement<{ children?: ReactNode }>(node)) {
        return node;
      }

      if (node.type === "th") {
        const columnIndex = headerColumnIndex++;
        const header = node as ReactElement<ThHTMLAttributes<HTMLTableCellElement>>;
        const label = getNodeText(header.props.children).trim();
        if (!label || header.props.onClick) return node;

        const direction = sort?.columnIndex === columnIndex ? sort.direction : null;
        const sortClick = () => {
          setSort((current) => ({
            columnIndex,
            direction:
              current?.columnIndex === columnIndex && current.direction === "ascending"
                ? "descending"
                : "ascending",
          }));
        };
        const sortKeyDown = (event: KeyboardEvent<HTMLTableCellElement>) => {
          if (event.key === "Enter" || event.key === " ") {
            event.preventDefault();
            sortClick();
          }
        };

        return cloneElement(header, {
          "aria-sort": direction ?? undefined,
          className: `${header.props.className ?? ""} cursor-pointer hover:bg-[#E6EEF9]`.trim(),
          title: `Ordenar por ${label}`,
          onClick: sortClick,
          onKeyDown: sortKeyDown,
          tabIndex: 0,
          children: (
            <>
              {header.props.children}
              <span aria-hidden="true" className="ml-1 text-[9px] text-slate-600">
                {direction === "ascending" ? "▲" : direction === "descending" ? "▼" : ""}
              </span>
            </>
          ),
        });
      }

      if (node.type === "thead") headerColumnIndex = 0;

      if (node.type === "tbody" && sort) {
        const rows = flattenRows(node.props.children);
        if (rows) {
          const sorted = rows
            .map((row, originalIndex) => ({ row, originalIndex }))
            .sort((left, right) => {
              const leftCell = Children.toArray(left.row.props.children)[sort.columnIndex];
              const rightCell = Children.toArray(right.row.props.children)[sort.columnIndex];
              const leftValue = getNodeText(leftCell).trim();
              const rightValue = getNodeText(rightCell).trim();
              if (!leftValue || !rightValue) {
                if (!leftValue && !rightValue) return left.originalIndex - right.originalIndex;
                const blanksLast = leftValue ? -1 : 1;
                return sort.direction === "ascending" ? blanksLast : -blanksLast;
              }
              const result = compareCellValues(leftValue, rightValue);
              return (
                (sort.direction === "ascending" ? result : -result) ||
                left.originalIndex - right.originalIndex
              );
            })
            .map(({ row }) => row);
          return cloneElement(node, { children: sorted });
        }
      }

      return cloneElement(node, { children: enhanceNode(node.props.children) });
    };

    return (
      <table ref={ref} {...props}>
        {enhanceNode(children)}
      </table>
    );
  },
);

SortableTable.displayName = "SortableTable";
