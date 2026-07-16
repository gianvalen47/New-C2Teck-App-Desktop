Imports System.ServiceModel
Public Class frmPlanillaVarColaborador

    '===========================Servicios====================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    Public IdPlanilla As Integer
    Public IdPersona As Integer
    Public iEstado As Integer

    Private dtIngresos As DataTable
    Private dtDsctos As DataTable
    Private dtHrsExtras As DataTable
    Private dtAportaciones As DataTable
    Private dtCTS As DataTable
    Private dtGrati As DataTable
    Private dtVaca As DataTable
    Private Sub frmPlanillaVarColaborador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosDetService.Close()
            oPlanillaSueldosService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosDetService.Abort()
            oPlanillaSueldosService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosDetService.Abort()
            oPlanillaSueldosService.Abort()
        End Try        
    End Sub

    Private Sub frmPlanillaVarColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaVarColaborador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvIngresos)
        dgvIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvDsctos)
        dgvDsctos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvHrsExtras)
        dgvHrsExtras.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvAportaciones)
        dgvAportaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvCTS)
        dgvCTS.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvGrati)
        dgvGrati.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvVaca)
        dgvVaca.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        iEstado = oPlanillaSueldosService.ObtenerIdEstado(IdPlanilla)
        txtIdPlanilla.Text = IdPlanilla
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            listaDatosIngresos()
            listaDatosDsctos()
            listaDatosHrsExtras()
            listaDatosAportaciones()
            listaDatosCTS()
            listaDatosGrati()
            listaDatosVaca()
            desactivar()
            'Me.Text = "SOLICITUD DE GASTOS Nº " + Chr(34) + txtNumGasto.Text.ToString + Chr(34)
        Else                          'Nuevo
            'Me.Text = "Registrar nueva Solicitud de Gastos"            
            activar()
            txtDiasMovilidad.Focus()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SumarMontos(ByVal dgv As Janus.Windows.GridEX.GridEX, ByVal txtMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox, ByVal txtMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox)
        Try
            If dgv.RowCount > 0 Then
                Dim totalSoles As Double = 0
                Dim totalDolares As Double = 0
                Dim row As Janus.Windows.GridEX.GridEXRow
                Dim bMontoNS As Boolean
                Dim bMontoUS As Boolean
                For i = 0 To dgv.RowCount - 1
                    dgv.Row = i
                    row = dgv.GetRow()
                    bMontoNS = row.Cells("MontoSol").Value
                    If bMontoNS Then
                        totalSoles = totalSoles + CDbl(dgv.CurrentRow.Cells("MontoSol").Value)                    
                    End If
                Next

                For i = 0 To dgv.RowCount - 1
                    dgv.Row = i
                    row = dgv.GetRow()
                    bMontoUS = row.Cells("MontoDol").Value
                   If bMontoUS Then
                        totalDolares = totalDolares + CDbl(dgv.CurrentRow.Cells("MontoDol").Value)
                    End If
                Next
                txtMontoSol.Value = totalSoles
                txtMontoDol.Value = totalDolares
            End If            
        Catch ex As Exception
            MsgBox("Error al sumar Montos " + dgv.Name + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvIngresos.RowCount < 1 Then
            miMostrarIng.Enabled = False
            miEliminarIng.Enabled = False            
        Else
            miMostrarIng.Enabled = True
            miEliminarIng.Enabled = IIf(iEstado = 1, True, False)
        End If
        If dgvDsctos.RowCount < 1 Then
            miMostrarDscto.Enabled = False
            miEliminarDscto.Enabled = False
        Else
            miMostrarDscto.Enabled = True
            miEliminarDscto.Enabled = IIf(iEstado = 1, True, False)
        End If
        If dgvHrsExtras.RowCount < 1 Then
            miMostrarHrsExtras.Enabled = False
            miEliminarHrsExtras.Enabled = False
        Else
            miMostrarHrsExtras.Enabled = True
            miEliminarHrsExtras.Enabled = IIf(iEstado = 1, True, False)
        End If

        miNuevoIng.Enabled = IIf(editable, True, False)
        miNuevoHrsExtras.Enabled = IIf(editable, True, False)
        miNuevoDscto.Enabled = IIf(editable, True, False)

        tpIngresos.Enabled = IIf(state_button = True And edicion = False, True, False)
        tpHorasExtras.Enabled = IIf(state_button = True And edicion = False, True, False)
        tpDescuentos.Enabled = IIf(state_button = True And edicion = False, True, False)
        tpAportaciones.Enabled = If(state_button = True And edicion = False, True, False)

        btnEditar.Enabled = IIf(editable, Not edicion, False)
        btnGuardar.Enabled = edicion
        btnDeshacer.Enabled = IIf(edicion And state_button, True, False)
        'cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub activar()
        If state_button Then
            btnBuscarPersona.Enabled = False
            txtDiasMovilidad.ReadOnly = False
            txtDiasMovilidad.BackColor = System.Drawing.SystemColors.Window
            txtDiasPDT.ReadOnly = False
            txtDiasPDT.BackColor = System.Drawing.SystemColors.Window
            txtDiasPago.ReadOnly = False
            txtDiasPago.BackColor = System.Drawing.SystemColors.Window
            txtDiasReales.ReadOnly = False
            txtDiasReales.BackColor = System.Drawing.SystemColors.Window

            txtHorasReales.ReadOnly = False
            txtHorasReales.BackColor = System.Drawing.SystemColors.Window

            txtMontoMovil.ReadOnly = False
            txtMontoMovil.BackColor = System.Drawing.SystemColors.Window

            txtVacacionIni.ReadOnly = False
            txtVacacionIni.BackColor = System.Drawing.SystemColors.Window
            txtVacacionFin.ReadOnly = False
            txtVacacionFin.BackColor = System.Drawing.SystemColors.Window
            ckPagado.Enabled = True

            edicion = True
            enableOpciones()
            txtDiasMovilidad.Focus()

            edicion = True
            enableOpciones()
            txtDiasMovilidad.Focus()
        Else
            btnBuscarPersona.Enabled = True
            txtDiasMovilidad.ReadOnly = False
            txtDiasMovilidad.BackColor = System.Drawing.SystemColors.Window
            txtDiasPDT.ReadOnly = False
            txtDiasPDT.BackColor = System.Drawing.SystemColors.Window
            txtDiasPago.ReadOnly = False
            txtDiasPago.BackColor = System.Drawing.SystemColors.Window
            txtDiasReales.ReadOnly = False
            txtDiasReales.BackColor = System.Drawing.SystemColors.Window

            txtHorasReales.ReadOnly = False
            txtHorasReales.BackColor = System.Drawing.SystemColors.Window

            txtMontoMovil.ReadOnly = False
            txtMontoMovil.BackColor = System.Drawing.SystemColors.Window

            txtVacacionIni.ReadOnly = False
            txtVacacionIni.BackColor = System.Drawing.SystemColors.Window
            txtVacacionFin.ReadOnly = False
            txtVacacionFin.BackColor = System.Drawing.SystemColors.Window
            ckPagado.Enabled = True

            edicion = True
            enableOpciones()
            txtDiasMovilidad.Focus()
        End If
    End Sub

    Private Sub desactivar()
        btnBuscarPersona.Enabled = False

        txtDiasMovilidad.ReadOnly = True
        txtDiasMovilidad.BackColor = System.Drawing.SystemColors.Control
        txtDiasPDT.ReadOnly = True
        txtDiasPDT.BackColor = System.Drawing.SystemColors.Control
        txtDiasPago.ReadOnly = True
        txtDiasPago.BackColor = System.Drawing.SystemColors.Control
        txtDiasReales.ReadOnly = True
        txtDiasReales.BackColor = System.Drawing.SystemColors.Control

        txtHorasReales.ReadOnly = True
        txtHorasReales.BackColor = System.Drawing.SystemColors.Control

        txtMontoMovil.ReadOnly = True
        txtMontoMovil.BackColor = System.Drawing.SystemColors.Control

        txtVacacionIni.ReadOnly = True
        txtVacacionIni.BackColor = System.Drawing.SystemColors.Control
        txtVacacionFin.ReadOnly = True
        txtVacacionFin.BackColor = System.Drawing.SystemColors.Control

        ckPagado.Enabled = False

        edicion = False
        enableOpciones()
        txtDiasMovilidad.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                btnBuscarPersona.Focus()
                Return False
                'ElseIf toNumber(txtDiasPago.Value) = 0 Then
                '    MsgBox("Debe Ingresar los Dias de Pago.", MsgBoxStyle.Information, "Información")
                '    txtDiasPago.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionadoIng() As Boolean
        Try
            If dgvIngresos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvIngresos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvIngresos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionadoIngCTS() As Boolean
        Try
            If dgvCTS.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCTS.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCTS.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Function ValidaCodigoSeleccionadoDes() As Boolean
        Try
            If dgvDsctos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDsctos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDsctos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionadoHrsExtras() As Boolean
        Try
            If dgvHrsExtras.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvHrsExtras.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvHrsExtras.CurrentRow.Cells(0).Text = Nothing Then
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
            Dim registro As PlanillaSueldosDetService.PlanillaSueldosDet
            registro = oPlanillaSueldosDetService.Obtener(IdPlanilla, IdPersona)

            IdPlanilla = registro.PlanillaSueldos.IdPlanilla
            txtIdPlanilla.Text = registro.PlanillaSueldos.IdPlanilla
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom

            txtDiasMovilidad.Value = registro.DiasMovil
            txtDiasPDT.Value = registro.DiasPDT
            txtDiasPago.Value = registro.DiasPago
            txtDiasReales.Value = registro.DiasReales

            txtHorasReales.Value = registro.HorasReales
            txtMontoMovil.Value = registro.MontoMovil

            If registro.VacacionIni.ToString <> "" Then
                txtVacacionIni.Value = registro.VacacionIni
                txtVacacionIni.Text = registro.VacacionIni.ToString
            Else
                txtVacacionIni.IsNullDate = True
            End If

            If registro.VacacionFin.ToString <> "" Then
                txtVacacionFin.Value = registro.VacacionFin
                txtVacacionFin.Text = registro.VacacionFin.ToString
            Else
                txtVacacionFin.IsNullDate = True
            End If
            txtTotalNetoDol.Value = registro.TotalNetoDol
            txtTotalNetoSol.Value = registro.TotalNetoSol
            ckPagado.Checked = registro.Pagado
            'Me.Text = "Planilla de Sueldos Nº " + registro.IdPlanilla.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDet)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                'IdPlanilla = estado_process
                MsgBox("Se insertó el registro Correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDet)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el registro Correctamente")
                desactivar()
                ObtenerRegistro()
                listaDatosIngresos()                
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.Borrar(IdPlanilla, IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosIngresos()
        Try
            dtIngresos = oPlanillaSueldosDetService.MostrarIngreso(IdPlanilla, IdPersona).Tables(0)
            dgvIngresos.DataSource = dtIngresos
            enableOpciones()
            SumarMontos(dgvIngresos, txtTotalNSIng, txtTotalUSIng)
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE INGRESOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosDsctos()
        Try
            dtDsctos = oPlanillaSueldosDetService.MostrarDescuento(IdPlanilla, IdPersona).Tables(0)
            dgvDsctos.DataSource = dtDsctos
            enableOpciones()
            SumarMontos(dgvDsctos, txtTotalNSDsctos, txtTotalUSDsctos)
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE DSCTOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosHrsExtras()
        Try
            dtHrsExtras = oPlanillaSueldosDetService.MostrarHoraExtra(IdPlanilla, IdPersona).Tables(0)
            dgvHrsExtras.DataSource = dtHrsExtras
            enableOpciones()            
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE HORAS EXTRAS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosAportaciones()
        Try
            dtAportaciones = oPlanillaSueldosDetService.MostrarAportacion(IdPlanilla, IdPersona).Tables(0)
            dgvAportaciones.DataSource = dtAportaciones
            SumarMontos(dgvAportaciones, txtTotalNSAport, txtTotalUSAport)

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE APORTACIONES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosCTS()
        Try
            dtCTS = oPlanillaSueldosDetService.MostrarIngresoCTS(IdPlanilla, IdPersona).Tables(0)
            dgvCTS.DataSource = dtCTS
            SumarMontos(dgvCTS, txtTotalNSCTS, txtTotalUSCTS)

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE APORTACIONES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub txtDiasReales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiasReales.ValueChanged
        txtHorasReales.Value = oPlanillaSueldosDetService.ObtenerParametroHoraReal(Session.sCodEmp) * txtDiasReales.Value
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New PlanillaSueldosDetService.PlanillaSueldosDet
                Dim PlanillaSueldo As New PlanillaSueldosDetService.PlanillaSueldos
                Dim Persona As New PlanillaSueldosDetService.Persona

                PlanillaSueldo.IdPlanilla = IdPlanilla
                registro.PlanillaSueldos = PlanillaSueldo
                Persona.IdPer = IdPersona
                registro.Persona = Persona

                registro.DiasMovil = txtDiasMovilidad.Value
                registro.DiasPDT = txtDiasPDT.Value
                registro.DiasPago = txtDiasPago.Value
                registro.DiasReales = txtDiasReales.Value

                registro.HorasReales = txtHorasReales.Value
                registro.MontoMovil = txtMontoMovil.Value

                registro.VacacionIni = IIf(txtVacacionIni.Text = "", Nothing, txtVacacionIni.Value)
                registro.VacacionFin = IIf(txtVacacionFin.Text = "", Nothing, txtVacacionFin.Value)

                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                registro.FecReg = Today
                registro.Pagado = ckPagado.Checked

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo                
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR PLANILLA SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            desactivar()
            ObtenerRegistro()
        End If
    End Sub
    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub RowPossesionIng(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubroIng").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionIngCTS(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("Item").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionDscto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubroDes").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionHrsExtras(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdHoraExtra").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    '===================================INGRESOS=======================================
    Private Sub miNuevoIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoIng.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPlanillaSueldos_Ing
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtIngresos = Nothing
                    listaDatosIngresos()
                    listaDatosHrsExtras()
                    If frm.type_process = "insert" Then
                        RowPossesionIng(dgvIngresos, frm.IdRubroIng)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO INGRESO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarIng.Click, dgvIngresos.DoubleClick
        Try
            If ValidaCodigoSeleccionadoIng() Then
                Dim frm As New frmPlanillaSueldos_Ing
                frm.state_button = True
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.IdRubroIng = toNumber(dgvIngresos.CurrentRow.Cells("IdRubroIng").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtIngresos = Nothing
                    listaDatosIngresos()
                    listaDatosHrsExtras()
                    If frm.type_process = "update" Then
                        RowPossesionIng(dgvIngresos, frm.IdRubroIng)
                    Else
                        MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesionIng(dgvIngresos, frm.IdRubroIng)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR INGRESO " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarIng.Click
        Try
            cmOpcionesIngresos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarIngreso(toNumber(txtIdPlanilla.Text), IdPersona, toNumber(dgvIngresos.CurrentRow.Cells("IdRubroIng").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtIngresos = Nothing
                    listaDatosIngresos()
                    listaDatosHrsExtras()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR INGRESO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarIng.Click
        listaDatosIngresos()        
    End Sub

    Private Sub miReprocesarIng_Click(sender As System.Object, e As System.EventArgs) Handles miReprocesarIng.Click
        Try
            If MsgBox("¿Está seguro de REPROCESAR los registros?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.ReprocesarIngresos(toNumber(txtIdPlanilla.Text), IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtIngresos = Nothing
                    listaDatosIngresos()
                    MsgBox("Se reprocesó los registros correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL REPROCESAR LOS INGRESOS :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================

    '==================================HORAS EXTRAS======================================
    Private Sub miNuevoHrsExtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoHrsExtras.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPlanillaSueldos_HrsExt
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtHrsExtras = Nothing
                    listaDatosHrsExtras()
                    listaDatosIngresos()
                    If frm.type_process = "insert" Then
                        RowPossesionHrsExtras(dgvHrsExtras, frm.IdHoraExtra)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA HORA EXTRA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarHrsExtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarHrsExtras.Click, dgvHrsExtras.DoubleClick
        Try
            If ValidaCodigoSeleccionadoHrsExtras() Then
                Dim frm As New frmPlanillaSueldos_HrsExt
                frm.state_button = True
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.IdHoraExtra = toNumber(dgvHrsExtras.CurrentRow.Cells("IdHoraExtra").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtHrsExtras = Nothing
                    listaDatosHrsExtras()
                    listaDatosIngresos()
                    If frm.type_process = "update" Then
                        RowPossesionHrsExtras(dgvHrsExtras, frm.IdHoraExtra)
                    Else
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesionHrsExtras(dgvHrsExtras, frm.IdHoraExtra)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR HORA EXTRA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarHrsExtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarHrsExtras.Click
        Try
            cmOpcionesIngresos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarHoraExtra(toNumber(txtIdPlanilla.Text), IdPersona, toNumber(dgvHrsExtras.CurrentRow.Cells("IdHoraExtra").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtHrsExtras = Nothing
                    listaDatosHrsExtras()
                    listaDatosIngresos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR HORA EXTRA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarHrsExtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarHrsExtras.Click
        listaDatosHrsExtras()
    End Sub

    Private Sub miReprocesarHrsExtras_Click(sender As System.Object, e As System.EventArgs) Handles miReprocesarHrsExtras.Click
        Try
            If MsgBox("¿Está seguro de REPROCESAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.ReprocesarHorasExtras(toNumber(txtIdPlanilla.Text), IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtIngresos = Nothing
                    listaDatosHrsExtras()
                    listaDatosIngresos()
                    MsgBox("Se reprocesó los registros correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL REPROCESAR LAS HORAS EXTRAS :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================

    '===================================DESCUENTOS======================================
    Private Sub miNuevoDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoDscto.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPlanillaSueldos_dsctos
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDsctos = Nothing
                    listaDatosDsctos()
                    If frm.type_process = "insert" Then
                        RowPossesionDscto(dgvDsctos, frm.IdRubroDes)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DESCUENTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarDscto.Click, dgvDsctos.DoubleClick
        Try
            If ValidaCodigoSeleccionadoDes() Then
                Dim frm As New frmPlanillaSueldos_dsctos
                frm.state_button = True
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.IdRubroDes = toNumber(dgvDsctos.CurrentRow.Cells("IdRubroDes").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDsctos = Nothing
                    listaDatosDsctos()
                    If frm.type_process = "update" Then
                        RowPossesionDscto(dgvDsctos, frm.IdRubroDes)
                    Else
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesionDscto(dgvDsctos, frm.IdRubroDes)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DESCUENTO " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarDscto.Click
        Try
            cmOpcionesIngresos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarDescuento(toNumber(txtIdPlanilla.Text), IdPersona, toNumber(dgvDsctos.CurrentRow.Cells("IdRubroDes").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDsctos = Nothing
                    listaDatosDsctos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DESCUENTO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarDscto.Click
        listaDatosDsctos()
    End Sub

    Private Sub miReprocesarDscto_Click(sender As System.Object, e As System.EventArgs) Handles miReprocesarDscto.Click
        Try            
            If MsgBox("¿Está seguro de REPROCESAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.ReprocesarDescuentos(toNumber(txtIdPlanilla.Text), IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDsctos = Nothing
                    listaDatosDsctos()
                    MsgBox("Se reprocesó los registros correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL REPROCESAR LOS DESCUENTOS :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mbNuevoCts_Click(sender As Object, e As EventArgs) Handles mbNuevoCts.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPlanillaSueldos_IngCTS
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.state_button = False
                frm.txtItem.Value = dgvCTS.RowCount() + 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtCTS = Nothing
                    listaDatosIngresos()
                    listaDatosCTS()
                    If frm.type_process = "insert" Then
                        RowPossesionIngCTS(dgvCTS, frm.Item)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO INGRESO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mbMostrarCts_Click(sender As Object, e As EventArgs) Handles mbMostrarCts.Click, dgvCTS.DoubleClick
        Try
            If ValidaCodigoSeleccionadoIngCTS() Then
                Dim frm As New frmPlanillaSueldos_IngCTS
                frm.state_button = True
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.Item = toNumber(dgvCTS.CurrentRow.Cells("Item").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtIngresos = Nothing
                    listaDatosIngresos()
                    listaDatosCTS()
                    If frm.type_process = "update" Then
                        RowPossesionIngCTS(dgvCTS, frm.Item)
                    Else
                        MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesionIngCTS(dgvCTS, frm.Item)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR INGRESO " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mbEliminarCts_Click(sender As Object, e As EventArgs) Handles mbEliminarCts.Click
        Try
            cmOpcionesCTS.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarIngresoCTS(toNumber(txtIdPlanilla.Text), IdPersona, toNumber(dgvCTS.CurrentRow.Cells("Item").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtCTS = Nothing
                    listaDatosCTS()
                    listaDatosIngresos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CTS :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mbRefrescarCts_Click(sender As Object, e As EventArgs) Handles mbRefrescarCts.Click
        listaDatosCTS()
    End Sub
    '====================================================================================


    '=====================GRATIFICACION===========================
    Private Function ValidaCodigoSeleccionadoIngGrati() As Boolean
        Try
            If dgvGrati.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvGrati.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvGrati.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub listaDatosGrati()
        Try
            dtGrati = oPlanillaSueldosDetService.MostrarIngresoGrati(IdPlanilla, IdPersona).Tables(0)
            dgvGrati.DataSource = dtGrati
            SumarMontos(dgvGrati, txtTotalNSGrati, txtTotalUSGrati)

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE APORTACIONES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionGrati(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubroIng").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mbNuevoGrati_Click(sender As Object, e As EventArgs) Handles miNuevoGrati.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPlanillaSueldos_IngGrati
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.state_button = False
                frm.txtItem.Value = dgvGrati.RowCount() + 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtGrati = Nothing
                    listaDatosIngresos()
                    listaDatosGrati()
                    If frm.type_process = "insert" Then
                        RowPossesionGrati(dgvGrati, frm.IdRubro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO INGRESO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mbMostrarGrati_Click(sender As Object, e As EventArgs) Handles miMostrarGrati.Click, dgvGrati.DoubleClick
        Try
            If ValidaCodigoSeleccionadoIngGrati() Then
                Dim frm As New frmPlanillaSueldos_IngGrati
                frm.state_button = True
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.IdRubro = toNumber(dgvGrati.CurrentRow.Cells("IdRubroIng").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtGrati = Nothing
                    listaDatosIngresos()
                    listaDatosGrati()
                    If frm.type_process = "update" Then
                        RowPossesionGrati(dgvGrati, frm.IdRubro)
                    Else
                        MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesionGrati(dgvGrati, frm.IdRubro)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR INGRESO " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarGrati_Click(sender As Object, e As EventArgs) Handles miEliminarGrati.Click
        Try
            cmOpcionesGrati.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarIngresoGrati(toNumber(txtIdPlanilla.Text), IdPersona, toNumber(dgvGrati.CurrentRow.Cells("IdRubroIng").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtGrati = Nothing
                    listaDatosGrati()
                    listaDatosIngresos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR GRATIFICACION :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miRefrescarGrati_Click(sender As Object, e As EventArgs) Handles miActualizarGrati.Click
        listaDatosGrati()
    End Sub

    '=================================================================================================
    '=====================VACACIONES===========================
    Private Function ValidaCodigoSeleccionadoIngVaca() As Boolean
        Try
            If dgvVaca.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvVaca.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvVaca.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub listaDatosVaca()
        Try
            dtVaca = oPlanillaSueldosDetService.MostrarIngresoVaca(IdPlanilla, IdPersona).Tables(0)
            dgvVaca.DataSource = dtVaca
            SumarMontos(dgvVaca, txtTotalNSVaca, txtTotalUSVaca)

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE APORTACIONES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionVaca(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubroIng").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mbNuevoVava_Click(sender As Object, e As EventArgs) Handles miNuevoVaca.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPlanillaSueldos_IngVaca
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.state_button = False
                frm.txtItem.Value = dgvVaca.RowCount() + 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtVaca = Nothing
                    listaDatosIngresos()
                    listaDatosVaca()
                    If frm.type_process = "insert" Then
                        RowPossesionVaca(dgvVaca, frm.IdRubro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO INGRESO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mbMostrarVaca_Click(sender As Object, e As EventArgs) Handles miMostrarVaca.Click, dgvVaca.DoubleClick
        Try
            If ValidaCodigoSeleccionadoIngVaca() Then
                Dim frm As New frmPlanillaSueldos_IngVaca
                frm.state_button = True
                frm.IdPlanilla = toNumber(txtIdPlanilla.Text)
                frm.IdPersona = IdPersona
                frm.IdRubro = toNumber(dgvVaca.CurrentRow.Cells("IdRubroIng").Value)
                frm.IdTipo = toNumber(dgvVaca.CurrentRow.Cells("IdTipo").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtVaca = Nothing
                    listaDatosIngresos()
                    listaDatosVaca()
                    If frm.type_process = "update" Then
                        RowPossesionVaca(dgvVaca, frm.IdRubro)
                    Else
                        MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesionVaca(dgvVaca, frm.IdRubro)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR INGRESO " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarVaca_Click(sender As Object, e As EventArgs) Handles miEliminarVaca.Click
        Try
            cmOpcionesVaca.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarIngresoVaca(toNumber(txtIdPlanilla.Text), IdPersona, toNumber(dgvVaca.CurrentRow.Cells("IdRubroIng").Value), toNumber(dgvVaca.CurrentRow.Cells("IdTipo").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtVaca = Nothing
                    listaDatosVaca()
                    listaDatosIngresos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR VACACIONES :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miRefrescarVaca_Click(sender As Object, e As EventArgs) Handles miRefrescarVaca.Click
        listaDatosVaca()
    End Sub


End Class