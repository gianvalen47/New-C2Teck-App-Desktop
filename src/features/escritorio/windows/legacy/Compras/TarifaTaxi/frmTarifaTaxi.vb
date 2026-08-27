Imports System.ServiceModel
Public Class frmTarifaTaxi

    '============================Servicios===================================
    Private oPlanillaViaticoService As New PlanillaViaticoService.PlanillaViaticoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdTarifa As Integer
    Private CodUbigeo As String
    Private dtMonedas As DataTable

    Private Sub frmTarifaTaxi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "Tarifa de Taxi"
        Else                          'Nuevo
            Me.Text = "Registrar nueva Tarifa"
            activar()
            cmbMoneda.Value = "NS"
        End If
        txtOrigen.Focus()
        'biGuardar.Enabled = IIf(Session.CodPerfil = "36" Or Session.CodPerfil = "01", True, False)
        'biEditarr.Enabled = IIf(Session.CodPerfil = "36" Or Session.CodPerfil = "01", True, False)
        'biDeshacerr.Enabled = IIf(Session.CodPerfil = "36" Or Session.CodPerfil = "01", True, False)

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   cmbMoneda.KeyPress _
                   , txtOrigen.KeyPress _
                   , txtDestino.KeyPress _
                   , txtUbigeo.KeyPress _
                 , txtMontoVuelta.KeyPress _
                 , txtMontoIda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTarifaTaxi_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmTarifaGastoViaje_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaViaticoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oPlanillaViaticoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oPlanillaViaticoService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If (Session.CodPerfil = "36" Or Session.CodPerfil = "01") Then
            biEditarr.Enabled = IIf(editable, Not edicion, False)
            biCerrar.Enabled = Not edicion
            biGuardar.Enabled = edicion
            biDeshacerr.Enabled = edicion
        Else
            biEditarr.Enabled = False
            biCerrar.Enabled = True
            biGuardar.Enabled = False
            biDeshacerr.Enabled = False
        End If
    End Sub

    Private Sub activar()
        If state_button Then   'Actualizar
            txtOrigen.ReadOnly = False
            txtOrigen.BackColor = System.Drawing.SystemColors.Window
            txtDestino.ReadOnly = False
            txtDestino.BackColor = System.Drawing.SystemColors.Window
            btnUbigeo.Enabled = True
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtMontoIda.ReadOnly = False
            txtMontoIda.BackColor = System.Drawing.SystemColors.Window
            txtMontoVuelta.ReadOnly = False
            txtMontoVuelta.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtOrigen.Focus()
        Else                      'Nuevo
            txtOrigen.ReadOnly = False
            txtOrigen.BackColor = System.Drawing.SystemColors.Window
            txtDestino.ReadOnly = False
            txtDestino.BackColor = System.Drawing.SystemColors.Window
            btnUbigeo.Enabled = True
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtMontoIda.ReadOnly = False
            txtMontoIda.BackColor = System.Drawing.SystemColors.Window
            txtMontoVuelta.ReadOnly = False
            txtMontoVuelta.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtOrigen.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtOrigen.ReadOnly = True
        txtOrigen.BackColor = System.Drawing.SystemColors.Control
        txtDestino.ReadOnly = True
        txtDestino.BackColor = System.Drawing.SystemColors.Control
        btnUbigeo.Enabled = False
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtMontoIda.ReadOnly = True
        txtMontoIda.BackColor = System.Drawing.SystemColors.Control
        txtMontoVuelta.ReadOnly = True
        txtMontoVuelta.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        txtOrigen.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtOrigen.Text = "" Then
                MsgBox("Debe Ingresar el Origen.", MsgBoxStyle.Information, "Información")
                btnUbigeo.Focus()
                Return False
            ElseIf txtDestino.Text = "" Then
                MsgBox("Debe Ingresar el Destino.", MsgBoxStyle.Information, "Información")
                btnUbigeo.Focus()
                Return False
            ElseIf CodUbigeo = "" Then
                MsgBox("Debe Ingresar el Ubigeo de la Tarifa.", MsgBoxStyle.Information, "Información")
                btnUbigeo.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toDouble(txtMontoIda.Value) <= 0 Then
                MsgBox("La tarifa ida debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoIda.Focus()
                Return False
            ElseIf toDouble(txtMontoVuelta.Value) <= 0 Then
                MsgBox("La tarifa vuelta debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoVuelta.Focus()
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
            Dim registro As PlanillaViaticoService.TarifaTaxi
            registro = oPlanillaViaticoService.ObtenerTaxi(IdTarifa)

            IdTarifa = registro.IdTarifa
            txtOrigen.Text = registro.Origen
            txtDestino.Text = registro.Destino
            CodUbigeo = registro.Ubigeo.CodUbigeo
            txtUbigeo.Text = registro.Ubigeo.Departamento.NomDpto & " - " & toBlank(registro.Ubigeo.Provincia.NomProv) & " - " & toBlank(registro.Ubigeo.Distrito.NomDist)
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMontoIda.Value = registro.TarifaIda
            txtMontoVuelta.Value = registro.TarifaVuelta

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaViaticoService.TarifaTaxi)
        Try
            Dim estado_process As Integer
            estado_process = oPlanillaViaticoService.InsertarTaxi(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdTarifa = estado_process
                MsgBox("Se inserto la Tarifa Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaViaticoService.TarifaTaxi)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaViaticoService.ActualizarTaxi(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Tarifa Correctamente")
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaViaticoService.BorrarTaxi(IdTarifa, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New PlanillaViaticoService.TarifaTaxi
                    Dim Moneda As New PlanillaViaticoService.Moneda
                    Dim ubigeo As New PlanillaViaticoService.Ubigeo

                    registro.IdTarifa = IdTarifa
                    registro.Origen = txtOrigen.Text
                    registro.Destino = txtDestino.Text
                    ubigeo.CodUbigeo = CodUbigeo
                    registro.Ubigeo = ubigeo
                    Moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = Moneda
                    registro.TarifaIda = txtMontoIda.Value
                    registro.TarifaVuelta = txtMontoVuelta.Value

                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR TARIFA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub btnUbigeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbigeo.Click
        Dim frm As New frmBuscarUbigeo
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodUbigeo = frm.CodUbigeo
            txtUbigeo.BackColor = System.Drawing.SystemColors.Control
            txtUbigeo.Text = frm.Nombre
        End If
        txtUbigeo.Select()
    End Sub


    Private Sub txtUbigeo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbigeo.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnUbigeo.Enabled = True Then
                btnUbigeo_Click(sender, e)
            End If
        End If
    End Sub

End Class