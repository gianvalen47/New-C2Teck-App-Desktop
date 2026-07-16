Imports System.Windows.Forms

Public Class frmAlmacen_FacturaImportacion_AgregarDetalle

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oImportacionDetService As New ImportacionDetService.ImportacionDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaImportDetService As New FacturaImportDetService.FacturaImportDetServiceClient
    Private dtDatos As DataTable
    Private dtPedidos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdDetImportacion As Integer
    Public IdImportacion As Integer
    Public estado_pedido As String
    'Public IdDetPedidoImp As Integer
    Private DetPedido As Integer
    Private Pedido As Integer

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtDescripcion.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtCanFac.KeyPress _
                          , txtCanMer.KeyPress _
                          , txtPreMer.KeyPress _
                          , txtItem.KeyPress _
                          , cmbPedidos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        'If state_button Then    'Modificar
        '    ObtenerRegistro()
        'Else                    'Nuevo
        '    txtCodMer.ReadOnly = False
        '    txtCodMer.Select()
        'End If
        'If (estado_pedido = "GENERADO" Or estado_pedido = "GN" Or state_button = False) Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        'End If
        'If oMaestroService.MostrarDato("SIGECOM.Almacen.Importaciones", "IdFactura", "IdImportacion", IdImportacion) <> Nothing Then
        '    btnGuardar.Enabled = False
        'Else
        '    btnGuardar.Enabled = True
        'End If
        If state_button Then
            ObtenerRegistro()
            If estado_pedido = "GENERADO" Or estado_pedido = "GN" Or state_button = False Then
                If oMaestroService.MostrarDato("SIGECOM.Almacen.Importaciones", "IdFactura", "IdImportacion", IdImportacion) <> Nothing Then
                    btnGuardar.Enabled = False
                    desactivar()
                Else
                    txtCodMer.ReadOnly = False
                    txtCodMer.BackColor = System.Drawing.SystemColors.Window
                    btnBuscarMercaderia.Enabled = True
                    btnGuardar.Enabled = True
                End If
            Else
                btnGuardar.Enabled = False
                desactivar()
            End If
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oImportacionDetService) = False Then
                oImportacionDetService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                 txtCodMer.KeyUp _
                              , txtCanFac.KeyUp
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
            If campo.Text.Trim.Length > 0 Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtItem.Value) <= 0 Then
                MsgBox("Ingrese el Nº de Item.", MsgBoxStyle.Information, "Información")
                txtItem.BackColor = Color.Red
                txtItem.Focus()
                Return False
            ElseIf toNumber(txtCanFac.Value) <= 0 Then
                MsgBox("La cantidad de la factura. ", MsgBoxStyle.Information, "Información")
                txtCanFac.BackColor = Color.Red
                txtCanFac.Focus()
                Return False
            ElseIf toNumber(txtCanMer.Value) < 0 Then
                MsgBox("La cantidad recibida. ", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
            ElseIf toDouble(txtPreMer.Text) <= 0 Then
                MsgBox("El precio debe ser mayor que CERO. ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf oImportacionDetService.Buscar(IdImportacion, txtItem.Value) And state_button = False Then
                MsgBox("El número de Item " & txtItem.Value & " ya existe en esta factura. ", MsgBoxStyle.Information, "Información")
                txtItem.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As ImportacionDetService.ImportacionDet)
        Try
            Dim estado_process As Integer
            estado_process = oImportacionDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdDetImportacion = estado_process
                'IdDetPedidoImp = cmbPedidos.Value
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ImportacionDetService.ImportacionDet)
        Try
            Dim estado_process As Boolean
            estado_process = oImportacionDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub desactivar()
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtCanFac.ReadOnly = True
        txtCanFac.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtPreMer.ReadOnly = True
        txtPreMer.BackColor = System.Drawing.SystemColors.Control
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        btnBuscarMercaderia.Enabled = False
        txtCanMer.ReadOnly = True
        txtCanMer.BackColor = System.Drawing.SystemColors.Control
        txtItem.ReadOnly = True
        txtItem.BackColor = System.Drawing.SystemColors.Control
        cmbPedidos.ReadOnly = True
        cmbPedidos.BackColor = System.Drawing.SystemColors.Control
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As ImportacionDetService.ImportacionDet
            registro = oImportacionDetService.MostrarPorId(IdDetImportacion)

            IdDetImportacion = registro.IdDetImportacion
            IdImportacion = registro.Importacion.IdImportacion
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDescripcion.Text = registro.Mercaderia.DesMer1
            txtCanFac.Text = registro.CanFac
            txtCanMer.Text = registro.CanMer
            txtItem.Text = registro.Item
            txtPreMer.Text = registro.PreMer
            DetPedido = registro.FacturaImportDet.PedidoImpDet.IdDetPedidoImp
            Pedido = registro.FacturaImportDet.PedidoImpDet.PedidoImp.IdPedidoImp

            If (llenarCombos() > 0) And registro.FacturaImportDet.PedidoImpDet.IdDetPedidoImp <> 0 Then
                cmbPedidos.Value = registro.FacturaImportDet.PedidoImpDet.IdDetPedidoImp
            End If

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function llenarCombos() As Integer
        Try
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
                cmbPedidos.SelectedIndex = 0
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
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New ImportacionDetService.ImportacionDet
            Dim importacion As New ImportacionDetService.Importacion
            Dim mercaderia As New ImportacionDetService.Mercaderia
            Dim pedidoImp As New ImportacionDetService.PedidoImport
            Dim pedidoImpDet As New ImportacionDetService.PedidoImportDet
            Dim factura As New ImportacionDetService.FacturaImportDet

            registro.IdDetImportacion = IdDetImportacion
            importacion.IdImportacion = IdImportacion
            registro.Importacion = importacion
            mercaderia.CodMer = txtCodMer.Text
            registro.Mercaderia = mercaderia
            registro.CanFac = txtCanFac.Text
            registro.CanMer = txtCanMer.Text
            registro.Item = txtItem.Value
            registro.PreMer = txtPreMer.Text

            If cmbPedidos.Value = 0 Then
                pedidoImp.IdPedidoImp = Nothing
                pedidoImpDet.IdDetPedidoImp = Nothing
            Else
                pedidoImp.IdPedidoImp = Pedido
                pedidoImpDet.IdDetPedidoImp = DetPedido
            End If
            pedidoImpDet.PedidoImp = pedidoImp
            factura.PedidoImpDet = pedidoImpDet
            registro.FacturaImportDet = factura
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
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtDescripcion.Text = frm.descripcion
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.Text = frm.codigo
            txtPreMer.Text = frm.precio
        End If
        txtCodMer.Select()
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 And state_button = False Then
                Dim ObjMerca As New MercaderiaService.MercaderiaServiceClient
                If ObjMerca.Buscar(txtCodMer.Text) Then
                    Dim Mercaderia As New MercaderiaService.Mercaderia
                    Mercaderia = ObjMerca.MostrarPorCodigo(txtCodMer.Text)
                    ' txtCodMer.Text = LocacionMercaderia.Mercaderia.CodMer
                    txtCodMer.ReadOnly = True
                    txtCodMer.BackColor = System.Drawing.SystemColors.Window
                    txtDescripcion.Text = Mercaderia.DesMer1
                    txtPreMer.Text = Mercaderia.DeaMer
                    If llenarCombos() = 0 Then
                        cmbPedidos.Enabled = False
                        cmbPedidos.Clear()
                    Else
                        cmbPedidos.Enabled = True
                        cmbPedidos.Value = 0
                        cmbPedidos.Clear()
                        ''llenarCombos()
                        ''cmbPedidos_ValueChanged( sender ,e)
                    End If
                Else
                    MsgBox("No existe el codigo ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                    txtCodMer.Clear()
                    txtCodMer.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbPedidos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPedidos.ValueChanged
        DetPedido = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text) = 0, DetPedido, toNumber(cmbPedidos.DropDownList.GetRow.Cells(3).Text))
        Pedido = IIf(toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text) = 0, Pedido, toNumber(cmbPedidos.DropDownList.GetRow.Cells(4).Text))
    End Sub

    Private Sub txtCanFac_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCanFac.Validating
        If txtCanMer.ReadOnly = False Then
            txtCanMer.Value = txtCanFac.Value
        End If
    End Sub
End Class
