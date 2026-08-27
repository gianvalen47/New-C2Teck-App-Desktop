Imports System.Windows.Forms

Public Class frmAgregarDetalle_PedidoImportacion

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdDetPedidoImp As String
    Public IdPedidoImp As String
    Public estado_pedido As String
    Public IdLocacion As String
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtCanStock.KeyPress _
                          , txtDescripcion.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtDestino.KeyPress _
                          , txtCanMer.KeyPress _
                          , txtPreMer.KeyPress _
                          , txtObservacion.KeyPress
        ', txtTotal.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmAgregarDetalle_PedidoImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            txtCodMer.ReadOnly = True
            txtCodMer.TabStop = False
            btnBuscarMercaderia.Enabled = False
            ObtenerRegistro()
        Else                    'Nuevo
            'txtCodMer.ReadOnly = True
            txtCodMer.TabStop = False
            txtCodMer.Select()

        End If
        If estado_pedido = "GENERADO" Or estado_pedido = "GN" Or state_button = False Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oPedidoImportDetService) = False Then
                oPedidoImportDetService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()

            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                 txtCodMer.KeyUp _
                              , txtCanMer.KeyUp
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
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCanStock.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Function calculateTotal() As Double
        txtTotal.Text = toNumber(txtCanMer.Value) * toDouble(txtPreMer.Text)
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New PedidoImportDetService.PedidoImportDet
            Dim mercaderia As New PedidoImportDetService.Mercaderia
            Dim pedidoimp As New PedidoImportDetService.PedidoImport

            mercaderia.CodMer = toNull(txtCodMer.Text)
            registro.Mercaderia = mercaderia
            pedidoimp.IdPedidoImp = toNumber(IdPedidoImp)
            registro.PedidoImp = pedidoimp
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
            ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                MsgBox("Debe Ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf state_button = False And oPedidoImportDetService.Buscar(registro) = True Then
                MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Text = ""
                txtCodMer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As PedidoImportDetService.PedidoImportDet)
        Try
            Dim estado_process As Integer
            estado_process = oPedidoImportDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdDetPedidoImp = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As PedidoImportDetService.PedidoImportDet)
        Try
            Dim estado_process As Boolean
            estado_process = oPedidoImportDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As PedidoImportDetService.PedidoImportDet
            registro = oPedidoImportDetService.MostrarPorId(toNumber(IdDetPedidoImp))

            IdDetPedidoImp = registro.IdDetPedidoImp
            IdPedidoImp = registro.PedidoImp.IdPedidoImp
            txtItem.Value = registro.Item
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtCanMer.Text = registro.CanMer
            txtCanStock.Text = registro.CanStock
            txtPreMer.Text = registro.PreMer
            txtTotal.Text = registro.PreMer * registro.CanMer
            txtDestino.Text = registro.Destino
            txtObservacion.Text = registro.Observacion

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

            Dim registro As New PedidoImportDetService.PedidoImportDet
            Dim pedidoImp As New PedidoImportDetService.PedidoImport
            Dim mercaderia As New PedidoImportDetService.Mercaderia

            registro.IdDetPedidoImp = toNumber(IdDetPedidoImp)
            pedidoImp.IdPedidoImp = toNumber(IdPedidoImp)
            registro.PedidoImp = pedidoImp
            registro.Item = txtItem.Value
            mercaderia.CodMer = toNull(txtCodMer.Text)
            registro.Mercaderia = mercaderia
            registro.CanMer = toNull(txtCanMer.Text)
            registro.CanStock = toNumber(txtCanStock.Text)
            registro.PreMer = toNull(txtPreMer.Text)
            registro.Destino = toNull(txtDestino.Text)
            registro.Observacion = toNull(txtObservacion.Text)
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
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDescripcion.Text = frm.descripcion
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.Text = frm.codigo
            txtPreMer.Text = frm.precio
            calculateTotal()
        End If
        txtCodMer.Select()

    End Sub

    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click
        calculateTotal()
    End Sub
    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then

                If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
                    Dim Mercaderia As New ProductoService.Producto
                    Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                    txtCodMer.Text = Mercaderia.CodMer
                    txtDescripcion.Text = Mercaderia.DesMer1
                    txtPreMer.Text = Mercaderia.DeaMer
                    calculateTotal()
                Else
                    txtDescripcion.Text = ""
                    txtPreMer.Text = 0.0

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class
