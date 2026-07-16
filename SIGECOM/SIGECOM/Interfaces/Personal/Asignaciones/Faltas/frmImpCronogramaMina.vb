Imports System.ServiceModel
Public Class frmImpCronogramaMina

    '===========================Servicios====================================================
    Private oFaltasService As New FaltasService.FaltasServiceClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private dtDatos As DataTable


    Private Sub frmImpCronogramaMina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmImpCronogramaMina_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = True
        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Today

        ListaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oFaltasService.ConsultarProcesoCronogramaMina(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value).Tables(0)
            dgvDatos.DataSource = dtDatos            

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged
        listaDatos()
    End Sub

    Private Function ValidaCampos() As Boolean
        If toBlank(cbFecInicio.Value) = "" Or toBlank(cbFecFinal.Value) = "" Then
            MsgBox("Debe de Ingresar las fechas.", MsgBoxStyle.Information, "Información")
            cbFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            If ValidaCampos() Then
                Dim estado_process As Boolean
                If MsgBox("¿Está seguro de PROCESAR el(los) Cronograma(s) de Mina?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    estado_process = oFaltasService.ProcesarCronogramaMinas(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Procesó el(los) Cronograma(s) de Mina correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL PROCESAR CRONOGRAMAS DE MINA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oFaltasService.Close()
        Catch ex As TimeoutException
            oFaltasService.Abort()
        Catch ex As CommunicationException
            oFaltasService.Abort()
        End Try
    End Sub

    Private Sub frmImpCronogramaMina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class