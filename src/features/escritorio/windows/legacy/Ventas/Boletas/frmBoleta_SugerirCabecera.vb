Public Class frmBoleta_SugerirCabecera
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Public IdSugerido As Integer
    Public IdBoleta As Integer

    Private Sub frmBoleta_SugerirCabecera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmBoleta_SugerirCabecera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        Me.Text = "Sugerir Factor - Dscto"
        state_button = oBoletaService.BuscarSugerido(IdBoleta)

        If state_button Then    ' Modificar
            btnEliminar.Enabled = True
            btnEliminar.Visible = True
            ObtenerRegistro()
        Else
            btnEliminar.Enabled = False
            btnEliminar.Visible = False
            btnAceptar.Location = New System.Drawing.Size(40, 200)
            btnCancelar.Location = New System.Drawing.Size(120, 200)
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oBoletaService) = False Then
                oBoletaService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If txtFactorSug.Value < 0 Then
                MsgBox("Debe Ingresar un Factor Valido.", MsgBoxStyle.Information, "Información")
                txtFactorSug.Select()
                Return False
            ElseIf txtDsctoSug.Value < 0 Then
                MsgBox("Debe Ingresar un Descuento Valido.", MsgBoxStyle.Information, "Información")
                txtDsctoSug.Select()

                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar()
        Try
            Dim estado_process As Integer
            estado_process = oBoletaService.InsertarSugerido(IdBoleta, txtFactorSug.Text, txtDsctoSug.Text, txtObservacion.Text)
            type_process = "insert"
            If estado_process Then
                'IdSugerido = estado_process
                IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoBoleta", "IdSugerido", "IdBoleta", IdBoleta)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim estado_process As Boolean
            estado_process = oBoletaService.ActualizarSugerido(IdSugerido, txtFactorSug.Text, txtDsctoSug.Text, txtObservacion.Text)
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
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oBoletaService.BorrarSugerido(IdSugerido)
            type_process = "delete"
            IdSugerido = oBoletaService.MostrarIdSugerido(IdBoleta)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As BoletaService.SugeridoBoleta
            registro = oBoletaService.MostrarSugeridoPorId(IdSugerido)
            txtFactorSug.Value = registro.FactorSug
            txtDsctoSug.Value = registro.DsctoSug
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
      And ValidaCampos() Then
            If state_button Then        'Modificar
                Modificar()
            Else                        'Nuevo
                Insertar()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR los datos Sugeridos ... ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Eliminar()
        End If
    End Sub
  
    Private Sub txtDsctoSug_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsctoSug.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtDsctoSug.Text <> 0.0 Then
                txtFactorSug.Text = 0
                txtFactorSug.ReadOnly = True
                txtFactorSug.BackColor = System.Drawing.SystemColors.Control
                txtObservacion.Focus()

            ElseIf txtDsctoSug.Text = 0.0 Then
                txtFactorSug.ReadOnly = False
                txtFactorSug.BackColor = System.Drawing.SystemColors.Window
                txtFactorSug.Focus()

            End If
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Select()
        End If
    End Sub

    Private Sub txtFactorSug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFactorSug.Click

    End Sub

    Private Sub txtFactorSug_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFactorSug.Validating
        If txtFactorSug.Text >= 10 Then
            MsgBox("El factor no puede ser mayor o igual a 10, Verifique...")
            txtFactorSug.Text = 0
            txtFactorSug.Select()
        Else
            If txtFactorSug.Text <> 0.0 Then
                txtDsctoSug.Text = 0
                txtDsctoSug.ReadOnly = True
                txtDsctoSug.BackColor = System.Drawing.SystemColors.Control
                txtObservacion.Focus()

            ElseIf txtFactorSug.Text = 0.0 Then
                txtDsctoSug.ReadOnly = False
                txtDsctoSug.BackColor = System.Drawing.SystemColors.Window
                txtDsctoSug.Focus()
            End If
        End If
    End Sub
End Class