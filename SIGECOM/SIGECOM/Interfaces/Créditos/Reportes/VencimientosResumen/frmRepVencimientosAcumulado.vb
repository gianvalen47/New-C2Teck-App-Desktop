Imports System.ServiceModel
Public Class frmRepVencimientosAcumulado
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private TipCta As String

    Private dtMonedas As DataTable
    Private dtTipoDocumentos As DataTable

    Private Sub frmRepVencimientosDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            oDocumentoCtaCtesService.Close()
            oMaestroService.Close()

        Catch ex As TimeoutException

            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()

        Catch ex As CommunicationException

            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()

        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepVencimientosDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepVencimientosDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress _
            , cmbCodMon.KeyPress _
            , cmbDocu.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepVencimientosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        cmbCodMon.Value = "US"
        cbFecInicio.Select()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oMaestroService.MostrarTipDocCtaCte.Tables(0)
            Dim row As DataRow = dtTipoDocumentos.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocu.SelectedIndex = 0
            dtTipoDocumentos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rpRepVentaAcumulada

            dtReporte = oDocumentoCtaCtesService.RepVencimientos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, 0, 0, cmbDocu.Value, 0, 2).Tables(0).DefaultView
            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                forma.Text = "Reporte de Vencimientos Acumulado"

                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("Documento", cmbDocu.Text)
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbCtasCtes_ToggleStateChanged(ByVal sender As System.Object, ByVal args As Telerik.WinControls.UI.StateChangedEventArgs) Handles rbCtasCtes.ToggleStateChanged
        If rbCtasCtes.ToggleState Then
            TipCta = 1
        ElseIf rbProvisiones.ToggleState Then
            TipCta = 2
        ElseIf rbCastigos.ToggleState Then
            TipCta = 3
            'ElseIf rbTodos.ToggleState Then
            '    TipCta = ""
        End If
    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAceptar.Click
        MostrarReporte()
    End Sub
End Class