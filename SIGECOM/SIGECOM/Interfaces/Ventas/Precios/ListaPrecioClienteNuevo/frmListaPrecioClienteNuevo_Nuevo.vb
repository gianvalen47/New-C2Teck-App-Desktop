Imports System.ServiceModel
Public Class frmListaPrecioClienteNuevo_Nuevo

    Private oListaClienteCabService As New ListaClienteCabService.ListaClienteCabServiceClient
    Private oListaClienteDetService As New ListaClienteDetService.ListaClienteDetServiceClient

    Private oMaestroService As New MaestroService.MaestroClient
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient

    '====================== Declaración de Variables ==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable
    Private IdCliente As Integer
    Private DirFile As String
    Private fileExt As String
    Public iEstado As Integer
    Public IdEstado As Integer
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

    Private Sub frmListaPrecioClienteNuevo_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaClienteCabService.Close()
            oListaClienteDetService.Close()
            oMaestroService.Close()
            oSolicitudCompraService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
            oEmpresaUsuario.Close()
        Catch ex As TimeoutException
            oListaClienteCabService.Abort()
            oListaClienteDetService.Abort()
            oMaestroService.Abort()
            oSolicitudCompraService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oEmpresaUsuario.Abort()
        Catch ex As CommunicationException
            oListaClienteCabService.Abort()
            oListaClienteDetService.Abort()
            oMaestroService.Abort()
            oSolicitudCompraService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oEmpresaUsuario.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioClienteNuevo_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioClienteNuevo_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            listaCorreos()
            If iEstado <> 1 Then
                Me.Size = New System.Drawing.Size(1112, 523)
                gbCorreos.Visible = False
            Else
                Me.Size = New System.Drawing.Size(1112, 680)
                gbCorreos.Visible = True
            End If
            Me.Text = "LISTA CLIENTE Nº " + Chr(34) + txtLista.Text.ToString + Chr(34)
            'dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            cmbMoneda.Value = "US"
            btnBuscarCliente.Focus()
            Me.Size = New System.Drawing.Size(1112, 265)

            gbEstado.Visible = False
            gbDetalle.Visible = False
            'gbCorreos.Visible = False
            Me.Text = "Registrar nueva Lista Cliente"
            activar()
            biFormatoExcel.Enabled = False
        End If

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New ListaClienteCabService.ListaClienteCab
                Dim Moneda As New ListaClienteCabService.Moneda
                Dim empresa As New ListaClienteCabService.Empresa
                Dim cliente As New ListaClienteCabService.Cliente
                Dim estado As New ListaClienteCabService.EstadoListaPrecioCliente

                registro.IdLista = IdLista
                Moneda.CodMon = cmbMoneda.Value
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
                registro.Moneda = Moneda
                registro.Observacion = txtObservacion.Text
                registro.FecVencimiento = IIf(txtFecVencimiento.Text = "", Nothing, txtFecVencimiento.Text)
                registro.NumContrato = toNull(txtNumContrato.Text)

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    estado.IdEstado = 1
                    registro.EstadoListaPrecioCliente = estado
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA CABECERA DE LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toBlank(txtCliente.Text) = "" Then
                MsgBox("Debe ingresar el cliente", MsgBoxStyle.Information, "Información")
                'cmbProvisional.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtFecVencimiento.Text) = "" Then
                MsgBox("Debe ingresar el la fecha de vencimiento", MsgBoxStyle.Information, "Información")
                'cmbProvisional.BackColor = Color.Red
                txtFecVencimiento.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ListaClienteCabService.ListaClienteCab)
        Try
            Dim estado_process As Integer
            estado_process = oListaClienteCabService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLista = estado_process
                MsgBox("Se inserto la Lista Correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ListaClienteCabService.ListaClienteCab)
        Try
            Dim estado_process As Boolean
            estado_process = oListaClienteCabService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Lista Correctamente", MsgBoxStyle.Information)
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LISTA: " + ex.Message, MsgBoxStyle.Exclamation)
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
            dtDatos = oListaClienteDetService.Mostrar(IdLista).Tables(0)
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
            Dim usuario As New EmpresaUsuarioService.EmpresaUsuario    'SeguridadService.Usuario
            Dim Persona As New PersonaService.Persona
            usuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp) ' oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
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
            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
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
            txtNumContrato.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oListaClienteDetService.Borrar(dgvDatos.CurrentRow.Cells("IdListaDet").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        Dim estado As Integer
        estado = iEstado
        If state_button = True And (estado = 1 Or estado = 4) Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmListaPrecioClienteNuevo_Detalle
                frm.state_button = False
                frm.IdLista = IdLista
                frm.estadocab = iEstado
                frm.ItemSug = dgvDatos.RowCount + 1
                'frm.CodRubro = cmbRubro.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    enableOpciones()

                    If iEstado = 1 Then
                        listaCorreos()
                        Me.Size = New System.Drawing.Size(1112, 680)
                        gbCorreos.Visible = True
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

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ENVIAR la Lista cliente Nº" & txtLista.Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

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
                        estado_process = oListaClienteCabService.Enviar(IdLista, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process Then
                            MsgBox("Se envió correctamente la lista cliente.", MsgBoxStyle.Information)
                            ObtenerRegistro()
                            enableOpciones()
                            actualizarDetalles()
                            Me.Size = New System.Drawing.Size(1112, 521)
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
            MsgBox("Error al Enviar la Lista cliente: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
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

    Private Sub activar()

        If dgvDatos.RowCount < 1 Then
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtCliente.ReadOnly = False
            txtCliente.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            txtNumContrato.ReadOnly = False
            txtNumContrato.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            txtFecVencimiento.ReadOnly = False
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Window
        Else
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            txtCliente.ReadOnly = False
            txtCliente.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            txtNumContrato.ReadOnly = False
            txtNumContrato.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            txtFecVencimiento.ReadOnly = False
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Window
        End If
        edicion = True
        enableOpciones()
    End Sub

    Private Sub desactivar()

        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        txtNumContrato.ReadOnly = True
        txtNumContrato.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtFecVencimiento.ReadOnly = True
        txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()

    End Sub

    Private Sub enableOpciones()

        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            Dim estadodet As Integer
            estadodet = dgvDatos.CurrentRow.Cells("IdEstado").Text

            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable And iEstado = 1 And estadodet = 1, True, False)
        End If
        miListaPrecioCliente.Enabled = IIf(iEstado = 1, True, False)
        miNuevo.Enabled = IIf(editable And (iEstado = 1 Or iEstado = 4), True, False)
        biEditarr.Enabled = IIf(editable And (iEstado = 1), Not edicion, False)
        biCerrar.Enabled = Not edicion
        biAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3 Or (oListaClienteCabService.BuscarAprobacionPendiente(IdLista) And iEstado = 4), True, False)
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)

    End Sub

    Private Sub biFormatoExcel_Click(sender As Object, e As EventArgs) Handles biFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub miListaPrecioCliente_Click(sender As Object, e As EventArgs) Handles miListaPrecioCliente.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        'OpenFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Filter = "XLSX|*.xlsx"
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
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
            InsertarMasivo()
            ' End If
        End If
    End Sub

    Private Sub CreacionTable()

        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMerCli", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"Item", "Codigo", "CodMerCli", "0.00", "Obs"})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim obs As String = ""
                    If IsDBNull(DataGridView1.Item(4, i).Value) Then
                        obs = ""
                    Else obs = CStr(DataGridView1.Item(4, i).Value)
                    End If

                    Dim codmercli As String = ""
                    If IsDBNull(DataGridView1.Item(2, i).Value) Then
                        codmercli = ""
                    Else codmercli = CStr(DataGridView1.Item(2, i).Value)
                    End If

                    row = dtInsertarMasivo.NewRow
                    row(0) = DataGridView1.Item(0, i).Value
                    row(1) = DataGridView1.Item(1, i).Value
                    row(2) = codmercli
                    row(3) = CDbl(DataGridView1.Item(3, i).Value)
                    row(4) = obs 'DataGridView1.Item(2, i).Value

                    dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            DtLimite = dtInsertarMasivo.Rows.Count

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub InsertarMasivo()

        Try
            Dim estado_process As Boolean
            estado_process = oListaClienteDetService.InsertarMasivo(IdLista, dtInsertarMasivo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            'estado_process = oListaClienteDetService.InsertarMasivo(IdLista, dtInsertarMasivo)

            If estado_process = True Then
                MsgBox("Se Inserto la Lista cliente Correctamente", MsgBoxStyle.Information)
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
            actualizarDetalles()
        End Try

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub FormatoExcel()

        'Dim row As DataRow

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Num. Parte", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cod. Mer. Cliente", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"", "", "", "0.00", ""})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        mostrarDetalle()
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try

            If cmOpciones.Enabled = True Then

                Dim frm As New frmListaPrecioClienteNuevo_Detalle
                frm.state_button = True
                frm.IdListaDet = dgvDatos.CurrentRow.Cells("IdListaDet").Text
                frm.IdLista = IdLista
                frm.estado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                frm.estadocab = iEstado

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

            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(sender As Object, e As EventArgs) Handles biAprobar.Click
        Try
            If txtLista.Text <> "" Then

                Dim frm As New frmListaPrecioClienteNuevo_Aprobar
                Dim frmGer As New frmListaPrecioClienteNuevo_AprobarGerencia
                Dim estado As Integer

                If iEstado = 2 Then
                    frm.IdLista = toNumber(txtLista.Text)
                    frm.IdEstado = iEstado 'dgvDatos.CurrentRow.Cells("IdEstado").Text
                    estado = iEstado 'dgvDatos.CurrentRow.Cells("IdEstado").Text
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        ObtenerRegistro()
                        actualizarDetalles()
                        If frm.tipoaprobacion = "rechazar" Then
                            listaCorreos()
                            Me.Size = New System.Drawing.Size(1112, 680)
                            gbCorreos.Visible = True
                        End If
                    End If
                Else
                    frmGer.IdLista = toNumber(txtLista.Text)
                    frmGer.IdEstado = iEstado 'dgvDatos.CurrentRow.Cells("IdEstado").Text
                    estado = iEstado 'dgvDatos.CurrentRow.Cells("IdEstado").Text
                    If frmGer.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        ObtenerRegistro()
                        actualizarDetalles()
                        If frmGer.tipoaprobacion = "rechazar" Then
                            listaCorreos()
                            Me.Size = New System.Drawing.Size(1112, 680)
                            gbCorreos.Visible = True
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL APROBAR LA LISTA CLIENTE : " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ListaClienteCabService.ListaClienteCab
            registro = oListaClienteCabService.Obtener(IdLista)

            IdLista = registro.IdLista
            iEstado = registro.EstadoListaPrecioCliente.IdEstado

            txtLista.Text = registro.IdLista
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtNumContrato.Text = registro.NumContrato
            cmbMoneda.Value = registro.Moneda.CodMon
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.EstadoListaPrecioCliente.DesEstado

            txtFecVencimiento.Value = registro.FecVencimiento

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub miBuscar_Click(sender As Object, e As EventArgs) Handles miBuscar.Click
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
                actualizarDetalles()
            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub txtFecVencimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFecVencimiento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            biGuardar.Select()
            biGuardar_Click(sender, e)
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                     cmbMoneda.KeyPress _
                  , txtNumContrato.KeyPress _
                  , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
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

End Class