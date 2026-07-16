Imports System.ServiceModel

Public Class frmRepClientes

    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient


    Private dtEstados As DataTable
    Private dtTiposContribuyentes As DataTable
    Private dtTiposClientes As DataTable


    Private Sub frmRepClientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oClienteService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oClienteService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oClienteService.Abort()
            oClienteService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          cmbIdTipoCon.KeyPress _
                        , cmbIdTipoCliente.KeyPress _
                        , cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub frmRepClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, )
        '/*************************************************************************************/

        llenarCombos()

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= TIPOS DE CONTRIBUYENTES =======================================
            dtTiposContribuyentes = oMaestroService.MostrarTipoContribuyente.Tables(0)
            dtTiposContribuyentes.Rows.InsertAt(getRowTodos(dtTiposContribuyentes), 0)
            cmbIdTipoCon.DataSource = dtTiposContribuyentes
            cmbIdTipoCon.DropDownList.DataMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.DropDownList.DisplayMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.DropDownList.ValueMember = dtTiposContribuyentes.Columns("IdTipoCon").ToString
            cmbIdTipoCon.DropDownList.Columns(0).DataMember = dtTiposContribuyentes.Columns("IdTipoCon").ToString
            cmbIdTipoCon.DropDownList.Columns(1).DataMember = dtTiposContribuyentes.Columns("DesTipo").ToString
            cmbIdTipoCon.SelectedIndex = 0
            dtTiposContribuyentes = Nothing

            '======================================= TIPOS DE CLIENTES =========================================
            dtTiposClientes = oMaestroService.MostrarTipoCliente.Tables(0)
            dtTiposClientes.Rows.InsertAt(getRowTodos(dtTiposClientes), 0)
            cmbIdTipoCliente.DataSource = dtTiposClientes
            cmbIdTipoCliente.DropDownList.DataMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.DropDownList.DisplayMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.DropDownList.ValueMember = dtTiposClientes.Columns("IdTipoCliente").ToString
            cmbIdTipoCliente.DropDownList.Columns(0).DataMember = dtTiposClientes.Columns("IdTipoCliente").ToString
            cmbIdTipoCliente.DropDownList.Columns(1).DataMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.SelectedIndex = 0
            dtTiposClientes = Nothing

            '======================================= ESTADOS DEL CLIENTE =========================================
            dtEstados = oClienteService.MostrarEstados.Tables(0)
            'dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpClienteLimiteCredito

            dtReporte = oClienteService.ReporteClienteCredito(Session.sCodEmp, toNumber(cmbIdTipoCon.Value), toNumber(cmbIdTipoCliente.Value), toBlank(cmbEstado.Value)).Tables(0)

            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)

                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)

                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If

                    forma.Text = "Reporte de Clientes con Limite de Crédito"
                    reporte.SetParameterValue("pDesTipo", toBlank(cmbIdTipoCon.Text))
                    reporte.SetParameterValue("pDesTipoCli", toBlank(cmbIdTipoCliente.Text))
                    reporte.SetParameterValue("pDesEstado", toBlank(cmbEstado.Text))
                    forma.ShowDialog()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'oSeguridadService.RegistrarVisitaOpciones(32, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class