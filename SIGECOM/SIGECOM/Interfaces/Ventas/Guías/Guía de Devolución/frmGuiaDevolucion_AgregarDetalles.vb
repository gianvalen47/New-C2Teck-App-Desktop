Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmGuiaDevolucion_AgregarDetalles

  Private oGuiaDevolucionDetService As New GuiaDevolucionDetService.GuiaDevolucionDetServiceClient
  Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
  Private dtDatos As DataTable
  Private state_Search As Boolean
  '====================================================================================================================
  '============================================ LOCAL PARAMETERS ======================================================
  '====================================================================================================================
  Public IdGuiaDev As Integer
  Private estado As String

  Public codigo As String
    Public numero As Integer

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Delete Then
            listaDatos()
        End If
    End Sub

  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
    'Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                dgvDatos.KeyPress
    '    If e.KeyChar = ChrW(Keys.Escape) Then
    '        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '        Me.Close()
    '    End If
    'End Sub
  Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
    Try
      tabla.DefaultView.Sort = nombreCampo
      lista.Row = dtDatos.DefaultView.Find(codigo)
    Catch ex As Exception
      MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
    End Try
    End Sub

    Private Sub frmGuiaDevolucion_AgregarDetalles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim estilo As New Estilo
    estilo.cargaEstiloGrid_Bucadores(dgvDatos)
    state_Search = True
    listaDatos()
    estado = oGuiaDevolucionService.Estado(IdGuiaDev)
    enableOpciones()
  End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        '  If isClosed(oGuiaDevolucionDetService) = False Then
        '    oGuiaDevolucionDetService.Close()
        '  End If
        '  If isClosed(oGuiaDevolucionService) = False Then
        '    oGuiaDevolucionService.Close()
        '  End If
        'Catch ex As Exception
        '  MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            oGuiaDevolucionService.Close()
            oGuiaDevolucionDetService.Close()
        Catch ex As TimeoutException
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
        Catch ex As CommunicationException
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)

  End Sub
  Private Sub enableOpciones()
    If dgvDatos.RowCount < 1 Then
      miAgregarDetalles.Enabled = False
    Else
      miAgregarDetalles.Enabled = True
    End If
    If estado = "GENERADO" Then
      miAgregarDetalles.Enabled = True
    Else
      miAgregarDetalles.Enabled = False
    End If
  End Sub
  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Sub agregarDetalles()
    If ValidaCodigoSeleccionado() Then
      Try
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = dgvDatos.GetCheckedRows()

        Dim row As Janus.Windows.GridEX.GridEXRow
        For Each row In rows
          Dim nro As Integer = oGuiaDevolucionDetService.IngresarDevolucion(IdGuiaDev, row.Cells("TipDoc").Text, row.Cells("CodigoDetalle").Text)
          If nro <= 0 Then
            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            Exit For
          End If
        Next
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Catch ex As Exception
        MsgBox("ERROR [AGREGAR_DETALLES]: " + ex.Message, MsgBoxStyle.Exclamation)
      End Try
    End If
  End Sub
  Private Sub actualizar()
    Dim codigo As String = ""
    If dgvDatos.RowCount > 0 Then
      codigo = dgvDatos.CurrentRow.Cells("CodigoDetalle").Text
    End If
    dtDatos = Nothing
    listaDatos()
    If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
      RowPossesion(dgvDatos, dtDatos, "CodigoDetalle", codigo)
    End If
  End Sub
  Private Sub salir()
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub listaDatos()
    Try
      If state_Search = True Then
        dtDatos = oGuiaDevolucionDetService.MostrarDevolucion(IdGuiaDev).Tables(0)
        dgvDatos.SetDataBinding(dtDatos, 0)

        sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        enableOpciones()
      End If
    Catch ex As Exception
      MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
    dgvDatos.Select()
  End Sub
  Private Function ValidaCodigoSeleccionado() As Boolean
    Dim rows() As Janus.Windows.GridEX.GridEXRow
    rows = dgvDatos.GetCheckedRows()
    Try
      If dgvDatos.RowCount < 1 Then
        MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
        Return False
      ElseIf rows.Length < 1 Then
        MsgBox("Seleccione por lo menos un registro ...!!!", MsgBoxStyle.Information, "Información")
        Return False
      Else
        Return True
      End If
    Catch ex As Exception
      MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function
  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ====================================================
  '====================================================================================================================
  Private Sub biAgregarDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAgregarDetalles.Click
    agregarDetalles()
  End Sub
  Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
    actualizar()
  End Sub
  Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
    salir()
  End Sub

  Private Sub miAgregarDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAgregarDetalles.Click
    agregarDetalles()
  End Sub
  Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
    actualizar()
  End Sub
  Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
    salir()
  End Sub

  Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biAgregarDetalles.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miAgregarDetalles.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
    sslError.Text = ""
  End Sub

  Private Sub AgregarDetalles_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                        biAgregarDetalles.MouseEnter, miAgregarDetalles.MouseEnter
    sslError.Text = "Agregar Detalles seleccionados a la Guía de Devolución actual."
  End Sub
  Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biActualizar.MouseEnter, miActualizar.MouseEnter
    sslError.Text = "Actualizar los Detalles de la FAC/BOL seleccionada."
  End Sub
  Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biSalir.MouseEnter, miSalir.MouseEnter
    sslError.Text = "Cerrar y Salir del Formulario."
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
