Imports System.ServiceModel
Public Class frmUbicaciones

    '=========================== Servicios ===================================================
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private dtDatos As New DataTable

    Private dtEstante As DataTable
    Private dtNivel As DataTable
    Private dtCelda As DataTable

    Private Sub frmUbicaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
           oLocacionMercaderiaService.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
        Catch ex As CommunicationException
           oLocacionMercaderiaService.Abort()
        End Try
    End Sub

    Private Sub frmUbicaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()

        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmCargos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount < 1 Then
                biImprimir.Enabled = False
                biMostrar.Enabled = False
                biEliminar.Enabled = False

                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
            Else
                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = True

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodUbicacion").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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

            '======================================= ESTANTE =============================================
            dtEstante = oLocacionMercaderiaService.MostrarEstante().Tables(0)
            'dtEstante.Rows.InsertAt(getRowTodos(dtEstante), 0)
            cmbEstante.DataSource = dtEstante
            cmbEstante.DropDownList.DataMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.DropDownList.DisplayMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.DropDownList.ValueMember = dtEstante.Columns("CodEstante").ToString
            cmbEstante.DropDownList.Columns(0).DataMember = dtEstante.Columns("CodEstante").ToString
            cmbEstante.DropDownList.Columns(1).DataMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.SelectedIndex = 0
            dtEstante = Nothing


            '========================================= NIVEL =============================================
            dtNivel = New DataTable
            dtNivel.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtNivel.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtNivel.Rows.Add(New Object() {"", "Todos"}) ', New DateTime(2008, 2, 5)
            dtNivel.Rows.Add(New Object() {"A", "A"})
            dtNivel.Rows.Add(New Object() {"B", "B"})
            dtNivel.Rows.Add(New Object() {"C", "C"})
            dtNivel.Rows.Add(New Object() {"D", "D"})
            dtNivel.Rows.Add(New Object() {"E", "E"})
            dtNivel.Rows.Add(New Object() {"F", "F"})
            dtNivel.Rows.Add(New Object() {"G", "G"})
            dtNivel.Rows.Add(New Object() {"H", "H"})
            dtNivel.Rows.Add(New Object() {"M", "M"})
            dtNivel.Rows.Add(New Object() {"P", "P"})
            dtNivel.Rows.Add(New Object() {"S", "S"})
            dtNivel.Rows.Add(New Object() {"T", "T"})

            cmbNivel.DataSource = dtNivel
            cmbNivel.DropDownList.DataMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.DisplayMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.ValueMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.Columns(0).DataMember = dtNivel.Columns("codigo").ToString
            cmbNivel.DropDownList.Columns(1).DataMember = dtNivel.Columns("nombre").ToString
            cmbNivel.SelectedIndex = 0
            dtNivel = Nothing


            '========================================= CELDA =============================================
            dtCelda = New DataTable
            dtCelda.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtCelda.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtCelda.Rows.Add(New Object() {"", "Todos"}) ', New DateTime(2008, 2, 5)
            dtCelda.Rows.Add(New Object() {"1", "1"})
            dtCelda.Rows.Add(New Object() {"2", "2"})
            dtCelda.Rows.Add(New Object() {"3", "3"})
            dtCelda.Rows.Add(New Object() {"4", "4"})
            dtCelda.Rows.Add(New Object() {"5", "5"})
            dtCelda.Rows.Add(New Object() {"6", "6"})
            dtCelda.Rows.Add(New Object() {"7", "7"})
            dtCelda.Rows.Add(New Object() {"8", "8"})
            dtCelda.Rows.Add(New Object() {"9", "9"})
            dtCelda.Rows.Add(New Object() {"10", "10"})
            dtCelda.Rows.Add(New Object() {"11", "11"})
            dtCelda.Rows.Add(New Object() {"12", "12"})
            dtCelda.Rows.Add(New Object() {"13", "13"})
            dtCelda.Rows.Add(New Object() {"14", "14"})
            dtCelda.Rows.Add(New Object() {"15", "15"})
            dtCelda.Rows.Add(New Object() {"16", "16"})
            dtCelda.Rows.Add(New Object() {"17", "17"})
            dtCelda.Rows.Add(New Object() {"18", "18"})
            dtCelda.Rows.Add(New Object() {"21", "21"})
            dtCelda.Rows.Add(New Object() {"22", "22"})
            dtCelda.Rows.Add(New Object() {"23", "23"})
            dtCelda.Rows.Add(New Object() {"24", "24"})
            dtCelda.Rows.Add(New Object() {"25", "25"})
            dtCelda.Rows.Add(New Object() {"26", "26"})
            dtCelda.Rows.Add(New Object() {"27", "27"})
            dtCelda.Rows.Add(New Object() {"29", "29"})
            dtCelda.Rows.Add(New Object() {"30", "30"})
            dtCelda.Rows.Add(New Object() {"31", "31"})

            cmbCelda.DataSource = dtCelda
            cmbCelda.DropDownList.DataMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.DisplayMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.ValueMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.Columns(0).DataMember = dtCelda.Columns("codigo").ToString
            cmbCelda.DropDownList.Columns(1).DataMember = dtCelda.Columns("nombre").ToString
            cmbCelda.SelectedIndex = 0
            dtCelda = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oLocacionMercaderiaService.FiltrarUbicacion(Session.sCodEmp, toBlank(cmbEstante.Value), IIf(cmbNivel.SelectedIndex = 0, "", cmbNivel.Value), _
                                                                                                IIf(cmbCelda.SelectedIndex = 0, "", cmbCelda.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos                
                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbEstante.ValueChanged, cmbNivel.ValueChanged, cmbCelda.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
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
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodUbicacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmUbicacion
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.CodUbicacion)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA UBICACIÓN DE MERCADERÍA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oLocacionMercaderiaService.BorrarUbicacion(toBlank(dgvDatos.CurrentRow.Cells("CodUbicacion").Value), Session.sCodEmp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA UBICACIÓN DE MERCADERÍA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmUbicacion
            frm.state_button = True
            frm.CodUbicacion = dgvDatos.CurrentRow.Cells("CodUbicacion").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.CodUbicacion)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.CodUbicacion)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA UBICACIÓN DE MERCADERÍA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                        biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                        biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                        biEliminar.MouseLeave, miEliminar.MouseLeave, _
                        biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Ubicación de Mercadería actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Ubicación de Mercadería."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Ubicación de Mercadería actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Ubicación de Mercadería actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

End Class