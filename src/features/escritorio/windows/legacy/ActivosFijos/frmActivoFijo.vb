Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmActivoFijo

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public CodActivo As String
    Public CodCentro As String
    Private dtUbicacion As DataTable
    Private dtEstados As DataTable
    Private dtTipoActivo As DataTable
    Public dtDatos As DataTable
    Public dtDatosObservaciones As DataTable
    Private dtMonedas As DataTable

    Private Sub frmActivoFijo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarcombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            Desactivar()
            gbEstado.Visible = True
            'gbDetalles.Visible = True
            tpDetalles.Visible = True
            actualizarDetalles()
            actualizarDetallesObs()
            Me.Text = "Activo Fijo"
            dgvDatos.Select()
        Else                          'Nuevo
            cmbMoneda.Value = "NS"
            Me.Size = New System.Drawing.Size(659, 400)
            gbEstado.Visible = False
            'gbDetalles.Visible = False
            tpDetalles.Visible = False
            Me.Text = "Registrar nuevo Activo Fijo"
            Activar()
            txtCodActivo.Focus()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   txtCodActivo.KeyPress _
                 , txtDescripcion.KeyPress _
                 , txtNumFactura.KeyPress _
                 , txtFecAdquisicion.KeyPress _
                 , txtMarca.KeyPress _
                 , txtModelo.KeyPress _
                 , txtSerie.KeyPress _
                 , cmbUbicacion.KeyPress _
                 , cmbTipoActivo.KeyPress _
                 , txtValorAdquisicion.KeyPress _
                 , txtFecBaja.KeyPress _
                 , txtVidaUtil.KeyPress _
                 , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmActivoFijo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVehiculo_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oActivoFijoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodActivo").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionObs(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("IdObservacion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarcombos()
        Try

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oActivoFijoService.MostrarUbicacion().Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '===================================== TIPO ACTIVO ===============================================
            dtTipoActivo = oActivoFijoService.MostrarTipo().Tables(0)
            cmbTipoActivo.DataSource = dtTipoActivo
            cmbTipoActivo.DropDownList.DataMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.DropDownList.DisplayMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.DropDownList.ValueMember = dtTipoActivo.Columns("IdTipo").ToString
            cmbTipoActivo.DropDownList.Columns(0).DataMember = dtTipoActivo.Columns("IdTipo").ToString
            cmbTipoActivo.DropDownList.Columns(1).DataMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.SelectedIndex = 0
            dtTipoActivo = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub enableOpcionesObs()
        If dgvObservaciones.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub



    Protected Sub Activar()
        Try
            If state_button Then   'Actualizar
                txtCodActivo.ReadOnly = True
                txtCodActivo.BackColor = System.Drawing.SystemColors.Control
                txtDescripcion.ReadOnly = False
                txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                txtNumFactura.ReadOnly = False
                txtNumFactura.BackColor = System.Drawing.SystemColors.Window
                txtFecAdquisicion.ReadOnly = False
                txtFecAdquisicion.BackColor = System.Drawing.SystemColors.Window
                txtMarca.ReadOnly = False
                txtMarca.BackColor = System.Drawing.SystemColors.Window
                txtModelo.ReadOnly = False
                txtModelo.BackColor = System.Drawing.SystemColors.Window
                txtSerie.ReadOnly = False
                txtSerie.BackColor = System.Drawing.SystemColors.Window
                cmbUbicacion.ReadOnly = False
                cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
                cmbTipoActivo.ReadOnly = False
                cmbTipoActivo.BackColor = System.Drawing.SystemColors.Window
                txtValorAdquisicion.ReadOnly = False
                txtValorAdquisicion.BackColor = System.Drawing.SystemColors.Window
                txtVidaUtil.ReadOnly = False
                txtVidaUtil.BackColor = System.Drawing.SystemColors.Window
                txtFecBaja.ReadOnly = True
                txtFecBaja.BackColor = System.Drawing.SystemColors.Control
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                txtCodMaleta.ReadOnly = False
                txtCodMaleta.BackColor = System.Drawing.SystemColors.Window
                edicion = True
                enableOpciones()
                enableOpcionesObs()
                txtDescripcion.Focus()

            Else                       'Nuevo
                txtCodActivo.ReadOnly = False
                txtCodActivo.BackColor = System.Drawing.SystemColors.Window
                txtDescripcion.ReadOnly = False
                txtDescripcion.BackColor = System.Drawing.SystemColors.Window
                txtNumFactura.ReadOnly = False
                txtNumFactura.BackColor = System.Drawing.SystemColors.Window
                txtFecAdquisicion.ReadOnly = False
                txtFecAdquisicion.BackColor = System.Drawing.SystemColors.Window
                txtMarca.ReadOnly = False
                txtMarca.BackColor = System.Drawing.SystemColors.Window
                txtModelo.ReadOnly = False
                txtModelo.BackColor = System.Drawing.SystemColors.Window
                txtSerie.ReadOnly = False
                txtSerie.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
                cmbUbicacion.ReadOnly = False
                cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
                cmbTipoActivo.ReadOnly = False
                cmbTipoActivo.BackColor = System.Drawing.SystemColors.Window
                txtValorAdquisicion.ReadOnly = False
                txtValorAdquisicion.BackColor = System.Drawing.SystemColors.Window
                txtVidaUtil.ReadOnly = False
                txtVidaUtil.BackColor = System.Drawing.SystemColors.Window
                txtFecBaja.ReadOnly = True
                txtFecBaja.BackColor = System.Drawing.SystemColors.Control
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                txtCodMaleta.ReadOnly = False
                txtCodMaleta.BackColor = System.Drawing.SystemColors.Window
                edicion = True
                enableOpciones()
                enableOpcionesObs()
                txtCodActivo.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try
            txtMemo.ReadOnly = True
            txtMemo.BackColor = System.Drawing.SystemColors.Control
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control

            txtCodActivo.ReadOnly = True
            txtCodActivo.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
            txtNumFactura.ReadOnly = True
            txtNumFactura.BackColor = System.Drawing.SystemColors.Control
            txtFecAdquisicion.ReadOnly = True
            txtFecAdquisicion.BackColor = System.Drawing.SystemColors.Control
            txtMarca.ReadOnly = True
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            txtModelo.ReadOnly = True
            txtModelo.BackColor = System.Drawing.SystemColors.Control
            txtSerie.ReadOnly = True
            txtSerie.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            cmbUbicacion.ReadOnly = True
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
            cmbTipoActivo.ReadOnly = True
            cmbTipoActivo.BackColor = System.Drawing.SystemColors.Control
            txtValorAdquisicion.ReadOnly = True
            txtValorAdquisicion.BackColor = System.Drawing.SystemColors.Control
            txtVidaUtil.ReadOnly = True
            txtVidaUtil.BackColor = System.Drawing.SystemColors.Control
            txtFecBaja.ReadOnly = True
            txtFecBaja.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            txtCodMaleta.ReadOnly = True
            txtCodMaleta.BackColor = System.Drawing.SystemColors.Control
            edicion = False
            enableOpciones()
            txtCodActivo.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodActivo.Text) = "" Then
                MsgBox("Debe ingresar el código del Activo Fijo", MsgBoxStyle.Information, "Información")
                txtCodActivo.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la descripción del Activo Fijo", MsgBoxStyle.Information, "Información")
                txtDescripcion.Focus()
                Return False
                'ElseIf toBlank(txtNumFactura.Text) = "" Then
                '    MsgBox("Debe ingresar el número de Factura", MsgBoxStyle.Information, "Información")
                '    txtNumFactura.Focus()
                '    Return False
            ElseIf toNull(txtFecAdquisicion.Value) = Nothing Then
                MsgBox("Debe ingresar la Fecha de Adquisición", MsgBoxStyle.Information, "Información")
                txtFecAdquisicion.Focus()
                Return False
                'ElseIf toBlank(txtMarca.Text) = "" Then
                '    MsgBox("Debe ingresar la Marca", MsgBoxStyle.Information, "Información")
                '    txtMarca.Focus()
                '    Return False
                'ElseIf toBlank(txtModelo.Text) = "" Then
                '    MsgBox("Debe ingresar el Modelo", MsgBoxStyle.Information, "Información")
                '    txtModelo.Focus()
                '    Return False
                'ElseIf toBlank(txtSerie.Text) = "" Then
                '    MsgBox("Debe ingresar la Serie", MsgBoxStyle.Information, "Información")
                '    txtSerie.Focus()
                '    Return False
            ElseIf toBlank(cmbUbicacion.Value) = "" Then
                MsgBox("Debe ingresar la Ubicación", MsgBoxStyle.Information, "Información")
                cmbUbicacion.Focus()
                Return False
            ElseIf toBlank(cmbTipoActivo.Value) = "" Then
                MsgBox("Debe ingresar el Tipo de Activo", MsgBoxStyle.Information, "Información")
                cmbTipoActivo.Focus()
                Return False
            ElseIf toDouble(txtValorAdquisicion.Value) = 0.00 Then
                MsgBox("Debe ingresar el valor de adquisición", MsgBoxStyle.Information, "Información")
                txtValorAdquisicion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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

    Private Function ValidaCodigoSeleccionadoObs() As Boolean
        Try
            If dgvObservaciones.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvObservaciones.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvObservaciones.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Protected Sub ObtenerRegistro()
        Try

            Dim registro As ActivoFijoService.ActivoFijo
            registro = oActivoFijoService.Obtener(CodActivo, Session.sCodEmp)

            CodActivo = registro.CodActivo
            txtCodActivo.Text = registro.CodActivo
            lblEstado.Text = registro.EstadoActivoFijo.DesEstado
            txtDescripcion.Text = registro.DesActivo
            txtNumFactura.Text = registro.NumFactura
            txtFecAdquisicion.Value = registro.FecAdquisicion
            txtMarca.Text = registro.Marca
            txtModelo.Text = registro.Modelo
            txtSerie.Text = registro.Serie
            cmbUbicacion.Value = registro.UbicacionActivoFijo.IdUbicacion
            cmbTipoActivo.Value = registro.TipoActivo.IdTipo
            txtVidaUtil.Value = registro.VidaUtil
            txtValorAdquisicion.Value = registro.ValorAdquisicion
            txtMemo.Text = registro.RecursoDet.Recurso.NumDoc
            txtColaborador.Text = registro.RecursoDet.Recurso.Persona.ApeNom
            txtCodMaleta.Text = registro.CodMaleta
            cmbMoneda.Value = registro.Moneda.CodMon
            If Not (registro.FechaBaja.ToString = "") Then
                txtFecBaja.Value = CDate(registro.FechaBaja)
                txtFecBaja.Text = registro.FechaBaja.ToString
            End If
            txtObservacion.Text = registro.Observaciones
            CodCentro = registro.CentroCosto.CodCentro

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmActivoFijo_Gasto
                frm.CodActivo = toBlank(txtCodActivo.Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    enableOpciones()
                    listaDatos()
                Else
                    enableOpciones()
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("Error al Ingresar Solicitud de Gastos al Activo Fijo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oActivoFijoService.BorrarGasto(toNumber(dgvDatos.CurrentRow.Cells("IdGastoDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdGasto").Value),
                                                                                       toBlank(dgvDatos.CurrentRow.Cells("CodActivo").Value), Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmComSolicitudGastoDetNew
            frm.state_button = True
            frm.IdGastoDet = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
            frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
            frm.estado = 5
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizarDetalles()
                ObtenerRegistro()
            End If
            RowPossesion(dgvDatos, frm.IdGastoDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesObs()
        Try
            Dim codigo As String = ""
            If dgvObservaciones.RowCount > 0 Then
                If IsDBNull(dgvObservaciones.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvObservaciones.CurrentRow.Cells("IdObservacion").Text
                End If
            End If
            dtDatos = Nothing
            listaDatosObservaciones()
            If dgvObservaciones.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionObs(dgvObservaciones, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Insertar(ByVal registro As ActivoFijoService.ActivoFijo)
        Try
            Dim estado_process As Boolean
            estado_process = oActivoFijoService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                CodActivo = txtCodActivo.Text
                MsgBox("Se insertó el Activo Fijo Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As ActivoFijoService.ActivoFijo)
        Try
            Dim estado_process As Boolean
            estado_process = oActivoFijoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Activo Fijo Correctamente")
                Desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oActivoFijoService.Borrar(CodActivo, Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oActivoFijoService.MostrarGasto(CodActivo, Session.sCodEmp).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosObservaciones()
        Try
            dtDatosObservaciones = oActivoFijoService.MostrarObservacion(CodActivo, Session.sCodEmp).Tables(0)
            dgvObservaciones.DataSource = dtDatosObservaciones
            enableOpcionesObs()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New ActivoFijoService.ActivoFijo
                Dim ubicacion As New ActivoFijoService.UbicacionActivoFijo
                Dim empresa As New ActivoFijoService.Empresa
                Dim tipoactivo As New ActivoFijoService.TipoActivo
                Dim centrocosto As New ActivoFijoService.CentroCosto
                Dim moneda As New ActivoFijoService.Moneda

                registro.CodActivo = txtCodActivo.Text
                registro.DesActivo = toBlank(txtDescripcion.Text)
                registro.NumFactura = toBlank(txtNumFactura.Text)
                registro.FecAdquisicion = txtFecAdquisicion.Value
                registro.Marca = toBlank(txtMarca.Text)
                registro.Modelo = toBlank(txtModelo.Text)
                registro.Serie = toBlank(txtSerie.Text)
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                ubicacion.IdUbicacion = toNumber(cmbUbicacion.Value)
                registro.UbicacionActivoFijo = ubicacion
                tipoactivo.IdTipo = cmbTipoActivo.Value
                registro.TipoActivo = tipoactivo
                registro.VidaUtil = txtVidaUtil.Value
                registro.ValorAdquisicion = txtValorAdquisicion.Value
                registro.FechaBaja = IIf(txtFecBaja.Text = "", Nothing, txtFecBaja.Value)
                registro.Observaciones = toBlank(txtObservacion.Text)
                registro.CodMaleta = toBlank(txtCodMaleta.Text)
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                centrocosto.CodCentro = CodCentro
                registro.CentroCosto = centrocosto
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button = True Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodActivo").Text
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

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Obs" Then
                Dim Observacion As String
                Observacion = dgvDatos.CurrentRow.Cells("Observaciones").Value

                Dim frm As New frmActivoFijo_Obrsv
                frm.Text = "Observación :"
                frm.txtObservacion.Text = Observacion

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Dim registro As New ActivoFijoService.ActivoFijoGastos
                    Dim activo As New ActivoFijoService.ActivoFijo
                    Dim SolicitudGasto As New ActivoFijoService.SolicitudGasto
                    Dim SolicitudGastoDet As New ActivoFijoService.SolicitudGastoDet
                    Dim empresa As New ActivoFijoService.Empresa

                    empresa.CodEmp = Session.sCodEmp
                    activo.CodActivo = toBlank(txtCodActivo.Text)
                    activo.Empresa = empresa
                    registro.ActivoFijo = activo

                    SolicitudGasto.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Value
                    SolicitudGastoDet.IdGastoDet = dgvDatos.CurrentRow.Cells("IdGastoDet").Value
                    SolicitudGastoDet.SolicitudGasto = SolicitudGasto
                    registro.SolicitudGastoDet = SolicitudGastoDet
                    registro.Observaciones = toBlank(frm.txtObservacion.Text)

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    oActivoFijoService.ActualizarObservacionGasto(registro)

                    listaDatos()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar la Observación " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvObservaciones_ColumnButtonClick(sender As Object, e As ColumnActionEventArgs) Handles dgvObservaciones.ColumnButtonClick
        Try
            If e.Column.Key = "Obs" Then
                Dim Observacion As String
                Observacion = dgvObservaciones.CurrentRow.Cells("Observacion").Value

                Dim frm As New frmActivoFijo_Obrsv
                frm.Text = "Observación :"
                frm.txtObservacion.Text = Observacion

            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar la Observación " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoObs_Click(sender As Object, e As EventArgs) Handles miNuevoObs.Click
        Try
            Dim frm As New frmActivoFijo_Observaciones
            frm.estado_proceso = False
            frm.CodActivo = txtCodActivo.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatosObservaciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarObs_Click(sender As Object, e As EventArgs) Handles miMostrarObs.Click, dgvObservaciones.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionadoObs() Then
                mostrarDetalleObs()
            End If
        End If
    End Sub

    Private Sub miEliminarObs_Click(sender As Object, e As EventArgs) Handles miEliminarObs.Click
        If ValidaCodigoSeleccionadoObs() Then
            eliminarDetalleObs()
        End If
    End Sub

    Private Sub miActualizarObs_Click(sender As Object, e As EventArgs) Handles miActualizarObs.Click
        listaDatosObservaciones()
    End Sub

    Private Sub mostrarDetalleObs()
        Dim frm As New frmActivoFijo_Observaciones
        frm.estado_proceso = True
        frm.IdObservacion = CInt(dgvObservaciones.CurrentRow.Cells("IdObservacion").Value)

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            actualizarDetallesObs()
        End If
    End Sub

    Private Sub eliminarDetalleObs()

        Try
            Dim estado_process As Boolean
            estado_process = oActivoFijoService.BorrarObservacion(dgvObservaciones.CurrentRow.Cells("IdObservacion").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process = True Then
                dtDatosObservaciones = Nothing
                listaDatosObservaciones()
                MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA OBSERVACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub dgvObservaciones_SelectionChanged(sender As Object, e As EventArgs) Handles dgvObservaciones.SelectionChanged
        enableOpcionesObs()
    End Sub

    Private Sub dgvObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvObservaciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrarObs_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
End Class