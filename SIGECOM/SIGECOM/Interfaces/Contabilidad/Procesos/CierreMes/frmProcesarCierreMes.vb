Imports System.ServiceModel
Public Class frmProcesarCierreMes

    '===========================Servicios====================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables=============================  

    Private Sub frmProcesarCierreMes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 187)
        '/*************************************************************************************/

        txtPeriodo.Value = Year(Today)
        txtMesRegistro.Text = Format(Month(Today), "00")
        Dim UltimoDiaMes As Date
        UltimoDiaMes = DateSerial(txtPeriodo.Value, txtMesRegistro.Text + 1, 0)
        txtFecha.Value = UltimoDiaMes
        txtPeriodo.Focus()
    End Sub

    Private Sub frmProcesarCierreMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProcesarCierreMes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

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
                    txtObservacion.Focus()
                End If
            Else
                MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
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
                txtObservacion.Focus()
            End If
            Dim UltimoDiaMes As Date
            UltimoDiaMes = DateSerial(txtPeriodo.Value, txtMesRegistro.Text + 1, 0)
            txtFecha.Value = UltimoDiaMes
        Else
            MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtPeriodo.Value) = 0 Then
                MsgBox("Debe Ingresar el periodo.", MsgBoxStyle.Information, "Información")
                txtPeriodo.Focus()
                Return False
            ElseIf toNumber(txtMesRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el Mes.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf oContabilidadService.BuscarCierreMes(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text) And rbProcesar.Checked Then
                MsgBox("Ya se procesó el cierre de este mes.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub txtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If rbProcesar.Checked = True Then
                If MsgBox("¿Está seguro de PROCESAR el cierre de mes?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                     And ValidaCampos() Then
                    Dim state_process As Integer

                    Dim registro As New ContabilidadService.CierreMesContable
                    Dim Empresa As New ContabilidadService.Empresa

                    registro.IdCierre = 0
                    registro.Periodo = txtPeriodo.Value
                    registro.Mes = txtMesRegistro.Text
                    registro.Observacion = txtObservacion.Text
                    registro.FechaCierre = txtFecha.Text
                    Empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = Empresa

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.FecReg = Today
                    registro.NomPc = Session.sNomPc

                    state_process = oContabilidadService.InsertarCierreMes(registro)

                    If state_process > 0 Then
                        MsgBox("Se procesó el cierre de mes Correctamente")
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            ElseIf rbRevertir.Checked Then

                If MsgBox("¿Está seguro de REVERTIR el cierre de mes?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidaCampos() Then
                    Dim state_process As Boolean

                    Dim registro As New ContabilidadService.CierreMesContable
                    Dim Empresa As New ContabilidadService.Empresa

                    registro.IdCierre = 0
                    registro.Periodo = txtPeriodo.Value
                    registro.Mes = txtMesRegistro.Text
                    registro.Observacion = txtObservacion.Text
                    registro.FechaCierre = txtFecha.Text
                    Empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = Empresa

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.FecReg = Today
                    registro.NomPc = Session.sNomPc

                    state_process = oContabilidadService.RevertirCierreMesContable(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If state_process Then
                        MsgBox("Se revirtio el cierre de mes correctamente")
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If


            End If

        Catch ex As Exception
            MsgBox("ERROR AL PROCESAR / REVERTIR CIERRE DE MES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbProcesar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbProcesar.CheckedChanged
        If rbProcesar.Checked Then
            txtFecha.Enabled = True
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub rbRevertir_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbRevertir.CheckedChanged
        If rbRevertir.Checked Then
            txtFecha.Enabled = False
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
End Class