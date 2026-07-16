Imports System.ServiceModel
Public Class frmCondicionPagoC

    Private oProveedorService As New ProveedorService.ProveedorServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public IdCondicion As Integer
    Private NumDocSug As String

    Private Sub frmCondicionPagoC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oProveedorService.Close()
        Catch ex As TimeoutException
            oProveedorService.Abort()
        Catch ex As CommunicationException
            oProveedorService.Abort()
        End Try
    End Sub

    Private Sub frmCondicionPagoC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCondicionPagoC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            Me.Text = "Condicion de Pago : " + Chr(34) + txtDescripción.Text.ToString + Chr(34)
        Else                    'Nuevo
            Me.Size = New System.Drawing.Size(382, 246)
            Me.Text = "Registrar Condicion Pago"
            activar()
            SugerirNumero()
        End If

    End Sub

    Private Sub SugerirNumero()
        Try

            NumDocSug = oProveedorService.SugerirIdCondicionPago()
            txtCodPag.Text = NumDocSug

        Catch ex As Exception
            MsgBox("ERROR AL SUGERIR NUMERO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ProveedorService.CondicionPagoProveedor
            registro = oProveedorService.ObtenerCondicionPago(IdCondicion)

            txtCodPag.Text = registro.IdCondicion
            txtDescripción.Text = registro.NomCondicion
            txtAbreviatura.Text = registro.AbrCondicion
            txtDiasPago.Text = registro.DiasPago

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

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New ProveedorService.CondicionPagoProveedor

                registro.IdCondicion = txtCodPag.Text
                registro.NomCondicion = txtDescripción.Text
                registro.AbrCondicion = txtAbreviatura.Text
                registro.DiasPago = txtDiasPago.Text
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

    Private Sub Insertar(ByVal registro As ProveedorService.CondicionPagoProveedor)
        Try
            Dim estado_process As Boolean
            estado_process = oProveedorService.InsertarCondicionPago(registro)
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

    Private Sub Modificar(ByVal registro As ProveedorService.CondicionPagoProveedor)
        Try
            Dim estado_process As Boolean
            estado_process = oProveedorService.ActualizarCondicionPago(registro)
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