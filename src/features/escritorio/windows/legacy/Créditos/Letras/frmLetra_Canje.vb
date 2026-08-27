Public Class frmLetra_Canje
    Private oLetraService As New LetraService.LetraServiceClient
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Public IdCliente As Integer
    Public DesCli As String
    Public NumLetra As Integer
    Public TotLetra As String
    Private dtDatos As DataTable
    Private state_Search As Boolean

    Private Sub frmLetra_Canje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCliente.KeyPress _
            , txtFecAcep.KeyPress _
            , txtNumLet1.KeyPress _
            , txtNumLet2.KeyPress _
            , txtTotLet.KeyPress _
            , txtTotCanje.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmLetra_Canje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oLetraService) = False Then
                oLetraService.Close()
            End If
            If isClosed(oDocumentoCtaCtesService) = False Then
                oDocumentoCtaCtesService.Close()
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmLetra_Canje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frnLetra_Canje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right

        state_Search = True
        txtFecAcep.Text = Today
        txtCliente.Text = DesCli
        txtNumLet1.Text = NumLetra
        txtNumLet2.Text = NumLetra
        txtTotLet.Text = TotLetra
        listaDatos()
        state_Search = False
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        txtNumLet1.Select()

    End Sub

    Private Sub listaDatos()
        Try
            ' If state_Search = True Then
            dtDatos = oDocumentoCtaCtesService.MostrarDeudas(Session.sCodEmp, IdCliente).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            'End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        dgvDatos.Focus()
    End Sub
  
    Private Function ValidaCampos() As Boolean
        Try
            If IdCliente = 0 Then
                MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtNumLet1.Text) = "" Then
                MsgBox("Debe Ingresar el número de Letra.", MsgBoxStyle.Information, "Información")
                txtNumLet1.BackColor = Color.Red
                txtNumLet1.Focus()
                Return False
            ElseIf toBlank(txtNumLet2.Text) = "" Then
                MsgBox("Debe Ingresar el número de Letra.", MsgBoxStyle.Information, "Información")
                txtNumLet2.BackColor = Color.Red
                txtNumLet2.Focus()
                Return False
            ElseIf toBlank(txtFecAcep.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de Aceptación.", MsgBoxStyle.Information, "Información")
                txtFecAcep.BackColor = Color.Red
                txtFecAcep.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
   
    Private Sub btnCanjear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanjear.Click
        Try
            If MsgBox("¿Está seguro de Canjear las letras?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                dtDatos = dgvDatos.DataSource
                Dim estado_process As Boolean
                estado_process = oLetraService.Canjear(Session.sCodEmp, IdCliente, txtFecAcep.Text, txtNumLet1.Text, txtNumLet2.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, dtDatos)

                If estado_process Then
                    MsgBox("Se realizó el canje correctamente")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else
                    MsgBox("No se canjeo")

                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub SumaTotal()

        If dgvDatos.RowCount > 0 Then
            
            dtDatos.AcceptChanges()
            Dim Total As Double = 0
            Dim Col As Integer = Me.dgvDatos.CurrentRow.Cells("Canje").Text
            For Each row As DataRow In dtDatos.Rows
                Total += Val(row.Item("Canje"))
            Next
            Me.txtTotCanje.Text = FormatNumber(Total.ToString, 2, , , TriState.True)


        End If
    End Sub

    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        If (dgvDatos.CurrentRow.Cells("Canje").Value) > (dgvDatos.CurrentRow.Cells("Saldo").Value) Then

            MsgBox("El monto no puede ser mayor a : " + dgvDatos.CurrentRow.Cells("Saldo").Text.ToString + ".", MsgBoxStyle.Information, "Información")
            dgvDatos.CurrentRow.Cells("Canje").Value = 0.0
        Else
            SumaTotal()
        End If
    End Sub
    Private Function limpiar() As Boolean
        Try
            dgvDatos.CurrentRow.Cells("Canje").Text = 0.0
            Return False
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function


End Class