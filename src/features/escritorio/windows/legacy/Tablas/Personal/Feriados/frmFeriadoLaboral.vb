Imports System.ServiceModel
Public Class frmFeriadoLaboral

    '=========================== Servicios ===================================================
    Private oHorarioService As New HorarioService.HorarioServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public iFecha As Date                        'Fecha Feriado de Personal

    Private Sub frmFeriadoPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmFeriadoPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtFecha.TabStop = False
            cbPrioridad.Focus()
        Else                                      'Nuevo            
            activar()
            txtFecha.TabStop = True
            txtFecha.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmFeriadoPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oHorarioService.Close()
        Catch ex As TimeoutException
            oHorarioService.Abort()
        Catch ex As CommunicationException
            oHorarioService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
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
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        cbPrioridad.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        cbPrioridad.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As HorarioService.FeriadoLaboral)
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioService.InsertarFeriado(registro)
            type_process = "insert"
            If estado_process = True Then
                iFecha = txtFecha.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR FERIADO LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HorarioService.FeriadoLaboral)
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioService.ActualizarFeriado(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR FERIADO LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As HorarioService.FeriadoLaboral
            registro = oHorarioService.ObtenerFeriado(iFecha)

            iFecha = registro.Fecha
            txtFecha.Value = registro.Fecha
            cbPrioridad.Checked = registro.Prioridad
            txtObservacion.Text = registro.DesFer

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
                Dim registro As New HorarioService.FeriadoLaboral

                registro.Fecha = txtFecha.Value
                registro.Prioridad = cbPrioridad.Checked
                registro.DesFer = txtObservacion.Text

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR FERIADO LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtFecha.KeyPress _
                           , cbPrioridad.KeyPress _
                           , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class