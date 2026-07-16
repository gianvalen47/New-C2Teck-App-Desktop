Imports System.ServiceModel
Public Class frmRegistroVenta
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestro As New MaestroService.MaestroClient

    Private CodMon As String
    Private dtTipoDocumentos As DataTable
    Dim IdCliente As String

    Private Sub frmRegistroVenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmRegistroVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cbFecInicio.KeyPress _
                         , rbSoles.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRegistroVenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub frmRegistroVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 29)
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
        llenarCombos()
        IdCliente = 0
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()

    End Sub


    Private Sub llenarCombos()
        Try
            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oMaestro.MostrarTipDocCtaCte.Tables(0)
            'Dim row As DataRow = dtTipoDocumentos.NewRow
            'row(0) = 0
            'row(1) = "(Todos)"
            'dtTipoDocumentos.Rows.InsertAt(row, 0)
            dtTipoDocumentos.Rows.InsertAt(getRowTodos(dtTipoDocumentos), 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocu.SelectedIndex = 0
            dtTipoDocumentos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "0"
        Catch ex As Exception

        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function


    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRegistroVenta
            Dim dtReporte As New DataTable

            If rbAntiguo.Checked = True Then

                dtReporte = oReporteVentaService.RegistroVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, CodMon, 1, IdCliente, utils.toNumber(cmbDocu.Value)).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else

                    If rbPantalla.Checked = True Then

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Registro de Ventas"
                        If CodMon = "US" Then
                            reporte.SetParameterValue("Moneda", "EN DOLARES USA")
                        ElseIf CodMon = "NS" Then
                            reporte.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                        End If
                        reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporte.SetParameterValue("FecFinal", cbFecFinal.Value)

                        forma.ShowDialog()

                    ElseIf rbExportExcel.Checked = True Then

                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If

                    End If

                End If
            ElseIf rbNuevo.Checked = True Then

                dtReporte = oReporteVentaService.RegistroVenta(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, CodMon, 2, IdCliente, utils.toNumber(cmbDocu.Value)).Tables(0)

                If rbPantalla.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        ' MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                        Dim reporteNuevo As New rpRegistroVentaNuevoVacio

                        reporteNuevo.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteNuevo

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Registro de Ventas"
                        If CodMon = "US" Then
                            reporteNuevo.SetParameterValue("Moneda", "EN DOLARES USA")
                        ElseIf CodMon = "NS" Then
                            reporteNuevo.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                        End If

                        reporteNuevo.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporteNuevo.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporteNuevo.SetParameterValue("Parametro", IIf(rbSinPag.Checked = True, "1", "0"))
                        reporteNuevo.SetParameterValue("RucEmp", oMaestro.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                        reporteNuevo.SetParameterValue("DesEmp", oMaestro.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))

                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                        'dtReporte.WriteXmlSchema("C:\RegistroVenta.xml")

                        forma.ShowDialog()

                    Else
                        If rbConCeldas.Checked Then
                            Dim reporteNuevo As New rpRegistroVentaNuevo

                            reporteNuevo.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteNuevo

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Reporte de Registro de Ventas"
                            If CodMon = "US" Then
                                reporteNuevo.SetParameterValue("Moneda", "EN DOLARES USA")
                            ElseIf CodMon = "NS" Then
                                reporteNuevo.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                            End If

                            reporteNuevo.SetParameterValue("FecInicio", cbFecInicio.Value)
                            reporteNuevo.SetParameterValue("FecFinal", cbFecFinal.Value)
                            reporteNuevo.SetParameterValue("Parametro", IIf(rbSinPag.Checked = True, "1", "0"))
                            'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                            'dtReporte.WriteXmlSchema("C:\RegistroVenta.xml")

                            forma.ShowDialog()

                        ElseIf rbSinCeldas.Checked Then
                            Dim reporteNuevo As New rpRegistroVentaNuevoSinCeldas

                            reporteNuevo.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteNuevo

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Reporte de Registro de Ventas"
                            If CodMon = "US" Then
                                reporteNuevo.SetParameterValue("Moneda", "EN DOLARES USA")
                            ElseIf CodMon = "NS" Then
                                reporteNuevo.SetParameterValue("Moneda", "EN NUEVOS SOLES")
                            End If

                            reporteNuevo.SetParameterValue("FecInicio", cbFecInicio.Value)
                            reporteNuevo.SetParameterValue("FecFinal", cbFecFinal.Value)
                            reporteNuevo.SetParameterValue("Parametro", IIf(rbSinPag.Checked = True, "1", "0"))
                            'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                            'dtReporte.WriteXmlSchema("C:\RegistroVenta.xml")

                            forma.ShowDialog()
                        End If

                    End If

                ElseIf rbExportExcel.Checked = True Then

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(29, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbMoneda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged, rbDolares.CheckedChanged
        If rbSoles.Checked Then
            CodMon = "NS"
        ElseIf rbDolares.Checked Then
            CodMon = "US"
        End If
    End Sub

    Private Sub rbNuevo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNuevo.CheckedChanged, rbAntiguo.CheckedChanged
        If rbNuevo.Checked = True Then
            gbImpresion.Enabled = True
        ElseIf rbAntiguo.Checked = True Then
            gbImpresion.Enabled = False
        End If
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        If rbBuscarCliente.Checked = True Then
            txtCliente.Text = ""
            IdCliente = 0
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            rbBuscarCliente.Checked = False
        End If
        'txtCliente.Select()
    End Sub

    Private Sub cbFecFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Select()
            'btnAceptar_Click(sender, e)
        End If
    End Sub

End Class