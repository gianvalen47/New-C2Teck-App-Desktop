Imports System.ServiceModel

Public Class frmMovimientoBanco_ConciliarBuscador

    '===========================Servicios====================================================
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient

    Private dtDatos As DataTable
    Private dtDatosN As DataTable
    Private dtDatosN2 As DataTable
    Private dtMeses As DataTable
    Private dtBancos As DataTable
    Private dtCuentas As DataTable

    Public IdMovimiento As Integer
    Public IdConciliacion As Integer

    Public Periodo As Integer
    Public Mes As Integer
    Public CodBan As String
    Public NumCta As String
    Private Cantidad As Integer

    Private Sub frmMovimientoBanco_ConciliarBuscador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmMovimientoBanco_ConciliarBuscador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimientoBanco_ConciliarBuscador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        Dim UltimoDiaMes As Date
        UltimoDiaMes = DateSerial(Periodo, Mes + 1, 0)
        txtFecha.Value = UltimoDiaMes
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

        'dtDatos = oMovimientoBancosService.MostrarConciliar(txtAnio.Value, cmbMes.Value, cmbBanco.Value, cmbNumCuenta.Text).Tables(0)
        'DataGridView2.DataSource = dtDatos

        Try
            dtDatos = oMovimientoBancosService.MostrarConciliar(txtAnio.Value, cmbMes.Value, cmbBanco.Value, cmbNumCuenta.Text).Tables(0)
            DataGridView1.DataSource = dtDatos
            datagridview3.DataSource = dtDatos

            LLenarGrillaFinal()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub LlenarGrillaFinal()

        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("cIdMovimiento", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("cIdMovimientoDet", Type.GetType("System.Int32")))

            dtCopia.Columns.Add(New DataColumn("cFecPlanilla", Type.GetType("System.String")))       'datetime
            dtCopia.Columns.Add(New DataColumn("cFecBanco", Type.GetType("System.String")))        'datetime
            dtCopia.Columns.Add(New DataColumn("cCheque", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("cDescripcion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("cAbrTipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("cTipMov", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("cMonto", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("cMontoDebe", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("cMontoHaber", Type.GetType("System.String")))
            'dtCopia.Columns.Add(New DataColumn("cMonto", Type.GetType("System.Double")))
            'dtCopia.Columns.Add(New DataColumn("cMontoDebe", Type.GetType("System.Double")))
            'dtCopia.Columns.Add(New DataColumn("cMontoHaber", Type.GetType("System.Double")))

            dtCopia.Rows.Add(New Object() {"1", "1", "01/01/1990", "01/01/1990", "cheque", "desc", "abrtipo", "tipo", "0.00", "0.00", "0.00"})

            dtDatosN = dtCopia.Copy
            dtDatosN.Clear()

            Dim Saldo As Double = 0

            '------

            Dim rows() As Janus.Windows.GridEX.GridEXRow
            Dim Cadena As String = ""
            rows = datagridview3.GetRows()
            Dim rowgrid As Janus.Windows.GridEX.GridEXRow

            If rows.Count <> 0 Then

                For Each rowgrid In rows

                    row = dtDatosN.NewRow

                    row(0) = CInt(rowgrid.Cells("IdMovimiento").Text)
                    row(1) = CInt(rowgrid.Cells("IdMovimientoDet").Text)
                    row(2) = CDate(rowgrid.Cells("FecPlanilla").Text)
                    row(3) = CDate(rowgrid.Cells("FecBanco").Text)
                    row(4) = toBlank(rowgrid.Cells("Cheque").Text)     'cheque
                    row(5) = rowgrid.Cells("Descripcion").Text     'descripcion
                    row(6) = rowgrid.Cells("AbrTipo").Text     'abrtipo
                    row(7) = rowgrid.Cells("TipMov").Text     'tipmov
                    row(8) = rowgrid.Cells("Monto").Text     'Monto


                    If row(7) = "D" Then
                        row(9) = rowgrid.Cells("Monto").Text
                        row(10) = 0

                    ElseIf row(7) = "H" Then
                        row(9) = 0
                        row(10) = rowgrid.Cells("Monto").Text

                    End If

                    dtDatosN.Rows.Add(row)

                Next
            End If

            'For i As Integer = 0 To DataGridView1.Rows.Count - 2

            '    If DataGridView1.Item(1, i).Value <> 0 Then

            '        row = dtDatosN.NewRow

            '        row(0) = CInt(DataGridView1.Item(0, i).Value)
            '        row(1) = CInt(DataGridView1.Item(1, i).Value)
            '        row(2) = CDate(DataGridView1.Item(2, i).Value)
            '        row(3) = CDate(DataGridView1.Item(3, i).Value)
            '        row(4) = toBlank(DataGridView1.Item(4, i).Value)     'cheque
            '        row(5) = DataGridView1.Item(5, i).Value     'descripcion
            '        row(6) = DataGridView1.Item(6, i).Value     'abrtipo
            '        row(7) = DataGridView1.Item(7, i).Value     'tipmov
            '        row(8) = DataGridView1.Item(8, i).Value     'Monto


            '        If row(7) = "D" Then
            '            row(9) = DataGridView1.Item(8, i).Value
            '            row(10) = "0"

            '        ElseIf row(7) = "H" Then
            '            row(9) = "0"
            '            row(10) = DataGridView1.Item(8, i).Value

            '        End If

            '        dtDatosN.Rows.Add(row)

            '    End If
            'Next

            dgvDatos.DataSource = dtDatosN

            cIdMovimiento.DataPropertyName = dtDatosN.Columns("cIdMovimiento").ColumnName
            cIdMovimientoDet.DataPropertyName = dtDatosN.Columns("cIdMovimientoDet").ColumnName
            cFecPlanilla.DataPropertyName = dtDatosN.Columns("cFecPlanilla").ColumnName
            cFecBanco.DataPropertyName = dtDatosN.Columns("cFecBanco").ColumnName
            cCheque.DataPropertyName = dtDatosN.Columns("cCheque").ColumnName
            cDescripcion.DataPropertyName = dtDatosN.Columns("cDescripcion").ColumnName
            cAbrTipo.DataPropertyName = dtDatosN.Columns("cAbrTipo").ColumnName
            cTipMov.DataPropertyName = dtDatosN.Columns("cTipMov").ColumnName
            cMonto.DataPropertyName = dtDatosN.Columns("cMonto").ColumnName
            cMontoDebe.DataPropertyName = dtDatosN.Columns("cMontoDebe").ColumnName
            cMontoHaber.DataPropertyName = dtDatosN.Columns("cMontoHaber").ColumnName


        Catch ex As Exception
            MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

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

    Private Sub biIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresar.Click

        Try
            If dgvDatos.RowCount > 0 Then

                dgvDatos.Update()
                txtObservacion.Focus()

                If MsgBox("¿Está seguro de INGRESAR estos montos a conciliar?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    'dgvDatos.Update()

                    'Dim row2 As DataRow

                    'Dim dtCopia As New DataTable("tabla")

                    'dtCopia.Columns.Add(New DataColumn("IdMovimientoDet", Type.GetType("System.Int32")))
                    'dtCopia.Columns.Add(New DataColumn("IdMovimiento", Type.GetType("System.Int32")))

                    'dtCopia.Rows.Add(New Object() {"1", "1"})

                    'dtDatosN2 = dtCopia.Copy
                    'dtDatosN2.Clear()

                    For i As Integer = 0 To dtDatosN.Rows.Count - 1

                        Dim row As DataGridViewRow = dgvDatos.Rows(i)
                        Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                        If toBoolean(cellSelecion.Value) = True Then

                            'row2 = dtDatosN2.NewRow

                            'row2(0) = CInt(DataGridView1.Item(0, i).Value)
                            'row2(1) = CInt(DataGridView1.Item(1, i).Value)

                            'dtDatosN2.Rows.Add(row2)

                            Dim registro As New MovimientoBancosService.ConciliacionBanco
                            Dim MovBanco As New MovimientoBancosService.MovimientoBancos
                            Dim MovBancodet As New MovimientoBancosService.MovimientoBancosDet

                            MovBanco.IdMovimiento = CInt(dgvDatos.Rows(i).Cells("cIdMovimiento").Value.ToString)

                            MovBancodet.MovimientoBancos = MovBanco
                            MovBancodet.IdMovimientoDet = CInt(dgvDatos.Rows(i).Cells("cIdMovimientoDet").Value.ToString)

                            registro.MovimientoBancosDet = MovBancodet
                            registro.IdConciliacion = 0

                            registro.Fecha = CDate(txtFecha.Value)
                            registro.Observacion = txtObservacion.Text
                            registro.CodUsu = Session.sCodUsu
                            registro.NomPc = Session.sNomPc
                            registro.DirIp = Session.sDirIp

                            Insertar(registro)


                        End If
                    Next

                    'DataGridView2.DataSource = dtDatosN2

                    'InsertarData()

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If
            Else
                MsgBox("Debe tener detalles", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR MOVIMIENTO BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    'Private Sub InsertarData()

    '    For i As Integer = 0 To dtDatosN2.Rows.Count - 1

    '        Dim registro As New MovimientoBancosService.ConciliacionBanco
    '        Dim MovBanco As New MovimientoBancosService.MovimientoBancos
    '        Dim MovBancodet As New MovimientoBancosService.MovimientoBancosDet

    '        MovBanco.IdMovimiento = CInt(DataGridView2.Item(0, i).Value)

    '        MovBancodet.MovimientoBancos = MovBanco
    '        MovBancodet.IdMovimientoDet = CInt(DataGridView2.Item(1, i).Value)

    '        registro.MovimientoBancosDet = MovBancodet
    '        registro.IdConciliacion = 0

    '        registro.Fecha = CDate(txtFecha.Value)
    '        registro.Observacion = txtObservacion.Text
    '        registro.CodUsu = Session.sCodUsu
    '        registro.NomPc = Session.sNomPc
    '        registro.DirIp = Session.sDirIp

    '        Insertar(registro)

    '    Next

    'End Sub

    Private Sub Insertar(ByVal registro As MovimientoBancosService.ConciliacionBanco)

        Try
            Dim estado_process As Integer
            estado_process = oMovimientoBancosService.InsertarConciliacion(registro)
            'type_process = "insert"

            If estado_process > 0 Then
                IdConciliacion = estado_process
                'MsgBox("Se insertó el Movimiento Banco Correctamente")
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CONCILIACION : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(11).Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(11).Value = False
        Next
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        ListarDatos()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ListarDatos()
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        ListarDatos()
    End Sub
End Class