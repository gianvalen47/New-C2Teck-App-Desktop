Imports System.ServiceModel

Public Class frmListaPrecioCliente_Detalle

    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient
    Private oListaPrecioClienteDetService As New ListaPrecioClienteDetService.ListaPrecioClienteDetServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdLista As Integer
    Public IdListaDet As Integer
    Public estado As Integer
    'Public iEstado As Integer
    Public CodRubro As String
    Public Item As Integer

    Private Sub frmListaPrecioCliente_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
            oListaPrecioClienteDetService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
            oListaPrecioClienteDetService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
            oListaPrecioClienteDetService.Abort()
            oMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar

        txtCodMer.Focus()
        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtCodMer.Focus()
        Else                                      'Nuevo
            activar()
            txtCodMer.Focus()
            txtCodMer.Select()
        End If

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ListaPrecioClienteDetService.ListaPrecioClienteDet
            registro = oListaPrecioClienteDetService.Obtener(toNumber(IdListaDet))

            txtCodMer.Text = registro.Mercaderia.CodMer
            txtCodigoCliente.Text = utils.toNull(registro.CodMerCli)
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtPrecioUS.Text = registro.PreVenUS
            txtPrecioNS.Text = registro.PreVenNS
            txtItem.Value = registro.Item

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()
        btnBuscarMercaderia.Enabled = False
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtCodigoCliente.ReadOnly = False
        txtCodigoCliente.BackColor = System.Drawing.SystemColors.Window
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        btnGuardar.Enabled = IIf(estado = 1, True, False)
    End Sub

    Private Sub activar()
        btnBuscarMercaderia.Enabled = True
        txtCodMer.ReadOnly = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        txtCodigoCliente.ReadOnly = False
        txtCodigoCliente.BackColor = System.Drawing.SystemColors.Window
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        btnGuardar.Enabled = IIf(estado = 1, True, False)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        And ValidaCampos() Then

            Dim registro As New ListaPrecioClienteDetService.ListaPrecioClienteDet
            Dim ListaPrecio As New ListaPrecioClienteDetService.ListaPrecioCliente
            Dim Mercaderia As New ListaPrecioClienteDetService.Mercaderia

            ListaPrecio.IdLista = IdLista
            registro.ListaPrecioCliente = ListaPrecio
            registro.IdListaDet = IdListaDet
            registro.Item = txtItem.Value
            Mercaderia.CodMer = txtCodMer.Text
            registro.Mercaderia = Mercaderia
            registro.CodMerCli = txtCodigoCliente.Text
            registro.PreVenUS = txtPrecioUS.Value
            registro.PreVenNS = txtPrecioNS.Value
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then            'Modificar                
                Modificar(registro)
            Else                                  'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtPrecioNS.Value) <= 0 And toNumber(txtPrecioUS.Value) <= 0 Then
                MsgBox("Debe Ingresar el Precio", MsgBoxStyle.Information, "Información")
                'txtPrecioNS.BackColor = Color.Red
                txtPrecioUS.Focus()
                Return False
            ElseIf (toNumber(txtPrecioNS.Value) > 0 And toNumber(txtPrecioUS.Value) > 0) And (toNumber(txtPrecioUS.Value) > toNumber(txtPrecioNS.Value)) Then
                MsgBox("El precio de venta en dolares no puede ser mayor que el precio de venta en soles ", MsgBoxStyle.Information, "Información")
                txtPrecioUS.BackColor = Color.Red
                txtPrecioUS.Focus()
                Return False
            ElseIf toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe ingresar el Código de la Mercaderia", MsgBoxStyle.Information, "Información")
                'cmbProvisional.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ListaPrecioClienteDetService.ListaPrecioClienteDet)
        Try
            Dim estado_process As Integer
            estado_process = oListaPrecioClienteDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdListaDet = estado_process
                'MsgBox("Se inserto Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ListaPrecioClienteDetService.ListaPrecioClienteDet)
        Try
            Dim estado_process As Boolean
            estado_process = oListaPrecioClienteDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm1 As New frmBuscarMercaderia
        frm1.CodRub = CodRubro
        If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm1.codigo
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtCodMer.KeyPress _
                      , txtCodigoCliente.KeyPress _
                      , txtDesMer.KeyPress _
                      , txtPrecioNS.KeyPress _
                      , txtPrecioUS.KeyPress
        ' , txtDesMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then

                If oMercaderiaService.Buscar(txtCodMer.Text) Then

                    Dim Mercaderia As New MercaderiaService.Mercaderia

                    Mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)

                    txtCodMer.Text = Mercaderia.CodMer
                    txtDesMer.Text = Mercaderia.DesMer1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class