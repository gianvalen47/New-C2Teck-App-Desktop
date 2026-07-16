Imports System.ServiceModel

Public Class frmRepMotorDarBajaR

    '=========================== Servicios ====================================
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtUbicacion As DataTable
    Private dtDatos As DataTable

    Private Sub frmRepMotorDarBajaR_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHorasMotorService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oHorasMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepMotorDarBajaR_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepMotorDarBajaR_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 253)
        '/*************************************************************************************/

        llenarCombos()
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


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



    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptMotorDarBaja

            oSeguridadService.RegistrarVisitaOpciones(253, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)


            dtReporte = oHorasMotorService.ReporteMotoresDarBaja(Session.sCodEmp, toBlank(cmbUbicacion.Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False

                'If txtSolicitante.Text = "" Then
                '    txtSolicitante.Text = "Todos"
                'End If
                reporte.SetParameterValue("Ubicacion", cmbUbicacion.Text)
                'reporte.SetParameterValue("pFechaInicio", txtFechaInicio.Value)

                forma.Text = "Reporte de Horas Motor"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class