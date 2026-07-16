Imports System.ServiceModel
Public Class frmRepVacaciones

    '=========================== Servicios ====================================================
    Private oVacacionesService As New VacacionesService.VacacionesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================================
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtClase As DataTable
    Private dtEstados As DataTable
    Private dtPeriodos As DataTable
    Private dtMeses As New DataTable
    Public IdPersona As Integer

    Private Sub frmRepVacaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oVacacionesService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oVacacionesService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVacacionesService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepVacaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepVacaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 226)
        '/*************************************************************************************/

        llenarCombos()
        chkColaborador.Enabled = False
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                    txtColaborador.KeyPress _
                                , cmbArea.KeyPress _
                                , cmbCentroCosto.KeyPress _
                                , cmbClase.KeyPress _
                                , cmbEstado.KeyPress _
                                , cmbAnio.KeyPress _
                                , rbTotales.KeyPress _
                                , rbDetalles.KeyPress _
                                , cbVigente.KeyPress
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

    Private Sub llenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '=========================================== CLASE =============================================
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

            ''========================================== PERIODOS ===========================================
            dtPeriodos = oVacacionesService.MostrarPeriodos().Tables(0)
            dtPeriodos.Rows.InsertAt(getRowTodos(dtPeriodos), 0)
            cmbAnio.DataSource = dtPeriodos
            cmbAnio.DropDownList.DataMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.DropDownList.DisplayMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.DropDownList.ValueMember = dtPeriodos.Columns("Periodo").ToString
            cmbAnio.DropDownList.Columns(0).DataMember = dtPeriodos.Columns("Periodo").ToString
            cmbAnio.DropDownList.Columns(1).DataMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.SelectedIndex = 0
            dtPeriodos = Nothing

            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            ''=========================================== ESTADOS ==========================================
            dtEstados = oVacacionesService.MostrarEstados()
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ==========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
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

    'Private Function ValidaCampos() As Boolean
    '    Try
    '        If txtFecInicio.Value < txtFecFinal.Value Then
    '            MsgBox("La fecha de inicio no debe ser mayor a la fecha final.", MsgBoxStyle.Information, "Información")
    '            txtFecInicio.Focus()
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            'If ValidaCampos() Then

            If rbTotales.Checked = True Then
                Dim forma As New frmReportes
                Dim reporte As New rptRepVacacionesTot
                Dim dtReporte As New DataTable

                oSeguridadService.RegistrarVisitaOpciones(226, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                dtReporte = oVacacionesService.Reporte(Session.sCodEmp, toBlank(cmbClase.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value),
                                                                            toNumber(cmbAnio.Value), toNumber(cmbMes.Value), IdPersona, toBlank(cmbEstado.Value), IIf(cbVigente.Checked = True, True, False), 1).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                Else

                    If rbExcel.Checked Then

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = False Then
                            MsgBox("No tienes permiso para descargar datos!!!!!")
                            Return
                        End If

                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    Else

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Vacaciones Totales"
                        reporte.SetParameterValue("pEstado", IIf(cmbEstado.SelectedIndex = 0, "", UCase(cmbEstado.Text)))
                        forma.ShowDialog()
                    End If

                End If


            ElseIf rbDetalles.Checked = True Then
                Dim forma As New frmReportes
                Dim reporte As New rptRepVacacionesDet
                Dim dtReporte As New DataTable

                dtReporte = oVacacionesService.Reporte(Session.sCodEmp, toBlank(cmbClase.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value),
                                                                            toNumber(cmbAnio.Value), toNumber(cmbMes.Value), IdPersona, toBlank(cmbEstado.Value), IIf(cbVigente.Checked = True, True, False), IIf(rbTotales.Checked = True, 1, 2)).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                Else

                    If rbExcel.Checked Then
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = False Then
                            MsgBox("No tienes permiso para descargar datos!!!!!!!!")
                            Return
                        End If

                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Vacaciones Detallado"
                        reporte.SetParameterValue("pEstado", IIf(cmbEstado.SelectedIndex = 0, "", UCase(cmbEstado.Text)))
                        reporte.SetParameterValue("pPeriodo", IIf(cmbAnio.SelectedIndex = 0, 0, cmbAnio.Text))
                        forma.ShowDialog()

                    End If
                End If
            End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

End Class