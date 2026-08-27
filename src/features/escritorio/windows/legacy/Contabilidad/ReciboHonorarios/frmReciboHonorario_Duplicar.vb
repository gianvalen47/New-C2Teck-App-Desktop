Imports System.ServiceModel
Public Class frmReciboHonorario_Duplicar

    Private oReciboHonorario As New ReciboHonorarioService.ReciboHonorarioServiceClient
    Public IdHonorario As Integer
    Public NumRegistro As String
    Public SerDoc As String
    Public NumDoc As String

    Private Sub frmReciboHonorario_Duplicar_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        txtFecha.Value = Today
        txtFechaDoc.Value = Today
        txtFechaPago.Value = Today
        txtSerieDoc.Text = SerDoc
        Me.Text = "Duplicar Registro de Compra  N°:" & NumRegistro

    End Sub

    Private Sub frmReciboHonorario_Duplicar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReciboHonorario_Duplicar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReciboHonorario.Close()
        Catch ex As TimeoutException
            oReciboHonorario.Abort()
        Catch ex As CommunicationException
            oReciboHonorario.Abort()
        End Try
    End Sub

    Private Sub btnDuplicar_Click(sender As Object, e As EventArgs) Handles btnDuplicar.Click
        Try
            If MsgBox("¿Esta seguro de DUPLICAR el Recibo por Honorario N° " & NumRegistro & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As String = ""
                estado_process = oReciboHonorario.DuplicarRegistro(IdHonorario, txtFecha.Value, txtFechaDoc.Value, txtFechaPago.Value, txtSerieDoc.Text, txtNumDoc.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process <> "" Then
                    MsgBox("Se generó el Recibo por Honorario correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el Proceso, comunicarse con el área de TI!!!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtNumDoc_TextChanged(sender As Object, e As EventArgs) Handles txtNumDoc.TextChanged

    End Sub

    Private Sub txtNumDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                'If oRegistroCompraService.Buscar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text) Then   'If BuscarNumRegistro(txtMesRegistro,txtNumRegistro) Then  
                '    IdCompra = oRegistroCompraService.ObtenerIdCompra(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text)
                '    state_button = True 'Modificar
                '    edicion = False
                '    ObtenerRegistro()
                '    actualizarDetalles()
                '    desactivar()
                '    txtNumRegistro.SelectAll()
                'Else
                '    state_button = False 'Nuevo 
                '    edicion = True
                '    Limpiar()
                '    activar()
                '    txtCodTipoDoc.Focus()
                'End If
            Else
                MsgBox("Debe ingresar el Numero de Documento", MsgBoxStyle.Critical, "No Existe")
                txtNumDoc.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumDoc_Validated(sender As Object, e As EventArgs) Handles txtNumDoc.Validated
        If Len(Trim(txtNumDoc.Text)) > 0 Then
            Dim cant As Integer = Len(txtNumDoc.Text)
            Do While cant < 8
                txtNumDoc.Text = "0" & txtNumDoc.Text
                cant = cant + 1
            Loop
        Else
            MsgBox("Debe ingresar el Numero de Documento", MsgBoxStyle.Critical, "No Existe")
            txtNumDoc.Focus()
        End If
    End Sub
End Class