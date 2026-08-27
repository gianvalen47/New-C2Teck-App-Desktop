Imports System.ServiceModel

Public Class frmOportunidadNegocio_GastosMasivo

    '===========================Servicios====================================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtDocumentos As DataTable
    Public iPlaca As String
    Public IdOportunidad As Integer
    Public IdOportunidadGasto As Integer
    Public IdProveedor As Integer

    Private IdGasto As Integer
    Private IdGastoDet As Integer
    Private Descripcion As String
    Private DesProv As String
    Private AbrDoc As String
    Private IdDocumento As String
    Private IdProveedora As Integer
    Private CodMon As String
    Private SerDoc As String
    Private NumDoc As String
    Private FecDoc As String
    Private TotalFila As Double

    Private Sub frmOportunidadNegocio_GastosMasivo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoDetService.Close()
            oOportunidadNegocioService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oOportunidadNegocioService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oOportunidadNegocioService.Abort()
        End Try
    End Sub

    Private Sub frmOportunidadNegocio_GastosMasivo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_GastosMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvDocumentos.BackgroundColor = Color.Beige
        dgvDocumentos.BackColor = Color.Beige
        dgvDocumentos.ForeColor = Color.MidnightBlue
        dgvDocumentos.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False

        LlenarCombos()
        listaSeleccionados()
        listaDatos()
        txtIdGasto.Focus()

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
            'dtDocumentos = oSolicitudGastoDetService.FiltrarGastosPlaca(iPlaca, txtNumDoc.Text, IdProveedor).Tables(0)
            'dtDocumentos = oSolicitudGastoDetService.FiltrarGastosPlaca("", txtIdGasto.Text, IdProveedor).Tables(0)
            dtDocumentos = oSolicitudGastoDetService.Mostrar(toNumber(txtIdGasto.Text)).Tables(0)

            dgvDocumentos.DataSource = dtDocumentos
            dgvDocumentos.Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"

            cIdGasto.DataPropertyName = dtDocumentos.Columns("IdGasto").ColumnName
            cIdGastoDet.DataPropertyName = dtDocumentos.Columns("IdGastoDet").ColumnName
            cDesProv.DataPropertyName = dtDocumentos.Columns("DesProv").ColumnName
            cAbrDoc.DataPropertyName = dtDocumentos.Columns("AbrDoc").ColumnName
            cIdDocumento.DataPropertyName = dtDocumentos.Columns("IdDocumento").ColumnName
            cDescripcion.DataPropertyName = dtDocumentos.Columns("Descripcion").ColumnName
            cIdProveedora.DataPropertyName = dtDocumentos.Columns("IdProveedor").ColumnName
            cCodMon.DataPropertyName = dtDocumentos.Columns("CodMon").ColumnName
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
            dtSeleccionados = oSolicitudGastoDetService.Mostrar(toNumber(txtIdGasto.Text)).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados
            dgvSeleccionados.Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"

            cIdGasto1.DataPropertyName = dtSeleccionados.Columns("IdGasto").ColumnName
            cIdGastoDet1.DataPropertyName = dtSeleccionados.Columns("IdGastoDet").ColumnName
            cDesProv1.DataPropertyName = dtSeleccionados.Columns("DesProv").ColumnName
            cAbrDoc1.DataPropertyName = dtSeleccionados.Columns("AbrDoc").ColumnName
            cIdDocumento1.DataPropertyName = dtSeleccionados.Columns("IdDocumento").ColumnName
            cDescripcion1.DataPropertyName = dtSeleccionados.Columns("Descripcion").ColumnName
            cIdProveedora1.DataPropertyName = dtSeleccionados.Columns("IdProveedor").ColumnName
            cCodMon1.DataPropertyName = dtSeleccionados.Columns("CodMon").ColumnName
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
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
            Dim FecDocUlt As String

            IdGasto = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdGasto").Value.ToString
            IdGastoDet = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdGastoDet").Value.ToString
            Descripcion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDescripcion").Value.ToString
            DesProv = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesProv").Value.ToString
            AbrDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cAbrDoc").Value.ToString
            IdDocumento = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdDocumento").Value.ToString
            IdProveedora = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdProveedora").Value.ToString
            CodMon = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodMon").Value.ToString
            SerDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cSerDoc").Value.ToString
            NumDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumDoc").Value.ToString
            FecDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cFecDoc").Value.ToString
            FecDocUlt = CDate(FecDoc).ToString("dd/MM/yyyy")
            TotalFila = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalFila").Value.ToString)

            dr("IdGasto") = IdGasto
            dr("IdGastoDet") = IdGastoDet
            dr("Descripcion") = Descripcion
            dr("DesProv") = DesProv
            dr("AbrDoc") = AbrDoc
            dr("IdDocumento") = IdDocumento
            dr("IdProveedor") = IdProveedora
            dr("CodMon") = CodMon
            dr("SerDoc") = SerDoc
            dr("NumDoc") = NumDoc
            dr("FecDoc") = CDate(FecDocUlt)
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
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

    Private Sub btnAgregarTodos_Click(sender As Object, e As EventArgs) Handles btnAgregarTodos.Click
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de INGRESAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim Cont As Integer = 0
                    For i As Integer = 0 To dgvSeleccionados.RowCount - 1

                        Dim registro As New OportunidadNegocioService.OportunidadNegocioGastos
                        Dim OportunidadNegocio As New OportunidadNegocioService.OportunidadNegocio
                        Dim Gasto As New OportunidadNegocioService.SolicitudGasto
                        Dim GastoDet As New OportunidadNegocioService.SolicitudGastoDet
                        Dim tipodoc As New OportunidadNegocioService.TipoDocumento
                        Dim moneda As New OportunidadNegocioService.Moneda
                        Dim proveedor As New OportunidadNegocioService.Proveedor

                        registro.IdOportunidadGasto = IdOportunidadGasto

                        OportunidadNegocio.IdOportunidad = IdOportunidad
                        registro.OportunidadNegocio = OportunidadNegocio

                        Gasto.IdGasto = dgvSeleccionados.Item("cIdGasto1".ToLower, i).Value
                        GastoDet.SolicitudGasto = Gasto
                        GastoDet.IdGastoDet = dgvSeleccionados.Item("cIdGastoDet1".ToLower, i).Value
                        registro.SolicitudGastoDet = GastoDet

                        tipodoc.IdDocumento = dgvSeleccionados.Item("cIdDocumento1".ToLower, i).Value
                        registro.TipoDocumento = tipodoc

                        registro.SerDoc = dgvSeleccionados.Item("cSerDoc1".ToLower, i).Value
                        registro.NumDoc = dgvSeleccionados.Item("cNumDoc1".ToLower, i).Value
                        registro.FecDoc = CDate(dgvSeleccionados.Item("cFecDoc1".ToLower, i).Value)

                        moneda.CodMon = dgvSeleccionados.Item("cCodMon1".ToLower, i).Value
                        registro.Moneda = moneda
                        registro.Monto = dgvSeleccionados.Item("cTotalFila1".ToLower, i).Value

                        proveedor.IdProveedor = dgvSeleccionados.Item("cIdProveedora1".ToLower, i).Value
                        registro.Proveedor = proveedor

                        registro.Observacion = dgvSeleccionados.Item("cDescripcion1".ToLower, i).Value

                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.NomPc = Session.sNomPc

                        Dim estado_process As String
                        estado_process = oOportunidadNegocioService.InsertarGastos(registro)
                        If estado_process <> "" Then
                            Cont = Cont + 1
                        End If

                        'Dim registro As New OportunidadNegocioService.OportunidadNegocioGastos
                        'Dim OportunidadNegocio As New OportunidadNegocioService.OportunidadNegocio
                        'Dim Gasto As New OportunidadNegocioService.SolicitudGasto
                        'Dim GastoDet As New OportunidadNegocioService.SolicitudGastoDet

                        'OportunidadNegocio.IdOportunidad = IdOportunidad
                        'registro.OportunidadNegocio = OportunidadNegocio

                        'Gasto.IdGasto = dgvSeleccionados.Item("cIdGasto1".ToLower, i).Value
                        'GastoDet.SolicitudGasto = Gasto
                        'GastoDet.IdGastoDet = dgvSeleccionados.Item("cIdGastoDet1".ToLower, i).Value
                        'registro.SolicitudGastoDet = GastoDet

                        'registro.CodUsu = Session.sCodUsu
                        'registro.DirIp = Session.sDirIp
                        'registro.NomPc = Session.sNomPc

                        'Dim estado_process As String
                        'estado_process = oOportunidadNegocioService.InsertarGastos(registro)
                        'If estado_process <> "" Then
                        '    Cont = Cont + 1
                        'End If
                    Next

                    If Cont > 0 Then
                        MsgBox("Se insertó el(los) Gasto(s) Correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        'LimpiarDatos()
                        'listaDatos()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DOCUMENTO(S): " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIdGasto.Text = ""
        listaSeleccionados()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       txtIdGasto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    'Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.F12 Then
    '        If btnBuscarProveedor.Enabled = True Then
    '            e.Handled = True
    '            btnBuscarProveedor_Click(sender, e)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim frm As New frmBuscarProveedor
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            If toNull(frm.codigo) <> Nothing Then
    '                IdProveedor = frm.codigo
    '                txtProveedor.Text = frm.descripcion
    '                txtNumDoc.Focus()
    '            Else
    '                IdProveedor = 0
    '                txtProveedor.Text = ""
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub chkProveedor_CheckedChanged(sender As Object, e As EventArgs)
    '    If txtProveedor.Text <> "(Todos)" Then
    '        chkProveedor.Enabled = False
    '        txtProveedor.Text = "(Todos)"
    '        IdProveedor = 0
    '        listaDatos()
    '    Else
    '        chkProveedor.Enabled = True
    '        pboxLimpiarCliente.Enabled = True
    '    End If
    'End Sub

    Private Sub btnBuscarGasto_Click(sender As Object, e As EventArgs) Handles btnBuscarGasto.Click
        Dim frm As New frmBuscarSolicitudGasto
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtIdGasto.BackColor = System.Drawing.SystemColors.Control
            txtIdGasto.Text = frm.IdGasto
            If frm.IdGasto <> Nothing Then
                listaDatos()
            Else
                LimpiarDatos()
                txtIdGasto.Text = ""
            End If
            txtIdGasto.ReadOnly = False
            txtIdGasto.BackColor = System.Drawing.SystemColors.Window
        End If
        txtIdGasto.Select()
    End Sub
End Class