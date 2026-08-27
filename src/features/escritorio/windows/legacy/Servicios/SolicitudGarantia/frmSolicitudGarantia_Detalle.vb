Imports System.ServiceModel
Public Class frmSolicitudGarantia_Detalle

    '============================Servicios===================================
    Private oSolicitudGarantiaAtencionService As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencionServiceClient
    Private SolicitudGarantiaHorasService As New SolicitudGarantiaHorasService.SolicitudGarantiaHorasServiceClient
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient
    Private oSolicitudGarantiaHorasService As New SolicitudGarantiaHorasService.SolicitudGarantiaHorasServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public editable As Boolean = False
    Private dtDatos As DataTable
    Private dtDatosMO As DataTable
    Private dtMonedas As DataTable
    Private dtDocumento As New DataTable
    Public estado As Integer
    Public IdAfaDet As Integer
    Public IdAfa As Integer
    Public rechazado As Boolean
    Public Atendido As Boolean

    Private Sub frmSolicitud_Garantia_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtNumClaim.KeyPress _
                        , txtFecha.KeyPress _
                        , cmbMoneda.KeyPress _
                        , txtHorasManoObraRec.KeyPress _
                        , txtTotManoObraRec.KeyPress _
                        , txtHorasViajeRec.KeyPress _
                        , txtTotViajeRec.KeyPress _
                        , txtMillasDistanciaRec.KeyPress _
                        , txtTotDistanciaRec.KeyPress _
                        , txtTotRepuestosRec.KeyPress _
                        , txtTotOtrosRec.KeyPress _
                        , txtTotNetItem.KeyPress _
                        , txtHorasManoObraAtendido.KeyPress _
                        , txtTotManoObraAtendido.KeyPress _
                        , txtHorasViajeAtendido.KeyPress _
                        , txtTotViajeAtendido.KeyPress _
                        , txtMillasDistanciaAtendido.KeyPress _
                        , txtTotDistanciaAtendido.KeyPress _
                        , txtTotRepuestosAtendido.KeyPress _
                        , txtTotRepuestosCli.KeyPress _
                        , txtTotOtros.KeyPress _
                        , txtTotNetItem.KeyPress _
                        , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmSolicitud_Garantia_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.CancelButton = Me.biSalir
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        estilo.cargaEstiloGridExt(dgvManoObra)
        dgvManoObra.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        If state_button Then                'Modificar
            Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencion
            registro = oSolicitudGarantiaAtencionService.Obtener(IdAfaDet)
            rechazado = registro.Rechazado
            Atendido = registro.Atendido
            ObtenerRegistro()
            desactivar()
            actualizarDetalles()
            Me.Text = "ATENCIÓN DE FORMATO DE ORDEN DE REPARACIÓN Nº " + Chr(34) + registro.NumClaim + Chr(34)
            gbRepuestos.Visible = True
            If estado = 1 Or estado = 2 Or estado = 3 Then
                dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
            Else
                dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
            End If
        Else                                      'Nuevo
            cmbMoneda.Value = "US"
            txtFecha.Value = Today
            activar()
            gbRepuestos.Visible = False
            Me.Text = "Nueva Atención de Formato de ORDEN DE REPARACIÓN"
            Me.Size = New System.Drawing.Size(655, 523)
        End If
        EnableOptions()
    End Sub

    Private Sub frmSolicitud_Garantia_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oFacturaService.Close()
            oSolicitudGarantiaAtencionService.Close()
            oSolicitudGarantiaService.Close()
            oSolicitudGarantiaHorasService.Close()
            oSeguridadService.Close()

        Catch ex As TimeoutException
            oFacturaService.Abort()
            oSolicitudGarantiaAtencionService.Abort()
            oSolicitudGarantiaService.Abort()
            oSolicitudGarantiaHorasService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oSolicitudGarantiaAtencionService.Abort()
            oSolicitudGarantiaService.Abort()
            oSolicitudGarantiaHorasService.Abort()
            oSeguridadService.Abort()
        End Try
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
            fila(2) = False
        End Try
        Try
            fila(2) = False
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toBlank(txtNumClaim.Text) = "" Then
                MsgBox("Debe Ingresar el Num Claim", MsgBoxStyle.Information, "Información")
                txtNumClaim.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        biGuardar.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable And rechazado = False And Atendido = False, True, False)
        biRechazar.Enabled = IIf((estado <> 1 And estado <> 2) And editable And rechazado = False And Atendido = False, True, False)
        biAtender.Enabled = IIf((estado <> 1 And estado <> 2) And editable And rechazado = False And Atendido = False, True, False)
        If editable = False And estado = 4 Or estado = 5 Or (rechazado = True Or Atendido = True) Then
            desactivar()
        End If
    End Sub

    Private Sub activar()
        If state_button Then
            txtNumClaim.ReadOnly = True
            txtNumClaim.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            'txtCreditState.ReadOnly = False
            'txtCreditState.BackColor = System.Drawing.SystemColors.Window
            txtHorasManoObraAtendido.ReadOnly = False
            txtHorasManoObraAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotManoObraAtendido.ReadOnly = False
            txtTotManoObraAtendido.BackColor = System.Drawing.SystemColors.Window
            txtHorasViajeAtendido.ReadOnly = False
            txtHorasViajeAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotViajeAtendido.ReadOnly = False
            txtTotViajeAtendido.BackColor = System.Drawing.SystemColors.Window
            txtMillasDistanciaAtendido.ReadOnly = False
            txtMillasDistanciaAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotDistanciaAtendido.ReadOnly = False
            txtTotDistanciaAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotRepuestosAtendido.ReadOnly = False
            txtTotRepuestosAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotRepuestosCli.ReadOnly = False
            txtTotRepuestosCli.BackColor = System.Drawing.SystemColors.Window
            txtTotOtros.ReadOnly = False
            txtTotOtros.BackColor = System.Drawing.SystemColors.Window
            txtTotNetItem.ReadOnly = False 'Añadido el día 28/08/2012
            txtTotNetItem.BackColor = System.Drawing.SystemColors.Window 'Añadido el día 28/08/2012

            '---------------------------Montos Reclamados (modificado el 30/03/2012 Sr Pacolo)------------
            txtHorasManoObraRec.ReadOnly = False
            txtHorasManoObraRec.BackColor = System.Drawing.SystemColors.Window
            txtTotDistanciaRec.ReadOnly = False
            txtTotManoObraRec.BackColor = System.Drawing.SystemColors.Window
            txtHorasViajeRec.ReadOnly = False
            txtHorasViajeRec.BackColor = System.Drawing.SystemColors.Window
            txtTotViajeRec.ReadOnly = False
            txtTotViajeRec.BackColor = System.Drawing.SystemColors.Window
            txtMillasDistanciaRec.ReadOnly = False
            txtMillasDistanciaRec.BackColor = System.Drawing.SystemColors.Window
            txtTotDistanciaRec.ReadOnly = False
            txtTotDistanciaRec.BackColor = System.Drawing.SystemColors.Window
            txtTotRepuestosRec.ReadOnly = False
            txtTotRepuestosRec.BackColor = System.Drawing.SystemColors.Window
            txtTotOtrosRec.ReadOnly = False
            txtTotOtrosRec.BackColor = System.Drawing.SystemColors.Window
            txtTotNetItemRec.ReadOnly = False 'Añadido el día 28/08/2012
            txtTotNetItemRec.BackColor = System.Drawing.SystemColors.Window 'Añadido el día 28/08/2012
            '----------------------------------------------------------------------------------------------------------------------------

            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Else
            txtNumClaim.ReadOnly = False
            txtNumClaim.BackColor = System.Drawing.SystemColors.Window
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            'txtCreditState.ReadOnly = False
            'txtCreditState.BackColor = System.Drawing.SystemColors.Window
            txtHorasManoObraAtendido.ReadOnly = False
            txtHorasManoObraAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotManoObraAtendido.ReadOnly = False
            txtTotManoObraAtendido.BackColor = System.Drawing.SystemColors.Window
            txtHorasViajeAtendido.ReadOnly = False
            txtHorasViajeAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotViajeAtendido.ReadOnly = False
            txtTotViajeAtendido.BackColor = System.Drawing.SystemColors.Window
            txtMillasDistanciaAtendido.ReadOnly = False
            txtMillasDistanciaAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotDistanciaAtendido.ReadOnly = False
            txtTotDistanciaAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotRepuestosAtendido.ReadOnly = False
            txtTotRepuestosAtendido.BackColor = System.Drawing.SystemColors.Window
            txtTotRepuestosCli.ReadOnly = False
            txtTotRepuestosCli.BackColor = System.Drawing.SystemColors.Window
            txtTotOtros.ReadOnly = False
            txtTotOtros.BackColor = System.Drawing.SystemColors.Window
            txtTotNetItem.ReadOnly = False 'Añadido el día 28/08/2012
            txtTotNetItem.BackColor = System.Drawing.SystemColors.Window 'Añadido el día 28/08/2012

            '---------------------------Montos Reclamados (modificado el 30/03/2012 Sr Pacolo)------------
            txtHorasManoObraRec.ReadOnly = False
            txtHorasManoObraRec.BackColor = System.Drawing.SystemColors.Window
            txtTotDistanciaRec.ReadOnly = False
            txtTotManoObraRec.BackColor = System.Drawing.SystemColors.Window
            txtHorasViajeRec.ReadOnly = False
            txtHorasViajeRec.BackColor = System.Drawing.SystemColors.Window
            txtTotViajeRec.ReadOnly = False
            txtTotViajeRec.BackColor = System.Drawing.SystemColors.Window
            txtMillasDistanciaRec.ReadOnly = False
            txtMillasDistanciaRec.BackColor = System.Drawing.SystemColors.Window
            txtTotDistanciaRec.ReadOnly = False
            txtTotDistanciaRec.BackColor = System.Drawing.SystemColors.Window
            txtTotRepuestosRec.ReadOnly = False
            txtTotRepuestosRec.BackColor = System.Drawing.SystemColors.Window
            txtTotOtrosRec.ReadOnly = False
            txtTotOtrosRec.BackColor = System.Drawing.SystemColors.Window
            txtTotNetItemRec.ReadOnly = False 'Añadido el día 28/08/2012
            txtTotNetItemRec.BackColor = System.Drawing.SystemColors.Window 'Añadido el día 28/08/2012
            '----------------------------------------------------------------------------------------------------------------------------

            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        If (estado = 1 Or estado = 2 Or estado = 3) And editable = True And cbRechazado.Checked = False And cbAtendido.Checked = False Then
            activar()
        Else
            txtNumClaim.ReadOnly = True
            txtNumClaim.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            'txtCreditState.ReadOnly = True
            'txtCreditState.BackColor = System.Drawing.SystemColors.Control
            txtHorasManoObraAtendido.ReadOnly = True
            txtHorasManoObraAtendido.BackColor = System.Drawing.SystemColors.Control
            txtTotManoObraAtendido.ReadOnly = True
            txtTotManoObraAtendido.BackColor = System.Drawing.SystemColors.Control
            txtHorasViajeAtendido.ReadOnly = True
            txtHorasViajeAtendido.BackColor = System.Drawing.SystemColors.Control
            txtTotViajeAtendido.ReadOnly = True
            txtTotViajeAtendido.BackColor = System.Drawing.SystemColors.Control
            txtMillasDistanciaAtendido.ReadOnly = True
            txtMillasDistanciaAtendido.BackColor = System.Drawing.SystemColors.Control
            txtTotDistanciaAtendido.ReadOnly = True
            txtTotDistanciaAtendido.BackColor = System.Drawing.SystemColors.Control
            txtTotRepuestosAtendido.ReadOnly = True
            txtTotRepuestosAtendido.BackColor = System.Drawing.SystemColors.Control
            txtTotRepuestosCli.ReadOnly = True
            txtTotRepuestosCli.BackColor = System.Drawing.SystemColors.Control
            txtTotOtros.ReadOnly = True
            txtTotOtros.BackColor = System.Drawing.SystemColors.Control
            txtTotNetItem.ReadOnly = True 'Añadido el día 28/08/2012
            txtTotNetItem.BackColor = System.Drawing.SystemColors.Control 'Añadido el día 28/08/2012

            '---------------------------Montos Reclamados (modificado el 30/03/2012 Sr Pacolo)------------
            txtHorasManoObraRec.ReadOnly = True
            txtHorasManoObraRec.BackColor = System.Drawing.SystemColors.Control
            txtTotDistanciaRec.ReadOnly = True
            txtTotManoObraRec.BackColor = System.Drawing.SystemColors.Control
            txtHorasViajeRec.ReadOnly = True
            txtHorasViajeRec.BackColor = System.Drawing.SystemColors.Control
            txtTotViajeRec.ReadOnly = True
            txtTotViajeRec.BackColor = System.Drawing.SystemColors.Control
            txtMillasDistanciaRec.ReadOnly = True
            txtMillasDistanciaRec.BackColor = System.Drawing.SystemColors.Control
            txtTotDistanciaRec.ReadOnly = True
            txtTotDistanciaRec.BackColor = System.Drawing.SystemColors.Control
            txtTotRepuestosRec.ReadOnly = True
            txtTotRepuestosRec.BackColor = System.Drawing.SystemColors.Control
            txtTotOtrosRec.ReadOnly = True
            txtTotOtrosRec.BackColor = System.Drawing.SystemColors.Control
            txtTotNetItemRec.ReadOnly = True 'Añadido el día 28/08/2012
            txtTotNetItemRec.BackColor = System.Drawing.SystemColors.Control 'Añadido el día 28/08/2012
            '----------------------------------------------------------------------------------------------------------------------------

            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= TIPO DE DOCUMENTO ================================================
            dtDocumento = oFacturaService.MostrarSerieFacturaBoleta().Tables(0)
            dtDocumento.Rows.InsertAt(getRowTodos(dtDocumento), 0)
            cmbDocumento.DataSource = dtDocumento
            cmbDocumento.DropDownList.DataMember = dtDocumento.Columns("Descripcion").ToString
            cmbDocumento.DropDownList.DisplayMember = dtDocumento.Columns("Descripcion").ToString
            cmbDocumento.DropDownList.ValueMember = dtDocumento.Columns("IdSerieDoc").ToString
            cmbDocumento.DropDownList.Columns(0).DataMember = dtDocumento.Columns("IdSerieDoc").ToString
            cmbDocumento.DropDownList.Columns(1).DataMember = dtDocumento.Columns("Descripcion").ToString
            cmbDocumento.SelectedIndex = 0
            dtDocumento = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudGarantiaAtencionService.SolicitudGarantiaAtencion)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudGarantiaAtencionService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdAfaDet = estado_process
                MsgBox("Se ingreso la Atención correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGarantiaAtencionService.SolicitudGarantiaAtencion)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGarantiaAtencionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Atención correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGarantiaAtencionService.SolicitudGarantiaAtencion
            registro = oSolicitudGarantiaAtencionService.Obtener(IdAfaDet)

            IdAfaDet = registro.IdAfaDet
            IdAfa = registro.SolicitudGarantia.IdAfa
            txtNumClaim.Text = registro.NumClaim
            txtFecha.Value = registro.FecClaim
            cmbMoneda.Value = registro.Moneda.CodMon
            txtCreditState.Text = registro.CreditState

            If Not (registro.FecCreditState.ToString = "") Then
                txtFechaCredit.Value = CDate(registro.FecCreditState)
                txtFechaCredit.Text = registro.FecCreditState.ToString
            End If

            txtTotRepuestosAtendido.Value = registro.TotRepuestos
            txtHorasManoObraAtendido.Value = registro.HorasManoObra
            txtTotManoObraAtendido.Value = registro.TotManoObra
            txtHorasViajeAtendido.Value = registro.HorasViaje
            txtTotViajeAtendido.Value = registro.TotViaje
            txtMillasDistanciaAtendido.Value = registro.MillasDistancia
            txtTotDistanciaAtendido.Value = registro.TotDistancia
            txtTotRepuestosCli.Value = registro.TotRepuestosCli
            txtTotOtros.Value = registro.TotOtros
            txtTotNetItem.Value = registro.TotNetItem 'Añadido el día 28/08/2012

            '---------------------------Montos Reclamados (modificado el 30/03/2012 Sr Pacolo)------------
            txtTotRepuestosRec.Value = registro.TotRepuestosRec
            txtHorasManoObraRec.Value = registro.HorasManoObraRec
            txtTotManoObraRec.Value = registro.TotManoObraRec
            txtHorasViajeRec.Value = registro.HorasViajeRec
            txtTotViajeRec.Value = registro.TotViajeRec
            txtMillasDistanciaRec.Value = registro.MillasDistanciaRec
            txtTotDistanciaRec.Value = registro.TotDistanciaRec
            txtTotOtrosRec.Value = registro.TotOtrosRec
            txtTotNetItemRec.Value = registro.TotNetItemRec  'Añadido el día 28/08/2012
            '----------------------------------------------------------------------------------------------------------------------------

            txtNumDocumento.Text = registro.NumDoc
            If registro.SerieDocumento.CodSerie <> Nothing Or registro.SerieDocumento.CodSerie = "" Then
                cmbDocumento.Value = registro.SerieDocumento.CodSerie
            Else
                cmbDocumento.SelectedIndex = 0
            End If
            cbCobrado.Checked = registro.Cobrado
            txtObservacion.Text = registro.Observacion
            cbRechazado.Checked = registro.Rechazado
            cbAtendido.Checked = registro.Atendido
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencion
            Dim Solicitud As New SolicitudGarantiaAtencionService.SolicitudGarantia
            Dim Moneda As New SolicitudGarantiaAtencionService.Moneda
            Dim Serie As New SolicitudGarantiaAtencionService.SerieDocumento

            registro.IdAfaDet = IdAfaDet
            Solicitud.IdAfa = IdAfa
            registro.SolicitudGarantia = Solicitud
            registro.NumClaim = txtNumClaim.Text
            registro.FecClaim = txtFecha.Value
            Moneda.CodMon = cmbMoneda.Value
            registro.Moneda = Moneda
            'registro.CreditState = toNull(txtCreditState.Text)
            'registro.FecCreditState = IIf(txtFechaCredit.Text = "", Nothing, txtFechaCredit.Value)
            registro.TotRepuestos = txtTotRepuestosAtendido.Value
            registro.HorasManoObra = txtHorasManoObraAtendido.Value
            registro.TotManoObra = txtTotManoObraAtendido.Value
            registro.HorasViaje = txtHorasViajeAtendido.Value
            registro.TotViaje = txtTotViajeAtendido.Value
            registro.MillasDistancia = txtMillasDistanciaAtendido.Value
            registro.TotDistancia = txtTotDistanciaAtendido.Value
            registro.TotRepuestosCli = txtTotRepuestosCli.Value
            registro.TotOtros = txtTotOtros.Value
            registro.TotNetItem = txtTotNetItem.Value  'Añadido el día 28/08/2012

            '---------------------------Montos Reclamados (modificado el 30/03/2012 Sr Pacolo)------------
            registro.TotRepuestosRec = txtTotRepuestosRec.Value
            registro.HorasManoObraRec = txtHorasManoObraRec.Value
            registro.TotManoObraRec = txtTotManoObraRec.Value
            registro.HorasViajeRec = txtHorasViajeRec.Value
            registro.TotViajeRec = txtTotViajeRec.Value
            registro.MillasDistanciaRec = txtMillasDistanciaRec.Value
            registro.TotDistanciaRec = txtTotDistanciaRec.Value
            registro.TotOtrosRec = txtTotOtrosRec.Value
            registro.TotNetItemRec = txtTotNetItemRec.Value  'Añadido el día 28/08/2012
            '----------------------------------------------------------------------------------------------------------------------------

            registro.NumDoc = txtNumDocumento.Text
            Serie.CodSerie = cmbDocumento.Value
            registro.SerieDocumento = Serie
            registro.Cobrado = cbCobrado.Checked
            registro.Observacion = txtObservacion.Text

            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                registro.FecReg = Today
                Insertar(registro)
            End If
        End If
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
            listaDatosMO()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizar()
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
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudGarantiaAtencionService.MostrarRepuestos(IdAfa).Tables(0)
            dgvDatos.DataSource = dtDatos
            If state_button Then
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            End If
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            If Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "24" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17" Then
                dgvDatos.RootTable.Columns(8).EditType = Janus.Windows.GridEX.EditType.TextBox
                dgvDatos.RootTable.Columns(9).EditType = Janus.Windows.GridEX.EditType.TextBox
                dgvDatos.RootTable.Columns(10).EditType = Janus.Windows.GridEX.EditType.TextBox
            Else
                dgvDatos.RootTable.Columns(8).EditType = Janus.Windows.GridEX.EditType.NoEdit
                dgvDatos.RootTable.Columns(9).EditType = Janus.Windows.GridEX.EditType.NoEdit
                dgvDatos.RootTable.Columns(10).EditType = Janus.Windows.GridEX.EditType.NoEdit
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosMO()
        Try
            dtDatosMO = SolicitudGarantiaHorasService.Mostrar(IdAfa).Tables(0)
            dgvManoObra.DataSource = dtDatosMO
            'If state_button Then
            '    sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            'End If

            enableOpcionesMO()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpcionesMO()

        'Agregado para la grilla de Mano de Obra

        If dgvManoObra.RowCount < 1 Then
            miMostrarMO.Enabled = False
            miEliminarMO.Enabled = False
        Else
            miMostrarMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
            miEliminarMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        End If
        miNuevoMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        miImprimir.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        cmOpcionesMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable And rechazado = False And Atendido = False, True, False)

        'miMostrarMO.Enabled = True
        'miEliminarMO.Enabled = True
        'miNuevoMO.Enabled = True
        'miImprimir.Enabled = True
        'cmOpcionesMO.Enabled = True

    End Sub

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

    Private Sub RowPossesionMO(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdHoraExtra").Value) = codigo Then
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
        If dgvDatos.RowCount < 1 Then
            miEliminarGuia.Enabled = False
            miCantAtendidaOk.Enabled = False
            miPrecFabricaOk.Enabled = False
        Else
            miEliminarGuia.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
            miCantAtendidaOk.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
            miPrecFabricaOk.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        End If
        miNuevo.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        cmOpciones.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable And rechazado = False And Atendido = False, True, False)

        ' Agregado para la grilla de Mano de Obra

        'If dgvManoObra.RowCount < 1 Then
        '    miMostrarMO.Enabled = False
        '    miEliminarMO.Enabled = False
        'Else
        '    miMostrarMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        '    miEliminarMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3) And editable, True, False)
        'End If

        'miMostrarMO.Enabled = True
        'miEliminarMO.Enabled = True
        'miNuevoMO.Enabled = True
        'cmOpcionesMO.Enabled = True 'IIf((estado = 1 Or estado = 2 Or estado = 3) And editable And rechazado = False And Atendido = False, True, False)

    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Try
            Dim frm As New frmBuscarGuias
            Dim registro As New SolicitudGarantiaService.SolicitudGarantia
            registro = oSolicitudGarantiaService.Obtener(IdAfa)
            frm.CodJob = registro.Job.CodJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'If oSolicitudGarantiaAtencionService.BuscarGuia(IdAfa, IdAfaDet, frm.IdGuia) Then
                If oSolicitudGarantiaAtencionService.BuscarGuia(IdAfa, frm.IdGuia) Then
                    MsgBox("Esta Guía ya fue ingresada tenga cuidado...!!!")
                Else
                    Dim estado_process As Boolean
                    'estado_process = oSolicitudGarantiaAtencionService.InsertarGuia(IdAfa, IdAfaDet, frm.IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    estado_process = oSolicitudGarantiaAtencionService.InsertarGuia(IdAfa, frm.IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        miActualizar_Click(sender, e)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al AGREGAR Guía  : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        Try
            If toNumber(dgvDatos.CurrentRow.Cells("CanAte").Value) > toNumber(dgvDatos.CurrentRow.Cells("CanMer").Value) Then
                MsgBox("La cantidad atendida no puede ser mayor a la cantidad de repuestos...!")
            Else
                Dim estado_process As Boolean
                Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaRepuestos
                Dim SolicitudGarantia As New SolicitudGarantiaAtencionService.SolicitudGarantia
                Dim GuiaRemisionDetalle As New SolicitudGarantiaAtencionService.GuiaRemisionDet
                Dim GuiaRemision As New SolicitudGarantiaAtencionService.GuiaRemision

                SolicitudGarantia.IdAfa = dgvDatos.CurrentRow.Cells("IdAfa").Value
                registro.SolicitudGarantia = SolicitudGarantia
                'registro.IdAfaDet = dgvDatos.CurrentRow.Cells("IdAfaDet").Value
                GuiaRemision.IdGuia = toNumber(dgvDatos.CurrentRow.Cells("IdGuia").Value)
                GuiaRemisionDetalle.GuiaRemision = GuiaRemision
                GuiaRemisionDetalle.IdGuiaDet = toNumber(dgvDatos.CurrentRow.Cells("IdGuiaDet").Value)
                registro.GuiaRemisionDet = GuiaRemisionDetalle
                registro.CanAte = toNumber(dgvDatos.CurrentRow.Cells("CanAte").Value)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.PreCompensado = toDouble(dgvDatos.CurrentRow.Cells("PreCompensado").Value)
                registro.PreFabrica = toDouble(dgvDatos.CurrentRow.Cells("PreFabrica").Value)

                estado_process = oSolicitudGarantiaAtencionService.ActualizarRepuesto(registro)
                If estado_process = False Then
                    MsgBox("Error al Actualizar Precios de Repuesto...")
                Else
                    ObtenerRegistro()
                    actualizarDetalles()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar Cantidad Atendida y/o Precios de Repuesto: " + ex.Message)
        End Try
    End Sub

    Private Sub miEliminarGuia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarGuia.Click
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Guía con CÓDIGO = " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                'estado_process = oSolicitudGarantiaAtencionService.BorrarGuia(toNumber(dgvDatos.CurrentRow.Cells("IdAfa").Value), toNumber(dgvDatos.CurrentRow.Cells("IdAfaDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdGuia").Value), Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                estado_process = oSolicitudGarantiaAtencionService.BorrarGuia(toNumber(dgvDatos.CurrentRow.Cells("IdAfa").Value), toNumber(dgvDatos.CurrentRow.Cells("IdGuia").Value), Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                If estado_process = True Then
                    dtDatos = Nothing
                    actualizarDetalles()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR GUIA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarRepuesto_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '    cmOpciones.Visible = False
        '    If MsgBox("Está seguro de ELIMINAR el Repuesto con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
        '        Dim estado_process As Boolean
        '        estado_process = oSolicitudGarantiaAtencionService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdAfa").Value), toNumber(dgvDatos.CurrentRow.Cells("IdAfaDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdGuia").Value), Session.sCodUsu, Session.sDirIp, Session.sNomPc)
        '        If estado_process = True Then
        '            dtDatos = Nothing
        '            actualizarDetalles()
        '            ObtenerRegistro()
        '            MsgBox("Se elimino correctamente el registro...!!!", MsgBoxStyle.Information)
        '        Else
        '            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
        '        End If
        '    Else
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR AL ELIMINAR GUIA:" + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub miCantAtendidaOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCantAtendidaOk.Click
        Try
            Dim estado_process As Boolean
            Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaRepuestos
            Dim SolicitudGarantia As New SolicitudGarantiaAtencionService.SolicitudGarantia
            Dim GuiaRemisionDetalle As New SolicitudGarantiaAtencionService.GuiaRemisionDet
            Dim GuiaRemision As New SolicitudGarantiaAtencionService.GuiaRemision

            For Each row In Me.dgvDatos.GetRows
                SolicitudGarantia.IdAfa = row.Cells("IdAfa").Value
                registro.SolicitudGarantia = SolicitudGarantia
                'registro.IdAfaDet = row.Cells("IdAfaDet").Value
                GuiaRemision.IdGuia = toNumber(row.Cells("IdGuia").Value)
                GuiaRemisionDetalle.GuiaRemision = GuiaRemision
                GuiaRemisionDetalle.IdGuiaDet = toNumber(row.Cells("IdGuiaDet").Value)
                registro.GuiaRemisionDet = GuiaRemisionDetalle
                registro.CanAte = toNumber(row.Cells("CanMer").Value)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.PreCompensado = toDouble(row.Cells("PreCompensado").Value)
                registro.PreFabrica = toDouble(row.Cells("PreFabrica").Value)

                estado_process = oSolicitudGarantiaAtencionService.ActualizarRepuesto(registro)
            Next

            ObtenerRegistro()
            actualizarDetalles()
        Catch ex As Exception
            MsgBox("Error al actualizar Cantidad Atendida Ok: " + ex.Message)
        End Try
    End Sub

    Private Sub miPrecFabricaOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miPrecFabricaOk.Click
        Try
            Dim estado_process As Boolean
            Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaRepuestos
            Dim SolicitudGarantia As New SolicitudGarantiaAtencionService.SolicitudGarantia
            Dim GuiaRemisionDetalle As New SolicitudGarantiaAtencionService.GuiaRemisionDet
            Dim GuiaRemision As New SolicitudGarantiaAtencionService.GuiaRemision

            For Each row In Me.dgvDatos.GetRows
                SolicitudGarantia.IdAfa = row.Cells("IdAfa").Value
                registro.SolicitudGarantia = SolicitudGarantia
                'registro.IdAfaDet = row.Cells("IdAfaDet").Value
                GuiaRemision.IdGuia = toNumber(row.Cells("IdGuia").Value)
                GuiaRemisionDetalle.GuiaRemision = GuiaRemision
                GuiaRemisionDetalle.IdGuiaDet = toNumber(row.Cells("IdGuiaDet").Value)
                registro.GuiaRemisionDet = GuiaRemisionDetalle
                registro.CanAte = toNumber(row.Cells("CanAte").Value)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.PreFabrica = toDouble(row.Cells("DeaMer").Value)
                registro.PreCompensado = toDouble(row.Cells("PreCompensado").Value)

                estado_process = oSolicitudGarantiaAtencionService.ActualizarRepuesto(registro)
            Next

            ObtenerRegistro()
            actualizarDetalles()
        Catch ex As Exception
            MsgBox("Error al actualizar Precio Fabrica Ok: " + ex.Message)
        End Try
    End Sub

    Private Sub biRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biRechazar.Click
        Try
            If IdAfa <> 0 Then
                Dim frm As New frmSolicitudGarantia_Rechazar
                frm.IdAfa = IdAfa
                frm.IdAfaDet = IdAfaDet
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    'ObtenerRegistro()
                    'enableOpciones()
                    'EnableOptions()
                    btnCancelar_Click(sender, e)
                End If
            Else
                MsgBox("Número de Formato AFA no válido...")
            End If
        Catch ex As Exception
            MsgBox("Error al RECHAZAR la Atención de Formato de ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAtender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAtender.Click
        Try
            If IdAfa <> 0 Then
                Dim frm As New frmSolicitudGarantia_Atender
                frm.IdAfa = IdAfa
                frm.IdAfaDet = IdAfaDet
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    'ObtenerRegistro()
                    'enableOpciones()
                    'EnableOptions()
                    btnCancelar_Click(sender, e)
                End If
            Else
                MsgBox("Número de Formato AFA no válido...")
            End If
        Catch ex As Exception
            MsgBox("Error al ATENDER la Atención de Formato de ORDEN DE REPARACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtTotManoObraRec_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotManoObraRec.ValueChanged, txtTotViajeRec.ValueChanged, txtTotRepuestosRec.ValueChanged, txtTotDistanciaRec.ValueChanged, txtTotNetItemRec.ValueChanged, txtTotOtrosRec.ValueChanged
        txtTotalMontoReclamado.Value = txtTotManoObraRec.Value + txtTotViajeRec.Value + txtTotRepuestosRec.Value + txtTotDistanciaRec.Value + txtTotNetItemRec.Value + txtTotOtrosRec.Value
    End Sub

    Private Sub txtTotManoObraAtendido_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotManoObraAtendido.ValueChanged, txtTotViajeAtendido.ValueChanged, txtTotRepuestosCli.ValueChanged, txtTotRepuestosAtendido.ValueChanged, txtTotDistanciaAtendido.ValueChanged, txtTotNetItem.ValueChanged, txtTotOtros.ValueChanged
        txtTotalMontoAtendido.Value = txtTotManoObraAtendido.Value + txtTotViajeAtendido.Value + txtTotRepuestosCli.Value + txtTotRepuestosAtendido.Value + txtTotDistanciaAtendido.Value + txtTotNetItem.Value + txtTotOtros.Value
    End Sub

    Private Sub miNuevoMO_Click(sender As Object, e As EventArgs) Handles miNuevoMO.Click
        NuevoDetalle()
    End Sub

    Private Sub NuevoDetalle()

        Try
            Dim lLog As Boolean = True
            While lLog

                Dim frm As New frmSolicitudGarantia_ManoObra
                frm.IdAfa = IdAfa
                frm.Fecha = txtFecha.Value
                frm.state_button = False
                'frm.iEstado = iEstado

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatosMO()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdHoraExtra)
                        'Mostrar()
                        ObtenerRegistro()
                        actualizarDetallesMO()
                    End If
                    enableOpciones()
                Else
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub actualizarDetallesMO()

        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdHoraExtra").Text
                End If
            End If
            dtDatos = Nothing
            listaDatosMO()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionMO(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miMostrarMO_Click(sender As Object, e As EventArgs) Handles miMostrarMO.Click
        If ValidaCodigoSeleccionadoMO() Then
            mostrarDetalleMO()
        End If
    End Sub

    Private Sub mostrarDetalleMO()
        Try
            Dim frm As New frmSolicitudGarantia_ManoObra
            frm.state_button = True
            frm.IdAfa = dgvManoObra.CurrentRow.Cells("IdAfa").Text
            frm.IdPer = dgvManoObra.CurrentRow.Cells("IdPer").Text
            frm.Fecha = dgvManoObra.CurrentRow.Cells("Fecha").Text
            frm.IdHoraExtra = dgvManoObra.CurrentRow.Cells("IdHoraExtra").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatosMO()
            End If

            RowPossesionMO(dgvDatos, frm.IdHoraExtra)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miEliminarMO_Click(sender As Object, e As EventArgs) Handles miEliminarMO.Click
        If ValidaCodigoSeleccionadoMO() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudGarantiaHorasService.Borrar(toNumber(dgvManoObra.CurrentRow.Cells("IdAfa").Value), toNumber(dgvManoObra.CurrentRow.Cells("IdPer").Value), Convert.ToDateTime(dgvManoObra.CurrentRow.Cells("Fecha").Value), toNumber(dgvManoObra.CurrentRow.Cells("IdHoraExtra").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatosMO = Nothing
                    listaDatosMO()
                    'ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else

            End If

        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA MANO DE OBRA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarMO_Click(sender As Object, e As EventArgs) Handles miActualizarMO.Click
        listaDatosMO()
    End Sub

    Private Function ValidaCodigoSeleccionadoMO() As Boolean
        Try
            If dgvManoObra.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvManoObra.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvManoObra.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub dgvManoObra_DoubleClick(sender As Object, e As EventArgs) Handles dgvManoObra.DoubleClick
        mostrarDetalleMO()
    End Sub

    Private Sub miImprimir_Click(sender As Object, e As EventArgs) Handles miImprimir.Click

        'Dim dtDatosImprimir As DataTable
        'dtDatosImprimir = oSolicitudGarantiaHorasService.ImprimirHoras(dgvManoObra.CurrentRow.Cells("IdAfa").Value, dgvManoObra.CurrentRow.Cells("IdPer").Value).Tables(0)
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim tothorastrabajo As Int32
            Dim tothorasviaje As Int32
            Dim tothoras25 As Int32
            Dim tothoras35 As Int32
            Dim tothoras100 As Int32

            Dim reporte As New rptSolicitudGarantiaDetalleMO  'rptSolicitudGarantiaDetalle

            If dgvManoObra.RowCount > 0 Then
                dtReporte = oSolicitudGarantiaHorasService.ImprimirHoras(dgvManoObra.CurrentRow.Cells("IdAfa").Value, dgvManoObra.CurrentRow.Cells("IdPer").Value).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    Dim idhoraex As Int32 = 0
                    Dim canthoras As Int32 = 0
                    Dim totalkm As Int32 = 0

                    Dim hortrabajo As Int32 = 0
                    Dim horviaje As Int32 = 0
                    Dim sum0 As Int32 = 0
                    Dim sum25 As Int32 = 0
                    Dim sum35 As Int32 = 0
                    Dim sum100 As Int32 = 0

                    For i = 0 To dtReporte.Rows.Count - 1

                        idhoraex = dtReporte.Rows(i).Item("IdHoraExtra")
                        canthoras = dtReporte.Rows(i).Item("CantHoras")
                        totalkm = dtReporte.Rows(i).Item("TotalKm")

                        If idhoraex = 1 Then
                            sum0 += dtReporte.Rows(i).Item("CantHoras")
                            horviaje += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 2 Then
                            sum25 += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 3 Then
                            sum35 += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 4 Then
                            sum100 += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        End If
                    Next

                    tothorastrabajo = hortrabajo
                    tothorasviaje = horviaje
                    tothoras25 = sum25
                    tothoras35 = sum35
                    tothoras100 = sum100

                    reporte.SetDataSource(dtReporte)
                    reporte.SetParameterValue("tothorastrabajo", tothorastrabajo)
                    reporte.SetParameterValue("tothorasviaje", tothorasviaje)
                    reporte.SetParameterValue("tothoras25", tothoras25)
                    reporte.SetParameterValue("tothoras35", tothoras35)
                    reporte.SetParameterValue("tothoras100", tothoras100)

                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de ORDEN DE REPARACION"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try



    End Sub


End Class