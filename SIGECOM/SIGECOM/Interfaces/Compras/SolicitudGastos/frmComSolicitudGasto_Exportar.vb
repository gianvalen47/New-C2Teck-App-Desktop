
Imports System.ServiceModel
Public Class frmComSolicitudGasto_Exportar

    '===========================Servicios====================================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    'Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtMeses As New DataTable
    Public IdGasto As Integer

    Private Sub frmComSolicitudGasto_Exportar_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_Exportar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Exportar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        txtAnio.Value = Today.Year
        Dim mesactual As String
        'Dim mesactualint As Integer
        If Len(CStr(Today.Month)) = 1 Then
            mesactual = "0" & Today.Month
        Else
            mesactual = Today.Month
        End If
        cmbMes.Value = mesactual
        txtFecha.Value = Today
    End Sub

    Private Sub llenarCombos()

        Try

            'dtIdioma = New DataTable
            'dtIdioma.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            'dtIdioma.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtIdioma.Rows.Add(New Object() {"1", "Español"}) ', New DateTime(2008, 2, 5)
            'dtIdioma.Rows.Add(New Object() {"2", "Inglés"})
            'dtIdioma.Rows.Add(New Object() {"3", "Alemán"})
            'dtIdioma.Rows.Add(New Object() {"4", "Italiano"})
            'dtIdioma.Rows.Add(New Object() {"5", "Portugués"})
            'dtIdioma.Rows.Add(New Object() {"6", "Francés"})

            dtMeses = New DataTable
            dtMeses.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
            dtMeses.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtMeses.Rows.Add(New Object() {"01", "ENERO"})
            dtMeses.Rows.Add(New Object() {"02", "FEBRERO"})
            dtMeses.Rows.Add(New Object() {"03", "MARZO"})
            dtMeses.Rows.Add(New Object() {"04", "ABRIL"})
            dtMeses.Rows.Add(New Object() {"05", "MAYO"})
            dtMeses.Rows.Add(New Object() {"06", "JUNIO"})
            dtMeses.Rows.Add(New Object() {"07", "JULIO"})
            dtMeses.Rows.Add(New Object() {"08", "AGOSTO"})
            dtMeses.Rows.Add(New Object() {"09", "SETIEMBRE"})
            dtMeses.Rows.Add(New Object() {"10", "OCTUBRE"})
            dtMeses.Rows.Add(New Object() {"11", "NOVIEMBRE"})
            dtMeses.Rows.Add(New Object() {"12", "DICIEMBRE"})



            '======================================= MESES ================================================
            'dtMeses = oMaestroService.MostrarMeses
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado As Boolean

            estado = oSolicitudGastoService.ExportarGasto(Session.sCodEmp, txtAnio.Value, cmbMes.Value, txtFecha.Value, IdGasto, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado Then
                MsgBox("Se exportó y contabilizó el documento correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            End If

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class