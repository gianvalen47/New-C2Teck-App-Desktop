Public Class frmAprobarFactor_Dscto

    Private oClienteFacDscService As New ClienteFacDscService.ClienteFacDscServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Public IdLocacion As Integer
    Public GruAlm As String
    Public IdCliente As Integer
    Public Cliente As String
    Public CodMer As String
    Public Fecha As Date
    Public CodMon As String

    Private Sub frmAprobarFactor_Dscto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oClienteFacDscService) = False Then
                oClienteFacDscService.Close()
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAprobarFactor_Dscto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAprobarFactor_Dscto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCliente.Text = Cliente
        txtCodMer.Text = CodMer
        If oClienteFacDscService.Buscar(Session.sCodEmp, GruAlm, IdCliente) Then
            Dim factorCliente As New ClienteFacDscService.ClienteFacDsc
            factorCliente = oClienteFacDscService.MostrarPorId(Session.sCodEmp, GruAlm, IdCliente)
            txtFacCli.Text = factorCliente.FacCli
            txtDscCli.Text = factorCliente.DscCli
        End If
        listarPrecios()

    End Sub
    Private Sub listarPrecios()
        txtPreFab.Text = oPrecioService.PrecioFabricaEmpresa(CodMer, Session.sCodEmp, CodMon, Fecha)
        txtPreVen.Text = oPrecioService.PrecioVenta(IdLocacion, IdCliente, CodMer, CodMon, Fecha)
        txtPreMos.Text = oPrecioService.PrecioMostrador(IdLocacion, CodMer, CodMon)
        txtPreOfe.Text = oPrecioService.PrecioOferta(IdLocacion, CodMer, CodMon)
        txtPreCli.Text = oPrecioService.PrecioCliente(IdLocacion, IdCliente, CodMer, CodMon)
        txtPreLis.Text = oPrecioService.PrecioLista(IdLocacion, CodMer, CodMon)
    End Sub
   
End Class