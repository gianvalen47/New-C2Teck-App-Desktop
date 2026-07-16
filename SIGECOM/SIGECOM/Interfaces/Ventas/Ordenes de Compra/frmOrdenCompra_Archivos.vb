Imports System.ServiceModel
Imports AxAcroPDFLib
Imports System.IO
Imports AcroPDFLib

Public Class frmOrdenCompra_Archivos

    Private oOrdenCompra As New OrdenCompraService.OrdenCompraServiceClient

    Private dtDatos As DataTable
    Public IdOrden As Int64
    Public NumOrden As String
    Public IdOrdenArchivo As Integer
    Private Sub frmCotizacion_Archivos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenCompra.Close()
        Catch ex As TimeoutException
            oOrdenCompra.Abort()
        Catch ex As CommunicationException
            oOrdenCompra.Abort()
        End Try
    End Sub

    Private Sub frmCotizacion_Archivos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_Archivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaDatos()

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub

    Private Sub listaDatos()
        Try
            IdOrdenArchivo = IdOrden
            dtDatos = oOrdenCompra.MostrarArchivos(IdOrden).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim lLog As Boolean = True
        While lLog
            Dim frm As New frmOrdenCompra_Archivos_Nuevo
            frm.state_button = False

            frm.IdOrden = IdOrden

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOrdenArchivo)
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
            If row.Cells("IdArchivo").Value = codigo Then
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

        Try
            If Not Directory.Exists("D:\OrdenArchivos\" & NumOrden) Then
                Directory.CreateDirectory("D:\OrdenArchivos\" & NumOrden)
            End If

            Dim idArchivo As Int64 = dgvDatos.CurrentRow.Cells("IdArchivo").Text

            Dim registro As OrdenCompraService.OrdenCompraArchivos
            registro = oOrdenCompra.ObtenerArchivos(idArchivo)

            Dim pdfDoc() As Byte
            Dim NombreArchivo As String
            Dim Extension As String
            pdfDoc = registro.ArchivoData
            NombreArchivo = registro.Nombre
            Extension = registro.Extension

            System.IO.File.WriteAllBytes("D:\OrdenArchivos\" & NumOrden & "\" & NombreArchivo & Extension, pdfDoc)
            System.Diagnostics.Process.Start("D:\OrdenArchivos\" & NumOrden & "\" & NombreArchivo & Extension)

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


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
                estado_process = oOrdenCompra.BorrarArchivos(toNumber(dgvDatos.CurrentRow.Cells("IdArchivo").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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

    'Private Function ValidaCodigoSeleccionado() As Boolean
    '    Try
    '        If dgvDatos.RowCount < 1 Then
    '            MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
    '            Return False
    '        ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
    '            MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
    '            Return False
    '        ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
    '            MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Function

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdArchivo").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdArchivo").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biModificar_Click(sender As Object, e As EventArgs) Handles biModificar.Click, miModificar.Click
        If ValidaCodigoSeleccionado() Then
            ModificarArchivo()
        End If
    End Sub

    Private Sub ModificarArchivo()

        Dim frm As New frmOrdenCompra_Archivos_Actualizar
        frm.IdArchivo = dgvDatos.CurrentRow.Cells("IdArchivo").Text
        frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            If frm.type_process = "actualizar" Then
                RowPossesion(dgvDatos, frm.IdArchivo)
            End If
        Else

        End If

    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Close()
    End Sub
End Class