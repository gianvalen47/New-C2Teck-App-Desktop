Imports System.ServiceModel
Public Class frmPendientesRendFondos

    '===========================Servicios====================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient

    '======================Declaración de Variables=============================   
    Public IdTesoreria As Integer
    Public IdTesoreriaDet As Integer
    Public IdCuenta As Integer
    Public CodCuenta As String
    Public IdDocumento As Integer
    Public SerDoc As String
    Public NumDoc As String
    Public MontoOriginal As Double
    Public CodMon As String
    Private dtDatos As DataTable
    Public IdPersona As Integer
    Private state_Search As Boolean

    Private Sub frmPendientesRendFondos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        txtCodCuenta.Focus()        
    End Sub

    Private Sub frmPendientesRendFondos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmPendientesRendFondos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oTesoreriaService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
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

    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtCodCuenta.KeyPress _
                       , txtColaborador.KeyPress
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

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LlenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Seleccionar()
        Try
            IdTesoreria = dgvDatos.CurrentRow.Cells("IdTesoreria").Value
            IdTesoreriaDet = dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Value
            'CodCuenta = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("CodCuenta").Value), "", dgvDatos.CurrentRow.Cells("CodCuenta").Text)
            CodCuenta = txtCodCuenta.Text
            IdDocumento = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdDocumento").Value), 0, dgvDatos.CurrentRow.Cells("IdDocumento").Value)
            SerDoc = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("SerDoc").Value), "", dgvDatos.CurrentRow.Cells("SerDoc").Text)
            NumDoc = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("NumDoc").Value), "", dgvDatos.CurrentRow.Cells("NumDoc").Text)
            CodMon = dgvDatos.CurrentRow.Cells("CodMon").Value
            MontoOriginal = IIf(CodMon = "NS", dgvDatos.CurrentRow.Cells("MontoSol").Value, dgvDatos.CurrentRow.Cells("MontoDol").Value)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR AL SELECCIONAR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oTesoreriaService.ConsultarPendienteRendicion(txtCodCuenta.Text, IdPersona).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdTesoreriaDet", codigo)
        End If
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        IdTesoreriaDet = 0
        CodCuenta = ""
        IdDocumento = 0
        SerDoc = ""
        NumDoc = ""
        MontoOriginal = 0
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCodCuenta.TextChanged, txtColaborador.TextChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            frm.txtCodCuenta.Text = txtCodCuenta.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta.Text = frm.codigo
                    'lblDesCuenta.Text = frm.descripcion
                Else
                    txtCodCuenta.Text = ""
                    'lblDesCuenta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = ""
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If txtColaborador.Text <> "(Todos)" Then
    '        chkPersona.Enabled = False
    '        txtColaborador.Text = "(Todos)"
    '        IdPersona = 0
    '        listaDatos()
    '    Else
    '        chkPersona.Enabled = True
    '        pboxLimpiarCliente.Enabled = True
    '    End If
    'End Sub
End Class