Imports System.ServiceModel
Public Class frmRepCondensados

    Private oCierreMesService As New CierreMesService.CierreMesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub frmRepCondensados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCierreMesService.Close()
            oSeguridadService.Close()

        Catch ex As TimeoutException
            oCierreMesService.Abort()
            oSeguridadService.Abort()

        Catch ex As CommunicationException
            oCierreMesService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepCondensados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCondensados_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              rbSaldoFinal.KeyPress _
              , txtFecInicio.KeyPress _
              , txtFecFinal.KeyPress _
            , rbSaldoPorCuentas.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepCondensados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 67)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        txtFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        txtFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        txtFecInicio.Select()
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            If rbSaldoFinal.Checked Then
                If rbDetallado.Checked = True Then
                    Dim reporte As New rpCondensadoSaldoFinal
                    dtReporte = oCierreMesService.MostrarSaldoFinal(Session.sCodEmp, txtFecInicio.Text, txtFecFinal.Text).Tables(0)
                    If dtReporte.Rows.Count < 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("FecInicio", txtFecInicio.Text)
                        reporte.SetParameterValue("FecFinal", txtFecFinal.Text)
                        forma.Text = "Reporte de Condensados de Saldo Final"
                        forma.ShowDialog()

                    End If
                ElseIf rbResumen.Checked = True Then

                    Dim reporte As New rpCondensadoSaldoFinalDetallado
                    dtReporte = oCierreMesService.MostrarSaldoFinal(Session.sCodEmp, txtFecInicio.Text, txtFecFinal.Text).Tables(0)
                    If dtReporte.Rows.Count < 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("FecInicio", txtFecInicio.Text)
                        reporte.SetParameterValue("FecFinal", txtFecFinal.Text)
                        forma.Text = "Reporte de Condensados de Saldo Final"
                        forma.ShowDialog()

                    End If
                End If

            ElseIf rbSaldoPorCuentas.Checked Then
                Dim reporte As New rpSaldoFinalPorCuenta
                dtReporte = oCierreMesService.MostrarSaldoFinalPorCuentas(Session.sCodEmp, txtFecInicio.Text, txtFecFinal.Text).Tables(0)
                If dtReporte.Rows.Count < 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("FecInicio", txtFecInicio.Text)
                    reporte.SetParameterValue("FecFinal", txtFecFinal.Text)
                    forma.Text = "Reporte de Condensados de Saldo Final por Cuentas"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(67, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub


    Private Sub rbSaldoFinal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSaldoFinal.CheckedChanged, rbSaldoPorCuentas.CheckedChanged
        If rbSaldoFinal.Checked Then
            rbDetallado.Enabled = True
            rbResumen.Enabled = True
        ElseIf rbSaldoPorCuentas.Checked Then
            rbDetallado.Enabled = False
            rbResumen.Enabled = False
        End If
    End Sub
End Class