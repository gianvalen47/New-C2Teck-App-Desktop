Imports System.ServiceModel
Public Class frmProvisional_Nuevo

    '===========================Servicios====================================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private Persona As New PersonaService.Persona
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    Public iEstado As Integer
    Public IdProvisional As Integer
    Public IdPersonaSolicita As Integer
    Public iUbicacion As Integer
    Public iViatico As Boolean
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMonedas As DataTable
    Private dtUbicacion As DataTable
    Private dtDetalles As DataTable
    Private dtDestino As DataTable
    Private dtTipo As DataTable

    Private Sub frmComProvisional_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbDetalles.Visible = True
            gbEstado.Visible = True
            Me.Text = "PROVISIONAL Nº " + Chr(34) + txtIdProvisional.Text.ToString + Chr(34)
            listaDatos()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(723, 385)
            gbDetalles.Visible = False
            gbEstado.Visible = False
            Me.Text = "Registrar nuevo Provisional"
            'cbViatico.Checked = True
            activar()
            ObtenerSolicitante()
            'txtFecha.Select()
            cmbMoneda.Value = "NS"
            cmbTipo.Value = 1
            'cmbDestinoViaje.Focus()
            cmbDestinoViaje.Select()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       txtPersonaSolicita.KeyPress _
                       , txtFecha.KeyPress _
                       , cmbUbicacion.KeyPress _
                      , cmbMoneda.KeyPress _
                      , txtNumJob.KeyPress _
                      , txtTotalEntrega.KeyPress _
                      , cmbDestinoViaje.KeyPress _
                      , cmbTipo.KeyPress _
 _
                      , txtFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComProvisional_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
            oJobService.Close()
            oEmpresaUsuario.Close()
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
            oEmpresaUsuario.Abort()
            oSolicitudGastoDetService.Close()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
            oEmpresaUsuario.Abort()
            oSolicitudGastoDetService.Close()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

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

            '======================================= DESTINOS ==============================================
            dtDestino = oSolicitudGastoDetService.MostrarDestinos.Tables(0)
            dtDestino.Rows.InsertAt(getRowTodos(dtDestino), 0)
            cmbDestinoViaje.DataSource = dtDestino
            cmbDestinoViaje.DropDownList.DataMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.DropDownList.DisplayMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.DropDownList.ValueMember = dtDestino.Columns("IdDestino").ToString
            cmbDestinoViaje.DropDownList.Columns(0).DataMember = dtDestino.Columns("IdDestino").ToString
            cmbDestinoViaje.DropDownList.Columns(1).DataMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.SelectedIndex = 0
            dtDestino = Nothing

            '======================================= TIPO ================================================
            dtTipo = oProvisionalService.MostrarTipo().Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub ObtenerSolicitante()


        Dim usuario As New EmpresaUsuarioService.EmpresaUsuario
        usuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)

        'Dim usuario As New SeguridadService.Usuario
        'usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersonaSolicita = usuario.Persona.IdPer
        txtPersonaSolicita.Text = usuario.Persona.ApeNom
        'Se agrega el perfil 38 Jefe de Operaciones Foráneas
        btnBuscarPersonaS.Enabled = IIf(Session.CodPerfil = "01" Or Session.CodPerfil = "13" Or Session.CodPerfil = "31" Or Session.CodPerfil = "24" Or Session.CodPerfil = "14" Or Session.CodPerfil = "57" Or Session.CodPerfil = "42" _
                                                        Or Session.CodPerfil = "02" Or Session.CodPerfil = "17" Or Session.CodPerfil = "30" Or Session.CodPerfil = "32" Or Session.CodPerfil = "12" _
                                                        Or Session.CodPerfil = "34" Or Session.CodPerfil = "15" Or Session.CodPerfil = "38" Or Session.CodPerfil = "39", True, False) '--Se agrega el perfil 39 a pedido de Jacky 25/07/2018
    End Sub

    Private Sub enableOpciones()
        biEditarr.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion
        If state_button Then
            iEstado = oProvisionalService.ObtenerEstado(IdProvisional)
            biAprobar.Enabled = IIf(iEstado = 2, True, False)
            cmOpciones.Enabled = IIf((iEstado = 5) Or (iEstado = 1), True, False)
        Else
            biAprobar.Enabled = False
            cmOpciones.Enabled = False
        End If
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
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbUbicacion.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        End If
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

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbUbicacion.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub


    Private Sub activar()
        If state_button Then   'Actualizar
            txtIdProvisional.ReadOnly = True
            txtIdProvisional.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            'cbViatico.Enabled = True
            cmbTipo.ReadOnly = False
            cmbTipo.BackColor = System.Drawing.SystemColors.Window
            btnBuscarPersonaS.Enabled = False
            cmbDestinoViaje.ReadOnly = True
            cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
            txtFecInicio.ReadOnly = True
            txtFecInicio.BackColor = System.Drawing.SystemColors.Control
            txtFecFinal.ReadOnly = True
            txtFecFinal.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            cmbUbicacion.ReadOnly = True
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            'txtTotalEntrega.ReadOnly = False
            'txtTotalEntrega.BackColor = System.Drawing.SystemColors.Window
            txtTotalEntrega.ReadOnly = True
            txtTotalEntrega.BackColor = System.Drawing.SystemColors.Control
            txtMotivo.ReadOnly = False
            txtMotivo.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else                      'Nuevo
            txtIdProvisional.ReadOnly = True
            txtIdProvisional.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            'cbViatico.Enabled = True
            cmbTipo.ReadOnly = False
            cmbTipo.BackColor = System.Drawing.SystemColors.Window
            cmbTipo.Enabled = True
            btnBuscarPersonaS.Enabled = True
            cmbDestinoViaje.ReadOnly = False
            cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Window
            txtFecInicio.ReadOnly = False
            txtFecInicio.BackColor = System.Drawing.SystemColors.Window
            txtFecFinal.ReadOnly = False
            txtFecFinal.BackColor = System.Drawing.SystemColors.Window

            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            'txtTotalEntrega.ReadOnly = False
            'txtTotalEntrega.BackColor = System.Drawing.SystemColors.Window
            txtTotalEntrega.ReadOnly = True
            txtTotalEntrega.BackColor = System.Drawing.SystemColors.Control
            txtMotivo.ReadOnly = False
            txtMotivo.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtIdProvisional.ReadOnly = True
        txtIdProvisional.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        'cbViatico.Enabled = False
        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersonaS.Enabled = False
        cmbDestinoViaje.ReadOnly = True
        cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
        txtFecInicio.ReadOnly = True
        txtFecInicio.BackColor = System.Drawing.SystemColors.Control
        txtFecFinal.ReadOnly = True
        txtFecFinal.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtTotalEntrega.ReadOnly = True
        txtTotalEntrega.BackColor = System.Drawing.SystemColors.Control
        txtMotivo.ReadOnly = True
        txtMotivo.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        txtFecha.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toNumber(IdPersonaSolicita) = 0 Then
                MsgBox("Debe Ingresar la Persona que Solicita la Orden ", MsgBoxStyle.Information, "Información")
                btnBuscarPersonaS.Focus()
                Return False
            ElseIf toBlank(cmbArea.Value) = "" Then
                MsgBox("Debe de Ingresar la Unidad de Negocio.", MsgBoxStyle.Information, "Información")
                cmbArea.Focus()
                Return False
            ElseIf toBlank(cmbUbicacion.Value) = "" Then
                MsgBox("Debe de Ingresar la Ubicación.", MsgBoxStyle.Information, "Información")
                cmbUbicacion.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'Comentado por el cambio de Provisional x detalles
                'ElseIf toDouble(txtTotalEntrega.Value) <= 0 Then
                '    MsgBox("El Monto Entregado debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                '    txtTotalEntrega.Focus()
                '    Return False
            ElseIf cmbDestinoViaje.SelectedIndex = 0 Then
                MsgBox("Debe ingresar el Destino de Viaje", MsgBoxStyle.Information, "Información")
                cmbDestinoViaje.Focus()
                Return False
            ElseIf toBlank(txtFecInicio.Text) = "" Then 'Se valida que la fecha del gasto sea obligatoria en cualquier caso
                MsgBox("Debe Ingresar la fecha Inicio del Viaje.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf toBlank(txtFecFinal.Text) = "" Then 'Se valida que la fecha del gasto sea obligatoria en cualquier caso
                MsgBox("Debe Ingresar la fecha Final del Viaje.", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
                Return False
            ElseIf txtMotivo.Text = "" Then
                MsgBox("Debe de Ingresar el Motivo.", MsgBoxStyle.Information, "Información")
                txtMotivo.Focus()
                Return False
            ElseIf txtFecInicio.Value > txtFecFinal.Value Then
                MsgBox("La Fecha de inicio no puede ser mayor a la Fecha final")
                txtFecInicio.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ProvisionalService.Provisional
            registro = oProvisionalService.Obtener(IdProvisional)

            IdProvisional = registro.IdProvisional
            txtIdProvisional.Text = registro.IdProvisional
            txtFecha.Value = registro.Fecha
            lblEstado.Text = registro.EstadosProvisional.DesEstado
            IdPersonaSolicita = registro.Persona.IdPer
            'cbViatico.Checked = registro.Viatico
            cmbTipo.Value = registro.TipoProvisional.IdTipo
            txtPersonaSolicita.Text = registro.Persona.ApeNom
            cmbDestinoViaje.Value = registro.DestinoViaje.IdDestino
            'txtFecInicio.Value = registro.FecInicio
            If Not (registro.FecInicio.ToString = "") Then
                txtFecInicio.Value = CDate(registro.FecInicio)
                txtFecInicio.Text = registro.FecInicio.ToString
            End If
            'txtFecFinal.Value = registro.FecFinal
            If Not (registro.FecFinal.ToString = "") Then
                txtFecFinal.Value = CDate(registro.FecFinal)
                txtFecFinal.Text = registro.FecFinal.ToString
            End If
            cmbArea.Value = registro.Area.CodArea
            cmbUbicacion.Value = registro.UbicacionCaja.IdUbicacion
            cmbMoneda.Value = registro.Moneda.CodMon
            txtNumJob.Text = registro.Job.CodJob
            txtSaldoFavor.Value = registro.SaldoFavor
            txtObservacion.Text = registro.Observacion
            txtTotalEntrega.Value = registro.TotEntrega
            txtTotalDevuelto.Value = registro.TotDevuelto
            txtMotivo.Text = registro.Motivo
            'If registro.SolicitudGasto.IdGasto = Nothing Then
            '    txtGasto.Text = ""
            'Else
            'txtGasto.Text = registro.SolicitudGasto.IdGasto
            'End If
            Me.Text = "Provisional Nº " + registro.IdProvisional.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ProvisionalService.Provisional)
        Try
            Dim estado_process As Integer
            estado_process = oProvisionalService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdProvisional = estado_process
                iUbicacion = toNumber(cmbUbicacion.Value)
                'iViatico = cbViatico.Checked
                MsgBox("Se insertó el Provisional Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PROVISIONAL : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ProvisionalService.Provisional)
        Try
            Dim estado_process As Boolean
            estado_process = oProvisionalService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Provisional Correctamente")
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PROVISIONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oProvisionalService.Borrar(IdProvisional, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PROVISIONAL : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersonaSolicita_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersonaSolicita = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                    'cmbUbicacion.Focus()
                    cmbDestinoViaje.Focus()
                Else
                    IdPersonaSolicita = 0
                    txtPersonaSolicita.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New ProvisionalService.Provisional
                    Dim Solicitante As New ProvisionalService.Persona
                    Dim Area As New ProvisionalService.Area
                    Dim Ubicacion As New ProvisionalService.UbicacionCaja
                    Dim Moneda As New ProvisionalService.Moneda
                    Dim Estado As New ProvisionalService.EstadosProvisional
                    Dim destino As New ProvisionalService.DestinosViaje
                    Dim tipoprovisional As New ProvisionalService.TipoProvisional
                    Dim Job As New ProvisionalService.Job

                    registro.IdProvisional = IdProvisional
                    registro.Fecha = txtFecha.Value
                    Solicitante.IdPer = IdPersonaSolicita
                    registro.Persona = Solicitante
                    Area.CodArea = cmbArea.Value
                    registro.Area = Area
                    destino.IdDestino = cmbDestinoViaje.Value
                    registro.DestinoViaje = destino
                    registro.FecInicio = txtFecInicio.Value
                    registro.FecFinal = txtFecFinal.Value
                    Ubicacion.IdUbicacion = cmbUbicacion.Value
                    Job.CodJob = toNull(txtNumJob.Text)
                    registro.Job = Job
                    registro.UbicacionCaja = Ubicacion
                    Moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = Moneda
                    registro.SaldoFavor = txtSaldoFavor.Value
                    'registro.Viatico = cbViatico.Checked
                    tipoprovisional.IdTipo = cmbTipo.Value
                    registro.TipoProvisional = tipoprovisional
                    registro.Observacion = txtObservacion.Text
                    registro.TotEntrega = txtTotalEntrega.Value
                    registro.TotDevuelto = txtTotalDevuelto.Value
                    registro.Motivo = txtMotivo.Text
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu
                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Estado.IdEstado = 1
                        registro.EstadosProvisional = Estado
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR PROVISIONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
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

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub txtPersonaSolicita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonaSolicita.TextChanged
        If state_button = False Then
            Persona = oPersonaService.Obtener(IdPersonaSolicita)
            cmbArea.Value = Persona.CentroCosto.Area.CodArea
        End If
    End Sub

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaSolicita.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersonaS.Enabled = True Then
                e.Handled = True
                btnBuscarPersonaSolicita_Click(sender, e)
            End If
        End If
    End Sub

    'Private Sub txtMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        txtFecha.Focus()
    '    End If
    'End Sub

    Private Sub cbViatico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If state_button Then
            If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
                e.Handled = True
                cmbMoneda.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click
        Try
            Dim frm As New frmProvisional_Aprobar
            frm.IdProvisional = toNumber(txtIdProvisional.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click

        NuevoDetalle()

    End Sub

    Private Sub NuevoDetalle()

        Try
            Dim frm As New frmProvisional_NuevoDetalle
            frm.IdProvisional = IdProvisional
            frm.state_button = False

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdProvisionalDet)
                    'Mostrar()
                    ObtenerRegistro()
                    actualizarDetalles()
                End If
                enableOpciones()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdProvisionalDet").Text
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdProvisionalDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub mostrarDetalle()

        Try
            Dim frm As New frmProvisional_NuevoDetalle
            frm.state_button = True
            frm.IdProvisionalDet = dgvDatos.CurrentRow.Cells("IdProvisionalDet").Text
            frm.IdProvisional = IdProvisional

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdProvisionalDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdProvisionalDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            Dim estadodet As Integer

            estadodet = oProvisionalService.ObtenerEstadoDetalle(toNumber(dgvDatos.CurrentRow.Cells("IdProvisionalDet").Value))

            If estadodet = 1 Then
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oProvisionalService.BorrarDetalle(toNumber(dgvDatos.CurrentRow.Cells("IdProvisionalDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        ObtenerRegistro()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                Else
                End If
            Else
                MsgBox("No se puede Eliminar porque no esta en estado GENERADO", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub listaDatos()
        Try

            dtDetalles = oProvisionalService.MostrarDetalle(toNumber(IdProvisional)).Tables(0)
            dgvDatos.DataSource = dtDetalles

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub


    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    'Private Sub cmbDestinoViaje_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDestinoViaje.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        txtFecInicio.Focus()
    '    End If
    'End Sub

    'Private Sub txtFecInicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecInicio.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        txtFecFinal.Focus()
    '    End If
    'End Sub

End Class