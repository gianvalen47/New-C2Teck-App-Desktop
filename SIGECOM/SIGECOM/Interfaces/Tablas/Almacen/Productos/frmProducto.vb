Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.IO

Public Class frmProducto
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestro As New MaestroService.MaestroClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient
    Private oModeloService As New ModelosProductoService.ModelosProductoServiceClient
    Private oTipoMotorService As New TipoMotorProductoService.TipoMotorProductoServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oListaFabrica As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient
    Private oCodigoBarraService As New CodigoBarraService.CodigoBarraServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private dtModelos As DataTable
    Private dtTiposMotores As DataTable
    Private dtUnidadesMedida As DataTable
    Private dtRubros As DataTable
    Private dtRubrosMotor As DataTable
    Private dtMovimientos As DataTable
    Private dtSubMovimientos As DataTable
    Private dtCodigoBarra As DataTable
    Private dtImagen As DataTable
    Private dtModeloMotor As DataTable
    Private dtModelosMotor As DataTable
    Private dtCodUniMed As DataTable
    Private dtListaPrecios As DataTable

    Private IdBarra As Boolean
    Private IdClase As String
    Private CodGru As String
    Private CodPais As String
    Private CodPar As String
    Private CodMar As String
    Private CodApl As String

    Private IdProveedor As Integer = 0             '---------Agregado el 14/02/2012---------

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtDesMer1.KeyPress _
                          , txtDesMer2.KeyPress _
                          , txtDeaMer.KeyPress _
                          , txtAntMer.KeyPress _
                          , txtNueMer.KeyPress _
                          , cmbModMer.KeyPress _
                          , cmbTipMot.KeyPress _
                          , cmbCodRub.KeyPress _
                          , cmbCodMov.KeyPress _
                          , txtPesMer.KeyPress
        ', txtObsMer.KeyPress
        ' , txtGrupo.KeyPress _
        ' , txtClase.KeyPress
        '  , txtCodMer.KeyPress _
        ' , cmbCodUniMed.KeyPress _
        ', cmbCodRubMot.KeyPress _
        ', txtPartida.KeyPress _
        ', txtPais.KeyPress _
        ' , txtMarca.KeyPress _
        ', txtCorMer.KeyPress _
        ', txtFleteMer.KeyPress _
        '  , txtAplicacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarClase.Focus()
        End If
    End Sub

    Private Sub txtClase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbCodRub.Focus()
        End If
    End Sub
    Private Sub cmbCodUniMed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodUniMed.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarGrupo.Focus()
        End If
    End Sub

    Private Sub cmbCodRubMot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodRubMot.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarPais.Focus()
        End If
    End Sub
    Private Sub txtPais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPais.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarPartida.Focus()
        End If
    End Sub
    Private Sub txtPartida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarMarca.Focus()
        End If
    End Sub
    Private Sub txtAplicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAplicacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbCodMov.Focus()
        End If
    End Sub
    Private Sub txtMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarAplicacion.Focus()
        End If
    End Sub

    Private Sub frmMercaderia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        state_Search = False
        llenarCombos()

        Dim permiso As SeguridadService.PermisoUsuario
        Dim PrecioFob As Boolean
        Dim Flete As Boolean
        permiso = oSeguridadService.MostrarPermisos(Session.sCodUsu)
        PrecioFob = permiso.PrecioFob
        Flete = permiso.Flete

        '----------------------------- Agregado el 11/09/2013 (César) -------------------------------
        If Flete = True Then
            txtFleteMer.ReadOnly = False
            txtFleteMer.BackColor = System.Drawing.SystemColors.Window
            txtFleteMer.Visible = True
            lblFleteMer.Visible = True
        Else
            txtFleteMer.ReadOnly = True
            txtFleteMer.BackColor = System.Drawing.SystemColors.Control
            txtFleteMer.Visible = False
            lblFleteMer.Visible = False
        End If
        '-----------------------------------------------------------------------------------------------------------

        If state_button Then    'Modificar
            'Me.btnGuardar.Location = New System.Drawing.Point(443, 277)
            'Me.btnEliminar.Location = New System.Drawing.Point(517, 277)
            txtCodMer.ReadOnly = True
            txtCodMer.TabStop = False
            ObtenerRegistro()
            listaDatosModeloMotor()
            listaDatosCodBarra()
            listaDatosImagen()
            Me.Text = "Producto " + Chr(34) + txtCodMer.Text.ToString + Chr(34)
            btnAgregarCodBar.Enabled = True
            btnEliminarCodBar.Enabled = True
            dgvCodBarra.Enabled = True
            btnAgregarImagen.Enabled = True
            btnActualizarImagen.Enabled = True
            btnMostrarImagen.Enabled = True
            btnEliminarImagen.Enabled = True
            dgvImagen.Enabled = True
            btnAgregarModelo.Enabled = True
            btnActualizarModelo.Enabled = True
            btnEliminarModelo.Enabled = True
            dgvModeloMotor.Enabled = True
            'cmbModeloMer.ReadOnly = False
            'cmbModeloMer.BackColor = System.Drawing.SystemColors.Window
            'txtObserModMotor.ReadOnly = False
            'txtObserModMotor.BackColor = System.Drawing.SystemColors.Window

        Else                    'Nuevo
            btnEliminar.Visible = False
            'Me.btnEliminar.Location = New System.Drawing.Point(443, 277)
            'Me.btnGuardar.Location = New System.Drawing.Point(517, 277)
            txtCodMer.ReadOnly = False
            txtCodMer.TabStop = True
            chkActivo.Checked = True
            chkActivo.Enabled = False
            btnAgregarCodBar.Enabled = False
            btnEliminarCodBar.Enabled = False
            dgvCodBarra.Enabled = False

            btnAgregarImagen.Enabled = False
            btnActualizarImagen.Enabled = False
            btnMostrarImagen.Enabled = False
            btnEliminarImagen.Enabled = False
            dgvImagen.Enabled = False
            btnAgregarModelo.Enabled = False
            btnActualizarModelo.Enabled = False
            btnEliminarModelo.Enabled = False
            dgvModeloMotor.Enabled = False
            'cmbModeloMer.ReadOnly = True
            'cmbModeloMer.BackColor = System.Drawing.SystemColors.Control
            'txtObserModMotor.ReadOnly = True
            'txtObserModMotor.BackColor = System.Drawing.SystemColors.Control
            Me.Text = "Registrar un nuevo Producto"

            If PrecioFob = True Then
                txtDeaMer.ReadOnly = False
                txtDeaMer.BackColor = System.Drawing.SystemColors.Window
                txtCorMer.ReadOnly = False
                txtCorMer.BackColor = System.Drawing.SystemColors.Window
            Else
                txtDeaMer.ReadOnly = True
                txtDeaMer.BackColor = System.Drawing.SystemColors.Control
                txtCorMer.ReadOnly = True
                txtCorMer.BackColor = System.Drawing.SystemColors.Control
            End If
            cmbCodMov.Value = "2"
            cmbListaPrecio.Value = 7
            If Session.sCodEmp = "05" Then
                cmbCodRub.Value = "15"
            End If
        End If
            state_Search = True
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oMercaderiaService.Close()
            oModeloService.Close()
            oTipoMotorService.Close()
            oPrecioService.Close()
            oCodigoBarraService.Close()
            oListaFabrica.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oMercaderiaService.Abort()
            oModeloService.Abort()
            oTipoMotorService.Abort()
            oPrecioService.Abort()
            oCodigoBarraService.Abort()
            oListaFabrica.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oMercaderiaService.Abort()
            oModeloService.Abort()
            oTipoMotorService.Abort()
            oPrecioService.Abort()
            oCodigoBarraService.Abort()
            oListaFabrica.Abort()
        Catch ex As Exception
            GC.SuppressFinalize(Me)
        End Try

    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtCodMer.KeyUp _
                          , txtDesMer1.KeyUp
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

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim permiso As SeguridadService.PermisoUsuario
            Dim precio As Boolean
            permiso = oSeguridadService.MostrarPermisos(Session.sCodUsu)
            precio = permiso.Precio

            If txtCodMer.Text.Trim = "" Then
                MsgBox("Debe Ingresar el código del Producto", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf txtDesMer1.Text = "" Then
                MsgBox("Debe Ingresar el descripción del Producto", MsgBoxStyle.Information, "Información")
                txtDesMer1.BackColor = Color.Red
                txtDesMer1.Focus()
                Return False
            ElseIf toNumber(IdClase) = 0 Then
                MsgBox("Debe Ingresar la categoria del Producto", MsgBoxStyle.Information, "Información")
                txtClase.BackColor = Color.Red
                btnBuscarClase.Focus()
                Return False
            ElseIf cmbCodUniMed.Value = "" Then
                MsgBox("Debe Ingresar la Unidad de Medida del Producto", MsgBoxStyle.Information, "Información")
                cmbCodUniMed.BackColor = Color.Red
                cmbCodUniMed.Focus()
                Return False
            ElseIf cmbCodRub.Value = "" Then
                MsgBox("Debe Ingresar el rubro del Producto", MsgBoxStyle.Information, "Información")
                cmbCodRub.BackColor = Color.Red
                cmbCodRub.Focus()
                Return False
            ElseIf cmbCodRub.Value = "01" And toBlank(cmbTipMot.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Motor", MsgBoxStyle.Information, "Información")
                cmbTipMot.Focus()
                Return False
            ElseIf cmbCodRub.Value = 4 And cmbModMer.Value = "" Then
                MsgBox("Debe Ingresar el modelo del Producto", MsgBoxStyle.Information, "Información")
                cmbModMer.BackColor = Color.Red
                cmbModMer.Focus()
            ElseIf cmbCodRub.Value = 4 And cmbCodRubMot.Value = "" Then
                MsgBox("Debe Ingresar el rubro del motor", MsgBoxStyle.Information, "Información")
                cmbCodRubMot.BackColor = Color.Red
                cmbCodRubMot.Focus()
            ElseIf toNull(CodPar) = Nothing Then
                MsgBox("Debe Ingresar la partida del Producto", MsgBoxStyle.Information, "Información")
                txtPartida.BackColor = Color.Red
                btnBuscarPartida.Focus()
                Return False
            ElseIf toNull(CodMar) = Nothing Then
                MsgBox("Debe Ingresar la marca del Producto", MsgBoxStyle.Information, "Información")
                txtMarca.BackColor = Color.Red
                btnBuscarMarca.Focus()
                Return False
                'ElseIf toBlank(txtAplicacion.Text) = "" Then
                '    MsgBox("Debe Ingresar la Aplicación", MsgBoxStyle.Information, "Información")
                '    txtAplicacion.BackColor = Color.Red
                '    btnBuscarAplicacion.Focus()
                '    Return False
            ElseIf toBlank(cmbCodMov.Value) = "" Then
                MsgBox("Debe Ingresar el Movimiento", MsgBoxStyle.Information, "Información")
                cmbCodMov.BackColor = Color.Red
                cmbCodMov.Focus()
                Return False
                'ElseIf toBlank(cmbListaPrecio.Text) = "" And cmbCodRub.Value = "01" Then
                '    MsgBox("Debe Ingresar la Lista de Precio", MsgBoxStyle.Information, "Información")
                '    cmbListaPrecio.BackColor = Color.Red
                '    cmbListaPrecio.Focus()
                '    Return False
            ElseIf cmbListaPrecio.Value = 0 Then
                MsgBox("Debe Ingresar la Lista de Precio", MsgBoxStyle.Information, "Información")
                cmbListaPrecio.BackColor = Color.Red
                cmbListaPrecio.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe Ingresar el Proveedor de la Mercadería", MsgBoxStyle.Information, "Información")
                btnBuscarProveedor.Focus()
                Return False
            ElseIf state_button = False And oMercaderiaService.Buscar(toNull(txtCodMer.Text), Session.sCodEmp) = True Then
                MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Text = ""
                txtCodMer.Focus()
                Return False

                '(And cmbCodRub.Value <> 4) Agregado el 26/02/2012 se valida que las mercaderías con rubro diferente de Equipos (4) el precio FOB sea obligatorio
                'ElseIf txtDeaMer.Value = 0 And cmbCodRub.Value <> 4 Then
                '    'If precio = True Then
                '    MsgBox("El precio FOB no puede ser 0", MsgBoxStyle.Information, "Información")
                '    txtDeaMer.Focus()
                '    Return False
                'Else
                'Return True
                'End If

                'Comentado por Orden de Cesar 25-02-13
                'ElseIf txtPesMer.Value = 0 Then
                '    'If precio = True Then
                '    MsgBox("El Peso no puede ser 0", MsgBoxStyle.Information, "Información")
                '    txtPesMer.Focus()
                '    Return False
                'ElseIf cmbUnidMedPeso.Text = "" Then
                '    'If precio = True Then
                '    MsgBox("Debe ingresar la Unidad de Medida de Peso", MsgBoxStyle.Information, "Información")
                '    cmbUnidMedPeso.Focus()
                '    Return False 
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ProductoService.Producto)
        Try
            Dim estado_process As Boolean
            estado_process = oMercaderiaService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                If MsgBox("¿Desea que el producto sea ingresada a una locación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim frm As New frmProductoLocacion
                    frm.CodMer = txtCodMer.Text
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        MsgBox("Se ingreso a la locación correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ProductoService.Producto)
        Try
            Dim estado_process As Boolean
            estado_process = oMercaderiaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
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
            estado_process = oMercaderiaService.Borrar(txtCodMer.Text.Trim, Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            Dim registro As ProductoService.Producto
            registro = oMercaderiaService.Obtener(toNull(txtCodMer.Text), Session.sCodEmp)

            txtCodMer.Text = registro.CodMer
            IdClase = registro.ClaseMerca.IdClase
            txtClase.Text = registro.ClaseMerca.NomClas
            txtDesMer1.Text = registro.DesMer1
            txtDesMer2.Text = registro.DesMer2
            txtObsMer.Text = registro.ObsMer
            txtDeaMer.Text = registro.DeaMer
            txtCorMer.Text = registro.CorMer
            '----------------------------- Se agregó el 11/09/2013 (César) --------------------------
            txtFleteMer.Text = registro.Flete
            '-------------------------------------------------------------------------------------------------------
            txtNueMer.Text = registro.NueMer
            txtAntMer.Text = registro.AntMer
            txtPesMer.Text = registro.PesMer
            'CodGru = registro.GrupoMerca.CodGru
            'txtGrupo.Text = registro.GrupoMerca.DesGru
            CodPais = registro.Pais.CodPais
            txtPais.Text = registro.Pais.DesPais
            CodPar = registro.Partida.CodPar
            txtPartida.Text = registro.Partida.ParPar
            CodMar = registro.Marca.CodMar
            txtMarca.Text = registro.Marca.DesMar
            CodApl = registro.AplicacionMerca.CodApl
            txtAplicacion.Text = registro.AplicacionMerca.DesApl
            state_Search = True
            cmbModMer.Value = toBlank(registro.Modelo.ModMer)
            cmbTipMot.Value = toBlank(registro.TipoMotor.TipMot)
            cmbCodUniMed.Value = toBlank(registro.UnidadMedida.CodUniMed)
            cmbCodRub.Value = toBlank(registro.Rubro.CodRub)
            cmbCodRubMot.Value = toBlank(registro.RubroMotor.CodRubMot)
            cmbCodMov.Value = toBlank(registro.Movimiento.CodMov)
            'cmbCodSubMov.Value = toBlank(registro.SubMovimiento.CodSubMov)
            chkActivo.Checked = registro.Activo
            'txtPesMerKg.Text = Math.Round(txtPesMer.Text / 2.20462262, 4)
            cmbUnidMedPeso.Value = toBlank(registro.UnidadMedidaPeso.CodUniMedPeso)
            cmbListaPrecio.Value = registro.ListaPrecios.IdListaPre

            '-------------------------14/02/2012---------------------------
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            '--------------------------------------------------------------------

            If Not (registro.FecPreserva.ToString = "") Then
                txtFecPreserv.Value = CDate(registro.FecPreserva)
                txtFecPreserv.Text = registro.FecPreserva.ToString
            End If

            If Not (registro.FecVenPreserva.ToString = "") Then
                txtFecVctoPreserv.Value = CDate(registro.FecVenPreserva)
                txtFecVctoPreserv.Text = registro.FecVenPreserva.ToString
            End If

            'txtFecPreserv.Value = registro.FecPreserva
            'txtFecVctoPreserv.Value = registro.FecVenPreserva

            Dim permiso As SeguridadService.PermisoUsuario
            Dim precio As Boolean
            permiso = oSeguridadService.MostrarPermisos(Session.sCodUsu)
            precio = permiso.PrecioFob

            If precio = True Then
                txtDeaMer.ReadOnly = False
                txtDeaMer.BackColor = System.Drawing.SystemColors.Window
                txtCorMer.ReadOnly = False
                txtCorMer.BackColor = System.Drawing.SystemColors.Window
            Else
                txtDeaMer.ReadOnly = True
                txtDeaMer.BackColor = System.Drawing.SystemColors.Control
                txtCorMer.ReadOnly = True
                txtCorMer.BackColor = System.Drawing.SystemColors.Control
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MODELOS ================================================
            dtModelos = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            dtModelos.Rows.InsertAt(getRowTodos(dtModelos), 0)
            cmbModMer.DataSource = dtModelos
            cmbModMer.DropDownList.DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.DisplayMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.ValueMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(0).DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(1).DataMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.SelectedIndex = 0
            dtModelos = Nothing

            'dtModelosMotor = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            'cmbModeloMer.DataSource = dtModelosMotor
            'cmbModeloMer.DropDownList.DataMember = dtModelosMotor.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.DisplayMember = dtModelosMotor.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.ValueMember = dtModelosMotor.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.Columns(0).DataMember = dtModelosMotor.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.Columns(1).DataMember = dtModelosMotor.Columns("Descripcion").ToString
            'cmbModeloMer.SelectedIndex = 0
            'dtModelosMotor = dtModelosMotor

            '======================================= TIPOS DE MOTORES =========================================
            dtTiposMotores = oTipoMotorService.Mostrar(Session.sCodEmp).Tables(0)
            dtTiposMotores.Rows.InsertAt(getRowTodos(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            dtTiposMotores = Nothing
            '======================================= UNIDAD DE MEDIDA =========================================
            dtUnidadesMedida = oMaestro.MostrarUnidadMedida.Tables(0)
            'dtUnidadesMedida.Rows.InsertAt(getRowTodos(dtUnidadesMedida), 0)
            cmbCodUniMed.DataSource = dtUnidadesMedida
            cmbCodUniMed.DropDownList.DataMember = dtUnidadesMedida.Columns("Nombre").ToString
            cmbCodUniMed.DropDownList.DisplayMember = dtUnidadesMedida.Columns("Nombre").ToString
            cmbCodUniMed.DropDownList.ValueMember = dtUnidadesMedida.Columns("CodUniMed").ToString
            cmbCodUniMed.DropDownList.Columns(0).DataMember = dtUnidadesMedida.Columns("CodUniMed").ToString
            cmbCodUniMed.DropDownList.Columns(1).DataMember = dtUnidadesMedida.Columns("Nombre").ToString
            dtUnidadesMedida = Nothing
            '======================================= RUBROS ================================================
            dtRubros = oMercaderiaService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing
            '======================================= RUBRO MOTOR ================================================
            dtRubrosMotor = oMaestro.MostrarRubroMotor.Tables(0)
            dtRubrosMotor.Rows.InsertAt(getRowTodos(dtRubrosMotor), 0)
            cmbCodRubMot.DataSource = dtRubrosMotor
            cmbCodRubMot.DropDownList.DataMember = dtRubrosMotor.Columns("DesRubMot").ToString
            cmbCodRubMot.DropDownList.DisplayMember = dtRubrosMotor.Columns("DesRubMot").ToString
            cmbCodRubMot.DropDownList.ValueMember = dtRubrosMotor.Columns("CodRubMot").ToString
            cmbCodRubMot.DropDownList.Columns(0).DataMember = dtRubrosMotor.Columns("CodRubMot").ToString
            cmbCodRubMot.DropDownList.Columns(1).DataMember = dtRubrosMotor.Columns("DesRubMot").ToString
            dtRubrosMotor = Nothing
            '======================================= MOVIMIENTOS ===============================================
            dtMovimientos = oMaestro.MostrarMovimiento.Tables(0)
            'dtMovimientos.Rows.InsertAt(getRowTodos(dtMovimientos), 0)
            cmbCodMov.DataSource = dtMovimientos
            cmbCodMov.DropDownList.DataMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.DisplayMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.ValueMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(0).DataMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(1).DataMember = dtMovimientos.Columns("DesMov").ToString
            dtMovimientos = Nothing
            '======================================= SUB MOVIMIENTOS ===========================================
            dtCodUniMed = oMercaderiaService.MostrarUniMedPeso.Tables(0)
            cmbUnidMedPeso.DataSource = dtCodUniMed
            cmbUnidMedPeso.DropDownList.DataMember = dtCodUniMed.Columns("Nombre").ToString
            cmbUnidMedPeso.DropDownList.DisplayMember = dtCodUniMed.Columns("Nombre").ToString
            cmbUnidMedPeso.DropDownList.ValueMember = dtCodUniMed.Columns("CodUniMedPes").ToString
            cmbUnidMedPeso.DropDownList.Columns(0).DataMember = dtCodUniMed.Columns("CodUniMedPes").ToString
            cmbUnidMedPeso.DropDownList.Columns(1).DataMember = dtCodUniMed.Columns("Nombre").ToString
            dtCodUniMed = Nothing
            '======================================= LISTA PRECIO ===========================================
            dtListaPrecios = oPrecioService.MostrarListaPreciosVigentes.Tables(0)  'oMarcaService.MostrarMarcasListaPrecio.Tables(0)
            dtListaPrecios.Rows.InsertAt(getRowTodos(dtListaPrecios), 0)
            cmbListaPrecio.DataSource = dtListaPrecios
            cmbListaPrecio.DropDownList.DataMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.DropDownList.DisplayMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.DropDownList.ValueMember = dtListaPrecios.Columns("IdListaPre").ToString
            cmbListaPrecio.DropDownList.Columns(0).DataMember = dtListaPrecios.Columns("IdListaPre").ToString
            cmbListaPrecio.DropDownList.Columns(1).DataMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.SelectedIndex = 0
            dtListaPrecios = Nothing

            ''====================================== MODELOS ===============================================
            'dtModeloMer = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            'cmbModeloMer.DataSource = dtModeloMer
            'cmbModeloMer.DropDownList.DataMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.DisplayMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.ValueMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.Columns(0).DataMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.Columns(1).DataMember = dtModeloMer.Columns("Descripcion").ToString
            'cmbModeloMer.SelectedIndex = 0
            'dtModeloMer = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnBuscarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClase.Click
        Dim frm As New frmBuscarClase
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtClase.Text = frm.descripcion
            txtClase.BackColor = System.Drawing.SystemColors.Control
            IdClase = frm.codigo
        End If
        txtClase.Focus()
    End Sub

    Private Sub btnBuscarGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarGrupo.Click
        Dim frm As New frmBuscarLectoresAsistencia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtGrupo.Text = frm.descripcion
            txtGrupo.BackColor = System.Drawing.SystemColors.Control
            CodGru = frm.codigo
        End If
        txtGrupo.Focus()

    End Sub
    Private Sub btnBuscarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPais.Click
        Dim frm As New frmBuscarPais
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtPais.Text = frm.descripcion
            txtPais.BackColor = System.Drawing.SystemColors.Control
            CodPais = frm.codigo
        End If
        txtPais.Focus()
    End Sub
    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        Dim frm As New frmBuscarPartida
        frm.txtCodPar.Text = toBlank(CodPar)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtPartida.Text = frm.descripcion
            txtPartida.BackColor = System.Drawing.SystemColors.Control
            CodPar = frm.codigo
        End If
        txtPartida.Focus()
    End Sub
    Private Sub btnBuscarMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            CodMar = frm.codigo
        End If
        txtMarca.Focus()
    End Sub
    Private Sub btnBuscarAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAplicacion.Click
        Dim frm As New frmBuscarAplicacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtAplicacion.Text = frm.descripcion
            txtAplicacion.BackColor = System.Drawing.SystemColors.Control
            CodApl = frm.codigo
        End If
        txtAplicacion.Focus()
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
           
            If Len(Trim(txtCodMer.Text)) > 0 Then

                If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
                    MsgBox("El código ya existe,Verifique")
                    txtCodMer.Clear()
                    txtCodMer.Focus()
                Else
                    'Dim Marca As Integer = 0
                    'If Mid(txtCodMer.Text, 1) = "P" Then
                    '    Marca = 4
                    'Else
                    '    Marca = 1
                    'End If

                    If oListaFabrica.BuscarPrecioGeneralVigente(Session.sCodEmp, txtCodMer.Text) Then
                        Dim registro As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
                        Dim idlista As Integer = oListaFabrica.ObtenerIdListaPreGeneralVigente(Session.sCodEmp, txtCodMer.Text)
                        registro = oListaFabrica.ObtenerPrecioCodigoVigente(Session.sCodEmp, idlista, txtCodMer.Text)
                        txtDesMer1.Text = registro.DesMer
                        txtDesMer2.Text = registro.DesMer
                        CodGru = Nothing  'registro.Mercaderia.GrupoMerca.CodGru
                        txtGrupo.Text = Nothing  'registro.Mercaderia.GrupoMerca.DesGru
                        CodPais = Nothing  'registro.Pais.CodPais
                        txtPais.Text = Nothing  'registro.Pais.DesPais
                        CodApl = Nothing  'registro.Mercaderia.AplicacionMerca.CodApl
                        txtAplicacion.Text = Nothing  'registro.Mercaderia.AplicacionMerca.DesApl
                        CodMar = Nothing  'registro.Mercaderia.Marca.CodMar
                        txtMarca.Text = Nothing  'registro.Mercaderia.Marca.DesMar
                        txtDeaMer.Text = registro.PreLista  'registro.Dealer
                        txtCorMer.Text = 0.00 'registro.PreCore
                        txtPesMer.Text = Nothing  'registro.Weight
                        cmbUnidMedPeso.Value = Nothing  'registro.UnitWeight
                        cmbListaPrecio.Value = idlista

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar datos")
        End Try
    End Sub

    'Private Sub txtPesMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPesMer.Validating
    '    cmbPesMerKg.Value = toBlank(registro.UnidadMedidaPeso.CodUniMedPeso)
    'End Sub

    Private Sub cmbCodRub_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodRub.ValueChanged
        If cmbCodRub.Value = 4 Then
            lblFOB.Visible = False  '--------Agregado el 26/02/2012 
            lblAstMod.Visible = True
            lblAstRubMot.Visible = True
            lblTipoMotor.Visible = False
        Else
            If cmbCodRub.Value = 1 Then
                lblTipoMotor.Visible = True
            Else
                lblTipoMotor.Visible = False
            End If
            lblFOB.Visible = True   '--------Agregado el 26/02/2012
            lblAstMod.Visible = False
            lblAstRubMot.Visible = False
        End If
        'If cmbCodRub.Value = 1 Then
        '    lbllista.Visible = True
        'Else
        '    lbllista.Visible = False
        'End If
    End Sub

    Private Sub txtGrupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrupo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbModMer.Focus()
        End If
    End Sub

    Private Sub listaDatosCodBarra()

        Try
            dtCodigoBarra = oCodigoBarraService.Mostrar(txtCodMer.Text).Tables(0)
            dgvCodBarra.DataSource = dtCodigoBarra

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar datos")
        End Try

    End Sub

    Private Sub listaDatosImagen()

        Try
            dtImagen = oMercaderiaService.MostrarImagen(txtCodMer.Text, Session.sCodEmp).Tables(0)
            dgvImagen.DataSource = dtImagen

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar datos")
        End Try

    End Sub

    Private Sub listaDatosModeloMotor()

        Try
            dtModeloMotor = oMercaderiaService.MostrarModelo(Session.sCodEmp, txtCodMer.Text).Tables(0)
            dgvModeloMotor.DataSource = dtModeloMotor

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar datos")
        End Try

    End Sub


    Private Sub btnAgregarCodBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCodBar.Click, miAgregarBarra.Click
        txtCodBar.Text = ""
        txtCodBar.Enabled = True
        biGuardarCodBarra.Enabled = True
    End Sub


    Private Sub InsertarCodBarra(ByVal registro As CodigoBarraService.CodigoBarra)

        Try
            Dim estado_process As Boolean

            estado_process = oCodigoBarraService.Insertar(registro)

            If estado_process = True Then
                listaDatosCodBarra()
                txtCodBar.Text = ""
            End If

            txtCodBar.Enabled = False
            biGuardarCodBarra.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Barra")
        End Try

    End Sub

    Private Sub EliminarCodBar()
        Try
            Dim estado_process_delete As Boolean

            estado_process_delete = oCodigoBarraService.Borrar(dgvCodBarra.CurrentRow.Cells("CodBar").Value, dgvCodBarra.CurrentRow.Cells("CodMer").Value)

            If estado_process_delete = True Then
                listaDatosCodBarra()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Eliminar Barra")
        End Try


    End Sub

    'Private Sub dgvCodBarra_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCodBarra.SelectionChanged
    '    If dgvCodBarra.CurrentRow.Cells("CodBar").Value = 0 Then
    '        txtCodBar.Text = ""
    '    Else
    '        txtCodBar.Text = dgvCodBarra.CurrentRow.Cells("CodBar").Value
    '    End If
    'End Sub

    Private Sub btnEliminarCodBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCodBar.Click, miEliminarBarra.Click
        If MsgBox("¿Está seguro de ELIMINAR el Código de Barra: " & dgvCodBarra.CurrentRow.Cells("CodBar").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            EliminarCodBar()
        End If
    End Sub


    Private Sub biGuardarCodBarra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardarCodBarra.Click, miAgregarBarra.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And txtCodBar.Text <> "" Then

            Dim registro As New CodigoBarraService.CodigoBarra
            Dim mercaderia As New CodigoBarraService.Mercaderia
            'Dim extension As New CodigoBarraService.

            registro.CodBar = txtCodBar.Text
            mercaderia.CodMer = txtCodMer.Text
            registro.Mercaderia = mercaderia

            InsertarCodBarra(registro)

        End If
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

            Dim registro As New ProductoService.Producto
            Dim empresa As New ProductoService.Empresa
            Dim rubro As New ProductoService.Rubro
            Dim modelo As New ProductoService.Modelo
            Dim tipoMotor As New ProductoService.TipoMotor
            Dim claseMerca As New ProductoService.ClaseMerca
            Dim unidadMedida As New ProductoService.UnidadMedida
            Dim rubroMotor As New ProductoService.RubroMotor
            Dim marca As New ProductoService.Marca
            Dim aplicacionMerca As New ProductoService.AplicacionMerca
            Dim movimiento As New ProductoService.Movimiento
            'Dim submovimiento As New MercaderiaService.SubMovimiento
            'Dim grupo As New MercaderiaService.GrupoMerca
            Dim pais As New ProductoService.Pais
            Dim partida As New ProductoService.Partida
            Dim UnidadMedidaPeso As New ProductoService.UnidadMedidaPeso
            Dim Proveedor As New ProductoService.Proveedor        ' Agregado el 14/02/2012
            Dim ListaPrecio As New ProductoService.ListaPrecios

            registro.CodMer = toNull(txtCodMer.Text)
            empresa.CodEmp = Session.sCodEmp
            claseMerca.IdClase = toNull(IdClase)
            registro.Empresa = empresa
            registro.ClaseMerca = claseMerca
            registro.DesMer1 = toNull(txtDesMer1.Text)
            registro.DesMer2 = toNull(txtDesMer2.Text)
            registro.ObsMer = toNull(txtObsMer.Text)
            registro.DeaMer = toNull(txtDeaMer.Text)
            registro.CorMer = toNull(txtCorMer.Text)
            '----------------------------- Se agregó el 11/09/2013 (César) --------------------------
            registro.Flete = toNull(txtFleteMer.Text)
            '-------------------------------------------------------------------------------------------------------
            modelo.ModMer = toNull(cmbModMer.Value)
            registro.Modelo = modelo
            registro.NueMer = toNull(txtNueMer.Text)
            registro.AntMer = toNull(txtAntMer.Text)
            tipoMotor.TipMot = toNull(cmbTipMot.Value)
            registro.TipoMotor = tipoMotor
            registro.PesMer = toNull(txtPesMer.Text)
            UnidadMedidaPeso.CodUniMedPeso = toNull(cmbUnidMedPeso.Value)
            registro.UnidadMedidaPeso = UnidadMedidaPeso
            unidadMedida.CodUniMed = toNull(cmbCodUniMed.Value)
            registro.UnidadMedida = unidadMedida
            'grupo.CodGru = toNull(CodGru)
            'registro.GrupoMerca = grupo
            rubro.CodRub = toNull(cmbCodRub.Value)
            registro.Rubro = rubro
            rubroMotor.CodRubMot = toNull(cmbCodRubMot.Value)
            registro.RubroMotor = rubroMotor
            pais.CodPais = toNull(CodPais)
            registro.Pais = pais
            partida.CodPar = toNull(CodPar)
            registro.Partida = partida
            marca.CodMar = toNull(CodMar)
            registro.Marca = marca
            aplicacionMerca.CodApl = toNull(CodApl)
            registro.AplicacionMerca = aplicacionMerca
            movimiento.CodMov = toNull(cmbCodMov.Value)
            registro.Movimiento = movimiento
            'submovimiento.CodSubMov = toNull(cmbCodSubMov.Value)
            'registro.SubMovimiento = submovimiento
            registro.Activo = chkActivo.Checked
            ListaPrecio.IdListaPre = toNull(cmbListaPrecio.Value)
            registro.ListaPrecios = ListaPrecio
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            '----------Agregado el 14/02/2012---------
            Proveedor.IdProveedor = IdProveedor
            registro.Proveedor = Proveedor
            '-----------------------------------------------------
            registro.FecPreserva = IIf(txtFecPreserv.Text = "", Nothing, txtFecPreserv.Value) 'txtFecPreserv.Value
            registro.FecVenPreserva = IIf(txtFecVctoPreserv.Text = "", Nothing, txtFecVctoPreserv.Value) ' txtFecVctoPreserv.Value

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If txtCodMer.Text.Trim.Length > 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '---------------------------------------------------------------------Agregado el 14/02/2012-----------------------------------------------------------------------
    Private Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtObsMer.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObsMer.Focus()
        End If
    End Sub

    Private Sub btnAgregarImagen_Click(sender As Object, e As EventArgs) Handles btnAgregarImagen.Click, miAgregarImagen.Click
        Dim lLog As Boolean = True
        While lLog
            Dim frm As New frmProducto_Imagen
            frm.state_button = False

            frm.CodMer = txtCodMer.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatosImagen()
                If frm.type_process = "insert" Then
                    RowPossesionImagen(dgvImagen, frm.IdImagen)
                End If
            Else
                lLog = False
            End If
        End While
    End Sub

    Private Sub btnEliminarImagen_Click(sender As Object, e As EventArgs) Handles btnEliminarImagen.Click, miEliminarImagen.Click
        If ValidaCodigoSeleccionadoImagen() Then
            EliminarImagen()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionadoImagen() As Boolean
        Try
            If dgvImagen.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvImagen.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvImagen.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EliminarImagen()
        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la imagen seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oMercaderiaService.BorrarImagen(toNumber(dgvImagen.CurrentRow.Cells("IdImagen").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatosImagen()
                    'MsgBox("Se eliminó la imagen correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA IMAGEN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub InsertarModeloMotor(ByVal registro As ProductoService.ProductosModelos)

    '    Try
    '        Dim estado_process As Boolean

    '        estado_process = oMercaderiaService.InsertarModelo(registro)

    '        If estado_process = True Then
    '            listaDatosModeloMotor()
    '            txtObserModMotor.Text = ""
    '        End If

    '        'txtCodBar.Enabled = False
    '        'biGuardarCodBarra.Enabled = False

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Barra")
    '    End Try

    'End Sub

    Private Sub EliminarModeloMotor()
        Try
            Dim estado_process_delete As Boolean

            estado_process_delete = oMercaderiaService.BorrarModelo(dgvModeloMotor.CurrentRow.Cells("CodMer").Value, Session.sCodEmp, dgvModeloMotor.CurrentRow.Cells("ModMer").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process_delete = True Then
                listaDatosModeloMotor()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Eliminar Barra")
        End Try


    End Sub

    Private Sub btnAgregarModelo_Click(sender As Object, e As EventArgs) Handles btnAgregarModelo.Click, miAgregarModeloMotor.Click

        Dim lLog As Boolean = True
        While lLog
            Dim frm As New frmProducto_ModeloMotor
            frm.state_button = False

            frm.CodMer = txtCodMer.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatosModeloMotor()
                'If frm.type_process = "insert" Then
                'RowPossesionModelo(dgvModeloMotor, frm.ModMer)
                'End If
            Else
                lLog = False
            End If
        End While

        'If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And cmbModeloMer.Text <> "" Then

        '    Dim registro As New ProductoService.ProductosModelos
        '    Dim modelomotor As New ProductoService.ModelosProducto
        '    Dim producto As New ProductoService.Producto
        '    Dim empresa As New ProductoService.Empresa
        '    'Dim extension As New CodigoBarraService.

        '    modelomotor.ModMer = cmbModeloMer.Value
        '    modelomotor.Descripcion = cmbModeloMer.DropDownList.GetRow.Cells(1).Text   'cmbModeloMer.Text

        '    '
        '    'modelomotor.Empresa = empresa

        '    registro.ModelosProducto = modelomotor

        '    producto.CodMer = txtCodMer.Text

        '    empresa.CodEmp = Session.sCodEmp
        '    producto.Empresa = empresa
        '    registro.Producto = producto

        '    registro.CodUsu = Session.sCodUsu
        '    registro.NomPc = Session.sNomPc
        '    registro.DirIp = Session.sDirIp

        '    registro.Observacion = txtObserModMotor.Text

        '    InsertarModeloMotor(registro)

        'End If

    End Sub

    Private Sub btnActualizarModelo_Click(sender As Object, e As EventArgs) Handles btnActualizarModelo.Click, miMostrarModelo.Click

        If ValidaCodigoSeleccionadoModeloMotor() Then
            ModificarModelo()
        End If

    End Sub

    Private Sub ModificarModelo()

        Dim frm As New frmProducto_ModeloMotor
        frm.state_button = True
        frm.ModMer = dgvModeloMotor.CurrentRow.Cells("ModMer").Text
        frm.CodMer = txtCodMer.Text

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatosModeloMotor()
            'If frm.type_process = "actualizar" Then
            'RowPossesionModelo(dgvModeloMotor, frm.ModMer)
            'End If
        Else

        End If

    End Sub

    Private Sub btnEliminarModelo_Click(sender As Object, e As EventArgs) Handles btnEliminarModelo.Click, miEliminarModeloMotor.Click
        If ValidaCodigoSeleccionadoModeloMotor() Then
            If MsgBox("¿Está seguro de ELIMINAR el Modelo Motor: " & dgvModeloMotor.CurrentRow.Cells("ModMer").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                EliminarModeloMotor()
            End If
        End If


    End Sub

    Private Function ValidaCodigoSeleccionadoModeloMotor() As Boolean
        Try
            If dgvModeloMotor.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvModeloMotor.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvModeloMotor.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miMostrarImagen_Click(sender As Object, e As EventArgs) Handles miMostrarImagen.Click, dgvImagen.DoubleClick, btnMostrarImagen.Click

        If ValidaCodigoSeleccionadoImagen() Then
            mostrarImagen()
        End If

    End Sub

    Private Sub mostrarImagen()

        Dim CodMerMos As String
        CodMerMos = txtCodMer.Text

        If Not Directory.Exists("D:\ProductosImagen\" & CodMerMos) Then
            Directory.CreateDirectory("D: \ProductosImagen\" & CodMerMos)
        End If

        Dim registro As ProductoService.ImagenesProducto
        registro = oMercaderiaService.ObtenerImagen(dgvImagen.CurrentRow.Cells("IdImagen").Text)

        Dim pdfDoc() As Byte
        Dim NombreArchivo As String
        Dim Extension As String
        pdfDoc = registro.ArchivoData
        NombreArchivo = registro.Nombre
        Extension = registro.Extension

        System.IO.File.WriteAllBytes("D:\ProductosImagen\" & CodMerMos & "\" & NombreArchivo & Extension, pdfDoc)
        System.Diagnostics.Process.Start("D:\ProductosImagen\" & CodMerMos & "\" & NombreArchivo & Extension)

    End Sub

    Private Sub miModificarImagen_Click(sender As Object, e As EventArgs) Handles miModificarImagen.Click, btnActualizarImagen.Click
        If ValidaCodigoSeleccionadoImagen() Then
            ModificarImagen()
        End If
    End Sub

    Private Sub ModificarImagen()

        Dim frm As New frmProducto_Imagen_Actualizar
        frm.IdImagen = dgvImagen.CurrentRow.Cells("IdImagen").Text
        frm.CodMer = txtCodMer.Text

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatosImagen()
            If frm.type_process = "actualizar" Then
                RowPossesionImagen(dgvImagen, frm.IdImagen)
            End If
        Else

        End If

    End Sub

    Private Sub RowPossesionImagen(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdImagen").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS IMAGEN]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionModelo(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("ModMer").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS IMAGEN]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
End Class
