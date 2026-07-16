Imports System.ServiceModel

Public Class frmMovimientoBanco

    '===========================Servicios====================================================
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient

    '======================Declaración de Variables==============================  
    Public IdMovimiento As Integer
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    Public Anio As Integer
    Public Mes As Integer
    Public CodBan As String
    Public NumCta As String


    Private dtDatos As DataTable
    Private dtMeses As DataTable
    Private dtBancos As DataTable
    Private dtCuentas As DataTable
    Private dtDatosN As DataTable

    Public iEstado As Integer

    Private Sub frmMovimientoBanco_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmMovimientoBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimientoBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            ListaDatos()
            desactivar()
            gbDetalle.Visible = True
            Me.Size = New System.Drawing.Size(751, 560)
            Me.Text = "MOVIMIENTO BANCO Nº " + Chr(34) + txtIdMovimiento.Text.ToString + Chr(34)
            dgvDatos.Select()
        Else                    'Nuevo
            'Agregado para el mejor uso de villalobos
            If CodBan <> "" And NumCta <> "" Then
                txtAnio.Value = Anio
                cmbMes.Value = Mes
                cmbBanco.Value = CodBan
                cmbNumCuenta.Value = NumCta
            Else
                txtAnio.Value = Today.Year
                cmbMes.Value = Today.Month
            End If
            gbDetalle.Visible = False
            Me.Size = New System.Drawing.Size(751, 237)
            Me.Text = "Registrar nuevo Movimiento de Banco"
            activar()
            cmbBanco.Select()
        End If

    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            'dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
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

        Try
            Dim registro As MovimientoBancosService.MovimientoBancos
            registro = oMovimientoBancosService.Obtener(IdMovimiento)

            IdMovimiento = registro.IdMovimiento
            txtIdMovimiento.Text = registro.IdMovimiento
            txtAnio.Value = registro.Periodo
            cmbMes.Value = registro.Mes
            cmbBanco.Value = registro.CuentaBancos.Banco.CodBan
            cmbNumCuenta.Value = registro.CuentaBancos.NumCta
            txtSaldoBanco.Text = registro.SaldoBanco
            txtSaldoInicial.Text = registro.SaldoInicial
            txtSaldoFinal.Text = registro.SaldoFinal
            txtTotalDebe.Text = registro.TotalDebe
            txtTotalHaber.Text = registro.TotalHaber
            txtObservacion.Text = registro.Observacion

            Me.Text = "Movimiento Banco Nº " + registro.IdMovimiento.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub desactivar()

        txtAnio.ReadOnly = True
        txtAnio.BackColor = System.Drawing.SystemColors.Control
        cmbMes.ReadOnly = True
        cmbMes.BackColor = System.Drawing.SystemColors.Control

        txtIdMovimiento.ReadOnly = True
        txtIdMovimiento.BackColor = System.Drawing.SystemColors.Control
        cmbBanco.ReadOnly = True
        cmbBanco.BackColor = System.Drawing.SystemColors.Control
        cmbNumCuenta.ReadOnly = True
        cmbNumCuenta.BackColor = System.Drawing.SystemColors.Control
        txtSaldoBanco.ReadOnly = True
        txtSaldoBanco.BackColor = System.Drawing.SystemColors.Control
        txtSaldoInicial.ReadOnly = True
        txtSaldoInicial.BackColor = System.Drawing.SystemColors.Control
        txtSaldoFinal.ReadOnly = True
        txtSaldoFinal.BackColor = System.Drawing.SystemColors.Control
        txtTotalDebe.ReadOnly = True
        txtTotalDebe.BackColor = System.Drawing.SystemColors.Control
        txtTotalHaber.ReadOnly = True
        txtTotalHaber.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            txtAnio.ReadOnly = True
            txtAnio.BackColor = System.Drawing.SystemColors.Control
            cmbMes.ReadOnly = True
            cmbMes.BackColor = System.Drawing.SystemColors.Control

            txtIdMovimiento.ReadOnly = True
            txtIdMovimiento.BackColor = System.Drawing.SystemColors.Control
            cmbBanco.ReadOnly = True
            cmbBanco.BackColor = System.Drawing.SystemColors.Control
            cmbNumCuenta.ReadOnly = True
            cmbNumCuenta.BackColor = System.Drawing.SystemColors.Control
            txtSaldoBanco.ReadOnly = False
            txtSaldoBanco.BackColor = System.Drawing.SystemColors.Window
            txtSaldoInicial.ReadOnly = True
            txtSaldoInicial.BackColor = System.Drawing.SystemColors.Control
            txtSaldoFinal.ReadOnly = True
            txtSaldoFinal.BackColor = System.Drawing.SystemColors.Control
            txtTotalDebe.ReadOnly = 7
            txtTotalDebe.BackColor = System.Drawing.SystemColors.Control
            txtTotalHaber.ReadOnly = True
            txtTotalHaber.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()

        Else
            txtAnio.ReadOnly = False
            txtAnio.BackColor = System.Drawing.SystemColors.Window
            cmbMes.ReadOnly = False
            cmbMes.BackColor = System.Drawing.SystemColors.Window

            txtIdMovimiento.ReadOnly = True
            txtIdMovimiento.BackColor = System.Drawing.SystemColors.Window
            cmbBanco.ReadOnly = False
            cmbBanco.BackColor = System.Drawing.SystemColors.Window
            cmbNumCuenta.ReadOnly = False
            cmbNumCuenta.BackColor = System.Drawing.SystemColors.Window
            txtSaldoBanco.ReadOnly = False
            txtSaldoBanco.BackColor = System.Drawing.SystemColors.Window
            txtSaldoInicial.ReadOnly = True
            txtSaldoInicial.BackColor = System.Drawing.SystemColors.Control
            txtSaldoFinal.ReadOnly = True
            txtSaldoFinal.BackColor = System.Drawing.SystemColors.Control
            txtTotalDebe.ReadOnly = True
            txtTotalDebe.BackColor = System.Drawing.SystemColors.Control
            txtTotalHaber.ReadOnly = True
            txtTotalHaber.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()

        End If
    End Sub


    Private Sub enableOpciones()

        Try
            If dgvDatos.RowCount < 1 Then
                miMostrar.Enabled = False
                miEliminar.Enabled = False
            Else
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(editable, True, False)
            End If
            miNuevo.Enabled = IIf(editable, True, False)
            biEditarr.Enabled = IIf(editable, Not edicion, False)
            biGuardar.Enabled = edicion
            biDeshacerr.Enabled = edicion
            cmOpciones.Enabled = IIf(Not edicion, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message)
        End Try

    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New MovimientoBancosService.MovimientoBancos
                Dim Cuentabancos As New MovimientoBancosService.CuentaBancos
                Dim Empresa As New MovimientoBancosService.Empresa
                Dim Banco As New MovimientoBancosService.Banco

                registro.IdMovimiento = IdMovimiento
                registro.Periodo = toNumber(txtAnio.Value)
                registro.Mes = toNumber(cmbMes.Value)
                Banco.CodBan = toBlank(cmbBanco.Value)

                'Cuentabancos.Banco = "01"

                Cuentabancos.Banco = Banco
                ' Cuentabancos.Banco.CodBan = toBlank(cmbBanco.Value)
                Cuentabancos.NumCta = toBlank(cmbNumCuenta.Value)
                registro.CuentaBancos = Cuentabancos
                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa

                'registro.FecReg = Today.Date
                registro.Observacion = toBlank(txtObservacion.Text)

                registro.SaldoBanco = txtSaldoBanco.Value
                registro.SaldoFinal = 0.0
                registro.SaldoInicial = 0.0
                registro.TotalDebe = 0.0
                registro.TotalHaber = 0.0

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR MOVIMIENTO BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toDouble(txtSaldoBanco.Value) <= 0 Then
            '    MsgBox("El Saldo Banco debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
            '    txtSaldoBanco.Focus()
            '    Return False
            'Else
            Return True
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As MovimientoBancosService.MovimientoBancos)
        Try
            Dim estado_process As Integer
            estado_process = oMovimientoBancosService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMovimiento = estado_process
                'iUbicacion = toNumber(cmbUbicacion.Value)
                'iViatico = cbViatico.Checked
                MsgBox("Se insertó el Movimiento Banco Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MOVIMIENTO BANCO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As MovimientoBancosService.MovimientoBancos)
        Try
            Dim estado_process As Boolean
            estado_process = oMovimientoBancosService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Movimiento Banco Correctamente")
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR MOVIMIENTO BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biEditarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oMovimientoBancosService.MostrarDetalle(IdMovimiento).Tables(0)
            DataGridView1.DataSource = dtDatos

            LLenarGrillaFinal()
            'dgvDatos.DataSource = dtDatos


        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LlenarGrillaFinal()

        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")
            'dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
            'dtCopia.Columns.Add(New DataColumn("IdLista", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("IdMovimientoDet", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("IdMovimiento", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("FecPlanilla", Type.GetType("System.String")))       'datetime
            dtCopia.Columns.Add(New DataColumn("FecBanco", Type.GetType("System.String")))        'datetime
            dtCopia.Columns.Add(New DataColumn("Cheque", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodTipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("TipMov", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("AbrTipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Monto", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("MontoDebe", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("MontoHaber", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Saldo", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Conciliar", Type.GetType("System.Boolean")))
            dtCopia.Columns.Add(New DataColumn("FecPlanilla2", Type.GetType("System.String")))


            dtCopia.Rows.Add(New Object() {"1", "1", "01/01/1990", "01/01/1990", "cheque", "desc", "cod", "tip", "abrtipo", "0.00", "0.00", "0.00", "0.00", "True", "01/01/1990"})

            dtDatosN = dtCopia.Copy
            dtDatosN.Clear()

            Dim Saldo As Double = 0

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If DataGridView1.Item(1, i).Value <> 0 Then

                    row = dtDatosN.NewRow


                    row(0) = CInt(DataGridView1.Item(0, i).Value)
                    row(1) = CInt(DataGridView1.Item(1, i).Value)
                    row(2) = Microsoft.VisualBasic.DateAndTime.Day(CDate(DataGridView1.Item(2, i).Value))
                    row(3) = CDate(DataGridView1.Item(3, i).Value)
                    row(4) = toBlank(DataGridView1.Item(4, i).Value)     'cheque
                    row(5) = DataGridView1.Item(5, i).Value     'abrtipo
                    row(6) = DataGridView1.Item(6, i).Value
                    row(7) = DataGridView1.Item(7, i).Value
                    row(8) = DataGridView1.Item(8, i).Value
                    row(9) = DataGridView1.Item(9, i).Value     'Monto
                    If i > 0 Then
                        If row(7) = "D" Then
                            row(10) = DataGridView1.Item(9, i).Value
                            row(11) = 0
                            'row(11) = DataGridView1.Item(8, i - 1).Value - DataGridView1.Item(8, i).Value
                            row(12) = Saldo + DataGridView1.Item(9, i).Value
                            Saldo = Saldo + DataGridView1.Item(9, i).Value
                        ElseIf row(7) = "H" Then
                            row(10) = 0
                            row(11) = DataGridView1.Item(9, i).Value
                            'row(11) = DataGridView1.Item(8, i - 1).Value + DataGridView1.Item(8, i).Value
                            row(12) = Saldo - DataGridView1.Item(9, i).Value
                            Saldo = Saldo - DataGridView1.Item(9, i).Value
                        End If
                    Else
                        If row(7) = "D" Then
                            row(10) = DataGridView1.Item(9, i).Value
                            row(11) = 0
                            row(12) = txtSaldoInicial.Text + DataGridView1.Item(9, i).Value
                            Saldo = Saldo + (txtSaldoInicial.Text + DataGridView1.Item(9, i).Value)
                        ElseIf row(7) = "H" Then
                            row(10) = 0
                            row(11) = DataGridView1.Item(9, i).Value
                            row(12) = txtSaldoInicial.Text - DataGridView1.Item(9, i).Value
                            Saldo = Saldo + (txtSaldoInicial.Text - DataGridView1.Item(9, i).Value)
                        End If
                    End If
                    row(13) = DataGridView1.Item(10, i).Value
                    row(14) = CDate(DataGridView1.Item(11, i).Value)

                    dtDatosN.Rows.Add(row)

                End If
            Next

            dgvDatos.DataSource = dtDatosN

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        'If state_button = True Then
        Nuevo()
        'End If
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True

            While lLog
                Dim frm As New frmMovimientoBanco_Detalle
                frm.IdMovimiento = IdMovimiento
                'frm.CodArea = CodArea
                'frm.CodCentro = iCentroCosto
                'frm.CodJob = txtCodJob.Text
                frm.Mes = cmbMes.Value
                frm.Anio = txtAnio.Value
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ListaDatos()
                    RowPossesion(dgvDatos, frm.IdMovimientoDet)
                    ObtenerRegistro()
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
            If CInt(row.Cells("IdMovimientoDet").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = True Then
            If ValidaCodigoSeleccionado() Then
                Mostrar()
            End If
        End If
    End Sub

    Private Sub Mostrar()

        Try
            Dim frm As New frmMovimientoBanco_Detalle
            frm.IdMovimiento = dgvDatos.CurrentRow.Cells("IdMovimiento").Text
            frm.IdMovimientoDet = dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text
            frm.state_button = True
            'frm.editable = True
            'frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    ListaDatos()
                    RowPossesion(dgvDatos, frm.IdMovimientoDet)
                    ObtenerRegistro()
                Else
                    ListaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
                ObtenerRegistro()
            End If
            actualizarDetalles()
            enableOpciones()


        Catch ex As Exception
            MsgBox("Error al modificar el registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text
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
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdMovimientoDet").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oMovimientoBancosService.BorrarDetalle(toNumber(dgvDatos.CurrentRow.Cells("IdMovimientoDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdMovimiento").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListaDatos()
                    ObtenerRegistro()
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

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub


    Private Sub Modificar(ByVal registro As MovimientoBancosService.MovimientoBancosDet)
        Try
            Dim estado_process As Boolean
            estado_process = oMovimientoBancosService.ActualizarDetalle(registro)

            If estado_process = True Then
                actualizarDetalles()

            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
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


    'Private Sub cmbNumCuenta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNumCuenta.ValueChanged
    '    ObtenerMoneda()
    'End Sub

    'Private Sub ObtenerMoneda()
    '    'If cmbNumCuenta.SelectedIndex <> 0 Then
    '    txtMoneda.Text = cmbNumCuenta.DropDownList.CurrentRow.Cells(0).Value
    '    'End If
    'End Sub

    Private Sub miConciliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miConciliar.Click

        Try
            Dim Check As String = ""

            Check = dgvDatos.CurrentRow.Cells("Conciliar").Value


            Dim estado_process As Boolean

            Dim registro As New MovimientoBancosService.MovimientoBancosDet
            Dim MovimientoBancos As New MovimientoBancosService.MovimientoBancos
            Dim TipoMovBanco As New MovimientoBancosService.TipoMovBanco

            MovimientoBancos.IdMovimiento = IdMovimiento
            registro.MovimientoBancos = MovimientoBancos
            registro.IdMovimientoDet = dgvDatos.CurrentRow.Cells("IdMovimientoDet").Value
            registro.FecBanco = CDate(dgvDatos.CurrentRow.Cells("FecBanco").Value)
            registro.FecPlanilla = CDate(dgvDatos.CurrentRow.Cells("FecPlanilla2").Value)

            registro.Cheque = dgvDatos.CurrentRow.Cells("Cheque").Value
            registro.Descripcion = dgvDatos.CurrentRow.Cells("Descripcion").Value
            TipoMovBanco.CodTipo = dgvDatos.CurrentRow.Cells("CodTipo").Value
            TipoMovBanco.TipMov = dgvDatos.CurrentRow.Cells("TipMov").Value
            registro.TipoMovBanco = TipoMovBanco
            If Check = False Then
                registro.Conciliar = True
            Else
                registro.Conciliar = False
            End If
            registro.Monto = toDouble(dgvDatos.CurrentRow.Cells("Monto").Value)

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Modificar(registro)

        Catch ex As Exception
            MsgBox("Error al Actualizar : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class