Imports System.ServiceModel

Public Class frmRegAuxiliarVenta
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestro As New MaestroService.MaestroClient

    Private dtoficinas As DataTable

    Dim CodMon As String

    Private Sub frmRegAuxiliarVenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRegAuxiliarVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cbFecInicio.KeyPress _
                          , cbFecFinal.KeyPress _
                          , rbRepuestos.KeyPress _
                          , rbSoles.KeyPress _
                          , cmbOficinas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRegAuxiliarVenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub frmRegAuxiliarVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 30)
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
        llenarCombos()
        cbFecInicio.Select()

    End Sub
    Private Sub desactivar()
        lblOficina.Visible = False
        gbMoneda.Visible = False
        cmbOficinas.Visible = False
    End Sub
    Private Sub activar()
        lblOficina.Visible = True
        gbMoneda.Visible = True
        cmbOficinas.Visible = True
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtoficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtoficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtoficinas = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView

            If rbRepuestos.Checked Then

                Dim reporte As New rpRegAuxiliarVentaRep
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 1).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    'dtReporte.Sort = "Documento Asc "
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"


                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If

            ElseIf rbBaterias.Checked Then


                Dim reporte As New rpRegAuxiliarVentaBat
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 2).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If
            ElseIf rbFiltros.Checked Then

                Dim reporte As New rpRegAuxiliarVentaFil
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 8).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If


            ElseIf rbMotores.Checked Then


                Dim reporte As New rpRegAuxiliarVentaMot
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 4).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If
            ElseIf rbNotaDebito.Checked Then

                Dim reporte As New rpRegAuxiliarVentaNota
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 6).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If
            ElseIf rbConsignacion.Checked Then
                Dim reporte As New rpRegAuxiliarVentaCons
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 5).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If
            ElseIf rbServicios.Checked Then
                Dim reporte As New rpRegAuxiliarVentaSer
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 3).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If
            ElseIf rbTranGrat.Checked Then

                Dim reporte As New rpRegAuxiliarVentaGratis
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 7).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()

                End If

                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\RegistroAuxiliarVenta.xml")

            ElseIf rbMercaSinMov.Checked Then

                Dim reporte As New rpRegAuxiliarVentaMercasinmov
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 9).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If

            ElseIf rbOtros.Checked Then '--A pedido de Angélica 07/05/2015

                Dim reporte As New rpRegAuxiliarVentaOtro
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 10).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If

            ElseIf rbProyectosNuevos.Checked Then '--A pedido de Angélica 06/01/2016
                Dim reporte As New rpRegAuxiliarVentaProy
                dtReporte = oReporteVentaService.RegistroAuxiliarVenta(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, CodMon, 11).Tables(0).DefaultView
                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Registro Auxiliar de Ventas"
                    If CodMon = "US" Then
                        reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                    ElseIf CodMon = "NS" Then
                        reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                    End If
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub rbMoneda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged, rbDolares.CheckedChanged

        If rbSoles.Checked Then
            CodMon = "NS"
        ElseIf rbDolares.Checked Then
            CodMon = "US"
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(30, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()

    End Sub

    Private Sub rbRepuestos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRepuestos.CheckedChanged, rbBaterias.CheckedChanged, rbServicios.CheckedChanged, rbMotores.CheckedChanged, rbConsignacion.CheckedChanged, rbFiltros.CheckedChanged, rbMercaSinMov.CheckedChanged
        activar()

    End Sub

    'Private Sub rbBaterias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBaterias.CheckedChanged
    '    activar()

    'End Sub

    'Private Sub rbServicios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbServicios.CheckedChanged
    '    activar()

    'End Sub

    'Private Sub rbMotores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMotores.CheckedChanged
    '    activar()

    'End Sub

    'Private Sub rbOtros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOtros.CheckedChanged
    '    activar()

    'End Sub

    Private Sub rbNotaDebito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNotaDebito.CheckedChanged, rbTranGrat.CheckedChanged
        desactivar()

    End Sub

    'Private Sub rbTranGrat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTranGrat.CheckedChanged
    '    desactivar()

    'End Sub

    'Private Sub rbFiltros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFiltros.CheckedChanged
    '    activar()
    'End Sub

    'Private Sub rbMercaSinMov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMercaSinMov.CheckedChanged

    'End Sub


    Private Sub cmbOficinas_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            If cmbOficinas.Value = "03" Or cmbOficinas.Value = "04" Then
                rbServicios.Text = "Reparaciones"
                rbConsignacion.Text = "Usufructo"
            Else
                rbServicios.Text = "Servicios"
                rbConsignacion.Text = "Consignación"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class