Imports System.ServiceModel
Public Class frmUnidad

    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public Placa As String

    Private dtAreas As DataTable
    Private dtPersonal As DataTable

    Private Sub frmUnidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVehiculoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oVehiculoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oVehiculoService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmUnidad_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUnidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvPersonal)
        dgvPersonal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()

        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            listaPersonal()
            Me.Text = "Unidad : " + Chr(34) + txtPlaca.Text.ToString + Chr(34)


        Else                    'Nuevo
            txtAnioFab.Text = Today.Year
            Me.Size = New System.Drawing.Size(513, 324)
            Me.Text = "Registrar nueva Unidad"
            activar()
        End If
        'state_Search = True
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listaPersonal()

        Try
            dtPersonal = oVehiculoService.MostrarUnidadAsignada(txtPlaca.Text).Tables(0)
            dgvPersonal.DataSource = dtPersonal
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CONTACTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub activar()
        Try
            If state_button Then   'Actualizar
                txtPlaca.ReadOnly = True
                txtPlaca.BackColor = System.Drawing.SystemColors.Control
                txtSerie.ReadOnly = False
                txtSerie.BackColor = System.Drawing.SystemColors.Window
                txtDescripción.ReadOnly = False
                txtDescripción.BackColor = System.Drawing.SystemColors.Window
                txtMarca.ReadOnly = False
                txtMarca.BackColor = System.Drawing.SystemColors.Window
                txtClase.ReadOnly = False
                txtClase.BackColor = System.Drawing.SystemColors.Window
                txtModelo.ReadOnly = False
                txtModelo.BackColor = System.Drawing.SystemColors.Window
                txtAnioFab.ReadOnly = False
                txtAnioFab.BackColor = System.Drawing.SystemColors.Window
                cmbCodArea.ReadOnly = False
                cmbCodArea.BackColor = System.Drawing.SystemColors.Window

                edicion = True
                enableOpciones()

            Else                       'Nuevo
                txtPlaca.ReadOnly = False
                txtPlaca.BackColor = System.Drawing.SystemColors.Window
                txtSerie.ReadOnly = False
                txtSerie.BackColor = System.Drawing.SystemColors.Window
                txtDescripción.ReadOnly = False
                txtDescripción.BackColor = System.Drawing.SystemColors.Window
                txtMarca.ReadOnly = False
                txtMarca.BackColor = System.Drawing.SystemColors.Window
                txtClase.ReadOnly = False
                txtClase.BackColor = System.Drawing.SystemColors.Window
                txtModelo.ReadOnly = False
                txtModelo.BackColor = System.Drawing.SystemColors.Window
                txtAnioFab.ReadOnly = False
                txtAnioFab.BackColor = System.Drawing.SystemColors.Window
                cmbCodArea.ReadOnly = False
                cmbCodArea.BackColor = System.Drawing.SystemColors.Window

                edicion = True
                enableOpciones()

            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvPersonal.RowCount < 1 Then
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

    Private Sub desactivar()
        Try
            txtPlaca.ReadOnly = True
            txtPlaca.BackColor = System.Drawing.SystemColors.Control
            txtSerie.ReadOnly = True
            txtSerie.BackColor = System.Drawing.SystemColors.Control
            txtDescripción.ReadOnly = True
            txtDescripción.BackColor = System.Drawing.SystemColors.Control
            txtMarca.ReadOnly = True
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            txtClase.ReadOnly = True
            txtClase.BackColor = System.Drawing.SystemColors.Control
            txtModelo.ReadOnly = True
            txtModelo.BackColor = System.Drawing.SystemColors.Control
            txtAnioFab.ReadOnly = True
            txtAnioFab.BackColor = System.Drawing.SystemColors.Control
            cmbCodArea.ReadOnly = True
            cmbCodArea.BackColor = System.Drawing.SystemColors.Control
            edicion = False
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As VehiculoService.Unidad
            registro = oVehiculoService.ObtenerUnidad(Placa)

            txtPlaca.Text = registro.Placa
            txtSerie.Text = registro.Serie
            txtDescripción.Text = registro.Descripcion
            txtMarca.Text = registro.Marca
            txtClase.Text = registro.Clase
            txtModelo.Text = registro.Modelo
            txtAnioFab.Text = registro.AnioFab
            cmbCodArea.Value = registro.Area.CodArea
            cbVigente.Checked = registro.Vigente

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New VehiculoService.Unidad
                Dim empresa As New VehiculoService.Empresa
                Dim area As New VehiculoService.Area

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa

                registro.Placa = txtPlaca.Text
                registro.Serie = txtSerie.Text
                registro.Descripcion = txtDescripción.Text
                registro.Marca = txtMarca.Text
                registro.Clase = txtClase.Text
                registro.Modelo = txtModelo.Text
                registro.AnioFab = txtAnioFab.Value
                area.CodArea = cmbCodArea.Value
                registro.Area = area
                registro.Vigente = cbVigente.Checked

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc


                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'Dim registro As New ProveedorService.Proveedor
            'registro.IdProveedor = toNumber(txtIdProveedor.Text)

            If txtPlaca.Text = "" Then
                MsgBox("Debe Ingresar la Placa", MsgBoxStyle.Information, "Información")
                txtPlaca.BackColor = Color.Red
                txtPlaca.Focus()
                Return False
            Else
                Return True
            End If
            Return True
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As VehiculoService.Unidad)
        Try
            Dim estado_process As Boolean
            estado_process = oVehiculoService.InsertarUnidad(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la Unidad correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I. ....!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA UNIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As VehiculoService.Unidad)
        Try
            Dim estado_process As Boolean
            estado_process = oVehiculoService.ActualizarUnidad(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If

    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmUnidadPersonal
            frm.Placa = toBlank(txtPlaca.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPersonal = Nothing
                ObtenerRegistro()
                enableOpciones()
                listaPersonal()
            Else
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al Ingresar Solicitud de Gastos al Activo Fijo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click, miMostrar.Click, dgvPersonal.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvPersonal.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvPersonal.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvPersonal.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmUnidadPersonal
            frm.state_button = True
            frm.Placa = dgvPersonal.CurrentRow.Cells("Placa").Text
            frm.IdPersona = dgvPersonal.CurrentRow.Cells("IdPer").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPersonal = Nothing
                actualizarDetalles()
                ObtenerRegistro()
            End If
            RowPossesion(dgvPersonal, frm.IdPersona)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvPersonal.RowCount > 0 Then
                If IsDBNull(dgvPersonal.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvPersonal.CurrentRow.Cells("IdPer").Text
                End If
            End If
            dtPersonal = Nothing
            listaPersonal()
            If dgvPersonal.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvPersonal, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("IdPer").Value) = codigo Then
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
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oVehiculoService.BorrarUnidadAsignada(dgvPersonal.CurrentRow.Cells("Placa").Value, toNumber(dgvPersonal.CurrentRow.Cells("IdPer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtPersonal = Nothing
                    listaPersonal()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        listaPersonal()
    End Sub
End Class