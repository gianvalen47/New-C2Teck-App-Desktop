Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmDocsCreditoRenovar
    Public IdDocCtaCte As Int64
    Private oDocumentoCtaCteService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If MsgBox("¿Está seguro de RENOVAR la Letra?", MsgBoxStyle.YesNo, "Renovar") = MsgBoxResult.Yes Then
            Try
                oDocumentoCtaCteService.RenovarLetra(IdDocCtaCte, txtRenovaNuevo.Text, txtVencimientoNuevo.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Grabar")
            End Try

        End If
        
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmDocsCreditoRenovar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oDocumentoCtaCteService.Close()
        Catch ex As TimeoutException
            oDocumentoCtaCteService.Abort()
        Catch ex As CommunicationException
            oDocumentoCtaCteService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmDocsCreditoRenovar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Obtener()
    End Sub

    Private Sub Obtener()
        Try
            Dim registro As New DocumentoCtaCtesService.DocumentoCtaCte
            registro = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
            txtNumDoc.Text = registro.NumDoc
            txtRenovacionActual.Text = registro.Renova
            txtFecVenActual.Text = registro.VenDoc
            txtVencimientoNuevo.Text = Today
            txtRenovaNuevo.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Registro")
        End Try
    End Sub
End Class
