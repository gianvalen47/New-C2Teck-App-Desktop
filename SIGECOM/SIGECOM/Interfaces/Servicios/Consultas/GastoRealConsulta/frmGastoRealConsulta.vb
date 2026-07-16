Imports System.ServiceModel
Public Class frmGastoRealConsulta

    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdPersona As Integer
    Private dtDatos As DataTable
    Private dtRubros As DataTable
    Private dtPlaca As DataTable
    Private IdGastoReal As Integer
    Public IdPerUsu As Integer

    Private Sub frmGastoRealConsulta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGastoRealService.Close()
            oVehiculoService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oGastoRealService.Abort()
            oVehiculoService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oGastoRealService.Abort()
            oVehiculoService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmGastoRealConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoRealConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 129)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        txtanio.Value = Today.Year
        llenarcombos()
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oGastoRealService.Filtrar(txtanio.Value, txtCodJob.Text, cmbRubro.Value, IdPersona, txtRuc.Text, txtDescripcion.Text, cmbPlaca.Value, IIf(toBlank(txtIdGasto.Text) = "", 0, txtIdGasto.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try

        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try

        Return fila
    End Function

    Private Sub llenarcombos()

        '-------------------------------Rubros-----------------------------
        dtRubros = oGastoRealService.MostrarRubros.Tables(0)
        dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
        cmbRubro.DataSource = dtRubros
        cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
        cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
        cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
        cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
        cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
        cmbRubro.SelectedIndex = 3
        dtRubros = Nothing

        ''-------------------------------Placa---------------------------
        dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
        dtPlaca.Rows.InsertAt(getRowTodos1(dtPlaca), 0)
        cmbPlaca.DataSource = dtPlaca
        cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
        cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
        cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
        cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
        'cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
        cmbPlaca.SelectedIndex = 0
        dtPlaca = Nothing

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdGastoReal").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.Close()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        Mostrar()
        dgvDatos.Select()
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmGastoRealConsulta_Nuevo
                frm.IdGastoReal = CInt(dgvDatos.CurrentRow.Cells("IdGastoReal").Value)
                frm.Actualizar = True
                frm.ShowDialog()
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, txtCodJob.TextChanged, cmbRubro.ValueChanged, txtSolicitante.TextChanged, txtRuc.TextChanged, txtDescripcion.TextChanged, cmbPlaca.ValueChanged
        listaDatos()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptGastoReal

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte
            forma.crvReportes.DisplayGroupTree = False
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            'forma.crvReportes.RefreshReport = False

            reporte.SetParameterValue("pCodJob", txtCodJob.Text)
            reporte.SetParameterValue("pAnio", txtanio.Value)
            reporte.SetParameterValue("pRubro", cmbRubro.Text)
            reporte.SetParameterValue("pColaborador", txtSolicitante.Text)
            reporte.SetParameterValue("pPlaca", cmbPlaca.Text)
            reporte.SetParameterValue("pDesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
            reporte.SetParameterValue("pRucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))

            forma.Text = "Reporte de Gastos Generales"
            forma.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al imprimir : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biMostrar.MouseLeave, _
                             biActualizar.MouseLeave, biSalir.MouseLeave, _
                              miImprimir.MouseLeave, miMostrar.MouseLeave, _
                             miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Gasto Real actual."
    End Sub   
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Gasto Real actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
End Class