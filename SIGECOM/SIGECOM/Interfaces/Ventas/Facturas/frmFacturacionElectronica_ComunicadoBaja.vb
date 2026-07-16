Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports Ionic.Zip
Imports UblLarsen.Ubl2
Imports UblLarsen.Ubl2.aplicacion
Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports FacturarSunat.aplicacion
Imports FacturarSunat21.aplicacion

Public Class frmFacturacionElectronica_ComunicadoBaja

    Private oComunicacionBajaDigitalService As New ComunicacionBajaDigitalService.ComunicacionBajaDigitalServiceClient
    Private oCommunicationState As New ComunicacionSunat

    Private dtTipoDocRef As DataTable
    Private dtDatos As DataTable
    Public TipoDoc As Integer = 0

    Private Sub FacturacionElectronica_ComunicadoBaja_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComunicacionBajaDigitalService.Close()
        Catch ex As TimeoutException
            oComunicacionBajaDigitalService.Close()
        Catch ex As CommunicationException
            oComunicacionBajaDigitalService.Abort()
        End Try
    End Sub

    Private Sub FacturacionElectronica_ComunicadoBaja_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub FacturacionElectronica_ComunicadoBaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        LlenarCombos()
        cmbTipDoc.Value = TipoDoc

    End Sub

    Private Sub LlenarCombos()
        Try
            dtTipoDocRef = oComunicacionBajaDigitalService.MostrarTipoDocumento.Tables(0)
            dtTipoDocRef.Rows.InsertAt(getRowTodos(dtTipoDocRef), 0)
            cmbTipDoc.DataSource = dtTipoDocRef
            cmbTipDoc.DropDownList.DataMember = dtTipoDocRef.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.DisplayMember = dtTipoDocRef.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.ValueMember = dtTipoDocRef.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(0).DataMember = dtTipoDocRef.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(1).DataMember = dtTipoDocRef.Columns("Nombre").ToString
            dtTipoDocRef = Nothing
        Catch ex As Exception
            MsgBox("Error al llenar combos : " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, cmbTipDoc.TextChanged, txtNumDocRef.TextChanged, txtSerieDocRef.TextChanged
        ListarDatos()
    End Sub

    Private Sub ListarDatos()

        Try
            dtDatos = oComunicacionBajaDigitalService.Consultar(Session.sCodEmp, utils.toNumber(cmbTipDoc.Value), txtSerieDocRef.Text.Trim, utils.toNumber(txtNumDocRef.Text.Trim)).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub biObtenerEstadoSunat_Click(sender As System.Object, e As System.EventArgs) Handles biObtenerEstadoSunat.Click, miObtenerEstadoSunat.Click

        Try
            'Comprimir()

            Dim obtenerestado As Boolean
            Dim rutaobtener As String = "D:\Documentos_Electronicos\Comunicacion_de_Baja\" & dgvDatos.CurrentRow.Cells("CodSerie").Text & "-" & dgvDatos.CurrentRow.Cells("NumDoc").Text & "\"
            'Dim file As String = dgvDatos.CurrentRow.Cells("NombreXml").Text & ".ZIP"
            Dim file As String = dgvDatos.CurrentRow.Cells("NombreXml").Text
            Dim IdComunicacion As String = dgvDatos.CurrentRow.Cells("IdComunicacion").Text

            'If Session.sRucEmp = "01" Or Session.sCodEmp = "02" Then
            '    'obtenerestado = oCommunicationState.ObtenerEstadoSunat(rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
            '    obtenerestado = EnviarSunat21.ObtenerEstadoComunicacionBajaOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
            'Else
            '    obtenerestado = EnviarSunat.ObtenerEstadoComunicacionBajaProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
            'End If

            If Session.sAplicaOSE Then
                obtenerestado = EnviarSunat21.ObtenerEstadoComunicacionBajaOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
            Else
                obtenerestado = EnviarSunat21.ObtenerEstadoComunicacionBajaProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
            End If


            If obtenerestado Then

                Dim xmlDocR As New XmlDocument
                xmlDocR.Load("D:\Documentos_Electronicos\Comunicacion_de_Baja\" & dgvDatos.CurrentRow.Cells("CodSerie").Text & "-" & dgvDatos.CurrentRow.Cells("NumDoc").Text & "\R-" & dgvDatos.CurrentRow.Cells("NombreXml").Text & ".xml")

                '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                namespaces.AddNamespace("ar", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
                namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
                namespaces.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/")

                Dim notecompilado As String = ""
                Dim contador As Integer = 0
                Dim xnList As XmlNodeList = xmlDocR.SelectNodes("/ar:ApplicationResponse/cbc:Note", namespaces)
                For Each xn As XmlNode In xnList
                    notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
                    contador = contador + 1
                Next
                Dim xPathString = "/ar:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
                Dim xPathString2 = "/ar:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
                'Dim xPathString3 = "/ar:ApplicationResponse/cbc:ID"
                Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
                Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
                'Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
                Dim Descripcioncdr As String = oNode.InnerText
                Dim Responsecode = oNode2.InnerText
                'Dim NumTicket As String = oNode3.InnerText
                '///////////////////////////////////////////////////////////////////////////

                Dim registro As New ComunicacionBajaDigitalService.ComunicacionBajaDigital
                Dim empresa As New ComunicacionBajaDigitalService.Empresa
                Dim tipodoc As New ComunicacionBajaDigitalService.TipoDocumento
                Dim seriedoc As New ComunicacionBajaDigitalService.SerieDocumento


                registro.IdComunicacion = dgvDatos.CurrentRow.Cells("IdComunicacion").Text
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                tipodoc.IdDocumento = CInt(dgvDatos.CurrentRow.Cells("IdDocumento").Text)
                registro.TipoDocumento = tipodoc
                seriedoc.IdSerieDoc = CInt(dgvDatos.CurrentRow.Cells("IdSerieDoc").Text)
                registro.SerieDocumento = seriedoc
                registro.NumDoc = CInt(dgvDatos.CurrentRow.Cells("NumDoc").Text)
                registro.Estado = Responsecode
                registro.Observacion = Descripcioncdr
                registro.CDRxml = xmlDocR.OuterXml
                registro.Notas = toNull(notecompilado)
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                'oComunicacionBajaDigitalService.ActualizarRespuestaSunat(registro)

                'registro.CodUsu = Session.sCodUsu
                'registro.NomPc = Session.sNomPc
                'registro.DirIp = Session.sDirIp

                Dim actualizar As Boolean
                oComunicacionBajaDigitalService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
                actualizar = oComunicacionBajaDigitalService.ActualizarRespuestaSunat(registro)

                If actualizar Then
                    MsgBox("Se obtuvo el estado correctamente", MsgBoxStyle.Information)
                    ListarDatos()
                    RowPossesion(dgvDatos, IdComunicacion)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
        End Try

    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biMostrar_Click(sender As System.Object, e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try

            Dim frm As New frmFacturacionElectronica_ComunicadoBaja_Obtener
            frm.IdComunicacion = dgvDatos.CurrentRow.Cells("IdComunicacion").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ListarDatos()
                'RowPossesion(dgvDatos, frm.IdBoleta)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
        End Try
        If dgvDatos.RowCount > 0 Then

        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("IdComunicacion").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class