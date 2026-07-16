Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSepOrdenCompra_Separar

    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient

    Public type_process As String               'update     insert      delete
    Public lseparar As Boolean
    Public IdOrdenDet As Integer
    'Public IdOrden As Integer
    'Public IdLocacion As Integer
    'Public IdCliente As Integer
    'Public CodMon As String
    Public estado As String
    Private CanPen As Integer

    Private Sub frmSepOrdenCompra_Separar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenCompraDetService.Close()
        Catch ex As TimeoutException
            oOrdenCompraDetService.Abort()
        Catch ex As CommunicationException
            oOrdenCompraDetService.Abort()
        End Try
    End Sub

    Private Sub frmSepOrdenCompra_Separar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSepOrdenCompra_Separar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObtenerRegistro()

        If estado = "GENERADO" Or estado = "GN" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If

        If CanPen > 0 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If

    End Sub

    Private Sub desactivar()
        If (estado = "PARCIAL" Or estado = "PA") And CanPen <> 0 Then
            txtCanSep.ReadOnly = False
            txtCanSep.BackColor = System.Drawing.SystemColors.Window
            txtFecIniSep.ReadOnly = False
            txtFecIniSep.BackColor = System.Drawing.SystemColors.Window
            txtFecFinSep.ReadOnly = False
            txtFecFinSep.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Else
            txtCanSep.ReadOnly = True
            txtCanSep.BackColor = System.Drawing.SystemColors.Control
            txtFecIniSep.ReadOnly = True
            txtFecIniSep.BackColor = System.Drawing.SystemColors.Control
            txtFecFinSep.ReadOnly = True
            txtFecFinSep.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenCompraDetService.OrdenCompraDet
            registro = oOrdenCompraDetService.MostrarPorId(toNumber(IdOrdenDet))

            CanPen = registro.CanPen

            If lseparar = True Then

                txtCanSep.Value = registro.CanSep
                If registro.FecIniSep Is Nothing Then
                    txtFecIniSep.IsNullDate = True
                Else
                    txtFecIniSep.Text = registro.FecIniSep
                End If
                If registro.FecFinSep Is Nothing Then
                    txtFecFinSep.IsNullDate = True
                Else
                    txtFecFinSep.Text = registro.FecFinSep
                End If
                txtObservacion.Text = toBlank(registro.Observacion)
            End If

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If lseparar = True Then
            If ValidaAprobacion() Then
                Separar()
            End If
        End If
    End Sub

    Private Sub Separar()
        Try
            Dim estado_process As Boolean

            estado_process = oOrdenCompraDetService.Separar(0, IdOrdenDet, txtCanSep.Value _
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

    Private Sub txtCanSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanSep.Click
        Try
            If txtCanSep.ReadOnly = False Then
                If txtCanSep.Value > 0 Then
                    txtCanSep.BackColor = Color.White
                Else
                    txtCanSep.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ValidaAprobacion() As Boolean
        Try
            Dim frm As New frmOrdenCompra

            If toBlank(txtFecIniSep.Text) = "" Then
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
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class