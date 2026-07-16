Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSepOrdenCompra_MostrarDetalle

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update      insert      delete
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridad As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Public lseparar As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOrdenDet As Integer
    Public IdOrden As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Private CanPen As Integer
    Public IdSugerido As Integer

    Private Sub frmSepOrdenCompra_MostrarDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oOrdenCompraService.Close()
            oOrdenCompraDetService.Close()
            oPrecioService.Close()
            oLocacionMercaderiaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
            oPrecioService.Abort()
            oLocacionMercaderiaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
            oPrecioService.Abort()
            oLocacionMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmSepOrdenCompra_MostrarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSepOrdenCompra_MostrarDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar
            ObtenerRegistro()
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtDesMer.Select()
            Desactivar()
        End If

    End Sub

    Private Sub Desactivar()
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        txtDscMer.ReadOnly = True
        txtDscMer.BackColor = System.Drawing.SystemColors.Control
        txtCanMer.ReadOnly = True
        txtCanMer.BackColor = System.Drawing.SystemColors.Control
        txtItem.ReadOnly = True
        txtItem.BackColor = System.Drawing.SystemColors.Control
        txtPreMer.ReadOnly = True
        txtPreMer.BackColor = System.Drawing.SystemColors.Control
        txtCodMerCli.ReadOnly = True
        txtCodMerCli.BackColor = System.Drawing.SystemColors.Control

        cbSugerir.Enabled = False
        txtPrecioSug.ReadOnly = True
        txtPrecioSug.BackColor = System.Drawing.SystemColors.Control
        txtDsctoSug.ReadOnly = True
        txtDsctoSug.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenCompraDetService.OrdenCompraDet
            registro = oOrdenCompraDetService.MostrarPorId(toNumber(IdOrdenDet))

            IdOrdenDet = registro.IdOrdenDet
            IdOrden = registro.OrdenCompra.IdOrden
            txtItem.Value = registro.Item
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtCodMerCli.Text = registro.CodMerCli
            txtCanMer.Value = registro.CanMer
            txtPreMer.Text = toDouble(registro.PreMer)
            txtDscMer.Text = toDouble(registro.DscMer)
            txtTotal.Text = toDouble(registro.TotFila)
            txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
            CanPen = registro.CanPen
            estado = oOrdenCompraService.Estado(IdOrden)

            'If IdSugerido > 0 Then
            '    cbSugerir.Checked = True
            '    cbSugerir.Enabled = False
            '    Dim Sugerido As OrdenCompraDetService.SugeridoOrdenDetalle
            '    Sugerido = oOrdenCompraDetService.MostrarPorIdSugerido(IdSugerido, IdOrdenDet)
            '    txtPrecioSug.Value = Sugerido.PreMerSug
            '    txtDsctoSug.Value = Sugerido.DsctoSug
            'Else
            '    cbSugerir.Checked = False
            'End If

            'If Session.CodPerfil = "02" Or (Session.CodPerfil = "14" And lseparar = True) Then

            '    txtCanSep.Value = registro.CanSep
            '    If registro.FecIniSep Is Nothing Then
            '        txtFecIniSep.IsNullDate = True
            '    Else
            '        txtFecIniSep.Text = registro.FecIniSep
            '    End If
            '    If registro.FecFinSep Is Nothing Then
            '        txtFecFinSep.IsNullDate = True
            '    Else
            '        txtFecFinSep.Text = registro.FecFinSep
            '    End If
            '    txtObservacion.Text = toBlank(registro.Observacion)
            'End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class