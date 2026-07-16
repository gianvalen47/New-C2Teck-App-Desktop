Imports System.ServiceModel

Public Class frmRepGastosGenerales
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPreGastoRealDetService As New PreGastoRealDetService.PreGastoRealDetServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private dtDatos As DataTable
    Private dtRubro As DataTable
    Private dtCLiente As DataTable
    Private dtOficinas As DataTable
    Private dtTipDoc As DataTable
    Private dtMonedas As DataTable
    Private dtTipo As DataTable
    Private IdPer As Integer
    Private dtAreas As DataTable
    Private dtUnidades As DataTable
    Private dtCentroCosto As DataTable


    Private Sub frmRepGastosGenerales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oPreGastoRealDetService.Close()
            oGastoRealService.Close()
            oJobService.Close()
            oSeguridadService.close()
            oCentroCostoService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oPreGastoRealDetService.Abort()
            oGastoRealService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oPreGastoRealDetService.Abort()
            oGastoRealService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepGastosGenerales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepGastosGenerales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 116)
        '/*************************************************************************************/

        ' Validar Usuario - Exportar Excel
        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
            rbExcel.Enabled = True
        Else
            rbExcel.Enabled = False
        End If

        txtFechaInicio.Value = CDate("01/01/" + utils.toBlank(Year(Today)))
        txtFechaFin.Value = Today()
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
            dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0

            '------------------------------- Tipo Documento --------------------------------------------
            dtTipDoc = oGastoRealService.MostrarTipoDocumento.Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipDoc.DataSource = dtTipDoc
            cmbTipDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.SelectedIndex = 0

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

            '-------------------------------Monedas--------------------------------------------
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 0

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

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(116, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Len(Trim(txtNumJob.Text)) > 0 Then

                    If Not (oJobService.Buscar(txtNumJob.Text)) Then
                        MsgBox("Número de OT no existente, Verifique")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()

                    Else
                        cmbTipDoc.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptGastosGenerales

            Dim FecInicio As Date
            Dim FecFinal As Date
            Dim CodOfi As String
            Dim NroDoc As String
            Dim TpoDoc As String
            Dim Ruc As String
            Dim CodMon As String
            Dim NumJob As String
            Dim Monto As String
            Dim CodRubro As String
            Dim CodLoc As String

            If utils.toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio")
            ElseIf utils.toBlank(txtFechaFin.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Termino")
            Else

                FecInicio = txtFechaInicio.Text
                FecFinal = txtFechaFin.Text

                CodRubro = cmbRubro.Value
                CodLoc = cmbLocacion.Value

                If txtNumDoc.Text = "" Then
                    NroDoc = "Todos"
                Else : NroDoc = txtNumDoc.Text
                End If

                CodOfi = cmbLocacion.Text
                If txtRuc.Text = "" Then
                    Ruc = "Todos"
                Else : Ruc = txtRuc.Text
                End If

                TpoDoc = cmbTipDoc.Text
                CodMon = cmbMoneda.Text

                If txtNumJob.Text = "" Then
                    NumJob = "Todos"
                    IdPer = 0
                Else : NumJob = txtNumJob.Text
                End If

                Monto = txtMonto.Text

                dtReporte = oGastoRealService.Reporte(FecInicio, FecFinal, CodRubro, CodLoc, utils.toNumber(cmbTipo.Value), _
                                                        txtNumJob.Text, utils.toNumber(cmbTipDoc.Value), txtNumDoc.Text, txtDescripcion.Text, _
                                                        txtRuc.Text, utils.toBlank(cmbMoneda.Value), utils.toDouble(Monto), utils.toNumber(IdPer), _
                                                        toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value)).Tables(0)


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
                        reporte.SetParameterValue("FecInicio", txtFechaInicio.Text)
                        reporte.SetParameterValue("FecFinal", txtFechaFin.Text)
                        reporte.SetParameterValue("NroDoc", NroDoc)
                        reporte.SetParameterValue("CodOfi", CodOfi)
                        reporte.SetParameterValue("TpoDoc", TpoDoc)
                        reporte.SetParameterValue("Ruc", Ruc)
                        reporte.SetParameterValue("CodMon", CodMon)
                        reporte.SetParameterValue("NumJob", NumJob)
                        reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                        reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))

                        forma.Text = "Reporte de Gastos Reales Generales"

                        forma.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

End Class