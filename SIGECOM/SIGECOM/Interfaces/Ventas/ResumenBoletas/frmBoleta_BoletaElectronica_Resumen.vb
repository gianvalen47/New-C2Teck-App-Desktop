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

Public Class frmBoleta_BoletaElectronica_Resumen

    Private oMaestroService As New MaestroService.MaestroClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oResumenBoletaDigitalService As New ResumenBoletasDigitalService.ResumenBoletasDigitalServiceClient
    Private oCommunicationState As New ComunicacionSunat
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdBoleta As String
    Private dtDatos As DataTable
    Private dtMeses As DataTable

    Dim RucEmp As String
    Dim DesEmp As String
    Dim TipoDoc As String
    Dim IdSerieDoc As String
    Dim CodSerie As String
    Dim NumDocInicio As String
    Dim NumDocFinal As String
    Dim TotNeto As Double
    Dim TotVenta As Double
    Dim TotDscto As Double
    Dim TotIgv As Double
    Dim TotBruto As Double
    Dim CodTributo As String
    Dim NomTributo As String
    Dim CodTributoInt As String

    Dim IdNumeracion As String

    Private Sub frmBoleta_BoletaElectronica_Resumen_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oResumenBoletaDigitalService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oResumenBoletaDigitalService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oResumenBoletaDigitalService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Resumen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_Resumen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 274)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        'txtanio.Value = Today.Year
        LlenarCombos()
        'cmbMes.Value = Today.Month

        txtanio.Value = Session.sFecha.Year
        cmbMes.Value = Session.sFecha.Month

        ListarDatos()


    End Sub

    Private Sub LlenarCombos()
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

    Private Sub ListarDatos()
        Try

            dtDatos = oResumenBoletaDigitalService.Filtrar(Session.sCodEmp, txtanio.Value, cmbMes.Value, toBlank(txtIdResumen.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(sender As System.Object, e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim frm As New frmBoleta_BoletaElectronica_Resumen_Generar
        'frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If frm.EstadoEnvio = True Then
                ListarDatos()
                'RowPossesion(dgvDatos, frm.IdBoleta)
            End If
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("IdResumen").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As System.Object, e As System.EventArgs) Handles biMostrar.Click, dgvDatos.DoubleClick, miMostrar.Click

        If ValidaCodigoSeleccionado() Then
            Try
                'If oResumenBoletaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdResumen").Text, Session.sCodEmp) Then
                Dim frm As New frmBoleta_BoletaElectronica_ListadoResumen
                frm.IdResumen = dgvDatos.CurrentRow.Cells("IdResumen").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
                'Else
                '    MsgBox("No existe Resumen, verifique ...", MsgBoxStyle.Information)
                'End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
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
                'ElseIf dgvDatos.CurrentRow.Cells("IdGuiaDev").Text = Nothing Then
                '    MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biObtenerEstadoSunat_Click(sender As System.Object, e As System.EventArgs) Handles biObtenerEstadoSunat.Click, miObtenerEstadoSunat.Click

        If ValidaCodigoSeleccionado() Then
            Try
                'Comprimir()

                Dim obtenerestado As Boolean
                Dim rutaobtener As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & dgvDatos.CurrentRow.Cells("IdResumen").Text & "\"
                'Dim file As String = dgvDatos.CurrentRow.Cells("NombreXml").Text & ".ZIP"
                Dim file As String = dgvDatos.CurrentRow.Cells("NombreXml").Text
                Dim Idresumenrowpos As String = dgvDatos.CurrentRow.Cells("IdResumen").Text

                'If Session.sCodEmp = "01" Then
                '    'obtenerestado = oCommunicationState.ObtenerEstadoSunat(rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
                '    obtenerestado = EnviarSunat21.ObtenerEstadoResumenOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
                'Else
                '    obtenerestado = EnviarSunat21.ObtenerEstadoResumenProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
                'End If

                If Session.sAplicaOSE Then
                    obtenerestado = EnviarSunat21.ObtenerEstadoResumenOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
                Else
                    obtenerestado = EnviarSunat21.ObtenerEstadoResumenProduccion(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, rutaobtener, file, dgvDatos.CurrentRow.Cells("NumTicket").Text)
                End If

                If obtenerestado Then

                    Dim xmlDocR As New XmlDocument
                    xmlDocR.Load("D:\Documentos_Electronicos\Resumen_Boletas\" & dgvDatos.CurrentRow.Cells("IdResumen").Text & "\R-" & dgvDatos.CurrentRow.Cells("NombreXml").Text & ".xml")

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

                    Dim registro As New ResumenBoletasDigitalService.ResumenBoletasDigital
                    Dim empresa As New ResumenBoletasDigitalService.Empresa
                    'Dim factura As New FacturaDigitalService.Factura

                    registro.CDRxml = xmlDocR.OuterXml
                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.DocumentoXml = "" 'xmlDoc.OuterXml
                    registro.Estado = Responsecode
                    registro.Fecha = dgvDatos.CurrentRow.Cells("Fecha").Text
                    registro.IdResumen = dgvDatos.CurrentRow.Cells("IdResumen").Text
                    registro.NombreXml = "" 'nombrexml
                    registro.NomPc = Session.sNomPc
                    registro.Notas = notecompilado
                    registro.NumTicket = dgvDatos.CurrentRow.Cells("NumTicket").Text
                    registro.Observacion = Descripcioncdr

                    Dim actualizar As Boolean
                    actualizar = oResumenBoletaDigitalService.ActualizarRespuestaSunat(registro)

                    If actualizar Then
                        MsgBox("Se obtuvo el estado correctamente", MsgBoxStyle.Information)
                        ListarDatos()
                        RowPossesion(dgvDatos, Idresumenrowpos)
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
            End Try
        End If
    End Sub

    'Private Sub Comprimir()
    '    Dim destdir As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & dgvDatos.CurrentRow.Cells("IdResumen").Text & "\20100020441-" & dgvDatos.CurrentRow.Cells("IdResumen").Text & ".zip"

    '    Dim zip As ZipFile = New ZipFile
    '    Dim directorio As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & dgvDatos.CurrentRow.Cells("IdResumen").Text
    '    zip.AddDirectory(directorio)
    '    zip.Save(destdir)
    'End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, biActualizar.Click, txtanio.TextChanged, cmbMes.ValueChanged, txtIdResumen.TextChanged
        ListarDatos()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtanio.KeyPress _
                      , cmbMes.KeyPress _
                      , txtIdResumen.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class