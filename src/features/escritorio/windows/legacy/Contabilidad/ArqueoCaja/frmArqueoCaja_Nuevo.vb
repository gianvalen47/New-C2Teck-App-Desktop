Imports System.ServiceModel
Public Class frmArqueoCaja_Nuevo

    '===========================Servicios====================================
    Private oArqueoCajaService As New ArqueoCajaService.ArqueoCajaServiceClient
    Private oArqueoCajaDetService As New ArqueoCajaDetService.ArqueoCajaDetServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True:     Modificar   False:   nuevo
    Public type_process As String                'update  insert        delete
    Public edicion As Boolean = True            'True:    Edición      False:   Vista
    Public editable As Boolean = True           'True:    Editable     False:   No Editable 
    Public iEstado As String
    Public IdArqueo As Integer
    Public iUbicacion As Integer
    Private dtUbicacion As DataTable
    Private dtDatos As DataTable

    '===========================Evento Load===================================
    Private Sub frmArqueoCaja_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "ARQUEO DE CAJA Nº " + Chr(34) + txtIdArqueo.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            If editable And Not edicion Then
                dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
            End If
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(537, 242)
            gbEstado.Visible = False
            gbDetalle.Visible = False
            Me.Text = "Registrar nuevo Arqueo de Caja"
            activar()
            txtFecha.Select()
        End If

    End Sub

    Private Sub frmArqueoCaja_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmArqueoCaja_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oArqueoCajaService.Close()
            oArqueoCajaDetService.Close()
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oArqueoCajaService.Abort()
            oArqueoCajaDetService.Abort()
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oArqueoCajaService.Abort()
            oArqueoCajaDetService.Abort()
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtObservacion.KeyPress _
                    , cmbUbicacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdArqueoDet").Value) = codigo Then
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
        iEstado = oArqueoCajaService.ObtenerEstado(IdArqueo)
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            biGenerar.Enabled = IIf(editable, Not edicion, False)
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
            biGenerar.Enabled = False
        End If
        miNuevo.Enabled = IIf(editable, True, False)
        biEditarr.Enabled = IIf(editable, Not edicion, False)        
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            txtIdArqueo.ReadOnly = True
            txtIdArqueo.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbUbicacion.ReadOnly = True
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtFecha.Focus()
        Else
            txtIdArqueo.ReadOnly = True
            txtIdArqueo.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtFecha.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtIdArqueo.ReadOnly = True
        txtIdArqueo.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
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
                'ElseIf toBlank(cmbMoneda.Value) = "" Then
                '    MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                '    cmbMoneda.Focus()
                '    Return False
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
            Dim registro As ArqueoCajaService.ArqueoCaja
            registro = oArqueoCajaService.Obtener(IdArqueo)

            IdArqueo = registro.IdArqueo
            txtIdArqueo.Text = registro.IdArqueo
            txtFecha.Value = registro.Fecha
            cmbUbicacion.Value = registro.UbicacionCaja.IdUbicacion
            txtObservacion.Text = registro.Observacion
            lblEstado.Text = registro.Estado            
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmArqueoCaja_Det
                frm.state_button = False
                frm.IdArqueo = IdArqueo
                frm.estado = "GENERADO"                
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    enableOpciones()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdArqueoDet)
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

    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        Dim registro As New ArqueoCajaDetService.ArqueoCajaDet
        Dim Arqueo As New ArqueoCajaDetService.ArqueoCaja
        Dim Concepto As New ArqueoCajaDetService.ConceptoArqueo
        Dim Moneda As New ArqueoCajaDetService.Moneda

        registro.IdArqueoDet = dgvDatos.CurrentRow.Cells("IdArqueoDet").Value
        Arqueo.IdArqueo = dgvDatos.CurrentRow.Cells("IdArqueo").Value
        registro.ArqueoCaja = Arqueo
        Concepto.IdConcepto = dgvDatos.CurrentRow.Cells("IdConcepto").Value
        registro.ConceptoArqueo = Concepto
        Moneda.CodMon = dgvDatos.CurrentRow.Cells("CodMon").Value
        registro.Moneda = Moneda
        registro.Monto = dgvDatos.CurrentRow.Cells("Monto").Value
        registro.Descripcion = toNull(dgvDatos.CurrentRow.Cells("Descripcion").Text)
        registro.CodUsu = Session.sCodUsu
        registro.NomPc = Session.sNomPc
        registro.DirIp = Session.sDirIp

        ModificarMontoDetalle(registro)

    End Sub

    Private Sub ModificarMontoDetalle(ByVal registro As ArqueoCajaDetService.ArqueoCajaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oArqueoCajaDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'MsgBox("Se modifico Monto")
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdArqueoDet").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oArqueoCajaDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdArqueoDet").Text), toNumber(txtIdArqueo.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
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

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmArqueoCaja_Det
            frm.state_button = True
            frm.IdArqueoDet = dgvDatos.CurrentRow.Cells("IdArqueoDet").Text
            frm.IdArqueo = IdArqueo
            frm.estado = oArqueoCajaService.ObtenerEstado(IdArqueo)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                enableOpciones()
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdArqueoDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdArqueoDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdArqueoDet").Text
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

    Private Sub Insertar(ByVal registro As ArqueoCajaService.ArqueoCaja)
        Try
            Dim estado_process As Integer
            estado_process = oArqueoCajaService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdArqueo = estado_process
                iUbicacion = toNumber(cmbUbicacion.Value)
                MsgBox("Se insertó el Arqueo de Caja Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ARQUEO DE CAJA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ArqueoCajaService.ArqueoCaja)
        Try
            Dim estado_process As Boolean
            estado_process = oArqueoCajaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Arqueo de Caja Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ARQUEO DE CAJA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oArqueoCajaService.Borrar(IdArqueo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR ARQUEO DE CAJA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oArqueoCajaDetService.Mostrar(IdArqueo).Tables(0)            
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New ArqueoCajaService.ArqueoCaja
                    Dim Ubicacion As New ArqueoCajaService.UbicacionCaja

                    registro.IdArqueo = IdArqueo
                    registro.Fecha = txtFecha.Value
                    registro.Observacion = txtObservacion.Text
                    Ubicacion.IdUbicacion = cmbUbicacion.Value
                    registro.UbicacionCaja = Ubicacion
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
            MsgBox("ERROR AL GUARDAR ARQUEO DE CAJA : " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
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

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Dim estado As String
        estado = oArqueoCajaService.ObtenerEstado(toNumber(txtIdArqueo.Text))
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
                    codigo = dgvDatos.CurrentRow.Cells("IdArqueoDet").Text
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

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If state_button Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtObservacion.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                cmbUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub biGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerar.Click
        Try
            If MsgBox("¿Está seguro de INGRESAR Plantilla al Arqueo N° " & txtIdArqueo.Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oArqueoCajaDetService.InsertarPlantilla(toNumber(txtIdArqueo.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se Ingresó la plantilla al Arqueo correctamente ")
                    ObtenerRegistro()
                    actualizar()
                    biGenerar.Enabled = False
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class