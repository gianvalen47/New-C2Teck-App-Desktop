Imports System.ServiceModel

Public Class frmServicios_CotizacionReportes
    Private state_search As Boolean
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Public idCotizacionRep As String
    Public idPer As Integer
    Public idPerDelegado As Integer

    Private Sub frmServicios_CotizacionReportes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub frmServicios_CotizacionReportes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_CotizacionReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        optResumido.Checked = True
        cbNoMostrarCodigo.Checked = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dtReporte As DataTable

        If Session.sCodEmp = "01" Then

            If optResumido.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacion
                    Dim IdPersonal As Integer
                    Dim registro As CotizacionServicioService.CotizacionServicio
                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    If rbVendedor.Checked = True Then
                        IdPersonal = idPer
                    ElseIf rbSupervisor.Checked = True Then
                        IdPersonal = idPerDelegado
                    End If

                    dtReporte = oCotizacionServicioService.Imprimir(idCotizacionRep, IdPersonal).Tables(0)

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

                        reporte.SetParameterValue("pSerie", IIf(registro.CodMer = Nothing, "", "Serie " & registro.CodMer))
                        reporte.SetParameterValue("pModelo", IIf(registro.ModMer = Nothing, "", " Modelo " & registro.ModMer))
                        reporte.SetParameterValue("pUnidad", IIf(registro.Unidad = Nothing, "", registro.Unidad))
                        reporte.SetParameterValue("pGarantia", oCotizacionServicioService.Garantia(idCotizacionRep))

                        If registro.CodProveedor = "004" Then
                            reporte.SetParameterValue("pCodProveedor", "")
                        Else
                            reporte.SetParameterValue("pCodProveedor", "                    ")
                        End If

                        forma.Text = "Imprimir Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try

            ElseIf optDetallado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionDetalle
                    Dim registro As CotizacionServicioService.CotizacionServicio

                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    dtReporte = oCotizacionServicioService.ImprimirRepuestos(idCotizacionRep).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        reporte.SetParameterValue("pCodMantenimiento", registro.TipoMantenimiento.CodMantenimiento)
                        reporte.SetParameterValue("pDesEmp", Session.sDesEmp)
                        forma.crvReportes.ReportSource = reporte
                        'Validar por usuario - Exportar Excel 
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try

            ElseIf optConsolidado.Checked = True Then

                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionConsolidado
                    Dim dtSubreporte As DataTable
                    Dim IdPersonal As Integer
                    Dim registro As CotizacionServicioService.CotizacionServicio
                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    If rbVendedor.Checked = True Then
                        IdPersonal = idPer
                    ElseIf rbSupervisor.Checked = True Then
                        IdPersonal = idPerDelegado
                    End If

                    dtReporte = oCotizacionServicioService.Imprimir(idCotizacionRep, IdPersonal).Tables(0)
                    dtSubreporte = oCotizacionServicioService.ImprimirRepuestos(idCotizacionRep).Tables(0)

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                        reporte.SetParameterValue("pSerie", IIf(registro.CodMer = Nothing, "", "Serie " & registro.CodMer))
                        reporte.SetParameterValue("pModelo", IIf(registro.ModMer = Nothing, "", " Modelo " & registro.ModMer))
                        reporte.SetParameterValue("pUnidad", IIf(registro.Unidad = Nothing, "", registro.Unidad))
                        reporte.SetParameterValue("pGarantia", oCotizacionServicioService.Garantia(idCotizacionRep))

                        If registro.CodProveedor = "004" Then
                            reporte.SetParameterValue("pCodProveedor", "")
                        Else
                            reporte.SetParameterValue("pCodProveedor", "                    ")
                        End If

                        forma.Text = "Imprimir Consolidado de Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If

        ElseIf Session.sCodEmp = "02" Then

            If optResumido.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionMtuAmaz
                    Dim IdPersonal As Integer
                    Dim registro As CotizacionServicioService.CotizacionServicio
                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    If rbVendedor.Checked = True Then
                        IdPersonal = idPer
                    ElseIf rbSupervisor.Checked = True Then
                        IdPersonal = idPerDelegado
                    End If

                    dtReporte = oCotizacionServicioService.Imprimir(idCotizacionRep, IdPersonal).Tables(0)

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

                        reporte.SetParameterValue("pSerie", IIf(registro.CodMer = Nothing, "", "Serie " & registro.CodMer))
                        reporte.SetParameterValue("pModelo", IIf(registro.ModMer = Nothing, "", " Modelo " & registro.ModMer))
                        reporte.SetParameterValue("pUnidad", IIf(registro.Unidad = Nothing, "", registro.Unidad))
                        reporte.SetParameterValue("pGarantia", oCotizacionServicioService.Garantia(idCotizacionRep))

                        If registro.CodProveedor = "004" Then
                            reporte.SetParameterValue("pCodProveedor", "")
                        Else
                            reporte.SetParameterValue("pCodProveedor", "                    ")
                        End If

                        forma.Text = "Imprimir Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try

            ElseIf optDetallado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionDetalleMtuAmaz
                    Dim registro As CotizacionServicioService.CotizacionServicio

                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    dtReporte = oCotizacionServicioService.ImprimirRepuestos(idCotizacionRep).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        reporte.SetParameterValue("pCodMantenimiento", registro.TipoMantenimiento.CodMantenimiento)
                        reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"))
                        forma.crvReportes.ReportSource = reporte
                        'Validar por usuario - Exportar Excel 
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try

            ElseIf optConsolidado.Checked = True Then

                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionConsolidadoMtuAmaz
                    Dim dtSubreporte As DataTable
                    Dim IdPersonal As Integer
                    Dim registro As CotizacionServicioService.CotizacionServicio
                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    If rbVendedor.Checked = True Then
                        IdPersonal = idPer
                    ElseIf rbSupervisor.Checked = True Then
                        IdPersonal = idPerDelegado
                    End If

                    dtReporte = oCotizacionServicioService.Imprimir(idCotizacionRep, IdPersonal).Tables(0)
                    dtSubreporte = oCotizacionServicioService.ImprimirRepuestos(idCotizacionRep).Tables(0)

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                    End If

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                        reporte.SetParameterValue("pSerie", IIf(registro.CodMer = Nothing, "", "Serie " & registro.CodMer))
                        reporte.SetParameterValue("pModelo", IIf(registro.ModMer = Nothing, "", " Modelo " & registro.ModMer))
                        reporte.SetParameterValue("pUnidad", IIf(registro.Unidad = Nothing, "", registro.Unidad))
                        reporte.SetParameterValue("pGarantia", oCotizacionServicioService.Garantia(idCotizacionRep))
                        reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"))
                        reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"), reporte.Subreports(0).Name.ToString())

                        If registro.CodProveedor = "004" Then
                            reporte.SetParameterValue("pCodProveedor", "")
                        Else
                            reporte.SetParameterValue("pCodProveedor", "                    ")
                        End If

                        forma.Text = "Imprimir Consolidado de Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If

        ElseIf Session.sCodEmp = "05" Then  'EQUIMAP

            If optResumido.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionEquimap
                    Dim IdPersonal As Integer
                    Dim registro As CotizacionServicioService.CotizacionServicio
                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    If rbVendedor.Checked = True Then
                        IdPersonal = idPer
                    ElseIf rbSupervisor.Checked = True Then
                        IdPersonal = idPerDelegado
                    End If

                    dtReporte = oCotizacionServicioService.Imprimir(idCotizacionRep, IdPersonal).Tables(0)

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

                        reporte.SetParameterValue("pSerie", IIf(registro.CodMer = Nothing, "", "Serie " & registro.CodMer))
                        reporte.SetParameterValue("pModelo", IIf(registro.ModMer = Nothing, "", " Modelo " & registro.ModMer))
                        reporte.SetParameterValue("pUnidad", IIf(registro.Unidad = Nothing, "", registro.Unidad))
                        reporte.SetParameterValue("pGarantia", oCotizacionServicioService.Garantia(idCotizacionRep))
                        'reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"))

                        If registro.CodProveedor = "004" Then
                            reporte.SetParameterValue("pCodProveedor", "")
                        Else
                            reporte.SetParameterValue("pCodProveedor", "                    ")
                        End If

                        forma.Text = "Imprimir Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try

            ElseIf optDetallado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionDetalleEquimap
                    Dim registro As CotizacionServicioService.CotizacionServicio

                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    dtReporte = oCotizacionServicioService.ImprimirRepuestos(idCotizacionRep).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        reporte.SetParameterValue("pCodMantenimiento", registro.TipoMantenimiento.CodMantenimiento)
                        reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"))
                        forma.crvReportes.ReportSource = reporte
                        'Validar por usuario - Exportar Excel 
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try

            ElseIf optConsolidado.Checked = True Then

                Try
                    Dim forma As New frmReportes
                    Dim reporte As New rpServiciosCotizacionConsolidadoEquimap
                    Dim dtSubreporte As DataTable
                    Dim IdPersonal As Integer
                    Dim registro As CotizacionServicioService.CotizacionServicio
                    registro = oCotizacionServicioService.Obtener(idCotizacionRep)

                    If rbVendedor.Checked = True Then
                        IdPersonal = idPer
                    ElseIf rbSupervisor.Checked = True Then
                        IdPersonal = idPerDelegado
                    End If

                    dtReporte = oCotizacionServicioService.Imprimir(idCotizacionRep, IdPersonal).Tables(0)
                    dtSubreporte = oCotizacionServicioService.ImprimirRepuestos(idCotizacionRep).Tables(0)

                    If reporte.Subreports.Count > 0 Then
                        reporte.Subreports(0).SetDataSource(dtSubreporte)
                        'reporte.Subreports(0).SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"), reporte.Subreports(0).Name.ToString())
                    End If

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                        reporte.SetParameterValue("pSerie", IIf(registro.CodMer = Nothing, "", "Serie " & registro.CodMer))
                        reporte.SetParameterValue("pModelo", IIf(registro.ModMer = Nothing, "", " Modelo " & registro.ModMer))
                        reporte.SetParameterValue("pUnidad", IIf(registro.Unidad = Nothing, "", registro.Unidad))
                        reporte.SetParameterValue("pGarantia", oCotizacionServicioService.Garantia(idCotizacionRep))
                        reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"))
                        reporte.SetParameterValue("pNoMostrarCodigo", IIf((cbNoMostrarCodigo.Checked), "true", "false"), reporte.Subreports(0).Name.ToString())

                        If registro.CodProveedor = "004" Then
                            reporte.SetParameterValue("pCodProveedor", "")
                        Else
                            reporte.SetParameterValue("pCodProveedor", "                    ")
                        End If

                        forma.Text = "Imprimir Consolidado de Cotización de Servicios"
                        forma.ShowDialog()

                    End If

                Catch ex As Exception
                    MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If


        End If

    End Sub

    Private Sub optResumido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResumido.CheckedChanged
        If optResumido.Checked Then
            gbFirma.Enabled = True
            cbNoMostrarCodigo.Enabled = False
        End If
    End Sub

    Private Sub optDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDetallado.CheckedChanged
        If optDetallado.Checked Then
            gbFirma.Enabled = False
            cbNoMostrarCodigo.Enabled = True
        End If
    End Sub

    Private Sub optConsolidado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optConsolidado.CheckedChanged
        If optConsolidado.Checked Then
            gbFirma.Enabled = True
            cbNoMostrarCodigo.Enabled = True
        End If
    End Sub
End Class