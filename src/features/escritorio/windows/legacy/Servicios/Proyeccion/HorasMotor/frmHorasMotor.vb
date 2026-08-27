Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmHorasMotor

    '=========================== Servicios ====================================
    Private oMotorService As New MotorService.MotorServiceClient
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================== Declaración de Variables ==============================
    Public state_Search As Boolean
    Private dtDatos As DataTable
    Private dtUbicacion As DataTable
    Private dtTipoPlanMantenimiento As DataTable
    Private dtTipoEquipo As DataTable
    Private dtInsertarMasivo As DataTable


    Private UbicPers As String
    Private DirFile As String
    Private fileExt As String
    Private DtLimite As Integer

    Private Sub frmHorasMotor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 247)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        ObtenerCodUbicacion()
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub frmHorasMotor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtCodMer.KeyPress _
                           , cmbUbicacion.KeyPress _
                           , cmbTipoEquipo.KeyPress _
                           , cmbTipoPlanMant.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub ObtenerCodUbicacion()

        UbicPers = oMotorService.ObtenerCodUbicacion(Session.sCodUsu)

        If UbicPers = "" Then
            cmbUbicacion.SelectedIndex = 0
        Else
            cmbUbicacion.Value = UbicPers
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
    Private Sub frmHorasMotor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMotorService.Close()
            oHorasMotorService.Close()
            oJobService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oMotorService.Abort()
            oHorasMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMotorService.Abort()
            oHorasMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmHorasMotor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If row.Cells("NumSerie").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmHoraMotor
            frm.state_button = True
            frm.codMer = dgvDatos.CurrentRow.Cells("NumSerie").Value
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.codMer)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LAS HRS DE RECORRIDO DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            Dim dtMantenimiento As DataTable
            dtMantenimiento = oHorasMotorService.MostrarMantenimiento(toBlank(dgvDatos.CurrentRow.Cells("NumSerie").Value)).Tables(0)

            If dtMantenimiento.Rows.Count > 0 Then
                MsgBox("El registro tiene mantenimientos ingresados, verifique!!!", MsgBoxStyle.Information)
            Else
                cmbOpciones.Visible = False
                If MsgBox("¿Está seguro de ELIMINAR las Horas de recorrido del equipo seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oHorasMotorService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("NumSerie").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LAS HRS DE RECORRIDO DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmHoraMotor
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.iCodOfi = cmbUbicacion.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.codMer)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVAS HRS DE MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '===================================== TIPO EQUIPO ==============================================
            dtTipoEquipo = oMotorService.MostrarTipoEquipo().Tables(0)
            dtTipoEquipo.Rows.InsertAt(getRowTodos(dtTipoEquipo), 0)
            cmbTipoEquipo.DataSource = dtTipoEquipo
            cmbTipoEquipo.DropDownList.DataMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.DropDownList.DisplayMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.DropDownList.ValueMember = dtTipoEquipo.Columns("IdTipo").ToString
            cmbTipoEquipo.DropDownList.Columns(0).DataMember = dtTipoEquipo.Columns("IdTipo").ToString
            cmbTipoEquipo.DropDownList.Columns(1).DataMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.SelectedIndex = 0
            dtTipoEquipo = Nothing

            '================================= TIPO PLAN MANTENIMIENTO =======================================
            dtTipoPlanMantenimiento = oHorasMotorService.MostrarTipoPlanMantenimiento().Tables(0)
            dtTipoPlanMantenimiento.Rows.InsertAt(getRowTodos(dtTipoPlanMantenimiento), 0)
            cmbTipoPlanMant.DataSource = dtTipoPlanMantenimiento
            cmbTipoPlanMant.DropDownList.DataMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.DropDownList.DisplayMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.DropDownList.ValueMember = dtTipoPlanMantenimiento.Columns("IdPlan").ToString
            cmbTipoPlanMant.DropDownList.Columns(0).DataMember = dtTipoPlanMantenimiento.Columns("IdPlan").ToString
            cmbTipoPlanMant.DropDownList.Columns(1).DataMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.SelectedIndex = 0
            dtTipoPlanMantenimiento = Nothing

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
                dtDatos = oHorasMotorService.Filtrar(toBlank(txtNomEquipo.Text), toBlank(txtCodMer.Text), toBlank(cmbUbicacion.Value), toNumber(cmbTipoPlanMant.Value), toNumber(cmbTipoEquipo.Value), cbActivo.Checked).Tables(0)
                dgvDatos.DataSource = dtDatos
                dgvDatosTemp.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCodMer.TextChanged, cmbUbicacion.ValueChanged, cmbTipoEquipo.ValueChanged, cmbTipoPlanMant.ValueChanged, txtNomEquipo.TextChanged, cbActivo.CheckedChanged
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
            codigo = dgvDatos.CurrentRow.Cells("NumSerie").Text
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
                'ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                '    MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                       biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                       biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                       biEliminar.MouseLeave, miEliminar.MouseLeave, _
                       biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Horas de recorrido de Motor actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Horas de recorrido de Motor."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Horas de recorrido de Motor actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Horas de recorrido Motor actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biDescargarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDescargarExcel.Click, miDescargarExcel.Click
        DescargarFormatoExcel()
    End Sub

    Private Sub DescargarFormatoExcel()

        Try
            Dim row2 As DataRow

            Dim dtDatosTemp As DataTable

            Dim dtExcel As New DataTable("tabla2")

            dtExcel.Columns.Add(New DataColumn("NumSerie", Type.GetType("System.String")))
            dtExcel.Columns.Add(New DataColumn("Horas Totales", Type.GetType("System.Double")))
            dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtExcel.Rows.Add(New Object() {"", "0.00", ""})

            dtDatosTemp = dtExcel.Copy
            dtDatosTemp.Clear()

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatosTemp.Rows(i)

                row2 = dtDatosTemp.NewRow

                row2(0) = Trim(row.Cells("NumSerie").Value)
                row2(1) = "0"
                row2(2) = Trim(row.Cells("Observacion").Value)


                dtDatosTemp.Rows.Add(row2)

            Next
            'dgvDatos.DataSource = dtDatosTemp
            DataGridView2.DataSource = dtDatosTemp
            'DataGridView2.DataSource = dtExcel

            Dim Export As Boolean

            Export = ExportarExcel(DataGridView2)

            If Export Then
                MsgBox("Se descargo el excel correctamente")
            End If

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImportarExcel.Click, miImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()

        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") And (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            CreacionTable()
            If DtLimite >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub CreacionTable()

        Try
            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("NumSerie", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("TotalHoras", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"", "0.00", ""})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If IsDBNull(DataGridView1.Item(1, i).Value) = False Then

                    row = dtInsertarMasivo.NewRow

                    row(0) = Trim(DataGridView1.Item(0, i).Value)
                    row(1) = CDbl(DataGridView1.Item(1, i).Value)
                    row(2) = Trim(IIf(IsDBNull(DataGridView1.Item(2, i).Value), "", DataGridView1.Item(2, i).Value))

                    dtInsertarMasivo.Rows.Add(row)

                End If
            Next

            DtLimite = dtInsertarMasivo.Rows.Count
            'DataGridView1.DataSource = Nothing

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub InsertarMasivo()

        Try
            Dim estado_process As Boolean

            estado_process = oHorasMotorService.ActualizarHorasMasivas(dtInsertarMasivo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process = True Then
                MsgBox("Se Actualizaron las horas correctamente", MsgBoxStyle.Information)
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LAS HORAS MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub btnNumSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumSerie.Click
        Try
            Dim frm As New frmBuscarMotor

            frm.UbicPers = cmbUbicacion.Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodMer.Text = frm.codigo
                Else
                    txtCodMer.Text = ""
                    txtCodMer.Focus()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biIngresoMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresoMasivo.Click
        If cmbUbicacion.SelectedIndex = 0 Then
            MsgBox("Debe seleccionar una Ubicación.", MsgBoxStyle.Information)
        Else
            IngresoMasivo()
        End If
    End Sub

    Private Sub IngresoMasivo()

        Dim frm As New frmHorasMotor_IngresoMasivo

        frm.CodUbicacion = cmbUbicacion.Value
        frm.DesUbicacion = cmbUbicacion.Text
        frm.TipoMantenimiento = cmbTipoPlanMant.Value
        frm.TipoEquipo = cmbTipoEquipo.Value
        frm.Activo = cbActivo.Checked

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()

        End If

    End Sub

    Private Sub biHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biHistorial.Click

        Dim frm As New frmHorasMotor_Historial

        frm.NumSerie = toBlank(dgvDatos.CurrentRow.Cells("NumSerie").Value)

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then


        End If

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptImpHorasMotor

            'Dim registro As CotizacionServicioService.CotizacionServicio
            Dim dtDatos As DataTable

            dtDatos = oHorasMotorService.Imprimir(dgvDatos.CurrentRow.Cells("NumSerie").Value).Tables(0)

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte
            ' Validar Usuario - Exportar Excel
            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            forma.crvReportes.DisplayGroupTree = False
            'forma.crvReportes.RefreshReport = False

            'reporte.SetParameterValue("pAnio", txtanio.Text)
            'reporte.SetParameterValue("pCliente", txtBuscarCliente.Text)
            'reporte.SetParameterValue("pTipo", cmbTipo.Text)
            'reporte.SetParameterValue("pEstado", cmbEstados.Text)
            'reporte.SetParameterValue("pLoc", cmbOficinas.Text)

            forma.Text = "Reporte de Horas Motor"
            forma.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class