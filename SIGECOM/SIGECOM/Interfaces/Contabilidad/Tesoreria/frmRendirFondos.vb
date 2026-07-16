Imports System.ServiceModel
Public Class frmRendirFondos

    '===========================Servicios====================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables=============================   
    Public IdTesoreriaDet As Integer      'Id obtenido de frmPendientesRendFondos
    Public CodCuenta As String            'CodCuenta obtenido de frmPendientesRendFondos
    Public IdDocumento As Integer        'IdDocumento obtenido de frmPendientesRendFondos
    Public SerDoc As String                  'SerDoc obtenido de frmPendientesRendFondos
    Public NumDoc As String                'NumDoc obtenido de frmPendientesRendFondos
    Public MontoOriginal As Double       'MontoOriginal obtenido frmPendientesRendFondos
    Public CodMon As String                 'CodMon obtenido frmPendientesRendFondos
    Public Nombre As String
    Public Glosa As String
    Public IdGasto As Integer    
    Public IdPerSolicita As Integer
    Private dtMonedas As DataTable
    Private dtDatos As DataTable

    Private Sub frmRendirCuentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        txtIdGasto.Focus()
    End Sub

    Private Sub frmRendirFondos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            oSolicitudGastoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oTesoreriaService.Abort()
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
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

    Private Sub txtIdGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdGasto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If ValidarCodigo() Then
                ListarDetalles()
                ObtenerRegistro()
                btnPendientes.Focus()
            End If
        End If
    End Sub

    Private Function ValidarCodigo() As Boolean
        Try
            If Len(Trim(txtIdGasto.Text)) > 0 Then
                If Not (oSolicitudGastoService.Buscar(toNumber(txtIdGasto.Text))) Then
                    MsgBox("Número de Solicitud de Gasto inexistente, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                Else
                    Return True
                End If
            Else
                MsgBox("Ingrese un N° de Solicitud de Gasto")
                txtIdGasto.Text = ""
                txtIdGasto.Focus()
                Limpiar()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR  IDGASTO : " + ex.Message)
        End Try
    End Function

    Private Sub ListarDetalles()
        Try
            dtDatos = oTesoreriaService.ConsultarSolicitudGasto(toNumber(txtIdGasto.Text)).Tables(0)            
            dgvDatos.DataSource = dtDatos
            If dgvDatos.RowCount > 0 Then
                SumarMonto()
            Else
                txtMontoTotalNeto.Value = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SumarMonto()
        Try
            Dim total As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As Boolean
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("TotalNeto").Value
                If bSelected Then
                    total = total + CDbl(Me.dgvDatos.CurrentRow.Cells("TotalNeto").Value) * IIf(Me.dgvDatos.CurrentRow.Cells("IdDocumento").Value = 5, -1, 1)
                End If
            Next
            lblMontoTotalNeto.Text = "Monto Total Neto " + cmbMoneda.Text
            txtMontoTotalNeto.Value = total
        Catch ex As Exception
            MsgBox("Error al sumar Montos" + ex.Message)
        End Try
    End Sub

    Private Sub Limpiar()
        txtIdGasto.Text = ""
        txtFecha.IsNullDate = True
        txtArea.Text = ""
        cmbCodMon.Text = ""
        txtMontoTotal.Value = 0
        txtPersonaSolicita.Text = ""
        txtPersonaAutoriza.Text = ""
        lblEstado.Text = ""
        txtMontoTotalNeto.Value = 0
        lblMontoTotalNeto.Text = "MONTO TOTAL NETO"
        dtDatos = Nothing
        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoService.SolicitudGasto
            registro = oSolicitudGastoService.Obtener(toNumber(txtIdGasto.Text))

            IdGasto = registro.IdGasto
            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtArea.Text = registro.Area.DesArea
            cmbCodMon.Value = registro.Moneda.CodMon
            IdPerSolicita = registro.PersonaSolicita.IdPer
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.PersonaJefe.ApeNom
            txtMontoTotal.Value = registro.TotalNeto
            lblEstado.Text = registro.EstadoSolicitudGasto.DesEstado
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendientes.Click
        Try
            If txtIdGasto.Text <> "" Then
                Dim frm As New frmPendientesRendFondos
                frm.txtCodCuenta.Text = "141.31"
                frm.IdPersona = IdPerSolicita
                frm.txtColaborador.Text = txtPersonaSolicita.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdTesoreriaDet = frm.IdTesoreriaDet
                    CodCuenta = frm.CodCuenta
                    IdDocumento = frm.IdDocumento
                    NumDoc = frm.NumDoc
                    SerDoc = frm.SerDoc
                    MontoOriginal = frm.MontoOriginal
                    txtMontoOriginal.Value = frm.MontoOriginal
                    cmbMonedas.Value = frm.CodMon
                    txtGlosa.Focus()
                Else
                    IdTesoreriaDet = 0
                    CodCuenta = 0
                    IdDocumento = 0
                    NumDoc = ""
                    SerDoc = ""
                    MontoOriginal = 0
                    txtMontoOriginal.Value = 0
                    cmbMonedas.Text = ""
                End If
            Else
                MsgBox("Debe Ingresar el Número de Gasto.", MsgBoxStyle.Information, "Información")
            End If            
        Catch ex As Exception
            MsgBox("Error al Buscar Tesoreria - Asientos Pendientes : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtGlosa.Text = "" Then
                MsgBox("Debe Ingresar la Glosa.", MsgBoxStyle.Information, "Información")
                txtGlosa.Focus()
                Return False
            ElseIf toNumber(txtIdGasto.Text) = 0 Then
                MsgBox("Debe Ingresar el Número de Gasto.", MsgBoxStyle.Information, "Información")
                txtIdGasto.Focus()
                Return False
            ElseIf Not (oSolicitudGastoService.Buscar(toNumber(txtIdGasto.Text))) Then
                MsgBox("Número de Gasto inexistente.", MsgBoxStyle.Information, "Información")
                txtIdGasto.Focus()
                Return False
            ElseIf Not (txtMontoTotal.Value = txtMontoTotalNeto.Value) Then
                MsgBox("Los Montos no coinciden.", MsgBoxStyle.Information, "Información")
                txtIdGasto.Focus()
                Return False
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
                IdGasto = txtIdGasto.Text
                Nombre = txtPersonaSolicita.Text
                Glosa = txtGlosa.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL RENDIR FONDOS : " + ex.Message, MsgBoxStyle.Exclamation)
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

End Class