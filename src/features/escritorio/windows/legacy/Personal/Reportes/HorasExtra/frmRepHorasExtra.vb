Imports System.ServiceModel
Public Class frmRepHorasExtra

    '=========================== Servicios ===================================================
    Private oHoraExtraService As New HoraExtraService.HoraExtraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oJobService As New JobService.JobServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================================    
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtClase As DataTable
    Private dtUbicacion As DataTable
    Private dtPerAutoriza As DataTable
    Public IdPersona As Integer

    Private Sub frmRepHorasExtra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oHoraExtraService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oAsignacionJefesService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oHoraExtraService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oAsignacionJefesService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oHoraExtraService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oAsignacionJefesService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepHorasExtra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepHorasExtra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 220)
        '/*************************************************************************************/

        txtFecInicio.Value = Today
        txtFecFinal.Value = Today
        llenarCombos()
        chkColaborador.Enabled = False
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                   txtFecInicio.KeyPress _
                                 , txtFecFinal.KeyPress _
                                 , txtColaborador.KeyPress _
                                 , cmbArea.KeyPress _
                                 , cmbCentroCosto.KeyPress _
                                 , cmbClase.KeyPress _
                                 , cmbPerAutoriza.KeyPress _
                                 , cmbUbicacion.KeyPress _
                                 , rbDetallado.KeyPress _
                                 , rbResumen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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

    Private Function getRowNinguno(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================== CLASE ================================================
            dtClase = oPersonaService.MostrarClases.Tables(0)
            dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing

            '============================================== UBICACIÓN ========================================
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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub cmbCentroCosto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.ValueChanged
        Try

            '=================================== PERSONA AUTORIZA ==========================================
            dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(cmbCentroCosto.Value).Tables(0)
            dtPerAutoriza.Rows.InsertAt(getRowNinguno(dtPerAutoriza), 0)
            cmbPerAutoriza.DataSource = dtPerAutoriza
            cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.SelectedIndex = 0
            dtPerAutoriza = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR PERSONA AUTORIZA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub cmbPerAutoriza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPerAutoriza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        If Len(Trim(txtNumJob.Text)) > 0 Then
            If Not (oJobService.Buscar(txtNumJob.Text)) Then
                MsgBox("Número de Job no existente, Verifique")
                txtNumJob.Text = ""
                txtNumJob.Focus()
            End If
        Else
            cmbUbicacion.Focus()
        End If
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0

            cmbArea.ReadOnly = False
            cmbArea.BackColor = System.Drawing.SystemColors.Window

            cmbCentroCosto.ReadOnly = False
            cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window

            cmbClase.ReadOnly = False
            cmbClase.BackColor = System.Drawing.SystemColors.Window
        Else
            chkColaborador.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                    ObtenerDatos()
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0

                    cmbArea.ReadOnly = False
                    cmbArea.BackColor = System.Drawing.SystemColors.Window

                    cmbCentroCosto.ReadOnly = False
                    cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window

                    cmbClase.ReadOnly = False
                    cmbClase.BackColor = System.Drawing.SystemColors.Window
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerDatos()
        Try
            Persona = oPersonaService.Obtener(IdPersona)
            cmbArea.Value = Persona.CentroCosto.Area.CodArea
            cmbArea.ReadOnly = True
            cmbArea.BackColor = System.Drawing.SystemColors.Control

            cmbCentroCosto.Value = Persona.CentroCosto.CodCentro
            cmbCentroCosto.ReadOnly = True
            cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control

            cmbClase.Value = Persona.Clase.CodClas
            cmbClase.ReadOnly = True
            cmbClase.BackColor = System.Drawing.SystemColors.Control
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS DE COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtFecInicio.Value > txtFecFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor a la fecha final.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If ValidaCampos() Then

                oSeguridadService.RegistrarVisitaOpciones(220, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If rbDetallado.Checked = True Then

                    Dim forma As New frmReportes
                    Dim reporte As New rptRepHorasExtraDet
                    Dim dtReporte As New DataTable

                    oHoraExtraService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtReporte = oHoraExtraService.ReporteHoraExtra(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), _
                                                                                            txtFecInicio.Value, txtFecFinal.Value, IdPersona, toNumber(cmbPerAutoriza.Value), txtNumJob.Text, _
                                                                                            toBlank(cmbUbicacion.Value), 1).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Horas Extra Detallado"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                        reporte.SetParameterValue("pArea", IIf(cmbArea.SelectedIndex = 0, "", UCase(cmbArea.Text)))
                        reporte.SetParameterValue("pCentro", UCase(cmbCentroCosto.Text))
                        reporte.SetParameterValue("pTitulo", "REPORTE DETALLADO DE HORAS EXTRA")
                        forma.ShowDialog()
                    End If

                ElseIf rbResumen.Checked = True Then

                    Dim forma As New frmReportes
                    Dim reporte As New rptRepHorasExtraRes
                    Dim dtReporte As New DataTable

                    oHoraExtraService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtReporte = oHoraExtraService.ReporteHoraExtra(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), _
                                                                                            txtFecInicio.Value, txtFecFinal.Value, IdPersona, toNumber(cmbPerAutoriza.Value), txtNumJob.Text, _
                                                                                            toBlank(cmbUbicacion.Value), 2).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Horas Extra Resumido"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                        reporte.SetParameterValue("pArea", IIf(cmbArea.SelectedIndex = 0, "", UCase(cmbArea.Text)))
                        reporte.SetParameterValue("pCentro", UCase(cmbCentroCosto.Text))             
                        forma.ShowDialog()
                    End If

                ElseIf rbHrsCompensdas.Checked = True Then

                    Dim forma As New frmReportes
                    Dim reporte As New rptRepHorasExtraDet
                    Dim dtReporte As New DataTable

                    oHoraExtraService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtReporte = oHoraExtraService.ReporteHoraExtra(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), _
                                                                                            txtFecInicio.Value, txtFecFinal.Value, IdPersona, toNumber(cmbPerAutoriza.Value), txtNumJob.Text, _
                                                                                            toBlank(cmbUbicacion.Value), 4).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Horas Compensadas"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                        reporte.SetParameterValue("pArea", IIf(cmbArea.SelectedIndex = 0, "", UCase(cmbArea.Text)))
                        reporte.SetParameterValue("pCentro", UCase(cmbCentroCosto.Text))
                        reporte.SetParameterValue("pTitulo", "REPORTE DE HORAS COMPENSADAS")
                        forma.ShowDialog()
                    End If

                End If

            End If           
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub rbExportar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbExportar.CheckedChanged
        If rbExportar.Checked = True Then
            btnAceptar.Visible = False
            btnAceptarE.Visible = True
        Else
            btnAceptar.Visible = True
            btnAceptarE.Visible = False
        End If
    End Sub

    Private Sub btnAceptarE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarE.Click
        Try
            If ValidaCampos() Then
                If rbExportar.Checked = True Then

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = False Then
                        MsgBox("No tienes acceso a descargar datos!!!!!!!!")
                        Return
                    End If

                    Dim dtDatosExcel As DataTable

                    oHoraExtraService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtDatosExcel = oHoraExtraService.ReporteHoraExtra(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), _
                                                                                           txtFecInicio.Value, txtFecFinal.Value, IdPersona, toNumber(cmbPerAutoriza.Value), txtNumJob.Text, _
                                                                                           toBlank(cmbUbicacion.Value), 3).Tables(0)
                    dgvDatosExcel.DataSource = dtDatosExcel

                    Dim Export As Boolean = ExportarExcel(dgvDatosExcel)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

End Class