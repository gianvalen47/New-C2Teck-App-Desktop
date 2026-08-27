Imports System.ServiceModel
Public Class frmParametrosPlanilla_Nuevo

    Private oParametrosPlanillaService As New ParametrosPlanillaService.ParametrosPlanillaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtMonedas As DataTable
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdLocacion As String


    Public CodEmp As String
    Public DesEmp As String


    Private Sub frmParametrosPlanilla_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtDesEmp.Text = DesEmp

        'llenarCombos()
        If state_button Then    'Modificar            
            LimpiarCampos()
            ObtenerRegistro()
            desactivar()
            'Me.Text = "Parametro Locacion " + Chr(34) + txtIdLocacion.Text.ToString + Chr(34)
        Else 'Nuevo
            'cbActivo.Checked = True
            'txtIdLocacion.Focus()
            LimpiarCampos()
            activar()
            Me.Size = New System.Drawing.Size(733, 739)
            Me.Text = "Registrar nuevo Parametro Planilla"
            'txtIgv.Text = "0"
            'SugerirNumero()
        End If
    End Sub

    Private Sub frmParametrosPlanilla_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub frmParametrosPlanilla_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oParametrosPlanillaService.Close()
        Catch ex As TimeoutException
            oParametrosPlanillaService.Abort()
        Catch ex As CommunicationException
            oParametrosPlanillaService.Abort()
        End Try
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LimpiarCampos()

        txtSNP.Text = ""
        txtEsSalud.Text = ""
        txtMinTardanza.Text = ""
        txtSancionHora.Text = ""
        txtHoraLaboral.Text = ""
        txtHoraReal.Text = ""
        txtSaludVida.Text = ""
        txtLimiteRefrigerio.Text = ""
        txtLimiteCena.Text = ""
        txtSueldoMinimo.Text = ""
        txtIdRubroSNP.Text = ""
        txtIdRubroVida.Text = ""
        txtIdRubroAsigFamiliar.Text = ""
        txtIdRubroMovilidad.Text = ""
        txtIdRubroSueldoGrati.Text = ""
        txtIdRubroAsigFamiliarGrati.Text = ""
        txtIdRubroHoraExtraGrati.Text = ""
        txtIdRubroComisionGrati.Text = ""
        txtIdRubroBonoGrati.Text = ""
        txtIdRubroBonoLeyGrati.Text = ""
        txtIdRubroVacaciones.Text = ""
        txtIdRubroAporteAfp.Text = ""
        txtIdRubroTopePrima.Text = ""
        txtIdRubroComisionAfp.Text = ""
        txtIdRubroQuinta.Text = ""
        txtIdHoraExtraNormal.Text = ""
        txtIdHoraExtra25.Text = ""
        txtIdHoraExtra35.Text = ""
        txtIdHoraExtra100.Text = ""
        txtIdRubroPermiso.Text = ""
        txtIdRubroTardanza.Text = ""
        txtIdRubroComision.Text = ""
        txtIdRubroBonificacion.Text = ""
        txtIdRubroCTS.Text = ""
        txtIdRubroHoraExtra25.Text = ""
        txtIdRubroHoraExtra35.Text = ""
        txtIdRubroHoraExtra100.Text = ""
        txtIdRubroPromedioHoraExtra.Text = ""
        txtIdRubroCompraVacaciones.Text = ""
        txtCorEmisor.Text = ""
        txtClaveCorEmisor.Text = ""
        txtMailHost.Text = ""

    End Sub

    Private Sub ObtenerRegistro()

        Try

            Dim registro As ParametrosPlanillaService.ParametrosPlanilla
            registro = oParametrosPlanillaService.Obtener(CodEmp)

            txtSNP.Text = registro.SNP
            txtEsSalud.Text = registro.EsSalud
            txtMinTardanza.Text = registro.MinTardanza
            txtSancionHora.Text = registro.SancionHora
            txtHoraLaboral.Text = registro.HoraLaboral
            txtHoraReal.Text = registro.HoraReal
            txtSaludVida.Text = registro.SaludVida
            txtLimiteRefrigerio.Text = registro.LimiteRefrigerio.ToString()
            txtLimiteCena.Text = registro.LimiteCena.ToString()
            txtSueldoMinimo.Text = registro.SueldoMinimo
            txtIdRubroSNP.Text = registro.IdRubroSNP
            txtIdRubroVida.Text = registro.IdRubroVida
            txtIdRubroAsigFamiliar.Text = registro.IdRubroAsigFamiliar
            txtIdRubroMovilidad.Text = registro.IdRubroMovilidad
            txtIdRubroSueldoGrati.Text = registro.IdRubroSueldoGrati
            txtIdRubroAsigFamiliarGrati.Text = registro.IdRubroAsigFamiliarGrati
            txtIdRubroHoraExtraGrati.Text = registro.IdRubroHoraExtraGrati
            txtIdRubroComisionGrati.Text = registro.IdRubroComisionGrati
            txtIdRubroBonoGrati.Text = registro.IdRubroBonoGrati
            txtIdRubroBonoLeyGrati.Text = registro.IdRubroBonoLeyGrati
            txtIdRubroVacaciones.Text = registro.IdRubroVacaciones
            txtIdRubroAporteAfp.Text = registro.IdRubroAporteAfp
            txtIdRubroTopePrima.Text = registro.IdRubroTopePrima
            txtIdRubroComisionAfp.Text = registro.IdRubroComisionAfp

            txtIdRubroQuinta.Text = registro.IdRubroQuinta
            txtIdHoraExtraNormal.Text = registro.IdHoraExtraNormal
            txtIdHoraExtra25.Text = registro.IdHoraExtra25
            txtIdHoraExtra35.Text = registro.IdHoraExtra35
            txtIdHoraExtra100.Text = registro.IdHoraExtra100
            txtIdRubroPermiso.Text = registro.IdRubroPermiso
            txtIdRubroTardanza.Text = registro.IdRubroTardanza
            txtIdRubroComision.Text = registro.IdRubroComision
            txtIdRubroBonificacion.Text = registro.IdRubroBonificacion
            txtIdRubroCTS.Text = registro.IdRubroCTS
            txtIdRubroHoraExtra25.Text = registro.IdRubroHoraExtra25
            txtIdRubroHoraExtra35.Text = registro.IdRubroHoraExtra35
            txtIdRubroHoraExtra100.Text = registro.IdRubroHoraExtra100
            txtIdRubroPromedioHoraExtra.Text = registro.IdRubroHoraExtra
            txtIdRubroCompraVacaciones.Text = registro.IdRubroCompraVacaciones

            Me.pbFoto.Image = utils.ByteArrayToImage(registro.Firma)

            txtCorEmisor.Text = registro.CorreoEmisor
            txtClaveCorEmisor.Text = registro.ClaveCorreoEmisor
            txtMailHost.Text = registro.MailHost

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        txtSNP.ReadOnly = True
        txtSNP.BackColor = System.Drawing.SystemColors.Control
        txtEsSalud.ReadOnly = True
        txtEsSalud.BackColor = System.Drawing.SystemColors.Control
        txtMinTardanza.ReadOnly = True
        txtMinTardanza.BackColor = System.Drawing.SystemColors.Control
        txtSancionHora.ReadOnly = True
        txtSancionHora.BackColor = System.Drawing.SystemColors.Control
        txtHoraLaboral.ReadOnly = True
        txtHoraLaboral.BackColor = System.Drawing.SystemColors.Control
        txtHoraReal.ReadOnly = True
        txtHoraReal.BackColor = System.Drawing.SystemColors.Control

        txtSaludVida.ReadOnly = True
        txtSaludVida.BackColor = System.Drawing.SystemColors.Control
        txtLimiteRefrigerio.ReadOnly = True
        txtLimiteRefrigerio.BackColor = System.Drawing.SystemColors.Control
        txtLimiteCena.ReadOnly = True
        txtLimiteCena.BackColor = System.Drawing.SystemColors.Control
        txtSueldoMinimo.ReadOnly = True
        txtSueldoMinimo.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroSNP.ReadOnly = True
        txtIdRubroSNP.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroVida.ReadOnly = True
        txtIdRubroVida.BackColor = System.Drawing.SystemColors.Control

        txtIdRubroAsigFamiliar.ReadOnly = True
        txtIdRubroAsigFamiliar.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroMovilidad.ReadOnly = True
        txtIdRubroMovilidad.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroSueldoGrati.ReadOnly = True
        txtIdRubroSueldoGrati.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroAsigFamiliarGrati.ReadOnly = True
        txtIdRubroAsigFamiliarGrati.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroHoraExtraGrati.ReadOnly = True
        txtIdRubroHoraExtraGrati.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroComisionGrati.ReadOnly = True
        txtIdRubroComisionGrati.BackColor = System.Drawing.SystemColors.Control

        txtIdRubroBonoGrati.ReadOnly = True
        txtIdRubroBonoGrati.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroBonoLeyGrati.ReadOnly = True
        txtIdRubroBonoLeyGrati.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroVacaciones.ReadOnly = True
        txtIdRubroVacaciones.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroAporteAfp.ReadOnly = True
        txtIdRubroAporteAfp.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroTopePrima.ReadOnly = True
        txtIdRubroTopePrima.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroComisionAfp.ReadOnly = True
        txtIdRubroComisionAfp.BackColor = System.Drawing.SystemColors.Control

        txtIdRubroQuinta.ReadOnly = True
        txtIdRubroQuinta.BackColor = System.Drawing.SystemColors.Control
        txtIdHoraExtraNormal.ReadOnly = True
        txtIdHoraExtraNormal.BackColor = System.Drawing.SystemColors.Control
        txtIdHoraExtra25.ReadOnly = True
        txtIdHoraExtra25.BackColor = System.Drawing.SystemColors.Control
        txtIdHoraExtra35.ReadOnly = True
        txtIdHoraExtra35.BackColor = System.Drawing.SystemColors.Control
        txtIdHoraExtra100.ReadOnly = True
        txtIdHoraExtra100.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroPromedioHoraExtra.ReadOnly = True
        txtIdRubroPromedioHoraExtra.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroPermiso.ReadOnly = True
        txtIdRubroPermiso.BackColor = System.Drawing.SystemColors.Control

        txtIdRubroTardanza.ReadOnly = True
        txtIdRubroTardanza.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroComision.ReadOnly = True
        txtIdRubroComision.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroBonificacion.ReadOnly = True
        txtIdRubroBonificacion.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroCTS.ReadOnly = True
        txtIdRubroCTS.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroHoraExtra25.ReadOnly = True
        txtIdRubroHoraExtra25.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroHoraExtra35.ReadOnly = True
        txtIdRubroHoraExtra35.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroHoraExtra100.ReadOnly = True
        txtIdRubroHoraExtra100.BackColor = System.Drawing.SystemColors.Control
        txtIdRubroCompraVacaciones.ReadOnly = True
        txtIdRubroCompraVacaciones.BackColor = System.Drawing.SystemColors.Control

        txtCorEmisor.ReadOnly = True
        txtCorEmisor.BackColor = System.Drawing.SystemColors.Control
        txtClaveCorEmisor.ReadOnly = True
        txtClaveCorEmisor.BackColor = System.Drawing.SystemColors.Control
        txtMailHost.ReadOnly = True
        txtMailHost.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        txtSNP.ReadOnly = False
        txtSNP.BackColor = System.Drawing.SystemColors.Window
        txtEsSalud.ReadOnly = False
        txtEsSalud.BackColor = System.Drawing.SystemColors.Window
        txtMinTardanza.ReadOnly = False
        txtMinTardanza.BackColor = System.Drawing.SystemColors.Window
        txtSancionHora.ReadOnly = False
        txtSancionHora.BackColor = System.Drawing.SystemColors.Window
        txtHoraLaboral.ReadOnly = False
        txtHoraLaboral.BackColor = System.Drawing.SystemColors.Window
        txtHoraReal.ReadOnly = False
        txtHoraReal.BackColor = System.Drawing.SystemColors.Window

        txtSaludVida.ReadOnly = False
        txtSaludVida.BackColor = System.Drawing.SystemColors.Window
        txtLimiteRefrigerio.ReadOnly = False
        txtLimiteRefrigerio.BackColor = System.Drawing.SystemColors.Window
        txtLimiteCena.ReadOnly = False
        txtLimiteCena.BackColor = System.Drawing.SystemColors.Window
        txtSueldoMinimo.ReadOnly = False
        txtSueldoMinimo.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroSNP.ReadOnly = False
        txtIdRubroSNP.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroVida.ReadOnly = False
        txtIdRubroVida.BackColor = System.Drawing.SystemColors.Window

        txtIdRubroAsigFamiliar.ReadOnly = False
        txtIdRubroAsigFamiliar.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroMovilidad.ReadOnly = False
        txtIdRubroMovilidad.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroSueldoGrati.ReadOnly = False
        txtIdRubroSueldoGrati.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroAsigFamiliarGrati.ReadOnly = False
        txtIdRubroAsigFamiliarGrati.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroHoraExtraGrati.ReadOnly = False
        txtIdRubroHoraExtraGrati.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroComisionGrati.ReadOnly = False
        txtIdRubroComisionGrati.BackColor = System.Drawing.SystemColors.Window

        txtIdRubroBonoGrati.ReadOnly = False
        txtIdRubroBonoGrati.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroBonoLeyGrati.ReadOnly = False
        txtIdRubroBonoLeyGrati.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroVacaciones.ReadOnly = False
        txtIdRubroVacaciones.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroAporteAfp.ReadOnly = False
        txtIdRubroAporteAfp.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroTopePrima.ReadOnly = False
        txtIdRubroTopePrima.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroComisionAfp.ReadOnly = False
        txtIdRubroComisionAfp.BackColor = System.Drawing.SystemColors.Window

        txtIdRubroQuinta.ReadOnly = False
        txtIdRubroQuinta.BackColor = System.Drawing.SystemColors.Window
        txtIdHoraExtraNormal.ReadOnly = False
        txtIdHoraExtraNormal.BackColor = System.Drawing.SystemColors.Window
        txtIdHoraExtra25.ReadOnly = False
        txtIdHoraExtra25.BackColor = System.Drawing.SystemColors.Window
        txtIdHoraExtra35.ReadOnly = False
        txtIdHoraExtra35.BackColor = System.Drawing.SystemColors.Window
        txtIdHoraExtra100.ReadOnly = False
        txtIdHoraExtra100.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroPromedioHoraExtra.ReadOnly = False
        txtIdRubroPromedioHoraExtra.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroPermiso.ReadOnly = False
        txtIdRubroPermiso.BackColor = System.Drawing.SystemColors.Window

        txtIdRubroTardanza.ReadOnly = False
        txtIdRubroTardanza.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroComision.ReadOnly = False
        txtIdRubroComision.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroBonificacion.ReadOnly = False
        txtIdRubroBonificacion.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroCTS.ReadOnly = False
        txtIdRubroCTS.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroHoraExtra25.ReadOnly = False
        txtIdRubroHoraExtra25.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroHoraExtra35.ReadOnly = False
        txtIdRubroHoraExtra35.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroHoraExtra100.ReadOnly = False
        txtIdRubroHoraExtra100.BackColor = System.Drawing.SystemColors.Window
        txtIdRubroCompraVacaciones.ReadOnly = False
        txtIdRubroCompraVacaciones.BackColor = System.Drawing.SystemColors.Window

        txtCorEmisor.ReadOnly = False
        txtCorEmisor.BackColor = System.Drawing.SystemColors.Window
        txtClaveCorEmisor.ReadOnly = False
        txtClaveCorEmisor.BackColor = System.Drawing.SystemColors.Window
        txtMailHost.ReadOnly = False
        txtMailHost.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New ParametrosPlanillaService.ParametrosPlanilla
                Dim empresa As New ParametrosPlanillaService.Empresa

                empresa.CodEmp = CodEmp
                registro.Empresa = empresa
                registro.SNP = txtSNP.Text
                registro.EsSalud = txtEsSalud.Text
                registro.MinTardanza = txtMinTardanza.Text
                registro.SancionHora = txtSancionHora.Text
                registro.HoraLaboral = txtHoraLaboral.Text
                registro.HoraReal = txtHoraReal.Text
                registro.SaludVida = txtSaludVida.Text
                registro.LimiteRefrigerio = txtLimiteRefrigerio.Text
                registro.LimiteCena = txtLimiteCena.Text
                registro.SueldoMinimo = txtSueldoMinimo.Text
                registro.IdRubroSNP = txtIdRubroSNP.Text
                registro.IdRubroVida = txtIdRubroVida.Text
                registro.IdRubroAsigFamiliar = txtIdRubroAsigFamiliar.Text
                registro.IdRubroMovilidad = txtIdRubroMovilidad.Text
                registro.IdRubroSueldoGrati = txtIdRubroSueldoGrati.Text
                registro.IdRubroAsigFamiliarGrati = txtIdRubroAsigFamiliarGrati.Text
                registro.IdRubroHoraExtraGrati = txtIdRubroHoraExtraGrati.Text
                registro.IdRubroComisionGrati = txtIdRubroComisionGrati.Text
                registro.IdRubroBonoGrati = txtIdRubroBonoGrati.Text
                registro.IdRubroBonoLeyGrati = txtIdRubroBonoLeyGrati.Text
                registro.IdRubroVacaciones = txtIdRubroVacaciones.Text
                registro.IdRubroAporteAfp = txtIdRubroAporteAfp.Text
                registro.IdRubroTopePrima = txtIdRubroTopePrima.Text
                registro.IdRubroComisionAfp = txtIdRubroComisionAfp.Text

                registro.IdRubroQuinta = txtIdRubroQuinta.Text
                registro.IdHoraExtraNormal = txtIdHoraExtraNormal.Text
                registro.IdHoraExtra25 = txtIdHoraExtra25.Text
                registro.IdHoraExtra35 = txtIdHoraExtra35.Text
                registro.IdHoraExtra100 = txtIdHoraExtra100.Text
                registro.IdRubroPermiso = txtIdRubroPermiso.Text
                registro.IdRubroTardanza = txtIdRubroTardanza.Text
                registro.IdRubroComision = txtIdRubroComision.Text
                registro.IdRubroBonificacion = txtIdRubroBonificacion.Text
                registro.IdRubroCTS = txtIdRubroCTS.Text
                registro.IdRubroHoraExtra25 = txtIdRubroHoraExtra25.Text
                registro.IdRubroHoraExtra35 = txtIdRubroHoraExtra35.Text
                registro.IdRubroHoraExtra100 = txtIdRubroHoraExtra100.Text
                registro.IdRubroHoraExtra = txtIdRubroPromedioHoraExtra.Text
                registro.IdRubroCompraVacaciones = txtIdRubroCompraVacaciones.Text

                registro.CorreoEmisor = txtCorEmisor.Text
                registro.ClaveCorreoEmisor = txtClaveCorEmisor.Text
                registro.MailHost = txtMailHost.Text

                registro.Firma = utils.ImageToByteArray(pbFoto.Image)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                'If rbInsertar.Checked Then
                '    state_button = False
                'ElseIf rbActualizar.Checked Then
                '    state_button = True
                'End If

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(txtSNP.Text) = "" Then
                MsgBox("Debe Ingresar el Codigo Locacion", MsgBoxStyle.Information, "Información")
                txtSNP.BackColor = Color.Red
                txtSNP.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub Insertar(ByVal registro As ParametrosPlanillaService.ParametrosPlanilla)
        Try
            Dim estado_process As Boolean
            estado_process = oParametrosPlanillaService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el Parametro Planilla correctamente")
                'IdLocacion = txtIdLocacion.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL PARAMETRO PLANILLA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ParametrosPlanillaService.ParametrosPlanilla)
        Try
            Dim estado_process As Boolean
            estado_process = oParametrosPlanillaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL PARAMETRO PLANILLA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarFoto_Click(sender As Object, e As EventArgs) Handles btnBuscarFoto.Click
        Dim file As New OpenFileDialog()
        Dim tamaño As Long
        file.Filter = "Archivos(*.jpg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|JPG(*.jpg)|*.jpg;*.jpeg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp"
        If file.ShowDialog() = DialogResult.OK Then
            tamaño = FileLen(file.FileName)
            'If tamaño > 16384 Then
            '    MsgBox("La imagen a adjuntar no debe pesar mas de 16 KB.", MsgBoxStyle.Information, "Información")
            'Else
            pbFoto.Image = Image.FromFile(file.FileName)
            'End If
        End If
    End Sub


End Class