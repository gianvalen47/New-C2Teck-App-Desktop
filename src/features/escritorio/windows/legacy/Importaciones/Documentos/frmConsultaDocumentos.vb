Imports System.ServiceModel
Public Class frmConsultaDocumentos
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private dtOficina As New DataTable
    Private dtMes As New DataTable
    Private dtDocumento As New DataTable
    Private dtConsolidado As New DataTable
    Private dtAlmacen As New DataTable
    Private dtTipos As New DataTable

    Private Sub frmConsultaDocumentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
    Private Sub frmConsultaDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub llenarCombos()

        Try
            txtPeriodo.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))

            dtMes = ObjMaestro.MostrarMeses
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            'cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            dtOficina = ObjMaestro.MostrarOficinas("").Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            dtDocumento = ObjDocumento.MostrarTipoDocumentoCosto.Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Nombre"
            cbDocumento.ValueMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(1).DataMember = "Nombre"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing

            '/////////////////////////////////// Tipo Facturas ////////////////////////////////
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            dtTipos.Rows.Add(New Object() {"1", "Crédito"})
            dtTipos.Rows.Add(New Object() {"2", "Contado"})

            cmbTipFac.DataSource = dtTipos
            cmbTipFac.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.SelectedIndex = 1
            dtTipos = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "Todos"
        Catch ex As Exception
            fila(0) = 0
        End Try
       
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception
        End Try


        Return fila
    End Function
    Private Sub frmConsultaDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDocumentos)
        llenarCombos()
        LlenarGrilla()
        enableOpciones()
        cbMes.Value = Today.Month
        dgDocumentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        dgDocumentos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
    End Sub
    Private Sub enableOpciones()
        If dgDocumentos.RowCount < 1 Then
            biActualizar.Enabled = False
            biEstados.Enabled = False
            biImprimir.Enabled = False
            biMostrar.Enabled = False

            miActualizar.Enabled = False
            miEstados.Enabled = False
            miImprimir.Enabled = False
            miMostrar.Enabled = False
        Else
            biActualizar.Enabled = True
            If cbDocumento.Value = 1 Then
                biEstados.Enabled = True
                miEstados.Enabled = True
            Else
                biEstados.Enabled = False
                miEstados.Enabled = False
            End If
            biImprimir.Enabled = True
            biMostrar.Enabled = True

            miActualizar.Enabled = True
            miImprimir.Enabled = True
            miMostrar.Enabled = True
        End If
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If dtConsolidado.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmConsultaDocumento
            forma.pTipDoc = dgDocumentos.CurrentRow.Cells(9).Text
            forma.pIdMovimiento = dgDocumentos.CurrentRow.Cells(0).Text
            forma.pTipo = dgDocumentos.CurrentRow.Cells(10).Text
            forma.ShowDialog()
        End If
    End Sub
    Public Sub LlenarGrilla()
        Try
            dtConsolidado = ObjDocumento.FiltrarDocumentos(txtPeriodo.Value, cbMes.Value, Session.sCodEmp, cbOficina.Value, cbAlmacen.Value, cbDocumento.Value, cmbTipFac.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text)).Tables(0)
            Me.dgDocumentos.SetDataBinding(dtConsolidado, 0)
            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub
    'Private Sub Finalizar() Handles biSalir.Click
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
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, "").Tables(0)
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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbMes.ValueChanged, cbAlmacen.ValueChanged, cbDocumento.ValueChanged, cbOficina.ValueChanged, txtNumero.TextChanged, txtPeriodo.TextChanged, cmbTipFac.ValueChanged
        If cbDocumento.Value = 3 Then
            cmbTipFac.Enabled = True
            LlenarGrilla()
        Else
            cmbTipFac.Value = ""
            LlenarGrilla()
        End If
    End Sub

    Private Sub dgDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumentos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub dgDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDocumentos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgDocumentos.RowCount > 0 Then
                biMostrar_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumero.Select()
        End If
    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            If cbDocumento.Value = 1 Then
                Dim frm As New frmGuiaRemision_Estados

                frm.IdGuia = dgDocumentos.CurrentRow.Cells("IdMovimiento").Text
                frm.Text = "Estados de Guía de Remisión Nº : " + dgDocumentos.CurrentRow.Cells("NumDoc").Text.ToString
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

                End If
            Else
                MsgBox("No esta configurado...")
            End If
          
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click

    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        LlenarGrilla()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
    Private Sub Estado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.MouseEnter, miEstados.MouseEnter
        sslError.Text = "Mostrar los Estados del Documento."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, biMostrar.MouseLeave, biEstados.MouseLeave, _
                                    biActualizar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, miMostrar.MouseLeave, miEstados.MouseLeave, _
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