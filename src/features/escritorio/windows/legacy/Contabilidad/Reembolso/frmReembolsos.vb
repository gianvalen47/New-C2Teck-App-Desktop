Imports System.ServiceModel
Public Class frmReembolsos

    '===========================Servicios====================================================
    Dim oReembolsoCajaService As New ReembolsoCajaService.ReembolsoCajaServiceClient
    Dim oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Dim oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean    
    Private dtMoneda As DataTable
    Private dtUbicacion As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtDatos As New DataTable

    '==========================Evento Load========================================================
    Private Sub frmComReembolso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 142)
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
        cmbUbicacion.Focus()
    End Sub

    '=============================Evento KeyPress==================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtAnio.KeyPress _
                      , cmbUbicacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , cmbMes.KeyPress
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

    '==========================Evento FormClosed====================================================
    Private Sub frmComSolicitudGastos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReembolsoCajaService.Close()
            oProvisionalService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try        
    End Sub

    '==========================Evento KeyDown======================================================
    Private Sub frmComReembolso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAtender.Enabled = False
            'biIngresar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAtender.Enabled = False
            'miIngresar.Enabled = False
        Else
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(lEstado = "GENERADO", True, False)
            biAtender.Enabled = IIf(lEstado = "GENERADO", True, False)
            'biIngresar.Enabled = IIf(lEstado = "GENERADO", True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(lEstado = "GENERADO", True, False)
            miAtender.Enabled = IIf(lEstado = "GENERADO", True, False)
            'miIngresar.Enabled = IIf(lEstado = "GENERADO", True, False)
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
            If row.Cells("IdReembolso").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmReembolso_Nuevo
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdReembolso = dgvDatos.CurrentRow.Cells("IdReembolso").Value
            frm.editable = IIf(lEstado = "GENERADO", True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.IdReembolso)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdReembolso)
                Else
                    listaDatos()
                    MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("Está seguro de ELIMINAR el Reembolso Nº " + dgvDatos.CurrentRow.Cells("Numero").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oReembolsoCajaService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdReembolso").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se elimino correctamente el registro...!!!", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL REEMBOLSO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmReembolso_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
           
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    cmbUbicacion.Value = frm.iUbicacion
                    RowPossesion(dgvDatos, frm.IdReembolso)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub llenarCombos()
        Try

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

            '======================================= ESTADOS ================================================
            dtEstados = oReembolsoCajaService.MostrarEstados()
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
                dtDatos = oReembolsoCajaService.Filtrar(cmbUbicacion.Value, txtAnio.Value, cmbMes.Value, cmbEstado.Value, toNumber(txtNumReembolso.Text)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()                
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbUbicacion.ValueChanged, txtAnio.TextChanged, cmbMes.ValueChanged, cmbEstado.ValueChanged, txtNumReembolso.TextChanged
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
            codigo = dgvDatos.CurrentRow.Cells("IdReembolso").Text
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

    Private Sub biAtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.Click, miAtender.Click
        'Se ocultó esta opción ya que el reembolso pasará a estado ATENDIDO cuando sea ingresado a un Asiento (Tesoreria)
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Estas seguro de ATENDER el Reembolso N° " & dgvDatos.CurrentRow.Cells("Numero").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oReembolsoCajaService.Atender(dgvDatos.CurrentRow.Cells("IdReembolso").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Atendio correctamente el Reembolso")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                    End If
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Reembolso actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Reembolso."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Reembolso actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Reembolso actual."
    End Sub
    Private Sub Ingresar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresar.MouseEnter, miIngresar.MouseEnter
        sslError.Text = "Ingresar Solicitud de Gastos al Reembolso actual."
    End Sub
    Private Sub Atender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.MouseEnter, miAtender.MouseEnter
        sslError.Text = "Atender Reembolso actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        'dtDatos = oReembolsoCajaService.Imprimir(dgvDatos.CurrentRow.Cells("IdReembolso").Value).Tables(0)
        'DataGridView1.DataSource = dtDatos
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmReembolso_Imprimir
                frm.IdReembolso = dgvDatos.CurrentRow.Cells("IdReembolso").Value
                frm.TotNeto = toDouble(dgvDatos.CurrentRow.Cells("TotNeto").Value)
                frm.CodMon = toBlank(dgvDatos.CurrentRow.Cells("CodMon").Value)
                frm.IdUbicacion = toNumber(cmbUbicacion.Value)
                frm.DesUbicacion = toBlank(cmbUbicacion.Text)
                frm.Anio = txtAnio.Value
                frm.Mes = toBlank(cmbMes.Value)
                frm.DesMes = toBlank(cmbMes.Text)
                frm.Estado = toBlank(cmbEstado.Value)
                frm.DesEstado = toBlank(cmbEstado.Text)
                frm.Numero = toNumber(txtNumReembolso.Text)                
                frm.ShowDialog()
            End If
            'Dim forma As New frmReportes
            'Dim dtReporte As New DataTable
            'Dim reporte As New rptReembolso_Detalle
            'If dgvDatos.RowCount > 0 Then
            '    dtReporte = oReembolsoCajaService.Imprimir(dgvDatos.CurrentRow.Cells("IdReembolso").Value).Tables(0)
            '    If dtReporte.Rows.Count = 0 Then
            '        MsgBox("No hay datos a mostrar")
            '    Else
            '        reporte.SetDataSource(dtReporte)
            '        forma.crvReportes.ReportSource = reporte
            '        forma.crvReportes.DisplayGroupTree = False
            '        reporte.SetParameterValue("pNumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
            '        forma.Text = "Reporte de Reembolso de Caja"
            '        forma.ShowDialog()
            '    End If
            'Else
            '    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresar.Click, miIngresar.Click
        'Se ocultó está opción ya que el ingreso de los detalles de solicitud de gasto se relaiza en la opción Ia INGRESAR (menu contextual de los detalles de Reembolso)

        'Try
        '    If ValidaCodigoSeleccionado() Then
        '        Dim frm As New frmReembolso_Ingresar
        '        frm.IdReembolso = dgvDatos.CurrentRow.Cells("IdReembolso").Text
        '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '            biRefrescar_Click(sender, e)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al Ingresar Solicitud de Gastos al Reembolso: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub
End Class