Imports System.ServiceModel
Public Class frmRepVisitaCobrador

    Private oMaestroService As New MaestroService.MaestroClient
    Private oVisitaCobradorService As New VisitaCobradorService.VisitaCobradorServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private IdCliente As Integer
    Private dtCobrador As DataTable
    Private dtMonedas As DataTable
    Private dtActividad As DataTable
    Private dtResultado As DataTable

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

    Private Sub frmRepVisitaCobrador_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            oVisitaCobradorService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oPlanillaService.Close()
        Catch ex As TimeoutException
            oPlanillaService.Abort()
            oVisitaCobradorService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPlanillaService.Abort()
            oVisitaCobradorService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepVisitaCobrador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepVisitaCobrador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
          cmbActividad.KeyPress _
        , cmbCobrador.KeyPress _
        , cmbCodMon.KeyPress _
        , cmbResultado.KeyPress _
        , txtImporte1.KeyPress _
        , txtImporte2.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepVisitaCobrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 81)
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
        cbFecInicio.Select()
        cmbCobrador.Text = "(Todos)"
        llenarCombos()

    End Sub
    Private Sub llenarCombos()
        '==================================COBRADOR======================================================
        dtCobrador = oPlanillaService.MostrarCobradores(Session.sCodEmp).Tables(0)
        dtCobrador.Rows.InsertAt(getRowTodos(dtCobrador), 0)
        cmbCobrador.DataSource = dtCobrador
        cmbCobrador.DisplayMember = "ApeNom"
        cmbCobrador.ValueMember = "IdPer"
        cmbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
        cmbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
        cmbCobrador.SelectedIndex = 0
        dtCobrador = Nothing
        '======================================= MONEDAS ================================================
        dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
        dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
        cmbCodMon.DataSource = dtMonedas
        cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
        cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
        cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
        cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
        cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
        cmbCodMon.SelectedIndex = 0
        dtMonedas = Nothing
        '==================================ACTIVIDAD=======================================================
        dtActividad = oVisitaCobradorService.MostrarActividad.Tables(0)
        dtActividad.Rows.InsertAt(getRowTodos(dtActividad), 0)
        cmbActividad.DataSource = dtActividad
        cmbActividad.DisplayMember = "DesActividad"
        cmbActividad.ValueMember = "IdActividad"
        cmbActividad.DropDownList.Columns(0).DataMember = "IdActividad"
        cmbActividad.DropDownList.Columns(1).DataMember = "DesActividad"
        cmbActividad.SelectedIndex = 0
        dtActividad = Nothing
        '=================================RESULTADO ======================================================
        dtResultado = oVisitaCobradorService.MostrarResultado.Tables(0)
        dtResultado.Rows.InsertAt(getRowTodos(dtResultado), 0)
        cmbResultado.DataSource = dtResultado
        cmbResultado.DisplayMember = "DesResultado"
        cmbResultado.ValueMember = "IdResultado"
        cmbResultado.DropDownList.Columns(0).DataMember = "IdResultado"
        cmbResultado.DropDownList.Columns(1).DataMember = "DesResultado"
        cmbResultado.SelectedIndex = 0
        dtResultado = Nothing

    End Sub
    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If

    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rpRepVisitaCobrador

            dtReporte = oVisitaCobradorService.Reporte(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(txtCliente.Text = "", 0, IdCliente), IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value), IIf(cmbResultado.Text = "(Todos)", 0, cmbResultado.Value), IIf(cmbActividad.Text = "(Todos)", 0, cmbActividad.Value), cmbCodMon.Value, txtImporte1.Text, txtImporte2.Text).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If rbFecha.Checked = True Then
                    dtReporte.Sort = "Fecha Asc "
                ElseIf rbCliente.Checked = True Then
                    dtReporte.Sort = "DesCli Asc "
                ElseIf rbActividad.Checked = True Then
                    dtReporte.Sort = "DesActividad Asc "
                End If

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("Actividad", cmbActividad.Text)
                reporte.SetParameterValue("Resultado", cmbResultado.Text)
                reporte.SetParameterValue("Cliente", txtCliente.Text)
                forma.Text = "Reporte de Visitas de los Cobradores"

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(81, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()

    End Sub

    Private Sub rcCliente_ToggleStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcCliente.CheckedChanged
        If rcCliente.Checked Then
            lblCliente.Enabled = False
            txtCliente.Enabled = False
            btnCliente.Enabled = False
            txtCliente.Text = ""
            IdCliente = 0
        Else
            lblCliente.Enabled = True
            txtCliente.Enabled = True
            btnCliente.Enabled = True
        End If
    End Sub


End Class