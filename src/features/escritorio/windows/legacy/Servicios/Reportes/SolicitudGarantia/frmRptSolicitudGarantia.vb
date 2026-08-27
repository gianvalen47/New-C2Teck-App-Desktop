Imports System.ServiceModel

Public Class frmRptSolicitudGarantia

    Private oSolicitudGarantia As New SolicitudGarantiaService.SolicitudGarantiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private dtSupervisor As DataTable
    Private dtEstados As DataTable
    Private dtFabricante As DataTable
    Private dtAplicacion As DataTable

    Private IdCliente As Integer
    Private IdSupervisor As Integer
    Private IdAplicacion As Integer
    Private IdFabricante As Integer
    Private IdEstado As Integer

    Dim dtReporte As DataTable

    Private Sub frmRptSolicitudGarantia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGarantia.Close()
            oMaestroService.Close()
            oCotizacionService.Close()
            oJobService.Close()
            oSeguridadService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantia.Abort()
            oMaestroService.Abort()
            oCotizacionService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantia.Abort()
            oMaestroService.Abort()
            oCotizacionService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub frmRptSolicitudGarantia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRptSolicitudGarantia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 164)
        '/*************************************************************************************/

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        txtCliente.Text = "(Todos)"
        rbGerencial.Checked = True
        llenarCombos()

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

    Private Sub llenarCombos()
        Try
            '======================================== SUPERVISOR ================================================            
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

            '======================================= ESTADOS ================================================
            dtEstados = oSolicitudGarantia.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            '------------------------------ Fabricante --------------------------------------------------
            dtFabricante = oCotizacionService.MostrarFabricante.Tables(0)
            dtFabricante.Rows.InsertAt(getRowTodos(dtFabricante), 0)
            cmbFabricante.DataSource = dtFabricante
            cmbFabricante.DropDownList.DataMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.DropDownList.DisplayMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.DropDownList.ValueMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(0).DataMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(1).DataMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.SelectedIndex = 0
            dtFabricante = Nothing

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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Try
            Dim frm As New frmBuscarMercaderia
            frm.CodRub = "04"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtSerie.Text = frm.codigo
            End If
            txtSerie.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If validarData() = True Then
                oSeguridadService.RegistrarVisitaOpciones(164, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If rbGerencial.Checked Then
                    ReporteGerencial()
                ElseIf rbDetallado.Checked Then
                    ReporteDetallado()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub ReporteGerencial()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptSolicitudGarantiaGerencial

            If txtCliente.Text = "(Todos)" Then
                IdCliente = 0
            End If

            dtReporte = oSolicitudGarantia.ReporteSolicitudGarantia(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbSupervisor.Value, 0, "", cmbFabricante.Value, "", txtCreditState.Text, txtNumClaim.Text.ToString, 2, "", "").Tables(0)
            'dtReporte = oSolicitudGarantia.ReporteSolicitudGarantia(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbSupervisor.Value, cmbEstado.Value, cmbAplicacion.Value, cmbFabricante.Value, txtSerie.Text, txtCreditState.Text, 2).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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
                forma.Text = "Reporte de Solicitud Garantia"
                reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Cliente", IIf((txtCliente.Text = "(Todos)"), "(Todos)", txtCliente.Text))
                reporte.SetParameterValue("Supervisor", IIf((cmbSupervisor.Text = "(Todos)"), "(Todos)", cmbSupervisor.Text))
                reporte.SetParameterValue("Fabricante", IIf((cmbFabricante.Text = "(Todos)"), "(Todos)", cmbFabricante.Text))
                reporte.SetParameterValue("CreditState", IIf((txtCreditState.Text = ""), " -", txtSerie.Text))
                reporte.SetParameterValue("NumClaim", IIf((txtNumClaim.Text = ""), " -", txtNumClaim.Text))
                'reporte.SetParameterValue("DesCorrecion", IIf((txtDesCorreccion.Text = ""), " -", txtDesCorreccion.Text))
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub ReporteDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptSolicitudGarantia

            If txtCliente.Text = "(Todos)" Then
                IdCliente = 0
            End If

            dtReporte = oSolicitudGarantia.ReporteSolicitudGarantia(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbSupervisor.Value, cmbEstado.Value, cmbAplicacion.Value, cmbFabricante.Value, txtSerie.Text, txtCreditState.Text, txtNumClaim.Text.ToString, 1, txtDesCorreccion.Text, txtCodPiezaPrim.text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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
                forma.Text = "Reporte de Solicitud Garantia"
                reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Cliente", IIf((txtCliente.Text = "(Todos)"), "(Todos)", txtCliente.Text))
                reporte.SetParameterValue("Supervisor", IIf((cmbSupervisor.Text = "(Todos)"), "(Todos)", cmbSupervisor.Text))
                reporte.SetParameterValue("Estado", IIf((cmbEstado.Text = "(Todos)"), "(Todos)", cmbEstado.Text))
                reporte.SetParameterValue("Aplicacion", IIf((cmbAplicacion.Text = "(Todos)"), "(Todos)", cmbAplicacion.Text))
                reporte.SetParameterValue("Serie", IIf((txtSerie.Text = ""), " -", txtSerie.Text))
                reporte.SetParameterValue("Fabricante", IIf((cmbFabricante.Text = "(Todos)"), "(Todos)", cmbFabricante.Text))
                reporte.SetParameterValue("CreditState", IIf((txtCreditState.Text = ""), " -", txtSerie.Text))
                reporte.SetParameterValue("NumClaim", IIf((txtNumClaim.Text = ""), " -", txtNumClaim.Text))
                reporte.SetParameterValue("DesCorreccion", IIf((txtDesCorreccion.Text = ""), " -", txtDesCorreccion.Text))
                reporte.SetParameterValue("CodPiezaPrim", IIf((txtCodPiezaPrim.Text = ""), " -", txtCodPiezaPrim.Text))
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        Else
            chkCliente.Enabled = True
        End If
    End Sub

    Private Sub rbGerencial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGerencial.CheckedChanged
        If rbGerencial.Checked = True Then
            cmbEstado.Enabled = False
            cmbAplicacion.Enabled = False
            txtSerie.Enabled = False
            btnBuscarMercaderia.Enabled = False
            txtDesCorreccion.Enabled = False
            txtCodPiezaPrim.Enabled = False
        End If
    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked = True Then
            cmbEstado.Enabled = True
            cmbAplicacion.Enabled = True
            txtSerie.Enabled = True
            btnBuscarMercaderia.Enabled = True
            txtDesCorreccion.Enabled = True
            txtCodPiezaPrim.Enabled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
