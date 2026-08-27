Imports System.ServiceModel
Public Class frmRepComisiones
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private ObjSeg As New SeguridadService.SeguridadClient
    Private Sub frmRepComisiones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReporteVentaService.Close()
            ObjCierre.Close()
            ObjSeg.Close()
        Catch ex As TimeoutException
            oReporteVentaService.Abort()
            ObjCierre.Abort()
            ObjSeg.Abort()
        Catch ex As CommunicationException
            oReporteVentaService.Abort()
            ObjCierre.Abort()
            ObjSeg.Abort()
        End Try
    End Sub

    Private Sub frmRepComisiones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReporteImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        ObjSeg.InsertarSesionOpciones(Session.sIdSesion, 277)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        txtFechaInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        txtFechaFin.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)

        btnAceptar.Enabled = IIf(ObjSeg.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

        txtFechaInicio.Select()

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If validarData() Then
            If rbComisionesVendedor.Checked = True Then
                'If ObjCierre.VerificarCierre(Session.sCodEmp, txtFechaInicio.Value, 1) = False Then
                '    MsgBox("¡Aún no se ha Cerrado Documentos este mes, no se puede mostrar el Reporte!", MsgBoxStyle.Information, "Error")
                'ElseIf ObjCierre.VerificarCierre(Session.sCodEmp, txtFechaInicio.Value, 2) = False Then
                '    MsgBox("¡Aún no se ha Cerrado Costos este mes, no se puede mostrar el Reporte!", MsgBoxStyle.Information, "Error")
                'Else
                MostrarReporte()
                    ObjSeg.RegistrarVisitaOpciones(277, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'End If

            ElseIf rbCompensacionAllison.Checked = True Then
                MostrarReporte()
            End If
        End If
    End Sub

    Private Sub MostrarReporte()
        Dim dtReporte As New DataTable

        If rbComisionesVendedor.Checked = True Then
            oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
            dtReporte = oReporteVentaService.VentaDetalle(Session.sCodEmp, "", 0, txtFechaInicio.Value, txtFechaFin.Value, 0, 0, "", 0, "", 0, 5).Tables(0)

            DataGridView1.DataSource = dtReporte
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                Dim Export As Boolean = ExportarExcel(DataGridView1)
                If Export Then
                    MsgBox("Se realizó la exportación correctamente")
                End If
            End If

        ElseIf rbCompensacionAllison.Checked = True Then
            oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
            dtReporte = oReporteVentaService.VentaDetalle(Session.sCodEmp, "", 0, txtFechaInicio.Value, txtFechaFin.Value, 0, 0, "", 0, "", 0, 6).Tables(0)

            DataGridView1.DataSource = dtReporte
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                Dim Export As Boolean = ExportarExcel(DataGridView1)
                If Export Then
                    MsgBox("Se realizó la exportación correctamente")
                End If
            End If
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function validarData() As Boolean
        If txtFechaInicio.Value > txtFechaFin.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            txtFechaInicio.Focus()
            Return False
        ElseIf Year(txtFechaInicio.Value) <> Year(txtFechaFin.Value) Then
            MsgBox("La Fechas ingresadas deben pertenecer al mismo Periodo")
            txtFechaInicio.Focus()
            Return False
        ElseIf Month(txtFechaInicio.Value) <> Month(txtFechaFin.Value) Then
            MsgBox("La Fechas ingresadas deben pertenecer al mismo Mes")
            txtFechaInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub frmRepVentaComisiones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    rbComisionesVendedor.KeyPress _
           , rbCompensacionAllison.KeyPress _
           , txtFechaInicio.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFechaFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            btnAceptar.Select()
            '            e.Handled = True
        End If
    End Sub

End Class