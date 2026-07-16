Imports System.ServiceModel
Public Class frmEmbarque_Nuevo

    '===========================Servicios====================================================
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient
    Private oEmbarqueDetService As New EmbarqueDetService.EmbarqueDetServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable    
    Public CodEmbarque As String
    Public dtMedios As DataTable
    Private dtDatos As DataTable
    Public IdProveedor As Integer

    Private Sub frmEmbarque_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        If state_button Then       'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstadoEmbarque.Visible = True
            gbDetalles.Visible = True
            actualizarDetalles()
            Me.Text = "Datos de Embarque"
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(769, 256)
            txtFecha.Value = Today
            txtNroIng.Text = oEmbarqueService.SugerirNroIng(Session.sCodEmp, Today.Year)
            gbDetalles.Visible = False
            gbEstadoEmbarque.Visible = False
            Me.Text = "Nuevo registro de Embarque"
            activar()
            txtCodEmbarque.Select()
            'txtFecLlenadoCont.Value = Today
        End If
    End Sub

    Private Sub frmEmbarque_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmHoraExtra_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
           oEmbarqueService.Close()
            oEmbarqueDetService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
            oEmbarqueDetService.Abort()
        Catch ex As CommunicationException
           oEmbarqueService.Abort()
            oEmbarqueDetService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdFactura").Value) = codigo Then
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

    Private Sub llenarCombos()
        Try

            '======================================= MEDIOS ================================================
            dtMedios = New DataTable
            dtMedios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMedios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtMedios.Rows.Add(New Object() {"A", "Aéreo"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"M", "Marinos"})
            dtMedios.Rows.Add(New Object() {"O", "Otros"})

            cmbMedio.DataSource = dtMedios
            cmbMedio.DropDownList.DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.DisplayMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.ValueMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(0).DataMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(1).DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.SelectedIndex = 0
            dtMedios = Nothing

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
            miEliminar.Enabled = IIf(editable, True, False)            
        End If
        miNuevo.Enabled = IIf(editable, True, False)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            txtCodEmbarque.ReadOnly = True
            txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            If dgvDatos.RowCount > 0 Then
                cmbMedio.ReadOnly = True
                cmbMedio.BackColor = System.Drawing.SystemColors.Control
            Else
                cmbMedio.ReadOnly = False
                cmbMedio.BackColor = System.Drawing.SystemColors.Window
            End If
            txtFecLlegada.ReadOnly = False
            txtFecLlegada.BackColor = System.Drawing.SystemColors.Window
            txtProveedor.ReadOnly = True
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            btnBuscarProveedor.Enabled = True
            txtNroIng.ReadOnly = False
            txtNroIng.BackColor = System.Drawing.SystemColors.Window
            txtTotalNeto.ReadOnly = False
            txtTotalNeto.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            txtInvoiceGE.ReadOnly = False
            txtInvoiceGE.BackColor = System.Drawing.SystemColors.Window
            txtTotalGE.ReadOnly = False
            txtTotalGE.BackColor = System.Drawing.SystemColors.Window
            txtFecLlenadoCont.ReadOnly = False
            txtFecLlenadoCont.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else
            txtCodEmbarque.ReadOnly = False
            txtCodEmbarque.BackColor = System.Drawing.SystemColors.Window
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbMedio.ReadOnly = False
            cmbMedio.BackColor = System.Drawing.SystemColors.Window
            txtProveedor.ReadOnly = True
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            btnBuscarProveedor.Enabled = True
            txtFecLlegada.ReadOnly = False
            txtFecLlegada.BackColor = System.Drawing.SystemColors.Window
            txtNroIng.ReadOnly = False
            txtNroIng.BackColor = System.Drawing.SystemColors.Window
            txtTotalNeto.ReadOnly = False
            txtTotalNeto.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            txtInvoiceGE.ReadOnly = False
            txtInvoiceGE.BackColor = System.Drawing.SystemColors.Window
            txtTotalGE.ReadOnly = False
            txtTotalGE.BackColor = System.Drawing.SystemColors.Window
            txtFecLlenadoCont.ReadOnly = False
            txtFecLlenadoCont.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtCodEmbarque.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtCodEmbarque.ReadOnly = True
        txtCodEmbarque.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbMedio.ReadOnly = True
        cmbMedio.BackColor = System.Drawing.SystemColors.Control
        txtProveedor.ReadOnly = True
        txtProveedor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = False
        txtFecLlegada.ReadOnly = True
        txtFecLlegada.BackColor = System.Drawing.SystemColors.Control
        txtNroIng.ReadOnly = True
        txtNroIng.BackColor = System.Drawing.SystemColors.Control
        txtTotalNeto.ReadOnly = True
        txtTotalNeto.BackColor = System.Drawing.SystemColors.Control        
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtInvoiceGE.ReadOnly = True
        txtInvoiceGE.BackColor = System.Drawing.SystemColors.Control
        txtTotalGE.ReadOnly = True
        txtTotalGE.BackColor = System.Drawing.SystemColors.Control
        txtFecLlenadoCont.ReadOnly = True
        txtFecLlenadoCont.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        txtCodEmbarque.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodEmbarque.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Embarque.", MsgBoxStyle.Information, "Información")
                txtCodEmbarque.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbMedio.Value) = "" Then
                MsgBox("Debe de Ingresar el Medio.", MsgBoxStyle.Information, "Información")
                cmbMedio.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe de Ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
                txtProveedor.Focus()
                Return False
            ElseIf toBlank(txtFecLlegada.Text) = "" Then
                MsgBox("Debe ingresar la fecha de llegada.", MsgBoxStyle.Information, "Información")
                txtFecLlegada.Focus()
                Return False
            ElseIf toBlank(txtNroIng.Text) = "" Then
                MsgBox("Debe de Ingresar el Nro. de Ingreso.", MsgBoxStyle.Information, "Información")
                txtNroIng.Focus()
                Return False
                'ElseIf toDouble(txtTotalNeto.Value) = 0 Then
                '    MsgBox("El Total Flete debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                '    txtTotalNeto.Focus()
                '    Return False
            ElseIf toBlank(txtFecLlenadoCont.Value) = "" And cmbMedio.Value <> "A" Then
                MsgBox("Debe ingresar la fecha de llenado del contenedor.", MsgBoxStyle.Information, "Información")
                txtFecLlenadoCont.Focus()
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
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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
            Dim registro As EmbarqueService.Embarque
            registro = oEmbarqueService.Obtener(CodEmbarque)

            CodEmbarque = registro.CodEmbarque
            txtCodEmbarque.Text = registro.CodEmbarque
            txtFecha.Value = registro.Fecha
            lblEstadoMesa.Text = registro.EstadoEmbarque.DesEstado
            cmbMedio.Value = registro.Medio
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            txtNroIng.Text = registro.NroIng
            txtTotalNeto.Value = registro.TotalNeto
            txtObservacion.Text = registro.Observacion
            txtInvoiceGE.Text = toNull(registro.InvoiceGasto)
            txtTotalGE.Value = registro.TotalGasto
            'txtFecLlenadoCont.Value = registro.FecLlenado
            If Not (registro.FecLlenado.ToString = "") Then
                txtFecLlenadoCont.Value = CDate(registro.FecLlenado)
                txtFecLlenadoCont.Text = registro.FecLlenado.ToString
            End If
            If Not (registro.FecLlegada.ToString = "") Then
                txtFecLlegada.Value = CDate(registro.FecLlegada)
                txtFecLlegada.Text = registro.FecLlegada.ToString
            End If

            Me.Text = "Datos de Embarque"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmEmbarque_Factura
            frm.CodEmbarque = CodEmbarque
            frm.Medio = toBlank(cmbMedio.Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If
            actualizar()
        Catch ex As Exception
            MsgBox("Error al generar Facturas de Importación MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oEmbarqueDetService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("CodEmbarque").Value), toNumber(dgvDatos.CurrentRow.Cells("IdFactura").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmEmbarque_Detalle
            frm.state_button = True
            frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Text
            frm.IdFactura = toNumber(dgvDatos.CurrentRow.Cells("IdFactura").Value)
            frm.iEstado = oEmbarqueService.ObtenerEstado(CodEmbarque)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdFactura)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdFactura)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""            
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdFactura").Text
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

    Private Sub Insertar(ByVal registro As EmbarqueService.Embarque)
        Try
            Dim estado_process As Boolean
            estado_process = oEmbarqueService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                CodEmbarque = txtCodEmbarque.Text
                MsgBox("Se insertó el Embarque Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EmbarqueService.Embarque)
        Try
            Dim estado_process As Boolean
            estado_process = oEmbarqueService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Embarque Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oEmbarqueService.Borrar(CodEmbarque, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oEmbarqueDetService.Mostrar(CodEmbarque).Tables(0)
            dgvDatos.DataSource = dtDatos            
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtNroIng.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New EmbarqueService.Embarque
                    Dim Proveedor As New EmbarqueService.Proveedor
                    Dim Empresa As New EmbarqueService.Empresa
                    Dim Estado As New EmbarqueService.EstadoEmbarque                    

                    registro.CodEmbarque = txtCodEmbarque.Text
                    registro.Fecha = txtFecha.Value
                    Proveedor.IdProveedor = IdProveedor
                    registro.Proveedor = Proveedor
                    registro.Medio = cmbMedio.Value
                    registro.TotalNeto = txtTotalNeto.Value
                    registro.NroIng = txtNroIng.Text
                    registro.Observacion = txtObservacion.Text
                    registro.FecLlegada = txtFecLlegada.Value
                    registro.InvoiceGasto = toNull(txtInvoiceGE.Text)
                    registro.TotalGasto = txtTotalGE.Value
                    'registro.FecLlenado = txtFecLlenadoCont.Value
                    registro.FecLlenado = IIf(txtFecLlenadoCont.Text = "", Nothing, txtFecLlenadoCont.Value)


                    Empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = Empresa
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        Estado.IdEstado = 1
                        registro.EstadoEmbarque = Estado
                        registro.FecReg = Today
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
                    codigo = dgvDatos.CurrentRow.Cells("IdFactura").Text
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

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtCodEmbarque.KeyPress _
                           , txtFecha.KeyPress _
                           , txtProveedor.KeyPress _
                           , cmbMedio.KeyPress _
                           , txtNroIng.KeyPress _
                           , txtTotalNeto.KeyPress _
                           , txtFecLlegada.KeyPress _
                           , txtObservacion.KeyPress _
                           , txtInvoiceGE.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFecLlenadoCont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecLlenadoCont.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub

    Private Sub cmbMedio_ValueChanged(sender As Object, e As EventArgs) Handles cmbMedio.ValueChanged
        If cmbMedio.Value = "A" Then
            txtFecLlenadoCont.Value = Nothing
            txtFecLlenadoCont.Text = ""
            txtFecLlenadoCont.Enabled = False
        Else
            txtFecLlenadoCont.Value = Today
            txtFecLlenadoCont.Enabled = True
        End If
    End Sub

    Private Sub miActualizarPeso_Click(sender As Object, e As EventArgs) Handles miActualizarPeso.Click
        If ValidaCodigoSeleccionado() Then
            ActualizarPeso()
        End If
    End Sub

    Private Sub ActualizarPeso()

        Dim frm As New frmEmbarque_ActPeso
        frm.CodEmbarque = CodEmbarque
        frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
        frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            actualizar()
        End If

    End Sub

End Class