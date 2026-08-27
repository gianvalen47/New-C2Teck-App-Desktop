Imports System.ServiceModel

Public Class frmRepVencCtasxPagarConta

    Private oRegistroCompra As New RegistroCompraService.RegistroCompraServiceClient
    ' Private oRegistroCompra As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim dtReporte As DataView
    Dim IdProveedor As String
    Private dtTipDoc As DataTable
    Private dtAreas As DataTable

    Private Sub frmRepVencCtasxPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRegistroCompra.Close()
            oOrdenesCompraService.Close()
            oSeguridadService.Close()
            'oMaestroService.Close()
        Catch ex As TimeoutException
            oRegistroCompra.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
            'oMaestroService.Abort()
        Catch ex As CommunicationException
            oRegistroCompra.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
            'oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmRepVencCtasxPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepVencCtasxPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 148)
        '/*************************************************************************************/

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombo()
        'cmbPosesion.Value = 0
        rbFecVenc.Checked = True
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

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

    Private Function getRowDoc(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = False
        End Try
        Try
            fila(2) = False
        Catch ex As Exception
            fila(3) = 0
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
        Return fila
    End Function

    Private Sub llenarCombo()
        Try

            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowDoc(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("AplicaIgv").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

            ''======================================= AREAS ================================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'dtAreas.Rows.InsertAt(getRowTodos1(dtAreas), 0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.SelectedIndex = 0
            'dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If
    End Sub

    Private Function validarData() As Boolean

        If cbFecInicio.Value > cbFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            cbFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validarData() = True Then
            oSeguridadService.RegistrarVisitaOpciones(148, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbDetallado.Checked Then
                MostrarReporteDetallado()
            ElseIf rbResumido.Checked Then
                MostrarReporteResumido()
            End If
        End If
    End Sub

    Private Sub MostrarReporteDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rpVencCtasxPagarConta
            Dim Condicion As Integer

            If rbPendientes.Checked = True Then
                Condicion = 1
            ElseIf rbTodos.Checked = True Then
                Condicion = 2
            End If

            oRegistroCompra.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            dtReporte = oRegistroCompra.ReporteVencimientosCtaPorPagar(Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, Condicion, toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView


            ' dtReporte = oRegistroCompra.ReporteVencimientosCtaPorPagar(Session.sCodEmp, IdProveedor, 0, 0, cbFecInicio.Value, cbFecFinal.Value, Condicion, toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbFecVenc.Checked = True Then
                    dtReporte.Sort = "FecVencimiento Asc "
                ElseIf rbProveedor.Checked = True Then
                    dtReporte.Sort = "DesProv Asc "
                ElseIf rbTotales.Checked = True Then
                    dtReporte.Sort = "TotalUS Asc "
                End If

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte de Vencimientos de Cuentas x Pagar"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("Condicion", IIf(rbPendientes.Checked = True, "Pendientes", "Todos"))
                reporte.SetParameterValue("pTipoDoc", IIf(cmbTipoDoc.SelectedIndex = 0, "(Todos)", cmbTipoDoc.Text))
                reporte.SetParameterValue("Reporte", "REPORTE DE VENCIMIENTO DE CUENTAS POR PAGAR DETALLADO")

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteResumido()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rpVencCtasxPagarDetalladoConta
            Dim Condicion As Integer

            If rbPendientes.Checked = True Then
                Condicion = 1
            ElseIf rbTodos.Checked = True Then
                Condicion = 2
            End If



            'dtReporte = oRegistroCompra.ReporteVencimientosCtaPorPagar(Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, Condicion, toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView
            oRegistroCompra.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            dtReporte = oRegistroCompra.ReporteVencimientosCtaPorPagar(Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, Condicion, toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView

            'dtReporte = oRegistroCompra.ReporteVencimientosCtaPorPagar(Session.sCodEmp, IdProveedor, 0, 0, cbFecInicio.Value, cbFecFinal.Value, Condicion, toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView


            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbFecVenc.Checked = True Then
                    dtReporte.Sort = "FecVencimiento Asc "
                ElseIf rbProveedor.Checked = True Then
                    dtReporte.Sort = "DesProv Asc "
                ElseIf rbTotales.Checked = True Then
                    dtReporte.Sort = "TotalUS Asc "
                End If

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte de Vencimientos de Cuentas x Pagar"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("Condicion", IIf(rbPendientes.Checked = True, "Pendientes", "Todos"))
                reporte.SetParameterValue("pTipoDoc", IIf(cmbTipoDoc.SelectedIndex = 0, "(Todos)", cmbTipoDoc.Text))
                reporte.SetParameterValue("Reporte", "REPORTE DE VENCIMIENTO DE CUENTAS POR PAGAR AGRUPADO")

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frmBuscarProveedor
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtProveedor.Text = frm.descripcion
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            IdProveedor = frm.codigo
        End If
        txtProveedor.Select()
        rbBuscarProveedor.Checked = False
    End Sub

End Class