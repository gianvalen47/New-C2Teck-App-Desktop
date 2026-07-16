Imports System.ServiceModel
Public Class frmOportunidadNegocio_Gastos_Nuevo

    '===========================Servicios====================================================
    'Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public IdOportunidad As Integer
    Public IdProveedor As Integer
    Public IdOportunidadGasto As Integer
    Private dtMonedas As DataTable

    Private dtTipDoc As DataTable

    Private Sub frmOportunidadNegocio_Gastos_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oOportunidadNegocioService.Close()
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oOportunidadNegocioService.Abort()
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oOportunidadNegocioService.Abort()
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub frmOportunidadNegocio_Gastos_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_Gastos_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbTipoDoc.Select()
        LlenarCombos()

    End Sub

    Private Sub LlenarCombos()
        Try
            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("AplicaIgv").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

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

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    'Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If Len(Trim(txtNumDoc.Text)) > 0 Then
    '            NumDoc()
    '        End If
    '        txtFecDoc.Focus()
    '    End If
    'End Sub

    Private Sub NumDoc()
        Try
            Dim cant As Integer = Len(txtNumDoc.Text)
            Do While cant < 8
                txtNumDoc.Text = "0" & txtNumDoc.Text
                cant = cant + 1
            Loop
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Validated
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                NumDoc()
                txtFecDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumDoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                NumDoc()
                'txtFecDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    'Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If Len(Trim(txtSerieDoc.Text)) > 0 Then
    '            SerieDoc()
    '        End If
    '        txtNumDoc.Focus()
    '    End If
    'End Sub

    Private Sub SerieDoc()
        Try
            Dim cant As Integer = Len(txtSerieDoc.Text)
            Do While cant < 4
                txtSerieDoc.Text = "0" & txtSerieDoc.Text
                cant = cant + 1
            Loop
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Validated
        Try
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                SerieDoc()
                txtNumDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSerieDoc.Validating
        Try
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                SerieDoc()
                'txtNumDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub


    Private Sub cmbTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtSerieDoc.Focus()
        End If
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                NumDoc()
            End If
            txtFecDoc.Focus()
        End If
    End Sub

    Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                SerieDoc()
            End If
            txtNumDoc.Focus()
        End If
    End Sub

    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Select()
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMonto.Select()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtDescripcion.Select()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Select()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If MsgBox("¿Está seguro de INGRESAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

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

                    Gasto.IdGasto = Nothing '98901
                    GastoDet.SolicitudGasto = Gasto
                    GastoDet.IdGastoDet = Nothing '337352
                    registro.SolicitudGastoDet = GastoDet

                    tipodoc.IdDocumento = cmbTipoDoc.Value
                    registro.TipoDocumento = tipodoc

                    registro.SerDoc = txtSerieDoc.Text
                    registro.NumDoc = txtNumDoc.Text
                    registro.FecDoc = txtFecDoc.Text

                    moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = moneda
                    registro.Monto = txtMonto.Value

                    proveedor.IdProveedor = IdProveedor '13299
                    registro.Proveedor = proveedor

                    registro.Observacion = txtDescripcion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.NomPc = Session.sNomPc
                    '-------------------------------------------------------------------------------------------


                    'If state_button Then        'Modificar
                    '    Modificar(registro)
                    'Else                        'Nuevo
                    Insertar(registro)
                    'End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub Insertar(ByVal registro As OportunidadNegocioService.OportunidadNegocioGastos)
        Try
            Dim estado_process As Integer
            estado_process = oOportunidadNegocioService.InsertarGastos(registro)
            'type_process = "insert"
            If estado_process > 0 Then
                IdOportunidadGasto = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub Modificar(ByVal registro As SolicitudGastoDetService.SolicitudGastoDet)
    '    Try
    '        Dim estado_process As Boolean
    '        estado_process = oOportunidadNegocioService.ActualizarGastos(registro)
    '        type_process = "update"
    '        If estado_process = True Then
    '            desactivar()
    '            ObtenerRegistro()
    '            ActualizarDetallesCentroCosto()
    '            ActualizarDetallesJob()
    '        Else
    '            MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Function ValidaCampos() As Boolean

        Try
            If toDouble(txtMonto.Value) <= 0 Then    'toDouble(txtMonto.Value) <= 0 Then  ' Modificado 26-02
                MsgBox("El monto debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe de ingresar el proveedor", MsgBoxStyle.Information, "Información")
                btnBuscarProveedor.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento", MsgBoxStyle.Information, "Información")
                txtSerieDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) <> 0 And (toBlank(txtSerieDoc.Text) = "") Then
                MsgBox("Debe Ingresar la Serie del Documento.", MsgBoxStyle.Information, "Información")
                txtSerieDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) <> 0 And (toBlank(txtNumDoc.Text) = "") Then
                MsgBox("Debe Ingresar el Número del Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) = 0 And toBlank(txtNumDoc.Text) <> "" Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf (toBlank(txtNumDoc.Text) <> "") And toNumber(cmbTipoDoc.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then 'Se valida que la fecha del gasto sea obligatoria en cualquier caso
                MsgBox("Debe Ingresar la fecha del documento.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) <> 0 And Year(txtFecDoc.Value) < 2012 Then
                MsgBox("Fecha de Documento inválido.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe Ingresar el Numero de Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtSerieDoc.Text) = "" Then
                MsgBox("Debe Ingresar la Serie de Documento.", MsgBoxStyle.Information, "Información")
                txtSerieDoc.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Text) = "" Then
                MsgBox("Debe Seleccionar la moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" And IdProveedor <> 0 Then
                MsgBox("Debe Ingresar el Número del Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    cmbTipoDoc.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles btnAgregarProveedor.Click
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

    Private Sub btnLimpiarProveedor_Click(sender As Object, e As EventArgs) Handles btnLimpiarProveedor.Click
        Try
            IdProveedor = 0
            txtProveedor.Text = ""
            cmbTipoDoc.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al Limpiar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class