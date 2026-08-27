Imports System.ServiceModel

Public Class frmResultadosEncuestaSis

    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    'Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient


    Private dtDatos As New DataTable
    Private dtSistemas As New DataTable
    Private dtEncuesta As New DataTable
    Private IdPer As Integer

    Private Sub frmResultadosEncuestaSis_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmResultadosEncuestaSis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmResultadosEncuestaSis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        listarDatos()
    End Sub

    Private Sub llenarCombos()
        Try
            '------------------------------- Aplicacion --------------------------------------------
            dtSistemas = oSeguridadService.MostrarSistemas.Tables(0)
            'dtSistemas.Rows.InsertAt(getRowTodos(dtSistemas), 0)
            cmbSistema.DataSource = dtSistemas
            cmbSistema.DropDownList.DataMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.DropDownList.DisplayMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.DropDownList.ValueMember = dtSistemas.Columns("IdSistema").ToString
            cmbSistema.DropDownList.Columns(0).DataMember = dtSistemas.Columns("IdSistema").ToString
            cmbSistema.DropDownList.Columns(1).DataMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.SelectedIndex = 0
            dtSistemas = Nothing

            ''------------------------------- Aplicacion --------------------------------------------
            'dtEncuesta = oEncuestaSistema.Filtrar(utils.toNumber(cmbSistema.Value)).Tables(0)
            ''dtEncuesta = oSeguridadService.MostrarSistemas.Tables(0)
            ''dtSistemas.Rows.InsertAt(getRowTodos(dtSistemas), 0)
            'cmbEncuesta.DataSource = dtSistemas
            'cmbEncuesta.DropDownList.DataMember = dtSistemas.Columns("NomSis").ToString
            'cmbEncuesta.DropDownList.DisplayMember = dtSistemas.Columns("NomSis").ToString
            'cmbEncuesta.DropDownList.ValueMember = dtSistemas.Columns("IdSistema").ToString
            'cmbEncuesta.DropDownList.Columns(0).DataMember = dtSistemas.Columns("IdSistema").ToString
            'cmbEncuesta.DropDownList.Columns(1).DataMember = dtSistemas.Columns("Objetivo").ToString
            ''cmbEncuesta.DropDownList.Columns(2).DataMember = dtSistemas.Columns("Objetivo").ToString
            'cmbEncuesta.SelectedIndex = 0
            'dtSistemas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub listarDatos()
        Try
            dtDatos = oEncuestaSistema.MostrarResultado(utils.toNumber(cmbSistema.Value), utils.toNumber(cmbEncuesta.Value), utils.toNumber(IdPer)).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()

    End Sub


    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        Dim frm As New frmBuscarPersonal
        'frm.codigoArea = "09"
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            chkPersonal.Checked = False
            txtPersonal.Text = frm.descripcion
            txtPersonal.BackColor = System.Drawing.SystemColors.Control
            IdPer = frm.codigo
        End If
        txtPersonal.Select()
        listarDatos()
    End Sub

    Private Sub chkPersonal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPersonal.CheckedChanged
        If txtPersonal.Text <> "(Todos)" Then
            chkPersonal.Enabled = False
            txtPersonal.Text = "(Todos)"
            IdPer = 0
            ListarDatos()
        Else
            chkPersonal.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Try
            Dim frm As New frmResultadosEncuestaSis_Nuevo
            'frm.state_button = False
            'frm.edicion = True
            'frm.editable = True
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'listaDatos()
                'If frm.type_process = "insert" Then
                '    RowPossesion(dgvDatos, frm.IdEncuesta)
                '    mostrar()
                '    Actualizar()
                'End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, cmbEncuesta.ValueChanged, cmbSistema.ValueChanged
        listarDatos()
    End Sub

    Private Sub cmbSistema_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSistema.ValueChanged
        Try

            dtEncuesta = oEncuestaSistema.Filtrar(utils.toNumber(cmbSistema.Value)).Tables(0)

            cmbEncuesta.DataSource = dtEncuesta
            cmbEncuesta.DropDownList.DataMember = dtEncuesta.Columns("Objetivo").ToString
            cmbEncuesta.DropDownList.DisplayMember = dtEncuesta.Columns("Objetivo").ToString
            cmbEncuesta.DropDownList.ValueMember = dtEncuesta.Columns("IdEncuesta").ToString
            cmbEncuesta.DropDownList.Columns(0).DataMember = dtEncuesta.Columns("IdEncuesta").ToString
            cmbEncuesta.DropDownList.Columns(1).DataMember = dtEncuesta.Columns("Objetivo").ToString
            'cmbEncuesta.DropDownList.Columns(2).DataMember = dtSistemas.Columns("Objetivo").ToString
            If dtEncuesta.Rows.Count = 0 Then
                cmbEncuesta.SelectedIndex = -1
            Else
                cmbEncuesta.SelectedIndex = 0
            End If
            dtEncuesta = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR EL COMBO ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class