Imports System.Windows.Forms

Public Class frmNotaCredito_AgregarDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oNotaCreditoDetService As New NotaCreditoDetService.NotaCreditoDetServiceClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdNotaDet As Integer
    Public IdNota As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Public CodMot As String     '----------(04/07/2012) Agregado para validar que cuando sea motivo Transferencia Gratuita ('2') el precio debe de ser el Costo (SOLO PARA ESTE MOTIVO) y no el precio de venta 

    Private dtModelos As DataTable

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
 _
                          , txtCodMer.KeyPress _
                          , txtStock.KeyPress _
                          , txtDscMer.KeyPress, txtDesMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmNotaCredito_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            btnBuscarMercaderia.Enabled = True
            txtItem.Value = oNotaCreditoDetService.SugerirItem(IdNota)
            cbNoCore.Checked = False
            txtCodMer.Select()
        End If
        If estado = "GENERADO" Or estado = "GN" Or state_button = False Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()

        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oNotaCreditoDetService) = False Then
                oNotaCreditoDetService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If
            If isClosed(oNotaCreditoService) = False Then
                oNotaCreditoService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtPreMer.KeyUp _
                          , txtCanMer.KeyUp _
 _
                          , txtCodMer.KeyUp _
                          , txtStock.KeyUp _
                          , txtDscMer.KeyUp, txtDesMer.KeyUp
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
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdNota) = 0 Then
                MsgBox("Debe Ingresar el código de la Nota. ", MsgBoxStyle.Information, "Información")
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
                'ElseIf state_button = False And toNumber(txtStock.Text) <= 0 Then
                '    MsgBox("No hay STOCK para esta merdadería. ", MsgBoxStyle.Information, "Información")
                '    Return False
                'ElseIf toNumber(txtCanMer.Value) > toNumber(txtStock.Text) Then
                '    MsgBox("Cantida no pueder ser mayor que Stock. ", MsgBoxStyle.Information, "Información")
                '    Return False
            ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                MsgBox("Debe Ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf state_button = False And oNotaCreditoDetService.Buscar(IdNota, toBlank(txtCodMer.Text)) And Microsoft.VisualBasic.Left(txtCodMer.Text, 3) <> "AAA" Then
                MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Text = ""
                txtCodMer.Focus()
                Return False
            ElseIf state_button = True And oNotaCreditoService.Estado(IdNota) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As NotaCreditoDetService.NotaCreditoDet)
        Try
            Dim estado_process As Integer
            estado_process = oNotaCreditoDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdNotaDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As NotaCreditoDetService.NotaCreditoDet)
        Try
            Dim estado_process As Boolean
            estado_process = oNotaCreditoDetService.Actualizar(registro)
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
            Dim registro As NotaCreditoDetService.NotaCreditoDet
            registro = oNotaCreditoDetService.MostrarPorId(toNumber(IdNotaDet))

            IdNotaDet = registro.IdNotaDet
            IdNota = registro.NotaCredito.IdNota
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtCanMer.Text = registro.CanMer
            txtPreMer.Text = registro.PreMer
            txtDscMer.Text = registro.DscMer
            txtTotal.Text = registro.TotalFila
            txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
            txtItem.Value = registro.Item
            cbNoCore.Checked = registro.NoCore

            estado = oNotaCreditoService.Estado(IdNota)
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

            Dim registro As New NotaCreditoDetService.NotaCreditoDet
            Dim notaCredito As New NotaCreditoDetService.NotaCredito
            Dim mercaderia As New NotaCreditoDetService.Mercaderia

            registro.IdNotaDet = IIf(toNumber(IdNotaDet) = 0, Nothing, IdNotaDet)
            notaCredito.IdNota = IIf(toNumber(IdNota) = 0, Nothing, IdNota)
            registro.NotaCredito = notaCredito
            mercaderia.CodMer = toNull(txtCodMer.Text)
            mercaderia.DesMer1 = toNull(txtDesMer.Text)
            registro.Mercaderia = mercaderia
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.PreMer = toDouble(txtPreMer.Text)
            registro.DscMer = toDouble(txtDscMer.Text)
            registro.NoCore = cbNoCore.Checked
            registro.Item = txtItem.Value


            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = IdLocacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            Dim LocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderia
            LocacionMercaderia = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, frm.codigo)

            txtDesMer.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)

            'VERIFICAR SI EL MOTIVO ES TRANSFERENCIA GRATUITA , SI ES ASI ME DARA COMO RESULTADO EL COSTO---------
            If CodMot = "2" Then
                txtPreMer.Text = IIf(CodMon = "NS", LocacionMercaderia.CosSol, LocacionMercaderia.CosDol)
                txtDscMer.Text = 0
            Else
                txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
            End If

            txtCodMer.Select()
            calculateTotal()
        End If
    End Sub
    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click
        calculateTotal()
    End Sub

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
                        txtStock.Text = LocacionMercaderia.Stock

                        'VERIFICAR SI EL MOTIVO ES TRANSFERENCIA GRATUITA , SI ES ASI ME DARA COMO RESULTADO EL COSTO---------
                        If CodMot = "2" Then
                            txtPreMer.Text = IIf(CodMon = "NS", LocacionMercaderia.CosSol, LocacionMercaderia.CosDol)
                            txtDscMer.Text = 0
                        Else
                            txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                            txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                        End If
                        '-----------------------------------------------------------------------------------------------------
                        calculateTotal()
                    Else
                        MsgBox("No existe el código ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                        txtCodMer.Clear()
                        txtCodMer.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Mercaderia")
            End Try
        End If 
    End Sub
End Class
