Imports System.ServiceModel
Public Class frmRepValeMaterial
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient

    Private dtOficinas As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtAreas As DataTable
    Private dtClases As DataTable

    Dim IdPer As String

    Private Sub frmRepValeMaterial_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oMaestro.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()

        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepValeMaterial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmRepValeMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        cbFecFinal.Value = Today
        cmbCodArea.Value = "(Todos)"
        llenarCombos()

    End Sub
    Private Sub llenarCombos()

        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= TIPO MOVIMIENTOS ===============================================
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"D", "SALIDAS"})
            dtTipoMovimientos.Rows.Add(New Object() {"H", "INGRESOS"})
            cmbTipoMovimiento.DataSource = dtTipoMovimientos
            cmbTipoMovimiento.DisplayMember = "Nombre"
            cmbTipoMovimiento.ValueMember = "Tipo"
            cmbTipoMovimiento.DropDownList.Columns(0).DataMember = "Tipo"
            cmbTipoMovimiento.DropDownList.Columns(1).DataMember = "Nombre"
            cmbTipoMovimiento.SelectedIndex = 0
            dtTipoMovimientos = Nothing
            '======================================= AREAS ================================================
            dtAreas = oMaestro.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing
            '======================================= CLASES ================================================
            dtClases = oMaestro.MostrarClaseMerca.Tables(0)
            dtClases.Rows.InsertAt(getRowTodos(dtClases), 0)
            cmbIdClase.DataSource = dtClases
            cmbIdClase.DropDownList.DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.DisplayMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.ValueMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(0).DataMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(1).DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.SelectedIndex = 0
            dtClases = Nothing

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
        fila(2) = "(Todos)"
        Return fila
    End Function

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepValeMaterial
            Dim dtReporte As New DataView


            dtReporte = oLocacionMercaderiaService.ReporteValeMateriales(cbFecInicio.Value, cbFecFinal.Value, cmbOficinas.Value, cmbTipoMovimiento.Value, IIf(cmbCodArea.Value = "(Todos)", "", cmbCodArea.Value), txtNumJob.Text, txtCodMer.Text, IIf(txtPersonal.Text = "", 0, IdPer), utils.toNumber(cmbIdClase.Value)).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                'forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.ShowRefreshButton = True
                forma.Text = "Reporte de Vales de Materiales"
                Dim TipMov As String
                TipMov = cmbTipoMovimiento.Value
                Select Case TipMov
                    Case "H"
                        reporte.SetParameterValue("TipMov", "INGRESOS")
                    Case "D"
                        reporte.SetParameterValue("TipMov", "SALIDAS")

                End Select

                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Area", cmbCodArea.Text)
                reporte.SetParameterValue("CodArea", cmbCodArea.Value)
                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\RepValeMaterial.xml")

                forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        MostrarReporte()
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbMercaderia.Checked = False
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window

        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job

        End If
    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        Dim frm As New frmBuscarPersonal
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPersonal.Text = frm.descripcion
            txtPersonal.BackColor = System.Drawing.SystemColors.Control
            IdPer = frm.codigo
        End If
    End Sub

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged
        rbMercaderia.Checked = False
    End Sub

    Private Sub rbMercaderia_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMercaderia.CheckedChanged
        txtCodMer.Text = ""
    End Sub
End Class