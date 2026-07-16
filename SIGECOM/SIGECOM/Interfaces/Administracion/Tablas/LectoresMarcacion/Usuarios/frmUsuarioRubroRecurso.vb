Imports System.ServiceModel
Public Class frmUsuarioRubroRecurso

    '===========================Servicios====================================
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oRecursoService As New RecursoService.RecursoServiceClient

    '======================Declaración de Variables==============================   
    Public CodUsu As String
    Public IdRubro As Integer
    Private dtRubros As DataTable

    Private Sub frmUsuarioRubroRecurso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
            oRecursoService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
            oRecursoService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
           oRecursoService.Abort()
        End Try
    End Sub

    Private Sub frmUsuarioRubroRecurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuarioRubroRecurso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        cmbRubro.Focus()
    End Sub

    Private Sub llenarCombos()
        Try

            '============================================== RUBRO ========================================
            dtRubros = oRecursoService.MostrarRubros("").Tables(0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If oSeguridadService.BuscarRubroRecurso(CodUsu, toNumber(cmbRubro.Value)) Then
                MsgBox("El Rubro de Recurso ya ha sido asignado al usuario.", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbRubro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim state_process As Boolean
                    state_process = oSeguridadService.InsertarRubroRecurso(CodUsu, toNumber(cmbRubro.Value))
                    If state_process = True Then
                        IdRubro = toNumber(cmbRubro.Value)
                        MsgBox("Se agregó correctamente el rubro de recurso")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR RUBRO DE RECURSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class