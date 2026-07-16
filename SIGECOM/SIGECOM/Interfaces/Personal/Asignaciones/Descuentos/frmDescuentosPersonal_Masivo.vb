Imports System.ServiceModel
Public Class frmDescuentosPersonal_Masivo

    '===========================Servicios====================================================
    Private oDescuentoPersonalService As New DescuentoPersonalService.DescuentoPersonalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtClase As DataTable
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtRubroDscto As DataTable
    Private dtMonedas As DataTable
    Private dtSeleccionados As DataTable
    Private dtPersonal As DataTable

    Public IdDescuento As Integer
    Private IdPer As Integer
    Private ApeNom As String

    Private Sub frmDescuentosPersonal_Masivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvPersonal.BackgroundColor = Color.Beige
        dgvPersonal.BackColor = Color.Beige
        dgvPersonal.ForeColor = Color.MidnightBlue
        dgvPersonal.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        LlenarCombos()

        txtFecha.Value = Today
        cmbMoneda.Value = "NS"
    End Sub

    Private Sub frmDescuentosPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmDescuentosPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPersonaService.Close()
            oMaestroService.Close()
            oDescuentoPersonalService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
            oMaestroService.Abort()
            oDescuentoPersonalService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
            oMaestroService.Abort()
            oDescuentoPersonalService.Abort()
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
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
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

            '======================================= MONEDAS ==============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            ''========================================== DESCUENTO ===============================================
            dtRubroDscto = oDescuentoPersonalService.MostrarRubros(Session.sCodEmp).Tables(0)
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

    Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
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

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oPersonaService.Filtrar("", "", "", "", "", True).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdPer1.DataPropertyName = dtSeleccionados.Columns("IdPer").ColumnName
            cApeNom1.DataPropertyName = dtSeleccionados.Columns("ApeNom").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
                btnRegresar.Enabled = True
                btnRegresarTodos.Enabled = True
            Else
                btnRegresar.Enabled = False
                btnRegresarTodos.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregarFila(dtSeleccionados, dgvSeleccionados, dgvPersonal)
        EnableOptions()
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

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtPersonal, dgvPersonal, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdPer = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdPer1").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom1").Value.ToString

            dr("IdPer") = IdPer
            dr("ApeNom") = ApeNom

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        For i As Integer = 0 To dgvPersonal.RowCount - 1
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvPersonal)
        Next
        EnableOptions()
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtPersonal, dgvPersonal, dgvSeleccionados)
        Next
        EnableOptions()
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
            ElseIf toBlank(cmbDescuento.Value) = "" Then
                MsgBox("Debe Ingresar el rubro del descuento.", MsgBoxStyle.Information, "Información")
                cmbDescuento.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe de Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            dgvSeleccionados.EndEdit()
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim ContMonto As Integer = 0  'Cantidad de registros sin monto

                    For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                        If toDouble(dgvSeleccionados.Item("cMonto".ToLower, i).Value) = 0 Then
                            ContMonto = ContMonto + 1
                        End If
                    Next

                    If ContMonto > 0 Then
                        MsgBox("Debe ingresar el monto de descuento a todos los colaboradores seleccionados.", MsgBoxStyle.Information, "Información")
                    Else
                        Dim Cont As Integer = 0

                        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                            Dim registro As New DescuentoPersonalService.DescuentoPersonal
                            Dim Colaborador As New DescuentoPersonalService.Persona
                            Dim RubroDescuento As New DescuentoPersonalService.RubroDescuentoPlanilla
                            Dim Moneda As New DescuentoPersonalService.Moneda

                            registro.IdDescuento = IdDescuento
                            IdPer = dgvSeleccionados.Item("cIdPer1".ToLower, i).Value

                            Colaborador.IdPer = IdPer
                            registro.Persona = Colaborador

                            RubroDescuento.IdRubroDes = cmbDescuento.Value
                            registro.RubroDescuentoPlanilla = RubroDescuento
                            registro.Fecha = txtFecha.Value
                            Moneda.CodMon = cmbMoneda.Value
                            registro.Moneda = Moneda
                            registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)

                            registro.Monto = toDouble(dgvSeleccionados.Item("cMonto".ToLower, i).Value)

                            registro.NomPc = Session.sNomPc
                            registro.DirIp = Session.sDirIp
                            registro.CodUsu = Session.sCodUsu
                            registro.FecReg = Today

                            Dim estado_process As Integer
                            estado_process = oDescuentoPersonalService.Insertar(registro)
                            If estado_process > 0 Then
                                Cont = Cont + 1
                            End If
                        Next

                        If Cont > 0 Then
                            MsgBox("Se insertó el(los) Descuento(s) Correctamente.", MsgBoxStyle.Information, "Información")
                            LimpiarDatos()
                            listaDatos()
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR DESCUENTO(S) MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        cmbArea.SelectedIndex = 0
        cmbCentroCosto.SelectedIndex = 0
        cmbClase.SelectedIndex = 0
        cmbDescuento.SelectedIndex = 0
        txtFecha.Value = Today
        cmbMoneda.Value = "NS"
        txtObservacion.Text = ""
    End Sub

    Private Sub dgvSeleccionados_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvSeleccionados.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna 
        Dim columna As Integer = dgvSeleccionados.CurrentCell.ColumnIndex
        ' en la columna 2 acepto ademas de numeros un unico "." que es el separador decimal aqui
        If columna = 2 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            ' comprobar si es un número con isNumber, si es el backspace, si el caracter es el separador decimal, y que no contiene ya el separador 
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
End Class