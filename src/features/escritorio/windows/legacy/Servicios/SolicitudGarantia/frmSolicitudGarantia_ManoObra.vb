Imports System.ServiceModel

Public Class frmSolicitudGarantia_ManoObra

    '===========================Servicios====================================
    Private oSolicitudGarantiaHorasService As New SolicitudGarantiaHorasService.SolicitudGarantiaHorasServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient


    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdMarca As Integer
    Public Actualizar As Boolean
    Public Nuevo As Boolean


    Public IdHoraExtra As Integer
    Public IdAfa As Integer
    Public IdPer As Integer
    Public Fecha As DateTime
    Private dtTipoHrsExt As DataTable
    Private estadocalculo As Boolean = False
    Private TipoCalculo As Integer
    Private Oficinas As String
    Private dtDetalles As New DataTable
    Private dtHorarios As DataTable

    Private Sub frmSolicitudGarantia_ManoObra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGarantiaHorasService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSolicitudGarantiaHorasService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaHorasService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudGarantia_ManoObra_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudGarantia_ManoObra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LlenarCombo()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            estadocalculo = True
        Else                          'Nuevo
            estadocalculo = False
            txtHoraInicio.Text = "00:00"
            txtHoraFin.Text = "00:00"
            txtCantHoras.Text = 0
            txtInicioKm.Text = ""
            txtFinKm.Text = ""
            txtTotalKm.Value = 0.00
            activar()
            estadocalculo = True
        End If
    End Sub

    Private Sub LlenarCombo()
        Try

            ''======================================= TIPOS DE HORA EXTRA ===========================================
            dtTipoHrsExt = oPlanillaSueldosDetService.MostrarTipoHoraExtra(Session.sCodEmp).Tables(0)
            cmbTipoHoraExtra.DataSource = dtTipoHrsExt
            cmbTipoHoraExtra.DropDownList.DataMember = dtTipoHrsExt.Columns("DesHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.DisplayMember = dtTipoHrsExt.Columns("DesHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.ValueMember = dtTipoHrsExt.Columns("IdHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.Columns(0).DataMember = dtTipoHrsExt.Columns("IdHoraExtra").ToString
            cmbTipoHoraExtra.DropDownList.Columns(1).DataMember = dtTipoHrsExt.Columns("DesHoraExtra").ToString
            cmbTipoHoraExtra.SelectedIndex = 0
            dtTipoHrsExt = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As SolicitudGarantiaHorasService.SolicitudGarantiaHoras
            registro = oSolicitudGarantiaHorasService.Obtener(toNumber(IdAfa), toNumber(IdPer), Fecha, toNumber(IdHoraExtra))

            IdPer = registro.Persona.IdPer
            txtSolicitante.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha

            txtHoraInicio.Text = registro.HoraInicio.ToString("HH:mm:ss")
            txtHoraFin.Text = registro.HoraFin.ToString("HH:mm:ss")
            txtCantHoras.Text = registro.CantHoras

            'Dim hola1 As Double
            'If Not String.IsNullOrEmpty(txtInicioKm.Text) Then
            '    hola1 = CDbl(txtInicioKm.Text)
            'Else
            '    hola1 = 0
            'End If

            'txtInicioKm.Text = hola1

            'Dim inikm, finkm As Double
            'inikm = registro.InicioKm
            'finkm = registro.FinalKm

            txtInicioKm.Text = registro.InicioKm
            txtFinKm.Text = registro.FinalKm
            txtTotalKm.Text = registro.TotalKm

            cmbTipoHoraExtra.Value = registro.TipoHoraExtra.IdHoraExtra

            txtConductor.Text = registro.Conductor

            txtObservacion.Text = registro.DesActividad

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()

        btnBuscarPersona.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbTipoHoraExtra.ReadOnly = True
        cmbTipoHoraExtra.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub activar()

        btnBuscarPersona.Enabled = True
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbTipoHoraExtra.ReadOnly = False
        cmbTipoHoraExtra.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If ValidaCampos() Then

                Dim registro As New SolicitudGarantiaHorasService.SolicitudGarantiaHoras
                Dim solicitudgarantia As New SolicitudGarantiaHorasService.SolicitudGarantia

                Dim tipohoraextra As New SolicitudGarantiaHorasService.TipoHoraExtra
                Dim persona As New SolicitudGarantiaHorasService.Persona

                solicitudgarantia.IdAfa = toNull(IdAfa)
                registro.SolicitudGarantia = solicitudgarantia
                registro.Fecha = txtFecha.Value

                persona.IdPer = IdPer
                registro.Persona = persona

                tipohoraextra.IdHoraExtra = cmbTipoHoraExtra.Value

                registro.TipoHoraExtra = tipohoraextra

                If cmbTipoHoraExtra.Value = 1 Then

                    registro.HoraInicio = txtHoraInicio.Text
                    registro.HoraFin = txtHoraFin.Text
                    registro.CantHoras = txtCantHoras.Text

                    registro.InicioKm = txtInicioKm.Text
                    registro.FinalKm = txtFinKm.Text
                    registro.TotalKm = txtTotalKm.Text

                    registro.Conductor = txtConductor.Text

                Else

                    registro.HoraInicio = txtHoraInicio.Text
                    registro.HoraFin = txtHoraFin.Text
                    registro.CantHoras = txtCantHoras.Text

                    registro.InicioKm = Nothing
                    registro.FinalKm = Nothing
                    registro.TotalKm = Nothing

                    registro.Conductor = Nothing

                End If

                registro.DesActividad = toNull(txtObservacion.Text)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If cmbTipoHoraExtra.Value = 1 Then

                If toBlank(txtSolicitante.Text) = "" Then
                    MsgBox("Debe ingresar el personal", MsgBoxStyle.Information, "Información")
                    txtHoraInicio.BackColor = Color.Red
                    txtHoraInicio.Focus()
                    Return False
                    'ElseIf toBlank(txtInicioKm.Text) = "" Then
                    '    MsgBox("Debe ingresar el inicio km.", MsgBoxStyle.Information, "Información")
                    '    txtInicioKm.BackColor = Color.Red
                    '    txtInicioKm.Focus()
                    '    Return False
                    'ElseIf toBlank(txtFinKm.Text) = "" Then
                    '    MsgBox("Debe ingresar el final km. ", MsgBoxStyle.Information, "Información")
                    '    txtFinKm.BackColor = Color.Red
                    '    txtFinKm.Focus()
                    '    Return False
                ElseIf toBlank(txtHoraInicio.Text) = "" Then
                    MsgBox("Debe ingresar la hora de inicio", MsgBoxStyle.Information, "Información")
                    txtHoraInicio.BackColor = Color.Red
                    txtHoraInicio.Focus()
                    Return False
                ElseIf toBlank(txtHoraFin.Text) = "" Then
                    MsgBox("Debe ingresar la hora final ", MsgBoxStyle.Information, "Información")
                    txtHoraFin.BackColor = Color.Red
                    txtHoraFin.Focus()
                    Return False
                Else
                    Return True
                End If
            Else
                If toBlank(txtSolicitante.Text) = "" Then
                    MsgBox("Debe ingresar el personal", MsgBoxStyle.Information, "Información")
                    txtHoraInicio.BackColor = Color.Red
                    txtHoraInicio.Focus()
                    Return False
                ElseIf toBlank(txtHoraInicio.Text) = "" Then
                    MsgBox("Debe ingresar la hora de inicio", MsgBoxStyle.Information, "Información")
                    txtHoraInicio.BackColor = Color.Red
                    txtHoraInicio.Focus()
                    Return False
                ElseIf toBlank(txtHoraFin.Text) = "" Then
                    MsgBox("Debe ingresar la hora final ", MsgBoxStyle.Information, "Información")
                    txtHoraFin.BackColor = Color.Red
                    txtHoraFin.Focus()
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub Insertar(ByVal registro As SolicitudGarantiaHorasService.SolicitudGarantiaHoras)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGarantiaHorasService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                'IdHoraExtra = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGarantiaHorasService.SolicitudGarantiaHoras)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGarantiaHorasService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(sender As Object, e As EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPer = frm.codigo
                    txtSolicitante.Text = frm.descripcion
                Else
                    IdPer = 0
                    txtSolicitante.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtHoraInicio_TextChanged(sender As Object, e As EventArgs) Handles txtHoraInicio.TextChanged, txtHoraFin.TextChanged



        'If txtHoraInicio.TextLength = 5 And txtHoraFin.TextLength = 5 Then

        '    If estadocalculo = True Then

        '        If txtHoraInicio.Text <> "" And txtHoraFin.Text <> "" Then

        '            Dim firstDate As DateTime
        '            Dim secondDate As DateTime

        '            firstDate = txtHoraInicio.Text
        '            secondDate = txtHoraFin.Text

        '            Dim diff As TimeSpan = secondDate - firstDate
        '            'TimeSpan diff = secondDate - firstDate;
        '            Dim hours As Double
        '            hours = diff.TotalHours

        '            txtCantHoras.Text = hours
        '        End If
        '    End If
        'End If

    End Sub

    'Private Sub txtInicioKm_TextChanged(sender As Object, e As EventArgs) Handles txtFinKm.TextChanged

    '    If txtInicioKm.Text <> "0" And txtFinKm.Text <> "0" Then

    '        Dim iniciokm As Double
    '        Dim finalkm As Double

    '        iniciokm = txtInicioKm.Text
    '        finalkm = txtFinKm.Text

    '        Dim diff As Double = iniciokm - finalkm

    '        If iniciokm > finalkm Then
    '            txtTotalKm.Text = diff
    '        ElseIf finalkm > iniciokm Then
    '            txtTotalKm.Text = diff * -1
    '        End If

    '    End If
    'End Sub

    Private Sub cmbTipoHoraExtra_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoHoraExtra.ValueChanged

        If cmbTipoHoraExtra.Value = 1 Then
            lbliniciokm.Visible = True
            txtInicioKm.Visible = True
            txtInicioKm.ReadOnly = False
            lblfinkm.Visible = True
            txtFinKm.Visible = True
            txtFinKm.ReadOnly = False
            lbltotalkm.Visible = True
            txtTotalKm.Visible = True
            txtTotalKm.ReadOnly = False
            lblConductor.Visible = True
            txtConductor.Visible = True
            txtConductor.ReadOnly = False
            'lblHoraIn.Visible = False
            'txtHoraInicio.Visible = False
            'txtHoraInicio.ReadOnly = True
            'lblHoraFin.Visible = False
            'txtHoraFin.Visible = False
            'txtHoraFin.ReadOnly = True
            'lblCanHoras.Visible = False
            'txtCantHoras.Visible = False
            'txtCantHoras.ReadOnly = True
        Else
            lbliniciokm.Visible = False
            txtInicioKm.Visible = False
            txtInicioKm.ReadOnly = True
            lblfinkm.Visible = False
            txtFinKm.Visible = False
            txtFinKm.ReadOnly = True
            lbltotalkm.Visible = False
            txtTotalKm.Visible = False
            txtTotalKm.ReadOnly = False
            lblConductor.Visible = False
            txtConductor.Visible = False
            txtConductor.ReadOnly = True

            lblHoraIn.Visible = True
            txtHoraInicio.Visible = True
            txtHoraInicio.ReadOnly = False
            lblHoraFin.Visible = True
            txtHoraFin.Visible = True
            txtHoraFin.ReadOnly = False
            lblCanHoras.Visible = True
            txtCantHoras.Visible = True
            txtCantHoras.ReadOnly = True

        End If

    End Sub

    'Private Sub txtHoraInicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoraInicio.KeyPress

    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        'e.Handled = True
    '        'txtHoraInicio.Focus()
    '        If estadocalculo = True Then
    '            If txtHoraInicio.Text <> "" And txtHoraFin.Text <> "" Then
    '                Dim firstDate As DateTime
    '                Dim secondDate As DateTime

    '                firstDate = txtHoraInicio.Text
    '                secondDate = txtHoraFin.Text

    '                Dim diff As TimeSpan = secondDate - firstDate
    '                'TimeSpan diff = secondDate - firstDate;
    '                Dim hours As Double
    '                hours = diff.TotalHours

    '                txtCantHoras.Text = hours
    '            End If
    '        End If
    '    End If

    'End Sub

    'Private Sub txtHoraFin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoraFin.KeyPress

    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        'e.Handled = True
    '        'txtHoraInicio.Focus()
    '        If estadocalculo = True Then
    '            If txtHoraInicio.Text <> "" And txtHoraFin.Text <> "" Then
    '                Dim firstDate As DateTime
    '                Dim secondDate As DateTime
    '                firstDate = txtHoraInicio.Text
    '                secondDate = txtHoraFin.Text

    '                Dim diff As TimeSpan = secondDate - firstDate
    '                'TimeSpan diff = secondDate - firstDate;
    '                Dim hours As Double
    '                hours = diff.TotalHours

    '                txtCantHoras.Text = hours
    '            End If
    '        End If

    '    End If

    'End Sub

    Private Sub txtHoraInicio_Leave(sender As Object, e As EventArgs) Handles txtHoraInicio.Leave
        If estadocalculo = True Then
            If txtHoraInicio.Text <> "" And txtHoraFin.Text <> "" Then
                Dim firstDate As DateTime
                Dim secondDate As DateTime

                firstDate = txtHoraInicio.Text
                secondDate = txtHoraFin.Text

                Dim diff As TimeSpan = secondDate - firstDate
                'TimeSpan diff = secondDate - firstDate;
                Dim hours As Double
                hours = diff.TotalHours

                txtCantHoras.Text = hours
            End If
        End If
    End Sub

    Private Sub txtHoraFin_Leave(sender As Object, e As EventArgs) Handles txtHoraFin.Leave
        If estadocalculo = True Then
            If txtHoraInicio.Text <> "" And txtHoraFin.Text <> "" Then
                Dim firstDate As DateTime
                Dim secondDate As DateTime
                firstDate = txtHoraInicio.Text
                secondDate = txtHoraFin.Text

                Dim diff As TimeSpan = secondDate - firstDate
                'TimeSpan diff = secondDate - firstDate;
                Dim hours As Double
                hours = diff.TotalHours

                txtCantHoras.Text = hours
            End If
        End If
    End Sub

    Private Sub txtHoraFin_GotFocus(sender As Object, e As EventArgs) Handles txtHoraFin.GotFocus
        txtHoraFin.SelectAll()
    End Sub
End Class