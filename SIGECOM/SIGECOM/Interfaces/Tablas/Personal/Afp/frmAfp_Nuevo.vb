Imports System.ServiceModel
Public Class frmAfp_Nuevo

    '===========================Servicios====================================================
    Private oAfpService As New AfpService.AfpServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdAfp As Integer

    Private Sub frmAfp_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtAbrvAfp.Select()
        Else                          'Nuevo
            cbActivo.Checked = True
            desactivar()
            txtAbrvAfp.Select()
        End If
        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmCuentaMayor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtIdAfp.KeyPress, _
                            txtAbrvAfp.KeyPress, _
                            txtTopePrima.KeyPress, _
                            cbActivo.KeyPress, _
                            txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = "(Todos)"
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub Finalizar()
        Try
            oAfpService.Close()
        Catch ex As TimeoutException
            oAfpService.Abort()
        Catch ex As CommunicationException
            oAfpService.Abort()
        End Try
    End Sub

    Private Sub EnableOptions()
        'If estado = 1 Then
        activar()
        btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub activar()
        If state_button Then
            txtIdAfp.ReadOnly = True
            txtIdAfp.BackColor = System.Drawing.SystemColors.Control
            txtAbrvAfp.ReadOnly = False
            txtAbrvAfp.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            txtTopePrima.ReadOnly = False
            txtTopePrima.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
        Else
            txtIdAfp.ReadOnly = True
            txtIdAfp.BackColor = System.Drawing.SystemColors.Control
            txtAbrvAfp.ReadOnly = False
            txtAbrvAfp.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            txtDescripcion.BackColor = System.Drawing.SystemColors.Window
            txtTopePrima.ReadOnly = False
            txtTopePrima.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
        End If
    End Sub

    Private Sub desactivar()
        txtIdAfp.ReadOnly = True
        txtIdAfp.BackColor = System.Drawing.SystemColors.Control
        txtAbrvAfp.ReadOnly = True
        txtAbrvAfp.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtTopePrima.ReadOnly = True
        txtTopePrima.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
    End Sub

    Private Sub Insertar(ByVal registro As AfpService.Afp)
        Try
            Dim estado_process As Integer
            estado_process = oAfpService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdAfp = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR AFP: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AfpService.Afp)
        Try
            Dim estado_process As Boolean
            estado_process = oAfpService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR AFP: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AfpService.Afp
            registro = oAfpService.Obtener(IdAfp)

            IdAfp = registro.IdAfp
            txtIdAfp.Text = registro.IdAfp
            txtAbrvAfp.Text = registro.AbrAfp
            txtDescripcion.Text = registro.DesAfp
            txtTopePrima.Value = registro.TopePrima
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER AFP: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción de AFP. ", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New AfpService.Afp            

            registro.IdAfp = IdAfp
            registro.AbrAfp = txtAbrvAfp.Text
            registro.DesAfp = txtDescripcion.Text
            registro.TopePrima = txtTopePrima.Value
            registro.Activo = cbActivo.Checked

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
End Class