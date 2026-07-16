Imports System.Windows.Forms

Public Class frmAgregarDetalle_Documento

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Private Modifi As Boolean = False
    Public type_process As String               'update     insert      delete
    Private Modificable As Boolean = False
    Private oFacturaImportDetService As New FacturaImportDetService.FacturaImportDetServiceClient
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMarcaService As New MarcaService.MarcaServiceClient
    Private oPartidaService As New PartidaService.PartidaServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oPrecioService As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private dtPedidos As DataTable

    Public IdDetFactura As String
    Public IdFactura As String
    Public estado As String
    Public precioEvaluado As Double

    Private CodPais As String
    Private CodPar As String
    Private CodMar As String
    Private IdLocacion As String
    Private DisDomMer As Double
    Private DisIntMer As Double
    Private Descuento As Double
    Private IdDetPedidoImp As String
    Private IdPedidoImp As String
    Private pedido As Integer
    Private pedidodet As Integer
    Public Item As Integer
    Private CodMer As String
    Public IdSerieImp As Integer

    Private dtCodUniMedPeso As DataTable          '----------- Agregado el 16/04/2013 -----------

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                        txtCanMer.KeyPress _
    '                      , txtItem.KeyPress _
    '                      , txtPais.KeyPress _
    '                      , txtMarca.KeyPress _
    '                      , txtCodMer.KeyPress _
    '                      , txtDesMer2.KeyPress _
    '                      , txtDesMer1.KeyPress _
    '                      , txtPartida.KeyPress _
    '                      , txtDeaMer.KeyPress _
    '                      , cbApliFle.KeyPress _
    '                      , txtDesPar.KeyPress _
    '                      , cbAnulado.KeyPress _
    '                      , cbApliNucleo.KeyPress _
    '                      , cbApliGes.KeyPress _
    '                      , txtObsMer.KeyPress _
    '                      , txtalmacen.KeyPress _
    '                      , cmbPedidos.KeyPress _
    '                      , txtTotal.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub
    Private Sub txtItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCanMer.Focus()
        End If
    End Sub

    Private Sub txtCanMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCanMer.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            txtItem.Focus()
        End If
    End Sub
    Private Sub txtCanMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCanMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send = ("(TAB)")
            txtCodMer.Focus()
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarMercaderia_Click_1(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtCanMer.Focus()
        End If
    End Sub
    Private Sub txtCodMar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMar.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarMarca_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtCodMer.Focus()
        End If
    End Sub
    Private Sub txtCodPais_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPais.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarPais_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtCodMar.Focus()
        End If
    End Sub
    Private Sub txtCodPartida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPartida.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarPartida_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up Then
            If txtObsMer.Enabled = True Then
                txtObsMer.Focus()
            Else
                txtDesMer1.Focus()
            End If
        End If
    End Sub
    Private Sub txtalmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtalmacen.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarAlmacen_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up Then
            If cmbPedidos.Enabled = True Then
                cmbPedidos.Focus()
            Else
                txtDeaMer.Focus()
            End If
        End If
    End Sub
    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCodMar.Focus()
        End If
    End Sub
    Private Sub txtCodMar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCodPais.Focus()
        End If
    End Sub
    Private Sub txtCodPais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPais.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDesMer1.Focus()
        End If
    End Sub

    Private Sub txtDesMer1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesMer1.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            txtCodPais.Focus()
        End If
    End Sub
    Private Sub txtDesMer1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesMer1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'If txtObsMer.Enabled = False Then
            '    txtCodPartida.Focus()
            'Else
            '    txtObsMer.Focus()
            'End If
            '----- Agregado el 16/04/2013 -----
            txtPesMer.Focus()
            '----------------------------------------------
        End If
    End Sub
    '-------------------------------------------------------------- Agregado el 16/04/2013 ----------------------------------------------------------------
    Private Sub txtPesMer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesMer.KeyUp
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            txtDesMer1.Focus()
        End If
    End Sub
    'Private Sub txtPesMer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesMer.KeyUp
    '    If e.KeyCode = Keys.Right Then
    '        e.Handled = True
    '        cmbUnidMedPeso.Focus()
    '    End If
    'End Sub
    Private Sub txtPesMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If cmbUnidMedPeso.ReadOnly = True Then
                cmbUnidMedPeso.Focus()
            Else
                cmbUnidMedPeso.Focus()
                cmbUnidMedPeso.DroppedDown = True
            End If
        End If
    End Sub
    Private Sub cmbUnidMedPeso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbUnidMedPeso.KeyUp
        If e.KeyCode = Keys.Left Then
            e.Handled = True
            txtPesMer.Focus()
        End If
    End Sub
    Private Sub cmbUnidMedPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUnidMedPeso.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If txtObsMer.Enabled = False Then
                txtCodPartida.Focus()
            Else
                txtObsMer.Focus()
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub txtObsMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCodPartida.Focus()
        End If
    End Sub
    Private Sub txtCodPartida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPartida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDeaMer.Focus()
        End If
    End Sub

    Private Sub txtDeaMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeaMer.KeyUp
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            txtCodPartida.Focus()
        End If
    End Sub
    Private Sub txtDeaMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeaMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDscto.Focus()
            'If cmbPedidos.Enabled = False Then
            '    btnBuscarAlmacen.Focus()
            'Else
            '    cmbPedidos.Focus()
            '    cmbPedidos.DroppedDown = True
            'End If
        End If
    End Sub
    Private Sub txtDscto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDscto.KeyUp
        If e.KeyCode = Keys.Left Then
            e.Handled = True
            txtDeaMer.Focus()
        End If
    End Sub
    Private Sub txtDscto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDscto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If cmbPedidos.Enabled = False Then
                btnBuscarAlmacen.Focus()
            Else
                cmbPedidos.Focus()
                cmbPedidos.DroppedDown = True
            End If
        End If
    End Sub
    Private Sub cmbPedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPedidos.Click
        Modifi = True
    End Sub

    Private Sub cmbPedidos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPedidos.GotFocus
        Modifi = True
    End Sub

    Private Sub cmbPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPedidos.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            txtDeaMer.Focus()
        End If
    End Sub
    Private Sub cmbPedidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPedidos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Modifi = True
            e.Handled = True
            If cmbPedidos.Value = 0 Then
                btnBuscarAlmacen.Focus()
            Else
                btnGuardar.Focus()
            End If
        End If
    End Sub
    Private Sub txtalmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtalmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarAlmacen.Enabled = True Then
                btnGuardar.Select()
            End If
        End If
    End Sub
    Private Sub frmAgregarDetalle_Documento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        cbApliGes.Checked = True
        llenarCombos()
        Dim frm As New frmDocumentos
        
        If state_button Then    'Modificar
            
            If estado = "PR" Or estado = "CH" Then

                txtItem.ReadOnly = True
                txtItem.TabStop = True
                txtCodMer.ReadOnly = True
                txtDesMer1.ReadOnly = True
                txtDesMer2.ReadOnly = True
                '--------------------- Agregado el 16/04/2013 ---------
                txtPesMer.ReadOnly = True
                txtPesMer.BackColor = System.Drawing.SystemColors.Control
                cmbUnidMedPeso.ReadOnly = True
                cmbUnidMedPeso.BackColor = System.Drawing.SystemColors.Control
                '------------------------------------------------------------------
                txtDeaMer.ReadOnly = True
                txtCanMer.ReadOnly = True
                '---------- Se agregó el 11/06/2014 Cesar -----------
                txtDscto.ReadOnly = True
                txtDscto.BackColor = System.Drawing.SystemColors.Control
                '-------------------------------------------------------------------
                cmbPedidos.ReadOnly = True
                btnBuscarAlmacen.Enabled = False
                btnBuscarMarca.Enabled = False
                txtCodMar.ReadOnly = True
                btnBuscarMercaderia.Enabled = False
                btnBuscarPais.Enabled = False
                txtCodPais.ReadOnly = True
                btnBuscarPartida.Enabled = False
                txtCodPartida.ReadOnly = True
                btnGuardar.Enabled = False
                cbAnulado.Enabled = False
                cbApliFle.Enabled = False
                cbApliGes.Enabled = False
                cbApliNucleo.Enabled = False
                txtObsMer.Enabled = False
                ObtenerRegistro()

            Else
                txtItem.ReadOnly = False
                txtItem.TabStop = True
                ObtenerRegistro()
            End If

        Else                    'Nuevo
            txtItem.ReadOnly = False
            txtItem.TabStop = True
            btnBuscarAlmacen.Enabled = False
            desactivar()

        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oFacturaImportDetService) = False Then
                oFacturaImportDetService.Close()
            End If
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
            If isClosed(oMarcaService) = False Then
                oMarcaService.Close()
            End If
            If isClosed(oPartidaService) = False Then
                oPartidaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtCanMer.KeyUp _
                          , txtItem.KeyUp _
                          , txtPais.KeyUp _
                          , txtMarca.KeyUp _
                          , txtCodMer.KeyUp _
                          , txtDesMer2.KeyUp _
                          , txtDesMer1.KeyUp _
                          , txtPartida.KeyUp _
                          , txtDesPar.KeyUp _
                          , txtObsMer.KeyUp _
                          , txtalmacen.KeyUp _
                          , txtTotal.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.IntegerUpDown" Then
                campo = New Janus.Windows.GridEX.EditControls.IntegerUpDown
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
        txtTotal.Text = (toNumber(txtCanMer.Value) * toDouble(txtDeaMer.Text)) - (toNumber(txtCanMer.Value) * toDouble(txtDscto.Value))
        'txtTotal.Text = (toNumber(txtCanMer.Value) * toDouble(txtDeaMer.Text)) - (toNumber(txtCanMer.Value) * toDouble(Descuento))      'Se regresa ya que ahora la caja de texto de dscto soporta 4 decimales 29/08/2014
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
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New FacturaImportDetService.FacturaImportDet
            Dim facturaImport As New FacturaImportDetService.FacturaImport
            Dim pedidoImpDet As New FacturaImportDetService.PedidoImportDet
            Dim pedidoImp As New FacturaImportDetService.PedidoImport
            dtPedidos = oFacturaImportDetService.MostrarPedidoImport(toNull(txtCodMer.Text)).Tables(0)
            cmbPedidos.DataSource = dtPedidos
            facturaImport.IdFactura = toNumber(IdFactura)
            registro.FacturaImport = facturaImport
            registro.IdDetFactura = toNumber(IdDetFactura)

            'pedidoImp.IdPedidoImp = IdPedidoImp

            registro.PedidoImpDet = pedidoImpDet
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el Código de la Mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) And txtDesMer1.Text = "" Then
                MsgBox("Debe Ingresar la Descripción de la Mercadería", MsgBoxStyle.Information, "Información")
                txtDesMer1.BackColor = Color.Red
                txtDesMer1.Focus()
                Return False
            ElseIf toNumber(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
            ElseIf cbApliNucleo.Checked = True And toDouble(txtDepNuc.Value) <= 0 Then
                MsgBox("El Deposito por Núcleo debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtDepNuc.Focus()
                Return False
            ElseIf IdSerieImp <> 2 And txtDeaMer.Text.Trim.Length > 0 And CDbl(txtDeaMer.Text.Trim) <= 0 Then
                MsgBox("Debe Ingresar el Precio del Artículo ", MsgBoxStyle.Information, "Información")
                txtDeaMer.BackColor = Color.Red
                txtDeaMer.Focus()
                Return False            
            ElseIf toNumber(IdLocacion) = 0 Then
                MsgBox("Debe Ingresar el Almacén del Detalle ", MsgBoxStyle.Information, "Información")
                txtalmacen.BackColor = Color.Red
                cmbPedidos.Clear()
                btnBuscarAlmacen.Focus()
                Return False
                'ElseIf toBlank(txtMarca.Text) = "" Then
                '    MsgBox("Debe Ingresar Marca de la Mercadería", MsgBoxStyle.Information, "Información")
                '    txtMarca.BackColor = Color.Red
                '    txtMarca.Focus()
                '    Return False
                'ElseIf toBlank(txtPais.Text) = "" Then
                '    MsgBox("Debe Ingresar País de la Mercadería", MsgBoxStyle.Information, "Información")
                '    txtPais.BackColor = Color.Red
                '    txtPais.Focus()
                '    Return False
                'ElseIf toBlank(txtPartida.Text) = "" Then
                '    MsgBox("Debe Ingresar Partida Arancelaria de la Mercadería", MsgBoxStyle.Information, "Información")
                '    txtPartida.BackColor = Color.Red
                '    txtPartida.Focus()
                '    Return False
                'ElseIf state_button = False And oFacturaImportDetService.Buscar(registro) = True Then
                '    MsgBox("El pedido ya existe en otro item, tenga cuidado... !", MsgBoxStyle.Information, "Información")
                '    txtCodMer.Focus()
                '    Return False
                'ElseIf dtPedidos.Rows.Count <> 0 And cmbPedidos.Value <> 0 Then
                '    If (txtCanMer.Value) > toNumber(txtCantidadPendiente.Text) And Modifi = True Then
                '        MsgBox("La Cantidad Solicitada no debe ser mayor que la Cantidad Pendiente. ", MsgBoxStyle.Information, "Información")
                '        txtCanMer.BackColor = Color.Red
                '        txtCanMer.Focus()
                '        Return False
                '    Else
                '        Return True
                '    End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As FacturaImportDetService.FacturaImportDet)
        Try
            Dim estado_process As Integer
            estado_process = oFacturaImportDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdDetFactura = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As FacturaImportDetService.FacturaImportDet)
        Try
            Dim estado_process As Boolean
            estado_process = oFacturaImportDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        txtCodMar.ReadOnly = False
        txtCodMar.BackColor = System.Drawing.SystemColors.Window
        txtCodPais.ReadOnly = False
        txtCodPais.BackColor = System.Drawing.SystemColors.Window
        txtDesMer1.ReadOnly = False
        txtDesMer1.BackColor = System.Drawing.SystemColors.Window
        txtDesMer2.ReadOnly = True
        txtDesMer2.BackColor = System.Drawing.SystemColors.Control
        '-------------------------Agregado el 16/04/2013 ----------------------------------
        txtPesMer.ReadOnly = False
        txtPesMer.BackColor = System.Drawing.SystemColors.Window
        cmbUnidMedPeso.ReadOnly = False
        cmbUnidMedPeso.BackColor = System.Drawing.SystemColors.Window
        '----------------------------------------------------------------------------------------------
        txtObsMer.ReadOnly = False
        txtObsMer.BackColor = System.Drawing.SystemColors.Window
        txtCodPartida.ReadOnly = False
        txtCodPartida.BackColor = System.Drawing.SystemColors.Window
        txtDeaMer.ReadOnly = False
        txtDeaMer.BackColor = System.Drawing.SystemColors.Window
        '----------------------- Agregadó el 11/06/2014 Cesar ------------------------
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window
        '---------------------------------------------------------------------------------------------
        btnBuscarAlmacen.Enabled = True
        btnBuscarMarca.Enabled = True
        btnBuscarPais.Enabled = True
        btnBuscarPartida.Enabled = True
        cbAnulado.Enabled = True
        cbApliFle.Enabled = True
        cbApliGes.Enabled = True
        cbApliNucleo.Enabled = True
        If cbApliNucleo.Checked = True Then
            txtDepNuc.ReadOnly = False
            txtDepNuc.BackColor = System.Drawing.SystemColors.Window
        Else
            txtDepNuc.ReadOnly = True
            txtDepNuc.BackColor = System.Drawing.SystemColors.Control
        End If
        cmbPedidos.ReadOnly = False
        cmbPedidos.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Sub desactivar()
        txtCodMar.ReadOnly = True
        txtCodMar.BackColor = System.Drawing.SystemColors.Control
        txtCodPais.ReadOnly = True
        txtCodPais.BackColor = System.Drawing.SystemColors.Control
        txtDesMer1.ReadOnly = True
        txtDesMer1.BackColor = System.Drawing.SystemColors.Control
        txtDesMer2.ReadOnly = True
        txtDesMer2.BackColor = System.Drawing.SystemColors.Control
        '-------------------------Agregado el 16/04/2013 ----------------------------------
        txtPesMer.ReadOnly = True
        txtPesMer.BackColor = System.Drawing.SystemColors.Control
        cmbUnidMedPeso.ReadOnly = True
        cmbUnidMedPeso.BackColor = System.Drawing.SystemColors.Control
        '----------------------------------------------------------------------------------------------
        txtObsMer.ReadOnly = True
        txtObsMer.BackColor = System.Drawing.SystemColors.Control
        txtCodPartida.ReadOnly = True
        txtCodPartida.BackColor = System.Drawing.SystemColors.Control
        txtDeaMer.ReadOnly = True
        txtDeaMer.BackColor = System.Drawing.SystemColors.Control
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window
        btnBuscarAlmacen.Enabled = False
        btnBuscarMarca.Enabled = False
        btnBuscarPais.Enabled = False
        btnBuscarPartida.Enabled = False
        cbAnulado.Enabled = False
        cbApliFle.Enabled = False
        cbApliGes.Enabled = False
        cbApliNucleo.Enabled = False
        txtDepNuc.ReadOnly = True
        txtDepNuc.BackColor = System.Drawing.SystemColors.Control
        cmbPedidos.ReadOnly = True
        cmbPedidos.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As FacturaImportDetService.FacturaImportDet
            registro = oFacturaImportDetService.MostrarPorId(toNumber(IdDetFactura))

            IdDetFactura = registro.IdDetFactura
            IdDetFactura = registro.IdDetFactura
            IdFactura = registro.FacturaImport.IdFactura
            txtTotal.Text = registro.Total

            txtCodMer.Text = registro.Mercaderia.CodMer
            CodMer = registro.Mercaderia.CodMer
            txtItem.Text = registro.Item
            txtCanMer.Text = registro.CanMer
            txtDeaMer.Text = registro.DeaMer
            txtDesMer1.Text = registro.Mercaderia.DesMer1
            txtDesMer2.Text = registro.Mercaderia.DesMer2
            '------------------------ Agregado el 16/04/2013 --------------------------
            txtPesMer.Value = registro.Mercaderia.PesMer
            If registro.Mercaderia.UnidadMedidaPeso.CodUniMedPeso = Nothing Then
                cmbUnidMedPeso.SelectedIndex = 0
            Else
                cmbUnidMedPeso.Value = registro.Mercaderia.UnidadMedidaPeso.CodUniMedPeso
            End If
            '--------------------------------------------------------------------------------------
            cbApliNucleo.Checked = toBoolean(registro.ApliNucleo)
            '------------------ Agregado el 12/06/2014 (Cesar) --------------------
            txtDepNuc.Value = registro.DptoNucleo
            'Descuento = registro.Descuento     'Se regresa ya que ahora la caja de texto de dscto soporta 4 decimales 29/08/2014
            txtDscto.Value = registro.Descuento
            '--------------------------------------------------------------------------------------

            txtCodMar.Text = registro.Mercaderia.Marca.CodMar
            CodMar = registro.Mercaderia.Marca.CodMar

            Dim Marca As New MarcaService.MarcasProducto
            If oMarcaService.Buscar(Trim(txtCodMar.Text), Session.sCodEmp) Then
                Marca = oMarcaService.Obtener(Trim(txtCodMar.Text), Session.sCodEmp)
                txtCodMar.Text = Marca.CodMar
                txtMarca.Text = Marca.DesMar
                CodMar = Marca.CodMar
            End If

            txtPais.Text = registro.Mercaderia.Pais.DesPais
            txtCodPais.Text = registro.Mercaderia.Pais.CodPais
            CodPais = registro.Mercaderia.Pais.CodPais
            txtPartida.Text = registro.Mercaderia.Partida.ParPar
            txtCodPartida.Text = registro.Mercaderia.Partida.CodPar
            CodPar = registro.Mercaderia.Partida.CodPar
            txtDesPar.Text = registro.Mercaderia.Partida.DesPar
            txtObsMer.Text = registro.Mercaderia.ObsMer

            DisDomMer = registro.DisDomMer
            DisIntMer = registro.DisIntMer
            cbApliFle.Checked = toBoolean(registro.ApliFle)
            cbApliGes.Checked = toBoolean(registro.ApliGes)

            cbAnulado.Checked = toBoolean(registro.Anulado)
            IdDetPedidoImp = toNumber(registro.PedidoImpDet.IdDetPedidoImp)
            IdPedidoImp = toNumber(registro.PedidoImpDet.PedidoImp.IdPedidoImp)
            pedido = toNumber(registro.PedidoImpDet.IdDetPedidoImp)
            pedidodet = toNumber(registro.PedidoImpDet.PedidoImp.IdPedidoImp)
            IdLocacion = registro.Locacion.IdLocacion
            txtalmacen.Text = registro.Locacion.Almacen.DesAlm
            'txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion)) _
            '        & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion))
            If (llenarCombos() > 0) And registro.PedidoImpDet.IdDetPedidoImp <> 0 Then
                cmbPedidos.Value = registro.PedidoImpDet.IdDetPedidoImp
            Else
                cmbPedidos.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function llenarCombos() As Integer
        Try

            '======================================= UNIDAD MED PESO ===========================================
            dtCodUniMedPeso = oMercaderiaService.MostrarUniMedPeso.Tables(0)
            dtCodUniMedPeso.Rows.InsertAt(getRowTodos(dtCodUniMedPeso), 0)
            cmbUnidMedPeso.DataSource = dtCodUniMedPeso
            cmbUnidMedPeso.DropDownList.DataMember = dtCodUniMedPeso.Columns("Nombre").ToString
            cmbUnidMedPeso.DropDownList.DisplayMember = dtCodUniMedPeso.Columns("Nombre").ToString
            cmbUnidMedPeso.DropDownList.ValueMember = dtCodUniMedPeso.Columns("CodUniMedPes").ToString
            cmbUnidMedPeso.DropDownList.Columns(0).DataMember = dtCodUniMedPeso.Columns("CodUniMedPes").ToString
            cmbUnidMedPeso.DropDownList.Columns(1).DataMember = dtCodUniMedPeso.Columns("Nombre").ToString
            dtCodUniMedPeso = Nothing

            '======================================= PEDIDOS ================================================
            If (toBlank(txtCodMer.Text) <> "") Then
                dtPedidos = Nothing
                ' cmbPedidos.Text = ""
                cmbPedidos.Clear()
                cmbPedidos.DataSource = Nothing
                dtPedidos = oFacturaImportDetService.MostrarPedidoImport(toNull(txtCodMer.Text)).Tables(0)
                dtPedidos.Rows.InsertAt(getRowTodos(dtPedidos), 0)
                cmbPedidos.DataSource = dtPedidos
                cmbPedidos.DropDownList.DataMember = dtPedidos.Columns("NomPed").ToString
                cmbPedidos.DropDownList.DisplayMember = dtPedidos.Columns("NomPed").ToString
                cmbPedidos.DropDownList.ValueMember = dtPedidos.Columns("IdDetPedidoImp").ToString
                cmbPedidos.DropDownList.Columns(0).DataMember = dtPedidos.Columns("IdLocacion").ToString
                cmbPedidos.DropDownList.Columns(1).DataMember = dtPedidos.Columns("NomPed").ToString
                cmbPedidos.DropDownList.Columns(2).DataMember = dtPedidos.Columns("CanMer").ToString
                cmbPedidos.DropDownList.Columns(3).DataMember = dtPedidos.Columns("IdDetPedidoImp").ToString
                cmbPedidos.DropDownList.Columns(4).DataMember = dtPedidos.Columns("IdPedidoImp").ToString
                cmbPedidos.DropDownList.Columns(5).DataMember = dtPedidos.Columns("Pendiente").ToString
                Dim nro As Integer = 0
                nro = dtPedidos.Rows.Count
                'dtPedidos = Nothing
                Return nro
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

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

            Dim registro As New FacturaImportDetService.FacturaImportDet
            Dim facturaImport As New FacturaImportDetService.FacturaImport
            Dim mercaderia As New FacturaImportDetService.Mercaderia
            Dim pedidoImpDet As New FacturaImportDetService.PedidoImportDet
            Dim locacion As New FacturaImportDetService.Locacion
            Dim marca As New FacturaImportDetService.Marca
            Dim pais As New FacturaImportDetService.Pais
            Dim partida As New FacturaImportDetService.Partida
            Dim pedidoImp As New FacturaImportDetService.PedidoImport

            '-------------------------------------------- Agregado el 16/04/2013 -----------------------------------------------
            Dim UnidadMedidaPeso As New FacturaImportDetService.UnidadMedidaPeso
            '-------------------------------------------------------------------------------------------------------------------------------

            registro.IdDetFactura = toNumber(IdDetFactura)
            facturaImport.IdFactura = toNumber(IdFactura)
            registro.FacturaImport = facturaImport

            mercaderia.CodMer = toNull(txtCodMer.Text)
            registro.Item = IIf(toNumber(txtItem.Text) = 0, Nothing, toNumber(txtItem.Text))
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.DeaMer = toDouble(txtDeaMer.Text)
            mercaderia.DesMer1 = IIf(txtDesMer1.Text = "", "", txtDesMer1.Text) ' toNull(txtDesMer1.Text) '  
            mercaderia.DesMer2 = toNull(txtDesMer2.Text)
            marca.DesMar = toNull(txtMarca.Text)
            marca.CodMar = toNull(CodMar)
            mercaderia.Marca = marca

            '-------------------------------------------- Agregado el 16/04/2013 -----------------------------------------------
            mercaderia.PesMer = txtPesMer.Value
            UnidadMedidaPeso.CodUniMedPeso = IIf(cmbUnidMedPeso.SelectedIndex = 0, Nothing, cmbUnidMedPeso.Value)
            mercaderia.UnidadMedidaPeso = UnidadMedidaPeso
            '-------------------------------------------------------------------------------------------------------------------------------

            registro.ApliNucleo = cbApliNucleo.Checked
            '------------------ Agregado el 12/06/2014 (Cesar) --------------------
            registro.DptoNucleo = txtDepNuc.Value
            registro.Descuento = txtDscto.Value    'Se regresa ya que ahora la caja de texto de dscto soporta 4 decimales 29/08/2014
            'registro.Descuento = Descuento 
            '--------------------------------------------------------------------------------------

            mercaderia.Partida = partida
            mercaderia.ObsMer = toNull(txtObsMer.Text)

            partida.ParPar = toNull(txtPartida.Text)
            partida.CodPar = toNull(CodPar)
            partida.DesPar = toNull(txtDesPar.Text)
            pais.DesPais = toNull(txtPais.Text)
            pais.CodPais = toNull(CodPais)
            mercaderia.Pais = pais
            registro.Mercaderia = mercaderia

            registro.DisDomMer = toDouble(DisDomMer)
            registro.DisIntMer = toDouble(DisIntMer)
            registro.ApliFle = cbApliFle.Checked
            registro.ApliGes = cbApliGes.Checked

            registro.Anulado = cbAnulado.Checked
            'pedidoImpDet.IdDetPedidoImp = cmbPedidos.DropDownList.GetRow.Cells(2).Text
            If dtPedidos.Rows.Count = 0 Or cmbPedidos.Value = 0 Then
                pedidoImpDet.IdDetPedidoImp = Nothing
                pedidoImp.IdPedidoImp = Nothing
            Else
                pedidoImpDet.IdDetPedidoImp = pedido 'toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text)
                pedidoImp.IdPedidoImp = pedidodet 'toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text)
            End If
            'pedidoImp.IdPedidoImp = cmbPedidos.DropDownList.GetRow.Cells(3).Text
            pedidoImpDet.PedidoImp = pedidoImp
            registro.PedidoImpDet = pedidoImpDet
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
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
    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click
        calculateTotal()
        If toNumber(txtCanMer.Value) <= toNumber(txtCantidadPendiente.Text) Then
            txtCanMer.BackColor = Color.White
        Else
            txtCanMer.BackColor = Color.Red
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer1.Text = frm.descripcion
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.Text = frm.codigo

            Dim mercaderia As ProductoService.Producto  'MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
            'Obtenemos el valor del precio evaluado

            If oPrecioService.BuscarPrecioGeneralVigente(Session.sCodEmp, txtCodMer.Text) Then
                Dim Precio As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
                Precio = oPrecioService.ObtenerPrecioCodigoVigente(Session.sCodEmp, mercaderia.ListaPrecios.IdListaPre, txtCodMer.Text)
                mercaderia.DeaMer = Precio.PreLista
            Else
                mercaderia.DeaMer = 0.00
            End If


            'mercaderia.DeaMer = oFacturaImportDetService.ConsultarPrecioImp(txtCodMer.Text, precioEvaluado)

            txtDeaMer.Text = mercaderia.DeaMer
            txtDesMer1.Text = mercaderia.DesMer1
            txtDesMer2.Text = mercaderia.DesMer2
            'Descuento = IIf(precioEvaluado = 3, oFacturaImportDetService.ConsultarDescuentoImp(txtCodMer.Text), 0)      'Se regresa ya que ahora la caja de texto de dscto soporta 4 decimales 29/08/2014
            txtDscto.Text = IIf(precioEvaluado = 3, oFacturaImportDetService.ConsultarDescuentoImp(txtCodMer.Text), 0)
            '-------------------------------------------- Agregado el 16/04/2013 -----------------------------------------------
            txtPesMer.Value = mercaderia.PesMer
            If mercaderia.UnidadMedidaPeso.CodUniMedPeso = Nothing Then
                cmbUnidMedPeso.SelectedIndex = 0
            Else
                cmbUnidMedPeso.Value = mercaderia.UnidadMedidaPeso.CodUniMedPeso
            End If
            '--------------------------------------------------------------------------------------------------------------------------------

            CodMar = mercaderia.Marca.CodMar
            txtCodMar.Text = mercaderia.Marca.CodMar
            txtMarca.Text = mercaderia.Marca.DesMar
            CodPais = mercaderia.Pais.CodPais
            txtCodPais.Text = mercaderia.Pais.CodPais
            txtPais.Text = mercaderia.Pais.DesPais
            CodPar = mercaderia.Partida.CodPar
            txtCodPartida.Text = mercaderia.Partida.CodPar
            txtPartida.Text = mercaderia.Partida.ParPar
            txtDesPar.Text = mercaderia.Partida.DesPar
            'txtObsMer.Text = mercaderia.ObsMer
            'recalculamos el monto total del Detalle

            If llenarCombos() = 0 Then
                btnBuscarAlmacen.Enabled = True
                cmbPedidos.Enabled = False
                cmbPedidos.Value = 0
                txtCantidadPendiente.Text = 0
                'cmbPedidos.Clear()

            Else
                btnBuscarAlmacen.Enabled = True
                cmbPedidos.Enabled = True
                cmbPedidos.Value = 0
                'cmbPedidos.Clear()
                'llenarCombos()
                'cmbPedidos_ValueChanged( sender ,e)
            End If
            'txtalmacen.Text = "LIMA - REPUESTOS" 'IIf(llenarCombos() > 0, Nothing, "LIMA - REPUESTOS")
            'IdLocacion = 1 'IIf(llenarCombos() > 0, Nothing, 1)
            'txtalmacen.Text = ""
            'IdLocacion = Nothing
            calculateTotal()
            activar()
            txtCodMer.Select()

        End If
    End Sub

    'Private Sub cmbPedidos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPedidos.ValueChanged
    '    Try
    '        If Modifi <> False Then
    '            If cmbPedidos.Value = 0 Then
    '                IdLocacion = 0                    
    '            Else
    '                IdLocacion = cmbPedidos.DropDownList.GetRow.Cells(0).Text
    '            End If                
    '        End If
    '            If cmbPedidos.Value = 0 Then
    '            txtalmacen.Text = ""
    '            Else
    '                txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IIf(Modifi = False, IdLocacion, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text)))) _
    '                 & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IIf(Modifi = False, IdLocacion, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text))))
    '                pedido = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text) = 0, pedido, toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text))
    '                pedidodet = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text) = 0, pedidodet, toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text))
    '                txtCantidadPendiente.Text = toNumber(cmbPedidos.DropDownList.GetRow.Cells(5).Text)
    '            End If

    '            If cmbPedidos.Value = 0 Then
    '                btnBuscarAlmacen.Enabled = True
    '            Else
    '                btnBuscarAlmacen.Enabled = False
    '            End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try

    'End Sub

    Private Sub cmbPedidos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPedidos.ValueChanged
        Try
            If Modifi <> False Then
                If cmbPedidos.Value <> 0 Then
                    IdLocacion = cmbPedidos.DropDownList.GetRow.Cells(0).Text
                End If
            End If
            If cmbPedidos.Value = 0 Then
                'txtalmacen.Text = ""
            Else               
                'txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion)) _
                '& " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion))
                txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IIf(Modifi = False, IdLocacion, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text)))) _
                 & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IIf(Modifi = False, IdLocacion, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text))))
                pedido = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text) = 0, pedido, toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text))
                pedidodet = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text) = 0, pedidodet, toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text))
                txtCantidadPendiente.Text = toNumber(cmbPedidos.DropDownList.GetRow.Cells(5).Text)
            End If

            If cmbPedidos.Value = 0 Then
                btnBuscarAlmacen.Enabled = True
            Else
                btnBuscarAlmacen.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    'Private Sub cmbPedidos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPedidos.ValueChanged
    '    If Modifi <> False Then
    '        IdLocacion = IIf(cmbPedidos.Value = 0, 1, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text))
    '    End If
    '    If cmbPedidos.Value = 0 Then
    '        txtalmacen.Text = "LIMA - REPUESTOS"
    '    Else
    '        txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IIf(Modifi = False, IdLocacion, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text)))) _
    '         & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IIf(Modifi = False, IdLocacion, toNull(cmbPedidos.DropDownList.GetRow.Cells(0).Text))))
    '    End If
    '    pedido = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text) = 0, pedido, toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text))
    '    pedidodet = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text) = 0, pedidodet, toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text))
    '    txtCantidadPendiente.Text = toNumber(cmbPedidos.DropDownList.GetRow.Cells(5).Text)
    '    If cmbPedidos.Value = 0 Then
    '        btnBuscarAlmacen.Enabled = True
    '    Else
    '        btnBuscarAlmacen.Enabled = False
    '    End If
    'End Sub
    Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
        Dim frm As New frmBuscarAlmacen
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtalmacen.Text = frm.descripcion
            txtalmacen.BackColor = System.Drawing.SystemColors.Control
            IdLocacion = frm.codigo
            txtalmacen.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion)) _
                    & " - " & oMaestroService.MostrarDato("SIGECOM.Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion))
        End If
        txtalmacen.Select()
    End Sub
    Private Sub btnBuscarMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            CodMar = frm.codigo
            txtCodMar.Text = CodMar
        End If
        txtCodMar.Select()
    End Sub
    Private Sub btnBuscarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPais.Click
        Dim frm As New frmBuscarPais
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtPais.Text = frm.descripcion
            txtPais.BackColor = System.Drawing.SystemColors.Control
            CodPais = frm.codigo
            txtCodPais.Text = CodPais
        End If
        txtCodPais.Select()
    End Sub
    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        Dim frm As New frmBuscarPartida
        frm.txtCodPar.Text = toBlank(CodPar)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtPartida.Text = frm.descripcion
            txtPartida.BackColor = System.Drawing.SystemColors.Control
            CodPar = frm.codigo
            txtCodPartida.Text = CodPar
        End If
        txtCodPartida.Select()
    End Sub
    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then
                If btnBuscarMercaderia.Enabled = True Then
                    If CodMer <> txtCodMer.Text Then
                        Modificable = True
                    Else
                        Modificable = False
                    End If

                    If state_button = False Then
                        If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
                            ValidarCodMer()
                        Else
                            txtObsMer.Text = ""
                            txtDesMer1.Text = ""
                            txtDeaMer.Text = 0.0
                            txtMarca.Text = ""
                            txtDesMer2.Text = ""

                            '--------------- Agregado el 16/04/2013 ---------------
                            txtPesMer.Value = 0
                            cmbUnidMedPeso.SelectedIndex = 0
                            '-------------------------------------------------------------------

                            txtPais.Text = ""
                            txtPartida.Text = ""
                            txtDesPar.Text = ""
                            txtCodMar.Text = ""
                            txtCodPais.Text = ""
                            txtCodPartida.Text = ""
                            txtTotal.Text = 0.0
                            activar()
                            cmbPedidos.Value = 0
                            cmbPedidos.Clear()
                            cmbPedidos.DataSource = Nothing
                            'txtalmacen.Text = "LIMA - REPUESTOS" 'IIf(llenarCombos() > 0, Nothing, "LIMA - REPUESTOS")
                            'IdLocacion = 1
                            'txtCodMer.Select()
                        End If
                    Else
                        If Modificable = True Then
                            If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
                                ValidarCodMer()
                            Else
                                txtObsMer.Text = ""
                                txtDesMer1.Text = ""
                                txtDeaMer.Text = 0.0
                                txtMarca.Text = ""
                                txtDesMer2.Text = ""

                                '--------------- Agregado el 16/04/2013 ---------------
                                txtPesMer.Value = 0
                                cmbUnidMedPeso.SelectedIndex = 0
                                '-------------------------------------------------------------------

                                txtPais.Text = ""
                                txtPartida.Text = ""
                                txtDesPar.Text = ""
                                txtCodMar.Text = ""
                                txtCodPais.Text = ""
                                txtCodPartida.Text = ""
                                txtTotal.Text = 0.0
                                activar()
                                cmbPedidos.Value = 0
                                cmbPedidos.Clear()
                                cmbPedidos.DataSource = Nothing
                                'txtalmacen.Text = "LIMA - REPUESTOS" 'IIf(llenarCombos() > 0, Nothing, "LIMA - REPUESTOS")
                                'IdLocacion = 1
                                'txtCodMer.Select()
                            End If
                        Else

                        End If
                    End If

                    'If oMercaderiaService.Buscar(txtCodMer.Text) Then
                    '    If state_button = False Then
                    '        Dim Mercaderia As New MercaderiaService.Mercaderia
                    '        Mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)
                    '        Mercaderia.DeaMer = oFacturaImportDetService.ConsultarPrecioImp(txtCodMer.Text, precioEvaluado)
                    '        txtDeaMer.Text = Mercaderia.DeaMer
                    '        txtDesMer1.Text = Mercaderia.DesMer1
                    '        txtDesMer2.Text = Mercaderia.DesMer2
                    '        CodMar = Mercaderia.Marca.CodMar
                    '        txtCodMar.Text = Mercaderia.Marca.CodMar
                    '        txtMarca.Text = Mercaderia.Marca.DesMar
                    '        txtDeaMer.Text = Mercaderia.DeaMer
                    '        CodPais = Mercaderia.Pais.CodPais
                    '        txtCodPais.Text = Mercaderia.Pais.CodPais
                    '        txtPais.Text = Mercaderia.Pais.DesPais
                    '        CodPar = Mercaderia.Partida.CodPar
                    '        txtCodPartida.Text = Mercaderia.Partida.CodPar
                    '        txtPartida.Text = Mercaderia.Partida.ParPar
                    '        txtDesPar.Text = Mercaderia.Partida.DesPar
                    '        'txtObsMer.Text = Mercaderia.ObsMer
                    '        'recalculamos el monto total del Detalle
                    '        activar()
                    '        If llenarCombos() = 0 Then
                    '            btnBuscarAlmacen.Enabled = True
                    '            cmbPedidos.Enabled = False
                    '            txtCantidadPendiente.Text = 0
                    '            cmbPedidos.Clear()

                    '        Else
                    '            btnBuscarAlmacen.Enabled = True
                    '            cmbPedidos.Enabled = True
                    '            cmbPedidos.Value = 0
                    '            cmbPedidos.Clear()
                    '            'llenarCombos()
                    '            'cmbPedidos_ValueChanged( sender ,e)
                    '        End If

                    '        txtalmacen.Text = "LIMA - REPUESTOS" 'IIf(llenarCombos() > 0, Nothing, "LIMA - REPUESTOS")
                    '        IdLocacion = 1 'IIf(llenarCombos() > 0, Nothing, 1)
                    '        calculateTotal()
                    '    End If
                    'Else
                    '    'MsgBox("No existe el codigo de mercaderia, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                    '    txtDesMer1.Text = ""
                    '    txtDeaMer.Text = 0.0
                    '    'txtCodMer.Text = ""
                    '    txtMarca.Text = ""
                    '    txtDesMer2.Text = ""
                    '    txtPais.Text = ""
                    '    txtPartida.Text = ""
                    '    txtDesPar.Text = ""
                    '    txtCodMar.Text = ""
                    '    txtCodPais.Text = ""
                    '    txtCodPartida.Text = ""
                    '    txtTotal.Text = 0.0
                    '    activar()
                    '    'txtCodMer.Select()
                    'End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub txtCodMar_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMar.Validating
        Try
            If Len(Trim(txtCodMar.Text)) > 0 Then
                Dim Marca As New MarcaService.MarcasProducto
                Marca.CodMar = txtCodMar.Text
                If oMarcaService.Buscar(Trim(txtCodMar.Text), Session.sCodEmp) Then
                    Marca = oMarcaService.Obtener(Trim(txtCodMar.Text), Session.sCodEmp)
                    txtCodMar.Text = Marca.CodMar
                    txtMarca.Text = Marca.DesMar
                    CodMar = Marca.CodMar
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCodMar.Select()
                End If
            Else
                txtMarca.Text = ""
                CodMar = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub txtCodPais_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodPais.Validating
        Try
            If Len(Trim(txtCodPais.Text)) > 0 Then
                Dim DesPais As String
                DesPais = oMaestroService.MostrarDato("Maestro.Paises", "DesPais", "CodPais", Trim(txtCodPais.Text))
                CodPais = oMaestroService.MostrarDato("Maestro.Paises", "CodPais", "CodPais", Trim(txtCodPais.Text))
                If DesPais <> "" Then
                    txtPais.Text = DesPais
                    txtCodPais.Text = CodPais
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCodPais.Select()
                End If
            Else
                txtPais.Text = ""
                CodPais = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    'se comento porque se debe de ingresar de todas maneras la descripcion numero 1 

    'Private Sub txtDesMer1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesMer1.TextChanged
    '    If txtDesMer1.Text <> "" Then
    '        txtObsMer.Enabled = False
    '        txtObsMer.Clear()
    '    Else
    '        txtObsMer.Enabled = True
    '    End If
    'End Sub

    Private Sub txtCodPartida_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodPartida.Validating
        Try
            If Len(Trim(txtCodPartida.Text)) > 0 Then
                Dim Partida As New PartidaService.Partida
                Partida.CodPar = Trim(txtCodPartida.Text)
                If oPartidaService.Buscar(Partida) Then
                    Partida = oPartidaService.MostrarPorCodigo(Trim(txtCodPartida.Text))
                    txtCodPartida.Text = Partida.CodPar
                    txtPartida.Text = Partida.ParPar
                    txtDesPar.Text = Partida.DesPar
                    CodPar = Partida.CodPar
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCodPartida.Select()
                End If
            Else
                txtPartida.Text = ""
                CodPar = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Mostrar")
        End Try
    End Sub

    Private Sub txtDeaMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDeaMer.Validating
        calculateTotal()
    End Sub
    Private Sub txtDscto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDscto.Validating
        calculateTotal()
    End Sub

    Private Sub ValidarCodMer()
        Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
        Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)


        If oPrecioService.BuscarPrecioGeneralVigente(Session.sCodEmp, txtCodMer.Text) Then
            Dim Precio As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
            Precio = oPrecioService.ObtenerPrecioCodigoVigente(Session.sCodEmp, Mercaderia.ListaPrecios.IdListaPre, txtCodMer.Text)
            Mercaderia.DeaMer = Precio.PreLista
            txtDeaMer.Text = Mercaderia.DeaMer
        Else
            Mercaderia.DeaMer = 0.00
            txtDeaMer.Text = Mercaderia.DeaMer
        End If


        'Mercaderia.DeaMer = oFacturaImportDetService.ConsultarPrecioImp(txtCodMer.Text, precioEvaluado)
        'txtDeaMer.Text = Mercaderia.DeaMer
        txtDesMer1.Text = Mercaderia.DesMer1
        txtDesMer2.Text = Mercaderia.DesMer2
        'Descuento = IIf(precioEvaluado = 3, oFacturaImportDetService.ConsultarDescuentoImp(txtCodMer.Text), 0)      'Se regresa ya que ahora la caja de texto de dscto soporta 4 decimales 29/08/2014
        txtDscto.Text = IIf(precioEvaluado = 3, oFacturaImportDetService.ConsultarDescuentoImp(txtCodMer.Text), 0)

        '----------------------------------- Agregado el 16/04/2013 ----------------------------------
        txtPesMer.Value = Mercaderia.PesMer
        If Mercaderia.UnidadMedidaPeso.CodUniMedPeso = Nothing Then
            cmbUnidMedPeso.SelectedIndex = 0
        Else
            cmbUnidMedPeso.Value = Mercaderia.UnidadMedidaPeso.CodUniMedPeso
        End If
        '---------------------------------------------------------------------------------------------------------

        CodMar = Mercaderia.Marca.CodMar
        txtCodMar.Text = Mercaderia.Marca.CodMar
        txtMarca.Text = Mercaderia.Marca.DesMar
        txtDeaMer.Text = Mercaderia.DeaMer
        CodPais = Mercaderia.Pais.CodPais
        txtCodPais.Text = Mercaderia.Pais.CodPais
        txtPais.Text = Mercaderia.Pais.DesPais
        CodPar = Mercaderia.Partida.CodPar
        txtCodPartida.Text = Mercaderia.Partida.CodPar
        txtPartida.Text = Mercaderia.Partida.ParPar
        txtDesPar.Text = Mercaderia.Partida.DesPar
        'txtObsMer.Text = Mercaderia.ObsMer
        'recalculamos el monto total del Detalle
        activar()
        If llenarCombos() = 0 Then
            btnBuscarAlmacen.Enabled = True
            cmbPedidos.Enabled = False
            txtCantidadPendiente.Text = 0
            cmbPedidos.Clear()
        Else
            btnBuscarAlmacen.Enabled = True
            cmbPedidos.Enabled = True
            cmbPedidos.Value = 0
            cmbPedidos.Clear()
            'llenarCombos()
            'cmbPedidos_ValueChanged( sender ,e)
        End If

        'txtalmacen.Text = "LIMA - REPUESTOS" 'IIf(llenarCombos() > 0, Nothing, "LIMA - REPUESTOS")
        'IdLocacion = 1 'IIf(llenarCombos() > 0, Nothing, 1)
        calculateTotal()

    End Sub

    Private Sub cbApliNucleo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbApliNucleo.CheckedChanged
        If cbApliNucleo.Checked = True Then
            txtDepNuc.ReadOnly = False
            txtDepNuc.BackColor = System.Drawing.SystemColors.Window
        Else
            txtDepNuc.ReadOnly = True
            txtDepNuc.BackColor = System.Drawing.SystemColors.Control
            txtDepNuc.Value = 0.0
        End If
    End Sub
End Class
