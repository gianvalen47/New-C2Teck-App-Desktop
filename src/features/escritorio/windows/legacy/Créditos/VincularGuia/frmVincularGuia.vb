Imports System.ServiceModel

Public Class frmVincularGuia

    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatosGuia As DataTable
    Private dtDatosFactura As DataTable
    Private IdSerieDoc As Integer

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmVincularGuia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oFacturaService.Close()
            oGuiaRemisionService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oFacturaService.Abort()
            oGuiaRemisionService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oFacturaService.Abort()
            oGuiaRemisionService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmVincularGuia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmVincularGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 135)
        '/*************************************************************************************/

        dgvDatosGuia.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatosGuia.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right

        dgvDatosFactura.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatosFactura.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right

        LlenarCombos()
        txtanio.Value = Today.Year
        txtNumGuia.Focus()
    End Sub

    Private Sub LlenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged

        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            'dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If

    End Sub

    Private Sub txtNumGuia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim buscarGuia As Boolean
                buscarGuia = oGuiaRemisionService.Buscar(IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), IdSerieDoc, toNumber(txtNumGuia.Text))
                If buscarGuia = True Then
                    listaDatosGuia()
                Else : MsgBox("No existe ese Nro de Guia", MsgBoxStyle.Information)
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA GUIA : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumFactura.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                'Dim buscarFactura As Boolean
                'buscarFactura = oFacturaService.Buscar(0, toNumber(txtNumFactura.Text))
                'If buscarFactura = True Then
                listaDatosFactura()
                'Else : MsgBox("No existe ese Nro de Factura", MsgBoxStyle.Information)
                'End If

                'listaDatosFactura()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA FACTURA : " + ex.Message)
        End Try
    End Sub

    Private Sub listaDatosGuia()
        Try

            dtDatosGuia = oGuiaRemisionService.Filtrar(txtanio.Value, 0, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), _
                                                 IdSerieDoc, 0, "", toNumber(txtNumGuia.Text)).Tables(0)

            dgvDatosGuia.DataSource = dtDatosGuia
            RowPossesionGuia(dgvDatosGuia, txtNumGuia.Text)

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosFactura()
        Try

            dtDatosFactura = oFacturaService.Filtrar(txtanio.Value, 0, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value),
                                                 "", 0, 0, "", toNumber(txtNumFactura.Text)).Tables(0)

            dgvDatosFactura.DataSource = dtDatosFactura
            RowPossesionFactura(dgvDatosFactura, txtNumFactura.Text)


        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de VINCULAR la Guia N° " & Trim(dgvDatosGuia.CurrentRow.Cells("NumDoc").Value) & " con la Factura N° " & Trim(dgvDatosFactura.CurrentRow.Cells("NumDoc").Value) & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Vincular()
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Vincular()
        Dim estado_proceso As Boolean

        estado_proceso = oFacturaService.VincularGuia(dgvDatosFactura.CurrentRow.Cells("IdFactura").Value, dgvDatosGuia.CurrentRow.Cells("IdGuia").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

        If estado_proceso = True Then
            MsgBox("Se Vinculo correctamente.!", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub RowPossesionGuia(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If row.Cells("NumDoc").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub RowPossesionFactura(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If row.Cells("NumDoc").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub btnBuscarGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarGuia.Click
        If txtNumGuia.Text <> "" Then
            Dim buscarGuia As Boolean
            buscarGuia = oGuiaRemisionService.Buscar(IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), IdSerieDoc, toNumber(txtNumGuia.Text))
            If buscarGuia = True Then
                listaDatosGuia()
            Else : MsgBox("No existe ese Nro de Guia", MsgBoxStyle.Information)
            End If

        End If
    End Sub

    Private Sub btnBuscarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFactura.Click
        If txtNumFactura.Text <> "" Then
            listaDatosFactura()
        End If
    End Sub

    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        Try
            IdSerieDoc = oGuiaRemisionService.MostraIdSerie(toNumber(cmbIdLocacion.Value)) '1: Guís de Remisión  '4:Guía de Devolución

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class