Imports System.ServiceModel

Public Class frmComSolicitudCompras

    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtArea As DataTable
    Private dtEstados As DataTable

    Private Sub frmComSolicitudCompras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudCompraService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSolicitudCompraService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Close()
        Catch ex As CommunicationException
            oSolicitudCompraService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmComSolicitudCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 130)
        '/*************************************************************************************/

        Me.Text = "Solicitud de Compra"

        llenarCombos()
        listaDatos()
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        cmbAnio.Value = Today.Year
        'CargarArea()
        enableOpciones()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows
            If CInt(row.Cells("IdSolicitud").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub CargarArea()
        'Try
        '    If Session.CodPerfil <> "01" And Session.CodPerfil <> "30" And Session.CodPerfil <> "28" Then
        '        Dim area As SeguridadService.Usuario
        '        area = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        '        cmbArea.Value = area.Persona.CentroCosto.Area.CodArea
        '        cmbArea.ReadOnly = True
        '        cmbArea.BackColor = System.Drawing.SystemColors.Control
        '    End If           
        'Catch ex As Exception
        '    MsgBox("Error al Cargar el Area : " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
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
        Return fila
    End Function

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount = 0 Then
                biMostrar.Enabled = False
                biEliminar.Enabled = False
                biImprimir.Enabled = False
                biActualizar.Enabled = False
                biGenerar.Enabled = False
                biEstados.Enabled = False
                'biEnviar.Enabled = False
                biAnular.Enabled = False

                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miImprimir.Enabled = False
                miActualizar.Enabled = False
                miGenerar.Enabled = False
                miEstados.Enabled = False
                'miEnviar.Enabled = False
                miAnular.Enabled = False

            Else
                Dim lEstado As Integer
                lEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text

                biMostrar.Enabled = True
                biEliminar.Enabled = IIf(lEstado = 1, True, False)
                biImprimir.Enabled = True
                biActualizar.Enabled = True
                biGenerar.Enabled = IIf(lEstado = 3 Or lEstado = 7, True, False)
                biAprobar.Enabled = IIf(lEstado = 2, True, False)
                biEstados.Enabled = True
                'biEnviar.Enabled = IIf(lEstado = 1, True, False)
                biAnular.Enabled = IIf(lEstado = 3 Or lEstado = 2, True, False)

                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(lEstado = 1, True, False)
                miImprimir.Enabled = True
                miActualizar.Enabled = True
                miGenerar.Enabled = IIf(lEstado = 3 Or lEstado = 7, True, False)
                miAprobar.Enabled = IIf(lEstado = 2, True, False)
                miEstados.Enabled = True
                'miEnviar.Enabled = IIf(lEstado = 1, True, False)
                miAnular.Enabled = IIf(lEstado = 3 Or lEstado = 2, True, False)

            End If
        Catch ex As Exception
            MsgBox("Error al habilitar los botones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '-------------------Area---------------------------------------------
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtArea.Rows.Count > 1 Then
                dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            End If            
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing
            '-----------------Estados -------------------------------------------
            dtEstados = oSolicitudCompraService.MostrarEstados.Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstados.DataSource = dtEstados
            cmbEstados.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstados.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstados.SelectedIndex = 0
           
        Catch ex As Exception
            MsgBox("Error al llenar los combos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudCompraService.Filtrar(Session.sCodEmp, toNumber(cmbAnio.Value), toBlank(cmbArea.Value), toNumber(cmbEstados.Value), toNumber(txtNumSolicitud.Text), Session.sCodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmComSolicitudCompra
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.IdSolicitud)
                biMostrar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al crear nueva solicitud de compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try      
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            Dim frm As New frmComSolicitudCompra
            If dgvDatos.RowCount > 0 Then
                frm.state_button = True
                frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
                biActualizar_Click(sender, e)
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox("Error al mostrat los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If MsgBox("¿Está Seguro de ELIMINAR la solicitud de compra N°: " & dgvDatos.CurrentRow.Cells("IdSolicitud").Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudCompraService.Borrar(dgvDatos.CurrentRow.Cells("IdSolicitud").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If estado_process Then
                    MsgBox("Se eliminó el registro correctamente ")
                    biActualizar_Click(sender, e)
                Else
                    MsgBox("Error en el proceso , comunicarse con el administrador del sistema", MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar la Solicitud de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptSolicitudCompra

            If dgvDatos.RowCount > 0 Then
                dtReporte = oSolicitudCompraService.Imprimir(dgvDatos.CurrentRow.Cells("IdSolicitud").Text).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Solicitud Compra"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        Try
            Dim frm As New frmComSolicitudCompra_Generar
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al Generar el Documento : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
    '    Try
    '        If MsgBox("¿Estás Seguro de Enviar la solicitud de compra N°:" & dgvDatos.CurrentRow.Cells("IdSolicitud").Text & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '            Dim estado_process As Boolean
    '            estado_process = oSolicitudCompraService.Enviar(dgvDatos.CurrentRow.Cells("IdSolicitud").Text, "", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '            If estado_process Then
    '                MsgBox("Se envio correctamente la solicitud de compra")
    '                biActualizar_Click(sender, e)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al Enviar a Aprobación : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            biMostrar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbAnio.ValueChanged, cmbArea.ValueChanged, cmbEstados.ValueChanged, txtNumSolicitud.TextChanged
        listaDatos()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar los Datos : " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            Dim frm As New frmComSolicitudCompra_Aprobar
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar la solicitud de compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            Dim frm As New frmComSolicitudCompra_Estados
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al ver los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave,
                                 biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave,
                                 biAprobar.MouseLeave, biEstados.MouseLeave, biGenerar.MouseLeave,
                                 miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave,
                                 miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave,
                                 miAprobar.MouseLeave, miEstados.MouseLeave, miGenerar.MouseLeave,
                                 miAnular.MouseLeave, biAnular.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biImprimir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Solicitud de Compra actual."
    End Sub
    Private Sub biNuevo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Solicitud de Compra."
    End Sub
    Private Sub biMostrar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Solicitud de Compra Actual."
    End Sub
    Private Sub biAnular_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular Solicitud de Compra Actual."
    End Sub
    Private Sub biEliminar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Solicitud de Compra Seleccionada."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Salir de la Ventana Actual."
    End Sub
    Private Sub biAprobar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar la Solicitud de Compra."
    End Sub
    Private Sub biGenerar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Generar Orden de Compra."
    End Sub
    Private Sub biEstados_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEstados.MouseEnter, miEstados.MouseEnter
        sslError.Text = "Ver Estados de la Solicitud de Compra."
    End Sub
    Private Sub biEnviar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        sslError.Text = "Enviar Solicitud de Compra a Aprobación."
    End Sub

    Private Sub biAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComSolicitudCompra_Anular
                frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ANULAR la Solicitud de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biArchivo_Click(sender As Object, e As EventArgs) Handles biArchivo.Click, miArchivo.Click
        Try
            Dim frm As New frmComSolicitudCompra_Archivos
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
            frm.NumOrden = dgvDatos.CurrentRow.Cells("IdSolicitud").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DE LA ORDEN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class