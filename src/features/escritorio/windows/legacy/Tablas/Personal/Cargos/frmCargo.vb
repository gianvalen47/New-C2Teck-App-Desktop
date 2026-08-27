Imports System.ServiceModel
Public Class frmCargo

    '=========================== Servicios ====================================
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public CodCargo As String                  'Código de Cargo seleccionado
    Private dtClaseCargo As DataTable

    Private Sub frmCargo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtCodCargo.TabStop = False
            cmbClaseCargo.Focus()
        Else                                      'Nuevo            
            activar()
            txtCodCargo.TabStop = True
            txtCodCargo.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmCargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oPersonaService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodCargo.Text) = "" Then
                MsgBox("Debe ingresar el código de cargo", MsgBoxStyle.Information, "Información")
                txtCodCargo.Focus()
                Return False
            ElseIf toBlank(cmbClaseCargo.Value) = "" Then
                MsgBox("Debe ingresar la Clase de cargo", MsgBoxStyle.Information, "Información")
                cmbClaseCargo.Focus()
                Return False
            ElseIf toBlank(txtDesCargo.Text) = "" Then
                MsgBox("Debe ingresar la Descripción de cargo", MsgBoxStyle.Information, "Información")
                txtDesCargo.Focus()
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
        txtCodCargo.ReadOnly = False
        txtCodCargo.BackColor = System.Drawing.SystemColors.Window
        cmbClaseCargo.ReadOnly = False
        cmbClaseCargo.BackColor = System.Drawing.SystemColors.Window
        txtDesCargo.ReadOnly = False
        txtDesCargo.BackColor = System.Drawing.SystemColors.Window
        txtAbrCargo.ReadOnly = False
        txtAbrCargo.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtCodCargo.ReadOnly = True
        txtCodCargo.BackColor = System.Drawing.SystemColors.Control
        cmbClaseCargo.ReadOnly = False
        cmbClaseCargo.BackColor = System.Drawing.SystemColors.Window
        txtDesCargo.ReadOnly = False
        txtDesCargo.BackColor = System.Drawing.SystemColors.Window
        txtAbrCargo.ReadOnly = False
        txtAbrCargo.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As PersonaService.Cargo)
        Try
            Dim estado_process As String
            estado_process = oPersonaService.InsertarCargo(registro)
            type_process = "insert"
            If estado_process = True Then
                CodCargo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CARGO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PersonaService.Cargo)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.ActualizarCargo(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CARGO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PersonaService.Cargo
            registro = oPersonaService.ObtenerCargo(CodCargo)

            CodCargo = registro.CodCargo
            txtCodCargo.Text = registro.CodCargo
            cmbClaseCargo.Value = registro.ClaseCargo.ClasCargo
            txtDesCargo.Text = registro.DesCargo
            txtAbrCargo.Text = registro.AbrCargo
            
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= CLASE CARGO =============================================
            dtClaseCargo = oPersonaService.MostrarClaseCargo.Tables(0)
            cmbClaseCargo.DataSource = dtClaseCargo
            cmbClaseCargo.DropDownList.DataMember = dtClaseCargo.Columns("Nombre").ToString
            cmbClaseCargo.DropDownList.DisplayMember = dtClaseCargo.Columns("Nombre").ToString
            cmbClaseCargo.DropDownList.ValueMember = dtClaseCargo.Columns("ClasCargo").ToString
            cmbClaseCargo.DropDownList.Columns(0).DataMember = dtClaseCargo.Columns("ClasCargo").ToString
            cmbClaseCargo.DropDownList.Columns(1).DataMember = dtClaseCargo.Columns("Nombre").ToString
            cmbClaseCargo.SelectedIndex = 0
            dtClaseCargo = Nothing


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
                Dim registro As New PersonaService.Cargo
                Dim ClaseCargo As New PersonaService.ClaseCargo
                Dim empresa As New PersonaService.Empresa

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.CodCargo = txtCodCargo.Text
                ClaseCargo.ClasCargo = cmbClaseCargo.Value
                registro.ClaseCargo = ClaseCargo
                registro.DesCargo = txtDesCargo.Text
                registro.AbrCargo = txtAbrCargo.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR CARGO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtCodCargo.KeyPress _
                           , cmbClaseCargo.KeyPress _
                           , txtDesCargo.KeyPress _
                           , txtAbrCargo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class