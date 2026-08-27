Imports System.ServiceModel
Public Class frmAsignacionHorario_Imprimir
    '=========================== Servicios ===================================================
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public CodHor As String
    Public CodArea As String
    Public CodCentro As String
    Public IdPersona As Integer

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmHorario_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oAsignacionHorarioService) = False Then
                oAsignacionHorarioService.Close()
            End If
            If isClosed(oAsignacionHorarioService) = False Then
                oAsignacionHorarioService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmHorario_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbVigentes.Checked = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView

            Dim reporte As New rpListado_AsignacionHorario
            dtDatos = oAsignacionHorarioService.Filtrar(Session.sCodEmp, CodArea, CodCentro, CodHor, IdPersona).Tables(0)
            dtReporte = dtDatos.Copy.DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If rbTodos.Checked Then
                    dtReporte.RowFilter = ""
                Else
                    dtReporte.RowFilter = "Vigente = True"
                End If

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.Text = "Listado de Asignación de Horarios de Personal"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub frmHorario_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionHorarioService.Close()
        Catch ex As TimeoutException
            oAsignacionHorarioService.Abort()
        Catch ex As CommunicationException
            oAsignacionHorarioService.Abort()
        End Try
    End Sub
End Class