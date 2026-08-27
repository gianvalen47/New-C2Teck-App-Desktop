Imports System.ServiceModel
Imports System.Xml
Imports System.IO

Public Class frmCuentasPorPagar

    '===========================Servicios====================================================
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public iPagos As Boolean
    Public IdProveedor As Integer
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtDatos As New DataTable

    '==========================Evento Load===================================================
    Private Sub frmCuentasPorPagar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Proveedor")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Proveedor")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        txtAnio.Value = Today.Year
        cmbMes.Value = Today.Month
        IdProveedor = 0
        txtProveedor.Text = "(Todos)"
        cmbEstado.Value = 1
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtAnio.KeyPress _
                        , cmbMes.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtIdGasto.KeyPress _
                      , txtProveedor.KeyPress _
                      , txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed=============================================
    Private Sub frmCuentasPorPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCtasPorPagarService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oCtasPorPagarService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oCtasPorPagarService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmCuentasPorPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biConsulEstados.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miConsultarEstados.Enabled = False
        Else
            iPagos = oCtasPorPagarService.BuscarPagos(dgvDatos.CurrentRow.Cells("IdCuenta").Value)
            Dim lEstado As Integer
            lEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(lEstado = 1, True, False)
            biConsulEstados.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(lEstado = 1, True, False)
            miCancelacionManual.Enabled = IIf(lEstado = 1, True, False)
            miConsultarEstados.Enabled = True
        End If
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdCuenta").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmCuentasPorPagar_Nuevo
            'Dim lEstado As Integer
            'lEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
            frm.state_button = True
            frm.IdCuenta = dgvDatos.CurrentRow.Cells("IdCuenta").Text
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdCuenta)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA CUENTA POR PAGAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Cuenta Por Pagar Nº " + dgvDatos.CurrentRow.Cells("IdCuenta").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oCtasPorPagarService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdCuenta").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA CUENTA POR PAGAR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmCuentasPorPagar_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.txtTipoCambio.Value = Format(toDouble(oMaestroService.MostrarTipoCambio("US", Today)), "#0.000")
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdCuenta)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA CUENTA POR PAGAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            '======================================= ESTADOS ===============================================
            dtEstados = oCtasPorPagarService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oCtasPorPagarService.Filtrar(Session.sCodEmp, CInt(txtAnio.Value), CInt(cmbMes.Value), IdProveedor, txtNumDoc.Text, cmbEstado.Value, toNumber(txtIdGasto.Text)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()

                '////////SUMAR MONTOS TOTALES DE VENCIMIENTOS////////
                If dtDatos.Rows.Count > 0 Then
                    Dim lPorVencerSol, lVencidoSol, lPorVencerDol, lVencidoDol As Decimal
                    For Each Fila As DataRow In dtDatos.Rows
                        If Fila.Item("CodMon") = "US" Then
                            If Fila.Item("FecVencimiento") <= Today Then
                                lVencidoDol = lVencidoDol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                            Else
                                lPorVencerDol = lPorVencerDol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                            End If
                        Else
                            If Fila.Item("FecVencimiento") <= Today Then
                                lVencidoSol = lVencidoSol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                            Else
                                lPorVencerSol = lPorVencerSol + (Fila.Item("Saldo")) ' * (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                            End If
                        End If

                    Next
                    txtPorVencerSol.Text = lPorVencerSol
                    txtVencidoSol.Text = lVencidoSol
                    txtPorVencerDol.Text = lPorVencerDol
                    txtVencidoDol.Text = lVencidoDol
                    txtSaldoSol.Text = lPorVencerSol + lVencidoSol
                    txtSaldoDol.Text = lPorVencerDol + lVencidoDol
                Else
                    txtPorVencerSol.Text = 0.0
                    txtVencidoSol.Text = 0.0
                    txtPorVencerDol.Text = 0.0
                    txtVencidoDol.Text = 0.0
                    txtSaldoSol.Text = 0.0
                    txtSaldoDol.Text = 0.0
                End If
                '/////////////////////////////////////////////////////

            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtAnio.TextChanged, cmbMes.ValueChanged, cmbEstado.ValueChanged, txtProveedor.TextChanged, txtIdGasto.TextChanged, txtNumDoc.TextChanged
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCuenta").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                    biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Cuenta Por Pagar actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Cuenta Por Pagar."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Cuenta Por Pagar actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Cuenta Por Pagar actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        'dtDatos = oCtasPorPagarService.Imprimir(dgvDatos.CurrentRow.Cells("IdCuenta").Value).Tables(0)
        'DataGridView1.DataSource = dtDatos
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub miDescargarXml_Click(sender As System.Object, e As System.EventArgs) Handles miDescargarXml.Click
        Try

            If oCtasPorPagarService.BuscarXml(dgvDatos.CurrentRow.Cells("IdCuenta").Text) = True Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(New StringReader(oCtasPorPagarService.DescargarXml(dgvDatos.CurrentRow.Cells("IdCuenta").Text)))

                Dim NombreXMLPDF As String = oCtasPorPagarService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdCuenta").Text)
                Dim Ubicacion As String

                Dim file As New SaveFileDialog()
                file.FileName = NombreXMLPDF
                file.Filter = "XML|*.xml"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName

                End If

                xmlDoc.Save(Ubicacion)
            Else
                MsgBox("No existe Documento XML, verifique...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESCARGAR XML:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miDescargarPdf_Click(sender As System.Object, e As System.EventArgs) Handles miDescargarPdf.Click
        Try
            If oCtasPorPagarService.BuscarXml(dgvDatos.CurrentRow.Cells("IdCuenta").Text) = True Then
                Dim PdfByte As Byte() = oCtasPorPagarService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdCuenta").Text)

                Dim NombreXMLPDF As String = oCtasPorPagarService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdCuenta").Text)
                Dim Ubicacion As String

                Dim file As New SaveFileDialog()
                file.FileName = NombreXMLPDF
                file.Filter = "PDF|*.pdf"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName

                End If

                System.IO.File.WriteAllBytes(Ubicacion, PdfByte)
            Else
                MsgBox("No existe Documento XML, verifique...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESCARGAR PDF:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biConsulEstados_Click(sender As Object, e As EventArgs) Handles biConsulEstados.Click, miConsultarEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmCuentasPorPagar_Estados
                frm.IdCuenta = dgvDatos.CurrentRow.Cells("IdCuenta").Value
                frm.Text = "Estados del Documento Nº " & dgvDatos.CurrentRow.Cells("IdCuenta").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miCancelacionManual_Click(sender As Object, e As EventArgs) Handles miCancelacionManual.Click, biPagarManual.Click
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de Cancelar el pago de la Cuenta Por Pagar Nº " + dgvDatos.CurrentRow.Cells("IdCuenta").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oCtasPorPagarService.CancelarPagoManual(CInt(dgvDatos.CurrentRow.Cells("IdCuenta").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    Actualizar()
                    MsgBox("Se CANCELO el pago del registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CANCELAR LA CUENTA POR PAGAR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class