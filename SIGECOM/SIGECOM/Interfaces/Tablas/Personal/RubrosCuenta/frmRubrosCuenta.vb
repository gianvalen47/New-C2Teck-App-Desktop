Imports System.ServiceModel
Public Class frmRubrosCuenta

    '===========================Servicios====================================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatosIngresos As New DataTable
    Private dtDatosDsctos As New DataTable
    Private dtDatosAport As New DataTable
    Public IdRubroIng As Integer

    Private Sub frmRubrosCtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 192)
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

        Dim estilo2 As New Estilo
        estilo2.CargaEstiloGrid(dgvDatosAport)
        dgvDatosAport.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosAport.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ListaDatosIngresos()
        ListaDatosDescuentos()
        ListaDatosAportaciones()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()
            oSeguridadService.abort()
        End Try
    End Sub

    Private Sub frmMantCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TabCuentas.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F3 Then
            TabCuentas.SelectedIndex = "1"
        ElseIf e.KeyCode = Keys.F4 Then
            TabCuentas.SelectedIndex = "2"
        End If
    End Sub

    Private Sub ListaDatosIngresos()
        Try
            dtDatosIngresos = oPlanillaSueldosService.MostrarRubroIngresoCuentas(Session.sCodEmp, toNumber(txtIdRubroIng.Text)).Tables(0)
            dgvDatosIngresos.DataSource = dtDatosIngresos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE INGRESO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try       
    End Sub

    Private Sub ListaDatosDescuentos()
        Try
            dtDatosDsctos = oPlanillaSueldosService.MostrarRubroDescuentoCuentas(Session.sCodEmp).Tables(0)
            dgvDatosDsctos.DataSource = dtDatosDsctos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try        
    End Sub

    Private Sub ListaDatosAportaciones()
        Try
            dtDatosAport = oPlanillaSueldosService.MostrarRubroAportacionCuentas(Session.sCodEmp).Tables(0)
            dgvDatosAport.DataSource = dtDatosAport            
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE APORTACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try        
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

        If dgvDatosAport.RowCount > 0 Then
            miEliminarApor.Enabled = True
            miMostrarApor.Enabled = True
        Else
            miEliminarApor.Enabled = False
            miMostrarApor.Enabled = False
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===============================RUBRO INGRESO=========================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionIngreso(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal IdRubroIng As String, ByVal CodCentro As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdRubroIng").Value = IdRubroIng And row.Cells("CodCentro").Value = CodCentro Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrarIng()
        Try
            Dim frm As New frmIngresoCuenta
            frm.state_button = True
            frm.IdRubroIng = toNumber(dgvDatosIngresos.CurrentRow.Cells("IdRubroIng").Text)
            frm.CodCentro = dgvDatosIngresos.CurrentRow.Cells("CodCentro").Text
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosIngresos = Nothing
                ListaDatosIngresos()
                If frm.type_process = "update" Then
                    RowPossesionIngreso(dgvDatosIngresos, frm.IdRubroIng, frm.CodCentro)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionIngreso(dgvDatosIngresos, frm.IdRubroIng, frm.CodCentro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL INGRESO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarIng()
        Try
            cmOpcionesIng.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Ingreso de Cuenta Seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosService.BorrarRubroIngresoCuentas(toNumber(dgvDatosIngresos.CurrentRow.Cells("IdRubroIng").Value), dgvDatosIngresos.CurrentRow.Cells("CodCentro").Text)
                If estado_process = True Then
                    dtDatosIngresos = Nothing
                    ListaDatosIngresos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL INGRESO DE CUENTA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoIng()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmIngresoCuenta
                frm.state_button = False
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosIngresos = Nothing
                    ListaDatosIngresos()
                    If frm.type_process = "insert" Then
                        RowPossesionIngreso(dgvDatosIngresos, frm.IdRubroIng, frm.CodCentro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO INGRESO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarIngreso()
        Dim codigo As String = ""
        Dim centro As String = ""
        If dgvDatosIngresos.RowCount > 0 Then
            codigo = dgvDatosIngresos.CurrentRow.Cells("IdRubroIng").Text
            centro = dgvDatosIngresos.CurrentRow.Cells("CodCentro").Text
        End If
        dtDatosIngresos = Nothing
        ListaDatosIngresos()
        If dgvDatosIngresos.RowCount > 0 And codigo.Trim.Length Then
            RowPossesionIngreso(dgvDatosIngresos, codigo, centro)
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

    Private Sub RowPossesionDscto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal IdRubroDes As String, ByVal IdCuenta As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdRubroDes").Value = IdRubroDes And row.Cells("IdCuenta").Value = IdCuenta Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrarDscto()
        Try
            Dim frm As New frmDsctoCuenta
            frm.state_button = True
            frm.IdRubroDes = toNumber(dgvDatosDsctos.CurrentRow.Cells("IdRubroDes").Text)
            frm.IdCuenta = dgvDatosDsctos.CurrentRow.Cells("IdCuenta").Text
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosDsctos = Nothing
                ListaDatosDescuentos()
                If frm.type_process = "update" Then
                    RowPossesionDscto(dgvDatosDsctos, frm.IdRubroDes, frm.IdCuenta)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionDscto(dgvDatosDsctos, frm.IdRubroDes, frm.IdCuenta)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DESCUENTO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDscto()
        Try
            cmOpcionesDscto.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Descuento de Cuenta Seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosService.BorrarRubroDescuentoCuentas(toNumber(dgvDatosDsctos.CurrentRow.Cells("IdRubroDes").Value), toNumber(dgvDatosDsctos.CurrentRow.Cells("IdCuenta").Text))
                If estado_process = True Then
                    dtDatosDsctos = Nothing
                    ListaDatosDescuentos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL DESCUENTO DE CUENTA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDscto()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmDsctoCuenta
                frm.state_button = False
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosDsctos = Nothing
                    ListaDatosDescuentos()
                    If frm.type_process = "insert" Then
                        RowPossesionDscto(dgvDatosDsctos, frm.IdRubroDes, frm.IdCuenta)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DESCUENTO DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDscto()
        Dim codigo As String = ""
        Dim cuenta As String = ""
        If dgvDatosDsctos.RowCount > 0 Then
            codigo = dgvDatosDsctos.CurrentRow.Cells("IdRubroDes").Text
            cuenta = dgvDatosDsctos.CurrentRow.Cells("CodCuenta").Text
        End If
        dtDatosDsctos = Nothing
        ListaDatosDescuentos()
        If dgvDatosDsctos.RowCount > 0 And codigo.Trim.Length Then
            RowPossesionDscto(dgvDatosDsctos, codigo, cuenta)
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

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===============================RUBRO APORTACIÓN======================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionAportacion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal IdAportacion As String, ByVal CodCentro As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdAportacion").Value = IdAportacion And row.Cells("CodCentro").Value = CodCentro Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrarAport()
        Try
            Dim frm As New frmAportacionCuenta
            frm.state_button = True
            frm.IdAportacion = toNumber(dgvDatosAport.CurrentRow.Cells("IdAportacion").Text)
            frm.CodCentro = dgvDatosAport.CurrentRow.Cells("CodCentro").Text
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosAport = Nothing
                ListaDatosAportaciones()
                If frm.type_process = "update" Then
                    RowPossesionAportacion(dgvDatosAport, frm.IdAportacion, frm.CodCentro)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionAportacion(dgvDatosAport, frm.IdAportacion, frm.CodCentro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA APORTACIÓN DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarAport()
        Try
            cmOpcionesDscto.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Descuento de Planilla Seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPlanillaSueldosService.BorrarRubroAportacionCuentas(toNumber(dgvDatosAport.CurrentRow.Cells("IdAportacion").Value), dgvDatosAport.CurrentRow.Cells("CodCentro").Text)
                If estado_process = True Then
                    dtDatosAport = Nothing
                    ListaDatosAportaciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA APORTACIÓN DE CUENTA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoAport()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAportacionCuenta
                frm.state_button = False
                'frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosAport = Nothing
                    ListaDatosAportaciones()
                    If frm.type_process = "insert" Then
                        RowPossesionAportacion(dgvDatosAport, frm.IdAportacion, frm.CodCentro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA  APORTACIÓN DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarAport()
        Dim codigo As String = ""
        Dim centro As String = ""
        If dgvDatosAport.RowCount > 0 Then
            codigo = dgvDatosAport.CurrentRow.Cells("IdAportacion").Text
            centro = dgvDatosAport.CurrentRow.Cells("CodCentro").Text
        End If
        dtDatosAport = Nothing
        ListaDatosAportaciones()
        If dgvDatosAport.RowCount > 0 And codigo.Trim.Length Then
            RowPossesionAportacion(dgvDatosAport, codigo, centro)
        End If
    End Sub

    Private Sub miNuevoApor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoApor.Click
        NuevoAport()
    End Sub

    Private Sub miMostrarApor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarApor.Click, dgvDatosAport.DoubleClick
        mostrarAport()
    End Sub
    Private Sub miEliminarApor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarApor.Click
        eliminarAport()
    End Sub

    Private Sub miActualizarApor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarApor.Click
        ActualizarAport()
    End Sub

    Private Sub dgvDatosAport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosAport.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosAport.RowCount > 0 Then
                miMostrarApor_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtIdRubroIng.TextChanged
        ListaDatosIngresos()
    End Sub


End Class