Imports System.ServiceModel

Public Class FrmRepConsignacion

    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable


    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas("").Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
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
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(6) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(7) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(8) = "(Todos)"
        Catch ex As Exception

        End Try


        Return fila
    End Function

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, "").Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbMercaderia.Checked = False
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window

        End If
        txtCodMer.Select()
    End Sub

    Private Sub rbMercaderia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMercaderia.CheckedChanged
        txtCodMer.Text = ""
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(200, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If validarData() Then
            MostrarReporte()
        End If
    End Sub

    Private Function validarData() As Boolean
        If cbFecInicio.Value > cbFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            cbFecInicio.Focus()
            Return False
        ElseIf cmbOficinas.SelectedIndex <> 0 And cmbIdLocacion.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar un Almacen")
            cmbIdLocacion.Focus()
            Return False
            'End If
        Else
            Return True
        End If
    End Function

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepConsignacion

            'oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
            dtReporte = oReporteVentaService.ReporteRegistroConsignaciones(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbIdLocacion.Value), txtCodMer.Text).Tables(0)
            'DataGridView1.DataSource = dtReporte

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

                forma.Text = "Reporte de Ventas Detalle"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Paginacion", IIf(cbPaginacion.Checked = True, "CP", "SP"))

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged
        If txtCodMer.Text <> "" Then
            rbMercaderia.Checked = False
        End If
    End Sub

    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarMercaderia.Select()
        End If

    End Sub

    Private Sub FrmRepConsignacion_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub FrmRepConsignacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 200)
        '/*************************************************************************************/

        cbFecInicio.Value = "01/" & Today.Month & "/" & Today.Year
        cbFecFinal.Value = Today.Date
        cbPaginacion.Checked = True
        llenarCombos()
    End Sub

    Private Sub frmRepVentaConsignacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cbFecInicio.KeyPress _
                    , cbFecFinal.KeyPress _
                    , cmbIdLocacion.KeyPress _
                    , cmbOficinas.KeyPress
        ', cmbVendedor.KeyPress
        ', txtCliente.KeyPress _
        ', txtCodMer.KeyPress _
        ', rbCliente.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


End Class