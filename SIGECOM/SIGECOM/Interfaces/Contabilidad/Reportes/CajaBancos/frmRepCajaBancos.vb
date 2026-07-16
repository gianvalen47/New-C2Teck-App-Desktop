Imports System.ServiceModel

Public Class frmRepCajaBancos

    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtMonedas As DataTable
    Private dtCuentaBancos As DataTable
    Private dtBancos As DataTable
    Private dtUnidades As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable

    Private Sub frmRepCajaBancos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oTesoreriaService.Close()
            oMaestroService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepCajaBancos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCajaBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 191)
            '/*************************************************************************************/

            Dim Mes, Anio As Integer
            Dim Fecha As Date
            Fecha = Today
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
            cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
            cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
            llenarCombos()
            cmbMoneda.Value = "NS"
            cmbCuentaBanco.Value = "191-0715400-0-62"
            cmbBanco.Value = "01"
            cbFecInicio.Focus()
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


            '====================================CUENTA BANCOS ============================================
            dtCuentaBancos = oTesoreriaService.MostrarCuentaBancos(Session.sCodEmp).Tables(0)

            cmbCuentaBanco.DataSource = dtCuentaBancos
            cmbCuentaBanco.DropDownList.DataMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.DisplayMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.ValueMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.Columns(0).DataMember = dtCuentaBancos.Columns("NumCta").ToString
            cmbCuentaBanco.DropDownList.Columns(1).DataMember = dtCuentaBancos.Columns("DesBan").ToString
            cmbCuentaBanco.DropDownList.Columns(2).DataMember = dtCuentaBancos.Columns("CodMon").ToString
            cmbCuentaBanco.DropDownList.Columns(3).DataMember = dtCuentaBancos.Columns("CodBan").ToString
            cmbCuentaBanco.DropDownList.Columns(4).DataMember = dtCuentaBancos.Columns("CodCuenta").ToString
            'cmbCuentaBanco.SelectedIndex = 1
            dtCuentaBancos = Nothing

            '======================================= BANCOS =================================================
            dtBancos = oMaestroService.MostrarBancos.Tables(0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            'cmbBanco.SelectedIndex = 0
            dtBancos = Nothing

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

    Private Sub MostrarReporte()
        Try
            Dim dtReporte As New DataTable
            Dim Reporte As New rpRepCajaBancos
            Dim forma As New frmReportes

            dtReporte = oTesoreriaService.ReporteLibroCajaBancos(Session.sCodEmp, toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), cbFecInicio.Value, cbFecFinal.Value, cmbBanco.Value, cmbCuentaBanco.Value, cmbMoneda.Value).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                Reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = Reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False
                Reporte.SetParameterValue("Paginacion", IIf(cbPaginacion.Checked = True, "CP", "SP"))
                Reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                Reporte.SetParameterValue("pArea", cmbArea.Text)
                Reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                forma.Text = "Reporte Libro Caja y Bancos"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
     
    Private Function validarCampos() As Boolean
        Try
            If cbFecInicio.Value > cbFecFinal.Value Then
                MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
                cbFecInicio.Focus()
                Return False
            ElseIf Year(cbFecInicio.Value) <> Year(cbFecInicio.Value) Then
                MsgBox("Los años del rango de fechas deben coincidir, Verificar... ")
                cbFecInicio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(191, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cbFecInicio.KeyPress _
                      , cbFecFinal.KeyPress _
                      , cmbMoneda.KeyPress _
                      , cmbUnidad.KeyPress _
                      , cmbArea.KeyPress _
                      , cmbCentroCosto.KeyPress _
                      , cmbBanco.KeyPress _
                      , cmbCuentaBanco.KeyPress _
                      , cbPaginacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
