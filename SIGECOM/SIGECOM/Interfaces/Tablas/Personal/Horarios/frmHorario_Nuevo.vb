Imports System.ServiceModel
Public Class frmHorario_Nuevo

    '===========================Servicios====================================
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private oHorarioDetService As New HorarioDetService.HorarioDetServiceClient    

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable    
    Public CodHor As String                         'Código de Horario seleccionado
    Public DiaHor As String                          'Nro de Día de detalle
    Public dtDatos As DataTable
    Public dtTurnos As DataTable

    Private Sub frmHorario_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbDetalles.Visible = True
            actualizarDetalles()
            Me.Text = "Horario de Personal"
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(529, 271)
            cbAplicaTardanza.Checked = True
            gbDetalles.Visible = False
            Me.Text = "Nuevo Horario de Personal"
            activar()
            txtCodHor.Focus()
        End If
    End Sub

    Private Sub frmHorario_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmHorario_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHorarioService.Close()
            oHorarioDetService.Close()            
        Catch ex As TimeoutException
            oHorarioService.Abort()
            oHorarioDetService.Abort()            
        Catch ex As CommunicationException
            oHorarioService.Abort()
            oHorarioDetService.Abort()            
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String, ByVal diahor As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodHor").Value) = codigo And toBlank(row.Cells("DiaHor").Value) = diahor Then
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
            '======================================== MOTIVO ================================================
            dtTurnos = oHorarioService.MostrarTurnos().Tables(0)
            cmbTurno.DataSource = dtTurnos
            cmbTurno.DropDownList.DataMember = dtTurnos.Columns("DesTurno").ToString
            cmbTurno.DropDownList.DisplayMember = dtTurnos.Columns("DesTurno").ToString
            cmbTurno.DropDownList.ValueMember = dtTurnos.Columns("IdTurno").ToString
            cmbTurno.DropDownList.Columns(0).DataMember = dtTurnos.Columns("IdTurno").ToString
            cmbTurno.DropDownList.Columns(1).DataMember = dtTurnos.Columns("DesTurno").ToString
            cmbTurno.SelectedIndex = 0
            dtTurnos = Nothing
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
            txtCodHor.ReadOnly = True
            txtCodHor.BackColor = System.Drawing.SystemColors.Control
            cmbTurno.ReadOnly = False
            cmbTurno.BackColor = System.Drawing.SystemColors.Window
            cbAplicaFeriado.Enabled = True
            cbAplicaTardanza.Enabled = True
            cbVigente.Enabled = True
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            txtToleranciaIng.ReadOnly = False
            txtToleranciaIng.BackColor = System.Drawing.SystemColors.Window
            txtTiempoRefrig.ReadOnly = False
            txtTiempoRefrig.BackColor = System.Drawing.SystemColors.Window
            txtToleranciaRefrig.ReadOnly = False
            txtToleranciaRefrig.BackColor = System.Drawing.SystemColors.Window
            txtTotHoraNormal.ReadOnly = False
            txtTotHoraNormal.BackColor = System.Drawing.SystemColors.Window
            cbVigente.Visible = True

            edicion = True
            enableOpciones()
            txtDescripcion.Focus()
        Else
            txtCodHor.ReadOnly = False
            txtCodHor.BackColor = System.Drawing.SystemColors.Window
            cmbTurno.ReadOnly = False
            cmbTurno.BackColor = System.Drawing.SystemColors.Window
            cbAplicaFeriado.Enabled = True
            cbAplicaTardanza.Enabled = True
            cbVigente.Enabled = True
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            txtToleranciaIng.ReadOnly = False
            txtToleranciaIng.BackColor = System.Drawing.SystemColors.Window
            txtTiempoRefrig.ReadOnly = False
            txtTiempoRefrig.BackColor = System.Drawing.SystemColors.Window
            txtToleranciaRefrig.ReadOnly = False
            txtToleranciaRefrig.BackColor = System.Drawing.SystemColors.Window
            txtTotHoraNormal.ReadOnly = False
            txtTotHoraNormal.BackColor = System.Drawing.SystemColors.Window
            cbVigente.Visible = False

            edicion = True
            enableOpciones()
            txtCodHor.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtCodHor.ReadOnly = True
        txtCodHor.BackColor = System.Drawing.SystemColors.Control
        cmbTurno.ReadOnly = True
        cmbTurno.BackColor = System.Drawing.SystemColors.Control
        cbAplicaFeriado.Enabled = False
        cbAplicaTardanza.Enabled = False
        cbVigente.Enabled = False
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtToleranciaIng.ReadOnly = True
        txtToleranciaIng.BackColor = System.Drawing.SystemColors.Control
        txtTiempoRefrig.ReadOnly = True
        txtTiempoRefrig.BackColor = System.Drawing.SystemColors.Control
        txtToleranciaRefrig.ReadOnly = True
        txtToleranciaRefrig.BackColor = System.Drawing.SystemColors.Control
        txtTotHoraNormal.ReadOnly = True
        txtTotHoraNormal.BackColor = System.Drawing.SystemColors.Control
        cbVigente.Visible = True

        edicion = False
        enableOpciones()
        txtCodHor.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodHor.Text) = "" Then
                MsgBox("Debe ingresar el código de horario.", MsgBoxStyle.Information, "Información")
                txtCodHor.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la descripción.", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
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
            Dim registro As HorarioService.Horario
            registro = oHorarioService.Obtener(CodHor, Session.sCodEmp)

            CodHor = registro.CodHor
            txtCodHor.Text = registro.CodHor
            cmbTurno.Value = registro.Turno.IdTurno
            cbAplicaFeriado.Checked = registro.Feriado
            cbAplicaTardanza.Checked = registro.AplicaTardanza
            cbVigente.Checked = registro.Vigente
            txtDescripcion.Text = registro.DesHor
            txtToleranciaIng.Text = registro.TolIng
            txtTiempoRefrig.Text = registro.TieRef
            txtToleranciaRefrig.Text = registro.TolRef
            txtTotHoraNormal.Text = registro.TotHoraNormal

            Me.Text = "Horario de Personal"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmHorario_Detalle
                frm.state_button = False
                frm.CodHor = txtCodHor.Text

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.CodHor, frm.DiaHor)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oHorarioDetService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("CodHor").Value), Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("DiaHor").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            Dim frm As New frmHorario_Detalle
            frm.state_button = True
            frm.CodHor = txtCodHor.Text
            frm.DiaHor = dgvDatos.CurrentRow.Cells("DiaHor").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.CodHor, frm.DiaHor)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.CodHor, frm.DiaHor)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            Dim diahor As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodHor").Text
                    diahor = dgvDatos.CurrentRow.Cells("DiaHor").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo, diahor)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As HorarioService.Horario)
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                CodHor = txtCodHor.Text
                MsgBox("Se insertó el horario Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR HORARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HorarioService.Horario)
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el horario Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR HORARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioService.Borrar(CodHor, Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR HORARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oHorarioDetService.Mostrar(CodHor, Session.sCodEmp).Tables(0)
            dgvDatos.DataSource = dtDatos

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New HorarioService.Horario
                    Dim turno As New HorarioService.Turno
                    Dim empresa As New HorarioService.Empresa

                    empresa.CodEmp = Session.sCodEmp
                    registro.CodHor = txtCodHor.Text
                    registro.Empresa = empresa
                    turno.IdTurno = cmbTurno.Value
                    registro.Turno = turno
                    registro.Feriado = cbAplicaFeriado.Checked
                    registro.AplicaTardanza = cbAplicaTardanza.Checked
                    registro.Vigente = cbVigente.Checked
                    registro.DesHor = txtDescripcion.Text
                    registro.TolIng = txtToleranciaIng.Value
                    registro.TieRef = txtTiempoRefrig.Value
                    registro.TolRef = txtToleranciaRefrig.Value
                    registro.TotHoraNormal = txtTotHoraNormal.Value

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo                        
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR HORARIO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            Dim diahor As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodHor").Text
                    diahor = dgvDatos.CurrentRow.Cells("DiaHor").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo, diahor)
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

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtCodHor.KeyPress _
                           , cbAplicaFeriado.KeyPress _
                           , cbAplicaTardanza.KeyPress _
                           , cbVigente.KeyPress _
                           , txtDescripcion.KeyPress _
                           , txtToleranciaIng.KeyPress _
                           , txtTiempoRefrig.KeyPress _
                           , txtToleranciaRefrig.KeyPress _
                           , txtTotHoraNormal.KeyPress _
                           , cmbTurno.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub
End Class