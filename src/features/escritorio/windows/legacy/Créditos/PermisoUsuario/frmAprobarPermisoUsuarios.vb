
Imports System.ServiceModel

Public Class frmAprobarPermisoUsuarios

    Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable

    Private Sub frmAprobarPermisoUsuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oSeguridadService.Close()
            oAprobarVentaService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
            oAprobarVentaService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
            oAprobarVentaService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub


    Private Sub frmAprobarPermisoUsuarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmAprobarPermisoUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 128)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Dim Fecha As Date

        Fecha = Today

        cbFecInicio.Value = DateSerial(Year(Fecha), Month(Fecha) + 0, 1)
        cbFecFinal.Value = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)

        listaDatos()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdAutorizar").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            dtDatos = oAprobarVentaService.FiltrarAutorizacion(txtUsuario.Text, cbFecInicio.Value, cbFecFinal.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmAprobarPermisoUsuario
                frm.IdAutorizar = dgvDatos.CurrentRow.Cells("IdAutorizar").Text
                frm.state_button = True

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            Else
                MsgBox("No existen datos para mostrar, verifique", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error al mostrar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmAprobarPermisoUsuario

            frm.state_button = False

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.IdAutorizar)
            End If
        Catch ex As Exception
            MsgBox("Error al crear registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtUsuario.TextChanged, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged
        listaDatos()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click

        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdAutorizar").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    
    Private Sub btnBuscarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarUsuario.Click
        Try
            Dim frm As New frmBuscarUsuario
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtUsuario.Text = frm.CodUsuario
                cbFecInicio.Focus()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar usuario", MsgBoxStyle.Information)
        End Try
    End Sub

    
End Class