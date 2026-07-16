Imports System.ServiceModel

Public Class frmComputadora

    '=========================== Servicios ===================================================
    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable

    Private dtDatos As New DataTable
    Private dtTipoComputadora As DataTable

    Private dtProcesadores As New DataTable
    Private dtPlacaMadre As New DataTable
    Private dtMemoriaRam As New DataTable
    Private dtTarjetaVideo As New DataTable
    Private dtDiscoDuro As New DataTable
    Private dtLectora As New DataTable
    Private dtCargador As New DataTable
    Private dtTeclado As New DataTable
    Private dtMouse As New DataTable
    Private dtMonitor As New DataTable
    Private dtSoftware As New DataTable

    Public IdComputadora As Integer
    Public IdHardware As Integer
    Public IdSoftware As Integer

    Public IdProcesador As Integer
    Public IdPlacaMadre As Integer
    Public IdMemRam As Integer
    Public IdTarjetaVideo As Integer
    Public IdDiscoDuro As Integer
    Public IdLectora As Integer
    Public IdCargador As Integer
    Public IdTeclado As Integer
    Public IdMouse As Integer
    Public IdMonitor As Integer

    Private Sub frmComputadora_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub

    Private Sub frmComputadora_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComputadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        LlenarCombos()

        If state_button Then                'Modificar
            Me.Size = New System.Drawing.Size(603, 724)
            ObtenerRegistro()
            desactivar()
            'ActivarSoftware()
            'txtFecha.TabStop = False
        Else                                'Nuevo
            Me.Size = New System.Drawing.Size(603, 200)
            cbVigente.Checked = True
            activar()
            txtComputadora.Focus()
            cmbTipoComputadora.SelectedIndex = 1
            'DesactivarComputadora
            'DesactivarSoftware
            'cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub activar()

        txtComputadora.ReadOnly = False
        txtComputadora.BackColor = System.Drawing.SystemColors.Window
        cmbTipoComputadora.ReadOnly = False
        cmbTipoComputadora.BackColor = System.Drawing.SystemColors.Window

        cbVigente.Enabled = True

        txtObservacionCom.ReadOnly = False
        txtObservacionCom.BackColor = System.Drawing.SystemColors.Window

        edicion = True
        enableOpciones()
    End Sub

    Private Sub desactivar()

        txtComputadora.ReadOnly = True
        txtComputadora.BackColor = System.Drawing.SystemColors.Control
        cmbTipoComputadora.ReadOnly = True
        cmbTipoComputadora.BackColor = System.Drawing.SystemColors.Control

        cbVigente.Enabled = False

        txtObservacionCom.ReadOnly = True
        txtObservacionCom.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()

    End Sub

    Private Sub enableOpciones()
        Try
            biEditarComputadora.Enabled = IIf(editable, Not edicion, False)
            biCerrar.Enabled = Not edicion
            biGuardarComputadora.Enabled = edicion
            biDeshacerComputadora.Enabled = edicion

            cmOpProcesador.Enabled = IIf(Not edicion, True, False)
            cmOpPlacaMadre.Enabled = IIf(Not edicion, True, False)
            cmOpMemoriaRam.Enabled = IIf(Not edicion, True, False)
            cmOpTarjetaVideo.Enabled = IIf(Not edicion, True, False)
            cmOpDiscoDuro.Enabled = IIf(Not edicion, True, False)
            cmOpLectora.Enabled = IIf(Not edicion, True, False)
            cmOpMonitor.Enabled = IIf(Not edicion, True, False)
            cmOpCargador.Enabled = IIf(Not edicion, True, False)
            cmOpTeclado.Enabled = IIf(Not edicion, True, False)
            cmOpMouse.Enabled = IIf(Not edicion, True, False)
            cmOpSoftware.Enabled = IIf(Not edicion, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message)
        End Try
    End Sub

    Private Sub LlenarCombos()

        Try
            '======================================= TIPO COMPUTADORA ================================================
            dtTipoComputadora = oComputadoraService.MostrarTipoComputadora().Tables(0)
            'dtTipoComputadora.Rows.InsertAt(getRowTodos(dtTipoComputadora), 0)
            cmbTipoComputadora.DataSource = dtTipoComputadora
            cmbTipoComputadora.DropDownList.DataMember = dtTipoComputadora.Columns("DesTipoComputadora").ToString
            cmbTipoComputadora.DropDownList.DisplayMember = dtTipoComputadora.Columns("DesTipoComputadora").ToString
            cmbTipoComputadora.DropDownList.ValueMember = dtTipoComputadora.Columns("IdTipoComputadora").ToString
            cmbTipoComputadora.DropDownList.Columns(0).DataMember = dtTipoComputadora.Columns("IdTipoComputadora").ToString
            cmbTipoComputadora.DropDownList.Columns(1).DataMember = dtTipoComputadora.Columns("DesTipoComputadora").ToString
            cmbTipoComputadora.SelectedIndex = 0
            dtTipoComputadora = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ComputadoraService.Computadora
            registro = oComputadoraService.ObtenerComputadora(IdComputadora)

            IdComputadora = registro.IdComputadora
            txtIdComputadora.Text = registro.IdComputadora
            txtComputadora.Text = registro.NomPc

            cmbTipoComputadora.Value = registro.TipoComputadora.IdTipoComputadora

            cbVigente.Checked = registro.Vigente

            txtObservacionCom.Text = registro.Observacion

            ObtenerListadoHardware()
            'IdHardware = registro.Hardware.IdHardware
            'ObtenerHardware()
            'ObtenerSoftware

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL REGISTRO" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================================================================BUSCADORES===================================================================================

    Private Sub ObtenerListadoHardware()

        ListarProcesadores()
        ListarPlacaMadre()
        ListarMemoriaram()
        ListarTarjetaVideo()
        ListarDiscoDuro()
        ListarLectora()
        ListarMonitor()
        ListarCargador()
        ListarMouse()
        ListarTeclado()
        ListarSoftware()

    End Sub

    '=============================================================================AGREGAR===================================================================================

    Private Sub btnAgregarProcesador1_Click(sender As Object, e As EventArgs) Handles btnAgregarProcesador1.Click, miNuevoProc.Click

        Try
            Dim frm As New frmProcesador
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarProcesadores()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAgregarPlacaMadre1_Click(sender As Object, e As EventArgs) Handles btnAgregarPlacaMadre1.Click, miNuevoPlaca.Click
        Try
            Dim frm As New frmPlacaMadre
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarPlacaMadre()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarMemoriaram1_Click(sender As Object, e As EventArgs) Handles btnAgregarMemoriaram1.Click, miNuevoMem.Click
        Try
            Dim frm As New frmMemoriaRam
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarMemoriaram()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTarjetaVideo1_Click(sender As Object, e As EventArgs) Handles btnAgregarTarjetaVideo1.Click, miNuevoTarj.Click
        Try
            Dim frm As New frmTarjetaVideo
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarTarjetaVideo()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarDiscoDuro1_Click(sender As Object, e As EventArgs) Handles btnAgregarDiscoDuro1.Click, miNuevoDisco.Click
        Try
            Dim frm As New frmDiscoDuro
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarDiscoDuro()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarLectora1_Click(sender As Object, e As EventArgs) Handles btnAgregarLectora1.Click, miNuevaLectora.Click
        Try
            Dim frm As New frmLectora
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarLectora()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarMonitor1_Click(sender As Object, e As EventArgs) Handles btnAgregarMonitor1.Click, miNuevoMonitor.Click
        Try
            Dim frm As New frmMonitor
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarMonitor()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarCargador1_Click(sender As Object, e As EventArgs) Handles btnAgregarCargador1.Click, miNuevoCargador.Click
        Try
            Dim frm As New frmCargador
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarCargador()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTeclado1_Click(sender As Object, e As EventArgs) Handles btnAgregarTeclado1.Click, miNuevoTeclado.Click
        Try
            Dim frm As New frmTeclado
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarTeclado()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarMouse1_Click(sender As Object, e As EventArgs) Handles btnAgregarMouse1.Click, miNuevoMouse.Click
        Try
            Dim frm As New frmMouse
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarMouse()
                'IdSoftware = frm.IdSoftware
                'txtSoftware.Text = frm.txtNomAplicacion.Text
                'AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarSoftware2_Click(sender As Object, e As EventArgs) Handles btnAgregarSoftware2.Click, miNuevoSoftware.Click
        Try
            Dim frm As New frmSoftware
            frm.state_button = False
            frm.IdComputadora = IdComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarSoftware()
                IdSoftware = frm.IdSoftware
                txtSoftware.Text = frm.txtNomAplicacion.Text
                AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el software : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarSoftware2_Click(sender As Object, e As EventArgs) Handles btnBuscarSoftware2.Click
        Try
            Dim frm As New frmBuscarSoftware
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtSoftware.Text = frm.descripcion
                    IdSoftware = frm.codigo
                    AgregarSoftware()
                Else
                    txtSoftware.Text = ""
                    IdSoftware = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub AgregarSoftware()

        Try
            Dim registro As New ComputadoraService.ComputadoraSoftware

            Dim computadora As New ComputadoraService.Computadora
            Dim registrosoftware As New ComputadoraService.Software

            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            registrosoftware.IdSoftware = IdSoftware
            registro.Software = registrosoftware

            registro.Observacion = "Observacion"

            computadora.IdComputadora = IdComputadora
            registro.Computadora = computadora

            InsertarSoftware(registro)

        Catch ex As Exception
            MsgBox("Error al guardar el software: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub InsertarSoftware(ByVal registro As ComputadoraService.ComputadoraSoftware)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.InsertarComputadoraSoftware(registro)
            type_process = "insert"
            If estado_process Then
                ListarSoftware()
                IdSoftware = 0
                txtSoftware.Text = ""
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================================================================FIN AGREGAR===================================================================================

    '=============================================================================LISTAR========================================================================================

    Private Sub ListarProcesadores()
        Try

            dtProcesadores = oComputadoraService.MostrarProcesador(IdComputadora).Tables(0)
            dgvDatosProcesador.DataSource = dtProcesadores

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR PROCESADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarPlacaMadre()
        Try

            dtPlacaMadre = oComputadoraService.MostrarPlacaMadre(IdComputadora).Tables(0)
            dgvDatosPlacaMadre.DataSource = dtPlacaMadre

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR PLACA MADRE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarMemoriaram()
        Try

            dtMemoriaRam = oComputadoraService.MostrarMemoria(IdComputadora).Tables(0)
            dgvDatosMemoriaRam.DataSource = dtMemoriaRam

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR MEMORIA RAM: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarTarjetaVideo()
        Try

            dtTarjetaVideo = oComputadoraService.MostrarTarjetaVideo(IdComputadora).Tables(0)
            dgvDatosTarjetaVideo.DataSource = dtTarjetaVideo

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR TARJETA VIDEO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarDiscoDuro()
        Try

            dtDiscoDuro = oComputadoraService.MostrarDiscoDuro(IdComputadora).Tables(0)
            dgvDatosDiscoDuro.DataSource = dtDiscoDuro

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DISCO DURO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarLectora()
        Try

            dtLectora = oComputadoraService.MostrarLectora(IdComputadora).Tables(0)
            dgvDatosLectora.DataSource = dtLectora

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LECTORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarMonitor()
        Try

            dtMonitor = oComputadoraService.MostrarMonitor(IdComputadora).Tables(0)
            dgvDatosMonitor.DataSource = dtMonitor

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR MONITOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarCargador()
        Try

            dtCargador = oComputadoraService.MostrarCargador(IdComputadora).Tables(0)
            dgvDatosCargador.DataSource = dtCargador

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CARGADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarTeclado()
        Try

            dtTeclado = oComputadoraService.MostrarTeclado(IdComputadora).Tables(0)
            dgvDatosTeclado.DataSource = dtTeclado

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR TECLADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarMouse()
        Try
            dtMouse = oComputadoraService.MostrarMouse(IdComputadora).Tables(0)
            dgvDatosMouse.DataSource = dtMouse

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR MOUSE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarSoftware()
        Try
            dtSoftware = oComputadoraService.MostrarComputadoraSoftware(IdComputadora).Tables(0)
            dgvDatosSoftware.DataSource = dtSoftware

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardarComputadora_Click(sender As Object, e As EventArgs) Handles biGuardarComputadora.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos de la computadora?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New ComputadoraService.Computadora
                Dim hardware As New ComputadoraService.Hardware
                Dim software As New ComputadoraService.Software
                Dim tipocomputadora As New ComputadoraService.TipoComputadora
                Dim empresa As New ComputadoraService.Empresa

                registro.IdComputadora = IdComputadora
                registro.NomPc = txtComputadora.Text
                tipocomputadora.IdTipoComputadora = cmbTipoComputadora.Value
                registro.TipoComputadora = tipocomputadora

                registro.Vigente = cbVigente.Checked

                registro.Observacion = txtObservacionCom.Text

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa

                If state_button Then        'Modificar
                    ModificarComputadora(registro)
                Else                              'Nuevo
                    InsertarComputadora(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA COMPUTADORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtComputadora.Text) = "" Then
                MsgBox("Debe ingresar la computadora", MsgBoxStyle.Information, "Información")
                txtProcesador.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub InsertarComputadora(ByVal registro As ComputadoraService.Computadora)
        Try
            Dim estado_process As Integer
            estado_process = oComputadoraService.InsertarComputadora(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdComputadora = estado_process
                MsgBox("Se guardó la computadora correctamente.", MsgBoxStyle.Information, "Información")
                'ActivarSoftware()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA COMPUTADORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarComputadora(ByVal registro As ComputadoraService.Computadora)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.ActualizarComputadora(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la computadora correctamente")
                desactivar()
                ObtenerRegistro()
                'actualizarDetalles()

            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA COMPUTADORA" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    '============================================================================= INICIO PROCESADORES ===================================================================================

    Private Function ValidaCodigoSeleccionadoProcesador() As Boolean
        Try
            If dgvDatosProcesador.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosProcesador.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosProcesador.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosProcesador_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosProcesador.DoubleClick
        If ValidaCodigoSeleccionadoProcesador() Then
            MostrarProcesador()
        End If
    End Sub

    Private Sub dgvDatosProcesador_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosProcesador.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosProcesador.RowCount > 0 Then
                e.Handled = True
                miEditProc_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditProc_Click(sender As Object, e As EventArgs) Handles miEditProc.Click
        If ValidaCodigoSeleccionadoProcesador() Then
            MostrarProcesador()
        End If
    End Sub

    Private Sub MostrarProcesador()
        Try
            Dim frm As New frmProcesador
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdProcesador = dgvDatosProcesador.CurrentRow.Cells("IdProcesador").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarProcesadores()
                If frm.type_process = "update" Then
                    RowPossesionProcesador(dgvDatosProcesador, frm.IdProcesador)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionProcesador(dgvDatosProcesador, frm.IdProcesador)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL PROCESADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionProcesador(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdProcesador").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miElimProc_Click(sender As Object, e As EventArgs) Handles miElimProc.Click
        If ValidaCodigoSeleccionadoProcesador() Then
            EliminarProcesador()
        End If
    End Sub

    Private Sub EliminarProcesador()
        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarProcesador(dgvDatosProcesador.CurrentRow.Cells("IdProcesador").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarProcesadores()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL PROCESADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActProc_Click(sender As Object, e As EventArgs) Handles miActProc.Click
        Try
            Dim codigo As String = ""
            If dgvDatosProcesador.RowCount > 0 Then
                If IsDBNull(dgvDatosProcesador.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosProcesador.CurrentRow.Cells("IdProcesador").Text
                End If
            End If
            dtDatos = Nothing
            ListarProcesadores()
            If dgvDatosProcesador.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionProcesador(dgvDatosProcesador, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============================================================================= FIN PROCESADORES ========================================================================================

    '============================================================================= INICIO PLACA MADRE ======================================================================================

    Private Function ValidaCodigoSeleccionadoPlacaMadre() As Boolean
        Try
            If dgvDatosPlacaMadre.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosPlacaMadre.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosPlacaMadre.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosPlacaMadre_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosPlacaMadre.DoubleClick
        If ValidaCodigoSeleccionadoPlacaMadre() Then
            MostrarPlacaMadre()
        End If
    End Sub

    Private Sub dgvDatosPlacaMadre_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosPlacaMadre.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosPlacaMadre.RowCount > 0 Then
                e.Handled = True
                miEditarPlaca_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarPlaca_Click(sender As Object, e As EventArgs) Handles miEditarPlaca.Click
        If ValidaCodigoSeleccionadoPlacaMadre() Then
            MostrarPlacaMadre()
        End If
    End Sub

    Private Sub MostrarPlacaMadre()

        Try
            Dim frm As New frmPlacaMadre
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdPlacaMadre = dgvDatosPlacaMadre.CurrentRow.Cells("IdPlaca").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarPlacaMadre()
                If frm.type_process = "update" Then
                    RowPossesionPlacaMadre(dgvDatosPlacaMadre, frm.IdPlacaMadre)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionPlacaMadre(dgvDatosPlacaMadre, frm.IdPlacaMadre)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PLACA MADRE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionPlacaMadre(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPlaca").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarPlaca_Click(sender As Object, e As EventArgs) Handles miEliminarPlaca.Click
        If ValidaCodigoSeleccionadoPlacaMadre() Then
            EliminarPlacaMadre()
        End If
    End Sub

    Private Sub EliminarPlacaMadre()

        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarPlacaMadre(dgvDatosPlacaMadre.CurrentRow.Cells("IdPlaca").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarPlacaMadre()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA PLACA MADRE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarPlaca_Click(sender As Object, e As EventArgs) Handles miActualizarPlaca.Click
        Try
            Dim codigo As String = ""
            If dgvDatosPlacaMadre.RowCount > 0 Then
                If IsDBNull(dgvDatosPlacaMadre.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosPlacaMadre.CurrentRow.Cells("IdPlaca").Text
                End If
            End If
            dtDatos = Nothing
            ListarPlacaMadre()
            If dgvDatosPlacaMadre.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionPlacaMadre(dgvDatosPlacaMadre, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============================================================================= FIN PLACA MADRE ======================================================================================

    '============================================================================= INICIO MEMORIA RAM ===================================================================================

    Private Function ValidaCodigoSeleccionadoMemoriaRam() As Boolean
        Try
            If dgvDatosMemoriaRam.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosMemoriaRam.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosMemoriaRam.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosMemoriaRam_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosMemoriaRam.DoubleClick
        If ValidaCodigoSeleccionadoMemoriaRam() Then
            MostrarMemoriaRam()
        End If
    End Sub

    Private Sub dgvDatosMemoriaRam_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosMemoriaRam.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosMemoriaRam.RowCount > 0 Then
                e.Handled = True
                miEditarMem_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarMem_Click(sender As Object, e As EventArgs) Handles miEditarMem.Click
        If ValidaCodigoSeleccionadoMemoriaRam() Then
            MostrarMemoriaRam()
        End If
    End Sub

    Private Sub MostrarMemoriaRam()
        Try
            Dim frm As New frmMemoriaRam
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdMemRam = dgvDatosMemoriaRam.CurrentRow.Cells("IdMemRam").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarMemoriaram()
                If frm.type_process = "update" Then
                    RowPossesionMemoriaRam(dgvDatosMemoriaRam, frm.IdMemRam)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionMemoriaRam(dgvDatosMemoriaRam, frm.IdMemRam)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA MEMORIA RAM: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionMemoriaRam(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdMemRam").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarMem_Click(sender As Object, e As EventArgs) Handles miEliminarMem.Click
        If ValidaCodigoSeleccionadoMemoriaRam() Then
            EliminarMemoriaRam()
        End If
    End Sub

    Private Sub EliminarMemoriaRam()

        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarMemoria(dgvDatosMemoriaRam.CurrentRow.Cells("IdMemRam").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarMemoriaram()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA MEMORIA RAM: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarMem_Click(sender As Object, e As EventArgs) Handles miActualizarMem.Click
        Try
            Dim codigo As String = ""
            If dgvDatosMemoriaRam.RowCount > 0 Then
                If IsDBNull(dgvDatosMemoriaRam.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosMemoriaRam.CurrentRow.Cells("IdMemRam").Text
                End If
            End If
            dtDatos = Nothing
            ListarMemoriaram()
            If dgvDatosMemoriaRam.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionMemoriaRam(dgvDatosMemoriaRam, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============================================================================= FIN MEMORIA RAM  =======================================================================================

    '============================================================================= INICIO TARJETA VIDEO ===================================================================================

    Private Function ValidaCodigoSeleccionadoTarjetaVideo() As Boolean
        Try
            If dgvDatosTarjetaVideo.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosTarjetaVideo.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosTarjetaVideo.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosTarjetaVideo_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosTarjetaVideo.DoubleClick
        If ValidaCodigoSeleccionadoTarjetaVideo() Then
            MostrarTarjetaVideo()
        End If
    End Sub

    Private Sub dgvDatosTarjetaVideo_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosTarjetaVideo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosTarjetaVideo.RowCount > 0 Then
                e.Handled = True
                miEditarTarj_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarTarj_Click(sender As Object, e As EventArgs) Handles miEditarTarj.Click
        If ValidaCodigoSeleccionadoTarjetaVideo() Then
            MostrarTarjetaVideo()
        End If
    End Sub

    Private Sub MostrarTarjetaVideo()

        Try
            Dim frm As New frmTarjetaVideo
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdTarjetaVideo = dgvDatosTarjetaVideo.CurrentRow.Cells("IdTarjetaVideo").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarPlacaMadre()
                If frm.type_process = "update" Then
                    RowPossesionTarjetaVideo(dgvDatosTarjetaVideo, frm.IdTarjetaVideo)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionTarjetaVideo(dgvDatosTarjetaVideo, frm.IdTarjetaVideo)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA TARJETA DE VIDEO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionTarjetaVideo(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdTarjetaVideo").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarTarj_Click(sender As Object, e As EventArgs) Handles miEliminarTarj.Click
        If ValidaCodigoSeleccionadoTarjetaVideo() Then
            EliminarTarjetaVideo()
        End If
    End Sub

    Private Sub EliminarTarjetaVideo()

        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarTarjetaVideo(dgvDatosTarjetaVideo.CurrentRow.Cells("IdTarjetaVideo").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarTarjetaVideo()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA TARJETA DE VIDEO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarTarj_Click(sender As Object, e As EventArgs) Handles miActualizarTarj.Click
        Try
            Dim codigo As String = ""
            If dgvDatosTarjetaVideo.RowCount > 0 Then
                If IsDBNull(dgvDatosTarjetaVideo.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosTarjetaVideo.CurrentRow.Cells("IdTarjetaVideo").Text
                End If
            End If
            dtDatos = Nothing
            ListarTarjetaVideo()
            If dgvDatosTarjetaVideo.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionTarjetaVideo(dgvDatosTarjetaVideo, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    '============================================================================= FIN TARJETA VIDEO ===================================================================================

    '============================================================================= INICIO DISCO DURO ===================================================================================

    Private Function ValidaCodigoSeleccionadoDiscoDuro() As Boolean
        Try
            If dgvDatosDiscoDuro.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosDiscoDuro.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosDiscoDuro.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub dgvDatosDiscoDuro_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosDiscoDuro.DoubleClick
        If ValidaCodigoSeleccionadoDiscoDuro() Then
            MostrarDiscoDuro()
        End If
    End Sub

    Private Sub dgvDatosDiscoDuro_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosDiscoDuro.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosDiscoDuro.RowCount > 0 Then
                e.Handled = True
                miEditarDisco_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarDisco_Click(sender As Object, e As EventArgs) Handles miEditarDisco.Click

        If ValidaCodigoSeleccionadoDiscoDuro() Then
            MostrarDiscoDuro()
        End If

    End Sub

    Private Sub MostrarDiscoDuro()

        Try
            Dim frm As New frmDiscoDuro
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdDiscoDuro = dgvDatosDiscoDuro.CurrentRow.Cells("IdDiscoDuro").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarDiscoDuro()
                If frm.type_process = "update" Then
                    RowPossesionDiscoDuro(dgvDatosDiscoDuro, frm.IdDiscoDuro)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionDiscoDuro(dgvDatosDiscoDuro, frm.IdDiscoDuro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DISCO DURO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionDiscoDuro(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdDiscoDuro").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarDisco_Click(sender As Object, e As EventArgs) Handles miEliminarDisco.Click
        If ValidaCodigoSeleccionadoDiscoDuro() Then
            EliminarDiscoDuro()
        End If
    End Sub

    Private Sub EliminarDiscoDuro()

        Try
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarDiscoDuro(dgvDatosDiscoDuro.CurrentRow.Cells("IdDiscoDuro").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarDiscoDuro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL DISCO DURO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarDisco_Click(sender As Object, e As EventArgs) Handles miActualizarDisco.Click
        Try
            Dim codigo As String = ""
            If dgvDatosDiscoDuro.RowCount > 0 Then
                If IsDBNull(dgvDatosDiscoDuro.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosDiscoDuro.CurrentRow.Cells("IdDiscoDuro").Text
                End If
            End If
            dtDatos = Nothing
            ListarDiscoDuro()
            If dgvDatosDiscoDuro.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionDiscoDuro(dgvDatosDiscoDuro, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============================================================================= FIN DISCO DURO ===================================================================================


    '============================================================================= INICIO LECTORA ===================================================================================

    Private Function ValidaCodigoSeleccionadoLectora() As Boolean
        Try
            If dgvDatosLectora.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosLectora.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosLectora.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosLectora_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosLectora.DoubleClick
        If ValidaCodigoSeleccionadoLectora() Then
            MostrarLectora()
        End If
    End Sub

    Private Sub dgvDatosLectora_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosLectora.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosLectora.RowCount > 0 Then
                e.Handled = True
                miEditarLectora_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarLectora_Click(sender As Object, e As EventArgs) Handles miEditarLectora.Click
        If ValidaCodigoSeleccionadoLectora() Then
            MostrarLectora()
        End If
    End Sub

    Private Sub MostrarLectora()

        Try
            Dim frm As New frmLectora
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdLectora = dgvDatosLectora.CurrentRow.Cells("IdLectora").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarLectora()
                If frm.type_process = "update" Then
                    RowPossesionLectora(dgvDatosLectora, frm.IdLectora)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionLectora(dgvDatosLectora, frm.IdLectora)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA LECTORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionLectora(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdLectora").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarLectora_Click(sender As Object, e As EventArgs) Handles miEliminarLectora.Click
        If ValidaCodigoSeleccionadoLectora() Then
            EliminarLectora()
        End If
    End Sub

    Private Sub EliminarLectora()
        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarLectora(dgvDatosLectora.CurrentRow.Cells("IdLectora").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarLectora()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA LECTORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarLectora_Click(sender As Object, e As EventArgs) Handles miActualizarLectora.Click
        Try
            Dim codigo As String = ""
            If dgvDatosLectora.RowCount > 0 Then
                If IsDBNull(dgvDatosLectora.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosLectora.CurrentRow.Cells("IdLectora").Text
                End If
            End If
            dtDatos = Nothing
            ListarLectora()
            If dgvDatosLectora.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionLectora(dgvDatosLectora, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============================================================================= FIN LECTORA===================================================================================

    '============================================================================= INICIO MONITOR ===================================================================================

    Private Function ValidaCodigoSeleccionadoMonitor() As Boolean
        Try
            If dgvDatosMonitor.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosMonitor.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosMonitor.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosMonitor_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosMonitor.DoubleClick
        If ValidaCodigoSeleccionadoMonitor() Then
            MostrarMonitor()
        End If
    End Sub

    Private Sub dgvDatosMonitor_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosMonitor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosMonitor.RowCount > 0 Then
                e.Handled = True
                miEditarMonitor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarMonitor_Click(sender As Object, e As EventArgs) Handles miEditarMonitor.Click
        If ValidaCodigoSeleccionadoMonitor() Then
            MostrarMonitor()
        End If
    End Sub

    Private Sub MostrarMonitor()

        Try
            Dim frm As New frmMonitor
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdMonitor = dgvDatosMonitor.CurrentRow.Cells("IdMonitor").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarMonitor()
                If frm.type_process = "update" Then
                    RowPossesionMonitor(dgvDatosMonitor, frm.IdMonitor)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionMonitor(dgvDatosMonitor, frm.IdMonitor)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL MONITOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionMonitor(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdMonitor").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarMonitor_Click(sender As Object, e As EventArgs) Handles miEliminarMonitor.Click
        If ValidaCodigoSeleccionadoMonitor() Then
            EliminarMonitor()
        End If
    End Sub

    Private Sub EliminarMonitor()
        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarMonitor(dgvDatosMonitor.CurrentRow.Cells("IdMonitor").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarMonitor()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL MONITOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarMonitor_Click(sender As Object, e As EventArgs) Handles miActualizarMonitor.Click
        Try
            Dim codigo As String = ""
            If dgvDatosMonitor.RowCount > 0 Then
                If IsDBNull(dgvDatosMonitor.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosMonitor.CurrentRow.Cells("IdMonitor").Text
                End If
            End If
            dtDatos = Nothing
            ListarMonitor()
            If dgvDatosMonitor.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionMonitor(dgvDatosMonitor, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    '============================================================================= FIN MONITOR ===================================================================================

    '============================================================================= INICIO CARGADOR ===================================================================================

    Private Function ValidaCodigoSeleccionadoCargador() As Boolean
        Try
            If dgvDatosCargador.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosCargador.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosCargador.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosCargador_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosCargador.DoubleClick
        If ValidaCodigoSeleccionadoCargador() Then
            MostrarCargador()
        End If
    End Sub

    Private Sub dgvDatosCargador_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosCargador.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosCargador.RowCount > 0 Then
                e.Handled = True
                miEditarCargador_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarCargador_Click(sender As Object, e As EventArgs) Handles miEditarCargador.Click
        If ValidaCodigoSeleccionadoCargador() Then
            MostrarCargador()
        End If
    End Sub

    Private Sub MostrarCargador()

        Try
            Dim frm As New frmCargador
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdCargador = dgvDatosCargador.CurrentRow.Cells("IdCargador").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarCargador()
                If frm.type_process = "update" Then
                    RowPossesionCargador(dgvDatosCargador, frm.IdCargador)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionCargador(dgvDatosCargador, frm.IdCargador)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL CARGADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionCargador(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdCargador").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarCargador_Click(sender As Object, e As EventArgs) Handles miEliminarCargador.Click
        If ValidaCodigoSeleccionadoCargador() Then
            EliminarCargador()
        End If
    End Sub

    Private Sub EliminarCargador()

        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarCargador(dgvDatosCargador.CurrentRow.Cells("IdCargador").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarCargador()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL CARGADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarCargador_Click(sender As Object, e As EventArgs) Handles miActualizarCargador.Click
        Try
            Dim codigo As String = ""
            If dgvDatosCargador.RowCount > 0 Then
                If IsDBNull(dgvDatosCargador.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosCargador.CurrentRow.Cells("IdCargador").Text
                End If
            End If
            dtDatos = Nothing
            ListarCargador()
            If dgvDatosCargador.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionCargador(dgvDatosCargador, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    '============================================================================= FIN MONITOR ===================================================================================

    '============================================================================= INICIO TECLADO ===================================================================================

    Private Function ValidaCodigoSeleccionadoTeclado() As Boolean
        Try
            If dgvDatosTeclado.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosTeclado.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosTeclado.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub dgvDatosTeclado_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosTeclado.DoubleClick
        If ValidaCodigoSeleccionadoTeclado() Then
            MostrarTeclado()
        End If
    End Sub

    Private Sub dgvDatosTeclado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosTeclado.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosTeclado.RowCount > 0 Then
                e.Handled = True
                miEditarTeclado_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarTeclado_Click(sender As Object, e As EventArgs) Handles miEditarTeclado.Click
        If ValidaCodigoSeleccionadoTeclado() Then
            MostrarTeclado()
        End If
    End Sub

    Private Sub MostrarTeclado()

        Try
            Dim frm As New frmTeclado
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdTeclado = dgvDatosTeclado.CurrentRow.Cells("IdTeclado").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarTeclado()
                If frm.type_process = "update" Then
                    RowPossesionTeclado(dgvDatosTeclado, frm.IdTeclado)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionTeclado(dgvDatosTeclado, frm.IdTeclado)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL TECLADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionTeclado(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdTeclado").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarTeclado_Click(sender As Object, e As EventArgs) Handles miEliminarTeclado.Click
        If ValidaCodigoSeleccionadoTeclado() Then
            EliminarTeclado()
        End If
    End Sub

    Private Sub EliminarTeclado()
        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarTeclado(dgvDatosTeclado.CurrentRow.Cells("IdTeclado").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarTeclado()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL TECLADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub miActualizarTeclado_Click(sender As Object, e As EventArgs) Handles miActualizarTeclado.Click
        Try
            Dim codigo As String = ""
            If dgvDatosTeclado.RowCount > 0 Then
                If IsDBNull(dgvDatosTeclado.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosTeclado.CurrentRow.Cells("IdTeclado").Text
                End If
            End If
            dtDatos = Nothing
            ListarTeclado()
            If dgvDatosTeclado.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionTeclado(dgvDatosTeclado, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    '============================================================================= FIN TECLADO ===================================================================================

    '============================================================================= INICIO MOUSE ===================================================================================

    Private Function ValidaCodigoSeleccionadoMouse() As Boolean
        Try
            If dgvDatosMouse.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosMouse.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosMouse.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosMouse_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosMouse.DoubleClick
        If ValidaCodigoSeleccionadoMouse() Then
            MostrarMouse()
        End If
    End Sub

    Private Sub dgvDatosMouse_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosMouse.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosMouse.RowCount > 0 Then
                e.Handled = True
                miEditarMouse_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarMouse_Click(sender As Object, e As EventArgs) Handles miEditarMouse.Click
        If ValidaCodigoSeleccionadoMouse() Then
            MostrarMouse()
        End If
    End Sub

    Private Sub MostrarMouse()

        Try
            Dim frm As New frmMouse
            frm.state_button = True
            frm.IdComputadora = IdComputadora
            frm.IdMouse = dgvDatosMouse.CurrentRow.Cells("IdMouse").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarMouse()
                If frm.type_process = "update" Then
                    RowPossesionMouse(dgvDatosMouse, frm.IdMouse)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionMouse(dgvDatosMouse, frm.IdMouse)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL MOUSE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionMouse(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdMouse").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarMouse_Click(sender As Object, e As EventArgs) Handles miEliminarMouse.Click
        If ValidaCodigoSeleccionadoMouse() Then
            EliminarMouse()
        End If
    End Sub

    Private Sub EliminarMouse()

        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarMouse(dgvDatosMouse.CurrentRow.Cells("IdMouse").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarMouse()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL MOUSE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarMouse_Click(sender As Object, e As EventArgs) Handles miActualizarMouse.Click
        Try
            Dim codigo As String = ""
            If dgvDatosMouse.RowCount > 0 Then
                If IsDBNull(dgvDatosMouse.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosMouse.CurrentRow.Cells("IdMouse").Text
                End If
            End If
            dtDatos = Nothing
            ListarMouse()
            If dgvDatosMouse.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionMouse(dgvDatosMouse, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============================================================================= FIN MOUSE ===================================================================================

    '============================================================================= INICIO SOFTWARE ===================================================================================

    Private Function ValidaCodigoSeleccionadoSoftware() As Boolean
        Try
            If dgvDatosSoftware.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosSoftware.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosSoftware.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatosSoftware_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatosSoftware.DoubleClick
        If ValidaCodigoSeleccionadoPlacaMadre() Then
            MostrarSoftware()
        End If
    End Sub

    Private Sub dgvDatosSoftware_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatosSoftware.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosPlacaMadre.RowCount > 0 Then
                e.Handled = True
                miEditarPlaca_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub miEditarSoftware_Click(sender As Object, e As EventArgs) Handles miEditarSoftware.Click
        If ValidaCodigoSeleccionadoPlacaMadre() Then
            MostrarSoftware()
        End If
    End Sub


    Private Sub MostrarSoftware()

        Try
            Dim frm As New frmSoftware
            frm.state_button = True
            frm.IdSoftware = dgvDatosSoftware.CurrentRow.Cells("IdSoftware").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarSoftware()
                If frm.type_process = "update" Then
                    RowPossesionSoftware(dgvDatosSoftware, frm.IdSoftware)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionSoftware(dgvDatosSoftware, frm.IdSoftware)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesionSoftware(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdSoftware").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminarSoftware_Click(sender As Object, e As EventArgs) Handles miEliminarSoftware.Click
        If ValidaCodigoSeleccionadoSoftware() Then
            EliminarSoftware()
        End If
    End Sub

    Private Sub EliminarSoftware()

        Try
            'cmOpProcesador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarComputadoraSoftware(dgvDatosSoftware.CurrentRow.Cells("IdComputadora").Value, dgvDatosSoftware.CurrentRow.Cells("IdSoftware").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'estado_process = oComputadoraService.BorrarSoftware(dgvDatosSoftware.CurrentRow.Cells("IdSoftware").Value)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarSoftware()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizarSoftware_Click(sender As Object, e As EventArgs) Handles miActualizarSoftware.Click
        Try
            Dim codigo As String = ""
            If dgvDatosSoftware.RowCount > 0 Then
                If IsDBNull(dgvDatosSoftware.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosSoftware.CurrentRow.Cells("IdSoftware").Text
                End If
            End If
            dtDatos = Nothing
            ListarSoftware()
            If dgvDatosSoftware.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionSoftware(dgvDatosSoftware, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biEditarComputadora_Click(sender As Object, e As EventArgs) Handles biEditarComputadora.Click
        activar()
    End Sub

    Private Sub biDeshacerComputadora_Click(sender As Object, e As EventArgs) Handles biDeshacerComputadora.Click
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

    '============================================================================= FIN SOFTWARE ===================================================================================

End Class