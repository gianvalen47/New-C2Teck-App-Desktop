Imports System.ServiceModel

Public Class frmPlanillaViatico

    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPlanillaViaticoService As New PlanillaViaticoService.PlanillaViaticoServiceClient
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient    
    Private Persona As New PersonaService.Persona

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    Private Atendido As Boolean
    Public IdPersona As Integer
    Public IdPlanilla As Integer
    Public iEstado As Integer
    Private dtAreas As DataTable
    Private dtMonedas As DataTable
    Private dtCorreos As DataTable
    Private dtUbicacion As DataTable
    Public iUbicacion As Integer
    Private dtSubRubros As DataTable

    Private Sub frmPlanillaViatico_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oPlanillaViaticoService.Close()
            oSolicitudCompraService.Close()
            oPersonaService.Close()
            oJobService.Close()
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPlanillaViaticoService.Abort()
            oSolicitudCompraService.Abort()
            oPersonaService.Abort()
            oJobService.Abort()
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPlanillaViaticoService.Abort()
            oSolicitudCompraService.Abort()
            oPersonaService.Abort()
            oJobService.Abort()
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmPlanillaViatico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaViatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvCorreos)
        llenarCombos()

        If state_button Then    'Modificar 
            'iEstado = oPlanillaViaticoService.ObtenerEstado(IdPlanilla)
            ObtenerRegistro()
            Desactivar()
            gbEstados.Visible = True
            listaCorreos()
            If cbEnviado.Checked = True Or cbAprobado.Checked = True Or cbProcesado.Checked = True Then
                Me.Size = New System.Drawing.Size(709, 398)
                gbCorreos.Visible = False
            Else
                Me.Size = New System.Drawing.Size(709, 547)
                gbCorreos.Visible = True
            End If
            Me.Text = "PLANILLA DE VIÁTICO Nº " + Chr(34) + txtNumero.Text.ToString + Chr(34)
        Else                          'Nuevo
            cmbMoneda.Value = "NS"
            rbMovilidad.Checked = True
            Me.Size = New System.Drawing.Size(709, 283)
            gbEstados.Visible = False
            gbCorreos.Visible = False
            Me.Text = "Registrar nueva Planilla de Viático"
            Activar()
            ObtenerSolicitante()
            txtFecha.Select()
            cmbUbicacion.Value = 4
        End If
    End Sub

    Private Sub listaCorreos()
        Try
            dtCorreos = oSolicitudCompraService.MostrarCorreos(cmbArea.Value).Tables(0)
            dgvCorreos.DataSource = dtCorreos
        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Activar()
        If state_button Then
            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersonaS.Enabled = False
            btnBuscarJob.Enabled = True
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            rbMovilidad.Enabled = True
            rbRefrigerio.Enabled = True
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            cmbUbicacion.ReadOnly = True
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
            cmbSubRubro.ReadOnly = False
            cmbSubRubro.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtDescripcion.Focus()
        Else
            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            'Se agrega el perfil 38 Jefe de Operaciones Foráneas 
            btnBuscarPersonaS.Enabled = IIf(Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "38", True, False) ' Agregado el 16/10/2012 habilitando al Supervisor a ingresar Planilla de Viatico de otros técnicos
            btnBuscarJob.Enabled = True
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            rbMovilidad.Enabled = True
            rbRefrigerio.Enabled = True
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
            cmbSubRubro.ReadOnly = False
            cmbSubRubro.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub Desactivar()
        txtNumero.ReadOnly = True
        txtNumero.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersonaS.Enabled = False
        btnBuscarJob.Enabled = False
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control
        rbMovilidad.Enabled = False
        rbRefrigerio.Enabled = False
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbSubRubro.ReadOnly = True
        cmbSubRubro.BackColor = System.Drawing.SystemColors.Control
        If cbEnviado.Checked = False And cbAprobado.Checked = False And cbProcesado.Checked = False Then
            'edicion = True
            enableOpcionesGenerado()
            txtFecha.Focus()
        Else
            edicion = False
            enableOpciones()
            txtFecha.Focus()
        End If

    End Sub

    Private Sub enableOpcionesGenerado()
        biGuardar.Enabled = False
        biEditar.Enabled = True
        biAprobar.Enabled = False
        biDeshacer.Enabled = False
        biAtender.Enabled = False
        biSalir.Enabled = True
    End Sub


    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            If MsgBox("¿Está seguro de ENVIAR la Planilla de Viático Nº " & txtNumero.Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                Dim Cadena As String = ""

                rows = dgvCorreos.GetCheckedRows()
                Dim row As Janus.Windows.GridEX.GridEXRow

                If rows.Count <> 0 Then
                    For Each row In rows
                        If Cadena = "" Then
                            Cadena = row.Cells("Email").Text
                        Else
                            Cadena = Cadena + ";" + row.Cells("Email").Text
                        End If
                    Next
                    '=================================Enviar a Correos Seleccionados=================================
                    Dim estado_process As Boolean
                    estado_process = oPlanillaViaticoService.Enviar(IdPlanilla, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se envió correctamente la Planilla de Viático Nº" & txtNumero.Text, MsgBoxStyle.Information)
                        ObtenerRegistro()
                        edicion = False
                        enableOpciones()
                        Me.Size = New System.Drawing.Size(670, 310)
                        gbCorreos.Visible = False
                    Else
                        MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                    End If
                Else
                    MsgBox("Debe seleccionar alguno de los correos")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Enviar la Planilla de Viático: " + ex.Message, MsgBoxStyle.Exclamation)
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

            '======================================= UBICACION ===============================================
            dtUbicacion = oProvisionalService.MostrarUbicacionCaja(Session.sCodEmp).Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LlenarSubRubro()

        '======================================== SUB RUBROS ==============================================
        dtSubRubros = oPlanillaViaticoService.MostrarSubRubro(IIf(rbMovilidad.Checked, 1, 2)).Tables(0)
        cmbSubRubro.DataSource = dtSubRubros
        cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
        cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
        cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
        'cmbSubRubro.SelectedIndex = 0
        dtSubRubros = Nothing
    End Sub

    Private Sub enableOpciones()
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biAprobar.Enabled = IIf((cbEnviado.Checked = True And cbAprobado.Checked = False), True, False)
        biAtender.Enabled = IIf(cbAprobado.Checked = True And Atendido = False, True, False)

        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumJob.Text) = "" And cmbUbicacion.Value = 4 Then
                MsgBox("Debe ingresar el Job", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf toNumber(cmbUbicacion.Value) = 0 Then
                MsgBox("Debe Ingresar la Ubicación", MsgBoxStyle.Information, "Información")
                cmbUbicacion.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNull(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la Descripción")
                txtDescripcion.Focus()
                Return False
            ElseIf (rbRefrigerio.Checked = False And rbMovilidad.Checked = False) Then
                MsgBox("Debe Seleccionar el Tipo")
                rbMovilidad.Focus()
                Return False
            ElseIf CStr(cmbSubRubro.Value) = "" Then
                MsgBox("Debe Seleccionar el Rubro")
                cmbSubRubro.Focus()
                Return False
            ElseIf toDouble(txtMonto.Text) <= 0 Then
                MsgBox("El monto de la planilla debe ser mayor a CERO.")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PlanillaViaticoService.PlanillaViatico
            registro = oPlanillaViaticoService.Obtener(IdPlanilla)

            IdPlanilla = registro.IdPlanilla
            txtNumero.Text = registro.IdPlanilla
            txtFecha.Value = registro.Fecha
            cmbArea.Value = registro.Area.CodArea
            cmbMoneda.Value = registro.Moneda.CodMon
            'lblEstado.Text = registro.
            IdPersona = registro.Persona.IdPer
            txtPersonaSolicita.Text = registro.Persona.ApeNom
            txtNumJob.Text = registro.Job.CodJob
            txtMonto.Text = registro.Monto
            cbEnviado.Checked = registro.Enviado
            If registro.Enviado = True Then
                txtEnviadoPor.Text = registro.CodUsuEnv
                txtFecEnvio.Value = registro.FechaEnv
                txtFecEnvio.Text = registro.FechaEnv
            End If
            cbAprobado.Checked = registro.Aprobado
            If registro.Aprobado Then
                txtAprobadoPor.Text = registro.CodUsuApro
                txtFecAprob.Value = registro.FechaApro
                txtFecAprob.Text = registro.FechaApro
            End If            
            cbProcesado.Checked = registro.Procesado
            txtDescripcion.Text = registro.Descripcion
            Atendido = registro.Atendido
            cbAtendido.Checked = Atendido
            cmbUbicacion.Value = registro.UbicacionCaja.IdUbicacion
            If registro.Tipo = 1 Then
                rbMovilidad.Checked = True
            ElseIf registro.Tipo = 2 Then
                rbRefrigerio.Checked = True
            End If
            LlenarSubRubro()
            cmbSubRubro.Value = registro.SubRubroGasto.CodSubRubro
            Me.Text = "Planilla de Viático Nº " + registro.IdPlanilla.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerSolicitante()
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        txtPersonaSolicita.Text = usuario.Persona.ApeNom
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos? ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New PlanillaViaticoService.PlanillaViatico
                Dim area As New PlanillaViaticoService.Area
                Dim Moneda As New PlanillaViaticoService.Moneda
                Dim empresa As New PlanillaViaticoService.Empresa
                Dim job As New PlanillaViaticoService.Job
                Dim persona As New PlanillaViaticoService.Persona
                Dim estado As New PlanillaViaticoService.EstadoJob
                Dim Ubicacion As New PlanillaViaticoService.UbicacionCaja
                Dim SubRubro As New PlanillaViaticoService.SubRubroGasto


                registro.IdPlanilla = IdPlanilla
                registro.Fecha = txtFecha.Value
                area.CodArea = cmbArea.Value
                registro.Area = area
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                persona.IdPer = IdPersona
                registro.Persona = persona
                job.CodJob = toNull(txtNumJob.Text)
                registro.Job = job
                SubRubro.CodSubRubro = cmbSubRubro.Value
                registro.SubRubroGasto = SubRubro
                Ubicacion.IdUbicacion = cmbUbicacion.Value
                registro.UbicacionCaja = Ubicacion
                registro.Descripcion = txtDescripcion.Text
                registro.Monto = txtMonto.Value
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If rbMovilidad.Checked = True Then
                    registro.Tipo = 1
                ElseIf rbRefrigerio.Checked = True Then
                    registro.Tipo = 2
                End If
                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR PLANILLA VIÁTICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As PlanillaViaticoService.PlanillaViatico)
        Try
            Dim estado_process As Integer
            estado_process = oPlanillaViaticoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPlanilla = estado_process
                iUbicacion = toNumber(cmbUbicacion.Value)
                MsgBox("Se inserto la Planilla de Viático Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA PLANILLA DE VIÁTICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaViaticoService.PlanillaViatico)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaViaticoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modifico la Planilla de Viático Correctamente")
                Desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA PLANILLA DE VIÁTICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
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

    Private Sub btnBuscarPersonaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                    cmbArea.Focus()
                Else
                    IdPersona = 0
                    txtPersonaSolicita.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub txtPersonaSolicita_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPersonaSolicita.TextChanged
        If state_button = False Then
            Persona = oPersonaService.Obtener(IdPersona)
            cmbArea.Value = Persona.CentroCosto.Area.CodArea
        End If
    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click
        Try
            Dim frm As New frmPlanillaViaticoAprobar
            frm.IdPlanilla = IdPlanilla
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Desactivar()
                ObtenerRegistro()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de Job")
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        If Len(Trim(txtNumJob.Text)) > 0 Then
            If Not (oJobService.Buscar(txtNumJob.Text)) Then
                MsgBox("Número de Job no existente, Verifique")
                txtNumJob.Text = ""
                txtNumJob.Focus()
            End If
        Else
            MsgBox("Ingrese un N° de Job")
        End If
    End Sub

    Private Sub biAtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.Click
        Try
            If Session.CodPerfil = "01" Or Session.CodPerfil = "30" Then
                If MsgBox("¿Está seguro de ATENDER la Planilla de Viático N° " & IdPlanilla & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPlanillaViaticoService.Atender(IdPlanilla, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Atendió la Planilla de Viático Correctamente")
                        'Actualizar()
                        Desactivar()
                        ObtenerRegistro()
                        enableOpciones()
                    End If
                End If
            Else
                MsgBox("Usted no tiene permiso para atender las planillas,Tenga cuidado...")
            End If
        Catch ex As Exception
            MsgBox("Error al atender planilla : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbMovilidad_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMovilidad.CheckedChanged, rbRefrigerio.CheckedChanged
        'If Not state_button Then
        cmbSubRubro.DataSource = Nothing
        LlenarSubRubro()
        If rbMovilidad.Checked Then
            cmbSubRubro.Value = "008"
        Else
            cmbSubRubro.Value = "007"
        End If
        'End If
    End Sub

End Class