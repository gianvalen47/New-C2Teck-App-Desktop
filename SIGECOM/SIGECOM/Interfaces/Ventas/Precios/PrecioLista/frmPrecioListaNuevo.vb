Imports System.ServiceModel

Public Class frmPrecioListaNuevo

    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete

    Public CodRubro As String
    Public CodMer As String

    Private Sub frmPrecioListaNuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPrecioService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oPrecioService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oPrecioService.Abort()
            oMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmPrecioListaNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPrecioListaNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar

        txtCodMer.Focus()
        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtPrecioUS.Focus()
        Else                                      'Nuevo
            activar()
            txtCodMer.Focus()
            txtCodMer.Select()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PrecioService.PreciosLista
            registro = oPrecioService.ObtenerPrecioLista(Session.sCodEmp, CodMer)

            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtPrecioUS.Text = registro.PreVen
            txtPrecioNS.Text = registro.PreVenS
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub activar()
        btnBuscarMercaderia.Enabled = True
        txtCodMer.ReadOnly = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        txtPrecioNS.ReadOnly = False
        txtPrecioNS.BackColor = System.Drawing.SystemColors.Window
        txtPrecioUS.ReadOnly = False
        txtPrecioUS.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub desactivar()
        btnBuscarMercaderia.Enabled = False
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtPrecioNS.Enabled = True
        txtPrecioUS.Enabled = True
        txtObservacion.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        And ValidaCampos() Then

            Dim registro As New PrecioService.PreciosLista
            'Dim ListaPrecio As New ListaPrecioClienteDetService.ListaPrecioCliente
            Dim Mercaderia As New PrecioService.Mercaderia
            Dim Empresa As New PrecioService.Empresa

            Empresa.CodEmp = Session.sCodEmp
            registro.Empresa = Empresa
            Mercaderia.CodMer = txtCodMer.Text
            registro.Mercaderia = Mercaderia
            registro.PreVen = txtPrecioUS.Text
            registro.PreVenS = txtPrecioNS.Text
            registro.Observacion = txtObservacion.Text
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

    Private Sub Insertar(ByVal registro As PrecioService.PreciosLista)
        Try
            Dim estado_process As String
            estado_process = oPrecioService.InsertarPrecioLista(registro)
            type_process = "insert"
            If estado_process >= 0 Then
                'IdListaDet = estado_process
                'MsgBox("Se inserto Correctamente")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PrecioService.PreciosLista)
        Try
            Dim estado_process As Boolean
            estado_process = oPrecioService.ActualizarPrecioLista(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                'actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LISTA DE PRECIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm1 As New frmBuscarMercaderia
        frm1.CodRub = CodRubro
        If frm1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm1.codigo
            txtDesMer.Text = frm1.descripcion
        End If
    End Sub

    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtDesMer.Focus()
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

    Private Sub txtDesMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtPrecioUS.Focus()
        End If
    End Sub

    Private Sub txtPrecioUS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioUS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtPrecioNS.Focus()
        End If
    End Sub

    Private Sub txtPrecioNS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioNS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged

    End Sub
End Class