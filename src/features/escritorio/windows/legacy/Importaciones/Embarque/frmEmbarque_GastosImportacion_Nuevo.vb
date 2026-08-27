Imports System.ServiceModel

Public Class frmEmbarque_GastosImportacion_Nuevo


    '===========================Servicios====================================================
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient
    'Private oEmbarqueDetService As New EmbarqueDetService.EmbarqueDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient

    Public CodEmbarque As String

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 
    'Public IdOrden As Integer
    Public IdProveedor As Integer
    Public IdTipo As Integer
    Public IdGastoEmb As Int64
    'Public IdPersonaSolicita As Integer
    'Public IdPersonaAutoriza As Integer
    'Private dtDatos As DataTable
    'Private dtCondPago As DataTable
    Private dtMonedas As DataTable
    Private dtTipoGasto As DataTable
    Private dtTipDoc As DataTable

    Private Sub frmEmbarque_GastosImportacion_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEmbarqueService.Close()
            oMaestroService.Close()
            oReembolsoCajaDetService.Close()
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
            oMaestroService.Abort()
            oReembolsoCajaDetService.Abort()
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oEmbarqueService.Abort()
            oMaestroService.Abort()
            oReembolsoCajaDetService.Abort()
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub frmEmbarque_GastosImportacion_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEmbarque_GastosImportacion_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LlenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
        Else                          'Nuevo
            cmbMoneda.Value = "NS"
            cmbTipoDoc.SelectedIndex = 1
            activar()
            cmbTipoGasto.Select()
            txtFecDoc.Value = Today
            txtFecDoc.Text = Today
        End If

    End Sub

    Private Sub LlenarCombos()
        Try
            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oEmbarqueService.MostrarTipoGasto().Tables(0)
            'dtTipoGasto.Rows.InsertAt(getRowTodos(dtTipoGasto), 0)
            cmbTipoGasto.DataSource = dtTipoGasto
            cmbTipoGasto.DropDownList.DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.DisplayMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.ValueMember = dtTipoGasto.Columns("IdTipo").ToString
            cmbTipoGasto.DropDownList.Columns(0).DataMember = dtTipoGasto.Columns("IdTipo").ToString
            cmbTipoGasto.DropDownList.Columns(1).DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.SelectedIndex = 0
            dtTipoGasto = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            'dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
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



        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EmbarqueService.EmbarqueGastos
            registro = oEmbarqueService.ObtenerGasto(IdGastoEmb)

            'CodEmbarque = registro.OportunidadNegocio.IdOportunidad
            cmbTipoGasto.Value = registro.TipoGastoImportacion.IdTipo
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMonto.Value = registro.Monto
            txtDescripcion.Text = registro.Observacion

            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            txtNumDoc.Text = registro.NumDoc
            txtSerieDoc.Text = registro.SerDoc
            If Not (registro.FecDoc.ToString = "") Then
                txtFecDoc.Value = CDate(registro.FecDoc)
                txtFecDoc.Text = registro.FecDoc.ToString
            End If



        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGrabar_Click(sender As Object, e As EventArgs) Handles biGrabar.Click


        Try
            If ValidaCampos() Then

                Dim registro As New EmbarqueService.EmbarqueGastos
                Dim embarque As New EmbarqueService.Embarque
                Dim tipo As New EmbarqueService.TipoGastoImportacion
                Dim moneda As New EmbarqueService.Moneda
                Dim proveedor As New EmbarqueService.Proveedor

                Dim TipoDocumento As New EmbarqueService.TipoDocumento

                registro.IdGastoEmb = IdGastoEmb
                embarque.CodEmbarque = CodEmbarque
                registro.Embarque = embarque

                tipo.IdTipo = cmbTipoGasto.Value
                registro.TipoGastoImportacion = tipo

                proveedor.IdProveedor = IdProveedor
                registro.Proveedor = proveedor

                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.Monto = txtMonto.Value

                registro.Observacion = txtDescripcion.Text

                If toNumber(cmbTipoDoc.Value) = 0 Then
                    TipoDocumento.IdDocumento = Nothing
                    registro.TipoDocumento = TipoDocumento
                Else
                    TipoDocumento.IdDocumento = cmbTipoDoc.Value
                    registro.TipoDocumento = TipoDocumento
                End If

                If Len(Trim(txtSerieDoc.Text)) > 0 Then
                    SerieDoc()
                End If
                If Len(Trim(txtNumDoc.Text)) > 0 Then
                    NumDoc()
                End If
                registro.NumDoc = toNull(txtNumDoc.Text)
                registro.SerDoc = toNull(txtSerieDoc.Text)
                registro.FecDoc = IIf(txtFecDoc.Text = "", Nothing, txtFecDoc.Value)


                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                '-------------------------------------------------------------------------------------------


                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As EmbarqueService.EmbarqueGastos)
        Try
            Dim estado_process As Int64
            estado_process = oEmbarqueService.InsertarGasto(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdGastoEmb = estado_process
                MsgBox("Se insertó el Gasto Correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL GASTO DE IMPORTACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EmbarqueService.EmbarqueGastos)
        Try
            Dim estado_process As Boolean
            estado_process = oEmbarqueService.ActualizarGasto(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Gasto Correctamente")
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL GASTO DE IMPORTACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


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
            ElseIf toNumber(cmbTipoGasto.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Gasto", MsgBoxStyle.Information, "Información")
                cmbTipoGasto.Focus()
                Return False

            ElseIf toNumber(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Text) = "" Then
                MsgBox("Debe Seleccionar la moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditar_Click(sender As Object, e As EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub activar()

        If state_button Then
            cmbTipoGasto.ReadOnly = True
            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
        Else
            cmbTipoGasto.ReadOnly = False
            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
        End If
        btnBuscarProveedor.Enabled = True
        btnAgregarProveedor.Enabled = True
        btnLimpiarProveedor.Enabled = True

        cmbTipoDoc.ReadOnly = False
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
        txtSerieDoc.ReadOnly = False
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        txtNumDoc.ReadOnly = False
        txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        txtFecDoc.ReadOnly = False
        txtFecDoc.BackColor = System.Drawing.SystemColors.Window

        cmbMoneda.ReadOnly = False
        cmbMoneda.BackColor = System.Drawing.SystemColors.Window
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        edicion = True
        enableOpciones()

    End Sub

    Private Sub desactivar()

        cmbTipoGasto.ReadOnly = True
        cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = False
        btnAgregarProveedor.Enabled = False
        btnLimpiarProveedor.Enabled = False

        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control

        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()

    End Sub

    Private Sub enableOpciones()

        biEditar.Enabled = Not edicion 'IIf(editable, Not edicion, False)
        biSalir.Enabled = Not edicion
        biGrabar.Enabled = edicion
        biDeshacer.Enabled = edicion
        'cmOpciones.Enabled = IIf(lblEstado.Text <> "", Not edicion, False)
    End Sub

    Private Sub biDeshacer_Click(sender As Object, e As EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

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
            'cmbTipoDoc.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al Limpiar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

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

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub

    Private Sub txtFecDoc_ValueChanged(sender As Object, e As System.EventArgs) Handles txtFecDoc.ValueChanged
        If toBlank(txtFecDoc.Value) <> "" Then
            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecDoc.Value)), "#0.000")
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            biGrabar.Select()
            biGrabar_Click(sender, e)
            'If biGrabar.Enabled = True Then
            '    biGrabar.Select()
            '    biGrabar_Click(sender, e)
            'Else
            '    dgvDatos.Select()
            'End If


        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cmbTipoGasto.KeyPress, cmbTipoDoc.KeyPress, txtSerieDoc.KeyPress, txtNumDoc.KeyPress,
                        txtFecDoc.KeyPress, cmbMoneda.KeyPress, txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class