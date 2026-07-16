Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmKardex_VerKardex

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete

    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtDatosN As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdLocacion As Integer
    Public CodMer As String
    Private Ajuste As Integer = 0

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                               txtanio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmKardex_VerKardex_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        Me.CancelButton = Me.btnCancelar
        'txtanio.Value = Today.Year
        listaDatos()
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        dgvDatos.RowFormatStyle.FontSize = 9.0!
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        Me.Text = "Lista de Kardex de la Mercadería ( " + CodMer + " )"
        btnImprimir.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "13" Or Session.CodPerfil = "24"), True, False)
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function getTotalIngreso(ByVal columna As String) As Double

        'Dim total As Double = 0
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    Dim r As DataRow
        '    r = dtDatos.Rows.Item(i)
        '    total = total + iidCDbl(r.Item(columna))
        'Next
        'Return total
        'dtDatos = dtDato.ToTable
        Dim total As Double = 0

        For Each Fila As DataRow In dtDatos.Rows
            If Fila.Item("AbrDoc").ToString <> "AJC" Then
                Dim contador As Double
                contador = IIf(Fila.Item("Ingreso") Is DBNull.Value, 0, Fila.Item("Ingreso"))
                total = total + contador
            End If
        Next
        Return total
    End Function
    Private Function getTotalSalida(ByVal columna As String) As Double
        'Dim total As Double = 0
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    Dim r As DataRow
        '    r = dtDatos.Rows.Item(i)
        '    total = total + iidCDbl(r.Item(columna))
        'Next
        'Return total
        Dim total As Double = 0

        For Each Fila As DataRow In dtDatos.Rows
            If Fila.Item("AbrDoc").ToString <> "AJC" Then
                Dim contador As Double
                contador = IIf(Fila.Item("Salida") Is DBNull.Value, 0, Fila.Item("Salida"))
                total = total + contador
            End If
        Next
        Return total
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdLocacion) = 0 Then
                MsgBox("Debe Ingresar el almacén de la mercadería.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(CodMer) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtanio.Value) = 0 Then
                MsgBox("Debe ingresar el año.", MsgBoxStyle.Information, "Información")
                txtanio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub listaDatos()
        Try

            dtDatos = oLocacionMercaderiaService.MostrarKardex(IdLocacion, CodMer, toNumber(txtanio.Value), Ajuste).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            txtTotalIngresos.Text = getTotalIngreso("Ingreso")
            txtTotalEgresos.Text = getTotalSalida("Salida")

        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, chkAbre.TextChanged
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdKardex").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdKardex", codigo)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, chkAbre.TextChanged
        listaDatos()
    End Sub
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
        listaDatos()
    End Sub

    Private Sub chkAbre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAbre.CheckedChanged
        If chkAbre.Checked = True Then
            Ajuste = 1
            listaDatos()
        ElseIf chkAbre.Checked = False Then
            Ajuste = 0
            listaDatos()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepKardex
            Dim FecInicio As Date
            Dim FecFinal As Date

            FecInicio = CDate("01/01/" & txtanio.Value.ToString)

            If Year(Today) = txtanio.Value Then
                FecFinal = Today
            Else
                FecFinal = CDate("31/12/" & txtanio.Value.ToString)
            End If

            dtReporte = oLocacionMercaderiaService.ReporteKardex(IdLocacion, CodMer, FecInicio, FecFinal, 0, 0).Tables(0)
            DataGridView1.DataSource = dtReporte

            CreacionDataTable()

            If dtDatosN.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtDatosN)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False

                forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("cbFecFinal", FecFinal.ToString)
                forma.Text = "Reporte de Kardex"
                ' dtReporte.WriteXmlSchema("D:\SIGECOM\SIGECOM\Interfaces\Costos\Reportes\OrigenDatos\RepKardex.xml")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub CreacionDataTable()


        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodOfi", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesOfi", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodAlm", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesAlm", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesMer1", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("ModMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DeaMer", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("UbiMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMar", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesMar", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesRub", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("IdClase", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomClas", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecDoc", Type.GetType("System.String")))       'datetime
            dtCopia.Columns.Add(New DataColumn("Documento", Type.GetType("System.String")))        'datetime
            dtCopia.Columns.Add(New DataColumn("Referencia", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Ingreso", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Salida", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Stock", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Pedido", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NumJob", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosDol", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosSol", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosProD", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosProS", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Cliente", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMon", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))

            dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "0.00", "0.00", "0.00", "0.00", "1", "1", "1", "0.00"})

            dtDatosN = dtCopia.Copy
            dtDatosN.Clear()

            Dim Saldo As Double = 0

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If DataGridView1.Item(18, i).Value <> "***INICIO***" Then

                    row = dtDatosN.NewRow

                    row(0) = DataGridView1.Item(0, i).Value
                    row(1) = DataGridView1.Item(1, i).Value
                    row(2) = DataGridView1.Item(2, i).Value
                    row(3) = DataGridView1.Item(3, i).Value
                    row(4) = DataGridView1.Item(4, i).Value
                    row(5) = DataGridView1.Item(5, i).Value
                    row(6) = DataGridView1.Item(6, i).Value
                    row(7) = DataGridView1.Item(7, i).Value
                    row(8) = DataGridView1.Item(8, i).Value
                    row(9) = CDbl(DataGridView1.Item(9, i).Value)
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
                    If IsDBNull(DataGridView1.Item(20, i).Value) Then
                        row(20) = 0
                    Else
                        row(20) = CInt(DataGridView1.Item(20, i).Value)
                    End If
                    If IsDBNull(DataGridView1.Item(21, i).Value) Then
                        row(21) = 0
                    Else
                        row(21) = CInt(DataGridView1.Item(21, i).Value)
                    End If
                    If IsDBNull(DataGridView1.Item(22, i).Value) Then
                        row(22) = 0
                    Else
                        row(22) = CInt(DataGridView1.Item(22, i).Value)
                    End If
                    ' row(20) = IIf(IsDBNull(DataGridView1.Item(20, i).Value), "0", CInt(DataGridView1.Item(20, i).Value))
                    'row(20) = IIf(DataGridView1.Item(20, i).Value = "", 0, CInt(DataGridView1.Item(20, i).Value))
                    'row(21) = IIf(IsDBNull(DataGridView1.Item(21, i).Value) = True, 0, CInt(DataGridView1.Item(21, i).Value))
                    'row(22) = IIf(IsDBNull(DataGridView1.Item(22, i).Value) = True, 0, CInt(DataGridView1.Item(22, i).Value))
                    'row(21) = CInt(DataGridView1.Item(21, i).Value)
                    'row(22) = CInt(DataGridView1.Item(22, i).Value)
                    row(23) = DataGridView1.Item(23, i).Value
                    row(24) = DataGridView1.Item(24, i).Value
                    row(25) = CDbl(DataGridView1.Item(25, i).Value)
                    row(26) = CDbl(DataGridView1.Item(26, i).Value)
                    row(27) = CDbl(DataGridView1.Item(27, i).Value)
                    row(28) = CDbl(DataGridView1.Item(28, i).Value)
                    row(29) = CDbl(DataGridView1.Item(29, i).Value)
                    row(30) = DataGridView1.Item(30, i).Value
                    row(31) = DataGridView1.Item(31, i).Value
                    row(32) = DataGridView1.Item(32, i).Value
                    row(33) = CDbl(DataGridView1.Item(33, i).Value)

                    dtDatosN.Rows.Add(row)

                End If
            Next


        Catch ex As Exception
            MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub
End Class
