Imports System.ServiceModel

Public Class frmGuiaRemision_AgregarConsumoJob

    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
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

    Private Sub frmGuiaRemision_AgregarConsumoJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmGuiaRemision_AgregarConsumoJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_AgregarConsumoJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        txtLocacion.Text = Locacion
        txtAlmacen.Text = Almacen
        'txtFecDoc.Text = Today.Date
        txtFecDoc.Text = Session.sFecha
        txtNumDoc.Text = NumDoc
        biImprimir.Enabled = False
    End Sub

    'Private Sub llenarCombos()
    '    Try
    '        dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
    '        cmbOficinas.DataSource = dtOficinas
    '        cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
    '        cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
    '        cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
    '        cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
    '        cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
    '        cmbOficinas.SelectedIndex = 0
    '        dtOficinas = Nothing
    '    Catch ex As Exception
    '        MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()
            listaDatos()            
        End If
    End Sub

    Private Sub EnableOptions()
        If dtDatos.Rows.Count < 1 Then
            biImprimir.Enabled = False
        Else
            biImprimir.Enabled = True
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oGuiaRemisionService.Close()
            oTransferenciaService.Close()
            oMaestroService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oGuiaRemisionService.Abort()
            oTransferenciaService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oGuiaRemisionService.Abort()
            oTransferenciaService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim codigos As String = oGuiaRemisionService.MostrarConsumoJobSinStock(txtNumJob.Text.Trim, CodAlmacen)
            If MsgBox(codigos & " ¿Está seguro de GENERAR las Guías", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidarData() = True Then
                'MsgBox("Checkeando ", MsgBoxStyle.Information)
                AgregarConsumoJob()
            End If
        Catch ex As Exception
            MsgBox("Error al Generar guias multiples " + ex.Message, MsgBoxStyle.Information, "Error al Generar")
        End Try
    End Sub

    Private Sub AgregarConsumoJob()
        Try
            oGuiaRemisionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            Estado = oGuiaRemisionService.IngresarConsumoJob(CodAlmacen, txtNumJob.Text.Trim, txtNumDoc.Text.Trim, txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If Estado = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
                MsgBox("Debe Ingresar el Nº de la OT, Verifique")
                dgvDatos.DataSource = Nothing
                biImprimir.Enabled = False
            End If
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oTransferenciaService.MostrarAtencionJob(Session.sCodEmp, txtNumJob.Text).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            If dtDatos.Rows.Count < 1 Then
                MsgBox("No existen datos, para este OT")
                txtNumJob.Clear()
                txtNumJob.Focus()
                dgvDatos.DataSource = Nothing
            End If
            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpImprimirConsumoJob

            dtReporte = oTransferenciaService.MostrarAtencionJob(Session.sCodEmp, txtNumJob.Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Listado de Repuestos Consumidos"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
End Class