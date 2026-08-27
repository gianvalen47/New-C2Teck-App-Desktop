Imports System.ServiceModel
Public Class frmAsignacionJefe_Area

    '=========================== Servicios ===================================================
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public CodCentro As String
    Private dtCentroCosto As DataTable
    Private dtAreas As DataTable
    Private dtMonedasCompra As DataTable
    Private dtMonedasViatico As DataTable

    Private Sub frmAsignacionJefe_Area_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAsignacionJefe_Area_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            cbLimiteCompra.Focus()
        Else                                      'Nuevo            
            activar()
            cmbArea.Focus()            
        End If
        EnableOptions()
    End Sub

    Private Sub frmAsignacionJefe_Area_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionJefesService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar el Colaborador. ", MsgBoxStyle.Information, "Información")
                cmbArea.Focus()
                Return False
            ElseIf toBlank(cmbArea.Value) = "" Then
                MsgBox("Debe de ingresar el área.", MsgBoxStyle.Information, "Información")
                cmbArea.Focus()
                Return False
            ElseIf toBlank(cmbCentroCosto.Value) = "" Then
                MsgBox("Debe de ingresar el centro de costo.", MsgBoxStyle.Information, "Información")
                cmbCentroCosto.Focus()
                Return False
            ElseIf cbLimiteCompra.Checked = True And cmbMonCompra.SelectedIndex = 0 Then
                MsgBox("Debe de ingresar la Moneda de Limite de Compra.", MsgBoxStyle.Information, "Información")
                cmbMonCompra.Focus()
                Return False
            ElseIf cbLimiteViatico.Checked = True And cmbMonViatico.SelectedIndex = 0 Then
                MsgBox("Debe de ingresar la Moneda de Limite de Viático.", MsgBoxStyle.Information, "Información")
                cmbMonViatico.Focus()
                Return False
            ElseIf cbLimiteCompra.Checked = True And toDouble(txtMontoCompra.Value) = 0 Then
                MsgBox("Debe de ingresar la Monto de Limite de Compra.", MsgBoxStyle.Information, "Información")
                txtMontoCompra.Focus()
                Return False
            ElseIf cbLimiteViatico.Checked = True And toDouble(txtMontoViatico.Value) = 0 Then
                MsgBox("Debe de ingresar la Monto de Limite de Viático.", MsgBoxStyle.Information, "Información")
                txtMontoViatico.Focus()
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
        cmbArea.ReadOnly = False
        cmbArea.BackColor = System.Drawing.SystemColors.Window
        cmbCentroCosto.ReadOnly = False
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
        cbLimiteCompra.Enabled = True
        cbLimiteCompra.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        cmbArea.ReadOnly = True
        cmbArea.BackColor = System.Drawing.SystemColors.Control
        cmbCentroCosto.ReadOnly = True
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        cbLimiteCompra.Enabled = True
        cbLimiteViatico.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As AsignacionJefesService.AsignacionJefesAreas)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionJefesService.InsertarArea(registro)
            type_process = "insert"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ASIGNACIÓN DE ÁREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AsignacionJefesService.AsignacionJefesAreas)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionJefesService.ActualizarArea(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ASIGNACIÓN DE ÁREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AsignacionJefesService.AsignacionJefesAreas
            registro = oAsignacionJefesService.ObtenerArea(IdPersona, CodCentro)

            IdPersona = registro.Persona.IdPer
            cmbArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            cbLimiteCompra.Checked = registro.LimiteCompra
            txtMontoCompra.Value = registro.MontoCompra
            cbLimiteViatico.Checked = registro.LimiteViatico
            txtMontoViatico.Value = registro.MontoViatico
            txtObservacion.Text = registro.Observacion
            If toBlank(registro.MonedaCompra.CodMon) = "" Then
                cmbMonCompra.SelectedIndex = 0
            Else
                cmbMonCompra.Value = registro.MonedaCompra.CodMon
            End If
            If toBlank(registro.MonedaViatico.CodMon) = "" Then
                cmbMonViatico.SelectedIndex = 0
            Else
                cmbMonViatico.Value = registro.MonedaViatico.CodMon
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowNinguno(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(5) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(6) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(7) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(8) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(9) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

            '===================================== MONEDAS COMPRA ==========================================
            dtMonedasCompra = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedasCompra.Rows.InsertAt(getRowNinguno(dtMonedasCompra), 0)
            cmbMonCompra.DataSource = dtMonedasCompra
            cmbMonCompra.DropDownList.DataMember = dtMonedasCompra.Columns("AbrMon").ToString
            cmbMonCompra.DropDownList.DisplayMember = dtMonedasCompra.Columns("AbrMon").ToString
            cmbMonCompra.DropDownList.ValueMember = dtMonedasCompra.Columns("CodMon").ToString
            cmbMonCompra.DropDownList.Columns(0).DataMember = dtMonedasCompra.Columns("CodMon").ToString
            cmbMonCompra.DropDownList.Columns(1).DataMember = dtMonedasCompra.Columns("AbrMon").ToString
            cmbMonCompra.SelectedIndex = 0
            dtMonedasCompra = Nothing

            '====================================== MONEDAS VIATICO ==========================================
            dtMonedasViatico = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedasViatico.Rows.InsertAt(getRowNinguno(dtMonedasViatico), 0)
            cmbMonViatico.DataSource = dtMonedasViatico
            cmbMonViatico.DropDownList.DataMember = dtMonedasViatico.Columns("AbrMon").ToString
            cmbMonViatico.DropDownList.DisplayMember = dtMonedasViatico.Columns("AbrMon").ToString
            cmbMonViatico.DropDownList.ValueMember = dtMonedasViatico.Columns("CodMon").ToString
            cmbMonViatico.DropDownList.Columns(0).DataMember = dtMonedasViatico.Columns("CodMon").ToString
            cmbMonViatico.DropDownList.Columns(1).DataMember = dtMonedasViatico.Columns("AbrMon").ToString
            cmbMonViatico.SelectedIndex = 0
            dtMonedasViatico = Nothing

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
                Dim registro As New AsignacionJefesService.AsignacionJefesAreas
                Dim Persona As New AsignacionJefesService.Persona
                Dim Area As New AsignacionJefesService.Area
                Dim CentroCosto As New AsignacionJefesService.CentroCosto
                Dim MonedaCompra As New AsignacionJefesService.Moneda
                Dim MonedaViatico As New AsignacionJefesService.Moneda

                Persona.IdPer = IdPersona
                registro.Persona = Persona
                Area.CodArea = cmbArea.Value
                CentroCosto.CodCentro = cmbCentroCosto.Value
                CentroCosto.Area = Area
                registro.CentroCosto = CentroCosto
                registro.LimiteCompra = cbLimiteCompra.Checked
                registro.MontoCompra = txtMontoCompra.Value
                registro.LimiteViatico = cbLimiteViatico.Checked
                registro.MontoViatico = txtMontoViatico.Value
                registro.Observacion = txtObservacion.Text
                MonedaCompra.CodMon = IIf(cmbMonCompra.SelectedIndex = 0, Nothing, cmbMonCompra.Value)
                registro.MonedaCompra = MonedaCompra
                MonedaViatico.CodMon = IIf(cmbMonViatico.SelectedIndex = 0, Nothing, cmbMonViatico.Value)
                registro.MonedaViatico = MonedaViatico

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
            MsgBox("ERROR AL GUARDAR ASIGNACIÓN DE ÁREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             cmbArea.KeyPress _
                           , cmbCentroCosto.KeyPress _
                           , cbLimiteCompra.KeyPress _
                           , txtMontoCompra.KeyPress _
                           , cbLimiteViatico.KeyPress _
                           , txtMontoViatico.KeyPress _
                           , cmbMonCompra.KeyPress _
                           , cmbMonViatico.KeyPress
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

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            If cmbArea.Value <> "" Then
                '====================================== CENTRO COSTO ===========================================
                dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
                'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
                cmbCentroCosto.DataSource = dtCentroCosto
                cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
                cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
                cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
                cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
                cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
                cmbCentroCosto.SelectedIndex = 0
                dtCentroCosto = Nothing
            End If

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbLimiteCompra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLimiteCompra.CheckedChanged
        If cbLimiteCompra.Checked = True Then
            txtMontoCompra.ReadOnly = False
            txtMontoCompra.BackColor = System.Drawing.SystemColors.Window
            cmbMonCompra.ReadOnly = False
            cmbMonCompra.BackColor = System.Drawing.SystemColors.Window
        Else
            txtMontoCompra.ReadOnly = True
            txtMontoCompra.BackColor = System.Drawing.SystemColors.Control
            txtMontoCompra.Value = 0
            cmbMonCompra.ReadOnly = True
            cmbMonCompra.BackColor = System.Drawing.SystemColors.Control
            cmbMonCompra.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbLimiteViatico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLimiteViatico.CheckedChanged
        If cbLimiteViatico.Checked = True Then
            txtMontoViatico.ReadOnly = False
            txtMontoViatico.BackColor = System.Drawing.SystemColors.Window
            cmbMonViatico.ReadOnly = False
            cmbMonViatico.BackColor = System.Drawing.SystemColors.Window
        Else
            txtMontoViatico.ReadOnly = True
            txtMontoViatico.BackColor = System.Drawing.SystemColors.Control
            txtMontoViatico.Value = 0
            cmbMonViatico.ReadOnly = True
            cmbMonViatico.BackColor = System.Drawing.SystemColors.Control
            cmbMonViatico.SelectedIndex = 0
        End If
    End Sub

End Class