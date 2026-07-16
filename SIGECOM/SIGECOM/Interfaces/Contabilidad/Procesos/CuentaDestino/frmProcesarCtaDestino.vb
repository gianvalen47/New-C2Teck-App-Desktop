Imports System.ServiceModel
Public Class frmProcesarCtaDestino

    '===========================Servicios====================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables=============================  

    Private Sub frmProcesarCtaDestino_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 182)
        '/*************************************************************************************/

        txtPeriodo.Value = Year(Today)
        txtMesRegistro.Text = Format(Month(Today), "00")

        cbProcesar.Checked = True
        txtPeriodo.Focus()
    End Sub

    Private Sub frmProcesarCtaDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProcesarCtaDestino_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
                    btnAceptar.Focus()
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
                btnAceptar.Focus()
            End If
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
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de PROCESAR las Cuentas Destino?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then
                '=======================================================================
                '------------------------------------------------------------ PROCESAR --------------------------------------------------------------
                '=======================================================================
                oContabilidadService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                If cbProcesar.Checked = True Then
                    Dim state_process As Boolean
                    state_process = oContabilidadService.ProcesarCuentaDestino(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If state_process Then
                        MsgBox("Se procesó las Cuentas Destino Correctamente")
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If

                    '=======================================================================
                    '------------------------------------------------------------- REVERTIR ---------------------------------------------------------------
                    '=======================================================================
                ElseIf cbRevertir.Checked = True Then
                    Dim state_process As Boolean
                    state_process = oContabilidadService.RevertirCuentaDestino(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If state_process Then
                        MsgBox("Se revertió las Cuentas Destino Correctamente")
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL PROCESAR/REVERTIR CUENTAS DESTINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMesRegistro.Focus()
        End If
    End Sub
End Class