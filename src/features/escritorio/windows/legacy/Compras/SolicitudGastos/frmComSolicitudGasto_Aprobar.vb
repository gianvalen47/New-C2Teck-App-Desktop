Imports System.ServiceModel
Public Class frmComSolicitudGasto_Aprobar

    '===========================Servicios====================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oPersona As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public IdGasto As Integer
    Public IdEstado As Integer
    Private dtCorreos As DataTable
    Private dtCentroCosto As DataTable
    Private dtCentroCostoSeleccionado As DataTable
    Public IdPersonaSolicita As Integer
    Public IdUnidad As Integer
    Private procesando As Boolean = False

    Private Sub frmComSolicitudGasto_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComSolicitudGasto_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If procesando = False Then
            If e.KeyCode = Keys.Escape Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmComSolicitudGasto_Aprobar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvCorreos)
        Me.Text = "Aprobar Solicitud de Gastos N°:" & IdGasto
        btnAprobar.Focus()



        'If IdUnidad = 2 Or IdUnidad = 3 Then
        'If IdUnidad = 3 Then
        If IdEstado = 8 Then
                Me.Size = New System.Drawing.Size(527, 378)
                gbCorreos.Visible = True
                gbCorreos.Text = "Lista de Correos"
                dgvCorreos.Visible = True
                dgvCentroCosto.Visible = False
                listarCorreos()
            Else
                'Me.Size = New System.Drawing.Size(527, 236)
                'gbCorreos.Visible = False

                estilo.cargaEstiloGridExt(dgvCentroCosto)
                gbCorreos.Visible = True
                gbCorreos.Text = "Centros de Costos Involucrados"
                dgvCorreos.Visible = False
                dgvCentroCosto.Visible = True
                listarCentroCostos()
            End If

        'Else

        '    estilo.cargaEstiloGridExt(dgvCentroCosto)
        '    gbCorreos.Visible = True
        '    gbCorreos.Text = "Centros de Costos Involucrados"
        '    dgvCorreos.Visible = False
        '    dgvCentroCosto.Visible = True
        '    listarCentroCostos()

        'End If


    End Sub

    'Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
    '    Try
    '        Dim estado_process As Boolean
    '        procesando = True
    '        '=====================================================APROBAR ===========================================
    '        If cbAprobar.Checked Then
    '            '=========================================== APROBACION JEFE DE AREA ===================================
    '            If IdUnidad = 2 Or IdUnidad = 3 Then
    '                If IdEstado = 8 Then
    '                    If MsgBox("¿Está seguro de APROBAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '                        Dim rows() As Janus.Windows.GridEX.GridEXRow
    '                        Dim Cadena As String = ""
    '                        rows = dgvCorreos.GetCheckedRows()
    '                        Dim row As Janus.Windows.GridEX.GridEXRow
    '                        If rows.Count <> 0 Then
    '                            For Each row In rows
    '                                If Cadena = "" Then
    '                                    Cadena = row.Cells("Email").Text
    '                                Else
    '                                    Cadena = Cadena + ";" + row.Cells("Email").Text
    '                                End If
    '                            Next
    '                            '================================APROBAR CON CORREOS SELECCIONADOS================================
    '                            estado_process = oSolicitudGastoService.Aprobar(IdGasto, Cadena, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                            If estado_process Then
    '                                MsgBox("Se Aprobó la solicitud de Gastos correctamente ")
    '                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                            End If
    '                        Else
    '                            MsgBox("Debe seleccionar alguno de los correos")
    '                        End If
    '                    End If
    '                    '========================================= APROBACION GERENCIA ==========================
    '                Else
    '                    If MsgBox("¿Está seguro de APROBAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '                        ' estado_process = oSolicitudGastoService.Aprobar(IdGasto, "", toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                        'MsgBox("Se Aprobó la solicitud de Gastos correctamente ")

    '                        Dim rows() As Janus.Windows.GridEX.GridEXRow
    '                        Dim Cadena As String = ""
    '                        rows = dgvCentroCosto.GetCheckedRows()
    '                        Dim row As Janus.Windows.GridEX.GridEXRow
    '                        If rows.Count <> 0 Then
    '                            For Each row In rows
    '                                estado_process = oSolicitudGastoService.AprobarCentroCosto(IdGasto, row.Cells("CodCentro").Text, utils.toDouble(row.Cells("Monto").Text), toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                            Next
    '                        End If

    '                        'Dim monto As Double = dgvCentroCosto2.CurrentRow.Cells("Monto").Value
    '                        'Dim codCentro As String = dgvCentroCosto2.CurrentRow.Cells("CodCentro").Value
    '                        'estado_process = oSolicitudGastoService.AprobarCentroCosto(IdGasto, codCentro, monto, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                        If estado_process = True Then
    '                            MsgBox("Se Aprobó el(los) centro(s) de costo seleccionado(s) de la solicitud de Gastos correctamente")
    '                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                        End If
    '                    End If
    '                End If

    '            Else   'ES PARA LAS DEMAS AREAS TENDRAN UNA SOLA APROBACION

    '                If IdEstado = 8 Or IdEstado = 2 Then
    '                    '========================================= APROBACION GERENCIA ==========================
    '                    If MsgBox("¿Está seguro de APROBAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '                        Dim rows() As Janus.Windows.GridEX.GridEXRow
    '                        Dim Cadena As String = ""
    '                        rows = dgvCentroCosto.GetCheckedRows()
    '                        Dim row As Janus.Windows.GridEX.GridEXRow
    '                        If rows.Count <> 0 Then
    '                            For Each row In rows
    '                                estado_process = oSolicitudGastoService.AprobarCentroCosto(IdGasto, row.Cells("CodCentro").Text, utils.toDouble(row.Cells("Monto").Text), toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                            Next
    '                        End If

    '                        If estado_process = True Then
    '                            MsgBox("Se Aprobó el(los) centro(s) de costo seleccionado(s) de la solicitud de Gastos correctamente")
    '                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                        End If

    '                    End If
    '                End If
    '            End If

    '            '======================================================RECHAZAR ==========================================
    '        ElseIf cbRechazar.Checked Then
    '            If MsgBox("¿Está seguro de RECHAZAR la solicitud de Gastos N°:" & IdGasto & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '                If txtObservacion.Text = "" Then
    '                    MsgBox("Debe ingresar la observación")
    '                    txtObservacion.Focus()
    '                Else
    '                    estado_process = oSolicitudGastoService.Rechazar(IdGasto, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                    If estado_process Then
    '                        MsgBox("Se rechazó la solicitud correctamente ")
    '                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                    End If
    '                End If
    '            End If
    '        End If
    '        procesando = False
    '    Catch ex As Exception
    '        MsgBox("Error al aprobar/desaprobar la solicitud de gastos : " + ex.Message, MsgBoxStyle.Exclamation)
    '        procesando = False
    '    End Try
    'End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            Dim estado_process As Boolean
            procesando = True
            '=====================================================APROBAR ===========================================
            If cbAprobar.Checked Then
                '=========================================== APROBACION JEFE DE AREA ===================================
                'If IdUnidad = 2 Or IdUnidad = 3 Then
                'If IdUnidad = 3 Then
                If IdEstado = 8 Then
                    If MsgBox("¿Está seguro de APROBAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim rows() As Janus.Windows.GridEX.GridEXRow
                        Dim Cadena As String = ""
                        rows = dgvCorreos.GetCheckedRows()
                        Dim row As Janus.Windows.GridEX.GridEXRow
                        If rows.Count <> 0 Then
                            For Each row In rows
                                If Cadena = "" Then
                                    Cadena = row.Cells("Email").Text
                                Else
                                    Cadena = Cadena + ";" + row.Cells("Email").Text
                                End If
                            Next
                            '================================APROBAR CON CORREOS SELECCIONADOS================================
                            estado_process = oSolicitudGastoService.AprobarJefe(IdGasto, Cadena, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            If estado_process Then
                                MsgBox("Se Aprobó la solicitud de Gastos correctamente ")
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            End If
                        Else
                            MsgBox("Debe seleccionar alguno de los correos")
                        End If
                    End If
                    '========================================= APROBACION GERENCIA ==========================
                Else
                    If MsgBox("¿Está seguro de APROBAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                        Dim row2 As DataRow

                        Dim dtCopia As New DataTable("tabla")
                        dtCopia.Columns.Add(New DataColumn("IdGasto", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("DesArea", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("CodCentro", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("DesCentro", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("Monto", Type.GetType("System.Double")))
                        dtCopia.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("Seleccion", Type.GetType("System.Boolean")))

                        dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", 0, "1", False})

                        dtCentroCostoSeleccionado = dtCopia.Copy
                        dtCentroCostoSeleccionado.Clear()

                        Dim rows() As Janus.Windows.GridEX.GridEXRow
                        rows = dgvCentroCosto.GetCheckedRows()
                        Dim row As Janus.Windows.GridEX.GridEXRow
                        If rows.Count <> 0 Then
                            For Each row In rows
                                'dtCentroCosto.Rows(0).Item("Seleccion") = 0
                                row2 = dtCentroCostoSeleccionado.NewRow
                                row2(0) = row.Cells("IdGasto").Text
                                row2(1) = row.Cells("DesArea").Text
                                row2(2) = row.Cells("CodCentro").Text
                                row2(3) = row.Cells("DesCentro").Text
                                row2(4) = row.Cells("Monto").Text
                                row2(5) = row.Cells("Estado").Text
                                row2(6) = True 'row.Cells("Seleccion").Text
                                dtCentroCostoSeleccionado.Rows.Add(row2)
                            Next
                            'dtCentroCosto.AcceptChanges()
                        End If

                        estado_process = oSolicitudGastoService.AprobarGerente(IdGasto, dtCentroCostoSeleccionado, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process = True Then
                            MsgBox("Se Aprobó el(los) centro(s) de costo seleccionado(s) de la solicitud de Gastos correctamente")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If

                'Else   'ES PARA LAS DEMAS AREAS TENDRAN UNA SOLA APROBACION

                '        If IdEstado = 8 Or IdEstado = 2 Then
                '            '========================================= APROBACION GERENCIA ==========================
                '            If MsgBox("¿Está seguro de APROBAR la solicitud de Gastos N°: " & IdGasto & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                '                Dim row2 As DataRow

                '                Dim dtCopia As New DataTable("tabla")
                '                dtCopia.Columns.Add(New DataColumn("IdGasto", Type.GetType("System.String")))
                '                dtCopia.Columns.Add(New DataColumn("DesArea", Type.GetType("System.String")))
                '                dtCopia.Columns.Add(New DataColumn("CodCentro", Type.GetType("System.String")))
                '                dtCopia.Columns.Add(New DataColumn("DesCentro", Type.GetType("System.String")))
                '                dtCopia.Columns.Add(New DataColumn("Monto", Type.GetType("System.Double")))
                '                dtCopia.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
                '                dtCopia.Columns.Add(New DataColumn("Seleccion", Type.GetType("System.Boolean")))

                '                dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", 0, "1", False})

                '                dtCentroCostoSeleccionado = dtCopia.Copy
                '                dtCentroCostoSeleccionado.Clear()

                '                Dim rows() As Janus.Windows.GridEX.GridEXRow
                '                rows = dgvCentroCosto.GetCheckedRows()
                '                Dim row As Janus.Windows.GridEX.GridEXRow
                '                If rows.Count <> 0 Then
                '                    For Each row In rows
                '                        'dtCentroCosto.Rows(0).Item("Seleccion") = 0
                '                        row2 = dtCentroCostoSeleccionado.NewRow
                '                        row2(0) = row.Cells("IdGasto").Text
                '                        row2(1) = row.Cells("DesArea").Text
                '                        row2(2) = row.Cells("CodCentro").Text
                '                        row2(3) = row.Cells("DesCentro").Text
                '                        row2(4) = row.Cells("Monto").Text
                '                        row2(5) = row.Cells("Estado").Text
                '                        row2(6) = True 'row.Cells("Seleccion").Text
                '                        dtCentroCostoSeleccionado.Rows.Add(row2)
                '                    Next
                '                    'dtCentroCosto.AcceptChanges()
                '                End If

                '                estado_process = oSolicitudGastoService.AprobarGerente(IdGasto, dtCentroCostoSeleccionado, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                '                If estado_process = True Then
                '                    MsgBox("Se Aprobó el(los) centro(s) de costo seleccionado(s) de la solicitud de Gastos correctamente")
                '                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                '                End If

                '            End If
                '        End If
                '    End If

                '======================================================RECHAZAR ==========================================
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Está seguro de RECHAZAR la solicitud de Gastos N°:" & IdGasto & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oSolicitudGastoService.Rechazar(IdGasto, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se rechazó la solicitud correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If
            End If
            procesando = False
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la solicitud de gastos : " + ex.Message, MsgBoxStyle.Exclamation)
            procesando = False
        End Try
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            Me.Size = New System.Drawing.Size(509, 236)
            gbCorreos.Visible = False
            txtObservacion.Focus()
        ElseIf cbAprobar.Checked And IdEstado = 8 Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(509, 378)
            gbCorreos.Visible = True
            btnAprobar.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(509, 236)
            gbCorreos.Visible = False
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            Me.Size = New System.Drawing.Size(509, 236)
            gbCorreos.Visible = False
            txtObservacion.Focus()
        ElseIf cbAprobar.Checked And IdEstado = 8 Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(509, 378)
            gbCorreos.Visible = True
            btnAprobar.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(509, 236)
            gbCorreos.Visible = False
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub listarCorreos()
        Try
            oPersona = oPersonaService.Obtener(IdPersonaSolicita)
            dtCorreos = oAsignacionJefesService.MostrarAprobarCompra(oPersona.CentroCosto.CodCentro).Tables(0)
            dgvCorreos.DataSource = dtCorreos
        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listarCentroCostos()
        Try

            dtCentroCosto = oSolicitudGastoService.MostrarCentroCostoInvolucrados(IdGasto, Session.sCodUsu).Tables(0)
            dgvCentroCosto.DataSource = dtCentroCosto

            For i = 0 To dgvCentroCosto.RowCount - 1

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvCentroCosto.GetRows()

                Dim row As Janus.Windows.GridEX.GridEXRow

                If rows.Count <> 0 Then
                    For Each row In rows
                        If row.Cells(7).Value = 1 Then  'Seleccion
                            row.IsChecked = True
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class