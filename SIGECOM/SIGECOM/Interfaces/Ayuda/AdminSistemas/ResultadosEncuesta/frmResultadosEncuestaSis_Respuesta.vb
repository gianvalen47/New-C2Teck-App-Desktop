Imports System.ServiceModel

Public Class frmResultadosEncuestaSis_Respuesta

    WithEvents bsReports As New BindingSource
    '===========================Servicios====================================================
    Private oEncuestaSistema As New EncuestaService.EncuestaServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Private dtDatos As DataTable
    Private dtTipo As DataTable
    Public IdPregunta As Integer
    Public Tipo As String
    Public IdEncuesta As Integer
    Public filaA As Integer
    Public IdPreguntaTempE As Integer
    Public RespuestaTempE As String

    Private Sub frmResultadosEncuestaSis_Respuesta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEncuestaSistema.Close()
        Catch ex As TimeoutException
            oEncuestaSistema.Abort()
        Catch ex As CommunicationException
            oEncuestaSistema.Abort()
        End Try
    End Sub

    Private Sub frmResultadosEncuestaSis_Respuesta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmResultadosEncuestaSis_Respuesta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObtenerRegistro()
        If Tipo = "Selectiva" Then
            RespuestaSelectiva()
            dgvOpciones.Visible = True
            dgvOpciones.Location = New Point(12, 80)
            txtRespuestaDesc.Visible = False
            txtRespuestaDesc.Location = New Point(12, 236)
            btnGuardar.Location = New Point(270, 260)
            btnCancelar.Location = New Point(354, 260)
        ElseIf Tipo = "Descriptiva" Then
            RespuestaDescriptiva()
            dgvOpciones.Visible = False
            dgvOpciones.Location = New Point(12, 236)
            txtRespuestaDesc.Visible = True
            txtRespuestaDesc.Location = New Point(12, 96)
            btnGuardar.Location = New Point(524, 196)
            btnCancelar.Location = New Point(608, 196)
            Me.Size = New System.Drawing.Size(722, 275)
        End If


    End Sub

    Private Sub RespuestaDescriptiva()

        txtRespuestaDesc.Focus()

    End Sub

    Private Sub RespuestaSelectiva()

        dtDatos = oEncuestaSistema.MostrarRespuesta(toNumber(IdPregunta)).Tables(0) 'listaDatos()

        Dim dt As New DataTable
        dt.Columns.AddRange(New DataColumn() {New DataColumn("Identifier", GetType(System.Int32)), _
                New DataColumn("SelectionColumn", GetType(System.Boolean)), _
                New DataColumn("ReportName", GetType(System.String)), _
                New DataColumn("SubOptions", GetType(System.String)), _
                New DataColumn("FileName", GetType(System.String))})
        '    }
        ')
        dt.Columns("FileName").ColumnMapping = MappingType.Hidden

        For i As Integer = 0 To dtDatos.Rows.Count - 1

            If dtDatos.Rows(i).Item("IdRespuesta") = filaA Then
                dt.Rows.Add(New Object() {i + 1, True, dtDatos.Rows(i).Item("Descripcion"), dtDatos.Rows(i).Item("IdRespuesta"), "A1"})
            Else
                dt.Rows.Add(New Object() {i + 1, False, dtDatos.Rows(i).Item("Descripcion"), dtDatos.Rows(i).Item("IdRespuesta"), "A1"})
            End If

            'If i = 0 Then
            '    dt.Rows.Add(New Object() {i + 1, True, dtDatos.Rows(i).Item("Descripcion"), dtDatos.Rows(i).Item("IdRespuesta"), "A1"})
            'Else
            '    dt.Rows.Add(New Object() {i + 1, False, dtDatos.Rows(i).Item("Descripcion"), dtDatos.Rows(i).Item("IdRespuesta"), "A1"})
            'End If

        Next

        bsReports.DataSource = dt
        dgvOpciones.DataSource = bsReports
        dgvOpciones.Columns("Identifier").Visible = False
        dgvOpciones.Columns("SubOptions").Visible = False
        dgvOpciones.Columns("SelectionColumn").HeaderText = ""
        dgvOpciones.Columns("SelectionColumn").Width = 20
        dgvOpciones.Columns("ReportName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvOpciones.Columns("ReportName").HeaderText = "Respuestas"

        Dim estilo1 As New Estilo
        estilo1.cargaEstiloDataDrid(dgvOpciones)
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EncuestaService.Pregunta
            registro = oEncuestaSistema.ObtenerPregunta(IdPregunta)

            IdPregunta = registro.IdPregunta
            IdEncuesta = registro.Encuesta.IdEncuesta
            txtPregunta.Text = registro.Descripcion
            'cmbTipo.Text = registro.Tipo
            'cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub listaDatos()
    '    Try
    '        dtDatos = oEncuestaSistema.MostrarRespuesta(toNumber(IdPregunta)).Tables(0)
    '        'dgvDatos.DataSource = dtDatos
    '        'dgvOpciones.DataSource = dtDatos
    '        'enableOpciones()

    '    Catch ex As Exception
    '        MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub dgvOpciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpciones.CellContentClick

        Dim Value As Boolean = CBool(dgvOpciones.Rows(e.RowIndex).Cells("SelectionColumn").Value)
        If Value Then
            Dim Index As Integer = e.RowIndex
            For row As Integer = 0 To dgvOpciones.Rows.Count - 1
                If row <> Index Then
                    dgvOpciones.Rows(row).Cells("SelectionColumn").Value = False
                End If
            Next
        Else
            dgvOpciones.Rows(e.RowIndex).Cells("SelectionColumn").Value = True
            Dim Index As Integer = e.RowIndex
            For row As Integer = 0 To dgvOpciones.Rows.Count - 1
                If row <> Index Then
                    dgvOpciones.Rows(row).Cells("SelectionColumn").Value = False
                End If
            Next
        End If
        dgvOpciones.CurrentCell = dgvOpciones(1, e.RowIndex)

    End Sub

    Private Sub dgvOpciones_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvOpciones.CellPainting
        If e.ColumnIndex = dgvOpciones.Columns("SelectionColumn").Index AndAlso e.RowIndex >= 0 Then
            e.PaintBackground(e.ClipBounds, True)
            Dim rectButton As Rectangle
            rectButton.Width = 14
            rectButton.Height = 14
            rectButton.X = e.CellBounds.X + (e.CellBounds.Width - rectButton.Width) \ 2
            rectButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectButton.Height) \ 2
            If IsDBNull(e.Value) OrElse CBool(e.Value) = False Then
                ControlPaint.DrawRadioButton(e.Graphics, rectButton, ButtonState.Normal)
            Else
                ControlPaint.DrawRadioButton(e.Graphics, rectButton, ButtonState.Checked)
            End If
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvOpciones_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOpciones.CurrentCellDirtyStateChanged
        If TypeOf dgvOpciones.CurrentCell Is DataGridViewCheckBoxCell Then
            dgvOpciones.EndEdit()
        End If
    End Sub


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Selection = (From T In CType(bsReports.DataSource, DataTable).AsEnumerable() Where (T.Field(Of Boolean)("SelectionColumn")) Select New With {.Answer = T.Field(Of String)("ReportName"), .SubOptions = T.Field(Of String)("SubOptions")}).FirstOrDefault

    '    If Selection IsNot Nothing Then
    '        MessageBox.Show(Me, String.Format("[{0}] [{1}]", Selection.Answer, Selection.SubOptions))
    '    Else
    '        MessageBox.Show("Please make a selection")
    '    End If
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If Tipo = "Selectiva" Then

            Dim Selection = (From T In CType(bsReports.DataSource, DataTable).AsEnumerable() Where (T.Field(Of Boolean)("SelectionColumn")) Select New With {.Answer = T.Field(Of String)("ReportName"), .SubOptions = T.Field(Of String)("SubOptions")}).FirstOrDefault

            If Selection IsNot Nothing Then
                IdPreguntaTempE = Selection.SubOptions
                RespuestaTempE = Selection.Answer
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Debe escoger una respuesta", MsgBoxStyle.Information)
            End If

        ElseIf Tipo = "Descriptiva" Then

            If txtRespuestaDesc.Text <> "" Then
                IdPreguntaTempE = 0
                RespuestaTempE = txtRespuestaDesc.Text
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Debe de ingresar la respuesta", MsgBoxStyle.Information)
            End If

        End If
        
        'Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class