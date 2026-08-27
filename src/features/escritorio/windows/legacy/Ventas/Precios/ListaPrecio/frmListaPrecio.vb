Imports System.Data.OleDb
Imports System.ServiceModel

Public Class frmListaPrecio

    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private IdCliente As Integer
    Private dtDatos As New DataTable
    Private dtRubros As DataTable
    Private dtEstados As DataTable
    Private dtInsertarMasivo As DataTable
    Private DirFile As String
    Private fileExt As String
    Private iEstado As Integer

    Private Sub frmPrecioLista2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPrecioService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPrecioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPrecioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmPrecioLista2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPrecioLista2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        listaDatos()

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
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

            '======================================= ESTADOS ================================================
            dtEstados = oPrecioService.MostrarEstadosListaPrecio.Tables(0)

            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstados.DataSource = dtEstados
            cmbEstados.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstados.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstados.SelectedIndex = 0
            dtRubros = Nothing


        Catch ex As Exception
            MsgBox("Error al llenar combos" + ex.Message, MsgBoxStyle.Exclamation)
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
            dtDatos = oPrecioService.MostrarListaPrecio(Session.sCodEmp, cmbRubro.Value, txtCodMer.Text, utils.toNumber(cmbEstados.Value)).Tables(0)
            'MostrarListaPrecio
            dgvDatos.DataSource = dtDatos
            enableOpciones()

        Catch ex As Exception
            MsgBox("Error al listar datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()

        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biAprobar.Enabled = False
            biEnviar.Enabled = False
            biVencimiento.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miAprobar.Enabled = False
            miEnviar.Enabled = False
            miVencimiento.Enabled = False

        Else
            iEstado = dgvDatos.CurrentRow.Cells("IdEstado").Value
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biVerEstados.Enabled = True
            biAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3, True, False)
            biEnviar.Enabled = IIf(iEstado = 1, True, False)
            biVencimiento.Enabled = IIf(iEstado = 4, True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miVerEstados.Enabled = True
            miAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3, True, False)
            miEnviar.Enabled = IIf(iEstado = 1, True, False)
            miVencimiento.Enabled = IIf(iEstado = 4, True, False)

        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbRubro.ValueChanged, cmbEstados.ValueChanged, txtCodMer.TextChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmListaPrecio_Nuevo
                frm.state_button = False
                'frm.estado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                'frm.CodMer = CodMer
                'frm.CodRubro = cmbRubro.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdLista)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("Error al ingresar nuevo precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmListaPrecio_Nuevo
            frm.state_button = True
            frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Text
            frm.estado = dgvDatos.CurrentRow.Cells("IdEstado").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()

                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdLista)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdLista)
        Catch ex As Exception
            MsgBox("Error al mostrar el precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
        End If
    End Sub

    Private Sub Eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPrecioService.BorrarListaPrecio(dgvDatos.CurrentRow.Cells("IdLista").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            MsgBox("Error al eliminar el precio lista:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CStr(row.Cells("IdLista").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBuscar.Click
        BuscarMercaderia()
    End Sub

    Private Sub BuscarMercaderia()
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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
            MsgBox("Error [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdLista").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("Error [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub miInsertarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInsertarLista.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        'OpenFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub CreacionTable()
        Try
            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            dtCopia.Columns.Add(New DataColumn("CodEmp", Type.GetType("System.String")))
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

        Catch ex As Exception
            MsgBox("Error al insertar masivo los precio lista : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarMasivo()
        Try
            Dim estado_process As Boolean
            estado_process = oPrecioService.InsertarMasivoListaPrecio(dtInsertarMasivo)

            If estado_process = True Then
                MsgBox("Se inserto los precio lista correctamente.", MsgBoxStyle.Information)
                ListaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Error al insertar masivo los precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged, txtCodMer.TextChanged, cmbEstados.ValueChanged
        actualizar()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptListaPrecioN

            If dgvDatos.RowCount > 0 Then
                dtReporte = oPrecioService.MostrarListaPrecio(Session.sCodEmp, cmbRubro.Value, txtCodMer.Text, utils.toNumber(cmbEstados.Value)).Tables(0)
                'es ela impresion del listar

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    reporte.SetParameterValue("Rubro", IIf((cmbRubro.Text = "(Todos)"), "(Todos)", cmbRubro.Text))
                    reporte.SetParameterValue("CodMer", IIf((txtCodMer.Text = ""), "(Todos)", txtCodMer.Text))
                    reporte.SetParameterValue("Estado", IIf((cmbEstados.Text = "(Todos)"), "(Todos)", cmbEstados.Text))
                    forma.Text = "Reporte de precio lista"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox("Error al imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEnviar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar precio lista"
    End Sub

    Private Sub biAprobar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar precio lista"
    End Sub

    Private Sub biVencimiento_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVencimiento.MouseEnter, miVencimiento.MouseEnter
        sslError.Text = "Dar de baja precio lista"
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                         biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                         biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                         biEnviar.MouseLeave, biAprobar.MouseLeave, biVencimiento.MouseLeave, biVerEstados.MouseLeave, _
                         miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                         miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                         miEnviar.MouseLeave, miAprobar.MouseLeave, miVencimiento.MouseLeave, miVerEstados.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir precio lista"
    End Sub

    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear nuevo precio lista"
    End Sub

    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar precio lista"
    End Sub

    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar precio lista seleccionado"
    End Sub

    Private Sub biFormatoExcel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biFormatoExcel.MouseEnter, miFormatoExcel.MouseEnter
        sslError.Text = "Descargar formato excel"
    End Sub

    Private Sub biActualizar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar"
    End Sub

    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            Dim frm As New frmListaPrecio_CambiarEstado
            frm.IdEstado = "1"
            frm.DesEstado = dgvDatos.CurrentRow.Cells("DesEstado").Value
            frm.Text = "Enviar precio lista"
            'frm.cmbEstados.ReadOnly = True

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If

        Catch ex As Exception
            MsgBox("Error al enviar el precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            Dim frm As New frmListaPrecio_CambiarEstado
            frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Value
            frm.DesEstado = dgvDatos.CurrentRow.Cells("DesEstado").Value
            frm.Text = "Aprobar precio lista"
            'frm.cmbEstados.ReadOnly = True
            'frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If

        Catch ex As Exception
            MsgBox("Error al aprobar el precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmListaPrecio_Estados
                frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Text
                frm.Text = "Estados del precio lista : " & dgvDatos.CurrentRow.Cells("CodMer").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

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
                MsgBox("Registro vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar codigo seleccionado: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biVencimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVencimiento.Click, miVencimiento.Click
        Try
            Dim frm As New frmListaPrecio_CambiarEstado
            frm.IdEstado = 4
            'frm.cmbEstados.ReadOnly = True
            frm.DesEstado = dgvDatos.CurrentRow.Cells("DesEstado").Value
            frm.Text = "Dar de baja precio lista"
            'frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If

        Catch ex As Exception
            MsgBox("Error al dar de baja el precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class