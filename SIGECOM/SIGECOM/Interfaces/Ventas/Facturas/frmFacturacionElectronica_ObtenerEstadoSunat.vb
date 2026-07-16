Imports System.IO
Imports System.ServiceModel
Imports FacturarSunat.aplicacion
Imports FacturarSunat21.aplicacion
Public Class frmFacturacionElectronica_ObtenerEstadoSunat

    Private oComunicacionBajaDigitalService As New ComunicacionBajaDigitalService.ComunicacionBajaDigitalServiceClient
    Private oCommunicationState As New ComunicacionSunat

    Private dtTipoDocRef As DataTable
    'Private dtDatos As DataTable
    Public TipoDoc As String = 0
    Public CodSerie As String = ""
    Public NumDoc As String = ""

    Private Sub frmFacturacionElectronica_ObtenerEstadoSunat_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComunicacionBajaDigitalService.Close()
        Catch ex As TimeoutException
            oComunicacionBajaDigitalService.Close()
        Catch ex As CommunicationException
            oComunicacionBajaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmFacturacionElectronica_ObtenerEstadoSunat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFacturacionElectronica_ObtenerEstadoSunat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        cmbTipDoc.Value = IIf(TipoDoc = 0, "01", TipoDoc)
        txtSerieDocRef.Text = CodSerie
        txtNumDocRef.Text = NumDoc
    End Sub

    Private Sub LlenarCombos()
        Try
            dtTipoDocRef = oComunicacionBajaDigitalService.MostrarTipoDocumento.Tables(0)
            cmbTipDoc.DataSource = dtTipoDocRef
            cmbTipDoc.DropDownList.DataMember = dtTipoDocRef.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.DisplayMember = dtTipoDocRef.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.ValueMember = dtTipoDocRef.Columns("CodSunat").ToString
            cmbTipDoc.DropDownList.Columns(0).DataMember = dtTipoDocRef.Columns("CodSunat").ToString
            cmbTipDoc.DropDownList.Columns(1).DataMember = dtTipoDocRef.Columns("Nombre").ToString
            dtTipoDocRef = Nothing
        Catch ex As Exception
            MsgBox("Error al llenar combos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim mensajeestado As String
            'mensajeestado = oCommunicationState.ObtenerMensajeEstado("20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)
            mensajeestado = EnviarSunat.ObtenerEstadoDocumento(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)

            If mensajeestado <> "" Then
                txtRespuesta.Text = mensajeestado
                btnObtenerCDR.Visible = True
            Else
                btnObtenerCDR.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
        End Try
    End Sub

    Private Sub btnObtenerCDR_Click(sender As System.Object, e As System.EventArgs) Handles btnObtenerCDR.Click

        Try
            Dim Ubicacion As String = ""
            Dim UbicacionconFile As String = ""
            Dim NombreArchivo As String = ""
            Dim file As New SaveFileDialog()
            file.FileName = "R-" & Session.sRucEmp & "-" & cmbTipDoc.Value & "-" & txtSerieDocRef.Text & "-" & txtNumDocRef.Text
            file.Filter = "XML|*.xml"
            If file.ShowDialog() = DialogResult.OK Then
                UbicacionconFile = file.FileName
                NombreArchivo = System.IO.Path.GetFileName(UbicacionconFile)

                Dim fileInfo As New FileInfo(UbicacionconFile)
                Ubicacion = fileInfo.DirectoryName

                Dim obtenerestado As Boolean
                'obtenerestado = oCommunicationState.ObtenerCDR(Ubicacion, "R-20100020441-" & cmbTipDoc.Value & "-" & txtSerieDocRef.Text & "-" & txtNumDocRef.Text & ".xml", "20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)
                'obtenerestado = oCommunicationState.ObtenerCDR(Ubicacion, NombreArchivo, "20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)
                'obtenerestado = oCommunicationState.ObtenerCDR("D:\Cibertec Cursos", "R-20100020441-" & cmbTipDoc.Value & "-" & txtSerieDocRef.Text & "-" & txtNumDocRef.Text & ".xml", "20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)

                obtenerestado = EnviarSunat21.ObtenerCdrDocumento(Session.sRucEmp, Session.sUsuarioSunat, Session.sClaveSunat, Ubicacion, NombreArchivo, cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)

                If obtenerestado Then
                    MsgBox("Se obtuvo el cdr correctamente.", MsgBoxStyle.Information)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
        End Try

    End Sub

    Private Sub btnObtenerCDROSE_Click(sender As Object, e As EventArgs) Handles btnObtenerCDROSE.Click
        Try
            Dim Ubicacion As String = ""
            Dim UbicacionconFile As String = ""
            Dim NombreArchivo As String = ""
            Dim file As New SaveFileDialog()
            file.FileName = "R-" & Session.sRucEmp & "-" & cmbTipDoc.Value & "-" & txtSerieDocRef.Text & "-" & txtNumDocRef.Text
            file.Filter = "XML|*.xml"
            If file.ShowDialog() = DialogResult.OK Then
                UbicacionconFile = file.FileName
                NombreArchivo = System.IO.Path.GetFileName(UbicacionconFile)

                Dim fileInfo As New FileInfo(UbicacionconFile)
                Ubicacion = fileInfo.DirectoryName

                Dim obtenerestado As Boolean
                'obtenerestado = oCommunicationState.ObtenerCDR(Ubicacion, "R-20100020441-" & cmbTipDoc.Value & "-" & txtSerieDocRef.Text & "-" & txtNumDocRef.Text & ".xml", "20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)
                'obtenerestado = oCommunicationState.ObtenerCDR(Ubicacion, NombreArchivo, "20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)
                'obtenerestado = oCommunicationState.ObtenerCDR("D:\Cibertec Cursos", "R-20100020441-" & cmbTipDoc.Value & "-" & txtSerieDocRef.Text & "-" & txtNumDocRef.Text & ".xml", "20100020441", cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)

                obtenerestado = EnviarSunat21.ObtenerCdrDocumentoOSE(Session.sRucEmp, Session.sUsuarioOSE, Session.sClaveOSE, Ubicacion, NombreArchivo, cmbTipDoc.Value, txtSerieDocRef.Text, txtNumDocRef.Text)

                If obtenerestado Then
                    MsgBox("Se obtuvo el cdr correctamente.", MsgBoxStyle.Information)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar los documentos")
        End Try
    End Sub
End Class