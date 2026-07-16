Imports System.ServiceModel
Public Class frmRepEmbarques

    '=========================== Servicios ====================================
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '====================== Declaración de Variables ==============================
    Private dtProveedores As DataTable
    Private dtMedios As DataTable


    Private Sub frmRepEmbarques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 249)
        '/*************************************************************************************/

        LlenarCombos()

        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        txtFechaInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        txtFechaFin.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)

        rbFechaEmision.Checked = True
        txtFechaInicio.Focus()
    End Sub

    Private Sub frmRepEmbarques_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                     txtFechaInicio.KeyPress _
                   , txtFechaFin.KeyPress _
                   , rbFechaEmision.KeyPress _
                   , rbFechaLlegada.KeyPress _
                   , cmbMedio.KeyPress _
                   , txtCodEmbarque.KeyPress _
                   , cmbProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub Finalizar()
        Try
            oFacturaImportService.Close()
            oPedidoImportService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oFacturaImportService.Abort()
            oPedidoImportService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oFacturaImportService.Abort()
            oPedidoImportService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepEmbarques_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmRepEmbarques_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try

            '======================================= MEDIOS ================================================
            dtMedios = New DataTable
            dtMedios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMedios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtMedios.Rows.Add(New Object() {"", "(Todos)"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"A", "Aéreo"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"M", "Marinos"})
            dtMedios.Rows.Add(New Object() {"O", "Otros"})

            cmbMedio.DataSource = dtMedios
            cmbMedio.DropDownList.DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.DisplayMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.ValueMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(0).DataMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(1).DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.SelectedIndex = 0
            dtMedios = Nothing

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptRepEmbarques
            oSeguridadService.RegistrarVisitaOpciones(249, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            dtReporte = oFacturaImportService.Reporte(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, IIf(rbFechaEmision.Checked = True, 1, 2), _
                                                                           toBlank(cmbMedio.Value), txtCodEmbarque.Text, toNumber(cmbProveedor.Value)).Tables(0)            

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No existen datos a imprimir ")
            Else
                reporte.SetDataSource(dtReporte)
                reporte.SetParameterValue("FecInicio", txtFechaInicio.Text)
                reporte.SetParameterValue("FecFin", txtFechaFin.Text)
                reporte.SetParameterValue("Medio", cmbMedio.Text)
                reporte.SetParameterValue("CodEmbarque", txtCodEmbarque.Text)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Reporte de Facturas de Importación"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Imprimir Reporte")
        End Try
    End Sub
End Class