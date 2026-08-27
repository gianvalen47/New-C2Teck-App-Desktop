Imports System.ServiceModel
Public Class frmPlanillas
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjPlanilla As New PlanillaService.PlanillaServiceClient
    Private ObjSeguridad As New SeguridadService.SeguridadClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtCobrador As New DataTable
    Private dtMes As New DataTable
    Private dtPlanilla As New DataTable
    Private IdPer As String

    Private Sub frmPlanillas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            ObjPlanilla.Close()
            ObjSeguridad.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            ObjPlanilla.Abort()
            ObjSeguridad.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            ObjPlanilla.Abort()
            ObjSeguridad.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub dgDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgDetalle.RowCount > 0 Then
                Mostrar()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumero.Select()
        End If
    End Sub

    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow()
        Try

            fila(0) = 1

        Catch ex As Exception

        End Try
        Try

            fila(1) = "OFICINA LIMA"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub frmPlanillas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                 txtNumero.KeyPress _
                , cbMes.KeyPress _
                , cbCobrador.KeyPress _
                , txtPeriodo.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub frmPlanillas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmPlanillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        ObjSeguridad.InsertarSesionOpciones(Session.sIdSesion, 36)
        '/*************************************************************************************/

        dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]

        dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgDetalle.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        LlenarCombos()
        LlenarGrilla()
        HabilitarBotones()
        dgDetalle.Select()
        ValidarUsuario()

    End Sub
    Private Sub ValidarUsuario()
        Dim usuario As New SeguridadService.Usuario
        Dim Cod As Integer
        usuario = ObjSeguridad.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPer = usuario.Persona.IdPer
        If Session.CodPerfil <> "10" And Session.CodPerfil <> "31" Then
            cbCobrador.Value = 0
            cbCobrador.Text = "(Todos)"
        Else
            Cod = IdPer
            cbCobrador.Value = Cod
            cbCobrador.Enabled = False
        End If
    End Sub
    Private Sub LlenarCombos()

        Try
            txtPeriodo.Value = Today.Year
            cbMes.Value = Today.Month

            dtMes = ObjMaestro.MostrarMeses
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            'cbMes.SelectedIndex = cbMes.SelectedIndex = IIf(Month(Today) = 1, 12, Month(Today) - 1)
            dtMes = Nothing

            dtCobrador = ObjPlanilla.MostrarCobradores(Session.sCodEmp).Tables(0) 'ObjMaestro.MostrarCobradores.Tables(0)
            Dim row As DataRow = dtCobrador.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtCobrador.Rows.InsertAt(row, 0)
            dtCobrador.Rows.InsertAt(getRowAsignado(dtCobrador), 0)
            cbCobrador.DataSource = dtCobrador
            cbCobrador.DisplayMember = "ApeNom"
            cbCobrador.ValueMember = "IdPer"
            cbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            cbCobrador.SelectedIndex = 0
            dtCobrador = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub LlenarGrilla()
        Try
            dtPlanilla = ObjPlanilla.Filtrar(Session.sCodEmp, txtPeriodo.Value, cbMes.Value, cbCobrador.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text)).Tables(0)
            Me.dgDetalle.SetDataBinding(dtPlanilla, 0)
            sslbTotal.Text = "Registros : " + dgDetalle.RowCount.ToString

            If dtPlanilla.Rows.Count > 0 Then
                Dim lTotal, lDifCam, lTotalPag As Double
                For Each Fila As DataRow In dtPlanilla.Rows
                    lTotal = lTotal + Fila.Item("Total")
                    lDifCam = lDifCam + Fila.Item("TotalDif")
                    lTotalPag = lTotalPag + Fila.Item("TotalPag")
                Next
                txtTotalDoc.Text = lTotal
                txtTotalDifCam.Text = lDifCam
                txtTotalPagos.Text = lTotalPag
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdPlanilla").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgDetalle.RowCount > 0 Then
            codigo = dgDetalle.CurrentRow.Cells("IdPlanilla").Text
        End If
        dtPlanilla = Nothing
        LlenarGrilla()
        If dgDetalle.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgDetalle, codigo)
        End If

    End Sub
    Private Sub Mostrar()
        If dtPlanilla.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmPlanilla
            forma.pIdPlanilla = dgDetalle.CurrentRow.Cells(0).Text
            forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
            forma.ShowDialog()
            Actualizar()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbCobrador.ValueChanged, txtPeriodo.ValueChanged, cbMes.ValueChanged, txtNumero.TextChanged
        LlenarGrilla()
    End Sub

    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click, cmRefrescar.Click
        Actualizar()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click, cmMostrar.Click, dgDetalle.DoubleClick
        Mostrar()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click, cmNuevo.Click
        Dim forma As New frmPlanilla
        forma.pIdPlanilla = 0
        forma.Text = "Planilla de Cobranzas"
        forma.NuevoRegistro()

        If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtPlanilla = Nothing
            LlenarGrilla()
            RowPossesion(dgDetalle, forma.pIdPlanilla)
            Mostrar()
        End If

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click, cmModificar.Click
        If dgDetalle.CurrentRow.Cells(7).Text = True Then
            MsgBox("Esta planilla ya se encuentra Aprobada, verifique...", MsgBoxStyle.Information, "Ya esta Aprobada")
            Return
        End If

        If dtPlanilla.Rows.Count = 0 Then
            MsgBox("No hay nada que Modificar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmPlanilla
            forma.pIdPlanilla = dgDetalle.CurrentRow.Cells(0).Text
            forma.Text = "Planilla Nº : " & dgDetalle.CurrentRow.Cells(1).Text
            forma.ModificarRegistro()
            forma.ShowDialog()
        End If
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click, cmBorrar.Click
        If dgDetalle.CurrentRow.Cells(7).Text = True Then
            MsgBox("Esta planilla ya se encuentra Aprobada, verifique...", MsgBoxStyle.Information, "Ya esta Aprobada")
            Return
        End If

        If MsgBox("Seguro de Borrar la planilla?", MsgBoxStyle.YesNo, "Borrar") = MsgBoxResult.Yes Then

            Try
                ObjPlanilla.Borrar(dgDetalle.CurrentRow.Cells(0).Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                LlenarGrilla()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Grabar")
            End Try
        End If

    End Sub

    
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click, cmImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rpPlanillaCobranza
            dtReporte = ObjPlanilla.Imprimir(dgDetalle.CurrentRow.Cells(0).Text).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("Contador", dtReporte.Rows.Count)
                forma.Text = "Impresión de Planillas"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click, cmAprobar.Click
        If dgDetalle.CurrentRow.Cells(7).Text = True Then
            MsgBox("Esta planilla ya se encuentra Aprobada, verifique...", MsgBoxStyle.Information, "Ya esta Aprobada")
            Return
        End If

        If MsgBox("¿Está Seguro de APROBAR la Planilla?", MsgBoxStyle.YesNo, "Aprobar") = MsgBoxResult.Yes Then
            Try
                ObjPlanilla.Aprobar(dgDetalle.CurrentRow.Cells(0).Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                btnRefrescar_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Proceso")
            End Try
        End If
    End Sub

    Private Sub btnRevertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevertir.Click, cmRevertir.Click

        If dgDetalle.CurrentRow.Cells(7).Text = False Then
            MsgBox("Esta planilla no esta Aprobada, no hay nada que revertir, Verifique...", MsgBoxStyle.Information, "No esta Aprobada")
            Return
        End If

        If MsgBox("¿Está seguro de REVERTIR la Aprobación de la Planilla?", MsgBoxStyle.YesNo, "Revertir Aprobacion") = MsgBoxResult.Yes Then
            Try
                ObjPlanilla.RevertirAprobacion(dgDetalle.CurrentRow.Cells(0).Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                btnRefrescar_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Proceso")
            End Try
        End If
    End Sub

    Private Sub HabilitarBotones()

        If dtPlanilla.Rows.Count > 0 Then
            Dim Aprobado As Boolean = dgDetalle.CurrentRow.Cells(7).Text
            btnModificar.Enabled = IIf(Aprobado, False, True)
            cmModificar.Enabled = IIf(Aprobado, False, True)
            btnBorrar.Enabled = IIf(Aprobado, False, True)
            cmBorrar.Enabled = IIf(Aprobado, False, True)
            btnAprobar.Enabled = IIf(Aprobado, False, True)
            cmAprobar.Enabled = IIf(Aprobado, False, True)
            btnRevertir.Enabled = IIf(Aprobado, True, False)
            cmRevertir.Enabled = IIf(Aprobado, True, False)
            btnMostrar.Enabled = True
            cmMostrar.Enabled = True
            btnImprimir.Enabled = True
            cmImprimir.Enabled = True
            
        Else

            btnModificar.Enabled = False
            btnBorrar.Enabled = False
            btnMostrar.Enabled = False
            btnAprobar.Enabled = False
            btnRevertir.Enabled = False
            btnImprimir.Enabled = False

            cmModificar.Enabled = False
            cmBorrar.Enabled = False
            cmMostrar.Enabled = False
            cmAprobar.Enabled = False
            cmRevertir.Enabled = False
            cmImprimir.Enabled = False
        End If

        btnNuevo.Enabled = True
        cmNuevo.Enabled = True

        If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Or Session.CodPerfil = "14" Or Session.CodPerfil = "22" Or Session.CodPerfil = "28" Or Session.CodPerfil = "57" Then      '-------- Se agrega el Perfil de Costos 02/08/2016
            btnAprobar.Enabled = True
            cmAprobar.Enabled = True
        Else
            btnAprobar.Enabled = False
            cmAprobar.Enabled = False
        End If

    End Sub

    Private Sub dgDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetalle.SelectionChanged
        HabilitarBotones()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.MouseLeave, btnRefrescar.MouseLeave, btnRevertir.MouseLeave, btnSalir.MouseLeave, btnMostrar.MouseLeave, btnModificar.MouseLeave, btnImprimir.MouseLeave, btnBuscar.MouseLeave, btnBorrar.MouseLeave, btnAprobar.MouseLeave
        sslbMensaje.Text = ""
    End Sub

    Private Sub btnNuevo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNuevo.MouseMove
        sslbMensaje.Text = "Nueva Planilla"
    End Sub

    Private Sub btnRefrescar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRefrescar.MouseMove
        sslbMensaje.Text = "Refrescar los Datos de la Grilla"
    End Sub

    Private Sub btnRevertir_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRevertir.MouseMove
        sslbMensaje.Text = "Revertir Aprobacion de la Planilla"
    End Sub

    Private Sub btnSalir_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSalir.MouseMove
        sslbMensaje.Text = "Salir de la Ventana"
    End Sub

    Private Sub btnMostrar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMostrar.MouseMove
        sslbMensaje.Text = "Mostrar datos del Registro Seleccionado"
    End Sub

    Private Sub btnModificar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnModificar.MouseMove
        sslbMensaje.Text = "Modificar Planilla Seleccionada"
    End Sub

    Private Sub btnImprimir_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnImprimir.MouseMove
        sslbMensaje.Text = "Imprimir Planilla Seleccionada"
    End Sub

    Private Sub btnBuscar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnBuscar.MouseMove
        sslbMensaje.Text = "Buscar los datos segun criterio de Búsqueda"
    End Sub

    Private Sub btnBorrar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnBorrar.MouseMove
        sslbMensaje.Text = "Borrar Planilla Seleccionada"
    End Sub

    Private Sub btnAprobar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAprobar.MouseMove
        sslbMensaje.Text = "Aprobar Planilla Seleccionada"
    End Sub

    Private Sub dgDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDetalle.KeyPress
        'If Not (Char.IsDigit(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub
End Class