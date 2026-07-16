Imports System.ServiceModel

Public Class FrmActividades

    'Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient    

    Private dtTipoMantenimiento As DataTable
    Private dtDatos As DataTable

    Private Sub EnableOptions()
        Try
            If dgvDatos.RowCount > 0 Then
                miMostrar.Enabled = True
                miEliminar.Enabled = True

                biMostrar.Enabled = True
                biEliminar.Enabled = True
            Else
                miMostrar.Enabled = False
                miEliminar.Enabled = False

                biMostrar.Enabled = False
                biEliminar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.MostrarActividad.Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub FrmActividades_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub FrmActividades_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub FrmActividades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 183)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdActividad").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmActividades_Nuevo
            'Dim lEstado As String
            'lEstado = dgvDatos.CurrentRow.Cells("DesEstado").Text
            frm.state_button = True
            frm.IdActividad = dgvDatos.CurrentRow.Cells("IdActividad").Text
            'frm.editable = IIf(lEstado = "Generado", True, False)
            'frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdActividad)
                    Mostrar()
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR esta Actividad?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oIndicadoresServicioService.BorrarActividad(CInt(dgvDatos.CurrentRow.Cells("IdActividad").Text))
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA ACTIVIDAD:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            Mostrar()
        End If
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmActividades_Nuevo
            frm.state_button = False
            'frm.txtNumActividad.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("IdActividad").Text) + 1

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdActividad)
                    Mostrar()
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdActividad").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Mostrar()
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdActividad").Value
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave

        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Actividad."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Actividad."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Actividad."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Actividad."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
End Class