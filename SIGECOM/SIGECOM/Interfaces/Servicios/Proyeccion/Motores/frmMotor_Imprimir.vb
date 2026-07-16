Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmMotor_Imprimir

    '=========================== Servicios ====================================
    Private oMotorService As New MotorService.MotorServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Public pNomEquipo As String
    Public pNumSerie As String    
    Public pIdFabricante As Integer
    Public DesFabricante As String
    Public pModMer As String
    Public pCodUbicacion As String
    Public pDesUbicacion As String
    Public pModEquipo As String
    Public pIdTipo As Integer
    Public DesTipo As String

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMotorService) = False Then
                oMotorService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptListadoMotores

            dtReporte = oMotorService.Filtrar(Session.sCodEmp, pNomEquipo, pNumSerie, pIdFabricante, pModMer, pCodUbicacion, pModEquipo, pIdTipo, 0).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                If rbPantalla.Checked = True Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    reporte.SetParameterValue("pEquipo", IIf(pNomEquipo = "", "Todos", pNomEquipo))
                    reporte.SetParameterValue("pSerieMotor", IIf(pNumSerie = "", "Todos", pNumSerie))
                    reporte.SetParameterValue("pUbicacion", pDesUbicacion)
                    reporte.SetParameterValue("pModMotor", IIf(pModMer = "", "Todos", pModMer))
                    reporte.SetParameterValue("pFabricante", DesFabricante)
                    reporte.SetParameterValue("pModEquipo", IIf(pModEquipo = "", "Todos", pModEquipo))
                    reporte.SetParameterValue("pTipEquipo", DesTipo)
                    forma.Text = "Reporte de Listado de Motores"
                    forma.ShowDialog()

                ElseIf rbExcel.Checked = True Then
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                End If
            End If
         
        Catch ex As Exception
            MsgBox("ERROR AL IMPRIMIR LISTADO DE MOTORES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmMotor_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class