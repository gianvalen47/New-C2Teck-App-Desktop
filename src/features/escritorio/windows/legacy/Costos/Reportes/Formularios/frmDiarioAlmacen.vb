Imports System.ServiceModel
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Public Class frmDiarioAlmacen

    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private dtTipoMovimientos As DataTable
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable
    Private dtDocumento As New DataTable
    Private dtMotivos As New DataTable
    Private dtAreas As New DataTable
    Dim IdCliente As Integer
    Private lTipFac As String
    Private state_button As Boolean


    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

        Select Case e.Item.Index
            Case 0
                gbFacturacion.Visible = False
                gbArea.Visible = False
                gbNumJob.Visible = False
                gbDocumento.Enabled = True
                gbMotivos.Enabled = True
                cbArea.SelectedIndex = 0
                state_button = True
                txtNumJob.Text = ""
            Case 1
                gbFacturacion.Visible = False
                gbArea.Visible = True
                gbNumJob.Visible = True
                gbDocumento.Enabled = False
                gbMotivos.Enabled = False
                cbDocumento.SelectedIndex = 0
                cbMotivo.SelectedIndex = 0
                state_button = True
            Case 2
                gbFacturacion.Visible = True
                gbArea.Visible = False
                gbNumJob.Visible = False
                gbDocumento.Enabled = True
                gbMotivos.Enabled = True
                cbArea.SelectedIndex = 0
                state_button = False
                txtNumJob.Text = ""

        End Select
    End Sub

    Private Sub LlenarCombos()
        Try
            '/////////OFICINA ORIGEN////////////////
            dtOficina = ObjMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            '///////////OFICINA DESTINO/////////////
            dtOficina = ObjMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            Dim row As DataRow = dtOficina.NewRow
            row(0) = ""
            row(1) = "(Todos)"
            dtOficina.Rows.InsertAt(row, 0)
            cbOficinaDestino.DataSource = dtOficina
            cbOficinaDestino.DisplayMember = "DesOfi"
            cbOficinaDestino.ValueMember = "CodOfi"
            cbOficinaDestino.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficinaDestino.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficinaDestino.SelectedIndex = 0
            dtOficina = Nothing


            '////////////TIPO DE MOVIMIENTO///////////////
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"H", "INGRESOS"})
            dtTipoMovimientos.Rows.Add(New Object() {"D", "SALIDAS"})
            dtTipoMovimientos.Rows.Add(New Object() {"C", "COSTOS"})
            cbTipoMovimiento.DataSource = dtTipoMovimientos
            cbTipoMovimiento.DisplayMember = "Nombre"
            cbTipoMovimiento.ValueMember = "Tipo"
            cbTipoMovimiento.DropDownList.Columns(0).DataMember = "Tipo"
            cbTipoMovimiento.DropDownList.Columns(1).DataMember = "Nombre"
            cbTipoMovimiento.SelectedIndex = 0
            dtTipoMovimientos = Nothing


            '/////////MOTIVOS///////////////
            dtMotivos = ObjMaestro.MostrarMotivos().Tables(0)
            Dim rowm As DataRow = dtMotivos.NewRow
            rowm(0) = ""
            rowm(1) = "(Todos)"
            dtMotivos.Rows.InsertAt(rowm, 0)
            cbMotivo.DataSource = dtMotivos
            cbMotivo.DisplayMember = "DesMot"
            cbMotivo.ValueMember = "CodMot"
            cbMotivo.DropDownList.Columns(0).DataMember = "CodMot"
            cbMotivo.DropDownList.Columns(1).DataMember = "DesMot"
            cbMotivo.SelectedIndex = 0
            dtMotivos = Nothing

            '////////TIPO DE DOCUMENTO///////////
            dtDocumento = ObjDocumento.MostrarSerieDocumentoCostos().Tables(0)
            Dim rowd As DataRow = dtDocumento.NewRow
            rowd(0) = 0
            rowd(1) = "(Todos)"
            dtDocumento.Rows.InsertAt(rowd, 0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Descripcion"
            cbDocumento.ValueMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(1).DataMember = "Descripcion"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing


            '/////////AREAS///////////////
            dtAreas = ObjMaestro.MostrarAreas().Tables(0)
            Dim rowa As DataRow = dtAreas.NewRow
            rowa(0) = ""
            rowa(2) = "(Todos)"
            dtAreas.Rows.InsertAt(rowa, 0)
            cbArea.DataSource = dtAreas
            cbArea.DisplayMember = "DesArea"
            cbArea.ValueMember = "CodArea"
            cbArea.DropDownList.Columns(0).DataMember = "CodArea"
            cbArea.DropDownList.Columns(1).DataMember = "DesArea"
            cbArea.SelectedIndex = 0
            dtAreas = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Cargar Almacenes")
        End Try


    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim dtReporte As New DataTable
            Dim Facturado, Comprobante, TipFac As Int16
            Dim Doc As String = ""
            If gbFacturacion.Visible Then
                If rbFacturado.Checked Then
                    Facturado = 1
                ElseIf rbNoFacturado.Checked Then
                    Facturado = 2
                End If
            Else
                Facturado = 0
            End If
            If rbFactura.Checked Then
                Comprobante = 1
                Doc = rbFactura.Text
            ElseIf rbBoleta.Checked Then
                Comprobante = 2
                Doc = rbBoleta.Text
            ElseIf rbNota.Checked Then
                Comprobante = 3
                Doc = rbNota.Text
            End If

            TipFac = IIf(rbCredito.Checked, 1, 2)
            dtReporte = ObjCierre.ReporteDiarioAlmacen(cbAlmacen.Value, cbFecInicio.Value, cbFecFinal.Value, cbTipoMovimiento.Value, cbDocumento.Value, cbMotivo.Value, cbArea.Value, txtNumJob.Text, Facturado, Comprobante, TipFac, cbAlmacenDestino.Value, IIf(rbDetalle.Checked, 1, 2), lTipFac, IdCliente).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verifique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
            Else
                Dim forma As New frmReportes
                If rbDetalle.Checked Then
                    Dim reporte As New rpDiarioAlmacen
                    Dim Condicion As String = ""
                    Dim Destino As String = ""
                    If cbMotivo.Value <> "" Then
                        Condicion = "Motivo : " & cbMotivo.Text
                    ElseIf cbArea.Value <> "" Or Trim(txtNumJob.Text) <> "" Then
                        Condicion = IIf(cbArea.Value <> "", "Area : " & Trim(cbArea.Text), "") & IIf(Trim(txtNumJob.Text) = "", "", IIf(cbArea.Value = "", "Job : " & txtNumJob.Text, " / Job : " & txtNumJob.Text))
                    End If
                    If cbAlmacenDestino.Value > 0 Then
                        Destino = "Destino : " & Trim(cbOficinaDestino.Text) & " - " & cbAlmacenDestino.Text
                    End If
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("Titulo", "DIARIO DE " & cbTipoMovimiento.Text & " DE ALMACEN")
                    reporte.SetParameterValue("Fecha", "DEL " & cbFecInicio.Value & " AL " & cbFecFinal.Value)
                    reporte.SetParameterValue("Condicion", Condicion)
                    reporte.SetParameterValue("Destino", Destino)
                    reporte.SetParameterValue("Facturado", IIf(Facturado = 1, "Facturado", IIf(Facturado = 2, "No Facturado", "")))
                    reporte.SetParameterValue("Comprobante", IIf(rbNoFacturado.Checked, "", IIf(Facturado = 0, "", IIf(rbNota.Checked, Doc, Doc & IIf(rbCredito.Checked, " Al Credito", " Al Contado")))))

                    If txtCliente.Text <> "" Then
                        reporte.SetParameterValue("Cliente", txtCliente.Text)
                    Else
                        reporte.SetParameterValue("Cliente", "")
                    End If

                ElseIf rbTotalizado.Checked Then
                    Dim reporte As New rpDiarioAlmacenTotales
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("Fecha", "DEL " & cbFecInicio.Value & " AL " & cbFecFinal.Value)
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Diario de Almacen"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Mostrar Datos")
        End Try

    End Sub

    Private Sub frmDiarioAlmacen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(ObjCierre) = False Then
                ObjCierre.Close()
            End If
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmDiarioAlmacen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDiarioAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Mes, Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        LlenarCombos()
        gbFacturacion.Visible = False
        IdCliente = 0
        lTipFac = ""
        'Me.Size = New System.Drawing.Size(512, 366)
    End Sub

    Private Sub cbOficinaDestino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficinaDestino.ValueChanged
        dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficinaDestino.Value, Session.sCodUsu).Tables(0)
        Dim row As DataRow = dtAlmacen.NewRow
        row(0) = 0
        row("DesAlm") = "(Todos)"
        dtAlmacen.Rows.InsertAt(row, 0)
        cbAlmacenDestino.DataSource = dtAlmacen
        cbAlmacenDestino.DisplayMember = "DesAlm"
        cbAlmacenDestino.ValueMember = "IdLocacion"
        cbAlmacenDestino.DropDownList.Columns(0).DataMember = "IdLocacion"
        cbAlmacenDestino.DropDownList.Columns(1).DataMember = "DesAlm"
        cbAlmacenDestino.SelectedIndex = 0
        dtAlmacen = Nothing
    End Sub

    'Private Sub Finalizar()
    '    Try
    '        ObjMaestro.Close()
    '        ObjDocumento.Close()
    '        ObjCierre.Close()
    '    Catch ex As TimeoutException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '        ObjCierre.Abort()
    '    Catch ex As CommunicationException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '        ObjCierre.Abort()
    '    End Try
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbNoFacturado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoFacturado.CheckedChanged
        gbComprobante.Visible = False
        gbCondicion.Visible = False
        gbFacturacion.Size = New System.Drawing.Size(112, 56)

    End Sub

    Private Sub rbFacturado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFacturado.CheckedChanged
        gbComprobante.Visible = True
        gbCondicion.Visible = True
        rbFactura.Checked = True
        rbCredito.Checked = True
        gbFacturacion.Size = New System.Drawing.Size(112, 200)

    End Sub

    Private Sub rbNota_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNota.CheckedChanged
        gbCondicion.Visible = False
        gbFacturacion.Size = New System.Drawing.Size(112, 137)
    End Sub

    Private Sub rbFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFactura.CheckedChanged
        gbCondicion.Visible = True
        gbFacturacion.Size = New System.Drawing.Size(112, 200)
    End Sub

    Private Sub rbBoleta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBoleta.CheckedChanged
        gbCondicion.Visible = True
        gbFacturacion.Size = New System.Drawing.Size(112, 200)
    End Sub

    Private Sub rbTotalizado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotalizado.CheckedChanged
        gbTipoMovimiento.Visible = False
        gbDocumento.Visible = False
        gbMotivos.Visible = False
        gbDestino.Visible = False
        gbArea.Visible = False
        gbNumJob.Visible = False
        gbFacturacion.Visible = False
        ExplorerBar1.Enabled = False
    End Sub

    Private Sub rbDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetalle.CheckedChanged
        gbTipoMovimiento.Visible = True
        gbDocumento.Visible = True
        gbMotivos.Visible = True
        gbDestino.Visible = True
        ExplorerBar1.Enabled = True
    End Sub

    Private Sub cbDocumento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDocumento.ValueChanged
        If cbDocumento.Value = 2 Or cbDocumento.Value = 3 Then
            gbCondicionFact.Visible = True
            gbCondicionFact.Location = New System.Drawing.Size(8, 150)
            '///////////////
            gbFacturacion.Visible = False
        Else
            gbCondicionFact.Visible = False
            If state_button = False Then
                gbFacturacion.Visible = True
            End If
        End If
    End Sub

    Private Sub Condicion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged, rbCredito1.CheckedChanged, rbContado1.CheckedChanged
        If rbTodos.Checked Then
            lTipFac = ""
        ElseIf rbCredito1.Checked Then
            lTipFac = 1
        ElseIf rbContado1.Checked Then
            lTipFac = 2
        End If

    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        IdCliente = 0
        txtCliente.Clear()
    End Sub

  
End Class