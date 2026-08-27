Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports ConsultasSunat
Imports ConsultasSunat.CodigoUsuario
Imports ConsultasSunat.EntidadNegocio

Public Class frmCliente

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdCliente As Integer
    Private oMaestro As New MaestroService.MaestroClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oVendedorClienteService As New VendedorClienteService.VendedorClienteServiceClient
    Private oCondicionPagoClienteService As New CondicionPagoClienteService.CondicionPagoClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oUsuarioClienteService As New UsuarioClienteService.UsuarioClienteServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient


    Private dtDatos As DataTable
    Private dtEstados As DataTable
    Private dtMoneda As DataTable
    Private dtTipoDoc As DataTable

    Private state_Search As Boolean
    Private CodUbigeo As String
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private TAB_CONTACTOS As String = "tabpContactos"
    Private TAB_DIRECCIONES_FISCALES As String = "tabpDireccionesFiscales"
    Private TAB_LOCACIONES As String = "tabpLocaciones"
    Private TAB_CONDICIONES_PAGO As String = "tabpCondicionesPago"
    Private TAB_VENDEDORES As String = "tabpVendedores"
    Private TAB_MONEDA As String = "tabMoneda"

    Private dtTiposContribuyentes As DataTable
    Private dtSectores As DataTable
    Private dtTiposClientes As DataTable
    Private dtMonedas As DataTable
    Private dtTipoMedioContacto As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           cmbIdTipoCliente.KeyPress _
                          , txtDesCli.KeyPress _
                          , txtIdCliente.KeyPress _
                          , cmbIdTipoCon.KeyPress _
                          , txtAbrCli.KeyPress _
                          , txtDueCli.KeyPress _
                          , txtNroDoc.KeyPress _
                          , txtDniCli.KeyPress _
                          , txtUrlCli.KeyPress _
                          , txtEmail.KeyPress _
                          , txtFaxCli.KeyPress _
                          , txtTelCli.KeyPress _
                          , cbListaCli.KeyPress _
                          , cbAprCli.KeyPress _
                          , txtDiaPago.KeyPress _
                          , txtNumCta.KeyPress _
                          , cmbMedioContacto.KeyPress _
                          , cmbTipoDoc.KeyPress
        ', txtHoraPago.KeyPress _
        'txtObsCli.KeyPress _
        ', cmbCodSec.KeyPress _
        ', txtUbigeo.KeyPress _
        ', txtDirCli.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtHoraPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    'Private Sub txtDirCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        If btnUbigeo.Enabled = True Then
    '            e.Handled = True
    '            btnUbigeo.Focus()
    '        End If
    '    End If
    'End Sub
    'Private Sub txtObsCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsCli.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        If btnGuardar.Enabled = True Then
    '            btnGuardar.Select()
    '            btnGuardar_Click(sender, e)
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Sub EjecutaEnter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDireccionesFiscales.KeyPress, dgvLocaciones.KeyPress, dgvCondicionesPago.KeyPress, dgvContactos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
                If ValidaCodigoSeleccionado(dgvContactos) Then
                    mostrarContacto()
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
                If ValidaCodigoSeleccionado(dgvDireccionesFiscales) Then
                    mostrarDireccionFiscal()
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
                If ValidaCodigoSeleccionado(dgvLocaciones) Then
                    mostrarLocacionCliente()
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
                If ValidaCodigoSeleccionado(dgvCondicionesPago) Then
                    mostrarCondicionPago()
                End If
            End If
        End If
    End Sub

    Private Sub txtUbigeo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDueCli.Focus()
        End If
    End Sub
    'Private Sub txtUbigeo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F12 Then
    '        If btnUbigeo.Enabled = True Then
    '            btnUbigeo_Click(sender, e)
    '        End If
    '    End If
    'End Sub
    Private Sub cmbCodSec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodSec.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbIdTipoCliente.Focus()
        End If
    End Sub

    Private Sub frmCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        state_Search = False
        llenarCombos()
        InitDataGrids()

        If state_button Then    'Modificar

            txtIdCliente.ReadOnly = True
            txtIdCliente.TabStop = False
            ObtenerRegistro()
            desactivar()
            'btnUbigeo.Enabled = False
            'txtDesCli.ReadOnly = True
            'txtDirCli.ReadOnly = True
            'txtDueCli.ReadOnly = True
            'txtFaxCli.ReadOnly = True
            'txtEmail.ReadOnly = True
            'txtObsCli.ReadOnly = True
            'txtRucCli.ReadOnly = True
            'txtAbrCli.ReadOnly = True
            'txtTelCli.ReadOnly = True
            'txtDniCli.ReadOnly = True
            'txtUrlCli.ReadOnly = True
            'txtNumCta.ReadOnly = True
            'txtDiaPago.ReadOnly = True
            'txtHoraPago.ReadOnly = True
            'txtNombre.ReadOnly = True
            'txtNombre.BackColor = System.Drawing.SystemColors.Control
            'txtApePat.ReadOnly = True
            'txtApePat.BackColor = System.Drawing.SystemColors.Control
            'txtApeMat.ReadOnly = True
            'txtApeMat.BackColor = System.Drawing.SystemColors.Control
            'cmbIdTipoCliente.ReadOnly = True
            'cmbCodSec.ReadOnly = True
            'cmbIdTipoCon.ReadOnly = True
            'cbEstado.Enabled = False
            'cbListaCli.Enabled = False
            'cbAprCli.Enabled = False

            tabVentanas.SelectedIndex = 0
            listaContactos()
            limpiaDataGrids(TAB_CONTACTOS)
            'Me.Text = "Cliente " + Chr(34) + txtDesCli.Text.ToString + Chr(34)
            btnConsultaSunat.Visible = False
        Else                    'Nuevo
            txtIdCliente.ReadOnly = True
            txtIdCliente.TabStop = False
            cmbTipoDoc.Value = "6"
            Me.Size = New System.Drawing.Size(703, 387)
            Me.Text = "Registrar nuevo Cliente"

        End If
        state_Search = True
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestro) = False Then
                oMaestro.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
            If isClosed(oDireccionFiscalService) = False Then
                oDireccionFiscalService.Close()
            End If
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oCondicionPagoClienteService) = False Then
                oCondicionPagoClienteService.Close()
            End If
            If isClosed(oVendedorClienteService) = False Then
                oVendedorClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oUsuarioClienteService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oPersonaService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                         txtIdCliente.KeyUp _
                        , txtDesCli.KeyUp _
                        , txtNroDoc.KeyUp _
                        , txtDniCli.KeyUp
        Try
            If state_Search = True Then
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
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles txtModMer.KeyPress
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
        fila(1) = "(Ninguno)"
        Return fila
    End Function
    Private Sub enableOpciones(ByVal campo As DataGridView)
        If campo.RowCount < 1 Then
            miModificar.Enabled = False
            miEliminar.Enabled = False
        Else
            miModificar.Enabled = True
            miEliminar.Enabled = True
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As DataGridView, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstDisplayedScrollingRowIndex = dtDatos.DefaultView.Find(codigo)
            lista.Rows(dtDatos.DefaultView.Find(codigo)).Selected = True
            lista.CurrentCell = lista.Rows(dtDatos.DefaultView.Find(codigo)).Cells(0)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub limpiaDataGrids(ByVal campo As String)
        If campo = TAB_CONTACTOS Then
            dgvDireccionesFiscales.DataSource = Nothing
            dgvLocaciones.DataSource = Nothing
            dgvCondicionesPago.DataSource = Nothing
            'dgvVendedores.DataSource = Nothing
        ElseIf campo = TAB_DIRECCIONES_FISCALES Then
            dgvContactos.DataSource = Nothing
            dgvLocaciones.DataSource = Nothing
            dgvCondicionesPago.DataSource = Nothing
            'dgvVendedores.DataSource = Nothing
        ElseIf campo = TAB_LOCACIONES Then
            dgvContactos.DataSource = Nothing
            dgvDireccionesFiscales.DataSource = Nothing
            dgvCondicionesPago.DataSource = Nothing
            'dgvVendedores.DataSource = Nothing
        ElseIf campo = TAB_CONDICIONES_PAGO Then
            dgvContactos.DataSource = Nothing
            dgvDireccionesFiscales.DataSource = Nothing
            dgvLocaciones.DataSource = Nothing
            'dgvVendedores.DataSource = Nothing
        ElseIf campo = TAB_VENDEDORES Then
            dgvContactos.DataSource = Nothing
            dgvDireccionesFiscales.DataSource = Nothing
            dgvLocaciones.DataSource = Nothing
            dgvCondicionesPago.DataSource = Nothing
        ElseIf campo = "Todos" Then
            dtDatos = Nothing
            dgvContactos.DataSource = Nothing
            dgvDireccionesFiscales.DataSource = Nothing
            dgvLocaciones.DataSource = Nothing
            dgvCondicionesPago.DataSource = Nothing
            'dgvVendedores.DataSource = Nothing
        End If
    End Sub
    Private Sub InitDataGrids()
        dgvContactos.BackgroundColor = Color.Beige
        dgvContactos.BackColor = Color.Beige
        dgvContactos.ForeColor = Color.MidnightBlue
        dgvContactos.AutoGenerateColumns = False

        dgvDireccionesFiscales.BackgroundColor = Color.Beige
        dgvDireccionesFiscales.BackColor = Color.Beige
        dgvDireccionesFiscales.ForeColor = Color.MidnightBlue
        dgvDireccionesFiscales.AutoGenerateColumns = False

        dgvLocaciones.BackgroundColor = Color.Beige
        dgvLocaciones.BackColor = Color.Beige
        dgvLocaciones.ForeColor = Color.MidnightBlue
        dgvLocaciones.AutoGenerateColumns = False

        dgvCondicionesPago.BackgroundColor = Color.Beige
        dgvCondicionesPago.BackColor = Color.Beige
        dgvCondicionesPago.ForeColor = Color.MidnightBlue
        dgvCondicionesPago.AutoGenerateColumns = False

        dgvVendedores.BackgroundColor = Color.Beige
        dgvVendedores.BackColor = Color.Beige
        dgvVendedores.ForeColor = Color.MidnightBlue
        dgvVendedores.AutoGenerateColumns = False

        dgvMoneda.BackgroundColor = Color.Beige
        dgvMoneda.BackColor = Color.Beige
        dgvMoneda.ForeColor = Color.MidnightBlue
        dgvMoneda.AutoGenerateColumns = False
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New ClienteService.Cliente
            registro.IdCliente = toNumber(txtIdCliente.Text)
            'If state_button = False And toNumber(txtIdCliente.Text) = 0 Then
            '  MsgBox("Debe Ingresar el código del Cliente", MsgBoxStyle.Information, "Información")
            '  txtIdCliente.BackColor = Color.Red
            '  txtIdCliente.Focus()
            '  Return False
            'Else
            If toNumber(cmbIdTipoCon.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de contribuyente del Cliente", MsgBoxStyle.Information, "Información")
                cmbIdTipoCon.BackColor = Color.Red
                cmbIdTipoCon.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de documento del Cliente", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.BackColor = Color.Red
                cmbTipoDoc.Focus()
                Return False
            ElseIf txtNroDoc.Text.Trim.Length = 0 And toBlank(cmbTipoDoc.Value) <> "0" Then
                MsgBox("Debe de Ingresar Nro. de Documento", MsgBoxStyle.Information, "Información")
                txtNroDoc.Text = ""
                txtNroDoc.Focus()
                Return False
            ElseIf txtNombre.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Nombre del Cliente", MsgBoxStyle.Information, "Información")
                txtNombre.BackColor = Color.Red
                txtNombre.Focus()
                Return False
            ElseIf txtApePat.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Apellido Paterno del Cliente", MsgBoxStyle.Information, "Información")
                txtApePat.BackColor = Color.Red
                txtApePat.Focus()
                Return False
            ElseIf txtApeMat.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Apellido Materno del Cliente", MsgBoxStyle.Information, "Información")
                txtApeMat.BackColor = Color.Red
                txtApeMat.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "6" And txtNroDoc.Text.Trim.Length <> 11 Then
                MsgBox("El R.U.C. es incorrecto...!", MsgBoxStyle.Information, "Información")
                txtNroDoc.BackColor = Color.Red
                txtNroDoc.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "1" And txtNroDoc.Text.Trim.Length <> 8 Then
                MsgBox("El D.N.I. es incorrecto...!", MsgBoxStyle.Information, "Información")
                txtNroDoc.BackColor = Color.Red
                txtNroDoc.Focus()
                Return False
                'ElseIf txtDniCli.Text.Trim.Length > 0 And (txtDniCli.Text.Trim.Length <> 8) Then
                '    MsgBox("El D.N.I. es incorrecto...!", MsgBoxStyle.Information, "Información")
                '    txtDniCli.BackColor = Color.Red
                '    txtDniCli.Focus()
                '    Return False
            ElseIf toNumber(cmbIdTipoCon.Value) = 1 And txtTelCli.Text = "" Then
                MsgBox("Debe de Ingresar el Teléfono", MsgBoxStyle.Information, "Información")
                txtTelCli.Text = ""
                txtTelCli.Focus()
                Return False
                'ElseIf toNumber(cmbIdTipoCon.Value) = 2 And txtDniCli.Text = "" Then
                '    MsgBox("Debe de Ingresar el DNI", MsgBoxStyle.Information, "Información")
                '    txtDniCli.Text = ""
                '    txtDniCli.Focus()
                '    Return False
                'ElseIf toNumber(cmbIdTipoCon.Value) = 4 And txtDniCli.Text = "" Then
                '    MsgBox("Debe de Ingresar el DNI", MsgBoxStyle.Information, "Información")
                '    txtDniCli.Text = ""
                '    txtDniCli.Focus()
                '    Return False
                'ElseIf toNumber(cmbIdTipoCon.Value) = 1 And txtNroDoc.Text.Trim.Length <> 11 Then
                '    MsgBox("El R.U.C. es incorrecto...!", MsgBoxStyle.Information, "Información")
                '    txtNroDoc.BackColor = Color.Red
                '    txtNroDoc.Focus()
                '    Return False
                'ElseIf toNumber(cmbIdTipoCon.Value) = 2 And txtDniCli.Text.Trim.Length <> 8 Then
                '    MsgBox("El D.N.I. es incorrecto...!", MsgBoxStyle.Information, "Información")
                '    txtDniCli.BackColor = Color.Red
                '    txtDniCli.Focus()
                '    Return False
                'ElseIf txtDirCli.Text = "" Then
                '    MsgBox("Debe Ingresar la dirección del Cliente", MsgBoxStyle.Information, "Información")
                '    txtDirCli.BackColor = Color.Red
                '    txtDirCli.Focus()
                '    Return False
            ElseIf cmbCodSec.Value = "" Then
                MsgBox("Debe Ingresar el sector del Cliente", MsgBoxStyle.Information, "Información")
                cmbCodSec.BackColor = Color.Red
                cmbCodSec.Focus()
                Return False
            ElseIf txtLimitecredito.Text > 0 And toBlank(cmbMoneda.Text) = "" Then
                MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbCodSec.BackColor = Color.Red
                cmbCodSec.Focus()
                Return False
            ElseIf cmbIdTipoCliente.Value = 0 Then
                MsgBox("Debe Ingresar el tipo de Cliente", MsgBoxStyle.Information, "Información")
                cmbIdTipoCliente.BackColor = Color.Red
                cmbIdTipoCliente.Focus()
                Return False
            ElseIf cmbMedioContacto.Value = 0 Then
                MsgBox("Debe Ingresar el medio de contacto del Cliente", MsgBoxStyle.Information, "Información")
                'cmbMedioContacto.BackColor = Color.Red
                cmbMedioContacto.Focus()
                Return False
                'ElseIf toBlank(cmbTipoDoc.Value) = "1" And state_button = False And oClienteService.BuscarDni(toNull(txtNroDoc.Text), Session.sCodEmp) = True Then
                '    MsgBox("El D.N.I. " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                '    txtNroDoc.Text = ""
                '    txtNroDoc.Focus()
                '    Return False
                'ElseIf (toBlank(cmbTipoDoc.Value) = "6") And state_button = False And oClienteService.BuscarRuc(toNull(Trim(txtNroDoc.Text)), Session.sCodEmp) = True Then
                '    MsgBox("El R.U.C. " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                '    txtNroDoc.Text = ""
                '    txtNroDoc.Focus()
                '    Return False
            ElseIf state_button = False And oClienteService.BuscarRuc(toNull(Trim(txtNroDoc.Text)), Session.sCodEmp) = True Then
                MsgBox("El Nro Documento " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtNroDoc.Text = ""
                txtNroDoc.Focus()
                Return False
                'ElseIf toBlank(txtUbigeo.Text) = "" And (toNumber(cmbIdTipoCon.Value) = 1 Or toNumber(cmbIdTipoCon.Value) = 2 Or toNumber(cmbIdTipoCon.Value) = 4) Then
                '    MsgBox("Debe Ingresar el Ubigeo del Cliente", MsgBoxStyle.Information, "Información")
                '    txtUbigeo.BackColor = Color.Red
                '    txtUbigeo.Text = ""
                '    txtUbigeo.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As ClienteService.Cliente)
        Try
            'Dim estado_process As Integer
            'estado_process = oClienteService.Insertar(Session.sCodEmp, registro)
            IdCliente = oClienteService.Insertar(registro)
            type_process = "insert"
            'If estado_process > 0 Then
            If IdCliente > 0 Then

                Dim frm As New frmAgregarDireccionFiscal
                frm.state_button = False
                frm.IdCliente = toNull(IdCliente)
                frm.NuevoContacto = True
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    'dtDatos = Nothing
                    'listaDirecionFiscal()
                End If
                '/////AGREGAR DIRECCION FISCAL////
                'If MsgBox("¿Está seguro de ASIGNAR la dirección ingresada como dirección fiscal del cliente?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                '    Dim direccionFiscal As New DireccionFiscalService.DireccionFiscal
                '    Dim cliente As New DireccionFiscalService.Cliente
                '    Dim ubigeo As New DireccionFiscalService.Ubigeo
                '    cliente.IdCliente = toNull(IdCliente)
                '    direccionFiscal.Cliente = cliente
                '    'direccionFiscal.Direccion = toNull(txtDirCli.Text)
                '    direccionFiscal.Direccion = Nothing
                '    ubigeo.CodUbigeo = CodUbigeo
                '    direccionFiscal.Ubigeo = ubigeo
                '    direccionFiscal.Vigente = True
                '    oDireccionFiscalService.Insertar(direccionFiscal)
                'End If
                '/////////////////////////////////

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ClienteService.Cliente)
        Try
            Dim estado_process As Boolean
            estado_process = oClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar(ByVal registro As ClienteService.Cliente)
        Try
            Dim estado_process As Boolean
            estado_process = oClienteService.Borrar(registro)
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
            Dim registro As ClienteService.Cliente
            'registro = oClienteService.MostrarPorID(toNumber(txtIdCliente.Text))
            registro = oClienteService.MostrarPorID(IdCliente)
            txtIdCliente.Text = toBlank(registro.IdCliente)
            txtDesCli.Text = toBlank(registro.DesCli)
            'txtDirCli.Text = toBlank(registro.DirCli)
            txtAbrCli.Text = toBlank(registro.AbrCli)
            txtNroDoc.Text = toBlank(registro.RucCli)
            txtDueCli.Text = toBlank(registro.DueCli)
            txtNumCta.Text = toBlank(registro.NumCta)
            txtDiaPago.Text = toBlank(registro.DiaPago)
            txtHoraPago.Text = toBlank(registro.HoraPago)
            txtDniCli.Text = toBlank(registro.DniCli)
            txtTelCli.Text = toBlank(registro.TelCli)
            txtFaxCli.Text = toBlank(registro.FaxCli)
            txtEmail.Text = toBlank(registro.Email)
            txtUrlCli.Text = toBlank(registro.UrlCli)
            txtObsCli.Text = toBlank(registro.ObsCli)
            txtNombre.Text = toBlank(registro.Nombres)
            txtApePat.Text = toBlank(registro.ApePat)
            txtApeMat.Text = toBlank(registro.ApeMat)
            txtFecIng.Text = toBlank(CDate(registro.FecIng))
            state_Search = True
            cmbTipoDoc.Value = registro.TipoDocumentoId.CodDoc
            cmbIdTipoCon.Value = registro.TipoContribuyente.IdTipoCon
            cmbCodSec.Value = toBlank(registro.SectorCliente.CodSec)
            cbAprCli.Checked = toBlank(registro.AprCli)
            cbListaCli.Checked = toBlank(registro.ListaCli)
            cmbIdTipoCliente.Value = registro.TipoCliente.IdTipoCliente
            cmbMedioContacto.Value = registro.TipoMedioContacto.IdMedio
            'CodUbigeo = registro.Ubigeo.CodUbigeo
            'txtUbigeo.Text = registro.Ubigeo.Departamento.NomDpto & " - " & toBlank(registro.Ubigeo.Provincia.NomProv) & " - " & toBlank(registro.Ubigeo.Distrito.NomDist)
            cmbEstado.Value = registro.Estado
            txtLimitecredito.Text = registro.LimiteCredito
            cmbMoneda.Value = registro.Moneda.CodMon
            cbAgente.Checked = toBlank(registro.Retenedor)
            'cbEstado.Checked = toBlank(registro.Estado)
            If oUsuarioClienteService.BuscarUsuario(IdCliente) Then
                ObtenerUsuario()
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '=================================== TIPO DE DOCUMENTO ========================================
            dtTipoDoc = oPersonaService.MostrarTipoDocumento.Tables(0)
            cmbTipoDoc.DataSource = dtTipoDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipoDoc = Nothing

            '======================================= TIPOS DE CONTRIBUYENTES =======================================
            dtTiposContribuyentes = oMaestro.MostrarTipoContribuyente.Tables(0)
            cmbIdTipoCon.DataSource = dtTiposContribuyentes
            cmbIdTipoCon.DropDownList.DataMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.DropDownList.DisplayMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.DropDownList.ValueMember = dtTiposContribuyentes.Columns("IdTipoCon").ToString
            cmbIdTipoCon.DropDownList.Columns(0).DataMember = dtTiposContribuyentes.Columns("IdTipoCon").ToString
            cmbIdTipoCon.DropDownList.Columns(1).DataMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.SelectedIndex = 0
            dtTiposContribuyentes = Nothing
            '======================================= SECTORES =========================================
            dtSectores = oMaestro.MostrarSectorCliente.Tables(0)
            cmbCodSec.DataSource = dtSectores
            cmbCodSec.DropDownList.DataMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.DropDownList.DisplayMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.DropDownList.ValueMember = dtSectores.Columns("CodSec").ToString
            cmbCodSec.DropDownList.Columns(0).DataMember = dtSectores.Columns("CodSec").ToString
            cmbCodSec.DropDownList.Columns(1).DataMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.SelectedIndex = 0
            dtSectores = Nothing
            '======================================= TIPOS DE CLIENTES =========================================
            dtTiposClientes = oMaestro.MostrarTipoCliente.Tables(0)
            cmbIdTipoCliente.DataSource = dtTiposClientes
            cmbIdTipoCliente.DropDownList.DataMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.DropDownList.DisplayMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.DropDownList.ValueMember = dtTiposClientes.Columns("IdTipoCliente").ToString
            cmbIdTipoCliente.DropDownList.Columns(0).DataMember = dtTiposClientes.Columns("IdTipoCliente").ToString
            cmbIdTipoCliente.DropDownList.Columns(1).DataMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.SelectedIndex = 0
            dtTiposClientes = Nothing
            ''======================================= ESTADOS DEL CLIENTE =========================================
            dtEstados = oClienteService.MostrarEstados.Tables(0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            dtEstados = Nothing

            '=============================================MONEDAS ==============================================
            dtMonedas = oMaestro.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '====================================== TIPO MEDIO CONTACTO ==========================================
            dtTipoMedioContacto = oClienteService.MostrarTipoMedioContacto.Tables(0)
            cmbMedioContacto.DataSource = dtTipoMedioContacto
            cmbMedioContacto.DropDownList.DataMember = dtTipoMedioContacto.Columns("DesMedio").ToString
            cmbMedioContacto.DropDownList.DisplayMember = dtTipoMedioContacto.Columns("DesMedio").ToString
            cmbMedioContacto.DropDownList.ValueMember = dtTipoMedioContacto.Columns("IdMedio").ToString
            cmbMedioContacto.DropDownList.Columns(0).DataMember = dtTipoMedioContacto.Columns("IdMedio").ToString
            cmbMedioContacto.DropDownList.Columns(1).DataMember = dtTipoMedioContacto.Columns("DesMedio").ToString
            cmbMedioContacto.SelectedIndex = 0
            dtTipoMedioContacto = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado(ByVal campo As DataGridView) As Boolean
        Try
            If campo.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf campo.CurrentRow.Index < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf campo.Item(0, campo.CurrentRow.Index).Value = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub listaContactos()
        Try
            dtDatos = oContactoService.Mostrar(toNumber(txtIdCliente.Text)).Tables(0)
            dgvContactos.DataSource = dtDatos

            cIdContacto.DataPropertyName = dtDatos.Columns("IdContacto").ColumnName
            cNombres.DataPropertyName = dtDatos.Columns("Nombres").ColumnName
            cApellidos.DataPropertyName = dtDatos.Columns("Apellidos").ColumnName

            enableOpciones(dgvContactos)

        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDirecionFiscal()
        Try
            dtDatos = oDireccionFiscalService.Mostrar(toNumber(txtIdCliente.Text)).Tables(0)
            dgvDireccionesFiscales.DataSource = dtDatos
            cIdFiscal.DataPropertyName = dtDatos.Columns("IdFiscal").ColumnName
            cDireccion.DataPropertyName = dtDatos.Columns("Direccion").ColumnName

            enableOpciones(dgvDireccionesFiscales)
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaLocacionesCliente()
        Try
            dtDatos = oLocacionClienteService.Mostrar(toNumber(txtIdCliente.Text)).Tables(0)
            dgvLocaciones.DataSource = dtDatos
            cIdLocCli.DataPropertyName = dtDatos.Columns("IdLocCli").ColumnName
            cNombre.DataPropertyName = dtDatos.Columns("Nombre").ColumnName
            cEmail.DataPropertyName = dtDatos.Columns("Email").ColumnName

            enableOpciones(dgvLocaciones)
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaCondicionesPago()
        Try
            dtDatos = oCondicionPagoClienteService.Mostrar(toNumber(txtIdCliente.Text)).Tables(0)
            dgvCondicionesPago.DataSource = dtDatos
            cDesRub.DataPropertyName = dtDatos.Columns("DesRub").ColumnName
            cDesPag.DataPropertyName = dtDatos.Columns("DesPag").ColumnName
            cDiaPag.DataPropertyName = dtDatos.Columns("DiaPag").ColumnName
            cCodPag.DataPropertyName = dtDatos.Columns("CodPag").ColumnName
            cCodRub.DataPropertyName = dtDatos.Columns("CodRub").ColumnName

            enableOpciones(dgvCondicionesPago)
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarContacto()
        Try
            Dim frm As New frmAgregarContacto
            frm.state_button = True
            frm.txtIdContacto.Text = dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value

            dgvContactos.Rows(dgvContactos.CurrentRow.Index).Selected = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaContactos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvContactos, dtDatos, "IdContacto", frm.txtIdContacto.Text.Trim)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDireccionFiscal()
        Try
            Dim frm As New frmAgregarDireccionFiscal
            frm.state_button = True
            frm.txtIdFiscal.Text = dgvDireccionesFiscales.Item("cIdFiscal", dgvDireccionesFiscales.CurrentRow.Index).Value

            dgvDireccionesFiscales.Rows(dgvDireccionesFiscales.CurrentRow.Index).Selected = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDirecionFiscal()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDireccionesFiscales, dtDatos, "IdFiscal", frm.txtIdFiscal.Text.Trim)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-013]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarLocacionCliente()
        Try
            Dim frm As New frmAgregarLocacionCliente
            frm.state_button = True
            frm.txtIdLocCli.Text = dgvLocaciones.Item("cIdLocCli", dgvLocaciones.CurrentRow.Index).Value

            dgvLocaciones.Rows(dgvLocaciones.CurrentRow.Index).Selected = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaLocacionesCliente()
                If frm.type_process = "update" Then
                    RowPossesion(dgvLocaciones, dtDatos, "IdLocCli", frm.txtIdLocCli.Text.Trim)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarCondicionPago()
        Try
            Dim frm As New frmAgregarCondicionPago
            frm.state_button = True
            frm.IdCliente = toNumber(txtIdCliente.Text)
            frm.cmbCodRub.Value = dgvCondicionesPago.Item("cCodRub", dgvCondicionesPago.CurrentRow.Index).Value

            dgvCondicionesPago.Rows(dgvCondicionesPago.CurrentRow.Index).Selected = True
            'Or Session.CodPerfil = "28"
            If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Then     '------ Se agrega el Perfil de Costos 02/08/2016
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaContactos()
                    If frm.type_process = "update" Then
                        'RowPossesion(dgvCondicionesPago, dtDatos, "CodPag", frm.cmbCodPag.Value.Text.Trim)
                    Else
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
            Else
                MsgBox("Su perfil no tiene permiso para modificar la Condicion de Pago")
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-015]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarContacto()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New ContactoService.Contacto
                Dim cliente As New ContactoService.Cliente
                registro.IdContacto = dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value
                cliente.IdCliente = toNumber(txtIdCliente.Text)
                registro.Cliente = cliente
                estado_process = oContactoService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaContactos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-016]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDireccionFiscal()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDireccionesFiscales.Item("cIdFiscal", dgvDireccionesFiscales.CurrentRow.Index).Value.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New DireccionFiscalService.DireccionFiscal
                Dim cliente As New DireccionFiscalService.Cliente
                registro.IdFiscal = dgvDireccionesFiscales.Item("cIdFiscal", dgvDireccionesFiscales.CurrentRow.Index).Value
                cliente.IdCliente = toNumber(txtIdCliente.Text)
                registro.Cliente = cliente
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                estado_process = oDireccionFiscalService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDirecionFiscal()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-017]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarLocacionCliente()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvLocaciones.Item("cIdLocCli", dgvLocaciones.CurrentRow.Index).Value.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New LocacionClienteService.LocacionCliente
                Dim cliente As New LocacionClienteService.Cliente
                registro.IdLocCli = dgvLocaciones.Item("cIdLocCli", dgvLocaciones.CurrentRow.Index).Value
                cliente.IdCliente = toNumber(txtIdCliente.Text)
                registro.Cliente = cliente
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                estado_process = oLocacionClienteService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaLocacionesCliente()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-018]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarCondicionPago()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con Rubro = " _
                      + dgvCondicionesPago.Item("cCodRub", dgvCondicionesPago.CurrentRow.Index).Value.ToString _
                      + " y Condición Pago =" + dgvCondicionesPago.Item("cCodPag", dgvCondicionesPago.CurrentRow.Index).Value.ToString + " ?" _
                      , MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New CondicionPagoClienteService.CondicionPagoCliente
                Dim rubro As New CondicionPagoClienteService.Rubro
                Dim condicionPago As New CondicionPagoClienteService.CondicionPago
                Dim cliente As New CondicionPagoClienteService.Cliente

                rubro.CodRub = dgvCondicionesPago.Item("cCodRub", dgvCondicionesPago.CurrentRow.Index).Value
                registro.Rubro = rubro
                condicionPago.CodPag = dgvCondicionesPago.Item("cCodPag", dgvCondicionesPago.CurrentRow.Index).Value
                registro.CondicionPago = condicionPago
                cliente.IdCliente = toNumber(txtIdCliente.Text)
                registro.Cliente = cliente
                estado_process = oCondicionPagoClienteService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaCondicionesPago()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-019]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoContacto()
        Try
            Dim frm As New frmAgregarContacto
            frm.state_button = False
            frm.IdCliente = toNull(txtIdCliente.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtIdCliente.Text.Trim)
                listaContactos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvContactos, dtDatos, "IdContacto", frm.txtIdContacto.Text.Trim)
                    'mostrarContacto()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-020]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDireccionFiscal()
        Try
            Dim frm As New frmAgregarDireccionFiscal
            frm.state_button = False
            frm.IdCliente = toNull(txtIdCliente.Text)
            frm.NuevoContacto = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDirecionFiscal()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDireccionesFiscales, dtDatos, "IdFiscal", frm.txtIdFiscal.Text.Trim)
                    'mostrarDireccionFiscal()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-021]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoLocacionCliente()
        Try
            Dim frm As New frmAgregarLocacionCliente
            frm.state_button = False
            frm.IdCliente = toNull(txtIdCliente.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtIdCliente.Text.Trim)
                listaLocacionesCliente()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvLocaciones, dtDatos, "IdLocCli", frm.txtIdLocCli.Text.Trim)
                    'mostrarLocacionCliente()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-022]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoCondicionPago()
        Try
            Dim frm As New frmAgregarCondicionPago
            frm.state_button = False
            frm.IdCliente = toNull(txtIdCliente.Text)
            'Or Session.CodPerfil = "28" 
            If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Then     '------ Se agrega el Perfil de Costos 02/08/2016
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    'limpiaOpcionesBusqueda("insert", frm.txtIdCliente.Text.Trim)
                    listaCondicionesPago()
                    If frm.type_process = "insert" Then
                        'RowPossesion(dgvContactos, dtDatos, "CodPag", frm.cmbCodPag.Value)
                        'mostrarCondicionPago()
                    End If
                End If
            Else
                MsgBox("Su perfil no tiene permiso para agregar una Condicion de Pago")
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-023]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizarLista(ByVal campo As DataGridView)
        Try
            Dim codigo As String = ""
            If campo.RowCount > 0 Then
                codigo = campo.Item(0, campo.CurrentRow.Index).Value
            End If
            dtDatos = Nothing
            If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
                listaContactos()
                If campo.RowCount > 0 And codigo.Trim.Length > 0 Then
                    RowPossesion(campo, dtDatos, "IdContacto", codigo)
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
                listaDirecionFiscal()
                If campo.RowCount > 0 And codigo.Trim.Length > 0 Then
                    RowPossesion(campo, dtDatos, "IdFiscal", codigo)
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
                listaLocacionesCliente()
                If campo.RowCount > 0 And codigo.Trim.Length > 0 Then
                    RowPossesion(campo, dtDatos, "IdLocCli", codigo)
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
                listaCondicionesPago()
                If campo.RowCount > 0 And codigo.Trim.Length > 0 Then
                    RowPossesion(campo, dtDatos, "CodPag", codigo)
                End If
            ElseIf tabVentanas.SelectedTab.Name = TAB_VENDEDORES Then
                listaVendedores()
                If campo.RowCount > 0 And codigo.Trim.Length > 0 Then
                    'RowPossesion(campo, dtDatos, "", codigo)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-024]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        'btnUbigeo.Enabled = True
        txtDesCli.ReadOnly = False
        'txtDirCli.ReadOnly = False
        txtDueCli.ReadOnly = False
        txtFaxCli.ReadOnly = False
        txtEmail.ReadOnly = False
        txtObsCli.ReadOnly = False
        txtNroDoc.ReadOnly = False
        txtNroDoc.BackColor = System.Drawing.SystemColors.Window
        txtAbrCli.ReadOnly = False
        txtTelCli.ReadOnly = False
        txtDniCli.ReadOnly = False
        txtUrlCli.ReadOnly = False
        txtNumCta.ReadOnly = False
        txtDiaPago.ReadOnly = False
        txtHoraPago.ReadOnly = False
        txtNombre.ReadOnly = False
        txtApePat.ReadOnly = False
        txtApeMat.ReadOnly = False

        If toBlank(cmbTipoDoc.Value) = "1" Then
            txtDesCli.BackColor = System.Drawing.SystemColors.Control
            txtDesCli.ReadOnly = True
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtNombre.ReadOnly = False
            txtApePat.BackColor = System.Drawing.SystemColors.Window
            txtApePat.ReadOnly = False
            txtApeMat.BackColor = System.Drawing.SystemColors.Window
            txtApeMat.ReadOnly = False

            lblAstRazSoc.Visible = False
            lblAstNombre.Visible = True
            lblAstApePat.Visible = True
            lblAstApeMat.Visible = True
            lblAstDni.Visible = True
        Else
            txtDesCli.BackColor = System.Drawing.SystemColors.Window
            txtDesCli.ReadOnly = False
            txtNombre.ReadOnly = False
            txtApePat.BackColor = System.Drawing.SystemColors.Window
            txtApePat.ReadOnly = False
            txtApeMat.BackColor = System.Drawing.SystemColors.Window
            txtApeMat.ReadOnly = False

            lblAstRazSoc.Visible = True
            lblAstNombre.Visible = False
            lblAstApePat.Visible = False
            lblAstApeMat.Visible = False
            lblAstDni.Visible = False
        End If

        cmbIdTipoCliente.ReadOnly = False
        cmbIdTipoCliente.BackColor = System.Drawing.SystemColors.Window
        cmbCodSec.ReadOnly = False
        cmbCodSec.BackColor = System.Drawing.SystemColors.Window
        cmbMedioContacto.ReadOnly = False
        cmbMedioContacto.BackColor = System.Drawing.SystemColors.Window
        cmbIdTipoCon.ReadOnly = False
        cmbIdTipoCon.BackColor = System.Drawing.SystemColors.Window
        cmbTipoDoc.ReadOnly = False
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window

        If Session.CodPerfil = "12" Or Session.CodPerfil = "22" Or Session.CodPerfil = "54" Or Session.CodPerfil = "05" Or Session.CodPerfil = "01" Then
            cmbEstado.ReadOnly = False
            cmbEstado.BackColor = System.Drawing.SystemColors.Window
            txtLimitecredito.ReadOnly = False
            txtLimitecredito.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            cbAprCli.Enabled = True
            ' Por default se pone moneda NS cuando se activa para ingresar el limite credito
            If toBlank(cmbMoneda.Value) = "" Then
                cmbMoneda.Value = "NS"
            End If
            'ElseIf Session.CodPerfil = "11" Or Session.CodPerfil = "05" Then  '--SE DESACTIVA A PEDIDO DE ERCIK 20/10/2020 '------ Se agrega el Perfil de Costos 02/08/2016
            '    cmbEstado.ReadOnly = False
            '    cmbEstado.BackColor = System.Drawing.SystemColors.Window
            '    txtLimitecredito.ReadOnly = True
            '    txtLimitecredito.BackColor = System.Drawing.SystemColors.Control
            '    cmbMoneda.ReadOnly = True
            '    cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        Else
            cmbEstado.ReadOnly = True
            cmbEstado.BackColor = System.Drawing.SystemColors.Control
            txtLimitecredito.ReadOnly = True
            txtLimitecredito.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            cbAprCli.Enabled = False
        End If

        ' cbEstado.Enabled = True
        'cbListaCli.Enabled = True
        'cbAprCli.Enabled = True
        cbAgente.Enabled = True
    End Sub
    Private Sub desactivar()
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

        'btnUbigeo.Enabled = False
        txtDesCli.ReadOnly = True
        'txtDirCli.ReadOnly = True
        txtDueCli.ReadOnly = True
        txtFaxCli.ReadOnly = True
        txtEmail.ReadOnly = True
        txtObsCli.ReadOnly = True
        txtNroDoc.ReadOnly = True
        txtNroDoc.BackColor = System.Drawing.SystemColors.Control
        txtAbrCli.ReadOnly = True
        txtTelCli.ReadOnly = True
        txtDniCli.ReadOnly = True
        txtUrlCli.ReadOnly = True
        txtNumCta.ReadOnly = True
        txtDiaPago.ReadOnly = True
        txtHoraPago.ReadOnly = True
        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtApePat.ReadOnly = True
        txtApePat.BackColor = System.Drawing.SystemColors.Control
        txtApeMat.ReadOnly = True
        txtApeMat.BackColor = System.Drawing.SystemColors.Control
        cmbIdTipoCliente.ReadOnly = True
        cmbIdTipoCliente.BackColor = System.Drawing.SystemColors.Control
        cmbCodSec.ReadOnly = True
        cmbCodSec.BackColor = System.Drawing.SystemColors.Control
        cmbIdTipoCon.ReadOnly = True
        cmbIdTipoCon.BackColor = System.Drawing.SystemColors.Control
        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        cmbMedioContacto.ReadOnly = True
        cmbMedioContacto.BackColor = System.Drawing.SystemColors.Control
        cmbEstado.ReadOnly = True
        cmbEstado.BackColor = System.Drawing.SystemColors.Control
        txtLimitecredito.ReadOnly = True
        txtLimitecredito.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        'cbEstado.Enabled = False
        'cbListaCli.Enabled = False
        cbAgente.Enabled = False
        cbAgente.Enabled = False
        gbSubDatos1.Visible = True
        cbAprCli.Enabled = False
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================

    Private Sub tabVentanas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles tabVentanas.SelectedTabChanged
        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
            listaContactos()
        ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
            listaDirecionFiscal()
        ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
            listaLocacionesCliente()
        ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
            listaCondicionesPago()
            ValidarUsuarioCondPago()
        ElseIf tabVentanas.SelectedTab.Name = TAB_VENDEDORES Then
            listaVendedores()
        ElseIf tabVentanas.SelectedTab.Name = TAB_MONEDA Then
            listaMoneda()
            ValidarUsuarioMoneda()
        End If
        limpiaDataGrids(tabVentanas.SelectedTab.Name)
    End Sub
    Private Sub EjecutaDataGrids_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                           dgvDireccionesFiscales.DoubleClick _
                        , dgvLocaciones.DoubleClick _
                        , dgvCondicionesPago.DoubleClick, dgvContactos.DoubleClick

        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
            If ValidaCodigoSeleccionado(dgvContactos) Then
                mostrarContacto()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
            If ValidaCodigoSeleccionado(dgvDireccionesFiscales) Then
                mostrarDireccionFiscal()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
            If ValidaCodigoSeleccionado(dgvLocaciones) Then
                mostrarLocacionCliente()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
            If ValidaCodigoSeleccionado(dgvCondicionesPago) Then
                mostrarCondicionPago()
            End If
        End If
        limpiaDataGrids(tabVentanas.SelectedTab.Name)
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
            If ValidaCodigoSeleccionado(dgvContactos) Then
                eliminarContacto()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
            If ValidaCodigoSeleccionado(dgvDireccionesFiscales) Then
                eliminarDireccionFiscal()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
            If ValidaCodigoSeleccionado(dgvLocaciones) Then
                eliminarLocacionCliente()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
            If ValidaCodigoSeleccionado(dgvCondicionesPago) Then
                eliminarCondicionPago()
            End If
        End If
        limpiaDataGrids(tabVentanas.SelectedTab.Name)
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
            actualizarLista(dgvContactos)
        ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
            actualizarLista(dgvDireccionesFiscales)
        ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
            actualizarLista(dgvLocaciones)
        ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
            actualizarLista(dgvCondicionesPago)
        End If
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
            NuevoContacto()
        ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
            NuevoDireccionFiscal()
        ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
            NuevoLocacionCliente()
        ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
            NuevoCondicionPago()
        End If
    End Sub
    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        NuevoContacto()
    End Sub
    Private Sub btnAgregarDireccionFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDireccionFiscal.Click
        NuevoDireccionFiscal()
    End Sub
    Private Sub btnAgregarLocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLocacion.Click
        NuevoLocacionCliente()
    End Sub
    Private Sub btnAgregarCondicionPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCondicionPago.Click
        NuevoCondicionPago()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        And ValidaCampos() Then

            Dim registro As New ClienteService.Cliente
            Dim tipoContribuyente As New ClienteService.TipoContribuyente
            Dim sector As New ClienteService.SectorCliente
            Dim tipoCliente As New ClienteService.TipoCliente
            Dim Moneda As New ClienteService.Moneda
            Dim Empresa As New ClienteService.Empresa
            Dim MedioContacto As New ClienteService.TipoMedioContacto          '------- Agregado el 08/05/2014 Jacquelin Solicitud de Usuario: 3942
            'Dim ubigeo As New ClienteService.Ubigeo
            Dim tipodoc As New ClienteService.TipoDocumentoId

            registro.IdCliente = toNumber(txtIdCliente.Text)
            tipoContribuyente.IdTipoCon = toNumber(cmbIdTipoCon.Value)
            registro.TipoContribuyente = tipoContribuyente
            tipodoc.CodDoc = cmbTipoDoc.Value
            registro.TipoDocumentoId = tipodoc
            registro.DesCli = toNull(txtDesCli.Text)
            'registro.DirCli = toNull(txtDirCli.Text)
            registro.AbrCli = toNull(txtAbrCli.Text)
            registro.RucCli = toNull(txtNroDoc.Text)
            registro.DueCli = toNull(txtDueCli.Text)
            registro.NumCta = toNull(txtNumCta.Text)
            registro.DiaPago = toNull(txtDiaPago.Text)
            registro.HoraPago = toNull(txtHoraPago.Text)
            registro.DniCli = toNull(txtDniCli.Text)
            registro.TelCli = toNull(txtTelCli.Text)
            registro.FaxCli = toNull(txtFaxCli.Text)
            registro.Email = toNull(txtEmail.Text)
            registro.UrlCli = toNull(txtUrlCli.Text)
            registro.ObsCli = toNull(txtObsCli.Text)
            sector.CodSec = toNull(cmbCodSec.Value)
            registro.SectorCliente = sector
            registro.AprCli = cbAprCli.Checked
            registro.ListaCli = cbListaCli.Checked
            tipoCliente.IdTipoCliente = toNumber(cmbIdTipoCliente.Value)
            registro.TipoCliente = tipoCliente
            MedioContacto.IdMedio = toNumber(cmbMedioContacto.Value)
            registro.TipoMedioContacto = MedioContacto
            'ubigeo.CodUbigeo = CodUbigeo
            'registro.Ubigeo = ubigeo
            'registro.Estado = cbEstado.Checked
            registro.Estado = cmbEstado.Value
            registro.LimiteCredito = txtLimitecredito.Value
            registro.Retenedor = cbAgente.Checked
            If txtLimitecredito.Value <= 0 Then
                Moneda.CodMon = Nothing
                registro.Moneda = Moneda
            Else
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
            End If

            registro.Nombres = toNull(txtNombre.Text)
            registro.ApePat = toNull(txtApePat.Text)
            registro.ApeMat = toNull(txtApeMat.Text)
            registro.CodUsu = Session.sCodUsu

            Empresa.CodEmp = Session.sCodEmp
            registro.Empresa = Empresa

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        oClienteService.Close()
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub


    'Private Sub btnUbigeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmBuscarUbigeo

    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        CodUbigeo = frm.CodUbigeo
    '        txtUbigeo.BackColor = System.Drawing.SystemColors.Control
    '        txtUbigeo.Text = frm.Nombre
    '    End If
    '    txtUbigeo.Select()
    'End Sub


    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click

        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If

    End Sub

    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar Detalles del Cliente."
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en Detalles Cliente."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en Detalles Cliente."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Cliente."
    End Sub
    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Cliente ."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave, _
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave, _
                                   miNuevo.MouseLeave, miModificar.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub


    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
            If ValidaCodigoSeleccionado(dgvContactos) Then
                mostrarContacto()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_DIRECCIONES_FISCALES Then
            If ValidaCodigoSeleccionado(dgvDireccionesFiscales) Then
                mostrarDireccionFiscal()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_LOCACIONES Then
            If ValidaCodigoSeleccionado(dgvLocaciones) Then
                mostrarLocacionCliente()
            End If
        ElseIf tabVentanas.SelectedTab.Name = TAB_CONDICIONES_PAGO Then
            If ValidaCodigoSeleccionado(dgvCondicionesPago) Then
                mostrarCondicionPago()
            End If
        End If
    End Sub

    'Private Sub cmbIdTipoCon_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIdTipoCon.ValueChanged
    '    If cmbIdTipoCon.Value = 2 Then
    '        txtNombre.Enabled = True
    '        txtNombre.BackColor = System.Drawing.SystemColors.Window
    '        txtApePat.Enabled = True
    '        txtApePat.BackColor = System.Drawing.SystemColors.Window
    '        txtApeMat.Enabled = True
    '        txtApeMat.BackColor = System.Drawing.SystemColors.Window
    '        lblNombre.Enabled = True
    '        lblApeMat.Enabled = True
    '        lblApePat.Enabled = True
    '        txtDesCli.Enabled = False
    '        txtDesCli.BackColor = System.Drawing.SystemColors.Control
    '        lblRazonSocial.Enabled = False
    '        txtDesCli.Text = ""
    '        lblAstTelef.Visible = False
    '        lblAstDni.Visible = True
    '        lblAstRuc.Visible = False
    '        lblAstRazSoc.Visible = False
    '        lblAstNombre.Visible = True
    '        lblAstApePat.Visible = True
    '        lblAstApeMat.Visible = True
    '        'lblAstUbicacion.Visible = True
    '    ElseIf cmbIdTipoCon.Value = 1 Then
    '        txtNombre.Enabled = False
    '        txtNombre.BackColor = System.Drawing.SystemColors.Control
    '        txtApePat.Enabled = False
    '        txtApePat.BackColor = System.Drawing.SystemColors.Control
    '        txtApeMat.Enabled = False
    '        txtApeMat.BackColor = System.Drawing.SystemColors.Control
    '        lblNombre.Enabled = False
    '        lblApeMat.Enabled = False
    '        lblApePat.Enabled = False
    '        txtDesCli.Enabled = True
    '        txtDesCli.BackColor = System.Drawing.SystemColors.Window
    '        lblRazonSocial.Enabled = True
    '        txtNombre.Text = ""
    '        txtApePat.Text = ""
    '        txtApeMat.Text = ""
    '        lblAstTelef.Visible = True
    '        lblAstDni.Visible = False
    '        lblAstRuc.Visible = True
    '        lblAstRazSoc.Visible = True
    '        lblAstNombre.Visible = False
    '        lblAstApePat.Visible = False
    '        lblAstApeMat.Visible = False
    '        'lblAstUbicacion.Visible = True
    '    ElseIf cmbIdTipoCon.Value = 3 Then
    '        txtNombre.Enabled = False
    '        txtNombre.BackColor = System.Drawing.SystemColors.Control
    '        txtApePat.Enabled = False
    '        txtApePat.BackColor = System.Drawing.SystemColors.Control
    '        txtApeMat.Enabled = False
    '        txtApeMat.BackColor = System.Drawing.SystemColors.Control
    '        lblNombre.Enabled = False
    '        lblApeMat.Enabled = False
    '        lblApePat.Enabled = False
    '        txtDesCli.Enabled = True
    '        txtDesCli.BackColor = System.Drawing.SystemColors.Window
    '        lblRazonSocial.Enabled = True
    '        txtNombre.Text = ""
    '        txtApePat.Text = ""
    '        txtApeMat.Text = ""
    '        lblAstTelef.Visible = False
    '        lblAstDni.Visible = False
    '        lblAstRuc.Visible = False
    '        lblAstRazSoc.Visible = True
    '        lblAstNombre.Visible = False
    '        lblAstApePat.Visible = False
    '        lblAstApeMat.Visible = False
    '        'lblAstUbicacion.Visible = False

    '    ElseIf cmbIdTipoCon.Value = 4 Then
    '        txtNombre.Enabled = False
    '        txtNombre.BackColor = System.Drawing.SystemColors.Control
    '        txtApePat.Enabled = False
    '        txtApePat.BackColor = System.Drawing.SystemColors.Control
    '        txtApeMat.Enabled = False
    '        txtApeMat.BackColor = System.Drawing.SystemColors.Control
    '        lblNombre.Enabled = False
    '        lblApeMat.Enabled = False
    '        lblApePat.Enabled = False
    '        txtDesCli.Enabled = True
    '        txtDesCli.BackColor = System.Drawing.SystemColors.Window
    '        lblRazonSocial.Enabled = True
    '        txtNombre.Text = ""
    '        txtApePat.Text = ""
    '        txtApeMat.Text = ""
    '        lblAstTelef.Visible = False
    '        lblAstDni.Visible = False
    '        lblAstRuc.Visible = False
    '        lblAstRazSoc.Visible = True
    '        lblAstNombre.Visible = False
    '        lblAstApePat.Visible = False
    '        lblAstApeMat.Visible = False
    '        'lblAstUbicacion.Visible = True
    '    End If
    'End Sub

    Private Sub listaVendedores()
        Try
            dtDatos = oVendedorClienteService.MostrarVendedorAsignado(Session.sCodEmp, toNumber(txtIdCliente.Text)).Tables(0)
            dgvVendedores.DataSource = dtDatos

            cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
            cApeNom.DataPropertyName = dtDatos.Columns("ApeNom").ColumnName
            cDesVen.DataPropertyName = dtDatos.Columns("DesVen").ColumnName
            cFecAsig.DataPropertyName = dtDatos.Columns("FecAsig").ColumnName
            cObservacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName

            'enableOpciones(dgvVendedores)
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivar.Click
        NuevaMoneda()
    End Sub

    Private Sub NuevaMoneda()
        Try
            Dim frm As New frmAgregarMoneda
            frm.IdCliente = IdCliente

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtMoneda = Nothing

                'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaMoneda()
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-022]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaMoneda()
        Try
            dtMoneda = oClienteService.MostrarMonedaCliente(IdCliente).Tables(0)
            dgvMoneda.DataSource = dtMoneda

        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarLocMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminarLocMoneda.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR la Locación Moneda : " & dgvMoneda.CurrentRow.Cells("DesOfi").Value & " - " & dgvMoneda.CurrentRow.Cells("DesAlm").Value & " ?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then

                Dim estado_eliminar As Boolean
                estado_eliminar = oClienteService.BorrarMonedaCliente(dgvMoneda.CurrentRow.Cells("IdLocacion").Value, IdCliente, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If estado_eliminar = True Then
                    dtMoneda = Nothing
                    listaMoneda()
                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA MONEDA", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ValidarUsuarioMoneda()
        If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Or Session.CodPerfil = "28" Then     '------ Se agrega el Perfil de Costos 02/08/2016
            cmbOpciones2.Enabled = True
            btnActivar.Enabled = True
        Else
            cmbOpciones2.Enabled = False
            btnActivar.Enabled = False
        End If
    End Sub

    Private Sub ValidarUsuarioCondPago()
        'Or Session.CodPerfil = "28"
        If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Then     '------ Se agrega el Perfil de Costos 02/08/2016
            cmOpciones.Enabled = True
            btnAgregarCondicionPago.Enabled = True
        Else
            cmOpciones.Enabled = False
            btnAgregarCondicionPago.Enabled = False
        End If
    End Sub

    Private Sub btnGenerarUsuario_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarUsuario.Click
        Try
            If oUsuarioClienteService.BuscarUsuario(IdCliente) Then
                MsgBox("¡Este Cliente ya tiene un Usuario registrado, Verifique!", MsgBoxStyle.Information, "Información")
            Else
                Dim frm As New frmCliente_Usuario
                frm.IdCliente = toNull(txtIdCliente.Text)
                frm.Actualizar = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ObtenerUsuario()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnActCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnActCorreo.Click
        Try
            If oUsuarioClienteService.BuscarUsuario(IdCliente) = False Then
                MsgBox("¡Este Cliente aún no tiene un Usuario registrado, Verifique!", MsgBoxStyle.Information, "Información")
            Else
                Dim frm As New frmCliente_Usuario
                frm.IdCliente = toNull(txtIdCliente.Text)
                frm.Actualizar = True
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ObtenerUsuario()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR CORREO DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerUsuario()
        Try
            Dim registro As New UsuarioClienteService.UsuarioCliente
            registro = oUsuarioClienteService.ObtenerUsuario(IdCliente)
            txtUsuario.Text = registro.Usuario
            txtCorreo.Text = registro.Correo
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbTipoDoc_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbTipoDoc.ValueChanged


        If toBlank(cmbTipoDoc.Value) = "6" Or toBlank(cmbTipoDoc.Value) = "0" Then
            txtDesCli.BackColor = System.Drawing.SystemColors.Window
            txtDesCli.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Control
            txtNombre.ReadOnly = True
            txtApePat.BackColor = System.Drawing.SystemColors.Control
            txtApePat.ReadOnly = True
            txtApeMat.BackColor = System.Drawing.SystemColors.Control
            txtApeMat.ReadOnly = True

            lblAstRazSoc.Visible = True
            lblAstNombre.Visible = False
            lblAstApePat.Visible = False
            lblAstApeMat.Visible = False
            lblAstDni.Visible = False

            txtNombre.Text = ""
            txtApePat.Text = ""
            txtApeMat.Text = ""
        Else
            txtDesCli.BackColor = System.Drawing.SystemColors.Control
            txtDesCli.ReadOnly = True
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtNombre.ReadOnly = False
            txtApePat.BackColor = System.Drawing.SystemColors.Window
            txtApePat.ReadOnly = False
            txtApeMat.BackColor = System.Drawing.SystemColors.Window
            txtApeMat.ReadOnly = False

            lblAstRazSoc.Visible = False
            lblAstNombre.Visible = True
            lblAstApePat.Visible = True
            lblAstApeMat.Visible = True
            lblAstDni.Visible = True
        End If




    End Sub


    Private Async Sub ConsultarRuc()

        Dim tipoRespuesta As Integer = 2
        Dim mensajeRespuesta As String = ""
        txtDesCli.Text = ""
        'txtTipoContribuyente.Text = ""
        txtAbrCli.Text = ""
        'txtDirProv.Text = ""
        Dim ruc As String = txtNroDoc.Text
        If String.IsNullOrWhiteSpace(ruc) Then Return
        Dim oCuTexto As CuTexto = New CuTexto()
        Dim oCronometro As Stopwatch = New Stopwatch()
        oCronometro.Start()
        btnConsultaSunat.Enabled = False
        Dim cookies As CookieContainer = New CookieContainer()
        Dim controladorMensaje As HttpClientHandler = New HttpClientHandler()
        controladorMensaje.CookieContainer = cookies
        controladorMensaje.UseCookies = True

        Dim ObjRuc As New ConsultaRUC

        Using cliente As HttpClient = New HttpClient(controladorMensaje)
            cliente.DefaultRequestHeaders.Add("Host", "e-consultaruc.sunat.gob.pe")
            cliente.DefaultRequestHeaders.Add("sec-ch-ua", " "" Not A;Brand"";v=""99"", ""Chromium"";v=""90"", ""Google Chrome"";v=""90""")
            cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1")
            cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1")
            cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
            Await Task.Delay(100)
            Dim url As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias"

            Using resultadoConsulta As HttpResponseMessage = Await cliente.GetAsync(New Uri(url))

                If resultadoConsulta.IsSuccessStatusCode Then
                    Await Task.Delay(100)
                    cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site")
                    cliente.DefaultRequestHeaders.Add("Origin", "https://e-consultaruc.sunat.gob.pe")
                    cliente.DefaultRequestHeaders.Add("Referer", url)
                    cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin")
                    Dim numeroDNI As String = "10048380"
                    Dim lClaveValor = New List(Of KeyValuePair(Of String, String)) From {
                        New KeyValuePair(Of String, String)("accion", "consPorTipdoc"),
                        New KeyValuePair(Of String, String)("razSoc", ""),
                        New KeyValuePair(Of String, String)("nroRuc", ""),
                        New KeyValuePair(Of String, String)("nrodoc", numeroDNI),
                        New KeyValuePair(Of String, String)("contexto", "ti-it"),
                        New KeyValuePair(Of String, String)("modo", "1"),
                        New KeyValuePair(Of String, String)("search1", ""),
                        New KeyValuePair(Of String, String)("rbtnTipo", "2"),
                        New KeyValuePair(Of String, String)("tipdoc", "1"),
                        New KeyValuePair(Of String, String)("search2", numeroDNI),
                        New KeyValuePair(Of String, String)("search3", ""),
                        New KeyValuePair(Of String, String)("codigo", "")
                    }
                    Dim contenido As FormUrlEncodedContent = New FormUrlEncodedContent(lClaveValor)
                    url = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias"

                    Using resultadoConsultaRandom As HttpResponseMessage = Await cliente.PostAsync(url, contenido)

                        If resultadoConsultaRandom.IsSuccessStatusCode Then
                            Await Task.Delay(100)
                            Dim contenidoHTML As String = Await resultadoConsultaRandom.Content.ReadAsStringAsync()
                            Dim numeroRandom As String = oCuTexto.ExtraerContenidoEntreTagString(contenidoHTML, 0, "name=""numRnd"" value=""", """>")
                            lClaveValor = New List(Of KeyValuePair(Of String, String)) From {
                                New KeyValuePair(Of String, String)("accion", "consPorRuc"),
                                New KeyValuePair(Of String, String)("actReturn", "1"),
                                New KeyValuePair(Of String, String)("nroRuc", ruc),
                                New KeyValuePair(Of String, String)("numRnd", numeroRandom),
                                New KeyValuePair(Of String, String)("modo", "1")
                            }
                            Dim cConsulta As Integer = 0
                            Dim nConsulta As Integer = 3
                            Dim codigoEstado As HttpStatusCode = HttpStatusCode.Unauthorized

                            While cConsulta < nConsulta AndAlso codigoEstado = HttpStatusCode.Unauthorized
                                contenido = New FormUrlEncodedContent(lClaveValor)

                                Using resultadoConsultaDatos As HttpResponseMessage = Await cliente.PostAsync(url, contenido)
                                    codigoEstado = resultadoConsultaDatos.StatusCode

                                    If resultadoConsultaDatos.IsSuccessStatusCode Then
                                        contenidoHTML = Await resultadoConsultaDatos.Content.ReadAsStringAsync()
                                        contenidoHTML = WebUtility.HtmlDecode(contenidoHTML)
                                        Dim oEnSUNAT As EnSUNAT = ObjRuc.ObtenerDatos(contenidoHTML)

                                        If oEnSUNAT.TipoRespuesta = 1 Then
                                            txtDesCli.Text = oEnSUNAT.RazonSocial
                                            txtAbrCli.Text = oEnSUNAT.NombreComercial
                                            'txtDirPro.Text = oEnSUNAT.DomicilioFiscal
                                            tipoRespuesta = 1
                                            mensajeRespuesta = String.Format("Se realizó exitosamente la consulta del número de RUC {0}", ruc)
                                        Else
                                            tipoRespuesta = oEnSUNAT.TipoRespuesta
                                            mensajeRespuesta = String.Format("No se pudo realizar la consulta del número de RUC {0}." & vbCrLf & "Detalle: {1}", ruc, oEnSUNAT.MensajeRespuesta)
                                        End If
                                    Else
                                        mensajeRespuesta = Await resultadoConsultaDatos.Content.ReadAsStringAsync()
                                        mensajeRespuesta = String.Format("Ocurrió un inconveniente al consultar los datos del RUC {0}." & vbCrLf & "Detalle:{1}", ruc, mensajeRespuesta)
                                    End If
                                End Using

                                cConsulta += 1
                            End While
                        Else
                            mensajeRespuesta = Await resultadoConsultaRandom.Content.ReadAsStringAsync()
                            mensajeRespuesta = String.Format("Ocurrió un inconveniente al consultar el número random del RUC {0}." & vbCrLf & "Detalle:{1}", ruc, mensajeRespuesta)
                        End If
                    End Using
                Else
                    mensajeRespuesta = Await resultadoConsulta.Content.ReadAsStringAsync()
                    mensajeRespuesta = String.Format("Ocurrió un inconveniente al consultar la página principal {0}." & vbCrLf & "Detalle:{1}", ruc, mensajeRespuesta)
                End If
            End Using
        End Using

        oCronometro.[Stop]()
        If tipoRespuesta > 1 Then MessageBox.Show(mensajeRespuesta, "Consultar RUC mediante número random", MessageBoxButtons.OK, If(tipoRespuesta = 2, MessageBoxIcon.Warning, MessageBoxIcon.[Error]))
        lblMensaje.Text = String.Format("Procesado en {0} seg.", oCronometro.Elapsed.TotalSeconds)
        btnConsultaSunat.Enabled = True
        'txtNumeroRUC.Focus()
        'txtNumeroRUC.SelectAll()

    End Sub

    Private Async Sub ConsultarDNI()
        Dim tipoRespuesta = 2
        Dim mensajeRespuesta = ""
        txtApePat.Text = ""
        txtApeMat.Text = ""
        txtNombre.Text = ""
        Dim numeroDNI As String = txtNroDoc.Text
        If String.IsNullOrWhiteSpace(numeroDNI) Then Return
        Dim oCronometro As Stopwatch = New Stopwatch()
        oCronometro.Start()
        btnConsultaSunat.Enabled = False
        Dim cookies As CookieContainer = New CookieContainer()
        Dim controladorMensaje As HttpClientHandler = New HttpClientHandler()
        controladorMensaje.CookieContainer = cookies
        controladorMensaje.UseCookies = True

        Dim ObjConDni As New ConsultaDNI

        Using cliente As HttpClient = New HttpClient(controladorMensaje)
            cliente.DefaultRequestHeaders.Add("Host", "eldni.com")
            cliente.DefaultRequestHeaders.Add("sec-ch-ua", """ Not A;Brand"";v=""99"", ""Chromium"";v=""90"", ""Google Chrome"";v=""90""")
            cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none")
            cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1")
            cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1")
            cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
            Dim url = "https://eldni.com/pe/buscar-por-dni"

            Using resultadoConsultaToken As HttpResponseMessage = Await cliente.GetAsync(New Uri(url))

                If resultadoConsultaToken.IsSuccessStatusCode Then
                    mensajeRespuesta = Await resultadoConsultaToken.Content.ReadAsStringAsync()
                    Dim token As String = ObjConDni.ExtraerContenidoEntreNombreString(mensajeRespuesta, 0, "name=""_token"" value=""", """>")
                    cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site")
                    cliente.DefaultRequestHeaders.Add("Origin", "https://eldni.com")
                    cliente.DefaultRequestHeaders.Add("Referer", "https://eldni.com/pe/buscar-por-dni")
                    cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin")
                    Dim oDatoSolicitudDNI As DatoSolicitudDNI = New DatoSolicitudDNI()
                    oDatoSolicitudDNI._token = token
                    oDatoSolicitudDNI.dni = numeroDNI

                    '  cliente.PostAsJsonAsync

                    Using resultadoConsultaDatos As HttpResponseMessage = Await cliente.PostAsJsonAsync(url, oDatoSolicitudDNI)

                        If resultadoConsultaDatos.IsSuccessStatusCode Then
                            Dim contenidoHTML As String = Await resultadoConsultaDatos.Content.ReadAsStringAsync()
                            Dim nombreInicio = "<table class=""table table-striped table-scroll"">"
                            Dim nombreFin = "</table>"
                            Dim contenidoDNI As String = ObjConDni.ExtraerContenidoEntreNombreString(contenidoHTML, 0, nombreInicio, nombreFin)

                            If Equals(contenidoDNI, "") Then
                                nombreInicio = "<h3 class=""text-error"">"
                                nombreFin = "</h3>"
                                mensajeRespuesta = ObjConDni.ExtraerContenidoEntreNombreString(contenidoHTML, 0, nombreInicio, nombreFin)
                                mensajeRespuesta = If(Equals(mensajeRespuesta, ""), String.Format("No se pudo realizar la consulta del número de DNI {0}.", numeroDNI), String.Format("No se pudo realizar la consulta del número de DNI {0}." & vbCrLf & "Detalle: {1}", numeroDNI, mensajeRespuesta))
                            Else
                                nombreInicio = "<td>"
                                nombreFin = "</td>"
                                Dim arrResultado As String() = ObjConDni.ExtraerContenidoEntreNombre(contenidoDNI, 0, nombreInicio, nombreFin)

                                If arrResultado IsNot Nothing Then
                                    ' Nombres
                                    arrResultado = ObjConDni.ExtraerContenidoEntreNombre(contenidoDNI, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                    If arrResultado IsNot Nothing Then
                                        txtNombre.Text = arrResultado(1)

                                        ' Apellido Paterno
                                        arrResultado = ObjConDni.ExtraerContenidoEntreNombre(contenidoDNI, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                        If arrResultado IsNot Nothing Then
                                            txtApePat.Text = arrResultado(1)

                                            ' Apellido Materno
                                            arrResultado = ObjConDni.ExtraerContenidoEntreNombre(contenidoDNI, Convert.ToInt32(arrResultado(0)), nombreInicio, nombreFin)

                                            If arrResultado IsNot Nothing Then
                                                txtApeMat.Text = arrResultado(1)
                                                tipoRespuesta = 1
                                                mensajeRespuesta = String.Format("Se realizó exitosamente la consulta del número de DNI {0}", numeroDNI)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            mensajeRespuesta = Await resultadoConsultaDatos.Content.ReadAsStringAsync()
                            mensajeRespuesta = String.Format("Ocurrió un inconveniente al consultar los datos del DNI {0}." & vbCrLf & "Detalle:{1}", numeroDNI, mensajeRespuesta)
                        End If
                    End Using
                Else
                    mensajeRespuesta = Await resultadoConsultaToken.Content.ReadAsStringAsync()
                    mensajeRespuesta = String.Format("Ocurrió un inconveniente al consultar el número de DNI {0}." & vbCrLf & "Detalle:{1}", numeroDNI, mensajeRespuesta)
                End If
            End Using
        End Using

        oCronometro.[Stop]()
        If tipoRespuesta > 1 Then MessageBox.Show(mensajeRespuesta, "Consultar DNI", MessageBoxButtons.OK, If(tipoRespuesta = 2, MessageBoxIcon.Warning, MessageBoxIcon.[Error]))
        lblMensaje.Text = String.Format("Procesado en {0} seg.", oCronometro.Elapsed.TotalSeconds)
        btnConsultaSunat.Enabled = True
        'txtNumeroDNI.Focus()
        'txtNumeroDNI.SelectAll()
    End Sub

    Private Sub btnConsultaSunat_Click(sender As Object, e As EventArgs) Handles btnConsultaSunat.Click

        If txtNroDoc.Text = "" Then
            MsgBox("Ingrese numero de documento ", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If cmbTipoDoc.Value = "6" Then
            ConsultarRuc()
        ElseIf cmbTipoDoc.Value = "1"
            ConsultarDNI()
        End If
    End Sub

    Private Sub cmbIdTipoCon_ValueChanged(sender As Object, e As EventArgs) Handles cmbIdTipoCon.ValueChanged
        If cmbIdTipoCon.Value = "1" Then
            cmbTipoDoc.Value = "6"
        ElseIf cmbIdTipoCon.Value = "2" Then
            cmbTipoDoc.Value = "1"
        Else
            cmbTipoDoc.Value = "0"
        End If
        txtNroDoc.Select()
    End Sub

End Class
