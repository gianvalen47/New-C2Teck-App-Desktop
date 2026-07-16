Imports System.ServiceModel
Public Class frmCapacitacion_Masivo

    '===========================Servicios====================================================
    Private oCapacitacionService As New CapacitacionService.CapacitacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtClase As DataTable
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtTipoCapacitacion As DataTable

    Private dtSeleccionados As DataTable
    Private dtPersonal As DataTable
    Private dtMonedas As DataTable

    Public IdCapacitacion As Integer
    Public IdProveedor As Integer
    Private IdPer As Integer
    Private ApeNom As String


    Private Sub frmCapacitacion_Masivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvPersonal.BackgroundColor = Color.Beige
        dgvPersonal.BackColor = Color.Beige
        dgvPersonal.ForeColor = Color.MidnightBlue
        dgvPersonal.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        LlenarCombos()
        cmbMoneda.Value = "NS"
        listaSeleccionados()
    End Sub

    Private Sub frmCapacitacion_Masivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmCapacitacion_Masivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCapacitacionService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oCapacitacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oCapacitacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
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

    Private Sub LlenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)            
            dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================== CLASE ================================================
            dtClase = oPersonaService.MostrarClases.Tables(0)
            dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing

            '======================================== TIPO =================================================
            dtTipoCapacitacion = oCapacitacionService.MostrarTipos()
            cmbTipoCapac.DataSource = dtTipoCapacitacion
            cmbTipoCapac.DropDownList.DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.DisplayMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.ValueMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.Columns(0).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.Columns(1).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.SelectedIndex = 0
            dtTipoCapacitacion = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
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

    Private Sub listaDatos()
        Try

            '===================================== LISTA PERSONAL ======================================
            dtPersonal = oPersonaService.Filtrar(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), "", True).Tables(0)
            dgvPersonal.DataSource = dtPersonal

            cIdPer.DataPropertyName = dtPersonal.Columns("IdPer").ColumnName
            cApeNom.DataPropertyName = dtPersonal.Columns("ApeNom").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oPersonaService.Filtrar("", "", "", "", "", True).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdPer1.DataPropertyName = dtSeleccionados.Columns("IdPer").ColumnName
            cApeNom1.DataPropertyName = dtSeleccionados.Columns("ApeNom").ColumnName

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvPersonal.RowCount > 0 Then
                btnAgregar.Enabled = True
                btnAgregarTodos.Enabled = True
            Else
                btnAgregar.Enabled = False
                btnAgregarTodos.Enabled = False
            End If

            If dgvSeleccionados.RowCount > 0 Then
                miEliminar.Enabled = True
            Else
                miEliminar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        IdPer = dgvPersonal.Rows(dgvPersonal.CurrentRow.Index).Cells("cIdPer").Value.ToString
        If ValidaIdPersona(dgvSeleccionados, IdPer) Then
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvPersonal)
            EnableOptions()
        Else
            MsgBox("El Colaborador ya fue seleccionado.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdPer = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdPer").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom").Value.ToString

            dr("IdPer") = IdPer
            dr("ApeNom") = ApeNom

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbClase.ValueChanged, cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un Colaborador.", MsgBoxStyle.Information, "Información")
                dgvPersonal.Focus()
                Return False
            ElseIf toBlank(cmbTipoCapac.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de capacitación.", MsgBoxStyle.Information, "Información")
                cmbTipoCapac.Focus()
                Return False
            ElseIf toBlank(txtCursoCapac.Text) = "" Then
                MsgBox("Debe Ingresar el nombre del Curso.", MsgBoxStyle.Information, "Información")
                txtCursoCapac.Focus()
                Return False
            ElseIf toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Inicio.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            ElseIf toBlank(txtFechaFinal.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha Final.", MsgBoxStyle.Information, "Información")
                txtFechaFinal.Focus()
                Return False
            ElseIf txtDuracionCapac.Text = "" Then
                MsgBox("Debe Ingresar la Duración.", MsgBoxStyle.Information, "Información")
                txtDuracionCapac.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe Ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
                txtProveedor.Focus()
                Return False
                'ElseIf toDouble(txtCostoCapac.Value) = 0 Then
                '    MsgBox("Debe Ingresar el Costo.", MsgBoxStyle.Information, "Información")
                '    txtCostoCapac.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0
        For i As Integer = 0 To dgvPersonal.RowCount - 1
            IdPer = dgvPersonal.Item("cIdPer".ToLower, i).Value
            If Not (ValidaIdPersona(dgvSeleccionados, IdPer)) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de los Colaboradores ya han sido seleccionados.", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvPersonal.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvPersonal)
            Next
            EnableOptions()
        End If
    End Sub

    Private Function ValidaIdPersona(ByVal dgvDatos As DataGridView, ByVal IdPersona As Integer) As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If IdPersona = dgvDatos.Item("cIdPer1".ToLower, i).Value Then
                        cont = cont + 1
                    End If
                Next

                If cont > 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al Validar Persona: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim Cont As Integer = 0
                    For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                        Dim registro As New CapacitacionService.Capacitacion
                        Dim Persona As New CapacitacionService.Persona
                        Dim Proveedor As New CapacitacionService.Proveedor
                        Dim Moneda As New CapacitacionService.Moneda

                        registro.IdCapacitacion = IdCapacitacion
                        IdPer = dgvSeleccionados.Item("cIdPer1".ToLower, i).Value

                        Persona.IdPer = IdPer
                        registro.Persona = Persona
                        registro.Tipo = cmbTipoCapac.Value
                        registro.NombreCurso = txtCursoCapac.Text
                        registro.Programado = cbProgramadoCapac.Checked
                        registro.FechaInicio = txtFechaInicio.Value
                        registro.FechaFinal = txtFechaFinal.Value
                        registro.Duracion = txtDuracionCapac.Text
                        Proveedor.IdProveedor = IdProveedor
                        registro.Proveedor = Proveedor
                        registro.Costo = toDouble(txtCostoCapac.Value)
                        registro.Observacion = txtObservacion.Text
                        registro.MesEvaluar = txtMesesEvaluarCapac.Value
                        registro.Evaluado = False
                        registro.FechaEvaluado = Nothing
                        Moneda.CodMon = cmbMoneda.Value
                        registro.Moneda = Moneda

                        registro.Instructor = txtInstructor.Text
                        registro.Nota = Nothing

                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.FecReg = Today
                        registro.NomPc = Session.sNomPc

                        Dim estado_process As Integer
                        estado_process = oCapacitacionService.Insertar(registro)
                        If estado_process > 0 Then
                            Cont = Cont + 1
                        End If              
                    Next

                    If Cont > 0 Then
                        MsgBox("Se insertó la(s) Capacitacion(es) Correctamente.")
                        LimpiarDatos()
                        listaDatos()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR CAPACITACION(ES) MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        cmbArea.SelectedIndex = 0
        cmbCentroCosto.SelectedIndex = 0
        cmbClase.SelectedIndex = 0
        cmbTipoCapac.SelectedIndex = 0
        txtFechaInicio.Value = Today
        txtFechaFinal.Value = Today
        IdProveedor = 0
        txtProveedor.Text = ""
        cbProgramadoCapac.Checked = False
        txtDuracionCapac.Text = ""
        txtCostoCapac.Value = 0
        txtObservacion.Text = ""
        txtCursoCapac.Text = ""
        txtMesesEvaluarCapac.Value = 0
        txtInstructor.Text = ""
        listaSeleccionados()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbArea.KeyPress _
                          , cmbCentroCosto.KeyPress _
                          , cmbClase.KeyPress _
                          , txtFechaInicio.KeyPress _
                          , txtFechaFinal.KeyPress _
                          , cmbTipoCapac.KeyPress _
                          , txtCursoCapac.KeyPress _
                          , cbProgramadoCapac.KeyPress _
                          , txtDuracionCapac.KeyPress _
                          , txtProveedor.KeyPress _
                          , txtCostoCapac.KeyPress _
                          , txtMesesEvaluarCapac.KeyPress _
                          , cmbMoneda.KeyPress _
                          , txtInstructor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbArea.Focus()
        End If
    End Sub

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtCostoCapac.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class