Imports System.ServiceModel
Public Class frmTablero

    '===========================Servicios====================================================
    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmTablero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 163)
        '/*************************************************************************************/

        'Dim estilo As New Estilo
        'estilo.CargaEstiloGrid(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        txtFecha.Value = Today
        LlenarCombos()
        ListaDatos()
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        CalculateDate()
        ListaDatos()
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

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub CalculateDate()
        txtSemana.Text = DatePart(DateInterval.WeekOfYear, txtFecha.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) 'CStr(DatePart("ww", txtFecha.Value))
        txtMes.Text = CStr(Month(txtFecha.Value))
        txtAnio.Text = CStr(Year(txtFecha.Value))
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oIndicadoresAlmacenService.MostrarTablero(Session.sCodEmp, toNumber(cmbIdLocacion.Value), txtFecha.Value).Tables(0)
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
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
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

    'Private Sub biProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesar.Click, miProcesar.Click
    'Try
    '    Dim frm As New frmTablero_Procesar            
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
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
                frm.IdLocacion = cmbIdLocacion.Value
                frm.iCodRub = dgvDatos.CurrentRow.Cells("CodRub").Value
                frm.iGrupo = dgvDatos.CurrentRow.Cells("Grupo").Value
                frm.iSemana = CInt(txtSemana.Text)
                frm.DesIndicador = utils.toBlank(dgvDatos.CurrentRow.Cells("Indicador").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ListaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.Columns(2).DataMember = dtAlmacenes.Columns("AproDoc").ToString
            cmbIdLocacion.DropDownList.Columns(3).DataMember = dtAlmacenes.Columns("CodAlm").ToString
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

    Private Sub cmbIdLocacion_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        ListaDatos()
    End Sub
End Class