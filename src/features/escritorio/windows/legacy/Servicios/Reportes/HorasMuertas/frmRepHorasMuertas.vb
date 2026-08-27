Imports System.ServiceModel

Public Class frmRepHorasMuertas

    Private oMarcacionJobService As New MarcacionJobService.MarcacionJobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtClase As DataTable
    Private dtCargo As New DataTable


    Private Sub frmRepHorasMuertas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionJobService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMarcacionJobService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMarcacionJobService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepHorasMuertas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepHorasMuertas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 237)
        '/*************************************************************************************/

        cmbClase.Focus()
        txtFechaInicio.Value = CDate("01/" + utils.toBlank(Month(Today)) + "/" + utils.toBlank(Year(Today)))
        txtFechaFin.Value = Today()
        llenarCombos()
        cmbClase.Value = "05"
    End Sub

    Private Sub llenarCombos()

        '======================================== CLASE ================================================
        dtClase = oPersonaService.MostrarClaseCargo.Tables(0)
        dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
        cmbClase.DataSource = dtClase
        cmbClase.DropDownList.DataMember = dtClase.Columns("Nombre").ToString
        cmbClase.DropDownList.DisplayMember = dtClase.Columns("Nombre").ToString
        cmbClase.DropDownList.ValueMember = dtClase.Columns("ClasCargo").ToString
        cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("ClasCargo").ToString
        cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("Nombre").ToString
        cmbClase.SelectedIndex = 0
        dtClase = Nothing

        '======================================== CARGO ===============================================
        dtCargo = oPersonaService.MostrarCargos(Session.sCodEmp, IIf(cmbClase.Value = "", "", cmbClase.Value)).Tables(0)
        dtCargo.Rows.InsertAt(getRowTodos(dtCargo), 0)
        cmbCargo.DataSource = dtCargo
        cmbCargo.DropDownList.DataMember = dtCargo.Columns("DesCargo").ToString
        cmbCargo.DropDownList.DisplayMember = dtCargo.Columns("DesCargo").ToString
        cmbCargo.DropDownList.ValueMember = dtCargo.Columns("CodCargo").ToString
        cmbCargo.DropDownList.Columns(0).DataMember = dtCargo.Columns("CodCargo").ToString
        cmbCargo.DropDownList.Columns(1).DataMember = dtCargo.Columns("DesCargo").ToString
        cmbCargo.SelectedIndex = 0
        dtCargo = Nothing

    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

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
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub MostrarReporteDetallado()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptHorasMuertas

            dtReporte = oMarcacionJobService.ReporteHoraMuerta(Session.sCodEmp, utils.toBlank(txtFechaInicio.Value), utils.toBlank(txtFechaFin.Value), cmbCargo.Value, cmbClase.Value, 1).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False

                'reporte.SetParameterValue("pDesPer", txtSolicitante.Text)
                reporte.SetParameterValue("pFechaInicio", txtFechaInicio.Value)
                reporte.SetParameterValue("pFechaFin", txtFechaFin.Value)
                reporte.SetParameterValue("pClaseCargo", IIf(cmbClase.Text = "(Todos)", "(Todos)", cmbClase.Text))
                reporte.SetParameterValue("pCargo", IIf(cmbCargo.Text = "(Todos)", "(Todos)", cmbCargo.Text))

                forma.Text = "Reporte de Horas Muertas"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub MostrarReporteResumido()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptHorasMuertasResumido

            dtReporte = oMarcacionJobService.ReporteHoraMuerta(Session.sCodEmp, utils.toBlank(txtFechaInicio.Value), utils.toBlank(txtFechaFin.Value), cmbCargo.Value, cmbClase.Value, 2).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False

                'reporte.SetParameterValue("pDesPer", txtSolicitante.Text)
                reporte.SetParameterValue("pFecInicio", CDate(txtFechaInicio.Value))
                reporte.SetParameterValue("pFecFinal", CDate(txtFechaFin.Value))
                reporte.SetParameterValue("pClaseCargo", IIf(cmbClase.Text = "(Todos)", "(Todos)", cmbClase.Text))
                reporte.SetParameterValue("pCargo", IIf(cmbCargo.Text = "(Todos)", "(Todos)", cmbCargo.Text))

                forma.Text = "Reporte de Horas Muertas"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub MostrarReporteAgrupadoxJob()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptHorasMuertasAgrupadoxJob

            dtReporte = oMarcacionJobService.ReporteHoraMuerta(Session.sCodEmp, utils.toBlank(txtFechaInicio.Value), utils.toBlank(txtFechaFin.Value), cmbCargo.Value, cmbClase.Value, 3).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False

                'reporte.SetParameterValue("pDesPer", txtSolicitante.Text)
                reporte.SetParameterValue("pFecInicio", CDate(txtFechaInicio.Value))
                reporte.SetParameterValue("pFecFinal", CDate(txtFechaFin.Value))
                reporte.SetParameterValue("pClaseCargo", IIf(cmbClase.Text = "(Todos)", "(Todos)", cmbClase.Text))
                reporte.SetParameterValue("pCargo", IIf(cmbCargo.Text = "(Todos)", "(Todos)", cmbCargo.Text))

                forma.Text = "Reporte de Horas Muertas"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(237, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If rbDetallado.Checked Then
            MostrarReporteDetallado()
        ElseIf rbResumido.Checked Then
            MostrarReporteResumido()
        ElseIf rbAgrupadoxJob.Checked Then
            MostrarReporteAgrupadoxJob()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbClase_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClase.ValueChanged
        LlenarCargos()
    End Sub

    Private Sub LlenarCargos()
        Try
            '======================================= CARGO =============================================
            If cmbClase.SelectedIndex <> 0 Then
                dtCargo = oPersonaService.MostrarCargos(Session.sCodEmp, IIf(cmbClase.Value = "", "", cmbClase.Value)).Tables(0)
                dtCargo.Rows.InsertAt(getRowTodos(dtCargo), 0)
                cmbCargo.DataSource = dtCargo
                cmbCargo.DropDownList.DataMember = dtCargo.Columns("DesCargo").ToString
                cmbCargo.DropDownList.DisplayMember = dtCargo.Columns("DesCargo").ToString
                cmbCargo.DropDownList.ValueMember = dtCargo.Columns("CodCargo").ToString
                cmbCargo.DropDownList.Columns(0).DataMember = dtCargo.Columns("CodCargo").ToString
                cmbCargo.DropDownList.Columns(1).DataMember = dtCargo.Columns("DesCargo").ToString
                cmbCargo.SelectedIndex = 0
                dtCargo = Nothing
            Else
                dtCargo = oPersonaService.MostrarCargos(Session.sCodEmp, IIf(cmbClase.Value = "", "", cmbClase.Value)).Tables(0)
                dtCargo.Rows.InsertAt(getRowTodos(dtCargo), 0)
                cmbCargo.DataSource = dtCargo
                cmbCargo.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO SUBRUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class

