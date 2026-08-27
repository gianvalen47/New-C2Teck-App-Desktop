Imports System.ServiceModel
Imports System.Net
Public Class frmOportunidadNegocio_ActEtapa

    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient

    '======================Declaración de Variables==============================
    Public IdOportunidad As Integer
    Private dtEtapa As DataTable

    Private Sub frmOportunidadNegocio_ActEtapa_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = "Actualizar Etapa de la Oportunidad de Negocio Nº " + Chr(34) + IdOportunidad.ToString + Chr(34)
        llenarCombos()
        cmbEtapa.Select()
    End Sub

    Private Sub frmOportunidadNegocio_ActEtapa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        finalizar()
    End Sub

    Private Function getRowVendedor(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception

        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception

        End Try

        Return fila
    End Function


    Private Sub llenarCombos()
        Try
            '======================================= Etapas ===========================================
            dtEtapa = oOportunidadNegocioService.MostrarEtapasPendientes(IdOportunidad).Tables(0) '''Preguntar
            dtEtapa.Rows.InsertAt(getRowVendedor(dtEtapa), 0)
            cmbEtapa.DataSource = dtEtapa
            cmbEtapa.DropDownList.DataMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.DisplayMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.ValueMember = dtEtapa.Columns("IdEtapa").ToString
            cmbEtapa.DropDownList.Columns(0).DataMember = dtEtapa.Columns("IdEtapa").ToString
            cmbEtapa.DropDownList.Columns(1).DataMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.Columns(2).DataMember = dtEtapa.Columns("Peso").ToString
            cmbEtapa.SelectedIndex = 0
            dtEtapa = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oOportunidadNegocioService.Close()            
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()            
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()            
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de ACTUALIZAR la Etapa de la Oportunidad de Negocio N°: " & IdOportunidad.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If toNumber(cmbEtapa.Value) = 0 Then
                    MsgBox("Debe Seleccionar la Etapa de Negocio")
                    cmbEtapa.Focus()
                ElseIf toBlank(txtObservacion.Text) = "" Then
                    MsgBox("Debe Ingresar la Observación")
                    txtObservacion.Focus()
                Else
                    estado_process = oOportunidadNegocioService.ActualizarEtapa(IdOportunidad, cmbEtapa.Value, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se actualizó la etapa correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar Etapa : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class