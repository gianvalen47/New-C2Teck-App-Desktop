Imports System.ServiceModel
Imports System.Net
Public Class frmConsolidadoMesDet
    Public pIdConsolidado As Integer
    Private ObjConsolidado As New ConsolidadoMesService.ConsolidadoMesServiceClient
    Private Registro As New ConsolidadoMesService.ConsolidadoMes    

    Private dtDetalle As New DataTable
    Public lestado As String

    Private Sub frmConsolidadoMesDet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjConsolidado.Close()            
        Catch ex As TimeoutException
            ObjConsolidado.Abort()            
        Catch ex As CommunicationException
            ObjConsolidado.Abort()            
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdConcepto").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmConsolidadoMesDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnSalir_Click(sender, e)
        End If
    End Sub

    Private Sub frmConsolidadoMesDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDetalle)
        LlenarDatos()
        MostrarDetalles()
    End Sub
   
    Private Sub LlenarDatos()

        Registro = ObjConsolidado.Obtener(pIdConsolidado)
        txtPeriodo.Text = Registro.Periodo
        txtMes.Text = ObjConsolidado.MostrarMes(Registro.Mes)
        txtOficina.Text = Registro.Locacion.Oficina.CodOfi & " - " & Registro.Locacion.Oficina.DesOfi
        txtAlmacen.Text = Registro.Locacion.Almacen.CodAlm & " - " & Registro.Locacion.Almacen.DesAlm
        txtFecIni.Text = Registro.FecIni
        txtFecFin.Text = Registro.FecFin
        txtTotalDol.Text = Registro.TotalDol
        txtTotalSol.Text = Registro.TotalSol
        lblEstado.Text = Registro.Estado

        If Registro.Estado <> "GENERADO" Then
            ' btnProcesar.Enabled = False
            cmBorrar.Enabled = False
            cmModificar.Enabled = False
            btnCerrar.Enabled = False
        End If
    End Sub

    Private Sub MostrarDetalles()
        Try
            dtDetalle = ObjConsolidado.MostrarDetalle(pIdConsolidado).Tables(0)
            dgDetalle.SetDataBinding(dtDetalle, 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub cmActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmActualizar.Click
        Try
            Dim codigo As String = ""
            If dgDetalle.RowCount > 0 Then
                codigo = dgDetalle.CurrentRow.Cells("IdConcepto").Text
            End If
            dtDetalle = Nothing
            MostrarDetalles()
            If dgDetalle.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgDetalle, codigo)
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub cmModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmModificar.Click
        If MsgBox("¿Está seguro de MODIFICAR el Registro Seleccionado?", MsgBoxStyle.YesNo, "Modificar Costo") = MsgBoxResult.Yes Then
            Try
                Dim estado_process As Boolean

                estado_process = ObjConsolidado.ActualizarDetalle(pIdConsolidado, dgDetalle.CurrentRow.Cells("IdConcepto").Text, dgDetalle.CurrentRow.Cells("CodRub").Text, toNumber(dgDetalle.CurrentRow.Cells("NumDoc").Text))
                If estado_process Then
                    MsgBox("Se realizó la modificación correctamente")
                    cmActualizar_Click(sender, e)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
            End Try
        End If
    End Sub

    Private Sub cmBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmBorrar.Click
        If MsgBox("¿Está seguro de BORRAR el Registro Seleccionado?", MsgBoxStyle.YesNo, "Borrar") = MsgBoxResult.Yes Then
            Try
                Dim estado_process As Boolean
                estado_process = ObjConsolidado.BorrarDetalle(pIdConsolidado, dgDetalle.CurrentRow.Cells("IdConcepto").Text, dgDetalle.CurrentRow.Cells("CodRub").Text, toNumber(dgDetalle.CurrentRow.Cells("NumDoc").Text))
                If estado_process Then
                    MsgBox("Se Eliminó el registro con éxito", MsgBoxStyle.Information, "Final Exitoso")
                    MostrarDetalles()
                    ' cmActualizar_Click(sender, e)
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
  
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim dtReporte As New DataTable
            Dim reporte As New rpConsolidado
            Dim forma As New frmReportes
            dtReporte = ObjConsolidado.Imprimir(pIdConsolidado).Tables(0)
            ' If dtReporte.Rows.Count = 0 Then
            'MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
            'Else
            reporte.SetDataSource(dtReporte)
            forma.crvReportes.ReportSource = reporte
            forma.crvReportes.DisplayGroupTree = False
            reporte.SetParameterValue("Mes", txtMes.Text)
            forma.Text = "Reporte de Consolidado de Movimientos de Inventario"
            forma.ShowDialog()
            ' End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Mostrar Datos")
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Está seguro de CERRAR el registro seleccionado?", MsgBoxStyle.YesNo, "Cerrar Proceso") = MsgBoxResult.Yes Then
            Try
                Dim NomPc As String = Dns.GetHostName
                Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                ObjConsolidado.Cerrar(pIdConsolidado, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString)
                MsgBox("Se Cerró el proceso con éxito", MsgBoxStyle.Information, "Final Exitoso")
                LlenarDatos()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cerrar")
            End Try
        End If
    End Sub
End Class