Imports System.ServiceModel

Imports System.IO

Public Class frmComSolicitudGastos_Archivos

    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient

    Private dtDatos As DataTable
    Public IdGasto As Integer
    Public Nombre As String
    Public IdGastoArchivo As Integer
    Public estado As String

    Private Sub frmComSolicitudGastos_Archivos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
        End Try
    End Sub

    Private Sub frmComSolicitudGastos_Archivos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGastos_Archivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaDatos()

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudGastoService.MostrarArchivo(IdGasto).Tables(0)
            dgvDatos.DataSource = dtDatos

            If estado <> 9 And estado <> 10 Then
                biNuevo.Enabled = True
                biEliminar.Enabled = True
                biModificarArchivo.Enabled = True
                miNuevo.Enabled = True
                miEliminar.Enabled = True
                miModificarArchivo.Enabled = True
            Else
                biNuevo.Enabled = False
                biEliminar.Enabled = False
                biModificarArchivo.Enabled = False
                miNuevo.Enabled = False
                miEliminar.Enabled = False
                miModificarArchivo.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim lLog As Boolean = True
        While lLog
            Dim frm As New frmComSolicitudGastos_Archivos_Nuevo
            frm.state_button = False

            frm.IdGasto = IdGasto

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdGastoArchivo)
                End If
            Else
                lLog = False
            End If
        End While
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdGastoArchivo").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()

        If Not Directory.Exists("D:\SolicitudGastoArchivos\" & Nombre) Then
            Directory.CreateDirectory("D: \SolicitudGastoArchivos\" & Nombre)
        End If

        Dim registro As SolicitudGastoService.SolicitudGastoArchivos
        registro = oSolicitudGastoService.ObtenerArchivo(dgvDatos.CurrentRow.Cells("IdGastoArchivo").Text)

        Dim pdfDoc() As Byte
        Dim NombreArchivo As String
        Dim Extension As String
        pdfDoc = registro.ArchivoData
        NombreArchivo = registro.Nombre
        Extension = registro.Extension

        System.IO.File.WriteAllBytes("D:\SolicitudGastoArchivos\" & Nombre & "\" & NombreArchivo & Extension, pdfDoc)
        System.Diagnostics.Process.Start("D:\SolicitudGastoArchivos\" & Nombre & "\" & NombreArchivo & Extension)

    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el archivo seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudGastoService.BorrarArchivo(toNumber(dgvDatos.CurrentRow.Cells("IdGastoArchivo").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el archivo correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdGastoArchivo").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub biModificarArchivo_Click(sender As Object, e As EventArgs) Handles biModificarArchivo.Click, miModificarArchivo.Click
        If ValidaCodigoSeleccionado() Then
            ModificarArchivo()
        End If
    End Sub

    Private Sub ModificarArchivo()

        Dim frm As New frmComSolicitudGastos_Archivos_Actualizar
        frm.IdGasto = IdGasto
        frm.IdGastoArchivo = dgvDatos.CurrentRow.Cells("IdGastoArchivo").Text

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            If frm.type_process = "actualizar" Then
                RowPossesion(dgvDatos, frm.IdGastoArchivo)
            End If
        Else

        End If

    End Sub

End Class