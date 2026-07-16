
Imports System.ServiceModel
Public Class frmSeguimiento_PersonalMasivo

    Private oSeguimientoService As New SeguimientoService.SeguimientoServiceClient

    Private dtDatos As DataTable
    Public IdSeguimiento As Integer
    Public IdLocacion As String

    Private Sub frmSeguimiento_PersonalMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguimientoService.Close()
        Catch ex As TimeoutException
            oSeguimientoService.Abort()
        Catch ex As CommunicationException
            oSeguimientoService.Abort()
        End Try
    End Sub

    Private Sub frmSeguimiento_PersonalMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSeguimiento_PersonalMasivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False

        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try

            dtDatos = oSeguimientoService.MostrarPersonal(IdLocacion).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresar.Click

        Try
            If dgvDatos.RowCount > 0 Then

                dgvDatos.Update()
                TextBox1.Focus()

                If MsgBox("¿Está seguro de INGRESAR el personal?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    For i As Integer = 0 To dgvDatos.Rows.Count - 1

                        Dim row As DataGridViewRow = dgvDatos.Rows(i)
                        Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                        If toBoolean(cellSelecion.Value) = True Then

                            Dim registro As New SeguimientoService.TecnicosSeguimiento
                            Dim Seguimiento As New SeguimientoService.Seguimiento
                            Dim Persona As New SeguimientoService.Persona

                            Seguimiento.IdSeguimiento = IdSeguimiento
                            registro.Seguimiento = Seguimiento

                            Persona.IdPer = toNumber(dgvDatos.Rows(i).Cells("IdPer").Value.ToString)
                            registro.PersonaTecnico = Persona

                            registro.CodUsu = Session.sCodUsu
                            registro.DirIp = Session.sDirIp
                            registro.NomPc = Session.sNomPc

                            InsertarDetalle(registro)

                        End If
                    Next

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If
            Else
                MsgBox("Debe tener detalles", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub InsertarDetalle(ByVal registro As SeguimientoService.TecnicosSeguimiento)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguimientoService.InsertarTecnico(registro)

            If estado_process = True Then
                'listaDatos()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TÉCNICO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(2).Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(2).Value = False
        Next
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub
End Class