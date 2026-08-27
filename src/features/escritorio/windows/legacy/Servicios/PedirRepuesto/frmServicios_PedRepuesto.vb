Public Class frmServicios_PedRepuesto

    Private oMaestro As New MaestroService.MaestroClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oJobRepuestoService As New JobRepuestoService.JobRepuestoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private Job As New JobService.Job
    Private state_Search As Boolean
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    'Public IdOficina As Integer
    Public NumJob As String
    Public IdCliente As String
    Private dtDatos As DataTable
    Private loNuevoDataTable As DataTable
    Public DesCli As String

    Private Sub frmServicios_PedRepuesto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestro) = False Then
                oMaestro.Close()
            End If
            If isClosed(oTransferenciaService) = False Then
                oTransferenciaService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_PedRepuesto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_PedRepuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmServicios_PedRepuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        state_Search = True
        llenarCombos()
        listaDatos()
        enableOpciones()
    End Sub
   
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 0 Then
            biTicket.Enabled = False
            biImprimir.Enabled = False
        Else
            biImprimir.Enabled = True
            biTicket.Enabled = True
        End If
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If IdCliente = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                Return False
           
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                Job = oJobService.Obtener(NumJob)

                'If Job.CentroCosto.Area.CodArea = "05" Then
                'dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, "01", 3, NumJob).Tables(0)
                'ElseIf Job.CentroCosto.Area.CodArea = "20" Then
                'dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, "01", 54, NumJob).Tables(0)
                'End If
                dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, cmbOficinas.Value, cmbIdLocacion.Value, NumJob).Tables(0)

                dgvDatos.DataSource = dtDatos

                cIdLocacion.DataPropertyName = dtDatos.Columns("IdLocacion").ColumnName
                cCodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
                cCodMer.DataPropertyName = dtDatos.Columns("CodMer").ColumnName
                cDesMer.DataPropertyName = dtDatos.Columns("DesMer").ColumnName
                cCanPed.DataPropertyName = dtDatos.Columns("CanMer").ColumnName
                cCanAte.DataPropertyName = dtDatos.Columns("CanAte").ColumnName
                cCanPen.DataPropertyName = dtDatos.Columns("CanPen").ColumnName
                cUbica.DataPropertyName = dtDatos.Columns("Ubica").ColumnName
                cDeaMer.DataPropertyName = dtDatos.Columns("DeaMer").ColumnName
                cStock.DataPropertyName = dtDatos.Columns("Stock").ColumnName
                cDespachar.DataPropertyName = dtDatos.Columns("Despachar").ColumnName
                cAtender.DataPropertyName = dtDatos.Columns("Atender").ColumnName
                cCodMer1.DataPropertyName = dtDatos.Columns("CodMer1").ColumnName
                cModMer.DataPropertyName = dtDatos.Columns("ModMer").ColumnName
                cCliente.DataPropertyName = dtDatos.Columns("Cliente").ColumnName
                cDesCli1.DataPropertyName = dtDatos.Columns("DesCli").ColumnName
                cDesEmp.DataPropertyName = dtDatos.Columns("DesEmp").ColumnName
                cRucEmp.DataPropertyName = dtDatos.Columns("RucEmp").ColumnName
                cSupervisor.DataPropertyName = dtDatos.Columns("Supervisor").ColumnName
                cPreMer.DataPropertyName = dtDatos.Columns("PreMer").ColumnName
                cNuevoCodigo.DataPropertyName = dtDatos.Columns("NuevoCodigo").ColumnName
                cStockNuevo.DataPropertyName = dtDatos.Columns("StockNuevo").ColumnName

                enableOpciones()
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.Click
        Try
            dgvDatos.Update()
            Dim dtTable As DataTable
            Dim rows As DataRow

            dtTable = dtDatos.Copy
            dtTable.Clear()

            For i As Integer = 0 To dtDatos.Rows.Count - 1
                ' For Each row As DataGridViewRow In dgvDatos.Rows

                ' Se recupera el campo que representa el checkbox, y se valida la seleccion
                ' agregandola a la lista temporal

                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                If toBoolean(cellSelecion.Value) = True Then
                    rows = dtTable.NewRow
                    rows(0) = dgvDatos.Rows(i).Cells(0).Value
                    rows(1) = dgvDatos.Rows(i).Cells(1).Value
                    rows(2) = dgvDatos.Rows(i).Cells(2).Value
                    rows(3) = dgvDatos.Rows(i).Cells(3).Value
                    rows(4) = dgvDatos.Rows(i).Cells(4).Value
                    rows(5) = dgvDatos.Rows(i).Cells(5).Value
                    rows(6) = dgvDatos.Rows(i).Cells(6).Value
                    rows(7) = dgvDatos.Rows(i).Cells(7).Value
                    rows(8) = dgvDatos.Rows(i).Cells(8).Value
                    rows(9) = dgvDatos.Rows(i).Cells(10).Value
                    rows(10) = dgvDatos.Rows(i).Cells(11).Value
                    rows(11) = dgvDatos.Rows(i).Cells(12).Value
                    rows(12) = dgvDatos.Rows(i).Cells(13).Value
                    rows(13) = dgvDatos.Rows(i).Cells(14).Value
                    rows(14) = dgvDatos.Rows(i).Cells(15).Value
                    rows(15) = dgvDatos.Rows(i).Cells(16).Value
                    rows(16) = dgvDatos.Rows(i).Cells(17).Value
                    rows(17) = dgvDatos.Rows(i).Cells(18).Value
                    rows(18) = dgvDatos.Rows(i).Cells(19).Value

                    dtTable.Rows.Add(rows)
                End If

            Next

            Dim forma As New frmReportes
            Dim reporte As New rpImprimirTicketServicios
            Dim dtReporte As New DataTable

            dtReporte = dtTable

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                Dim Impresora As String = SeleccionarImpresora()
                If Impresora <> "" Then

                    '===================== PRE SELECCIONAR ===================
                    For Each row As DataRow In dtReporte.Rows
                        oJobRepuestoService.PreSeleccion(row("CodJob"), row("CodMer"), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    Next
                    '==========================================================

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If

                    forma.Text = "Imprimir Ticket"

                    reporte.SetParameterValue("DesCli", DesCli)
                    reporte.SetParameterValue("DesEmp", oMaestro.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("DesMotor", "Modelo Motor:")
                    reporte.SetParameterValue("pUsuario", Session.sCodUsu)

                    reporte.PrintOptions.PrinterName = Impresora
                    reporte.PrintToPrinter(1, False, 0, 0)

                    'oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                End If

                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte

                'forma.Text = "Imprimir Ticket"

                'reporte.SetParameterValue("DesCli", DesCli)
                'reporte.SetParameterValue("DesEmp", oMaestro.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                'reporte.SetParameterValue("DesMotor", "Modelo Motor:")
                'reporte.SetParameterValue("pUsuario", Session.sCodUsu)
                ''ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                ''dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                ''forma.ShowDialog()
                'forma.crvReportes.PrintReport()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim dtTable As DataTable
            Dim rows As DataRow

            dtTable = dtDatos.Copy
            dtTable.Clear()

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                rows = dtTable.NewRow
                rows(0) = dgvDatos.Rows(i).Cells(0).Value
                rows(1) = dgvDatos.Rows(i).Cells(1).Value
                rows(2) = dgvDatos.Rows(i).Cells(2).Value
                rows(3) = dgvDatos.Rows(i).Cells(3).Value
                rows(4) = dgvDatos.Rows(i).Cells(4).Value
                rows(5) = dgvDatos.Rows(i).Cells(5).Value
                rows(6) = dgvDatos.Rows(i).Cells(6).Value
                rows(7) = dgvDatos.Rows(i).Cells(7).Value
                rows(8) = dgvDatos.Rows(i).Cells(8).Value
                rows(9) = dgvDatos.Rows(i).Cells(10).Value
                rows(10) = dgvDatos.Rows(i).Cells(11).Value
                rows(11) = dgvDatos.Rows(i).Cells(12).Value
                rows(12) = dgvDatos.Rows(i).Cells(13).Value
                rows(13) = dgvDatos.Rows(i).Cells(14).Value
                rows(14) = dgvDatos.Rows(i).Cells(15).Value
                rows(15) = dgvDatos.Rows(i).Cells(16).Value
                rows(16) = dgvDatos.Rows(i).Cells(17).Value
                rows(17) = dgvDatos.Rows(i).Cells(18).Value
                rows(18) = dgvDatos.Rows(i).Cells(19).Value

                dtTable.Rows.Add(rows)

            Next

            Dim forma As New frmReportes
            Dim reporte As New rpImprimirPedidoServicios
            Dim dtReporte As New DataTable

            dtReporte = dtTable

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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
                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("NumJob", NumJob)

                forma.Text = "Reporte de Pedidos de OT"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
    End Sub

    Private Sub cmbAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        listaDatos()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(9).Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(9).Value = False
        Next
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub cmbOficinas_ValueChanged(sender As Object, e As EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.Columns(2).DataMember = dtAlmacenes.Columns("AproDoc").ToString
            cmbIdLocacion.DropDownList.Columns(3).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            'dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub biImprimirTicketA4_Click(sender As Object, e As EventArgs) Handles biImprimirTicketA4.Click

        Try
            dgvDatos.Update()
            Dim dtTable As DataTable
            Dim rows As DataRow

            dtTable = dtDatos.Copy
            dtTable.Clear()

            For i As Integer = 0 To dtDatos.Rows.Count - 1
                ' For Each row As DataGridViewRow In dgvDatos.Rows

                ' Se recupera el campo que representa el checkbox, y se valida la seleccion
                ' agregandola a la lista temporal

                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                If toBoolean(cellSelecion.Value) = True Then
                    rows = dtTable.NewRow
                    rows(0) = dgvDatos.Rows(i).Cells(0).Value
                    rows(1) = dgvDatos.Rows(i).Cells(1).Value
                    rows(2) = dgvDatos.Rows(i).Cells(2).Value
                    rows(3) = dgvDatos.Rows(i).Cells(3).Value
                    rows(4) = dgvDatos.Rows(i).Cells(4).Value
                    rows(5) = dgvDatos.Rows(i).Cells(5).Value
                    rows(6) = dgvDatos.Rows(i).Cells(6).Value
                    rows(7) = dgvDatos.Rows(i).Cells(7).Value
                    rows(8) = dgvDatos.Rows(i).Cells(8).Value
                    rows(9) = dgvDatos.Rows(i).Cells(10).Value
                    rows(10) = dgvDatos.Rows(i).Cells(11).Value
                    rows(11) = dgvDatos.Rows(i).Cells(12).Value
                    rows(12) = dgvDatos.Rows(i).Cells(13).Value
                    rows(13) = dgvDatos.Rows(i).Cells(14).Value
                    rows(14) = dgvDatos.Rows(i).Cells(15).Value
                    rows(15) = dgvDatos.Rows(i).Cells(16).Value
                    rows(16) = dgvDatos.Rows(i).Cells(17).Value
                    rows(17) = dgvDatos.Rows(i).Cells(18).Value
                    rows(18) = dgvDatos.Rows(i).Cells(19).Value

                    dtTable.Rows.Add(rows)
                End If

            Next

            Dim forma As New frmReportes
            Dim reporte As New rpImprimirTicketServiciosA4
            Dim dtReporte As New DataTable

            dtReporte = dtTable

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                Dim Impresora As String = SeleccionarImpresora()
                If Impresora <> "" Then

                    '===================== PRE SELECCIONAR ===================
                    For Each row As DataRow In dtReporte.Rows
                        oJobRepuestoService.PreSeleccion(row("CodJob"), row("CodMer"), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    Next
                    '==========================================================

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If

                    forma.Text = "Imprimir Ticket"

                    reporte.SetParameterValue("DesCli", DesCli)
                    reporte.SetParameterValue("DesEmp", oMaestro.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("DesMotor", "Modelo Motor:")
                    reporte.SetParameterValue("pUsuario", Session.sCodUsu)

                    reporte.PrintOptions.PrinterName = Impresora
                    reporte.PrintToPrinter(1, False, 0, 0)

                    'oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                End If

                'reporte.SetDataSource(dtReporte)
                'forma.crvReportes.ReportSource = reporte

                'forma.Text = "Imprimir Ticket"

                'reporte.SetParameterValue("DesCli", DesCli)
                'reporte.SetParameterValue("DesEmp", oMaestro.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                'reporte.SetParameterValue("DesMotor", "Modelo Motor:")
                'reporte.SetParameterValue("pUsuario", Session.sCodUsu)
                ''ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                ''dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                ''forma.ShowDialog()
                'forma.crvReportes.PrintReport()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub
End Class