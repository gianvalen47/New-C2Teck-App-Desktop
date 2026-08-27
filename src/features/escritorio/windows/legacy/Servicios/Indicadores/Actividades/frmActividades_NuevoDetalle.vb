Imports System.ServiceModel

Public Class frmActividades_NuevoDetalle

    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete

    Public IdActividad As Integer
    Public IdActividadDet As Integer

    Private Sub frmActividades_NuevoDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmActividades_NuevoDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActividades_NuevoDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        activar()
        If state_button Then                'Modificar
            Me.Text = "Modificar Actividad"
            ObtenerRegistro()
        Else
            Me.Text = "Ingresar Nueva Actividad"
            txtDesActividad.Text = ""
        End If
        txtDesActividad.Focus()
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As IndicadoresServicioService.ActividadServicioDet
            registro = oIndicadoresServicioService.ObtenerActividadDet(IdActividadDet)

            txtDesActividad.Text = registro.DesActividad

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub activar()

        txtDesActividad.ReadOnly = False
        txtDesActividad.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        'If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
        If ValidaCampos() Then
            Dim registro As New IndicadoresServicioService.ActividadServicioDet
            Dim ActividadServicio As New IndicadoresServicioService.ActividadServicio

            ActividadServicio.IdActividad = IdActividad
            registro.ActividadServicio = ActividadServicio
            registro.IdActividadDet = IdActividadDet
            registro.DesActividad = txtDesActividad.Text

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesActividad.Text) = "" Then
                MsgBox("Debe ingresar la Actividad", MsgBoxStyle.Information, "Información")
                txtDesActividad.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.ActividadServicioDet)
        Try
            Dim estado_process As Integer
            estado_process = oIndicadoresServicioService.InsertarActividadDet(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdActividadDet = estado_process
                'Dim frm As New frmActividades_Nuevo
                'frm.CodJob = txtNumJob.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                txtDesActividad.Text = ""
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As IndicadoresServicioService.ActividadServicioDet)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarActividadDet(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class