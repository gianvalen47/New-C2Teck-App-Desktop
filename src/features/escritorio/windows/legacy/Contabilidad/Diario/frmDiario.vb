Imports System.ServiceModel
Public Class frmDiario

    '===========================Servicios====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oContabilidadDetService As New ContabilidadDetService.ContabilidadDetServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Public IdContabilidad As Integer                ' Id del Registro Diario      
    Private dtMonedas As DataTable
    Private dtTipDocumento As DataTable
    Private dtDatos As DataTable
    Private dtTipo As DataTable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True                   'True: Editable     False: No Editable 

    Private CodMon As String
    Private TipCambio As Decimal
    Private DirFile As String
    Private fileExt As String
    Private dtDatosExcel As DataTable


    Private Sub frmDiario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmDiario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oContabilidadService.Close()
            oContabilidadDetService.Close()
            oCuentaContableService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 175)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        LlenarCombos()
        txtDesCuenta.Text = ""

        txtPeriodo.Value = Today.Year
        cmbTipoLibro.Value = 5
        txtMesRegistro.Text = Format(Month(Today), "00")
        'cmbTipo.Value = 2
        ObtenerNumRegistro()
        state_button = False
        Desactivar()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdContabilidadDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdContabilidadDet").Text
                End If
            End If
            dtDatos = Nothing
            ObtenerRegistro()
            listaDatos()            
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        txtPeriodo.ReadOnly = False
        txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        cmbTipoLibro.ReadOnly = False
        cmbTipoLibro.BackColor = System.Drawing.SystemColors.Window
        txtMesRegistro.ReadOnly = False
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
        txtNumRegistro.ReadOnly = False
        txtNumRegistro.BackColor = System.Drawing.SystemColors.Window
        btnBuscarRegistro.Enabled = True


        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtTipCambio.ReadOnly = True
        txtTipCambio.BackColor = System.Drawing.SystemColors.Control

        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtGlosa.ReadOnly = True
        txtGlosa.BackColor = System.Drawing.SystemColors.Control

        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control


        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control

        rbAnulado.Enabled = False

        edicion = False
        enableOpciones()
    End Sub

    Private Sub Activar()
        If state_button Then
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            cmbTipoLibro.ReadOnly = True
            cmbTipoLibro.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarRegistro.Enabled = True
            biImportarImportaciones.Enabled = False
            biImportarVenta.Enabled = False
            biImportarCostos.Enabled = False

            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window

            txtNombre.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window

            rbAnulado.Enabled = True

            If dgvDatos.RowCount > 0 Then
                txtTipCambio.ReadOnly = True
                txtTipCambio.BackColor = System.Drawing.SystemColors.Control
                cmbMoneda.ReadOnly = True
                cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            Else
                txtTipCambio.ReadOnly = False
                txtTipCambio.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            End If

            cmbTipo.ReadOnly = False
            cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Else
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            cmbTipoLibro.ReadOnly = True
            cmbTipoLibro.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarRegistro.Enabled = True
            biImportarImportaciones.Enabled = True
            biImportarVenta.Enabled = True
            biImportarCostos.Enabled = True

            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window

            If toNumber(txtMesRegistro.Text) = Month(Today) And txtPeriodo.Value = Year(Today) Then
                txtFecha.Value = Today
                txtFecha.Text = Today
            Else
                txtFecha.Value = DateSerial(txtPeriodo.Value, toNumber(txtMesRegistro.Text) + 1, 0)
                txtFecha.Text = CStr(DateSerial(txtPeriodo.Value, toNumber(txtMesRegistro.Text) + 1, 0))
            End If
            'txtFecha.Value = Today
            'txtFecha.Text = Today

            txtTipCambio.ReadOnly = False
            txtTipCambio.BackColor = System.Drawing.SystemColors.Window

            txtNombre.ReadOnly = False
            txtNombre.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window

            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.Value = "NS"

            cmbTipo.ReadOnly = False
            cmbTipo.BackColor = System.Drawing.SystemColors.Window
            cmbTipo.Value = 2


            rbAnulado.Enabled = True
            rbAnulado.Checked = False

            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Value)), "#0.000")
        End If

        txtFecha.Focus()

        edicion = True
        enableOpciones()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miDuplicar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(editable, True, False)
            miDuplicar.Enabled = IIf(editable, True, False)
        End If
        miNuevo.Enabled = IIf(editable, True, False)

        biEditar.Enabled = IIf(editable, Not edicion And IdContabilidad <> 0, False)
        biSalir.Enabled = Not edicion
        biImprimir.Enabled = IIf(Not edicion, True, False)
        'biImportar.Enabled = IIf(Not edicion And IdCompra = 0, True, False)
        biEliminar.Enabled = IIf(Not edicion And IdContabilidad <> 0, True, False)
        biImportarImportaciones.Enabled = IIf(edicion And IdContabilidad = 0, True, False)
        biImportarVenta.Enabled = IIf(edicion And IdContabilidad = 0, True, False)
        biImportarCostos.Enabled = IIf(edicion And IdContabilidad = 0, True, False)
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion And IdContabilidad <> 0, True, False)
    End Sub

    Private Sub ObtenerNumRegistro()
        Try
            txtNumRegistro.Text = oContabilidadService.ObtenerRegistro(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, cmbTipoLibro.Value)
            txtNumRegistro.Focus()
            txtNumRegistro.SelectAll()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER Nº  DE REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As New ContabilidadService.Contabilidad
            registro = oContabilidadService.Obtener(IdContabilidad)

            IdContabilidad = registro.IdContabilidad
            txtPeriodo.Value = registro.Periodo
            cmbTipoLibro.Value = registro.TipoLibro.IdLibro
            txtMesRegistro.Text = registro.Mes
            txtNumRegistro.Text = registro.NumRegistro

            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtTipCambio.Value = registro.TipCam

            txtNombre.Text = registro.Nombre
            txtGlosa.Text = registro.Glosa

            cmbMoneda.Value = registro.Moneda.CodMon
            rbAnulado.Checked = registro.Anulado

            txtTotalDebeSol.Value = registro.TotalDebeSol
            txtTotalHaberSol.Value = registro.TotalHaberSol

            txtTotalDebeDol.Value = registro.TotalDebeDol
            txtTotalHaberDol.Value = registro.TotalHaberDol

            cmbTipo.Value = registro.Tipo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
            '===================================TIPO DE LIBRO ===========================================
            dtTipDocumento = oContabilidadService.MostrarTipoLibros.Tables(0)
            'dtTipDocumento.Rows.InsertAt(getRowTodos1(dtMonedas), 0)            
            cmbTipoLibro.DataSource = dtTipDocumento
            cmbTipoLibro.DropDownList.DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.DisplayMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.ValueMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoLibro.DropDownList.Columns(0).DataMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoLibro.DropDownList.Columns(1).DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.Columns(2).DataMember = dtTipDocumento.Columns("DesLibro").ToString
            cmbTipoLibro.SelectedIndex = 0
            dtTipDocumento = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos1(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.SelectedIndex = 0
            dtMonedas = Nothing

            '=======================================TIPO===============================================
            dtTipo = MostrarTipo()
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("Descripcion").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("Descripcion").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("Tipo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("Tipo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("Descripcion").ToString
            'cmbMoneda.SelectedIndex = 0
            dtTipo = Nothing






        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar()
        IdContabilidad = 0

        txtFecha.IsNullDate = True
        txtTipCambio.Value = 0

        txtNombre.Text = ""
        txtGlosa.Text = ""

        cmbMoneda.SelectedIndex = 0
        rbAnulado.Checked = False

        cmbTipo.Value = 2

        dgvDatos.DataSource = Nothing
        txtTotalDebeSol.Value = 0
        txtTotalDebeDol.Value = 0

        txtTotalHaberDol.Value = 0
        txtTotalHaberSol.Value = 0

        txtDesCuenta.Text = ""
    End Sub

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el Registro Nº : " + txtMesRegistro.Text + " - " + txtNumRegistro.Text + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContabilidadService.Borrar(IdContabilidad, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Limpiar()
                    ObtenerNumRegistro()
                    state_button = False
                    Desactivar()
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL REGISTRO DIARIO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ContabilidadService.Contabilidad)
        Try
            Dim estado_process As Integer
            estado_process = oContabilidadService.Insertar(registro)
            If estado_process > 0 Then
                IdContabilidad = estado_process
                MsgBox("Se insertó el Registro Diario Correctamente.")
                Desactivar()
                ObtenerRegistro()                
                state_button = True
                enableOpciones()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR REGISTRO DIARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContabilidadService.Contabilidad)
        Try
            Dim estado_process As Boolean
            estado_process = oContabilidadService.Actualizar(registro)
            If estado_process = True Then
                ObtenerRegistro()
                enableOpciones()
                Desactivar()
                state_button = True
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR REGISTRO DIARIO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtMesRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el número de Comprobante.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toNumber(txtNumRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el número de Comprobante.", MsgBoxStyle.Information, "Información")
                txtNumRegistro.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toDouble(txtTipCambio.Value) <= 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
                Return False
            ElseIf toBlank(txtNombre.Text) = "" Then
                MsgBox("Debe Ingresar el Nombre.", MsgBoxStyle.Information, "Información")
                txtNombre.Focus()
                Return False
                'ElseIf toBlank(txtGlosa.Text) = "" Then
                '    MsgBox("Debe Ingresar la Glosa.", MsgBoxStyle.Information, "Información")
                '    txtGlosa.Focus()
                '    Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'ElseIf rbActivo.Checked = False And rbAnulado.Checked = False Then
                '    MsgBox("Debe Ingresar el Estado.", MsgBoxStyle.Information, "Información")
                '    rbActivo.Focus()
                '    Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub cmbTipoDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoLibro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            ObtenerNumRegistro()
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtMesRegistro.Text)
                If cant < 2 Then
                    txtMesRegistro.Text = "0" & txtMesRegistro.Text
                End If
                If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                    MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                Else
                    ObtenerNumRegistro()
                End If
            Else
                MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumRegistro_EnabledChanged(sender As Object, e As System.EventArgs) Handles txtNumRegistro.EnabledChanged

    End Sub

    Private Sub txtNumRegistro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumRegistro.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarRegistro.Enabled = True Then
                e.Handled = True
                btnBuscarRegistro_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtNumRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtNumRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistro.Text)
                Do While cant < 6
                    txtNumRegistro.Text = "0" & txtNumRegistro.Text
                    cant = cant + 1
                Loop
                If oContabilidadService.Buscar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, cmbTipoLibro.Value, txtNumRegistro.Text) Then
                    IdContabilidad = oContabilidadService.ObtenerIdContabilidad(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, cmbTipoLibro.Value, txtNumRegistro.Text)
                    state_button = True 'Modificar
                    edicion = False
                    ObtenerRegistro()
                    actualizarDetalles()
                    Desactivar()
                    txtNumRegistro.SelectAll()
                Else
                    state_button = False 'Nuevo 
                    edicion = True
                    Limpiar()
                    Activar()
                    txtFecha.Focus()
                End If
            Else
                MsgBox("Debe ingresar el Numero de Registro.", MsgBoxStyle.Critical, "No Existe")
                txtNumRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtTipCambio.Focus()
        End If
    End Sub

    Private Sub txtTipCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipCambio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNombre.Focus()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtGlosa.Focus()
        End If
    End Sub

    Private Sub txtGlosa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oContabilidadDetService.Mostrar(toNumber(IdContabilidad)).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()

            If dgvDatos.RowCount > 0 Then
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
                'InhabilitarColumnas()
            Else
                txtDesCuenta.Text = ""
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then
                Dim registro As New ContabilidadService.Contabilidad
                'Dim TipoDocumento As New ContabilidadService.TipoDocumento
                Dim Moneda As New ContabilidadService.Moneda
                Dim Empresa As New ContabilidadService.Empresa
                Dim RegistroCompra As New ContabilidadService.RegistroCompra
                Dim TipoLibro As New ContabilidadService.TipoLibro

                registro.IdContabilidad = IdContabilidad
                RegistroCompra.IdCompra = Nothing
                registro.RegistroCompra = RegistroCompra
                TipoLibro.IdLibro = cmbTipoLibro.Value
                registro.TipoLibro = TipoLibro
                registro.Mes = txtMesRegistro.Text
                registro.NumRegistro = txtNumRegistro.Text

                registro.Fecha = txtFecha.Value
                registro.TipCam = txtTipCambio.Value

                registro.Nombre = txtNombre.Text
                registro.Glosa = txtGlosa.Text

                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.Anulado = IIf(rbAnulado.Checked = True, True, False)

                Empresa.CodEmp = Session.sCodEmp
                registro.Empresa = Empresa
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.Periodo = txtPeriodo.Value
                registro.Tipo = cmbTipo.Value

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        Limpiar()
        ObtenerNumRegistro()
        Desactivar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRegistro.Click
        Try
            Dim frm As New frmBuscarDiario
            frm.txtMesRegistro.Text = txtMesRegistro.Text
            frm.txtPeriodo.Value = txtPeriodo.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.IdContabilidad) <> Nothing Then
                    IdContabilidad = frm.IdContabilidad
                    ObtenerRegistro()
                    actualizarDetalles()
                    state_button = True
                    edicion = False
                    Desactivar()
                Else
                    IdContabilidad = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Registro de Diario : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtNumRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistro.Click
        ObtenerNumRegistro()
        state_button = False
        Limpiar()
        Desactivar()
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If IdContabilidad = 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Nuevo()
        Try
            Dim frm As New frmDiarioDet
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.IdContabilidad = IdContabilidad
            frm.CodLibro = cmbTipoLibro.Value
            frm.CodMon = cmbMoneda.Value
            frm.TipoCambio = txtTipCambio.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdContabilidadDet)
                    Mostrar()
                    actualizarDetalles()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmDiarioDet
            frm.state_button = True
            frm.IdContabilidadDet = dgvDatos.CurrentRow.Cells("IdContabilidadDet").Value
            frm.IdContabilidad = IdContabilidad
            frm.CodLibro = cmbTipoLibro.Value
            frm.CodMon = cmbMoneda.Value
            frm.TipoCambio = txtTipCambio.Value
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then

                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdContabilidadDet)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            ObtenerRegistro()
            actualizarDetalles()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContabilidadDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdContabilidadDet").Text), IdContabilidad, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionadoDet() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.CurrentCellChanged
        If dgvDatos.RowCount > 0 Then
            If dgvDatos.Col = 11 Then
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("Nombre").Text)
            Else
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
            End If
        Else
            txtDesCuenta.Text = ""
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionadoDet() Then
            Mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Function ValidaCodigoSeleccionadoDet() As Boolean
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

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        'If dgvDatos.RowCount > 0 Then
        '    txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
        'Else
        '    txtDesCuenta.Text = ""
        'End If
    End Sub

    Private Sub txtTotalDebeNS_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalDebeSol.ValueChanged, txtTotalHaberSol.ValueChanged
        txtDiferenciaSol.Value = txtTotalDebeSol.Value - txtTotalHaberSol.Value
    End Sub

    Private Sub txtTotalDebeUS_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalDebeDol.ValueChanged, txtTotalHaberDol.ValueChanged
        txtDiferenciaDol.Value = txtTotalDebeDol.Value - txtTotalHaberDol.Value
    End Sub

    Private Sub cmbTipoDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoLibro.ValueChanged
        ObtenerNumRegistro()
        cmbTipoLibro.Focus()
    End Sub

    Private Sub miDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDuplicar.Click
        If ValidaCodigoSeleccionadoDet() Then
            Duplicar()
        End If
    End Sub

    Private Sub Duplicar()
        Try
            Dim estado_process As Integer
            Dim IdContabilidadDet As Integer
            estado_process = oContabilidadDetService.Duplicar(toNumber(dgvDatos.CurrentRow.Cells("IdContabilidadDet").Value), IdContabilidad, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process > 0 Then
                IdContabilidadDet = estado_process
                ObtenerRegistro()
                listaDatos()
                RowPossesion(dgvDatos, IdContabilidadDet)
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If         
        Catch ex As Exception
            MsgBox("ERROR AL DUPLICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbTipoLibro.Focus()
        End If
    End Sub

    Private Sub txtMesRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Validated
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtMesRegistro.Text)
            If cant < 2 Then
                txtMesRegistro.Text = "0" & txtMesRegistro.Text
            End If
            If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
            Else
                ObtenerNumRegistro()
            End If
        Else
            MsgBox("Debe ingresar el Mes de Registro.", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        If toBlank(txtFecha.Text) <> "" Then
            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Value)), "#0.000")
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptDiario

            If IdContabilidad <> 0 Then
                dtReporte = oContabilidadService.Imprimir(IdContabilidad).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'reporte.SetParameterValue("pIdMesa", 0)
                    forma.Text = "Reporte de Diario"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Número de Registro Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biImportarImportaciones_Click(sender As System.Object, e As System.EventArgs) Handles biImportarImportaciones.Click

        Try
            If ValidaCampos() Then
                Dim frm As New frmDiario_ImportarImportaciones
                'frm.IdGasto = toNumber(txtNumGasto.Text)
                'frm.CodMon = cmbMoneda.Value
                frm.IdContabilidad = 0
                frm.Periodo = txtPeriodo.Value
                frm.ITipoLibro = cmbTipoLibro.Value
                frm.MesRegistro = txtMesRegistro.Text
                frm.NumRegistro = txtNumRegistro.Text
                frm.Fecha = txtFecha.Value
                frm.TipoCambio = txtTipCambio.Value
                frm.Nombre = txtNombre.Text
                frm.Glosa = txtGlosa.Text
                frm.IMoneda = cmbMoneda.Value
                frm.Anulado = IIf(rbAnulado.Checked = True, True, False)

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    If toNull(frm.Idcontabilidad) <> Nothing Then
                        IdContabilidad = frm.IdContabilidadDet
                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdContabilidad = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR la importación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dgvDatos_FormattingRow(sender As System.Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles dgvDatos.FormattingRow

    End Sub

    Private Sub biImportarVenta_Click(sender As Object, e As EventArgs) Handles biImportarVenta.Click
        Try
            If ValidaCampos() Then
                Dim frm As New frmDiario_ImportarVentas
                'frm.IdGasto = toNumber(txtNumGasto.Text)
                'frm.CodMon = cmbMoneda.Value
                frm.IdContabilidad = 0
                frm.Periodo = txtPeriodo.Value
                frm.ITipoLibro = cmbTipoLibro.Value
                frm.MesRegistro = txtMesRegistro.Text
                frm.Periodo = txtPeriodo.Text
                frm.NumRegistro = txtNumRegistro.Text
                frm.Fecha = txtFecha.Value
                frm.TipoCambio = txtTipCambio.Value
                frm.Nombre = txtNombre.Text
                frm.Glosa = txtGlosa.Text
                frm.IMoneda = cmbMoneda.Value
                frm.Anulado = IIf(rbAnulado.Checked = True, True, False)

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    If toNull(frm.IdContabilidad) <> Nothing Then
                        IdContabilidad = frm.IdContabilidadDet
                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdContabilidad = 0
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR la importación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImportarCostos_Click(sender As Object, e As EventArgs) Handles biImportarCostos.Click
        Try
            'If ValidaCampos() Then
            Dim frm As New frmDiario_ImportarCostos
            'frm.IdGasto = toNumber(txtNumGasto.Text)
            'frm.CodMon = cmbMoneda.Value
            frm.IdContabilidad = 0
                frm.Periodo = txtPeriodo.Value
                frm.ITipoLibro = cmbTipoLibro.Value
                frm.MesRegistro = txtMesRegistro.Text
                frm.Periodo = txtPeriodo.Text
                frm.NumRegistro = txtNumRegistro.Text
                frm.Fecha = txtFecha.Value
                frm.TipoCambio = txtTipCambio.Value
                frm.Nombre = txtNombre.Text
                frm.Glosa = txtGlosa.Text
                frm.IMoneda = cmbMoneda.Value
                frm.Anulado = IIf(rbAnulado.Checked = True, True, False)

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    If toNull(frm.IdContabilidad) <> Nothing Then
                        IdContabilidad = frm.IdContabilidadDet
                        ObtenerRegistro()
                        actualizarDetalles()
                        state_button = True
                        edicion = False
                        Desactivar()
                    Else
                        IdContabilidad = 0
                    End If
                End If
            'End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR la importación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miImportarDocs_Click(sender As Object, e As EventArgs) Handles miImportarDocs.Click
        Try
            If ValidaCampos() Then
                Dim frm As New frmDiarioBuscarDoc
                'frm.IdGasto = toNumber(txtNumGasto.Text)
                'frm.CodMon = cmbMoneda.Value
                frm.IdContabilidad = IdContabilidad

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizarDetalles()
                    state_button = True
                    edicion = False
                    Desactivar()

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR la importación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function MostrarTipo() As DataTable

        Try

            Dim Tabla As DataTable
            Tabla = New DataTable("Tipos")
            Tabla.Columns.Add("Tipo", GetType(Integer))
            Tabla.Columns.Add("Descripcion", GetType(String))
            Dim Fila As DataRow


            Fila = Tabla.NewRow
            Fila("Tipo") = 1
            Fila("Descripcion") = "Asiento de Apertura"
            Tabla.Rows.Add(Fila)


            Fila = Tabla.NewRow
            Fila("Tipo") = 2
            Fila("Descripcion") = "Asiento Operativo"
            Tabla.Rows.Add(Fila)

            Fila = Tabla.NewRow
            Fila("Tipo") = 3
            Fila("Descripcion") = "Asiento de Cierre"
            Tabla.Rows.Add(Fila)

            Fila = Tabla.NewRow
            Fila("Tipo") = 6
            Fila("Descripcion") = "Asiento Diferencia Cambio"
            Tabla.Rows.Add(Fila)

            Return Tabla
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub miFormatoExcel_Click(sender As Object, e As EventArgs) Handles miFormatoExcel.Click
        FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")

        dtExcel.Columns.Add(New DataColumn("CodCuenta", Type.GetType("System.String")))
        'dtExcel.Columns.Add(New DataColumn("NumJob", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodTipMov", Type.GetType("System.String")))
        'dtExcel.Columns.Add(New DataColumn("CodCuentaDest", Type.GetType("System.String")))

        dtExcel.Columns.Add(New DataColumn("CodTipoDocumento", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("SerieDoc", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("NumDoc", Type.GetType("System.String")))

        dtExcel.Columns.Add(New DataColumn("IdProveedor", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("IdCliente", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("IdPersona", Type.GetType("System.Int32")))

        dtExcel.Columns.Add(New DataColumn("MontoSol", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("MontoDol", Type.GetType("System.Double")))

        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"", "", "0", "", "", "0", "0", "0", "0.00", "0.00", ""})

        dgvFormatoExcel.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcel)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub miImportarExcel_Click(sender As Object, e As EventArgs) Handles miImportarExcel.Click
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
                Dim mensaje As String = ""
                Dim Item As Integer = 0
                Dim CodJobDet As String = ""
                Dim CodCuentaDest As String = ""
                Dim nrodocform As String = ""
                Dim seriedocform As String = ""
                Dim observaciondet As String = ""
                CodMon = cmbMoneda.Value
                TipCambio = CDec(txtTipCambio.Text)


                If dgvImportarExcel.RowCount > 0 Then
                    For Each fila As DataGridViewRow In dgvImportarExcel.Rows

                        Dim registro As New ContabilidadDetService.ContabilidadDet
                        Dim Contabilidad As New ContabilidadDetService.Contabilidad
                        Dim CuentaContable As New ContabilidadDetService.CuentaContable
                        Dim CuentaContableDest As New ContabilidadDetService.CuentaContable
                        'Dim CentroCosto As New ContabilidadDetService.CentroCosto
                        'Dim Area As New ContabilidadDetService.Area
                        Dim Job As New ContabilidadDetService.Job
                        Dim Proveedor As New ContabilidadDetService.Proveedor
                        Dim Persona As New ContabilidadDetService.Persona
                        Dim TipoDocumento As New ContabilidadDetService.TipoDocumento
                        Dim cliente As New ContabilidadDetService.Cliente

                        registro.IdContabilidadDet = 0
                        Contabilidad.IdContabilidad = IdContabilidad
                        registro.Contabilidad = Contabilidad

                        CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, fila.Cells("CodCuenta").Value)
                        CuentaContable.CodCuenta = fila.Cells("CodCuenta").Value
                        registro.CuentaContable = CuentaContable

                        Job.CodJob = Nothing
                        registro.Job = Job

                        registro.TipMov = fila.Cells("CodTipMov").Value  'cmbTipoMov.Value

                        CuentaContableDest.IdCuenta = Nothing
                        CuentaContableDest.CodCuenta = Nothing
                        registro.CuentaContableDest = CuentaContableDest

                        TipoDocumento.IdDocumento = toNumber(fila.Cells("CodTipoDocumento").Value) '  cmbTipoDoc.Value
                        registro.TipoDocumento = TipoDocumento


                        If IsDBNull(fila.Cells("SerieDoc").Value) Then
                            seriedocform = ""
                        Else
                            seriedocform = FormatoSerieDoc(fila.Cells("SerieDoc").Value)
                        End If

                        If IsDBNull(fila.Cells("NumDoc").Value) Then
                            nrodocform = ""
                        Else
                            nrodocform = FormatoNroDoc(fila.Cells("NumDoc").Value)
                        End If

                        'registro.SerDoc = IIf(fila.Cells("SerieDoc").Value = "", Nothing, fila.Cells("SerieDoc").Value) 'IIf(txtSerieDoc.Text = "", Nothing, txtSerieDoc.Text)
                        registro.SerDoc = IIf(seriedocform = "", Nothing, seriedocform) 'IIf(txtSerieDoc.Text = "", Nothing, txtSerieDoc.Text)
                        registro.NumDoc = nrodocform 'fila.Cells("NumDoc").Value
                        Proveedor.IdProveedor = IIf(toNumber(fila.Cells("IdProveedor").Value) = 0, Nothing, fila.Cells("IdProveedor").Value)  'IIf(toNumber(IdProveedor) = 0, Nothing, IdProveedor)
                        registro.Proveedor = Proveedor

                        cliente.IdCliente = IIf(toNumber(fila.Cells("IdCliente").Value) = 0, Nothing, fila.Cells("IdCliente").Value)   'IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
                        registro.Cliente = cliente

                        Persona.IdPer = IIf(fila.Cells("IdPersona").Value = 0, Nothing, fila.Cells("IdPersona").Value)   'IIf(IdPersona = 0, Nothing, IdPersona)
                        registro.Persona = Persona

                        If CodMon = "NS" Then
                            registro.MontoSol = fila.Cells("MontoSol").Value
                            registro.MontoDol = Math.Round((fila.Cells("MontoSol").Value / TipCambio), 2)
                        ElseIf CodMon = "US" Then
                            registro.MontoDol = fila.Cells("MontoDol").Value
                            registro.MontoSol = Math.Round((fila.Cells("MontoDol").Value * TipCambio), 2)
                        End If

                        observaciondet = ""

                        If IsDBNull(fila.Cells("Observacion").Value) Then
                            observaciondet = ""
                        Else
                            observaciondet = fila.Cells("Observacion").Value
                        End If

                        registro.Observacion = observaciondet

                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.NomPc = Session.sNomPc
                        registro.FecReg = Today

                        estado_process = oContabilidadDetService.Insertar(registro)

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

    Private Function FormatoNroDoc(ByVal a As String)

        If Len(Trim(a)) > 0 Then
            Dim cant As Integer = Len(a)
            Do While cant < 8
                a = "0" & a
                cant = cant + 1
            Loop

        End If

        Return a

    End Function

    Private Function FormatoSerieDoc(ByVal d As String)

        If Len(Trim(d)) > 0 Then
            Dim cant As Integer = Len(d)
            Do While cant < 4
                d = "0" & d
                cant = cant + 1
            Loop

        End If

        Return d

    End Function

    Private Sub miImportarDocsTesoreria_Click(sender As Object, e As EventArgs) Handles miImportarDocsTesoreria.Click
        Try
            If ValidaCampos() Then
                Dim frm As New frmDiarioBuscarDocTesoreria
                'frm.IdGasto = toNumber(txtNumGasto.Text)
                'frm.CodMon = cmbMoneda.Value
                frm.IdContabilidad = IdContabilidad

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizarDetalles()
                    state_button = True
                    edicion = False
                    Desactivar()

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbMoneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub

End Class