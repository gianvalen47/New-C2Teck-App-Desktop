Public Class frmRepCreditos
    Private oDocumentosCtasCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient

    Private Sub frmRepCreditos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isClosed(oDocumentosCtasCtesService) = False Then
            oDocumentosCtasCtesService.Close()
        End If
    End Sub

    Private Sub frmRepCreditos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbFecInicio.KeyPress _
   , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepCreditos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub MostrarReporte041()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepGerCreditos
            Dim dtReporte As New DataTable

            dtReporte = oDocumentosCtasCtesService.ReporteGerencial(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 1).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False


                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                forma.Text = "Reporte Gerencial de Créditos y Cobranzas"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporte042()
        Try
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpRepGerCreditos2
                Dim dtReporte As New DataTable
                Dim total As Double

                dtReporte = oDocumentosCtasCtesService.ReporteGerencial(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, 2).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    For Each Fila As DataRow In dtReporte.Rows

                        Dim contador As Double
                        contador = Fila.Item("TotCob")
                        total = total + contador
                    Next

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                    reporte.SetParameterValue("TotalCobranza", total)
                    'forma.crvReportes.RefreshReport = False

                    forma.Text = "Reporte Gerencial de Créditos y Cobranzas"
                    forma.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar041_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar041.Click
        MostrarReporte041()

    End Sub

    Private Sub btnAceptar042_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar042.Click
        MostrarReporte042()

    End Sub
End Class