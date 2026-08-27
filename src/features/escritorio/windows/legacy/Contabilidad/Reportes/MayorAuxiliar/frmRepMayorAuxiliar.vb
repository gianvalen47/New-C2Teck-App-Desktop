Imports System.ServiceModel
Public Class frmRepMayorAuxiliar

    '=========================== Servicios ===================================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Private dtMonedas As DataTable
    Private dtUnidades As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable

    Private Sub frmRepMayorAuxiliar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
            oMaestroService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
            oCuentaContableService.close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepMayorAuxiliar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepLibroMayor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 241)
            '/*************************************************************************************/

            Dim Mes, Anio As Integer
            Dim Fecha As Date
            Fecha = Today
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
            txtFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
            txtFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
            llenarCombos()
            cmbMoneda.Value = "NS"
            txtFecInicio.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing


            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
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
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR AREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '==================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
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

    Private Function ValidarCampos() As Boolean
        If txtFecInicio.Value > txtFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            txtFecInicio.Focus()
            Return False
        ElseIf Year(txtFecInicio.Value) <> Year(txtFecFinal.Value) Then
            MsgBox("Los años del rango de fechas deben coincidir, Verificar... ")
            txtFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarCampos() Then
            oSeguridadService.RegistrarVisitaOpciones(241, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            MostrarReporte()
        End If
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim dtReporte As New DataTable
            Dim forma As New frmReportes
            Dim reporte As New rptRepMayorAuxiliar

            oContabilidadService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
            dtReporte = oContabilidadService.ReporteMayorAuxiliar(Session.sCodEmp, toNumber(cmbUnidad.Value), toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), txtFecInicio.Value, txtFecFinal.Value, cmbMoneda.Value, txtCuentaMayor.Text, txtDesde.Text, txtHasta.Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
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
                forma.Text = "Reporte de Mayor Auxiliar"
                reporte.SetParameterValue("pFechaInicio", txtFecInicio.Value)
                reporte.SetParameterValue("pFechaFin", txtFecFinal.Value)
                reporte.SetParameterValue("pMoneda", IIf(cmbMoneda.SelectedIndex = 0, "TODOS", IIf(cmbMoneda.Value = "NS", "EN NUEVOS SOLES", IIf(cmbMoneda.Value = "US", "EN DOLARES USA", ""))))
                reporte.SetParameterValue("pUnidad", cmbUnidad.Text)
                reporte.SetParameterValue("pArea", cmbArea.Text)
                reporte.SetParameterValue("pCentro", cmbCentroCosto.Text)
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub rbCuentaMayor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCuentaMayor.CheckedChanged
        If rbCuentaMayor.Checked = True Then
            txtCuentaMayor.ReadOnly = False
            txtCuentaMayor.BackColor = System.Drawing.SystemColors.Window

            txtDesde.ReadOnly = True
            txtDesde.BackColor = System.Drawing.SystemColors.Control
            txtDesde.Text = ""
            btnBuscarCuenta1.Enabled = False
            txtHasta.ReadOnly = True
            txtHasta.BackColor = System.Drawing.SystemColors.Control
            txtHasta.Text = ""
            btnBuscarCuenta2.Enabled = False
        Else            
            txtCuentaMayor.ReadOnly = True
            txtCuentaMayor.BackColor = System.Drawing.SystemColors.Control
            txtCuentaMayor.Text = ""

            txtDesde.ReadOnly = False
            txtDesde.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCuenta1.Enabled = True
            txtHasta.ReadOnly = False
            txtHasta.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCuenta2.Enabled = True
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtFecInicio.KeyPress _
                      , txtFecFinal.KeyPress _
                      , cmbArea.KeyPress _
                      , cmbCentroCosto.KeyPress _
                      , cmbMoneda.KeyPress _
                      , txtCuentaMayor.KeyPress _
                      , txtDesde.KeyPress _
                      , txtHasta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnBuscarCuenta1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta1.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtDesde.Text = frm.codigo
                    txtHasta.Text = txtDesde.Text
                    txtHasta.Focus()
                Else
                    txtDesde.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCuenta2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta2.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtHasta.Text = frm.codigo
                    btnAceptar.Focus()
                Else
                    txtHasta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta1.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta1_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtDesde.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtDesde.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtDesde.Text = ""
                    txtDesde.Focus()
                Else
                    txtHasta.Text = txtDesde.Text
                    txtHasta.Focus()
                End If
            Else
                txtHasta.Focus()
            End If
        End If
    End Sub

    Private Sub txtDesde_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesde.Validated
        If Len(Trim(txtDesde.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtDesde.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtDesde.Text = ""
                txtDesde.Focus()
            Else
                txtHasta.Text = txtDesde.Text
                txtHasta.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta2.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta2_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtHasta.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtHasta.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtHasta.Text = ""
                    txtHasta.Focus()
                Else
                    btnAceptar.Focus()
                End If
            Else
                btnAceptar.Focus()
            End If
        End If
    End Sub

    Private Sub txtHasta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHasta.Validated
        If Len(Trim(txtHasta.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtHasta.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtHasta.Text = ""
                txtHasta.Focus()
            Else
                btnAceptar.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub
End Class