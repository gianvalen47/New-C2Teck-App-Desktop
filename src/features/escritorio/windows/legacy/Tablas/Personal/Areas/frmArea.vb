Imports System.ServiceModel
Public Class frmArea


    '===========================Servicios====================================================
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public CodArea As String
    Public IdUnidad As Integer
    '=============================Evento Load==================================
    Private Sub frmArea_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtDesArea.Select()
        Else                          'Nuevo
            txtCodArea.Text = oCentroCostoService.SugerirCodigoArea()
            cbActivo.Checked = True
            desactivar()
            txtCodArea.Select()
        End If

        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                        txtCodCuentaMayor.KeyPress, _
    '                        cbActivo.KeyPress, _
    '                        txtDescripcion.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub Finalizar()
        Try
            oCentroCostoService.Close()
        Catch ex As TimeoutException
            oCentroCostoService.Abort()
        Catch ex As CommunicationException
            oCentroCostoService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodArea.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Área. ", MsgBoxStyle.Information, "Información")
                txtCodArea.Focus()
                Return False
            ElseIf oCentroCostoService.BuscarArea(txtCodArea.Text) And state_button = False Then
                MsgBox("Esté código ya fue ingresado, ¡Verificar...!. ", MsgBoxStyle.Information, "Información")
                txtCodArea.Focus()
                Return False
            ElseIf toBlank(txtDesArea.Text) = "" Then
                MsgBox("Debe Ingresar la descripción del Área.", MsgBoxStyle.Information, "Información")
                txtDesArea.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        'If estado = 1 Then
        activar()
        btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub activar()
        If state_button Then
            '    'If estado <> 1 Then
            '    desactivar()
            'Else
            txtCodArea.ReadOnly = True
            txtCodArea.BackColor = System.Drawing.SystemColors.Control
            cbActivo.Enabled = True
            txtDesArea.ReadOnly = False
            txtDesArea.BackColor = System.Drawing.SystemColors.Window
            'End If
        Else
            txtCodArea.ReadOnly = False
            txtCodArea.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            txtDesArea.ReadOnly = False
            txtDesArea.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        txtCodArea.ReadOnly = True
        txtCodArea.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        txtDesArea.ReadOnly = True
        txtDesArea.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As CentroCostoService.Area)
        Try
            Dim estado_process As String
            estado_process = oCentroCostoService.InsertarArea(registro)
            type_process = "insert"
            If estado_process <> "" Then
                CodArea = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR AREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CentroCostoService.Area)
        Try
            Dim estado_process As Boolean
            estado_process = oCentroCostoService.ActualizarArea(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR AREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CentroCostoService.Area
            registro = oCentroCostoService.ObtenerArea(CodArea)

            CodArea = registro.CodArea

            txtCodArea.Text = registro.CodArea
            cbActivo.Checked = registro.Activo
            txtDesArea.Text = registro.DesArea

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER AREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
         And ValidaCampos() Then

                Dim registro As New CentroCostoService.Area
                Dim Empresa As New CentroCostoService.Empresa
                Dim unidad As New CentroCostoService.UnidadNegocio

                CodArea = txtCodArea.Text
                registro.CodArea = txtCodArea.Text
                unidad.IdUnidad = IdUnidad
                registro.UnidadNegocio = unidad
                registro.Activo = cbActivo.Checked
                registro.DesArea = txtDesArea.Text
                registro.AbrArea = txtAbrArea.Text
                registro.MarcaJob = False
                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ÁREA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try     
    End Sub

    Private Sub txtCodArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodArea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtDesArea.Focus()
        End If
    End Sub

    Private Sub txtDesArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesArea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class