Imports System.ServiceModel

Public Class frmCalendario_Imprimir

    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Public IdProcesoImp As Integer
    Public Fecha As Date
    Public CodRubro As String
    Public DesRubro As String
    Public Locacion As String
    Public dtCalendarioActual As DataTable

    Private Sub frmCalendario_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresAlmacenService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmCalendario_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCalendario_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbEnBlanco.Checked = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If rbActual.Checked = True Then
            ImprimirCalendarioActual()
        ElseIf rbEnBlanco.Checked = True Then
            ImprimirCalendarioBlanco()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ImprimirCalendarioBlanco()

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptCalendario1
            Dim dtDatosAntes As DataTable

            dtDatosAntes = oIndicadoresAlmacenService.ImprimirCalendario(IdProcesoImp, Fecha, CodRubro).Tables(0)

            If dtDatosAntes.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!")
            Else
                reporte.SetDataSource(dtDatosAntes)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False

                forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("Rubro", DesRubro)
                'reporte.SetParameterValue("Locacion", )
                reporte.SetParameterValue("Fecha", Fecha)
                reporte.SetParameterValue("pLocacion", Locacion)
                reporte.SetParameterValue("pCodUsu", Session.sCodUsu)
                forma.Text = "Reporte de Calendario"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ImprimirCalendarioActual()

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptCalendario2

            If dtCalendarioActual.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!")
            Else
                reporte.SetDataSource(dtCalendarioActual)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("Rubro", DesRubro)
                'reporte.SetParameterValue("Locacion", cmbOficinas.Text & " - " & cmbIdLocacion.Text)
                reporte.SetParameterValue("Fecha", Fecha)
                reporte.SetParameterValue("pLocacion", Locacion)
                reporte.SetParameterValue("pCodUsu", Session.sCodUsu)
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Calendario"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class