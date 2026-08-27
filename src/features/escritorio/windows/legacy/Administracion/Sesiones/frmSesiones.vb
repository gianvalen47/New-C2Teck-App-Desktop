Imports System.ServiceModel
Public Class frmSesiones

    '===========================Servicios====================================================
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatosSesion As New DataTable
    Private dtDatosOpciones As New DataTable

    Private Sub frmSesiones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 230)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatosSesion)
        dgvDatosSesion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosSesion.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.cargaEstiloGrid_Bucadores(dgvDatosOpciones)
        dgvDatosOpciones.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        dgvDatosOpciones.RowFormatStyle.FontSize = 9.0!
        dgvDatosOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dgvDatosOpciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ListaDatosSesiones()
    End Sub

    Private Sub Finalizar()
        Try          
            oSeguridadService.close()
        Catch ex As TimeoutException        
            oSeguridadService.Abort()
        Catch ex As CommunicationException            
            oSeguridadService.Abort()
        End Try
    End Sub


    Private Sub frmSesiones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TabSesiones.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F3 Then
            TabSesiones.SelectedIndex = "1"
        End If
    End Sub

    Private Sub ListaDatosSesiones()
        Try
            dtDatosSesion = oSeguridadService.MostrarSesion(txtFechaInicio.Value, txtUsuario.Text).Tables(0)
            dgvDatosSesion.DataSource = dtDatosSesion
            enableOpciones()

            lblTotalReg.Text = "Total Registros : " & dtDatosSesion.Rows.Count().ToString

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR SESIONES: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ListaDatosOpciones()
        Try
            dtDatosOpciones = oSeguridadService.MostrarSesionOpciones(IIf(dgvDatosSesion.RowCount > 0, toNumber(dgvDatosSesion.CurrentRow.Cells("IdSesion").Value), 0)).Tables(0)
            dgvDatosOpciones.DataSource = dtDatosOpciones
            enableOpciones()

            lblUsuario.Text = "Usuario : " & dgvDatosSesion.CurrentRow.Cells("CodUsu").Value

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR OPCIONES DE SESION: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatosSesion_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatosSesion.SelectionChanged
        If dgvDatosSesion.RowCount > 0 Then
            'lblIdAfp.Text = dgvDatosAFP.CurrentRow.Cells("IdAfp").Value.ToString
            'txtDesAfp.Text = dgvDatosAFP.CurrentRow.Cells("DesAfp").Text
            ListaDatosOpciones()
        Else
            'lblIdAfp.Text = ""
            'txtDesAfp.Text = ""
            dgvDatosOpciones.DataSource = Nothing
        End If
    End Sub

    Private Sub enableOpciones()
        'If dgvDatosAFP.RowCount > 0 Then
        '    miEliminarAfp.Enabled = True
        '    miMostrarAfp.Enabled = True
        'Else
        '    miEliminarAfp.Enabled = False
        '    miMostrarAfp.Enabled = False
        'End If

        'If dgvDatosRubroDscto.RowCount > 0 Then
        '    miEliminarRubro.Enabled = True
        '    miMostrarRubro.Enabled = True
        'Else
        '    miEliminarRubro.Enabled = False
        '    miMostrarRubro.Enabled = False
        'End If
        'miNuevoRubro.Enabled = IIf(dgvDatosAFP.RowCount > 0, True, False)
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '=================================== SESIONES ==============================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionSesiones(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdSesion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] SESIONES: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ActualizarSesiones()
        Try
            Dim codigo As String = ""
            If dgvDatosSesion.RowCount > 0 Then
                If IsDBNull(dgvDatosSesion.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosSesion.CurrentRow.Cells("IdSesion").Text
                End If
            End If
            dtDatosSesion = Nothing
            ListaDatosSesiones()
            If dgvDatosSesion.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionSesiones(dgvDatosSesion, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR SESIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarSesiones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarSesiones.Click
        ActualizarSesiones()
    End Sub

    Private Sub dgvDatosSesion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosSesion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosSesion.RowCount > 0 Then
                miActualizarSesiones_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================== OPCIONES DE SESION ===========================================
    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionOpcion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdSesion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] OPCIONES: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ActualizarOpciones()
        Try
            Dim codigo As String = ""
            If dgvDatosOpciones.RowCount > 0 Then
                If IsDBNull(dgvDatosOpciones.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosOpciones.CurrentRow.Cells("IdSesion").Text
                End If
            End If
            dtDatosOpciones = Nothing
            ListaDatosOpciones()
            If dgvDatosOpciones.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionOpcion(dgvDatosOpciones, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarOpcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarOpciones.Click
        ActualizarOpciones()
    End Sub

    Private Sub txtFechaInicio_ValueChanged(sender As Object, e As System.EventArgs) Handles txtFechaInicio.ValueChanged
        ListaDatosSesiones()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtUsuario.TextChanged
        ListaDatosSesiones()
    End Sub


End Class