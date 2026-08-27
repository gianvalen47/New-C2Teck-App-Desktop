Imports Janus.Data
Imports Janus.Windows.GridEX

Public Class frmAprobarServicios

    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    'Private codigoCot As String

    Private Sub frmAprobarServicios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oPersonaService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            'If dtAreas.Rows.Count > 1 Then
            '    dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            'End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAprobarServicios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows
                If CInt(row.Cells("IdCotizacionSer").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
            'For Each row As DataGridViewRow In dgvDatos.Rows
            '    If CStr(row.Cells("cCod_Cotizacion").Value) = codigo Then
            '        row.Selected = True
            '        Exit For
            '    End If
            'Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmAprobarServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 40)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        listaDatos()
        '---------Formnato de condicion para grilla --------------------------------------
        Dim fc As GridEXFormatCondition

        fc = New GridEXFormatCondition(dgvDatos.RootTable.Columns("Sugerido"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)
        fc.FormatStyle.BackColor = Color.Red
        fc.FormatStyle.ForeColor = Color.Black
        dgvDatos.RootTable.FormatConditions.Add(fc)
        '---------------------------------------------------------------------------------
        dgvDatos.Select()
        position()

        ' dgvDatos_Click(sender, e)
    End Sub
   
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 0 Then
            biAprobar.Enabled = False
            biMostrar.Enabled = False
        Else
            biAprobar.Enabled = True
            biMostrar.Enabled = True
        End If
    End Sub

    Private Sub position()
        If dgvDatos.RowCount > 0 Then
            dgvDatos.Col = 1
            dgvDatos.Row = 0
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If dgvDatos.RowCount > 0 Then
            biMostrar_Click(sender, e)
        Else
            MsgBox("No existen datos que mostrar...")
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                e.Handled = True
                biMostrar_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionServicioService.MostrarParaCreditosCentroCosto(Session.sCodEmp, cmbCentroCosto.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
            If dtDatos.Rows.Count > 0 Then
                System.Media.SystemSounds.Asterisk.Play()
            End If

            enableOpciones()
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub
    Private Function ValidaCodigo() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function
    'Private Sub ObtenerRegistro()
    '    cmbCodPag.Value = "00"
    '    txtObservacion.Clear()
    '    rcAdelanto.Checked = False
    '    rbMonto.Checked = False
    '    rbPorcentaje.Checked = False
    '    cmbPorcentaje.Text = ""
    '    txtMonto.Clear()
    'End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmAprobarServicios_Detalle
                frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Text
                frm.Fecha = dgvDatos.CurrentRow.Cells("Fecha").Text
                frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Text
                frm.Cliente = dgvDatos.CurrentRow.Cells("DesCli").Text
                frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
                frm.Text = "Detalles de la Cotización "
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            Else
                MsgBox("No existen datos que mostrar...")
            End If
        Catch ex As Exception
            MsgBox("ERROR [MOSTRAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try

            Dim frm As New frmAprobarServicios_Aprobar
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Text
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Text
            frm.Fecha = dgvDatos.CurrentRow.Cells("Fecha").Text
            frm.Text = "Aprobar/Rechazar Cotización Nº " & dgvDatos.CurrentRow.Cells("NumCotizacion").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Try
        '    Dim codigo As String = ""
        '    If dgvDatos.RowCount > 0 Then
        '        codigo = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Text
        '    End If
        '    dtDatos = Nothing
        '    listaDatos()
        '    If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
        '        RowPossesion(dgvDatos, codigo)
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub
    'Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
    '    codigoCot = dgvDatos.CurrentRow.Cells("NumCotizacion").Text
    'End Sub

    Private Sub biImprimir_Click(sender As System.Object, e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptAprobarServicios

            dtReporte = dgvDatos.DataSource
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("DesEmp", Session.sDesEmp)
                reporte.SetParameterValue("RucEmp", Session.sRucEmp)                

                forma.Text = "Reporte de Cotizaciones de Servicios por Aprobar"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            'If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
            'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            'End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCentroCosto_ValueChanged(sender As Object, e As EventArgs) Handles cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub
End Class