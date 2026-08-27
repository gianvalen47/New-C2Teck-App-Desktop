Imports System.ServiceModel
Public Class frmDsctoCuenta

    '============================Servicios===================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdRubroDes As Integer
    Public IdCuenta As Integer
    Private dtRubroDscto As DataTable

    Private Sub frmDsctoCuenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "DESCUENTO DE CUENTA"
            cmbDescuento.TabStop = False
            txtCodCuenta.Focus()
        Else                          'Nuevo
            Me.Text = "Registrar nuevo Descuento de Cuenta"
            activar()
            lblDesCuenta.Text = ""
            cmbDescuento.TabStop = True
            cmbDescuento.Focus()
        End If
        enableOpciones()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       cmbDescuento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDsctoCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDsctoCuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaSueldosService.Close()
            oPlanillaSueldosDetService.Close()
            oCuentaContableService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oCuentaContableService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()            
            oPlanillaSueldosDetService.Abort()
            oCuentaContableService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== DESCUENTO ===============================================
            dtRubroDscto = oPlanillaSueldosDetService.MostrarRubroDescuento(Session.sCodEmp).Tables(0)
            cmbDescuento.DataSource = dtRubroDscto
            cmbDescuento.DropDownList.DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.DisplayMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.ValueMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(0).DataMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(1).DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.SelectedIndex = 0
            dtRubroDscto = Nothing

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

        cmbDescuento.ReadOnly = False
        cmbDescuento.BackColor = System.Drawing.SystemColors.Window

        cmbDescuento.Focus()
    End Sub

    Private Sub desactivar()
        txtCodCuenta.ReadOnly = False
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Window

        cmbDescuento.ReadOnly = True
        cmbDescuento.BackColor = System.Drawing.SystemColors.Control

        txtCodCuenta.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbDescuento.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Descuento.", MsgBoxStyle.Information, "Información")
                cmbDescuento.Focus()
                Return False
            ElseIf txtCodCuenta.Text = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta. ", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar !!!", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
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
            Dim registro As PlanillaSueldosService.RubroDescuentoCuentas
            registro = oPlanillaSueldosService.ObtenerRubroDescuentoCuentas(IdRubroDes, IdCuenta)

            IdRubroDes = registro.RubroDescuentoPlanilla.IdRubroDes
            IdCuenta = registro.CuentaContable.IdCuenta

            cmbDescuento.Value = registro.RubroDescuentoPlanilla.IdRubroDes
            txtCodCuenta.Text = registro.CuentaContable.CodCuenta
            lblDesCuenta.Text = registro.CuentaContable.NomCuenta

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaSueldosService.RubroDescuentoCuentas)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.InsertarRubroDescuentoCuentas(registro)
            type_process = "insert"
            If estado_process = True Then
                IdRubroDes = cmbDescuento.Value
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DESCUENTO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosService.RubroDescuentoCuentas)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.ActualizarRubroDescuentoCuentas(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DESCUENTO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.BorrarRubroDescuentoCuentas(IdRubroDes, IdCuenta)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DESCUENTO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New PlanillaSueldosService.RubroDescuentoCuentas
                    Dim Descuento As New PlanillaSueldosService.RubroDescuentoPlanilla
                    Dim CuentaContable As New PlanillaSueldosService.CuentaContable

                    Descuento.IdRubroDes = cmbDescuento.Value
                    registro.RubroDescuentoPlanilla = Descuento

                    CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    CuentaContable.CodCuenta = txtCodCuenta.Text
                    registro.CuentaContable = CuentaContable

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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
                    btnGuardar.Focus()
                End If
            Else
                btnGuardar.Focus()
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
                btnGuardar.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub
End Class