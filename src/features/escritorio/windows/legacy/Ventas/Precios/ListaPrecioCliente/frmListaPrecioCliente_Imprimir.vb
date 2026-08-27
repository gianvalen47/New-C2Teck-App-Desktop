Imports System.ServiceModel

Public Class frmListaPrecioCliente_Imprimir

    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public IdLista As Integer
    Public IdCliente As Integer
    Public DesTipoLista As String
    Public NumContrato As String
    Public Observacion As String
    Public FecVigencia As String
    Public FecVencimiento As String
    Public Vigente As Boolean

    Private Sub frmListaPrecioCliente_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbPantalla.Checked = True
        rbExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If rbLisPreSel.Checked Then
            ImprimirListaPrecio()
        ElseIf rbLisPreVig.Checked Then
            ImprimirListaPrecioVigente()
        End If
        
    End Sub

    Private Sub ImprimirListaPrecio()

        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptListaPrecio

            dtReporte = oListaPrecioClienteService.Imprimir(IdLista).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("TipoLista", DesTipoLista)
                    reporte.SetParameterValue("NumContrato", NumContrato)
                    reporte.SetParameterValue("Observacion", Observacion)
                    reporte.SetParameterValue("FecVigencia", FecVigencia)
                    reporte.SetParameterValue("FecVencimiento", FecVencimiento)
                    reporte.SetParameterValue("Vigente", IIf(Vigente = True, "1", "0"))
                    forma.Text = "Reporte de Listado de Precio"
                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ImprimirListaPrecioVigente()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptListaPrecioVigente

            dtReporte = oListaPrecioClienteService.MostrarListaVigente(Session.sCodEmp, IdCliente).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Listado de Precio Vigente"
                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


End Class