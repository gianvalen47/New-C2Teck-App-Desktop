Imports System.ServiceModel

Public Class frmRptGastosViajeTotalxRubro

    Private oMaestroService As New MaestroService.MaestroClient
    Private oPreGastoRealService As New PreGastoRealService.PreGastoRealServiceClient
    Private oPreGastoRealDetService As New PreGastoRealDetService.PreGastoRealDetServiceClient
    Private oJobService As New JobService.JobServiceClient
    'Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private dtRubro As DataTable
    Private dtCLiente As DataTable
    Private dtOficinas As DataTable
    Public IdPersona As Integer
    Public IdCliente As Integer

    Private Sub frmRptGastosViajeTotalxRubro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oPreGastoRealDetService.Close()
            oPreGastoRealService.Close()
            oJobService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oPreGastoRealDetService.Abort()
            oPreGastoRealService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oPreGastoRealDetService.Abort()
            oPreGastoRealService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRptGastosViajeTotalxRubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRptGastosViajeTotalxRubro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtFechaInicio.Value = CDate("01/01/" + utils.toBlank(Year(Today)))
        txtFechaFin.Value = Today()
        llenarCombos()


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

    Private Sub llenarCombos()
        Try
            '------------------------------- Oficinas --------------------------------------------
            dtOficinas = oMaestroService.MostrarOficinas("mgamarra").Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbLocacion.DataSource = dtOficinas
            cmbLocacion.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 0

            '------------------------------- Rubros --------------------------------------------
            dtRubro = oPreGastoRealDetService.MostrarRubros.Tables(0)
            dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOS COMBOS :" + ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkJob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJob.CheckedChanged
        If chkJob.Checked Then
            txtNumJob.Text = ""
        End If
    End Sub

    Private Sub chkColaborador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkColaborador.CheckedChanged
        If chkColaborador.Checked Then
            txtColaborador.Text = ""
            IdPersona = 0
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then
            txtCliente.Text = ""
            IdCliente = 0
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Len(Trim(txtNumJob.Text)) > 0 Then

                    If Not (oJobService.Buscar(txtNumJob.Text)) Then
                        MsgBox("Número de OT no existente, Verifique")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()

                    Else
                        btnBuscarCliente.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkJob.Checked = False
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
        txtNumJob.Select()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                txtCliente.Text = frm.descripcion
                txtCliente.BackColor = System.Drawing.SystemColors.Control
                IdCliente = frm.codigo
                'Cliente = frm.descripcion

            End If
            txtCliente.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = ""
                    IdPersona = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(117, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptGastosViajeTotalPorRubro

            If utils.toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio")
            ElseIf utils.toBlank(txtFechaFin.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Termino")
            Else

                Dim FecInicio As Date
                Dim FecFinal As Date
                Dim NumJob As String
                Dim CodOfi As String
                Dim Cliente As String
                Dim Persona As String
                Dim CodRubro As String
                Dim NumJob2 As String = ""

                'Datos para DataTable
                Dim CodLoc As String
                Dim CodCli As String
                Dim CodPer As String
                Dim Rubro As String

                CodLoc = cmbLocacion.Value
                CodCli = IdCliente
                CodPer = IdPersona
                Rubro = cmbRubro.Value

                If txtNumJob.Text = "" Then
                    NumJob = ""
                    NumJob2 = "Todos"
                Else
                    NumJob = txtNumJob.Text
                End If

                If cmbLocacion.Text = "Todos" Then
                    CodOfi = "Todos"
                End If

                FecInicio = txtFechaInicio.Text
                FecFinal = txtFechaFin.Text
                CodOfi = cmbLocacion.Value
                Cliente = txtCliente.Text
                Persona = txtColaborador.Text
                CodRubro = cmbRubro.Text

                dtDatos = oPreGastoRealService.ReportePorRubro(FecInicio, FecFinal, _
                                                            NumJob, CodLoc, utils.toNumber(CodCli), _
                                                            utils.toNumber(CodPer), Rubro).Tables(0)

                If dtDatos.Rows.Count <= 0 Then
                    MsgBox("No hay Datos a mostrar en este reporte")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("FecInicio", FecInicio)
                    reporte.SetParameterValue("FecFinal", FecFinal)
                    reporte.SetParameterValue("NumJob", NumJob2)
                    reporte.SetParameterValue("CodOfi", CodOfi)
                    reporte.SetParameterValue("Cliente", Cliente)
                    reporte.SetParameterValue("IdPer", Persona)
                    reporte.SetParameterValue("CodRubro", CodRubro)
                    'reporte.SetParameterValue("CodLoc", CodLoc)
                    'reporte.SetParameterValue("CodCli", CodCli)
                    'reporte.SetParameterValue("CodPer", CodPer)
                    'reporte.SetParameterValue("Rubro", Rubro)

                    forma.Text = "Reporte de Gastos de Viaje x Rubro"

                    forma.ShowDialog()

                End If

                End If

        Catch ex As Exception
            MsgBox("Error en el reporte : " + ex.Message)
        End Try


    End Sub


End Class