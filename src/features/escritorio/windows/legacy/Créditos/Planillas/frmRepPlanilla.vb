Imports System.ServiceModel
Public Class frmRepPlanilla
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private IdPer As String
    Private dtCobrador As New DataTable

    Private Sub frmRepPlanilla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            oPlanillaService.Close()

        Catch ex As TimeoutException
            ObjMaestro.Abort()
            oPlanillaService.Abort()

        Catch ex As CommunicationException
            ObjMaestro.Abort()
            oPlanillaService.Abort()

        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
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

        'Try
        '    fila(5) = "(Todos)"
        'Catch ex As Exception

        'End Try

        Return fila
    End Function

    Private Sub frmRepPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmRepPlanilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
             cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cmbCobrador.Value = "(Todos)"
        llenarCombos()
        cbFecInicio.Select()


    End Sub
    Private Sub llenarCombos()
        Try
            dtCobrador = ObjMaestro.MostrarCobradores.Tables(0)
            dtCobrador.Rows.InsertAt(getRowTodos(dtCobrador), 0)
            cmbCobrador.DataSource = dtCobrador
            cmbCobrador.DisplayMember = "ApeNom"
            cmbCobrador.ValueMember = "IdPer"
            cmbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cmbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            'cbCobrador.SelectedIndex = 0
            dtCobrador = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepPlanilla

           
            dtReporte = oPlanillaService.Reporte(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                forma.Text = "Reporte de Planilla de Cobranzas"
                ' dtReporte.WriteXmlSchema("C:\RepPlanilla.xml")
               

                forma.ShowDialog()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    
    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAceptar.Click
        MostrarReporte()

    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class