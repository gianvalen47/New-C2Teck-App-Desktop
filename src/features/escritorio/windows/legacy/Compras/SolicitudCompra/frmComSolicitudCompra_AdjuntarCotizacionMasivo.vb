Imports System.ServiceModel
Public Class frmComSolicitudCompra_AdjuntarCotizacionMasivo

    Private oSolicitudCompraService As New SolicitudCompraService.SolicitudCompraServiceClient
    Private oSolicitudCompraDetService As New SolicitudCompraDetService.SolicitudCompraDetServiceClient
    Private oCotizacionSolicitudDetService As New CotizacionSolicitudDetService.CotizacionSolicitudDetServiceClient

    Private dtCotizaciones As DataTable
    Private dtDatos As DataTable
    Private dtDatosN As DataTable
    Public IdSolicitud As Integer
    Public IdEstado As Integer

    Private Sub frmComSolicitudCompra_AdjuntarCotizacionMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaCotizaciones()
        listaDetalles()

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDetalles)
        dgvDetalles.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub

    Private Sub frmComSolicitudCompra_AdjuntarCotizacionMasivo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudCompra_AdjuntarCotizacionMasivo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudCompraDetService.Close()
            oSolicitudCompraService.Close()
        Catch ex As TimeoutException
            oSolicitudCompraDetService.Abort()
            oSolicitudCompraService.Abort()
        Catch ex As CommunicationException
            oSolicitudCompraDetService.Abort()
            oSolicitudCompraService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub listaCotizaciones()
        Try

            dtCotizaciones = oSolicitudCompraDetService.MostrarCotizacionesMasivo(IdSolicitud).Tables(0)
            'TieneCotizaciones = dtCotizaciones.Rows.Count
            cmbCotizaciones.DataSource = dtCotizaciones
            cmbCotizaciones.DropDownList.DataMember = dtCotizaciones.Columns("NumCotizacion").ToString
            cmbCotizaciones.DropDownList.DisplayMember = dtCotizaciones.Columns("NumCotizacion").ToString
            cmbCotizaciones.DropDownList.ValueMember = dtCotizaciones.Columns("IdCotizacion").ToString
            'cmbCotizaciones.DropDownList.Columns(0).DataMember = dtCotizaciones.Columns("IdCotizacion").ToString
            'cmbCotizaciones.DropDownList.Columns(1).DataMember = dtCotizaciones.Columns("IdCotizacionDet").ToString
            'cmbCotizaciones.DropDownList.Columns(2).DataMember = dtCotizaciones.Columns("NumCotizacion").ToString
            'cmbCotizaciones.DropDownList.Columns(3).DataMember = dtCotizaciones.Columns("DesProv").ToString
            'cmbCotizaciones.DropDownList.Columns(4).DataMember = dtCotizaciones.Columns("CanMer").ToString
            'cmbCotizaciones.DropDownList.Columns(5).DataMember = dtCotizaciones.Columns("PreMer").ToString
            'cmbCotizaciones.DropDownList.Columns(6).DataMember = dtCotizaciones.Columns("DscMer").ToString
            'cmbCotizaciones.DropDownList.Columns(7).DataMember = dtCotizaciones.Columns("TotalFila").ToString
            cmbCotizaciones.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error al listar las cotizaciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDetalles()

        'dtDatos = oSolicitudCompraDetService.Mostrar(IdSolicitud).Tables(0)
        'dgvDetalles.DataSource = dtDatos

        dtDatos = oCotizacionSolicitudDetService.Mostrar(cmbCotizaciones.Value).Tables(0)
        dgvDetalles.DataSource = dtDatos

        Dim dtCopia As New DataTable("tabla")
        dtCopia.Columns.Add(New DataColumn("IdCotizacionDet", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("IdCotizacion", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("IdSolicitud", Type.GetType("System.String")))       'datetime
        dtCopia.Columns.Add(New DataColumn("IdSolicitudDet", Type.GetType("System.String")))        'datetime
        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("TotalFila", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Aceptado", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("FecEntrega", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("FecReg", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodUsu", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("NomPc", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DirIp", Type.GetType("System.String")))

        dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "0.00", "0.00", "0.00", "0.00", "1", "1", "1", "1", "1", "1", "1"})

        dtDatosN = dtCopia.Copy
        dtDatosN.Clear()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If dgvDetalles.RowCount > 0 Then
                If MsgBox("¿Está seguro de ADJUNTAR la solicitud de compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim Cadena As String = ""
                    rows = dgvDetalles.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow

                    Dim rowP As DataRow

                    If rows.Count <> 0 Then

                        For Each row In rows

                            rowP = dtDatosN.NewRow

                            rowP(0) = row.Cells("IdCotizacionDet").Text
                            rowP(1) = row.Cells("IdCotizacion").Text
                            rowP(2) = row.Cells("IdSolicitud").Text
                            rowP(3) = row.Cells("IdSolicitudDet").Text
                            rowP(4) = row.Cells("CodMer").Text
                            rowP(5) = row.Cells("DesMer").Text
                            rowP(6) = row.Cells("CanMer").Text
                            rowP(7) = row.Cells("PreMer").Text
                            rowP(8) = row.Cells("DscMer").Text
                            rowP(9) = row.Cells("TotalFila").Text
                            rowP(10) = row.Cells("Observacion").Text
                            rowP(11) = row.Cells("Aceptado").Text
                            rowP(12) = row.Cells("FecEntrega").Text
                            rowP(13) = row.Cells("FecReg").Text
                            rowP(14) = row.Cells("CodUsu").Text
                            rowP(15) = row.Cells("NomPc").Text
                            rowP(16) = row.Cells("DirIp").Text

                            dtDatosN.Rows.Add(rowP)

                        Next

                        Dim estado_process As Boolean
                        'estado_process = oSolicitudCompraService.Enviar(IdSolicitud, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        'estado_process = oSolicitudCompraDetService.AsignarCotizacionMasiva(cmbCotizaciones.DropDownList.GetRow.Cells(0).Text, IdSolicitud, dtDatos, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        estado_process = oSolicitudCompraDetService.AsignarCotizacionMasiva(cmbCotizaciones.DropDownList.GetRow.Cells(0).Text, IdSolicitud, dtDatosN, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process = True Then
                            MsgBox("Se adjunto correctamente", MsgBoxStyle.Information)
                            Me.Close()
                        Else
                            MsgBox("Error al adjuntar masivamente los detalles", MsgBoxStyle.Information)
                        End If

                    Else
                        MsgBox("Debe seleccionar alguno de los detalles")
                    End If
                End If
            Else
                MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error al adjuntar masivamente los detalles : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbCotizaciones_ValueChanged(sender As Object, e As EventArgs) Handles cmbCotizaciones.ValueChanged
        listaDetalles()
    End Sub
End Class