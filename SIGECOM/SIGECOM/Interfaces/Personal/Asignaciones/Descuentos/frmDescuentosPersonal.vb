Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmDescuentosPersonal

    '=========================== Servicios ===================================================
    Private oDescuentoPersonalService As New DescuentoPersonalService.DescuentoPersonalServiceClient    
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private dtDatos As New DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable
    Private dtRubroDscto As DataTable

    Private DirFile As String
    Private fileExt As String
    Private dtDatosExcel As DataTable
    Private OpenFileDialog1 As New System.Windows.Forms.OpenFileDialog

    '==========================Evento Load===================================================
    Private Sub frmDescuentosPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            '/************************** Insertar Opciones de Session ************************/
            oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 213)
            '/*************************************************************************************/

            chkColaborador.Enabled = False
            pboxLimpiarColaborador.Enabled = True
            ToolTip1.SetToolTip(chkColaborador, "Limpiar Colaborador")
            ToolTip1.SetToolTip(pboxLimpiarColaborador, "Limpiar Colaborador")

            Dim estilo As New Estilo
            estilo.CargaEstiloGrid(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            llenarCombos()

            txtanio.Value = Today.Year
            state_Search = True
            listaDatos()
            dgvDatos.Select()
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                          txtanio.KeyPress _
                                        , cmbCodArea.KeyPress _
                                        , cmbCentroCosto.KeyPress _
                                        , cmbDescuento.KeyPress _
                                        , txtColaborador.KeyPress
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
    Private Sub frmDescuentosPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oDescuentoPersonalService.Close()            
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oDescuentoPersonalService.Abort()            
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oDescuentoPersonalService.Abort()            
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmDescuentosPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If row.Cells("IdDescuento").Value = codigo Then
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

            '=========================================== AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            ''========================================== DESCUENTO =============================================
            dtRubroDscto = oDescuentoPersonalService.MostrarRubros(Session.sCodEmp).Tables(0)
            dtRubroDscto.Rows.InsertAt(getRowTodos(dtRubroDscto), 0)
            cmbDescuento.DataSource = dtRubroDscto
            cmbDescuento.DropDownList.DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.DisplayMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.ValueMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(0).DataMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(1).DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.SelectedIndex = 0
            dtRubroDscto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, "").Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
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
                dtDatos = oDescuentoPersonalService.Filtrar(Session.sCodEmp, txtanio.Value, cmbCodArea.Value, cmbCentroCosto.Value, toNumber(cmbDescuento.Value), IdPersona).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbDescuento.ValueChanged, cmbCentroCosto.ValueChanged, txtColaborador.TextChanged, txtanio.ValueChanged
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
            codigo = dgvDatos.CurrentRow.Cells("IdDescuento").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkColaborador.Enabled = True
            pboxLimpiarColaborador.Enabled = True
        End If
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmDescuentosPersonal_Nuevo
                frm.state_button = False

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdDescuento)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DESCUENTO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oDescuentoPersonalService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdDescuento").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            MsgBox("ERROR AL ELIMINAR DESCUENTO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmDescuentosPersonal_Nuevo
            frm.state_button = True
            frm.IdDescuento = dgvDatos.CurrentRow.Cells("IdDescuento").Text
            frm.iPagado = toBoolean(dgvDatos.CurrentRow.Cells("Pagado").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdDescuento)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdDescuento)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DESCUENTO DE PERSONAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDescuentoMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biDescuentoMasivo.Click, miDescuentoMasivo.Click
        Try
            Dim frm As New frmDescuentosPersonal_Masivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception

            MsgBox("Error al generar DESCUENTOS MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biInsertarPermisos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biInsertarPermisos.Click, miInsertarPermisos.Click
        Try
            Dim frm As New frmInsertarPermisos
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al INSERTAR PERMISOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                        biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave,
                        biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave,
                        biEliminar.MouseLeave, miEliminar.MouseLeave, biDescuentoMasivo.MouseLeave, miDescuentoMasivo.MouseLeave,
                        biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave,
                        biInsertarPermisos.MouseLeave, miInsertarPermisos.MouseLeave,
                        biFormatoExcel.MouseLeave, miFormatoExcel.MouseLeave, biImportarExcel.MouseLeave, miImportarExcel.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Descuento de Personal actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Descuento de Personal."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Descuento de Personal actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Descuento de Personal actual."
    End Sub
    Private Sub InsertarPermisos_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biInsertarPermisos.MouseEnter, miInsertarPermisos.MouseEnter
        sslError.Text = "Insertar Permisos de Personal."
    End Sub
    Private Sub DescuentoMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDescuentoMasivo.MouseEnter, miDescuentoMasivo.MouseEnter
        sslError.Text = "Descuento de Personal masivo."
    End Sub
    Private Sub IngresarCuotas_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCuotas.MouseEnter, miCuotas.MouseEnter
        sslError.Text = "Ingreso Cuotas"
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub FormatoExcel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFormatoExcel.MouseEnter, miFormatoExcel.MouseEnter
        sslError.Text = "Descargar Fomato Excel."
    End Sub
    Private Sub ImportarExcel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImportarExcel.MouseEnter, miImportarExcel.MouseEnter
        sslError.Text = "Importar Formato Excel."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub miFormatoExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFormatoExcel.Click, biFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")

        dtExcel.Columns.Add(New DataColumn("IdPersona", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("ApeNom", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("IdRubroDes", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Fecha", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Moneda", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Monto", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        'dtExcel.Rows.Add(New Object() {"0", "0", "01/01/2001", "NS", "0.01", ""})

        Dim dtTable As New DataTable
        dtTable = oPersonaService.Reporte(Session.sCodEmp, "", "", "E", True).Tables(0)
        dgvPersonal.DataSource = dtTable
        For i As Integer = 0 To dgvPersonal.RowCount - 1
            dtExcel.Rows.Add(New Object() {toBlank(dgvPersonal.Rows(i).Cells("IdPer").Value), toBlank(dgvPersonal.Rows(i).Cells("ApeNom").Value), "0", "01/01/2001", "NS", "0.01", ""})
        Next

        dgvFormatoExcel.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcel)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miImportarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miImportarExcel.Click, biImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xls") And (fileExt <> ".xlsx") Then
                MsgBox("¡Solo se aceptan archivos de Excel, tenga cuidado...!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
        End If
    End Sub

    Private Sub CargarGrilla()
        Try
            If MsgBox("¿Está seguro de IMPORTAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvImportarExcel.DataSource = GetDataExcel(DirFile, fileExt)
                Dim estado_process As Integer = 0

                If dgvImportarExcel.RowCount > 0 Then
                    For Each fila As DataGridViewRow In dgvImportarExcel.Rows

                        Dim registro As New DescuentoPersonalService.DescuentoPersonal
                        Dim Persona As New DescuentoPersonalService.Persona
                        Dim RubroDescuento As New DescuentoPersonalService.RubroDescuentoPlanilla
                        Dim Moneda As New DescuentoPersonalService.Moneda

                        registro.IdDescuento = 0
                        Persona.IdPer = toNumber(fila.Cells("IdPersona").Value)
                        registro.Persona = Persona
                        RubroDescuento.IdRubroDes = Convert.ToInt16(fila.Cells("IdRubroDes").Value)
                        registro.RubroDescuentoPlanilla = RubroDescuento
                        registro.Fecha = Convert.ToDateTime(fila.Cells("Fecha").Value)
                        Moneda.CodMon = Convert.ToString(fila.Cells("Moneda").Value)
                        registro.Moneda = Moneda
                        registro.Monto = Convert.ToDouble(fila.Cells("Monto").Value)
                        registro.Observacion = IIf(Convert.ToString(fila.Cells("Observacion").Value) = "", Nothing, Convert.ToString(fila.Cells("Observacion").Value))

                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp

                        estado_process = oDescuentoPersonalService.Insertar(registro)
                    Next

                    If estado_process > 0 Then
                        MsgBox("Se ingresó los detalles correctamente", MsgBoxStyle.Information, "Error de datos")
                        listaDatos()
                    End If
                Else
                    MsgBox("¡No existen detalles a importar...!", MsgBoxStyle.Information, "Error de datos")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCuotas_Click(sender As Object, e As EventArgs) Handles biCuotas.Click, miCuotas.Click
        Try
            Dim frm As New frmDescuentosPersonal_Cuotas
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception

            MsgBox("Error al ingresar cuotas: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biInsertarTardanza_Click(sender As Object, e As EventArgs) Handles biInsertarTardanza.Click
        Try
            Dim frm As New frmInsertarTardanza
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al INSERTAR PERMISOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class