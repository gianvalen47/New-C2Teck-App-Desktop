Public Class frmConsultaDocumentoAlmacen

    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient

    Private DocumentoAlmacen As New DocumentoCostoService.DocumentoAlmacen
    Public pIdMovimiento As Int64
    Public pTipDoc As Int16


    Private Sub frmConsultaDocumentoAlmacen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmConsultaDocumentoAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmConsultaDocumentoAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDetalle)
        dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        LlenarDatos()
    End Sub

    Private Sub llenarDatos()
        Try
            DocumentoAlmacen = ObjDocumento.MostrarPorIdAlmacen(pIdMovimiento, pTipDoc)
            txtNumero.Text = DocumentoAlmacen.NumDoc
            txtFecDoc.Text = DocumentoAlmacen.FecDoc
            txtCliente.Text = DocumentoAlmacen.Cliente.DesCli
            txtNumJob.Text = DocumentoAlmacen.NumJob
            txtMotorOrigen.Text = DocumentoAlmacen.MotorOrigen.CodMer
            txtMotorDestino.Text = DocumentoAlmacen.MotorDestino.CodMer
            txtMotivoMTD.Text = DocumentoAlmacen.MotMtd
            txtArea.Text = DocumentoAlmacen.Area.DesArea
            txtPersona.Text = DocumentoAlmacen.Persona.ApeNom
            txtMoneda.Text = DocumentoAlmacen.Moneda.DesMon
            txtTipCam.Text = ObjMaestro.MostrarTipoCambio("US", DocumentoAlmacen.FecDoc)
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
                dgDetalle.Size = New System.Drawing.Size(657, 193)
                dgDetalle.Location = New System.Drawing.Point(9, 204)
            Else
                gpMti.Visible = False
                dgDetalle.Size = New System.Drawing.Size(657, 239)
                dgDetalle.Location = New System.Drawing.Point(9, 162)
            End If
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
            Dim dtDetalle As DataTable
            dtDetalle = ObjDocumento.MostrarDetalles(pIdMovimiento, TipMov, pTipDoc, 2, Year(DocumentoAlmacen.FecDoc)).Tables(0)
            Me.dgDetalle.SetDataBinding(dtDetalle, 0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

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
            txtNumero.Select()
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