Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSolicitudesUsuario

    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtSolicitudes As DataTable
    Private dtEstados As DataTable
    Private dtTipoSolicitud As DataTable

    Private IdSolicitud As String
    Private IdSolicitudAct As String
    Private Estado As String
    Private IdPer As String
    Private IdPerUsu As Integer


    Private Sub frmSolicitudesUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudUsuarioService.Close()
        Catch ex As TimeoutException
            oSolicitudUsuarioService.Abort()
        Catch ex As CommunicationException
            oSolicitudUsuarioService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudesUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudesUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtanio.Value = Session.sFecha.Year
        ListarDatos()
        LlenarCombos()

    End Sub

    Private Sub LlenarCombos()

        '------------------------------- Estados --------------------------------------------
        dtEstados = oSolicitudUsuarioService.ListarEstados()
        dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
        cmbEstados.DataSource = dtEstados
        cmbEstados.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
        cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
        cmbEstados.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
        cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
        cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
        cmbEstados.SelectedIndex = 0
        dtEstados = Nothing

        '------------------------------- Solicitudes --------------------------------------------
        dtTipoSolicitud = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
        dtTipoSolicitud.Rows.InsertAt(getRowTodos(dtTipoSolicitud), 0)
        cmbTipSol1.DataSource = dtTipoSolicitud
        cmbTipSol1.DropDownList.DataMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbTipSol1.DropDownList.DisplayMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbTipSol1.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipo").ToString
        cmbTipSol1.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipo").ToString
        cmbTipSol1.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("Nombre").ToString
        cmbTipSol1.SelectedIndex = 0
        dtTipoSolicitud = Nothing

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

            If row.Cells("IdSolicitud").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub ListarDatos()

        IdPerUsu = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu).Persona.IdPer
        dtSolicitudes = oSolicitudUsuarioService.Filtrar(txtanio.Text, cmbTipSol1.Value, IdPer, utils.toNumber(txtSolicitud.Text), cmbEstados.Value).Tables(0)
        dgvSolicitudes.DataSource = dtSolicitudes

    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        'Dim datoAreas As String
        'datoAreas = ""
        Dim frm As New frmBuscarPersonal
        'frm.codigoArea = "09"
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            chkSolicitante.Checked = False
            txtPersonal.Text = frm.descripcion
            txtPersonal.BackColor = System.Drawing.SystemColors.Control
            IdPer = frm.codigo
        End If
        txtPersonal.Select()
        ListarDatos()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.TextChanged, txtPersonal.TextChanged, txtSolicitud.TextChanged, cmbEstados.ValueChanged, cmbTipSol1.ValueChanged
        ListarDatos()
    End Sub

    Private Sub chkSolicitante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSolicitante.CheckedChanged
        If txtPersonal.Text <> "(Todos)" Then
            chkSolicitante.Enabled = False
            txtPersonal.Text = "(Todos)"
            IdPer = 0
            ListarDatos()
        Else
            chkSolicitante.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim frm As New frmSolicitudesEstados

        frm.IdSolicitud = ""
        frm.Actualizar = False
        frm.IdPer = IdPer
        frm.Text = "Nueva Solicitud de Usuarios"
        Dim solicitante As New SeguridadService.Usuario
        solicitante = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        frm.Solicitante = solicitante.Persona.ApeNom
        frm.IdPer = solicitante.Persona.IdPer
        'frm.Solicitante = Session.sCodUsu

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'dtDatos = Nothing
            IdSolicitudAct = frm.IdSolicitud
            If frm.type_process = "update" Or frm.type_estado = "update" Then
                Datos0()
            End If
            ListarDatos()
            RowPossesion(dgvSolicitudes, frm.IdSolicitud)
            IdSolicitud = frm.IdSolicitud
            Mostrar()
        End If
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvSolicitudes.DoubleClick
        Mostrar()
    End Sub

    Private Sub Datos0()
        Dim EstadoAtencion As String

        EstadoAtencion = oSolicitudUsuarioService.ObtenerEstado(IdSolicitudAct)

        'txtanio.Text = Today.Year
        'cmbTipSol1.Value = 0
        'IdPer = 0
        'txtSolicitud.Text = ""
        'cmbEstados.Value = ""
        'cmbEstados.Value = EstadoAtencion
        If EstadoAtencion = "GN" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "VS" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "EJ" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "CA" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "TE" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "EN" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "DI" Then
            cmbEstados.Value = ""
        ElseIf EstadoAtencion = "DE" Then
            cmbEstados.Value = ""
        End If
        'cmbEstados.Value = ""

    End Sub

    Private Sub Mostrar()
        Try

            If dgvSolicitudes.RowCount > 0 Then
                Dim frm As New frmSolicitudesEstados
                frm.Text = "Solicitud de Usuarios - N° " & CStr(dgvSolicitudes.CurrentRow.Cells("IdSolicitud").Value)
                frm.IdSolicitud = CStr(dgvSolicitudes.CurrentRow.Cells("IdSolicitud").Value)
                frm.Actualizar = True
                frm.IdPerUsu = IdPerUsu
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtSolicitudes = Nothing
                    IdSolicitudAct = frm.IdSolicitud
                    If frm.type_process = "update" Or frm.type_estado = "update" Then
                        Datos0()
                    End If
                    ListarDatos()
                    RowPossesion(dgvSolicitudes, frm.IdSolicitud)
                    IdSolicitud = frm.IdSolicitud
                    Mostrar()
                End If
                dtSolicitudes = Nothing
                IdSolicitudAct = frm.IdSolicitud
                If frm.type_process = "update" Or frm.type_estado = "update" Then
                    Datos0()
                End If
                ListarDatos()
                RowPossesion(dgvSolicitudes, frm.IdSolicitud)
                IdSolicitud = frm.IdSolicitud
                'Mostrar()
            Else
                MsgBox("No existen datos, Verifique...")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        'Datos0()
        Dim IdSol As String = ""
        IdSol = dgvSolicitudes.CurrentRow.Cells("IdSolicitud").Value

        ListarDatos()
        RowPossesion(dgvSolicitudes, IdSol)

        'ListarDatos()
    End Sub

    Private Sub dgvSolicitudes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSolicitudes.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvSolicitudes.RowCount > 0 Then
               Mostrar()
            End If
        End If
    End Sub
End Class
