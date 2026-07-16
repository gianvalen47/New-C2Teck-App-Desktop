Imports System.ServiceModel
Public Class frmConsultaCompras

    '===========================Servicios====================================================
    Private oMesaControlService As New SolicitudGastoService.SolicitudGastoServiceClient  'MesaControlService.MesaControlServiceClient
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private lMostrar As Boolean
    Private dtTipoDocumentos As DataTable
    Private dtDatos As DataTable
    Private IdProveedor As Integer
    Private dtAreas As DataTable
    Private dtMonedas As DataTable
    Private IdMesa As Integer
    Private IdCuenta As Integer
    Private IdGasto As Integer
    Private IdGastoDet As Integer

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtProveedor.KeyPress, cmbDocumento.KeyPress, cbFecFin.KeyPress, cbFecIni.KeyPress, cmbCodMon.KeyPress, cmbCodArea.KeyPress, txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    biMostrar_Click(sender, e)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
          txtProveedor.KeyPress, cmbDocumento.KeyPress, btnBuscar.KeyPress, dgvDatos.KeyPress, txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub

    Private Sub frmConsultaCompras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMesaControlService.Close()
            oMaestroService.Close()
            oDocumentoCtaCtesService.Close()
            oOrdenesCompraService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMesaControlService.Abort()
            oMaestroService.Abort()
            oDocumentoCtaCtesService.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMesaControlService.Abort()
            oMaestroService.Abort()
            oDocumentoCtaCtesService.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsultaCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub frmConsultaCompras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 154)
        '/*************************************************************************************/

        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Proveedor")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Proveedor")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        cmbCodMon.Value = "US"
        cbFecIni.Value = "01/" & Month(Today) & "/" & Year(Today)
        cbFecFin.Value = Today
        IdProveedor = 0
        txtProveedor.Text = "(Todos)"
        cmbDocumento.Value = 3
        listaDatos()
        refrescarMenus()
        dgvDatos.Select()
    End Sub

    Private Sub RowPossesionMesa(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdMesa").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionGasto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdGasto").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionCuenta(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCuenta").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub refrescarMenus()
        lMostrar = IIf(dgvDatos.RowCount > 0, True, False)
        Me.biMostrar.Enabled = lMostrar
        Me.biActualizar.Enabled = lMostrar
        Me.miMostrar.Enabled = lMostrar
        Me.miActualizar.Enabled = lMostrar
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            Dim row As DataRow = dtTipoDocumentos.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocumento.DataSource = dtTipoDocumentos
            cmbDocumento.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocumento.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocumento.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocumento.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocumento.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocumento.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocumento.SelectedIndex = 0
            dtTipoDocumentos = Nothing
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oMesaControlService.ConsultarCompras(Session.sCodEmp, cbFecIni.Value, cbFecFin.Value, cmbCodMon.Value, cmbCodArea.Value, IdProveedor, cmbDocumento.Value, txtSerdoc.Text, txtNumDoc.Text, toDouble(txtMonto.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            ''------------------------------------------Sumar Totales de Vencimiento---------------------------------------
            'If dtDatos.Rows.Count > 0 Then
            '    Dim lPorVencerSol, lVencidoSol, lPorVencerDol, lVencidoDol As Decimal
            '    For Each Fila As DataRow In dtDatos.Rows
            '        If Not IsDBNull(Fila.Item("Credito")) Then
            '            If CBool(Fila.Item("Credito")) = True Then
            '                If Fila.Item("CodMon") = "US" Then
            '                    If Not IsDBNull(Fila.Item("FecVencimiento")) Then
            '                        If Fila.Item("FecVencimiento") <= Today Then
            '                            lVencidoDol = lVencidoDol + (Fila.Item("Saldo"))
            '                        Else
            '                            lPorVencerDol = lPorVencerDol + (Fila.Item("Saldo"))
            '                        End If
            '                    End If
            '                ElseIf Fila.Item("CodMon") = "NS" Then
            '                    If Not IsDBNull(Fila.Item("FecVencimiento")) Then
            '                        If Fila.Item("FecVencimiento") <= Today Then
            '                            lVencidoSol = lVencidoSol + (Fila.Item("Saldo"))
            '                        Else
            '                            lPorVencerSol = lPorVencerSol + (Fila.Item("Saldo"))
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    Next
            '    txtPorVencerSol.Text = lPorVencerSol
            '    txtVencidoSol.Text = lVencidoSol
            '    txtPorVencerDol.Text = lPorVencerDol
            '    txtVencidoDol.Text = lVencidoDol
            '    txtSaldoSol.Text = lPorVencerSol + lVencidoSol
            '    txtSaldoDol.Text = lPorVencerDol + lVencidoDol
            'End If
            ''----------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        refrescarMenus()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If dgvDatos.RowCount > 0 Then
            IdCuenta = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdCuenta").Value) = True, 0, dgvDatos.CurrentRow.Cells("IdCuenta").Value)
            IdGasto = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdGasto").Value) = True, 0, dgvDatos.CurrentRow.Cells("IdGasto").Value)
            IdGastoDet = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdGastoDet").Value) = True, 0, dgvDatos.CurrentRow.Cells("IdGastoDet").Value)
            'IdMesa = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdMesa").Value) = True, 0, dgvDatos.CurrentRow.Cells("IdMesa").Value)
            If IdGasto = 0 And IdMesa = 0 Then
                Dim frm As New frmConsultaCompra_CtaxPagar
                frm.IdCuenta = IdCuenta
                frm.ShowDialog()
            Else
                Dim frm As New frmConsultaCompra
                frm.IdCuenta = IdCuenta
                frm.IdGasto = IdGasto
                frm.IdGastoDet = IdGastoDet
                'frm.IdMesa = IdMesa
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codMesa As String = ""
        Dim codGasto As String = ""
        Dim codCuenta As String = ""
        If dgvDatos.RowCount > 0 Then
            'codMesa = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdMesa").Value) = True, "", dgvDatos.CurrentRow.Cells("IdMesa").Value)
            codGasto = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdGasto").Value) = True, "", dgvDatos.CurrentRow.Cells("IdGasto").Value)
            codCuenta = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdCuenta").Value) = True, "", dgvDatos.CurrentRow.Cells("IdCuenta").Value)
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codGasto.Trim.Length > 0 Then
            RowPossesionGasto(dgvDatos, codGasto)
        ElseIf dgvDatos.RowCount > 0 And codMesa.Trim.Length > 0 Then
            RowPossesionMesa(dgvDatos, codMesa)
        ElseIf dgvDatos.RowCount > 0 And codCuenta.Trim.Length > 0 Then
            RowPossesionCuenta(dgvDatos, codCuenta)
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbDocumento.ValueChanged, cbFecIni.ValueChanged, cbFecFin.ValueChanged, txtNumDoc.TextChanged, cmbCodArea.ValueChanged, cmbCodMon.ValueChanged, txtProveedor.TextChanged, txtSerdoc.TextChanged, txtMonto.TextChanged
        listaDatos()
    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click, biImprimir.Click
        MostrarReporte()
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Documento Actual."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento Actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, _
                                    biMostrar.MouseLeave, _
                                    biActualizar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, _
                                    miMostrar.MouseLeave, _
                                    miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptConsultaCompra_Listado            

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.crvReportes.DisplayGroupTree = False

            reporte.SetParameterValue("pArea", IIf(toBlank(cmbCodArea.Value) = "", "(Todos)", cmbCodArea.Text))
            reporte.SetParameterValue("pDocumento", IIf(toBlank(cmbDocumento.Value) = "", "(Todos)", cmbDocumento.Text))
            reporte.SetParameterValue("pNumDoc", IIf(txtNumDoc.Text = "", "-", txtNumDoc.Text))
            reporte.SetParameterValue("pDesProv", IIf(IdProveedor = 0, "(Todos)", txtProveedor.Text))
            reporte.SetParameterValue("pDesProv", IIf(IdProveedor = 0, "(Todos)", txtProveedor.Text))
            ' reporte.SetParameterValue("pCodJob", IIf(txtNumJob.Text = "", "-", txtNumJob.Text))
            reporte.SetParameterValue("pCodJob", "")
            reporte.SetParameterValue("pMoneda", IIf(cmbCodMon.Value = "", "-", cmbCodMon.Text))
            reporte.SetParameterValue("pFechaFin", cbFecFin.Text)
            reporte.SetParameterValue("pFechaInicio", cbFecIni.Text)

            forma.Text = "Reporte de Consulta de Compras y/o Gastos"
            forma.ShowDialog()

        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class