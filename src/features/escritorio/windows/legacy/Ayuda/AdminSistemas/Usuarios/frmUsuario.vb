Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmUsuario

    '===========================Servicios====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public CodUsu As String                        'CodUsu de Usuario Seleccionado
    Private IdPersona As Integer                   'IdPersona de Colaborador Seleccionado
    Private dtOficinas As DataTable

    Private dtSistemas As DataTable
    Private dtLocaciones As DataTable
    Private dtCentroCostos As DataTable
    Private dtRubroRecurso As DataTable
    Private Clave As String = ""

    Private Sub frmUsuario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvSistemas)
        estilo.CargaEstiloGrid(dgvLocaciones)

        dgvSistemas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvLocaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        If state_button Then    'Modificar 
            If edicion = False Then
                desactivar()
            Else
                activar()
            End If
            ObtenerRegistro()
            TabOpciones.Visible = True
            Me.Size = New System.Drawing.Size(679, 480)
            dgvSistemas.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(679, 224)
            TabOpciones.Visible = False
            Me.Text = "Registrar nuevo Usuario"
            txtFechaCreacion.Value = Today
            activar()
            txtCodUsu.Focus()
        End If
    End Sub

    Private Sub frmUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtCodUsu.KeyPress _
                            , txtClave.KeyPress _
                            , txtCodbarra.KeyPress _
                            , txtColaborador.KeyPress _
                            , cmbOficina.KeyPress _
                            , txtEmail.KeyPress _
                            , cbVigente.KeyPress _
                            , cbSeteo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtColaborador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColaborador.TextChanged
        Persona = oPersonaService.Obtener(IdPersona)
        txtArea.Text = Persona.CentroCosto.Area.DesArea
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficina.DataSource = dtOficinas
            cmbOficina.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficina.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficina.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficina.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficina.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficina.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            TabOpciones.Enabled = IIf(state_button = True And edicion = False, True, False)

            biEditar.Enabled = IIf(editable, Not edicion, False)
            biSalir.Enabled = Not edicion
            biGuardar.Enabled = edicion
            biDeshacer.Enabled = edicion
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub activar()
        If state_button Then
            txtCodUsu.ReadOnly = True
            txtCodUsu.BackColor = System.Drawing.SystemColors.Control
            txtClave.ReadOnly = False
            txtClave.BackColor = System.Drawing.SystemColors.Window
            txtCodbarra.ReadOnly = False
            txtCodbarra.BackColor = System.Drawing.SystemColors.Window
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = True
            cmbOficina.ReadOnly = False
            cmbOficina.BackColor = System.Drawing.SystemColors.Window
            txtEmail.ReadOnly = False
            txtEmail.BackColor = System.Drawing.SystemColors.Window
            lblFecModificacion.Visible = True
            txtFecMod.Visible = True
            cbVigente.Enabled = True
            cbSeteo.Enabled = True
            cbAlertas.Enabled = True
            edicion = True
            enableOpciones()
            txtClave.Focus()
        Else
            txtCodUsu.ReadOnly = False
            txtCodUsu.BackColor = System.Drawing.SystemColors.Window
            txtClave.ReadOnly = False
            txtClave.BackColor = System.Drawing.SystemColors.Window
            txtCodbarra.ReadOnly = False
            txtCodbarra.BackColor = System.Drawing.SystemColors.Window
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = True
            cmbOficina.ReadOnly = False
            cmbOficina.BackColor = System.Drawing.SystemColors.Window
            txtEmail.ReadOnly = False
            txtEmail.BackColor = System.Drawing.SystemColors.Window
            lblFecModificacion.Visible = False
            txtFecMod.Visible = False
            cbVigente.Enabled = True
            cbSeteo.Enabled = True
            cbAlertas.Enabled = True
            edicion = True
            enableOpciones()
            txtCodUsu.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtCodUsu.ReadOnly = True
        txtCodUsu.BackColor = System.Drawing.SystemColors.Control
        txtClave.ReadOnly = True
        txtClave.BackColor = System.Drawing.SystemColors.Control
        txtCodbarra.ReadOnly = True
        txtCodbarra.BackColor = System.Drawing.SystemColors.Control
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersona.Enabled = False
        cmbOficina.ReadOnly = True
        cmbOficina.BackColor = System.Drawing.SystemColors.Control
        txtEmail.ReadOnly = True
        txtEmail.BackColor = System.Drawing.SystemColors.Control
        lblFecModificacion.Visible = True
        txtFecMod.Visible = True
        cbVigente.Enabled = False
        cbSeteo.Enabled = False
        cbAlertas.Enabled = False
        edicion = False
        enableOpciones()
        txtCodUsu.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodUsu.Text) = "" Then
                MsgBox("Debe Ingresar el Usuario.", MsgBoxStyle.Information, "Información")
                txtCodUsu.Focus()
                Return False
            ElseIf toBlank(txtClave.Text) = "" Then
                MsgBox("Debe Ingresar la Clave", MsgBoxStyle.Information, "Información")
                txtClave.Focus()
                Return False
            ElseIf toNumber(IdPersona) = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                btnBuscarPersona.Focus()
                Return False
            ElseIf toBlank(cmbOficina.Value) = "" Then
                MsgBox("Debe de Ingresar la Oficina.", MsgBoxStyle.Information, "Información")
                cmbOficina.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SeguridadService.Usuario
            registro = oSeguridadService.MostrarUsuarioPorCodigo(CodUsu)

            CodUsu = registro.CodUsu
            txtCodUsu.Text = registro.CodUsu
            txtClave.Text = registro.Clave
            Clave = registro.Clave
            txtCodbarra.Text = registro.CodBarras
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbOficina.Value = registro.Oficina.CodOfi
            txtFechaCreacion.Value = registro.FecCreacion
            txtEmail.Text = registro.Email
            txtArea.Text = registro.Persona.CentroCosto.Area.DesArea
            txtFecMod.Value = registro.FecMod
            cbVigente.Checked = registro.Vigente
            cbSeteo.Checked = registro.Seteo
            cbAlertas.Checked = registro.RecibeAlerta

            ListarSistemas()
            ObtenerPermisos()
            ListarLocaciones()
            ListarCentroCostos()
            ListarRubrosRecurso()

            Me.Text = "Usuario: " + registro.CodUsu + " Colaborador: " + registro.Persona.ApeNom
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbOficina.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SeguridadService.Usuario)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.InsertarUsuario(registro)
            type_process = "insert"
            If estado_process = True Then
                CodUsu = txtCodUsu.Text
                MsgBox("Se inserto el UsuarioCorrectamente")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SeguridadService.Usuario)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.ActualizarUsuario(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Usuario Correctamente")
                desactivar()
                ObtenerRegistro()
                ListarSistemas()
                ObtenerPermisos()
                ListarLocaciones()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New SeguridadService.Usuario
                Dim Persona As New SeguridadService.Persona
                Dim Oficina As New SeguridadService.Oficina

                registro.CodUsu = txtCodUsu.Text


                If Clave = txtClave.Text Then
                    registro.Clave = Clave
                Else
                    registro.Clave = Encriptar(txtClave.Text, txtClave.Text)
                End If

                registro.CodBarras = txtCodbarra.Text
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                Oficina.CodOfi = cmbOficina.Value
                registro.Oficina = Oficina
                registro.FecCreacion = txtFechaCreacion.Value
                registro.Email = txtEmail.Text
                registro.Vigente = IIf(cbVigente.Checked = True, True, False)
                registro.Seteo = IIf(cbSeteo.Checked = True, True, False)
                registro.RecibeAlerta = cbAlertas.Checked
                registro.CodUsuTrans = Session.sCodUsu

                If state_button Then            'Modificar                
                    registro.FecMod = txtFecMod.Value
                    Modificar(registro)
                Else                                  'Nuevo                    
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            txtCodUsu.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub EnableOptionsOptions()
        Try
            If dgvSistemas.RowCount > 0 Then
                miEliminarSis.Enabled = True                
            Else
                miEliminarSis.Enabled = False
            End If

            If oSeguridadService.BuscarPermiso(CodUsu) Then
                miNuevoPer.Enabled = False
                miMostrarPer.Enabled = True

                tbLocaciones.Enabled = True
                tbCentroCostos.Enabled = True
                tbRubroRecurso.Enabled = True
            Else
                miNuevoPer.Enabled = True
                miMostrarPer.Enabled = False

                tbLocaciones.Enabled = False
                tbCentroCostos.Enabled = False
                tbRubroRecurso.Enabled = False
            End If

            If dgvLocaciones.RowCount > 0 Then
                miEliminarLoc.Enabled = True
            Else
                miEliminarLoc.Enabled = False
            End If

            If dgvCentroCosto.RowCount > 0 Then
                miEliminarCentro.Enabled = True
            Else
                miEliminarCentro.Enabled = False
            End If

            If dgvRubroRecurso.RowCount > 0 Then
                miEliminarRubRecurso.Enabled = True
            Else
                miEliminarRubRecurso.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    '======================================================================================
    '--------------------------------------------------------------------------- SISTEMAS ------------------------------------------------------------------------------
    '======================================================================================

    Private Sub ListarSistemas()
        Try
            dtSistemas = oSeguridadService.MostrarUsuarioSistema(CodUsu).Tables(0)
            dgvSistemas.DataSource = dtSistemas
            EnableOptionsOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR SISTEMAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionSis(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdSistema").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] SISTEMAS: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevoSis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoSis.Click
        Try
            Dim frm As New frmUsuarioSistema
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarSistemas()
                ObtenerPermisos()
                RowPossesionSis(dgvSistemas, frm.IdSistema)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR AL INGRESAR NUEVO SISTEMA")
        End Try
    End Sub

    Private Sub miEliminarSis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarSis.Click
        Try
            cmbOpSistemas.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguridadService.BorrarUsuarioSistema(CodUsu, toNumber(dgvSistemas.CurrentRow.Cells("IdSistema").Value))
                If estado_process = True Then
                    dtSistemas = Nothing
                    ListarSistemas()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR SISTEMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAsignarSistemas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignarSistemas.Click
        Try
            Dim frm As New frmUsuarioSistemas
            frm.CodUsu = CodUsu
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarSistemas()
                ObtenerPermisos()
            End If
            ListarSistemas()
            ObtenerPermisos()
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR SISTEMAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '======================================================================================
    '--------------------------------------------------------------------------- PERMISOS ------------------------------------------------------------------------------
    '======================================================================================

    Private Sub ObtenerPermisos()
        Try
            If oSeguridadService.BuscarPermiso(CodUsu) Then
                Dim registro As New SeguridadService.PermisoUsuario
                registro = oSeguridadService.MostrarPermisos(CodUsu)

                txtPerfil.Text = registro.Perfil.Nombre
                ckTipCam.Checked = registro.TipCam
                ckCartera.Checked = registro.Cartera
                ckPerPrecio.Checked = registro.Precio
                ckPerPrecioFOB.Checked = registro.PrecioFob
                ckPrecioFlete.Checked = registro.Flete
                ckGastoGerencia.Checked = registro.GastoGerencia
                ckVendeOficina.Checked = registro.VendeOficina
                ckVerPrecios.Checked = registro.VerPrecios
                ckVerGastos.Checked = registro.VerGastos

                If registro.TipFac = "2" Then
                    rbTipFacCon.Checked = True
                ElseIf registro.TipFac = "1" Then
                    rbTipFacCre.Checked = True
                ElseIf registro.TipFac = "0" Then
                    rbTipFacTodos.Checked = True
                End If
            End If
            EnableOptionsOptions()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER PERMISOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoPer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoPer.Click
        Try
            Dim frm As New frmUsuarioPermisos
            frm.CodUsu = txtCodUsu.Text
            frm.state_button = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ObtenerPermisos()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR PERMISOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarPer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarPer.Click
        Try
            Dim frm As New frmUsuarioPermisos
            frm.CodUsu = txtCodUsu.Text
            frm.state_button = True
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ObtenerPermisos()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PERMISOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '======================================================================================
    '------------------------------------------------------------------------- LOCACIONES ----------------------------------------------------------------------------
    '======================================================================================

    Private Sub ListarLocaciones()
        Try
            dtLocaciones = oSeguridadService.MostrarLocacionUsuario(CodUsu).Tables(0)
            dgvLocaciones.DataSource = dtLocaciones
            EnableOptionsOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOCACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionLoc(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdLocacion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] LOCACIONES: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevoLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoLoc.Click
        Try
            Dim frm As New frmUsuarioLocacion
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarLocaciones()
                RowPossesionLoc(dgvLocaciones, frm.IdLocacion)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR AL INGRESAR NUEVA LOCACION")
        End Try
    End Sub

    Private Sub miEliminarLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarLoc.Click
        Try
            cmbOpLocacion.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguridadService.BorrarLocacionUsuario(CodUsu, toNumber(dgvLocaciones.CurrentRow.Cells("IdLocacion").Value))
                If estado_process = True Then
                    dtLocaciones = Nothing
                    ListarLocaciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LOCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAsignarLocaciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignarLocaciones.Click
        Try
            Dim frm As New frmUsuarioLocaciones
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarLocaciones()
            End If
            ListarLocaciones()
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR LOCACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '======================================================================================
    '------------------------------------------------------------------- CENTRO DE COSTOS ----------------------------------------------------------------------
    '======================================================================================

    Private Sub ListarCentroCostos()
        Try
            dtCentroCostos = oSeguridadService.MostrarCentroCosto(CodUsu).Tables(0)
            dgvCentroCosto.DataSource = dtCentroCostos
            EnableOptionsOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CENTRO DE COSTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionCent(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("CodCentro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevoCentro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoCentro.Click
        Try
            Dim frm As New frmUsuarioCentroCosto
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarCentroCostos()
                RowPossesionCent(dgvCentroCosto, frm.CodCentro)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR AL INGRESAR NUEVO CENTRO DE COSTO")
        End Try
    End Sub

    Private Sub miEliminarCentro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarCentro.Click
        Try
            cmbOpCentroCostos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguridadService.BorrarCentroCosto(CodUsu, dgvCentroCosto.CurrentRow.Cells("CodCentro").Value)
                If estado_process = True Then
                    dtCentroCostos = Nothing
                    ListarCentroCostos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAsignarCentrosCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignarCentrosCosto.Click
        Try
            Dim frm As New frmUsuarioCentrosCosto
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarCentroCostos()
            End If
            ListarCentroCostos()
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR CENTROS DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '======================================================================================
    '--------------------------------------------------------------------- RUBRO RECURSO ------------------------------------------------------------------------
    '======================================================================================

    Private Sub ListarRubrosRecurso()
        Try
            dtRubroRecurso = oSeguridadService.MostrarRubroRecurso(CodUsu).Tables(0)
            dgvRubroRecurso.DataSource = dtRubroRecurso
            EnableOptionsOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR RUBRO RECURSOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionRubRecurso(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] RUBRO RECURSO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevoRubRecurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoRubRecurso.Click
        Try
            Dim frm As New frmUsuarioRubroRecurso
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarRubrosRecurso()
                RowPossesionRubRecurso(dgvRubroRecurso, frm.IdRubro)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR AL INGRESAR NUEVO RUBRO DE RECURSO")
        End Try
    End Sub

    Private Sub miEliminarRubRecurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarRubRecurso.Click
        Try
            cmbOpRubRecurso.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguridadService.BorrarRubroRecurso(CodUsu, toNumber(dgvRubroRecurso.CurrentRow.Cells("IdRubro").Value))
                If estado_process = True Then
                    dtRubroRecurso = Nothing
                    ListarRubrosRecurso()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR RUBRO DE RECURSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAsignarRubroRecurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignarRubroRecurso.Click
        Try
            Dim frm As New frmUsuarioRubrosRecursos
            frm.CodUsu = txtCodUsu.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListarRubrosRecurso()
            End If
            ListarRubrosRecurso()
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR RUBROS DE RECURSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
