Imports System.ServiceModel
Public Class frmTipo_Cambio

    '=========================== Servicios ===================================================
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Private dtMonedas As DataTable

    '==========================Evento Load===================================================
    Private Sub frmTipo_Cambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 307)
            '/*************************************************************************************/

            Dim estilo As New Estilo
            estilo.CargaEstiloGrid(dgvDatos)
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            llenarCombos()

            Dim Mes, Anio, meses As Integer
            Dim Fecha As Date

            Fecha = Today
            meses = Month(Today)
            If meses = 1 Then
                Mes = Month(Today)
                Anio = Year(Today)
            Else
                Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
                Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
            End If
            cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
            cbFecFinal.Value = Fecha

            cmbMoneda.Value = "NS"
            state_Search = True
            listaDatos()
            dgvDatos.Select()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                          cmbMoneda.KeyPress
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

    '==========================Evento FormClosed=============================================
    Private Sub frmTipo_Cambio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmIngresosPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal moneda As String, ByVal fecha As Date)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodMon").Value = moneda And row.Cells("Fecha").Value = fecha Then
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

            ''======================================= MONEDAS ================================================
            'dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            'cmbMoneda.DataSource = dtMonedas
            'cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            'cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            'cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            'dtMonedas = Nothing

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
                dtDatos = oSeguridadService.FiltrarTipoCambio(cbFecInicio.Value, cbFecFinal.Value).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged
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
        Dim moneda As String = ""
        Dim fecha As New Date
        If dgvDatos.RowCount > 0 Then
            moneda = dgvDatos.CurrentRow.Cells("CodMon").Text
            fecha = dgvDatos.CurrentRow.Cells("Fecha").Value
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And moneda.Trim.Length > 0 Then
            RowPossesion(dgvDatos, moneda, fecha)
        End If
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmTipo_Cambio_Nuevo
                frm.state_button = False

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.moneda, frm.fecha)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO TIPO DE CAMBIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            'cmbOpciones.Visible = False
            'If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
            '    Dim estado_process As Boolean
            '    estado_process = oIngresoPersonalService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdIngreso").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            '    If estado_process = True Then
            '        dtDatos = Nothing
            '        listaDatos()
            '        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
            '    Else
            '        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            '    End If
            'Else
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR TIPO DE CAMBIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmTipo_Cambio_Nuevo
            frm.state_button = True
            frm.moneda = dgvDatos.CurrentRow.Cells("CodMon").Text
            frm.fecha = CDate(dgvDatos.CurrentRow.Cells("Fecha").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.moneda, frm.fecha)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.moneda, frm.fecha)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR TIPO DE CAMBIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                        biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave,
                        biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave,
                        biEliminar.MouseLeave, miEliminar.MouseLeave,
                        biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Listado de Tipos de Cambio."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Tipo de Cambio."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Tipo de Cambio actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Tipo de Cambio actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
End Class