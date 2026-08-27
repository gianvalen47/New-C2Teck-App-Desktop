Imports System.Windows.Forms

Public Class frmCarteraClientes_Agregar

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVendedorClienteService As New VendedorClienteService.VendedorClienteServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdPer As Integer
    Public IdCliente As Integer
    Public GruVen As String
    Public GruAlm As String

    'Private Sub txtCliente_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyPress
    '    If e.KeyCode = Keys.F12 Then
    '        If btnBuscarCliente.Enabled = True Then
    '            btnBuscarCliente_Click(sender, e)
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtVendedor.KeyPress _
                          , cmbGruVen.KeyPress
        '  txtFecAsig.KeyPress _
        ' , txtObservacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCarteraClientes_Agregar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            Me.btnGuardar.Location = New System.Drawing.Point(326, 156)
            Me.btnEliminar.Location = New System.Drawing.Point(400, 156)
            ObtenerRegistro()
            btnBuscarCliente.Enabled = False
            cmbGruVen.ReadOnly = True
            cmbGruVen.BackColor = System.Drawing.SystemColors.Control
            'cmbGruAlm.ReadOnly = True
            'cmbGruAlm.BackColor = System.Drawing.SystemColors.Control
        Else                    'Nuevo
            'txtFecAsig.Value = Today
            txtFecAsig.Value = Session.sFecha
            btnEliminar.Visible = False
            Me.btnGuardar.Location = New System.Drawing.Point(400, 156)
            txtVendedor.Text = oMaestroService.MostrarNombrePersona(IdPer)
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oVendedorClienteService) = False Then
                oVendedorClienteService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub txtFecAsig_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecAsig.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Focus()
            End If
        End If
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtCliente.KeyUp _
                         , txtFecAsig.KeyUp
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPer) = 0 Then
                MsgBox("Debe Ingresar el vendedor.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(txtFecAsig.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecAsig.BackColor = Color.Red
                txtFecAsig.Focus()
                Return False
            ElseIf toBlank(cmbGruVen.Text) = "" Then
                MsgBox("Debe Ingresar el grupo de ventas", MsgBoxStyle.Information, "Información")
                cmbGruVen.BackColor = Color.Red
                cmbGruVen.Focus()
                Return False
                'ElseIf toBlank(cmbGruAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar el Grupo de Almacenes", MsgBoxStyle.Information, "Información")
                '    cmbGruAlm.BackColor = Color.Red
                '    cmbGruAlm.Focus()
                '    Return False
            ElseIf state_button = False And oVendedorClienteService.Buscar(Session.sCodEmp, cmbGruVen.Value, IdPer, IdCliente) = True Then
                MsgBox("El Cliente " + txtCliente.Text + " ya existe en el grupo del vendedor...!", MsgBoxStyle.Information, "Información")
                btnBuscarCliente.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As VendedorClienteService.VendedorCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oVendedorClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As VendedorClienteService.VendedorCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oVendedorClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oVendedorClienteService.Borrar(Session.sCodEmp, cmbGruVen.Value, IdPer, IdCliente)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As VendedorClienteService.VendedorCliente
            registro = oVendedorClienteService.MostrarPorId(Session.sCodEmp, GruVen, IdPer, IdCliente)

            IdPer = registro.Persona.IdPer
            txtVendedor.Text = registro.Persona.ApeNom
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbGruVen.Value = registro.GrupoVenta.GruVen
            'cmbGruAlm.Value = registro.GrupoAlmacen.GruAlm
            txtFecAsig.Text = registro.FecAsig
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= GRUPO DE VENTA ================================================
            dtDatos = oMaestroService.MostrarGrupoVentas.Tables(0)
            cmbGruVen.DataSource = dtDatos
            cmbGruVen.DropDownList.DataMember = dtDatos.Columns("DesVen").ToString
            cmbGruVen.DropDownList.DisplayMember = dtDatos.Columns("DesVen").ToString
            cmbGruVen.DropDownList.ValueMember = dtDatos.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(0).DataMember = dtDatos.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(1).DataMember = dtDatos.Columns("DesVen").ToString
            dtDatos = Nothing

            '======================================= GRUPO DE VENTA ================================================
            'dtDatos = oMaestroService.MostrarGrupoAlmacen.Tables(0)
            'cmbGruAlm.DataSource = dtDatos
            'cmbGruAlm.DropDownList.DataMember = dtDatos.Columns("DesGru").ToString
            'cmbGruAlm.DropDownList.DisplayMember = dtDatos.Columns("DesGru").ToString
            'cmbGruAlm.DropDownList.ValueMember = dtDatos.Columns("GruAlm").ToString
            'cmbGruAlm.DropDownList.Columns(0).DataMember = dtDatos.Columns("GruAlm").ToString
            'cmbGruAlm.DropDownList.Columns(1).DataMember = dtDatos.Columns("DesGru").ToString
            'dtDatos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New VendedorClienteService.VendedorCliente
            Dim persona As New VendedorClienteService.Persona
            Dim cliente As New VendedorClienteService.Cliente
            Dim grupo As New VendedorClienteService.GrupoVenta
            Dim empresa As New VendedorClienteService.Empresa
            ' Dim grupoalmacen As New VendedorClienteService.GrupoAlmacen

            persona.IdPer = IdPer
            registro.Persona = persona
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            grupo.GruVen = cmbGruVen.Value
            registro.GrupoVenta = grupo
            'grupoalmacen.GruAlm = cmbGruAlm.Value
            empresa.CodEmp = Session.sCodEmp
            registro.Empresa = empresa
            ' registro.GrupoAlmacen = grupoalmacen
            registro.FecAsig = txtFecAsig.Text
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If toNumber(IdPer) <> 0 And toNumber(IdCliente) <> 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        cmbGruVen.Select()
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Select()
            btnGuardar_Click(sender, e)
        End If
    End Sub

End Class
