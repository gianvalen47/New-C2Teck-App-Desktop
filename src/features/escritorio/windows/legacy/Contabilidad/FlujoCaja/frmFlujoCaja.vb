Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmFlujoCaja

    '===========================Servicios====================================================
    Private oFlujoCajaCabService As New FlujoCajaCabService.FlujoCajaCabServiceClient
    Private oFlujoCajaDetService As New FlujoCajaDetService.FlujoCajaDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public IdFlujoCaja As Integer
    Public idEstado As Integer
    Private dtMoneda As DataTable
    ' Private dtEstados As DataTable
    Private dtTipoActivo As DataTable
    Public dtDatos As DataTable
    Public dtDatosObservaciones As DataTable

    Private Sub frmActivoFijo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDetalles)
        dgDetalles.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgDetalles.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
        llenarcombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            Desactivar()
            gbEstado.Visible = True
            'gbDetalles.Visible = True

            actualizarDetalles()

            Me.Text = "Flujo de Caja"
            dgvDatos.Select()

        Else                          'Nuevo
            'Me.Size = New System.Drawing.Size(659, 400)
            gbEstado.Visible = False
            'gbDetalles.Visible = False

            txtMesRegistro.Text = Format(Month(Today), "00")
            txtPeriodo.Value = Today.Year

            Me.Text = "Registrar nuevo Flujo de Caja"
            Activar()
            txtIdFlujoCaja.Text = IdFlujoCaja
            txtIdFlujoCaja.Focus()
        End If
        If idEstado <> 1 Then
            biEditar.Enabled = False
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   txtIdFlujoCaja.KeyPress _
 _
 _
 _
 _
 _
 _
                 , cmbMoneda.KeyPress _
 _
 _
 _
 _
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
            oFlujoCajaCabService.Close()
            oFlujoCajaDetService.Close()
            oMaestroService.close()
        Catch ex As TimeoutException
            oFlujoCajaCabService.Abort()
            oFlujoCajaDetService.Abort()
            oMaestroService.abort()
        Catch ex As CommunicationException
            oFlujoCajaCabService.Abort()
            oFlujoCajaDetService.Abort()
            oMaestroService.abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("IdTipo").Value) = codigo Then
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

            '===================================== MONEDAS ===============================================
            dtMoneda = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMoneda
            cmbMoneda.DropDownList.DataMember = dtMoneda.Columns("DesMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMoneda.Columns("DesMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMoneda.Columns("DesMon").ToString
            cmbMoneda.SelectedIndex = 0
            dtMoneda = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgDetalles.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)

        biEditar.Enabled = IIf(idEstado <> 1, False, IIf(editable, Not edicion, False))
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub



    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetalles.SelectionChanged
        enableOpciones()
    End Sub


    Private Sub dgdetalles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalles.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Protected Sub Activar()
        Try
            If state_button Then   'Actualizar
                'txtIdFlujoCaja.ReadOnly = True
                'txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Control

                txtPeriodo.ReadOnly = True
                txtPeriodo.BackColor = System.Drawing.SystemColors.Control

                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window

                txtMesRegistro.ReadOnly = True
                txtMesRegistro.BackColor = System.Drawing.SystemColors.Control

                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                txtSaldoInicio.ReadOnly = False
                txtSaldoInicio.BackColor = System.Drawing.SystemColors.Window

                edicion = True
                enableOpciones()

                txtObservacion.Focus()

            Else                       'Nuevo
                'txtIdFlujoCaja.ReadOnly = False
                'txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Window

                txtPeriodo.ReadOnly = False
                txtPeriodo.BackColor = System.Drawing.SystemColors.Window

                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window

                txtMesRegistro.ReadOnly = False
                txtMesRegistro.BackColor = System.Drawing.SystemColors.Window

                txtSaldoInicio.ReadOnly = False
                txtSaldoInicio.BackColor = System.Drawing.SystemColors.Window

                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                edicion = True
                enableOpciones()

                txtIdFlujoCaja.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try

            'txtIdFlujoCaja.ReadOnly = True
            'txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Control

            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control

            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control

            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control

            txtSaldoInicio.ReadOnly = True
            txtSaldoInicio.BackColor = System.Drawing.SystemColors.Control

            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

            edicion = False
            enableOpciones()
            txtIdFlujoCaja.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toBlank(txtIdFlujoCaja.Text) = "" Then
            '    MsgBox("Debe ingresar el código del Flujo", MsgBoxStyle.Information, "Información")
            '    txtIdFlujoCaja.Focus()
            '    Return False
            If toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe ingresar la descripción del Flujo", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False

            ElseIf toNull(txtPeriodo.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio", MsgBoxStyle.Information, "Información")
                txtPeriodo.Focus()
                Return False
            ElseIf toNull(txtMesRegistro.Text) = "" Then
                MsgBox("Debe ingresar la Fecha Final", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False

            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
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
            If dgDetalles.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgDetalles.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgDetalles.CurrentRow.Cells(0).Text = Nothing Then
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

            Dim registro As FlujoCajaCabService.FlujoCajaCab
            registro = oFlujoCajaCabService.Obtener(IdFlujoCaja)

            IdFlujoCaja = registro.IdFlujoCaja
            txtIdFlujoCaja.Text = registro.IdFlujoCaja
            lblEstado.Text = registro.EstadoFlujoCaja.DesEstado

            txtPeriodo.Text = registro.Periodo

            cmbMoneda.Value = registro.Moneda.CodMon

            txtMesRegistro.Text = registro.Mes

            txtSaldoInicio.Text = registro.SaldoInicio
            txtObservacion.Text = registro.Observacion

            txtIngresos.Text = registro.TotalIngreso
            txtEgresos.Text = registro.TotalSalida
            txtSaldoFinal.Text = registro.TotalSaldo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmFlujoCajaDetalle
                frm.IdFlujoCaja = toBlank(txtIdFlujoCaja.Text)
                frm.IdTipo = idEstado
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
                estado_process = oFlujoCajaDetService.Borrar(toNumber(dgDetalles.CurrentRow.Cells("IdFlujoCaja").Value), toNumber(dgDetalles.CurrentRow.Cells("IdTipo").Value), Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ' ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmFlujoCajaDetalle
            frm.state_button = True
            frm.IdFlujoCaja = dgDetalles.CurrentRow.Cells("IdFlujoCaja").Text
            frm.IdTipo = dgDetalles.CurrentRow.Cells("IdTipo").Text
            frm.IdEstado = idEstado
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizarDetalles()
                ObtenerRegistro()
            End If
            RowPossesion(dgDetalles, frm.IdTipo)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgDetalles.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgDetalles.CurrentRow.Cells("IdTipo").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgDetalles.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgDetalles, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Protected Sub Insertar(ByVal registro As FlujoCajaCabService.FlujoCajaCab)
        Try
            Dim estado_process As Boolean
            estado_process = oFlujoCajaCabService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                IdFlujoCaja = txtIdFlujoCaja.Text
                MsgBox("Se insertó el Activo Fijo Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As FlujoCajaCabService.FlujoCajaCab)
        Try
            Dim estado_process As Boolean
            estado_process = oFlujoCajaCabService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Flujo de Caja Correctamente")
                Desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR FLUJO DE CAJA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub listaDatos()
        Try
            dtDatos = oFlujoCajaDetService.Mostrar(IdFlujoCaja).Tables(0)
            dgDetalles.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New FlujoCajaCabService.FlujoCajaCab

                Dim empresa As New FlujoCajaCabService.Empresa
                Dim moneda As New FlujoCajaCabService.Moneda
                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.IdFlujoCaja = toNumber(txtIdFlujoCaja.Text)

                registro.Periodo = txtPeriodo.Text
                registro.Mes = txtMesRegistro.Text

                registro.Observacion = toBlank(txtObservacion.Text)

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa

                registro.SaldoInicio = txtSaldoInicio.Text

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
            dgDetalles.Focus()
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
                If IsDBNull(dgDetalles.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgDetalles.CurrentRow.Cells("IdTipo").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgDetalles.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgDetalles, codigo)
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

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgDetalles.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub



End Class