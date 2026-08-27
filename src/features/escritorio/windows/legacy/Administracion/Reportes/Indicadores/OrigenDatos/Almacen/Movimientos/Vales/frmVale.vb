Imports System.Windows.Forms

Public Class frmVale

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private oValeMaterialDetService As New ValeMaterialDetService.ValeMaterialDetServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdVale As Integer

    Private IdPer As Integer

    Public IdLocacion As Integer
    Public IdSerieDoc As Integer
    Private IdCliente As Integer
    Private dtTipos As DataTable

    Private dtMonedas As DataTable
    Private dtAreas As DataTable
    Private TipMov As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                       cmbIdSerieDoc.KeyPress _
    '                      , txtFecDoc.KeyPress _
    '                      , txtNumJob.KeyPress _
    '                      , txtIgv.KeyPress _
    '                      , cmbCodMon.KeyPress _
    '                      , txtTipoCambio.KeyPress _
    '                      , txtTotalNeto.KeyPress _
    '                      , txtTotalIGV.KeyPress _
    '                      , txtPersonal.KeyPress _
    '                      , txtTotalPrecio.KeyPress _
    '                      , txtTotalDescuento.KeyPress _
    '                      , txtTotal.KeyPress _
    '                      , btnBuscarCliente.KeyPress _
    '                      , btnBuscarPersonal.KeyPress _
    '                      , btnModificarObservacion.KeyPress _
    '                      , cmbCodArea.KeyPress
    '    'txtObservacion.KeyPress _
    '    ', txtCliente.KeyPress _
    '    'txtNumDoc.KeyPress _
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub
    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFecDoc.Focus()
        End If
    End Sub

    'Private Sub cmbIdSeriDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIdSerieDoc.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        txtFecDoc.Focus()
    '    End If
    'End Sub
    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarJob.Focus()
        End If
    End Sub
    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbCodArea.Focus()
        End If
    End Sub
    Private Sub cmbCodArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodArea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscarPersonal.Focus()
        End If
    End Sub
    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbCodArea.Focus()

        End If
    End Sub
    Private Sub txtPersonal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbCodMon.Focus()
        End If
    End Sub
    Private Sub cmbCodMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Focus()
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmVale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                e.Handled = True
                miModificar_Click(sender, e)
            End If

        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            listaDatos()
            desactivar()
            enableOpciones()
            Me.Text = "VALE Nº " + Chr(34) + txtNumDoc.Text.ToString + Chr(34)
            dgvDatos.Select()
        Else                    'Nuevo

            gbEstado.Visible = False
            btnBuscarCliente.Enabled = True

            cmbCodMon.Value = "US"
            txtNumDoc.ReadOnly = False
            Me.Size = New System.Drawing.Size(850, 220)
            ' Me.Text = "Registrar un nuevo VALE"
            Nuevo()
            txtNumDoc.Select()
        End If
        estilo.cargaEstiloGridExt(dgvDatos)

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oValeMaterialService) = False Then
                oValeMaterialService.Close()
            End If
            If isClosed(oValeMaterialDetService) = False Then
                oValeMaterialDetService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtObservacion.KeyUp _
                          , txtNumJob.KeyUp _
                          , txtIgv.KeyUp _
                          , txtTipoCambio.KeyUp _
                          , txtCliente.KeyUp _
                          , txtFecDoc.KeyUp _
                          , txtNumDoc.KeyUp _
                          , txtTotalNeto.KeyUp _
                          , txtTotalIGV.KeyUp _
                          , txtTotalPrecio.KeyUp _
                          , txtTotalDescuento.KeyUp _
                          , txtTotal.KeyUp
        Try
            If state_Search = True Then
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
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                              cmbIdSerieDoc.ValueChanged _
                          , cmbCodMon.ValueChanged _
                          , cmbCodArea.ValueChanged
        Try
            If state_Search = True Then
                Dim campo As New Object
                If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                    campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
                End If
                campo = sender
                If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '  If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '    e.KeyChar = Chr(0)
    '  End If
    'End Sub
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
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdValeDet").Value) = codigo Then

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
            miModificar.Enabled = False
            miEliminar.Enabled = False
            btnGuardar.Enabled = False
            btnDeshacer.Enabled = False
        Else
            If state_button = True And toBlank(lblEstado.Text) = "GENERADO" Then

                btnGuardar.Enabled = False
                btnEditar.Enabled = True
                btnDeshacer.Enabled = False
                miEliminar.Enabled = True
                miModificar.Enabled = True

            ElseIf state_button = True And toBlank(lblEstado.Text) = "IMPRESO" Then

                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miActualizar.Enabled = False
                miModificar.Enabled = False

                btnGuardar.Enabled = False
                btnEditar.Enabled = False
                btnDeshacer.Enabled = False

            Else
                miNuevo.Enabled = False
                miEliminar.Enabled = False
                btnGuardar.Enabled = False
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdVale) = 0 Then
                MsgBox("Debe Ingresar el código del Vale.", MsgBoxStyle.Information, "Información")
                Return False

            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf toNumber(IdSerieDoc) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Vale.", MsgBoxStyle.Information, "Información")
                cmbIdSerieDoc.BackColor = Color.Red
                cmbIdSerieDoc.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toNumber(cmbCodArea.Value) = 0 Then
                MsgBox("Debe Ingresar el Área.", MsgBoxStyle.Information, "Información")
                cmbCodArea.BackColor = Color.Red
                cmbCodArea.Focus()
                Return False
            ElseIf toNumber(IdPer) = 0 Then
                MsgBox("Debe Ingresar el nombre del Empleado.", MsgBoxStyle.Information, "Información")
                txtPersonal.BackColor = Color.Red
                btnBuscarPersonal.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de Ingresar el tipo de Moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf cmbCodMon.Value <> "NS" And toDouble(txtTipoCambio.Text) <= 0 Then
                MsgBox("Tipo de Cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf state_button = False And oValeMaterialService.Buscar(IdSerieDoc, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " del Vale ya existe...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf state_button = True And oValeMaterialService.Estado(IdVale) <> "GENERADO" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As ValeMaterialService.ValeMaterial)
        Try
            Dim estado_process As Integer
            estado_process = oValeMaterialService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdVale = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ValeMaterialService.ValeMaterial)
        Try
            Dim estado_process As Boolean
            estado_process = oValeMaterialService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = Windows.Forms.DialogResult.OK
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oValeMaterialService.Borrar(IdVale)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As ValeMaterialService.ValeMaterial
            registro = oValeMaterialService.MostrarPorId(IdVale)

            IdVale = registro.IdVale
            IdLocacion = registro.Locacion.IdLocacion
            'llenarComboTipos()

            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtNumJob.Text = registro.NumJob
            IdPer = registro.Persona.IdPer
            txtPersonal.Text = registro.Persona.ApeNom
            txtIgv.Text = registro.Igv
            txtObservacion.Text = toBlank(registro.Observacion)
            state_Search = True
            cmbIdSerieDoc.Value = registro.SerieDocumento.IdSerieDoc
            IdSerieDoc = registro.SerieDocumento.IdSerieDoc
            cmbCodMon.Value = registro.Moneda.CodMon
            cmbCodArea.Value = registro.Area.CodArea
            lblEstado.Text = registro.Estado
            TipMov = registro.TipMov


        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try

            'dtTipos = oMaestroService.MostrarSerieDocumento(IdLocacion, 3, "").Tables(0)
            'cmbIdSerieDoc.DataSource = dtTipos
            'cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarComboTipos()
        '======================================= TIPOS  ================================================
        dtTipos = oMaestroService.MostrarSerieDocumento(IdLocacion, 3, "").Tables(0)
        cmbIdSerieDoc.DataSource = dtTipos
        cmbIdSerieDoc.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.ValueMember = dtTipos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
        cmbIdSerieDoc.SelectedIndex = 0
        dtTipos = Nothing
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oValeMaterialDetService.Mostrar(toNumber(IdVale)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ValeMaterial", "TotBruto", "IdVale", IdVale)
            txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ValeMaterial", "TotDscto", "IdVale", IdVale)
            txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ValeMaterial", "TotVenta", "IdVale", IdVale)
            txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ValeMaterial", "TotIgv", "IdVale", IdVale)
            txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Almacen.ValeMaterial", "TotNeto", "IdVale", IdVale)
            lblTotal.Text = "SUB TOTALES"
            lbltotalIGV.Text = "IGV"
            lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Almacen.ValeMaterial", "CodMon", "IdVale", IdVale)) + ")"

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmVale_AgregarDetalle
                frm.state_button = False
                frm.IdVale = IdVale
                frm.IdLocacion = IdLocacion
                frm.TipMov = TipMov
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdValeDet)
                    End If
                Else
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oValeMaterialDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdValeDet").Text), IdVale)
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
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmVale_AgregarDetalle
            frm.state_button = True
            frm.IdValeDet = dgvDatos.CurrentRow.Cells("IdValeDet").Text
            frm.IdVale = IdVale
            frm.IdLocacion = IdLocacion
            frm.TipMov = TipMov
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdValeDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
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
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdValeDet").Text
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

    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        btnBuscarPersonal.Enabled = True
        btnBuscarCliente.Enabled = True
        btnBuscarJob.Enabled = True
        btnModificarObservacion.Enabled = True
        cmbCodArea.ReadOnly = False

        txtFecDoc.ReadOnly = True

    End Sub

    Private Sub desactivar()

        gbEstado.Visible = True
        btnBuscarJob.Enabled = False
        'cmbIdSerieDoc.ReadOnly = True
        'cmbIdSerieDoc.BackColor = System.Drawing.SystemColors.Control
        cmbCodArea.ReadOnly = True
        cmbCodArea.BackColor = System.Drawing.SystemColors.Control
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True

        txtObservacion.ReadOnly = True
        btnBuscarPersonal.Enabled = False
        btnModificarObservacion.Enabled = False
        btnBuscarCliente.Enabled = False
        btnBuscarJob.Enabled = False
        cmbCodArea.ReadOnly = True
        cmbCodArea.BackColor = System.Drawing.SystemColors.Control
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================


    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            txtCliente.Select()
        End If
        txtCliente.Select()
    End Sub



    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True And (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN") Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        If state_Search = True Then
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
        End If
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click

        Dim frm As New frmBuscarJob
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            IdCliente = frm.IdCliente
            txtCliente.Text = frm.DesCli
        End If
        txtNumJob.Select()
    End Sub
    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmVale_ModificarObservacion
        frm.state_button = state_button
        frm.IdVale = IdVale
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
    End Sub
    'Private Sub cmbIdSerieDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdSerieDoc.ValueChanged
    '      If state_button = False Then

    '          txtNumDoc.ReadOnly = False
    '          txtNumDoc.TabStop = True
    '          txtNumDoc.Text = oValeMaterialService.SugerirNumero(cmbIdSerieDoc.Value)
    '      End If
    'End Sub
    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
    End Sub
    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        Dim datoAreas As String
        datoAreas = cmbCodArea.Value
        Dim frm As New frmBuscarPersonal
        frm.codigoArea = datoAreas
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPersonal.Text = frm.descripcion
            txtPersonal.BackColor = System.Drawing.SystemColors.Control
            IdPer = frm.codigo
        End If
        txtPersonal.Select()
    End Sub

    Private Sub Nuevo()
        Try

            llenarComboTipos()
            txtNumDoc.Text = oValeMaterialService.SugerirNumero(cmbIdSerieDoc.Value)
            txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion))
            'cmbCodMon.SelectedIndex = 2
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Nuevo Registro")
        End Try

    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New ValeMaterialService.ValeMaterial
            Dim locacion As New ValeMaterialService.Locacion
            Dim cliente As New ValeMaterialService.Cliente
            Dim moneda As New ValeMaterialService.Moneda
            Dim serieDocumento As New ValeMaterialService.SerieDocumento
            Dim area As New ValeMaterialService.Area
            Dim personal As New ValeMaterialService.Persona

            registro.IdVale = IdVale
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            '---
            serieDocumento.IdSerieDoc = IdSerieDoc
            registro.SerieDocumento = serieDocumento
            registro.NumDoc = txtNumDoc.Text
            registro.FecDoc = txtFecDoc.Text
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.NumJob = toNull(txtNumJob.Text)
            area.CodArea = cmbCodArea.Value
            registro.Area = area
            personal.IdPer = IdPer
            registro.Persona = personal
            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()

    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar la Cabecera del Vale."
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en el Vale."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en la Cabecera del Vale."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Vale."
    End Sub

    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle del Vale."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Vale."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave, _
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave, _
                                   miNuevo.MouseLeave, miModificar.MouseLeave, _
                                   miEliminar.MouseLeave, miActualizar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub


End Class
