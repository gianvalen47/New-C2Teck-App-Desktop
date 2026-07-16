Imports System.ServiceModel

Public Class frmHorasMotor_Historial

    '=========================== Servicios ====================================
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient

    '====================== Declaración de Variables ==============================
    Private dtDatos As DataTable
    Public NumSerie As String

    Private Sub frmHorasMotor_Historial_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHorasMotorService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
        Catch ex As CommunicationException
            oHorasMotorService.Abort()
        End Try
    End Sub

    Private Sub frmHorasMotor_Historial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmHorasMotor_Historial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNumSerie.Text = "N° Serie : " & NumSerie

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        listarDatos()
    End Sub

    Private Sub listarDatos()
        Try
            dtDatos = oHorasMotorService.MostrarHistorial(NumSerie).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miActFecRegistro_Click(sender As System.Object, e As System.EventArgs) Handles miActFecRegistro.Click, biActFecRegistro.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            ActualizarHistorial()
        End If
    End Sub

    Private Sub ActualizarHistorial()
        Try
            Dim frm As New frmHoraMotor_Act_Historial
            frm.IdHistorial = toNumber(dgvDatos.CurrentRow.Cells("IdHistorial").Value)
            frm.codMer = dgvDatos.CurrentRow.Cells("NumSerie").Value
            frm.FecRegistro = CDate(dgvDatos.CurrentRow.Cells("FecRegistro").Value)
            frm.TotalHoras = CDbl(dgvDatos.CurrentRow.Cells("TotalHoras").Value)
            frm.HorasParcial = CDbl(dgvDatos.CurrentRow.Cells("HoraParcial").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listarDatos()
                'RowPossesion(dgvDatos, frm.codMer, frm.FecRegistroNuevo.ToString)
            End If
            listarDatos()
            'RowPossesion(dgvDatos, frm.codMer, frm.FecRegistroAnt.ToString)
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR LA FECHA DE REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
                'ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                '    MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("IdHistorial").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class