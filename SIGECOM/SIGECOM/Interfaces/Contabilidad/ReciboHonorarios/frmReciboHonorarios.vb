Imports System.ServiceModel
Imports System.IO
Imports System.Xml
Public Class frmReciboHonorarios

    Private oReciboHonorario As New ReciboHonorarioService.ReciboHonorarioServiceClient
    'Private oReciboHonorarioDet As New ReciboHonorarioDetService.ReciboHonorarioDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Private dtMeses As DataTable
    Private state_Search As Boolean
    Private NumeroSug As String
    Private IdHonorario As Integer

    Private IdProveedor As Integer

    Private Sub frmReciboHonorarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oReciboHonorario.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oReciboHonorario.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oReciboHonorario.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmReciboHonorarios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            dgvDatos.Select()
            dgvDatos.Row = dgvDatos.RowCount - 1
            dgvDatos.Col = 1
        End If
    End Sub

    Private Sub frmReciboHonorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()

        txtanio.Value = Today.Year
        cmbMes.Value = Today.Month

        'txtanio.Value = Today.Year
        'cmbMes.Value = Today.Month

        IdProveedor = 0
        txtProveedor.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()

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

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
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

        Return fila
    End Function

    Private Sub listaDatos()

        Try
            If state_Search = True Then
                'dtDatos = oReciboHonorario.Filtrar(Session.sCodEmp, txtanio.Value, cmbMes.Value, txtSerieDoc.Text, toNumber(txtNumDoc.Text), IdProveedor).Tables(0)
                dtDatos = oReciboHonorario.Filtrar(Session.sCodEmp, txtanio.Value, IIf(cmbMes.Value = 0, "", Format(cmbMes.Value, "00")), txtSerieDoc.Text, txtNumDoc.Text, IdProveedor).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                'DataGridView1.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, cmbMes.ValueChanged, txtSerieDoc.TextChanged, txtNumDoc.TextChanged
        listaDatos()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdHonorario").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            btnDescargarPDF.Enabled = False
            btnDescargarXML.Enabled = False

            miMostrar.Enabled = False
            miEliminar.Enabled = False

        Else
            biMostrar.Enabled = True
            biEliminar.Enabled = True

            btnDescargarPDF.Enabled = True
            btnDescargarXML.Enabled = True

            miMostrar.Enabled = True
            miEliminar.Enabled = True


        End If
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            'If oFacturaService.PermisoFactura(Session.sCodUsu, cmbTipFac.Value) = False Then
            '    MsgBox("No tiene Permiso para Facturar al " & cmbTipFac.Text, MsgBoxStyle.Information, "No tiene Permiso")
            '    Exit Sub
            'End If

            Dim frm As New frmReciboHonorario
            frm.state_button = False
            frm.txtMesRegistro.Text = IIf(cmbMes.Value = 0, Format(Month(Today), "00"), Format(cmbMes.Value, "00"))
            'frm.IdLocacion = cmbIdLocacion.Value
            'frm.TipFac = cmbTipFac.Value
            'frm.txtNumDoc.Text = oFacturaService.SugerirNumero(cmbIdLocacion.Value, Session.sCodUsu)
            ' frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion))
            'frm.lblLocacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.Text = "Registrar Nuevo Recibo Honorario "
            'frm.IdSugerido = 0
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ' limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdHonorario)
                    Mostrar_Click(sender, e)
                    Actualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmReciboHonorario
                'Dim lEstado As String
                'lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.state_button = True
                frm.IdHonorario = dgvDatos.CurrentRow.Cells("IdHonorario").Text
                'frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
                frm.edicion = False
                'frm.TipFac = cmbTipFac.Value
                frm.editable = True 'IIf(lEstado = "GN" Or lEstado = "AP" Or lEstado = "CR", True, False)
                'frm.lblLocacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    If frm.type_process = "update" Then
                        ' limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text)
                        listaDatos()
                        RowPossesion(dgvDatos, frm.IdHonorario)
                    Else
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                Actualizar_Click(sender, e)
            Catch ex As Exception
                MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
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
            ElseIf dgvDatos.CurrentRow.Cells("IdHonorario").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdHonorario").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Recibo por Honorario"
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Recibo por Honorario actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Recibo por Honorario actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        Mostrar_Click(sender, e)
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está seguro de ELIMINAR el Recibo por Honorario Nº " + dgvDatos.CurrentRow.Cells("Documento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oReciboHonorario.Borrar(dgvDatos.CurrentRow.Cells("IdHonorario").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        'dtDatos = Nothing
                        listaDatos()
                        'Actualizar_Click(sender, e)
                        MsgBox("Se Eliminó el Recibo por Honorario actual correctamente. !!!", MsgBoxStyle.Information, "Eliminar")
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical, "Eliminar")
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ELIMINAR]:" + ex.Message, MsgBoxStyle.Exclamation, "Eliminar")
            End Try
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
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

    Private Sub chkProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chkProveedor.CheckedChanged
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

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnDescargarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnDescargarXml.Click
        Try

            IdHonorario = dgvDatos.CurrentRow.Cells("IdHonorario").Text

            If oReciboHonorario.BuscarXml(IdHonorario) = True Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(New StringReader(oReciboHonorario.DescargarXml(IdHonorario)))

                Dim NombreXMLPDF As String = oReciboHonorario.ObtenerNombre(IdHonorario)
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

    Private Sub btnDescargarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnDescargarPdf.Click
        Try
            IdHonorario = dgvDatos.CurrentRow.Cells("IdHonorario").Text

            If oReciboHonorario.BuscarXml(IdHonorario) = True Then
                Dim PdfByte As Byte() = oReciboHonorario.DescargarPdf(IdHonorario)

                Dim NombreXMLPDF As String = oReciboHonorario.ObtenerNombre(IdHonorario)
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

    Private Sub biDuplicar_Click(sender As Object, e As EventArgs) Handles biDuplicar.Click, miDuplicar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmReciboHonorario_Duplicar
                frm.IdHonorario = dgvDatos.CurrentRow.Cells("IdHonorario").Value
                frm.SerDoc = dgvDatos.CurrentRow.Cells("SerDoc").Value
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Value
                frm.NumRegistro = dgvDatos.CurrentRow.Cells("NumRegistro").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdHonorario)
                End If
            Catch ex As Exception
                MsgBox("Error al DUPLICAR el Registro de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub btnGenerarArchivo_Click(sender As Object, e As EventArgs) Handles btnGenerarArchivo.Click
        Try
            Dim frm As New frmReciboHonorarioGenerarArchivo
            'frm.IdPlanilla = toNumber(dgvDatos.CurrentRow.Cells("IdPlanilla").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                ' RowPossesion(dgvDatos, frm.IdPlanilla)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class