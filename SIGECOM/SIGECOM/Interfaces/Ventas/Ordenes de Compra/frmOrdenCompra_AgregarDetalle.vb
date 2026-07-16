Imports System.Windows.Forms

Public Class frmOrdenCompra_AgregarDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridad As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Public lseparar As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOrdenDet As Integer
    Public IdOrden As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public estado As String
    Private CanPen As Integer
    Public IdSugerido As Integer

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtPreMer.KeyPress _
                          , txtTotal.KeyPress _
                          , txtCanMer.KeyPress _
                          , txtDesMer.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtStock.KeyPress _
                          , txtDscMer.KeyPress _
                          , txtItem.KeyPress _
                          , txtCodMerCli.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOrdenCompra_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtDesMer.Select()
        Else                    'Nuevo
            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            cbNoCore.Checked = False
            txtCodMer.Select()
        End If
        estado = oOrdenCompraService.Estado(IdOrden)
        If estado = "GENERADO" Or estado = "GN" Or state_button = False Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
        EnableOptionsAprobacion()
        EnableOptions()
        Dim oPermisousuario As SeguridadService.PermisoUsuario
        oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)
        If oPermisousuario.Precio = False Then
            txtPreMer.ReadOnly = True
            txtDscMer.ReadOnly = True
            txtPreMer.BackColor = System.Drawing.SystemColors.Control
            txtDscMer.BackColor = System.Drawing.SystemColors.Control
        Else
            txtPreMer.ReadOnly = False
            txtDscMer.ReadOnly = False
            txtPreMer.BackColor = System.Drawing.SystemColors.Window
            txtDscMer.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oOrdenCompraDetService) = False Then
                oOrdenCompraDetService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If
            If isClosed(oOrdenCompraService) = False Then
                oOrdenCompraService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtPreMer.KeyUp _
                          , txtCanMer.KeyUp _
                          , txtDesMer.KeyUp _
                          , txtCodMer.KeyUp _
                          , txtStock.KeyUp _
                          , txtDscMer.KeyUp _
                          , txtItem.KeyUp
        Try
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
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function calculateTotal() As Double
        txtTotal.Text = Math.Round((toNumber(txtCanMer.Value) * toDouble(txtPreMer.Text)) - (toDouble(txtPreMer.Value) * toDouble(txtDscMer.Text / 100)), 2)
    End Function
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub EnableOptionsAprobacion()
        '------------------------------------------------------------------------'
        'Evaluamos el Perfil del usuario
        'Donde solo el Supervisor con código “02” puEde aprobar la orden de compra
        '------------------------------------------------------------------------'
        If Session.CodPerfil = "02" Then
            txtPreMer.ReadOnly = True
            txtTotal.ReadOnly = True
            txtCanMer.ReadOnly = True
            txtDesMer.ReadOnly = True
            txtCodMer.ReadOnly = True
            txtStock.ReadOnly = True
            txtDscMer.ReadOnly = True
            txtItem.ReadOnly = True
            txtCodMerCli.ReadOnly = True
            btnBuscarMercaderia.Enabled = False

            ''>>>=============================================================================Separar
            'gbSeparacion.Visible = True
            'btnGuardar.Text = "Separar"
            'Me.Size = New System.Drawing.Size(473, 335)
            'btnGuardar.Location = New System.Drawing.Point(308, 273)
            ''btnCancelar.Location = New System.Drawing.Point(383, 273)



            'Me.Size = New System.Drawing.Size(479, 282)
            'btnGuardar.Location = New System.Drawing.Point(293, 220)
            'btnCancelar.Location = New System.Drawing.Point(368, 220)
        Else
            txtPreMer.ReadOnly = False
            'txtTotal.ReadOnly = False
            txtCanMer.ReadOnly = False
            txtCanMer.BackColor = System.Drawing.SystemColors.Window
            ' txtDesMer.ReadOnly = False
            ' txtCodMer.ReadOnly = False
            'txtStock.ReadOnly = False
            txtDscMer.ReadOnly = False
            txtItem.ReadOnly = False
            txtCodMerCli.ReadOnly = False
            'btnBuscarMercaderia.Enabled = True

            ''========================================================''Separar a otro formulario
            'gbSeparacion.Visible = False
            'btnGuardar.Text = "Guardar"
            'Me.Size = New System.Drawing.Size(473, 227)
            'Me.btnGuardar.Location = New System.Drawing.Point(308, 164)
            'Me.btnCancelar.Location = New System.Drawing.Point(383, 164)
            '--


            'Me.Size = New System.Drawing.Size(479, 203)
            'Me.btnGuardar.Location = New System.Drawing.Point(293, 141)
            'Me.btnCancelar.Location = New System.Drawing.Point(368, 141)

        End If
        If state_button = False Or CanPen > 0 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
        End If
    End Sub
    Private Sub EnableOptions()

        If Session.CodPerfil = "14" And lseparar Then
            txtPreMer.ReadOnly = True
            txtTotal.ReadOnly = True
            txtCanMer.ReadOnly = True
            txtDesMer.ReadOnly =  True
            txtCodMer.ReadOnly = True
            txtStock.ReadOnly = True
            txtDscMer.ReadOnly = True
            txtItem.ReadOnly = True
            txtCodMerCli.ReadOnly = True
            btnBuscarMercaderia.Enabled = False
            ' ''gbSeparacion.Visible = True
            ' ''btnGuardar.Text = "Separar"
            ' ''Me.Size = New System.Drawing.Size(473, 335)
            ' ''btnGuardar.Location = New System.Drawing.Point(308, 273)
            ' ''btnCancelar.Location = New System.Drawing.Point(383, 273)
            'Me.Size = New System.Drawing.Size(479, 282)
            'btnGuardar.Location = New System.Drawing.Point(293, 220)
            'btnCancelar.Location = New System.Drawing.Point(368, 220)
        End If
    End Sub
    Private Sub desactivar()
        txtDesMer.ReadOnly = True
        txtDesMer.BackColor = System.Drawing.SystemColors.Control
        txtDscMer.ReadOnly = True
        txtDscMer.BackColor = System.Drawing.SystemColors.Control
        txtCanMer.ReadOnly = True
        txtCanMer.BackColor = System.Drawing.SystemColors.Control
        txtItem.ReadOnly = True
        txtItem.BackColor = System.Drawing.SystemColors.Control
        txtPreMer.ReadOnly = True
        txtPreMer.BackColor = System.Drawing.SystemColors.Control
        txtCodMerCli.ReadOnly = True
        txtCodMerCli.BackColor = System.Drawing.SystemColors.Control

        ''-----------------------------------------------------------------------------------------Sacar
        'If (estado = "PARCIAL" Or estado = "PA") And CanPen <> 0 Then
        '    txtCanSep.ReadOnly = False
        '    txtCanSep.BackColor = System.Drawing.SystemColors.Window
        '    txtFecIniSep.ReadOnly = False
        '    txtFecIniSep.BackColor = System.Drawing.SystemColors.Window
        '    txtFecFinSep.ReadOnly = False
        '    txtFecFinSep.BackColor = System.Drawing.SystemColors.Window
        '    txtObservacion.ReadOnly = False
        '    txtObservacion.BackColor = System.Drawing.SystemColors.Window
        'Else
        '    txtCanSep.ReadOnly = True
        '    txtCanSep.BackColor = System.Drawing.SystemColors.Control
        '    txtFecIniSep.ReadOnly = True
        '    txtFecIniSep.BackColor = System.Drawing.SystemColors.Control
        '    txtFecFinSep.ReadOnly = True
        '    txtFecFinSep.BackColor = System.Drawing.SystemColors.Control
        '    txtObservacion.ReadOnly = True
        '    txtObservacion.BackColor = System.Drawing.SystemColors.Control
        'End If

        cbNoCore.Enabled = False
        cbSugerir.Enabled = False
        txtPrecioSug.ReadOnly = True
        txtPrecioSug.BackColor = System.Drawing.SystemColors.Control
        txtDsctoSug.ReadOnly = True
        txtDsctoSug.BackColor = System.Drawing.SystemColors.Control
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresar el código de la Orden. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
                'ElseIf txtPreMer.Text.Trim.Length > 0 And CDbl(txtPreMer.Text.Trim) <= 0 Then
                '    MsgBox("Debe Ingresar el precio del artículo ", MsgBoxStyle.Information, "Información")
                '    txtPreMer.BackColor = Color.Red
                '    txtPreMer.Focus()
                '    Return False
            ElseIf oOrdenCompraService.Estado(IdOrden) <> "GENERADO" Then
                MsgBox("Ya no puede realizar modificaciones por que la Orden ya no esta en estado GENERADO.", MsgBoxStyle.Information, "Información")
                estado = oOrdenCompraService.Estado(IdOrden)
                Return False
            ElseIf state_button = False And oOrdenCompraDetService.Buscar(IdOrden, toBlank(txtCodMer.Text)) = True Then
                MsgBox("Código " + txtCodMer.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Text = ""
                txtCodMer.Focus()
                Return False
            ElseIf cbSugerir.Checked = True And txtPrecioSug.Value <= 0 Then
                MsgBox("El precio no es Válido", MsgBoxStyle.Information, "Información")
                txtPrecioSug.Focus()
                Return False
            ElseIf cbSugerir.Checked = True And txtDsctoSug.Value < 0 Then
                MsgBox("El descuento no es Válido", MsgBoxStyle.Information, "Información")
                txtPrecioSug.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As OrdenCompraDetService.OrdenCompraDet)
        Try
            Dim estado_process As Integer
            estado_process = oOrdenCompraDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOrdenDet = estado_process
                If cbSugerir.Checked = True Then
                    oOrdenCompraDetService.InsertarSugerido(IdOrdenDet, IdOrden, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoOrden", "IdSugerido", "IdOrden", IdOrden)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As OrdenCompraDetService.OrdenCompraDet)
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenCompraDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                If cbSugerir.Checked = True And IdSugerido > 0 Then
                    oOrdenCompraDetService.ActualizarSugerido(IdSugerido, IdOrdenDet, IdOrden, txtPrecioSug.Value, txtDsctoSug.Value)
                ElseIf cbSugerir.Checked = True And IdSugerido = 0 Then
                    oOrdenCompraDetService.InsertarSugerido(IdOrdenDet, IdOrden, txtPrecioSug.Value, txtDsctoSug.Value)
                    IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoOrden", "IdSugerido", "IdOrden", IdOrden)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenCompraDetService.OrdenCompraDet
            registro = oOrdenCompraDetService.MostrarPorId(toNumber(IdOrdenDet))

            IdOrdenDet = registro.IdOrdenDet
            IdOrden = registro.OrdenCompra.IdOrden
            txtItem.Value = registro.Item
            txtCodMer.Text = registro.Mercaderia.CodMer
            txtDesMer.Text = registro.Mercaderia.DesMer1
            txtCodMerCli.Text = registro.CodMerCli
            txtCanMer.Value = registro.CanMer
            txtPreMer.Text = toDouble(registro.PreMer)
            txtDscMer.Text = toDouble(registro.DscMer)
            txtTotal.Text = toDouble(registro.TotFila)
            txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
            CanPen = registro.CanPen
            cbNoCore.Checked = registro.NoCore
            estado = oOrdenCompraService.Estado(IdOrden)

            If IdSugerido > 0 Then
                cbSugerir.Checked = True
                cbSugerir.Enabled = False
                Dim Sugerido As OrdenCompraDetService.SugeridoOrdenDetalle
                Sugerido = oOrdenCompraDetService.MostrarPorIdSugerido(IdSugerido, IdOrdenDet)
                txtPrecioSug.Value = Sugerido.PreMerSug
                txtDsctoSug.Value = Sugerido.DsctoSug
            Else
                cbSugerir.Checked = False
            End If

            'If Session.CodPerfil = "02" Or (Session.CodPerfil = "14" And lseparar = True) Then

            '    txtCanSep.Value = registro.CanSep
            '    If registro.FecIniSep Is Nothing Then
            '        txtFecIniSep.IsNullDate = True
            '    Else
            '        txtFecIniSep.Text = registro.FecIniSep
            '    End If
            '    If registro.FecFinSep Is Nothing Then
            '        txtFecFinSep.IsNullDate = True
            '    Else
            '        txtFecFinSep.Text = registro.FecFinSep
            '    End If
            '    txtObservacion.Text = toBlank(registro.Observacion)
            'End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub llenarCombos()
        Try
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub Aprobar()
    '    Try
    '        Dim estado_process As Boolean
    '        estado_process = oOrdenCompraDetService.Separar(0, IdOrdenDet, txtCanSep.Value _
    '                                                        , txtFecIniSep.Text, txtFecFinSep.Text _
    '                                                        , toBlank(txtObservacion.Text) _
    '                                                        , Session.sCodUsu)
    '        type_process = "update"
    '        If estado_process = True Then
    '            Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '        Else
    '            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Function ValidaAprobacion() As Boolean
        Try
            Dim frm As New frmOrdenCompra

            If toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresar el código de la orden. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(IdOrdenDet) = 0 Then
                MsgBox("Debe Ingresar el código del detalle . ", MsgBoxStyle.Information, "Información")
                Return False
                'ElseIf toNumber(txtCanSep.Value) <= 0 Then
                '    MsgBox("La cantidad para separar debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                '    txtCanSep.BackColor = Color.Red
                '    txtCanSep.Focus()
                '    Return False
                'ElseIf toBlank(txtFecIniSep.Text) = "" Then
                '    MsgBox("Debe ingresar la fecha de inicio.", MsgBoxStyle.Information, "Información")
                '    txtFecIniSep.BackColor = Color.Red
                '    txtFecIniSep.Focus()
                '    Return False
                'ElseIf toBlank(txtFecFinSep.Text) = "" Then
                '    MsgBox("Debe ingresar la fecha final", MsgBoxStyle.Information, "Información")
                '    txtFecFinSep.BackColor = Color.Red
                '    txtFecFinSep.Focus()
                '    Return False
                'ElseIf txtFecIniSep.Value > txtFecFinSep.Value Then
                '    MsgBox("Fecha INICIAL no puede ser mayor que la fecha FINAL", MsgBoxStyle.Information, "Información")
                '    txtFecIniSep.Focus()
                '    Return False
            ElseIf Session.CodPerfil <> "02" And lseparar = False Then
                MsgBox("Su perfil no es de SUPERVISOR y no puede aprobar esta orden.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf CanPen <= 0 Then
                MsgBox("Ya no puede aprobar, por que no hay cantidad pendientes.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf frm.AprOrden = True And (estado = "GENERADO" Or estado = "GN" Or estado = "ENVIADO") Then
                MsgBox("No puede Separar ningún repuesto, debido a que la orden no esta APROBADA.", MsgBoxStyle.Information, "Información")
                estado = oOrdenCompraService.Estado(IdOrden)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        '------------------------------------------------------------------------'
        'Evaluamos el Perfil del usuario
        'Donde solo el Supervisor con código “02” pude aprobar la orden de compra
        '------------------------------------------------------------------------'
        If (Session.CodPerfil <> "02" And lseparar = False) Or (Session.CodPerfil = "14" And lseparar = False) Then

            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidaCampos() Then

                Dim registro As New OrdenCompraDetService.OrdenCompraDet
                Dim orden As New OrdenCompraDetService.OrdenCompra
                Dim mercaderia As New OrdenCompraDetService.Mercaderia

                registro.IdOrdenDet = IdOrdenDet
                orden.IdOrden = IdOrden
                registro.OrdenCompra = orden
                registro.Item = txtItem.Value
                mercaderia.CodMer = txtCodMer.Text
                mercaderia.DesMer1 = txtDesMer.Text
                registro.Mercaderia = mercaderia
                registro.CodMerCli = txtCodMerCli.Text
                registro.CanMer = txtCanMer.Value
                registro.PreMer = txtPreMer.Text
                registro.DscMer = txtDscMer.Text
                registro.TotFila = txtTotal.Text
                registro.CodUsu = Session.sCodUsu
                registro.NoCore = cbNoCore.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
            'ElseIf Session.CodPerfil = "02" Or (Session.CodPerfil = "14" And lseparar) Then
            '    If ValidaAprobacion() Then
            '        Aprobar()
            '    End If
        End If
    End Sub
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
            txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
            txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)        
            calculateTotal()
        End If
        txtCodMer.Select()
    End Sub
    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.Click
        calculateTotal()
    End Sub
    Private Sub btnSugerirPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'Private Sub txtCanSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If txtCanSep.ReadOnly = False Then
    '            If txtCanSep.Value > 0 Then
    '                txtCanSep.BackColor = Color.White
    '            Else
    '                txtCanSep.BackColor = Color.Red
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If state_button = False Then
            Try
                Dim oPermisousuario As SeguridadService.PermisoUsuario
                oPermisousuario = oSeguridad.MostrarPermisos(Session.sCodUsu)

                If Len(Trim(txtCodMer.Text)) > 0 And state_button = False Then

                    If oLocacionMercaderiaService.Buscar(IdLocacion, txtCodMer.Text) Then
                        Dim LocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderia
                        LocacionMercaderia = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, txtCodMer.Text)
                        ' txtCodMer.Text = LocacionMercaderia.Mercaderia.CodMer
                        'txtStock.Text = LocacionMercaderia.Stock
                        txtStock.Text = oPrecioService.MostrarStock(IdLocacion, txtCodMer.Text)
                        txtDesMer.Text = LocacionMercaderia.Mercaderia.DesMer1
                        txtPreMer.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                        txtDscMer.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
                        calculateTotal()
                        If oPermisousuario.Precio = False Then
                            txtPreMer.ReadOnly = True
                            txtDscMer.ReadOnly = True
                            txtPreMer.BackColor = System.Drawing.SystemColors.Control
                            txtDscMer.BackColor = System.Drawing.SystemColors.Control
                        Else
                            txtPreMer.ReadOnly = False
                            txtDscMer.ReadOnly = False
                            txtPreMer.BackColor = System.Drawing.SystemColors.Window
                            txtDscMer.BackColor = System.Drawing.SystemColors.Window
                        End If
                    Else
                        MsgBox("No existe el codigo ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub cbSugerir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSugerir.CheckedChanged
        If cbSugerir.Checked Then
            lblPrecioSug.Visible = True
            lblPrecioSug2.Visible = True
            lblDsctoSug.Visible = True
            lblDsctoSug2.Visible = True
            txtPrecioSug.Visible = True
            txtDsctoSug.Visible = True
            If IdSugerido = 0 Then
                txtPrecioSug.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, txtCodMer.Text, CodMon, Date.Today)
                txtDsctoSug.Text = oPrecioService.DescuentoVenta(IdLocacion, IdCliente, txtCodMer.Text)
            End If
            txtPrecioSug.Focus()
        Else
            lblPrecioSug.Visible = False
            lblPrecioSug2.Visible = False
            lblDsctoSug.Visible = False
            lblDsctoSug2.Visible = False
            txtPrecioSug.Visible = False
            txtDsctoSug.Visible = False
            txtPrecioSug.Value = 0
            txtDsctoSug.Value = 0
        End If
    End Sub

    Private Sub txtPrecioSug_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioSug.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDsctoSug.Focus()
        End If
    End Sub

    Private Sub txtDsctoSug_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsctoSug.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

End Class
