Imports System.ServiceModel

Public Class frmVale_Generar

    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient

    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private Estado As Boolean

    Private dtOficinas As DataTable
    Private dtDatos As DataTable
    Public Locacion As String
    Public IdSerieDoc As Integer
    Public NumDoc As String
    Public Almacen As String
    Public CodAlmacen As String
    Public IdLocacion As Integer
    Private Sub frmVale_Generar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oValeMaterialService.Close()
            oMaestroService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oValeMaterialService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oValeMaterialService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmVale_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVale_Generar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        txtLocacion.Text = Locacion
        txtAlmacen.Text = Almacen
        txtFecDoc.Text = Today.Date
        txtNumDoc.Text = NumDoc
        biImprimir.Enabled = False
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()
            listaDatos()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de GENERAR la(s) Guía(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidarData() = True Then
                'MsgBox("Checkeando ", MsgBoxStyle.Information)
                Generar()
            End If
        Catch ex As Exception
            MsgBox("Error al Generar guias multiples " + ex.Message, MsgBoxStyle.Information, "Error al Generar")
        End Try
    End Sub

    Private Sub Generar()
        Try
            Dim estado_process As String = ""

            'If rbComprometidos.Checked = True Then
            estado_process = oValeMaterialService.GenerarGuiaConsumoJob(CodAlmacen, txtNumJob.Text, txtNumDoc.Text, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp, cbProrratear.Checked)
            'ElseIf rbNoComprometidos.Checked = True Then
            '    estado_process = oValeMaterialService.GenerarGuiaConsumoJobNoComprometido(CodAlmacen, txtNumJob.Text, txtNumDoc.Text, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp, cbProrratear.Checked)
            'End If

            If estado_process <> "" Then
                MsgBox("Se generaron las siguientes guias : " & estado_process & ".", MsgBoxStyle.Information, "No hay datos")
                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                '    Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub listaDatos()
        Try
            ' If rbComprometidos.Checked = True Then
            dtDatos = oValeMaterialService.MostrarConsumoRepuestos(CodAlmacen, txtNumJob.Text).Tables(0)
                'ElseIf rbNoComprometidos.Checked = True Then
                '    dtDatos = oValeMaterialService.MostrarConsumoRepuestosNoComprometido(CodAlmacen, txtNumJob.Text).Tables(0)
                'End If

                dtDatos.Columns.Add(New DataColumn("Total", Type.GetType("System.Double")))

            If dtDatos.Rows.Count < 1 Then
                MsgBox("No existen datos, para este OT")
                txtNumJob.Clear()
                txtNumJob.Focus()
                dgvDatos.DataSource = Nothing
            Else
                CalcularColumnaTotal(dtDatos)
                dgvDatos.DataSource = dtDatos
                CalcularMontosTotales()
            End If

            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CalcularColumnaTotal(ByVal dtTable As DataTable)
        Try
            Dim Precio As Double = 0.0
            Dim Descuento As Double = 0.0
            Dim Cantidad As Integer = 0.0
            For Each row As DataRow In dtTable.Rows
                Precio = Math.Round(toDouble(row("PreMer")), 2)
                Descuento = toDouble(row("DscMer"))
                Cantidad = toNumber(row("CanMer"))
                row("Total") = ((Precio - (Precio * Descuento) / (100)) * Cantidad)
            Next
        Catch ex As Exception
            MsgBox("ERROR AL CALCULAR LA COLUMNA TOTAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CalcularMontosTotales()
        Try
            Dim Igv As Double = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion))
            Dim SubTotal As Double = 0
            Dim TotalIgv As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                SubTotal = SubTotal + CDbl(row.Cells("Total").Value)
            Next
            txtTotal.Value = SubTotal
            TotalIgv = Math.Round((SubTotal * Igv) / (100), 2)
            txtTotalIGV.Value = TotalIgv
            txtTotalNeto.Value = SubTotal + TotalIgv
        Catch ex As Exception
            MsgBox("ERROR AL CALCULAR TOTALES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        If dtDatos.Rows.Count < 1 Then
            biImprimir.Enabled = False
        Else
            biImprimir.Enabled = True
        End If
    End Sub

    Function ValidarData() As Boolean
        Try
            If toBlank(txtNumJob.Text) = "" Then
                MsgBox("Debe ingresar el número de la OT..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Value) = "" Then
                MsgBox("Debe ingresar la Fecha..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    dgvDatos.DataSource = Nothing
                    biImprimir.Enabled = False
                Else
                    listaDatos()
                End If
            Else
                MsgBox("Debe Ingresar el Nº de OT, Verifique")
                dgvDatos.DataSource = Nothing
                biImprimir.Enabled = False
            End If
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptGenerarVale

            'If rbComprometidos.Checked = True Then
            dtReporte = oValeMaterialService.MostrarConsumoRepuestos(CodAlmacen, txtNumJob.Text).Tables(0)
                'ElseIf rbNoComprometidos.Checked = True Then
                '    dtReporte = oValeMaterialService.MostrarConsumoRepuestosNoComprometido(CodAlmacen, txtNumJob.Text).Tables(0)
                'End If

                dtReporte.Columns.Add(New DataColumn("Total", Type.GetType("System.Double")))

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                CalcularColumnaTotal(dtReporte)
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                'forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("NumJob", txtNumJob.Text)
                reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("pIgv", toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion)))

                forma.Text = "Listado de Repuestos "
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    dgvDatos.DataSource = Nothing
                    biImprimir.Enabled = False
                Else
                    listaDatos()
                End If
            Else
                dgvDatos.DataSource = Nothing
                biImprimir.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub
End Class