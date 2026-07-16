Imports System.ServiceModel
Public Class frmRecostearFIMasivo

    '===========================Servicios====================================================
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtFacturas As DataTable

    Private IdImportacion As Integer
    Private IdSerieDoc As Integer
    Private IdLocacion As Integer
    Private NumDoc As String
    Private DesAlm As String
    Private FecDoc As Date
    Private IdProveedor As Integer
    Private DesProv As String
    Private CodMon As String
    Private DesMon As String
    Private TipCam As Double
    Private Observacion As String
    Private TotFobGen As Double
    Private TotFobGenSol As Double
    Private TotalNeto As Double
    Private TotalNetoSol As Double
    Private Estado As String

    Private Sub frmValorizarFIMasivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvFacturas.BackgroundColor = Color.Beige
        dgvFacturas.BackColor = Color.Beige
        dgvFacturas.ForeColor = Color.MidnightBlue
        dgvFacturas.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False

        dtInicio.Value = Today
        dtFinal.Value = Today
        lblRegistros.Text = "0"
        listaDatos()
        listaSeleccionados()
    End Sub

    Private Sub frmValorizarFIMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmValorizarFIMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()
            oPedidoImportService.Close()
        Catch ex As TimeoutException
            oImportacionService.Abort()
            oPedidoImportService.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            oPedidoImportService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA FACTURAS ======================================
            dtFacturas = oImportacionService.Filtrar(0, 0, dtInicio.Value, dtFinal.Value, txtNumero.Text, "CH", "", txtCodEmbarque.Text).Tables(0)
            dgvFacturas.DataSource = dtFacturas

            cIdImportacion.DataPropertyName = dtFacturas.Columns("IdImportacion").ColumnName
            cIdSerieDoc.DataPropertyName = dtFacturas.Columns("IdSerieDoc").ColumnName
            cIdLocacion.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cNumDoc.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cDesAlm.DataPropertyName = dtFacturas.Columns("DesAlm").ColumnName
            cFecDoc.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cIdProveedor.DataPropertyName = dtFacturas.Columns("IdProveedor").ColumnName
            cDesProv.DataPropertyName = dtFacturas.Columns("DesProv").ColumnName
            cCodMon.DataPropertyName = dtFacturas.Columns("CodMon").ColumnName
            cDesMon.DataPropertyName = dtFacturas.Columns("DesMon").ColumnName
            cTipCam.DataPropertyName = dtFacturas.Columns("TipCam").ColumnName
            cObservacion.DataPropertyName = dtFacturas.Columns("Observacion").ColumnName
            cTotFobGen.DataPropertyName = dtFacturas.Columns("TotFobGen").ColumnName
            cTotFobGenSol.DataPropertyName = dtFacturas.Columns("TotFobGenSol").ColumnName
            cTotalNeto.DataPropertyName = dtFacturas.Columns("TotalNeto").ColumnName
            cTotalNetoSol.DataPropertyName = dtFacturas.Columns("TotalNetoSol").ColumnName
            cEstado.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oImportacionService.Filtrar(0, 0, Nothing, Nothing, "", "0", "", txtCodEmbarque.Text).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdImportacion1.DataPropertyName = dtFacturas.Columns("IdImportacion").ColumnName
            cIdSerieDoc1.DataPropertyName = dtFacturas.Columns("IdSerieDoc").ColumnName
            cIdLocacion1.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cNumDoc1.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cDesAlm1.DataPropertyName = dtFacturas.Columns("DesAlm").ColumnName
            cFecDoc1.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cIdProveedor1.DataPropertyName = dtFacturas.Columns("IdProveedor").ColumnName
            cDesProv1.DataPropertyName = dtFacturas.Columns("DesProv").ColumnName
            cCodMon1.DataPropertyName = dtFacturas.Columns("CodMon").ColumnName
            cDesMon1.DataPropertyName = dtFacturas.Columns("DesMon").ColumnName
            cTipCam1.DataPropertyName = dtFacturas.Columns("TipCam").ColumnName
            cObservacion1.DataPropertyName = dtFacturas.Columns("Observacion").ColumnName
            cTotFobGen1.DataPropertyName = dtFacturas.Columns("TotFobGen").ColumnName
            cTotFobGenSol1.DataPropertyName = dtFacturas.Columns("TotFobGenSol").ColumnName
            cTotalNeto1.DataPropertyName = dtFacturas.Columns("TotalNeto").ColumnName
            cTotalNetoSol1.DataPropertyName = dtFacturas.Columns("TotalNetoSol").ColumnName
            cEstado1.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvFacturas.RowCount > 0 Then
                btnAgregar.Enabled = True
                btnAgregarTodos.Enabled = True
            Else
                btnAgregar.Enabled = False
                btnAgregarTodos.Enabled = False
            End If

            If dgvSeleccionados.RowCount > 0 Then
                miEliminar.Enabled = True
            Else
                miEliminar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        IdImportacion = dgvFacturas.Rows(dgvFacturas.CurrentRow.Index).Cells("cIdImportacion").Value.ToString
        If ValidaIdImportacion(dgvSeleccionados, IdImportacion) Then
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvFacturas)
            EnableOptions()
        Else
            MsgBox("La factura ya fue seleccionada.", MsgBoxStyle.Exclamation)
        End If
        lblRegistros.Text = dgvSeleccionados.RowCount
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdImportacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdImportacion").Value.ToString
            IdSerieDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdSerieDoc").Value.ToString
            IdLocacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
            NumDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumDoc").Value.ToString
            DesAlm = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesAlm").Value.ToString
            FecDoc = CDate(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cFecDoc").Value.ToString)
            IdProveedor = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdProveedor").Value.ToString
            DesProv = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesProv").Value.ToString
            CodMon = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodMon").Value.ToString
            DesMon = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesMon").Value.ToString
            TipCam = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTipCam").Value.ToString)
            Observacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cObservacion").Value.ToString
            TotFobGen = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotFobGen").Value.ToString)
            TotFobGenSol = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotFobGenSol").Value.ToString)
            TotalNeto = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalNeto").Value.ToString)
            TotalNetoSol = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalNetoSol").Value.ToString)
            Estado = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cEstado").Value.ToString


            dr("IdImportacion") = IdImportacion
            dr("IdLocacion") = IdLocacion
            dr("IdSerieDoc") = IdSerieDoc
            dr("NumDoc") = NumDoc
            dr("DesAlm") = DesAlm
            dr("FecDoc") = FecDoc
            dr("IdProveedor") = IdProveedor
            dr("DesProv") = DesProv
            dr("CodMon") = CodMon
            dr("DesMon") = DesMon
            dr("TipCam") = TipCam
            dr("Observacion") = Observacion
            dr("TotFobGen") = TotFobGen
            dr("TotFobGenSol") = TotFobGenSol
            dr("TotalNeto") = TotalNeto
            dr("TotalNetoSol") = TotalNetoSol
            dr("Estado") = Estado


            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumero.TextChanged, dtInicio.ValueChanged, dtFinal.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) ''Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos una Factura.", MsgBoxStyle.Information, "Información")
                dgvFacturas.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0
        For i As Integer = 0 To dgvFacturas.RowCount - 1
            IdImportacion = dgvFacturas.Item("cIdImportacion".ToLower, i).Value
            If Not (ValidaIdImportacion(dgvSeleccionados, IdImportacion)) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguna(s) de las facturas ya han sido seleccionadas.", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvFacturas.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvFacturas)
            Next
            EnableOptions()
        End If
        lblRegistros.Text = dgvSeleccionados.RowCount
    End Sub

    Private Function ValidaIdImportacion(ByVal dgvDatos As DataGridView, ByVal IdImportacion As Integer) As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If IdImportacion = dgvDatos.Item("cIdImportacion1".ToLower, i).Value Then
                        cont = cont + 1
                    End If
                Next

                If cont > 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al Validar Factura de Importación: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de  CERRAR el costo de la(s) Factura(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvSeleccionados.Update()
                Dim codigo As Integer = 0
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvSeleccionados.Rows.Count - 1
                    codigo = CInt(dgvSeleccionados.Item("cIdImportacion1".ToLower, i).Value)
                    If oImportacionService.Recostear(codigo, Session.sCodUsu) Then
                        cont = cont + 1
                    End If
                Next

                If cont > 0 Then
                    MsgBox("Se Cerró el Costo previo de los costos de la(s) Factura(s) seleccionada(s)", MsgBoxStyle.Information, "Recalculo Exitoso")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALORIZAR FACTURAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class