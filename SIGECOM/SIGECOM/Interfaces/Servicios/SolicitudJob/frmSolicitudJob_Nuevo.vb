Imports System.ServiceModel

Public Class frmSolicitudJob_Nuevo

    Private oSolicitudJobService As New SolicitudJobService.SolicitudJobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobServices As New JobService.JobServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oPersona As New PersonaService.PersonaServiceClient

    Private IdCliente As Integer
    Private IdBeneficiado As Integer
    Public state_button As Boolean
    Private dtAreas As DataTable
    Private dtTipoSolicitud As DataTable
    Private dtUbicacion As DataTable
    Private dtVendedor As DataTable
    Public IdSolicitud As Integer
    Public IdCodJob As String
    Public IdPer As Integer
    Private IdEstado As String

    Private dtCorreos As DataTable
    Private dtDestinatarios As DataTable
    Public CodArea As String
    Public Area As String
    Private ComboTipo As String


    Private Sub frmSolicitudJob_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oSolicitudJobService) = True Then
                oSolicitudJobService.Close()
            End If

            If isClosed(oMaestroService) = True Then
                oMaestroService.Close()
            End If

            If isClosed(oJobServices) = True Then
                oJobServices.Close()
            End If

            If isClosed(oMercaderiaService) = True Then
                oMercaderiaService.Close()
            End If

            If isClosed(oPersona) = True Then
                oPersona.Close()
            End If
            If isClosed(oClienteService) = True Then
                oClienteService.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmSolicitudJob_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
        End If
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

        End Try
        'Try
        '    fila(1) = ""
        'Catch ex As Exception

        'End Try
        'Try
        '    fila(5) = ""
        'Catch ex As Exception

        'End Try

        Return fila
    End Function

    Private Sub frmSolicitudJob_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDestinatarios)
        If state_button Then
            ObtenerRegistro()
            listaDatos()
            desactivar()
            Me.Text = "Solicitud de OT Nº" & txtNumSolicitud.Text

        Else
            Me.Size = New System.Drawing.Size(762, 438)
            Me.Text = "Crear Nueva Solicitud de OT"
            txtFecha.Value = Today
            txtCodArea.Text = Area
            llenarCombos()
            enableOpciones()
            poVendedor()
            Me.Text = "Crear una Nueva Solicitud de OT"
            txtObservaciones.Text = "-Debe volver el Nº OT"
            txtObservaciones.ReadOnly = False
            txtObservaciones.BackColor = System.Drawing.SystemColors.Window
            txtObservaciones.ButtonEnabled = True

            txtMotivo.ReadOnly = False
            txtMotivo.BackColor = System.Drawing.SystemColors.Window
            txtMotivo.ButtonEnabled = True
            'cmbVendedorv.SelectedIndex = -1
            'cmbTipo.SelectedIndex = -1
            'cmbUbicacion.SelectedIndex = -1
        End If
        'cmbTipo.SelectedIndex = -1
        'cmbUbicacion.SelectedIndex = -1

    End Sub

    Private Sub poVendedor()
        Try
            Dim ClienteArea As Long
            If oSolicitudJobService.BuscarIdClienteArea(CodArea) Then
                Dim cliente As New ClienteService.Cliente
                ClienteArea = oSolicitudJobService.ObtenerIdClienteArea(CodArea)
                cliente = oClienteService.MostrarPorID(ClienteArea)
                txtBuscarCliente.Text = cliente.DesCli
                IdCliente = cliente.IdCliente
            End If

        Catch ex As Exception
            MsgBox("ERROR AL CLIENTE DEL AREA : " + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            If state_button Then
                biGuardar.Enabled = False
                biDeshacer.Enabled = False
                If IdEstado = 1 Then
                    biEditar.Enabled = True
                Else
                    biEditar.Enabled = False
                End If
            Else
                biSalir.Enabled = False
                biEditar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudJobService.SolicitudJob)
        Try
            Dim estado_process As Integer

            estado_process = oSolicitudJobService.Insertar(registro)
            If estado_process > 0 Then
                IdSolicitud = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else
                MsgBox("Error en el Proceso, Comuniquese con el Departamento de TI", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudJobService.SolicitudJob)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudJobService.Actualizar(registro)

            If estado_process Then

                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el Proceso, Comuniquese con el Departamento de TI", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        btnBuscarCliente.Enabled = True
        btnBuscarMercaderia.Enabled = True
        btnBuscarBeneficiado.Enabled = True

        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtCodArea.ReadOnly = True
        txtCodArea.BackColor = System.Drawing.SystemColors.Control
        'cmbCodArea.ReadOnly = False
        'cmbCodArea.BackColor = System.Drawing.SystemColors.Window
        txtcontacto.ReadOnly = False
        txtcontacto.BackColor = System.Drawing.SystemColors.Window
        cmbTipo.ReadOnly = False
        cmbTipo.BackColor = System.Drawing.SystemColors.Window
        cmbUbicacion.ReadOnly = False
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
        cmbVendedorv.ReadOnly = False
        cmbVendedorv.BackColor = System.Drawing.SystemColors.Window
        txtCargo.ReadOnly = False
        txtCargo.BackColor = System.Drawing.SystemColors.Window
        txtTelefono.ReadOnly = False
        txtTelefono.BackColor = System.Drawing.SystemColors.Window
        txtNumPedido.ReadOnly = False
        txtNumPedido.BackColor = System.Drawing.SystemColors.Window
        txtNumCotizacion.ReadOnly = False
        txtNumCotizacion.BackColor = System.Drawing.SystemColors.Window
        txtSerie.ReadOnly = False
        txtSerie.BackColor = System.Drawing.SystemColors.Window
        txtModMer.ReadOnly = False
        txtModMer.BackColor = System.Drawing.SystemColors.Window
        txtDesMer.ReadOnly = False
        txtDesMer.BackColor = System.Drawing.SystemColors.Window
        txtObservaciones.ReadOnly = False
        txtObservaciones.BackColor = System.Drawing.SystemColors.Window
        txtObservaciones.ButtonEnabled = True
        txtMotivo.ReadOnly = False
        txtMotivo.BackColor = System.Drawing.SystemColors.Window
        txtMotivo.ButtonEnabled = True

        biDeshacer.Enabled = True
        biEditar.Enabled = False
        biGuardar.Enabled = True
    End Sub

    Private Sub desactivar()

        btnBuscarCliente.Enabled = False
        btnBuscarMercaderia.Enabled = False
        btnBuscarBeneficiado.Enabled = False

        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtCodArea.ReadOnly = True
        txtCodArea.BackColor = System.Drawing.SystemColors.Control
        'cmbCodArea.ReadOnly = True
        'cmbCodArea.BackColor = System.Drawing.SystemColors.Control
        txtcontacto.ReadOnly = True
        txtcontacto.BackColor = System.Drawing.SystemColors.Control
        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control
        txtCargo.ReadOnly = True
        txtCargo.BackColor = System.Drawing.SystemColors.Control
        txtTelefono.ReadOnly = True
        txtTelefono.BackColor = System.Drawing.SystemColors.Control
        txtNumPedido.ReadOnly = True
        txtNumPedido.BackColor = System.Drawing.SystemColors.Control
        txtNumCotizacion.ReadOnly = True
        txtNumCotizacion.BackColor = System.Drawing.SystemColors.Control
        txtSerie.ReadOnly = True
        txtSerie.BackColor = System.Drawing.SystemColors.Control
        txtModMer.ReadOnly = True
        txtModMer.BackColor = System.Drawing.SystemColors.Control
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        txtMotivo.ReadOnly = True
        txtMotivo.BackColor = System.Drawing.SystemColors.Control
        txtMotivo.ButtonEnabled = False
        txtObservaciones.ReadOnly = True
        txtObservaciones.BackColor = System.Drawing.SystemColors.Control
        txtObservaciones.ButtonEnabled = False
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbVendedorv.ReadOnly = True
        cmbVendedorv.BackColor = System.Drawing.SystemColors.Control

        biDeshacer.Enabled = False
        biEditar.Enabled = IIf(IdEstado = 1, True, False)
        biGuardar.Enabled = False
        btnCorreo.Enabled = IIf(IdEstado = 1, True, False)
        btnEliminarTodo.Enabled = IIf(IdEstado = 1, True, False)
        btnEnviar.Enabled = IIf(IdEstado = 1, True, False)
        cmbOpciones.Enabled = IIf(IdEstado = 1, True, False)
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= UBICACION ================================================
            dtAreas = oJobServices.MostrarUbicacionEquipo.Tables(0)
            cmbUbicacion.DataSource = dtAreas
            cmbUbicacion.DropDownList.DataMember = dtAreas.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtAreas.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtAreas.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtAreas = Nothing

            '======================================= Vendedor - VENTAS ===========================================
            dtVendedor = oPersona.MostrarVendedoresVigente(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowTodos(dtVendedor), 0)
            cmbVendedorv.DataSource = dtVendedor
            cmbVendedorv.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedorv.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedorv.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.SelectedIndex = 0
            dtVendedor = Nothing

            ''======================================= AREAS ================================================
            'dtAreas = oMaestroService.MostrarAreas.Tables(0)
            'cmbCodArea.DataSource = dtAreas
            'cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'cmbCodArea.SelectedIndex = 0
            'dtAreas = Nothing

            '======================================= TIPO SOLICITUD ================================================
            dtTipoSolicitud = oJobServices.MostrarTipo().Tables(0) 'oSolicitudJobService.MostrarTipoSolicitud(CodArea).Tables(0)
            cmbTipo.DataSource = dtTipoSolicitud
            cmbTipo.DropDownList.DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipoSolicitud.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
            'cmbTipo.DropDownList.Columns(2).DataMember = dtTipoSolicitud.Columns("CodBloque").ToString
            If dtTipoSolicitud.Rows.Count > 0 Then
                cmbTipo.SelectedIndex = 0
            End If

            dtTipoSolicitud = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudJobService.SolicitudJob
            Dim Estado As String

            registro = oSolicitudJobService.Obtener(IdSolicitud)

            txtNumSolicitud.Text = registro.IdSolicitud
            'IdPer = registro.Persona.IdPer
            txtSolicitante.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            IdCliente = registro.ClienteSolicita.IdCliente
            txtBuscarCliente.Text = registro.ClienteSolicita.DesCli
            IdBeneficiado = registro.ClienteBeneficiado.IdCliente
            txtBuscarBeneficiado.Text = registro.ClienteBeneficiado.DesCli
            txtcontacto.Text = registro.Contacto
            CodArea = registro.Area.CodArea
            llenarCombos()

            txtCodArea.Text = registro.Area.DesArea
            cmbTipo.Value = registro.TipoJob.IdTipoJob  'registro.TipoSolicitudJob.IdTipo
            cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion
            cmbVendedorv.Value = registro.Vendedor.IdPer
            If cmbVendedorv.Value = 0 Then
                cmbVendedorv.Text = ""
            End If
            txtCargo.Text = registro.Cargo
            txtTelefono.Text = registro.Telefono
            txtNumPedido.Text = registro.NumPedido
            txtNumCotizacion.Text = registro.NumCotizacion
            txtSerie.Text = registro.CodMer
            txtModMer.Text = registro.ModMer
            txtDesMer.Text = registro.DesMer
            txtMotivo.Text = registro.Motivo
            txtObservaciones.Text = registro.Observacion
            IdEstado = registro.EstadoSolicitudJob.IdEstado
            lblEstado.Text = registro.EstadoSolicitudJob.DesEstado
            Estado = registro.EstadoSolicitudJob.DesEstado
            IdCliente = registro.ClienteSolicita.IdCliente
            txtBuscarCliente.Text = registro.ClienteSolicita.DesCli
            If Estado = "GENERADA" Then
                lblEstado.Text = "(SOLICITUD " & Estado & ")"
            ElseIf Estado = "ENVIADA" Then
                lblEstado.Text = "(SOLICITUD " & Estado & " A SERVICIOS)"
            ElseIf Estado = "ATENDIDA" Then
                lblEstado.Text = "(SOLICITUD " & Estado & " POR SERVICIOS CON # OT " & IdCodJob & " )"
            ElseIf Estado = "ANULADA" Then
                lblEstado.Text = "(SOLICITUD " & Estado & ")"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If IdPer = 0 Then
            '    MsgBox("Debes elegir a la persona que hara la solicitud")
            '    Return False
            If IdCliente = 0 Then
                MsgBox("Debes elegir el Cliente")
                btnBuscarCliente.Focus()
                Return False
            ElseIf IdBeneficiado = 0 Then
                MsgBox("Debes elegir el Beneficiario")
                btnBuscarBeneficiado.Focus()
                Return False
                'ElseIf cmbVendedorv.Text = "" Then
                '    MsgBox("Debes seleccionar el Vendedor")
                '    cmbVendedorv.Focus()
                '    Return False
                'ElseIf toBlank(txtContacto.Text) = "" Then
                '    MsgBox("Debe ingresar el contacto")
                '    txtContacto.Focus()
                '    Return False
                'ElseIf toBlank(txtCargo.Text) = "" Then
                '    MsgBox("Debe ingresar el cargo")
                '    txtCargo.Focus()
                '    Return False
                'ElseIf toBlank(txtTelefono.Text) = "" Then
                '    MsgBox("Debe ingresar el teléfono")
                '    txtTelefono.Focus()
                '    Return False
            ElseIf toBlank(txtMotivo.Text) = "" Then
                MsgBox("Debe ingresar el motivo")
                txtMotivo.Focus()
                Return False
                'ElseIf toBlank(txtObservaciones.Text) = "" Then
                '    MsgBox("Debe ingresar la observación")
                '    txtObservaciones.Focus()
                '    Return False
                'ElseIf toNull(txtSerie.Text) = "" Then
                '    MsgBox("Debe ingresar el codigo de la mercaderia")
                '    txtSerie.Focus()
                '    Return False
                'ElseIf toBlank(txtModMer.Text) = "" Then
                '    MsgBox("Debe ingresar el modelo de la mercaderia")
                '    txtModMer.Focus()
                '    Return False
                'ElseIf toBlank(txtDesMer.Text) = "" Then
                '    MsgBox("Debe ingresar la descripción de la mercaderia")
                '    txtDesMer.Focus()
                '    Return False
                'ElseIf toBlank(txtNumPedido.Text) = "" Then
                '    MsgBox("Debe ingresar el número de pedido")
                '    txtNumPedido.Focus()
                '    Return False
                'ElseIf toBlank(txtNumCotizacion.Text) = "" Then
                '    MsgBox("Debe ingresar el número de la cotización")
                '    txtNumCotizacion.Focus()
                '    Return False
            ElseIf cmbTipo.Value = 0 Then
                MsgBox("Debe elegir el tipo de solicitud de OT")
                cmbTipo.Focus()
                Return False
            ElseIf cmbUbicacion.Value = 0 Then
                MsgBox("Debe elegir la Ubicación")
                cmbUbicacion.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub listaDatos()
        Try
            'Listar Destinatarios 
            dtDestinatarios = oSolicitudJobService.MostrarDestinatarios(IdSolicitud).Tables(0)
            dgvDestinatarios.DataSource = dtDestinatarios

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim registro As New SolicitudJobService.SolicitudJob
                Dim persona As New SolicitudJobService.Persona
                Dim clienteSolicita As New SolicitudJobService.Cliente
                Dim clienteBeneficiado As New SolicitudJobService.Cliente
                Dim tiposolicitudjob As New SolicitudJobService.TipoSolicitudJob
                Dim ubicacion As New SolicitudJobService.UbicacionEquipo
                Dim vendedor As New SolicitudJobService.Persona
                Dim area As New SolicitudJobService.Area
                If cmbVendedorv.Text = "" Then
                    cmbVendedorv.Value = 0
                End If
                'Dim tipojob As New SolicitudJobService.TipoJob

                Dim empresa As New SolicitudJobService.Empresa
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                area.CodArea = CodArea
                registro.Area = area
                registro.IdSolicitud = IdSolicitud
                registro.Fecha = txtFecha.Value
                persona.IdPer = IdPer
                registro.Persona = persona

                clienteSolicita.IdCliente = IdCliente
                registro.ClienteSolicita = clienteSolicita

                clienteBeneficiado.IdCliente = IdBeneficiado
                registro.ClienteBeneficiado = clienteBeneficiado

                registro.Contacto = toNull(txtcontacto.Text)
                registro.Cargo = toNull(txtCargo.Text)
                registro.Telefono = toNull(txtTelefono.Text)
                registro.Motivo = toNull(txtMotivo.Text)
                registro.Observacion = toNull(txtObservaciones.Text)
                registro.CodMer = toNull(txtSerie.Text)
                registro.ModMer = toNull(txtModMer.Text)
                registro.DesMer = toNull(txtDesMer.Text)
                registro.NumPedido = toNull(txtNumPedido.Text)
                registro.NumCotizacion = toNull(txtNumCotizacion.Text)
                tiposolicitudjob.IdTipo = cmbTipo.Value
                registro.TipoSolicitudJob = tiposolicitudjob
                ubicacion.CodUbicacion = cmbUbicacion.Value
                registro.UbicacionEquipo = ubicacion
                vendedor.IdPer = cmbVendedorv.Value
                registro.Vendedor = vendedor
                'tipojob.IdTipoJob =
                'registro .TipoJob =
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
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

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                    txtcontacto.Select()
                Else
                    txtBuscarCliente.Text = ""
                    IdCliente = 0
                End If

                'listarContactos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Try
            Dim frm As New frmBuscarMercaderia
            frm.CodRub = "04"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtSerie.Text = frm.codigo
                txtDesMer.Text = frm.descripcion
                txtModMer.Text = frm.ModMer
            End If
            txtSerie.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Está seguro de salir del formulario?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorreo.Click
        Try
            Dim frm As New frmSolicitudJob_Correo
            frm.CodArea = CodArea
            frm.IdSolicitud = IdSolicitud

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        Try
            If MsgBox("¿Desea ELIMINAR el correo de " & dgvDestinatarios.CurrentRow.Cells("AbrPer2").Value & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudJobService.BorrarCorreo(dgvDestinatarios.CurrentRow.Cells("IdSolicitud").Value, dgvDestinatarios.CurrentRow.Cells("IdPer").Value)
                If estado_process Then
                    MsgBox("Se eliminó el correo seleccionado correctamente")
                    listaDatos()
                Else
                    MsgBox("Error en el proceso, por favor comunicarse con el departamento de TI..")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEliminarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTodo.Click
        If MsgBox("¿Desea ELIMINAR TODOS los correos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Dim estado_process As Boolean
            For Each row As DataRow In dtDestinatarios.Rows
                estado_process = oSolicitudJobService.BorrarCorreo(row.Item("IdSolicitud"), row.Item("IdPer"))
            Next
            If estado_process Then
                MsgBox("Se ELIMINO TODOS los Correos Correctamente")
            Else
                MsgBox("Error en el Proceso ,Por Favor Comunicarse con el Administardor de TI")
            End If
        End If
    End Sub

    Private Sub btnBuscarBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarBeneficiado.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarBeneficiado.Text = frm.descripcion
                    IdBeneficiado = frm.codigo
                    txtcontacto.Select()
                Else
                    txtBuscarBeneficiado.Text = ""
                    IdBeneficiado = 0
                End If

                'listarContactos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged

        Dim ClienteSolicitante As New SolicitudJobService.Cliente
        Dim Garantia As String

        Garantia = cmbTipo.DropDownList.GetRow.Cells(2).Text

        If Garantia = "15" Then
            txtBuscarCliente.Text = "ALMACEN DE GARANTIA DE SERVICIOS"
            IdCliente = "3498"
            'Else
            '    txtBuscarCliente.Text = ""
            '    IdCliente = 0
        End If

    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If dgvDestinatarios.RecordCount < 1 Then
            MsgBox("Debe Agregar un Correo a Enviar...", MsgBoxStyle.Exclamation)
        Else
            If oSolicitudJobService.Estado(txtNumSolicitud.Text.Trim) = 1 Then
                If MsgBox("¿Está seguro de ENVIAR la solicitud de OT N°: " & txtNumSolicitud.Text.Trim & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Enviar()
                End If
            Else
                MsgBox("No se puede ENVIAR porque no esta en estado GENERADO")
            End If
        End If
    End Sub

    Protected Sub Enviar()
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudJobService.Enviar(txtNumSolicitud.Text.Trim, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
            If estado_process Then
                MsgBox("La solicitud de OT fue enviada correctamente")
                listaDatos()
                lblEstado.Text = "SOLICITUD ENVIADA A SERVICIOS"
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ENVIAR LA SOLICITUD DE OT : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

            If oMercaderiaService.Buscar(txtSerie.Text, Session.sCodEmp) = True Then

                Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia

                Mercaderia = oMercaderiaService.Obtener(txtSerie.Text, Session.sCodEmp)

                txtSerie.Text = Mercaderia.CodMer
                txtDesMer.Text = Mercaderia.DesMer1
                txtModMer.Text = Mercaderia.Modelo.ModMer
            Else
                txtDesMer.Text = ""
                txtModMer.Text = ""
            End If
        End If


    End Sub

    Private Sub txtMotivo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMotivo.ButtonClick
        Dim frm As New frmSolicitudJob_ModificarMotivo

        frm.txtMotivo.Text = toBlank(txtMotivo.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtMotivo.Text = toBlank(frm.txtMotivo.Text)
        End If
        txtMotivo.Select()
    End Sub

    Private Sub txtObservaciones_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservaciones.ButtonClick
        Dim frm As New frmSolicitudJob_ModificarObservaciones

        frm.txtObservaciones.Text = toBlank(txtObservaciones.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservaciones.Text = toBlank(frm.txtObservaciones.Text)
        End If
        txtObservaciones.Select()
    End Sub

End Class