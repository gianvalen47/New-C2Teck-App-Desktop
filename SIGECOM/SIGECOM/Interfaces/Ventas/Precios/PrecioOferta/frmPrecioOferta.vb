Imports System.Data.OleDb
Imports System.ServiceModel

Public Class frmPrecioOferta

    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private IdCliente As Integer
    Private dtDatos As New DataTable
    Private dtRubros As DataTable
    Private dtInsertarMasivo As DataTable
    Private DirFile As String
    Private fileExt As String

    Private Sub frmPrecioOferta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPrecioService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oPrecioService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oPrecioService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmPrecioOferta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPrecioOferta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        listaDatos()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= RUBROS ================================================
            dtRubros = oMaestroService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub listaDatos()
        Try
            dtDatos = oPrecioService.MostrarPrecioOferta(Session.sCodEmp, cmbRubro.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        nuevo()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        mostrar()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
        End If
    End Sub

    Private Sub biFormatoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFormatoExcel.Click, miFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")

        dtExcel.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Precio Venta US", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Precio Venta NS", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"", "0.00", "0.00", ""})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodMer").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptPrecioOferta

            If dgvDatos.RowCount > 0 Then
                dtReporte = oPrecioService.MostrarPrecioOferta(Session.sCodEmp, cmbRubro.Value).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("Rubro", cmbRubro.Text)
                    forma.Text = "Reporte de Precio Lista"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Precio Oferta"
    End Sub

    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Precio Oferta"
    End Sub

    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Precio Oferta Seleccionada"
    End Sub

    Private Sub biFormatoExcel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biFormatoExcel.MouseEnter, miFormatoExcel.MouseEnter
        sslError.Text = "Descargar Formato Excel"
    End Sub

    Private Sub biActualizar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar"
    End Sub

    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Precio Oferta"
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                             biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                             biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                             biAprobar.MouseLeave, biVerEstados.MouseLeave, _
                             miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                             miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                             miAprobar.MouseLeave, miVerEstados.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmPrecioOfertaNuevo
            frm.state_button = True
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.CodMer)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.CodMer)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmPrecioOfertaNuevo
                frm.state_button = False
                'frm.CodMer = CodMer
                'frm.CodRubro = cmbRubro.Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ListaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.CodMer)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CStr(row.Cells("CodMer").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPrecioService.BorrarPrecioOferta(Session.sCodEmp, dgvDatos.CurrentRow.Cells("CodMer").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBuscar.Click
        BuscarMercaderia()
    End Sub

    Private Sub BuscarMercaderia()
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows
                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then
                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1
                        Exit For
                    End If
                Next
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miInsertarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInsertarLista.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        'OpenFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            'If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
            '    MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
            '    Exit Sub
            'Else
            CargarGrilla()
            'End If
            CreacionTable()
            'If DtLimite >= 280 Then
            '    MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            'Else
            InsertarMasivo()
            'End If
        End If
    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, "Hoja4$")
    End Sub

    Private Function GetDataExcel(ByVal fileName As String, ByVal source As String) As DataTable

        Try
            If fileExt = ".xlsx" Then
                Using cnn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" & _
                        "Extended Properties='Excel 12.0 Xml;HDR=Yes';" & "Data Source=" & fileName)

                    Dim sql As String = String.Format("SELECT * FROM [{0}]", source)
                    Dim da As New OleDbDataAdapter(sql, cnn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Return dt

                End Using
            ElseIf fileExt = ".xls" Then
                Using cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                        "Extended Properties='Excel 8.0;HDR=Yes';" & "Data Source=" & fileName)

                    Dim sql As String = String.Format("SELECT * FROM [{0}]", source)
                    Dim da As New OleDbDataAdapter(sql, cnn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Return dt

                End Using

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Sub CreacionTable()
        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            dtCopia.Columns.Add(New DataColumn("CodEmp", Type.GetType("System.string")))
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("PreVenUS", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("PreVenNS", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodUsu", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomPc", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DirIp", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"1", "1", "5.00", "14.00", "Obser", "Nuevo", "Nuevo", "Nuevo"})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    row = dtInsertarMasivo.NewRow

                    row(0) = Session.sCodEmp
                    row(1) = Trim(DataGridView1.Item(0, i).Value)
                    row(2) = IIf(IsDBNull(DataGridView1.Item(1, i).Value) = True, "0.00", CDbl(DataGridView1.Item(1, i).Value))
                    row(3) = IIf(IsDBNull(DataGridView1.Item(2, i).Value) = True, "0.00", CDbl(DataGridView1.Item(2, i).Value))  'DataGridView1.Item(2, i).Value
                    row(4) = IIf(IsDBNull(DataGridView1.Item(3, i).Value) = True, "", DataGridView1.Item(3, i).Value)
                    row(5) = Session.sCodUsu
                    row(6) = Session.sNomPc
                    row(7) = Session.sDirIp

                    dtInsertarMasivo.Rows.Add(row)
                End If
            Next
            'DtLimite = dtInsertarMasivo.Rows.Count
            'DataGridView1.DataSource = Nothing

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarMasivo()
        Try
            Dim estado_process As Boolean
            estado_process = oPrecioService.InsertarMasivoPrecioLista(dtInsertarMasivo)

            If estado_process = True Then
                MsgBox("Se Inserto la Lista de Precio Correctamente", MsgBoxStyle.Information)
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MASIVO LA LISTA DE OFERTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        actualizar()
    End Sub
End Class