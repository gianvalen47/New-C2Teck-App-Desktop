Imports System.ServiceModel
Public Class frmAsignacionPersona

    '=========================== Servicios ===================================================
    Private oAsignacionLineaService As New AsignacionLineaService.AsignacionLineaServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Public IdPer As Integer
    Public IdLinea As Integer
    Public IdEquipo As Integer

    Private Sub frmAsignacionPersona_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oAsignacionLineaService.Close()
        Catch ex As TimeoutException
            oAsignacionLineaService.Abort()
        Catch ex As CommunicationException
            oAsignacionLineaService.Abort()
        End Try
    End Sub

    Private Sub frmAsignacionPersona_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAsignacionPersona_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            'txtFecha.TabStop = False
        Else                                      'Nuevo            
            activar()
            cbActivo.Checked = True
            'cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AsignacionLineaService.AsignacionLinea
            registro = oAsignacionLineaService.Obtener(IdPer, IdLinea)

            IdPer = registro.Persona.IdPer
            txtPersona.Text = registro.Persona.ApeNom

            IdLinea = registro.Lineas.IdLinea
            txtLinea.Text = registro.Lineas.NumLinea

            IdEquipo = registro.Equipos.IdEquipo
            txtEquipo.Text = registro.Equipos.DesEquipo

            txtFechaAsig.Value = registro.FechaAsig
            txtObservacion.Text = registro.Observacion

            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        btnBuscarPersonaS.Enabled = False
        btnBuscarLinea.Enabled = False

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        btnBuscarPersonaS.Enabled = True
        btnBuscarLinea.Enabled = True

        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New AsignacionLineaService.AsignacionLinea
                Dim persona As New AsignacionLineaService.Persona
                Dim linea As New AsignacionLineaService.Lineas
                Dim equipo As New AsignacionLineaService.Equipos

                persona.IdPer = IdPer
                registro.Persona = persona

                linea.IdLinea = IdLinea
                registro.Lineas = linea

                equipo.IdEquipo = IdEquipo
                registro.Equipos = equipo

                registro.FechaAsig = txtFechaAsig.Value
                registro.Observacion = txtObservacion.Text

                registro.Activo = cbActivo.Checked

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA ASIGNACION X PERSONA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As AsignacionLineaService.AsignacionLinea)
        Try
            If oAsignacionLineaService.Buscar(IdPer, IdLinea) = True Then
                MsgBox("La linea ya se encuentra asignada a un personal, tenga cuidado.", MsgBoxStyle.Information, "Información")
                txtLinea.Focus()
            Else
                Dim estado_process As Boolean
                estado_process = oAsignacionLineaService.Insertar(registro)
                type_process = "insert"
                If estado_process = True Then
                    IdEquipo = estado_process
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA ASIGNACION X EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AsignacionLineaService.AsignacionLinea)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionLineaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA ASIGNACION X EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtPersona.Text) = "" Then
                MsgBox("Debe ingresar el personal", MsgBoxStyle.Information, "Información")
                txtPersona.Focus()
                Return False
            ElseIf toBlank(txtFechaAsig.Value) = "" Then
                MsgBox("Debe ingresar la fecha de asignación", MsgBoxStyle.Information, "Información")
                txtFechaAsig.Focus()
                Return False
            ElseIf toBlank(txtLinea.Text) = "" Then
                MsgBox("Debe ingresar la linea", MsgBoxStyle.Information, "Información")
                txtLinea.Focus()
                Return False
            ElseIf toBlank(txtEquipo.Text) = "" Then
                MsgBox("Debe ingresar el equipo", MsgBoxStyle.Information, "Información")
                txtEquipo.Focus()
                Return False
            ElseIf toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe ingresar la observación del equipo", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False
                'ElseIf oAsignacionLineaService.Buscar(IdPer, IdLinea) = True Then
                '    MsgBox("La linea ya se encuentra asignada a un personal, tenga cuidado.", MsgBoxStyle.Information, "Información")
                '    txtLinea.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscarPersonaS_Click(sender As Object, e As EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtPersona.Text = frm.descripcion
                    IdPer = frm.codigo
                Else
                    txtPersona.Text = ""
                    IdPer = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarLinea_Click(sender As Object, e As EventArgs) Handles btnBuscarLinea.Click
        Try
            Dim frm As New frmBuscarLinea
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtLinea.Text = frm.descripcion
                    IdLinea = frm.codigo
                Else
                    txtLinea.Text = ""
                    IdLinea = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarEquipo_Click(sender As Object, e As EventArgs) Handles btnBuscarEquipo.Click
        Try
            Dim frm As New frmBuscarEquipo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtEquipo.Text = frm.descripcion
                    IdEquipo = frm.codigo
                Else
                    txtEquipo.Text = ""
                    IdEquipo = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class