Imports System.ServiceModel
Public Class frmComSolicitudGasto_CentroCosto

    '============================Servicios===================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    '======================Declaración de Variables==============================
    Public IdGastoDet As Integer
    Public CodCentro As String

    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable

    Private Sub frmComSolicitudGasto_CentroCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'llenarCombos()
        Desactivar()
        ObtenerRegistro()
        txtUnidad.Focus()
    End Sub

    Private Sub frmComSolicitudGastoDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then         
            Finalizar()
            Me.Close() 
        End If
    End Sub

    Private Sub frmComSolicitudGasto_CentroCosto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoDetService.Close()
            oCentroCostoService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oCentroCostoService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oCentroCostoService.Abort()
        End Try
    End Sub

    'Private Sub llenarCombos()
    '    Try

    '        '========================================== AREAS ===============================================
    '        dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
    '        cmbCodArea.DataSource = dtAreas
    '        cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
    '        cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
    '        cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
    '        cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
    '        cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
    '        dtAreas = Nothing

    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub


    'Private Sub cmbCodArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try

    '        '====================================== CENTRO COSTO ===========================================
    '        dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, "").Tables(0)
    '        cmbCentroCosto.DataSource = dtCentroCosto
    '        cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
    '        cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.SelectedIndex = 0

    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub Desactivar()
        Try

            txtUnidad.ReadOnly = True
            txtUnidad.BackColor = System.Drawing.SystemColors.Control
            txtArea.ReadOnly = True
            txtArea.BackColor = System.Drawing.SystemColors.Control
            txtCentroCosto.ReadOnly = True
            txtCentroCosto.BackColor = System.Drawing.SystemColors.Control
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtMontoSinIgv.ReadOnly = True
            txtMontoSinIgv.BackColor = System.Drawing.SystemColors.Control
            txtMontoNoAfecto.ReadOnly = True
            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoDetService.SolicitudGastoDetCentroCosto
            registro = oSolicitudGastoDetService.ObtenerCentroCosto(IdGastoDet, CodCentro)

            IdGastoDet = registro.SolicitudGastoDet.IdGastoDet
            CodCentro = registro.CentroCosto.CodCentro
            txtUnidad.Text = registro.CentroCosto.Area.UnidadNegocio.DesUnidad
            txtArea.Text = registro.CentroCosto.Area.DesArea
            txtCentroCosto.Text = registro.CentroCosto.DesCentro
            txtMonto.Value = registro.Monto
            txtMontoSinIgv.Value = registro.MontoSinIgv
            txtMontoNoAfecto.Value = registro.MontoNoAfecto
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class