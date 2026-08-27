Imports System.ServiceModel
Public Class frmProcesarDifTipCamb

    '===========================Servicios====================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables=============================  
    Private dtDatos As DataTable

    Private Sub frmProcesarDifCambio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 195)
        '/*************************************************************************************/

        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        ListarDatos()

        Dim Fecha As Date = DateAdd(DateInterval.Month, 1, Now.Date)
        txtFecha.Value = DateAdd(DateInterval.Day, -1, DateSerial(Fecha.Year, Fecha.Month, 1))

        txtTipCambio.Value = Format(toDouble(oSeguridadService.MostrarTipoCambioCompra("US", Today)), "#0.000")
        txtCodCtaPerdida.Text = "676.11"
        txtCodCtaGanancia.Text = "776.11"
        txtGlosa.Text = "AJUSTE DE DIFERENCIA DE CAMBIO"
        txtFecha.Focus()
    End Sub

    Private Sub ListarDatos()
        Try
            dtDatos = oCuentaContableService.MostrarProcesoDifCam().Tables(0)
            dgvDatos.DataSource = dtDatos

            cCodCuenta1.DataPropertyName = dtDatos.Columns("CodCuenta1").ColumnName
            cCodCuenta2.DataPropertyName = dtDatos.Columns("CodCuenta2").ColumnName
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCtaPerdida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCtaPerdida.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCtaPerdida.Text = frm.codigo
                Else
                    txtCodCtaPerdida.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable Perdida: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCtaGanancia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCtaGanancia.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCtaGanancia.Text = frm.codigo
                Else
                    txtCodCtaGanancia.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable Ganancia : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCtaPerdida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCtaPerdida.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCtaPerdida.Enabled = True Then
                e.Handled = True
                btnBuscarCtaPerdida_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCtaPerdida.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCtaPerdida.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCtaPerdida.Text = ""
                    txtCodCtaPerdida.Focus()
                Else
                    txtGlosa.Focus()
                End If
            Else
                txtGlosa.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCtaPerdida_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCtaPerdida.Validated
        If Len(Trim(txtCodCtaPerdida.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCtaPerdida.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCtaPerdida.Text = ""
                txtCodCtaPerdida.Focus()
            Else
                txtGlosa.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub frmProcesarCierreMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtCodCtaGanancia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCtaGanancia.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCtaGanancia.Enabled = True Then
                e.Handled = True
                btnBuscarCtaGanancia_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCtaGanancia.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCtaGanancia.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCtaGanancia.Text = ""
                    txtCodCtaGanancia.Focus()
                Else
                    txtCodCtaPerdida.Focus()
                End If
            Else
                txtCodCtaPerdida.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCtaGanancia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCtaGanancia.Validated
        If Len(Trim(txtCodCtaGanancia.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCtaGanancia.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCtaGanancia.Text = ""
                txtCodCtaGanancia.Focus()
            Else
                txtCodCtaPerdida.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Try
            Dim dt As New DataTable
            dt = dgvDatos.DataSource
            Dim row As DataRow
            row = dt.NewRow()
            row.Item("CodCuenta1") = ""
            row.Item("CodCuenta2") = ""
            dt.Rows.Add(row)

            dgvDatos.DataSource = dt
            cCodCuenta1.DataPropertyName = dt.Columns("CodCuenta1").ColumnName
            cCodCuenta2.DataPropertyName = dt.Columns("CodCuenta2").ColumnName
        Catch ex As Exception
            MsgBox("Error al Insertar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If dgvDatos.RowCount > 0 Then
            dgvDatos.Rows.RemoveAt(dgvDatos.CurrentRow.Index)
        End If
        EnableOptions()
    End Sub

    Private Sub EnableOptions()
        If dgvDatos.RowCount > 0 Then
            miEliminar.Enabled = True
        Else
            miEliminar.Enabled = False
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
            oCuentaContableService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de PROCESAR diferencia de cambio?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    dgvDatos.Update()
                    Dim dtTable As DataTable
                    Dim rows As DataRow

                    dtTable = dtDatos.Copy
                    dtTable.Clear()

                    For i As Integer = 0 To dtDatos.Rows.Count - 1
                        rows = dtTable.NewRow
                        rows(0) = dgvDatos.Rows(i).Cells(0).Value
                        rows(1) = dgvDatos.Rows(i).Cells(1).Value
                        dtTable.Rows.Add(rows)
                    Next

                    Dim state_process As Boolean
                    oContabilidadService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    state_process = oContabilidadService.ProcesarDiferenciaCambio(Session.sCodEmp, txtFecha.Value, txtTipCambio.Value, txtGlosa.Text, dtTable, txtCodCtaGanancia.Text, txtCodCtaPerdida.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If state_process = True Then
                        MsgBox("Se procesó la diferencia de cambio Correctamente")
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDatos.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvDatos.CurrentCell.ColumnIndex
        If columna = 0 Or columna = 1 Then
            Dim caracter As Char = e.KeyChar            
            If (Char.IsNumber(e.KeyChar)) Or (e.KeyChar = ChrW(Keys.Back)) Or (e.KeyChar = ".") And (CType(sender, TextBox).Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    'Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
    '    Try
    '        If MsgBox("¿Está seguro de PROCESAR diferencia de cambio?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
    '        And ValidaCampos() Then
    '            Dim cadena As String = ""
    '            For i As Integer = 0 To dgvDatos.Rows.Count - 1
    '                Dim row As DataGridViewRow = dgvDatos.Rows(i)
    '                If cadena = "" Then
    '                    cadena = toBlank(row.Cells("cCodCuenta").Value)
    '                Else
    '                    cadena = cadena & "," & toBlank(row.Cells("cCodCuenta").Value)
    '                End If
    '            Next
    '            Dim state_process As Boolean
    '            state_process = oContabilidadService.ProcesarDiferenciaCambio(Session.sCodEmp, txtFecha.Value, txtTipCambio.Value, txtGlosa.Text, cadena, txtCodCtaGanancia.Text, txtCodCtaPerdida.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

    '            If state_process = True Then
    '                MsgBox("Se procesó la diferencia de cambio Correctamente")
    '            Else
    '                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL PROCESAR DIFERENCIA DE CAMBIO : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
                Return False
            ElseIf dgvDatos.RowCount < 1 Then
                MsgBox("No se presentan Cuentas, Verificar.", MsgBoxStyle.Information, "Información")
                dgvDatos.Focus()
                Return False
            ElseIf ValidaCuentas() Then
                MsgBox("Codigo de cuenta de la tabla no existente, Verificar.", MsgBoxStyle.Information, "Información")
                dgvDatos.Focus()
                Return False
            ElseIf toBlank(txtCodCtaGanancia.Text) = "" Then
                MsgBox("Debe Ingresar la Cuenta Ganancia.", MsgBoxStyle.Information, "Información")
                txtCodCtaGanancia.Focus()
                Return False
            ElseIf toBlank(txtCodCtaPerdida.Text) = "" Then
                MsgBox("Debe Ingresar la Cuenta Perdida.", MsgBoxStyle.Information, "Información")
                txtCodCtaPerdida.Focus()
                Return False
            ElseIf toBlank(txtGlosa.Text) = "" Then
                MsgBox("Debe Ingresar la Glosa.", MsgBoxStyle.Information, "Información")
                txtGlosa.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCuentas() As Boolean
        Try
            Dim Cont As Integer = 0
            For i As Integer = 0 To dtDatos.Rows.Count - 1
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, dgvDatos.Rows(i).Cells(0).Value.ToString)) Or Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, dgvDatos.Rows(i).Cells(1).Value.ToString)) Then
                    Cont = Cont + 1
                End If
            Next

            If Cont > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CUENTAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
End Class