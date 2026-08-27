
Imports System.ServiceModel

Public Class frmEncuestaSistema_Nuevo

    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    'Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient

    '======================Declaración de Variables==============================

    Private dtSistemas As DataTable
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdEncuesta As Integer
    Private dtDatos As DataTable

    Private Sub frmEncuestaSistema_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmEncuestaSistema_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEncuestaSistema_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbDetalle.Visible = True
            actualizarDetalles()

            'Me.Text = "ENCUESTA Nº " + Chr(34) + txtNumGasto.Text.ToString + Chr(34)
            'Me.Text = "ENCUESTA : " &   & "
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(753, 235)
            cbActivo.Checked = False
            txtFecInicio.Text = ""
            txtFecFinal.Text = ""

            gbDetalle.Visible = False

            Me.Text = "Registrar nueva Encuesta"
            activar()
            'ObtenerSolicitante()

        End If

    End Sub

    Private Sub llenarCombos()
        Try
            '------------------------------- Aplicacion --------------------------------------------
            dtSistemas = oSeguridadService.MostrarSistemas.Tables(0)
            cmbSistema.DataSource = dtSistemas
            cmbSistema.DropDownList.DataMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.DropDownList.DisplayMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.DropDownList.ValueMember = dtSistemas.Columns("IdSistema").ToString
            cmbSistema.DropDownList.Columns(0).DataMember = dtSistemas.Columns("IdSistema").ToString
            cmbSistema.DropDownList.Columns(1).DataMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.SelectedIndex = 0
            dtSistemas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub activar()
        If state_button = True Then
            cmbSistema.ReadOnly = True
            cmbSistema.BackColor = System.Drawing.SystemColors.Control
        Else
            cmbSistema.ReadOnly = False
            cmbSistema.BackColor = System.Drawing.SystemColors.Window
        End If

        txtObjetivo.ReadOnly = False
        txtObjetivo.BackColor = System.Drawing.SystemColors.Window
        'cbActivo.Enabled = True
        txtFecInicio.ReadOnly = True
        txtFecInicio.BackColor = System.Drawing.SystemColors.Control
        txtFecFinal.ReadOnly = True
        txtFecFinal.BackColor = System.Drawing.SystemColors.Control
        edicion = True
        cbAnonimo.Enabled = True
        'biEditarr.Enabled = False
        'biGuardar.Enabled = True
        'biDeshacerr.Enabled = True
        enableOpciones()
    End Sub

    Private Sub desactivar()
        cmbSistema.ReadOnly = True
        cmbSistema.BackColor = System.Drawing.SystemColors.Control
        txtObjetivo.ReadOnly = True
        txtObjetivo.BackColor = System.Drawing.SystemColors.Control
        'cbActivo.Enabled = False
        txtFecInicio.ReadOnly = True
        txtFecInicio.BackColor = System.Drawing.SystemColors.Control
        txtFecFinal.ReadOnly = True
        txtFecFinal.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        cbAnonimo.Enabled = False
        'biEditarr.Enabled = True
        'biGuardar.Enabled = False
        'biDeshacerr.Enabled = False
        enableOpciones()
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EncuestaService.Encuesta
            registro = oEncuestaSistema.Obtener(IdEncuesta)

            IdEncuesta = registro.IdEncuesta
            cmbSistema.Value = registro.Sistema.IdSistema
            txtObjetivo.Text = registro.Objetivo
            cbActivo.Checked = registro.Activo
            'txtFecInicio.Text = IIf(registro.FecInicio = Nothing, "", registro.FecInicio)
            'txtFecFinal.Text = IIf(registro.FecFinal = Nothing, "", registro.FecFinal)
            'txtFecInicio.Value = IIf(registro.FecInicio = Nothing, Nothing, registro.FecInicio)
            'txtFecFinal.Value = IIf(registro.FecFinal = Nothing, Nothing, registro.FecFinal)
            If Not (registro.FecInicio.ToString = "") Then
                txtFecInicio.Value = CDate(registro.FecInicio)
                txtFecInicio.Text = registro.FecInicio.ToString
            End If
            If Not (registro.FecFinal.ToString = "") Then
                txtFecFinal.Value = CDate(registro.FecFinal)
                txtFecFinal.Text = registro.FecFinal.ToString
            End If
            'txtFecInicio.Value = registro.FecInicio
            'txtFecFinal.Value = registro.FecFinal
            cbAnonimo.Checked = registro.Anonimo

            Me.Text = "Encuesta Nº " + registro.IdEncuesta.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdPregunta").Text
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
            dtDatos = oEncuestaSistema.MostrarPregunta(toNumber(IdEncuesta)).Tables(0)
            dgvDatos.DataSource = dtDatos
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

        'If edicion = True Then
        '    cmOpciones.Enabled = False
        'Else
        '    cmOpciones.Enabled = True
        'End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdPregunta").Value) = codigo Then
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
            'If dgvDatos.CurrentRow.Cells("Tipo").Text = "Selectiva" Then
            Dim frm As New frmEncuestaSistema_Detalle

            frm.state_button = True
            frm.IdPregunta = dgvDatos.CurrentRow.Cells("IdPregunta").Text
            frm.IdEncuesta = dgvDatos.CurrentRow.Cells("IdEncuesta").Text
            frm.Tipo = dgvDatos.CurrentRow.Cells("Tipo").Text
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdPregunta)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()

            'End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PREGUNTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPregunta").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        NuevoDetalle()
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmEncuestaSistema_Detalle
            frm.state_button = False
            frm.IdEncuesta = IdEncuesta
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdEncuesta)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA PREGUNTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR la Pregunta seleccionada", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oEncuestaSistema.BorrarPregunta(CInt(dgvDatos.CurrentRow.Cells("IdEncuesta").Text), CInt(dgvDatos.CurrentRow.Cells("IdPregunta").Text))
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA ENCUESTA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub biEditarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New EncuestaService.Encuesta
                Dim sistema As New EncuestaService.Sistema

                registro.IdEncuesta = IdEncuesta
                sistema.IdSistema = cmbSistema.Value
                registro.Sistema = sistema
                registro.Objetivo = txtObjetivo.Text
                registro.Activo = cbActivo.Checked
                registro.FecInicio = txtFecInicio.Value
                registro.FecFinal = txtFecFinal.Value
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                registro.Anonimo = cbAnonimo.Checked

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As EncuestaService.Encuesta)
        Try
            Dim estado_process As Integer
            estado_process = oEncuestaSistema.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdEncuesta = estado_process
                MsgBox("Se inserto la Encuesta correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Modificar(ByVal registro As EncuestaService.Encuesta)
        Try
            Dim estado_process As Boolean
            estado_process = oEncuestaSistema.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Encuesta Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toBlank(txtFecInicio.Text) = "" Then
            '    MsgBox("Debe Ingresar la fecha de Inicio", MsgBoxStyle.Information, "Información")
            '    txtFecInicio.BackColor = Color.Red
            '    txtFecInicio.Focus()
            '    Return False
            'Else
            If toBlank(txtObjetivo.Text) = "" Then
                MsgBox("Debe Ingresar el Objetivo", MsgBoxStyle.Information, "Información")
                txtObjetivo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea deshacer los cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

End Class