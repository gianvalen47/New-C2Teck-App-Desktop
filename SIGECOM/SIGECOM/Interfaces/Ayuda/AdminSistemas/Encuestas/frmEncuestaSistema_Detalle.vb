Imports System.ServiceModel

Public Class frmEncuestaSistema_Detalle

    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Private dtDatos As DataTable
    Private dtTipo As DataTable
    Public IdPregunta As Integer
    Public IdEncuesta As Integer
    Public Tipo As String

    Private Sub frmEncuestaSistema_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
        End Try
    End Sub

    Private Sub frmEncuestaSistema_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEncuestaSistema_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)

        llenarCombos()
        If state_button Then    'Modificar 
            If Tipo = "Selectiva" Then
                ObtenerRegistro()
                listaDatos()
                desactivar()
            ElseIf Tipo = "Descriptiva" Then
                Me.Size = New System.Drawing.Size(713, 202)
                ObtenerRegistro()
                desactivar()
                dgvDatos.Visible = False
                'actualizarDetalles()
            End If
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(713, 202)
            activar()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EncuestaService.Pregunta
            registro = oEncuestaSistema.ObtenerPregunta(IdPregunta)

            IdPregunta = registro.IdPregunta
            IdEncuesta = registro.Encuesta.IdEncuesta
            txtPregunta.Text = registro.Descripcion
            cmbTipo.Text = registro.Tipo
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdRespuesta").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarVentana()

        If cmbTipo.Text = "Selectiva" Then
            dgvDatos.Visible = True
            Me.Size = New System.Drawing.Size(713, 365)
            ObtenerRegistro()
            listaDatos()
            desactivar()
        ElseIf cmbTipo.Text = "Descriptiva" Then
            dgvDatos.Visible = False
            Me.Size = New System.Drawing.Size(713, 202)
            ObtenerRegistro()
            desactivar()
            dgvDatos.Visible = False
            'actualizarDetalles()
        End If


    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oEncuestaSistema.MostrarRespuesta(toNumber(IdPregunta)).Tables(0)
            dgvDatos.DataSource = dtDatos

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            Dim dt As DataTable = New DataTable("Tabla")

            dt.Columns.Add("Codigo")
            dt.Columns.Add("Descripcion")

            Dim dr As DataRow

            dr = dt.NewRow()
            dr("Codigo") = "1"
            dr("Descripcion") = "Selectiva"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "2"
            dr("Descripcion") = "Descriptiva"
            dt.Rows.Add(dr)

            cmbTipo.DataSource = dt
            cmbTipo.DropDownList.DataMember = dt.Columns("Descripcion").ToString
            cmbTipo.DropDownList.DisplayMember = dt.Columns("Descripcion").ToString
            cmbTipo.DropDownList.ValueMember = dt.Columns("Codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dt.Columns("Codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dt.Columns("Descripcion").ToString

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRespuesta").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
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

    Private Sub mostrar()
        Try
            'Dim lLog As Boolean = True
            'While lLog
            Dim frm As New frmEncuestaSistema_Respuesta

            frm.state_button = True
            frm.IdRespuesta = dgvDatos.CurrentRow.Cells("IdRespuesta").Text
            'frm.editable = IIf(lEstado = "Generado", True, False)
            'frm.edicion = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    'listaDatos()
                    RowPossesion(dgvDatos, frm.IdRespuesta)
                Else
                    'listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If

            Actualizar()
            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA RESPUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmEncuestaSistema_Respuesta
                frm.IdPregunta = IdPregunta
                'frm.edicion = True
                'frm.editable = True
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    'ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdRespuesta)
                    End If
                Else
                    lLog = False
                End If
            End While
            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA RESPUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdRespuesta").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub enableOpciones()

        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If

        editable = True
        miNuevo.Enabled = IIf(editable, True, False)
        biEditarr.Enabled = IIf(True, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion
        'biEnviar.Enabled = IIf(iEstado = 1 Or iEstado = 0, Not edicion, False)
        cmOpciones.Enabled = IIf(editable, Not edicion, False)

    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR la respuesta seleccionada", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oEncuestaSistema.BorrarRespuesta(CInt(dgvDatos.CurrentRow.Cells("IdRespuesta").Text), CInt(dgvDatos.CurrentRow.Cells("IdPregunta").Text))
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    'enableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA RESPUESTA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New EncuestaService.Pregunta
                Dim Encuesta As New EncuestaService.Encuesta

                registro.IdPregunta = IdPregunta
                Encuesta.IdEncuesta = IdEncuesta
                registro.Encuesta = Encuesta
                registro.Descripcion = txtPregunta.Text
                registro.Tipo = cmbTipo.Text
                registro.Activo = cbActivo.Checked

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA PREGUNTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As EncuestaService.Pregunta)
        Try
            Dim estado_process As Integer
            estado_process = oEncuestaSistema.InsertarPregunta(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdEncuesta = estado_process
                MsgBox("Se inserto la pregunta correctamente")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA PREGUNTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EncuestaService.Pregunta)
        Try
            Dim estado_process As Boolean
            estado_process = oEncuestaSistema.ActualizarPregunta(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la pregunta correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
                actualizarVentana()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA PREGUNTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtPregunta.Text) = "" Then
                MsgBox("Debe Ingresar la pregunta", MsgBoxStyle.Information, "Información")
                txtPregunta.BackColor = Color.Red
                txtPregunta.Focus()
                Return False
            ElseIf toBlank(cmbTipo.Text) = "" Then
                MsgBox("Debe Ingresar el Tipo", MsgBoxStyle.Information, "Información")
                cmbTipo.Focus()
                Return False
            ElseIf cmbTipo.Text = "Descriptiva" And dgvDatos.RowCount > 0 Then
                MsgBox("Debe eliminar las respuestas antes de continuar", MsgBoxStyle.Information, "Información")
                dgvDatos.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub desactivar()
        txtPregunta.ReadOnly = True
        txtPregunta.BackColor = System.Drawing.SystemColors.Control
        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        edicion = False
        'biEditarr.Enabled = True
        'biGuardar.Enabled = False
        'biDeshacerr.Enabled = False
        enableOpciones()
    End Sub

    Private Sub activar()
        txtPregunta.ReadOnly = False
        txtPregunta.BackColor = System.Drawing.SystemColors.Window
        cmbTipo.ReadOnly = False
        cmbTipo.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        edicion = True
        'biEditarr.Enabled = False
        'biGuardar.Enabled = True
        'biDeshacerr.Enabled = True
        enableOpciones()
    End Sub

    Private Sub biEditarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea deshacer los cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class