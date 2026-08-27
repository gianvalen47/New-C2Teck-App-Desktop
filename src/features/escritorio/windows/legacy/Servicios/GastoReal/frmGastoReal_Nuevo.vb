Imports System.ServiceModel
Public Class frmGastoReal_Nuevo

    Private oMaestroService As New MaestroService.MaestroClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oJobService As New JobService.JobServiceClient

    Public IdGastoReal As Integer
    Public CodJob As String
    Public Actualizar As Boolean

    Public IdPersona As Integer
    Private IdCliente As Integer
    Dim dtSubRubros As DataTable
    Dim dtRubros As DataTable
    Dim dtPlaca As DataTable
    Dim dtMoneda As DataTable
    Dim dtTipDoc As DataTable
    Dim dtColaborador As DataTable
    Dim dtDatos As DataTable

    Private Sub frmGastoReal_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGastoRealService.Close()
            oJobService.Close()
            oMaestroService.Close()
            oVehiculoService.Close()
        Catch ex As TimeoutException
            oGastoRealService.Abort()
            oJobService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
        Catch ex As CommunicationException
            oGastoRealService.Abort()
            oJobService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
        End Try
    End Sub

    Private Sub frmGastoReal_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoReal_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        llenarCombos()
        If Actualizar Then
            txtNumJob.Text = CodJob
            cmbRubro.Focus()
        Else
            cmbMoneda.Value = "NS"
        End If
        If txtNumJob.Text = "" Then
            cmbRubro.Value = "5"
            txtNumJob.Text = CodJob
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente", MsgBoxStyle.Information)
                    Me.Close()
                    'ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    '    MsgBox("Número de Job Liquidado o Facturado")
                    '    Me.Close()
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("El OT esta liquidado o facturado, Verifique", MsgBoxStyle.Information)
                    Me.Close()
                End If
            End If
            listaSubRubro()
            cmbRubro.Focus()
        End If
        cmbTipDoc.Value = 3
        txtFecha.Value = Today
        listaDatos()
    End Sub

    Protected Sub llenarCombos()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '-------------------------------Moneda-----------------------------
            dtMoneda = oMaestroService.MostrarMonedas.Tables(0)
            dtMoneda.Rows.InsertAt(getRowTodos(dtMoneda), 0)
            cmbMoneda.DataSource = dtMoneda
            cmbMoneda.DropDownList.DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.SelectedIndex = 2
            dtMoneda = Nothing

            '-------------------------------Colaborador-----------------------------
            'dtColaborador = oMaestroService.FiltrarPersona("05", "").Tables(0)
            'dtColaborador.Rows.InsertAt(getRowTodos(dtColaborador), 0)
            'cmbColaborador.DisplayMember = dtColaborador.Columns("ApeNom").ToString()
            'cmbColaborador.ValueMember = dtColaborador.Columns("IdPer").ToString
            'cmbColaborador.DataSource = dtColaborador         
            'cmbColaborador.SelectedIndex = 0
            'dtColaborador = Nothing

            '-------------------------------Placa-----------------------------
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing

            '-------------------------------Tipo Documento -----------------------------
            dtTipDoc = oGastoRealService.MostrarTipoDocumento.Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipDoc.DataSource = dtTipDoc
            cmbTipDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.SelectedIndex = 0
            dtTipDoc = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR LOS COMBOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub listaSubRubro()
        Try
            '-------------------------------Sub Rubros-----------------------------
            dtSubRubros = oGastoRealService.MostrarSubRubros(cmbRubro.Value).Tables(0)
            dtSubRubros.Rows.InsertAt(getRowTodos(dtSubRubros), 0)
            cmbSubRubro.DataSource = dtSubRubros
            cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.SelectedIndex = 0
            dtSubRubros = Nothing

            ValidarCombo()
        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR COMBO SUBRUBRO : " + ex.Message)
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
            fila(1) = ""
        Catch ex As Exception

        End Try
        Try
            fila(2) = ""
        Catch ex As Exception

        End Try
        Try
            fila(3) = ""
        Catch ex As Exception

        End Try
        Try
            fila(4) = ""
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Protected Sub listaDatos()
        Try
            dtDatos = oGastoRealService.Mostrar(txtNumJob.Text, cmbRubro.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtNumJob.Text = "") Then
                MsgBox("Debe ingresar el número de OT")
                txtNumJob.Focus()
                Return False
            ElseIf utils.toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha del gasto")
                txtFecha.Focus()
                Return False
            ElseIf utils.toBlank(cmbRubro.Value) = "" Then
                MsgBox("Debe ingresar el rubro del gasto")
                cmbRubro.Focus()
                Return False
            ElseIf utils.toNumber(cmbTipDoc.Value) = 0 And cmbRubro.Value <> 7 Then
                MsgBox("Debe ingresar el tipo del documento")
                cmbTipDoc.Focus()
                Return False
            ElseIf utils.toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe ingresar la moneda")
                cmbMoneda.Focus()
                Return False
            ElseIf utils.toDouble(txtTotal.Value) = 0 Then
                MsgBox("Debe ingresar el monto")
                txtTotal.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub biActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Protected Sub limpiarDatos()
        Try
            IdPersona = 0
            txtProveedor.Text = ""
            txtNumDoc.Text = ""
            txtRuc.Text = ""
            txtFecha.Value = Today
            txtDescripcion.Text = ""
            txtTotal.Value = 0
            cmbPlaca.SelectedIndex = 0
            cmbRubro.Focus()
            'cmbColaborador.SelectedIndex = 0
            txtColaborador.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub ValidarCombo()
        Try
            '---------------------Terceros------------------
            If cmbRubro.Value = "2" Then
                btnBuscarPersona.Enabled = False
                IdPersona = 0
                txtColaborador.Text = ""
                'cmbColaborador.SelectedIndex = 0
                'cmbColaborador.Enabled = False
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                btnBuscarProveedor.Enabled = True
                cmbSubRubro.Enabled = True
                cmbSubRubro.SelectedIndex = 1
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True
                '--------------------------
                cmbPlaca.SelectedIndex = 0
                txtProveedor.Text = ""
                cmbTipDoc.Value = 3
                txtNumDoc.Text = ""
                txtRuc.Text = ""
                txtFecha.Value = Today
                txtDescripcion.Text = ""
                txtTotal.Value = 0

                '------------Gastos Viaje----------------
            ElseIf cmbRubro.Value = "3" Then
                btnBuscarPersona.Enabled = True
                IdPersona = 0
                txtColaborador.Text = ""
                'cmbColaborador.SelectedIndex = 0
                'cmbColaborador.Enabled = True
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                btnBuscarProveedor.Enabled = True
                cmbSubRubro.Enabled = True
                cmbSubRubro.SelectedIndex = 1
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True
                '--------------------------
                cmbPlaca.SelectedIndex = 0
                txtProveedor.Text = ""
                cmbTipDoc.Value = 3
                txtNumDoc.Text = ""
                txtRuc.Text = ""
                txtFecha.Value = Today
                txtDescripcion.Text = ""
                txtTotal.Value = 0

                '-----------------Materiales----------------
            ElseIf cmbRubro.Value = "4" Then
                btnBuscarPersona.Enabled = False
                IdPersona = 0
                txtColaborador.Text = ""
                'cmbColaborador.SelectedIndex = 0
                'cmbColaborador.Enabled = False
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                btnBuscarProveedor.Enabled = True
                cmbSubRubro.Enabled = False
                cmbSubRubro.SelectedIndex = 0
                cmbTipDoc.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True
                '--------------------------
                cmbPlaca.SelectedIndex = 0
                txtProveedor.Text = ""
                cmbTipDoc.Value = 3
                txtNumDoc.Text = ""
                txtRuc.Text = ""
                txtFecha.Value = Today
                txtDescripcion.Text = ""
                txtTotal.Value = 0

                '---------------------Varios-----------------
            ElseIf cmbRubro.Value = "5" Then
                btnBuscarPersona.Enabled = False
                IdPersona = 0
                txtColaborador.Text = ""
                'cmbColaborador.SelectedIndex = 0
                'cmbColaborador.Enabled = False
                cmbPlaca.Enabled = True
                txtProveedor.Enabled = False
                btnBuscarProveedor.Enabled = True
                cmbSubRubro.Enabled = True
                cmbSubRubro.SelectedIndex = 1
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True
                cmbPlaca.SelectedIndex = 0
                txtProveedor.Text = ""
                cmbTipDoc.Value = 3
                txtNumDoc.Text = ""
                txtRuc.Text = ""
                txtFecha.Value = Today
                txtDescripcion.Text = ""
                txtTotal.Value = 0

                '---------------------Refrig y Movil------------------
            ElseIf cmbRubro.Value = "7" Then
                ''btnBuscarPersona.Enabled = True
                ''IdPersona = 0
                ''txtSolicitante.Text = ""
                'cmbColaborador.SelectedIndex = 0
                'cmbColaborador.Enabled = True
                'cmbPlaca.Enabled = False
                'cmbPlaca.BackColor = Drawing.Color.White
                'txtProveedor.Enabled = False
                'cmbSubRubro.Enabled = True
                'cmbSubRubro.SelectedIndex = 1
                'cmbSubRubro.Focus()
                ''--------------------------
                'cmbTipDoc.Enabled = False
                'cmbTipDoc.BackColor = Drawing.Color.White
                'txtNumDoc.Enabled = False
                'txtRuc.Enabled = False
                'txtDescripcion.Enabled = False
                ''--------------------------
                'cmbPlaca.SelectedIndex = 0
                'txtProveedor.Text = ""
                'cmbTipDoc.SelectedIndex = 0
                'txtNumDoc.Text = ""
                'txtRuc.Text = ""
                'txtFecha.Value = Today
                'txtDescripcion.Text = ""
                'txtTotal.Value = 0
                '/////////////////////////////////////////////Modificado el 16/02/2012 para que puedan ingresar el Ruc en esta opcion 
                btnBuscarPersona.Enabled = True
                IdPersona = 0
                txtColaborador.Text = ""
                'cmbColaborador.SelectedIndex = 0
                'cmbColaborador.Enabled = True
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                btnBuscarProveedor.Enabled = True
                cmbSubRubro.Enabled = True
                cmbSubRubro.SelectedIndex = 1
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                cmbTipDoc.BackColor = Drawing.Color.White
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = False
                '--------------------------
                cmbPlaca.SelectedIndex = 0
                txtProveedor.Text = ""
                cmbTipDoc.SelectedIndex = 0
                txtNumDoc.Text = ""
                txtRuc.Text = ""
                txtFecha.Value = Today
                txtDescripcion.Text = ""
                txtTotal.Value = 0
            End If
        Catch ex As Exception
            MsgBox("ERRROR AL VALIDAR RUBRO : " + ex.Message)
        End Try
    End Sub

    Protected Sub Insertar(ByVal registro As GastoRealService.GastoReal)
        Try
            Dim estado_process As Integer

            estado_process = oGastoRealService.Insertar(registro)
            If estado_process Then
                MsgBox("Se inserto el Gasto Real correctamente")
                limpiarDatos()
                listaDatos()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR : " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then

                If MsgBox("¿Está seguro de ELIMINAR el Gasto Real N° " & dgvDatos.CurrentRow.Cells("IdGastoReal").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oGastoRealService.Borrar(dgvDatos.CurrentRow.Cells("IdGastoReal").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                    If estado_process Then
                        MsgBox("Se eliminó el Gasto Real correctamente ")
                        listaDatos()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If

                End If

            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar" + ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Protected Sub Guardar()
        Try
            If ValidaCampos() Then

                Dim registro As New GastoRealService.GastoReal
                Dim job As New GastoRealService.Job
                Dim persona As New GastoRealService.Persona
                Dim tipodocumento As New GastoRealService.TipoDocumento
                Dim moneda As New GastoRealService.Moneda
                Dim unidad As New GastoRealService.Unidad
                Dim rubrogasto As New GastoRealService.RubroGasto
                Dim subrubrogasto As New GastoRealService.SubRubroGasto

                job.CodJob = txtNumJob.Text
                registro.Job = job
                persona.IdPer = IdPersona
                registro.Persona = persona
                registro.Fecha = txtFecha.Value
                rubrogasto.CodRubro = cmbRubro.Value
                registro.RubroGasto = rubrogasto
                subrubrogasto.CodSubRubro = utils.toNull(cmbSubRubro.Value)
                registro.SubRubroGasto = subrubrogasto
                tipodocumento.IdDocumento = utils.toNumber(cmbTipDoc.Value)
                registro.TipoDocumento = tipodocumento
                registro.NumDoc = utils.toNull(txtNumDoc.Text)
                registro.Proveedor = utils.toNull(txtProveedor.Text)
                registro.Ruc = utils.toNull(txtRuc.Text)
                registro.Descripcion = utils.toNull(txtDescripcion.Text)
                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.MontoSol = utils.toDouble(txtTotal.Value)
                unidad.Placa = utils.toNull(cmbPlaca.Value)
                registro.Unidad = unidad
                registro.FecReg = Today
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                Insertar(registro)

            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    listaDatos()
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                End If
                listaDatos()
            Else
                MsgBox("Ingrese un N° de OT")
            End If
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = ""
                    IdPersona = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                    txtNumJob.Focus()
                Else
                    txtNumJob.Text = ""
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de OT")
            End If
            listaDatos()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub

    Private Sub cmbRubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRubro.KeyDown, cmbSubRubro.KeyDown, txtProveedor.KeyDown, cmbTipDoc.KeyDown, txtNumDoc.KeyDown, txtRuc.KeyDown, txtFecha.KeyDown, txtDescripcion.KeyDown, cmbMoneda.KeyDown, txtTotal.KeyDown, cmbPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then
            Guardar()
        End If
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        Try
            listaSubRubro()
            listaDatos()
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR EL COMBO SUBRUBRO" + ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        Mostrar()
        dgvDatos.Select()
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then
         
                Dim frm As New frmGastoReal_Modificar
                frm.IdGastoReal = CInt(dgvDatos.CurrentRow.Cells("IdGastoReal").Value)
                frm.ShowDialog()
                listaDatos()
                RowPossesion(dgvDatos, frm.IdGastoReal)
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdGastoReal").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                Mostrar()
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frmBuscarProveedor
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtProveedor.Text = frm.descripcion
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            'IdCliente = frm.codigo
            txtRuc.Text = frm.ruc
        End If
        txtProveedor.Select()
    End Sub
End Class