Imports System.ServiceModel
Public Class frmImportaciones
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjImportacion As New ImportacionService.ImportacionServiceClient
    Private ObjPedidoImport As New PedidoImportService.PedidoImportServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficina As New DataTable
    Private dtProveedor As New DataTable
    Private dtEstado As New DataTable
    Private dtFactura As New DataTable
    Private dtAlmacen As New DataTable
    Private OkBusqueda As Boolean

    Private Sub frmImportaciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            ObjImportacion.Close()
            ObjPedidoImport.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            ObjImportacion.Abort()
            ObjPedidoImport.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            ObjImportacion.Abort()
            ObjPedidoImport.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub

    Private Sub frmImportaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbOficina.KeyPress _
            , cbAlmacen.KeyPress _
            , cbProveedor.KeyPress _
            , cbEstado.KeyPress _
            , dtInicio.KeyPress _
            , dtFinal.KeyPress _
            , txtNumero.KeyPress _
            , txtCodEmbarque.KeyPress _
            , dgFacturas.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmImportaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    'Private Sub frmImportaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    'If e.KeyCode = Keys.Escape Then
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End If
    'End Sub

    Private Sub frmImportaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 55)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgFacturas)
        dgFacturas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgFacturas.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        OkBusqueda = False
        LlenarCombos()
        OkBusqueda = True
        LlenarGrilla()
    End Sub
    Private Sub LlenarCombos()

        Try
            'dtInicio.Value = "01/01/" & Year(Today)
            'dtFinal.Value = Today

            '/*Se realiza el cambio de fechas  a pedido de Angélica 01/10/2018*/
            dtInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
            dtFinal.Value = Date.Today

            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            dtProveedor = ObjPedidoImport.MostrarProveedores(Session.sCodEmp).Tables(0)
            Dim row As DataRow = dtProveedor.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtProveedor.Rows.InsertAt(row, 0)
            cbProveedor.DataSource = dtProveedor
            cbProveedor.DisplayMember = "DesProv"
            cbProveedor.ValueMember = "IdProveedor"
            cbProveedor.SelectedIndex = 0
            dtProveedor = Nothing

            dtEstado = ObjImportacion.MostrarEstados
            Dim rowe As DataRow = dtEstado.NewRow
            rowe(0) = ""
            rowe(1) = "(Todos)"
            dtEstado.Rows.InsertAt(rowe, 0)
            cbEstado.DataSource = dtEstado
            cbEstado.DisplayMember = "Descripcion"
            cbEstado.ValueMember = "Estado"
            cbEstado.SelectedIndex = 0
            dtEstado = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Public Sub LlenarGrilla()

        'With dgFacturas
        '    'alternar color de filas   
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.GhostWhite
        '    .DefaultCellStyle.BackColor = Color.AliceBlue
        'End With
        'dgFacturas.AutoGenerateColumns = False
        'dgFacturas.DataSource = dtFactura
        'Me.Columna1.DataPropertyName = dtFactura.Columns("NumDoc").ColumnName
        'Me.Columna2.DataPropertyName = dtFactura.Columns("FecDoc").ColumnName
        'Me.Columna3.DataPropertyName = dtFactura.Columns("DesCli").ColumnName
        'Me.Columna4.DataPropertyName = dtFactura.Columns("TipCam").ColumnName
        'Me.Columna5.DataPropertyName = dtFactura.Columns("TotalNeto").ColumnName
        'Me.Columna6.DataPropertyName = dtFactura.Columns("TotalNetoSol").ColumnName
        'Me.Columna7.DataPropertyName = dtFactura.Columns("Estado").ColumnName
        Try
            If OkBusqueda Then
                'dtFactura = ObjImportacion.Filtrar(cbAlmacen.SelectedValue, cbProveedor.SelectedValue, dtInicio.Value, dtFinal.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text), cbEstado.SelectedValue).Tables(0)
                dtFactura = ObjImportacion.Filtrar(cbAlmacen.SelectedValue, cbProveedor.SelectedValue, dtInicio.Value, dtFinal.Value, txtNumero.Text, cbEstado.SelectedValue, "", txtCodEmbarque.Text).Tables(0)
                Me.dgFacturas.SetDataBinding(dtFactura, 0)
                sslTotal.Text = "Registros: " + dgFacturas.RowCount.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    Private Sub cbOficina_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOficina.SelectedValueChanged
        If cbOficina.ValueMember <> Nothing Then
            dtAlmacen = ObjImportacion.MostrarLocacionImportacion(Session.sCodEmp, cbOficina.SelectedValue).Tables(0)  'ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.SelectedValue, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            dtAlmacen = Nothing
        End If
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click, cmMostrar.Click, dgFacturas.DoubleClick
        If dtFactura.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmDatosImportacion
            'forma.MdiParent = Me.MdiParent
            'forma.pIdImportacion = dtFactura.Rows(dgFacturas.CurrentCell.RowIndex).Item("IdImportacion")
            forma.pIdImportacion = dgFacturas.CurrentRow.Cells(0).Text
            forma.ShowDialog(Me)
            Actualizar()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbOficina.SelectedValueChanged, cbAlmacen.SelectedValueChanged, cbProveedor.SelectedValueChanged, cbEstado.SelectedValueChanged, txtNumero.TextChanged
        LlenarGrilla()
    End Sub

    Private Sub btnRecostear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecostear.Click, cmRecostear.Click
        Dim pEstado As String = ObjImportacion.ObtenerEstado(dgFacturas.CurrentRow.Cells("IdImportacion").Text)
        If pEstado <> "CH" And pEstado <> "TR" Then
            MsgBox("En este Estado no se puede realizar el Recosteo de la factura", MsgBoxStyle.Information, "No esta Disponible")
            Exit Sub
        End If
        If MsgBox("¿Está seguro de CERRAR el costo de la Factura?", MsgBoxStyle.YesNo, "Recostear Factura") = MsgBoxResult.Yes Then
            Try
                Dim pIdImportacion As Int64 = dgFacturas.CurrentRow.Cells(0).Text
                ObjImportacion.Recostear(pIdImportacion, Session.sCodUsu)
                MsgBox("Se Cerró el Costo de la factura con exito", MsgBoxStyle.Information, "Final Exitoso")
                Actualizar()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgFacturas.RowCount > 0 Then
            codigo = dgFacturas.CurrentRow.Cells("IdImportacion").Text
        End If
        dtFactura = Nothing
        LlenarGrilla()
        If dgFacturas.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgFacturas, codigo)
        End If
        ' enableOpciones()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdImportacion").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click, cmImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpFacturaImport
            Dim dtReporte As New DataTable
            dtReporte = ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                forma.Text = "Reporte de Factura de Importacion"
                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtFactura.WriteXmlSchema("D:\Proyecto\Codigo\SIGECOM\Cliente\Reportes\OrigenDatos\Importaciones.xml")
                'reporte.SetParameterValue("NumDoc", Importacion.NumDoc)
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, cmSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click, cmActualizar.Click
        Actualizar()
    End Sub

    Private Sub dgFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgFacturas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgFacturas.RowCount > 0 Then
                btnMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biValorizarFIMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biValorizarFIMasivo.Click, miValorizarFIMasivo.Click
        Try
            Dim frm As New frmValorizarFIMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al VALORIZAR F/I MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRecalcularFIMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biRecalcularMasivo.Click, miRecalcularMasivo.Click
        Try
            Dim frm As New frmRecalcularFIMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al RECALCULAR F/I MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRecostearMasivo_Click(sender As System.Object, e As System.EventArgs) Handles biRecostearMasivo.Click, miRecostearMasivo.Click
        Try
            Dim frm As New frmRecostearFIMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al RECOSTEAR F/I MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGenerarAsientoDUA_Click(sender As Object, e As EventArgs) Handles btnGenerarAsientoDUA.Click, miGenerarAsientoDUA.Click
        Try
            Dim frm As New frmGenerarAsientoDUA
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al VALORIZAR F/I MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class