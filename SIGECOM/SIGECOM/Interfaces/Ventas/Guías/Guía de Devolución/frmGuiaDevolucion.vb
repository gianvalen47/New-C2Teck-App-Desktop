Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmGuiaDevolucion

  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Public edicion As Boolean                   'True: Edición      False: Vista
  Public editable As Boolean                  'True: Editable     False: No Editable
  Private oMaestroService As New MaestroService.MaestroClient
  Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
  Private oGuiaDevolucionDetService As New GuiaDevolucionDetService.GuiaDevolucionDetServiceClient
  Private oContactoService As New ContactoService.ContactoServiceClient
  Private dtDatos As DataTable
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Public IdGuiaDev As Integer
  Public IdLocacion As Integer
  Private IdCliente As Integer
  Private item As Integer
  Private cantidad As Integer

    Private dtMonedas As DataTable

    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnModificarObservacion.Enabled = True Then
                btnModificarObservacion_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub
   
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtFecDoc.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtCliente.KeyPress _
                          , txtNumDoc.KeyPress _
                          , txtNumJob.KeyPress _
                        , txtIdLocCli.KeyPress _
                        , txtCodMot.KeyPress _
                        , txtCodPag.KeyPress
        ', txtObservacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGuiaDevolucion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        txtFecDoc.Value = Session.sFecha
        desactivar()
        llenarCombos()
        ObtenerRegistro()
        listaDatos()
        enableOpciones()
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.Text = "GUÍA DE DEVOLUCIÓN Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        '  If isClosed(oMaestroService) = False Then
        '    oMaestroService.Close()
        '  End If
        '  If isClosed(oGuiaDevolucionService) = False Then
        '    oGuiaDevolucionService.Close()
        '  End If
        '  If isClosed(oGuiaDevolucionDetService) = False Then
        '    oGuiaDevolucionDetService.Close()
        '  End If
        'Catch ex As Exception
        '  MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        '    End Try

        Try
            oMaestroService.Close()
            oGuiaDevolucionService.Close()
            oGuiaDevolucionDetService.Close()
            oContactoService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
            oContactoService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
            oContactoService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)

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
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdGuiaDevDet").Value) = codigo Then

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
        'cmOpciones.Enabled = IIf(edicion And editable, True, False)
        cmOpciones.Enabled = IIf(editable, Not edicion, False)
        miEliminar.Enabled = IIf(dgvDatos.RowCount < 1, False, True)
        If oGuiaDevolucionService.Estado(IdGuiaDev) <> "GENERADO" Then
            dgvDatos.RootTable.Columns("CanMer").EditType = Janus.Windows.GridEX.EditType.NoEdit
        Else
            dgvDatos.RootTable.Columns("CanMer").EditType = Janus.Windows.GridEX.EditType.TextBox
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdGuiaDev) = 0 Then
                MsgBox("Debe Ingresar el código de la guía.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf state_button = True And oGuiaDevolucionService.Estado(IdGuiaDev) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub editar()
        activar()
    End Sub
    Private Sub guardar()
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New GuiaDevolucionService.GuiaDevolucion

            registro.IdGuiaDev = IdGuiaDev
            registro.FecDoc = txtFecDoc.Text
            registro.Observacion = toBlank(txtObservacion.Text)
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp


            If state_button Then        'Modificar
                Modificar(registro)
            End If
        End If
    End Sub
    Private Sub deshacer()
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
    Private Sub salir()
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub NuevoDetalle()
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            Try
                Dim frm As New frmGuiaDevolucion_AgregarDetalles
                frm.IdGuiaDev = IdGuiaDev
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                End If
            Catch ex As Exception
                MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub eliminarDetalle()
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean

                    estado_process = oGuiaDevolucionDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdGuiaDevDet").Text), IdGuiaDev)
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
        End If
    End Sub
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGuiaDevDet").Text
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

    Private Sub Modificar(ByVal registro As GuiaDevolucionService.GuiaDevolucion)
        Try
            Dim estado_process As Boolean
            estado_process = oGuiaDevolucionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                desactivar()
                ObtenerRegistro()
                ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As GuiaDevolucionService.GuiaDevolucion
            registro = oGuiaDevolucionService.MostrarPorId(IdGuiaDev)

            IdGuiaDev = registro.IdGuiaDev
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
            txtFecDoc.Text = registro.FecDoc
            txtNumDoc.Text = registro.NumDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtIdLocCli.Text = registro.LocacionCliente.Nombre
            txtCodMot.Text = registro.Motivos.DesMot
            txtNumJob.Text = registro.NumJob
            cmbCodMon.Value = registro.Moneda.CodMon
            txtIgv.Text = registro.Igv.ToString + " %"
            txtObservacion.Text = toBlank(registro.Observacion)
            lblEstado.Text = registro.Estado
            txtVendedor.Text = registro.Persona.ApeNom
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oGuiaDevolucionDetService.Mostrar(toNumber(IdGuiaDev)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucion", "TotBruto", "IdGuiaDev", IdGuiaDev)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucion", "TotDscto", "IdGuiaDev", IdGuiaDev)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucion", "TotVenta", "IdGuiaDev", IdGuiaDev)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucion", "TotIgv", "IdGuiaDev", IdGuiaDev)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucion", "TotNeto", "IdGuiaDev", IdGuiaDev)
            lblTotal.Text = "SUB TOTALES   "
            lbltotalIGV.Text = "IGV   "
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucion", "CodMon", "IdGuiaDev", IdGuiaDev)) + ")   "

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [LISTA_DATOS]: " + ex.Message, MsgBoxStyle.Exclamation)
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
    Private Sub ModificarItem(ByVal fila As Integer)
        Try
            oGuiaDevolucionDetService.ActualizarDevolucion(dgvDatos.GetRow(fila).Cells(0).Text, _
                                                               IdGuiaDev, _
                                                               dgvDatos.GetRow(fila).Cells("Item").Text, _
                                                               dgvDatos.GetRow(fila).Cells("CanMer").Text)
            listaDatos()
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        edicion = True
        biEditar.Enabled = False
        biGrabar.Enabled = True
        biDeshacer.Enabled = True
        biSalir.Enabled = False
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnModificarObservacion.Enabled = True
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        dgvDatos.RootTable.Columns(1).EditType = Janus.Windows.GridEX.EditType.TextBox
        dgvDatos.RootTable.Columns(2).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(3).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(4).EditType = Janus.Windows.GridEX.EditType.TextBox
        dgvDatos.RootTable.Columns(5).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(6).EditType = Janus.Windows.GridEX.EditType.NoEdit
        dgvDatos.RootTable.Columns(7).EditType = Janus.Windows.GridEX.EditType.NoEdit
        txtObservacion.Select()
        enableOpciones()
    End Sub
    Private Sub desactivar()
        edicion = False
        biEditar.Enabled = editable
        biGrabar.Enabled = False
        biDeshacer.Enabled = False
        biSalir.Enabled = True
        btnModificarObservacion.Enabled = False
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        enableOpciones()
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text)), "#0.000")
    End Sub
    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmGuiaDevolucion_ModificarObservacion
        frm.state_button = state_button
        frm.IdGuiaDev = IdGuiaDev
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        frm.txtObservacion.ReadOnly = IIf(edicion And editable, False, True)
        'frm.btnAceptar.Enabled = IIf(edicion And editable, False, True)
        'frm.btnAceptar.Visible = IIf(edicion And editable, False, True)
        frm.btnGuardar.Enabled = IIf(edicion And editable, True, False)
        frm.btnGuardar.Visible = IIf(edicion And editable, True, False)
        frm.btnCancelar.Enabled = IIf(edicion And editable, True, False)
        frm.btnCancelar.Visible = IIf(edicion And editable, True, False)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Focus()
    End Sub
    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text)), "#0.000")

    End Sub
    Private Sub dgvDatos_CellEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellEditCanceled
        If dgvDatos.RowCount < 1 Then
        ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
        ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
        Else
            dgvDatos.CurrentRow.Cells("Item").Text = toNumber(oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucionDet", "Item", "IdGuiaDevDet", dgvDatos.CurrentRow.Cells("IdGuiaDevDet").Text))
            dgvDatos.CurrentRow.Cells("CanMer").Text = toNumber(oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucionDet", "CanMer", "IdGuiaDevDet", dgvDatos.CurrentRow.Cells("IdGuiaDevDet").Text))
        End If
    End Sub
    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        item = toNumber(oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucionDet", "Item", "IdGuiaDevDet", dgvDatos.CurrentRow.Cells("IdGuiaDevDet").Text))
        cantidad = toNumber(oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaDevolucionDet", "CanMer", "IdGuiaDevDet", dgvDatos.CurrentRow.Cells("IdGuiaDevDet").Text))
        If toNumber(IdGuiaDev) = 0 Then
            MsgBox("Debe Ingresar el código de la guía.", MsgBoxStyle.Information, "Información")
            actualizar()
        ElseIf toNumber(dgvDatos.CurrentRow.Cells("Item").Text) <= 0 Then
            MsgBox("El número del item debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
            actualizar()
        ElseIf toNumber(dgvDatos.CurrentRow.Cells("CanMer").Text) <= 0 Then
            MsgBox("La cantidad debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
            actualizar()
        ElseIf toNumber(dgvDatos.CurrentRow.Cells("CanMer").Text) > cantidad Then
            MsgBox("La cantidad de puede ser mayor a " + cantidad.ToString + ".", MsgBoxStyle.Information, "Información")
            actualizar()
        Else
            ModificarItem(dgvDatos.CurrentRow.RowIndex)
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        editar()
    End Sub
    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        guardar()
    End Sub
    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        deshacer()
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        NuevoDetalle()
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        eliminarDetalle()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biEditar.MouseLeave, biGrabar.MouseLeave, biDeshacer.MouseLeave, biSalir.MouseLeave, _
                                miNuevo.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.MouseEnter
        sslError.Text = "Grabar los cambios hechos en la Guia de Devoluciòn."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los cambios hechos en la Guia de Devoluciòn."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Guia de Devoluciòn."
    End Sub

    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Guia de Devoluciòn."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle de la Guia de Devoluciòn."
    End Sub

    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario Guia de Devoluciòn."
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.None Then
            txtNumDoc.Select()
        End If
    End Sub

    Private Sub UiGroupBox2_Click(sender As Object, e As EventArgs) Handles UiGroupBox2.Click

    End Sub

    'Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
    '    'If Not (Char.IsDigit(e.KeyChar)) Then
    '    '    e.Handled = True
    '    'End If

    '    If Asc(e.KeyChar) = 3 Then
    '        e.Handled = False
    '    Else
    '        e.Handled = Not (e.KeyChar = "")
    '    End If
    'End Sub
End Class
