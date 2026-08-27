Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmOrdenCompra

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean                   'True: Edición      False: Vista
    Public editable As Boolean                  'True: Editable     False: No Editable
    Public AprOrden As Boolean                  'True: Aprobacion    False: No necesita Aprobacion
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOrden As Integer
    Public IdLocacion As Integer
    Private IdCliente As Integer
    Public IdSugerido As Integer
    Private dtCotizaciones As DataTable
    Private dtMonedas As DataTable
    Private IdSugeridoCab As Integer
    Private CodMon As String
    Private Permiso As Boolean
    Private MonNac As Boolean

    Private dtCondicionesPago As DataTable
    Private dtMotivos As DataTable

    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObsOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsOrden.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub
    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFecRec.Focus()
        End If
    End Sub
    Private Sub cmbCodMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Focus()
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumOrden.Select()

        End If
    End Sub
    Private Sub cmbCodMot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMot.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObsOrden.Focus()
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtFecEnt.KeyPress _
                          , txtFecha.KeyPress _
                          , txtFecRec.KeyPress _
                          , txtNumOrden.KeyPress
        ',cmbCodMot.KeyPress
        ' , cmbCodMon.KeyPress
        ', cmbIdCotizacion.KeyPress
        ', txtObsOrden.KeyPress _
        ',txtCliente.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOrdenCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.biSalir
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar 
            desactivar()
            ObtenerRegistro()
            gbEstado.Visible = True
            actualizarDetalles()
            Me.Text = "ORDEN DE COMPRA Nº " + Chr(34) + txtNumOrden.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                    'Nuevo

            CodMon = oMaestroService.ObtenerMonedaNacional(IdLocacion)
            Permiso = oSeguridadService.BuscarPermisoTipCam(Session.sCodUsu)
            MonNac = oMaestroService.BuscarMonedaNacional(IdLocacion)

            txtNumOrden.ReadOnly = False
            txtNumOrden.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True

            Me.Size = New System.Drawing.Size(824, 273)
            gbEstado.Visible = False
            Me.Text = "Registrar nueva Orden de Compra"
            cmbCodMon.Value = CodMon
            txtFecha.Value = Session.sFecha
            txtFecEnt.Value = Session.sFecha
            txtFecRec.Value = Session.sFecha

            If Permiso Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                Else
                    cmbCodMon.ReadOnly = False
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Window
                End If
            End If
            activar()
            txtNumOrden.Select()
        End If

    End Sub
    Private Sub activar()
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtFecRec.ReadOnly = False
        txtFecRec.BackColor = System.Drawing.SystemColors.Window
        txtFecEnt.ReadOnly = False
        txtFecEnt.BackColor = System.Drawing.SystemColors.Window
        cmbCodMot.ReadOnly = False
        cmbCodMot.BackColor = System.Drawing.SystemColors.Window
        '----- Se valida que solo cuando la orden de compra sea generada desde una cotizacion se mostrara en el combo 15/05/14 -----
        cmbIdCotizacion.ReadOnly = True
        cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        txtObsOrden.ReadOnly = False
        txtObsOrden.BackColor = System.Drawing.SystemColors.Window
        edicion = True
        enableOpciones()
        biGenerar.Enabled = False
        biSugerir.Enabled = False
        dgvDatos.Select()
    End Sub
    Private Sub desactivar()
        txtNumOrden.ReadOnly = True
        txtNumOrden.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtFecRec.ReadOnly = True
        txtFecRec.BackColor = System.Drawing.SystemColors.Control
        txtFecEnt.ReadOnly = True
        txtFecEnt.BackColor = System.Drawing.SystemColors.Control
        cmbCodMot.ReadOnly = True
        cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        ' *****************************************************
        cmbIdCotizacion.ReadOnly = True
        cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        txtObsOrden.ReadOnly = True
        txtObsOrden.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        dgvDatos.Select()
    End Sub
    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oOrdenCompraService) = False Then
                oOrdenCompraService.Close()
            End If
            If isClosed(oOrdenCompraDetService) = False Then
                oOrdenCompraDetService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    'campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles txtNumOrden.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
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
        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdOrdenDet").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        '------------------------------------------------------------------------'
        'Evaluamos el Perfil del usuario
        'Donde solo el Supervisor con código “02” pude aprobar la orden de compra
        '------------------------------------------------------------------------'
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Enabled = False
            miEliminarSeparacion.Enabled = False
            miEliminarSeparaciones.Enabled = False
            miSugerir.Enabled = False
            biEnviar.Enabled = False
            biAprobar.Enabled = False
            biGenerar.Enabled = False
            biSepararOrden.Enabled = False
            biSugerir.Enabled = False
            biActMoneda.Enabled = IIf(lblEstado.Text = "GENERADO" And (Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miEliminarDetalle.Enabled = True
            'miSepararOrdenItem.Enabled = True
            biEnviar.Enabled = True
            biAprobar.Enabled = True
            biActMoneda.Enabled = False
            biSepararOrden.Enabled = IIf(lblEstado.Text = "GENERADO" And dgvDatos.RowCount > 0, True, False) 'True
            '  biGenerar.Enabled = True
        End If

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGrabar.Enabled = edicion
        biDeshacer.Enabled = edicion

        '----------------------------------------------------'
        'cmOpciones.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
        miMostrar.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
        miSugerir.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
        miEliminar.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
        miEliminarDetalle.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
        miSepararOrdenItem.Enabled = IIf((lblEstado.Text = "PARCIAL" Or lblEstado.Text = "GENERADO"), True, False)
        miEliminarSeparacion.Enabled = IIf((lblEstado.Text = "PARCIAL" Or lblEstado.Text = "GENERADO"), True, False)
        miEliminarSeparaciones.Enabled = IIf((lblEstado.Text = "PARCIAL" Or lblEstado.Text = "GENERADO"), True, False)
        miActualizar.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
        '-----------------------------------------------------'
        miNuevo.Enabled = IIf(editable, True, False)
        'biSepararOrden.Enabled = IIf(lblEstado.Text = "GENERADO" And (Session.CodPerfil = "02" Or Session.CodPerfil = "14"), True, False)

        '------------------------------------------------------------------------------------------------------'
        '- Evaluamos el estado hasta que sea diferente a "GENERADO" ya no podra realizar cambios.
        '- Evaluamos el Perfil del usuario, donde solo el Supervisor con código “02” pude aprobar la orden de compra
        '------------------------------------------------------------------------------------------------------'
        If state_button = True And (lblEstado.Text = "GENERADO" And Session.CodPerfil <> "02") Then
            '  biGrabar.Enabled = True
            biAprobar.Visible = False
            biEnviar.Visible = AprOrden  'True
            miNuevo.Enabled = True
            miEliminar.Enabled = True
            miEliminarDetalle.Enabled = True
            'miSepararOrdenItem.Visible = False
            'miSeparador1.Visible = False
            biGenerar.Enabled = Not AprOrden And IdSugeridoCab = 0 And dgvDatos.RowCount > 0 'False
        ElseIf state_button = True And lblEstado.Text = "GENERADO" And Session.CodPerfil = "02" Then
            '    biGrabar.Enabled = False
            biAprobar.Visible = False
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = False
            'miSeparador1.Visible = False
            biGenerar.Enabled = False
        ElseIf state_button = True And lblEstado.Text = "ENVIADO" And Session.CodPerfil <> "02" Then
            '   biGrabar.Enabled = False
            biAprobar.Visible = False
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = False
            'miSeparador1.Visible = False
            biGenerar.Enabled = False
        ElseIf state_button = True And lblEstado.Text = "ENVIADO" And Session.CodPerfil = "02" Then
            '    biGrabar.Enabled = False
            biAprobar.Visible = True
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = False
            ' miSeparador1.Visible = False
            biGenerar.Enabled = False
        ElseIf state_button = True And lblEstado.Text = "APROBADO" And Session.CodPerfil = "02" Then
            '     biGrabar.Enabled = False
            biAprobar.Visible = False
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = True
            'miSeparador1.Visible = True
            biGenerar.Enabled = False
        ElseIf state_button = True And lblEstado.Text = "ATENDIDO" Or lblEstado.Text = "RECHAZADO" Then
            '     biGrabar.Enabled = False
            biAprobar.Visible = False
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = False
            ' miSeparador1.Visible = False
            biGenerar.Enabled = False
        ElseIf state_button = True And lblEstado.Text = "PARCIAL" And Session.CodPerfil <> "02" Then
            biAprobar.Visible = False
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = IIf(Session.CodPerfil = "14", True, False)
            ' miSeparador1.Visible = False
            biGenerar.Enabled = True
        Else
            '     biGrabar.Enabled = False
            biAprobar.Visible = False
            biEnviar.Visible = False
            miNuevo.Enabled = False
            miEliminar.Enabled = False
            miEliminarDetalle.Enabled = False
            'miSepararOrdenItem.Visible = True
            '  miSeparador1.Enabled = True
            'biGenerar.Enabled = True
        End If

        'If state_button = True And lblEstado.Text = "GENERADO" And Session.CodPerfil = "14" Then
        '    'miSepararOrdenItem.Visible = True
        'End If

        If state_button = True And lblEstado.Text = "GENERADO" Then
            miSugerir.Enabled = True
            biSugerir.Enabled = True
        Else
            miSugerir.Enabled = False
            biSugerir.Enabled = False
        End If

    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresar el código de la orden.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf IdLocacion = 0 Then
                MsgBox("Debe Ingresar el almacén del documento.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtNumOrden.Text) = "" Then
                MsgBox("Debe Ingresar el Número de la Cotización.", MsgBoxStyle.Information, "Información")
                txtNumOrden.BackColor = Color.Red
                txtNumOrden.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf toBlank(txtFecRec.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de recepción.", MsgBoxStyle.Information, "Información")
                txtFecRec.BackColor = Color.Red
                txtFecRec.Focus()
                Return False
            ElseIf toBlank(txtFecEnt.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de entrega.", MsgBoxStyle.Information, "Información")
                txtFecEnt.BackColor = Color.Red
                txtFecEnt.Focus()
                Return False
            ElseIf toBlank(cmbCodMot.Value) = "" Then
                MsgBox("Debe Ingresar el motivo.", MsgBoxStyle.Information, "Información")
                cmbCodMot.Focus()
                Return False
            ElseIf state_button = False And oOrdenCompraService.Buscar(IdLocacion, toNumber(txtNumOrden.Text)) Then
                MsgBox("El Número " + txtNumOrden.Text + " de la orden ya existe...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf state_button = True And toBlank(lblEstado.Text) <> "GENERADO" And toBlank(lblEstado.Text) <> "CREDITOS" Then
                MsgBox("La Orden ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As OrdenCompraService.OrdenCompra)
        Try
            Dim estado_process As Integer
            estado_process = oOrdenCompraService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOrden = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As OrdenCompraService.OrdenCompra)
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenCompraService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenCompraService.Borrar(IdOrden, Session.sCodUsu)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenCompraService.OrdenCompra
            registro = oOrdenCompraService.MostrarPorId(IdOrden)

            IdOrden = registro.IdOrden
            IdLocacion = registro.Locacion.IdLocacion

            txtNumOrden.Text = registro.NumOrden
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            listarCotizaciones()
            txtFecha.Text = registro.Fecha
            txtFecRec.Text = registro.FecRec
            'If IsDBNull(registro.FecEnt) = Nothing Then
            '    txtFecEnt.IsNullDate = True
            'Else
            txtFecEnt.Text = registro.FecEnt
            'End If
            cmbCodMon.Value = registro.Moneda.CodMon
            cmbCodMot.Value = registro.Motivos.CodMot
            txtIgv.Text = registro.Igv
            txtObsOrden.Text = toBlank(registro.ObsOrden)
            cmbIdCotizacion.Value = IIf(registro.Cotizacion.IdCotizacion Is Nothing, 0, registro.Cotizacion.IdCotizacion)
            cmbCodPag.Value = IIf(registro.CondicionPago.CodPag Is Nothing, "", registro.CondicionPago.CodPag)
            lblEstado.Text = registro.Estado
            txtVendedor.Text = registro.Persona.ApeNom

            Me.Text = "Orden de Compra Nº " + registro.NumOrden.ToString
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= CONDICONES DE PAGO ================================================
            dtCondicionesPago = oMaestroService.MostrarCondicionPago.Tables(0)
            dtCondicionesPago.Rows.InsertAt(getRowTodos(dtCondicionesPago), 0)
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("DesPag").ToString
            dtCondicionesPago = Nothing

            '======================================= MOTIVOS ================================================
            dtMotivos = oMaestroService.MostrarMotivos.Tables(0)
            'dtMotivos.Rows.InsertAt(getRowTodos(dtMotivos), 0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.SelectedIndex = 0
            dtMotivos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listarCotizaciones()
        '======================================= COTIZACION ================================================
        dtCotizaciones = oOrdenCompraService.MostrarCotizacion(IdCliente).Tables(0)
        dtCotizaciones.Rows.InsertAt(getRowTodos(dtCotizaciones), 0)
        cmbIdCotizacion.DataSource = dtCotizaciones
        cmbIdCotizacion.DropDownList.DataMember = dtCotizaciones.Columns("NumCot").ToString
        cmbIdCotizacion.DropDownList.DisplayMember = dtCotizaciones.Columns("NumCot").ToString
        cmbIdCotizacion.DropDownList.ValueMember = dtCotizaciones.Columns("IdCotizacion").ToString
        cmbIdCotizacion.DropDownList.Columns(0).DataMember = dtCotizaciones.Columns("IdCotizacion").ToString
        cmbIdCotizacion.DropDownList.Columns(1).DataMember = dtCotizaciones.Columns("NumCot").ToString
        dtCotizaciones = Nothing
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOrdenCompraDetService.Mostrar(toNumber(IdOrden)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            If dgvDatos.RowCount > 0 Then
                IdSugeridoCab = IIf(dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text)

                Dim registro1 As New OrdenCompraService.OrdenCompra
                Dim registro2 As New OrdenCompraService.SugeridoOrden

                registro1 = oOrdenCompraService.MostrarPorId(IdOrden)
                If IdSugeridoCab > 0 Then
                    registro2 = oOrdenCompraService.MostrarPorIdSugerido(IdSugeridoCab)
                End If

                txtTotalPrecio.Value = registro1.TotBruto
                txtTotalDescuento.Value = registro1.TotDscto
                txtTotal.Value = registro1.TotVenta
                txtTotalIGV.Value = registro1.TotIgv
                txtTotalNeto.Value = registro1.TotNeto

                lblTotal.Text = "SUB TOTALES ==>  "
                lbltotalIGV.Text = "IGV ==>  "
                lblTotalNeto.Text = " TOTAL NETO ==>(" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", cmbCodMon.Value) + ")"


                txtTotalSug.Text = IIf(IdSugeridoCab > 0, registro2.TotVentaSug, 0)
                txtTotalIgvSug.Text = IIf(IdSugeridoCab > 0, registro2.TotIgvSug, 0)
                txtTotalNetoSug.Text = IIf(IdSugeridoCab > 0, registro2.TotNetoSug, 0)

                If txtTotalNetoSug.Text > 0 Then
                    dgvDatos.RootTable.Columns(3).Width = 164
                    dgvDatos.RootTable.Columns(11).Visible = True
                    lblTotal.Size = New System.Drawing.Size(481, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(610, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(610, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(483, 8)
                    txtTotalDescuento.Location = New System.Drawing.Point(560, 8)
                    txtTotal.Location = New System.Drawing.Point(613, 8)
                    txtTotalIGV.Location = New System.Drawing.Point(613, 27)
                    txtTotalNeto.Location = New System.Drawing.Point(613, 46)
                    txtTotalSug.Visible = True
                    txtTotalIgvSug.Visible = True
                    txtTotalNetoSug.Visible = True
                Else
                    dgvDatos.RootTable.Columns(3).Width = 246
                    dgvDatos.RootTable.Columns(11).Visible = False
                    lblTotal.Size = New System.Drawing.Size(563, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(692, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(692, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(564, 8)
                    txtTotalDescuento.Location = New System.Drawing.Point(641, 8)
                    txtTotal.Location = New System.Drawing.Point(694, 8)
                    txtTotalIGV.Location = New System.Drawing.Point(694, 27)
                    txtTotalNeto.Location = New System.Drawing.Point(694, 46)
                    txtTotalSug.Visible = False
                    txtTotalIgvSug.Visible = False
                    txtTotalNetoSug.Visible = False
                End If

            End If
            'txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.OrdenCompra", "TotBruto", "IdOrden", IdOrden)
            'txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.OrdenCompra", "TotDscto", "IdOrden", IdOrden)
            'txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.OrdenCompra", "TotVenta", "IdOrden", IdOrden)
            'txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.OrdenCompra", "TotIgv", "IdOrden", IdOrden)
            'txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.OrdenCompra", "TotNeto", "IdOrden", IdOrden)
            'lblTotal.Text = "SUB TOTALES"
            'lbltotalIGV.Text = "IGV"
            'lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", cmbCodMon.Value) + ")"


            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmOrdenCompra_AgregarDetalle
                frm.state_button = False
                frm.IdOrden = IdOrden
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                Else
                    frm.txtItem.Text = 1
                End If

                frm.estado = "GN"
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdSugerido = frm.IdSugerido
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdOrdenDet)
                    End If
                Else
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
                    Dim estado_process As Boolean
                    estado_process = oOrdenCompraDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text), IdOrden, Session.sCodUsu)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmOrdenCompra_AgregarDetalle
            frm.state_button = True
            frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
            frm.IdOrden = IdOrden
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.estado = toBlank(lblEstado.Text)
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdOrdenDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If toNumber(IdOrden) = 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtNumOrden.Focus()
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo

            listarCotizaciones()
            txtCliente.Select()
            If oClienteService.BuscarMonedaCliente(IdLocacion, IdCliente) = True Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If Permiso = False And MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                    cmbCodMon.Value = CodMon
                End If
            End If
        End If
    End Sub

    Private Sub btnAgregarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New OrdenCompraService.OrdenCompra
                Dim locacion As New OrdenCompraService.Locacion
                Dim cliente As New OrdenCompraService.Cliente
                Dim moneda As New OrdenCompraService.Moneda
                Dim cotizacion As New OrdenCompraService.Cotizacion
                Dim condicionPago As New OrdenCompraService.CondicionPago
                Dim motivo As New OrdenCompraService.Motivos
                Dim persona As New OrdenCompraService.Persona

                registro.IdOrden = IdOrden
                locacion.IdLocacion = IdLocacion
                registro.Locacion = locacion
                registro.NumOrden = txtNumOrden.Text
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
                registro.Fecha = txtFecha.Text
                registro.FecRec = txtFecRec.Text
                registro.FecEnt = txtFecEnt.Text    'IIf(txtFecEnt.IsNullDate, Nothing, txtFecEnt.Text)
                moneda.CodMon = cmbCodMon.Value
                registro.Moneda = moneda
                registro.ObsOrden = toNull(txtObsOrden.Text)
                cotizacion.IdCotizacion = IIf(toNumber(cmbIdCotizacion.Value) = 0, Nothing, cmbIdCotizacion.Value)
                registro.Cotizacion = cotizacion
                condicionPago.CodPag = IIf(toBlank(cmbCodPag.Value) = "", Nothing, cmbCodPag.Value)
                registro.CondicionPago = condicionPago
                motivo.CodMot = cmbCodMot.Value
                registro.Motivos = motivo
                persona.IdPer = Nothing
                registro.Persona = persona
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        Else
            dgvDatos.Focus()
        End If
    End Sub
    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click
        Try
            Dim frm As New frmOrdenCompra_GenerarDocumento
            frm.Text = "Generar G/F "
            frm.IdOrden = IdOrden
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                lblEstado.Text = oOrdenCompraService.Estado(IdOrden)
                listaDatos()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click
        Try
            If Session.CodPerfil = "02" And toNumber(IdOrden) > 0 Then
                Dim frm As New frmAprobarOrdenCompra
                frm.IdOrden = IdOrden
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    lblEstado.Text = oOrdenCompraService.Estado(IdOrden)
                    enableOpciones()
                    biAprobar.Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [APROB]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click
        If MsgBox("¿Está seguro de ENVIAR la orden para ser aprobada por el jefe de área?", MsgBoxStyle.YesNo, "Enviar Orden") = MsgBoxResult.Yes Then
            Try
                Dim estado_process As Boolean
                estado_process = oOrdenCompraService.Aprobar(IdOrden, "EN", Session.sCodUsu, "")
                If estado_process = True Then
                    lblEstado.Text = oOrdenCompraService.Estado(IdOrden)
                    enableOpciones()
                    biEnviar.Visible = False
                Else

                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVI]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If

    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
        txtFecha.Select()
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

    Private Sub biSepararOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSepararOrden.Click
        'Try
        '    If (Session.CodPerfil = "02" Or Session.CodPerfil = "14") And toNumber(IdOrden) > 0 Then
        '        Dim frm As New frmSepararOrdenCompra
        '        frm.IdOrden = IdOrden
        '        frm.AprOrden = AprOrden
        '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '            dtDatos = Nothing
        '            listaDatos()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR [SEPAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            'If (Session.CodPerfil = "02" Or Session.CodPerfil = "14") And toNumber(IdOrden) > 0 Then
            Dim frm As New frmOrdenCompra_SepararCabAprobacion
            frm.IdOrden = IdOrden
                frm.AprOrden = AprOrden
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [SEPAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miSepararOrdenItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSepararOrdenItem.Click
        'Try
        '    If Session.CodPerfil = "14" And state_button Then

        '        miSepararOrdenItem.Visible = True
        '        Dim frm As New frmOrdenCompra_SepararDetalle

        '        'frm.state_button = True
        '        frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
        '        'frm.IdOrden = IdOrden
        '        'frm.IdLocacion = IdLocacion
        '        'frm.IdCliente = IdCliente
        '        'frm.CodMon = cmbCodMon.Value
        '        frm.estado = toBlank(lblEstado.Text)
        '        frm.lseparar = True
        '        '/////////////////////////////////////////////
        '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '            dtDatos = Nothing
        '            listaDatos()
        '            If frm.type_process = "update" Then
        '                RowPossesion(dgvDatos, frm.IdOrdenDet)
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            'If Session.CodPerfil = "14" And state_button Then

            miSepararOrdenItem.Visible = True
            Dim frm As New frmOrdenCompra_SepararDetAprobacion

            'Dim registro As OrdenCompraDetService.OrdenCompraSeparadoTemp
            'registro = oOrdenCompraDetService.ObtenerSeparar(toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text))


            'Dim CanSep As Integer
            'CanSep = registro.CanSep

            'If CanSep > 0 Then
            '    frm.Nuevo = False
            'Else
            '    frm.Nuevo = True
            'End If

            Dim buscarseparacion As Boolean
            buscarseparacion = oOrdenCompraDetService.BuscarSeparado(toNumber(IdOrden), toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text))

            If buscarseparacion Then
                frm.Nuevo = False
            Else
                frm.Nuevo = True
            End If


            frm.IdOrden = IdOrden
            frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
            'frm.IdOrden = IdOrden
            'frm.IdLocacion = IdLocacion
            'frm.IdCliente = IdCliente
            'frm.CodMon = cmbCodMon.Value
            frm.CanPen = dgvDatos.CurrentRow.Cells("CanPen").Text
            frm.estado = toBlank(lblEstado.Text)
                frm.lseparar = True
                '/////////////////////////////////////////////
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "update" Then
                        RowPossesion(dgvDatos, frm.IdOrdenDet)
                    End If
                End If
            'End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub
    Private Sub sugerirCabecera()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New OrdenCompraService.SugeridoOrden
                registro = oOrdenCompraService.MostrarPorIdSugerido(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug = 0 And txtTotalSug.Text > 0 Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmOrdenCompra_SugerirCabecera
            frm.IdOrden = IdOrden
            frm.IdSugerido = IdSugerido
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                listaDatos()
                'If frm.type_process = "insert" Or frm.type_process = "update" Then
                '    RowPossesion(dgvDatos, dtDatos, "IdGuia", frm.IdGuia)
                'Else
                '    MsgBox("Se elimino la sugerencia correctamente.", MsgBoxStyle.Information)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub sugerirDetalle()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New OrdenCompraService.SugeridoOrden
                registro = oOrdenCompraService.MostrarPorIdSugerido(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug > 0 Then
                    MsgBox("No puede hacer sugerencias por detalle, por que ya se hizo a nivel de Documento ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            Dim frm As New frmOrdenCompra_SugerirDetalle
            frm.IdOrden = IdOrden
            frm.IdOrdenDet = toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Value)
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.CodMon = cmbCodMon.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                listaDatos()

                If frm.type_process = "insert" Or frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdOrdenDet)
                Else
                    MsgBox("Se eliminó la sugerencia correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirCabecera()
            ObtenerRegistro()
        End If
    End Sub

    Private Sub miSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirDetalle()
            ObtenerRegistro()
        End If
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Orden de Compra."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera de la Orden de Compra."
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar Cabecera de la Orden de Compra."
    End Sub
    Private Sub btnGenerarDocumento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter
        sslError.Text = "Generar Guia de Remision/Factura al Contado a partir de la Orden de Compra actual."
    End Sub
    Private Sub biSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento a la Orden de Compra."
    End Sub
    Private Sub biAprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter
        sslError.Text = "Aprobar/Rechazar Orden de Compra."
    End Sub
    Private Sub biEnviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter
        sslError.Text = "Aprobar/Rechazar Orden de Compra."
    End Sub
    'Private Sub biSeparar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSepararOrden.MouseEnter
    '    sslError.Text = "Separar toda la Orden de Compra"
    'End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Orden de Compra."
    End Sub
    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle a la Orden Compra."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Orden de Compra."
    End Sub
    'Private Sub miSepararOrdenItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSepararOrdenItem.MouseEnter
    '    sslError.Text = "Actualizar detalles del Formulario Orden de Compra."
    'End Sub
    Private Sub miSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.MouseEnter
        sslError.Text = "Sugerir Precio y/o Descuento al detalle seleccionado."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  biGrabar.MouseLeave, biDeshacer.MouseLeave, biEditar.MouseLeave, biGenerar.MouseLeave, _
                                   biSugerir.MouseLeave, biAprobar.MouseLeave, biEnviar.MouseLeave, _
                                   biSalir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave, miSugerir.MouseLeave
        sslError.Text = ""
    End Sub


    Private Sub biActMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActMoneda.Click
        Try
            Dim frm As New frmGuiaRemision_ActualizarMoneda

            frm.IdDoc = IdOrden
            frm.CodMon = cmbCodMon.Value
            frm.state_button = 5
            frm.NumDoc = txtNumOrden.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al Actualizar la moneda")
        End Try
    End Sub

    Private Sub miFormatoExcel_Click(sender As System.Object, e As System.EventArgs) Handles miFormatoExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodMerCli", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))

        dtExcel.Rows.Add(New Object() {"0", "", "", "", "0", "0.00", "0.00"})
        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub miImportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles miImportarExcel.Click

        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If

    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            If dgvDatos.RowCount >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If
    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub InsertarMasivo()
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim registro As New OrdenCompraDetService.OrdenCompraDet
                    Dim orden As New OrdenCompraDetService.OrdenCompra
                    Dim mercaderia As New OrdenCompraDetService.Mercaderia

                    Dim codigo As String
                    codigo = Trim(DataGridView1.Item(1, i).Value)

                    If oOrdenCompraDetService.Buscar(IdOrden, toBlank(codigo)) = True Then
                        MsgBox("Código " + codigo + " ya existe...!", MsgBoxStyle.Information, "Información")
                        listaDatos()
                        Exit Sub

                    Else

                        registro.IdOrdenDet = Nothing
                        orden.IdOrden = IdOrden
                        registro.OrdenCompra = orden
                        registro.Item = toNull(Trim(DataGridView1.Item(0, i).Value))
                        mercaderia.CodMer = toNull(Trim(DataGridView1.Item(1, i).Value))
                        mercaderia.DesMer1 = IIf(IsDBNull(DataGridView1.Item(2, i).Value), Nothing, DataGridView1.Item(2, i).Value)
                        registro.Mercaderia = mercaderia
                        registro.CodMerCli = IIf(IsDBNull(DataGridView1.Item(3, i).Value), Nothing, DataGridView1.Item(3, i).Value)
                        registro.CanMer = toNull(Trim(DataGridView1.Item(4, i).Value))
                        registro.PreMer = toNull(Trim(DataGridView1.Item(5, i).Value))
                        registro.DscMer = toNull(Trim(DataGridView1.Item(6, i).Value))
                        registro.TotFila = Math.Round((toNumber(Trim(DataGridView1.Item(4, i).Value)) * toDouble(toNull(Trim(DataGridView1.Item(5, i).Value)))) - (toDouble(toNull(Trim(DataGridView1.Item(5, i).Value))) * toDouble(Trim(DataGridView1.Item(6, i).Value) / 100)), 2)
                        registro.CodUsu = Session.sCodUsu
                        registro.NoCore = True

                        InsertarMasivo(registro)

                    End If

                End If
            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarMasivo(ByVal registro As OrdenCompraDetService.OrdenCompraDet)

        Try
            Dim estado_process As Integer
            estado_process = oOrdenCompraDetService.Insertar(registro)

            If estado_process > 0 Then

            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarDetalle_Click(sender As Object, e As EventArgs) Handles miEliminarDetalle.Click

        Try
            If MsgBox("¿Está seguro de ELIMINAR los detalles?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim row As Janus.Windows.GridEX.GridEXRow
                For i = 0 To Me.dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = i
                    row = Me.dgvDatos.GetRow()

                    If row.Cells("IdSugerido").Text = "" Then
                        oOrdenCompraDetService.Borrar(toNumber(row.Cells("IdOrdenDet").Value), IdOrden, Session.sCodUsu)
                    Else
                        MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                        Exit Sub
                    End If
                Next

                listaDatos()
                MsgBox("Se eliminaron los detalles correctamente.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error al ELIMINAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarSeparacion_Click(sender As Object, e As EventArgs) Handles miEliminarSeparacion.Click
        If ValidaCodigoSeleccionado() Then
            eliminarSeparacion()
        End If
    End Sub

    Private Sub eliminarSeparacion()
        Try

            Dim buscarseparacion As Boolean
            buscarseparacion = oOrdenCompraDetService.BuscarSeparado(toNumber(IdOrden), toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text))

            If buscarseparacion Then

                'cmOpciones.Visible = False
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                '    If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
                Dim estado_process As Boolean
                estado_process = oOrdenCompraDetService.BorrarSeparar(toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text), IdOrden, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó la separación correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
                '    Else
                '        MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                '    End If
                'End If
            Else
                MsgBox("El N° de Parte no tiene separación", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarSeparaciones_Click(sender As Object, e As EventArgs) Handles miEliminarSeparaciones.Click

        Try

            Dim estado_process As Boolean
            Dim buscarseparacion As Boolean


            For i As Integer = 0 To dtDatos.Rows.Count - 1
                'If dgvPrueba.Rows(i).Cells("Despacho").Value > "0" Then
                buscarseparacion = oOrdenCompraDetService.BuscarSeparado(toNumber(IdOrden), toNumber(dgvDatos.GetRow(i).Cells("IdOrdenDet").Text))

                If buscarseparacion Then
                    estado_process = oOrdenCompraDetService.BorrarSeparar(toNumber(dgvDatos.GetRow(i).Cells("IdOrdenDet").Text), IdOrden, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                End If

            Next

            If estado_process Then
                MsgBox("Se Eliminaron las Separaciones Correctamente.", MsgBoxStyle.Information)
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If


        Catch ex As Exception
            MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    'Private Sub miEliminarSeparar_Click(sender As Object, e As EventArgs)

    '    If ValidaCodigoSeleccionado() Then
    '        eliminarSeparacion()
    '    End If

    'End Sub

    'Private Sub eliminarSeparacion()
    '    Try
    '        'cmOpciones.Visible = False
    '        'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
    '        '    If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
    '        Dim estado_process As Boolean
    '        estado_process = oOrdenCompraDetService.BorrarSeparar(toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text), IdOrden, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '        If estado_process = True Then
    '            dtDatos = Nothing
    '            listaDatos()
    '            MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
    '        Else
    '            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
    '        End If
    '        '    Else
    '        '        MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
    '        '    End If
    '        'End If
    '    Catch ex As Exception
    '        MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

End Class
