Imports System.ServiceModel

Public Class frmComputadora_Imprimir

    '=========================== Servicios ===================================================
    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    Public IdComputadora As Integer

    Private dtInsertarMasivo As DataTable
    Private dtCopia As DataTable

    Dim forma As New frmReportes
    Dim dtReporte As New DataTable
    Dim reporte As New rptComputadora

    Private Sub frmComputadora_Imprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim dtReporteVigente As DataTable

            If rbHistorial.Checked Then

                dtReporte = oComputadoraService.ImprimirComputadora(IdComputadora).Tables(0)
                DataGridView1.DataSource = dtReporte
                ImpresionHistorial()

            ElseIf rbVigente.Checked Then

                dtReporteVigente = oComputadoraService.ImprimirComputadora(IdComputadora).Tables(0)
                DataGridView1.DataSource = dtReporteVigente
                ImpresionVigente()

            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub ImpresionVigente()

        Try
            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            'dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
            'dtCopia.Columns.Add(New DataColumn("IdLista", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("IdComputadora", Type.GetType("System.Int32")))
            'dtCopia.Columns.Add(New DataColumn("IdTipoComputadora", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("DesTipoComputadora", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomPc", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("ObsComputadora", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("VigenteC", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("Componente", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Codigo", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("TipoDispositivo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Marca", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Modelo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Serie", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("VideoIntegrado", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("Entrada", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Bus", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Capacidad", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Velocidad", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Voltaje", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Dispositivos", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Generacion", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("LicenciaAplica", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("FecIniLic", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecFinLic", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecIniUso", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecFinUso", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("MotivoFinUso", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecFinGarantia", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Vigente", Type.GetType("System.Boolean")))

            dtCopia.Rows.Add(New Object() {"1", "1", "1", "Nuevo", "Nuevo", "Nuevo", True, "Nuevo", "1", "Nuevo", "Nuevo", "N", "N", "N", "N", True, "N", "N", "1", "0.00", "1", "N", "N", "1", "N", True, "01/01/1999", "01/01/1999", "01/01/1999", "01/01/1999", "N", "01/01/1999", True})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 1 To DataGridView1.Rows.Count - 2

                If CBool(DataGridView1.Item(32, i).Value) = True Then

                    row = dtInsertarMasivo.NewRow

                    'row(0) = DataGridView1.Item(0, i).Value
                    'row(1) = DataGridView1.Item(1, i).Value
                    'row(2) = DataGridView1.Item(2, i).Value
                    'row(3) = DataGridView1.Item(3, i).Value
                    'row(4) = DataGridView1.Item(4, i).Value
                    'row(5) = DataGridView1.Item(5, i).Value
                    'row(6) = DataGridView1.Item(6, i).Value

                    row(0) = DataGridView1.Item(0, 0).Value
                    row(1) = DataGridView1.Item(1, 0).Value
                    row(2) = DataGridView1.Item(2, 0).Value
                    row(3) = DataGridView1.Item(3, 0).Value
                    row(4) = DataGridView1.Item(4, 0).Value
                    row(5) = DataGridView1.Item(5, 0).Value
                    row(6) = DataGridView1.Item(6, 0).Value
                    row(7) = DataGridView1.Item(7, i).Value
                    row(8) = DataGridView1.Item(8, i).Value
                    row(9) = DataGridView1.Item(9, i).Value
                    row(10) = DataGridView1.Item(10, i).Value
                    row(11) = DataGridView1.Item(11, i).Value
                    row(12) = DataGridView1.Item(12, i).Value
                    row(13) = DataGridView1.Item(13, i).Value
                    row(14) = DataGridView1.Item(14, i).Value
                    row(15) = DataGridView1.Item(15, i).Value
                    row(16) = DataGridView1.Item(16, i).Value
                    row(17) = DataGridView1.Item(17, i).Value
                    row(18) = DataGridView1.Item(18, i).Value
                    row(19) = DataGridView1.Item(19, i).Value
                    row(20) = DataGridView1.Item(20, i).Value
                    row(21) = DataGridView1.Item(21, i).Value
                    row(22) = DataGridView1.Item(22, i).Value
                    row(23) = DataGridView1.Item(23, i).Value
                    row(24) = DataGridView1.Item(24, i).Value
                    row(25) = DataGridView1.Item(25, i).Value
                    row(26) = DataGridView1.Item(26, i).Value
                    row(27) = DataGridView1.Item(27, i).Value
                    row(28) = DataGridView1.Item(28, i).Value
                    row(29) = DataGridView1.Item(29, i).Value
                    row(30) = DataGridView1.Item(30, i).Value
                    row(31) = DataGridView1.Item(31, i).Value
                    row(32) = DataGridView1.Item(32, i).Value

                    dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            DataGridView2.DataSource = dtInsertarMasivo

            reporte.SetDataSource(dtInsertarMasivo)
            forma.crvReportes.ReportSource = reporte
            reporte.SetParameterValue("TipoReporte", "VIGENTE")
            forma.Text = "Reporte de Computadora Vigente"
            forma.ShowDialog()

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ImpresionHistorial()
        Try
            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            'dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
            'dtCopia.Columns.Add(New DataColumn("IdLista", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("IdComputadora", Type.GetType("System.Int32")))
            'dtCopia.Columns.Add(New DataColumn("IdTipoComputadora", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("DesTipoComputadora", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomPc", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("ObsComputadora", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("VigenteC", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("Componente", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Codigo", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("TipoDispositivo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Marca", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Modelo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Serie", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("VideoIntegrado", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("Entrada", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Bus", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Capacidad", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Velocidad", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Voltaje", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Dispositivos", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Generacion", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("LicenciaAplica", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("FecIniLic", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecFinLic", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecIniUso", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecFinUso", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("MotivoFinUso", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecFinGarantia", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Vigente", Type.GetType("System.Boolean")))

            dtCopia.Rows.Add(New Object() {"1", "1", "1", "Nuevo", "Nuevo", "Nuevo", True, "Nuevo", "1", "Nuevo", "Nuevo", "N", "N", "N", "N", True, "N", "N", "1", "0.00", "1", "N", "N", "1", "N", True, "01/01/1999", "01/01/1999", "01/01/1999", "01/01/1999", "N", "01/01/1999", True})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 1 To DataGridView1.Rows.Count - 2

                'If CBool(DataGridView1.Item(32, i).Value) = True Then

                row = dtInsertarMasivo.NewRow

                    'row(0) = DataGridView1.Item(0, i).Value
                    'row(1) = DataGridView1.Item(1, i).Value
                    'row(2) = DataGridView1.Item(2, i).Value
                    'row(3) = DataGridView1.Item(3, i).Value
                    'row(4) = DataGridView1.Item(4, i).Value
                    'row(5) = DataGridView1.Item(5, i).Value
                    'row(6) = DataGridView1.Item(6, i).Value

                    row(0) = DataGridView1.Item(0, 0).Value
                    row(1) = DataGridView1.Item(1, 0).Value
                    row(2) = DataGridView1.Item(2, 0).Value
                    row(3) = DataGridView1.Item(3, 0).Value
                    row(4) = DataGridView1.Item(4, 0).Value
                    row(5) = DataGridView1.Item(5, 0).Value
                    row(6) = DataGridView1.Item(6, 0).Value
                    row(7) = DataGridView1.Item(7, i).Value
                    row(8) = DataGridView1.Item(8, i).Value
                    row(9) = DataGridView1.Item(9, i).Value
                    row(10) = DataGridView1.Item(10, i).Value
                    row(11) = DataGridView1.Item(11, i).Value
                    row(12) = DataGridView1.Item(12, i).Value
                    row(13) = DataGridView1.Item(13, i).Value
                    row(14) = DataGridView1.Item(14, i).Value
                    row(15) = DataGridView1.Item(15, i).Value
                    row(16) = DataGridView1.Item(16, i).Value
                    row(17) = DataGridView1.Item(17, i).Value
                    row(18) = DataGridView1.Item(18, i).Value
                    row(19) = DataGridView1.Item(19, i).Value
                    row(20) = DataGridView1.Item(20, i).Value
                    row(21) = DataGridView1.Item(21, i).Value
                    row(22) = DataGridView1.Item(22, i).Value
                    row(23) = DataGridView1.Item(23, i).Value
                    row(24) = DataGridView1.Item(24, i).Value
                    row(25) = DataGridView1.Item(25, i).Value
                    row(26) = DataGridView1.Item(26, i).Value
                    row(27) = DataGridView1.Item(27, i).Value
                    row(28) = DataGridView1.Item(28, i).Value
                    row(29) = DataGridView1.Item(29, i).Value
                    row(30) = DataGridView1.Item(30, i).Value
                    row(31) = DataGridView1.Item(31, i).Value
                    row(32) = DataGridView1.Item(32, i).Value

                    dtInsertarMasivo.Rows.Add(row)

                'End If
            Next

            DataGridView2.DataSource = dtInsertarMasivo

            reporte.SetDataSource(dtInsertarMasivo)
            forma.crvReportes.ReportSource = reporte

            reporte.SetParameterValue("TipoReporte", "HISTORIAL")

            forma.Text = "Reporte de Computadora"
            forma.ShowDialog()

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComputadora_Imprimir_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComputadora_Imprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub
End Class