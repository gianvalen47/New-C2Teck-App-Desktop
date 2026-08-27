Imports System.ServiceModel

Public Class frmRepPagosCtasxPagar

    Private oPagosCtasPorPagarService As New PagosCtasPorPagarService.PagosCtasPorPagarServiceClient
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim dtTipoPago As DataTable
    Dim dtReporte As DataTable
    Dim IdProveedor As String
    Dim IdPago As Integer

    Private Sub frmRepPagosCtasxPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPagosCtasPorPagarService.Close()
            oCtasPorPagarService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPagosCtasPorPagarService.Abort()
            oCtasPorPagarService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPagosCtasPorPagarService.Abort()
            oCtasPorPagarService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepPagosCtasxPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepPagosCtasxPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombo()
        rbDetallado.Checked = True
        rbListado.Checked = True

    End Sub

    Private Sub llenarCombo()
        Try
            '===================================== TIPO DE PAGO COMPRA =======================================
            dtTipoPago = oPagosCtasPorPagarService.MostrarTipoPago().Tables(0)
            dtTipoPago.Rows.InsertAt(getRowTodos(dtTipoPago), 0)
            cmbTipoPago.DataSource = dtTipoPago
            cmbTipoPago.DropDownList.DataMember = dtTipoPago.Columns("DesPago").ToString
            cmbTipoPago.DropDownList.DisplayMember = dtTipoPago.Columns("DesPago").ToString
            cmbTipoPago.DropDownList.ValueMember = dtTipoPago.Columns("IdTipoPago").ToString
            cmbTipoPago.DropDownList.Columns(0).DataMember = dtTipoPago.Columns("IdTipoPago").ToString
            cmbTipoPago.DropDownList.Columns(1).DataMember = dtTipoPago.Columns("DesPago").ToString
            dtTipoPago = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validarData() = True Then
            oSeguridadService.RegistrarVisitaOpciones(149, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbDetallado.Checked And rbListado.Checked Then
                MostrarReporteDetalladoListado()
            ElseIf rbDetallado.Checked And rbAgrupado.Checked And rbxProveedor.Checked Then
                MostrarReporteDetalladoAgrupadoxProveedor()
            ElseIf rbDetallado.Checked And rbAgrupado.Checked And rbxTipoPago.Checked Then
                MostrarReporteDetalladoAgrupadoxTipoPago()
            ElseIf rbAcumulado.Checked Then
                MostrarReporteAcumulado()
            End If
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

    Private Sub MostrarReporteDetalladoListado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpPagosCtasxPagarDetList

            If txtProveedor.Text = "(TODOS)" Then
                IdProveedor = 0
            End If

            If cmbTipoPago.Text = "(Todos)" Then
                IdPago = 0
            Else
                IdPago = cmbTipoPago.Value
            End If

            dtReporte = oPagosCtasPorPagarService.ReportePagosCtasPorPagar(1, Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdProveedor, IdPago).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Pagos de Cuentas x Pagar Detallado"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("TipoPago", IIf(cmbTipoPago.Text = "(Todos)", "(Todos)", cmbTipoPago.Text))
                reporte.SetParameterValue("Reporte", "REPORTE DE PAGOS DE CUENTAS POR PAGAR DETALLADO")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteDetalladoAgrupadoxProveedor()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpPagosCtasxPagarDetAgrpxProveedor

            If txtProveedor.Text = "(TODOS)" Then
                IdProveedor = 0
            End If

            If cmbTipoPago.Text = "(Todos)" Then
                IdPago = 0
            Else
                IdPago = cmbTipoPago.Value
            End If

            dtReporte = oPagosCtasPorPagarService.ReportePagosCtasPorPagar(1, Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdProveedor, IdPago).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Pagos de Cuentas x Pagar Detallado"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("TipoPago", IIf(cmbTipoPago.Text = "(Todos)", "(Todos)", cmbTipoPago.Text))
                reporte.SetParameterValue("Reporte", "REPORTE DE PAGOS DE CUENTAS POR PAGAR AGRUPADO")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteDetalladoAgrupadoxTipoPago()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpPagosCtasxPagarDetAgrpxTipoPago

            If txtProveedor.Text = "(TODOS)" Then
                IdProveedor = 0
            End If

            If cmbTipoPago.Text = "(Todos)" Then
                IdPago = 0
            Else
                IdPago = cmbTipoPago.Value
            End If

            dtReporte = oPagosCtasPorPagarService.ReportePagosCtasPorPagar(1, Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdProveedor, IdPago).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Pagos de Cuentas x Pagar Detallado"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("TipoPago", IIf(cmbTipoPago.Text = "(Todos)", "(Todos)", cmbTipoPago.Text))
                reporte.SetParameterValue("Reporte", "REPORTE DE PAGOS DE CUENTAS POR PAGAR AGRUPADO")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteAcumulado()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpPagosCtasxPagarAcum

            IdProveedor = 0
            IdPago = 0
            If cbFecInicio.Value.Year = cbFecFinal.Value.Year Then
                dtReporte = oPagosCtasPorPagarService.ReportePagosCtasPorPagar(2, Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdProveedor, IdPago).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Pagos de Cuentas x Pagar Detallado"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    'reporte.SetParameterValue("Proveedor", IIf(txtProveedor.Text = "(Todos)", "(Todos)", txtProveedor.Text))
                    reporte.SetParameterValue("Reporte", "REPORTE DE PAGOS DE CUENTAS POR PAGAR ACUMULADO")
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Las fechas tienen que estar en el mismo año")
            End If

          

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try


    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked = True Then
            cmbTipoPago.Enabled = True
            cmbTipoPago.Text = "(Todos)"
            txtProveedor.Text = "(Todos)"
            btnBuscarProveedor.Enabled = True
            rbBuscarProveedor.Enabled = True
            rbBuscarProveedor.Checked = True
            rbListado.Enabled = True
            rbListado.Checked = True
            rbAgrupado.Enabled = True
        End If
    End Sub

    Private Sub rbAcumulado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAcumulado.CheckedChanged
        If rbAcumulado.Checked = True Then
            cmbTipoPago.Enabled = False
            cmbTipoPago.Text = ""
            txtProveedor.Text = ""
            btnBuscarProveedor.Enabled = False
            rbBuscarProveedor.Enabled = False
            rbBuscarProveedor.Checked = False
            rbListado.Enabled = False
            rbAgrupado.Enabled = False
            rbListado.Checked = False
            rbAgrupado.Checked = False
            gbAgrupado.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub rbAgrupado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAgrupado.CheckedChanged
        If rbAgrupado.Checked = True Then
            gbAgrupado.Enabled = True
            rbxProveedor.Checked = True
        End If
    End Sub

    Private Sub rbListado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbListado.CheckedChanged
        If rbListado.Checked = True Then
            gbAgrupado.Enabled = False
            rbxProveedor.Checked = False
        End If
    End Sub
End Class