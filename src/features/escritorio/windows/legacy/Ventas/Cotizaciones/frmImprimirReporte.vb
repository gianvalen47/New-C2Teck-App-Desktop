Imports System.Globalization
Imports System.IO
Imports System.ServiceModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmImprimirReporte
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim forma As New frmReportes

    Dim reporte As New rpImprimirCotizacion
    Dim reporteSinPrecio As New rpImprimirCotizacionSinPrecio
    Dim reporteDscto As New rpImprimirCotizacionDscto
    Dim reporteDsctoSinPrecio As New rpImprimirCotizacionDsctoSinPrecio
    Dim reporteConStock As New rpImprimirCotizacionConStock

    Dim reportemtuamaz As New rpImprimirCotizacionMtuAmaz
    Dim reporteSinPreciomtuamaz As New rpImprimirCotizacionSinPrecioMtuAmaz
    Dim reporteDsctomtuamaz As New rpImprimirCotizacionDsctoMtuAmaz
    Dim reporteDsctoSinPreciomtuamaz As New rpImprimirCotizacionDsctoSinPrecioMtuAmaz
    Dim reporteConStockmtuamaz As New rpImprimirCotizacionConStockMtuAmaz

    Dim reporteequimap As New rpImprimirCotizacionEquimap
    Dim reporteSinPrecioequimap As New rpImprimirCotizacionSinPrecioEquimap
    Dim reporteDsctoequimap As New rpImprimirCotizacionDsctoEquimap
    Dim reporteDsctoSinPrecioequimap As New rpImprimirCotizacionDsctoSinPrecioEquimap
    Dim reporteConStockequimap As New rpImprimirCotizacionConStockEquimap

    Dim reportedefecto As New rpImprimirCotizacionDefecto
    Dim reporteSinPreciodefecto As New rpImprimirCotizacionSinPrecioDefecto
    Dim reporteDsctodefecto As New rpImprimirCotizacionDsctoDefecto
    Dim reporteDsctoSinPreciodefecto As New rpImprimirCotizacionDsctoSinPrecioDefecto
    Dim reporteConStockdefecto As New rpImprimirCotizacionConStockDefecto

    Dim reportec2teck As New rpImprimirCotizacionC2Teck
    Dim reporteSinPrecioc2teck As New rpImprimirCotizacionSinPrecioC2Teck
    Dim reporteDsctoc2teck As New rpImprimirCotizacionDsctoC2Teck
    Dim reporteDsctoSinPrecioc2teck As New rpImprimirCotizacionDsctoSinPrecioC2Teck
    Dim reporteConStockc2teck As New rpImprimirCotizacionConStockC2Teck

    Dim reportec2teckIM As New rpImprimirCotizacionC2TeckIM
    'Dim reportec2teckIM As New rpImprimirCotizacionC2TeckIMNuevo
    Dim reporteSinPrecioc2teckIM As New rpImprimirCotizacionSinPrecioC2TeckIM
    Dim reporteDsctoc2teckIM As New rpImprimirCotizacionDsctoC2TeckIM
    Dim reporteDsctoSinPrecioc2teckIM As New rpImprimirCotizacionDsctoSinPrecioC2TeckIM
    Dim reporteConStockc2teckIM As New rpImprimirCotizacionConStockC2TeckIM


    Dim dtReporte As New DataTable
    Public idCotizar As Integer
    Public NumCot As String
    Public IdCliente As Integer

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click, Button6.Click, Button3.Click, Button1.Click
        Try
            dtReporte = oCotizacionService.Imprimir(idCotizar, IIf(rbStockAlmPrin.Checked = True, True, False)).Tables(0)

            If Session.sCodEmp = "01" Then

                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDscto.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDscto
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()

                        forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecio.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteSinPrecio
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecio.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoSinPrecio
                        End If


                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStock.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteConStock

                    End If


                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Cotización"
                    Me.Close()
                    forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "02" Then

                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportemtuamaz.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reportemtuamaz
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctomtuamaz.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctomtuamaz
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()

                        forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPreciomtuamaz.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteSinPreciomtuamaz
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPreciomtuamaz.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoSinPreciomtuamaz
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockmtuamaz.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteConStockmtuamaz
                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Cotización"
                    Me.Close()
                    forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "05" Then       '================================== Reporte Equimap   =======================================


                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteequimap.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteequimap
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoequimap.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoequimap
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()

                        forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecioequimap.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteSinPrecioequimap
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecioequimap.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoSinPrecioequimap
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockequimap.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteConStockequimap
                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Cotización"
                    Me.Close()
                    forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "07" Then       '================================== Reporte c2teck   =======================================


                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecioc2teck.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteSinPrecioc2teck

                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoc2teck.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoc2teck
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()

                        forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportec2teck.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reportec2teck
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecioc2teck.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoSinPrecioc2teck
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockc2teck.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteConStockc2teck
                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Cotización"
                    Me.Close()
                    forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "08" Then       '================================== Reporte c2teck IM  =======================================

                Dim numcot As String
                Dim fechalarga As String
                numcot = dtReporte.Rows(0).Item("NumCot").ToString()

                If Len(numcot) = 1 Then
                    numcot = "0" + numcot
                End If

                fechalarga = Format(dtReporte.Rows(0).Item("Fecha"), "Long Date")

                Dim c As CultureInfo = New CultureInfo("es-MX")
                'Dim c As CultureInfo = New CultureInfo("it-IT")
                Dim format2 As DateTimeFormatInfo = c.DateTimeFormat
                Dim f As Date = CDate(dtReporte.Rows(0).Item("Fecha")) 'New Date()
                'el método ToString recibe como parámetro el formato de salida, y el formato de cultura
                fechalarga = f.ToString("D", format2)

                'fechalarga = Format(dtReporte.Rows(0).Item("Fecha"), "Long Date")

                'DateTime date1 = New DateTime(dtReporte.Rows(0).Item("Fecha"))
                'fechalarga = dtReporte.Rows(0).Item("Fecha").ToString()
                'fechalarga = dtReporte.Rows(0).Item("Fecha").ToString("D", CultureInfo.CreateSpecificCulture("es-MX"))

                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecioc2teckIM.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteSinPrecioc2teckIM
                            reporteSinPrecioc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reporteSinPrecioc2teckIM.SetParameterValue("pFechaL", fechalarga)
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoc2teckIM.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoc2teckIM
                            reporteDsctoc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reporteDsctoc2teckIM.SetParameterValue("pFechaL", fechalarga)

                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()

                        forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportec2teckIM.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reportec2teckIM
                            reportec2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reportec2teckIM.SetParameterValue("pFechaL", fechalarga)

                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecioc2teckIM.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoSinPrecioc2teckIM
                            reporteDsctoSinPrecioc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reporteDsctoSinPrecioc2teckIM.SetParameterValue("pFechaL", fechalarga)
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockc2teckIM.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteConStockc2teckIM
                        reporteConStockc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                        'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                        reporteConStockc2teckIM.SetParameterValue("pFechaL", fechalarga)
                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Cotización"
                    Me.Close()
                    forma.ShowDialog()
                End If

            Else   '================================== Reporte Default cuando no hay logo de la empresa  =======================================


                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportedefecto.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reportedefecto
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctodefecto.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctodefecto
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()

                        forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPreciodefecto.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteSinPreciodefecto
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPreciodefecto.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteDsctoSinPreciodefecto
                        End If

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockdefecto.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteConStockdefecto

                    End If

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Cotización"
                    Me.Close()
                    forma.ShowDialog()
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Imprimir")
        End Try

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click, Button5.Click, Button4.Click, Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmImprimirReporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         rbtnConCodigo.KeyPress _
                      , btnAceptar.KeyPress, Button6.KeyPress, Button3.KeyPress, Button1.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmImprimirReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session.sCodEmp = "07" Then
            rbtnSinCodigo.Select()
        End If

    End Sub

    Private Sub cbStockNinguno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbStockNinguno.CheckedChanged, rbStockAlmPrin.CheckedChanged, rbStockAlmCoti.CheckedChanged

        If rbStockAlmPrin.Checked = True Then

            rbtnConCodigo.Enabled = False
            rbtnSinCodigo.Enabled = False
            cbMostrarDscto.Enabled = False

            rbtnConCodigo.Checked = False
            rbtnSinCodigo.Checked = False
            cbMostrarDscto.Checked = False

            rbStockAlmCoti.Checked = False

        ElseIf rbStockAlmCoti.Checked = True Then

            rbtnConCodigo.Enabled = False
            rbtnSinCodigo.Enabled = False
            cbMostrarDscto.Enabled = False

            rbtnConCodigo.Checked = False
            rbtnSinCodigo.Checked = False
            cbMostrarDscto.Checked = False

            rbStockAlmPrin.Checked = False

        Else
            rbtnConCodigo.Enabled = True
            rbtnSinCodigo.Enabled = True
            cbMostrarDscto.Enabled = True

            rbtnConCodigo.Checked = False
            rbtnSinCodigo.Checked = False
            cbMostrarDscto.Checked = False

        End If

    End Sub

    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click

        CrearCarpeta()

        Try
            dtReporte = oCotizacionService.Imprimir(idCotizar, IIf(rbStockAlmPrin.Checked = True, True, False)).Tables(0)

            If Session.sCodEmp = "01" Then

                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporte.SetDataSource(dtReporte)
                            ExportToPDF(reporte, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporte
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDscto.SetDataSource(dtReporte)
                            ExportToPDF(reporteDscto, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDscto
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()

                        'forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecio.SetDataSource(dtReporte)
                            ExportToPDF(reporteSinPrecio, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteSinPrecio
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecio.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoSinPrecio, "Cotizacion.pdf", NumCot)
                        End If


                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()
                        'forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStock.SetDataSource(dtReporte)
                        ExportToPDF(reporteDsctoSinPrecio, "Cotizacion.pdf", NumCot)
                        'forma.crvReportes.ReportSource = reporteConStock

                    End If


                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    ''forma.crvReportes.RefreshReport = False
                    ''forma.crvReportes.DisplayGroupTree = False

                    'forma.Text = "Imprimir Cotización"
                    'Me.Close()
                    'forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "02" Then

                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportemtuamaz.SetDataSource(dtReporte)
                            ExportToPDF(reportemtuamaz, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reportemtuamaz
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctomtuamaz.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctomtuamaz, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctomtuamaz
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()

                        'forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPreciomtuamaz.SetDataSource(dtReporte)
                            ExportToPDF(reporteSinPreciomtuamaz, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteSinPreciomtuamaz
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPreciomtuamaz.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoSinPreciomtuamaz, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctoSinPreciomtuamaz
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización"
                        Me.Close()
                        forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockmtuamaz.SetDataSource(dtReporte)
                        ExportToPDF(reporteConStockmtuamaz, "Cotizacion.pdf", NumCot)
                        'forma.crvReportes.ReportSource = reporteConStockmtuamaz
                    End If

                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    'forma.Text = "Imprimir Cotización"
                    'Me.Close()
                    'forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "05" Then       '================================== Reporte Equimap   =======================================


                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteequimap.SetDataSource(dtReporte)
                            ExportToPDF(reporteequimap, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteequimap
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoequimap.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoequimap, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctoequimap
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()

                        'forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecioequimap.SetDataSource(dtReporte)
                            ExportToPDF(reporteSinPrecioequimap, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteSinPrecioequimap
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecioequimap.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoSinPrecioequimap, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctoSinPrecioequimap
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()
                        'forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockequimap.SetDataSource(dtReporte)
                        ExportToPDF(reporteConStockequimap, "Cotizacion.pdf", NumCot)
                        'forma.crvReportes.ReportSource = reporteConStockequimap
                    End If

                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    ''forma.crvReportes.RefreshReport = False
                    ''forma.crvReportes.DisplayGroupTree = False

                    'forma.Text = "Imprimir Cotización"
                    'Me.Close()
                    'forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "07" Then       '================================== Reporte c2teck   =======================================


                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecioc2teck.SetDataSource(dtReporte)
                            ExportToPDF(reporteSinPrecioc2teck, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteSinPrecioc2teck

                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoc2teck.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoc2teck, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctoc2teck
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()

                        'forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportec2teck.SetDataSource(dtReporte)
                            ExportToPDF(reportec2teck, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reportec2teck
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecioc2teck.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoSinPrecioc2teck, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctoSinPrecioc2teck
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()
                        'forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockc2teck.SetDataSource(dtReporte)
                        ExportToPDF(reporteConStockc2teck, "Cotizacion.pdf", NumCot)
                        'forma.crvReportes.ReportSource = reporteConStockc2teck
                    End If

                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    ''forma.crvReportes.RefreshReport = False
                    ''forma.crvReportes.DisplayGroupTree = False

                    'forma.Text = "Imprimir Cotización"
                    'Me.Close()
                    'forma.ShowDialog()
                End If

            ElseIf Session.sCodEmp = "08" Then       '================================== Reporte c2teck IM  =======================================

                Dim numcot1 As String
                'Dim NumCotizacion As String
                Dim fechalarga As String
                'NumCotizacion = NumCot
                numcot1 = dtReporte.Rows(0).Item("NumCot").ToString()

                If Len(NumCot) = 1 Then
                    numcot1 = "0" + numcot1
                End If

                fechalarga = Format(dtReporte.Rows(0).Item("Fecha"), "Long Date")

                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPrecioc2teckIM.SetDataSource(dtReporte)
                            'forma.crvReportes.ReportSource = reporteSinPrecioc2teckIM
                            reporteSinPrecioc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot1 + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reporteSinPrecioc2teckIM.SetParameterValue("pFechaL", fechalarga)
                            ExportToPDF(reporteSinPrecioc2teckIM, "Cotizacion.pdf", NumCot)
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoc2teckIM.SetDataSource(dtReporte)
                            'forma.crvReportes.ReportSource = reporteDsctoc2teckIM
                            reporteDsctoc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot1 + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reporteDsctoc2teckIM.SetParameterValue("pFechaL", fechalarga)
                            ExportToPDF(reporteDsctoc2teckIM, "Cotizacion.pdf", NumCot)
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()

                        'forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportec2teckIM.SetDataSource(dtReporte)
                            'forma.crvReportes.ReportSource = reportec2teckIM
                            reportec2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot1 + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reportec2teckIM.SetParameterValue("pFechaL", fechalarga)
                            ExportToPDF(reportec2teckIM, "Cotizacion.pdf", NumCot)
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPrecioc2teckIM.SetDataSource(dtReporte)
                            'forma.crvReportes.ReportSource = reporteDsctoSinPrecioc2teckIM
                            reporteDsctoSinPrecioc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot1 + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                            'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                            reporteDsctoSinPrecioc2teckIM.SetParameterValue("pFechaL", fechalarga)
                            ExportToPDF(reporteDsctoSinPrecioc2teckIM, "Cotizacion.pdf", NumCot)
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()
                        'forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockc2teckIM.SetDataSource(dtReporte)
                        'forma.crvReportes.ReportSource = reporteConStockc2teckIM
                        reporteConStockc2teckIM.SetParameterValue("pTitulo", "COTIZACIÓN " + numcot1 + "-" + Year(dtReporte.Rows(0).Item("Fecha")).ToString())
                        'reportec2teckIM.SetParameterValue("pFechaL", UCase(fechalarga))
                        reporteConStockc2teckIM.SetParameterValue("pFechaL", fechalarga)
                        ExportToPDF(reporteConStockc2teckIM, "Cotizacion.pdf", NumCot)
                    End If

                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    ''forma.crvReportes.RefreshReport = False
                    ''forma.crvReportes.DisplayGroupTree = False

                    'forma.Text = "Imprimir Cotización"
                    'Me.Close()
                    'forma.ShowDialog()
                End If

            Else   '================================== Reporte Default cuando no hay logo de la empresa  =======================================


                If rbtnConCodigo.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reportedefecto.SetDataSource(dtReporte)
                            ExportToPDF(reportedefecto, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reportedefecto
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctodefecto.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctodefecto, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctodefecto
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()

                        'forma.ShowDialog()
                    End If
                End If

                If rbtnSinCodigo.Checked = True Then

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If cbMostrarDscto.Checked = False Then
                            reporteSinPreciodefecto.SetDataSource(dtReporte)
                            ExportToPDF(reporteSinPreciodefecto, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteSinPreciodefecto
                        ElseIf cbMostrarDscto.Checked = True Then
                            reporteDsctoSinPreciodefecto.SetDataSource(dtReporte)
                            ExportToPDF(reporteDsctoSinPreciodefecto, "Cotizacion.pdf", NumCot)
                            'forma.crvReportes.ReportSource = reporteDsctoSinPreciodefecto
                        End If

                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        ''forma.crvReportes.RefreshReport = False
                        ''forma.crvReportes.DisplayGroupTree = False

                        'forma.Text = "Imprimir Cotización"
                        'Me.Close()
                        'forma.ShowDialog()
                    End If

                End If

                If rbStockAlmPrin.Checked = True Or rbStockAlmCoti.Checked = True Then
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporteConStockdefecto.SetDataSource(dtReporte)
                        ExportToPDF(reporteConStockdefecto, "Cotizacion.pdf", NumCot)
                        'forma.crvReportes.ReportSource = reporteConStockdefecto

                    End If

                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    ''forma.crvReportes.RefreshReport = False
                    ''forma.crvReportes.DisplayGroupTree = False

                    'forma.Text = "Imprimir Cotización"
                    'Me.Close()
                    'forma.ShowDialog()
                End If


            End If


            Dim frm As New frmCotizacion_EnviarCorreo

            frm.NumDoc = NumCot
            frm.IdCliente = IdCliente

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Imprimir")
        End Try



    End Sub

    Private Sub CrearCarpeta()
        Try

            If Not Directory.Exists("D:\Documentos_Electronicos\Cotizaciones\" & NumCot) Then
                Directory.CreateDirectory("D:\Documentos_Electronicos\Cotizaciones\" & NumCot)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Public Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, codigo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try

            'Dim idcodigo As String = dgvDatos.CurrentRow.Cells("IdPer").Value
            Dim NumCotizacion As String
            NumCotizacion = "Cotización " & codigo

            diskOpts.DiskFileName = "D:\Documentos_Electronicos\Cotizaciones\" & codigo & "\" & NumCotizacion & ".pdf"

            rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            'diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()
        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function


End Class