Imports System.ServiceModel
Public Class frmRepValeMaterial
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMercaderia As New MercaderiaService.MercaderiaServiceClient
    Private dtOficinas As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtAreas As DataTable
    Private dtClases As DataTable
    Private dtAlmacenes As DataTable
    Private dtEstados As DataTable

    Dim IdPer As String

    Private Sub frmRepValeMaterial_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oMaestro.Close()
            oValeMaterialService.Close()
            oSeguridadService.Close()
            oMercaderia.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
            oValeMaterialService.Abort()
            oSeguridadService.Abort()
            oMercaderia.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
            oValeMaterialService.Abort()
            oSeguridadService.Abort()
            oMercaderia.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepValeMaterial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmRepValeMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 15)
        '/*************************************************************************************/

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

        rbExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub
    Private Sub llenarCombos()

        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
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
            dtTipoMovimientos.Rows.Add(New Object() {"O", "OTROS"})
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
            dtClases = oMercaderia.MostrarClasePorEmpresa(Session.sCodEmp).Tables(0)
            dtClases.Rows.InsertAt(getRowTodos(dtClases), 0)
            cmbIdClase.DataSource = dtClases
            cmbIdClase.DropDownList.DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.DisplayMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.ValueMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(0).DataMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(1).DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.SelectedIndex = 0
            dtClases = Nothing
            '======================================= ESTADOS ================================================
            dtEstados = oValeMaterialService.MostrarEstados()
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

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
        'fila(1) = "(Todos)"
        'fila(2) = "(Todos)"
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try


        'Try
        '    fila(1) = "(Todos)"
        'Catch ex As Exception

        'End Try
        'Try
        '    fila(4) = "(Todos)"
        'Catch ex As Exception


        Try
            fila(4) = ""
        Catch ex As Exception
        End Try

        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try


        Return fila
    End Function

    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        fila(1) = "(Todos)"
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        fila(4) = "(Todos)"
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        fila(5) = "(Todos)"
    '    Catch ex As Exception

    '    End Try

    '    Return fila
    'End Function


    Private Sub MostrarReporte()
        Try

            Dim forma As New frmReportes
            Dim reporte As New rpRepValeMaterial
            Dim dtReporte As New DataView


            dtReporte = oLocacionMercaderiaService.ReporteValeMateriales(cbFecInicio.Value, cbFecFinal.Value, cmbOficinas.Value, cmbIdLocacion.Value, cmbTipoMovimiento.Value, IIf(cmbCodArea.Value = "(Todos)", "", cmbCodArea.Value), txtNumJob.Text, txtCodMer.Text, IIf(txtPersonal.Text = "", 0, IdPer), utils.toNumber(cmbIdClase.Value), IIf(cmbEstado.Value = "(Todos)", "", cmbEstado.Value)).Tables(0).DefaultView
            'dtReporte = oLocacionMercaderiaService.ReporteValeMateriales(cbFecInicio.Value, cbFecFinal.Value, cmbOficinas.Value, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), cmbTipoMovimiento.Value, IIf(cmbCodArea.Value = "(Todos)", "", cmbCodArea.Value), txtNumJob.Text, txtCodMer.Text, IIf(txtPersonal.Text = "", 0, IdPer), utils.toNumber(cmbIdClase.Value)).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If rbExcel.Checked Then

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                Else

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Vales de Materiales"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte.SetParameterValue("TipMov", "INGRESOS")
                        Case "D"
                            reporte.SetParameterValue("TipMov", "SALIDAS")
                        Case "O"
                            reporte.SetParameterValue("TipMov", "OTROS")

                    End Select


                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Area", cmbCodArea.Text)
                    reporte.SetParameterValue("CodArea", cmbCodArea.Value)
                    reporte.SetParameterValue("IdLocacion", IIf(cmbIdLocacion.Text = "(Todos)" Or cmbIdLocacion.Text = "", "(Todos)", cmbIdLocacion.Text))
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepValeMaterial.xml")

                    forma.ShowDialog()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(15, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbMercaderia.Checked = False
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window

        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job

        End If
    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        Dim frm As New frmBuscarPersonal
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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



    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged

        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            'dtAlmacenes = oMaestroService.MostrarLocacionPorAlmacen(Session.sCodEmp, cmbOficinas.Value, "074", Session.sCodUsu).Tables(0)
            dtAlmacenes = oValeMaterialService.MostrarLocacionUsaVale(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            'dtAlmacenes = Nothing
        Else
            dtAlmacenes = oValeMaterialService.MostrarLocacionUsaVale(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes

            cmbIdLocacion.SelectedIndex = 0
            'cmbIdLocacion.Value = ""

        End If

    End Sub
End Class