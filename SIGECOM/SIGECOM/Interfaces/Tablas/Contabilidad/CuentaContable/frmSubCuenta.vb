Imports System.ServiceModel
Public Class frmSubCuenta

    '===========================Servicios====================================================
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdSubCuenta As String
    Public IdCuentaMayor As Integer


    '=============================Evento Load==================================
    Private Sub frmCuentaMayor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtDescripcion.Select()
        Else                          'Nuevo
            cbActivo.Checked = True
            desactivar()
            txtCodSubCuenta.Select()
        End If
        'estado = oOrdenesCompraService.ObtenerEstado(IdOrden)
        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmCuentaMayor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                        txtCodSubCuenta.KeyPress, _
    '                        cbActivo.KeyPress, _
    '                        txtDescripcion.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub Finalizar()
        Try
            oCuentaContableService.Close()
        Catch ex As TimeoutException
            oCuentaContableService.Abort()
        Catch ex As CommunicationException
            oCuentaContableService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodSubCuenta.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Sub Cuenta. ", MsgBoxStyle.Information, "Información")
                txtCodSubCuenta.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la descripción de la Sub Cuenta.", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        'If estado = 1 Then
        activar()
        btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub
    Private Sub activar()
        If state_button Then
            '    'If estado <> 1 Then
            '    desactivar()
            'Else

            txtCodSubCuenta.ReadOnly = True
            txtCodSubCuenta.BackColor = System.Drawing.SystemColors.Control
            cbActivo.Enabled = True
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window

            'End If
        Else

            txtCodSubCuenta.ReadOnly = False
            txtCodSubCuenta.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window

        End If
    End Sub

    Private Sub desactivar()

        txtCodSubCuenta.ReadOnly = True
        txtCodSubCuenta.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub Insertar(ByVal registro As CuentaContableService.SubCuentaContable)
        Try
            Dim estado_process As Integer
            estado_process = oCuentaContableService.InsertarSubCuenta(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdSubCuenta = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR SUB CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CuentaContableService.SubCuentaContable)
        Try
            Dim estado_process As Boolean
            estado_process = oCuentaContableService.ActualizarSubCuenta(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR SUB CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CuentaContableService.SubCuentaContable
            registro = oCuentaContableService.ObtenerSubCuenta(IdSubCuenta)

            IdCuentaMayor = registro.MayorCuentaContable.IdCuentaMayor
            IdSubCuenta = registro.IdSubCuenta

            txtCodSubCuenta.Text = registro.CodSubCuenta
            cbActivo.Checked = registro.Activo
            txtDescripcion.Text = registro.NomSubCuenta

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER SUB CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub llenarCombos()
        Try


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

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New CuentaContableService.SubCuentaContable
            Dim CuentaMayor As New CuentaContableService.MayorCuentaContable

            registro.IdSubCuenta = IdSubCuenta
            registro.CodSubCuenta = txtCodSubCuenta.Text

            CuentaMayor.IdCuentaMayor = IdCuentaMayor
            registro.MayorCuentaContable = CuentaMayor

            registro.Activo = cbActivo.Checked
            registro.NomSubCuenta = txtDescripcion.Text

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub txtCodSubCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSubCuenta.KeyPress
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