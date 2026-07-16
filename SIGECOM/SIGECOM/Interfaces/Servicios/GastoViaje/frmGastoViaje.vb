Imports System.ServiceModel
Public Class frmGastoViaje
    Private oPreGastoRealService As New PreGastoRealService.PreGastoRealServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtOficinas As DataTable
    Private dtEstados As DataTable
    Private dtTipo As DataTable
    Public IdPersona As Integer
    Public IdPreGastoReal As Integer

    Private Sub frmGastoViaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPreGastoRealService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPreGastoRealService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPreGastoRealService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmGastoViaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoViaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        txtSolicitante.Text = usuario.Persona.ApeNom
        btnBuscarPersona.Enabled = IIf(Not (Session.CodPerfil = "23"), True, False)
        llenarCombos()
        listaDatos()
        dgvDatos.Select()
        EnableOptions()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ' chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        If dgvDatos.RowCount < 1 Then
            biGenerar.Enabled = False
            biEliminar.Enabled = False
            biAprobar.Enabled = False
            miGenerar.Enabled = False
            miEliminar.Enabled = False
            miAprobar.Enabled = False
        Else
            biGenerar.Enabled = IIf(oPreGastoRealService.BuscarGasto(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value), False, True)
            miGenerar.Enabled = IIf(oPreGastoRealService.BuscarGasto(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value), False, True)
            biEliminar.Enabled = IIf(dgvDatos.CurrentRow.Cells("IdEstado").Value <> 0, False, True)
            miEliminar.Enabled = IIf(dgvDatos.CurrentRow.Cells("IdEstado").Value <> 0, False, True)
            biAprobar.Enabled = IIf(dgvDatos.CurrentRow.Cells("IdEstado").Value = 0 Or dgvDatos.CurrentRow.Cells("IdEstado").Value = 1 Or dgvDatos.CurrentRow.Cells("IdEstado").Value = 2, True, False)
            miAprobar.Enabled = IIf(dgvDatos.CurrentRow.Cells("IdEstado").Value = 0 Or dgvDatos.CurrentRow.Cells("IdEstado").Value = 1 Or dgvDatos.CurrentRow.Cells("IdEstado").Value = 2, True, False)
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPreGastoRealService.Filtrar(CStr(cmbOficinas.Value), utils.toNumber(cmbTipo.Value), txtNumJob.Text, IdPersona, utils.toNumber(cmbEstados.Value)).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
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
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub llenarcombos()
        Try

            '===============================Oficinas====================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '============================ Tipo Job ======================================
            dtTipo = oJobService.MostrarTipo.Tables(0)
            cmbTipo.DataSource = dtTipo
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing

            '============================ Estado Job ====================================
            dtEstados = oPreGastoRealService.MostrarEstados
            cmbEstados.DataSource = dtEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstados.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("Error al llenar los combos" + ex.Message)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPreGastoReal").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "PDF" Then
                Imprimir()
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        Mostrar()
        dgvDatos.Select()
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then               
                Dim frm As New frmGastoViaje_Nuevo
                Dim lEstado As String
                lEstado = dgvDatos.CurrentRow.Cells("AbrEstado").Text
                frm.IdPreGastoReal = CInt(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value)
                frm.state_button = True
                frm.editable = IIf(lEstado = "REG", True, False)
                frm.edicion = False
                frm.ShowDialog()
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPreGastoReal)
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbOficinas.ValueChanged, cmbTipo.TextChanged, cmbEstados.ValueChanged, txtSolicitante.TextChanged, txtNumJob.TextChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim frm As New frmGastoViaje_Nuevo
        frm.IdPreGastoReal = 0
        frm.state_button = False
        frm.edicion = True
        frm.editable = True
        If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            IdPreGastoReal = frm.IdPreGastoReal
            Remostrar()
            RowPossesion(dgvDatos, frm.IdPreGastoReal)
        End If
        RowPossesion(dgvDatos, frm.IdPreGastoReal)
        listaDatos()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ELIMINAR el Gasto de Viaje N° " & dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPreGastoRealService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se eliminó el Gasto de Viaje correctamente ")
                        listaDatos()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If oPreGastoRealService.Estado(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value) = 3 Then
                    MsgBox("No se puede volver a APROBAR en este Estado")
                Else
                    If MsgBox("¿Está seguro de APROBAR el Gasto de Viaje N° " & dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean
                        estado_process = oPreGastoRealService.Aprobar(CInt(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se Aprobó el Gasto de Viaje correctamente")
                            biActualizar_Click(sender, e)
                        Else
                            MsgBox("Error en el proceso,comuniquese con el departamento de TI")

                        End If
                    End If
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Remostrar()

        Dim frm As New frmGastoViaje_Nuevo
        frm.IdPreGastoReal = IdPreGastoReal
        frm.state_button = True
        frm.ShowDialog()

    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Imprimir()

    End Sub

    Private Sub Imprimir()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptGastoViajeDetalle
            If dgvDatos.RowCount > 0 Then
                dtReporte = oPreGastoRealService.Imprimir(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value).Tables(0)
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                'Validar por usuario - Exportar Excel 
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("pIdPreGastoReal", dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value)
                forma.Text = "Reporte de Gasto de Viaje"
                forma.ShowDialog()
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try        
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        EnableOptions()
    End Sub

    Private Sub biGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                cmbOpciones.Visible = False
                If MsgBox("¿Está seguro de GENERAR la Solicitud de Gastos del Gasto de Viaje Nº " + dgvDatos.CurrentRow.Cells("IdPreGastoReal").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Integer = 0
                    estado_process = oPreGastoRealService.GenerarSolicitudGasto(CInt(dgvDatos.CurrentRow.Cells("IdPreGastoReal").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process <> 0 Then
                        biActualizar_Click(sender, e)
                        MsgBox("Se genero la Solicitud de Gastos Nro " + estado_process.ToString, MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If            
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR SOLICITUD DE GASTOS:" + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub biVerEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmGastoViaje_Estados
                frm.IdPreGastoReal = dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value
                frm.Text = "Estados del Gasto de Viaje Nº " & dgvDatos.CurrentRow.Cells("IdPreGastoReal").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biNuevo.MouseLeave, biMostrar.MouseLeave, _
                               biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                               miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                               miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                               biVerEstados.MouseLeave, miVerEstados.MouseLeave, miAprobar.MouseLeave, _
                               biAprobar.MouseLeave, biGenerar.MouseLeave, miGenerar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Gasto de Viaje actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Gasto de Viaje."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Gasto de Viaje actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Gasto de Viaje actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Generar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Generar Solicitud de Gastos."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar Gasto de Viaje."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados de Gasto de Viaje actual."
    End Sub
End Class