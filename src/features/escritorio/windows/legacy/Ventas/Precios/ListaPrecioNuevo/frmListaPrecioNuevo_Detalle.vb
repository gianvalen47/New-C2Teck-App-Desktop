Imports System.ComponentModel
Imports System.ServiceModel
Public Class frmListaPrecioNuevo_Detalle

    Private oListaPrecioDetService As New ListaPrecioDetService.ListaPrecioDetServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdLista As Integer
    Public IdListaDet As Integer
    Public estado As Integer
    Public estadocab As Integer
    'Public iEstado As Integer
    Public CodRubro As String
    Public Item As Integer


    Private Sub frmListaPrecioNuevo_Detalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioDetService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oListaPrecioDetService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oListaPrecioDetService.Abort()
            oMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioNuevo_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioNuevo_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        Me.Size = New System.Drawing.Size(597, 306)

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
            Dim registro As ListaPrecioDetService.ListaPrecioDet
            registro = oListaPrecioDetService.Obtener(toNumber(IdListaDet))

            estado = registro.EstadoListaPrecio.IdEstado
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtPrecio.Text = registro.Precio
            txtObservacion.Text = registro.Observacion

            If registro.FecAprobacion Is Nothing Or IsDBNull(registro.FecAprobacion) Then
                txtFecAprobacion.Text = ""
            Else
                txtFecAprobacion.Text = registro.FecAprobacion.ToString.Substring(0, 10)
            End If

            If registro.FecVencimiento Is Nothing Or IsDBNull(registro.FecVencimiento) Then
                txtFecVencimiento.Text = ""
            Else
                txtFecVencimiento.Text = registro.FecVencimiento.ToString.Substring(0, 10)
            End If

            'If Not (registro.FecAprobacion.ToString = "") Then
            '    txtFecAprobacion.Value = CDate(registro.FecAprobacion)
            '    txtFecAprobacion.Text = registro.FecAprobacion.ToString
            'End If
            'txtFecVencimiento.Value = registro.FecVencimiento
            txtRubro.Text = registro.Mercaderia.Rubro.DesRub
            'txtPrecioNS.Text = registro.PreVenNS
            'txtItem.Value = registro.Item

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()
        btnBuscarMercaderia.Enabled = False
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control

        If (estado = 1) Then
            txtPrecio.ReadOnly = False
            txtPrecio.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Else
            txtPrecio.ReadOnly = True
            txtPrecio.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If


        btnGuardar.Enabled = IIf((estado = 1), True, False)
    End Sub

    Private Sub activar()
        btnBuscarMercaderia.Enabled = True
        txtCodMer.ReadOnly = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control

        'If (estado = 1 Or estado = 4) Then
        txtPrecio.ReadOnly = False
        txtPrecio.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        'Else
        '    txtPrecio.ReadOnly = True
        '    txtPrecio.BackColor = System.Drawing.SystemColors.Control
        '    txtObservacion.ReadOnly = True
        '    txtObservacion.BackColor = System.Drawing.SystemColors.Control
        'End If

        btnGuardar.Enabled = IIf((estadocab = 1 Or estadocab = 4), True, False)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New ListaPrecioDetService.ListaPrecioDet
            Dim listaprecio As New ListaPrecioDetService.ListaPrecioCab
            Dim Mercaderia As New ListaPrecioDetService.Mercaderia
            'Dim rubro As New ListaPrecioDetService.Rubro

            listaprecio.IdLista = IdLista
            registro.ListaPrecioCab = listaprecio
            registro.IdListaDet = IdListaDet
            Mercaderia.CodMer = txtCodMer.Text
            registro.Mercaderia = Mercaderia
            registro.Precio = txtPrecio.Value
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.Observacion = txtObservacion.Text

            If state_button Then            'Modificar                
                Modificar(registro)
            Else                                  'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtPrecio.Value) <= 0 Then
                MsgBox("Debe Ingresar el Precio", MsgBoxStyle.Information, "Información")
                'txtPrecioNS.BackColor = Color.Red
                txtPrecio.Focus()
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

    Private Sub Insertar(ByVal registro As ListaPrecioDetService.ListaPrecioDet)
        Try
            Dim estado_process As Integer
            estado_process = oListaPrecioDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdListaDet = estado_process
                'MsgBox("Se inserto Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ListaPrecioDetService.ListaPrecioDet)
        Try
            Dim estado_process As Boolean
            estado_process = oListaPrecioDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(sender As Object, e As EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm1 As New frmBuscarMercaderia
        frm1.CodRub = CodRubro
        If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm1.codigo
            txtDesMer.Text = frm1.descripcion

            Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
            Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
            txtRubro.Text = Mercaderia.Rubro.DesRub

            txtPrecio.Focus()

        End If
    End Sub

    Private Sub txtCodMer_Validating(sender As Object, e As CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then

                If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then

                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                    Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)

                    txtCodMer.Text = Mercaderia.CodMer
                    txtDesMer.Text = Mercaderia.DesMer1
                    txtRubro.Text = Mercaderia.Rubro.DesRub

                    txtPrecio.Focus()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtCodMer.KeyPress _
                  , txtDesMer.KeyPress _
                  , txtDesMer.KeyPress _
                  , txtPrecio.KeyPress
        ', txtObservacion.KeyPress
        ' , txtDesMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Tab Or Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            Else
                'dgvDatos.Select()
            End If
        End If
    End Sub

End Class