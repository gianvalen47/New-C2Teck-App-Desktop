Imports System.ServiceModel
Public Class frmComSolicitudGasto_Imprimir

    '===========================Servicios====================================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public idGasto As Integer
    Public iAnio As Integer
    Public iMes As Integer
    Public iCodArea As String
    Public iCodCentro As String
    Public iIdPer As Integer
    Public iIdGasto As Integer
    Public iIdEstado As Integer
    Public iSolicitante As String
    Public iDesMes As String
    Public iDesArea As String
    Public iDesEstado As String
    Public IdProvisional As Integer
    Public GastoViaje As Boolean
    Public IdTipo As String

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oSolicitudGastoService) = False Then
                oSolicitudGastoService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If GastoViaje = True Then
        If IdProvisional > 0 And IdTipo = "1" Then
            rbGastoViaje.Enabled = True
            rbGastoViaje.Checked = True
            cbResumenProvisional.Checked = True
            rbDeclaracionJurada.Enabled = True
        Else
            rbGastoViaje.Enabled = False
            rbPrincipal.Checked = True
            cbResumenProvisionalGen.Checked = True
            rbDeclaracionJurada.Enabled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If rbPrincipal.Checked = True Then
            Try
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptComSolicitudGastos
                Dim subreporte As New rptComSolicitudGastos1
                If idGasto <> 0 Then
                    dtReporte = oSolicitudGastoService.Imprimir(idGasto).Tables(0)
                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay datos a mostrar")
                    Else
                        reporte.SetDataSource(dtReporte)
                        subreporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        'forma.crvReportes.DisplayGroupTree = False
                        reporte.SetParameterValue("pIdMesa", 0)
                        reporte.SetParameterValue("pResumenProvisionalGen", cbResumenProvisionalGen.Checked)
                        forma.Text = "Reporte de Solicitud de Gastos Formato Principal"
                        forma.ShowDialog()
                    End If
                Else
                    MsgBox("Número de Gasto Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        ElseIf rbGastoViaje.Checked = True And IdProvisional > 0 And IdTipo = "1" Then 'GastoViaje = True Then
            Try
                Dim forma As New frmReportes
                Dim dtReporte As New DataView
                Dim reporte As New rptComSolicitudGastos_GastoViaje
                If idGasto <> 0 Then
                    dtReporte = oSolicitudGastoService.Imprimir(idGasto).Tables(0).DefaultView
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay datos a mostrar")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Solicitud de Gastos Fomato Gasto de Viaje"
                        reporte.SetParameterValue("pResumenProvisional", cbResumenProvisional.Checked)
                        forma.ShowDialog()
                    End If
                Else
                    MsgBox("Número de Gasto Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        ElseIf rbDeclaracionJurada.Checked = True And IdProvisional > 0 Then 'GastoViaje = True Then
            Try
                Dim forma As New frmReportes
                Dim dtReporte As New DataView
                Dim reporte As New rptComSolicitudGasto_Ext
                If idGasto <> 0 Then
                    dtReporte = oSolicitudGastoService.Imprimir(idGasto).Tables(0).DefaultView
                    dtReporte.RowFilter = "SerDoc is Null And NumDoc Is Null And IdRubro In (1,5)"                    
                    If dtReporte.Count = 0 Then
                        MsgBox("No hay datos a mostrar")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        ' Validar Usuario - Exportar Excel
                        'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        '    forma.crvReportes.ShowExportButton = True
                        'Else
                        '    forma.crvReportes.ShowExportButton = False
                        'End If
                        'forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Declaración Jurada"
                        forma.ShowDialog()
                    End If
                Else
                    MsgBox("Número de Gasto Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        ElseIf rbListado.Checked = True Then
            Try
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptComSolicitudGasto_Listado
                dtReporte = oSolicitudGastoService.Filtrar(Session.sCodEmp, iAnio, iMes, iCodArea, iCodCentro, iIdPer, iIdGasto, iIdEstado, Session.sCodUsu).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    'If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    '    forma.crvReportes.ShowExportButton = True
                    'Else
                    '    forma.crvReportes.ShowExportButton = False
                    'End If
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Listado de Solicitudes de Gastos"
                    reporte.SetParameterValue("pAnio", iAnio)
                    reporte.SetParameterValue("pMes", iDesMes)
                    reporte.SetParameterValue("pArea", iDesArea)
                    reporte.SetParameterValue("pEstado", iDesEstado)
                    reporte.SetParameterValue("pSolicitante", iSolicitante)
                    reporte.SetParameterValue("pIdGasto", IIf(iIdGasto = 0, "-", iIdGasto))
                    forma.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
        End Try
    End Sub

    Private Sub rbGastoViaje_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbGastoViaje.CheckedChanged
        If rbGastoViaje.Checked Then
            cbResumenProvisional.Enabled = True
        End If
    End Sub

    Private Sub rbPrincipal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPrincipal.CheckedChanged
        If rbPrincipal.Checked Then
            cbResumenProvisional.Enabled = False
        End If
    End Sub

    Private Sub rbListado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbListado.CheckedChanged
        If rbListado.Checked Then
            cbResumenProvisional.Enabled = False
        End If
    End Sub

    Private Sub rbDeclaracionJurada_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbDeclaracionJurada.CheckedChanged
        If rbDeclaracionJurada.Checked Then
            cbResumenProvisional.Enabled = False
        End If
    End Sub
End Class