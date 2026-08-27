Imports System.ServiceModel
Public Class frmCuadrarCierre
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oProductoService As New ProductoService.ProductoServiceClient
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable
    Private dtReporte As New DataTable
    Private dtRubro As New DataTable


    Private Sub frmCuadrarCierre_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            ObjMaestro.Close()
            oSeguridadService.Close()
            ObjCierre.Close()
            oProductoService.Close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            oSeguridadService.Abort()
            ObjCierre.Abort()
            oProductoService.Abort()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            oSeguridadService.Abort()
            ObjCierre.Abort()
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmCuadrarCierre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbOficina.KeyPress _
        , cbFecFinal.KeyPress _
        , cbFecInicio.KeyPress
        ' , cbAlmacen.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub cbAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cbFecInicio.Focus()
            e.Handled = True
        End If
    End Sub
   
    Private Sub frmCuadrarCierre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub frmCuadrarCierre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 64)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)

        LlenarCombos()
        cbOficina.Focus()

    End Sub
    Private Sub LlenarCombos()
        Try
            '/////////OFICINA ORIGEN////////////////
            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing
            '/////////RUBROS////////////////
            dtRubro = oProductoService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cbCodRubro.DataSource = dtRubro
            cbCodRubro.DisplayMember = "DesRub"
            cbCodRubro.ValueMember = "CodRub"
            cbCodRubro.DropDownList.Columns(0).DataMember = "CodRub"
            cbCodRubro.DropDownList.Columns(1).DataMember = "DesRub"
            cbCodRubro.SelectedIndex = 0
            dtRubro = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub
    'Private Sub Finalizar()
    '    Try
    '        ObjMaestro.Close()
    '        ObjCierre.Close()
    '    Catch ex As TimeoutException
    '        ObjMaestro.Abort()
    '        ObjCierre.Abort()
    '    Catch ex As CommunicationException
    '        ObjMaestro.Abort()
    '        ObjCierre.Abort()
    '    End Try
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Cargar Almacenes")
        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        oSeguridadService.RegistrarVisitaOpciones(64, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

        ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(60)
        dtReporte = ObjCierre.MostrarCuadroCierre(cbAlmacen.Value, cbFecInicio.Value, cbFecFinal.Value, cbCodRubro.Value)

        If dtReporte.Rows.Count = 0 Then
            MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
            btnImprimir.Enabled = False
        Else
            Me.dgCierre.SetDataBinding(dtReporte, 0)
            btnImprimir.Enabled = True
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click


        Dim forma As New frmReportes
        Dim reporte As New rpCierreMes

        reporte.SetDataSource(dtReporte)
        forma.crvReportes.ReportSource = reporte

        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
            forma.crvReportes.ShowExportButton = True
        Else
            forma.crvReportes.ShowExportButton = False
        End If
        'forma.crvReportes.RefreshReport = False
        'forma.crvReportes.DisplayGroupTree = False

        reporte.SetParameterValue("Oficina", cbOficina.Text & " - " & cbAlmacen.Text)
        reporte.SetParameterValue("Fecha", "DEL " & cbFecInicio.Value & " AL " & cbFecFinal.Value)
        reporte.SetParameterValue("Rubro", cbCodRubro.Text)
        forma.Text = "Reporte de Cierre de Mes"
        forma.ShowDialog()


    End Sub


    
End Class