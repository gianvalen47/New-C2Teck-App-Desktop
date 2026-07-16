Imports System.ServiceModel
Public Class frmRepHorasEscalon

    Private oJobservices As New JobService.JobServiceClient
    Private oJobMarcacion As New MarcacionJobService.MarcacionJobServiceClient
    Private oJobCotizaciones As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtTipoJob As DataTable
    Private dtMantenimiento As DataTable
    Private dtEstado As DataTable
    Private IdCliente As Integer
    Private Sub frmRepHorasEscalon_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobservices.Close()
            oJobMarcacion.Close()
            oJobCotizaciones.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oJobservices.Abort()
            oJobMarcacion.Abort()
            oJobCotizaciones.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobservices.Abort()
            oJobMarcacion.Abort()
            oJobCotizaciones.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepHorasEscalon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepHorasEscalon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 121)
        '/*************************************************************************************/

        llenarCombos()
        txtanio.Value = Today.Year
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0
        Catch ex As Exception
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = 0
        Catch ex As Exception
        End Try
        Try
            fila(4) = ""
        Catch ex As Exception
        End Try
        Try
            fila(5) = ""
        Catch ex As Exception
        End Try
        Try
            fila(6) = 0
        Catch ex As Exception
        End Try

        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = 0
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowTodos2(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0
        Catch ex As Exception

        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '=================================== Tipo Job =======================================
            dtTipoJob = oJobservices.MostrarTipo.Tables(0)
            dtTipoJob.Rows.InsertAt(getRowTodos(dtTipoJob), 0)
            cmbTipoJob.DataSource = dtTipoJob
            cmbTipoJob.DropDownList.DataMember = dtTipoJob.Columns("AbrTipo").ToString
            cmbTipoJob.DropDownList.DisplayMember = dtTipoJob.Columns("AbrTipo").ToString
            cmbTipoJob.DropDownList.ValueMember = dtTipoJob.Columns("IdTipoJob").ToString
            cmbTipoJob.DropDownList.Columns(0).DataMember = dtTipoJob.Columns("IdTipoJob").ToString
            cmbTipoJob.DropDownList.Columns(1).DataMember = dtTipoJob.Columns("AbrTipo").ToString
            cmbTipoJob.SelectedIndex = 0
            dtTipoJob = Nothing

            '================================= Mantenimiento =====================================
            dtMantenimiento = oJobCotizaciones.MostrarTipoMantenimiento.Tables(0)
            dtMantenimiento.Rows.InsertAt(getRowTodos1(dtMantenimiento), 0)
            cmbMantenimiento.DataSource = dtMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtMantenimiento.Columns("abrmantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtMantenimiento.Columns("abrmantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtMantenimiento.Columns("codmantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtMantenimiento.Columns("codmantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtMantenimiento.Columns("abrmantenimiento").ToString
            cmbMantenimiento.SelectedIndex = 0
            dtMantenimiento = Nothing

            dtEstado = oJobservices.MostrarEstados.Tables(0)
            dtEstado.Rows.InsertAt(getRowTodos2(dtEstado), 0)
            cmbEstado.DataSource = dtEstado
            cmbEstado.DropDownList.DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstado.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstado.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstado = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try

            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptHorasEscalon

            If txtCliente.Text = "(TODOS)" Then
                IdCliente = 0
            End If

            dtReporte = oJobMarcacion.ReporteHorasEscalon(utils.toNumber(txtanio.Value), cmbMantenimiento.Value, txtNumJob.Text, IdCliente, cmbTipoJob.Value, cmbEstado.Value).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                'dtReporte.Sort = "Documento Asc "
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                forma.Text = "Reporte Consolidados de Horas Escalón"
                reporte.SetParameterValue("Anio", txtanio.Value)
                reporte.SetParameterValue("TipoJob", IIf(cmbTipoJob.Text = "(Todos)", "(Todos)", cmbTipoJob.Text))
                reporte.SetParameterValue("Mant", IIf(cmbMantenimiento.Text = "(Todos)", "(Todos)", cmbMantenimiento.Text))
                reporte.SetParameterValue("Estado", IIf(cmbEstado.Text = "(Todos)", "(Todos)", cmbEstado.Text))
                reporte.SetParameterValue("Cliente", IIf(txtCliente.Text = "(TODOS)", "(Todos)", txtCliente.Text))
                reporte.SetParameterValue("Job", IIf(txtNumJob.Text = "", "(Todos)", txtNumJob.Text))
                'reporte.SetParameterValue("Reporte", "REPORTE DE SOLICITUD DE GASTOS TOTALIZADO")
                forma.ShowDialog()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(121, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        If rbBuscarCliente.Checked = True Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobservices.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            Else
                MsgBox("Ingrese un N° de OT")
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        If Len(Trim(txtNumJob.Text)) > 0 Then
            If Not (oJobservices.Buscar(txtNumJob.Text)) Then
                MsgBox("Número de OT no existente, Verifique")
                txtNumJob.Text = ""
                txtNumJob.Focus()
            End If
        Else
            MsgBox("Ingrese un N° de OT")
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class