Imports System.ServiceModel
Public Class frmReclamoCliente


    '===========================Servicios====================================================
    Private oReclamoClienteService As New ReclamoClienteService.ReclamoClienteServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient
    Private oMotorService As New MotorService.MotorServiceClient
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete

    Public IdReclamo As Integer
    Public IdCliente As Integer
    Private dtSupervisor As DataTable
    Private dtUnidad As DataTable
    Private iEstado As String

    Public iIdCliente As Integer = 0           'IdCliente de cliente seleccionado en la ventana anterior


    Private Sub frmReclamoCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()            
            ObtenerRegistro()
            Me.Text = "Reclamo de Cliente: " + Chr(34) + IdReclamo.ToString + Chr(34)
            txtCliente.TabStop = False
            txtLugarServicio.Focus()
        Else                                      'Nuevo
            Me.Text = "Registrar nuevo Reclamo de Cliente"
            activar()          
            txtLugarServicio.TabStop = True
            txtLugarServicio.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmReclamoCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oReclamoClienteService.Close()
            oCotizacionServicioService.Close()
            oSolicitudGarantiaService.Close()
            oMotorService.Close()
        Catch ex As TimeoutException
            oReclamoClienteService.Abort()
            oCotizacionServicioService.Abort()
            oSolicitudGarantiaService.Abort()
            oMotorService.Abort()
        Catch ex As CommunicationException
            oReclamoClienteService.Abort()
            oCotizacionServicioService.Abort()
            oSolicitudGarantiaService.Abort()
            oMotorService.Abort()
        End Try
    End Sub

    Private Sub frmReclamoCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
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

    Private Sub llenarCombos()
        Try
            '======================================== SUPERVISOR =============================================           
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            '======================================= UNIDAD  ==================================================
            dtUnidad = oReclamoClienteService.MostrarUnidad.Tables(0)
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

    Private Sub EnableOptions()
        If state_button Then
            iEstado = oReclamoClienteService.Estado(IdReclamo)

            If iEstado = 1 Then
                activar()
            Else
                desactivar()
            End If
        End If        
    End Sub

    Private Sub activar()
        txtLugarServicio.ReadOnly = False
        txtLugarServicio.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = True
        txtTotalHoras.ReadOnly = False
        txtTotalHoras.BackColor = System.Drawing.SystemColors.Window
        cmbUnidad.ReadOnly = False
        cmbUnidad.BackColor = System.Drawing.SystemColors.Window
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = True
        txtSerieMotor.ReadOnly = False
        txtSerieMotor.BackColor = System.Drawing.SystemColors.Window
        btnBuscarMercaderia.Enabled = True
        txtModMotor.ReadOnly = False
        txtModMotor.BackColor = System.Drawing.SystemColors.Window
        txtProblema.ReadOnly = False
        txtProblema.BackColor = System.Drawing.SystemColors.Window
        txtCausa.ReadOnly = False
        txtCausa.BackColor = System.Drawing.SystemColors.Window
        txtComponentes.ReadOnly = False
        txtComponentes.BackColor = System.Drawing.SystemColors.Window
        cbDevLlamada.Enabled = True
        cbSumRepuestos.Enabled = True
        cbAteTecnico.Enabled = True
        txtEnsayoPrimario.ReadOnly = False
        txtEnsayoPrimario.BackColor = System.Drawing.SystemColors.Window
        cbEnGarantia.Enabled = True
        txtFecFinGarantia.ReadOnly = False
        txtFecFinGarantia.BackColor = System.Drawing.SystemColors.Window
        cmbSupervisor.ReadOnly = False
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
        txtLugarServicio.Focus()
    End Sub

    Private Sub desactivar()
        'If iPagago = True Then

        '    txtColaborador.ReadOnly = True
        '    txtColaborador.BackColor = System.Drawing.SystemColors.Control
        '    btnBuscarColaborador.Enabled = False
        '    cmbMotivo.ReadOnly = True
        '    cmbMotivo.BackColor = System.Drawing.SystemColors.Control
        '    txtFechaInicio.ReadOnly = True
        '    txtFechaInicio.BackColor = System.Drawing.SystemColors.Control
        '    txtFechaFinal.ReadOnly = True
        '    txtFechaFinal.BackColor = System.Drawing.SystemColors.Control
        '    txtHoraInicio.ReadOnly = True
        '    txtHoraInicio.BackColor = System.Drawing.SystemColors.Control
        '    txtHoraFinal.ReadOnly = True
        '    txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
        '    cmbPerAutoriza.ReadOnly = True
        '    cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
        '    txtObservacion.ReadOnly = True
        '    txtObservacion.BackColor = System.Drawing.SystemColors.Control
        '    cbPagado.Visible = True
        '    btnGuardar.Enabled = False
        '    txtColaborador.Focus()

        'Else

        txtLugarServicio.ReadOnly = True
        txtLugarServicio.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        txtTotalHoras.ReadOnly = True
        txtTotalHoras.BackColor = System.Drawing.SystemColors.Control
        cmbUnidad.ReadOnly = True
        cmbUnidad.BackColor = System.Drawing.SystemColors.Control        
        txtSerieMotor.ReadOnly = True
        txtSerieMotor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarMercaderia.Enabled = False
        txtModMotor.ReadOnly = True
        txtModMotor.BackColor = System.Drawing.SystemColors.Control
        txtProblema.ReadOnly = True
        txtProblema.BackColor = System.Drawing.SystemColors.Control
        txtCausa.ReadOnly = True
        txtCausa.BackColor = System.Drawing.SystemColors.Control
        txtComponentes.ReadOnly = True
        txtComponentes.BackColor = System.Drawing.SystemColors.Control
        cbDevLlamada.Enabled = False
        cbSumRepuestos.Enabled = False
        cbAteTecnico.Enabled = False
        txtEnsayoPrimario.ReadOnly = True
        txtEnsayoPrimario.BackColor = System.Drawing.SystemColors.Control
        cbEnGarantia.Enabled = False
        txtFecFinGarantia.ReadOnly = True
        txtFecFinGarantia.BackColor = System.Drawing.SystemColors.Control
        cmbSupervisor.ReadOnly = True
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = False
        txtLugarServicio.Focus()

        'End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf IdCliente = 0 Then
                MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtSerieMotor.Text) = "" Then
                MsgBox("Debe Ingresar la Serie de Motor.", MsgBoxStyle.Information, "Información")
                txtSerieMotor.Focus()
                Return False
            ElseIf toBlank(txtModMotor.Text) = "" Then
                MsgBox("Debe Ingresar el Modelo de Motor.", MsgBoxStyle.Information, "Información")
                txtModMotor.Focus()
                Return False
            ElseIf toBlank(txtProblema.Text) = "" Then
                MsgBox("Debe Ingresar la descripción del reclamo.", MsgBoxStyle.Information, "Información")
                txtProblema.Focus()
                Return False
            ElseIf toBlank(txtCausa.Text) = "" Then
                MsgBox("Debe Ingresar la(s) causa(s) del reclamo.", MsgBoxStyle.Information, "Información")
                txtCausa.Focus()
                Return False
            ElseIf toBlank(txtComponentes.Text) = "" Then
                MsgBox("Debe Ingresar los componentes del reclamo.", MsgBoxStyle.Information, "Información")
                txtComponentes.Focus()
                Return False
            ElseIf txtFecFinGarantia.Text <> "" And (txtFecFinGarantia.Value < txtFecha.Value) Then
                MsgBox("La fecha Fin Garantía debe ser mayor a la Fecha de Reclamo.", MsgBoxStyle.Information, "Información")
                txtFecFinGarantia.Focus()
                Return False
            ElseIf toNumber(cmbSupervisor.Value) = 0 Then
                MsgBox("Debe ingresar el supervisor del reclamo.", MsgBoxStyle.Information, "Información")
                cmbSupervisor.Focus()
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
            Dim registro As ReclamoClienteService.ReclamoCliente
            registro = oReclamoClienteService.Obtener(IdReclamo)

            IdReclamo = registro.IdReclamo
            lblEstado.Text = registro.EstadoReclamoCliente.DesEstado
            txtLugarServicio.Text = registro.LugarServicio
            txtFecha.Value = registro.Fecha
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtTotalHoras.Value = registro.TotalHoras
            cmbUnidad.Value = registro.UnidadMedida.CodUniMed
            txtSerieMotor.Text = registro.NumSerie
            txtModMotor.Text = registro.Modelo
            txtProblema.Text = registro.DesProblema
            txtCausa.Text = registro.DesCausa
            txtComponentes.Text = registro.DesComponentes
            cbDevLlamada.Checked = registro.DevLlamada
            cbSumRepuestos.Checked = registro.SumRepuesto
            cbAteTecnico.Checked = registro.AteTecnico
            txtEnsayoPrimario.Text = registro.EnsayoPrimario
            cbEnGarantia.Checked = registro.EnGarantia
            txtFecFinGarantia.Value = registro.FecFinGarantia
            cmbSupervisor.Value = registro.Supervisor.IdPer

            Me.Text = "Reclamo de Cliente: " + registro.IdReclamo.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ReclamoClienteService.ReclamoCliente)
        Try
            Dim estado_process As Integer
            estado_process = oReclamoClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdReclamo = estado_process
                MsgBox("Se insertó el reclamo Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR RECLAMO DE CLIENTE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ReclamoClienteService.ReclamoCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oReclamoClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR RECLAMO DE CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oReclamoClienteService.Borrar(IdReclamo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR RECLAMO DE CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
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
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New ReclamoClienteService.ReclamoCliente
                    Dim cliente As New ReclamoClienteService.Cliente
                    Dim unidad As New ReclamoClienteService.UnidadMedida
                    Dim supervisor As New ReclamoClienteService.Persona
                    Dim estado As New ReclamoClienteService.EstadoReclamoCliente
                    Dim empresa As New ReclamoClienteService.Empresa

                    registro.IdReclamo = IdReclamo
                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.LugarServicio = txtLugarServicio.Text
                    registro.Fecha = txtFecha.Value
                    cliente.IdCliente = IdCliente                    
                    registro.Cliente = cliente
                    registro.TotalHoras = txtTotalHoras.Value
                    unidad.CodUniMed = cmbUnidad.Value
                    registro.UnidadMedida = unidad
                    registro.NumSerie = txtSerieMotor.Text
                    registro.Modelo = txtModMotor.Text
                    registro.DesProblema = txtProblema.Text
                    registro.DesCausa = txtCausa.Text
                    registro.DesComponentes = txtComponentes.Text
                    registro.DevLlamada = cbDevLlamada.Checked
                    registro.SumRepuesto = cbSumRepuestos.Checked
                    registro.AteTecnico = cbAteTecnico.Checked
                    registro.EnsayoPrimario = toNull(txtEnsayoPrimario.Text)
                    registro.EnGarantia = cbEnGarantia.Checked
                    registro.FecFinGarantia = txtFecFinGarantia.Value
                    supervisor.IdPer = cmbSupervisor.Value
                    registro.Supervisor = supervisor

                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else
                        estado.IdEstado = 1
                        registro.EstadoReclamoCliente = estado
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR RECLAMO DE CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtLugarServicio.KeyPress _
                          , txtFecha.KeyPress _
                          , txtCliente.KeyPress _
                          , txtTotalHoras.KeyPress _
                          , cmbUnidad.KeyPress _
                          , txtSerieMotor.KeyPress _
                          , txtModMotor.KeyPress _
                          , txtProblema.KeyPress _
                          , txtCausa.KeyPress _
                          , txtComponentes.KeyPress _
                          , txtFecFinGarantia.KeyPress _
                          , cmbSupervisor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtSerieMotor_Validated(sender As Object, e As EventArgs) Handles txtSerieMotor.Validated
        Try
            If Len(Trim(txtSerieMotor.Text)) > 0 Then
                Dim registro As MotorService.Motor
                registro = oMotorService.Obtener(txtSerieMotor.Text)
                txtModMotor.Text = registro.Modelo.ModMer

                Dim registrohormot As HorasMotorService.HorasMotor
                registrohormot = oHorasMotorService.Obtener(txtSerieMotor.Text)
                cbEnGarantia.Checked = True
                txtFecFinGarantia.Value = registrohormot.FecFinGarantia

            Else
                txtModMotor.Text = ""
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL MODELO DE EQUIPO : " + ex.Message)
        End Try
    End Sub

End Class