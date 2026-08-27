Public Class frmPedidosImportacion

    Private oMaestroService As New MaestroService.MaestroClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtProveedores As DataTable

    'Dim Fecha As Date
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumPed.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdCliente.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtFecFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    mostrar()
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumPed.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdCliente.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtFecFin.KeyPress _
                      , btnBuscar.KeyPress _
                      , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPed.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdPedidoImp").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmPedidosImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

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
        txtFecIni.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        txtFecFin.Text = Fecha
        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPedidoImportService) = False Then
                oPedidoImportService.Close()
            End If
            If isClosed(oImportacionService) = False Then
                oImportacionService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal cod_proveedor As String)
    '    If type_process = "update" Or type_process = "insert" Then
    '        cmbIdCliente.Value = toNumber(cod_proveedor)
    '        txtFecIni.Text = ""
    '        txtFecFin.Text = ""
    '        txtNumPed.Text = codigoCampo
    '    End If
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmPedidoImportacion
            frm.state_button = True
            frm.IdLocacion = cmbIdLocacion.Value
            frm.IdPedidoImp = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("update", frm.txtNumPed.Text, frm.IdCliente)
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdPedidoImp)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()

        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdPedidoImp").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New PedidoImportService.PedidoImport
                registro.IdPedidoImp = toNumber(dgvDatos.CurrentRow.Cells("IdPedidoImp").Text)
                estado_process = oPedidoImportService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                Dim registro As New PedidoImportService.PedidoImport
                Dim locacion As New PedidoImportService.Locacion
                Dim proveedor As New PedidoImportService.Proveedor
                Dim total As Double

                If toNumber(cmbIdLocacion.Value) = 0 Then
                    locacion.IdLocacion = -1
                    registro.Locacion = locacion
                Else
                    locacion.IdLocacion = toNumber(cmbIdLocacion.Value)
                    registro.Locacion = locacion
                End If
                proveedor.IdProveedor = toNumber(cmbIdCliente.Value)
                registro.Proveedor = proveedor
                registro.NumPed = toBlank(txtNumPed.Text)
                If toNull(txtFecIni.Text) <> Nothing Then
                    registro.FecIni = txtFecIni.Text
                End If
                If toNull(txtFecFin.Text) <> Nothing Then
                    registro.FecFin = txtFecFin.Text
                End If

                dtDatos = oPedidoImportService.Filtrar(registro).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                For Each Fila As DataRow In dtDatos.Rows

                    Dim contador As Double
                    contador = Fila.Item("TotPed")
                    total = total + contador
                Next
                txtTotGen.Text = total

                sslTotal.Text = "Total Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmPedidoImportacion
            frm.state_button = False
            frm.IdLocacion = cmbIdLocacion.Value
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.IdCliente = cmbIdCliente.Value
            frm.txtProveedor.Text = cmbIdCliente.Text
            frm.txtNumPed.Text = oPedidoImportService.MostrarNumPed(frm.IdCliente, frm.txtFecPed.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumPed.Text, frm.IdCliente)
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPedidoImp)
                mostrar()
                If frm.type_process = "insert" Then
                    ' RowPossesion(dgvDatos, dtDatos, "IdPedidoImp", frm.IdPedidoImp)
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Imprimir()
        ' Fecha = Today
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptPedidosImportaciones
            Dim dtReporte As New DataTable
            Dim IdPedidoImport As Integer = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text

            dtReporte = oPedidoImportService.Imprimir(IdPedidoImport).Tables(0)

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

                forma.Text = "Reporte de Orden de Pedidos de Importacion para Importar"
                'reporte.SetParameterValue("FecInicio", Fecha)

                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\PedidoInterno.xml")

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdPedidoImp").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= PROVEEDORES ================================================
            dtProveedores = oPedidoImportService.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedores.Rows.InsertAt(getRowTodos(dtProveedores), 0)
            cmbIdCliente.DataSource = dtProveedores
            cmbIdCliente.DropDownList.DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.DropDownList.DisplayMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.DropDownList.ValueMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdCliente.DropDownList.Columns(0).DataMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdCliente.DropDownList.Columns(1).DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.SelectedIndex = 0
            dtProveedores = Nothing
             
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        Actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                  cmbIdLocacion.ValueChanged _
                , cmbIdCliente.ValueChanged
        listaDatos()
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================

            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, IIf(Session.sCodUsu = "pgaray", "", Session.sCodUsu)).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
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
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub txtFecIni_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecIni.NoneButtonClick
        listaDatos()
    End Sub

    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecIni.ValueChanged
        listaDatos()
    End Sub

    Private Sub txtFecFin_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecFin.NoneButtonClick
        listaDatos()
    End Sub

    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecFin.ValueChanged
        listaDatos()
    End Sub

  
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
 _
        miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, _
        miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, miImprimir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Orden de Pedido de Importación."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Mostrar Orden de Pedido de Importación Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Orden de Pedido de Importación Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter
        sslError.Text = "Imprimir Orden de Pedido de Importación."
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biimprimir.Click, miImprimir.Click
        Imprimir()
    End Sub

    Private Sub biActualizarCanRec_Click(sender As Object, e As EventArgs) Handles biActualizarCanRec.Click, miActualizarCanRec.Click
        Try
            Dim forma As New frmPedidoImportacionActualizarRecibido
            forma.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Formulario")
        End Try
    End Sub

    Private Sub biHistorialCanRec_Click(sender As Object, e As EventArgs) Handles biHistorialCanRec.Click, miHistorialCanRec.Click
        Try
            Dim forma As New frmPedidoImportacionActualizarRecibidoHistorial
            forma.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Formulario")
        End Try
    End Sub

    Private Sub biRegistrarArchivos_Click(sender As Object, e As EventArgs) Handles biRegistrarArchivos.Click, miRegistrarArchivos.Click

        Try
            Dim frm As New frmPedidosImportacion_Archivos
            frm.IdPedidoImp = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text
            'frm.Nombre = dgvDatos.CurrentRow.Cells("Nombre").Value
            'frm.estado = dgvDatos.CurrentRow.Cells("AbrEstado").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DE LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biVerEstados_Click(sender As Object, e As EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            Dim frm As New frmPedidosImportacion_Estados

            frm.IdGuia = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text
            frm.Text = "Estados de la Orden de Pedido Nº : " + dgvDatos.CurrentRow.Cells("NumPed").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biFacturar_Click(sender As Object, e As EventArgs) Handles biFacturar.Click, miFacturar.Click

        Try
            Dim frm As New frmPedidosImportacion_Facturar
            frm.state_button = False
            frm.IdSerieImp = oPedidoImportService.ObtenerIdSerieImportacion(Session.sCodEmp)
            frm.IdPedidoImp = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text
            frm.codMon = dgvDatos.CurrentRow.Cells("CodMon").Text
            frm.txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "NumDoc", "IdSerieImp", frm.IdSerieImp)
            frm.lblUbicacion.Text = "Generar Factura de Importación"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                RowPossesion(dgvDatos, frm.IdPedidoImp)
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biActualizarFecPromesa_Click(sender As Object, e As EventArgs) Handles biActualizarFecPromesa.Click, miActualizarFecPromesa.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmPedidoImportacion_ActFecPromesa
                'frm.IdProvisional = toNumber(dgvDatos.CurrentRow.Cells("IdProvisional").Text)
                frm.IdPedidoImp = dgvDatos.CurrentRow.Cells("IdPedidoImp").Text
                frm.FechaEstimada = dgvDatos.CurrentRow.Cells("FecPromesa").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    RowPossesion(dgvDatos, frm.IdPedidoImp)
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la Fecha Promesa : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class