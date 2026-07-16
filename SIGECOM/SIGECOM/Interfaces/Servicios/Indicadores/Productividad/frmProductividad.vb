Imports System.Windows.Forms
Imports System.ServiceModel
Imports AxMSChart20Lib
Public Class frmProductividad

    '===========================Servicios====================================================
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Private dtGrafico As DataTable


    Private Sub frmProductividad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 245)
            '/*************************************************************************************/

            dgvDatos.BackgroundColor = Color.Beige
            dgvDatos.BackColor = Color.Beige
            dgvDatos.ForeColor = Color.MidnightBlue

            txtanio.Value = Today.Year
            ListarDatos()
            ChartMotivo.Visible = False
            ChartMotivo.Enabled = False
            btnProductividad.Visible = False
        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ListarDatos()
        MostrarGrafico()
    End Sub

    Private Sub ListarDatos()
        Try
            dtDatos = oJobService.ReporteIndicadores(Session.sCodEmp, CDate("01/01/" + utils.toBlank(txtanio.Value)), CDate("01/01/" + utils.toBlank(txtanio.Value)), 0, 0, "", 11, 0, 1).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("Error al Listar Datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarGrafico()
        Try
            'dtGrafico = oJobService.ReporteIndicadores(Session.sCodEmp, CDate("01/01/" + utils.toBlank(txtanio.Value)), CDate("01/01/" + utils.toBlank(txtanio.Value)), 0, 0, "", 11, 0, 2).Tables(0)
            'dgvGrafico.DataSource = dtGrafico

            If dtDatos.Rows.Count < 1 Then
                ChartMotivo.Visible = False
                btnProductividad.Visible = False
            Else
                ChartMotivo.Visible = True
                btnProductividad.Visible = True

                '-----------------------------------------------------Formato de Gráfico---------------------------------------------------------
                ChartMotivo.Visible = True
                ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = True
                ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = True
                ChartMotivo.Footnote.Location.Visible = False
                ChartMotivo.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
                ChartMotivo.Title.Text = "Indicador productividad - Sección Taller"
                '------------------------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------------------------------------Filas y Columnas del Gráfico--------------------------------------------------------------
                ChartMotivo.ColumnCount = dtDatos.Rows.Count - 4    'Se resta las filas que no son tipos de Jobs
                ChartMotivo.RowCount = dgvDatos.ColumnCount - 1     'Se resta la columna (Nombre) para tener la cantidad de meses

                Dim cont As Integer = 1
                For I = 0 To ChartMotivo.ColumnCount - 1
                    ChartMotivo.Plot.SeriesCollection(cont).LegendText = dgvDatos.Rows(I + 4).Cells("Nombre").Value  'Se aumenta 4 al numero de fila para ubicarnos en el primer tipo de job
                    cont = cont + 1
                Next
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                '---------------------------------------------------------------------------Datos de Gráfico---------------------------------------------------------------------------
                cont = 0
                For J = 0 To dgvDatos.ColumnCount - 2
                    cont = cont + 1
                    If cont > 0 Then
                        ChartMotivo.Row = cont
                        ChartMotivo.RowLabel = dgvDatos.Columns(cont).HeaderText
                        For I = 0 To dgvDatos.Rows.Count - 5
                            ChartMotivo.Column = I + 1
                            ChartMotivo.Data = IIf(dgvDatos(cont, I + 4).Value Is Nothing Or dgvDatos(cont, I + 4).Value.ToString = "" Or IsDBNull(dgvDatos(cont, I + 4).Value), 0, dgvDatos(cont, I + 4).Value)
                        Next
                    End If
                Next
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar Gráfico: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnProductividad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductividad.Click
        Try
            Dim frm As New frmProductividad_Meta
            frm.Fecha = CDate("01/01/" + utils.toBlank(txtanio.Value))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar Productividad: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '==============================Evento KeyDown==============================================
    Private Sub frmAsignacionesRecursos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAsignacionesRecursos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub btnPorColaborador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorColaborador.Click
        Try
            Dim frm As New frmProductividad_Persona
            'frm.Fecha = CDate("01/01/" + utils.toBlank(txtanio.Value))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar Productividad por Colaborador: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class