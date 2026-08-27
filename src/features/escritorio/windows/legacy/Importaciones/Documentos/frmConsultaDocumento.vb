Imports System.ServiceModel
Public Class frmConsultaDocumento
    Public pIdMovimiento As Int64
    Public pTipDoc As Int16
    Public pTipo As Int16
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private DocumentoVenta As New DocumentoCostoService.DocumentoVenta
    Private DocumentoAlmacen As New DocumentoCostoService.DocumentoAlmacen

    Private Sub frmConsultaDocumento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmConsultaDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmConsultaDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDetalle)
        dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        LlenarDatos()
    End Sub
    Private Sub LlenarDatos()
        Try
            Select Case pTipo
                Case 1
                    DocumentoVenta = ObjDocumento.MostrarPorIdVenta(pIdMovimiento, pTipDoc)
                    txtNumero.Text = DocumentoVenta.NumDoc
                    txtFecDoc.Text = DocumentoVenta.FecDoc
                    txtCliente.Text = DocumentoVenta.Cliente.DesCli
                    txtMotivo.Text = DocumentoVenta.Motivos.DesMot
                    txtFactura.Text = DocumentoVenta.NumFac
                    If toNumber(txtFactura.Text) = 0 Then
                        txtFactura.Text = ""
                    End If
                    txtNumOrden.Text = DocumentoVenta.NumOrden
                    txtVendedor.Text = DocumentoVenta.Persona.ApeNom
                    txtNumCoti.Text = DocumentoVenta.Cotizacion.NumCot
                    If toNumber(txtNumCoti.Text) = 0 Then
                        txtNumCoti.Text = ""
                    End If
                    txtUsuario.Text = DocumentoVenta.CodUsu
                    txtGuias.Text = DocumentoVenta.NumGuis
                    txtNumJob.Text = DocumentoVenta.NumJob
                    txtCondicionPago.Text = DocumentoVenta.CondicionPago.DesPag
                    txtMoneda.Text = DocumentoVenta.Moneda.DesMon
                    txtTipCam.Text = ObjMaestro.MostrarTipoCambio(DocumentoVenta.Moneda.CodMon, DocumentoVenta.FecDoc)
                    '/////////////////////////////////TOTALES////////////////////////////////////////////////////////
                    txtTotalPrecio.Text = DocumentoVenta.TotBruto
                    txtTotalDescuento.Text = DocumentoVenta.TotDscto
                    txtTotal.Text = DocumentoVenta.TotVenta
                    txtTotalIGV.Text = DocumentoVenta.TotIgv
                    txtTotalNeto.Text = DocumentoVenta.TotNeto

                    Me.Text = DocumentoVenta.Locacion.Oficina.DesOfi & " - " & DocumentoVenta.Locacion.Almacen.DesAlm & " / " & DocumentoVenta.SerieDocumento.TipoDocumento.Nombre & "(" & DocumentoVenta.SerieDocumento.TipoDocumento.AbrDoc & ") " & DocumentoVenta.SerieDocumento.CodSerie & "-" & Trim(DocumentoVenta.NumDoc)
                    dgDetalle.Size = New System.Drawing.Size(654, 231)
                    dgDetalle.Location = New System.Drawing.Point(3, 260)

                Case 2
                    DocumentoAlmacen = ObjDocumento.MostrarPorIdAlmacen(pIdMovimiento, pTipDoc)
                    txtNumero.Text = DocumentoAlmacen.NumDoc
                    txtFecDoc.Text = DocumentoAlmacen.FecDoc
                    txtCliente.Text = DocumentoAlmacen.Cliente.DesCli
                    txtNumJob.Text = DocumentoVenta.NumJob
                    txtMotorOrigen.Text = DocumentoAlmacen.MotorOrigen.CodMer
                    txtMotorDestino.Text = DocumentoAlmacen.MotorDestino.CodMer
                    txtMotivoMTD.Text = DocumentoAlmacen.MotMtd
                    txtArea.Text = DocumentoAlmacen.Area.DesArea
                    txtPersona.Text = DocumentoAlmacen.Persona.ApeNom
                    txtMoneda.Text = DocumentoAlmacen.Moneda.DesMon
                    txtTipCam.Text = ObjMaestro.MostrarTipoCambio(DocumentoAlmacen.Moneda.CodMon, DocumentoAlmacen.FecDoc)
                    txtUsuario.Text = DocumentoAlmacen.CodUsu
                    Me.Text = DocumentoAlmacen.Locacion.Oficina.DesOfi & " - " & DocumentoAlmacen.Locacion.Almacen.DesAlm & " / " & DocumentoAlmacen.SerieDocumento.TipoDocumento.Nombre & "(" & DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc & ") " & DocumentoAlmacen.SerieDocumento.CodSerie & "-" & Trim(DocumentoAlmacen.NumDoc)
                    '/////////////////////////////////TOTALES////////////////////////////////////////////////////////
                    txtTotalPrecio.Text = DocumentoAlmacen.TotBruto
                    txtTotalDescuento.Text = DocumentoAlmacen.TotDscto
                    txtTotal.Text = DocumentoAlmacen.TotVenta
                    txtTotalIGV.Text = DocumentoAlmacen.TotIgv
                    txtTotalNeto.Text = DocumentoAlmacen.TotNeto
                    If Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "MTI" Or Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "MTD" Then
                        gpMti.Visible = True
                        dgDetalle.Size = New System.Drawing.Size(654, 193)
                        dgDetalle.Location = New System.Drawing.Point(3, 300)
                    Else
                        gpMti.Visible = False
                        dgDetalle.Size = New System.Drawing.Size(654, 231)
                        dgDetalle.Location = New System.Drawing.Point(3, 260)
                    End If

            End Select
            LlenarGrilla()
            lblTotal.Text = "SUB TOTALES ==>  "
            lbltotalIGV.Text = "IGV ==>  "
            lblTotalNeto.Text = "TOTAL NETO ==> (" + txtMoneda.Text + ") "
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Mostrar Datos")
        End Try
    End Sub
    Public Sub LlenarGrilla()
        Try
            Dim dtDetalle As New DataTable
            dtDetalle = ObjDocumento.MostrarDetalles(pIdMovimiento, TipMov, pTipDoc, pTipo, IIf(pTipo = 1, Year(DocumentoVenta.FecDoc), Year(DocumentoAlmacen.FecDoc))).Tables(0)
            Me.dgDetalle.SetDataBinding(dtDetalle, 0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub
    'Private Sub Finalizar()
    '    Try
    '        ObjMaestro.Close()
    '        ObjDocumento.Close()
    '    Catch ex As TimeoutException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '    Catch ex As CommunicationException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '    End Try
    '    Me.Close()
    '    GC.SuppressFinalize(Me)
    'End Sub
    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        LlenarGrilla()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        ' Finalizar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Function TipMov() As String
        Dim resul As String = ""
        If rbIngreso.Checked Then
            resul = "H"
        ElseIf rbSalida.Checked Then
            resul = "D"
        End If
        Return resul
    End Function

    Private Sub rbIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIngreso.CheckedChanged
        LlenarGrilla()
    End Sub

    Private Sub rbSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSalida.CheckedChanged
        LlenarGrilla()
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  biActualizar.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalle.KeyDown
        If e.KeyCode = Keys.Delete Then
            txtNumCoti.Select()
        End If
       
    End Sub

    Private Sub dgDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDetalle.KeyPress

        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub
End Class