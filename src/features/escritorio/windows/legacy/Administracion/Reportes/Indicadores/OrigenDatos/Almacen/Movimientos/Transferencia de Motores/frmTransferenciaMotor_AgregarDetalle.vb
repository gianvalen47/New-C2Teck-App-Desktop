Imports System.Windows.Forms

Public Class frmTransferenciaMotor_AgregarDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oTransferenciaMotorDetService As New TransferenciaMotorDetService.TransferenciaMotorDetServiceClient
    Private oTransferenciaMotorService As New TransferenciaMotorService.TransferenciaMotorServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdTraMotDet As Integer
    Public IdTraMot As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Public Fecha As Date

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
                          , txtCosDol.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtStock.KeyPress _
                          , txtDscMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTransferenciaMotor_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        state_Search = False
        If state_button Then    'Modificar
            ObtenerRegistro()
            If estado = "GENERADO" Or estado = "GN" Then
                txtCodMer.ReadOnly = True
                txtCodMer.BackColor = System.Drawing.SystemColors.Control
                btnBuscarMercaderia.Enabled = False
                btnGuardar.Enabled = True
            Else
                btnGuardar.Enabled = False
                btnBuscarMercaderia.Enabled = False
                txtCodMer.ReadOnly = True
                txtCodMer.BackColor = System.Drawing.SystemColors.Control
                txtDesMer.ReadOnly = True
                txtDesMer.BackColor = System.Drawing.SystemColors.Control
                txtCanMer.ReadOnly = True
                txtPreMer.ReadOnly = True
                txtPreMer.BackColor = System.Drawing.SystemColors.Control
                txtCosDol.ReadOnly = True
                txtCosDol.BackColor = System.Drawing.SystemColors.Control
                txtCosSol.ReadOnly = True
                txtCosSol.BackColor = System.Drawing.SystemColors.Control
                txtDscMer.ReadOnly = True
                txtDscMer.BackColor = System.Drawing.SystemColors.Control
            End If
            'btnBuscarMercaderia.Enabled = False
            Me.Text = "Modificar detalle " + txtCodMer.Text.ToString
        Else                    'Nuevo
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            txtCodMer.BackColor = System.Drawing.SystemColors.Window


            Me.Text = "Agregar Detalle"
        End If
        
        state_Search = True
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oTransferenciaMotorDetService) = False Then
                oTransferenciaMotorDetService.Close()
            End If
            If isClosed(oTransferenciaMotorService) = False Then
                oTransferenciaMotorService.Close()
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
                          , txtDscMer.KeyUp _
                          , txtCosDol.KeyUp _
                          , txtCosSol.KeyUp
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
    Private Function calculateTotal() As Double
        txtTotal.Text = (toNumber(txtCanMer.Value) * toDouble(txtPreMer.Text)) - (toNumber(txtCanMer.Value) * toDouble(txtDscMer.Text))
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdTraMot) = 0 Then
                MsgBox("Debe Ingresar el código del Transferencia de motor. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtDesMer.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción de la mercadería", MsgBoxStyle.Information, "Información")
                txtDesMer.BackColor = Color.Red
                txtDesMer.Focus()
                Return False
            ElseIf toNumber(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
            ElseIf toDouble(txtPreMer.Text) <= 0 Then
                MsgBox("Debe ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf state_button = False And oTransferenciaMotorDetService.Buscar(IdTraMot, toBlank(txtCodMer.Text)) Then
                MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
                Return False
            ElseIf state_button = True And oTransferenciaMotorService.Estado(IdTraMot) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As TransferenciaMotorDetService.TransferenciaMotorDet)
        Try
            Dim estado_process As Integer
            estado_process = oTransferenciaMotorDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdTraMotDet = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As TransferenciaMotorDetService.TransferenciaMotorDet)
        Try
            Dim estado_process As Boolean
            estado_process = oTransferenciaMotorDetService.Actualizar(registro)
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
    Private Sub ObtenerRegistro()
        Try
            Dim registro As TransferenciaMotorDetService.TransferenciaMotorDet
            registro = oTransferenciaMotorDetService.MostrarPorId(toNumber(IdTraMotDet))

            IdTraMotDet = registro.IdTraMotDet
            IdTraMot = registro.TransferenciaMotor.IdTraMot
            txtCodMer.Text = registro.CodMer
            txtDesMer.Text = registro.DesMer
            txtCanMer.Text = registro.CanMer
            txtPreMer.Text = registro.PreMer
            txtCosDol.Text = registro.CosDol
            txtCosSol.Text = registro.CosSol
            txtDscMer.Text = registro.DscMer
            txtTotal.Text = registro.TotalFila
            txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text)

            estado = oTransferenciaMotorService.Estado(IdTraMot)
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
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

            Dim registro As New TransferenciaMotorDetService.TransferenciaMotorDet
            Dim transferenciaMotor As New TransferenciaMotorDetService.TransferenciaMotor

            registro.IdTraMotDet = IIf(toNumber(IdTraMotDet) = 0, Nothing, IdTraMotDet)
            transferenciaMotor.IdTraMot = IdTraMot
            registro.TransferenciaMotor = transferenciaMotor
            registro.CodMer = toNull(txtCodMer.Text)
            registro.CanMer = toNumber(txtCanMer.Text)
            registro.PreMer = toDouble(txtPreMer.Text)
            registro.DscMer = toDouble(txtDscMer.Text)
            registro.DesMer = toNull(txtDesMer.Text)
            registro.CosDol = toDouble(txtCosDol.Text)
            registro.CosSol = toDouble(txtCosSol.Text)

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
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtDesMer.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtPreMer.Text = frm.precio
            txtDscMer.Text = frm.descuento
            txtCosDol.Text = frm.costo_dolares
            txtCosSol.Text = frm.costo_soles
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtStock.Text = oLocacionMercaderiaService.MostrarStock(IdLocacion, txtCodMer.Text)
            calculateTotal()
        End If
        txtCodMer.Select()
    End Sub
    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click
        calculateTotal()
    End Sub
    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating

        Try
            If Len(Trim(txtCodMer.Text)) > 0 And state_button = False Then

                If oMercaderiaService.Buscar(txtCodMer.Text) Then
                    Dim LocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderia
                    LocacionMercaderia = oLocacionMercaderiaService.MostrarPorCodigo(1, txtCodMer.Text)
                    Dim mercaderia As MercaderiaService.Mercaderia
                    mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)

                    txtStock.Text = LocacionMercaderia.Stock
                    txtDesMer.Text = mercaderia.DesMer1
                    txtPreMer.Text = mercaderia.DeaMer
                    txtDscMer.Text = 0.0
                    txtCosSol.Text = LocacionMercaderia.CosSol
                    txtCosDol.Text = LocacionMercaderia.CosDol
                    calculateTotal()
                Else

                    txtStock.Text = 0
                    txtDesMer.Text = ""
                    txtPreMer.Text = 0.0
                    txtCosSol.Text = ""
                    txtCosDol.Text = ""
                    calculateTotal()

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub txtPreMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPreMer.Validating
        Try
            If oLocacionMercaderiaService.Buscar(1, txtCodMer.Text) = False Then

                txtCosSol.Text = toDouble(txtPreMer.Text * oMaestroService.MostrarTipoCambio("US", Fecha))
                txtCosDol.Text = toDouble(txtPreMer.Text)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged
        If txtCodMer.Text = "" Then
            txtStock.Text = 0
            txtDesMer.Text = ""
            txtPreMer.Text = 0.0
            txtCosSol.Text = ""
            txtCosDol.Text = ""
            calculateTotal()
        End If
    End Sub

End Class
