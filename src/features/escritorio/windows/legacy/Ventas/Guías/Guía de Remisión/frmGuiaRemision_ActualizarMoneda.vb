Imports System.ServiceModel

Public Class frmGuiaRemision_ActualizarMoneda

    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public NumDoc As String
    Public CodMon As String
    Public IdDoc As Int64
    Public state_button As Integer
    '----state_button------
    '1 = Guias de Remision
    '2 = Factura
    '3 = Boleta de Venta
    '4 = Cotizaciones 
    '5 = Orden de Compra
    '6 = Cotizacion Servicios 

    Private dtDatos As DataTable
    Private dtMonedas As DataTable

    

    Private Sub frmGuiaRemision_ActualizarMoneda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oGuiaRemisionService.Close()
            oMaestroService.Close()
            oFacturaService.Close()
            oBoletaService.Close()
            oCotizacionService.Close()
            oOrdenCompraService.Close()
            oCotizacionServicioService.Close()

        Catch ex As TimeoutException
            oGuiaRemisionService.Abort()
            oMaestroService.Abort()
            oFacturaService.Abort()
            oBoletaService.Abort()
            oCotizacionService.Abort()
            oOrdenCompraService.Abort()
            oCotizacionServicioService.Abort()

        Catch ex As CommunicationException
            oGuiaRemisionService.Abort()
            oMaestroService.Abort()
            oFacturaService.Abort()
            oBoletaService.Abort()
            oCotizacionService.Abort()
            oOrdenCompraService.Abort()
            oCotizacionServicioService.Abort()

        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmGuiaRemision_ActualizarMoneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_ActualizarMoneda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If state_button = 1 Then
            Me.Text = "Actualizar guia de remision : " + NumDoc
        ElseIf state_button = 2 Then
            Me.Text = "Actualizar factura : " + NumDoc
        ElseIf state_button = 3 Then
            Me.Text = "Actualizar boleta : " + NumDoc
        ElseIf state_button = 4 Then
            Me.Text = "Actualizar cotización : " + NumDoc
        ElseIf state_button = 5 Then
            Me.Text = "Actualizar orden compra : " + NumDoc
        ElseIf state_button = 6 Then
            Me.Text = "Actualizar cotización : " + NumDoc
        End If

        llenarCombos()
        cmbCodMon.Value = CodMon

    End Sub

    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("Error al llenar los combos : " + ex.Message)
        End Try
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            If MsgBox("¿Está seguro de ACTUALIZAR la moneda de la documentoº: " + NumDoc + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim estado_process As Boolean = False

                If state_button = 1 Then
                    estado_process = oGuiaRemisionService.ActualizarMoneda(IdDoc, cmbCodMon.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf state_button = 2 Then
                    estado_process = oFacturaService.ActualizarMoneda(IdDoc, cmbCodMon.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf state_button = 3 Then
                    estado_process = oBoletaService.ActualizarMoneda(IdDoc, cmbCodMon.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf state_button = 4 Then
                    estado_process = oCotizacionService.ActualizarMoneda(IdDoc, cmbCodMon.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf state_button = 5 Then
                    estado_process = oOrdenCompraService.ActualizarMoneda(IdDoc, cmbCodMon.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf state_button = 6 Then
                    estado_process = oCotizacionServicioService.ActualizarMoneda(IdDoc, cmbCodMon.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                End If

                If estado_process Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, Comunicarse con el Administrador del Sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar la moneda : " + ex.Message)
        End Try
      
    End Sub
End Class