Imports System.ServiceModel
Public Class frmAsientos

    '===========================Servicios====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oTesoreriaDetService As New TesoreriaDetService.TesoreriaDetServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables=============================
    Public IdTesoreria As Integer                   'Id del Registro de Tesoreria
    Private dtMonedas As DataTable
    Private dtTipDocumento As DataTable
    Private dtDatos As DataTable
    Private dtCuentaBancos As DataTable

    Private CodBan As String                       'CodBan seleccionado del combo cmbCuentaBanco
    Public IEditable As Boolean                    'Valor que devuelve el método BuscarEditable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Private Sub frmAsientos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAsientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oTesoreriaService.Close()
            oTesoreriaDetService.Close()
            oCuentaContableService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oTesoreriaService.Abort()
            oTesoreriaDetService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oTesoreriaService.Abort()
            oTesoreriaDetService.Abort()
            oCuentaContableService.Abort()
        End Try        
    End Sub

    Private Sub frmAsientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 172)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        LlenarCombos()
        txtDesCuenta.Text = ""
        lblDesCuenta.Text = ""
        lblDesCtaBanco.Text = ""

        txtPeriodo.Value = Today.Year
        txtMesRegistro.Text = Format(Month(Today), "00")
        ObtenerNumRegistro()
        state_button = False
        Desactivar()
        txtNumRegistro.Focus()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdTesoreriaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Text
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

    Private Sub Desactivar()
        txtPeriodo.ReadOnly = False
        txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        txtMesRegistro.ReadOnly = False
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
        txtNumRegistro.ReadOnly = False
        txtNumRegistro.BackColor = System.Drawing.SystemColors.Window
        btnBuscarRegistro.Enabled = True

        cmbCuentaBanco.ReadOnly = True
        cmbCuentaBanco.BackColor = System.Drawing.SystemColors.Control
        txtCodCuenta.ReadOnly = True
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCuenta.Enabled = False

        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtTipCambio.ReadOnly = True
        txtTipCambio.BackColor = System.Drawing.SystemColors.Control
        btnPendientes.Enabled = False
        btnProvisional.Enabled = False
        btnReembolso.Enabled = False
        btnRendirFondos.Enabled = False
        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtGlosa.ReadOnly = True
        txtGlosa.BackColor = System.Drawing.SystemColors.Control

        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        rbAnulado.Enabled = False

        edicion = False
        enableOpciones()
    End Sub

    Private Sub Activar()
        If state_button Then
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarRegistro.Enabled = True

            cmbCuentaBanco.ReadOnly = False
            cmbCuentaBanco.BackColor = System.Drawing.SystemColors.Window
            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCuenta.Enabled = True

            If dgvDatos.RowCount = 0 Then
                txtFecha.ReadOnly = False
                txtFecha.BackColor = System.Drawing.SystemColors.Window
            Else
                txtFecha.ReadOnly = True
                txtFecha.BackColor = System.Drawing.SystemColors.Control
            End If
       
            btnPendientes.Enabled = False
            btnProvisional.Enabled = False
            btnReembolso.Enabled = False
            btnRendirFondos.Enabled = False

            txtNombre.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window

            rbAnulado.Enabled = True

            If dgvDatos.RowCount > 0 Then
                txtTipCambio.ReadOnly = True
                txtTipCambio.BackColor = System.Drawing.SystemColors.Control
                cmbMoneda.ReadOnly = True
                cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            Else
                txtTipCambio.ReadOnly = False
                txtTipCambio.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            End If

        Else
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarRegistro.Enabled = True

            cmbCuentaBanco.ReadOnly = False
            cmbCuentaBanco.BackColor = System.Drawing.SystemColors.Window

            ''============DATOS SELECCIONADO POR DEFECTO============
            'cmbCuentaBanco.Value = "191-0715400-0-62"
            'lblDesCtaBanco.Text = "CREDITO DEL PERU"
            'txtCodCuenta.Text = "104.11"
            'CodBan = "01"
            ''=======================================================

            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCuenta.Enabled = True

            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window

            If toNumber(txtMesRegistro.Text) = Month(Today) And txtPeriodo.Value = Year(Today) Then
                txtFecha.Value = Today
                txtFecha.Text = Today
            Else
                txtFecha.Value = DateSerial(txtPeriodo.Value, toNumber(txtMesRegistro.Text) + 1, 0)
                txtFecha.Text = CStr(DateSerial(txtPeriodo.Value, toNumber(txtMesRegistro.Text) + 1, 0))
            End If
            btnPendientes.Enabled = True
            btnProvisional.Enabled = True
            btnReembolso.Enabled = True
            btnRendirFondos.Enabled = True

            txtTipCambio.ReadOnly = False
            txtTipCambio.BackColor = System.Drawing.SystemColors.Window

            txtNombre.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window

            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.Value = "NS"

            rbAnulado.Enabled = True
            rbAnulado.Checked = False

            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Value)), "#0.000")
            cmbCuentaBanco.Focus()
        End If
        edicion = True
        enableOpciones()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miDuplicar.Enabled = False
        Else
            miMostrar.Enabled = True
            'miEliminar.Enabled = IIf(editable And (state_button = True And IEditable = False), True, False)        'Se comenta para habilitar la edición para el Sr Jesus Alba (Rend Gastos)
            miEliminar.Enabled = IIf(editable And (state_button = True), True, False)
            'miDuplicar.Enabled = IIf(editable And (state_button = True And IEditable = False), True, False)        'Se comenta para habilitar la edición para el Sr Jesus Alba (Rend Gastos)
            miDuplicar.Enabled = IIf(editable And (state_button = True), True, False)
        End If
        'miNuevo.Enabled = IIf(editable And (state_button = True And IEditable = False), True, False)               'Se comenta para habilitar la edición para el Sr Jesus Alba (Rend Gastos)
        miNuevo.Enabled = IIf(editable And (state_button = True), True, False)

        biEditar.Enabled = IIf(editable, Not edicion And IdTesoreria <> 0, False)
        biArchivo.Enabled = IIf(editable, Not edicion And IdTesoreria <> 0, False)
        biSalir.Enabled = Not edicion
        biImprimir.Enabled = IIf(Not edicion, True, False)
        'biImportar.Enabled = IIf(Not edicion And IdCompra = 0, True, False)
        biEliminar.Enabled = IIf(Not edicion And IdTesoreria <> 0, True, False)
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        biImportarPlanillasCobranzas.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion And IdTesoreria <> 0, True, False)
    End Sub

    Private Sub ObtenerNumRegistro()
        Try            
            txtNumRegistro.Text = oTesoreriaService.ObtenerRegistro(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text)
            txtNumRegistro.Focus()
            txtNumRegistro.SelectAll()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER Nº  DE REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As New TesoreriaService.Tesoreria
            registro = oTesoreriaService.Obtener(IdTesoreria)

            IdTesoreria = registro.IdTesoreria
            txtPeriodo.Value = registro.Periodo
            txtMesRegistro.Text = registro.Mes
            txtNumRegistro.Text = registro.NumRegistro

            cmbCuentaBanco.Value = registro.CuentaBancos.NumCta
            lblDesCtaBanco.Text = registro.CuentaBancos.Banco.DesBan '& "  " & registro.CuentaBancos.Moneda.CodMon
            txtCodCuenta.Text = registro.CuentaContable.CodCuenta
            lblDesCuenta.Text = registro.CuentaContable.NomCuenta
            CodBan = registro.CuentaBancos.Banco.CodBan
            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtTipCambio.Value = registro.TipCam

            txtNombre.Text = registro.Nombre
            txtGlosa.Text = registro.Glosa

            cmbMoneda.Value = registro.Moneda.CodMon
            rbAnulado.Checked = registro.Anulado

            txtTotalDebeSol.Value = registro.TotalDebeSol
            txtTotalHaberSol.Value = registro.TotalHaberSol

            txtTotalDebeDol.Value = registro.TotalDebeDol
            txtTotalHaberDol.Value = registro.TotalHaberDol

            'IEditable = oTesoreriaService.BuscarEditable(IdTesoreria)
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
            fila(3) = 0
        End Try
        Try
            fila(3) = ""
        Catch ex As Exception
            fila(4) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try

            '======================================MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos1(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.SelectedIndex = 0
            dtMonedas = Nothing

            '====================================CUENTA BANCOS ============================================
            dtCuentaBancos = oTesoreriaService.MostrarCuentaBancos(Session.sCodEmp).Tables(0)
            dtCuentaBancos.Rows.InsertAt(getRowTodos1(dtCuentaBancos), 0)
            cmbCuentaBanco.DataSource = dtCuentaBancos
            cmbCuentaBanco.DropDownList.DataMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.DisplayMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.ValueMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.Columns(0).DataMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.Columns(1).DataMember = dtCuentaBancos.Columns("DesBan").ToString
            cmbCuentaBanco.DropDownList.Columns(2).DataMember = dtCuentaBancos.Columns("CodMon").ToString
            cmbCuentaBanco.DropDownList.Columns(3).DataMember = dtCuentaBancos.Columns("CodBan").ToString
            cmbCuentaBanco.DropDownList.Columns(4).DataMember = dtCuentaBancos.Columns("CodCuenta").ToString
            cmbCuentaBanco.SelectedIndex = 0
            dtCuentaBancos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar()
        IdTesoreria = 0
        CodBan = ""

        cmbCuentaBanco.SelectedIndex = 0
        lblDesCtaBanco.Text = ""

        txtCodCuenta.Text = ""
        lblDesCuenta.Text = ""

        txtFecha.IsNullDate = True
        txtTipCambio.Value = 0

        txtNombre.Text = ""
        txtGlosa.Text = ""

        cmbMoneda.SelectedIndex = 0
        rbAnulado.Checked = False

        dgvDatos.DataSource = Nothing
        txtTotalDebeSol.Value = 0
        txtTotalDebeDol.Value = 0

        txtTotalHaberDol.Value = 0
        txtTotalHaberSol.Value = 0

        txtDesCuenta.Text = ""

        txtNumRegistro.Focus()
    End Sub

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el Registro Nº : " + txtMesRegistro.Text + " - " + txtNumRegistro.Text + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oTesoreriaService.Borrar(IdTesoreria, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("¡Se eliminó correctamente el registro...!", MsgBoxStyle.Information)
                    Limpiar()
                    ObtenerNumRegistro()
                    state_button = False
                    Desactivar()
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL REGISTRO DE TESORERIA  :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As TesoreriaService.Tesoreria)
        Try
            Dim estado_process As Integer
            estado_process = oTesoreriaService.Insertar(registro)
            If estado_process > 0 Then
                IdTesoreria = estado_process
                MsgBox("¡Se insertó el Registro de Tesoría Correctamente...!")
                Desactivar()
                ObtenerRegistro()                
                state_button = True
                enableOpciones()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR REGISTRO DE TESORERÍA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As TesoreriaService.Tesoreria)
        Try
            Dim estado_process As Boolean
            estado_process = oTesoreriaService.Actualizar(registro)
            If estado_process = True Then
                ObtenerRegistro()
                Desactivar()
                state_button = True

            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR REGISTRO DE TESORERÍA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtMesRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el Mes de Registro.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toNumber(txtNumRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el Número de Registro.", MsgBoxStyle.Information, "Información")
                txtNumRegistro.Focus()
                Return False
            ElseIf toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                cmbCuentaBanco.Focus()
                Return False
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar !!!", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
                Return False
            ElseIf toBlank(txtNombre.Text) = "" Then
                MsgBox("Debe Ingresar el Nombre.", MsgBoxStyle.Information, "Información")
                txtNombre.Focus()
                Return False
                'ElseIf toBlank(txtGlosa.Text) = "" Then
                '    MsgBox("Debe Ingresar la Glosa.", MsgBoxStyle.Information, "Información")
                '    txtGlosa.Focus()
                '    Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'ElseIf rbActivo.Checked = False And rbAnulado.Checked = False Then
                '    MsgBox("Debe Ingresar el Estado.", MsgBoxStyle.Information, "Información")
                '    rbActivo.Focus()
                '    Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtMesRegistro.Text)
                If cant < 2 Then
                    txtMesRegistro.Text = "0" & txtMesRegistro.Text
                End If
                If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                    MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                Else
                    ObtenerNumRegistro()
                End If
            Else
                MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumRegistro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumRegistro.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarRegistro.Enabled = True Then
                e.Handled = True
                btnBuscarRegistro_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtNumRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistro.Text)
                Do While cant < 6
                    txtNumRegistro.Text = "0" & txtNumRegistro.Text
                    cant = cant + 1
                Loop
                If oTesoreriaService.Buscar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text) Then
                    IdTesoreria = oTesoreriaService.ObtenerIdTesoreria(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text)
                    state_button = True 'Modificar
                    edicion = False
                    ObtenerRegistro()
                    actualizarDetalles()
                    Desactivar()
                    txtNumRegistro.SelectAll()
                Else
                    state_button = False 'Nuevo 
                    edicion = True
                    Limpiar()
                    Activar()
                    cmbCuentaBanco.Focus()
                End If
            Else
                MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
                txtNumRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtTipCambio.Focus()
        End If
    End Sub

    Private Sub txtTipCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipCambio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNombre.Focus()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtGlosa.Focus()
        End If
    End Sub

    Private Sub txtGlosa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oTesoreriaDetService.Mostrar(toNumber(IdTesoreria)).Tables(0)
            dgvDatos.DataSource = dtDatos

            enableOpciones()
            'dgvDatos.Select()
            If dgvDatos.RowCount > 0 Then
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
                'InhabilitarColumnas()
            Else
                txtDesCuenta.Text = ""
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidaCampos() Then
                Dim registro As New TesoreriaService.Tesoreria
                Dim CuentaContable As New TesoreriaService.CuentaContable
                Dim Moneda As New TesoreriaService.Moneda
                Dim Empresa As New TesoreriaService.Empresa
                Dim CuentaBanco As New TesoreriaService.CuentaBancos
                Dim Banco As New TesoreriaService.Banco

                registro.IdTesoreria = IdTesoreria
                registro.Mes = txtMesRegistro.Text
                registro.NumRegistro = txtNumRegistro.Text

                CuentaBanco.NumCta = cmbCuentaBanco.Value
                Banco.CodBan = CodBan
                CuentaBanco.Banco = Banco

                registro.CuentaBancos = CuentaBanco

                CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                CuentaContable.CodCuenta = txtCodCuenta.Text
                registro.CuentaContable = CuentaContable

                registro.Fecha = txtFecha.Value
                registro.TipCam = txtTipCambio.Value

                registro.Nombre = txtNombre.Text
                registro.Glosa = txtGlosa.Text

                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.Anulado = IIf(rbAnulado.Checked = True, True, False)

                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.Periodo = txtPeriodo.Value

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click        
        Limpiar()
        ObtenerNumRegistro()
        Desactivar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If ValidaBalanceAsiento() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If        
    End Sub

    Private Sub btnBuscarRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRegistro.Click
        Try
            Dim frm As New frmBuscarAsientos
            frm.txtMesRegistro.Text = txtMesRegistro.Text
            frm.txtPeriodo.Value = txtPeriodo.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.IdTesoreria) <> Nothing Then
                    IdTesoreria = frm.IdTesoreria
                    ObtenerRegistro()
                    actualizarDetalles()
                    state_button = True
                    edicion = False
                    Desactivar()
                Else
                    IdTesoreria = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Registro de Tesorería : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtNumRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistro.Click
        If ValidaBalanceAsiento() Then
            ObtenerNumRegistro()
            state_button = False
            Limpiar()
            Desactivar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If IdTesoreria = 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Nuevo()
        Try
            Dim frm As New frmAsientosDet
            frm.state_button = False
            frm.editable = True
            frm.edicion = True        
            frm.iEditable = oTesoreriaService.BuscarEditable(IdTesoreria)
            frm.IdTesoreria = IdTesoreria        
            frm.CodMon = cmbMoneda.Value
            frm.TipoCambio = txtTipCambio.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdTesoreriaDet)
                    Mostrar()
                    actualizarDetalles()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmAsientosDet
            frm.state_button = True
            frm.editable = True
            frm.edicion = False
            frm.iEditable = oTesoreriaService.BuscarEditable(IdTesoreria)
            frm.IdTesoreriaDet = dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Text
            frm.IdTesoreria = IdTesoreria           
            frm.CodMon = cmbMoneda.Value
            frm.TipoCambio = txtTipCambio.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then          
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    ObtenerRegistro()
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdTesoreriaDet)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            ObtenerRegistro()
            actualizarDetalles()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oTesoreriaDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Text), IdTesoreria, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    MsgBox("¡Se elimino correctamente el registro...!", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionadoDet() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.CurrentCellChanged
        If dgvDatos.RowCount > 0 Then
            If dgvDatos.Col = 10 Then
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("Nombre").Text)
            Else
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
            End If
        Else
            txtDesCuenta.Text = ""
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionadoDet() Then
            Mostrar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionadoDet() As Boolean
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

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        'If dgvDatos.RowCount > 0 Then
        '    If dgvDatos.CurrentColumn.Position = 11 Then
        '        txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
        '    End If
        'Else
        '    txtDesCuenta.Text = ""
        'End If
    End Sub

    Private Sub txtTotalDebeNS_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalDebeSol.ValueChanged, txtTotalHaberSol.ValueChanged
        txtDiferenciaSol.Value = txtTotalDebeSol.Value - txtTotalHaberSol.Value
    End Sub

    Private Sub txtTotalDebeUS_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalDebeDol.ValueChanged, txtTotalHaberDol.ValueChanged
        txtDiferenciaDol.Value = txtTotalDebeDol.Value - txtTotalHaberDol.Value
    End Sub

    Private Sub miDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDuplicar.Click
        If ValidaCodigoSeleccionadoDet() Then
            Duplicar()
        End If
    End Sub

    Private Sub Duplicar()
        Try
            Dim estado_process As Integer
            Dim IdTesoreiaDet As Integer
            estado_process = oTesoreriaDetService.Duplicar(toNumber(dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Value), IdTesoreria, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process > 0 Then
                IdTesoreiaDet = estado_process
                ObtenerRegistro()
                listaDatos()
                RowPossesion(dgvDatos, IdTesoreiaDet)
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DUPLICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarDetalle(ByVal registro As TesoreriaDetService.TesoreriaDet)
        Try
            Dim estado_process As Integer
            Dim IdTesoreriaDet As Integer
            estado_process = oTesoreriaDetService.Insertar(registro)
            If estado_process > 0 Then
                IdTesoreriaDet = estado_process
                ObtenerRegistro()
                listaDatos()
                RowPossesion(dgvDatos, IdTesoreriaDet)
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                    txtCodCuenta.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuenta.Text = registro.NomCuenta
                    txtFecha.Focus()
                End If
            Else
                txtFecha.Focus()
            End If
        End If
    End Sub

    Private Sub ObtenerCuenta()
        Try
            If Len(Trim(txtCodCuenta.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                    txtCodCuenta.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuenta.Text = registro.NomCuenta
                    txtFecha.Focus()
                End If
            Else
                'txtNumJob.Focus()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar Obtener Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtCodCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta.Validated
        ObtenerCuenta()
    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            frm.txtCodCuenta.Text = "10"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta.Text = frm.codigo
                    lblDesCuenta.Text = frm.descripcion                                        
                Else
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMesRegistro.Focus()
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

    Private Sub btnPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendientes.Click
        Try
            If toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
            Else
                Dim frm As New frmBuscarPendientes
                frm.txtCodCuenta.Text = "42"
                frm.txtMesRegistro.Text = txtMesRegistro.Text
                frm.txtPeriodo.Text = txtPeriodo.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim registro As New TesoreriaService.Tesoreria
                        Dim CuentaContable As New TesoreriaService.CuentaContable
                        Dim Moneda As New TesoreriaService.Moneda
                        Dim Empresa As New TesoreriaService.Empresa
                        Dim CuentaBanco As New TesoreriaService.CuentaBancos
                        Dim Banco As New TesoreriaService.Banco

                        registro.IdTesoreria = IdTesoreria
                        registro.Mes = txtMesRegistro.Text
                        registro.NumRegistro = txtNumRegistro.Text
                        CuentaBanco.NumCta = cmbCuentaBanco.Value
                        Banco.CodBan = CodBan 'cmbCuentaBanco.DropDownList.GetRow.Cells(3).Value
                        CuentaBanco.Banco = Banco
                        registro.CuentaBancos = CuentaBanco
                        CuentaContable.CodCuenta = txtCodCuenta.Text
                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        registro.CuentaContable = CuentaContable
                        registro.Fecha = txtFecha.Value
                        registro.TipCam = txtTipCambio.Value
                        registro.Nombre = frm.Nombre
                        registro.Glosa = txtGlosa.Text
                        Moneda.CodMon = cmbMoneda.Value
                        registro.Moneda = Moneda
                        registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                        Empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = Empresa
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.Periodo = txtPeriodo.Value

                        IdTesoreria = oTesoreriaService.InsertarPendiente(registro, frm.dtDetalles, frm.IdDocumento, frm.SerieDoc, frm.NumDoc)

                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdTesoreria = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Insertar Pendientes : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRendirFondos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRendirFondos.Click
        Try
            If toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
            Else
                Dim frm As New frmRendirFondos
                Dim Serie As String
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim registro As New TesoreriaService.Tesoreria
                        Dim CuentaContable As New TesoreriaService.CuentaContable
                        Dim Moneda As New TesoreriaService.Moneda
                        Dim Empresa As New TesoreriaService.Empresa
                        Dim CuentaBanco As New TesoreriaService.CuentaBancos
                        Dim Banco As New TesoreriaService.Banco
                        Dim IdCuentaTes As Integer = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, frm.CodCuenta)
                        Serie = frm.SerDoc
                        registro.IdTesoreria = IdTesoreria
                        registro.Mes = txtMesRegistro.Text
                        registro.NumRegistro = txtNumRegistro.Text
                        CuentaBanco.NumCta = cmbCuentaBanco.Value
                        Banco.CodBan = CodBan 'cmbCuentaBanco.DropDownList.GetRow.Cells(3).Value
                        CuentaBanco.Banco = Banco
                        registro.CuentaBancos = CuentaBanco
                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        CuentaContable.CodCuenta = txtCodCuenta.Text
                        registro.CuentaContable = CuentaContable
                        registro.Fecha = txtFecha.Value
                        registro.TipCam = txtTipCambio.Value
                        registro.Nombre = frm.Nombre
                        registro.Glosa = frm.Glosa
                        Moneda.CodMon = cmbMoneda.Value
                        registro.Moneda = Moneda
                        registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                        Empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = Empresa
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.Periodo = txtPeriodo.Value

                        IdTesoreria = oTesoreriaService.RendirGasto(registro, frm.IdTesoreriaDet, frm.IdGasto, IdCuentaTes, frm.IdDocumento, frm.SerDoc, frm.NumDoc, frm.IdPerSolicita, frm.MontoOriginal)

                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdTesoreria = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Rendir Fondos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaBalanceAsiento() As Boolean
        Try
            If txtDiferenciaSol.Value <> 0 And txtDiferenciaDol.Value <> 0 Then
                'MsgBox("¡El Registro no se encuentra balanceado, verificar...!".ToUpper, MsgBoxStyle.Information, "Información")
                Dim frm As New frmMsgBox
                frm.lblMensaje.Text = "¡El Registro no se encuentra balanceado, verificar...!"
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR BALANCE DE ASIENTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub cmbCuentaBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCuentaBanco.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtCodCuenta.Focus()
        End If
    End Sub

    Private Sub ObtenerCuentaBanco()
        If cmbCuentaBanco.SelectedIndex <> 0 Then
            lblDesCtaBanco.Text = cmbCuentaBanco.DropDownList.CurrentRow.Cells(1).Text '& "  " & cmbCuentaBanco.DropDownList.CurrentRow.Cells(2).Text
            txtCodCuenta.Text = cmbCuentaBanco.DropDownList.CurrentRow.Cells(4).Text
            CodBan = cmbCuentaBanco.DropDownList.CurrentRow.Cells(3).Value
            cmbMoneda.Value = cmbCuentaBanco.DropDownList.CurrentRow.Cells(2).Value
        Else
            lblDesCtaBanco.Text = ""
            txtCodCuenta.Text = ""
            CodBan = ""
            cmbMoneda.Value = "NS"
        End If
    End Sub

    Private Sub cmbCuentaBanco_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuentaBanco.ValueChanged
        'If state_button = False Then
        ObtenerCuentaBanco()
        ObtenerCuenta()
        'End If
    End Sub

    Private Sub btnProvisional_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProvisional.Click
        Try
            If toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()          
            Else
                Dim frm As New frmProvisionalRendFondos                
                frm.CodMon = cmbMoneda.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim registro As New TesoreriaService.Tesoreria
                        Dim CuentaContable As New TesoreriaService.CuentaContable
                        Dim Moneda As New TesoreriaService.Moneda
                        Dim Empresa As New TesoreriaService.Empresa
                        Dim CuentaBanco As New TesoreriaService.CuentaBancos
                        Dim Banco As New TesoreriaService.Banco

                        registro.IdTesoreria = IdTesoreria
                        registro.Mes = txtMesRegistro.Text
                        registro.NumRegistro = txtNumRegistro.Text
                        CuentaBanco.NumCta = cmbCuentaBanco.Value
                        Banco.CodBan = CodBan 'cmbCuentaBanco.DropDownList.GetRow.Cells(3).Value
                        CuentaBanco.Banco = Banco
                        registro.CuentaBancos = CuentaBanco
                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        CuentaContable.CodCuenta = txtCodCuenta.Text
                        registro.CuentaContable = CuentaContable
                        registro.Fecha = txtFecha.Value
                        registro.TipCam = txtTipCambio.Value
                        registro.Nombre = frm.Nombre
                        registro.Glosa = txtGlosa.Text
                        Moneda.CodMon = frm.CodMon
                        registro.Moneda = Moneda
                        registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                        Empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = Empresa
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.Periodo = txtPeriodo.Value


                        IdTesoreria = oTesoreriaService.InsertarProvisional(registro, frm.IdDocumento, frm.SerieDoc, frm.NumDoc, frm.IdProvisional)

                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdTesoreria = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Rendir Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnReembolso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReembolso.Click
        Try
            If toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
            Else
                Dim frm As New frmReembolsoRendFondos
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim registro As New TesoreriaService.Tesoreria
                        Dim CuentaContable As New TesoreriaService.CuentaContable
                        Dim Moneda As New TesoreriaService.Moneda
                        Dim Empresa As New TesoreriaService.Empresa
                        Dim CuentaBanco As New TesoreriaService.CuentaBancos
                        Dim Banco As New TesoreriaService.Banco
          
                        registro.IdTesoreria = IdTesoreria
                        registro.Mes = txtMesRegistro.Text
                        registro.NumRegistro = txtNumRegistro.Text
                        CuentaBanco.NumCta = cmbCuentaBanco.Value
                        Banco.CodBan = CodBan 'cmbCuentaBanco.DropDownList.GetRow.Cells(3).Value
                        CuentaBanco.Banco = Banco
                        registro.CuentaBancos = CuentaBanco
                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        CuentaContable.CodCuenta = txtCodCuenta.Text
                        registro.CuentaContable = CuentaContable
                        registro.Fecha = txtFecha.Value
                        registro.TipCam = txtTipCambio.Value
                        registro.Nombre = frm.Nombre
                        registro.Glosa = frm.Glosa
                        Moneda.CodMon = cmbMoneda.Value
                        registro.Moneda = Moneda
                        registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                        Empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = Empresa
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.Periodo = txtPeriodo.Value

                        IdTesoreria = oTesoreriaService.RendirReembolso(registro, frm.IdTesoreriaDet, frm.IdReembolso, frm.IdCuenta, frm.IdDocumento, frm.SerDoc, frm.NumDoc, frm.IdPersona, frm.MontoOriginal)

                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdTesoreria = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Rendir Reembolso : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtMesRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Validated
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtMesRegistro.Text)
            If cant < 2 Then
                txtMesRegistro.Text = "0" & txtMesRegistro.Text
            End If
            If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
            Else
                ObtenerNumRegistro()
            End If
        Else
            MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        If toBlank(txtFecha.Text) <> "" Then
            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Value)), "#0.000")
        End If
    End Sub

    'Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        biGuardar.Select()
    '    End If
    'End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            'If oTesoreriaService.BuscarCheque(IdTesoreria) = True Then
            'If IdTesoreria <> 0 Then
            Dim frm As New frmAsientos_Imprimir
            frm.IdTesoreria = IdTesoreria
            frm.CodMon = cmbMoneda.Value
            frm.ShowDialog()
            'End If
            'Else
            'Dim forma As New frmReportes
            'Dim dtReporte As New DataTable
            'Dim reporte As New rptAsiento

            'If IdTesoreria <> 0 Then
            '    dtReporte = oTesoreriaService.Imprimir(IdTesoreria).Tables(0)

            '    If dtReporte.Rows.Count = 0 Then
            '        MsgBox("No hay datos a mostrar")
            '    Else
            '        reporte.SetDataSource(dtReporte)
            '        forma.crvReportes.ReportSource = reporte
            '        forma.crvReportes.DisplayGroupTree = False
            '        'reporte.SetParameterValue("pIdMesa", 0)
            '        forma.Text = "Reporte de Asiento"
            '        forma.ShowDialog()
            '    End If
            'Else
            '    MsgBox("Número de Asiento Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            'End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub biImportarPlanillasCobranzas_Click(sender As Object, e As EventArgs) Handles biImportarPlanillasCobranzas.Click
        Try
            If ValidaCamposImportarPlanilla() Then
                Dim frm As New frmImportarPlanillaCobranzas

                frm.MesRegistro = txtMesRegistro.Text
                frm.NumRegistro = txtNumRegistro.Text

                frm.NumCta = cmbCuentaBanco.Value
                frm.CodBan = CodBan

                frm.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                frm.CodCuenta = txtCodCuenta.Text

                frm.Fecha = txtFecha.Value
                frm.TipCam = txtTipCambio.Value

                frm.Nombre = txtNombre.Text
                frm.Glosa = txtGlosa.Text

                frm.CodMon = cmbMoneda.Value
                frm.Anulado = IIf(rbAnulado.Checked = True, True, False)
                frm.Periodo = txtPeriodo.Value

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    If toNull(frm.IdTesoreriaDet) <> Nothing Then
                        IdTesoreria = frm.IdTesoreriaDet
                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdTesoreria = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR la(s) planilla(s) de cobranza(s) : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCamposImportarPlanilla() As Boolean
        Try
            If toNumber(txtMesRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el número de Comprobante.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toNumber(txtNumRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el número de Comprobante.", MsgBoxStyle.Information, "Información")
                txtNumRegistro.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toDouble(txtTipCambio.Value) <= 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
                Return False
            ElseIf toBlank(txtNombre.Text) = "" Then
                MsgBox("Debe Ingresar el Nombre.", MsgBoxStyle.Information, "Información")
                txtNombre.Focus()
                Return False
                'ElseIf toBlank(txtGlosa.Text) = "" Then
                '    MsgBox("Debe Ingresar la Glosa.", MsgBoxStyle.Information, "Información")
                '    txtGlosa.Focus()
                '    Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'ElseIf rbActivo.Checked = False And rbAnulado.Checked = False Then
                '    MsgBox("Debe Ingresar el Estado.", MsgBoxStyle.Information, "Información")
                '    rbActivo.Focus()
                '    Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biArchivo_Click(sender As Object, e As EventArgs) Handles biArchivo.Click       
        Try
            Dim frm As New frmAsientos_GenerarArchivo         
            frm.IdTesoreria = IdTesoreria
            frm.CodBan = CodBan
            frm.DesBanco = lblDesCtaBanco.Text
            frm.CuentaBanco = cmbCuentaBanco.Value
            frm.cbFecha.Value = txtFecha.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
                actualizarDetalles()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miInsertarPendiente_Click(sender As Object, e As EventArgs) Handles miInsertarPendiente.Click
        Try
            If toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
            Else
                Dim frm As New frmBuscarPendientes
                frm.txtCodCuenta.Text = "42"
                frm.txtMesRegistro.Text = txtMesRegistro.Text
                frm.txtPeriodo.Text = txtPeriodo.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim registro As New TesoreriaService.Tesoreria
                        Dim CuentaContable As New TesoreriaService.CuentaContable
                        Dim Moneda As New TesoreriaService.Moneda
                        Dim Empresa As New TesoreriaService.Empresa
                        Dim CuentaBanco As New TesoreriaService.CuentaBancos
                        Dim Banco As New TesoreriaService.Banco

                        registro.IdTesoreria = IdTesoreria
                        registro.Mes = txtMesRegistro.Text
                        registro.NumRegistro = txtNumRegistro.Text
                        CuentaBanco.NumCta = cmbCuentaBanco.Value
                        Banco.CodBan = CodBan 'cmbCuentaBanco.DropDownList.GetRow.Cells(3).Value
                        CuentaBanco.Banco = Banco
                        registro.CuentaBancos = CuentaBanco
                        CuentaContable.CodCuenta = txtCodCuenta.Text
                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        registro.CuentaContable = CuentaContable
                        registro.Fecha = txtFecha.Value
                        registro.TipCam = txtTipCambio.Value
                        registro.Nombre = frm.Nombre
                        registro.Glosa = txtGlosa.Text
                        Moneda.CodMon = cmbMoneda.Value
                        registro.Moneda = Moneda
                        registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                        Empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = Empresa
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.Periodo = txtPeriodo.Value

                        IdTesoreria = oTesoreriaService.InsertarPendiente(registro, frm.dtDetalles, frm.IdDocumento, frm.SerieDoc, frm.NumDoc)

                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Insertar Pendientes : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miInsertarPendienteMasivo_Click(sender As Object, e As EventArgs) Handles miInsertarPendienteMasivo.Click
        Try
            If toBlank(cmbCuentaBanco.Value) = "" Then
                MsgBox("Debe Ingresar la Cuenta Banco.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
            Else
                Dim frm As New frmBuscarPendientesMasivo
                frm.txtCodCuenta.Text = "42"
                frm.txtMesRegistro.Text = txtMesRegistro.Text
                frm.txtPeriodo.Text = txtPeriodo.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim registro As New TesoreriaService.Tesoreria
                        Dim CuentaContable As New TesoreriaService.CuentaContable
                        Dim Moneda As New TesoreriaService.Moneda
                        Dim Empresa As New TesoreriaService.Empresa
                        Dim CuentaBanco As New TesoreriaService.CuentaBancos
                        Dim Banco As New TesoreriaService.Banco

                        registro.IdTesoreria = IdTesoreria
                        registro.Mes = txtMesRegistro.Text
                        registro.NumRegistro = txtNumRegistro.Text
                        CuentaBanco.NumCta = cmbCuentaBanco.Value
                        Banco.CodBan = CodBan 'cmbCuentaBanco.DropDownList.GetRow.Cells(3).Value
                        CuentaBanco.Banco = Banco
                        registro.CuentaBancos = CuentaBanco
                        CuentaContable.CodCuenta = txtCodCuenta.Text
                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        registro.CuentaContable = CuentaContable
                        registro.Fecha = txtFecha.Value
                        registro.TipCam = txtTipCambio.Value
                        registro.Nombre = frm.Nombre
                        registro.Glosa = txtGlosa.Text
                        Moneda.CodMon = cmbMoneda.Value
                        registro.Moneda = Moneda
                        registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                        Empresa.CodEmp = Session.sCodEmp
                        registro.Empresa = Empresa
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.Periodo = txtPeriodo.Value

                        IdTesoreria = oTesoreriaService.InsertarPendiente(registro, frm.dtDetalles, frm.IdDocumento, frm.SerieDoc, frm.NumDoc)

                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Insertar Pendientes : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbMoneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub

End Class