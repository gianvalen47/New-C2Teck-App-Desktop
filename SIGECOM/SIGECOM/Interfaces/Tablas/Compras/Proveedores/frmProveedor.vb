Imports System.Net
Imports System.Net.Http
Imports System.ServiceModel
Imports ConsultasSunat.EntidadNegocio
Imports ConsultasSunat
Imports ConsultasSunat.CodigoUsuario
Imports System.Threading.Tasks

Public Class frmProveedor

    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete

    Public IdProveedor As Integer
    Public DesProv As String
    Public RucProv As String
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContactoProveedorService As New ContactoProveedorService.ContactoProveedorServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private dtDatos As DataTable
    Private dtEstados As DataTable
    Private dtTiposContribuyentes As DataTable
    Private dtCondicionesPago As DataTable
    Private dtRubros As DataTable
    Private dtCuentaPago As DataTable
    Private dtTipoDoc As DataTable

    Private state_Search As Boolean
    Private CodUbigeo As String
    Private CodPais As String

    Private TAB_CONTACTOS As String = "tabpContactos"

    Private Sub cbImportacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbImportacion.CheckedChanged
        If cbImportacion.Checked Then
            lblAstAbr.Visible = True
        Else
            lblAstAbr.Visible = False
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           cmbIdTipoCon.KeyPress _
                           , cmbRubro.KeyPress _
                           , cmbCodPag.KeyPress _
                          , txtDesProv.KeyPress _
                          , txtIdProveedor.KeyPress _
                          , txtAbrProv.KeyPress _
                          , txtNroDoc.KeyPress _
                          , txtDniProv.KeyPress _
                          , txtUrlProv.KeyPress _
                          , txtEmail.KeyPress _
                          , txtFaxProv.KeyPress _
                          , txtTelProv.KeyPress _
                          , cbImportacion.KeyPress _
                            , cbEmiteFacElect.KeyPress _
                            , cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtHoraPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDirCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDirProv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnUbigeo.Enabled = True Then
                e.Handled = True
                btnUbigeo.Focus()
            End If
        End If
    End Sub

    Private Sub dgvContactos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvContactos.DoubleClick
        If ValidaCodigoSeleccionado(dgvContactos) Then
            mostrarContacto()
        End If
    End Sub

    Private Sub dgvContactos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvContactos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvContactos.RowCount > 0 Then
                dgvContactos_DoubleClick(sender, e)
            End If
        End If
    End Sub

    'Private Sub EjecutaEnter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvContactos.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        If tabVentanas.SelectedTab.Name = TAB_CONTACTOS Then
    '            If ValidaCodigoSeleccionado(dgvContactos) Then
    '                mostrarContacto()
    '            End If
    '        End If
    '    End If
    'End Sub
    Private Sub txtUbigeo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUbigeo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFaxProv.Focus()
        End If
    End Sub

    Private Sub txtUbigeo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbigeo.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnUbigeo.Enabled = True Then
                btnUbigeo_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmProveedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProveedorService.Close()
            oMaestroService.Close()
            oContactoProveedorService.Close()
        Catch ex As TimeoutException
            oProveedorService.Abort()
            oMaestroService.Abort()
            oContactoProveedorService.Abort()
        Catch ex As CommunicationException
            oProveedorService.Abort()
            oMaestroService.Abort()
            oContactoProveedorService.Abort()
        End Try
    End Sub

    Private Sub frmProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub frmProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        state_Search = False
        llenarCombos()
        InitDataGrids()

        If state_button Then    'Modificar            
            txtIdProveedor.ReadOnly = True
            txtIdProveedor.TabStop = False
            ObtenerRegistro()
            desactivar()
            cbImportacion.Enabled = False
            cbEmiteFacElect.Enabled = False

            tabVentanas.SelectedIndex = 0
            listaContactos()
            listaCuentaPago()
            lblEstado.Visible = False
            cmbEstado.Visible = False
            Me.Text = "Proveedor " + Chr(34) + txtDesProv.Text.ToString + Chr(34)
            btnConsultaSunat.Visible = False

        Else                    'Nuevo
            txtIdProveedor.ReadOnly = True
            txtIdProveedor.TabStop = False
            cmbTipoDoc.Value = "6"
            Me.Size = New System.Drawing.Size(699, 408)
            Me.Text = "Registrar nuevo Proveedor"

        End If
        state_Search = True
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                         txtIdProveedor.KeyUp _
                        , txtDesProv.KeyUp _
                        , txtDirProv.KeyUp _
                        , txtNroDoc.KeyUp _
                        , txtNombre.KeyUp _
                        , txtDniProv.KeyUp _
                        , txtAbrProv.KeyUp _
                        , txtApePat.KeyUp _
                        , txtApeMat.KeyUp _
                        , txtTelProv.KeyUp _
                        , txtEmail.KeyUp
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception

        End Try
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

    Private Sub InitDataGrids()
        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgvContactos)
        estilo.cargaEstiloDataDrid(dgvCuentaPago)
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New ProveedorService.Proveedor
            registro.IdProveedor = toNumber(txtIdProveedor.Text)

            If toNumber(cmbIdTipoCon.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de contribuyente  del Proveedor", MsgBoxStyle.Information, "Información")
                cmbIdTipoCon.BackColor = Color.Red
                cmbIdTipoCon.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de documento del Proveedor", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.BackColor = Color.Red
                cmbTipoDoc.Focus()
                Return False
            ElseIf txtNroDoc.Text.Trim.Length = 0 And toBlank(cmbTipoDoc.Value) <> "0" Then
                MsgBox("Debe de Ingresar Nro. de Documento", MsgBoxStyle.Information, "Información")
                txtNroDoc.Text = ""
                txtNroDoc.Focus()
                Return False
            ElseIf txtNombre.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Nombre del Proveedor", MsgBoxStyle.Information, "Información")
                txtNombre.BackColor = Color.Red
                txtNombre.Focus()
                Return False
            ElseIf txtApePat.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Apellido Paterno del Proveedor", MsgBoxStyle.Information, "Información")
                txtApePat.BackColor = Color.Red
                txtApePat.Focus()
                Return False
            ElseIf txtApeMat.Text = "" And toBlank(cmbTipoDoc.Value) = "1" Then
                MsgBox("Debe Ingresar el Apellido Materno del Proveedor", MsgBoxStyle.Information, "Información")
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
                'ElseIf txtDniProv.Text.Trim.Length > 0 And (txtDniProv.Text.Trim.Length <> 8) Then
                '    MsgBox("El D.N.I. es incorrecto...!", MsgBoxStyle.Information, "Información")
                '    txtDniProv.BackColor = Color.Red
                '    txtDniProv.Focus()
                '    Return False
            ElseIf txtDirProv.Text = "" Then
                MsgBox("Debe Ingresar la dirección del Proveedor", MsgBoxStyle.Information, "Información")
                txtDirProv.BackColor = Color.Red
                txtDirProv.Focus()
                Return False
            ElseIf cmbRubro.Value = 0 Then
                MsgBox("Debe Ingresar el Rubro del Proveedor", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
            ElseIf cmbCodPag.Value = 0 Then
                MsgBox("Debe Ingresar la Condición de pago del Proveedor", MsgBoxStyle.Information, "Información")
                cmbCodPag.Focus()
                Return False
            ElseIf cmbCodPag.Value <> 1 And toBlank(txtTelProv.Text) = "" Then
                MsgBox("Debe Ingresar el Teléfono del Proveedor", MsgBoxStyle.Information, "Información")
                txtTelProv.BackColor = Color.Red
                txtTelProv.Focus()
                Return False
            ElseIf cmbCodPag.Value <> 1 And toBlank(txtEmail.Text) = "" Then
                MsgBox("Debe Ingresar el Email del Proveedor", MsgBoxStyle.Information, "Información")
                txtEmail.BackColor = Color.Red
                txtEmail.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "1" And state_button = False And oProveedorService.BuscarDni(toNull(txtNroDoc.Text)) = True Then
                MsgBox("El D.N.I. " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtNroDoc.Text = ""
                txtNroDoc.Focus()
                Return False
            ElseIf (toBlank(cmbTipoDoc.Value) = "6") And state_button = False And oProveedorService.BuscarRuc(Session.sCodEmp, toNull(Trim(txtNroDoc.Text))) = True Then
                MsgBox("El R.U.C. " + txtNroDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtNroDoc.Text = ""
                txtNroDoc.Focus()
                Return False
            ElseIf cbImportacion.Checked = True And txtAbrProv.Text = "" Then
                MsgBox("Debe ingresar la Abreviatura del Proveedor", MsgBoxStyle.Information, "Información")
                txtAbrProv.BackColor = Color.Red
                txtAbrProv.Focus()
                Return False
            ElseIf txtTelProv.Text = "" Then
                MsgBox("Debe ingresar el telefono del Proveedor", MsgBoxStyle.Information, "Información")
                txtTelProv.BackColor = Color.Red
                txtTelProv.Focus()
                Return False
                'ElseIf cmbBanco.SelectedIndex <> 0 And cmbTipoCuenta.SelectedIndex = 0 Then
                '    MsgBox("Debe ingresar el Tipo de Cuenta", MsgBoxStyle.Information, "Información")
                '    cmbTipoCuenta.Focus()
                '    Return False
                'ElseIf cmbTipoCuenta.SelectedIndex <> 0 And cmbMoneda.SelectedIndex = 0 Then
                '    MsgBox("Debe ingresar la Moneda", MsgBoxStyle.Information, "Información")
                '    cmbMoneda.Focus()
                '    Return False
                'ElseIf cmbMoneda.SelectedIndex <> 0 And toBlank(txtNumCta.Text) = "" Then
                '    MsgBox("Debe ingresar la Número de Cuenta", MsgBoxStyle.Information, "Información")
                '    txtNumCta.Focus()
                '    Return False
                'ElseIf toBlank(txtNumCta.Text) <> "" And cmbBanco.SelectedIndex = 0 Then
                '    MsgBox("Debe ingresar la Número de Cuenta", MsgBoxStyle.Information, "Información")
                '    cmbBanco.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ProveedorService.Proveedor)
        Try
            Dim estado_process As Integer
            estado_process = oProveedorService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                MsgBox("Se insertó el Proveedor correctamente")
                IdProveedor = estado_process
                If txtDesProv.Text = "" Then
                    DesProv = txtNombre.Text + " " + txtApePat.Text + " " + txtApeMat.Text
                Else
                    DesProv = txtDesProv.Text
                End If
                'If cmbIdTipoCon.Value = 2 Then
                RucProv = txtNroDoc.Text
                'Else : RucProv = txtNroDoc.Text
                'End If
                'If txtRucProv.Text = "" Then
                '    RucProv = txtDniProv.Text
                'Else
                '    RucProv = txtRucProv.Text
                'End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ProveedorService.Proveedor)
        Try
            Dim estado_process As Boolean
            estado_process = oProveedorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar(ByVal registro As ProveedorService.Proveedor)
        Try
            Dim estado_process As Boolean
            estado_process = oProveedorService.Borrar(IdProveedor, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ProveedorService.Proveedor
            registro = oProveedorService.Obtener(IdProveedor)
            txtIdProveedor.Text = toBlank(registro.IdProveedor)
            txtDesProv.Text = toBlank(registro.DesProv)
            txtDirProv.Text = toBlank(registro.DirProv)
            txtAbrProv.Text = toBlank(registro.AbrProv)
            txtNroDoc.Text = toBlank(registro.RucProv)
            txtDniProv.Text = toBlank(registro.DniProv)
            txtTelProv.Text = toBlank(registro.Telefono)
            txtFaxProv.Text = toBlank(registro.Fax)
            txtEmail.Text = toBlank(registro.Email)
            txtUrlProv.Text = toBlank(registro.Url)
            txtObsProv.Text = toBlank(registro.Observacion)
            txtNombre.Text = toBlank(registro.Nombres)
            txtApePat.Text = toBlank(registro.ApePat)
            txtApeMat.Text = toBlank(registro.ApeMat)
            If Not (registro.FecFinHomologa.ToString = "") Then
                txtFecFinHomologacion.Value = CDate(registro.FecFinHomologa)
                txtFecFinHomologacion.Text = registro.FecFinHomologa.ToString
            End If
            state_Search = True
            cmbIdTipoCon.Value = registro.TipoContribuyente.IdTipoCon
            cmbTipoDoc.Value = registro.TipoDocumentoId.CodDoc
            cmbCodPag.Value = registro.CondicionPagoProveedor.IdCondicion
            cmbRubro.Value = registro.RubroProveedor.IdRubro
            cbImportacion.Checked = toBlank(registro.Importacion)
            cbEmiteFacElect.Checked = toBlank(registro.EmiteFacturaDigital)
            CodUbigeo = registro.Ubigeo.CodUbigeo
            txtUbigeo.Text = registro.Ubigeo.Departamento.NomDpto & " - " & toBlank(registro.Ubigeo.Provincia.NomProv) & " - " & toBlank(registro.Ubigeo.Distrito.NomDist)
            cmbEstado.Value = registro.IdEstado

            CodPais = registro.PaisProveedor.CodPais
            txtPais.Text = registro.PaisProveedor.DesPais

            'If registro.Banco.CodBan Is Nothing Or registro.Banco.CodBan = "" Then
            '    cmbBanco.SelectedIndex = 0
            'Else
            '    cmbBanco.Value = registro.Banco.CodBan
            'End If

            'If registro.Moneda.CodMon Is Nothing Or registro.Moneda.CodMon = "" Then
            '    cmbMoneda.SelectedIndex = 0
            'Else
            '    cmbMoneda.Value = registro.Moneda.CodMon
            'End If

            'If registro.TipoCuentaBanco.CodTipoCuenta Is Nothing Or registro.TipoCuentaBanco.CodTipoCuenta = "" Then
            '    cmbTipoCuenta.SelectedIndex = 0
            'Else
            '    cmbTipoCuenta.Value = registro.TipoCuentaBanco.CodTipoCuenta
            'End If

            'txtNumCta.Text = toBlank(registro.NumCta)
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '=================================== TIPO DE DOCUMENTO ========================================
            dtTipoDoc = oProveedorService.MostrarTipoDocumento.Tables(0)
            cmbTipoDoc.DataSource = dtTipoDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipoDoc = Nothing

            ''=================================TIPO CONTRIBUYENTE DEL PROVEEDOR ====================================
            dtTiposContribuyentes = oProveedorService.MostrarTipoContribuyente.Tables(0)
            cmbIdTipoCon.DataSource = dtTiposContribuyentes
            cmbIdTipoCon.DropDownList.DataMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.DropDownList.DisplayMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.DropDownList.ValueMember = dtTiposContribuyentes.Columns("IdTipoCon").ToString
            cmbIdTipoCon.DropDownList.Columns(0).DataMember = dtTiposContribuyentes.Columns("IdTipoCon").ToString
            cmbIdTipoCon.DropDownList.Columns(1).DataMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.SelectedIndex = 0
            dtTiposContribuyentes = Nothing

            ''======================================= ESTADOS DEL PROVEEDOR ========================================
            'dtEstados = oProveedorService.MostrarEstado.Tables(0)
            'cmbEstado.DataSource = dtEstados
            'cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            'cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            'cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            'dtEstados = Nothing

            ''======================================= RUBROS DEL PROVEEDOR =========================================
            dtRubros = oProveedorService.MostrarRubros.Tables(0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("NomRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("NomRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("NomRubro").ToString
            dtRubros = Nothing

            '======================================= CONDICIONES DE PAGO ===========================================
            dtCondicionesPago = oProveedorService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("NomCondicion").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("NomCondicion").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("IdCondicion").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("IdCondicion").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("NomCondicion").ToString
            cmbCodPag.DropDownList.Columns(2).DataMember = dtCondicionesPago.Columns("DiasPago").ToString
            dtCondicionesPago = Nothing



        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub listaContactos()
        Try
            dtDatos = oContactoProveedorService.Mostrar(toNumber(txtIdProveedor.Text)).Tables(0)
            dgvContactos.DataSource = dtDatos

            cIdContacto.DataPropertyName = dtDatos.Columns("IdContacto").ColumnName
            cNombres.DataPropertyName = dtDatos.Columns("Nombres").ColumnName
            cApellidos.DataPropertyName = dtDatos.Columns("Apellidos").ColumnName

            enableOpciones(dgvContactos)
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CONTACTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarContacto()
        Try
            Dim frm As New frmProveedor_AgregarContacto
            Dim IdContactoPos As Integer
            frm.state_button = True
            frm.txtIdContacto.Text = dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value
            IdContactoPos = dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value
            dgvContactos.Rows(dgvContactos.CurrentRow.Index).Selected = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaContactos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvContactos, dtDatos, "IdContacto", IdContactoPos)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            listaContactos()
            RowPossesion(dgvContactos, dtDatos, "IdContacto", IdContactoPos)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CONTACTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarContacto()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContactoProveedorService.Borrar(CInt(dgvContactos.Item("cIdContacto", dgvContactos.CurrentRow.Index).Value), toNumber(txtIdProveedor.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaContactos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CONTACTO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoContacto()
        Try
            Dim frm As New frmProveedor_AgregarContacto
            frm.state_button = False
            frm.IdProveedor = CInt(txtIdProveedor.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaContactos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvContactos, dtDatos, "IdContacto", frm.txtIdContacto.Text.Trim)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL AGREGAR NUEVO CONTACTO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR LISTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaCuentaPago()

        Try
            dtCuentaPago = oProveedorService.MostrarCuentaBanco(toNumber(txtIdProveedor.Text)).Tables(0)
            dgvCuentaPago.DataSource = dtCuentaPago

            cIdProveedor.DataPropertyName = dtCuentaPago.Columns("IdProveedor").ColumnName
            cCodBan.DataPropertyName = dtCuentaPago.Columns("CodBan").ColumnName
            cDesBan.DataPropertyName = dtCuentaPago.Columns("DesBan").ColumnName
            cCodMon.DataPropertyName = dtCuentaPago.Columns("CodMon").ColumnName
            cCodTipoCuenta.DataPropertyName = dtCuentaPago.Columns("CodTipoCuenta").ColumnName
            cNumCta.DataPropertyName = dtCuentaPago.Columns("NumCta").ColumnName
            cCodDoc.DataPropertyName = dtCuentaPago.Columns("CodDoc").ColumnName
            cDesDoc.DataPropertyName = dtCuentaPago.Columns("DesDoc").ColumnName
            cAbrDoc.DataPropertyName = dtCuentaPago.Columns("AbrDoc").ColumnName
            cNumDoc.DataPropertyName = dtCuentaPago.Columns("NumDoc").ColumnName

            enableOpciones(dgvCuentaPago)
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CONTACTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub mostrarCuentaPago()
        Try
            Dim frm As New frmProveedor_AgregarCuentaPago
            frm.state_button = True
            frm.IdProveedor = dgvCuentaPago.Item("cIdProveedor", dgvCuentaPago.CurrentRow.Index).Value
            frm.Banco = dgvCuentaPago.Item("cCodBan", dgvCuentaPago.CurrentRow.Index).Value
            frm.Moneda = dgvCuentaPago.Item("cCodMon", dgvCuentaPago.CurrentRow.Index).Value

            dgvCuentaPago.Rows(dgvCuentaPago.CurrentRow.Index).Selected = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtCuentaPago = Nothing
                listaCuentaPago()

                If frm.type_process = "update" Then
                    'RowPossesion(dgvCuentaPago, dtCuentaPago, "NumCta", frm.txtNumCta.Text.Trim)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            listaCuentaPago()
            'RowPossesion(dgvCuentaPago, dtCuentaPago, "NumCta", frm.txtNumCta.Text.Trim)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CONTACTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        btnUbigeo.Enabled = True
        btnBuscarPais.Enabled = True
        txtDesProv.ReadOnly = False
        txtDirProv.ReadOnly = False
        txtFaxProv.ReadOnly = False
        txtEmail.ReadOnly = False
        txtObsProv.ReadOnly = False
        txtNroDoc.ReadOnly = False
        txtNroDoc.BackColor = System.Drawing.SystemColors.Window
        txtAbrProv.ReadOnly = False
        txtTelProv.ReadOnly = False
        txtDniProv.ReadOnly = False
        txtUrlProv.ReadOnly = False
        txtNombre.ReadOnly = False
        txtApePat.ReadOnly = False
        txtApeMat.ReadOnly = False
        'txtFecFinHomologacion.
        txtFecFinHomologacion.ReadOnly = False
        txtFecFinHomologacion.BackColor = System.Drawing.SystemColors.Window

        'If toNumber(cmbIdTipoCon.Value) = 2 Then
        '    txtNombre.BackColor = System.Drawing.SystemColors.Window
        '    txtApePat.BackColor = System.Drawing.SystemColors.Window
        '    txtApeMat.BackColor = System.Drawing.SystemColors.Window
        'Else
        '    txtNombre.BackColor = System.Drawing.SystemColors.Control
        '    txtApePat.BackColor = System.Drawing.SystemColors.Control
        '    txtApeMat.BackColor = System.Drawing.SystemColors.Control
        'End If

        If toBlank(cmbTipoDoc.Value) = "1" Then
            txtDesProv.BackColor = System.Drawing.SystemColors.Control
            txtDesProv.ReadOnly = True
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtNombre.ReadOnly = False
            txtApePat.BackColor = System.Drawing.SystemColors.Window
            txtApePat.ReadOnly = False
            txtApeMat.BackColor = System.Drawing.SystemColors.Window
            txtApeMat.ReadOnly = False

            lblRazonSocial.Visible = False
            lblAstNombre.Visible = True
            lblAstApePat.Visible = True
            lblAstApeMat.Visible = True
            lblAstDni.Visible = True
        Else
            txtDesProv.BackColor = System.Drawing.SystemColors.Window
            txtDesProv.ReadOnly = False
            txtNombre.ReadOnly = False
            txtApePat.BackColor = System.Drawing.SystemColors.Window
            txtApePat.ReadOnly = False
            txtApeMat.BackColor = System.Drawing.SystemColors.Window
            txtApeMat.ReadOnly = False

            lblRazonSocial.Visible = True
            lblAstNombre.Visible = False
            lblAstApePat.Visible = False
            lblAstApeMat.Visible = False
            lblAstDni.Visible = False
        End If

        cmbCodPag.ReadOnly = False
        cmbCodPag.BackColor = System.Drawing.SystemColors.Window
        cmbRubro.ReadOnly = False
        cmbRubro.BackColor = System.Drawing.SystemColors.Window
        cmbIdTipoCon.ReadOnly = False
        cmbIdTipoCon.BackColor = System.Drawing.SystemColors.Window
        cmbTipoDoc.ReadOnly = False
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
        'cmbEstado.ReadOnly = False
        'cmbEstado.BackColor = System.Drawing.SystemColors.Window
        cbImportacion.Enabled = True
        cbEmiteFacElect.Enabled = True

        'cmbBanco.ReadOnly = False
        'cmbBanco.BackColor = System.Drawing.SystemColors.Window
        'cmbMoneda.ReadOnly = False
        'cmbMoneda.BackColor = System.Drawing.SystemColors.Window
        'txtNumCta.ReadOnly = False
        'txtNumCta.BackColor = System.Drawing.SystemColors.Window
        'cmbTipoCuenta.ReadOnly = False
        'cmbTipoCuenta.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub desactivar()
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

        btnUbigeo.Enabled = False
        btnBuscarPais.Enabled = False
        txtDesProv.ReadOnly = True
        txtDirProv.ReadOnly = True
        txtFaxProv.ReadOnly = True
        txtEmail.ReadOnly = True
        txtObsProv.ReadOnly = True
        txtNroDoc.ReadOnly = True
        txtNroDoc.BackColor = System.Drawing.SystemColors.Control
        txtAbrProv.ReadOnly = True
        txtTelProv.ReadOnly = True
        txtDniProv.ReadOnly = True
        txtUrlProv.ReadOnly = True
        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtApePat.ReadOnly = True
        txtApePat.BackColor = System.Drawing.SystemColors.Control
        txtApeMat.ReadOnly = True
        txtApeMat.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        cmbIdTipoCon.ReadOnly = True
        cmbIdTipoCon.BackColor = System.Drawing.SystemColors.Control
        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        'cmbEstado.ReadOnly = True
        'cmbEstado.BackColor = System.Drawing.SystemColors.Control       
        cbImportacion.Enabled = False
        cbEmiteFacElect.Enabled = False
        txtFecFinHomologacion.ReadOnly = True
        txtFecFinHomologacion.BackColor = System.Drawing.SystemColors.Control

        'cmbBanco.ReadOnly = True
        'cmbBanco.BackColor = System.Drawing.SystemColors.Control
        'cmbMoneda.ReadOnly = True
        'cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        'txtNumCta.ReadOnly = True
        'txtNumCta.BackColor = System.Drawing.SystemColors.Control
        'cmbTipoCuenta.ReadOnly = True
        'cmbTipoCuenta.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click

        If ValidaCodigoSeleccionado(dgvContactos) Then
            eliminarContacto()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarLista(dgvContactos)
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click, btnAgregarContacto.Click
        NuevoContacto()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New ProveedorService.Proveedor
                Dim Rubro As New ProveedorService.RubroProveedor
                Dim CondicionPago As New ProveedorService.CondicionPagoProveedor
                Dim tipoContribuyente As New ProveedorService.TipoContribuyente
                Dim ubigeo As New ProveedorService.Ubigeo
                Dim empresa As New ProveedorService.Empresa
                Dim banco As New ProveedorService.Banco
                Dim moneda As New ProveedorService.Moneda
                Dim tipocuenta As New ProveedorService.TipoCuentaBanco
                Dim tipodoc As New ProveedorService.TipoDocumentoId
                Dim paisproveedor As New ProveedorService.PaisProveedor

                registro.IdProveedor = toNumber(txtIdProveedor.Text)
                tipoContribuyente.IdTipoCon = toNumber(cmbIdTipoCon.Value)
                registro.TipoContribuyente = tipoContribuyente
                tipodoc.CodDoc = cmbTipoDoc.Value
                registro.TipoDocumentoId = tipodoc
                registro.DesProv = toNull(txtDesProv.Text)
                registro.DirProv = toNull(txtDirProv.Text)
                registro.AbrProv = toNull(txtAbrProv.Text)
                registro.RucProv = toNull(txtNroDoc.Text)
                CondicionPago.IdCondicion = cmbCodPag.Value
                registro.CondicionPagoProveedor = CondicionPago
                registro.DniProv = toNull(txtDniProv.Text)
                registro.Telefono = toNull(txtTelProv.Text)
                registro.Fax = toNull(txtFaxProv.Text)
                registro.Email = toNull(txtEmail.Text)
                registro.Url = toNull(txtUrlProv.Text)
                registro.Observacion = toNull(txtObsProv.Text)
                paisproveedor.CodPais = toNull(CodPais)
                'paisproveedor.DesPais = txtPais.Text
                registro.PaisProveedor = paisproveedor

                'banco.CodBan = IIf(cmbBanco.SelectedIndex = 0, Nothing, cmbBanco.Value)
                'registro.Banco = banco
                'moneda.CodMon = IIf(cmbMoneda.SelectedIndex = 0, Nothing, cmbMoneda.Value)
                'registro.Moneda = moneda
                'registro.NumCta = IIf(txtNumCta.Text = "", Nothing, txtNumCta.Text)
                'tipocuenta.CodTipoCuenta = IIf(cmbTipoCuenta.SelectedIndex = 0, Nothing, cmbTipoCuenta.Value)
                'registro.TipoCuentaBanco = tipocuenta
                Rubro.IdRubro = cmbRubro.Value
                registro.RubroProveedor = Rubro
                registro.Importacion = cbImportacion.Checked
                registro.EmiteFacturaDigital = cbEmiteFacElect.Checked
                ubigeo.CodUbigeo = CodUbigeo
                registro.Ubigeo = ubigeo
                registro.FecFinHomologa = IIf(txtFecFinHomologacion.Text = "", Nothing, txtFecFinHomologacion.Value)
                'registro.Estado = cbEstado.Checked
                registro.IdEstado = 0
                registro.Nombres = toNull(txtNombre.Text)
                registro.ApePat = toNull(txtApePat.Text)
                registro.ApeMat = toNull(txtApeMat.Text)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc


                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        oProveedorService.Close()
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnUbigeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbigeo.Click
        Dim frm As New frmBuscarUbigeo
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodUbigeo = frm.CodUbigeo
            txtUbigeo.BackColor = System.Drawing.SystemColors.Control
            txtUbigeo.Text = frm.Nombre
        End If
        txtUbigeo.Select()
    End Sub

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
        sslError.Text = "Editar Detalles del Proveedor."
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en Detalles Proveedor."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en Detalles Proveedor."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Proveedor."
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
        sslError.Text = "Actualizar detalles del Formulario Proveedor ."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave,
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave,
                                   miNuevo.MouseLeave, miModificar.MouseLeave,
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado(dgvContactos) Then
            mostrarContacto()
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
    '        txtDesProv.Enabled = False
    '        txtDesProv.BackColor = System.Drawing.SystemColors.Control
    '        lblRazonSocial.Enabled = False
    '        txtDesProv.Text = ""
    '        lblAstDni.Visible = True
    '        lblAstNroDoc.Visible = True
    '        lblAstRazSoc.Visible = False
    '        lblAstNombre.Visible = True
    '        txtNroDoc.MaxLength = 11
    '        '------ Se agregó 13/12/2013 (Sr. Jesús Alba) -------
    '        lblAstApePat.Visible = True
    '        lblAstApeMat.Visible = True
    '        '-----------------------------------------------------------------------
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
    '        txtDesProv.Enabled = True
    '        txtDesProv.BackColor = System.Drawing.SystemColors.Window
    '        lblRazonSocial.Enabled = True
    '        txtNombre.Text = ""
    '        txtApePat.Text = ""
    '        txtApeMat.Text = ""
    '        lblAstDni.Visible = False
    '        lblAstNroDoc.Visible = True
    '        lblAstRazSoc.Visible = True
    '        lblAstNombre.Visible = False
    '        txtNroDoc.MaxLength = 11
    '        '------ Se agregó 13/12/2013 (Sr. Jesús Alba) -------
    '        lblAstApePat.Visible = False
    '        lblAstApeMat.Visible = False
    '        '-----------------------------------------------------------------------
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
    '        txtDesProv.Enabled = True
    '        txtDesProv.BackColor = System.Drawing.SystemColors.Window
    '        lblRazonSocial.Enabled = True
    '        txtNombre.Text = ""
    '        txtApePat.Text = ""
    '        txtApeMat.Text = ""
    '        lblAstDni.Visible = False
    '        lblAstNroDoc.Visible = False
    '        lblAstRazSoc.Visible = True
    '        lblAstNombre.Visible = False
    '        txtNroDoc.MaxLength = 30
    '        '------ Se agregó 13/12/2013 (Sr. Jesús Alba) -------
    '        lblAstApePat.Visible = False
    '        lblAstApeMat.Visible = False
    '        '-----------------------------------------------------------------------
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
    '        txtDesProv.Enabled = True
    '        txtDesProv.BackColor = System.Drawing.SystemColors.Window
    '        lblRazonSocial.Enabled = True
    '        txtNombre.Text = ""
    '        txtApePat.Text = ""
    '        txtApeMat.Text = ""
    '        lblAstDni.Visible = True
    '        lblAstNroDoc.Visible = False
    '        lblAstRazSoc.Visible = True
    '        lblAstNombre.Visible = False
    '        '------ Se agregó 13/12/2013 (Sr. Jesús Alba) -------
    '        lblAstApePat.Visible = False
    '        lblAstApeMat.Visible = False
    '        '-----------------------------------------------------------------------
    '    End If
    'End Sub

    Private Sub btnAgregarCuentaBanco_Click(sender As Object, e As EventArgs) Handles btnAgregarCuentaBanco.Click, miNuevoCtaPago.Click
        Try
            Dim frm As New frmProveedor_AgregarCuentaPago
            frm.state_button = False
            frm.IdProveedor = CInt(txtIdProveedor.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaCuentaPago()
                If frm.type_process = "insert" Then
                    'RowPossesion(dgvCuentaPago, dtCuentaPago, "NumCta", frm.txtNumCta.Text.Trim)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL AGREGAR NUEVA CUENTA BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvCuentaPago_DoubleClick(sender As Object, e As EventArgs) Handles dgvCuentaPago.DoubleClick, miMostrarCtaPago.Click
        If ValidaCodigoSeleccionado(dgvCuentaPago) Then
            mostrarCuentaPago()
        End If
    End Sub

    Private Sub miEliminarCtaPago_Click(sender As Object, e As EventArgs) Handles miEliminarCtaPago.Click
        If ValidaCodigoSeleccionado(dgvCuentaPago) Then
            eliminarCuentaPago()
        End If
    End Sub

    Private Sub eliminarCuentaPago()
        Try
            cmbOpcionesCtaPago.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvCuentaPago.Item("cNumCta", dgvCuentaPago.CurrentRow.Index).Value.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oProveedorService.BorrarCuentaBanco(CInt(dgvCuentaPago.Item("cIdProveedor", dgvCuentaPago.CurrentRow.Index).Value), dgvCuentaPago.Item("cCodBan", dgvCuentaPago.CurrentRow.Index).Value, dgvCuentaPago.Item("cCodMon", dgvCuentaPago.CurrentRow.Index).Value)
                If estado_process = True Then
                    dtCuentaPago = Nothing
                    listaCuentaPago()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA CUENTA PAGO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarCtaPago_Click(sender As Object, e As EventArgs) Handles miActualizarCtaPago.Click
        listaCuentaPago()
    End Sub

    Private Sub ActivarCasillas()

        If toBlank(cmbTipoDoc.Value) = "1" Then    '--------------------------------------- DNI
            txtDesProv.BackColor = System.Drawing.SystemColors.Control
            txtDesProv.ReadOnly = True
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

            txtDesProv.Text = ""

        Else     '---------------------------------------------------- RUC, OTROS,CE,ECT

            If cmbIdTipoCon.Value = 2 Then    '------------ PERSONA NATURAL
                txtDesProv.BackColor = System.Drawing.SystemColors.Control
                txtDesProv.ReadOnly = True
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
                lblAstDni.Visible = False

                txtDesProv.Text = ""
                'cmbIdTipoCon.Value = "2"
                txtNroDoc.Select()

            ElseIf cmbTipoDoc.Value = 1 Then      '------------ PERSONA JURIDICA
                txtDesProv.BackColor = System.Drawing.SystemColors.Window
                txtDesProv.ReadOnly = False
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

            Else     '------------ EXTRANJERO MANCOMUNADO
                txtDesProv.BackColor = System.Drawing.SystemColors.Window
                txtDesProv.ReadOnly = False
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

            End If

        End If
    End Sub

    Private Sub cmbTipoDoc_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbTipoDoc.ValueChanged

        'If toBlank(cmbTipoDoc.Value) = "6" Or toBlank(cmbTipoDoc.Value) = "0" Then
        '    txtDesProv.BackColor = System.Drawing.SystemColors.Window
        '    txtDesProv.ReadOnly = False
        '    txtNombre.BackColor = System.Drawing.SystemColors.Control
        '    txtNombre.ReadOnly = True
        '    txtApePat.BackColor = System.Drawing.SystemColors.Control
        '    txtApePat.ReadOnly = True
        '    txtApeMat.BackColor = System.Drawing.SystemColors.Control
        '    txtApeMat.ReadOnly = True

        '    lblAstRazSoc.Visible = True
        '    lblAstNombre.Visible = False
        '    lblAstApePat.Visible = False
        '    lblAstApeMat.Visible = False
        '    lblAstDni.Visible = False

        '    txtNombre.Text = ""
        '    txtApePat.Text = ""
        '    txtApeMat.Text = ""
        'Else
        '    txtDesProv.BackColor = System.Drawing.SystemColors.Control
        '    txtDesProv.ReadOnly = True
        '    txtNombre.BackColor = System.Drawing.SystemColors.Window
        '    txtNombre.ReadOnly = False
        '    txtApePat.BackColor = System.Drawing.SystemColors.Window
        '    txtApePat.ReadOnly = False
        '    txtApeMat.BackColor = System.Drawing.SystemColors.Window
        '    txtApeMat.ReadOnly = False

        '    lblAstRazSoc.Visible = False
        '    lblAstNombre.Visible = True
        '    lblAstApePat.Visible = True
        '    lblAstApeMat.Visible = True
        '    lblAstDni.Visible = True
        'End If


        'If toBlank(cmbTipoDoc.Value) = "1" Then    '--------------------------------------- DNI
        '    txtDesProv.BackColor = System.Drawing.SystemColors.Control
        '    txtDesProv.ReadOnly = True
        '    txtNombre.BackColor = System.Drawing.SystemColors.Window
        '    txtNombre.ReadOnly = False
        '    txtApePat.BackColor = System.Drawing.SystemColors.Window
        '    txtApePat.ReadOnly = False
        '    txtApeMat.BackColor = System.Drawing.SystemColors.Window
        '    txtApeMat.ReadOnly = False

        '    lblAstRazSoc.Visible = False
        '    lblAstNombre.Visible = True
        '    lblAstApePat.Visible = True
        '    lblAstApeMat.Visible = True
        '    lblAstDni.Visible = True

        '    txtDesProv.Text = ""

        'Else     '---------------------------------------------------- RUC, OTROS,CE,ECT

        '    If cmbIdTipoCon.Value = 2 Then    '------------ PERSONA NATURAL
        '        txtDesProv.BackColor = System.Drawing.SystemColors.Control
        '        txtDesProv.ReadOnly = True
        '        txtNombre.BackColor = System.Drawing.SystemColors.Window
        '        txtNombre.ReadOnly = False
        '        txtApePat.BackColor = System.Drawing.SystemColors.Window
        '        txtApePat.ReadOnly = False
        '        txtApeMat.BackColor = System.Drawing.SystemColors.Window
        '        txtApeMat.ReadOnly = False

        '        lblAstRazSoc.Visible = False
        '        lblAstNombre.Visible = True
        '        lblAstApePat.Visible = True
        '        lblAstApeMat.Visible = True
        '        lblAstDni.Visible = False

        '        txtDesProv.Text = ""
        '        'cmbIdTipoCon.Value = "2"
        '        txtNroDoc.Select()

        '    ElseIf cmbTipoDoc.Value = 1 Then      '------------ PERSONA JURIDICA
        '        txtDesProv.BackColor = System.Drawing.SystemColors.Window
        '        txtDesProv.ReadOnly = False
        '        txtNombre.BackColor = System.Drawing.SystemColors.Control
        '        txtNombre.ReadOnly = True
        '        txtApePat.BackColor = System.Drawing.SystemColors.Control
        '        txtApePat.ReadOnly = True
        '        txtApeMat.BackColor = System.Drawing.SystemColors.Control
        '        txtApeMat.ReadOnly = True

        '        lblAstRazSoc.Visible = True
        '        lblAstNombre.Visible = False
        '        lblAstApePat.Visible = False
        '        lblAstApeMat.Visible = False
        '        lblAstDni.Visible = False

        '        txtNombre.Text = ""
        '        txtApePat.Text = ""
        '        txtApeMat.Text = ""

        '    Else     '------------ EXTRANJERO MANCOMUNADO
        '        txtDesProv.BackColor = System.Drawing.SystemColors.Window
        '        txtDesProv.ReadOnly = False
        '        txtNombre.BackColor = System.Drawing.SystemColors.Control
        '        txtNombre.ReadOnly = True
        '        txtApePat.BackColor = System.Drawing.SystemColors.Control
        '        txtApePat.ReadOnly = True
        '        txtApeMat.BackColor = System.Drawing.SystemColors.Control
        '        txtApeMat.ReadOnly = True

        '        lblAstRazSoc.Visible = True
        '        lblAstNombre.Visible = False
        '        lblAstApePat.Visible = False
        '        lblAstApeMat.Visible = False
        '        lblAstDni.Visible = False

        '        txtNombre.Text = ""
        '        txtApePat.Text = ""
        '        txtApeMat.Text = ""

        '    End If

        'End If

        ActivarCasillas()

    End Sub

    Private Sub btnBuscarPais_Click(sender As Object, e As EventArgs) Handles btnBuscarPais.Click
        Dim frm As New frmBuscarPaisProveedor
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtPais.Text = frm.descripcion
            txtPais.BackColor = System.Drawing.SystemColors.Control
            CodPais = frm.codigo

        End If
        txtPais.Select()
    End Sub

    Private Sub btnConsultaSunat_Click(sender As Object, e As EventArgs) Handles btnConsultaSunat.Click

        If txtNroDoc.Text = "" Then
            MsgBox("Ingrese numero de documento ", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        If cmbTipoDoc.Value = "6" And cmbIdTipoCon.Value = "1" Then
            ConsultarRuc()
        ElseIf cmbTipoDoc.Value = "1" And cmbIdTipoCon.Value = "2"
            ConsultarDNI()
        End If
    End Sub

    Private Async Sub ConsultarRuc()

        Dim tipoRespuesta As Integer = 2
        Dim mensajeRespuesta As String = ""
        txtDesProv.Text = ""
        'txtTipoContribuyente.Text = ""
        txtAbrProv.Text = ""
        txtDirProv.Text = ""
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
                    Dim numeroDNI As String = "12345678"
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
                                            txtDesProv.Text = oEnSUNAT.RazonSocial
                                            txtAbrProv.Text = oEnSUNAT.NombreComercial
                                            txtDirProv.Text = oEnSUNAT.DomicilioFiscal
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




    Private Sub cmbIdTipoCon_ValueChanged(sender As Object, e As EventArgs) Handles cmbIdTipoCon.ValueChanged
        'If cmbIdTipoCon.Value = "1" Then
        '    cmbTipoDoc.Value = "6"
        'ElseIf cmbIdTipoCon.Value = "2" Then
        '    'cmbTipoDoc.Value = "1"
        '    cmbTipoDoc.Value = "6"
        'Else
        '    cmbTipoDoc.Value = "0"
        'End If
        ActivarCasillas()
        txtNroDoc.Select()
    End Sub
End Class