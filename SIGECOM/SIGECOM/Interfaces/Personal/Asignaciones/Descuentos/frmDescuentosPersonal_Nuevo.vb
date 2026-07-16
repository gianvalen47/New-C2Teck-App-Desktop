Imports System.ServiceModel
Public Class frmDescuentosPersonal_Nuevo

    '=========================== Servicios ====================================
    Private oDescuentoPersonalService As New DescuentoPersonalService.DescuentoPersonalServiceClient    
    Private oMaestroService As New MaestroService.MaestroClient

    '====================== Declaración de Variables ==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public IdPersona As Integer
    Public iPagado As Boolean                 'Campo pagado del Ingreso seleccionado
    Public IdDescuento As Integer
    Private dtMonedas As DataTable
    Private dtRubroDscto As New DataTable


    Private Sub frmDescuentosPersonal_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmDescuentosPersonal_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtColaborador.TabStop = True
            cmbDescuento.Focus()
        Else                                      'Nuevo       
            activar()
            'txtColaborador.TabStop = False
            'txtColaborador.Focus()
            btnBuscarColaborador.TabStop = True
            btnBuscarColaborador.Select()
            txtFecha.Value = Today
            cmbMoneda.Value = "NS"
        End If
        EnableOptions()
    End Sub

    Private Sub frmDescuentosPersonal_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oDescuentoPersonalService.Close()            
            oMaestroService.Close()
        Catch ex As TimeoutException
            oDescuentoPersonalService.Abort()            
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oDescuentoPersonalService.Abort()            
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar el Colaborador. ", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(cmbDescuento.Value) = "" Then
                MsgBox("Debe ingresar el Rubro de Descuento", MsgBoxStyle.Information, "Información")
                cmbDescuento.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe de Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toDouble(txtMonto.Value) = 0 Then
                MsgBox("Debe ingresar el Monto.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True
        cmbDescuento.ReadOnly = False
        cmbDescuento.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbMoneda.ReadOnly = False
        cmbMoneda.BackColor = System.Drawing.SystemColors.Window
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window

        cbPagado.Visible = False
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        If iPagado = True Then
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            cmbDescuento.ReadOnly = True
            cmbDescuento.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

            cbPagado.Visible = True
            btnGuardar.Enabled = False
        Else
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarColaborador.Enabled = False
            cmbDescuento.ReadOnly = False
            cmbDescuento.BackColor = System.Drawing.SystemColors.Window
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

            cbPagado.Visible = True
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub Insertar(ByVal registro As DescuentoPersonalService.DescuentoPersonal)
        Try
            Dim estado_process As Integer
            estado_process = oDescuentoPersonalService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdDescuento = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As DescuentoPersonalService.DescuentoPersonal)
        Try
            Dim estado_process As Boolean
            estado_process = oDescuentoPersonalService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As DescuentoPersonalService.DescuentoPersonal
            registro = oDescuentoPersonalService.Obtener(IdDescuento)

            IdDescuento = registro.IdDescuento
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbDescuento.Value = registro.RubroDescuentoPlanilla.IdRubroDes
            txtFecha.Value = registro.Fecha
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMonto.Value = registro.Monto
            txtObservacion.Text = registro.Observacion
            cbPagado.Checked = registro.Pagado

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarColaborador.Enabled = True Then
                e.Handled = True
                btnBuscarColaborador_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== DESCUENTO ===============================================
            dtRubroDscto = oDescuentoPersonalService.MostrarRubros(Session.sCodEmp).Tables(0)
            cmbDescuento.DataSource = dtRubroDscto
            cmbDescuento.DropDownList.DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.DisplayMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.ValueMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(0).DataMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(1).DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.SelectedIndex = 0
            dtRubroDscto = Nothing

            '======================================= MONEDAS ==============================================
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New DescuentoPersonalService.DescuentoPersonal
                Dim Persona As New DescuentoPersonalService.Persona
                Dim RubroDescuento As New DescuentoPersonalService.RubroDescuentoPlanilla
                Dim Moneda As New DescuentoPersonalService.Moneda

                registro.IdDescuento = IdDescuento
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                RubroDescuento.IdRubroDes = cmbDescuento.Value
                registro.RubroDescuentoPlanilla = RubroDescuento
                registro.Fecha = txtFecha.Value
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.Monto = txtMonto.Value
                registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    registro.FecReg = Today
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DESCUENTO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=================================== Evento KeyPress =========================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                           , cmbDescuento.KeyPress _
                           , txtFecha.KeyPress _
                           , cmbMoneda.KeyPress _
                           , txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbDescuento.Focus()
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