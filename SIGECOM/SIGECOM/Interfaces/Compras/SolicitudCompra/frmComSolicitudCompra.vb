Imports System.ServiceModel

Public Class frmComSolicitudCompra

    Private oMaestroService As New MaestroService.MaestroClient
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oSolicitudCompraDetService As New SolicitudCompraDetService.SolicitudCompraDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oJobService As New JobService.JobServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Public state_button As Boolean '-----------True = Modificar    False = Nuevo
    Private dtMoneda As DataTable
    Public IdSolicitud As Integer
    Private CodArea As String
    Private iCentroCosto As String     'Centro de Costo de solicitante
    Private IdPer As Integer
    Private dtDatos As DataTable
    Private IdEstado As Integer

    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer

    Private dtCorreos As DataTable
    Private dtRubros As DataTable    

    Private Sub frmComSolicitudCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oMaestroService.Close()
            oSolicitudCompraService.Close()
            oSolicitudCompraDetService.Close()
            oSeguridadService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSolicitudCompraService.Abort()
            oSolicitudCompraDetService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSolicitudCompraService.Abort()
            oSolicitudCompraDetService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        Catch ex As Exception
            GC.SuppressFinalize(Me)
        End Try
    End Sub

    Private Sub frmComSolicitudCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    'Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        If Len(Trim(txtCodJob.Text)) > 0 Then
    '            If Not (oJobService.Buscar(txtCodJob.Text)) Then
    '                MsgBox("Número de Job no existente, Verifique")
    '                txtCodJob.Text = ""
    '                txtCodJob.Focus()
    '            ElseIf oJobService.Estado(txtCodJob.Text) = 16 Then
    '                MsgBox("Número de Job Liquidado, Verifique")
    '                txtCodJob.Text = ""
    '                txtCodJob.Focus()
    '            Else
    '                'If txtCodJob.Enabled = True Then
    '                '    cmbRubro.Enabled = True
    '                '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '                '    cmbRubro.Focus()
    '                'End If
    '                'cmbRubro.Enabled = False
    '                'cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '                txtObservacion.Focus()
    '            End If
    '        Else
    '            txtObservacion.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Len(Trim(txtCodJob.Text)) > 0 Then
    '            If Not (oJobService.Buscar(txtCodJob.Text)) Then
    '                MsgBox("Número de Job no existente, Verifique")
    '                txtCodJob.Text = ""
    '                txtCodJob.Focus()
    '            ElseIf oJobService.Estado(txtCodJob.Text) = 16 Then
    '                MsgBox("Número de Job Liquidado, Verifique")
    '                txtCodJob.Text = ""
    '                txtCodJob.Focus()
    '            Else
    '                'If txtCodJob.Enabled = True Then
    '                '    cmbRubro.Enabled = True
    '                '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '                'End If
    '                txtObservacion.Focus()
    '            End If
    '        Else
    '            'cmbRubro.Enabled = False
    '            'cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '            txtObservacion.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmBuscarJob
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            If toNull(frm.cod_job) <> Nothing Then
    '                txtCodJob.Text = frm.cod_job
    '            Else
    '                txtCodJob.Text = ""
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub txtNumJob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodJob.TextChanged
    '    If txtCodJob.Text <> "" Then
    '        If txtCodJob.Enabled = True Then
    '            cmbRubro.Enabled = True
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '        Else
    '            cmbRubro.Enabled = False
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '        End If
    '    Else
    '        cmbRubro.Enabled = False
    '        cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '    End If
    'End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If CInt(row.Cells("IdSolicitudDet").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If biGuardar.Enabled = True Then
                e.Handled = True
                biGuardar_Click(sender, e)
            End If          
        ElseIf e.KeyCode = Keys.F12 Then
            If btnModificarObservacion.Enabled = True Then
                btnModificarObservacion_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmComSolicitudCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComSolicitudCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim estilo As New Estilo
            estilo.cargaEstiloGridExt(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            estilo.cargaEstiloGridExt(dgvCorreos)
            dgvCorreos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            llenarCombos()

            Dim usuario As New SeguridadService.Usuario
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)

            If state_button Then
                ObtenerRegistro()
                listaDatos()
                listaCorreos()
                Desactivar()
                If IdEstado = 1 Then
                    Me.Size = New System.Drawing.Size(765, 575)
                Else
                    Me.Size = New System.Drawing.Size(765, 450)
                End If
                Me.Text = "Solicitud de Compra N°: " & txtNumSol.Text
                gbEstado.Visible = True
            Else
                 ObtenerSolicitante()
                Me.Text = "Nueva Solicitud de Compra"
                Me.Size = New System.Drawing.Size(761, 233)
                gbEstado.Visible = False
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("Error al cargar el load : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try      
    End Sub

    Private Sub ObtenerSolicitante()
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPer = usuario.Persona.IdPer
        txtSolicitante.Text = usuario.Persona.ApeNom
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function



    Private Sub llenarCombos()
        Try

            ' ''========================================== RUBROS ===============================================
            'dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            'cmbRubro.DataSource = dtRubros
            'cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            'cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            'cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            'cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            'cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            'cmbRubro.SelectedIndex = 0
            'dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            If state_button Then
                biGuardar.Enabled = False
                biEditar.Enabled = IIf(IdEstado = 1, True, False)
                biDeshacer.Enabled = False
                biSalir.Enabled = True
                biEnviar.Enabled = IIf(IdEstado = 1, True, False)

                'Agregado importal excel
                biDescargarExcel.Enabled = IIf(IdEstado = 1, True, False)
                biImportarExcel.Enabled = IIf(IdEstado = 1, True, False)

                miNuevo.Enabled = IIf(IdEstado = 1, True, False)
                miModificar.Enabled = IIf(Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01", True, False)
                miVerCotizaciones.Enabled = True
                miEliminar.Enabled = IIf(IdEstado = 1, True, False)
                miAdjuntar.Enabled = IIf(IdEstado = 3 Or IdEstado = 7, True, False)
                miActualizar.Enabled = True
            Else
                biGuardar.Enabled = True
                biEditar.Enabled = False
                biDeshacer.Enabled = True
                biSalir.Enabled = False
                biEnviar.Enabled = False

                biDescargarExcel.Enabled = False
                biImportarExcel.Enabled = False

                miNuevo.Enabled = False
                miModificar.Enabled = False
                miVerCotizaciones.Enabled = False
                miEliminar.Enabled = False
                miActualizar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Error al habilitar las opciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            dtDatos = oSolicitudCompraDetService.Mostrar(IdSolicitud).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaCorreos()
        Try
            dtCorreos = oAsignacionJefesService.MostrarJefeArea(iCentroCosto).Tables(0)
            dgvCorreos.DataSource = dtCorreos

        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudCompraService.SolicitudCompra
            registro = oSolicitudCompraService.Obtener(IdSolicitud)

            txtNumSol.Text = registro.IdSolicitud
            cbFecha.Value = registro.Fecha
            IdPer = registro.PersonaSolicita.IdPer
            txtSolicitante.Text = registro.PersonaSolicita.ApeNom
            txtObservacion.Text = registro.Observacion
            IdEstado = registro.EstadoSolicitudCompra.IdEstado
            lblEstado.Text = registro.EstadoSolicitudCompra.DesEstado
            CodArea = registro.Area.CodArea            
            txtArea.Text = registro.Area.DesArea
            enableOpciones()

        Catch ex As Exception
            MsgBox("Error al Obtener Registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Activar()
        Try
            cbFecha.ReadOnly = False
            cbFecha.BackColor = System.Drawing.SystemColors.Window
            'txtCodJob.ReadOnly = True
            'txtCodJob.BackColor = System.Drawing.SystemColors.Control
            'btnBuscarJob.Enabled = False
            'cmbRubro.ReadOnly = False
            'cmbRubro.BackColor = System.Drawing.SystemColors.Window
            btnBuscarPersonaS.Enabled = True
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnModificarObservacion.Enabled = True
            biDescargarExcel.Enabled = False
            biImportarExcel.Enabled = False

            biGuardar.Enabled = True
            biEditar.Enabled = False
            biDeshacer.Enabled = True
        Catch ex As Exception
            MsgBox("Error al Activar los botones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        Try
            cbFecha.ReadOnly = True
            cbFecha.BackColor = System.Drawing.SystemColors.Control
            'txtCodJob.ReadOnly = True
            'txtCodJob.BackColor = System.Drawing.SystemColors.Control
            'btnBuscarJob.Enabled = False
            'cmbRubro.ReadOnly = True
            'cmbRubro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersonaS.Enabled = False
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            btnModificarObservacion.Enabled = False
     
            biGuardar.Enabled = False
            biEditar.Enabled = True
            biDeshacer.Enabled = False
        Catch ex As Exception
            MsgBox("Error al Desactivar los botones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudCompraService.SolicitudCompra)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudCompraService.Insertar(registro)
            If estado_process > 0 Then
                MsgBox("Se insertó el registro correctamente ", MsgBoxStyle.Information)
                IdSolicitud = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, Comunicarse con el Administrador del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error Insertar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudCompraService.SolicitudCompra)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudCompraService.Actualizar(registro)
            If estado_process Then
                MsgBox("Se modificó el registro correctamente ")
                ObtenerRegistro()
                Desactivar()
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("Error al modificar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cbFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha")
                cbFecha.Focus()
                Return False
            ElseIf toNumber(IdPer) = 0 Then
                MsgBox("Debe ingresar el solcitante")
                txtSolicitante.Focus()
                Return False
                'ElseIf toBlank(txtCodJob.Text) <> "" And cmbRubro.SelectedIndex = 0 Then
                '    MsgBox("Debe Ingresar el Rubro.", MsgBoxStyle.Information, "Información")
                '    cmbRubro.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar los campos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está Seguro de GUARDAR los Cambios?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim registro As New SolicitudCompraService.SolicitudCompra
                Dim personaSolicita As New SolicitudCompraService.Persona
                'Dim job As New SolicitudCompraService.Job
                Dim area As New SolicitudCompraService.Area
                Dim empresa As New SolicitudCompraService.Empresa

                registro.IdSolicitud = IdSolicitud
                registro.Fecha = cbFecha.Value
                personaSolicita.IdPer = toNumber(IdPer)
                registro.PersonaSolicita = personaSolicita
                'El Job pasara al detalle 19/04/13
                'job.CodJob = toNull(txtCodJob.Text)
                'registro.Job = job
                registro.Observacion = toNull(txtObservacion.Text)
                area.CodArea = toNull(CodArea)
                registro.Area = area
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al guardar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Try
            Activar()
        Catch ex As Exception
            MsgBox("Error al editar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        Try
            If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If state_button Then
                    ObtenerRegistro()
                    Desactivar()
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al deshacer los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Try
            Dim lLog As Boolean = True

            While lLog
                Dim frm As New frmComSolicitudCompra_AgregarDetalle
                frm.IdSolicitud = IdSolicitud
                'frm.CodArea = CodArea
                'frm.CodCentro = iCentroCosto
                'frm.CodJob = txtCodJob.Text
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdSolicitudDet)
                Else
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("Error al crear nuevo registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click

        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmComSolicitudCompra_AgregarDetalle
                frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
                frm.IdSolicitudDet = dgvDatos.CurrentRow.Cells("IdSolicitudDet").Text
                'frm.CodJob = txtCodJob.Text
                frm.Asignado = dgvDatos.CurrentRow.Cells("Procesado").Text
                frm.state_button = True

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                End If
            Else
                MsgBox("No existen datos que mostrar, Verifique")
            End If
          
        Catch ex As Exception
            MsgBox("Error al modificar el registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub miVerCotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miVerCotizaciones.Click
        Try
            Dim frm As New frmComSolicitudCompra_VerCotizacion

            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
            frm.IdSolicitudDet = dgvDatos.CurrentRow.Cells("IdSolicitudDet").Text
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.IdCotizacionDet = oSolicitudCompraDetService.ObtenerCotizacionAceptada(dgvDatos.CurrentRow.Cells("IdSolicitud").Text, dgvDatos.CurrentRow.Cells("IdSolicitudDet").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al ver las cotizaciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudCompraDetService.Borrar(dgvDatos.CurrentRow.Cells("IdSolicitudDet").Text, dgvDatos.CurrentRow.Cells("IdSolicitud").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se eliminó el registro correctamente")
                    miActualizar_Click(sender, e)
                Else
                    MsgBox("Error en el proceso, comunicarse con el administrador del sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el dato : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdSolicitudDet").Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAdjuntar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmComSolicitudCompra_AdjuntarCotizacionMasivo
                frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            Else
                MsgBox("No existen datos que mostrar, Verifique")
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmComSolicitudCompra_Observacion
        frm.txtOservacion.Text = txtObservacion.Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = frm.txtOservacion.Text
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        miModificar_Click(sender, e)
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            miModificar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            miModificar_Click(sender, e)
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  biGuardar.MouseLeave, biEditar.MouseLeave, biDeshacer.MouseLeave, _
                                  biSalir.MouseLeave, _
                                  miNuevo.MouseLeave, miModificar.MouseLeave, miEliminar.MouseLeave, _
                                  miVerCotizaciones.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Guardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Guardar los datos ."
    End Sub
    Private Sub Editar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar Solicitud de Compra."
    End Sub
    Private Sub Deshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer Cambios Realizados."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Salir de la ventana actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear nuevo detalle."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar los datos."
    End Sub

    Private Sub Modificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar el detalle seleccionado."
    End Sub

    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar el detalle seleccionado."
    End Sub

    Private Sub VerCotizaciones_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miVerCotizaciones.MouseEnter
        sslError.Text = "Ver cotizaciones del detalle."
    End Sub

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click
        Try

            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ENVIAR la solicitud de compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

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
                        '----------------------------------------Enviar los Correos Seleccionados----------------------------------------------------------------
                        Dim estado_process As Boolean
                        estado_process = oSolicitudCompraService.Enviar(IdSolicitud, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process Then
                            MsgBox("Se envió la solicitud de compra correctamente", MsgBoxStyle.Information)
                            ObtenerRegistro()
                            Me.Size = New System.Drawing.Size(719, 422)
                        Else
                            MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                        End If
                    Else
                        MsgBox("Debe seleccionar alguno de los correos")
                    End If

                End If

            Else
                MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error al Enviar la solicitud de compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtSolicitante_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitante.TextChanged
        If txtSolicitante.Text <> "" Then
            Dim persona As New PersonaService.Persona
            persona = oPersonaService.Obtener(IdPer)
            CodArea = persona.CentroCosto.Area.CodArea
            txtArea.Text = persona.CentroCosto.Area.DesArea
            iCentroCosto = persona.CentroCosto.CodCentro
        End If        
    End Sub

    Private Sub biDescargarExcel_Click(sender As Object, e As EventArgs) Handles biDescargarExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("OT", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("UnidadMedida", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("IdTipoGasto", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"", "", "0.00", "", "UND", "1", ""})
        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub biImportarExcel_Click(sender As Object, e As EventArgs) Handles biImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If

    End Sub

    Private Sub CargadoFinal()


        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            If dgvDatos.RowCount >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub InsertarMasivo()
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim registro As New SolicitudCompraDetService.SolicitudCompraDet
                    Dim solicitudcompra As New SolicitudCompraDetService.SolicitudCompra
                    Dim unidadmedida As New SolicitudCompraDetService.UnidadMedida
                    Dim Rubro As New SolicitudCompraDetService.RubroGasto
                    Dim job As New SolicitudCompraDetService.Job
                    Dim tipogasto As New SolicitudCompraDetService.TipoGasto

                    solicitudcompra.IdSolicitud = IdSolicitud
                    registro.SolicitudCompra = solicitudcompra
                    registro.IdSolicitudDet = 0
                    registro.CodMer = toNull(DataGridView1.Item(0, i).Value)
                    'job.CodJob = toNull(DataGridView1.Item(3, i).Value)
                    'job.CodJob = IIf(IsDBNull(DataGridView1.Item(3, i).Value), "", toNull(Trim(DataGridView1.Item(3, i).Value)))
                    job.CodJob = IIf(IsDBNull(DataGridView1.Item(3, i).Value), Nothing, (DataGridView1.Item(3, i).Value))
                    registro.Job = job
                    Rubro.CodRubro = 5
                    registro.RubroGasto = Rubro

                    tipogasto.IdTipoGasto = CInt(DataGridView1.Item(5, i).Value)
                    registro.TipoGasto = tipogasto

                    registro.DesMer = IIf(IsDBNull(DataGridView1.Item(1, i).Value), "", DataGridView1.Item(1, i).Value)
                    registro.CanMer = toDouble(DataGridView1.Item(2, i).Value)
                    unidadmedida.CodUniMed = IIf(IsDBNull(DataGridView1.Item(4, i).Value), "", (DataGridView1.Item(4, i).Value))
                    registro.UnidadMedida = unidadmedida
                    registro.Observacion = IIf(IsDBNull(DataGridView1.Item(6, i).Value), "", DataGridView1.Item(6, i).Value)
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    Insertar(registro)

                End If
            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub Insertar(ByVal registro As SolicitudCompraDetService.SolicitudCompraDet)

        Try
            Dim estado_process As Integer
            estado_process = oSolicitudCompraDetService.Insertar(registro)

            If estado_process > 0 Then

            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarPersonaS_Click(sender As Object, e As EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPer = frm.codigo
                    txtSolicitante.Text = frm.descripcion
                    'txtPersonaAutoriza.Focus()
                    txtObservacion.Focus()
                Else
                    IdPer = 0
                    txtSolicitante.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class