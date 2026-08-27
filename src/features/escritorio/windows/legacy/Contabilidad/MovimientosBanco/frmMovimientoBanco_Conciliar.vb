Imports System.ServiceModel

Public Class frmMovimientoBanco_Conciliar

    '===========================Servicios====================================================
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient

    Private dtDatos As DataTable
    Private dtDatosN As DataTable
    Private dtMeses As DataTable
    Private dtBancos As DataTable
    Private dtCuentas As DataTable

    Public IdMovimiento As Integer
    Public Periodo As Integer
    Public Mes As Integer
    Public CodBan As String
    Public NumCta As String

    Private Sub frmMovimientoBanco_Conciliar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMovimientoBancosService.Close()
            oMaestroService.Close()
            oPlanillaService.Close()
        Catch ex As TimeoutException
            oMovimientoBancosService.Abort()
            oMaestroService.Abort()
            oPlanillaService.Abort()
        Catch ex As CommunicationException
            oMovimientoBancosService.Abort()
            oMaestroService.Abort()
            oPlanillaService.Abort()
        End Try
    End Sub

    Private Sub frmMovimientoBanco_Conciliar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimientoBanco_Conciliar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        ObtenerRegistro()
        ListarDatos()
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses

            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            '======================================= BANCOS =================================================
            dtBancos = oMovimientoBancosService.MostrarBancos.Tables(0)
            'dtBancos.Rows.InsertAt(getRowTodos(dtBancos), 0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.SelectedIndex = 0
            dtBancos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerRegistro()

        txtAnio.Value = Periodo
        cmbMes.Value = Mes
        txtIdMovimiento.Text = IdMovimiento
        cmbBanco.Value = CodBan
        cmbNumCuenta.Value = NumCta

    End Sub

    Private Sub ListarDatos()

        'dtDatos = oMovimientoBancosService.MostrarConciliacion(txtAnio.Value, cmbMes.Value, cmbBanco.Value, cmbNumCuenta.Text).Tables(0)



        Try
            dtDatos = oMovimientoBancosService.MostrarConciliacion(txtAnio.Value, cmbMes.Value, cmbBanco.Value, cmbNumCuenta.Text).Tables(0)
            DataGridView1.DataSource = dtDatos

            LLenarGrillaFinal()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub LlenarGrillaFinal()

        Try
            Dim row As DataRow
            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("IdConciliacion", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("IdMovimientoDet", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("IdMovimiento", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Fecha", Type.GetType("System.String")))        'datetime
            dtCopia.Columns.Add(New DataColumn("FecPlanilla", Type.GetType("System.String")))       'datetime
            dtCopia.Columns.Add(New DataColumn("FecBanco", Type.GetType("System.String")))        'datetime
            dtCopia.Columns.Add(New DataColumn("Cheque", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodTipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("AbrTipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("TipMov", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Monto", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("MontoDebe", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("MontoHaber", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"1", "1", "1", "01/01/1990", "01/01/1990", "01/01/1990", "cheque", "desc", "codtip", "abrtipo", "tipmov", "0.00", "0.00", "0.00", "observacion"})

            dtDatosN = dtCopia.Copy
            dtDatosN.Clear()

            Dim Saldo As Double = 0

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If DataGridView1.Item(1, i).Value <> 0 Then

                    row = dtDatosN.NewRow

                    row(0) = CInt(DataGridView1.Item(0, i).Value)
                    row(1) = CInt(DataGridView1.Item(1, i).Value)
                    row(2) = CInt(DataGridView1.Item(2, i).Value)
                    row(3) = Format(CDate(DataGridView1.Item(3, i).Value), "dd/MM/yyyy")
                    row(4) = CDate(DataGridView1.Item(4, i).Value)
                    row(5) = CDate(DataGridView1.Item(5, i).Value)
                    row(6) = toBlank(DataGridView1.Item(6, i).Value)    'cheque
                    row(7) = DataGridView1.Item(7, i).Value             'descripcion
                    row(8) = DataGridView1.Item(8, i).Value             'CodTipo
                    row(9) = DataGridView1.Item(9, i).Value             'AbrTipo
                    row(10) = DataGridView1.Item(10, i).Value           'TipMov
                    row(11) = DataGridView1.Item(11, i).Value

                    If row(10) = "D" Then
                        row(12) = DataGridView1.Item(11, i).Value
                        row(13) = 0
                    ElseIf row(10) = "H" Then
                        row(12) = 0
                        row(13) = DataGridView1.Item(11, i).Value
                    End If

                    row(14) = DataGridView1.Item(12, i).Value

                    dtDatosN.Rows.Add(row)

                End If
            Next

            dgvDatos.DataSource = dtDatosN

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biConciliarDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConciliarDet.Click



    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        ListarDatos()
    End Sub

    Private Sub cmbBanco_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.ValueChanged
        Try

            dtCuentas = oPlanillaService.MostrarCuentas(cmbBanco.Value).Tables(0)

            cmbNumCuenta.DataSource = dtCuentas
            cmbNumCuenta.DropDownList.DataMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.DisplayMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.ValueMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.Columns(0).DataMember = dtCuentas.Columns("CodMon").ToString
            cmbNumCuenta.DropDownList.Columns(1).DataMember = dtCuentas.Columns("DesMon").ToString
            cmbNumCuenta.DropDownList.Columns(2).DataMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.SelectedIndex = 0
            dtCuentas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO CUENTA" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()


        Try
            Dim frm As New frmMovimientoBanco_Conciliar_Detalle
            frm.IdConciliacion = dgvDatos.CurrentRow.Cells("IdConciliacion").Text


            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizarDetalles()

            End If
        Catch ex As Exception
            MsgBox("Error al modificar el registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdConciliacion").Text
                End If
            End If
            dtDatos = Nothing
            ListarDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If CInt(row.Cells("IdConciliacion").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
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

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdConciliacion").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oMovimientoBancosService.BorrarConciliacion(toNumber(dgvDatos.CurrentRow.Cells("IdConciliacion").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListarDatos()

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

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click

        Try
            Dim lLog As Boolean = True

            While lLog

                Dim frm As New frmMovimientoBanco_ConciliarBuscador
                frm.IdMovimiento = IdMovimiento
                frm.Periodo = Periodo
                frm.Mes = Mes
                frm.CodBan = CodBan
                frm.NumCta = NumCta

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ListarDatos()
                Else
                    lLog = False
                End If

            End While

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

End Class