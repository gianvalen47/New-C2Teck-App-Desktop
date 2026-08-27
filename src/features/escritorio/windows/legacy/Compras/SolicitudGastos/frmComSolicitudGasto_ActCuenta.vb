Imports System.ServiceModel
Public Class frmComSolicitudGasto_ActCuenta

    '===========================Servicios====================================
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================   
    Public IdGastoDet As Integer
    Public IdGasto As Integer
    Public Masivo As Boolean
    Private cIdGastoDet As Integer
    Public dtDetalles As DataTable

    Private Sub frmComSolicitudGasto_ActCuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudGasto_ActCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_ActCuenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblIdGasto.Text = CStr(IdGasto)
        Me.Text = "Actualizar Número de Cuenta Contable"
        txtCodCuenta.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Len(Trim(txtCodCuenta.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Número de Cuenta Contable no existente, Verifique")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
            Else
                ActualizarCuentaMasivo()
            End If
        Else
            MsgBox("Ingrese un N° de Cuenta Contable")
        End If
    End Sub

    Private Sub ActualizarCuentaMasivo()
        Try
            Dim estado_process As Boolean
            If Masivo = False Then
                'If MsgBox("¿Estás seguro de Actualizar el Nro de Cuenta del Detalle de Solicitud de Gastos N°:" & IdGasto & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                '    estado_process = oSolicitudGastoDetService.ActualizarNumeroCuenta(IdGastoDet, IdGasto, txtCodCuenta.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                '    If estado_process Then
                '        'MsgBox("Se ACTUALIZO correctamente el Número de Cuenta Contable")
                '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                '    Else
                '        MsgBox("Error al Actualizar Número de Cuenta Contable...")
                '    End If
                'End If
            Else
                '  If MsgBox("¿Estás seguro de Actualizar el Nro de Cuenta a los detalles de Solicitud de Gastos N°:" & IdGasto & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                For i As Integer = 0 To dtDetalles.Rows.Count - 1
                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    cIdGastoDet = toNumber(row.Cells("IdGastoDet").Value)
                    oSolicitudGastoDetService.ActualizarNumeroCuenta(cIdGastoDet, IdGasto, txtCodCuenta.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                Next
                estado_process = oSolicitudGastoDetService.ActualizarNumeroCuenta(IdGastoDet, IdGasto, txtCodCuenta.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'If estado_process Then
                'MsgBox("Se ACTUALIZO correctamente el Número de Cuenta Contable")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Else
                '    MsgBox("Error al Actualizar Número de Cuenta Contable...")
                'End If
            End If
            ' End If
        Catch ex As Exception
            MsgBox("Error al Actualizar el Número de Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoDetService.Close()
            oCuentaContableService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oCuentaContableService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oCuentaContableService.Abort()
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                    MsgBox("Número de Cuenta Contable no existente, Verifique")
                    txtCodCuenta.Text = ""
                    txtCodCuenta.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de Cuenta Contable")
            End If
        End If
    End Sub

    Private Sub txtCodCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub

    'Private Sub txtCodCuenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCuenta.Validating
    '    Try
    '        If Len(Trim(txtCodCuenta.Text)) > 0 Then
    '            If Not (oSolicitudGastoDetService.BuscarNumeroCuenta(txtCodCuenta.Text)) Then
    '                MsgBox("Número de Cuenta Contable no existente, Verifique")                    
    '                txtCodCuenta.Text = ""
    '                txtCodCuenta.Focus()                                
    '            End If
    '        Else
    '            MsgBox("Ingrese un N° de Cuenta Contable")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER LA CUENTA CONTABLE : " + ex.Message)
    '    End Try
    'End Sub

    Private Sub btnBuscarNroCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarNroCuenta.Click
        Dim frm As New frmBuscarCuentaContable
        'frm.txtCodCuenta.Text = "10"
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                'txtCodCuentaDest.Text = frm.codigo
                'lblDesCuentaDest.Text = frm.descripcion
                txtCodCuenta.Text = frm.codigo
            Else
                'txtCodCuentaDest.Text = ""
                'lblDesCuentaDest.Text = ""
                txtCodCuenta.Text = ""
            End If
        End If
    End Sub
End Class