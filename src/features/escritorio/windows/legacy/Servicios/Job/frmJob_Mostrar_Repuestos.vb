Imports System.ServiceModel

Public Class frmJob_Mostrar_Repuestos

    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public CodRubro As String
    Public CodMon As String

    Private Sub frmJob_Mostrar_Repuestos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oSeguridadService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oSeguridadService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oSeguridadService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Mostrar_Repuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Mostrar_Repuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        lblNumJob.Text = CodJob
        lblRubro.Text = "Repuestos"

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.ConsultarGastos(CodJob, CodRubro, Session.sCodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
            SumaColumna()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Private Sub SumaColumna()
        Try
            Dim total As Double = 0
            Dim totalprecio As Double = 0
            Dim totalSol As Double = 0
            Dim totalcotizado As Double = 0

            If dgvDatos.RowCount <> 0 Then

                For i As Integer = 0 To dgvDatos.RowCount - 1

                    If Not (IsDBNull(dgvDatos.Item("Costo".ToLower, i).Value)) Then
                        total = total + CDbl(dgvDatos.Item("Costo".ToLower, i).Value)
                    End If

                    If Not (IsDBNull(dgvDatos.Item("Precio".ToLower, i).Value)) Then
                        totalprecio = totalprecio + CDbl(dgvDatos.Item("Precio".ToLower, i).Value)
                    End If

                    If Not (IsDBNull(dgvDatos.Item("PrecioCotizado".ToLower, i).Value)) Then
                        totalcotizado = totalcotizado + CDbl(dgvDatos.Item("PrecioCotizado".ToLower, i).Value)
                    End If

                Next

                MontoDol.Text = "Total Costos (" & CodMon & ")"
                PrecioDol.Text = "Total Precio Consumido (" & CodMon & ")"
                lblpreciocotizado.Text = "Total Precio Cotizado (" & CodMon & ")"
                txtMontoDol.Value = total
                txtPrecioDol.Value = totalprecio
                txtpreciocotizado.Value = totalcotizado
                txtMontoSol.Visible = False
                MontoSol.Visible = False

            End If

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        End Try
    End Sub

    Private Sub MontoDol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MontoDol.Click

    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click

        MostrarReporte()

    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJob_Mostrar_Repuestos

            dtReporte = oJobService.ConsultarGastos(CodJob, CodRubro, Session.sCodUsu).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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
                reporte.SetParameterValue("pDesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("pRucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("pCodMon", CodMon)
                reporte.SetParameterValue("pCodJob", CodJob)
                reporte.SetParameterValue("pRubro", "Repuestos")
                'reporte.SetParameterValue("pMotor", lblMotor.Text)
                'reporte.SetParameterValue("pCliente", lblCliente.Text)

                forma.Text = "Job - Mostrar Repuestos"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

End Class