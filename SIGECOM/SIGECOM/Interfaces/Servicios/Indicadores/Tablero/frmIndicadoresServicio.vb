Imports System.ServiceModel
Imports System.Globalization


Public Class frmIndicadoresServicio

    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtIndicadoresNivSer As DataTable
    Private dtIndicadoresMO As DataTable
    Dim dtTableNS As DataTable
    Dim dtTableMO As DataTable
    Dim dtReporteTipo As DataTable
    Dim dtAnios As DataTable
    Dim state As Boolean
    Dim row As DataRow
    Dim col As DataColumn


    Private Sub frmIndicadoresServicio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmIndicadoresServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIndicadoresServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 201)
        '/*************************************************************************************/

        state = False
        LlenarCombos()
        cmbAno.Value = Today.Year
        txtFecha.Text = Today
        state = True
        Buscar()
    End Sub

    Private Sub LlenarCombos()
        Try

            '-----------------------------Años-----------------------
            dtAnios = oJobService.MostrarAnios.Tables(0)
            cmbAno.DataSource = dtAnios
            cmbAno.DropDownList.DataMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.DisplayMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.ValueMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.Columns(0).DataMember = dtAnios.Columns("Anio").ToString
            cmbAno.DropDownList.Columns(1).DataMember = dtAnios.Columns("Anio").ToString
            cmbAno.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
    '    Try

    '        Dim fecha As DateTime = txtFecha.Value.Date
    '        txtSemana.Text = DatePart(DateInterval.WeekOfYear, Today.Date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
    '        txtMes.Text = Month(txtFecha.Text)
    '        txtAnio.Text = Year(txtFecha.Text)

    '        dtIndicadoresNivSer = oJobService.FiltrarIndicadoresServicios(Date.Today, 1).Tables(0)
    '        dgvDatosNivSer.DataSource = dtIndicadoresNivSer

    '        dtIndicadoresMO = oJobService.FiltrarIndicadoresServicios(Date.Today, 2).Tables(0)
    '        dgvDatosMO.DataSource = dtIndicadoresMO

    '    Catch ex As Exception
    '        MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub Buscar()
        Try
            Dim fecha As DateTime = txtFecha.Value.Date
            txtSemana.Text = DatePart(DateInterval.WeekOfYear, Today.Date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            txtMes.Text = Month(txtFecha.Text)
            txtAnio.Text = Year(txtFecha.Text)

            dtIndicadoresNivSer = oJobService.FiltrarIndicadoresServicios(Session.sCodEmp, cmbAno.Value, Date.Today, 1).Tables(0)
            'dgvDatosNivSer.DataSource = dtIndicadoresNivSer
            AgregarPorcentajeNivSer()

            dtIndicadoresMO = oJobService.FiltrarIndicadoresServicios(Session.sCodEmp, cmbAno.Value, Date.Today, 2).Tables(0)
            'dgvDatosMO.DataSource = dtIndicadoresMO
            AgregarPorcentajeMO()

        Catch ex As Exception
            MsgBox("Error al Filtrar los Indicadores:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub AgregarPorcentajeNivSer()

        dtTableNS = dtIndicadoresNivSer.Copy
        dtTableNS.Clear()

        For i = 0 To dtIndicadoresNivSer.Rows.Count - 1
            row = dtTableNS.NewRow

            For j = 0 To dtTableNS.Columns.Count - 1

                If j = 5 Or j = 6 Or j = 7 Or j = 13 Or j = 14 Then
                    row(j) = CStr(dtIndicadoresNivSer.Rows(i).Item(j) & " %")
                Else
                    row(j) = dtIndicadoresNivSer.Rows(i).Item(j)
                End If

            Next

            dtTableNS.Rows.Add(row)

        Next

        dgvDatosNivSer.DataSource = dtTableNS

    End Sub

    Private Sub AgregarPorcentajeMO()

        dtTableMO = dtIndicadoresMO.Copy
        dtTableMO.Clear()

        For i = 0 To dtIndicadoresMO.Rows.Count - 1
            row = dtTableMO.NewRow

            For j = 0 To dtTableMO.Columns.Count - 1

                If j = 5 Or j = 6 Or j = 7 Then
                    row(j) = CStr(dtIndicadoresMO.Rows(i).Item(j) & " %")
                Else
                    row(j) = dtIndicadoresMO.Rows(i).Item(j)
                End If

            Next

            dtTableMO.Rows.Add(row)

        Next

        dgvDatosMO.DataSource = dtTableMO


    End Sub


    'Public Function GetFirstDayOfWeek(ByVal currentDate As DateTime) As DateTime

    '    ' Referenciamos la cultura invariable.
    '    Dim ci As CultureInfo = CultureInfo.InvariantCulture
    '    ' Obtenemos el día de la semana correspondiente a la fecha actual.
    '    '
    '    Dim ds As DayOfWeek = ci.Calendar.GetDayOfWeek(currentDate)
    '    ' Como el primer día de la semana es el 0 (Domingo), construimos
    '    ' un array para conocer los días que hay que restar de la fecha.
    '    ' Así, si es Domingo (0) restaremos 6 días, si es Sábado (6)
    '    ' restaremos 5 días, y si es Lunes (1) restaremos 0 días.
    '    ' Recordar que en .NET los índices de los arrays están en base cero.

    '    Dim dias() As Integer = {6, 0, 1, 2, 3, 4, 5}
    '    ' De la fecha actual restamos los días correspondientes.

    '    Return currentDate.Subtract(New TimeSpan(dias(ds), 0, 0, 0))

    'End Function

    'Private Sub txtdiasig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiasig.Click
    '    txtFecha.Text = (CDate(DateAdd("d", 1, txtFecha.Text)))
    'End Sub

    'Private Sub txtdiaant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiaant.Click
    '    txtFecha.Text = (CDate(DateAdd("d", -1, txtFecha.Text)))
    'End Sub

    Private Sub BuscarNivSer()

        Try
            Dim fecha As DateTime = txtFecha.Value.Date
            txtSemana.Text = DatePart(DateInterval.WeekOfYear, Today.Date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            txtMes.Text = Month(txtFecha.Text)
            txtAnio.Text = Year(txtFecha.Text)

            dtIndicadoresNivSer = oJobService.FiltrarIndicadoresServicios(Session.sCodEmp, cmbAno.Value, Date.Today, 1).Tables(0)
            AgregarPorcentajeNivSer()
            'dgvDatosNivSer.DataSource = dtIndicadoresNivSer

        Catch ex As Exception
            MsgBox("Error al listar los indicadores de nivel servicio" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub BuscarMO()

        Try
            Dim fecha As DateTime = txtFecha.Value.Date
            txtSemana.Text = DatePart(DateInterval.WeekOfYear, Today.Date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            txtMes.Text = Month(txtFecha.Text)
            txtAnio.Text = Year(txtFecha.Text)

            dtIndicadoresMO = oJobService.FiltrarIndicadoresServicios(Session.sCodEmp, cmbAno.Value, Date.Today, 2).Tables(0)
            AgregarPorcentajeMO()
            'dgvDatosMO.DataSource = dtIndicadoresMO

                Catch ex As Exception
            MsgBox("Error al listar los indicadores de nivel servicio" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatosNivSer_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosNivSer.ColumnButtonClick

        Try
            Dim DiasProyectados As String

            'dtReporteTipo = oJobService.ReporteIndicadores(Session.sCodEmp, Date.Today, Date.Today, 0, 0, "", 4, dgvDatosNivSer.CurrentRow.Cells("IdProgramacion").Value, 0).Tables(0)
            'dgvTipo4.DataSource = dtReporteTipo

            'DiasProyectados = dgvTipo4.Rows(0).Cells("DiasProyectados").Value()
            DiasProyectados = dgvDatosNivSer.CurrentRow.Cells("DiasProye").Value

            If dgvDatosNivSer.CurrentRow.Cells("IdProgramacion").Value = 0 Then

            ElseIf DiasProyectados = 0 Then
                MsgBox("Aun no existen datos para este Job.", MsgBoxStyle.Information)
            Else
                If e.Column.Key = "Grafica" Then
                    Dim frm As New frmIndicadoresServicio_Grafica11
                    Dim fechaLunes As DateTime = Date.Today

                    frm.Fecha = fechaLunes
                    frm.FechaEscogida = Date.Today

                    frm.IdProgramacion = dgvDatosNivSer.CurrentRow.Cells("IdProgramacion").Value
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dgvDatosMO_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosMO.ColumnButtonClick

        Try
            If dgvDatosNivSer.CurrentRow.Cells("IdProgramacion").Value = 0 Then

            Else
                If e.Column.Key = "Grafica" Then
                    Dim frm As New frmIndicadoresServicio_Grafica21
                    Dim fechaLunes As DateTime = Date.Today

                    frm.Fecha = fechaLunes
                    frm.FechaEscogida = Date.Today

                    frm.IdProgramacion = dgvDatosMO.CurrentRow.Cells("IdProgramacion").Value
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnActualizarNivSer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarNivSer.Click, cmbAno.ValueChanged
        If state Then
            BuscarNivSer()
        End If
    End Sub

    Private Sub btnActualizarMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarMO.Click, cmbAno.ValueChanged
        If state Then
            BuscarMO()
        End If
    End Sub

    Private Sub btnAtrasoConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtrasoConsolidado.Click
        Dim frm As New frmIndicadoresServicio_Atraso
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

        End If
    End Sub


End Class