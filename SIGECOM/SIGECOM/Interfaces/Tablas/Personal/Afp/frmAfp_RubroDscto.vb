Imports System.ServiceModel
Public Class frmAfp_RubroDscto

    '===========================Servicios====================================================
    Private oAfpService As New AfpService.AfpServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdRubroDes As Integer
    Public IdAfp As Integer
    Public IdModalidad As Integer
    Private dtRubroDscto As DataTable
    Private dtModalidad As DataTable

    Private Sub frmAfp_RubroDscto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtPorcentaje.Select()
        Else                          'Nuevo
            lblDesCuenta.Text = ""
            desactivar()
            cmbDescuento.Select()
        End If
        EnableOptions()

    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmAfp_RubroDscto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbDescuento.KeyPress, _
                            txtPorcentaje.KeyPress, _
                            txtPorcentaje.KeyPress, _
                            cmbModalidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = "(Todos)"
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub Finalizar()
        Try
            oAfpService.Close()
            oCuentaContableService.Close()
        Catch ex As TimeoutException
            oAfpService.Abort()
            oCuentaContableService.Abort()
        Catch ex As CommunicationException
            oAfpService.Abort()
            oCuentaContableService.Abort()
        End Try
    End Sub

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
            cmbDescuento.ReadOnly = True
            cmbDescuento.BackColor = System.Drawing.SystemColors.Control
            txtPorcentaje.ReadOnly = False
            txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            cmbModalidad.ReadOnly = True
            cmbModalidad.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCuenta.Enabled = True
        Else
            cmbDescuento.ReadOnly = False
            cmbDescuento.BackColor = System.Drawing.SystemColors.Window
            txtPorcentaje.ReadOnly = False
            txtPorcentaje.BackColor = System.Drawing.SystemColors.Window
            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            cmbModalidad.ReadOnly = False
            cmbModalidad.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCuenta.Enabled = True
        End If
    End Sub

    Private Sub desactivar()
        cmbDescuento.ReadOnly = True
        cmbDescuento.BackColor = System.Drawing.SystemColors.Control
        txtPorcentaje.ReadOnly = True
        txtPorcentaje.BackColor = System.Drawing.SystemColors.Control
        txtCodCuenta.ReadOnly = True
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
        cmbModalidad.ReadOnly = True
        cmbModalidad.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCuenta.Enabled = False
    End Sub

    Private Sub Insertar(ByVal registro As AfpService.AfpRubroDescuento)
        Try
            Dim estado_process As Boolean
            estado_process = oAfpService.InsertarRubroDescuento(registro)
            type_process = "insert"
            If estado_process = True Then
                IdRubroDes = cmbDescuento.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR RUBRO DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AfpService.AfpRubroDescuento)
        Try
            Dim estado_process As Boolean
            estado_process = oAfpService.ActualizarRubroDescuento(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR RUBRO DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AfpService.AfpRubroDescuento
            registro = oAfpService.ObtenerRubroDescuento(Session.sCodEmp, IdAfp, IdModalidad, IdRubroDes)

            IdAfp = registro.Afp.IdAfp
            IdRubroDes = registro.RubroDescuentoPlanilla.IdRubroDes
            cmbDescuento.Value = registro.RubroDescuentoPlanilla.IdRubroDes
            txtPorcentaje.Value = registro.Porcentaje
            txtCodCuenta.Text = registro.CuentaContable.CodCuenta
            lblDesCuenta.Text = registro.CuentaContable.NomCuenta
            cmbModalidad.Value = registro.ModalidadCobroAfp.IdModalidad

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER RUBRO DESCUENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== DESCUENTO ===============================================
            dtRubroDscto = oAfpService.MostrarRubroDescuentoAutomatico(Session.sCodEmp).Tables(0)
            cmbDescuento.DataSource = dtRubroDscto
            cmbDescuento.DropDownList.DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.DisplayMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.ValueMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(0).DataMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(1).DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.SelectedIndex = 0
            dtRubroDscto = Nothing


            ''========================================== MODALIDAD ===============================================
            dtModalidad = oAfpService.MostrarModalidad().Tables(0)
            cmbModalidad.DataSource = dtModalidad
            cmbModalidad.DropDownList.DataMember = dtModalidad.Columns("AbrModalidad").ToString
            cmbModalidad.DropDownList.DisplayMember = dtModalidad.Columns("AbrModalidad").ToString
            cmbModalidad.DropDownList.ValueMember = dtModalidad.Columns("IdModalidad").ToString
            cmbModalidad.DropDownList.Columns(0).DataMember = dtModalidad.Columns("IdModalidad").ToString
            cmbModalidad.DropDownList.Columns(1).DataMember = dtModalidad.Columns("AbrModalidad").ToString
            cmbModalidad.SelectedIndex = 0
            dtModalidad = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdAfp = 0 Then
                MsgBox("Código de AFP no valido.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(cmbDescuento.Value) = "" Then
                MsgBox("Debe Ingresar la Descripción de AFP. ", MsgBoxStyle.Information, "Información")
                cmbDescuento.Focus()
                Return False
                'ElseIf toDouble(txtPorcentaje.Value) = 0 Then
                '    MsgBox("Debe Ingresar el Porcentaje de Rubro Descuento.", MsgBoxStyle.Information, "Información")
                '    txtPorcentaje.Focus()
                '    Return False
            ElseIf toDouble(cmbModalidad.Value) = 0 Then
                MsgBox("Debe Ingresar la Modalidad de Rubro Descuento.", MsgBoxStyle.Information, "Información")
                cmbModalidad.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New AfpService.AfpRubroDescuento
            Dim Afp As New AfpService.Afp
            Dim RubroDescuento As New AfpService.RubroDescuentoPlanilla
            Dim CuentaContable As New AfpService.CuentaContable
            Dim ModalidadCobro As New AfpService.ModalidadCobroAfp
            Dim Empresa As New AfpService.Empresa

            Afp.IdAfp = IdAfp
            registro.Afp = Afp
            RubroDescuento.IdRubroDes = cmbDescuento.Value
            registro.RubroDescuentoPlanilla = RubroDescuento
            registro.Porcentaje = txtPorcentaje.Value

            CuentaContable.IdCuenta = IIf(oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text) = 0, 140, oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text))
            CuentaContable.CodCuenta = IIf(txtCodCuenta.Text = "", Nothing, txtCodCuenta.Text)
            registro.CuentaContable = CuentaContable

            ModalidadCobro.IdModalidad = cmbModalidad.Value
            registro.ModalidadCobroAfp = ModalidadCobro

            Empresa.CodEmp = Session.sCodEmp
            registro.Empresa = Empresa

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                Insertar(registro)
            End If
        End If
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
                    btnGuardar.Focus()
                End If
            Else
                'txtCodCuentaDest.Focus()
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
                btnGuardar.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub
End Class