Imports System.ServiceModel
Public Class frmImportacion_GastosImportacion

    '===========================Servicios====================================================
    Private oEmbarqueService As New ImportacionService.ImportacionServiceClient
    'Private oEmbarqueDetService As New EmbarqueDetService.EmbarqueDetServiceClient

    Public idImportacion As String
    'Public dtGastos As DataTable
    'Public dtMedios As DataTable
    Private dtDatos As DataTable

    Public IdProveedor As Integer

    Private Sub frmEmbarque_GastosImportacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEmbarqueService.Close()
            '       oEmbarqueDetService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
            '      oEmbarqueDetService.Abort()
        Catch ex As CommunicationException
            oEmbarqueService.Abort()
            '     oEmbarqueDetService.Abort()
        End Try
    End Sub

    Private Sub frmEmbarque_GastosImportacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEmbarque_GastosImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        ObtenerRegistro()
        desactivar()

        gbDetalles.Visible = True
        actualizarDetalles()
        'Me.Text = "Datos de Embarque"
        'dgvDatos.Select()

    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= MEDIOS ================================================
            'dtMedios = New DataTable
            'dtMedios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            'dtMedios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtMedios.Rows.Add(New Object() {"A", "Aéreo"}) ', New DateTime(2008, 2, 5)
            'dtMedios.Rows.Add(New Object() {"M", "Marinos"})
            'dtMedios.Rows.Add(New Object() {"O", "Otros"})

            'cmbMedio.DataSource = dtMedios
            'cmbMedio.DropDownList.DataMember = dtMedios.Columns("nombre").ToString
            'cmbMedio.DropDownList.DisplayMember = dtMedios.Columns("nombre").ToString
            'cmbMedio.DropDownList.ValueMember = dtMedios.Columns("codigo").ToString
            'cmbMedio.DropDownList.Columns(0).DataMember = dtMedios.Columns("codigo").ToString
            'cmbMedio.DropDownList.Columns(1).DataMember = dtMedios.Columns("nombre").ToString
            'cmbMedio.SelectedIndex = 0
            'dtMedios = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = False 'True
        End If
        miNuevo.Enabled = False 'True

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ImportacionService.Importacion
            registro = oEmbarqueService.MostrarPorId(idImportacion)

            'CodEmbarque = registro.CodEmbarque
            txtnumero.Text = registro.NumDoc
            txtFecha.Value = registro.FecDoc
            'lblEstadoMesa.Text = registro.Estado
            'cmbMedio.Value = registro.Medio
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            txtNroIng.Text = registro.NroIng
            'txtTotalNeto.Value = registro.TotalNeto
            'txtObservacion.Text = registro.Observacion
            'txtInvoiceGE.Text = toNull(registro.InvoiceGasto)
            'txtTotalGE.Value = registro.TotalGasto
            'txtFecLlenadoCont.Value = registro.FecLlenado
            'If Not (registro.FecLlenado.ToString = "") Then
            '    txtFecLlenadoCont.Value = CDate(registro.FecLlenado)
            '    txtFecLlenadoCont.Text = registro.FecLlenado.ToString
            'End If
            'If Not (registro.FecLlegada.ToString = "") Then
            '    txtFecLlegada.Value = CDate(registro.FecLlegada)
            '    txtFecLlegada.Text = registro.FecLlegada.ToString
            'End If

            'Me.Text = "Datos de Embarque"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub desactivar()
        txtnumero.ReadOnly = True
        txtnumero.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        'cmbMedio.ReadOnly = True
        'cmbMedio.BackColor = System.Drawing.SystemColors.Control
        txtProveedor.ReadOnly = True
        txtProveedor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = False
        'txtFecLlegada.ReadOnly = True
        'txtFecLlegada.BackColor = System.Drawing.SystemColors.Control
        txtNroIng.ReadOnly = True
        txtNroIng.BackColor = System.Drawing.SystemColors.Control
        'txtTotalNeto.ReadOnly = True
        'txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
        'txtObservacion.ReadOnly = True
        'txtObservacion.BackColor = System.Drawing.SystemColors.Control
        'txtInvoiceGE.ReadOnly = True
        'txtInvoiceGE.BackColor = System.Drawing.SystemColors.Control
        'txtTotalGE.ReadOnly = True
        'txtTotalGE.BackColor = System.Drawing.SystemColors.Control
        'txtFecLlenadoCont.ReadOnly = True
        'txtFecLlenadoCont.BackColor = System.Drawing.SystemColors.Control

        'edicion = False
        enableOpciones()
        txtnumero.Focus()
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodEmbarque").Text
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

    Private Sub listaDatos()
        Try
            dtDatos = oEmbarqueService.MostrarGastos(idImportacion).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
            SumarMontos()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SumarMontos()
        Try
            Dim MontoTotalDol As Double = 0
            Dim MontoTotalSol As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim Monto As Boolean
            Dim CodMon As String

            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                CodMon = row.Cells("CodMon").Value
                Monto = row.Cells("Monto").Value

                If CodMon = "US" Then
                    MontoTotalDol = MontoTotalDol + CDbl(Me.dgvDatos.CurrentRow.Cells("Monto").Value)
                ElseIf CodMon = "NS" Then
                    MontoTotalSol = MontoTotalSol + CDbl(Me.dgvDatos.CurrentRow.Cells("Monto").Value)
                End If

            Next

            txtTotalMontoDol.Value = MontoTotalDol
            txtTotalMontoSol.Value = MontoTotalSol

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR MONTOS SOL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("IdImportacion").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        'NuevoDetalle()
    End Sub

    'Private Sub NuevoDetalle()
    '    Try
    '        Dim lLog As Boolean = True
    '        While lLog
    '            Dim frm As New frmEmbarque_GastosImportacion_Nuevo
    '            frm.state_button = False
    '            frm.CodEmbarque = idImportacion
    '            'frm.IdProveedor = IdProveedor
    '            'frm.CodMon = cmbMoneda.Value
    '            'frm.CodArea = cmbArea.Value
    '            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                dtDatos = Nothing
    '                listaDatos()
    '                If frm.type_process = "insert" Then
    '                    RowPossesion(dgvDatos, frm.CodEmbarque)
    '                End If
    '            Else
    '                lLog = False
    '            End If
    '        End While
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INGRESAR NUEVO GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmEmbarque_GastosImportacion_Nuevo
            frm.state_button = True
            frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Text
            frm.IdTipo = dgvDatos.CurrentRow.Cells("IdTipo").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.CodEmbarque)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            listaDatos()
            RowPossesion(dgvDatos, frm.CodEmbarque)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
    '    If ValidaCodigoSeleccionado() Then
    '        eliminarDetalle()
    '    End If
    'End Sub

    'Private Sub eliminarDetalle()
    '    Try
    '        cmOpciones.Visible = False
    '        If MsgBox("¿Está seguro de ELIMINAR el Gasto?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
    '            Dim estado_process As Boolean
    '            estado_process = oEmbarqueService.BorrarGasto(dgvDatos.CurrentRow.Cells("CodEmbarque").Text, dgvDatos.CurrentRow.Cells("IdTipo").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '            If estado_process = True Then
    '                dtDatos = Nothing
    '                listaDatos()
    '                MsgBox("Se eliminó el Gasto correctamente.", MsgBoxStyle.Information)
    '            Else
    '                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
    '            End If
    '        Else
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class