Imports System.ServiceModel
Public Class frmAportacionCuenta

    '============================Servicios===================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Private dtCentroCosto As DataTable
    Private dtAreas As DataTable
    Private dtAportacion As DataTable
    Public IdAportacion As Integer
    Public CodCentro As String

    Private Sub frmAportacionCuenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "APORTACIÓN DE CUENTA"
            cmbAportacion.TabStop = False
            cmbArea.TabStop = False
            cmbCentroCosto.TabStop = False
            txtCodCuenta.Focus()
        Else                          'Nuevo
            Me.Text = "Registrar nuevo Aportación de Cuenta"
            activar()
            lblDesCuenta.Text = ""
            lblDesCuenta4.Text = ""
            cmbAportacion.TabStop = True
            cmbArea.TabStop = True
            cmbCentroCosto.TabStop = True
            cmbAportacion.Focus()
        End If
        enableOpciones()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       cmbAportacion.KeyPress _
                       , cmbArea.KeyPress _
                       , cmbCentroCosto.KeyPress
        ', txtCodCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmAportacionCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAportacionCuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPlanillaSueldosService.Close()
            oPlanillaSueldosDetService.Close()
            oCuentaContableService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oCuentaContableService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosService.Abort()
            oPlanillaSueldosDetService.Abort()
            oCuentaContableService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            ''======================================== APORTACIÓN ============================================
            dtAportacion = oPlanillaSueldosDetService.MostrarRubroAportacion().Tables(0)
            cmbAportacion.DataSource = dtAportacion
            cmbAportacion.DropDownList.DataMember = dtAportacion.Columns("DesAportacion").ToString
            cmbAportacion.DropDownList.DisplayMember = dtAportacion.Columns("DesAportacion").ToString
            cmbAportacion.DropDownList.ValueMember = dtAportacion.Columns("IdAportacion").ToString
            cmbAportacion.DropDownList.Columns(0).DataMember = dtAportacion.Columns("IdAportacion").ToString
            cmbAportacion.DropDownList.Columns(1).DataMember = dtAportacion.Columns("DesAportacion").ToString
            cmbAportacion.SelectedIndex = 0
            dtAportacion = Nothing

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try
            'If cmbArea.Value <> "" Then
            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
            'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            'If cmbArea.Value <> "" Then
            '    cmbCentroCosto.SelectedIndex = 1
            'Else
            cmbCentroCosto.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
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
            btnGuardar.Enabled = True
            desactivar()
        End If
    End Sub

    Private Sub activar()
        cmbAportacion.ReadOnly = False
        cmbAportacion.BackColor = System.Drawing.SystemColors.Window
        cmbArea.ReadOnly = False
        cmbArea.BackColor = System.Drawing.SystemColors.Window
        cmbCentroCosto.ReadOnly = False
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
        txtCodCuenta.ReadOnly = False
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuenta.Enabled = True
        txtCodCuenta4.ReadOnly = False
        txtCodCuenta4.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuenta4.Enabled = True

        cmbAportacion.Focus()
    End Sub

    Private Sub desactivar()
        cmbAportacion.ReadOnly = True
        cmbAportacion.BackColor = System.Drawing.SystemColors.Control
        cmbArea.ReadOnly = True
        cmbArea.BackColor = System.Drawing.SystemColors.Control
        cmbCentroCosto.ReadOnly = True
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        txtCodCuenta.ReadOnly = False
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuenta.Enabled = True
        txtCodCuenta4.ReadOnly = False
        txtCodCuenta4.BackColor = System.Drawing.SystemColors.Window
        btnBuscarCuenta4.Enabled = True

        txtCodCuenta.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(cmbAportacion.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Aportación.", MsgBoxStyle.Information, "Información")
                cmbAportacion.Focus()
                Return False
            ElseIf toNumber(cmbArea.Value) = 0 Then
                MsgBox("Debe Ingresar el Área.", MsgBoxStyle.Information, "Información")
                cmbArea.Focus()
                Return False
            ElseIf toNumber(cmbCentroCosto.Value) = 0 Then
                MsgBox("Debe Ingresar el Centro de Costo.", MsgBoxStyle.Information, "Información")
                cmbCentroCosto.Focus()
                Return False
            ElseIf txtCodCuenta.Text = "" Then
                MsgBox("Debe Ingresar la Cuenta Contable.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
                Return False
            ElseIf txtCodCuenta4.Text = "" Then
                MsgBox("Debe Ingresar la Cuenta Contable (4).", MsgBoxStyle.Information, "Información")
                txtCodCuenta4.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta4.Text)) Then
                MsgBox("Código de Cuenta (4) incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta4.Text = ""
                txtCodCuenta4.Focus()
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
            Dim registro As PlanillaSueldosService.RubroAportacionCuentas
            registro = oPlanillaSueldosService.ObtenerRubroAportacionCuentas(IdAportacion, CodCentro)

            IdAportacion = registro.RubroAportacion.IdAportacion
            cmbAportacion.Value = registro.RubroAportacion.IdAportacion

            CodCentro = registro.CentroCosto.CodCentro

            cmbArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro

            lblDesCuenta.Text = Trim(registro.CuentaContable.NomCuenta)
            txtCodCuenta.Text = toNull(registro.CuentaContable.CodCuenta)

            lblDesCuenta4.Text = Trim(registro.CuentaContable4.NomCuenta)
            txtCodCuenta4.Text = toNull(registro.CuentaContable4.CodCuenta)

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaSueldosService.RubroAportacionCuentas)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.InsertarRubroAportacionCuentas(registro)
            type_process = "insert"
            If estado_process = True Then
                IdAportacion = cmbAportacion.Value
                CodCentro = cmbCentroCosto.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR APORTACIÓN DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosService.RubroAportacionCuentas)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.ActualizarRubroAportacionCuentas(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR APORTACIÓN DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosService.BorrarRubroAportacionCuentas(IdAportacion, CodCentro)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR APORTACIÓN DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New PlanillaSueldosService.RubroAportacionCuentas
                    Dim Aportacion As New PlanillaSueldosService.RubroAportacion
                    Dim Area As New PlanillaSueldosService.Area
                    Dim CentroCosto As New PlanillaSueldosService.CentroCosto
                    Dim CuentaContable As New PlanillaSueldosService.CuentaContable
                    Dim CuentaContable4 As New PlanillaSueldosService.CuentaContable

                    Aportacion.IdAportacion = cmbAportacion.Value
                    registro.RubroAportacion = Aportacion

                    Area.CodArea = cmbArea.Value
                    CentroCosto.CodCentro = cmbCentroCosto.Value
                    CentroCosto.Area = Area
                    registro.CentroCosto = CentroCosto

                    CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    CuentaContable.CodCuenta = txtCodCuenta.Text
                    registro.CuentaContable = CuentaContable

                    CuentaContable4.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta4.Text)
                    CuentaContable4.CodCuenta = txtCodCuenta4.Text
                    registro.CuentaContable4 = CuentaContable4

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR APORTACIÓN DE CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta.Text = frm.codigo
                    lblDesCuenta.Text = frm.descripcion
                Else
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                    txtCodCuenta.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuenta.Text = registro.NomCuenta
                    txtCodCuenta4.Focus()
                End If
            Else
                txtCodCuenta4.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta.Validated
        If Len(Trim(txtCodCuenta.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCuenta.Text = ""
                lblDesCuenta.Text = ""
                txtCodCuenta.Focus()
            Else
                Dim IdCuenta As Integer
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                Dim registro As New CuentaContableService.CuentaContable
                registro = oCuentaContableService.Obtener(IdCuenta)
                lblDesCuenta.Text = registro.NomCuenta
                txtCodCuenta4.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub btnBuscarCuenta4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta4.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta4.Text = frm.codigo
                    lblDesCuenta4.Text = frm.descripcion
                Else
                    txtCodCuenta4.Text = ""
                    lblDesCuenta4.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable 4 : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuenta4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta4.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta4_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta4.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta4.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta4.Text = ""
                    lblDesCuenta4.Text = ""
                    txtCodCuenta4.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta4.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuenta4.Text = registro.NomCuenta
                    btnGuardar.Focus()
                End If
            Else
                btnGuardar.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuenta4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta4.Validated
        If Len(Trim(txtCodCuenta4.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta4.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCuenta4.Text = ""
                lblDesCuenta4.Text = ""
                txtCodCuenta4.Focus()
            Else
                Dim IdCuenta As Integer
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta4.Text)
                Dim registro As New CuentaContableService.CuentaContable
                registro = oCuentaContableService.Obtener(IdCuenta)
                lblDesCuenta4.Text = registro.NomCuenta
                btnGuardar.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub
End Class