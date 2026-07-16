Imports System.ServiceModel
Public Class frmHoraMotor

    '===========================Servicios====================================================
    Private oEquipoService As New MotorService.MotorServiceClient
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oModeloService As New ModeloService.ModeloServiceClient    

    '====================== Declaración de Variables =============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public codMer As String
    Public iCodOfi As String
    Private dtDatos As DataTable
    Private dtTipoPlanMantenimiento As DataTable
    Private dtPlanMantenimiento As DataTable

    Private Sub frmHoraMotor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbMantenimiento.Visible = True
            actualizarDetalles()
            txtCodMer.TabStop = False
            txtFecFinGarantia.Focus()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(614, 451)
            activar()
            LimpiarCampos()
            cbCalcAutomatico.Checked = True
            cbDetenido.Checked = False
            txtFecArranque.Value = Today
            txtFecFinGarantia.Value = Today
            gbMantenimiento.Visible = False
            Me.Text = "Registrar Horas de recorrido de Motor"
            activar()
            txtCodMer.TabStop = True
            txtCodMer.Focus()
        End If
    End Sub

    Private Sub frmHoraMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oEquipoService.Close()
            oHorasMotorService.Close()
            oModeloService.Close()            
        Catch ex As TimeoutException
            oEquipoService.Abort()
            oHorasMotorService.Abort()
            oModeloService.Abort()            
        Catch ex As CommunicationException
            oEquipoService.Abort()
           oHorasMotorService.Abort()
            oModeloService.Abort()            
        End Try
    End Sub

    Private Sub frmEquipo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("CodMantenimiento").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Function getRowNinguno(ByVal data As DataTable)
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
        Try
            fila(5) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(6) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(7) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(8) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(9) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '================================= TIPO PLAN MANTENIMIENTO =======================================
            dtTipoPlanMantenimiento = oHorasMotorService.MostrarTipoPlanMantenimiento().Tables(0)
            cmbTipoPlanMant.DataSource = dtTipoPlanMantenimiento
            cmbTipoPlanMant.DropDownList.DataMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.DropDownList.DisplayMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.DropDownList.ValueMember = dtTipoPlanMantenimiento.Columns("IdPlan").ToString
            cmbTipoPlanMant.DropDownList.Columns(0).DataMember = dtTipoPlanMantenimiento.Columns("IdPlan").ToString
            cmbTipoPlanMant.DropDownList.Columns(1).DataMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.SelectedIndex = 0
            dtTipoPlanMantenimiento = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbTipoPlanMant_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoPlanMant.ValueChanged
        Try

            '================================= PLAN MANTENIMIENTO =====================================
            dtPlanMantenimiento = oHorasMotorService.MostrarPlanMantenimiento(toNumber(cmbTipoPlanMant.Value)).Tables(0)
            dtPlanMantenimiento.Rows.InsertAt(getRowNinguno(dtPlanMantenimiento), 0)
            cmbPlanMant.DataSource = dtPlanMantenimiento
            cmbPlanMant.DropDownList.DataMember = dtPlanMantenimiento.Columns("DesMantenimiento").ToString
            cmbPlanMant.DropDownList.DisplayMember = dtPlanMantenimiento.Columns("DesMantenimiento").ToString
            cmbPlanMant.DropDownList.ValueMember = dtPlanMantenimiento.Columns("CodMantenimiento").ToString
            cmbPlanMant.DropDownList.Columns(0).DataMember = dtPlanMantenimiento.Columns("CodMantenimiento").ToString
            cmbPlanMant.DropDownList.Columns(1).DataMember = dtPlanMantenimiento.Columns("DesMantenimiento").ToString
            cmbPlanMant.SelectedIndex = 0
            dtPlanMantenimiento = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR PLAN MANTENIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            btnNumSerie.Enabled = False
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtFecArranque.ReadOnly = False
            txtFecArranque.BackColor = System.Drawing.SystemColors.Window
            txtFecFinGarantia.ReadOnly = False
            txtFecFinGarantia.BackColor = System.Drawing.SystemColors.Window
            cmbTipoPlanMant.ReadOnly = False
            cmbTipoPlanMant.BackColor = System.Drawing.SystemColors.Window
            cbSwing.Enabled = True
            cbDetenido.Enabled = True
            cbCalcAutomatico.Enabled = True

            If cbCalcAutomatico.Checked = True Then
                cmbPlanMant.ReadOnly = True
                cmbPlanMant.BackColor = System.Drawing.SystemColors.Control
                txtFecMantenimiento.ReadOnly = True
                txtFecMantenimiento.BackColor = System.Drawing.SystemColors.Control
            Else
                cmbPlanMant.ReadOnly = False
                cmbPlanMant.BackColor = System.Drawing.SystemColors.Window
                txtFecMantenimiento.ReadOnly = False
                txtFecMantenimiento.BackColor = System.Drawing.SystemColors.Window
            End If

            txtHrsDiarias.ReadOnly = False
            txtHrsDiarias.BackColor = System.Drawing.SystemColors.Window
            txtHrsTotales.ReadOnly = False
            txtHrsTotales.BackColor = System.Drawing.SystemColors.Window
            txtHrsParciales.ReadOnly = False
            txtHrsParciales.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtFecArranque.Focus()
        Else
            btnNumSerie.Enabled = True
            txtCodMer.ReadOnly = False
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtFecArranque.ReadOnly = False
            txtFecArranque.BackColor = System.Drawing.SystemColors.Window
            txtFecFinGarantia.ReadOnly = False
            txtFecFinGarantia.BackColor = System.Drawing.SystemColors.Window
            cmbTipoPlanMant.ReadOnly = False
            cmbTipoPlanMant.BackColor = System.Drawing.SystemColors.Window
            cbSwing.Enabled = True
            cbDetenido.Enabled = True
            cbCalcAutomatico.Enabled = True
            txtHrsDiarias.ReadOnly = False
            txtHrsDiarias.BackColor = System.Drawing.SystemColors.Window
            txtHrsTotales.ReadOnly = False
            txtHrsTotales.BackColor = System.Drawing.SystemColors.Window
            txtHrsParciales.ReadOnly = False
            txtHrsParciales.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtCodMer.Focus()
        End If
    End Sub

    Private Sub desactivar()
        btnNumSerie.Enabled = False
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtFecArranque.ReadOnly = True
        txtFecArranque.BackColor = System.Drawing.SystemColors.Control
        txtFecFinGarantia.ReadOnly = True
        txtFecFinGarantia.BackColor = System.Drawing.SystemColors.Control
        cmbTipoPlanMant.ReadOnly = True
        cmbTipoPlanMant.BackColor = System.Drawing.SystemColors.Control
        cbSwing.Enabled = False
        cbDetenido.Enabled = False
        cbCalcAutomatico.Enabled = False
        txtHrsDiarias.ReadOnly = True
        txtHrsDiarias.BackColor = System.Drawing.SystemColors.Control
        txtHrsTotales.ReadOnly = True
        txtHrsTotales.BackColor = System.Drawing.SystemColors.Control
        txtHrsParciales.ReadOnly = True
        txtHrsParciales.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        cmbPlanMant.ReadOnly = True
        cmbPlanMant.BackColor = System.Drawing.SystemColors.Control
        txtFecMantenimiento.ReadOnly = True
        txtFecMantenimiento.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        txtFecArranque.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtCodMer.Text = "" Then
                MsgBox("Debe Ingresar la Serie del Motor", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtFecArranque.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Arranque de Garantía.", MsgBoxStyle.Information, "Información")
                txtFecArranque.Focus()
                Return False
            ElseIf toBlank(txtFecFinGarantia.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha Fín de Garantía.", MsgBoxStyle.Information, "Información")
                txtFecFinGarantia.Focus()
                Return False
            ElseIf toNumber(cmbTipoPlanMant.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Plan de Mantenimiento.", MsgBoxStyle.Information, "Información")
                cmbTipoPlanMant.Focus()
                Return False
            ElseIf cbCalcAutomatico.Checked = False And toBlank(cmbPlanMant.Value) = "" Then
                MsgBox("Debe Ingresar el Plan de Mantenimiento.", MsgBoxStyle.Information, "Información")
                cmbPlanMant.Focus()
                Return False
            ElseIf cbCalcAutomatico.Checked = False And toBlank(txtFecMantenimiento.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Mantenimiento.", MsgBoxStyle.Information, "Información")
                txtFecMantenimiento.Focus()
                Return False
            ElseIf toDouble(txtHrsDiarias.Value) = 0 Then
                MsgBox("Debe Ingresar las Horas Diarias.", MsgBoxStyle.Information, "Información")
                txtHrsDiarias.Focus()
                Return False
            ElseIf toDouble(txtHrsTotales.Value) = 0 Then
                MsgBox("Debe Ingresar las Horas Totales.", MsgBoxStyle.Information, "Información")
                txtHrsTotales.Focus()
                Return False
            ElseIf toDouble(txtHrsParciales.Value) = 0 Then
                MsgBox("Debe Ingresar las Horas Parciales.", MsgBoxStyle.Information, "Información")
                txtHrsParciales.Focus()
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

    Private Sub ObtenerEquipo(ByVal CodMer As String)
        Try
            Dim registro As MotorService.Motor
            registro = oEquipoService.Obtener(CodMer)

            txtCodMer.Text = registro.NumSerie
            txtTipoEquipo.Text = registro.TipoEquipo.Descripcion
            txtModeloMotor.Text = registro.Modelo.ModMer            
            txtModeloEquipo.Text = registro.ModeloEquipo.Descripcion
            txtNombreEquipo.Text = registro.Equipo.NomEquipo

            txtPotencia.Text = registro.Potencia

            'If Not (registro.FecArranque.ToString = "") Then
            '    txtFecArranque.IsNullDate = False
            '    txtFecArranque.Value = CDate(registro.FecArranque)
            '    txtFecArranque.Text = registro.FecArranque.ToString
            'Else
            '    txtFecArranque.IsNullDate = True
            'End If

            txtUbicacion.Text = registro.UbicacionEquipo.DesUbicacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        Try
            txtCodMer.Text = ""
            txtTipoEquipo.Text = ""
            txtModeloMotor.Text = ""
            txtModeloEquipo.Text = ""
            txtNombreEquipo.Text = ""
            txtPotencia.Text = ""
            'txtFecArranque.IsNullDate = True
            'txtFecArranque.Text = ""
            txtUbicacion.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As HorasMotorService.HorasMotor
            registro = oHorasMotorService.Obtener(codMer)

            '====================== Datos de Equipo =======================
            codMer = registro.Motor.NumSerie
            txtCodMer.Text = registro.Motor.NumSerie

            txtTipoEquipo.Text = registro.Motor.TipoEquipo.Descripcion
            txtModeloMotor.Text = registro.Motor.Modelo.ModMer
            txtModeloEquipo.Text = registro.Motor.ModeloEquipo.ModEquipo
            txtNombreEquipo.Text = registro.Motor.Equipo.NomEquipo

            txtPotencia.Text = registro.Motor.Potencia

            'If Not (registro.Equipo.FecArranque.ToString = "") Then
            '    txtFecArranque.IsNullDate = False
            '    txtFecArranque.Value = CDate(registro.Equipo.FecArranque)
            '    txtFecArranque.Text = registro.Equipo.FecArranque.ToString
            'Else
            '    txtFecArranque.IsNullDate = True
            'End If

            txtUbicacion.Text = registro.Motor.UbicacionEquipo.DesUbicacion

            '================= Hrs de recorrido de Fecha ===================
            txtFecArranque.Value = CDate(registro.FecArranqueRep)

            '================= Hrs de recorrido de Equipo ===================
            txtFecFinGarantia.Value = CDate(registro.FecFinGarantia)

            cbSwing.Checked = registro.Swing
            cbDetenido.Checked = registro.Detenido

            cmbTipoPlanMant.Value = registro.TipoPlanMantenimiento.IdPlan

            cbCalcAutomatico.Checked = registro.CalculoAutomatico

            If Not (registro.FechaMantenimiento.ToString = "") Then
                txtFecMantenimiento.IsNullDate = False
                txtFecMantenimiento.Value = CDate(registro.FechaMantenimiento)
                txtFecMantenimiento.Text = registro.FechaMantenimiento.ToString
            Else
                txtFecMantenimiento.IsNullDate = True
            End If

            If toBlank(registro.TipoMantenimiento.CodMantenimiento) = "" Then
                cmbPlanMant.SelectedIndex = 0
            Else
                cmbPlanMant.Value = registro.TipoMantenimiento.CodMantenimiento
            End If

            txtHrsDiarias.Value = registro.HorasDiarias
            txtHrsTotales.Value = registro.TotalHoras
            txtHrsParciales.Value = registro.HoraParcial

            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER HRS DE RECORRIDO DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmHoraMotor_Mant
                frm.state_button = False
                frm.CodMer = codMer
                frm.IdPlan = toNumber(cmbTipoPlanMant.Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.CodMantenimiento)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO MANTENIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oHorasMotorService.BorrarMantenimiento(toBlank(dgvDatos.CurrentRow.Cells("NumSerie").Value), toBlank(dgvDatos.CurrentRow.Cells("CodMantenimiento").Value), CDate(dgvDatos.CurrentRow.Cells("Fecha").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            MsgBox("ERROR AL ELIMINAR MANTENIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmHoraMotor_Mant
            frm.state_button = True
            frm.CodMantenimiento = dgvDatos.CurrentRow.Cells("CodMantenimiento").Value
            frm.CodMer = codMer
            frm.IdPlan = toNumber(cmbTipoPlanMant.Value)
            frm.Fecha = CDate(dgvDatos.CurrentRow.Cells("Fecha").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.CodMantenimiento)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.CodMantenimiento)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR MANTENIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodMantenimiento").Text
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

    Private Sub Insertar(ByVal registro As HorasMotorService.HorasMotor)
        Try
            Dim estado_process As String
            estado_process = oHorasMotorService.Insertar(registro)
            type_process = "insert"
            If estado_process <> "" Then
                codMer = txtCodMer.Text
                MsgBox("Se insertó las Hrs de recorrido del Equipo Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR HRS DE RECORRIDO DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HorasMotorService.HorasMotor)
        Try
            Dim estado_process As Boolean
            estado_process = oHorasMotorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR HRS DE RECORRIDO DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oHorasMotorService.Borrar(codMer, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR HRS DE RECORRIDO DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oHorasMotorService.MostrarMantenimiento(codMer).Tables(0)
            dgvDatos.DataSource = dtDatos            
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR MANTENIMIENTOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
                    codigo = dgvDatos.CurrentRow.Cells("CodMantenimiento").Text
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

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim registro As New HorasMotorService.HorasMotor
                    Dim Motor As New HorasMotorService.Motor
                    Dim TipoMantenimiento As New HorasMotorService.TipoMantenimiento
                    Dim TipoPlanMantenimiento As New HorasMotorService.TipoPlanMantenimiento

                    Motor.NumSerie = txtCodMer.Text
                    registro.Motor = Motor

                    registro.FecArranqueRep = txtFecArranque.Value

                    registro.FecFinGarantia = txtFecFinGarantia.Value

                    TipoPlanMantenimiento.IdPlan = toNumber(cmbTipoPlanMant.Value)
                    registro.TipoPlanMantenimiento = TipoPlanMantenimiento

                    registro.Swing = cbSwing.Checked
                    registro.Detenido = cbDetenido.Checked

                    registro.CalculoAutomatico = cbCalcAutomatico.Checked

                    TipoMantenimiento.CodMantenimiento = IIf(cmbPlanMant.SelectedIndex = 0, Nothing, cmbPlanMant.Value)
                    registro.TipoMantenimiento = TipoMantenimiento
                    registro.FechaMantenimiento = IIf(txtFecMantenimiento.Text = "", Nothing, txtFecMantenimiento.Value)

                    registro.HorasDiarias = txtHrsDiarias.Value
                    registro.TotalHoras = txtHrsTotales.Value
                    registro.HoraParcial = txtHrsParciales.Value

                    registro.Observacion = txtObservacion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.NomPc = Session.sNomPc

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR HRS DE RECORRIDO DE MOTOR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodMer.Text)) > 0 Then
                If Not (oEquipoService.Buscar(txtCodMer.Text)) Then
                    MsgBox("El número de serie ingresado no está registrado en la tabla MOTORES.", MsgBoxStyle.Information, "Información")
                    LimpiarCampos()
                    txtCodMer.Focus()
                Else
                    ObtenerEquipo(txtCodMer.Text)
                End If
            Else
                MsgBox("Debe ingresar el número de serie.", MsgBoxStyle.Information, "Información")
                'txtCodMer.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodMer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodMer.Validated
        If Len(Trim(txtCodMer.Text)) > 0 Then
            If Not (oEquipoService.Buscar(txtCodMer.Text)) Then
                MsgBox("El número de serie ingresado no está registrado en la tabla MOTORES.", MsgBoxStyle.Information, "Información")
                LimpiarCampos()
                txtCodMer.Focus()
            Else
                ObtenerEquipo(txtCodMer.Text)
            End If
        Else
            btnNumSerie_Click(sender, e)
            'MsgBox("Debe ingresar el número de serie.", MsgBoxStyle.Information, "Información")
            'txtCodMer.Focus()
        End If
    End Sub

    Private Sub cbCalcAutomatico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCalcAutomatico.CheckedChanged
        If cbCalcAutomatico.Checked = True Then
            cmbPlanMant.ReadOnly = True
            cmbPlanMant.BackColor = System.Drawing.SystemColors.Control
            txtFecMantenimiento.ReadOnly = True
            txtFecMantenimiento.BackColor = System.Drawing.SystemColors.Control
        Else
            cmbPlanMant.ReadOnly = False
            cmbPlanMant.BackColor = System.Drawing.SystemColors.Window
            txtFecMantenimiento.ReadOnly = False
            txtFecMantenimiento.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtCodMer.KeyPress _
                        , txtFecFinGarantia.KeyPress _
                        , cmbTipoPlanMant.KeyPress _
                        , cbSwing.KeyPress _
                        , cbCalcAutomatico.KeyPress _
                        , cmbPlanMant.KeyPress _
                        , txtFecMantenimiento.KeyPress _
                        , txtHrsDiarias.KeyPress _
                        , txtHrsTotales.KeyPress _
                        , txtHrsParciales.KeyPress _
                        , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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

    Private Sub txtHrsTotales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHrsTotales.ValueChanged
        txtHrsParciales.Value = oHorasMotorService.SugerirHoraParcial(txtCodMer.Text, txtHrsTotales.Value)
    End Sub

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged

    End Sub

    Private Sub btnNumSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumSerie.Click
        Try
            Dim frm As New frmBuscarMotor
            frm.UbicPers = iCodOfi
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodMer.Text = frm.codigo
                    ObtenerEquipo(txtCodMer.Text)
                Else
                    txtCodMer.Text = ""
                    txtCodMer.Focus()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class