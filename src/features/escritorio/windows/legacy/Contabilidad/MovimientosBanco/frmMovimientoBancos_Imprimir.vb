Imports System.ServiceModel
Public Class frmMovimientoBancos_Imprimir

    '===========================Servicios====================================================
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdMovimiento As Integer
    Public Periodo As Integer
    Public Mes As Integer
    Public CodBan As String
    Public NumCta As String
    

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmMovimientoBancos_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMovimientoBancosService) = False Then
                oMovimientoBancosService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmMovimientoBancos_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If rbMovimientos.Checked Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataView
                Dim reporte As New rptMovimientoBanco               
                dtReporte = oMovimientoBancosService.Imprimir(IdMovimiento).Tables(0).DefaultView

                If dtReporte.Count = 0 Then
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
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Impresión de Movimiento Banco Nº " + IdMovimiento.ToString
                    forma.ShowDialog()
                End If

            ElseIf rbConciliacion.Checked Then

                Dim forma As New frmReportes
                Dim dtReporte As New DataView                
                Dim reporte As New rptConciliacion
                Dim reporte2 As New rptConciliacion_Vacio
                Dim dtDatos As New DataTable 'Verificamos si el Movimiento tiene documentos a conciliar
                Dim Fecha As Date
                Fecha = CDate("01/" + Mes.ToString + "/" + Periodo.ToString)
                Dim UltimoDiaMes As Date
                UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)

                dtReporte = oMovimientoBancosService.ImprimirConciliacion(CodBan, NumCta, Periodo, Mes).Tables(0).DefaultView

                If dtReporte.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else

                    dtDatos = oMovimientoBancosService.MostrarConciliacion(Periodo, Mes, CodBan, NumCta).Tables(0)
                    If dtDatos.Rows.Count > 0 Then
                        reporte.SetDataSource(dtReporte)
                        reporte.SetParameterValue("pFecha", UltimoDiaMes)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                    Else
                        reporte2.SetDataSource(dtReporte)
                        reporte2.SetParameterValue("pFecha", UltimoDiaMes)
                        forma.crvReportes.ReportSource = reporte2
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                    End If
                   
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Conciliación de Movimiento Banco Nº " + IdMovimiento.ToString
                    forma.ShowDialog()
                End If


                End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
       
    End Sub

    Private Sub frmMovimientoBancos_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oMovimientoBancosService.Close()
        Catch ex As TimeoutException
            oMovimientoBancosService.Abort()
        Catch ex As CommunicationException
            oMovimientoBancosService.Abort()
        End Try
    End Sub
End Class