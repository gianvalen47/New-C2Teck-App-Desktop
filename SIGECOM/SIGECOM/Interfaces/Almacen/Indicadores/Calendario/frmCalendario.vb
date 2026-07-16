Imports System.ServiceModel

Public Class frmCalendario

    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable

    Private Sub frmCalendario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresAlmacenService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmCalendario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCalendario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 161)
        '/*************************************************************************************/

        txtanio.Value = Year(Today)
        llenarCombos()
        ListaDatos()
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

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        Mostrar()
        'biActualizar_Click(sender, e)
        dgvDatos.Select()
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmCalendarioDetalle
                frm.IdProceso = CStr(dgvDatos.CurrentRow.Cells("IdProceso").Value)
                frm.IdLocacion = CStr(dgvDatos.CurrentRow.Cells("IdLocacion").Value)
                frm.Locacion = cmbIdLocacion.Text
                frm.ShowDialog()
            Else
                MsgBox("No existen datos, Verifique...")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oIndicadoresAlmacenService.MostrarProcesosCalendario(utils.toNumber(cmbIdLocacion.Value), txtanio.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub txtanio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtanio.ValueChanged, cmbIdLocacion.ValueChanged, cmbOficinas.ValueChanged
        ListaDatos()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    Mostrar()
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmCalendario_Nuevo

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListaDatos()
                RowPossesion(dgvDatos, frm.IdProceso)
            End If

        Catch ex As Exception
            MsgBox("Error al Procesar un Nuevo Calendario : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdProceso").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        ListaDatos()
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