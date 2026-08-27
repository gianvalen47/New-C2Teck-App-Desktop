Imports System.ServiceModel

Public Class frmMarcarOT

    '===========================Servicios====================================
    Private oMarcacionJobService As New MarcacionJobService.MarcacionJobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private usuario As New SeguridadService.Usuario
    '======================Declaración de Variables==============================
    Private dtDatos As DataTable
    Public IdPersona As Integer
    Public IdMarca As Integer
    Public ApeNom As String
    Public CodJob As String
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable
    Private CodJobSalir As String = ""

    Private Sub frmMarcarOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 330)
        '/*************************************************************************************/

        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        LlenarCombos()

        'Dim estilo As New Estilo
        'estilo.CargaEstiloGrid(dgvDatos)
        'dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        'dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        'dgvDatos.AutoGenerateColumns = False
        listaDatos()
        dgvDatos.Select()

        If oMarcacionJobService.BuscarPendiente(usuario.Persona.IdPer, Today()) Then
            CodJobSalir = oMarcacionJobService.ObtenerJobPendiente(usuario.Persona.IdPer, Today())
            lblEstado.Text = "Esta registrado su marcación en la OT " & CodJobSalir
            cmbCodArea.ReadOnly = True
            dgvDatos.ReadOnly = True
            btnSalirOT.Enabled = True
        Else
            lblEstado.Text = ""
            cmbCodArea.ReadOnly = False
            dgvDatos.ReadOnly = False
            btnSalirOT.Enabled = False
        End If



    End Sub

    Private Sub LlenarCombos()
        Try

            '======================================= AREAS ================================================
            If Session.CodPerfil = "17" Then
                dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            Else
                dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            End If

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
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message)
        End Try

    End Sub

    Private Sub frmMarcarOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionJobService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
            oIndicadoresServicioService.Close()
        Catch ex As TimeoutException
            oMarcacionJobService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oIndicadoresServicioService.Abort()
        Catch ex As CommunicationException
            oMarcacionJobService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oIndicadoresServicioService.Abort()
        End Try
    End Sub

    Private Sub frmMarcarOT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oMarcacionJobService.MostrarJobMarcables(usuario.Oficina.CodOfi, cmbCodArea.Value)
            dgvDatos.DataSource = dtDatos


            'sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
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

    Private Sub cmbCodArea_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodArea.ValueChanged
        listaDatos()

    End Sub

    Private Sub RegistrarMarcacion()
        Dim job As New MarcacionJobService.Job
        Dim persona As New MarcacionJobService.Persona
        Dim registro As New MarcacionJobService.MarcacionJob
        Dim resul As Boolean
        Try
            job.CodJob = CodJob
            registro.Job = job
            persona.IdPer = usuario.Persona.IdPer
            registro.Persona = persona
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            resul = oMarcacionJobService.MarcarAsistencia(registro)

            If resul Then

                MsgBox("Usted acaba de registrarse en la OT : " & CodJob, MsgBoxStyle.Information, "Marcación Exitosa")

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        Catch ex As Exception
            MsgBox("Error al registrar marcación : " & ex.Message)
        End Try

    End Sub

    Private Sub dgvDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellClick
        Try

            CodJob = dgvDatos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value


            Dim TieneProgramacion As Boolean = oIndicadoresServicioService.BuscarProgramacion(CodJob)

            If TieneProgramacion = True Then
                'BuscarProgramacion()
                MsgBox("programacion")
            Else
                RegistrarMarcacion()
            End If



        Catch ex As Exception
            MsgBox("Error al registrar marcación, seleccione una OT valido")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub SalirOT()

        Try
            'usuario = oSeguridad.MostrarUsuarioPorCodigo(MiSesion.Current.CodUsu)

            'Dim CodJob As String = oMarcacionJobService.ObtenerJobPendiente(usuario.Persona.IdPer, Today())

            Dim job As New MarcacionJobService.Job
            Dim persona As New MarcacionJobService.Persona
            Dim registro As New MarcacionJobService.MarcacionJob
            job.CodJob = CodJobSalir
            registro.Job = job
            persona.IdPer = usuario.Persona.IdPer
            registro.Persona = persona
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If oMarcacionJobService.MarcarAsistencia(registro) Then
                MsgBox("Ud se acaba de retirar de la OT : " & CodJobSalir, MsgBoxStyle.Information, "Salida Exitosa")
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Salir")
        End Try


    End Sub

    Private Sub btnSalirOT_Click(sender As Object, e As EventArgs) Handles btnSalirOT.Click
        SalirOT()

    End Sub
End Class