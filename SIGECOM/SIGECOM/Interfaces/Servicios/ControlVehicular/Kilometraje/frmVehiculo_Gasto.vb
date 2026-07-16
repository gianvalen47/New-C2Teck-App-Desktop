Imports System.ServiceModel
Public Class frmVehiculo_Gasto

    '===========================Servicios====================================================
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtDocumentos As DataTable
    Public iPlaca As String
    Public IdKilometraje As Integer
    Public IdProveedor As Integer

    Private IdGasto As Integer
    Private IdGastoDet As Integer
    Private SerDoc As String
    Private NumDoc As String
    Private FecDoc As String
    Private TotalFila As Double


    Private Sub frmVehiculo_Gasto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dgvDocumentos.BackgroundColor = Color.Beige
        dgvDocumentos.BackColor = Color.Beige
        dgvDocumentos.ForeColor = Color.MidnightBlue
        dgvDocumentos.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False

        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Proveedor")

        IdProveedor = 0
        txtProveedor.Text = "(Todos)"

        LlenarCombos()
        listaSeleccionados()
        listaDatos()
        txtNumDoc.Focus()
    End Sub

    Private Sub frmVehiculo_Gasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmCapacitacion_Masivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVehiculoService.Close()
            oSolicitudGastoDetService.Close()            
        Catch ex As TimeoutException
            oVehiculoService.Abort()
            oSolicitudGastoDetService.Abort()            
        Catch ex As CommunicationException
            oVehiculoService.Abort()
            oSolicitudGastoDetService.Abort()            
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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA DOCUMENTOS ===================================
            dtDocumentos = oSolicitudGastoDetService.FiltrarGastosPlaca(iPlaca, txtNumDoc.Text, IdProveedor).Tables(0)
            dgvDocumentos.DataSource = dtDocumentos

            cIdGasto.DataPropertyName = dtDocumentos.Columns("IdGasto").ColumnName
            cIdGastoDet.DataPropertyName = dtDocumentos.Columns("IdGastoDet").ColumnName
            cSerDoc.DataPropertyName = dtDocumentos.Columns("SerDoc").ColumnName
            cNumDoc.DataPropertyName = dtDocumentos.Columns("NumDoc").ColumnName            
            cFecDoc.DataPropertyName = dtDocumentos.Columns("FecDoc").ColumnName            
            cTotalFila.DataPropertyName = dtDocumentos.Columns("TotalFila").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oSolicitudGastoDetService.FiltrarGastosPlaca("", "", 0).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdGasto1.DataPropertyName = dtSeleccionados.Columns("IdGasto").ColumnName
            cIdGastoDet1.DataPropertyName = dtSeleccionados.Columns("IdGastoDet").ColumnName
            cSerDoc1.DataPropertyName = dtSeleccionados.Columns("SerDoc").ColumnName
            cNumDoc1.DataPropertyName = dtSeleccionados.Columns("NumDoc").ColumnName            
            cFecDoc1.DataPropertyName = dtSeleccionados.Columns("FecDoc").ColumnName
            cTotalFila1.DataPropertyName = dtSeleccionados.Columns("TotalFila").ColumnName

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvDocumentos.RowCount > 0 Then
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
        IdGastoDet = dgvDocumentos.Rows(dgvDocumentos.CurrentRow.Index).Cells("cIdGastoDet").Value.ToString
        If ValidarDocumento(dgvSeleccionados, IdGastoDet) Then
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvDocumentos)
            EnableOptions()
        Else
            MsgBox("El Documento ya fue seleccionado.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdGasto = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdGasto").Value.ToString
            IdGastoDet = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdGastoDet").Value.ToString
            SerDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cSerDoc").Value.ToString
            NumDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumDoc").Value.ToString
            FecDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cFecDoc").Value.ToString
            TotalFila = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalFila").Value.ToString)

            dr("IdGasto") = IdGasto
            dr("IdGastoDet") = IdGastoDet
            dr("SerDoc") = SerDoc
            dr("NumDoc") = NumDoc
            dr("FecDoc") = FecDoc
            dr("TotalFila") = TotalFila

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

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumDoc.TextChanged, txtProveedor.TextChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un Documento.", MsgBoxStyle.Information, "Información")
                dgvDocumentos.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0
        For i As Integer = 0 To dgvDocumentos.RowCount - 1
            IdGastoDet = dgvDocumentos.Item("cIdGastoDet".ToLower, i).Value
            If Not (ValidarDocumento(dgvSeleccionados, IdGastoDet)) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de los Documentos ya han sido seleccionados.", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvDocumentos.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvDocumentos)
            Next
            EnableOptions()
        End If
    End Sub

    Private Function ValidarDocumento(ByVal dgvDatos As DataGridView, ByVal IdGastoDet As Integer) As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If IdGastoDet = dgvDatos.Item("cIdGastoDet1".ToLower, i).Value Then
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
            MsgBox("Error al Validar Documento: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim Cont As Integer = 0
                    For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                        Dim registro As New VehiculoService.KilometrajeGasto
                        Dim Kilometraje As New VehiculoService.Kilometraje
                        Dim Gasto As New VehiculoService.SolicitudGasto
                        Dim GastoDet As New VehiculoService.SolicitudGastoDet

                        Kilometraje.IdKilometraje = IdKilometraje
                        registro.Kilometraje = Kilometraje

                        Gasto.IdGasto = dgvSeleccionados.Item("cIdGasto1".ToLower, i).Value
                        GastoDet.SolicitudGasto = Gasto
                        GastoDet.IdGastoDet = dgvSeleccionados.Item("cIdGastoDet1".ToLower, i).Value
                        registro.SolicitudGastoDet = GastoDet

                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp                        
                        registro.NomPc = Session.sNomPc

                        Dim estado_process As String
                        estado_process = oVehiculoService.InsertarGasto(registro)
                        If estado_process <> "" Then
                            Cont = Cont + 1
                        End If
                    Next

                    If Cont > 0 Then
                        MsgBox("Se insertó el(los) Documento(s) Correctamente.")
                        LimpiarDatos()
                        listaDatos()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DOCUMENTO(S): " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()        
        IdProveedor = 0
        txtProveedor.Text = ""
        txtNumDoc.Text = ""
        listaSeleccionados()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtProveedor.KeyPress _
                        , txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
                    txtNumDoc.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub
End Class