Imports System.Data.OleDb
Imports System.ServiceModel

Public Class frmListaPrecioCliente_Nuevo

    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient
    Private oListaPrecioClienteDetService As New ListaPrecioClienteDetService.ListaPrecioClienteDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable
    Private IdCliente As Integer
    Private DirFile As String
    Private fileExt As String
    Public iEstado As Integer
    Private dtDatos As DataTable
    Public IdLista As Integer
    Public IdListaDet As Integer
    Public TipoLista As Integer
    Private IdPer As Integer
    Private CodArea As String
    Private DtLimite As Integer
    Private Mensaje As String = ""

    Private dtTipoLista As DataTable
    Private dtRubros As DataTable
    Private dtMonedas As DataTable
    Private dtCorreos As DataTable
    Private dtInsertarMasivo As DataTable
    Private dtCopia As DataTable

    Private Sub frmListaPrecioCliente_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
            oSolicitudCompraService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
            oSolicitudCompraService.Close()
            oMaestroService.Close()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
            oSolicitudCompraService.Close()
            oMaestroService.Close()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            listaCorreos()
            If iEstado <> 1 Then
                Me.Size = New System.Drawing.Size(968, 528)
                gbCorreos.Visible = False
            Else
                Me.Size = New System.Drawing.Size(968, 686)
                gbCorreos.Visible = True
            End If
            Me.Text = "LISTA DE PRECIO Nº " + Chr(34) + txtLista.Text.ToString + Chr(34)
            'dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            cmbMoneda.Value = "NS"
            Me.Size = New System.Drawing.Size(968, 268)

            cmbTipoLista.Value = "2"
            gbEstado.Visible = False
            gbDetalle.Visible = False
            'gbCorreos.Visible = False
            Me.Text = "Registrar nueva Lista de Precio"
            activar()
            biFormatoExcel.Enabled = False
        End If

    End Sub

    Private Sub activar()

        If dgvDatos.RowCount < 1 Then
            txtNumContrato.ReadOnly = False
            txtNumContrato.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            cmbRubro.ReadOnly = False
            cmbRubro.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            txtCliente.ReadOnly = True
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cmbTipoLista.ReadOnly = False
            cmbTipoLista.BackColor = System.Drawing.SystemColors.Window
            cbVigente.Enabled = False

        Else
            txtNumContrato.ReadOnly = False
            txtNumContrato.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            cmbRubro.ReadOnly = True
            cmbRubro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCliente.Enabled = False
            txtCliente.ReadOnly = True
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cmbTipoLista.ReadOnly = True
            cmbTipoLista.BackColor = System.Drawing.SystemColors.Control
            cbVigente.Enabled = False

        End If
        edicion = True
        enableOpciones()
    End Sub

    Private Sub desactivar()

        txtNumContrato.ReadOnly = True
        txtNumContrato.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        cmbTipoLista.ReadOnly = True
        cmbTipoLista.BackColor = System.Drawing.SystemColors.Control

        cbVigente.Enabled = False
        edicion = False
        enableOpciones()
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ListaPrecioClienteService.ListaPrecioCliente
            registro = oListaPrecioClienteService.Obtener(IdLista)

            IdLista = registro.IdLista
            txtLista.Text = registro.IdLista
            txtNumContrato.Text = registro.NumContrato
            cmbMoneda.Value = registro.Moneda.CodMon
            cmbRubro.Value = registro.Rubro.CodRub
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbTipoLista.Value = CStr(registro.TipoLista)
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.Estado.DesEstado

            If registro.FecVigencia Is Nothing Or IsDBNull(registro.FecVigencia) Then
                txtFecVigencia.Text = ""
            Else
                txtFecVigencia.Text = registro.FecVigencia
            End If
            If registro.FecVencimiento Is Nothing Or IsDBNull(registro.FecVencimiento) Then
                txtFecVencimiento.Text = ""
            Else
                txtFecVencimiento.Text = registro.FecVencimiento
            End If
            'txtFecVigencia.Text = utils.toBlank(registro.FecVigencia)
            ' txtFecVencimiento.Text = utils.toBlank(registro.FecVencimiento)
            cbVigente.Checked = registro.Vigente

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdListaDet").Text
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

    Private Sub enableOpciones()
        iEstado = oListaPrecioClienteService.ObtenerEstado(IdLista)
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable And iEstado = 1, True, False)
        End If
        miListaPrecioCliente.Enabled = IIf(iEstado = 1, True, False)
        miNuevo.Enabled = IIf(editable And iEstado = 1, True, False)
        biEditarr.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biAprobar.Enabled = IIf(Not edicion And (iEstado = 2 Or iEstado = 3), True, False)
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = ""
                    IdCliente = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdListaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oListaPrecioClienteDetService.Mostrar(IdLista).Tables(0)
            dgvDatos.DataSource = dtDatos
            dgvDetalle.DataSource = dtDatos



            lblRegistros.Text = "Registros : " + dgvDatos.RowCount.ToString

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaCorreos()
        Try
            Dim usuario As New SeguridadService.Usuario
            Dim Persona As New PersonaService.Persona
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            IdPer = usuario.Persona.IdPer

            Persona = oPersonaService.Obtener(IdPer)
            CodArea = Persona.CentroCosto.Area.CodArea

            dtCorreos = oSolicitudCompraService.MostrarCorreos(CodArea).Tables(0)
            dgvCorreos.DataSource = dtCorreos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CORREOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= RUBROS ================================================
            dtRubros = oMaestroService.MostrarRubros.Tables(0)
            'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '////////////TIPO DE MOVIMIENTO///////////////
            dtTipoLista = New DataTable
            dtTipoLista.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtTipoLista.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtTipoLista.Rows.Add(New Object() {"1", "Nuevo"})
            dtTipoLista.Rows.Add(New Object() {"2", "Actualizacion"})
            cmbTipoLista.DataSource = dtTipoLista
            cmbTipoLista.DisplayMember = "Nombre"
            cmbTipoLista.ValueMember = "Tipo"
            cmbTipoLista.DropDownList.Columns(0).DataMember = "Tipo"
            cmbTipoLista.DropDownList.Columns(1).DataMember = "Nombre"
            cmbTipoLista.SelectedIndex = 0
            dtTipoLista = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click
        Try
            If txtLista.Text <> "" Then

                VerificarCodigos()

                Dim frm As New frmListaPrecioCliente_Aprobar
                frm.IdLista = toNumber(txtLista.Text)
                frm.IdEstado = oListaPrecioClienteService.ObtenerEstado(toNumber(txtLista.Text))
                frm.MensajeCodigosPrecio = Mensaje
                'frm.GastoViaje = cbGastoViaje.Checked '----Agregado el 30/05/2012----
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ObtenerRegistro()
                    actualizarDetalles()
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL APROBAR EL PRECIO CLIENTE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerificarCodigos()

        Mensaje = ""

        For i As Integer = 0 To dgvDetalle.Rows.Count - 1

            If ((dgvDetalle.Item(9, i).Value < dgvDetalle.Item(14, i).Value) And (dgvDetalle.Item(9, i).Value <> 0)) Or ((dgvDetalle.Item(10, i).Value < dgvDetalle.Item(15, i).Value) And (dgvDetalle.Item(10, i).Value <> 0)) Then

                Mensaje = Mensaje + Trim(dgvDetalle.Item(6, i).Value) & ","

            End If

        Next
    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") And (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            CreacionTable()
            'If DtLimite >= 280 Then
            '    MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            'Else
            ValidarPrecio()
            ' End If
        End If
    End Sub

    Private Sub CreacionTable()

        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            'dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
            'dtCopia.Columns.Add(New DataColumn("IdLista", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("IdLista", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMerCli", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("PreVenUS", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("PreVenNS", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CodUsu", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomPc", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DirIp", Type.GetType("System.String")))

            'dtCopia.Columns.Add(New DataColumn("IdLista1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("Item1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("CodMer1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("CodMerCli1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("PreVenUS1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("PreVenNS1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("CodUsu1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("NomPc1", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("DirIp1", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"1", "1", "Nuevo", "Nuevo", "5.00", "14.00", "Nuevo", "Nuevo", "Nuevo"})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(1, i).Value) = False Then

                    row = dtInsertarMasivo.NewRow
                    'row(0) = CStr(IdLista)
                    'row(1) = CStr(DataGridView1.Item(0, i).Value)
                    'row(2) = CStr(DataGridView1.Item(1, i).Value)
                    'row(3) = CStr(DataGridView1.Item(2, i).Value)
                    'row(4) = CStr(DataGridView1.Item(3, i).Value)
                    'row(5) = CStr(DataGridView1.Item(4, i).Value)
                    'row(6) = Session.sCodUsu
                    'row(7) = Session.sNomPc
                    'row(8) = Session.sDirIp

                    row(0) = IdLista
                    row(1) = CInt(DataGridView1.Item(0, i).Value)
                    'row(0) = CInt(DataGridView1.Item(0, i).Value)
                    'row(1) = IdLista
                    row(2) = Trim(DataGridView1.Item(1, i).Value)
                    row(3) = IIf(IsDBNull(DataGridView1.Item(2, i).Value) = True, "", DataGridView1.Item(2, i).Value)
                    row(4) = DataGridView1.Item(3, i).Value
                    row(5) = DataGridView1.Item(4, i).Value
                    row(6) = Session.sCodUsu
                    row(7) = Session.sNomPc
                    row(8) = Session.sDirIp

                    dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            DtLimite = dtInsertarMasivo.Rows.Count
            'DataGridView1.DataSource = Nothing

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub ValidarPrecio()

        Try
            Dim estado_process As String
            estado_process = oListaPrecioClienteDetService.ValidarPrecios(dtInsertarMasivo)

            If estado_process = "" Then
                InsertarMasivo()
            Else
                If MsgBox(estado_process & Environment.NewLine & Environment.NewLine & _
                   "¿Desea INGRESAR los códigos restantes?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    InsertarMasivo()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR AL PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub



    Private Sub InsertarMasivo()

        Try
            Dim estado_process As Boolean

            estado_process = oListaPrecioClienteDetService.InsertarMasivo(dtInsertarMasivo)

            If estado_process = True Then
                MsgBox("Se Inserto la Lista de Precio Correctamente", MsgBoxStyle.Information)
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ENVIAR la Lista de Precio Nº" & txtLista.Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim Cadena As String = ""
                    rows = dgvCorreos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow

                    If rows.Count <> 0 Then

                        For Each row In rows
                            If Cadena = "" Then
                                Cadena = row.Cells("Email").Text
                            Else
                                Cadena = Cadena + ";" + row.Cells("Email").Text
                            End If
                        Next
                        '=================================Enviar a Correos Seleccionados=================================
                        Dim estado_process As Boolean
                        estado_process = oListaPrecioClienteService.Enviar(IdLista, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process Then
                            MsgBox("Se envió correctamente la Lista de Precios", MsgBoxStyle.Information)
                            ObtenerRegistro()
                            enableOpciones()
                            Me.Size = New System.Drawing.Size(918, 496)
                            gbCorreos.Visible = False
                        Else
                            MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                        End If
                    Else
                        MsgBox("Debe seleccionar alguno de los correos")
                    End If
                End If
            Else
                MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
            End If


        Catch ex As Exception
            MsgBox("Error al Enviar la Lista de Precios: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Dim estado As Integer
        estado = oListaPrecioClienteService.ObtenerEstado(IdLista)
        If state_button = True And estado = 1 Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miListaPrecioCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miListaPrecioCliente.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        'OpenFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("Item").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oListaPrecioClienteDetService.Borrar(dgvDatos.CurrentRow.Cells("IdListaDet").Value, toNumber(dgvDatos.CurrentRow.Cells("IdLista").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmListaPrecioCliente_Detalle
                frm.state_button = False
                frm.IdLista = IdLista
                frm.estado = 1
                frm.CodRubro = cmbRubro.Value
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                Else
                    frm.txtItem.Text = 1
                End If
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdListaDet)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmListaPrecioCliente_Detalle
            frm.state_button = True
            frm.IdListaDet = dgvDatos.CurrentRow.Cells("IdListaDet").Text
            frm.IdLista = IdLista
            frm.estado = oListaPrecioClienteService.ObtenerEstado(IdLista)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdListaDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdListaDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New ListaPrecioClienteService.ListaPrecioCliente
                Dim cliente As New ListaPrecioClienteService.Cliente
                Dim rubro As New ListaPrecioClienteService.Rubro
                Dim Moneda As New ListaPrecioClienteService.Moneda
                Dim empresa As New ListaPrecioClienteService.Empresa
                Dim estado As New ListaPrecioClienteService.EstadoListaPrecioCliente

                registro.IdLista = IdLista
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                rubro.CodRub = cmbRubro.Value
                registro.Rubro = rubro
                registro.TipoLista = cmbTipoLista.Value
                registro.NumContrato = toNull(txtNumContrato.Text)
                registro.Observacion = txtObservacion.Text
                registro.FecVigencia = IIf(txtFecVigencia.Text = "", Nothing, txtFecVigencia.Text)
                registro.FecVencimiento = IIf(txtFecVencimiento.Text = "", Nothing, txtFecVencimiento.Text)
                registro.Vigente = cbVigente.Checked
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    estado.IdEstado = 1
                    registro.Estado = estado
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA CABECERA DE LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ListaPrecioClienteService.ListaPrecioCliente)
        Try
            Dim estado_process As Integer
            estado_process = oListaPrecioClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLista = estado_process
                MsgBox("Se inserto la Lista de Precio Correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ListaPrecioClienteService.ListaPrecioCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oListaPrecioClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Lista de Precio Correctamente", MsgBoxStyle.Information)
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toBlank(cmbRubro.Value) = "" Then
                MsgBox("Debe ingresar el Rubro", MsgBoxStyle.Information, "Información")
                'cmbProvisional.BackColor = Color.Red
                cmbRubro.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toBlank(cmbTipoLista.Value) = "" Then
                MsgBox("Debe ingresar el Tipo de Lista", MsgBoxStyle.Information, "Información")
                'cmbProvisional.BackColor = Color.Red
                cmbTipoLista.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
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

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        mostrarDetalle()
    End Sub


    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBuscar.Click
        BuscarDetalle()
    End Sub

    Private Sub BuscarDetalle()
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows
                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then
                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1
                        Exit For
                    End If
                Next
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdListaDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    cmbMoneda.KeyPress _
                  , cmbRubro.KeyPress _
                  , txtCliente.KeyPress _
                  , cmbTipoLista.KeyPress
        ', txtObservacion.ke
        ' , txtDesMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub biFormatoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFormatoExcel.Click, miFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        'Dim row As DataRow

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Num. Parte", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cod. Mer. Cliente", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Precio Venta US", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Precio Venta NS", Type.GetType("System.Double")))

        dtExcel.Rows.Add(New Object() {"1", "", "", "0.00", "0.00"})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub


End Class