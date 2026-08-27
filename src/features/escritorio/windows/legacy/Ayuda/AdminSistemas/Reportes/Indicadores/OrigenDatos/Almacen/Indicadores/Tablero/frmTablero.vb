Imports System.ServiceModel
Public Class frmTablero

    '===========================Servicios====================================================
    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable

    Private Sub frmTablero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim estilo As New Estilo
        'estilo.CargaEstiloGrid(dgvDatos)
        txtFecha.Value = Today
        ListaDatos()
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        CalculateDate()
        ListaDatos()
    End Sub

    Private Sub CalculateDate()
        txtSemana.Text = DatePart(DateInterval.WeekOfYear, txtFecha.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) 'CStr(DatePart("ww", txtFecha.Value))
        txtMes.Text = CStr(Month(txtFecha.Value))
        txtAnio.Text = CStr(Year(txtFecha.Value))
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oIndicadoresAlmacenService.MostrarTablero(Session.sCodEmp, txtFecha.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub frmTablero_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmTablero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oIndicadoresAlmacenService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
        End Try
    End Sub

    'Private Sub biProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesar.Click, miProcesar.Click
    'Try
    '    Dim frm As New frmTablero_Procesar            
    '    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        ListaDatos()
    '    End If
    'Catch ex As Exception
    '    MsgBox("Error al PROCESAR cobertura de Tablero : " + ex.Message, MsgBoxStyle.Exclamation)
    'End Try
    'End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ListaDatos()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        ListaDatos()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biImprimir.MouseLeave, miImprimir.MouseLeave, _
                                biProcesar.MouseLeave, miProcesar.MouseLeave, _
                                biActualizar.MouseLeave, miActualizar.MouseLeave, _
                                biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Tablero."
    End Sub
    Private Sub Procesar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesar.MouseEnter, miProcesar.MouseEnter
        sslError.Text = "Procesar Tablero."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Grafica" Then
                Dim frm As New frmTablero_Grafica
                frm.iFecha = txtFecha.Value
                frm.iCodRub = dgvDatos.CurrentRow.Cells("CodRub").Value
                frm.iGrupo = dgvDatos.CurrentRow.Cells("Grupo").Value
                frm.iSemana = CInt(txtSemana.Text)
                frm.DesIndicador = utils.toBlank(dgvDatos.CurrentRow.Cells("Indicador").Value)
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ListaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class