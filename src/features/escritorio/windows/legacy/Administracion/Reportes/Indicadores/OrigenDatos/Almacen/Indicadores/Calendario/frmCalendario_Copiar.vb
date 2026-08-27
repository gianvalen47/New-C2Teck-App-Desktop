Imports System.ServiceModel

Public Class frmCalendario_Copiar

    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient

    Public IdProceso As Integer
    Private dtRubros As DataTable

    Private Sub frmCalendario_Copiar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresAlmacenService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
        End Try
    End Sub

    Private Sub frmCalendario_Copiar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCalendario_Copiar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
    End Sub

    Private Sub llenarCombos()
        '======================================= RUBROS ================================================
        dtRubros = oIndicadoresAlmacenService.MostrarRubros.Tables(0)
        'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
        cmbRubro.DataSource = dtRubros
        cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
        cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
        cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
        cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
        cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
        cmbRubro.SelectedIndex = 0
        dtRubros = Nothing
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim dtCopiar As Boolean
            dtCopiar = oIndicadoresAlmacenService.CopiarAbcCalendario(IdProceso, cmbRubro.Value, cmbAbcConsumo.Text, txtFechaInicio.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If dtCopiar = True Then
                MsgBox("Se copió el calendario correctamente")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL COPIAR EL CALENDARIO " + ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class