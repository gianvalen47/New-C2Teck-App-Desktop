Imports System.ServiceModel

Public Class frmRepActivoFijo

    '============================Servicios===================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================
    Dim dtReporte As DataTable
    Dim IdProveedor As String
    Dim IdPersona As String

    Private dtUbicacion As DataTable
    Private dtEstados As DataTable
    Private dtTipoActivo As DataTable

    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable



    Private Sub frmRepActivoFijo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oActivoFijoService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
        End Try
    End Sub

    Private Sub frmRepActivoFijo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepActivoFijo_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        llenarCombos()

        IdPersona = 0
        'cmbMoneda.Value = "NS"
        ''cmbPosesion.Value = 0
        ''cmbPosesion.Text = "(Todos)"
        'rbTotalizado.Checked = True

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'If validarData() = True Then
        '    'oSeguridadService.RegistrarVisitaOpciones(157, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        '    If rbDetallado.Checked Then
        '        MostrarReporteDetallado()
        '    ElseIf rbTotalizado.Checked Then
        '        MostrarReporteTotalizado()
        '    End If
        'End If

        ReporteActivoFijo()

    End Sub

    Private Sub ReporteActivoFijo()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptActivoFijo

            dtReporte = oActivoFijoService.Reporte(Session.sCodEmp, cmbCodArea.Value, cmbCentroCosto.Value, cmbUbicacion.Value, utils.toNumber(cmbTipoActivo.Value), IdPersona, cmbEstado.Value).Tables(0)
            'dtReporte = oActivoFijo.Reporte(Session.sCodEmp, cmbCodArea.Value, cmbCentroCosto.Value, IdProveedor, utils.toNumber(cmbEstado.Value), txtNumJob.Text, 2).Tables(0)

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
                forma.Text = "Reporte de Activo Fijos"
                'reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Colaborador", IIf((txtColaborador.Text = "(Todos)") Or (txtColaborador.Text = "(TODOS)"), "(Todos)", txtColaborador.Text))
                reporte.SetParameterValue("Area", IIf(cmbCodArea.Text = "(Todos)", "(Todos)", cmbCodArea.Text))
                reporte.SetParameterValue("CentroCosto", IIf(cmbCentroCosto.Text = "(Todos)", "(Todos)", cmbCentroCosto.Text))
                reporte.SetParameterValue("Ubicacion", IIf(cmbUbicacion.Text = "(Todos)", "(Todos)", cmbUbicacion.Text))
                reporte.SetParameterValue("Tipo", IIf(cmbTipoActivo.Text = "(Todos)", "(Todos)", cmbTipoActivo.Text))
                reporte.SetParameterValue("Estado", IIf(cmbEstado.Text = "(Todos)", "(Todos)", cmbEstado.Text))
                reporte.SetParameterValue("Reporte", "REPORTE DE ACTIVOS FIJOS")

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try
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
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing


            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oActivoFijoService.MostrarUbicacion().Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oActivoFijoService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            '===================================== TIPO ACTIVO ===============================================
            dtTipoActivo = oActivoFijoService.MostrarTipo().Tables(0)
            dtTipoActivo.Rows.InsertAt(getRowTodos(dtTipoActivo), 0)
            cmbTipoActivo.DataSource = dtTipoActivo
            cmbTipoActivo.DropDownList.DataMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.DropDownList.DisplayMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.DropDownList.ValueMember = dtTipoActivo.Columns("IdTipo").ToString
            cmbTipoActivo.DropDownList.Columns(0).DataMember = dtTipoActivo.Columns("IdTipo").ToString
            cmbTipoActivo.DropDownList.Columns(1).DataMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.SelectedIndex = 0
            dtTipoActivo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub cmbCodArea_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            'If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            'End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            'listaDatos()

            'If cmbCodArea.Value = "" Then
            '    lblUnidadNegocio.Text = ""
            'Else
            '    lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbBuscarPersona_CheckedChanged(sender As Object, e As EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
            'listaDatos()
        Else
            chkColaborador.Enabled = True
            'pboxLimpiarColaborador.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarColaborador_Click(sender As Object, e As EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class