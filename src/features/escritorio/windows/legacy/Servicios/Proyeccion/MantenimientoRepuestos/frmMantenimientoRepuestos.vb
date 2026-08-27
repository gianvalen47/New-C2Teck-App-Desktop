Imports System.Data.OleDb
Imports System.ServiceModel

Public Class frmMantenimientoRepuestos

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oMantenimientoRepuestosService As New MantenimientoRepuestosService.MantenimientoRepuestosServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtUbicacion As New DataTable
    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable

    Private dtTipoMantenimiento As DataTable
    Private dtModeloMer As DataTable
    Private IdCliente As Integer
    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer
    Private dtInsertarMasivo As DataTable

    Private Sub frmMantenimientoRepuestos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMantenimientoRepuestosService.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oMantenimientoRepuestosService.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
            oJobService.Abort()
        Catch ex As CommunicationException
            oMantenimientoRepuestosService.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
            oJobService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmMantenimientoRepuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMantenimientoRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 257)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        '  IdCliente = 7206
        'txtCliente.Text = "SOUTHERN PERU COPPER CORPORATION"
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
            '=================================== TIPO MANTENIMIENTO ===========================================
            dtTipoMantenimiento = oMantenimientoRepuestosService.MostrarTipoMantenimiento.Tables(0)
            'dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            ''=================================== MODELO MOTOR ============================================
            'dtModeloMer = oMantenimientoRepuestosService.MostrarModelos.Tables(0)
            ''dtModeloMer.Rows.InsertAt(getRowTodos1(dtModeloMer), 0)
            'cmbModeloMer.DataSource = dtModeloMer
            'cmbModeloMer.DropDownList.DataMember = dtModeloMer.Columns("Descripcion").ToString
            'cmbModeloMer.DropDownList.DisplayMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.ValueMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.Columns(0).DataMember = dtModeloMer.Columns("ModMer").ToString
            'cmbModeloMer.DropDownList.Columns(1).DataMember = dtModeloMer.Columns("Descripcion").ToString
            'cmbModeloMer.SelectedIndex = 0
            'dtModeloMer = Nothing

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing


        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
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
            dtDatos = oMantenimientoRepuestosService.Filtrar(cmbUbicacion.Value, cmbMantenimiento.Value, txtCodMer.Text, Session.sCodEmp).Tables(0)
            dgvDatos.DataSource = dtDatos
            'dgvDatos.SetDataBinding(dtDatos, 0)
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmBuscarCliente
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        txtCliente.Text = frm.descripcion
    '        txtCliente.BackColor = System.Drawing.SystemColors.Control
    '        IdCliente = frm.codigo
    '        llenarCombos()
    '        txtCliente.Select()
    '    End If
    'End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbUbicacion.ValueChanged, cmbMantenimiento.ValueChanged
        actualizarDetalles()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click

        Try
            Dim lLog As Boolean = True

            While lLog
                Dim frm As New frmMantenimientoRepuesto
                frm.txtItem.Value = dgvDatos.RowCount() + 1
                frm.DesMantenimiento = cmbMantenimiento.Text
                'frm.DesModeloMer = cmbModeloMer.Text
                frm.CodMantenimiento = cmbMantenimiento.Value
                frm.CodUbicacion = cmbUbicacion.Value
                'frm.ModMer = cmbModeloMer.Value
                'frm.IdCliente = IdCliente
                'frm.lblCliente.Text = txtCliente.Text
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodMer)
                Else
                    lLog = False
                End If

            End While

        Catch ex As Exception
            MsgBox("Error al crear nuevo registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodMer").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If cmbOpciones.Enabled = True Then
            If ValidaCodigoSeleccionado() Then
                Mostrar()
            End If
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

    Private Sub Mostrar()

        Try
            Dim frm As New frmMantenimientoRepuesto

            frm.DesMantenimiento = cmbMantenimiento.Text
            'frm.DesModeloMer = cmbModeloMer.Text
            frm.CodMantenimiento = cmbMantenimiento.Value
            frm.CodUbicacion = cmbUbicacion.Value
            'frm.ModMer = cmbModeloMer.Value
            'frm.IdCliente = IdCliente
            'frm.lblCliente.Text = txtCliente.Text
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.state_button = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodMer)
                Else
                    listaDatos()
                    'MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizarDetalles()
            enableOpciones()

        Catch ex As Exception
            MsgBox("Error al modificar el registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
        End If
    End Sub

    Private Sub Eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oMantenimientoRepuestosService.Borrar(cmbUbicacion.Value, cmbMantenimiento.Value, dgvDatos.CurrentRow.Cells("CodMer").Value, Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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

    Private Sub biDescargarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDescargarExcel.Click, miDescargarExcel.Click
        DescargarFormatoExcel()

    End Sub

    Private Sub DescargarFormatoExcel()
        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Int32")))


        dtExcel.Rows.Add(New Object() {"1", "codigo", "descripcion", "1"})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub biImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImportarExcel.Click, miImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
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
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            If dgvDatos.RowCount >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub InsertarMasivo()
        Try

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(1, i).Value) = False Then

                    Dim registro As New MantenimientoRepuestosService.MantenimientoRepuestos
                    Dim mercaderia As New MantenimientoRepuestosService.Producto
                    Dim empresa As New MantenimientoRepuestosService.Empresa
                    'Dim cliente As New MantenimientoRepuestosService.Cliente
                    Dim tipomantenimiento As New MantenimientoRepuestosService.TipoMantenimiento
                    Dim ubicacionEquipo As New MantenimientoRepuestosService.UbicacionEquipo

                    'modelo.ModMer = cmbModeloMer.Value
                    'registro.Modelo = modelo
                    'cliente.IdCliente = IdCliente
                    'registro.Cliente = cliente

                    ubicacionEquipo.CodUbicacion = cmbUbicacion.Value
                    registro.UbicacionEquipo = ubicacionEquipo
                    tipomantenimiento.CodMantenimiento = cmbMantenimiento.Value
                    registro.TipoMantenimiento = tipomantenimiento
                    mercaderia.CodMer = Trim(DataGridView1.Item(1, i).Value)
                    empresa.CodEmp = Session.sCodEmp
                    mercaderia.Empresa = empresa
                    'mercaderia.DesMer1 = Trim(IIf(IsDBNull(DataGridView1.Item(2, i).Value), "", DataGridView1.Item(2, i).Value))
                    registro.Descripcion = Trim(IIf(IsDBNull(DataGridView1.Item(2, i).Value), "", DataGridView1.Item(2, i).Value))
                    registro.Producto = mercaderia
                    registro.Item = CInt(DataGridView1.Item(0, i).Value)
                    registro.CanMer = CInt(DataGridView1.Item(3, i).Value)

                    Insertar(registro)

                    'row(0) = CInt(DataGridView1.Item(0, i).Value)
                    'row(1) = Trim(DataGridView1.Item(1, i).Value)
                    'row(2) = Trim(IIf(IsDBNull(DataGridView1.Item(2, i).Value), "", DataGridView1.Item(2, i).Value))
                    'row(3) = CInt(DataGridView1.Item(3, i).Value)
                    'dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As MantenimientoRepuestosService.MantenimientoRepuestos)
        Try
            Dim estado_process As Boolean
            estado_process = oMantenimientoRepuestosService.Insertar(registro)

            If estado_process = True Then

                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biEliminarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminarTodo.Click, miLimpiarTodo.Click

        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ELIMINAR la mercadería del mantenimiento seleccionado?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    For Each Fila As DataRow In dtDatos.Rows
                        estado_process = oMantenimientoRepuestosService.Borrar(cmbUbicacion.Value, cmbMantenimiento.Value, Fila.Item("CodMer").ToString, Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    Next

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

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click, cmbMantenimiento.ValueChanged, txtCodMer.TextChanged
        actualizarDetalles()
    End Sub

    Private Sub actualizarDetalles()
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
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Mostrar()
        End If
    End Sub

    Private Sub biImprimirListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimirListado.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptMantenimientoRepuestos

            dtReporte = oMantenimientoRepuestosService.Imprimir(cmbUbicacion.Value, toBlank(cmbMantenimiento.Value), Session.sCodEmp).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                'reporte.SetParameterValue("Cliente", txtCliente.Text)
                'reporte.SetParameterValue("pRucEmp", Session.sDesEmp)
                reporte.SetParameterValue("TipoMantenimiento", cmbMantenimiento.Text)
                reporte.SetParameterValue("Ubicacion", cmbUbicacion.Text)

                forma.Text = "Reporte de Listado de Mantenimiento Repuestos"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class