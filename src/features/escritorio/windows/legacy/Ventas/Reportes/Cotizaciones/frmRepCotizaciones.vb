Imports System.ServiceModel
Imports System.Net.Mail
Public Class frmRepCotizaciones

    Private oMaestro As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Dim IdCliente As String
    Dim dtOficinas As DataTable
    Dim dtVendedor As DataTable
    Dim dtAlmacenes As DataTable
    Dim dtEstados As DataTable
    Private dtMotivo As DataTable



    Private Sub frmRepCotizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oCotizacionService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oCotizacionService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oCotizacionService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepCotizaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ' fila(0) = 0
        End Try

        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try
        Return fila
    End Function

    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 1
        Catch ex As Exception

        End Try
        Try
            fila(1) = "ASIGNADO A OFICINA"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Sub frmRepCotizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 77)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        ' cmbVendedor.Value = "(Todos)"
        llenarCombos()
        llenarCombosRechazo()
        cbFecInicio.Select()
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowAsignado(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            dtVendedor = Nothing

            '======================================= Estados ===========================================
            dtEstados = oCotizacionService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub llenarCombosRechazo()

        Try
            dtMotivo = oCotizacionService.MostrarTipoRechazo.Tables(0)
            dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdTipo").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdTipo").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("Nombre").ToString
            dtMotivo = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepCotizacion
            Dim opcion As Integer
            Dim txtopcion As String = ""
            If optTodos.Checked = True Then
                opcion = 0
                txtopcion = ""
            ElseIf OptGenerados.Checked = True Then
                opcion = 1
                txtopcion = "GENERADOS"
            ElseIf optVencidos.Checked = True Then
                opcion = 2
                txtopcion = "VENCIDOS"
            ElseIf optAtendidos.Checked = True Then
                opcion = 3
                txtopcion = "ATENDIDOS"
            ElseIf optRechazados.Checked = True Then
                opcion = 4
                txtopcion = "RECHAZADOS"
            End If

            dtReporte = oCotizacionService.Reporte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value),
                                                   cbFecInicio.Value,
                                                   cbFecFinal.Value,
                                                   IIf(rbBuscarCliente.Checked = True, 0, IdCliente),
                                                   IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value),
                                                   IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value),
                                                   IIf(cmbMotivo.Text = "(Todos)", 0, cmbMotivo.Value), opcion).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                'dtReporte.Sort = "Documento Asc "
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                reporte.SetParameterValue("Vendedor", cmbVendedor.Text)
                reporte.SetParameterValue("Cliente", txtCliente.Text)
                reporte.SetParameterValue("Estado", cmbEstado.Text)
                reporte.SetParameterValue("Oficina", IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Text))
                reporte.SetParameterValue("Almacen", IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Text))
                reporte.SetParameterValue("Opcion", txtopcion)
                forma.Text = "Reporte de Cotización"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Text = ""
        IdCliente = 0
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(77, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("CodAlm").ToString
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

    Private Sub cmbEstado_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.ValueChanged
        Try
            If cmbEstado.Value = "RE" Then
                cmbMotivo.Enabled = True
                llenarCombosRechazo()
            Else
                cmbMotivo.Enabled = False
                cmbMotivo.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodoVendedor.CheckedChanged
        If rbTodoVendedor.Checked Then
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = True
        Else
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = False
        End If
    End Sub

    Private Sub optTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTodos.CheckedChanged
        If optTodos.Checked = True Then
            cmbEstado.Enabled = True
            cmbEstado.Text = ""
        Else
            cmbEstado.Enabled = False
            cmbEstado.Text = ""
        End If
    End Sub


    Private Sub cmbIdLocacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbIdLocacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Select()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                     cbFecInicio.KeyPress _
                  , cmbOficinas.KeyPress _
                  , cbFecFinal.KeyPress _
                  , cmbEstado.KeyPress _
                  , cmbMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class