Imports System.ServiceModel

Public Class frmMovimAlmacen_Imprimir

    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public MovAlmacen As Integer
    Public IdLocacion As Integer


    Private Sub frmMovimAlmacen_Imprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMoviAlmacenService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMoviAlmacenService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMoviAlmacenService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmMovimAlmacen_Imprimir_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimAlmacen_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub rbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles rbOrdenCompra.CheckedChanged, rbFacturaLocal.CheckedChanged, rbConformidad.CheckedChanged
        If rbOrdenCompra.Checked Then
            gbConformidad.Enabled = False
            gbOrdenCompra.Enabled = True
        ElseIf rbFacturaLocal.Checked Then
            gbConformidad.Enabled = False
            gbOrdenCompra.Enabled = True
        ElseIf rbConformidad.Checked Then
            gbConformidad.Enabled = True
            gbOrdenCompra.Enabled = False
        End If

    End Sub

    'Private Sub rbFacturaLocal_CheckedChanged(sender As Object, e As EventArgs) Handles rbFacturaLocal.CheckedChanged
    '    gbOrdenCompra.Enabled = False
    'End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Imprinir()
    End Sub

    Private Sub Imprinir()

        Try

            Dim dtReporte As New DataView
            Dim dtConformidad As New DataTable
            Dim forma As New frmReportes
            Dim reporteMovAlmacen As New rptMovAlmacen
            Dim reporteMovAlmacenOC As New rptMovAlmacenOrdenCompra
            Dim reporteMovAlmacenFac As New rptMovAlmacenNumDoc
            Dim reporteMovAlmacenOCNoAgrupado As New rptMovAlmacenOrdenCompraNoAgrupado
            Dim reporteMovAlmacenConformidad As New rptMovAlmacenConformidad
            Dim reporteMovAlmacenNotaContabilidad As New rptMovAlmacenNotaContabilidad

            If rbFacturaLocal.Checked Then

                dtReporte = oMoviAlmacenService.Imprimir(MovAlmacen).Tables(0).DefaultView
                DataGridView1.DataSource = dtReporte

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    'Me.Close()
                Else
                    If rbtnPorCodigo.Checked Then

                        dtReporte.Sort = "CodMer Asc"

                        reporteMovAlmacen.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacen

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnPorDestino.Checked Then

                        dtReporte.Sort = "Observacion Asc"

                        reporteMovAlmacen.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacen

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnPorUbicacion.Checked Then

                        dtReporte.Sort = "UbiMer Asc"

                        reporteMovAlmacen.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacen

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    End If
                End If

            ElseIf rbOrdenCompra.Checked Then

                'Dim dtReporte2 As New DataTable

                'dtReporte2 = oMoviAlmacenService.ReportePendientes(Session.sCodEmp, toNumber(txtNumOrden.Text)).Tables(0)
                'DataGridView1.DataSource = dtReporte2

                dtReporte = oMoviAlmacenService.ReportePendientes(Session.sCodEmp, toNumber(txtNumOrden.Text)).Tables(0).DefaultView
                'DataGridView1.DataSource = dtReporte

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    'Me.Close()
                Else
                    If rbtnPorCodigo.Checked Then

                        dtReporte.Sort = "CodMer Asc"

                        reporteMovAlmacenOCNoAgrupado.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOCNoAgrupado

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnPorDestino.Checked Then

                        dtReporte.Sort = "Observacion Asc"

                        reporteMovAlmacenOCNoAgrupado.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOCNoAgrupado

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnPorUbicacion.Checked Then

                        dtReporte.Sort = "UbiMer Asc"

                        reporteMovAlmacenOCNoAgrupado.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOCNoAgrupado

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                        '======================== Imprimir por N° OrdenCompra ==============================================================================================
                    ElseIf rbtnCodigoAgrup.checked And gbPorOrdenCompraAgrup.Enabled = True Then

                        dtReporte.Sort = "CodMer Asc"

                        reporteMovAlmacenOC.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOC

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnDestinoAgrup.Checked And gbPorOrdenCompraAgrup.Enabled = True Then

                        dtReporte.Sort = "Observacion Asc"

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporteMovAlmacenOC.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOC

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnUbicacionAgrup.Checked And gbPorOrdenCompraAgrup.Enabled = True Then

                        dtReporte.Sort = "UbiMer Asc"

                        reporteMovAlmacenOC.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOC

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                        '======================== Imprimir por N° Factura ==============================================================================================
                    ElseIf rbtnfacCodigoAgrup.checked And gbPorNumFacAgrup.Enabled = True Then

                        dtReporte.Sort = "CodMer Asc"

                        reporteMovAlmacenFac.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenFac

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnFacDestinoAgrup.Checked And gbPorNumFacAgrup.Enabled = True Then

                        dtReporte.Sort = "Observacion Asc"

                        reporteMovAlmacenFac.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenFac

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    ElseIf rbtnFacUbicacionAgrup.Checked And gbPorNumFacAgrup.Enabled = True Then

                        dtReporte.Sort = "UbiMer Asc"

                        reporteMovAlmacenFac.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteMovAlmacenFac

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Movimiento Almacen"
                        forma.ShowDialog()

                    End If
                End If

            ElseIf rbConformidad.Checked Then

                dtConformidad = oMoviAlmacenService.ImprimirConformidad(toNumber(IdLocacion), txtFecDoc.Value).Tables(0)
                DataGridView1.DataSource = dtConformidad

                If dtConformidad.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else

                    reporteMovAlmacenConformidad.SetDataSource(dtConformidad)
                    forma.crvReportes.ReportSource = reporteMovAlmacenConformidad

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Movimiento Almacen - Conformidad"
                    forma.ShowDialog()
                End If

            ElseIf rbNotaContabilidad.Checked Then

                dtReporte = oMoviAlmacenService.Imprimir(MovAlmacen).Tables(0).DefaultView
                'DataGridView1.DataSource = dtReporte

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    'Me.Close()
                Else
                    reporteMovAlmacenNotaContabilidad.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteMovAlmacenNotaContabilidad

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Movimiento Almacen Nota Contabilidad"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbtnPorNumOrden_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorNumOrden.CheckedChanged
        gbPorOrdenCompraAgrup.Enabled = True
        gbPorNumFacAgrup.Enabled = False
    End Sub

    Private Sub rbtnPorCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorCodigo.CheckedChanged
        gbPorOrdenCompraAgrup.Enabled = False
        gbPorNumFacAgrup.Enabled = False
    End Sub

    Private Sub rbtnPorUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorUbicacion.CheckedChanged
        gbPorOrdenCompraAgrup.Enabled = False
        gbPorNumFacAgrup.Enabled = False
    End Sub

    Private Sub rbtnPorDestino_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorDestino.CheckedChanged
        gbPorOrdenCompraAgrup.Enabled = False
        gbPorNumFacAgrup.Enabled = False
    End Sub

    Private Sub rbtnPorNumFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPorNumFactura.CheckedChanged
        gbPorOrdenCompraAgrup.Enabled = False
        gbPorNumFacAgrup.Enabled = True
    End Sub
End Class