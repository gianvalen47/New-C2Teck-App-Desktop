Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class frmGuiaRemision

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean                   'True: Edición      False: Vista
    Public editable As Boolean                  'True: Editable     False: No Editable
    Private oMaestroService As New MaestroService.MaestroClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oGuiaRemisionDetService As New GuiaRemisionDetService.GuiaRemisionDetServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient       '-------------- Se agregó el 04/06/2013 ---------------
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Public dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdGuia As Integer
    Public IdSugerido As Integer
    Public IdLocacion As Integer
    Private IdCliente As Integer
    Public IdSerieDoc As Integer
    Private TipMov As String
    Private dtModoTraslado As DataTable
    Private dtTipos As DataTable
    Private dtMotivos As DataTable
    Private dtMonedas As DataTable
    Private dtLocaciones As DataTable
    Private ConLocCli As Integer = 0
    Private Factura As Boolean
    Private IdOrden As Integer = 0
    Private IdSugeridoCab As Integer
    Private CodMon As String
    Private Permiso As Boolean
    Private MonNac As Boolean
    Private DirFile As String
    Private fileExt As String
    Private DtLimite As Integer
    Private dtInsertarMasivo As DataTable
    Private dtCodUniMed As DataTable

    Public CodOfi As String              '--------- Se agregó el 09/05/2014 para que aparesca la direccion de oficina en el campo de punto de partida (Jacquelin)

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
        'If e.KeyCode = Keys.F12 Then
        '    If txtCliente.ButtonEnabled = True Then
        '        txtCliente_ButtonClick(sender, e)
        '        e.Handled = True
        '    End If
        'End If
    End Sub
    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If txtNumJob.ButtonEnabled = True Then
                txtNumJob_ButtonClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown

        If e.KeyCode = Keys.F12 Then
            If txtObservacion.ButtonEnabled = True Then
                txtObservacion_ButtonClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbIdLocCli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdLocCli.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarLocacion.Enabled = True Then
                e.Handled = True
                btnAgregarLocacion_Click(sender, e)
            End If
        End If
    End Sub
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                    txtNumDoc.KeyPress, txtFecDoc.KeyPress, cmbIdLocCli.KeyPress, txtPartida.KeyPress,
                                    cmbCodMot.KeyPress, txtNumJob.KeyPress, txtNum_Orden.KeyPress, txtTotFlete.KeyPress, cmbIdFiscal.KeyPress,
                                    txtPesoTotal.KeyPress, txtCanBultos.KeyPress, cmbUnidMedPeso.KeyPress, cmbModoTraslado.KeyPress, txtFecIniTraslado.KeyPress, txtCliente.KeyPress
        'cmbCodMon.KeyPress
        ' txtLlegada.KeyPress,
        ' txtObservacion.KeyPress,
        'cmbIdCotizacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtTotFlete.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub txtTotEmbarque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotEmbarque.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub
    Private Sub txtLlegada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLlegada.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNum_Orden.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub frmGuiaRemision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub cmbCodMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Select()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()

        If state_button Then    'Ver/Modificar

            desactivar()
            ObtenerRegistro()
            actualizarDetalles()
            Me.Text = "GUÍAS DE REMISIÓN Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
            dgvDatos.Select()

        Else
            'Nuevo
            CodMon = oMaestroService.ObtenerMonedaNacional(IdLocacion)
            Permiso = oSeguridadService.BuscarPermisoTipCam(Session.sCodUsu)
            MonNac = oMaestroService.BuscarMonedaNacional(IdLocacion)

            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window
            txtFecDoc.ReadOnly = False
            txtFecDoc.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            cmbIdLocCli.ReadOnly = False
            cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window

            cmbCodMon.Value = CodMon
            cmbCodMot.Value = "1"

            cmbUnidMedPeso.Value = "KGM"
            cmbModoTraslado.Value = "02"

            txtFecDoc.Value = Session.sFecha

            If Permiso Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                Else
                    cmbCodMon.ReadOnly = False
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Window
                End If
            End If
            '--- txtPartida.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DirEmp", "CodEmp", Session.sDesEmp)
            txtPartida.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "PuntoPartida", "IdLocacion", IdLocacion)
            activar()
            If IdOrden = 0 Then
                txtNum_Orden.ReadOnly = False
                txtNum_Orden.BackColor = System.Drawing.SystemColors.Window
            Else
                txtNum_Orden.ReadOnly = True
                txtNum_Orden.BackColor = System.Drawing.SystemColors.Control
            End If
            Me.Size = New System.Drawing.Size(856, 305)
            Me.Text = "Registrar nueva GUÍA DE REMISIÓN"
            txtNumDoc.Select()

        End If

        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text)), "#0.000")
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oGuiaRemisionService) = False Then
                oGuiaRemisionService.Close()
            End If
            If isClosed(oGuiaRemisionDetService) = False Then
                oGuiaRemisionDetService.Close()
            End If
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            '-------------- Se agregó el 04/06/2013 ---------------
            If isClosed(oDireccionFiscalService) = False Then
                oDireccionFiscalService.Close()
            End If
            '------------------------------------------------------------------
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR[FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdGuiaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            If state_button Then
                Dim aprobar As GuiaRemisionService.GuiaRemision
                aprobar = oGuiaRemisionService.MostrarPorId(IdGuia)

                biEditar.Enabled = IIf(editable, Not edicion, False)
                biTransportista.Enabled = IIf(editable, Not edicion, False)
                biSalir.Enabled = Not edicion
                'biSugerir.Enabled = IIf(editable, Not edicion, False)
                biSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And txtTotalNeto.Text > 0 And aprobar.Motivos.Aprobar = True, True, False)
                biGrabar.Enabled = edicion
                biDeshacer.Enabled = edicion
                biActMoneda.Enabled = IIf((Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO"), True, False)   '------ Se agrega el Perfil de Costos 02/08/2016

                cmOpciones.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
                ' miNuevo.Enabled = IIf(editable, True, False)
                miNuevo.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And Not oGuiaRemisionService.BuscarOrden(IdGuia), True, False)
                miModificar.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
                miEliminar.Enabled = IIf(dgvDatos.RowCount > 0 And (lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And Not oGuiaRemisionService.BuscarOrden(IdGuia), True, False)
                miActualizar.Enabled = IIf(dgvDatos.RowCount > 0 And (lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO"), True, False)
                'miSugerir.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
                ''miSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And txtTotalNeto.Text > 0 And aprobar.Motivos.Aprobar = True, True, False)
                'Sugerir cambiado para que tambien se active cuando tenga un Total sugerido > 0  06-05-12
                miSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And (txtTotalNeto.Text > 0 Or txtTotalSug.Text > 0) And aprobar.Motivos.Aprobar = True And Not oGuiaRemisionService.BuscarOrden(IdGuia), True, False)

                '--- El Insertar Masivo es para Jefe de Logistica y en el Almacen de Consignacion Repuestos Tintaya
                miFormatoExcel.Visible = IIf(((lblEstado.Text = "GENERADO") Or (lblEstado.Text = "APROBADO")) And (Session.CodPerfil = "28" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42") And IdLocacion = 12, True, False)
                miInsertarMasivo.Visible = IIf(((lblEstado.Text = "GENERADO") Or (lblEstado.Text = "APROBADO")) And (Session.CodPerfil = "28" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42") And IdLocacion = 12, True, False)

                'miAgregarConsumoJob.Enabled = IIf(dgvDatos.RowCount < 1, True, False)
            Else
                biEditar.Enabled = False
                biDeshacer.Enabled = True
                biGrabar.Enabled = True
                biTransportista.Enabled = False
                biSalir.Enabled = False
                biSugerir.Enabled = False
                biActMoneda.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdGuia) = 0 Then
                MsgBox("Debe Ingresar el código de la guía.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
                'ElseIf toNumber(IdLocacion) = 0 Then
                '  MsgBox("Debe Ingresar la almacén del documento.", MsgBoxStyle.Information, "Información")
                '  txtAlmacen.BackColor = Color.Red
                '  txtAlmacen.Select()
                '  Return False
            ElseIf toNumber(IdSerieDoc) = 0 Then
                MsgBox("ERROR: Al obtener el código del documento, comuníquese con el departamento de sistemas...!.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtTipoCambio.Text) = 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Select()
                Return False
            ElseIf toBlank(cmbIdFiscal.Value) = "" Then
                MsgBox("Debe ingresar la dirección fiscal.", MsgBoxStyle.Information, "Información")
                cmbIdFiscal.Select()
                Return False
            ElseIf toBlank(cmbCodMot.Value) = "" Then
                MsgBox("Debe ingresar el motivo de la guía.", MsgBoxStyle.Information, "Información")
                cmbCodMot.Select()
                Return False
            ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Select()
                Return False
                'ElseIf state_button = False And oGuiaRemisionService.BuscarOrdenCliente(IdCliente) Then
                '          MsgBox("El Cliente seleccionado aun tiene órdenes de compra " + vbCr + " Debe generar la guía de remisión desde la opción " + Chr(34) + "Ordenes de Compra" + Chr(34) + "", MsgBoxStyle.Information, "Información")
                '  Return False
            ElseIf state_button = False And oGuiaRemisionService.Buscar(IdLocacion, IdSerieDoc, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la guía ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Select()
                Return False
            ElseIf state_button = True And oGuiaRemisionService.Estado(IdGuia) <> "GENERADO" And oGuiaRemisionService.Estado(IdGuia) <> "APROBADO" And oGuiaRemisionService.Estado(IdGuia) <> "CREDITOS" Then
                MsgBox("La Guía ya no se puede modificar...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf ConLocCli > 1 And cmbIdLocCli.Value = 0 Then
                MsgBox("Ingrese la Locacion del Cliente", MsgBoxStyle.Information, "Faltan Datos")
                cmbIdLocCli.Select()
                Return False
            ElseIf toDouble(txtPesoTotal.Value) <= 0 Then
                MsgBox("El peso total no puede ser CERO.", MsgBoxStyle.Information, "Información")
                txtPesoTotal.Select()
                Return False
            ElseIf toBlank(cmbUnidMedPeso.Value) = "" Then
                MsgBox("Debe ingresar la Unidad de Medida del Peso.", MsgBoxStyle.Information, "Información")
                cmbUnidMedPeso.Select()
                Return False
            ElseIf toNumber(txtCanBultos.Value) <= 0 Then
                MsgBox("La cantidad de bultos no puede ser CERO.", MsgBoxStyle.Information, "Información")
                txtCanBultos.Select()
                Return False
            ElseIf toBlank(txtFecIniTraslado.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de inicio de traslado", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(cmbModoTraslado.Value) = "" Then
                MsgBox("Debe ingresar el Modo Traslado", MsgBoxStyle.Information, "Información")
                cmbModoTraslado.Select()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub sugerirDetalle()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New GuiaRemisionService.SugeridoGuia
                registro = oGuiaRemisionService.MostrarSugeridoPorId(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug > 0 Then
                    MsgBox("No puede hacer sugerencias por detalle, por que ya se hizo a nivel de Documento ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            Dim frm As New frmGuiaRemision_SugerirDetalle
            frm.IdGuia = IdGuia
            frm.IdGuiaDet = toNumber(dgvDatos.CurrentRow.Cells("IdGuiaDet").Value)
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.CodMon = cmbCodMon.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "insert" Or frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdGuiaDet)
                Else
                    MsgBox("Se eliminó la sugerencia correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub sugerirCabecera()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New GuiaRemisionService.SugeridoGuia
                registro = oGuiaRemisionService.MostrarSugeridoPorId(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug = 0 And txtTotalSug.Text > 0 Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmGuiaRemision_SugerirCabecera
            frm.IdGuia = IdGuia
            frm.IdSugerido = IdSugerido
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                'If frm.type_process = "insert" Or frm.type_process = "update" Then
                '    RowPossesion(dgvDatos, dtDatos, "IdGuia", frm.IdGuia)
                'Else
                '    MsgBox("Se elimino la sugerencia correctamente.", MsgBoxStyle.Information)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub nuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmGuiaRemision_AgregarDetalle
                'Dim frm1 As New frmGuiasRemision
                frm.state_button = False
                frm.IdGuia = IdGuia
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                frm.TipMov = TipMov
                frm.CodMot = toBlank(cmbCodMot.Value)

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdSugerido = frm.IdSugerido
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdGuiaDet)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmGuiaRemision_AgregarDetalle
            frm.state_button = True
            frm.IdGuiaDet = dgvDatos.CurrentRow.Cells("IdGuiaDet").Text
            frm.IdGuia = IdGuia
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.TipMov = TipMov
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                listaDatos()
                ObtenerRegistro()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdGuiaDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
                    Dim estado_process As Boolean
                    estado_process = oGuiaRemisionDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdGuiaDet").Text), IdGuia)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGuiaDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As GuiaRemisionService.GuiaRemision)

        Try
            Dim estado_process As Integer
            estado_process = oGuiaRemisionService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdGuia = estado_process
                If MsgBox("¿Desea ingresar el transportista?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Transportista()
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Size = New System.Drawing.Size(851, 560)
                state_button = True
                desactivar()
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INSERTAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As GuiaRemisionService.GuiaRemision)
        Try
            Dim estado_process As Boolean
            estado_process = oGuiaRemisionService.Actualizar(registro)
            type_process = "update"
            If estado_process Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [MODIFICAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As GuiaRemisionService.GuiaRemision
            registro = oGuiaRemisionService.MostrarPorId(IdGuia)

            IdGuia = registro.IdGuia
            IdLocacion = registro.Locacion.IdLocacion
            txtFecDoc.Text = registro.FecDoc
            IdSerieDoc = registro.SerieDocumento.IdSerieDoc
            txtNumDoc.Text = registro.NumDoc
            IdCliente = registro.Cliente.IdCliente
            listarLocacionesCliente()
            listarCombosDirFiscal()                                                  '-------------- Se agregó el 04/06/2013 ---------------
            txtCliente.Text = registro.Cliente.DesCli
            cmbIdLocCli.Value = registro.LocacionCliente.IdLocCli
            cmbIdFiscal.Value = registro.DireccionFiscal.IdFiscal       '-------------- Se agregó el 04/06/2013 ---------------
            cmbCodMot.Value = registro.Motivos.CodMot
            cmbIdCotizacion.Value = registro.Cotizacion.IdCotizacion
            txtNumJob.Text = registro.NumJob
            txtPartida.Text = registro.PtoPartida
            txtLlegada.Text = registro.PtoLlegada
            cmbCodMon.Value = registro.Moneda.CodMon
            txtIgv.Value = registro.Igv
            txtTotFlete.Text = registro.TotFlete
            txtTotEmbarque.Text = registro.TotEmbarque
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = registro.Estado
            txtVendedor.Text = registro.Persona.ApeNom
            txtNum_Orden.Text = registro.OrdenCompra.NumOrden
            TipMov = registro.TipMov
            Factura = registro.Motivos.Factura
            txtNum_Orden.Text = registro.OrdenCompra.NumOrden
            IdOrden = IIf(registro.OrdenCompra.IdOrden Is Nothing, 0, registro.OrdenCompra.IdOrden)

            '=========================================================  CAMPOS AGREGADOS PARA LA GUIA DE REMISION ELECTRONICA
            txtPesoTotal.Value = registro.PesoBruto
            cmbUnidMedPeso.Value = registro.UnidadMedidaPeso.CodUniMedPeso
            txtCanBultos.Value = registro.NumeroBultos
            txtFecIniTraslado.Value = registro.FecTraslado
            cmbModoTraslado.Value = registro.ModoTraslado.CodModo
            '========================================================= 


            Me.Text = "GUÍAS DE REMISIÓN Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '======================================= MOTIVOS ================================================
            dtMotivos = oMaestroService.MostrarMotivos.Tables(0)
            dtMotivos.Rows.InsertAt(getRowTodos(dtMotivos), 0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing
            '======================================= UNIDAD DE MEDIDA ===========================================
            dtCodUniMed = oMercaderiaService.MostrarUniMedPeso.Tables(0)
            cmbUnidMedPeso.DataSource = dtCodUniMed
            cmbUnidMedPeso.DropDownList.DataMember = dtCodUniMed.Columns("Nombre").ToString
            cmbUnidMedPeso.DropDownList.DisplayMember = dtCodUniMed.Columns("Nombre").ToString
            cmbUnidMedPeso.DropDownList.ValueMember = dtCodUniMed.Columns("CodUniMedPes").ToString
            cmbUnidMedPeso.DropDownList.Columns(0).DataMember = dtCodUniMed.Columns("CodUniMedPes").ToString
            cmbUnidMedPeso.DropDownList.Columns(1).DataMember = dtCodUniMed.Columns("Nombre").ToString
            dtCodUniMed = Nothing
            '======================================= MODO TRASLADO ===========================================
            dtModoTraslado = oGuiaRemisionService.MostrarModoTraslado.Tables(0)
            cmbModoTraslado.DataSource = dtModoTraslado
            cmbModoTraslado.DropDownList.DataMember = dtModoTraslado.Columns("DesModo").ToString
            cmbModoTraslado.DropDownList.DisplayMember = dtModoTraslado.Columns("DesModo").ToString
            cmbModoTraslado.DropDownList.ValueMember = dtModoTraslado.Columns("CodModo").ToString
            cmbModoTraslado.DropDownList.Columns(0).DataMember = dtModoTraslado.Columns("CodModo").ToString
            cmbModoTraslado.DropDownList.Columns(1).DataMember = dtModoTraslado.Columns("DesModo").ToString
            dtModoTraslado = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listarLocacionesCliente()
        '======================================= LOCACIONES DEL CLIENTE ================================================
        dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
        dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
        cmbIdLocCli.DataSource = dtLocaciones
        cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
        ConLocCli = dtLocaciones.Rows.Count
        cmbIdLocCli.SelectedIndex = 0
        dtLocaciones = Nothing
        '======================================= COTIZACIONES DEL CLIENTE ================================================
        dtLocaciones = oGuiaRemisionService.MostrarCotizacion(IdCliente).Tables(0)
        dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
        cmbIdCotizacion.DataSource = dtLocaciones
        cmbIdCotizacion.DropDownList.DataMember = dtLocaciones.Columns("NumCot").ToString
        cmbIdCotizacion.DropDownList.DisplayMember = dtLocaciones.Columns("NumCot").ToString
        cmbIdCotizacion.DropDownList.ValueMember = dtLocaciones.Columns("IdCotizacion").ToString
        cmbIdCotizacion.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdCotizacion").ToString
        cmbIdCotizacion.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("NumCot").ToString
        dtLocaciones = Nothing
        '  cmbIdCotizacion.SelectedIndex = 0
    End Sub

    Public Sub listaDatos()
        Try
            dtDatos = oGuiaRemisionDetService.Mostrar(toNumber(IdGuia)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            If dgvDatos.RowCount > 0 Then

                IdSugeridoCab = IIf(dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text)

                Dim registro1 As New GuiaRemisionService.GuiaRemision
                Dim registro2 As New GuiaRemisionService.SugeridoGuia

                registro1 = oGuiaRemisionService.MostrarPorId(IdGuia)
                If IdSugeridoCab > 0 Then
                    registro2 = oGuiaRemisionService.MostrarSugeridoPorId(IdSugeridoCab)
                End If

                txtTotalPrecio.Value = registro1.TotBruto
                txtTotalDescuento.Value = registro1.TotDscto
                txtTotal.Value = registro1.TotVenta
                txtTotalIGV.Value = registro1.TotIgv
                txtTotalNeto.Value = registro1.TotNeto

                lblTotal.Text = "SUB TOTALES ==>  "
                lbltotalIGV.Text = "IGV ==>  "
                lblTotalNeto.Text = "TOTAL NETO ==> (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaRemision", "CodMon", "IdGuia", IdGuia)) + ") "

                txtTotalSug.Text = IIf(IdSugeridoCab > 0, registro2.TotVentaSug, 0)
                txtTotalIgvSug.Text = IIf(IdSugeridoCab > 0, registro2.TotIgvSug, 0)
                txtTotalNetoSug.Text = IIf(IdSugeridoCab > 0, registro2.TotNetoSug, 0)

                If txtTotalNetoSug.Text > 0 Then
                    dgvDatos.RootTable.Columns(4).Width = 228
                    dgvDatos.RootTable.Columns(9).Visible = True
                    lblTotal.Size = New System.Drawing.Size(433, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(602, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(602, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(453, 11)
                    txtTotalDescuento.Location = New System.Drawing.Point(543, 11)
                    txtTotal.Location = New System.Drawing.Point(622, 11)
                    txtTotalIGV.Location = New System.Drawing.Point(622, 30)
                    txtTotalNeto.Location = New System.Drawing.Point(622, 49)
                    txtTotalSug.Visible = True
                    txtTotalIgvSug.Visible = True
                    txtTotalNetoSug.Visible = True
                Else
                    dgvDatos.RootTable.Columns(4).Width = 318
                    dgvDatos.RootTable.Columns(9).Visible = False
                    lblTotal.Size = New System.Drawing.Size(523, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(692, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(692, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(542, 11)
                    txtTotalDescuento.Location = New System.Drawing.Point(632, 11)
                    txtTotal.Location = New System.Drawing.Point(711, 11)
                    txtTotalIGV.Location = New System.Drawing.Point(711, 30)
                    txtTotalNeto.Location = New System.Drawing.Point(711, 49)
                    txtTotalSug.Visible = False
                    txtTotalIgvSug.Visible = False
                    txtTotalNetoSug.Visible = False
                End If
            End If

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub activar()
        txtNumJob.ButtonEnabled = True
        If state_button Then
            cmbCodMot.ReadOnly = True
            cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        Else
            cmbCodMot.ReadOnly = False
            cmbCodMot.BackColor = System.Drawing.SystemColors.Window
        End If
        cmbIdLocCli.ReadOnly = False
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window
        btnAgregarLocacion.Enabled = True
        btnModificarLocacion.Enabled = True
        '================ Se agregó el 04/06/2013 =================
        cmbIdFiscal.ReadOnly = False
        cmbIdFiscal.BackColor = System.Drawing.SystemColors.Window
        btnAgregarDirFiscal.Enabled = True
        btnModificarDirFiscal.Enabled = True
        '====================================================
        'cmbIdCotizacion.ReadOnly = False
        'cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ButtonEnabled = True
        txtTotFlete.ReadOnly = False
        txtTotFlete.BackColor = System.Drawing.SystemColors.Window
        txtTotEmbarque.ReadOnly = False
        txtTotEmbarque.BackColor = System.Drawing.SystemColors.Window
        txtLlegada.ReadOnly = False
        txtLlegada.BackColor = System.Drawing.SystemColors.Window
        txtPartida.ReadOnly = False
        txtPartida.BackColor = System.Drawing.SystemColors.Window
        If IdOrden = 0 Then
            txtNum_Orden.ReadOnly = False
            txtNum_Orden.BackColor = System.Drawing.SystemColors.Window
        Else
            txtNum_Orden.ReadOnly = True
            txtNum_Orden.BackColor = System.Drawing.SystemColors.Control
        End If
        txtPesoTotal.ReadOnly = False
        txtPesoTotal.BackColor = System.Drawing.SystemColors.Window
        cmbUnidMedPeso.ReadOnly = False
        cmbUnidMedPeso.BackColor = System.Drawing.SystemColors.Window
        txtCanBultos.ReadOnly = False
        txtCanBultos.BackColor = System.Drawing.SystemColors.Window
        txtFecIniTraslado.ReadOnly = False
        txtFecIniTraslado.BackColor = System.Drawing.SystemColors.Window
        cmbModoTraslado.ReadOnly = False
        cmbModoTraslado.BackColor = System.Drawing.SystemColors.Window
        edicion = True
        enableOpciones()
        biSugerir.Enabled = False
        dgvDatos.Select()
    End Sub
    Private Sub desactivar()

        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        cmbIdLocCli.ReadOnly = True
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        btnAgregarLocacion.Enabled = False
        btnModificarLocacion.Enabled = False
        '================ Se agregó el 04/06/2013 =================
        cmbIdFiscal.ReadOnly = True
        cmbIdFiscal.BackColor = System.Drawing.SystemColors.Control
        btnAgregarDirFiscal.Enabled = False
        btnModificarDirFiscal.Enabled = False
        '====================================================
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        ' *****************************************************
        txtNumJob.ButtonEnabled = False
        cmbCodMot.ReadOnly = True
        cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        cmbIdCotizacion.ReadOnly = True
        cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ButtonEnabled = False
        txtTotFlete.ReadOnly = True
        txtTotFlete.BackColor = System.Drawing.SystemColors.Control
        txtTotEmbarque.ReadOnly = True
        txtTotEmbarque.BackColor = System.Drawing.SystemColors.Control
        txtLlegada.ReadOnly = True
        txtLlegada.BackColor = System.Drawing.SystemColors.Control
        txtPartida.ReadOnly = True
        txtPartida.BackColor = System.Drawing.SystemColors.Control
        txtNum_Orden.ReadOnly = True
        txtNum_Orden.BackColor = System.Drawing.SystemColors.Control
        txtPesoTotal.ReadOnly = True
        txtPesoTotal.BackColor = System.Drawing.SystemColors.Control
        cmbUnidMedPeso.ReadOnly = True
        cmbUnidMedPeso.BackColor = System.Drawing.SystemColors.Control
        txtCanBultos.ReadOnly = True
        txtCanBultos.BackColor = System.Drawing.SystemColors.Control
        cmbModoTraslado.ReadOnly = True
        cmbModoTraslado.BackColor = System.Drawing.SystemColors.Control
        txtFecIniTraslado.ReadOnly = True
        txtFecIniTraslado.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        dgvDatos.Select()
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub txtNumJob_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumJob.ButtonClick
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            txtCliente.Select()
            listarLocacionesCliente()
            listarCombosDirFiscal()
            If oClienteService.BuscarMonedaCliente(IdLocacion, IdCliente) = True Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If Permiso = False And MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                    cmbCodMon.Value = CodMon
                End If
            End If
        End If
    End Sub

    Private Sub txtObservacion_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacion.ButtonClick
        Dim frm As New frmGuiaRemision_ModificarObservacion
        frm.state_button = state_button
        frm.IdGuia = IdGuia
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub
    Private Sub miSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirDetalle()
            ObtenerRegistro()
        End If
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN" Or toBlank(lblEstado.Text) = "APROBADO" Or toBlank(lblEstado.Text) = "AP") Then
            nuevoDetalle()
        End If
    End Sub
    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text)), "#0.000")
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
        cmbCodMot.Select()
    End Sub
    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirCabecera()
            ObtenerRegistro()
        End If
    End Sub
    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New GuiaRemisionService.GuiaRemision
                Dim locacion As New GuiaRemisionService.Locacion
                Dim almacen As New GuiaRemisionService.Almacen
                Dim tipoDocumento As New GuiaRemisionService.SerieDocumento
                Dim cliente As New GuiaRemisionService.Cliente
                Dim locacionCliente As New GuiaRemisionService.LocacionCliente
                Dim motivo As New GuiaRemisionService.Motivos
                Dim moneda As New GuiaRemisionService.Moneda
                Dim cotizacion As New GuiaRemisionService.Cotizacion
                Dim ordencompra As New GuiaRemisionService.OrdenCompra
                Dim direccion As New GuiaRemisionService.DireccionFiscal         '==== Se agregó el 04/06/2013 ======
                Dim unidadpesomedida As New GuiaRemisionService.UnidadMedidaPeso
                Dim modotraslado As New GuiaRemisionService.ModoTraslado

                registro.IdGuia = IdGuia
                locacion.IdLocacion = IdLocacion
                registro.Locacion = locacion
                registro.FecDoc = txtFecDoc.Text
                tipoDocumento.IdSerieDoc = IdSerieDoc
                registro.SerieDocumento = tipoDocumento
                registro.NumDoc = txtNumDoc.Text
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
                locacionCliente.IdLocCli = cmbIdLocCli.Value
                registro.LocacionCliente = locacionCliente
                '================== Se agregó el 04/06/2013 ==========================
                direccion.IdFiscal = IIf(toNumber(cmbIdFiscal.Value) = 0, Nothing, cmbIdFiscal.Value)
                registro.DireccionFiscal = direccion
                '==============================================================
                motivo.CodMot = cmbCodMot.Value
                registro.Motivos = motivo
                registro.NumJob = txtNumJob.Text
                registro.PtoPartida = txtPartida.Text
                registro.PtoLlegada = txtLlegada.Text
                moneda.CodMon = cmbCodMon.Value
                registro.Moneda = moneda
                registro.Igv = txtIgv.Value
                registro.TotFlete = toDouble(txtTotFlete.Text)
                registro.TotEmbarque = toDouble(txtTotEmbarque.Text)
                registro.Observacion = toBlank(txtObservacion.Text)
                ordencompra.NumOrden = toNull(txtNum_Orden.Text)
                registro.OrdenCompra = ordencompra
                cotizacion.IdCotizacion = cmbIdCotizacion.Value
                registro.Cotizacion = cotizacion

                registro.PesoBruto = toDouble(txtPesoTotal.Value)
                unidadpesomedida.CodUniMedPeso = cmbUnidMedPeso.Value
                registro.UnidadMedidaPeso = unidadpesomedida
                registro.NumeroBultos = txtCanBultos.Value
                registro.FecTraslado = txtFecIniTraslado.Text
                modotraslado.CodModo = cmbModoTraslado.Value
                registro.ModoTraslado = modotraslado

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biEditar.MouseLeave, biSugerir.MouseLeave, biGrabar.MouseLeave, biDeshacer.MouseLeave, biSalir.MouseLeave, biTransportista.MouseLeave,
                                    miSugerir.MouseLeave, miNuevo.MouseLeave, miModificar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Guía de Remisión."
    End Sub
    Private Sub biSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento para la Guía de Remisión."
    End Sub
    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.MouseEnter
        sslError.Text = "Grabar los cambios hechos en la Guía de Remisión."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los cambios hechos en la Guía de Remisión."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Guía de Remisión."
    End Sub
    Private Sub biTransportista_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTransportista.MouseEnter
        sslError.Text = "Ingresar el Transportista."
    End Sub
    Private Sub biActMoneda_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActMoneda.MouseEnter
        sslError.Text = "actualizar moneda de la Guía de Remisión."
    End Sub
    Private Sub miSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.MouseEnter
        sslError.Text = "Sugerir Precio y/o Descuento para el Detalle actual."
    End Sub
    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle de la Guía de Remisión."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario Guía de Remisión."
    End Sub
    Private Sub biTransportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTransportista.Click
        Transportista()
    End Sub
    Private Sub Transportista()
        Try
            Dim frm As New frmGuiaRemision_Transportista
            frm.state_button = True
            frm.IdGuia = IdGuia
            frm.CodModo = cmbModoTraslado.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("Se guardó los datos del Transportista correctamente")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Al cargar Transportista")
        End Try
    End Sub

    Private Sub cmbIdLocCli_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocCli.ValueChanged
        Try
            txtLlegada.Text = oMaestroService.MostrarDato("Maestro.LocacionCliente", "DirCli", "IdLocCli", cmbIdLocCli.Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
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

    Private Sub btnAgregarLocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLocacion.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarLocacionCliente
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarLocacionesCliente()
                cmbIdLocCli.Value = forma.txtIdLocCli.Text
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdLocCli.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdLocCli.Select()
    End Sub

    Private Sub biActMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActMoneda.Click
        Try
            Dim frm As New frmGuiaRemision_ActualizarMoneda

            frm.IdDoc = IdGuia
            frm.CodMon = cmbCodMon.Value
            frm.state_button = 1
            frm.NumDoc = txtNumDoc.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al Actualizar la moneda")
        End Try
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '****************************************************************** SE AGREGÓ EL 04/06/2013 *******************************************************************
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub cmbIdFiscal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdFiscal.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarDirFiscal.Enabled = True Then
                e.Handled = True
                btnAgregarDirFiscal_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub listarCombosDirFiscal()
        '========================= DIRECCIONES FISCALES =======================

        dtLocaciones = oDireccionFiscalService.Mostrar(IdCliente).Tables(0)
        cmbIdFiscal.DataSource = dtLocaciones
        cmbIdFiscal.DropDownList.DataMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscal.DropDownList.DisplayMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscal.DropDownList.ValueMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscal.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscal.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Direccion").ToString
        If dtLocaciones.Rows.Count > 0 Then
            cmbIdFiscal.SelectedIndex = 0
        Else
            cmbIdFiscal.Value = ""
        End If
    End Sub

    Private Sub btnAgregarDirFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDirFiscal.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarDireccionFiscal
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarCombosDirFiscal()
                cmbIdFiscal.Value = forma.txtIdFiscal.Text
                'cmbIdLocCli.Value = forma.txtIdFiscal.Text
            End If
        End If
        cmbIdFiscal.Select()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '************************************************************************************************************************************************************************
    Private Sub miFormatoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
        dtExcel.Rows.Add(New Object() {"", ""})

        DataGridView2.DataSource = dtExcel

        Dim Export As Boolean

        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub miInsertarMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInsertarMasivo.Click

        OpenFileDialog1.InitialDirectory = "d:\"
        'OpenFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If

    End Sub

    Private Sub CargadoFinal()

        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") And (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            CreacionTable()
            If DtLimite >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If

    End Sub

    Private Sub CreacionTable()
        Try

            Dim row As DataRow
            Dim dtCopia As New DataTable("tabla")
            dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CanMer", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"", "", ""})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(1, i).Value) = False Then

                    row = dtInsertarMasivo.NewRow

                    row(0) = dgvDatos.RowCount + i + 1
                    row(1) = Trim(DataGridView1.Item(0, i).Value)
                    row(2) = Trim(DataGridView1.Item(1, i).Value)

                    dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            DtLimite = dtInsertarMasivo.Rows.Count
            'DataGridView1.DataSource = Nothing

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub InsertarMasivo()
        Try
            Dim estado_process As Boolean
            estado_process = oGuiaRemisionDetService.InsertarMasivo(IdGuia, dtInsertarMasivo)

            If estado_process = True Then
                MsgBox("Se Inserto correctamente el listado.", MsgBoxStyle.Information)
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LISTA DE CODIGOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnModificarLocacion_Click(sender As Object, e As EventArgs) Handles btnModificarLocacion.Click
        If IdCliente > 0 And cmbIdLocCli.Text <> "" Then
            Dim forma As New frmModificarLocacionCliente
            forma.IdCliente = IdCliente
            forma.IdLocCiente = cmbIdLocCli.Value
            forma.state_button = True
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                cmbIdLocCli_ValueChanged(sender, e)
                'listarLocacionesCliente()
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdLocCli.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        'cmbIdLocCli.Select()
    End Sub

    Private Sub btnModificarDirFiscal_Click(sender As Object, e As EventArgs) Handles btnModificarDirFiscal.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarDireccionFiscal
            forma.IdCliente = IdCliente
            forma.txtIdFiscal.Text = cmbIdFiscal.Value
            forma.state_button = True
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                'listarCombosDirFiscal()
                'cmbIdFiscal.Value = forma.txtIdFiscal.Text
                'cmbIdLocCli.Value = forma.txtIdFiscal.Text
            End If
        End If
        'cmbIdFiscal.Select()
    End Sub


End Class
