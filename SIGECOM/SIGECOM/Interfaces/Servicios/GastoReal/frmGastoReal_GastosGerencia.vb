Imports System.ServiceModel

Public Class frmGastoReal_GastosGerencia

    Private oJobService As New JobService.JobServiceClient
    Private oGastoReal As New GastoRealService.GastoRealServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    'Public CodJob As String

    Private Sub frmGastoReal_GastosGerencia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oGastoReal.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oGastoReal.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oGastoReal.Abort()
        End Try
    End Sub

    Private Sub frmGastoReal_GastosGerencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoReal_GastosGerencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'txtNumJob.Text = CodJob
        txtNumJob.Text = ""
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmGastoReal_GastoGerencia
                frm.state_button = False
                'frm.IdGasto = IdGasto
                'frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", 1))
                'frm.IdPersonaSolicita = IdPersonaSolicita

                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    'ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdGastoGer)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdGastoGer").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            If dgvDatos.CurrentRow.Cells("Procesado").Value = True Then
                MsgBox("Este gasto ya ha sido Procesado, tenga cuidado.", MsgBoxStyle.Information, "Información")
            Else
                If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oGastoReal.BorrarGastoGerencia(toNumber(dgvDatos.CurrentRow.Cells("IdGastoGer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        'ObtenerRegistro()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                Else
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biProcesarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesarJob.Click, miProcesar.Click

        Try
            If dgvDatos.CurrentRow.Cells("Procesado").Value = True Then
                MsgBox("Este gasto ya ha sido Procesado, tenga cuidado.", MsgBoxStyle.Information, "Información")
            Else
                If MsgBox("¿Está seguro de PROCESAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oGastoReal.Procesar(toNumber(dgvDatos.CurrentRow.Cells("IdGastoGer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        'ObtenerRegistro()
                        MsgBox("Se proceso el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                Else
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL PROCESAR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click

        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdGastoGer").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
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

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmGastoReal_GastoGerencia
            frm.state_button = True
            frm.IdGastoGer = dgvDatos.CurrentRow.Cells("IdGastoGer").Text
            frm.Procesado = dgvDatos.CurrentRow.Cells("Procesado").Value
            'frm.IdGasto = IdGasto
            'frm.estado = oSolicitudGastoService.ObtenerEstado(IdGasto)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                'ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdGastoGer)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdGastoGer)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oGastoReal.FiltrarGastoGerencia(txtNumJob.Text).Tables(0)
            dgvDatos.DataSource = dtDatos
            'DataGridView1.DataSource = dtDatos
            'sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biNuevo.Enabled = True
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biProcesarJob.Enabled = False
            biImprimir.Enabled = False

            miNuevo.Enabled = True
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miProcesar.Enabled = False

        Else
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(dgvDatos.CurrentRow.Cells("Procesado").Value, False, True)
            biProcesarJob.Enabled = IIf(dgvDatos.CurrentRow.Cells("Procesado").Value, False, True)
            biImprimir.Enabled = True

            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(dgvDatos.CurrentRow.Cells("Procesado").Value, False, True)
            miProcesar.Enabled = IIf(dgvDatos.CurrentRow.Cells("Procesado").Value, False, True)


        End If

    End Sub

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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumJob.TextChanged
        listaDatos()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            listaDatos()
        End If
    End Sub

    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Gasto Gerencia"
    End Sub

    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter
        sslError.Text = "Mostrar Gasto Gerencia"
    End Sub

    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter
        sslError.Text = "Eliminar Gasto Gerencia"
    End Sub

    Private Sub biProcesarJob_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesarJob.MouseEnter
        sslError.Text = "Procesar Gasto Gerencia"
    End Sub

    Private Sub biActualizar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub

    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            biNuevo.MouseLeave, biMostrar.MouseLeave, _
                          biActualizar.MouseLeave, biSalir.MouseLeave, _
                           miNuevo.MouseLeave, miMostrar.MouseLeave, _
                          miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptGastoRealGerencia
            Dim dtCheck As DataTable

            Dim dtDatosListado As DataTable

            dtDatosListado = oGastoReal.FiltrarGastoGerencia(utils.toBlank(txtNumJob.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos


            dtCheck = dtDatos.Copy
            dtCheck.Clear()

            Dim nuevorow As DataRow

            Dim rows() As Janus.Windows.GridEX.GridEXRow
            'Dim Cadena As String = ""

            rows = dgvDatos.GetCheckedRows()

            Dim row As Janus.Windows.GridEX.GridEXRow

            If rows.Count <> 0 Then

                For Each row In rows

                    nuevorow = dtCheck.NewRow

                    nuevorow(0) = row.Cells("CodEmp").Text
                    nuevorow(1) = row.Cells("DesEmp").Text
                    nuevorow(2) = row.Cells("RucEmp").Text
                    nuevorow(3) = row.Cells("IdGastoGer").Text
                    nuevorow(4) = row.Cells("CodJob").Text
                    nuevorow(5) = row.Cells("CodRubro").Text
                    nuevorow(6) = row.Cells("DesRubro").Text
                    nuevorow(7) = row.Cells("CodSubRubro").Text
                    nuevorow(8) = row.Cells("DesSubRubro").Text
                    nuevorow(9) = row.Cells("CodMon").Text
                    nuevorow(10) = row.Cells("AbrMon").Text
                    nuevorow(11) = row.Cells("Observacion").Text
                    nuevorow(12) = CDec(row.Cells("Monto").Text)
                    nuevorow(13) = CBool(row.Cells("Procesado").Text)

                    dtCheck.Rows.Add(nuevorow)

                Next

                reporte.SetDataSource(dtCheck)
                forma.crvReportes.ReportSource = reporte
                'Validar por usuario - Exportar Excel 
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("pCodJob", IIf(txtNumJob.Text = "", "(Todos)", txtNumJob.Text))
                forma.Text = "Listado de Gasto Real Gerencia"
                forma.ShowDialog()

            Else
                MsgBox("Debe seleccionar alguno de los Gastos Gerencia")
            End If

           
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
End Class