Imports System.ServiceModel
Imports System.Net

Public Class frmOportunidadNegocio_Gastos

    '============================Servicios===================================
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public IdOportunidad As Integer
    Private dtDatos As New DataTable
    Private dtMonedas As DataTable

    Private Sub frmOportunidadNegocio_Gastos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOportunidadNegocioService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
        End Try
    End Sub

    Private Sub frmOportunidadNegocio_Gastos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_Gastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()

        ObtenerRegistro()
        desactivar()
        gbEtapa.Visible = True
        gbDetalle.Visible = True
        actualizarDetalles()
        Me.Text = "Oportunidad de Negocio Nº " + Chr(34) + txtIdOportunidad.Text.ToString + Chr(34) + " - Gastos"



    End Sub

    Private Sub llenarCombos()
        Try
            ''======================================= Vendedor ===========================================
            'dtVendedor = oPersonaService.MostrarVendedoresVigente.Tables(0)
            'dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            'cmbVendedor.DataSource = dtVendedor
            'cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.SelectedIndex = 0
            'dtVendedor = Nothing

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdOportunidadGasto").Text
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
            dtDatos = oOportunidadNegocioService.MostrarGastos(toNumber(IdOportunidad)).Tables(0)
            dgvDatos.DataSource = dtDatos
            ObtenerRegistro()
            'SumarMontosSol()
            'SumarMontosDol()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub SumarMontosSol()
    '    Try
    '        Dim MontoTotal As Double = 0
    '        Dim row As Janus.Windows.GridEX.GridEXRow
    '        Dim Monto As Boolean

    '        For i = 0 To Me.dgvDatos.RowCount - 1
    '            Me.dgvDatos.Row = i
    '            row = Me.dgvDatos.GetRow()
    '            Monto = row.Cells("MontoSol").Value
    '            If Monto Then
    '                MontoTotal = MontoTotal + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoSol").Value)
    '            End If
    '        Next

    '        txtTotalGastosSol.Value = MontoTotal

    '        txtUtilidadSol.Value = txtMonto.Value - txtTotalGastosSol.Value

    '    Catch ex As Exception
    '        MsgBox("ERROR AL SUMAR MONTOS SOL: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub SumarMontosDol()
    '    Try
    '        Dim MontoTotal As Double = 0
    '        Dim row As Janus.Windows.GridEX.GridEXRow
    '        Dim Monto As Boolean

    '        For i = 0 To Me.dgvDatos.RowCount - 1
    '            Me.dgvDatos.Row = i
    '            row = Me.dgvDatos.GetRow()
    '            Monto = row.Cells("MontoDol").Value
    '            If Monto Then
    '                MontoTotal = MontoTotal + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoDol").Value)
    '            End If
    '        Next

    '        txtTotalGastosDol.Value = MontoTotal

    '        txtUtilidadDol.Value = txtMonto.Value - txtTotalGastosDol.Value

    '    Catch ex As Exception
    '        MsgBox("ERROR AL SUMAR MONTOS DOL: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdOportunidadGasto").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub ObtenerRegistro()
        Try
            Dim registro As OportunidadNegocioService.OportunidadNegocio
            registro = oOportunidadNegocioService.Obtener(IdOportunidad)
            IdOportunidad = registro.IdOportunidad
            txtIdOportunidad.Text = IdOportunidad
            txtFecProbable.Value = registro.FecProbable
            lblEtapa.Text = registro.EtapasNegocio.DesEtapa
            txtNombre.Text = registro.Nombre
            txtCliente.Text = registro.Cliente.DesCli
            txtVendedor.Text = registro.Persona.ApeNom
            txtTipoProducto.Text = registro.TipoProducto
            txtFecCierre.Value = registro.FecCierre
            txtMonto.Value = registro.Monto
            txtDescripcion.Text = registro.Descripcion
            lblEtapa.Text = registro.EtapasNegocio.DesEtapa
            txtTotalMonto.Text = registro.Monto
            txtTotalGastos.Text = registro.Costo
            txtUtilidad.Text = registro.Utilidad
            cmbCodMon.Value = registro.Moneda.CodMon

            lblTotalVenta.Text = "Total Venta (" + cmbCodMon.Value + ") :"
            lbltotalGasto.Text = "Total Gastos (" + cmbCodMon.Value + ") :"
            lblUtilidad.Text = "Utilidad (" + cmbCodMon.Value + ") :"

            Me.Text = "Oportunidad de Negocio Nº " + registro.IdOportunidad.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        txtIdOportunidad.ReadOnly = True
        txtIdOportunidad.BackColor = System.Drawing.SystemColors.Control
        txtFecProbable.ReadOnly = True
        txtFecProbable.BackColor = System.Drawing.SystemColors.Control
        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtTipoProducto.ReadOnly = True
        txtTipoProducto.BackColor = System.Drawing.SystemColors.Control
        txtFecCierre.ReadOnly = True
        txtFecCierre.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        enableOpciones()
        dgvDatos.Select()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
        'miNuevo.Enabled = IIf(editable, True, False)
        'biEditar.Enabled = IIf(editable, Not edicion, False)
        'biSalir.Enabled = Not edicion
        'biGrabar.Enabled = edicion
        'biDeshacer.Enabled = edicion
        'cmOpciones.Enabled = IIf(lblEtapa.Text <> "", Not edicion, False)
    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        NuevoDetalle()
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmOportunidadNegocio_Gastos_Nuevo
                'Dim frm As New frmOportunidadNegocio_GastosMasivo
                'frm.state_button = False
                frm.IdOportunidad = IdOportunidad
                If dgvDatos.RowCount > 0 Then
                End If
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    'If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, frm.IdOportunidadGasto)
                    'End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR UN NUEVO GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrardetalle()
        End If
    End Sub

    Private Sub mostrardetalle()
        Try
            Dim frm As New frmOportunidadNegocio_Gastos_Mostrar

            frm.IdOportunidad = IdOportunidad
            frm.IdOportunidadGasto = dgvDatos.CurrentRow.Cells("IdOportunidadGasto").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminardetalle()
        End If
    End Sub

    Private Sub eliminardetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Gasto seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oOportunidadNegocioService.BorrarGastos(toNumber(dgvDatos.CurrentRow.Cells("IdOportunidadGasto").Text), toNumber(IdOportunidad), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL GASTO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub miNuevoMasivo_Click(sender As Object, e As EventArgs) Handles miNuevoMasivo.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                'Dim frm As New frmOportunidadNegocio_Gastos_Nuevo
                Dim frm As New frmOportunidadNegocio_GastosMasivo
                'frm.state_button = False
                frm.IdOportunidad = IdOportunidad
                If dgvDatos.RowCount > 0 Then
                End If
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    'If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, frm.IdOportunidadGasto)
                    'End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR GASTOS MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

End Class