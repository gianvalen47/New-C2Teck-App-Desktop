Imports System.ServiceModel

Public Class frmRptJobGarantia
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtOficinas As DataTable
    Private dtDatos As New DataTable

    Public IdCliente As Integer = 0    '-------- Agregado el 26/02/2012 -------

    Private Sub frmRptJobGarantia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRptJobGarantia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRptJobGarantia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 120)
        '/*************************************************************************************/

        txtFechaInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFechaFin.Value = Date.Today
        llenarCombos()
        rbxJob.Checked = True
        txtCreditStateDesde.Focus()
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
            '============================== Oficinas =============================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbLocacion.DataSource = dtOficinas
            cmbLocacion.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOS COMBOS :" + ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(120, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If rbxJob.Checked = True Then
            MostrarReporte()
        ElseIf rbxLiquidacion.Checked = True Then
            MostrarReportexLiquidacion()
        End If
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rptJobGarantia

            If utils.toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio")
            ElseIf utils.toBlank(txtFechaFin.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Termino")
            Else

                Dim Inicio As String
                Dim Final As String
                Dim CodOfi As String

                Inicio = utils.toBlank(txtFechaInicio.Text)
                Final = utils.toBlank(txtFechaFin.Text)

                CodOfi = cmbLocacion.Value

                dtDatos = oJobService.ReporteGarantias(CodOfi, utils.toBlank(Inicio), utils.toBlank(Final), txtNroClaim.Text, txtCreditStateDesde.Text, txtCreditStateHasta.Text, 1, 0, IdCliente).Tables(0)

                If dtDatos.Rows.Count <= 0 Then
                    MsgBox("No hay Datos a mostrar en este reporte")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("pOficina", IIf(cmbLocacion.Text = "(Todos)", "Todos", cmbLocacion.Text))
                    reporte.SetParameterValue("pNroClaim", IIf(txtNroClaim.Text = "", "Todos", txtNroClaim.Text))
                    reporte.SetParameterValue("pCreditState", IIf(txtCreditStateDesde.Text = "", "Todos", txtCreditStateDesde.Text))
                    reporte.SetParameterValue("pInicio", Inicio)
                    reporte.SetParameterValue("pFinal", Final)
                    reporte.SetParameterValue("pCliente", IIf(IdCliente = 0, "Todos", txtCliente.Text))      '------Agregado el 26/02/2012
                    'reporte.SetParameterValue("CodOfi", CodOfi)
                    'reporte.SetParameterValue("CreditState1", CreditState1)
                    'reporte.SetParameterValue("NroClaim1", NroClaim1)

                    forma.Text = "Reporte de OT Garantia"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error en el reporte : " + ex.Message)
        End Try
    End Sub

    Private Sub MostrarReportexLiquidacion()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJobGarantiaxLiquidacion
            Dim estado As Integer

            If utils.toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio")
            ElseIf utils.toBlank(txtFechaFin.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Termino")
            Else

                Dim Inicio As String
                Dim Final As String
                Dim CodOfi As String

                Inicio = utils.toBlank(txtFechaInicio.Text)
                Final = utils.toBlank(txtFechaFin.Text)

                CodOfi = cmbLocacion.Value

                If rbTodos.Checked = True Then
                    estado = 0
                ElseIf rbLiquidados.Checked = True Then
                    estado = 1
                ElseIf rbFacturados.Checked = True Then
                    estado = 2
                End If

                dtDatos = oJobService.ReporteGarantias(CodOfi, utils.toBlank(Inicio), utils.toBlank(Final), txtNroClaim.Text, txtCreditStateDesde.Text, txtCreditStateHasta.Text, 2, estado, IdCliente).Tables(0)

                If dtDatos.Rows.Count <= 0 Then
                    MsgBox("No hay Datos a mostrar en este reporte")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("pOficina", IIf(cmbLocacion.Text = "(Todos)", "Todos", cmbLocacion.Text))
                    reporte.SetParameterValue("pNroClaim", IIf(txtNroClaim.Text = "", "Todos", txtNroClaim.Text))
                    reporte.SetParameterValue("pCreditState", IIf(txtCreditStateDesde.Text = "", "Todos", txtCreditStateDesde.Text))
                    reporte.SetParameterValue("pInicio", Inicio)
                    reporte.SetParameterValue("pFinal", Final)
                    reporte.SetParameterValue("pCliente", IIf(IdCliente = 0, "Todos", txtCliente.Text))      '------Agregado el 26/02/2012
                    'reporte.SetParameterValue("CodOfi", CodOfi)
                    'reporte.SetParameterValue("CreditState1", CreditState1)
                    'reporte.SetParameterValue("NroClaim1", NroClaim1)

                    forma.Text = "Reporte de OT Garantia x Liquidación"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error en el reporte : " + ex.Message)
        End Try
    End Sub

    Private Sub rbxLiquidacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbxLiquidacion.CheckedChanged
        If rbxLiquidacion.Checked = True Then
            gbLiquidacion.Enabled = True
            rbTodos.Checked = True
        End If
    End Sub

    Private Sub rbxJob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbxJob.CheckedChanged
        If rbxJob.Checked = True Then
            gbLiquidacion.Enabled = False
        End If
    End Sub


    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '=====================================Agregado el 26/02/2012=====================================
    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===========================================================================================
    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
End Class