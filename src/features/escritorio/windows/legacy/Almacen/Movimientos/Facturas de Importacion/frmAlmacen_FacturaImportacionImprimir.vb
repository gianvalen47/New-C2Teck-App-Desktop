Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmAlmacen_FacturaImportacionImprimir
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdImportacion As Integer
    Public IdLocacion As Int64
    Public NumDoc As String
    Public FecInicio As Date
    Public FecFinal As Date    

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        MostrarReporte()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAlmacen_FacturaImportacionImprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()
            oMaestro.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oImportacionService.Abort()
            oMaestro.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            oMaestro.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmAlmacen_FacturaImportacionImprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacionImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        
    End Sub

    Private Sub rbCambio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbListado.CheckedChanged, rbConformidad.CheckedChanged, rbListGeneral.CheckedChanged, rbListadoxFecha.CheckedChanged, rbEmbarque.CheckedChanged
        If rbListado.Checked Then
            rbtnPorItem.Enabled = True
            rbtnPorCodigo.Enabled = True
            rbtnPorUbicacion.Enabled = True
            rbtnPorNumFactura.Enabled = False
            rbtnPorDestino.Enabled = False
            rbtnPorItem.Checked = True
            txtCodEmbarque.Text = ""
            txtNroPaquete.Text = ""
            gbEmbarque.Enabled = False
            'txtCodEmbarque.Enabled = False
            gbMostrarStock.Enabled = True
            rbFisico.Checked = True
        ElseIf rbConformidad.Checked Then
            rbtnPorItem.Enabled = False
            rbtnPorCodigo.Enabled = False
            rbtnPorUbicacion.Enabled = False
            rbtnPorNumFactura.Enabled = False
            rbtnPorDestino.Enabled = False
            txtCodEmbarque.Text = ""
            txtNroPaquete.Text = ""
            gbEmbarque.Enabled = False
            'txtCodEmbarque.Enabled = False
            gbMostrarStock.Enabled = False
            rbFisico.Checked = False
            rbDisponible.Checked = False
        ElseIf rbListGeneral.Checked Then
            rbtnPorItem.Enabled = True
            rbtnPorCodigo.Enabled = True
            rbtnPorUbicacion.Enabled = True
            rbtnPorNumFactura.Enabled = False
            rbtnPorDestino.Enabled = False
            rbtnPorItem.Checked = True
            txtCodEmbarque.Text = ""
            txtNroPaquete.Text = ""
            gbEmbarque.Enabled = False
            'txtCodEmbarque.Enabled = False
            gbMostrarStock.Enabled = True
            rbFisico.Checked = True
        ElseIf rbListadoxFecha.Checked Then
            rbtnPorItem.Enabled = False
            rbtnPorCodigo.Enabled = True
            rbtnPorUbicacion.Enabled = True
            rbtnPorNumFactura.Enabled = True
            rbtnPorDestino.Enabled = True
            rbtnPorCodigo.Checked = True
            txtCodEmbarque.Text = ""
            txtNroPaquete.Text = ""
            gbEmbarque.Enabled = False
            'txtCodEmbarque.Enabled = False
            gbMostrarStock.Enabled = True
            rbFisico.Checked = True
        ElseIf rbEmbarque.Checked Then
            rbtnPorItem.Enabled = False
            rbtnPorCodigo.Enabled = True
            rbtnPorUbicacion.Enabled = True
            rbtnPorNumFactura.Enabled = True
            rbtnPorDestino.Enabled = True
            rbtnPorCodigo.Checked = True
            gbEmbarque.Enabled = True
            gbMostrarStock.Enabled = True
            rbFisico.Checked = True
        End If
    End Sub

    Private Sub rbtnPorNumFactura_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnPorNumFactura.CheckedChanged
        If rbtnPorNumFactura.Checked Then
            gbOrdenFactura.Enabled = True
            rbtnPorItemFac.Checked = True
        Else
            gbOrdenFactura.Enabled = False
            rbtnPorItemFac.Checked = False
            rbtnPorCodigoFac.Checked = False
        End If
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView

            '================================ LISTADO POR ALMACEN ====================================
            If rbListado.Checked Then
                Dim reporte As New rpChequeoImportacion
                Dim reporteCodigo As New rpChequeoImportacionCodigo

                dtReporte = oImportacionService.ImprimirChequeo(IdImportacion, NumDoc, IdLocacion, Nothing, Nothing, "", "").Tables(0).DefaultView

                If rbtnPorItem.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        dtReporte.Sort = "Item Asc"
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("Almacen", 1)                        
                        reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
                If rbtnPorCodigo.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        'Se realizo el sort en el mismo reporte por la cantidad de caracteres del codigo de mercaderia
                        'dtReporte.Sort = "CodMer Asc"
                        reporteCodigo.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCodigo

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporteCodigo.SetParameterValue("Almacen", 1)
                        reporteCodigo.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
                If rbtnPorUbicacion.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        dtReporte.Sort = "UbiMer Asc"
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("Almacen", 1)
                        reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
            End If
            '========================================================================================

            '================================== LISTADO GENERAL ======================================
            If rbListGeneral.Checked Then
                Dim reporte As New rpChequeoImportacion
                Dim reporteCodigo As New rpChequeoImportacionCodigo

                dtReporte = oImportacionService.ImprimirChequeo(0, NumDoc, 0, Nothing, Nothing, "", "").Tables(0).DefaultView

                If rbtnPorItem.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        dtReporte.Sort = "Item Asc"
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("Almacen", "")
                        reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
                If rbtnPorCodigo.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        'Se realizo el sort en el mismo reporte por la cantidad de caracteres del codigo de mercaderia
                        'dtReporte.Sort = "CodMer Asc"
                        reporteCodigo.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteCodigo

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporteCodigo.SetParameterValue("Almacen", "")
                        reporteCodigo.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
                If rbtnPorUbicacion.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        dtReporte.Sort = "UbiMer Asc"
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("Almacen", "")
                        reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
            End If
            '=====================================================================================

            '================================== CONFORMIDAD ======================================
            If rbConformidad.Checked Then
                Dim reporte As New rpConformidadImportacion
                dtReporte = oImportacionService.ImprimirConformidad(IdImportacion, NumDoc, IdLocacion).Tables(0).DefaultView
                'If dtReporte.Rows.Count = 0 Then
                'MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                'Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Reporte de Chequeo de Importacion"
                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\ChequeoImportacion.xml")
                If oImportacionService.BuscarFaltantes(IdImportacion, NumDoc, IdLocacion) = False Then
                    reporte.SetParameterValue("pConforme", True)
                    reporte.SetParameterValue("Mensaje", "LA FACTURA LLEGO CONFORME, SEGUN FACTURA")
                Else
                    reporte.SetParameterValue("pConforme", False)
                    reporte.SetParameterValue("Mensaje", "")
                End If
                forma.ShowDialog()
            End If
            '===================================================================================

            '=============================== LISTADO POR FECHA ===================================
            If rbListadoxFecha.Checked Then
                '-------------------------------------- POR NÚMERO DE FACTURA --------------------------------------
                If rbtnPorNumFactura.Checked Then
                    Dim reporte As New rpChequeoImportacionListadoxFecha_Factura
                    Dim reporte2 As New rpChequeoImportacionListadoxFecha_Factura_Cod

                    dtReporte = oImportacionService.ImprimirChequeo(0, "", IdLocacion, FecInicio, FecFinal, "", "").Tables(0).DefaultView

                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        If rbtnPorItemFac.Checked Then              '-------------------------------- POR ITEM -------------------------
                            dtReporte.Sort = "Item Asc"
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("pFecInicio", FecInicio)
                            reporte.SetParameterValue("pFecFinal", FecFinal)
                            reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                            forma.Text = "Reporte de Chequeo de Importacion"
                            forma.ShowDialog()

                        ElseIf rbtnPorCodigoFac.Checked Then    '------------------------ POR CÓDIGO ---------------------------
                            'Se realizo el sort en el mismo reporte por la cantidad de caracteres del codigo de mercaderia
                            'dtReporte.Sort = "CodMer Asc"

                            reporte2.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte2

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte2.SetParameterValue("pFecInicio", FecInicio)
                            reporte2.SetParameterValue("pFecFinal", FecFinal)
                            reporte2.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                            forma.Text = "Reporte de Chequeo de Importacion"
                            forma.ShowDialog()
                        End If                       
                    End If

                Else '---------------------------- <> POR NÚMERO DE FACTURA -----------------------------------
                    Dim reporte As New rpChequeoImportacionListadoxFecha

                    dtReporte = oImportacionService.ImprimirChequeo(0, "", IdLocacion, FecInicio, FecFinal, "", "").Tables(0).DefaultView

                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        'If rbtnPorItem.Checked Then
                        '    dtReporte.Sort = "Item Asc"
                        If rbtnPorCodigo.Checked Then
                            dtReporte.Sort = "CodMer Asc"
                        ElseIf rbtnPorUbicacion.Checked Then
                            dtReporte.Sort = "UbiMer Asc"
                        ElseIf rbtnPorDestino.Checked Then
                            dtReporte.Sort = "Destino Asc"
                        End If
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("pFecInicio", FecInicio)
                        reporte.SetParameterValue("pFecFinal", FecFinal)
                        reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()
                    End If
                End If
            End If
            '===================================================================================

            '================================== EMBARQUE ======================================
            If rbEmbarque.Checked Then
                If txtCodEmbarque.Text = "" Then
                    MsgBox("¡Debe ingresar el código de Embarque!", MsgBoxStyle.Information, "Error")
                Else
                    '-------------------------------------- POR NÚMERO DE FACTURA --------------------------------------
                    If rbtnPorNumFactura.Checked Then
                        Dim reporte As New rpChequeoImportacionEmbarque_Fact
                        Dim reporte2 As New rpChequeoImportacionEmbarque_Fact_Cod

                        dtReporte = oImportacionService.ImprimirChequeo(0, "", IIf(ckTodosAlmacen.Checked = True, 0, IdLocacion), Nothing, Nothing, txtCodEmbarque.Text, txtNroPaquete.Text).Tables(0).DefaultView

                        If dtReporte.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            If rbtnPorItemFac.Checked Then              '-------------------------------- POR ITEM -------------------------
                                dtReporte.Sort = "Item Asc"

                                reporte.SetDataSource(dtReporte)
                                forma.crvReportes.ReportSource = reporte

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte.SetParameterValue("pNroPaquete", IIf(txtNroPaquete.Text = "", "Todos", txtNroPaquete.Text))
                                reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                                forma.Text = "Reporte de Chequeo de Importacion"
                                forma.ShowDialog()

                            ElseIf rbtnPorCodigoFac.Checked Then    '------------------------ POR CÓDIGO ---------------------------
                                'Se realizo el sort en el mismo reporte por la cantidad de caracteres del codigo de mercaderia
                                'dtReporte.Sort = "CodMer Asc"

                                reporte2.SetDataSource(dtReporte)
                                forma.crvReportes.ReportSource = reporte2

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                reporte2.SetParameterValue("pNroPaquete", IIf(txtNroPaquete.Text = "", "Todos", txtNroPaquete.Text))
                                reporte2.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                                forma.Text = "Reporte de Chequeo de Importacion"
                                forma.ShowDialog()
                            End If
                        End If

                    Else '---------------------------- <> POR NÚMERO DE FACTURA -----------------------------------
                        Dim reporte As New rpChequeoImportacionEmbarque

                        dtReporte = oImportacionService.ImprimirChequeo(0, "", IIf(ckTodosAlmacen.Checked = True, 0, IdLocacion), Nothing, Nothing, txtCodEmbarque.Text, txtNroPaquete.Text).Tables(0).DefaultView

                        If dtReporte.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            If rbtnPorCodigo.Checked Then
                                dtReporte.Sort = "CodMer Asc"
                            ElseIf rbtnPorUbicacion.Checked Then
                                dtReporte.Sort = "UbiMer Asc"
                            ElseIf rbtnPorDestino.Checked Then
                                dtReporte.Sort = "Destino Asc"
                            End If
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("pNroPaquete", IIf(txtNroPaquete.Text = "", "Todos", txtNroPaquete.Text))
                            reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                            forma.Text = "Reporte de Chequeo de Importacion"
                            forma.ShowDialog()
                        End If
                    End If
                End If
            End If
            '===================================================================================
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
End Class
