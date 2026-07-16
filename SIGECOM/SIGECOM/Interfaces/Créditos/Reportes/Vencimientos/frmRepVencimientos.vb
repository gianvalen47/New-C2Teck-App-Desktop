Imports System.ServiceModel
Public Class frmRepVencimientos
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaDetalleService As New PlanillaDetalleService.PlanillaDetalleServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private dtUnidades As DataTable
    Private dtCobrador As DataTable
    Private dtMonedas As DataTable
    Private dtTipoDocumentos As DataTable

    Private IdCliente As String
    Private TipCta As String
    Private Condicion As String
    Private Sub frmRepVencimientos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oCentroCostoService.Close()
            oDocumentoCtaCtesService.Close()
            oMaestroService.Close()
            oPlanillaDetalleService.Close()
            oSeguridadService.Close()
            oPlanillaService.Close()
        Catch ex As TimeoutException
            oCentroCostoService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            oPlanillaDetalleService.Abort()
            oSeguridadService.Abort()
            oPlanillaService.Abort()
        Catch ex As CommunicationException
            oCentroCostoService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            oPlanillaDetalleService.Abort()
            oSeguridadService.Abort()
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
    Private Function getRowSinAsignacion(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 1
        Catch ex As Exception

        End Try
        Try
            fila(1) = "SIN ASIGNACION DE COBRADOR"
        Catch ex As Exception

        End Try

        Return fila
    End Function


    Private Sub frmRepVencimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmRepVencimientos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmRepVencimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 50)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()
        cmbCodMon.Value = "US"
        cmbCobrador.Text = "(Todos)"
        llenarCombos()
    End Sub
    Private Sub llenarCombos()
        Try

            '==================================COBRADOR======================================================
            dtCobrador = oPlanillaService.MostrarCobradores(Session.sCodEmp).Tables(0)
            dtCobrador.Rows.InsertAt(getRowSinAsignacion(dtCobrador), 0)
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

            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oPlanillaDetalleService.MostrarSerieDocumentoCtaCte(Session.sCodEmp).Tables(0)
            Dim row As DataRow = dtTipoDocumentos.NewRow
            row(1) = 0
            row(3) = "(Todos)"
            dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DisplayMember = "Descripcion"
            cmbDocu.ValueMember = "IdSerieDoc"
            cmbDocu.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cmbDocu.DropDownList.Columns(1).DataMember = "Descripcion"
            cmbDocu.SelectedIndex = 0
            'dtTipoDocumentos = oMaestroService.MostrarTipDocCtaCte.Tables(0)
            'Dim row As DataRow = dtTipoDocumentos.NewRow
            'row(0) = 0
            'row(1) = "(Todos)"
            'dtTipoDocumentos.Rows.InsertAt(row, 0)
            'cmbDocu.DataSource = dtTipoDocumentos
            'cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            'cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            'cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            'cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            'cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            'cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            'cmbDocu.SelectedIndex = 0
            'dtTipoDocumentos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rpRepVencimientos

            dtReporte = oDocumentoCtaCtesService.RepVencimientos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IIf(txtCliente.Text = "", 0, IdCliente), Condicion, cmbDocu.Value, IIf(cmbCobrador.Text = "(Todos)", 0, cmbCobrador.Value), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value), 1).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If rbFecEmision.checked Then

                    If rbAscendente.checked Then
                        dtReporte.Sort = "TipoCon Asc,CodSerie Asc,NumDoc Asc"
                    ElseIf rbDescendente.checked Then
                        dtReporte.Sort = "TipoCon Desc,CodSerie Desc,NumDoc Desc"
                    End If

                Else

                    If rbAscendente.checked Then
                        dtReporte.Sort = "VenDoc Asc "
                    ElseIf rbDescendente.checked Then
                        dtReporte.Sort = "VenDoc Desc "
                    End If

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

                forma.Text = "Reporte de Vencimientos"

                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("Documento", cmbDocu.Text)
                reporte.SetParameterValue("Cobrador", IIf(cmbCobrador.Value = 0, "", cmbCobrador.Text))
                reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)

                If rcPendientes.checked Then
                    reporte.SetParameterValue("Condicion", "Pendientes")
                ElseIf rcTodos.checked Then
                    reporte.SetParameterValue("Condicion", "Todos")
                End If

                'If cmbCodMon.Value = "US" Then
                '    reporte.SetParameterValue("Moneda", "Dólares")
                'ElseIf cmbCodMon.Value = "NS" Then
                '    reporte.SetParameterValue("Moneda", "Soles")
                'ElseIf cmbCodMon.Value = "EU" Then
                '    reporte.SetParameterValue("Moneda", "Euros")
                'End If

                If rbCtasCtes.checked Then
                    reporte.SetParameterValue("TipCta", "Cta Cte")
                ElseIf rbProvisiones.checked Then
                    reporte.SetParameterValue("TipCta", "Provisiones")
                ElseIf rbCastigos.checked Then
                    reporte.SetParameterValue("TipCta", "Castigos")
                ElseIf rbTodos.checked Then
                    reporte.SetParameterValue("TipCta", "Todos")
                End If

                'dtReporte.WriteXmlSchema("C:\RepVencimiento.xml"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If

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
        oSeguridadService.RegistrarVisitaOpciones(50, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rcPendientes_checkedChanged(ByVal sender As System.Object, e As System.EventArgs) Handles rcPendientes.CheckedChanged
        Condicion = 1
    End Sub

    Private Sub rcTodos_checkedChanged(ByVal sender As System.Object, e As System.EventArgs) Handles rcTodos.CheckedChanged
        Condicion = 0
    End Sub

    
    Private Sub rcTodoCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcTodoCobrador.CheckedChanged
        If rcTodoCobrador.Checked Then

            lblCobrador.Enabled = False
            cmbCobrador.Enabled = False
            cmbCobrador.Value = 0
            cmbCobrador.Clear()
        Else
            lblCobrador.Enabled = True
            cmbCobrador.Enabled = True
        End If
    End Sub

    
    Private Sub rcCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcCliente.CheckedChanged
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