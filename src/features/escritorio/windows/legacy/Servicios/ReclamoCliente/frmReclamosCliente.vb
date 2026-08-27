Imports System.ServiceModel
Public Class frmReclamosCliente

    '===========================Servicios====================================================
    Private oReclamoClienteService As New ReclamoClienteService.ReclamoClienteServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdCliente As Integer
    Private dtSupervisor As New DataTable
    Private dtEstados As New DataTable
    Private dtDatos As New DataTable
    Private iEstado As Integer

    '==========================Evento Load===================================================
    Private Sub frmReclamosCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 301)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        txtFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFecFinal.Value = Today
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtFecInicio.KeyPress _
                           , txtFecFinal.KeyPress _
                           , txtCliente.KeyPress _
                           , btnBuscarCliente.KeyPress _
                           , cmbSupervisor.KeyPress _
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
    Private Sub frmReclamosCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReclamoClienteService.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oReclamoClienteService.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oReclamoClienteService.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmReclamosCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            biEnviar.Enabled = False
            biVerEstados.Enabled = False            
            biRechazar.Enabled = False            

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miEnviar.Enabled = False
            miVerEstados.Enabled = False            
            miRechazar.Enabled = False            
        Else
            iEstado = toNumber(dgvDatos.CurrentRow.Cells("IdEstado").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biEnviar.Enabled = IIf(iEstado = 1, True, False)
            biVerEstados.Enabled = True
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            biRechazar.Enabled = IIf(iEstado = 2 And IIf(Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "26" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17", True, False), True, False)


            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miEnviar.Enabled = IIf(iEstado = 1, True, False)
            miVerEstados.Enabled = True
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            miRechazar.Enabled = IIf(iEstado = 2 And IIf(Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "26" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17", True, False), True, False)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdReclamo").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal IdGarantia As String)
        If type_process = "update" Or type_process = "insert" Then

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

    Private Sub mostrar()
        Try
            Dim frm As New frmReclamoCliente
            frm.state_button = True
            frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdReclamo)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdReclamo)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL RECLAMO DE CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el reclamo seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oReclamoClienteService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdReclamo").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL RECLAMO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmReclamoCliente
                frm.state_button = False
                frm.iIdCliente = IdCliente
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdReclamo)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO RECLAMO CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================== SUPERVISOR ================================================            
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing


            '======================================= ESTADOS ================================================
            dtEstados = oReclamoClienteService.MostrarEstados().Tables(0)
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
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
                dtDatos = oReclamoClienteService.Filtrar(Session.sCodEmp, txtFecInicio.Value, txtFecFinal.Value, IdCliente, toNumber(cmbSupervisor.Value), toNumber(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtFecInicio.ValueChanged, txtFecFinal.ValueChanged, txtCliente.TextChanged, cmbSupervisor.ValueChanged, cmbEstado.ValueChanged
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
            codigo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
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

    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub miProcesar_Click(sender As Object, e As System.EventArgs) Handles miProcesar.Click, biProcesar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmReclamoCliente_Procesar
                frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Text                
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al PROCESAR el Reclamo de Cliente: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   biImprimir.MouseLeave, biNuevo.MouseLeave, _
                                   biMostrar.MouseLeave, biEliminar.MouseLeave, biEnviar.MouseLeave, _
                                   biVerEstados.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                   miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                   miEliminar.MouseLeave, miEnviar.MouseLeave, miActualizar.MouseLeave, _
                                   miSalir.MouseLeave, miRechazar.MouseLeave, biRechazar.MouseLeave, _
                                   miProcesar.MouseLeave, biProcesar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Reclamo de Cliente actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Reclamo de Cliente."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Reclamo de Cliente actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Reclamo de Cliente actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar Reclamo de Cliente actual."
    End Sub
    Private Sub Rechazar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.MouseEnter, miRechazar.MouseEnter
        sslError.Text = "Aprobar / Rechazar Reclamo de Cliente actual."
    End Sub
    Private Sub Procesar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesar.MouseEnter, miProcesar.MouseEnter
        sslError.Text = "Procesar Reclamo de Cliente actual."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados de Reclamo de Cliente actual."
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmReclamoCliente_Estados
                frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Value
                frm.Text = "Estados del Reclamo de Cliente Nº " & dgvDatos.CurrentRow.Cells("IdReclamo").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biRechazar.Click, miRechazar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmReclamoCliente_Rechazar
                frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al RECHAZAR el Reclamo de Cliente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Está seguro de ENVIAR el Reclamo de Cliente N° " & dgvDatos.CurrentRow.Cells("IdReclamo").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oReclamoClienteService.Enviar(dgvDatos.CurrentRow.Cells("IdReclamo").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Envió el Reclamo de Cliente correctamente ")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ENVIAR Reclamo de Cliente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()
        Try

            Dim NoIncluyeFirma As String

            Dim frm As New frmReclamoCliente_Imprimir
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                NoIncluyeFirma = frm.nofirma

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptReclamo_Cliente
                If dgvDatos.RowCount > 0 Then
                    dtReporte = oReclamoClienteService.Imprimir(toNumber(dgvDatos.CurrentRow.Cells("IdReclamo").Value)).Tables(0)
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
                        reporte.SetParameterValue("NoFirma", NoIncluyeFirma)
                        reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))

                        forma.Text = "Reporte de Reclamo de Cliente"
                        forma.ShowDialog()
                    End If
                Else
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
End Class