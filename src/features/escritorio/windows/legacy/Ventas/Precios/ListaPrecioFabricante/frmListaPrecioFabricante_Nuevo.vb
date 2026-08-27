Imports System.ServiceModel
Public Class frmListaPrecioFabricante_Nuevo

    Private oListaPrecioFabricanteCabService As New ListaPrecioFabricanteCabService.ListaPrecioFabricanteCabServiceClient
    Private oListaPrecioFabricanteDetService As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient

    Private oMaestroService As New MaestroService.MaestroClient
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient


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
    Public IdListaFab As Integer
    Public IdListaDetFab As Integer
    Public TipoLista As Integer
    Private IdPer As Integer
    Private CodArea As String
    Private DtLimite As Integer
    Private Mensaje As String = ""

    Private dtTipoLista As DataTable
    Private dtListaPrecios As DataTable
    Private dtMonedas As DataTable
    Private dtCorreos As DataTable
    Private dtInsertarMasivo As DataTable
    Private dtCopia As DataTable

    Private Sub frmListaPrecioFabricante_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarCombos()
        pbTimer.Visible = False
        lblMensaje.Visible = False

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()

            gbDetalle.Visible = True
            actualizarDetalles()

            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            cmbMoneda.Value = "US"
            txtFecVencimiento.Value = Session.sFecha
            cbVigente.Checked = True
            Me.Size = New System.Drawing.Size(743, 261)

            gbDetalle.Visible = False
            Me.Text = "Registrar nueva Lista Precio Fabricante"
            activar()
            biFormatoExcel.Enabled = False
        End If

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

            '======================================= LISTA PRECIO ===========================================
            dtListaPrecios = oPrecioService.MostrarListaPrecios.Tables(0)  'oMarcaService.MostrarMarcasListaPrecio.Tables(0)
            'dtListaPrecios.Rows.InsertAt(getRowTodos(dtListaPrecios), 0)
            cmbListaPrecio.DataSource = dtListaPrecios
            cmbListaPrecio.DropDownList.DataMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.DropDownList.DisplayMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.DropDownList.ValueMember = dtListaPrecios.Columns("IdListaPre").ToString
            cmbListaPrecio.DropDownList.Columns(0).DataMember = dtListaPrecios.Columns("IdListaPre").ToString
            cmbListaPrecio.DropDownList.Columns(1).DataMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.SelectedIndex = 0
            dtListaPrecios = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ListaPrecioFabricanteCabService.ListaPrecioFabricanteCab
            registro = oListaPrecioFabricanteCabService.Obtener(IdListaFab)

            IdListaFab = registro.IdListaFab
            txtLista.Text = IdListaFab
            'iEstado = registro.EstadoListaPrecioCliente.IdEstado

            txtLista.Text = registro.IdListaFab
            txtNombreLista.Text = registro.Nombre
            cmbListaPrecio.Value = registro.ListaPrecio.IdListaPre
            cmbMoneda.Value = registro.Moneda.CodMon
            txtObservacion.Text = registro.Observacion
            cbVigente.Checked = registro.Vigente
            txtFecVencimiento.Value = registro.FecVencimiento

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub activar()

        If dgvDatos.RowCount < 1 Then
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            cmbListaPrecio.ReadOnly = False
            cmbListaPrecio.BackColor = System.Drawing.SystemColors.Window

            cbVigente.Enabled = True
            txtNombreLista.ReadOnly = False
            txtNombreLista.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            txtFecVencimiento.ReadOnly = False
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Window
        Else
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            cmbListaPrecio.ReadOnly = True
            cmbListaPrecio.BackColor = System.Drawing.SystemColors.Control

            txtNombreLista.ReadOnly = False
            txtNombreLista.BackColor = System.Drawing.SystemColors.Window

            cbVigente.Enabled = True
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
        cmbListaPrecio.ReadOnly = True
        cmbListaPrecio.BackColor = System.Drawing.SystemColors.Control

        cbVigente.Enabled = False
        txtNombreLista.ReadOnly = True
        txtNombreLista.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtFecVencimiento.ReadOnly = True
        txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()

    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdListaFabDet").Text
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

    Private Sub listaDatos()
        Try
            dtDatos = oListaPrecioFabricanteDetService.Mostrar(IdListaFab).Tables(0)
            dgvDatos.DataSource = dtDatos
            dgvDetalle.DataSource = dtDatos

            lblRegistros.Text = "Registros : " + dgvDatos.RowCount.ToString

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
        miLimpiarLista.Enabled = IIf(editable And cbVigente.Checked And dgvDatos.RowCount > 0, True, False)
        biEditarr.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)

    End Sub

    Private Sub frmListaPrecioFabricante_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioFabricante_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioFabricanteCabService.Close()
            oListaPrecioFabricanteDetService.Close()
            oMaestroService.Close()
            oSolicitudCompraService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oListaPrecioFabricanteCabService.Abort()
            oListaPrecioFabricanteDetService.Abort()
            oMaestroService.Abort()
            oSolicitudCompraService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oListaPrecioFabricanteCabService.Abort()
            oListaPrecioFabricanteDetService.Abort()
            oMaestroService.Abort()
            oSolicitudCompraService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New ListaPrecioFabricanteCabService.ListaPrecioFabricanteCab
                Dim Moneda As New ListaPrecioFabricanteCabService.Moneda
                Dim empresa As New ListaPrecioFabricanteCabService.Empresa
                Dim listaprecio As New ListaPrecioFabricanteCabService.TipoListaPrecio

                registro.IdListaFab = IdListaFab
                registro.Nombre = txtNombreLista.Text
                listaprecio.IdListaPre = cmbListaPrecio.Value
                registro.ListaPrecio = listaprecio
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.Observacion = txtObservacion.Text
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
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA CABECERA DE LA LISTA DE PRECIO FABRICANTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toBlank(txtNombreLista.Text) = "" Then
                MsgBox("Debe ingresar el nombre de la lista", MsgBoxStyle.Information, "Información")
                'cmbProvisional.BackColor = Color.Red
                txtNombreLista.Focus()
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

    Private Sub Insertar(ByVal registro As ListaPrecioFabricanteCabService.ListaPrecioFabricanteCab)
        Try
            Dim estado_process As Integer
            estado_process = oListaPrecioFabricanteCabService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdListaFab = estado_process
                MsgBox("Se inserto la Lista Correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ListaPrecioFabricanteCabService.ListaPrecioFabricanteCab)
        Try
            Dim estado_process As Boolean
            estado_process = oListaPrecioFabricanteCabService.Actualizar(registro)
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
                If CInt(row.Cells("IdListaFabDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
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
                estado_process = oListaPrecioFabricanteDetService.Borrar(dgvDatos.CurrentRow.Cells("IdListaFabDet").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
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

        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmListaPrecioFabricante_Detalle
                frm.state_button = False
                frm.IdListaFab = IdListaFab
                'frm.CodRubro = cmbRubro.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    enableOpciones()

                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub


    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try

            If cmOpciones.Enabled = True Then

                Dim frm As New frmListaPrecioFabricante_Detalle
                frm.state_button = True
                frm.IdListaFabDet = dgvDatos.CurrentRow.Cells("IdListaFabDet").Text
                frm.IdListaFab = IdListaFab


                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "update" Then
                        RowPossesion(dgvDatos, frm.IdListaFabDet)
                    Else
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesion(dgvDatos, frm.IdListaFabDet)

            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub miFormatoExcel_Click(sender As Object, e As EventArgs) Handles miFormatoExcel.Click, biFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub miListaPrecioCliente_Click(sender As Object, e As EventArgs) Handles miListaPrecioCliente.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        'OpenFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Filter = "XLSX|*.xlsx"
        lblMensaje.Visible = True
        pbTimer.Visible = True
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
            'cOMENTADO POR VA SER X CLIENTE
            InsertarMasivo()
            ' End If
        End If
    End Sub

    Private Sub CreacionTable()

        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("PreLista", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("PrecioSLP", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"CodMer", "DesMer", "0.00", "0.00", "0.00", "Obs"})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            Dim registro As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
            Dim listapreciofabrica As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteCab

            oListaPrecioFabricanteDetService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(800)

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim obs As String = ""
                    If IsDBNull(DataGridView1.Item(5, i).Value) Then
                        obs = ""
                    Else obs = CStr(DataGridView1.Item(5, i).Value)
                    End If

                    Dim descripcion As String = ""
                    If IsDBNull(DataGridView1.Item(1, i).Value) Then
                        descripcion = ""
                    Else descripcion = CStr(DataGridView1.Item(1, i).Value)
                    End If


                    'Dim rubro As New ListaPrecioDetService.Rubro

                    'Comentado porque va ser ingresado en el cliente

                    'listapreciofabrica.IdListaFab = IdListaFab
                    'registro.ListaPrecioFabricanteCab = listapreciofabrica

                    'registro.IdListaFabDet = 0
                    'registro.CodMer = CStr(DataGridView1.Item(0, i).Value)
                    'registro.DesMer = descripcion 'CStr(DataGridView1.Item(1, i).Value)
                    'registro.Precio = DataGridView1.Item(2, i).Value
                    'registro.Observacion = obs 'CStr(DataGridView1.Item(3, i).Value)
                    'registro.NomPc = Session.sNomPc
                    'registro.DirIp = Session.sDirIp
                    'registro.CodUsu = Session.sCodUsu

                    'oListaPrecioFabricanteDetService.Insertar(registro)

                    'Comentado porque va ser ingresado en el cliente

                    row = dtInsertarMasivo.NewRow
                    row(0) = DataGridView1.Item(0, i).Value
                    row(1) = descripcion
                    row(2) = CDbl(DataGridView1.Item(2, i).Value)   'PrecioLista
                    row(3) = CDbl(DataGridView1.Item(3, i).Value)   'PrecioSLP
                    row(4) = CDbl(DataGridView1.Item(4, i).Value)   'Precio
                    row(5) = obs 'DataGridView1.Item(2, i).Value

                    dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            'MsgBox("Se inserto la lista precio fabricante correctamente", MsgBoxStyle.Information)
            'listaDatos()

            'DtLimite = dtInsertarMasivo.Rows.Count

        Catch ex As Exception
            MsgBox("Error al Insertar masivamente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub InsertarMasivo()

        Try
            oListaPrecioFabricanteDetService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(400)
            Dim estado_process As Boolean
            estado_process = oListaPrecioFabricanteDetService.InsertarMasivo(IdListaFab, dtInsertarMasivo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            'estado_process = oListaClienteDetService.InsertarMasivo(IdLista, dtInsertarMasivo)

            If estado_process = True Then
                MsgBox("Se Inserto la Lista precio fabricante correctamente", MsgBoxStyle.Information)
                listaDatos()
                lblMensaje.Visible = False
                pbTimer.Visible = False
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA PRECIO FABRICANTE: " + ex.Message, MsgBoxStyle.Exclamation)
            actualizarDetalles()
        End Try

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub FormatoExcel()

        'Dim row As DataRow

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("PreLista", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("PrecioSLP", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"", "", "0.00", "0.00", "0.00", ""})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub cbVigente_CheckedChanged(sender As Object, e As EventArgs) Handles cbVigente.CheckedChanged
        If cbVigente.Checked = True Then
        Else
            txtFecVencimiento.Value = Session.sFecha
        End If
    End Sub

    Private Sub miLimpiarLista_Click(sender As Object, e As EventArgs) Handles miLimpiarLista.Click
        Try
            'cmOpciones.Visible = False
            If MsgBox("¿Está seguro de VACIAR la Lista Precio Fabricante?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oListaPrecioFabricanteDetService.VaciarLista(dgvDatos.CurrentRow.Cells("IdListaFab").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se vacio la lista precio fabricante correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VACIAR EL LISTADO PRECIO FABRICANTE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtFecVencimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecVencimiento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            biGuardar.Select()
            biGuardar_Click(sender, e)
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                     cmbMoneda.KeyPress _
                  , cmbListaPrecio.KeyPress _
                  , txtNombreLista.KeyPress _
                  , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
        End If
    End Sub


End Class