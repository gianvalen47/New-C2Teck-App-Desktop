Imports System.ServiceModel
Public Class frmIngresoPlanilla

    '============================Servicios===================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdRubroIng As Integer
    Private CodConRemu As String

    Private Sub frmIngresoPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "INGRESO DE PLANILLA"
        Else                          'Nuevo
            Me.Text = "Registrar nuevo Ingreso de Planilla"
            activar()            
            cbActivo.Checked = True
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       txtAbrv.KeyPress _
                       , cbActivo.KeyPress _
                       , txtDescripcion.KeyPress _
                      , cbAfectoDscto.KeyPress _
                      , cbAfectoAporte.KeyPress _
                      , cbAutomatico.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmIngresoPlanilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        cbAfectoDscto.Enabled = True
        cbAfectoAporte.Enabled = True
        cbAutomatico.Enabled = True
        cbAfectoQuinta.Enabled = True
        cbContrato.Enabled = True

        cbActivo.Checked = True
        cbAfectoDscto.Checked = False
        cbAfectoAporte.Checked = False
        cbAfectoQuinta.Checked = False
        cbContrato.Checked = False
        cbAutomatico.Checked = False


        txtAbrv.Focus()
    End Sub

    Private Sub desactivar()
        txtAbrv.ReadOnly = False
        txtAbrv.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        cbAfectoDscto.Enabled = True
        cbAfectoAporte.Enabled = True
        cbAutomatico.Enabled = True
        cbAfectoQuinta.Enabled = True
        cbContrato.Enabled = True
        txtAbrv.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(txtIdRubroIng.Text) = 0 Then
                MsgBox("Debe Ingresar el Código de Ingreso.", MsgBoxStyle.Information, "Información")
                txtIdRubroIng.Focus()
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
            Dim registro As PlanillaSueldosDetService.RubroIngresoPlanilla
            registro = oPlanillaSueldosDetService.ObtenerRubroIngreso(IdRubroIng)

            IdRubroIng = registro.IdRubroIng
            txtIdRubroIng.Text = registro.IdRubroIng
            txtAbrv.Text = registro.AbrIngreso

            cbActivo.Checked = registro.Activo
            txtDescripcion.Text = registro.DesIngreso

            CodConRemu = registro.ConceptoRemuneracion.CodTributo
            txtConRemu.Text = registro.ConceptoRemuneracion.CodTributo

            cbAfectoDscto.Checked = registro.AfectoDscto
            cbAfectoAporte.Checked = registro.AfectoAporte
            cbAutomatico.Checked = registro.Automatico
            cbAfectoQuinta.Checked = registro.AfectoQuinta
            cbContrato.Checked = registro.Contrato


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaSueldosDetService.RubroIngresoPlanilla)
        Try
            Dim estado_process As Integer
            estado_process = oPlanillaSueldosDetService.InsertarRubroIngreso(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdRubroIng = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosDetService.RubroIngresoPlanilla)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.ActualizarRubroIngreso(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.BorrarRubroIngreso(IdRubroIng)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New PlanillaSueldosDetService.RubroIngresoPlanilla
                    Dim empresa As New PlanillaSueldosDetService.Empresa
                    Dim conceptoremu As New PlanillaSueldosDetService.ConceptoRemuneracion

                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.IdRubroIng = IdRubroIng
                    registro.AbrIngreso = txtAbrv.Text
                    registro.Activo = cbActivo.Checked
                    registro.DesIngreso = txtDescripcion.Text
                    registro.AfectoDscto = cbAfectoDscto.Checked
                    registro.AfectoAporte = cbAfectoAporte.Checked
                    registro.Automatico = cbAutomatico.Checked
                    registro.AfectoQuinta = cbAfectoQuinta.Checked
                    registro.Contrato = cbContrato.Checked
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
            MsgBox("ERROR AL GUARDAR INGRESO DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
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