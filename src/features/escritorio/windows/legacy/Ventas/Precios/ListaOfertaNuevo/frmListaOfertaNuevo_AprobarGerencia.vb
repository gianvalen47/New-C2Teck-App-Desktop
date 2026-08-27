Imports System.ServiceModel

Public Class frmListaOfertaNuevo_AprobarGerencia

    '===========================Servicios====================================
    Private oListaOfertaCabService As New ListaOfertaCabService.ListaOfertaCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdOferta As Integer
    Public IdEstado As Integer
    Public tipoaprobacion As String = ""
    'Public MensajeCodigosPrecio As String
    'Private dtCorreos As DataTable

    Private dtDetallesPendientes As DataTable

    Private Sub frmListaOfertaNuevo_AprobarGerencia_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaOfertaCabService.Close()
        Catch ex As TimeoutException
            oListaOfertaCabService.Abort()
        Catch ex As CommunicationException
            oListaOfertaCabService.Abort()
        End Try
    End Sub

    Private Sub frmListaOfertaNuevo_AprobarGerencia_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaOfertaNuevo_AprobarGerencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Aprobar la Lista de oferta N°:" & IdOferta
        cbAprobar.Checked = True
        btnAprobar.Focus() '------- Agregado el 30/05/2012 -------
        Me.Size = New System.Drawing.Size(902, 479)
        ListarDetallesPendientes()
    End Sub

    Private Sub cbAprobar_CheckedChanged(sender As Object, e As EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Focus() '----Agregado el 30/05/2012----
            gbDetalle.Enabled = False
        ElseIf cbAprobar.Checked And IdEstado = 8 Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '----Agregado el 30/05/2012----
            gbDetalle.Enabled = True
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '----Agregado el 30/05/2012----
            gbDetalle.Enabled = True
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(sender As Object, e As EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Focus() '----Agregado el 30/05/2012----
            gbDetalle.Enabled = False
        ElseIf cbAprobar.Checked And IdEstado = 8 Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '----Agregado el 30/05/2012----
            gbDetalle.Enabled = True
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '----Agregado el 30/05/2012----
            gbDetalle.Enabled = True
        End If
    End Sub

    Private Sub ListarDetallesPendientes()
        Try

            dtDetallesPendientes = oListaOfertaCabService.MostrarPendientes(IdOferta).Tables(0)
            dgvPendientes.DataSource = dtDetallesPendientes

            lblRegistros.Text = "Registros : " + dgvPendientes.RowCount.ToString

        Catch ex As Exception
            MsgBox("Error al listar pendientes : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Try

            If cbAprobar.Checked Then

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                Dim Cadena As String = ""
                rows = dgvPendientes.GetCheckedRows()
                Dim row As Janus.Windows.GridEX.GridEXRow
                Dim dtDetalles As DataTable
                Dim rowDataN As DataRow

                If rows.Count <> 0 Then

                    If MsgBox("¿Está seguro de APROBAR la Lista de oferta N°: " & IdOferta & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                        Dim dtCopia As New DataTable("tabla")
                        dtCopia.Columns.Add(New DataColumn("IdOferta", Type.GetType("System.Int32")))
                        dtCopia.Columns.Add(New DataColumn("IdOfertaDet", Type.GetType("System.Int32")))
                        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("DesMer1", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("DesRub", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))
                        dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("DesEstado", Type.GetType("System.String")))
                        dtCopia.Columns.Add(New DataColumn("Costo", Type.GetType("System.Double")))
                        dtCopia.Columns.Add(New DataColumn("Procesar", Type.GetType("System.Boolean")))

                        dtCopia.Rows.Add(New Object() {"1", "1", "Nuevo", "Nuevo", "Nuevo", "Nuevo", "5.00", "Nuevo", "Nuevo", "Nuevo", "0.00", "true"})

                        dtDetalles = dtCopia.Copy
                        dtDetalles.Clear()

                        For Each row In rows

                            rowDataN = dtDetalles.NewRow
                            rowDataN(0) = Convert.ToInt32(row.Cells("IdOferta").Text)
                            rowDataN(1) = Convert.ToInt32(row.Cells("IdOfertaDet").Text)
                            rowDataN(2) = row.Cells("CodMer").Text
                            rowDataN(3) = row.Cells("DesMer1").Text
                            rowDataN(4) = row.Cells("CodRub").Text
                            rowDataN(5) = row.Cells("DesRub").Text
                            rowDataN(6) = row.Cells("Precio").Text
                            rowDataN(7) = row.Cells("Observacion").Text
                            rowDataN(8) = row.Cells("IdEstado").Text
                            rowDataN(9) = row.Cells("DesEstado").Text
                            rowDataN(10) = row.Cells("Costo").Text
                            rowDataN(11) = True

                            dtDetalles.Rows.Add(rowDataN)
                        Next

                        '=================================Enviar a Correos Seleccionados=================================
                        Dim estado_process As Boolean
                        estado_process = oListaOfertaCabService.AprobacionGerencia(IdOferta, dtDetalles, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process Then
                            MsgBox("Se aprobo la lista de ofertas correctamente", MsgBoxStyle.Information)
                            tipoaprobacion = "aprobar"
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                        End If
                    End If
                Else
                    MsgBox("Debe seleccionar alguno de los correos")
                End If
            Else
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la observación")
                    txtObservacion.Focus()
                Else
                    If MsgBox("¿Está seguro de RECHAZAR la Lista de oferta N°: " & IdOferta & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                        Dim estado_processrec As Boolean
                        estado_processrec = oListaOfertaCabService.Rechazar(IdOferta, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_processrec Then
                            MsgBox("Se rechazó la lista de oferta correctamente ")
                            tipoaprobacion = "rechazar"
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la lista de oferta : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class