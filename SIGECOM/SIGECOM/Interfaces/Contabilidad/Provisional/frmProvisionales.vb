Imports System.ServiceModel
Public Class frmProvisionales

    '===========================Servicios====================================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    'Private oUsuario As New SeguridadService.Usuario    
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    Private oUsuario As New EmpresaUsuarioService.EmpresaUsuario
    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private iEstado As Integer
    Private dtEstados As DataTable
    Private dtTipo As DataTable
    Private dtAreas As DataTable
    Private dtUbicacion As DataTable
    Private dtDatos As New DataTable

    '==========================Evento Load===================================================
    Private Sub frmComProvisionales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 141)
        '/*************************************************************************************/

        chkPersona.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkPersona, "Limpiar Solicitante")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Solicitante")
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_Search = False
        llenarCombos()
        cmbUbicacion.Value = 1
        'poCargarArea()
        ObtenerSolicitante()
        InhabilitarViatico()
        ObtenerUbicacion()
        txtAnio.Value = Today.Year
        state_Search = True
        listaDatos()
        dgvDatos.Select()
        'Agregado 25-01
        'cbViatico.Checked = True
        'cmbTipo.
        '-----------
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              cmbUbicacion.KeyPress _
                            , txtAnio.KeyPress _
                            , cmbCodArea.KeyPress _
                            , txtSolicitante.KeyPress _
                            , txtIdProvisional.KeyPress _
                            , txtNumJob.KeyPress _
                            , cmbTipo.KeyPress _
                            , cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed=============================================
    Private Sub frmCuentasPorPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oAsignacionJefesService.Close()
            oEmpresaUsuario.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
            oEmpresaUsuario.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
            oEmpresaUsuario.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmCuentasPorPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biAprobar.Enabled = False
            biEnviar.Enabled = False
            biAtender.Enabled = False
            biCerrar.Enabled = False
            biRechazar.Enabled = False
            biAtenderMasivo.Enabled = False
            biTramitar.Enabled = False
            biActualizarFecTermino.Enabled = False
            biActualizarOT.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miAprobar.Enabled = False
            miEnviar.Enabled = False
            miAtender.Enabled = False
            miCerrar.Enabled = False
            miRechazar.Enabled = False
            miAtenderMasivo.Enabled = False
            miTramitar.Enabled = False
            miActualizarFecTermino.Enabled = False
            miActualizarOT.Enabled = False
        Else
            iEstado = oProvisionalService.ObtenerEstado(dgvDatos.CurrentRow.Cells("IdProvisional").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biVerEstados.Enabled = True
            biAprobar.Enabled = IIf(iEstado = 2, True, False)
            biEnviar.Enabled = IIf(iEstado = 1, True, False)
            biAtender.Enabled = IIf(iEstado = 3 And (oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            biCerrar.Enabled = IIf(iEstado = 5 And (oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            biAtenderMasivo.Enabled = IIf((oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            biRechazar.Enabled = IIf(iEstado = 3 And (oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            biTramitar.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "51" Or Session.CodPerfil = "02" Or Session.CodPerfil = "38") And iEstado = 5, True, False)
            'biActualizarFecTermino.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "12" Or Session.CodPerfil = "57" Or Session.CodPerfil = "51") And iEstado = 5, True, False)
            biActualizarFecTermino.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "12") And iEstado = 5, True, False)
            biFechaTerminoMant.Enabled = IIf(iEstado = 5, True, False)
            biAprobarFecTermino.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "12" Or Session.CodPerfil = "57" Or Session.CodPerfil = "22" Or Session.CodPerfil = "42") And iEstado = 5, True, False)

            biActualizarOT.Enabled = IIf((oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01" Or Session.CodPerfil = "24") And iEstado <> 6, True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miVerEstados.Enabled = True
            miAprobar.Enabled = IIf(iEstado = 2, True, False)
            miEnviar.Enabled = IIf(iEstado = 1, True, False)
            miAtender.Enabled = IIf(iEstado = 3 And (oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            miCerrar.Enabled = IIf(iEstado = 5 And (oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            miAtenderMasivo.Enabled = IIf((oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            miRechazar.Enabled = IIf(iEstado = 3 And (oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01"), True, False)
            miTramitar.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "51" Or Session.CodPerfil = "02" Or Session.CodPerfil = "38") And iEstado = 5, True, False)
            'miActualizarFecTermino.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "12" Or Session.CodPerfil = "57" Or Session.CodPerfil = "51") And iEstado = 5, True, False)
            miActualizarOT.Enabled = IIf((oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or Session.CodPerfil = "01" Or Session.CodPerfil = "24") And iEstado <> 6, True, False)

            miActualizarFecTermino.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "12") And iEstado = 5, True, False)
            miFechaTerminoMant.Enabled = IIf(iEstado = 5, True, False)
            miAprobarFecTermino.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "12" Or Session.CodPerfil = "57" Or Session.CodPerfil = "22" Or Session.CodPerfil = "42") And iEstado = 5, True, False)

        End If
    End Sub

    Private Sub InhabilitarViatico()
        'Se comenta la opción que inhabilita el check de viaticos para el perfil "32" - 18/06/2013
        'If Session.CodPerfil = "32" Then
        '    cbViatico.Checked = True
        '    cbViatico.Enabled = False
        'ElseIf Session.CodPerfil = "31" Or Session.CodPerfil = "30" Then
        If Session.CodPerfil = "31" Or Session.CodPerfil = "30" Then
            'cbViatico.Checked = False
            'cbViatico.Enabled = False
            cmbTipo.ReadOnly = True
            cmbTipo.BackColor = System.Drawing.SystemColors.Control
        Else
            'cbViatico.Checked = False
            'cbViatico.Enabled = True
            cmbTipo.ReadOnly = False
            cmbTipo.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub poCargarArea()
        'oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        '---------------------Modificado el 12/07/2012 (solo usuarios de gerencia y perfiles especificos pueden ver los provisionales de todas las areas)------------
        'If Session.CodPerfil = "01" Or Session.CodPerfil = "34" Or Session.CodPerfil = "15" Or oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or oAsignacionJefesService.BuscarAprobarCompra(oUsuario.Persona.IdPer) Then
        '    cmbCodArea.SelectedIndex = 0
        '    cmbCodArea.Enabled = True
        'Else
        '    cmbCodArea.Value = oUsuario.Persona.CentroCosto.Area.CodArea
        '    cmbCodArea.Enabled = False
        'End If
    End Sub

    Private Sub ObtenerSolicitante()
        '---------------------Modificado el 12/07/2012 (solo usuarios de gerencia, usuarios con permiso de aprobación y perfiles especificos pueden ver los provisionales de cualquier solicitante)------------
        oUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp) 'oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        If Session.CodPerfil = "01" Or Session.CodPerfil = "34" Or Session.CodPerfil = "42" Or Session.CodPerfil = "14" Or Session.CodPerfil = "57" Or oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Or
            oAsignacionJefesService.BuscarJefeArea(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Or oAsignacionJefesService.BuscarAprobarCompra(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Then
            IdPersona = 0
            txtSolicitante.Text = "(Todos)"
            btnBuscarPersona.Enabled = True
        Else
            IdPersona = oUsuario.Persona.IdPer
            txtSolicitante.Text = oUsuario.Persona.ApeNom
            btnBuscarPersona.Enabled = False
        End If
    End Sub

    Private Sub ObtenerUbicacion()
        If oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Then
            cmbUbicacion.Value = oProvisionalService.ObtenerIdUbicacion(Session.sCodUsu, Session.sCodEmp)
            cmbUbicacion.Enabled = False
        Else
            cmbUbicacion.SelectedIndex = 1
            cmbUbicacion.Enabled = True
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdProvisional").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal IdProvisional As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtIdProvisional.Text = IdProvisional
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmProvisional_Nuevo
            iEstado = oProvisionalService.ObtenerEstado(dgvDatos.CurrentRow.Cells("IdProvisional").Value)
            frm.state_button = True
            frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Text
            frm.editable = IIf(iEstado = 1, True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtIdProvisional.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdProvisional)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL PROVISIONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Provisional Nº " & dgvDatos.CurrentRow.Cells("IdProvisional").Text.ToString & " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oProvisionalService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("!Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL PROVISIONAL:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmProvisional_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    cmbUbicacion.Value = frm.iUbicacion
                    'cbViatico.Checked = frm.iViatico
                    RowPossesion(dgvDatos, frm.IdProvisional)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO PROVISIONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================== AREAS ================================================
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

            '======================================= UBICACION ===============================================
            dtUbicacion = oProvisionalService.MostrarUbicacionCaja(Session.sCodEmp).Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oProvisionalService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            '======================================= TIPO ================================================
            dtTipo = oProvisionalService.MostrarTipo().Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                'dtDatos = oProvisionalService.Filtrar(Session.sCodEmp, cmbUbicacion.Value, toNumber(txtAnio.Value), cmbCodArea.Value, IdPersona, toNumber(txtIdProvisional.Text), cmbEstado.Value, cbViatico.Checked, txtNumJob.Text, Session.sCodUsu).Tables(0)
                dtDatos = oProvisionalService.Filtrar(Session.sCodEmp, cmbUbicacion.Value, toNumber(txtAnio.Value), cmbCodArea.Value, IdPersona, toNumber(txtIdProvisional.Text), cmbEstado.Value, cmbTipo.Value, txtNumJob.Text, Session.sCodUsu).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbUbicacion.ValueChanged, txtAnio.ValueChanged, cmbCodArea.ValueChanged, txtSolicitante.TextChanged, txtIdProvisional.TextChanged, cmbEstado.ValueChanged, txtNumJob.TextChanged, cmbTipo.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdProvisional").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("!Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("!Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_Estados
                frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Value
                frm.Text = "Estados del Provisional Nº " & dgvDatos.CurrentRow.Cells("IdProvisional").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        oUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp) 'oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        Try
            If ValidaCodigoSeleccionado() Then
                If oAsignacionJefesService.BuscarJefeArea(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Then
                    Dim frm As New frmProvisional_Aprobar
                    frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Text
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        biRefrescar_Click(sender, e)
                    End If
                Else
                    MsgBox("Usted no tiene permiso para aprobar provisional.")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                                miTramitar.MouseLeave, biTramitar.MouseLeave, miRechazar.MouseLeave, biRechazar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Provisional actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Provisional."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Provisional actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Provisional actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar Provisional actual."
    End Sub
    Private Sub Atender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.MouseEnter, miAtender.MouseEnter
        sslError.Text = "Atender Provisional actual."
    End Sub
    Private Sub Rechazar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.MouseEnter, miRechazar.MouseEnter
        sslError.Text = "Rechazar Provisional actual."
    End Sub
    Private Sub Tramitar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTramitar.MouseEnter, miTramitar.MouseEnter
        sslError.Text = "Tramitar Provisional actual."
    End Sub
    Private Sub Cerrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.MouseEnter, miCerrar.MouseEnter
        sslError.Text = "Cerrar Provisional actual."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar Provisional actual."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados de Provisional actual."
    End Sub
    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        'dtDatos = oProvisionalService.Imprimir(dgvDatos.CurrentRow.Cells("IdProvisional").Value).Tables(0)
        'DataGridView1.DataSource = dtDatos
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptProvisional_Detalle
            If dgvDatos.RowCount > 0 Then
                dtReporte = oProvisionalService.Imprimir(dgvDatos.CurrentRow.Cells("IdProvisional").Value).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("pNumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotEntrega").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                    forma.Text = "Impresión de Provisional Nº" + dgvDatos.CurrentRow.Cells("IdProvisional").Text
                    forma.ShowDialog()
                End If
            Else
                MsgBox("!No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            oUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)  'oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_Enviar
                frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Value
                frm.iCodArea = (dgvDatos.CurrentRow.Cells("CodArea").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al ENVIAR el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        'Try
        '    If dgvDatos.RowCount > 0 Then
        '        If MsgBox("¿Estas seguro de ENVIAR el Provisional N° " & dgvDatos.CurrentRow.Cells("IdProvisional").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
        '            Dim estado_process As Boolean
        '            estado_process = oProvisionalService.Enviar(dgvDatos.CurrentRow.Cells("IdProvisional").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        '            If estado_process Then
        '                MsgBox("Se Envio correctamente el Provisional")
        '                Actualizar()
        '            Else
        '                MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
        '            End If
        '        End If
        '    Else
        '        MsgBox("No existen datos, Verifique...")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try        
    End Sub

    Private Sub biAtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.Click, miAtender.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ATENDER el Provisional N°: " & dgvDatos.CurrentRow.Cells("IdProvisional").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oProvisionalService.Atender(dgvDatos.CurrentRow.Cells("IdProvisional").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Atendió correctamente el Provisional")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                    End If
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biCerrar.Click, miCerrar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_Cierre
                frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al CERRAR el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try        
    End Sub

    Private Sub biRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biRechazar.Click, miRechazar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_Rechazar
                frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al RECHAZAR el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAtenderMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAtenderMasivo.Click
        Try            
            Dim frm As New frmProvisional_Atender_Masivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If       
        Catch ex As Exception
            MsgBox("Error al ATENDER MASIVO el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerarArchivo_Click(sender As Object, e As EventArgs) Handles biGenerarArchivo.Click
        Try
            Dim frm As New frmProvisional_GenerarArchivo
            'frm.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                'RowPossesion(dgvDatos, frm.IdPlanilla)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biTramitar_Click(sender As System.Object, e As System.EventArgs) Handles biTramitar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_Tramitar
                frm.IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al poner EN TRAMITE el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarFecTermino_Click(sender As Object, e As EventArgs) Handles biActualizarFecTermino.Click, miActualizarFecTermino.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_ActFecTermino
                frm.IdProvisional = toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la Fecha de Termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biActualizarOT_Click(sender As Object, e As EventArgs) Handles biActualizarOT.Click, miActualizarOT.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_ActOT
                frm.IdProvisional = toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la OT : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biFechaTerminoMant_Click(sender As Object, e As EventArgs) Handles biFechaTerminoMant.Click, miFechaTerminoMant.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProvisional_FechaTerminoMant
                frm.IdProvisional = toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la Fecha Termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biAprobarFecTermino_Click(sender As Object, e As EventArgs) Handles biAprobarFecTermino.Click, miAprobarFecTermino.Click

        Try
            If ValidaCodigoSeleccionado() Then

                Dim buscarfechatermino As Boolean
                buscarfechatermino = oProvisionalService.BuscarEnviadoExtensionFecha(dgvDatos.CurrentRow.Cells("IdProvisional").Text)

                If buscarfechatermino Then

                    Dim frm As New frmProvisional_FechaTermino_AprobarFecTermino
                    frm.IdProvisional = toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text)
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        biRefrescar_Click(sender, e)
                    End If

                Else
                    MsgBox("El provisional no tiene una extension de fecha termino por Aprobar/Rechazar. ", MsgBoxStyle.Information)

                End If

            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la Fecha Termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class