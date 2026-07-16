Imports System.ServiceModel
Public Class frmRepFaltasPersonal

    '===========================Servicios====================================================
    Private oFaltasService As New FaltasService.FaltasServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oMaestroService As New MaestroService.MaestroClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================================
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtClase As DataTable
    Private dtPerAutoriza As DataTable
    Private dtMotivo As DataTable
    Public IdPersona As Integer

    Private Sub frmRepFaltasPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oFaltasService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
            oAsignacionJefesService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oFaltasService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oAsignacionJefesService.Abort()
            oSeguridadService.Close()
        Catch ex As CommunicationException
            oFaltasService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oAsignacionJefesService.Abort()
            oSeguridadService.Close()
        End Try
    End Sub

    Private Sub frmRepFaltasPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepFaltasPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 221)
        '/*************************************************************************************/

        txtFecInicio.Value = Today
        txtFecFinal.Value = Today
        llenarCombos()
        chkColaborador.Enabled = False
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                  txtFecInicio.KeyPress _
                                , txtFecFinal.KeyPress _
                                , txtColaborador.KeyPress _
                                , cmbArea.KeyPress _
                                , cmbCentroCosto.KeyPress _
                                , cmbPerAutoriza.KeyPress _
                                , cmbClase.KeyPress _
                                , cmbMotivo.KeyPress _
                                , rbDetallado.KeyPress _
                                , rbStatus.KeyPress _
                                , rbDescontar.KeyPress
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

    Private Function getRowAusente(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "00"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "AUSENTE"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "AUSENTE"
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

            '======================================== MOTIVO ================================================
            dtMotivo = oFaltasService.MostrarMotivos(Session.sCodUsu).Tables(0)
            dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
            dtMotivo.Rows.InsertAt(getRowAusente(dtMotivo), 1)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("CodMotivo").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("CodMotivo").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.SelectedIndex = 0
            dtMotivo = Nothing


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

                oSeguridadService.RegistrarVisitaOpciones(221, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable

                '============================ DETALLADO ===============================
                If rbDetallado.Checked = True Then

                    Dim reporte As New rptFaltasPersonalDetallado
                    oFaltasService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtReporte = oFaltasService.ReporteFaltas(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), txtFecInicio.Value, txtFecFinal.Value, _
                                                                                  IdPersona, toNumber(cmbPerAutoriza.Value), toBlank(cmbMotivo.Value), 1).Tables(0)

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
                        forma.Text = "Reporte de Faltas de Personal Detallado"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                        forma.ShowDialog()
                    End If

                    '============================== STATUS =================================
                ElseIf rbStatus.Checked = True Then

                    Dim reporte As New rptFaltasPersonalStatus
                    oFaltasService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtReporte = oFaltasService.ReporteFaltas(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), txtFecInicio.Value, txtFecFinal.Value, _
                                                                                  IdPersona, toNumber(cmbPerAutoriza.Value), toBlank(cmbMotivo.Value), 2).Tables(0)

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
                        forma.Text = "Reporte de Faltas de Personal Status"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                        forma.ShowDialog()
                    End If

                    '============================ DESCUENTO ===============================
                ElseIf rbDescontar.Checked = True Then

                    Dim reporte As New rptFaltasPersonalDescuento
                    oFaltasService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    dtReporte = oFaltasService.ReporteFaltas(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), txtFecInicio.Value, txtFecFinal.Value, _
                                                                                                      IdPersona, toNumber(cmbPerAutoriza.Value), toBlank(cmbMotivo.Value), 3).Tables(0)
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
                        forma.Text = "Reporte de Faltas de Personal Descuento"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
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
End Class