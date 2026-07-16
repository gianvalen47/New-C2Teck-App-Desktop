Imports System.ServiceModel

Public Class frmPreMarcacion_Nuevo

    '===========================Servicios====================================================
    Private oPreMarcacionJobService As New PreMarcacionJobService.PreMarcacionJobServiceClient    
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable 
    Public IdPreMarca As Integer
    Public IdPersona As Integer

    Private Sub frmPreMarcacion_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbAprobacion.Visible = True
            Me.Size = New System.Drawing.Size(631, 321)
            Me.Text = "PRE MARCACIÓN Nº " + Chr(34) + IdPreMarca.ToString + Chr(34)
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(631, 265)
            gbAprobacion.Visible = False
            Me.Text = "Registrar Nueva Pre Marcación"
            activar()
            ObtenerSolicitante()
            txtNumJob.Focus()
        End If
    End Sub

    Private Sub frmPreMarcacion_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPreMarcacionJobService.Close()
            oJobService.Close()
            oSeguridadService.Close()       
        Catch ex As TimeoutException
            oPreMarcacionJobService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPreMarcacionJobService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerSolicitante()
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        txtColaborador.Text = usuario.Persona.ApeNom
        btnBuscarPersona.Enabled = IIf(Session.CodPerfil = "01" Or Session.CodPerfil = "17" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24", True, False)
    End Sub

    Private Sub enableOpciones()                  
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        biEnviar.Enabled = IIf(editable, Not edicion, False)
    End Sub

    Private Sub activar()
        If state_button Then
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            'txtColaborador.ReadOnly = True
            'txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False
            btnBuscarPersona.Enabled = False
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtHoraIng.ReadOnly = False
            txtHoraIng.BackColor = System.Drawing.SystemColors.Window
            txtHoraSal.ReadOnly = False
            txtHoraSal.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtNumJob.Focus()
        Else
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            'txtColaborador.ReadOnly = False
            'txtColaborador.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            btnBuscarPersona.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtHoraIng.ReadOnly = False
            txtHoraIng.BackColor = System.Drawing.SystemColors.Window
            txtFecha.Value = Today()
            txtHoraIng.Text = Now().ToString("HH:mm:ss")
            txtHoraSal.ReadOnly = False
            txtHoraSal.BackColor = System.Drawing.SystemColors.Window
            txtHoraSal.Text = Now().ToString("HH:mm:ss")
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtHoraIng.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        'txtColaborador.ReadOnly = True
        'txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersona.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtHoraIng.ReadOnly = True
        txtHoraIng.BackColor = System.Drawing.SystemColors.Control
        txtHoraSal.ReadOnly = True
        txtHoraSal.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        txtNumJob.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtNumJob.Text) = "" Then
                MsgBox("Debe ingresar la OT")
                txtNumJob.Focus()
                Return False
            ElseIf toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar el Colaborador")
                txtColaborador.Focus()
                Return False
            ElseIf utils.toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha")
                txtFecha.Focus()
                Return False
            ElseIf utils.toBlank(txtHoraIng.Text) = "" Then
                MsgBox("Debe ingresar la hora de ingreso")
                txtHoraIng.Focus()
                Return False
            ElseIf utils.toBlank(txtHoraSal.Text) = "" Then
                MsgBox("Debe ingresar la hora de salida")
                txtHoraSal.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PreMarcacionJobService.PreMarcacionJob
            registro = oPreMarcacionJobService.Obtener(IdPreMarca)

            IdPreMarca = registro.IdPreMarca
            txtNumJob.Text = registro.Job.CodJob
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            txtHoraIng.Text = registro.HoraIngreso.ToLongTimeString
            txtHoraSal.Text = registro.HoraSalida.ToLongTimeString
            txtObservacion.Text = registro.Observacion

            cbEnviado.Checked = registro.Enviado
            cbAprobado.Checked = registro.Aprobado
            txtCodUsuAprueba.Text = registro.CodUsuApro
            txtFecAprobacion.Text = utils.toNull(registro.FechaApro.ToString)
            Me.Text = "Pre Marcación Nº " + registro.IdPreMarca.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PreMarcacionJobService.PreMarcacionJob)
        Try
            Dim estado_process As Integer
            estado_process = oPreMarcacionJobService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPreMarca = estado_process
                MsgBox("Se insertó la Pre Marcación Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PRE MARCACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PreMarcacionJobService.PreMarcacionJob)
        Try
            Dim estado_process As Boolean
            estado_process = oPreMarcacionJobService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Pre Marcación Correctamente")
                desactivar()
                ObtenerRegistro()                
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PRE MARCACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPreMarcacionJobService.Borrar(IdPreMarca, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PRE MARCACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtFecha.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New PreMarcacionJobService.PreMarcacionJob
                Dim Job As New PreMarcacionJobService.Job
                Dim Persona As New PreMarcacionJobService.Persona

                registro.IdPreMarca = IdPreMarca
                Job.CodJob = txtNumJob.Text
                registro.Job = Job
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                registro.Fecha = txtFecha.Value
                registro.HoraIngreso = txtHoraIng.Text
                registro.HoraSalida = txtHoraSal.Text
                registro.Observacion = txtObservacion.Text

                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR PRE MARCACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            txtNumJob.Focus()
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

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtColaborador.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de OT")
                txtColaborador.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtColaborador.Focus()
                End If
            Else
                'MsgBox("Ingrese un N° de Job")
                'txtNumJob.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
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

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click
        Try

            If MsgBox("¿Está seguro de ENVIAR la Pre Marcación N° " & IdPreMarca, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPreMarcacionJobService.Enviar(IdPreMarca, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se Envio correctamente la Pre Marcación")
                    ObtenerRegistro()
                    editable = False
                    enableOpciones()
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class