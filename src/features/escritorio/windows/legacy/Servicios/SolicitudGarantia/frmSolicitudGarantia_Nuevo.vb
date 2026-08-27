Imports System.ServiceModel
Public Class frmSolicitudGarantia_Nuevo

    '===========================Servicios====================================================
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient
    Private oSolicitudGarantiaAtencionService As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient  
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oJobService As New JobService.JobServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    Public iEstado As Integer
    Public IdAfa As Integer
    Public IdCliente As Integer
    Public IdTecnico As Integer
    Private dtDatos As DataTable
    Private dtSupervisor As DataTable
    Private dtJefe As DataTable
    Private dtContacto As DataTable
    Private dtAplicacion As DataTable
    Private dtUnidad As DataTable

    Private Sub frmSolicitudGarantia_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "FORMATO DE ORDEN DE REPARACIÓN Nº " + Chr(34) + txtIdAfa.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both          
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(1032, 649)
            gbEstado.Visible = False
            gbDetalle.Visible = False
            Me.Text = "Registrar nuevo Formato de Orden de Reparación"
            activar()
        End If
    End Sub

    Private Sub txtTecnico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTecnico.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtIdAfa.KeyPress _
                  , txtNumJob.KeyPress _
                  , txtHorasViajeIdaVuelta.KeyPress _
                  , txtDistanciaKm.KeyPress _
                  , txtLugarServicio.KeyPress _
                  , cmbSupervisor.KeyPress _
                  , txtTecnico.KeyPress _
                  , txtCliente.KeyPress _
                  , txtEmailCliente.KeyPress _
                  , cmbContactoCliente.KeyPress _
                  , txtSerieMotor.KeyPress _
                  , txtModMotor.KeyPress _
                  , cmbAplicacion.KeyPress _
                  , txtSerieVehiculo.KeyPress _
                  , txtMarcaEquipo.KeyPress _
                  , txtModeloEquipo.KeyPress _
                  , txtFecArranqueInicial.KeyPress _
                  , txtFecReparacionGarantia.KeyPress _
                  , txtDiasServTotales.KeyPress _
                  , txtHorasTotalMotor.KeyPress _
                  , cmbUnidad.KeyPress _
                  , txtFecUltRepPzaFallada.KeyPress _
                  , txtDiasServicioPzaFallada.KeyPress _
                  , txtHorasUltRepPzaFallada.KeyPress _
                  , txtDescPzaPrimaria.KeyPress _
                  , cbRepuestos.KeyPress _
                  , cbCores.KeyPress _
                  , txtPartePzaPrimaria.KeyPress _
                  , txtOT.KeyPress _
                  , txtVale.KeyPress _
                  , txtFacturaImportacionAlm.KeyPress _
                  , txtPedidoAlm.KeyPress _
                  , txtFecLlegadaAlm.KeyPress _
                  , txtSeriePiezaPrimaria.KeyPress _
                  , txtCantPzaPrimaria.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmSolicitudGarantia_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGarantiaService.Close()
            oSolicitudGarantiaAtencionService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oJobService.Close()
            oClienteService.Close()
            oMercaderiaService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantiaService.Abort()
            oSolicitudGarantiaAtencionService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
            oClienteService.Abort()
            oMercaderiaService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaService.Abort()
            oSolicitudGarantiaAtencionService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
            oClienteService.Abort()
            oMercaderiaService.Abort()
            oCotizacionServicioService.Abort()
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
            fila(1) = ""
        Catch ex As Exception
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
        End Try
        Try
            fila(3) = ""
        Catch ex As Exception
        End Try
        Try
            fila(4) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
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

            '======================================== SUPERVISOR =============================================           
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            ''======================================== JEFE =============================================           
            'dtJefe = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            'dtJefe.Rows.InsertAt(getRowTodos(dtJefe), 0)
            'cmbJefe.DataSource = dtJefe
            'cmbJefe.DropDownList.DataMember = dtJefe.Columns("AbrPer").ToString
            'cmbJefe.DropDownList.DisplayMember = dtJefe.Columns("AbrPer").ToString
            'cmbJefe.DropDownList.ValueMember = dtJefe.Columns("IdPer").ToString
            'cmbJefe.DropDownList.Columns(0).DataMember = dtJefe.Columns("IdPer").ToString
            'cmbJefe.DropDownList.Columns(1).DataMember = dtJefe.Columns("AbrPer").ToString
            'cmbJefe.SelectedIndex = 0
            'dtJefe = Nothing

            '=======================================APLICACION ===============================================
            dtAplicacion = oJobService.MostrarAplicacionMotor.Tables(0)
            dtAplicacion.Rows.InsertAt(getRowTodos1(dtAplicacion), 0)
            cmbAplicacion.DataSource = dtAplicacion
            cmbAplicacion.DropDownList.DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.DisplayMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.ValueMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(0).DataMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(1).DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            dtAplicacion = Nothing

            '======================================= UNIDAD  ==================================================
            dtUnidad = oSolicitudGarantiaService.MostrarUnidad.Tables(0)
            'dtUnidad.Rows.InsertAt(getRowTodos1(dtUnidad), 0)
            cmbUnidad.DataSource = dtUnidad
            cmbUnidad.DropDownList.DataMember = dtUnidad.Columns("Nombre").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidad.Columns("Nombre").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidad.Columns("CodUniMed").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidad.Columns("CodUniMed").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidad.Columns("Nombre").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidad = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarContactos()
        Try
            cmbContactoCliente.DataSource = Nothing
            cmbContactoCliente.Text = ""
            cmbContactoCliente.Value = ""
            dtContacto = oContactoService.Mostrar(IdCliente).Tables(0)
            If dtContacto.Rows.Count <> 0 Then
                '===================================== CONTACTOS ==============================================
                cmbContactoCliente.DataSource = dtContacto
                cmbContactoCliente.DropDownList.DataMember = dtContacto.Columns("Apellidos").ToString
                cmbContactoCliente.DropDownList.DisplayMember = dtContacto.Columns("Apellidos").ToString
                cmbContactoCliente.DropDownList.ValueMember = dtContacto.Columns("IdContacto").ToString
                cmbContactoCliente.DropDownList.Columns(0).DataMember = dtContacto.Columns("IdContacto").ToString
                cmbContactoCliente.DropDownList.Columns(1).DataMember = dtContacto.Columns("Apellidos").ToString
                cmbContactoCliente.DropDownList.Columns(2).DataMember = dtContacto.Columns("Nombres").ToString
                dtContacto = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS CONTACTOS" + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            Dim permiso As Boolean = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "26" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17" Or Session.CodPerfil = "14" Or Session.CodPerfil = "57"), True, False)
            iEstado = oSolicitudGarantiaService.Estado(IdAfa)
            If dgvDatos.RowCount < 1 Then
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miRechazar.Enabled = False
                miAtender.Enabled = False
                miActualizarEstado.Enabled = False
            Else
                Dim Rechazado As Boolean = toBoolean(dgvDatos.CurrentRow.Cells("Rechazado").Value)
                Dim Atendido As Boolean = toBoolean(dgvDatos.CurrentRow.Cells("Atendido").Value)
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(permiso And (Rechazado = False And Atendido = False), True, False)
                miAtender.Enabled = IIf(permiso And (iEstado <> 1 And iEstado <> 2) And (Rechazado = False And Atendido = False), True, False)
                miRechazar.Enabled = IIf(permiso And (iEstado <> 1 And iEstado <> 2) And (Rechazado = False And Atendido = False), True, False)
                miActualizarEstado.Enabled = IIf(permiso And (iEstado = 4 Or iEstado = 5), True, False)  'Se valida que el AFA este en estado Atendido ó Rechazado y que el usuario tenga permiso
            End If
            editable = True  'IIf(iEstado <> 1, True, False)
            miNuevo.Enabled = IIf(editable And permiso, True, False)
            biEditar.Enabled = IIf(iEstado = 1 Or iEstado = 0, Not edicion, False)
            biSalir.Enabled = Not edicion
            biGuardar.Enabled = IIf(iEstado = 1 Or iEstado = 0, True, False)
            biDeshacer.Enabled = edicion
            biEnviar.Enabled = IIf(iEstado = 1 Or iEstado = 0, Not edicion, False)
            cmOpciones.Enabled = IIf(editable And lblEstado.Text <> "", Not edicion, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES" + ex.Message)
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
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    ObtenerDatosJob()
                End If
            Else
                txtNumJob.Focus()
            End If
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                    ObtenerDatosJob()
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
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    ObtenerDatosJob()
                End If
            Else
                txtNumJob.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerDatosJob()
        Try
            Dim registro As New JobService.Job
            registro = oJobService.Obtener(txtNumJob.Text)
            cmbSupervisor.Value = registro.PersonaDelegado.IdPer
            IdCliente = registro.ClienteBeneficiado.IdCliente
            txtCliente.Text = registro.ClienteBeneficiado.DesCli
            ListarContactos()
            txtSerieMotor.Text = registro.CodMer
            txtModMotor.Text = registro.ModMer
            cmbAplicacion.Value = registro.TipoAplicacionMotor.CodAplicacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS DE LA OT : " + ex.Message)
        End Try     
    End Sub

    Private Sub activar()
        If state_button Then   'Actualizar
            txtIdAfa.ReadOnly = True
            txtIdAfa.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            txtHorasViajeIdaVuelta.ReadOnly = False
            txtHorasViajeIdaVuelta.BackColor = System.Drawing.SystemColors.Window
            txtDistanciaKm.ReadOnly = False
            txtDistanciaKm.BackColor = System.Drawing.SystemColors.Window
            txtLugarServicio.ReadOnly = False
            txtLugarServicio.BackColor = System.Drawing.SystemColors.Window
            cmbSupervisor.ReadOnly = True
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = True
            'cmbJefe.ReadOnly = True
            'cmbJefe.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCliente.Enabled = True
            cmbContactoCliente.ReadOnly = False
            cmbContactoCliente.BackColor = System.Drawing.SystemColors.Window
            btnAgregarContacto.Enabled = True
            txtSerieMotor.ReadOnly = False
            txtSerieMotor.BackColor = System.Drawing.SystemColors.Window
            btnBuscarMercaderia.Enabled = True
            txtModMotor.ReadOnly = False
            txtModMotor.BackColor = System.Drawing.SystemColors.Window
            cmbAplicacion.ReadOnly = False
            cmbAplicacion.BackColor = System.Drawing.SystemColors.Window
            txtSerieVehiculo.ReadOnly = False
            txtSerieVehiculo.BackColor = System.Drawing.SystemColors.Window
            txtMarcaEquipo.ReadOnly = False
            txtMarcaEquipo.BackColor = System.Drawing.SystemColors.Window
            txtModeloEquipo.ReadOnly = False
            txtModeloEquipo.BackColor = System.Drawing.SystemColors.Window
            txtFecArranqueInicial.ReadOnly = False
            txtFecArranqueInicial.BackColor = System.Drawing.SystemColors.Window
            txtFecReparacionGarantia.ReadOnly = False
            txtFecReparacionGarantia.BackColor = System.Drawing.SystemColors.Window
            txtDiasServTotales.ReadOnly = False
            txtDiasServTotales.BackColor = System.Drawing.SystemColors.Window
            txtHorasTotalMotor.ReadOnly = False
            txtHorasTotalMotor.BackColor = System.Drawing.SystemColors.Window
            cmbUnidad.ReadOnly = False
            cmbUnidad.BackColor = System.Drawing.SystemColors.Window
            txtFecUltRepPzaFallada.ReadOnly = False
            txtFecUltRepPzaFallada.BackColor = System.Drawing.SystemColors.Window
            txtDiasServicioPzaFallada.ReadOnly = False
            txtDiasServicioPzaFallada.BackColor = System.Drawing.SystemColors.Window
            txtHorasUltRepPzaFallada.ReadOnly = False
            txtHorasUltRepPzaFallada.BackColor = System.Drawing.SystemColors.Window
            txtDescPzaPrimaria.ReadOnly = False
            txtDescPzaPrimaria.BackColor = System.Drawing.SystemColors.Window
            txtPartePzaPrimaria.ReadOnly = False
            txtPartePzaPrimaria.BackColor = System.Drawing.SystemColors.Window
            cbRepuestos.Enabled = True
            cbCores.Enabled = True
            txtQuejaDemandaProblema.ReadOnly = False
            txtQuejaDemandaProblema.BackColor = System.Drawing.SystemColors.Window
            btnQueja.Enabled = True
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            btnCausa.Enabled = True
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            btnCorreccion.Enabled = True
            txtComentarios.ReadOnly = False
            txtComentarios.BackColor = System.Drawing.SystemColors.Window
            btnComentarios.Enabled = True

            'Agregado nuevo formato de AFA
            txtOT.ReadOnly = False
            txtOT.BackColor = System.Drawing.SystemColors.Window
            txtVale.ReadOnly = False
            txtVale.BackColor = System.Drawing.SystemColors.Window
            txtSeriePiezaPrimaria.ReadOnly = False
            txtSeriePiezaPrimaria.BackColor = System.Drawing.SystemColors.Window
            txtCantPzaPrimaria.ReadOnly = False
            txtCantPzaPrimaria.BackColor = System.Drawing.SystemColors.Window
            txtFacturaImportacionAlm.ReadOnly = False
            txtFacturaImportacionAlm.BackColor = System.Drawing.SystemColors.Window
            txtPedidoAlm.ReadOnly = False
            txtPedidoAlm.BackColor = System.Drawing.SystemColors.Window
            txtFecLlegadaAlm.ReadOnly = False
            txtFecLlegadaAlm.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtIdAfa.Focus()
        Else                      'Nuevo
            txtIdAfa.ReadOnly = True
            txtIdAfa.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.ReadOnly = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Window
            btnBuscarJob.Enabled = True
            txtHorasViajeIdaVuelta.ReadOnly = False
            txtHorasViajeIdaVuelta.BackColor = System.Drawing.SystemColors.Window
            txtDistanciaKm.ReadOnly = False
            txtDistanciaKm.BackColor = System.Drawing.SystemColors.Window
            txtLugarServicio.ReadOnly = False
            txtLugarServicio.BackColor = System.Drawing.SystemColors.Window
            cmbSupervisor.ReadOnly = False
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Window
            btnBuscarPersona.Enabled = True
            'cmbJefe.ReadOnly = False
            'cmbJefe.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            cmbContactoCliente.ReadOnly = False
            cmbContactoCliente.BackColor = System.Drawing.SystemColors.Window
            btnAgregarContacto.Enabled = True
            txtSerieMotor.ReadOnly = False
            txtSerieMotor.BackColor = System.Drawing.SystemColors.Window
            btnBuscarMercaderia.Enabled = True
            txtModMotor.ReadOnly = False
            txtModMotor.BackColor = System.Drawing.SystemColors.Window
            cmbAplicacion.ReadOnly = False
            cmbAplicacion.BackColor = System.Drawing.SystemColors.Window
            txtSerieVehiculo.ReadOnly = False
            txtSerieVehiculo.BackColor = System.Drawing.SystemColors.Window
            txtMarcaEquipo.ReadOnly = False
            txtMarcaEquipo.BackColor = System.Drawing.SystemColors.Window
            txtModeloEquipo.ReadOnly = False
            txtModeloEquipo.BackColor = System.Drawing.SystemColors.Window
            txtFecArranqueInicial.ReadOnly = False
            txtFecArranqueInicial.BackColor = System.Drawing.SystemColors.Window
            txtFecReparacionGarantia.ReadOnly = False
            txtFecReparacionGarantia.BackColor = System.Drawing.SystemColors.Window
            txtDiasServTotales.ReadOnly = False
            txtDiasServTotales.BackColor = System.Drawing.SystemColors.Window
            txtHorasTotalMotor.ReadOnly = False
            txtHorasTotalMotor.BackColor = System.Drawing.SystemColors.Window
            cmbUnidad.ReadOnly = False
            cmbUnidad.BackColor = System.Drawing.SystemColors.Window
            txtFecUltRepPzaFallada.ReadOnly = False
            txtFecUltRepPzaFallada.BackColor = System.Drawing.SystemColors.Window
            txtDiasServicioPzaFallada.ReadOnly = False
            txtDiasServicioPzaFallada.BackColor = System.Drawing.SystemColors.Window
            txtHorasUltRepPzaFallada.ReadOnly = False
            txtHorasUltRepPzaFallada.BackColor = System.Drawing.SystemColors.Window
            txtDescPzaPrimaria.ReadOnly = False
            txtDescPzaPrimaria.BackColor = System.Drawing.SystemColors.Window
            txtPartePzaPrimaria.ReadOnly = False
            txtPartePzaPrimaria.BackColor = System.Drawing.SystemColors.Window
            cbRepuestos.Enabled = True
            cbCores.Enabled = True
            txtQuejaDemandaProblema.ReadOnly = False
            txtQuejaDemandaProblema.BackColor = System.Drawing.SystemColors.Window
            btnQueja.Enabled = True
            txtCausa.ReadOnly = False
            txtCausa.BackColor = System.Drawing.SystemColors.Window
            btnCausa.Enabled = True
            txtCorreccion.ReadOnly = False
            txtCorreccion.BackColor = System.Drawing.SystemColors.Window
            btnCorreccion.Enabled = True
            txtComentarios.ReadOnly = False
            txtComentarios.BackColor = System.Drawing.SystemColors.Window
            btnComentarios.Enabled = True

            'Agregado nuevo formato de AFA
            txtOT.ReadOnly = False
            txtOT.BackColor = System.Drawing.SystemColors.Window
            txtVale.ReadOnly = False
            txtVale.BackColor = System.Drawing.SystemColors.Window
            txtSeriePiezaPrimaria.ReadOnly = False
            txtSeriePiezaPrimaria.BackColor = System.Drawing.SystemColors.Window
            txtCantPzaPrimaria.ReadOnly = False
            txtCantPzaPrimaria.BackColor = System.Drawing.SystemColors.Window
            txtFacturaImportacionAlm.ReadOnly = False
            txtFacturaImportacionAlm.BackColor = System.Drawing.SystemColors.Window
            txtPedidoAlm.ReadOnly = False
            txtPedidoAlm.BackColor = System.Drawing.SystemColors.Window
            txtFecLlegadaAlm.ReadOnly = False
            txtFecLlegadaAlm.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtIdAfa.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtIdAfa.ReadOnly = True
        txtIdAfa.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        txtHorasViajeIdaVuelta.ReadOnly = True
        txtHorasViajeIdaVuelta.BackColor = System.Drawing.SystemColors.Control
        txtDistanciaKm.ReadOnly = True
        txtDistanciaKm.BackColor = System.Drawing.SystemColors.Control
        txtLugarServicio.ReadOnly = True
        txtLugarServicio.BackColor = System.Drawing.SystemColors.Control
        cmbSupervisor.ReadOnly = True
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersona.Enabled = False
        'cmbJefe.ReadOnly = True
        'cmbJefe.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        cmbContactoCliente.ReadOnly = True
        cmbContactoCliente.BackColor = System.Drawing.SystemColors.Control
        btnAgregarContacto.Enabled = False
        txtSerieMotor.ReadOnly = True
        txtSerieMotor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarMercaderia.Enabled = False
        txtModMotor.ReadOnly = True
        txtModMotor.BackColor = System.Drawing.SystemColors.Control
        cmbAplicacion.ReadOnly = True
        cmbAplicacion.BackColor = System.Drawing.SystemColors.Control
        txtSerieVehiculo.ReadOnly = True
        txtSerieVehiculo.BackColor = System.Drawing.SystemColors.Control
        txtMarcaEquipo.ReadOnly = True
        txtMarcaEquipo.BackColor = System.Drawing.SystemColors.Control
        txtModeloEquipo.ReadOnly = True
        txtModeloEquipo.BackColor = System.Drawing.SystemColors.Control
        txtFecArranqueInicial.ReadOnly = True
        txtFecArranqueInicial.BackColor = System.Drawing.SystemColors.Control
        txtFecReparacionGarantia.ReadOnly = True
        txtFecReparacionGarantia.BackColor = System.Drawing.SystemColors.Control
        txtDiasServTotales.ReadOnly = True
        txtDiasServTotales.BackColor = System.Drawing.SystemColors.Control
        txtHorasTotalMotor.ReadOnly = True
        txtHorasTotalMotor.BackColor = System.Drawing.SystemColors.Control
        cmbUnidad.ReadOnly = True
        cmbUnidad.BackColor = System.Drawing.SystemColors.Control
        txtFecUltRepPzaFallada.ReadOnly = True
        txtFecUltRepPzaFallada.BackColor = System.Drawing.SystemColors.Control
        txtDiasServicioPzaFallada.ReadOnly = True
        txtDiasServicioPzaFallada.BackColor = System.Drawing.SystemColors.Control
        txtHorasUltRepPzaFallada.ReadOnly = True
        txtHorasUltRepPzaFallada.BackColor = System.Drawing.SystemColors.Control
        txtDescPzaPrimaria.ReadOnly = True
        txtDescPzaPrimaria.BackColor = System.Drawing.SystemColors.Control
        txtPartePzaPrimaria.ReadOnly = True
        txtPartePzaPrimaria.BackColor = System.Drawing.SystemColors.Control
        cbRepuestos.Enabled = False
        cbCores.Enabled = False
        txtQuejaDemandaProblema.ReadOnly = True
        txtQuejaDemandaProblema.BackColor = System.Drawing.SystemColors.Control
        btnQueja.Enabled = False
        txtCausa.ReadOnly = True
        txtCausa.BackColor = System.Drawing.SystemColors.Control
        btnCausa.Enabled = False
        txtCorreccion.ReadOnly = True
        txtCorreccion.BackColor = System.Drawing.SystemColors.Control
        btnCorreccion.Enabled = False
        txtComentarios.ReadOnly = True
        txtComentarios.BackColor = System.Drawing.SystemColors.Control
        btnComentarios.Enabled = False

        'Agregado nuevo formato de AFA
        txtOT.ReadOnly = True
        txtOT.BackColor = System.Drawing.SystemColors.Control
        txtVale.ReadOnly = True
        txtVale.BackColor = System.Drawing.SystemColors.Control
        txtSeriePiezaPrimaria.ReadOnly = True
        txtSeriePiezaPrimaria.BackColor = System.Drawing.SystemColors.Control
        txtCantPzaPrimaria.ReadOnly = True
        txtCantPzaPrimaria.BackColor = System.Drawing.SystemColors.Control
        txtFacturaImportacionAlm.ReadOnly = True
        txtFacturaImportacionAlm.BackColor = System.Drawing.SystemColors.Control
        txtPedidoAlm.ReadOnly = True
        txtPedidoAlm.BackColor = System.Drawing.SystemColors.Control
        txtFecLlegadaAlm.ReadOnly = True
        txtFecLlegadaAlm.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        txtIdAfa.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumJob.Text) = "" Then
                MsgBox("Debe Ingresar el Número de OT.", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf oSolicitudGarantiaService.BuscarJob(txtNumJob.Text) And state_button = False Then
                MsgBox("Este Nro de OT ya ha sido ingresado en un Formato de Orden de Reparación. Tenga cuidado...!", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf toBlank(cmbSupervisor.Text) = "" Then
                MsgBox("Debe Ingresar el Supervisor ", MsgBoxStyle.Information, "Información")
                cmbSupervisor.Focus()
                Return False
            ElseIf IdTecnico = 0 Then
                MsgBox("Debe de Ingresar el Técnico.", MsgBoxStyle.Information, "Información")
                txtTecnico.Focus()
                Return False
                'ElseIf toBlank(cmbJefe.Text) = "" Then
                '    MsgBox("Debe Ingresar el Jefe ", MsgBoxStyle.Information, "Información")
                '    cmbJefe.Focus()
                '    Return False
            ElseIf IdCliente = 0 Then
                MsgBox("Debe de Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtSerieMotor.Text) = "" Then
                MsgBox("Debe de Ingresar la Serie del Motor.", MsgBoxStyle.Information, "Información")
                txtSerieMotor.Focus()
                Return False
            ElseIf toBlank(cmbAplicacion.Value) = "" Then
                MsgBox("Debe de Ingresar la Aplicación", MsgBoxStyle.Information, "Información")
                cmbAplicacion.Focus()
                Return False
            ElseIf toBlank(txtModMotor.Text) = "" Then
                MsgBox("Debe Ingresar el Modelo del Motor", MsgBoxStyle.Information, "Información")
                txtModMotor.Focus()
                Return False
            ElseIf txtQuejaDemandaProblema.Text = "" Then
                MsgBox("Debe de Ingresar el Problema.", MsgBoxStyle.Information, "Información")
                txtQuejaDemandaProblema.Focus()
                Return False
            ElseIf txtCausa.Text = "" Then
                MsgBox("Debe de Ingresar la Causa.", MsgBoxStyle.Information, "Información")
                txtCausa.Focus()
                Return False
            ElseIf txtCorreccion.Text = "" Then
                MsgBox("Debe de Ingresar la Corrección.", MsgBoxStyle.Information, "Información")
                txtCorreccion.Focus()
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
            Dim registro As SolicitudGarantiaService.SolicitudGarantia
            registro = oSolicitudGarantiaService.Obtener(IdAfa)

            IdAfa = registro.IdAfa
            txtIdAfa.Text = registro.IdAfa
            txtNumJob.Text = registro.Job.CodJob
            cmbSupervisor.Value = registro.PersonaSupervisor.IdPer
            IdTecnico = registro.PersonaTecnico.IdPer
            txtTecnico.Text = registro.PersonaTecnico.ApeNom
            'cmbJefe.Value = registro.personaJefe.IdPer
            IdCliente = registro.Cliente.IdCliente
            ListarContactos()
            txtCliente.Text = registro.Cliente.DesCli
            txtEmailCliente.Text = registro.Contacto.Email
            If registro.Contacto.IdContacto = 0 Or registro.Contacto.IdContacto = Nothing Or IsDBNull(registro.Contacto.IdContacto) Then
                cmbContactoCliente.SelectedIndex = 0
            Else
                cmbContactoCliente.Value = registro.Contacto.IdContacto
            End If

            txtSerieMotor.Text = registro.CodMer
            txtModMotor.Text = registro.ModMer
            cmbAplicacion.Value = registro.Aplicacion.CodAplicacion
            txtSerieVehiculo.Text = registro.SerieVehiculo
            txtMarcaEquipo.Text = registro.MarcaEquipo
            txtModeloEquipo.Text = registro.ModeloEquipo
            txtHorasViajeIdaVuelta.Value = registro.TotHorasViaje
            txtDistanciaKm.Value = registro.Distancia
            txtLugarServicio.Text = registro.LugarServicio

            If Not (registro.FecArranque.ToString = "") Then
                txtFecArranqueInicial.Value = CDate(registro.FecArranque)
                txtFecArranqueInicial.Text = registro.FecArranque.ToString
            End If

            If Not (registro.FecRepGarantia.ToString = "") Then
                txtFecReparacionGarantia.Value = CDate(registro.FecRepGarantia)
                txtFecReparacionGarantia.Text = registro.FecRepGarantia.ToString
            End If

            txtDiasServTotales.Value = registro.TotDiasServicio
            txtHorasTotalMotor.Value = registro.TotHorasMotor
            cmbUnidad.Value = registro.UnidadMedida.CodUniMed

            If Not (registro.FecMontaje.ToString = "") Then
                txtFecUltRepPzaFallada.Value = CDate(registro.FecMontaje)
                txtFecUltRepPzaFallada.Text = registro.FecMontaje.ToString
            End If

            txtDiasServicioPzaFallada.Value = registro.TotDiasMontaje
            txtHorasUltRepPzaFallada.Value = registro.TotHorasMontaje
            txtDescPzaPrimaria.Text = registro.DesPiezaPrimaria
            txtPartePzaPrimaria.Text = registro.CodPiezaPrimaria
            cbRepuestos.Checked = registro.Repuestos
            cbCores.Checked = registro.Cores
            txtQuejaDemandaProblema.Text = registro.DesProblema
            txtCausa.Text = registro.DesCausa
            txtCorreccion.Text = registro.DesCorreccion
            txtComentarios.Text = registro.Comentarios
            lblEstado.Text = registro.Estado.DesEstado

            'Agregado por nuevo formato de AFA
            txtOT.Text = registro.NumOrden
            txtVale.Text = registro.NumVale
            txtSeriePiezaPrimaria.Text = registro.NumSeriePieza
            txtCantPzaPrimaria.Text = registro.CantPieza
            txtFacturaImportacionAlm.Text = registro.NumFacturaImp
            txtPedidoAlm.Text = registro.NumPedido
            If Not (registro.FecLlegadaImp.ToString = "") Then
                txtFecLlegadaAlm.Value = CDate(registro.FecLlegadaImp)
                txtFecLlegadaAlm.Text = registro.FecLlegadaImp.ToString
            End If
            'txtFecLlegadaAlm.Value = registro.FecLlegadaImp

            Me.Text = "FORMATO DE OREDEN DE REPARACIÓN Nº " + registro.IdAfa.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudGarantiaService.SolicitudGarantia)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudGarantiaService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdAfa = estado_process
                MsgBox("Se insertó Formato de Orden de Reparación correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR FORMATO DE ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGarantiaService.SolicitudGarantia)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGarantiaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó Formato de Orden de Reparación correctamente")
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR FORMATO DE ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGarantiaService.Borrar(IdAfa, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR FORMATO DE ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New SolicitudGarantiaService.SolicitudGarantia
                    Dim Cliente As New SolicitudGarantiaService.Cliente
                    Dim Supervisor As New SolicitudGarantiaService.Persona
                    Dim Tecnico As New SolicitudGarantiaService.Persona
                    'Dim Jefe As New SolicitudGarantiaService.Persona
                    Dim Aplicacion As New SolicitudGarantiaService.TipoAplicacionMotor
                    Dim Estado As New SolicitudGarantiaService.EstadoSolicitudGarantia
                    Dim Job As New SolicitudGarantiaService.Job
                    Dim Contacto As New SolicitudGarantiaService.Contacto
                    Dim Unidad As New SolicitudGarantiaService.UnidadMedida

                    registro.IdAfa = IdAfa
                    Job.CodJob = txtNumJob.Text
                    registro.Job = Job
                    Supervisor.IdPer = cmbSupervisor.Value
                    registro.PersonaSupervisor = Supervisor
                    Tecnico.IdPer = IdTecnico
                    registro.PersonaTecnico = Tecnico
                    'Jefe.IdPer = cmbJefe.Value
                    'registro.PersonaJefe = Jefe

                    Cliente.IdCliente = IdCliente
                    Cliente.Email = txtEmailCliente.Text
                    registro.Cliente = Cliente

                    If cmbContactoCliente.Text = "" Then
                        Contacto.IdContacto = Nothing
                        registro.Contacto = Contacto
                    Else
                        Contacto.IdContacto = cmbContactoCliente.Value
                        registro.Contacto = Contacto
                    End If

                    registro.CodMer = txtSerieMotor.Text
                    registro.ModMer = txtModMotor.Text
                    Aplicacion.CodAplicacion = toNull(cmbAplicacion.Value)
                    registro.Aplicacion = Aplicacion
                    registro.SerieVehiculo = txtSerieVehiculo.Text
                    registro.MarcaEquipo = txtMarcaEquipo.Text
                    registro.ModeloEquipo = txtModeloEquipo.Text
                    registro.TotHorasViaje = txtHorasViajeIdaVuelta.Value
                    registro.Distancia = txtDistanciaKm.Value
                    registro.LugarServicio = txtLugarServicio.Text
                    registro.FecArranque = IIf(txtFecArranqueInicial.Text = "", Nothing, txtFecArranqueInicial.Value)
                    registro.FecRepGarantia = IIf(txtFecReparacionGarantia.Text = "", Nothing, txtFecReparacionGarantia.Value)
                    registro.TotDiasServicio = txtDiasServTotales.Value
                    registro.TotHorasMotor = txtHorasTotalMotor.Value
                    Unidad.CodUniMed = cmbUnidad.Value
                    registro.UnidadMedida = Unidad
                    registro.FecMontaje = IIf(txtFecUltRepPzaFallada.Text = "", Nothing, txtFecUltRepPzaFallada.Value)
                    registro.TotDiasMontaje = txtDiasServicioPzaFallada.Value
                    registro.TotHorasMontaje = txtHorasUltRepPzaFallada.Value
                    registro.DesPiezaPrimaria = txtDescPzaPrimaria.Text
                    registro.CodPiezaPrimaria = txtPartePzaPrimaria.Text
                    registro.Repuestos = cbRepuestos.Checked
                    registro.Cores = cbCores.Checked
                    registro.DesProblema = txtQuejaDemandaProblema.Text
                    registro.DesCausa = txtCausa.Text
                    registro.DesCorreccion = txtCorreccion.Text
                    registro.Comentarios = txtComentarios.Text

                    'Agregado para el nuevo formato AFA
                    registro.NumOrden = txtOT.Text
                    registro.NumVale = txtVale.Text
                    registro.NumFacturaImp = txtFacturaImportacionAlm.Text
                    registro.NumPedido = txtPedidoAlm.Text
                    registro.FecLlegadaImp = IIf(txtFecLlegadaAlm.Text = "", Nothing, txtFecLlegadaAlm.Value)
                    registro.NumSeriePieza = txtSeriePiezaPrimaria.Text
                    registro.CantPieza = txtCantPzaPrimaria.Text

                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Estado.IdEstado = 1
                        registro.Estado = Estado
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR FORMATO DE ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
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

    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                    ListarContactos()
                Else
                    txtCliente.Text = ""
                    IdCliente = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtBuscarCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Try
            Dim frm As New frmBuscarMotor
            'frm.CodRub = "04"
            frm.idcliente = IdCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                txtSerieMotor.Text = frm.codigo
                txtModMotor.Text = frm.modelo
            End If
            txtSerieMotor.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        'Try
        '    Dim frm As New frmBuscarMercaderia
        '    frm.CodRub = "04"
        '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '        txtSerieMotor.Text = frm.codigo
        '        txtModMotor.Text = frm.ModMer
        '    End If
        '    txtSerieMotor.Select()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            frm.codigoArea = "05"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdTecnico = frm.codigo
                    txtTecnico.Text = frm.descripcion
                    txtCliente.Focus()
                Else
                    IdTecnico = 0
                    txtTecnico.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdAfaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
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

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdAfaDet").Text
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

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdAfaDet").Text
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

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
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

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmSolicitudGarantia_Detalle
            frm.state_button = False
            frm.IdAfa = IdAfa
            frm.estado = 1
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            frm.editable = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "26" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17"), True, False)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdAfaDet)
                    mostrarDetalle()
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("NumClaim").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudGarantiaAtencionService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdAfaDet").Text), toNumber(txtIdAfa.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmSolicitudGarantia_Detalle
            frm.state_button = True
            frm.IdAfaDet = dgvDatos.CurrentRow.Cells("IdAfaDet").Text
            frm.IdAfa = IdAfa
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            frm.editable = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "26" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17"), True, False)
            frm.estado = oSolicitudGarantiaService.Estado(IdAfa)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdAfaDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            listaDatos()
            ObtenerRegistro()
            RowPossesion(dgvDatos, frm.IdAfaDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudGarantiaAtencionService.Mostrar(toNumber(txtIdAfa.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Dim estado As Integer
        estado = oSolicitudGarantiaService.Estado(toNumber(txtIdAfa.Text))
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub cmbContactoCliente_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbContactoCliente.ValueChanged
        If cmbContactoCliente.Text <> "" Then
            Dim registro As New ContactoService.Contacto
            registro = oContactoService.MostrarPorID(cmbContactoCliente.Value)
            txtEmailCliente.Text = registro.Email
        Else
            txtEmailCliente.Text = ""
        End If
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        Try
            If IdCliente > 0 Then
                Dim frm As New frmAgregarContacto
                frm.IdCliente = IdCliente
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ListarContactos()
                    cmbContactoCliente.Select()
                    cmbContactoCliente.DroppedDown = True
                End If
            Else
                MsgBox("Debe ingresar el Cliente")
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el contacto : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miRechazar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmSolicitudGarantia_Rechazar
                frm.IdAfa = dgvDatos.CurrentRow.Cells("IdAfa").Text
                frm.IdAfaDet = dgvDatos.CurrentRow.Cells("IdAfaDet").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                    ObtenerRegistro()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al RECHAZAR la Atención de Formato de Orden de Reparación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miAtender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAtender.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmSolicitudGarantia_Atender
                frm.IdAfa = dgvDatos.CurrentRow.Cells("IdAfa").Text
                frm.IdAfaDet = dgvDatos.CurrentRow.Cells("IdAfaDet").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                    ObtenerRegistro()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ATENDER la Atención de Formato de Orden de Reparación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbAplicacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAplicacion.ValueChanged
        If cmbAplicacion.Value = "T" Then
            gbMotor.Text = "Datos de Transmisión"
            lblTotal.Text = "Tot. Trans."
            cmbUnidad.Value = "KM"
        Else
            gbMotor.Text = "Datos de Motor"
            lblTotal.Text = "Tot. Motor"
            cmbUnidad.Value = "HRS"
        End If
    End Sub

    'Private Sub txtPartePzaPrimaria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartePzaPrimaria.KeyDown
    '    If oMercaderiaService.Buscar(txtPartePzaPrimaria.Text) = True Then

    '        Dim Mercaderia As New MercaderiaService.Mercaderia

    '        Mercaderia = oMercaderiaService.MostrarPorCodigo(txtPartePzaPrimaria.Text)

    '        txtPartePzaPrimaria.Text = Mercaderia.CodMer
    '        txtDescPzaPrimaria.Text = Mercaderia.DesMer1
    '        txtDescPzaPrimaria.Focus()
    '    Else
    '        MsgBox("Debe ingresar la descripción de la Pza")
    '        txtDescPzaPrimaria.Focus()
    '    End If
    'End Sub

    Private Sub btnQueja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQueja.Click
        Dim frm As New frmSolicitudGarantia_Observacion
        frm.Text = "Queja, demanda o problema :"
        frm.txtObservacion.Text = toBlank(txtQuejaDemandaProblema.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtQuejaDemandaProblema.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtQuejaDemandaProblema.Select()
    End Sub

    Private Sub btnCausa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCausa.Click
        Dim frm As New frmSolicitudGarantia_Observacion
        frm.Text = "Causa :"
        frm.txtObservacion.Text = toBlank(txtCausa.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCausa.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtCausa.Select()
    End Sub

    Private Sub btnCorreccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCorreccion.Click
        Dim frm As New frmSolicitudGarantia_Observacion
        frm.Text = "Corrección :"
        frm.txtObservacion.Text = toBlank(txtCorreccion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCorreccion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtCorreccion.Select()
    End Sub

    Private Sub btnComentarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComentarios.Click
        Dim frm As New frmSolicitudGarantia_Observacion
        frm.Text = "Comentarios :"
        frm.txtObservacion.Text = toBlank(txtComentarios.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtComentarios.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtComentarios.Select()
    End Sub

    Private Sub biEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.Click
        Try
            If txtIdAfa.Text <> "" Then
                If MsgBox("¿Está seguro de ENVIAR el Formato de Orden de Reparación N° " & txtIdAfa.Text + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oSolicitudGarantiaService.Enviar(CInt(txtIdAfa.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Envió el formato de Orden de Reparación correctamente")
                        ObtenerRegistro()
                        actualizar()
                        edicion = False
                        enableOpciones()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ENVIAR Formato DE ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtPartePzaPrimaria_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartePzaPrimaria.Validated
        Try
            If (iEstado = 1 Or iEstado = 0) And edicion And txtPartePzaPrimaria.Text <> "" Then
                If oMercaderiaService.Buscar(txtPartePzaPrimaria.Text, Session.sCodEmp) = True Then
                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia

                    Mercaderia = oMercaderiaService.Obtener(txtPartePzaPrimaria.Text, Session.sCodEmp)

                    txtPartePzaPrimaria.Text = Mercaderia.CodMer
                    txtDescPzaPrimaria.Text = Mercaderia.DesMer1
                    txtDescPzaPrimaria.Focus()
                Else
                    MsgBox("Debe ingresar la descripción de la Pza")
                    txtDescPzaPrimaria.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DSC DE LA PZA : " + ex.Message)
        End Try
    End Sub

    '-------------------------------------------------- ACTUALIZAR ESTADO DE AFA A RECLAMADO -------------------------------------------------------
    Private Sub miActualizarEstado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarEstado.Click
        Try
            Dim frm As New frmSolicitudGarantia_ActualizarEstado
            frm.Text = "Actualizar estado de la Orden de Reparación"
            frm.IdAfa = IdAfa
            frm.IdAfaDet = dgvDatos.CurrentRow.Cells("IdAfaDet").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
                listaDatos()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtFecArranqueInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFecArranqueInicial.ValueChanged, txtFecReparacionGarantia.ValueChanged
        Try
            If Len(txtFecArranqueInicial.Value) > 0 And Len(txtFecReparacionGarantia.Value) > 0 Then

                Dim DiasTrans As Integer
                DiasTrans = DateDiff(DateInterval.Day, txtFecArranqueInicial.Value, txtFecReparacionGarantia.Value)
                txtDiasServTotales.Text = CStr(DiasTrans)

            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class