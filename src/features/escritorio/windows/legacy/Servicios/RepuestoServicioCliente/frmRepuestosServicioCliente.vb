Imports System.ServiceModel

Public Class frmRepuestosServicioCliente

    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    'Private oRepuestoServicioService As New RepuestoServicioService.RepuestoServicioServiceClient
    Private oRepuestoServicioClienteService As New RepuestoServicioClienteService.RepuestoServicioClienteServiceClient

    Public state_button As Boolean
    Public CodServicio As String
    Public DesCodServicio As String
    Public TipMot As String
    Public DesTipMot As String
    Public ModMer As String
    Public DesModMer As String
    Public CodMer As String
    Public IdCliente As Integer

    Private Sub frmRepuestosServicioCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRepuestoServicioClienteService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oRepuestoServicioClienteService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oRepuestoServicioClienteService.Abort()
            oMercaderiaService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmRepuestosServicioCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmRepuestosServicioCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCodMer.KeyPress _
        , txtDescripcion.KeyPress _
        , txtCanMer.KeyPress _
        , txtItem.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepuestosServicioCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            ElseIf oRepuestoServicioClienteService.Buscar(Session.sCodEmp, CodServicio, TipMot, ModMer, IdCliente, txtCodMer.Text) Then
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As RepuestoServicioClienteService.RepuestoServicioCliente
            registro = oRepuestoServicioClienteService.Obtener(Session.sCodEmp, CodServicio, TipMot, ModMer, IdCliente, CodMer)

            txtCodServicio.Text = CodServicio & " / " & DesCodServicio
            txtModMer.Text = ModMer & " / " & DesModMer
            txtTipMot.Text = TipMot & " / " & DesTipMot
            txtCodMer.Text = registro.CodMer
            txtDescripcion.Text = registro.DesMer
            txtItem.Value = registro.Item
            txtCanMer.Value = registro.CanMer
            lblCliente.Text = registro.Cliente.DesCli
            IdCliente = registro.Cliente.IdCliente

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

    Private Sub Insertar(ByVal registro As RepuestoServicioClienteService.RepuestoServicioCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oRepuestoServicioClienteService.Insertar(registro)

            If estado_process = True Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RepuestoServicioClienteService.RepuestoServicioCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oRepuestoServicioClienteService.Actualizar(registro)

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
            If MsgBox("¿Está seguro de AGREGAR la mercaderia?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim registro As New RepuestoServicioClienteService.RepuestoServicioCliente
                Dim modelo As New RepuestoServicioClienteService.Modelo
                Dim tipomotor As New RepuestoServicioClienteService.TipoMotor
                Dim cliente As New RepuestoServicioClienteService.Cliente
                Dim empresa As New RepuestoServicioClienteService.Empresa

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
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
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