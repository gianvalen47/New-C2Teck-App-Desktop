Public Class frmValorizarFIDatos

    '===========================Servicios====================================================
    Private oImportacionService As New ImportacionService.ImportacionServiceClient

    '======================Declaración de Variables==============================================
    Public dtDetalles As DataTable
    Public RegistroImp As New ImportacionService.Importacion

    Private dtDatos As DataTable

    Private Sub frmValorizarFIDatos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right

        Try
            dtDatos = oImportacionService.MostrarValorizacion(RegistroImp, dtDetalles)
            dgvDatos.DataSource = dtDatos
            txtIgv.Value = getTotal("Igv")
            txtTotIpm.Value = getTotal("Ipm")
            txtTotIgvAd.Value = getTotal("IgvAdu")
            txtTotAdvalorem.Value = getTotal("Advalorem")
            txtTotServicio.Value = getTotal("Servicio")
            txtTotSeguro.Value = getTotal("Seguro")
            txtTotCargaDescarga.Value = getTotal("CarDes")
            txtTotTerminalAlmacen.Value = getTotal("TerAlm")
            txtGastoAgenciaAduana.Value = getTotal("GasAdu")
            txtTransLocal.Value = getTotal("TraLoc")
            txtOtrosGastos.Value = getTotal("OtroGasto")
            txtResguardo.Value = getTotal("Resguardo")
            txtHandLing.Value = getTotal("HandLing")
            txtTorOtrosGastos.Value = getTotal("TotOtrosGastos")
            txtTotFobGen.Value = getTotal("TotFobGen")            
            txtTotFleteDol.Value = getTotal("TotFlete")
            txtTotDerAduSol.Value = getTotal("TotDerAduSol")
            txtTotDerAduDol.Value = getTotal("TotDerAduDol")
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de VALORIZAR la(s) Factura(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim state_process As Boolean
                oImportacionService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                state_process = oImportacionService.ValorizarFactura(RegistroImp, dtDetalles)

                If state_process Then
                    MsgBox("Se ingresó las Facturas de Importación correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("!Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR FACTURAS DE IMPORTACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getTotal(ByVal columna As String) As Double
        Dim total As Double = 0
        Dim row As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.dgvDatos.RowCount - 1
            Me.dgvDatos.Row = i
            row = Me.dgvDatos.GetRow()
            total = total + CDbl(row.Cells(columna).Value)
        Next
        Return total
    End Function

End Class