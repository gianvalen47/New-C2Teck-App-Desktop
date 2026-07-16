Imports System.ServiceModel

Public Class frmCalendario_Nuevo

    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public IdProceso As Integer
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmCalendario_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresAlmacenService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
        End Try
    End Sub

    Private Sub frmCalendario_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCalendario_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFechaInicio.Select()
        txtMeses.Value = 3
        llenarCombos()
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim estado_process As Integer

            oIndicadoresAlmacenService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(15)

            estado_process = oIndicadoresAlmacenService.ProcesarCalendario(utils.toNumber(cmbIdLocacion.Value), txtFechaInicio.Value, txtObservacion.Text, txtMeses.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process <> 0 Then
                IdProceso = estado_process
                MsgBox("Se procesó un nuevo calendario correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS " + ex.Message)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            'dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub
End Class