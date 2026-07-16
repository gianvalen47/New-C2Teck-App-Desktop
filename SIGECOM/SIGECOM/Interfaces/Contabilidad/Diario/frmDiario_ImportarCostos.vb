Imports System.ServiceModel

Public Class frmDiario_ImportarCostos

    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient

    Public IdContabilidad As Integer
    Public IdContabilidadDet As Integer
    Public Periodo As Integer
    Public MesRegistro As String

    Public ITipoLibro As Integer
    Public NumRegistro As String
    Public Fecha As Date
    Public TipoCambio As Double
    Public Nombre As String
    Public Glosa As String
    Public IMoneda As String
    Public Anulado As Boolean

    Private dtDatos As DataTable

    Private Sub frmDiario_ImportarCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListarCostos()

    End Sub

    Private Sub frmDiario_ImportarCostos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDiario_ImportarCostos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oContabilidadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
        End Try
    End Sub

    Private Sub ListarCostos()

        dtDatos = oContabilidadService.ConsultarCostos(Session.sCodEmp, Periodo, MesRegistro).Tables(0)
        dgvDatos.DataSource = dtDatos
        CalcularTotales()

    End Sub

    Private Sub CalcularTotales()

        txtTotalCosto.Value = getTotalHaber("Costo")

    End Sub

    Private Function getTotalDebe(ByVal columna As String) As Double
        Dim total As Double = 0
        Dim row As Janus.Windows.GridEX.GridEXRow

        For i = 0 To Me.dgvDatos.RowCount - 1
            Me.dgvDatos.Row = i
            row = Me.dgvDatos.GetRow()
            If row.Cells("TipMov").Value = "D" Then
                total = total + CDbl(row.Cells(columna).Value)
            End If
        Next
        Return total
    End Function

    Private Function getTotalHaber(ByVal columna As String) As Double
        Dim total As Double = 0
        Dim row As Janus.Windows.GridEX.GridEXRow
        For i = 0 To Me.dgvDatos.RowCount - 1
            Me.dgvDatos.Row = i
            row = Me.dgvDatos.GetRow()
            If row.Cells("TipMov").Value = "H" Then
                total = total + CDbl(row.Cells(columna).Value)
            End If
        Next
        Return total
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If MsgBox("¿Está seguro de IMPORTAR los costos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim registro As New ContabilidadService.Contabilidad
                'Dim TipoDocumento As New ContabilidadService.TipoDocumento
                Dim Moneda As New ContabilidadService.Moneda
                Dim Empresa As New ContabilidadService.Empresa
                Dim RegistroCompra As New ContabilidadService.RegistroCompra
                Dim TipoLibro As New ContabilidadService.TipoLibro

                registro.IdContabilidad = IdContabilidad
                RegistroCompra.IdCompra = Nothing
                registro.RegistroCompra = RegistroCompra
                TipoLibro.IdLibro = ITipoLibro
                registro.TipoLibro = TipoLibro
                registro.Mes = MesRegistro
                registro.NumRegistro = NumRegistro

                registro.Fecha = Fecha
                registro.TipCam = TipoCambio

                registro.Nombre = Nombre
                registro.Glosa = Glosa

                Moneda.CodMon = IMoneda
                registro.Moneda = Moneda
                registro.Anulado = Anulado

                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.Periodo = Periodo

                IdContabilidadDet = oContabilidadService.ImportarCostos(registro)

                If IdContabilidadDet > 0 Then


                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class