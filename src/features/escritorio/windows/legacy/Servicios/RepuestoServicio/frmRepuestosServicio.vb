Imports System.ServiceModel

Public Class frmRepuestosServicio

    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oRepuestoServicioService As New RepuestoServicioService.RepuestoServicioServiceClient

    Public state_button As Boolean
    Public CodServicio As String
    Public DesCodServicio As String
    Public TipMot As String
    Public DesTipMot As String
    Public ModMer As String
    Public DesModMer As String
    Public CodMer As String

    Private Sub frmRepuestosServicio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRepuestoServicioService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oRepuestoServicioService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oRepuestoServicioService.Abort()
            oMercaderiaService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmRepuestosServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepuestosServicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCodMer.KeyPress _
            , txtDescripcion.KeyPress _
            , txtCanMer.KeyPress _
            , txtItem.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRepuestosServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state_button Then
            ObtenerRegistro()
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.Select()
        Else
            txtCodServicio.Text = CodServicio & " / " & DesCodServicio
            txtModMer.Text = ModMer & " / " & DesModMer
            txtTipMot.Text = TipMot & " / " & DesTipMot
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
        End If
        txtCodMer.Select()
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As RepuestoServicioService.RepuestoServicio
            registro = oRepuestoServicioService.Obtener(Session.sCodEmp, CodServicio, TipMot, ModMer, CodMer)

            txtCodServicio.Text = CodServicio & " / " & DesCodServicio
            txtModMer.Text = ModMer & " / " & DesModMer
            txtTipMot.Text = TipMot & " / " & DesTipMot
            txtCodMer.Text = registro.CodMer
            txtDescripcion.Text = registro.DesMer
            txtItem.Value = registro.Item
            txtCanMer.Value = registro.CanMer

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDescripcion.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtCodMer.Select()
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe ingresar el código de la mercaderia")
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la descripción de la mercaderia")
                txtDescripcion.Focus()
                Return False
            ElseIf oRepuestoServicioService.Buscar(Session.sCodEmp, CodServicio, TipMot, ModMer, txtCodMer.Text) And state_button = False Then
                MsgBox("No se puede guardar porque el código " & txtCodMer.Text & " ya existe para estas opciones")
                txtCodMer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As RepuestoServicioService.RepuestoServicio)
        Try
            Dim estado_process As Boolean
            estado_process = oRepuestoServicioService.Insertar(registro)

            If estado_process = True Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RepuestoServicioService.RepuestoServicio)
        Try
            Dim estado_process As Boolean
            estado_process = oRepuestoServicioService.Actualizar(registro)

            If estado_process = True Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If Len(Trim(txtCodMer.Text)) > 0 Then
            If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) And state_button = False Then

                Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                txtCodMer.Text = Mercaderia.CodMer
                txtDescripcion.Text = Mercaderia.DesMer1
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta seguro de AGREGAR la mercaderia?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim registro As New RepuestoServicioService.RepuestoServicio
                Dim modelo As New RepuestoServicioService.Modelo
                Dim tipomotor As New RepuestoServicioService.TipoMotor
                Dim empresa As New RepuestoServicioService.Empresa

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.CodServicio = CodServicio
                modelo.ModMer = ModMer
                registro.Modelo = modelo
                tipomotor.TipMot = TipMot
                registro.TipoMotor = tipomotor
                registro.CodMer = txtCodMer.Text
                registro.DesMer = txtDescripcion.Text
                registro.Item = txtItem.Value
                registro.CanMer = txtCanMer.Value

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class