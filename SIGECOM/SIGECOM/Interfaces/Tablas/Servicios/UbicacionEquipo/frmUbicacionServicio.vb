Imports System.ServiceModel
Public Class frmUbicacionServicio
    '=========================== Servicios ====================================
    Private oTablasPersonalService As New TablasPersonalService.TablasPersonalServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public CodUbicacion As String                  'Código de Cargo seleccionado

    Private Sub frmCargo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtCodUbicacion.TabStop = False
            txtDesUbicacion.Focus()
        Else                                      'Nuevo            
            activar()
            txtCodUbicacion.TabStop = True
            txtCodUbicacion.Focus()
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
            oTablasPersonalService.Close()
        Catch ex As TimeoutException
            oTablasPersonalService.Abort()
        Catch ex As CommunicationException
            oTablasPersonalService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodUbicacion.Text) = "" Then
                MsgBox("Debe ingresar el código de cargo", MsgBoxStyle.Information, "Información")
                txtCodUbicacion.Focus()
                Return False
            ElseIf oTablasPersonalService.BuscarUbicacionEquipo(txtCodUbicacion.Text) And state_button = False Then
                MsgBox("Esté código ya fue ingresado, ¡Verificar...!. ", MsgBoxStyle.Information, "Información")
                txtCodUbicacion.Focus()
                Return False            
            ElseIf toBlank(txtDesUbicacion.Text) = "" Then
                MsgBox("Debe ingresar la Descripción de Ubicación", MsgBoxStyle.Information, "Información")
                txtDesUbicacion.Focus()
                Return False
            ElseIf toBlank(txtAbrUbicacion.Text) = "" Then
                MsgBox("Debe ingresar la Abreviatura de Ubicación", MsgBoxStyle.Information, "Información")
                txtAbrUbicacion.Focus()
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
        txtCodUbicacion.ReadOnly = False
        txtCodUbicacion.BackColor = System.Drawing.SystemColors.Window
        txtDesUbicacion.ReadOnly = False
        txtDesUbicacion.BackColor = System.Drawing.SystemColors.Window
        txtAbrUbicacion.ReadOnly = False
        txtAbrUbicacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtCodUbicacion.ReadOnly = True
        txtCodUbicacion.BackColor = System.Drawing.SystemColors.Control
        txtDesUbicacion.ReadOnly = False
        txtDesUbicacion.BackColor = System.Drawing.SystemColors.Window
        txtAbrUbicacion.ReadOnly = False
        txtAbrUbicacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As TablasPersonalService.UbicacionEquipo)
        Try
            Dim estado_process As String
            estado_process = oTablasPersonalService.InsertarUbicacionEquipo(registro)
            type_process = "insert"
            If estado_process = True Then
                CodUbicacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR UBICACIÓN DE SERVICIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As TablasPersonalService.UbicacionEquipo)
        Try
            Dim estado_process As Boolean
            estado_process = oTablasPersonalService.ActualizarUbicacionEquipo(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR UBICACIÓN DE SERVICIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As TablasPersonalService.UbicacionEquipo
            registro = oTablasPersonalService.ObtenerUbicacionEquipo(CodUbicacion)

            CodUbicacion = registro.CodUbicacion
            txtCodUbicacion.Text = registro.CodUbicacion
            txtDesUbicacion.Text = registro.DesUbicacion
            txtAbrUbicacion.Text = registro.AbrUbicacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

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
                Dim registro As New TablasPersonalService.UbicacionEquipo   

                registro.CodUbicacion = txtCodUbicacion.Text
                registro.DesUbicacion = txtDesUbicacion.Text
                registro.AbrUbicacion = txtAbrUbicacion.Text

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR UBICACIÓN DE SERVICIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtCodUbicacion.KeyPress _
                           , txtDesUbicacion.KeyPress _
                           , txtAbrUbicacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class