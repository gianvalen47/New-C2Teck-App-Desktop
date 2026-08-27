Imports System.ServiceModel

Public Class frmJobConsulta_Nuevo

    Private oJobService As New JobService.JobServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient   
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oJobDetalleService As New JobDetalleService.JobDetalleServiceClient


    Private dtOficinas As DataTable
    Private dtTipo As DataTable
    Private dtTipoMantenimiento As DataTable
    Private dtMonedas As DataTable
    Private dtLocal As DataTable
    Private dtSupervisor As DataTable
    Private dtEstados As DataTable
    Private dtUbicacion As DataTable
    Private dtAplicacion As DataTable
    Private IdSolicitante As Integer
    Private IdBeneficiado As Integer

    Public CodJob As String
    Public Actualizar As Boolean
    Public Anio As Integer

    Private dtCotizaciones As DataTable
    Private dtFacturacion As DataTable
    Private dtFabricante As DataTable

    Private dtDatos As DataTable                  '------------- Agregado el 21/03/2013 Detalles de Job -------------

    Private Sub frmJobConsulta_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oCotizacionServicioService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oGastoRealService.Close()
            oJobDetalleService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oCotizacionServicioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oGastoRealService.Abort()
            oJobDetalleService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oCotizacionServicioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oGastoRealService.Abort()
            oJobDetalleService.Abort()
        End Try
    End Sub

    Private Sub frmJobConsulta_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJobConsulta_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvCotAsignadas)
        estilo.cargaEstiloGridExtAlternating(dgvDocFacturacion)
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        ObtenerRegistro()
        Desactivar()

        listaDatos()
        listaCotizaciones()
        listaFacturacion()
        cmbOficinas.Focus()
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================== OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '========================================== TIPO ==================================================
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

            '=================================== TIPO MANTENIMIENTO ===========================================

            dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            'cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= SUPERVISOR =============================================
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("AbrPer").ToString
            'cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            '======================================= LUGAR A REALIZAR=========================================
            dtLocal = New DataTable
            dtLocal.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtLocal.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            dtLocal.Rows.Add(New Object() {"1", "Interno"})
            dtLocal.Rows.Add(New Object() {"2", "Externo"})

            cmbTipo.DataSource = dtLocal
            cmbTipo.DropDownList.DataMember = dtLocal.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtLocal.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtLocal.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtLocal.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtLocal.Columns("nombre").ToString

            '============================================ APLICACIÓN ==========================================
            dtAplicacion = oJobService.MostrarAplicacionMotor.Tables(0)
            dtAplicacion.Rows.InsertAt(getRowTodos(dtAplicacion), 0)
            cmbAplicacion.DataSource = dtAplicacion
            cmbAplicacion.DropDownList.DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.DisplayMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.ValueMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(0).DataMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(1).DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            dtAplicacion = Nothing

            '============================================== UBICACIÓN ========================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("AbrUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("AbrUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("AbrUbicacion").ToString
            dtUbicacion = Nothing

            '============================================== FABRICANTE =======================================
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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        'Try
        '    fila(1) = ""
        'Catch ex As Exception
        '    fila(2) = ""
        'End Try
        Return fila
    End Function

    Private Sub listaDatos()
        Try
            dtDatos = oJobDetalleService.Mostrar(txtNumJob.Text).Tables(0)
            dgvDatos.DataSource = dtDatos
            Dim registro As New JobService.Job
            registro = oJobService.Obtener(txtNumJob.Text)

            lblMontoVenta.Text = "(Montos no incluyen Igv)  TOTAL MONTO VENTA:" & " " & registro.Moneda.CodMon
            lblMontoCosto.Text = "TOTAL MONTO COSTO:" & " " & registro.Moneda.CodMon

            txtMontoVenta.Value = registro.TotVentaCot
            txtMontoCosto.Value = registro.TotBrutoCosto
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As JobService.Job

            registro = oJobService.Obtener(CodJob)

            txtNumJob.Text = registro.CodJob
            If oJobService.Regularizar(txtNumJob.Text) = True Then
                lblRegularizar.Visible = True
                lblRegularizar.Text = "El Job esta Activado Temporalmente por el Administrador para ser Regularizado"
            Else
                lblRegularizar.Visible = False
            End If
            cmbOficinas.Value = registro.Oficina.CodOfi
            If registro.Tipo = 1 Then
                cmbTipo.Value = 1
                cmbTipo.Text = "Interno"
            ElseIf registro.Tipo = 2 Then
                cmbTipo.Value = 2
                cmbTipo.Text = "Externo"
            End If
            txtNumSolicitud.Text = registro.SolicitudJob.IdSolicitud
            CmbTipoJob.Value = registro.TipoJob.IdTipoJob
            lblAsterisco.Visible = True
            lblLeyenda.Visible = True
            If CmbTipoJob.Value = 2 Then
                lblLeyenda.Text = " Precio de Venta, Incluido el Descuento."
            Else
                lblLeyenda.Text = " Costos."
            End If         
            cmbFabricante.Value = registro.Fabricante.IdFabricante
            IdSolicitante = registro.ClienteSolicita.IdCliente
            txtSolicitante.Text = registro.ClienteSolicita.DesCli
            IdBeneficiado = registro.ClienteBeneficiado.IdCliente
            txtBeneficiario.Text = registro.ClienteBeneficiado.DesCli
            cmbMantenimiento.Value = registro.TipoMantenimiento.CodMantenimiento
            cbKit.Checked = registro.Repower
            txtCodMer.Text = registro.CodMer
            txtModMer.Text = registro.ModMer
            cbNoFacturar.Checked = registro.Facturar
            cmbAplicacion.Value = registro.TipoAplicacionMotor.CodAplicacion
            cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion
            txtDescripcion.Text = registro.Observacion
            txtFecInicio.Value = registro.FecInicio
            txtFecFin.Value = registro.FecFinal
            cmbCodMon.Value = registro.Moneda.CodMon
            txtNroClaim.Text = registro.NroClaim
            txtCreditState.Text = registro.CreditState
            cmbSupervisor.Value = registro.PersonaDelegado.IdPer

            txtFecLiqAdm.Text = utils.toNull(registro.FecLiquidacionAdmin.ToString)

            lblEstado.Text = registro.EstadoJob.DesEstado
            If lblEstado.Text Is Nothing Or lblEstado.Text = "" Then
                lblEstado.Visible = False
            Else
                lblEstado.Visible = True
            End If

            If Not (registro.FecLlegada.ToString = "") Then
                txtFecLlegada.Value = CDate(registro.FecLlegada)
                txtFecLlegada.Text = registro.FecLlegada.ToString
            End If

            txtFecIniRep.Text = utils.toNull(registro.FecIniRep.ToString)
            txtFecFinRep.Text = utils.toNull(registro.FecFinRep.ToString)

            If Not (registro.FecEntrega.ToString = "") Then
                txtFecEntrega.Value = CDate(registro.FecEntrega)
                txtFecEntrega.Text = registro.FecEntrega.ToString
            End If

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub Desactivar()

        txtNumJob.ReadOnly = True ' ------------------------------borrar
        cmbOficinas.ReadOnly = True
        cmbOficinas.BackColor = System.Drawing.SystemColors.Control
        cmbFabricante.ReadOnly = True
        cmbFabricante.BackColor = System.Drawing.SystemColors.Control
        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control
        CmbTipoJob.ReadOnly = True
        CmbTipoJob.BackColor = System.Drawing.SystemColors.Control
        cmbMantenimiento.ReadOnly = True
        cmbMantenimiento.BackColor = System.Drawing.SystemColors.Control
        cbKit.Enabled = False
        cbNoFacturar.Enabled = False
        cmbAplicacion.ReadOnly = True
        cmbAplicacion.BackColor = System.Drawing.SystemColors.Control
        txtModMer.ReadOnly = True
        txtCodMer.ReadOnly = True
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        txtNumSolicitud.ReadOnly = True
        txtSolicitante.ReadOnly = True
        txtBeneficiario.ReadOnly = True
        txtFecInicio.ReadOnly = True
        txtFecInicio.BackColor = System.Drawing.SystemColors.Control
        txtFecFin.ReadOnly = True
        txtFecFin.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        'txtTotRepuesto.ReadOnly = True
        'txtTotDescuento.ReadOnly = True
        'txtTotManoObra.ReadOnly = True
        'txtTotTerceros.ReadOnly = True
        'txtTotViaticos.ReadOnly = True
        'txtTotMateriales.ReadOnly = True
        'txtTotVarios.ReadOnly = True
        'txtRepower.ReadOnly = True
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        If CmbTipoJob.Value = 3 Then
            txtNroClaim.ReadOnly = True
            txtCreditState.ReadOnly = True
            txtNroClaim.Visible = True
            txtCreditState.Visible = True
            lblNroClaim.Visible = True
            lblCreditState.Visible = True
        Else
            txtNroClaim.Visible = False
            txtCreditState.Visible = False
            lblNroClaim.Visible = False
            lblCreditState.Visible = False
        End If
        cmbSupervisor.ReadOnly = True
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
        '---------------------------------------
        'btnGuardar.Enabled = False
    End Sub

    Private Sub listaCotizaciones()
        Try
            dtCotizaciones = oJobService.MostrarCotizacionAsignada(Trim(txtNumJob.Text)).Tables(0)
            dgvCotAsignadas.DataSource = dtCotizaciones
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR COTIZACIONES ASIGNADAS : " + ex.Message)
        End Try
    End Sub

    Private Sub listaFacturacion()
        Try
            dtFacturacion = oJobService.MostrarFacturacion(Trim(txtNumJob.Text)).Tables(0)
            dgvDocFacturacion.DataSource = dtFacturacion
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DOCUMENTOS DE FACTURACION : " + ex.Message)
        End Try
    End Sub

    'Private Sub btnRepuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_Repuestos
    '    'If CodJob <> "" Then
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "6"
    '    frm.CodMon = cmbCodMon.Value
    '    frm.ShowDialog()

    'End Sub

    'Private Sub btnManoObra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJobConsulta_Mostrar_ManoObra
    '    'If CodJob <> "" Then
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "1"
    '    frm.CodMon = cmbCodMon.Value
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnTerceros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_Terceros
    '    'If CodJob <> "" Then
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "2"
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnGastosViaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_GastosViaje
    '    'If CodJob <> "" Then
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "3"
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmJob_Mostrar_Materiales
    '        Dim dtMateriales As DataTable
    '        frm.CodJob = CodJob
    '        frm.CodRubro = "4"
    '        frm.CodMon = cmbCodMon.Value
    '        frm.Anio = Anio

    '        dtMateriales = oGastoRealService.Filtrar(Anio, CodJob, "4", 0, "", "", "").Tables(0)

    '        If dtMateriales.Rows.Count > 0 Then
    '            frm.MostrarMat = True
    '        Else : frm.MostrarMat = False
    '        End If

    '        frm.ShowDialog()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MOSTRAR LOS MATERIALES " + ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnVarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_Varios
    '    'If CodJob <> "" Then
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "5"
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnRefrigMov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_RefrigMovil
    '    'If CodJob <> "" Then
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "7"
    '    frm.ShowDialog()
    'End Sub

    Private Sub btnVerRepuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerRepuestos.Click
        Try
            Dim frm2 As New frmJobConsulta_ListadoRepuestos
            frm2.CodJob = CodJob
            frm2.DesCli = txtSolicitante.Text
            frm2.ModMer = txtModMer.Text
            'frm2.ShowDialog()

            If frm2.ShowDialog = Windows.Forms.DialogResult.OK Then
                'frm2.CodJob = CodJob
                'frm2.DesCli = txtSolicitante.Text
                'frm2.ModMer = txtModMer.Text
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJobConsultaDetalle

            dtReporte = oJobDetalleService.Mostrar(txtNumJob.Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                'forma.crvReportes.DisplayGroupTree = False

                Dim registro As New JobService.Job
                registro = oJobService.Obtener(txtNumJob.Text)

                reporte.SetParameterValue("pDesEmp", registro.Empresa.DesEmp)
                reporte.SetParameterValue("pRuc", registro.Empresa.RucEmp)
                reporte.SetParameterValue("pRealizar", cmbTipo.Text)
                reporte.SetParameterValue("pSupervisor", cmbSupervisor.Text)
                reporte.SetParameterValue("pDescripcion", txtDescripcion.Text)
                reporte.SetParameterValue("pSolicitud", txtNumSolicitud.Text)
                reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                reporte.SetParameterValue("pMantenimiento", cmbMantenimiento.Text)
                reporte.SetParameterValue("pFecFin", txtFecFin.Value)
                reporte.SetParameterValue("pOficina", cmbOficinas.Text)
                reporte.SetParameterValue("pTipoJob", CmbTipoJob.Text)
                reporte.SetParameterValue("pCulminacion", txtFecFinRep.Text)
                reporte.SetParameterValue("pLiquidacion", txtFecLiqAdm.Text)
                reporte.SetParameterValue("pSolicitante", registro.ClienteSolicita.DesCli)
                reporte.SetParameterValue("pBeneficiario", registro.ClienteBeneficiado.DesCli)
                reporte.SetParameterValue("pSerie", txtCodMer.Text)
                reporte.SetParameterValue("pModelo", txtModMer.Text)
                reporte.SetParameterValue("pAplicacion", cmbAplicacion.Text)
                reporte.SetParameterValue("pUbicacion", cmbUbicacion.Text)
                reporte.SetParameterValue("pTotalMontoVenta", registro.TotVentaCot)
                reporte.SetParameterValue("pTotalMontoCosto", registro.TotBrutoCosto)
                reporte.SetParameterValue("pMoneda", cmbCodMon.Value)
                forma.Text = "Reporte de Job"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Mostrar" Then
                Dim IdRubro As Integer
                IdRubro = toNumber(dgvDatos.CurrentRow.Cells("IdRubro").Value)

                '======================= REPUESTOS ==========================
                If IdRubro = 1 Then
                    Dim frm As New frmJob_Mostrar_Repuestos
                    'If CodJob <> "" Then
                    frm.CodJob = CodJob
                    frm.CodRubro = "6"
                    frm.CodMon = cmbCodMon.Value
                    frm.ShowDialog()

                    '==================== MANO DE OBRA ========================
                ElseIf IdRubro = 2 Then
                    Dim frm As New frmJobConsulta_Mostrar_ManoObra
                    'If CodJob <> "" Then
                    frm.CodJob = CodJob
                    frm.CodRubro = "1"
                    frm.CodMon = cmbCodMon.Value
                    frm.ShowDialog()

                    '===================== MATERIALES =========================
                ElseIf IdRubro = 3 Then
                    Try
                        Dim frm As New frmJob_Mostrar_Materiales
                        Dim dtMateriales As DataTable
                        frm.CodJob = CodJob
                        frm.CodRubro = "4"
                        frm.CodMon = cmbCodMon.Value
                        frm.Anio = Anio

                        dtMateriales = oGastoRealService.Filtrar(Anio, CodJob, "4", 0, "", "", "", 0).Tables(0)

                        If dtMateriales.Rows.Count > 0 Then
                            frm.MostrarMat = True
                        Else : frm.MostrarMat = False
                        End If
                        frm.ShowDialog()
                    Catch ex As Exception
                        MsgBox("ERROR AL MOSTRAR LOS MATERIALES " + ex.Message)
                    End Try

                    '================ TRABAJO DE TERCEROS ====================
                ElseIf IdRubro = 4 Then
                    Dim frm As New frmJob_Mostrar_Terceros
                    'If CodJob <> "" Then
                    frm.CodJob = CodJob
                    frm.CodRubro = "2"
                    frm.btnActRubro.Visible = False
                    frm.ShowDialog()

                    '=================== GASTOS DE VIAJE =======================
                ElseIf IdRubro = 5 Then
                    Dim frm As New frmJob_Mostrar_GastosViaje
                    'If CodJob <> "" Then
                    frm.CodJob = CodJob
                    frm.CodRubro = "3"
                    frm.ShowDialog()

                    '======================= VARIOS ===========================
                ElseIf IdRubro = 6 Then
                    Dim frm As New frmJob_Mostrar_Varios
                    'If CodJob <> "" Then
                    frm.CodJob = CodJob
                    frm.CodRubro = "5"
                    frm.btnActRubro.Visible = False
                    frm.ShowDialog()

                    '===================== REF. Y MOV. =========================
                ElseIf IdRubro = 8 Then
                    Dim frm As New frmJob_Mostrar_RefrigMovil
                    'If CodJob <> "" Then
                    frm.CodJob = CodJob
                    frm.CodRubro = "7"
                    frm.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar Detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class