Imports System.ServiceModel
Public Class frmDocumentoCosto
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private DocumentoVenta As New DocumentoCostoService.DocumentoVenta
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim IdMovimientod As Int64
    Dim TipDocd As Int16
    Private dtOficina As New DataTable
    Private dtMes As New DataTable
    Private dtDocumento As New DataTable
    Private dtConsolidado As New DataTable
    Private dtAlmacen As New DataTable
    Private dtEstados As New DataTable

    Private Sub LlenarCombos()

        Try
            txtPeriodo.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))

            dtMes = ObjMaestro.MostrarMeses
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            dtDocumento = ObjDocumento.MostrarTipoDocumentoCosto.Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Nombre"
            cbDocumento.ValueMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(1).DataMember = "Nombre"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing

            '--------------------------------------------------------- ESTADOS ---------------------------------------------------------
            dtEstados = New DataTable
            dtEstados.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
            dtEstados.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtEstados.Rows.Add(New Object() {"", "(Todos)"})
            dtEstados.Rows.Add(New Object() {"GN", "GENERADO"}) ', New DateTime(2008, 2, 5)
            dtEstados.Rows.Add(New Object() {"CR", "CREDITOS"})
            dtEstados.Rows.Add(New Object() {"AP", "APROBADO"})
            dtEstados.Rows.Add(New Object() {"IM", "IMPRESO"})
            dtEstados.Rows.Add(New Object() {"IN", "INGRESADO"})
            dtEstados.Rows.Add(New Object() {"TR", "TRANSFERIDO"})
            dtEstados.Rows.Add(New Object() {"CH", "CHEQUEADO"})
            dtEstados.Rows.Add(New Object() {"PR", "PROCESADO"})
            dtEstados.Rows.Add(New Object() {"FC", "FACTURADO"})
            dtEstados.Rows.Add(New Object() {"DP", "DESPACHADO"})
            dtEstados.Rows.Add(New Object() {"DV", "DEVUELTO"})
            dtEstados.Rows.Add(New Object() {"AN", "ANULADO"})
            dtEstados.Rows.Add(New Object() {"CO", "CONSULTA"})
            cbEstado.DataSource = dtEstados
            cbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cbEstado.DropDownList.ValueMember = dtEstados.Columns("Codigo").ToString
            cbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Codigo").ToString
            cbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgDocumentos.RowCount > 0 Then
            codigo = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
        End If
        dtConsolidado = Nothing
        LlenarGrilla()
        If dgDocumentos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgDocumentos, codigo)
        End If
        'enableOpciones()
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdMovimiento").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For

                End If

            Next

            'tabla.DefaultView.Sort = nombreCampo
            'lista.FirstRow = dtConsolidado.DefaultView.Find(codigo)
            'lista.Row = dtConsolidado.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click, cmMostrar.Click, dgDocumentos.DoubleClick
        If dtConsolidado.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmDocumentoCostoDatos
            forma.pTipDoc = dgDocumentos.CurrentRow.Cells(9).Text
            forma.pIdMovimiento = dgDocumentos.CurrentRow.Cells(0).Text
            forma.pTipo = dgDocumentos.CurrentRow.Cells(10).Text

            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If

            End If
    End Sub

    Private Sub frmDocumentoCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbMes.KeyPress _
            , cbOficina.KeyPress _
            , cbAlmacen.KeyPress _
            , cbDocumento.KeyPress _
            , txtNumero.KeyPress _
            , txtPeriodo.KeyPress
        ', dgDocumentos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDocumentoCosto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmDocumentoCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocumentoCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 60)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDocumentos)

        dgDocumentos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgDocumentos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        LlenarCombos()
        LlenarGrilla()

    End Sub

    Public Sub LlenarGrilla()

        Try
            'dtConsolidado = ObjDocumento.Filtrar(txtPeriodo.Value, cbMes.Value, cbAlmacen.Value, cbDocumento.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text)).Tables(0)
            dtConsolidado = ObjDocumento.Filtrar(txtPeriodo.Value, cbMes.Value, cbAlmacen.Value, cbDocumento.Value, IIf(cbEstado.SelectedIndex = 0, "", cbEstado.Value), IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text)).Tables(0)
            Me.dgDocumentos.SetDataBinding(dtConsolidado, 0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub


    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Almacenes")
        End Try

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.ValueChanged, cbMes.ValueChanged, cbDocumento.ValueChanged, cbOficina.ValueChanged, cbAlmacen.ValueChanged, txtNumero.TextChanged, cbEstado.ValueChanged
        LlenarGrilla()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        imprimir()
    End Sub
    Public Sub imprimir()
        Try
            Dim frm As New frmImprimirCosto
            Dim dtReporte As DataTable

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If frm.Imprimir = 1 Then

                    If dgDocumentos.CurrentRow.Cells("Tipo").Value = 1 Then
                        Dim forma As New frmReportes
                        Dim reporteOriginal As New rptOriginal
                        ObjDocumento.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                        dtReporte = ObjDocumento.ImprimirDocVenta(dgDocumentos.CurrentRow.Cells("IdMovimiento").Text, dgDocumentos.CurrentRow.Cells("TipDoc").Text).Tables(0)

                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                            'Me.Close()
                        Else
                            reporteOriginal.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteOriginal

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporteOriginal.SetParameterValue("Nombre", cbDocumento.Text)
                            reporteOriginal.SetParameterValue("Documento", cbDocumento.Value)
                            reporteOriginal.SetParameterValue("NumeroDocumento", dgDocumentos.CurrentRow.Cells("NumDoc").Text)
                            reporteOriginal.SetParameterValue("motivo", dgDocumentos.CurrentRow.Cells("Tipo").Text)
                            forma.Text = "Reporte de Costos"
                            forma.ShowDialog()
                        End If

                    ElseIf dgDocumentos.CurrentRow.Cells("Tipo").Value = 2 Then

                        Dim forma As New frmReportes
                        Dim reporteOriginal As New rptOriginal
                        ObjDocumento.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                        dtReporte = ObjDocumento.ImprimirDocAlmacen(dgDocumentos.CurrentRow.Cells("IdMovimiento").Text, dgDocumentos.CurrentRow.Cells("TipDoc").Text).Tables(0)
                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                            'Me.Close()
                        Else
                            reporteOriginal.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporteOriginal

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporteOriginal.SetParameterValue("Nombre", cbDocumento.Text)
                            reporteOriginal.SetParameterValue("Documento", cbDocumento.Value)
                            reporteOriginal.SetParameterValue("NumeroDocumento", dgDocumentos.CurrentRow.Cells("NumDoc").Text)
                            reporteOriginal.SetParameterValue("motivo", dgDocumentos.CurrentRow.Cells("Tipo").Text)
                            forma.Text = "Reporte de Costos"
                            forma.ShowDialog()
                        End If

                    End If


                ElseIf frm.Imprimir = 2 Then

                    If dgDocumentos.CurrentRow.Cells("Tipo").Value = 1 Then
                        Dim forma As New frmReportes
                        Dim reporte As New rptCostos
                        ObjDocumento.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                        dtReporte = ObjDocumento.ImprimirDocVenta(dgDocumentos.CurrentRow.Cells("IdMovimiento").Text, dgDocumentos.CurrentRow.Cells("TipDoc").Text).Tables(0)
                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                            'Me.Close()
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

                            reporte.SetParameterValue("Nombre", cbDocumento.Text)
                            reporte.SetParameterValue("Documento", cbDocumento.Value)
                            reporte.SetParameterValue("NumeroDocumento", dgDocumentos.CurrentRow.Cells("NumDoc").Text)
                            reporte.SetParameterValue("motivo", dgDocumentos.CurrentRow.Cells("Tipo").Text)
                            forma.Text = "Reporte de Costos"
                            forma.ShowDialog()
                        End If

                    ElseIf dgDocumentos.CurrentRow.Cells("Tipo").Value = 2 Then
                        Dim forma As New frmReportes
                        Dim reporte As New rptCostos
                        ObjDocumento.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                        dtReporte = ObjDocumento.ImprimirDocAlmacen(dgDocumentos.CurrentRow.Cells("IdMovimiento").Text, dgDocumentos.CurrentRow.Cells("TipDoc").Text).Tables(0)
                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                            'Me.Close()
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

                            reporte.SetParameterValue("Nombre", cbDocumento.Text)
                            reporte.SetParameterValue("Documento", cbDocumento.Value)
                            reporte.SetParameterValue("NumeroDocumento", dgDocumentos.CurrentRow.Cells("NumDoc").Text)
                            reporte.SetParameterValue("motivo", dgDocumentos.CurrentRow.Cells("Tipo").Text)
                            forma.Text = "Reporte de Costos"
                            forma.ShowDialog()
                        End If

                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try


    End Sub


    Private Sub dgDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDocumentos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgDocumentos.RowCount > 0 Then
                e.Handled = True
                btnMostrar_Click(sender, e)
            End If
        End If
    End Sub

End Class