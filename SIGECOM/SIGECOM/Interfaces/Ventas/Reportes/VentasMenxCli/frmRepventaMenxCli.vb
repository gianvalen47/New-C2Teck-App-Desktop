Imports System.ServiceModel
Public Class frmRepventaMenxCli
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oProductoService As New ProductoService.ProductoServiceClient

    Private dtSectores As DataTable
    Private dtVendedor As DataTable
    Private dtOficinas As DataTable
    Private dtRubros As DataTable
    Private dtAlmacenes As DataTable
    Private CodMon As String

    Private Sub frmRepventaMenxCli_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oReporteVentaService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oReporteVentaService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
            oProductoService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepventaMenxCli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepventaMenxCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                cbFecInicio.KeyPress _
                , cbFecFinal.KeyPress _
                , cmbOficinas.KeyPress _
                , cmbIdLocacion.KeyPress _
                , cmbVendedor.KeyPress _
                , cmbCodRub.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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

    Private Sub frmRepventaMenxCli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 96)
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
        llenarCombos()
        cbFecInicio.Select()
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
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
            '======================================= SECTORES =========================================
            dtSectores = oMaestroService.MostrarSectorCliente.Tables(0)
            dtSectores.Rows.InsertAt(getRowTodos(dtSectores), 0)
            cmbCodSec.DataSource = dtSectores
            cmbCodSec.DropDownList.DataMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.DropDownList.DisplayMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.DropDownList.ValueMember = dtSectores.Columns("CodSec").ToString
            cmbCodSec.DropDownList.Columns(0).DataMember = dtSectores.Columns("CodSec").ToString
            cmbCodSec.DropDownList.Columns(1).DataMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.SelectedIndex = 0
            dtSectores = Nothing

            '======================================= RUBROS ================================================
            dtRubros = oProductoService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView

            If rbDetalle.Checked Then

                Dim reporte As New rpRepVentaMenxCli
                dtReporte = oReporteVentaService.ReporteMensualxCliente(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodSec.Text = "(Todos)", "", cmbCodSec.Value), IIf(rbTodoVendedor.Checked, 0, cmbVendedor.Value), 1, CodMon).Tables(0).DefaultView

                If dtReporte.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbTotVenta.Checked Then
                        If rbAscendente.Checked Then
                            dtReporte.Sort = "Total Asc"
                        ElseIf rbDescendente.Checked Then
                            dtReporte.Sort = "Total Desc"
                        End If
                    ElseIf rbCliente.Checked Then
                        If rbAscendente.Checked Then
                            dtReporte.Sort = "DesCli Asc"
                        ElseIf rbDescendente.Checked Then
                            dtReporte.Sort = "DesCli Desc"
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

                    forma.Text = "Reporte de Ventas Mensuales"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Sector", cmbCodRub.Text)
                    reporte.SetParameterValue("Vendedor", IIf(cmbVendedor.Value = 0, "", cmbVendedor.Text))
                    reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                    reporte.SetParameterValue("Almacen", cmbIdLocacion.Text)
                    reporte.SetParameterValue("Moneda", IIf(CodMon = "NS", "SOLES", "DOLARES AMERICANOS"))
                    ' dtReporte.WriteXmlSchema("C:\VentaAcumulada.xml")
                    forma.ShowDialog()
                End If

            ElseIf rbResumen.Checked Then

                Dim reporte As New rpRepVentaMenxCliResumen
                dtReporte = oReporteVentaService.ReporteMensualxCliente(Session.sCodEmp, cmbOficinas.Value, IIf(cmbIdLocacion.Text = "(Todos)", "", cmbIdLocacion.Value), IIf(cmbCodRub.Text = "(Todos)", "", cmbCodRub.Value), cbFecInicio.Value, cbFecFinal.Value, IIf(cmbCodSec.Text = "(Todos)", "", cmbCodSec.Value), cmbVendedor.Value, 2, CodMon).Tables(0).DefaultView

                If dtReporte.Count = 0 Then
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

                    forma.Text = "Reporte de Ventas Mensuales"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Moneda", IIf(CodMon = "NS", "SOLES", "DOLARES AMERICANOS"))
                    ' dtReporte.WriteXmlSchema("C:\VentaAcumulada.xml")

                    forma.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(96, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub rbTodoVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodoVendedor.CheckedChanged

        If rbTodoVendedor.Checked Then
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = True
            'cmbVendedor.Value = 0
        Else
            cmbVendedor.Clear()
            cmbVendedor.ReadOnly = False
        End If
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


    Private Sub rbResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbResumen.CheckedChanged, rbDetalle.CheckedChanged
        If rbResumen.Checked Then
            gbOrdenadox.Enabled = False
            gbTipoOrden.Enabled = False
            gbVendedor.Enabled = False
            lblAlmacen.Enabled = False
            lblOficina.Enabled = False
            lblSector.Enabled = False
            cmbCodSec.Enabled = False
            cmbIdLocacion.Enabled = False
            cmbOficinas.Enabled = False
            cmbCodRub.Enabled = False
            lblRubro.Enabled = False
        ElseIf rbDetalle.Checked Then
            gbOrdenadox.Enabled = True
            gbTipoOrden.Enabled = True
            gbVendedor.Enabled = True
            lblAlmacen.Enabled = True
            lblOficina.Enabled = True
            lblSector.Enabled = True
            cmbCodSec.Enabled = True
            cmbIdLocacion.Enabled = True
            cmbOficinas.Enabled = True
            cmbCodRub.Enabled = True
            lblRubro.Enabled = True
        End If
    End Sub

    Private Sub rbSoles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSoles.CheckedChanged, rbDolares.CheckedChanged
        If rbSoles.Checked Then
            CodMon = "NS"
        ElseIf rbDolares.Checked Then
            CodMon = "US"
        End If
    End Sub

    Private Sub cmbCodSec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCodSec.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnAceptar.Select()
        End If
    End Sub
End Class