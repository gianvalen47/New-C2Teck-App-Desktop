Imports System.ServiceModel
Public Class frmDevolver_Recurso

    '=========================== Servicios ====================================
    Private oRecursoDetService As New RecursoDetService.RecursoDetServiceClient
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient

    '====================== Declaración de Variables ==============================   
    Public IdRecursoDet As Integer
    Public IdRecurso As Integer
    Public Codigo As String
    Public Masivo As Boolean
    Private dtDatos As DataTable

    Private Sub frmDevolver_Recurso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtFecDevuelto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDevolver_Recurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDevolver_Recurso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFecDevuelto.Focus()
        txtFecDevuelto.Value = Today
        Me.Text = "Devolver detalle(s) de Recurso"
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try        
            If Masivo = False Then
                Dim estado_process As Boolean
                If MsgBox("¿Está seguro de DEVOLVER el detalle seleccionado?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If toBlank(txtFecDevuelto.Value) = "" Then
                        MsgBox("Debe ingresar la fecha.")
                        txtFecDevuelto.Focus()
                    Else
                        If MsgBox("¿Desea Dar de Baja el Activo Fijo?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                            oActivoFijoService.DarBaja(Codigo, Session.sCodEmp, Date.Today, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        End If
                        estado_process = oRecursoDetService.Devolver(IdRecursoDet, IdRecurso, txtFecDevuelto.Value, txtDescripcion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se devolvió el detalle correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                End If
            Else
                '============================ MASIVO ==========================
                dtDatos = oRecursoDetService.Mostrar(IdRecurso).Tables(0)
                dgvDatos.DataSource = dtDatos
                If MsgBox("¿Está seguro de DEVOLVER los detalles seleccionados?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If toBlank(txtFecDevuelto.Value) = "" Then
                        MsgBox("Debe ingresar la fecha.")
                        txtFecDevuelto.Focus()
                    Else
                        If MsgBox("¿Desea Dar de Baja los Activos Fijos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then ' Se devuelven y se dan de baja los activos
                            dgvDatos.Update()
                            Dim dtTable As DataTable
                            Dim Cont As Integer = 0
                            Dim cIdRecursoDet As Integer
                            Dim cCodigo As String
                            dtTable = dtDatos.Copy
                            dtTable.Clear()
                            For i As Integer = 0 To dtDatos.Rows.Count - 1
                                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Devuelto"), DataGridViewCheckBoxCell)
                                If toBoolean(cellSelecion.Value) = False Then
                                    Cont = Cont + 1
                                    cIdRecursoDet = toNumber(row.Cells("IdRecursoDet").Value)
                                    cCodigo = row.Cells("Codigo").Value
                                    oActivoFijoService.DarBaja(cCodigo, Session.sCodEmp, Date.Today, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                    oRecursoDetService.Devolver(cIdRecursoDet, IdRecurso, txtFecDevuelto.Value, txtDescripcion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                End If
                            Next
                            If Cont < 1 Then
                                MsgBox("No existen detalles a devolver.")
                            Else
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                MsgBox("Se devolvió los detalles correctamente.")
                            End If
                        Else        ' Solo se devuelven sin dar de baja el activo
                            dgvDatos.Update()
                            Dim dtTable As DataTable
                            Dim Cont As Integer = 0
                            Dim cIdRecursoDet As Integer
                            dtTable = dtDatos.Copy
                            dtTable.Clear()
                            For i As Integer = 0 To dtDatos.Rows.Count - 1
                                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Devuelto"), DataGridViewCheckBoxCell)
                                If toBoolean(cellSelecion.Value) = False Then
                                    Cont = Cont + 1
                                    cIdRecursoDet = toNumber(row.Cells("IdRecursoDet").Value)
                                    oRecursoDetService.Devolver(cIdRecursoDet, IdRecurso, txtFecDevuelto.Value, txtDescripcion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                End If
                            Next
                            If Cont < 1 Then
                                MsgBox("No existen detalles a devolver.")
                            Else
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                MsgBox("Se devolvió los detalles correctamente.")
                            End If

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Devolver Detalles de Recurso: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oRecursoDetService.Close()
            oActivoFijoService.Close()
        Catch ex As TimeoutException
            oRecursoDetService.Abort()
            oActivoFijoService.Abort()
        Catch ex As CommunicationException
            oRecursoDetService.Abort()
            oActivoFijoService.Abort()
        End Try
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class