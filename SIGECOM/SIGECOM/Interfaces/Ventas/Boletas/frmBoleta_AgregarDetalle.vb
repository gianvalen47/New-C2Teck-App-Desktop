Imports System.Windows.Forms

Public Class frmBoleta_agregarDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oSeguridad As New SeguridadService.SeguridadClient
    Private oBoletaDetalleService As New BoletaDetalleService.BoletaDetalleServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdBoletaDet As Integer
    Public IdBoleta As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Public TipMov As String
    Public IdSugerido As Integer
    Public CodMot As String   '----------(04/07/2012) Agregado para validar que cuando sea motivo Transferencia Gratuita ('2') el precio debe de ser el Costo (SOLO PARA ESTE MOTIVO) y no el precio de venta 
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
                          , txtDscMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmBoleta_agregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            txtCodMer.ReadOnly = False
            btnBuscarMercaderia.Enabled = True
            txtItem.Value = oBoletaDetalleService.SugerirItem(IdBoleta)
            cbNoCore.Checked = False
            txtCodMer.Select()
        End If

        If estado = "GENERADO" Or estado = "GN" Or estado = "APROBADO" Or estado = "AP" Or state_button = False Then
            btnGuardar.Enabled = True

            Dim oPermisousuario As SeguridadService.PermisoUsuario
            Dim aprobar As BoletaService.Boleta
            oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
            aprobar = oBoletaService.MostrarPorId(IdBoleta)

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
            If isClosed(oBoletaDetalleService) = False Then
                oBoletaDetalleService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If
            If isClosed(oBoletaService) = False Then
                oBoletaService.Close()
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
                    'campo.BackColor = Color.Red
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
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdBoleta) = 0 Then
                MsgBox("Debe Ingresrar el código de la Boleta. ", MsgBoxStyle.Information, "Información")
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
            ElseIf state_button = False And toNumber(txtStock.Text) <= 0 And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" And TipMov = "D" Then
                MsgBox("No hay STOCK para esta merdadería. ", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
                Return False
            ElseIf state_button = False And toNumber(txtCanMer.Value) > toNumber(txtStock.Text) And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" And TipMov = "D" Then
                MsgBox("Cantidad no pueder ser mayor que Stock. ", MsgBoxStyle.Information, "Información")
                txtCanMer.Focus()
                Return False
            ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                MsgBox("Debe Ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf state_button = False And (oBoletaDetalleService.Buscar(IdBoleta, toBlank(txtCodMer.Text)) And cbRegalo.Checked = False) And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" Then
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
            ElseIf state_button = True And oBoletaService.Estado(IdBoleta) <> "GENERADO" And oBoletaService.Estado(IdBoleta) <> "APROBADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As BoletaDetalleService.BoletaDetalle)
        Try
            Dim estado_process As Integer
            estado_process = oBoletaDetalleService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdBoletaDet = estado_process
                If cbSugerir.Checked = True Then
                    oBoletaDetalleService.InsertarSugerido(IdBoletaDet, IdBoleta, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoBoleta", "IdSugerido", "IdBoleta", IdBoleta)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As BoletaDetalleService.BoletaDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oBoletaDetalleService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                If cbSugerir.Checked = True And IdSugerido > 0 Then
                    oBoletaDetalleService.ActualizarSugerido(IdSugerido, IdBoletaDet, IdBoleta, txtPrecioSug.Value, txtDsctoSug.Value)
                ElseIf cbSugerir.Checked = True And IdSugerido = 0 Then
                    oBoletaDetalleService.InsertarSugerido(IdBoletaDet, IdBoleta, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoBoleta", "IdSugerido", "IdBoleta", IdBoleta)
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
            Dim registro As BoletaDetalleService.BoletaDetalle
            registro = oBoletaDetalleService.MostrarPorId(toNumber(IdBoletaDet))

            IdBoletaDet = registro.IdBoletaDet
            IdBoleta = registro.Boleta.IdBoleta
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
            If IdSugerido > 0 Then
                cbSugerir.Checked = True
                cbSugerir.Enabled = False
                Dim Sugerido As BoletaDetalleService.SugeridoBoletaDet
                Sugerido = oBoletaDetalleService.MostrarSugeridoPorId(IdSugerido, IdBoletaDet)
                txtPrecioSug.Value = Sugerido.PreMerSug
                txtDsctoSug.Value = Sugerido.DsctoSug
            Else
                cbSugerir.Checked = False
            End If
            estado = oBoletaService.Estado(IdBoleta)
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

            Dim registro As New BoletaDetalleService.BoletaDetalle
            Dim boleta As New BoletaDetalleService.Boleta
            Dim mercaderia As New BoletaDetalleService.Mercaderia

            registro.IdBoletaDet = IIf(toNumber(IdBoletaDet) = 0, Nothing, IdBoletaDet)
            boleta.IdBoleta = IIf(toNumber(IdBoleta) = 0, Nothing, IdBoleta)
            registro.Boleta = boleta
            mercaderia.CodMer = toNull(txtCodMer.Text)
            mercaderia.DesMer1 = toNull(txtDesMer.Text)
            registro.Mercaderia = mercaderia
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.PreMer = toDouble(txtPreMer.Text)
            registro.DscMer = toDouble(txtDscMer.Text)
            registro.Item = txtItem.Value
            registro.Regalo = cbRegalo.Checked
            registro.NoCore = cbNoCore.Checked
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
        frm.IdLocacion = IdLocacion
        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)

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
                        ' txtCodMer.Text = LocacionMercaderia.Mercaderia.CodMer
                        txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text)
                        txtDesMer.Text = LocacionMercaderia.Mercaderia.DesMer1

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
                        Dim aprobar As BoletaService.Boleta
                        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
                        aprobar = oBoletaService.MostrarPorId(IdBoleta)

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
                        '---------------------------------------------------------------------------------------
                        calculateTotal()
                    Else
                        MsgBox("No existe el código ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                        txtCodMer.Clear()
                        txtCodMer.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub txtCanMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCanMer.Validating
        Try
            If state_button Then
                Dim registro As BoletaDetalleService.BoletaDetalle
                registro = oBoletaDetalleService.MostrarPorId(toNumber(IdBoletaDet))
                Dim CantStock As Integer
                CantStock = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text) + registro.CanMer
                If state_button And toNumber(txtCanMer.Value) > CantStock And TipMov = "D" And Mid(Trim(txtCodMer.Text), 1, 3) <> "AAA" Then
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
            lblDsctoSug.Visible = True
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

    Private Sub cbRegalo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRegalo.CheckedChanged
        Try

            If Flag = True Then
                If toBlank(txtCodMer.Text) = "" Then
                    MsgBox("Debe ingresar el código de la mercaderia")
                    Flag = False
                    cbRegalo.Checked = False
                    Flag = True

                Else
                    If oMercaderiaService.BuscarRegalo(txtCodMer.Text) = False Then
                        MsgBox("Esta mercaderia no se puede regalar, tenga cuidado")
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

End Class
