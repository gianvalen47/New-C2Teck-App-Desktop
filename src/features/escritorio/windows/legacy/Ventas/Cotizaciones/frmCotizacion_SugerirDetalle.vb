Public Class frmCotizacion_SugerirDetalle
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdSugerido As Integer
    Public IdCotizacionDet As Integer
    Public IdCotizacion As Integer
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public CodMon As String
    Public CodMer As String

    Private Sub frmCotizacion_SugerirDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If

            If isClosed(oCotizacionService) = False Then
                oCotizacionService.Close()
            End If
            If isClosed(oCotizacionDetalleService) = False Then
                oCotizacionDetalleService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCotizacion_SugerirDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_SugerirDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtPrecio.KeyPress, txtDscto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCotizacion_SugerirDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        Me.Text = "Sugerir Precio - Dscto"
        state_button = oCotizacionDetalleService.BuscarSugerido(IdCotizacionDet)
        If state_button Then    ' Modificar
            btnEliminar.Enabled = True
            btnEliminar.Visible = True
            ObtenerRegistro()
        Else
            btnEliminar.Enabled = False
            btnEliminar.Visible = False
            btnAceptar.Location = New System.Drawing.Size(40, 120)
            btnCancelar.Location = New System.Drawing.Size(120, 120)

            Dim registro As CotizacionDetalleService.CotizacionDetalle
            registro = oCotizacionDetalleService.MostrarPorId(toNumber(IdCotizacion), toNumber(IdCotizacionDet))
            txtPrecio.Text = registro.PreMer
            txtDscto.Text = registro.DscMer
            'If oMercaderiaService.Buscar(CodMer) Then
            '    txtPrecio.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, CodMer, CodMon, Date.Today)
            'ElseIf oPrecioService.BuscarPrecioFabrica("001", CodMer) Then
            '    txtPrecio.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, CodMer, CodMon, Date.Today) ' IIf(CodMon = "US", Precio.PreVenDol, Precio.PreVenSol)
            'End If
        End If
    End Sub

    Private Sub Insertar()
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionDetalleService.InsertarSugerido(IdCotizacionDet, IdCotizacion, txtPrecio.Value, txtDscto.Value)
            type_process = "insert"
            If estado_process Then
                IdSugerido = oMaestroService.MostrarDato("Ventas.SugeridoCotizacion", "IdSugerido", "IdCotizacion", IdCotizacion)
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
            estado_process = oCotizacionDetalleService.ActualizarSugerido(IdSugerido, IdCotizacionDet, IdCotizacion, txtPrecio.Value, txtDscto.Value)
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
            estado_process = oCotizacionDetalleService.BorrarSugerido(IdSugerido, IdCotizacionDet, IdCotizacion)
            type_process = "delete"
            IdSugerido = oCotizacionService.MostrarIdSugerido(IdCotizacion)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionDetalleService.SugeridoCotizacionDet
            registro = oCotizacionDetalleService.MostrarPorIdSugerido(IdSugerido, IdCotizacionDet)
            txtPrecio.Value = registro.PreMerSug
            txtDscto.Value = registro.DsctoSug
        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Function ValidaCampos() As Boolean
        Try
            If txtPrecio.Value <= 0 Then
                MsgBox("Debe Ingresar un Precio Valido.", MsgBoxStyle.Information, "Información")
                txtPrecio.Select()
                Return False
            ElseIf txtDscto.Value < 0 Then
                MsgBox("Debe Ingresar un Descuento Valido.", MsgBoxStyle.Information, "Información")
                txtPrecio.Select()

                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
         And ValidaCampos() Then
            If state_button Then        'Modificar
                Modificar()
            Else                        'Nuevo
                Insertar()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR los datos Sugeridos ... ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Eliminar()
        End If
    End Sub
End Class