Imports System.Windows.Forms

Public Class frmAgregarDetalle_Pedido

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oPedidoDetService As New PedidoDetService.PedidoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oPrecioService As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient   'PrecioService.PrecioServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdPedidoDet As String
    Public IdPedido As String
    Public estado_pedido As String

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarMercaderia_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtDesMer.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtCanPed.KeyPress _
                          , txtPreMer.KeyPress _
                          , txtDestino.KeyPress _
                          , txtObservacion.KeyPress _
                          , txtTotalFila.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            txtCodMer.ReadOnly = True
            txtCodMer.TabStop = False
            ObtenerRegistro()
        Else                    'Nuevo
            txtCodMer.TabStop = False
            txtCodMer.Select()
        End If

        If estado_pedido = "GENERADO" Or estado_pedido = "GN" Or state_button = False Then
            btnGuardar.Enabled = True
        ElseIf estado_pedido = "VISUALIZADO" Or estado_pedido = "VS" Then
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtDesMer.ReadOnly = True
            txtDesMer.BackColor = System.Drawing.SystemColors.Control
            txtCanPed.ReadOnly = True
            txtCanPed.BackColor = System.Drawing.SystemColors.Control
            txtPreMer.ReadOnly = True
            txtPreMer.BackColor = System.Drawing.SystemColors.Control
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oPedidoDetService) = False Then
                oPedidoDetService.Close()
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
                              , txtCanPed.KeyUp
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
        txtTotalFila.Text = toNumber(txtCanPed.Value) * toDouble(txtPreMer.Text)
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New PedidoDetService.PedidoDet
            Dim pedido As New PedidoDetService.Pedido
            pedido.IdPedido = toNumber(IdPedido)
            registro.Pedido = pedido
            registro.IdPedidoDet = toNumber(IdPedidoDet)
            registro.CodMer = toNull(txtCodMer.Text)
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(txtCanPed.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtCanPed.BackColor = Color.Red
                txtCanPed.Focus()
                Return False
            ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                MsgBox("Debe Ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf state_button = False And oPedidoDetService.Buscar(registro) = 1 Then
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
    Private Sub Insertar(ByVal registro As PedidoDetService.PedidoDet)
        Try
            Dim estado_process As Integer
            estado_process = oPedidoDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPedidoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As PedidoDetService.PedidoDet)
        Try
            Dim estado_process As Boolean
            estado_process = oPedidoDetService.Actualizar(registro)
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
    Private Sub ObtenerRegistro()
        Try
            Dim registro As PedidoDetService.PedidoDet
            registro = oPedidoDetService.MostrarPorId(toNumber(IdPedidoDet))

            IdPedidoDet = registro.IdPedidoDet
            IdPedido = registro.Pedido.IdPedido
            txtCodMer.Text = registro.CodMer
            txtDesMer.Text = registro.DesMer
            txtCanPed.Text = registro.CanPed
            txtPreMer.Text = registro.PreMer
            txtDestino.Text = registro.Destino
            txtObservacion.Text = registro.Observacion
            txtTotalFila.Text = registro.TotalFila

            'If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
            '    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
            '    Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)

            'If IsDBNull(Mercaderia.ListaPrecios.IdListaPre) Then
            'Else
            '    If Mercaderia.ListaPrecios.IdListaPre = 1 Or Mercaderia.ListaPrecios.IdListaPre = 2 Or Mercaderia.ListaPrecios.IdListaPre = 3 Or Mercaderia.ListaPrecios.IdListaPre = 4 Or Mercaderia.ListaPrecios.IdListaPre = 5 Or Mercaderia.ListaPrecios.IdListaPre = 6 Or Mercaderia.ListaPrecios.IdListaPre = 7 Then
            '        Dim registro2 As New PrecioService.PrecioFabrica
            '        registro2 = oPrecioService.ObtenerListaPrecioFabrica(Mercaderia.ListaPrecios.IdListaPre, txtCodMer.Text)
            '        txtMustBuy.Text = registro2.CanMer
            '    End If
            'End If
            'End If

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

            Dim registro As New PedidoDetService.PedidoDet
            Dim pedido As New PedidoDetService.Pedido

            registro.IdPedidoDet = IIf(toNumber(IdPedidoDet) = 0, Nothing, toNumber(IdPedidoDet))
            pedido.IdPedido = IIf(toNumber(IdPedido) = 0, Nothing, toNumber(IdPedido))
            registro.Pedido = pedido
            registro.CodMer = toNull(txtCodMer.Text)
            registro.DesMer = toNull(txtDesMer.Text)
            registro.CanPed = toNull(txtCanPed.Text)
            registro.PreMer = toNull(txtPreMer.Text)
            registro.Destino = toNull(txtDestino.Text)
            registro.Observacion = toNull(txtObservacion.Text)
            registro.TotalFila = toNull(txtTotalFila.Text)

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        frm.ConsultaFormulario = "pedidointerno"
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer.Text = frm.descripcion
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.Text = frm.codigo
            txtPreMer.Text = frm.precio
            calculateTotal()
        End If
        txtCodMer.Select()
    End Sub
    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanPed.Click
        calculateTotal()
    End Sub
    Private Sub txtPreMer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPreMer.KeyUp
        calculateTotal()
    End Sub
    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If state_button = False Then
            Try
                If Len(Trim(txtCodMer.Text)) > 0 Then


                    If oPrecioService.BuscarPrecioGeneralVigente(Session.sCodEmp, txtCodMer.Text) Then
                        Dim Precio As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
                        Dim idListaPre As Integer = oPrecioService.ObtenerIdListaPreGeneralVigente(Session.sCodEmp, txtCodMer.Text)
                        Precio = oPrecioService.ObtenerPrecioCodigoVigente(Session.sCodEmp, idListaPre, txtCodMer.Text)
                        txtDesMer.Text = Precio.DesMer
                        txtPreMer.Text = Precio.PreLista

                        'txtMustBuy.Text = registro.CanMer
                        'txtPreMer.Text = registro.DistInt + registro.PreCore
                    ElseIf oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
                        Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                        Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                        txtCodMer.Text = Mercaderia.CodMer
                        txtDesMer.Text = Mercaderia.DesMer1
                        txtPreMer.Text = Mercaderia.DeaMer
                    Else
                        txtDesMer.Text = ""
                        txtPreMer.Text = 0.0
                        txtMustBuy.Text = ""
                    End If

                    calculateTotal()
                Else
                    txtDesMer.Text = ""
                    txtPreMer.Text = 0.0
                    txtMustBuy.Text = ""
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub


End Class
