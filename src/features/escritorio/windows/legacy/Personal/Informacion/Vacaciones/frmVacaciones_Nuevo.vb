Imports System.ServiceModel
Public Class frmVacaciones_Nuevo

    '===========================Servicios====================================
    Private oVacacionesService As New VacacionesService.VacacionesServiceClient
    Private oVacacionesDetService As New VacacionesDetService.VacacionesDetServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable    
    Public IdVacaciones As Integer
    Public IdPersona As Integer = 0
    Public dtDatos As DataTable
    Public ApeNom As String
    Private iEstado As String

    Public Anio As Integer                            'Periodo de Vacación
    Public iIdPersona As Integer = 0             'IdPersona del colaborador seleccionado en la venta anterior

    Private Sub frmVacaciones_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbDetalles.Visible = True
            gbEstado.Visible = True
            actualizarDetalles()
            Me.Text = "Registro de Vacaciones de: " + Chr(34) + ApeNom + Chr(34)
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(488, 282)
            txtPeriodo.Value = Today.Year
            txtFecInicio.Value = Today
            txtFecFinal.Value = Today
            If iIdPersona <> 0 Then
                ObtenerPersona()
            End If

            gbDetalles.Visible = False
            gbEstado.Visible = False
            Me.Text = "Nuevo registro de vacaciones"
            activar()
            txtPeriodo.Select()
        End If
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmVacaciones_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVacacionesService.Close()
            oVacacionesDetService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oVacacionesService.Abort()
            oVacacionesDetService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oVacacionesService.Abort()
            oVacacionesDetService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdVacacionesDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        iEstado = oVacacionesService.ObtenerEstado(IdVacaciones)

        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else            
            miMostrar.Enabled = True
            miEliminar.Enabled = True 'IIf(editable And iEstado = "P", True, False)            
        End If
        miNuevo.Enabled = IIf(editable And iEstado = "P", True, False)

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
            txtPeriodo.ReadOnly = False
            txtPeriodo.BackColor = System.Drawing.SystemColors.Window
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            txtFecInicio.ReadOnly = False
            txtFecInicio.BackColor = System.Drawing.SystemColors.Window
            txtFecFinal.ReadOnly = False
            txtFecFinal.BackColor = System.Drawing.SystemColors.Window
            txtFecPago.ReadOnly = False
            txtFecPago.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            'lblDiasPend.Visible = True
            'txtDiasPen.Visible = True

            edicion = True
            enableOpciones()
            txtPeriodo.Focus()
        Else
            txtPeriodo.ReadOnly = False
            txtPeriodo.BackColor = System.Drawing.SystemColors.Window
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = True
            txtFecInicio.ReadOnly = False
            txtFecInicio.BackColor = System.Drawing.SystemColors.Window
            txtFecFinal.ReadOnly = False
            txtFecFinal.BackColor = System.Drawing.SystemColors.Window
            txtFecPago.ReadOnly = False
            txtFecPago.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            'lblDiasPend.Visible = False
            'txtDiasPen.Visible = False

            edicion = True
            enableOpciones()
            txtPeriodo.Focus()
        End If
    End Sub

    Private Sub desactivar()

        txtPeriodo.ReadOnly = True
        txtPeriodo.BackColor = System.Drawing.SystemColors.Control
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = False
        txtFecInicio.ReadOnly = True
        txtFecInicio.BackColor = System.Drawing.SystemColors.Control
        txtFecFinal.ReadOnly = True
        txtFecFinal.BackColor = System.Drawing.SystemColors.Control
        txtFecPago.ReadOnly = True
        txtFecPago.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        'lblDiasPend.Visible = True
        'txtDiasPen.Visible = True

        edicion = False
        enableOpciones()
        txtColaborador.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf txtFecInicio.Value > txtFecFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor que la fecha final.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf txtFecFinal.Value < txtFecInicio.Value Then
                MsgBox("La fecha final no debe ser menor que la fecha de inicio.", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
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
            Dim registro As VacacionesService.Vacaciones
            registro = oVacacionesService.Obtener(IdVacaciones)

            IdVacaciones = registro.IdVacaciones
            txtPeriodo.Value = registro.Periodo
            Anio = registro.Periodo
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtFecInicio.Value = registro.FecInicio
            txtFecFinal.Value = registro.FecFinal
            If Not (registro.FecPago.ToString = "") Then
                txtFecPago.Value = CDate(registro.FecPago)
                txtFecPago.Text = registro.FecPago.ToString
            End If
            txtDiasPen.Value = registro.DiasPen
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.Estado

            Me.Text = "Registro de Vacaciones de: " + Chr(34) + registro.Persona.ApeNom + Chr(34)
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmVacaciones_Detalle
                frm.state_button = False
                frm.IdVacaciones = IdVacaciones                                
                frm.iEstado = oVacacionesService.ObtenerEstado(IdVacaciones)

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdVacacionesDet)
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
                estado_process = oVacacionesDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdVacacionesDet").Value), IdVacaciones, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            Dim frm As New frmVacaciones_Detalle
            frm.state_button = True
            frm.IdVacacionesDet = dgvDatos.CurrentRow.Cells("IdVacacionesDet").Text
            frm.IdVacaciones = IdVacaciones
            frm.iEstado = oVacacionesService.ObtenerEstado(IdVacaciones)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdVacacionesDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdVacacionesDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdVacacionesDet").Text
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

    Private Sub Insertar(ByVal registro As VacacionesService.Vacaciones)
        Try
            Dim estado_process As Integer
            estado_process = oVacacionesService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdVacaciones = estado_process
                Anio = txtPeriodo.Value
                MsgBox("Se insertó el registro de vacaciones Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As VacacionesService.Vacaciones)
        Try
            Dim estado_process As Boolean
            estado_process = oVacacionesService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Anio = txtPeriodo.Value
                MsgBox("Se modificó el registro de vacaciones Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oVacacionesService.Borrar(IdVacaciones, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                ObtenerRegistro()
                listaDatos()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oVacacionesDetService.Mostrar(IdVacaciones).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()           
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    Persona = oPersonaService.Obtener(IdPersona)
                    txtFecInicio.Value = CDate(CStr(Persona.FecIniContrato.Value.Day) + "/" + CStr(Month(Persona.FecIniContrato)) + "/" + CStr(txtPeriodo.Value))
                    txtFecFinal.Value = CDate(txtFecInicio.Value.AddDays(30))
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                    txtFecInicio.Value = Today
                    txtFecFinal.Value = Today
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

                    Dim registro As New VacacionesService.Vacaciones
                    Dim Persona As New VacacionesService.Persona

                    registro.IdVacaciones = IdVacaciones
                    registro.Periodo = txtPeriodo.Value
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    registro.DiasPen = txtDiasPen.Value
                    registro.FecInicio = txtFecInicio.Value
                    registro.FecFinal = txtFecFinal.Value
                    registro.FecPago = IIf(txtFecPago.Text = "", Nothing, txtFecPago.Value)
                    registro.Observacion = txtObservacion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        registro.FecReg = Today
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
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
        Dim estado As String
        estado = oVacacionesService.ObtenerEstado(IdVacaciones)
        If state_button = True And estado = "P" Then
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
                    codigo = dgvDatos.CurrentRow.Cells("IdVacacionesDet").Text
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

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarColaborador.Enabled = True Then
                e.Handled = True
                btnBuscarColaborador_Click(sender, e)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtPeriodo.KeyPress _
                           , txtColaborador.KeyPress _
                           , txtFecInicio.KeyPress _
                           , txtFecFinal.KeyPress _
                           , txtFecPago.KeyPress _
                           , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub txtFecInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecInicio.ValueChanged
        If Year(txtFecInicio.Value) = Year(txtFecFinal.Value) Then
            txtDiasPen.Value = DateDiff(DateInterval.Day, txtFecInicio.Value, txtFecFinal.Value) + 1
        End If
    End Sub

    Private Sub txtFecFinal_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecFinal.ValueChanged
        If Year(txtFecInicio.Value) = Year(txtFecFinal.Value) Then
            txtDiasPen.Value = DateDiff(DateInterval.Day, txtFecInicio.Value, txtFecFinal.Value) + 1
        End If
    End Sub

    Private Sub txtPeriodo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriodo.ValueChanged
        txtFecInicio.Value = CDate(CStr(txtFecInicio.Value.Day) + "/" + CStr(Month(txtFecInicio.Value)) + "/" + CStr(txtPeriodo.Value))
        txtFecFinal.Value = CDate(CStr(txtFecFinal.Value.Day) + "/" + CStr(Month(txtFecFinal.Value)) + "/" + CStr(txtPeriodo.Value))
    End Sub
End Class