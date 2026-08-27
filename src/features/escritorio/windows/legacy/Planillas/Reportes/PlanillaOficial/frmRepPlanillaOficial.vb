Imports System.ServiceModel
Public Class frmRepPlanillaOficial

    '===========================Servicios====================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    '======================Declaración de Variables==============================   
    Private dtDatos As New DataTable
    Private dtUnidades As DataTable

    Private Sub frmRepRegCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosService.Close()
            oSeguridadService.Close()
            oCentroCostoService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
        End Try
    End Sub

    Private Sub frmRepRegCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepPlanillaOficial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 194)
        '/*************************************************************************************/

        Me.Text = "Planilla Oficial de Sueldos"
        txtIdPlanilla.Focus()
        llenarCombos()
        txtPeriodo.Value = Today.Year
        txtMesRegistro.Text = Format(Month(Today), "00")
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
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPlanillaSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPlanillaSueldo.Click
        Try
            Dim frm As New frmBuscarPlanillaSueldo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtIdPlanilla.Text = frm.codigo
                    btnAceptar.Focus()
                Else
                    txtIdPlanilla.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtIdPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdPlanilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtIdPlanilla.Text)) > 0 Then
                If Not (oPlanillaSueldosService.BuscarPlanilla(toNumber(txtIdPlanilla.Text))) Then
                    MsgBox("Número de Planilla no existente, Verifique")
                    txtIdPlanilla.Text = ""
                    txtIdPlanilla.Focus()
                Else
                    btnAceptar.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de Planilla")
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            oSeguridadService.RegistrarVisitaOpciones(194, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If rbPlanilla.Checked = True Then
                If oPlanillaSueldosService.BuscarPlanilla(toNumber(txtIdPlanilla.Text)) Then

                    If rbDetalle.Checked = True Then

                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptPlanillaOficial

                        dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(txtIdPlanilla.Text), 0, 0, "", toNumber(cmbUnidad.Value), 2).Tables(0)

                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte
                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            forma.Text = "Reporte Planilla Oficial"
                            forma.ShowDialog()
                        End If

                    ElseIf rbResumen.Checked = True Then

                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptPlanillaResumen

                        dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, toNumber(txtIdPlanilla.Text), 0, 0, "", 0, 4).Tables(0)

                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte
                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            reporte.SetParameterValue("pIdPlanilla", txtIdPlanilla.Text)
                            forma.Text = "Reporte Resumen de Planilla"
                            forma.ShowDialog()
                        End If

                    End If
                Else
                    MsgBox("¡No existe Nº de Planilla.!", MsgBoxStyle.Information, "Información")
                    txtIdPlanilla.Focus()
                End If

            ElseIf rbPeriodo.Checked Then
                If txtMesRegistro.Text <> "" Then

                    If rbDetalle.Checked = True Then

                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptPlanillaOficial

                        dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, 0, 0, txtPeriodo.Value, txtMesRegistro.Text, toNumber(cmbUnidad.Value), 2).Tables(0)

                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte
                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            forma.Text = "Reporte Planilla Oficial"
                            forma.ShowDialog()
                        End If

                    ElseIf rbResumen.Checked = True Then

                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rptPlanillaResumen

                        dtReporte = oPlanillaSueldosService.ImprimirBoletaPago(Session.sCodEmp, 0, 0, txtPeriodo.Value, txtMesRegistro.Text, 0, 4).Tables(0)

                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte
                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            reporte.SetParameterValue("pIdPlanilla", txtIdPlanilla.Text)
                            forma.Text = "Reporte Resumen de Planilla"
                            forma.ShowDialog()
                        End If

                    End If
                Else
                    MsgBox("¡Debe ingresar el Mes y Periodo!", MsgBoxStyle.Information, "Información")
                    txtMesRegistro.Focus()
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Finalizar()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbPlanilla_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbPlanilla.CheckedChanged, rbPeriodo.CheckedChanged
        If rbPlanilla.Checked = True Then
            txtIdPlanilla.ReadOnly = False
            txtIdPlanilla.BackColor = System.Drawing.SystemColors.Window
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtPeriodo.Value = Today.Year
            txtMesRegistro.Text = Format(Month(Today), "00")
        ElseIf rbPeriodo.Checked = True Then
            txtIdPlanilla.ReadOnly = True
            txtIdPlanilla.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = False
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
            txtPeriodo.ReadOnly = False
            txtPeriodo.BackColor = System.Drawing.SystemColors.Window
            txtPeriodo.Value = Today.Year
            txtMesRegistro.Text = Format(Month(Today), "00")
            txtIdPlanilla.Text = ""
        End If
    End Sub

    Private Sub rbDetalle_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbDetalle.CheckedChanged, rbResumen.CheckedChanged
        If rbDetalle.Checked = True Then
            cmbUnidad.ReadOnly = False
            cmbUnidad.BackColor = System.Drawing.SystemColors.Window

        ElseIf rbResumen.Checked = True Then
            cmbUnidad.ReadOnly = True
            cmbUnidad.BackColor = System.Drawing.SystemColors.Control
            cmbUnidad.SelectedIndex = 0
        End If
    End Sub
End Class