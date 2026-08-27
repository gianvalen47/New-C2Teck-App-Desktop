Imports System.ServiceModel
Public Class frmSeguimiento

    '===========================Servicios====================================================
    Private oSeguimientoService As New SeguimientoService.SeguimientoServiceClient
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oMotorService As New MotorService.MotorServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oAsignacionJefesAreaService As New AsignacionJefesService.AsignacionJefesServiceClient

    '====================== Declaración de Variables =============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable


    Public IdSeguimiento As Integer
    Public iCodOfi As String
    Public iDesOfi As String
    Private CodOfiObt As String
    Private dtDatos As DataTable
    Private dtSisMot As DataTable
    Private dtTipSeg As DataTable
    Private dtProSeg As DataTable
    Private dtSupervisor As DataTable
    Private dtTipoComponente As DataTable
    Private dtTipoSubComponente As DataTable
    Public IdPersona As Integer                    'IdPer de Supervisor
    Public IdLocacion As String

    Private Sub frmSeguimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbPersonal.Visible = True
            actualizarDetalles()
            Me.Text = "Seguimiento"
            dgvDatos.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(598, 538)
            txtFecha.Value = Today
            lblOficina.Text = "Oficina : " & iDesOfi
            txtHoraInicio.Value = Now
            txtHoraFinal.Text = Now
            gbPersonal.Visible = False
            cbAfectaDisponibilidad.Checked = False
            Me.Text = "Nuevo registro de Seguimiento"
            activar()            
            txtCodMer.Select()
        End If
    End Sub

    Private Sub frmSeguimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSeguimiento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguimientoService.Close()
            oMotorService.Close()
            oJobService.Close()
            oSeguridadService.Close()
            oAsignacionJefesAreaService.Close()
            oMotorService.Close()
        Catch ex As TimeoutException
            oSeguimientoService.Abort()
            oMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesAreaService.Abort()
            oMotorService.Abort()
        Catch ex As CommunicationException
            oSeguimientoService.Abort()
            oMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesAreaService.Abort()
            oMotorService.Abort()
        End Try
    End Sub

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

            '================================= SISTEMAS MOTOR ====================================
            dtSisMot = oSeguimientoService.MostrarSistemaMotor.Tables(0)
            'dtSisMot.Rows.InsertAt(getRowTodos(dtSisMot), 0)
            cmbSistemasMotor.DataSource = dtSisMot
            cmbSistemasMotor.DropDownList.DataMember = dtSisMot.Columns("DesSistema").ToString
            cmbSistemasMotor.DropDownList.DisplayMember = dtSisMot.Columns("DesSistema").ToString
            cmbSistemasMotor.DropDownList.ValueMember = dtSisMot.Columns("IdSistema").ToString
            cmbSistemasMotor.DropDownList.Columns(0).DataMember = dtSisMot.Columns("IdSistema").ToString
            cmbSistemasMotor.DropDownList.Columns(1).DataMember = dtSisMot.Columns("DesSistema").ToString
            cmbSistemasMotor.SelectedIndex = 0
            dtSisMot = Nothing

            '================================= TIPO SEGUIMIENTO ===================================
            dtTipSeg = oSeguimientoService.MostrarTipoSeguimiento.Tables(0)
            dtTipSeg.Rows.InsertAt(getRowTodos(dtTipSeg), 0)
            cmbTipoSeguimiento.DataSource = dtTipSeg
            cmbTipoSeguimiento.DropDownList.DataMember = dtTipSeg.Columns("DesTipo").ToString
            cmbTipoSeguimiento.DropDownList.DisplayMember = dtTipSeg.Columns("DesTipo").ToString
            cmbTipoSeguimiento.DropDownList.ValueMember = dtTipSeg.Columns("IdTipo").ToString
            cmbTipoSeguimiento.DropDownList.Columns(0).DataMember = dtTipSeg.Columns("IdTipo").ToString
            cmbTipoSeguimiento.DropDownList.Columns(1).DataMember = dtTipSeg.Columns("DesTipo").ToString
            cmbTipoSeguimiento.SelectedIndex = 0
            dtTipSeg = Nothing

            '=============================== PROCESO SEGUIMIENTO =================================
            dtProSeg = oSeguimientoService.MostrarProcesoSeguimiento.Tables(0)
            dtProSeg.Rows.InsertAt(getRowTodos(dtProSeg), 0)
            cmbProceso.DataSource = dtProSeg
            cmbProceso.DropDownList.DataMember = dtProSeg.Columns("DesProceso").ToString
            cmbProceso.DropDownList.DisplayMember = dtProSeg.Columns("DesProceso").ToString
            cmbProceso.DropDownList.ValueMember = dtProSeg.Columns("IdProceso").ToString
            cmbProceso.DropDownList.Columns(0).DataMember = dtProSeg.Columns("IdProceso").ToString
            cmbProceso.DropDownList.Columns(1).DataMember = dtProSeg.Columns("DesProceso").ToString
            cmbProceso.SelectedIndex = 0
            dtProSeg = Nothing

            ''=============================== PROCESO SEGUIMIENTO =================================
            'dtProSeg = oSeguimientoService.MostrarProcesoSeguimiento.Tables(0)
            ''dtProSeg.Rows.InsertAt(getRowTodos(dtProSeg), 0)
            'cmbProceso.DataSource = dtProSeg
            'cmbProceso.DropDownList.DataMember = dtProSeg.Columns("DesProceso").ToString
            'cmbProceso.DropDownList.DisplayMember = dtProSeg.Columns("DesProceso").ToString
            'cmbProceso.DropDownList.ValueMember = dtProSeg.Columns("IdProceso").ToString
            'cmbProceso.DropDownList.Columns(0).DataMember = dtProSeg.Columns("IdProceso").ToString
            'cmbProceso.DropDownList.Columns(1).DataMember = dtProSeg.Columns("DesProceso").ToString
            'cmbProceso.SelectedIndex = 0
            'dtProSeg = Nothing


            Dim CodCentro As String
            CodCentro = oSeguridadService.ObtenerCodCentro(Session.sCodUsu)

            dtSupervisor = oAsignacionJefesAreaService.MostrarJefeArea(CodCentro).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

          

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
        miNuevoMasivo.Enabled = IIf(editable, True, False)

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
            txtIdSeguimiento.ReadOnly = True
            txtIdSeguimiento.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            btnNumSerie.Enabled = False
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSeguimiento.ReadOnly = False
            cmbTipoSeguimiento.BackColor = System.Drawing.SystemColors.Window
            cmbProceso.ReadOnly = False
            cmbProceso.BackColor = System.Drawing.SystemColors.Window
            cmbSistemasMotor.ReadOnly = False
            cmbSistemasMotor.BackColor = System.Drawing.SystemColors.Window
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            cmbSupervisor.ReadOnly = False
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Window
            'txtSupervisor.ReadOnly = True
            'txtSupervisor.BackColor = System.Drawing.SystemColors.Control
            'btnBuscarSupervisor.Enabled = True
            txtHrsParciales.ReadOnly = False
            txtHrsParciales.BackColor = System.Drawing.SystemColors.Window
            txtHrsTotales.ReadOnly = False
            txtHrsTotales.BackColor = System.Drawing.SystemColors.Window
            txtHoraInicio.ReadOnly = False
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Window
            txtHoraFinal.ReadOnly = False
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            cmbTipoComponente.ReadOnly = False
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSubComponente.ReadOnly = False
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cbAfectaDisponibilidad.Enabled = True

            If toNumber(cmbTipoSeguimiento.Value) = 1 Or toNumber(cmbTipoSeguimiento.Value) = 2 Or toNumber(cmbTipoSeguimiento.Value) = 7 Then
                cbCambioMotor.Enabled = True
            Else
                cbCambioMotor.Enabled = False
            End If

            edicion = True
            enableOpciones()
            txtFecha.Focus()

        Else
            txtIdSeguimiento.ReadOnly = True
            txtIdSeguimiento.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.ReadOnly = False
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            btnNumSerie.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSeguimiento.ReadOnly = False
            cmbTipoSeguimiento.BackColor = System.Drawing.SystemColors.Window
            cmbProceso.ReadOnly = False
            cmbProceso.BackColor = System.Drawing.SystemColors.Window
            cmbSistemasMotor.ReadOnly = False
            cmbSistemasMotor.BackColor = System.Drawing.SystemColors.Window
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            cmbSupervisor.ReadOnly = False
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Window
            'txtSupervisor.ReadOnly = True
            'txtSupervisor.BackColor = System.Drawing.SystemColors.Control
            'btnBuscarSupervisor.Enabled = True
            txtHrsParciales.ReadOnly = False
            txtHrsParciales.BackColor = System.Drawing.SystemColors.Window
            txtHrsTotales.ReadOnly = False
            txtHrsTotales.BackColor = System.Drawing.SystemColors.Window
            txtHoraInicio.ReadOnly = False
            txtHoraInicio.BackColor = System.Drawing.SystemColors.Window
            'txtHoraInicio.Text = Now().ToString("HH:mm:ss")
            txtHoraInicio.Value = Now
            txtHoraFinal.ReadOnly = False
            txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
            'txtHoraFinal.Text = Now().ToString("HH:mm:ss")
            txtHoraFinal.Value = Now
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            cmbTipoComponente.ReadOnly = False
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSubComponente.ReadOnly = False
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cbAfectaDisponibilidad.Enabled = True
            If toNumber(cmbTipoSeguimiento.Value) = 1 Or toNumber(cmbTipoSeguimiento.Value) = 2 Or toNumber(cmbTipoSeguimiento.Value) = 7 Then
                cbCambioMotor.Enabled = True
            Else
                cbCambioMotor.Enabled = False
            End If
            edicion = True
            enableOpciones()
            txtCodMer.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtIdSeguimiento.ReadOnly = True
        txtIdSeguimiento.BackColor = System.Drawing.SystemColors.Control
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        btnNumSerie.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbTipoSeguimiento.ReadOnly = True
        cmbTipoSeguimiento.BackColor = System.Drawing.SystemColors.Control
        cmbProceso.ReadOnly = True
        cmbProceso.BackColor = System.Drawing.SystemColors.Control
        cmbSistemasMotor.ReadOnly = True
        cmbSistemasMotor.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbSupervisor.ReadOnly = True
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
        'txtSupervisor.ReadOnly = True
        'txtSupervisor.BackColor = System.Drawing.SystemColors.Control
        'btnBuscarSupervisor.Enabled = False
        txtHrsParciales.ReadOnly = True
        txtHrsParciales.BackColor = System.Drawing.SystemColors.Control
        txtHrsTotales.ReadOnly = True
        txtHrsTotales.BackColor = System.Drawing.SystemColors.Control
        txtHoraInicio.ReadOnly = True
        txtHoraInicio.BackColor = System.Drawing.SystemColors.Control
        txtHoraFinal.ReadOnly = True
        txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
        txtFalla.ReadOnly = True
        txtFalla.BackColor = System.Drawing.SystemColors.Control
        txtCausa.ReadOnly = True
        txtCausa.BackColor = System.Drawing.SystemColors.Control
        cmbTipoComponente.ReadOnly = True
        cmbTipoComponente.BackColor = System.Drawing.SystemColors.Control
        cmbTipoSubComponente.ReadOnly = True
        cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Control
        txtComponente.ReadOnly = True
        txtComponente.BackColor = System.Drawing.SystemColors.Control
        txtCorreccion.ReadOnly = True
        txtCorreccion.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        cbAfectaDisponibilidad.Enabled = False
        cbCambioMotor.Enabled = False
        edicion = False
        enableOpciones()
        txtCodMer.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMer.Text) <> "" And txtHrsParciales.Value = 0 Then
                MsgBox("Debe Ingresar las Horas Parciales..", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtCodMer.Text) <> "" And txtHrsTotales.Value = 0 Then
                MsgBox("Debe Ingresar las Horas Totales..", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toNumber(cmbTipoSeguimiento.Value) = 0 Then
                MsgBox("Debe de Ingresar el Tipo de Seguimiento.", MsgBoxStyle.Information, "Información")
                cmbTipoSeguimiento.Focus()
                Return False
            ElseIf toNumber(cmbProceso.Value) = 0 Then
                MsgBox("Debe de Ingresar el Proceso de Seguimiento.", MsgBoxStyle.Information, "Información")
                cmbProceso.Focus()
                Return False
            ElseIf toNumber(cmbSistemasMotor.Value) = 0 Then
                MsgBox("Debe de Ingresar el Sistema de Motor.", MsgBoxStyle.Information, "Información")
                cmbSistemasMotor.Focus()
                Return False
                'ElseIf toNumber(IdPersona) = 0 Then
                '    MsgBox("Debe de Ingresar el Supervisor.", MsgBoxStyle.Information, "Información")
                '    txtSupervisor.Focus()
                '    Return False
            ElseIf toBlank(txtHoraInicio.Value) = "" Then
                MsgBox("Debe de Ingresar la Hora de Inicio.", MsgBoxStyle.Information, "Información")
                txtHoraInicio.Focus()
                Return False
            ElseIf toBlank(txtHoraFinal.Value) = "" Then
                MsgBox("Debe de Ingresar la Hora Fin.", MsgBoxStyle.Information, "Información")
                txtHoraInicio.Focus()
                Return False
            ElseIf utils.toBlank(txtFalla.Text) = "" And (cmbTipoSeguimiento.Value <> "99" And cmbTipoSeguimiento.Value <> "3" And cmbTipoSeguimiento.Value <> "6") Then
                MsgBox("Debe ingresar la Falla", MsgBoxStyle.Information, "Información")
                txtFalla.Focus()
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
            Dim registro As SeguimientoService.Seguimiento
            registro = oSeguimientoService.Obtener(IdSeguimiento)

            IdSeguimiento = registro.IdSeguimiento
            txtIdSeguimiento.Text = registro.IdSeguimiento
            txtCodMer.Text = registro.Motor.NumSerie
            'txtNomEquipo.Text = registro.Motor.Equipo.NomEquipo
            'txtTipoMotor.Text = registro.Motor.Modelo.TipoMotor.TipMot
            If toBlank(registro.Motor.NumSerie) <> "" Then
                ObtenerEquipo(registro.Motor.NumSerie)
            End If

            CodOfiObt = registro.Oficina.CodOfi
            lblOficina.Text = "Oficina : " & registro.Oficina.DesOfi
            txtFecha.Value = registro.Fecha
            cmbTipoSeguimiento.Value = registro.TipoSeguimiento.IdTipo
            cmbProceso.Value = registro.ProcesoSeguimiento.IdProceso
            cmbSistemasMotor.Value = registro.SistemaMotor.IdSistema
            txtNumJob.Text = registro.Job.CodJob
            cbAfectaDisponibilidad.Checked = registro.AfectaDisponibilidad

            cbCambioMotor.Checked = registro.CambioMotor
            cmbSupervisor.Value = registro.PersonaSupervisor.IdPer

            txtHrsTotales.Value = registro.TotalHoras
            txtHrsParciales.Value = registro.HoraParcial
            txtHoraInicio.Text = registro.HoraInicio
            txtHoraFinal.Text = registro.HoraFin
            txtCantHoras.Value = registro.CantidadHoras
            txtFalla.Text = registro.Falla
            txtCausa.Text = registro.Causa
            If registro.TipoComponente.IdComponente <> 0 Then
                cmbTipoComponente.Value = registro.TipoComponente.IdComponente
            Else
                cmbTipoComponente.SelectedIndex = 0
            End If
            If registro.TipoSubComponente.IdSubComponente = 0 Or registro.TipoSubComponente.IdSubComponente Is Nothing Then
                cmbTipoSubComponente.SelectedIndex = 0
            Else
                cmbTipoSubComponente.Value = registro.TipoSubComponente.IdSubComponente
            End If
            txtComponente.Text = registro.Componente
            txtCorreccion.Text = registro.Correccion
            txtObservacion.Text = registro.Observacion

            Me.Text = "Seguimiento"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalleMasivo()
        Try
            Dim frm As New frmSeguimiento_PersonalMasivo
            frm.IdSeguimiento = IdSeguimiento
            frm.IdLocacion = IdLocacion
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
            'Dim frm As New frmBuscarPersonal
            'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '    If toNull(frm.codigo) <> Nothing Then
            '        Dim registro As New SeguimientoService.TecnicosSeguimiento
            '        Dim Seguimiento As New SeguimientoService.Seguimiento
            '        Dim Persona As New SeguimientoService.Persona

            '        Seguimiento.IdSeguimiento = IdSeguimiento
            '        registro.Seguimiento = Seguimiento

            '        Persona.IdPer = toNumber(frm.codigo)
            '        registro.PersonaTecnico = Persona

            '        registro.CodUsu = Session.sCodUsu
            '        registro.DirIp = Session.sDirIp
            '        registro.NomPc = Session.sNomPc

            '        InsertarDetalle(registro)
            '    End If
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO TÉCNICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub NuevoDetalle()
        Try
            'Dim frm As New frmSeguimiento_PersonalMasivo
            'frm.IdSeguimiento = IdSeguimiento
            'frm.IdLocacion = IdLocacion
            'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '    listaDatos()
            'End If
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    Dim registro As New SeguimientoService.TecnicosSeguimiento
                    Dim Seguimiento As New SeguimientoService.Seguimiento
                    Dim Persona As New SeguimientoService.Persona

                    Seguimiento.IdSeguimiento = IdSeguimiento
                    registro.Seguimiento = Seguimiento

                    Persona.IdPer = toNumber(frm.codigo)
                    registro.PersonaTecnico = Persona

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.NomPc = Session.sNomPc

                    InsertarDetalle(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO TÉCNICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarDetalle(ByVal registro As SeguimientoService.TecnicosSeguimiento)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguimientoService.InsertarTecnico(registro)
            type_process = "insert"
            If estado_process = True Then
                listaDatos()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TÉCNICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguimientoService.BorrarTecnico(IdSeguimiento, toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR TÉCNICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmSeguimiento_Personal
            frm.IdPer = dgvDatos.CurrentRow.Cells("IdPer").Value
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            frm.DesCargo = dgvDatos.CurrentRow.Cells("DesCargo").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
            End If
            RowPossesion(dgvDatos, frm.IdPer)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR TÉCNICO: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub Insertar(ByVal registro As SeguimientoService.Seguimiento)
        Try
            Dim estado_process As Integer
            estado_process = oSeguimientoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdSeguimiento = estado_process
                MsgBox("Se insertó el seguimiento Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR SEGUIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SeguimientoService.Seguimiento)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguimientoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el seguimiento Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR SEGUIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oSeguimientoService.Borrar(IdSeguimiento, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR SEGUIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSeguimientoService.MostrarTecnico(IdSeguimiento).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR TÉCNICOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscarSupervisor_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmBuscarPersonal
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            If toNull(frm.codigo) <> Nothing Then
    '                IdPersona = frm.codigo
    '                txtSupervisor.Text = frm.descripcion
    '                txtFecha.Focus()
    '            Else
    '                IdPersona = 0
    '                txtSupervisor.Text = ""
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New SeguimientoService.Seguimiento
                    Dim empresa As New SeguimientoService.Empresa
                    Dim oficina As New SeguimientoService.Oficina
                    Dim Motor As New SeguimientoService.Motor
                    Dim TipoSeguimiento As New SeguimientoService.TipoSeguimiento
                    Dim SistemaMotor As New SeguimientoService.SistemaMotor
                    Dim ProcesoSeguimiento As New SeguimientoService.ProcesoSeguimiento
                    Dim Persona As New SeguimientoService.Persona
                    Dim Job As New SeguimientoService.Job
                    Dim TipoComponente As New SeguimientoService.TipoComponente
                    Dim TipoSubComponente As New SeguimientoService.TipoSubComponente

                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.IdSeguimiento = IdSeguimiento

                    Motor.NumSerie = toNull(txtCodMer.Text)
                    registro.Motor = Motor

                    TipoSeguimiento.IdTipo = cmbTipoSeguimiento.Value
                    registro.TipoSeguimiento = TipoSeguimiento

                    ProcesoSeguimiento.IdProceso = cmbProceso.Value
                    registro.ProcesoSeguimiento = ProcesoSeguimiento

                    SistemaMotor.IdSistema = cmbSistemasMotor.Value
                    registro.SistemaMotor = SistemaMotor

                    registro.Fecha = txtFecha.Value
                    registro.TotalHoras = txtHrsTotales.Value
                    registro.HoraParcial = txtHrsParciales.Value
                    registro.HoraInicio = txtHoraInicio.Value
                    registro.HoraFin = txtHoraFinal.Value

                    Job.CodJob = utils.toNull(txtNumJob.Text)
                    registro.Job = Job

                    If state_button Then
                        oficina.CodOfi = CodOfiObt
                    Else
                        oficina.CodOfi = iCodOfi
                    End If
                    registro.Oficina = oficina

                    Persona.IdPer = cmbSupervisor.Value
                    registro.PersonaSupervisor = Persona

                    Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                    registro.Job = Job

                    registro.Causa = toNull(txtCausa.Text)
                    registro.Falla = toNull(txtFalla.Text)
                    registro.Componente = toNull(txtComponente.Text)
                    If toNumber(cmbTipoComponente.Value) = 0 Then
                        TipoComponente.IdComponente = Nothing
                        registro.TipoComponente = TipoComponente
                    Else
                        TipoComponente.IdComponente = cmbTipoComponente.Value
                        registro.TipoComponente = TipoComponente
                    End If

                    If toNumber(cmbTipoSubComponente.Value) = 0 Then
                        TipoSubComponente.TipoComponente = TipoComponente
                        TipoSubComponente.IdSubComponente = Nothing
                        registro.TipoSubComponente = TipoSubComponente
                    Else
                        TipoSubComponente.TipoComponente = TipoComponente
                        TipoSubComponente.IdSubComponente = cmbTipoSubComponente.Value
                        registro.TipoSubComponente = TipoSubComponente
                    End If
                    registro.Correccion = toNull(txtCorreccion.Text)
                    registro.Observacion = toNull(txtObservacion.Text)
                    registro.AfectaDisponibilidad = cbAfectaDisponibilidad.Checked
                    registro.CambioMotor = cbCambioMotor.Checked

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
            MsgBox("ERROR AL GUARDAR SEGUIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
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

    'Private Sub txtSupervisor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F12 Then
    '        If btnBuscarSupervisor.Enabled = True Then
    '            e.Handled = True
    '            btnBuscarSupervisor_Click(sender, e)
    '        End If
    '    End If
    'End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            'IdLocacion = oSeguridadService.ObtenerCodOfi(Session.sCodUsu)
            IdLocacion = IIf(state_button = True, CodOfiObt, iCodOfi) 'oSeguridadService.ObtenerCodOfi(Session.sCodUsu)
            frm.idlocacion = IdLocacion
            If cmbProceso.Value = 1 Or cmbProceso.Value = 2 Then
                frm.tipo = 3
            ElseIf cmbProceso.Value = 3 Then
                frm.tipo = 4
            ElseIf cmbProceso.Value = 4 Then
                frm.tipo = 2
            End If

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
                Else
                    cmbSupervisor.Focus()
                End If
            Else
                cmbSupervisor.Focus()
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
                Else
                    cmbSupervisor.Focus()
                End If
            Else
                cmbSupervisor.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtIdSeguimiento.KeyPress _
                           , txtCodMer.KeyPress _
                           , txtFecha.KeyPress _
                           , cmbTipoSeguimiento.KeyPress _
                           , cmbProceso.KeyPress _
                           , cmbSistemasMotor.KeyPress _
                           , txtHrsParciales.KeyPress _
                           , txtHrsTotales.KeyPress _
                           , txtFalla.KeyPress _
                           , txtCausa.KeyPress _
                           , txtComponente.KeyPress _
                           , txtCorreccion.KeyPress _
                           , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodMer.Text)) > 0 Then
                If Not (oMotorService.Buscar(txtCodMer.Text)) Then
                    MsgBox("El número de serie ingresado no está registrado en la tabla MOTORES.", MsgBoxStyle.Information, "Información")
                    txtCodMer.Focus()
                    txtNomEquipo.Text = ""
                    txtTipoMotor.Text = ""
                Else
                    ObtenerEquipo(txtCodMer.Text)
                End If
                'Else
                '    MsgBox("Debe ingresar el número de serie.", MsgBoxStyle.Information, "Información")
                'txtCodMer.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodMer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodMer.Validated
        If Len(Trim(txtCodMer.Text)) > 0 Then
            If Not (oMotorService.Buscar(txtCodMer.Text)) Then
                MsgBox("El número de serie ingresado no está registrado en la tabla MOTORES.", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
            Else
                ObtenerEquipo(txtCodMer.Text)
            End If
            'Else
            '    MsgBox("Debe ingresar el número de serie.", MsgBoxStyle.Information, "Información")
            'txtCodMer.Focus()
        End If
    End Sub

    Private Sub ObtenerEquipo(ByVal CodMer As String)
        Try            
            Dim registro As MotorService.Motor
            registro = oMotorService.Obtener(CodMer)

            txtCodMer.Text = registro.NumSerie
            txtNomEquipo.Text = registro.Equipo.NomEquipo
            txtTipoMotor.Text = registro.Modelo.TipoMotor.TipMot
            'lblOficina.Text = "Oficina : " & registro.UbicacionEquipo.DesUbicacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbSupervisor.Focus()
        End If
    End Sub

    Private Sub btnNumSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumSerie.Click
        Try
            Dim frm As New frmBuscarMotor

            frm.UbicPers = oSeguimientoService.ObtenerCodUbicacionxOficina(IIf(state_button = True, CodOfiObt, iCodOfi))

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodMer.Text = frm.codigo
                    ObtenerEquipo(frm.codigo)
                Else
                    txtCodMer.Text = ""
                    txtCodMer.Focus()
                    txtNomEquipo.Text = ""
                    txtTipoMotor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtHrsTotales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHrsTotales.ValueChanged
        txtHrsParciales.Value = oHorasMotorService.SugerirHoraParcial(txtCodMer.Text, txtHrsTotales.Value)
    End Sub


    Private Sub miNuevoMasivo_Click(sender As System.Object, e As System.EventArgs) Handles miNuevoMasivo.Click
        If state_button = True Then
            NuevoDetalleMasivo()
        End If
    End Sub

    Private Sub miNuevo_Click(sender As System.Object, e As System.EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub cmbTipoSeguimiento_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipoSeguimiento.ValueChanged
        '--------------------------------------------- NINGUNO ------------------------------------------------
        If cmbTipoSeguimiento.Value = "99" Then
            txtFalla.ReadOnly = True
            txtFalla.BackColor = System.Drawing.SystemColors.Control
            txtCausa.ReadOnly = True
            txtCausa.BackColor = System.Drawing.SystemColors.Control
            txtComponente.ReadOnly = True
            txtComponente.BackColor = System.Drawing.SystemColors.Control
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cmbTipoComponente.ReadOnly = True
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.SelectedIndex = 0
            cmbTipoSubComponente.ReadOnly = True
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoSubComponente.SelectedIndex = 0
            'txtComponente.ReadOnly = False
            'txtComponente.BackColor = System.Drawing.SystemColors.Window
            cbCambioMotor.Enabled = False
            cbCambioMotor.Checked = False
            '--------------------------------------------- CORRECTIVO ------------------------------------------------
        ElseIf cmbTipoSeguimiento.Value = "1" Then
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cmbTipoComponente.ReadOnly = False
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSubComponente.ReadOnly = False
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            cbCambioMotor.Enabled = True
            '--------------------------------------------- MANTENIMIENTO PROGRAMADO ------------------------------------------------
        ElseIf cmbTipoSeguimiento.Value = "2" Then
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = True
            txtCausa.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.ReadOnly = True
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.SelectedIndex = 0
            txtComponente.ReadOnly = True
            txtComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoSubComponente.ReadOnly = True
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoSubComponente.SelectedIndex = 0
            cbCambioMotor.Enabled = True
            '--------------------------------------------- INSPECCION ------------------------------------------------------------
        ElseIf cmbTipoSeguimiento.Value = "3" Then
            txtFalla.ReadOnly = True
            txtFalla.BackColor = System.Drawing.SystemColors.Control
            txtCausa.ReadOnly = True
            txtCausa.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.ReadOnly = True
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.SelectedIndex = 0
            cmbTipoSubComponente.ReadOnly = True
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoSubComponente.SelectedIndex = 0
            txtComponente.ReadOnly = True
            txtComponente.BackColor = System.Drawing.SystemColors.Control
            cbCambioMotor.Enabled = False
            cbCambioMotor.Checked = False
            '--------------------------------------------- MONITOREO ------------------------------------------------------------
        ElseIf cmbTipoSeguimiento.Value = "5" Then
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = True
            txtCausa.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.ReadOnly = True
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.SelectedIndex = 0
            cmbTipoSubComponente.ReadOnly = True
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoSubComponente.SelectedIndex = 0
            txtComponente.ReadOnly = True
            txtComponente.BackColor = System.Drawing.SystemColors.Control
            cbCambioMotor.Enabled = False
            cbCambioMotor.Checked = False
            '--------------------------------------------- INSPECCION ------------------------------------------------------------
        ElseIf cmbTipoSeguimiento.Value = "6" Then
            txtFalla.ReadOnly = True
            txtFalla.BackColor = System.Drawing.SystemColors.Control
            txtCausa.ReadOnly = True
            txtCausa.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.ReadOnly = True
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoComponente.SelectedIndex = 0
            cmbTipoSubComponente.ReadOnly = True
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Control
            cmbTipoSubComponente.SelectedIndex = 0
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            cbCambioMotor.Enabled = False
            cbCambioMotor.Checked = False
            '--------------------------------------------- MANTENIMIENTO + CORRECTIVO ------------------------------------------------------------
        ElseIf cmbTipoSeguimiento.Value = "7" Then
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cmbTipoComponente.ReadOnly = False
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSubComponente.ReadOnly = False
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            cbCambioMotor.Enabled = True
        Else
            txtFalla.ReadOnly = False
            txtFalla.BackColor = System.Drawing.SystemColors.Window
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            cmbTipoComponente.ReadOnly = False
            cmbTipoComponente.BackColor = System.Drawing.SystemColors.Window
            cmbTipoSubComponente.ReadOnly = False
            cmbTipoSubComponente.BackColor = System.Drawing.SystemColors.Window
            txtComponente.ReadOnly = False
            txtComponente.BackColor = System.Drawing.SystemColors.Window
            cbCambioMotor.Enabled = False
            cbCambioMotor.Checked = False
        End If
    End Sub

    Private Sub cmbTipoComponente_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbTipoComponente.ValueChanged, txtTipoMotor.TextChanged
        LlenarTipoSubComponente()
    End Sub

    Private Sub LlenarTipoSubComponente()
        Try
            '======================================= TIPO SUBCOMPONENTE =============================================
            'If cmbTipoComponente.SelectedIndex <> 0 Then
            dtTipoSubComponente = oSeguimientoService.MostrarTipoSubComponente(cmbTipoComponente.Value, txtTipoMotor.Text).Tables(0)
            dtTipoSubComponente.Rows.InsertAt(getRowTodos(dtTipoSubComponente), 0)
            cmbTipoSubComponente.DataSource = dtTipoSubComponente
            cmbTipoSubComponente.DropDownList.DataMember = dtTipoSubComponente.Columns("DesSubComponente").ToString
            cmbTipoSubComponente.DropDownList.DisplayMember = dtTipoSubComponente.Columns("DesSubComponente").ToString
            cmbTipoSubComponente.DropDownList.ValueMember = dtTipoSubComponente.Columns("IdSubComponente").ToString
            cmbTipoSubComponente.DropDownList.Columns(0).DataMember = dtTipoSubComponente.Columns("IdSubComponente").ToString
            cmbTipoSubComponente.DropDownList.Columns(1).DataMember = dtTipoSubComponente.Columns("DesSubComponente").ToString
            cmbTipoSubComponente.SelectedIndex = 0
            dtTipoSubComponente = Nothing
            'Else
            'dtTipoSubComponente = oSeguimientoService.MostrarTipoSubComponente(cmbTipoComponente.Value).Tables(0)
            'dtTipoSubComponente.Rows.InsertAt(getRowTodos(dtTipoSubComponente), 0)
            'cmbTipoSubComponente.DataSource = dtTipoSubComponente
            'cmbTipoSubComponente.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO SUBCOMPONENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbSistemasMotor_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbSistemasMotor.ValueChanged
        LlenarComponentes()
    End Sub

    Private Sub LlenarComponentes()
        Try
            '=============================== COMPONENTES =================================
            dtTipoComponente = oSeguimientoService.MostrarComponentes(toNumber(cmbSistemasMotor.Value)).Tables(0)
            dtTipoComponente.Rows.InsertAt(getRowTodos(dtTipoComponente), 0)
            cmbTipoComponente.DataSource = dtTipoComponente
            cmbTipoComponente.DropDownList.DataMember = dtTipoComponente.Columns("DesComponente").ToString
            cmbTipoComponente.DropDownList.DisplayMember = dtTipoComponente.Columns("DesComponente").ToString
            cmbTipoComponente.DropDownList.ValueMember = dtTipoComponente.Columns("IdComponente").ToString
            cmbTipoComponente.DropDownList.Columns(0).DataMember = dtTipoComponente.Columns("IdComponente").ToString
            cmbTipoComponente.DropDownList.Columns(1).DataMember = dtTipoComponente.Columns("DesComponente").ToString
            cmbTipoComponente.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO COMPONENTES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtHoraInicio_ValueChanged(sender As Object, e As System.EventArgs) Handles txtHoraInicio.ValueChanged, txtHoraFinal.ValueChanged
        txtCantHoras.Value = DateDiff(DateInterval.Hour, txtHoraInicio.Value, txtHoraFinal.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
    End Sub
End Class