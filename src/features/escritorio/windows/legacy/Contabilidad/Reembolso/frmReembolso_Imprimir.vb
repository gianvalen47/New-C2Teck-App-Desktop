Imports System.ServiceModel
Public Class frmReembolso_Imprimir

    '===========================Servicios====================================================
    Dim oReembolsoCajaService As New ReembolsoCajaService.ReembolsoCajaServiceClient
    Dim oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public IdReembolso As Integer
    Public TotNeto As Double
    Public CodMon As String

    Public IdUbicacion As Integer
    Public DesUbicacion As String
    Public Anio As Integer
    Public Mes As Integer
    Public DesMes As String
    Public Estado As String
    Public DesEstado As String
    Public Numero As Integer

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oReembolsoCajaService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmReembolso_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmReembolso_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbPrincipal.Checked = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If rbPrincipal.Checked = True Then

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptReembolso_Detalle

                If IdReembolso <> 0 Then
                    dtReporte = oReembolsoCajaService.Imprimir(IdReembolso).Tables(0)
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay datos a mostrar")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        reporte.SetParameterValue("pNumeroLetra", oMaestroService.ConvierteNumLetra(TotNeto, CodMon))
                        forma.Text = "Reporte de Reembolso de Caja"
                        forma.ShowDialog()
                    End If
                Else
                    MsgBox("¡Número de Reembolso Invalido.!", MsgBoxStyle.Information, "No hay datos")
                End If

            ElseIf rbListado.Checked = True Then

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptReembolso_Listado

                dtReporte = oReembolsoCajaService.Filtrar(IdUbicacion, Anio, Mes, Estado, Numero).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Listado de Reembolsos"
                    reporte.SetParameterValue("pUbicacion", DesUbicacion)
                    reporte.SetParameterValue("pAnio", Anio)
                    reporte.SetParameterValue("pMes", DesMes)                    
                    reporte.SetParameterValue("pEstado", DesEstado)                    
                    reporte.SetParameterValue("pNumero", IIf(Numero = 0, "-", Numero))
                    forma.ShowDialog()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub
End Class