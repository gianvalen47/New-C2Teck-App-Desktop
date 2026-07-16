Imports System.ServiceModel

Public Class frmRepSolicitudGasto

    '============================Servicios===================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient

    '======================Declaración de Variables==============================
    Dim dtReporte As DataTable
    Dim IdProveedor As String
    Dim IdPersona As String
    Private dtEstados As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable
    Private dtMonedas As DataTable
    Private dtTipDoc As DataTable
    Private dtRubroViaje As DataTable
    Private dtPlaca As DataTable
    Private dtTipoGasto As DataTable


    Private Sub frmRepSolicitudGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oSolicitudGastoDetService.Close()
            oVehiculoService.Close()
            oPersonaService.close()
            oOrdenesCompraService.close()
            oSeguridadService.Close()
            oReembolsoCajaDetService.close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()            
            oSolicitudGastoDetService.Abort()
            oVehiculoService.Abort()
            oPersonaService.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
            oReembolsoCajaDetService.abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSolicitudGastoDetService.Abort()
            oVehiculoService.Abort()
            oPersonaService.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
            oReembolsoCajaDetService.Abort()
        End Try
    End Sub

    Private Sub frmRepSolicitudGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepSolicitudGasto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 158)
        '/*************************************************************************************/

        ' Validar Usuario - Exportar Excel
        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
            rbExcel.Enabled = True
        Else
            rbExcel.Enabled = False
        End If

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombos()
        cmbMoneda.Value = "NS"
        'cmbPosesion.Value = 0
        'cmbPosesion.Text = "(Todos)"
        rbTotalizado.Checked = True
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de OT")
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        If Len(Trim(txtNumJob.Text)) > 0 Then
            If Not (oJobService.Buscar(txtNumJob.Text)) Then
                MsgBox("Número de OT no existente, Verifique")
                txtNumJob.Text = ""
                txtNumJob.Focus()
            End If
        Else
            MsgBox("Ingrese un N° de OT")
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oSolicitudGastoService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("AplicaIgv").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

            '======================================= RUBRO VIAJE ==============================================
            dtRubroViaje = oSolicitudGastoDetService.MostrarRubroViaje.Tables(0)
            dtRubroViaje.Rows.InsertAt(getRowTodos(dtRubroViaje), 0)
            cmbRubroViaje.DataSource = dtRubroViaje
            cmbRubroViaje.DropDownList.DataMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.DropDownList.DisplayMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.DropDownList.ValueMember = dtRubroViaje.Columns("IdRubro").ToString
            cmbRubroViaje.DropDownList.Columns(0).DataMember = dtRubroViaje.Columns("IdRubro").ToString
            cmbRubroViaje.DropDownList.Columns(1).DataMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.SelectedIndex = 0
            dtRubroViaje = Nothing

            '========================================== PLACA ===============================================
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos1(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing

            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            dtTipoGasto.Rows.InsertAt(getRowTodos(dtTipoGasto), 0)
            cmbTipoGasto.DataSource = dtTipoGasto
            cmbTipoGasto.DropDownList.DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.DisplayMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.ValueMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(0).DataMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(1).DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.Columns(2).DataMember = dtTipoGasto.Columns("Observacion").ToString
            cmbTipoGasto.SelectedIndex = 0
            dtTipoGasto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
                dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = "(Todos)"
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

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
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub rbTotalizado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotalizado.CheckedChanged
        If rbTotalizado.Checked Then
            gbPersona.Enabled = False
            gbProveedor.Enabled = False
            txtNumJob.Enabled = False
            txtNumJob.Text = ""
            btnBuscarJob.Enabled = False
            txtCodCuenta.Enabled = False
            txtCodCuenta.Text = ""
            cmbTipoDoc.Enabled = False
            cmbTipoGasto.Enabled = False
            cmbTipoDoc.SelectedIndex = -1
            cmbTipoGasto.SelectedIndex = -1
            txtDocumento.Enabled = False
            txtDocumento.Text = ""
            cmbPlaca.Enabled = False
            cmbPlaca.SelectedIndex = -1
            txtDescripcion.Enabled = False
            txtDescripcion.Text = ""
            gbProcesoJob.Enabled = False
            gbGastoViaje.Enabled = False
            rbTodos.Checked = True
            IdProveedor = 0
            txtProveedor.Text = "(Todos)"
            txtArea.Text = "Area de la Cabecera"
            cmbCentroCosto.Enabled = False
            cmbRubroViaje.Enabled = False
            cmbRubroViaje.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frmBuscarProveedor
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtProveedor.Text = frm.descripcion
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            IdProveedor = frm.codigo
        End If
        txtProveedor.Select()
        rbBuscarProveedor.Checked = False
    End Sub

    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If
    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked Then
            gbPersona.Enabled = True
            gbProveedor.Enabled = True
            txtNumJob.Enabled = True
            btnBuscarJob.Enabled = True
            txtCodCuenta.Enabled = True
            cmbTipoDoc.Enabled = True
            cmbTipoDoc.SelectedIndex = 0
            cmbTipoGasto.Enabled = True
            cmbTipoGasto.SelectedIndex = 0
            txtDocumento.Enabled = True
            cmbPlaca.Enabled = True
            cmbPlaca.SelectedIndex = 0
            txtDescripcion.Enabled = True
            gbProcesoJob.Enabled = True
            gbGastoViaje.Enabled = True
            rbTodos.Checked = True
            txtPersona.Text = "(Todos)"
            txtArea.Text = "Area  y Centro de Costo del Detalle"
            cmbCentroCosto.Enabled = True
            rbGVTodos.Checked = True
            cmbRubroViaje.Enabled = False
            cmbRubroViaje.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validarData() = True Then
            oSeguridadService.RegistrarVisitaOpciones(158, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbDetallado.Checked Then
                MostrarReporteDetallado()
            ElseIf rbTotalizado.Checked Then
                MostrarReporteTotalizado()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function validarData() As Boolean
        If cbFecInicio.Value > cbFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            cbFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub MostrarReporteDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rptSolGastoDetallado

            If txtProveedor.Text = "(Todos)" Then
                IdProveedor = 0
            End If

            If txtPersona.Text = "(Todos)" Then
                IdPersona = 0
            End If

            dtReporte = oSolicitudGastoService.ReporteSolicitudGastoDetalle(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, cmbMoneda.Value, _
                                                                                                            cmbCodArea.Value, cmbCentroCosto.Value, txtNumJob.Text.Trim, txtCodCuenta.Text.Trim, _
                                                                                                            IdProveedor, utils.toNumber(cmbTipoDoc.Value), utils.toNumber(cmbEstado.Value), txtDescripcion.Text, _
                                                                                                            txtDocumento.Text, IdPersona, utils.toNumber(cmbRubroViaje.Value), IIf(cmbPlaca.SelectedIndex = 0, "", cmbPlaca.Value), toNumber(cmbTipoGasto.Value)).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                'If rbTodos.Checked Then
                '    dtReporte.RowFilter = ""
                'ElseIf rbSiProcJob.Checked Then
                '    dtReporte.RowFilter = "ProcesoJob = 1"
                'ElseIf rbNoProcJob.Checked Then
                '    dtReporte.RowFilter = "ProcesoJob = 0 And CodJob <>''"
                'End If

                'If rbGVTodos.Checked Then
                '    dtReporte.RowFilter = ""
                'ElseIf rbSiGastoViaje.Checked Then
                '    dtReporte.RowFilter = "GastoViaje = 1"
                'ElseIf rbNoGastoViaje.Checked Then
                '    dtReporte.RowFilter = "GastoViaje = 0 And CodJob <>''"
                'End If

                If rbTodos.Checked And rbGVTodos.Checked Then
                    dtReporte.RowFilter = ""
                ElseIf rbTodos.Checked And rbSiGastoViaje.Checked Then
                    dtReporte.RowFilter = "GastoViaje = 1"
                ElseIf rbTodos.Checked And rbNoGastoViaje.Checked Then
                    dtReporte.RowFilter = "GastoViaje = 0"
                ElseIf rbSiProcJob.Checked And rbGVTodos.Checked Then
                    dtReporte.RowFilter = "ProcesoJob = 1"
                ElseIf rbSiProcJob.Checked And rbSiGastoViaje.Checked Then
                    dtReporte.RowFilter = "ProcesoJob = 1 and GastoViaje = 1"
                ElseIf rbSiProcJob.Checked And rbNoGastoViaje.Checked Then
                    dtReporte.RowFilter = "ProcesoJob = 1 and GastoViaje = 0"
                ElseIf rbNoProcJob.Checked And rbGVTodos.Checked Then
                    dtReporte.RowFilter = "ProcesoJob = 0 And CodJob <>''"
                ElseIf rbNoProcJob.Checked And rbSiGastoViaje.Checked Then
                    dtReporte.RowFilter = "ProcesoJob = 0 And CodJob <>'' and GastoViaje = 1"
                ElseIf rbNoProcJob.Checked And rbNoGastoViaje.Checked Then
                    dtReporte.RowFilter = "ProcesoJob = 0 and GastoViaje = 0 And CodJob <>''"
                End If

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbExcel.Checked Then

                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    Else

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If

                        forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Solicitud de Gastos Detallado"
                        reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                        reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                        reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                        reporte.SetParameterValue("Persona", IIf((txtPersona.Text = "(Todos)") Or (txtPersona.Text = "(TODOS)"), "(Todos)", txtPersona.Text))
                        reporte.SetParameterValue("Area", IIf(cmbCodArea.Text = "(Todos)", "(Todos)", cmbCodArea.Text))
                        reporte.SetParameterValue("Job", IIf(txtNumJob.Text = "", " -", txtNumJob.Text))
                        reporte.SetParameterValue("Moneda", IIf(cmbMoneda.Text = "", " -", cmbMoneda.Text))
                        reporte.SetParameterValue("CodCuenta", IIf(txtCodCuenta.Text = "", " -", txtCodCuenta.Text))
                        reporte.SetParameterValue("TipoDoc", IIf(cmbTipoDoc.Text = "", " -", cmbTipoDoc.Text))
                        reporte.SetParameterValue("TipoGasto", IIf(cmbTipoGasto.Text = "", " -", cmbTipoGasto.Text))
                        reporte.SetParameterValue("Documento", IIf(txtDocumento.Text = "", " -", txtDocumento.Text))
                        reporte.SetParameterValue("Descripcion", IIf(txtDescripcion.Text = "", " -", txtDescripcion.Text))
                        reporte.SetParameterValue("Estado", IIf(cmbEstado.Text = "(Todos)", "(Todos)", cmbEstado.Text))
                        reporte.SetParameterValue("ProcesoJob", IIf(rbNoProcJob.Checked, "No", IIf(rbSiProcJob.Checked, "Si", "(Todos)")))
                        reporte.SetParameterValue("GastoViaje", IIf(rbNoGastoViaje.Checked, "No", IIf(rbSiGastoViaje.Checked, "Si", "(Todos)")))
                        reporte.SetParameterValue("RubroViaje", IIf(rbSiGastoViaje.Checked, cmbRubroViaje.Text, ""))
                        reporte.SetParameterValue("Reporte", "REPORTE DE SOLICITUD DE GASTOS DETALLADO")
                        reporte.SetParameterValue("Placa", IIf(cmbPlaca.Text = "", " -", cmbPlaca.Text))
                        forma.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    
    Private Sub MostrarReporteTotalizado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptSolGastoTotalizado

            If txtProveedor.Text = "(Todos)" Then
                IdProveedor = 0
            End If

            dtReporte = oSolicitudGastoService.ReporteSolicitudGasto(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, cmbMoneda.Value, cmbCodArea.Value, utils.toNumber(cmbEstado.Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Solicitud de Gasto Totalizado"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Area", IIf(cmbCodArea.Text = "(Todos)", "(Todos)", cmbCodArea.Text))
                    reporte.SetParameterValue("Moneda", IIf(cmbMoneda.Text = "", " -", cmbMoneda.Text))
                    reporte.SetParameterValue("Estado", IIf(cmbEstado.Text = "(Todos)", "(Todos)", cmbEstado.Text))
                    reporte.SetParameterValue("Reporte", "REPORTE DE SOLICITUD DE GASTOS TOTALIZADO")
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub rbBuscarPersona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarPersona.CheckedChanged
        If rbBuscarPersona.Checked = True Then
            txtPersona.Text = "(Todos)"
            IdPersona = 0
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtPersona.Text = frm.descripcion
                    IdPersona = frm.codigo
                    rbBuscarPersona.Checked = False
                Else
                    txtPersona.Text = "(Todos)"
                    IdPersona = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbSiGastoViaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSiGastoViaje.CheckedChanged, rbGVTodos.CheckedChanged, rbNoGastoViaje.CheckedChanged
        If rbSiGastoViaje.Checked Then
            cmbRubroViaje.Enabled = True
            cmbRubroViaje.SelectedIndex = 0

        ElseIf rbGVTodos.Checked Then
            cmbRubroViaje.Enabled = False
            cmbRubroViaje.SelectedIndex = -1
            cmbRubroViaje.Value = 0
        ElseIf rbNoGastoViaje.Checked Then
            cmbRubroViaje.Enabled = False
            cmbRubroViaje.SelectedIndex = -1
            cmbRubroViaje.Value = 0
        End If
    End Sub
End Class