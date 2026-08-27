Imports System.ServiceModel
Public Class frmRepCronogramaMina
    '===========================Servicios====================================================
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public IdPersona As Integer
    Private dtTipo As DataTable
    Private dtUbicacion As DataTable

    Private Sub frmRepCronogramaMina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionHorarioService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oAsignacionHorarioService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oAsignacionHorarioService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepCronogramaMina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepFaltasPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 297)
        '/*************************************************************************************/

        txtFechaInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFechaFinal.Value = Today
        llenarCombos()
        chkColaborador.Enabled = False
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                      txtFechaInicio.KeyPress _
                                    , txtFechaFinal.KeyPress _
                                    , txtColaborador.KeyPress _
                                    , cmbUbicacion.KeyPress _
                                    , cmbTipo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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
            '===================================== UBICACIÓN ===============================================
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

            '======================================== TIPO ================================================
            dtTipo = oAsignacionHorarioService.MostrarTipoCronograma().Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
        Else
            chkColaborador.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo                    
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtFechaInicio.Value > txtFechaFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor a la fecha final.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If ValidaCampos() Then

                Dim forma As New frmReportes
                Dim dtReporte As New DataTable

                If rbAgrupPersona.Checked = True Then

                    Dim reporte As New rpCronogramaMina_Persona
                    dtReporte = oAsignacionHorarioService.ReporteCronograma(Session.sCodEmp, txtFechaInicio.Value, txtFechaFinal.Value, _
                                                                                                        IdPersona, toBlank(cmbUbicacion.Value), toNumber(cmbTipo.Value)).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Cronograma de Minas agrupado por Colaborador"
                        reporte.SetParameterValue("pFecInicio", txtFechaInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFechaFinal.Value)
                        reporte.SetParameterValue("pUbicacion", cmbUbicacion.Text)
                        reporte.SetParameterValue("pTipo", cmbTipo.Text)
                        forma.ShowDialog()
                    End If

                ElseIf rbAgrupFecha.Checked = True Then

                    Dim reporte As New rpCronogramaMina_Fecha
                    dtReporte = oAsignacionHorarioService.ReporteCronograma(Session.sCodEmp, txtFechaInicio.Value, txtFechaFinal.Value, _
                                                                                                        IdPersona, toBlank(cmbUbicacion.Value), toNumber(cmbTipo.Value)).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        forma.crvReportes.DisplayGroupTree = False
                        forma.Text = "Reporte de Cronograma de Minas agrupado por Fecha"
                        reporte.SetParameterValue("pFecInicio", txtFechaInicio.Value)
                        reporte.SetParameterValue("pFecFinal", txtFechaFinal.Value)
                        reporte.SetParameterValue("pUbicacion", cmbUbicacion.Text)
                        reporte.SetParameterValue("pTipo", cmbTipo.Text)
                        forma.ShowDialog()
                    End If

                End If

               

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

End Class