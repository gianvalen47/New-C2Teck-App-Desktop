Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmDocsCreditos
    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================================================================================================================
    '============================================ Parametros Locales ====================================================
    '====================================================================================================================
    Private lMostrar As Boolean
    Private dtTipoDocumentos As DataTable
    Private dtDatos As DataTable
    Private IdCliente, IdDocumento As String
    Private NumDocumento As Integer
    '====================================================================================================================
    '============================================ Metodos de Control ====================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
          txtCliente.KeyPress, cmbDocu.KeyPress, txtNumDoc.KeyPress, txtFecIni.KeyPress, txtFecFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                e.Handled = True
                biMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
          txtCliente.KeyPress, cmbDocu.KeyPress, txtNumDoc.KeyPress, btnBuscar.KeyPress, dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocs_Creditos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oDocumentoCtaCtesService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oDocumentoCtaCtesService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oDocumentoCtaCtesService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmDocsCreditos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 35)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dgvDatos.RowFormatStyle.FontSize = 7.5!
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        txtFecIni.Value = "01/01/" & Year(Today)
        listaDatos()
        dgvDatos.Select()
        dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ' refrescarMenus()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdDocCtaCte").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ Metodos de Asignación =================================================
    '====================================================================================================================
    Private Sub refrescarMenus()

        lMostrar = IIf(dgvDatos.RowCount > 0, True, False)
        Me.biMostrar.Enabled = lMostrar
        Me.biActualizar.Enabled = lMostrar
        Me.miMostrar.Enabled = lMostrar
        Me.miActualizar.Enabled = lMostrar

        If lMostrar Then
            Me.biRenovar.Enabled = IIf(dgvDatos.CurrentRow.Cells("AbrDoc").Text = "LET" And dgvDatos.CurrentRow.Cells("Saldo").Text > 0, True, False)
            Me.miRenovar.Enabled = IIf(dgvDatos.CurrentRow.Cells("AbrDoc").Text = "LET" And dgvDatos.CurrentRow.Cells("Saldo").Text > 0, True, False)
            Me.miEliminar.Enabled = IIf(dgvDatos.CurrentRow.Cells("AbrDoc").Text = "LET" And dgvDatos.CurrentRow.Cells("Saldo").Text > 0, True, False)
        End If

        Me.biNuevo.Enabled = IIf(Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05", True, False)      '------ Se agrega el Perfil de Costos 02/08/2016
        Me.miNuevo.Enabled = IIf(Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05", True, False)      '------ Se agrega el Perfil de Costos 02/08/2016

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oMaestroService.MostrarTipDocCtaCte.Tables(0)
            Dim row As DataRow = dtTipoDocumentos.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocu.SelectedIndex = 0
            dtTipoDocumentos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oDocumentoCtaCtesService.Filtrar(Session.sCodEmp, "", "", txtFecIni.Value, txtFecFin.Value, IdCliente, cmbDocu.Value, IIf(Trim(txtNumDoc.Text) = "", 0, txtNumDoc.Text)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString


            '////////SUMAR MONTOS TOTALES DE VENCIMIENTOS////////
            If dtDatos.Rows.Count > 0 Then
                Dim lPorVencerSol, lVencidoSol, lPorVencerDol, lVencidoDol As Decimal
                For Each Fila As DataRow In dtDatos.Rows
                    If Fila.Item("CodMon") = "US" Then
                        If Fila.Item("VenDoc") <= Today Then
                            lVencidoDol = lVencidoDol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        Else
                            lPorVencerDol = lPorVencerDol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        End If
                    Else
                        If Fila.Item("VenDoc") <= Today Then
                            lVencidoSol = lVencidoSol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        Else
                            lPorVencerSol = lPorVencerSol + (Fila.Item("Saldo")) ' * (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        End If
                    End If
                
                Next
                txtPorVencerSol.Text = lPorVencerSol
                txtVencidoSol.Text = lVencidoSol
                txtPorVencerDol.Text = lPorVencerDol
                txtVencidoDol.Text = lVencidoDol
                txtSaldoSol.Text = lPorVencerSol + lVencidoSol
                txtSaldoDol.Text = lPorVencerDol + lVencidoDol
            Else
                txtPorVencerSol.Text = 0.0
                txtVencidoSol.Text = 0.0
                txtPorVencerDol.Text = 0.0
                txtVencidoDol.Text = 0.0
                txtSaldoSol.Text = 0.0
                txtSaldoDol.Text = 0.0
            End If
            '/////////////////////////////////////////////////////

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        refrescarMenus()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdDocCtaCte").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    '====================================================================================================================
    '============================================ Metodos de Interface ==================================================
    '====================================================================================================================
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If dgvDatos.RecordCount > 0 Then
            Dim forma As New frmDocsCredito
            forma.IdDocCtaCte = dgvDatos.CurrentRow.Cells("IdDocCtaCte").Text
            forma.Transa = "M"
            forma.Text = "Documento de Credito Nro : " & dgvDatos.CurrentRow.Cells("Documento").Text
            forma.ShowDialog()
            Actualizar()
        End If
        
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbDocu_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDocu.ValueChanged
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        btnBuscar.Focus()
    End Sub

    Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            txtCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            txtNumDoc.Text = ""
            listaDatos()
        End If
    End Sub

    Private Sub txtNumDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtNumDoc.Text <> "" Then
            txtCliente.Text = ""
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbDocu.ValueChanged, txtFecIni.ValueChanged, txtFecFin.ValueChanged, txtNumDoc.TextChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim forma As New frmDocsCredito
        '  forma.IdDocCtaCte = 0
        forma.Transa = "I"
        If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            RowPossesion(dgvDatos, forma.IdDocCtaCte)
            biMostrar_Click(sender, e)
        End If
    End Sub


    Private Sub biRenovar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRenovar.Click, miRenovar.Click
        If dgvDatos.CurrentRow.Cells("Saldo").Text >= 0 Then
            Dim forma As New frmDocsCreditoRenovar
            forma.IdDocCtaCte = dgvDatos.CurrentRow.Cells("IdDocCtaCte").Text
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, forma.IdDocCtaCte)
            End If
        Else
            MsgBox("La Letra ya esta cancelada no se puede renovar")
        End If
        
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        refrescarMenus()
    End Sub

    Private Sub biRecalcularDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRecalcularDoc.Click
        Try

            If MsgBox("¿Está Seguro de Recalcular el documento Nº " + dgvDatos.CurrentRow.Cells("Documento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oDocumentoCtaCtesService.RecalcularDocumento(dgvDatos.CurrentRow.Cells("IdDocCtaCte").Text, dgvDatos.CurrentRow.Cells("CodMon").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se realizó el Recalculo Correctamente.!!!!!", MsgBoxStyle.Information, "Recalculo")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        Try

            If MsgBox("¿Está Seguro de Eliminar el documento Nº " + dgvDatos.CurrentRow.Cells("Documento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oDocumentoCtaCtesService.Borrar(dgvDatos.CurrentRow.Cells("IdDocCtaCte").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se elimino el documento.!!!!!", MsgBoxStyle.Information, "Borrar")
                    dtDatos = Nothing
                    listaDatos()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If

    End Sub
End Class