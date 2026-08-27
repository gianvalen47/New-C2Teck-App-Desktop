Imports System.Windows.Forms

Public Class frmMovimAlmacen_GenerarVale
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMoviAlmacen As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================

    Public IdMovimiento As Integer
    Public IdLocacion As Integer


    Private IdPersona As String
    Private dtTipos As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmMovimAlmacen_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMoviAlmacen) = False Then
                oMoviAlmacen.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oValeMaterialService) = False Then
                oValeMaterialService.Close()
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

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumero.Text) = "" Then
                MsgBox("Debe Ingresar el numero de documento", MsgBoxStyle.Information, "Información")
                txtNumero.BackColor = Color.Red
                txtNumero.Focus()
                Return False
            ElseIf state_button = False And toNumber(IdMovimiento) = 0 Then
                MsgBox("Debe Ingresar el código del Movimiento. ", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try
            'dtTipos = oMaestro.MostrarSerieDocumento(54, 3, "").Tables(0)
            dtTipos = oMaestroService.MostrarSerieDocumento(IdLocacion, 3, "").Tables(0)

            If dtTipos.Rows.Count = 0 Then

                MsgBox("Este almacen no esta habilitado para emitir vales de almacen, Comunicarse con TI", MsgBoxStyle.Exclamation)


            Else
                'dtTipos = oMaestro.MostrarSerieDocumento(cmbAlmacen.Value, 3, "").Tables(0)
                cmbIdSerieDoc.DataSource = dtTipos
                cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
                cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
                cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
                cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
                cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
                cmbIdSerieDoc.SelectedIndex = 0
                dtTipos = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de generar el VALE para regularizar entrega provisional?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim estado_process As Long
                estado_process = oMoviAlmacen.GenerarVale(IdMovimiento, txtFecha.Text, cmbIdSerieDoc.Value, txtNumero.Text, IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'type_process = "update"
                If estado_process > 0 Then
                    MsgBox("Se genero el vale " & txtNumero.Text & " correctamente.", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtPersonal.Text = frm.descripcion
                    IdPersona = frm.codigo

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbIdSerieDoc_ValueChanged(sender As Object, e As EventArgs) Handles cmbIdSerieDoc.ValueChanged
        If cmbIdSerieDoc.Text <> "" Then
            txtNumero.Text = oValeMaterialService.SugerirNumero(cmbIdSerieDoc.Value)
        End If
    End Sub
End Class
