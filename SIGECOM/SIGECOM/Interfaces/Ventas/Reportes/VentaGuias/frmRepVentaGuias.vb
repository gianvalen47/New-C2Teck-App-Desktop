Imports System.ServiceModel
Public Class frmRepVentaGuias
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Dim dtMotivos As DataTable
    Dim dtOficinas As DataTable
    Dim dtAlmacenes As DataTable
    Dim dtVendedor As DataTable
    Dim IdCliente As String
    Dim IdLocacion As String
    Dim Tipo As String


    Private Sub frmRepVentaGuias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub


    Private Sub frmRepVentaGuias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    cbFecInicio.KeyPress _
                    , cbFecFinal.KeyPress _
                    , txtCliente.KeyPress _
                    , rbTodaLocacion.KeyPress _
                    , rbBuscarCliente.KeyPress _
                    , rbPendientes.KeyPress _
                    , cmbOficinas.KeyPress _
                    , cmbCodMot.KeyPress
        ', cmbIdLocacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub cmbIdLocacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIdLocacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCliente.Focus()
        End If
    End Sub

    Private Sub cmbVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVendedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAceptar.Select()
        End If
    End Sub

    Private Sub frmRepVentaGuias_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarCliente_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            'fila(0) = 0
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
    Private Function getRowMotivo(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "7"
        Catch ex As Exception
            'fila(0) = 0
        End Try
        Try
            fila(1) = "Consignación"
        Catch ex As Exception

        End Try

        'Try
        '    fila(5) = "(Todos)"
        'Catch ex As Exception

        'End Try

        Return fila
    End Function
    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 1
        Catch ex As Exception

        End Try
        Try
            fila(1) = "ASIGNADO A OFICINA"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Sub frmRepVentaGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 34)
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
        cmbCodMot.Value = "(Todos)"
        cbFecInicio.Select()
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Motivos===========================================
            dtMotivos = oMaestro.MostrarMotivos.Tables(0)
            dtMotivos.Rows.InsertAt(getRowTodos(dtMotivos), 0)
            dtMotivos.Rows.InsertAt(getRowMotivo(dtMotivos), 7)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing

            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            'dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowAsignado(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            dtVendedor = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepVentaGuias
            Dim reportefecha As New rpRepVentaGuiasFechas

            If rbTodaLocacion.Checked Then
                IdLocacion = "0"
            ElseIf rbUna.Checked Then
                IdLocacion = cmbIdLocacion.Value
            End If

            If rbGuia.Checked Then
                dtReporte = oReporteVentaService.VentaGuias(Session.sCodEmp, IdLocacion, cbFecInicio.Value, cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbCodMot.Text = "(Todos)", "", cmbCodMot.Value), IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value), Tipo, 1).Tables(0)

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

                    forma.Text = "Reporte de Guias de Ventas / Guias sin Facturar"
                    reporte.SetParameterValue("Motivo", cmbCodMot.Text)
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Vendedor", IIf(rbTodoVendedor.Checked = True, "(Todos)", cmbVendedor.Text))
                    reporte.SetParameterValue("Locacion", IdLocacion)
                    If rbPendientes.Checked Then
                        reporte.SetParameterValue("Reporte", "Reporte de Guías Pendientes de Facturación")
                    ElseIf rbTodos.Checked Then
                        reporte.SetParameterValue("Reporte", "Reporte de Guías")
                    End If

                    forma.ShowDialog()
                End If

            ElseIf rbGuiaFecha.Checked Then
                dtReporte = oReporteVentaService.VentaGuias(Session.sCodEmp, IdLocacion, cbFecInicio.Value, cbFecFinal.Value, IIf(rbBuscarCliente.Checked = True, 0, IdCliente), IIf(cmbCodMot.Text = "(Todos)", "", cmbCodMot.Value), IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value), Tipo, 2).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else

                    reportefecha.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reportefecha

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Guias de Remisión / Guias de Remision sin Facturar"
                    reportefecha.SetParameterValue("Motivo", cmbCodMot.Text)
                    reportefecha.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reportefecha.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reportefecha.SetParameterValue("Vendedor", IIf(rbTodoVendedor.Checked = True, "(Todos)", cmbVendedor.Text))
                    reportefecha.SetParameterValue("Locacion", IdLocacion)
                    If rbPendientes.Checked Then
                        reportefecha.SetParameterValue("Reporte", "Reporte de Guías de Remisión Pendientes de Facturación")
                    ElseIf rbTodos.Checked Then
                        reportefecha.SetParameterValue("Reporte", "Reporte de Guías de Remisión")
                    End If

                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            'dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = 0
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(34, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbTipos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPendientes.CheckedChanged, rbTodos.CheckedChanged
        If rbPendientes.Checked Then
            Tipo = "1"
        ElseIf rbTodos.Checked Then
            Tipo = "2"
        End If
    End Sub

    Private Sub rbTodaLocacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodaLocacion.CheckedChanged
        cmbOficinas.Enabled = False
        lblOficina.Enabled = False
        cmbIdLocacion.Enabled = False
        lblAlmacen.Enabled = False

    End Sub

    Private Sub rbUna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUna.CheckedChanged
        cmbOficinas.Enabled = True
        lblOficina.Enabled = True
        cmbIdLocacion.Enabled = True
        lblAlmacen.Enabled = True
        cmbOficinas.Select()
    End Sub

    Private Sub rbTodoVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodoVendedor.CheckedChanged
        If rbTodoVendedor.Checked Then
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = True
        Else
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = False
        End If

    End Sub
End Class