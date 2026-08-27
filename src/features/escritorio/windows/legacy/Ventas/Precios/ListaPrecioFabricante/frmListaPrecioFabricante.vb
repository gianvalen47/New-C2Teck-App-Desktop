Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmListaPrecioFabricante

    Private oMaestroService As New MaestroService.MaestroClient
    Private oListaPrecioFabricanteCabService As New ListaPrecioFabricanteCabService.ListaPrecioFabricanteCabServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPrecioService As New PrecioService.PrecioServiceClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private IdCliente As Integer
    Private dtDatos As New DataTable
    Private dtListaPrecios As DataTable
    Private dtEstados As DataTable
    Private dtInsertarMasivo As DataTable
    Private DirFile As String
    Private fileExt As String
    Private iEstado As Integer

    Private Sub frmListaPrecioFabricante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioFabricanteCabService.Close()
            oPrecioService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oListaPrecioFabricanteCabService.Abort()
            oPrecioService.Close()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oListaPrecioFabricanteCabService.Abort()
            oPrecioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioFabricante_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioFabricante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        listaDatos()

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= LISTA PRECIO ===========================================
            dtListaPrecios = oPrecioService.MostrarListaPrecios.Tables(0)  'oMarcaService.MostrarMarcasListaPrecio.Tables(0)
            dtListaPrecios.Rows.InsertAt(getRowTodos(dtListaPrecios), 0)
            cmbListaPrecio.DataSource = dtListaPrecios
            cmbListaPrecio.DropDownList.DataMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.DropDownList.DisplayMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.DropDownList.ValueMember = dtListaPrecios.Columns("IdListaPre").ToString
            cmbListaPrecio.DropDownList.Columns(0).DataMember = dtListaPrecios.Columns("IdListaPre").ToString
            cmbListaPrecio.DropDownList.Columns(1).DataMember = dtListaPrecios.Columns("DesListaPre").ToString
            cmbListaPrecio.SelectedIndex = 0
            dtListaPrecios = Nothing

            ''======================================= ESTADOS ================================================
            'dtEstados = oPrecioService.MostrarEstadosListaPrecio.Tables(0)

            'dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            'cmbEstados.DataSource = dtEstados
            'cmbEstados.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstados.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            'cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            'cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstados.SelectedIndex = 0
            'dtRubros = Nothing


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
            dtDatos = oListaPrecioFabricanteCabService.Filtrar(Session.sCodEmp, cmbListaPrecio.Value).Tables(0)
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

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False

        Else
            'iEstado = dgvDatos.CurrentRow.Cells("IdEstado").Value
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True
            biVerEstados.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miVerEstados.Enabled = True

        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, cmbListaPrecio.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmListaPrecioFabricante_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdListaFab)
                    mostrar()
                    actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al Generar la lista precio fabricante : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmListaPrecioFabricante_Nuevo
            frm.state_button = True
            frm.IdListaFab = dgvDatos.CurrentRow.Cells("IdListaFab").Text
            'frm.estado = dgvDatos.CurrentRow.Cells("IdEstado").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()

                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdListaFab)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            listaDatos()
            RowPossesion(dgvDatos, frm.IdListaFab)
        Catch ex As Exception
            MsgBox("Error al mostrar el lista precio fabricante: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
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
                MsgBox("Registro vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar codigo seleccionado: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Lista de Precio Nº " + dgvDatos.CurrentRow.Cells("IdListaFab").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oListaPrecioFabricanteCabService.Borrar(dgvDatos.CurrentRow.Cells("IdListaFab").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó la lista correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el lista precio fabricante:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CStr(row.Cells("IdListaFab").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("Error [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdListaFab").Text
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

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave,
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, biVerEstados.MouseLeave,
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave,
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, miVerEstados.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Lista precio fabricante"
    End Sub
    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Lista precio fabricante"
    End Sub
    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Lista precio fabricante"
    End Sub
    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Lista precio fabricante"
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptListaPrecioFabricante

            If dgvDatos.RowCount > 0 Then
                dtReporte = oListaPrecioFabricanteCabService.Imprimir(dgvDatos.CurrentRow.Cells("IdListaFab").Text).Tables(0)

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

                    'reporte.SetParameterValue("Rubro", IIf((cmbRubro.Text = "(Todos)"), "(Todos)", cmbRubro.Text))
                    'reporte.SetParameterValue("CodMer", IIf((txtCodMer.Text = ""), "(Todos)", txtCodMer.Text))
                    'reporte.SetParameterValue("Estado", IIf((cmbEstados.Text = "(Todos)"), "(Todos)", cmbEstados.Text))
                    forma.Text = "Reporte de lista precio fabricante"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox("Error al imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub cmbListaPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbListaPrecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnBuscar.Select()
            btnBuscar_Click(sender, e)
        End If
    End Sub

End Class