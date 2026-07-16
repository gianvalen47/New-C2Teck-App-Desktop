Imports System.ServiceModel
Public Class frmBuscarUbicacion
    '=========================== Servicios ===================================================
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtDatos As DataTable
    Public codigo As String
    Public descripcion As String

    Private dtEstante As DataTable
    Private dtNivel As DataTable
    Private dtCelda As DataTable

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cmbEstante.KeyPress _
                      , cmbCelda.KeyPress _
                      , cmbNivel.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
             cmbEstante.KeyPress _
          , cmbCelda.KeyPress _
          , cmbNivel.KeyPress _
          , btnBuscar.KeyPress _
          , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmBuscarUbicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        listaDatos()
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("CodUbicacion").Text
            'descripcion = dgvDatos.CurrentRow.Cells("").Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            dtDatos = oLocacionMercaderiaService.FiltrarUbicacion(Session.sCodEmp, toBlank(cmbEstante.Value), IIf(cmbNivel.SelectedIndex = 0, "", cmbNivel.Value), _
                                                                                                IIf(cmbCelda.SelectedIndex = 0, "", cmbCelda.Value)).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("CodUbicacion").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try

            '======================================= ESTANTE =============================================
            dtEstante = oLocacionMercaderiaService.MostrarEstante().Tables(0)
            'dtEstante.Rows.InsertAt(getRowTodos(dtEstante), 0)
            cmbEstante.DataSource = dtEstante
            cmbEstante.DropDownList.DataMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.DropDownList.DisplayMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.DropDownList.ValueMember = dtEstante.Columns("CodEstante").ToString
            cmbEstante.DropDownList.Columns(0).DataMember = dtEstante.Columns("CodEstante").ToString
            cmbEstante.DropDownList.Columns(1).DataMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.SelectedIndex = 0
            dtEstante = Nothing


            '========================================= NIVEL =============================================
            dtNivel = New DataTable
            dtNivel.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtNivel.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtNivel.Rows.Add(New Object() {"", "Todos"}) ', New DateTime(2008, 2, 5)
            dtNivel.Rows.Add(New Object() {"A", "A"})
            dtNivel.Rows.Add(New Object() {"B", "B"})
            dtNivel.Rows.Add(New Object() {"C", "C"})
            dtNivel.Rows.Add(New Object() {"D", "D"})
            dtNivel.Rows.Add(New Object() {"E", "E"})
            dtNivel.Rows.Add(New Object() {"F", "F"})
            dtNivel.Rows.Add(New Object() {"G", "G"})
            dtNivel.Rows.Add(New Object() {"H", "H"})
            dtNivel.Rows.Add(New Object() {"M", "M"})
            dtNivel.Rows.Add(New Object() {"P", "P"})
            dtNivel.Rows.Add(New Object() {"S", "S"})
            dtNivel.Rows.Add(New Object() {"T", "T"})

            cmbNivel.DataSource = dtNivel
            cmbNivel.DropDownList.DataMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.DisplayMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.ValueMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.Columns(0).DataMember = dtNivel.Columns("codigo").ToString
            cmbNivel.DropDownList.Columns(1).DataMember = dtNivel.Columns("nombre").ToString
            cmbNivel.SelectedIndex = 0
            dtNivel = Nothing


            '========================================= CELDA =============================================
            dtCelda = New DataTable
            dtCelda.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtCelda.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtCelda.Rows.Add(New Object() {"", "Todos"}) ', New DateTime(2008, 2, 5)
            dtCelda.Rows.Add(New Object() {"1", "1"})
            dtCelda.Rows.Add(New Object() {"2", "2"})
            dtCelda.Rows.Add(New Object() {"3", "3"})
            dtCelda.Rows.Add(New Object() {"4", "4"})
            dtCelda.Rows.Add(New Object() {"5", "5"})
            dtCelda.Rows.Add(New Object() {"6", "6"})
            dtCelda.Rows.Add(New Object() {"7", "7"})
            dtCelda.Rows.Add(New Object() {"8", "8"})
            dtCelda.Rows.Add(New Object() {"9", "9"})
            dtCelda.Rows.Add(New Object() {"10", "10"})
            dtCelda.Rows.Add(New Object() {"11", "11"})
            dtCelda.Rows.Add(New Object() {"12", "12"})
            dtCelda.Rows.Add(New Object() {"13", "13"})
            dtCelda.Rows.Add(New Object() {"14", "14"})
            dtCelda.Rows.Add(New Object() {"15", "15"})
            dtCelda.Rows.Add(New Object() {"16", "16"})
            dtCelda.Rows.Add(New Object() {"17", "17"})
            dtCelda.Rows.Add(New Object() {"18", "18"})
            dtCelda.Rows.Add(New Object() {"21", "21"})
            dtCelda.Rows.Add(New Object() {"22", "22"})
            dtCelda.Rows.Add(New Object() {"23", "23"})
            dtCelda.Rows.Add(New Object() {"24", "24"})
            dtCelda.Rows.Add(New Object() {"25", "25"})
            dtCelda.Rows.Add(New Object() {"26", "26"})
            dtCelda.Rows.Add(New Object() {"27", "27"})
            dtCelda.Rows.Add(New Object() {"29", "29"})
            dtCelda.Rows.Add(New Object() {"30", "30"})
            dtCelda.Rows.Add(New Object() {"31", "31"})

            cmbCelda.DataSource = dtCelda
            cmbCelda.DropDownList.DataMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.DisplayMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.ValueMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.Columns(0).DataMember = dtCelda.Columns("codigo").ToString
            cmbCelda.DropDownList.Columns(1).DataMember = dtCelda.Columns("nombre").ToString
            cmbCelda.SelectedIndex = 0
            dtCelda = Nothing

        Catch ex As Exception
            MsgBox("ERROR [BUSC-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbEstante.ValueChanged, cmbNivel.ValueChanged, cmbCelda.ValueChanged
        listaDatos()
    End Sub
    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodUbicacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "CodUbicacion", codigo)
        End If
    End Sub
    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        codigo = Nothing
        descripcion = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class