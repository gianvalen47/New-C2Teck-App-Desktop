Imports System.Windows.Forms

Public Class frmFactura_AgregarDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oSeguridad As New SeguridadService.SeguridadClient
    Private oFacturaDetalleService As New FacturaDetalleService.FacturaDetalleServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdFacturaDet As Integer
    Public IdFactura As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Public IdSugerido As Integer
    Public CodMot As String
    Private dtModelos As DataTable
    Private Flag As Boolean = True

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
                          , txtDesMer.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtStock.KeyPress _
                          , txtItem.KeyPress _
                          , txtDscMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmFactura_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtDesMer.Select()
        Else                    'Nuevo
            If CodMot = "10" Then
                cbAnticipo.Visible = True
                cbAnticipo.Checked = False
            End If
            btnBuscarMercaderia.Enabled = True
            txtItem.Value = oFacturaDetalleService.SugerirItem(IdFactura)
            cbNoCore.Checked = False
        End If
        If estado = "GENERADO" Or estado = "GN" Or estado = "APROBADO" Or estado = "AP" Or state_button = False Then
            btnGuardar.Enabled = True

            Dim oPermisousuario As SeguridadService.PermisoUsuario
            Dim aprobar As FacturaService.Factura
            oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
            aprobar = oFacturaService.MostrarPorId(IdFactura)

            If oPermisousuario.Precio = False Then
                If aprobar.Motivos.Aprobar = False Then
                    txtPreMer.ReadOnly = False
                    txtDscMer.ReadOnly = False
                    txtPreMer.BackColor = System.Drawing.SystemColors.Window
                    txtDscMer.BackColor = System.Drawing.SystemColors.Window
                Else
                    txtPreMer.ReadOnly = True
                    txtDscMer.ReadOnly = True
                    txtPreMer.BackColor = System.Drawing.SystemColors.Control
                    txtDscMer.BackColor = System.Drawing.SystemColors.Control
                End If
            Else
                txtPreMer.ReadOnly = False
                txtDscMer.ReadOnly = False
                txtPreMer.BackColor = System.Drawing.SystemColors.Window
                txtDscMer.BackColor = System.Drawing.SystemColors.Window
            End If

            If state_button Then
                If Mid(Trim(txtCodMer.Text), 1, 3) = "AAA" Then
                    txtPreMer.ReadOnly = False
                    txtDscMer.ReadOnly = False
                    txtPreMer.BackColor = System.Drawing.SystemColors.Window
                    txtDscMer.BackColor = System.Drawing.SystemColors.Window
                End If
            End If
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oFacturaDetalleService) = False Then
                oFacturaDetalleService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If
            If isClosed(oFacturaService) = False Then
                oFacturaService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
        txtTotal.Text = Math.Round((toNumber(txtCanMer.Value) * toDouble(txtPreMer.Text)) - (toNumber(txtPreMer.Value) * toDouble(txtDscMer.Text / 100)), 2)
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
    Private Sub desactivar()
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        txtDscMer.ReadOnly = True
        txtDscMer.BackColor = System.Drawing.SystemColors.Control
        txtCanMer.ReadOnly = True
        txtCanMer.BackColor = System.Drawing.SystemColors.Control
        txtItem.ReadOnly = True
        txtItem.BackColor = System.Drawing.SystemColors.Control
        txtPreMer.ReadOnly = True
        txtPreMer.BackColor = System.Drawing.SystemColors.Control
        cbNoCore.Enabled = False
        cbSugerir.Enabled = False
        txtPrecioSug.ReadOnly = True
        txtPrecioSug.BackColor = System.Drawing.SystemColors.Control
        txtDsctoSug.ReadOnly = True
        txtDsctoSug.BackColor = System.Drawing.SystemColors.Control
        cbRegalo.Enabled = False
        cbAnticipo.Enabled = False
        txtSerieDocRef.ReadOnly = True
        txtSerieDocRef.BackColor = System.Drawing.SystemColors.Control
        txtNumDocRef.ReadOnly = True
        txtNumDocRef.BackColor = System.Drawing.SystemColors.Control

    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdFactura) = 0 Then
                MsgBox("Debe Ingresar el código de la factura. ", MsgBoxStyle.Information, "Información")
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
            ElseIf txtDesMer.Text = "" Then
                MsgBox("Debe la descripción del artículo ", MsgBoxStyle.Information, "Información")
                txtDesMer.BackColor = Color.Red
                txtDesMer.Focus()
                Return False
                'ElseIf toNumber(txtCanMer.Value) <= 0 Then
                '    MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                '    txtCanMer.BackColor = Color.Red
                '    txtCanMer.Focus()
                '    Return False
            ElseIf state_button = False And toNumber(txtStock.Text) <= 0 And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" And oFacturaService.TipMov(IdFactura) = "D" Then
                MsgBox("No hay STOCK para esta mercadería. ", MsgBoxStyle.Information, "Información")
                txtCodMer.Text = ""
                txtCodMer.Focus()
                Return False

                'ElseIf Trim(txtCodMer.Text).Substring(0, 3) <> "AAA" Then

            ElseIf state_button = False And toNumber(txtCanMer.Value) > toNumber(txtStock.Text) And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" And oFacturaService.TipMov(IdFactura) = "D" Then
                MsgBox("Cantidad no pueder ser mayor que Stock. ", MsgBoxStyle.Information, "Información")
                txtCanMer.Focus()
                Return False
                'End If

            ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 And cbSugerir.Checked = False Then
                MsgBox("Debe Ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf state_button = False And (oFacturaDetalleService.Buscar(IdFactura, toBlank(txtCodMer.Text)) And cbRegalo.Checked = False) And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" Then
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
            ElseIf state_button = True And oFacturaService.Estado(IdFactura) <> "GENERADO" And oFacturaService.Estado(IdFactura) <> "APROBADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf cbAnticipo.Checked = True And txtSerieDocRef.Text = "" Then
                MsgBox("Debe ingresar la serie del documento del anticipo", MsgBoxStyle.Information, "Información")
                txtSerieDocRef.Focus()
                Return False
            ElseIf cbAnticipo.Checked = True And txtNumDocRef.Text = "" Then
                MsgBox("Debe ingresar el numero del documento del anticipo", MsgBoxStyle.Information, "Información")
                txtNumDocRef.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As FacturaDetalleService.FacturaDetalle)
        Try
            Dim estado_process As Integer
            estado_process = oFacturaDetalleService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdFacturaDet = estado_process
                If cbSugerir.Checked = True Then
                    oFacturaDetalleService.InsertarSugerido(IdFacturaDet, IdFactura, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoFactura", "IdSugerido", "IdFactura", IdFactura)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As FacturaDetalleService.FacturaDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oFacturaDetalleService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                If cbSugerir.Checked = True And IdSugerido > 0 Then
                    oFacturaDetalleService.ActualizarSugerido(IdSugerido, IdFacturaDet, IdFactura, txtPrecioSug.Value, txtDsctoSug.Value)
                ElseIf cbSugerir.Checked = True And IdSugerido = 0 Then
                    oFacturaDetalleService.InsertarSugerido(IdFacturaDet, IdFactura, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoFactura", "IdSugerido", "IdFactura", IdFactura)
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
            Dim registro As FacturaDetalleService.FacturaDetalle
            registro = oFacturaDetalleService.MostrarPorId(toNumber(IdFacturaDet))

            IdFacturaDet = registro.IdFacturaDet
            IdFactura = registro.Factura.IdFactura
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtCanMer.Text = registro.CanMer
            txtPreMer.Text = registro.PreMer
            txtDscMer.Text = registro.DscMer
            txtTotal.Text = registro.TotalFila
            txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
            txtItem.Value = registro.Item
            cbRegalo.Checked = registro.Regalo
            cbNoCore.Checked = registro.NoCore
            cbAnticipo.Checked = registro.Anticipo
            txtSerieDocRef.Text = registro.CodSerieAnt
            txtNumDocRef.Text = registro.NumDocAnt
            If IdSugerido > 0 Then
                cbSugerir.Checked = True
                cbSugerir.Enabled = False
                Dim Sugerido As FacturaDetalleService.SugeridoFacturaDet
                Sugerido = oFacturaDetalleService.MostrarSugeridoPorId(IdSugerido, IdFacturaDet)
                txtPrecioSug.Value = Sugerido.PreMerSug
                txtDsctoSug.Value = Sugerido.DsctoSug
            Else
                cbSugerir.Checked = False
            End If
            estado = oFacturaService.Estado(IdFactura)
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
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

            Dim registro As New FacturaDetalleService.FacturaDetalle
            Dim factura As New FacturaDetalleService.Factura
            Dim mercaderia As New FacturaDetalleService.Mercaderia

            registro.IdFacturaDet = IIf(toNumber(IdFacturaDet) = 0, Nothing, IdFacturaDet)
            factura.IdFactura = IIf(toNumber(IdFactura) = 0, Nothing, IdFactura)
            registro.Factura = factura
            mercaderia.CodMer = toNull(txtCodMer.Text)
            mercaderia.DesMer1 = toNull(txtDesMer.Text)
            registro.Mercaderia = mercaderia
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.PreMer = toDouble(txtPreMer.Text)
            registro.DscMer = toDouble(txtDscMer.Text)
            registro.Item = txtItem.Value
            registro.Regalo = cbRegalo.Checked
            registro.NoCore = cbNoCore.Checked

            If CodMot = "10" And cbAnticipo.Checked Then
                registro.Anticipo = cbAnticipo.Checked
                registro.CodSerieAnt = txtSerieDocRef.Text
                registro.NumDocAnt = txtNumDocRef.Text
            End If




            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        Dim oPermisousuario As SeguridadService.PermisoUsuario
        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
        frm.IdLocacion = IdLocacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            Dim LocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderia
            LocacionMercaderia = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, frm.codigo)

            txtDesMer.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text) 'oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)

            'VERIFICAR SI EL MOTIVO ES TRANSFERENCIA GRATUITA , SI ES ASI ME DARA COMO RESULTADO EL COSTO---------
            If CodMot = "2" Then
                txtPreMer.Text = IIf(CodMon = "NS", LocacionMercaderia.CosSol, LocacionMercaderia.CosDol)
                txtDscMer.Text = 0
            Else
                txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
            End If

            calculateTotal()
            txtCodMer.Select()
        End If
    End Sub
    'Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click
    '    calculateTotal()
    'End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If state_button = False Then
            Try
               
                If Len(Trim(txtCodMer.Text)) > 0 Then
                    If oLocacionMercaderiaService.Buscar(IdLocacion, txtCodMer.Text) Then
                        Dim LocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderia
                        LocacionMercaderia = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, txtCodMer.Text)
                        txtDesMer.Text = LocacionMercaderia.Mercaderia.DesMer1
                        'txtCodMer.Text = LocacionMercaderia.Mercaderia.CodMer
                        txtCodMer.BackColor = System.Drawing.SystemColors.Window
                        txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text)

                        'VERIFICAR SI EL MOTIVO ES TRANSFERENCIA GRATUITA , SI ES ASI ME DARA COMO RESULTADO EL COSTO---------
                        If CodMot = "2" Then
                            txtPreMer.Text = IIf(CodMon = "NS", LocacionMercaderia.CosSol, LocacionMercaderia.CosDol)
                            txtDscMer.Text = 0
                        Else
                            txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                            txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                        End If
                        '-----------------------------------------------------------------------------------------------------

                        '----------VALIDAR COMODIN Y PERMISOS USUARIOS PARA MODIFICAR PRECIO------------------
                        Dim oPermisousuario As SeguridadService.PermisoUsuario
                        Dim aprobar As FacturaService.Factura
                        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
                        aprobar = oFacturaService.MostrarPorId(IdFactura)

                        If oPermisousuario.Precio = False Then
                            If Mid(Trim(txtCodMer.Text), 1, 3) = "AAA" Then
                                txtPreMer.ReadOnly = False
                                txtDscMer.ReadOnly = False
                                txtPreMer.BackColor = System.Drawing.SystemColors.Window
                                txtDscMer.BackColor = System.Drawing.SystemColors.Window
                            Else
                                If aprobar.Motivos.Aprobar = False Then
                                    txtPreMer.ReadOnly = False
                                    txtDscMer.ReadOnly = False
                                    txtPreMer.BackColor = System.Drawing.SystemColors.Window
                                    txtDscMer.BackColor = System.Drawing.SystemColors.Window
                                Else
                                    txtPreMer.ReadOnly = True
                                    txtDscMer.ReadOnly = True
                                    txtPreMer.BackColor = System.Drawing.SystemColors.Control
                                    txtDscMer.BackColor = System.Drawing.SystemColors.Control
                                End If
                            End If
                        Else
                            txtPreMer.ReadOnly = False
                            txtDscMer.ReadOnly = False
                            txtPreMer.BackColor = System.Drawing.SystemColors.Window
                            txtDscMer.BackColor = System.Drawing.SystemColors.Window
                        End If
                        '------------------------------------------------------------------------------
                        calculateTotal()
                    Else
                        MsgBox("No existe el codigo ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                        txtCodMer.Clear()
                        txtCodMer.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Obtener Mercaderia")
            End Try
        End If
    End Sub

    Private Sub txtCanMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCanMer.Validating
        Try
            If state_button Then
                Dim registro As FacturaDetalleService.FacturaDetalle
                registro = oFacturaDetalleService.MostrarPorId(toNumber(IdFacturaDet))
                Dim CantStock As Integer
                CantStock = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text) + registro.CanMer
                If state_button And toNumber(txtCanMer.Value) > CantStock And oFacturaService.TipMov(IdFactura) <> "O" And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" Then
                    MsgBox("No hay stock para esta mercaderia")
                    txtCanMer.Value = registro.CanMer
                    txtCanMer.Select()
                End If
            End If
            calculateTotal()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

    Private Sub txtPreMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPreMer.Validating
        Try
            calculateTotal()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtDscMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDscMer.Validating
        Try
            calculateTotal()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbRegalo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRegalo.CheckedChanged
        Try

            If Flag = True Then
                If toBlank(txtCodMer.Text) = "" Then
                    MsgBox("Debe ingresar el código de la mercadería")
                    Flag = False
                    cbRegalo.Checked = False
                    Flag = True

                Else
                    If oMercaderiaService.BuscarRegalo(txtCodMer.Text) = False Then
                        MsgBox("Esta mercadería no se puede regalar, tenga cuidado")
                        Flag = False
                        cbRegalo.Checked = False
                        Flag = True
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al Poner Mercaderia como Regalo" + ex.Message)
        End Try
    End Sub

    Private Sub cbAnticipo_CheckedChanged(sender As Object, e As EventArgs) Handles cbAnticipo.CheckedChanged
        If cbAnticipo.Checked Then
            cbAnticipo.Visible = True
            lblSerieAnti.Visible = True
            lblNumDocAnt.Visible = True
            txtSerieDocRef.Visible = True
            txtNumDocRef.Visible = True
            btnBuscarAnticipo.Visible = True
            txtSerieDocRef.Focus()
        Else
            lblSerieAnti.Visible = False
            lblNumDocAnt.Visible = False
            txtSerieDocRef.Visible = False
            txtNumDocRef.Visible = False
            btnBuscarAnticipo.Visible = False
            txtSerieDocRef.Text = ""
            txtNumDocRef.Text = ""
        End If
    End Sub

    Private Sub btnBuscarAnticipo_Click(sender As Object, e As EventArgs) Handles btnBuscarAnticipo.Click
        Dim frm As New frmBuscarAnticipos

        frm.IdDocumento = 3
        frm.IdCliente = IdCliente
        frm.CodMon = CodMon
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtSerieDocRef.Text = frm.codSerie
            txtNumDocRef.Text = frm.Numdoc
            txtPreMer.Value = frm.totVenta
            txtDscMer.Value = 0
            txtCanMer.Value = -1
            txtCodMer.Text = "AAA09"
            txtDesMer.Text = "ANTICIPO: FACTURA NRO. " & frm.documento
            calculateTotal()
            txtDesMer.Select()
        End If
    End Sub
End Class
