Imports System.ServiceModel
Public Class frmGastoReal_Modificar

    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oJobService As New JobService.JobServiceClient

    Public IdGastoReal As Integer
    Public IdGastoGer As Integer
    Public IdPersona As Integer
    'Public Actualizar As Boolean
    Public CodJob As String

    Private dtRubros As DataTable
    Private dtSubRubros As DataTable
    Private dtMoneda As DataTable
    Private dtPlaca As DataTable
    Private dtTipDoc As DataTable
    Private dtColaborador As DataTable

    Private Sub frmGastoReal_Modificar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmGastoReal_Modificar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoReal_Modificar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            llenarCombos()
            ObtenerRegistro()
            If Len(Trim(txtCodJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtCodJob.Text)) Then
                    MsgBox("Número de OT no existente")
                    Me.Close()
                End If
                If (oJobService.Estado(txtCodJob.Text) = 16 Or oJobService.Estado(txtCodJob.Text) = 25) And oJobService.Regularizar(txtCodJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado")
                    Me.Close()
                End If
            End If
            ValidarGuardar()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD" + ex.Message)
        End Try
    End Sub

    Private Sub ValidarGuardar()

        If IdGastoGer <> 0 And Session.CodPerfil <> "13" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
        End If

    End Sub

    Protected Sub ValidarCombo()
        Try
            '---------------------Terceros------------------
            If cmbRubro.Value = "2" Then
                btnBuscarPersona.Enabled = False
                'cmbColaborador.Enabled = False
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                cmbRubro.Enabled = False
                cmbRubro.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                cmbSubRubro.Enabled = True
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True

                '------------Gastos Viaje----------------
            ElseIf cmbRubro.Value = "3" Then
                btnBuscarPersona.Enabled = True
                'cmbColaborador.Enabled = True
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                cmbRubro.Enabled = False
                cmbRubro.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                cmbSubRubro.Enabled = True
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True

                '-----------------Materiales----------------
            ElseIf cmbRubro.Value = "4" Then
                btnBuscarPersona.Enabled = False
                'cmbColaborador.Enabled = False
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                cmbRubro.Enabled = False
                cmbRubro.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                cmbSubRubro.Enabled = False
                cmbSubRubro.BackColor = Drawing.Color.White
                '--------------------------
                cmbTipDoc.Enabled = True
                cmbTipDoc.Focus()
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True

                '---------------------Varios-----------------
            ElseIf cmbRubro.Value = "5" Then
                btnBuscarPersona.Enabled = False
                'cmbColaborador.Enabled = False
                cmbPlaca.Enabled = True
                cmbRubro.Enabled = False
                cmbRubro.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                cmbSubRubro.Enabled = True
                cmbSubRubro.Focus()
                '--------------------------
                cmbTipDoc.Enabled = True
                txtNumDoc.Enabled = True
                txtRuc.Enabled = True
                txtDescripcion.Enabled = True

                '---------------------Refig y Movil------------------
            ElseIf cmbRubro.Value = "7" Then
                btnBuscarPersona.Enabled = True
                'cmbColaborador.Enabled = True
                cmbPlaca.Enabled = False
                cmbPlaca.BackColor = Drawing.Color.White
                cmbRubro.Enabled = False
                cmbRubro.BackColor = Drawing.Color.White
                txtProveedor.Enabled = False
                cmbSubRubro.Enabled = True
                cmbSubRubro.Focus()
                '-----------------------------------
                cmbTipDoc.Enabled = False
                cmbTipDoc.BackColor = Drawing.Color.White
                txtNumDoc.Enabled = False
                txtRuc.Enabled = False
                txtDescripcion.Enabled = False

            End If
        Catch ex As Exception
            MsgBox("ERRROR AL VALIDAR RUBRO : " + ex.Message)
        End Try
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
            cmbMoneda.SelectedIndex = 0
            dtMoneda = Nothing

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

            ''-------------------------------Colaborador-----------------------------
            'dtColaborador = oMaestroService.FiltrarPersona("05", "").Tables(0)
            'dtColaborador.Rows.InsertAt(getRowTodos(dtColaborador), 0)
            'cmbColaborador.DisplayMember = dtColaborador.Columns("ApeNom").ToString()
            'cmbColaborador.ValueMember = dtColaborador.Columns("IdPer").ToString
            'cmbColaborador.DataSource = dtColaborador
            'cmbColaborador.SelectedIndex = 0
            'dtColaborador = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR LOS COMBOS : " + ex.Message)
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

    Protected Sub ObtenerRegistro()
        Try
            Dim registro As GastoRealService.GastoReal
            registro = oGastoRealService.Obtener(IdGastoReal)

            txtCodJob.Text = registro.Job.CodJob
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            txtProveedor.Text = registro.Proveedor
            cmbRubro.Value = registro.RubroGasto.CodRubro
            listaSubRubro()
            cmbSubRubro.Value = registro.SubRubroGasto.CodSubRubro
            cmbTipDoc.Value = registro.TipoDocumento.IdDocumento
            txtNumDoc.Text = registro.NumDoc
            txtRuc.Text = registro.Ruc
            txtFecha.Value = registro.Fecha
            txtDescripcion.Text = registro.Descripcion
            cmbMoneda.Value = registro.Moneda.CodMon
            If cmbMoneda.Value = "US" Then
                txtTotal.Value = utils.toDouble(registro.MontoDol)
            Else
                txtTotal.Value = utils.toDouble(registro.MontoSol)
            End If

            cmbPlaca.Value = registro.Unidad.Placa

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        Try
            listaSubRubro()
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR EL COMBO SUBRUBRO." + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As GastoRealService.GastoReal)
        Try
            Dim estado_process As Boolean

            estado_process = oGastoRealService.Actualizar(registro)
            If estado_process Then
                MsgBox("Se modifico el Gasto Real correctamente")
                Me.Close()

            Else
                MsgBox("Error en el proceso, comunicarse con el area de TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtCodJob.Text = "") Then
                MsgBox("Debe ingresar el número de OT")
                txtCodJob.Focus()
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

    Protected Sub Guardar()
        Try

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

                    registro.IdGastoReal = IdGastoReal
                    job.CodJob = txtCodJob.Text
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
                    registro.NumDoc = txtNumDoc.Text
                    registro.Proveedor = txtProveedor.Text
                    registro.Ruc = txtRuc.Text
                    registro.Descripcion = txtDescripcion.Text
                    moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = moneda
                    registro.MontoSol = txtTotal.Value
                    unidad.Placa = utils.toNull(cmbPlaca.Value)
                    registro.Unidad = unidad
                    registro.FecReg = Today
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    Modificar(registro)

                End If

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
            End Try

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click, btnBuscarPersona.KeyPress
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

    Private Sub cmbSubRubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSubRubro.KeyDown, txtProveedor.KeyDown, cmbTipDoc.KeyDown, txtNumDoc.KeyDown, txtRuc.KeyDown, txtFecha.KeyDown, txtDescripcion.KeyDown, cmbMoneda.KeyDown, txtTotal.KeyDown, cmbPlaca.KeyDown, cmbColaborador.KeyDown
        If e.KeyCode = Keys.Enter Then
            Guardar()
        End If
    End Sub
End Class