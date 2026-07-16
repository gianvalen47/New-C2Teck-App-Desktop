Imports System.ServiceModel
Public Class frmPlanillaSueldos_GenerarArchivoPlame

    '===========================Servicios====================================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    '======================Declaración de Variables==============================================    

    Public IdPlanilla As Integer
    Public Periodo As String
    Public Mes As String

    '======================= Nomenclatura de Libros ======================
    Dim CodForm As String = "0601"                           'CODIGO FORMULARIO



    Private Sub frmPlanillaSueldos_dsctos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosService.Close()

        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()

        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()

        End Try
    End Sub

    Private Sub frmPlanillaSueldos_GenerarArchivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        rbSegunSeleccionado.Checked = True

    End Sub

    Private Sub frmPlanillaSueldos_GenerarArchivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Function GenerarNombreArchivo() As String
        Dim Nombre As String = ""
        Dim ext As String = ""
        Try


            If rbRem.Checked Then
                ext = ".rem"
            ElseIf rbJor.Checked
                ext = ".jor"
            ElseIf rbSNL.Checked
                ext = ".snl"
            ElseIf rbOR5.Checked
                ext = ".or5"
            ElseIf rbTOC.Checked
                ext = ".toc"
            ElseIf rbPS4.Checked
                ext = ".ps4"
            ElseIf rb4TA.Checked
                ext = ".4ta"
            ElseIf rbFor.Checked
                ext = ".for"
            End If


            Nombre = CodForm + Periodo + Mes + Session.sRucEmp + ext

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NOMBRE DE ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return Nombre
    End Function


    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If rbSegunSeleccionado.Checked Then
            GenerarSeleccionado()
        ElseIf rbTodos.Checked Then
            GenerarTodos()
        End If

    End Sub

    Private Sub GenerarSeleccionado()

        Try


            Dim Seleccion As New SaveFileDialog
            Seleccion.Title = "Guardar archivo para el pago de haberes masivo en el banco"
            Seleccion.Filter = "Archivos de texto |*.txt"
            Seleccion.FileName = GenerarNombreArchivo()


            If Seleccion.ShowDialog() = DialogResult.OK Then

                Dim tipo As Integer
                If rbRem.Checked Then
                    tipo = 6
                ElseIf rbJor.Checked
                    tipo = 7
                ElseIf rbSNL.Checked
                    tipo = 9
                ElseIf rbOR5.Checked
                    tipo = 10
                ElseIf rbTOC.Checked
                    tipo = 11
                ElseIf rbPS4.Checked
                    tipo = 12
                ElseIf rb4TA.Checked
                    tipo = 13
                ElseIf rbFor.Checked
                    tipo = 14
                End If


                Dim dtdetalle As New DataTable
                dtdetalle = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, tipo).Tables(0)
                dgvDatos.DataSource = dtdetalle


                If dgvDatos.Rows.Count > 0 Then


                    Dim Ruta As String = Seleccion.FileName

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2


                            '==============================================
                            '------------- REM -------------                        
                            If tipo = 6 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|"

                                '==============================================
                                '------------ JOR -------------
                            ElseIf tipo = 7 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|"
                                '------------ SNL -------------
                            ElseIf tipo = 9 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|"
                                '------------ OR5 -------------
                            ElseIf tipo = 10 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|"
                                '------------ TOC -------------
                            ElseIf tipo = 11 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|"
                                '------------ PS4 -------------
                            ElseIf tipo = 12 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|"
                                '------------ 4TA -------------
                            ElseIf tipo = 13 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" & .Rows(i).Cells("campo8").Value & "|" &
                                    .Rows(i).Cells("campo9").Value & "|" & .Rows(i).Cells("campo10").Value & "|" &
                                    .Rows(i).Cells("campo11").Value & "|"
                                '-----------FOR-----------------
                            ElseIf tipo = 14 Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|"
                            End If

                            archivo.WriteLine(Linea)
                        Next
                    End With

                    archivo.Close()

                End If


                MsgBox("Se descargo exitosamente")

                Finalizar()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub GenerarTodos()

        Try
            Dim Nombre As String = ""
            Dim Nombre1 As String = ""
            Dim Nombre2 As String = ""
            Dim Nombre3 As String = ""
            Dim Nombre4 As String = ""
            Dim Nombre5 As String = ""
            Dim Nombre6 As String = ""
            Dim ext As String = ""

            Dim Seleccion As New SaveFileDialog
            Seleccion.Title = "Guardar archivo para el pago de haberes masivo en el banco"
            Seleccion.Filter = "Archivos de texto |*.txt"
            Seleccion.FileName = CodForm + Periodo + Mes + Session.sRucEmp ' + ".rem"

            'If rbRem.Checked Then
            '    ext = ".rem"
            'ElseIf rbJor.Checked
            '    ext = ".jor"
            'ElseIf rbSNL.Checked
            '    ext = ".snl"
            'ElseIf rbOR5.Checked
            '    ext = ".or5"
            'ElseIf rbTOC.Checked
            '    ext = ".toc"
            'ElseIf rbPS4.Checked
            '    ext = ".ps4"
            'ElseIf rb4TA.Checked
            '    ext = ".4ta"
            'ElseIf rbFor.Checked
            '    ext = ".for"
            'End If

            'Nombre = CodForm + Periodo + Mes + Session.sRucEmp

            If Seleccion.ShowDialog() = DialogResult.OK Then

                Dim dtdetalle0 As New DataTable
                dtdetalle0 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 6).Tables(0)
                dgvDatos.DataSource = dtdetalle0

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".rem"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".rem"
                    'Dim Ruta As String = Nombre + ".rem"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- REM -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                .Rows(i).Cells("campo5").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== JOR

                Dim dtdetalle1 As New DataTable
                dtdetalle1 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 7).Tables(0)
                dgvDatos.DataSource = dtdetalle1

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".jor"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".jor"
                    'Dim Ruta As String = Nombre + ".jor"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- JOR -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== SNL

                Dim dtdetalle2 As New DataTable
                dtdetalle2 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 9).Tables(0)
                dgvDatos.DataSource = dtdetalle2

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".snl"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".snl"
                    'Dim Ruta As String = Nombre + ".snl"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- SNL -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== or5

                Dim dtdetalle3 As New DataTable
                dtdetalle3 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 10).Tables(0)
                dgvDatos.DataSource = dtdetalle3

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".or5"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".or5"
                    'Dim Ruta As String = Nombre + ".or5"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- OR5 -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== toc

                Dim dtdetalle4 As New DataTable
                dtdetalle4 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 11).Tables(0)
                dgvDatos.DataSource = dtdetalle4

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".toc"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".toc"
                    'Dim Ruta As String = Nombre + ".toc"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- TOC -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== ps4

                Dim dtdetalle5 As New DataTable
                dtdetalle5 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 12).Tables(0)
                dgvDatos.DataSource = dtdetalle5

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".ps4"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".ps4"
                    'Dim Ruta As String = Nombre + ".ps4"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- PS4 -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== 4ta

                Dim dtdetalle6 As New DataTable
                dtdetalle6 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 13).Tables(0)
                dgvDatos.DataSource = dtdetalle6

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".4ta"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".4ta"
                    'Dim Ruta As String = Nombre + ".4ta"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- 4TA -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" & .Rows(i).Cells("campo8").Value & "|" &
                                    .Rows(i).Cells("campo9").Value & "|" & .Rows(i).Cells("campo10").Value & "|" &
                                    .Rows(i).Cells("campo11").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                '=============================================== for

                Dim dtdetalle7 As New DataTable
                dtdetalle7 = oPlanillaSueldosService.GenerarArchivoPlame(Session.sCodEmp, IdPlanilla, 14).Tables(0)
                dgvDatos.DataSource = dtdetalle7

                If dgvDatos.Rows.Count > 0 Then

                    'Dim Ruta As String = Seleccion.FileName + ".for"
                    Dim Ruta As String = Mid(Seleccion.FileName, 1, Len(Seleccion.FileName) - 4) + ".for"
                    'Dim Ruta As String = Nombre + ".for"

                    Dim fichero As String = Ruta
                    Dim archivo As New System.IO.StreamWriter(fichero)
                    Dim Linea As String = Nothing

                    With dgvDatos
                        For i = 0 To .RowCount - 2

                            '==============================================
                            '------------- FOR -------------                        
                            Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|"

                            '==============================================
                            archivo.WriteLine(Linea)
                        Next


                    End With

                    archivo.Close()

                End If

                MsgBox("Se descargo exitosamente")

                Finalizar()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR LOS ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub


End Class