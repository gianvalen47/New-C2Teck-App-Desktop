Imports System.ServiceModel

Public Class frmEncuestaSistema_Respuesta

    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private dtDatos As DataTable
    Public IdPregunta As Integer
    Public IdRespuesta As Integer

    Private Sub frmEncuestaSistema_Respuesta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
        End Try
    End Sub

    Private Sub frmEncuestaSistema_Respuesta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEncuestaSistema_Respuesta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state_button = True Then
            ObtenerRegistro()
        Else
            txtRespuesta.Focus()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EncuestaService.Respuesta
            registro = oEncuestaSistema.ObtenerRespuesta(IdRespuesta)

            IdRespuesta = registro.IdRespuesta
            IdPregunta = registro.Pregunta.IdPregunta
            txtRespuesta.Text = registro.Descripcion
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New EncuestaService.Respuesta
                Dim Pregunta As New EncuestaService.Pregunta

                registro.IdRespuesta = IdRespuesta
                Pregunta.IdPregunta = IdPregunta
                registro.Pregunta = Pregunta
                registro.Descripcion = txtRespuesta.Text
                registro.Activo = cbActivo.Checked

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As EncuestaService.Respuesta)
        Try
            Dim estado_process As Integer
            estado_process = oEncuestaSistema.InsertarRespuesta(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdRespuesta = estado_process
                MsgBox("Se inserto la respuesta correctamente")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA RESPUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Modificar(ByVal registro As EncuestaService.Respuesta)
        Try
            Dim estado_process As Boolean
            estado_process = oEncuestaSistema.ActualizarRespuesta(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la respuesta correctamente")
                'desactivar()
                ObtenerRegistro()
                'actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA RESPUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtRespuesta.Text) = "" Then
                MsgBox("Debe Ingresar la Respuesta", MsgBoxStyle.Information, "Información")
                txtRespuesta.BackColor = Color.Red
                txtRespuesta.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function



End Class