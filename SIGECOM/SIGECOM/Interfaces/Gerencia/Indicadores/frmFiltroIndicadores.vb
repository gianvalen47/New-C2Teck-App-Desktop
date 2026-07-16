Imports System.ServiceModel
Public Class frmFiltroIndicadores
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private objReporteVentas As New ReporteVentaService.ReporteVentaServiceClient 'Ventas
    Private objLocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderiaServiceClient 'Almacen
    Private objPedidoImportacion As New PedidoImportService.PedidoImportServiceClient 'Importaciones
    Private objJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficinasv As DataTable
    Private dtOficinasc As DataTable
    Private dtOficinasva As DataTable
    Private dtOficinasvm As DataTable
    Private dtoficinasps As DataTable
    Private dtoficinaspf As DataTable

    Private dtVendedor As DataTable
    Private dtVendedorc As DataTable

    Private dtAlmacenes As DataTable
    Private dtAlmacenc As DataTable
    Private dtAlmacenva As DataTable
    Private dtAlmacenvm As DataTable
    Private dtAlmacenps As DataTable
    Private dtAlmacenpf As DataTable
    Private dtMotivo As DataTable

    Private dtProveedores As DataTable
    Private dtProveedorespf As DataTable

    Private dtSupervisor As DataTable
    Private dtSemaforo As DataTable

    Private IdCliente As Integer
    Private IdClientec As Integer
    Private IdMercaderiava = ""
    Private IdMercaderiaps = ""
    Private IdMercaderiapf As Integer

    Private IdMarcava = ""
    Private IdMercaderiavm = ""
    Private IdMarcavm = ""
    Private idMarcaps = ""
    Private idMarcapf = ""

    Private dtMeses As DataTable
    Private dtAnio As DataTable
    Private Tipo As Integer



    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oCotizacionService.Close()
            objReporteVentas.Close()
            objLocacionMercaderia.Close()
            objPedidoImportacion.Close()
            objJobService.Close()
            oSeguridadService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oCotizacionService.Abort()
            objReporteVentas.Abort()
            objLocacionMercaderia.Abort()
            objPedidoImportacion.Abort()
            objJobService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oCotizacionService.Abort()
            objReporteVentas.Abort()
            objLocacionMercaderia.Abort()
            objPedidoImportacion.Abort()
            objJobService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 97)
        '/*************************************************************************************/

        llenarComboVenta()
        oSeguridadService.RegistrarVisitaOpciones(97, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
    Private Sub frmSugerencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtanio.Value = Today.Year
        'txtanioc.Value = Today.Year
        'cmbMes.Value = Today.Month
        'cmdmesc.Value = Today.Month
        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecIniciov.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinalv.Value = Fecha
        cbFecIniciov.Select()

        'listaDatos()
        SeleccionTab(0)


    End Sub
    Private Sub frmSugerencia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub llenarComboVenta()

        '======================================= OFICINAS - VENTAS ===========================================
        Try
            dtOficinasv = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinasv.Rows.InsertAt(getRowTodos(dtOficinasv), 0)
            cmbOficinasv.DataSource = dtOficinasv
            cmbOficinasv.DropDownList.DataMember = dtOficinasv.Columns("DesOfi").ToString
            cmbOficinasv.DropDownList.DisplayMember = dtOficinasv.Columns("DesOfi").ToString
            cmbOficinasv.DropDownList.ValueMember = dtOficinasv.Columns("CodOfi").ToString
            cmbOficinasv.DropDownList.Columns(0).DataMember = dtOficinasv.Columns("CodOfi").ToString
            cmbOficinasv.DropDownList.Columns(1).DataMember = dtOficinasv.Columns("DesOfi").ToString
            cmbOficinasv.SelectedIndex = 0
            dtOficinasv = Nothing

            '======================================= Vendedor - VENTAS ===========================================
            dtVendedor = oMaestroService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowTodos(dtVendedor), 0)
            cmbVendedorv.DataSource = dtVendedor
            cmbVendedorv.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedorv.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedorv.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.SelectedIndex = 0
            dtVendedor = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub
    Private Sub llenarComboCotizacion()
        Try
            '======================================= OFICINAS COTIZACION =================================
            dtOficinasc = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinasc.Rows.InsertAt(getRowTodos(dtOficinasc), 0)
            cmbOficinasc.DataSource = dtOficinasc
            cmbOficinasc.DropDownList.DataMember = dtOficinasc.Columns("DesOfi").ToString
            cmbOficinasc.DropDownList.DisplayMember = dtOficinasc.Columns("DesOfi").ToString
            cmbOficinasc.DropDownList.ValueMember = dtOficinasc.Columns("CodOfi").ToString
            cmbOficinasc.DropDownList.Columns(0).DataMember = dtOficinasc.Columns("CodOfi").ToString
            cmbOficinasc.DropDownList.Columns(1).DataMember = dtOficinasc.Columns("DesOfi").ToString
            cmbOficinasc.SelectedIndex = 0
            dtOficinasc = Nothing

            '======================================= Vendedor - VENTAS ===========================================
            dtVendedorc = oMaestroService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedorc.Rows.InsertAt(getRowTodos(dtVendedorc), 0)
            cmbVendedorc.DataSource = dtVendedorc
            cmbVendedorc.DropDownList.DataMember = dtVendedorc.Columns("ApeNom").ToString
            cmbVendedorc.DropDownList.DisplayMember = dtVendedorc.Columns("ApeNom").ToString
            cmbVendedorc.DropDownList.ValueMember = dtVendedorc.Columns("IdPer").ToString
            cmbVendedorc.DropDownList.Columns(0).DataMember = dtVendedorc.Columns("IdPer").ToString
            cmbVendedorc.DropDownList.Columns(1).DataMember = dtVendedorc.Columns("ApeNom").ToString
            cmbVendedorc.SelectedIndex = 0
            dtVendedorc = Nothing

            '======================================= MOTIVO COTIZACION ===================================
            dtMotivo = oCotizacionService.MostrarTipoRechazo.Tables(0)
            dtMotivo.Rows.InsertAt(getRowTodos(dtMotivo), 0)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdTipo").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdTipo").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("Nombre").ToString
            cmbMotivo.SelectedIndex = 0
            dtMotivo = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
      
    End Sub
    Private Sub llenarComboVentasAlmacenes()
        Try
            '======================================= OFICINAS VENTAS ALMACENES =================================
            dtOficinasva = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinasva.Rows.InsertAt(getRowTodos(dtOficinasva), 0)
            cmbOficinava.DataSource = dtOficinasva
            cmbOficinava.DropDownList.DataMember = dtOficinasva.Columns("DesOfi").ToString
            cmbOficinava.DropDownList.DisplayMember = dtOficinasva.Columns("DesOfi").ToString
            cmbOficinava.DropDownList.ValueMember = dtOficinasva.Columns("CodOfi").ToString
            cmbOficinava.DropDownList.Columns(0).DataMember = dtOficinasva.Columns("CodOfi").ToString
            cmbOficinava.DropDownList.Columns(1).DataMember = dtOficinasva.Columns("DesOfi").ToString
            cmbOficinava.SelectedIndex = 0
            dtOficinasva = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub
    Private Sub llenarComboPedidoSemana()
        Try
            '======================================= OFICINAS PEDIDOS SEMANA =================================
            dtoficinasps = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtoficinasps.Rows.InsertAt(getRowTodos(dtoficinasps), 0)
            cmbOficinaps.DataSource = dtoficinasps
            cmbOficinaps.DropDownList.DataMember = dtoficinasps.Columns("DesOfi").ToString
            cmbOficinaps.DropDownList.DisplayMember = dtoficinasps.Columns("DesOfi").ToString
            cmbOficinaps.DropDownList.ValueMember = dtoficinasps.Columns("CodOfi").ToString
            cmbOficinaps.DropDownList.Columns(0).DataMember = dtoficinasps.Columns("CodOfi").ToString
            cmbOficinaps.DropDownList.Columns(1).DataMember = dtoficinasps.Columns("DesOfi").ToString
            cmbOficinaps.SelectedIndex = 0
            dtoficinasps = Nothing

            '======================================= PROVEEDORES ================================================
            dtProveedores = objPedidoImportacion.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedores.Rows.InsertAt(getRowTodos(dtProveedores), 0)
            cmbIdProveedorps.DataSource = dtProveedores
            cmbIdProveedorps.DropDownList.DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdProveedorps.DropDownList.DisplayMember = dtProveedores.Columns("DesProv").ToString
            cmbIdProveedorps.DropDownList.ValueMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdProveedorps.DropDownList.Columns(0).DataMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdProveedorps.DropDownList.Columns(1).DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdProveedorps.SelectedIndex = 0
            dtProveedores = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarComboVentasMaterial()
        Try
            '======================================= OFICINAS VENTAS MATERIAL =================================
            dtOficinasvm = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinasvm.Rows.InsertAt(getRowTodos(dtOficinasvm), 0)
            cmbOficinavm.DataSource = dtOficinasvm
            cmbOficinavm.DropDownList.DataMember = dtOficinasvm.Columns("DesOfi").ToString
            cmbOficinavm.DropDownList.DisplayMember = dtOficinasvm.Columns("DesOfi").ToString
            cmbOficinavm.DropDownList.ValueMember = dtOficinasvm.Columns("CodOfi").ToString
            cmbOficinavm.DropDownList.Columns(0).DataMember = dtOficinasvm.Columns("CodOfi").ToString
            cmbOficinavm.DropDownList.Columns(1).DataMember = dtOficinasvm.Columns("DesOfi").ToString
            cmbOficinavm.SelectedIndex = 0
            dtOficinasvm = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
      
    End Sub

    Private Sub llenarComboPedidosFechaLlegada()
        Try
            '======================================= OFICINAS PEDIDOS SEMANA =================================
            dtoficinaspf = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtoficinaspf.Rows.InsertAt(getRowTodos(dtoficinaspf), 0)
            cmbOficinapf.DataSource = dtoficinaspf
            cmbOficinapf.DropDownList.DataMember = dtoficinaspf.Columns("DesOfi").ToString
            cmbOficinapf.DropDownList.DisplayMember = dtoficinaspf.Columns("DesOfi").ToString
            cmbOficinapf.DropDownList.ValueMember = dtoficinaspf.Columns("CodOfi").ToString
            cmbOficinapf.DropDownList.Columns(0).DataMember = dtoficinaspf.Columns("CodOfi").ToString
            cmbOficinapf.DropDownList.Columns(1).DataMember = dtoficinaspf.Columns("DesOfi").ToString
            cmbOficinapf.SelectedIndex = 0
            dtoficinaspf = Nothing

            '======================================= PROVEEDORES ================================================
            dtProveedorespf = objPedidoImportacion.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedorespf.Rows.InsertAt(getRowTodos(dtProveedorespf), 0)
            cmbIdProveedorpf.DataSource = dtProveedorespf
            cmbIdProveedorpf.DropDownList.DataMember = dtProveedorespf.Columns("DesProv").ToString
            cmbIdProveedorpf.DropDownList.DisplayMember = dtProveedorespf.Columns("DesProv").ToString
            cmbIdProveedorpf.DropDownList.ValueMember = dtProveedorespf.Columns("IdProveedor").ToString
            cmbIdProveedorpf.DropDownList.Columns(0).DataMember = dtProveedorespf.Columns("IdProveedor").ToString
            cmbIdProveedorpf.DropDownList.Columns(1).DataMember = dtProveedorespf.Columns("DesProv").ToString
            cmbIdProveedorpf.SelectedIndex = 0
            dtProveedorespf = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub

    Private Sub llenarComboServicios()
        Try
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            '--------------------------------------------------------------------------------------------------
            dtSemaforo = New DataTable
            dtSemaforo.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtSemaforo.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            dtSemaforo.Rows.Add(New Object() {"", "(Todos)"})
            dtSemaforo.Rows.Add(New Object() {"V", "Verde"})
            dtSemaforo.Rows.Add(New Object() {"A", "Amarillo"})
            dtSemaforo.Rows.Add(New Object() {"R", "Rojo"})

            cmbSemaforo.DataSource = dtSemaforo
            cmbSemaforo.DropDownList.DataMember = dtSemaforo.Columns("nombre").ToString
            cmbSemaforo.DropDownList.DisplayMember = dtSemaforo.Columns("nombre").ToString
            cmbSemaforo.DropDownList.ValueMember = dtSemaforo.Columns("codigo").ToString
            cmbSemaforo.DropDownList.Columns(0).DataMember = dtSemaforo.Columns("codigo").ToString
            cmbSemaforo.DropDownList.Columns(1).DataMember = dtSemaforo.Columns("nombre").ToString
            cmbSemaforo.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombosTablero()

        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            'dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdClientev.ButtonClick
        limpiarVentas()
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdClientev.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdClientev.Text = "(Todos)"
                IdCliente = 0
            End If
        End If
    End Sub
    Private Sub txtIdClientec_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdClientec.ButtonClick
        limpiarCotizacion()
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdClientec.Text = frm.descripcion
                IdClientec = frm.codigo
            Else
                txtIdClientev.Text = "(Todos)"
                IdClientec = 0
            End If
        End If
    End Sub

    Private Sub txtIdMarcava_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMarcava.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMarcava.Text = frm.descripcion
                IdMarcava = frm.codigo
            End If
        End If
    End Sub
    Private Sub txtIdMarcavm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMarcavm.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMarcavm.Text = frm.descripcion
                IdMarcavm = frm.codigo
            End If
        End If
    End Sub
    Private Sub txtIdMercaderiavm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMercaderiavm.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMercaderiavm.Text = frm.codigo
                IdMercaderiavm = frm.codigo
            End If
        End If
    End Sub
    Private Sub txtIdMercaderiava_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMercaderiava.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMercaderiava.Text = frm.codigo
                IdMercaderiava = frm.codigo
            Else
                txtIdMercaderiava.Text = ""
                IdMercaderiava = ""
            End If
        End If
    End Sub
    Private Sub txtIdMercaderiaps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMercaderiaps.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMercaderiaps.Text = frm.codigo
                IdMercaderiaps = frm.codigo
            End If
        End If
    End Sub
    Private Sub txtIdMercaderiapf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMercaderiapf.Click
        Dim frm As New frmBuscarLocacionMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMercaderiapf.Text = frm.codigo
                IdMercaderiapf = frm.codigo
            End If
        End If
    End Sub

    Private Sub txtIdMarcaps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMarcaps.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMarcaps.Text = frm.descripcion
                idMarcaps = frm.codigo
            End If
        End If
    End Sub
    Private Sub txtIdMarcapf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdMarcapf.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdMarcapf.Text = frm.descripcion
                idMarcapf = frm.codigo
            End If
        End If
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cmbVendedorv.ValueChanged

        ' listaDatos()
    End Sub
    Private Sub cmbLocacionv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  listaDatos()
    End Sub

    Private Sub cmbOficinasv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinasv.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinasv.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowTodos(dtAlmacenes), 0)
            cmbAlmacenv.DataSource = dtAlmacenes
            'cmbAlmacenv.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbAlmacenv.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbAlmacenv.DropDownList.ValueMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbAlmacenv.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbAlmacenv.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbAlmacenv.SelectedIndex = 0
            Else
                cmbAlmacenv.Value = ""
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub cmbOficinasc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinasc.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenc = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinasc.Value, Session.sCodUsu).Tables(0)
            dtAlmacenc.Rows.InsertAt(getRowTodos(dtAlmacenc), 0)
            cmbAlmacenc.DataSource = dtAlmacenc
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbAlmacenc.DropDownList.DisplayMember = dtAlmacenc.Columns("DesAlm").ToString
            cmbAlmacenc.DropDownList.ValueMember = dtAlmacenc.Columns("CodAlm").ToString
            cmbAlmacenc.DropDownList.Columns(0).DataMember = dtAlmacenc.Columns("CodAlm").ToString
            cmbAlmacenc.DropDownList.Columns(1).DataMember = dtAlmacenc.Columns("DesAlm").ToString
            If dtAlmacenc.Rows.Count > 0 Then
                cmbAlmacenc.SelectedIndex = 0
            Else
                cmbAlmacenc.Value = ""
            End If
            dtAlmacenc = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub cmbOficinava_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinava.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenva = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinava.Value, Session.sCodUsu).Tables(0)
            dtAlmacenva.Rows.InsertAt(getRowTodos(dtAlmacenva), 0)
            cmbAlmacenva.DataSource = dtAlmacenva
            cmbAlmacenva.DropDownList.DisplayMember = dtAlmacenva.Columns("DesAlm").ToString
            cmbAlmacenva.DropDownList.ValueMember = dtAlmacenva.Columns("CodAlm").ToString
            cmbAlmacenva.DropDownList.Columns(0).DataMember = dtAlmacenva.Columns("CodAlm").ToString
            cmbAlmacenva.DropDownList.Columns(1).DataMember = dtAlmacenva.Columns("DesAlm").ToString
            If dtAlmacenva.Rows.Count > 0 Then
                cmbAlmacenva.SelectedIndex = 0
            Else
                cmbAlmacenva.Value = ""
            End If
            dtAlmacenva = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub cmbOficinaps_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinaps.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenps = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinaps.Value, Session.sCodUsu).Tables(0)
            dtAlmacenps.Rows.InsertAt(getRowTodos(dtAlmacenps), 0)
            cmbAlmacenps.DataSource = dtAlmacenps
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbAlmacenps.DropDownList.DisplayMember = dtAlmacenps.Columns("DesAlm").ToString
            cmbAlmacenps.DropDownList.ValueMember = dtAlmacenps.Columns("CodAlm").ToString
            cmbAlmacenps.DropDownList.Columns(0).DataMember = dtAlmacenps.Columns("CodAlm").ToString
            cmbAlmacenps.DropDownList.Columns(1).DataMember = dtAlmacenps.Columns("DesAlm").ToString

            cmbAlmacenps.SelectedIndex = 0
            dtAlmacenps = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub cmbOficinavm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinavm.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenvm = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinavm.Value, Session.sCodUsu).Tables(0)
            dtAlmacenvm.Rows.InsertAt(getRowTodos(dtAlmacenvm), 0)
            cmbAlmacenvm.DataSource = dtAlmacenvm
            cmbAlmacenvm.DropDownList.DisplayMember = dtAlmacenvm.Columns("DesAlm").ToString
            cmbAlmacenvm.DropDownList.ValueMember = dtAlmacenvm.Columns("CodAlm").ToString
            cmbAlmacenvm.DropDownList.Columns(0).DataMember = dtAlmacenvm.Columns("CodAlm").ToString
            cmbAlmacenvm.DropDownList.Columns(1).DataMember = dtAlmacenvm.Columns("DesAlm").ToString
            If dtAlmacenvm.Rows.Count > 0 Then
                cmbAlmacenvm.SelectedIndex = 0
            Else
                cmbAlmacenvm.Value = ""
            End If
            dtAlmacenvm = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub cmbOficinapf_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinapf.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenpf = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinapf.Value, Session.sCodUsu).Tables(0)
            dtAlmacenpf.Rows.InsertAt(getRowTodos(dtAlmacenpf), 0)
            cmbAlmacenpf.DataSource = dtAlmacenpf
            cmbAlmacenpf.DropDownList.DisplayMember = dtAlmacenpf.Columns("DesAlm").ToString
            cmbAlmacenpf.DropDownList.ValueMember = dtAlmacenpf.Columns("CodAlm").ToString
            cmbAlmacenpf.DropDownList.Columns(0).DataMember = dtAlmacenpf.Columns("CodAlm").ToString
            cmbAlmacenpf.DropDownList.Columns(1).DataMember = dtAlmacenpf.Columns("DesAlm").ToString
            If dtAlmacenpf.Rows.Count > 0 Then
                cmbAlmacenpf.SelectedIndex = 0
            Else
                cmbAlmacenpf.Value = ""
            End If
            dtAlmacenpf = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub limpiarVentas()
        txtIdClientev.Text = ""
    End Sub
    Private Sub limpiarCotizacion()
        txtIdClientec.Text = ""
    End Sub
    Private Sub limpiarVentasAlmacen()
        txtIdMercaderiava.Text = ""
        txtIdMarcava.Text = ""
    End Sub

    Private Sub TabOpciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cbFecInicioSer.KeyPress _
        , cbFecFinalSer.KeyPress _
        , cmbMes.KeyPress _
        , txtanio.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TabOpciones_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles TabOpciones.SelectedTabChanged
        SeleccionTab(TabOpciones.SelectedIndex)
        enableOpciones()
        'cmbOficinasv.SelectedIndex = 0
    End Sub

    Private Sub enableOpciones()
        Try
            '-------------------------------------SERVICIOS--------------------------------------------
            Select Case TabOpciones.SelectedIndex
                Case 0
                    '-----------'Ventas------
                    If dgvVentas.RowCount = 0 Then
                        btnExcel.Enabled = False
                    Else
                        btnExcel.Enabled = True
                    End If
                Case 1
                    '-----------'Cotizaciones------
                    If dgvCotizacion.RowCount = 0 Then
                        btnExcelc.Enabled = False
                    Else
                        btnExcelc.Enabled = True
                    End If
                Case 2
                    '-----------'Ventas Almacen------
                    If dgVentasAlmacen.RowCount = 0 Then
                        btnExcelva.Enabled = False
                    Else
                        btnExcelva.Enabled = True
                    End If
                Case 3
                    '-----------'Ventas Material------
                    If dgVentasMateriales.RowCount = 0 Then
                        btnExcelvm.Enabled = False
                    Else
                        btnExcelvm.Enabled = True
                    End If
                Case 4
                    '-----------'Pedidos Semana------
                    If dgPedidosSemana.RowCount = 0 Then
                        btnExcelps.Enabled = False
                    Else
                        btnExcelps.Enabled = True
                    End If
                Case 5
                    'Pedidos Fecha Llegada
                    If dgPedidosFechaLlegada.RowCount = 0 Then
                        btnExcelpf.Enabled = False
                    Else
                        btnExcelpf.Enabled = True
                    End If

                Case 6
                    '-----------'Servicios------------
                    If dgDetalleServicios.RowCount = 0 Then
                        btnExcelSer.Enabled = False
                        btnImprimirSer.Enabled = False
                        btnPorcentaje.Enabled = False
                    Else
                        btnExcelSer.Enabled = True
                        btnImprimirSer.Enabled = True
                        btnPorcentaje.Enabled = True
                    End If
                Case 7
                    '-----------'Tablero------------
                    If dgvTablero.RowCount = 0 Then
                        btnExcelTab.Enabled = False
                    Else
                        btnExcelTab.Enabled = True
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub
    Private Sub SeleccionTab(ByVal Indice As Int16)
        Select Case TabOpciones.SelectedIndex
            Case 0 'Ventas
                Try
                    limpiarVentas()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 1 'Cotizaciones
                Try
                    limpiarCotizacion()
                    llenarComboCotizacion()

                    Dim Mes, Anio, meses As Integer
                    Dim Fecha As Date

                    Fecha = Today
                    meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
                    If meses = 1 Then
                        Mes = Month(Today)
                        Anio = Year(Today)
                    Else
                        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
                    End If
                    cbFecInicioc.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
                    cbFecFinc.Value = Fecha
                    cbFecInicioc.Select()
                    limpiarVentasAlmacen()
                    llenarComboVentasAlmacenes()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try

            Case 2 'Ventas Almacen
                Try
                    Dim Mes, Anio, meses As Integer
                    Dim Fecha As Date

                    Fecha = Today
                    meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
                    If meses = 1 Then
                        Mes = Month(Today)
                        Anio = Year(Today)
                    Else
                        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
                    End If
                    cbFecIniciova.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
                    cbFecFinva.Value = Fecha
                    cbFecIniciova.Select()
                    limpiarVentasAlmacen()
                    llenarComboVentasAlmacenes()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try

            Case 3 'Ventas Material
                Try
                    Dim Mes, Anio, meses As Integer
                    Dim Fecha As Date

                    Fecha = Today
                    meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
                    If meses = 1 Then
                        Mes = Month(Today)
                        Anio = Year(Today)
                    Else
                        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
                    End If
                    cbFecIniciovm.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
                    cbFecFinvm.Value = Fecha
                    cbFecIniciovm.Select()

                    'Me.dgVentasMateriales.SetDataBinding(dtlistarGrilla, 0)
                    llenarComboVentasMaterial()

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 4 'Pedidos Semana
                Try
                    Dim Mes, Anio, meses As Integer
                    Dim Fecha As Date

                    Fecha = Today
                    meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
                    If meses = 1 Then
                        Mes = Month(Today)
                        Anio = Year(Today)
                    Else
                        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
                    End If
                    cbFecIniciops.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
                    cbFecFinps.Value = Fecha
                    cbFecIniciops.Select()

                    llenarComboPedidoSemana()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 5 'Pedidos Fecha Llegada
                Try
                    Dim Mes, Anio, meses As Integer
                    Dim Fecha As Date

                    Fecha = Today
                    meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
                    If meses = 1 Then
                        Mes = Month(Today)
                        Anio = Year(Today)
                    Else
                        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
                    End If
                    cbFecIniciopf.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
                    cbFecFinpf.Value = Fecha
                    cbFecIniciopf.Select()

                    llenarComboPedidosFechaLlegada()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 6 'Servicios
                Try
                    Dim Mes, Anio, meses As Integer
                    Dim Fecha As Date

                    Fecha = Today
                    meses = Month(Today) 'IIf(Month(Fecha) = 1, 12, Month(Fecha))
                    If meses = 1 Then
                        Mes = Month(Today)
                        Anio = Year(Today)
                    Else
                        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
                    End If
                    cbFecInicioSer.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
                    cbFecFinalSer.Value = Fecha
                    cbFecInicioSer.Select()

                    llenarComboServicios()
                    txtRojo.Text = "R"
                    txtAmbar.Text = "A"
                    txtVerde.Text = "V"
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 7
                Try
                    Dim estilo As New Estilo
                    estilo.cargaEstiloDataDrid(dgvTablero)
                    dgvTablero.AutoGenerateColumns = True
                    txtanio.Value = Today.Year
                    llenarCombosTablero()
                    txtanio.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
        End Select
    End Sub
    '********************BOTONES BUSCAR ****************************
    '-----------BTNVENTAS------
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim dtReporteVenta As DataTable
        dtReporteVenta = objReporteVentas.ReporteIndicadores(Session.sCodEmp, cmbOficinasv.Value, IIf(cmbAlmacenv.Text = "(Todos)", "", cmbAlmacenv.Value), _
                     cbFecIniciov.Value, cbFecFinalv.Value, toNumber(IdCliente), IIf(cmbVendedorv.Text = "(Todos)", 0, cmbVendedorv.Value), _
                     0, IIf(rbFacturacion.Checked = True, 1, 2), 2).Tables(0)
        dgventas.DataSource = dtReporteVenta
        Me.dgvVentas.SetDataBinding(dtReporteVenta, 0)
        enableOpciones()
    End Sub
    '-----------BTNCOTIZACION------
    Private Sub btnBuscarc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarc.Click
        Dim dtReporteCotizacion As DataTable
        dtReporteCotizacion = objReporteVentas.ReporteIndicadores(Session.sCodEmp, cmbOficinasc.Value, IIf(cmbAlmacenc.Text = "(Todos)", "", cmbAlmacenc.Value), _
                    cbFecInicioc.Value, cbFecFinc.Value, toNumber(IdClientec), IIf(cmbVendedorv.Text = "(Todos)", 0, cmbVendedorc.Value), _
                    IIf(cmbMotivo.Text = "(Todos)", 0, cmbMotivo.Value), 0, 1).Tables(0)
        Me.dgvCotizacion.SetDataBinding(dtReporteCotizacion, 0)
        dcotizacion.DataSource = dtReporteCotizacion
        enableOpciones()
    End Sub

    '-----------BTNVENTAS - ALMACEN------
    Private Sub btnBuscarva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarva.Click
        Dim dtlocacionMercaderia As New DataTable
        'If dtlocacionMercaderia.Rows.Count > 0 Then
        dtlocacionMercaderia = objLocacionMercaderia.ReporteIndicadores(Session.sCodEmp, cmbOficinava.Value, IIf(cmbAlmacenva.Text = "(Todos)", "", cmbAlmacenva.Value), _
                                                                     cbFecIniciova.Value, cbFecFinva.Value, IdMercaderiava, _
                                                                     IdMarcava, 1).Tables(0)
        dventasAlmacenes.DataSource = dtlocacionMercaderia
        Me.dgVentasAlmacen.SetDataBinding(dtlocacionMercaderia, 0)
        enableOpciones()
        'Else
        'MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        'End If
    End Sub
    '-----------BTNVENTAS - MATERIAL------
    Private Sub btnBuscarvm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarvm.Click
        Dim dtlocacionMercaderiaMaterial As New DataTable

        dtlocacionMercaderiaMaterial = objLocacionMercaderia.ReporteIndicadores(Session.sCodEmp, cmbOficinavm.Value, IIf(cmbAlmacenvm.Text = "(Todos)", "", cmbAlmacenvm.Value), _
                                                                                cbFecIniciovm.Value, cbFecFinvm.Value, IdMercaderiavm, _
                                                                                IdMarcavm, 2).Tables(0)
        dvenntasMateriales.DataSource = dtlocacionMercaderiaMaterial
        Me.dgVentasMateriales.SetDataBinding(dtlocacionMercaderiaMaterial, 0)
        enableOpciones()
    End Sub

    '-----------BTNPEDIDOS - SEMANA------
    Private Sub btnBuscarps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarps.Click
        Dim dtPedidosSemana As New DataTable
        dtPedidosSemana = objPedidoImportacion.ReporteIndicadores(Session.sCodEmp, cmbOficinaps.Value, IIf(cmbAlmacenps.Text = "(Todos)", "", cmbAlmacenps.Value), _
                                     cbFecIniciops.Value, cbFecFinps.Value, IIf(cmbIdProveedorps.Text = "(Todos)", 0, cmbIdProveedorps.Value), IdMercaderiaps, _
                                        idMarcaps, toNumber(txtNumDoc.Text), 1).Tables(0)
        dpedidosSemana.DataSource = dtPedidosSemana
        Me.dgPedidosSemana.SetDataBinding(dtPedidosSemana, 0)
        enableOpciones()
    End Sub

    '-----------BTNPEDIDOS - FECHA - LLEGADA------
    Private Sub btnBuscarpf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarpf.Click
        Dim dtPedidosFechaLlegada As New DataTable
        dtPedidosFechaLlegada = objPedidoImportacion.ReporteIndicadores(Session.sCodEmp, cmbOficinapf.Value, IIf(cmbAlmacenpf.Text = "(Todos)", "", cmbAlmacenpf.Value), _
                                        cbFecIniciopf.Value, cbFecFinpf.Value, IIf(cmbIdProveedorpf.Text = "(Todos)", 0, cmbIdProveedorpf.Value), IdMercaderiapf, _
                                        idMarcapf, toNumber(txtNumDocpf.Text), 2).Tables(0)
        dpedidosFechaLlegada.DataSource = dtPedidosFechaLlegada
        Me.dgPedidosFechaLlegada.SetDataBinding(dtPedidosFechaLlegada, 0)
        enableOpciones()
    End Sub
    '-----------BTNPEDIDOS - SERVICIOS------
    Private Sub btnBuscarSer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSer.Click, cmbSupervisor.ValueChanged, cmbSemaforo.ValueChanged
        Dim dtPedidosSer As New DataTable
        dtPedidosSer = objJobService.ReporteIndicadores(Session.sCodEmp, cbFecInicioSer.Value, cbFecFinalSer.Value, 0, IIf(cmbSupervisor.Text = "(Todos)", 0, cmbSupervisor.Value), cmbSemaforo.Value, 1, 0, 0).Tables(0)
        dServicios.DataSource = dtPedidosSer
        dgDetalleServicios.DataSource = dtPedidosSer
        'DataGridView1.DataSource = dtPedidosSer
        enableOpciones()
    End Sub
    '-----------BTNPEDIDOS - TABLERO------
    Private Sub btnBuscarTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTab.Click
        Try
            Dim Fecha1 As Date
            Dim Fecha2 As Date

            Fecha1 = "01/" & IIf(cmbMes.Value > 9, cmbMes.Value, "0" & cmbMes.Value) & "/" & txtanio.Value
            Fecha2 = DateSerial(txtanio.Value, cmbMes.Value + 1, 0)
            dgvTablero.DataSource = Nothing
            Dim dtPedidosTablero As DataTable
            dtPedidosTablero = objReporteVentas.ReporteIndicadores(Session.sCodEmp, "", "", Fecha1, Fecha2, 0, 0, 0, 0, Tipo).Tables(0)
            dgvTablero.DataSource = dtPedidosTablero

            If dgvTablero.RowCount < 1 Then
                MsgBox("No existen registros para esta consulta", MsgBoxStyle.Information)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    '********************BOTONES EXCEL ****************************
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim Export As Boolean = ExportarExcel(dgventas)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub

    Private Sub btnExcelc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelc.Click
        Dim Export As Boolean = ExportarExcel(dcotizacion)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub

    Private Sub btnExcelva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelva.Click
        Dim Export As Boolean = ExportarExcel(dventasAlmacenes)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub

    Private Sub btnExcelvm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelvm.Click
        Dim Export As Boolean = ExportarExcel(dvenntasMateriales)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub

    Private Sub btnExcelps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelps.Click
        Dim Export As Boolean = ExportarExcel(dpedidosSemana)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub

    Private Sub btnExcelpf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelpf.Click
        Dim Export As Boolean = ExportarExcel(dpedidosFechaLlegada)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub
    Private Sub btnExcelSer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelSer.Click
        Dim Export As Boolean = ExportarExcel(dServicios)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub
    Private Sub btnExcelTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelTab.Click
        Dim Export As Boolean = ExportarExcel(dgvTablero)
        If Export Then
            MsgBox("Se realizó la exportación correctamente ")
        End If
    End Sub


    '****************************BOTON IMPRIMIR****************************************************

    Private Sub btnImprimirSer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirSer.Click
        Dim forma As New frmReportes
        Dim reporte As New rpRepJobSer
        Dim dtReporte As New DataTable

        dtReporte = objJobService.ReporteIndicadores(Session.sCodEmp, cbFecInicioSer.Value, cbFecFinalSer.Value, 0, IIf(cmbSupervisor.Text = "(Todos)", 0, cmbSupervisor.Value), cmbSemaforo.Value, 1, 0, 0).Tables(0)
        If dtReporte.Rows.Count = 0 Then
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            reporte.SetDataSource(dtReporte)
            forma.crvReportes.ReportSource = reporte
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.crvReportes.DisplayGroupTree = False
            'forma.crvReportes.RefreshReport = False

            reporte.SetParameterValue("FecInicio", cbFecInicioSer.Text)
            reporte.SetParameterValue("FecFinal", cbFecFinalSer.Text)
            reporte.SetParameterValue("Supervisor", cmbSupervisor.Text)
            forma.Text = "Reporte de Seguimiento de Jobs"
            forma.ShowDialog()
        End If
    End Sub

    '****************************BOTON PORCENTAJES****************************************************

    Private Sub btnPorcentaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorcentaje.Click
        Dim forma As New frmReportes
        Dim reporte As New rpRepJobSerEst
        Dim dtReporte As New DataView
        Dim Filtro As String = "A"

        dtReporte = objJobService.ReporteIndicadores(Session.sCodEmp, cbFecInicioSer.Value, cbFecFinalSer.Value, 0, IIf(cmbSupervisor.Text = "(Todos)", 0, cmbSupervisor.Value), "", 2, 0, 0).Tables(0).DefaultView
        If dtReporte.Count = 0 Then
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else
            dtReporte.RowFilter = "Semaforo<> '" & Filtro & "'"
            reporte.SetDataSource(dtReporte)
            forma.crvReportes.ReportSource = reporte
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.crvReportes.DisplayGroupTree = False
            'forma.crvReportes.RefreshReport = False

            reporte.SetParameterValue("FecInicio", cbFecInicioSer.Text)
            reporte.SetParameterValue("FecFinal", cbFecFinalSer.Text)
            reporte.SetParameterValue("Supervisor", cmbSupervisor.Text)
            forma.Text = "Reporte de Seguimiento de Jobs"
            forma.ShowDialog()
        End If
    End Sub

    '****************************BOTON OPCIONES TABLERO****************************************************

    Private Sub cbOpciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBaterias.CheckedChanged, rbChimbote.CheckedChanged, rbFiltros.CheckedChanged, rbGrupElec.CheckedChanged, rbManoObra.CheckedChanged, rbMotores.CheckedChanged, rbRepConsig.CheckedChanged, rbRepServ.CheckedChanged, rbVenOfi.CheckedChanged
        If rbMotores.Checked Then
            Tipo = 3
        ElseIf rbGrupElec.Checked Then
            Tipo = 4
        ElseIf rbRepConsig.Checked Then
            Tipo = 5
        ElseIf rbVenOfi.Checked Then
            Tipo = 6
        ElseIf rbRepServ.Checked Then
            Tipo = 7
        ElseIf rbManoObra.Checked Then
            Tipo = 8
        ElseIf rbFiltros.Checked Then
            Tipo = 9
        ElseIf rbBaterias.Checked Then
            Tipo = 10
        ElseIf rbChimbote.Checked Then
            Tipo = 11
        End If
    End Sub
End Class
