Imports System.ServiceModel

Public Class frmProvisional_FechaTerminoMant


    '===========================Servicios====================================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    Private dtDatos As New DataTable
    Public IdProvisional As Integer
    Private iEnviado As Boolean
    Private iAprobado As Boolean

    Private Sub frmProvisional_FechaTerminoMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaDatos()
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub

    Private Sub frmProvisional_FechaTerminoMant_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_FechaTerminoMant_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("!Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("!Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub listaDatos()
        Try
            dtDatos = oProvisionalService.MostrarExtensionFecha(IdProvisional).Tables(0)
            dgvDatos.DataSource = dtDatos

            enableOpciones()

            'If estado <> 9 And estado <> 10 Then
            '    biNuevo.Enabled = True
            '    biEliminar.Enabled = True
            '    biModificarArchivo.Enabled = True
            '    miNuevo.Enabled = True
            '    miEliminar.Enabled = True
            '    miModificarArchivo.Enabled = True
            'Else
            '    biNuevo.Enabled = False
            '    biEliminar.Enabled = False
            '    biModificarArchivo.Enabled = False
            '    miNuevo.Enabled = False
            '    miEliminar.Enabled = False
            '    miModificarArchivo.Enabled = False
            'End If

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biNuevo.Enabled = True
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biEnviar.Enabled = False

            miNuevo.Enabled = True
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miEnviar.Enabled = False
        Else
            iEnviado = CBool(dgvDatos.CurrentRow.Cells("Enviado").Value)
            iAprobado = CBool(dgvDatos.CurrentRow.Cells("Aprobado").Value)
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(Not iEnviado, True, False)
            biEnviar.Enabled = IIf(Not iEnviado And Not iAprobado, True, False)

            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(Not iEnviado, True, False)
            miEnviar.Enabled = IIf(Not iEnviado And Not iAprobado, True, False)
        End If
    End Sub


    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click

        Dim frm As New frmProvisional_FechaTerminoMant_Nuevo
        frm.state_button = False

        frm.IdProvisional = IdProvisional
        frm.IdFechas = 0

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            'If frm.type_process = "insert" Then
            '    RowPossesion(dgvDatos, frm.IdGastoArchivo)
            'End If
        End If

    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click

        mostrar()

    End Sub

    Private Sub mostrar()

        Dim frm As New frmProvisional_FechaTerminoMant_Nuevo
        frm.state_button = True

        frm.IdProvisional = IdProvisional
        frm.IdFechas = toNumber(dgvDatos.CurrentRow.Cells("IdFechas").Text)

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            'listaDatos()
            Actualizar()

            'If frm.type_process = "insert" Then
            '    RowPossesion(dgvDatos, frm.IdGastoArchivo)
            'End If
        End If

    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click

        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la extension de fecha termino?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oProvisionalService.BorrarExtensionFecha(toNumber(dgvDatos.CurrentRow.Cells("IdFechas").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("!Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR la extension de fecha termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biEnviar_Click(sender As Object, e As EventArgs) Handles biEnviar.Click, miEnviar.Click

        Try

            If MsgBox("¿Está seguro de ENVIAR la extension de fecha termino?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim estado_process As Boolean
                estado_process = oProvisionalService.EnviarExtensionFecha(dgvDatos.CurrentRow.Cells("IdFechas").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If estado_process Then
                    MsgBox("Se envió la extension de fecha termino correctamente ", MsgBoxStyle.Information)
                    'listaDatos()
                    Actualizar()

                    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ENVIAR la extension de fecha termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdFechas").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdFechas").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs)
        listaDatos()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click_1(sender As Object, e As EventArgs) Handles biActualizar.Click
        Actualizar()

    End Sub
End Class