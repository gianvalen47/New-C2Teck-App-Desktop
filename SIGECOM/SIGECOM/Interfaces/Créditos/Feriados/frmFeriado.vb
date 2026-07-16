Imports System.ServiceModel

Public Class frmFeriado

    Private oDocumentosCtasService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient

    Public state_button As Boolean
    Public FecFer As DateTime
    Public DesFer As String

    Private Sub frmFeriado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDocumentosCtasService.Close()
        Catch ex As TimeoutException
            oDocumentosCtasService.Abort()
        Catch ex As CommunicationException
            oDocumentosCtasService.Abort()
        End Try
    End Sub

    Private Sub frmFeriado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFeriado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state_button Then
            txtfecha.Value = FecFer
            txtDescripcion.Text = DesFer
        Else
            txtfecha.Value = Today.Date
            txtDescripcion.Text = ""
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está Seguro de GUARDAR los Cambios Realizados? ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                If state_button = True Then
                    Modificar()
                Else
                    Insertar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar()
        Try
            Dim FechaInsert As DateTime

            FechaInsert = oDocumentosCtasService.InsertarFeriado(txtfecha.value, txtDescripcion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If FechaInsert <> Nothing Then
                MsgBox("Se insertó el Feriado Correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                FecFer = FechaInsert
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar()
        Try
            Dim Actualizar As Boolean

            Actualizar = oDocumentosCtasService.ActualizarFeriado(txtfecha.Value, txtDescripcion.Text, Session.sCodUsu, Session.sDirIp, Session.sNomPc)

            If Actualizar = True Then
                MsgBox("Se modificó el Feriado Correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
End Class