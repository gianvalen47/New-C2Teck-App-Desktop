Imports System.ServiceModel
Public Class frmCuentaContable

    '===========================Servicios====================================================
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete    
    Public IdCuenta As Integer
    Public IdSubCuenta As Integer
    Private dtAreas As DataTable

    '=============================Evento Load==================================
    Private Sub frmCtaContable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            cmbArea.Select()
        Else                          'Nuevo
            rbDeudora.Checked = True
            cbActivo.Checked = True
            cbDetalle.Checked = False
            cbAjusteDifCam.Checked = False
            desactivar()
            txtCodCuenta.Select()
        End If
        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmComOrdenCompraDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                       txtCodCuenta.KeyPress, _
    '                       txtDescripcion.KeyPress, _
    '                       cmbArea.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Sub Finalizar()
        Try
            oCuentaContableService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oCuentaContableService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oCuentaContableService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el código de la Cuenta Contable. ", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
                Return False
                'ElseIf toBlank(cmbArea.Value) = "" Then
                '    MsgBox("Debe Ingresar el Área.", MsgBoxStyle.Information, "Información")
                '    cmbArea.Focus()
                '    Return False
            ElseIf toBlank(txtNomCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Nombre de la Cuenta.", MsgBoxStyle.Information, "Información")
                txtNomCuenta.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        'If state_button = False Then ' estado = 1 Then
        activar()
        btnGuardar.Enabled = True
        'Else
        'btnGuardar.Enabled = False
        'desactivar()
        'End If
    End Sub

    Private Sub activar()
        If state_button Then
            txtCodCuenta.ReadOnly = True
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
            cmbArea.ReadOnly = False
            cmbArea.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            cbDetalle.Enabled = True
            cbAjusteDifCam.Enabled = True
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Else
            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            cmbArea.ReadOnly = False
            cmbArea.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            cbDetalle.Enabled = True
            cbAjusteDifCam.Enabled = True
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        txtCodCuenta.ReadOnly = True
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
        cmbArea.ReadOnly = True
        cmbArea.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        cbDetalle.Enabled = False
        cbAjusteDifCam.Enabled = False
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As CuentaContableService.CuentaContable)
        Try
            Dim estado_process As Integer
            estado_process = oCuentaContableService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCuenta = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CUENTA CONTABLE CONTABLE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CuentaContableService.CuentaContable)
        Try
            Dim estado_process As Boolean
            estado_process = oCuentaContableService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'IdCuenta = txtCodCuenta.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CUENTA CONTABLE CONTABLE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CuentaContableService.CuentaContable
            registro = oCuentaContableService.Obtener(IdCuenta)

            IdCuenta = registro.IdCuenta
            txtCodCuenta.Text = registro.CodCuenta
            IdSubCuenta = registro.IdSubCuenta
            If registro.Area.CodArea = Nothing Then
                cmbArea.SelectedIndex = 0
            Else
                cmbArea.Value = registro.Area.CodArea
            End If

            If registro.Naturaleza = 1 Then
                rbDeudora.Checked = True
            ElseIf registro.Naturaleza = 2 Then
                rbAcreedora.Checked = True
            End If

            cbActivo.Checked = registro.Activo
            cbDetalle.Checked = registro.ConDetalle
            cbAjusteDifCam.Checked = registro.AjusteDifCam
            txtNomCuenta.Text = registro.NomCuenta
            txtDescripcion.Text = registro.Descripcion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Dim registro As New CuentaContableService.CuentaContable
            'Dim SubCuenta As New CuentaContableService.SubCuentaContable
            Dim Area As New CuentaContableService.Area

            registro.IdCuenta = IdCuenta
            registro.CodCuenta = txtCodCuenta.Text

            'SubCuenta.IdSubCuenta = IdSubCuenta
            'registro.SubCuentaContable = SubCuenta
            registro.IdSubCuenta = IdSubCuenta

            Area.CodArea = IIf(cmbArea.SelectedIndex = 0, Nothing, cmbArea.Value)
            registro.Area = Area

            registro.Naturaleza = IIf(rbDeudora.Checked = True, 1, 2)

            registro.NomCuenta = txtNomCuenta.Text
            registro.Descripcion = txtDescripcion.Text
            registro.Activo = cbActivo.Checked
            registro.ConDetalle = cbDetalle.Checked
            registro.AjusteDifCam = cbAjusteDifCam.Checked

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub txtCodCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbArea.Focus()
        End If
    End Sub
    Private Sub cmbArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbArea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            rbDeudora.Focus()
        End If
    End Sub
    Private Sub rbDeudora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbDeudora.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            rbAcreedora.Focus()
        End If
    End Sub
    Private Sub rbAcreedora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbAcreedora.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbActivo.Focus()
        End If
    End Sub
    Private Sub cbActivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbActivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbDetalle.Focus()
        End If
    End Sub
    Private Sub cbDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbDetalle.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbAjusteDifCam.Focus()
        End If
    End Sub
    Private Sub cbAjusteDifCam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAjusteDifCam.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNomCuenta.Focus()
        End If
    End Sub
    Private Sub txtNomCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNomCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtDescripcion.Focus()
        End If
    End Sub
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class