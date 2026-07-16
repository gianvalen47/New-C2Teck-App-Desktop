Public Class Estilo

  Public Sub cargaEstiloDataDrid(ByVal dgvDatos)
    With dgvDatos
      .AlternatingRowsDefaultCellStyle.BackColor = Color.White
      .DefaultCellStyle.BackColor = Color.AliceBlue
      .BackgroundColor = Color.Beige

      .BackColor = Color.Beige
      .ForeColor = Color.MidnightBlue
      .ReadOnly = True
      .BorderStyle = BorderStyle.None
      .Font = New Font("Microsoft Sans Serif", 8.0!, FontStyle.Bold)

      .AllowUserToAddRows = False
      .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
      .RowHeadersWidth = 18
      .MultiSelect = False
            .RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing

            .ScrollBars = System.Windows.Forms.ScrollBars.Both
      .AutoGenerateColumns = False
      .GridColor = System.Drawing.Color.LightSteelBlue
      .Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Dim i As Integer = 0
      While (i < dgvDatos.Columns.Count)
                .Columns(i).SortMode = DataGridViewColumnSortMode.Automatic
                i = i + 1
      End While
    End With
  End Sub
  Public Sub cargaEstiloGridExt(ByVal dgvDatos)
    With dgvDatos
      .AllowCardSizing = False
      .AllowColumnDrag = False
      .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
      .Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      .EmptyRows = True
      .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
      .GroupByBoxVisible = False
      .HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True  'CRR
      .HeaderFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(147, Byte), Integer))  'CRR
      .HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
      .RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True     'CRR
      .RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
            .ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
      .SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007

      Dim i As Integer = 0
      While (i < .RootTable.Columns.Count)
                .RootTable.Columns(i).AllowSort = True
                .RootTable.Columns(i).AllowSize = True
        .RootTable.Columns(i).HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        i = i + 1
      End While
    End With
  End Sub
  Public Sub cargaEstiloGridExtAlternating(ByVal dgvDatos)
    With dgvDatos
      .AllowCardSizing = False
      .AllowColumnDrag = False
      .AlternatingColors = True
      .AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(253, Byte), Integer))
      .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
      .Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      .EmptyRows = True
      .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
      .GroupByBoxVisible = False
      .HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True  'CRR
      .HeaderFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(147, Byte), Integer))  'CRR
      .HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
      .RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True     'CRR
      .RowFormatStyle.FontSize = 8.5!
      .RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
            .ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
      '.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007

      Dim i As Integer = 0
      While (i < .RootTable.Columns.Count)
                .RootTable.Columns(i).AllowSort = True
                .RootTable.Columns(i).AllowSize = True
        .RootTable.Columns(i).HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        i = i + 1
      End While
    End With
  End Sub
  Public Sub cargaEstiloGrid_Bucadores(ByVal dgvDatos)
    With dgvDatos
      .AllowCardSizing = False
      .AllowColumnDrag = False
      .AlternatingColors = True
      '.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(253, Byte), Integer))
      .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
      .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .GroupByBoxVisible = False
      .RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .SelectedFormatStyle.BackColor = System.Drawing.Color.LightSteelBlue
      .SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .FocusCellFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .FocusCellFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
      .VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005
      .EmptyRows = True
      .GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
      .RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
      .ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
      .HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
      .RowFormatStyle.FontSize = 7.5!
      .Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
      Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)

      Dim i As Integer = 0
      While (i < .RootTable.Columns.Count)
                .RootTable.Columns(i).AllowSort = True
                .RootTable.Columns(i).AllowSize = True
        .RootTable.Columns(i).HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        i = i + 1
      End While
    End With
    End Sub

    Public Sub CargaEstiloGrid(ByVal dgDatos)
        With dgDatos
            .AllowCardSizing = False
            .AllowColumnDrag = False
            .AlternatingColors = True
            .AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(253, Byte), Integer))
            .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .GroupByBoxVisible = False
            .RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
            .SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
            '.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
            .EmptyRows = True
            .GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
            .RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
            .ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
            .HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
            .RowFormatStyle.FontSize = 9.0!
            .Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)

            'Dim i As Integer = 0
            'While (i < .RootTable.Columns.Count)
            '    .RootTable.Columns(i).AllowSort = False
            '    .RootTable.Columns(i).AllowSize = False
            '    .RootTable.Columns(i).HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            '    i = i + 1
            'End While
        End With
    End Sub
End Class
