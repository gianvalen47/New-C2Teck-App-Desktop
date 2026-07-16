Imports System.ServiceModel
Public Class frmGastoViaje_Nuevo

    Private oPreGastoRealService As New PreGastoRealService.PreGastoRealServiceClient
    Private oPreGastoRealDetService As New PreGastoRealDetService.PreGastoRealDetServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Private dtMonedas As DataTable
    Private dtRubro As DataTable
    Private dtTipMov As DataTable
    Private dtSubRubros As DataTable
    Private dtPlaca As DataTable
    Private dtTipDoc As DataTable
    Private dtConcepto As DataTable

    Private IdProveedor As Integer
    Public IdPreGastoReal As Integer
    Public IdPreGastoRealDet As Integer
    Public IdPersona As Integer
    'Public Actualizar As Boolean
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable

    Private Sub frmGastoViaje_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        llenarCombos()
        ToolTip1.SetToolTip(btnInfUsuario, "Información del Usuario")
        ToolTip2.SetToolTip(btnGuardarDetalle, "Guardar Detalle")
        If state_button Then
            ObtenerRegistros()
            listaDatos()
            Desactivar()
            biVerHoras.Enabled = True
            txtEstadoJob.Visible = True
            btnInfUsuario.Visible = True
            Me.Text = "Gasto de Viaje Nº" + txtNumero.Text
            txtFechaDet.Focus()
        Else
            Dim usuario As New SeguridadService.Usuario
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            IdPersona = usuario.Persona.IdPer
            txtSolicitante.Text = usuario.Persona.ApeNom
            cmbMoneda.Value = "NS"
            lblTotalAprobado.Visible = False
            txtToAproSinIgv.Visible = False
            txtEstadoJob.Visible = False
            biVerHoras.Enabled = False
            btnInfUsuario.Visible = False
            Me.Size = New System.Drawing.Size(1006, 203)
            Me.Text = "Nuevo Gasto de Viaje"
            txtNumJob.Focus()
        End If
        enableOpciones()
    End Sub

    Private Sub frmGastoViaje_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPreGastoRealService.Close()
            oPreGastoRealDetService.Close()
            oGastoRealService.Close()
            oMaestroService.Close()
            oVehiculoService.Close()
            oSeguridadService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oPreGastoRealService.Abort()
            oPreGastoRealDetService.Abort()
            oGastoRealService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oPreGastoRealService.Abort()
            oPreGastoRealDetService.Abort()
            oGastoRealService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmGastoViaje_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPreGastoRealDet").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Protected Sub enableOpciones()
        Try
            If state_button = False Then
                biGuardar.Enabled = True
                biEditar.Enabled = False
                biDeshacer.Enabled = False
                btnBuscarPersona.Enabled = IIf(Not (Session.CodPerfil = "23"), True, False)
            Else
                biGuardar.Enabled = False                
                If Session.CodPerfil = "17" Then
                    biEditar.Enabled = IIf(oPreGastoRealService.Estado(txtNumero.Text) = 0 Or oPreGastoRealService.Estado(txtNumero.Text) = 1, True, False)
                    btnGuardarDetalle.Enabled = IIf(oPreGastoRealService.Estado(txtNumero.Text) = 1 Or oPreGastoRealService.Estado(txtNumero.Text) = 0, True, False)
                Else
                    biEditar.Enabled = IIf(oPreGastoRealService.Estado(txtNumero.Text) = 0, True, False)
                    btnGuardarDetalle.Enabled = IIf(oPreGastoRealService.Estado(txtNumero.Text) = 0 Or (Session.CodPerfil = "24" And oPreGastoRealService.Estado(txtNumero.Text) <> 3), True, False)
                End If
            End If
            biSalir.Enabled = Not edicion
            biDeshacer.Enabled = edicion
            cmOpciones.Enabled = IIf(editable And lblEstado.Text <> "", Not edicion, False)
        Catch ex As Exception
            MsgBox("ERROR AL HABILITAR LOS BOTONES : " + ex.Message)
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

    Protected Sub llenarCombos()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubro = oPreGastoRealDetService.MostrarRubros.Tables(0)
            dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            'cmbRubro.SelectedIndex = 0
            dtRubro = Nothing

            '-------------------------------Moneda-----------------------------
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            'dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 1
            dtMonedas = Nothing

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

            '-------------------------------Concepto -----------------------------
            dtSubRubros = oPreGastoRealDetService.MostrarSubRubros(cmbRubro.Value).Tables(0)
            dtSubRubros.Rows.InsertAt(getRowTodos(dtSubRubros), 0)
            cmbSubRubro.DataSource = dtSubRubros
            cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.SelectedIndex = 0
            dtSubRubros = Nothing

            '-----------------------------Tipo Movimiento ------------------------------------
            dtTipMov = New DataTable
            dtTipMov.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipMov.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipMov.Rows.Add(New Object() {"0", ""})
            dtTipMov.Rows.Add(New Object() {"1", "Transferencia"})
            dtTipMov.Rows.Add(New Object() {"2", "Deposito"})

            cmbTipMov.DataSource = dtTipMov
            cmbTipMov.DropDownList.DataMember = dtTipMov.Columns("nombre").ToString
            cmbTipMov.DropDownList.DisplayMember = dtTipMov.Columns("nombre").ToString
            cmbTipMov.DropDownList.ValueMember = dtTipMov.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(0).DataMember = dtTipMov.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(1).DataMember = dtTipMov.Columns("nombre").ToString
            cmbTipMov.SelectedIndex = 0
            dtTipMov = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR LOS COMBOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub listaDatos()
        Try
            dtDatos = oPreGastoRealDetService.Mostrar(IdPreGastoReal).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString            
            Sumar()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES : " + ex.Message)
        End Try
    End Sub

    Protected Sub Sumar()
        Try
            Dim total As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As Boolean
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("Monto").Value
                If bSelected Then
                    total = total + CDbl(Me.dgvDatos.CurrentRow.Cells("Monto").Value)
                End If
            Next
            lblTotal.Text = "Monto Total  " + cmbMoneda.Text
            txtTotalMonto.Value = total
        Catch ex As Exception
            MsgBox("Error al sumar Montos" + ex.Message)
        End Try
    End Sub

    Protected Sub Desactivar()
        Try
            txtNumJob.ReadOnly = True
            btnBuscarJob.Enabled = False
            txtSolicitante.ReadOnly = True
            btnBuscarPersona.Enabled = False
            cmbMoneda.Enabled = False
            cmbMoneda.BackColor = Drawing.Color.White
            cmbTipMov.Enabled = False
            cmbTipMov.BackColor = Drawing.Color.White
            txtVoucher.ReadOnly = True
            txtMonto.ReadOnly = True
            txtFecRegVou.Enabled = False
            '------------------------------------
            biGuardar.Enabled = False
            'biEditar.Enabled = True
            edicion = False
        Catch ex As Exception
            MsgBox("ERROR AL DESHABILITAR LAS OPCIONES : " + ex.Message)
        End Try
    End Sub

    Protected Sub Activar()
        Try
            txtNumJob.ReadOnly = True
            btnBuscarJob.Enabled = False
            txtSolicitante.ReadOnly = True
            btnBuscarPersona.Enabled = False
            cmbMoneda.Enabled = False
            cmbMoneda.BackColor = Drawing.Color.White
            cmbTipMov.Enabled = True
            txtVoucher.ReadOnly = False
            txtMonto.ReadOnly = False
            txtFecRegVou.Enabled = True
            '------------------------------------
            enableOpciones()
            biGuardar.Enabled = True
            'biEditar.Enabled = False
            edicion = True
        Catch ex As Exception
            MsgBox("ERROR AL HABILITAR LAS OPCIONES : " + ex.Message)
        End Try
    End Sub

    Protected Sub ObtenerRegistros()
        Try
            Dim registro As PreGastoRealService.PreGastoReal
            registro = oPreGastoRealService.Obtener(IdPreGastoReal)
            txtNumero.Text = registro.IdPreGastoReal
            txtNumJob.Text = registro.Job.CodJob
            txtEstadoJob.Text = registro.Job.EstadoJob.AbrEstado
            IdPersona = (registro.Persona.IdPer)
            txtSolicitante.Text = registro.Persona.ApeNom
            txtToAproSinIgv.Value = registro.TotAprobado
            lblEstado.Text = registro.EstadoPreGasto.DesEstado
            cmbMoneda.Value = registro.Moneda.CodMon
            txtSupervisor.Text = registro.CodUsuApro
            txtAdministrador.Text = registro.CodUsuAproAdmin
            If registro.TipoMovimiento = "Transferencia" Then
                cmbTipMov.SelectedIndex = 1
            ElseIf registro.TipoMovimiento = "Deposito" Then
                cmbTipMov.SelectedIndex = 2
            End If
            txtVoucher.Text = registro.NroVoucher
            txtMonto.Value = registro.TotDevuelto
            If Not (registro.FecVoucher.ToString = "") Then
                txtFecRegVou.Value = CDate(registro.FecVoucher)
                txtFecRegVou.Text = registro.FecVoucher.ToString
            End If
            txtFecAproSup.Text = utils.toNull(registro.FecApro.ToString)
            txtFecAproAdm.Text = utils.toNull(registro.FecAproAdmin.ToString)
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtNumJob.Text) = "" Then
                MsgBox("Debe ingresar el número de OT")
                txtNumJob.Focus()
                Return False
            ElseIf utils.toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar la persona")
                txtSolicitante.Focus()
                Return False
            ElseIf utils.toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe ingresar la moneda")
                cmbMoneda.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Function ValidaCamposDet() As Boolean
        Try
            If txtFechaDet.Value = Nothing Then
                MsgBox("Debe ingresar la fecha del detalle del gasto de viaje")
                txtFechaDet.Focus()
                Return False
            ElseIf cmbRubro.Text = "" Then
                MsgBox("Debe ingresar el codigo del rubro")
                cmbRubro.Focus()
                Return False
            ElseIf cmbTipDoc.Text = "" Then
                MsgBox("Debe ingresar el tipo documento")
                cmbTipDoc.Focus()
                Return False
            ElseIf txtDescripcion.Text = "" Then
                MsgBox("Debe ingresar la descripción")
                txtDescripcion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS DEL DETALLE " + ex.Message)
        End Try

    End Function

    Protected Sub limpiarDet()
        Try
            llenarCombos()
            txtFechaDet.Value = Today
            cmbRubro.SelectedIndex = 0
            txtSerieDoc.Text = ""
            txtNumDoc.Text = ""
            txtDescripcion.Text = ""
            IdProveedor = 0
            txtProveedor.Text = ""
            txtRuc.Text = ""
            txtTotal.Value = 0
            txtFechaDet.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New PreGastoRealService.PreGastoReal
                Dim job As New PreGastoRealService.Job
                Dim persona As New PreGastoRealService.Persona
                Dim moneda As New PreGastoRealService.Moneda
                registro.IdPreGastoReal = IdPreGastoReal
                job.CodJob = txtNumJob.Text
                registro.Job = job
                persona.IdPer = utils.toNumber(IdPersona)
                registro.Persona = persona
                registro.IdProv = 0
                registro.TipoMovimiento = cmbTipMov.Text
                registro.NroVoucher = txtVoucher.Text
                registro.FecVoucher = IIf(txtFecRegVou.Value = Nothing, Nothing, txtFecRegVou.Value)
                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.TotDevuelto = txtMonto.Value
                registro.FecRegistro = Today
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub GuardarDet()
        Try
            If ValidaCamposDet() Then
                Dim registro As New PreGastoRealDetService.PreGastoRealDet
                Dim pregastoreal As New PreGastoRealDetService.PreGastoReal
                Dim rubrogastoviaje As New PreGastoRealDetService.RubroGastoViaje
                Dim subrubrogastoviaje As New PreGastoRealDetService.SubRubroGastoViaje
                Dim tipodocumento As New PreGastoRealDetService.TipoDocumento
                Dim proveedor As New PreGastoRealDetService.Proveedor

                pregastoreal.IdPreGastoReal = IdPreGastoReal
                registro.PreGastoReal = pregastoreal
                registro.Fecha = txtFechaDet.Value
                rubrogastoviaje.CodRubro = cmbRubro.Value
                registro.RubroGastoViaje = rubrogastoviaje
                subrubrogastoviaje.CodSubRubro = utils.toNull(cmbSubRubro.Value)
                registro.SubRubroGastoViaje = subrubrogastoviaje
                tipodocumento.IdDocumento = cmbTipDoc.Value
                registro.TipoDocumento = tipodocumento
                registro.SerDoc = txtSerieDoc.Text
                registro.NumDoc = txtNumDoc.Text
                'registro.Ruc = txtRuc.Text
                proveedor.IdProveedor = utils.toNull(IdProveedor)
                proveedor.RucProv = utils.toNull(txtRuc.Text)
                registro.Proveedor = proveedor
                'registro.Proveedor = proveedor
                registro.Descripcion = txtDescripcion.Text
                registro.Monto = txtTotal.Value
                registro.Placa = utils.toNull(cmbPlaca.Value)
                registro.FecRegistro = Today
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                InsertarDetalle(registro)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DETALLES : " + ex.Message)
        End Try
    End Sub

    Protected Sub Insertar(ByVal registro As PreGastoRealService.PreGastoReal)
        Try
            Dim estado_process As Integer
            estado_process = oPreGastoRealService.Insertar(registro)
            If estado_process > 0 Then
                MsgBox("Se inserto el Gasto de Viaje correctamente")
                IdPreGastoReal = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administardor del TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As PreGastoRealService.PreGastoReal)
        Try
            Dim estado_process As Boolean
            estado_process = oPreGastoRealService.Actualizar(registro)
            If estado_process Then
                MsgBox("Se modifico el registro correctamente")
                ObtenerRegistros()
                Desactivar()
            Else
                MsgBox("Error en el proceso, comunicarse con el administrador del TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub InsertarDetalle(ByVal registro As PreGastoRealDetService.PreGastoRealDet)
        Try
            Dim estado_process As Integer
            estado_process = oPreGastoRealDetService.Insertar(registro)
            If estado_process Then
                MsgBox("Se guardo correctamente el detalle")
                listaDatos()
                limpiarDet()
                txtFechaDet.Focus()
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del TI ")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL DETALLE : " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then
                If MsgBox("¿Está seguro de ELIMINAR el Detalle de Gasto de Viaje N° " & dgvDatos.CurrentRow.Cells("IdPreGastoRealDet").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPreGastoRealDetService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdPreGastoRealDet").Value), IdPreGastoReal, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                    If estado_process Then
                        MsgBox("Se eliminó el registro correctamente")
                        listaDatos()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                    listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar el Detalle" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged

        '-------------------------------Concepto -----------------------------
        dtSubRubros = oPreGastoRealDetService.MostrarSubRubros(cmbRubro.Value).Tables(0)
        dtSubRubros.Rows.InsertAt(getRowTodos(dtSubRubros), 0)
        cmbSubRubro.DataSource = dtSubRubros
        cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
        cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
        cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.SelectedIndex = 0
        dtSubRubros = Nothing
        txtDescripcion.Text = ""
        cmbSubRubro.Focus()

    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        biGuardar.Enabled = True
        biEditar.Enabled = False
        Activar()
    End Sub

    Private Sub cmbSubRubro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubRubro.TextChanged
        txtDescripcion.Text = cmbSubRubro.Text
        cmbTipDoc.Focus()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
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
                listaDatos()
            Else
                MsgBox("Ingrese un N° de OT")
            End If
        End If
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

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = ""
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

    Private Sub btnGuardarDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarDetalle.Click, btnGuardarDetalle.KeyDown
        If ValidaCamposDet() Then
            If MsgBox("¿Está seguro de GUARDAR el detalle", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                GuardarDet()
            End If
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, miMostrar.Click
        Dim frm As New frmGastoViaje_ModificarDet
        frm.IdPreGastoRealDet = CInt(dgvDatos.CurrentRow.Cells("IdPreGastoRealDet").Value)
        frm.ShowDialog()
        listaDatos()
        RowPossesion(dgvDatos, frm.IdPreGastoRealDet)
    End Sub

    Private Sub btnInfUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfUsuario.Click
        Dim frm As New frmGastoViaje_InformacionUsuario
        frm.IdPersona = IdPersona
        frm.ShowDialog()
    End Sub

    Private Sub biVerHoras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerHoras.Click
        Dim frm As New frmGastoViaje_VerHoras
        frm.IdPersona = IdPersona
        frm.CodJob = txtNumJob.Text
        frm.ShowDialog()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistros()
            End If
        End If
    End Sub

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR el Detalle de Gasto de Viaje N° " & dgvDatos.CurrentRow.Cells("IdPreGastoRealDet").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPreGastoRealDetService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdPreGastoRealDet").Value), IdPreGastoReal, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                If estado_process Then
                    MsgBox("Se eliminó el registro correctamente ")
                    listaDatos()
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar el Detalle" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtRuc.Text = frm.ruc
                    txtDescripcion.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
                txtRuc.Text = frm.RucProv
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class