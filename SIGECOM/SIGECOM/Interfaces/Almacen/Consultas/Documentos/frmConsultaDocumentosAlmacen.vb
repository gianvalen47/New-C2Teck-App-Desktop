Public Class frmConsultaDocumentosAlmacen

    Private objMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private objMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtConsolidado As DataTable
    Private dtAlmacen As DataTable
    Private dtMes As DataTable
    Private dtOficina As DataTable
    Private dtDocumento As DataTable


    Private Sub frmConsultaDocumentosAlmacen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(objMoviAlmacenService) = False Then
                objMoviAlmacenService.Close()
            End If
            If isClosed(objMaestro) = False Then
                objMaestro.Close()
            End If
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmConsultaDocumentosAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub enableOpciones()
        If dgDocumentos.RowCount < 1 Then
            biActualizar.Enabled = False
            biImprimir.Enabled = False
            biMostrar.Enabled = False

            miActualizar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
        Else
            biActualizar.Enabled = True
            biImprimir.Enabled = True
            biMostrar.Enabled = True

            miActualizar.Enabled = True
            miImprimir.Enabled = True
            miMostrar.Enabled = True
        End If
    End Sub

    Private Sub llenarCombos()

        Try
            txtPeriodo.Value = Year(Today)

            dtMes = objMaestro.MostrarMeses
            dtMes.Rows.InsertAt(getRowTodos(dtMes), 0)
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            'cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            dtOficina = objMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            dtDocumento = objMoviAlmacenService.MostrarTipoDocumentoAlmacen.Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Nombre"
            cbDocumento.ValueMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(1).DataMember = "Nombre"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing

            '/////////////////////////////////// Tipo Facturas ////////////////////////////////
          

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub frmConsultaDocumentosAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 106)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDocumentos)
        llenarCombos()
        LlenarGrilla()
        enableOpciones()

        cbMes.Value = Today.Month
        dgDocumentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        dgDocumentos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgDocumentos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If dtConsolidado.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmConsultaDocumentoAlmacen
            forma.pTipDoc = dgDocumentos.CurrentRow.Cells("TipDoc").Text
            forma.pIdMovimiento = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
            'forma.pTipo = dgDocumentos.CurrentRow.Cells(10).Text
            forma.ShowDialog()
        End If
    End Sub

    Public Sub LlenarGrilla()
        Try
            dtConsolidado = objMoviAlmacenService.FiltrarDocumentos(txtPeriodo.Value, cbMes.Value, Session.sCodEmp, cbOficina.Value, cbAlmacen.Value, cbDocumento.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text), toBlank(txtCodJob.Text), txtObservacion.Text).Tables(0)

            Me.dgDocumentos.SetDataBinding(dtConsolidado, 0)
            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = objMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, "").Tables(0)
            dtAlmacen.Rows.InsertAt(getRowTodos(dtAlmacen), 0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Almacenes")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbMes.ValueChanged, cbAlmacen.ValueChanged, cbDocumento.ValueChanged, cbOficina.ValueChanged, txtNumero.TextChanged, txtPeriodo.TextChanged, txtCodJob.TextChanged, txtObservacion.TextChanged
        LlenarGrilla()
    End Sub
    Private Sub dgDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumentos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub
    Private Sub dgDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDocumentos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgDocumentos.RowCount > 0 Then
                e.Handled = True
                biMostrar_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumero.Select()
        End If
    End Sub
   
    Private Sub Imprimir()

        Try
            Dim dtReporte As DataTable
            Dim forma As New frmReportes
            Dim reporteOriginalAlmacen As New rptConsultaOriginalAlmacen

            dtReporte = ObjDocumento.ImprimirDocAlmacen(dgDocumentos.CurrentRow.Cells("IdMovimiento").Text, dgDocumentos.CurrentRow.Cells("TipDoc").Text).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                'Me.Close()
            Else
                reporteOriginalAlmacen.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporteOriginalAlmacen
                forma.crvReportes.DisplayGroupTree = False

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False

                reporteOriginalAlmacen.SetParameterValue("Nombre", cbDocumento.Text)
                reporteOriginalAlmacen.SetParameterValue("NumeroDocumento", dgDocumentos.CurrentRow.Cells("NumDoc").Text)
                reporteOriginalAlmacen.SetParameterValue("motivo", dgDocumentos.CurrentRow.Cells("Tipo").Text)
                reporteOriginalAlmacen.SetParameterValue("NumeroLetra", objMaestro.ConvierteNumLetra(dgDocumentos.CurrentRow.Cells("TotNeto").Value, dgDocumentos.CurrentRow.Cells("CodMon").Text))
                reporteOriginalAlmacen.SetParameterValue("TipCam", objMaestro.MostrarTipoCambio("US", dgDocumentos.CurrentRow.Cells("FecDoc").Text))

                forma.Text = "Reporte de Documentos"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Imprimir()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        LlenarGrilla()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Documento Seleccionado."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Estado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sslError.Text = "Mostrar los Estados del Documento."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, biMostrar.MouseLeave, _
                                    biActualizar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, miMostrar.MouseLeave, _
                                    miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgDocumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDocumentos.KeyPress

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
