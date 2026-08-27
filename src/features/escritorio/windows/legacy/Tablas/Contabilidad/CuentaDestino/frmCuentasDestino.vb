Imports System.ServiceModel
Public Class frmCuentasDestino

    '===========================Servicios====================================================
    Dim oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Private CodCuenta As String


    Private Sub frmCuentasDestino_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 193)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ListaDatos()

        txtCodCuenta.Focus()
    End Sub

    Private Sub Finalizar()
        Try
            oCuentaContableService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmMantCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub txtCodCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            dgvDatos.Select()
        End If
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oCuentaContableService.FiltrarCuentaDestino(Session.sCodEmp, txtCodCuenta.Text).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try       
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCodCuenta.TextChanged
        ListaDatos()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount > 0 Then
            miEliminar.Enabled = True
            miMostrar.Enabled = True
        Else
            miEliminar.Enabled = False
            miMostrar.Enabled = False
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal IdCuenta As String, ByVal IdCuentaDest As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCuenta").Value) = IdCuenta And CInt(row.Cells("IdCuentaDest").Value) = IdCuentaDest Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmCuentaDestino
                frm.state_button = False
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ListaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdCuenta, frm.IdCuentaDest)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA CUENTA DESTINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmCuentaDestino
            frm.state_button = True
            frm.IdCuenta = dgvDatos.CurrentRow.Cells("IdCuenta").Text
            frm.IdCuentaDest = dgvDatos.CurrentRow.Cells("IdCuentaDest").Text
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCuenta, frm.IdCuentaDest)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdCuenta, frm.IdCuentaDest)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CUENTA DESTINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro Seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCuentaContableService.BorrarCuentaDestino(toNumber(dgvDatos.CurrentRow.Cells("IdCuenta").Text), toNumber(dgvDatos.CurrentRow.Cells("IdCuentaDest").Text))
                If estado_process = True Then
                    dtDatos = Nothing
                    ListaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CUENTA DESTINO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim idcuenta As String = ""
            Dim idcuentadest As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    idcuenta = dgvDatos.CurrentRow.Cells("IdCuenta").Text
                    idcuentadest = dgvDatos.CurrentRow.Cells("IdCuentaDest").Text
                End If
            End If
            dtDatos = Nothing
            ListaDatos()
            If dgvDatos.RowCount > 0 And idcuenta.Trim.Length > 0 And idcuentadest.Trim.Length > 0 Then
                RowPossesion(dgvDatos, idcuenta, idcuentadest)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR CUENTAS DESTINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click, biNuevo.Click
        Nuevo()
    End Sub

    Private Sub miMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick, biMostrar.Click
        mostrar()
    End Sub

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click, biEliminar.Click
        eliminar()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSalir.Click, biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()        
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                                   biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                                   biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Cuentas Destino."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Cuenta Destino."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Cuenta Destino actual."
    End Sub 
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Cuenta Destino actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
End Class