Imports System.ServiceModel
Public Class frmProveedores

    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtRubro As DataTable
    Private state_Search As Boolean

    Private Sub frmProveedores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProveedorService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oProveedorService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oProveedorService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()            
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
            End If
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdProveedor").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmProveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 133)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
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

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String)
        state_Search = False
        If type_process = "update" Or type_process = "insert" Then
            txtDesProv.Text = ""
            cmbRubro.Value = 0
            txtRucProv.Text = ""
            txtDniProv.Text = ""
            txtIdProveedor.Text = codigoCampo
        End If
        state_Search = True
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmProveedor
            Dim IdProveedorPos As Integer
            frm.state_button = True
            frm.btnGuardar.Enabled = False
            frm.btnDeshacer.Enabled = False
            frm.IdProveedor = dgvDatos.CurrentRow.Cells("IdProveedor").Text
            IdProveedorPos = CInt(dgvDatos.CurrentRow.Cells("IdProveedor").Value)
            frm.lblEstado.Visible = True
            frm.cmbEstado.Visible = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtIdProveedor.Text.Trim)
                    listaDatos()
                    RowPossesion(dgvDatos, IdProveedorPos)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
                listaDatos()
            End If
            listaDatos()
            RowPossesion(dgvDatos, IdProveedorPos)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Proveedor con código = " + dgvDatos.CurrentRow.Cells("IdProveedor").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oProveedorService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdProveedor").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PROVEEDOR :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oProveedorService.Filtrar(Session.sCodEmp, utils.toNumber(txtIdProveedor.Text), txtDesProv.Text, txtRucProv.Text, txtDniProv.Text, cmbRubro.Value).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            frm.IdProveedor = 0
            frm.btnEditar.Enabled = False
            frm.btnCancelar.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing        
                limpiaOpcionesBusqueda("insert", frm.IdProveedor)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdProveedor)
                    mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdProveedor").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Public Sub imprimir()
        If ValidaCodigoSeleccionado() Then

            'IMPRIMIR

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
            ElseIf dgvDatos.CurrentRow.Cells("IdProveedor").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
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
    Private Sub llenarCombos()
        Try
            '======================================= SECTORES ================================================
            dtRubro = oProveedorService.MostrarRubros.Tables(0)
            dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("NomRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("NomRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("NomRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubro = Nothing
          
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR LOS COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtDesProv.TextChanged, cmbRubro.ValueChanged, txtDniProv.TextChanged, txtIdProveedor.TextChanged, txtRucProv.TextChanged
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biactualizar.Click
        actualizar()
    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        imprimir()
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Proveedor."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Proveedor Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Proveedor Actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Proveedores del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Datos Proveedor."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, biImprimir.MouseLeave, _
                                    biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, _
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biConsultaSunat_Click(sender As Object, e As EventArgs) Handles biConsultaSunat.Click, miConsultaSunat.Click
        Try
            Dim frm As New frmAgregarClienteSunat
            frm.IdProveedor = 0
            frm.tipoBusqueda = 2
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                limpiaOpcionesBusqueda("insert", frm.IdProveedor)
                listaDatos()
                RowPossesion(dgvDatos, frm.IdProveedor)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class