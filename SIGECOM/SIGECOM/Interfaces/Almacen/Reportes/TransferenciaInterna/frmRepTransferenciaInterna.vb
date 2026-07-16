Imports System.ServiceModel
Public Class frmRepTransferenciaInterna

    '===========================Servicios====================================================
    Private oJobService As New JobService.JobServiceClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================    
    Private dtReporte As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtEstados As DataTable
    Public IdCliente As Integer

    Private Sub frmRepDocumentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 269)
        '/*************************************************************************************/

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombos()
        IdCliente = 0
        txtCliente.Text = "(Todos)"

        rbExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub

    Private Sub frmRepDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
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

        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oTransferenciaService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
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
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub frmRepCtasxPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oTransferenciaService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oTransferenciaService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oTransferenciaService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    btnAceptar.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked = True Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtCliente.Text = frm.descripcion
                txtCliente.BackColor = System.Drawing.SystemColors.Control
                IdCliente = frm.codigo                
            End If
            txtCliente.Select()
            chkCliente.Checked = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(269, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepTransferenciaInterna
            Dim dtReporte As New DataView

            dtReporte = oTransferenciaService.ReporteTransferenciaInterna(cbFecInicio.Value, cbFecFinal.Value, IdCliente, txtNumJob.Text, toNumber(cmbIdLocacion.Value), IIf(cmbEstado.SelectedIndex = 0, "", cmbEstado.Value)).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
            Else

                If rbExcel.Checked Then

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Documentos de Almacen"

                    reporte.SetParameterValue("pFecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("pFecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("pOficina", IIf(toBlank(cmbOficinas.Value) = "", "(Todos)", cmbOficinas.Text))
                    reporte.SetParameterValue("pAlmacen", IIf(toBlank(cmbIdLocacion.Value) = "", "(Todos)", cmbIdLocacion.Text))
                    reporte.SetParameterValue("pNumJob", IIf(txtNumJob.Text = "", "(Todos)", txtNumJob.Text))
                    reporte.SetParameterValue("pCliente", IIf(IdCliente = 0, "(Todos)", txtCliente.Text))
                    reporte.SetParameterValue("pEstado", IIf(cmbEstado.SelectedIndex = 0, "(Todos)", cmbEstado.Text))
                    forma.ShowDialog()
                End If
            
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                 cbFecInicio.KeyPress _
                               , cbFecFinal.KeyPress _
                               , txtCliente.KeyPress _
                               , cmbEstado.KeyPress _
                               , txtNumJob.KeyPress _
                               , cmbOficinas.KeyPress _
                               , cmbIdLocacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class