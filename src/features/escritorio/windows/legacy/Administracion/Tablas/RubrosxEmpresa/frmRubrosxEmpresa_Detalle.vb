Imports System.ServiceModel

Public Class frmRubrosxEmpresa_Detalle

    Private oRubrosService As New RubrosService.RubrosServiceClient

    Public CodEmp As String
    'Public CodRub As String

    'Private CodRubGrilla As String
    'Private DesRubGrilla As String
    'Private AbrRubGrilla As String
    'Private FacCos As String
    'Private FacVen As String
    'Private Dscto As String

    Public CodRubGrilla As String
    Public DesRubGrilla As String
    Public AbrRubGrilla As String
    Public FactorCosto As Double
    Public FactorVenta As Double
    Public Descuento As Double

    Private dtDatos As DataTable

    Public type_process As String                'update     insert      delete

    Public state_button As Boolean

    Private Sub frmRubrosxEmpresa_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaDatos()
    End Sub

    Private Sub frmRubrosxEmpresa_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRubrosxEmpresa_Detalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRubrosService.Close()
        Catch ex As TimeoutException
            oRubrosService.Abort()
        Catch ex As CommunicationException
            oRubrosService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()

        Try

            dtDatos = oRubrosService.Filtrar().Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub Seleccionar()
        Try

            CodRubGrilla = dgvDatos.CurrentRow.Cells("CodRub").Text
            DesRubGrilla = dgvDatos.CurrentRow.Cells("DesRub").Text
            AbrRubGrilla = dgvDatos.CurrentRow.Cells("AbrRub").Text
            FactorCosto = dgvDatos.CurrentRow.Cells("FacCos").Text
            FactorVenta = dgvDatos.CurrentRow.Cells("FacVen").Text
            Descuento = dgvDatos.CurrentRow.Cells("Dscto").Text

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
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
                'ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                '    MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class