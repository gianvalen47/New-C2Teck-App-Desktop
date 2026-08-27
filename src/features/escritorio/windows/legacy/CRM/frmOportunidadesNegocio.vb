Imports System.ServiceModel
Imports System.Net
Public Class frmOportunidadesNegocio

    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    Private dtVendedor As DataTable
    Public IdCliente As Integer
    Private dtEtapa As DataTable
    Private iEtapa As Integer

    Private Sub frmOportunidadNegocio_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        chkPersona.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkPersona, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = False
        llenarCombos()

        txtAnio.Value = Today.Year

        IdCliente = 0
        txtCliente.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtAnio.KeyPress _
                      , cmbVendedor.KeyPress _
                      , cmbEtapa.KeyPress _
                      , txtNombre.KeyPress _
                      , txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Function getRowVendedor(ByVal data As DataTable)
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

    '=============================Evento FormClosed==========================================
    Private Sub frmOportunidadesNegocio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOportunidadNegocioService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmOportunidadesNegocio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEtapa.Value = 0
            'txtIdGasto.Text = nro_Orden
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biMostrarCotizaciones.Enabled = False
            biActualizarEtapa.Enabled = False
            biActualizarVendedor.Enabled = False
            biVincularCotizacion.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miMostrarCotizaciones.Enabled = False
            miActualizarEtapa.Enabled = False
            miActualizarVendedor.Enabled = False
            miVincularCotizacion.Enabled = False
        Else
            iEtapa = dgvDatos.CurrentRow.Cells("IdEtapa").Value
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            biVerEstados.Enabled = True
            biMostrarCotizaciones.Enabled = True
            biActualizarEtapa.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            biActualizarVendedor.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            biVincularCotizacion.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            miVerEstados.Enabled = True
            miMostrarCotizaciones.Enabled = True
            miActualizarEtapa.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            miActualizarVendedor.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            miVincularCotizacion.Enabled = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdOportunidad").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmOportunidadNegocio            
            iEtapa = dgvDatos.CurrentRow.Cells("IdEtapa").Text
            frm.state_button = True
            frm.IdOportunidad = dgvDatos.CurrentRow.Cells("IdOportunidad").Text
            frm.editable = IIf(iEtapa = 1 Or iEtapa = 7, False, True)
            frm.edicion = False
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then                    
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdOportunidad)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA OPORTUNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Oportunidad de Negocio Nº " + dgvDatos.CurrentRow.Cells("IdOportunidad").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oOportunidadNegocioService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdOportunidad").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA OPORTUNIDAD DE NEGOCIO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmOportunidadNegocio
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOportunidad)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA OPORTUNIDAD DE NEGOCIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try

            '======================================= Etapas ===========================================
            dtEtapa = oOportunidadNegocioService.MostrarEtapasNegocio().Tables(0) '''Preguntar
            dtEtapa.Rows.InsertAt(getRowTodos(dtEtapa), 0)
            cmbEtapa.DataSource = dtEtapa
            cmbEtapa.DropDownList.DataMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.DisplayMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.ValueMember = dtEtapa.Columns("IdEtapa").ToString
            cmbEtapa.DropDownList.Columns(0).DataMember = dtEtapa.Columns("IdEtapa").ToString
            cmbEtapa.DropDownList.Columns(1).DataMember = dtEtapa.Columns("DesEtapa").ToString
            cmbEtapa.DropDownList.Columns(2).DataMember = dtEtapa.Columns("Peso").ToString
            cmbEtapa.SelectedIndex = 0
            dtEtapa = Nothing

            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedoresVigente.Tables(0)
            dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.SelectedIndex = 0
            dtVendedor = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oOportunidadNegocioService.Filtrar(Session.sCodEmp, toNumber(txtAnio.Value), IdCliente, toNumber(cmbVendedor.Value), toNumber(cmbEtapa.Value), txtNombre.Text).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtAnio.ValueChanged, txtCliente.TextChanged, cmbVendedor.ValueChanged, cmbEtapa.ValueChanged, txtNombre.TextChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdOportunidad").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub biActualizarVendedor_Click(sender As Object, e As System.EventArgs) Handles biActualizarVendedor.Click, miActualizarVendedor.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOportunidadNegocio_ActVendedor
                frm.IdOportunidad = dgvDatos.CurrentRow.Cells("IdOportunidad").Text

                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR Vendedor: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarEtapa_Click(sender As Object, e As System.EventArgs) Handles biActualizarEtapa.Click, miActualizarEtapa.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOportunidadNegocio_ActEtapa
                frm.IdOportunidad = dgvDatos.CurrentRow.Cells("IdOportunidad").Text

                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR Etapa: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVincularCotizacion_Click(sender As Object, e As System.EventArgs) Handles biVincularCotizacion.Click, miVincularCotizacion.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOportunidadNegocio_Vincular
                frm.IdOportunidad = dgvDatos.CurrentRow.Cells("IdOportunidad").Text
                frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al VINCULAR Cotización: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biNuevo.MouseLeave, biMostrar.MouseLeave, _
                               biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, _
                               miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                               miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                               miVerEstados.MouseLeave, biVerEstados.MouseLeave, biActualizarEtapa.MouseLeave, _
                               miActualizarEtapa.MouseLeave, biActualizarVendedor.MouseLeave, miActualizarVendedor.MouseLeave, _
                               miMostrarCotizaciones.MouseLeave, biMostrarCotizaciones.MouseLeave, miVincularCotizacion.MouseLeave, _
                               biVincularCotizacion.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Oportunidad de Negocio actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Oportunidad de Negocio."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Oportunidad de Negocio actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Oportunidad de Negocio actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Etapas de Oportunidad de Negocio actual."
    End Sub
    Private Sub ActualizarEtapa_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarEtapa.MouseEnter, miActualizarEtapa.MouseEnter
        sslError.Text = "Actualizar Etapa de Oportunidad de Negocio actual."
    End Sub
    Private Sub ActualizarVendedor_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarVendedor.MouseEnter, miActualizarVendedor.MouseEnter
        sslError.Text = "Actualizar Vendedor de Oportunidad de Negocio actual."
    End Sub
    Private Sub MostrarCotizaciones_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrarCotizaciones.MouseEnter, miMostrarCotizaciones.MouseEnter
        sslError.Text = "Mostrar Cotizaciones de Oportunidad de Negocio actual."
    End Sub
    Private Sub VincularCotizacion_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVincularCotizacion.MouseEnter, miVincularCotizacion.MouseEnter
        sslError.Text = "Vincular Cotizacion a Oportunidad de Negocio actual."
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOportunidadNegocio_Etapas
                frm.IdOportunidad = dgvDatos.CurrentRow.Cells("IdOportunidad").Value
                frm.Text = "Etapas de la Oportunidad de Negocio Nº " & dgvDatos.CurrentRow.Cells("IdOportunidad").Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarCotizaciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrarCotizaciones.Click, miMostrarCotizaciones.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOportunidadNegocio_Cotizaciones
                frm.IdOportunidad = dgvDatos.CurrentRow.Cells("IdOportunidad").Value
                frm.Text = "Mostrar Cotizaciones de la Oportunidad de Negocio Nº " & dgvDatos.CurrentRow.Cells("IdOportunidad").Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class