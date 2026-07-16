Imports System.ServiceModel

Public Class frmRepJob

    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Dim dtReporte As DataTable
    Private dtSupervisor As DataTable
    Private dtOficinas As DataTable
    Private dtDatos As DataTable
    Private dtTipo As DataTable
    Private dtEstado As DataTable
    Private dtAplicacion As DataTable
    Private dtUbicacion As DataTable
    Private dtFabricante As DataTable
    Private dtTipoMantenimiento As DataTable
    Private IdClienteSolicitante As String
    Private IdClienteBeneficiado As String
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private Sub frmRepJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionServicioService.Close()
            oMaestroService.Close()
            oCotizacionServicioService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 174)
        '/*************************************************************************************/

        ' Validar Usuario - Exportar Excel
        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
            rbExportExcel.Enabled = True
        Else
            rbExportExcel.Enabled = False
        End If

        cbFecInicio.Value = "01/" & Today.Month & "/" & Today.Year
        cbFecFinal.Value = Today.Date
        rbPantalla.Checked = True
        rbMonCot.Checked = True
        IdClienteSolicitante = 0
        IdClienteBeneficiado = 0
        cmbOficinas.Focus()
        llenarCombos()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try
            '------------------------------- Supervisor --------------------------------------------
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            '------------------------------- Oficinas --------------------------------------------
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= TIPO ================================================
            dtTipo = oJobService.MostrarTipo.Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            CmbTipoJob.DataSource = dtTipo
            CmbTipoJob.DropDownList.DataMember = dtTipo.Columns("AbrTipo").ToString
            CmbTipoJob.DropDownList.DisplayMember = dtTipo.Columns("AbrTipo").ToString
            CmbTipoJob.DropDownList.ValueMember = dtTipo.Columns("IdTipoJob").ToString
            CmbTipoJob.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipoJob").ToString
            CmbTipoJob.DropDownList.Columns(1).DataMember = dtTipo.Columns("AbrTipo").ToString
            CmbTipoJob.SelectedIndex = 0
            dtTipo = Nothing

            '======================================= ESTADOS ================================================
            dtEstado = oJobService.MostrarEstados.Tables(0)
            dtEstado.Rows.InsertAt(getRowTodos(dtEstado), 0)
            cmbEstados.DataSource = dtEstado
            cmbEstados.DropDownList.DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstado.Columns("DesEstado").ToString
            cmbEstados.DropDownList.ValueMember = dtEstado.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstado.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstados.SelectedIndex = 0
            dtEstado = Nothing

            '------------------------------ Aplicacion --------------------------------------------------
            dtAplicacion = oJobService.MostrarAplicacionMotor.Tables(0)
            dtAplicacion.Rows.InsertAt(getRowTodos(dtAplicacion), 0)
            cmbAplicacion.DataSource = dtAplicacion
            cmbAplicacion.DropDownList.DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.DisplayMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.ValueMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(0).DataMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(1).DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.SelectedIndex = 0
            dtAplicacion = Nothing

            '------------------------------ Ubicacion --------------------------------------------------
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '------------------------------ Fabricante --------------------------------------------------
            dtFabricante = oCotizacionServicioService.MostrarFabricante.Tables(0)
            dtFabricante.Rows.InsertAt(getRowTodos(dtFabricante), 0)
            cmbFabricante.DataSource = dtFabricante
            cmbFabricante.DropDownList.DataMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.DropDownList.DisplayMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.DropDownList.ValueMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(0).DataMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(1).DataMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.SelectedIndex = 0
            dtFabricante = Nothing

            '======================================= TIPO MANTENIMIENTO ================================================

            dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.Columns(2).DataMember = dtAreas.Columns("DesUnidad").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validarData() = True Then
            oSeguridadService.RegistrarVisitaOpciones(174, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbMonCot.Checked = True Then
                MostrarReporteMontosCotizados()
            Else
                MostrarReporteGastosIncurridos()
            End If
        End If
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

    Private Sub MostrarReporteMontosCotizados()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJobMonCot

            If txtClienteSolicitante.Text = "(Todos)" Then
                IdClienteSolicitante = "0"
            End If

            If txtClienteBeneficiado.Text = "(Todos)" Then
                IdClienteBeneficiado = "0"
            End If

            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            dtReporte = oJobService.ReporteJob(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbEstados.Value), cmbOficinas.Value, utils.toNumber(CmbTipoJob.Value), IdClienteSolicitante, IdClienteBeneficiado, txtSerie.Text, utils.toNumber(cmbSupervisor.Value), cmbUbicacion.Value, cmbMantenimiento.Value, utils.toNumber(cmbFabricante.Value), cmbAplicacion.Value, IIf(rbAperturaJob.Checked, 1, 2), cmbCodArea.Value, cmbCentroCosto.Value).Tables(0)
            'DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    Dim Export As Boolean
                    Dim dataset1 As DataSet
                    dataset1 = oJobService.ReporteJob(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbEstados.Value), cmbOficinas.Value, utils.toNumber(CmbTipoJob.Value), IdClienteSolicitante, IdClienteBeneficiado, txtSerie.Text, utils.toNumber(cmbSupervisor.Value), cmbUbicacion.Value, cmbMantenimiento.Value, utils.toNumber(cmbFabricante.Value), cmbAplicacion.Value, IIf(rbAperturaJob.Checked, 1, 2), cmbCodArea.Value, cmbCentroCosto.Value)

                    dataset1.Tables(0).Columns.Remove("CodEmp")
                    dataset1.Tables(0).Columns.Remove("RucEmp")
                    dataset1.Tables(0).Columns.Remove("DesEmp")
                    dataset1.Tables(0).Columns.Remove("TotCostoVenRepuestos")
                    dataset1.Tables(0).Columns.Remove("DesCentro")
                    dataset1.Tables(0).Columns.Remove("AbrTipo")
                    dataset1.Tables(0).Columns.Remove("IdTipoJob")
                    dataset1.Tables(0).Columns.Remove("Estado")
                    dataset1.Tables(0).Columns.Remove("MonedaCotizacion")
                    dataset1.Tables(0).Columns.Remove("MonedaCosto")


                    DataGridView1.DataSource = dataset1.Tables(0)
                    Export = ExportarExcel(DataGridView1)

                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If

                ElseIf rbPantalla.Checked Then

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Ventas Detalle"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Oficina", IIf(cmbOficinas.Text = "(Todos)", "(Todos)", cmbOficinas.Text))
                    reporte.SetParameterValue("TipoJob", IIf(CmbTipoJob.Text = "(Todos)", "(Todos)", CmbTipoJob.Text))
                    reporte.SetParameterValue("Estados", IIf(cmbEstados.Text = "(Todos)", "(Todos)", cmbEstados.Text))
                    reporte.SetParameterValue("Fabricante", IIf(cmbFabricante.Text = "(Todos)", "(Todos)", cmbFabricante.Text))
                    reporte.SetParameterValue("Mantenimiento", IIf(cmbMantenimiento.Text = "(Todos)", "(Todos)", cmbMantenimiento.Text))
                    reporte.SetParameterValue("Aplicacion", IIf(cmbAplicacion.Text = "(Todos)", "(Todos)", cmbAplicacion.Text))
                    reporte.SetParameterValue("Ubicacion", IIf(cmbUbicacion.Text = "(Todos)", "(Todos)", cmbUbicacion.Text))
                    reporte.SetParameterValue("Supervisor", IIf(cmbSupervisor.Text = "(Todos)", "(Todos)", cmbSupervisor.Text))
                    reporte.SetParameterValue("Serie", IIf(txtSerie.Text = "", " -", txtSerie.Text))
                    reporte.SetParameterValue("ClienteSol", IIf(txtClienteSolicitante.Text = "", " -", txtClienteSolicitante.Text))
                    reporte.SetParameterValue("ClienteBen", IIf(txtClienteBeneficiado.Text = "", " -", txtClienteBeneficiado.Text))
                    reporte.SetParameterValue("TipoReporte", IIf(rbAperturaJob.Checked, "(Por Apertura)", "(Por Liquidación)"))

                    forma.ShowDialog()
                End If
                'Me.DataGridView1.DataSource = dtReporte
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub MostrarReporteGastosIncurridos()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJobGastosInc

            If txtClienteSolicitante.Text = "(Todos)" Then
                IdClienteSolicitante = "0"
            End If

            If txtClienteBeneficiado.Text = "(Todos)" Then
                IdClienteBeneficiado = "0"
            End If

            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            dtReporte = oJobService.ReporteJob(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbEstados.Value), cmbOficinas.Value, utils.toNumber(CmbTipoJob.Value), IdClienteSolicitante, IdClienteBeneficiado, txtSerie.Text, utils.toNumber(cmbSupervisor.Value), cmbUbicacion.Value, cmbMantenimiento.Value, utils.toNumber(cmbFabricante.Value), cmbAplicacion.Value, IIf(rbAperturaJob.Checked, 1, 2), cmbCodArea.Value, cmbCentroCosto.Value).Tables(0)
            'DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    Dim Export As Boolean
                    Dim dataset1 As DataSet
                    dataset1 = oJobService.ReporteJob(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbEstados.Value), cmbOficinas.Value, utils.toNumber(CmbTipoJob.Value), IdClienteSolicitante, IdClienteBeneficiado, txtSerie.Text, utils.toNumber(cmbSupervisor.Value), cmbUbicacion.Value, cmbMantenimiento.Value, utils.toNumber(cmbFabricante.Value), cmbAplicacion.Value, IIf(rbAperturaJob.Checked, 1, 2), cmbCodArea.Value, cmbCentroCosto.Value)

                    dataset1.Tables(0).Columns.Remove("CodEmp")
                    dataset1.Tables(0).Columns.Remove("RucEmp")
                    dataset1.Tables(0).Columns.Remove("DesEmp")
                    dataset1.Tables(0).Columns.Remove("TotCostoVenRepuestos")
                    dataset1.Tables(0).Columns.Remove("DesCentro")
                    dataset1.Tables(0).Columns.Remove("AbrTipo")
                    dataset1.Tables(0).Columns.Remove("IdTipoJob")
                    dataset1.Tables(0).Columns.Remove("Estado")
                    dataset1.Tables(0).Columns.Remove("MonedaCotizacion")
                    dataset1.Tables(0).Columns.Remove("MonedaCosto")

                    DataGridView1.DataSource = dataset1.Tables(0)
                    Export = ExportarExcel(DataGridView1)

                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Ventas Detalle"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Oficina", IIf(cmbOficinas.Text = "(Todos)", "(Todos)", cmbOficinas.Text))
                    reporte.SetParameterValue("TipoJob", IIf(CmbTipoJob.Text = "(Todos)", "(Todos)", CmbTipoJob.Text))
                    reporte.SetParameterValue("Estados", IIf(cmbEstados.Text = "(Todos)", "(Todos)", cmbEstados.Text))
                    reporte.SetParameterValue("Fabricante", IIf(cmbFabricante.Text = "(Todos)", "(Todos)", cmbFabricante.Text))
                    reporte.SetParameterValue("Mantenimiento", IIf(cmbMantenimiento.Text = "(Todos)", "(Todos)", cmbMantenimiento.Text))
                    reporte.SetParameterValue("Aplicacion", IIf(cmbAplicacion.Text = "(Todos)", "(Todos)", cmbAplicacion.Text))
                    reporte.SetParameterValue("Ubicacion", IIf(cmbUbicacion.Text = "(Todos)", "(Todos)", cmbUbicacion.Text))
                    reporte.SetParameterValue("Supervisor", IIf(cmbSupervisor.Text = "(Todos)", "(Todos)", cmbSupervisor.Text))
                    reporte.SetParameterValue("Serie", IIf(txtSerie.Text = "", " -", txtSerie.Text))
                    reporte.SetParameterValue("ClienteSol", IIf(txtClienteSolicitante.Text = "", " -", txtClienteSolicitante.Text))
                    reporte.SetParameterValue("ClienteBen", IIf(txtClienteBeneficiado.Text = "", " -", txtClienteBeneficiado.Text))
                    reporte.SetParameterValue("TipoReporte", IIf(rbAperturaJob.Checked, "(Por Apertura)", "(Por Liquidación)"))

                    forma.ShowDialog()
                End If
                'Me.DataGridView1.DataSource = dtReporte
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub btnBuscarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSolicitante.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkClienteSolicitante.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtClienteSolicitante.Text = frm.descripcion
                    IdClienteSolicitante = frm.codigo

                Else
                    txtClienteSolicitante.Text = "(Todos)"
                    IdClienteSolicitante = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarBeneficiado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarBeneficiado.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkClienteBeneficiado.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtClienteBeneficiado.Text = frm.descripcion
                    IdClienteBeneficiado = frm.codigo

                Else
                    txtClienteBeneficiado.Text = "(Todos)"
                    IdClienteBeneficiado = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkClienteSolicitante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClienteSolicitante.CheckedChanged
        If txtClienteSolicitante.Text <> "(Todos)" Then
            chkClienteSolicitante.Enabled = False
            txtClienteSolicitante.Text = "(Todos)"
            IdClienteSolicitante = 0
        Else
            chkClienteSolicitante.Enabled = True
        End If
    End Sub

    Private Sub chkClienteBeneficiado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClienteBeneficiado.CheckedChanged
        If txtClienteBeneficiado.Text <> "(Todos)" Then
            chkClienteBeneficiado.Enabled = False
            txtClienteBeneficiado.Text = "(Todos)"
            IdClienteBeneficiado = 0
        Else
            chkClienteBeneficiado.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Try
            Dim frm As New frmBuscarMercaderia
            frm.CodRub = "04"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtSerie.Text = frm.codigo
                'txtDesMer.Text = frm.descripcion
                'txtModMer.Text = frm.ModMer
            End If
            txtSerie.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class