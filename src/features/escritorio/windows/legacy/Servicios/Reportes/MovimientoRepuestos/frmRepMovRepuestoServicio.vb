Imports System.ServiceModel

Public Class frmRepMovRepuestoServicio

    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim dtReporte As DataTable
    Dim Tipo2 As String

    Private Sub frmRepMovRepuestoServicio1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            oSeguridadService.RegistrarVisitaOpciones(124, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbMovRepuestos.Checked Then
                If ValidaDatos() Then
                    Dim forma As New frmReportes
                    Dim reporte As New rptMovimientoRepuestos
                    Dim Tipo As String = ""

                    If rbEgresos.Checked = True Then
                        Tipo = "D"
                    ElseIf rbIngresos.Checked = True Then
                        Tipo = "H"
                    ElseIf rbTodos.Checked = True Then
                        Tipo = ""
                    End If

                    dtReporte = oJobService.ReporteMovimientoRepuestos(txtFechaInicio.Value, txtFechaFin.Value, txtNumJob.Text.Trim, Tipo).Tables(0)
                    'DataGridView1.DataSource = dtReporte
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
                        'forma.crvReportes.DisplayGroupTree = False
                        'forma.crvReportes.RefreshReport = False

                        If rbCostos.Checked = True Then
                            Tipo2 = "Costos"
                        ElseIf rbPrecios.Checked = True Then
                            Tipo2 = "Precios"
                        End If
                        reporte.SetParameterValue("pFechaIni", txtFechaInicio.Value)
                        reporte.SetParameterValue("pFechaFin", txtFechaFin.Value)
                        reporte.SetParameterValue("Tipo", Tipo2)

                        forma.Text = "Reporte Movimiento de Repuestos"
                        forma.ShowDialog()

                    End If
                End If
            ElseIf rbRepNoDevueltos.Checked Then
                If txtNumJob.Text <> "" Then
                    Dim forma As New frmReportes
                    Dim reporte As New rptRepuestosNoDevueltos

                    dtReporte = oJobService.ReporteConsumoRepuestos(txtNumJob.Text).Tables(0)

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
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte Consumo de Repuestos"
                        forma.ShowDialog()
                    End If
                Else
                    MsgBox("Debe ingresar la OT")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaDatos() As Boolean
        Try
            If utils.toBlank(txtNumJob.Text) = "" Then '-----------------------------------borrar
                MsgBox("Debe ingresar la OT") '------------------------borrar
                txtNumJob.Focus() '--------------------------------------------------------borrar
                Return False '-------------------------------------------------------------borrar
            ElseIf rbCostos.Checked = False And rbPrecios.Checked = False Then
                MsgBox("Debe Escojer el Tipo de Dato")
                rbCostos.Focus()
                Return False
            ElseIf Year(txtFechaInicio.Value) <> Year(txtFechaFin.Value) Then
                MsgBox("Las Fechas deben pertenecer al mismo Año")
                txtFechaInicio.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtFechaInicio.Focus()
                End If
            Else
                'MsgBox("Debe ingresar el Job")
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtFechaInicio.Focus()
                End If
            Else
                'MsgBox("Debe ingresar el Job")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
    End Sub

    Private Sub frmRepMovRepuestoServicio1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepMovRepuestoServicio1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 124)
        '/*************************************************************************************/

        txtFechaInicio.Value = "01/" & Today.Month & "/" & Today.Year
        txtFechaFin.Value = Today
        rbMovRepuestos.Checked = True
        txtNumJob.Select()
    End Sub

    Private Sub rbMovRepuestos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMovRepuestos.CheckedChanged
        If rbMovRepuestos.Checked Then
            Activar()
        ElseIf rbRepNoDevueltos.Checked Then
            Desactivar()
        End If
    End Sub

    Private Sub rbRepNoDevueltos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbRepNoDevueltos.CheckedChanged
        If rbMovRepuestos.Checked Then
            Activar()
        ElseIf rbRepNoDevueltos.Checked Then
            Desactivar()
        End If
    End Sub

    Private Sub Desactivar()
        txtFechaInicio.IsNullDate = True
        txtFechaInicio.ReadOnly = True
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Control

        txtFechaFin.IsNullDate = True
        txtFechaFin.ReadOnly = True
        txtFechaFin.BackColor = System.Drawing.SystemColors.Control

        rbTodos.Checked = False
        rbTodos.Enabled = False

        rbEgresos.Checked = False
        rbEgresos.Enabled = False

        rbIngresos.Checked = False
        rbIngresos.Enabled = False

        rbCostos.Checked = False
        rbCostos.Enabled = False

        rbPrecios.Checked = False
        rbPrecios.Enabled = False
    End Sub

    Private Sub Activar()
        txtFechaInicio.IsNullDate = False
        txtFechaInicio.Value = "01/" & Today.Month & "/" & Today.Year
        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window

        txtFechaFin.IsNullDate = False
        txtFechaFin.Value = Today
        txtFechaFin.ReadOnly = False
        txtFechaFin.BackColor = System.Drawing.SystemColors.Window

        rbTodos.Checked = True
        rbTodos.Enabled = True

        rbEgresos.Checked = False
        rbEgresos.Enabled = True

        rbIngresos.Checked = False
        rbIngresos.Enabled = True

        rbCostos.Checked = True
        rbCostos.Enabled = True

        rbPrecios.Checked = False
        rbPrecios.Enabled = True
    End Sub

    Private Sub txtFechaInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaInicio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFechaFin.Focus()
        End If
    End Sub

    Private Sub txtFechaFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            rbTodos.Focus()
        End If
    End Sub
End Class