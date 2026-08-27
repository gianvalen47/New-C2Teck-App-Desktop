Imports System.ServiceModel

Public Class frmInvRotativo

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataView
    Private dtRubros As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacen As DataTable
    Private IdLocacion As Integer

    Private Sub frmInvRotativo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oMaestroService.Close()
            oLocacionMercaderiaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oLocacionMercaderiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oLocacionMercaderiaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmInvRotativo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmInvRotativo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim Estilo As New Estilo
            Estilo.cargaEstiloGridExtAlternating(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            llenarCombos()
            Me.Text = "Inventario Rotativo a la Fecha"
        Catch ex As Exception
            MsgBox("Error en el Load : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            ' fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try
            '///////// OFICINAS ////////////
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DisplayMember = "DesOfi"
            cmbOficinas.ValueMember = "CodOfi"
            cmbOficinas.DropDownList.Columns(0).DataMember = "CodOfi"
            cmbOficinas.DropDownList.Columns(1).DataMember = "DesOfi"
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '///////// RUBROS ////////////
            dtRubros = oMaestroService.MostrarRubros.Tables(0)
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
            MsgBox("Error al llenar los combos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try

            Dim forma As New frmReportes
            Dim reporte As New rptInvRotativo
            If dtDatos.Count = 0 Then
                MsgBox("No existen datos que mostrar")
            Else

                dtDatos.Sort = "UbiMer Asc "
                Dim Impresora As String = SeleccionarImpresora()
                If Impresora <> "" Then
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Inventario Rotativo"

                    reporte.PrintOptions.PrinterName = Impresora
                    reporte.PrintToPrinter(0, False, 0, 0)

                    For Each Fila As DataRow In dtDatos.Table.Rows
                        oLocacionMercaderiaService.InsertarInvRot(Fila.Item("IdLocacion"), Fila.Item("CodMer"), Fila.Item("FecInv"), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    Next

                End If
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Try
            oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
            dtDatos = oLocacionMercaderiaService.ReporteInvRot(cmbOficinas.Value, cmbAlmacenes.Value, cmbCodRub.Value).Tables(0).DefaultView
            dtDatos.Sort = "UbiMer Asc "
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al procesar Inventario Rotativo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            dtAlmacen = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, "").Tables(0)
            cmbAlmacenes.DataSource = dtAlmacen
            cmbAlmacenes.DisplayMember = "DesAlm"
            cmbAlmacenes.ValueMember = "CodAlm"
            cmbAlmacenes.DropDownList.Columns(0).DataMember = "CodAlm"
            cmbAlmacenes.DropDownList.Columns(1).DataMember = "DesAlm"
            cmbAlmacenes.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try

    End Sub
End Class