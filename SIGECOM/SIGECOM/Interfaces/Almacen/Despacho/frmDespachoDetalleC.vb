Imports System.ServiceModel
Public Class frmDespachoDetalleC

    '===========================Servicios====================================
    Private oDespachoDetService As New DespachoDetService.DespachoDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete

    Public IdDespachoCab As Integer
    Public IdDespachoDet As Integer
    Public iEstado As Integer

    Private IdCliente As Integer
    Private IdSerieDocumento As Integer

    Private IdGuia As Integer
    Private CodSerie As String
    Private NumDoc As String

    Private Sub frmDespachoDetalleC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDespachoDetService.Close()
        Catch ex As TimeoutException
            oDespachoDetService.Abort()
        Catch ex As CommunicationException
            oDespachoDetService.Abort()
        End Try
    End Sub

    Private Sub frmDespachoDetalleC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachoDetalleC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ObtenerRegistro()

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As DespachoDetService.DespachoDet
            registro = oDespachoDetService.Obtener(toNumber(IdDespachoDet))

            IdDespachoDet = registro.IdDespachoDet
            IdDespachoCab = registro.DespachoCab.IdDespachoCab

            IdSerieDocumento = registro.SerieDocumento.IdSerieDoc
            txtNumGuia.Text = registro.NumDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtDestino.Text = registro.Destino
            txtTransporte.Text = registro.AgenciaTransp
            txtCanBultos.Text = registro.CanBultos
            txtObservacion.Text = registro.Observacion

            txtEstado.Text = registro.EstadosDespachoDet.DesEstado
            Dim estado As String = ""
            estado = registro.EstadosDespachoDet.IdEstado
            txtEstadoObs.Text = registro.ObservacionEstado

            If estado = "1" Then
                txtEstado.BackColor = Color.FromArgb(210, 242, 190)
            ElseIf estado = "2" Then
                txtEstado.BackColor = Color.FromArgb(239, 157, 144)
            End If
            ' 239, 157, 144     red

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub






End Class