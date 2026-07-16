Public Class frmAsientos_Imprimir

    '===========================Servicios====================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables=============================
    Public IdTesoreria As Integer
    Public CodMon As String

    Private Sub rbPrincipal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbPrincipal.CheckedChanged, rbCheque.CheckedChanged, rbMasivo.CheckedChanged, rbRetencion.CheckedChanged
        If rbPrincipal.Checked Then
            gbCheque.Enabled = False
            gbMasivo.Enabled = False
            LimpiarCampos()
        ElseIf rbRetencion.Checked Then
            gbCheque.Enabled = False
            gbMasivo.Enabled = False
            LimpiarCampos()
        ElseIf rbCheque.Checked Then
            gbCheque.Enabled = True
            gbMasivo.Enabled = False
            LimpiarCampos()
        ElseIf rbMasivo.Checked Then
            gbCheque.Enabled = False
            gbMasivo.Enabled = True
            txtPeriodo.Value = Today.Year
            txtMesRegistro.Text = Format(Month(Today), "00")
            txtNumRegistroDesde.Text = "000001"
            txtNumRegistroHasta.Text = "000001"
        End If
    End Sub

    Private Sub LimpiarCampos()
        txtMesRegistro.Text = "00"
        txtNumRegistroDesde.Text = "000000"
        txtNumRegistroHasta.Text = "000000"
    End Sub

    Private Sub frmAsientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oTesoreriaService) = False Then
                oTesoreriaService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        '-------------------------------------------------- Impresión de todo el Asiento ---------------------------------------------
        If rbPrincipal.Checked = True Then
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptAsiento

            If IdTesoreria <> 0 Then
                dtReporte = oTesoreriaService.Imprimir(IdTesoreria).Tables(0)

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
                    'forma.crvReportes.DisplayGroupTree = False     
                    forma.Text = "Reporte de Asiento"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Número de Asiento Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If


            '------------------------------------------------- Impresión de Retencion ------------------------------------------------
        ElseIf rbRetencion.Checked = True Then
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
                Dim reporte As New rptRetencion
                Dim reporte1 As New rptRetencion1
            Dim Monto As Double = 0.0
            If IdTesoreria <> 0 Then
                dtReporte = oTesoreriaService.ImprimirRetencion(IdTesoreria).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    For Each Fila As DataRow In dtReporte.Rows
                        Monto = Monto + (CDbl(Fila.Item("MontoSol")))
                    Next

                    reporte.SetDataSource(dtReporte)
                    reporte.SetParameterValue("NumeroLetra", Trim(oTesoreriaService.ConvierteNumLetraConta(Monto)))
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If

                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Retención"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Número de Asiento Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If



            '------------------------------------------------- Impresión de Cheque ------------------------------------------------
        ElseIf rbCheque.Checked = True Then
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte1 As New rptCheque_Nuevo_Scotiabank        '       rptCheque_Wise      rptCheque_Prueba
            Dim reporte2 As New rptCheque_Nuevo_CreditoUS
            Dim reporte3 As New rptCheque_Nuevo_Nacion
            Dim reporte4 As New rptCheque_Nuevo_CreditoNS
            Dim reporte5 As New rptCheque_Nuevo_Continental
            'Dim reporte1 As New rptCheque_Wise
            'Dim reporte2 As New rptCheque_CreditoUS
            'Dim reporte4 As New rptCheque_CreditoNS
            'Dim reporte3 As New rptCheque_Nacion
            Dim Monto As Double

            If IdTesoreria <> 0 Then
                dtReporte = oTesoreriaService.ImprimirCheque(IdTesoreria).Tables(0)
                dgvDatos.DataSource = dtReporte

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else

                    '-------- Escogiendo el monto según la moneda del Asiento --------
                    If CodMon = "NS" Then
                        Monto = toDouble(dgvDatos.Rows(0).Cells("MontoSol").Value)
                    ElseIf CodMon = "US" Then
                        Monto = toDouble(dgvDatos.Rows(0).Cells("MontoDol").Value)
                    End If
                    '-------------------------------------------------------------------------------------------

                    If rbWise.Checked = True Then
                        reporte1.SetDataSource(dtReporte)
                        reporte1.SetParameterValue("Monto", Monto)
                        reporte1.SetParameterValue("NumeroLetra", Trim(oTesoreriaService.ConvierteNumLetraConta(Monto)))
                        forma.crvReportes.ReportSource = reporte1
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If

                    ElseIf rbCredito.Checked = True Then
                        If CodMon = "US" Then
                            reporte2.SetDataSource(dtReporte)
                            reporte2.SetParameterValue("Monto", Monto)
                            reporte2.SetParameterValue("NumeroLetra", Trim(oTesoreriaService.ConvierteNumLetraConta(Monto)))
                            forma.crvReportes.ReportSource = reporte2
                            ' Validar Usuario - Exportar Excel
                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                        ElseIf CodMon = "NS" Then
                            reporte4.SetDataSource(dtReporte)
                            reporte4.SetParameterValue("Monto", Monto)
                            reporte4.SetParameterValue("NumeroLetra", Trim(oTesoreriaService.ConvierteNumLetraConta(Monto)))
                            forma.crvReportes.ReportSource = reporte4
                            ' Validar Usuario - Exportar Excel
                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                        End If


                    ElseIf rbNacion.Checked = True Then
                        reporte3.SetDataSource(dtReporte)
                        reporte3.SetParameterValue("Monto", Monto)
                        reporte3.SetParameterValue("NumeroLetra", Trim(oTesoreriaService.ConvierteNumLetraConta(Monto)))
                        forma.crvReportes.ReportSource = reporte3
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                    ElseIf rbContinental.Checked = True Then
                        reporte5.SetDataSource(dtReporte)
                        reporte5.SetParameterValue("Monto", Monto)
                        reporte5.SetParameterValue("NumeroLetra", Trim(oTesoreriaService.ConvierteNumLetraConta(Monto)))
                        forma.crvReportes.ReportSource = reporte5
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If

                    End If

                    'forma.crvReportes.DisplayGroupTree = False
                    'reporte.SetParameterValue("pIdMesa", 0)
                    forma.Text = "Impresión de Cheque"
                    forma.ShowDialog()
                End If

            Else
                MsgBox("Número de Asiento Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
            '----------------------------------------------- Impresión MASIVO -------------------------------------
        ElseIf rbMasivo.Checked = True Then
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptAsientoMasivo

            If ValidaCampos() Then
                dtReporte = oTesoreriaService.ImprimirMasivo(txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistroDesde.Text, txtNumRegistroHasta.Text).Tables(0)

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
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Asiento Masivo"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Número de Asiento Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If

        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtPeriodo.Value) = 0 Then
                MsgBox("Debe Ingresar el Periodo.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toNumber(txtMesRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el Mes.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toNumber(txtNumRegistroDesde.Text) = 0 Then
                MsgBox("Debe Ingresar el Número de Registro.", MsgBoxStyle.Information, "Información")
                txtNumRegistroDesde.Focus()
                Return False
            ElseIf toNumber(txtNumRegistroHasta.Text) = 0 Then
                MsgBox("Debe Ingresar el Número de Registro.", MsgBoxStyle.Information, "Información")
                txtNumRegistroHasta.Focus()
                Return False
            ElseIf toNumber(txtNumRegistroHasta.Text) < toNumber(txtNumRegistroDesde.Text) Then
                MsgBox("El Número de Registro Hasta debe ser mayor que el Número de Registro Desde.", MsgBoxStyle.Information, "Información")
                txtNumRegistroHasta.Focus()
                Return False
            ElseIf toNumber(txtNumRegistroDesde.Text) > toNumber(txtNumRegistroHasta.Text) Then
                MsgBox("El Número de Registro Desde debe ser menor que el Número de Registro Hasta.", MsgBoxStyle.Information, "Información")
                txtNumRegistroDesde.Focus()
                Return False            
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtMesRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Validated
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtMesRegistro.Text)
            If cant < 2 Then
                txtMesRegistro.Text = "0" & txtMesRegistro.Text
            End If
            If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
            Else
                txtNumRegistroDesde.Focus()
                txtNumRegistroDesde.SelectAll()
            End If
        Else
            MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtNumRegistroDesde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistroDesde.Click        
        txtNumRegistroDesde.Focus()
        txtNumRegistroDesde.SelectAll()
    End Sub

    Private Sub txtNumRegistroHasta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistroHasta.Click
        txtNumRegistroHasta.Focus()
        txtNumRegistroHasta.SelectAll()
    End Sub

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtMesRegistro.Text)
                If cant < 2 Then
                    txtMesRegistro.Text = "0" & txtMesRegistro.Text
                End If
                If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                    MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                Else
                    txtNumRegistroDesde.Focus()
                    txtNumRegistroDesde.SelectAll()
                End If
            Else
                MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumRegistroDesde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistroDesde.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumRegistroDesde.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistroDesde.Text)
                Do While cant < 6
                    txtNumRegistroDesde.Text = "0" & txtNumRegistroDesde.Text
                    cant = cant + 1
                Loop
                txtNumRegistroHasta.Focus()
                txtNumRegistroHasta.SelectAll()
            Else
                'MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
                'txtNumRegistroDesde.Focus()                
            End If
        End If
    End Sub

    Private Sub txtNumRegistroHasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistroHasta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumRegistroHasta.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistroHasta.Text)
                Do While cant < 6
                    txtNumRegistroHasta.Text = "0" & txtNumRegistroHasta.Text
                    cant = cant + 1
                Loop
                btnAceptar.Focus()
            Else                
            End If
        End If
    End Sub

    'Private Sub ObtenerNumRegistro()
    '    Try
    '        txtNumRegistroHasta.Text = oTesoreriaService.ObtenerRegistro(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text)
    '        txtNumRegistroHasta.Focus()
    '        txtNumRegistroHasta.SelectAll()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER Nº  DE REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub frmAsientos_Imprimir_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IdTesoreria = 0 Then
            rbMasivo.Enabled = True
            rbMasivo.Checked = True
            rbPrincipal.Enabled = False
            rbPrincipal.Checked = False
            rbRetencion.Enabled = False
            rbRetencion.Checked = False
            rbCheque.Enabled = False
            rbCheque.Checked = False
            gbCheque.Enabled = False
            gbMasivo.Enabled = True
        Else
            If oTesoreriaService.BuscarCheque(IdTesoreria) = True Then
                rbPrincipal.Enabled = True
                rbPrincipal.Checked = False
                rbRetencion.Enabled = True
                rbRetencion.Checked = False
                rbCheque.Enabled = True
                rbCheque.Checked = True
                gbCheque.Enabled = True
                rbMasivo.Enabled = True
                rbMasivo.Checked = False
                gbMasivo.Enabled = False
            Else
                rbMasivo.Enabled = True
                rbMasivo.Checked = False
                rbPrincipal.Enabled = True
                rbPrincipal.Checked = True
                rbRetencion.Enabled = True
                rbRetencion.Checked = False
                rbCheque.Enabled = False
                rbCheque.Checked = False
                gbCheque.Enabled = False
                gbMasivo.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtNumRegistroDesde_Validated(sender As Object, e As System.EventArgs) Handles txtNumRegistroDesde.Validated       
            If Len(Trim(txtNumRegistroDesde.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistroDesde.Text)
                Do While cant < 6
                    txtNumRegistroDesde.Text = "0" & txtNumRegistroDesde.Text
                    cant = cant + 1
                Loop
                txtNumRegistroHasta.Focus()
                txtNumRegistroHasta.SelectAll()
            Else
                'MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
                'txtNumRegistroDesde.Focus()                
            End If
    End Sub

    Private Sub txtNumRegistroHasta_Validated(sender As Object, e As System.EventArgs) Handles txtNumRegistroHasta.Validated
        If Len(Trim(txtNumRegistroHasta.Text)) > 0 Then
            Dim cant As Integer = Len(txtNumRegistroHasta.Text)
            Do While cant < 6
                txtNumRegistroHasta.Text = "0" & txtNumRegistroHasta.Text
                cant = cant + 1
            Loop
            btnAceptar.Focus()
        Else
        End If
    End Sub

    Private Sub btnBuscarDesde_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarDesde.Click
        Try
            Dim frm As New frmBuscarAsientos
            frm.txtMesRegistro.Text = txtMesRegistro.Text
            frm.txtPeriodo.Value = txtPeriodo.Value
            frm.txtPeriodo.Enabled = False
            frm.txtMesRegistro.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.IdTesoreria) <> Nothing Then
                    txtNumRegistroDesde.Text = frm.NumRegistro
                Else
                    txtNumRegistroDesde.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Registro de Tesorería : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarHasta_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarHasta.Click
        Try
            Dim frm As New frmBuscarAsientos
            frm.txtMesRegistro.Text = txtMesRegistro.Text
            frm.txtPeriodo.Value = txtPeriodo.Value
            frm.txtPeriodo.Enabled = False
            frm.txtMesRegistro.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.IdTesoreria) <> Nothing Then
                    txtNumRegistroHasta.Text = frm.NumRegistro
                Else
                    txtNumRegistroHasta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Registro de Tesorería : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class