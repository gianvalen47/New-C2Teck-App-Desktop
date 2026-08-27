Imports System.Windows.Forms

Public Class frmMemoTransferenciaInterna_AgregarDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMemoDetalleService As New MemoDetalleService.MemoDetalleServiceClient
    Private oMemoService As New MemoService.MemoServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdMemoDet As Integer
    Public IdMemo As Integer
    Public IdLocacion As Integer
    Public estado As String
    Public TipoMov As String
    Public Tipo As String



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
                            txtPreMer.KeyPress _
                          , txtTotal.KeyPress _
                          , txtCanMer.KeyPress _
                          , txtDesMer.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtStock.KeyPress _
                          , txtDscMer.KeyPress _
                          , rbIngreso.KeyPress _
                          , rbSalida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmMemoTransferenciaInterna_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        If state_button Then    'Modificar
            ObtenerRegistro()
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control

            Me.Text = "Modificar detalle " + txtCodMer.Text.ToString
        Else                    'Nuevo
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            If Tipo = "H" Then
                rbIngreso.Checked = True
            ElseIf Tipo = "D" Then
                rbSalida.Checked = True
            End If
            txtCodMer.Select()
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            Me.Text = "Agregar Detalle"
        End If
        If estado = "GENERADO" Or estado = "GN" Or state_button = False Then
            btnGuardar.Enabled = True
          
        Else
            btnGuardar.Enabled = False
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMemoDetalleService) = False Then
                oMemoDetalleService.Close()
            End If
            If isClosed(oMemoService) = False Then
                oMemoService.Close()
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
        txtTotal.Text = (toNumber(txtCanMer.Value) * toDouble(txtPreMer.Text)) - (toNumber(txtCanMer.Value) * toDouble(txtDscMer.Text))
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
            If toNumber(IdMemo) = 0 Then
                MsgBox("Debe Ingresar el código del Memo T.I. ", MsgBoxStyle.Information, "Información")
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
            ElseIf state_button = False And toNumber(txtStock.Text) <= 0 And rbSalida.Checked Then
                MsgBox("No hay STOCK para esta merdadería. ", MsgBoxStyle.Information, "Información")
                Return False
                ' esta validacion se hace en CarMer.validating
            ElseIf state_button = False And toNumber(txtCanMer.Value) > toNumber(txtStock.Text) And rbSalida.Checked Then
                MsgBox("Cantidad no pueder ser mayor que Stock. ", MsgBoxStyle.Information, "Información")
                txtCanMer.Focus()
                Return False
            ElseIf txtPreMer.Text = "" Then
                MsgBox("Debe ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
                'ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                '    MsgBox("Debe ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                '    txtPreMer.BackColor = Color.Red
                '    txtPreMer.Focus()
                '    Return False
                'ElseIf state_button = False And oMemoDetalleService.Buscar(IdMemo, toBlank(txtCodMer.Text)) Then
                '    MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                '    txtCodMer.Focus()
                '    Return False
            ElseIf state_button = True And oMemoService.Estado(IdMemo) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As MemoDetalleService.MemoDetalle)
        Try
            Dim estado_process As Integer
            estado_process = oMemoDetalleService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMemoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As MemoDetalleService.MemoDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oMemoDetalleService.Actualizar(registro)
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
            Dim registro As MemoDetalleService.MemoDetalle
            registro = oMemoDetalleService.MostrarPorId(toNumber(IdMemoDet))

            IdMemoDet = registro.IdMemoDet
            IdMemo = registro.Memo.IdMemo
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtCanMer.Text = registro.CanMer
            txtPreMer.Text = registro.PreMer
            txtDscMer.Text = registro.DscMer
            txtTotal.Text = registro.TotalFila
            If registro.TipMov = "H" Then
                rbIngreso.Checked = True
            ElseIf registro.TipMov = "D" Then
                rbSalida.Checked = True
            End If
            txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text)

            estado = oMemoService.Estado(IdMemo)
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
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

            Dim registro As New MemoDetalleService.MemoDetalle
            Dim memo As New MemoDetalleService.Memo
            Dim mercaderia As New MemoDetalleService.Mercaderia

            registro.IdMemoDet = IIf(toNumber(IdMemoDet) = 0, Nothing, IdMemoDet)
            memo.IdMemo = IdMemo
            registro.Memo = memo
            mercaderia.CodMer = toNull(txtCodMer.Text)
            registro.Mercaderia = mercaderia
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.PreMer = toDouble(txtPreMer.Text)
            registro.DscMer = toDouble(txtDscMer.Text)
            registro.TipMov = TipoMov
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
        Dim frm As New frmBuscarLocacionMercaderia
        frm.IdLocacion = IdLocacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtPreMer.Text = frm.precio
            txtDscMer.Text = frm.descuento
            txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text)
            calculateTotal()
        End If
        txtCodMer.Select()
    End Sub
    Private Sub txtCanMer_Validating(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Validating
        Try
            If state_button Then
                Dim registro As MemoDetalleService.MemoDetalle
                registro = oMemoDetalleService.MostrarPorId(toNumber(IdMemoDet))
                Dim CantStock As Integer
                CantStock = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text) + registro.CanMer
                If state_button And toNumber(txtCanMer.Value) > CantStock And TipoMov = "D" And Trim(txtCodMer.Text).Substring(0, 3) <> "AAA" Then
                    MsgBox("No hay stock para esta mercaderia")
                    txtCanMer.Value = registro.CanMer
                    txtCanMer.Select()
                End If
                'ElseIf toNumber(txtCanMer.Value) > toNumber(txtStock.Text) And TipoMov = "D" Then
                '    MsgBox("Cantidad no pueder ser mayor que Stock. ", MsgBoxStyle.Information, "Información")
                '    txtCanMer.Focus()
            End If
            calculateTotal()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub rbArmado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIngreso.CheckedChanged, rbSalida.CheckedChanged
        If rbIngreso.Checked Then
            TipoMov = "H"
        ElseIf rbSalida.Checked Then
            TipoMov = "D"
            
        End If
    End Sub
    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 And state_button = False Then

                If oLocacionMercaderiaService.Buscar(IdLocacion, txtCodMer.Text) Then
                    Dim LocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderia
                    LocacionMercaderia = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, txtCodMer.Text)
                    ' txtCodMer.Text = LocacionMercaderia.Mercaderia.CodMer
                    txtCodMer.ReadOnly = True
                    txtCodMer.BackColor = System.Drawing.SystemColors.Window
                    txtStock.Text = LocacionMercaderia.Stock
                    txtDesMer.Text = LocacionMercaderia.Mercaderia.DesMer1
                    txtPreMer.Text = LocacionMercaderia.Mercaderia.DeaMer
                    txtDscMer.Text = 0
                    calculateTotal()
                Else
                    MsgBox("No existe el codigo ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtPreMer_Validating(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreMer.Validating
        calculateTotal()
    End Sub

    Private Sub txtDscMer_Validating(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDscMer.Validating
        calculateTotal()
    End Sub
End Class
