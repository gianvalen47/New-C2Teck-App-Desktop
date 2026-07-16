Imports System.ServiceModel
Public Class frmArqueoCaja

    '===========================Servicios====================================================
    Private oArqueoCajaService As New ArqueoCajaService.ArqueoCajaServiceClient
    Private oArqueoCajaDetService As New ArqueoCajaDetService.ArqueoCajaDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean    
    Private iEstado As String
    Private dtEstados As DataTable
    Private dtUbicacion As DataTable
    Private dtMeses As DataTable
    Private dtDatos As New DataTable

    '==========================Evento Load===================================================
    Private Sub frmArqueoCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 144)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        ObtenerUbicacion()
        txtAnio.Value = Today.Year
        cmbMes.Value = Today.Month
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbUbicacion.KeyPress _
                            , txtAnio.KeyPress _
                            , cmbMes.KeyPress _
                            , cmbEstado.KeyPress
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
    Private Sub frmArqueoCaja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oArqueoCajaService.Close()
            oMaestroService.Close()
            oProvisionalService.Close()
            oArqueoCajaDetService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oArqueoCajaService.Abort()
            oMaestroService.Abort()
            oProvisionalService.Abort()
            oArqueoCajaDetService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oArqueoCajaService.Abort()
            oMaestroService.Abort()
            oProvisionalService.Abort()
            oArqueoCajaDetService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmArqueoCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            'biGenerar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            'miIngresar.Enabled=False

        Else
            iEstado = oArqueoCajaService.ObtenerEstado(dgvDatos.CurrentRow.Cells("IdArqueo").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = "GN", True, False)
            ' biGenerar.Enabled = IIf(iEstado = "GN", True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = "GN", True, False)
            'miIngresar.Enabled = IIf(iEstado = "GN", True, False)
        End If
    End Sub

    Private Sub ObtenerUbicacion()
        If oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Then
            cmbUbicacion.Value = oProvisionalService.ObtenerIdUbicacion(Session.sCodUsu, Session.sCodEmp)
            cmbUbicacion.Enabled = False
        Else
            cmbUbicacion.SelectedIndex = 0
            cmbUbicacion.Enabled = True
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdArqueo").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal IdProvisional As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmArqueoCaja_Nuevo
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdArqueo = dgvDatos.CurrentRow.Cells("IdArqueo").Value
            frm.editable = IIf(lEstado = "GENERADO", True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtIdArqueo.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdArqueo)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL ARQUEO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Arqueo de Caja Nº " + dgvDatos.CurrentRow.Cells("IdArqueo").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oArqueoCajaService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdArqueo").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL ARQUEO DE CAJA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmArqueoCaja_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    cmbUbicacion.Value = frm.iUbicacion
                    RowPossesion(dgvDatos, frm.IdArqueo)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try          

            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            '======================================= UBICACION ===============================================
            dtUbicacion = oProvisionalService.MostrarUbicacionCaja(Session.sCodEmp).Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oArqueoCajaService.MostrarEstados()
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
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
                dtDatos = oArqueoCajaService.Filtrar(Session.sCodEmp, cmbUbicacion.Value, toNumber(txtAnio.Value), cmbMes.Value, cmbEstado.Value).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbUbicacion.ValueChanged, txtAnio.ValueChanged, cmbMes.ValueChanged, cmbEstado.ValueChanged
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
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdArqueo").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
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

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Arqueo de Caja actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Arqueo de Caja."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Arqueo de Caja actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Arqueo de Caja actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Generar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter
        sslError.Text = "Ingresar Plantilla al Arqueo Actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        'dtDatos = oArqueoCajaService.Imprimir(dgvDatos.CurrentRow.Cells("IdArqueo").Value).Tables(0)
        'DataGridView1.DataSource = dtDatos
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()        
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptArqueoCaja_Detalle
            If dgvDatos.RowCount > 0 Then
                dtReporte = oArqueoCajaService.Imprimir(dgvDatos.CurrentRow.Cells("IdArqueo").Value).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False                    
                    forma.Text = "Impresión de Arqueo de Caja Nº" + dgvDatos.CurrentRow.Cells("IdArqueo").Text
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try        
    End Sub

    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click
        'Try
        '    If dgvDatos.RowCount > 0 Then
        '        If MsgBox("¿Estas seguro de INGRESAR los Detalles al Arqueo N° " & dgvDatos.CurrentRow.Cells("IdArqueo").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
        '            Dim estado_process As Boolean
        '            estado_process = oArqueoCajaDetService.InsertarPlantilla(dgvDatos.CurrentRow.Cells("IdArqueo").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        '            If estado_process Then
        '                MsgBox("Se Ingreso correctamente la plantilla al Arqueo")
        '                Actualizar()
        '            Else
        '                MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
        '            End If
        '        End If
        '    Else
        '        MsgBox("No existen datos, Verifique...")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub
End Class