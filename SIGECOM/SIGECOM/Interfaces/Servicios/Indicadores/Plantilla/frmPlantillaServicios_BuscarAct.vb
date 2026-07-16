Imports System.ServiceModel

Public Class frmPlantillaServicios_BuscarAct

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    Private dtDatos As DataTable
    Public descripcion As String
    Public IdActividadDet As Integer
    Private dtActividad As DataTable

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, biActividad.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdActividadDet").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CÓDIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Seleccionar()
        Try
            descripcion = dgvDatos.CurrentRow.Cells("DesActividad").Text
            IdActividadDet = dgvDatos.CurrentRow.Cells("IdActividadDet").Text
            'IdActividadDet = dgvDatos.CurrentRow.Cells("IdActividad").Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR AL SELECCIONAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmPlantillaServicios_BuscarAct_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
        End Try
    End Sub

    Private Sub frmPlantillaServicios_BuscarAct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlantillaServicios_BuscarAct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombo()
        'cmbActividad.Value = 1
        listaDatos()
        cmbActividad.Focus()
    End Sub

    Private Sub llenarCombo()
        Try
            '========================================= ACTIVIDADES ================================================
            dtActividad = oIndicadoresServicioService.MostrarActividad.Tables(0)
            'dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbActividad.DataSource = dtActividad
            cmbActividad.DropDownList.DataMember = dtActividad.Columns("DesActividad").ToString
            cmbActividad.DropDownList.DisplayMember = dtActividad.Columns("DesActividad").ToString
            cmbActividad.DropDownList.ValueMember = dtActividad.Columns("IdActividad").ToString
            cmbActividad.DropDownList.Columns(0).DataMember = dtActividad.Columns("IdActividad").ToString
            cmbActividad.DropDownList.Columns(1).DataMember = dtActividad.Columns("DesActividad").ToString
            If dtActividad.Rows.Count > 0 Then
                cmbActividad.SelectedIndex = 0
            End If
            dtActividad = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO ACTIVIDADES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try        
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.MostrarActividadDet(utils.toNumber(cmbActividad.Value)).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbActividad_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbActividad.ValueChanged
        listaDatos()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cmbActividad.KeyPress
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
End Class
