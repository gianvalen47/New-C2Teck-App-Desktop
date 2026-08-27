Imports System.ServiceModel
Public Class frmListaOfertaNuevo

    Private oListaOfertaCabService As New ListaOfertaCabService.ListaOfertaCabServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtEstados As DataTable

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Private iEstado As Integer
    Private Mensaje As String = ""
    Private Sub frmListaOfertaNuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaOfertaCabService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oListaOfertaCabService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oListaOfertaCabService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmListaOfertaNuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub cmbEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnBuscar.Select()
            btnBuscar_Click(sender, e)
        End If
    End Sub

    Private Sub frmListaOfertaNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 205)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        'dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        'dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Me.Size = New System.Drawing.Size(978, 502)
        llenarCombos()
        listaDatos()
    End Sub

    Private Sub llenarCombos()

        '======================================= ESTADOS ================================================
        dtEstados = oListaOfertaCabService.MostrarEstados().Tables(0)
        dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
        cmbEstado.DataSource = dtEstados
        cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
        cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
        cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
        cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
        cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
        cmbEstado.SelectedIndex = 0
        dtEstados = Nothing

    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, cmbEstado.ValueChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()

        Try
            dtDatos = oListaOfertaCabService.Filtrar(Session.sCodEmp, cmbEstado.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()

        Catch ex As Exception
            MsgBox("Erros al listar datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar el codigo seleccionado: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub mostrar()
        Try
            Dim frm As New frmListaOfertaNuevo_Nuevo
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("DesEstado").Text
            frm.state_button = True
            frm.IdOferta = dgvDatos.CurrentRow.Cells("IdOferta").Text
            'frm.TipoLista = dgvDatos.CurrentRow.Cells("TipoLista").Text
            frm.editable = IIf((lEstado = "Generado" Or lEstado = "Aprobado"), True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumContrato.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdOferta)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("Error al mostrar la lista oferta : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdOferta").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biAprobar.Enabled = False
            biDarBaja.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miAprobar.Enabled = False
            miDarBaja.Enabled = False
        Else
            iEstado = dgvDatos.CurrentRow.Cells("IdEstado").Value
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biVerEstados.Enabled = True
            'biAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3, True, False)
            biAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3 Or (oListaOfertaCabService.BuscarAprobacionPendiente(dgvDatos.CurrentRow.Cells("IdOferta").Value) And iEstado = 4), True, False)
            biDarBaja.Enabled = IIf(iEstado = 4, True, False)
            biModificarValidez.Enabled = IIf(iEstado = 4, True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miVerEstados.Enabled = True
            'miAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3, True, False)
            miAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 3 Or (oListaOfertaCabService.BuscarAprobacionPendiente(dgvDatos.CurrentRow.Cells("IdOferta").Value) And iEstado = 4), True, False)
            miDarBaja.Enabled = IIf(iEstado = 4, True, False)
            miModificarValidez.Enabled = IIf(iEstado = 4, True, False)

        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdOferta").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Lista de Precio Nº " + dgvDatos.CurrentRow.Cells("IdOferta").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oListaOfertaCabService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdOferta").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar la lista oferta :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmListaOfertaNuevo_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOferta)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al Generar la lista oferta : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerEstados_Click(sender As Object, e As EventArgs) Handles biVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmListaOfertaNuevo_Estados
                frm.IdOferta = dgvDatos.CurrentRow.Cells("IdOferta").Value
                frm.Text = "Estados de la Lista de Oferta Nº " & dgvDatos.CurrentRow.Cells("IdOferta").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave,
                                 biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave,
                                 biAprobar.MouseLeave, biVerEstados.MouseLeave,
                                 miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave,
                                 miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave,
                                 miAprobar.MouseLeave, miVerEstados.MouseLeave, biModificarValidez.MouseLeave, miModificarValidez.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Lista de Oferta."
    End Sub
    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Lista de Oferta"
    End Sub
    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Lista de Oferta."
    End Sub

    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Lista de Oferta Seleccionada."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub
    Private Sub biModificarValidez_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biModificarValidez.MouseEnter, miModificarValidez.MouseEnter
        sslError.Text = "Modificar Fecha Vencimiento"
    End Sub

    Private Sub biAprobar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar la Lista de Oferta."
    End Sub

    Private Sub biVerEstados_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados."
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAprobar_Click(sender As Object, e As EventArgs) Handles biAprobar.Click, miAprobar.Click

        Try
            If dgvDatos.CurrentRow.Cells("IdOferta").Text <> "" Then

                Dim frm As New frmListaOfertaNuevo_Aprobar
                Dim frmGer As New frmListaOfertaNuevo_AprobarGerencia
                Dim estado As Integer

                'frm.IdLista = toNumber(dgvDatos.CurrentRow.Cells("IdLista").Text)
                'frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                'estado = dgvDatos.CurrentRow.Cells("IdEstado").Text

                If iEstado = 2 Then
                    frm.IdOferta = toNumber(dgvDatos.CurrentRow.Cells("IdOferta").Text)
                    frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                    estado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        Actualizar()
                    End If
                Else
                    frmGer.IdOferta = toNumber(dgvDatos.CurrentRow.Cells("IdOferta").Text)
                    frmGer.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                    estado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                    If frmGer.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        Actualizar()
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al aprobar la lista oferta : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biDarBaja_Click(sender As Object, e As EventArgs) Handles biDarBaja.Click, miDarBaja.Click

        Try
            If dgvDatos.CurrentRow.Cells("IdOferta").Text <> "" Then

                Dim frm As New frmListaOfertaNuevo_DarBaja
                frm.IdOferta = toNumber(dgvDatos.CurrentRow.Cells("IdOferta").Text)

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al aprobar la lista oferta : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptListaOfertaNuevo

            If dgvDatos.RowCount > 0 Then
                dtReporte = oListaOfertaCabService.Imprimir(dgvDatos.CurrentRow.Cells("IdOferta").Text).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    'reporte.SetParameterValue("Rubro", IIf((cmbRubro.Text = "(Todos)"), "(Todos)", cmbRubro.Text))
                    'reporte.SetParameterValue("CodMer", IIf((txtCodMer.Text = ""), "(Todos)", txtCodMer.Text))
                    'reporte.SetParameterValue("Estado", IIf((cmbEstados.Text = "(Todos)"), "(Todos)", cmbEstados.Text))
                    forma.Text = "Reporte de Oferta lista"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox("Error al imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biModificarValidez_Click(sender As Object, e As EventArgs) Handles biModificarValidez.Click, miModificarValidez.Click
        Try
            Dim frm As New frmListaOfertaNuevo_ModificarValidez
            'frm.FecVencimiento = CDate(dgvDatos.CurrentRow.Cells("FecVencimiento").Text)
            frm.IdOferta = toNumber(dgvDatos.CurrentRow.Cells("IdOferta").Text)
            frm.txtFecVencimiento.Value = CDate(dgvDatos.CurrentRow.Cells("FecVencimiento").Text)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdOferta)
            End If
        Catch ex As Exception
            MsgBox("Error de Datos", ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class