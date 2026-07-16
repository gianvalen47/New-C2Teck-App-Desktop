Imports System.ServiceModel
Public Class frmComOrdenCompra

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oContactoProveedorService As New ContactoProveedorService.ContactoProveedorServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    'Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    'Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    Public IdOrden As Integer
    Public IdProveedor As Integer
    Public IdPersonaSolicita As Integer
    Public IdPersonaAutoriza As Integer
    Private dtDatos As DataTable
    Private dtCondPago As DataTable
    Private dtMonedas As DataTable
    Private dtTipDoc As DataTable
    Private dtAreas As DataTable
    Private dtContacto As DataTable
    Private dtRubros As DataTable

    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer


    Private Sub frmComOrdenCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "ORDEN DE COMPRA Nº " + Chr(34) + txtNumOrden.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(807, 388)
            gbEstado.Visible = False
            gbDetalle.Visible = False
            Me.Text = "Registrar nueva Orden de Compra"
            cmbMoneda.Value = "NS"
            txtCodUsu.Text = Session.sCodUsu
            activar()
            txtFecha.Select()
        End If
    End Sub

    Private Sub frmComOrdenCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraService.Close()
            oOrdenesCompraDetService.Close()
            oProveedorService.Close()
            oContactoProveedorService.Close()
            oMaestroService.Close()
            'oJobService.Close()
            oPersonaService.Close()
            'oGastoRealService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
            oOrdenesCompraDetService.Abort()
            oProveedorService.Abort()
            oContactoProveedorService.Abort()
            oMaestroService.Abort()
            'oJobService.Abort()
            oPersonaService.Abort()
            'oGastoRealService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
            oOrdenesCompraDetService.Abort()
            oProveedorService.Abort()
            oContactoProveedorService.Abort()
            oMaestroService.Abort()
            'oJobService.Abort()
            oPersonaService.Abort()
            'oGastoRealService.Abort()
        End Try
    End Sub

    Private Sub txtPersonaSolicita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonaSolicita.TextChanged
        'If state_button = False Then
        Persona = oPersonaService.Obtener(IdPersonaSolicita)
        cmbArea.Value = Persona.CentroCosto.Area.CodArea
        'End If
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        Dim proveedor As ProveedorService.Proveedor
        proveedor = oProveedorService.Obtener(IdProveedor)
        If proveedor.CondicionPagoProveedor.IdCondicion <> 0 Then
            cmbCodPago.Value = proveedor.CondicionPagoProveedor.IdCondicion
        End If
        ListarContactos()
    End Sub

    'Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        If Len(Trim(txtNumJob.Text)) > 0 Then
    '            If Not (oJobService.Buscar(txtNumJob.Text)) Then
    '                MsgBox("Número de Job no existente, Verifique")
    '                listaDatos()
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
    '                MsgBox("Número de Job Liquidado, Verifique")
    '                listaDatos()
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            Else
    '                If txtNumJob.Enabled = True Then
    '                    cmbRubro.Enabled = True
    '                    cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '                End If
    '                cmbRubro.Enabled = False
    '                cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '                txtPersonaSolicita.Focus()
    '            End If
    '        Else
    '            cmbRubro.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Len(Trim(txtNumJob.Text)) > 0 Then
    '            If Not (oJobService.Buscar(txtNumJob.Text)) Then
    '                MsgBox("Número de Job no existente, Verifique")
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
    '                MsgBox("Número de Job Liquidado, Verifique")
    '                txtNumJob.Text = ""
    '                txtNumJob.Focus()
    '            Else
    '                If txtNumJob.Enabled = True Then
    '                    cmbRubro.Enabled = True
    '                    cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '                End If
    '                cmbRubro.Focus()
    '            End If
    '        Else
    '            cmbRubro.Enabled = False
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '            txtPersonaSolicita.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
    '    End Try
    'End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                                            txtPersonaSolicita.KeyUp, _
                                                            txtPersonaAutoriza.KeyUp, _
                                                            txtProveedor.KeyUp
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
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) 'Handles cmbMoneda.ValueChanged, cmbCodPago.ValueChanged, cmbContacto.ValueChanged, cmbContacto.ValueChanged
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

            '================================CONDICION DE PAGO PROVEEDOR===================================
            dtCondPago = oProveedorService.MostrarCondicionPago.Tables(0)
            cmbCodPago.DataSource = dtCondPago
            cmbCodPago.DropDownList.DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.DisplayMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.ValueMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCodPago.DropDownList.Columns(0).DataMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCodPago.DropDownList.Columns(1).DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.Columns(2).DataMember = dtCondPago.Columns("DiasPago").ToString
            dtCondPago = Nothing

            ''===================================== TIPO DE DOCUMENTO=========================================
            'dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            'cmbTipoDoc.DataSource = dtTipDoc
            'cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            'cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            'cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            'cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            'cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("Nombre").ToString
            'dtTipDoc = Nothing

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

            ''========================================== RUBROS ===============================================
            'dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            'cmbRubro.DataSource = dtRubros
            'cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            'cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            'cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            'cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            'cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            'cmbRubro.SelectedIndex = 0
            'dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarContactos()
        Try
            cmbContacto.DataSource = Nothing
            cmbContacto.Text = ""
            dtContacto = oContactoProveedorService.Mostrar(IdProveedor).Tables(0)
            If dtContacto.Rows.Count <> 0 Then
                '===================================== CONTACTOS ==============================================
                cmbContacto.DataSource = dtContacto
                cmbContacto.DropDownList.DataMember = dtContacto.Columns("Nombres").ToString
                cmbContacto.DropDownList.DisplayMember = dtContacto.Columns("Nombres").ToString
                cmbContacto.DropDownList.ValueMember = dtContacto.Columns("IdContacto").ToString
                cmbContacto.DropDownList.Columns(0).DataMember = dtContacto.Columns("IdContacto").ToString
                cmbContacto.DropDownList.Columns(1).DataMember = dtContacto.Columns("Nombres").ToString
                cmbContacto.DropDownList.Columns(2).DataMember = dtContacto.Columns("Apellidos").ToString
                dtContacto = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS CONTACTOS" + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miActMasivo.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miActMasivo.Enabled = IIf(lblEstado.Text = "Generado", True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGrabar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(lblEstado.Text <> "", Not edicion, False)
    End Sub

    Private Sub activar()
        txtNumOrden.ReadOnly = True
        txtNumOrden.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        If CInt(lblSolicitud.Text) = 0 Then
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            btnBuscarProveedor.Enabled = True
            txtNumCotizacion.ReadOnly = False
            txtNumCotizacion.BackColor = System.Drawing.SystemColors.Window
            btnBuscarPersonaS.Enabled = True
            'btnBuscarPersonaA.Enabled = True
        Else
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            btnBuscarProveedor.Enabled = False
            txtNumCotizacion.ReadOnly = True
            txtNumCotizacion.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersonaS.Enabled = False
            'btnBuscarPersonaA.Enabled = False
        End If
        If state_button Then
            txtIgv.ReadOnly = True
            txtIgv.BackColor = System.Drawing.SystemColors.Control
        Else
            txtIgv.ReadOnly = False
            txtIgv.BackColor = System.Drawing.SystemColors.Window
        End If    
        cmbContacto.Enabled = True
        cmbCodPago.ReadOnly = False
        cmbCodPago.BackColor = System.Drawing.SystemColors.Window
        txtFormaPago.ReadOnly = False
        txtFormaPago.BackColor = System.Drawing.SystemColors.Window
        txtLugarEntrega.ReadOnly = False
        txtLugarEntrega.BackColor = System.Drawing.SystemColors.Window
        txtFecEntrega.ReadOnly = False
        txtFecEntrega.BackColor = System.Drawing.SystemColors.Window
        'txtNumJob.ReadOnly = False
        'txtNumJob.BackColor = System.Drawing.SystemColors.Window
        'btnBuscarJob.Enabled = True
        'If txtNumJob.Text <> "" Then
        '    cmbRubro.Enabled = True
        '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
        'End If        
        txtObsOrden.ReadOnly = False
        txtObsOrden.BackColor = System.Drawing.SystemColors.Window
        btnObservacion.Enabled = True
        edicion = True
        enableOpciones()
        txtFecha.Focus()
    End Sub

    Private Sub desactivar()
        txtNumOrden.ReadOnly = True
        txtNumOrden.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtIgv.ReadOnly = True
        txtIgv.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = False
        cmbContacto.Enabled = False
        cmbCodPago.ReadOnly = True
        cmbCodPago.BackColor = System.Drawing.SystemColors.Control
        txtFormaPago.ReadOnly = True
        txtFormaPago.BackColor = System.Drawing.SystemColors.Control
        txtLugarEntrega.ReadOnly = True
        txtLugarEntrega.BackColor = System.Drawing.SystemColors.Control
        txtFecEntrega.ReadOnly = True
        txtFecEntrega.BackColor = System.Drawing.SystemColors.Control
        txtNumCotizacion.ReadOnly = True
        txtNumCotizacion.BackColor = System.Drawing.SystemColors.Control
        'txtNumJob.ReadOnly = True
        'txtNumJob.BackColor = System.Drawing.SystemColors.Control
        'btnBuscarJob.Enabled = False
        'cmbRubro.Enabled = False
        'cmbRubro.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersonaS.Enabled = False
        'btnBuscarPersonaA.Enabled = False
        txtObsOrden.ReadOnly = True
        txtObsOrden.BackColor = System.Drawing.SystemColors.Control
        btnObservacion.Enabled = False
        edicion = False
        enableOpciones()
        dgvDatos.Select()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtIgv.Value < 0 Then
                MsgBox("Debe Ingresar el Igv con valores positivos", MsgBoxStyle.Information, "Información")
                txtIgv.BackColor = Color.Red
                txtIgv.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe Ingresar el Proveedor ", MsgBoxStyle.Information, "Información")
                txtProveedor.BackColor = Color.Red
                btnBuscarProveedor.Focus()
                Return False
            ElseIf toBlank(cmbCodPago.Value) = "" Then
                MsgBox("Debe de ingresar la Forma de Pago.", MsgBoxStyle.Information, "Información")
                cmbCodPago.BackColor = Color.Red
                cmbCodPago.Focus()
                Return False
            ElseIf toBlank(cmbContacto.Value) = "" Then
                MsgBox("Debe Ingresar el Contacto del Proveedor", MsgBoxStyle.Information, "Información")
                cmbContacto.BackColor = Color.Red
                cmbContacto.Focus()
                Return False
            ElseIf toBlank(cmbArea.Value) = "" Then
                MsgBox("Debe de Ingresar el Área.", MsgBoxStyle.Information, "Información")
                cmbArea.BackColor = Color.Red
                cmbArea.Focus()
                Return False
                'ElseIf toBlank(txtNumJob.Text) <> "" And cmbRubro.SelectedIndex = 0 Then
                '    MsgBox("Debe Ingresar el Rubro.", MsgBoxStyle.Information, "Información")
                '    cmbRubro.Focus()
                '    Return False
            ElseIf toNumber(IdPersonaSolicita) = 0 Then
                MsgBox("Debe Ingresar la Persona que Solicita la Orden ", MsgBoxStyle.Information, "Información")
                txtPersonaSolicita.BackColor = Color.Red
                btnBuscarPersonaS.Focus()
                Return False
                'ElseIf toNumber(IdPersonaAutoriza) = 0 Then
                '    MsgBox("Debe Ingresar la Persona que Autoriza la Orden ", MsgBoxStyle.Information, "Información")
                '    txtPersonaAutoriza.BackColor = Color.Red
                '    btnBuscarPersonaA.Focus()
                '    Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
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
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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
            Dim registro As OrdenesCompraService.OrdenesCompra
            registro = oOrdenesCompraService.Obtener(IdOrden)
            IdOrden = registro.IdOrden
            txtNumOrden.Text = IdOrden
            txtFecha.Value = registro.Fecha
            cmbMoneda.Value = registro.Moneda.CodMon
            txtIgv.Value = registro.Igv
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            ListarContactos()
            cmbContacto.Value = registro.ContactoProveedor.IdContacto
            cmbCodPago.Value = registro.CondicionPagoProveedor.IdCondicion
            txtFormaPago.Text = registro.ObsCondicion
            txtFecEntrega.Value = registro.FecEntrega
            txtNumCotizacion.Text = registro.NumCotizacion
            'txtNumJob.Text = registro.Job.CodJob
            ''----Se agrego 10/05/2012 para seleccionar el rubro al que se cargara el gasto.----
            'If CStr(registro.RubroGasto.CodRubro) <> "" Then
            '    cmbRubro.Value = registro.RubroGasto.CodRubro
            'Else
            '    cmbRubro.SelectedIndex = 0
            'End If
            '--------------------------------------------------------------------------------------------------------------------
            cmbArea.Value = registro.Area.CodArea
            IdPersonaSolicita = registro.PersonaSolicita.IdPer
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            'IdPersonaAutoriza = registro.PersonaAutoriza.IdPer
            txtPersonaAutoriza.Text = registro.PersonaAutoriza.ApeNom
            txtCodUsu.Text = registro.CodUsu
            txtLugarEntrega.Text = registro.LugarEntrega
            txtObsOrden.Text = registro.Observacion
            lblEstado.Text = registro.EstadoOrdenesCompra.DesEstado
            'cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            'txtNumDoc.Text = registro.NumDoc
            'txtSerieDoc.Text = registro.SerDoc
            lblSolicitud.Text = CStr(registro.SolicitudCompra.IdSolicitud)
            'If Not (registro.FecDoc.ToString = "") Then
            '    txtFecDoc.Value = CDate(registro.FecDoc)
            '    txtFecDoc.Text = registro.FecDoc.ToString
            'End If
            Me.Text = "Orden de Compra Nº " + registro.IdOrden.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmComOrdenCompraDet
                frm.state_button = False
                frm.IdOrden = IdOrden
                frm.IdProveedor = IdProveedor
                frm.CodMon = cmbMoneda.Value
                'frm.CodArea = cmbArea.Value
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                Else
                    frm.txtItem.Text = 1
                End If
                frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oOrdenesCompraDetService.Borrar(toNumber(txtNumOrden.Text), toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmComOrdenCompraDet
            frm.state_button = True
            frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
            frm.IdOrden = IdOrden
            frm.IdProveedor = IdProveedor
            frm.CodMon = cmbMoneda.Value
            'frm.CodArea = cmbArea.Value
            frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdOrdenDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdOrdenDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As OrdenesCompraService.OrdenesCompra)
        Try
            Dim estado_process As Integer
            estado_process = oOrdenesCompraService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOrden = estado_process
                MsgBox("Se insertó la Orden de Compra Correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ORDEN DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As OrdenesCompraService.OrdenesCompra)
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenesCompraService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Orden de Compra Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ORDEN DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenesCompraService.Borrar(IdOrden, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR ORDEN DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOrdenesCompraDetService.Mostrar(toNumber(IdOrden)).Tables(0)
            dgvDatos.DataSource = dtDatos
            If dgvDatos.RowCount > 0 Then
                Dim registro1 As New OrdenesCompraService.OrdenesCompra
                registro1 = oOrdenesCompraService.Obtener(IdOrden)
                txtTotalPrecio.Value = registro1.TotBruto
                txtTotalDescuento.Value = registro1.TotDscto
                txtTotal.Value = registro1.TotVenta
                txtTotalIGV.Value = registro1.TotIgv
                txtTotalNeto.Value = registro1.TotNeto
                lblTotal.Text = "SUB TOTALES ==>  "
                lbltotalIGV.Text = "IGV ==>  "
                lblTotalNeto.Text = " TOTAL NETO ==>(" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", cmbMoneda.Value) + ")"
            Else
                txtTotalPrecio.Value = 0
                txtTotalDescuento.Value = 0
                txtTotal.Value = 0
                txtTotalIGV.Value = 0
                txtTotalNeto.Value = 0
                lblTotal.Text = "SUB TOTALES ==>  "
                lbltotalIGV.Text = "IGV ==>  "
                lblTotalNeto.Text = " TOTAL NETO ==>(" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", cmbMoneda.Value) + ")"
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    cmbContacto.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmBuscarJob
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            If toNull(frm.cod_job) <> Nothing Then
    '                txtNumJob.Text = frm.cod_job
    '            Else
    '                txtNumJob.Text = ""
    '            End If
    '            listaDatos()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnBuscarPersonaSolicita_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersonaSolicita = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                    'txtPersonaAutoriza.Focus()
                    txtObsOrden.Focus()
                Else
                    IdPersonaSolicita = 0
                    txtPersonaSolicita.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersonaAutoriza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaA.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtPersonaAutoriza.Text = frm.descripcion
                    IdPersonaAutoriza = frm.codigo
                    txtObsOrden.Focus()
                Else
                    txtPersonaAutoriza.Text = ""
                    IdPersonaAutoriza = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New OrdenesCompraService.OrdenesCompra
                Dim moneda As New OrdenesCompraService.Moneda
                Dim personaSolicita As New OrdenesCompraService.Persona
                Dim personaAutoriza As New OrdenesCompraService.Persona
                Dim proveedor As New OrdenesCompraService.Proveedor
                Dim condicionPago As New OrdenesCompraService.CondicionPagoProveedor
                'Dim job As New OrdenesCompraService.Job
                Dim empresa As New OrdenesCompraService.Empresa
                'Dim tipoDocumento As New OrdenesCompraService.TipoDocumento
                Dim area As New OrdenesCompraService.Area
                Dim contacto As New OrdenesCompraService.ContactoProveedor
                Dim Estado As New OrdenesCompraService.EstadoOrdenesCompra
                'Dim Rubro As New OrdenesCompraService.RubroGasto ' Se agrego 10/05/2012 para seleccionar el rubro al que se cargara el gasto.

                registro.IdOrden = IdOrden
                registro.Fecha = txtFecha.Value
                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.Igv = CDbl(txtIgv.Value)
                proveedor.IdProveedor = IdProveedor
                registro.Proveedor = proveedor
                contacto.IdContacto = cmbContacto.Value
                registro.ContactoProveedor = contacto
                condicionPago.IdCondicion = cmbCodPago.Value                
                registro.CondicionPagoProveedor = condicionPago
                registro.ObsCondicion = txtFormaPago.Text
                registro.LugarEntrega = toNull(txtLugarEntrega.Text)
                registro.FecEntrega = txtFecEntrega.Value
                registro.NumCotizacion = toNull(txtNumCotizacion.Text)
                'job.CodJob = toNull(txtNumJob.Text)
                'registro.Job = job
                ''---Se agrego 10/05/2012 para seleccionar el rubro al que se cargara el gasto.---
                'Rubro.CodRubro = IIf(cmbRubro.SelectedIndex = 0, Nothing, cmbRubro.Value)
                'registro.RubroGasto = Rubro
                ''-------------------------------------------------------------------------------------------------------------------
                area.CodArea = cmbArea.Value
                registro.Area = area
                personaSolicita.IdPer = IdPersonaSolicita
                registro.PersonaSolicita = personaSolicita
                personaAutoriza.IdPer = 0
                registro.PersonaAutoriza = personaAutoriza
                registro.Observacion = txtObsOrden.Text
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                If state_button Then            'Modificar
                    'If cmbTipoDoc.Text = "" Then
                    '    tipoDocumento.IdDocumento = Nothing
                    '    registro.TipoDocumento = tipoDocumento
                    'Else
                    '    tipoDocumento.IdDocumento = toNull(cmbTipoDoc.Value)
                    '    registro.TipoDocumento = tipoDocumento
                    'End If
                    'registro.NumDoc = toNull(txtNumDoc.Text)
                    'registro.SerDoc = toNull(txtSerieDoc.Text)
                    'registro.FecDoc = IIf(txtFecDoc.Text = "", Nothing, txtFecDoc.Value)
                    Modificar(registro)
                Else                                  'Nuevo
                    Estado.IdEstado = 1
                    registro.EstadoOrdenesCompra = Estado
                    Insertar(registro)
                End If
            End If            
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ORDEN DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario...?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
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

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And toBlank(lblEstado.Text) = "Generado" Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

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
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = False And CInt(lblSolicitud.Text) = 0 Then
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

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If state_button Then
                txtProveedor.Focus()
            Else
                txtIgv.Focus()
            End If
        End If
    End Sub

    Private Sub txtIgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIgv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If CInt(lblSolicitud.Text) = 0 Then
            If e.KeyCode = Keys.F12 Then
                If btnBuscarProveedor.Enabled = True Then
                    e.Handled = True
                    btnBuscarProveedor_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbContacto.Focus()
        End If
    End Sub

    Private Sub cmbContacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbContacto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbCodPago.Focus()
        End If
    End Sub

    Private Sub cmbCodPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFormaPago.Focus()
        End If
    End Sub

    'Private Sub txtFormaPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        txtFecEntrega.Focus()
    '    End If
    'End Sub

    Private Sub txtFecEntrega_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecEntrega.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNumCotizacion.Focus()
        End If
    End Sub

    Private Sub txtNumCotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCotizacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtPersonaSolicita.Focus()
        End If
    End Sub

    'Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If cmbRubro.Enabled = True Then
    '            cmbRubro.Focus()
    '        Else
    '            txtPersonaSolicita.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub cmbRubro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        txtPersonaSolicita.Focus()
    '    End If
    'End Sub

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaSolicita.KeyDown
        If CInt(lblSolicitud.Text) = 0 Then
            If e.KeyCode = Keys.F12 Then
                If btnBuscarPersonaS.Enabled = True Then
                    e.Handled = True
                    btnBuscarPersonaSolicita_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub txtPersonaSolicita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonaSolicita.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObsOrden.Focus()
            'txtPersonaAutoriza.Focus()
        End If
    End Sub

    'Private Sub txtPersonaAutoriza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaAutoriza.KeyDown
    '    If CInt(lblSolicitud.Text) = 0 Then
    '        If e.KeyCode = Keys.F12 Then
    '            If btnBuscarPersonaA.Enabled = True Then
    '                e.Handled = True
    '                btnBuscarPersonaAutoriza_Click(sender, e)
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub txtPersonaAutoriza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonaAutoriza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObsOrden.Focus()
        End If
    End Sub

    Private Sub txtObsOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsOrden.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True            
            txtFecha.Focus()
        End If
    End Sub

    Private Sub btnObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservacion.Click
        Dim frm As New frmComOrdenCompraObservacion
        frm.Text = "Observación :"
        frm.txtObservacion.Text = toBlank(txtObsOrden.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObsOrden.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObsOrden.Select()        
    End Sub

    'Private Sub txtNumJob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If txtNumJob.Text <> "" Then
    '        If txtNumJob.Enabled = True Then
    '            cmbRubro.Enabled = True
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '        Else
    '            cmbRubro.Enabled = False
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '        End If
    '    Else
    '        cmbRubro.Enabled = False
    '        cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '    End If
    'End Sub

    Private Sub miActMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActMasivo.Click
        Try
            'If ValidaCodigoSeleccionado() Then
            Dim frm As New frmComOrdenCompra_ActMasivo
            frm.state_button = True
            frm.IdOrden = IdOrden
            frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
            frm.Masivo = True
            'frm.CodArea = cmbArea.Value        'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
            frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                miActualizar_Click(sender, e)
            End If
            'End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR el Nro de Cuenta Masivo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDescargarExcel_Click(sender As Object, e As EventArgs) Handles biDescargarExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Job", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodRubro", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Placa", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("IdTipoGasto", Type.GetType("System.Int32")))


        dtExcel.Rows.Add(New Object() {"0", "", "", "0.00", "0.00", "0.00", "", "", "", "", "1"})
        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub biImportarExcel_Click(sender As Object, e As EventArgs) Handles biImportarExcel.Click
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

                    Dim registro As New OrdenesCompraDetService.OrdenesCompraDet
                    Dim orden As New OrdenesCompraDetService.OrdenesCompra
                    Dim solicitudCompraDet As New OrdenesCompraDetService.SolicitudCompraDet
                    Dim Job As New OrdenesCompraDetService.Job
                    Dim Rubro As New OrdenesCompraDetService.RubroGasto
                    Dim Unidad As New OrdenesCompraDetService.Unidad
                    Dim tipogasto As New OrdenesCompraDetService.TipoGasto

                    registro.IdOrdenDet = 0
                    orden.IdOrden = IdOrden
                    registro.OrdenesCompra = orden
                    registro.Item = toNull(DataGridView1.Item(0, i).Value)
                    registro.CodMer = toNull(DataGridView1.Item(1, i).Value)
                    registro.DesMer = toNull(DataGridView1.Item(2, i).Value)
                    registro.CanMer = toNull(DataGridView1.Item(3, i).Value)
                    registro.PreMer = toNull(DataGridView1.Item(4, i).Value)
                    registro.DscMer = toNull(DataGridView1.Item(5, i).Value)
                    registro.Observacion = toNull(DataGridView1.Item(6, i).Value)
                    registro.TotalFila = Math.Round((toDouble(DataGridView1.Item(3, i).Value) * toDouble(DataGridView1.Item(4, i).Value)) - (toDouble(DataGridView1.Item(4, i).Value) * toDouble(DataGridView1.Item(5, i).Value / 100)), 2)

                    Job.CodJob = IIf(IsDBNull(DataGridView1.Item(7, i).Value), Nothing, DataGridView1.Item(7, i).Value)
                    registro.Job = Job
                    Rubro.CodRubro = IIf(IsDBNull(DataGridView1.Item(8, i).Value), Nothing, DataGridView1.Item(8, i).Value)
                    registro.RubroGasto = Rubro
                    Unidad.Placa = IIf(IsDBNull(DataGridView1.Item(9, i).Value), Nothing, DataGridView1.Item(9, i).Value)
                    registro.Unidad = Unidad

                    tipogasto.IdTipoGasto = CInt(DataGridView1.Item(10, i).Value)
                    registro.TipoGasto = tipogasto

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.FecModifica = Today

                    '=========================================================

                    Insertar(registro)

                End If
            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As OrdenesCompraDetService.OrdenesCompraDet)

        Try
            Dim estado_process As Integer
            estado_process = oOrdenesCompraDetService.Insertar(registro)

            If estado_process > 0 Then

            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class