Imports System.Windows.Forms

Public Class frmGenerarPedido_PedidoInterno

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oPedidoService As New PedidoService.PedidoServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdPedidoImp As String
    Public IdCliente As String
    Public IdLocacion As String
    Private ObsCabec As String
    Private ObsDetalle As String
    Private AbrvProv As String

    Public dtListaDetalles As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtProveedor.KeyPress _
                          , txtalmacen.KeyPress _
                          , txtFecha.KeyPress _
                          , txtNumPed.KeyPress _
                          , txtObservacion.KeyPress _
                          , rbAgregarPedido.KeyPress _
                          , rbGenerarPedido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmGenerarPedido_PedidoInterno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oPedidoService) = False Then
                oPedidoService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPedidoImportService) = False Then
                oPedidoImportService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtProveedor.KeyUp _
                          , txtalmacen.KeyUp _
                          , txtFecha.KeyUp _
                          , txtNumPed.KeyUp _
                          , txtObservacion.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.IntegerUpDown" Then
                campo = New Janus.Windows.GridEX.EditControls.IntegerUpDown
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPed.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New PedidoImportService.PedidoImport
            Dim proveedor As New PedidoImportService.Proveedor
            Dim Locacion As New PedidoImportService.Locacion

            registro.NumPed = toNull(txtNumPed.Text)
            proveedor.IdProveedor = toNull(IdCliente)
            registro.Proveedor = proveedor
            Locacion.IdLocacion = toNull(IdLocacion)
            registro.Locacion = Locacion

            If (rbGenerarPedido.Checked = True Or rbAgregarPedido.Checked = True) And toNumber(txtNumPed.Text) = 0 Then
                MsgBox("Debe Ingresar el número del pedido de Importación", MsgBoxStyle.Information, "Información")
                txtNumPed.BackColor = Color.Red
                txtNumPed.Focus()
                Return False
            ElseIf rbGenerarPedido.Checked = True And toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe ingresar la fecha del pedido de importación. ", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf rbGenerarPedido.Checked = True And toNumber(IdCliente) = 0 Then
                MsgBox("Debe ingresar el proveedor del pedido de importación. ", MsgBoxStyle.Information, "Información")
                txtProveedor.BackColor = Color.Red
                btnBuscarProveedor.Focus()
                Return False
            ElseIf rbGenerarPedido.Checked = True And toNumber(IdLocacion) = 0 Then
                MsgBox("Debe ingresar el almacén del pedido de importación ", MsgBoxStyle.Information, "Información")
                txtalmacen.BackColor = Color.Red
                btnBuscarAlmacen.Focus()
                Return False
            ElseIf rbAgregarPedido.Checked = True And toNumber(IdLocacion) = 0 Then
                MsgBox("Debe Ingresar el almacén del detalle ", MsgBoxStyle.Information, "Información")
                txtalmacen.BackColor = Color.Red
                btnBuscarAlmacen.Focus()
                Return False
            ElseIf rbGenerarPedido.Checked = True And oPedidoImportService.Buscar(registro) = True Then
                MsgBox("El número del pedido de importación " + txtNumPed.Text + " ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumPed.Text = ""
                txtNumPed.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Generar(ByVal registro As PedidoService.PedidoImport, ByVal listaDetalles As DataTable, ByVal isNuevo As Boolean)
        Try
            Dim estado_process As Boolean
            estado_process = oPedidoService.GenerarPedidoImport(registro, listaDetalles, Session.sCodUsu, isNuevo)
            type_process = "insert"
            If estado_process = True Then
                MsgBox(" Se generó el pedido de Importación:" & vbLf & _
                       " Número : " + txtNumPed.Text & vbLf & _
                       " Proveedor: " + oMaestroService.MostrarDato("SIGECOM.Maestro.Proveedores", "DesProv", "IdProveedor", IdCliente) _
                        , MsgBoxStyle.Information)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim cadenacodigostarjeta As String = ""
        Dim cadenacodigostarjetaalmacen As String = ""

        For Each row As DataRow In dtListaDetalles.Rows
            Dim codmer As String = CStr(row("CodMer"))

            If oMercaderiaService.Buscar(codmer) Then
                If oLocacionMercaderiaService.Buscar(IdLocacion, codmer) = False Then
                    cadenacodigostarjetaalmacen = cadenacodigostarjetaalmacen + " , " + Trim(codmer)
                End If
            Else
                cadenacodigostarjeta = cadenacodigostarjeta + " , " + Trim(codmer)
            End If
        Next

        If cadenacodigostarjeta <> "" Then
            MsgBox("Los siguientes numeros de parte no tienen tarjeta " + cadenacodigostarjeta, MsgBoxStyle.Information)
        End If

        If cadenacodigostarjetaalmacen <> "" Then
            MsgBox("Los siguientes numeros de parte no existen en este almacen " + cadenacodigostarjetaalmacen, MsgBoxStyle.Information)
        End If

        If cadenacodigostarjeta = "" And cadenacodigostarjetaalmacen = "" Then
            Guardar()
        End If

    End Sub

    Private Sub Guardar()

        Dim mensaje As String = ""
        If rbAgregarPedido.Checked = True Then
            mensaje = "¿Está seguro de AGREGAR la lista de detalles al pedido " + toBlank(txtNumPed.Text) + " ?"
        ElseIf rbGenerarPedido.Checked = True Then
            mensaje = "¿Está seguro de GENERAR el pedido de Importación?:" & vbLf &
                       " Número : " + txtNumPed.Text & vbLf &
                       " Proveedor: " + oMaestroService.MostrarDato("SIGECOM.Maestro.Proveedores", "DesProv", "IdProveedor", IdCliente)
        End If
        If MsgBox(mensaje, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New PedidoService.PedidoImport
            Dim locacion As New PedidoService.Locacion
            Dim proveedor As New PedidoService.Proveedor

            registro.IdPedidoImp = toNumber(IdPedidoImp)
            locacion.IdLocacion = toNull(IdLocacion)
            registro.Locacion = locacion
            proveedor.IdProveedor = toNull(IdCliente)
            registro.Proveedor = proveedor
            registro.NumPed = toNull(txtNumPed.Text)
            registro.FecPed = toNull(txtFecha.Text)
            If IdCliente = "404" Then
                registro.ObsPed = "A/To : STEVE REMMICK                                                           Referencia  :   ORDER " & AbrvProv & "" & txtNumPed.Text & "-" & Mid(Today.Year, 3, 2) & Environment.NewLine &
                                    "  " & Environment.NewLine &
                                    "PLEASE ENTER OUR ORDER  " & AbrvProv & "" & txtNumPed.Text & "-" & Mid(Today.Year, 3, 2) & ",  TO BE SHIPPED OPEN ACCOUNT, SURFACE TO :" & Environment.NewLine &
                                    "DETROIT DIESEL-MTU PERU S.A.C."
                registro.ObsDet = "REGARDS," & Environment.NewLine &
                                   "MORI VALDIZAN" & Environment.NewLine &
                                   "DETROIT DIESEL - MTU PERU S.A.C." & Environment.NewLine &
                                   "LIMA PERU"
            Else
                registro.ObsPed = "" 'toNull(txtObservacion.Text)
                registro.ObsDet = ""
            End If

            If rbGenerarPedido.Checked = True Then
                Generar(registro, dtListaDetalles, True)
            ElseIf rbAgregarPedido.Checked = True Then
                Generar(registro, dtListaDetalles, False)
            End If
        End If

    End Sub
    Private Sub btnBuscarAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAlmacen.Click
        Dim frm As New frmBuscarAlmacen
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtalmacen.Text = frm.descripcion
            txtalmacen.BackColor = System.Drawing.SystemColors.Control
            IdLocacion = frm.codigo
        End If
    End Sub
    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frmBuscarProveedor
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtProveedor.Text = frm.descripcion
            AbrvProv = frm.abreviatura
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            If rbGenerarPedido.Checked = True Then
                txtNumPed.Text = oPedidoImportService.MostrarNumPed(IdCliente, txtFecha.Text)
            End If
        End If
    End Sub
    Private Sub EnableRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                      rbGenerarPedido.CheckedChanged _
                    , rbAgregarPedido.CheckedChanged
        If rbGenerarPedido.Checked = True Then
            txtNumPed.Enabled = True
            txtFecha.Enabled = True
            btnBuscarProveedor.Visible = True
            btnBuscarAlmacen.Visible = True
            txtObservacion.Enabled = True
            btnBuscarFacturaImportacion.Visible = False
        ElseIf rbAgregarPedido.Checked = True Then
            txtNumPed.Enabled = True
            txtFecha.Enabled = False
            btnBuscarProveedor.Visible = True
            btnBuscarAlmacen.Visible = True
            txtObservacion.Enabled = False
            btnBuscarFacturaImportacion.Visible = True
        End If
    End Sub


    Private Sub btnBuscarFacturaImportacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFacturaImportacion.Click
        If IdCliente = 0 Then
            MsgBox("Debe ingresar el Proveedor...!")
        Else
            Dim frm As New frmBuscarPedidoImportacion
            frm.IdLocacion = IdLocacion
            frm.IdProveedor = IdCliente
            frm.DesProv = txtProveedor.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                IdPedidoImp = frm.codigo
                txtNumPed.Text = frm.numero
            End If
        End If
    End Sub
End Class
