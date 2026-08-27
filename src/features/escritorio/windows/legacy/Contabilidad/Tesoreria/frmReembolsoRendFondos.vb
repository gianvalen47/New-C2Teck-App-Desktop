Imports System.ServiceModel
Public Class frmReembolsoRendFondos

    '===========================Servicios====================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oReembolsoCajaService As New ReembolsoCajaService.ReembolsoCajaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient

    '======================Declaración de Variables=============================   
    Public IdTesoreriaDet As Integer      'IdTesoreriaDet obtenido de frmPendientesRendFondos
    Public IdCuenta As Integer              'IdCuenta obtenido de frmPendientesRendFondos
    Public CodCuenta As String            'CodCuenta obtenido de frmPendientesRendFondos
    Public IdDocumento As Integer        'IdDocumento obtenido de frmPendientesRendFondos
    Public SerDoc As String                  'SerDoc obtenido de frmPendientesRendFondos
    Public NumDoc As String                'NumDoc obtenido de frmPendientesRendFondos
    Public MontoOriginal As Double       'MontoOriginal obtenido frmPendientesRendFondos
    Public CodMon As String                 'CodMon obtenido frmPendientesRendFondos
    Public IdPersona As Integer             'IdPersona obtenido de frmPendientesRendFondos
    Public Nombre As String
    Public Glosa As String
    Public IdReembolso As Integer
    Private dtMonedas As DataTable
    Private dtDatos As DataTable

    Private Sub frmReembolsoRendFondos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        txtIdReembolso.Focus()
    End Sub

    Private Sub frmReembolsoRendFondos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRendirFondos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oTesoreriaService.Close()
            oReembolsoCajaService.Close()
            oMaestroService.Close()
            oCuentaContableService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
            oReembolsoCajaService.Abort()
            oMaestroService.Abort()
            oCuentaContableService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
            oReembolsoCajaService.Abort()
            oMaestroService.Abort()
            oCuentaContableService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMonedas.DataSource = dtMonedas
            cmbMonedas.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMonedas.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMonedas.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMonedas.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMonedas.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtIdReembolso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdReembolso.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarReembolso.Enabled = True Then
                e.Handled = True
                btnBuscarReembolso_Click(sender, e)
            End If
        End If
    End Sub

    Private Function ValidarCodigo() As Boolean
        Try
            If Len(Trim(txtIdReembolso.Text)) > 0 Then
                ''If Not (oSolicitudGastoService.Buscar(toNumber(txtIdGasto.Text))) Then
                ''        MsgBox("Número de Solicitud de Gasto inexistente, Verifique")
                'txtIdReembolso.Text = ""
                'txtIdReembolso.Focus()
                'Limpiar()
                'Return False
                '    Else
                Return True
                '    End If
            Else
                MsgBox("Ingrese un N° de Reembolso")
                txtIdReembolso.Text = ""
                txtIdReembolso.Focus()
                Limpiar()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR  IDREEMBOLSO : " + ex.Message)
        End Try
    End Function

    Private Sub ListarDetalles()
        Try
            dtDatos = oTesoreriaService.ConsultarReembolso(IdReembolso).Tables(0)
            dgvDatos.DataSource = dtDatos            
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar()
        txtIdReembolso.Text = ""
        txtFecha.IsNullDate = True
        txtUbicacion.Text = ""
        cmbCodMon.Text = ""
        txtTCCompra.Value = 0
        txtTCVenta.Value = 0        
        txtMontoTotalNeto.Value = 0
        lblMontoTotalNeto.Text = "MONTO TOTAL NETO"
        dtDatos = Nothing
        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ReembolsoCajaService.ReembolsoCaja
            registro = oReembolsoCajaService.Obtener(IdReembolso)

            IdReembolso = registro.IdReembolso
            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtUbicacion.Text = registro.UbicacionCaja.NomUbicacion
            cmbCodMon.Value = registro.Moneda.CodMon
            txtTCCompra.Value = registro.TCCompra
            txtTCVenta.Value = registro.TCVenta
            txtMontoTotalNeto.Value = registro.TotNeto

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendientes.Click
        Try
            If txtIdReembolso.Text <> "" Then
                Dim frm As New frmPendientesRendFondos
                frm.txtCodCuenta.Text = "141.31"
                'frm.IdPersona = 98   'Mandamos por defecto al colaborador Segundo Villalobos
                frm.IdPersona = 547   'Mandamos por defecto al colaborador Juan Salazar (Angélica Vega SolUsuario 65828) 
                frm.txtColaborador.Text = "SALAZAR CUADROS JUAN JONATHAN"  'Mandamos por defecto al colaborador Segundo Villalobos
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdTesoreriaDet = frm.IdTesoreriaDet                    
                    CodCuenta = frm.CodCuenta
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, frm.CodCuenta)
                    IdDocumento = frm.IdDocumento
                    SerDoc = frm.SerDoc
                    NumDoc = frm.NumDoc
                    MontoOriginal = frm.MontoOriginal
                    txtMontoOriginal.Value = frm.MontoOriginal
                    cmbMonedas.Value = frm.CodMon
                    Nombre = frm.txtColaborador.Text 'Mandamos el nombre del colaborador
                    IdPersona = frm.IdPersona   'Obtenemos la Persona ingresada en la busqueda de frmRendientesRendFondos
                    txtGlosa.Focus()
                Else
                    IdTesoreriaDet = 0
                    IdCuenta = 0
                    CodCuenta = 0
                    IdDocumento = 0
                    SerDoc = ""
                    NumDoc = ""
                    MontoOriginal = 0
                    txtMontoOriginal.Value = 0
                    cmbMonedas.Text = ""
                End If
            Else
                MsgBox("Debe Ingresar el Número de Reembolso.", MsgBoxStyle.Information, "Información")
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Tesoreria - Asientos Pendientes : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try            
            If toNumber(txtIdReembolso.Text) = 0 Then
                MsgBox("Debe Ingresar el Número de Reembolso.", MsgBoxStyle.Information, "Información")
                txtIdReembolso.Focus()
                Return False
            ElseIf dgvDatos.RowCount < 1 Then
                MsgBox("El Reembolso no presenta detalles.", MsgBoxStyle.Information, "Información")
                txtIdReembolso.Focus()
                Return False
            ElseIf txtGlosa.Text = "" Then
                MsgBox("Debe Ingresar la Glosa.", MsgBoxStyle.Information, "Información")
                txtGlosa.Focus()
                Return False
                'ElseIf Not (oSolicitudGastoService.Buscar(toNumber(txtIdGasto.Text))) Then
                '    MsgBox("Número de Gasto inexistente.", MsgBoxStyle.Information, "Información")
                '    txtIdGasto.Focus()
                '    Return False
                'ElseIf Not (txtMontoTotalNeto.Value = txtMontoTotalNeto.Value) Then
                '    MsgBox("Los Montos no coinciden.", MsgBoxStyle.Information, "Información")
                '    txtIdReembolso.Focus()
                '    Return False
            ElseIf IdTesoreriaDet = 0 Then
                MsgBox("Debe Seleccionar Asiento Pendiente.", MsgBoxStyle.Information, "Información")
                btnPendientes.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If ValidaCampos() Then
                Glosa = txtGlosa.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL RENDIR REEMBOLSO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub txtGlosa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub btnBuscarReembolso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarReembolso.Click
        Try
            Dim frm As New frmBuscarReembolso            
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If frm.codigo <> 0 Then
                    txtIdReembolso.Text = frm.numero
                    IdReembolso = frm.codigo
                    If ValidarCodigo() Then
                        ListarDetalles()
                        ObtenerRegistro()
                        btnPendientes.Focus()
                    End If
                Else
                    txtIdReembolso.Text = ""
                    IdReembolso = 0
                    Limpiar()
                    txtIdReembolso.Focus()
                End If
            Else
                txtIdReembolso.Text = ""
                IdReembolso = 0
                Limpiar()
                txtIdReembolso.Focus()
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class