Public Class frmClienteFacDsc
  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
    Private oFacDscService As New ClienteFacDscService.ClienteFacDscServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

  Private dtDatos As DataTable
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
    Public lCodRub
    Public IdCliente

    Private Sub frmClienteFacDsc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If txtCliente.ButtonEnabled = True Then
                txtCliente_ButtonClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 41)
        '/*************************************************************************************/

        Me.CancelButton = Me.btnCancelar
        If state_button Then    'Modificar Registro
            ObtenerRegistro()
            Me.Text = "Modificar Cliente - " + txtCliente.Text.ToString
            txtCliente.Enabled = False
            txtFactorCliente.Focus()
        Else                    'Nuevo Registro
            Me.Text = "Agregar Nuevo Registro"
            miEliminar.Visible = False
            btnEliminar.Visible = False
            txtCliente.Focus()
        End If

        If Session.CodPerfil = "01" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05" Then      '-------- Se agrega el Perfil de Costos 02/08/2016
            btnGuardar.Enabled = True
            btnEliminar.Enabled = True
            txtFactorCliente.Enabled = True
            txtDsctoCliente.Enabled = True
            chkbDNCliente.Enabled = True
        Else
            btnGuardar.Enabled = False
            btnEliminar.Enabled = False
            txtFactorCliente.Enabled = False
            txtDsctoCliente.Enabled = False
            chkbDNCliente.Enabled = False
        End If


    End Sub


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    txtCliente.KeyPress, txtRucCliente.KeyPress, txtDniCliente.KeyPress, txtFactorCliente.KeyPress, _
    txtDsctoCliente.KeyPress, chkbDNCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oFacDscService) = False Then
        oFacDscService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
            txtCliente.KeyUp, txtRucCliente.KeyUp, txtDniCliente.KeyUp
    Try
      Dim campo As New Object
      If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
        campo = New Janus.Windows.GridEX.EditControls.EditBox
      ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
        campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
      ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
        campo = New TextBox
      End If
      campo = sender
      If campo.readonly = False Then
        If campo.Text.Trim.Length > 0 Then
          campo.BackColor = Color.White
        Else
          campo.BackColor = Color.Red
        End If
      End If
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub
  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Function ValidaCampos() As Boolean
    Try
      If state_button = False And IdCliente = 0 Then
        MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
        txtCliente.BackColor = Color.Red
        txtCliente.Focus()
        Return False
      ElseIf txtFactorCliente.Value = 0 And txtDsctoCliente.Value = 0 Then
        MsgBox("Debe ingresar el Factor o el Descuento.", MsgBoxStyle.Information)
        'txtFactorCliente.BackColor = Color.Red
        txtFactorCliente.Focus()
      ElseIf txtFactorCliente.Value > 0 And txtDsctoCliente.Value > 0 Then
        MsgBox("Solo debe ingresar el Factor o el Descuento y no los dos", MsgBoxStyle.Information)
        'txtFactorCliente.BackColor = Color.Red
        txtFactorCliente.Focus()
        Return False
      ElseIf txtFactorCliente.Value < 0 Or txtDsctoCliente.Value < 0 Then
        MsgBox("El valor debe ser mayor que cero.", MsgBoxStyle.Information)
        'txtFactorCliente.BackColor = Color.Red
        'txtDesctoCliente.BackColor = Color.Red
        If txtFactorCliente.Value < 0 Then
          txtFactorCliente.Focus()
        Else
          txtDsctoCliente.Focus()
        End If
        Return False
      Else
        Return True
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function
  Private Sub Insertar(ByVal registro As ClienteFacDscService.ClienteFacDsc)
    Try
      Dim estado_process As Integer
      estado_process = oFacDscService.Insertar(registro)
      type_process = "insert"
      If estado_process = True Then
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Else
        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Modificar(ByVal registro As ClienteFacDscService.ClienteFacDsc)
    Try
      Dim estado_process As Boolean
      estado_process = oFacDscService.Actualizar(registro)
            type_process = "update"

      If estado_process = True Then
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Else
        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Eliminar()
    Try
      Dim estado_process As Boolean
            estado_process = oFacDscService.Borrar(Session.sCodEmp, lCodRub, IdCliente, Session.sCodUsu)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As ClienteFacDscService.ClienteFacDsc
            registro = oFacDscService.MostrarPorId(Session.sCodEmp, lCodRub, IdCliente)

            txtCliente.Text = registro.Cliente.DesCli
            IdCliente = registro.Cliente.IdCliente
            txtRucCliente.Text = registro.Cliente.RucCli
            txtDniCliente.Text = registro.Cliente.DniCli
            txtFactorCliente.Value = registro.FacCli
            txtDsctoCliente.Value = registro.DscCli
            chkbDNCliente.Checked = registro.DNCli
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub GuardarDatos()
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            Dim registro As New ClienteFacDscService.ClienteFacDsc
            Dim cliente As New ClienteFacDscService.Cliente
            Dim empresa As New ClienteFacDscService.Empresa
            Dim Rubro As New ClienteFacDscService.Rubro

            Rubro.CodRub = lCodRub
            registro.Rubro = Rubro
            cliente.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
            registro.Cliente = cliente
            registro.FacCli = txtFactorCliente.Value
            registro.DscCli = txtDsctoCliente.Value
            registro.DNCli = chkbDNCliente.Checked

            empresa.CodEmp = Session.sCodEmp
            registro.Empresa = empresa
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
  Private Sub EliminarDatos()
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If toNumber(IdCliente) = 0 Then
                Eliminar()
            Else
                MsgBox("Debe Seleccionar el Registro a Eliminar...!!!", MsgBoxStyle.Information, "Información")
                txtCliente.Focus()
            End If
        End If
  End Sub
  Private Sub CancelarDatos()
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
  End Sub
  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ====================================================
  '====================================================================================================================
  Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
    Dim frm As New frmBuscarCliente
    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
      txtCliente.Text = frm.descripcion
      txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            txtRucCliente.Text = frm.Ruc
            txtDniCliente.Text = frm.Dni
        End If
        txtCliente.Select()
    End Sub
  Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    GuardarDatos()
  End Sub
  Private Sub miGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGuardar.Click
    GuardarDatos()
  End Sub
  Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    EliminarDatos()
  End Sub
  Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
    EliminarDatos()
  End Sub
  Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    CancelarDatos()
  End Sub
  Private Sub miCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCancelar.Click
    CancelarDatos()
  End Sub
  Private Sub txtFactorCliente_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFactorCliente.ValueChanged
    If txtFactorCliente.Value > 0 Then
      txtDsctoCliente.Value = 0
    End If
  End Sub
  Private Sub txtDsctoCliente_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDsctoCliente.ValueChanged
    If txtDsctoCliente.Value > 0 Then
      txtFactorCliente.Value = 0
    End If
  End Sub

End Class