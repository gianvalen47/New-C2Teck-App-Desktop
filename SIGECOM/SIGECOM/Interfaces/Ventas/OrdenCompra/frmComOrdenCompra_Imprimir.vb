Imports System.ServiceModel
Public Class frmComOrdenCompra_Imprimir

    '===========================Servicios====================================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public IdOrden As Integer
    Public iAnio As Integer
    Public iCodArea As String
    Public iIdPer As Integer
    Public iIdOrden As Integer
    Public iIdEstado As Integer
    Public iProveedor As String
    Public iDesArea As String
    Public iDesEstado As String

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oOrdenesCompraService) = False Then
                oOrdenesCompraService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbPrincipal.Checked = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Session.sCodEmp = "01" Then

            If rbPrincipal.Checked = True Then
                Try
                    If rbGeneral.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompra
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    ElseIf rbComercial.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompra_Com
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            ElseIf rbListado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    Dim reporte As New rptComOrdenCompra_Listado
                    dtReporte = oOrdenesCompraService.Filtrar(Session.sCodEmp, iAnio, iCodArea, iIdPer, iIdOrden, iIdEstado, Session.sCodUsu).Tables(0)
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
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Listado de Órdenes de Compra"
                        reporte.SetParameterValue("pAnio", iAnio)
                        reporte.SetParameterValue("pArea", iDesArea)
                        reporte.SetParameterValue("pEstado", iDesEstado)
                        reporte.SetParameterValue("pProveedor", iProveedor)
                        reporte.SetParameterValue("pIdOrden", IIf(iIdOrden = 0, "-", iIdOrden))
                        forma.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            End If

        ElseIf Session.sCodEmp = "02" Then

            If rbPrincipal.Checked = True Then
                Try
                    If rbGeneral.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompraMtuAmaz
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    ElseIf rbComercial.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompra_ComMtuAmaz
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            ElseIf rbListado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    Dim reporte As New rptComOrdenCompra_ListadoMtuAmaz
                    dtReporte = oOrdenesCompraService.Filtrar(Session.sCodEmp, iAnio, iCodArea, iIdPer, iIdOrden, iIdEstado, Session.sCodUsu).Tables(0)
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
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Listado de Órdenes de Compra"
                        reporte.SetParameterValue("pAnio", iAnio)
                        reporte.SetParameterValue("pArea", iDesArea)
                        reporte.SetParameterValue("pEstado", iDesEstado)
                        reporte.SetParameterValue("pProveedor", iProveedor)
                        reporte.SetParameterValue("pIdOrden", IIf(iIdOrden = 0, "-", iIdOrden))
                        forma.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            End If

        ElseIf Session.sCodEmp = "05" Then

            If rbPrincipal.Checked = True Then
                Try
                    If rbGeneral.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompraEquimap
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    ElseIf rbComercial.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompra_ComEquimap
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            ElseIf rbListado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    Dim reporte As New rptComOrdenCompra_ListadoEquimap
                    dtReporte = oOrdenesCompraService.Filtrar(Session.sCodEmp, iAnio, iCodArea, iIdPer, iIdOrden, iIdEstado, Session.sCodUsu).Tables(0)
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
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Listado de Órdenes de Compra"
                        reporte.SetParameterValue("pAnio", iAnio)
                        reporte.SetParameterValue("pArea", iDesArea)
                        reporte.SetParameterValue("pEstado", iDesEstado)
                        reporte.SetParameterValue("pProveedor", iProveedor)
                        reporte.SetParameterValue("pIdOrden", IIf(iIdOrden = 0, "-", iIdOrden))
                        forma.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            End If

        Else

            If rbPrincipal.Checked = True Then
                Try
                    If rbGeneral.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompra_General
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                reporte.SetParameterValue("pEmpresa", Session.sCodEmp)
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    ElseIf rbComercial.Checked = True Then
                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptComOrdenCompra_Com_General
                        If IdOrden <> 0 Then
                            dtReporte = oOrdenesCompraService.Imprimir(IdOrden).Tables(0)
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
                                ' forma.crvReportes.DisplayGroupTree = False
                                forma.Text = "Reporte de Orden de Compra"
                                reporte.SetParameterValue("pEmpresa", Session.sCodEmp)
                                forma.ShowDialog()
                            End If
                        Else
                            MsgBox("¡Número de Orden Invalido...!", MsgBoxStyle.Information, "No hay datos")
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            ElseIf rbListado.Checked = True Then
                Try
                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    Dim reporte As New rptComOrdenCompra_Listado_General
                    dtReporte = oOrdenesCompraService.Filtrar(Session.sCodEmp, iAnio, iCodArea, iIdPer, iIdOrden, iIdEstado, Session.sCodUsu).Tables(0)
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
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Listado de Órdenes de Compra"
                        reporte.SetParameterValue("pAnio", iAnio)
                        reporte.SetParameterValue("pArea", iDesArea)
                        reporte.SetParameterValue("pEstado", iDesEstado)
                        reporte.SetParameterValue("pProveedor", iProveedor)
                        reporte.SetParameterValue("pIdOrden", IIf(iIdOrden = 0, "-", iIdOrden))
                        forma.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
                End Try
            End If

        End If

    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub rbListado_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbListado.CheckedChanged, rbPrincipal.CheckedChanged
        Try
            If rbListado.Checked Then
                gbDetalle.Enabled = False
            ElseIf rbPrincipal.Checked Then
                gbDetalle.Enabled = True
                rbGeneral.Checked = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
End Class