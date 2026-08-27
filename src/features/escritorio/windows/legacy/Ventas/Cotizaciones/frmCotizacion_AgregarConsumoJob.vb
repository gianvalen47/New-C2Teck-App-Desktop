Public Class frmCotizacion_AgregarConsumoJob
    Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Public IdCotizacion As Integer

    Private Sub frmCotizacion_AgregarConsumoJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionDetalleService) = False Then
                oCotizacionDetalleService.Close()
            End If
            If isClosed(oTransferenciaService) = False Then
                oTransferenciaService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarJob_Click(sender, e)
        End If
    End Sub

    Private Sub frmCotizacion_AgregarConsumoJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmCotizacion_AgregarConsumoJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_AgregarConsumoJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        txtNumJob.Select()
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oTransferenciaService.MostrarAtencionJob(Session.sCodEmp, txtNumJob.Text).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            If dtDatos.Rows.Count < 1 Then
                MsgBox("No existen datos, para esta OT")
                txtNumJob.Clear()
                txtNumJob.Focus()
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click

        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()
        End If

    End Sub

    Private Sub txtNumJob_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumJob.Validating
        If txtNumJob.Text <> "" Then
            listaDatos()
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Esta seguro de AGREGAR las mercaderias?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If dgvDatos.RowCount < 1 Then
                    MsgBox("La lista esta vacia,no puede ingresar los detalles", MsgBoxStyle.Exclamation)
                Else
                    Dim estado_process As Boolean
                    estado_process = oCotizacionDetalleService.IngresarConsumoJob(IdCotizacion, txtNumJob.Text, Session.sCodUsu)
                    If estado_process Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class