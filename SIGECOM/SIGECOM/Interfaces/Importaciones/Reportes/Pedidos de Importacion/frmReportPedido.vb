Imports System.ServiceModel
Public Class frmReportPedido
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtProveedores As DataTable
    Dim IdPedido As Integer

    Private Sub frmReportPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 86)
        '/*************************************************************************************/

        llenarCombos()
        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        'cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
    End Sub

    Private Sub frmReportPedido_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oPedidoImportService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oPedidoImportService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
            oMaestroService.Abort()
            oPedidoImportService.Abort()

        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= PROVEEDORES ================================================
            dtProveedores = oPedidoImportService.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedores.Rows.InsertAt(getRowTodos(dtProveedores), 0)
            cmbProveedor.DataSource = dtProveedores
            cmbProveedor.DropDownList.DataMember = dtProveedores.Columns("DesProv").ToString
            cmbProveedor.DropDownList.DisplayMember = dtProveedores.Columns("DesProv").ToString
            cmbProveedor.DropDownList.ValueMember = dtProveedores.Columns("IdProveedor").ToString
            cmbProveedor.DropDownList.Columns(0).DataMember = dtProveedores.Columns("IdProveedor").ToString
            cmbProveedor.DropDownList.Columns(1).DataMember = dtProveedores.Columns("DesProv").ToString
            cmbProveedor.SelectedIndex = 0
            dtProveedores = Nothing
        Catch ex As Exception
            MsgBox("Error al cargar Combos", MsgBoxStyle.Exclamation)
        End Try
      
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            If toBlank(cmbOficinas.Value) <> "" Then
                '======================================= ALMACENES ================================================
                dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
                dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
                cmbIdLocacion.DataSource = dtAlmacenes
                cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
                cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
                cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
                cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
                cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
                If dtAlmacenes.Rows.Count > 0 Then
                    cmbIdLocacion.SelectedIndex = 0
                Else
                    cmbIdLocacion.Value = ""
                End If
                'dtAlmacenes = Nothing
            Else
                cmbIdLocacion.Value = ""
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar Combos", MsgBoxStyle.Exclamation)
        End Try
    
    End Sub
    Private Sub frmReportPedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(6) = "(Todos)"
        Catch ex As Exception

        End Try
        Return fila
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        oSeguridadService.RegistrarVisitaOpciones(86, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptReportePedidos
            Dim dtReporte As New DataTable

            If txtPedido.Text <> "" Then
                IdPedido = Convert.ToInt32(txtPedido.Text)
            End If

            dtReporte = oPedidoImportService.Reporte(cmbIdLocacion.Value, _
                                                     IIf(cmbProveedor.Text = "(Todos)", 0, cmbProveedor.Value), _
                                                     IIf(ckPedido.Checked = True, 0, IdPedido), _
                                                     IIf(ckCantPendientes.Checked = True, 0, 1), _
                                                     IIf(ckCantPendientes.Checked = False, cbFecFinal.Value, Today)).Tables(0)

            'MessageBox.Show("Locacion " & cmbIdLocacion.Value.ToString)
            'MessageBox.Show("Proveedor " & IIf(cmbProveedor.Text = "(Todos)", 0, cmbProveedor.Value).ToString)
            'MessageBox.Show("Pedido " & IIf(ckPedido.Checked = True, 0, IdPedido).ToString)
            'MessageBox.Show("Cantidad " & IIf(ckCantPendientes.Checked = True, 0, 1).ToString)
            'MessageBox.Show("Fecha " & IIf(ckCantPendientes.Checked = False, cbFecFinal.Value, Today).ToString)

            'dtReporte = oPedidoImportService.Reporte(1, 1, 1, 1, Today).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("Fecha", cbFecFinal.Value)
                forma.Text = "Reporte de Pedidos"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub ckPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckPedido.CheckedChanged
        If ckPedido.Checked = True Then
            txtPedido.Enabled = False
        End If
        If ckPedido.Checked = False Then
            txtPedido.Enabled = True
        End If
        txtPedido.Clear()
        IdPedido = 0
    End Sub

    Private Sub ckCantPendientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCantPendientes.CheckedChanged
        If ckCantPendientes.Checked = True Then
            cbFecFinal.Enabled = False
        End If
        If ckCantPendientes.Checked = False Then
            cbFecFinal.Enabled = True
        End If
    End Sub

End Class