Imports System.ServiceModel

Public Class frmComCotizacionesSolicitud

    Private oCotizacionSolicitudService As New CotizacionSolicitudService.CotizacionSolicitudServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private IdProveedor As Integer = 0

    Private Sub frmComCotizacionesSolicitud_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oCotizacionSolicitudService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCotizacionSolicitudService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oCotizacionSolicitudService.Abort()
            oSeguridadService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmComCotizacionesSolicitud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComCotizacionesSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtAnio.KeyPress _
        , txtProveedor.KeyPress _
        , txtNumSolicitud.KeyPress _
        , txtNumCotizacion.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComCotizacionesSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 134)
        '/*************************************************************************************/

        cbProveedor.Enabled = False
        pboxLimpiarProveedor.Enabled = True
        ToolTip1.SetToolTip(cbProveedor, "Limpiar Proveedor")
        ToolTip1.SetToolTip(pboxLimpiarProveedor, "Limpiar Proveedor")

        txtAnio.Value = Today.Year
        listaDatos()
        Dim Estilo As New Estilo
        Estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.Text = "Cotización de Solicitud de Compra"

        enableOpciones()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If CInt(row.Cells("IdCotizacion").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1

            End If
        Next

    End Sub

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount > 0 Then

                biEliminar.Enabled = True
                biActualizar.Enabled = True
                biMostrar.Enabled = True
                biImprimir.Enabled = True

                miEliminar.Enabled = True
                miActualizar.Enabled = True
                miMostrar.Enabled = True
                miImprimir.Enabled = True

            Else
                biEliminar.Enabled = False
                biActualizar.Enabled = False
                biMostrar.Enabled = False
                biImprimir.Enabled = False

                miEliminar.Enabled = False
                miActualizar.Enabled = False
                miMostrar.Enabled = False
                miImprimir.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("Error al inhabilitar las opciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionSolicitudService.Filtrar(toNumber(txtAnio.Value), IdProveedor, toBlank(txtNumCotizacion.Text), toNumber(txtNumSolicitud.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtAnio.ValueChanged, txtNumCotizacion.TextChanged, txtNumSolicitud.TextChanged, txtProveedor.TextChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                cbProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmComCotizacionSolicitud

            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.IdCotizacion)
                biMostrar_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox("Error al crear cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try

            Dim frm As New frmComCotizacionSolicitud
            If dgvDatos.RowCount > 0 Then

                frm.state_button = True
                frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
                biActualizar_Click(sender, e)
            Else
                MsgBox("No existen datos, Verifique", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error al mostrsr los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR la cotización N° : " & dgvDatos.CurrentRow.Cells("NumCotizacion").Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim estado_process As Boolean
                estado_process = oCotizacionSolicitudService.Borrar(dgvDatos.CurrentRow.Cells("IdCotizacion").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se eliminó el registro correctamente")
                    biActualizar_Click(sender, e)
                Else
                    MsgBox("Error en el proceso, Comunicarse con el administrador del sistema", MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Try

            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdCotizacion").Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar los Datos : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            biMostrar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub cbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            cbProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            cbProveedor.Enabled = True
            pboxLimpiarProveedor.Enabled = True
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                   biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                   miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Cotización actual."
    End Sub
    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Cotización."
    End Sub
    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Cotización Actual."
    End Sub
    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Cotización Seleccionada."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub

End Class