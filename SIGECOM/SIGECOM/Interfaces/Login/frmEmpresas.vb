Imports System.ServiceModel

Public Class frmEmpresas
    'Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Public CodEmp As String
    Public DesEmp As String
    Public Salir As Boolean
    Public CodUsu As String

    'Private Sub frmEmpresas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    Try
    '        If isClosed(oMaestroService) = False Then
    '            oMaestroService.Close()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub
    Private Sub Finalizar()
        Try
            '      oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException

            '     oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException

            '    oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        Me.Hide()

    End Sub
    Private Sub frmEmpresas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub frmEmpresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        dgvDatos.Select()


    End Sub
    Private Sub listaDatos()
        Try
            'dtDatos = oMaestroService.MostrarEmpresas.Tables(0)
            dtDatos = oSeguridadService.MostrarMultiEmpresa(CodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        CodEmp = dgvDatos.CurrentRow.Cells("CodEmp").Text
        DesEmp = dgvDatos.CurrentRow.Cells("DesEmp").Text
        Salir = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Salir = True
        Finalizar()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
  

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        btnAceptar_Click(sender, e)
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            btnAceptar_Click(sender, e)
        End If
    End Sub

  
  
End Class