Public Class frmMaximosMinimo

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmMaximosMinimo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMaximosMinimo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        llenarCombos()
        txtanio.Value = Today.Year
        listaDatos()
    End Sub

    Private Sub llenarCombos()
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
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oLocacionMercaderiaService.MostrarHistoryMinMax(cmbIdLocacion.Value, txtanio.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRecalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRecalcular.Click, miRecalcular.Click
        Try
            Dim frm As New frmMaximoMinimo_Recalcular
            frm.IdLocacion = cmbIdLocacion.Value
            frm.Text = "Recalcular los Máximos y Mínimos "
            frm.lblLocacion.Text = cmbIdLocacion.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            If dgvDatos.RowCount = 0 Then
                MsgBox("No Existen Datos , Por Favor Verifique")
            Else
                Dim frm As New frmMaximoMinimo
                frm.IdMinMax = dgvDatos.CurrentRow.Cells("IdMinMax").Text
                frm.IdLocacion = cmbIdLocacion.Value
                frm.lblIdLocacion.Text = cmbIdLocacion.Text
                frm.Text = "Máximos y Mínimos del Número : " & dgvDatos.CurrentRow.Cells("IdMinMax").Text
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

                End If
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

   
    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click

    End Sub

    
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbIdLocacion.ValueChanged, cmbOficinas.ValueChanged, txtanio.ValueChanged
        listaDatos()
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

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If dgvDatos.RowCount = 0 Then
            MsgBox("No Existen Datos que Mostrar , Verifique ")
        Else
            biMostrar_Click(sender, e)
        End If
    End Sub

   
    Private Sub biRevertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRevertir.Click
        If MsgBox("¿Está Seguro de Revertir los Mínimos y Máximos ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

            Dim estado_process As Boolean
            estado_process = oLocacionMercaderiaService.AnularProcesoMinMax(cmbIdLocacion.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se Realizó la Reversión correctamente ", MsgBoxStyle.Information)
                listaDatos()

            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema", MsgBoxStyle.Information)

            End If

        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
End Class