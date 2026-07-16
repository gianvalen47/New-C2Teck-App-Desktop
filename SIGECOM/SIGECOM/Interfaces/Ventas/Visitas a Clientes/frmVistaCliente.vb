Imports System.Windows.Forms

Public Class frmVistaCliente

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public cancelado As Boolean
    Private resul As Boolean
    Private mot As Boolean
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private dtDatos As DataTable
    Private dtResultados As DataTable
    Private dtMotivo As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdVisita As Integer
    Private IdCliente As Integer
    Private dtGruposVenta As DataTable
    Private dtContactos As DataTable
    Private dtVendedores As DataTable
    Private dtTiposVisitas As DataTable

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub


    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtFecha.KeyPress _
                        , txtCliente.KeyPress _
                        , cmbGruVen.KeyPress _
                        , cmbIdTipoVisita.KeyPress _
                        , cmbIdContacto.KeyPress _
                        , cmbMotivo.KeyPress _
                        , cmbResultado.KeyPress
        ', txtObservacion.KeyPress _
        ', cmbIdPer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmVistaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(474, 200)
            'Me.btnEliminar.Location = New System.Drawing.Point(548, 200)
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            If cancelado Then
                biEditar.Enabled = False
                biDeshacer.Enabled = False
                biGuardar.Enabled = True
                biSalir.Enabled = True
                gbDatos.Enabled = False
                Me.cmbMotivo.Location = New System.Drawing.Point(79, 16)
                Me.lblMotivo.Location = New System.Drawing.Point(4, 20)
                Me.txtObservacion.Location = New System.Drawing.Point(79, 39)
                Me.lblObservacion.Location = New System.Drawing.Point(0, 43)
                cmbResultado.Visible = False
                lblResultado.Visible = False
                cmbMotivo.Enabled = True
                cmbMotivo.Visible = True
                lblMotivo.Visible = True
                If toNumber(cmbMotivo.Value) = 0 Then
                    cmbMotivo.Clear()
                End If
                gbEstado.Visible = False
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                cmbMotivo.Select()
                Me.Text = "Ingrese el Motivo de la Cancelación de la Visita al cliente " + Chr(34) + txtCliente.Text + Chr(34)
            Else
                If lblEstado.Text <> "NO EJECUTADO" Then
                    'Me.btnEliminar.Location = New System.Drawing.Point(548, 200)
                    Me.txtObservacion.Location = New System.Drawing.Point(79, 39)
                    Me.lblObservacion.Location = New System.Drawing.Point(0, 43)
                    cmbMotivo.Visible = False
                    lblMotivo.Visible = False
                Else
                    Me.cmbMotivo.Location = New System.Drawing.Point(79, 16)
                    Me.lblMotivo.Location = New System.Drawing.Point(4, 20)
                    Me.txtObservacion.Location = New System.Drawing.Point(79, 39)
                    Me.lblObservacion.Location = New System.Drawing.Point(0, 43)
                End If
                Me.Text = "Visita al cliente" + Chr(34) + txtCliente.Text + Chr(34)
            End If


        Else                    'Nuevo
            'btnEliminar.Visible = False
            'Me.btnGuardar.Location = New System.Drawing.Point(548, 200)
            btnBuscarCliente.Select()
            cmbResultado.Enabled = False
            cmbMotivo.Enabled = False
            cmbResultado.Visible = False
            cmbMotivo.Visible = False
            lblMotivo.Visible = False
            lblResultado.Visible = False
            biEditar.Enabled = False
            biSalir.Enabled = False
            gbEstado.Visible = False
            Me.Size = New System.Drawing.Size(742, 175)
            Me.Text = "Registrar nueva Visita al Cliente"
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oVisitaClienteService) = False Then
                oVisitaClienteService.Close()
            End If
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                         cmbGruVen.ValueChanged _
                        , cmbIdTipoVisita.ValueChanged _
                        , cmbIdPer.ValueChanged _
                        , cmbIdContacto.ValueChanged
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub enableOpciones()
        biGuardar.Enabled = False
        biDeshacer.Enabled = False
        If lblEstado.Text = "PROGRAMADO" Then
            biEditar.Enabled = True
        Else
            biEditar.Enabled = False
        End If
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe de ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(cmbGruVen.Value) = 0 Then
                MsgBox("Debe de ingresar el grupo de venta.", MsgBoxStyle.Information, "Información")
                cmbGruVen.BackColor = Color.Red
                cmbGruVen.Focus()
                Return False
            ElseIf toNumber(cmbIdContacto.Value) = 0 Then
                MsgBox("Debe de ingresar el contacto.", MsgBoxStyle.Information, "Información")
                cmbIdContacto.BackColor = Color.Red
                cmbIdContacto.Focus()
                Return False
            ElseIf toNumber(cmbIdTipoVisita.Value) = 0 Then
                MsgBox("Debe de ingresar el tipo de venta.", MsgBoxStyle.Information, "Información")
                cmbIdTipoVisita.BackColor = Color.Red
                cmbIdTipoVisita.Focus()
                Return False
            ElseIf toNumber(cmbIdPer.Value) = 0 Then
                MsgBox("Debe de ingresar el vendedor.", MsgBoxStyle.Information, "Información")
                cmbIdPer.BackColor = Color.Red
                cmbIdPer.Focus()
                Return False
            ElseIf cmbResultado.Visible = True And toNumber(cmbResultado.Value) = 0 Then
                MsgBox("Debe de ingresar el resultado.", MsgBoxStyle.Information, "Información")
                cmbResultado.BackColor = Color.Red
                cmbResultado.Focus()
                Return False
            ElseIf cmbMotivo.Visible = True And toNumber(cmbMotivo.Value) = 0 Then
                MsgBox("Debe de ingresar el motivo de la cancelación.", MsgBoxStyle.Information, "Información")
                cmbMotivo.BackColor = Color.Red
                cmbMotivo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As VisitaClienteService.VisitaCliente)
        Try
            Dim estado_process As Integer
            estado_process = oVisitaClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdVisita = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As VisitaClienteService.VisitaCliente)
        Try
            Dim estado_process As Boolean
            If mot Then
                estado_process = oVisitaClienteService.CancelarVisita(IdVisita, cmbMotivo.Value, txtObservacion.Text, Session.sCodUsu)
                If estado_process Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            ElseIf resul Then
                estado_process = oVisitaClienteService.ActualizarResultado(IdVisita, cmbResultado.Value, txtObservacion.Text, Session.sCodUsu)
                type_process = "resultado"
                If estado_process Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
                estado_process = oVisitaClienteService.Actualizar(registro)
                type_process = "update"
                If estado_process = True Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        cmbResultado.ReadOnly = False
        cmbResultado.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        biGuardar.Enabled = True
        biDeshacer.Enabled = True
        biEditar.Enabled = False
        cmbResultado.Select()
    End Sub
    Private Sub desactivar()
        btnBuscarCliente.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        cmbGruVen.ReadOnly = True
        cmbGruVen.BackColor = System.Drawing.SystemColors.Control
        cmbIdContacto.ReadOnly = True
        cmbIdContacto.BackColor = System.Drawing.SystemColors.Control
        cmbIdPer.ReadOnly = True
        cmbIdPer.BackColor = System.Drawing.SystemColors.Control
        cmbIdTipoVisita.ReadOnly = True
        cmbIdTipoVisita.BackColor = System.Drawing.SystemColors.Control
        cmbResultado.ReadOnly = True
        cmbResultado.BackColor = System.Drawing.SystemColors.Control
        If toNumber(cmbResultado.Value) = 0 Then
            cmbResultado.Clear()
        End If
        If lblEstado.Text = "NO EJECUTADO" Then
            cmbMotivo.ReadOnly = True
            cmbMotivo.BackColor = System.Drawing.SystemColors.Control
            cmbMotivo.Visible = True
            lblMotivo.Visible = True
            cmbResultado.Visible = False
            lblResultado.Visible = False
        Else
            cmbMotivo.Enabled = False
            cmbMotivo.Visible = False
            lblMotivo.Visible = False
        End If

    End Sub
    'Private Sub Eliminar()
    '    Try
    '        Dim estado_process As Boolean
    '        estado_process = oVisitaClienteService.Borrar(IdVisita)
    '        type_process = "delete"
    '        If estado_process = True Then
    '            Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Else
    '            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As VisitaClienteService.VisitaCliente
            registro = oVisitaClienteService.MostrarPorId(toNumber(IdVisita))

            IdVisita = registro.IdVisita
            txtFecha.Text = registro.Fecha
            txtCliente.Text = registro.Contacto.Cliente.DesCli
            IdCliente = registro.Contacto.Cliente.IdCliente
            listarContactos()

            cmbIdContacto.Value = registro.Contacto.IdContacto
            cmbIdTipoVisita.Value = registro.TipoVisita.IdTipoVisita
            cmbIdPer.Value = registro.Persona.IdPer
            cmbGruVen.Value = registro.GrupoVenta.GruVen
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = registro.Estado
            cmbResultado.Value = registro.TipoResultadoVisita.IdResultado
            cmbMotivo.Value = registro.TipoCancelacionVisita.IdCancelacion
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= GRUPOS DE VENTA ================================================
            dtGruposVenta = oMaestroService.MostrarGrupoVentas.Tables(0)
            'dtGruposVenta.Rows.InsertAt(getRowTodos(dtGruposVenta), 0)
            cmbGruVen.DataSource = dtGruposVenta
            cmbGruVen.DropDownList.DataMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.DropDownList.DisplayMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.DropDownList.ValueMember = dtGruposVenta.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(0).DataMember = dtGruposVenta.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(1).DataMember = dtGruposVenta.Columns("DesVen").ToString
            dtGruposVenta = Nothing
            '======================================= TIPO DE VISITA ================================================
            dtTiposVisitas = oVisitaClienteService.MostrarTipoVisita.Tables(0)
            'dtTiposVisitas.Rows.InsertAt(getRowTodos(dtTiposVisitas), 0)
            cmbIdTipoVisita.DataSource = dtTiposVisitas
            cmbIdTipoVisita.DropDownList.DataMember = dtTiposVisitas.Columns("DesTipo").ToString
            cmbIdTipoVisita.DropDownList.DisplayMember = dtTiposVisitas.Columns("DesTipo").ToString
            cmbIdTipoVisita.DropDownList.ValueMember = dtTiposVisitas.Columns("IdTipoVisita").ToString
            cmbIdTipoVisita.DropDownList.Columns(0).DataMember = dtTiposVisitas.Columns("IdTipoVisita").ToString
            cmbIdTipoVisita.DropDownList.Columns(1).DataMember = dtTiposVisitas.Columns("DesTipo").ToString
            dtTiposVisitas = Nothing
            '======================================= VENDEDORES ================================================
            dtDatos = oMaestroService.MostrarVendedores.Tables(0)
            cmbIdPer.DataSource = dtDatos
            cmbIdPer.DropDownList.DataMember = dtDatos.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.DisplayMember = dtDatos.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.ValueMember = dtDatos.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(0).DataMember = dtDatos.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(1).DataMember = dtDatos.Columns("ApeNom").ToString
            dtDatos = Nothing
            '======================================= RESULTADOS ================================================
            dtResultados = oVisitaClienteService.MostrarTipoResultadoVisita.Tables(0)
            cmbResultado.DataSource = dtResultados
            cmbResultado.DropDownList.DataMember = dtResultados.Columns("Nombre").ToString
            cmbResultado.DropDownList.DisplayMember = dtResultados.Columns("Nombre").ToString
            cmbResultado.DropDownList.ValueMember = dtResultados.Columns("IdResultado").ToString
            cmbResultado.DropDownList.Columns(0).DataMember = dtResultados.Columns("IdResultado").ToString
            cmbResultado.DropDownList.Columns(1).DataMember = dtResultados.Columns("Nombre").ToString
            dtResultados = Nothing
            '======================================= MOTIVO CANCELACIÓN ================================================
            dtMotivo = oVisitaClienteService.MostrarTipoCancelacionVisita().Tables(0)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdCancelacion").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdCancelacion").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("Nombre").ToString
            dtMotivo = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listarContactos()
        '======================================= CONTACTOS ================================================
        dtContactos = oContactoService.Mostrar(IdCliente).Tables(0)
        cmbIdContacto.DataSource = dtContactos
        cmbIdContacto.DropDownList.DataMember = dtContactos.Columns("Apellidos").ToString
        cmbIdContacto.DropDownList.DisplayMember = dtContactos.Columns("Apellidos").ToString
        cmbIdContacto.DropDownList.ValueMember = dtContactos.Columns("IdContacto").ToString
        cmbIdContacto.DropDownList.Columns(0).DataMember = dtContactos.Columns("IdContacto").ToString
        cmbIdContacto.DropDownList.Columns(1).DataMember = dtContactos.Columns("Apellidos").ToString
        cmbIdContacto.DropDownList.Columns(2).DataMember = dtContactos.Columns("Nombres").ToString
        dtContactos = Nothing
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    'Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    '    If MsgBox("¿Está seguro que desea eliminar el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '        Eliminar()
    '    End If
    'End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            listarContactos()

        End If
        txtCliente.Select()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else

                ObtenerRegistro()
                desactivar()
            End If
        End If
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

            Dim registro As New VisitaClienteService.VisitaCliente
            Dim contacto As New VisitaClienteService.Contacto
            Dim vendedor As New VisitaClienteService.Persona
            Dim tipo As New VisitaClienteService.TipoVisita
            Dim grupo As New VisitaClienteService.GrupoVenta
            Dim resultado As New VisitaClienteService.TipoResultadoVisita
            Dim motivo As New VisitaClienteService.TipoCancelacionVisita

            registro.IdVisita = IdVisita
            registro.Fecha = txtFecha.Text
            contacto.IdContacto = cmbIdContacto.Value
            registro.Contacto = contacto
            tipo.IdTipoVisita = cmbIdTipoVisita.Value
            registro.TipoVisita = tipo
            vendedor.IdPer = cmbIdPer.Value
            registro.Persona = vendedor
            grupo.GruVen = toNull(cmbGruVen.Value)
            registro.GrupoVenta = grupo
            registro.Observacion = toNull(txtObservacion.Text)
            If cmbResultado.Value <> 0 Then
                resultado.IdResultado = toNull(cmbResultado.Value)
                registro.TipoResultadoVisita = resultado
                'Dim resul As Boolean
                resul = True
            End If
            If cmbMotivo.Value <> 0 Then
                motivo.IdCancelacion = toNull(cmbMotivo.Value)
                registro.TipoCancelacionVisita = motivo
                'Dim mot As Boolean
                mot = True
            End If

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub cmbIdPer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIdPer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Visita."
    End Sub
    
    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Grabar los cambios hechos en la Visita."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los cambios hechos en la Visita."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario de Visita"
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                       biEditar.MouseLeave, biGuardar.MouseLeave, biDeshacer.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub
End Class
