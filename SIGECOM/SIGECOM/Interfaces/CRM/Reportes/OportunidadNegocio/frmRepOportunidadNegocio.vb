Imports System.ServiceModel

Public Class frmRepOportunidadNegocio

    '============================Servicios===================================
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oVisitaOportunidadService As New VisitaOportunidadService.VisitaOportunidadServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================
    Public IdCliente As Integer
    Private dtVendedor As DataTable
    Private dtEtapa As DataTable
    Private dtTipoVisita As DataTable

    Private Sub frmRepOportunidadNegocio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOportunidadNegocioService.Close()
            oVisitaOportunidadService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
            oVisitaOportunidadService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
            oVisitaOportunidadService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepOportunidadNegocio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepOportunidadNegocio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 292)
        '/*************************************************************************************/

        txtFechaInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFechaFin.Value = Date.Today
        llenarCombos()
        rbResumen.Checked = True
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
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= VENDEDOR ===========================================
            dtVendedor = oPersonaService.MostrarVendedoresVigente(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowTodos(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.SelectedIndex = 0
            dtVendedor = Nothing

            '======================================= ETAPAS ===========================================
            dtEtapa = oOportunidadNegocioService.MostrarEtapasNegocio().Tables(0)
            dtEtapa.Rows.InsertAt(getRowTodos(dtEtapa), 0)
            cmbEtapa.DataSource = dtEtapa
            cmbEtapa.DropDownList.DataMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.DisplayMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.ValueMember = dtEtapa.Columns("IdEtapa").ToString
            cmbEtapa.DropDownList.Columns(0).DataMember = dtEtapa.Columns("IdEtapa").ToString
            cmbEtapa.DropDownList.Columns(1).DataMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.Columns(2).DataMember = dtEtapa.Columns("Peso").ToString
            cmbEtapa.SelectedIndex = 0
            dtEtapa = Nothing

            ''===================================== TIPO DE VISITA ============================================
            dtTipoVisita = oVisitaOportunidadService.MostrarTipoVisita().Tables(0)
            dtTipoVisita.Rows.InsertAt(getRowTodos(dtTipoVisita), 0)
            cmbTipoVisita.DataSource = dtTipoVisita
            cmbTipoVisita.DropDownList.DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.DisplayMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.ValueMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(0).DataMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(1).DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.SelectedIndex = 0
            dtTipoVisita = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbResumen_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbResumen.CheckedChanged, rbDetallado.CheckedChanged
        Try
            If rbResumen.Checked = True Then
                cmbTipoVisita.ReadOnly = True
                cmbTipoVisita.BackColor = System.Drawing.SystemColors.Control
                cmbTipoVisita.Value = 0
            ElseIf rbDetallado.Checked = True Then
                cmbTipoVisita.ReadOnly = False
                cmbTipoVisita.BackColor = System.Drawing.SystemColors.Window
            End If
        Catch ex As Exception
            MsgBox("ERROR SELECCIONAR EL TIPO DE REPORTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
        rbBuscarCliente.Checked = False
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        If rbBuscarCliente.Checked = True Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown        
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)
            End If
        End If        
    End Sub

    Private Sub cmbVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbVendedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtTipoProducto.Focus()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporteRes As New rpOportunidadNegocioResumen
            Dim reporteDet As New rpOportunidadNegocioDetalle

            If rbResumen.Checked = True Then

                dtReporte = oOportunidadNegocioService.ReporteOportunidadNegocio(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, txtNombre.Text, _
                                                                                                                    IdCliente, toNumber(cmbVendedor.Value), txtTipoProducto.Text, txtDescripcion.Text, _
                                                                                                                    toNumber(cmbEtapa.Value)).Tables(0).DefaultView

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbPantalla.Checked = True Then

                        reporteRes.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteRes
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Oportunidad de Negocio Totalizado"
                        reporteRes.SetParameterValue("pFecInicio", txtFechaInicio.Value)
                        reporteRes.SetParameterValue("pFecFin", txtFechaFin.Value)
                        reporteRes.SetParameterValue("pEtapa", cmbEtapa.Text)
                        reporteRes.SetParameterValue("pNombre", IIf(txtNombre.Text = "", " -", txtNombre.Text))
                        reporteRes.SetParameterValue("pCliente", IIf((txtCliente.Text = "(Todos)") Or (txtCliente.Text = "(TODOS)"), "(Todos)", txtCliente.Text))
                        reporteRes.SetParameterValue("pVendedor", IIf(cmbVendedor.Text = "(Todos)", "(Todos)", cmbVendedor.Text))
                        reporteRes.SetParameterValue("pTipoProducto", IIf(txtTipoProducto.Text = "", " -", txtTipoProducto.Text))
                        reporteRes.SetParameterValue("pDescripcion", IIf(txtDescripcion.Text = "", " -", txtDescripcion.Text))                                
                        forma.ShowDialog()

                    ElseIf rbExcel.Checked = True Then
                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    End If
                End If


            ElseIf rbDetallado.Checked = True Then

                dtReporte = oOportunidadNegocioService.ReporteOportunidadNegocioDetalle(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, txtNombre.Text, _
                                                                                                                    IdCliente, toNumber(cmbVendedor.Value), txtTipoProducto.Text, txtDescripcion.Text, _
                                                                                                                    toNumber(cmbEtapa.Value), toNumber(cmbTipoVisita.Value)).Tables(0).DefaultView

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbPantalla.Checked = True Then

                        reporteDet.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteDet
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Oportunidad de Negocio Detallado"
                        reporteDet.SetParameterValue("pFecInicio", txtFechaInicio.Value)
                        reporteDet.SetParameterValue("pFecFin", txtFechaFin.Value)
                        reporteDet.SetParameterValue("pEtapa", cmbEtapa.Text)
                        reporteDet.SetParameterValue("pNombre", IIf(txtNombre.Text = "", " -", txtNombre.Text))
                        reporteDet.SetParameterValue("pCliente", IIf((txtCliente.Text = "(Todos)") Or (txtCliente.Text = "(TODOS)"), "(Todos)", txtCliente.Text))
                        reporteDet.SetParameterValue("pVendedor", IIf(cmbVendedor.Text = "(Todos)", "(Todos)", cmbVendedor.Text))
                        reporteDet.SetParameterValue("pTipoProducto", IIf(txtTipoProducto.Text = "", " -", txtTipoProducto.Text))
                        reporteDet.SetParameterValue("pDescripcion", IIf(txtDescripcion.Text = "", " -", txtDescripcion.Text))
                        reporteDet.SetParameterValue("pTipoVisita", IIf(cmbTipoVisita.Text = "(Todos)", "(Todos)", cmbTipoVisita.Text))
                        forma.ShowDialog()

                    ElseIf rbExcel.Checked = True Then
                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        '  Finalizar()
        Me.Close()
    End Sub
End Class