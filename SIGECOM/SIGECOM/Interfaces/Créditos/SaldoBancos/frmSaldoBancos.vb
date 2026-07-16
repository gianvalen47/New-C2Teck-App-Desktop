Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmSaldoBancos

    Inherits System.Windows.Forms.Form

    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public Delimiter As String = ","
    Public Qualifier As String = """"
    Private dtBancos As DataTable
    Private dtCuentas As DataTable
    Private dtMostrar As DataTable
    Private dtCobrador As DataTable
    Private Cuenta As String
    Private Moneda As String
    Private CodMon As String
    Private TipoCuenta As String
    Private dtTable As New DataTable
    Private section As MySection

    Private CodBan As String
    Private DesBan As String
    Private CodCuenta As String
    Private CondError As String

    Private Function SplitDelimitedLine(ByVal CurrentLine As String, ByVal Delimiter As String, ByVal Qualifier As String) As Collection

        ''/////Se separan los valores entre "" y "," de cada fila
        '----------------------------------------------------------

        Dim i As Integer
        Dim SplitString As New Collection()
        Dim CountDelimiter As Boolean
        Dim Total As Integer
        Dim Ch As Char
        Dim Section As String

        ' We want to count the delimiter unless it is within the text qualifier
        CountDelimiter = True
        Total = 0
        Section = ""

        For i = 1 To Len(CurrentLine)

            Ch = Mid(CurrentLine, i, 1)
            Select Case Ch
                Case Qualifier
                    If CountDelimiter Then
                        CountDelimiter = False
                    Else
                        CountDelimiter = True
                    End If
                Case Delimiter
                    If CountDelimiter Then
                        ' Add current section to collection
                        SplitString.Add(New MySection(Section))
                        Section = ""
                        Total = Total + 1
                    End If
                Case Else
                    Section = Section & Ch
            End Select
        Next

        ' Get the last field - as most files will not have an ending delimiter
        If CountDelimiter Then
            ' Add current section to collection
            SplitString.Add(New MySection(Section))
        End If

        SplitDelimitedLine = SplitString

    End Function

    Private Sub CargadoDetalle()

        ''///Se Carga el table como ha sido traido del *.txt
        '----------------------------------------------------------
        Dim FileName As String = txtDirFile.Text

        Dim IgnoreLines As Integer = 4

        'Dim ts As StreamReader
        Dim ts As IO.StreamReader '= New IO.StreamReader(FileName, System.Text.Encoding.Default)
        'Dim tw As StreamWriter
        Dim CurrentLine As String
        Dim SampleLines(120) As String
        ' Read only the first 70 lines
        ' to get a feel for how many columns is needed.
        Dim i As Integer
        Dim j As Integer
        Dim MaxCols As Integer
        Dim SeparatedLine As Collection
        Dim section As MySection
        Dim tabla As New DataTable
        Dim fila As DataRow

        ' Open the file and assign to a streamreader.
        'ts = File.OpenText(FileName)
        ts = New IO.StreamReader(FileName, System.Text.Encoding.Default)
        'tw = File.OpenText(FileName, "false", System.Text.Encoding.UTF8)
        ' Set maximum columns to 0
        MaxCols = 0
        j = 0

        For i = 1 To 120 + IgnoreLines
            CurrentLine = ts.ReadLine
            SeparatedLine = SplitDelimitedLine(CurrentLine, Delimiter, Qualifier)

            If i > IgnoreLines Then
                ' Keep line for later (data)
                SampleLines(j) = CurrentLine
                j = j + 1
            End If
        Next

        tabla.Columns.Add(("Fecha").ToString)
        tabla.Columns.Add(("Fecha Valuta").ToString)
        tabla.Columns.Add(("Descripción - Operación").ToString)
        tabla.Columns.Add(("Monto").ToString)
        tabla.Columns.Add(("Saldo").ToString)
        tabla.Columns.Add(("Sucursal - Agencia").ToString)
        tabla.Columns.Add(("Operación - Número").ToString)
        tabla.Columns.Add(("Operación - Hora").ToString)
        tabla.Columns.Add(("Usuario").ToString)
        tabla.Columns.Add(("UTC").ToString)
        tabla.Columns.Add(("Referencia2").ToString)

        For l As Integer = 1 To j
            'For l As Integer = 1 To SeparatedLine.Count - 1

            If SampleLines(l) <> "" Then
                SeparatedLine = SplitDelimitedLine(SampleLines(l), Delimiter, Qualifier)
                fila = tabla.NewRow()
                For k As Integer = 0 To SeparatedLine.Count - 2
                    section = CType(SeparatedLine(k + 1), MySection)
                    fila(k) = section.Section
                Next
                tabla.Rows.Add(fila)
            End If
        Next

        dgvDatos.DataSource = tabla

        dtTable = tabla

        ts.Close()
        section = Nothing

        CargarArchivo()

    End Sub

    Private Sub TraerCuenta()

        ''// Se trae el Banco, Nro de Cuenta y la Moneda del *.txt
        '----------------------------------------------------------
        Dim FileName As String = txtDirFile.Text

        Dim IgnoreLinesTitulo As Integer = 0

        'Dim ts As StreamReader
        Dim ts As IO.StreamReader ''New IO.StreamReader(FileName, System.Text.Encoding.Default)
        Dim CurrentLine As String
        Dim SampleLinesTitulos(3) As String
        Dim i As Integer
        Dim j As Integer
        Dim MaxCols As Integer
        Dim SeparatedLine As Collection
        Dim section As MySection
        Dim tabla As New DataTable
        Dim fila As DataRow

        ' Open the file and assign to a streamreader.
        ts = New IO.StreamReader(FileName, System.Text.Encoding.Default)
        ' Set maximum columns to 0
        MaxCols = 0
        j = 0
        ' Read only the first 8 lines
        ' to get a feel for how many columns is needed.

        For i = 1 To 3 + IgnoreLinesTitulo
            CurrentLine = ts.ReadLine
            SeparatedLine = SplitDelimitedLine(CurrentLine, Delimiter, Qualifier)
            If i > IgnoreLinesTitulo Then
                ' Keep line for later (data)
                SampleLinesTitulos(j) = CurrentLine
                j = j + 1
            End If
        Next

        tabla.Columns.Add(("Titulo").ToString)
        tabla.Columns.Add(("Descripción").ToString)

        For l As Integer = 0 To j
            'For l As Integer = 1 To SeparatedLine.Count - 1

            If SampleLinesTitulos(l) <> "" Then
                SeparatedLine = SplitDelimitedLine(SampleLinesTitulos(l), Delimiter, Qualifier)

                fila = tabla.NewRow()

                For k As Integer = 0 To SeparatedLine.Count - 2
                    section = CType(SeparatedLine(k + 1), MySection)
                    fila(k) = section.Section

                    If k = 1 And l = 0 Then
                        Cuenta = fila(k)
                    ElseIf k = 1 And l = 1 Then
                        Moneda = fila(k)
                    ElseIf k = 1 And l = 2 Then
                        TipoCuenta = fila(k)
                    End If
                Next

                tabla.Rows.Add(fila)
            End If
        Next

        ts.Close()
        section = Nothing

        ComprobarCuenta()

    End Sub

    Private Sub ComprobarCuenta()

        ''///Se comprueba que el Numero de Cuenta del txt coincide con lo que trae el Sistema
        '----------------------------------------------------------
        If Mid(Cuenta, 1, 16) <> txtCuenta.Text Then
            txtDirFile.Select()
            MsgBox("El Tipo de Cuenta no es el mismo ... por favor corrobore si ha seleccionado el archivo correcto : ", MsgBoxStyle.Information)
        Else
            CargadoDetalle()
        End If
    End Sub

    Private Sub frmSaldoBancos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oPlanillaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oPlanillaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oPlanillaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmSaldoBancos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            TabCuentas.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F2 Then
            TabCuentas.SelectedIndex = "1"
        ElseIf e.KeyCode = Keys.F3 Then
            TabCuentas.SelectedIndex = "2"
            'ElseIf e.KeyCode = Keys.P Then
            '    btnImprimir_Click(sender, e)
            'ElseIf e.KeyCode = Keys.C Then
            '    btnExaminar_Click(sender, e)
        End If
    End Sub

    Private Sub frmSaldoBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 42)
        '/*************************************************************************************/

        ListarDatos()
    End Sub

    Private Sub TabOpciones_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles TabCuentas.SelectedTabChanged
        SeleccionTab(TabCuentas.SelectedIndex)
    End Sub

    Private Sub SeleccionTab(ByVal Indice As Int16)
        Select Case TabCuentas.SelectedIndex
            Case 0 'Banco
                Try
                    ListarDatos()

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try
            Case 1 'Cuentas
                Try
                    If dgvBancos.CurrentRow.Cells("CodBan").Text = "" Then
                        MsgBox("Debe Seleccionar el Banco...", MsgBoxStyle.Information)
                        SeleccionTab(0)
                    Else
                        CodBan = dgvBancos.CurrentRow.Cells("CodBan").Text
                        DesBan = dgvBancos.CurrentRow.Cells("DesBan").Text
                        txtBanco.Text = DesBan
                        TabDetalles.Enabled = True
                        ListarCuentas()
                    End If

                    RowPossesion(dgvCuentas)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try

            Case 2 'Detalle
                Try

                    ListarTransaccionesBanco()
                    LlenarCobrador()
                    txtDirFile.Text = ""
                    txtBanco2.Text = DesBan
                    txtCuenta.Text = dgvCuentas.CurrentRow.Cells("NumCta").Text
                    txtMoneda.Text = dgvCuentas.CurrentRow.Cells("DesMon").Text
                    CodMon = dgvCuentas.CurrentRow.Cells("CodMon").Text

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
                End Try

        End Select
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            lista.Row = 1
            lista.Col = 1

        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ListarDatos()
        Try
            dtBancos = oPlanillaService.MostrarBancos().Tables(0)
            dgvBancos.DataSource = dtBancos
            dgvBancos.Select()

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarCuentas()
        Try
            dtCuentas = oPlanillaService.MostrarCuentas(CodBan).Tables(0)
            dgvCuentas.DataSource = dtCuentas
            dgvCuentas.Select()

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarTransaccionesBanco()
        Try
            dtMostrar = oPlanillaService.MostrarTransaccionBanco(CodBan, dgvCuentas.CurrentRow.Cells("NumCta").Text, Today.Year).Tables(0)
            dgvDatosFin.DataSource = dtMostrar

            'MostrarDetalleFinal()

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CargadoFinal()

        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".txt") Then
                MsgBox("Solo se aceptan archivos de Text (.txt) ... ", MsgBoxStyle.Information)
                Exit Sub
            Else
                TraerCuenta()
            End If
        End If

    End Sub

    Private Sub CargarArchivo()

        ''///Se Carga el Archivo 
        '----------------------------------------------------------

        Try
            Dim row As Janus.Windows.GridEX.GridEXRow

            If dgvDatos.RowCount <> 0 Then

                For i As Integer = 0 To Me.dgvDatos.RowCount - 1
                    Me.dgvDatos.Row = i
                    row = Me.dgvDatos.GetRow()

                    Dim registro As New PlanillaService.TransaccionBancos
                    Dim Banco As New PlanillaService.Banco

                    Banco.CodBan = Trim(CodBan)
                    registro.Banco = Banco
                    registro.NumCta = Trim(txtCuenta.Text)
                    registro.Fecha = IIf(row.Cells("Fecha").Text = "", Nothing, CDate(row.Cells("Fecha").Text))
                    If row.Cells("Fecha Valuta").Text = "" Then
                        registro.FecVal = Nothing
                    Else : registro.FecVal = row.Cells("Fecha Valuta").Text
                    End If
                    registro.Referencia = Trim(row.Cells("Descripción operación").Text)
                    If Mid(row.Cells("Monto").Text, 1, 1) = "-" Then
                        registro.Cargo = (CDbl(row.Cells("Monto").Text) * -1)
                        registro.Abono = 0
                    Else
                        registro.Abono = CDbl(row.Cells("Monto").Text)
                        registro.Cargo = 0
                    End If
                    registro.Saldo = CDbl(row.Cells("Saldo").Text)
                    registro.SucAge = Trim(row.Cells("Sucursal - agencia").Text)
                    registro.NumOpe = Trim(row.Cells("Operación - Número").Text)
                    registro.Hora = row.Cells("Operación - Hora").Text
                    registro.Usuario = Trim(row.Cells("Usuario").Text)
                    registro.Utc = Trim(row.Cells("UTC").Text)

                    Insertar(registro)

                Next

                If CondError = "T" Then
                    MsgBox("Error al Efectuar el Cargado", MsgBoxStyle.Exclamation)
                    'dgvDatosFinal.DataSource = Nothing
                    'EstadoImprimir = False
                ElseIf CondError = "F" Then
                    'MsgBox("Ya se habia cargado este Archivo", MsgBoxStyle.Information)
                    'dgvDatosFinal.DataSource = Nothing
                    'EstadoImprimir = True
                Else
                    'MsgBox("Se Cargo correctamente el Archivo", MsgBoxStyle.Information)
                    'EstadoImprimir = True
                End If

                ListarTransaccionesBanco()

            End If

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR EL ARCHIVO : " + ex.Message)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaService.TransaccionBancos)
        Try
            Dim estado_process As Integer

            estado_process = oPlanillaService.InsertarTransaccionBanco(registro)

            If estado_process > 0 Then
                'MsgBox("Se Cargo correctamente el Archivo")
            Else
                CondError = "F"
                'MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!" + ex.Message, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            CondError = "T"
            'MsgBox("ERROR AL EFECTUAR LA TRANSACCIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarDetalleFinal()

        'Dim row As Janus.Windows.GridEX.GridEXRow

        'For i As Integer = 0 To Me.dgvDatosFin.RowCount - 1
        '    Me.dgvDatosFin.Row = i
        '    row = Me.dgvDatosFin.GetRow()

        '    If row.Cells("Cargo").Text = "0.00" Then
        '        row.Cells("Cargo1").Text = ""
        '    Else
        '        row.Cells("Cargo1").Text = row.Cells("Cargo").Text
        '    End If

        '    If row.Cells("Abono").Text = "0.00" Then
        '        row.Cells("Abono1").Text = ""
        '    Else
        '        row.Cells("Abono1").Text = row.Cells("Abono").Text
        '    End If

        'Next

        '' ''For i As Integer = 0 To Me.dgvDatosFin2.Rows.Count - 1

        '' ''    If dgvDatosFin2.Rows(i).Cells("Cargo").Value = "0.00" Then
        '' ''        dgvDatosFin2.Rows(i).Cells("Cargo1").Value = ""
        '' ''    Else
        '' ''        dgvDatosFin2.Rows(i).Cells("Cargo1").Value = dgvDatosFin2.Rows(i).Cells("Cargo").Value
        '' ''    End If

        '' ''    If dgvDatosFin2.Rows(i).Cells("Abono").Value = "0.00" Then
        '' ''        dgvDatosFin2.Rows(i).Cells("Abono1").Value = ""
        '' ''    Else
        '' ''        dgvDatosFin2.Rows(i).Cells("Abono1").Value = dgvDatosFin2.Rows(i).Cells("Abono").Value
        '' ''    End If

        '' ''Next

    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Try
            If txtBanco2.Text <> "" And txtCuenta.Text <> "" Then
                Dim frm As New frmSaldoBancos_Imprimir
                frm.CodBan = CodBan
                frm.CodCuenta = txtCuenta.Text
                frm.dtMostrarFinal = dtMostrar
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvBancos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBancos.DoubleClick
        Try
            If dgvBancos.RowCount > 0 Then
                TabCuentas.SelectedIndex = "1"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvBancos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBancos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                If dgvBancos.RowCount > 0 Then
                    TabCuentas.SelectedIndex = "1"
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvCuentas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCuentas.DoubleClick
        Try
            If dgvCuentas.RowCount > 0 Then
                TabCuentas.SelectedIndex = "2"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCuentas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvCuentas.RowCount > 0 Then
                    TabCuentas.SelectedIndex = "2"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDirFile.Text = OpenFileDialog1.FileName
            CargadoFinal()

        End If
    End Sub

    Private Sub dgvDatosFin_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosFin.CellUpdated

        Try
            Dim estado_process As Boolean
            Dim ExistePlanilla As Boolean
            Dim IdPersona As Integer
            Dim codigo As String
            codigo = dgvDatosFin.CurrentRow.Cells("IdSaldo").Text

            If Not (dgvDatosFin.CurrentRow.Cells("NumPla").Text = "") Then

                ExistePlanilla = oPlanillaService.Buscar(Session.sCodEmp, dgvDatosFin.CurrentRow.Cells("NumPla").Text)

                If ExistePlanilla = True Then

                    If dgvDatosFin.CurrentRow.Cells("IdPer").Text = "" Then
                        IdPersona = 0
                    Else
                        IdPersona = dgvDatosFin.CurrentRow.Cells("IdPer").Value
                    End If

                    estado_process = oPlanillaService.ActualizarTransaccionBancos(Session.sCodEmp, dgvDatosFin.CurrentRow.Cells("IdSaldo").Text, dgvDatosFin.CurrentRow.Cells("NumPla").Text, IdPersona, dgvDatosFin.CurrentRow.Cells("Observacion").Text)

                    If estado_process = True Then

                    Else
                        MsgBox("Error al Actualizar la Planilla...")
                        dgvDatosFin.CurrentRow.Cells("NumPla").Text = ""
                    End If

                Else
                    MsgBox("El Número de Planilla No Existe..., Verifique")
                    dgvDatosFin.CurrentRow.Cells("NumPla").Text = ""
                End If
            Else

            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar la Planilla: " + ex.Message)
        End Try
    End Sub

    Private Sub RowPossesion2(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdSaldo").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LlenarCobrador()

        '==================================COBRADOR======================================================
        dtCobrador = oMaestroService.MostrarCobradores.Tables(0)

        Dim column As GridEXColumn

        column = dgvDatosFin.RootTable.Columns("IdPer")
        column.ValueList.PopulateValueList(dtCobrador.DefaultView, "IdPer", "ApeNom")

    End Sub

    Private Sub dgvDatosFin_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatosFin.ColumnButtonClick

        'If e.Column.Key = "Guardar" Then

        '    Try
        '        Dim estado_process As Boolean
        '        Dim ExistePlanilla As Boolean
        '        Dim codigo As String
        '        codigo = dgvDatosFin.CurrentRow.Cells("IdSaldo").Text

        '        If Not (dgvDatosFin.CurrentRow.Cells("NumPla").Text = "") Then

        '            ExistePlanilla = oPlanillaService.Buscar(Session.sCodEmp, dgvDatosFin.CurrentRow.Cells("NumPla").Text)

        '            If ExistePlanilla = True Then

        '                estado_process = oPlanillaService.ActualizarTransaccionBancos(Session.sCodEmp, dgvDatosFin.CurrentRow.Cells("IdSaldo").Text, dgvDatosFin.CurrentRow.Cells("NumPla").Text, dgvDatosFin.CurrentRow.Cells("IdPer").Value, dgvDatosFin.CurrentRow.Cells("Observacion").Text)

        '                If estado_process = True Then

        '                Else
        '                    MsgBox("Error al Actualizar la Planilla...")
        '                    dgvDatosFin.CurrentRow.Cells("NumPla").Text = ""
        '                End If

        '            Else
        '                MsgBox("El Numero de Planilla No Existe..., Verifique")
        '                dgvDatosFin.CurrentRow.Cells("NumPla").Text = ""
        '            End If
        '        Else

        '        End If

        '    Catch ex As Exception
        '        MsgBox("Error al Actualizar la Planilla: " + ex.Message)
        '    End Try

        'Else
        'If e.Column.Key = "Print" Then

        '    Dim IdSaldo As String
        '    IdSaldo = dgvDatosFin.CurrentRow.Cells("IdSaldo").Value

        '    Try
        Try
            If e.Column.Key = "Print" Then

                Dim IdSaldo As String
                Dim Saldo As Double
                Dim TituloSaldo As String

                IdSaldo = dgvDatosFin.CurrentRow.Cells("IdSaldo").Value

                Dim forma As New frmReportes
                Dim reporte As New rptSaldoBancoUnit
                Dim dtReporte As New DataTable

                dtReporte = oPlanillaService.ImprimirFila(IdSaldo).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Imprimir Transacción Banco"

                    If utils.toDouble(dgvDatosFin.CurrentRow.Cells("Cargo").Text) = 0.0 Then
                        TituloSaldo = "Abono"
                    Else : TituloSaldo = "Cargo"
                    End If
                    Saldo = utils.toDouble(dgvDatosFin.CurrentRow.Cells("Cargo").Text) + utils.toDouble(dgvDatosFin.CurrentRow.Cells("Abono").Text)


                    reporte.SetParameterValue("TituloSaldo", TituloSaldo)
                    reporte.SetParameterValue("Saldo", Saldo)
                    reporte.SetParameterValue("Moneda", CodMon)
                    reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    'reporte.SetParameterValue("DesMotor", "Modelo Motor:")
                    'reporte.SetParameterValue("DesCli", "Cliente")

                    'reporte.SetParameterValue("DesMotor", "Modelo Motor:")
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                    forma.ShowDialog()
                    'forma.crvReportes.PrintReport()

                    End If

            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class

Public Class MySection

    Public Section As String
    Sub New(ByVal newName As String)
        Section = newName
    End Sub

End Class