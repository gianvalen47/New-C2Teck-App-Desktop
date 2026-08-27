Imports System.ServiceModel

Public Class frmRepVentaGuiasRemision

    Private oGuiasRemision As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    Private dtMotivo As DataTable
    Private dtEstado As DataTable
    Private dtMonedas As DataTable

    Private IdCliente As Integer

    Private Sub frmRepVentaGuiasRemision_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGuiasRemision.Close()
            oMaestro.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oGuiasRemision.Abort()
            oMaestro.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oGuiasRemision.Abort()
            oMaestro.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepVentaGuiasRemision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub frmRepVentaGuiasRemision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 199)
        '/*************************************************************************************/

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        txtCliente.Text = "(Todos)"
        LlenarCombos()
        cmbMoneda.Text = "(Todos)"

    End Sub

    Private Sub LlenarCombos()
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

            '======================================= Motivos ================================================
            dtMotivo = oMaestro.MostrarMotivos().Tables(0)
            'DataGridView1.DataSource = dtMotivo
            dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
            cmbMotivo.DataSource = dtMotivo
            'cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("DesMot").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("DesMot").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("CodMot").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("CodMot").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("DesMot").ToString
            cmbMotivo.SelectedIndex = 0
            dtMotivo = Nothing

            '======================================= Estados ================================================
            dtEstado = oGuiasRemision.MostrarEstados()
            dtEstado.Rows.InsertAt(getRowTodos(dtEstado), 0)
            cmbEstado.DataSource = dtEstado
            'cmbEstado.DropDownList.DataMember = dtEstado.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstado.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstado.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstado.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstado.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstado = Nothing

            '======================================= Monedas ===============================================
            dtMonedas = oMaestro.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

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

        Return fila
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            oSeguridadService.RegistrarVisitaOpciones(199, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If validarData() = True Then
                ReporteVentaGuias()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

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

    Private Sub ReporteVentaGuias()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepVentaGuiaRemision
            Dim Moneda As String

            If txtCliente.Text = "(Todos)" Then
                IdCliente = 0
            End If

            If IsDBNull(cmbIdLocacion.Value) = True Then
                cmbIdLocacion.Value = 0
                cmbIdLocacion.Text = "(Todos)"
            End If

            If cmbMoneda.Text = "(Todos)" Then
                Moneda = ""
            Else
                Moneda = cmbMoneda.Value
            End If

            dtReporte = oGuiasRemision.ReporteGuiasRemision(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbIdLocacion.Value), IdCliente, txtCodSerie.Text, cmbMotivo.Value, cmbEstado.Value, Moneda).Tables(0)
            'DataGridView1.DataSource = dtReporte
            'dtReporte = oSolicitudGarantia.ReporteSolicitudGarantia(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdCliente, cmbSupervisor.Value, cmbEstado.Value, cmbAplicacion.Value, cmbFabricante.Value, txtSerie.Text, txtCreditState.Text, 2).Tables(0)

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

                forma.Text = "Reporte de Guia de Remisión"
                'reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                'reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Cliente", IIf((txtCliente.Text = "(Todos)"), "(Todos)", txtCliente.Text))
                reporte.SetParameterValue("Oficina", IIf((cmbOficinas.Text = "(Todos)"), "(Todos)", cmbOficinas.Text))
                reporte.SetParameterValue("Almacen", IIf((cmbIdLocacion.Text = "(Todos)"), "(Todos)", cmbIdLocacion.Text))
                reporte.SetParameterValue("Moneda", IIf((cmbMoneda.Text = "(Todos)"), "(Todos)", cmbMoneda.Text))
                reporte.SetParameterValue("Motivo", IIf((cmbMotivo.Text = "(Todos)"), "(Todos)", cmbMotivo.Text))
                reporte.SetParameterValue("Estado", IIf((cmbEstado.Text = "(Todos)"), "(Todos)", cmbEstado.Text))
                reporte.SetParameterValue("SerieDoc", IIf((txtCodSerie.Text = ""), " -", txtCodSerie.Text))
                'reporte.SetParameterValue("NumClaim", IIf((txtNumClaim.Text = ""), " -", txtNumClaim.Text))
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
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
        Else
            Return True
        End If
    End Function

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                cmbMoneda.Select()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        Else
            chkCliente.Enabled = True
        End If
    End Sub

    Private Sub frmRepVentaGuiaRemision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    cbFecInicio.KeyPress _
                , cbFecFinal.KeyPress _
                , cmbIdLocacion.KeyPress _
                , cmbOficinas.KeyPress _
        , cmbMoneda.KeyPress _
        , txtCodSerie.KeyPress _
        , cmbEstado.KeyPress _
        , cmbMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

End Class