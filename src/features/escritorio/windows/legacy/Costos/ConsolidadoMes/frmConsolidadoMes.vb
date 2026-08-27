Imports System.ServiceModel
Imports System.Net
Public Class frmConsolidadoMes
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjConsolidado As New ConsolidadoMesService.ConsolidadoMesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficina As New DataTable
    Private dtMes As New DataTable
    Private dtEstado As New DataTable
    Private dtConsolidado As New DataTable
    Private dtAlmacen As New DataTable

    Private Sub dgConsolidado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgConsolidado.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgConsolidado.RowCount > 0 Then
                e.Handled = True
                btnMostrar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmConsolidadoMes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtPeriodo.KeyPress _
        , cbAlmacen.KeyPress _
        , cbEstado.KeyPress _
        , cbMes.KeyPress _
        , cbOficina.KeyPress _
        , dgConsolidado.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmConsolidadoMes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjConsolidado.Close()
            ObjMaestro.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            ObjConsolidado.Abort()
            ObjMaestro.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            ObjConsolidado.Abort()
            ObjMaestro.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsolidadoMes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdConsolidado").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LlenarCombos()

        Try
            txtPeriodo.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))

            dtMes = ObjMaestro.MostrarMeses
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            dtEstado = ObjConsolidado.MostrarEstados
            cbEstado.DataSource = dtEstado
            cbEstado.DisplayMember = "Descripcion"
            cbEstado.ValueMember = "Estado"
            cbEstado.DropDownList.Columns(0).DataMember = "Estado"
            cbEstado.DropDownList.Columns(1).DataMember = "Descripcion"
            cbEstado.SelectedIndex = 0
            dtEstado = Nothing

            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            Dim row As DataRow = dtOficina.NewRow
            row(0) = ""
            row(1) = "(Todos)"
            dtOficina.Rows.InsertAt(row, 0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

         
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Public Sub LlenarGrilla()
        Try
            dtConsolidado = ObjConsolidado.Filtrar(Session.sCodEmp, txtPeriodo.Value, cbMes.Value, cbOficina.Value, cbAlmacen.Value, cbEstado.Value).Tables(0)
            Me.dgConsolidado.SetDataBinding(dtConsolidado, 0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click, cmMostrar.Click, dgConsolidado.DoubleClick
        Try
            If dtConsolidado.Rows.Count = 0 Then
                MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
            Else
                Dim forma As New frmConsolidadoMesDet
                'forma.MdiParent = Me.MdiParent
                forma.pIdConsolidado = dgConsolidado.CurrentRow.Cells("IdConsolidado").Text
                forma.lestado = dgConsolidado.CurrentRow.Cells("Estado").Text
                forma.ShowDialog(Me)
                RowPossesion(dgConsolidado, forma.pIdConsolidado)
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
      
    End Sub

    Private Sub frmConsolidadoMes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 59)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgConsolidado)
        dgConsolidado.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgConsolidado.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        LlenarCombos()
        LlenarGrilla()
        txtPeriodo.Select()
        enableOpciones()

    End Sub
    Private Sub enableOpciones()
        If dgConsolidado.RowCount < 1 Then
            btnActualizar.Enabled = False
            btnBorrar.Enabled = False
            btnCerrar.Enabled = False
            btnRevertir.Enabled = False
            btnImprimir.Enabled = False
            btnMostrar.Enabled = False

            cmActualizar.Enabled = False
            cmBorrar.Enabled = False
            cmCerrar.Enabled = False
            cmRevertir.Enabled = False
            cmImprimir.Enabled = False
            cmMostrar.Enabled = False

        Else
            btnActualizar.Enabled = True
            btnImprimir.Enabled = True
            btnBorrar.Enabled = IIf(dgConsolidado.CurrentRow.Cells("Estado").Text = "GENERADO", True, False)
            btnCerrar.Enabled = IIf(dgConsolidado.CurrentRow.Cells("Estado").Text = "CERRADO", False, True)
            btnRevertir.Enabled = IIf(dgConsolidado.CurrentRow.Cells("Estado").Text = "CERRADO", True, False)
            btnMostrar.Enabled = True

            cmActualizar.Enabled = True
            cmImprimir.Enabled = True
            cmBorrar.Enabled = IIf(dgConsolidado.CurrentRow.Cells("Estado").Text = "GENERADO", True, False)
            cmCerrar.Enabled = IIf(dgConsolidado.CurrentRow.Cells("Estado").Text = "CERRADO", False, True)
            cmRevertir.Enabled = IIf(dgConsolidado.CurrentRow.Cells("Estado").Text = "CERRADO", True, False)
            cmMostrar.Enabled = True
        End If
    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            Dim row As DataRow = dtAlmacen.NewRow
            row(0) = 0
            row("DesAlm") = "(Todos)"
            dtAlmacen.Rows.InsertAt(row, 0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox("ERROR [BUSC-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmActualizar.Click, txtPeriodo.ValueChanged, cbMes.ValueChanged, cbOficina.ValueChanged, cbAlmacen.ValueChanged, cbEstado.ValueChanged, btnActualizar.Click
        LlenarGrilla()
    End Sub
    Private Sub Actualizar()
        Try
            Dim codigo As String = ""
            If dgConsolidado.RowCount > 0 Then
                codigo = dgConsolidado.CurrentRow.Cells("IdConsolidado").Text
            End If
            dtConsolidado = Nothing
            LlenarGrilla()
            If dgConsolidado.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgConsolidado, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click, cmNuevo.Click
        Try
            Dim forma As New frmConsolidadoNuevo
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtConsolidado = Nothing
                LlenarGrilla()
                'MsgBox("Se Realizo Correctamente el Proceso", MsgBoxStyle.Information, "Final Exitoso")
                If forma.IdLocacion <> 0 Then
                    RowPossesion(dgConsolidado, forma.IdConsolidado)
                Else
                    Actualizar()
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click, cmBorrar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Borrar") = MsgBoxResult.Yes Then
            Try
                Dim NomPc As String = Dns.GetHostName
                Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                ObjConsolidado.Borrar(dgConsolidado.CurrentRow.Cells("IdConsolidado").Text, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString)
                MsgBox("Se eliminó el registro correctamente", MsgBoxStyle.Information, "Final Exitoso")
                LlenarGrilla()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Borrar")
            End Try
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click, cmImprimir.Click
        Try
            Dim dtReporte As New DataTable
            Dim reporte As New rpConsolidado
            Dim forma As New frmReportes
            dtReporte = ObjConsolidado.Imprimir(dgConsolidado.CurrentRow.Cells("IdConsolidado").Text).Tables(0)

            Dim total As Double
            For Each Fila As DataRow In dtReporte.Rows
                If Fila.Item("TipMov").ToString = "S" Then
                    Dim contador As Double
                    contador = IIf(Fila.Item("CosSol") Is DBNull.Value, 0, Fila.Item("CosSol"))
                    total = total + contador
                End If
            Next
            ' If dtReporte.Rows.Count = 0 Then
            'MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
            'Else
            reporte.SetDataSource(dtReporte)
            forma.crvReportes.ReportSource = reporte

            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            'forma.crvReportes.RefreshReport = False
            'forma.crvReportes.DisplayGroupTree = False

            reporte.SetParameterValue("Mes", cbMes.Text)
            reporte.SetParameterValue("SaldoAlmacen", total)
            forma.Text = "Reporte de Consolidado de Movimientos de Inventario"
            forma.ShowDialog()
            ' End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Mostrar Datos")
        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, cmCerrar.Click
        If MsgBox("¿Está seguro de CERRAR el registro seleccionado?", MsgBoxStyle.YesNo, "Cerrar Proceso") = MsgBoxResult.Yes Then
            Try
                Dim NomPc As String = Dns.GetHostName
                Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                ObjConsolidado.Cerrar(dgConsolidado.CurrentRow.Cells("IdConsolidado").Text, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString)
                LlenarGrilla()
                MsgBox("Se Cerró el proceso correctamente", MsgBoxStyle.Information, "Final Exitoso")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cerrar")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, cmSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub dgConsolidado_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgConsolidado.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub btnRevertir_Click(sender As Object, e As EventArgs) Handles btnRevertir.Click, cmRevertir.Click
        If MsgBox("¿Está seguro de REVERTIR CONSOLIDADO seleccionado?", MsgBoxStyle.YesNo, "Revertir Proceso") = MsgBoxResult.Yes Then
            Try
                Dim NomPc As String = Dns.GetHostName
                Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                ObjConsolidado.Revertir(dgConsolidado.CurrentRow.Cells("IdConsolidado").Text, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString)
                LlenarGrilla()
                MsgBox("Se Revertio el proceso correctamente", MsgBoxStyle.Information, "Final Exitoso")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cerrar")
            End Try
        End If
    End Sub
End Class