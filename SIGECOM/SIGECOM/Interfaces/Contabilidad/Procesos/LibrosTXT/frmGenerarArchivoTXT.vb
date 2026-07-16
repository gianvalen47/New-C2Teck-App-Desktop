Imports System.ServiceModel
Imports System.IO
Public Class frmGenerarArchivoTXT

    '===========================Servicios=================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient

    '======================Declaración de Variables=======================
    Private dtMeses As New DataTable
    Private dtLibros As New DataTable

    '======================= Nomenclatura de Libros ======================
    Dim P1P2 As String = "LE"                           'Identificador fijo LE
    Dim P3P12 As String = Session.sRucEmp               'RUC
    Dim P14P17 As String = ""                           'Año
    Dim P18P19 As String = ""                           'Mes
    Dim P20P21 As String = "00"                         'Día (Aplica al Libro Inventarios y Balances, demás es "00")
    Dim P22P27 As String = ""                           'Identificador del libro  
    Dim P28P29 As String = "00"                         'Código de oportunidad (Aplica al libro Inventarios y Balances, demás es "00")
    Dim P30 As String = "1"                             'Identificador de operaciones (1 Entidad Operativa)
    Dim P31 As String = ""                              'Indicador de contenido del LE (0-Vacio,1-Con información)
    Dim P32 As String = "1"                             'Indicador de la moneda (1-Nuevos Soles, 2-Dolares)
    Dim P33 As String = "1"                             'Indicador fijo "1"

    Dim Datos As Boolean                                'Valida si existen datos

    Private dtDatos As New DataTable
    Private Sub frmGenerarArchivoTXT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        txtAnio.Value = Today.Year
        cmbMes.Value = Today.Month
        txtAnio.Focus()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
           txtAnio.KeyPress,
           cmbMes.KeyPress,
           cmbLibro.KeyPress,
           cmbLibro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    '=============================Evento FormClosed==========================================
    Private Sub frmGenerarArchivoTXT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmGenerarArchivoTXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing



            '======================================= LIBROS ================================================
            dtLibros = New DataTable
            dtLibros.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtLibros.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtLibros.Rows.Add(New Object() {"050100", "Libro Diario"})
            dtLibros.Rows.Add(New Object() {"050300", "Libro Diario - Detalle de Plan Contable Utilizado"})
            dtLibros.Rows.Add(New Object() {"060100", "Libro Mayor"})
            dtLibros.Rows.Add(New Object() {"080100", "Registro de Compras"})
            dtLibros.Rows.Add(New Object() {"080200", "Registro de Compras - Operaciones con No Domiciliados"})
            dtLibros.Rows.Add(New Object() {"140100", "Registro de Ventas e Ingresos"}) ', New DateTime(2008, 2, 5)

            cmbLibro.DataSource = dtLibros
            cmbLibro.DropDownList.DataMember = dtLibros.Columns("nombre").ToString
            cmbLibro.DropDownList.DisplayMember = dtLibros.Columns("nombre").ToString
            cmbLibro.DropDownList.ValueMember = dtLibros.Columns("codigo").ToString
            cmbLibro.DropDownList.Columns(0).DataMember = dtLibros.Columns("codigo").ToString
            cmbLibro.DropDownList.Columns(1).DataMember = dtLibros.Columns("nombre").ToString
            cmbLibro.SelectedIndex = 0
            dtLibros = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtAnio.Value) = 0 Then
                MsgBox("Debe Ingresar el año", MsgBoxStyle.Information, "Información")
                txtAnio.Focus()
                Return False
            ElseIf toNumber(cmbMes.Value) = 0 Then
                MsgBox("Debe Ingresar el mes", MsgBoxStyle.Information, "Información")
                cmbMes.Focus()
                Return False
            ElseIf toBlank(cmbLibro.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Libro", MsgBoxStyle.Information, "Información")
                cmbLibro.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function GenerarNombreArchivo() As String
        Dim Nombre As String = ""
        Try

            P14P17 = toBlank(txtAnio.Value)
            P18P19 = toBlank(Format(cmbMes.Value, "00"))
            P22P27 = toBlank(cmbLibro.Value)
            P31 = IIf(Datos = True, "1", "0")
            Nombre = P1P2 + P3P12 + P14P17 + P18P19 + P20P21 + P22P27 + P28P29 + P30 + P31 + P32 + P33

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NOMBRE DE ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return Nombre
    End Function

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            ValidaCampos()

            '--------- Llenando Datos en la Grilla ----------
            dtDatos = oContabilidadService.LibrosContables(Session.sCodEmp, toNumber(txtAnio.Value), toNumber(cmbMes.Value), toBlank(cmbLibro.Value)).Tables(0)
            dgvDatos.DataSource = dtDatos
            '------------------------------------------------

            '-------- Verificando si hay datos --------
            Datos = IIf(dtDatos.Rows.Count > 0, True, False)
            '------------------------------------------

            Dim Seleccion As New SaveFileDialog
            Seleccion.Title = "Guardar archivo para los libros electronicos"
            Seleccion.Filter = "Archivos de texto |*.txt"
            Seleccion.FileName = GenerarNombreArchivo()

            If Seleccion.ShowDialog() = DialogResult.OK Then
                Dim Ruta As String = Seleccion.FileName

                Dim fichero As String = Ruta
                Dim archivo As New System.IO.StreamWriter(fichero)
                Dim Linea As String = Nothing

                Dim Row As Integer = 1

                If dgvDatos.Rows.Count > 0 Then

                    With dgvDatos
                        For i = 0 To .RowCount - 2


                            '==============================================
                            '------------- REGISTRO DE VENTAS -------------                        
                            If cmbLibro.Value = "140100" Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" & .Rows(i).Cells("campo8").Value & "|" &
                                    .Rows(i).Cells("campo9").Value & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo10").Value) & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo11").Value) & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo12").Value) & "|" &
                                    .Rows(i).Cells("campo13").Value & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo14").Value) & "|" &
                                    .Rows(i).Cells("campo15").Value & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo16").Value) & "|" &
                                    .Rows(i).Cells("campo17").Value & "|" & .Rows(i).Cells("campo18").Value & "|" &
                                    .Rows(i).Cells("campo19").Value & "|" & .Rows(i).Cells("campo20").Value & "|" &
                                    .Rows(i).Cells("campo21").Value & "|" & .Rows(i).Cells("campo22").Value & "|" &
                                    .Rows(i).Cells("campo23").Value & "|" & .Rows(i).Cells("campo24").Value & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo25").Value) & "|" &
                                    .Rows(i).Cells("campo26").Value & "|" & .Rows(i).Cells("campo27").Value & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo28").Value) & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo29").Value) & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo30").Value) & "|" &
                                    IIf(.Rows(i).Cells("campo35").Value = "2", "", .Rows(i).Cells("campo31").Value) & "|" &
                                    .Rows(i).Cells("campo32").Value & "|" & .Rows(i).Cells("campo33").Value & "|" &
                                    .Rows(i).Cells("campo34").Value & "|" & .Rows(i).Cells("campo35").Value & "|"



                                '==============================================
                                '------------ REGISTRO DE COMPRAS -------------
                            ElseIf cmbLibro.Value = "080100" Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" & .Rows(i).Cells("campo8").Value & "|" &
                                    .Rows(i).Cells("campo9").Value & "|" & .Rows(i).Cells("campo10").Value & "|" &
                                    .Rows(i).Cells("campo11").Value & "|" & .Rows(i).Cells("campo12").Value & "|" &
                                    .Rows(i).Cells("campo13").Value & "|" & .Rows(i).Cells("campo14").Value & "|" &
                                    .Rows(i).Cells("campo15").Value & "|" & .Rows(i).Cells("campo16").Value & "|" &
                                    .Rows(i).Cells("campo17").Value & "|" & .Rows(i).Cells("campo18").Value & "|" &
                                    .Rows(i).Cells("campo19").Value & "|" & .Rows(i).Cells("campo20").Value & "|" &
                                    .Rows(i).Cells("campo21").Value & "|" & .Rows(i).Cells("campo22").Value & "|" &
                                    .Rows(i).Cells("campo23").Value & "|" & .Rows(i).Cells("campo24").Value & "|" &
                                    .Rows(i).Cells("campo25").Value & "|" & .Rows(i).Cells("campo26").Value & "|" &
                                    .Rows(i).Cells("campo27").Value & "|" & .Rows(i).Cells("campo28").Value & "|" &
                                    .Rows(i).Cells("campo29").Value & "|" & .Rows(i).Cells("campo30").Value & "|" &
                                    .Rows(i).Cells("campo31").Value & "|" & .Rows(i).Cells("campo32").Value & "|" &
                                    .Rows(i).Cells("campo33").Value & "|" & .Rows(i).Cells("campo34").Value & "|" &
                                    .Rows(i).Cells("campo35").Value & "|" & .Rows(i).Cells("campo36").Value & "|" &
                                    .Rows(i).Cells("campo37").Value & "|" & .Rows(i).Cells("campo38").Value & "|" &
                                    .Rows(i).Cells("campo39").Value & "|" & .Rows(i).Cells("campo40").Value & "|" &
                                    .Rows(i).Cells("campo41").Value & "|" & .Rows(i).Cells("campo42").Value & "|"

                                '------------ REGISTRO DE COMPRAS NO DOMICILIADOS-------------
                            ElseIf cmbLibro.Value = "080200" Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" & .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" & .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" & .Rows(i).Cells("campo8").Value & "|" &
                                    .Rows(i).Cells("campo9").Value & "|" & .Rows(i).Cells("campo10").Value & "|" &
                                    .Rows(i).Cells("campo11").Value & "|" & .Rows(i).Cells("campo12").Value & "|" &
                                    .Rows(i).Cells("campo13").Value & "|" & .Rows(i).Cells("campo14").Value & "|" &
                                    .Rows(i).Cells("campo15").Value & "|" & .Rows(i).Cells("campo16").Value & "|" &
                                    .Rows(i).Cells("campo17").Value & "|" & .Rows(i).Cells("campo18").Value & "|" &
                                    .Rows(i).Cells("campo19").Value & "|" & .Rows(i).Cells("campo20").Value & "|" &
                                    .Rows(i).Cells("campo21").Value & "|" & .Rows(i).Cells("campo22").Value & "|" &
                                    .Rows(i).Cells("campo23").Value & "|" & .Rows(i).Cells("campo24").Value & "|" &
                                    .Rows(i).Cells("campo25").Value & "|" & .Rows(i).Cells("campo26").Value & "|" &
                                    .Rows(i).Cells("campo27").Value & "|" & .Rows(i).Cells("campo28").Value & "|" &
                                    .Rows(i).Cells("campo29").Value & "|" & .Rows(i).Cells("campo30").Value & "|" &
                                    .Rows(i).Cells("campo31").Value & "|" & .Rows(i).Cells("campo32").Value & "|" &
                                    .Rows(i).Cells("campo33").Value & "|" & .Rows(i).Cells("campo34").Value & "|" &
                                    .Rows(i).Cells("campo35").Value & "|" & .Rows(i).Cells("campo36").Value & "|"



                                '==============================================
                                '----------- LIBRO DIARIO Y MAYOR -------------
                            ElseIf cmbLibro.Value = "050100" Or cmbLibro.Value = "060100" Then

                                Linea = .Rows(i).Cells("campo1").Value & "|" &
                                    .Rows(i).Cells("campo2").Value + toBlank(Format(Row, "000000")) & "|" &
                                     "M" + toBlank(Format(Row, "000000")) & "|" &
                                    .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" & .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" & .Rows(i).Cells("campo8").Value & "|" &
                                    .Rows(i).Cells("campo9").Value & "|" & .Rows(i).Cells("campo10").Value & "|" &
                                    .Rows(i).Cells("campo11").Value & "|" & .Rows(i).Cells("campo12").Value & "|" &
                                    .Rows(i).Cells("campo13").Value & "|" & .Rows(i).Cells("campo14").Value & "|" &
                                    .Rows(i).Cells("campo15").Value & "|" & .Rows(i).Cells("campo16").Value & "|" &
                                    .Rows(i).Cells("campo17").Value & "|" & .Rows(i).Cells("campo18").Value & "|" &
                                    .Rows(i).Cells("campo19").Value & "|" & .Rows(i).Cells("campo20").Value & "|" &
                                    .Rows(i).Cells("campo21").Value & "|"

                                Row = Row + 1

                                '==============================================
                                '--------------- PLAN DE CUENTAS --------------                            
                            ElseIf cmbLibro.Value = "050300" Then
                                Linea = .Rows(i).Cells("campo1").Value & "|" &
                                    .Rows(i).Cells("campo2").Value & "|" &
                                    .Rows(i).Cells("campo3").Value & "|" &
                                    .Rows(i).Cells("campo4").Value & "|" &
                                    .Rows(i).Cells("campo5").Value & "|" &
                                    .Rows(i).Cells("campo6").Value & "|" &
                                    .Rows(i).Cells("campo7").Value & "|" &
                                    .Rows(i).Cells("campo8").Value & "|"
                            End If

                            archivo.WriteLine(Linea)
                        Next
                    End With

                End If


                archivo.Close()
                MsgBox("Se descargo exitosamente")
                'Finalizar()

            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO TXT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class