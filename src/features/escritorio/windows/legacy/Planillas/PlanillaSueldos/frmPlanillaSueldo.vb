Imports System.IO
Imports System.Net.Mail
Imports System.ServiceModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPlanillaSueldo

    '===========================Servicios====================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersona As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================   
    Public state_button As Boolean             'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True           'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable 
    Public Cerrado As Boolean
    Public IdPlanilla As Integer
    Public Procesado As Boolean                 'True=Planilla que viene de Sistema de Personal False=Planilla ingresada desde el Módulo Planillas (SIGECOM)
    Public iEstado As Integer                        'Estado de la Planilla Sueldo

    Private dtDatos As DataTable
    Private dtTipoPlanilla As DataTable
    Private dtMonedas As DataTable

    Private Sub frmPlanillaSueldo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesado = oPlanillaSueldosService.BuscarGenProceso(IdPlanilla)
        iEstado = oPlanillaSueldosService.ObtenerIdEstado(IdPlanilla)
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            'gbDetalle.Visible = True
            dgvDatos.Visible = True
            actualizarDetalles()
            Me.Text = "PLANILLA DE SUELDO Nº " + Chr(34) + txtIdPlanilla.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            gbEstado.Visible = True
        Else                          'Nuevo
            cmbMoneda.Value = "NS"
            txtMesRegistro.Text = Format(Month(Today), "00")
            txtPeriodo.Value = Today.Year
            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, Today)), "#0.0000")
            gbEstado.Visible = False
            Me.Size = New System.Drawing.Size(761, 265)
            dgvDatos.Visible = False
            'gbDetalle.Visible = False
            Me.Text = "Registrar nueva Planilla de Sueldo"
            'cbGenProceso.Checked = True
            activar()
            txtPeriodo.Select()
        End If
    End Sub

    Private Sub frmPlanillaSueldo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaSueldo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaSueldosService.Close()
            oPlanillaSueldosDetService.Close()
            oMaestroService.Close()
            oPersona.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oMaestroService.Abort()
            oPersona.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oMaestroService.Abort()
            oPersona.Abort()
            oSeguridadService.Abort()
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
                If CInt(row.Cells("IdPer").Value) = codigo Then
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

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '==================================== TIPO PLANILLA ========================================
            dtTipoPlanilla = oPlanillaSueldosService.MostrarTipoPlanilla().Tables(0)
            cmbTipoPlanilla.DataSource = dtTipoPlanilla
            cmbTipoPlanilla.DropDownList.DataMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.DropDownList.DisplayMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.DropDownList.ValueMember = dtTipoPlanilla.Columns("IdTipo").ToString
            cmbTipoPlanilla.DropDownList.Columns(0).DataMember = dtTipoPlanilla.Columns("IdTipo").ToString
            cmbTipoPlanilla.DropDownList.Columns(1).DataMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.SelectedIndex = 0
            dtTipoPlanilla = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miEnviarCorreo.Enabled = False
            miInsertarMasivo.Enabled = IIf(editable And Procesado = False And iEstado = 1, True, False)
            miProcesarLiquidacion.Enabled = False
            miProcesarVacaciones.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable And iEstado = 1, True, False) 'IIf(editable And Procesado = False And iEstado = 1, True, False)
            miInsertarMasivo.Enabled = False
            miEnviarCorreo.Enabled = True
            miProcesarLiquidacion.Enabled = IIf(editable And iEstado = 1 And cmbTipoPlanilla.Value = 4, True, False)
            miProcesarVacaciones.Enabled = IIf(editable And iEstado = 1 And cmbTipoPlanilla.Value = 1, True, False)
        End If
        miNuevo.Enabled = IIf(editable And Procesado = False And iEstado = 1, True, False)
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGrabar.Enabled = edicion
        biProcesarDetalle.Enabled = IIf(state_button And edicion, True, False)

        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtDuracion.ReadOnly = False
            txtDuracion.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtTipCambio.ReadOnly = False
            txtTipCambio.BackColor = System.Drawing.SystemColors.Window
            cmbTipoPlanilla.ReadOnly = False
            cmbTipoPlanilla.BackColor = System.Drawing.SystemColors.Window

            txtFecProIni.ReadOnly = False
            txtFecProIni.BackColor = System.Drawing.SystemColors.Window
            txtFecProFin.ReadOnly = False
            txtFecProFin.BackColor = System.Drawing.SystemColors.Window
            txtFecPlaIni.ReadOnly = False
            txtFecPlaIni.BackColor = System.Drawing.SystemColors.Window
            txtFecPlaFin.ReadOnly = False
            txtFecPlaFin.BackColor = System.Drawing.SystemColors.Window

            'txtFecExtIni.ReadOnly = False
            'txtFecExtIni.BackColor = System.Drawing.SystemColors.Window
            'txtFecExtFin.ReadOnly = False
            'txtFecExtFin.BackColor = System.Drawing.SystemColors.Window
            'txtFecTarFin.ReadOnly = False
            'txtFecTarFin.BackColor = System.Drawing.SystemColors.Window
            'txtFecTarIni.ReadOnly = False
            'txtFecTarIni.BackColor = System.Drawing.SystemColors.Window


            'cbCerrado.Enabled = True
            cbNoAplicaDscto.Enabled = True
            cbGenProceso.Enabled = True

            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtDuracion.Focus()
        Else
            txtPeriodo.ReadOnly = False
            txtPeriodo.BackColor = System.Drawing.SystemColors.Window
            txtMesRegistro.ReadOnly = False
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
            txtDuracion.ReadOnly = False
            txtDuracion.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtTipCambio.ReadOnly = False
            txtTipCambio.BackColor = System.Drawing.SystemColors.Window
            cmbTipoPlanilla.ReadOnly = False
            cmbTipoPlanilla.BackColor = System.Drawing.SystemColors.Window

            txtFecProIni.ReadOnly = False
            txtFecProIni.BackColor = System.Drawing.SystemColors.Window
            txtFecProFin.ReadOnly = False
            txtFecProFin.BackColor = System.Drawing.SystemColors.Window
            txtFecPlaIni.ReadOnly = False
            txtFecPlaIni.BackColor = System.Drawing.SystemColors.Window
            txtFecPlaFin.ReadOnly = False
            txtFecPlaFin.BackColor = System.Drawing.SystemColors.Window

            'txtFecExtIni.ReadOnly = False
            'txtFecExtIni.BackColor = System.Drawing.SystemColors.Window
            'txtFecExtFin.ReadOnly = False
            'txtFecExtFin.BackColor = System.Drawing.SystemColors.Window           
            'txtFecTarFin.ReadOnly = False
            'txtFecTarFin.BackColor = System.Drawing.SystemColors.Window
            'txtFecTarIni.ReadOnly = False
            'txtFecTarIni.BackColor = System.Drawing.SystemColors.Window

            cbNoAplicaDscto.Enabled = True
            'cbGenProceso.Enabled = True

            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtPeriodo.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtPeriodo.ReadOnly = True
        txtPeriodo.BackColor = System.Drawing.SystemColors.Control
        txtMesRegistro.ReadOnly = True
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
        txtDuracion.ReadOnly = True
        txtDuracion.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtTipCambio.ReadOnly = True
        txtTipCambio.BackColor = System.Drawing.SystemColors.Control
        cmbTipoPlanilla.ReadOnly = True
        cmbTipoPlanilla.BackColor = System.Drawing.SystemColors.Control

        txtFecProIni.ReadOnly = True
        txtFecProIni.BackColor = System.Drawing.SystemColors.Control
        txtFecProFin.ReadOnly = True
        txtFecProFin.BackColor = System.Drawing.SystemColors.Control
        txtFecPlaIni.ReadOnly = True
        txtFecPlaIni.BackColor = System.Drawing.SystemColors.Control
        txtFecPlaFin.ReadOnly = True
        txtFecPlaFin.BackColor = System.Drawing.SystemColors.Control

        'txtFecExtIni.ReadOnly = True
        'txtFecExtIni.BackColor = System.Drawing.SystemColors.Control
        'txtFecExtFin.ReadOnly = True
        'txtFecExtFin.BackColor = System.Drawing.SystemColors.Control      
        'txtFecTarFin.ReadOnly = True
        'txtFecTarFin.BackColor = System.Drawing.SystemColors.Control
        'txtFecTarIni.ReadOnly = True
        'txtFecTarIni.BackColor = System.Drawing.SystemColors.Control

        cbNoAplicaDscto.Enabled = False
        cbGenProceso.Enabled = False

        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        txtPeriodo.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toBlank(txtFecha.Text) = "" Then
            '    MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
            '    txtFecha.BackColor = Color.Red
            '    txtFecha.Focus()
            '    Return False
            'ElseIf toBlank(cmbMoneda.Value) = "" Then
            '    MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
            '    cmbMoneda.Focus()
            '    Return False
            'ElseIf toNumber(IdPersonaSolicita) = 0 Then
            '    MsgBox("Debe Ingresar la Persona que Solicita la Orden ", MsgBoxStyle.Information, "Información")
            '    txtPersonaSolicita.BackColor = Color.Red
            '    btnBuscarPersonaS.Focus()
            '    Return False
            'ElseIf toBlank(cmbArea.Value) = "" Then
            '    MsgBox("Debe de Ingresar el Área.", MsgBoxStyle.Information, "Información")
            '    cmbArea.BackColor = Color.Red
            '    cmbArea.Focus()
            '    Return False
            'ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
            '    MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
            '    txtFecha.BackColor = Color.Red
            '    txtFecha.Focus()
            '    Return False
            'ElseIf cbGastoViaje.Checked = True And cmbProvisional.SelectedIndex = 0 Then
            '    MsgBox("Debe ingresar el Provisional", MsgBoxStyle.Information, "Información")
            '    'cmbProvisional.BackColor = Color.Red
            '    cmbProvisional.Focus()
            '    Return False
            'Else
            Return True
            'End If
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
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(1).Text = Nothing Then
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
            Dim registro As PlanillaSueldosService.PlanillaSueldos
            registro = oPlanillaSueldosService.Obtener(IdPlanilla)

            IdPlanilla = registro.IdPlanilla
            txtIdPlanilla.Text = registro.IdPlanilla
            txtPeriodo.Value = registro.Periodo
            txtMesRegistro.Text = registro.Mes
            txtDuracion.Value = registro.Duracion
            cmbMoneda.Value = registro.Moneda.CodMon
            txtTipCambio.Value = registro.TipCam
            cmbTipoPlanilla.Value = registro.TipoPlanilla.IdTipo
            lblEstado.Text = registro.EstadosPlanillaSueldos.DesEstado

            txtFecPlaIni.Value = registro.FecPlaIni
            txtFecPlaFin.Value = registro.FecPlaFin

            txtFecProIni.Value = registro.FecProIni
            txtFecProFin.Value = registro.FecProFin

            'txtFecTarIni.Value = registro.FecTarIni
            'txtFecTarFin.Value = registro.FecTarFin
            'txtFecExtIni.Value = registro.FecExtIni
            'txtFecExtFin.Value = registro.FecExtFin

            cbNoAplicaDscto.Checked = registro.NoAplicaDscto
            txtObservacion.Text = registro.Observacion
            cbGenProceso.Checked = registro.GenProceso


            txtIngresosDol.Value = registro.TotIngresoDol
            txtIngresosSol.Value = registro.TotIngresoSol
            txtDescuentoDol.Value = registro.TotDescuentoDol
            txtDescuentoSol.Value = registro.TotDescuentoSol
            txtNetoDol.Value = registro.TotalNetoDol
            txtNetoSol.Value = registro.TotalNetoSol
            txtAportacionDol.Value = registro.TotAportacionDol
            txtAportacionSol.Value = registro.TotAportacionSol

            Me.Text = "Planilla de Sueldos Nº " + registro.IdPlanilla.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmPlanillaVarColaborador
            frm.IdPlanilla = IdPlanilla
            frm.IdPersona = 0
            frm.state_button = False
            frm.edicion = True
            frm.editable = True

            If cmbTipoPlanilla.Value = 8 Then 'PLANILLA CTS
                frm.tpAportaciones.TabVisible = False
                frm.tpHorasExtras.TabVisible = False
                frm.tpDescuentos.TabVisible = False
                frm.tpGrati.TabVisible = False
            ElseIf cmbTipoPlanilla.Value = 2 Then 'PLANILLA GRATIFICACION
                frm.tpAportaciones.TabVisible = False
                frm.tpHorasExtras.TabVisible = False
                frm.tpDescuentos.TabVisible = False
                frm.tpCTS.TabVisible = False
            Else
                If oPlanillaSueldosDetService.BuscarVacaciones(Session.sCodEmp, IdPlanilla, frm.IdPersona) Then
                    frm.tpVaca.TabVisible = True
                    frm.tpCTS.TabVisible = False
                    frm.tpGrati.TabVisible = False
                Else
                    frm.tpCTS.TabVisible = False
                    frm.tpGrati.TabVisible = False
                End If

            End If



            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdPersona)
                    mostrarDetalle()
                    actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR EL DETALLE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro del Colaborador = " & dgvDatos.CurrentRow.Cells("ApeNom").Text.ToString & " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmPlanillaVarColaborador
            frm.state_button = True
            frm.IdPlanilla = IdPlanilla
            frm.IdPersona = toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value)
            frm.editable = IIf(iEstado = 1, True, False)
            frm.edicion = False
            If cmbTipoPlanilla.Value = 8 Then 'PLANILLA CTS
                frm.tpAportaciones.TabVisible = False
                frm.tpHorasExtras.TabVisible = False
                frm.tpDescuentos.TabVisible = False
                frm.tpGrati.TabVisible = False
                frm.tpVaca.TabVisible = False
            ElseIf cmbTipoPlanilla.Value = 2 Then 'PLANILLA GRATIFICACION
                frm.tpAportaciones.TabVisible = False
                frm.tpHorasExtras.TabVisible = False
                'frm.tpDescuentos.TabVisible = False
                frm.tpCTS.TabVisible = False
                frm.tpVaca.TabVisible = False
            Else
                If oPlanillaSueldosDetService.BuscarVacaciones(Session.sCodEmp, IdPlanilla, frm.IdPersona) Then
                    frm.tpVaca.TabVisible = True
                    frm.tpCTS.TabVisible = True
                    frm.tpGrati.TabVisible = True
                Else
                    frm.tpCTS.TabVisible = False
                    frm.tpGrati.TabVisible = False
                    frm.tpVaca.TabVisible = False
                End If

            End If

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizar()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdPersona)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizar()
            RowPossesion(dgvDatos, frm.IdPersona)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdPer").Text
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

    Private Sub Insertar(ByVal registro As PlanillaSueldosService.PlanillaSueldos)
        Try
            Dim estado_process As Integer
            oPlanillaSueldosService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            estado_process = oPlanillaSueldosService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPlanilla = estado_process
                MsgBox("Se insertó la Planilla de Sueldos Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosService.PlanillaSueldos)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Planilla Sueldos Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.Borrar(IdPlanilla, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPlanillaSueldosDetService.Mostrar(IdPlanilla).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
            InhabilitarColumnas()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InhabilitarColumnas()
        Try
            If cmbMoneda.Value = "NS" Then

                dgvDatos.RootTable.Columns(8).Visible = False
                dgvDatos.RootTable.Columns(9).Visible = False
                dgvDatos.RootTable.Columns(10).Visible = True
                dgvDatos.RootTable.Columns(11).Visible = True

            ElseIf cmbMoneda.Value = "US" Then

                dgvDatos.RootTable.Columns(8).Visible = True
                dgvDatos.RootTable.Columns(9).Visible = True
                dgvDatos.RootTable.Columns(10).Visible = False
                dgvDatos.RootTable.Columns(11).Visible = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR COLUMNAS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New PlanillaSueldosService.PlanillaSueldos
                Dim TipoPlanilla As New PlanillaSueldosService.TipoPlanilla
                Dim Moneda As New PlanillaSueldosService.Moneda
                Dim Empresa As New PlanillaSueldosService.Empresa
                Dim Estado As New PlanillaSueldosService.EstadosPlanillaSueldos

                registro.IdPlanilla = IdPlanilla
                registro.Periodo = txtPeriodo.Value
                registro.Mes = txtMesRegistro.Text
                registro.Duracion = txtDuracion.Value
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.TipCam = txtTipCambio.Value
                TipoPlanilla.IdTipo = cmbTipoPlanilla.Value
                registro.TipoPlanilla = TipoPlanilla

                registro.FecPlaIni = txtFecPlaIni.Value
                registro.FecPlaFin = txtFecPlaFin.Value

                registro.FecProIni = txtFecProIni.Value
                registro.FecProFin = txtFecProFin.Value

                registro.FecTarIni = Nothing
                registro.FecTarFin = Nothing
                registro.FecExtIni = Nothing
                registro.FecExtFin = Nothing

                registro.NoAplicaDscto = cbNoAplicaDscto.Checked
                registro.Observacion = txtObservacion.Text

                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Estado.IdEstado = 1
                    registro.EstadosPlanillaSueldos = Estado
                    registro.GenProceso = cbGenProceso.Checked
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ...?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
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
        Dim estado As Integer
        estado = oPlanillaSueldosService.ObtenerIdEstado(CInt(txtIdPlanilla.Text))
        If state_button = True And estado = 1 Then
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
                    codigo = dgvDatos.CurrentRow.Cells("IdPer").Text
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

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtMesRegistro.Text)
                If cant < 2 Then
                    txtMesRegistro.Text = "0" & txtMesRegistro.Text
                End If
                If toNumber(txtMesRegistro.Text) < 1 Or toNumber(txtMesRegistro.Text) > 12 Then
                    MsgBox("Rango del Mes [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                    txtMesRegistro.Text = ""
                    txtMesRegistro.Focus()
                Else
                    txtDuracion.Value = DateTime.DaysInMonth(txtPeriodo.Value, toNumber(txtMesRegistro.Text))
                    txtDuracion.Focus()
                End If
            Else
                MsgBox("Debe ingresar el Mes", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtMesRegistro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.TextChanged
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            If Not (toNumber(txtMesRegistro.Text) < 1 Or toNumber(txtMesRegistro.Text) > 12) Then
                txtDuracion.Value = DateTime.DaysInMonth(txtPeriodo.Value, toNumber(txtMesRegistro.Text))
            End If
        End If
    End Sub

    Private Sub txtPeriodo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriodo.TextChanged
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            If Not (toNumber(txtMesRegistro.Text) < 1 Or toNumber(txtMesRegistro.Text) > 12) Then
                txtDuracion.Value = DateTime.DaysInMonth(txtPeriodo.Value, toNumber(txtMesRegistro.Text))
            End If
        End If
    End Sub


    '=============================Evento KeyPress===================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtPeriodo.KeyPress _
                        , txtDuracion.KeyPress _
                        , cmbMoneda.KeyPress _
                        , txtTipCambio.KeyPress _
                        , cmbTipoPlanilla.KeyPress _
                        , cbNoAplicaDscto.KeyPress _
                        , txtFecPlaIni.KeyPress _
                        , txtFecPlaFin.KeyPress _
                        , txtObservacion.KeyPress _
                        , txtFecProIni.KeyPress _
                        , txtFecProFin.KeyPress
        ', txtFecTarIni.KeyPress _
        ', txtFecTarFin.KeyPress _
        ', txtFecExtIni.KeyPress _
        ', txtFecExtFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub txtMesRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Validated
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtMesRegistro.Text)
            If cant < 2 Then
                txtMesRegistro.Text = "0" & txtMesRegistro.Text
            End If
            If toNumber(txtMesRegistro.Text) < 1 Or toNumber(txtMesRegistro.Text) > 12 Then
                MsgBox("Rango del Mes [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                txtMesRegistro.Text = ""
                txtMesRegistro.Focus()
            Else
                txtDuracion.Value = DateTime.DaysInMonth(txtPeriodo.Value, toNumber(txtMesRegistro.Text))
            End If
        Else
            MsgBox("Debe ingresar el Mes", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "PDF" Then

                Dim forma As New frmReportes
                Dim reporte As New rpBoletaPago
                Dim reporteCTS As New rpBoletaPagoCTS
                Dim reporteCTSEquimap As New rpBoletaPagoCTSEquimap
                Dim dtReporte As DataTable
                Dim dtSubreporte As DataTable

                If cmbTipoPlanilla.Value = 8 Then 'CTS
                    dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), 0, "", 0, 8).Tables(0)
                Else
                    dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), 0, "", 0, 1).Tables(0)
                    dtSubreporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), 0, "", 0, 1).Tables(0)
                End If

                If reporte.Subreports.Count > 0 Then
                    reporte.Subreports(0).SetDataSource(dtSubreporte)
                End If


                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else



                    If cmbTipoPlanilla.Value = 8 Then 'CTS
                        If Session.sCodEmp = "05" Then
                            reporteCTSEquimap.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteCTSEquimap
                        Else
                            reporteCTS.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteCTS
                        End If

                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then

                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    '  forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte Boleta de Pago"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir Boleta de Pago : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miInsertarMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miInsertarMasivo.Click
        Try
            If dgvDatos.RowCount = 0 Then
                Dim frm As New frmPlanillaSueldos_InsertarMasivo
                frm.IdPlanilla = IdPlanilla
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biProcesarDetalle_Click(sender As Object, e As EventArgs) Handles biProcesarDetalle.Click
        Try
            If MsgBox("¿Está seguro que desea procesar los detalles?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New PlanillaSueldosService.PlanillaSueldos
                Dim TipoPlanilla As New PlanillaSueldosService.TipoPlanilla
                Dim Moneda As New PlanillaSueldosService.Moneda
                Dim Empresa As New PlanillaSueldosService.Empresa
                Dim Estado As New PlanillaSueldosService.EstadosPlanillaSueldos

                registro.IdPlanilla = txtIdPlanilla.Text
                registro.Periodo = txtPeriodo.Value
                registro.Mes = txtMesRegistro.Text
                registro.Duracion = txtDuracion.Value
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.TipCam = txtTipCambio.Value
                TipoPlanilla.IdTipo = cmbTipoPlanilla.Value
                registro.TipoPlanilla = TipoPlanilla

                registro.FecPlaIni = txtFecPlaIni.Value
                registro.FecPlaFin = txtFecPlaFin.Value

                registro.FecProIni = txtFecProIni.Value
                registro.FecProFin = txtFecProFin.Value

                registro.FecTarIni = Nothing
                registro.FecTarFin = Nothing
                registro.FecExtIni = Nothing
                registro.FecExtFin = Nothing

                registro.NoAplicaDscto = cbNoAplicaDscto.Checked
                registro.Observacion = txtObservacion.Text

                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                registro.GenProceso = True


                Dim estado_process As Boolean
                oPlanillaSueldosService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
                estado_process = oPlanillaSueldosService.InsertarDetalleMasivo(registro)
                type_process = "update"
                If estado_process = True Then
                    MsgBox("Se proceso los detalles de la Planilla de Sueldos Correctamente")
                    desactivar()
                    ObtenerRegistro()
                    actualizarDetalles()
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If


            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub GenerarPDF()

        Dim forma As New frmReportes
        Dim reporte As New rpBoletaPago
        Dim dtReporte As DataTable
        Dim dtSubreporte As DataTable
        Dim reporteCTS As New rpBoletaPagoCTS
        Dim reporteCTSEquimap As New rpBoletaPagoCTSEquimap
        Dim reporteCTSAmazonica As New rpBoletaPagoCTSAmazonica

        If cmbTipoPlanilla.Value = 8 Then
            dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), 0, "", 0, 8).Tables(0)
        Else
            dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), 0, "", 0, 1).Tables(0)
            dtSubreporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), 0, "", 0, 1).Tables(0)
        End If


        If dtReporte.Rows.Count = 0 Then
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            If cmbTipoPlanilla.Value = 8 Then
                If Session.sCodEmp = "05" Then
                    reporteCTSEquimap.SetDataSource(dtReporte)
                    ExportToPDF(reporteCTSEquimap, "miReporte.pdf", "118")
                ElseIf Session.sCodEmp = "02" Then
                    reporteCTSAmazonica.SetDataSource(dtReporte)
                    ExportToPDF(reporteCTSAmazonica, "miReporte.pdf", "118")
                Else
                    reporteCTS.SetDataSource(dtReporte)
                    ExportToPDF(reporteCTS, "miReporte.pdf", "118")
                End If

            Else
                If reporte.Subreports.Count > 0 Then
                    reporte.Subreports(0).SetDataSource(dtSubreporte)
                End If
                reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte
                ''  forma.crvReportes.DisplayGroupTree = False
                'forma.Text = "Reporte Boleta de Pago"
                'forma.ShowDialog()
                ExportToPDF(reporte, "miReporte.pdf", "118")
            End If

        End If
    End Sub

    Private Sub CrearCarpeta()
        Try
            Dim idcodigo As String = dgvDatos.CurrentRow.Cells("IdPer").Value
            If Not Directory.Exists("D:\BoletaSueldoElectronicas\" & Session.sDesEmp & "\" & IdPlanilla.ToString() & "\" & idcodigo) Then
                Directory.CreateDirectory("D:\BoletaSueldoElectronicas\" & Session.sDesEmp & "\" & IdPlanilla.ToString() & "\" & idcodigo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub
    Public Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, codigo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try

            Dim idcodigo As String = dgvDatos.CurrentRow.Cells("IdPer").Value

            diskOpts.DiskFileName = "D:\BoletaSueldoElectronicas\" & Session.sDesEmp & "\" & IdPlanilla.ToString() & "\" & idcodigo & "\" & txtPeriodo.Text & txtMesRegistro.Text & idcodigo & ".pdf"

            rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            'diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()
        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function

    Private Sub miEnviarCorreo_Click(sender As Object, e As EventArgs) Handles miEnviarCorreo.Click
        CrearCarpeta()
        GenerarPDF()
        EnviarCorreo()
    End Sub

    Private Sub EnviarCorreo()

        'Try


        '    Dim parametro As New PlanillaSueldosService.ParametrosPlanilla
        '    parametro = oPlanillaSueldosService.ObtenerParametros(Session.sCodEmp)
        '    Dim idcodigo As String = dgvDatos.CurrentRow.Cells("IdPer").Value

        '    Dim email As String = oPersona.ObtenerEmail(idcodigo)
        '    Dim copia As String = ""
        '    Dim SendFrom As MailAddress = New MailAddress(parametro.CorreoEmisor)
        '    Dim SendTo As MailAddress = New MailAddress(email)
        '    Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
        '    If toBlank(copia) <> "" Then
        '        MyMessage.CC.Add(copia)
        '    End If
        '    MyMessage.Subject = Session.sDesEmp & " Boleta de Sueldo " & txtMesRegistro.Text & "-" & txtPeriodo.Text
        '    MyMessage.Body = "Envio de Boleta de Pago de Sueldo c/Adjunto pdf" & Environment.NewLine & Environment.NewLine & "No Contestar el correo porque es una cuenta desatendida"

        '    'Dim destdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".zip"
        '    'Dim xmldir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".xml"
        '    Dim pdfdir As String = "D:\BoletaSueldoElectronicas\" & Session.sDesEmp & "\" & IdPlanilla.ToString() & "\" & idcodigo & "\" & txtPeriodo.Text & txtMesRegistro.Text & idcodigo & ".pdf"


        '    'Dim attachFile As Attachment = New Attachment(xmldir)
        '    'MyMessage.Attachments.Add(attachFile)
        '    Dim attachFile1 As Attachment = New Attachment(pdfdir)
        '    MyMessage.Attachments.Add(attachFile1)

        '    Dim smtp As New System.Net.Mail.SmtpClient
        '    smtp.Host = parametro.MailHost
        '    smtp.Credentials = New System.Net.NetworkCredential(parametro.CorreoEmisor, parametro.ClaveCorreoEmisor)
        '    smtp.Send(MyMessage)
        '    MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)

        'Catch ex As Exception
        '    MsgBox("Error al enviar por correo : " + ex.ToString, MsgBoxStyle.Exclamation)
        'End Try


        Try
            If dgvDatos.RowCount() > 0 Then
                Dim frm As New frmPlanillaSueldoEnviarCorreo
                frm.idPlanilla = IdPlanilla
                frm.idPer = dgvDatos.CurrentRow.Cells("IdPer").Value
                frm.periodo = txtPeriodo.Text
                frm.mes = txtMesRegistro.Text

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub miProcesarLiquidacion_Click(sender As Object, e As EventArgs) Handles miProcesarLiquidacion.Click
        Try
            If dgvDatos.RowCount > 0 Then

                oPlanillaSueldosService.GenerarLiquidacion(IdPlanilla, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                actualizar()

                MsgBox("Se proceso con exito la Liquidación.!!!!!!", MsgBoxStyle.Information, "Exito")

            Else
                MsgBox("No existe datos que procesar!!!!!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR LIQUIDACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miProcesarVacaciones_Click(sender As Object, e As EventArgs) Handles miProcesarVacaciones.Click
        Try
            If dgvDatos.RowCount > 0 Then

                oPlanillaSueldosService.GenerarVacaciones(IdPlanilla, dgvDatos.CurrentRow.Cells("IdPer").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                actualizar()

                MsgBox("Se proceso con exito las Vacaciones.!!!!!!", MsgBoxStyle.Information, "Exito")
            Else
                MsgBox("No existe datos que procesar!!!!!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR LIQUIDACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbTipoPlanilla_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPlanilla.ValueChanged
        If cmbTipoPlanilla.Value = 1 Then
            cbGenProceso.Checked = True
        Else
            cbGenProceso.Checked = False
        End If
    End Sub
End Class