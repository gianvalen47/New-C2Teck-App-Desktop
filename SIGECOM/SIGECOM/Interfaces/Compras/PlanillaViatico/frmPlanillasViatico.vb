Imports System.ServiceModel
Public Class frmPlanillasViatico

    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPlanillaViaticoService As New PlanillaViaticoService.PlanillaViaticoServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    Public IdPersona As Integer
    Private dtAreas As DataTable    
    Private dtTipo As DataTable
    Private dtDatos As New DataTable
    Private dtUbicacion As DataTable

    Private Sub frmPlanillasViatico_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oPlanillaViaticoService.Close()
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPlanillaViaticoService.Abort()
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPlanillaViaticoService.Abort()
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmPlanillasViatico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillasViatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 150)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        'poCargarArea()
        poCargarSolicitante()
        Dim Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            ' Mes = Month(Today)
            Anio = Year(Today)
        Else
            ' Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        'cbFecInicio.Value = "01/01/" & Trim(Anio) se cambio por mostrar demasiada data
        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Fecha
        'IdPersona = 0
        'txtSolicitante.Text = "(Todos)"
        ObtenerUbicacion()
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub poCargarArea()
        'If Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "30" Or Session.CodPerfil = "15" Then
        '    cmbCodArea.Enabled = True
        'Else
        '    Dim oUsuario As New SeguridadService.Usuario
        '    oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        '    cmbCodArea.Value = oUsuario.Persona.CentroCosto.Area.CodArea
        '    cmbCodArea.Enabled = False
        'End If
    End Sub

    Private Sub poCargarSolicitante()
        'Se agrega el perfil 38 Jefe de Operaciones Foráneas y el perfil 42 Administrador Sistemas
        'Se agrega el perfil 12 de Gerente Administrativo 08/11/2013 (Sr. Erick)
        'Se agrega el perfil 36 de Jefe de Recursos humanos 05/06/2014 (Sra. Marlene)
        If Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "30" Or Session.CodPerfil = "25" Or Session.CodPerfil = "24" Or
          Session.CodPerfil = "15" Or Session.CodPerfil = "38" Or Session.CodPerfil = "42" Or Session.CodPerfil = "12" Or Session.CodPerfil = "36" Or Session.CodPerfil <> "48" Then
            btnBuscarPersona.Enabled = True
            IdPersona = 0
            txtSolicitante.Text = "(Todos)"
        Else
            btnBuscarPersona.Enabled = False
            Dim oUsuario As New SeguridadService.Usuario
            oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            IdPersona = oUsuario.Persona.IdPer
            txtSolicitante.Text = oUsuario.Persona.ApeNom
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
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

    Private Sub chkPersona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPlanillaViaticoService.Filtrar(cbFecInicio.Value, cbFecFinal.Value, IdPersona, CStr(cmbCodArea.Value), txtNumJob.Text, toNumber(txtNumero.Text), toNumber(cmbTipo.Value), toNumber(cmbUbicacion.Value)).Tables(0)
            dgvDatos.DataSource = dtDatos
            'sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
            CalcularTotalProcesados()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CalcularTotalProcesados()
        Try
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As Boolean
            Dim Monto As Double = 0.0

            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("Procesado").Value

                If bSelected Then
                    Monto = Monto + toDouble(row.Cells("Monto").Value)
                End If
            Next
            sslTotalProcesados.Text = "Monto Total de Planillas de Viático Procesadas: "
            txtTotalProcesados.Value = Monto
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub enableOpciones()
        Dim Permiso As Boolean
        If Session.CodPerfil <> "30" And Session.CodPerfil <> "24" And Session.CodPerfil <> "01" And Session.CodPerfil <> "25" And Session.CodPerfil <> "15" And Session.CodPerfil <> "48" Then
            Permiso = False
        Else
            Permiso = True
        End If

        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAprobar.Enabled = False
            biAtender.Enabled = False
            biRechazar.Enabled = False

            'miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAprobar.Enabled = False
            miAtender.Enabled = False
            miRechazar.Enabled = False
        Else
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf((dgvDatos.CurrentRow.Cells("Enviado").Value = False), True, False)
            biAprobar.Enabled = IIf((dgvDatos.CurrentRow.Cells("Enviado").Value = True And dgvDatos.CurrentRow.Cells("Aprobado").Value = False), True, False)
            biAtender.Enabled = IIf((dgvDatos.CurrentRow.Cells("Aprobado").Value = True And dgvDatos.CurrentRow.Cells("Atendido").Value = False) And Permiso = True, True, False)
            biRechazar.Enabled = IIf((dgvDatos.CurrentRow.Cells("Aprobado").Value = True And dgvDatos.CurrentRow.Cells("Procesado").Value = False) And Permiso = True, True, False)

            'miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf((dgvDatos.CurrentRow.Cells("Enviado").Value = False), True, False)
            miAprobar.Enabled = IIf((dgvDatos.CurrentRow.Cells("Enviado").Value = True And dgvDatos.CurrentRow.Cells("Aprobado").Value = False), True, False)
            miAtender.Enabled = IIf((dgvDatos.CurrentRow.Cells("Aprobado").Value = True And dgvDatos.CurrentRow.Cells("Atendido").Value = False) And Permiso = True, True, False)
            miRechazar.Enabled = IIf((dgvDatos.CurrentRow.Cells("Aprobado").Value = True And dgvDatos.CurrentRow.Cells("Procesado").Value = False) And Permiso = True, True, False)
        End If

        biAtenderMasivo.Enabled = IIf(Permiso = True, True, False)
        miAtenderMasivo.Enabled = IIf(Permiso = True, True, False)

    End Sub

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
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            '======================================= TIPO : REFRIG-MOVIL ================================================
            dtTipo = New DataTable
            dtTipo.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipo.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipo.Rows.Add(New Object() {"0", "(Todos)"})
            dtTipo.Rows.Add(New Object() {"1", "Movilidad"})
            dtTipo.Rows.Add(New Object() {"2", "Refrigerio"})

            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("nombre").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCodArea.ValueChanged, txtNumJob.TextChanged, txtNumero.TextChanged, cmbTipo.ValueChanged, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged, cmbUbicacion.ValueChanged
        listaDatos()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
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

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Mostrar()
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmPlanillaViatico
            frm.state_button = True
            frm.IdPlanilla = dgvDatos.CurrentRow.Cells("IdPlanilla").Text
            'frm.editable = IIf(lEstado = "Generado", True, False)
            frm.editable = False
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdPlanilla)
                Else
                    listaDatos()
                End If
            End If
            Actualizar()
            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PLANILLA DE VIÁTICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Mostrar()
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

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmPlanillaViatico
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    cmbUbicacion.Value = frm.iUbicacion
                    RowPossesion(dgvDatos, frm.IdPlanilla)
                    Mostrar()
                    Actualizar()
                End If
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA PLANILLA DE VIÁTICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                              biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                              biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                              biAprobar.MouseLeave, miAprobar.MouseLeave, biRechazar.MouseLeave, miRechazar.MouseLeave, _
                              biEliminar.MouseLeave, miAtender.MouseLeave, biActualizar.MouseLeave, miActualizar.MouseLeave, _
                              biSalir.MouseLeave, miSalir.MouseLeave, miAtenderMasivo.MouseLeave, biAtenderMasivo.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter
        sslError.Text = "Imprimir Planilla de Viático Actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Planilla de Viático Actual.."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Planilla de Viático Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Planilla de Viático Actual."
    End Sub
    Private Sub Atender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.MouseEnter, miAtender.MouseEnter
        sslError.Text = "Atender Planilla de Viático Actual."
    End Sub
    Private Sub AtenderMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtenderMasivo.MouseEnter, miAtenderMasivo.MouseEnter
        sslError.Text = "Atender Planilla de Viático Masivo."
    End Sub
    Private Sub Rechazar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.MouseEnter, miRechazar.MouseEnter
        sslError.Text = "Rechazar Planilla de Viático Actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub    
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar Planilla de Viático Actual."
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

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR la Planilla de Viático Nº " + dgvDatos.CurrentRow.Cells("IdPlanilla").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaViaticoService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdPlanilla").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PLANILLA DE VIÁTICO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmPlanillaViaticoAprobar
                frm.IdPlanilla = CInt(dgvDatos.CurrentRow.Cells("IdPlanilla").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            Else
                MsgBox("No existen datos, Verifique...")            
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            If toNumber(cmbTipo.Value) <> 0 Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataView
                Dim dtTabla As New DataView
                Dim reporte As New rptPlanillaViatico
                dtReporte = oPlanillaViaticoService.Filtrar(cbFecInicio.Value, cbFecFinal.Value, IdPersona, CStr(cmbCodArea.Value), txtNumJob.Text, toNumber(txtNumero.Text), toNumber(cmbTipo.Value), toNumber(cmbUbicacion.Value)).Tables(0).DefaultView
                'dtReporte.RowFilter = "Aprobado =1 And Procesado=0"
                If dtReporte.Count = 0 Then
                    MsgBox("No existen datos a imprimir ")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = True
                    forma.Text = "Reporte de Planilla Viático"
                    reporte.SetParameterValue("Tipo", IIf(cmbTipo.Value = 1, "MOVILIDAD", IIf(cmbTipo.Value = 2, "REFRIGERIO", "")))
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Debe ingresar el tipo de planilla...")
                cmbTipo.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.Click, miAtender.Click
        Try
            If Session.CodPerfil = "01" Or Session.CodPerfil = "30" Or Session.CodPerfil = "24" Or Session.CodPerfil = "25" Or Session.CodPerfil = "15" And Session.CodPerfil <> "48" Then
                If MsgBox("¿Está seguro de ATENDER la Planilla de Viático Nº " + dgvDatos.CurrentRow.Cells("IdPlanilla").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPlanillaViaticoService.Atender(CInt(dgvDatos.CurrentRow.Cells("IdPlanilla").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se atendió la planilla correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            Else
                MsgBox("Usted no tiene permiso para atender la planilla")
                cmbTipo.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ATENDER LA PLANILLA DE VIÁTICO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biRechazar.Click, miRechazar.Click
        Try
            If MsgBox("¿Está seguro de RECHAZAR la Planilla de Viático Nº " + dgvDatos.CurrentRow.Cells("IdPlanilla").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaViaticoService.Rechazar(CInt(dgvDatos.CurrentRow.Cells("IdPlanilla").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se atendió la planilla correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ATENDER LA PLANILLA DE VIÁTICO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAtenderMasivo_Click(sender As Object, e As System.EventArgs) Handles biAtenderMasivo.Click, miAtenderMasivo.Click
        Try
            If toNumber(cmbUbicacion.Value) = 0 Then
                MsgBox("Debe seleccionar una Ubicación de Caja", MsgBoxStyle.Information, "Información")
            Else
                Dim frm As New frmPlanillaViaticoAtenderMasivo
                frm.IdUbicacion = toNumber(cmbUbicacion.Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR MASIVO la Pre Marcación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class