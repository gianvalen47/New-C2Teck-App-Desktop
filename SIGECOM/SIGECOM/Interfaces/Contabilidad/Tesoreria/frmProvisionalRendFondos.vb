Imports System.ServiceModel
Public Class frmProvisionalRendFondos

    '===========================Servicios====================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables=============================   
    Public IdProvisional As Integer ' IdProvisional Seleccionado
    Public Nombre As String 'ApeNom de Colaborador del Provisional Seleccionado
    Public IdDocumento As Integer 'Tipo de Documento viene del InsertarPendientes
    Public SerieDoc As String 'Serie de Documento viene del Insertar Pendientes
    Public NumDoc As String 'Número de Documento viene del Insertar Pendientes        
    Private state_Search As Boolean
    Private dtDatos As DataTable
    Private dtMonedas As DataTable
    Public CodMon As String
    Public IdPersona As Integer

    Private Sub frmBuscarPendientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmBuscarPendientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisionalRendFondos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Colaborador")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Colaborador")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        IdPersona = 0
        txtColaborador.Text = "(Todos)"

        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        cmbMoneda.Value = CodMon
        cmbMoneda.Focus()
    End Sub

    Private Sub Finalizar()
        Try
            oTesoreriaService.Close()
            oProvisionalService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
            oProvisionalService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtColaborador.TextChanged, cmbMoneda.ValueChanged
        listaDatos()
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
            fila(4) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cmbMoneda.KeyPress, _
                         txtColaborador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oProvisionalService.MostrarProvisionalAtendido(Session.sCodEmp, cmbMoneda.Value, IdPersona).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdProvisional").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub chkProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Insertar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdProvisional").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar()
        Try
            If MsgBox("¿Está seguro de INSERTAR el Provisional Nro : " + dgvDatos.CurrentRow.Cells("IdProvisional").Value.ToString + "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then              
                Dim frm As New frmInsertarPendientes
                frm.Provisional = True
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdDocumento = frm.IdDocumento
                    SerieDoc = frm.SerieDoc
                    NumDoc = frm.NumDoc
                    IdProvisional = dgvDatos.CurrentRow.Cells("IdProvisional").Value
                    Nombre = CStr(dgvDatos.CurrentRow.Cells("ApeNom").Value)
                    CodMon = cmbMoneda.Value
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miImportar.Enabled = False
            biInsertar.Enabled = False
        Else
            miImportar.Enabled = True
            biInsertar.Enabled = True
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biInsertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biInsertar.Click, miImportar.Click
        If ValidaCodigoSeleccionado() Then
            Insertar()
        End If        
    End Sub

    Private Sub miSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miCancelar.Click, biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class