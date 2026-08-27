Imports System.ServiceModel
Public Class frmDocumentoCostoDet
    Public pIdMovimientoDet As Int64
    Public pTipDoc As Integer
    Public pTipo As Integer
    Private ObjDetalle As New DocumentoCostoService.DocumentoCostoServiceClient
    Private RegistroVenta As New DocumentoCostoService.DocumentoVentaDet
    Private RegistroAlmacen As New DocumentoCostoService.DocumentoAlmacenDet
    Private oMaestroService As New MaestroService.MaestroClient
    Private Fecha As Date
    Private Sub frmDocumentoCostoDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCosDol.KeyPress _
            , txtCosSol.KeyPress _
            , txtTotalCosDol.KeyPress _
            , txtTotalCosSol.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDocumentoCostoDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            'If isClosed(ObjDetalle) = False Then
            '    ObjDetalle.Close()
            'End If
            Finalizar()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Finalizar()
        Try
            ObjDetalle.Close()

        Catch ex As TimeoutException
            ObjDetalle.Abort()
        Catch ex As CommunicationException
            ObjDetalle.Abort()
        End Try
    End Sub


    Private Sub frmDocumentoCostoDet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmDocumentoCostoDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MostrarDatos()
        txtCosDol.Select()
    End Sub
    Private Sub MostrarDatos()
        Try
            Select Case pTipo
                Case 1
                    ObjDetalle.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    RegistroVenta = ObjDetalle.MostrarPorIdVentaDet(pIdMovimientoDet, pTipDoc)
                    txtCodigo.Text = RegistroVenta.Mercaderia.CodMer
                    txtDescripcion.Text = RegistroVenta.Mercaderia.DesMer1
                    txtCantidad.Text = RegistroVenta.CanMer
                    txtPrecio.Text = RegistroVenta.PreMer
                    txtDescuento.Text = RegistroVenta.DscMer
                    txtTotal.Text = RegistroVenta.TotalFila
                    txtCosDol.Text = RegistroVenta.CosDol
                    txtCosSol.Text = RegistroVenta.CosSol
                    txtTotalCosDol.Text = RegistroVenta.CosDol * RegistroVenta.CanMer
                    txtTotalCosSol.Text = RegistroVenta.CosSol * RegistroVenta.CanMer
                    Fecha = RegistroVenta.FecDoc
                Case 2
                    ObjDetalle.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    RegistroAlmacen = ObjDetalle.MostrarPorIdAlmacenDet(pIdMovimientoDet, pTipDoc)
                    txtCodigo.Text = RegistroAlmacen.Mercaderia.CodMer
                    txtDescripcion.Text = RegistroAlmacen.Mercaderia.DesMer1
                    txtCantidad.Text = RegistroAlmacen.CanMer
                    txtPrecio.Text = RegistroAlmacen.PreMer
                    txtDescuento.Text = RegistroAlmacen.DscMer
                    txtTotal.Text = RegistroAlmacen.TotalFila
                    txtCosDol.Text = RegistroAlmacen.CosDol
                    txtCosSol.Text = RegistroAlmacen.CosSol
                    txtTotalCosDol.Text = RegistroAlmacen.CosDol * RegistroAlmacen.CanMer
                    txtTotalCosSol.Text = RegistroAlmacen.CosSol * RegistroAlmacen.CanMer
                    Fecha = RegistroAlmacen.FecDoc
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try

    End Sub
   
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Está Seguro de ACTUALIZAR los Costos?", MsgBoxStyle.YesNo, "Actualizar Costo") = MsgBoxResult.Yes Then
            Try
                Select Case pTipo
                    Case 1
                        ObjDetalle.ActualizarCosto(Session.sCodEmp, pIdMovimientoDet, RegistroVenta.DocumentoVenta.IdVenta, txtCosDol.Text, txtCosSol.Text, pTipDoc, pTipo, RegistroVenta.FecDoc)
                    Case 2
                        ObjDetalle.ActualizarCosto(Session.sCodEmp, pIdMovimientoDet, RegistroAlmacen.DocumentoAlmacen.IdAlmacen, txtCosDol.Text, txtCosSol.Text, pTipDoc, pTipo, RegistroAlmacen.FecDoc)
                End Select
                btnCancelar_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub txtCosDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCosDol.Validating

        Try
            'If oLocacionMercaderiaService.Buscar(1, txtCodMer.Text) = False Then
            If txtCosDol.Value > 0 Then
                txtCosSol.Text = toDouble(txtCosDol.Text * oMaestroService.MostrarTipoCambio("US", Fecha))

            End If
            txtTotalCosDol.Text = txtCosDol.Text * txtCantidad.Text
            txtTotalCosSol.Text = txtCosSol.Text * txtCantidad.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub txtCosSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCosSol.Validating
        txtTotalCosSol.Text = txtCosSol.Text * txtCantidad.Text


    End Sub
    Private Sub txtTotalCosDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCosDol.Validating
        txtCosDol.Text = txtTotalCosDol.Text / txtCantidad.Text
      
    End Sub
    Private Sub txtTotalCosSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCosSol.Validating
        txtCosSol.Text = txtTotalCosSol.Text / txtCantidad.Text

    End Sub


End Class
