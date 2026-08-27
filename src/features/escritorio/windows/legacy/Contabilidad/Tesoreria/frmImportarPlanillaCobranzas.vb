Imports System.ServiceModel

Public Class frmImportarPlanillaCobranzas

    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient

    Private dtDatos As DataTable
    'Private IdOrdenDet As Integer
    Private dtDatosN As DataTable

    Public MesRegistro As String
    Public NumRegistro As String
    Public NumCta As String
    Public CodBan As String
    Public IdCuenta As Integer
    Public CodCuenta As String
    Public Fecha As Date
    Public TipCam As Double
    Public Nombre As String
    Public Glosa As String
    Public CodMon As String
    Public Anulado As Boolean
    Public Periodo As Integer

    Public IdTesoreriaDet As Integer


    Private Sub frmImportarPlanillaCobranzas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oTesoreriaService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
        End Try
    End Sub

    Private Sub frmImportarPlanillaCobranzas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmImportarPlanillaCobranzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = Fecha
    End Sub

    Private Sub btnConsultarPlanillas_Click(sender As Object, e As EventArgs) Handles btnConsultarPlanillas.Click
        ObtenerPlanillaCobranzas()
    End Sub

    Private Sub ObtenerPlanillaCobranzas()
        Try
            If txtFecha.Text.Length > 0 Then
                If rbResumen.Checked Then
                    dtDatos = oTesoreriaService.ConsultarPlanillas(Session.sCodEmp, txtFecha.Value).Tables(0)
                ElseIf rbDetalle.Checked
                    dtDatos = oTesoreriaService.ConsultarDocumentosPlanillasPorMonedaPago(Session.sCodEmp, txtFecha.Value, CodMon).Tables(0)
                End If

                dgvDatos.DataSource = dtDatos
                DataGridView1.DataSource = dtDatos
                'CrearPlanillaCobranzas()
                CalcularTotales()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA IMPORTACION " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CrearPlanillaCobranzas()

        Try
            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("CodCuenta", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("IdCuenta", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("TipoMov", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("TotalDol", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("TotalSol", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("DifCam", Type.GetType("System.Double")))       'datetime
            dtCopia.Columns.Add(New DataColumn("DifCamPos", Type.GetType("System.Double")))        'datetime
            dtCopia.Columns.Add(New DataColumn("DifCamNeg", Type.GetType("System.Double")))

            dtCopia.Rows.Add(New Object() {"1", "1", "1", "0.00", "0.00", "0.00", "0.00", "0.00"})

            dtDatosN = dtCopia.Copy
            dtDatosN.Clear()

            Dim Saldo As Double = 0

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If CInt(DataGridView1.Item(3, i).Value) > 0.00 Then

                    row = dtDatosN.NewRow

                    row(0) = DataGridView1.Item(0, i).Value
                    row(1) = CInt(DataGridView1.Item(1, i).Value)
                    row(2) = DataGridView1.Item(2, i).Value
                    row(3) = CDbl(DataGridView1.Item(3, i).Value)
                    row(4) = CDbl(DataGridView1.Item(4, i).Value)
                    row(5) = CDbl(DataGridView1.Item(5, i).Value)
                    row(6) = CDbl(DataGridView1.Item(6, i).Value)
                    row(7) = CDbl(DataGridView1.Item(7, i).Value)

                    dtDatosN.Rows.Add(row)

                End If
            Next

            dgvDatos.DataSource = dtDatosN

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub CalcularTotales()

        txtTotalDolares.Value = getTotal("TotalDol")
        txtTotalSoles.Value = getTotal("TotalSol")
        txtTotalDif.Value = getTotal("DifCam")

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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try
            If MsgBox("¿Está seguro de IMPORTAR las planillas de cobranzas?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim registro As New TesoreriaService.Tesoreria

                Dim CuentaContable As New TesoreriaService.CuentaContable
                Dim Moneda As New TesoreriaService.Moneda
                Dim Empresa As New TesoreriaService.Empresa
                Dim CuentaBanco As New TesoreriaService.CuentaBancos
                Dim Banco As New TesoreriaService.Banco

                registro.IdTesoreria = 0
                registro.Mes = MesRegistro
                registro.NumRegistro = NumRegistro

                CuentaBanco.NumCta = NumCta
                Banco.CodBan = CodBan
                CuentaBanco.Banco = Banco

                registro.CuentaBancos = CuentaBanco

                CuentaContable.IdCuenta = IdCuenta
                CuentaContable.CodCuenta = CodCuenta
                registro.CuentaContable = CuentaContable

                registro.Fecha = txtFecha.Value
                registro.TipCam = TipCam

                registro.Nombre = Nombre
                registro.Glosa = Glosa

                Moneda.CodMon = CodMon
                registro.Moneda = Moneda
                registro.Anulado = Anulado

                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.Periodo = Periodo

                If rbResumen.Checked Then
                    IdTesoreriaDet = oTesoreriaService.ImportarPlanillaCobranza(registro, txtFecha.Value)
                ElseIf rbDetalle.Checked
                    IdTesoreriaDet = oTesoreriaService.ImportarPlanillaCobranzaDetallado(registro, txtFecha.Value)
                End If


                If IdTesoreriaDet > 0 Then
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

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            ObtenerPlanillaCobranzas()
        End If
    End Sub


End Class