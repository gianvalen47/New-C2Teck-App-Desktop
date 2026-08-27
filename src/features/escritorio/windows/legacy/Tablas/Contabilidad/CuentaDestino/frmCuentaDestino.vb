Imports System.ServiceModel
Public Class frmCuentaDestino

    '===========================Servicios====================================================
    Dim oCuentaContableService As New CuentaContableService.CuentaContableServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdCuenta As Integer
    Public IdCuentaDest As Integer

    Private Sub frmCuentaDestino_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "CUENTA DESTINO"
        Else                          'Nuevo
            Me.Text = "Registrar nueva Cuenta Destino"
            activar()
            cbActivo.Checked = True
            lblDesCuenta.Text = ""
            lblDesCuentaDest.Text = ""
            lblDesCuentaTrans.Text = ""
        End If
        enableOpciones()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCuentaDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAportacionCuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCuentaContableService.Close()
        Catch ex As TimeoutException
            oCuentaContableService.Abort()
        Catch ex As CommunicationException
            oCuentaContableService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub enableOpciones()
        If state_button = False Then
            activar()
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = True
            desactivar()
        End If
    End Sub

    Private Sub activar()        
        txtCodCuenta.ReadOnly = False
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuenta.Enabled = True
        txtCodCuentaDest.ReadOnly = False
        txtCodCuentaDest.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuentaDest.Enabled = True
        txtCodCuentaTrans.ReadOnly = False
        txtCodCuentaTrans.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuentaTrans.Enabled = True

        txtPorcentaje.ReadOnly = False
        txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True

        txtCodCuenta.Focus()
    End Sub

    Private Sub desactivar()
        txtCodCuenta.ReadOnly = True
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCuenta.Enabled = False
        txtCodCuentaDest.ReadOnly = True
        txtCodCuentaDest.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCuentaDest.Enabled = False
        txtCodCuentaTrans.ReadOnly = False
        txtCodCuentaTrans.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuentaTrans.Enabled = True

        txtPorcentaje.ReadOnly = False
        txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True

        txtCodCuentaTrans.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtCodCuenta.Text = "" Then
                MsgBox("Debe Ingresar la Cuenta Contable.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
                Return False
            ElseIf txtCodCuentaDest.Text = "" Then
                MsgBox("Debe Ingresar la Cuenta Contable Destino.", MsgBoxStyle.Information, "Información")
                txtCodCuentaDest.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaDest.Text)) Then
                MsgBox("Código de Cuenta Destino incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuentaDest.Text = ""
                txtCodCuentaDest.Focus()
                Return False
            ElseIf txtCodCuentaTrans.Text = "" Then
                MsgBox("Debe Ingresar la Cuenta Contable Transferencia.", MsgBoxStyle.Information, "Información")
                txtCodCuentaTrans.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaTrans.Text)) Then
                MsgBox("Código de Cuenta Transferencia incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuentaTrans.Text = ""
                txtCodCuentaTrans.Focus()
                Return False
            ElseIf toDouble(txtPorcentaje.Value) = 0 Then
                MsgBox("Debe Ingresar el porcentaje.", MsgBoxStyle.Information, "Información")
                txtPorcentaje.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CuentaContableService.CuentaDestino
            registro = oCuentaContableService.ObtenerCuentaDestino(IdCuenta, IdCuentaDest)

            IdCuenta = registro.CuentaContable.IdCuenta
            IdCuentaDest = registro.CuentaContableDest.IdCuenta

            lblDesCuenta.Text = Trim(registro.CuentaContable.NomCuenta)
            txtCodCuenta.Text = toNull(registro.CuentaContable.CodCuenta)

            lblDesCuentaDest.Text = Trim(registro.CuentaContableDest.NomCuenta)
            txtCodCuentaDest.Text = toNull(registro.CuentaContableDest.CodCuenta)

            lblDesCuentaTrans.Text = Trim(registro.CuentaContableTrans.NomCuenta)
            txtCodCuentaTrans.Text = toNull(registro.CuentaContableTrans.CodCuenta)

            txtPorcentaje.Value = registro.Porcentaje
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As CuentaContableService.CuentaDestino)
        Try
            Dim estado_process As Boolean
            estado_process = oCuentaContableService.InsertarCuentaDestino(registro)
            type_process = "insert"
            If estado_process = True Then
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                IdCuentaDest = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CUENTA DESTINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CuentaContableService.CuentaDestino)
        Try
            Dim estado_process As Boolean
            estado_process = oCuentaContableService.ActualizarCuentaDestino(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CUENTA DESTINO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oCuentaContableService.BorrarCuentaDestino(IdCuenta, IdCuentaDest)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CUENTA DESTINO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New CuentaContableService.CuentaDestino
                    Dim CuentaContable As New CuentaContableService.CuentaContable
                    Dim CuentaContableDest As New CuentaContableService.CuentaContable
                    Dim CuentaContableTrans As New CuentaContableService.CuentaContable

                    CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    CuentaContable.CodCuenta = txtCodCuenta.Text
                    registro.CuentaContable = CuentaContable

                    CuentaContableDest.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text)
                    CuentaContableDest.CodCuenta = txtCodCuentaDest.Text
                    registro.CuentaContableDest = CuentaContableDest

                    CuentaContableTrans.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaTrans.Text)
                    CuentaContableTrans.CodCuenta = txtCodCuentaTrans.Text
                    registro.CuentaContableTrans = CuentaContableTrans

                    registro.Porcentaje = txtPorcentaje.Value
                    registro.Activo = cbActivo.Checked

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
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
            MsgBox("Error al Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
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
                    txtCodCuentaDest.Focus()
                End If
            Else
                txtCodCuentaDest.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta.Validated
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
                txtCodCuentaDest.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub btnBuscarCuentaDest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuentaDest.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuentaDest.Text = frm.codigo
                    lblDesCuentaDest.Text = frm.descripcion
                Else
                    txtCodCuentaDest.Text = ""
                    lblDesCuentaDest.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable Destino: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuentaDest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuentaDest.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuentaDest.Enabled = True Then
                e.Handled = True
                btnBuscarCuentaDest_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuentaDest.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaDest.Text)) Then
                    MsgBox("Código de Cuenta Destino no existente, Verifique")
                    txtCodCuentaDest.Text = ""
                    lblDesCuentaDest.Text = ""
                    txtCodCuentaDest.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuentaDest.Text = registro.NomCuenta
                    txtCodCuentaTrans.Focus()
                End If
            Else
                txtCodCuentaTrans.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuentaDest_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuentaDest.Validated
        If Len(Trim(txtCodCuentaDest.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaDest.Text)) Then
                MsgBox("Código de Cuenta Destino no existente, Verifique")
                txtCodCuentaDest.Text = ""
                lblDesCuentaDest.Text = ""
                txtCodCuentaDest.Focus()
            Else
                Dim IdCuenta As Integer
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text)
                Dim registro As New CuentaContableService.CuentaContable
                registro = oCuentaContableService.Obtener(IdCuenta)
                lblDesCuentaDest.Text = registro.NomCuenta
                txtCodCuentaTrans.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub btnBuscarCuentaTrans_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuentaTrans.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuentaTrans.Text = frm.codigo
                    lblDesCuentaTrans.Text = frm.descripcion
                Else
                    txtCodCuentaTrans.Text = ""
                    lblDesCuentaTrans.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable Transferencia : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuentaTrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuentaTrans.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuentaTrans.Enabled = True Then
                e.Handled = True
                btnBuscarCuentaTrans_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuentaTrans.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaTrans.Text)) Then
                    MsgBox("Código de Cuenta Transferencia no existente, Verifique")
                    txtCodCuentaTrans.Text = ""
                    lblDesCuentaTrans.Text = ""
                    txtCodCuentaTrans.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaTrans.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuentaTrans.Text = registro.NomCuenta
                    txtPorcentaje.Focus()
                End If
            Else
                txtPorcentaje.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuentaTrans_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuentaTrans.Validated
        If Len(Trim(txtCodCuentaTrans.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaTrans.Text)) Then
                MsgBox("Código de Cuenta Transferencia no existente, Verifique")
                txtCodCuentaTrans.Text = ""
                lblDesCuentaTrans.Text = ""
                txtCodCuentaTrans.Focus()
            Else
                Dim IdCuenta As Integer
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaTrans.Text)
                Dim registro As New CuentaContableService.CuentaContable
                registro = oCuentaContableService.Obtener(IdCuenta)
                lblDesCuentaTrans.Text = registro.NomCuenta
                txtPorcentaje.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub txtPorcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

End Class