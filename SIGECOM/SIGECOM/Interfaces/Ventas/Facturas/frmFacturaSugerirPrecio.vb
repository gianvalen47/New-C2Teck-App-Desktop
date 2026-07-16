Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmFacturaSugerirPrecio
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdSugerido As Integer
    Public IdFacturaDet As Integer
    Public IdFactura As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMer As String
    Public CodMon As String
    Private ObjFacturaDetalleService As New FacturaDetalleService.FacturaDetalleServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtPrecio.KeyPress, txtDscto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As New FacturaDetalleService.SugeridoFacturaDet
            registro = ObjFacturaDetalleService.MostrarSugeridoPorId(IdSugerido, IdFacturaDet)
            txtPrecio.Value = registro.PreMerSug
            txtDscto.Value = registro.DsctoSug
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al Obtener Datos")
        End Try
    End Sub

    Private Sub Insertar()
        Try
            Dim estado_process As Integer
            estado_process = ObjFacturaDetalleService.InsertarSugerido(IdFacturaDet, IdFactura, txtPrecio.Value, txtDscto.Value)
            type_process = "insert"
            If estado_process Then
                'IdSugerido = estado_process
                IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoFactura", "IdSugerido", "IdFactura", IdFactura)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim estado_process As Boolean
            estado_process = ObjFacturaDetalleService.ActualizarSugerido(IdSugerido, IdFacturaDet, IdFactura, txtPrecio.Value, txtDscto.Value)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = ObjFacturaDetalleService.BorrarSugerido(IdSugerido, IdFacturaDet, IdFactura)
            type_process = "delete"
            IdSugerido = oFacturaService.MostrarIdSugerido(IdFactura)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmFacturaSugerirPrecio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjFacturaDetalleService.Close()
            oFacturaService.Close()
            oMaestroService.Close()
            oPrecioService.Close()

        Catch ex As TimeoutException
            ObjFacturaDetalleService.Abort()
            oFacturaService.Abort()
            oMaestroService.Abort()
            oPrecioService.Abort()

        Catch ex As CommunicationException
            ObjFacturaDetalleService.Abort()
            oFacturaService.Abort()
            oMaestroService.Abort()
            oPrecioService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmFacturaSugerirPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFacturaSugerirPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        Me.Text = "Sugerir Precio - Dscto"
        state_button = ObjFacturaDetalleService.BuscarSugerido(IdFacturaDet)
        If state_button Then    ' Modificar
            btnBorrar.Enabled = True
            btnBorrar.Visible = True
            ObtenerRegistro()
        Else
            btnBorrar.Enabled = False
            btnBorrar.Visible = False
            btnAceptar.Location = New System.Drawing.Size(40, 120)
            btnCancelar.Location = New System.Drawing.Size(120, 120)

            Dim registro As FacturaDetalleService.FacturaDetalle
            registro = ObjFacturaDetalleService.MostrarPorId(toNumber(IdFacturaDet))
            txtPrecio.Text = registro.PreMer
            txtDscto.Text = registro.DscMer
        End If


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtPrecio.Value <= 0 Then
                MsgBox("Debe Ingresar un Precio Valido.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf txtDscto.Value < 0 Then
                MsgBox("Debe Ingresar un Descuento Valido.", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If MsgBox("¿Está seguro de BORRAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Eliminar()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            If state_button Then        'Modificar
                Modificar()
            Else                        'Nuevo
                Insertar()
            End If
        End If
    End Sub
End Class
