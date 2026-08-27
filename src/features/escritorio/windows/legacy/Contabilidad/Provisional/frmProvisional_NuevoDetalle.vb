Imports System.ServiceModel

Public Class frmProvisional_NuevoDetalle

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete

    Public IdProvisional As Integer
    Public IdProvisionalDet As Integer

    Private Sub frmProvisional_NuevoDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmProvisional_NuevoDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_NuevoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
        Else                          'Nuevo
            txtFecha.Focus()
            activar()
        End If

    End Sub

    Private Sub desactivar()


        Dim estadodet As Integer
            estadodet = oProvisionalService.ObtenerEstadoDetalle(IdProvisionalDet)

        If estadodet <> 1 Then

            txtFecha.Enabled = False
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtMonto.Enabled = False
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.Enabled = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

        Else
            txtFecha.Enabled = True
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtMonto.Enabled = True
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.Enabled = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

        End If


    End Sub

    Private Sub activar()

        If state_button = True Then
            Dim estadodet As Integer
            estadodet = oProvisionalService.ObtenerEstadoDetalle(IdProvisionalDet)

            If estadodet <> 1 Then
                txtFecha.Enabled = False
                txtFecha.BackColor = System.Drawing.SystemColors.Control
                txtMonto.Enabled = False
                txtMonto.BackColor = System.Drawing.SystemColors.Control
                txtObservacion.Enabled = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Control
            Else
                txtFecha.Enabled = True
                txtFecha.BackColor = System.Drawing.SystemColors.Window
                txtMonto.Enabled = True
                txtMonto.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.Enabled = True
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
            End If

        ElseIf state_button = False Then

            txtFecha.Enabled = True
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtMonto.Enabled = True
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.Enabled = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Window

        End If

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ProvisionalService.ProvisionalDetalle
            registro = oProvisionalService.ObtenerDetalle(toNumber(IdProvisionalDet))

            IdProvisionalDet = registro.IdProvisionalDet
            IdProvisional = registro.Provisional.IdProvisional

            txtFecha.Value = registro.Fecha
            txtMonto.Value = registro.Monto
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toDouble(txtMonto.Value) <= 0 Then
                MsgBox("El monto debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMonto.BackColor = Color.Red
                txtMonto.Focus()
                Return False
            ElseIf toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe ingresar la observación", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New ProvisionalService.ProvisionalDetalle
            Dim provisional As New ProvisionalService.Provisional

            registro.IdProvisionalDet = IdProvisionalDet
            provisional.IdProvisional = IdProvisional
            registro.Provisional = provisional

            registro.Fecha = txtFecha.Value
            registro.Monto = txtMonto.Value
            registro.Observacion = txtObservacion.Text

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub

    Private Sub Insertar(ByVal registro As ProvisionalService.ProvisionalDetalle)
        Try
            Dim estado_process As Integer
            estado_process = oProvisionalService.InsertarDetalle(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdProvisionalDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ProvisionalService.ProvisionalDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oProvisionalService.ActualizarDetalle(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class