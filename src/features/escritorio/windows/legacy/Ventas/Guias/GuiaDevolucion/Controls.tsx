import React from 'react'

export function ROInput(props: React.InputHTMLAttributes<HTMLInputElement>) {
  return <input {...props} readOnly />
}

export function Numeric(props: React.InputHTMLAttributes<HTMLInputElement>) {
  return <input {...props} inputMode="decimal" />
}

export function DateInput(props: React.InputHTMLAttributes<HTMLInputElement>) {
  return <input {...props} type="date" />
}

export function MultiCombo(props: { items?: string[] }) {
  return (
    <select disabled>
      <option>-</option>
      {props.items?.map((it, i) => (
        <option key={i} value={it}>
          {it}
        </option>
      ))}
    </select>
  )
}
