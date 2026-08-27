Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmAlmacen_FacturaImportacionImprimir
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oMaestro As New MaestroService.MaestroClient

    Public IdLocacion As Int64
    Public NumDoc As Int64

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
        Catch ex As TimeoutException
            oImportacionService.Abort()
            oMaestro.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            oMaestro.Abort()

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
    Private Sub rbCambio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbListado.CheckedChanged, rbConformidad.CheckedChanged, rbListGeneral.CheckedChanged
        If rbListado.Checked Then
            grupoOrden.Enabled = True
        ElseIf rbConformidad.Checked Then
            grupoOrden.Enabled = False
        ElseIf rbListGeneral.Checked Then
            grupoOrden.Enabled = True
        End If
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView

            If rbListado.Checked Then
                Dim reporte As New rpChequeoImportacion
                Dim reporteCodigo As New rpChequeoImportacionCodigo

                dtReporte = oImportacionService.ImprimirChequeo(NumDoc, IdLocacion).Tables(0).DefaultView
                If rbtnPorItem.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        dtReporte.Sort = "Item Asc"
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        forma.crvReportes.DisplayGroupTree = False
                        'forma.crvReportes.ShowRefreshButton = True
                        reporte.SetParameterValue("Almacen", 1)
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
                        forma.crvReportes.DisplayGroupTree = False
                        reporteCodigo.SetParameterValue("Almacen", 1)

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
                        forma.crvReportes.DisplayGroupTree = False
                        reporte.SetParameterValue("Almacen", 1)

                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()

                    End If
                End If
            End If
            If rbListGeneral.Checked Then

                Dim reporte As New rpChequeoImportacion
                Dim reporteCodigo As New rpChequeoImportacionCodigo
             
                dtReporte = oImportacionService.ImprimirChequeo(NumDoc, 0).Tables(0).DefaultView
                If rbtnPorItem.Checked Then
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        forma.crvReportes.DisplayGroupTree = False
                        'forma.crvReportes.ShowRefreshButton = True
                        reporte.SetParameterValue("Almacen", "")

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
                        forma.crvReportes.DisplayGroupTree = False
                        reporteCodigo.SetParameterValue("Almacen", "")

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
                        forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("Almacen", "")

                        forma.Text = "Reporte de Chequeo de Importacion"
                        forma.ShowDialog()

                    End If
                End If
            End If
            If rbConformidad.Checked Then

                Dim reporte As New rpConformidadImportacion
                dtReporte = oImportacionService.ImprimirConformidad(NumDoc, IdLocacion).Tables(0).DefaultView
                'DataGridView1.DataSource = dtReporte
                'If dtReporte.Rows.Count = 0 Then
                'MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                'Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.ShowRefreshButton = True
                forma.Text = "Reporte de Chequeo de Importacion"
                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\ChequeoImportacion.xml")
                If oImportacionService.BuscarFaltantes(NumDoc, IdLocacion) = False Then
                    reporte.SetParameterValue("Mensaje", "LA FACTURA LLEGO CONFORME, SEGUN FACTURA")
                Else
                    reporte.SetParameterValue("Mensaje", "")
                End If
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

End Class
