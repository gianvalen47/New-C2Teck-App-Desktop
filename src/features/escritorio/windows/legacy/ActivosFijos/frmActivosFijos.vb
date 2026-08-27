Imports System.ServiceModel
Public Class frmActivosFijos

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private empresaUsuario As New EmpresaUsuarioService.EmpresaUsuario

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Private CodActivo As String
    Private dtUbicacion As DataTable
    Private dtEstados As DataTable
    Private dtTipoActivo As DataTable
    Private dtDatos As New DataTable
    Private iEstado As Integer
    Public IdPersona As Integer
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable


    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer

    '===============================Evento Load=============================================
    Private Sub frmActivosFijos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, )
        '/*************************************************************************************/

        chkColaborador.Enabled = False
        pboxLimpiarColaborador.Enabled = True
        ToolTip1.SetToolTip(chkColaborador, "Limpiar Solicitante")
        ToolTip1.SetToolTip(pboxLimpiarColaborador, "Limpiar Solicitante")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = False
        llenarcombos()
        poCargarArea()
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub poCargarArea()
        Try
            empresaUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
            cmbEstado.SelectedIndex = 0
            If Session.CodPerfil = "13" Then
                cmbCodArea.SelectedIndex = 0
            Else
                If empresaUsuario.Persona.CentroCosto.Area.CodArea Is Nothing Then
                    cmbCodArea.SelectedIndex = 0 'oUsuario.Persona.CentroCosto.Area.CodArea
                Else
                    cmbCodArea.Value = empresaUsuario.Persona.CentroCosto.Area.CodArea
                End If
                'cmbCodArea.Value = empresaUsuario.Persona.CentroCosto.Area.CodArea    'oUsuario.Persona.CentroCosto.Area.CodArea
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtSerie.KeyPress _
                            , cmbUbicacion.KeyPress _
                            , txtCodActivo.KeyPress _
                            , txtCodMaleta.KeyPress _
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
    Private Sub frmActivosFijos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oActivoFijoService.Close()
            oSeguridadService.Close()
            oEmpresaUsuario.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
            oSeguridadService.Abort()
            oEmpresaUsuario.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
            oSeguridadService.Abort()
            oEmpresaUsuario.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown==============================================
    Private Sub frmActivosFijos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biEliminarMasivo.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True
            biEliminarMasivo.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True
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

    Private Sub llenarcombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing


            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oActivoFijoService.MostrarUbicacion().Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("IdUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oActivoFijoService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            '===================================== TIPO ACTIVO ===============================================
            dtTipoActivo = oActivoFijoService.MostrarTipo().Tables(0)
            dtTipoActivo.Rows.InsertAt(getRowTodos(dtTipoActivo), 0)
            cmbTipoActivo.DataSource = dtTipoActivo
            cmbTipoActivo.DropDownList.DataMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.DropDownList.DisplayMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.DropDownList.ValueMember = dtTipoActivo.Columns("IdTipo").ToString
            cmbTipoActivo.DropDownList.Columns(0).DataMember = dtTipoActivo.Columns("IdTipo").ToString
            cmbTipoActivo.DropDownList.Columns(1).DataMember = dtTipoActivo.Columns("DesTipo").ToString
            cmbTipoActivo.SelectedIndex = 0
            dtTipoActivo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oActivoFijoService.Filtrar(Session.sCodEmp, CStr(cmbCodArea.Value), CStr(cmbCentroCosto.Value), toBlank(txtCodActivo.Text), toBlank(txtSerie.Text), toNumber(cmbUbicacion.Value), toNumber(cmbTipoActivo.Value), IdPersona, toBlank(txtCodMaleta.Text), toNumber(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodActivo").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        If cmbCentroCosto.Value <> "" Then
            Nuevo()
        Else
            MsgBox("Debe Seleccionar un centro de costo: ", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmActivoFijo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.CodCentro = cmbCentroCosto.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.CodActivo)
                    Mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Mostrar()
        End If
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmActivoFijo
            frm.state_button = True
            frm.CodActivo = toBlank(dgvDatos.CurrentRow.Cells("CodActivo").Value)
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodActivo)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Activo Fijo con códgio Nº " + dgvDatos.CurrentRow.Cells("CodActivo").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oActivoFijoService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("CodActivo").Text), Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL ACTIVO FIJO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtSerie.TextChanged, cmbUbicacion.ValueChanged, txtCodActivo.TextChanged, cmbEstado.ValueChanged, txtColaborador.TextChanged, cmbTipoActivo.ValueChanged, cmbCentroCosto.ValueChanged, txtCodMaleta.TextChanged
        listaDatos()
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

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodActivo").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biNuevo.MouseLeave, biMostrar.MouseLeave, _
                               biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                               miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                               miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Activo Fijo actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Activo Fijo."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Activo Fijo actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Activo Fijo actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub miImportarExcel_Click(sender As Object, e As EventArgs) Handles miImportarExcel.Click
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
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            'If dgvDatos.RowCount >= 280 Then
            '    MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            'Else
            InsertarMasivo()
            'End If
        End If

    End Sub
    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub


    Private Sub InsertarMasivo()
        Try
            'Dim contador As String = ""

            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim registro As New ActivoFijoService.ActivoFijo
                    Dim ubicacion As New ActivoFijoService.UbicacionActivoFijo
                    Dim empresa As New ActivoFijoService.Empresa
                    Dim tipoactivo As New ActivoFijoService.TipoActivo
                    Dim centrocosto As New ActivoFijoService.CentroCosto

                    registro.CodActivo = Trim(DataGridView1.Item(0, i).Value)
                    registro.DesActivo = DataGridView1.Item(1, i).Value

                    Dim numfac As String = ""
                    If IsDBNull(DataGridView1.Item(2, i).Value) Then
                        numfac = ""
                    Else numfac = CStr(DataGridView1.Item(2, i).Value)
                    End If

                    registro.NumFactura = numfac 'DataGridView1.Item(2, i).Value
                    registro.FecAdquisicion = Convert.ToDateTime(DataGridView1.Item(3, i).Value)

                    Dim marca As String = ""
                    If IsDBNull(DataGridView1.Item(4, i).Value) Then
                        marca = ""
                    Else marca = CStr(DataGridView1.Item(4, i).Value)
                    End If

                    registro.Marca = marca 'DataGridView1.Item(4, i).Value

                    Dim modelo As String = ""
                    If IsDBNull(DataGridView1.Item(5, i).Value) Then
                        modelo = ""
                    Else modelo = CStr(DataGridView1.Item(5, i).Value)
                    End If

                    registro.Modelo = modelo 'DataGridView1.Item(5, i).Value

                    Dim serie As String = ""
                    If IsDBNull(DataGridView1.Item(6, i).Value) Then
                        serie = ""
                    Else serie = CStr(DataGridView1.Item(6, i).Value)
                    End If

                    registro.Serie = serie 'DataGridView1.Item(6, i).Value
                    ubicacion.IdUbicacion = toNumber(DataGridView1.Item(7, i).Value)
                    registro.UbicacionActivoFijo = ubicacion
                    tipoactivo.IdTipo = toNumber(DataGridView1.Item(8, i).Value)
                    registro.TipoActivo = tipoactivo
                    registro.VidaUtil = toNumber(DataGridView1.Item(9, i).Value)
                    registro.ValorAdquisicion = Convert.ToDouble(DataGridView1.Item(10, i).Value)
                    registro.FechaBaja = Nothing

                    Dim observacion As String = ""
                    If IsDBNull(DataGridView1.Item(11, i).Value) Then
                        observacion = ""
                    Else observacion = CStr(DataGridView1.Item(11, i).Value)
                    End If

                    centrocosto.CodCentro = CStr(DataGridView1.Item(12, i).Value)
                    registro.CentroCosto = centrocosto

                    registro.CodMaleta = CStr(DataGridView1.Item(13, i).Value)

                    registro.Observaciones = observacion 'DataGridView1.Item(11, i).Value
                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    Dim estado_process As Integer
                    estado_process = oActivoFijoService.Insertar(registro)
                    'contador = "paso"

                    If estado_process > 0 Then

                    End If
                End If
            Next

            'If contador = "" Then
            MsgBox("Se insertaron los activos correctamente", MsgBoxStyle.Information)
            'End If
            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
            listaDatos()
        End Try
    End Sub

    Private Sub miFormatoExcel_Click(sender As Object, e As EventArgs) Handles miFormatoExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("CodActivo", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("NumFactura", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("FecAdquisicion", Type.GetType("System.DateTime")))
        dtExcel.Columns.Add(New DataColumn("Marca", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Modelo", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Serie", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Ubicacion", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("TipoActivo", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("VidaUtil", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("ValorAdquisicion", Type.GetType("System.Double")))
        'dtExcel.Columns.Add(New DataColumn("FecBaja", Type.GetType("System.DateTime")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodCentro", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodMaleta", Type.GetType("System.String")))

        'dtExcel.Rows.Add(New Object() {"", "", "", Date.Today, "", "", "", "0", "0", "0", "0.00", Date.Today, ""})
        dtExcel.Rows.Add(New Object() {"", "", "", Date.Today, "", "", "", "0", "0", "0", "0.00", "", "", ""})
        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub btnBuscarColaborador_Click(sender As Object, e As EventArgs) Handles btnBuscarColaborador.Click
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

    Private Sub chkColaborador_CheckedChanged(sender As Object, e As EventArgs) Handles chkColaborador.CheckedChanged
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

    Private Sub cmbCodArea_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            'If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            'End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

            'If cmbCodArea.Value = "" Then
            '    lblUnidadNegocio.Text = ""
            'Else
            '    lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerMemos_Click(sender As Object, e As EventArgs) Handles biVerMemos.Click

        Dim frm As New frmActivoFijo_Memos
        frm.CodActivo = dgvDatos.CurrentRow.Cells("CodActivo").Text
        frm.ShowDialog()

    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptActivosFijosListaHoriz

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte

            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            'forma.crvReportes.RefreshReport = False
            'forma.crvReportes.DisplayGroupTree = False

            reporte.SetParameterValue("Area", cmbCodArea.Text)
            reporte.SetParameterValue("CentroCosto", cmbCentroCosto.Text)
            reporte.SetParameterValue("Serie", txtSerie.Text)
            reporte.SetParameterValue("Ubicacion", cmbUbicacion.Text)
            reporte.SetParameterValue("Colaborador", txtColaborador.Text)
            reporte.SetParameterValue("Tipo", cmbTipoActivo.Text)
            reporte.SetParameterValue("Codigo", txtCodActivo.Text)
            reporte.SetParameterValue("Estado", cmbEstado.Text)

            forma.Text = "Listado de Activos"
            forma.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEliminarMasivo_Click(sender As Object, e As EventArgs) Handles biEliminarMasivo.Click

        If MsgBox("¿Está seguro de ELIMINAR los Activo Fijos filtrados?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

            Dim CodAct As String = ""

            Dim i As Integer
            For i = 0 To dgvDatos.RowCount - 1
                'CodAct = dgvDatos.CurrentRow.Cells("CodActivo").Value
                CodAct = dgvDatos.GetRow(i).Cells("CodActivo").Value
                oActivoFijoService.Borrar(toBlank(CodAct), Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            Next

            MsgBox("Se eliminaron los activos correctamente")
            listaDatos()

        End If
        'For i = 0 To dgvDatos.RowCount
        '    estado_process = oActivoFijoService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("CodActivo").Text), Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    End Sub

    Private Sub biDarBaja_Click(sender As Object, e As EventArgs) Handles biDarBaja.Click, miDarBaja.Click

        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmActivoFijo_DarBaja
                frm.CodActivo = dgvDatos.CurrentRow.Cells("CodActivo").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al poner EN TRAMITE el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

        'Try
        '    'cmbOpciones.Visible = False
        '    If MsgBox("¿Está seguro de DAR DE BAJA el Activo Fijo con códgio Nº " + dgvDatos.CurrentRow.Cells("CodActivo").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
        '        Dim estado_process As Boolean
        '        estado_process = oActivoFijoService.DarBaja(toBlank(dgvDatos.CurrentRow.Cells("CodActivo").Text), Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        '        If estado_process = True Then
        '            dtDatos = Nothing
        '            listaDatos()
        '            MsgBox("Se dio de baja el registro correctamente.", MsgBoxStyle.Information)
        '        Else
        '            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR AL DAR DE BAJA EL ACTIVO FIJO:" + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

    End Sub

    Private Sub biRegistrarArchivos_Click(sender As Object, e As EventArgs) Handles biRegistrarArchivos.Click, miRegistrarArchivos.Click

        Try
            Dim frm As New frmActivoFijo_Archivos
            frm.CodActivo = dgvDatos.CurrentRow.Cells("CodActivo").Value
            frm.estado = dgvDatos.CurrentRow.Cells("IdEstado").Value
            'frm.Nombre = dgvDatos.CurrentRow.Cells("Nombre").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DEL JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class