Imports System.ServiceModel
Imports System.Xml
Imports System.IO

Public Class frmComOrdenCompra_Facturacion

    '===========================Servicios====================================
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer
    Private dtDatos As DataTable
    Public Estado As Integer
    Public IdProveedor As Integer

    Private Sub frmComOrdenCompra_Facturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComOrdenCompra_Procesar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Facturacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Me.Text = "Documentos de Orden de Compra " + IdOrden.ToString

        ListaDatos()
        EnableOptions()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraDetService.Close()
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub ListaDatos()
        dtDatos = oOrdenesCompraDetService.MostrarFactura(IdOrden).Tables(0)
        dgvDatos.DataSource = dtDatos
    End Sub

    Private Sub EnableOptions()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            Dim Procesado As Boolean = toBoolean(dgvDatos.CurrentRow.Cells("Procesado").Value)
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf((Estado = 3 Or Estado = 5 Or Estado = 9) And Procesado = False, True, False)
        End If
        miNuevo.Enabled = IIf(Estado = 3 Or Estado = 9, True, False)
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdOrdenDoc").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        NuevoDocumento()
    End Sub

    Private Sub NuevoDocumento()
        Try
            Dim frm As New frmComOrdenCompra_Factura
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.IdOrden = IdOrden
            frm.IdProveedor = IdProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOrdenDoc)
                    MostrarDocumento()
                    Actualizar()
                End If
                EnableOptions()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DOCUMENTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        MostrarDocumento()
    End Sub

    Private Sub MostrarDocumento()
        Try
            Dim frm As New frmComOrdenCompra_Factura
            frm.state_button = True
            frm.IdOrden = IdOrden
            frm.IdProveedor = IdProveedor
            frm.IdOrdenDoc = dgvDatos.CurrentRow.Cells("IdOrdenDoc").Value
            frm.editable = IIf(toBoolean(dgvDatos.CurrentRow.Cells("Procesado").Value), False, True)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    ListaDatos()
                    RowPossesion(dgvDatos, frm.IdOrdenDoc)
                Else
                    ListaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DOCUMENTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDocumento()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

    Private Sub eliminarDocumento()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Documento : " + dgvDatos.CurrentRow.Cells("SerDoc").Text.ToString + " - " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oOrdenesCompraDetService.BorrarFactura(toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        EnableOptions()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text
        End If
        dtDatos = Nothing
        ListaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub miDescargarXml_Click(sender As System.Object, e As System.EventArgs) Handles miDescargarXml.Click
        Try

            If oOrdenesCompraDetService.BuscarXml(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text) = True Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(New StringReader(oOrdenesCompraDetService.DescargarXml(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text)))

                Dim NombreXMLPDF As String = oOrdenesCompraDetService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text)
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
            If oOrdenesCompraDetService.BuscarXml(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text) = True Then
                Dim PdfByte As Byte() = oOrdenesCompraDetService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text)

                Dim NombreXMLPDF As String = oOrdenesCompraDetService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdOrdenDoc").Text)
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
End Class