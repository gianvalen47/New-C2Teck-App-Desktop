Imports System.ServiceModel

Public Class frmFactura_Cuotas_Nuevo

    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private dtDatos As DataTable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdFactura As Integer
    Public NumeroCuota As Integer

    Private Sub frmFactura_Cuotas_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmFactura_Cuotas_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oFacturaService.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
        End Try
    End Sub

    Private Sub frmFactura_Cuotas_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            'Me.Text = "Locacion :  " + Chr(34) + cmbOficinas.Text.ToString + Chr(34)
        Else 'Nuevo
            activar()
            'Me.Size = New System.Drawing.Size(468, 397)
            Me.Text = "Registrar nueva Cuota"
            SugerirNumero()
            'cbActivo.Checked = True
        End If
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As FacturaService.FacturaCuotas
            registro = oFacturaService.ObtenerCuota(IdFactura, NumeroCuota)

            txtNumeroCuota.Text = registro.NumeroCuota
            txtMontoCuota.Text = registro.MontoCuota
            txtFecVencimiento.Text = registro.FecVencimiento

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub SugerirNumero()

        Dim numsug As Integer
        numsug = oFacturaService.SugerirNumeroCuota(IdFactura).ToString()
        txtNumeroCuota.Text = numsug

    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        txtNumeroCuota.ReadOnly = True
        txtNumeroCuota.BackColor = System.Drawing.SystemColors.Control
        txtMontoCuota.ReadOnly = True
        txtMontoCuota.BackColor = System.Drawing.SystemColors.Control
        txtFecVencimiento.ReadOnly = True
        txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        txtNumeroCuota.ReadOnly = False
        txtNumeroCuota.BackColor = System.Drawing.SystemColors.Window
        txtMontoCuota.ReadOnly = False
        txtMontoCuota.BackColor = System.Drawing.SystemColors.Window
        txtFecVencimiento.ReadOnly = False
        txtFecVencimiento.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New FacturaService.FacturaCuotas
                Dim empresa As New FacturaService.Empresa
                Dim factura As New FacturaService.Factura
                'Dim oficina As New LocacionService.Oficina
                'Dim almacen As New LocacionService.Almacen
                'Dim centrocosto As New LocacionService.CentroCosto

                registro.NumeroCuota = txtNumeroCuota.Text
                registro.MontoCuota = txtMontoCuota.Text
                registro.FecVencimiento = txtFecVencimiento.Text

                factura.IdFactura = IdFactura
                registro.Factura = factura

                registro.FecReg = Date.Today

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then    'Modificar
                    Modificar(registro)
                Else                    'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub


    Private Sub Insertar(ByVal registro As FacturaService.FacturaCuotas)
        Try
            Dim estado_process As Boolean
            estado_process = oFacturaService.InsertarCuota(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el numero de cuota correctamente")
                'IdLocacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA CUOTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As FacturaService.FacturaCuotas)
        Try
            Dim estado_process As Boolean
            estado_process = oFacturaService.ActualizarCuota(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I. ...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumeroCuota.Text) = "" Then
                MsgBox("Debe Ingresar el numero de cuota", MsgBoxStyle.Information, "Información")
                txtNumeroCuota.BackColor = Color.Red
                txtNumeroCuota.Focus()
                Return False
            ElseIf toBlank(txtMontoCuota.Text) = "" Then
                MsgBox("Debe Ingresar el Monto Cuota", MsgBoxStyle.Information, "Información")
                txtMontoCuota.BackColor = Color.Red
                txtMontoCuota.Focus()
                Return False
            ElseIf toBlank(txtFecVencimiento.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Vencimiento", MsgBoxStyle.Information, "Información")
                txtFecVencimiento.BackColor = Color.Red
                txtFecVencimiento.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

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

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtFecVencimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFecVencimiento.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        ElseIf e.KeyChar = ChrW(Keys.Tab) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                'biGuardar_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumeroCuota.KeyPress _
                      , txtMontoCuota.KeyPress _
                      , txtFecVencimiento.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class