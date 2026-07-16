Imports System.ServiceModel

Public Class frmProgramacionJob_ActPersona

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    Private dtAtraso As DataTable
    Private dtDatos As DataTable
    Private IdAtraso As Integer
    Public IdProgramacionDet As Integer
    Public IdProgramacion As Integer
    Public IdPer As Integer
    Public DesActividad As String
    Public FecFinReal As Date

    Private Atraso As Boolean

    Private Sub frmProgramacionJob_ActPersona_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
        End Try
    End Sub

    Private Sub frmProgramacionJob_ActPersona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProgramacionJob_ActPersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObtenerRegistro()

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As IndicadoresServicioService.ProgramacionPersona
            registro = oIndicadoresServicioService.MostrarPorIdProgramacionPersona(IdProgramacionDet, FecFinReal, IdPer)

            IdPer = registro.Persona.IdPer
            txtPersona.Text = registro.Persona.ApeNom
            txtHoraReal.Value = registro.HorReal
            txtHoraPlaneada.Value = registro.HorPla
            txtHoraExtra.Value = registro.HorExt

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub btnBuscarPersonaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            frm.codigoArea = "05"
            frm.cmbCodArea.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPer = frm.codigo
                    txtPersona.Text = frm.descripcion
                Else
                    IdPer = 0
                    txtPersona.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If ValidaCampos() Then

                Dim registro As New IndicadoresServicioService.ProgramacionPersona
                Dim Persona As New IndicadoresServicioService.Persona
                Dim ProgramacionJobDet As New IndicadoresServicioService.ProgramacionJobDet
                Dim ProgramacionJob As New IndicadoresServicioService.ProgramacionJob

                Persona.IdPer = IdPer
                registro.Persona = Persona

                ProgramacionJob.IdProgramacion = IdProgramacion
                ProgramacionJobDet.ProgramacionJob = ProgramacionJob
                ProgramacionJobDet.IdProgramacionDet = IdProgramacionDet
                registro.ProgramacionJobDet = ProgramacionJobDet
                registro.FecFinReal = FecFinReal
                registro.HorReal = txtHoraReal.Value
                registro.HorPla = txtHoraPlaneada.Value
                registro.HorExt = txtHoraExtra.Value
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                Modificar(registro)

            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As IndicadoresServicioService.ProgramacionPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarProgramacionPersona(registro)

            If estado_process Then
                MsgBox("Se modificó la programación por persona correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del TI")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If utils.toNumber(IdPer) = 0 Then
                MsgBox("Debe ingresar el personal")
                txtPersona.Focus()
                Return False
            Else
                Return True
            End If


        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtPersona.KeyPress _
                          , txtHoraReal.KeyPress _
                          , txtHoraPlaneada.KeyPress
        ', txtObsDet.KeyPress _
        ', txtFecha.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtHoraReal_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHoraReal.ValueChanged
        CalcularHoraAdic()
    End Sub

    Private Sub CalcularHoraAdic()
        If txtHoraReal.Value >= txtHoraPlaneada.Value Then
            txtHoraExtra.Value = txtHoraReal.Value - txtHoraPlaneada.Value
        Else
            txtHoraExtra.Value = 0
        End If
    End Sub

End Class