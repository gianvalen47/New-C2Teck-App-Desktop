Imports System.ServiceModel

Public Class frmJobConsulta

    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient    
    Private oSolicitudJob As New SolicitudJobService.SolicitudJobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    Private IdCliente As Integer
    Private dtSupervisor As DataTable
    Private dtOficinas As DataTable
    Private dtDatos As DataTable
    Private dtTipo As DataTable
    Private dtEstado As DataTable
    Private dtTable As DataTable
    Private dtAnios As DataTable
    Private CodJob As String
    Public Anio As Integer
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private Sub frmJobConsulta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMaestroService.Close()
            oSolicitudJob.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
            oCentroCostoService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMaestroService.Abort()
            oSolicitudJob.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oCentroCostoService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMaestroService.Abort()
            oSolicitudJob.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oCentroCostoService.Abort()
        End Try
    End Sub

    Private Sub frmJobConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJobConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 125)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarcombos()
        txtanio.Value = Today.Year
        IdCliente = 0
        cmbEstados.Value = 6
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        cmbOficinas.Value = usuario.Oficina.CodOfi
        listaDatos()
    End Sub

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

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.Filtrar(Session.sCodEmp, utils.toNumber(txtanio.Text), cmbOficinas.Value, utils.toNumber(cmbTipo.Value), utils.toNumber(IdCliente), txtSerie.Text, txtDescripcion.Text, utils.toNumber(cmbSupervisor.Value), utils.toNumber(cmbEstados.Value), txtNumJob.Text, cmbCodArea.Value, cmbCentroCosto.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
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

    Private Sub llenarcombos()
        Try
            '==================================== SUPERVISOR ===========================================
            dtSupervisor = oMaestroService.MostrarSupervisores.Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

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

            '======================================= TIPO ================================================
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

            '////////////TIPO DE MOVIMIENTO///////////////
            'dtAnios = New DataTable
            'dtAnios.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
            'dtAnios.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            'dtAnios.Rows.Add(New Object() {"0", "(Todos)"})
            'dtAnios.Rows.Add(New Object() {"2002", "2002"})
            'dtAnios.Rows.Add(New Object() {"2003", "2003"})
            'dtAnios.Rows.Add(New Object() {"2004", "2004"})
            'dtAnios.Rows.Add(New Object() {"2005", "2005"})
            'dtAnios.Rows.Add(New Object() {"2006", "2006"})
            'dtAnios.Rows.Add(New Object() {"2007", "2007"})
            'dtAnios.Rows.Add(New Object() {"2008", "2008"})
            'dtAnios.Rows.Add(New Object() {"2009", "2009"})
            'dtAnios.Rows.Add(New Object() {"2010", "2010"})
            'dtAnios.Rows.Add(New Object() {"2011", "2011"})
            'dtAnios.Rows.Add(New Object() {"2012", "2012"})
            'dtAnios.Rows.Add(New Object() {"2013", "2013"})
            'dtAnios.Rows.Add(New Object() {"2014", "2014"})
            'dtAnios.Rows.Add(New Object() {"2015", "2015"})
            'cmbAnio.DataSource = dtAnios
            'cmbAnio.DisplayMember = "Descripcion"
            'cmbAnio.ValueMember = "Codigo"
            'cmbAnio.DropDownList.Columns(0).DataMember = "Codigo"
            'cmbAnio.DropDownList.Columns(1).DataMember = "Descripcion"
            ''cmbAnio.SelectedIndex = 1
            'dtAnios = Nothing

            ' ''======================================= AÑOS ================================================
            'dtAnios = oJobService.MostrarAnios.Tables(0)
            ''DataGridView1.DataSource = dtAnios
            ''AgregarColumna()
            ''dtAnios.Rows.Add(New Object() {"(Todos)"})
            'dtAnios.Rows.InsertAt(getRowTodos1(dtAnios), 0)
            'cmbAnio.DataSource = dtAnios
            'cmbAnio.DropDownList.DataMember = dtAnios.Columns("Anio").ToString
            'cmbAnio.DropDownList.DisplayMember = dtAnios.Columns("Anio").ToString
            'cmbAnio.DropDownList.ValueMember = dtAnios.Columns("Anio").ToString
            'cmbAnio.DropDownList.Columns(0).DataMember = dtAnios.Columns("Anio").ToString
            'cmbAnio.DropDownList.Columns(1).DataMember = dtAnios.Columns("Anio").ToString
            'cmbAnio.SelectedIndex = 0
            'dtAnios = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
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
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message)
        End Try
    End Sub

    'Private Sub AgregarColumna()
    '    Dim row As DataRow

    '    dtTable = dtAnios.Copy
    '    dtTable.Columns.Add("DesAnio", Type.GetType("System.String"))
    '    dtTable.Clear()

    '    For i = 0 To dtAnios.Rows.Count - 1
    '        row = dtTable.NewRow
    '        row(0) = dtAnios.Rows(i).Item(0)
    '        row(1) = dtAnios.Rows(i).Item(0)
    '        dtTable.Rows.Add(row)
    '    Next i
    '    dtAnios = dtTable.Copy
    'End Sub
    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, "").Tables(0)
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
            listaDatos()

            If cmbCodArea.Value = "" Then
                lblUnidadNegocio.Text = ""
            Else
                lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.TextChanged, cmbOficinas.ValueChanged, txtBuscarCliente.TextChanged, _
    cmbTipo.ValueChanged, cmbEstados.ValueChanged, txtSerie.TextChanged, txtNumJob.TextChanged, txtDescripcion.TextChanged, cmbSupervisor.ValueChanged, cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.Click, miEstado.Click
        Dim frm As New frmJobConsulta_Estados
        If dgvDatos.CurrentRow.Cells("CodJob").Value = "" Then
            MsgBox("¡Selecccione un registro, tenga cuidado...!")
        Else
            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
            frm.ShowDialog()
        End If
        listaDatos()
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "PDF" Then
                Dim CodJobImp As String
                CodJobImp = dgvDatos.CurrentRow.Cells("CodJob").Value

                Dim forma As New frmReportes
                Dim reporte As New rptJobDetalle  'rptJobConsultaDetalle
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
                    'Validar por usuario - Exportar Excel 
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If

                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False

                    forma.Text = "reporte por Rubros de la OT"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmJobConsulta_Nuevo
                frm.CodJob = CStr(dgvDatos.CurrentRow.Cells("CodJob").Value)
                frm.Actualizar = True
                frm.Anio = Year(CDate(dgvDatos.CurrentRow.Cells("FecInicio").Value))
                frm.ShowDialog()
                'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                '    biActualizar_Click(sender, e)
                'End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
            Dim reporte As New rptJobListado  'rptJobConsultaListado
            'Dim registro As CotizacionServicioService.CotizacionServicio

            'Dim dtDatosListado As DataTable

            'dtDatosListado = oJobService.Filtrar(txtanio.Text, cmbOficinas.Value, utils.toNumber(cmbTipo.Value), utils.toNumber(txtBuscarCliente.Text), txtSerie.Text, txtDescripcion.Text, utils.toNumber(cmbSupervisor.Value), utils.toNumber(cmbEstados.Value), txtNumJob.Text).Tables(0)
            'dgvDatos.DataSource = dtDatos

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte
            'Validar por usuario - Exportar Excel 
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

            'reporte.SetParameterValue("pAnio", IIf(txtanio.Text = Nothing, "", "Serie " & txtanio.Text))
            'reporte.SetParameterValue("pCliente", IIf(txtBuscarCliente.Text = Nothing, "", " Modelo " & txtBuscarCliente.Text))
            'reporte.SetParameterValue("pTipo", IIf(cmbTipo.Value = Nothing, "", cmbTipo.Value))
            'reporte.SetParameterValue("pEstado", IIf(cmbEstados.Value = Nothing, "", "Serie " & cmbEstados.Value))
            'reporte.SetParameterValue("pLoc", IIf(cmbOficinas.Value = Nothing, "", "Serie " & cmbOficinas.Value))

            forma.Text = "Listado de OTs"
            forma.ShowDialog()

        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        Mostrar()
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
End Class