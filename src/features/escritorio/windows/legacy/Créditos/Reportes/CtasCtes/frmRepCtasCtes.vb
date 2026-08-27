Imports System.ServiceModel
Public Class frmRepCtasCtes
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private dtCobrador As DataTable
    Private dtMonedas As DataTable
    Private dtUnidades As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtEstado As DataTable
    Private IdCliente As String
    Private TipCta As String
    Private Tipo As String
    Private Condicion As String
    Private Documento As Integer

    Private Sub frmRepCtasCtes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            oDocumentoCtaCtesService.Close()
            oMaestroService.Close()
            oCentroCostoService.Close()
            oSeguridadService.Close()
            oPlanillaService.Close()
        Catch ex As TimeoutException
            oCentroCostoService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPlanillaService.Abort()
        Catch ex As CommunicationException
            oCentroCostoService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
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

    Private Sub frmRepCtasCtes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCtasCtes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
             cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub frmRepCtasCtes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 45)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/01/1992"
        cbFecFinal.Value = Fecha
        cbFecInicio.Select()
        cmbCodMon.Value = "US"
        cmbEstado.Value = "(Todos)"
        cmbCobrador.Text = "(Todos)"
        llenarcombos()

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)

    End Sub
    Private Sub llenarcombos()
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
            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oMaestroService.MostrarTipDocCtaCte.Tables(0)
            'Dim row As DataRow = dtTipoDocumentos.NewRow
            'row(0) = 0
            'row(1) = "(Todos)"
            'dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            'cmbDocu.SelectedIndex = 1
            dtTipoDocumentos = Nothing
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '===================================ESTADOS CTA CTES =============================================
            dtEstado = oDocumentoCtaCtesService.MostrarEstados.Tables(0)
            dtEstado.Rows.InsertAt(getRowTodos(dtEstado), 0)
            cmbEstado.DataSource = dtEstado
            cmbEstado.DropDownList.DisplayMember = dtEstado.Columns("DesEst").ToString
            cmbEstado.DropDownList.ValueMember = dtEstado.Columns("CodEst").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstado.Columns("CodEst").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstado.Columns("DesEst").ToString
            dtOficinas = Nothing

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
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            oDocumentoCtaCtesService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(400)
            If rbDetallado.checked Then
                Dim reporte As New rpRepDocumentoCtaCte

                dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IdCliente, Condicion, IIf(rbDocDocumento.checked, cmbDocu.Value, 0), Documento, IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value), IIf(rcTodoCobrador.Checked, 0, cmbCobrador.Value), Tipo, IIf(cbMoneda.Checked = False, 1, 2), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value)).Tables(0).DefaultView

                '{RepDocumentoCtaCte.Importe}*IIf({RepDocumentoCtaCte.TipMov}="D",1,-1)+{RepDocumentoCtaCte.Letra}-({RepDocumentoCtaCte.Pago}*IIf({RepDocumentoCtaCte.TipMov}="D",1,-1))-{RepDocumentoCtaCte.Devolucion}

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbExportExcel.checked Then
                        Dim calcular As Decimal
                        For Each Fila As DataRow In dtReporte.Table.Rows
                            calcular = Fila.Item("Importe") * IIf(Fila.Item("TipMov") = "D", 1, -1) + Fila.Item("Letra") - Fila.Item("Pago") * IIf(Fila.Item("TipMov") = "D", 1, -1) - Fila.Item("Devolucion")
                            Fila.Item("Saldo") = calcular
                            dtReporte.ToTable.AcceptChanges()
                        Next
                        DataGridView1.DataSource = dtReporte

                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente ")
                        End If

                    ElseIf rbPantalla.checked Then
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False


                        forma.Text = "Reporte de Documentos de Cuentas Corrientes"
                        reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                        reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                        If rbDocCliente.checked Then
                            reporte.SetParameterValue("Documento", "Cliente")
                        ElseIf rbDocDocumento.checked Then
                            reporte.SetParameterValue("Documento", cmbDocu.Text)
                        ElseIf rbDocJudicial.checked Then
                            reporte.SetParameterValue("Documento", "Judicial")
                        ElseIf rbDocGeneral.checked Then
                            reporte.SetParameterValue("Documento", "General")
                        End If
                        reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                        reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                        reporte.SetParameterValue("Estado", cmbEstado.Text)
                        reporte.SetParameterValue("Cobrador", IIf(cmbCobrador.Value = 0, "", cmbCobrador.Text))
                        reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)

                        If rbPendientes.checked Then
                            reporte.SetParameterValue("Condicion", "PENDIENTES")
                        ElseIf rbCancelados.checked Then
                            reporte.SetParameterValue("Condicion", "CANCELADOS")
                        ElseIf rbTodos.checked Then
                            reporte.SetParameterValue("Condicion", "TODOS")
                        End If

                        If cmbCodMon.Value = "US" Then
                            reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "EXPRESADO EN DOLARES", "EN DOLARES"))
                        ElseIf cmbCodMon.Value = "NS" Then
                            reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "EXPRESADO EN SOLES", "EN SOLES"))
                        ElseIf cmbCodMon.Value = "EU" Then
                            reporte.SetParameterValue("Moneda", "EUROS")
                        End If

                        If rbCtasCtes.checked Then
                            reporte.SetParameterValue("TipCta", "CUENTAS CORRIENTES")
                        ElseIf rbProvisiones.checked Then
                            reporte.SetParameterValue("TipCta", "PROVISIONES")
                        ElseIf rbCastigos.checked Then
                            reporte.SetParameterValue("TipCta", "CASTIGOS")
                        End If

                        'dtReporte.WriteXmlSchema("C:\RepDocumentoCtaCte.xml")
                        forma.ShowDialog()
                    End If
                End If

            ElseIf rbResumen.checked Then
                Dim reporte As New rpRepDocumentoCtaCteResumen
                Dim reporte2 As New rpRepDocumentoCtaCteResumen2

                'dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IdCliente, Condicion, IIf(rbDocDocumento.checked, cmbDocu.Value, 0), Documento, IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value), IIf(rcTodoCobrador.Checked, 0, cmbCobrador.Value), Tipo, IIf(cbMoneda.Checked = False, 1, 2)).Tables(0).DefaultView
                'dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, "", "", Today, Today, "1", "US", 0, 1, 0, "", 0, 1).Tables(0)

                If cbMoneda.Checked Then

                    dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IdCliente, Condicion, IIf(rbDocDocumento.checked, cmbDocu.Value, 0), Documento, IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value), IIf(rcTodoCobrador.Checked, 0, cmbCobrador.Value), Tipo, IIf(cbMoneda.Checked = False, 1, 2), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value)).Tables(0).DefaultView

                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else

                        If rbExportExcel.checked Then

                            If rbTotal.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "Saldo Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "Saldo Desc "
                                End If
                            ElseIf rbCliente.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "DesCli Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "DesCli Desc "
                                End If
                            End If

                            DataGridView1.DataSource = dtReporte
                            Dim Export As Boolean = ExportarExcel(DataGridView1)
                            If Export Then
                                MsgBox("Se realizó la exportación correctamente ")
                            End If
                        ElseIf rbPantalla.checked Then
                            If rbTotal.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "Saldo Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "Saldo Desc "
                                End If
                            ElseIf rbCliente.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "DesCli Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "DesCli Desc "
                                End If
                            End If

                            reporte2.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte2

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False


                            forma.Text = "Reporte de Documentos de Cuentas Corrientes"
                            reporte2.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte2.SetParameterValue("FecFinal", cbFecFinal.Text)
                            If cmbCodMon.Value = "NS" Then
                                reporte2.SetParameterValue("Moneda", "NS")
                            ElseIf cmbCodMon.Value = "US" Then
                                reporte2.SetParameterValue("Moneda", "US")
                            End If

                            If rbCtasCtes.checked Then
                                reporte2.SetParameterValue("TipCta", "CUENTAS CORRIENTES")
                            ElseIf rbProvisiones.checked Then
                                reporte2.SetParameterValue("TipCta", "PROVISIONES")
                            ElseIf rbCastigos.checked Then
                                reporte2.SetParameterValue("TipCta", "CASTIGOS")
                            End If
                            reporte2.SetParameterValue("UnidadNegocio", cmbUnidad.Text)
                            'If cmbCodMon.Value = "US" Then
                            '    reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "Expresado en Dólares", "En Dólares"))
                            'ElseIf cmbCodMon.Value = "NS" Then
                            '    reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "Expresado en Sóles", "En Sóles"))
                            'ElseIf cmbCodMon.Value = "EU" Then
                            '    reporte.SetParameterValue("Moneda", "Euros")
                            'End If

                            'dtReporte.WriteXmlSchema("C:\RepDocumentoCtaCte.xml")
                            forma.ShowDialog()
                        End If
                    End If

                ElseIf cbMoneda.Checked = False Then

                    dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IdCliente, Condicion, IIf(rbDocDocumento.checked, cmbDocu.Value, 0), Documento, IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value), IIf(rcTodoCobrador.Checked, 0, cmbCobrador.Value), Tipo, IIf(cbMoneda.Checked = False, 1, 2), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value)).Tables(0).DefaultView

                    If dtReporte.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else

                        If rbExportExcel.checked Then

                            If rbTotal.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "Saldo Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "Saldo Desc "
                                End If
                            ElseIf rbCliente.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "DesCli Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "DesCli Desc "
                                End If
                            End If

                            DataGridView1.DataSource = dtReporte
                            Dim Export As Boolean = ExportarExcel(DataGridView1)
                            If Export Then
                                MsgBox("Se realizó la exportación correctamente ")
                            End If
                        ElseIf rbPantalla.checked Then
                            If rbTotal.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "Saldo Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "Saldo Desc "
                                End If
                            ElseIf rbCliente.checked Then
                                If rbAscendente.checked Then
                                    dtReporte.Sort = "DesCli Asc "
                                ElseIf rbDescendente.checked Then
                                    dtReporte.Sort = "DesCli Desc "
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


                            forma.Text = "Reporte de Documentos de Cuentas Corrientes"
                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                            reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)
                            If rbCtasCtes.checked Then
                                reporte.SetParameterValue("TipCta", "CUENTAS CORRIENTES")
                            ElseIf rbProvisiones.checked Then
                                reporte.SetParameterValue("TipCta", "PROVISIONES")
                            ElseIf rbCastigos.checked Then
                                reporte.SetParameterValue("TipCta", "CASTIGOS")
                            End If

                            If cmbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "Expresado en Dólares", "En Dólares"))
                            ElseIf cmbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "Expresado en Sóles", "En Sóles"))
                            ElseIf cmbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "Euros")
                            End If
                            forma.ShowDialog()
                        End If
                    End If

                End If

            ElseIf rbXUnidadNegocio.Checked = True Then
                Dim reporte As New rpRepDocumentoCtaCteResumen_UN
                Dim reporte2 As New rpRepDocumentoCtaCteResumen2_UN

                If cbMoneda.Checked Then

                    dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IdCliente, Condicion, IIf(rbDocDocumento.Checked, cmbDocu.Value, 0), Documento, IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value), IIf(rcTodoCobrador.Checked, 0, cmbCobrador.Value), Tipo, IIf(cbMoneda.Checked = False, 1, 2), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value)).Tables(0).DefaultView

                    If dtReporte.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else

                        If rbExportExcel.Checked Then

                            DataGridView1.DataSource = dtReporte
                            Dim Export As Boolean = ExportarExcel(DataGridView1)
                            If Export Then
                                MsgBox("Se realizó la exportación correctamente ")
                            End If
                        ElseIf rbPantalla.Checked Then

                            reporte2.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte2

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Reporte de Documentos de Cuentas Corrientes"
                            reporte2.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte2.SetParameterValue("FecFinal", cbFecFinal.Text)
                            If cmbCodMon.Value = "NS" Then
                                reporte2.SetParameterValue("Moneda", "NS")
                            ElseIf cmbCodMon.Value = "US" Then
                                reporte2.SetParameterValue("Moneda", "US")
                            End If

                            If rbCtasCtes.Checked Then
                                reporte2.SetParameterValue("TipCta", "CUENTAS CORRIENTES")
                            ElseIf rbProvisiones.Checked Then
                                reporte2.SetParameterValue("TipCta", "PROVISIONES")
                            ElseIf rbCastigos.Checked Then
                                reporte2.SetParameterValue("TipCta", "CASTIGOS")
                            End If                            
                            forma.ShowDialog()
                        End If
                    End If

                ElseIf cbMoneda.Checked = False Then

                    dtReporte = oDocumentoCtaCtesService.RepDocumentoCtaCte(Session.sCodEmp, IIf(cmbOficinas.Text = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), cbFecInicio.Value, cbFecFinal.Value, TipCta, cmbCodMon.Value, IdCliente, Condicion, IIf(rbDocDocumento.Checked, cmbDocu.Value, 0), Documento, IIf(cmbEstado.Text = "(Todos)", "", cmbEstado.Value), IIf(rcTodoCobrador.Checked, 0, cmbCobrador.Value), Tipo, IIf(cbMoneda.Checked = False, 1, 2), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value)).Tables(0).DefaultView

                    If dtReporte.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else

                        If rbExportExcel.Checked Then
                            DataGridView1.DataSource = dtReporte
                            Dim Export As Boolean = ExportarExcel(DataGridView1)
                            If Export Then
                                MsgBox("Se realizó la exportación correctamente ")
                            End If
                        ElseIf rbPantalla.Checked Then
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False


                            forma.Text = "Reporte de Documentos de Cuentas Corrientes"
                            reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                            reporte.SetParameterValue("FecFinal", cbFecFinal.Text)                            
                            If rbCtasCtes.Checked Then
                                reporte.SetParameterValue("TipCta", "CUENTAS CORRIENTES")
                            ElseIf rbProvisiones.Checked Then
                                reporte.SetParameterValue("TipCta", "PROVISIONES")
                            ElseIf rbCastigos.Checked Then
                                reporte.SetParameterValue("TipCta", "CASTIGOS")
                            End If

                            If cmbCodMon.Value = "US" Then
                                reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "Expresado en Dólares", "En Dólares"))
                            ElseIf cmbCodMon.Value = "NS" Then
                                reporte.SetParameterValue("Moneda", IIf(cbMoneda.Checked = False, "Expresado en Sóles", "En Sóles"))
                            ElseIf cmbCodMon.Value = "EU" Then
                                reporte.SetParameterValue("Moneda", "Euros")
                            End If
                            forma.ShowDialog()
                        End If
                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
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

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtBuscarCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
    End Sub


    Private Sub rbCtasCtes_checkedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCtasCtes.CheckedChanged, rbProvisiones.CheckedChanged, rbCastigos.CheckedChanged
        If rbCtasCtes.Checked Then
            TipCta = 1
        ElseIf rbProvisiones.Checked Then
            TipCta = 2
        ElseIf rbCastigos.Checked Then
            TipCta = 3
        End If
    End Sub

    Private Sub rbPendientes_checkedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPendientes.CheckedChanged, rbCancelados.CheckedChanged, rbTodos.CheckedChanged
        If rbPendientes.Checked Then
            Condicion = 1
        ElseIf rbCancelados.Checked Then
            Condicion = 2
        ElseIf rbTodos.Checked Then
            Condicion = 3
        End If
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(45, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub rbDetallado_checkedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetallado.CheckedChanged, rbResumen.CheckedChanged, rbXUnidadNegocio.CheckedChanged
        If rbDetallado.Checked Then
            Tipo = 1
            gbOrden.Enabled = False
            gbOrdenado.Enabled = False
            cmbOficinas.Enabled = True
            lblOficina.Enabled = True
            cmbIdLocacion.Enabled = True
            lblAlmacen.Enabled = True
            gbCobrador.Enabled = True
            gbCliente.Enabled = True
            cmbEstado.Enabled = True
            lblEstado.Enabled = True
            cmbCodMon.Enabled = True
        ElseIf rbResumen.Checked Then
            Tipo = 2
            gbOrden.Enabled = True
            gbOrdenado.Enabled = True
            cmbOficinas.Enabled = False
            lblOficina.Enabled = False
            cmbOficinas.SelectedIndex = 0
            cmbIdLocacion.Enabled = False
            lblAlmacen.Enabled = False
            cmbIdLocacion.SelectedIndex = 0
            gbCobrador.Enabled = False
            rcTodoCobrador.Checked = True
            cmbCobrador.Clear()
            gbCliente.Enabled = False
            rcCliente.Checked = True
            txtBuscarCliente.Clear()
            IdCliente = 0
            cmbEstado.Enabled = False
            lblEstado.Enabled = False
            cmbEstado.SelectedIndex = 0
            If cbMoneda.Checked Then
                cmbCodMon.Enabled = False
                'cmbCodMon.Value = 0
                'cmbCodMon.Clear()
            Else
                cmbCodMon.Enabled = True
                'cmbCodMon.Value = "NS"
            End If
        ElseIf rbXUnidadNegocio.Checked Then
            Tipo = 4
            gbOrden.Enabled = False
            gbOrdenado.Enabled = False
            cmbOficinas.Enabled = False
            lblOficina.Enabled = False
            cmbOficinas.SelectedIndex = 0
            cmbIdLocacion.Enabled = False
            lblAlmacen.Enabled = False
            cmbIdLocacion.SelectedIndex = 0
            gbCobrador.Enabled = False
            rcTodoCobrador.Checked = True
            cmbCobrador.Clear()
            gbCliente.Enabled = False
            rcCliente.Checked = True
            txtBuscarCliente.Clear()
            IdCliente = 0
            cmbEstado.Enabled = False
            lblEstado.Enabled = False
            cmbEstado.SelectedIndex = 0
            If cbMoneda.Checked Then
                cmbCodMon.Enabled = False              
            Else
                cmbCodMon.Enabled = True               
            End If
        End If
    End Sub

    Private Sub rbDocumentos_checkedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDocCliente.CheckedChanged, rbDocDocumento.CheckedChanged, rbDocJudicial.CheckedChanged, rbDocGeneral.CheckedChanged
        If rbDocCliente.Checked Then
            Documento = 1
            cmbDocu.ReadOnly = True
            cmbDocu.BackColor = System.Drawing.SystemColors.Control
            cmbDocu.Clear()
        ElseIf rbDocDocumento.Checked Then
            Documento = 2
            cmbDocu.ReadOnly = False
            cmbDocu.BackColor = System.Drawing.SystemColors.Window
            cmbDocu.SelectedIndex = 1
        ElseIf rbDocJudicial.Checked Then
            Documento = 3
            cmbDocu.ReadOnly = True
            cmbDocu.BackColor = System.Drawing.SystemColors.Control
            cmbDocu.Clear()
        ElseIf rbDocGeneral.Checked Then
            Documento = 4
            cmbDocu.ReadOnly = True
            cmbDocu.BackColor = System.Drawing.SystemColors.Control
            cmbDocu.Clear()
        End If

    End Sub

    Private Sub rcCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcCliente.CheckedChanged
        If rcCliente.Checked Then
            lblCliente.Enabled = False
            txtBuscarCliente.ReadOnly = True
            btnCliente.Enabled = False
            txtBuscarCliente.Text = ""
            IdCliente = 0
        Else
            lblCliente.Enabled = True
            txtBuscarCliente.ReadOnly = False
            btnCliente.Enabled = True
        End If
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

    Private Sub cbMoneda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMoneda.CheckedChanged
        If rbResumen.checked Then
            If cbMoneda.Checked Then
                cmbCodMon.Enabled = False
                'cmbCodMon.Value = 0
                'cmbCodMon.Clear()
            Else
                cmbCodMon.Enabled = True
                'cmbCodMon.Value = "NS"
            End If
        End If
    End Sub
End Class