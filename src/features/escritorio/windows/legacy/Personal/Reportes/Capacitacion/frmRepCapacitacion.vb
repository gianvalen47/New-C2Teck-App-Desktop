Imports System.ServiceModel
Public Class frmRepCapacitacion

    '=========================== Servicios ===================================================
    Private oCapacitacionService As New CapacitacionService.CapacitacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables============================================== 
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtTipoCapacitacion As DataTable
    Private dtCargo As DataTable
    Public IdPersona As Integer
    Public IdProveedor As Integer

    Private Sub frmRepCapacitacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oCapacitacionService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCapacitacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oCapacitacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepCapacitacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCapacitacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 239)
        '/*************************************************************************************/

        txtFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFecFinal.Value = Date.Today
        llenarCombos()
        chkColaborador.Enabled = False
        chkProveedor.Enabled = False
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                  txtFecInicio.KeyPress _
                                , txtFecFinal.KeyPress _
                                , txtColaborador.KeyPress _
                                , txtProveedor.KeyPress _
                                , cmbArea.KeyPress _
                                , cmbCentroCosto.KeyPress _
                                , cmbTipoCapac.KeyPress _
                                , cmbCargo.KeyPress
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

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
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
            dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================== TIPO =================================================
            dtTipoCapacitacion = oCapacitacionService.MostrarTipos()
            dtTipoCapacitacion.Rows.InsertAt(getRowTodos1(dtTipoCapacitacion), 0)
            cmbTipoCapac.DataSource = dtTipoCapacitacion
            cmbTipoCapac.DropDownList.DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.DisplayMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.ValueMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.Columns(0).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.Columns(1).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.SelectedIndex = 0
            dtTipoCapacitacion = Nothing

            '======================================== CARGO ===============================================
            dtCargo = oPersonaService.MostrarCargos(Session.sCodEmp, "").Tables(0)
            dtCargo.Rows.InsertAt(getRowTodos(dtCargo), 0)
            cmbCargo.DataSource = dtCargo
            cmbCargo.DropDownList.DataMember = dtCargo.Columns("DesCargo").ToString
            cmbCargo.DropDownList.DisplayMember = dtCargo.Columns("DesCargo").ToString
            cmbCargo.DropDownList.ValueMember = dtCargo.Columns("CodCargo").ToString
            cmbCargo.DropDownList.Columns(0).DataMember = dtCargo.Columns("CodCargo").ToString
            cmbCargo.DropDownList.Columns(1).DataMember = dtCargo.Columns("DesCargo").ToString
            cmbCargo.SelectedIndex = 0
            dtCargo = Nothing

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

            cmbCargo.ReadOnly = False
            cmbCargo.BackColor = System.Drawing.SystemColors.Window
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

                    cmbCargo.ReadOnly = False
                    cmbCargo.BackColor = System.Drawing.SystemColors.Window

                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        Else
            chkProveedor.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                    ObtenerDatos()
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
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

            cmbCargo.Value = Persona.Cargo.CodCargo
            cmbCargo.ReadOnly = True
            cmbCargo.BackColor = System.Drawing.SystemColors.Control
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
                Dim forma As New frmReportes
                Dim reporte As New rptRepCapacitacion
                Dim dtReporte As New DataTable

                oSeguridadService.RegistrarVisitaOpciones(239, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                dtReporte = oCapacitacionService.Reporte(Session.sCodEmp, txtFecInicio.Value, txtFecFinal.Value, cmbArea.Value, cmbCentroCosto.Value, _
                                                                                IIf(cmbTipoCapac.SelectedIndex = 0, "", cmbTipoCapac.Value), IdProveedor, IdPersona, txtNomCurso.Text, IIf(cmbCargo.SelectedIndex = 0, "", cmbCargo.Value)).Tables(0)
                If rbPantalla.Checked = True Then                  

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
                        forma.Text = "Reporte de Capacitación"
                        reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                        reporte.SetParameterValue("pTipo", cmbTipoCapac.Text)
                        reporte.SetParameterValue("pCargo", cmbCargo.Text)
                        forma.ShowDialog()
                    End If

                ElseIf rbExcel.Checked = True Then
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
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