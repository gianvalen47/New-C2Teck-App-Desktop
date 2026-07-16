Imports System.ServiceModel

Public Class frmRepDisponibilidadMotores

    Private oMaestroService As New MaestroService.MaestroClient
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oMotorService As New MotorService.MotorServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtOficinas As DataTable
    Private dtModeloEquipo As DataTable
    Private dtDatos As DataTable
    Dim forma As New frmReportes

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ====================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '=================================== MODELO EQUIPO ========================================
            dtModeloEquipo = oMotorService.MostrarModeloEquipo(0).Tables(0)
            dtModeloEquipo.Rows.InsertAt(getRowTodos(dtModeloEquipo), 0)
            cmbModeloEquipo.DataSource = dtModeloEquipo
            cmbModeloEquipo.DropDownList.DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.DisplayMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.ValueMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.Columns(0).DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.Columns(1).DataMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
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

    Private Sub frmRepDisponibilidadMotores_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oHorasMotorService.Close()
            oMotorService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oHorasMotorService.Abort()
            oMotorService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oHorasMotorService.Abort()
            oMotorService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepDisponibilidadMotores_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepDisponibilidadMotores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 252)
        '/*************************************************************************************/

        llenarCombos()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(252, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If rbResumen.Checked = True Then                         '====================================================================== Resumido
            If rbDispOperativa.Checked Then
                Dim reporte As New rptDisponibilidadMotor
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 1, 1).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de Operatividad"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            ElseIf rbMTBF.Checked Then
                Dim reporte As New rptDisponibilidadMotorMTBF
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 1, 2).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de MTBF"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            ElseIf rbMTTR.Checked Then
                Dim reporte As New rptDisponibilidadMotorMTTR
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 1, 3).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de MTTR"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            ElseIf rbDispInherente.Checked Then
                Dim reporte As New rptDisponibilidadMotorInherente
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 1, 4).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de Disponibilidad"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            End If
        ElseIf rbDetallado.Checked = True Then                          '====================================================================== Detallado
            If rbDispOperativa.Checked Then
                Dim reporte As New rptDisponibilidadMotorDetallado
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 2, 1).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de Operatividad"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            ElseIf rbMTBF.Checked Then
                Dim reporte As New rptDisponibilidadMotorMTBFDetallado
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 2, 2).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de MTBF"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            ElseIf rbMTTR.Checked Then
                Dim reporte As New rptDisponibilidadMotorMTTRDetallado
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 2, 3).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de MTTR"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            ElseIf rbDispInherente.Checked Then
                Dim reporte As New rptDisponibilidadMotorInherenteDetallado
                dtDatos = oHorasMotorService.ReporteDisponibilidad(Session.sCodEmp, utils.toBlank(cmbOficinas.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtNomEquipo.Text), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbModeloEquipo.Text = "(Todos)", "", cmbModeloEquipo.Text), 2, 4).Tables(0)
                'DataGridView1.DataSource = dtDatos
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.Text = "Reporte de Disponibilidad"
                    reporte.SetParameterValue("DesOfi", cmbOficinas.Text)
                    reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                    reporte.SetParameterValue("NomEquipo", IIf(txtNomEquipo.Text = "", "(Todos)", txtNomEquipo.Text))
                    reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                    'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    forma.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class