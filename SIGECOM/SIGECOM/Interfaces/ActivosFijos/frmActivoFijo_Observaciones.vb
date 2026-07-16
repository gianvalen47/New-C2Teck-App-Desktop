Public Class frmActivoFijo_Observaciones

    Public estado_proceso As Boolean
    Public CodActivo As String
    Public IdObservacion As Int64
    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient

    Private Sub frmActivoFijo_Observaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActivoFijo_Observaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If estado_proceso Then
            ObtenerRegistro()
            txtObservacion.Focus()
        Else
            txtObservacion.Focus()
        End If

    End Sub

    Private Sub ObtenerRegistro()

        Dim registro As New ActivoFijoService.ActivoFijoObservaciones

        registro = oActivoFijoService.ObtenerObservacion(IdObservacion)

        IdObservacion = registro.IdObservacion
        txtObservacion.Text = registro.Observacion
        CodActivo = registro.ActivoFijo.CodActivo

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            Dim estadoins As Int32
            Dim estadoact As Boolean

            Dim registro As New ActivoFijoService.ActivoFijoObservaciones
            Dim activo As New ActivoFijoService.ActivoFijo
            Dim empresa As New ActivoFijoService.Empresa
            Dim centrocosto As New ActivoFijoService.CentroCosto

            activo.CodActivo = CodActivo
            empresa.CodEmp = Session.sCodEmp
            activo.Empresa = empresa
            registro.ActivoFijo = activo
            registro.Fecha = Today
            registro.IdObservacion = IdObservacion
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            If estado_proceso = False Then
                estadoins = oActivoFijoService.InsertarObservacion(registro)
                If estadoins > 0 Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Else
                estadoact = oActivoFijoService.ActualizarObservacion(registro)
                If estadoact Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA OBSERVACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class