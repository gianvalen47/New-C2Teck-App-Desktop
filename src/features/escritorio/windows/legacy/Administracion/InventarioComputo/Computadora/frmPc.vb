Imports System.ServiceModel

Public Class frmPc

    '=========================== Servicios ===================================================
    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Private dtDatos As New DataTable
    Private dtTipoComputadora As DataTable

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
    Public IdMonitor As Integer


    Private Sub frmPc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub

    Private Sub frmPc_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        LlenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            ActivarSoftware()
            'txtFecha.TabStop = False

        Else                                      'Nuevo            
            activar()
            DesactivarComputadora
            DesactivarSoftware
            'cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub DesactivarComputadora()

        biGuardar.Enabled = False
        biDeshacer.Enabled = False
        biCerrar.Enabled = True

        txtIdComputadora.Enabled = False
        txtComputadora.Enabled = False
        cmbTipoComputadora.Enabled = False
        cbVigente.Enabled = False


    End Sub

    Private Sub DesactivarSoftware()

        tpSoftware.Enabled = False

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

    Private Sub desactivar()
        'txtNumLinea.ReadOnly = True
        'txtNumLinea.BackColor = System.Drawing.SystemColors.Control

        'btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        'txtNumLinea.ReadOnly = False
        'txtNumLinea.BackColor = System.Drawing.SystemColors.Window

        'btnGuardar.Enabled = True
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ComputadoraService.Computadora
            registro = oComputadoraService.ObtenerComputadora(IdComputadora)

            IdComputadora = registro.IdComputadora
            txtIdComputadora.Text = registro.IdComputadora
            txtComputadora.Text = registro.NomPc

            'IdHardware = registro.Hardware.IdHardware

            ObtenerHardware()


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL REGISTRO" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerHardware()
        Try
            Dim registro As ComputadoraService.Hardware
            registro = oComputadoraService.ObtenerHardware(IdHardware)

            IdProcesador = registro.Procesador.IdProcesador
            txtProcesador.Text = registro.Procesador.DesProcesador
            IdPlacaMadre = registro.PlacaMadre.IdPlaca
            txtPlacaMadre.Text = registro.PlacaMadre.DesPlaca
            IdMemRam = registro.MemoriaRAM.IdMemRam
            txtMemoriaRam.Text = registro.MemoriaRAM.DesMemRam
            IdTarjetaVideo = registro.TarjetaVideo.IdTarjetaVideo
            txtTarjetaVideo.Text = registro.TarjetaVideo.DesTarjetaVideo
            IdDiscoDuro = registro.DiscoDuro.IdDiscoDuro
            txtDiscoDuro.Text = registro.DiscoDuro.DesDiscoDuro
            IdLectora = registro.Lectora.IdLectora
            txtLectora.Text = registro.Lectora.DesLectora
            IdCargador = registro.Cargador.IdCargador
            txtCargador.Text = registro.Cargador.DesCargador
            IdMonitor = registro.Monitor.IdMonitor
            txtMonitor.Text = registro.Monitor.DesMonitor

            txtTeclado.Text = registro.Teclado
            txtMouse.Text = registro.Mouse
            If Not (registro.FecIniUso.ToString = "") Then
                txtFecIniUso.Value = CDate(registro.FecIniUso)
                txtFecIniUso.Text = registro.FecIniUso.ToString
            End If
            If Not (registro.FecFinUso.ToString = "") Then
                txtFecFinUso.Value = CDate(registro.FecIniUso)
                txtFecFinUso.Text = registro.FecIniUso.ToString
            End If
            'txtFecIniUso.Text = registro.FecIniUso
            'txtFecFinUso.Text = registro.FecFinUso
            txtMotivoFinUso.Text = registro.MotivoFinUso

            txtNotaHardware.Text = registro.NotaHardware

            listarSoftwares()

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL HARDWARE" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProcesador_Click(sender As Object, e As EventArgs) Handles btnBuscarProcesador.Click
        Try
            Dim frm As New frmBuscarProcesador
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtProcesador.Text = frm.descripcion
                    IdProcesador = frm.codigo
                Else
                    txtProcesador.Text = ""
                    IdProcesador = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPlacaMadre_Click(sender As Object, e As EventArgs) Handles btnBuscarPlacaMadre.Click
        Try
            Dim frm As New frmBuscarPlacaMadre
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtPlacaMadre.Text = frm.descripcion
                    IdPlacaMadre = frm.codigo
                Else
                    txtPlacaMadre.Text = ""
                    IdPlacaMadre = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarMemoriaRam_Click(sender As Object, e As EventArgs) Handles btnBuscarMemoriaRam.Click
        Try
            Dim frm As New frmBuscarMemoriaRam
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtMemoriaRam.Text = frm.descripcion
                    IdMemRam = frm.codigo
                Else
                    txtMemoriaRam.Text = ""
                    IdMemRam = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarTarjetaVideo_Click(sender As Object, e As EventArgs) Handles btnBuscarTarjetaVideo.Click
        Try
            Dim frm As New frmBuscarTarjetaVideo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtTarjetaVideo.Text = frm.descripcion
                    IdTarjetaVideo = frm.codigo
                Else
                    txtTarjetaVideo.Text = ""
                    IdTarjetaVideo = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarDiscoDuro_Click(sender As Object, e As EventArgs) Handles btnBuscarDiscoDuro.Click
        Try
            Dim frm As New frmBuscarDiscoDuro
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtDiscoDuro.Text = frm.descripcion
                    IdDiscoDuro = frm.codigo
                Else
                    txtDiscoDuro.Text = ""
                    IdDiscoDuro = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarLectora_Click(sender As Object, e As EventArgs) Handles btnBuscarLectora.Click
        Try
            Dim frm As New frmBuscarLectora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtLectora.Text = frm.descripcion
                    IdLectora = frm.codigo
                Else
                    txtLectora.Text = ""
                    IdLectora = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCargador_Click(sender As Object, e As EventArgs) Handles btnBuscarCargador.Click
        Try
            Dim frm As New frmBuscarCargador
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtCargador.Text = frm.descripcion
                    IdCargador = frm.codigo
                Else
                    txtCargador.Text = ""
                    IdCargador = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarMonitor_Click(sender As Object, e As EventArgs) Handles btnBuscarMonitor.Click
        Try
            Dim frm As New frmBuscarMonitor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtMonitor.Text = frm.descripcion
                    IdMonitor = frm.codigo
                Else
                    txtMonitor.Text = ""
                    IdMonitor = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarProcesador_Click(sender As Object, e As EventArgs) Handles btnAgregarProcesador.Click
        Try
            Dim frm As New frmProcesador
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProcesador = frm.IdProcesador
                txtProcesador.Text = frm.txtDesProcesador.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el procesador : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarPlacaMadre_Click(sender As Object, e As EventArgs) Handles frmAgregarPlacaMadre.Click
        Try
            Dim frm As New frmPlacaMadre
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdPlacaMadre = frm.IdPlacaMadre
                txtPlacaMadre.Text = frm.txtDesPlacaMadre.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar la placa madre : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarMemRam_Click(sender As Object, e As EventArgs) Handles frmAgregarMemRam.Click
        Try
            Dim frm As New frmMemoriaRam
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdMemRam = frm.IdMemRam
                txtMemoriaRam.Text = frm.txtDesMemRam.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar la memoria ram : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarTarjetaVideo_Click(sender As Object, e As EventArgs) Handles frmAgregarTarjetaVideo.Click
        Try
            Dim frm As New frmTarjetaVideo
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdTarjetaVideo = frm.IdTarjetaVideo
                txtTarjetaVideo.Text = frm.txtDesTarjetaVideo.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar la tarjeta de video : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarDiscoDuro_Click(sender As Object, e As EventArgs) Handles frmAgregarDiscoDuro.Click
        Try
            Dim frm As New frmDiscoDuro
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdDiscoDuro = frm.IdDiscoDuro
                txtDiscoDuro.Text = frm.txtDesDiscoDuro.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el disco duro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarLectora_Click(sender As Object, e As EventArgs) Handles frmAgregarLectora.Click
        Try
            Dim frm As New frmLectora
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdLectora = frm.IdLectora
                txtLectora.Text = frm.txtDesLectora.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar la lectora : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarCargador_Click(sender As Object, e As EventArgs) Handles frmAgregarCargador.Click
        Try
            Dim frm As New frmCargador
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdCargador = frm.IdCargador
                txtCargador.Text = frm.txtDesCargador.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el cargador : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAgregarMonitor_Click(sender As Object, e As EventArgs) Handles frmAgregarMonitor.Click
        Try
            Dim frm As New frmMonitor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdMonitor = frm.IdMonitor
                txtMonitor.Text = frm.txtDesMonitor.Text
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el monitor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGrabaHardware_Click(sender As Object, e As EventArgs) Handles biGrabaHardware.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos de Hardware?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCamposHardware() Then
                Dim registro As New ComputadoraService.Hardware
                Dim procesador As New ComputadoraService.Procesador
                Dim placamadre As New ComputadoraService.PlacaMadre
                Dim memoriaram As New ComputadoraService.MemoriaRAM
                Dim tarjetavideo As New ComputadoraService.TarjetaVideo
                Dim discoduro As New ComputadoraService.DiscoDuro
                Dim lectora As New ComputadoraService.Lectora
                Dim cargador As New ComputadoraService.Cargador
                Dim monitor As New ComputadoraService.Monitor
                Dim tipodispositivo As New ComputadoraService.TipoDispositivo

                registro.IdHardware = IdHardware

                procesador.IdProcesador = IdProcesador
                registro.Procesador = procesador

                placamadre.IdPlaca = IdPlacaMadre
                registro.PlacaMadre = placamadre

                memoriaram.IdMemRam = IdMemRam
                registro.MemoriaRAM = memoriaram

                tarjetavideo.IdTarjetaVideo = IdTarjetaVideo
                registro.TarjetaVideo = tarjetavideo

                discoduro.IdDiscoDuro = IdDiscoDuro
                registro.DiscoDuro = discoduro

                lectora.IdLectora = IdLectora
                registro.Lectora = lectora

                cargador.IdCargador = IdCargador
                registro.Cargador = cargador

                monitor.IdMonitor = IdMonitor
                registro.Monitor = monitor

                registro.Teclado = txtTeclado.Text
                registro.Mouse = txtMouse.Text
                registro.FecIniUso = IIf(txtFecIniUso.Text = "", Nothing, txtFecIniUso.Value)
                registro.FecFinUso = IIf(txtFecFinUso.Text = "", Nothing, txtFecFinUso.Value)

                registro.MotivoFinUso = txtMotivoFinUso.Text

                registro.Vigente = cbVigenteH.Checked
                registro.NotaHardware = txtNotaHardware.Text
                tipodispositivo.IdTipoDispositivo = 1 'Entrada o Salida
                registro.TipoDispositivo = tipodispositivo

                registro.Vigente = cbVigente.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL CARGADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub Insertar(ByVal registro As ComputadoraService.Hardware)
        Try
            Dim estado_process As Integer
            estado_process = oComputadoraService.InsertarHardware(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdHardware = estado_process
                MsgBox("Se guardó el hardware correctamente.", MsgBoxStyle.Information, "Información")
                ActivarComputadora
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL HARDWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ComputadoraService.Hardware)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.ActualizarHardware(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                MsgBox("Se guardó el hardware correctamente.", MsgBoxStyle.Information, "Información")
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL HARDWARE" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Activarcomputadora()

        biGuardar.Enabled = True
        biDeshacer.Enabled = True
        biCerrar.Enabled = True

        txtIdComputadora.Enabled = True
        txtComputadora.Enabled = True
        cmbTipoComputadora.Enabled = True
        cbVigente.Enabled = True

    End Sub

    Private Sub ActivarSoftware()

        tpSoftware.Enabled = True
        tpSoftware.Focus()

    End Sub

    Private Function ValidaCamposHardware() As Boolean
        Try
            If toBlank(txtProcesador.Text) = "" Then
                MsgBox("Debe ingresar el procesador", MsgBoxStyle.Information, "Información")
                txtProcesador.Focus()
                Return False
            ElseIf toBlank(txtPlacaMadre.Text) = "" Then
                MsgBox("Debe ingresar la placa madre", MsgBoxStyle.Information, "Información")
                txtPlacaMadre.Focus()
                Return False
            ElseIf toBlank(txtMemoriaRam.Text) = "" Then
                MsgBox("Debe ingresar la memoria ram", MsgBoxStyle.Information, "Información")
                txtMemoriaRam.Focus()
                Return False
            ElseIf toBlank(txtTarjetaVideo.Text) = "" Then
                MsgBox("Debe ingresar la tarjeta de video", MsgBoxStyle.Information, "Información")
                txtTarjetaVideo.Focus()
                Return False
            ElseIf toBlank(txtLectora.text) = "" Then
                MsgBox("Debe ingresar la lectora", MsgBoxStyle.Information, "Información")
                txtLectora.Focus()
                Return False
            ElseIf toBlank(txtDiscoDuro.text) = "" Then
                MsgBox("Debe ingresar el Disco Duro", MsgBoxStyle.Information, "Información")
                txtDiscoDuro.Focus()
                Return False
            ElseIf toBlank(txtCargador.text) = "" Then
                MsgBox("Debe ingresar el cargador", MsgBoxStyle.Information, "Información")
                txtCargador.Focus()
                Return False
            ElseIf toBlank(txtMonitor.text) = "" Then
                MsgBox("Debe ingresar el monitor", MsgBoxStyle.Information, "Información")
                txtMonitor.Focus()
                Return False
            ElseIf toBlank(txtTeclado.text) = "" Then
                MsgBox("Debe ingresar el teclado", MsgBoxStyle.Information, "Información")
                txtTeclado.Focus()
                Return False
            ElseIf toBlank(txtMouse.text) = "" Then
                MsgBox("Debe ingresar el mouse", MsgBoxStyle.Information, "Información")
                txtMouse.Focus()
                Return False
            ElseIf toBlank(txtFecIniUso.text) = "" Then
                MsgBox("Debe ingresar la fecha de inicio de uso", MsgBoxStyle.Information, "Información")
                txtMouse.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

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

    Private Sub biLimpiarProcesador_Click(sender As Object, e As EventArgs) Handles biLimpiarProcesador.Click
        IdProcesador = 0
        txtProcesador.Text = ""
    End Sub

    Private Sub btnLimpiarPlacaMadre_Click(sender As Object, e As EventArgs) Handles btnLimpiarPlacaMadre.Click
        IdPlacaMadre = 0
        txtPlacaMadre.Text = ""
    End Sub

    Private Sub btnLimpiarMemRam_Click(sender As Object, e As EventArgs) Handles btnLimpiarMemRam.Click
        IdMemRam = 0
        txtMemoriaRam.Text = ""
    End Sub

    Private Sub btnLimpiarTarjetaVideo_Click(sender As Object, e As EventArgs) Handles btnLimpiarTarjetaVideo.Click
        IdTarjetaVideo = 0
        txtTarjetaVideo.Text = ""
    End Sub

    Private Sub btnLimpiarDiscoDuro_Click(sender As Object, e As EventArgs) Handles btnLimpiarDiscoDuro.Click
        IdDiscoDuro = 0
        txtDiscoDuro.Text = ""
    End Sub

    Private Sub btnLimpiarLectora_Click(sender As Object, e As EventArgs) Handles btnLimpiarLectora.Click
        IdLectora = 0
        txtLectora.Text = ""
    End Sub

    Private Sub btnLimpiarCargador_Click(sender As Object, e As EventArgs) Handles btnLimpiarCargador.Click
        IdCargador = 0
        txtCargador.Text = ""
    End Sub

    Private Sub btnLimpiarMonitor_Click(sender As Object, e As EventArgs) Handles btnLimpiarMonitor.Click
        IdMonitor = 0
        txtMonitor.Text = ""
    End Sub

    Private Sub biDeshacerHardware_Click(sender As Object, e As EventArgs) Handles biDeshacerHardware.Click
        If state_button = True Then
            ObtenerHardware()
        End If
    End Sub

    Private Sub btnAgregarSoftware_Click(sender As Object, e As EventArgs) Handles btnAgregarSoftware.Click

        Try
            Dim frm As New frmSoftware
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSoftware = frm.IdSoftware
                txtSoftware.Text = frm.txtNomAplicacion.Text
                AgregarSoftware()
            End If
        Catch ex As Exception
            MsgBox("Error al agregar la placa madre : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

        'listaDatos()
    End Sub

    Private Sub AgregarSoftware()

        Try
            'If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            'Then 'And ValidaCampos() Then
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

                'If state_button Then        'Modificar
                '    ModificarSoftware(registro)
                'Else                              'Nuevo
                InsertarSoftware(registro)
            'End If
            ' End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub InsertarSoftware(ByVal registro As ComputadoraService.ComputadoraSoftware)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.InsertarComputadoraSoftware(registro)
             type_process = "insert"
            If estado_process Then
                listarSoftwares()
                IdSoftware = 0
                txtSoftware.Text = ""
                'IdCargador = estado_process
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarSoftware(ByVal registro As ComputadoraService.ComputadoraSoftware)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.ActualizarComputadoraSoftware(registro)
            'estado_process = oComputadoraService.Borrar()
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL SOFTWARE" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listarSoftwares()
        Try

            dtDatos = oComputadoraService.MostrarComputadoraSoftware(IdComputadora).Tables(0)
            dgvSoftwares.DataSource = dtDatos
            'sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
            'enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR SOFTWARES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos de la computadora?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New ComputadoraService.Computadora
                Dim hardware As New ComputadoraService.Hardware
                Dim software As New ComputadoraService.Software
                Dim tipocomputadora As New ComputadoraService.TipoComputadora
                Dim computadorasoftware As New ComputadoraService.ComputadoraSoftware



                registro.IdComputadora = IdComputadora
                registro.NomPc = txtComputadora.Text
                tipocomputadora.IdTipoComputadora = cmbTipoComputadora.Value
                registro.TipoComputadora = tipocomputadora

                ' hardware.IdHardware = IdHardware
                ' registro.Hardware = hardware

                registro.Vigente = cbVigente.Checked

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

    'Private Sub btnBuscarSoftware_Click(sender As Object, e As EventArgs) Handles btnBuscarSoftware.Click

    '    Try
    '        Dim frm As New frmBuscarSoftware
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

    '            If toNull(frm.codigo) <> Nothing Then
    '                txtSoftware.Text = frm.descripcion
    '                IdSoftware = frm.codigo
    '            Else
    '                txtCargador.Text = ""
    '                IdCargador = 0
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

    Private Sub InsertarComputadora(ByVal registro As ComputadoraService.Computadora)
        Try
            Dim estado_process As Integer
            estado_process = oComputadoraService.InsertarComputadora(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdComputadora = estado_process
                MsgBox("Se guardó la computadora correctamente.", MsgBoxStyle.Information, "Información")
                ActivarSoftware()

                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
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
                ActivarSoftware()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA COMPUTADORA" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarSoftware_Click(sender As Object, e As EventArgs) Handles btnBuscarSoftware.Click
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

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If state_button = True Then
            ObtenerRegistro()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub miEliminarSoftware_Click(sender As Object, e As EventArgs) Handles miEliminarSoftware.Click

        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If

    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvSoftwares.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvSoftwares.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvSoftwares.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el software seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oComputadoraService.BorrarComputadoraSoftware(dgvSoftwares.CurrentRow.Cells("IdComputadora").Value, dgvSoftwares.CurrentRow.Cells("IdSoftware").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listarSoftwares()
                    MsgBox("Se eliminó el software correctamente.", MsgBoxStyle.Information)
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
        listarSoftwares()
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class