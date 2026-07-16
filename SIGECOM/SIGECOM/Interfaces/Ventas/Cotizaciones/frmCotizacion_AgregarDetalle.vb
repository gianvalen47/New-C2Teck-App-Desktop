Imports System.Windows.Forms

Public Class frmCotizacion_AgregarDetalle

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oModeloService As New ModelosProductoService.ModelosProductoServiceClient  'ModeloService.ModeloServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oSeguridad As New SeguridadService.SeguridadClient
    'Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oListaPrecioFabricante As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdCotizacionDet As Int64
    Public IdCotizacion As Int64
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Private CodMar As String
    Private dtModelos As DataTable
    Private IdLista As Integer
    Public IdSugerido As Integer
    Private listaGen As Boolean = True 'false se cambio porque validadba que tenga lista de precios pero hoy en dia ya no se usa 

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtPreMer.KeyPress _
                          , txtTotal.KeyPress _
                          , txtCanMer.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtStock.KeyPress _
                          , cmbModMer.KeyPress _
                          , txtObservacion.KeyPress _
                          , txtReferencia.KeyPress _
                          , txtDscMer.KeyPress
        ', txtMarca.KeyPress _
        ' , txtDesMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtMarca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarca.KeyDown
        If e.KeyCode = Keys.F12 Then
            If txtMarca.Text = "" And btnBuscarMarca.Enabled = True Then
                btnBuscarMarca_Click(sender, e)
            Else
                txtMarca.Focus()
            End If
        End If

    End Sub

    Private Sub frmCotizacion_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            txtCanMer.Select()
        Else                    'Nuevo

            btnBuscarMercaderia.Enabled = True
            txtItem.Value = oCotizacionDetalleService.SugerirItem(IdCotizacion)
            txtCodMer.Select()
            cbNoCore.Checked = False
            Me.Text = "Agregar Detalle"
        End If
        If estado = "GENERADO" Or estado = "GN" Or estado = "APROBADO" Or estado = "AP" Or state_button = False Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If

        Dim oPermisousuario As SeguridadService.PermisoUsuario
        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
        If oPermisousuario.Precio = False Then
            txtPreMer.ReadOnly = True
            txtDscMer.ReadOnly = True
            txtPreMer.BackColor = System.Drawing.SystemColors.Control
            txtDscMer.BackColor = System.Drawing.SystemColors.Control
        Else
            txtPreMer.ReadOnly = False
            txtDscMer.ReadOnly = False
            txtPreMer.BackColor = System.Drawing.SystemColors.Window
            txtDscMer.BackColor = System.Drawing.SystemColors.Window
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionDetalleService) = False Then
                oCotizacionDetalleService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If
            If isClosed(oModeloService) = False Then
                oModeloService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
            If isClosed(oListaPrecioFabricante) = False Then
                oMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtDesMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesMer.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Then
            'If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarMarca.Enabled = True Then
                btnBuscarMarca.Select()
            ElseIf btnBuscarMarca.Enabled = False Then
                txtCanMer.Focus()
            End If
        End If
    End Sub

    Private Sub txtMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarMarca.Enabled = True Then
                btnBuscarMarca.Select()
            ElseIf btnBuscarMarca.Enabled = False Then
                txtCanMer.Focus()
            End If
        End If
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtPreMer.KeyUp _
                          , txtCanMer.KeyUp _
                          , txtDesMer.KeyUp _
                          , txtCodMer.KeyUp _
                          , txtStock.KeyUp _
                          , txtDscMer.KeyUp
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
    Private Function calculateTotal() As Double
        txtTotal.Text = Math.Round((toNumber(txtCanMer.Value) * toDouble(txtPreMer.Text)) - (toDouble(txtPreMer.Value) * toDouble(txtDscMer.Text / 100)), 2)
    End Function
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Function existe() As Boolean
        If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Or oPrecioService.BuscarListaPrecioFabrica(IdLista, txtCodMer.Text) Then
            txtStock.ReadOnly = True
            'If CodMar = "" Then
            btnBuscarMarca.Enabled = True
            'Else
            '    btnBuscarMarca.Enabled = False
            'End If

            If cmbModMer.Value = "" Then
                cmbModMer.ReadOnly = False
            Else
                cmbModMer.ReadOnly = True
            End If
            txtDesMer.ReadOnly = False
            cbImportado.Checked = True

            ' txtDscMer.ReadOnly = True
            ' txtDscMer.BackColor = System.Drawing.SystemColors.Control
            Return True
        Else
            txtStock.ReadOnly = False
            btnBuscarMarca.Enabled = True
            txtDesMer.ReadOnly = False
            cbImportado.Checked = False
            cmbModMer.ReadOnly = False
            'txtDscMer.ReadOnly = False
            'txtDscMer.BackColor = System.Drawing.SystemColors.Window
            Return False
        End If
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCotizacion) = 0 Then
                MsgBox("Debe Ingresar el código de la cotización. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtItem.Value) = 0 Then
                MsgBox("Debe Ingresar el item del detalle", MsgBoxStyle.Information, "Información")
                txtItem.BackColor = Color.Red
                txtItem.Focus()
                Return False
            ElseIf toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
                'ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                '    MsgBox("Debe el precio del artículo ", MsgBoxStyle.Information, "Información")
                '    txtPreMer.BackColor = Color.Red
                '    txtPreMer.Focus()
                '    Return False
            ElseIf state_button = False And oCotizacionDetalleService.Buscar(IdCotizacion, toBlank(txtCodMer.Text)) = True And Trim(txtCodMer.Text).Substring(0, 3) <> "AAA" Then
                MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Text = ""
                txtCodMer.Focus()
                Return False
            ElseIf cbSugerir.Checked = True And txtPrecioSug.Value <= 0 Then
                MsgBox("El precio no es Válido", MsgBoxStyle.Information, "Información")
                txtPrecioSug.Focus()
                Return False
            ElseIf cbSugerir.Checked = True And txtDsctoSug.Value < 0 Then
                MsgBox("El descuento no es Válido", MsgBoxStyle.Information, "Información")
                txtPrecioSug.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub desactivar()
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        btnBuscarMercaderia.Enabled = False
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        btnBuscarMarca.Enabled = False
        txtDscMer.ReadOnly = True
        txtDscMer.BackColor = System.Drawing.SystemColors.Control
        txtCanMer.ReadOnly = True
        txtCanMer.BackColor = System.Drawing.SystemColors.Control
        txtPreMer.ReadOnly = True
        txtPreMer.BackColor = System.Drawing.SystemColors.Control
        txtItem.ReadOnly = True
        txtItem.BackColor = System.Drawing.SystemColors.Control
        txtPreMer.ReadOnly = True
        txtPreMer.BackColor = System.Drawing.SystemColors.Control
        cbImportado.Enabled = False
        txtReferencia.ReadOnly = True
        txtReferencia.BackColor = System.Drawing.SystemColors.Control
        cmbModMer.ReadOnly = True
        cmbModMer.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtPrecioSug.ReadOnly = True
        txtPrecioSug.BackColor = System.Drawing.SystemColors.Control
        txtDsctoSug.ReadOnly = True
        txtDsctoSug.BackColor = System.Drawing.SystemColors.Control
        cbNoCore.Enabled = False
        cbSugerir.Enabled = False
        txtPrecioSug.ReadOnly = True
        txtPrecioSug.BackColor = System.Drawing.SystemColors.Control
        txtDsctoSug.ReadOnly = True
        txtDsctoSug.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub Insertar(ByVal registro As CotizacionDetalleService.CotizacionDetalle)
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionDetalleService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCotizacionDet = estado_process
                If cbSugerir.Checked = True Then
                    oCotizacionDetalleService.InsertarSugerido(IdCotizacionDet, IdCotizacion, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoCotizacion", "IdSugerido", "IdCotizacion", IdCotizacion)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As CotizacionDetalleService.CotizacionDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionDetalleService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                If cbSugerir.Checked = True And IdSugerido > 0 Then
                    oCotizacionDetalleService.ActualizarSugerido(IdSugerido, IdCotizacionDet, IdCotizacion, txtPrecioSug.Value, txtDsctoSug.Value)
                ElseIf cbSugerir.Checked = True And IdSugerido = 0 Then
                    oCotizacionDetalleService.InsertarSugerido(IdCotizacionDet, IdCotizacion, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoCotizacion", "IdSugerido", "IdCotizacion", IdCotizacion)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionDetalleService.CotizacionDetalle

            registro = oCotizacionDetalleService.MostrarPorId(toNumber(IdCotizacion), toNumber(IdCotizacionDet))
            IdCotizacionDet = registro.IdCotizacionDet
            IdCotizacion = registro.Cotizacion.IdCotizacion
            txtCodMer.Text = registro.CodMer
            txtDesMer.Text = registro.DesMer
            txtCanMer.Text = registro.CanMer
            txtPreMer.Text = registro.PreMer
            txtDscMer.Text = registro.DscMer
            CodMar = registro.Marca.CodMar
            txtMarca.Text = registro.Marca.DesMar
            cmbModMer.Value = registro.Modelo.ModMer
            txtTotal.Text = registro.TotFila
            txtStock.Text = registro.Stock
            txtObservacion.Text = registro.Observacion
            txtReferencia.Text = registro.Referencia
            txtItem.Value = registro.Item
            cbNoCore.Checked = registro.NoCore
            'If oMaestroService.BuscarMercaderia(txtCodMer.Text) Or oPrecioService.BuscarListaPrecioFabrica(1, txtCodMer.Text) Then
            '    cbImportado.Checked = True
            'Else
            '    cbImportado.Checked = False
            'End If
            cbImportado.Checked = registro.Importado
            If IdSugerido > 0 Then
                cbSugerir.Checked = True
                cbSugerir.Enabled = False
                Dim Sugerido As CotizacionDetalleService.SugeridoCotizacionDet
                Sugerido = oCotizacionDetalleService.MostrarPorIdSugerido(IdSugerido, IdCotizacionDet)
                txtPrecioSug.Value = Sugerido.PreMerSug
                txtDsctoSug.Value = Sugerido.DsctoSug
            Else
                cbSugerir.Checked = False
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MODELOS ================================================
            dtModelos = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            dtModelos.Rows.InsertAt(getRowTodos(dtModelos), 0)
            cmbModMer.DataSource = dtModelos
            cmbModMer.DropDownList.DataMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.DropDownList.DisplayMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.DropDownList.ValueMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(0).DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(1).DataMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.SelectedIndex = 0
            dtModelos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New CotizacionDetalleService.CotizacionDetalle
            Dim cotizacion As New CotizacionDetalleService.Cotizacion
            Dim modelo As New CotizacionDetalleService.Modelo
            Dim marca As New CotizacionDetalleService.Marca
            Dim stockactual As Integer

            stockactual = toDouble(txtStock.Text) 'oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
            registro.IdCotizacionDet = IIf(toNumber(IdCotizacionDet) = 0, Nothing, IdCotizacionDet)
            cotizacion.IdCotizacion = IIf(toNumber(IdCotizacion) = 0, Nothing, IdCotizacion)

            registro.Cotizacion = cotizacion
            registro.CodMer = toNull(txtCodMer.Text)
            registro.DesMer = toNull(txtDesMer.Text)
            modelo.ModMer = toNull(cmbModMer.Value)
            registro.Modelo = modelo
            marca.CodMar = toNull(CodMar)
            registro.Marca = marca
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.PreMer = toDouble(txtPreMer.Text)
            registro.DscMer = toDouble(txtDscMer.Text)
            registro.Stock = stockactual 'toDouble(txtStock.Text)
            registro.Importado = cbImportado.Checked
            registro.Referencia = toNull(txtReferencia.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            registro.NoCore = cbNoCore.Checked
            registro.Item = txtItem.Value
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        Dim separado As Integer
        Dim oPermisousuario As SeguridadService.PermisoUsuario

        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
        separado = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            If existe() Then
                CodMar = frm.CodMar
                txtMarca.Text = frm.DesMar
                cmbModMer.Value = frm.ModMer
                txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
                If txtStock.Text < 0 Then
                    txtStock.Text = 0
                End If


                'Else
                'CodMar = ""
                'txtMarca.Text = ""
                'cmbModMer.Value = ""
                'txtPreMer.Text = 0.0
                'txtDscMer.Text = 0.0
                'txtStock.Text = 0
            End If
            ObtenerIdLista()
            CalcularPrecio() 'calculateTotal()
            existe()
            txtCodMer.Select()
        End If
    End Sub

    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click

        If state_button = False Then
            ComprobarPrecioMercaderia()
            ObtenerIdLista()
            If IdLista = 0 Or IdLista = 8 Then
                If txtCanMer.Value > txtStock.Text Then
                    If listaGen = False Then
                        txtPreMer.Value = 0.00
                    End If
                    calculateTotal()
                Else
                    calculateTotal()
                End If
            Else
                calculateTotal()
            End If
        Else
            calculateTotal()
        End If


    End Sub
    'Private Sub txtCodMer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodMer.Leave
    '    existe()
    'End Sub

    Private Sub ObtenerIdLista()
        Try

            IdLista = oMercaderiaService.ObtenerIdListaPre(txtCodMer.Text.Trim, Session.sCodEmp)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al obtener Id lista")
        End Try
    End Sub

    Private Sub CalcularPrecio()
        Try

            'If IdLista = 0 Or IdLista = 8 Then
            '    If txtCanMer.Value > txtStock.Text Then
            '        If listaGen = False Then
            '            txtPreMer.Value = 0.00
            '        End If
            '        calculateTotal()
            '    Else
            '        calculateTotal()
            '    End If
            'Else
            calculateTotal()
            ' End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al obtener Id lista")
        End Try
    End Sub

    Private Sub ComprobarPrecioMercaderia()

        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then
                Dim oPermisousuario As SeguridadService.PermisoUsuario
                oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)

                If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then

                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                    Dim separado As Integer

                    Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                    separado = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)

                    txtCodMer.Text = Mercaderia.CodMer
                    txtDesMer.Text = Mercaderia.DesMer1
                    CodMar = Mercaderia.Marca.CodMar
                    txtMarca.Text = Mercaderia.Marca.DesMar
                    cmbModMer.Value = Mercaderia.Modelo.ModMer
                    txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
                    txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                    txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                    calculateTotal()
                    If Trim(txtCodMer.Text).Substring(0, 3) <> "AAA" And oPermisousuario.Precio = False Then
                        txtPreMer.ReadOnly = True
                        txtDscMer.ReadOnly = True
                    Else
                        txtPreMer.ReadOnly = False
                        txtDscMer.ReadOnly = False
                    End If
                ElseIf oListaPrecioFabricante.BuscarPrecioGeneralVigente(Session.sCodEmp, txtCodMer.Text) Then

                    Dim Precio As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
                    Dim idListaPre As Integer = oListaPrecioFabricante.ObtenerIdListaPreGeneralVigente(Session.sCodEmp, txtCodMer.Text)
                    Dim separado As Integer


                    separado = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)
                    Precio = oListaPrecioFabricante.ObtenerPrecioCodigoVigente(Session.sCodEmp, idListaPre, txtCodMer.Text)
                    txtDesMer.Text = Precio.DesMer
                    CodMar = "" 'Precio.Mercaderia.Marca.CodMar
                    txtMarca.Text = "" 'Precio.Mercaderia.Marca.DesMar
                    cmbModMer.Value = "" 'Precio.Mercaderia.Modelo.ModMer
                    txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today) ' IIf(CodMon = "US", Precio.PreVenDol, Precio.PreVenSol)
                    txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
                    txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                    calculateTotal()
                    If oPermisousuario.Precio = False Then
                        txtPreMer.ReadOnly = True
                        txtDscMer.ReadOnly = True
                        txtPreMer.BackColor = System.Drawing.SystemColors.Control
                        txtDscMer.BackColor = System.Drawing.SystemColors.Control
                    Else
                        txtPreMer.ReadOnly = False
                        txtDscMer.ReadOnly = False
                        txtPreMer.BackColor = System.Drawing.SystemColors.Window
                        txtDscMer.BackColor = System.Drawing.SystemColors.Window
                    End If
                    'ElseIf oPrecioService.BuscarPrecioFabricaGeneral(txtCodMer.Text)
                    '    Dim preciofabrica As New PrecioService.PrecioFabrica
                    '    preciofabrica = oPrecioService.ObtenerPrecioFabricaGeneral(txtCodMer.Text)
                    '    Dim tc As Double = oSeguridad.MostrarTipoCambio("US", Today)

                    '    CodMar = preciofabrica.Mercaderia.Marca.CodMar
                    '    txtMarca.Text = preciofabrica.Mercaderia.Marca.DesMar
                    '    txtDesMer.Text = preciofabrica.Mercaderia.DesMer2
                    '    cmbModMer.Value = ""
                    '    txtPreMer.Text = IIf(CodMon = "US", preciofabrica.PreVenDol, Math.Round(preciofabrica.PreVenDol * tc, 2))
                    '    txtDscMer.Text = 0.0
                    '    txtStock.Text = 0
                    '    listaGen = True
                Else
                    CodMar = ""
                    txtMarca.Text = ""
                    cmbModMer.Value = ""
                    txtDesMer.Text = ""
                    txtPreMer.Text = 0.0
                    txtDscMer.Text = 0.0 'oPrecioService.DescuentoCliente(Session.sCodEmp, "01", IdCliente)
                    'txtPreMer.ReadOnly = False
                    'txtDscMer.ReadOnly = False
                    txtStock.Text = 0
                End If

                calculateTotal()
                existe()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        'If state_button = False Then

        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then
                Dim oPermisousuario As SeguridadService.PermisoUsuario
                oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)

                If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then

                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                    Dim separado As Integer

                    Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                    separado = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)

                    txtCodMer.Text = Mercaderia.CodMer
                    txtDesMer.Text = Mercaderia.DesMer1
                    CodMar = Mercaderia.Marca.CodMar
                    txtMarca.Text = Mercaderia.Marca.DesMar
                    cmbModMer.Value = Mercaderia.Modelo.ModMer
                    txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
                    txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                    txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                    calculateTotal()
                    If Trim(txtCodMer.Text).Substring(0, 3) <> "AAA" And oPermisousuario.Precio = False Then
                        txtPreMer.ReadOnly = True
                        txtDscMer.ReadOnly = True
                    Else
                        txtPreMer.ReadOnly = False
                        txtDscMer.ReadOnly = False
                    End If

                    '------------- Mensaje de Precio cuando el stock es 0 -------------
                    If toNumber(txtStock.Text) = 0 Then
                        lblMensajePrecio.Visible = True
                        lblMensajePrecio2.Visible = True
                    Else
                        lblMensajePrecio.Visible = False
                        lblMensajePrecio2.Visible = False
                    End If
                    '--------------------------------------------------------------------------------------

                ElseIf oListaPrecioFabricante.BuscarPrecioGeneralVigente(Session.sCodEmp, txtCodMer.Text) Then

                    Dim Precio As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
                    Dim idListaPre As Integer = oListaPrecioFabricante.ObtenerIdListaPreGeneralVigente(Session.sCodEmp, txtCodMer.Text)
                    Dim separado As Integer

                    separado = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)
                    Precio = oListaPrecioFabricante.ObtenerPrecioCodigoVigente(Session.sCodEmp, idListaPre, txtCodMer.Text)
                    txtDesMer.Text = Precio.DesMer
                    'CodMar = Precio.Mercaderia.Marca.CodMar
                    'txtMarca.Text = Precio.Mercaderia.Marca.DesMar
                    'cmbModMer.Value = Precio.Mercaderia.Modelo.ModMer
                    txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today) ' IIf(CodMon = "US", Precio.PreVenDol, Precio.PreVenSol)
                    txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
                    txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                    calculateTotal()
                    If oPermisousuario.Precio = False Then
                        txtPreMer.ReadOnly = True
                        txtDscMer.ReadOnly = True
                        txtPreMer.BackColor = System.Drawing.SystemColors.Control
                        txtDscMer.BackColor = System.Drawing.SystemColors.Control
                    Else
                        txtPreMer.ReadOnly = False
                        txtDscMer.ReadOnly = False
                        txtPreMer.BackColor = System.Drawing.SystemColors.Window
                        txtDscMer.BackColor = System.Drawing.SystemColors.Window
                    End If

                    '------------- Mensaje de Precio cuando el stock es 0 -------------
                    If toNumber(txtStock.Text) = 0 Then
                        lblMensajePrecio.Visible = True
                        lblMensajePrecio2.Visible = True
                    Else
                        lblMensajePrecio.Visible = False
                        lblMensajePrecio2.Visible = False
                    End If
                    '--------------------------------------------------------------------------------------


                    'ElseIf oPrecioService.BuscarPrecioFabricaGeneral(txtCodMer.Text)
                    '    Dim preciofabrica As New PrecioService.PrecioFabrica
                    '    preciofabrica = oPrecioService.ObtenerPrecioFabricaGeneral(txtCodMer.Text)
                    '    Dim tc As Double = oSeguridad.MostrarTipoCambio("US", Today)

                    '    CodMar = preciofabrica.Mercaderia.Marca.CodMar
                    '    txtMarca.Text = preciofabrica.Mercaderia.Marca.DesMar
                    '    txtDesMer.Text = preciofabrica.Mercaderia.DesMer2
                    '    cmbModMer.Value = ""
                    '    txtPreMer.Text = IIf(CodMon = "US", preciofabrica.PreVenDol, Math.Round(preciofabrica.PreVenDol * tc, 2))
                    '    txtDscMer.Text = 0.0
                    '    txtStock.Text = 0
                    '    listaGen = True

                Else
                    CodMar = ""
                    txtMarca.Text = ""
                    cmbModMer.Value = ""
                    txtDesMer.Text = ""
                    txtPreMer.Text = 0.0
                    txtDscMer.Text = 0.0 'oPrecioService.DescuentoCliente(Session.sCodEmp, "01", IdCliente)
                    'txtPreMer.ReadOnly = False
                    'txtDscMer.ReadOnly = False
                    txtStock.Text = 0

                    '---------------------------------------------------
                    lblMensajePrecio.Visible = False
                    lblMensajePrecio2.Visible = False
                    '---------------------------------------------------

                End If

                'Agregado 16-12 --------------
                ObtenerIdLista()
                CalcularPrecio()
                '-----------------------------
                calculateTotal()
                existe()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        ' End If
    End Sub

    Private Sub btnBuscarMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodMar = frm.codigo
            txtMarca.Text = frm.descripcion
        End If
        txtCanMer.Select()
        'txtMarca.Select()
    End Sub

    Private Sub cbSugerir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSugerir.CheckedChanged
        If cbSugerir.Checked Then
            lblPrecioSug.Visible = True
            lblPrecioSug2.Visible = True
            lblDsctoSug.Visible = True
            lblDsctoSug2.Visible = True
            txtPrecioSug.Visible = True
            txtDsctoSug.Visible = True
            If IdSugerido = 0 Then
                txtPrecioSug.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                txtDsctoSug.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
            End If
            txtPrecioSug.Focus()
        Else
            lblPrecioSug.Visible = False
            lblPrecioSug2.Visible = False
            lblDsctoSug.Visible = False
            lblDsctoSug2.Visible = False
            txtPrecioSug.Visible = False
            txtDsctoSug.Visible = False
            txtPrecioSug.Value = 0
            txtDsctoSug.Value = 0
        End If
    End Sub

    Private Sub txtPrecioSug_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioSug.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDsctoSug.Focus()
        End If
    End Sub

    Private Sub txtDsctoSug_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsctoSug.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub


End Class
