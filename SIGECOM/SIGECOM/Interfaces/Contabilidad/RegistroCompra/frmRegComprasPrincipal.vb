Imports System.ServiceModel
Imports System.IO
Imports System.Xml

Public Class frmRegComprasPrincipal

    Private oRegistroCompraService As New RegistroCompraService.RegistroCompraServiceClient
    'Private oReciboHonorarioDet As New ReciboHonorarioDetService.ReciboHonorarioDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Private dtMeses As DataTable
    Private dtTipDoc As DataTable
    Private state_Search As Boolean
    'Private NumeroSug As String
    'Private IdHonorario As Integer

    Private IdProveedor As Integer

    Private Sub frmRegComprasPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRegistroCompraService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oRegistroCompraService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oRegistroCompraService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmRegComprasPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRegComprasPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()

        txtanio.Value = Today.Year
        cmbMes.Value = Today.Month

        'txtanio.Value = Today.Year
        'cmbMes.Value = Today.Month

        'txtPeriodo.Value = Today.Year
        'txtMesRegistro.Text = Format(Month(Today), "00")

        IdProveedor = 0
        txtProveedor.Text = "(Todos)"

        state_Search = True
        listaDatos()
        dgvDatos.Select()


    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oRegistroCompraService.MostrarTipoDocumento().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos1(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            fila(2) = ""
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
            fila(4) = 0
        End Try
        Return fila
    End Function


    Private Sub listaDatos()

        Try
            If state_Search = True Then
                'dtDatos = oReciboHonorario.Filtrar(Session.sCodEmp, txtanio.Value, cmbMes.Value, txtSerieDoc.Text, toNumber(txtNumDoc.Text), IdProveedor).Tables(0)
                dtDatos = oRegistroCompraService.Filtrar(Session.sCodEmp, txtanio.Value, IIf(cmbMes.Value = 0, "", Format(cmbMes.Value, "00")), txtNumRegistro.Text, cmbTipoDoc.Value, txtSerieDoc.Text, txtNumDoc.Text, IdProveedor).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                'DataGridView1.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, cmbMes.ValueChanged, txtSerieDoc.TextChanged, txtNumDoc.TextChanged, txtNumRegistro.TextChanged, cmbTipoDoc.ValueChanged
        listaDatos()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCompra").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmRegCompras
            'frm.txtSerieDoc.Text =
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            Dim frm As New frmRegCompras
            'frm.txtSerieDoc.Text =
            frm.state_button = True
            frm.IdCompra = dgvDatos.CurrentRow.Cells("IdCompra").Text
            frm.edicion = False
            'frm.TipFac = cmbTipFac.Value
            frm.editable = True

            'frm.ShowDialog()

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    ' limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdCompra)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar_Click(sender, e)

        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCompra").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
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
            ElseIf dgvDatos.CurrentRow.Cells("IdCompra").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el Registro de Compra Nº : " + dgvDatos.CurrentRow.Cells("Documento").Text + " - " + txtNumRegistro.Text + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oRegistroCompraService.Borrar(dgvDatos.CurrentRow.Cells("IdCompra").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    'Limpiar()
                    'ObtenerNumRegistro()
                    'state_button = False
                    'Desactivar()
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL REGISTRO DE COMPRAS :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click

    'End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub
End Class