Public Class frm_Ser_Cotizaciones
    Private state_search As Boolean
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficinas As DataTable
    Private dtSupervisor As DataTable
    Private dtVendedor As DataTable
    Private dtDatos As DataTable
    Private dtEstados As DataTable
    Private IdCliente As Integer
    Private iEstado As Integer
    'Private Evaluar As Boolean
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private Sub frm_Ser_Cotizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

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
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0
        Catch ex As Exception

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
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function
   
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If CInt(row.Cells("IdCotizacionSer").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1

            End If

        Next


    End Sub
    Private Sub frm_Ser_Cotizaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            dgvDatos.Select()
            dgvDatos.Row = dgvDatos.RowCount - 1
            dgvDatos.Col = 1
        End If

    End Sub

    Private Sub frmServicios_Cotizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 108)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_search = False
        llenarCombos()
        txtanio.Value = Today.Year
        state_search = True
        listaDatos()
        dgvDatos.Select()
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= SUPERVISOR ================================================
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos1(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            '========================================== VENDEDOR ================================================
            dtVendedor = oMaestroService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowTodos1(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("AbrPer").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("AbrPer").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("AbrPer").ToString
            cmbVendedor.SelectedIndex = 0

            '========================================== ESTADOS =================================================
            dtEstados = oCotizacionServicioService.MostrarEstados.Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos1(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.Columns(2).DataMember = dtAreas.Columns("DesUnidad").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
                dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString            
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

            If cmbCodArea.Value = "" Then
                lblUnidadNegocio.Text = ""
            Else
                lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try

            If dgvDatos.RowCount < 1 Then

                biMostrar.Enabled = False
                biActualizar.Enabled = False
                biEliminar.Enabled = False
                biAdjuntar.Enabled = False
                biDesvincular.Enabled = False
                biEstados.Enabled = False
                biEnviarCre.Enabled = False
                biImprimir.Enabled = False
                biDuplicar.Enabled = False
                biAnular.Enabled = False

                miMostrar.Enabled = False
                miActualizar.Enabled = False
                miEliminar.Enabled = False
                miAdjuntar.Enabled = False
                miDesvincular.Enabled = False
                miEstados.Enabled = False
                miEnviarCre.Enabled = False
                miImprimir.Enabled = False
                miDuplicar.Enabled = False
                miAnular.Enabled = False
            Else

                biMostrar.Enabled = True
                biActualizar.Enabled = True
                biEstados.Enabled = True
                biImprimir.Enabled = True
                biDuplicar.Enabled = True

                miMostrar.Enabled = True
                miActualizar.Enabled = True
                miEstados.Enabled = True
                miImprimir.Enabled = True
                miDuplicar.Enabled = True
                'Dim AbrEstado As String

                'AbrEstado = dgvDatos.CurrentRow.Cells("AbrEstado").Value
                If oCotizacionServicioService.Estado(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value) = 1 Then

                    biEnviarCre.Enabled = True
                    miEnviarCre.Enabled = True
                    biAdjuntar.Enabled = True
                    miAdjuntar.Enabled = True
                    If oCotizacionServicioService.BuscarRepuestos(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value) = True Then
                        biEliminar.Enabled = False
                        miEliminar.Enabled = False
                        'biAdjuntar.Enabled = False
                        'miAdjuntar.Enabled = False
                        biDesvincular.Enabled = True
                        miDesvincular.Enabled = True
                    Else
                        biEliminar.Enabled = True
                        miEliminar.Enabled = True
                        'biAdjuntar.Enabled = True
                        'miAdjuntar.Enabled = True
                        biDesvincular.Enabled = False
                        miDesvincular.Enabled = False
                    End If

                Else
                    biEliminar.Enabled = False
                    biAdjuntar.Enabled = False
                    biDesvincular.Enabled = False
                    biEnviarCre.Enabled = False

                    miEliminar.Enabled = False
                    miAdjuntar.Enabled = False
                    miDesvincular.Enabled = False
                    miEnviarCre.Enabled = False

                End If

                iEstado = oCotizacionServicioService.Estado(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value)

                biActualizarEstado.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "24"), True, False)
                biActualizarEstado.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "24") And (iEstado = 5 Or iEstado = 11), True, False)

                miActualizarEstado.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "24"), True, False)
                miActualizarEstado.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "24") And (iEstado = 5 Or iEstado = 11), True, False)

                miAnular.Enabled = IIf(iEstado = 1 Or iEstado = 6, False, True)
                biAnular.Enabled = IIf(iEstado = 1 Or iEstado = 6, False, True)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_search = True Then
                ' Evaluar = False
                dtDatos = oCotizacionServicioService.Filtrar(Session.sCodEmp, txtanio.Value, cmbOficinas.Value, IdCliente, cmbVendedor.Value, cmbEstado.Value, txtNumCot.Text, txtSerie.Text, txtNum_Orden.Text, txtDescripcion.Text, cmbSupervisor.Value, txtCodJob.Text, "", cmbCodArea.Value, cmbCentroCosto.Value).Tables(0)
                dgvDatos.DataSource = dtDatos
                'Evaluar = True
                enableOpciones()

            End If

        Catch ex As Exception
            MsgBox("Error al Cargar Datos" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtBuscarCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtBuscarCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtBuscarCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtBuscarCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            If dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value = Nothing Then
                MsgBox("Escoja una cotizacion", MsgBoxStyle.Exclamation)
            Else
                Dim frm As New frmServicios_CotizacionReportes
                frm.idCotizacionRep = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
                frm.idPer = dgvDatos.CurrentRow.Cells("IdPer").Value
                frm.idPerDelegado = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdPerDelegado").Value) = True, 0, dgvDatos.CurrentRow.Cells("IdPerDelegado").Value)
                frm.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            If cmbCentroCosto.Value = "" Then
                MsgBox("¡Selecccione un Centro de Costo...!")
            Else
                Dim frm As New frmServicios_Cotizacion
                frm.state_button = False
                frm.edicion = True
                frm.editable = True
                frm.iCodArea = cmbCodArea.Value
                frm.iCodCentro = cmbCentroCosto.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdCotizacionSer)
                        mostrar()
                        Actualizar()
                    End If
                    enableOpciones()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmServicios_Cotizacion
            Dim lEstado As String
            frm.state_button = True
            lEstado = dgvDatos.CurrentRow.Cells("DesEstado").Text
            frm.state_button = True
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
            frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
            frm.editable = IIf(lEstado = "Generado", True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumCot.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdCotizacionSer)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA COTIZACIÓN DE SERVICIOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtNumCot.Text = nro_Orden
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click

        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbEstado.ValueChanged, cmbOficinas.ValueChanged, cmbSupervisor.ValueChanged, cmbVendedor.ValueChanged, txtanio.TextChanged, txtBuscarCliente.TextChanged, txtDescripcion.TextChanged, txtNum_Orden.TextChanged, txtSerie.TextChanged, txtNumCot.TextChanged, txtCodJob.TextChanged, cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        biMostrar_Click(sender, e)
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR la cotización Nº " & dgvDatos.CurrentRow.Cells("NumCotizacion").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCotizacionServicioService.Borrar(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                If estado_process Then
                    MsgBox("La cotización fue eliminada correctamente.", MsgBoxStyle.Information)
                    listaDatos()
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            Dim frm As New frmServicios_Cotizacion_Estado
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
            frm.Text = "Estados de la Cotización Nº " & dgvDatos.CurrentRow.Cells("NumCotizacion").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAdjuntar.Click, miAdjuntar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmServicios_Cotizacion_Adjuntar
                frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
                frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Value
                frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
                frm.Text = "Adjuntar Cotización al Cliente : " & dgvDatos.CurrentRow.Cells("DesCli").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ADJUNTAR Cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEnviarCre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviarCre.Click, miEnviarCre.Click
        Try

            iEstado = oCotizacionServicioService.Estado(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value)
            Dim frm As New frmServicios_Cotizacion_Enviar
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
            frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
            frm.CodCentro = dgvDatos.CurrentRow.Cells("CodCentro").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox("Error al Enviar la Cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDesadjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDesvincular.Click, miDesvincular.Click
        Try
            Dim frm As New frmServicios_Cotizacion_Desvincular
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
            frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
            frm.Text = "Desvincular Cotización de Repuestos"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("La cotización fue desvinculada correctamente.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDuplicar.Click, miDuplicar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmServicios_Cotizacion_Duplicar
                frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
                frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdCotizacionSer)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al DUPLICAR Cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub



    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    If biMostrar.Enabled = True Then
                        biMostrar_Click(sender, e)
                        e.Handled = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
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

    Private Sub biActualizarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarEstado.Click, miActualizarEstado.Click

        Try
            Dim frm As New frmServicios_Cotizacion_ActualizarEstado

            frm.Text = "Actualizar a estado inicial"
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Text
            frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Text
            'frm.IdLocacion = cmbIdLocacion.Value
            'frm.IdCliente = dgvDatos.CurrentRow.Cells("IdClienteBenificiado").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        Try
            If oCotizacionServicioService.BuscarJob(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value)) Then
                MsgBox("¡La Cotización seleccionada está asignada a un OT, no se puede anular!", MsgBoxStyle.Information, "Información")
            Else
                Dim frm As New frmServicios_Cotizacion_Anular
                frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
                frm.IdCotizacionSer = toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarFecEmision_Click(sender As Object, e As EventArgs) Handles biActualizarFecEmision.Click, miActualizarFecEmision.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmServicios_Cotizacion_ActFecEmision
                'frm.IdProvisional = toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text)
                frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
                frm.NumCotizacion = dgvDatos.CurrentRow.Cells("NumCotizacion").Value
                frm.FechaEmision = dgvDatos.CurrentRow.Cells("Fecha").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                    enableOpciones()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la Fecha de Emision : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class