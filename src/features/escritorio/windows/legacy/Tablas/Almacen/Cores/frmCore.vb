Public Class frmCore

    Public state_button As Boolean
    Public type_process As String

    'Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public IdLocacion As String
    Public Oficina As String
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
                e.Handled = True
            End If
        End If
        txtCodMer.Focus()
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtCodMer.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCorMer.Focus()
        End If
    End Sub
    Private Sub txtCorMer_keyPress(ByVal sender As Object, _
                             ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                             Handles txtCorMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub frmCore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then
                Dim mercaderia As MercaderiaService.Mercaderia
                mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)
                'txtCodMer.Text = mercaderia.CodMer
                txtDesMer1.Text = mercaderia.DesMer1
                txtMarca.Text = mercaderia.Marca.DesMar
                txtClase.Text = mercaderia.ClaseMerca.NomClas
                txtRubro.Text = mercaderia.Rubro.DesRub
                txtUniMedida.Text = mercaderia.UnidadMedida.Nombre
                txtDeaMer.Text = mercaderia.DeaMer
                txtCorMer.Text = mercaderia.CorMer
                txtPais.Text = mercaderia.Pais.DesPais
            End If
        Catch ex As Exception
            MsgBox("No exite el Código de Mercaderia ingresado. Verifique!!! " + ex.Message, MsgBoxStyle.Critical, "Error al Consultar Mercaderia")
        End Try
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state_button Then    'Modificar
            ObtenerRegistro()

            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtCorMer.Select()
        Else    'Nuevo
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            Me.Text = "Registrar Nuevo Precio Core"
            txtCodMer.Select()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim mercaderia As MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)
            txtCodMer.Text = mercaderia.CodMer
            txtDesMer1.Text = mercaderia.DesMer1
            txtMarca.Text = mercaderia.Marca.DesMar
            txtClase.Text = mercaderia.ClaseMerca.NomClas
            txtRubro.Text = mercaderia.Rubro.DesRub
            txtUniMedida.Text = mercaderia.UnidadMedida.Nombre
            txtDeaMer.Text = mercaderia.DeaMer
            txtCorMer.Text = mercaderia.CorMer
            txtPais.Text = mercaderia.Pais.DesPais

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer1.Text = frm.descripcion
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.Text = frm.codigo

            Dim mercaderia As MercaderiaService.Mercaderia
            'Dim obtenterCore As MercaderiaService.PreciosCore
            mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)
            txtCodMer.Text = mercaderia.CodMer
            txtDesMer1.Text = mercaderia.DesMer1
            txtMarca.Text = mercaderia.Marca.DesMar
            txtClase.Text = mercaderia.ClaseMerca.NomClas
            txtRubro.Text = mercaderia.Rubro.DesRub
            txtUniMedida.Text = mercaderia.UnidadMedida.Nombre
            txtDeaMer.Text = mercaderia.DeaMer
            txtCorMer.Text = mercaderia.CorMer
            txtPais.Text = mercaderia.Pais.DesPais
        End If
        txtCodMer.Select()
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf state_button = False And oMercaderiaService.BuscarCore(txtCodMer.Text) Then
                MsgBox("El código de la mercadería " + txtCodMer.Text + " no existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Select()
                txtCodMer.Clear()
                Return False
            ElseIf (txtCorMer.Text) = 0 Then
                MsgBox("Debe Ingresar Precio Core", MsgBoxStyle.Information, "Información")
                txtCorMer.BackColor = Color.Red
                txtCorMer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Modificar(ByVal registro As MercaderiaService.PreciosCore)

        Try
            Dim estado_process As Boolean
            estado_process = oMercaderiaService.ActualizarCore(registro)
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
    Private Sub Insertar(ByVal registro As MercaderiaService.PreciosCore)
        Try
            Dim estado_process As Boolean
            estado_process = oMercaderiaService.InsertarCore(registro)
            type_process = "insert"
            If estado_process = True Then
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
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
         And ValidaCampos() Then

            Dim registro As New MercaderiaService.PreciosCore
            Dim mercaderia As New MercaderiaService.Mercaderia
            mercaderia.CodMer = toNull(txtCodMer.Text)
            mercaderia.CorMer = toNull(txtCorMer.Text)
            registro.Mercaderia = mercaderia
            registro.CodUsu = Session.sCodUsu

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
            estado_process = oMercaderiaService.BorrarCore(txtCodMer.Text, Session.sCodUsu)
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
            If txtCodMer.Text.Trim.Length > 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class