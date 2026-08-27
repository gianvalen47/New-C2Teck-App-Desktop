Imports System.Data.OleDb
Imports System.ServiceModel

Public Class frmRepuestosServicios

    Private oModeloService As New ModelosProductoService.ModelosProductoServiceClient
    Private oTipoMotorService As New TipoMotorProductoService.TipoMotorProductoServiceClient
    Private oRepuestoServicioService As New RepuestoServicioService.RepuestoServicioServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtModelos As DataTable
    Private dtTiposMotores As DataTable
    Private dtCodServicio As DataTable
    Private DirFile As String
    Private fileExt As String
    Private dtInsertarMasivo As DataTable

    Private Sub frmRepuestosServicios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oModeloService.Close()
            oTipoMotorService.Close()
            oRepuestoServicioService.Close()
            oMercaderiaService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oModeloService.Abort()
            oTipoMotorService.Abort()
            oRepuestoServicioService.Abort()
            oMercaderiaService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oModeloService.Abort()
            oTipoMotorService.Abort()
            oRepuestoServicioService.Abort()
            oMercaderiaService.Abort()
            oSeguridadService.abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmRepuestosServicios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmRepuestosServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 104)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        listaDatos()
        enableOpciones()

    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biEliminar.Enabled = False
            biMostrar.Enabled = False
            biEliminarTodo.Enabled = False

            miEliminar.Enabled = False
            miMostrar.Enabled = False
        Else
            biEliminar.Enabled = True
            biMostrar.Enabled = True
            biEliminarTodo.Enabled = True

            miEliminar.Enabled = True
            miMostrar.Enabled = True

        End If
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MODELOS ================================================
            dtModelos = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            ' dtModelos.Rows.InsertAt(getRowTodos(dtModelos), 0)
            cmbModMer.DataSource = dtModelos
            cmbModMer.DropDownList.DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.DisplayMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.ValueMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(0).DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(1).DataMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.SelectedIndex = 0
            dtModelos = Nothing

            '======================================= TIPOS DE MOTORES =========================================
            dtTiposMotores = oTipoMotorService.Mostrar(Session.sCodEmp).Tables(0)
            'dtTiposMotores.Rows.InsertAt(getRowTodos(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            dtTiposMotores = Nothing

            '======================================= TIPOS DE SERVICIOS =========================================
            dtCodServicio = oRepuestoServicioService.MostrarTipoServicio(Session.sCodEmp).Tables(0)
            cmbCodServicio.DataSource = dtCodServicio
            cmbCodServicio.DataSource = dtCodServicio
            cmbCodServicio.DropDownList.DataMember = dtCodServicio.Columns("Nombre").ToString
            cmbCodServicio.DropDownList.DisplayMember = dtCodServicio.Columns("Nombre").ToString
            cmbCodServicio.DropDownList.ValueMember = dtCodServicio.Columns("CodServicio").ToString
            cmbCodServicio.DropDownList.Columns(0).DataMember = dtCodServicio.Columns("CodServicio").ToString
            cmbCodServicio.DropDownList.Columns(1).DataMember = dtCodServicio.Columns("Nombre").ToString
            cmbCodServicio.SelectedIndex = 0
            dtCodServicio = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oRepuestoServicioService.Mostrar(Session.sCodEmp, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCodServicio.ValueChanged, cmbModMer.ValueChanged, cmbTipMot.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmRepuestosServicio
                frm.txtItem.Value = dgvDatos.RowCount() + 1
                frm.CodServicio = cmbCodServicio.Value
                frm.DesCodServicio = cmbCodServicio.Text
                frm.TipMot = cmbTipMot.Value
                frm.DesTipMot = cmbTipMot.DropDownList.GetRow.Cells(1).Text 'cmbTipMot.Text
                frm.ModMer = cmbModMer.Value
                frm.DesModMer = cmbModMer.DropDownList.GetRow.Cells(1).Text 'cmbModMer.Text
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, dtDatos, "CodMer", frm.txtCodMer.Text)
                Else
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Esta seguro de ELIMINAR la mercaderia Nº" & dgvDatos.CurrentRow.Cells("CodMer").Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean

                    estado_process = oRepuestoServicioService.Borrar(Session.sCodEmp, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value, dgvDatos.CurrentRow.Cells("CodMer").Text)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            Dim frm As New frmRepuestosServicio
            frm.state_button = True
            frm.CodServicio = cmbCodServicio.Value
            frm.DesCodServicio = cmbCodServicio.Text
            frm.TipMot = cmbTipMot.Value
            frm.DesTipMot = cmbTipMot.DropDownList.GetRow.Cells(1).Text 'cmbTipMot.Text
            frm.ModMer = cmbModMer.Value
            frm.DesModMer = cmbModMer.DropDownList.GetRow.Cells(1).Text 'cmbModMer.Text
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodMer").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "CodMer", codigo)
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If dgvDatos.RowCount < 1 Then
            MsgBox("No existen Datos , Verifique...", MsgBoxStyle.Information)
        Else
            biMostrar_Click(sender, e)
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount < 1 Then
                MsgBox("No existen Datos , Verifique...", MsgBoxStyle.Information)
            Else
                biMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub biEliminarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminarTodo.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ELIMINAR todas las mercaderías del Servicio seleccionado?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    For Each Fila As DataRow In dtDatos.Rows
                        estado_process = oRepuestoServicioService.Borrar(Session.sCodEmp, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value, Fila.Item("CodMer").ToString)
                    Next
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó correctamente TODOS los registros...!!!", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub FormatoExcel()
        'Dim row As DataRow

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Código Mer.", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"1", "", "", ""})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miInsertarListadoDeRepuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInsertarListadoDeRepuestos.Click
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
            'CreacionTable()
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

    Private Sub Insertar(ByVal registro As RepuestoServicioService.RepuestoServicio)
        Try
            Dim estado_process As Boolean
            estado_process = oRepuestoServicioService.Insertar(registro)

            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarMasivo()
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(1, i).Value) = False Then
                    If IsDBNull(DataGridView1.Item(1, i).Value) = True Then
                        MsgBox("Debe ingresar el código de la mercaderia")
                    ElseIf IsDBNull(DataGridView1.Item(2, i).Value) = True Then
                        MsgBox("Debe ingresar la descripción de la mercaderia")
                        'ElseIf oMercaderiaService.Buscar(DataGridView1.Item(1, i).Value) = False Then
                        '    MsgBox("Esta Mercaderia no existe... Verifique")
                    ElseIf oRepuestoServicioService.Buscar(Session.sCodEmp, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value, DataGridView1.Item(1, i).Value) Then
                        MsgBox("No se puede guardar porque el código " & DataGridView1.Item(1, i).Value & " ya existe para estas opciones")
                    Else

                        Dim registro As New RepuestoServicioService.RepuestoServicio
                        Dim modelo As New RepuestoServicioService.Modelo
                        Dim tipomotor As New RepuestoServicioService.TipoMotor
                        Dim empresa As New RepuestoServicioService.Empresa

                        empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = empresa
                        registro.CodServicio = cmbCodServicio.Value
                        modelo.ModMer = cmbModMer.Value
                        registro.Modelo = modelo
                        tipomotor.TipMot = cmbTipMot.Value
                        registro.TipoMotor = tipomotor
                        registro.CodMer = DataGridView1.Item(1, i).Value
                        registro.DesMer = DataGridView1.Item(2, i).Value
                        registro.Item = DataGridView1.Item(0, i).Value
                        registro.CanMer = IIf(IsDBNull(DataGridView1.Item(3, i).Value) = True, 0, DataGridView1.Item(3, i).Value)

                        Insertar(registro)
                    End If
                End If

            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Insertar Masivamente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biFormatoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFormatoExcel.Click, miFormatoExcel.Click
        FormatoExcel()
    End Sub
End Class