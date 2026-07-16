Imports System.Windows.Forms

Public Class frmPartida

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestro As New MaestroService.MaestroClient
    Private oPartidaService As New PartidaService.PartidaServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private dtRubros As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtCodPar.KeyPress _
                          , txtDesPar.KeyPress _
                          , cmbCodRubPar.KeyPress _
                          , txtParPar.KeyPress _
                          , txtAdvPar.KeyPress _
                          , txtFacPar.KeyPress _
                          , txtSegPar.KeyPress _
                          , txtSobPar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        state_Search = False
        llenarCombos()
        If state_button Then    'Modificar
            Me.btnGuardar.Location = New System.Drawing.Point(175, 167)
            Me.btnEliminar.Location = New System.Drawing.Point(249, 167)
            txtCodPar.ReadOnly = True
            txtCodPar.TabStop = False
            ObtenerRegistro()
            Me.Text = "Partida Arancelara " + Chr(34) + txtCodPar.Text + Chr(34)
        Else                    'Nuevo
            btnEliminar.Visible = False
            Me.btnEliminar.Location = New System.Drawing.Point(175, 167)
            Me.btnGuardar.Location = New System.Drawing.Point(249, 167)
            txtCodPar.ReadOnly = False
            txtCodPar.TabStop = True
            Me.Text = "Registrar una Partida Arancelaria"
        End If
        state_Search = True
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestro) = False Then
                oMaestro.Close()
            End If
            If isClosed(oPartidaService) = False Then
                oPartidaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                           txtCodPar.KeyUp _
                          , txtDesPar.KeyUp _
                          , txtAdvPar.KeyUp _
                          , txtFacPar.KeyUp _
                          , txtSegPar.KeyUp _
                          , txtSobPar.KeyUp
        Try
            If state_Search = True Then
                Dim campo As New Object
                If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                    campo = New Janus.Windows.GridEX.EditControls.EditBox
                ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                    campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
                ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                    campo = New TextBox
                End If
                campo = sender
                If campo.readonly = False Then
                    If campo.Text.Trim.Length > 0 Then
                        campo.BackColor = Color.White
                    Else
                        campo.BackColor = Color.Red
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPar.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New PartidaService.Partida
            registro.CodPar = toNull(txtCodPar.Text)
            If txtCodPar.Text.Trim = "" Then
                MsgBox("Debe Ingresar el código de la Partida", MsgBoxStyle.Information, "Información")
                txtCodPar.BackColor = Color.Red
                txtCodPar.Focus()
                Return False
            ElseIf txtParPar.Text = "" Then
                MsgBox("Debe Ingresar la partida de la Partida", MsgBoxStyle.Information, "Información")
                txtParPar.BackColor = Color.Red
                txtParPar.Focus()
                Return False
            ElseIf txtDesPar.Text = "" Then
                MsgBox("Debe Ingresar el descripción de la Partida", MsgBoxStyle.Information, "Información")
                txtDesPar.BackColor = Color.Red
                txtDesPar.Focus()
                Return False
            ElseIf toDouble(txtAdvPar.Text) < 0 Or toDouble(txtAdvPar.Text) > 100 Then
                MsgBox("El Advalorem de la Partida debe estar 0-100%.", MsgBoxStyle.Information, "Información")
                txtAdvPar.Text = ""
                txtAdvPar.BackColor = Color.Red
                txtAdvPar.Focus()
                Return False
            ElseIf toDouble(txtFacPar.Text) < 0 Or toDouble(txtFacPar.Text) > 100 Then
                MsgBox("El Factor de la Partida debe estar 0-100%.", MsgBoxStyle.Information, "Información")
                txtAdvPar.Text = ""
                txtFacPar.BackColor = Color.Red
                txtFacPar.Focus()
                Return False
            ElseIf toDouble(txtSegPar.Text) < 0 Or toDouble(txtSegPar.Text) > 100 Then
                MsgBox("El Seguro de la Partida debe estar 0-100%.", MsgBoxStyle.Information, "Información")
                txtAdvPar.Text = ""
                txtSegPar.BackColor = Color.Red
                txtSegPar.Focus()
                Return False
            ElseIf toDouble(txtSobPar.Text) < 0 Or toDouble(txtSobPar.Text) > 100 Then
                MsgBox("El Sobretasa de la Partida debe estar 0-100%.", MsgBoxStyle.Information, "Información")
                txtAdvPar.Text = ""
                txtSobPar.BackColor = Color.Red
                txtSobPar.Focus()
                Return False
            ElseIf state_button = False And oPartidaService.Buscar(registro) = True Then
                MsgBox("Código " + txtCodPar.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtCodPar.Text = ""
                txtCodPar.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As PartidaService.Partida)
        Try
            Dim estado_process As Boolean
            estado_process = oPartidaService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As PartidaService.Partida)
        Try
            Dim estado_process As Boolean
            estado_process = oPartidaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar(ByVal registro As PartidaService.Partida)
        Try
            Dim estado_process As Boolean
            estado_process = oPartidaService.Borrar(registro)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As PartidaService.Partida
            registro = oPartidaService.MostrarPorCodigo(toNull(txtCodPar.Text))

            txtCodPar.Text = registro.CodPar
            txtParPar.Text = registro.ParPar
            txtDesPar.Text = registro.DesPar
            txtAdvPar.Text = registro.AdvPar
            txtFacPar.Text = registro.FacPar
            txtSegPar.Text = registro.SegPar
            txtSobPar.Text = registro.SobPar
            state_Search = True
            cmbCodRubPar.Value = registro.RubroPartida.CodRubPar

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= RUBROS DE PARTIDA ===========================================
            dtRubros = oMaestro.MostrarRubroPartidas.Tables(0)
            'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRubPar.DataSource = dtRubros
            cmbCodRubPar.DropDownList.DataMember = dtRubros.Columns("DesRubPar").ToString
            cmbCodRubPar.DropDownList.DisplayMember = dtRubros.Columns("DesRubPar").ToString
            cmbCodRubPar.DropDownList.ValueMember = dtRubros.Columns("CodRubPar").ToString
            cmbCodRubPar.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubPar").ToString
            cmbCodRubPar.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubPar").ToString
            'cmbCodRubPar.SelectedIndex = 0
            dtRubros = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New PartidaService.Partida
            Dim rubroPartida As New PartidaService.RubroPartida

            registro.CodPar = toNull(txtCodPar.Text)
            rubroPartida.CodRubPar = toNull(cmbCodRubPar.Value)
            registro.RubroPartida = rubroPartida
            registro.ParPar = toNull(txtParPar.Text)
            registro.DesPar = toNull(txtDesPar.Text)
            registro.AdvPar = toNull(txtAdvPar.Text)
            registro.FacPar = toNull(txtFacPar.Text)
            registro.SegPar = toNull(txtSegPar.Text)
            registro.SobPar = toNull(txtSobPar.Text)

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If txtCodPar.Text.Trim.Length > 0 Then
                Dim registro As New PartidaService.Partida
                registro.CodPar = txtCodPar.Text.Trim
                Eliminar(registro)
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtCodPar.Focus()
            End If
        End If
    End Sub
End Class
