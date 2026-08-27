Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmEmbarques

    '=========================== Servicios ====================================
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================== Declaración de Variables ==============================
    Public state_Search As Boolean
    Private dtDatos As DataTable
    Private dtMedios As DataTable
    Private dtEstados As DataTable
    Public iEstado As Integer

    Private Sub frmEmbarques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 88)
            '/*************************************************************************************/

            Dim estilo As New Estilo
            estilo.CargaEstiloGrid(dgvDatos)
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

            llenarCombos()
            cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
            cbFecFinal.Value = Today
            state_Search = True
            listaDatos()
            dgvDatos.Select()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub frmHorasMotor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             cbFecInicio.KeyPress _
                           , cbFecFinal.KeyPress _
                           , cmbMedio.KeyPress _
                           , txtCodEmbarque.KeyPress _
                           , cmbEstado.KeyPress
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
    Private Sub frmEmbarques_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEmbarqueService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oEmbarqueService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmEmbarques_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                biGenerar.Enabled = False
                biBajarNivel.Enabled = False
                biEstado.Enabled = False

                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miGenerar.Enabled = False
                miBajarNivel.Enabled = False
                miEstado.Enabled = False
            Else
                iEstado = oEmbarqueService.ObtenerEstado(toBlank(dgvDatos.CurrentRow.Cells("CodEmbarque").Text))
                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = IIf(iEstado = 1, True, False)
                biGenerar.Enabled = IIf(iEstado = 1, True, False)
                biBajarNivel.Enabled = IIf((Session.CodPerfil = "28" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "06") And iEstado <> 1, True, False)
                biEstado.Enabled = True

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(iEstado = 1, True, False)
                miGenerar.Enabled = IIf(iEstado = 1, True, False)
                miBajarNivel.Enabled = IIf((Session.CodPerfil = "28" Or Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "06") And iEstado <> 1, True, False)
                miEstado.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodEmbarque").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmEmbarque_Nuevo            
            frm.state_button = True
            frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Text
            iEstado = oEmbarqueService.ObtenerEstado(toBlank(dgvDatos.CurrentRow.Cells("CodEmbarque").Value))
            frm.editable = IIf(iEstado = 1, True, False)
            frm.edicion = False            
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodEmbarque)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Embarque seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oEmbarqueService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("CodEmbarque").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmEmbarque_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True            
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.CodEmbarque)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= MEDIOS ================================================
            dtMedios = New DataTable
            dtMedios.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMedios.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtMedios.Rows.Add(New Object() {"", "(Todos)"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"A", "Aéreo"}) ', New DateTime(2008, 2, 5)
            dtMedios.Rows.Add(New Object() {"M", "Marinos"})
            dtMedios.Rows.Add(New Object() {"O", "Otros"})

            cmbMedio.DataSource = dtMedios
            cmbMedio.DropDownList.DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.DisplayMember = dtMedios.Columns("nombre").ToString
            cmbMedio.DropDownList.ValueMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(0).DataMember = dtMedios.Columns("codigo").ToString
            cmbMedio.DropDownList.Columns(1).DataMember = dtMedios.Columns("nombre").ToString
            cmbMedio.SelectedIndex = 0
            dtMedios = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oEmbarqueService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

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
                dtDatos = oEmbarqueService.Filtrar(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, toBlank(cmbMedio.Value), txtCodEmbarque.Text, toNumber(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos                
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged, _
                                                                                                                                              cmbMedio.ValueChanged, txtCodEmbarque.TextChanged, cmbEstado.ValueChanged
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
            codigo = dgvDatos.CurrentRow.Cells("CodEmbarque").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
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

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            If ValidaCodigoSeleccionado() Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptEmbarque
                dtReporte = oEmbarqueService.Imprimir(toBlank(dgvDatos.CurrentRow.Cells("CodEmbarque").Value)).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No existen datos a imprimir ")
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

                    forma.Text = "Reporte de Embarque"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR REPORTE: " + ex.Message, MsgBoxStyle.Exclamation)
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
        sslError.Text = "Imprimir Embarque actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Embarque."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Embarque actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Embarque actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        Try
            If MsgBox("¿Está seguro de GENERAR la Solicitud de Gastos del Embarque N°" & dgvDatos.CurrentRow.Cells("CodEmbarque").Value.ToString & "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Integer
                estado_process = oEmbarqueService.GenerarSolicitudGasto(toBlank(dgvDatos.CurrentRow.Cells("CodEmbarque").Value), Today, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process > 0 Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se  Generó la Solicitud de Gastos Nº " + estado_process.ToString)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biArchivo_Click(sender As Object, e As EventArgs) Handles biArchivo.Click, miArchivo.Click
        Try
            Dim frm As New frmEmbarque_Archivos
            frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Value
            'frm.CodEmbarque = dgvDatos.CurrentRow.Cells("NumOrden").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DEL EMBARQUE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGastos_Click(sender As Object, e As EventArgs) Handles biGastos.Click, miGastos.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmEmbarque_GastosImportacion
                frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Value
                frm.Text = "Gastos de Importación del Embarque : " & dgvDatos.CurrentRow.Cells("CodEmbarque").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnValorizar_Click(sender As Object, e As EventArgs) Handles btnValorizar.Click, miValorizar.Click
        Try
            Dim frm As New frmEmbarqueValorizar
            frm.txtCodEmbarque.Text = dgvDatos.CurrentRow.Cells("CodEmbarque").Value
            frm.txtNumRegistro.Text = dgvDatos.CurrentRow.Cells("NroIng").Value
            frm.listaDatos()
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If

        Catch ex As Exception
            MsgBox("Error al VALORIZAR F/I MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biBajarNivel_Click(sender As Object, e As EventArgs) Handles biBajarNivel.Click, miBajarNivel.Click

        Try
            Dim frm As New frmEmbarque_BajarNivel

            frm.Text = "Embarque - Bajar de Nivel N° : " + dgvDatos.CurrentRow.Cells("CodEmbarque").Value
            frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If

        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEstado_Click(sender As Object, e As EventArgs) Handles biEstado.Click, miEstado.Click

        Try
            Dim frm As New frmEmbarque_Estados

            frm.CodEmbarque = dgvDatos.CurrentRow.Cells("CodEmbarque").Text
            frm.Text = "Estados del Embarque Nº : " + dgvDatos.CurrentRow.Cells("CodEmbarque").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class