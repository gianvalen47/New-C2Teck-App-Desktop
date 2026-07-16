Imports System.ServiceModel
Public Class frmReembolso_Nuevo

    '===========================Servicios====================================
    Private oReembolsoCajaService As New ReembolsoCajaService.ReembolsoCajaServiceClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True:     Modificar   False:   nuevo
    Public type_process As String                'update  insert        delete
    Public edicion As Boolean = True            'True:    Edición     False:   Vista
    Public editable As Boolean = True           'True:    Editable    False:   No Editable 
    Public iEstado As String
    Public IdReembolso As Integer
    Public iUbicacion As Integer
    Public iArea As String
    Private dtUbicacion As DataTable
    Private dtMonedas As DataTable
    Private dtDatos As DataTable
    Public CodOficina As String            'Oficina de acuerdo a caja seleccionada

    '===========================Evento Load===================================
    Private Sub frmComReembolso_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim estilo As New Estilo
        'estilo.cargaEstiloGridExt(dgvDatos)
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "REEMBOLSO Nº " + Chr(34) + txtIdReembolso.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(761, 246)
            cmbMoneda.Value = "NS"
            gbEstado.Visible = False
            gbDetalle.Visible = False
            Me.Text = "Registrar nuevo Reembolso"
            activar()
            txtIdReembolso.Text = oReembolsoCajaService.ObtenerNumero(cmbUbicacion.Value, Year(txtFecha.Value))
            txtIdReembolso.Select()
            ObtenerUbicacion()
        End If
    End Sub

    Private Sub ObtenerUbicacion()
        If oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu) Then
            cmbUbicacion.Value = oProvisionalService.ObtenerIdUbicacion(Session.sCodUsu, Session.sCodEmp)
            cmbUbicacion.Enabled = False
        Else
            cmbUbicacion.SelectedIndex = 0
            cmbUbicacion.Enabled = True
        End If
    End Sub

    Private Sub frmComReembolso_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComReembolso_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReembolsoCajaService.Close()
            oReembolsoCajaDetService.Close()
            oProvisionalService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaService.Abort()
            oReembolsoCajaDetService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaService.Abort()
            oReembolsoCajaDetService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdReembolsoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
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

            '======================================= UBICACION ===============================================
            dtUbicacion = oProvisionalService.MostrarUbicacionCaja(Session.sCodEmp).Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("NomUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        iEstado = oReembolsoCajaService.ObtenerEstado(IdReembolso)
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        miIngresar.Enabled = IIf(editable, True, False) 'Opcion ingresada el 14/11/2012
        miOrdenar.Enabled = IIf(editable, True, False)
        biEditarr.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        'biIngresar.Enabled = IIf(editable, Not edicion, False)
        biDeshacerr.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            txtIdReembolso.ReadOnly = True
            txtIdReembolso.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbUbicacion.ReadOnly = True
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtTotalNeto.ReadOnly = True
            txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else
            txtIdReembolso.ReadOnly = False
            txtIdReembolso.BackColor = System.Drawing.SystemColors.Window
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtTotalNeto.ReadOnly = True
            txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtFecha.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtIdReembolso.ReadOnly = True
        txtIdReembolso.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtTCCompra.ReadOnly = True
        txtTCCompra.BackColor = System.Drawing.SystemColors.Control
        txtTCVenta.ReadOnly = True
        txtTCVenta.BackColor = System.Drawing.SystemColors.Control
        txtTotalNeto.ReadOnly = True
        txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        txtFecha.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")                
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbUbicacion.Value) = "" Then
                MsgBox("Debe de Ingresar la Ubicación.", MsgBoxStyle.Information, "Información")            
                cmbUbicacion.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")            
                cmbMoneda.Focus()
                Return False           
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ReembolsoCajaService.ReembolsoCaja
            registro = oReembolsoCajaService.Obtener(IdReembolso)

            IdReembolso = registro.IdReembolso

            txtFecha.Value = registro.Fecha
            txtIdReembolso.Text = registro.Numero
            cmbUbicacion.Value = registro.UbicacionCaja.IdUbicacion
            lblEstado.Text = registro.Estado
            cmbMoneda.Value = registro.Moneda.CodMon
            txtTCCompra.Value = registro.TCCompra
            txtTCVenta.Value = registro.TCVenta
            txtTotalNeto.Value = registro.TotNeto
            txtObservacion.Text = registro.Observacion

            CodOficina = registro.UbicacionCaja.Oficina.CodOfi

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmReembolso_Det
                frm.state_button = False
                frm.IdReembolso = IdReembolso                
                frm.estado = "GENERADO"
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                    frm.iArea = dgvDatos.CurrentRow.Cells("CodArea").Value
                Else
                    frm.txtItem.Text = 1
                End If
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    enableOpciones()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdReembolsoDet)
                    End If
                Else
                    enableOpciones()
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdReembolsoDet").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oReembolsoCajaDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdReembolsoDet").Text), toNumber(IdReembolso), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se elimino correctamente el registro...!!!", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmReembolso_Det
            frm.state_button = True
            frm.IdReembolsoDet = dgvDatos.CurrentRow.Cells("IdReembolsoDet").Text
            frm.IdReembolso = IdReembolso
            frm.estado = oReembolsoCajaService.ObtenerEstado(IdReembolso)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                enableOpciones()
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdReembolsoDet)
                Else
                    MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdReembolsoDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdReembolsoDet").Text
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

    Private Sub Insertar(ByVal registro As ReembolsoCajaService.ReembolsoCaja)
        Try
            Dim estado_process As Integer
            estado_process = oReembolsoCajaService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdReembolso = estado_process
                iUbicacion = toNumber(cmbUbicacion.Value)
                MsgBox("Se inserto el Reembolso Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ReembolsoCajaService.ReembolsoCaja)
        Try
            Dim estado_process As Boolean
            estado_process = oReembolsoCajaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modifico el Reembolso Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oReembolsoCajaService.Borrar(IdReembolso, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oReembolsoCajaDetService.Mostrar(IdReembolso).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New ReembolsoCajaService.ReembolsoCaja
                    Dim Ubicacion As New ReembolsoCajaService.UbicacionCaja
                    Dim Moneda As New ReembolsoCajaService.Moneda                    

                    registro.IdReembolso = IdReembolso
                    registro.Numero = toBlank(txtIdReembolso.Text)
                    registro.Fecha = txtFecha.Value
                    Ubicacion.IdUbicacion = cmbUbicacion.Value
                    registro.UbicacionCaja = Ubicacion
                    Moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = Moneda
                    registro.TCCompra = txtTCCompra.Value
                    registro.TCVenta = txtTCVenta.Value
                    registro.TotNeto = txtTotalNeto.Value
                    registro.Observacion = txtObservacion.Text
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu
                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        registro.Estado = "GN"
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR REEMBOLSO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Dim estado As String
        estado = oReembolsoCajaService.ObtenerEstado(toNumber(IdReembolso))

        If state_button = True And estado = "GN" Then
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
                    codigo = dgvDatos.CurrentRow.Cells("IdReembolsoDet").Text
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

    Private Sub cmbMoneda_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMoneda.ValueChanged
        If cmbMoneda.Value = "NS" Then
            txtTCCompra.ReadOnly = True
            txtTCCompra.BackColor = System.Drawing.SystemColors.Control
            txtTCCompra.Value = 0
            txtTCVenta.ReadOnly = True
            txtTCVenta.BackColor = System.Drawing.SystemColors.Control
            txtTCVenta.Value = 0
        Else
            txtTCCompra.ReadOnly = False
            txtTCCompra.BackColor = System.Drawing.SystemColors.Window
            txtTCCompra.Value = 0
            txtTCVenta.ReadOnly = False
            txtTCVenta.BackColor = System.Drawing.SystemColors.Window
            txtTCVenta.Value = 0
        End If
    End Sub
    Private Sub txtIdReembolso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdReembolso.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFecha.Focus()
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If state_button Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                cmbMoneda.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                cmbUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub cmbUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUbicacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If cmbMoneda.Value = "NS" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtObservacion.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtTCCompra.Focus()
            End If
        End If
    End Sub

    Private Sub txtTCCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTCCompra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtTCVenta.Focus()
        End If
    End Sub

    Private Sub txtTCVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTCVenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFecha.Focus()
        End If
    End Sub

    Private Sub miIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miIngresar.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmReembolso_Gasto
                frm.IdReembolso = toNumber(IdReembolso)
                frm.NumReembolso = txtIdReembolso.Text
                frm.CodOficina = CodOficina
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
            MsgBox("Error al Ingresar Solicitud de Gastos al Reembolso: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        If state_button = False Then
            txtIdReembolso.Text = oReembolsoCajaService.ObtenerNumero(cmbUbicacion.Value, Year(txtFecha.Value))
        End If

    End Sub

    Private Sub cmbUbicacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUbicacion.ValueChanged
        If state_button = False Then
            txtIdReembolso.Text = oReembolsoCajaService.ObtenerNumero(cmbUbicacion.Value, Year(txtFecha.Value))
        End If        
    End Sub

    Private Sub miOrdenar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOrdenar.Click
        Try
            Dim frm As New frmReembolso_Item
            frm.IdReembolso = toNumber(IdReembolso)
            frm.IdReembolsoDet = dgvDatos.CurrentRow.Cells("IdReembolsoDet").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizarDetalles()
            End If

        Catch ex As Exception
            MsgBox("Error al Ordenar los Items: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class