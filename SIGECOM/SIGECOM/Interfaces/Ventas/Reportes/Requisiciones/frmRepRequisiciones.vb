Imports System.ServiceModel
Public Class frmRepRequisiciones

    Private oMaestroService As New MaestroService.MaestroClient
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtEstados As DataTable
    Private dtRubros As DataTable
    'Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oRequisiciones As New RequisicionService.RequisicionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oProductoService As New ProductoService.ProductoServiceClient

    Private Sub frmRepRequisiciones_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oRequisiciones.Close()
            oSeguridadService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oRequisiciones.Abort()
            oSeguridadService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oRequisiciones.Abort()
            oSeguridadService.Abort()
            oProductoService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepRequisiciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 85)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If

        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        llenarCombos()

    End Sub
    Private Sub llenarCombos()
        dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
        cmbOficinas.DataSource = dtOficinas
        cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
        cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
        cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
        cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
        cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
        cmbOficinas.SelectedIndex = 0
        dtOficinas = Nothing

        '======================================= ESTADOS ================================================
        dtEstados = oRequisiciones.MostrarEstados
        dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
        cmbEstado.DataSource = dtEstados
        cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
        cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
        cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
        cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
        cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
        cmbEstado.SelectedIndex = 0
        dtEstados = Nothing

        '======================================= RUBROS ================================================
        dtRubros = oProductoService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
        dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
        cmbCodRub.DataSource = dtRubros
        cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
        cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
        cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
        cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
        cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
        cmbCodRub.SelectedIndex = 0
        dtRubros = Nothing

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

        Return fila
    End Function

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
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
    Private Sub frmRepRequisiciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(85, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptRequisiciones
            Dim reporteDetalle As New rptRequisicionesDetalle

            'Resumen
            If rbtnResumen.Checked = True Then
                dtReporte = oRequisiciones.Reporte(cmbIdLocacion.Value, cbFecInicio.Value, cbFecFinal.Value, 2, cmbEstado.Value, toBlank(cmbCodRub.Value)).Tables(0)

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                '    forma.crvReportes.ShowExportButton = True
                'Else
                '    forma.crvReportes.ShowExportButton = False
                'End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Reporte de Requisiciones"
                'Detallado
            ElseIf rbtnDetalle.Checked = True Then
                dtReporte = oRequisiciones.Reporte(cmbIdLocacion.Value, cbFecInicio.Value, cbFecFinal.Value, 1, cmbEstado.Value, toBlank(cmbCodRub.Value)).Tables(0)
                reporteDetalle.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporteDetalle

                'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                '    forma.crvReportes.ShowExportButton = True
                'Else
                '    forma.crvReportes.ShowExportButton = False
                'End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Reporte de Requisiciones Detallado"

            End If
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFin", cbFecFinal.Value)
                reporte.SetParameterValue("Estado", cmbEstado.Text)
                reporteDetalle.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporteDetalle.SetParameterValue("FecFin", cbFecFinal.Value)
                reporteDetalle.SetParameterValue("Estado", cmbEstado.Text)
                'reporte.SetParameterValue("Vendedor", cmbVendedor.Text)
                'reporte.SetParameterValue("Cliente", txtCliente.Text)
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmResumenRegVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    cbFecInicio.KeyPress _
                    , cbFecFinal.KeyPress _
        , cmbOficinas.KeyPress _
        , cmbIdLocacion.KeyPress _
        , cmbEstado.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub cmbCodRub_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodRub.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Select()
        End If
    End Sub


End Class