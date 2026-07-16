Imports System.ServiceModel

Public Class frmMovimientoBancos

    '===========================Servicios====================================================
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================

    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMeses As DataTable
    Private dtBancos As DataTable
    Private dtCuentas As DataTable

    Private iEstado As Integer

    Private Sub frmMovimientoBancos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMovimientoBancosService.Close()
            oMaestroService.Close()
            oPlanillaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMovimientoBancosService.Abort()
            oMaestroService.Abort()
            oPlanillaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMovimientoBancosService.Abort()
            oMaestroService.Abort()
            oPlanillaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmMovimientoBancos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
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
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()

        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            '======================================= BANCOS =================================================
            dtBancos = oMovimientoBancosService.MostrarBancos.Tables(0)
            dtBancos.Rows.InsertAt(getRowTodos(dtBancos), 0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.SelectedIndex = 0
            dtBancos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmMovimientoBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 254)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        txtAnio.Value = Today.Year
        cmbMes.Value = Today.Month
        ListaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oMovimientoBancosService.Filtrar(Session.sCodEmp, txtAnio.Value, toNumber(cmbMes.Value), toBlank(cmbBanco.Value), IIf(cmbNumCuenta.Text = "(Todos)", "", cmbNumCuenta.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, miActualizar.Click
        ListaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        mostrar()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
        End If
    End Sub

    Private Sub Eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Movimiento Banco Nº " + dgvDatos.CurrentRow.Cells("IdMovimiento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oMovimientoBancosService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdMovimiento").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ListaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL MOVIMIENTO BANCO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                             biNuevo.MouseLeave, biMostrar.MouseLeave, _
                            biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                            miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                            miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir el Movimiento Banco actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Movimiento Banco"
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Movimiento Banco actual"
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Movimiento Banco actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, txtAnio.TextChanged, cmbMes.ValueChanged, cmbNumCuenta.ValueChanged
        Actualizar()
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Nuevo()
        Try
            Dim frm As New frmMovimientoBanco
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.Anio = txtAnio.Value
            frm.Mes = cmbMes.Value
            frm.CodBan = cmbBanco.Value
            frm.NumCta = cmbNumCuenta.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListaDatos()
                If frm.type_process = "insert" Then
                    'cmbUbicacion.Value = frm.iUbicacion
                    'cbViatico.Checked = frm.iViatico
                    RowPossesion(dgvDatos, frm.IdMovimiento)
                    mostrar()
                    Actualizar()
                End If
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO MOVIMIENTO BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()

        Try
            Dim frm As New frmMovimientoBanco
            Dim lEstado As String
            'lEstado = dgvDatos.CurrentRow.Cells("DesEstado").Text
            frm.state_button = True
            frm.IdMovimiento = dgvDatos.CurrentRow.Cells("IdMovimiento").Text
            frm.editable = True 'IIf(lEstado = "Generado", True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdMovimiento)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL MOVIMIENTO BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdMovimiento").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdMovimiento").Text
        End If
        dtDatos = Nothing
        ListaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False

        Else
            iEstado = 1 'oSolicitudGastoService.ObtenerEstado(dgvDatos.CurrentRow.Cells("IdGasto").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
           
        End If

    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
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

    Private Sub cmbBanco_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.ValueChanged

        Try

            '====================================== CUENTAS ===========================================
            dtCuentas = oPlanillaService.MostrarCuentas(cmbBanco.Value).Tables(0)

            If dtCuentas.Rows.Count > 1 Or cmbBanco.Value = "" Or dtCuentas.Rows.Count = 0 Then
                dtCuentas.Rows.InsertAt(getRowTodos(dtCuentas), 0)
            End If
            cmbNumCuenta.DataSource = dtCuentas
            cmbNumCuenta.DropDownList.DataMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.DisplayMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.ValueMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.Columns(0).DataMember = dtCuentas.Columns("NumCta").ToString
            cmbNumCuenta.DropDownList.Columns(1).DataMember = dtCuentas.Columns("CodMon").ToString
            cmbNumCuenta.SelectedIndex = 0
            dtCuentas = Nothing
            ListaDatos()


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR LOS NUMEROS DE CUENTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        If ValidaCodigoSeleccionado() Then
            Dim frm As New frmMovimientoBancos_Imprimir
            Dim registro As New MovimientoBancosService.MovimientoBancos
            registro = oMovimientoBancosService.Obtener(toNumber(dgvDatos.CurrentRow.Cells("IdMovimiento").Value))
            frm.IdMovimiento = toNumber(dgvDatos.CurrentRow.Cells("IdMovimiento").Value)        
            frm.Periodo = dgvDatos.CurrentRow.Cells("Periodo").Value
            frm.Mes = dgvDatos.CurrentRow.Cells("Mes").Value
            frm.CodBan = dgvDatos.CurrentRow.Cells("CodBan").Value
            frm.NumCta = dgvDatos.CurrentRow.Cells("NumCta").Value
            frm.ShowDialog()
        End If
    End Sub   

    Private Sub biConciliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConciliar.Click

        Try
            Dim frm As New frmMovimientoBanco_Conciliar

            frm.IdMovimiento = toNumber(dgvDatos.CurrentRow.Cells("IdMovimiento").Value)
            frm.Periodo = dgvDatos.CurrentRow.Cells("Periodo").Value
            frm.Mes = dgvDatos.CurrentRow.Cells("Mes").Value
            frm.CodBan = dgvDatos.CurrentRow.Cells("CodBan").Value
            frm.NumCta = dgvDatos.CurrentRow.Cells("NumCta").Value
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class