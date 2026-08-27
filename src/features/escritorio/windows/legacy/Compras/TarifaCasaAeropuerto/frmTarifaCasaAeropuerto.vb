Imports System.ServiceModel
Public Class frmTarifaCasaAeropuerto

    '============================Servicios===================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdPersona As Integer
    Public CodMon As String
    Public CodArea As String
    Private dtMonedas As DataTable
    Private dtAreas As DataTable

    Private Sub frmTarifaCasaAeropuerto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "Tarifa de Taxis de Casa a Empresa / Aeropuerto"
        Else                          'Nuevo
            Me.Text = "Registrar nueva Tarifa"
            activar()
            cmbMoneda.Value = "NS"
        End If

        'biGuardar.Enabled = IIf(Session.CodPerfil = "36" Or Session.CodPerfil = "01", True, False)
        'biEditarr.Enabled = IIf(Session.CodPerfil = "36" Or Session.CodPerfil = "01", True, False)
        'biDeshacerr.Enabled = IIf(Session.CodPerfil = "36" Or Session.CodPerfil = "01", True, False)

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      txtPersona.KeyPress _
                     , cmbMoneda.KeyPress _
                     , txtMontoAeropuerto.KeyPress _
                     , txtMontoEmpresa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComProvisional_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmTarifaGastoViaje_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoDetService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
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

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If (Session.CodPerfil = "36" Or Session.CodPerfil = "01" Or Session.CodPerfil = "27") Then
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
            btnBuscarPersona.Enabled = True
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtMontoEmpresa.ReadOnly = False
            txtMontoEmpresa.BackColor = System.Drawing.SystemColors.Window
            txtMontoAeropuerto.ReadOnly = False
            txtMontoAeropuerto.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtPersona.Focus()
        Else                      'Nuevo
            btnBuscarPersona.Enabled = True
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtMontoEmpresa.ReadOnly = False
            txtMontoEmpresa.BackColor = System.Drawing.SystemColors.Window
            txtMontoAeropuerto.ReadOnly = False
            txtMontoAeropuerto.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtPersona.Focus()
        End If
    End Sub

    Private Sub desactivar()
        btnBuscarPersona.Enabled = False
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtMontoEmpresa.ReadOnly = True
        txtMontoEmpresa.BackColor = System.Drawing.SystemColors.Control
        txtMontoAeropuerto.ReadOnly = True
        txtMontoAeropuerto.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        txtPersona.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtPersona.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toDouble(txtMontoEmpresa.Value) <= 0 Then
                MsgBox("El Monto de Empresa Casa debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoEmpresa.Focus()
                Return False
            ElseIf toDouble(txtMontoAeropuerto.Value) <= 0 Then
                MsgBox("El Monto de Aeropuerto Casa debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoAeropuerto.Focus()
                Return False
                'ElseIf toDouble(txtMontoEmpresa.Value) > toDouble(txtMontoAeropuerto.Value) Then
                '    MsgBox("El monto Mínimo no debe ser mayor al Máximo.", MsgBoxStyle.Information, "Información")
                '    txtMontoEmpresa.Focus()
                '    Return False
                'ElseIf toDouble(txtMontoAeropuerto.Value) < toDouble(txtMontoEmpresa.Value) Then
                '    MsgBox("El monto Máximo no debe ser menor al Mínimo.", MsgBoxStyle.Information, "Información")
                '    txtMontoAeropuerto.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoDetService.TarifaCasaAeropuerto
            registro = oSolicitudGastoDetService.ObtenerTarifaCasaAeropuerto(IdPersona)

            IdPersona = registro.Persona.IdPer
            txtPersona.Text = registro.Persona.ApeNom

            ObtenerDatosPersona()

            cmbMoneda.Value = registro.Moneda.CodMon
            txtMontoEmpresa.Value = registro.MontoEmpresa
            txtMontoAeropuerto.Value = registro.MontoMax

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerDatosPersona()
        Try
            If IdPersona <> 0 Then
                Persona = oPersonaService.Obtener(IdPersona)
                cmbArea.Value = Persona.CentroCosto.Area.CodArea
                txtNomVia.Text = Persona.NomVia
                txtDesVia.Text = Persona.TipoVia.DesVia
                txtInterior.Text = Persona.Interior
                txtNomZona.Text = Persona.NomZona
                txtUbigeo.Text = Persona.Ubigeo.Departamento.NomDpto + " - " + Persona.Ubigeo.Provincia.NomProv + " - " + Persona.Ubigeo.Distrito.NomDist
                txtReferencia.Text = Persona.Referencia
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS DE PERSONA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtPersona.Text = frm.descripcion
                    txtMontoEmpresa.Focus()
                Else
                    IdPersona = 0
                    txtPersona.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudGastoDetService.TarifaCasaAeropuerto)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoDetService.InsertarTarifaCasaAeropuerto(registro)
            type_process = "insert"
            If estado_process = True Then
                CodArea = cmbArea.Value
                CodMon = cmbMoneda.Value
                MsgBox("Se inserto la Tarifa Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGastoDetService.TarifaCasaAeropuerto)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoDetService.ActualizarTarifaCasaAeropuerto(registro)
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
            estado_process = oSolicitudGastoDetService.BorrarTarifaCasaAeropuerto(IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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

                    Dim registro As New SolicitudGastoDetService.TarifaCasaAeropuerto
                    Dim Moneda As New SolicitudGastoDetService.Moneda
                    Dim Persona As New SolicitudGastoDetService.Persona

                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    Moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = Moneda
                    registro.MontoEmpresa = txtMontoEmpresa.Value
                    registro.MontoMax = txtMontoAeropuerto.Value

                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        registro.FecReg = Today
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

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersona.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtPersona_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersona.TextChanged
        ObtenerDatosPersona()
    End Sub
End Class