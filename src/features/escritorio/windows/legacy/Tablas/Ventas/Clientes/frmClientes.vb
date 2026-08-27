Public Class frmClientes

    Private oMaestro As New MaestroService.MaestroClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtSectores As DataTable
    Private dtTiposClientes As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtDesCli.KeyPress _
                      , cmbCodSec.KeyPress _
                      , cmbIdTipoCliente.KeyPress _
                      , txtRucCli.KeyPress _
                      , txtDniCli.KeyPress _
                      , txtIdCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtDesCli.KeyPress _
                      , cmbCodSec.KeyPress _
                      , cmbIdTipoCliente.KeyPress _
                      , txtRucCli.KeyPress _
                      , txtDniCli.KeyPress _
                      , txtIdCliente.KeyPress _
                      , btnBuscar.KeyPress, dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles txtIdCliente.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdCliente").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 68)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestro) = False Then
                oMaestro.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String)
        state_Search = False
        If type_process = "update" Or type_process = "insert" Then
            txtDesCli.Text = ""
            cmbCodSec.Value = ""
            cmbIdTipoCliente.Value = 0
            txtRucCli.Text = ""
            txtDniCli.Text = ""
            txtIdCliente.Text = codigoCampo
        End If
        state_Search = True
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            miActualizar.Enabled = False
            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False

            biactualizar.Enabled = False
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
        Else

            miActualizar.Enabled = True
            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True

            biactualizar.Enabled = True
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True

        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmCliente
            frm.state_button = True
            frm.btnGuardar.Enabled = False
            frm.btnDeshacer.Enabled = False
            'frm.txtIdCliente.Text = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.Text = "CLIENTE " + Chr(34) + dgvDatos.CurrentRow.Cells("DesCli").Text + Chr(34)
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.lblEstado.Visible = True
            frm.cmbEstado.Visible = True
            frm.txtLimitecredito.Visible = True
            frm.lbllimitecredito.Visible = True
            frm.cmbMoneda.Visible = True
            frm.gbcredito.Visible = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing

                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtIdCliente.Text.Trim)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.txtIdCliente.Text.Trim)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdCliente").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New ClienteService.Cliente
                registro.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
                estado_process = oClienteService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                Dim registro As New ClienteService.Cliente
                Dim sector As New ClienteService.SectorCliente
                Dim tipoCliente As New ClienteService.TipoCliente

                registro.IdCliente = toNumber(txtIdCliente.Text)
                registro.DesCli = toBlank(txtDesCli.Text)
                sector.CodSec = toBlank(cmbCodSec.Value)
                registro.SectorCliente = sector
                tipoCliente.IdTipoCliente = toNumber(cmbIdTipoCliente.Value)
                registro.TipoCliente = tipoCliente
                registro.RucCli = toBlank(txtRucCli.Text)
                registro.DniCli = toBlank(txtDniCli.Text)


                dtDatos = oClienteService.Filtrar(Session.sCodEmp, registro).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmCliente
            frm.state_button = False
            frm.IdCliente = 0
            frm.btnEditar.Enabled = False
            frm.btnCancelar.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtIdCliente.Text.Trim)
                limpiaOpcionesBusqueda("insert", frm.IdCliente)
                listaDatos()
                If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, dtDatos, "IdCliente", frm.txtIdCliente.Text.Trim)
                    RowPossesion(dgvDatos, frm.IdCliente)
                    mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCliente").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Public Sub imprimir()
        If ValidaCodigoSeleccionado() Then

        End If
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= SECTORES ================================================
            dtSectores = oMaestro.MostrarSectorCliente.Tables(0)
            dtSectores.Rows.InsertAt(getRowTodos(dtSectores), 0)
            cmbCodSec.DataSource = dtSectores
            cmbCodSec.DropDownList.DataMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.DropDownList.DisplayMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.DropDownList.ValueMember = dtSectores.Columns("CodSec").ToString
            cmbCodSec.DropDownList.Columns(0).DataMember = dtSectores.Columns("CodSec").ToString
            cmbCodSec.DropDownList.Columns(1).DataMember = dtSectores.Columns("DesSec").ToString
            cmbCodSec.SelectedIndex = 0
            dtSectores = Nothing
            '======================================= TIPOS DE CLIENTE ================================================
            dtTiposClientes = oMaestro.MostrarTipoCliente.Tables(0)
            dtTiposClientes.Rows.InsertAt(getRowTodos(dtTiposClientes), 0)
            cmbIdTipoCliente.DataSource = dtTiposClientes
            cmbIdTipoCliente.DropDownList.DataMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.DropDownList.DisplayMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.DropDownList.ValueMember = dtTiposClientes.Columns("IdTipoCliente").ToString
            cmbIdTipoCliente.DropDownList.Columns(0).DataMember = dtTiposClientes.Columns("IdTipoCliente").ToString
            cmbIdTipoCliente.DropDownList.Columns(1).DataMember = dtTiposClientes.Columns("DesTipoCli").ToString
            cmbIdTipoCliente.SelectedIndex = 0
            dtTiposClientes = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtDesCli.TextChanged
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                  cmbCodSec.ValueChanged _
                , cmbIdTipoCliente.ValueChanged
        listaDatos()
    End Sub

    
    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        actualizar()

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        imprimir()

    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        imprimir()

    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.Dispose()
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Cliente."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Cliente Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Cliente Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Clientes del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Datos Cliente ."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, biImprimir.MouseLeave, _
                                    biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, _
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biSunat_Click(sender As Object, e As EventArgs) Handles biSunat.Click, miConsultaSunat.Click

        Try
            Dim frm As New frmAgregarClienteSunat
            frm.IdCliente = 0
            frm.tipoBusqueda = 1
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtIdCliente.Text.Trim)
                limpiaOpcionesBusqueda("insert", frm.IdCliente)
                listaDatos()
                RowPossesion(dgvDatos, frm.IdCliente)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class