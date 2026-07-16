
Imports System.ServiceModel

Public Class frmSolicitudesEstados

    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient

    Private dtTipoSolicitud As DataTable
    Private dtAplicacion As DataTable
    Private dtPrioridad As DataTable
    Private dtMedio As DataTable
    Private dtEstados As DataTable
    Private dtMotivo As DataTable
    Private EstCancelar As Boolean
    Private Solicitud As String

    Public Actualizar As String
    Public type_process As String
    Public type_estado As String
    Private EstadoAtencion As String
    Public IdSolicitud As String
    Public IdPer As Integer
    Public Solicitante As String
    Public IdPerUsu As Integer
    Private Guardar As Boolean

    Private Sub frmSolicitudesEstados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudUsuarioService.Close()
        Catch ex As TimeoutException
            oSolicitudUsuarioService.Abort()
        Catch ex As CommunicationException
            oSolicitudUsuarioService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudesEstados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudesEstados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        LlenarComboMotivo()

        If Actualizar = True Then

            EstadoAtencion = oSolicitudUsuarioService.ObtenerEstado(IdSolicitud)

            ObtenerRegistro()
            Desactivar()
            enableOption()

            If EstadoAtencion = "GN" Then
                biEditar.Enabled = True
                biAtencion.Enabled = False
            Else
                biEditar.Enabled = False
                biAtencion.Enabled = True
            End If
            If EstadoAtencion = "VS" Or EstadoAtencion = "EJ" Then
                biCancelar.Enabled = True
            End If

        Else
            Desactivar()
            Limpiar()
            enableOption()
        End If

    End Sub

    Private Sub enableOption()
        If Actualizar = True Then
            biGuardar.Enabled = False
            biEditar.Enabled = True
            biAtencion.Enabled = True
        Else
            biGuardar.Enabled = True
            biEditar.Enabled = False
            biAtencion.Enabled = False
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Dim registro As SolicitudUsuarioService.Solicitud

        registro = oSolicitudUsuarioService.Obtener(IdSolicitud)

        txtNumero.Text = registro.IdSolicitud
        txtFecha.Text = registro.Fecha
        cmbTipSol.Value = registro.TipoTrabajo.IdTipo
        LlenarComboMotivo()

        If registro.MotivoProblema.IdMotivo = 0 Then
            '    If registro.MotivoProblema.IdMotivo = 0 Or registro.MotivoProblema.IdMotivo Is Nothing Then
            cmbMotivo.SelectedIndex = 0
        Else
            cmbMotivo.Value = registro.MotivoProblema.IdMotivo
        End If
        cmbAplicacion.Value = registro.Aplicacion
        cmbPrioridad.Value = registro.Prioridad.Descripcion
        cmbMedio.Value = registro.Medio
        cmbMotivo.Value = registro.MotivoProblema.IdMotivo

        txtDescripcion.Text = registro.Motivo
        txtSolicitante.Text = registro.Persona.ApeNom
        IdPer = registro.Persona.IdPer

        dtEstados = oSolicitudUsuarioService.MostrarEstados(IdSolicitud, 0).Tables(0)
        dgvEstados.DataSource = dtEstados

    End Sub

    Private Sub llenarCombos()
        '------------------------------- Solicitudes --------------------------------------------
        dtTipoSolicitud = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
        dtTipoSolicitud.Rows.InsertAt(getRowTodos(dtTipoSolicitud), 0)
        cmbTipSol.DataSource = dtTipoSolicitud
        cmbTipSol.DropDownList.DataMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbTipSol.DropDownList.DisplayMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbTipSol.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipo").ToString
        cmbTipSol.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipo").ToString
        cmbTipSol.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbTipSol.SelectedIndex = 0
        dtTipoSolicitud = Nothing

        '------------------------------- Aplicacion ---------------------------------------------
        dtAplicacion = oSolicitudUsuarioService.MostrarAplicacion()
        cmbAplicacion.DataSource = dtAplicacion
        cmbAplicacion.DropDownList.DataMember = dtAplicacion.Columns("Descripcion").ToString
        cmbAplicacion.DropDownList.DisplayMember = dtAplicacion.Columns("Descripcion").ToString
        cmbAplicacion.DropDownList.ValueMember = dtAplicacion.Columns("Descripcion").ToString
        cmbAplicacion.DropDownList.Columns(0).DataMember = dtAplicacion.Columns("Descripcion").ToString
        'cmbAplicacion.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbAplicacion.SelectedIndex = 0
        dtAplicacion = Nothing

        '------------------------------- Prioridad --------------------------------------------
        dtPrioridad = oSolicitudUsuarioService.MostrarPrioridad().Tables(0)
        cmbPrioridad.DataSource = dtPrioridad
        cmbPrioridad.DropDownList.DataMember = dtPrioridad.Columns("Descripcion").ToString
        cmbPrioridad.DropDownList.DisplayMember = dtPrioridad.Columns("Descripcion").ToString
        cmbPrioridad.DropDownList.ValueMember = dtPrioridad.Columns("CodPrioridad").ToString
        cmbPrioridad.DropDownList.Columns(0).DataMember = dtPrioridad.Columns("CodPrioridad").ToString
        cmbPrioridad.DropDownList.Columns(1).DataMember = dtPrioridad.Columns("Descripcion").ToString
        cmbPrioridad.SelectedIndex = 0
        dtPrioridad = Nothing

        '------------------------------- Medio --------------------------------------------
        dtMedio = oSolicitudUsuarioService.MostrarMedio()
        cmbMedio.DataSource = dtMedio
        cmbMedio.DropDownList.DataMember = dtMedio.Columns("Descripcion").ToString
        cmbMedio.DropDownList.DisplayMember = dtMedio.Columns("Descripcion").ToString
        cmbMedio.DropDownList.ValueMember = dtMedio.Columns("Descripcion").ToString
        cmbMedio.DropDownList.Columns(0).DataMember = dtMedio.Columns("Descripcion").ToString
        cmbTipSol.SelectedIndex = 0
        dtMedio = Nothing

    End Sub

    Private Sub LlenarComboMotivo()

        ''------------------------------- Motivo -------------------------------------------------
        'dtMotivo = oSolicitudUsuarioService.MostrarMotivoProblema(cmbTipSol.Value).Tables(0)
        'dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
        'cmbMotivo.DataSource = dtMotivo
        'cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("Nombre").ToString
        'cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("Nombre").ToString
        'cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdMotivo").ToString
        'cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdMotivo").ToString
        'cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("Nombre").ToString
        'cmbMotivo.SelectedIndex = 0
        'dtMotivo = Nothing

        Try
            '======================================= Motivo =============================================
            If cmbTipSol.SelectedIndex <> 0 Then
                dtMotivo = oSolicitudUsuarioService.MostrarMotivoProblema(cmbTipSol.Value).Tables(0)
                dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
                cmbMotivo.DataSource = dtMotivo
                cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("Nombre").ToString
                cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("Nombre").ToString
                cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdMotivo").ToString
                cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdMotivo").ToString
                cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("Nombre").ToString
                cmbMotivo.SelectedIndex = 0
                dtMotivo = Nothing
            Else
                dtMotivo = oSolicitudUsuarioService.MostrarMotivoProblema(cmbTipSol.Value).Tables(0)
                dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
                cmbMotivo.DataSource = dtMotivo
                cmbMotivo.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO MOTIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub Limpiar()
        txtNumero.Text = ""
        txtFecha.Text = Session.sFecha.Date
        cmbTipSol.Text = ""
        cmbPrioridad.Text = ""
        cmbAplicacion.Text = ""
        cmbPrioridad.Text = ""
        cmbMedio.Text = ""
        txtSolicitante.Text = Solicitante

        txtDescripcion.Text = ""
        dgvEstados.DataSource = Nothing
    End Sub

    Private Sub Activar()
        txtNumero.ReadOnly = False
        txtNumero.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbTipSol.ReadOnly = False
        cmbTipSol.BackColor = System.Drawing.SystemColors.Window
        cmbAplicacion.ReadOnly = False
        cmbAplicacion.BackColor = System.Drawing.SystemColors.Window
        cmbPrioridad.ReadOnly = False
        cmbPrioridad.BackColor = System.Drawing.SystemColors.Window
        cmbMedio.ReadOnly = False
        cmbMedio.BackColor = System.Drawing.SystemColors.Window
        cmbMotivo.ReadOnly = False
        cmbMotivo.BackColor = System.Drawing.SystemColors.Window
        txtSolicitante.ReadOnly = False
        txtSolicitante.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub Desactivar()
        If Actualizar = True Then
            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbTipSol.ReadOnly = True
            cmbTipSol.BackColor = System.Drawing.SystemColors.Control
            cmbAplicacion.ReadOnly = True
            cmbAplicacion.BackColor = System.Drawing.SystemColors.Control
            cmbPrioridad.ReadOnly = True
            cmbPrioridad.BackColor = System.Drawing.SystemColors.Control
            cmbMotivo.ReadOnly = True
            cmbMotivo.BackColor = System.Drawing.SystemColors.Control
            cmbMedio.ReadOnly = True
            cmbMedio.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
            txtSolicitante.ReadOnly = True
            txtSolicitante.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        Else
            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtSolicitante.ReadOnly = True
            txtSolicitante.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe ingresar la Fecha")
                txtFecha.Select()
                Return False
            ElseIf utils.toBlank(cmbTipSol.SelectedIndex) = 0 Then
                MsgBox("Debe seleccionar el Tipo de Solicitud")
                cmbTipSol.Select()
                Return False
            ElseIf utils.toBlank(cmbMotivo.SelectedIndex) = 0 Or utils.toBlank(cmbMotivo.Text) = "" Then
                MsgBox("Debe seleccionar el Motivo Tipo Problema")
                cmbMotivo.Select()
                Return False
            ElseIf utils.toBlank(cmbAplicacion.Text) = "" Then
                MsgBox("Debe seleccionar la Aplicación")
                cmbAplicacion.Select()
                Return False
                'ElseIf utils.toBlank(cmbPrioridad.Text) = "" Then
                '    MsgBox("Debe seleccionar la Prioridad")
                '    cmbPrioridad.Select()
                '    Return False
            ElseIf utils.toBlank(cmbMedio.Text) = "" Then
                MsgBox("Debe seleccionar el Medio")
                cmbMedio.Select()
                Return False
            ElseIf utils.toBlank(txtSolicitante.Text) = "" Then
                MsgBox("Debe ingresar el Solicitante")
                txtSolicitante.Select()
                Return False
            ElseIf utils.toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la Descripción")
                txtDescripcion.Select()
                Return False
            ElseIf utils.toBlank(txtObsFinal.Text) = "" Then
                MsgBox("Debe Ingresar el Motivo")
                txtObsFinal.Focus()
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try

    End Function


    Protected Sub Insertar(ByVal registro As SolicitudUsuarioService.Solicitud)
        Try
            Dim estado_process As Integer

            estado_process = oSolicitudUsuarioService.Insertar(registro)
            type_process = "insert"
            If estado_process <> 0 Then
                IdSolicitud = estado_process
                'MsgBox("Se guardaron los datos correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el departamento de sistemas...")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Protected Sub Modificar(ByVal registro As SolicitudUsuarioService.Solicitud)
        Try
            Dim estado_process As Boolean

            estado_process = oSolicitudUsuarioService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                IdSolicitud = txtNumero.Text
                'MsgBox("Se modifico correctamente la Solicitud")
                biEditar.Enabled = False
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS " + ex.Message)
        End Try

    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        gbComentario.Visible = True
        txtObsFinal.Text = ""
        txtObsFinal.Focus()
        Guardar = True
    End Sub

    Private Sub biAtencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtencion.Click

        EstadoAtencion = oSolicitudUsuarioService.ObtenerEstado(IdSolicitud)

        If EstadoAtencion = "GN" Then
            MsgBox("La solicitud esta generada, no puede visualizar o proceder con la atencion, primero visualicela", MsgBoxStyle.Information)
        Else
            Dim frmAten As New frmSolicitudesAtencion
            frmAten.IdSolicitud = IdSolicitud

            If frmAten.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
                type_estado = "update"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub

    Private Sub dgvEstados_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvEstados.ColumnButtonClick
        Try
            If e.Column.Key = "Ver" Then

                Dim frm As New frmSolicitudesDetEstados
                frm.Estado = dgvEstados.CurrentRow.Cells("Estado").Value
                frm.Fecha = dgvEstados.CurrentRow.Cells("Fecha").Value
                frm.Hora = dgvEstados.CurrentRow.Cells("Hora").Value
                frm.Usuario = dgvEstados.CurrentRow.Cells("CodUsu").Value
                frm.Observacion = dgvEstados.CurrentRow.Cells("Observacion").Value

                If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Consultar Detalle" + ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Try
            EstadoAtencion = oSolicitudUsuarioService.ObtenerEstado(IdSolicitud)

            If EstadoAtencion = "GN" Then
                cmbTipSol.ReadOnly = False
                cmbTipSol.BackColor = System.Drawing.SystemColors.Window
                cmbPrioridad.ReadOnly = False
                cmbPrioridad.BackColor = System.Drawing.SystemColors.Window
                cmbMotivo.ReadOnly = False
                cmbMotivo.BackColor = System.Drawing.SystemColors.Window
                biGuardar.Enabled = True
                biEditar.Enabled = False
            Else
                MsgBox("La Solicitud no se puede modificar ...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Error al Editar" + ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click

        gbComentario.Visible = True
        txtObsFinal.Text = ""
        txtObsFinal.Focus()
        Guardar = False

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Guardar = True Then
                If MsgBox("¿Estás seguro de guardar los cambios?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                    Dim registro As New SolicitudUsuarioService.Solicitud
                    Dim tipotrabajo As New SolicitudUsuarioService.TipoTrabajo
                    Dim prioridad As New SolicitudUsuarioService.Prioridad
                    Dim persona As New SolicitudUsuarioService.Persona
                    Dim motivoproblema As New SolicitudUsuarioService.MotivoProblema
                    Dim usuario As New SolicitudUsuarioService.Persona


                    If Actualizar = True Then
                        registro.IdSolicitud = txtNumero.Text
                    End If

                    'registro.IdSolicitud = txtNumero.Text
                    registro.Aplicacion = cmbAplicacion.Value
                    registro.Medio = cmbMedio.Value

                    If EstadoAtencion = "GN" Then
                        registro.Estado = "VS"
                    ElseIf EstadoAtencion = "VS" Then
                        registro.Estado = "EJ"
                    ElseIf EstadoAtencion = "EJ" Then
                        registro.Estado = "TE"
                    ElseIf EstadoAtencion = "TE" Then
                        registro.Estado = "EN"
                    End If

                    persona.IdPer = IdPer
                    registro.Persona = persona
                    usuario.IdPer = IdPerUsu
                    registro.Usuario = usuario
                    tipotrabajo.IdTipo = cmbTipSol.Value
                    registro.TipoTrabajo = tipotrabajo
                    registro.Motivo = IIf(registro.Estado = "VS", txtObsFinal.Text, txtDescripcion.Text)
                    motivoproblema.IdMotivo = IIf(cmbMotivo.SelectedIndex = 0, Nothing, cmbMotivo.Value)
                    registro.MotivoProblema = motivoproblema
                    registro.ObsFinal = txtObsFinal.Text
                    registro.CodUsu = Session.sCodUsu
                    registro.Fecha = Today.Date
                    prioridad.CodPrioridad = cmbPrioridad.Value
                    registro.Prioridad = prioridad

                    If Actualizar = True Then
                        Modificar(registro)
                    ElseIf Actualizar = False Then
                        Insertar(registro)
                    End If

                    gbComentario.Visible = False
                    txtObsFinal.Text = ""
                End If
            Else
                CancelarSolicitud()
            End If
        Catch ex As Exception
            gbComentario.Visible = False
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub CancelarSolicitud()
        Try
            Dim estadofinal As String = ""
            If EstadoAtencion = "VS" Then
                estadofinal = "CA"
            ElseIf EstadoAtencion = "EJ" Then
                estadofinal = "CA"
            End If

            If MsgBox("¿Estás Seguro de Cancelar la Solicitud: " & IdSolicitud & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                EstCancelar = oSolicitudUsuarioService.CambiarEstado(IdSolicitud, txtObsFinal.Text, estadofinal, 0, "", Session.sCodUsu, Session.sDirIp)

                If EstCancelar Then
                    'MsgBox("Se Cancelo Satisfactoriamente la Solicitud : " & IdSolicitud & ".", MsgBoxStyle.Information)

                    gbComentario.Visible = False
                    ObtenerRegistro()
                    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If

        Catch ex As Exception
            gbComentario.Visible = False
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click

        Dim frm As New frmBuscarPersonal
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            txtSolicitante.Text = frm.descripcion
            txtSolicitante.BackColor = System.Drawing.SystemColors.Control
            IdPer = frm.codigo
        End If

    End Sub

    Private Sub cmbTipSol_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipSol.ValueChanged
        LlenarComboMotivo()
    End Sub
End Class
