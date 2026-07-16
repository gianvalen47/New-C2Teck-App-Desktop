Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmPlanillasSueldos

    '===========================Servicios====================================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPlanilla As Integer
    Public iEstado As Integer
    Private dtDatos As New DataTable
    Private dtEstados As New DataTable

    Private DirFileDsctos As String
    Private fileExtDsctos As String

    Private DirFileIng As String
    Private fileExtIng As String

    '==========================Evento Load===================================================
    Private Sub frmPlanillaSueldo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 179)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        txtPeriodo.Value = Today.Year
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtPeriodo.KeyPress _
                      , txtMes.KeyPress _
                      , txtIdPlanilla.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed=============================================
    Private Sub frmComSolicitudGastos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaSueldosService.Close()
            oPlanillaSueldosDetService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmComOrdenesCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Planilla As String)
        If type_process = "update" Or type_process = "insert" Then
            'cmbEstado.Value = ""
            txtIdPlanilla.Text = nro_Planilla
        End If
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
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False            
            biCalcular.Enabled = False
            biCerrar.Enabled = False
            biProcesar.Enabled = False
            biImportarExcelDsctos.Enabled = False
            biImportarExcelIng.Enabled = False
            biExportarPlanilla.Enabled = False
            biGenerarArchivoAfpNet.Enabled = False
            biGenerarArchivoPlame.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miCalcular.Enabled = False
            miCerrar.Enabled = False
            miProcesar.Enabled = False
            miImportarExcelDsctos.Enabled = False
            miImportarExcelIng.Enabled = False
            miExportarPlanilla.Enabled = False
            miEnviarCorreoMasivo.Enabled = False
            miGenerarArchivoAfpNet.Enabled = False
            miGenerarArchivoPlame.Enabled = False
            miCalcularEPS.Enabled = False
        Else
            iEstado = CInt(dgvDatos.CurrentRow.Cells("IdEstado").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado <> 1, False, True)
            biCalcular.Enabled = IIf(iEstado <> 1, False, True)
            biCerrar.Enabled = IIf(iEstado = 1 Or iEstado = 2, True, False)
            biProcesar.Enabled = IIf(iEstado <> 2, False, True)
            biImportarExcelDsctos.Enabled = IIf(iEstado <> 1, False, True)
            biImportarExcelIng.Enabled = IIf(iEstado <> 1, False, True)
            biExportarPlanilla.Enabled = True
            biGenerarArchivoAfpNet.Enabled = True
            biGenerarArchivoPlame.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado <> 1, False, True)
            miCalcular.Enabled = IIf(iEstado <> 1, False, True)
            miCalcularEPS.Enabled = IIf(iEstado <> 1, False, True)
            miCerrar.Enabled = IIf(iEstado = 1 Or iEstado = 2, True, False)
            miProcesar.Enabled = IIf(iEstado <> 2, False, True)
            miImportarExcelDsctos.Enabled = IIf(iEstado <> 1, False, True)
            miImportarExcelIng.Enabled = IIf(iEstado <> 1, False, True)
            miExportarPlanilla.Enabled = True
            miEnviarCorreoMasivo.Enabled = True
            miGenerarArchivoAfpNet.Enabled = True
            miGenerarArchivoPlame.Enabled = True
            miCalcularEPS.Enabled = True
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPlanilla").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmPlanillaSueldo
            Dim Procesado As Boolean
            Procesado = oPlanillaSueldosService.BuscarGenProceso(toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value))
            frm.state_button = True
            frm.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
            frm.editable = IIf(iEstado = 1, True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtIdPlanilla.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdPlanilla)
                Else
                    listaDatos()
                    MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PLANILLA SUELDO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Planilla de Sueldo Nº " & dgvDatos.CurrentRow.Cells("IdPlanilla").Value.ToString & " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdPlanilla").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó correctamente el registro.", MsgBoxStyle.Information)
                Else
                    MsgBox("'¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA PLANILLA SUELDO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmPlanillaSueldo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdPlanilla)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA PLANILLA SUELDO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("!Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("!Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

    Private Sub llenarCombos()
        Try

            '============================= ESTADOS ===============================      
            dtEstados = oPlanillaSueldosService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oPlanillaSueldosService.Filtrar(Session.sCodEmp, txtPeriodo.Value, txtMes.Text, IIf(toBlank(txtIdPlanilla.Text) = "", 0, txtIdPlanilla.Text), toNumber(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.ValueChanged, txtMes.TextChanged, txtIdPlanilla.TextChanged, cmbEstado.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPlanilla").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub biCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biCerrar.Click, miCerrar.Click
        'Try
        'If dgvDatos.RowCount > 0 Then
        '    If MsgBox("¿Está seguro de CERRAR la Planilla de Sueldos N° " & dgvDatos.CurrentRow.Cells("IdPlanilla").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
        '        Dim estado_process As Boolean
        '        estado_process = oPlanillaSueldosService.CerrarPlanilla(toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        '        If estado_process = True Then
        '            MsgBox("Se  Cerró la Planilla de Sueldos correctamente.")
        '            Actualizar()
        '        Else
        '            MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
        '        End If
        '    End If
        'Else
        '    MsgBox("¡No existen datos, Verifique...!")
        'End If
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmPlanillaSueldos_Cierre
                frm.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al CERRAR / REVERTIR el cierre de la Planilla de Sueldo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        'Catch ex As Exception
        '    MsgBox("ERROR AL CERRAR PLANILLA DE SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub biExportarPlanilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biExportarPlanilla.Click, miExportarPlanilla.Click
        Try
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = False Then
                MsgBox("No tienes permiso para descargar datos!!!!!!")
                Return
            End If

            Dim Export As Boolean
            Dim dtExcel As New DataTable
            dtExcel = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), 0, 0, "", 0, 3).Tables(0)
            dgvExportarPlanilla.DataSource = dtExcel
            Export = ExportarExcel(dgvExportarPlanilla)
        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                               biNuevo.MouseLeave, miNuevo.MouseLeave, biMostrar.MouseLeave, miMostrar.MouseLeave,
                               biEliminar.MouseLeave, miEliminar.MouseLeave, biImprimir.MouseLeave, miImprimir.MouseLeave,
                               biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave,
                               biProcesar.MouseLeave, miProcesar.MouseLeave, biCalcular.MouseLeave, miCalcular.MouseLeave,
                               biCerrar.MouseLeave, miCerrar.MouseLeave, miImportarExcelDsctos.MouseLeave, biImportarExcelDsctos.MouseLeave,
                               miImportarExcelIng.MouseLeave, miImportarExcelIng.MouseLeave, biFormatoExcelIng.MouseLeave, miFormatoExcelIng.MouseLeave,
                               miFormatoExcelDsctos.MouseLeave, biFormatoExcelIng.MouseLeave, miExportarPlanilla.MouseLeave, biExportarPlanilla.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Planilla Sueldo."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Planilla Sueldo."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Planilla Sueldo actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Planilla Sueldo actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub ImportarDsctos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImportarExcelDsctos.MouseEnter, miImportarExcelDsctos.MouseEnter
        sslError.Text = "Importar Excel Dsctos a Planilla Sueldo actual."
    End Sub
    Private Sub ImportarIng_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImportarExcelIng.MouseEnter, miImportarExcelIng.MouseEnter
        sslError.Text = "Importar Excel Ingresos a Planilla Sueldo actual."
    End Sub
    Private Sub Exportar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biExportarPlanilla.MouseEnter, miExportarPlanilla.MouseEnter
        sslError.Text = "Exportar Planilla de Sueldos actual a Excel."
    End Sub
    Private Sub FormatoDctos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFormatoExcelDsctos.MouseEnter, biFormatoExcelDsctos.MouseEnter
        sslError.Text = "Formato Excel Descuentos."
    End Sub
    Private Sub FormatoIng_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFormatoExcelIng.MouseEnter, biFormatoExcelIng.MouseEnter
        sslError.Text = "Formato Excel Ingresos."
    End Sub
    Private Sub Procesar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesar.MouseEnter, miProcesar.MouseEnter
        sslError.Text = "Procesar Planilla Sueldo actual."
    End Sub

    Private Sub GenerarArchivoAfpNet_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarArchivoAfpNet.MouseEnter, miGenerarArchivoAfpNet.MouseEnter
        sslError.Text = "Generar Archivo AfpNet"
    End Sub
    Private Sub Calcular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCalcular.MouseEnter, miCalcular.MouseEnter
        sslError.Text = "Calcular Descuentos Planilla Sueldo actual."
    End Sub
    Private Sub Cerrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.MouseEnter, miCerrar.MouseEnter
        sslError.Text = "Cerrar / Revertir Cierre de Planilla Sueldo actual."
    End Sub

    Private Sub mostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim dtSubreporte As DataTable
            Dim reporte As New rpBoletaPago
            Dim reporteCTS As New rpBoletaPagoCTS
            Dim reporteCTSEquimap As New rpBoletaPagoCTSEquimap
            Dim reporteCTSAmazonica As New rpBoletaPagoCTSAmazonica
            Dim registro As New PlanillaSueldosService.PlanillaSueldos
            registro = oPlanillaSueldosService.Obtener(toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value))


            If registro.TipoPlanilla.IdTipo = 8 Then 'CTS
                dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), 0, 0, "", 0, 8).Tables(0)
            Else
                dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), 0, 0, "", 0, 1).Tables(0)
                dtSubreporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value), 0, 0, "", 0, 1).Tables(0)
            End If


            If reporte.Subreports.Count > 0 Then
                reporte.Subreports(0).SetDataSource(dtSubreporte)
            End If

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If registro.TipoPlanilla.IdTipo = 8 Then 'CTS
                    If Session.sCodEmp = "05" Then
                        reporteCTSEquimap.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCTSEquimap
                    ElseIf Session.sCodEmp = "02" Then
                        reporteCTSAmazonica.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCTSAmazonica
                    Else
                        reporteCTS.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCTS
                    End If

                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                End If

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte Boleta de Pago"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        mostrarReporte()
    End Sub

    Private Sub txtMes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMes.Click
        txtMes.SelectAll()
    End Sub

    Private Sub txtMes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtMes.Text)) > 0 Then
                If toNumber(txtMes.Text) < 13 And toNumber(txtMes.Text) > 0 Then
                    Dim cant As Integer = Len(txtMes.Text)
                    If cant < 2 Then
                        txtMes.Text = "0" & txtMes.Text
                    End If
                    txtIdPlanilla.Focus()
                Else
                    MsgBox("Rango de Mes [01 - 12]")
                    txtMes.Focus()
                End If
            End If
            txtIdPlanilla.Focus()
        End If
    End Sub

    Private Sub miProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesar.Click, miProcesar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de PROCESAR la Planilla de Sueldos N° " & dgvDatos.CurrentRow.Cells("IdPlanilla").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPlanillaSueldosService.ProcesarPlanilla(dgvDatos.CurrentRow.Cells("IdPlanilla").Value, Today, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se  Procesó la Planilla de Sueldos correctamente.")
                        Actualizar()
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL PROCESAR PLANILLA DE SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biCalcular.Click, miCalcular.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de CALCULAR DESCUENTOS de la Planilla de Sueldos N° " & dgvDatos.CurrentRow.Cells("IdPlanilla").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPlanillaSueldosService.CalcularDescuentos(dgvDatos.CurrentRow.Cells("IdPlanilla").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se Calculó la Planilla de Sueldos correctamente.")
                        Actualizar()
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CALCULAR PLANILLA DE SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miFormatoExcelDsctos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFormatoExcelDsctos.Click, biFormatoExcelDsctos.Click
        FormatoExcelDsctos()
    End Sub

    Private Sub FormatoExcelDsctos()

        Dim dtExcel As New DataTable("tabla2")

        dtExcel.Columns.Add(New DataColumn("IdPersona", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("ApeNom", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodigoDscto", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Moneda", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("MontoSol", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("MontoDol", Type.GetType("System.Double")))

        If dgvDatos.RowCount > 0 Then
            Dim dtTable As New DataTable
            dtTable = oPlanillaSueldosDetService.Mostrar(toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)).Tables(0)
            For i As Integer = 0 To dtTable.Rows.Count - 1
                dtExcel.Rows.Add(New Object() {toBlank(dtTable.Rows(i).Item(1)), toBlank(dtTable.Rows(i).Item(2)), "", "NS", "0.00", "0.00"})
            Next
        Else
            dtExcel.Rows.Add(New Object() {"", "", "", "NS", "0.00", "0.00"})
        End If

        dgvFormatoExcelDsctos.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcelDsctos)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miFormatoExcelIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFormatoExcelIng.Click, biFormatoExcelIng.Click
        FormatoExcelIng()
    End Sub

    Private Sub FormatoExcelIng()

        Dim dtExcel As New DataTable("tabla2")

        dtExcel.Columns.Add(New DataColumn("IdPersona", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("ApeNom", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodigoIngreso", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Moneda", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("MontoSol", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("MontoDol", Type.GetType("System.Double")))

        If dgvDatos.RowCount > 0 Then
            Dim dtTable As New DataTable
            dtTable = oPlanillaSueldosDetService.Mostrar(toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)).Tables(0)
            For i As Integer = 0 To dtTable.Rows.Count - 1
                dtExcel.Rows.Add(New Object() {toBlank(dtTable.Rows(i).Item(1)), toBlank(dtTable.Rows(i).Item(2)), "", "NS", "0.00", "0.00"})
            Next
        Else
            dtExcel.Rows.Add(New Object() {"", "", "", "NS", "0.00", "0.00"})
        End If

        dgvFormatoExcelIng.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcelIng)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miImportarExcelDsctos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miImportarExcelDsctos.Click, biImportarExcelDsctos.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFileDsctos = OpenFileDialog1.FileName
            CargadoFinalDsctos()
        End If
    End Sub

    Private Sub CargadoFinalDsctos()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            fileExtDsctos = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExtDsctos <> ".xls") And (fileExtDsctos <> ".xlsx") Then
                MsgBox("¡Solo se aceptan archivos de Excel, tenga cuidado...!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrillaDsctos()
            End If
        End If
    End Sub

    Private Function ValidaDolaresSolesDsctos() As Boolean
        Try
            Dim cont As Integer = 0
            For Each fila As DataGridViewRow In dgvImportarExcelDsctos.Rows
                If Convert.ToDouble(fila.Cells("MontoSol").Value) > 0 And Convert.ToDouble(fila.Cells("MontoDol").Value) = 0 Then
                    cont = cont + 1
                ElseIf Convert.ToDouble(fila.Cells("MontoDol").Value) > 0 And Convert.ToDouble(fila.Cells("MontoSol").Value) = 0 Then
                    cont = cont + 1
                End If
            Next
            If cont > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DOLARES Y SOLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub CargarGrillaDsctos()
        Try
            If MsgBox("¿Está seguro de IMPORTAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvImportarExcelDsctos.DataSource = GetDataExcel(DirFileDsctos, fileExtDsctos)
                If ValidaDolaresSolesDsctos() Then
                    Dim estado_process As Boolean

                    If dgvImportarExcelDsctos.RowCount > 0 Then
                        For Each fila As DataGridViewRow In dgvImportarExcelDsctos.Rows
                            If Not (Convert.ToDouble(fila.Cells("MontoSol").Value) = 0 And Convert.ToDouble(fila.Cells("MontoDol").Value) = 0) Then

                                Dim registro As New PlanillaSueldosDetService.PlanillaSueldosDetDescuento
                                Dim PlanillaSueldo As New PlanillaSueldosDetService.PlanillaSueldos
                                Dim Persona As New PlanillaSueldosDetService.Persona
                                Dim PlanillaSueldoDet As New PlanillaSueldosDetService.PlanillaSueldosDet
                                Dim RubroDescuentoPlanilla As New PlanillaSueldosDetService.RubroDescuentoPlanilla
                                Dim Moneda As New PlanillaSueldosDetService.Moneda

                                Persona.IdPer = toNumber(fila.Cells("IdPersona").Value)
                                PlanillaSueldo.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
                                PlanillaSueldoDet.PlanillaSueldos = PlanillaSueldo
                                PlanillaSueldoDet.Persona = Persona
                                registro.PlanillaSueldosDet = PlanillaSueldoDet

                                RubroDescuentoPlanilla.IdRubroDes = toNumber(fila.Cells("CodigoDscto").Value)
                                registro.RubroDescuentoPlanilla = RubroDescuentoPlanilla

                                Moneda.CodMon = Convert.ToString(fila.Cells("Moneda").Value)
                                registro.Moneda = Moneda

                                registro.MontoSol = Convert.ToDouble(fila.Cells("MontoSol").Value)
                                registro.MontoDol = Convert.ToDouble(fila.Cells("MontoDol").Value)

                                registro.CodUsu = Session.sCodUsu
                                registro.DirIp = Session.sDirIp
                                registro.NomPc = Session.sNomPc
                                registro.FecReg = Today

                                estado_process = oPlanillaSueldosDetService.InsertarDescuento(registro)
                            End If
                        Next

                        If estado_process = True Then
                            MsgBox("Se ingresó los detalles correctamente", MsgBoxStyle.Information, "Error de datos")
                            listaDatos()
                        End If
                    Else
                        MsgBox("¡No existen detalles a importar...!", MsgBoxStyle.Information, "Error de datos")
                    End If
                Else
                    MsgBox("¡Debe ingresar monto en soles y dolares en cada detalle!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miImportarExcelIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miImportarExcelIng.Click, biImportarExcelIng.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFileIng = OpenFileDialog1.FileName
            CargadoFinalIng()
        End If
    End Sub

    Private Sub CargadoFinalIng()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            fileExtIng = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExtIng <> ".xls") And (fileExtIng <> ".xlsx") Then
                MsgBox("¡Solo se aceptan archivos de Excel, tenga cuidado...!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrillaIng()
            End If
        End If
    End Sub

    Private Function ValidaDolaresSolesIng() As Boolean
        Try
            Dim cont As Integer = 0
            For Each fila As DataGridViewRow In dgvImportarExcelIng.Rows
                If Convert.ToDouble(fila.Cells("MontoSol").Value) > 0 And Convert.ToDouble(fila.Cells("MontoDol").Value) = 0 Then
                    cont = cont + 1
                ElseIf Convert.ToDouble(fila.Cells("MontoDol").Value) > 0 And Convert.ToDouble(fila.Cells("MontoSol").Value) = 0 Then
                    cont = cont + 1
                End If
            Next
            If cont > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DOLARES Y SOLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub CargarGrillaIng()
        Try
            If MsgBox("¿Está seguro de IMPORTAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvImportarExcelIng.DataSource = GetDataExcel(DirFileIng, fileExtIng)
                If ValidaDolaresSolesIng() Then
                    Dim estado_process As Boolean

                    If dgvImportarExcelIng.RowCount > 0 Then
                        For Each fila As DataGridViewRow In dgvImportarExcelIng.Rows
                            If Not (Convert.ToDouble(fila.Cells("MontoSol").Value) = 0 And Convert.ToDouble(fila.Cells("MontoDol").Value) = 0) Then

                                Dim registro As New PlanillaSueldosDetService.PlanillaSueldosDetIngreso
                                Dim PlanillaSueldo As New PlanillaSueldosDetService.PlanillaSueldos
                                Dim Persona As New PlanillaSueldosDetService.Persona
                                Dim PlanillaSueldoDet As New PlanillaSueldosDetService.PlanillaSueldosDet
                                Dim RubroIngresoPlanilla As New PlanillaSueldosDetService.RubroIngresoPlanilla
                                Dim Moneda As New PlanillaSueldosDetService.Moneda

                                Persona.IdPer = toNumber(fila.Cells("IdPersona").Value)
                                PlanillaSueldo.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
                                PlanillaSueldoDet.PlanillaSueldos = PlanillaSueldo
                                PlanillaSueldoDet.Persona = Persona
                                registro.PlanillaSueldosDet = PlanillaSueldoDet

                                RubroIngresoPlanilla.IdRubroIng = toNumber(fila.Cells("CodigoIngreso").Value)
                                registro.RubroIngresoPlanilla = RubroIngresoPlanilla

                                Moneda.CodMon = Convert.ToString(fila.Cells("Moneda").Value)
                                registro.Moneda = Moneda

                                registro.MontoSol = Convert.ToDouble(fila.Cells("MontoSol").Value)
                                registro.MontoDol = Convert.ToDouble(fila.Cells("MontoDol").Value)

                                registro.CodUsu = Session.sCodUsu
                                registro.DirIp = Session.sDirIp
                                registro.NomPc = Session.sNomPc
                                registro.FecReg = Today

                                estado_process = oPlanillaSueldosDetService.InsertarIngreso(registro)
                            End If
                        Next

                        If estado_process = True Then
                            MsgBox("Se ingresó los detalles correctamente", MsgBoxStyle.Information, "Error de datos")
                            listaDatos()
                        End If
                    Else
                        MsgBox("¡No existen detalles a importar...!", MsgBoxStyle.Information, "Error de datos")
                    End If
                Else
                    MsgBox("¡Debe ingresar monto en soles y dolares en cada detalle!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerarArchivo_Click(sender As Object, e As EventArgs) Handles biGenerarArchivo.Click
        Try
            Dim frm As New frmPlanillaSueldos_GenerarArchivo
            frm.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPlanilla)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEnviarCorreoMasivo_Click(sender As Object, e As EventArgs) Handles miEnviarCorreoMasivo.Click
        Try
            If dgvDatos.RowCount() > 0 Then
                Dim frm As New frmPlanillaSueldoEnviarCorreoMasivo
                frm.idPlanilla = dgvDatos.CurrentRow.Cells("IdPlanilla").Value
                frm.periodo = dgvDatos.CurrentRow.Cells("Periodo").Value
                frm.mes = dgvDatos.CurrentRow.Cells("Mes").Value

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    MsgBox("Se envio las boletas de pago masivamente por correo Exitosamente", MsgBoxStyle.Information, "Exito")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miGenerarArchivo_Click(sender As Object, e As EventArgs) Handles miGenerarArchivoAfpNet.Click, biGenerarArchivoAfpNet.Click

        Try
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = False Then
                MsgBox("No tienes permiso para descargar datos!!!!!!")
                Return
            End If

            Dim Export As Boolean

            Dim dtExcel As New DataTable
            dtExcel = oPlanillaSueldosService.GenerarArchivoAfpNet(Session.sCodEmp, toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)).Tables(0)
            dgvGenerarAfpNet.DataSource = dtExcel
            Export = ExportarExcelSinCabecera(dgvGenerarAfpNet)

        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGenerarArchivoPlame_Click(sender As Object, e As EventArgs) Handles biGenerarArchivoPlame.Click, miGenerarArchivoPlame.Click

        Try
            If dgvDatos.RowCount() > 0 Then
                Dim frm As New frmPlanillaSueldos_GenerarArchivoPlame
                frm.idPlanilla = dgvDatos.CurrentRow.Cells("IdPlanilla").Value
                frm.periodo = dgvDatos.CurrentRow.Cells("Periodo").Value
                frm.Mes = dgvDatos.CurrentRow.Cells("Mes").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    MsgBox("Se Genero el Archivo Plame Exitosamente", MsgBoxStyle.Information, "Exito")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miCalcularEPS_Click(sender As Object, e As EventArgs) Handles miCalcularEPS.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de CALCULAR EPS de la Planilla de Sueldos N° " & dgvDatos.CurrentRow.Cells("IdPlanilla").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPlanillaSueldosService.CalcularEPS(dgvDatos.CurrentRow.Cells("IdPlanilla").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se Calculó la EPS de la Planilla de Sueldos correctamente.")
                        Actualizar()
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el are de TI...!")
                    End If
                End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CALCULAR EPS PLANILLA DE SUELDOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class