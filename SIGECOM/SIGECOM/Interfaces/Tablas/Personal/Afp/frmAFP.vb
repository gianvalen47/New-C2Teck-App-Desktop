Imports System.ServiceModel
Public Class frmAFP

    '===========================Servicios====================================================
    Private oAfpService As New AfpService.AfpServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatosAFPs As New DataTable
    Private dtRubrosDscto As New DataTable

    Private Sub frmAFP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 230)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatosAFP)
        dgvDatosAFP.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosAFP.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.cargaEstiloGrid_Bucadores(dgvDatosRubroDscto)
        dgvDatosRubroDscto.RowFormatStyle.FontSize = 9.0!
        dgvDatosRubroDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dgvDatosRubroDscto.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosRubroDscto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ListaDatosAfps()
    End Sub

    Private Sub Finalizar()
        Try
            oAfpService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oAfpService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oAfpService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmAFP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TabAfps.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F3 Then
            TabAfps.SelectedIndex = "1"
        End If
    End Sub

    Private Sub ListaDatosAfps()
        Try
            dtDatosAFPs = oAfpService.Filtrar().Tables(0)
            dgvDatosAFP.DataSource = dtDatosAFPs
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR AFPs: " + ex.Message, MsgBoxStyle.Critical)
        End Try     
    End Sub

    Private Sub ListaDatosRubro()
        Try
            dtRubrosDscto = oAfpService.MostrarRubroDescuento(Session.sCodEmp, IIf(dgvDatosAFP.RowCount > 0, toNumber(dgvDatosAFP.CurrentRow.Cells("IdAfp").Value), 0)).Tables(0)
            dgvDatosRubroDscto.DataSource = dtRubrosDscto
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR RUBROS DESCUENTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatosMayor_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatosAFP.SelectionChanged
        If dgvDatosAFP.RowCount > 0 Then
            lblIdAfp.Text = dgvDatosAFP.CurrentRow.Cells("IdAfp").Value.ToString
            txtDesAfp.Text = dgvDatosAFP.CurrentRow.Cells("DesAfp").Text
            ListaDatosRubro()
        Else
            lblIdAfp.Text = ""
            txtDesAfp.Text = ""
            dgvDatosRubroDscto.DataSource = Nothing
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatosAFP.RowCount > 0 Then
            miEliminarAfp.Enabled = True
            miMostrarAfp.Enabled = True
        Else
            miEliminarAfp.Enabled = False
            miMostrarAfp.Enabled = False
        End If

        If dgvDatosRubroDscto.RowCount > 0 Then
            miEliminarRubro.Enabled = True
            miMostrarRubro.Enabled = True
        Else
            miEliminarRubro.Enabled = False
            miMostrarRubro.Enabled = False
        End If
        miNuevoRubro.Enabled = IIf(dgvDatosAFP.RowCount > 0, True, False)
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '=================================== AFPs ==============================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionAfp(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdAfp").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] AFPs: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoAfp()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAfp_Nuevo
                frm.state_button = False                
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosAFPs = Nothing
                    ListaDatosAfps()
                    If frm.type_process = "insert" Then
                        RowPossesionAfp(dgvDatosAFP, frm.IdAfp)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA AFP: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarAfp()
        Try
            Dim frm As New frmAfp_Nuevo
            frm.state_button = True
            frm.IdAfp = toNumber(dgvDatosAFP.CurrentRow.Cells("IdAfp").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosAFPs = Nothing
                ListaDatosAfps()
                If frm.type_process = "update" Then
                    RowPossesionAfp(dgvDatosAFP, frm.IdAfp)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionAfp(dgvDatosAFP, frm.IdAfp)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR AFP : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarAfp()
        Try
            cmbOpcionesAfp.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la AFP con Código = " + dgvDatosAFP.CurrentRow.Cells("IdAfp").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oAfpService.Borrar(toNumber(dgvDatosAFP.CurrentRow.Cells("IdAfp").Text))
                If estado_process = True Then
                    dtDatosAFPs = Nothing
                    ListaDatosAfps()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR AFP:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarAFPs()
        Try
            Dim codigo As String = ""
            If dgvDatosAFP.RowCount > 0 Then
                If IsDBNull(dgvDatosAFP.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosAFP.CurrentRow.Cells("IdAfp").Text
                End If
            End If
            dtDatosAFPs = Nothing
            ListaDatosAfps()
            If dgvDatosAFP.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionAfp(dgvDatosAFP, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR AFPs: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoAfp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoAfp.Click
        NuevoAfp()
    End Sub

    Private Sub miMostrarAfp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarAfp.Click, dgvDatosAFP.DoubleClick
        mostrarAfp()
    End Sub

    Private Sub miEliminarAfp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarAfp.Click
        eliminarAfp()
    End Sub

    Private Sub miActualizarAfp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarAfp.Click
        ActualizarAFPs()
    End Sub

    Private Sub dgvDatosMayor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosAFP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosAFP.RowCount > 0 Then
                miMostrarAfp_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================== RUBRO DSCTO ===========================================
    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionRubro(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubroDes").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] RUBRO DESCUENTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoRubroDscto()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAfp_RubroDscto
                frm.IdAfp = toNumber(lblIdAfp.Text)
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtRubrosDscto = Nothing
                    ListaDatosRubro()
                    If frm.type_process = "insert" Then
                        RowPossesionRubro(dgvDatosRubroDscto, frm.IdRubroDes)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO RUBRO DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarRubroDscto()
        Try
            Dim frm As New frmAfp_RubroDscto
            frm.state_button = True
            frm.IdAfp = toNumber(dgvDatosRubroDscto.CurrentRow.Cells("IdAfp").Value)
            frm.IdRubroDes = toNumber(dgvDatosRubroDscto.CurrentRow.Cells("IdRubroDes").Value)
            frm.IdModalidad = toNumber(dgvDatosRubroDscto.CurrentRow.Cells("IdModalidad").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtRubrosDscto = Nothing
                ListaDatosRubro()
                If frm.type_process = "update" Then
                    RowPossesionRubro(dgvDatosRubroDscto, frm.IdRubroDes)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionRubro(dgvDatosRubroDscto, frm.IdRubroDes)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR RUBRO DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarRubroDscto()
        Try
            cmbOpcionesRubroDscto.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el RUBRO DESCUENTO con Código = " + dgvDatosRubroDscto.CurrentRow.Cells("IdRubroDes").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oAfpService.BorrarRubroDescuento(Session.sCodEmp, toNumber(dgvDatosRubroDscto.CurrentRow.Cells("IdAfp").Value), toNumber(dgvDatosRubroDscto.CurrentRow.Cells("IdModalidad").Value), toNumber(dgvDatosRubroDscto.CurrentRow.Cells("IdRubroDes").Value))
                If estado_process = True Then
                    dtRubrosDscto = Nothing
                    ListaDatosRubro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR RUBRO DESCUENTO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarRubroDscto()
        Try
            Dim codigo As String = ""
            If dgvDatosRubroDscto.RowCount > 0 Then
                If IsDBNull(dgvDatosRubroDscto.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosRubroDscto.CurrentRow.Cells("IdRubroDes").Text
                End If
            End If
            dtRubrosDscto = Nothing
            ListaDatosRubro()
            If dgvDatosRubroDscto.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionRubro(dgvDatosRubroDscto, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR RUBROS DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoRubro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoRubro.Click
        NuevoRubroDscto()
    End Sub

    Private Sub miMostrarRubro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarRubro.Click, dgvDatosRubroDscto.DoubleClick
        mostrarRubroDscto()
    End Sub

    Private Sub miEliminarRubro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarRubro.Click
        eliminarRubroDscto()
    End Sub

    Private Sub miActualizarRubro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarRubro.Click
        ActualizarRubroDscto()
    End Sub

    Private Sub dgvDatosRubroDscto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosRubroDscto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosRubroDscto.RowCount > 0 Then
                miMostrarRubro_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
End Class