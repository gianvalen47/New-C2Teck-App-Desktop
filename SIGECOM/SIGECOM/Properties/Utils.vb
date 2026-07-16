Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.OleDb

Module utils
    Public Function toNull(ByVal campo As String) As String
        If IsDBNull(campo) Then
            campo = Nothing
        ElseIf campo = Nothing Then
            campo = Nothing
        ElseIf campo.Trim.Length < 1 Then
            campo = Nothing
        Else
            campo = campo.Trim
        End If
        Return campo
    End Function
    Public Function toBlank(ByVal campo As String) As String
        Try
            If campo = Nothing Then
                campo = ""
            ElseIf campo.Trim.Length < 1 Then
                campo = ""
            Else
                campo = campo.Trim
            End If
        Catch ex As Exception
            campo = ""
        End Try
        Return campo
    End Function
    Public Function toNumber(ByVal campo As String) As Integer
        Dim numero As Integer = 0
        Try
            If IsDBNull(campo) Then
                numero = 0
            ElseIf campo = Nothing Then
                numero = 0
            ElseIf campo Is Nothing Then
                numero = 0
            ElseIf campo.Trim.Length < 1 Then
                numero = 0
            Else
                numero = CInt(campo.Trim)
            End If
        Catch ex As Exception
            numero = 0
        End Try

        Return numero
    End Function
    Public Function toDouble(ByVal campo As String) As Double
        Dim numero As Double = 0.0
        Try
            If campo = Nothing Then
                numero = 0.0
            ElseIf campo.Trim.Length < 1 Then
                numero = 0.0
            Else
                numero = CDbl(campo.Trim)
            End If
        Catch ex As Exception
            numero = 0.0
        End Try

        Return numero
    End Function
    Public Function toBoolean(ByVal campo As String) As Boolean
        Dim estado As Boolean = False
        Try
            If campo = Nothing Then
                estado = False
            ElseIf campo.Trim.Length < 1 Then
                estado = False
            ElseIf campo.Trim.ToUpper = "FALSE" Then
                estado = False
            ElseIf campo.Trim.ToUpper = "TRUE" Then
                estado = True
            ElseIf campo.Trim = "1" Then
                estado = True
            ElseIf campo.Trim = "0" Then
                estado = False
            Else
                estado = False
            End If
        Catch ex As Exception
            estado = False
        End Try

        Return estado
    End Function
    Public Function isClosed(ByVal sender As Object) As Boolean
        If sender.State = ServiceModel.CommunicationState.Faulted Or _
           sender.State = ServiceModel.CommunicationState.Closed Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SeleccionarImpresora() As String
        Dim prtDialog As New PrintDialog
        Dim prtSettings As New Printing.PrinterSettings
        Dim Impresora As String = ""
        With prtDialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True
            .UseEXDialog = True

            .PrinterSettings = prtSettings
            .PrinterSettings.Copies = 2
            ' .PrinterSettings.PrinterName = "hp deskjet 5550 series (HPA)"

            If .ShowDialog() = DialogResult.OK Then
                prtSettings = .PrinterSettings
                Impresora = .PrinterSettings.PrinterName
            End If
        End With
        Return Impresora
    End Function

    Public Function ExportarExcel(ByVal DataGridView1) As Boolean
        Dim ty As Boolean = Comprobar("Excel.Application") ' Asignamos para validar si se ha instalado Excel en la máquina

        '======================== SIN EXCEL ===========================
        If ty = False Then
            'Creamos las variables
            Dim exApp
            Dim exLibro
            Dim exHoja

            'Añadimos el Libro al programa, y la hoja al libro
            exApp = CreateObject("Ket.Application")
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Try
                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = DataGridView1.ColumnCount
                Dim NRow As Integer = DataGridView1.RowCount

                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(1, i) = DataGridView1.Columns(i - 1).Name.ToString
                    'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                    Next
                Next

                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()

                'Aplicación visible
                exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                Return False
            End Try
            Return True


            '======================== CON EXCEL ===========================
        Else
            'Creamos las variables
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Try
                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = DataGridView1.ColumnCount
                Dim NRow As Integer = DataGridView1.RowCount

                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(1, i) = DataGridView1.Columns(i - 1).Name.ToString
                    'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                    Next
                Next

                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()

                'Aplicación visible
                exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                Return False
            End Try
            Return True
        End If
    End Function

    Public Function ExportarExcelSinCabecera(ByVal DataGridView1) As Boolean
        Dim ty As Boolean = Comprobar("Excel.Application") ' Asignamos para validar si se ha instalado Excel en la máquina

        '======================== SIN EXCEL ===========================
        If ty = False Then
            'Creamos las variables
            Dim exApp
            Dim exLibro
            Dim exHoja

            'Añadimos el Libro al programa, y la hoja al libro
            exApp = CreateObject("Ket.Application")
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Try
                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = DataGridView1.ColumnCount
                Dim NRow As Integer = DataGridView1.RowCount

                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                'For i As Integer = 1 To NCol
                '    exHoja.Cells.Item(1, i) = DataGridView1.Columns(i - 1).Name.ToString
                '    'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                'Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 1, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                    Next
                Next

                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                'exHoja.Rows.Item(1).Font.Bold = 1
                'exHoja.Rows.Item(1).HorizontalAlignment = 3
                'exHoja.Columns.AutoFit()

                'Aplicación visible
                exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                Return False
            End Try
            Return True


            '======================== CON EXCEL ===========================
        Else
            'Creamos las variables
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Try
                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = DataGridView1.ColumnCount
                Dim NRow As Integer = DataGridView1.RowCount

                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.

                'For i As Integer = 1 To NCol
                '    exHoja.Cells.Item(1, i) = DataGridView1.Columns(i - 1).Name.ToString
                '    'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                'Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        'Fila +1   --- para que no aparezca el header como fila
                        If Col = 0 Or Col = 1 Or Col = 3 Then
                            'exHoja.Cells.Item(Fila + 1, Col + 1).NumberFormat = "00000000"
                            'exHoja.Cells.Item(Fila + 1, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                            exHoja.Cells.Item(Fila + 1, Col + 1) = “'” + DataGridView1.Rows(Fila).Cells(Col).Value
                        Else
                            exHoja.Cells.Item(Fila + 1, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                        End If


                        'exHoja.Cells.Item(Fila + 1, Col + 1) = “’” + DataGridView1.Rows(Fila).Cells(Col).Value
                        'exHoja.Cells.Item(Fila + 1, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                    Next
                Next

                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                'exHoja.Rows.Item(1).Font.Bold = 1
                'exHoja.Rows.Item(1).HorizontalAlignment = 3
                'exHoja.Columns.AutoFit()


                Dim Ubicacion As String = ""
                Dim file As New SaveFileDialog()
                'file.FileName = NombreXMLPDF
                file.Filter = "XLSX|*.xlsx"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName
                End If

                exLibro.SaveAs(Ubicacion, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                False, False, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                exLibro.Close()

                'Aplicación visible
                'exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                Return False
            End Try
            Return True
        End If
    End Function

    Public Function GetDataExcel(ByVal fileName As String, ByVal fileExt As String) As DataTable
        Dim dt As New DataTable()
        Dim source As String = ""
        Dim ty As Boolean = Comprobar("Excel.Application") ' Asignamos para validar si se ha instalado Excel en la máquina

        Try
            ' Validamos si está instalado Excel en la maquina y asignamos el valor a source
            If ty = False Then
                source = "Sheet4$"
            Else
                source = "Hoja2$"
            End If

            If fileExt = ".xlsx" Then
                If source = "Hoja2$" Then
                    Using cnn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                            "Extended Properties='Excel 12.0 Xml;HDR=Yes';" & "Data Source=" & fileName)

                        Dim sql As String = String.Format("SELECT * FROM [{0}]", source)
                        Dim da As New OleDbDataAdapter(sql, cnn)

                        da.Fill(dt)

                    End Using
                Else
                    'Agregado como prueba - para la ultima version del kingsoft WPS OFFICE
                    Using cnn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" & _
                    "Extended Properties='Excel 12.0 Xml;HDR=Yes';" & "Data Source=" & fileName)

                        Dim sql As String = String.Format("SELECT * FROM [{0}]", source)
                        Dim da As New OleDbDataAdapter(sql, cnn)

                        da.Fill(dt)

                    End Using
                    'Using cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                    '"Extended Properties='Excel 8.0;HDR=Yes';" & "Data Source=" & fileName)

                    '    Dim sql As String = String.Format("SELECT * FROM [{0}]", source)
                    '    Dim da As New OleDbDataAdapter(sql, cnn)
                    '    'Dim dt As New DataTable()
                    '    da.Fill(dt)

                    'End Using

                End If

            ElseIf fileExt = ".xls" Then
                Using cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                        "Extended Properties='Excel 8.0;HDR=Yes';" & "Data Source=" & fileName)

                    Dim sql As String = String.Format("SELECT * FROM [{0}]", source)
                    Dim da As New OleDbDataAdapter(sql, cnn)
                    'Dim dt As New DataTable()
                    da.Fill(dt)

                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return dt
    End Function

    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function

    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Private Function Comprobar(ByVal Clase_Application As String) As Boolean

        Dim Objeto As Object

        ' Deshabilitar errores temporalmente   
        On Error Resume Next

        ' -- Crear una referencia al objeto   
        Objeto = CreateObject(Clase_Application)

        ' -- No dío error   
        If Err.Number <> 0 Then
            Comprobar = False
        Else
            ' .. error   
            Comprobar = True
            ' -- Eliminar  referencia   
            Objeto = Nothing
        End If

        ' -- Limpiar error   
        On Error GoTo 0

    End Function

    Public Function ArchivoToByte(ByVal strPath As String) As Byte()

        Dim ruta As New FileStream(strPath, FileMode.Open, FileAccess.Read)

        Dim binario(ruta.Length) As Byte

        ruta.Read(binario, 0, ruta.Length) 'Leo el archivo y lo convierto a binario 

        ruta.Close()

        Return binario

    End Function

    Public Function Encriptar(ByVal S As String, ByVal P As String) As String
        Dim I As Integer, R As String
        Dim C1 As Integer, C2 As Integer
        R = ""
        If Len(P) > 0 Then
            For I = 1 To Len(S)
                C1 = Asc(Mid(S, I, 1))
                If I > Len(P) Then
                    C2 = Asc(Mid(P, I Mod Len(P) + 1, 1))
                Else
                    C2 = Asc(Mid(P, I, 1))
                End If
                C1 = C1 + C2 + 64
                If C1 > 255 Then C1 = C1 - 256
                R = R + Chr(C1)
            Next I
        Else
            R = S
        End If
        Encriptar = R
    End Function

    Public Function Desencriptar(ByVal S As String, ByVal P As String) As String
        Dim I As Integer, R As String
        Dim C1 As Integer, C2 As Integer
        R = ""
        If Len(P) > 0 Then
            For I = 1 To Len(S)
                C1 = Asc(Mid(S, I, 1))
                If I > Len(P) Then
                    C2 = Asc(Mid(P, I Mod Len(P) + 1, 1))
                Else
                    C2 = Asc(Mid(P, I, 1))
                End If
                C1 = C1 - C2 - 64
                If Math.Sign(C1) = -1 Then C1 = 256 + C1
                R = R + Chr(C1)
            Next I
        Else
            R = S
        End If
        Desencriptar = R
    End Function

    Public Function GenerarTxtTelecredito()
        Try

            Dim Chesum As String, Contar As Integer, FechaPro As String, TotalNeto As Double, NroCta As String

            '     Chesum = LTrim(Str(Sum(Cast(Right(Personal.RemoverCaracter(B.NumCuentaAbono,'-'),11) As bigint))+Cast(Right(Personal.RemoverCaracter(@NumCta,'-'),10) As BigInt),15,0))

            ' Declare @Chesum Varchar(50),@Contar int,@FechaPro varchar(8), @TotalNeto money, @NroCta varchar(20)

            'Select @Chesum = LTrim(Str(Sum(Cast(Right(Personal.RemoverCaracter(B.NumCuentaAbono,'-'),11) As bigint))+Cast(Right(Personal.RemoverCaracter(@NumCta,'-'),10) As BigInt),15,0)),@Contar = Count(*), 
            '	   @FechaPro =  Personal.RemoverCaracter(CONVERT(varchar(10), @Fecha, 103),'/'),@TotalNeto = Sum(D.TotalNetoSol),
            '	   @NroCta = Personal.RemoverCaracter(@NumCta,'-')
            'From Planilla.PlanillaSueldosDet D Inner Join Personal.ContratoPersona B On B.IdPer = D.IdPer 
            'WHERE D.IdPlanilla = @IdPlanilla And B.CodBanAbono  = @CodBan 



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function ConvertirEnHoras(ByVal Minutos As Integer) As Double

        Dim resul As Double = 0
        Try
            resul = Math.Floor(Minutos / 60) + ((Minutos Mod 60) / 100)
            Return resul
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


End Module
