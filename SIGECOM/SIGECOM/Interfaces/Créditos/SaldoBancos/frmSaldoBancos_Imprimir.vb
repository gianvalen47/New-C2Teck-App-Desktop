Imports System.ServiceModel

Public Class frmSaldoBancos_Imprimir

    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public CodBan As String
    Public CodCuenta As String
    Public dtMostrarFinal As DataTable
    Dim dtReporte As New DataTable

    Private Sub frmSaldoBancos_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPlanillaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPlanillaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmSaldoBancos_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSaldoBancos_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbFecInicio.Select()
        cbFecFinal.Value = Date.Today
        cbFecInicio.Value = CDate(DateAdd("d", -1, cbFecFinal.Text))
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      cbFecInicio.KeyPress _
                      , cbFecFinal.KeyPress
        ' , btnAceptar.KeyPress _
        ', btnCancelar.KeyPress
        ', txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub OcultarColumnas()
        For i As Integer = 0 To Me.dgvFinal.Rows.Count - 1

            If dgvFinal.Rows(i).Cells("Cargo").Value = "0.00" Then
                dgvFinal.Rows(i).Cells("Cargo1").Value = ""
            Else
                dgvFinal.Rows(i).Cells("Cargo1").Value = dgvFinal.Rows(i).Cells("Cargo").Value
            End If

            If dgvFinal.Rows(i).Cells("Abono").Value = "0.00" Then
                dgvFinal.Rows(i).Cells("Abono1").Value = ""
            Else
                dgvFinal.Rows(i).Cells("Abono1").Value = dgvFinal.Rows(i).Cells("Abono").Value
            End If
        Next

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptSaldoBanco

            dtReporte = oPlanillaService.ImprimirTransaccionBanco(Session.sCodEmp, CodBan, CodCuenta, cbFecInicio.Value, cbFecFinal.Value).Tables(0)
            dgvFinal.DataSource = dtReporte
            EliminarColumnas()

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar, Verifique!")
            Else
                If rbExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(dgvFinal)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.Text = "Reporte de Saldos de Banco"
                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub EliminarColumnas()

        With dgvFinal
            .AutoGenerateColumns = True
            .DataSource = dtReporte
            .Columns.Remove("DesEmp")
            .Columns.Remove("RucEmp")
            .Columns.Remove("CodMon")
            .Columns.Remove("DesMon")
            .Columns.Remove("AbrMon")
            .Columns.Remove("CodBan")
            .Columns.Remove("DesBan")
            .Columns.Remove("NumCta")
            .Columns.Remove("FecVal")
        End With


        'dgvFinal.Columns.RemoveAt(0)
        'dgvFinal.Columns.RemoveAt(1)
        'dgvFinal.Columns.RemoveAt(2)
        'dgvFinal.Columns.RemoveAt(4)
        ''dgvFinal.Columns.RemoveAt(14)


        'Dim dtModificar As DataTable

        'For i As Integer = 0 To Me.dgvFinal.Rows.Count - 1



        'Next

    End Sub

End Class