Public Class frmComSolicitudCompra_AgregarCotizacion

    Private state_button As Boolean
    Private opcion As Boolean

    Private Sub frmComSolicitudCompra_AgregarCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompra_AgregarCotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCodPrv.KeyPress _
           , txtPreMer.KeyPress _
           , txtCotizacion.KeyPress _
           , txtDsctoMer.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComSolicitudCompra_AgregarCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Cotizaciones de Proveedores"
        Desactivar()

    End Sub

    Private Sub enableOpciones()
        Try
            If opcion Then
                biNuevo.Enabled = True
                biModificar.Enabled = True
                biEliminar.Enabled = True
            Else
                biNuevo.Enabled = False
                biModificar.Enabled = False
                biEliminar.Enabled = False

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Activar()
        Try
            If state_button = False Then
                txtCodPrv.ReadOnly = False
                txtDesPrv.ReadOnly = False
                txtPreMer.ReadOnly = False
                txtCotizacion.ReadOnly = False
                txtDsctoMer.ReadOnly = False
                txtObservacion.ReadOnly = False

                btnBuscarProveedor.Enabled = True
            Else
                txtCotizacion.ReadOnly = False
                txtDsctoMer.ReadOnly = False
                txtObservacion.ReadOnly = False
            End If
            enableOpciones()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Desactivar()
        Try
            txtCodPrv.ReadOnly = True
            txtDesPrv.ReadOnly = True
            txtPreMer.ReadOnly = True
            txtCotizacion.ReadOnly = True
            txtDsctoMer.ReadOnly = True
            txtObservacion.ReadOnly = True

            btnBuscarProveedor.Enabled = False

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LimpiarDatos()
        Try
            txtCodPrv.Clear()
            txtDesPrv.Clear()
            txtPreMer.Clear()
            txtCotizacion.Text = 0
            txtDsctoMer.Text = 0
            txtObservacion.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Insertar()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Modificar()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Try
            state_button = False
            opcion = False
            LimpiarDatos()
            Activar()
            txtCodPrv.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub biModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biModificar.Click
        Try
            state_button = True
            opcion = False
            Activar()
            txtCotizacion.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Estás Seguro de Guardar los Cambios?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If state_button Then
                    Modificar()
                Else
                    Insertar()
                End If
                opcion = True
                enableOpciones()
                Desactivar()

            End If
        Catch ex As Exception

        End Try
    End Sub

   
End Class