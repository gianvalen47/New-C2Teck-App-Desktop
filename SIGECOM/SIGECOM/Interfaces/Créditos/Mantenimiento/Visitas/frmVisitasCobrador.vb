Public Class frmVisitasCobrador
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVisitaCobradorService As New VisitaCobradorService.VisitaCobradorServiceClient
    Private oSeguridad As New SeguridadService.SeguridadClient
    Private dtMeses As DataTable
    Private dtDatos As DataTable
    Private dtCobrador As DataTable
    Private IdCliente As Integer
    Private IdPer As String
    Private Persona As String
    Private CodPerfil As String

    Private Sub frmVisitasCobrador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oVisitaCobradorService) = False Then
                oVisitaCobradorService.Close()
            End If
            If isClosed(oSeguridad) = False Then
                oSeguridad.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmVisitasCobrador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVisitasCobrador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtIdCliente.KeyPress _
        , cmbMes.KeyPress _
        , cmbCobrador.KeyPress _
        , txtanio.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub
    Private Sub frmVisitasCobrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridad.InsertarSesionOpciones(Session.sIdSesion, 80)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        SeguridadUsuario()
        txtanio.Value = Today.Year
        cmbMes.Value = Today.Month
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        listaDatos()
        Text = "Visitas de los Cobradores"
        txtanio.Select()
        enableOpciones()
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

    End Sub
    Private Sub SeguridadUsuario()
        Dim usuario As New SeguridadService.Usuario
        Dim Cod As Integer
        usuario = oSeguridad.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPer = usuario.Persona.IdPer
        If Session.CodPerfil <> "10" Then
            cmbCobrador.Value = 0
            cmbCobrador.Text = "(Todos)"
        Else
            Cod = IdPer
            cmbCobrador.Value = Cod
            cmbCobrador.Enabled = False
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdVisita").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try

        Return fila
    End Function
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 0 Then
            biActualizar.Enabled = False
            biEliminar.Enabled = False
            biImprimir.Enabled = False
            biMostrar.Enabled = False

            miActualizar.Enabled = False
            miEliminar.Enabled = False
            miImprimir.Enabled = False
            miMostrar.Enabled = False
        Else
            biActualizar.Enabled = True
            biEliminar.Enabled = True
            biImprimir.Enabled = True
            biMostrar.Enabled = True

            miActualizar.Enabled = True
            miEliminar.Enabled = True
            miImprimir.Enabled = True
            miMostrar.Enabled = True
        End If
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oVisitaCobradorService.Filtrar(Session.sCodEmp, txtanio.Value, cmbMes.Value, IdCliente, toNumber(cmbCobrador.Value)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing
            '==================================COBRADOR======================================================
            dtCobrador = oMaestroService.MostrarCobradores.Tables(0)
            Dim row As DataRow = dtCobrador.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtCobrador.Rows.InsertAt(row, 0)
            cmbCobrador.DataSource = dtCobrador
            cmbCobrador.DataMember = "ApeNom"
            cmbCobrador.DisplayMember = "ApeNom"
            cmbCobrador.ValueMember = "IdPer"
            cmbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cmbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            'cmbCobrador.SelectedIndex = 0
            dtCobrador = Nothing
          
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click

    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Dim frm As New frmVisitaCobrador
        frm.state_button = False
        If Session.CodPerfil = 10 Then
            frm.IdPer = IdPer
            frm.cmbCobrador.Enabled = False
        End If

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            frm.Dispose()
            MsgBox("Se realizó la creación de la visita correctamente ")
            dtDatos = Nothing
            'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
            txtIdCliente.Clear()
            If Session.CodPerfil <> "10" Then
                cmbCobrador.Value = 0
                cmbCobrador.Text = "(Todos)"
            End If
            
            listaDatos()
            'If frm.type_process = "insert" Then
            RowPossesion(dgvDatos, frm.IdVisita)

        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.TextChanged, cmbCobrador.ValueChanged, cmbMes.ValueChanged, txtIdCliente.TextChanged
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.ButtonClick
        Dim frm As New frmBuscarCliente

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Dim frm As New frmVisitaCobrador

        frm.IdVisita = dgvDatos.CurrentRow.Cells("IdVisita").Text
        frm.state_button = True
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            biActualizar_Click(sender, e)

        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdVisita").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                e.Handled = True
                biMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click

    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub
End Class