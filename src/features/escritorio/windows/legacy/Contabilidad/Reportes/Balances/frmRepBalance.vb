Imports System.ServiceModel
Public Class frmRepBalance

    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtMonedas As DataTable
    Private dtMeses As DataTable
    Private dtUnidades As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable
    Private dtNivel As DataTable
    Private Opcion As Integer

    Private Sub frmRepBalance_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oContabilidadService.Close()
            oMaestroService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepBalance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 190)
            '/*************************************************************************************/

            Dim Mes, Anio As Integer
            Dim Fecha As Date
            Fecha = Today
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
            llenarCombos()
            cmbMoneda.Value = "NS"
            cmbMes.Value = Mes
            cmbNivel.SelectedIndex = 0
            txtAnio.Value = Anio
            txtAnio.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

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

            '================================= NIVEL =========================================
            dtNivel = New DataTable
            dtNivel.Columns.Add(New DataColumn("codniv", Type.GetType("System.String")))
            dtNivel.Columns.Add(New DataColumn("desniv", Type.GetType("System.String")))
            dtNivel.Rows.Add(New Object() {"1", "Nivel 1"})
            dtNivel.Rows.Add(New Object() {"2", "Nivel 2"})
            dtNivel.Rows.Add(New Object() {"3", "Nivel 3"})

            cmbNivel.DataSource = dtNivel
            cmbNivel.DropDownList.DataMember = dtNivel.Columns("desniv").ToString
            cmbNivel.DropDownList.DisplayMember = dtNivel.Columns("desniv").ToString
            cmbNivel.DropDownList.ValueMember = dtNivel.Columns("codniv").ToString
            cmbNivel.DropDownList.Columns(0).DataMember = dtNivel.Columns("codniv").ToString
            cmbNivel.DropDownList.Columns(1).DataMember = dtNivel.Columns("desniv").ToString
            dtNivel = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub MostrarReporte()
        Try
            Dim dtReporte As New DataTable
            Dim Reporte1 As New rpRepBalanceGeneral
            Dim Reporte2 As New rpRepGpxFuncion
            Dim Reporte3 As New rpRepGpxNaturaleza
            Dim Reporte4 As New rpRepHojaTrabajo
            Dim forma As New frmReportes
            Dim Mes As String = ""

            Mes = IIf(cmbMes.Value < 10, "0" + cmbMes.Value, cmbMes.Value)

            dtReporte = oContabilidadService.ReporteBalances(Session.sCodEmp, toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), txtAnio.Value, Mes, cmbMoneda.Value, utils.toNumber(cmbNivel.Value), Opcion).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If Opcion = 1 Then
                    Reporte1.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = Reporte1
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    Reporte1.SetParameterValue("Paginacion", IIf(cbPaginacion.Checked = True, "CP", "SP"))
                    Reporte1.SetParameterValue("DesMes", cmbMes.Text)
                    Reporte1.SetParameterValue("Anio", txtAnio.Value)
                    Reporte1.SetParameterValue("pUnidad", cmbUnidad.Text)
                    Reporte1.SetParameterValue("pArea", cmbArea.Text)
                    Reporte1.SetParameterValue("pCentro", cmbCentroCosto.Text)

                    forma.Text = "Reporte Balance General"
                ElseIf Opcion = 2 Then
                    Reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = Reporte2
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    Reporte2.SetParameterValue("Paginacion", IIf(cbPaginacion.Checked = True, "CP", "SP"))
                    Reporte2.SetParameterValue("DesMes", cmbMes.Text)
                    Reporte2.SetParameterValue("Anio", txtAnio.Value)
                    Reporte2.SetParameterValue("pUnidad", cmbUnidad.Text)
                    Reporte2.SetParameterValue("pArea", cmbArea.Text)
                    Reporte2.SetParameterValue("pCentro", cmbCentroCosto.Text)

                    forma.Text = "Reporte GG. PP. Funcion"
                ElseIf Opcion = 3 Then
                    Reporte3.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = Reporte3
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    Reporte3.SetParameterValue("Paginacion", IIf(cbPaginacion.Checked = True, "CP", "SP"))
                    Reporte3.SetParameterValue("DesMes", cmbMes.Text)
                    Reporte3.SetParameterValue("Anio", txtAnio.Value)
                    Reporte3.SetParameterValue("pUnidad", cmbUnidad.Text)
                    Reporte3.SetParameterValue("pArea", cmbArea.Text)
                    Reporte3.SetParameterValue("pCentro", cmbCentroCosto.Text)

                    forma.Text = "Reporte GG. PP. Naturaleza"
                ElseIf Opcion = 4 Then
                    Reporte4.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = Reporte4
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    Reporte4.SetParameterValue("Paginacion", IIf(cbPaginacion.Checked = True, "CP", "SP"))
                    Reporte4.SetParameterValue("DesMes", cmbMes.Text)
                    Reporte4.SetParameterValue("Anio", txtAnio.Value)
                    Reporte4.SetParameterValue("pUnidad", cmbUnidad.Text)
                    Reporte4.SetParameterValue("pArea", cmbArea.Text)
                    Reporte4.SetParameterValue("pCentro", cmbCentroCosto.Text)

                    forma.Text = "Reporte Hoja de Trabajo"
                End If

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(190, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub rbBalanceGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBalanceGeneral.CheckedChanged, rbGpFuncion.CheckedChanged, rbGpNaturaleza.CheckedChanged, rbHojaTrabajo.CheckedChanged
        If rbBalanceGeneral.Checked Then
            Opcion = 1
        ElseIf rbGpFuncion.Checked Then
            Opcion = 2
        ElseIf rbGpNaturaleza.Checked Then
            Opcion = 3
        ElseIf rbHojaTrabajo.Checked Then
            Opcion = 4
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtAnio.KeyPress _
                      , cmbMes.KeyPress _
                      , cmbMoneda.KeyPress _
                      , cmbUnidad.KeyPress _
                      , cmbArea.KeyPress _
                      , cmbCentroCosto.KeyPress _
                      , rbBalanceGeneral.KeyPress _
                      , rbGpFuncion.KeyPress _
                      , rbGpNaturaleza.KeyPress _
                      , rbHojaTrabajo.KeyPress _
                      , cbPaginacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class