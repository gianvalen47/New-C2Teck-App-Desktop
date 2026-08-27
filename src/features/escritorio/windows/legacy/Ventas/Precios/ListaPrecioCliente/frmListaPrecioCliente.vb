Imports System.ServiceModel

Public Class frmListaPrecioCliente

    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient
    Private oListaPrecioClienteDetService As New ListaPrecioClienteDetService.ListaPrecioClienteDetServiceClient

    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private IdCliente As Integer
    Private dtDatos As New DataTable
    Private dtRubros As DataTable
    Private dtEstados As DataTable
    Private iEstado As Integer
    Private Mensaje As String = ""

    Private Sub frmListaPrecioCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
            oMaestroService.Close()
            oListaPrecioClienteDetService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
            oMaestroService.Abort()
            oListaPrecioClienteDetService.Abort()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
            oMaestroService.Abort()
            oListaPrecioClienteDetService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        IdCliente = 0
        txtBuscarCliente.Text = "(Todos)"
        state_Search = True
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

            '======================================= ESTADOS ================================================
            dtEstados = oListaPrecioClienteService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

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

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtBuscarCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtBuscarCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtBuscarCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            'pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oListaPrecioClienteService.Filtrar(IdCliente, utils.toBlank(cmbRubro.Value), txtNumContrato.Text, utils.toNumber(cmbEstado.Value)).Tables(0)
                'dtDatos = oListaPrecioClienteService.Filtrar(0, "", "", 0).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Erros al listar datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biAprobar.Enabled = False
            biDarBaja.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miAprobar.Enabled = False
            miDarBaja.Enabled = False
        Else
            iEstado = oListaPrecioClienteService.ObtenerEstado(dgvDatos.CurrentRow.Cells("IdLista").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biVerEstados.Enabled = True
            biAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3, True, False)
            biDarBaja.Enabled = IIf(iEstado = 4, True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miVerEstados.Enabled = True
            miAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3, True, False)
            miDarBaja.Enabled = IIf(iEstado = 4, True, False)

        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbRubro.ValueChanged, cmbEstado.ValueChanged, txtBuscarCliente.TextChanged, txtNumContrato.TextChanged
        listaDatos()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmListaPrecioCliente_Estados
                frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Value
                frm.Text = "Estados de la Lista de Precio Nº " & dgvDatos.CurrentRow.Cells("IdLista").Value
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
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar el codigo seleccionado: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub pboxLimpiarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxLimpiarCliente.Click
        txtBuscarCliente.Text = "(Todos)"
        IdCliente = 0
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

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmListaPrecioCliente_Nuevo
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("DesEstado").Text
            frm.state_button = True
            frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Text
            'frm.TipoLista = dgvDatos.CurrentRow.Cells("TipoLista").Text
            frm.editable = IIf(lEstado = "Generado", True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumContrato.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdLista)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("Error al mostrar la lista precio cliente: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtNumContrato.Text = nro_Orden
        End If
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Lista de Precio Nº " + dgvDatos.CurrentRow.Cells("IdLista").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oListaPrecioClienteService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdLista").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar la lista precio cliente:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmListaPrecioCliente_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdLista)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al Generar la lista precio cliente: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdLista").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdLista").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click

        Dim frm As New frmListaPrecioCliente_Imprimir

        frm.IdLista = dgvDatos.CurrentRow.Cells("IdLista").Text
        frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
        frm.DesTipoLista = dgvDatos.CurrentRow.Cells("DesTipoLista").Text
        frm.NumContrato = dgvDatos.CurrentRow.Cells("NumContrato").Text
        frm.Observacion = dgvDatos.CurrentRow.Cells("Observacion").Text
        frm.FecVigencia = dgvDatos.CurrentRow.Cells("FecVigencia").Text
        frm.FecVencimiento = dgvDatos.CurrentRow.Cells("FecVencimiento").Text
        frm.Vigente = dgvDatos.CurrentRow.Cells("Vigente").Value

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

        End If

        'Try
        '    Dim forma As New frmReportes
        '    Dim dtReporte As New DataTable
        '    Dim reporte As New rptListaPrecio

        '    If dgvDatos.RowCount > 0 Then
        '        dtReporte = oListaPrecioClienteService.Imprimir(dgvDatos.CurrentRow.Cells("IdLista").Text).Tables(0)

        '        If dtReporte.Rows.Count = 0 Then
        '            MsgBox("No hay datos a mostrar")
        '        Else
        '            reporte.SetDataSource(dtReporte)
        '            forma.crvReportes.ReportSource = reporte
        '            forma.crvReportes.DisplayGroupTree = False
        '            reporte.SetParameterValue("TipoLista", dgvDatos.CurrentRow.Cells("DesTipoLista").Text)
        '            reporte.SetParameterValue("NumContrato", txtNumContrato.Text)
        '            reporte.SetParameterValue("Observacion", dgvDatos.CurrentRow.Cells("Observacion").Text)
        '            reporte.SetParameterValue("FecVigencia", dgvDatos.CurrentRow.Cells("FecVigencia").Text)
        '            reporte.SetParameterValue("FecVencimiento", dgvDatos.CurrentRow.Cells("FecVencimiento").Text)
        '            reporte.SetParameterValue("Vigente", IIf(dgvDatos.CurrentRow.Cells("Vigente").Value = True, "1", "0"))
        '            forma.Text = "Reporte de Listado de Precio"
        '            forma.ShowDialog()
        '        End If
        '    Else
        '        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
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

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Lista de Precio."
    End Sub
    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Lista de Precio"
    End Sub
    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Lista de Precio."
    End Sub

    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Lista de Precio Seleccionada."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub

    Private Sub biAprobar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar la Lista de Precio."
    End Sub

    Private Sub biVerEstados_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados."
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If dgvDatos.CurrentRow.Cells("IdLista").Text <> "" Then

                VerificarCodigos()

                Dim frm As New frmListaPrecioCliente_Aprobar
                frm.IdLista = toNumber(dgvDatos.CurrentRow.Cells("IdLista").Text)
                frm.IdEstado = oListaPrecioClienteService.ObtenerEstado(toNumber(dgvDatos.CurrentRow.Cells("IdLista").Text))
                frm.MensajeCodigosPrecio = Mensaje
                'frm.GastoViaje = cbGastoViaje.Checked '----Agregado el 30/05/2012----
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al aprobar la lista precio cliente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerificarCodigos()

        dtDatos = oListaPrecioClienteDetService.Mostrar(dgvDatos.CurrentRow.Cells("IdLista").Text).Tables(0)
        dgvDetalle.DataSource = dtDatos

        Mensaje = ""

        For i As Integer = 0 To dgvDetalle.Rows.Count - 1

            If ((dgvDetalle.Item(9, i).Value < dgvDetalle.Item(14, i).Value) And (dgvDetalle.Item(9, i).Value <> 0)) Or ((dgvDetalle.Item(10, i).Value < dgvDetalle.Item(15, i).Value) And (dgvDetalle.Item(10, i).Value <> 0)) Then

                Mensaje = Mensaje + Trim(dgvDetalle.Item(6, i).Value) & ","

            End If

        Next


    End Sub
    Private Sub biDarBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDarBaja.Click, miDarBaja.Click

        Try
            If dgvDatos.CurrentRow.Cells("IdLista").Text <> "" Then
                Dim frm As New frmListaPrecioCliente_Darbaja
                frm.IdLista = toNumber(dgvDatos.CurrentRow.Cells("IdLista").Text)
                frm.IdCliente = toNumber(dgvDatos.CurrentRow.Cells("IdCliente").Text)
                'frm.GastoViaje = cbGastoViaje.Checked '----Agregado el 30/05/2012----
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al dar baja a la lista precio cliente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class