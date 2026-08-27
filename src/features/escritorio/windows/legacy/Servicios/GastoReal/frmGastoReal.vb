Imports System.ServiceModel
Public Class frmGastoReal
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdPersona As Integer
    Private dtDatos As DataTable
    Private dtRubros As DataTable
    Private dtPlaca As DataTable
    Private IdGastoReal As Integer

    Private Sub frmGastoReal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGastoRealService.Close()
            oVehiculoService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oGastoRealService.Abort()
            oVehiculoService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oGastoRealService.Abort()
            oVehiculoService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmGastoReal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoReal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 113)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        txtanio.Value = Today.Year
        llenarcombos()
        listaDatos()
        dgvDatos.Select()
        enableOpciones()
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

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then

                If IsDBNull(dgvDatos.CurrentRow.Cells("IdGastoGer").Value) = True Then

                    If MsgBox("¿Está seguro de ELIMINAR el Gasto Real N° " & dgvDatos.CurrentRow.Cells("IdGastoReal").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim estado_process As Boolean
                        estado_process = oGastoRealService.Borrar(dgvDatos.CurrentRow.Cells("IdGastoReal").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                        If estado_process Then
                            MsgBox("Se eliminó el Gasto Real correctamente")
                            listaDatos()
                        Else
                            MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                        End If
                    End If
                Else
                    MsgBox("No se puede eliminar el Gasto, Comunicarse con Gerencia General")

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        Mostrar()
        dgvDatos.Select()
    End Sub

    Private Sub Mostrar()
        Try
            If dgvDatos.RowCount > 0 Then
                'If (oJobService.Estado(CStr(dgvDatos.CurrentRow.Cells("CodJob").Value)) = 16 Or oJobService.Estado(CStr(dgvDatos.CurrentRow.Cells("CodJob").Value)) = 25) And oJobService.Regularizar(CStr(dgvDatos.CurrentRow.Cells("CodJob").Value)) = False Then
                '    MsgBox("Número de Job Liquidado o Facturado")
                'Else
                Dim frm As New frmGastoReal_Modificar
                frm.IdGastoReal = CInt(dgvDatos.CurrentRow.Cells("IdGastoReal").Value)
                frm.IdGastoGer = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdGastoGer").Value), 0, 1)
                'frm.CodJob = CStr(dgvDatos.CurrentRow.Cells("CodJob").Value)
                'frm.Actualizar = True
                frm.ShowDialog()
                listaDatos()
                RowPossesion(dgvDatos, frm.IdGastoReal)
                'End If
            Else
            MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, txtCodJob.TextChanged, cmbRubro.ValueChanged, txtSolicitante.TextChanged, txtRuc.TextChanged, txtDescripcion.TextChanged, cmbPlaca.ValueChanged, txtIdGasto.TextChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click

        Dim CodJob As String
        CodJob = txtCodJob.Text

        If CodJob = "" Then
            MsgBox("Debe ingresar el Número de Job")
        Else
            Dim frm As New frmGastoReal_Nuevo
            frm.IdGastoReal = 0
            frm.CodJob = CodJob
            frm.Actualizar = False
            frm.ShowDialog()
            'If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            '    ' listaDatos()
            'End If
            listaDatos()
            RowPossesion(dgvDatos, frm.IdGastoReal)
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdGastoReal").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biNuevo.MouseLeave, biMostrar.MouseLeave, _
                              biActualizar.MouseLeave, biSalir.MouseLeave, _
                               miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                              miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Gasto Real actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Gasto Real."
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

    Private Sub biGastosGerencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGastosGerencia.Click
        Try
            Dim frm As New frmGastoReal_GastosGerencia
            'frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()

            End If
        Catch ex As Exception
            MsgBox("Error al Trasladar los Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub enableOpciones()

        Dim permiso As SeguridadService.PermisoUsuario
        Dim GastoGerencia As Boolean
        permiso = oSeguridadService.MostrarPermisos(Session.sCodUsu)
        GastoGerencia = permiso.GastoGerencia

        If GastoGerencia = True Then
            biGastosGerencia.Visible = True
        Else
            biGastosGerencia.Visible = False
        End If

    End Sub

    'Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
    '    Try
    '        Dim forma As New frmReportes
    '        Dim reporte As New rptGastoRealGerencia
    '        'Dim registro As CotizacionServicioService.CotizacionServicio

    '        'Dim dtDatosListado As DataTable

    '        'dtDatosListado = oJobService.Filtrar(txtanio.Text, cmbOficinas.Value, utils.toNumber(cmbTipo.Value), utils.toNumber(txtBuscarCliente.Text), txtSerie.Text, txtDescripcion.Text, utils.toNumber(cmbSupervisor.Value), utils.toNumber(cmbEstados.Value), txtNumJob.Text).Tables(0)
    '        'dgvDatos.DataSource = dtDatos

    '        reporte.SetDataSource(dtDatos)
    '        forma.crvReportes.ReportSource = reporte
    '        forma.crvReportes.DisplayGroupTree = False
    '        'forma.crvReportes.RefreshReport = False

    '        reporte.SetParameterValue("pAnio", txtanio.Text)
    '        'reporte.SetParameterValue("pCliente", txtBuscarCliente.Text)
    '        'reporte.SetParameterValue("pTipo", cmbTipo.Text)
    '        'reporte.SetParameterValue("pEstado", cmbEstados.Text)
    '        'reporte.SetParameterValue("pLoc", cmbOficinas.Text)

    '        forma.Text = "Listado de Jobs"
    '        forma.ShowDialog()
    '    Catch ex As Exception
    '        MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub


End Class