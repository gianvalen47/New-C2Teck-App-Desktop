Imports System.ServiceModel
Public Class frmAreasCentroCosto

    '===========================Servicios====================================================
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatosUnidadNegocio As New DataTable
    Private dtDatosArea As New DataTable
    Private dtDatosCentroCosto As New DataTable


    Private Sub frmAreasCentroCosto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAreasCentroCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 234)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvUnidadNegocio)
        dgvUnidadNegocio.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvUnidadNegocio.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvAreas)
        dgvAreas.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvAreas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.cargaEstiloGrid_Bucadores(dgvCentroCosto)
        dgvCentroCosto.RowFormatStyle.FontSize = 9.0!
        dgvCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dgvCentroCosto.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        ListaDatosUnidades()

        dgvAreas.Select()
    End Sub

    Private Sub Finalizar()
        Try
            oCentroCostoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmAreasCentroCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub ListaDatosUnidades()
        Try
            dtDatosUnidadNegocio = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dgvUnidadNegocio.DataSource = dtDatosUnidadNegocio
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR UNIDADES DE NEGOCIO: " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub ListaDatosAreas()
        Try
            dtDatosArea = oCentroCostoService.MostrarAreas(Session.sCodEmp, IIf(dgvUnidadNegocio.RowCount > 0, dgvUnidadNegocio.CurrentRow.Cells("IdUnidad").Value, ""), "").Tables(0)
            dgvAreas.DataSource = dtDatosArea
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR AREAS: " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub ListaDatosCentroCosto()
        Try
            dtDatosCentroCosto = oCentroCostoService.FiltrarCentroCosto(IIf(dgvAreas.RowCount > 0, dgvAreas.CurrentRow.Cells("CodArea").Value, "")).Tables(0)
            dgvCentroCosto.DataSource = dtDatosCentroCosto
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub dgvUnidadNegocio_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUnidadNegocio.SelectionChanged
        If dgvUnidadNegocio.RowCount > 0 Then
            lblIdUnidad.Text = dgvUnidadNegocio.CurrentRow.Cells("IdUnidad").Value.ToString
            lblDesUnidad.Text = dgvUnidadNegocio.CurrentRow.Cells("DesUnidad").Text.ToUpper
            ListaDatosAreas()
        Else
            lblIdUnidad.Text = ""
            lblDesUnidad.Text = ""
            dgvAreas.DataSource = Nothing
        End If
    End Sub

    Private Sub dgvAreas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAreas.SelectionChanged
        If dgvAreas.RowCount > 0 Then
            lblCodArea.Text = dgvAreas.CurrentRow.Cells("CodArea").Value.ToString
            lblDesArea.Text = dgvAreas.CurrentRow.Cells("DesArea").Text.ToUpper
            ListaDatosCentroCosto()
        Else
            lblCodArea.Text = ""
            lblDesArea.Text = ""
            dgvCentroCosto.DataSource = Nothing
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvAreas.RowCount > 0 Then
            miEliminarArea.Enabled = True
            miMostrarArea.Enabled = True
        Else
            miEliminarArea.Enabled = False
            miMostrarArea.Enabled = False
        End If

        If dgvCentroCosto.RowCount > 0 Then
            miEliminarCentroCosto.Enabled = True
            miMostrarCentroCosto.Enabled = True
        Else
            miEliminarCentroCosto.Enabled = False
            miMostrarCentroCosto.Enabled = False
        End If
        miNuevoCentroCosto.Enabled = IIf(dgvAreas.RowCount > 0, True, False)
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================ UNIDADES DE NEGOCIO =======================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionUnidadNegocio(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdUnidad").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] UNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizarDetallesUnidad()
        Try
            Dim codigo As String = ""
            If dgvUnidadNegocio.RowCount > 0 Then
                If IsDBNull(dgvUnidadNegocio.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvUnidadNegocio.CurrentRow.Cells("IdUnidad").Text
                End If
            End If
            dtDatosUnidadNegocio = Nothing
            ListaDatosUnidades()
            If dgvUnidadNegocio.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionUnidadNegocio(dgvUnidadNegocio, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR UNIDADES DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '================================== ÁREAS =============================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionArea(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("CodArea").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] AREA: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoArea()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmArea
                frm.IdUnidad = lblIdUnidad.Text
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosArea = Nothing
                    ListaDatosAreas()
                    If frm.type_process = "insert" Then
                        RowPossesionArea(dgvAreas, frm.CodArea)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA AREA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarArea()
        Try
            Dim frm As New frmArea
            frm.state_button = True
            frm.CodArea = dgvAreas.CurrentRow.Cells("CodArea").Text
            frm.IdUnidad = lblIdUnidad.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosArea = Nothing
                ListaDatosAreas()
                If frm.type_process = "update" Then
                    RowPossesionArea(dgvAreas, frm.CodArea)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionArea(dgvAreas, frm.CodArea)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR AREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarArea()
        Try
            cmbOpcionesArea.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Área con Código = " + dgvAreas.CurrentRow.Cells("CodArea").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCentroCostoService.BorrarArea(dgvAreas.CurrentRow.Cells("CodArea").Text)
                If estado_process = True Then
                    dtDatosArea = Nothing
                    ListaDatosAreas()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR AREA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesArea()
        Try
            Dim codigo As String = ""
            If dgvAreas.RowCount > 0 Then
                If IsDBNull(dgvAreas.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvAreas.CurrentRow.Cells("CodArea").Text
                End If
            End If
            dtDatosArea = Nothing
            ListaDatosAreas()
            If dgvAreas.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionArea(dgvAreas, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR AREAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoArea.Click
        NuevoArea()
    End Sub

    Private Sub miMostrarArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarArea.Click, dgvAreas.DoubleClick
        mostrarArea()
    End Sub

    Private Sub miEliminarArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarArea.Click
        eliminarArea()
    End Sub

    Private Sub miActualizarArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarArea.Click
        actualizarDetallesArea()
    End Sub

    Private Sub dgvAreas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAreas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvAreas.RowCount > 0 Then
                miMostrarArea_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================ CENTRO DE COSTO =========================================
    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionCentroCosto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("CodCentro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] CENTRO COSTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoCentroCosto()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmCentroCosto
                frm.state_button = False
                frm.CodArea = lblCodArea.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosCentroCosto = Nothing
                    ListaDatosCentroCosto()
                    If frm.type_process = "insert" Then
                        RowPossesionCentroCosto(dgvCentroCosto, frm.CodCentro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarCentroCosto()
        Try
            Dim frm As New frmCentroCosto
            frm.state_button = True
            frm.CodArea = dgvCentroCosto.CurrentRow.Cells("CodArea").Text
            frm.CodCentro = dgvCentroCosto.CurrentRow.Cells("CodCentro").Text
            'frm.estado = oOrdenesCompraService.ObtenerEstado(toNumber(txtNumOrden.Text))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosCentroCosto = Nothing
                ListaDatosCentroCosto()
                If frm.type_process = "update" Then
                    RowPossesionCentroCosto(dgvCentroCosto, frm.CodCentro)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionCentroCosto(dgvCentroCosto, frm.CodCentro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarCentroCosto()
        Try
            cmbOpcionesCentroCosto.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Centro de Costo con Código = " + dgvCentroCosto.CurrentRow.Cells("CodCentro").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCentroCostoService.BorrarCentroCosto(dgvCentroCosto.CurrentRow.Cells("CodCentro").Text)
                If estado_process = True Then
                    dtDatosCentroCosto = Nothing
                    ListaDatosCentroCosto()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CENTRO DE COSTO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesCentroCosto()
        Try
            Dim codigo As String = ""
            If dgvCentroCosto.RowCount > 0 Then
                If IsDBNull(dgvCentroCosto.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvCentroCosto.CurrentRow.Cells("CodCentro").Text
                End If
            End If
            dtDatosCentroCosto = Nothing
            ListaDatosCentroCosto()
            If dgvCentroCosto.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionCentroCosto(dgvCentroCosto, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoCentroCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoCentroCosto.Click
        NuevoCentroCosto()
    End Sub

    Private Sub miMostrarCentroCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCentroCosto.Click, dgvCentroCosto.DoubleClick
        mostrarCentroCosto()
    End Sub

    Private Sub miEliminarCentroCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarCentroCosto.Click
        eliminarCentroCosto()
    End Sub

    Private Sub miActualizarCentroCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarCentroCosto.Click
        actualizarDetallesCentroCosto()
    End Sub

    Private Sub dgvCentroCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCentroCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvCentroCosto.RowCount > 0 Then
                miMostrarCentroCosto_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biImprimir_Click(sender As System.Object, e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptListadoCentroCosto
            Dim dtReporte As DataTable

            dtReporte = oCentroCostoService.Imprimir(Session.sCodEmp).Tables(0)

            reporte.SetDataSource(dtReporte)
            forma.crvReportes.ReportSource = reporte
            'forma.crvReportes.DisplayGroupTree = False
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.Text = "Listado de Centros de Costo"
            forma.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class