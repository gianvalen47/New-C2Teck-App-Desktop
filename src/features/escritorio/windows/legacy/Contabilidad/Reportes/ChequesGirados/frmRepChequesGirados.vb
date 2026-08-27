Imports System.ServiceModel
Public Class frmRepChequesGirados
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtCuentas As DataTable
    Private dtBancos As DataTable

    Private Sub frmRepChequesGirados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oTesoreriaService.Close()
            oMaestroService.Close()
            oPlanillaService.Close()
            oMovimientoBancosService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
            oMaestroService.Abort()
            oPlanillaService.Abort()
            oMovimientoBancosService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
            oMaestroService.Abort()
            oPlanillaService.Abort()
            oMovimientoBancosService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepChequesGirados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepChequesGirados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 268)
            '/*************************************************************************************/

            'Dim Mes, Anio As Integer
            'Dim Fecha As Date
            'Fecha = Today
            'Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
            'Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
            'cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
            'cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)

            '/*Se realiza el cambio de fechas  a pedido de Angélica 14/09/2017*/
            cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
            cbFecFinal.Value = Date.Today

            llenarCombos()
            cmbNumCuenta.Value = "191-0715400-0-62"
            cmbBanco.Value = "01"
            cbFecInicio.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try       

            '======================================= BANCOS =================================================
            dtBancos = oMovimientoBancosService.MostrarBancos.Tables(0)
            dtBancos.Rows.InsertAt(getRowTodos1(dtBancos), 0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            'cmbBanco.SelectedIndex = 0
            dtBancos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbBanco_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.ValueChanged

        Try

            '====================================== CUENTAS ===========================================
            dtCuentas = oPlanillaService.MostrarCuentas(cmbBanco.Value).Tables(0)

            If dtCuentas.Rows.Count > 1 Or cmbBanco.Value = "" Or dtCuentas.Rows.Count = 0 Then
                dtCuentas.Rows.InsertAt(getRowTodos1(dtCuentas), 0)
            End If
            cmbNumCuenta.DataSource = dtCuentas
            cmbNumCuenta.DropDownList.DataMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.DisplayMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.ValueMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.Columns(0).DataMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.Columns(1).DataMember = dtCuentas.Columns("CodMon").ToString
            cmbNumCuenta.SelectedIndex = 0
            dtCuentas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR LOS NUMEROS DE CUENTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Function getRowTodos1(ByVal data As DataTable)
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
        oSeguridadService.RegistrarVisitaOpciones(268, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MostrarReporte()
        Try
            If validarCampos() Then
                Dim dtReporte As New DataTable
                Dim Reporte As New rpRepChequesGirados
                Dim forma As New frmReportes
                Dim Banco As String = IIf(cmbBanco.SelectedIndex = 0, "", cmbBanco.Value)
                Dim NumCta As String = IIf(cmbNumCuenta.Text = "(Todos)", "", cmbNumCuenta.Text)
                dtReporte = oTesoreriaService.ReporteChequesGirados(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, Banco, NumCta).Tables(0)
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
                    forma.crvReportes.DisplayGroupTree = False
                    Reporte.SetParameterValue("pFecInicio", cbFecInicio.Value)                    
                    Reporte.SetParameterValue("pFecFinal", cbFecFinal.Value)
                    forma.Text = "Reporte Cheques Girados"

                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
End Class