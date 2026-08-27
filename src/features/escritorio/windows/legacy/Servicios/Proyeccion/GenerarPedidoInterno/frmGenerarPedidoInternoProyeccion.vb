Imports System.ServiceModel
Imports System.Net
Public Class frmGenerarPedidoInternoMantenimiento

    ' Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    ' Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oJobService As New JobService.JobServiceClient
    Private dtUbicacion As DataTable


    Public IdOrden As Integer
    Private dtSupervisores As DataTable
    Public estado_process As Integer
    Private dtADR As DataTable

    Private Sub frm_Ser_Cotizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oHorasMotorService) = False Then
                oHorasMotorService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmOrdenCompra_GenerarPedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 290)
        '/*************************************************************************************/

        llenarCombos()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cmbIdPer.KeyPress _
                      , txtNumJob.KeyPress _
                      , txtInterprete.KeyPress _
                      , txtDestino.KeyPress _
                      , txtTecnico.KeyPress _
                      , cmbADR.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Ninguno)"
        Return fila
    End Function
    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Return fila
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= SUPERVISOR ================================================
            dtSupervisores = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisores.Rows.InsertAt(getRowTodos(dtSupervisores), 0)
            cmbIdPer.DataSource = dtSupervisores
            cmbIdPer.DropDownList.DataMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.DisplayMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.ValueMember = dtSupervisores.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(0).DataMember = dtSupervisores.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(1).DataMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.SelectedIndex = 0
            dtSupervisores = Nothing

            ''======================================= ADR ================================================
            'dtADR = oPedidoImportService.ConsultarNumerosADR().Tables(0)
            'dtADR.Rows.InsertAt(getRowTodos1(dtADR), 0)
            'cmbADR.DataSource = dtADR
            'cmbADR.DropDownList.DataMember = dtADR.Columns("NumeroADR").ToString
            'cmbADR.DropDownList.DisplayMember = dtADR.Columns("NumeroADR").ToString
            'cmbADR.DropDownList.ValueMember = dtADR.Columns("NumeroADR").ToString
            'cmbADR.DropDownList.Columns(0).DataMember = dtADR.Columns("NumeroADR").ToString
            'cmbADR.SelectedIndex = 0
            'dtADR = Nothing

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                Button1_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toNumber(cmbIdPer.Value) = 0 Then
                MsgBox("Debe Ingresar el supervisor del Pedido", MsgBoxStyle.Information, "Información")
                cmbIdPer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Estás seguro de Generar el Pedido Interno de Importación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim nomantenimiento As String
                    If cbnow3.Checked Then
                        nomantenimiento = "103"
                    Else
                        nomantenimiento = ""
                    End If

                    'IIf(cmbADR.SelectedIndex = 0, Nothing, cmbADR.Value)
                    estado_process = oHorasMotorService.GenerarPedidoRepuestosImportar(Session.sCodEmp, cbFecInicio.Text, cbFecFinal.Text, cmbUbicacion.Value, nomantenimiento, cmbIdPer.Value, txtInterprete.Text, txtTecnico.Text, txtDestino.Text, Nothing, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se Generó el Pedido Interno Nº " + estado_process.ToString)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR EL PEDIDO INTERNO: " + ex.Message, MsgBoxStyle.Exclamation)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub
End Class