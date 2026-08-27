Imports System.Windows.Forms

Public Class frmFactura_Transportista

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oTransportistaService As New TransportistaService.TransportistaServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================

    Public IdFactura As Integer
    Private estado As String
    Private dtModelos As DataTable
    Private IdTransportista As Integer = 0
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                  txtEmpresa.KeyPress, txtChofer.KeyPress, txtRuc.KeyPress, txtDireccion.KeyPress, _
                                  txtVehiculo.KeyPress, txtPlaca.KeyPress, txtConIns.KeyPress, txtLicencia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmFactura_Transportista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        ObtenerRegistro()
        If state_button = False Then
            cbTransportista.Enabled = True
        Else
            cbTransportista.Enabled = False
        End If

        If estado = "GN" Or estado = "AP" Or estado = "CR" Then
            btnGuardar.Enabled = True
        ElseIf estado = "GENERADO" Or estado = "APROBADO" or estado ="CREDITOS" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
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
            If isClosed(oFacturaService) = False Then
                oFacturaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                  txtDireccion.KeyUp, txtEmpresa.KeyUp, txtRuc.KeyUp

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
            If toNumber(IdFactura) = 0 Then
                MsgBox("Debe Ingresar el código de la Factura. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtEmpresa.Text) = "" Then
                MsgBox("Debe Ingresar la Razón Social del Transportista.", MsgBoxStyle.Information, "Información")
                txtEmpresa.BackColor = Color.Red
                txtEmpresa.Focus()
                Return False
                'ElseIf toBlank(txtChofer.Text) = "" Then
                '    MsgBox("Debe Ingresar el nombre del Transportista.", MsgBoxStyle.Information, "Información")
                '    txtChofer.BackColor = Color.Red
                '    txtChofer.Focus()
                '    Return False
            ElseIf toBlank(txtRuc.Text) = "" Then
                MsgBox("Debe Ingresar el RUC o DNI del transportista.", MsgBoxStyle.Information, "Información")
                txtRuc.BackColor = Color.Red
                txtRuc.Focus()
                Return False
            ElseIf state_button = True And oFacturaService.Estado(IdFactura) <> "GENERADO" And oFacturaService.Estado(IdFactura) <> "APROBADO" And oFacturaService.Estado(IdFactura) <> "CREDITOS" Then
                MsgBox("La Factura ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
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
            If oTransportistaService.BuscarFactura(IdFactura) Then
                registro = oTransportistaService.MostrarPorId(oTransportistaService.MostrarIdTransportistaFactura(IdFactura))

                IdTransportista = registro.IdTransportista
                txtEmpresa.Text = registro.Empresa
                txtDireccion.Text = registro.Direccion
                txtRuc.Text = registro.Ruc
                txtVehiculo.Text = registro.Vehiculo
                txtPlaca.Text = registro.Placa
                txtChofer.Text = registro.Chofer
                txtLicencia.Text = registro.Licencia
                txtConIns.Text = registro.ConIns
                IdFactura = registro.Factura.IdFactura

                state_button = True
            Else
                state_button = False
            End If

            estado = oFacturaService .Estado(IdFactura)

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
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
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New TransportistaService.Transportista
            Dim Factura As New TransportistaService.Factura


            registro.IdTransportista = IdTransportista
            registro.Empresa = txtEmpresa.Text
            registro.Direccion = txtDireccion.Text
            registro.Ruc = txtRuc.Text
            registro.Vehiculo = txtVehiculo.Text
            registro.Placa = txtPlaca.Text
            registro.Chofer = txtChofer.Text
            registro.Licencia = txtLicencia.Text
            registro.ConIns = txtConIns.Text
            registro.TipoDocumentoId = Nothing
            registro.GuiaRemision = Nothing
            registro.Boleta = Nothing
            Factura.IdFactura = IdFactura
            registro.Factura = Factura

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub cbTransportista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTransportista.CheckedChanged
        Try
            If cbTransportista.Checked Then
                txtEmpresa.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp)
                txtRuc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp)
                txtDireccion.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DirEmp", "CodEmp", Session.sCodEmp)
            Else
                txtEmpresa.Text = ""
                txtRuc.Text = ""
                txtDireccion.Text = ""
            End If

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
