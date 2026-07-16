Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSolicitudesAtencion

    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    Private ObjSeguridad As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Public IdSolicitud As String
    Private EstadoAtencion As String
    Private dtMenuOpcion As DataTable
    Private dtMenuOpcionAsignado As DataTable
    Private dtProblema As DataTable
    Private Personal As Boolean
    Public HabilitarPersonal As Boolean
    Private dtTable As DataTable
    Private dv As New DataView
    Dim row As DataRow
    Dim fila As DataRow
    Dim CodArea As String = "06"

    'Dim numero As String
    'Dim dato As String
    Dim col1 As String
    Dim col2 As String
    Dim col3 As String
    Dim col4 As String
    Dim dtPersonal As DataTable

    Private Sub frmSolicitudesAtencion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudUsuarioService.Close()
            ObjSeguridad.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            ObjSeguridad.Abort()
            oSolicitudUsuarioService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oSolicitudUsuarioService.Abort()
            ObjSeguridad.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudesAtencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmSolicitudesAtencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()

        EstadoAtencion = oSolicitudUsuarioService.ObtenerEstado(IdSolicitud)

        MostrarBotonEstado()
        MostrarGrillas()

        If EstadoAtencion = "EJ" Then
            Desactivar()
        Else
            Activar()
        End If

        If EstadoAtencion = "VS" Then
            dgvOpcionMenu.Enabled = True
            dgvOpcionMenuAsignado.Enabled = True
            btnAgregar.Enabled = True
            btnRegresar.Enabled = True
            btnAgregarTodos.Enabled = True
            btnRegresarTodos.Enabled = True
        Else
            dgvOpcionMenu.Enabled = False
            dgvOpcionMenuAsignado.Enabled = False
            btnAgregar.Enabled = False
            btnRegresar.Enabled = False
            btnAgregarTodos.Enabled = False
            btnRegresarTodos.Enabled = False
        End If

    End Sub

    Private Sub MostrarBotonEstado()
        If EstadoAtencion = "VS" Then
            btnOpciones.Visible = True
            btnOpciones.Text = "Ejecutar Atención"
        ElseIf EstadoAtencion = "EJ" Then
            btnOpciones.Visible = True
            btnOpciones.Text = "Terminar Atención"
        ElseIf EstadoAtencion = "TE" Then
            btnOpciones.Visible = True
            btnOpciones.Text = "Entregar Solución"
        ElseIf EstadoAtencion = "EN" Then
            btnOpciones.Visible = False
        ElseIf EstadoAtencion = "DI" Then
            btnOpciones.Visible = True
            btnOpciones.Text = "Descargar Disconformidad"
        End If
    End Sub

    Private Sub MostrarGrillas()
        If EstadoAtencion = "VS" Then

            dtMenuOpcionAsignado = oPersonaService.Filtrar(Session.sCodEmp, CodArea, "", "", "", True).Tables(0)
            dtMenuOpcionAsignado.Clear()

            'dtMenuOpcion = oMaestroService.FiltrarPersona(CodArea, "").Tables(0)
            'DataGridView1.DataSource = dtMenuOpcion

            dv = oPersonaService.Filtrar(Session.sCodEmp, CodArea, "", "", "", True).Tables(0).DefaultView
            dv.RowFilter = "CodCentro = 06 and Vigente = True"

            'DataGridView1.DataSource = dv
            'dv.ToTable("dtMenuOpcion")

            'dtTable = dtMenuOpcion.Copy
            'dtTable.Clear()

            'For i = 0 To dtMenuOpcion.Rows.Count - 1
            '    If dtMenuOpcion.Rows(i).Item(4) = True Then

            '        row = dtTable.NewRow
            '        row(0) = dtMenuOpcion.Rows(i).Item(0)
            '        row(1) = dtMenuOpcion.Rows(i).Item(1)
            '        row(2) = dtMenuOpcion.Rows(i).Item(2)
            '        row(3) = dtMenuOpcion.Rows(i).Item(3)
            '        'row(4) = dtMenuOpcion.Rows(i).Item(5)

            '        dtTable.Rows.Add(row)
            '    End If
            'Next

            'dgvOpcionMenu.DataSource = dtTable
            dgvOpcionMenu.DataSource = dv
            'dv.Table = dtTable
            'dv.RowFilter = "CodCentro = 06"
            'dgvOpcionMenu.DataSource = dv

            ocultarColumnas()
            cmbProblema.Value = 0
            cmbProblema.Text = ""

        Else
            ObtenerRegistro()
        End If
    End Sub

    Private Sub Activar()
        txtFechaInicio.ReadOnly = True
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = True
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
        txtHoraInicial.ReadOnly = True
        txtHoraInicial.BackColor = System.Drawing.SystemColors.Window
        txtHoraFinal.ReadOnly = True
        txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
        txtEstado.ReadOnly = True
        txtEstado.BackColor = System.Drawing.SystemColors.Window
        cmbProblema.ReadOnly = True
        cmbProblema.BackColor = System.Drawing.SystemColors.Window
        txtSolucion.ReadOnly = True
        txtSolucion.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub Desactivar()
        txtFechaInicio.ReadOnly = True
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Control
        txtFechaFinal.ReadOnly = True
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Control
        txtHoraInicial.ReadOnly = True
        txtHoraInicial.BackColor = System.Drawing.SystemColors.Control
        txtHoraFinal.ReadOnly = True
        txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
        txtEstado.ReadOnly = True
        txtEstado.BackColor = System.Drawing.SystemColors.Control
        cmbProblema.ReadOnly = False
        cmbProblema.BackColor = System.Drawing.SystemColors.Window
        txtSolucion.ReadOnly = False
        txtSolucion.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub ocultarColumnas()

        dgvOpcionMenu.Columns("Idper").Visible = False
        dgvOpcionMenu.Columns("ApeNom").Visible = True
        dgvOpcionMenu.Columns("CodArea").Visible = False
        dgvOpcionMenu.Columns("DesArea").Visible = False
        dgvOpcionMenu.Columns("Vigente").Visible = False
        dgvOpcionMenu.Columns("CodCentro").Visible = False

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registroAsig As SolicitudUsuarioService.Atencion

            registroAsig = oSolicitudUsuarioService.ObtenerAtencion(utils.toNumber(IdSolicitud))

            txtFechaInicio.Text = registroAsig.FecIni
            txtFechaFinal.Text = registroAsig.FecFin
            txtHoraInicial.Text = registroAsig.HorIni
            txtHoraFinal.Text = registroAsig.HorFin
            txtEstado.Text = registroAsig.Estado
            If EstadoAtencion = "EJ" Then
                cmbProblema.Text = ""
            Else
                cmbProblema.Value = registroAsig.TipoProblema.IdProblema
            End If
            txtSolucion.Text = registroAsig.Solucion


            dtPersonal = oSolicitudUsuarioService.MostrarPersonalAsignado(IdSolicitud).Tables(0)
            dgvPersonalEjecutor.DataSource = dtPersonal

        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        '------------------------------- MostrarTipoProblema --------------------------------------------

        Dim registroIdTipo As SolicitudUsuarioService.Solicitud
        Dim IdTipo As Integer

        registroIdTipo = oSolicitudUsuarioService.Obtener(utils.toNumber(IdSolicitud))

        IdTipo = registroIdTipo.TipoTrabajo.IdTipo

        dtProblema = oSolicitudUsuarioService.MostrarTipoProblema(IdTipo).Tables(0)
        cmbProblema.DataSource = dtProblema
        cmbProblema.DropDownList.DataMember = dtProblema.Columns("Nombre").ToString
        cmbProblema.DropDownList.DisplayMember = dtProblema.Columns("Nombre").ToString
        cmbProblema.DropDownList.ValueMember = dtProblema.Columns("IdProblema").ToString
        cmbProblema.DropDownList.Columns(0).DataMember = dtProblema.Columns("IdProblema").ToString
        cmbProblema.DropDownList.Columns(1).DataMember = dtProblema.Columns("Nombre").ToString
        cmbProblema.SelectedIndex = 0
        dtProblema = Nothing
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Personal As Integer
        Dim PersonalAsignado As Integer
        Dim estadoPersonal As String = ""

        Personal = dgvOpcionMenu.CurrentRow.Cells("IdPer").Value()

        For Each fila As DataRow In dtMenuOpcionAsignado.Rows
            PersonalAsignado = fila.Item("IdPer")

            If Personal = PersonalAsignado Then
                MsgBox("Este Personal ya esta como Seleccionado...")
                estadoPersonal = "R"
            End If

        Next

        If estadoPersonal = "R" Then
        Else
            Dim dr As DataRow
            dr = dtMenuOpcionAsignado.NewRow
            dgvOpcionMenuAsignado.DataSource = dtMenuOpcionAsignado
            col1 = dgvOpcionMenu.Rows(dgvOpcionMenu.CurrentRow.Index).Cells("IdPer").Value.ToString
            col2 = dgvOpcionMenu.Rows(dgvOpcionMenu.CurrentRow.Index).Cells("ApeNom").Value.ToString
            col3 = dgvOpcionMenu.Rows(dgvOpcionMenu.CurrentRow.Index).Cells("CodArea").Value.ToString
            col4 = dgvOpcionMenu.Rows(dgvOpcionMenu.CurrentRow.Index).Cells("DesArea").Value.ToString
            dr("IdPer") = col1
            dr("ApeNom") = col2
            dr("CodArea") = col3
            dr("DesArea") = col4
            dtMenuOpcionAsignado.Rows.Add(dr)
            ocultarColumnasAsignado()
            
        End If
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click

        dgvOpcionMenuAsignado.Rows.Remove(dgvOpcionMenuAsignado.CurrentRow)
        dtMenuOpcionAsignado = oPersonaService.Filtrar(Session.sCodEmp, CodArea, "", "", "", True).Tables(0)
        dtMenuOpcionAsignado.Clear()

    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click


        dtMenuOpcionAsignado = oPersonaService.Filtrar(Session.sCodEmp, CodArea, "", "", "", True).Tables(0)

        dtTable = dtMenuOpcionAsignado.Copy
        dtTable.Clear()

        For i = 0 To dtMenuOpcionAsignado.Rows.Count - 1
            If dtMenuOpcionAsignado.Rows(i).Item(4) = True Then

                row = dtTable.NewRow
                row(0) = dtMenuOpcionAsignado.Rows(i).Item(0)
                row(1) = dtMenuOpcionAsignado.Rows(i).Item(1)
                row(2) = dtMenuOpcionAsignado.Rows(i).Item(2)
                row(3) = dtMenuOpcionAsignado.Rows(i).Item(3)

                dtTable.Rows.Add(row)
            End If
        Next
        dgvOpcionMenuAsignado.DataSource = dtTable
        ocultarColumnasAsignado()
        cmbProblema.Value = 0
        cmbProblema.Text = ""

    End Sub

    Private Sub ocultarColumnasAsignado()
        dgvOpcionMenuAsignado.Columns("Idper").Visible = False
        'dgvOpcionMenuAsignado.Columns("ApeNom").Visible = false
        dgvOpcionMenuAsignado.Columns("CodArea").Visible = False
        dgvOpcionMenuAsignado.Columns("DesArea").Visible = False
        dgvOpcionMenuAsignado.Columns("Vigente").Visible = False
        dgvOpcionMenuAsignado.Columns("CodCentro").Visible = False
    End Sub

    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click

        gbComentario.Visible = True
        txtObsFinal.Text = ""
        txtObsFinal.Focus()

        If EstadoAtencion = "VS" Then
            If dgvOpcionMenuAsignado.Rows.Count <= 1 Then
                MsgBox("Debe seleccionar un Personal para esta Solicitud...", MsgBoxStyle.Information)
                gbComentario.Visible = False
            End If
        End If

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtObsFinal.Text) = "" Then
                MsgBox("Debe Ingresar el Motivo")
                txtObsFinal.Focus()
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try

    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de Modificar el estado de la Solicitud: " & IdSolicitud & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() = True Then
                Dim estado_process As Boolean
                Dim estadofinal As String = ""

                If EstadoAtencion = "VS" Then
                    'estadofinal = "EJ"
                    'For Each fila As DataRow In dtMenuOpcionAsignado.Rows
                    '    estado_process = oSolicitudUsuarioService.AsignarPersonal(IdSolicitud, fila.Item("IdPer"), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    'Next
                    For i = 0 To dgvOpcionMenuAsignado.Rows.Count - 2
                        estado_process = oSolicitudUsuarioService.AsignarPersonal(IdSolicitud, CInt(dgvOpcionMenuAsignado.Rows(i).Cells("IdPer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    Next
                End If

                If EstadoAtencion = "VS" Then
                    estadofinal = "EJ"
                ElseIf EstadoAtencion = "EJ" Then
                    estadofinal = "TE"
                ElseIf EstadoAtencion = "TE" Then
                    estadofinal = "EN"
                ElseIf EstadoAtencion = "DI" Then
                    estadofinal = "DE"
                End If

                Personal = oSolicitudUsuarioService.CambiarEstado(IdSolicitud, txtObsFinal.Text, estadofinal, utils.toNumber(cmbProblema.Value), txtSolucion.Text, Session.sCodUsu, Session.sDirIp)


                If Personal Then
                    'MsgBox("Se Modifico Satisfactoriamente el Estado de la Solicitud: " & IdSolicitud & ".", MsgBoxStyle.Information)
                    gbComentario.Visible = False
                    Me.DialogResult = Windows.Forms.DialogResult.OK

                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If

            End If

        Catch ex As Exception
            gbComentario.Visible = False
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i = 0 To dgvOpcionMenuAsignado.Rows.Count - 2
            dgvOpcionMenuAsignado.Rows.Remove(dgvOpcionMenuAsignado.CurrentRow)
        Next
        dtMenuOpcionAsignado.Clear()


    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub
End Class
