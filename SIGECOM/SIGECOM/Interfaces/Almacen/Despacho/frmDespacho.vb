Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmDespacho

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient
    Private oDespachoDetService As New DespachoDetService.DespachoDetServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 

    Public IdChofer As Integer = 0
    Public IdAcompanante As Integer = 0

    Public IdDespachoCab As Integer
    Public iEstado As Integer
    Private dtDatos As DataTable
    Private dtUbicacion As DataTable
    Private dtPlaca As DataTable
    Public iUbicacion As Integer

    Private Sub frmDespacho_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDespachoDetService.Close()
            oDespachoCabService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oDespachoDetService.Abort()
            oDespachoCabService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oDespachoDetService.Abort()
            oDespachoCabService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmDespacho_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDespacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()

        If state_button Then    'Modificar 
            'iEstado = oPlanillaViaticoService.ObtenerEstado(IdPlanilla)
            ObtenerRegistro()
            Desactivar()
            Me.Size = New System.Drawing.Size(936, 489)
            dgvDatos.Visible = True
            Me.Text = "Despacho Nº " + Chr(34) + txtNumero.Text.ToString + Chr(34)
            listaDatos()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(936, 265)
            dgvDatos.Visible = False
            Me.Text = "Registrar Nuevo Despacho"

            'txtHoraSalida.Text = Now().ToString("HH:mm:ss")
            cmbPlaca.SelectedIndex = -1
            ActivarNuevo()
            'ObtenerSolicitante()
            txtFecha.Select()
        End If


    End Sub

    Private Sub llenarCombos()

        Try
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            'dtPlaca.Rows.InsertAt(getRowTodos(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = "(Ninguno)"
    '    Catch ex As Exception
    '        fila(0) = 0
    '    End Try
    '    Try
    '        fila(1) = "(Ninguno)"
    '    Catch ex As Exception
    '        fila(2) = "(Ninguno)"
    '    End Try
    '    Try
    '        fila(2) = "(Ninguno)"
    '    Catch ex As Exception
    '        fila(3) = 0
    '    End Try
    '    Return fila
    'End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As DespachoCabService.DespachoCab
            registro = oDespachoCabService.Obtener(IdDespachoCab)

            IdDespachoCab = registro.IdDespachoCab
            txtNumero.Text = registro.IdDespachoCab
            iEstado = registro.EstadosDespacho.IdEstado
            lblEstado.Text = registro.EstadosDespacho.DesEstado
            txtFecha.Value = registro.Fecha
            IdChofer = registro.Chofer.IdPer
            txtChofer.Text = registro.Chofer.ApeNom
            IdAcompanante = registro.Acompanante.IdPer
            txtAcompanante.Text = registro.Acompanante.ApeNom
            'txtHoraSalida.Text = registro.HoraSalida.ToLongTimeString

            If (IsNothing(registro.HoraSalida) Or IsDBNull(registro.HoraSalida)) Then
                txtHoraSalida.Text = ""
            Else
                txtHoraSalida.Text = registro.HoraSalida
            End If

            If (IsNothing(registro.HoraRetorno) Or IsDBNull(registro.HoraRetorno)) Then
                txtHoraRetorno.Text = ""
            Else
                txtHoraRetorno.Text = registro.HoraRetorno
            End If

            'txtHoraRetorno.Text = registro.HoraRetorno

            'If registro.Unidad.Placa = Nothing Or registro.Unidad.Placa = "" Then
            '    cmbPlaca.SelectedIndex = 0
            'Else
            '    cmbPlaca.Value = registro.Unidad.Placa
            'End If
            cmbPlaca.Value = registro.Unidad.Placa
            'txtPlaca.Text = registro.Unidad.Placa
            txtObservacion.Text = registro.Observacion

            Me.Text = "Despacho Nº " + registro.IdDespachoCab.ToString

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()

        If iEstado = "1" Then

            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtHoraSalida.ReadOnly = True
            txtHoraSalida.BackColor = System.Drawing.SystemColors.Control
            txtHoraRetorno.ReadOnly = True
            txtHoraRetorno.BackColor = System.Drawing.SystemColors.Control
            cmbPlaca.ReadOnly = True
            cmbPlaca.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

            btnBuscarChofer.Enabled = False
            btnBuscarAcompanante.Enabled = False

            biGuardar.Enabled = False
            biEditar.Enabled = True
            biDeshacer.Enabled = False
            biSalir.Enabled = True

            'cmOpciones.Enabled = True

        Else

            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtHoraSalida.ReadOnly = True
            txtHoraSalida.BackColor = System.Drawing.SystemColors.Control
            txtHoraRetorno.ReadOnly = True
            txtHoraRetorno.BackColor = System.Drawing.SystemColors.Control
            cmbPlaca.ReadOnly = True
            cmbPlaca.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

            btnBuscarChofer.Enabled = False
            btnBuscarAcompanante.Enabled = False

            biGuardar.Enabled = False
            biEditar.Enabled = False
            biDeshacer.Enabled = False
            biSalir.Enabled = True

            'cmOpciones.Enabled = False

        End If

    End Sub

    'Private Sub enableOpcionesGenerado()

    '    biGuardar.Enabled = True
    '    biEditar.Enabled = False
    '    biDeshacer.Enabled = True
    '    biSalir.Enabled = False

    'End Sub

    Private Sub ActivarNuevo()

        txtNumero.ReadOnly = True
        txtNumero.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtHoraSalida.ReadOnly = True
        txtHoraSalida.BackColor = System.Drawing.SystemColors.Control
        txtHoraRetorno.ReadOnly = True
        txtHoraRetorno.BackColor = System.Drawing.SystemColors.Control
        cmbPlaca.ReadOnly = False
        cmbPlaca.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnBuscarChofer.Enabled = True
        btnBuscarAcompanante.Enabled = True

        biGuardar.Enabled = True
        biEditar.Enabled = False
        biDeshacer.Enabled = True
        biSalir.Enabled = False

    End Sub

    Private Sub Activar()

        If iEstado = "1" Then

            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtHoraSalida.ReadOnly = True
            txtHoraSalida.BackColor = System.Drawing.SystemColors.Control
            txtHoraRetorno.ReadOnly = True
            txtHoraRetorno.BackColor = System.Drawing.SystemColors.Control
            cmbPlaca.ReadOnly = False
            cmbPlaca.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnBuscarChofer.Enabled = True
            btnBuscarAcompanante.Enabled = True

            biGuardar.Enabled = True
            biEditar.Enabled = False
            biDeshacer.Enabled = True
            biSalir.Enabled = False

            'cmOpciones.Enabled = False

        Else

            txtNumero.ReadOnly = True
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtHoraSalida.ReadOnly = True
            txtHoraSalida.BackColor = System.Drawing.SystemColors.Control
            txtHoraRetorno.ReadOnly = True
            txtHoraRetorno.BackColor = System.Drawing.SystemColors.Control
            cmbPlaca.ReadOnly = True
            cmbPlaca.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnBuscarChofer.Enabled = False
            btnBuscarAcompanante.Enabled = False

            biGuardar.Enabled = False
            biEditar.Enabled = False
            biDeshacer.Enabled = False
            biSalir.Enabled = False

            'cmOpciones.Enabled = False

        End If


        'If iEstado = "1" Then

        'Else

        'End If

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oDespachoDetService.Mostrar(toNumber(IdDespachoCab)).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()

        Try
            'Dim estadocab As String = ""
            If dgvDatos.RowCount < 1 Then
                miNuevo.Enabled = IIf(iEstado = 1, True, False)
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miConformidad.Enabled = False
            Else
                miNuevo.Enabled = IIf(iEstado = 1, True, False)
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(iEstado = 1, True, False)
                miConformidad.Enabled = IIf(iEstado = 2, True, False)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message)
        End Try

    End Sub

    Private Sub btnBuscarChofer_Click(sender As Object, e As EventArgs) Handles btnBuscarChofer.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdChofer = frm.codigo
                    txtChofer.Text = frm.descripcion
                Else
                    IdChofer = 0
                    txtChofer.Text = ""
                End If
            End If
            txtChofer.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarAcompanante_Click(sender As Object, e As EventArgs) Handles btnBuscarAcompanante.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdAcompanante = frm.codigo
                    txtAcompanante.Text = frm.descripcion
                Else
                    IdAcompanante = 0
                    txtAcompanante.Text = ""
                End If
            End If
            txtAcompanante.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos? ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New DespachoCabService.DespachoCab

                Dim empresa As New DespachoCabService.Empresa

                Dim chofer As New DespachoCabService.Persona
                Dim acompanante As New DespachoCabService.Persona
                Dim unidad As New DespachoCabService.Unidad


                registro.IdDespachoCab = IdDespachoCab
                registro.Fecha = txtFecha.Value

                chofer.IdPer = IdChofer
                registro.Chofer = chofer
                acompanante.IdPer = IIf(IdAcompanante = 0, Nothing, IdAcompanante)
                registro.Acompanante = acompanante

                registro.HoraSalida = Nothing 'txtHoraSalida.Text

                'If txtHoraRetorno.Text = "" Then
                '    registro.HoraRetorno = Nothing
                'Else
                '    registro.HoraRetorno = txtHoraRetorno.Text
                'End If
                registro.HoraRetorno = Nothing

                'unidad.Placa = cmbPlaca.Text
                'registro.Unidad = unidad

                'unidad.Placa = IIf(cmbPlaca.SelectedIndex = 0, Nothing, cmbPlaca.Value)
                unidad.Placa = cmbPlaca.Value
                registro.Unidad = unidad

                registro.Observacion = txtObservacion.Text

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa

                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL DESPACHO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As DespachoCabService.DespachoCab)
        Try
            Dim estado_process As Integer
            estado_process = oDespachoCabService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdDespachoCab = estado_process
                MsgBox("Se inserto el despacho correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL DESPACHO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As DespachoCabService.DespachoCab)
        Try
            Dim estado_process As Boolean
            estado_process = oDespachoCabService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modifico el despacho correctamente")
                Desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL DESPACHO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtChofer.Text) = "" Then
                MsgBox("Debe Ingresar el chofer", MsgBoxStyle.Information, "Información")
                txtChofer.Focus()
                Return False
                'ElseIf toBlank(txtAcompanante.Text) = "" Then
                '    MsgBox("Debe Ingresar el acompañante", MsgBoxStyle.Information, "Información")
                '    txtChofer.Focus()
                '    Return False
            ElseIf toBlank(txtHoraSalida.Text) = "" Then
                MsgBox("Debe Ingresar la hora de salida", MsgBoxStyle.Information, "Información")
                txtHoraSalida.Focus()
                Return False
            ElseIf toBlank(cmbPlaca.Text) = "" Then
                MsgBox("Debe Ingresar la placa", MsgBoxStyle.Information, "Información")
                cmbPlaca.Focus()
                Return False

                'ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                '    MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                '    txtFecha.BackColor = Color.Red
                '    txtFecha.Focus()
                '    Return False
                'ElseIf toNull(txtDescripcion.Text) = "" Then
                '    MsgBox("Debe ingresar la Descripción")
                '    txtDescripcion.Focus()
                '    Return False
                'ElseIf (rbRefrigerio.Checked = False And rbMovilidad.Checked = False) Then
                '    MsgBox("Debe Seleccionar el Tipo")
                '    rbMovilidad.Focus()
                '    Return False
                'ElseIf CStr(cmbSubRubro.Value) = "" Then
                '    MsgBox("Debe Seleccionar el Rubro")
                '    cmbSubRubro.Focus()
                '    Return False
                'ElseIf toDouble(txtMonto.Text) <= 0 Then
                '    MsgBox("El monto de la planilla debe ser mayor a CERO.")
                '    txtMonto.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditar_Click(sender As Object, e As EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub biDeshacer_Click(sender As Object, e As EventArgs) Handles biDeshacer.Click
        If MsgBox("Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        NuevoDetalle()
    End Sub

    Private Sub NuevoDetalle()
        Try

            Dim lLog As Boolean = True
            While lLog

                Dim frm As New frmDespachoDetalle
                frm.IdDespachoCab = IdDespachoCab
                frm.state_button = False
                frm.iEstado = iEstado

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdDespachoDet)
                        'Mostrar()
                        ObtenerRegistro()
                        actualizarDetalles()
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

    Private Sub actualizarDetalles()

        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdDespachoDet").Text
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdDespachoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
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

    Private Sub mostrarDetalle()

        Try
            If lblEstado.Text = "Generado" Then

                Dim frm As New frmDespachoDetalle
                frm.state_button = True
                frm.iEstado = iEstado
                frm.IdDespachoDet = dgvDatos.CurrentRow.Cells("IdDespachoDet").Text
                frm.IdDespachoCab = IdDespachoCab

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "update" Then
                        RowPossesion(dgvDatos, frm.IdDespachoDet)
                    Else
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                RowPossesion(dgvDatos, frm.IdDespachoDet)

            Else
                Dim frm As New frmDespachoDetalleC
                frm.state_button = True
                frm.iEstado = iEstado
                frm.IdDespachoDet = dgvDatos.CurrentRow.Cells("IdDespachoDet").Text
                frm.IdDespachoCab = IdDespachoCab

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                End If

                RowPossesion(dgvDatos, frm.IdDespachoDet)

            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oDespachoDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdDespachoDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdDespachoCab").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        mostrarDetalle()
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub miConformidad_Click(sender As Object, e As EventArgs) Handles miConformidad.Click

        Dim frm As New frmDespachoConformidad

        frm.IdDespachoDet = dgvDatos.CurrentRow.Cells("IdDespachoDet").Text
        frm.IdDespachoCab = IdDespachoCab

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
        End If
        RowPossesion(dgvDatos, frm.IdDespachoDet)


    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarChofer.Focus()
        End If
    End Sub

    Private Sub txtChofer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChofer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarAcompanante.Focus()
        End If
    End Sub

    Private Sub txtAcompanante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAcompanante.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbPlaca.Select()
        End If
    End Sub

    Private Sub cmbPlaca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPlaca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Select()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

End Class