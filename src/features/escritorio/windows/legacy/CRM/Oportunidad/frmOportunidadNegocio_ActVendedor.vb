Imports System.ServiceModel
Imports System.Net
Public Class frmOportunidadNegocio_ActVendedor

    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================
    Public IdOportunidad As Integer
    Private dtVendedor As DataTable

    Private Sub frmOportunidadNegocio_ActVendedor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = "Actualizar Vendedor de la Oportunidad de Negocio Nº " + Chr(34) + IdOportunidad.ToString + Chr(34)
        llenarCombos()
        cmbVendedor.Select()
    End Sub

    Private Sub frmOportunidadNegocio_ActVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_ActVendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
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
            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedoresVigente(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.SelectedIndex = 0
            dtVendedor = Nothing
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
            oPersonaService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de ACTUALIZAR el vendedor de la Oportunidad de Negocio N°: " & IdOportunidad.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If toNumber(cmbVendedor.Value) = 0 Then
                    MsgBox("Debe Seleccionar el Vendedor")
                    cmbVendedor.Focus()
                Else
                    estado_process = oOportunidadNegocioService.ActualizarVendedor(IdOportunidad, cmbVendedor.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se actualizó el Vendedor correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar Vendedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class