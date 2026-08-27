Imports System.ServiceModel
Public Class frmRubrosPlanilla

    '===========================Servicios====================================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatosIngresos As New DataTable
    Private dtDatosDsctos As New DataTable

    Private Sub frmRubrosPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 186)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatosIngresos)
        dgvDatosIngresos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        Dim estilo1 As New Estilo
        estilo1.cargaEstiloGrid_Bucadores(dgvDatosDsctos)
        dgvDatosDsctos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosDsctos.RowFormatStyle.FontSize = 9.0!
        dgvDatosDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        ListaDatosIngresos()
        ListaDatosDescuentos()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosDetService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oPlanillaSueldosDetService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oPlanillaSueldosDetService.Abort()
            oSeguridadService.abort()
        End Try
    End Sub

    Private Sub frmRubrosPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TabCuentas.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F3 Then
            TabCuentas.SelectedIndex = "1"
        End If
    End Sub

    Private Sub ListaDatosIngresos()
        dtDatosIngresos = oPlanillaSueldosDetService.FiltrarRubroIngreso(Session.sCodEmp).Tables(0)
        dgvDatosIngresos.DataSource = dtDatosIngresos
        enableOpciones()
    End Sub

    Private Sub ListaDatosDescuentos()
        dtDatosDsctos = oPlanillaSueldosDetService.FiltrarRubroDescuento(Session.sCodEmp).Tables(0)
        dgvDatosDsctos.DataSource = dtDatosDsctos
        enableOpciones()
    End Sub

    Private Sub enableOpciones()
        If dgvDatosIngresos.RowCount > 0 Then
            miEliminarIng.Enabled = True
            miMostrarIng.Enabled = True
        Else
            miEliminarIng.Enabled = False
            miMostrarIng.Enabled = False
        End If

        If dgvDatosDsctos.RowCount > 0 Then
            miEliminarDscto.Enabled = True
            miMostrarDscto.Enabled = True
        Else
            miEliminarDscto.Enabled = False
            miMostrarDscto.Enabled = False
        End If        
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===============================RUBRO INGRESO=========================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionIngreso(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdRubroIng").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrarIng()
        Try
            Dim frm As New frmIngresoPlanilla
            frm.state_button = True
            frm.IdRubroIng = toNumber(dgvDatosIngresos.CurrentRow.Cells("IdRubroIng").Text)
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosIngresos = Nothing
                ListaDatosIngresos()
                If frm.type_process = "update" Then
                    RowPossesionIngreso(dgvDatosIngresos, frm.IdRubroIng)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionIngreso(dgvDatosIngresos, frm.IdRubroIng)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarIng()
        Try
            cmOpcionesIng.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Ingreso de Planilla Seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarRubroIngreso(toNumber(dgvDatosIngresos.CurrentRow.Cells("IdRubroIng").Value))
                If estado_process = True Then
                    dtDatosIngresos = Nothing
                    ListaDatosIngresos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL INGRESO DE PLANILLA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoIng()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmIngresoPlanilla
                frm.state_button = False
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosIngresos = Nothing
                    ListaDatosIngresos()
                    If frm.type_process = "insert" Then
                        RowPossesionIngreso(dgvDatosIngresos, frm.IdRubroIng)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarIngreso()
        Dim codigo As String = ""
        If dgvDatosIngresos.RowCount > 0 Then
            codigo = dgvDatosIngresos.CurrentRow.Cells("IdRubroIng").Text
        End If
        dtDatosIngresos = Nothing
        ListaDatosIngresos()
        If dgvDatosIngresos.RowCount > 0 And codigo.Trim.Length Then
            RowPossesionIngreso(dgvDatosIngresos, codigo)
        End If
    End Sub

    Private Sub miNuevoIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoIng.Click
        NuevoIng()
    End Sub

    Private Sub miMostrarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarIng.Click, dgvDatosIngresos.DoubleClick
        mostrarIng()
    End Sub

    Private Sub miEliminarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarIng.Click
        eliminarIng()
    End Sub

    Private Sub miActualizarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarIng.Click
        ActualizarIngreso()
    End Sub

    Private Sub dgvDatosIngresos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosIngresos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosIngresos.RowCount > 0 Then
                miMostrarIng_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===============================RUBRO DESCUENTO=======================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionDscto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdRubroDes").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrarDscto()
        Try
            Dim frm As New frmDsctoPlanilla
            frm.state_button = True
            frm.IdRubroDes = toNumber(dgvDatosDsctos.CurrentRow.Cells("IdRubroDes").Text)
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosDsctos = Nothing
                ListaDatosDescuentos()
                If frm.type_process = "update" Then
                    RowPossesionDscto(dgvDatosDsctos, frm.IdRubroDes)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionDscto(dgvDatosDsctos, frm.IdRubroDes)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDscto()
        Try
            cmOpcionesDscto.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Descuento de Planilla Seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosDetService.BorrarRubroDescuento(toNumber(dgvDatosDsctos.CurrentRow.Cells("IdRubroDes").Value))
                If estado_process = True Then
                    dtDatosDsctos = Nothing
                    ListaDatosDescuentos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL DESCUENTO DE PLANILLA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDscto()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmDsctoPlanilla
                frm.state_button = False
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosDsctos = Nothing
                    ListaDatosDescuentos()
                    If frm.type_process = "insert" Then
                        RowPossesionDscto(dgvDatosDsctos, frm.IdRubroDes)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDscto()
        Dim codigo As String = ""
        If dgvDatosDsctos.RowCount > 0 Then
            codigo = dgvDatosDsctos.CurrentRow.Cells("IdRubroDes").Text
        End If
        dtDatosDsctos = Nothing
        ListaDatosDescuentos()
        If dgvDatosDsctos.RowCount > 0 And codigo.Trim.Length Then
            RowPossesionDscto(dgvDatosDsctos, codigo)
        End If
    End Sub

    Private Sub miNuevoDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoDscto.Click
        NuevoDscto()
    End Sub

    Private Sub miMostrarDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarDscto.Click, dgvDatosDsctos.DoubleClick
        mostrarDscto()
    End Sub

    Private Sub miEliminarDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarDscto.Click
        eliminarDscto()
    End Sub

    Private Sub miActualizarDscto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarDscto.Click
        ActualizarDscto()
    End Sub

    Private Sub dgvDatosDsctos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosDsctos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosDsctos.RowCount > 0 Then
                miMostrarDscto_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
End Class