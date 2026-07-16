Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmGuiaDevolucion_Generar

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private oGuiaDevolucionDetService As New GuiaDevolucionDetService.GuiaDevolucionDetServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private dtDatos As DataTable
    Private TIPO_GUIA_REMISION As Integer = 1
    Private TIPO_FACTURA As Integer = 2
    Private TIPO_BOLETA As Integer = 3
    Public IdLocacion As Integer

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdGuiaDev As Integer
    Private codigo As Integer
    Private tipo_doc As Integer = 0

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnBuscarDocumento_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnModificarObservacion_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                txtNumDoc.KeyPress

        ', txtObservacion.KeyPress
        ', txtFecDoc.KeyPress _
        ', btnBuscarDocumento.KeyPress _
        ', btnModificarObservacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarDocumento.Enabled = True Then
                btnBuscarDocumento.Select()
            End If
        End If
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub frmGuiaDevolucion_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFecDoc.Value = Session.sFecha
        Me.CancelButton = Me.btnCancelar
        Me.Text = "Registrar nueva GUÍAS DE DEVOLUCIÓN"
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        '  If isClosed(oMaestroService) = False Then
        '    oMaestroService.Close()
        '  End If
        '  If isClosed(oGuiaDevolucionService) = False Then
        '    oGuiaDevolucionService.Close()
        '  End If
        '  If isClosed(oGuiaRemisionService) = False Then
        '    oGuiaRemisionService.Close()
        '  End If
        '  If isClosed(oGuiaDevolucionDetService) = False Then
        '    oGuiaDevolucionDetService.Close()
        '  End If
        '  If isClosed(oFacturaService) = False Then
        '    oFacturaService.Close()
        '  End If
        '  If isClosed(oBoletaService) = False Then
        '    oBoletaService.Close()
        '  End If
        'Catch ex As Exception
        '  MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            oMaestroService.Close()
            oGuiaDevolucionService.Close()
            oGuiaDevolucionDetService.Close()
            oGuiaRemisionService.Close()
            oFacturaService.Close()
            oBoletaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
            oGuiaRemisionService.Abort()
            oFacturaService.Abort()
            oBoletaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
            oGuiaRemisionService.Abort()
            oFacturaService.Abort()
            oBoletaService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub


    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                txtNumero.KeyUp _
                              , txtNumDoc.KeyUp _
                              , txtFecDoc.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
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
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdGuiaDev) = 0 Then
                MsgBox("Debe Ingresar el código de la guía de devolución.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(codigo) = 0 Or toNumber(tipo_doc) = 0 Then
                MsgBox("Debe Ingresar el código del documento.", MsgBoxStyle.Information, "Información")
                txtNumero.BackColor = Color.Red
                txtNumero.Focus()
                Return False
            ElseIf toNumber(txtNumDoc.Text) = 0 Then
                MsgBox("Debe Ingresar el número de la Guía de Devolución.", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf txtObservacion.Text = "" Then
                MsgBox("Debe Ingresar la Observación.", MsgBoxStyle.Information, "Información")
                txtObservacion.BackColor = Color.Red
                txtObservacion.Focus()
                Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text) <= 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio, Verifique...", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
            ElseIf state_button = False And oGuiaDevolucionService.Buscar(tipo_doc, codigo, txtNumDoc.Text) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la guía ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf state_button = True And oGuiaDevolucionService.Estado(IdGuiaDev) <> "GENERADO" Then
                MsgBox("Ya no puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado generado...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar()
        Try
            Dim estado_process As Integer
            estado_process = oGuiaDevolucionService.GenerarGuiaDevolucion(IdLocacion, tipo_doc, codigo, txtFecDoc.Text, txtNumDoc.Text, toBlank(txtObservacion.Text), Session.sCodUsu)

            type_process = "insert"
            If estado_process > 0 Then
                IdGuiaDev = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerDocumento_GFB()
        If toNumber(codigo) > 0 Then
            If tipo_doc = 1 Then                      ' GUÍA DE REMISIÓN
                Dim registro As New GuiaRemisionService.GuiaRemision
                registro = oGuiaRemisionService.MostrarPorId(codigo)
                lblUbicacion.Text = "OFICINA: " & registro.Locacion.Oficina.DesOfi & "  -  ALMACEN: " & registro.Locacion.Almacen.DesAlm
                'lblAlmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
                lblCliente.Text = registro.Cliente.DesCli
                lblCodMon.Text = registro.Moneda.CodMon
                lblCodMot.Text = registro.Motivos.DesMot
                lbldLocCli.Text = registro.LocacionCliente.Nombre
                lblFecha.Text = registro.FecDoc
                lblIgv.Text = registro.Igv.ToString + "%"
                lblNumJob.Text = registro.NumJob
                If state_button = False Then
                    txtNumDoc.Text = oGuiaDevolucionService.SugerirNumero(registro.Locacion.IdLocacion)
                End If
            ElseIf tipo_doc = 2 Then                  ' FACTURA
                Dim registro As New FacturaService.Factura
                registro = oFacturaService.MostrarPorId(codigo)
                lblUbicacion.Text = "OFICINA: " & registro.Locacion.Oficina.DesOfi & "  -  ALMACEN: " & registro.Locacion.Almacen.DesAlm
                'lblAlmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
                lblCliente.Text = registro.Cliente.DesCli
                lblCodMon.Text = registro.Moneda.CodMon
                lblCodMot.Text = registro.Motivos.DesMot
                lbldLocCli.Text = registro.LocacionCliente.Nombre
                lblFecha.Text = registro.FecDoc
                lblIgv.Text = registro.Igv.ToString + "%"
                lblNumJob.Text = registro.NumJob
                If state_button = False Then
                    txtNumDoc.Text = oGuiaDevolucionService.SugerirNumero(registro.Locacion.IdLocacion)
                End If
            ElseIf tipo_doc = 3 Then                  ' BOLETA
                Dim registro As New BoletaService.Boleta
                registro = oBoletaService.MostrarPorId(codigo)
                lblUbicacion.Text = "OFICINA: " & registro.Locacion.Oficina.DesOfi & "  -  ALMACEN: " & registro.Locacion.Almacen.DesAlm
                'lblAlmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
                lblCliente.Text = registro.Cliente.DesCli
                lblCodMon.Text = registro.Moneda.CodMon
                lblCodMot.Text = registro.Motivos.DesMot
                lbldLocCli.Text = registro.LocacionCliente.Nombre
                lblFecha.Text = registro.FecDoc
                lblIgv.Text = registro.Igv.ToString + "%"
                lblNumJob.Text = registro.NumJob
                If state_button = False Then
                    txtNumDoc.Text = oGuiaDevolucionService.SugerirNumero(registro.Locacion.IdLocacion)
                End If
            End If
        Else
            'lblAlmacen.Text = ""
            lblCliente.Text = ""
            lblCodMon.Text = ""
            lblCodMot.Text = ""
            lbldLocCli.Text = ""
            lblFecha.Text = ""
            lblIgv.Text = ""
            lblNumJob.Text = ""
        End If
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Insertar()
        End If
    End Sub
    Private Sub btnBuscarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDocumento.Click
        Dim frm As New frmBuscarTipoDocumentoGFB
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumero.BackColor = System.Drawing.SystemColors.Control
            txtNumero.Text = frm.numero
            codigo = frm.codigo
            tipo_doc = frm.tipo
            'gbDocumento.Text = frm.titulo
            txtNumero.Select()
            ObtenerDocumento_GFB()
            LlenarObservacion()
        End If
    End Sub

    Private Sub LlenarObservacion()
        If tipo_doc = 1 Then
            txtObservacion.Text = "REFERENCIA: G/R " & txtNumero.Text & "   FECHA: " & lblFecha.Text
        ElseIf tipo_doc = 2 Then
            txtObservacion.Text = "REFERENCIA: F/ " & txtNumero.Text & "   FECHA: " & lblFecha.Text
        ElseIf tipo_doc = 3 Then
            txtObservacion.Text = "REFERENCIA: B/ " & txtNumero.Text & "   FECHA: " & lblFecha.Text
        End If
    End Sub

    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmGuiaDevolucion_ModificarObservacion
        frm.state_button = state_button
        frm.IdGuiaDev = IdGuiaDev
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()

    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.Select()
            btnGuardar_Click(sender, e)
        End If
    End Sub


End Class
