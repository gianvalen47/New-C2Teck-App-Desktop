Imports System.ServiceModel
Public Class frmRepCtasxPagar

    '===========================Servicios====================================
    Private oCtasPorPagar As New CtasPorPagarService.CtasPorPagarServiceClient
    'Private oCtasPorPagar As New RegistroCompraService.RegistroCompraServiceClient

    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables============================= 
    Dim dtReporte As DataTable
    Dim IdPer As String
    Dim IdProveedor As String
    Dim dtPosesion As DataTable
    Private dtTipDoc As DataTable
    Private dtAreas As DataTable

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

    Private Sub frmRepCtasxPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCtasPorPagar.Close()
            oOrdenesCompraService.Close()
            oSeguridadService.Close()
            'oMaestroService.Close()
        Catch ex As TimeoutException
            oCtasPorPagar.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
            'oMaestroService.Abort()
        Catch ex As CommunicationException
            oCtasPorPagar.Abort()
            oOrdenesCompraService.Abort()
            oSeguridadService.Abort()
            'oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmRepCtasxPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCtasxPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 147)
        '/*************************************************************************************/

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombo()
        'cmbPosesion.Value = 0
        cmbPosesion.Text = "(Todos)"
        rbDetallado.Checked = True

    End Sub

    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If
        
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validarData() = True Then
            oSeguridadService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
            oSeguridadService.RegistrarVisitaOpciones(147, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbDetallado.Checked Then
                MostrarReporteDetallado()
            ElseIf rbResumido.Checked Then
                MostrarReporteResumido()
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombo()
        Try

            ''======================================= POSESION =============================================
            'dtPosesion = oCtasPorPagar.MostrarPosesion.Tables(0)
            'dtPosesion.Rows.InsertAt(getRowTodos(dtPosesion), 0)
            'cmbPosesion.DataSource = dtPosesion
            'cmbPosesion.DisplayMember = "ApeNom"
            'cmbPosesion.ValueMember = "IdPer"
            'cmbPosesion.DropDownList.Columns(0).DataMember = "IdPer"
            'cmbPosesion.DropDownList.Columns(1).DataMember = "ApeNom"
            'dtPosesion = Nothing

            ''=================================== TIPO DE DOCUMENTO=========================================
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

    Private Sub MostrarReporteDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpCtasxPagarDetallado

            If cmbPosesion.Text = "(Todos)" Then
                IdPer = 0
            Else
                IdPer = cmbPosesion.Value
            End If

            If txtProveedor.Text = "(TODOS)" Then
                IdProveedor = 0
            End If

            oCtasPorPagar.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
            dtReporte = oCtasPorPagar.ReporteCtasPorPagar(1, Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, IdPer, IIf(rbPendiente.Checked, 1, IIf(rbCancelado.Checked, 2, 3)), toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0)

            'dtReporte = oCtasPorPagar.ReporteCtasPorPagar(1, Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, IIf(rbPendiente.Checked, 1, IIf(rbCancelado.Checked, 2, 3)), toNumber(cmbTipoDoc.Value), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0)

            'DataGridView1.DataSource = dtReporte

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
                forma.Text = "Reporte de Cuentas x Pagar Detallado"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("Posesion", IIf(cmbPosesion.Text = "(Todos)", "(Todos)", cmbPosesion.Text))
                reporte.SetParameterValue("pCondicion", IIf(rbPendiente.Checked, "PENDIENTES", IIf(rbCancelado.Checked, "CANCELADOS", "TODOS")))
                reporte.SetParameterValue("pTipoDoc", IIf(cmbTipoDoc.SelectedIndex = 0, "(Todos)", cmbTipoDoc.Text))
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
            Dim reporte As New rpCtasxPagarResumido

            IdPer = "0"
            IdProveedor = "0"

            oCtasPorPagar.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
            dtReporte = oCtasPorPagar.ReporteCtasPorPagar(2, Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, IdPer, IIf(rbPendiente.Checked, 1, IIf(rbCancelado.Checked, 2, 3)), 0, IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView

            'dtReporte = oCtasPorPagar.ReporteCtasPorPagar(2, Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, IIf(rbPendiente.Checked, 1, IIf(rbCancelado.Checked, 2, 3)), 0, IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0))).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbTotal.Checked Then
                    If rbAscendente.Checked Then
                        'dtReporte.Sort = "Saldo Asc "
                        If rbSoles.Checked Then
                            dtReporte.Sort = "TotalNS Asc "
                        ElseIf rbDolares.Checked Then
                            dtReporte.Sort = "TotalUS Asc "
                        End If
                    ElseIf rbDescendente.Checked Then
                        If rbSoles.Checked Then
                            dtReporte.Sort = "TotalNS Desc "
                        ElseIf rbDolares.Checked Then
                            dtReporte.Sort = "TotalUS Desc "
                        End If
                    End If
                ElseIf rbProveedor.Checked Then
                    If rbAscendente.Checked Then
                        dtReporte.Sort = "DesProv Asc "
                    ElseIf rbDescendente.Checked Then
                        dtReporte.Sort = "DesProv Desc "
                    End If
                End If

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Cuentas x Pagar Resumido"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                'reporte.SetParameterValue("Proveedor", "")
                'reporte.SetParameterValue("Reporte", "REPORTE DE CUENTAS POR PAGAR RESUMIDO")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked = True Then
            cmbPosesion.Enabled = True
            cmbPosesion.Text = "(Todos)"
            txtProveedor.Text = "(Todos)"
            btnBuscarProveedor.Enabled = True
            rbBuscarProveedor.Enabled = True
            rbBuscarProveedor.Checked = True
            cmbTipoDoc.Value = 0
            cmbTipoDoc.Text = "(Todos)"
            cmbTipoDoc.Enabled = True
            gbOrdenadoPor.Enabled = False
            gbOrden.Enabled = False
            gbMoneda.Enabled = False
        End If
    End Sub

    Private Sub rbResumido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbResumido.CheckedChanged
        If rbResumido.Checked = True Then
            cmbPosesion.Enabled = False
            cmbPosesion.Text = ""
            txtProveedor.Text = ""
            btnBuscarProveedor.Enabled = False
            rbBuscarProveedor.Enabled = False
            rbBuscarProveedor.Checked = False
            cmbTipoDoc.Text = ""
            cmbTipoDoc.Enabled = False
            gbOrdenadoPor.Enabled = True
            gbOrden.Enabled = True
            gbMoneda.Enabled = true
        End If
    End Sub

    Private Sub rbTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotal.CheckedChanged
        If rbTotal.Checked = True Then
            gbOrden.Enabled = True
            gbMoneda.Enabled = True
        End If
    End Sub

    Private Sub rbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProveedor.CheckedChanged
        If rbProveedor.Checked = True Then
            gbOrden.Enabled = True
            gbMoneda.Enabled = False
        End If
    End Sub
End Class