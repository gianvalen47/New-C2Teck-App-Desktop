Imports System.ServiceModel
Public Class frmInsertarPendientes

    '===========================Servicios====================================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================   
    Public Provisional As Boolean 'Se agrego para validar si el pendiente ingresado es provisional
    Private state_Search As Boolean
    Public IdDocumento As Integer
    Public SerieDoc As String
    Public NumDoc As String
    Private dtTipDoc As DataTable

    Private Sub frmInsertarPendientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmBuscarPendientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        state_Search = False
        LlenarCombos()
        state_Search = True
        txtCodTipoDoc.Focus()
        Me.Text = IIf(Provisional = True, "Insertar Provisional Pendiente", "Insertar Pendiente(s)")
    End Sub

    Private Sub Finalizar()
        Try
            oTesoreriaService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oTesoreriaService.MostrarTipoDocumento().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos1(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            dtTipDoc = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub txtCodTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            Try
                If Len(Trim(txtCodTipoDoc.Text)) = 1 Then
                    Dim cant As Integer = Len(txtCodTipoDoc.Text)
                    Do While cant < 2
                        txtCodTipoDoc.Text = "0" & txtCodTipoDoc.Text
                        cant = cant + 1
                    Loop
                    Dim IdDocumento As Integer
                    Dim TipoDoc As String = txtCodTipoDoc.Text
                    IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoDoc.Text)))
                    If IdDocumento <> 0 Then
                        cmbTipoDoc.Value = IdDocumento
                        txtCodTipoDoc.Text = TipoDoc
                        txtSerieDoc.Focus()
                    Else
                        MsgBox("Codigo no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                        cmbTipoDoc.SelectedIndex = 0
                        txtCodTipoDoc.Text = ""
                        txtCodTipoDoc.Focus()
                    End If

                ElseIf Len(Trim(txtCodTipoDoc.Text)) > 1 Then
                    Dim IdDocumento As Integer
                    Dim TipoDoc As String = txtCodTipoDoc.Text
                    IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoDoc.Text)))
                    If IdDocumento <> 0 Then
                        cmbTipoDoc.Value = IdDocumento
                        txtCodTipoDoc.Text = TipoDoc
                        txtSerieDoc.Focus()
                    Else
                        MsgBox("Codigo no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                        cmbTipoDoc.SelectedIndex = 0
                        txtCodTipoDoc.Text = ""
                        txtCodTipoDoc.Focus()
                    End If
                Else
                    cmbTipoDoc.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtSerieDoc.Text)
                Do While cant < 4
                    txtSerieDoc.Text = "0" & txtSerieDoc.Text
                    cant = cant + 1
                Loop
                txtNumDoc.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                btnAceptar.Focus()
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(cmbTipoDoc.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
                'ElseIf toNumber(txtSerieDoc.Text) = 0 Then
                '    MsgBox("Debe Ingresar la Serie del Documento.", MsgBoxStyle.Information, "Información")
                '    txtSerieDoc.Focus()
                '    Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar el Número del Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub cmbTipoDoc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.ValueChanged
        txtCodTipoDoc.Text = IIf(cmbTipoDoc.Value = 0, "", cmbTipoDoc.DropDownList.GetRow.Cells(3).Text)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If ValidaCampos() Then
                IdDocumento = cmbTipoDoc.Value
                SerieDoc = txtSerieDoc.Text
                NumDoc = txtNumDoc.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PENDIENTES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumDoc_Validated(sender As Object, e As EventArgs) Handles txtNumDoc.Validated
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                btnAceptar.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try

    End Sub
End Class