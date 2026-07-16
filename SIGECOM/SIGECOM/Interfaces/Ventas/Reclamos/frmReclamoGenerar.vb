Public Class frmReclamoGenerar

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private oReclamoService As New ReclamoService.ReclamoServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient

    Public IdLocacion As Integer
    Public IdReclamo As Integer
    Private IdSerieDoc As Integer
    Private dtTipos As DataTable
    Public Resultado As String
    Private Tipo As Integer
    Private dtDatos As DataTable


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then
            GenerarGuiaDevolucion()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oGuiaDevolucionService) = False Then
                oGuiaDevolucionService.Close()
            End If
            If isClosed(oReclamoService) = False Then
                oReclamoService.Close()
            End If
            If isClosed(oGuiaRemisionService) = False Then
                oGuiaRemisionService.Close()
            End If
            If isClosed(oGuiaDevolucionService) = False Then
                oGuiaRemisionService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
   
    Private Function ValidaCampos() As Boolean
        Dim IdReferencia As Integer
        Dim Tip_Doc As Integer
        IdReferencia = dgvdatos.CurrentRow.Cells("IdVenta").Text
        Tip_Doc = dgvdatos.CurrentRow.Cells("TipDoc").Text
        Try
            If toNumber(IdReclamo) = 0 Then
                MsgBox("Debe Ingresar el código del Reclamo. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del nuevo documento", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf Tipo = 1 And oGuiaRemisionService.Buscar(IdLocacion, IdSerieDoc, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la Guía ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Select()
                Return False
            ElseIf Tipo = 2 And oGuiaDevolucionService.Buscar(Tip_Doc, IdReferencia, txtNumDoc.Text) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la Guía de Devolución ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf Tipo = 3 And oGuiaRemisionService.Buscar(IdLocacion, IdSerieDoc, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la Guía de Remisión ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Select()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub frmReclamoGenerar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReclamoGenerar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumDoc.KeyPress _
        , txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmReclamoGenerar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFecDoc.Value = Session.sFecha
        If Resultado = "OPERATIVA" Or Resultado = "NO PROCEDE" Then
            rbG_Despacho.Checked = True
            rbG_Devolucion.Enabled = False
            rbG_Remision.Enabled = False
            rbG_Despacho.Enabled = True

        ElseIf Resultado = "GARANTIA" Then
            rbG_Devolucion.Checked = True
            rbG_Despacho.Enabled = False
            rbG_Devolucion.Enabled = True
            rbG_Remision.Enabled = True
            txtNumDoc.Focus()
        End If
        llenarGrilla()

    End Sub
    Private Sub llenarGrilla()
        dtDatos = oReclamoService.Filtrar("01/01/2000", Today, IdLocacion, 0, "", toNumber(IdReclamo)).Tables(0)
        dgvdatos.SetDataBinding(dtDatos, 0)
    End Sub
    Private Sub GenerarGuiaDevolucion()
        Try
            Dim estado_process As String

            estado_process = oReclamoService.GenerarDocumento(Tipo, IdReclamo, IdLocacion, txtFecDoc.Value, txtNumDoc.Text, Session.sCodUsu)
            type_process = "insert"
            If estado_process <> "" Then
                MsgBox(estado_process, MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub rbG_Despacho_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbG_Despacho.CheckedChanged, rbG_Devolucion.CheckedChanged, rbG_Remision.CheckedChanged
        If rbG_Despacho.Checked Then
            IdSerieDoc = oGuiaRemisionService.MostraIdSerie(IdLocacion)
            txtNumDoc.Text = oGuiaRemisionService.SugerirNumero(IdSerieDoc)
            Tipo = 1
        ElseIf rbG_Devolucion.Checked Then
            txtNumDoc.Text = oGuiaDevolucionService.SugerirNumero(IdLocacion)
            Tipo = 2
        ElseIf rbG_Remision.Checked Then
            IdSerieDoc = oGuiaRemisionService.MostraIdSerie(IdLocacion)
            txtNumDoc.Text = oGuiaRemisionService.SugerirNumero(IdSerieDoc)
            Tipo = 3
        End If
    End Sub
End Class