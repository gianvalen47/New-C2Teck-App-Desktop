Imports System.ServiceModel
Public Class frmCuotaVendedor

    '=========================== Servicios ====================================
    Private oCuotaVendedorService As New CuotaVendedorService.CuotaVendedorServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public CodEmp As String
    Public Periodo As Integer
    Public Mes As Integer
    Public CodProducto As String
    Public IdPer As Integer

    Private dtMeses As New DataTable
    Private dtVendedor As DataTable
    Private dtTipoProducto As DataTable


    Private Sub frmCuotaVendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCuotaVendedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()            
            txtAnio.Focus()
        Else                                      'Nuevo            
            activar()
            txtAnio.Value = Today.Year
            cmbMes.Value = Today.Month
            txtAnio.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmCuotaVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oCuotaVendedorService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oCuotaVendedorService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oCuotaVendedorService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtAnio.Value) = 0 Then
                MsgBox("Debe ingresar el Periodo de la Cuota", MsgBoxStyle.Information, "Información")
                txtAnio.Focus()
                Return False
            ElseIf toNumber(cmbMes.Value) = 0 Then
                MsgBox("Debe ingresar el Mes de la Cuota", MsgBoxStyle.Information, "Información")
                cmbMes.Focus()
                Return False
            ElseIf toNumber(cmbVendedor.Value) = 0 Then
                MsgBox("Debe ingresar el Vendedor de la Cuota", MsgBoxStyle.Information, "Información")
                cmbVendedor.Focus()
                Return False
            ElseIf toBlank(cmbTipoProducto.Value) = "" Then
                MsgBox("Debe ingresar el Tipo de Producto de la Cuota", MsgBoxStyle.Information, "Información")
                cmbTipoProducto.Focus()
                Return False
            ElseIf toDouble(txtMonto.Value) = 0 Then
                MsgBox("Debe ingresar el Monto de la Cuota", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtAnio.ReadOnly = False
        txtAnio.BackColor = System.Drawing.SystemColors.Window
        cmbMes.ReadOnly = False
        cmbMes.BackColor = System.Drawing.SystemColors.Window
        cmbVendedor.ReadOnly = False
        cmbVendedor.BackColor = System.Drawing.SystemColors.Window
        cmbTipoProducto.ReadOnly = False
        cmbTipoProducto.BackColor = System.Drawing.SystemColors.Window
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtAnio.ReadOnly = True
        txtAnio.BackColor = System.Drawing.SystemColors.Control
        cmbMes.ReadOnly = True
        cmbMes.BackColor = System.Drawing.SystemColors.Control
        cmbVendedor.ReadOnly = True
        cmbVendedor.BackColor = System.Drawing.SystemColors.Control
        cmbTipoProducto.ReadOnly = True
        cmbTipoProducto.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As CuotaVendedorService.CuotaVendedor)
        Try
            Dim estado_process As String
            estado_process = oCuotaVendedorService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                'CodCargo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CUOTA DE VENDEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CuotaVendedorService.CuotaVendedor)
        Try
            Dim estado_process As Boolean
            estado_process = oCuotaVendedorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CUOTA DE VENDEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CuotaVendedorService.CuotaVendedor
            registro = oCuotaVendedorService.Obtener(CodEmp, Periodo, Mes, CodProducto, IdPer)

            CodEmp = registro.Empresa.CodEmp
            Periodo = registro.Periodo
            txtAnio.Value = registro.Periodo
            Mes = registro.Mes
            cmbMes.Value = registro.Mes
            CodProducto = registro.TipoProducto.CodProducto
            cmbTipoProducto.Value = registro.TipoProducto.CodProducto
            IdPer = registro.Persona.IdPer
            cmbVendedor.Value = registro.Persona.IdPer
            txtMonto.Value = registro.Monto            

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            'dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing

            '======================================= TIPO PRODUCTO ================================================
            dtTipoProducto = oCuotaVendedorService.MostrarTipoProducto().Tables(0)
            'dtTipoProducto.Rows.InsertAt(getRowTodos(dtTipoProducto), 0)
            cmbTipoProducto.DataSource = dtTipoProducto
            cmbTipoProducto.DropDownList.DataMember = dtTipoProducto.Columns("DesProducto").ToString
            cmbTipoProducto.DropDownList.DisplayMember = dtTipoProducto.Columns("DesProducto").ToString
            cmbTipoProducto.DropDownList.ValueMember = dtTipoProducto.Columns("CodProducto").ToString
            cmbTipoProducto.DropDownList.Columns(0).DataMember = dtTipoProducto.Columns("CodProducto").ToString
            cmbTipoProducto.DropDownList.Columns(1).DataMember = dtTipoProducto.Columns("DesProducto").ToString
            cmbTipoProducto.SelectedIndex = 0
            dtTipoProducto = Nothing

            '======================================= Vendedor ===========================================
            dtVendedor = oPersonaService.MostrarVendedoresVigente(Session.sCodEmp).Tables(0)
            'dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            cmbVendedor.DataSource = dtVendedor
            cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedor.SelectedIndex = 0
            dtVendedor = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New CuotaVendedorService.CuotaVendedor
                Dim empresa As New CuotaVendedorService.Empresa
                Dim tipoproducto As New CuotaVendedorService.TipoProducto
                Dim vendedor As New CuotaVendedorService.Persona

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.Periodo = txtAnio.Value
                registro.Mes = toNumber(cmbMes.Value)
                tipoproducto.CodProducto = toBlank(cmbTipoProducto.Value)
                registro.TipoProducto = tipoproducto
                vendedor.IdPer = toNumber(cmbVendedor.Value)
                registro.Persona = vendedor
                registro.Monto = txtMonto.Value

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR CUOTA DE VENDEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtAnio.KeyPress _
                           , cmbMes.KeyPress _
                           , cmbVendedor.KeyPress _
                           , cmbTipoProducto.KeyPress _
                           , txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class