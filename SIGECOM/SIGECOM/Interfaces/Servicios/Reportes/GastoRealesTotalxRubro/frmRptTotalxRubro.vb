Imports System.ServiceModel

Public Class frmRptTotalxRubro

    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private dtOficinas As DataTable
    Private dtTipo As New DataTable
    Private dtEstados As New DataTable
    Private dtRubro As New DataTable
    Private dtDatos As New DataTable
    Public IdCliente As Integer
    Public Cliente As String
    Private dtAreas As DataTable
    Private dtUnidades As DataTable
    Private dtCentroCosto As DataTable

    Private Sub frmRptTotalxRubro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oJobService.Close()
            oGastoRealService.Close()
            oSeguridadService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oJobService.Abort()
            oGastoRealService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oJobService.Abort()
            oGastoRealService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRptTotalxRubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRptTotalxRubro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 115)
        '/*************************************************************************************/

        ' Validar Usuario - Exportar Excel
        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
            rbExcel.Enabled = True
        Else
            rbExcel.Enabled = False
        End If

        llenarCombos()
        txtFechaInicio.Text = CDate("01/01/" + utils.toBlank(Year(Today)))
        txtFechaFin.Text = Today()

    End Sub

    Private Sub llenarCombos()
        Try
            '------------------------------- Oficinas --------------------------------------------
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbLocacion.DataSource = dtOficinas
            cmbLocacion.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 0

            '------------------------------- Rubros --------------------------------------------
            dtRubro = oGastoRealService.MostrarRubros.Tables(0)
            'dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0

            '------------------------------ Job --------------------------------------------------
            dtTipo = oJobService.MostrarTipo.Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipo.SelectedIndex = 0

            '------------------------------ Estados --------------------------------------------------
            dtEstados = oJobService.MostrarEstados.Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("AbrEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("AbrEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("AbrEstado").ToString
            cmbEstado.SelectedIndex = 0

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOS COMBOS :" + ex.Message)
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), Session.sCodUsu).Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ==========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            dtCentroCosto = Nothing

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
            fila(1) = "Todos"
        Catch ex As Exception

        End Try
        Try
            fila(2) = "Todos"
        Catch ex As Exception

        End Try
        Try
            fila(3) = "Todos"
        Catch ex As Exception

        End Try
        Try
            fila(4) = "Todos"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then
            txtCliente.Text = ""
            IdCliente = 0
        End If
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptTotalPorRubro

            oSeguridadService.RegistrarVisitaOpciones(115, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If utils.toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio")
            ElseIf utils.toBlank(txtFechaFin.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Termino")
            Else
                Dim Inicio As String
                Dim Final As String
                Dim Rubro As String
                Dim Tipo As String
                Dim Oficina As String
                Dim Estado As String
                Dim DesCli As String
                'Datos para el DataTable
                Dim CodRubro As String
                Dim CodOfi As String
                Dim CodCli As String
                Dim CodEstado As String
                Dim CodTipo As String

                Inicio = utils.toBlank(txtFechaInicio.Text)
                Final = utils.toBlank(txtFechaFin.Text)
                Rubro = cmbRubro.Text
                Tipo = cmbTipo.Text
                Oficina = cmbLocacion.Text
                Estado = cmbEstado.Text

                'Datos para el DataTable
                CodRubro = cmbRubro.Value.ToString
                CodOfi = cmbLocacion.Value.ToString
                CodCli = IdCliente
                CodEstado = cmbEstado.Value.ToString
                CodTipo = cmbTipo.Value.ToString

                If txtCliente.Text = "" Then
                    DesCli = "Todos"
                Else
                    DesCli = txtCliente.Text
                End If

                dtDatos = oGastoRealService.ReporteTotalPorRubro(utils.toBlank(Inicio), utils.toBlank(Final), CodRubro, CodOfi, utils.toNumber(CodCli), utils.toNumber(CodEstado), utils.toNumber(CodTipo), _
                                                                                            toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value)).Tables(0)

                If dtDatos.Rows.Count <= 0 Then
                    MsgBox("No hay Datos a mostrar en este reporte")
                Else
                    If rbExcel.Checked Then

                        DataGridView1.DataSource = dtDatos
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    Else

                        reporte.SetDataSource(dtDatos)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.crvReportes.DisplayGroupTree = False
                        reporte.SetParameterValue("pInicio", Inicio)
                        reporte.SetParameterValue("pFinal", Final)
                        reporte.SetParameterValue("pRubro", Rubro)
                        reporte.SetParameterValue("pTipo", Tipo)
                        reporte.SetParameterValue("pOficina", Oficina)
                        reporte.SetParameterValue("pEstado", Estado)
                        reporte.SetParameterValue("pDesCli", DesCli)
                        'reporte.SetParameterValue("pCodRubro", CodRubro)
                        'reporte.SetParameterValue("pCodOfi", CodOfi)
                        'reporte.SetParameterValue("pCodCli", CodCli)
                        'reporte.SetParameterValue("pCodEstado", CodEstado)
                        'reporte.SetParameterValue("pCodTipo", CodTipo)
                        reporte.SetParameterValue("pDesEmp", Session.sDesEmp)
                        reporte.SetParameterValue("pRucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))


                        forma.Text = "Reporte de Gastos Reales Totales x Rubro"

                        forma.ShowDialog()

                    End If
           
                End If

            End If

        Catch ex As Exception
            MsgBox("Error en el reporte : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                txtCliente.Text = frm.descripcion
                txtCliente.BackColor = System.Drawing.SystemColors.Control
                IdCliente = frm.codigo
                Cliente = frm.descripcion

            End If
            txtCliente.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class