Imports System.Windows.Forms

Public Class frmGuiaRemision_GenerarDocumento
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private dtDatos As DataTable
    Private dtMotivos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdGuia As Integer
    Public IdLocacion As Integer
    Public CodPag As String
    Public CodMon As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtNumDoc.KeyPress, txtFecDoc.KeyPress, cmbTipo.KeyPress, cmbCodPag.KeyPress, txtCodPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGuiaRemision_GenerarDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        CargarPerfil()

        If cmbTipo.Value = 2 Then
            txtNumDoc.Text = oGuiaRemisionService.SugerirFactura(IdLocacion, Session.sCodUsu)
        ElseIf cmbTipo.Value = 3 Then
            txtNumDoc.Text = oGuiaRemisionService.SugerirBoleta(IdLocacion, Session.sCodUsu)
        End If
        txtFecDoc.Value = Session.sFecha
        txtCodPago.Text = CodPag
        cmbCodPag.Value = CodPag
        cmbCodMot.Value = "1"
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oGuiaRemisionService) = False Then
                oGuiaRemisionService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oReporteVentaService) = False Then
                oReporteVentaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                  txtNumDoc.KeyUp _
                , txtFecDoc.KeyUp
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub CargarPerfil()
        Try
            If Not (Session.CodPerfil = "11" Or Session.CodPerfil = "05" Or Session.CodPerfil = "57" Or Session.CodPerfil = "01" Or Session.CodPerfil = "28") Then
                txtCodPago.ReadOnly = True
                txtCodPago.BackColor = System.Drawing.SystemColors.Control
                cmbCodPag.ReadOnly = True
                cmbCodPag.BackColor = System.Drawing.SystemColors.Control
            End If
        Catch ex As Exception
            MsgBox("Error al cargar el perfil : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdGuia) = 0 Then
                MsgBox("Debe Ingresar el código de la guía. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar número de la nota de crédito.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio(CodMon, txtFecDoc.Text) = 0 Then
                MsgBox("Esta fecha no tiene tipo de cambio, Tenga cuidado...")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(cmbCodPag.Text) = "" Then
                MsgBox("Debe Ingresar la condición de pago.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf state_button = True And oGuiaRemisionService.Estado(IdGuia) <> "IMPRESO" Then
                MsgBox("No puede generar el documento...!" + vbCr + "Debido que la Guía no esta en estado IMPRESO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub GenerarDocumento()
        Try
            Dim estado_process As Integer
            estado_process = oGuiaRemisionService.GenerarDocumento(cmbTipo.Value, IdGuia, txtFecDoc.Text, txtNumDoc.Text, cmbCodPag.Value, cmbCodMot.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "insert"
            If estado_process > 0 Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS  ================================================
            dtDatos = New DataTable
            dtDatos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtDatos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtDatos.Rows.Add(New Object() {2, "Factura"})
            dtDatos.Rows.Add(New Object() {3, "Boleta"})

            cmbTipo.DataSource = dtDatos
            cmbTipo.DropDownList.DataMember = dtDatos.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtDatos.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtDatos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtDatos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtDatos.Columns("nombre").ToString
            cmbTipo.SelectedIndex = 0
            dtDatos = Nothing
            '======================================= CONDICIONES DE PAGO ================================================
            dtDatos = oMaestroService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtDatos
            cmbCodPag.DropDownList.DataMember = dtDatos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtDatos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtDatos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtDatos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtDatos.Columns("DesPag").ToString
            dtDatos = Nothing

            '======================================= MOTIVOS ================================================
            dtMotivos = oReporteVentaService.MostrarMotivosVenta.Tables(0) ' oMaestroService.MostrarMotivos.Tables(0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [GEN-003]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            GenerarDocumento()
        End If
    End Sub
    Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        If cmbTipo.Value = 2 Then
            txtNumDoc.Text = oGuiaRemisionService.SugerirFactura(IdLocacion, Session.sCodUsu)
        ElseIf cmbTipo.Value = 3 Then
            txtNumDoc.Text = oGuiaRemisionService.SugerirBoleta(IdLocacion, Session.sCodUsu)
        End If
    End Sub

    Private Sub txtCodPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodPago.Validating
        Try
            If Len(Trim(txtCodPago.Text)) > 0 Then
                Dim CodPago As String
                CodPago = oMaestroService.MostrarDato("Maestro.CondicionPago", "CodPag", "CodPag", Trim(txtCodPago.Text))
                If CodPago <> "" Then
                    cmbCodPag.Value = CodPago
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCodPago.Clear()
                    cmbCodPag.Clear()
                    txtCodPago.Select()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbCodPag_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCodPag.ValueChanged
        Try
            txtCodPago.Text = cmbCodPag.Value

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
