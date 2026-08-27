Imports System.ServiceModel
Public Class frmComOrdenCompraDet

    '============================Servicios===================================
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient   'MercaderiaService.MercaderiaServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    'Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private Solicitud As Boolean
    Private dtDatos As DataTable
    Private dtTipoGasto As DataTable
    Public IdOrdenDet As Integer
    Public IdOrden As Integer
    Public IdProveedor As Integer
    Public CodMon As String
    Public estado As Integer
    'Public CodArea As String
    'Private dtAreas As DataTable          'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
    Private dtRubros As DataTable
    Private dtPlaca As DataTable
    'Private dtCentroCosto As DataTable            'Se agrega el centro de Costo 05/12/2012      'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014

    '=============================Evento Load==================================
    Private Sub frmComOrdenCompraDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        Solicitud = oOrdenesCompraDetService.BuscarSolicitud(IdOrden, IdOrdenDet)
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtDesMer.Select()
            txtObservTipoGasto.Text = ""
        Else                          'Nuevo
            'cmbArea.Value = CodArea
            desactivar()
            txtCodMer.Select()
        End If
        estado = oOrdenesCompraService.ObtenerEstado(IdOrden)
        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmComOrdenCompraDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    '==========================Evento KeyPress==================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtPreMer.KeyPress _
                          , txtTotal.KeyPress _
                          , txtCodMer.KeyPress _
                          , txtDscMer.KeyPress _
                          , txtCanMer.KeyPress _
                          , txtItem.KeyPress _
                          , cmbPlaca.KeyPress _
                          , txtObservacion.KeyPress _
                          , cmbTipoGasto.KeyPress _
                          , cmbRubro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraDetService.Close()
            'oMaestroService.Close()
            oOrdenesCompraService.Close()
            oMercaderiaService.Close()
            oGastoRealService.Close()
            oJobService.Close()
            oVehiculoService.Close()
            'oPersonaService.Close()
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
            'oMaestroService.Abort()
            oOrdenesCompraService.Abort()
            oMercaderiaService.Abort()
            oGastoRealService.Abort()
            oJobService.Abort()
            oVehiculoService.Abort()
            'oPersonaService.Abort()
            oSolicitudGastoDetService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
            'oMaestroService.Abort()
            oOrdenesCompraService.Abort()
            oMercaderiaService.Abort()
            oGastoRealService.Abort()
            oJobService.Abort()
            oVehiculoService.Abort()
            'oPersonaService.Abort()
            oSolicitudGastoDetService.Abort()
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtPreMer.KeyUp _
                          , txtDesMer.KeyUp _
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
        'Dim Total As Double
        'Dim Descuento As Double
        'Total = Math.Round((toDouble(txtCanMer.Value) * toDouble(txtPreMer.Value)), 2)
        'Descuento = Math.Round(((toDouble(txtPreMer.Value) * toDouble(txtDscMer.Value)) / 100), 2)
        'txtTotal.Value = Total
        txtTotal.Text = Math.Round((toDouble(txtCanMer.Value) * toDouble(txtPreMer.Text)) - (toDouble(txtPreMer.Value) * toDouble(txtDscMer.Text / 100)), 2)
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

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Function ValidaCampos() As Boolean
        Dim dtTable As New DataTable
        dtTable = oSolicitudGastoDetService.MostrarRubros(toNumber(cmbTipoGasto.Value)).Tables(0)
        Try
            If toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresar el código de la Orden. ", MsgBoxStyle.Information, "Información")
                Return False
                'ElseIf toBlank(txtCodMer.Text) = "" Then
                '    MsgBox("Debe Ingresar el código de la mercadería.", MsgBoxStyle.Information, "Información")
                '    txtCodMer.BackColor = Color.Red
                '    txtCodMer.Focus()
                '    Return False
            ElseIf toDouble(txtPreMer.Value) <= 0 Then
                MsgBox("El precio debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtPreMer.BackColor = Color.Red
                txtPreMer.Focus()
                Return False
            ElseIf toDouble(txtDscMer.Value) < 0 Then
                MsgBox("El descuento no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtDscMer.Focus()
                Return False
            ElseIf toDouble(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad solicitada debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtCanMer.BackColor = Color.Red
                txtCanMer.Focus()
                Return False
            ElseIf toNumber(cmbTipoGasto.Value) = 0 Then
                MsgBox("Debe ingresar el tipo de gasto", MsgBoxStyle.Information, "Información")
                cmbTipoGasto.BackColor = Color.Red
                cmbTipoGasto.Focus()
                Return False
            ElseIf toNumber(cmbRubro.Value) = 0 And dtTable.Rows.Count > 0 Then '-------- 04/07/2018 --------         
                MsgBox("Debe Ingresar el Rubro", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
                'ElseIf cmbRubro.SelectedIndex = 0 Then
                '    MsgBox("Debe Ingresar el Rubro.", MsgBoxStyle.Information, "Información")
                '    cmbRubro.Focus()
                '    Return False
                '----------------- Se comento ya que ahora el campo Rubro es obligatorio en todos los casos ----------------- (21/09/2016)
                'ElseIf toBlank(txtNumJob.Text) <> "" And cmbRubro.SelectedIndex = 0 Then
                '    MsgBox("Debe Ingresar el Rubro.", MsgBoxStyle.Information, "Información")
                '    cmbRubro.Focus()
                '    Return False
                '-------------------- Se comenta ya que ingresará el centro de costo en el módulo de facturación -------------------
                'ElseIf toBlank(cmbArea.Value) = "" Then
                '    MsgBox("Debe de Ingresar el Área.", MsgBoxStyle.Information, "Información")
                '    'cmbArea.BackColor = Color.Red
                '    cmbArea.Focus()
                '    Return False
                'ElseIf toBlank(cmbCentroCosto.Value) = "" Then
                '    MsgBox("Debe de Ingresar el Centro de Costo.", MsgBoxStyle.Information, "Información")
                '    'cmbCentroCosto.BackColor = Color.Red
                '    cmbCentroCosto.Focus()
                '    Return False
                '-------------------------------------------------------------------------------------------------------------------------------------------------------
            ElseIf oOrdenesCompraService.ObtenerEstado(IdOrden) <> 1 Then
                MsgBox("Ya no puede realizar modificaciones por que la Orden ya no esta en estado GENERADO.", MsgBoxStyle.Information, "Información")
                estado = oOrdenesCompraService.ObtenerEstado(IdOrden)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        If Solicitud Then
            btnGuardar.Enabled = If(estado = 1, True, False)      'se cambio para modificar el Job '17/01/2012
        Else
            If estado = 1 Then
                activar()
                btnGuardar.Enabled = True
            Else
                btnGuardar.Enabled = False
                desactivar()
            End If
        End If
    End Sub

    Private Sub activar()
        If Solicitud Then
            desactivar()
            If estado = 1 Then          'se cambio para modificar el Job '17/01/2012
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbRubro.ReadOnly = False
                cmbRubro.BackColor = System.Drawing.SystemColors.Window
                cmbTipoGasto.ReadOnly = False
                cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
            End If
        Else
            If state_button Then
                If estado <> 1 Then
                    desactivar()
                Else
                    txtCodMer.ReadOnly = True
                    txtCodMer.BackColor = System.Drawing.SystemColors.Control
                    btnBuscarMercaderia.Enabled = False
                    txtDesMer.ReadOnly = False
                    txtDesMer.BackColor = System.Drawing.SystemColors.Window
                    txtDscMer.ReadOnly = False
                    txtDscMer.BackColor = System.Drawing.SystemColors.Window
                    txtCanMer.ReadOnly = False
                    txtCanMer.BackColor = System.Drawing.SystemColors.Window
                    txtItem.ReadOnly = False
                    txtItem.BackColor = System.Drawing.SystemColors.Window
                    txtPreMer.ReadOnly = False
                    txtPreMer.BackColor = System.Drawing.SystemColors.Window
                    txtObservacion.ReadOnly = False
                    txtObservacion.BackColor = System.Drawing.SystemColors.Window
                    txtNumJob.ReadOnly = False
                    txtNumJob.BackColor = System.Drawing.SystemColors.Window
                    btnBuscarJob.Enabled = True
                    cmbTipoGasto.ReadOnly = False
                    cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
                    cmbRubro.ReadOnly = False
                    cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    'cmbArea.ReadOnly = False
                    'cmbArea.BackColor = System.Drawing.SystemColors.Window
                    'cmbCentroCosto.ReadOnly = False
                    'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                    cmbPlaca.ReadOnly = False
                    cmbPlaca.BackColor = System.Drawing.SystemColors.Window
                End If
            Else
                txtCodMer.ReadOnly = False
                txtCodMer.BackColor = System.Drawing.SystemColors.Window
                btnBuscarMercaderia.Enabled = True
                txtDesMer.ReadOnly = False
                txtDesMer.BackColor = System.Drawing.SystemColors.Window
                txtDscMer.ReadOnly = False
                txtDscMer.BackColor = System.Drawing.SystemColors.Window
                txtCanMer.ReadOnly = False
                txtCanMer.BackColor = System.Drawing.SystemColors.Window
                txtItem.ReadOnly = False
                txtItem.BackColor = System.Drawing.SystemColors.Window
                txtPreMer.ReadOnly = False
                txtPreMer.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbTipoGasto.ReadOnly = False
                cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
                cmbRubro.ReadOnly = False
                cmbRubro.BackColor = System.Drawing.SystemColors.Window
                'cmbArea.ReadOnly = False
                'cmbArea.BackColor = System.Drawing.SystemColors.Window
                'cmbCentroCosto.ReadOnly = False
                'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                cmbPlaca.ReadOnly = False
                cmbPlaca.BackColor = System.Drawing.SystemColors.Window
            End If
        End If
    End Sub

    Private Sub desactivar()
        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        btnBuscarMercaderia.Enabled = False
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
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbTipoGasto.ReadOnly = True
        cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        'cmbArea.ReadOnly = True
        'cmbArea.BackColor = System.Drawing.SystemColors.Control
        'cmbCentroCosto.ReadOnly = True
        'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        cmbPlaca.ReadOnly = True
        cmbPlaca.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As OrdenesCompraDetService.OrdenesCompraDet)
        Try
            Dim estado_process As Integer
            estado_process = oOrdenesCompraDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOrdenDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As OrdenesCompraDetService.OrdenesCompraDet)
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenesCompraDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenesCompraDetService.OrdenesCompraDet
            registro = oOrdenesCompraDetService.Obtener(toNumber(IdOrdenDet))

            IdOrdenDet = registro.IdOrdenDet
            IdOrden = registro.OrdenesCompra.IdOrden
            txtItem.Value = registro.Item
            txtCodMer.Text = registro.CodMer
            txtDesMer.Text = registro.DesMer
            txtCanMer.Value = registro.CanMer
            txtPreMer.Text = toDouble(registro.PreMer)
            txtDscMer.Text = toDouble(registro.DscMer)
            txtObservacion.Text = registro.Observacion
            txtTotal.Text = toDouble(registro.TotalFila)
            cmbTipoGasto.Value = registro.TipoGasto.IdTipoGasto

            txtNumJob.Text = registro.Job.CodJob
            'cmbArea.Value = registro.CentroCosto.Area.CodArea
            'cmbCentroCosto.Value = registro.CentroCosto.CodCentro

            If CStr(registro.RubroGasto.CodRubro) <> "" Then
                cmbRubro.Value = registro.RubroGasto.CodRubro
            Else
                cmbRubro.SelectedIndex = 0
            End If

            If registro.Unidad.Placa = Nothing Or registro.Unidad.Placa = "" Then
                cmbPlaca.SelectedIndex = 0
            Else
                cmbPlaca.Value = registro.Unidad.Placa
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== AREAS ===============================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'dtAreas = Nothing

            ''========================================== RUBROS ===============================================
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '========================================== PLACA ===============================================
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos1(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing

            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            dtTipoGasto.Rows.InsertAt(getRowTodos(dtTipoGasto), 0)
            cmbTipoGasto.DataSource = dtTipoGasto
            cmbTipoGasto.DropDownList.DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.DisplayMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.ValueMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(0).DataMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(1).DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.Columns(2).DataMember = dtTipoGasto.Columns("Observacion").ToString
            cmbTipoGasto.SelectedIndex = 0
            dtTipoGasto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
    '    Try
    '        'If cmbArea.Value <> "" Then
    '        '====================================== CENTRO COSTO ===========================================
    '        dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
    '        'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
    '        cmbCentroCosto.DataSource = dtCentroCosto
    '        cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
    '        cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
    '        'If cmbArea.Value <> "" Then
    '        '    cmbCentroCosto.SelectedIndex = 1
    '        'Else
    '        cmbCentroCosto.SelectedIndex = 0
    '        'End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New OrdenesCompraDetService.OrdenesCompraDet
            Dim orden As New OrdenesCompraDetService.OrdenesCompra
            Dim solicitudCompraDet As New OrdenesCompraDetService.SolicitudCompraDet
            'Dim Area As New OrdenesCompraDetService.Area
            'Dim CentroCosto As New OrdenesCompraDetService.CentroCosto
            Dim Job As New OrdenesCompraDetService.Job
            Dim Rubro As New OrdenesCompraDetService.RubroGasto
            Dim Unidad As New OrdenesCompraDetService.Unidad
            Dim tipogasto As New OrdenesCompraDetService.TipoGasto

            registro.IdOrdenDet = IdOrdenDet
            orden.IdOrden = IdOrden
            registro.OrdenesCompra = orden
            registro.Item = txtItem.Value
            registro.CodMer = toNull(txtCodMer.Text)
            registro.DesMer = txtDesMer.Text
            registro.CanMer = txtCanMer.Value
            registro.PreMer = txtPreMer.Text
            registro.DscMer = txtDscMer.Text
            registro.Observacion = txtObservacion.Text
            registro.TotalFila = txtTotal.Text
            tipogasto.IdTipoGasto = toNumber(cmbTipoGasto.Value)
            registro.TipoGasto = tipogasto

            'Area.CodArea = cmbArea.Value
            'registro.Area = Area

            'Area.CodArea = cmbArea.Value
            'CentroCosto.CodCentro = cmbCentroCosto.Value
            'CentroCosto.Area = Area
            'registro.CentroCosto = CentroCosto


            Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
            registro.Job = Job
            Rubro.CodRubro = IIf(cmbRubro.SelectedIndex = 0, Nothing, cmbRubro.Value)
            registro.RubroGasto = Rubro
            Unidad.Placa = IIf(cmbPlaca.SelectedIndex = 0, Nothing, cmbPlaca.Value)
            registro.Unidad = Unidad

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.FecModifica = Today

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm.codigo
            txtDesMer.Text = frm.descripcion
            txtCodMer.Focus()
        End If
        txtCodMer.Select()
    End Sub

    Private Sub txtCanMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanMer.TextChanged
        calculateTotal()
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If oMercaderiaService.Buscar(Trim(txtCodMer.Text), Session.sCodEmp) Then
            Dim mercaderia As ProductoService.Producto  'MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
            txtDesMer.Text = mercaderia.DesMer1
        End If
    End Sub

    Private Sub txtPreMer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPreMer.TextChanged, txtDscMer.TextChanged
        calculateTotal()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Len(Trim(txtNumJob.Text)) > 0 Then
                    If Not (oJobService.Buscar(txtNumJob.Text)) Then
                        MsgBox("Número de Job no existente, Verifique")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()
                    ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                        MsgBox("Número de Job Liquidado, Verifique")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()
                    Else
                        'If txtNumJob.Enabled = True Then
                        '    cmbRubro.Enabled = True
                        '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
                        'End If
                        cmbRubro.Focus()
                    End If
                Else
                    'cmbRubro.Enabled = False
                    'cmbRubro.BackColor = System.Drawing.SystemColors.Control
                    'cmbRubro.SelectedIndex = 0
                    'cmbPlaca.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de Job Liquidado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    'If txtNumJob.Enabled = True Then
                    '    cmbRubro.Enabled = True
                    '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    'End If
                    cmbRubro.Focus()
                End If
            Else
                'cmbRubro.Enabled = False
                'cmbRubro.BackColor = System.Drawing.SystemColors.Control
                'cmbRubro.SelectedIndex = 0
                'cmbPlaca.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbTipoGasto_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoGasto.ValueChanged
        ObtenerObservacionTipoGasto()
        LlenarRubroGasto()
    End Sub

    Private Sub LlenarRubroGasto()
        Try

            '========================================== RUBROS ===============================================
            dtRubros = oSolicitudGastoDetService.MostrarRubros(cmbTipoGasto.Value).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos1(dtRubros), 0)

            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR RUBRO GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerObservacionTipoGasto()
        If cmbTipoGasto.SelectedIndex <> 0 Then
            txtObservTipoGasto.Text = toBlank(cmbTipoGasto.DropDownList.GetRow.Cells(2).Text)    'Obtiene el Texto de la 3 columna del Combo TipoGasto
        Else
            txtObservTipoGasto.Text = ""
        End If
    End Sub

    'Private Sub txtNumJob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.TextChanged
    '    If txtNumJob.Text <> "" Then
    '        If txtNumJob.Enabled = True Then
    '            cmbRubro.Enabled = True
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Window
    '        Else
    '            cmbRubro.Enabled = False
    '            cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '        End If
    '    Else
    '        cmbRubro.Enabled = False
    '        cmbRubro.BackColor = System.Drawing.SystemColors.Control
    '    End If
    'End Sub

End Class