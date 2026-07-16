Imports System.Windows.Forms

Public Class frmGuiaRemision_Transportista

  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oTransportistaService As New TransportistaService.TransportistaServiceClient
  Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
  Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    Private dtTipoDocumento As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================

    Public IdGuia As Integer
    Private estado As String
    Private dtModelos As DataTable
    Private IdTransportista As Integer = 0
    Public CodModo As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                  txtEmpresa.KeyPress, txtChofer.KeyPress, txtRuc.KeyPress, txtDireccion.KeyPress, btnGuardar.KeyPress,
                                  txtVehiculo.KeyPress, txtPlaca.KeyPress, txtConIns.KeyPress, txtLicencia.KeyPress, btnCancelar.KeyPress, cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGuiaRemision_Transportista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        ObtenerRegistro()


        If estado = "GN" Or estado = "AP" Or estado = "CR" Then
            btnGuardar.Enabled = True
        ElseIf estado = "GENERADO" Or estado = "APROBADO" Or estado = "CREDITOS" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If

        If CodModo = "01" Then

            lbloempresa.Visible = True
            lblodireccion.Visible = False
            lbloruc.Visible = True
            lbloplaca.Visible = False
            lblotipodoc.Visible = False
            lblonumdoc.Visible = False
            lblLicencia.Visible = False
            lblChofer.Visible = False

            txtEmpresa.Select()

        ElseIf CodModo = "02" Then

            lbloempresa.Visible = False
            lblodireccion.Visible = False
            lbloruc.Visible = False
            lbloplaca.Visible = True
            lblotipodoc.Visible = True
            lblonumdoc.Visible = True
            lblLicencia.Visible = True
            lblChofer.Visible = True

            If state_button = False Then
                cbTransportista.Enabled = True
            Else
                cbTransportista.Enabled = False
            End If

            txtChofer.Select()

        End If



        Me.Text = "Transportista"
    End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oTransportistaService) = False Then
        oTransportistaService.Close()
      End If
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oGuiaRemisionService) = False Then
        oGuiaRemisionService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                  txtDireccion.KeyUp, txtEmpresa.KeyUp, txtRuc.KeyUp, txtPlaca.KeyUp, txtChofer.KeyUp, cmbTipoDoc.KeyUp, txtNumDoc.KeyUp

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
            If toNumber(IdGuia) = 0 Then
                MsgBox("Debe Ingresar el código de la guía. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtEmpresa.Text) = "" And CodModo = "01" Then
                MsgBox("Debe Ingresar la Razón social del Transportista.", MsgBoxStyle.Information, "Información")
                txtEmpresa.BackColor = Color.Red
                txtEmpresa.Focus()
                Return False
            ElseIf Len(txtEmpresa.Text) < 5 And CodModo = "01" Then
                MsgBox("Debe Ingresar una Razón Social valida.", MsgBoxStyle.Information, "Información")
                txtEmpresa.BackColor = Color.Red
                txtEmpresa.Focus()
                Return False
                'ElseIf toBlank(txtDireccion.Text) = "" Then
                '    MsgBox("Debe Ingresar la Dirección", MsgBoxStyle.Information, "Información")
                '    txtChofer.BackColor = Color.Red
                '    txtChofer.Focus()
                '    Return False
            ElseIf toBlank(txtRuc.Text) = "" And CodModo = "01" Then
                MsgBox("Debe Ingresar el RUC del transportista.", MsgBoxStyle.Information, "Información")
                txtRuc.BackColor = Color.Red
                txtRuc.Focus()
                Return False
            ElseIf Len(txtRuc.Text) < 11 And CodModo = "01" Then
                MsgBox("Debe Ingresar un numero de RUC Valido.", MsgBoxStyle.Information, "Información")
                txtRuc.BackColor = Color.Red
                txtRuc.Focus()
                Return False
            ElseIf toBlank(txtPlaca.Text) = "" And CodModo = "02" Then
                MsgBox("Debe Ingresar la Placa del vehiculo", MsgBoxStyle.Information, "Información")
                txtPlaca.BackColor = Color.Red
                txtPlaca.Focus()
                Return False
                'ElseIf toBlank(txtChofer.Text) = "" Then
                '    MsgBox("Debe Ingresar el nombre del Transportista.", MsgBoxStyle.Information, "Información")
                '    txtChofer.BackColor = Color.Red
                '    txtChofer.Focus()
                '    Return False
            ElseIf toBlank(cmbTipoDoc.Text) = "" And CodModo = "02" Then
                MsgBox("Debe Ingresar el Tipo de Documento", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.BackColor = Color.Red
                cmbTipoDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" And CodModo = "02" Then
                MsgBox("Debe Ingresar el Numero de Documento del Transportista.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf Len(txtNumDoc.Text) < 8 And CodModo = "02" Then
                MsgBox("Debe Ingresar un Numero de Documento Valido", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtChofer.Text) = "" And CodModo = "02" Then
                MsgBox("Debe Ingresar el nombre del chofer.", MsgBoxStyle.Information, "Información")
                txtChofer.BackColor = Color.Red
                txtChofer.Focus()
                Return False
            ElseIf toBlank(txtLicencia.Text) = "" And CodModo = "02" Then
                MsgBox("Debe Ingresar el Numero de Licencia de conducir.", MsgBoxStyle.Information, "Información")
                txtLicencia.BackColor = Color.Red
                txtLicencia.Focus()
                Return False
            ElseIf Len(txtLicencia.Text) < 9 And CodModo = "02" Then
                MsgBox("Debe Ingresar un Numero de Licencia Valido.", MsgBoxStyle.Information, "Información")
                txtLicencia.BackColor = Color.Red
                txtLicencia.Focus()
                Return False
            ElseIf state_button = True And oGuiaRemisionService.Estado(IdGuia) <> "GENERADO" And oGuiaRemisionService.Estado(IdGuia) <> "APROBADO" And oGuiaRemisionService.Estado(IdGuia) <> "CREDITOS" Then
                MsgBox("La Guía ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
    Catch ex As Exception
      MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function
  Private Sub Insertar(ByVal registro As TransportistaService.Transportista)
    Try
      Dim estado_process As Integer
      estado_process = oTransportistaService.Insertar(registro)
      type_process = "insert"
      If estado_process > 0 Then
        IdTransportista = estado_process
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Else
        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Modificar(ByVal registro As TransportistaService.Transportista)
    Try
      Dim estado_process As Boolean
      estado_process = oTransportistaService.Actualizar(registro)
      type_process = "update"
      If estado_process = True Then
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Else
        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub ObtenerRegistro()
    Try
            Dim registro As TransportistaService.Transportista

            If oTransportistaService.BuscarGuia(IdGuia) Then
                registro = oTransportistaService.MostrarPorId(oTransportistaService.MostrarIdTransportistaGuia(IdGuia))
                IdTransportista = registro.IdTransportista
                txtEmpresa.Text = registro.Empresa
                txtDireccion.Text = registro.Direccion
                txtRuc.Text = registro.Ruc
                txtVehiculo.Text = registro.Vehiculo
                txtPlaca.Text = registro.Placa
                txtChofer.Text = registro.Chofer
                txtLicencia.Text = registro.Licencia
                txtConIns.Text = registro.ConIns
                IdGuia = registro.GuiaRemision.IdGuia
                cmbTipoDoc.Value = registro.TipoDocumentoId.CodDoc
                txtNumDoc.Text = registro.NumDoc
                state_button = True
            Else
                state_button = False
                cmbTipoDoc.Value = "1"
            End If

            estado = oGuiaRemisionService.Estado(IdGuia)

    Catch ex As Exception
      MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub llenarCombos()
        Try
            '======================================= ESTADOS ================================================
            dtTipoDocumento = oTransportistaService.MostrarTipoDocumento().Tables(0)
            cmbTipoDoc.DataSource = dtTipoDocumento
            cmbTipoDoc.DropDownList.DataMember = dtTipoDocumento.Columns("DesDoc").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipoDocumento.Columns("DesDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipoDocumento.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipoDocumento.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipoDocumento.Columns("DesDoc").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipoDocumento = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub

  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ====================================================
  '====================================================================================================================
  Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

                Dim registro As New TransportistaService.Transportista
                Dim guia As New TransportistaService.GuiaRemision
                Dim tipodocumentoid As New TransportistaService.TipoDocumentoId

                registro.IdTransportista = IdTransportista
                registro.Empresa = toNull(txtEmpresa.Text)
                registro.Direccion = toNull(txtDireccion.Text)
                registro.Ruc = toNull(txtRuc.Text)
                registro.Vehiculo = toNull(txtVehiculo.Text)
                registro.Placa = toNull(txtPlaca.Text)
                registro.Chofer = toNull(txtChofer.Text)
                registro.Licencia = toNull(txtLicencia.Text)
                registro.ConIns = toNull(txtConIns.Text)
                guia.IdGuia = IdGuia
                registro.GuiaRemision = guia
                tipodocumentoid.CodDoc = toNull(cmbTipoDoc.Value)
                registro.TipoDocumentoId = tipodocumentoid
                registro.NumDoc = toNull(txtNumDoc.Text)


                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub

    Private Sub cbTransportista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTransportista.CheckedChanged
        Try
            If cbTransportista.Checked Then
                'txtEmpresa.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                'txtRuc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp)
                'txtDireccion.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DirEmp", "CodEmp", Session.sCodEmp)

                Dim idLocacion As Integer = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaRemision", "IdLocacion", "IdGuia", IdGuia)

                txtChofer.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Choferes", "Nombre", "IdLocacion", idLocacion)
                cmbTipoDoc.Value = oMaestroService.MostrarDato("SIGECOM.Ventas.Choferes", "CodDoc", "IdLocacion", idLocacion)
                txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Choferes", "NumDoc", "IdLocacion", idLocacion)
                txtPlaca.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Choferes", "Placa", "IdLocacion", idLocacion)
                txtLicencia.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Choferes", "NumLicencia", "IdLocacion", idLocacion)

            Else
                txtChofer.Text = ""
                cmbTipoDoc.Value = ""
                txtNumDoc.Text = ""
                txtPlaca.Text = ""
                txtLicencia.Text = ""
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtRuc.Text = frm.ruc
                    txtEmpresa.Text = frm.descripcion
                    txtChofer.Focus()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
