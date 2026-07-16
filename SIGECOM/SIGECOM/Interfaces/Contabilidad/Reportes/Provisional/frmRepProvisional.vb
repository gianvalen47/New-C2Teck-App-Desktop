Imports System.ServiceModel
Public Class frmRepProvisional

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Private dtDatos As DataTable

    Private Sub frmRepProvisional_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oProvisionalService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepProvisional_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepProvisional_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 177)
        '/*************************************************************************************/

        txtFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFecFinal.Value = Date.Today

        txtFecInicio.Focus()

    End Sub

    Private Function ValidarCampos() As Boolean
        If txtFecInicio.Value > txtFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            txtFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidarCampos() Then
            'oSeguridadService.RegistrarVisitaOpciones(177, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            MostrarReporte()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub MostrarReporte()
        Try
            'dtDatos = oRegistroCompraService.ReporteRegistroCompra(Session.sCodEmp, txtFecInicio.Value, txtFecFinal.Value, cmbMoneda.Value, "", 1).Tables(0)
            'DataGridView1.DataSource = dtDatos
            If rbResumenViatico.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptRepProvisional

                dtReporte = oProvisionalService.ReporteResumenAtencionViaticos(Session.sCodEmp, txtFecInicio.Value, txtFecFinal.Value).Tables(0)

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
                    forma.Text = "Reporte de Resumen de Provisionales por Viatico"
                    reporte.SetParameterValue("FecInicio", txtFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", txtFecFinal.Value)
                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtFecInicio.KeyPress _
                  , txtFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class