
Imports Janus.Windows.GridEX
Imports System.ServiceModel

Public Class frmResultadosEncuestaSis_Nuevo

    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    'Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    'Dim oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient

    Private dtDatos As New DataTable
    Private dtSistemas As New DataTable
    Private dtRespuesta As New DataTable
    Private IdPersona As Integer
    Private dtTemporal As DataTable
    Private IdRespuestaTemp As Integer
    Private RespuestaTemp As String
    Private fila As Integer
    Private filaC As String
    Private EncuestaActiva As Integer
    Private IdEncuesta As Integer
    Private totalfila As Integer = 0
    Private anonimo As Boolean


    Private Sub frmResultadosEncuestaSis_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmResultadosEncuestaSis_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmResultadosEncuestaSis_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenarCombos()
        ObtenerEncuestaActiva()
        listaDatos()
        ObtenerObjetivo()
        ObtenerPersona()
    End Sub

    'Private Sub llenarCombos()
    '    Try
    '        '------------------------------- Aplicacion --------------------------------------------
    '        dtSistemas = oSeguridadService.MostrarSistemas.Tables(0)
    '        cmbSistema.DataSource = dtSistemas
    '        cmbSistema.DropDownList.DataMember = dtSistemas.Columns("NomSis").ToString
    '        cmbSistema.DropDownList.DisplayMember = dtSistemas.Columns("NomSis").ToString
    '        cmbSistema.DropDownList.ValueMember = dtSistemas.Columns("IdSistema").ToString
    '        cmbSistema.DropDownList.Columns(0).DataMember = dtSistemas.Columns("IdSistema").ToString
    '        cmbSistema.DropDownList.Columns(1).DataMember = dtSistemas.Columns("NomSis").ToString
    '        cmbSistema.SelectedIndex = 0
    '        dtSistemas = Nothing

    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub ObtenerObjetivo()

        Try
            Dim registro As EncuestaService.Encuesta
            registro = oEncuestaSistema.Obtener(IdEncuesta)

            txtObjetivo.Text = registro.Objetivo
            anonimo = registro.Anonimo

            'txtFecInicio.Value = registro.FecInicio
            'txtFecFinal.Value = registro.FecFinal

            Me.Text = "Encuesta" '' + registro.IdEncuesta.ToString
            'Me.Text = "Encuesta Nº " + registro.IdEncuesta.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerEncuestaActiva()
        'Se ingresa Sistema "1" porque el sigecom es 1 
        EncuestaActiva = oEncuestaSistema.MostrarVigente(1)
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oEncuestaSistema.MostrarActivo(EncuestaActiva).Tables(0)
            dgvDatos.DataSource = dtDatos

            IdEncuesta = dgvDatos.CurrentRow.Cells("IdEncuesta").Text
            'dgvDatoTemporal.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub mostrar()
        Try
            Dim frm As New frmResultadosEncuestaSis_Respuesta

            'If e.Column.Key = "Grafica" Then

            frm.IdPregunta = dgvDatos.CurrentRow.Cells("IdPregunta").Text
            frm.Tipo = dgvDatos.CurrentRow.Cells("Tipo").Text

            'If dgvDatos.CurrentRow.Cells("Tipo").Text = "1" Then
            '    frm.Tipo = "Descriptiva"
            'Else
            '    frm.Tipo = "Selectiva"
            'End If

            For i = 0 To dgvDatos.RowCount - 1
                fila = dgvDatos.CurrentRow.RowIndex.ToString()
            Next

            For i = 0 To dgvDatos.RowCount - 1
                filaC = dgvDatos.CurrentRow.Cells("Respuesta").Text
            Next

            If dgvDatos.CurrentRow.Cells("Tipo").Text = "Selectiva" Then
                If filaC = "" Then
                    frm.filaA = 1
                Else
                    frm.filaA = dgvDatos.CurrentRow.Cells("IdRespuesta").Text
                End If
            ElseIf dgvDatos.CurrentRow.Cells("Tipo").Text = "Descriptiva" Then

                frm.txtRespuestaDesc.Text = dgvDatos.CurrentRow.Cells("Respuesta").Text
                'ElseIf dgvDatos.CurrentRow.Cells("Tipo").Text = "Descriptiva" Then
            End If

            'frm.filaA = fila

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdRespuestaTemp = frm.IdPreguntaTempE
                RespuestaTemp = frm.RespuestaTempE
                ActualizarGrillaTemporal()
            End If

            'End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            Dim frm As New frmResultadosEncuestaSis_Respuesta

            If e.Column.Key = "Grafica" Then

                frm.IdPregunta = dgvDatos.CurrentRow.Cells("IdPregunta").Text
                frm.Tipo = dgvDatos.CurrentRow.Cells("Tipo").Text

                'If dgvDatos.CurrentRow.Cells("Tipo").Text = "1" Then
                '    frm.Tipo = "Descriptiva"
                'Else
                '    frm.Tipo = "Selectiva"
                'End If

                For i = 0 To dgvDatos.RowCount - 1
                    fila = dgvDatos.CurrentRow.RowIndex.ToString()
                Next

                For i = 0 To dgvDatos.RowCount - 1
                    filaC = dgvDatos.CurrentRow.Cells("Respuesta").Text
                Next

                If dgvDatos.CurrentRow.Cells("Tipo").Text = "Selectiva" Then
                    If filaC = "" Then
                        frm.filaA = 1
                    Else
                        frm.filaA = dgvDatos.CurrentRow.Cells("IdRespuesta").Text
                    End If
                ElseIf dgvDatos.CurrentRow.Cells("Tipo").Text = "Descriptiva" Then

                    frm.txtRespuestaDesc.Text = dgvDatos.CurrentRow.Cells("Respuesta").Text
                    'ElseIf dgvDatos.CurrentRow.Cells("Tipo").Text = "Descriptiva" Then
                End If

                'frm.filaA = fila

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdRespuestaTemp = frm.IdPreguntaTempE
                    RespuestaTemp = frm.RespuestaTempE
                    ActualizarGrillaTemporal()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarGrillaTemporal()

        Dim dt As DataTable = DirectCast(dgvDatos.DataSource, DataTable)
        dgvDatoTemporal.DataSource = dt

        Dim row As DataRow

        Dim dtCopia As New DataTable("tabla")
        'dtCopia.Columns.Add(New DataColumn("IdSistema", Type.GetType("System.Int32")))
        'dtCopia.Columns.Add(New DataColumn("NomSis", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("IdPregunta", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("IdEncuesta", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Activo", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("IdRespuesta", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Respuesta", Type.GetType("System.String")))



        dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "1"})

        dtDatos = dtCopia.Copy
        dtDatos.Clear()

        'Dim filaNueva As System.Data.DataRow
        Dim numCols As Integer

        numCols = dt.Columns.Count

        For i As Integer = 0 To dgvDatoTemporal.Rows.Count - 2
            'For i = 0 To numCols - 1
            'filaNueva = dtDatosfinal.NewRow()
            row = dtDatos.NewRow
            'filaNueva = dtDatos.NewRow()
            For j As Integer = 0 To numCols - 1
                If i = fila And j = 5 Then
                    row(j) = IdRespuestaTemp
                ElseIf i = fila And j = 6 Then
                    row(j) = RespuestaTemp
                Else
                    row(j) = dgvDatoTemporal.Rows(i).Cells(j).Value
                End If
            Next
            dtDatos.Rows.Add(row)
        Next

        dgvDatoTemporal.DataSource = dtDatos
        dgvDatos.DataSource = dtDatos

    End Sub


    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    'Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
    '    Try
    '        dtRespuesta = oEncuestaSistema.MostrarRespuesta(dgvDatos.CurrentRow.Cells("IdPregunta").Text).Tables(0)
    '        DataGridView1.DataSource = dtRespuesta

    '        'Dim column As GridEXColumn

    '        'column = dgvDatos.RootTable.Columns("IdRespuesta")
    '        'column.ValueList.PopulateValueList(dtRespuesta.DefaultView, "IdRespuesta", "Descripcion")


    '        'column.ValueList.PopulateValueList(dtRespuesta.DefaultView, "IdRespuesta", "Descripcion")
    '        'column.ValueList.PopulateValueList(dtRespuesta.DefaultView, "IdRespuesta", "Descripcion")


    '        'For i As Integer = 0 To dgvDatos.RowCount


    '        Dim cell As GridEXCell
    '        cell = dgvDatos.CurrentRow.Cells("IdPregunta")

    '        If dgvDatos.CurrentRow.Cells("Descripcion").Text = "Sugerencias" Then

    '            'dgvDatos.RootTable.c()

    '            cell.Column.EditType = EditType.TextBox
    '            cell.Column.FilterEditType = FilterEditType.TextBox
    '            cell.Column.ButtonDisplayMode = CellButtonDisplayMode.CurrentCell
    '            cell.Column.HasValueList = False
    '            cell.Column.PrintMode = ColumnPrintMode.PrintWhenVisible
    '            cell.Column.EditButtonDisplayMode = CellButtonDisplayMode.EditingCell
    '            cell.Column.EditTarget = EditTarget.Value

    '            'dgvDatos.RootTable.Columns("IdRespuesta").EditType = EditType.TextBox
    '            'dgvDatos.RootTable.Columns("IdRespuesta").FilterEditType = EditType.TextBox
    '            'dgvDatos.RootTable.Columns("IdRespuesta").ButtonDisplayMode = CellButtonDisplayMode.CurrentCell
    '            'dgvDatos.RootTable.Columns("IdRespuesta").HasValueList = False
    '            'dgvDatos.RootTable.Columns("IdRespuesta").PrintMode = ColumnPrintMode.PrintWhenVisible
    '            'dgvDatos.RootTable.Columns("IdRespuesta").EditButtonDisplayMode = CellButtonDisplayMode.EditingCell
    '            'dgvDatos.RootTable.Columns("IdRespuesta").EditTarget = EditTarget.Value

    '        Else

    '            cell.Column.EditType = EditType.Combo
    '            cell.Column.FilterEditType = FilterEditType.Combo

    '            'dgvDatos.RootTable.Columns("IdRespuesta").EditType = EditType.Combo
    '            'dgvDatos.RootTable.Columns("IdRespuesta").FilterEditType = EditType.Combo
    '            'dgvDatos.RootTable.Columns("IdRespuesta").ButtonDisplayMode = CellButtonDisplayMode.Always
    '            'dgvDatos.RootTable.Columns("IdRespuesta").HasValueList = True
    '            'dgvDatos.RootTable.Columns("IdRespuesta").PrintMode = ColumnPrintMode.PrintAlways
    '            'dgvDatos.RootTable.Columns("IdRespuesta").EditButtonDisplayMode = CellButtonDisplayMode.Always
    '            'dgvDatos.RootTable.Columns("IdRespuesta").EditTarget = EditTarget.Text

    '            'Dim column As GridEXColumn

    '            'column = dgvDatos.RootTable.Columns("IdRespuesta")
    '            'column.ValueList.PopulateValueList(dtRespuesta.DefaultView, "IdRespuesta", "Descripcion")


    '            'cell.Column.ValueList.PopulateValueList(dtRespuesta.DefaultView, "IdRespuesta", "Descripcion")
    '            'cell.Column.ValueList.PopulateValueList(dtRespuesta.DefaultView, "IdRespuesta", "Descripcion")
    '        End If
    '        'Next

    '    Catch ex As Exception
    '        MsgBox("ERROR AL MOSTRAR LA ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub ObtenerPersona()

        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        'txtPersonaSolicita.Text = usuario.Persona.ApeNom
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR la encuesta?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidaCampos() Then

                For j As Integer = 0 To dgvDatos.RowCount - 1

                    Dim registro As New EncuestaService.Resultado
                    Dim persona As New EncuestaService.Persona
                    Dim respuesta As New EncuestaService.Respuesta
                    Dim pregunta As New EncuestaService.Pregunta

                    pregunta.IdPregunta = dgvDatoTemporal.Item("IdPregunta".ToLower, j).Value()
                    'Item("IdPregunta".ToLower, j).Value()

                    pregunta.Descripcion = dgvDatoTemporal.Item("Descripcion".ToLower, j).Value()
                    registro.Pregunta = pregunta
                    persona.IdPer = IIf(anonimo, Nothing, IdPersona)
                    registro.Persona = persona
                    If dgvDatoTemporal.Item("Tipo".ToLower, j).Value() = "Descriptiva" Then
                        respuesta.IdRespuesta = Nothing
                    Else
                        respuesta.IdRespuesta = CInt(dgvDatoTemporal.Item("IdRespuesta".ToLower, j).Value())
                    End If

                    'respuesta.Descripcion = DataGridView1.Item("Respuesta".ToLower, j).Value()
                    registro.Descripcion = dgvDatoTemporal.Item("Respuesta".ToLower, j).Value()
                    registro.Respuesta = respuesta
                    'registro.Respuesta = respuesta

                    'persona.IdPer = IdPersona
                    'registro.Persona = persona
                    registro.Fecha = Today.Date
                    registro.CodUsu = IIf(anonimo, Nothing, Session.sCodUsu)
                    registro.NomPc = IIf(anonimo, Nothing, Session.sNomPc)
                    registro.DirIp = IIf(anonimo, Nothing, Session.sDirIp)

                    Insertar(registro)

                Next

                '////////////ACTUALIZAR ENCUESTA REALIZADA DEL USUARIO//////////
                oEncuestaSistema.CerrarUsuario(IdEncuesta, Session.sCodUsu)
                '///////////////////////////////////////////////////////////////


                'MsgBox("Se guardo la encuesta correctamente", MsgBoxStyle.Information, "Información")
                If totalfila = dgvDatos.RowCount Then
                    MsgBox("Se guardo la encuesta correctamente." & Environment.NewLine & _
                           "" & Environment.NewLine & _
                           "GRACIAS POR PARTICIPAR", MsgBoxStyle.Information, "Información")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'MDIPrincipal.Show()
                Else
                    MsgBox("ERROR AL GUARDAR LA ENCUESTA: ", MsgBoxStyle.Exclamation)
                End If
                'Me.Close()

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As EncuestaService.Resultado)
        Try
            Dim estado_process As Boolean
            estado_process = oEncuestaSistema.InsertarResultado(registro)
            If estado_process Then
                totalfila = totalfila + 1
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA ENCUESTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Function ValidaCampos() As Boolean
        Try
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As String
            Dim contador As Integer = 0
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("Respuesta").Value
                If bSelected = "" Then
                    contador = contador + 1
                End If
            Next

            If contador > 0 Then
                MsgBox("Debe contestar toda la encuesta antes de continuar", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub dgvDatos_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles dgvDatos.FormattingRow

    End Sub
End Class