Public Class frmActualizarVendedor

    Private oMaestroService As New MaestroService.MaestroClient
    Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtTipos As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtVendedor As DataTable
    Private dtDatos As DataTable
    Private IdVenta As Integer

    Private Sub frmActualizarVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCliente.KeyPress _
            , txtFecha.KeyPress _
            , txtNumDoc.KeyPress _
            , cmbIdLocacion.KeyPress _
            , cmbOficinas.KeyPress _
            , cmbTipo.KeyPress _
            , cmbVendedor.KeyPress
        ' , cmbTipFac.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmActualizarVendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oAprobarVentaService) = False Then
                oAprobarVentaService.Close()
            End If
            If isClosed(oPersonaService) = False Then
                oPersonaService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub frmActualizarVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActualizarVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 79)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        enableOpciones()
    End Sub
    Private Sub enableOpciones()
        biModificar.Enabled = True
        'biDeshacer.Enabled = True
        biGuardar.Enabled = False
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS  ================================================
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipos.Rows.Add(New Object() {1, "Guía de Remisión"})
            dtTipos.Rows.Add(New Object() {2, "Factura"})
            dtTipos.Rows.Add(New Object() {3, "Boleta"})
            dtTipos.Rows.Add(New Object() {4, "Guía de Devolución"})
            dtTipos.Rows.Add(New Object() {5, "Nota de Crédito"})

            cmbTipo.DataSource = dtTipos
            cmbTipo.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            cmbTipo.SelectedIndex = 0
            dtTipos = Nothing

            '======================================= Oficinas ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedores(Session.sCodEmp).Tables(0)
            'dtVendedor.Rows.InsertAt(getRowTodos(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            dtVendedor = Nothing
            '======================================= TIPOS DE FACTURAS ================================================
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            dtTipos.Rows.Add(New Object() {"1", "Crédito"})
            dtTipos.Rows.Add(New Object() {"2", "Contado"})

            cmbTipFac.DataSource = dtTipos
            cmbTipFac.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.SelectedIndex = 1
            dtTipos = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            Dim registro As New AprobarVentaService.DocumentoVenta
            registro = oAprobarVentaService.ObtenerDocumentoVenta(cmbIdLocacion.Value, cmbTipo.Value, IIf(gbTipFac.Enabled = False, "", cmbTipFac.Value), txtNumDoc.Text)

            txtFecha.Text = registro.FecDoc
            txtCliente.Text = registro.Cliente.DesCli
            cmbVendedor.Value = registro.Persona.IdPer
            IdVenta = registro.IdVenta
            txtTotBruto.Text = Format(registro.TotBruto, "##,##0.00")
            txtDescuento.Text = Format(registro.TotDscto, "##,##0.00")
            txtTotImpuesto.Text = Format(registro.TotIgv, "##,##0.00")
            txtTotDocumento.Text = Format(registro.TotNeto, "##,##0.00")

            dtDatos = oAprobarVentaService.MostrarDetalles(IdVenta, cmbTipo.Value).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub Limpiar()
        txtNumDoc.Clear()
        txtFecha.Clear()
        txtCliente.Clear()
        txtTotBruto.Clear()
        txtTotDocumento.Clear()
        txtTotImpuesto.Clear()
        txtDescuento.Clear()
        cbOficina.Checked = False
        If dgvDatos.RowCount > 0 Then
            dtDatos.Clear()
        End If
    End Sub
    Private Sub activar()
        cmbVendedor.ReadOnly = False
        cmbVendedor.Select()
        biGuardar.Enabled = True
        ' biDeshacer.Enabled = True
        biModificar.Enabled = False
        cbOficina.Enabled = True
    End Sub
    Private Sub desactivar()
        cmbVendedor.ReadOnly = True
        biGuardar.Enabled = False
        'biDeshacer.Enabled = False
        biModificar.Enabled = True
        cbOficina.Enabled = False
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe Ingresar el código del Documento. ", MsgBoxStyle.Information, "Información")
                cmbVendedor.BackColor = Color.Red
                txtNumDoc.Select()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar número del nuevo documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(cmbVendedor.Value) = 0 And cbOficina.Checked = False Then
                MsgBox("Debe Ingresar el Vendedor.", MsgBoxStyle.Information, "Información")
                cmbVendedor.BackColor = Color.Red
                cmbVendedor.Focus()
                Return False
            ElseIf toBlank(txtCliente.Text) = "" Then
                MsgBox("Debe Ingresar el Vendedor.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            Else
                Return True
            End If
            Return False
        Catch ex As Exception

        End Try
    End Function
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub biModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biModificar.Click
        activar()
    End Sub

    Private Sub txtNumDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                If oAprobarVentaService.BuscarDocumentoVenta(cmbIdLocacion.Value, cmbTipo.Value, IIf(gbTipFac.Enabled = False, "", cmbTipFac.Value), txtNumDoc.Text) Then
                    listaDatos()
                Else
                    MsgBox("No existe el Documento, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                    Limpiar()
                    txtNumDoc.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbTipo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        Try
            If cmbTipo.Value = "2" Then
                gbTipFac.Enabled = True
            Else
                gbTipFac.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try
    End Sub
    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If dgvDatos.RowCount > 0 Then
            Limpiar()
            txtNumDoc.Focus()
        End If
    End Sub
    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            Dim estado_process As Boolean
            estado_process = oAprobarVentaService.ActualizarVendedor(cmbTipo.Value, IdVenta, cmbVendedor.Value, Session.sCodUsu)
            If estado_process Then
                MsgBox("Se realizó la actualización correctamente ")
                desactivar()
            End If
        End If

    End Sub

    Private Sub cmbTipFac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipFac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNumDoc.Focus()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
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


    Private Sub cbOficina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.CheckedChanged
        If cbOficina.Checked = True Then
            cmbVendedor.Clear()
            cmbVendedor.Value = 0
            cmbVendedor.Enabled = False
        ElseIf cbOficina.Checked = False Then
            cmbVendedor.Enabled = True
        End If
    End Sub
End Class