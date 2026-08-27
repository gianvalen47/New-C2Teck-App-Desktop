Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmPlanilla

    Protected Friend pIdPlanilla As Integer
    Private ObjPlanilla As New PlanillaService.PlanillaServiceClient
    Private ObjPlanillaDet As New PlanillaDetalleService.PlanillaDetalleServiceClient
    Private ObjPagos As New PagoPlanillaService.PagoPlanillaServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private Planilla As New PlanillaService.Planilla
    Private dtCobrador As New DataTable
    Private dtDetalles As New DataTable
    Private dtPagos As New DataTable
    Private Transa As String = "" '(I = Insertar, U = Actualizar)

    Private Sub frmPlanilla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            ObjPlanilla.Close()
            ObjPlanillaDet.Close()
            ObjPagos.Close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            ObjPlanilla.Abort()
            ObjPlanillaDet.Abort()
            ObjPagos.Abort()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            ObjPlanilla.Abort()
            ObjPlanillaDet.Abort()
            ObjPagos.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                dgDetalle.Focus()
            End If
        End If
    End Sub
    Private Sub dgDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmMostrar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub dgPagos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgPagos.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmMostrarPago_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub cbCobrador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCobrador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmPlanilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtNumero.KeyPress _
                , txtFecha.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgDetalle)
        estilo.cargaEstiloGridExt(dgPagos)

        dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgDetalle.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        dgPagos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgPagos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        MostrarDatos()
        LlenarCobrador()
        MostrarDetalles()
        SeleccionTab(0)
        If dgDetalle.RowCount > 0 Then
            dgDetalle.Select()
        Else
            txtNumero.Select()
        End If
    End Sub

    Protected Friend Sub MostrarDatos()
        Try
            If Transa <> "I" Then
                Planilla = ObjPlanilla.MostrarPorId(pIdPlanilla)
                txtNumero.Text = Planilla.NumPla
                txtFecha.Text = Planilla.FecPla
                txtTipoCambio.Text = Planilla.TipCam
                cbCobrador.Value = Planilla.Persona.IdPer
                If Planilla.Aprobado = True Then
                    btnModificar.Enabled = False
                    CMenuDetalle.Enabled = False
                    CMenuPagos.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Protected Friend Sub NuevoRegistro()
        Transa = "I"
        txtNumero.Text = ""
        txtFecha.Text = Today
        txtTipoCambio.Text = ObjMaestro.MostrarTipoCambio("US", Today)
        cbCobrador.Value = ""
        txtNumero.ReadOnly = False
        txtFecha.ReadOnly = False
        'txtTipoCambio.ReadOnly = False
        cbCobrador.Enabled = True
        txtNumero.Text = ObjPlanilla.SugerirNumero(Session.sCodEmp)

        btnModificar.Enabled = False
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnSalir.Enabled = False

        cmNuevo.Enabled = False
        cmModificar.Enabled = False
        cmBorrar.Enabled = False

        cmNuevoPago.Enabled = False
        cmModificarPago.Enabled = False
        cmBorrarPago.Enabled = False

        TabOpciones.Enabled = False

    End Sub

    Protected Friend Sub ModificarRegistro()
        Transa = "U"
        txtFecha.ReadOnly = False
        'txtTipoCambio.ReadOnly = False
        cbCobrador.Enabled = True

        btnModificar.Enabled = False
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnSalir.Enabled = False

        cmNuevo.Enabled = False
        cmModificar.Enabled = False
        cmBorrar.Enabled = False

        cmNuevoPago.Enabled = False
        cmModificarPago.Enabled = False
        cmBorrarPago.Enabled = False


        TabOpciones.Enabled = False

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        ModificarRegistro()
    End Sub

    Private Sub LlenarCobrador()

        Try
            dtCobrador = ObjPlanilla.MostrarCobradores(Session.sCodEmp).Tables(0)
            dtCobrador.Rows.InsertAt(getRowAsignado(dtCobrador), 0)
            cbCobrador.DataSource = dtCobrador
            cbCobrador.DisplayMember = "ApeNom"
            cbCobrador.ValueMember = "IdPer"
            cbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            'cbCobrador.SelectedIndex = 0
            dtCobrador = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = 0
        Catch ex As Exception

        End Try
        Try
            fila(1) = "OFICINA LIMA"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Transa = "I" Then
            Close()
        Else
            Desactivar()
        End If

    End Sub

    Private Sub Desactivar()
        Transa = ""
        txtNumero.ReadOnly = True
        txtFecha.ReadOnly = True
        txtTipoCambio.ReadOnly = True
        cbCobrador.Enabled = False

        btnModificar.Enabled = IIf(pIdPlanilla = 0, False, True)
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnSalir.Enabled = True

        cmNuevo.Enabled = True
        cmModificar.Enabled = True
        cmBorrar.Enabled = True

        cmNuevoPago.Enabled = True
        cmModificarPago.Enabled = True
        cmBorrarPago.Enabled = True


        TabOpciones.Enabled = True

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toNumber(cbCobrador.Value) = 0 Then
            '    MsgBox("Debe Seleccionar el Vendedor", MsgBoxStyle.Information, "Información")
            '    Return False
            'Else
            If toNumber(txtTipoCambio.Text) = 0 Then
                MsgBox("Debe ingresar el tipo de cambio")
                txtTipoCambio.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de Ingreso")
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GRABAR los datos?", MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.Yes And ValidaCampos() Then

            Try

                Dim Registro As New PlanillaService.Planilla
                Dim Empresa As New PlanillaService.Empresa
                Dim Cobrador As New PlanillaService.Persona
                Empresa.CodEmp = Session.sCodEmp
                Registro.Empresa = Empresa
                Registro.NumPla = txtNumero.Text
                Registro.FecPla = txtFecha.Text
                Registro.TipCam = txtTipoCambio.Text
                Cobrador.IdPer = cbCobrador.Value
                Registro.Persona = Cobrador

                Registro.CodUsu = Session.sCodUsu
                Registro.NomPc = Session.sNomPc
                Registro.DirIp = Session.sDirIp

                Select Case Transa
                    Case "I"
                        If ObjPlanilla.Buscar(Session.sCodEmp, txtNumero.Text) Then
                            MsgBox("Ya existe este numero de Planilla, tenga cuidado.!!!!!", MsgBoxStyle.Critical, "Ya Existe Numero")
                        Else
                            pIdPlanilla = ObjPlanilla.Insertar(Registro)
                        End If
                    Case "U"

                        Registro.IdPlanilla = pIdPlanilla
                        ObjPlanilla.Actualizar(Registro)
                End Select
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Desactivar()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Grabar")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdPlanillaDet").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub RowPossesionPago(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdPago").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub MostrarDetalles()
        Try
            dtDetalles = ObjPlanillaDet.Mostrar(pIdPlanilla).Tables(0)
            Me.dgDetalle.SetDataBinding(dtDetalles, 0)
            tbPagos.Enabled = IIf(dtDetalles.Rows.Count = 0, False, True)

            Dim lTotal, lDifCam, lTotalPag As Double
            For Each Fila As DataRow In dtDetalles.Rows
                lTotal = lTotal + Fila.Item("SolPag")
                lDifCam = lDifCam + Math.Round(Fila.Item("DifCam"), 3)  ' lDifCam + Math.Round(Fila.Item("DifCam"), 2)   'Se comenta a pedido de Angélica pide calcular la dif de cambio en 4 decimales 17/11/2014 Solicitud de usuario 4325
                lTotalPag = lTotalPag + Fila.Item("PagSol")
            Next
            txtTotalDoc.Text = lTotal
            txtTotalDifCam.Text = Math.Round(lDifCam, 2)  'lDifCam 'Se comenta a pedido de Angélica pide calcular la dif de cambio en 4 decimales Solicitud de usuario 4325
            txtTotalPagos.Text = lTotalPag

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub
    Private Sub MostrarPagos()
        Try
            If dtDetalles.Rows.Count > 0 Then
                dtPagos = ObjPagos.Mostrar(dgDetalle.CurrentRow.Cells(0).Text).Tables(0)
                Me.dgPagos.SetDataBinding(dtPagos, 0)
            End If 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub cmMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmMostrar.Click, dgDetalle.DoubleClick
        If dtDetalles.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmPlanillaDet
            forma.pIdPlanilla = pIdPlanilla
            forma.pIdPlanillaDet = dgDetalle.CurrentRow.Cells(0).Text
            'forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
            forma.ShowDialog()
        End If
    End Sub

    Private Sub cmRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmRefrescar.Click

        RefrescarDetalles()

    End Sub
    Public Sub RefrescarDetalles()
        Dim codigo As String = ""
        If dgDetalle.RowCount > 0 Then
            codigo = dgDetalle.CurrentRow.Cells("IdPlanillaDet").Text
        End If
        dtDetalles = Nothing
        MostrarDetalles()
        If dgDetalle.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgDetalle, codigo)
        End If
    End Sub

    Private Sub TabOpciones_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles TabOpciones.SelectedTabChanged
        SeleccionTab(TabOpciones.SelectedIndex)
    End Sub

    Private Sub SeleccionTab(ByVal Indice As Int16)
        Select Case TabOpciones.SelectedIndex
            Case 0
                Try
                    ' RefrescarDetalles()
                    dgDetalle.Select()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 1
                Try
                    MostrarPagos()
                    dgPagos.Select()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try


        End Select
    End Sub

    Private Sub btnModificarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmModificarPago.Click
        If dtPagos.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmPlanillaPago
            forma.pIdPlanilla = pIdPlanilla
            forma.pIdPlanillaDet = dgDetalle.CurrentRow.Cells(0).Text
            forma.pIdPago = dgPagos.CurrentRow.Cells(0).Text
            forma.ModificarRegistro()
            'forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPagos = Nothing
                MostrarPagos()
                RefrescarDetalles()
                RowPossesionPago(dgPagos, forma.pIdPago)
            End If
        End If
    End Sub

    Private Sub cmMostrarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmMostrarPago.Click, dgPagos.DoubleClick
        If dtPagos.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmPlanillaPago
            forma.pIdPlanilla = pIdPlanilla
            forma.pIdPlanillaDet = dgDetalle.CurrentRow.Cells(0).Text
            forma.pIdPago = dgPagos.CurrentRow.Cells(0).Text



            'forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
            forma.ShowDialog()
        End If
    End Sub

    Private Sub cmRefrescarPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmRefrescarPagos.Click


        Dim codigo As String = ""
        If dgPagos.RowCount > 0 Then
            codigo = dgPagos.CurrentRow.Cells("IdPago").Text
        End If
        dtPagos = Nothing
        MostrarPagos()
        If dgPagos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesionPago(dgPagos, codigo)
        End If

    End Sub

    Private Sub cmNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmNuevo.Click
        Dim forma As New frmPlanillaDet
        forma.pIdPlanilla = pIdPlanilla
        forma.pIdPlanillaDet = 0
        forma.NuevoRegistro()
        'forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
        If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDetalles = Nothing
            MostrarDetalles()
            RowPossesion(dgDetalle, forma.pIdPlanillaDet)
        End If

    End Sub

    Private Sub cmModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmModificar.Click
        If dtDetalles.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmPlanillaDet
            forma.pIdPlanilla = pIdPlanilla
            forma.pIdPlanillaDet = dgDetalle.CurrentRow.Cells(0).Text
            forma.ModificarRegistro()
            'forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDetalles = Nothing
                MostrarDetalles()
                RowPossesion(dgDetalle, forma.pIdPlanillaDet)
                RefrescarDetalles()
            End If

        End If
    End Sub

    Private Sub cmBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmBorrar.Click
        If MsgBox("¿Está seguro de BORRAR el Documento?", MsgBoxStyle.YesNo, "Borrar") = MsgBoxResult.Yes Then

            Try
                ObjPlanillaDet.Borrar(dgDetalle.CurrentRow.Cells(0).Text, pIdPlanilla, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MostrarDetalles()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Borrar")
            End Try
        End If
    End Sub

    Private Sub cmNuevoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmNuevoPago.Click
        Dim forma As New frmPlanillaPago
        forma.pIdPlanilla = pIdPlanilla
        forma.pIdPlanillaDet = dgDetalle.CurrentRow.Cells(0).Text
        forma.pIdPago = 0
        forma.NuevoRegistro()
        'forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
        If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtPagos = Nothing
            MostrarPagos()
            RefrescarDetalles()
            RowPossesionPago(dgPagos, forma.pIdPago)

            'RefrescarDetalles()
        End If

    End Sub

    Private Sub cmBorrarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmBorrarPago.Click
        If MsgBox("¿Está seguro de BORRAR el pago?", MsgBoxStyle.YesNo, "Borrar") = MsgBoxResult.Yes Then

            Try
                ObjPagos.Borrar(dgPagos.CurrentRow.Cells(0).Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MostrarPagos()
                RefrescarDetalles()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Borrar")
            End Try
        End If
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        txtTipoCambio.Text = toDouble(ObjMaestro.MostrarTipoCambio("US", txtFecha.Text))
    End Sub
End Class
