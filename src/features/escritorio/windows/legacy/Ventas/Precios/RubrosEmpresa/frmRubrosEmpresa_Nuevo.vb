Imports System.ServiceModel
Public Class frmRubrosEmpresa_Nuevo

    Private oRubrosService As New RubrosService.RubrosServiceClient

    Public CodEmpV As String
    Public DesEmpV As String
    Public CodRubV As String

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable

    Private CodRubro As String
    Private DesRubro As String
    Private AbrvRubro As String
    Private FactorVenta As Double
    Private FactorCosto As Double
    Private Descuento As Double

    Private Sub frmRubrosEmpresa_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRubrosService.Close()
        Catch ex As TimeoutException
            oRubrosService.Abort()
        Catch ex As CommunicationException
            oRubrosService.Abort()
        End Try
    End Sub

    Private Sub frmRubrosEmpresa_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub frmRubrosEmpresa_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If state_button Then    'Modificar            
            LimpiarCampos()
            ObtenerRegistro()
            desactivar()
            Me.Text = "Rubro : " + Chr(34) + txtCodRubro.Text.ToString + Chr(34)
        Else 'Nuevo
            'cbActivo.Checked = True
            btnBuscarRubro.Focus()
            LimpiarCampos()
            activar()
            Me.Size = New System.Drawing.Size(390, 267)
            Me.Text = "Registrar nuevo Rubro"
            txtFactorCosto.Text = "0.00"
            txtFactorVenta.Text = "0.00"
            txtDscto.Text = "0.00"
            'SugerirNumero()
        End If
    End Sub

    Private Sub LimpiarCampos()

        txtCodRubro.Text = ""
        txtDescripcion.Text = ""
        txtAbreviatura.Text = ""
        txtFactorCosto.Text = "0.00"
        txtFactorVenta.Text = "0.00"
        txtDscto.Text = "0.00"

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As RubrosService.RubrosEmpresa
            registro = oRubrosService.ObtenerRubrosEmpresa(CodRubV, CodEmpV)

            txtCodRubro.Text = registro.Rubro.CodRub
            txtDescripcion.Text = registro.Rubro.DesRub
            txtAbreviatura.Text = registro.Rubro.AbrRub
            txtFactorCosto.Text = registro.FacCos
            txtFactorVenta.Text = registro.FacVen
            txtDscto.Text = registro.Dscto

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        btnBuscarRubro.Enabled = False
        txtCodRubro.ReadOnly = True
        txtCodRubro.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtAbreviatura.ReadOnly = True
        txtAbreviatura.BackColor = System.Drawing.SystemColors.Control
        txtFactorCosto.ReadOnly = True
        txtFactorCosto.BackColor = System.Drawing.SystemColors.Control
        txtFactorVenta.ReadOnly = True
        txtFactorVenta.BackColor = System.Drawing.SystemColors.Control
        txtDscto.ReadOnly = True
        txtDscto.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        btnBuscarRubro.Enabled = IIf(state_button = False, True, False)
        txtCodRubro.ReadOnly = True
        txtCodRubro.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtAbreviatura.ReadOnly = True
        txtAbreviatura.BackColor = System.Drawing.SystemColors.Control
        txtFactorCosto.ReadOnly = False
        txtFactorCosto.BackColor = System.Drawing.SystemColors.Window
        txtFactorVenta.ReadOnly = False
        txtFactorVenta.BackColor = System.Drawing.SystemColors.Window
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub btnBuscarRubro_Click(sender As Object, e As EventArgs) Handles btnBuscarRubro.Click
        NuevoDetalle()
    End Sub

    Private Sub NuevoDetalle()

        Try
            Dim frm As New frmRubroEmpresa_Detalle
            frm.CodEmp = CodEmpV
            'frm.Placa = toBlank(txtDesEmp.Text)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                txtCodRubro.Text = frm.CodRubGrilla
                txtDescripcion.Text = frm.DesRubGrilla
                txtAbreviatura.Text = frm.AbrRubGrilla
                txtFactorCosto.Text = frm.FactorCosto
                txtFactorVenta.Text = frm.FactorVenta
                txtDscto.Text = frm.Descuento

            Else

            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar el Rubro: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Try

            Dim registro As New RubrosService.RubrosEmpresa
            Dim empresa As New RubrosService.Empresa
            Dim rubro As New RubrosService.Rubro

            rubro.CodRub = txtCodRubro.Text
            rubro.DesRub = txtDescripcion.Text
            rubro.AbrRub = txtAbreviatura.Text
            registro.Rubro = rubro

            empresa.CodEmp = Session.sCodEmp
            registro.Empresa = empresa

            registro.FacCos = toDouble(txtFactorCosto.Text)
            registro.FacVen = toDouble(txtFactorVenta.Text)
            registro.Dscto = toDouble(txtDscto.Text)

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If

        Catch ex As Exception
            MsgBox("Error al Guardar Datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As RubrosService.RubrosEmpresa)
        Try
            Dim estado_process As Boolean
            estado_process = oRubrosService.InsertarRubrosEmpresa(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el Rubro correctamente")
                CodRubro = txtCodRubro.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL RUBRO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RubrosService.RubrosEmpresa)
        Try
            Dim estado_process As Boolean
            estado_process = oRubrosService.ActualizarRubrosEmpresa(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I....!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL RUBRO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtFactorCosto.KeyPress _
                      , txtFactorVenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDscto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDscto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            biGuardar.Select()
            biGuardar_Click(sender, e)
        End If
    End Sub


End Class