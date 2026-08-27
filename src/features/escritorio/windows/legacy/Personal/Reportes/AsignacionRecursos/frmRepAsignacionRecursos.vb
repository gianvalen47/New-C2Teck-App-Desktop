Imports System.ServiceModel
Public Class frmRepAsignacionRecurso

    '=========================== Servicios ====================================================
    Private oRecursoService As New RecursoService.RecursoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtRubros As DataTable
    Private dtEstados As New DataTable
    Public IdPersona As Integer

    Private Sub frmRepAsignacionRecurso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oRecursoService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepAsignacionRecurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepAsignacionRecurso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 225)
        '/*************************************************************************************/

        txtFecInicio.Value = Today
        txtFecFinal.Value = Today
        llenarCombos()
        chkColaborador.Enabled = False
        txtFecInicio.Focus()
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                 txtFecInicio.KeyPress _
                               , txtFecFinal.KeyPress _
                               , txtColaborador.KeyPress _
                               , cmbArea.KeyPress _
                               , cmbCentroCosto.KeyPress _
                               , cmbRubro.KeyPress _
                               , txtCodigo.KeyPress _
                               , txtSerie.KeyPress _
                               , txtNumCelular.KeyPress _
                               , cmbEstado.KeyPress
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
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtArea.Rows.Count > 1 Then
                dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            End If
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================= RUBRO ================================================
            dtRubros = oRecursoService.MostrarRubros("").Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '======================================= ESTADO ================================================
            dtEstados = oRecursoService.MostrarEstados()
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
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            If dtCentroCosto.Rows.Count > 1 Or cmbArea.Value = "" Then
                dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            End If
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

            'cmbArea.ReadOnly = False
            'cmbArea.BackColor = System.Drawing.SystemColors.Window

            'cmbCentroCosto.ReadOnly = False
            'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
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
                    'ObtenerDatos()
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0

                    'cmbArea.ReadOnly = False
                    'cmbArea.BackColor = System.Drawing.SystemColors.Window

                    'cmbCentroCosto.ReadOnly = False
                    'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub ObtenerDatos()
    '    Try
    '        Persona = oPersonaService.Obtener(IdPersona)
    '        cmbArea.Value = Persona.CentroCosto.Area.CodArea
    '        cmbArea.ReadOnly = True
    '        cmbArea.BackColor = System.Drawing.SystemColors.Control

    '        cmbCentroCosto.Value = Persona.CentroCosto.CodCentro
    '        cmbCentroCosto.ReadOnly = True
    '        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER DATOS DE COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

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
                Dim forma As New frmReportes
                Dim reporte As New rptRepAsignacionRecursos
                Dim dtReporte As New DataTable

                oSeguridadService.RegistrarVisitaOpciones(225, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                dtReporte = oRecursoService.Reporte(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), txtFecInicio.Value, txtFecFinal.Value, _
                                                    IdPersona, toNumber(cmbRubro.Value), txtCodigo.Text, txtSerie.Text, txtNumCelular.Text, toBlank(cmbEstado.Value)).Tables(0)

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
                    reporte.SetParameterValue("pArea", cmbArea.Text)
                    reporte.SetParameterValue("pRubro", cmbRubro.Text)
                    reporte.SetParameterValue("pCentroCosto", cmbCentroCosto.Text)
                    reporte.SetParameterValue("pEstado", cmbEstado.Text)
                    forma.Text = "Reporte de Asignaciones de Recursos"
                    forma.ShowDialog()
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