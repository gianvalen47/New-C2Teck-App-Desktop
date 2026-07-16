Imports System.ServiceModel
Public Class frmRegComprasImpDoc

    '===========================Servicios====================================
    Private oRegistroCompraService As New RegistroCompraService.RegistroCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdCompra As Integer                ' Id del Registro de Compra
    Private dtDatos As DataTable
    Private state_Search As Boolean
    Public Periodo As Integer
    Public MesRegistro As String
    Public NumRegistro As String

    Private Sub txtNumDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumDoc.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtSerieDoc.KeyPress, _
                            txtNumDoc.KeyPress
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

    Private Sub frmRegComprasImpDoc_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oRegistroCompraService.Close()
        Catch ex As TimeoutException
            oRegistroCompraService.Abort()
        Catch ex As CommunicationException
            oRegistroCompraService.Abort()
        End Try
    End Sub

    Private Sub frmRegComprasImpDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmRegComprasImpDoc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        If toNumber(MesRegistro) = Month(Today) And Periodo = Year(Today) Then
            txtFecha.Value = Today
        Else
            txtFecha.Value = DateSerial(Periodo, toNumber(MesRegistro) + 1, 0)
        End If
        txtNumDoc.Focus()
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
            'tabla.DefaultView.Sort = nombreCampo
            'lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            'lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Importar()
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
            ElseIf dgvDatos.CurrentRow.Cells("IdDocumento").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Importar()
        Try
            IdCompra = oRegistroCompraService.ImportarDocumento(Session.sCodEmp, Periodo, MesRegistro, NumRegistro, _
                                                                                                dgvDatos.CurrentRow.Cells("IdProveedor").Value, _
                                                                                                dgvDatos.CurrentRow.Cells("IdDocumento").Value, _
                                                                                                IIf(IsDBNull(dgvDatos.CurrentRow.Cells("SerDoc").Value), Nothing, dgvDatos.CurrentRow.Cells("SerDoc").Text), _
                                                                                                dgvDatos.CurrentRow.Cells("NumDoc").Value, _
                                                                                                txtFecha.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp, dgvDatos.CurrentRow.Cells("IdGasto").Value)
            If IdCompra <> 0 Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR AL IMPORTAR DOCUMENTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCancelar.Click, biSalir.Click
        IdCompra = 0
        Me.Close()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oRegistroCompraService.ConsultarDocumentos(txtSerieDoc.Text, txtNumDoc.Text).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miImportar.Enabled = False
            biImportar.Enabled = False
        Else
            miImportar.Enabled = True
            biImportar.Enabled = True
        End If
    End Sub

    Private Sub miImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImportar.Click, biImportar.Click
        If ValidaCodigoSeleccionado() Then
            Importar()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        'Dim codigo As String = ""
        'If dgvDatos.RowCount > 0 Then
        '    codigo = dgvDatos.CurrentRow.Cells("IdDocumento").Text
        'End If
        'dtDatos = Nothing
        listaDatos()
        'If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
        '    RowPossesion(dgvDatos, dtDatos, "IdDocumento", codigo)
        'End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtSerieDoc.TextChanged, txtNumDoc.TextChanged
        listaDatos()
    End Sub
End Class