Imports System.Windows.Forms

Public Class frmLiquidacionMotor_AgregarDetalle

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oLiquidacionMotorDetService As New LiquidacionMotorDetService.LiquidacionMotorDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private dtConceptos As DataTable

    Public IdLiqMotorDet As Integer
    Public IdLiqMotor As Integer
    Public estado As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdConcepto.KeyPress _
                          , txtPrecio.KeyPress _
                          , txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmLiquidacionMotor_AgregarDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
        End If

        If estado = "GENERADO" Or estado = "GN" Or state_button = False Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            txtPrecio.ReadOnly = True
            txtDescripcion.ReadOnly = True
            cmbIdConcepto.ReadOnly = True
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oLiquidacionMotorDetService) = False Then
                oLiquidacionMotorDetService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtPrecio.KeyUp _
                          , txtDescripcion.KeyUp
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                           cmbIdConcepto.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(cmbIdConcepto.Value) = 0 Then
                MsgBox("Debe Ingresar el concepti de detalle.", MsgBoxStyle.Information, "Información")
                cmbIdConcepto.BackColor = Color.Red
                cmbIdConcepto.Focus()
                Return False
            ElseIf toDouble(txtPrecio.Text) <= 0 Then
                MsgBox("El precio debe ser mayor a CERO. ", MsgBoxStyle.Information, "Información")
                txtPrecio.BackColor = Color.Red
                txtPrecio.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe de ingresar la descripción.", MsgBoxStyle.Information, "Información")
                txtDescripcion.BackColor = Color.Red
                txtDescripcion.Focus()
                Return False
            ElseIf state_button = False And oLiquidacionMotorDetService.Buscar(IdLiqMotor, cmbIdConcepto.Value) = True Then
                MsgBox("El concepto " + cmbIdConcepto.DropDownList.GetRow.Cells(1).Text + " ya existe en la liquidación...!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As LiquidacionMotorDetService.LiquidacionMotorDet)
        Try
            Dim estado_process As Integer
            estado_process = oLiquidacionMotorDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLiqMotorDet = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As LiquidacionMotorDetService.LiquidacionMotorDet)
        Try
            Dim estado_process As Boolean
            estado_process = oLiquidacionMotorDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As LiquidacionMotorDetService.LiquidacionMotorDet
            registro = oLiquidacionMotorDetService.MostrarPorId(toNumber(IdLiqMotorDet))

            IdLiqMotorDet = registro.IdLiqMotorDet
            IdLiqMotor = registro.LiquidacionMotor.IdLiqMotor
            cmbIdConcepto.Value = registro.ConceptoLiqMotor.IdConcepto
            txtDescripcion.Text = registro.Descripcion
            txtPrecio.Text = registro.Precio

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= CONCEPTOS DE LIQUIDACION ================================================
            dtConceptos = oMaestroService.MostrarConceptoLiqMotor.Tables(0)
            cmbIdConcepto.DataSource = dtConceptos
            cmbIdConcepto.DropDownList.DataMember = dtConceptos.Columns("Nombre").ToString
            cmbIdConcepto.DropDownList.DisplayMember = dtConceptos.Columns("Nombre").ToString
            cmbIdConcepto.DropDownList.ValueMember = dtConceptos.Columns("IdConcepto").ToString
            cmbIdConcepto.DropDownList.Columns(0).DataMember = dtConceptos.Columns("IdConcepto").ToString
            cmbIdConcepto.DropDownList.Columns(1).DataMember = dtConceptos.Columns("Nombre").ToString
            dtConceptos = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New LiquidacionMotorDetService.LiquidacionMotorDet
            Dim liquidacion As New LiquidacionMotorDetService.LiquidacionMotor
            Dim concepto As New LiquidacionMotorDetService.ConceptoLiqMotor

            registro.IdLiqMotorDet = IdLiqMotorDet
            liquidacion.IdLiqMotor = IdLiqMotor
            registro.LiquidacionMotor = liquidacion
            concepto.IdConcepto = cmbIdConcepto.Value
            registro.ConceptoLiqMotor = concepto
            registro.Descripcion = txtDescripcion.Text
            registro.Precio = txtPrecio.Text

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
End Class
