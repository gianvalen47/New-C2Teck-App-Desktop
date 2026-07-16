Imports System.Windows.Forms

Public Class frmGenerarDocumento


    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdFactura As Integer
    Public facturaGenerated As String
    Public IdProveedor As Integer

    Private dtDocumentos As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cmbDocaumentos.KeyPress _
                      , txtNumDoc.KeyPress _
                      , txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGenerarDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            ElseIf sender.GetType.ToString = "Janus.Windows.CalendarCombo.CalendarCombo" Then
                campo = New Janus.Windows.CalendarCombo.CalendarCombo
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.IntegerUpDown" Then
                campo = New Janus.Windows.GridEX.EditControls.IntegerUpDown
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
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                           cmbDocaumentos.ValueChanged
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New FacturaImportService.FacturaImport
            Dim serieImp As New FacturaImportService.SerieImportacion
            serieImp.IdSerieImp = cmbDocaumentos.Value
            registro.SerieImportacion = serieImp
            registro.NumDoc = toNull(txtNumDoc.Text)

            If toNumber(cmbDocaumentos.Value) = 0 Then
                MsgBox("Debe ingresar el tipo de documento.", MsgBoxStyle.Information, "Información")
                cmbDocaumentos.BackColor = Color.Red
                cmbDocaumentos.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del documento. ", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(IdFactura) = 0 Then
                MsgBox("Debe de ingresar el número de documento del cual se desea generar el nuevo documento.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe ingresar la fecha. ", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf state_button = False And oFacturaImportService.Buscar(registro) = True Then
                MsgBox("El número del documento  " + txtNumDoc.Text + " ya existe en " + oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "Descripcion", "IdSerieImp", cmbDocaumentos.Value) + "...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Generar()
        Try
            Dim estado_process As Integer
            estado_process = oFacturaImportService.GenerarDocumento(toNull(IdFactura), toNull(cmbDocaumentos.Value), toNumber(IdProveedor), toNull(txtNumDoc.Text), toNull(txtFecha.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process > 0 Then
                facturaGenerated = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function llenarCombos() As Integer
        Try
            '======================================= DOCUMENTOS ================================================
            dtDocumentos = oFacturaImportService.MostrarSerieImportacion(Session.sCodEmp).Tables(0)
            cmbDocaumentos.DataSource = dtDocumentos
            cmbDocaumentos.DropDownList.DataMember = dtDocumentos.Columns("Descripcion").ToString
            cmbDocaumentos.DropDownList.DisplayMember = dtDocumentos.Columns("Descripcion").ToString
            cmbDocaumentos.DropDownList.ValueMember = dtDocumentos.Columns("IdSerieImp").ToString
            cmbDocaumentos.DropDownList.Columns(0).DataMember = dtDocumentos.Columns("IdSerieImp").ToString
            cmbDocaumentos.DropDownList.Columns(1).DataMember = dtDocumentos.Columns("Descripcion").ToString
            cmbDocaumentos.SelectedIndex = 0
            dtDocumentos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
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
        If MsgBox("¿Está seguro de GENERAR el documento?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Generar()
        End If
    End Sub
    Private Sub cmbDocaumentos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDocaumentos.ValueChanged
        txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "NumDoc", "IdSerieImp", cmbDocaumentos.Value)
    End Sub
End Class
