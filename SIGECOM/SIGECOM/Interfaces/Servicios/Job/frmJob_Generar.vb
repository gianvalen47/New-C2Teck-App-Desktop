Imports System.ServiceModel
Public Class frmJob_Generar

    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtDatos As DataTable
    Public NumJob As String
    Public IdCliente As Integer

    Private Sub frmJob_Generar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMaestroService.Close()
            oCotizacionService.Close()
            oLocacionClienteService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMaestroService.Abort()
            oCotizacionService.Abort()
            oLocacionClienteService.Close()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMaestroService.Abort()
            oCotizacionService.Abort()
            oLocacionClienteService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmJob_Generar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LlenarCombos()
        cmbIdLocacion.Value = 3
        txtNumDoc.Focus()

    End Sub

    Private Sub LlenarCombos()
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

            '======================================= LOCACIONES DEL CLIENTE ================================================
            dtDatos = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            cmbIdLocCli.DataSource = dtDatos
            cmbIdLocCli.DropDownList.DataMember = dtDatos.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.DisplayMember = dtDatos.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.ValueMember = dtDatos.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(0).DataMember = dtDatos.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(1).DataMember = dtDatos.Columns("Nombre").ToString
            dtDatos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR EL COMBO " + ex.Message, MsgBoxStyle.Exclamation)
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
            dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GENERAR la Guia de Remisión?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            GenerarDocumento()
        End If

    End Sub

    Private Sub GenerarDocumento()
        Try
            Dim estado_process As Boolean
            'If cmbTipo.Value <> 4 Then
            estado_process = oJobService.GenerarGuiaEntrega(NumJob, utils.toNumber(cmbIdLocacion.Value), utils.toNumber(txtNumDoc.Text), txtFecDoc.Value, utils.toNumber(cmbIdLocCli.Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            'Else
            '    estado_process = oCotizacionService.GenerarOrden(IdCotizacion, txtFecDoc.Text, txtNumDoc.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, DespachoTotal, IIf(cbDespacharTodo.Checked = True, Nothing, dtTable))
            'End If
            'type_process = "insert"
            If estado_process = True Then
                MsgBox("Se generó correctamente la Guia de Remisión...! " + vbCr + "Número : " + txtNumDoc.Text.ToString, MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean

        Try
            If txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del nuevo documento", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) = 0 Then
                MsgBox("Esta fecha no tiene tipo de cambio, Tenga cuidado...")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [GEN-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged

        txtNumDoc.Text = oCotizacionService.SugerirNumero(1, utils.toNumber(cmbIdLocacion.Value))

    End Sub
End Class