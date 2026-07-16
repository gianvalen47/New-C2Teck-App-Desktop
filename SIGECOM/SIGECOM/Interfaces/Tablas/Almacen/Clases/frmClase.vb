Public Class frmClase

    Public state_button As Boolean
    Public type_process As String
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Public IdClase As Integer

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtCodClase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodClase.KeyDown
        If e.KeyCode = Keys.F12 Then
            'If btnBuscarClase.Enabled = True Then
            '    e.Handled = True
            'End If
        End If
        txtCodClase.Focus()
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtClase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtDesClase_keyPress(ByVal sender As Object, _
                             ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                             Handles txtDesClase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.Focus()
        End If
    End Sub
    Private Sub frmClase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub txtCodClase_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodClase.Validating
        Try
            If Len(Trim(txtCodClase.Text)) > 0 Then
                Dim claseMerca As MercaderiaService.ClaseMerca
                claseMerca = oMercaderiaService.ObtenerClase(txtCodClase.Text)
                txtClase.Text = claseMerca.NomClas
                txtDesClase.Text = claseMerca.DesClas
            End If
        Catch ex As Exception
            MsgBox("No exite el Código de Clase ingresado. Verifique!!! " + ex.Message, MsgBoxStyle.Critical, "Error al Consultar Mercaderia")
        End Try
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state_button Then    'Modificar
            ObtenerRegistro()

            ' btnBuscarClase.Enabled = False
            txtCodClase.ReadOnly = True
            txtClase.Select()
        Else    'Nuevo
            ' btnBuscarClase.Enabled = False
            txtCodClase.ReadOnly = True
            Me.Text = "Registrar Nueva Clase"
            txtClase.Select()
        End If
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim claseMerca As MercaderiaService.ClaseMerca
            claseMerca = oMercaderiaService.ObtenerClase(txtCodClase.Text)
            txtClase.Text = claseMerca.NomClas
            txtDesClase.Text = claseMerca.DesClas

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Dim frm As New frmBuscarClase
    '    'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '    '    txtDesClase.Text = frm.descripcion
    '    '    txtCodClase.BackColor = System.Drawing.SystemColors.Control
    '    '    txtCodClase.Text = frm.codigo

    '    '    Dim claseMerca As MercaderiaService.ClaseMerca
    '    '    'Dim obtenterCore As MercaderiaService.PreciosCore
    '    '    claseMerca = oMercaderiaService.ObtenerClase(txtCodClase.Text)
    '    '    txtClase.Text = claseMerca.NomClas
    '    '    txtDesClase.Text = claseMerca.DesClas

    '    'End If
    '    'txtCodClase.Select()
    'End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toBlank(txtCodClase.Text) = "" Then
                MsgBox("Debe Ingresar la Clase", MsgBoxStyle.Information, "Información")
                txtCodClase.BackColor = Color.Red
                txtCodClase.Focus()
                Return False
            ElseIf state_button = False And oMercaderiaService.BuscarCore(txtCodClase.Text) Then
                MsgBox("El código de la Clase " + txtCodClase.Text + " no existe...!", MsgBoxStyle.Information, "Información")
                txtCodClase.Select()
                txtCodClase.Clear()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Modificar(ByVal registro As MercaderiaService.ClaseMerca)

        Try
            Dim estado_process As Boolean
            estado_process = oMercaderiaService.ActualizarClase(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se Modificó correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Insertar(ByVal registro As MercaderiaService.ClaseMerca)
        Try
            Dim estado_process As Integer
            estado_process = oMercaderiaService.InsertarClase(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdClase = estado_process
                MsgBox("Se ingresó correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

            Dim registro As New MercaderiaService.ClaseMerca
            Dim empresa As New MercaderiaService.Empresa
            empresa.CodEmp = Session.sCodEmp
            registro.IdClase = toNull(txtCodClase.Text)
            registro.Empresa = empresa
            registro.NomClas = toNull(txtClase.Text)
            registro.DesClas = toNull(txtDesClase.Text)

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oMercaderiaService.BorrarClase(txtCodClase.Text)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If txtCodClase.Text.Trim.Length > 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtCodClase.Focus()
            End If
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class