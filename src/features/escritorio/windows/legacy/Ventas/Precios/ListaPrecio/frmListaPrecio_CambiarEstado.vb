Imports System.ServiceModel

Public Class frmListaPrecio_CambiarEstado

    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private IdCliente As Integer
    Private dtDatos As New DataTable
    Private dtRubros As DataTable
    Private dtEstados As DataTable
    Private dtCorreos As DataTable
    Private IdLista As Integer
    Private estado_process As Boolean
    Public IdEstado As Integer
    Public DesEstado As String
    Public iCentroCosto As String
    Public IdPersonaSolicita As Integer

    Private Sub llenarCombos()

        Try
            '======================================= RUBROS ================================================
            dtRubros = oMaestroService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            ''======================================= ESTADOS ================================================
            'dtEstados = oPrecioService.MostrarEstadosListaPrecio.Tables(0)

            'dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            'cmbEstados.DataSource = dtEstados
            'cmbEstados.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstados.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            'cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            'cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            'cmbEstados.SelectedIndex = 0
            'dtRubros = Nothing


        Catch ex As Exception
            MsgBox("Error al llenar combos" + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub ListaCorreos()

        Try
            Dim usuario As New SeguridadService.Usuario
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            IdPersonaSolicita = usuario.Persona.IdPer

            Persona = oPersonaService.Obtener(IdPersonaSolicita)
            iCentroCosto = Persona.CentroCosto.CodCentro

            dtCorreos = oAsignacionJefesService.MostrarJefeArea(iCentroCosto).Tables(0)
            dgvCorreos.DataSource = dtCorreos

        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPrecioService.MostrarListaPrecio(Session.sCodEmp, cmbRubro.Value, txtCodMer.Text, utils.toNumber(IdEstado)).Tables(0)
            'MostrarListaPrecio
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbRubro.ValueChanged, txtCodMer.TextChanged
        listaDatos()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ENVIAR los precio lista seleccionados?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim rowsLista() As Janus.Windows.GridEX.GridEXRow

                    Dim Cadena As String = ""
                    Dim i As Integer = 0

                    rowsLista = dgvDatos.GetCheckedRows()
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

                        If rowsLista.Count <> 0 Then

                            Dim estado_process As Boolean
                            For Each row In rowsLista

                                IdLista = row.Cells("IdLista").Text

                                estado_process = oPrecioService.EnviarListaPrecio(IdLista, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                i = i + 1

                            Next

                        Else
                            MsgBox("Debe seleccionar algun precio lista")
                        End If
                    Else
                        MsgBox("Debe seleccionar alguno de los correos")
                    End If

                    If rowsLista.Count = i And rowsLista.Count <> 0 Then
                        MsgBox("Se envio los precio lista correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        '                        listaDatos()
                    End If
                End If
            Else
                MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error al enviar los precio lista: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = False
            txtObservacion.Focus()
        ElseIf cbAprobar.Checked And (IdEstado = 2 Or IdEstado = 3) Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = True
            btnAprobar.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = False
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = False
            txtObservacion.Focus()
        ElseIf cbAprobar.Checked And (IdEstado = 2 Or IdEstado = 3) Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = True
            btnAprobar.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = False
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Try
            Dim estado_process As Boolean
            '=====================================================APROBAR ===========================================
            If cbAprobar.Checked Then
                If MsgBox("¿Está seguro de APROBAR los precio lista seleccionados?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    '=========================================== APROBACION JEFE DE AREA ===================================
                    If IdEstado = 2 Or IdEstado = 3 Then

                        Dim rowsLista() As Janus.Windows.GridEX.GridEXRow

                        Dim Cadena As String = ""
                        Dim i As Integer = 0

                        rowsLista = dgvDatos.GetCheckedRows()

                        Dim row As Janus.Windows.GridEX.GridEXRow

                        If rowsLista.Count <> 0 Then

                            For Each row In rowsLista

                                IdLista = row.Cells("IdLista").Text
                                estado_process = oPrecioService.AprobarListaPrecio(IdLista, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                i = i + 1
                            Next

                        Else
                            MsgBox("Debe seleccionar algun precio lista")
                        End If

                        If rowsLista.Count = i And rowsLista.Count <> 0 Then
                            MsgBox("Se aprobó los precio lista correctamente.")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    End If
                End If

                '======================================================RECHAZAR ==========================================
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Está seguro de RECHAZAR los precio lista seleccionados?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la observación")
                        txtObservacion.Focus()
                    Else

                        Dim rowsLista() As Janus.Windows.GridEX.GridEXRow

                        Dim Cadena As String = ""
                        Dim i As Integer = 0

                        rowsLista = dgvDatos.GetCheckedRows()

                        Dim row As Janus.Windows.GridEX.GridEXRow

                        If rowsLista.Count <> 0 Then

                            For Each row In rowsLista

                                IdLista = row.Cells("IdLista").Text
                                estado_process = oPrecioService.RechazarListaPrecio(IdLista, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                i = i + 1

                            Next

                        Else
                            MsgBox("Debe seleccionar algun precio lista")
                        End If

                        If rowsLista.Count = i And rowsLista.Count <> 0 Then
                            MsgBox("Se rechazó los precio lista correctamente.")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al aprobar/rechazar los precio lista : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnVencer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVencer.Click

        Try
            Dim estado_process As Boolean

            If IdEstado = 4 Then
                If MsgBox("¿Está seguro de DAR DE BAJA los precio lista seleccionados?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim rowsLista() As Janus.Windows.GridEX.GridEXRow

                    Dim Cadena As String = ""
                    Dim i As Integer = 0

                    rowsLista = dgvDatos.GetCheckedRows()

                    Dim row As Janus.Windows.GridEX.GridEXRow

                    If rowsLista.Count <> 0 Then

                        For Each row In rowsLista

                            IdLista = row.Cells("IdLista").Text
                            estado_process = oPrecioService.VencimientoPrecioListaPrecio(IdLista, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            i = i + 1
                        Next

                    Else
                        MsgBox("Debe seleccionar algun precio lista")
                    End If


                    If rowsLista.Count = i And rowsLista.Count <> 0 Then
                        MsgBox("Se dio de baja los precio lista correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al dar de baja los precio lista : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmListaPrecio_CambiarEstado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPrecioService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oPrecioService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oPrecioService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecio_CambiarEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub frmListaPrecio_CambiarEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        llenarCombos()
        cmbEstados.Text = DesEstado
        listaDatos()

        If IdEstado = 1 Then
            Me.Size = New System.Drawing.Size(763, 541)
            gbCorreos.Visible = True
            lblObservacion.Visible = False
            txtObservacion.Visible = False
            btnAprobar.Visible = False
            btnVencer.Visible = False
            cbAprobar.Visible = False
            cbRechazar.Visible = False
            gbCorreos.Location = New System.Drawing.Point(12, 310)
            btnEnviar.Location = New System.Drawing.Point(295, 474)
            btnSalir.Location = New System.Drawing.Point(374, 474)
            ListaCorreos()
        ElseIf IdEstado = 2 Or IdEstado = 3 Then
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = False
            lblObservacion.Visible = True
            txtObservacion.Visible = True
            btnAprobar.Visible = True
            btnVencer.Visible = False
            cbAprobar.Visible = True
            cbRechazar.Visible = True
            btnEnviar.Visible = False
        ElseIf IdEstado = 4 Then
            Me.Size = New System.Drawing.Size(763, 489)
            gbCorreos.Visible = False
            lblObservacion.Visible = True
            txtObservacion.Visible = True
            btnAprobar.Visible = False
            cbAprobar.Visible = False
            cbRechazar.Visible = False
            btnEnviar.Visible = False
            btnVencer.Location = New System.Drawing.Point(268, 423)
        End If
    End Sub
End Class