Imports System.ServiceModel

Public Class frmServicios_Cotizacion_Nuevo

    Private oCotizacionServicioDetService As New CotizacionServicioDetService.CotizacionServicioDetServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public estado As Integer
    Public IdCotizacionSer As Integer
    Public IdCotizacionDet As Integer
    Public IdCliente As Integer
    Public codMon As String
    Public NumCotizacion As String
    Public NumCotizacion2 As String
    Public IdRubro As Integer
    Public IdCotizacion As Integer = 0
    Private dtRubro As DataTable
    Private dtSubRubro As DataTable
    Public DesRubro As String

    Private dtDatos As DataTable

    Private Sub frmServicios_Cotizacion_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionServicioService.Close()
            oCotizacionServicioDetService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()
            oCotizacionServicioDetService.Abort()            
        Catch ex As CommunicationException
            oCotizacionServicioService.Abort()
            oCotizacionServicioDetService.Abort()
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If state_button = True Then
                If ValidaBalanceMontos() Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Finalizar()
                    Me.Close()
                End If
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Finalizar()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        LlenarSubRubro()

        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            gbDetalles.Visible = True
            actualizar()
            Me.Text = "Rubro: " + DesRubro
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(516, 242)
            gbDetalles.Visible = False
            Me.Text = "Nuevo Rubro"
            activar()
        End If
        enableOpciones()
        txtObservacion.Focus()
    End Sub

    Private Sub activar()
        If state_button = False Then            'Nuevo
            cmbRubro.ReadOnly = False
            cmbRubro.BackColor = System.Drawing.SystemColors.Window
            cmbSubRubro.ReadOnly = False
            cmbSubRubro.BackColor = System.Drawing.SystemColors.Window
            txtItem.ReadOnly = False
            txtItem.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            txtDescuento.ReadOnly = False
            txtDescuento.BackColor = System.Drawing.SystemColors.Window

            If cmbRubro.Value = 1 Then
                btnAdjuntar.Enabled = True
            Else
                btnAdjuntar.Enabled = False
            End If
            btnDesvincular.Enabled = False

        Else                  'Actualizar
            If estado = 1 Then
                cmbRubro.ReadOnly = True
                cmbRubro.BackColor = System.Drawing.SystemColors.Control
                cmbSubRubro.ReadOnly = True
                cmbSubRubro.BackColor = System.Drawing.SystemColors.Control
                txtItem.ReadOnly = False
                txtItem.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                If cmbRubro.Value = 1 Then                  
                    btnAdjuntar.Enabled = True
                    If oCotizacionServicioService.BuscarRepuestos(IdCotizacionSer) = True Then
                        txtMonto.ReadOnly = True
                        txtMonto.BackColor = System.Drawing.SystemColors.Control
                        txtDescuento.ReadOnly = True
                        txtDescuento.BackColor = System.Drawing.SystemColors.Control

                        btnDesvincular.Enabled = True
                    Else
                        txtMonto.ReadOnly = False
                        txtMonto.BackColor = System.Drawing.SystemColors.Window
                        txtDescuento.ReadOnly = False
                        txtDescuento.BackColor = System.Drawing.SystemColors.Window

                        btnDesvincular.Enabled = False
                    End If
                Else
                    txtMonto.ReadOnly = False
                    txtMonto.BackColor = System.Drawing.SystemColors.Window
                    txtDescuento.ReadOnly = False
                    txtDescuento.BackColor = System.Drawing.SystemColors.Window

                    btnAdjuntar.Enabled = False
                    btnDesvincular.Enabled = False
                End If
            End If
        End If
        edicion = True
        enableOpciones()
    End Sub

    Private Sub EnableOptions()
        Try
            If state_button = True Then     '--------------- Actualizar
                If edicion Then
                    If cmbRubro.Value = 1 And oCotizacionServicioService.BuscarRepuestos(IdCotizacionSer) = True Then
                        txtMonto.ReadOnly = True
                        txtMonto.BackColor = System.Drawing.SystemColors.Control
                        txtDescuento.ReadOnly = True
                        txtDescuento.BackColor = System.Drawing.SystemColors.Control
                        btnAdjuntar.Enabled = True
                        btnDesvincular.Enabled = True
                    Else
                        txtMonto.ReadOnly = False
                        txtMonto.BackColor = System.Drawing.SystemColors.Window
                        txtDescuento.ReadOnly = False
                        txtDescuento.BackColor = System.Drawing.SystemColors.Window
                        btnAdjuntar.Enabled = IIf(cmbRubro.Value = 1, True, False)
                        btnDesvincular.Enabled = False
                    End If
                End If
            Else                                       '----------------- Nuevo
                txtMonto.ReadOnly = False
                txtMonto.BackColor = System.Drawing.SystemColors.Window
                txtDescuento.ReadOnly = False
                txtDescuento.BackColor = System.Drawing.SystemColors.Window
                If cmbRubro.Value = 1 Then
                    btnAdjuntar.Enabled = True
                Else
                    btnAdjuntar.Enabled = False
                End If
                btnDesvincular.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        cmbSubRubro.ReadOnly = True
        cmbSubRubro.BackColor = System.Drawing.SystemColors.Control
        txtItem.ReadOnly = True
        txtItem.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control
        txtDescuento.ReadOnly = True
        txtDescuento.BackColor = System.Drawing.SystemColors.Control

        btnAdjuntar.Enabled = False
        btnDesvincular.Enabled = False
        edicion = False
        enableOpciones()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cmbRubro.KeyPress _
                      , cmbSubRubro.KeyPress _
                      , txtItem.KeyPress _
                      , txtMonto.KeyPress _
                      , txtDescuento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= RUBRO ==============================================
            dtRubro = oCotizacionServicioDetService.MostrarRubros.Tables(0)
            'DataGridView1.DataSource = dtRubro
            'dtDestino.Rows.InsertAt(getRowTodos(dtDestino), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubro = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionServicioDetService.CotizacionServicioDet
            registro = oCotizacionServicioDetService.Obtener(IdCotizacionDet)

            'If registro.SubRubroServicios.RubroServicios.IdRubro Is Nothing Or registro.SubRubroServicios.RubroServicios.IdRubro = 0 Then
            If registro.SubRubroServicios.RubroServicios.IdRubro = 0 Then
                cmbRubro.SelectedIndex = 0
            Else
                cmbRubro.Value = registro.SubRubroServicios.RubroServicios.IdRubro
            End If
            LlenarSubRubro()
            'cmbRubro.Value = registro.SubRubroServicios.RubroServicios.IdRubro
            cmbSubRubro.Value = registro.SubRubroServicios.IdSubRubro
            txtItem.Value = registro.Item
            txtObservacion.Text = registro.Observacion
            txtMonto.Value = registro.Monto
            txtDescuento.Value = registro.MontoDscto

            'If IdRubro = 1 Then
            '    'If oCotizacionServcioService.BuscarRepuestos(IdCotizacionSer) = True Then
            '    txtMonto.ReadOnly = True
            '    txtMonto.BackColor = System.Drawing.SystemColors.Control
            '    txtDescuento.ReadOnly = True
            '    txtDescuento.BackColor = System.Drawing.SystemColors.Control
            '    btnAdjuntar.Enabled = False
            'Else
            '    txtMonto.ReadOnly = False
            '    txtMonto.BackColor = System.Drawing.SystemColors.Window
            '    txtDescuento.ReadOnly = False
            '    txtDescuento.BackColor = System.Drawing.SystemColors.Window
            '    btnAdjuntar.Enabled = True
            '    'End If
            'End If
            '---------------------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LlenarSubRubro()
        Try
            '======================================= SUBRUBRO VIAJE =============================================
            If cmbRubro.SelectedIndex <> 0 Then
                dtSubRubro = oCotizacionServicioDetService.MostrarSubRubros(cmbRubro.Value).Tables(0)
                'dtSubRubro.Rows.InsertAt(getRowTodos(dtSubRubroViaje), 0)
                cmbSubRubro.DataSource = dtSubRubro
                cmbSubRubro.DropDownList.DataMember = dtSubRubro.Columns("DesSubRubro").ToString
                cmbSubRubro.DropDownList.DisplayMember = dtSubRubro.Columns("DesSubRubro").ToString
                cmbSubRubro.DropDownList.ValueMember = dtSubRubro.Columns("IdSubRubro").ToString
                cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubro.Columns("IdSubRubro").ToString
                cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubro.Columns("DesSubRubro").ToString
                'cmbSubRubro.DropDownList.Columns(2).DataMember = dtSubRubro.Columns("Observacion").ToString
                'cmbSubRubroViaje.SelectedIndex = 0
                dtSubRubro = Nothing
                'Else
                '    dtSubRubro = oCotizacionServicioDetService.MostrarSubRubros(cmbRubro.Value).Tables(0)
                '    dtSubRubro.Rows.InsertAt(getRowTodos(dtSubRubro), 0)
                '    cmbSubRubro.DataSource = dtSubRubro
                '    cmbSubRubro.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO SUBRUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
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

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If ValidaSubRubro() Then
            If IdCotizacion <> 0 Then
                If MsgBox("¿Está seguro de ADJUNTAR la cotización Nº " & NumCotizacion2 & " a la cotización de servicios Nº " & NumCotizacion, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim registro As New CotizacionServicioDetService.CotizacionServicioDet
                    Dim CotizacionServicio As New CotizacionServicioDetService.CotizacionServicio
                    Dim SubRubroServicios As New CotizacionServicioDetService.SubRubroServicios
                 
                    CotizacionServicio.IdCotizacionSer = IdCotizacionSer
                    registro.CotizacionServicio = CotizacionServicio
                    registro.IdCotizacionSerDet = IdCotizacionDet
                    SubRubroServicios.IdSubRubro = cmbSubRubro.Value
                    registro.SubRubroServicios = SubRubroServicios
                   
                    registro.Item = txtItem.Value
                    registro.Monto = txtMonto.Value
                    registro.MontoDscto = txtDescuento.Value
                    registro.Observacion = txtObservacion.Text

                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc

                    If state_button Then        'Modificar
                        Modificar(registro)
                    Else                        'Nuevo
                        Insertar(registro)
                    End If
                End If
            Else
                If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                    And ValidaCampos() Then
                    Dim registro As New CotizacionServicioDetService.CotizacionServicioDet
                    Dim CotizacionServicio As New CotizacionServicioDetService.CotizacionServicio
                    Dim SubRubroServicios As New CotizacionServicioDetService.SubRubroServicios
                    'Dim Job As New SolicitudGastoDetService.Job
                    'Dim Moneda As New SolicitudGastoDetService.Moneda
                    'Dim Proveedor As New SolicitudGastoDetService.Proveedor

                    CotizacionServicio.IdCotizacionSer = IdCotizacionSer
                    registro.CotizacionServicio = CotizacionServicio
                    registro.IdCotizacionSerDet = IdCotizacionDet
                    SubRubroServicios.IdSubRubro = cmbSubRubro.Value
                    registro.SubRubroServicios = SubRubroServicios
                    registro.Item = txtItem.Value
                    registro.Monto = txtMonto.Value
                    registro.MontoDscto = txtDescuento.Value
                    registro.Observacion = txtObservacion.Text

                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc

                    If state_button Then        'Modificar
                        Modificar(registro)
                    Else                        'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Insertar(ByVal registro As CotizacionServicioDetService.CotizacionServicioDet)
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionServicioDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                If IdCotizacion <> 0 Then
                    AdjuntarCotizacion()
                    IdCotizacionDet = estado_process
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    IdCotizacionDet = estado_process
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CotizacionServicioDetService.CotizacionServicioDet)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionServicioDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                If IdCotizacion <> 0 Then
                    AdjuntarCotizacion()
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If ValidaBalanceMontos() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub AdjuntarCotizacion()
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionServicioService.AdjuntarRepuestos(IdCotizacionSer, IdCotizacion, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
            If estado_process Then
                MsgBox("Se Adjuntó la Cotización correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaSubRubro() As Boolean
        Try
            'Dim estado As Boolean
            If state_button = False Then
                If oCotizacionServicioDetService.BuscarSubRubro(IdCotizacionSer, utils.toNumber(cmbSubRubro.Value)) = True Then
                    MsgBox("¡Este SubRubro ya ha sido ingresado, tenga cuidado!", MsgBoxStyle.Information, "Información")
                    cmbSubRubro.Focus()
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR EL SUBRUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCampos() As Boolean
        Try
            If txtMonto.Value = 0 Then
                MsgBox("Debe Ingresar el Monto. ", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaBalanceMontos() As Boolean
        Try
            If (txtMonto.Value - txtDescuento.Value) <> oCotizacionServicioDetService.ObtenerTotalCosto(IdCotizacionDet, IdCotizacionSer) Then
                MsgBox("El monto del Detalle debe coincidir con el total de los detalles de costos.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR BALANCE DE MONTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Finalizar()
        Try
            oCotizacionServicioDetService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioDetService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oCotizacionServicioDetService.Abort()
            oCotizacionServicioService.Abort()
        End Try
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        Try
            dtSubRubro = oCotizacionServicioDetService.MostrarSubRubros(utils.toNumber(cmbRubro.Value)).Tables(0)
            'DataGridView2.DataSource = dtSubRubro
            ''dtPlaca.Rows.InsertAt(getRowTodos(dtPlaca), 0)
            cmbSubRubro.DataSource = dtSubRubro
            cmbSubRubro.DropDownList.DataMember = dtSubRubro.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.DisplayMember = dtSubRubro.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.ValueMember = dtSubRubro.Columns("IdSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubro.Columns("IdSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubro.Columns("DesSubRubro").ToString
            cmbSubRubro.SelectedIndex = 0
            dtSubRubro = Nothing

            EnableOptions()
        Catch ex As Exception
            MsgBox("Error al llenar el SubRubro", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub btnAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntar.Click
        Try
            'If ValidaCodigoSeleccionado() Then
            Dim frm As New frmServicios_Cotizacion_Adjuntar
            frm.IdCotizacionSer = IdCotizacionSer
            frm.IdCliente = IdCliente
            'frm.NumCotizacion = NumCotizacion
            frm.Text = "Adjuntar Cotización" '----- Al Cliente : " & dgvDatos.CurrentRow.Cells("DesCli").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'If IdCotizacion <> 0 Then
                IdCotizacion = frm.IdCotizacion
                NumCotizacion2 = frm.NumCotizacion2
                txtMonto.Value = frm.MontoTotal
                txtDescuento.Value = frm.MontoDscto
                VerificarAdjuntaCot()
                'End If
            Else
                IdCotizacion = 0
                VerificarAdjuntaCot()
            End If
            'VerificarAdjuntaCot()
        Catch ex As Exception
            MsgBox("Error al ADJUNTAR Cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerificarAdjuntaCot()
        If oCotizacionServicioService.BuscarRepuestos(IdCotizacionSer) = True Then
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtDescuento.ReadOnly = True
            txtDescuento.BackColor = System.Drawing.SystemColors.Control
        Else
            If IdCotizacion <> 0 Then
                txtMonto.ReadOnly = True
                txtMonto.BackColor = System.Drawing.SystemColors.Control
                txtDescuento.ReadOnly = True
                txtDescuento.BackColor = System.Drawing.SystemColors.Control
                'txtMonto.Value = 0.0
                'txtDescuento.Value = 0.0
            Else
                txtMonto.ReadOnly = False
                txtMonto.BackColor = System.Drawing.SystemColors.Window
                txtDescuento.ReadOnly = False
                txtDescuento.BackColor = System.Drawing.SystemColors.Window
                txtMonto.Value = 0.0
                txtDescuento.Value = 0.0
            End If
        End If
    End Sub

    Private Sub btnDesvincular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesvincular.Click
        Try
            Dim frm As New frmServicios_Cotizacion_Desvincular
            frm.IdCotizacionSer = IdCotizacionSer
            frm.NumCotizacion = NumCotizacion
            frm.Text = "Desvincular Cotización de Repuestos"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("La cotización fue desvinculada correctamente.", MsgBoxStyle.Information)                 
                ObtenerRegistro()
                desactivar()
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCotizacionSerDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionServicioDetService.MostrarCosto(IdCotizacionDet, IdCotizacionSer).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()             
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String, ByVal codigoDet As String, ByVal codigoRub As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCotizacionSer").Value) = codigo And CInt(row.Cells("IdCotizacionSerDet").Value) = codigoDet And CInt(row.Cells("IdRubro").Value) = codigoRub Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCotizacionServicioDetService.BorrarCosto(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value), toNumber(dgvDatos.CurrentRow.Cells("IdRubro").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        NuevoDetalle()
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmServicios_Cotizacion_Costo
                frm.state_button = False
                frm.IdCotizacionSer = IdCotizacionSer
                frm.IdCotizacionSerDet = IdCotizacionDet
                frm.codMon = codMon
                frm.idCliente = IdCliente
                frm.estado = estado
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdCotizacionSer, frm.IdCotizacionSerDet, frm.IdRubro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()            
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmServicios_Cotizacion_Costo
            frm.state_button = True
            frm.IdCotizacionSer = dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value
            frm.IdCotizacionSerDet = dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Value
            frm.IdRubro = dgvDatos.CurrentRow.Cells("IdRubro").Value
            frm.codMon = codMon
            frm.idCliente = IdCliente
            frm.estado = estado
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCotizacionSer, frm.IdCotizacionSerDet, frm.IdRubro)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdCotizacionSer, frm.IdCotizacionSerDet, frm.IdRubro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
End Class