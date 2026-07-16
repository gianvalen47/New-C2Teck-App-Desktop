Imports System.ServiceModel

Public Class frmRepInventariosinMovimiento

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient

    Private dtAlmacenes As DataTable
    Private dtoficinas As DataTable
    Private dtRubros As DataTable
    Private codApliIni As String
    Private codApliFin As String
    'Private dtReporteSinMovimiento As DataTable
    'Dim forma As New frmReportes
    'Dim reporteSinMovimiento As New rptInventariosinMovimiento

    Private Sub frmRepInventariosinMovimiento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oMaestro.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
        End Try
    End Sub

    Private Sub frmRepInventariosinMovimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepInventariosinMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombos()

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ===============================================
            dtoficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtoficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtoficinas = Nothing
            
            '======================================= RUBROS ================================================
            dtRubros = oMaestro.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim forma As New frmReportes
        Dim reporte As New rptInventariosinMovimiento
        Dim dtReporte As New DataView

        dtReporte = oLocacionMercaderiaService.ReporteGerencialInventarios(Session.sCodEmp, cmbCodRub.Value, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbIdLocacion.Value), 3).Tables(0).DefaultView

        If dtReporte.Count = 0 Then
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            If (txtApliIni.Text = "" Or txtApliFin.Text = "") And rbAplicación.Checked = True Then
                MsgBox("Debe ingresar el rango de Aplicación.", MsgBoxStyle.Information, "Rango de Aplicación")
            Else
                If rbExcel.Checked Then

                    If rbAplicación.Checked Then
                        dtReporte.RowFilter = "CodApl >='" + codApliIni + "' AND CodApl <= '" + codApliFin + "' "
                    End If

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbPantalla.Checked Then

                    If rbAplicación.Checked Then
                        dtReporte.RowFilter = "CodApl >='" + codApliIni + "' AND CodApl <= '" + codApliFin + "' "
                    End If
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFin", cbFecFinal.Value)
                    reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                    reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                    reporte.SetParameterValue("FiltroAplic", IIf(rbAplicación.Checked, "Desde :  '" + txtApliIni.Text + "'       Hasta : '" + txtApliFin.Text + "'", "(Todos)"))
                    reporte.SetParameterValue("Aplicacion", IIf(rbAplicación.Checked, "1", "0"))
                    reporte.SetParameterValue("Rubro", IIf(cmbCodRub.Text = "(Todos)", "Todos", cmbCodRub.Text))
                    forma.Text = "Reporte de Stock Sin Movimiento"
                    'DataGridView1.DataSource = dtReporteSinMovimiento
                    forma.ShowDialog()

                End If
            End If
        End If

    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarMerIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMerIni.Click
        Dim frm As New frmBuscarAplicacion
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            'rbAplicacion.Checked = False
            txtApliIni.Text = frm.descripcion
            txtApliIni.BackColor = System.Drawing.SystemColors.Control
            codApliIni = frm.codigo
        End If
    End Sub

    Private Sub btnBuscarMerFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMerFin.Click
        Dim frm As New frmBuscarAplicacion
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            'rbAplicacion.Checked = False
            txtApliFin.Text = frm.descripcion
            txtApliFin.BackColor = System.Drawing.SystemColors.Control
            codApliFin = frm.codigo
        End If
    End Sub

    Private Sub rbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked Then
            gbAplicacion.Enabled = False
            txtApliIni.Text = ""
            txtApliFin.Text = ""
        End If
    End Sub

    Private Sub rbAplicación_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAplicación.CheckedChanged
        If rbAplicación.Checked Then
            gbAplicacion.Enabled = True
        End If
    End Sub
End Class