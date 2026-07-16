Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmIndicadoresVenta

    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCierreService As New CierreMesService.CierreMesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim dtDatos As DataTable
    Dim dtMeses As DataTable
    Dim dtReporte As DataTable
    Dim dtReporte2 As DataTable
    Dim dtAnual As DataTable
    Dim forma As New frmReportes
    Dim mifecha As Date
    Dim sw As Integer

    Private FechaMensual As Date
    Private FechaDiaria As Date
    Private lLog As Boolean = True

    Private Sub frmIndicadoresVenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReporteVentaService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oReporteVentaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oReporteVentaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 169)
        '/*************************************************************************************/

        With txtFechaMensual
            .Format = DateTimePickerFormat.Custom
            .CustomFormat = "MM-yyyy"
        End With

        txtFechaMensual.Text = Session.sFecha
        txtFechaDiaria.Text = Session.sFecha

        'FechaMensual = (CDate(DateAdd("M", -1, txtFechaMensual.Text)))
        'FechaDiaria = (CDate(DateAdd("M", -1, txtFechaDiaria.Text)))

        'ActualizarSemana()
        'txtSemana.Text = DateDiff(DateInterval.WeekOfYear, New DateTime(txtFecha.Value.Year, 1, 1), txtFecha.Value)
        'txtSemana.Text = DatePart(DateInterval.WeekOfYear, txtFecha.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) 'CStr(DatePart("ww", txtFecha.Value))
        'txtMes.Text = Month(txtFecha.Text)
        'txtAnio.Text = Year(txtFecha.Text)
        'txtMesAnt.Text = Month(txtFecha.Text) - 1

        'ListarDatosAnual()
        'ListarDatosMensual()
        'CierreMesService()

        While lLog
            If oCierreService.Buscar(Session.sCodEmp, Year(txtFechaMensual.Text), Month(txtFechaMensual.Text), 1) = False Then
                'MsgBox("Este Mes todavia no se ha cerrado", MsgBoxStyle.Exclamation)
                txtFechaMensual.Text = (CDate(DateAdd("M", -1, txtFechaMensual.Text)))
                lLog = True
            Else
                lLog = False
            End If

        End While
        oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
        dtMeses = oReporteVentaService.FiltrarIndicadoresComercialMensual(Session.sCodEmp, txtFechaDiaria.Text).Tables(0)
        dtMeses.Rows(6).Delete()
        dgvDatosDiario.DataSource = dtMeses

        oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
        dtAnual = oReporteVentaService.FiltrarIndicadoresComercialAnual(Session.sCodEmp, txtFechaMensual.Text).Tables(0)
        dtAnual.Rows(6).Delete()
        dgvDatosMensual.DataSource = dtAnual

    End Sub

    Function PrimerDiaDelMes(ByVal dtmFecha As Date) As Date
        PrimerDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha), 1)
    End Function

    Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

    Private Sub ListarDatosMensual()
        Try
            'If oCierreService.Buscar(Session.sCodEmp, Year(FechaDiaria), Month(txtFechaDiaria.Text), 1) = False Then
            '    'MsgBox("Este Mes todavia no se ha cerrado", MsgBoxStyle.Exclamation)
            '    'txtFechaMensual = (CDate(DateAdd("M", -1, FechaMensual)))

            'End If
            oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
            dtMeses = oReporteVentaService.FiltrarIndicadoresComercialMensual(Session.sCodEmp, txtFechaDiaria.Text).Tables(0)
            dtMeses.Rows(6).Delete()
            dgvDatosDiario.DataSource = dtMeses

        Catch ex As Exception
            MsgBox("Error al Listar los Datos Mensuales. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ListarDatosAnual()
        Try
            Dim i As Integer = 0
            lLog = True
            While lLog
                If oCierreService.Buscar(Session.sCodEmp, Year(txtFechaMensual.Text), Month(txtFechaMensual.Text), 1) = False Then
                    'MsgBox("Este Mes todavia no se ha cerrado", MsgBoxStyle.Exclamation)
                    txtFechaMensual.Text = (CDate(DateAdd("M", -1, txtFechaMensual.Text)))
                    lLog = True
                    i = i + 1
                Else
                    lLog = False
                End If

            End While

            If i > 0 Then
                MsgBox("Este mes todavia no se ha cerrado", MsgBoxStyle.Exclamation)
            Else
                oReporteVentaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                dtAnual = oReporteVentaService.FiltrarIndicadoresComercialAnual(Session.sCodEmp, txtFechaMensual.Text).Tables(0)
                dtAnual.Rows(6).Delete()
                dgvDatosMensual.DataSource = dtAnual
            End If


            'dtAnual = oReporteVentaService.FiltrarIndicadoresComercialAnual(Session.sCodEmp, txtFechaMensual.Text).Tables(0)
            'dtAnual.Rows(6).Delete()
            'dgvDatosMensual.DataSource = dtAnual

        Catch ex As Exception
            MsgBox("Error al Listar los Datos Anuales. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtdiaant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiaant.Click
        txtFechaMensual.Text = (CDate(DateAdd("d", -1, txtFechaMensual.Text)))
    End Sub

    Private Sub txtdiasig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiasig.Click
        txtFechaMensual.Text = (CDate(DateAdd("d", 1, txtFechaMensual.Text)))
    End Sub

    'Private Sub txtFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        ActualizarSemana()
    '        txtMes.Text = Month(txtFecha.Text)
    '        txtAnio.Text = Year(txtFecha.Text)
    '        txtMesAnt.Text = Month(txtFecha.Text) - 1
    '        ListarDatosAnual()
    '        ListarDatosMensual()
    '    End If
    'End Sub

    'Private Sub txtFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.Validated
    '    ActualizarSemana()
    '    txtMes.Text = Month(txtFecha.Text)
    '    txtAnio.Text = Year(txtFecha.Text)
    '    txtMesAnt.Text = Month(txtFecha.Text) - 1
    '    ListarDatosAnual()
    '    ListarDatosMensual()
    'End Sub

    'Private Sub ActualizarSemana()
    '    If (Mid(txtFecha.Text, 1, 2) >= 1 And Mid(txtFecha.Text, 1, 2) <= 7) Then
    '        txtSemana.Text = "1"
    '    ElseIf (Mid(txtFecha.Text, 1, 2) >= 8 And Mid(txtFecha.Text, 1, 2) <= 14) Then
    '        txtSemana.Text = "2"
    '    ElseIf (Mid(txtFecha.Text, 1, 2) >= 15 And Mid(txtFecha.Text, 1, 2) <= 21) Then
    '        txtSemana.Text = "3"
    '    ElseIf (Mid(txtFecha.Text, 1, 2) >= 22 And Mid(txtFecha.Text, 1, 2) <= 28) Then
    '        txtSemana.Text = "4"
    '    ElseIf (Mid(txtFecha.Text, 1, 2) >= 29 And Mid(txtFecha.Text, 1, 2) <= 31) Then
    '        txtSemana.Text = "5"
    '    End If
    'End Sub

    Private Sub dgvDatosMensual_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosMensual.ColumnButtonClick
        Try
            If e.Column.Key = "Grafica" Then
                Dim frm As New frmIndicadorGrafica
                frm.iFecha = txtFechaMensual.Value
                frm.iGrupo = dgvDatosMensual.CurrentRow.Cells("Item").Value
                frm.iTipo = "Mensual"
                frm.Semaforo = dgvDatosMensual.CurrentRow.Cells("Semaforo").Value
                frm.iPB = dgvDatosMensual.CurrentRow.Cells("PB").Value
                frm.iObjetivo = dgvDatosMensual.CurrentRow.Cells("Objetivo").Value
                frm.iTitulo = dgvDatosMensual.CurrentRow.Cells("Indicador").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatosDiario_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosDiario.ColumnButtonClick
        Try
            If e.Column.Key = "Grafica" Then
                Dim frm As New frmIndicadorGrafica
                frm.iFecha = txtFechaDiaria.Value
                frm.iGrupo = dgvDatosDiario.CurrentRow.Cells("Item").Value
                frm.iTipo = "Diaria"
                frm.Semaforo = dgvDatosDiario.CurrentRow.Cells("Semaforo").Value
                frm.iPB = dgvDatosDiario.CurrentRow.Cells("PB").Value
                frm.iObjetivo = dgvDatosDiario.CurrentRow.Cells("Objetivo").Value
                frm.iTitulo = dgvDatosDiario.CurrentRow.Cells("Indicador").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMensual.Click
        'ActualizarSemana()
        'txtMes.Text = Month(txtFechaMensual.Text)
        'txtAnio.Text = Year(txtFechaMensual.Text)
        'txtMesAnt.Text = Month(txtFechaMensual.Text) - 1
        ListarDatosAnual()
    End Sub

    Private Sub ActualizarSemana()
        txtSemana.Text = DatePart(DateInterval.WeekOfYear, txtFechaMensual.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) 'CStr(DatePart("ww", txtFecha.Value))
    End Sub

    Private Sub btnBuscarDiaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDiaria.Click
        ListarDatosMensual()
    End Sub

    Private Sub txtdiaantdia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiaantdia.Click
        txtFechaDiaria.Text = (CDate(DateAdd("d", -1, txtFechaDiaria.Text)))
    End Sub

    Private Sub txtdiasigdia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiasigdia.Click
        txtFechaDiaria.Text = (CDate(DateAdd("d", 1, txtFechaDiaria.Text)))
    End Sub


End Class