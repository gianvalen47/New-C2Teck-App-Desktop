Imports System.ServiceModel
Public Class frmRepPlanilla
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtUnidades As DataTable
    Private dtBancos As DataTable
    Private IdPer As String
    Private dtCobrador As New DataTable
    Public IdCliente As Integer

    Private Sub frmRepPlanilla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            oPlanillaService.Close()
            oCentroCostoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            oPlanillaService.Abort()
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            oPlanillaService.Abort()
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        'Try
        '    fila(5) = "(Todos)"
        'Catch ex As Exception

        'End Try

        Return fila
    End Function

    Private Sub frmRepPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepPlanilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
             cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 51)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date
        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cmbCobrador.Value = "(Todos)"
        llenarCombos()
        cbFecInicio.Select()


    End Sub
    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 1
        Catch ex As Exception

        End Try
        Try
            fila(1) = "OFICINA LIMA"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Sub llenarCombos()
        Try
            dtCobrador = oPlanillaService.MostrarCobradores(Session.sCodEmp).Tables(0)
            dtCobrador.Rows.InsertAt(getRowTodos(dtCobrador), 0)
            dtCobrador.Rows.InsertAt(getRowAsignado(dtCobrador), 0)
            cmbCobrador.DataSource = dtCobrador
            cmbCobrador.DisplayMember = "ApeNom"
            cmbCobrador.ValueMember = "IdPer"
            cmbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cmbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            'cbCobrador.SelectedIndex = 0
            dtCobrador = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

            '======================================= BANCOS =================================================
            dtBancos = ObjMaestro.MostrarBancos.Tables(0)
            dtBancos.Rows.InsertAt(getRowTodos(dtBancos), 0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.SelectedIndex = 0
            dtBancos = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepPlanilla
            Dim reporteUN As New rpRepPlanillaDetUN
            Dim reporteBanco As New rpRepPlanillaDetBanco

            If rbResumido.Checked = True Then

                dtReporte = oPlanillaService.Reporte(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value)).Tables(0)

                If dtReporte.Rows.Count = 0 Then
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

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Cobrador", cmbCobrador.Text)
                    reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)
                    forma.Text = "Reporte de Planilla de Cobranzas"
                    forma.ShowDialog()
                End If


            ElseIf rbDetallado.Checked = True Then
                If rbUnidadNegocio.Checked = True Then

                    dtReporte = oPlanillaService.ReporteDetalle(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value), IdCliente, IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value), toBlank(cmbBanco.Value)).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteUN.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteUN

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporteUN.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporteUN.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporteUN.SetParameterValue("Cobrador", cmbCobrador.Text)
                        reporteUN.SetParameterValue("Cliente", txtCliente.Text)
                        reporteUN.SetParameterValue("Unidad", cmbUnidad.Text)
                        reporteUN.SetParameterValue("Banco", cmbBanco.Text)
                        forma.Text = "Reporte de Planilla de Cobranzas"
                        forma.ShowDialog()
                    End If

                ElseIf rbBancos.Checked = True Then

                    dtReporte = oPlanillaService.ReporteDetalle(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value), IdCliente, IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value), toBlank(cmbBanco.Value)).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteBanco.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteBanco

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporteBanco.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporteBanco.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporteBanco.SetParameterValue("Cobrador", cmbCobrador.Text)
                        reporteBanco.SetParameterValue("Cliente", txtCliente.Text)
                        reporteBanco.SetParameterValue("Unidad", cmbUnidad.Text)
                        reporteBanco.SetParameterValue("Banco", cmbBanco.Text)
                        forma.Text = "Reporte de Planilla de Cobranzas"
                        forma.ShowDialog()
                    End If

                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    
    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(51, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()

    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbResumido_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbResumido.CheckedChanged, rbDetallado.CheckedChanged
        If rbResumido.Checked = True Then
            IdCliente = 0
            txtCliente.Text = "(Todos)"
            gbCliente.Enabled = False            
            cmbBanco.ReadOnly = True
            cmbBanco.BackColor = System.Drawing.SystemColors.Control            
            cmbUnidad.ReadOnly = True
            cmbUnidad.BackColor = System.Drawing.SystemColors.Control
            gbAgrupadoPor.Enabled = False
        ElseIf rbDetallado.Checked = True Then
            gbCliente.Enabled = True
            cmbBanco.ReadOnly = False
            cmbBanco.BackColor = System.Drawing.SystemColors.Window
            cmbUnidad.ReadOnly = False
            cmbUnidad.BackColor = System.Drawing.SystemColors.Window
            gbAgrupadoPor.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
        rbBuscarCliente.Checked = False
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        If rbBuscarCliente.Checked = True Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        End If
    End Sub
End Class