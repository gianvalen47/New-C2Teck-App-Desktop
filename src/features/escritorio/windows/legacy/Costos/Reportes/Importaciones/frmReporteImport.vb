Imports System.ServiceModel
Public Class frmReporteImport
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New ImportacionService.ImportacionServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable
    Private dtMonedas As New DataTable
    Private dtMes As New DataTable
    Private dtImportacion As New DataTable

    Private dtProveedores As DataTable
    Private dtDatos As DataTable

    Private Sub frmReporteImport_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumero.KeyPress _
        , cbOficina.KeyPress _
        , cmbIdCliente.KeyPress
        ', cbAlmacen.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmReporteImport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            ObjMaestro.Close()
            ObjDocumento.Close()
            oSeguridadService.Close()
            oPedidoImportService.Close()
        Catch ex As TimeoutException

            ObjMaestro.Abort()
            ObjDocumento.Abort()
            oSeguridadService.Abort()
            oPedidoImportService.Abort()
        Catch ex As CommunicationException

            ObjMaestro.Abort()
            ObjDocumento.Abort()
            oSeguridadService.Abort()
            oPedidoImportService.Abort()
        End Try
    End Sub

    Private Sub frmReporteImport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReporteImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 61)
        '/*************************************************************************************/

        LlenarCombos()
        rbRegistro.Select()
        cmbMoneda.Value = "NS"

        'Dim Mes, Anio As Integer
        'Dim Fecha As Date
        'Fecha = Today
        'Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        'Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        'txtFechaInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        'txtFechaFin.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)

        '/*Se realiza el cambio de fechas  a pedido de Angélica 14/09/2017*/
        txtFechaInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFechaFin.Value = Date.Today

        rbRegistro.Checked = True
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
            'txtPeriodo.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))
            'dtMes = ObjMaestro.MostrarMeses
            'cbMes.DataSource = dtMes
            'cbMes.DataMember = "Descripcion"
            'cbMes.DisplayMember = "Descripcion"
            'cbMes.ValueMember = "Codigo"
            'cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            'cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            'cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            'dtMes = Nothing

            '======================================= PROVEEDORES ================================================
            dtProveedores = oPedidoImportService.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedores.Rows.InsertAt(getRowTodos(dtProveedores), 0)
            cmbIdCliente.DataSource = dtProveedores
            cmbIdCliente.DropDownList.DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.DropDownList.DisplayMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.DropDownList.ValueMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdCliente.DropDownList.Columns(0).DataMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdCliente.DropDownList.Columns(1).DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.SelectedIndex = 0
            dtProveedores = Nothing

            '========================================= MONEDAS ==================================================
            dtMonedas = ObjMaestro.MostrarMonedas.Tables(0)
            'dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 0

            '========================================== OFICINA ===================================================
            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            Dim row As DataRow = dtOficina.NewRow
            row(0) = ""
            row(1) = "(Todos)"
            dtOficina.Rows.InsertAt(row, 0)
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

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
        Dim row As DataRow = dtAlmacen.NewRow
        row(0) = 0
        row("DesAlm") = "(Todos)"
        dtAlmacen.Rows.InsertAt(row, 0)
        cbAlmacen.DataSource = dtAlmacen
        cbAlmacen.DisplayMember = "DesAlm"
        cbAlmacen.ValueMember = "IdLocacion"
        cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
        cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
        cbAlmacen.SelectedIndex = 0
        dtAlmacen = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim dtReporte As New DataTable

        Dim forma As New frmReportes
        oSeguridadService.RegistrarVisitaOpciones(61, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

        If rbRegistro.Checked Then

            Dim dtReporteview As New DataView

            dtReporteview = ObjDocumento.RegistroImportacion(Session.sCodEmp, cbAlmacen.Value, txtFechaInicio.Value, txtFechaFin.Value, cmbMoneda.Value, txtNroIng.Text).Tables(0).DefaultView

            If dtReporteview.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                'txtPeriodo.Select()
                Exit Sub
            Else
                If rbFechaIngreso.Checked Then
                    dtReporteview.Sort = "FecDoc Asc, FacAdu Asc"
                End If

                ''''''''Dim reporte As New rpRegistroImportacionNTIT
                Dim reporte As New rpRegistroImportacion
                reporte.SetDataSource(dtReporteview)
                forma.crvReportes.ReportSource = reporte


                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("Titulo", IIf(cbAlmacen.Value = 0, "R E G I S T R O  G E N E R A L  D E  I M P O R T A C I O N E S", "R E G I S T R O  D E  I M P O R T A C I O N E S"))
                reporte.SetParameterValue("Subtitulo", IIf(cmbMoneda.Value = "NS", "EXPRESADO EN SOLES", IIf(cmbMoneda.Value = "US", "EXPRESADO EN DÓLARES", "EXPRESADO EN EUROS")))
                reporte.SetParameterValue("Almacen", IIf(cbAlmacen.Value = 0, "", cbOficina.Text & " - " & cbAlmacen.Text))
                reporte.SetParameterValue("FecInicio", txtFechaInicio.Text)
                reporte.SetParameterValue("FecFin", txtFechaFin.Text)
                'reporte.SetParameterValue("Moneda", cmbMoneda.Text)
            End If
        ElseIf rbRegistroUnidad.Checked Then

            Dim dtReporteview As New DataView

            dtReporteview = ObjDocumento.RegistroImportacion(Session.sCodEmp, cbAlmacen.Value, txtFechaInicio.Value, txtFechaFin.Value, cmbMoneda.Value, "").Tables(0).DefaultView

            If dtReporteview.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                'txtPeriodo.Select()
                Exit Sub
            Else
                If rbFechaIngreso.Checked Then
                    dtReporteview.Sort = "FecDoc Asc, FacAdu Asc"
                End If

                ''''''''Dim reporte As New rpRegistroImportacionNTIT
                Dim reporte As New rpRegUnidadImportacion
                reporte.SetDataSource(dtReporteview)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("Titulo", IIf(cbAlmacen.Value = 0, "R E G I S T R O  G E N E R A L  D E  I M P O R T A C I O N E S  P O R  U N I D A D  D E  N E G O C I O", "R E G I S T R O  D E  I M P O R T A C I O N E S  P O R   U N I D A D  D E  N E G O C I O"))
                reporte.SetParameterValue("Subtitulo", IIf(cmbMoneda.Value = "NS", "EXPRESADO EN SOLES", IIf(cmbMoneda.Value = "US", "EXPRESADO EN DÓLARES", "EXPRESADO EN EUROS")))
                reporte.SetParameterValue("Almacen", IIf(cbAlmacen.Value = 0, "", cbOficina.Text & " - " & cbAlmacen.Text))
                reporte.SetParameterValue("FecInicio", txtFechaInicio.Text)
                reporte.SetParameterValue("FecFin", txtFechaFin.Text)
                'reporte.SetParameterValue("Moneda", cmbMoneda.Text)
            End If
        ElseIf rbResumen.Checked Then
            If txtNumero.Text = "" Then
                MsgBox("Ingrese el numero de la factura", MsgBoxStyle.Information, "Ingrese Numero")
                txtNumero.Select()
                Exit Sub
            End If

            dtReporte = ObjDocumento.ResumenImportacion(cbAlmacen.Value, txtNumero.Text).Tables(0)
            'dtReporte.WriteXmlSchema("D:\Proyecto\Codigo\SIGECOM\Cliente\Reportes\OrigenDatos\ResumenImportacion.xml")
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                txtNumero.Select()
                Exit Sub
            Else
                Dim reporte As New rptResumenImportacion
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("Almacen", IIf(cbAlmacen.Value = 0, "", cbOficina.Text & " - " & cbAlmacen.Text))

            End If

        ElseIf rbRegistroProveedor.Checked = True Then
            dtReporte = ObjDocumento.RegistroImportacionProveedor(Session.sCodEmp, cbAlmacen.Value, toNumber(cmbIdCliente.Value), txtFechaInicio.Value, txtFechaFin.Value, cmbMoneda.Value).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                'txtPeriodo.Select()
                Exit Sub
            Else
                If cbFlete.Checked = True Then
                    Dim reporte1 As New rpRegProveedorImportacion_Flete
                    reporte1.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte1

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte1.SetParameterValue("Subtitulo", IIf(cmbMoneda.Value = "NS", "EXPRESADO EN SOLES", IIf(cmbMoneda.Value = "US", "EXPRESADO EN DÓLARES", "EXPRESADO EN EUROS")))
                    reporte1.SetParameterValue("FecInicio", txtFechaInicio.Text)
                    reporte1.SetParameterValue("FecFin", txtFechaFin.Text)
                    'reporte.SetParameterValue("Moneda", cmbMoneda.Text)
                Else
                    Dim reporte As New rpRegProveedorImportacion
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("Subtitulo", IIf(cmbMoneda.Value = "NS", "EXPRESADO EN SOLES", IIf(cmbMoneda.Value = "US", "EXPRESADO EN DÓLARES", "EXPRESADO EN EUROS")))
                    reporte.SetParameterValue("FecInicio", txtFechaInicio.Text)
                    reporte.SetParameterValue("FecFin", txtFechaFin.Text)
                    'reporte.SetParameterValue("Moneda", cmbMoneda.Text)

                End If

            End If

        ElseIf rbPreciovsCosto.Checked = True And cbExportarExcel.Checked = True Then

            Dim dtReporteview As New DataView
            Dim dtExport As New DataTable

            dtReporteview = ObjDocumento.RegistroImportacionPreciovsCosto(cbAlmacen.Value, txtFechaInicio.Value, txtFechaFin.Value).Tables(0).DefaultView
            dtExport = ObjDocumento.RegistroImportacionPreciovsCosto(cbAlmacen.Value, txtFechaInicio.Value, txtFechaFin.Value).Tables(0)
            DataGridView1.DataSource = dtExport

            If dtReporteview.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                Exit Sub
            Else
                Dim Export As Boolean = False
                Export = ExportarExcel(DataGridView1)
            End If

        ElseIf rbPreciovsCosto.Checked = True And cbExportarExcel.Checked = False Then

            Dim dtReporteview As New DataView
            dtReporteview = ObjDocumento.RegistroImportacionPreciovsCosto(cbAlmacen.Value, txtFechaInicio.Value, txtFechaFin.Value).Tables(0).DefaultView

            If dtReporteview.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                Exit Sub
            Else
                If rbFechaIngreso.Checked Then
                    dtReporteview.Sort = "FecDoc Asc"
                End If

                Dim reporte As New rpRegistroPrecioVsCosto
                reporte.SetDataSource(dtReporteview)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("Almacen", IIf(cbAlmacen.Value = 0, "", cbOficina.Text & " - " & cbAlmacen.Text))
                reporte.SetParameterValue("FecInicio", txtFechaInicio.Text)
                reporte.SetParameterValue("FecFin", txtFechaFin.Text)
            End If

        End If
        forma.crvReportes.DisplayGroupTree = False
        forma.Text = "Reporte de Importaciones"
        forma.ShowDialog()
    End Sub

    Private Sub rbRegistro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRegistro.CheckedChanged
        If rbRegistro.Checked = True Then
            gbPeriodo.Visible = True
            gbMoneda.Visible = True
            gbNumero.Visible = False
            gbEmbarque.Visible = False
            gbProveedor.Visible = False
            gbOrdenar.Visible = True
            gbOrdenar.Location = New System.Drawing.Point(6, 302)
            gbAlmacenes.Visible = True
            gbNroIng.Visible = True
            gbFlete.Visible = False
            gbExportarExcel.Visible = False
            'btnAceptar.Location = New System.Drawing.Point(145, 199)
            'btnCancelar.Location = New System.Drawing.Point(226, 199)
            'Me.Size = New System.Drawing.Size(320, 260)
            btnAceptarE.Visible = False
            btnAceptar.Visible = True
            btnAceptar.Location = New System.Drawing.Point(145, 348)
            btnCancelar.Location = New System.Drawing.Point(226, 348)
            Me.Size = New System.Drawing.Size(326, 424)
        End If        
    End Sub

    Private Sub rbRegistroUnidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRegistroUnidad.CheckedChanged
        If rbRegistroUnidad.Checked = True Then
            gbPeriodo.Visible = True
            gbMoneda.Visible = True
            gbNumero.Visible = False
            gbEmbarque.Visible = False
            gbProveedor.Visible = False
            gbOrdenar.Visible = True
            gbOrdenar.Location = New System.Drawing.Point(6, 237)
            gbAlmacenes.Visible = True
            gbNroIng.Visible = False
            gbFlete.Visible = False
            gbExportarExcel.Visible = False
            'btnAceptar.Location = New System.Drawing.Point(145, 199)
            'btnCancelar.Location = New System.Drawing.Point(226, 199)
            'Me.Size = New System.Drawing.Size(320, 260)
            btnAceptarE.Visible = False
            btnAceptar.Visible = True
            btnAceptar.Location = New System.Drawing.Point(145, 283)
            btnCancelar.Location = New System.Drawing.Point(226, 283)
            Me.Size = New System.Drawing.Size(326, 354)
        End If
    End Sub

    Private Sub rbResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbResumen.CheckedChanged
        If rbResumen.Checked = True Then
            gbPeriodo.Visible = False
            gbMoneda.Visible = False
            gbNumero.Visible = True
            gbEmbarque.Visible = False
            gbNumero.Location = New System.Drawing.Point(6, 110)
            txtNumero.Focus()
            gbProveedor.Visible = False
            gbOrdenar.Visible = False
            gbAlmacenes.Visible = True
            gbNroIng.Visible = False
            gbFlete.Visible = False
            gbExportarExcel.Visible = False
            btnAceptarE.Visible = False
            btnAceptar.Visible = True
            btnAceptar.Location = New System.Drawing.Point(145, 238)
            btnCancelar.Location = New System.Drawing.Point(226, 238)
            Me.Size = New System.Drawing.Size(326, 310)
        End If
    End Sub

    Private Sub rbRegistroProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbRegistroProveedor.CheckedChanged
        If rbRegistroProveedor.Checked = True Then
            gbPeriodo.Visible = True
            gbMoneda.Visible = True
            gbNumero.Visible = False
            gbEmbarque.Visible = False
            gbProveedor.Visible = True
            gbOrdenar.Visible = False
            gbAlmacenes.Visible = True
            gbNroIng.Visible = False
            gbExportarExcel.Visible = False
            gbFlete.Visible = True
            gbFlete.Location = New System.Drawing.Point(6, 283)
            btnAceptarE.Visible = False
            btnAceptar.Visible = True
            btnAceptar.Location = New System.Drawing.Point(145, 288)
            btnCancelar.Location = New System.Drawing.Point(226, 288)
            Me.Size = New System.Drawing.Size(326, 362)
        End If        
    End Sub

    Private Sub rbEmbarque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEmbarque.CheckedChanged
        If rbEmbarque.Checked = True Then
            gbPeriodo.Visible = False
            gbMoneda.Visible = False
            gbNumero.Visible = False
            gbEmbarque.Visible = True
            gbEmbarque.Location = New Point(6, 110)
            txtEmbarque.Focus()
            gbProveedor.Visible = False
            gbOrdenar.Visible = False
            gbAlmacenes.Visible = False
            gbNroIng.Visible = False
            gbFlete.Visible = False
            gbExportarExcel.Visible = False
            btnAceptarE.Visible = True
            btnAceptar.Visible = False
            btnAceptarE.Location = New System.Drawing.Point(145, 173)
            btnCancelar.Location = New System.Drawing.Point(226, 173)
            Me.Size = New System.Drawing.Size(326, 245)
        End If
    End Sub

    Private Sub rbPreciovsCosto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPreciovsCosto.CheckedChanged
        If rbPreciovsCosto.Checked = True Then
            gbPeriodo.Visible = True
            gbMoneda.Visible = False
            gbNumero.Visible = False
            gbEmbarque.Visible = False
            gbProveedor.Visible = False
            gbOrdenar.Visible = True
            gbOrdenar.Location = New System.Drawing.Point(6, 237)
            gbAlmacenes.Visible = True
            gbNroIng.Visible = False
            gbFlete.Visible = False
            gbExportarExcel.Visible = True
            gbExportarExcel.Location = New System.Drawing.Point(6, 278)
            'btnAceptar.Location = New System.Drawing.Point(145, 199)
            'btnCancelar.Location = New System.Drawing.Point(226, 199)
            'Me.Size = New System.Drawing.Size(320, 260)
            btnAceptarE.Visible = False
            btnAceptar.Visible = True
            btnAceptar.Location = New System.Drawing.Point(145, 283)
            btnCancelar.Location = New System.Drawing.Point(226, 283)
            Me.Size = New System.Drawing.Size(326, 354)
        End If
    End Sub

    Private Sub rbComparacionCabDet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbComparacionCabDet.CheckedChanged
        If rbComparacionCabDet.Checked = True Then
            gbPeriodo.Visible = False
            gbMoneda.Visible = False
            gbNumero.Visible = False
            gbEmbarque.Visible = True
            gbEmbarque.Location = New Point(6, 110)
            txtEmbarque.Focus()
            gbProveedor.Visible = False
            gbOrdenar.Visible = False
            gbAlmacenes.Visible = False
            gbNroIng.Visible = False
            gbFlete.Visible = False
            btnAceptarE.Visible = True
            btnAceptar.Visible = False
            btnAceptarE.Location = New System.Drawing.Point(145, 173)
            btnCancelar.Location = New System.Drawing.Point(226, 173)
            Me.Size = New System.Drawing.Size(326, 245)
        End If
    End Sub

    'Private Sub rbRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbRegistro.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        txtPeriodo.Select()
    '    End If
    'End Sub

    Private Sub cbAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub btnAceptarE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarE.Click
        Try
            If rbEmbarque.Checked = True Then
                dtDatos = ObjDocumento.RegistroImportacionEmbarque(txtEmbarque.Text).Tables(0)                
            ElseIf rbComparacionCabDet.Checked = True Then
                dtDatos = ObjDocumento.RegistroImportacionCabeceravsDetalle(txtEmbarque.Text).Tables(0)
            End If

            dgvDatos.DataSource = dtDatos

            Dim Export As Boolean
            If dtDatos.Rows.Count > 0 Then
                Export = ExportarExcel(dgvDatos)
                If Export Then
                    MsgBox("Se realizó la exportación correctamente ")
                End If
            Else
                MsgBox("No hay datos que exportar. Verifique!!!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
End Class
