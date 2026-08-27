Imports System.ServiceModel

Public Class frmActividades_Nuevo

    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdActividad As Integer

    Private dtDatos As DataTable

    Private Sub frmActividades_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmActividades_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActividades_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        If state_button Then    'Modificar 
            ObtenerRegistro()
            listaDatos()
            Desactivar()
            gbDetalle.Visible = True
            Me.Text = "Actividad"
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(714, 183)
            gbDetalle.Visible = False
            Me.Text = "Registrar Nueva Actividad"
            Activar()
            txtDesActividad.Focus()
        End If

    End Sub

    Private Sub listaDatos()

        dtDatos = oIndicadoresServicioService.MostrarActividadDet(IdActividad).tables(0)
        dgvDatos.DataSource = dtDatos

    End Sub


    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(1).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdActividadDet").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdActividadDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As IndicadoresServicioService.ActividadServicio
            registro = oIndicadoresServicioService.ObtenerActividad(IdActividad)
            txtDesActividad.Text = registro.DesActividad
            'Me.Text = "Actividad Nº " + registro.IdActividad.ToString

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesActividad.Text) = "" Then
                MsgBox("Debe ingresar la Actividad.", MsgBoxStyle.Information, "Información")
                txtDesActividad.BackColor = Color.Red
                txtDesActividad.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Desactivar()
        biGuardar.Enabled = False
        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        txtDesActividad.ReadOnly = True
        txtDesActividad.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Activar()
        biGuardar.Enabled = True
        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        txtDesActividad.ReadOnly = False
        txtDesActividad.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmActividades_NuevoDetalle
            frm.state_button = False
            frm.IdActividad = IdActividad

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdActividadDet)
                    NuevoDetalle()
                End If
            Else

            End If

        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Sub Actividad?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oIndicadoresServicioService.BorrarActividadDet(toNumber(dgvDatos.CurrentRow.Cells("IdActividadDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdActividad").Text))
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmActividades_NuevoDetalle
            frm.state_button = True
            frm.IdActividadDet = dgvDatos.CurrentRow.Cells("IdActividadDet").Text
            frm.IdActividad = IdActividad
            
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdActividadDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdActividadDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.ActividadServicio)
        Try
            Dim estado_process As Integer
            estado_process = oIndicadoresServicioService.InsertarActividad(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdActividad = estado_process
                MsgBox("Se insertó la Actividad correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As IndicadoresServicioService.ActividadServicio)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarActividad(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Actividad correctamente")
                Desactivar()
                ObtenerRegistro()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                txtDesActividad.Focus()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New IndicadoresServicioService.ActividadServicio

                registro.IdActividad = IdActividad
                registro.DesActividad = txtDesActividad.Text

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    'estado.IdEstado = 1
                    'registro.EstadoSolicitudGasto = estado
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        Activar()
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then
                If MsgBox("¿Está seguro de ELIMINAR la Sub Actividad?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oIndicadoresServicioService.BorrarActividadDet(dgvDatos.CurrentRow.Cells("IdActividadDet").Value, IdActividad)
                    If estado_process Then
                        'MsgBox("Se elimino correctamente el registro ")
                        listaDatos()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                    End If
                    listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar el Detalle" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrarDetalle()
                e.Handled = True
            End If
        End If
    End Sub
End Class