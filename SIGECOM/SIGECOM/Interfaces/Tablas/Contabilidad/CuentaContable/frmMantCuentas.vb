Imports System.ServiceModel
Public Class frmMantCuentas

    '===========================Servicios====================================================
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatosMayor As New DataTable
    Private dtDatosSubCuenta As New DataTable
    Private dtDatosCtaContable As New DataTable

    Private Sub frmMantCuentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 181)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatosMayor)
        dgvDatosMayor.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosMayor.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        Dim estilo1 As New Estilo
        estilo1.cargaEstiloGrid_Bucadores(dgvDatosSubCuenta)
        dgvDatosSubCuenta.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosSubCuenta.RowFormatStyle.FontSize = 9.0!
        dgvDatosSubCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim estilo2 As New Estilo
        estilo2.CargaEstiloGrid(dgvDatosCtaContable)
        dgvDatosCtaContable.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatosCtaContable.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ListaDatosMayor()

        txtCodCuentaMayor.Focus()
    End Sub

    Private Sub Finalizar()
        Try
            oCuentaContableService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oCuentaContableService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmMantCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TabCuentas.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F3 Then
            TabCuentas.SelectedIndex = "1"
        ElseIf e.KeyCode = Keys.F4 Then
            TabCuentas.SelectedIndex = "2"
        End If
    End Sub

    Private Sub txtCodCuentaMayor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCuentaMayor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            dgvDatosMayor.Select()
        End If
    End Sub

    Private Sub ListaDatosMayor()
        Try
            dtDatosMayor = oCuentaContableService.FiltrarMayor(Session.sCodEmp, txtCodCuentaMayor.Text).Tables(0)
            dgvDatosMayor.DataSource = dtDatosMayor
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE CUENTA MAYOR: " + ex.Message, MsgBoxStyle.Critical)
        End Try      
    End Sub

    Private Sub ListaDatosSubCuenta()
        Try
            dtDatosSubCuenta = oCuentaContableService.MostrarSubCuenta(IIf(dgvDatosMayor.RowCount > 0, toNumber(dgvDatosMayor.CurrentRow.Cells("IdCuentaMayor").Value), 0)).Tables(0)
            dgvDatosSubCuenta.DataSource = dtDatosSubCuenta
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE SUBCUENTA: " + ex.Message, MsgBoxStyle.Critical)
        End Try     
    End Sub

    Private Sub ListaDatosCtaContable()
        Try
            dtDatosCtaContable = oCuentaContableService.MostrarCuentas(IIf(dgvDatosSubCuenta.RowCount > 0, toNumber(dgvDatosSubCuenta.CurrentRow.Cells("IdSubCuenta").Value), 0)).Tables(0)
            dgvDatosCtaContable.DataSource = dtDatosCtaContable            
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS DE CUENTA CONTABLE: " + ex.Message, MsgBoxStyle.Critical)
        End Try       
    End Sub

    Private Sub dgvDatosMayor_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatosMayor.SelectionChanged
        If dgvDatosMayor.RowCount > 0 Then
            lblIdCuentaMayor.Text = dgvDatosMayor.CurrentRow.Cells("IdCuentaMayor").Value.ToString
            lblCodCuentaMayor.Text = dgvDatosMayor.CurrentRow.Cells("CodCuentaMayor").Value.ToString
            txtNomCtaMayor.Text = dgvDatosMayor.CurrentRow.Cells("Nombre").Text
            ListaDatosSubCuenta()
        Else
            lblIdCuentaMayor.Text = ""
            lblCodCuentaMayor.Text = ""
            txtNomCtaMayor.Text = ""
            dgvDatosSubCuenta.DataSource = Nothing
        End If
    End Sub

    Private Sub dgvDatosSubCuenta_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatosSubCuenta.SelectionChanged
        If dgvDatosSubCuenta.RowCount > 0 Then
            lblIdSubCuenta.Text = dgvDatosSubCuenta.CurrentRow.Cells("IdSubCuenta").Value.ToString
            lblCodSubCuenta.Text = dgvDatosSubCuenta.CurrentRow.Cells("CodSubCuenta").Value.ToString
            txtNomSubCuenta.Text = dgvDatosSubCuenta.CurrentRow.Cells("NomSubCuenta").Text
            ListaDatosCtaContable()
        Else
            lblIdSubCuenta.Text = ""
            lblCodSubCuenta.Text = ""
            txtNomSubCuenta.Text = ""
            dgvDatosCtaContable.DataSource = Nothing
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCodCuentaMayor.TextChanged
        ListaDatosMayor()
    End Sub

    Private Sub enableOpciones()
        If dgvDatosMayor.RowCount > 0 Then
            miEliminarCtaMayor.Enabled = True
            miMostrarCtaMayor.Enabled = True
        Else
            miEliminarCtaMayor.Enabled = False
            miMostrarCtaMayor.Enabled = False
        End If

        If dgvDatosSubCuenta.RowCount > 0 Then
            miEliminarSubCuenta.Enabled = True
            miMostrarSubCuenta.Enabled = True
        Else
            miEliminarSubCuenta.Enabled = False
            miMostrarSubCuenta.Enabled = False
        End If
        miNuevoSubCuenta.Enabled = IIf(dgvDatosMayor.RowCount > 0, True, False)

        If dgvDatosCtaContable.RowCount > 0 Then
            miEliminarCtaContable.Enabled = True
            miMostrarCtaContable.Enabled = True
        Else
            miEliminarCtaContable.Enabled = False
            miMostrarCtaContable.Enabled = False
        End If
        miNuevoCtaContable.Enabled = IIf(dgvDatosSubCuenta.RowCount > 0, True, False)
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===============================CUENTA MAYOR==========================================
    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionMayor(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCuentaMayor").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR CUENTA MAYOR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoMayor()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmCuentaMayor
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosMayor = Nothing
                    ListaDatosMayor()
                    If frm.type_process = "insert" Then
                        RowPossesionMayor(dgvDatosMayor, frm.IdCuentaMayor)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA CUENTA MAYOR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarMayor()
        Try
            Dim frm As New frmCuentaMayor
            frm.state_button = True
            frm.IdCuentaMayor = dgvDatosMayor.CurrentRow.Cells("IdCuentaMayor").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosMayor = Nothing
                ListaDatosMayor()
                If frm.type_process = "update" Then
                    RowPossesionMayor(dgvDatosMayor, frm.IdCuentaMayor)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionMayor(dgvDatosMayor, frm.IdCuentaMayor)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CUENTA MAYOR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarMayor()
        Try
            cmbOpcionesMayor.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Cuenta Mayor con Código = " + dgvDatosMayor.CurrentRow.Cells("CodCuentaMayor").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCuentaContableService.BorrarMayor(toNumber(dgvDatosMayor.CurrentRow.Cells("IdCuentaMayor").Text))
                If estado_process = True Then
                    dtDatosMayor = Nothing
                    ListaDatosMayor()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CUENTA MAYOR :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesMayor()
        Try
            Dim codigo As String = ""
            If dgvDatosMayor.RowCount > 0 Then
                If IsDBNull(dgvDatosMayor.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosMayor.CurrentRow.Cells("IdCuentaMayor").Text
                End If
            End If
            dtDatosMayor = Nothing
            ListaDatosMayor()
            If dgvDatosMayor.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionMayor(dgvDatosMayor, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR CUENTAS MAYOR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoMayor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoCtaMayor.Click
        NuevoMayor()
    End Sub

    Private Sub miMostrarCtaMayor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCtaMayor.Click, dgvDatosMayor.DoubleClick
        mostrarMayor()
    End Sub

    Private Sub miEliminarCtaMayor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarCtaMayor.Click
        eliminarMayor()
    End Sub

    Private Sub miActualizarCtaMayor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarCtaMayor.Click
        actualizarDetallesMayor()
    End Sub

    Private Sub dgvDatosMayor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosMayor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosMayor.RowCount > 0 Then
                miMostrarCtaMayor_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '===============================SUB CUENTA============================================
    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionSubCuenta(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdSubCuenta").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR SUBCUENTA [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoSubCuenta()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmSubCuenta
                frm.state_button = False
                frm.IdCuentaMayor = lblIdCuentaMayor.Text                
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosSubCuenta = Nothing
                    ListaDatosSubCuenta()
                    If frm.type_process = "insert" Then
                        RowPossesionSubCuenta(dgvDatosSubCuenta, frm.IdSubCuenta)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA SUB CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarSubCuenta()
        Try
            Dim frm As New frmSubCuenta
            frm.state_button = True
            frm.IdCuentaMayor = dgvDatosSubCuenta.CurrentRow.Cells("IdCuentaMayor").Text
            frm.IdSubCuenta = dgvDatosSubCuenta.CurrentRow.Cells("IdSubCuenta").Text            
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosSubCuenta = Nothing
                ListaDatosSubCuenta()
                If frm.type_process = "update" Then
                    RowPossesionSubCuenta(dgvDatosSubCuenta, frm.IdSubCuenta)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionSubCuenta(dgvDatosSubCuenta, frm.IdSubCuenta)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR SUB CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarSubCuenta()
        Try
            cmbOpcionesSubCuenta.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Sub Cuenta con Código = " + dgvDatosSubCuenta.CurrentRow.Cells("CodSubCuenta").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCuentaContableService.BorrarSubCuenta(toNumber(dgvDatosSubCuenta.CurrentRow.Cells("IdSubCuenta").Text))
                If estado_process = True Then
                    dtDatosSubCuenta = Nothing
                    ListaDatosSubCuenta()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR SUB CUENTA :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesSubCuenta()
        Try
            Dim codigo As String = ""
            If dgvDatosSubCuenta.RowCount > 0 Then
                If IsDBNull(dgvDatosSubCuenta.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosSubCuenta.CurrentRow.Cells("IdSubCuenta").Text
                End If
            End If
            dtDatosSubCuenta = Nothing
            ListaDatosSubCuenta()
            If dgvDatosSubCuenta.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionSubCuenta(dgvDatosSubCuenta, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR SUB CUENTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoSubCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoSubCuenta.Click
        NuevoSubCuenta()
    End Sub

    Private Sub miMostrarSubCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarSubCuenta.Click, dgvDatosSubCuenta.DoubleClick
        mostrarSubCuenta()
    End Sub

    Private Sub miEliminarSubCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarSubCuenta.Click
        eliminarSubCuenta()
    End Sub

    Private Sub miActualizarSubCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarSubCuenta.Click
        actualizarDetallesSubCuenta()
    End Sub

    Private Sub dgvDatosSubCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosSubCuenta.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosSubCuenta.RowCount > 0 Then
                miMostrarSubCuenta_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------------------
    '==========================CUENTA CONTABLE==============================
    '-----------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub RowPossesionCtaContable(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCuenta").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR CUENTA CONTABLE [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoCtaContable()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmCuentaContable
                frm.state_button = False
                frm.IdSubCuenta = lblIdSubCuenta.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosCtaContable = Nothing
                    ListaDatosCtaContable()
                    If frm.type_process = "insert" Then
                        RowPossesionCtaContable(dgvDatosCtaContable, frm.IdCuenta)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA CUENTA CONTABLE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarCtaContable()
        Try
            Dim frm As New frmCuentaContable
            frm.state_button = True
            frm.IdSubCuenta = dgvDatosCtaContable.CurrentRow.Cells("IdSubCuenta").Text
            frm.IdCuenta = dgvDatosCtaContable.CurrentRow.Cells("IdCuenta").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosCtaContable = Nothing
                ListaDatosCtaContable()
                If frm.type_process = "update" Then
                    RowPossesionCtaContable(dgvDatosCtaContable, frm.IdCuenta)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If            
            RowPossesionCtaContable(dgvDatosCtaContable, frm.txtCodCuenta.Text)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CUENTA CONTABLE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarCtaContable()
        Try
            cmbOpcionesCtaContable.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Cuenta Contable con Código = " + dgvDatosCtaContable.CurrentRow.Cells("CodCuenta").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCuentaContableService.Borrar(toNumber(dgvDatosCtaContable.CurrentRow.Cells("IdCuenta").Text))
                If estado_process = True Then
                    dtDatosCtaContable = Nothing
                    ListaDatosCtaContable()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CUENTA CONTABLE :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesCtaContable()
        Try
            Dim codigo As String = ""
            If dgvDatosCtaContable.RowCount > 0 Then
                If IsDBNull(dgvDatosCtaContable.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosCtaContable.CurrentRow.Cells("IdCuenta").Text
                End If
            End If
            dtDatosCtaContable = Nothing
            ListaDatosCtaContable()
            If dgvDatosCtaContable.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionCtaContable(dgvDatosCtaContable, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR CUENTAS CONTABLES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoCtaContable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoCtaContable.Click
        NuevoCtaContable()
    End Sub

    Private Sub miMostrarCtaContable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCtaContable.Click, dgvDatosCtaContable.DoubleClick
        mostrarCtaContable()
    End Sub

    Private Sub miEliminarCtaContable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarCtaContable.Click
        eliminarCtaContable()
    End Sub

    Private Sub miActualizarCtaContable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarCtaContable.Click
        actualizarDetallesCtaContable()
    End Sub

    Private Sub dgvDatosCtaContable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatosCtaContable.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatosSubCuenta.RowCount > 0 Then
                miMostrarCtaContable_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click

        Dim forma As New frmReportes
        Dim dtReporte As New DataTable
        Dim reporte As New rpRepCuentaContable

        dtReporte = oCuentaContableService.Imprimir(Session.sCodEmp).Tables(0)

        If dtReporte.Rows.Count = 0 Then
            MsgBox("No hay datos a mostrar")
        Else
            reporte.SetDataSource(dtReporte)
            forma.crvReportes.ReportSource = reporte
            ' forma.crvReportes.DisplayGroupTree = False
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.Text = "Reporte de Cuenta Contable"
            forma.ShowDialog()
        End If

    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub
End Class