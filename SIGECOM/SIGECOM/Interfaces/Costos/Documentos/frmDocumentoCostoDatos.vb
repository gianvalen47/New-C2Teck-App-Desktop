Imports System.ServiceModel
Public Class frmDocumentoCostoDatos
    Public pIdMovimiento As Int64
    Public pTipDoc As Int16
    Public pTipo As Int16
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private DocumentoVenta As New DocumentoCostoService.DocumentoVenta
    Private DocumentoAlmacen As New DocumentoCostoService.DocumentoAlmacen
    Private oTransferencia As New TransferenciaService.TransferenciaServiceClient
    Private oTransferenciaMotor As New TransferenciaMotorService.TransferenciaMotorServiceClient
    Private dtDetalle As DataTable

    Private Sub frmDocumentoCostoDatos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmDocumentoCostoDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnSalir_Click(sender, e)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows
                If CInt(row.Cells("IdMovimientoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If

            Next

        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmDocumentoCostoDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDetalle)
        dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgDetalle.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        LlenarDatos()
        dgDetalle.Select()
        Dim forma As New frmImprimirCosto
       
    End Sub
   
    Private Sub LlenarDatos()
        Try
            Select Case pTipo
                Case 1
                    DocumentoVenta = ObjDocumento.MostrarPorIdVenta(pIdMovimiento, pTipDoc)
                    txtNumero.Text = DocumentoVenta.NumDoc
                    txtFecDoc.Text = DocumentoVenta.FecDoc
                    txtCliente.Text = DocumentoVenta.Cliente.DesCli
                    txtCodMot.Text = DocumentoVenta.Motivos.CodMot
                    txtMotivo.Text = DocumentoVenta.Motivos.DesMot
                    txtFactura.Text = DocumentoVenta.NumFac
                    txtGuias.Text = DocumentoVenta.NumGuis
                    txtNumJob.Text = DocumentoVenta.NumJob
                    txtCondicionPago.Text = DocumentoVenta.CondicionPago.DesPag
                    txtMoneda.Text = DocumentoVenta.Moneda.DesMon
                    txtTipCam.Text = ObjMaestro.MostrarTipoCambio(DocumentoVenta.Moneda.CodMon, DocumentoVenta.FecDoc)
                    Me.Text = DocumentoVenta.Locacion.Oficina.DesOfi & " - " & DocumentoVenta.Locacion.Almacen.DesAlm & " / " & DocumentoVenta.SerieDocumento.TipoDocumento.Nombre & "(" & DocumentoVenta.SerieDocumento.TipoDocumento.AbrDoc & ") " & DocumentoVenta.SerieDocumento.CodSerie & "-" & Trim(DocumentoVenta.NumDoc)
                    dgDetalle.Size = New System.Drawing.Size(654, 231)
                    dgDetalle.Location = New System.Drawing.Point(3, 183)
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
                    txtFactura.Text = DocumentoAlmacen.NumFac
                    txtTipCam.Text = ObjMaestro.MostrarTipoCambio(DocumentoAlmacen.Moneda.CodMon, DocumentoAlmacen.FecDoc)
                    Me.Text = DocumentoAlmacen.Locacion.Oficina.DesOfi & " - " & DocumentoAlmacen.Locacion.Almacen.DesAlm & " / " & DocumentoAlmacen.SerieDocumento.TipoDocumento.Nombre & "(" & DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc & ") " & DocumentoAlmacen.SerieDocumento.CodSerie & "-" & Trim(DocumentoAlmacen.NumDoc)
                    If Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "MTI" Or Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "MTD" Then
                        gpMti.Visible = True
                        dgDetalle.Size = New System.Drawing.Size(654, 193)
                        dgDetalle.Location = New System.Drawing.Point(3, 228)
                        btnProrratear.Visible = True
                        ToolStripSeparatorProrratear.Visible = True
                    Else
                        gpMti.Visible = False
                        dgDetalle.Size = New System.Drawing.Size(654, 231)
                        dgDetalle.Location = New System.Drawing.Point(3, 183)
                    End If

                    If Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "T/I" Or Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "T/M" Then
                        biActualizarCosto.Enabled = True
                    Else
                        biActualizarCosto.Enabled = False
                    End If

                    If Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "MTI" And DocumentoAlmacen.Locacion.IdLocacion = 54 Then
                        biActualizarCostosMTI.Enabled = True
                    Else
                        biActualizarCostosMTI.Enabled = False
                    End If

            End Select
            LlenarGrilla()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Mostrar Datos")
        End Try
    End Sub
    Public Sub LlenarGrilla()
        Try
            ObjDocumento.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            dtDetalle = ObjDocumento.MostrarDetalles(pIdMovimiento, TipMov, pTipDoc, pTipo, IIf(pTipo = 1, Year(DocumentoVenta.FecDoc), Year(DocumentoAlmacen.FecDoc))).Tables(0)
            Me.dgDetalle.SetDataBinding(dtDetalle, 0)

            txtTotCosDol.Text = Format(getTotalDolares("Dolares"), "##,##0.00")
            txtTotCosSol.Text = Format(getTotalSoles("Soles"), "##,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub
    Private Function getTotalDolares(ByVal columna As String) As Double

        Dim total As Double = 0

        For Each Fila As DataRow In dtDetalle.Rows
            Dim contador As Double

            contador = Fila.Item("TotDol")
            total = total + contador

        Next
        Return total
    End Function
    Private Function getTotalSoles(ByVal columna As String) As Double

        Dim total As Double = 0

        For Each Fila As DataRow In dtDetalle.Rows
            Dim contador As Double

            contador = Fila.Item("TotSol")
            total = total + contador

        Next
        Return total
    End Function

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click, cmMostrar.Click, dgDetalle.DoubleClick
        Dim forma As New frmDocumentoCostoDet
        forma.pIdMovimientoDet = dgDetalle.CurrentRow.Cells(0).Text
        forma.pTipDoc = dgDetalle.CurrentRow.Cells(8).Text
        forma.pTipo = dgDetalle.CurrentRow.Cells(9).Text
        forma.ShowDialog(Me)
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click, cmModificar.Click
        If Modificable() = True Then
            Dim forma As New frmDocumentoCostoDet
            forma.pIdMovimientoDet = dgDetalle.CurrentRow.Cells(0).Text
            forma.pTipDoc = dgDetalle.CurrentRow.Cells(8).Text
            forma.pTipo = dgDetalle.CurrentRow.Cells(9).Text
            forma.txtCosDol.ReadOnly = False
            forma.txtCosDol.BackColor = System.Drawing.SystemColors.Window
            forma.txtCosSol.ReadOnly = False
            forma.txtCosSol.BackColor = System.Drawing.SystemColors.Window
            forma.txtTotalCosDol.ReadOnly = False
            forma.txtTotalCosDol.BackColor = System.Drawing.SystemColors.Window
            forma.txtTotalCosSol.ReadOnly = False
            forma.txtTotalCosSol.BackColor = System.Drawing.SystemColors.Window
            forma.btnAceptar.Enabled = True
            forma.btnAceptar.Visible = True
            forma.ShowDialog()
            cmRefrescar_Click(sender, e)
        Else
            MsgBox("Para este documento no se modifica los Costos, tenga cuidado.!!!!!", MsgBoxStyle.Information, "No es Modificable")
        End If
        
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub cmRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmRefrescar.Click
        Dim codigo As String = ""
        If dgDetalle.RowCount > 0 Then
            codigo = dgDetalle.CurrentRow.Cells("IdMovimientoDet").Text
        End If
        dtDetalle = Nothing
        LlenarGrilla()
        If dgDetalle.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgDetalle, codigo)
        End If
        'enableOpciones()
    End Sub
    Private Function Modificable() As Boolean
        Dim resul As Boolean = False
        Select Case pTipo
            '1 = Documentos de Venta
            '2 = Documentos de Almacen
            Case 1
                If DocumentoVenta.TipMov = "H" Then
                    resul = True
                End If
            Case 2
                If dgDetalle.CurrentRow.Cells(10).Text = "H" Or dgDetalle.CurrentRow.Cells(10).Text = "C" Then
                    resul = True
                End If
        End Select
        Return resul
    End Function
    Private Function TipMov() As String
        Dim resul As String = ""
        If rbIngreso.Checked Then
            resul = "H"
        ElseIf rbSalida.Checked Then
            resul = "D"
        ElseIf rbTodos.Checked Then
            resul = ""
        End If
        Return resul
    End Function

    Private Sub rbIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIngreso.CheckedChanged
        LlenarGrilla()
    End Sub

    Private Sub rbSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSalida.CheckedChanged
        LlenarGrilla()
    End Sub

    Private Sub dgDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnMostrar.Enabled = True Then
                e.Handled = True
                btnMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnProrratear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProrratear.Click
        Dim frm As New frmDocumentoCostoProrratear
        frm.IdMemo = pIdMovimiento
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            MsgBox("Se realizó el prorrateo de los costos correctamente ")
            cmRefrescar_Click(sender, e)
        End If
    End Sub

    Private Sub biActualizarCosto_Click(sender As Object, e As EventArgs) Handles biActualizarCosto.Click
        If Modificable() = True Then
            DocumentoAlmacen = ObjDocumento.MostrarPorIdAlmacen(pIdMovimiento, pTipDoc)
            If Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "T/M" Then
                If MsgBox("¿Esta seguro de actualizar los costos desde el documento origen... ?", MsgBoxStyle.YesNo, "Actualizar Costos") = MsgBoxResult.Yes Then
                    oTransferenciaMotor.ActualizarCostosDocumentoOrigen(pIdMovimiento, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    cmRefrescar_Click(sender, e)
                End If
            ElseIf Trim(DocumentoAlmacen.SerieDocumento.TipoDocumento.AbrDoc) = "T/I" Then
                If MsgBox("¿Esta seguro de actualizar los costos desde el documento origen... ?", MsgBoxStyle.YesNo, "Actualizar Costos") = MsgBoxResult.Yes Then
                    oTransferencia.ActualizarCostosDocumentoOrigen(pIdMovimiento, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    cmRefrescar_Click(sender, e)
                End If
            End If
            
        Else
            MsgBox("Para este documento no se modifica los Costos, tenga cuidado.!!!!!", MsgBoxStyle.Information, "No es Modificable")
        End If
    End Sub

    Private Sub biActualizarCostosMTI_Click(sender As Object, e As System.EventArgs) Handles biActualizarCostosMTI.Click
        If Modificable() = True Then
            DocumentoAlmacen = ObjDocumento.MostrarPorIdAlmacen(pIdMovimiento, pTipDoc)            
                If MsgBox("¿Esta seguro de actualizar los costos de Ingreso del MTI?", MsgBoxStyle.YesNo, "Actualizar Costos") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = ObjDocumento.ActualizarCostoMTI(Session.sCodEmp, pIdMovimiento, DocumentoAlmacen.FecDoc)
                If estado_process Then
                    MsgBox("Se actualizó los costos del MTI correctamente.")
                    cmRefrescar_Click(sender, e)
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de TI.")
                End If
            End If
        Else
            MsgBox("Para este documento no se modifica los Costos, tenga cuidado.!!!!!", MsgBoxStyle.Information, "No es Modificable")
        End If
    End Sub
End Class
