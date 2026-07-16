Imports System.ServiceModel
Public Class frmAsignacionRecurso_Detalle

    '=========================== Servicios ====================================
    Private oRecursoService As New RecursoService.RecursoServiceClient
    Private oRecursoDetService As New RecursoDetService.RecursoDetServiceClient

    '====================== Declaración de Variables ==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Private dtDatos As DataTable
    Public IdRecursoDet As Integer
    Public IdRecurso As Integer
    Public iEstado As String
    Private dtEmpCom As DataTable
    Public IdRubro As Integer                   'IdRubro de cabecera de Recurso

    Private Sub frmAsignacionRecurso_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAsignacionRecurso_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            If IdRubro = 2 Then
                gbDetalle.Size = New System.Drawing.Size(552, 276)
                gbComunicaciones.Visible = True
                gbDatosDevolucion.Location = New System.Drawing.Point(8, 285)
                btnGuardar.Location = New System.Drawing.Point(187, 331)
                btnCancelar.Location = New System.Drawing.Point(271, 331)
                Me.Size = New System.Drawing.Size(580, 395)
            Else
                gbDetalle.Size = New System.Drawing.Size(552, 191)
                gbComunicaciones.Visible = False
                gbDatosDevolucion.Location = New System.Drawing.Point(8, 200)
                btnGuardar.Location = New System.Drawing.Point(187, 246)
                btnCancelar.Location = New System.Drawing.Point(271, 246)
                Me.Size = New System.Drawing.Size(580, 312)
            End If
            ObtenerRegistro()
            desactivar()
            txtCodigo.Focus()
            gbDatosDevolucion.Visible = True
        Else                                      'Nuevo
            If IdRubro = 2 Then
                gbDetalle.Size = New System.Drawing.Size(552, 276)
                gbComunicaciones.Visible = True
                btnGuardar.Location = New System.Drawing.Point(187, 288)
                btnCancelar.Location = New System.Drawing.Point(271, 288)
                Me.Size = New System.Drawing.Size(580, 354)
            Else
                gbDetalle.Size = New System.Drawing.Size(552, 193)
                gbComunicaciones.Visible = False
                btnGuardar.Location = New System.Drawing.Point(187, 208)
                btnCancelar.Location = New System.Drawing.Point(271, 208)
                Me.Size = New System.Drawing.Size(580, 274)
            End If
            gbDatosDevolucion.Visible = False
            activar()
            txtCodigo.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmAsignacionRecurso_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oRecursoService.Close()
            oRecursoDetService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
            oRecursoDetService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
            oRecursoDetService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtCantidad.Value) = 0 Then
                MsgBox("Debe ingresar la cantidad.", MsgBoxStyle.Information, "Información")
                txtCantidad.Focus()
            ElseIf cbUsoPersonal.Checked = False And txtDesOtroUso.Text = "" Then
                MsgBox("Debe ingresar el Tipo de hora extra.", MsgBoxStyle.Information, "Información")
                txtDesOtroUso.Focus()
                Return False
                'ElseIf toNumber(txtCanHoras.Value) = 0 Then
                '    MsgBox("Debe Ingresar la Cantidad de Horas Extras.", MsgBoxStyle.Information, "Información")
                '    txtCanHoras.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        If iEstado = "GN" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        txtCantidad.ReadOnly = False
        txtCantidad.BackColor = System.Drawing.SystemColors.Window
        txtCodigo.ReadOnly = False
        txtCodigo.BackColor = System.Drawing.SystemColors.Window
        txtSerie.ReadOnly = False
        txtSerie.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        txtTalla.ReadOnly = False
        txtTalla.BackColor = System.Drawing.SystemColors.Window
        txtModelo.ReadOnly = False
        txtModelo.BackColor = System.Drawing.SystemColors.Window
        txtMarca.ReadOnly = False
        txtMarca.BackColor = System.Drawing.SystemColors.Window
        cbUsoPersonal.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        If IdRubro = 2 Then
            cmbEmpCom.ReadOnly = False
            cmbEmpCom.BackColor = System.Drawing.SystemColors.Window
            txtDesPlan.ReadOnly = False
            txtDesPlan.BackColor = System.Drawing.SystemColors.Window
            txtNumCelular.ReadOnly = False
            txtNumCelular.BackColor = System.Drawing.SystemColors.Window
            txtNumRadio.ReadOnly = False
            txtNumRadio.BackColor = System.Drawing.SystemColors.Window
        Else
            cmbEmpCom.ReadOnly = True
            cmbEmpCom.BackColor = System.Drawing.SystemColors.Control
            txtDesPlan.ReadOnly = True
            txtDesPlan.BackColor = System.Drawing.SystemColors.Control
            txtNumCelular.ReadOnly = True
            txtNumCelular.BackColor = System.Drawing.SystemColors.Control
            txtNumRadio.ReadOnly = True
            txtNumRadio.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub desactivar()
        If iEstado = "GN" Then
            activar()
        Else
            txtCantidad.ReadOnly = True
            txtCantidad.BackColor = System.Drawing.SystemColors.Control
            txtCodigo.ReadOnly = True
            txtCodigo.BackColor = System.Drawing.SystemColors.Control
            txtSerie.ReadOnly = True
            txtSerie.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
            txtTalla.ReadOnly = True
            txtTalla.BackColor = System.Drawing.SystemColors.Control
            txtModelo.ReadOnly = True
            txtModelo.BackColor = System.Drawing.SystemColors.Control
            txtMarca.ReadOnly = True
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            cbUsoPersonal.Enabled = False
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            cmbEmpCom.ReadOnly = True
            cmbEmpCom.BackColor = System.Drawing.SystemColors.Control
            txtDesPlan.ReadOnly = True
            txtDesPlan.BackColor = System.Drawing.SystemColors.Control
            txtNumCelular.ReadOnly = False
            txtNumCelular.BackColor = System.Drawing.SystemColors.Control
            txtNumRadio.ReadOnly = True
            txtNumRadio.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub Insertar(ByVal registro As RecursoDetService.RecursoDet)
        Try
            Dim estado_process As Integer
            estado_process = oRecursoDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdRecursoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RecursoDetService.RecursoDet)
        Try
            Dim estado_process As Boolean
            estado_process = oRecursoDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As RecursoDetService.RecursoDet
            registro = oRecursoDetService.Obtener(IdRecursoDet)

            IdRecursoDet = registro.IdRecursoDet
            IdRecurso = registro.Recurso.IdRecurso
            txtCantidad.Value = registro.Cantidad
            txtCodigo.Text = registro.Codigo
            txtSerie.Text = registro.Serie
            txtDescripcion.Text = registro.Descripcion
            txtTalla.Text = registro.Talla
            txtModelo.Text = registro.Modelo
            txtMarca.Text = registro.Marca
            cbUsoPersonal.Checked = registro.UsoPersonal
            txtDesOtroUso.Text = registro.DesOtroUso
            txtObservacion.Text = registro.Observacion

            If IdRubro = 2 Then
                cmbEmpCom.Value = registro.EmpresaComunicacion.IdEmpresa
                txtDesPlan.Text = registro.DesPlan
                txtNumCelular.Text = registro.NumCelular
                txtNumRadio.Text = registro.NumRadio
            End If

            cbDevuelto.Checked = registro.Devuelto
            If registro.FecDevuelto.ToString <> "" Then
                txtFecDevuelto.Value = registro.FecDevuelto
                txtFecDevuelto.Text = registro.FecDevuelto.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '================================== EMP. COMUNICACIÓN =====================================
            dtEmpCom = oRecursoDetService.MostrarEmpresaComunicacion().Tables(0)
            cmbEmpCom.DataSource = dtEmpCom
            cmbEmpCom.DropDownList.DataMember = dtEmpCom.Columns("DesEmpresa").ToString
            cmbEmpCom.DropDownList.DisplayMember = dtEmpCom.Columns("DesEmpresa").ToString
            cmbEmpCom.DropDownList.ValueMember = dtEmpCom.Columns("IdEmpresa").ToString
            cmbEmpCom.DropDownList.Columns(0).DataMember = dtEmpCom.Columns("IdEmpresa").ToString
            cmbEmpCom.DropDownList.Columns(1).DataMember = dtEmpCom.Columns("DesEmpresa").ToString
            cmbEmpCom.SelectedIndex = 0
            dtEmpCom = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Dim registro As New RecursoDetService.RecursoDet
            Dim Recurso As New RecursoDetService.Recurso
            Dim EmpCom As New RecursoDetService.EmpresaComunicacion

            registro.IdRecursoDet = IdRecursoDet
            Recurso.IdRecurso = IdRecurso
            registro.Recurso = Recurso
            registro.Cantidad = txtCantidad.Value
            registro.Codigo = IIf(txtCodigo.Text = "", Nothing, txtCodigo.Text)
            registro.Serie = IIf(txtSerie.Text = "", Nothing, txtSerie.Text)
            registro.Descripcion = IIf(txtDescripcion.Text = "", Nothing, txtDescripcion.Text)
            registro.Talla = IIf(txtTalla.Text = "", Nothing, txtTalla.Text)
            registro.Modelo = IIf(txtModelo.Text = "", Nothing, txtModelo.Text)
            registro.Marca = IIf(txtMarca.Text = "", Nothing, txtMarca.Text)
            registro.UsoPersonal = cbUsoPersonal.Checked
            registro.DesOtroUso = IIf(txtDesOtroUso.Text = "", Nothing, txtDesOtroUso.Text)
            registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)

            EmpCom.IdEmpresa = IIf(IdRubro = 2, cmbEmpCom.Value, Nothing)
            registro.EmpresaComunicacion = EmpCom
            registro.DesPlan = IIf(IdRubro = 2, txtDesPlan.Text, Nothing)
            registro.NumCelular = IIf(IdRubro = 2, txtNumCelular.Text, Nothing)
            registro.NumRadio = IIf(IdRubro = 2, txtNumRadio.Text, Nothing)

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                registro.FecReg = Today
                Insertar(registro)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtCantidad.KeyPress _
                           , txtCodigo.KeyPress _
                           , txtSerie.KeyPress _
                           , txtTalla.KeyPress _
                           , txtModelo.KeyPress _
                           , txtMarca.KeyPress _
                           , cbUsoPersonal.KeyPress _
                           , txtDesOtroUso.KeyPress _
                           , cmbEmpCom.KeyPress _
                           , txtDesPlan.KeyPress _
                           , txtNumCelular.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If IdRubro = 2 Then
                SendKeys.Send("{TAB}")
            Else
                btnGuardar.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumRadio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRadio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub cbUsoPersonal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUsoPersonal.CheckedChanged
        If cbUsoPersonal.Checked = True Then
            txtDesOtroUso.ReadOnly = True
            txtDesOtroUso.BackColor = System.Drawing.SystemColors.Control
        ElseIf cbUsoPersonal.Checked = False And (iEstado = "GN" Or state_button = False) Then
            txtDesOtroUso.ReadOnly = False
            txtDesOtroUso.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub btnBuscarActivo_Click(sender As Object, e As EventArgs) Handles btnBuscarActivo.Click

        Try

            Dim frm As New frmAsignacionRecurso_BuscarActivo

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                txtCodigo.Text = frm.CodActivo
                txtDescripcion.Text = frm.DesActivo
                txtSerie.Text = frm.Serie
                txtMarca.Text = frm.Marca
                txtModelo.Text = frm.Modelo

            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class