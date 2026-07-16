Imports System.ServiceModel
Public Class frmJob

    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    'Private oCotizacionServiciosService As CotizacionServicioService.CotizacionServicioServiceClient
    Private oSolicitudJob As New SolicitudJobService.SolicitudJobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    Private IdCliente As Integer

    Private dtSupervisor As DataTable
    Private dtOficinas As DataTable
    Private dtDatos As DataTable
    Private dtTipo As DataTable
    Private dtEstado As DataTable
    Private dtAnios As DataTable
    Private CodJob As String
    Private iEstado As Integer
    Private iAbrTipo As String
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private Sub frmJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMaestroService.Close()
            oSolicitudJob.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
            oCentroCostoService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMaestroService.Abort()
            oSolicitudJob.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oCentroCostoService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMaestroService.Abort()
            oSolicitudJob.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oCentroCostoService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub frmJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If        
    End Sub

    Private Sub frmJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 110)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        txtanio.Value = Today.Year
        llenarCombos()
        IdCliente = 0
        cmbEstados.Value = 6
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        cmbOficinas.Value = usuario.Oficina.CodOfi
        listaDatos()

        dgvDatos.Select()
        'dgvDatos.CurrentRow.Cells("CodJob").Value = ""      
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbEstados.ValueChanged, cmbOficinas.ValueChanged, cmbSupervisor.ValueChanged, cmbTipo.ValueChanged, txtanio.TextChanged, txtNumJob.TextChanged, txtBuscarCliente.TextChanged, txtSerie.TextChanged, txtDescripcion.TextChanged



        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.Filtrar(Session.sCodEmp, txtanio.Text, cmbOficinas.Value, utils.toNumber(cmbTipo.Value), utils.toNumber(IdCliente), txtSerie.Text, txtDescripcion.Text, utils.toNumber(cmbSupervisor.Value), utils.toNumber(cmbEstados.Value), txtNumJob.Text, cmbCodArea.Value, cmbCentroCosto.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
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
            If row.Cells("CodJob").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub llenarCombos()
        Try


            '====================================== OFICINAS ============================================
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

            '======================================== TIPO ==============================================
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

            '======================================= ESTADOS ===========================================
            dtEstado = oJobService.MostrarEstados.Tables(0)
            dtEstado.Rows.InsertAt(getRowTodos(dtEstado), 0)
            cmbEstados.DataSource = dtEstado
            cmbEstados.DropDownList.DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstado.Columns("DesEstado").ToString
            cmbEstados.DropDownList.ValueMember = dtEstado.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstado.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstados.SelectedIndex = 0
            dtEstado = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.Columns(2).DataMember = dtAreas.Columns("DesUnidad").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing



        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message)
        End Try      
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
                dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString            
            cmbCentroCosto.SelectedIndex = 0            

            If cmbCodArea.Value = "" Then
                lblUnidadNegocio.Text = ""
            Else
                lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            End If

            listaDatos()
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        If cmbCentroCosto.Value = "" Then
            MsgBox("¡Selecccione un Centro de Costo...!")
        Else
            Dim frm As New frmJob_Nuevo

            frm.CodJob = ""
            frm.Actualizar = False
            frm.edicion = True
            frm.iCodArea = cmbCodArea.Value
            frm.iCodCentro = cmbCentroCosto.Value

            If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.CodJob)
                CodJob = frm.CodJob
                Remostrar()
            End If
            enableOpciones()
        End If
      
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else
            If oJobService.Estado(dgvDatos.CurrentRow.Cells("CodJob").Value) = 6 Then
                If MsgBox("¿Está seguro de ELIMINAR la OT N° " & Trim(dgvDatos.CurrentRow.Cells("CodJob").Value) & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Eliminar()
                End If
            Else
                MsgBox("Esta OT ya no se puede ELIMINAR ya que no esta en Estado de Ejecución")
            End If
        End If
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oJobService.Borrar(dgvDatos.CurrentRow.Cells("CodJob").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se eliminó la OT correctamente ")
                listaDatos()
            Else
                MsgBox("Error en el proceso, comunicarse con el área de sistemas")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR : " + ex.Message)
        End Try
    End Sub

    Private Sub biLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biLiquidar.Click, miLiquidar.Click
        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else
            Dim frm As New frmJob_Liquidar
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If
            'If MsgBox("Estas seguro de LIQUIDAR el job N° " & Trim(dgvDatos.CurrentRow.Cells("CodJob").Value) & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            '    Liquidar()
            '    biActualizar_Click(sender, e)
            '    dgvDatos.Select()
            'End If
        End If
    End Sub

    'Private Sub Liquidar()
    '    Try
    '        Dim estado_process As Boolean
    '        estado_process = oJobService.Liquidar(dgvDatos.CurrentRow.Cells("CodJob").Value, False, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

    '        If estado_process Then
    '            MsgBox("Se liquido correctamente el job")
    '            'listaDatos()
    '        Else
    '            MsgBox("Error en el proceso, Comunicarse con el área de sistemas")
    '        End If

    '    Catch ex As Exception
    '        MsgBox("ERROR AL LIQUIDAR JOB : " + ex.Message)
    '    End Try
    'End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtBuscarCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("CodJob").Value
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

    Private Sub biRecalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRecalcular.Click, miRecalcular.Click
        If dgvDatos.CurrentRow.Cells("CodJob").Value <> "" Then
            If MsgBox("¿Está seguro de RECALCULAR la OT N° " & Trim(dgvDatos.CurrentRow.Cells("CodJob").Value) & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Recalcular()
                biActualizar_Click(sender, e)
            End If
        Else
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        End If
        dgvDatos.Select()
    End Sub

    Private Sub Recalcular()
        Try
            Dim estado_process As Boolean
            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(5)
            estado_process = oJobService.Recalcular(dgvDatos.CurrentRow.Cells("CodJob").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se Recalculo correctamente la OT")
            Else
                MsgBox("Error en el Proceso, Comuniquese con el Administrador del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL RECALCULAR LOS GASTOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biRegularGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRegularGastos.Click, miRegular.Click
        Dim frm As New frmJob_Regularizar
        If dgvDatos.CurrentRow.Cells("CodJob").Value <> "" Then
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If
        Else
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        End If
        'listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub biEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.Click, miEstado.Click
        Dim frm As New frmJob_Estados

        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If
        End If
        dgvDatos.Select()
        'listaDatos()
    End Sub

    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else
            If oJobService.Estado(dgvDatos.CurrentRow.Cells("CodJob").Value) <> 16 Then
                If MsgBox("¿Está seguro de ANULAR la OT N° " & Trim(dgvDatos.CurrentRow.Cells("CodJob").Value) & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Anular()
                End If
            Else
                MsgBox("Esta OT no se puede ANULAR ya que esta en estado Liquidado")
            End If
        End If
    End Sub

    Private Sub Anular()
        Try
            Dim estado_process As Boolean
            estado_process = oJobService.Anular(dgvDatos.CurrentRow.Cells("CodJob").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se anulo correctamente la OT")
                listaDatos()
            Else
                MsgBox("Error en el proceso, Comunicarse con el área de TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ANULAR : " + ex.Message)
        End Try
    End Sub

    Private Sub biCulminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCulminar.Click, miCulminar.Click
        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else
            If oJobService.Estado(dgvDatos.CurrentRow.Cells("CodJob").Value) = 6 Then
                If MsgBox("¿Está seguro de CULMINAR la OT N° " & Trim(dgvDatos.CurrentRow.Cells("CodJob").Value) & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Culminar()
                    biActualizar_Click(sender, e)
                End If
            Else
                MsgBox("Esta OT no se puede CULMINAR ya que no esta en estado de Ejecución")
            End If
            dgvDatos.Select()
        End If
    End Sub

    Private Sub Culminar()
        Try
            Dim estado_process As Boolean
            estado_process = oJobService.Culminar(dgvDatos.CurrentRow.Cells("CodJob").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se culmino la OT correctamente")
                listaDatos()
            Else
                MsgBox("Error en el proceso, Comunicarse con el área de TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CULMINAR la OT : " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            'Dim dtdetalles As DataTable
            'dtdetalles = oJobService.MostrarLiquidaciones("").Tables(0)
            'DataGridView1.DataSource = dtdetalles
            If e.Column.Key = "PDF" Then
                Dim CodJobImp As String
                CodJobImp = dgvDatos.CurrentRow.Cells("CodJob").Value

                Dim forma As New frmReportes
                Dim reporte As New rptJobDetalle
                Dim dtReporte As DataTable
                Dim dtSubreporte As DataTable
                'Dim registro As JobService.JobServiceClient

                dtReporte = oJobService.Imprimir(CodJobImp).Tables(0)
                dtSubreporte = oJobService.MostrarLiquidaciones(CodJobImp).Tables(0)

                If reporte.Subreports.Count > 0 Then
                    reporte.Subreports(0).SetDataSource(dtSubreporte)
                End If

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("¡No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "reporte por Rubros de la OT"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir la OT."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva OT."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar OT actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar OT actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del OT."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del OT."
    End Sub
    Private Sub Liquidar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biLiquidar.MouseEnter, miLiquidar.MouseEnter
        sslError.Text = "Liquidar OT actual."
    End Sub
    Private Sub Culminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCulminar.MouseEnter, miCulminar.MouseEnter
        sslError.Text = "Culminar OT actual."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular OT actual."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.MouseEnter, miEstado.MouseEnter
        sslError.Text = "Ver Estados del OT actual."
    End Sub
    Private Sub RegularGastos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRegularGastos.MouseEnter, miRegular.MouseEnter
        sslError.Text = "Regular Gastos del OT actual."
    End Sub
    Private Sub TrasladarGastos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladarGastos.MouseEnter, miTrasladarGastos.MouseEnter
        sslError.Text = "Trasladar Gastos a Otro OT."
    End Sub
    Private Sub Recalcular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRecalcular.MouseEnter, miRecalcular.MouseEnter
        sslError.Text = "Recalcular OT actual."
    End Sub
    Private Sub HabilitarMarcacion_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biHabilitarMarcacion.MouseEnter, miHabilitarMarcacion.MouseEnter
        sslError.Text = "Habilitar Marcación a OT actual."
    End Sub
    Private Sub ActualizarEstado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarEstado.MouseEnter, miActualizarEstado.MouseEnter
        sslError.Text = "Actualizar Estado"
    End Sub
    Private Sub HistorialActivacion_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biHistorialActivar.MouseEnter, miHistorialActivacion.MouseEnter
        sslError.Text = "Ver Historial de Activación del OT actual"
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                             biNuevo.MouseLeave, biMostrar.MouseLeave, _
                            biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                            miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                            miEliminar.MouseLeave, miActualizarEstado.MouseLeave, miActualizar.MouseLeave, _
                            miSalir.MouseLeave, miHabilitarMarcacion.MouseLeave, biHabilitarMarcacion.MouseLeave, miHistorialActivacion.MouseLeave, biHistorialActivar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmJob_Nuevo
                frm.edicion = False
                frm.CodJob = CStr(dgvDatos.CurrentRow.Cells("CodJob").Value)
                frm.Actualizar = True
                frm.Anio = txtanio.Value

                frm.ShowDialog()
                'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                '    biActualizar_Click(sender, e)
                'End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Remostrar()
        Dim frm As New frmJob_Nuevo

        frm.CodJob = CodJob
        frm.Actualizar = True
        frm.ShowDialog()
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtBuscarCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtBuscarCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptJobListado
            'Dim registro As CotizacionServicioService.CotizacionServicio
            'Dim dtDatosListado As DataTable

            'dtDatosListado = oJobService.Filtrar(txtanio.Text, cmbOficinas.Value, utils.toNumber(cmbTipo.Value), utils.toNumber(txtBuscarCliente.Text), txtSerie.Text, txtDescripcion.Text, utils.toNumber(cmbSupervisor.Value), utils.toNumber(cmbEstados.Value), txtNumJob.Text).Tables(0)
            'dgvDatos.DataSource = dtDatos

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.crvReportes.DisplayGroupTree = False
            'forma.crvReportes.RefreshReport = False

            reporte.SetParameterValue("pAnio", txtanio.Text)
            reporte.SetParameterValue("pCliente", txtBuscarCliente.Text)
            reporte.SetParameterValue("pTipo", cmbTipo.Text)
            reporte.SetParameterValue("pEstado", cmbEstados.Text)
            reporte.SetParameterValue("pLoc", cmbOficinas.Text)

            forma.Text = "Listado de Jobs"
            forma.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        Mostrar()
        biActualizar_Click(sender, e)
        dgvDatos.Select()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    If biMostrar.Enabled = True Then
                        biMostrar_Click(sender, e)
                        e.Handled = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biTrasladarGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladarGastos.Click, miTrasladarGastos.Click
        Try
            Dim frm As New frmJob_TrasladarGastos
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("Error al Trasladar los Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biHabilitarMarcacion.Enabled = False
            biLiquidar.Enabled = False
            biCulminar.Enabled = False
            biAnular.Enabled = False
            biEstado.Enabled = False
            biRegularGastos.Enabled = False
            biTrasladarGastos.Enabled = False
            biRecalcular.Enabled = False
            biGenerarGuia.Enabled = False
            biRegistrarArchivos.Enabled = False
            biEnviar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miHabilitarMarcacion.Enabled = False
            miLiquidar.Enabled = False
            miCulminar.Enabled = False
            miAnular.Enabled = False

            miEstado.Enabled = False
            miHistorialActivacion.Enabled = False
            miRegular.Enabled = False
            miTrasladarGastos.Enabled = False
            miRecalcular.Enabled = False
            miGenerarGuia.Enabled = False
            miRegistrarArchivos.Enabled = False
            miEnviar.Enabled = False
        Else
            iEstado = oJobService.Estado(dgvDatos.CurrentRow.Cells("CodJob").Value)
            iAbrTipo = dgvDatos.CurrentRow.Cells("AbrTipo").Value
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 6, True, False)
            biHabilitarMarcacion.Enabled = IIf(iEstado = 6, True, False)
            biEstado.Enabled = True
            biHistorialActivar.Enabled = True
            biGenerarGuia.Enabled = IIf(iEstado = 6 Or iEstado = 28 Or iEstado = 29, True, False)
            biLiquidar.Enabled = IIf(((iEstado = 24) And (iAbrTipo = "VEN") And (Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "57")) Or ((iEstado = 28 Or iEstado = 29) And (iAbrTipo <> "VEN") And Session.CodPerfil <> "12"), True, False)  'IIf(iEstado = 28 Or iEstado = 29, True, False)




            biCulminar.Enabled = IIf(iEstado = 6, True, False)
            biAnular.Enabled = IIf(iEstado = 16 Or iEstado = 1 Or iEstado = 25, False, True)
            biRegularGastos.Enabled = IIf((iEstado = 16 Or iEstado = 25 Or iEstado = 28 Or iEstado = 29), True, False)
            biTrasladarGastos.Enabled = IIf((iEstado = 16 Or iEstado = 25 Or iEstado = 1 Or iEstado = 28), False, True)
            biRecalcular.Enabled = IIf(iEstado = 1, False, True)
            biActualizarEstado.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "25" Or Session.CodPerfil = "24"), True, False)
            biActualizarEstado.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "25" Or Session.CodPerfil = "24") And (iEstado = 16 Or iEstado = 28 Or iEstado = 1 Or iEstado = 29), True, False)
            biActualizar.Enabled = True
            biSalir.Enabled = True
            biRegistrarArchivos.Enabled = True 'IIf(iEstado = 25, False, True)
            biEnviar.Enabled = IIf((iEstado = 28 Or iEstado = 29) And (iAbrTipo = "VEN"), True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 6, True, False)
            miHabilitarMarcacion.Enabled = IIf(iEstado = 6, True, False)
            miEstado.Enabled = True
            miGenerarGuia.Enabled = IIf(iEstado = 6 Or iEstado = 28 Or iEstado = 29, True, False)
            miLiquidar.Enabled = IIf(((iEstado = 24) And (iAbrTipo = "VEN") And (Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "57")) Or ((iEstado = 28 Or iEstado = 29) And (iAbrTipo <> "VEN") And Session.CodPerfil <> "12"), True, False)  'IIf((iEstado = 28 Or iEstado = 29) And (iAbrTipo <> "VEN"), True, False)      'IIf(iEstado = 28 Or iEstado = 29, True, False)
            miCulminar.Enabled = IIf(iEstado = 6, True, False)
            miAnular.Enabled = IIf(iEstado = 16, False, True)
            miRegular.Enabled = IIf((iEstado = 16 Or iEstado = 25 Or iEstado = 28 Or iEstado = 29), True, False)
            miTrasladarGastos.Enabled = IIf((iEstado = 16 Or iEstado = 25), False, True)
            miRecalcular.Enabled = True
            miActualizarEstado.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "25" Or Session.CodPerfil = "24"), True, False)
            miActualizarEstado.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "25" Or Session.CodPerfil = "24") And (iEstado = 16 Or iEstado = 28 Or iEstado = 1 Or iEstado = 29), True, False)
            miActualizar.Enabled = True
            miSalir.Enabled = True
            miRegistrarArchivos.Enabled = True 'IIf(iEstado = 25, False, True)
            miEnviar.Enabled = IIf((iEstado = 28 Or iEstado = 29) And (iAbrTipo = "VEN"), True, False)

        End If
    End Sub

    Private Sub biGenerarGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarGuia.Click, miGenerarGuia.Click
        Try
            Dim frm As New frmJob_Generar

            frm.Text = "Generar Guia"
            frm.NumJob = dgvDatos.CurrentRow.Cells("CodJob").Text
            'frm.IdLocacion = cmbIdLocacion.Value
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdClienteBenificiado").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarEstado.Click, miActualizarEstado.Click
        Try
            Dim frm As New frmJob_ActualizarEstado

            frm.Text = "Actualizar a estado inicial"
            frm.NumJob = dgvDatos.CurrentRow.Cells("CodJob").Text
            'frm.IdLocacion = cmbIdLocacion.Value
            'frm.IdCliente = dgvDatos.CurrentRow.Cells("IdClienteBenificiado").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biHabilitarMarcacion_Click(sender As Object, e As System.EventArgs) Handles biHabilitarMarcacion.Click, miHabilitarMarcacion.Click
        Try
            Dim frm As New frmJob_HabilitarMarcacion
            If dgvDatos.CurrentRow.Cells("CodJob").Value <> "" Then
                frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            Else
                MsgBox("¡Selecccione un registro, tenga cuidado ...!")
            End If
            'listaDatos()
            dgvDatos.Select()
        Catch ex As Exception
            MsgBox("ERROR [HABILITAR MARCACIÓN]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biHistorialActivar_Click(sender As System.Object, e As System.EventArgs) Handles biHistorialActivar.Click, miHistorialActivacion.Click
        Try
            Dim frm As New frmJob_Historial_Act

            If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
                MsgBox("¡Selecccione un registro, tenga cuidado ...!")
            Else
                frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            End If
            dgvDatos.Select()
        Catch ex As Exception
            MsgBox("ERROR [HISTORIAL DE ACTIVACIÓN]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRegistrarArchivos_Click(sender As Object, e As EventArgs) Handles biRegistrarArchivos.Click, miRegistrarArchivos.Click
        Try
            Dim frm As New frmJob_Archivos
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
            'frm.Nombre = dgvDatos.CurrentRow.Cells("Nombre").Value
            frm.estado = dgvDatos.CurrentRow.Cells("AbrEstado").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DE LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub cmbCentroCosto_ValueChanged(sender As Object, e As EventArgs) Handles cmbCentroCosto.ValueChanged

        ' If toBlank(cmbCentroCosto.Value) <> "" Then
        '==================================== SUPERVISOR ===========================================
        dtSupervisor = oAsignacionJefesService.MostrarJefeArea(cmbCentroCosto.Value).Tables(0) 'oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            If dtSupervisor.Rows.Count > 1 Or cmbCentroCosto.Value = "" Then
                dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            End If
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            If dtSupervisor.Rows.Count > 0 Then
                cmbSupervisor.SelectedIndex = 0
            End If
            dtSupervisor = Nothing

        ' End If

        listaDatos()

    End Sub

    Private Sub biEnviar_Click(sender As Object, e As EventArgs) Handles biEnviar.Click, miEnviar.Click

        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else

            Dim frm As New frmJob_EnviarCreditos
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If


            'Try
            '    'cmOpciones.Visible = False
            '    If MsgBox("¿Está seguro de ENVIAR la OT Nº " + dgvDatos.CurrentRow.Cells("CodJob").Text.ToString + " a Créditos para su aprobación ... ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

            '        'Dim NomPc As String = Dns.GetHostName
            '        'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
            '        Dim estado_process As Boolean
            '        estado_process = oJobService.EnviarCreditos(dgvDatos.CurrentRow.Cells("CodJob").Text, dgvDatos.CurrentRow.Cells("IdSugerido").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            '        If estado_process = True Then
            '            dtDatos = Nothing
            '            listaDatos()
            '            RowPossesion(dgvDatos, dgvDatos.CurrentRow.Cells("CodJob").Text)
            '            MsgBox("La Cotización fue Enviada a Créditos correctamente.", MsgBoxStyle.Information)
            '        Else
            '            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            '        End If
            '    End If
            'Catch ex As Exception
            '    MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            'End Try
        End If
    End Sub
End Class