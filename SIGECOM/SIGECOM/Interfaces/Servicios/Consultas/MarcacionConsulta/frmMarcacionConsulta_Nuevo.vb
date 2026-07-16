Imports System.ServiceModel
Public Class frmMarcacionConsulta_Nuevo

    Private oMarcacionJobService As New MarcacionJobService.MarcacionJobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oHorarioService As New HorarioService.HorarioServiceClient

    Public IdMarca As Integer
    Public Actualizar As Boolean

    Public IdPersona As Integer
    Private TipoCalculo As Integer
    'Private Oficinas As String
    Private dtDetalles As New DataTable
    'Private dtOficinas As New DataTable
    Private dtHorarios As DataTable

    Private Sub frmMarcacionConsulta_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionJobService.Close()
            oJobService.Close()
            oMaestroService.Close()
            oHorarioService.Close()
        Catch ex As TimeoutException
            oMarcacionJobService.Abort()
            oJobService.Abort()
            oMaestroService.Abort()
            oHorarioService.Abort()
        Catch ex As CommunicationException
            oMarcacionJobService.Abort()
            oJobService.Abort()
            oMaestroService.Abort()
            oHorarioService.Abort()
        End Try
    End Sub

    Private Sub frmMarcacionConsulta_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMarcacionConsulta_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarcombos()
        If Actualizar = True Then
            ObtenerRegistro()
            Desactivar()
            If Session.CodPerfil = "23" Then
                Me.Size = New System.Drawing.Size(765, 321)
                gbMarcacionesJob.Visible = False
                sslTotal.Visible = False
            Else
                Me.Size = New System.Drawing.Size(765, 542)
                gbMarcacionesJob.Visible = True
                sslTotal.Visible = True
            End If
        End If
        listaDatos()
    End Sub

    Private Sub llenarcombos()

        '================================= HORARIOS ===================================
        dtHorarios = oHorarioService.Mostrar(Session.sCodEmp).Tables(0)
        cmbHorario.DataSource = dtHorarios
        cmbHorario.DropDownList.DataMember = dtHorarios.Columns("DesHor").ToString
        cmbHorario.DropDownList.DisplayMember = dtHorarios.Columns("DesHor").ToString
        cmbHorario.DropDownList.ValueMember = dtHorarios.Columns("CodHor").ToString
        cmbHorario.DropDownList.Columns(0).DataMember = dtHorarios.Columns("CodHor").ToString
        cmbHorario.DropDownList.Columns(1).DataMember = dtHorarios.Columns("DesHor").ToString
        cmbHorario.SelectedIndex = 0
        dtHorarios = Nothing

    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub Desactivar()
        Try
            txtHoraIng.ReadOnly = True
            txtHoraIng.BackColor = System.Drawing.SystemColors.Control
            txtHoraSal.ReadOnly = True
            txtHoraSal.BackColor = System.Drawing.SystemColors.Control
            txtIngReal.ReadOnly = True
            txtIngReal.BackColor = System.Drawing.SystemColors.Control
            txtSalReal.ReadOnly = True
            txtSalReal.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            txtSolicitante.ReadOnly = True
            txtSolicitante.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = False
            btnBuscarJob.Enabled = False
            cmbHorario.ReadOnly = True
            cmbHorario.BackColor = System.Drawing.SystemColors.Control
            gbOpciones.Enabled = False
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            If IdMarca <> 0 Then
                Dim registro As New MarcacionJobService.MarcacionJob
                registro = oMarcacionJobService.Obtener(IdMarca)

                txtFecha.Value = registro.Fecha
                txtNumJob.Text = registro.Job.CodJob
                IdPersona = registro.Persona.IdPer
                txtSolicitante.Text = registro.Persona.ApeNom
                txtHoraIng.Text = registro.HorIngMarca
                txtIngReal.Text = registro.HorIngReal
                txtHoraSal.Text = registro.HorSalMarca
                txtSalReal.Text = registro.HorSalReal
                txtObservacion.Text = registro.Observacion
                cmbHorario.Value = registro.Horario.CodHor
                If registro.TipoCalculo = 1 Then
                    cbHorarioAsignado.Checked = True
                ElseIf registro.TipoCalculo = 2 Then
                    cbCalcularViaje.Checked = True
                ElseIf registro.TipoCalculo = 3 Then
                    cbCalcular100.Checked = True
                ElseIf registro.TipoCalculo = 4 Then
                    cbCalcularNormal.Checked = True
                ElseIf registro.TipoCalculo = 5 Then
                    cbCalcular35.Checked = True
                ElseIf registro.TipoCalculo = 6 Then
                    cbCalcular25.Checked = True
                End If
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al obtener registro : " + ex.Message)
        End Try

        'Try
        '    Dim registro As New MarcacionJobService.MarcacionJob
        '    registro = oMarcacionJobService.Obtener(IdMarca)

        '    txtFecha.Value = registro.Fecha
        '    txtNumJob.Text = registro.Job.CodJob
        '    IdPersona = registro.Persona.IdPer
        '    txtSolicitante.Text = registro.Persona.ApeNom
        '    txtHoraIng.Text = registro.HorIngMarca
        '    txtIngReal.Text = registro.HorIngReal
        '    txtHoraSal.Text = registro.HorSalMarca
        '    txtSalReal.Text = registro.HorSalReal
        '    txtObservacion.Text = registro.Observacion
        '    cmbOficinas.Value = registro.Oficina.CodOfi
        '    If registro.TipoCalculo = 1 Then
        '        cbCalcularOficinaJob.Checked = True
        '    ElseIf registro.TipoCalculo = 2 Then
        '        cbCalcularOficina.Checked = True
        '    ElseIf registro.TipoCalculo = 3 Then
        '        cbCalcular100.Checked = True
        '    End If

        'Catch ex As Exception
        '    MsgBox("Error al obtener registro : " + ex.Message)
        'End Try
    End Sub

    Private Sub TipoCalculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCalcular100.CheckedChanged, cbCalcularViaje.CheckedChanged,
                                                                                                                                                                              cbHorarioAsignado.CheckedChanged, cbCalcularNormal.CheckedChanged,
                                                                                                                                                                              cbCalcular25.CheckedChanged, cbCalcular35.CheckedChanged
        If cbHorarioAsignado.Checked Then
            TipoCalculo = 1
            lblHorario.Visible = True
            cmbHorario.Visible = True
        ElseIf cbCalcularViaje.Checked Then
            TipoCalculo = 2
            lblHorario.Visible = False
            cmbHorario.Visible = False
        ElseIf cbCalcular100.Checked Then
            TipoCalculo = 3
            lblHorario.Visible = False
            cmbHorario.Visible = False
        ElseIf cbCalcularNormal.Checked Then
            TipoCalculo = 4
            lblHorario.Visible = False
            cmbHorario.Visible = False
        ElseIf cbCalcular35.Checked Then
            TipoCalculo = 5
            lblHorario.Visible = False
            cmbHorario.Visible = False
        ElseIf cbCalcular25.Checked Then
            TipoCalculo = 6
            lblHorario.Visible = False
            cmbHorario.Visible = False
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Protected Sub listaDatos()
        Try
            dtDetalles = oJobService.ConsultarGastos(txtNumJob.Text, "1", Session.sCodUsu).Tables(0)
            dgvDatos.DataSource = dtDetalles
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES : " + ex.Message)
        End Try
    End Sub

End Class