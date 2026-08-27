Public Class frmMaximoMinimo_Recalcular

    Private oLocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Public IdLocacion As Integer
    Public CodRubro As String
    Private dtDatos As DataTable

    Private Sub MaximoMinimo_Recalcular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub MaximoMinimo_Recalcular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        listaDatos()
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oLocacionMercaderia.MostrarMercaderiaMinMax(Session.sCodEmp, IdLocacion, CodRubro).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biProcesarMinMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesarMinMax.Click
        Try
            If MsgBox("¿Está Seguro de Modificar los Máximos y Mínimos del Almacén : " + lblLocacion.Text + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                oLocacionMercaderia.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                estado_process = oLocacionMercaderia.ActualizarMinMax(Session.sCodEmp, IdLocacion, CodRubro, txtObservación.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se realizó el proceso correctamente", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else
                    MsgBox("Error en el Proceso, Comunicarse con el Administrador del Sistema", MsgBoxStyle.Critical)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

  
    Private Sub biBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biBuscar.Click, miBuscar.Click
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows

                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then

                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1

                        Exit For
                    End If

                Next
                'RowPossesion(dgvDatos, dtDatos, "CodMer", frm.codigoDetalle)
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class