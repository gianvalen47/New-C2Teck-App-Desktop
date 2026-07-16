Imports System.ServiceModel
Public Class frmRepContCtasCtesPend

    '===========================Servicios====================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables=============================  
    Private dtDatos As DataTable
    Public IdPersona As Integer
    Public IdProveedor As Integer
    Private dtUnidades As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable

    Private Sub frmRepContCtasCtesPend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 198)
        '/*************************************************************************************/

        llenarCombos()
        txtFecha.Value = Today
        txtFecha.Focus()
    End Sub

    Private Sub btnBuscarCuenta1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta1.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta1.Text = frm.codigo
                    txtCodCuenta2.Text = txtCodCuenta1.Text
                    txtCodCuenta2.Focus()
                Else
                    txtCodCuenta1.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCuenta2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta2.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta2.Text = frm.codigo
                    btnAceptar.Focus()
                Else
                    txtCodCuenta2.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta1.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta1.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta1_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta1.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta1.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta1.Text = ""
                    txtCodCuenta1.Focus()
                Else
                    txtCodCuenta2.Text = txtCodCuenta1.Text
                    txtCodCuenta2.Focus()
                End If
            Else
                txtCodCuenta2.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuenta1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta1.Validated
        If Len(Trim(txtCodCuenta1.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta1.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCuenta1.Text = ""
                txtCodCuenta1.Focus()
            Else
                txtCodCuenta2.Text = txtCodCuenta1.Text
                txtCodCuenta2.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub txtCodCuenta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta2.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta2.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta2_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta2.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta2.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta2.Text = ""
                    txtCodCuenta2.Focus()
                Else
                    btnAceptar.Focus()
                End If
            Else
                btnAceptar.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuenta2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta2.Validated
        If Len(Trim(txtCodCuenta2.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta2.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCuenta2.Text = ""
                txtCodCuenta2.Focus()
            Else
                btnAceptar.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                    rbBuscarProveedor.Checked = False
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                    rbBuscarPersona.Checked = False
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbBuscarPersona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarPersona.CheckedChanged
        If rbBuscarPersona.Checked = True Then
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
        End If
    End Sub

    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos1(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos1(dtAreas), 0)
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
            dtCentroCosto.Rows.InsertAt(getRowTodos1(dtCentroCosto), 0)
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(198, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            oContabilidadService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            dtReporte = oContabilidadService.ReporteCtaCtesPendientes(Session.sCodEmp, toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), txtFecha.Value, IdProveedor, IdPersona, txtCodCuenta1.Text, txtCodCuenta2.Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbDetalle.Checked = True Then
                    Dim reporte As New rpContCtasCtesPend

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Cuentas Corrientes Pendientes Detallado"
                    reporte.SetParameterValue("pFecha", txtFecha.Value)
                    reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                    reporte.SetParameterValue("pArea", cmbArea.Text)
                    reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                    forma.ShowDialog()

                ElseIf rbResumido.Checked = True Then

                    If rbProveedor.Checked = True Then
                        Dim reporte As New rpContCtasCtesPendResProv

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Cuentas Corrientes Pendientes Resumido por Proveedor"
                        reporte.SetParameterValue("pFecha", txtFecha.Value)
                        reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                        reporte.SetParameterValue("pArea", cmbArea.Text)
                        reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                        forma.ShowDialog()

                    ElseIf rbDocumento.Checked = True Then
                        Dim reporte As New rpContCtasCtesPendResDoc

                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Cuentas Corrientes Pendientes Resumido por Documento"
                        reporte.SetParameterValue("pFecha", txtFecha.Value)
                        reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                        reporte.SetParameterValue("pArea", cmbArea.Text)
                        reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                        forma.ShowDialog()
                    End If
                End If
            End If
 

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
            oCuentaContableService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oCuentaContableService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oCuentaContableService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtFecha.KeyPress _
                      , cmbUnidad.KeyPress _
                      , cmbArea.KeyPress _
                      , cmbCentroCosto.KeyPress _
                      , txtProveedor.KeyPress _
                      , txtColaborador.KeyPress _
                      , txtCodCuenta2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rbDetalle_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbDetalle.CheckedChanged, rbResumido.CheckedChanged
        If rbDetalle.Checked = True Then
            gbResumido.Enabled = False
        ElseIf rbResumido.Checked = True Then
            gbResumido.Enabled = True
        End If
    End Sub
End Class