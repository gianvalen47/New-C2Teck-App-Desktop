Imports System.ServiceModel
Public Class frmRepCtasxPagarUnidad

    '===========================Servicios====================================
    Private oCtasPorPagar As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables============================= 
    Dim dtReporte As DataTable
    Dim IdProveedor As String
    Private dtUnidades As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable

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
            oCentroCostoService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCtasPorPagar.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oCtasPorPagar.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepCtasxPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCtasxPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombos()
        rbDetallado.Checked = True
        cbFecInicio.Focus()
    End Sub

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
        Return fila
    End Function

    Private Sub llenarcombos()
        Try

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '==================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            dtCentroCosto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validarData() = True Then
            oSeguridadService.RegistrarVisitaOpciones(271, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MostrarReporteDetallado()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpCtasxPagarUnidadDetallado

            If txtProveedor.Text = "(TODOS)" Then
                IdProveedor = 0
            End If


            dtReporte = oCtasPorPagar.ReporteCtasPorPagarCentroCosto(1, Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, IIf(rbPendiente.Checked, 1, IIf(rbCancelado.Checked, 2, 3)), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0)), toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value)).Tables(0)
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
                forma.Text = "Reporte de Cuentas x Pagar Detallado"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Proveedor", IIf((txtProveedor.Text = "(Todos)") Or (txtProveedor.Text = "(TODOS)"), "(Todos)", txtProveedor.Text))
                reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                reporte.SetParameterValue("pArea", cmbArea.Text)
                reporte.SetParameterValue("pCentroCosto", cmbCentroCosto.Text)
                reporte.SetParameterValue("pCondicion", IIf(rbPendiente.Checked, "PENDIENTES", IIf(rbCancelado.Checked, "CANCELADOS", "TODOS")))
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
            Dim reporte As New rpCtasxPagarUnidadResumido

            IdProveedor = "0"

            dtReporte = oCtasPorPagar.ReporteCtasPorPagarCentroCosto(2, Session.sCodEmp, IdProveedor, cbFecInicio.Value, cbFecFinal.Value, IIf(rbPendiente.Checked, 1, IIf(rbCancelado.Checked, 2, 3)), IIf(rbComprasLocales.Checked = True, 1, IIf(rbComprasExterior.Checked = True, 2, 0)), toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value)).Tables(0).DefaultView

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
                forma.Text = "Reporte de Cuentas x Pagar Resumido"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                reporte.SetParameterValue("pArea", cmbArea.Text)
                reporte.SetParameterValue("pCentroCosto", cmbCentroCosto.Text)
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub rbDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked = True Then           
            txtProveedor.Text = "(Todos)"
            btnBuscarProveedor.Enabled = True
            rbBuscarProveedor.Enabled = True
            rbBuscarProveedor.Checked = True
            gbOrdenadoPor.Enabled = False
            gbOrden.Enabled = False
            gbMoneda.Enabled = False
        End If
    End Sub

    Private Sub rbResumido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbResumido.CheckedChanged
        If rbResumido.Checked = True Then       
            txtProveedor.Text = ""
            btnBuscarProveedor.Enabled = False
            rbBuscarProveedor.Enabled = False
            rbBuscarProveedor.Checked = False            
            gbOrdenadoPor.Enabled = True
            gbOrden.Enabled = True
            gbMoneda.Enabled = True
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