Imports System.ServiceModel

Public Class frmComSolicitudCompra_AgregarDetalle

    Private oMercaderiaService As New ProductoService.ProductoServiceClient   'MercaderiaService.MercaderiaServiceClient
    Private oSolicitudCompraDetService As New SolicitudCompraDetService.SolicitudCompraDetServiceClient
    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oCotizacionSolicitudDetService As New CotizacionSolicitudDetService.CotizacionSolicitudDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    'Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    Private dtUnidadesMedida As DataTable
    Private dtTipoGasto As DataTable
    Public IdSolicitud As Integer
    Public IdSolicitudDet As Integer
    Public state_button As Boolean
    Private dtCotizaciones As DataTable
    Private Estado As String
    Public Asignado As Boolean
    Private TieneCotizaciones As Integer
    Private dtRubros As DataTable
    'Private dtAreas As DataTable              'Se agrega el área 05/12/2012                                         'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
    'Private dtCentroCosto As DataTable    'Se agrega el centro de costo 05/12/2012                         'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
    'Public CodArea As String                   'CodArea que viene de la cabecera                                  'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
    'Public CodCentro As String                'Codigo de Centro de Costo del solicitante (cabecera)       'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
    Public CodJob As String                     'CodJob que viene de la cabecera        


    Private Sub frmComSolicitudCompra_AgregarDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oMercaderiaService.Close()
            oSolicitudCompraDetService.Close()
            oSolicitudCompraService.Close()
            oCotizacionSolicitudDetService.Close()
            oMaestroService.Close()
            oGastoRealService.Close()
            'oPersonaService.Close()
            oJobService.Close()
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oMercaderiaService.Abort()
            oSolicitudCompraDetService.Abort()
            oSolicitudCompraService.Abort()
            oCotizacionSolicitudDetService.Abort()
            oMaestroService.Abort()
            oGastoRealService.Abort()
            'oPersonaService.Abort()
            oJobService.Abort()
            oSolicitudGastoDetService.Abort()
        Catch ex As CommunicationException
            oMercaderiaService.Abort()
            oSolicitudCompraDetService.Abort()
            oSolicitudCompraService.Abort()
            oCotizacionSolicitudDetService.Abort()
            oMaestroService.Abort()
            oGastoRealService.Abort()
            'oPersonaService.Abort()
            oJobService.Abort()
            oSolicitudGastoDetService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmComSolicitudCompra_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                e.Handled = True
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmComSolicitudCompra_AgregarDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCodMer.KeyPress _
        , txtDescripcion.KeyPress _
         , cmbCotizaciones.KeyPress _
         , txtCanMer.KeyPress _
         , cmbCodUniMed.KeyPress
        ', cmbArea.KeyPress _
        ', cmbCentroCosto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComSolicitudCompra_AgregarDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Estado = oSolicitudCompraService.ObtenerEstado(IdSolicitud)
        llenarCombos()
        If state_button Then
            listaCotizaciones()
            ObtenerRegistro()
            txtObservTipoGasto.Text = ""

            If Estado = 3 Or Estado = 7 Then
                cmbCotizaciones.Select()
                cmbCotizaciones.DroppedDown = IIf(Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "25", True, False)
                btnAceptar.TabIndex = 0
                btnCancelar.TabIndex = 1
            End If
            Me.Text = "Código de mercaderia N°: " & txtCodMer.Text

        Else
            cmbCodUniMed.Value = "UND"
            'cmbArea.Value = CodArea
            'cmbCentroCosto.Value = CodCentro
            Me.Text = "Agregar nueva mercaderia"
            txtCodMer.Select()
        End If
        Desactivar()

    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = 0
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        'Try
        '    fila(2) = "(Ninguno)"
        'Catch ex As Exception
        'End Try

        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
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

    Private Function getRowTodos2(ByVal data As DataTable)
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


    Private Sub llenarCombos()
        Try
            '=====================================UNIDAD DE MEDIDA==========================================
            dtUnidadesMedida = oMaestroService.MostrarUnidadMedida.Tables(0)
            'dtUnidadesMedida.Rows.InsertAt(getRowTodos(dtUnidadesMedida), 0)
            cmbCodUniMed.DataSource = dtUnidadesMedida
            cmbCodUniMed.DropDownList.DataMember = dtUnidadesMedida.Columns("Nombre").ToString
            cmbCodUniMed.DropDownList.DisplayMember = dtUnidadesMedida.Columns("Nombre").ToString
            cmbCodUniMed.DropDownList.ValueMember = dtUnidadesMedida.Columns("CodUniMed").ToString
            cmbCodUniMed.DropDownList.Columns(0).DataMember = dtUnidadesMedida.Columns("CodUniMed").ToString
            cmbCodUniMed.DropDownList.Columns(1).DataMember = dtUnidadesMedida.Columns("Nombre").ToString
            dtUnidadesMedida = Nothing

            ''========================================== AREAS ===============================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'dtAreas = Nothing

            ' ''========================================== RUBROS ===============================================
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos1(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            dtTipoGasto.Rows.InsertAt(getRowTodos2(dtTipoGasto), 0)
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
            MsgBox("Error al llenar los combos : " + ex.Message, MsgBoxStyle.Exclamation)
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
        Me.Close()
    End Sub

    Private Sub listaCotizaciones()
        Try
            dtCotizaciones = oSolicitudCompraDetService.MostrarCotizaciones(IdSolicitud, IdSolicitudDet).Tables(0)
            TieneCotizaciones = dtCotizaciones.Rows.Count
            dtCotizaciones.Rows.InsertAt(getRowTodos(dtCotizaciones), 0)
            cmbCotizaciones.DataSource = dtCotizaciones
            cmbCotizaciones.DropDownList.DataMember = dtCotizaciones.Columns("NumCotizacion").ToString
            cmbCotizaciones.DropDownList.DisplayMember = dtCotizaciones.Columns("NumCotizacion").ToString
            cmbCotizaciones.DropDownList.ValueMember = dtCotizaciones.Columns("IdCotizacionDet").ToString
            cmbCotizaciones.DropDownList.Columns(0).DataMember = dtCotizaciones.Columns("IdCotizacion").ToString
            cmbCotizaciones.DropDownList.Columns(1).DataMember = dtCotizaciones.Columns("IdCotizacionDet").ToString
            cmbCotizaciones.DropDownList.Columns(2).DataMember = dtCotizaciones.Columns("NumCotizacion").ToString
            cmbCotizaciones.DropDownList.Columns(3).DataMember = dtCotizaciones.Columns("DesProv").ToString
            cmbCotizaciones.DropDownList.Columns(4).DataMember = dtCotizaciones.Columns("CanMer").ToString
            cmbCotizaciones.DropDownList.Columns(5).DataMember = dtCotizaciones.Columns("PreMer").ToString
            cmbCotizaciones.DropDownList.Columns(6).DataMember = dtCotizaciones.Columns("DscMer").ToString
            cmbCotizaciones.DropDownList.Columns(7).DataMember = dtCotizaciones.Columns("TotalFila").ToString
            cmbCotizaciones.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error al listar las cotizaciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudCompraDetService.SolicitudCompraDet

            registro = oSolicitudCompraDetService.Obtener(IdSolicitudDet)

            txtCodMer.Text = registro.CodMer
        
            txtDescripcion.Text = registro.DesMer
            txtCanMer.Value = registro.CanMer
            txtCodJob.Text = registro.Job.CodJob
            cmbTipoGasto.Value = registro.TipoGasto.IdTipoGasto

            If CStr(registro.RubroGasto.CodRubro) <> "" Then
                cmbRubro.Value = registro.RubroGasto.CodRubro
            Else
                cmbRubro.SelectedIndex = 0
            End If

            'cmbArea.Value = registro.CentroCosto.Area.CodArea
            'cmbCentroCosto.Value = registro.CentroCosto.CodCentro

            cmbCodUniMed.Value = registro.UnidadMedida.CodUniMed
            txtObservacion.Text = registro.Observacion
            ObtenerCotizacion()

        Catch ex As Exception
            MsgBox("Error al listar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerCotizacion()

        Try
            cmbCotizaciones.Value = oSolicitudCompraDetService.ObtenerCotizacionAceptada(IdSolicitud, IdSolicitudDet)

            If cmbCotizaciones.Value > 0 Then
                Dim cotizacion As CotizacionSolicitudDetService.CotizacionSolicitudDet
                cotizacion = oCotizacionSolicitudDetService.Obtener(oSolicitudCompraDetService.ObtenerCotizacionAceptada(IdSolicitud, IdSolicitudDet))

                txtPreMer.Value = cotizacion.PreMer
                txtDscto.Value = cotizacion.DscMer
                txtTotal.Value = cotizacion.TotalFila
                txtMotivo.Text = cotizacion.Observacion
                txtCantidad.Text = cotizacion.CanMer
            End If

        Catch ex As Exception
            MsgBox("Error al obtener la cotización asignada : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub AsignarCotizacion()
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudCompraDetService.AsignarCotizacion(cmbCotizaciones.DropDownList.GetRow.Cells(1).Text, cmbCotizaciones.DropDownList.GetRow.Cells(0).Text, IdSolicitud, IdSolicitudDet, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se asignó la cotización correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , Comumicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("Error al asignar cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RevertirCotizacion()
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudCompraDetService.RevertirAsignacionCotizacion(IdSolicitud, IdSolicitudDet, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                If cmbCotizaciones.Value = 0 Then
                    MsgBox("Se realizó la reversión correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    AsignarCotizacion()
                End If

            Else
                MsgBox("Error en el proceso, comunicarse con el departamento de TI")
            End If
        Catch ex As Exception
            MsgBox("Error al revertir la cotización : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        Try
            txtCodMer.ReadOnly = IIf(Estado = 1, False, True)
            txtCodMer.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            cmbRubro.ReadOnly = IIf(Estado = 1, False, True)
            cmbRubro.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            cmbTipoGasto.ReadOnly = IIf(Estado = 1, False, True)
            cmbTipoGasto.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            cmbRubro.ReadOnly = IIf(Estado = 1, False, True)
            cmbRubro.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            txtDescripcion.ReadOnly = IIf(Estado = 1, False, True)
            txtDescripcion.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            txtCanMer.ReadOnly = IIf(Estado = 1, False, True)
            txtCanMer.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            txtCodJob.ReadOnly = IIf(Estado = 1, False, True)
            txtCodJob.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            btnBuscarJob.Enabled = IIf(Estado = 1, True, False)
            cmbCodUniMed.ReadOnly = IIf(Estado = 1, False, True)
            cmbCodUniMed.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            'cmbArea.ReadOnly = IIf(Estado = 1, False, True)
            'cmbArea.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            'cmbCentroCosto.ReadOnly = IIf(Estado = 1, False, True)
            'cmbCentroCosto.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            cmbCotizaciones.ReadOnly = IIf(Estado = 3 Or (Estado = 7 And Asignado = False) And (Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "25"), False, True)
            cmbCotizaciones.BackColor = IIf(Estado = 3 Or (Estado = 7 And Asignado = False) And (Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "25"), System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            txtObservacion.ReadOnly = IIf(Estado = 1, False, True)
            txtObservacion.BackColor = IIf(Estado = 1, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            txtMotivo.ReadOnly = IIf(Estado = 3 And (Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "25"), False, True)
            txtMotivo.BackColor = IIf(Estado = 3 And (Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "25"), System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Control)
            btnBuscarMercaderia.Enabled = IIf(Estado = 1, True, False)

            btnAceptar.Enabled = IIf(Estado = 1 Or (Estado = 7 And Asignado = False And utils.toNumber(TieneCotizaciones) > 0 And (Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "´42" Or Session.CodPerfil = "25")) Or (Estado = 3 And utils.toNumber(TieneCotizaciones) > 0 And (Session.CodPerfil = "28" Or Session.CodPerfil = "30" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "25")), True, False)

        Catch ex As Exception
            MsgBox("Error al desactivar los campos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Insertar(ByVal registro As SolicitudCompraDetService.SolicitudCompraDet)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudCompraDetService.Insertar(registro)
            If estado_process > 0 Then
                MsgBox("Se insertó el registro correctamente ", MsgBoxStyle.Information)
                IdSolicitudDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al insertar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As SolicitudCompraDetService.SolicitudCompraDet)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudCompraDetService.Actualizar(registro)

            If estado_process Then
                MsgBox("Se modificó el registro correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, Comunicarse con el administrador del sistema")
            End If

        Catch ex As Exception
            MsgBox("Error al modificar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Dim dtTable As New DataTable
        dtTable = oSolicitudGastoDetService.MostrarRubros(toNumber(cmbTipoGasto.Value)).Tables(0)
        Try
            'If Estado = 3 Or Estado = 7 Then
            '    If toNumber(cmbCotizaciones.Value) = 0 Then
            '        MsgBox("Debe Seleccionar una Cotización")
            '        txtCodMer.Focus()
            '        Return False
            '    Else
            '        Return True
            '    End If
            'Else
            'Comentado para q deje pasar sin codigo 16-05
            'If toBlank(txtCodMer.Text) = "" Then
            '    MsgBox("Debe ingresar el código de la mercaderia")
            '    txtCodMer.Focus()
            '    Return False
            'If txtCodJob.Text <> "" And toBlank(cmbRubro.Value) = "" Then
            '    MsgBox("Debe ingresar el Rubro")
            '    cmbRubro.Focus()
            '    Return False
            If toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la descripción de la mercaderia")
                txtDescripcion.Focus()
                Return False
            ElseIf toBlank(cmbTipoGasto.Value) = "" Then
                MsgBox("Debe ingresar el tipo de gasto")
                cmbCodUniMed.Focus()
                Return False
            ElseIf toDouble(txtCanMer.Value) <= 0 Then
                MsgBox("La cantidad debe ser mayor a CERO.")
                txtCanMer.Focus()
                Return False
            ElseIf toBlank(cmbCodUniMed.Value) = "" Then
                MsgBox("Debe ingresar la unidad de medida")
                cmbCodUniMed.Focus()
                Return False
            ElseIf toNumber(cmbTipoGasto.Value) = 0 Then
                MsgBox("Debe ingresar el tipo de gasto")
                cmbTipoGasto.Focus()
                Return False
            ElseIf toNumber(cmbRubro.Value) = 0 And dtTable.Rows.Count > 0 Then '-------- 04/07/2018 --------         
                MsgBox("Debe Ingresar el Rubro", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
                '-------------------- Se comenta ya que ingresará el centro de costo en el módulo de facturación -------------------
                'ElseIf toBlank(cmbArea.Value) = "" Then
                '    MsgBox("Debe ingresar el Área")
                '    cmbArea.Focus()
                '    Return False
                'ElseIf toBlank(cmbCentroCosto.Value) = "" Then
                '    MsgBox("Debe ingresar el Centro de Costo")
                '    cmbCentroCosto.Focus()
                '    Return False
                '-------------------------------------------------------------------------------------------------------------------------------------------------------
            Else
                Return True
            End If
            'End If
        Catch ex As Exception
            MsgBox("Error al validar los campos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Está Seguro de GUARDAR los Datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

            Dim registro As New SolicitudCompraDetService.SolicitudCompraDet
            Dim solicitudcompra As New SolicitudCompraDetService.SolicitudCompra
            Dim unidadmedida As New SolicitudCompraDetService.UnidadMedida
            Dim Rubro As New SolicitudCompraDetService.RubroGasto
            Dim tipogasto As New SolicitudCompraDetService.TipoGasto
            'Dim Area As New SolicitudCompraDetService.Area
            'Dim CentroCosto As New SolicitudCompraDetService.CentroCosto
            Dim job As New SolicitudCompraDetService.Job

            solicitudcompra.IdSolicitud = IdSolicitud
            registro.SolicitudCompra = solicitudcompra
            registro.IdSolicitudDet = IdSolicitudDet
            registro.CodMer = toNull(txtCodMer.Text)
            job.CodJob = toNull(txtCodJob.Text)
            registro.Job = job
            tipogasto.IdTipoGasto = toNumber(cmbTipoGasto.Value)
            registro.TipoGasto = tipogasto
            Rubro.CodRubro = IIf(cmbRubro.SelectedIndex = 0, Nothing, cmbRubro.Value)
            registro.RubroGasto = Rubro
            registro.DesMer = toNull(txtDescripcion.Text)
            registro.CanMer = toDouble(txtCanMer.Value)
            unidadmedida.CodUniMed = toBlank(cmbCodUniMed.Value)
            registro.UnidadMedida = unidadmedida



            'Area.CodArea = cmbArea.Value
            'CentroCosto.CodCentro = cmbCentroCosto.Value
            'CentroCosto.Area = Area
            'registro.CentroCosto = CentroCosto

            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp


            If Estado = 3 Or Estado = 7 Then

                If oSolicitudCompraDetService.ObtenerCotizacionAceptada(IdSolicitud, IdSolicitudDet) = 0 Then
                    AsignarCotizacion()
                    'If cmbCotizaciones.Value <> 0 Then
                    '    AsignarCotizacion()
                    'Else
                    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'End If
                Else
                    RevertirCotizacion()

                End If

            Else

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If

            End If

        End If
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm.codigo
            txtDescripcion.Text = frm.descripcion
            txtCodMer.Focus()
        End If
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If oMercaderiaService.Buscar(Trim(txtCodMer.Text), Session.sCodEmp) Then
            Dim mercaderia As ProductoService.Producto   'MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
            txtDescripcion.Text = mercaderia.DesMer1
        End If

    End Sub

    Private Sub cmbCotizaciones_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCotizaciones.ValueChanged
        Try
            txtPreMer.Value = toDouble(cmbCotizaciones.DropDownList.GetRow.Cells(5).Text)
            txtDscto.Value = toDouble(cmbCotizaciones.DropDownList.GetRow.Cells(6).Text)
            txtTotal.Value = toDouble(cmbCotizaciones.DropDownList.GetRow.Cells(7).Text)
            txtMotivo.Text = ""
        Catch ex As Exception
            MsgBox("Error al evaluar las cotizaciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub evaluarPrecio()
    '    Try
    '        txtPreMer.Value = toDouble(cmbCotizaciones.DropDownList.GetRow.Cells(5).Text)
    '        txtDscto.Value = toDouble(cmbCotizaciones.DropDownList.GetRow.Cells(6).Text)
    '        txtTotal.Value = toDouble(cmbCotizaciones.DropDownList.GetRow.Cells(7).Text)
    '    Catch ex As Exception
    '        MsgBox("Error al evaluar los precios : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnVerCotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerCotizaciones.Click
        Try
            Dim frm As New frmComSolicitudCompra_VerCotizacion

            frm.IdSolicitud = IdSolicitud
            frm.IdSolicitudDet = IdSolicitudDet
            frm.CodMer = txtCodMer.Text
            frm.IdCotizacionDet = oSolicitudCompraDetService.ObtenerCotizacionAceptada(IdSolicitud, IdSolicitudDet)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al ver las cotizaciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtCodJob.Text = frm.cod_job
                Else
                    txtCodJob.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtCodJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtCodJob.Text = ""
                    txtCodJob.Focus()
                ElseIf oJobService.Estado(txtCodJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtCodJob.Text = ""
                    txtCodJob.Focus()
                Else
                    'If txtCodJob.Enabled = True Then
                    '    cmbRubro.Enabled = True
                    '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    '    cmbRubro.Focus()
                    'End If
                    'cmbRubro.Enabled = False
                    'cmbRubro.BackColor = System.Drawing.SystemColors.Control
                    txtDescripcion.Focus()
                End If
            Else
                txtDescripcion.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodJob.Validated
        Try
            If Len(Trim(txtCodJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtCodJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtCodJob.Text = ""
                    txtCodJob.Focus()
                ElseIf oJobService.Estado(txtCodJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtCodJob.Text = ""
                ElseIf oJobService.Estado(txtCodJob.Text) = 1 Then
                    MsgBox("Número de OT Anulado, Verifique")
                    txtCodJob.Text = ""
                    txtCodJob.Focus()
                Else
                    'If txtCodJob.Enabled = True Then
                    '    cmbRubro.Enabled = True
                    '    cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    'End If
                    txtDescripcion.Focus()
                End If
            Else
                'cmbRubro.Enabled = False
                'cmbRubro.BackColor = System.Drawing.SystemColors.Control
                txtDescripcion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub cmbTipoGasto_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoGasto.ValueChanged
        ObtenerObservacionTipoGasto()
        LlenarRubroGasto()
    End Sub

    Private Sub ObtenerObservacionTipoGasto()
        If cmbTipoGasto.SelectedIndex <> 0 Then
            txtObservTipoGasto.Text = toBlank(cmbTipoGasto.DropDownList.GetRow.Cells(2).Text)    'Obtiene el Texto de la 3 columna del Combo TipoGasto
        Else
            txtObservTipoGasto.Text = ""
        End If
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
End Class