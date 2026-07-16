Imports System.ServiceModel
Public Class frmPreMarcacion_Aprobar

    '===========================Servicios====================================================
    Private oPreMarcacionJobService As New PreMarcacionJobService.PreMarcacionJobServiceClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public IdPersona As Integer

    Private Sub frmPreMarcacion_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPreMarcacionJobService.Close()
        Catch ex As TimeoutException
            oPreMarcacionJobService.Abort()
        Catch ex As CommunicationException
            oPreMarcacionJobService.Abort()
        End Try
    End Sub

    Private Sub frmPreMarcacion_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_Atender_Masivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        listaDatos()
        enableOpciones()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPreMarcacionJobService.FiltrarEnviados(IdPersona, txtNumJob.Text).Tables(0)
            dgvDatos.DataSource = dtDatos

            cIdPreMarca.DataPropertyName = dtDatos.Columns("IdPreMarca").ColumnName
            cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
            cAbrPer2.DataPropertyName = dtDatos.Columns("AbrPer2").ColumnName
            cApeNom.DataPropertyName = dtDatos.Columns("ApeNom").ColumnName
            cCodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
            cFecha.DataPropertyName = dtDatos.Columns("Fecha").ColumnName
            cHoraIngreso.DataPropertyName = dtDatos.Columns("HoraIngreso").ColumnName
            cHoraSalida.DataPropertyName = dtDatos.Columns("HoraSalida").ColumnName
            cObservacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName
            cAprob.DataPropertyName = dtDatos.Columns("Aprobado").ColumnName
            cEnv.DataPropertyName = dtDatos.Columns("Enviado").ColumnName

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biAProbar.Enabled = False
        Else
            biImprimir.Enabled = True
            biAProbar.Enabled = True
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAProbar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAProbar.Click
        Try
            If MsgBox("¿Está seguro de APROBAR la(s) Pre Marcación(es) Seleccionada(s)", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvDatos.Update()
                Dim dtTable As DataTable
                'Dim rows As DataRow
                Dim Cont As Integer = 0
                Dim cPreMarca As Integer

                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1

                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAprobar"), DataGridViewCheckBoxCell)

                    If toBoolean(cellSelecion.Value) = True Then
                        Cont = Cont + 1
                        cPreMarca = toNumber(row.Cells("cIdPreMarca").Value)
                        oPreMarcacionJobService.Aprobar(cPreMarca, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If
                Next
                If Cont < 1 Then
                    MsgBox("Debe seleccionar una de las Pre Marcaciones")
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    MsgBox("Se Aprobó la(s) Pre Marcación(es) correctamente")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al APROBAR la(s) Pre Marcación(es)")
        End Try
    End Sub

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells("cbAprobar").Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells("cbAprobar").Value = False
        Next
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtSolicitante.TextChanged, txtNumJob.TextChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitante.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                             biAProbar.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAProbar.MouseEnter
        sslError.Text = "Aprobar  Pre Marcacion(es) seleccionada(s)."
    End Sub
End Class