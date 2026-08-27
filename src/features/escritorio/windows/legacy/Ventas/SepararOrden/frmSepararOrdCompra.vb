Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSepararOrdCompra

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOrdenDet As Integer
    Public IdOrden As Integer
    Public AprOrden As Boolean

    Private Sub frmSepararOrdCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oOrdenCompraService.Close()
            oOrdenCompraDetService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
        End Try
    End Sub

    Private Sub frmSepararOrdCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmSepararOrdCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            Dim estado As String = oOrdenCompraService.Estado(IdOrden)
            If toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresar el código de la orden. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecIniSep.Text) = "" Then
                MsgBox("Debe ingresar la fecha de inicio.", MsgBoxStyle.Information, "Información")
                txtFecIniSep.BackColor = Color.Red
                txtFecIniSep.Focus()
                Return False
            ElseIf toBlank(txtFecFinSep.Text) = "" Then
                MsgBox("Debe ingresar la fecha final", MsgBoxStyle.Information, "Información")
                txtFecFinSep.BackColor = Color.Red
                txtFecFinSep.Focus()
                Return False
            ElseIf txtFecIniSep.Value > txtFecFinSep.Value Then
                MsgBox("Fecha INICIAL no puede ser mayor que la fecha FINAL", MsgBoxStyle.Information, "Información")
                txtFecIniSep.Focus()
                Return False
                'ElseIf Session.CodPerfil <> "02" And Session.CodPerfil <> "14" Then
                '    MsgBox("Su perfil no es de SUPERVISOR y no puede aprobar esta orden.", MsgBoxStyle.Information, "Información")
                '    Return False
            ElseIf (estado = "GENERADO" Or estado = "ENVIADO") And AprOrden = True Then
                MsgBox("No puede Separar ningún repuesto, debido a que la orden no esta APROBADA.", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Aprobar()
        Try
            Dim estado_process As Boolean

            estado_process = oOrdenCompraDetService.Separar(IdOrden, 0, 0 _
                                                            , txtFecIniSep.Text, txtFecFinSep.Text _
                                                            , toBlank(txtObservacion.Text) _
                                                            , Session.sCodUsu)
            type_process = "update"

            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de SEPARAR la Orden de Compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
              And ValidaCampos() Then
            Aprobar()
        End If
    End Sub
End Class