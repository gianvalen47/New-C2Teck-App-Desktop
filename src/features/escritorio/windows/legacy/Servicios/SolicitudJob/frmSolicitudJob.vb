Public Class frmSolicitudJob

    Private state_search As Boolean
    Private oSolicitudJobService As New SolicitudJobService.SolicitudJobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oUsuario As New SeguridadService.Usuario
    Private oJobService As New JobService.JobServiceClient

    Public pCodUsu As String
    Private IdCliente As Integer
    Private IdArea As String
    Private dtAreas As DataTable
    Private dtMeses As DataTable
    Private dtTipoSolicitud As DataTable
    Private dtEstado As DataTable
    Private dtDatos As DataTable
    Public Registro As String
    'Private Evaluar As Boolean

    Private Sub frmSolicitudJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oSolicitudJobService) = False Then
                oSolicitudJobService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oJobService) = False Then
                oJobService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmSolicitudJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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

    Public Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If CInt(row.Cells("IdSolicitud").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1

            End If
        Next

    End Sub

    Private Sub frmSolicitudJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 109)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_search = True
        llenarCombos()
        IdCliente = 0
        txtanio.Value = Today.Year
        state_search = True
        listaDatos()
        dgvDatos.Select()
        '    poCargarArea()
        cmbMes.Value = Today.Month
        If Session.CodPerfil = "01" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17" Or Session.CodPerfil = "24" Or Session.CodPerfil = "26" Then
            cmbCodArea.Enabled = True
            biRechazar.Visible = True
            ToolStripSeparator8.Visible = True
        Else
            cmbCodArea.Enabled = False
            biRechazar.Visible = False
            ToolStripSeparator8.Visible = False
        End If
    End Sub

    Private Sub poCargarArea()
        oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        cmbCodArea.Value = oUsuario.Persona.CentroCosto.Area.CodArea
    End Sub

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount = 0 Then

                biMostrar.Enabled = False
                biEnviar.Enabled = False
                biImprimir.Enabled = False
                biActualizar.Enabled = False
                biEliminar.Enabled = False
                biAnular.Enabled = False
                biRechazar.Enabled = False

                miMostrar.Enabled = False
                miEnviar.Enabled = False
                miImprimir.Enabled = False
                miActualizar.Enabled = False
                miEliminar.Enabled = False
                miAnular.Enabled = False
                miRechazar.Enabled = False
            Else
                Dim estado As String
                estado = dgvDatos.CurrentRow.Cells("DesEstado").Value

                biMostrar.Enabled = True
                biImprimir.Enabled = True
                biEnviar.Enabled = IIf(estado = "GENERADA", True, False)
                biEliminar.Enabled = IIf(estado = "GENERADA", True, False)
                biActualizar.Enabled = True
                biAnular.Enabled = True
                biRechazar.Enabled = True

                miMostrar.Enabled = True
                miImprimir.Enabled = True
                miEnviar.Enabled = IIf(estado = "GENERADA", True, False)
                miEliminar.Enabled = IIf(estado = "GENERADA", True, False)
                miActualizar.Enabled = True
                miAnular.Enabled = True
                miRechazar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing
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
            dtEstado = oSolicitudJobService.MostrarEstados.Tables(0)
            dtEstado.Rows.InsertAt(getRowTodos(dtEstado), 0)
            cmbEstado.DataSource = dtEstado
            cmbEstado.DropDownList.DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstado.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstado.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstado = Nothing

            '======================================= TIPO SOLICITUD ================================================
            dtTipoSolicitud = oJobService.MostrarTipo().Tables(0)
            dtTipoSolicitud.Rows.InsertAt(getRowTodos(dtTipoSolicitud), 0)
            cmbTipo.DataSource = dtTipoSolicitud
            cmbTipo.DropDownList.DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipoSolicitud.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipoSolicitud = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_search = True Then
                'Evaluar = False
                dtDatos = oSolicitudJobService.Filtrar(Session.sCodEmp, txtanio.Value, cmbMes.Value, cmbCodArea.Value, cmbTipo.Value, IdCliente, cmbEstado.Value, IIf(toBlank(txtNumero.Text) = "", 0, txtNumero.Text), txtNumJob.Text).Tables(0)
                dgvDatos.DataSource = dtDatos
                'Evaluar = True
                enableOpciones()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim frm As New frmSolicitudJob_Nuevo
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)

        frm.IdPer = usuario.Persona.IdPer
        frm.txtSolicitante.Text = usuario.Persona.ApeNom
        frm.CodArea = IIf(cmbCodArea.Value = "", usuario.Persona.CentroCosto.Area.CodArea, cmbCodArea.Value)
        frm.Area = usuario.Persona.CentroCosto.Area.DesArea
        frm.state_button = False
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            'RowPossesion(dgvDatos, frm.IdSolicitud)
            If CStr(frm.IdSolicitud) <> "" Then
                Registro = CStr(frm.IdSolicitud)
                ObtenerCotizacionNueva()
                listaDatos()
            End If
            RowPossesion(dgvDatos, frm.IdSolicitud)
        End If
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

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCodArea.ValueChanged, cmbEstado.ValueChanged, cmbMes.ValueChanged, cmbTipo.ValueChanged, txtanio.TextChanged, txtNumero.TextChanged, txtNumJob.TextChanged, txtBuscarCliente.TextChanged
        listaDatos()
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        ''======================================= TIPO SOLICITUD ================================================
        'dtTipoSolicitud = oSolicitudJobService.MostrarTipoSolicitud(cmbCodArea.Value).Tables(0)
        'dtTipoSolicitud.Rows.InsertAt(getRowTodos(dtTipoSolicitud), 0)
        'cmbTipo.DataSource = dtTipoSolicitud
        'cmbTipo.DropDownList.DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
        'cmbTipo.DropDownList.DisplayMember = dtTipoSolicitud.Columns("DesTipo").ToString
        'cmbTipo.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipo").ToString
        'cmbTipo.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipo").ToString
        'cmbTipo.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
        'cmbTipo.SelectedIndex = 0
        'dtTipoSolicitud = Nothing
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmSolicitudJob_Nuevo
               

                frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
                If IsDBNull(dgvDatos.CurrentRow.Cells("CodJob").Value) Then
                    frm.IdCodJob = ""
                Else
                    frm.IdCodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
                End If
                frm.state_button = True

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub ObtenerCotizacionNueva()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmSolicitudJob_Nuevo

                frm.IdSolicitud = Registro
                frm.state_button = True

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Registro = ""
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR la solicitud N° " & dgvDatos.CurrentRow.Cells("IdSolicitud").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudJobService.Borrar(dgvDatos.CurrentRow.Cells("IdSolicitud").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                If estado_process Then
                    MsgBox("Se eliminó la solicitud de OT correctamente")
                    listaDatos()
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            If MsgBox("¿Está seguro de ENVIAR la solicitud de OT N° " & dgvDatos.CurrentRow.Cells("IdSolicitud").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estadp_process As Boolean

                estadp_process = oSolicitudJobService.Enviar(dgvDatos.CurrentRow.Cells("IdSolicitud").Value, Session.sCodUsu, Session.sDirIp, Session.sCodUsu)
                If estadp_process Then
                    MsgBox("Se envió la Solicitud de OT correctamente")
                    biActualizar_Click(sender, e)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        biMostrar_Click(sender, e)
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
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

    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click
        Dim IdSolicitud As String = ""


        If ValidaCodigoSeleccionado() Then
            Try
                If oSolicitudJobService.Estado(dgvDatos.CurrentRow.Cells("IdSolicitud").Text.ToString) = 3 Then

                    MsgBox("Esta Solicitud de OT no se puede ANULAR ya que esta en estado ATENDIDO")

                ElseIf oSolicitudJobService.Estado(dgvDatos.CurrentRow.Cells("IdSolicitud").Text.ToString) = 4 Then

                    MsgBox("Esta Solicitud de OT no se puede ANULAR porque ya esta ANULADO")

                Else
                    If MsgBox("¿Está seguro de Anular la Solicitud de OT Nº " & dgvDatos.CurrentRow.Cells("IdSolicitud").Text & " ?", MsgBoxStyle.YesNo, "Anular") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean

                        estado_process = oSolicitudJobService.Anular(dgvDatos.CurrentRow.Cells("IdSolicitud").Text.ToString, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                        If estado_process = True Then
                            'dtDatos = Nothing
                            listaDatos()
                            'Actualizar()
                            MsgBox("Se Anuló la Solicitud de OT Actual correctamente. ", MsgBoxStyle.Information, "Anular")
                        Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical, "Anular")
                        End If
                    End If

                End If
            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation, "Anular")
            End Try
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
            ElseIf dgvDatos.CurrentRow.Cells("IdSolicitud").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            ''RowPossesion(dgvDatos, codigo)  Comentado por Mateu
        End If
    End Sub

    Private Sub miAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAnular.Click
        Dim IdSolicitud As String = ""


        If ValidaCodigoSeleccionado() Then
            Try
                If oSolicitudJobService.Estado(dgvDatos.CurrentRow.Cells("IdSolicitud").Text.ToString) = 3 Then

                    MsgBox("Esta Solicitud de OT no se puede ANULAR ya que esta en estado ATENDIDO")

                ElseIf oSolicitudJobService.Estado(dgvDatos.CurrentRow.Cells("IdSolicitud").Text.ToString) = 4 Then

                    MsgBox("Esta Solicitud de OT no se puede ANULAR porque ya esta ANULADO")

                Else
                    If MsgBox("¿Está seguro de ANULAR la Solicitud de OT Nº " & (dgvDatos.CurrentRow.Cells("IdSolicitud").Text) & " ?", MsgBoxStyle.YesNo, "Anular") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean

                        estado_process = oSolicitudJobService.Anular(dgvDatos.CurrentRow.Cells("IdSolicitud").Text.ToString, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                        If estado_process = True Then
                            'dtDatos = Nothing
                            listaDatos()
                            'Actualizar()
                            MsgBox("Se Anuló la Solicitud de OT Actual correctamente.", MsgBoxStyle.Information, "Anular")
                        Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical, "Anular")
                        End If
                    End If

                End If
            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation, "Anular")
            End Try
        End If
    End Sub

    Private Sub biRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.Click, miRechazar.Click
        Dim frm As New frmSolicitudJob_Rechazar

        If dgvDatos.CurrentRow.Cells("IdSolicitud").Value = 0 Then
            MsgBox("Selecccione un registro, tenga cuidado ...!!!")
        Else
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
        End If
    End Sub

    Private Sub biDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDuplicar.Click, miDuplicar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmSolicitudJob_Duplicar
                frm.NumSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    RowPossesion(dgvDatos, frm.NumSolicitud)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al DUPLICAR la Solicitud de OT : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class