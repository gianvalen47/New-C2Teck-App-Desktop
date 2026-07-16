Imports System.ServiceModel
Public Class frmDsctoPlanilla

    '============================Servicios===================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdRubroDes As Integer
    Private CodConRemu As String

    Private Sub frmIngresoPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "DESCUENTO DE PLANILLA"
        Else                          'Nuevo
            Me.Text = "Registrar nuevo Descuento de Planilla"
            activar()
            cbActivo.Checked = True
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtIdRubroDes.KeyPress _
                     , txtAbrv.KeyPress _
                     , cbActivo.KeyPress _
                     , cbAutomatico.KeyPress _
                     , txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDsctoPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIngresoPlanilla_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaSueldosDetService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosDetService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosDetService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub enableOpciones()
        If state_button = False Then
            activar()
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        txtAbrv.ReadOnly = False
        txtAbrv.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        cbAutomatico.Enabled = True
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window

        cbActivo.Checked = True
        cbAutomatico.Checked = False

        txtAbrv.Focus()
    End Sub

    Private Sub desactivar()
        txtAbrv.ReadOnly = False
        txtAbrv.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        cbAutomatico.Enabled = True
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window

        txtAbrv.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(txtIdRubroDes.Text) = 0 Then
                MsgBox("Debe Ingresar el Código de Descuento.", MsgBoxStyle.Information, "Información")
                txtIdRubroDes.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PlanillaSueldosDetService.RubroDescuentoPlanilla
            registro = oPlanillaSueldosDetService.ObtenerRubroDescuento(IdRubroDes)

            IdRubroDes = registro.IdRubroDes
            txtIdRubroDes.Text = registro.IdRubroDes
            txtAbrv.Text = registro.AbrDescuento

            CodConRemu = registro.ConceptoRemuneracion.CodTributo
            txtConRemu.Text = registro.ConceptoRemuneracion.CodTributo

            cbActivo.Checked = registro.Activo
            cbAutomatico.Checked = registro.Automatico
            txtDescripcion.Text = registro.DesDescuento

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaSueldosDetService.RubroDescuentoPlanilla)
        Try
            Dim estado_process As Integer
            estado_process = oPlanillaSueldosDetService.InsertarRubroDescuento(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdRubroDes = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosDetService.RubroDescuentoPlanilla)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.ActualizarRubroDescuento(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.BorrarRubroIngreso(IdRubroDes)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New PlanillaSueldosDetService.RubroDescuentoPlanilla
                    Dim empresa As New PlanillaSueldosDetService.Empresa
                    Dim conceptoremu As New PlanillaSueldosDetService.ConceptoRemuneracion

                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.IdRubroDes = IdRubroDes
                    registro.AbrDescuento = txtAbrv.Text
                    registro.Activo = cbActivo.Checked
                    registro.Automatico = cbAutomatico.Checked
                    registro.DesDescuento = txtDescripcion.Text
                    conceptoremu.CodTributo = CodConRemu
                    registro.ConceptoRemuneracion = conceptoremu
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DESCUENTO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarCodRemun_Click(sender As Object, e As EventArgs) Handles btnBuscarCodRemun.Click
        Dim frm As New frmBuscarConceptoRemuneracion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtConRemu.Text = frm.codigo
            txtConRemu.BackColor = System.Drawing.SystemColors.Control
            CodConRemu = frm.codigo
        End If
        txtConRemu.Select()
    End Sub
End Class