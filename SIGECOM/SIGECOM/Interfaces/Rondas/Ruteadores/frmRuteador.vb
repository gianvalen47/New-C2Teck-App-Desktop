Imports System.ServiceModel

Public Class frmRuteador

    Private oRondasService As New RondasService.RondasServiceClient

    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete

    Public IdRuteador As Integer

    Private Sub frmRuteador_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRondasService.Close()
        Catch ex As TimeoutException
            oRondasService.Abort()
        Catch ex As CommunicationException
            oRondasService.Abort()
        End Try
    End Sub

    Private Sub frmRuteador_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRuteador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar

            ObtenerRegistro()
            desactivar()

            Me.Text = "Ruteador " + Chr(34) + txtApePat.Text.ToString + Chr(34) + txtApeMat.Text.ToString + Chr(34) + txtNombre.Text.ToString + Chr(34)
        Else                    'Nuevo
            'Me.Size = New System.Drawing.Size(677, 365)
            Me.Text = "Registrar nuevo Ruteador"
            cbVigente.Checked = True
        End If

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As RondasService.Ruteador
            registro = oRondasService.ObtenerRuteador(IdRuteador)

            IdRuteador = registro.IdRuteador
            txtNombre.Text = toBlank(registro.Nombres)
            txtApePat.Text = toBlank(registro.ApePat)
            txtApeMat.Text = toBlank(registro.ApeMat)
            txtCodBarra.Text = toBlank(registro.CodBarras)
            cbVigente.Checked = registro.Vigente

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtApePat.ReadOnly = True
        txtApePat.BackColor = System.Drawing.SystemColors.Control
        txtApeMat.ReadOnly = True
        txtApeMat.BackColor = System.Drawing.SystemColors.Control
        txtCodBarra.ReadOnly = True
        txtCodBarra.BackColor = System.Drawing.SystemColors.Control
        cbVigente.Enabled = False

    End Sub

    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        txtNombre.ReadOnly = False
        txtNombre.BackColor = System.Drawing.SystemColors.Window
        txtApePat.ReadOnly = False
        txtApePat.BackColor = System.Drawing.SystemColors.Window
        txtApeMat.ReadOnly = False
        txtApeMat.BackColor = System.Drawing.SystemColors.Window
        txtCodBarra.ReadOnly = False
        txtCodBarra.BackColor = System.Drawing.SystemColors.Window
        cbVigente.Enabled = True

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress, txtApePat.KeyPress _
                       , txtApeMat.KeyPress, txtCodBarra.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub btnDeshacer_Click(sender As System.Object, e As System.EventArgs) Handles btnDeshacer.Click
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

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub



    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New RondasService.Ruteador

                registro.IdRuteador = toNumber(IdRuteador)

                registro.Nombres = toNull(txtNombre.Text)
                registro.ApePat = toNull(txtApePat.Text)
                registro.ApeMat = toNull(txtApeMat.Text)
                registro.CodBarras = toNull(txtCodBarra.Text)
                registro.Vigente = cbVigente.Checked

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

    Private Sub Insertar(ByVal registro As RondasService.Ruteador)
        Try
            Dim estado_process As Integer
            estado_process = oRondasService.InsertarRuteador(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdRuteador = estado_process
                MsgBox("Se insertó el Ruteador correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR RUTEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RondasService.Ruteador)
        Try
            Dim estado_process As Boolean
            estado_process = oRondasService.ActualizarRuteador(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR RUTEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Function ValidaCampos() As Boolean
        Try

            If txtApePat.Text = "" Then
                MsgBox("Debe Ingresar el Apellido Materno del Ruteador", MsgBoxStyle.Information, "Información")
                txtApePat.BackColor = Color.Red
                txtApePat.Focus()
                Return False
            ElseIf txtApeMat.Text = "" Then
                MsgBox("Debe Ingresar el Apellido Materno del Ruteador", MsgBoxStyle.Information, "Información")
                txtApeMat.BackColor = Color.Red
                txtApeMat.Focus()
                Return False
            ElseIf txtNombre.Text = "" Then
                MsgBox("Debe Ingresar los Nombres del Ruteador", MsgBoxStyle.Information, "Información")
                txtNombre.BackColor = Color.Red
                txtNombre.Focus()
                Return False
            ElseIf txtCodBarra.Text = "" Then
                MsgBox("Debe Ingresar el Codigo Barra del Ruteador", MsgBoxStyle.Information, "Información")
                txtCodBarra.BackColor = Color.Red
                txtCodBarra.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class