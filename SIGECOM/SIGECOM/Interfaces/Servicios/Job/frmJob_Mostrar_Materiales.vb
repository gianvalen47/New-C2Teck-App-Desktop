Imports System.ServiceModel

Public Class frmJob_Mostrar_Materiales

    Private oJobService As New JobService.JobServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient

    Private dtDatos As DataTable
    Private dtDatos2 As DataTable
    Public CodJob As String
    Public CodRubro As String
    Public CodMon As String
    Public Anio As Integer
    Public MostrarMat As Boolean

    Private Sub frmJob_Mostrar_Materiales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oGastoRealService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oGastoRealService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oGastoRealService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Mostrar_Materiales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Mostrar_Materiales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        listaDatos()  'Lista Datos de Materiales de Almacen

        If MostrarMat = True Then
            listaDatos2() 'Lista Datos de Materiales ingresados por Gasto Real
            Me.Size = New System.Drawing.Size(866, 706)
            lblMostrarMat.Visible = False
            Label1.Visible = True
            Label2.Visible = True
        Else
            Me.Size = New System.Drawing.Size(866, 411)
            lblMostrarMat.Visible = True
            Label1.Visible = False
            Label2.Visible = False
        End If
        lblNumJob.Text = CodJob
        lblRubro.Text = "Materiales de Almacen"

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.ConsultarGastos(CodJob, CodRubro, Session.sCodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
            SumaColumna()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub listaDatos2()
        Try
            dtDatos2 = oGastoRealService.Filtrar(Anio, CodJob, CodRubro, 0, "", "", "", 0).Tables(0)
            dgvMateriales.DataSource = dtDatos2

            If CodMon = "NS" Then
                SumaColumnaSoles2()
            ElseIf CodMon = "US" Then
                SumaColumnaDolares2()
            End If

            'sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub


    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Private Sub SumaColumna()
        Try
            Dim total As Double = 0
            Dim totalprecio As Double = 0
            Dim totalSol As Double = 0

            If dgvDatos.RowCount <> 0 Then
                For i As Integer = 0 To dgvDatos.RowCount - 1

                    If Not (IsDBNull(dgvDatos.Item("Costo".ToLower, i).Value)) Then
                        total = total + CDbl(dgvDatos.Item("Costo".ToLower, i).Value)
                    End If

                Next

                MontoDol.Text = "Total (" & CodMon & ")"

                txtMontoDol.Value = total
                txtMontoSol.Visible = False
                MontoSol.Visible = False
                PrecioDol.Visible = False
                txtPrecioDol.Visible = False

            End If


        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        End Try
    End Sub


    Private Sub SumaColumnaDolares2()
        Try
            Dim total2 As Double = 0
            Dim totalprecio2 As Double = 0
            Dim totalSol2 As Double = 0

            dgvMateriales.Columns("MontoDol2").Visible = True
            dgvMateriales.Columns("MontoSol2").Visible = False

            If dgvMateriales.RowCount <> 0 Then
                For i As Integer = 0 To dgvMateriales.RowCount - 1

                    If Not (IsDBNull(dgvMateriales.Item("MontoDol2".ToLower, i).Value)) Then
                        total2 = total2 + CDbl(dgvMateriales.Item("MontoDol2".ToLower, i).Value)
                    End If

                Next

                Label4.Text = "Total (" & CodMon & ")"
                txtMontoDol2.Value = total2

            End If

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        End Try
    End Sub

    Private Sub SumaColumnaSoles2()
        Try
            Dim total2 As Double = 0
            Dim totalprecio2 As Double = 0
            Dim totalSol2 As Double = 0

            dgvMateriales.Columns("MontoDol2").Visible = False
            dgvMateriales.Columns("MontoSol2").Visible = True

            If dgvMateriales.RowCount <> 0 Then
                For i As Integer = 0 To dgvMateriales.RowCount - 1
                    If Not (IsDBNull(dgvMateriales.Item("MontoSol2".ToLower, i).Value)) Then
                        total2 = total2 + CDbl(dgvMateriales.Item("MontoSol2".ToLower, i).Value)
                    End If
                Next
                Label4.Text = "Total (" & CodMon & ")"
                txtMontoDol2.Value = total2

            End If

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR DATOS: " + ex.Message)
        End Try
    End Sub


End Class