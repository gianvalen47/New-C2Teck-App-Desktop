Imports System.ServiceModel
Public Class frmRepDocumentos

    '===========================Servicios====================================================
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient

    '======================Declaración de Variables==============================================
    Public IdCliente As Integer
    Private dtReporte As DataTable
    Private dtLocaciones As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtMonedas As DataTable
    Private dtTipoDocumentos As DataTable

    Private Sub frmRepDocumentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load   
        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        IdCliente = 0
        txtCliente.Text = "(Todos)"
        llenarCombos()
        cmbCodMon.Value = "NS"
    End Sub

    Private Sub frmRepDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCtasxPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionClienteService.Close()
            oMaestroService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oLocacionClienteService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oLocacionClienteService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked = True Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbIdLocCli.DataSource = dtLocaciones
            cmbIdLocCli.Value = 0
            cmbIdLocCli.Text = "(Todos)"
            dtLocaciones = Nothing
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtCliente.Text = frm.descripcion
                txtCliente.BackColor = System.Drawing.SystemColors.Control
                IdCliente = frm.codigo
                listarLocacionesCliente()
            End If
            txtCliente.Select()
            chkCliente.Checked = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
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

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString            
            dtMonedas = Nothing

            '======================================= LOCACIONES DEL CLIENTE ================================================
            dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbIdLocCli.DataSource = dtLocaciones
            cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.SelectedIndex = 0
            dtLocaciones = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
        
    Private Sub listarLocacionesCliente()
        Try
            '======================================= LOCACIONES DEL CLIENTE ================================================
            dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbIdLocCli.DataSource = dtLocaciones
            cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.SelectedIndex = 0
            dtLocaciones = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR LOCACIONES CLIENTE : " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
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
                    MsgBox("Número de Job no existente, Verifique")
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

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepDocumentos
            Dim dtReporte As New DataView

            dtReporte = oMoviAlmacenService.ReporteMoviAlmacen(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, toNumber(cmbIdLocacion.Value), toNumber(cmbIdSerieDoc.Value), cmbCodMon.Value, IdCliente, toNumber(cmbIdLocCli.Value), txtNumJob.Text).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Documentos de Almacen"
              
                reporte.SetParameterValue("pFecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("pFecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("pDesOficina", IIf(toBlank(cmbOficinas.Value) = "", "(Todos)", cmbOficinas.Text))
                reporte.SetParameterValue("pDesAlmacen", IIf(toBlank(cmbIdLocacion.Value) = "", "(Todos)", cmbIdLocacion.Text))
                reporte.SetParameterValue("pTipoDoc", IIf(cmbIdSerieDoc.SelectedIndex = 0, "(Todos)", cmbIdSerieDoc.Text))
                reporte.SetParameterValue("pMoneda", toBlank(cmbCodMon.Text))
                reporte.SetParameterValue("pNumJob", IIf(txtNumJob.Text = "", "(Todos)", txtNumJob.Text))
                reporte.SetParameterValue("pLocacion", IIf(cmbIdLocCli.SelectedIndex = 0, "(Todos)", cmbIdLocCli.Text))                    
                reporte.SetParameterValue("pDesCli", IIf(IdCliente = 0, "(Todos)", txtCliente.Text))
                forma.ShowDialog()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        '======================================= SERIE DE DOCUMENTO ================================================
        dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(cmbIdLocacion.Value, 2, "").Tables(0)
        dtTipoDocumentos.Rows.InsertAt(getRowTodos(dtTipoDocumentos), 0)
        cmbIdSerieDoc.DataSource = dtTipoDocumentos
        cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.SelectedIndex = 0
        dtTipoDocumentos = Nothing

    End Sub
End Class