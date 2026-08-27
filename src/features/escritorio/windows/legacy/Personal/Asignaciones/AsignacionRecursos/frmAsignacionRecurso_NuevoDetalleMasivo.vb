Imports System.ServiceModel
Public Class frmAsignacionRecurso_NuevoDetalleMasivo

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oRecursoDetService As New RecursoDetService.RecursoDetServiceClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private empresaUsuario As New EmpresaUsuarioService.EmpresaUsuario

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private CodActivo As String
    Private dtUbicacion As DataTable
    Private dtEstados As DataTable
    Private dtTipoActivo As DataTable
    Private dtDatos As New DataTable
    Private iEstado As Integer
    Public IdPersona As Integer
    Public IdRecurso As Integer
    Public Memo As String
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer

    Private Sub frmAsignacionRecurso_NuevoMasivo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oActivoFijoService.Close()
            oSeguridadService.Close()
            oEmpresaUsuario.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
            oSeguridadService.Abort()
            oEmpresaUsuario.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
            oSeguridadService.Abort()
            oEmpresaUsuario.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmAsignacionRecurso_NuevoMasivo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAsignacionRecurso_NuevoMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, )
        '/*************************************************************************************/

        chkColaborador.Enabled = False
        pboxLimpiarColaborador.Enabled = True
        ToolTip1.SetToolTip(chkColaborador, "Limpiar Solicitante")
        ToolTip1.SetToolTip(pboxLimpiarColaborador, "Limpiar Solicitante")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarcombos()
        poCargarArea()
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub poCargarArea()
        Try
            empresaUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
            cmbEstado.SelectedIndex = 0
            If Session.CodPerfil = "13" Then
                cmbCodArea.SelectedIndex = 0
            Else
                If empresaUsuario.Persona.CentroCosto.Area.CodArea Is Nothing Then
                    cmbCodArea.SelectedIndex = 0 'oUsuario.Persona.CentroCosto.Area.CodArea
                Else
                    cmbCodArea.Value = empresaUsuario.Persona.CentroCosto.Area.CodArea
                End If
                'cmbCodArea.Value = empresaUsuario.Persona.CentroCosto.Area.CodArea    'oUsuario.Persona.CentroCosto.Area.CodArea
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtSerie.KeyPress _
                        , cmbUbicacion.KeyPress _
                        , txtCodActivo.KeyPress _
                        , txtCodMaleta.KeyPress _
                        , cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
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


    Private Sub llenarcombos()
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

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oActivoFijoService.Filtrar(Session.sCodEmp, CStr(cmbCodArea.Value), CStr(cmbCentroCosto.Value), toBlank(txtCodActivo.Text), toBlank(txtSerie.Text), toNumber(cmbUbicacion.Value), toNumber(cmbTipoActivo.Value), IdPersona, toBlank(txtCodMaleta.Text), toNumber(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Try

            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de INSERTAR los ACTIVOS al Memo Nº : " & Memo & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim Cadena As String = ""
                    rows = dgvDatos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow

                    If rows.Count <> 0 Then
                        For Each row In rows

                            Dim registro As New RecursoDetService.RecursoDet
                            Dim Recurso As New RecursoDetService.Recurso
                            Dim EmpCom As New RecursoDetService.EmpresaComunicacion
                            Dim estado_process2 As Integer

                            registro.IdRecursoDet = 0
                            Recurso.IdRecurso = IdRecurso
                            registro.Recurso = Recurso
                            registro.Cantidad = 1
                            registro.Codigo = row.Cells("CodActivo").Text
                            registro.Serie = IIf(row.Cells("Serie").Text = "", Nothing, row.Cells("Serie").Text)  '' serie
                            registro.Descripcion = IIf(row.Cells("DesActivo").Text = "", Nothing, row.Cells("DesActivo").Text)  ' '' descripcion
                            registro.Talla = Nothing    ' ""
                            registro.Modelo = IIf(row.Cells("Modelo").Text = "", Nothing, row.Cells("Modelo").Text)     '  modelo
                            registro.Marca = IIf(row.Cells("Marca").Text = "", Nothing, row.Cells("Marca").Text)       '  marca
                            registro.UsoPersonal = True      '  true
                            registro.DesOtroUso = Nothing     ' ""
                            registro.Observacion = Nothing  ' "" 

                            EmpCom.IdEmpresa = Nothing     ' ""
                            registro.EmpresaComunicacion = EmpCom
                            registro.DesPlan = Nothing       ' ""
                            registro.NumCelular = Nothing ' ""
                            registro.NumRadio = Nothing     ' ""

                            registro.CodUsu = Session.sCodUsu
                            registro.NomPc = Session.sNomPc
                            registro.DirIp = Session.sDirIp
                            registro.FecReg = Today

                            estado_process2 = oRecursoDetService.Insertar(registro)

                        Next

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK

                    Else
                        MsgBox("Debe seleccionar alguno de los activos")
                    End If
                End If
            Else
                MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error al insertar los activos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtSerie.TextChanged, cmbUbicacion.ValueChanged, txtCodActivo.TextChanged, cmbEstado.ValueChanged, txtColaborador.TextChanged, cmbTipoActivo.ValueChanged, txtCodMaleta.TextChanged
        listaDatos()
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
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkColaborador_CheckedChanged(sender As Object, e As EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkColaborador.Enabled = True
            pboxLimpiarColaborador.Enabled = True
        End If
    End Sub

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
            listaDatos()

            'If cmbCodArea.Value = "" Then
            '    lblUnidadNegocio.Text = ""
            'Else
            '    lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class