Imports System.ServiceModel
Public Class frmQuintaCategoriaNuevoDetalle
    '===========================Servicios====================================================
    Private oQuintaCategoriaDetService As New QuintaCategoriaDetService.QuintaCategoriaDetServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete

    Private dtTipoPlanilla As DataTable
    Public IdPersona As Integer
    Public ApeNom As String
    Public periodo As Integer
    Public mes As String
    Public idTipo As Integer





    Private Sub frmCronograMina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If IdPersona <> 0 Then
            ObtenerPersona()
        End If

        If state_button Then                'Modificar
            desactivar()
            ObtenerRegistro()
            Me.Text = "Detalle Quinta Categoria"
            txtColaborador.TabStop = False
            cmbTipoPlanilla.Focus()
        Else                                      'Nuevo
            txtAnio.Value = periodo  'Today.Year
            txtMesRegistro.Text = Format(Month(Today), "00")
            Me.Text = "Nuevo Detalle Quinta Categoria"
            activar()

        End If

        EnableOptions()
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(IdPersona)
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmCronograMinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As QuintaCategoriaDetService.QuintaCategoriaDet
            registro = oQuintaCategoriaDetService.Obtener(IdPersona, periodo, mes, idTipo)
            mes = registro.Mes
            periodo = registro.QuintaCategoriaCab.Periodo
            txtAnio.Value = periodo
            txtMesRegistro.Text = mes
            'IdPersona = registro.QuintaCategoriaCab.Persona.IdPer
            'txtColaborador.Text = registro.QuintaCategoriaCab.Persona.ApeNom
            cmbTipoPlanilla.Value = registro.TipoQuinta.IdTipoQuinta
            txtMontoIngresos.Value = registro.Ingresos
            txtIngresosExtras.Value = registro.IngresosExtras
            txtMontoRetenido.Value = registro.Retenido

            Me.Text = "Detalle Quinta Categoria"
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub Finalizar()
        Try
            oQuintaCategoriaDetService.Close()
            oPersonaService.Close()
            ' oMaestroService.Close()
            oPlanillaSueldosService.Close()

        Catch ex As TimeoutException
            oQuintaCategoriaDetService.Abort()
            oPersonaService.Abort()
            '   oMaestroService.Abort()
            oPlanillaSueldosService.Abort()

        Catch ex As CommunicationException
            oQuintaCategoriaDetService.Abort()
            oPersonaService.Abort()
            '   oMaestroService.Abort()
            oPlanillaSueldosService.Abort()

        End Try
    End Sub

    Private Sub frmCronograMina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub llenarCombos()
        Try

            ''=======================================MONEDAS ===============================================
            'dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            'cmbMoneda.DataSource = dtMonedas
            'cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            'cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            'cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            'dtMonedas = Nothing

            '==================================== TIPO PLANILLA ========================================
            dtTipoPlanilla = oQuintaCategoriaDetService.MostrarTipos().Tables(0)
            cmbTipoPlanilla.DataSource = dtTipoPlanilla
            cmbTipoPlanilla.DropDownList.DataMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.DropDownList.DisplayMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.DropDownList.ValueMember = dtTipoPlanilla.Columns("IdTipoQuinta").ToString
            cmbTipoPlanilla.DropDownList.Columns(0).DataMember = dtTipoPlanilla.Columns("IdTipoQuinta").ToString
            cmbTipoPlanilla.DropDownList.Columns(1).DataMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.SelectedIndex = 0
            dtTipoPlanilla = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        'txtColaborador.ReadOnly = True
        'txtColaborador.BackColor = System.Drawing.SystemColors.Control
        'btnBuscarColaborador.Enabled = True
        cmbTipoPlanilla.ReadOnly = False
        cmbTipoPlanilla.BackColor = System.Drawing.SystemColors.Window

        txtMesRegistro.ReadOnly = False
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
        txtMontoIngresos.ReadOnly = False
        txtMontoIngresos.BackColor = System.Drawing.SystemColors.Window
        txtMontoRetenido.ReadOnly = False
        txtMontoRetenido.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
        txtMontoIngresos.Focus()


    End Sub

    Private Sub desactivar()

        'txtColaborador.ReadOnly = True
        'txtColaborador.BackColor = System.Drawing.SystemColors.Control
        'btnBuscarColaborador.Enabled = False
        cmbTipoPlanilla.ReadOnly = True
        cmbTipoPlanilla.BackColor = System.Drawing.SystemColors.Control
        txtMesRegistro.ReadOnly = True
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
        txtMontoIngresos.ReadOnly = False
        txtMontoIngresos.BackColor = System.Drawing.SystemColors.Window
        txtMontoRetenido.ReadOnly = False
        txtMontoRetenido.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
        txtMontoIngresos.Focus()

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar la persona.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(txtAnio.Value) = "" Then
                MsgBox("Debe Ingresar el periodo.", MsgBoxStyle.Information, "Información")
                txtAnio.Focus()
                Return False
            ElseIf txtMesRegistro.Text = "" Then
                MsgBox("Debe ingresar Mes", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function



    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub


    Private Sub Insertar(ByVal registro As QuintaCategoriaDetService.QuintaCategoriaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oQuintaCategoriaDetService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el detalle de quinta categoria")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As QuintaCategoriaDetService.QuintaCategoriaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oQuintaCategoriaDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim QuintaCab As New QuintaCategoriaDetService.QuintaCategoriaCab
                    Dim registro As New QuintaCategoriaDetService.QuintaCategoriaDet
                    Dim Colaborador As New QuintaCategoriaDetService.Persona
                    Dim Tipo As New QuintaCategoriaDetService.TipoQuinta
                    Dim empresa As New QuintaCategoriaDetService.Empresa

                    empresa.CodEmp = Session.sCodEmp
                    QuintaCab.Periodo = periodo
                    Colaborador.IdPer = IdPersona
                    Colaborador.Empresa = empresa
                    QuintaCab.Persona = Colaborador
                    Tipo.IdTipoQuinta = cmbTipoPlanilla.Value
                    registro.QuintaCategoriaCab = QuintaCab
                    registro.TipoQuinta = Tipo
                    registro.Mes = txtMesRegistro.Text
                    mes = txtMesRegistro.Text
                    registro.Ingresos = txtMontoIngresos.Value
                    registro.IngresosExtras = txtIngresosExtras.Value
                    registro.Retenido = txtMontoRetenido.Value
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
            MsgBox("ERROR AL GUARDAR QUINTA CATEGORIA DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub


    Private Sub btnBuscarColaborador_Click(sender As Object, e As EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtAnio.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class