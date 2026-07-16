Imports System.ServiceModel
Public Class frmConsultaDocumentos
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private ObjDocVenta As New ReporteVentaService.ReporteVentaServiceClient
    Private ObjGuiaRemision As New GuiaRemisionService.GuiaRemisionServiceClient
    Private ObjBoleta As New BoletaService.BoletaServiceClient
    Private ObjFactura As New FacturaService.FacturaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficina As New DataTable
    Private dtMes As New DataTable
    Private dtDocumento As New DataTable
    Private dtConsolidado As New DataTable
    Private dtAlmacen As New DataTable
    Private dtTipos As New DataTable
    Dim forma As New frmReportes
    Dim reporteOriginal As New rptConsultaOriginal

    '------ Agregado el 10/03/2014 ------
    Private IdCliente As Integer
    '------------------------------------------------

    'Dim dtReporteVenta As New DataTable

    'Public nombre As String
    'Public nrodocumento As String
    'Public nombre_Alm As String
    'Public nombre_motivo As String
    'Public idMovimiento As Integer
    'Public idTipoDoc As Integer

    Private Sub frmConsultaDocumentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(ObjDocVenta) = False Then
                ObjDocVenta.Close()
            End If
            If isClosed(ObjGuiaRemision) = False Then
                ObjGuiaRemision.Close()
            End If
            If isClosed(ObjFactura) = False Then
                ObjFactura.Close()
            End If
            If isClosed(ObjBoleta) = False Then
                ObjBoleta.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmConsultaDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            txtPeriodo.Value = Year(Today) 'IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))

            dtMes = ObjMaestro.MostrarMeses
            dtMes.Rows.InsertAt(getRowTodos(dtMes), 0)
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            cbMes.SelectedIndex = Month(Today) 'IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            'dtDocumento = ObjDocumento.MostrarTipoDocumentoCosto.Tables(0)
            dtDocumento = ObjDocVenta.MostrarTipoDocumentoVenta.Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Nombre"
            cbDocumento.ValueMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(1).DataMember = "Nombre"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing

            '/////////////////////////////////// Tipo Facturas ////////////////////////////////
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            dtTipos.Rows.Add(New Object() {"1", "Crédito"})
            dtTipos.Rows.Add(New Object() {"2", "Contado"})

            cmbTipFac.DataSource = dtTipos
            cmbTipFac.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.SelectedIndex = 1
            dtTipos = Nothing

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
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        'Try
        '    fila(1) = "(Todos)"
        'Catch ex As Exception
        'End Try
        'Try
        '    fila(2) = "(Todos)"
        'Catch ex As Exception
        'End Try
        'Try
        '    fila(3) = "(Todos)"
        'Catch ex As Exception
        'End Try
        'Try
        '    fila(4) = "(Todos)"
        'Catch ex As Exception
        'End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub frmConsultaDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 78)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDocumentos)
        dgDocumentos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        llenarCombos()
        IdCliente = 0
        txtBuscarCliente.Text = "(Todos)"
        LlenarGrilla()
        enableOpciones()
        'txtPeriodo.Value =
        'cbMes.Value = Today.Month

        txtPeriodo.Value = Session.sFecha.Year
        cbMes.Value = Session.sFecha.Month

        dgDocumentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        dgDocumentos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

    End Sub
    Private Sub enableOpciones()
        If dgDocumentos.RowCount < 1 Then
            biActualizar.Enabled = False
            biEstados.Enabled = False
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biTicket.Enabled = False

            miActualizar.Enabled = False
            miEstados.Enabled = False
            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miTicket.Enabled = False

        Else
            biActualizar.Enabled = True
            If cbDocumento.Value = 1 Or cbDocumento.Value = 2 Or cbDocumento.Value = 3 Then
                biEstados.Enabled = True
                miEstados.Enabled = True
            Else
                biEstados.Enabled = False
                miEstados.Enabled = False
            End If
            If cbDocumento.Value = 1 Or cbDocumento.Value = 3 Then
                biTicket.Enabled = True
                miTicket.Enabled = True
            Else
                biTicket.Enabled = False
                miTicket.Enabled = False
            End If
            biImprimir.Enabled = True
            biMostrar.Enabled = True

            miActualizar.Enabled = True
            miImprimir.Enabled = True
            miMostrar.Enabled = True
        End If
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If dtConsolidado.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmConsultaDocumento
            forma.pTipDoc = dgDocumentos.CurrentRow.Cells("TipDoc").Text
            forma.pIdMovimiento = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
            forma.pTipo = dgDocumentos.CurrentRow.Cells("Tipo").Text
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        End If
    End Sub
    Public Sub LlenarGrilla()
        Try
            'dtConsolidado = ObjDocumento.FiltrarDocumentos(txtPeriodo.Value, cbMes.Value, Session.sCodEmp, cbOficina.Value, cbAlmacen.Value, cbDocumento.Value, cmbTipFac.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text)).Tables(0)
            dtConsolidado = ObjDocVenta.FiltrarDocumentos(txtPeriodo.Value, cbMes.Value, Session.sCodEmp, cbOficina.Value, cbAlmacen.Value, cbDocumento.Value, _
                                                                                    cmbTipFac.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text), toBlank(txtCodJob.Text), IdCliente).Tables(0)

            Me.dgDocumentos.SetDataBinding(dtConsolidado, 0)

            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub
    'Private Sub Finalizar() Handles biSalir.Click
    '    Try
    '        ObjMaestro.Close()
    '        ObjDocumento.Close()
    '    Catch ex As TimeoutException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '    Catch ex As CommunicationException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '    End Try
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, "").Tables(0)
            dtAlmacen.Rows.InsertAt(getRowTodos1(dtAlmacen), 0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Almacenes")
        End Try
    End Sub

    Private Sub cbDocumento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDocumento.ValueChanged

        If cbDocumento.Value = 1 Or cbDocumento.Value = 2 Or cbDocumento.Value = 3 Then
            biConsultarSugerido.Enabled = True
        Else
            biConsultarSugerido.Enabled = False
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbMes.ValueChanged, cbAlmacen.ValueChanged, cbDocumento.ValueChanged, cbOficina.ValueChanged, txtNumero.TextChanged, txtPeriodo.TextChanged, cmbTipFac.ValueChanged, txtCodJob.TextChanged, txtBuscarCliente.TextChanged
        If cbDocumento.Value = 3 Or cbDocumento.Value = 2 Then
            cmbTipFac.Enabled = True
            LlenarGrilla()
        Else
            cmbTipFac.Value = ""
            cmbTipFac.Enabled = False
            LlenarGrilla()
        End If
    End Sub

    Private Sub dgDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumentos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub dgDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDocumentos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgDocumentos.RowCount > 0 Then
                e.Handled = True
                biMostrar_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumero.Select()
        End If
    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            If cbDocumento.Value = 1 Then
                Dim frm As New frmGuiaRemision_Estados

                frm.IdGuia = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
                frm.Text = "Estados de Guía de Remisión Nº : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            ElseIf cbDocumento.Value = 2 Then

                Dim frm As New frmBoleta_Estados
                frm.IdBoleta = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
                frm.Text = "Estados de la Boleta N° : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If

            ElseIf cbDocumento.Value = 3 Then
                Dim frm As New frmFacturaEstados
                frm.IdFactura = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
                frm.Text = "Estados de la Factura N° : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            Else

                MsgBox("No esta configurado...")

            End If

        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub
    Private Sub Imprimir()

        Try
            Dim dtReporte As DataTable

            Dim forma As New frmReportes
            Dim reporteOriginal As New rptConsultaOriginal

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
                reporteOriginal.SetParameterValue("NumeroDocumento", dgDocumentos.CurrentRow.Cells("NumDoc").Text)
                reporteOriginal.SetParameterValue("motivo", dgDocumentos.CurrentRow.Cells("Tipo").Text)
                reporteOriginal.SetParameterValue("NumeroLetra", ObjMaestro.ConvierteNumLetra(dgDocumentos.CurrentRow.Cells("TotNeto").Text, dgDocumentos.CurrentRow.Cells("CodMon").Text))
                forma.Text = "Reporte de Documentos"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub ImprimirTicket()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpImprimirTicket
            Dim dtReporte As New DataTable
            Dim IdMovimiento As Integer = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text

            'Se esta utilizando el reporte de imprimir ticket de Guias de Remisión

            If cbDocumento.Value = 1 Then
                dtReporte = ObjGuiaRemision.Imprimir(IdMovimiento).Tables(0)

            ElseIf cbDocumento.Value = 2 Then
                dtReporte = ObjBoleta.Imprimir(IdMovimiento).Tables(0)

            ElseIf cbDocumento.Value = 3 Then
                dtReporte = ObjFactura.Imprimir(IdMovimiento).Tables(0)

            End If

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                forma.Text = "Imprimir Ticket"

                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")

                forma.crvReportes.PrintReport()
                'forma.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Imprimir()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        LlenarGrilla()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Documento Seleccionado."
    End Sub
    Private Sub ImprimirTicket_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.MouseEnter, miTicket.MouseEnter
        sslError.Text = "Imprimir Ticket de Documento Seleccionado."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Estado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.MouseEnter, miEstados.MouseEnter
        sslError.Text = "Mostrar los Estados del Documento."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, biMostrar.MouseLeave, biEstados.MouseLeave, _
                                    biActualizar.MouseLeave, biSalir.MouseLeave, biTicket.MouseLeave, _
                                    miImprimir.MouseLeave, miMostrar.MouseLeave, miEstados.MouseLeave, _
                                    miActualizar.MouseLeave, miSalir.MouseLeave, miTicket.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgDocumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDocumentos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub biTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.Click, miTicket.Click
        ImprimirTicket()
    End Sub

    Private Sub biConsultarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.Click
        Try
            Dim frm As New frmGuiaRemision_ConsultarSugerido

            frm.IdCodigo = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
            If cbDocumento.Value = 1 Then
                frm.TipoCodigo = "GR"
                frm.Text = "Aprobación de Precios Sugeridos de Guía de Remisión Nº : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
            ElseIf cbDocumento.Value = 2 Then
                frm.TipoCodigo = "BO"
                frm.Text = "Aprobación de Precios Sugeridos de Boleta Nº : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
            ElseIf cbDocumento.Value = 3 Then
                frm.TipoCodigo = "FA"
                frm.Text = "Aprobación de Precios Sugeridos de Factura Nº : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
            End If
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al consultar precios sugeridos : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtBuscarCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                LlenarGrilla()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtBuscarCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtBuscarCliente.Text = "(Todos)"
            IdCliente = 0
            LlenarGrilla()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub
End Class