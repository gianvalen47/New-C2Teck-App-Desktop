Imports System.ServiceModel

Public Class frmComCotizacionSolicitud_AgregarDetalle

    Private oCotizacionSolicitudDetService As New CotizacionSolicitudDetService.CotizacionSolicitudDetServiceClient

    Public IdCotizacionDet As Integer
    Private IdSolictudDet As Integer
    Private IdCotizacion As Integer
    Public CodMer As String
    Private Aceptado As Boolean

    Private Sub frmComCotizacionSolicitud_AgregarDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oCotizacionSolicitudDetService.Close()

        Catch ex As TimeoutException
            oCotizacionSolicitudDetService.Abort()

        Catch ex As CommunicationException
            oCotizacionSolicitudDetService.Abort()

        End Try
        GC.SuppressFinalize(Me)
    End Sub


    Private Sub frmComCotizacionSolicitud_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComCotizacionSolicitud_AgregarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
           txtPreMer.KeyPress _
            , txtDscto.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmComCotizacionSolicitud_AgregarDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ObtenerRegistro()
            Me.Text = "Modificar los precios del Código : " & CodMer
        Catch ex As Exception
            MsgBox("Error al cargar el load : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionSolicitudDetService.CotizacionSolicitudDet

            registro = oCotizacionSolicitudDetService.Obtener(IdCotizacionDet)

            IdSolictudDet = registro.SolicitudCompraDet.IdSolicitudDet
            IdCotizacion = registro.CotizacionSolicitud.IdCotizacion
            txtCodMer.Text = registro.SolicitudCompraDet.CodMer
            txtDesMer.Text = registro.SolicitudCompraDet.DesMer
            txtCanMer.Value = registro.CanMer
            If Not (registro.FecEntrega.ToString = "") Then
                txtFecEntrega.Value = CDate(registro.FecEntrega)
                txtFecEntrega.Text = registro.FecEntrega.ToString
            End If
            txtPreMer.Value = registro.PreMer
            txtDscto.Value = registro.DscMer
            txtObservacion.Text = registro.Observacion
            Aceptado = registro.Aceptado

        Catch ex As Exception
            MsgBox("Error al obtener registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCotizacionDet) = 0 Then
                MsgBox("Debe ingresar el codigo a modificar", MsgBoxStyle.Information)
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(IdCotizacionDet) = 0 Then
                MsgBox("Debe ingresar el codigo a modificar", MsgBoxStyle.Information)
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(IdSolictudDet) = 0 Then
                MsgBox("Debe ingresar el codigo a modificar", MsgBoxStyle.Information)
                Return False
            ElseIf toDouble(txtPreMer.Value) <= 0 Then
                MsgBox("El precio debe ser mayor a cero.", MsgBoxStyle.Information)
                txtPreMer.Focus()
                Return False
            ElseIf toDouble(txtDscto.Value) < 0 Then
                MsgBox("El descuento no debe ser menor a cero.", MsgBoxStyle.Information)
                txtDscto.Focus()
                Return False
            ElseIf Aceptado = True Then
                MsgBox("Ya no se puede modificar el precio porque ya a sido asignado a una solicitud", MsgBoxStyle.Information)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar los campos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Sub Modificar(ByVal registro As CotizacionSolicitudDetService.CotizacionSolicitudDet)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionSolicitudDetService.Actualizar(registro)
            If estado_process Then
                MsgBox("Se actualizó el registro correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("Error al modificar el detalle : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                Dim registro As New CotizacionSolicitudDetService.CotizacionSolicitudDet
                Dim solicitudcompradet As New CotizacionSolicitudDetService.SolicitudCompraDet
                Dim cotizacionsolicitud As New CotizacionSolicitudDetService.CotizacionSolicitud

                registro.IdCotizacionDet = IdCotizacionDet
                solicitudcompradet.IdSolicitudDet = IdSolictudDet
                registro.SolicitudCompraDet = solicitudcompradet
                cotizacionsolicitud.IdCotizacion = IdCotizacion
                registro.CotizacionSolicitud = cotizacionsolicitud
                registro.CanMer = toDouble(txtCanMer.Value)
                registro.FecEntrega = IIf(txtFecEntrega.Text = "", Nothing, txtFecEntrega.Value)
                registro.PreMer = toDouble(txtPreMer.Value)
                registro.DscMer = toDouble(txtDscto.Value)
                registro.Observacion = toBlank(txtObservacion.Text)
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                Modificar(registro)

            End If

        Catch ex As Exception
            MsgBox("Error al guardar el detalle : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class