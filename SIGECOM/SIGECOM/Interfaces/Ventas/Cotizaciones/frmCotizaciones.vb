Imports System.ServiceModel
Imports System.Net
Public Class frmCotizaciones

    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    'Dim IdCotizacion As Integer

    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtVendedor As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumCot.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
 _
                      , cmbMes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrar()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumCot.Select()
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumCot.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbMes.KeyPress _
                      , btnBuscar.KeyPress
        ', dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCot.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdCotizacion").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmCotizaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            dgvDatos.Select()
            dgvDatos.Row = dgvDatos.RowCount - 1
            dgvDatos.Col = 1
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 21)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        'txtanio.Value = Today.Year
        'cmbMes.Value = Today.Month
        txtanio.Value = Session.sFecha.Year
        cmbMes.Value = Session.sFecha.Month
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
            If isClosed(oPersonaService) = False Then
                oPersonaService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_cotizacion As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtNumCot.Text = nro_cotizacion
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            miActualizar.Enabled = False
            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miGenerar.Enabled = False
            miSeguimiento.Enabled = False
            miGenerarCoti.Enabled = False
            miRechazar.Enabled = False
            miEstado.Enabled = False
            miGenerarGuiasMulti.Enabled = False
            miSugerir.Enabled = False
            miEnviar.Enabled = False
            miArchivos.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biactualizar.Enabled = False
            biImprimir.Enabled = False
            biGenerar.Enabled = False
            btnseguimiento.Enabled = False
            biGenerarCoti.Enabled = False
            biRechazar.Enabled = False
            biEstado.Enabled = False
            biGenerarGuiasMulti.Enabled = False
            biSugerir.Enabled = False
            biEnviar.Enabled = False
            biArchivos.Enabled = False

        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miActualizar.Enabled = True
            'miImprimir.Enabled = True
            miSeguimiento.Enabled = True
            miEstado.Enabled = True
            miSeguimiento.Enabled = True
            miArchivos.Enabled = True

            biMostrar.Enabled = True
            biEliminar.Enabled = True
            biactualizar.Enabled = True
            'biImprimir.Enabled = True
            btnseguimiento.Enabled = True
            biEstado.Enabled = True
            btnseguimiento.Enabled = True
            biArchivos.Enabled = True

            Dim lestado As String
            Dim lmonto As Integer
            Dim lSugerido As Integer

            lestado = dgvDatos.CurrentRow.Cells("Estado").Text
            lmonto = dgvDatos.CurrentRow.Cells("TotNeto").Text
            lSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value

            biEliminar.Enabled = IIf(lestado <> "GENERADO" And lestado <> "APROBADO", False, True)
            miEliminar.Enabled = IIf(lestado <> "GENERADO" And lestado <> "APROBADO", False, True)
            biGenerar.Enabled = IIf(lestado = "ATENDIDO" Or lestado = "RECHAZADO" Or lmonto = 0 Or lSugerido > 0, False, True)
            miGenerar.Enabled = IIf(lestado = "ATENDIDO" Or lestado = "RECHAZADO" Or lmonto = 0 Or lSugerido > 0, False, True)
            biGenerarGuiasMulti.Enabled = IIf(lestado = "ATENDIDO" Or lmonto = 0 Or lestado = "CREDITOS" Or lestado = "RECHAZADO" Or lSugerido > 0, False, True)
            miGenerarGuiasMulti.Enabled = IIf(lestado = "ATENDIDO" Or lmonto = 0 Or lestado = "CREDITOS" Or lestado = "RECHAZADO" Or lSugerido > 0, False, True)
            biSugerir.Enabled = IIf((lestado = "GENERADO" Or lestado = "APROBADO") And lmonto > 0, True, False)
            miSugerir.Enabled = IIf((lestado = "GENERADO" Or lestado = "APROBADO") And lmonto > 0, True, False)
            biEnviar.Enabled = IIf(lSugerido > 0 And lestado <> "CREDITOS", True, False)
            miEnviar.Enabled = IIf(lSugerido > 0 And lestado <> "CREDITOS", True, False)
            biImprimir.Enabled = IIf(lSugerido > 0, False, True)
            miImprimir.Enabled = IIf(lSugerido > 0, False, True)
            'btnseguimiento.Enabled = IIf(lestado = "IMPRESO" Or lestado = "PROCESADO", False, True)
            'miSeguimiento.Enabled = IIf(lestado = "IMPRESO" Or lestado = "PROCESADO", False, True)
            biGenerarCoti.Enabled = IIf(dgvDatos.CurrentRow.Cells("TotNeto").Text > 0, True, False)
            miGenerarCoti.Enabled = IIf(dgvDatos.CurrentRow.Cells("TotNeto").Text > 0, True, False)
            biRechazar.Enabled = IIf(lestado = "RECHAZADO" Or lestado = "ATENDIDO" Or lestado = "CREDITOS", False, True)
            miRechazar.Enabled = IIf(lestado = "RECHAZADO" Or lestado = "ATENDIDO" Or lestado = "CREDITOS", False, True)
            biModificarValidez.Visible = IIf(Session.CodPerfil <> "12" And Session.CodPerfil <> "11" And Session.CodPerfil <> "57" And Session.CodPerfil <> "01" And Session.CodPerfil <> "05", False, True)
            miModificarValidez.Visible = IIf(Session.CodPerfil <> "12" And Session.CodPerfil <> "11" And Session.CodPerfil <> "57" And Session.CodPerfil <> "01" And Session.CodPerfil <> "05", False, True)
            biModificarValidez.Enabled = IIf(lestado = "ATENDIDO", False, True)
            miModificarValidez.Enabled = IIf(lestado = "ATENDIDO", False, True)
        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = "(Todos)"
        End Try

        Return fila
    End Function

    Private Function getRowVendedor(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmCotizacion
            Dim lEstado As String

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumCot.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdCotizacion)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizar()
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Cotización Nº " + dgvDatos.CurrentRow.Cells("NumCot").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oCotizacionService.Borrar(dgvDatos.CurrentRow.Cells("IdCotizacion").Text, Session.sCodUsu)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oCotizacionService.Filtrar(cmbMes.Value _
                                                     , txtanio.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumCot.Text), cmbVendedor.Value).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmCotizacion
            frm.state_button = False
            frm.btnGenerarDocumento.Enabled = False
            frm.btnEditar.Enabled = False
            frm.btnDeshacer.Enabled = True
            frm.btnCancelar.Enabled = False
            frm.btnRecalcularDscto.Enabled = False
            frm.IdLocacion = cmbIdLocacion.Value
            frm.txtNumCot.Text = toNumber(oCotizacionService.MostrarNumCot(frm.IdLocacion))
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion)) / 100
            frm.GruAlm = oMaestroService.MostrarDato("Maestro.Locaciones", "GruAlm", "IdLocacion", frm.IdLocacion)
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If cmbIdLocacion.Text = "FILTROS" Then
                frm.txtGarantia.Text = "Producto garantizado por el fabricante Donaldson"
            End If
            frm.txtDiasValidez.Value = 30
            frm.txtValidez.Text = "A 30 DIAS"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumCot.Text)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdCotizacion)
                    mostrar()
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Public Sub imprimir()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpImprimirCotizacion
                Dim reporteSinPrecio As New rpImprimirCotizacionSinPrecio
                Dim reporteDescuento As New rpImprimirCotizacionDscto
                Dim reporteDescuentoSinPrecio As New rpImprimirCotizacionDsctoSinPrecio
                Dim dtReporte As New DataTable
                frmImprimirReporte.idCotizar = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
                frmImprimirReporte.NumCot = dgvDatos.CurrentRow.Cells("NumCot").Text
                frmImprimirReporte.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text

                'IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
                'dtReporte = oCotizacionService.Imprimir(IdCotizacion).Tables(0)
                frmImprimirReporte.Show()

                'If dtReporte.Rows.Count = 0 Then
                '    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                'Else
                '    reporte.SetDataSource(dtReporte)
                '    forma.crvReportes.ReportSource = reporte
                '    forma.crvReportes.DisplayGroupTree = False
                '    'forma.crvReportes.RefreshReport = False
                '    forma.Text = "Imprimir Cotizacion"

                '    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                '    'dtReporte.WriteXmlSchema("C:\Cotizacion.xml")
                '    'reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                '    'reporte.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))

                '    'reporte.SetParameterValue("Mensaje1", oFacturaImportService.Mensaje(1, IdSerieImp, Medio, IdClienteSold))
                '    'reporte.SetParameterValue("Mensaje2", oFacturaImportService.Mensaje(2, IdSerieImp, Medio, IdClienteSold))
                '    'reporte.SetParameterValue("Mensaje3", oFacturaImportService.Mensaje(3, IdSerieImp, Medio, IdClienteSold))
                '    'reporte.SetParameterValue("Mensaje4", oFacturaImportService.Mensaje(4, IdSerieImp, Medio, IdClienteSold))
                '    'reporte.SetParameterValue("Mensaje5", oFacturaImportService.Mensaje(5, IdSerieImp, Medio, IdClienteSold))
                '    'reporte.SetParameterValue("Mensaje6", oFacturaImportService.Mensaje(6, IdSerieImp, Medio, IdClienteSold))
                '    'reporte.SetParameterValue("Mensaje7", oFacturaImportService.Mensaje(7, IdSerieImp, Medio, IdClienteSold))

                '    forma.ShowDialog()
                'End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        End If
    End Sub
    Private Sub Seguimiento()
        Dim frm As New frmCotizacionSeguimiento
        Dim lcliente As String
        Dim lnumero As String

        lcliente = dgvDatos.CurrentRow.Cells("DesCli").Text
        frm.cliente = lcliente
        lnumero = dgvDatos.CurrentRow.Cells("NumCot").Text
        frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
        frm.NumCot = lnumero
        frm.lblCliente.Text = "COTIZACION Nº: " & lnumero & " - " & lcliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        End If
    End Sub
    Private Sub Generar()
        Try
            Dim frm As New frmCotizacion_GenerarDocumento
            frm.Text = "Generar G/F/B/O.C. "
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.IdLocacion = cmbIdLocacion.Value
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub RechazarCotizacion()
        Try
            Dim frm As New frmCotizacion_Rechazar
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("La Cotización a sido Rechazada")
                listaDatos()
                RowPossesion(dgvDatos, frm.IdCotizacion)
            End If
        Catch ex As Exception
            MsgBox("ERROR [RECHAZAR]:")
        End Try
    End Sub
    Private Sub Estados()
        Try
            Dim frm As New frmCotizacion_Estados
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.Text = "Estados de la Cotización Nº " & dgvDatos.CurrentRow.Cells("NumCot").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub GenerarCoti()
        Try
            Dim frm As New frmCotizacion_GenerarCoti
            frm.Text = "Generar Cotización"
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.txtNumDoc.Text = toNumber(oCotizacionService.MostrarNumCot(cmbIdLocacion.Value))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.txtNumDoc.Text)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdCotizacion").Text = Nothing Then
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
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing
            '======================================= ESTADOS ================================================
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
            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.SelectedIndex = 0
            dtVendedor = Nothing

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
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged _
                  , cmbEstado.ValueChanged _
                  , cmbMes.ValueChanged _
                  , cmbVendedor.ValueChanged
        listaDatos()
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
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
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        actualizar()

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        imprimir()
    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        imprimir()
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnseguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseguimiento.Click

        Seguimiento()

    End Sub

    Private Sub miSeguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeguimiento.Click
        Seguimiento()

    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Cotizacion."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Documento Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Cotización ."
    End Sub
    Private Sub Seguimiento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnseguimiento.MouseEnter, miSeguimiento.MouseEnter
        sslError.Text = "Observaciones de la Cotizacion ."
    End Sub
    Private Sub GenerarGuiasMulti_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarGuiasMulti.MouseEnter, miGenerarGuiasMulti.MouseEnter
        sslError.Text = "Generar Guías de Remisión Múltiples"
    End Sub
    Private Sub Sugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter, miSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento a la Cotización"
    End Sub
    Private Sub GenerarDocumento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Generar G/F/B/O.C.."
    End Sub
    Private Sub GenerarCoti_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarCoti.MouseEnter, miGenerarCoti.MouseEnter
        sslError.Text = "Generar Cotización"
    End Sub
    Private Sub Estados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.MouseEnter, miEstado.MouseEnter
        sslError.Text = "Mostrar Estados de la Cotización"
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar  a Créditos para su Aprobación"
    End Sub
    Private Sub Rechazar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.MouseEnter, miRechazar.MouseEnter
        sslError.Text = "Rechazar Cotización"
    End Sub
    Private Sub Archivos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biArchivos.MouseEnter, miArchivos.MouseEnter
        sslError.Text = "Mostrar Archivos"
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, biImprimir.MouseLeave, biGenerar.MouseLeave, biGenerarCoti.MouseLeave, biGenerarGuiasMulti.MouseLeave, biSugerir.MouseLeave,
                                    biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, btnseguimiento.MouseLeave, biEstado.MouseLeave, biRechazar.MouseLeave, biEnviar.MouseLeave,
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, miGenerar.MouseLeave, miGenerarCoti.MouseLeave, miGenerarGuiasMulti.MouseLeave, miSugerir.MouseLeave,
        miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, miSeguimiento.MouseLeave, miEstado.MouseLeave, miRechazar.MouseLeave, miEnviar.MouseLeave, biArchivos.MouseLeave, miArchivos.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click
        Generar()
    End Sub

    Private Sub miGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGenerar.Click
        Generar()
    End Sub

    Private Sub biGenerarCoti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarCoti.Click
        GenerarCoti()
    End Sub

    Private Sub miGenerarCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGenerarCoti.Click
        GenerarCoti()
    End Sub

    Private Sub biRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.Click, miRechazar.Click
        RechazarCotizacion()
    End Sub

    Private Sub biEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.Click, miEstado.Click
        Estados()
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress

        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click, miSugerir.Click
        Try
            If toNumber(dgvDatos.CurrentRow.Cells("IdSugerido").Text) > 0 Then
                Dim factor As Double
                Dim dscto As Double
                factor = dgvDatos.CurrentRow.Cells("FactorSug").Text
                dscto = dgvDatos.CurrentRow.Cells("DsctoSug").Text
                If factor + dscto = 0 And dgvDatos.CurrentRow.Cells("TotNetoSug").Text Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            Dim frm As New frmCotizacion_SugerirCabecera
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerarGuiasMulti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarGuiasMulti.Click, miGenerarGuiasMulti.Click

        Dim frm As New frmCotizacion_GenerarGuiasMulti

        frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
        frm.IdLocacion = cmbIdLocacion.Value
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            actualizar()
            enableOpciones()
        End If
    End Sub

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ENVIAR la Cotización Nº " + dgvDatos.CurrentRow.Cells("NumCot").Text.ToString + " a Créditos para su aprobación ... ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                    'Dim NomPc As String = Dns.GetHostName
                    'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                    Dim estado_process As Boolean
                    estado_process = oCotizacionService.EnviarCreditos(dgvDatos.CurrentRow.Cells("IdCotizacion").Text, dgvDatos.CurrentRow.Cells("IdSugerido").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        actualizar()
                        MsgBox("La Cotización fue Enviada a Créditos correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biModificarValidez_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biModificarValidez.Click, miModificarValidez.Click
        Try
            Dim frm As New frmCotizacion_ModificarValidez
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.NumCot = dgvDatos.CurrentRow.Cells("NumCot").Text

            Dim registro As CotizacionService.Cotizacion
            registro = oCotizacionService.MostrarPorId(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacion").Text))

            frm.txtDiasValidez.Value = registro.DiasValidez
            frm.Text = "Modificar Cotización Nº" & dgvDatos.CurrentRow.Cells("NumCot").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error de Datos", ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biConsultarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.Click
        Try
            Dim frm As New frmGuiaRemision_ConsultarSugerido

            frm.IdCodigo = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            frm.TipoCodigo = "CT"
            frm.Text = "Precios Sugeridos de Cotización Nº : " + dgvDatos.CurrentRow.Cells("NumCot").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If

        Catch ex As Exception
            MsgBox("Error al consultar precios sugeridos : " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_FormattingRow(sender As System.Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles dgvDatos.FormattingRow

    End Sub

    Private Sub biArchivos_Click(sender As Object, e As EventArgs) Handles biArchivos.Click, miArchivos.Click
        Try
            Dim frm As New frmCotizacion_Archivos
            frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Value
            frm.NumCot = dgvDatos.CurrentRow.Cells("NumCot").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DE LA COTIZACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click

        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                chkCliente.Checked = False
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            cmbEstado.Select()
            listaDatos()
        End If

    End Sub

    Private Sub txtIdCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

End Class