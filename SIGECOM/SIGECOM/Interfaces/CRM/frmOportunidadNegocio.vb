Imports System.ServiceModel
Imports System.Net
Public Class frmOportunidadNegocio

    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oVisitaOportunidadService As New VisitaOportunidadService.VisitaOportunidadServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable

    Public iEtapa As Integer
    Public IdOportunidad As Integer
    Private dtDatos As New DataTable
    Private dtEtapa As DataTable
    Public IdCliente As Integer
    Private dtVendedor As DataTable
    Private dttable As DataTable

    Private Sub frmOportunidadNegocio_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEtapa.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "Oportunidad de Negocio Nº " + Chr(34) + txtIdOportunidad.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(635, 259)
            gbEtapa.Visible = False
            gbDetalle.Visible = False
            Me.Text = "Registrar nueva Oportunidad de Negocio"            
            activar()
            txtFecCierre.value = Today
            txtFecProbable.Value = Today
        End If
     
    End Sub

    Private Sub frmComOrdenCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
           oOportunidadNegocioService.Close()
            oVisitaOportunidadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
            oVisitaOportunidadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
         oOportunidadNegocioService.Abort()
            oVisitaOportunidadService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdVisita").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
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
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowVendedor(ByVal data As DataTable)
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

        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            ''======================================= Vendedor ===========================================
            'dtVendedor = oPersonaService.MostrarVendedoresVigente.Tables(0)
            'dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            'cmbVendedor.DataSource = dtVendedor
            'cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.SelectedIndex = 0
            'dtVendedor = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False            
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True  
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGrabar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(lblEtapa.Text <> "", Not edicion, False)
    End Sub

    Private Sub activar()
        txtIdOportunidad.ReadOnly = True
        txtIdOportunidad.BackColor = System.Drawing.SystemColors.Control
        txtFecProbable.ReadOnly = False
        txtFecProbable.BackColor = System.Drawing.SystemColors.Window
        txtNombre.ReadOnly = False
        txtNombre.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCliente.Enabled = True
        txtTipoProducto.ReadOnly = False
        txtTipoProducto.BackColor = System.Drawing.SystemColors.Window
        txtFecCierre.ReadOnly = False
        txtFecCierre.BackColor = System.Drawing.SystemColors.Window   
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window

        edicion = True
        enableOpciones()
        txtFecProbable.Focus()
    End Sub

    Private Sub desactivar()
        txtIdOportunidad.ReadOnly = True
        txtIdOportunidad.BackColor = System.Drawing.SystemColors.Control
        txtFecProbable.ReadOnly = True
        txtFecProbable.BackColor = System.Drawing.SystemColors.Control
        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        txtTipoProducto.ReadOnly = True
        txtTipoProducto.BackColor = System.Drawing.SystemColors.Control
        txtFecCierre.ReadOnly = True
        txtFecCierre.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        dgvDatos.Select()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try        
            If toBlank(txtFecProbable.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha Probable.", MsgBoxStyle.Information, "Información")
                txtFecProbable.Focus()
                Return False
            ElseIf toBlank(txtNombre.Text) = "" Then
                MsgBox("Debe de Ingresar el Nombre de la Oportunidad.", MsgBoxStyle.Information, "Información")
                txtNombre.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente ", MsgBoxStyle.Information, "Información")                
                btnBuscarCliente.Focus()
                Return False
                'ElseIf toNumber(cmbVendedor.Value) = 0 Then
                '    MsgBox("Debe Ingresar el Vendedor ", MsgBoxStyle.Information, "Información")
                '    cmbVendedor.Focus()
                '    Return False
            ElseIf toBlank(txtTipoProducto.Text) = "" Then
                MsgBox("Debe de Ingresar el Tipo Producto de la Oportunidad.", MsgBoxStyle.Information, "Información")
                txtTipoProducto.Focus()
                Return False
            ElseIf toBlank(txtFecCierre.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha Cierre.", MsgBoxStyle.Information, "Información")
                txtFecCierre.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OportunidadNegocioService.OportunidadNegocio
            registro = oOportunidadNegocioService.Obtener(IdOportunidad)
            IdOportunidad = registro.IdOportunidad
            txtIdOportunidad.Text = IdOportunidad
            txtFecProbable.Value = registro.FecProbable
            lblEtapa.Text = registro.EtapasNegocio.DesEtapa
            txtNombre.Text = registro.Nombre
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtVendedor.Text = registro.Persona.ApeNom
            txtTipoProducto.Text = registro.TipoProducto
            txtFecCierre.Value = registro.FecCierre
            txtDescripcion.Text = registro.Descripcion
            lblEtapa.Text = registro.EtapasNegocio.DesEtapa

            Me.Text = "Oportunidad de Negocio Nº " + registro.IdOportunidad.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmVisitaOportunidad
                frm.state_button = False
                frm.IdOportunidad = IdOportunidad
                frm.IdCliente = IdCliente
                If dgvDatos.RowCount > 0 Then               
                End If
                'frm.estado = 1
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdVisita)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA VISITA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la visita seleccionada?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oVisitaOportunidadService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdVisita").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmVisitaOportunidad
            frm.state_button = True
            frm.IdVisita = dgvDatos.CurrentRow.Cells("IdVisita").Text
            frm.IdOportunidad = IdOportunidad
            frm.IdCliente = IdCliente
            frm.iEtapa = iEtapa
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdVisita)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdVisita)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdVisita").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As OportunidadNegocioService.OportunidadNegocio)
        Try
            Dim estado_process As Integer
            estado_process = oOportunidadNegocioService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOportunidad = estado_process
                MsgBox("Se insertó la Oportunidad de Negocio Correctamente.")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR OPORTUNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As OportunidadNegocioService.OportunidadNegocio)
        Try
            Dim estado_process As Boolean
            estado_process = oOportunidadNegocioService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Oportunidad de Negocio Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR OPORTUNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oOportunidadNegocioService.Borrar(IdOportunidad, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR OPORTUNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oVisitaOportunidadService.Mostrar(toNumber(IdOportunidad)).Tables(0)
            dgvDatos.DataSource = dtDatos            
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdCliente = frm.codigo
                    txtCliente.Text = frm.descripcion
                    txtTipoProducto.Focus()
                Else
                    IdCliente = 0
                    txtCliente.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New OportunidadNegocioService.OportunidadNegocio
                Dim cliente As New OportunidadNegocioService.Cliente
                Dim etapa As New OportunidadNegocioService.EtapasNegocio                
                Dim empresa As New OportunidadNegocioService.Empresa
                Dim persona As New OportunidadNegocioService.Persona

                registro.IdOportunidad = IdOportunidad
                registro.FecProbable = txtFecProbable.Value
                registro.Nombre = toNull(txtNombre.Text)                
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
                registro.TipoProducto = toNull(txtTipoProducto.Text)
                registro.FecCierre = txtFecCierre.Value
                registro.Descripcion = toNull(txtDescripcion.Text)
                persona.IdPer = Nothing
                registro.Persona = persona

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If state_button Then            'Modificar                  
                    Modificar(registro)
                Else                                  'Nuevo                   
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR OPORTUNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario...?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
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

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdVisita").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        'If CInt(lblSolicitud.Text) = 0 Then
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)
            End If
        End If
        'End If
    End Sub

End Class