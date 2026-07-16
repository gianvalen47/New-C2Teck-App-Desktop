Imports System.ServiceModel

Public Class frmRepMovimientosAlmacen

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient

    Private dtoficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtMovimientos As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtRubros As DataTable
    Dim codMar As String


    Private Sub frmRepMovimientosAlmacen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oMaestro.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oMaestro.Close()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepMovimientosAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepMovimientosAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        cmbCodMov.Value = "(Todos)"
        llenarCombos()

    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtoficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtoficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtoficinas = Nothing

            '======================================= MOVIMIENTOS ===============================================
            dtMovimientos = oMaestro.MostrarMovimiento.Tables(0)
            dtMovimientos.Rows.InsertAt(getRowTodos(dtMovimientos), 0)
            cmbCodMov.DataSource = dtMovimientos
            cmbCodMov.DropDownList.DataMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.DisplayMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.ValueMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(0).DataMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(1).DataMember = dtMovimientos.Columns("DesMov").ToString
            dtMovimientos = Nothing

            '======================================= TIPO MOVIMIENTOS ===============================================
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"H", "INGRESOS"})
            dtTipoMovimientos.Rows.Add(New Object() {"D", "SALIDAS"})
            dtTipoMovimientos.Rows.Add(New Object() {"C", "COSTOS"})
            cmbTipoMovimiento.DataSource = dtTipoMovimientos
            cmbTipoMovimiento.DisplayMember = "Nombre"
            cmbTipoMovimiento.ValueMember = "Tipo"
            cmbTipoMovimiento.DropDownList.Columns(0).DataMember = "Tipo"
            cmbTipoMovimiento.DropDownList.Columns(1).DataMember = "Nombre"
            cmbTipoMovimiento.SelectedIndex = 0
            dtTipoMovimientos = Nothing

            '======================================= RUBROS ================================================
            dtRubros = oMaestro.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function
    Private Sub MostrarReporte()

        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepMovimientosAlmacen
            Dim reporte2 As New rpRepMovimientosAlmacen2   'Cambio hecho el 28/02/2013 por solicitud de usuario N° 2916
            Dim dtReporte As New DataView

            dtReporte = oLocacionMercaderiaService.ReporteMovimientos(cbFecInicio.Value, cbFecFinal.Value, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), cmbTipoMovimiento.Value, txtUbiMer.Text, cmbCodRub.Value, IIf(cbUbicacion.Checked = True, 2, 1)).Tables(0).DefaultView
            'dtReporte = oLocacionMercaderiaService.ReporteMovimientos(Today, Today, "1", "", "", "D", "").Tables(0)

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If cbBajoMaximo.Checked Then
                    dtReporte.RowFilter = "Stock < MaxMer"
                End If

                If rbFormato1.Checked Then

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Movimientos de Almacen"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte.SetParameterValue("TipMov", "Ingresos")
                        Case "D"
                            reporte.SetParameterValue("TipMov", "Salidas")
                        Case "C"
                            reporte.SetParameterValue("TipMov", "Costos")
                    End Select

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Marca", txtMarca.Text)
                    reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    reporte.SetParameterValue("Movimiento", cmbCodMov.Text)
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepMovimientosAlmacen.xml")

                    forma.ShowDialog()

                Else

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Movimientos de Almacen"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte2.SetParameterValue("TipMov", "Ingresos")
                        Case "D"
                            reporte2.SetParameterValue("TipMov", "Salidas")
                        Case "C"
                            reporte2.SetParameterValue("TipMov", "Costos")
                    End Select

                    reporte2.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte2.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte2.SetParameterValue("Marca", txtMarca.Text)
                    reporte2.SetParameterValue("Rubro", cmbCodRub.Text)
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepMovimientosAlmacen.xml")

                    forma.ShowDialog()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cmbIdLocacion.ValueChanged

    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnBuscaMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbMarca.Checked = False
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            codMar = frm.codigo
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Year(cbFecInicio.Value) <> Year(cbFecFinal.Value) Then
            MsgBox("Las fechas deben pertenecer al mismo año")
        Else
            MostrarReporte()
        End If

    End Sub

    Private Sub rbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMarca.CheckedChanged
        txtMarca.Text = ""
    End Sub

End Class