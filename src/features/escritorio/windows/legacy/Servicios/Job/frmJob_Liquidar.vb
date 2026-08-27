Imports System.ServiceModel
Public Class frmJob_Liquidar

    Public CodJob As String
    Private oJobService As New JobService.JobServiceClient
    Private oJobDetalleService As New JobDetalleService.JobDetalleServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtMonedas As DataTable

    Private dtDatos As DataTable
    Private dtCotizacion As DataTable

    Private Sub frmJob_Liquidar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmJob_Liquidar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oJobService.Close()
            oJobDetalleService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oJobDetalleService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oJobDetalleService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Liquidar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim estilo As New Estilo
            Estilo.CargaEstiloGrid(dgvDatos)
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

            estilo.CargaEstiloGrid(dgvcotizaciones)
            dgvcotizaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

            llenarCombos()
            ListaDatos()
            dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
            'If Session.sCodUsu = "ccueto" Then
            GrupoLiquidacion.Visible = True
            cbParcial.Visible = True
            'End If
            ValidarTipoJob()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR EL LOAD : " + ex.Message)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR EL COMBO : " + ex.Message)
        End Try
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oJobDetalleService.MostrarParaLiquidar(CodJob).Tables(0)
            dgvDatos.DataSource = dtDatos

            dtCotizacion = oJobDetalleService.MostrarCostosCotizacionAsignadas(CodJob).Tables(0)
            dgvcotizaciones.DataSource = dtCotizacion


            Dim registro As New JobService.Job
            registro = oJobService.Obtener(CodJob)

            cmbCodMon.Value = registro.Moneda.CodMon

            'txtMontoVenta.Value = registro.TotVentaCot
            'txtMontoCosto.Value = registro.TotBrutoCosto

            SumarMontoVenta()
            SumarDescuento()
            SumarMontoCosto()
            SumarCotizacion()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidar.Click
        Dim registro As New JobService.Job
        registro = oJobService.Obtener(CodJob)

        If MsgBox("Está seguro de LIQUIDAR la OT N° " & CodJob & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If (registro.TotBrutoCot) = 0 And (registro.TipoJob.IdTipoJob = 2 Or registro.TipoJob.IdTipoJob = 3) Then
                MsgBox("¡La OT no presenta montos cotizados, No se puede liquidar...!")
            Else
                Liquidar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Liquidar()
        Try
            Dim state_process As Boolean
            dtDatos = dgvDatos.DataSource
            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            state_process = oJobService.Liquidar(CodJob, dtDatos, cbParcial.Checked, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If state_process = True Then
                MsgBox("Se liquidó la OT correctamente")
            Else
                MsgBox("¡Error en el proceso, comunicarse con el departamento de TI...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LIQUIDAR LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub ValidarTipoJob()
        Dim registro As JobService.Job
        registro = oJobService.Obtener(CodJob)
        If registro.TipoJob.IdTipoJob = 2 Or registro.TipoJob.IdTipoJob = 3 Then
            cbParcial.Enabled = True
        Else
            cbParcial.Enabled = False
        End If
    End Sub

    Private Sub cbParcial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbParcial.CheckedChanged
        If cbParcial.Checked Then
            dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.TextBox
            dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.TextBox
        Else
            dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
            dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
            ListaDatos()
        End If
    End Sub

    Private Sub SumarMontoVenta()
        Try
            Dim totalVenta As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelectedVenta As Boolean
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelectedVenta = row.Cells("TotalVenta").Value
                If bSelectedVenta Then
                    totalVenta = totalVenta + CDbl(Me.dgvDatos.CurrentRow.Cells("TotalVenta").Value)
                End If
            Next
            'txtMontoVenta.Value = totalVenta - SumarDescuento()

            txtMontoVenta.Value = totalVenta

        Catch ex As Exception
            MsgBox("Error al sumar Monto Venta" + ex.Message)
        End Try
    End Sub

    Private Sub SumarMontoCosto()
        Try
            Dim totalCosto As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As Boolean
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("MontoCosto").Value
                If bSelected Then
                    totalCosto = totalCosto + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoCosto").Value)
                End If
            Next
            txtMontoCosto.Value = totalCosto


            txtutilidad.Value = txtMontoVenta.Value - txtMontoCosto.Value

            txtporcentaje.Value = Math.Round((txtutilidad.Value / IIf(txtMontoVenta.Value = 0, 1, txtMontoVenta.Value)) * 100, 2)

        Catch ex As Exception
            MsgBox("Error al sumar Monto Costo" + ex.Message)
        End Try
    End Sub

    Private Function SumarDescuento() As Double
        Try
            Dim totalDscto As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As Boolean
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("MontoDscto").Value
                If bSelected Then
                    totalDscto = totalDscto + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoDscto").Value)
                End If
            Next
            Return totalDscto
        Catch ex As Exception
            MsgBox("Error al sumar Montos" + ex.Message)
        End Try
    End Function

    Private Function SumarCotizacion() As Double
        Try
            Dim totalVenta As Double = 0
            Dim totalCosto As Double = 0
            'Dim row As Janus.Windows.GridEX.GridEXRow
            'Dim bSelectedVenta As Boolean
            'For i = 0 To Me.dgvcotizaciones.RowCount - 1
            '    Me.dgvcotizaciones.Row = i
            '    row = Me.dgvcotizaciones.GetRow()
            '    bSelectedVenta = row.Cells("CostoTeorico").Value
            '    If bSelectedVenta Then
            '        'totalVenta = totalVenta + CDbl(Me.dgvcotizaciones.CurrentRow.Cells("TotalVenta").Value)
            '        totalCosto = totalCosto + CDbl(Me.dgvcotizaciones.CurrentRow.Cells("CostoTeorico").Value)
            '    End If
            'Next


            For Each Fila As DataRow In dtCotizacion.Rows
                totalVenta = totalVenta + CDbl(Fila.Item("TotalVenta"))
                totalCosto = totalCosto + CDbl(Fila.Item("CostoTeorico"))
            Next


            txttotalventateorica.Value = totalVenta
            txttotalcostoteorica.Value = totalCosto
            txttotalutilidadteorica.Value = totalVenta - totalCosto
            txttotalporcentajeteorica.Value = Math.Round((txttotalutilidadteorica.Value / IIf(totalVenta = 0, 1, totalVenta)) * 100, 2)

        Catch ex As Exception
            MsgBox("Error al sumar Monto Venta" + ex.Message)
        End Try
    End Function


    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        SumarMontoVenta()
        SumarMontoCosto()
    End Sub

    Private Sub btnvalidar_Click(sender As Object, e As EventArgs) Handles btnvalidar.Click
        Try
            Dim state_process As Boolean
            Dim registro As JobService.Job
            registro = oJobService.Obtener(CodJob)
            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            state_process = oJobService.ValidarLiquidar(CodJob, registro.TipoJob.IdTipoJob, cbParcial.Checked, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If state_process Then
                MsgBox("La información es correcta y esta lista para liquidar la OT")
            Else
                MsgBox("¡Tiene documentos pendientes por procesar, verifique...!")
            End If
        Catch ex As Exception
            MsgBox("Observaciones que impiden liquidar : " + ex.Message)
        End Try
    End Sub

    Private Sub btnrechazar_Click(sender As Object, e As EventArgs) Handles btnrechazar.Click

        Try
            Dim frm As New frmJob_RechazarLiquidacion
            If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Dim observacion As String = frm.txtObservacion.Text
                Dim state_process As Boolean
                state_process = oJobService.ObservarLiquidacion(CodJob, observacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If state_process Then
                    MsgBox("Se observo la liquidacion con exito!!!!!!")
                Else
                    MsgBox("¡Hay problemas al rechazar, verifique...!")
                End If


                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        Catch ex As Exception
            MsgBox("Error al rechazar: " + ex.Message)
        End Try


    End Sub
End Class