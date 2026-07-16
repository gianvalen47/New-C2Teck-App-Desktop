Imports System.ServiceModel
Public Class frmRepReembolsoxGasto

    '===========================Servicios====================================================
    Private oReembolsoCajaService As New ReembolsoCajaService.ReembolsoCajaServiceClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    '======================Declaración de Variables==============================
    Private dtUbicacion As DataTable
    Private dtAreas As DataTable
    Private dtTipoGasto As DataTable
    Private dtUnidad As DataTable
    Private dtUnidades As DataTable

    Private Sub frmReembolsoxGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oReembolsoCajaService.Close()
            oReembolsoCajaDetService.Close()
            oProvisionalService.Close()
            oMaestroService.Close()
            oVehiculoService.Close()
            oSeguridadService.Close()
            oCentroCostoService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaService.Abort()
            oReembolsoCajaDetService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaService.Abort()
            oReembolsoCajaDetService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
        End Try
    End Sub

    Private Sub frmReembolsoxGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReembolsoxGasto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 152)
        '/*************************************************************************************/

        txtFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFecFinal.Value = Date.Today
        llenarCombos()
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = "(Todos)"
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
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

    Private Sub llenarCombos()
        Try

            ''======================================= PLACA ===============================================
            dtUnidad = oVehiculoService.MostrarUnidades.Tables(0)
            dtUnidad.Rows.InsertAt(getRowTodos(dtUnidad), 0)
            cmbPlaca.DataSource = dtUnidad
            cmbPlaca.DropDownList.DataMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtUnidad = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos1(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

            ''======================================= AREAS ================================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'dtAreas.Rows.InsertAt(getRowTodos1(dtAreas), 0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.SelectedIndex = 0
            'dtAreas = Nothing

            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            dtTipoGasto.Rows.InsertAt(getRowTodos(dtTipoGasto), 0)
            cmbTipoGasto.DataSource = dtTipoGasto
            cmbTipoGasto.DropDownList.DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.DisplayMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.ValueMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(0).DataMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(1).DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.SelectedIndex = 0
            dtTipoGasto = Nothing

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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidarCampos() As Boolean
        If txtFecInicio.Value > txtFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            txtFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarCampos() Then
            oSeguridadService.RegistrarVisitaOpciones(152, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            MostrarReporte()
        End If
    End Sub

    Private Sub MostrarReporte()
        Try
            If rbDetallado.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptRepReembolsoxGasto

                dtReporte = oReembolsoCajaService.ReporteReembolso(txtFecInicio.Value, txtFecFinal.Value, cmbUbicacion.Value, cmbTipoGasto.Value, cmbUnidad.Value, cmbArea.Value, IIf(cmbPlaca.Value = "(Todos)", "", cmbPlaca.Value), toNumber(txtNumReembolso.Text)).Tables(0)

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
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Pagos de Cuentas x Pagar Detallado"
                    reporte.SetParameterValue("pFechaInicio", txtFecInicio.Value)
                    reporte.SetParameterValue("pFechaFin", txtFecFinal.Value)
                    reporte.SetParameterValue("pUbicacion", cmbUbicacion.Text)
                    reporte.SetParameterValue("pUnidadNegocio", cmbUnidad.Text)
                    reporte.SetParameterValue("pArea", IIf(toBlank(cmbArea.Value) <> "", cmbArea.Text, "(Todos)"))
                    reporte.SetParameterValue("pTipoGasto", IIf(toBlank(cmbTipoGasto.Value) <> "", cmbTipoGasto.Text, "(Todos)"))
                    reporte.SetParameterValue("pPlaca", cmbPlaca.Text)
                    reporte.SetParameterValue("pNumReembolso", IIf(toBlank(txtNumReembolso.Text) <> "", txtNumReembolso.Text, "(Todos)"))
                    forma.ShowDialog()
                End If

            ElseIf rbTotalizado.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptRepReembolsoTotalizado

                dtReporte = oReembolsoCajaService.ReporteReembolso(txtFecInicio.Value, txtFecFinal.Value, cmbUbicacion.Value, cmbTipoGasto.Value, cmbUnidad.Value, cmbArea.Value, IIf(cmbPlaca.Value = "(Todos)", "", cmbPlaca.Value), toNumber(txtNumReembolso.Text)).Tables(0)

                Dim rowf As DataRow
                Dim dtFinal As DataTable

                Dim dtCopia As New DataTable("tabla")

                dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))
                dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
                dtCopia.Columns.Add(New DataColumn("IdReembolso", Type.GetType("System.Int32")))
                dtCopia.Columns.Add(New DataColumn("Numero", Type.GetType("System.Int32")))
                dtCopia.Columns.Add(New DataColumn("Fecha", Type.GetType("System.DateTime")))
                dtCopia.Columns.Add(New DataColumn("Importe", Type.GetType("System.Double")))
                dtCopia.Columns.Add(New DataColumn("CodMon", Type.GetType("System.String")))
                dtCopia.Columns.Add(New DataColumn("TotNeto", Type.GetType("System.Double")))
                dtCopia.Columns.Add(New DataColumn("ImporteSerCom", Type.GetType("System.Double")))
                dtCopia.Columns.Add(New DataColumn("ImporteOtros", Type.GetType("System.Double")))
                dtCopia.Columns.Add(New DataColumn("ObsReembolso", Type.GetType("System.String")))

                dtCopia.Rows.Add(New Object() {"", "", "0", "0", "01/01/2012", "0.00", "", "0.00", "0.00", "0.00", "observacion"})

                dtFinal = dtCopia.Copy
                dtFinal.Clear()

                For Each row As DataRow In dtReporte.Rows

                    rowf = dtFinal.NewRow

                    If (row("IdUnidad")) = "2" Or (row("IdUnidad")) = 3 Then

                        rowf(0) = row("RucEmp")
                        rowf(1) = row("DesEmp")
                        rowf(2) = row("IdReembolso")
                        rowf(3) = row("Numero")
                        rowf(4) = row("Fecha")
                        rowf(5) = row("Importe")
                        rowf(6) = row("CodMon")
                        rowf(7) = row("TotNeto")
                        rowf(8) = row("Importe")
                        rowf(9) = 0
                        rowf(10) = row("ObsRembolso")

                    Else

                        rowf(0) = row("RucEmp")
                        rowf(1) = row("DesEmp")
                        rowf(2) = row("IdReembolso")
                        rowf(3) = row("Numero")
                        rowf(4) = row("Fecha")
                        rowf(5) = row("Importe")
                        rowf(6) = row("CodMon")
                        rowf(7) = row("TotNeto")
                        rowf(8) = 0
                        rowf(9) = row("Importe")
                        rowf(10) = row("ObsRembolso")

                    End If

                    dtFinal.Rows.Add(rowf)

                Next

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    'reporte.SetDataSource(dtReporte)
                    reporte.SetDataSource(dtFinal)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Pagos de Cuentas x Pagar Detallado"
                    reporte.SetParameterValue("pFechaInicio", txtFecInicio.Value)
                    reporte.SetParameterValue("pFechaFin", txtFecFinal.Value)
                    reporte.SetParameterValue("pUbicacion", cmbUbicacion.Text)
                    reporte.SetParameterValue("pUnidadNegocio", cmbUnidad.Text)
                    reporte.SetParameterValue("pArea", IIf(toBlank(cmbArea.Value) <> "", cmbArea.Text, "(Todos)"))
                    reporte.SetParameterValue("pTipoGasto", IIf(toBlank(cmbTipoGasto.Value) <> "", cmbTipoGasto.Text, "(Todos)"))
                    reporte.SetParameterValue("pPlaca", cmbPlaca.Text)
                    reporte.SetParameterValue("pNumReembolso", IIf(toBlank(txtNumReembolso.Text) <> "", txtNumReembolso.Text, "(Todos)"))
                    forma.ShowDialog()
                End If
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumReembolso.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cmbUnidad_ValueChanged(sender As Object, e As EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos1(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub rbDetallado_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbDetallado.CheckedChanged, rbTotalizado.CheckedChanged
    '    If rbDetallado.Checked = True Then
    '        cmbTipoGasto.Enabled = True
    '        cmbPlaca.Enabled = True
    '        cmbUnidad.Enabled = True
    '        cmbArea.Enabled = True
    '    Else
    '        cmbTipoGasto.SelectedIndex = 0
    '        cmbTipoGasto.Enabled = False
    '        cmbPlaca.SelectedIndex = 0
    '        cmbPlaca.Enabled = False
    '        cmbUnidad.SelectedIndex = 0
    '        cmbUnidad.Enabled = False
    '        cmbArea.SelectedIndex = 0
    '        cmbArea.Enabled = False
    '    End If
    'End Sub
End Class