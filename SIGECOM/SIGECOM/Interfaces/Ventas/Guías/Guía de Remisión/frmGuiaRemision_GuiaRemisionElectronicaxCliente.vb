Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal
Public Class frmGuiaRemision_GuiaRemisionElectronicaxCliente

    Private oMaestroService As New MaestroService.MaestroClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oGuiaRemisionDigitalService As New GuiaRemisionDigitalService.GuiaRemisionDigitalServiceClient

    Public DesCli As String
    Public IdCliente As Integer
    Public CodSerie As String
    Public NumDoc As String
    Public IdFactura As Integer
    Dim dtGuias As DataTable
    Dim NombreXMLPDF As String = ""
    Dim UbicacionCodBarra As String

    Dim CodMot As String
    Dim LegalMonetaryTotal As Double
    Dim CurrencyId As String
    Dim TipoDoc As String
    Dim TaxAmount As Double
    Dim CodSerieFac As String
    Dim NumDocFac As String
    Dim DocumentoFac As String
    Dim FecDoc As Date
    Dim RucCli As String
    Dim RucEmp As String
    Dim CodMon As String

    Dim ValorResumen As String
    Dim ValorFirma As String

    Private Sub frmGuiaRemision_GuiaRemisionElectronicaxCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oGuiaRemisionService.Close()
            oGuiaRemisionDigitalService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oGuiaRemisionService.Abort()
            oGuiaRemisionDigitalService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oGuiaRemisionService.Abort()
            oGuiaRemisionDigitalService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmGuiaRemision_GuiaRemisionElectronicaxCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_GuiaRemisionElectronicaxCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodSerie.Text = CodSerie
        txtNumDoc.Text = NumDoc
        txtCliente.Text = DesCli
        ListarDatos()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = ""
                    IdCliente = 0
                End If

                'listarContactos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtCliente.TextChanged, txtCodSerie.TextChanged, txtNumDoc.TextChanged
        ListarDatos()
    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click
        ListarDatos()
    End Sub

    Private Sub ListarDatos()
        Try
            dtGuias = oGuiaRemisionDigitalService.ConsultarGuias(IdCliente, utils.toBlank(txtCodSerie.Text), utils.toNumber(txtNumDoc.Text)).Tables(0)
            'DataGridView1.DataSource = dtFacturas
            dgvDatos.DataSource = dtGuias

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biDescargar_Click(sender As Object, e As EventArgs) Handles biDescargar.Click
        Try
            If dgvDatos.RowCount > 0 Then

                Dim dtImprimirDigital As New DataTable

                dtImprimirDigital = oGuiaRemisionService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdGuia").Text).Tables(0)
                GridEX2.DataSource = dtImprimirDigital

                'CodMot = GridEX2.CurrentRow.Cells("CodMot").Text
                'LegalMonetaryTotal = GridEX2.CurrentRow.Cells("LegalMonetaryTotal").Text
                'CurrencyId = GridEX2.CurrentRow.Cells("CurrencyId").Text
                'TipoDoc = GridEX2.CurrentRow.Cells("TipoDoc").Text
                'TaxAmount = GridEX2.CurrentRow.Cells("TaxAmount").Text
                'CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                'NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                DocumentoFac = GridEX2.CurrentRow.Cells("Documento").Text
                'FecDoc = GridEX2.CurrentRow.Cells("FecDoc").Text
                'RucEmp = GridEX2.CurrentRow.Cells("RucEmp").Text
                'RucCli = GridEX2.CurrentRow.Cells("RucCli").Text
                'CodMon = GridEX2.CurrentRow.Cells("CodMon").Text

                CrearCarpeta()
                CrearXML()
                'ObtenerTagFirma()
                CrearPDF()

            Else
                MsgBox("No existe registros, tenga cuidado", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al descargar la factura electronica")
        End Try
    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text)
        End If

        'If Not Directory.Exists("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & DocumentoFac) Then
        '    Directory.CreateDirectory("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & DocumentoFac)
        'End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oGuiaRemisionDigitalService.Descargar(dgvDatos.CurrentRow.Cells("IdGuia").Text)))

            NombreXMLPDF = oGuiaRemisionDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            xmlDoc.Save("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el xml")
        End Try

    End Sub

    Private Sub CrearPDF()
        Try
            Dim pdfDoc() As Byte
            pdfDoc = oGuiaRemisionDigitalService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            NombreXMLPDF = oGuiaRemisionDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            System.IO.File.WriteAllBytes("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf", pdfDoc)

            MsgBox("Se descargo la guia de remision electronica correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try
    End Sub

End Class