Imports System.ServiceModel
Public Class frmCuentasPorPagar_Detalle

    '============================Servicios===================================
    Private oPagosCtasPorPagarService As New PagosCtasPorPagarService.PagosCtasPorPagarServiceClient
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'Update     insert      delete
    Public IdCuentaDet As Integer
    Public IdCuenta As Integer
    Public iEstado As Integer
    Public Total As Double
    Public TotalPago As Double
    Private dtBancos As DataTable
    Private dtTipoPago As DataTable
    Private dtDatos As DataTable

    Private Sub frmCuentasPorPagar_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCuentasPorPagar_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtFecha.KeyPress _
                      , txtCheque.KeyPress _
                      , cmbTipoPago.KeyPress _
                      , cmbBanco.KeyPress _
                      , txtTipoCambio.KeyPress _
                      , txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCuentasPorPagar_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        'iEstado = oCtasPorPagarService.ObtenerEstado(IdCuenta)
        llenarCombos()
        txtFecha.Focus()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            txtFecha.Focus()
        Else                          'Nuevo
            activar()            
            txtFecha.Focus()
            ObtenerSaldo()
        End If
        EnableOptions()
        txtFecha.Focus()
    End Sub

    Private Sub Finalizar()
        Try
            oPagosCtasPorPagarService.Close()
            oCtasPorPagarService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oPagosCtasPorPagarService.Abort()
            oCtasPorPagarService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oPagosCtasPorPagarService.Abort()
            oCtasPorPagarService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub ObtenerSaldo()
        txtMonto.Value = Total - TotalPago
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha. ", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
                'ElseIf txtCheque.Text = "" Then
                '    MsgBox("Debe Ingresar el Número de Cheque. ", MsgBoxStyle.Information, "Información")
                '    txtCheque.Focus()
                '    Return False
            ElseIf toBlank(cmbTipoPago.Value) = "" Then
                MsgBox("Debe de ingresar el Tipo de Pago.", MsgBoxStyle.Information, "Información")
                'cmbTipoPago.BackColor = Color.Red
                cmbTipoPago.Focus()
                Return False
            ElseIf (toNumber(cmbTipoPago.Value) = 3 Or toNumber(cmbTipoPago.Value) = 4) And toBlank(cmbBanco.Value) = "" Then
                MsgBox("Debe de ingresar el Banco.", MsgBoxStyle.Information, "Información")
                'cmbTipoPago.BackColor = Color.Red
                cmbTipoPago.Focus()
                Return False
                'ElseIf toBlank(cmbBanco.Value) = "" Then
                '    MsgBox("Debe de ingresar el Banco.", MsgBoxStyle.Information, "Información")
                '    'cmbTipoPago.BackColor = Color.Red
                '    cmbBanco.Focus()
                '    Return False
            ElseIf toDouble(txtTipoCambio.Value) <= 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio ", MsgBoxStyle.Information, "Información")
                'txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf toDouble(txtMonto.Value) = 0 Then
                MsgBox("El monto debe ser diferente a CERO.", MsgBoxStyle.Information, "Información")
                'txtMonto.BackColor = Color.Red
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        If iEstado = 1 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtCheque.ReadOnly = False
        txtCheque.BackColor = System.Drawing.SystemColors.Window
        cmbTipoPago.ReadOnly = False
        cmbTipoPago.BackColor = System.Drawing.SystemColors.Window
        cmbBanco.ReadOnly = False
        cmbBanco.BackColor = System.Drawing.SystemColors.Window
        txtTipoCambio.ReadOnly = False
        txtTipoCambio.BackColor = System.Drawing.SystemColors.Window
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub desactivar()
        If iEstado = 1 Then
            activar()
        Else
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtCheque.ReadOnly = True
            txtCheque.BackColor = System.Drawing.SystemColors.Control
            cmbTipoPago.ReadOnly = True
            cmbTipoPago.BackColor = System.Drawing.SystemColors.Control
            cmbBanco.ReadOnly = True
            cmbBanco.BackColor = System.Drawing.SystemColors.Control
            txtTipoCambio.ReadOnly = True
            txtTipoCambio.BackColor = System.Drawing.SystemColors.Control
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub Insertar(ByVal registro As PagosCtasPorPagarService.PagosCtasPorPagar)
        Try
            Dim estado_process As Integer
            estado_process = oPagosCtasPorPagarService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCuentaDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PagosCtasPorPagarService.PagosCtasPorPagar)
        Try
            Dim estado_process As Boolean
            estado_process = oPagosCtasPorPagarService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PagosCtasPorPagarService.PagosCtasPorPagar
            registro = oPagosCtasPorPagarService.Obtener(toNumber(IdCuentaDet))

            IdCuentaDet = registro.IdCuentaDet
            IdCuenta = registro.CtasPorPagar.IdCuenta
            txtCheque.Text = registro.Cheque
            txtFecha.Value = registro.Fecha
            txtMonto.Value = registro.Monto
            txtObservacion.Text = registro.Observacion
            txtTipoCambio.Value = registro.TipCam
            If registro.Banco.CodBan <> 0 Then
                cmbBanco.Value = registro.Banco.CodBan
            Else
                cmbBanco.SelectedIndex = 0
            End If
            cmbTipoPago.Value = registro.TipoPagoCompras.IdTipoPago
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= BANCOS =================================================
            dtBancos = oMaestroService.MostrarBancos.Tables(0)
            dtBancos.Rows.InsertAt(getRowTodos(dtBancos), 0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.SelectedIndex = 0
            dtBancos = Nothing

            '===================================== TIPO DE PAGO COMPRA =======================================
            dtTipoPago = oPagosCtasPorPagarService.MostrarTipoPago().Tables(0)
            cmbTipoPago.DataSource = dtTipoPago
            cmbTipoPago.DropDownList.DataMember = dtTipoPago.Columns("DesPago").ToString
            cmbTipoPago.DropDownList.DisplayMember = dtTipoPago.Columns("DesPago").ToString
            cmbTipoPago.DropDownList.ValueMember = dtTipoPago.Columns("IdTipoPago").ToString
            cmbTipoPago.DropDownList.Columns(0).DataMember = dtTipoPago.Columns("IdTipoPago").ToString
            cmbTipoPago.DropDownList.Columns(1).DataMember = dtTipoPago.Columns("DesPago").ToString
            dtTipoPago = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then
            Dim registro As New PagosCtasPorPagarService.PagosCtasPorPagar
            Dim ctaPorPagar As New PagosCtasPorPagarService.CtasPorPagar
            Dim Banco As New PagosCtasPorPagarService.Banco
            Dim TipoPago As New PagosCtasPorPagarService.TipoPagoCompras

            registro.IdCuentaDet = IdCuentaDet

            If toNumber(cmbBanco.Value) = 0 Then
                Banco.CodBan = Nothing
                registro.Banco = Banco
            Else
                Banco.CodBan = cmbBanco.Value
                registro.Banco = Banco
            End If
            registro.Cheque = toNull(txtCheque.Text)
            ctaPorPagar.IdCuenta = IdCuenta
            registro.CtasPorPagar = ctaPorPagar
            registro.Fecha = txtFecha.Value
            registro.Monto = toDouble(txtMonto.Value)
            registro.Observacion = txtObservacion.Text
            registro.TipCam = toDouble(txtTipoCambio.Value)
            TipoPago.IdTipoPago = cmbTipoPago.Value
            registro.TipoPagoCompras = TipoPago
            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc
            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class