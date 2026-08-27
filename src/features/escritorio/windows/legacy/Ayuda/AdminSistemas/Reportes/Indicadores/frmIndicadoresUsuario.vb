Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmIndicadoresUsuario

    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient

    Dim dtReporte As DataTable
    Dim dtTipoSolicitud1 As DataTable
    Dim dtTipoSolicitud2 As DataTable
    Dim dtTipoSolicitud3 As DataTable
    Dim dtTipoSolicitud4 As DataTable
    Dim forma As New frmReportes

    Private Sub frmIndicadoresUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudUsuarioService.Close()
            oSeguridadService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSolicitudUsuarioService.Abort()
            oSeguridadService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSolicitudUsuarioService.Abort()
            oSeguridadService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'txtanio1.Value = Today.Year
        'txtanio2.Value = Today.Year
        'txtanio3.Value = Today.Year
        cbFecInicio.Value = CDate("01/01/" & Today.Year)
        llenarCombos()
        rbOpcion1.Checked = True
        gbPorSolicitante.Enabled = False
        gbRanking.Enabled = False

    End Sub


    Private Sub llenarCombos()
        '------------------------------- Solicitudes --------------------------------------------
        dtTipoSolicitud1 = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
        dtTipoSolicitud1.Rows.InsertAt(getRowTodos(dtTipoSolicitud1), 0)
        cmbTipSol1.DataSource = dtTipoSolicitud1
        cmbTipSol1.DropDownList.DataMember = dtTipoSolicitud1.Columns("Nombre").ToString
        cmbTipSol1.DropDownList.DisplayMember = dtTipoSolicitud1.Columns("Nombre").ToString
        cmbTipSol1.DropDownList.ValueMember = dtTipoSolicitud1.Columns("IdTipo").ToString
        cmbTipSol1.DropDownList.Columns(0).DataMember = dtTipoSolicitud1.Columns("IdTipo").ToString
        cmbTipSol1.DropDownList.Columns(1).DataMember = dtTipoSolicitud1.Columns("Nombre").ToString
        cmbTipSol1.SelectedIndex = -1
        dtTipoSolicitud1 = Nothing

        dtTipoSolicitud2 = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
        dtTipoSolicitud2.Rows.InsertAt(getRowTodos(dtTipoSolicitud2), 0)
        cmbTipSol2.DataSource = dtTipoSolicitud2
        cmbTipSol2.DropDownList.DataMember = dtTipoSolicitud2.Columns("Nombre").ToString
        cmbTipSol2.DropDownList.DisplayMember = dtTipoSolicitud2.Columns("Nombre").ToString
        cmbTipSol2.DropDownList.ValueMember = dtTipoSolicitud2.Columns("IdTipo").ToString
        cmbTipSol2.DropDownList.Columns(0).DataMember = dtTipoSolicitud2.Columns("IdTipo").ToString
        cmbTipSol2.DropDownList.Columns(1).DataMember = dtTipoSolicitud2.Columns("Nombre").ToString
        cmbTipSol2.SelectedIndex = -1
        dtTipoSolicitud2 = Nothing

        dtTipoSolicitud3 = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
        cmbTipSol3.DataSource = dtTipoSolicitud3
        cmbTipSol3.DropDownList.DataMember = dtTipoSolicitud3.Columns("Nombre").ToString
        cmbTipSol3.DropDownList.DisplayMember = dtTipoSolicitud3.Columns("Nombre").ToString
        cmbTipSol3.DropDownList.ValueMember = dtTipoSolicitud3.Columns("IdTipo").ToString
        cmbTipSol3.DropDownList.Columns(0).DataMember = dtTipoSolicitud3.Columns("IdTipo").ToString
        cmbTipSol3.DropDownList.Columns(1).DataMember = dtTipoSolicitud3.Columns("Nombre").ToString
        cmbTipSol3.SelectedIndex = -1
        dtTipoSolicitud3 = Nothing

        dtTipoSolicitud4 = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
        cmbTipSol4.DataSource = dtTipoSolicitud4
        cmbTipSol4.DropDownList.DataMember = dtTipoSolicitud4.Columns("Nombre").ToString
        cmbTipSol4.DropDownList.DisplayMember = dtTipoSolicitud4.Columns("Nombre").ToString
        cmbTipSol4.DropDownList.ValueMember = dtTipoSolicitud4.Columns("IdTipo").ToString
        cmbTipSol4.DropDownList.Columns(0).DataMember = dtTipoSolicitud4.Columns("IdTipo").ToString
        cmbTipSol4.DropDownList.Columns(1).DataMember = dtTipoSolicitud4.Columns("Nombre").ToString
        cmbTipSol4.SelectedIndex = -1
        dtTipoSolicitud4 = Nothing

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

    Private Sub rbOpcion1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOpcion1.CheckedChanged
        If rbOpcion1.Checked Then
            gb1.Enabled = True
            gb2.Enabled = False
            gb3.Enabled = False
            cmbTipSol1.SelectedIndex = -1
            cmbTipSol2.SelectedIndex = -1
            rbGrupo.Checked = True
            rbMinutos.Checked = False
            rbHoras.Checked = False
            rbDias.Checked = False
        End If
    End Sub

    Private Sub rbOpcion2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOpcion2.CheckedChanged
        If rbOpcion2.Checked Then
            gb1.Enabled = False
            gb2.Enabled = True
            gb3.Enabled = False
            cmbTipSol1.SelectedIndex = 0
            cmbTipSol2.SelectedIndex = -1
            rbMinutos.Checked = True
            rbGrupo.Checked = False
            rbTipoTrabajo.Checked = False
            rbEstados.Checked = False
            rbSolicitantes.Checked = False
        End If
    End Sub

    Private Sub rbOpcion3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOpcion3.CheckedChanged
        If rbOpcion3.Checked Then
            gb1.Enabled = False
            gb2.Enabled = False
            gb3.Enabled = True
            cmbTipSol1.SelectedIndex = -1
            cmbTipSol2.SelectedIndex = 0
            rbMinutos.Checked = False
            rbHoras.Checked = False
            rbDias.Checked = False
            rbGrupo.Checked = False
            rbTipoTrabajo.Checked = False
            rbEstados.Checked = False
            rbSolicitantes.Checked = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(159, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If (rbOpcion1.Checked And rbRanking.Checked And rbRankSolicitante.Checked) Or (rbOpcion1.Checked And rbRanking.Checked And rbRankTrabajo.Checked) Or (rbOpcion1.Checked And rbSolicitantes.Checked And rbSolicitantexCantidad.Checked) Or (rbOpcion1.Checked And rbSolicitantes.Checked And rbTipoTrabajo2.Checked) Or (rbOpcion1.Checked And rbTipoProblema.Checked) Or (rbOpcion1.Checked And rbSolicitantes.Checked And rbTipoProblema2.Checked) Then
            If rbOpcion1.Checked Then
                MostrarReporteOpcion1()
            End If
            'ElseIf rbOpcion2.Checked Then
            '    MostrarReporteOpcion2()
            'ElseIf rbOpcion3.Checked Then
            '    MostrarReporteOpcion3()
            'End If
        ElseIf (rbOpcion2.Checked) Then
            'If Year(cbFecInicio.Value) = Year(cbFecFinal.Value) Then
            '    MsgBox("La fecha de inicio y la fecha de fin deben ser de diferentes años.", MsgBoxStyle.Information)
            'Else
            MostrarReporteOpcion2()
            'End If

        Else
            If Year(cbFecInicio.Value) <> Year(cbFecFinal.Value) Then
                MsgBox("La fecha de inicio y la fecha de fin deben pertenecer al mismo año.", MsgBoxStyle.Information)
            Else
                If rbOpcion1.Checked Then
                    MostrarReporteOpcion1()
                ElseIf rbOpcion2.Checked Then
                    MostrarReporteOpcion2()
                ElseIf rbOpcion3.Checked Then
                    MostrarReporteOpcion3()
                End If
            End If
        End If
    End Sub

    Private Sub MostrarReporteOpcion1()
        Try
            Dim opcion As Integer
            Dim reporte1 As New rptIndicUsuxGrupo
            Dim reporte2 As New rptIndicUsuxTipoTrabajo
            Dim reporte3 As New rptIndicUsuxEstados
            Dim reporte4 As New rptIndicUsuxSolicitante
            Dim reporte5 As New rptIndicUsuxSolicitantexTrabajo
            Dim reporte6 As New rptIndicUsuxSolicitantexProblema
            Dim reporte7 As New rptIndicUsuxProblema
            Dim reporte8 As New rptIndicUsuxRankingxSolicitante
            Dim reporte9 As New rptIndicUsuxRankingxTipoTrabajo

            If rbGrupo.Checked Then
                opcion = 1
            ElseIf rbTipoTrabajo.Checked Then
                opcion = 2
            ElseIf rbEstados.Checked Then
                opcion = 3
            ElseIf rbSolicitantes.Checked And rbSolicitantexCantidad.Checked Then
                opcion = 6
            ElseIf rbSolicitantes.Checked And rbTipoTrabajo2.Checked Then
                opcion = 8
            ElseIf rbSolicitantes.Checked And rbTipoProblema2.Checked Then
                opcion = 9
            ElseIf rbTipoProblema.Checked Then
                opcion = 10
            ElseIf rbRanking.Checked And rbRankSolicitante.Checked Then
                opcion = 11
            ElseIf rbRanking.Checked And rbRankTrabajo.Checked Then
                opcion = 12
            End If

            If rbSolicitantes.Checked And rbTipoProblema2.Checked Then
                dtReporte = oSolicitudUsuarioService.ReporteAgrupadoPorOpcion(cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbTipSol4.Value), opcion).Tables(0)
                'DataGridView1.DataSource = dtReporte
            ElseIf rbTipoProblema.Checked Then
                dtReporte = oSolicitudUsuarioService.ReporteAgrupadoPorOpcion(cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbTipSol3.Value), opcion).Tables(0)
                'DataGridView1.DataSource = dtReporte
            Else
                dtReporte = oSolicitudUsuarioService.ReporteAgrupadoPorOpcion(cbFecInicio.Value, cbFecFinal.Value, 0, opcion).Tables(0)
                DataGridView1.DataSource = dtReporte
            End If

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If opcion = 1 Then
                    reporte1.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte1
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Grupo"
                    reporte1.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte1.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                ElseIf opcion = 2 Then
                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Tipo de Trabajo"
                    reporte2.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte2.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                ElseIf opcion = 3 Then
                    reporte3.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte3
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Estados"
                    reporte3.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte3.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                ElseIf opcion = 6 Then
                    reporte4.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte4
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Solicitantes"
                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte4.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte4.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte4.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte4.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte4.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    'reporte4.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    'reporte4.SetParameterValue("FecFinal", Year(cbFecFinal.Value))
                    reporte4.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte4.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    reporte4.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte4.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    forma.ShowDialog()
                ElseIf opcion = 8 Then
                    reporte5.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte5
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Solicitantes por Trabajo"
                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte5.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte5.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte5.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte5.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte5.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    'reporte5.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    'reporte5.SetParameterValue("FecFinal", Year(cbFecFinal.Value))
                    reporte5.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte5.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    reporte5.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte5.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    forma.ShowDialog()
                ElseIf opcion = 9 Then
                    reporte6.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte6
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Solicitantes por Problema"
                    reporte6.SetParameterValue("TipoTrabajo", cmbTipSol4.Text)
                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte6.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte6.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte6.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte6.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte6.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    reporte6.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte6.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    'reporte6.SetParameterValue("FecInicio", cbFecInicio.Value)
                    'reporte6.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte6.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte6.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    forma.ShowDialog()
                ElseIf opcion = 10 Then
                    reporte7.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte7
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Numero de Solicitudes x Problema"
                    reporte7.SetParameterValue("TipoTrabajo", cmbTipSol3.Text)
                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte7.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte7.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte7.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte7.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte7.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    'reporte7.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    'reporte7.SetParameterValue("FecFinal", Year(cbFecFinal.Value))

                    reporte7.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte7.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    reporte7.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte7.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    forma.ShowDialog()
                ElseIf opcion = 11 Then
                    reporte8.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte8
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte Ranking x Solicitante"
                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte8.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte8.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte8.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte8.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte8.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    'reporte8.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & "31/10/" & Year(cbFecInicio.Value) & " Y " & "01/01/" & Year(cbFecFinal.Value) & " Al " & "31/10/" & Year(cbFecFinal.Value))
                    'reporte8.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    'reporte8.SetParameterValue("FecFinal", Year(cbFecFinal.Value))
                    reporte8.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte8.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    reporte8.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte8.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    forma.ShowDialog()
                ElseIf opcion = 12 Then
                    reporte9.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte9
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte Ranking x Tipo de Trabajo"
                    Dim recuento1 As Int64 = 0
                    Dim recuento2 As Int64 = 0
                    Dim recuento3 As Int64 = 0
                    Dim recuento4 As Int64 = 0
                    Dim recuento5 As Int64 = 0
                    Dim recuento6 As Int64 = 0
                    Dim recuento7 As Int64 = 0
                    Dim recuento8 As Int64 = 0
                    Dim recuento9 As Int64 = 0
                    Dim recuento10 As Int64 = 0
                    Dim recuento11 As Int64 = 0
                    Dim recuento12 As Int64 = 0
                    Dim recuento13 As Int64 = 0
                    Dim recuento14 As Int64 = 0

                    For i As Integer = 0 To DataGridView1.RowCount - 1
                        If DataGridView1.Item("IdTipo".ToLower, i).Value = 0 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento1 = recuento1 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento8 = recuento8 + 1
                            End If
                        ElseIf DataGridView1.Item("IdTipo".ToLower, i).Value = 1 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento2 = recuento2 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento9 = recuento9 + 1
                            End If
                        ElseIf DataGridView1.Item("IdTipo".ToLower, i).Value = 7 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento3 = recuento3 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento10 = recuento10 + 1
                            End If
                        ElseIf DataGridView1.Item("IdTipo".ToLower, i).Value = 8 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento4 = recuento4 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento11 = recuento11 + 1
                            End If
                        ElseIf DataGridView1.Item("IdTipo".ToLower, i).Value = 9 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento5 = recuento5 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento12 = recuento12 + 1
                            End If
                        ElseIf DataGridView1.Item("IdTipo".ToLower, i).Value = 10 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento6 = recuento6 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento13 = recuento13 + 1
                            End If
                        ElseIf DataGridView1.Item("IdTipo".ToLower, i).Value = 11 Then
                            If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                                recuento7 = recuento7 + 1
                            End If
                            If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                                recuento14 = recuento14 + 1
                            End If
                        End If
                    Next

                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte9.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte9.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte9.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte9.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte8.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & "31/10/" & Year(cbFecInicio.Value) & " Y " & "01/01/" & Year(cbFecFinal.Value) & " Al " & "31/10/" & Year(cbFecFinal.Value))
                    reporte9.SetParameterValue("recuento1", recuento1)
                    reporte9.SetParameterValue("recuento2", recuento2)
                    reporte9.SetParameterValue("recuento3", recuento3)
                    reporte9.SetParameterValue("recuento4", recuento4)
                    reporte9.SetParameterValue("recuento5", recuento5)
                    reporte9.SetParameterValue("recuento6", recuento6)
                    reporte9.SetParameterValue("recuento7", recuento7)
                    reporte9.SetParameterValue("recuento8", recuento8)
                    reporte9.SetParameterValue("recuento9", recuento9)
                    reporte9.SetParameterValue("recuento10", recuento10)
                    reporte9.SetParameterValue("recuento11", recuento11)
                    reporte9.SetParameterValue("recuento12", recuento12)
                    reporte9.SetParameterValue("recuento13", recuento13)
                    reporte9.SetParameterValue("recuento14", recuento14)

                    'reporte9.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    reporte9.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte9.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    'reporte9.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    'reporte9.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    reporte9.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte9.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    forma.ShowDialog()
                End If
                End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteOpcion2()
        Try
            Dim opcion2 As Integer
            Dim reporte As New rptIndicUsuxUnidad
            Dim reporte2 As New rptIndicUsuxUnidadTipoTrabajo

            If rbMinutos.Checked Then
                opcion2 = 1
            ElseIf rbHoras.Checked Then
                opcion2 = 2
            ElseIf rbDias.Checked Then
                opcion2 = 3
            End If

            If utils.toNumber(cmbTipSol1.Value) = 0 Then
                dtReporte = oSolicitudUsuarioService.ReporteAgrupadoPorUnidad(cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbTipSol1.Value), opcion2, 7).Tables(0)
                DataGridView1.DataSource = dtReporte

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Duración por Atención"
                    reporte2.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte2.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    reporte2.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte2.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)

                    Dim recuento1 As Int64 = 0
                    Dim recuento2 As Int64 = 0

                    For i As Integer = 0 To DataGridView1.RowCount - 1
                        If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                            recuento1 = recuento1 + 1
                        End If
                        If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                            recuento2 = recuento2 + 1
                        End If

                    Next

                    reporte2.SetParameterValue("recuento1", recuento1)
                    reporte2.SetParameterValue("recuento2", recuento2)

                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte2.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte2.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte2.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte2.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If
                    'reporte2.SetParameterValue("FechaCompleta", "DEL  " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " AL " & UltimoDiaDelMes(cbFecFinal.Value))
                    If opcion2 = 1 Then
                        'reporte2.SetParameterValue("Titulo", "Reporte Duración de Atención en Minutos")
                        reporte2.SetParameterValue("Unidad", "MINUTOS")
                    ElseIf opcion2 = 2 Then
                        'reporte2.SetParameterValue("Titulo", "Reporte Duración de Atención en Horas")
                        reporte2.SetParameterValue("Unidad", "HORAS")
                    ElseIf opcion2 = 3 Then
                        'reporte2.SetParameterValue("Titulo", "Reporte Duración de Atención en Dias")
                        reporte2.SetParameterValue("Unidad", "DIAS")
                    End If
                    'reporte2.SetParameterValue("subtitulo", cmbTipSol1.Text)
                    forma.ShowDialog()
                End If

            Else
                dtReporte = oSolicitudUsuarioService.ReporteAgrupadoPorUnidad(cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbTipSol1.Value), opcion2, 4).Tables(0)
                DataGridView1.DataSource = dtReporte

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Duración por Atención"
                    If opcion2 = 1 Then
                        reporte.SetParameterValue("Titulo", "Reporte Duración de Atención en Minutos")
                        reporte.SetParameterValue("unidad", "MINUTOS")
                    ElseIf opcion2 = 2 Then
                        reporte.SetParameterValue("Titulo", "Reporte Duración de Atención en Horas")
                        reporte.SetParameterValue("unidad", "HORAS")
                    ElseIf opcion2 = 3 Then
                        reporte.SetParameterValue("Titulo", "Reporte Duración de Atención en Dias")
                        reporte.SetParameterValue("unidad", "DIAS")
                    End If

                    Dim recuento1 As Int64 = 0
                    Dim recuento2 As Int64 = 0

                    For i As Integer = 0 To DataGridView1.RowCount - 1
                        If DataGridView1.Item("Anio1".ToLower, i).Value <> 0 Then
                            recuento1 = recuento1 + 1
                        End If
                        If DataGridView1.Item("Anio2".ToLower, i).Value <> 0 Then
                            recuento2 = recuento2 + 1
                        End If

                    Next

                    reporte.SetParameterValue("recuento1", recuento1)
                    reporte.SetParameterValue("recuento2", recuento2)

                    reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("subtitulo", cmbTipSol1.Text)
                    reporte.SetParameterValue("FecInicio", Year(cbFecInicio.Value))
                    reporte.SetParameterValue("FecFinal", Year(cbFecInicio.Value) + 1)
                    'reporte.SetParameterValue("FechaCompleta", "Desde el " & "01/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecInicio.Value) & " Al " & UltimoDiaDelMes(cbFecFinal.Value))
                    'If (Year(cbFecInicio.Value) = Year(cbFecFinal.Value)) Then
                    '    reporte.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & cbFecFinal.Value)
                    '    reporte.SetParameterValue("FechaCompleta2", "")
                    'ElseIf (Year(cbFecInicio.Value) <> Year(cbFecFinal.Value)) Then
                    '    reporte.SetParameterValue("FechaCompleta1", cbFecInicio.Value & " Al " & Format(cbFecFinal.Value.Day, "00") & "/" & Format(Month(cbFecFinal.Value), "00") & "/" & Year(cbFecInicio.Value))
                    '    reporte.SetParameterValue("FechaCompleta2", Format(cbFecInicio.Value.Day, "00") & "/" & Format(Month(cbFecInicio.Value), "00") & "/" & Year(cbFecFinal.Value) & " Al " & cbFecFinal.Value)
                    'End If

                    If opcion2 = 1 Then
                        'reporte2.SetParameterValue("Titulo", "Reporte Duración de Atención en Minutos")
                        reporte.SetParameterValue("Unidad", "MINUTOS")
                    ElseIf opcion2 = 2 Then
                        'reporte2.SetParameterValue("Titulo", "Reporte Duración de Atención en Horas")
                        reporte.SetParameterValue("Unidad", "HORAS")
                    ElseIf opcion2 = 3 Then
                        'reporte2.SetParameterValue("Titulo", "Reporte Duración de Atención en Dias")
                        reporte.SetParameterValue("Unidad", "DIAS")
                    End If

                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteOpcion3()
        Try
            Dim reporte As New rptIndicUsuxPersonal

            dtReporte = oSolicitudUsuarioService.ReporteAgrupadoPorPersonal(cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbTipSol2.Value), 5).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte por Personal"
                reporte.SetParameterValue("Titulo", "Reporte de Solicitudes por Personal del " & cbFecInicio.Value & " Al " & cbFecFinal.Value)
                reporte.SetParameterValue("subtitulo", cmbTipSol2.Text)
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbSolicitantes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSolicitantes.CheckedChanged, rbGrupo.CheckedChanged, rbEstados.CheckedChanged, rbTipoTrabajo.CheckedChanged, rbTipoProblema.CheckedChanged, rbRanking.CheckedChanged
        If rbSolicitantes.Checked Then
            gbPorSolicitante.Enabled = True
            gbRanking.Enabled = False
            'cmbTipSol1.SelectedIndex = -1
            cmbTipSol3.Enabled = False
            cmbTipSol3.SelectedIndex = -1
            'rbTipoTrabajo2.Checked = True
            rbSolicitantexCantidad.Checked = True
        ElseIf rbTipoProblema.Checked Then
            gbPorSolicitante.Enabled = False
            gbRanking.Enabled = False
            cmbTipSol3.Enabled = True
            cmbTipSol3.SelectedIndex = 3
            cmbTipSol4.Enabled = False
            cmbTipSol4.SelectedIndex = -1
        ElseIf rbRanking.Checked Then
            gbRanking.Enabled = True
            gbPorSolicitante.Enabled = False
            cmbTipSol3.Enabled = False
            cmbTipSol3.SelectedIndex = -1
            cmbTipSol4.Enabled = False
            cmbTipSol4.SelectedIndex = -1
            rbRankSolicitante.Checked = True
        Else
            gbPorSolicitante.Enabled = False
            gbRanking.Enabled = False
            'cmbTipSol1.SelectedIndex = -1
            cmbTipSol3.Enabled = False
            cmbTipSol3.SelectedIndex = -1
            cmbTipSol4.Enabled = False
            cmbTipSol4.SelectedIndex = -1
            rbTipoProblema2.Checked = False
        End If
    End Sub

    Private Sub rbTipoTrabajo2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTipoTrabajo2.CheckedChanged, rbTipoProblema2.CheckedChanged
        If rbTipoProblema2.Checked Then
            cmbTipSol4.Enabled = True
            cmbTipSol4.SelectedIndex = 3
        Else
            cmbTipSol4.Enabled = False
            cmbTipSol4.SelectedIndex = -1
        End If
    End Sub

    Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

End Class