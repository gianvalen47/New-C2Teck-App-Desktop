Imports System.ComponentModel
Imports System.ServiceModel
Public Class frmListaPrecioFabricante_Detalle

    Private oListaPrecioFabricanteDetService As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdListaFab As Integer
    Public IdListaFabDet As Integer
    Public estado As Integer
    Public estadocab As Integer
    'Public iEstado As Integer
    Public CodRubro As String
    Public ItemSug As Integer

    Private Sub frmListaPrecioFabricante_Detalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioFabricanteDetService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oListaPrecioFabricanteDetService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oListaPrecioFabricanteDetService.Abort()
            oMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioFabricante_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioFabricante_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        txtCodMer.Focus()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtCodMer.Focus()
        Else                                      'Nuevo
            'txtItem.Value = ItemSug
            activar()
            txtCodMer.Focus()
            txtCodMer.Select()
        End If
        'Me.Size = New System.Drawing.Size(601, 345)
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
            registro = oListaPrecioFabricanteDetService.Obtener(toNumber(IdListaFabDet))


            txtCodMer.Text = registro.CodMer
            txtDesMer.Text = registro.DesMer
            txtPreLista.Text = registro.PreLista
            txtPrecioSLP.Text = registro.PrecioSLP
            txtPrecio.Text = registro.Precio

            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()
        btnBuscarMercaderia.Enabled = False

        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtDesMer.ReadOnly = False
        txtDesMer.BackColor = System.Drawing.SystemColors.Window

        txtPreLista.ReadOnly = False
        txtPreLista.BackColor = System.Drawing.SystemColors.Window
        txtPrecioSLP.ReadOnly = False
        txtPrecioSLP.BackColor = System.Drawing.SystemColors.Window
        txtPrecio.ReadOnly = False
        txtPrecio.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()

        btnBuscarMercaderia.Enabled = True

        txtCodMer.ReadOnly = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        txtDesMer.ReadOnly = False
        txtDesMer.BackColor = System.Drawing.SystemColors.Window
        txtPreLista.ReadOnly = False
        txtPreLista.BackColor = System.Drawing.SystemColors.Window
        txtPrecioSLP.ReadOnly = False
        txtPrecioSLP.BackColor = System.Drawing.SystemColors.Window
        txtPrecio.ReadOnly = False
        txtPrecio.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
    And ValidaCampos() Then

            Dim registro As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet
            Dim listapreciofabrica As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteCab
            'Dim rubro As New ListaPrecioDetService.Rubro

            listapreciofabrica.IdListaFab = IdListaFab
            registro.ListaPrecioFabricanteCab = listapreciofabrica

            registro.IdListaFabDet = IdListaFabDet
            registro.CodMer = txtCodMer.Text
            registro.DesMer = txtDesMer.Text
            registro.PreLista = txtPreLista.Value
            registro.PrecioSLP = txtPrecioSLP.Value
            registro.Precio = txtPrecio.Value
            registro.Observacion = txtObservacion.Text
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.CodUsu = Session.sCodUsu

            If state_button Then                  'Modificar                
                Modificar(registro)
            Else                                  'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toDouble(txtPrecio.Value) <= 0 Then
                MsgBox("Debe Ingresar el Precio", MsgBoxStyle.Information, "Información")
                'txtPrecioNS.BackColor = Color.Red
                txtPrecio.Focus()
                Return False
            ElseIf utils.toDouble(txtPrecioSLP.Value) <= 0 Then
                MsgBox("Debe Ingresar el Precio SLP", MsgBoxStyle.Information, "Información")
                'txtPrecioNS.BackColor = Color.Red
                txtPrecioSLP.Focus()
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

    Private Sub Insertar(ByVal registro As ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet)
        Try
            Dim estado_process As Integer
            estado_process = oListaPrecioFabricanteDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdListaFabDet = estado_process
                'MsgBox("Se inserto Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet)
        Try
            Dim estado_process As Boolean
            estado_process = oListaPrecioFabricanteDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarMercaderia_Click(sender As Object, e As EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm1 As New frmBuscarMercaderia
        frm1.CodRub = CodRubro
        If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm1.codigo
            txtDesMer.Text = frm1.descripcion

            txtPreLista.Focus()
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

                    txtPreLista.Focus()

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
          , txtPrecio.KeyPress _
          , txtPrecioSLP.KeyPress _
          , txtPreLista.KeyPress
        ' , txtDesMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Select()
            btnGuardar_Click(sender, e)
        End If
    End Sub

End Class