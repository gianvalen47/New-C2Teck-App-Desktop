Imports System.ServiceModel
Public Class frmRepVencimientosResumen
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private dtUnidades As DataTable
    Private TipCta As String

    Private dtCobrador As DataTable
    Private dtMonedas As DataTable
    Private dtTipoDocumentos As DataTable
    Private Fecha As Date

    Private Sub frmRepVencimientosDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oSeguridadService.Close()
            oDocumentoCtaCtesService.Close()
            oMaestroService.Close()
            oCentroCostoService.Close()
            oPlanillaService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPlanillaService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            oCentroCostoService.Abort()
            oPlanillaService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
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
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub frmRepVencimientosResumen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmRepVencimientosResumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
         cmbCobrador.KeyPress _
         , cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmRepVencimientosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 95)
        '/*************************************************************************************/

        cbFecInicio.Value = Today
        CalcularFecha()
        cbFecInicio.Select()
        cmbCodMon.Value = "US"
        cmbCobrador.Text = "(Todos)"
        llenarCombos()


    End Sub

    Private Sub llenarCombos()
        Try

            '==================================COBRADOR======================================================
            dtCobrador = oPlanillaService.MostrarCobradores(Session.sCodEmp).Tables(0)
            dtCobrador.Rows.InsertAt(getRowTodos(dtCobrador), 0)
            cmbCobrador.DataSource = dtCobrador
            cmbCobrador.DisplayMember = "ApeNom"
            cmbCobrador.ValueMember = "IdPer"
            cmbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cmbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            'cbCobrador.SelectedIndex = 0
            dtCobrador = Nothing
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
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
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepVencimientosResumen
            dtReporte = oDocumentoCtaCtesService.RepVencimientos(Session.sCodEmp, cbFecFinal.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, 0, 0, 0, IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value), 2)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                Dim Contador As Integer = dtReporte.Compute("Count(DesCli)", "").ToString()
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Reporte Acumulado de Vencimientos "
                reporte.SetParameterValue("FecInicio", cbFecFinal.Text)
                reporte.SetParameterValue("FecFinal", Fecha.AddDays(27))
                reporte.SetParameterValue("Cobrador", cmbCobrador.Text)
                reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)
                reporte.SetParameterValue("Contador", Contador)
                reporte.SetParameterValue("Sem1", dtReporte.Columns(10).ColumnName.ToString)
                reporte.SetParameterValue("Sem2", dtReporte.Columns(11).ColumnName.ToString)
                reporte.SetParameterValue("Sem3", dtReporte.Columns(12).ColumnName.ToString)
                reporte.SetParameterValue("Sem4", dtReporte.Columns(13).ColumnName.ToString)

                If cmbCodMon.Value = "US" Then
                    reporte.SetParameterValue("CodMon", "US$")
                    reporte.SetParameterValue("Moneda", "Dólares")
                ElseIf cmbCodMon.Value = "NS" Then
                    reporte.SetParameterValue("CodMon", "NS")
                    reporte.SetParameterValue("Moneda", "Soles")
                ElseIf cmbCodMon.Value = "EU" Then
                    reporte.SetParameterValue("CodMon", "EU")
                    reporte.SetParameterValue("Moneda", "Euros")
                End If

                If rbCtasCtes.Checked Then
                    reporte.SetParameterValue("Documento", "Cuentas Corrientes")
                ElseIf rbProvisiones.Checked Then
                    reporte.SetParameterValue("Documento", "Provisiones")
                ElseIf rbCastigos.checked Then
                    reporte.SetParameterValue("Documento", "Castigos")
                ElseIf rbTodos.checked Then
                    reporte.SetParameterValue("Documento", "Todos")
                End If

                ''dtReporte.WriteXmlSchema("C:\RepVencimiento.xml")
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub rbCtasCtes_checkedChanged(ByVal sender As System.Object, e As System.EventArgs) Handles rbCtasCtes.CheckedChanged, rbProvisiones.CheckedChanged, rbCastigos.CheckedChanged, rbTodos.CheckedChanged
        If rbCtasCtes.Checked Then
            TipCta = 1
        ElseIf rbProvisiones.Checked Then
            TipCta = 2
        ElseIf rbCastigos.Checked Then
            TipCta = 3
        ElseIf rbTodos.Checked Then
            TipCta = ""
        End If
    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(95, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub CalcularFecha()

        Fecha = cbFecInicio.Value

        Do While Weekday(Fecha) <> 2
            Fecha = Fecha.AddDays(1)
        Loop
        cbFecFinal.Value = Fecha
    End Sub

    Private Sub cbFecInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cbFecInicio.ValueChanged
        CalcularFecha()
    End Sub
End Class