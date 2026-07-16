Imports System.Windows.Forms

Public Class frmNotaCredito

  Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean                   'True: Edición      False: Vista
    Public editable As Boolean                  'True: Editable     False: No Editable
    Private oMaestroService As New MaestroService.MaestroClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient
    Private oNotaCreditoDetService As New NotaCreditoDetService.NotaCreditoDetServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Public IdNota As Integer
    Public IdLocacion As Integer
    Public IdSerieDoc As Integer
    Public IdDocumento As Integer
    Private IdCliente As Integer


    Private dtTipos As DataTable
    Private dtTipoDocRef As DataTable
    Private dtTipoNota As DataTable
    Private dtAfectacionIgv As DataTable
  Private dtMotivos As DataTable
  Private dtMonedas As DataTable
    Private dtLocaciones As DataTable
    Private ConLocCli As Integer

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
                e.Handled = True
            End If

        End If
    End Sub
    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnModificarObservacion.Enabled = True Then
                btnModificarObservacion_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdLocCli.KeyPress _
                          , cmbCodMot.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtFecDoc.KeyPress _
                          , cmbTipFac.KeyPress _
                          , txtNumJob.KeyPress _
                          , txtIgv.KeyPress _
                          , txtCliente.KeyPress _
                          , txtNumDoc.KeyPress _
                          , txtTotalNeto.KeyPress _
                          , txtTotalIGV.KeyPress _
                          , txtTotalPrecio.KeyPress _
                          , txtTotalDescuento.KeyPress _
                          , txtTotal.KeyPress _
                          , cmbCodPag.KeyPress _
                          , cmbIdFiscal.KeyPress _
                          , txtNumGuis.KeyPress _
                            , txtObservacion.KeyPress _
                        , cmbTipoNota.KeyPress _
                    , txtMotivo.KeyPress _
        , cmbTipDoc.KeyPress _
        , txtSerieDocRef.KeyPress _
        , txtNumDocRef.KeyPress
        ', cmbTipoAfectacionIgv
        ', cmbCodMon.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If biGrabar.Enabled = True Then
        '        biGrabar.Select()
        '        biGrabar_Click(sender, e)
        '    Else
        '        dgvDatos.Select()
        '    End If
        'End If
    End Sub

    Private Sub cmbTipoAfectacionIgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoAfectacionIgv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        miMostrar_Click(sender, e)
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrarDetalle()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()

        End If
    End Sub
    'Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        txtFecDoc.Focus()
    '    End If
    'End Sub
    Private Sub frmNotaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            actualizar()
        Else                    'Nuevo
            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window
            txtFecDoc.ReadOnly = False
            txtFecDoc.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            cmbCodMot.ReadOnly = False
            cmbCodMot.BackColor = System.Drawing.SystemColors.Window
            cmbCodMon.ReadOnly = False
            cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            cmbTipDoc.ReadOnly = False
            cmbTipDoc.BackColor = System.Drawing.SystemColors.Window
            cmbTipoNota.ReadOnly = False
            cmbTipoNota.BackColor = System.Drawing.SystemColors.Window
            cmbCodMon.Value = "US"
            cmbCodMot.Value = "1"
            cmbCodPag.Value = "00"
            cmbTipoAfectacionIgv.Value = "10"
            txtFecDoc.Value = Session.sFecha
            activar()
            Me.Size = New System.Drawing.Size(792, 339)
            txtNumDoc.Select()
            txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text)), "#0.000")
        End If


    End Sub

    Private Sub activar()

        txtTipoCambio.ReadOnly = False
        txtTipoCambio.BackColor = System.Drawing.SystemColors.Window
        cmbTipFac.ReadOnly = False
        cmbTipFac.BackColor = System.Drawing.SystemColors.Window
        cmbCodMot.ReadOnly = False
        cmbCodMot.BackColor = System.Drawing.SystemColors.Window
        cmbIdLocCli.ReadOnly = False
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window
        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        btnBuscarJob.Enabled = True
        cmbIdFiscal.ReadOnly = False
        cmbIdFiscal.BackColor = System.Drawing.SystemColors.Window

        txtNumGuis.ReadOnly = False
        txtNumGuis.Enabled = True
        txtNumGuis.BackColor = System.Drawing.SystemColors.Window
        cmbCodPag.ReadOnly = False
        cmbCodPag.BackColor = System.Drawing.SystemColors.Window

        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnModificarObservacion.Enabled = True

        cmbTipoNota.ReadOnly = False
        cmbTipoNota.BackColor = System.Drawing.SystemColors.Window
        cmbTipDoc.ReadOnly = False
        cmbTipDoc.BackColor = System.Drawing.SystemColors.Window
        txtSerieDocRef.ReadOnly = False
        txtSerieDocRef.BackColor = System.Drawing.SystemColors.Window
        txtNumDocRef.ReadOnly = False
        txtNumDocRef.BackColor = System.Drawing.SystemColors.Window
        txtMotivo.ReadOnly = False
        txtMotivo.BackColor = System.Drawing.SystemColors.Window
        cmbTipoAfectacionIgv.ReadOnly = False
        cmbTipoAfectacionIgv.BackColor = System.Drawing.SystemColors.Window

        edicion = True
        enableOpciones()
        dgvDatos.Select()
    End Sub
    Private Sub desactivar()

        txtTipoCambio.ReadOnly = True
        txtTipoCambio.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        cmbTipFac.ReadOnly = True
        cmbTipFac.BackColor = System.Drawing.SystemColors.Control
        cmbCodMot.ReadOnly = True
        cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        '**************************************************************
        cmbIdLocCli.ReadOnly = True
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbIdFiscal.ReadOnly = True
        cmbIdFiscal.BackColor = System.Drawing.SystemColors.Control

        txtNumGuis.ReadOnly = True
        txtNumGuis.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control

        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        btnModificarObservacion.Enabled = False

        cmbTipoNota.ReadOnly = True
        cmbTipoNota.BackColor = System.Drawing.SystemColors.Control
        cmbTipDoc.ReadOnly = True
        cmbTipDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDocRef.ReadOnly = True
        txtSerieDocRef.BackColor = System.Drawing.SystemColors.Control
        txtNumDocRef.ReadOnly = True
        txtNumDocRef.BackColor = System.Drawing.SystemColors.Control
        txtMotivo.ReadOnly = True
        txtMotivo.BackColor = System.Drawing.SystemColors.Control
        cmbTipoAfectacionIgv.ReadOnly = True
        cmbTipoAfectacionIgv.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        dgvDatos.Select()
    End Sub

  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oNotaCreditoService) = False Then
        oNotaCreditoService.Close()
      End If
      If isClosed(oNotaCreditoDetService) = False Then
        oNotaCreditoDetService.Close()
      End If
      If isClosed(oLocacionClienteService) = False Then
        oLocacionClienteService.Close()
      End If
      If isClosed(oDireccionFiscalService) = False Then
        oDireccionFiscalService.Close()
            End If
            If isClosed(oFacturaService) = False Then
                oFacturaService.Close()
            End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtObservacion.KeyUp _
                          , txtNumJob.KeyUp _
                          , txtIgv.KeyUp _
                          , txtTipoCambio.KeyUp _
                          , txtCliente.KeyUp _
                          , txtNumDoc.KeyUp _
                          , txtTotalNeto.KeyUp _
                          , txtTotalIGV.KeyUp _
                          , txtTotalPrecio.KeyUp _
                          , txtTotalDescuento.KeyUp _
                          , txtTotal.KeyUp _
                          , txtNumGuis.KeyUp
        Try
            If state_Search = True Then
                Dim campo As New Object
                If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                    campo = New Janus.Windows.GridEX.EditControls.EditBox
                ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                    campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
                ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                    campo = New TextBox
                End If
                campo = sender
                If campo.readonly = False Then
                    If campo.Text.Trim.Length > 0 Then
                        campo.BackColor = Color.White
                    Else
                        'campo.BackColor = Color.Red
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            cmbIdLocCli.ValueChanged _
                          , cmbCodMot.ValueChanged _
                          , cmbTipFac.ValueChanged _
                          , cmbCodMon.ValueChanged _
                          , cmbCodPag.ValueChanged _
                          , cmbIdFiscal.ValueChanged
        Try
            'If state_Search = True Then
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                'campo.BackColor = Color.Red
            End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '  If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '    e.KeyChar = Chr(0)
    '      End If
    'End Sub
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

                If CInt(row.Cells("IdNotaDet").Value) = codigo Then

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

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGrabar.Enabled = edicion
        biDeshacer.Enabled = edicion

        cmOpciones.Enabled = IIf(editable, Not edicion, False)
        'cmOpciones.Visible = IIf(editable, Not edicion, False)
        'miNuevo.Enabled = IIf(editable, True, False)
        miNuevo.Enabled = IIf(lblEstado.Text = "GENERADO", True, False)
        miMostrar.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
        miEliminar.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
  End Sub
  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Function ValidaCampos() As Boolean
    Try
            If state_button = True And toNumber(IdNota) = 0 Then

                MsgBox("Debe Ingresar el código de la factura.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(IdLocacion) = 0 Then
                MsgBox("Debe Ingresar el almacén del documento.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(IdSerieDoc) = 0 Then
                MsgBox("Debe Ingresar el tipo de documento.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipFac.Value) = 0 Then
                MsgBox("Debe Ingresar el tipo de la factura.", MsgBoxStyle.Information, "Información")
                cmbTipFac.BackColor = Color.Red
                cmbTipFac.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf ConLocCli > 1 And toNumber(cmbIdLocCli.Value) = 0 Then
                MsgBox("Debe una locación del Cliente.", MsgBoxStyle.Information, "Información")
                cmbIdLocCli.BackColor = Color.Red
                cmbIdLocCli.Focus()
                Return False
                'ElseIf toNumber(cmbIdFiscal.Value) = 0 Then
                '  MsgBox("Debe una dirección fiscal del cliente.", MsgBoxStyle.Information, "Información")
                '  cmbIdFiscal.BackColor = Color.Red
                '  cmbIdFiscal.Focus()
                '  Return False
            ElseIf toBlank(cmbCodMot.Value) = "" Then
                MsgBox("Debe ingresar el motivo de la factura.", MsgBoxStyle.Information, "Información")
                cmbCodMot.BackColor = Color.Red
                cmbCodMot.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf toNumber(txtTipoCambio.Text) = 0 Then
                MsgBox("El Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
                Return False
            ElseIf state_button = False And oNotaCreditoService.Buscar(IdSerieDoc, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And oNotaCreditoService.Estado(IdNota) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(cmbTipoNota.Text) = "" Then
                MsgBox("Debe ingresar el tipo de nota", MsgBoxStyle.Information, "Información")
                cmbTipoNota.Focus()
                Return False
            ElseIf toBlank(cmbTipDoc.Text) = "" Then
                MsgBox("Debe ingresar el tipo de documento de referencia", MsgBoxStyle.Information, "Información")
                cmbTipDoc.Focus()
                Return False
            ElseIf toBlank(txtSerieDocRef.Text) = "" And IdDocumento = "5" Then
                MsgBox("Debe ingresar la serie de documento de referencia", MsgBoxStyle.Information, "Información")
                txtSerieDocRef.Focus()
                Return False
            ElseIf toBlank(txtNumDocRef.Text) = "" And IdDocumento = "5" Then
                MsgBox("Debe ingresar el numero de documento de referencia", MsgBoxStyle.Information, "Información")
                txtNumDocRef.Focus()
                Return False
            ElseIf toBlank(txtMotivo.Text) = "" Then
                MsgBox("Debe ingresar el motivo", MsgBoxStyle.Information, "Información")
                txtMotivo.Focus()
                Return False
            Else
                Return True
            End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function
  Private Sub Insertar(ByVal registro As NotaCreditoService.NotaCredito)
    Try
      Dim estado_process As Integer
      estado_process = oNotaCreditoService.Insertar(registro)
      type_process = "insert"
      If estado_process > 0 Then
        IdNota = estado_process
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Else
        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Modificar(ByVal registro As NotaCreditoService.NotaCredito)
    Try
      Dim estado_process As Boolean
      estado_process = oNotaCreditoService.Actualizar(registro)
      type_process = "update"
      If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
                ObtenerRegistro()
                actualizar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Eliminar()
    Try
      Dim estado_process As Boolean
            estado_process = oNotaCreditoService.Borrar(IdNota, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As NotaCreditoService.NotaCredito
            registro = oNotaCreditoService.MostrarPorId(IdNota)

            IdNota = registro.IdNota
            IdLocacion = registro.Locacion.IdLocacion

            txtFecDoc.Text = registro.FecDoc
            txtNumDoc.Text = registro.NumDoc
            cmbTipFac.Value = registro.TipFac
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtTipoCambio.Text = registro.TipCam 'Format(registro.TipCam, "#0.000")
            listarCombosPorCliente()

            cmbIdLocCli.Value = registro.LocacionCliente.IdLocCli
            cmbIdFiscal.Value = registro.DireccionFiscal.IdFiscal
            cmbCodMot.Value = registro.Motivos.CodMot
            cmbCodPag.Value = registro.CondicionPago.CodPag
            txtNumJob.Text = registro.NumJob
            txtNumGuis.Text = registro.NumGuis
            cmbCodMon.Value = registro.Moneda.CodMon
            txtIgv.Text = registro.Igv
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.Estado
            txtVendedor.Text = registro.Persona.ApeNom

            cmbTipDoc.Value = registro.TipoDocumentoRef.IdDocumento
            If IdDocumento = "5" Then
                cmbTipoNota.Value = registro.TipoNotaCredito.CodTipoCre
            ElseIf IdDocumento = "6" Then
                cmbTipoNota.Value = registro.TipoNotaDebito.CodTipoDeb
            End If
            cmbTipoAfectacionIgv.Value = registro.TipoAfectacionIgv.CodTipoIgv
            txtSerieDocRef.Text = registro.CodSerieRef
            txtNumDocRef.Text = registro.NumDocRef
            txtMotivo.Text = registro.MotivoRef


        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS DE FACTURAS ================================================
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipos.Rows.Add(New Object() {"1", "Crédito"})
            dtTipos.Rows.Add(New Object() {"2", "Contado"})
            dtTipos.Rows.Add(New Object() {"3", "Nota Cargo"})
            dtTipos.Rows.Add(New Object() {"4", "Flete"})
            dtTipos.Rows.Add(New Object() {"5", "Embalaje"})

            cmbTipFac.DataSource = dtTipos
            cmbTipFac.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.SelectedIndex = 0
            dtTipos = Nothing
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
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing
            '======================================= CONDICIONES DE PAGO ========================================
            dtMotivos = oMaestroService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtMotivos
            cmbCodPag.DropDownList.DataMember = dtMotivos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtMotivos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtMotivos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesPag").ToString
            dtMotivos = Nothing
            '======================================= TIPO DOCUMENTO REFERENCIA ===================================
            dtTipoDocRef = oNotaCreditoService.MostrarTipoDocumentoRef.Tables(0)
            cmbTipDoc.DataSource = dtTipoDocRef
            cmbTipDoc.DropDownList.DataMember = dtTipoDocRef.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.DisplayMember = dtTipoDocRef.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.ValueMember = dtTipoDocRef.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(0).DataMember = dtTipoDocRef.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(1).DataMember = dtTipoDocRef.Columns("Nombre").ToString
            dtTipoDocRef = Nothing
            '======================================= TIPO NOTA ================================================
            If IdDocumento = "5" Then
                dtTipoNota = oNotaCreditoService.MostrarTipoNotaCredito.Tables(0)
                cmbTipoNota.DataSource = dtTipoNota
                cmbTipoNota.DropDownList.DataMember = dtTipoNota.Columns("DesTipo").ToString
                cmbTipoNota.DropDownList.DisplayMember = dtTipoNota.Columns("DesTipo").ToString
                cmbTipoNota.DropDownList.ValueMember = dtTipoNota.Columns("CodTipoCre").ToString
                cmbTipoNota.DropDownList.Columns(0).DataMember = dtTipoNota.Columns("CodTipoCre").ToString
                cmbTipoNota.DropDownList.Columns(1).DataMember = dtTipoNota.Columns("DesTipo").ToString
                dtTipoNota = Nothing
            ElseIf IdDocumento = "6" Then
                dtTipoNota = oNotaCreditoService.MostrarTipoNotaDebito.Tables(0)
                cmbTipoNota.DataSource = dtTipoNota
                cmbTipoNota.DropDownList.DataMember = dtTipoNota.Columns("DesTipo").ToString
                cmbTipoNota.DropDownList.DisplayMember = dtTipoNota.Columns("DesTipo").ToString
                cmbTipoNota.DropDownList.ValueMember = dtTipoNota.Columns("CodTipoDeb").ToString
                cmbTipoNota.DropDownList.Columns(0).DataMember = dtTipoNota.Columns("CodTipoDeb").ToString
                cmbTipoNota.DropDownList.Columns(1).DataMember = dtTipoNota.Columns("DesTipo").ToString
                dtTipoNota = Nothing
            End If
            '======================================= TIPO AFECTACION IGV ================================================
            dtAfectacionIgv = oFacturaService.MostrarTipoAfectacionIgv().Tables(0)
            cmbTipoAfectacionIgv.DataSource = dtAfectacionIgv
            cmbTipoAfectacionIgv.DropDownList.DataMember = dtAfectacionIgv.Columns("DesTipo").ToString
            cmbTipoAfectacionIgv.DropDownList.DisplayMember = dtAfectacionIgv.Columns("DesTipo").ToString
            cmbTipoAfectacionIgv.DropDownList.ValueMember = dtAfectacionIgv.Columns("CodTipoIgv").ToString
            cmbTipoAfectacionIgv.DropDownList.Columns(0).DataMember = dtAfectacionIgv.Columns("CodTipoIgv").ToString
            cmbTipoAfectacionIgv.DropDownList.Columns(1).DataMember = dtAfectacionIgv.Columns("DesTipo").ToString
            dtAfectacionIgv = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    
    Private Sub listarCombosPorCliente()
        '======================================= LOCACIONES DEL CLIENTE ================================================
        dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
        cmbIdLocCli.DataSource = dtLocaciones
        cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
        ConLocCli = dtLocaciones.Rows.Count
        dtLocaciones = Nothing
        '======================================= DIRECCIONES FISCALES ================================================
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
        'dtLocaciones = Nothing
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oNotaCreditoDetService.Mostrar(toNumber(IdNota)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.NotaCredito", "TotBruto", "IdNota", IdNota)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.NotaCredito", "TotDscto", "IdNota", IdNota)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.NotaCredito", "TotVenta", "IdNota", IdNota)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.NotaCredito", "TotIgv", "IdNota", IdNota)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.NotaCredito", "TotNeto", "IdNota", IdNota)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Ventas.NotaCredito", "CodMon", "IdNota", IdNota)) + ")"

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmNotaCredito_AgregarDetalle
                frm.state_button = False
                frm.IdNota = IdNota
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                frm.CodMot = cmbCodMot.Value

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdNotaDet)
                    End If
                Else
                    lLog = False
                End If
            End While
           
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oNotaCreditoDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdNotaDet").Text), IdNota)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmNotaCredito_AgregarDetalle
            frm.state_button = True
            frm.IdNotaDet = dgvDatos.CurrentRow.Cells("IdNotaDet").Text
            frm.IdNota = IdNota
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdNotaDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
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
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdNotaDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================

  Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
    Dim frm As New frmBuscarCliente
    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
      txtCliente.Text = frm.descripcion
      txtCliente.BackColor = System.Drawing.SystemColors.Control
      IdCliente = frm.codigo
            txtCliente.Select()
            listarCombosPorCliente()
    End If
  End Sub
  
    Private Sub btnAgregarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If
    End Sub
  Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
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
    actualizar()
  End Sub
  Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
    If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
      NuevoDetalle()
    End If
  End Sub
  
  Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        'If state_Search = True Then
        '  txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
        'End If
  End Sub
  Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
    Dim frm As New frmBuscarJob
    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
      txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()
        End If
  End Sub
  Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
    Dim frm As New frmNotaCredito_ModificarObservacion
    frm.state_button = state_button
    frm.IdNota = IdNota
    frm.txtObservacion.Text = toBlank(txtObservacion.Text)
    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
      txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub
  
  
    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New NotaCreditoService.NotaCredito
            Dim locacion As New NotaCreditoService.Locacion
            Dim clienete As New NotaCreditoService.Cliente
            Dim locacionCliente As New NotaCreditoService.LocacionCliente
            Dim direccion As New NotaCreditoService.DireccionFiscal
            Dim moneda As New NotaCreditoService.Moneda
            Dim motivo As New NotaCreditoService.Motivos
            Dim condicionPago As New NotaCreditoService.CondicionPago
            Dim serieDocumento As New NotaCreditoService.SerieDocumento
            Dim tipoafectaigv As New NotaCreditoService.TipoAfectacionIgv
            Dim tipodocumentoref As New NotaCreditoService.TipoDocumento
            Dim tiponotacredito As New NotaCreditoService.TipoNotaCredito
            Dim tiponotadebito As New NotaCreditoService.TipoNotaDebito

            registro.IdNota = IdNota
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            serieDocumento.IdSerieDoc = IdSerieDoc
            registro.SerieDocumento = serieDocumento
            registro.FecDoc = txtFecDoc.Text
            registro.NumDoc = txtNumDoc.Text
            registro.TipFac = cmbTipFac.Value
            clienete.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
            registro.Cliente = clienete
            locacionCliente.IdLocCli = IIf(toNumber(cmbIdLocCli.Value) = 0, Nothing, cmbIdLocCli.Value)
            registro.LocacionCliente = locacionCliente
            direccion.IdFiscal = IIf(toNumber(cmbIdFiscal.Value) = 0, Nothing, cmbIdFiscal.Value)
            registro.DireccionFiscal = direccion
            motivo.CodMot = cmbCodMot.Value
            registro.Motivos = motivo
            condicionPago.CodPag = toNull(cmbCodPag.Value)
            registro.CondicionPago = condicionPago
            registro.TipCam = toNull(txtTipoCambio.Text)
            registro.NumJob = toNull(txtNumJob.Text)
            registro.NumGuis = toNull(txtNumGuis.Text)
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.Observacion = toNull(txtObservacion.Text)

            tipoafectaigv.CodTipoIgv = toNull(cmbTipoAfectacionIgv.Value)
            registro.TipoAfectacionIgv = tipoafectaigv

            tipodocumentoref.IdDocumento = toNumber(cmbTipDoc.Value)
            registro.TipoDocumentoRef = tipodocumentoref
            If IdDocumento = "5" Then
                tiponotacredito.CodTipoCre = toNull(cmbTipoNota.Value)
                registro.TipoNotaCredito = tiponotacredito
                tiponotadebito.CodTipoDeb = Nothing
                registro.TipoNotaDebito = tiponotadebito
            ElseIf IdDocumento = "6" Then
                tiponotacredito.CodTipoCre = Nothing
                registro.TipoNotaCredito = tiponotacredito
                tiponotadebito.CodTipoDeb = toNull(cmbTipoNota.Value)
                registro.TipoNotaDebito = tiponotadebito
            End If
            registro.MotivoRef = toNull(txtMotivo.Text.Trim)
            registro.NumDocRef = toNull(txtNumDocRef.Text)
            registro.CodSerieRef = toNull(txtSerieDocRef.Text)

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
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
    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
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
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                               biEditar.MouseLeave, biGrabar.MouseLeave, biDeshacer.MouseLeave, biSalir.MouseLeave, _
                               miNuevo.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave, miMostrar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.MouseEnter
        sslError.Text = "Grabar los cambios hechos en la Nota de Credito/Debito."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los cambios hechos en la Nota de Credito/Debito."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Nota de Credito/Debito."
    End Sub

    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Nota de Credito/Debito."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle de la Nota de Credito/Debito."
    End Sub

    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario Nota de Credito/Debito."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario Nota de Credito/Debito."
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

    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        ' If state_Search = False  Then
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text)), "#0.000")
        'End If
    End Sub

    Private Sub cmbTipoAfectacionIgv_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoAfectacionIgv.ValueChanged
        If oFacturaService.ObtenerAplicaIgv(cmbTipoAfectacionIgv.Value) = False Then
            txtIgv.Value = 0.00
        Else
            txtIgv.Value = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion))
        End If
    End Sub
End Class
