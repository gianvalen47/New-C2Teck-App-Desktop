Imports System.ServiceModel

Public Class frmProgramacionJob

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtTiposMotores As DataTable
    Private dtUbicacion As DataTable
    Private dtTipoMantenimiento As DataTable
    Private dtAnios As DataTable
    Private dtDatos As DataTable

    Private Sub frmProgramacionJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oIndicadoresServicioService.Close()
            oTipoMotorService.Close()
            oJobService.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            oTipoMotorService.Abort()
            oJobService.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            oTipoMotorService.Abort()
            oJobService.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmProgramacionJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProgramacionJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 185)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        LlenarCombos()
        cmbAno.Value = Today.Year
        listaDatos()
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvDatos.RowCount > 0 Then
                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True
                miGenerarFechas.Enabled = True

                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = True
                biGenerarFechas.Enabled = True
            Else
                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miGenerarFechas.Enabled = False

                biImprimir.Enabled = False
                biMostrar.Enabled = False
                biEliminar.Enabled = False
                biGenerarFechas.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABLITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.FiltrarProgramacion(cmbAno.Value, txtNumJob.Text.Trim, utils.toBlank(cmbMantenimiento.Value), utils.toBlank(cmbUbicacion.Value), IIf(cmbTipMot.Text = "(Todos)", "", utils.toBlank(cmbTipMot.Value))).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LlenarCombos()
        Try

            '-----------------------------Años-----------------------
            dtAnios = oJobService.MostrarAnios.Tables(0)
            cmbAno.DataSource = dtAnios
            cmbAno.DropDownList.DataMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.DisplayMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.ValueMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.Columns(0).DataMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.Columns(1).DataMember = dtAnios.Columns("Anio").ToString
            cmbAno.SelectedIndex = 0

            '======================================= TIPO MANTENIMIENTO ================================================
            dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            '======================================= TIPOS DE MOTORES =========================================
            dtTiposMotores = oTipoMotorService.Mostrar.Tables(0)
            dtTiposMotores.Rows.InsertAt(getRowMotores(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            dtTiposMotores = Nothing

            '======================================= Ubicacion =======================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowMotores(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Function getRowTodos(ByVal data As DataTable)
        'Dim fila As DataRow = data.NewRow
        'Try
        '    fila(0) = ""
        'Catch ex As Exception
        'End Try
        'Try
        '    fila(1) = "(Todos)"
        'Catch ex As Exception
        'End Try
        'Return fila

        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(6) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(7) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(8) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(9) = "(Todos)"
        Catch ex As Exception

        End Try

        Try
            fila(10) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(11) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(12) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(13) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(14) = "(Todos)"
        Catch ex As Exception
        End Try

        Return fila
    End Function

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbMantenimiento.Focus()
                End If
            Else
                cmbMantenimiento.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbMantenimiento.ValueChanged, cmbTipMot.ValueChanged, cmbUbicacion.ValueChanged, txtNumJob.TextChanged, cmbAno.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmProgramacionJob_Detalle
            frm.state_button = False
            frm.edicion = True
            'frm.editable = True
            'frm.txtNumActividad.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("IdActividad").Text) + 1

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdProgramacion)
                    Mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA PROGRAMACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdProgramacion").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Mostrar()
        End If
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmProgramacionJob_Detalle
            frm.state_button = True
            frm.edicion = False
            frm.IdProgramacion = dgvDatos.CurrentRow.Cells("IdProgramacion").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdProgramacion)
                    Mostrar()
                Else
                    'listaDatos()
                    'MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PROGRAMACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
        End If
    End Sub

    Private Sub Eliminar()
        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Programación? ", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oIndicadoresServicioService.BorrarProgramacion(dgvDatos.CurrentRow.Cells("IdProgramacion").Text.ToString)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA PROGRAMACIÓN" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Public Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdProgramacion").Value
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
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

    'Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
    '    sslError.Text = "Imprimir Actividad."
    'End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter
        sslError.Text = "Crear Nueva Programación"
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter
        sslError.Text = "Mostrar Programación"
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter
        sslError.Text = "Eliminar Programación"
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmProgramacionJob_Imprimir
                frm.IdProgramacion = dgvDatos.CurrentRow.Cells("IdProgramacion").Value
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        'Try
        '    Dim forma As New frmReportes
        '    Dim dtReporte As New DataTable
        '    Dim reporte As New rptProgramacionJob

        '    If dgvDatos.RowCount > 0 Then
        '        dtReporte = oIndicadoresServicioService.ImprimirProgramacion(dgvDatos.CurrentRow.Cells("IdProgramacion").Text).Tables(0)
        '        'DataGridView1.DataSource = dtReporte
        '        If dtReporte.Rows.Count = 0 Then
        '            MsgBox("No hay datos a mostrar")
        '        Else
        '            reporte.SetDataSource(dtReporte)
        '            forma.crvReportes.ReportSource = reporte
        '            forma.crvReportes.DisplayGroupTree = False
        '            forma.Text = "Reporte de Programacion Job"
        '            forma.ShowDialog()
        '        End If
        '    Else
        '        MsgBox("¡No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub biGenerarFechas_Click(sender As Object, e As System.EventArgs) Handles biGenerarFechas.Click, miGenerarFechas.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Está seguro de Generar las Fechas de la Programación de la OT Nº " + dgvDatos.CurrentRow.Cells("CodJob").Text.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oIndicadoresServicioService.GenerarFechasProgramacion(toNumber(dgvDatos.CurrentRow.Cells("IdProgramacion").Value))
                    If estado_process Then
                        MsgBox("Se Generó las Fechas correctamente.")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI.")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [CHEQUEAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class