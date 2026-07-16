Imports System.ServiceModel

Public Class frmCondicionPagoV

    Private oClienteService As New ClienteService.ClienteServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public CodPag As String
    Private NumDocSug As String

    Private Sub frmCondicionPagoV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'llenarCombos()

        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            Me.Text = "Condicion de Pago : " + Chr(34) + txtDescripción.Text.ToString + Chr(34)
        Else                    'Nuevo
            'txtAnioFab.Text = Today.Year
            Me.Size = New System.Drawing.Size(382, 246)
            Me.Text = "Registrar Condicion Pago"
            activar()
            SugerirNumero()
        End If

    End Sub

    Private Sub SugerirNumero()

        Try

            NumDocSug = oClienteService.SugerirCodigoCondicionPago()
            txtCodPag.Text = NumDocSug

        Catch ex As Exception
            MsgBox("ERROR AL SUGERIR NUMERO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub frmCondicionPagoV_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ClienteService.CondicionPago
            registro = oClienteService.ObtenerCondicionPago(CodPag)

            txtCodPag.Text = registro.CodPag
            txtDescripción.Text = registro.DesPag
            txtAbreviatura.Text = registro.AbrPag
            txtDiasPago.Text = registro.DiaPag

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub activar()
        Try
            txtCodPag.ReadOnly = True
            txtCodPag.BackColor = System.Drawing.SystemColors.Control
            txtDescripción.ReadOnly = False
            txtDescripción.BackColor = System.Drawing.SystemColors.Window
            txtAbreviatura.ReadOnly = False
            txtAbreviatura.BackColor = System.Drawing.SystemColors.Window
            txtDiasPago.ReadOnly = False
            txtDiasPago.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub desactivar()
        Try
            txtCodPag.ReadOnly = True
            txtCodPag.BackColor = System.Drawing.SystemColors.Control
            txtDescripción.ReadOnly = True
            txtDescripción.BackColor = System.Drawing.SystemColors.Control
            txtAbreviatura.ReadOnly = True
            txtAbreviatura.BackColor = System.Drawing.SystemColors.Control
            txtDiasPago.ReadOnly = True
            txtDiasPago.BackColor = System.Drawing.SystemColors.Control
            edicion = False
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion

    End Sub

    Private Sub frmCondicionPagoV_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oClienteService.Close()
        Catch ex As TimeoutException
            oClienteService.Abort()
        Catch ex As CommunicationException
            oClienteService.Abort()
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New ClienteService.CondicionPago
                Dim empresa As New VehiculoService.Empresa
                Dim area As New VehiculoService.Area

                registro.CodPag = txtCodPag.Text
                registro.DesPag = txtDescripción.Text
                registro.AbrPag = txtAbreviatura.Text
                registro.DiaPag = txtDiasPago.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'Dim registro As New ProveedorService.Proveedor
            'registro.IdProveedor = toNumber(txtIdProveedor.Text)

            If txtDescripción.Text = "" Then
                MsgBox("Debe Ingresar la Descripcion", MsgBoxStyle.Information, "Información")
                txtDescripción.BackColor = Color.Red
                txtDescripción.Focus()
                Return False
            Else
                Return True
            End If
            Return True
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub Insertar(ByVal registro As ClienteService.CondicionPago)
        Try
            Dim estado_process As Boolean
            estado_process = oClienteService.InsertarCondicionPago(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la Condición de Pago correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I. ....!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA CONDICION DE PAGO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ClienteService.CondicionPago)
        Try
            Dim estado_process As Boolean
            estado_process = oClienteService.ActualizarCondicionPago(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I....!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA CONDICION DE PAGO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(sender As Object, e As EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(sender As Object, e As EventArgs) Handles biDeshacer.Click
        ObtenerRegistro()
        desactivar()
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub



End Class