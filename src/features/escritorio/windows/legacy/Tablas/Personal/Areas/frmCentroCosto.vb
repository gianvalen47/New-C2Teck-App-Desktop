Imports System.ServiceModel
Public Class frmCentroCosto

    '===========================Servicios====================================================
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public CodCentro As String
    Public CodArea As String

    '=============================Evento Load==================================
    Private Sub frmCentroCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtDesCentro.Select()
        Else                          'Nuevo
            txtCodCentro.Text = oCentroCostoService.SugerirCodigoCentroCosto
            cbActivo.Checked = True
            desactivar()
            txtCodCentro.Select()
        End If
        'estado = oOrdenesCompraService.ObtenerEstado(IdOrden)
        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmCentroCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                        txtCodSubCuenta.KeyPress, _
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
            If toBlank(txtCodCentro.Text) = "" Then
                MsgBox("Debe Ingresar el Código de Sub Cuenta. ", MsgBoxStyle.Information, "Información")
                txtCodCentro.Focus()
                Return False
            ElseIf oCentroCostoService.BuscarCentroCosto(txtCodCentro.Text) And state_button = False Then
                MsgBox("Esté código ya fue ingresado, ¡Verificar...!. ", MsgBoxStyle.Information, "Información")
                txtCodCentro.Focus()
                Return False
            ElseIf toBlank(txtDesCentro.Text) = "" Then
                MsgBox("Debe Ingresar la descripción de la Sub Cuenta.", MsgBoxStyle.Information, "Información")
                txtDesCentro.Focus()
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
            txtCodCentro.ReadOnly = True
            txtCodCentro.BackColor = System.Drawing.SystemColors.Control
            cbActivo.Enabled = True
            txtDesCentro.ReadOnly = False
            txtDesCentro.BackColor = System.Drawing.SystemColors.Window
            txtAbrCentro.ReadOnly = False
            txtAbrCentro.BackColor = System.Drawing.SystemColors.Window
            'End If
        Else
            txtCodCentro.ReadOnly = False
            txtCodCentro.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            txtDesCentro.ReadOnly = False
            txtDesCentro.BackColor = System.Drawing.SystemColors.Window
            txtAbrCentro.ReadOnly = False
            txtAbrCentro.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        txtCodCentro.ReadOnly = True
        txtCodCentro.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        txtDesCentro.ReadOnly = True
        txtDesCentro.BackColor = System.Drawing.SystemColors.Control
        txtAbrCentro.ReadOnly = True
        txtAbrCentro.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As CentroCostoService.CentroCosto)
        Try
            Dim estado_process As String
            estado_process = oCentroCostoService.InsertarCentroCosto(registro)
            type_process = "insert"
            If estado_process <> "" Then
                CodCentro = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CentroCostoService.CentroCosto)
        Try
            Dim estado_process As Boolean
            estado_process = oCentroCostoService.ActualizarCentroCosto(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CentroCostoService.CentroCosto
            registro = oCentroCostoService.ObtenerCentroCosto(CodCentro)

            CodArea = registro.Area.CodArea
            CodCentro = registro.CodCentro

            txtCodCentro.Text = registro.CodCentro
            cbActivo.Checked = registro.Activo
            txtDesCentro.Text = registro.DesCentro
            txtAbrCentro.Text = registro.AbrCentro

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
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

                Dim registro As New CentroCostoService.CentroCosto
                Dim Area As New CentroCostoService.Area

                CodCentro = txtCodCentro.Text
                registro.CodCentro = txtCodCentro.Text

                Area.CodArea = CodArea
                registro.Area = Area

                registro.Activo = cbActivo.Checked
                registro.DesCentro = txtDesCentro.Text
                registro.AbrCentro = txtAbrCentro.Text

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try  
    End Sub

    Private Sub txtCodCentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCentro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtDesCentro.Focus()
        End If
    End Sub

    Private Sub txtDesCentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesCentro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtAbrCentro.Focus()
        End If
    End Sub

    Private Sub txtAbrCentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbrCentro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class