Public Class frmRepCostoMotores
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Dim dtOficina As DataTable
    Dim dtAlmacen As DataTable

    Private Sub frmRepCostoMotores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oDocumentoCostoService) = False Then
                oDocumentoCostoService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
          
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtSerieMot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerieMot.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderiaOrigen.Enabled = True Then
                btnBuscarMercaderiaOrigen_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmRepCostoMotores_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbAlmacen.KeyPress _
        , cbOficina.KeyPress _
        , cbFecFinal.KeyPress _
        , cbFecInicio.KeyPress _
        , txtSerieMot.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRepCostoMotores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmRepCostoMotores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        llenarCombos()
        cbOficina.Focus()

    End Sub
    Private Sub llenarCombos()
        Try
            '/////////OFICINA ORIGEN////////////////
            dtOficina = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub
    Private Function ValidaCampos() As Boolean
        Try
           
            If toBlank(txtSerieMot.Text) = "" And rbKardex.Checked Then
                MsgBox("Debe Ingresar el código del Motor", MsgBoxStyle.Information, "Información")
                txtSerieMot.BackColor = Color.Red
                txtSerieMot.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView

            If rbKardex.Checked Then
                Dim reporte As New rpKardexMotor
                dtReporte = oLocacionMercaderiaService.ReporteKardexMotor(cbAlmacen.Value, txtSerieMot.Text, cbFecInicio.Text, cbFecFinal.Text).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                    forma.Text = "Reporte de Motores"
                    forma.ShowDialog()
                End If

            ElseIf rbMotVend.Checked Then
                Dim reporte As New rpMotoresVendidos
                dtReporte = oDocumentoCostoService.ReporteMotoresVendidos(cbAlmacen.Value, cbFecInicio.Text, cbFecFinal.Text).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                    reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                    forma.Text = "Reporte de Motores Vendidos"
                    forma.ShowDialog()
                End If

            ElseIf rbCosAdi.Checked Then
                Dim reporte As New rpMotoresCostoAdicional
                dtReporte = oDocumentoCostoService.ReporteCostoAdicionalMotor(4, "01/08/2010", Today).Tables(0).DefaultView

                If rbTodos.Checked Then

                ElseIf rbVendidos.Checked Then
                    dtReporte.RowFilter = "Vendido = 1"
                ElseIf rbStock.Checked Then
                    dtReporte.RowFilter = "Vendido = 0"
                End If

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                    reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                    forma.Text = "Reporte de Costo de Motores"
                    forma.ShowDialog()
                End If

            ElseIf rbAccesVen.Checked Then
                Dim reporte As New rpMotoresVendidos
                dtReporte = oDocumentoCostoService.ReporteAccesorioMotorVendido(cbAlmacen.Value, cbFecInicio.Text, cbFecFinal.Text).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                    reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                    forma.Text = "Reporte de Accesorios de Motores"
                    forma.ShowDialog()
                End If

            ElseIf rbKardexMotVen.Checked Then
                Dim reporte As New rpKardexMotoresVendidos
                dtReporte = oLocacionMercaderiaService.ReporteKardexMotorVendido(cbAlmacen.Value, cbFecInicio.Text, cbFecFinal.Text).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                    reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                    forma.Text = "Reporte de Kardex de Motores Vendidos"
                    forma.ShowDialog()
                End If
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidaCampos Then
            MostrarReporte()
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = oMaestroService.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
            If cbOficina.Value = "01" Then
                cbAlmacen.Value = 4
            ElseIf cbOficina.Value = "02" Then
                cbAlmacen.Value = 17
            ElseIf cbOficina.Value = "03" Then
                cbAlmacen.Value = 24
            ElseIf cbOficina.Value = "04" Then
                cbAlmacen.Value = 28
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Almacenes")
        End Try
    End Sub

    Private Sub rbArmado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbKardex.CheckedChanged, rbAccesVen.CheckedChanged, rbCosAdi.CheckedChanged, rbKardexMotVen.CheckedChanged, rbMotVend.CheckedChanged
        If rbKardex.Checked Then
            lblSerieMot.Enabled = True
            txtSerieMot.Enabled = True
            txtSerieMot.Focus()
        Else
            lblSerieMot.Enabled = False
            txtSerieMot.Enabled = False
            txtSerieMot.Clear()
        End If

        If rbAccesVen.Checked Or rbKardexMotVen.Checked Or rbMotVend.Checked Then
            cbFecInicio.Focus()
        End If

        If rbCosAdi.Checked Then
            gbCosAdi.Enabled = True
            rbTodos.Checked = True
            rbTodos.Focus()
        Else
            gbCosAdi.Enabled = False
            rbTodos.Checked = False
            rbVendidos.Checked = False
            rbStock.Checked = False
        End If
    End Sub
    Private Sub txtSerieMot_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSerieMot.Validating

        Try
            If Len(Trim(txtSerieMot.Text)) > 0 Then
                If oLocacionMercaderiaService.Buscar(cbAlmacen.Value, txtSerieMot.Text) Then
                    cbFecInicio.Focus()
                Else
                    MsgBox("No Existe esta Mercaderia")
                    txtSerieMot.Clear()
                    txtSerieMot.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnBuscarMercaderiaOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderiaOrigen.Click
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = cbAlmacen.Value
        frm.CodRub = "04"
        frm.cmbCodRub.ReadOnly = True
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtSerieMot.Text = frm.codigo
            txtSerieMot.BackColor = System.Drawing.SystemColors.Window
        End If
        cbFecInicio.Focus()
    End Sub

End Class