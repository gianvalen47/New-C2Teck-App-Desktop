Public Class frmVales
    Private oMaestroService As New MaestroService.MaestroClient
    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtTipos As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbMes.KeyPress _
                      , cmbIdSerieDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If

        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()

        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbMes.KeyPress _
                      , btnBuscar.KeyPress _
                      , cmbIdSerieDoc.KeyPress
        ', dgvDatos.KeyPress _
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdVale").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmVales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 3)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = False
        llenarCombos()
        txtanio.Value = Today.Year
        cmbMes.Value = Today.Month
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        cmbEstado.Value = "GN"
        state_Search = True
        listaDatos()

        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oValeMaterialService) = False Then
                oValeMaterialService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String, ByVal codLocacion As Integer, ByVal tipo As Integer)
    '    state_Search = False
    '    If type_process = "update" Then
    '        cmbEstado.Value = ""
    '        cmbIdSerieDoc.SelectedIndex = 0
    '        txtNumDoc.Text = numero
    '    ElseIf type_process = "insert" Then
    '        cmbEstado.Value = "GN"
    '        cmbIdSerieDoc.SelectedIndex = 0
    '        txtNumDoc.Text = numero
    '    End If
    '    cmbOficinas.Value = toNumber(oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", codLocacion))
    '    cmbIdLocacion.Value = codLocacion
    '    cmbIdSerieDoc.Value = tipo
    '    state_Search = True
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            miImprimir.Enabled = False
            miActualizar.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAtender.Enabled = False
            miDuplicarVale.Enabled = False
            biVerEstados.Enabled = False

            biImprimir.Enabled = False
            biactualizar.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAtender.Enabled = False
            biDuplicarVale.Enabled = False
            miVerEstados.Enabled = False
            miBajarNivel.Enabled = False
        Else
            miImprimir.Enabled = True
            miActualizar.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miAtender.Enabled = True
            miDuplicarVale.Enabled = True
            miVerEstados.Enabled = True

            biImprimir.Enabled = True
            biactualizar.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True
            biAtender.Enabled = True
            biDuplicarVale.Enabled = True
            biVerEstados.Enabled = True

            Dim lestado As String

            lestado = dgvDatos.CurrentRow.Cells("Estado").Text

            biEliminar.Enabled = IIf(lestado = "GENERADO", True, False)
            miEliminar.Enabled = IIf(lestado = "GENERADO", True, False)
            biAtender.Enabled = IIf(lestado = "GENERADO" And (Session.CodPerfil = "04" Or Session.CodPerfil = "16" Or Session.CodPerfil = "09" Or Session.CodPerfil = "26" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "28" Or Session.CodPerfil = "14" Or Session.CodPerfil = "15"), True, False)
            miAtender.Enabled = IIf(lestado = "GENERADO" And (Session.CodPerfil = "04" Or Session.CodPerfil = "16" Or Session.CodPerfil = "09" Or Session.CodPerfil = "26" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "28" Or Session.CodPerfil = "14" Or Session.CodPerfil = "15"), True, False)
            miBajarNivel.Enabled = IIf(lestado = "ATENDIDO" And (Session.CodPerfil = "04" Or Session.CodPerfil = "16" Or Session.CodPerfil = "09" Or Session.CodPerfil = "26" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "28" Or Session.CodPerfil = "14" Or Session.CodPerfil = "15"), True, False)

            'biactualizar.Enabled = IIf(lestado = "IMPRESO", False, True)
            'miActualizar.Enabled = IIf(lestado = "IMPRESO", False, True)
        End If

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

        Return fila
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmVale
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdVale = dgvDatos.CurrentRow.Cells("IdVale").Text
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.IdLocacion, frm.cmbIdSerieDoc.Value)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdVale)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Vale Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oValeMaterialService.Borrar(dgvDatos.CurrentRow.Cells("IdVale").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then            
                dtDatos = oValeMaterialService.Filtrar(txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toBlank(cmbIdSerieDoc.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumDoc.Text), txtNumJob.Text).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmVale
            frm.state_button = False
            frm.btnGuardar.Enabled = True
            frm.btnEditar.Enabled = False
            frm.btnDeshacer.Enabled = True
            frm.btnCancelar.Enabled = False
            frm.IdLocacion = cmbIdLocacion.Value
            '----
            frm.IdSerieDoc = cmbIdSerieDoc.Value
            frm.txtNumDoc.Text = oValeMaterialService.SugerirNumero(cmbIdSerieDoc.Value)
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion))
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.Text = "Registrar Nuevo " & cmbIdSerieDoc.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text, frm.IdLocacion, frm.cmbIdSerieDoc.Value)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdVale)
                    mostrar()
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub imprimir()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpVale
            Dim dtReporte As New DataView
            Dim IdVale As Integer = dgvDatos.CurrentRow.Cells("IdVale").Text

            dtReporte = oValeMaterialService.Imprimir(IdVale).Tables(0).DefaultView
            dtReporte.Sort = "UbiMer Asc"

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                forma.Text = "Reporte de Pedidos Internos para Importar"


                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdVale").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount <1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdVale").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing
            '======================================= ESTADOS ================================================
            dtEstados = oValeMaterialService.MostrarEstados()
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing
            '======================================= TIPOS  ================================================
            'dtTipos = oMaestroService.MostrarSerieDocumento(cmbIdLocacion.Value, 3, "").Tables(0)
            'cmbIdSerieDoc.DataSource = dtTipos
            'cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.SelectedIndex = 0
            'dtTipos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumJob.TextChanged
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cmbEstado.ValueChanged _
                  , cmbMes.ValueChanged _
                  , cmbIdSerieDoc.ValueChanged
        listaDatos()
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            'dtAlmacenes = oMaestroService.MostrarLocacionPorAlmacen(Session.sCodEmp, cmbOficinas.Value, "074", Session.sCodUsu).Tables(0)
            dtAlmacenes = oValeMaterialService.MostrarLocacionUsaVale(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
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
            'dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            pboxLimpiarCliente.Enabled = True
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        If ValidaCodigoSeleccionado() Then
            imprimir()
        End If
    End Sub

    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        actualizar()

    End Sub

    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        Try
            If toBlank(cmbOficinas.Value) <> "" Then
                dtTipos = oMaestroService.MostrarSerieDocumento(cmbIdLocacion.Value, 3, "").Tables(0)
                cmbIdSerieDoc.DataSource = dtTipos
                cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
                cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
                cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
                cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
                cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
                cmbIdSerieDoc.SelectedIndex = 0
                dtTipos = Nothing
            End If

            listaDatos()
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.Dispose()
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Vale."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Documento Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Vale ."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, biImprimir.MouseLeave, _
                                    biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, _
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        Try
            Dim frm As New frmVale_Generar
            frm.IdLocacion = cmbIdLocacion.Value
            frm.Locacion = cmbOficinas.Text
            frm.Almacen = cmbIdLocacion.Text
            frm.CodAlmacen = cmbIdLocacion.Value
            frm.IdSerieDoc = oGuiaRemisionService.MostraIdSerie(cmbIdLocacion.Value)
            frm.NumDoc = oGuiaRemisionService.SugerirNumero(frm.IdSerieDoc)
            'frm.Text = "Agregar Consumo de Job" & txtNumDoc.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAtender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAtender.Click, miAtender.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ATENDER el Vale de Almacen N°: " & dgvDatos.CurrentRow.Cells("NumDoc").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oValeMaterialService.Atender(dgvDatos.CurrentRow.Cells("IdVale").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Atendió correctamente el Vale de Almacen")
                        actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDuplicarVale_Click(sender As Object, e As EventArgs) Handles biDuplicarVale.Click, miDuplicarVale.Click
        Try
            Dim frm As New frmVale_Duplicar
            frm.Text = "Duplicar Vale"
            frm.IdVale = dgvDatos.CurrentRow.Cells("IdVale").Text
            'frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.txtNumDoc.Text = toNumber(oValeMaterialService.SugerirNumero(cmbIdSerieDoc.Value))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.txtNumDoc.Text)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biVerEstados_Click(sender As Object, e As EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmVale_VerEstados
                frm.IdVale = dgvDatos.CurrentRow.Cells("IdVale").Value
                frm.Text = "Estados del Vale Nº " & dgvDatos.CurrentRow.Cells("NumDoc").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miBajarNivel_Click(sender As Object, e As EventArgs) Handles miBajarNivel.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de BAJAR DE VIVEL el Vale de Almacen N°: " & dgvDatos.CurrentRow.Cells("NumDoc").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oValeMaterialService.DejarAtender(dgvDatos.CurrentRow.Cells("IdVale").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se BAJO DE NIVEL correctamente el Vale de Almacen")
                        actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class