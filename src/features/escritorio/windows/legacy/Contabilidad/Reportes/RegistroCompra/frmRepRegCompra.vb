Imports System.ServiceModel
Public Class frmRepRegCompra

    '===========================Servicios====================================
    Private oRegistroCompraService As New RegistroCompraService.RegistroCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================   
    Private dtMonedas As DataTable
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtUnidades As DataTable
    Private dtCentroCosto As DataTable

    Private Sub frmRepRegCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oRegistroCompraService.Close()
            oMaestroService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oRegistroCompraService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oRegistroCompraService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepRegCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepRegCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 177)
        '/*************************************************************************************/

        txtFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFecFinal.Value = Date.Today
        llenarCombos()
        cmbMoneda.Value = "NS"
        txtFecInicio.Focus()
    End Sub

    'Private Function getRowTodos1(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception
    '        fila(0) = 0
    '    End Try
    '    Try
    '        fila(1) = "(Todos)"
    '    Catch ex As Exception
    '    End Try
    '    Try
    '        fila(2) = "(Todos)"
    '    Catch ex As Exception
    '    End Try
    '    Try
    '        fila(3) = "(Todos)"
    '    Catch ex As Exception
    '    End Try
    '    Try
    '        fila(4) = "(Todos)"
    '    Catch ex As Exception
    '    End Try
    '    Return fila
    'End Function

    Private Sub llenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            'dtMonedas.Rows.InsertAt(getRowTodos1(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 0
            dtMonedas = Nothing


            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos1(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos1(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '==================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos1(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            dtCentroCosto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos1(ByVal data As DataTable)
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

    Private Function ValidarCampos() As Boolean
        If txtFecInicio.Value > txtFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            txtFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarCampos() Then
            oSeguridadService.RegistrarVisitaOpciones(177, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            MostrarReporte()
        End If
    End Sub

    Private Sub MostrarReporte()
        Try
            'dtDatos = oRegistroCompraService.ReporteRegistroCompra(Session.sCodEmp, txtFecInicio.Value, txtFecFinal.Value, cmbMoneda.Value, "", 1).Tables(0)
            'DataGridView1.DataSource = dtDatos
            If rbConCeldas.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptRepRegCompra

                dtReporte = oRegistroCompraService.ReporteRegistroCompra(Session.sCodEmp, toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), txtFecInicio.Value, txtFecFinal.Value, cmbMoneda.Value, "", 1).Tables(0)

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
                    forma.Text = "Reporte de Registro de Compras"
                    reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                    reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                    reporte.SetParameterValue("pMoneda", IIf(cmbMoneda.Value = "NS", "EN NUEVOS SOLES", IIf(cmbMoneda.Value = "US", "EN DOLARES USA", "")))
                    reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                    reporte.SetParameterValue("pArea", cmbArea.Text)
                    reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                    forma.ShowDialog()
                End If

            ElseIf rbSinCeldas.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptRepRegCompraSinCeldas

                dtReporte = oRegistroCompraService.ReporteRegistroCompra(Session.sCodEmp, toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), txtFecInicio.Value, txtFecFinal.Value, cmbMoneda.Value, "", 1).Tables(0)

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
                    forma.Text = "Reporte de Registro de Compras"
                    reporte.SetParameterValue("pFecInicio", txtFecInicio.Value)
                    reporte.SetParameterValue("pFecFinal", txtFecFinal.Value)
                    reporte.SetParameterValue("pMoneda", IIf(cmbMoneda.Value = "NS", "EN NUEVOS SOLES", IIf(cmbMoneda.Value = "US", "EN DOLARES USA", "")))
                    reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                    reporte.SetParameterValue("pArea", cmbArea.Text)
                    reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                    forma.ShowDialog()
                End If
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtFecInicio.KeyPress _
                      , txtFecFinal.KeyPress _
                      , cmbArea.KeyPress _
                      , cmbCentroCosto.KeyPress _
                      , cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class