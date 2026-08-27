Imports System.ServiceModel
Public Class frmTarifaGastoViaje

    '============================Servicios===================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean
    Public type_process As String
    Public editable As Boolean = True
    Public edicion As Boolean = True
    Public IdDestino As Integer
    Public IdSubRubro As Integer
    Public CodMon As String
    Public IdRubroViaje As Integer
    Private dtRubroViaje As DataTable
    Private dtDestino As DataTable
    Private dtSubRubroViaje As DataTable
    Private dtMonedas As DataTable

    Private Sub frmTarifaGastoViaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        LlenarSubRubroViaje()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            Me.Text = "TARIFA"
        Else                          'Nuevo
            Me.Text = "Registrar nueva Tarifa"
            activar()
            cmbMoneda.Value = "NS"
            cbActivo.Checked = True
            cmbDestinoViaje.SelectedIndex = 0
            cmbRubroViaje.SelectedIndex = 0            
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       cmbDestinoViaje.KeyPress _
                       , cmbRubroViaje.KeyPress _
                       , cmbSubRubroViaje.KeyPress _
                      , txtDias.KeyPress _
                      , cmbMoneda.KeyPress _
                      , txtMonto.KeyPress _
                      , cbActivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmTarifaGastoViaje_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmTarifaGastoViaje_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoDetService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= RUBRO VIAJE ==============================================
            dtRubroViaje = oSolicitudGastoDetService.MostrarRubroViaje.Tables(0)
            'dtRubroViaje.Rows.InsertAt(getRowTodos(dtRubroViaje), 0)
            cmbRubroViaje.DataSource = dtRubroViaje
            cmbRubroViaje.DropDownList.DataMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.DropDownList.DisplayMember = dtRubroViaje.Columns("DesRubro").ToString
            cmbRubroViaje.DropDownList.ValueMember = dtRubroViaje.Columns("IdRubro").ToString
            cmbRubroViaje.DropDownList.Columns(0).DataMember = dtRubroViaje.Columns("IdRubro").ToString
            cmbRubroViaje.DropDownList.Columns(1).DataMember = dtRubroViaje.Columns("DesRubro").ToString
            '            cmbRubroViaje.SelectedIndex = 0
            dtRubroViaje = Nothing

            '======================================= DESTINOS ==============================================
            dtDestino = oSolicitudGastoDetService.MostrarDestinos.Tables(0)
            'dtDestino.Rows.InsertAt(getRowTodos(dtDestino), 0)
            cmbDestinoViaje.DataSource = dtDestino
            cmbDestinoViaje.DropDownList.DataMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.DropDownList.DisplayMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.DropDownList.ValueMember = dtDestino.Columns("IdDestino").ToString
            cmbDestinoViaje.DropDownList.Columns(0).DataMember = dtDestino.Columns("IdDestino").ToString
            cmbDestinoViaje.DropDownList.Columns(1).DataMember = dtDestino.Columns("DesDestino").ToString
            '            cmbDestinoViaje.SelectedIndex = 0
            dtDestino = Nothing

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

    Private Sub LlenarSubRubroViaje()
        Try
            '======================================= SUBRUBRO VIAJE =============================================
            If cmbRubroViaje.Value <> 0 And cmbDestinoViaje.Value <> 0 Then
                dtSubRubroViaje = oSolicitudGastoDetService.MostrarSubRubroViaje(cmbRubroViaje.Value, cmbDestinoViaje.Value).Tables(0)
                dtSubRubroViaje.Rows.InsertAt(getRowTodos(dtSubRubroViaje), 0)
                cmbSubRubroViaje.DataSource = dtSubRubroViaje
                cmbSubRubroViaje.DropDownList.DataMember = dtSubRubroViaje.Columns("DesSubRubro").ToString
                cmbSubRubroViaje.DropDownList.DisplayMember = dtSubRubroViaje.Columns("DesSubRubro").ToString
                cmbSubRubroViaje.DropDownList.ValueMember = dtSubRubroViaje.Columns("IdSubRubro").ToString
                cmbSubRubroViaje.DropDownList.Columns(0).DataMember = dtSubRubroViaje.Columns("IdSubRubro").ToString
                cmbSubRubroViaje.DropDownList.Columns(1).DataMember = dtSubRubroViaje.Columns("DesSubRubro").ToString
                cmbSubRubroViaje.DropDownList.Columns(2).DataMember = dtSubRubroViaje.Columns("Observacion").ToString
                cmbSubRubroViaje.SelectedIndex = 0
                dtSubRubroViaje = Nothing
            Else
                dtSubRubroViaje = oSolicitudGastoDetService.MostrarSubRubroViaje(cmbRubroViaje.Value, cmbDestinoViaje.Value).Tables(0)
                dtSubRubroViaje.Rows.InsertAt(getRowTodos(dtSubRubroViaje), 0)
                cmbSubRubroViaje.DataSource = dtSubRubroViaje
                cmbSubRubroViaje.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO SUBRUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub enableOpciones()
        biEditarr.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacerr.Enabled = edicion        
    End Sub

    Private Sub activar()
        If state_button Then   'Actualizar
            cmbDestinoViaje.ReadOnly = True
            cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
            cmbRubroViaje.ReadOnly = True
            cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
            cmbSubRubroViaje.ReadOnly = True
            cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            txtDias.ReadOnly = False
            txtDias.BackColor = System.Drawing.SystemColors.Window
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            'cbActivo.BackColor = System.Drawing.SystemColors.Window            
            edicion = True
            enableOpciones()
            txtDias.Focus()
        Else                      'Nuevo
            cmbDestinoViaje.ReadOnly = False
            cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Window
            cmbRubroViaje.ReadOnly = False
            cmbRubroViaje.BackColor = System.Drawing.SystemColors.Window
            cmbSubRubroViaje.ReadOnly = False
            cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtDias.ReadOnly = False
            txtDias.BackColor = System.Drawing.SystemColors.Window
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            cbActivo.Enabled = True
            'cbActivo.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            cmbDestinoViaje.Focus()
        End If
    End Sub

    Private Sub desactivar()
        cmbDestinoViaje.ReadOnly = True
        cmbDestinoViaje.BackColor = System.Drawing.SystemColors.Control
        cmbRubroViaje.ReadOnly = True
        cmbRubroViaje.BackColor = System.Drawing.SystemColors.Control
        cmbSubRubroViaje.ReadOnly = True
        cmbSubRubroViaje.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtDias.ReadOnly = True
        txtDias.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        'cbActivo.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        cmbDestinoViaje.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbDestinoViaje.Value) = "" Then
                MsgBox("Debe Ingresar el Destino.", MsgBoxStyle.Information, "Información")
                cmbDestinoViaje.Focus()
                Return False
            ElseIf toBlank(cmbRubroViaje.Value) = "" Then
                MsgBox("Debe Ingresar el Rubro Viaje.", MsgBoxStyle.Information, "Información")
                cmbRubroViaje.Focus()
                Return False
            ElseIf cmbSubRubroViaje.Value = 0 Then
                MsgBox("Debe de Ingresar el SubRubro.", MsgBoxStyle.Information, "Información")
                cmbSubRubroViaje.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False           
            ElseIf toDouble(txtMonto.Value) <= 0 Then
                MsgBox("El monto debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoDetService.TarifaGastoViaje
            registro = oSolicitudGastoDetService.ObtenerTarifaGastoViaje(IdDestino, IdSubRubro, CodMon)

            IdDestino = registro.DestinosViaje.IdDestino
            IdRubroViaje = registro.SubRubroViaje.RubroViaje.IdRubro
            IdSubRubro = registro.SubRubroViaje.IdSubRubro
            CodMon = registro.Moneda.CodMon

            cmbDestinoViaje.Value = registro.DestinosViaje.IdDestino
            cmbRubroViaje.Value = registro.SubRubroViaje.RubroViaje.IdRubro
            cmbSubRubroViaje.Value = registro.SubRubroViaje.IdSubRubro
            txtDias.Value = registro.Dias
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMonto.Value = registro.Monto
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudGastoDetService.TarifaGastoViaje)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoDetService.InsertarTarifaGastoViaje(registro)
            type_process = "insert"
            If estado_process = True Then
                IdDestino = cmbDestinoViaje.Value
                IdRubroViaje = cmbRubroViaje.Value
                IdSubRubro = cmbSubRubroViaje.Value
                CodMon = cmbMoneda.Value
                MsgBox("Se insertó la Tarifa Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGastoDetService.TarifaGastoViaje)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoDetService.ActualizarTarifaGastoViaje(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Tarifa Correctamente")
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoDetService.BorrarTarifaGastoViaje(IdDestino, IdSubRubro, IdRubroViaje, CodMon, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR TARIFA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New SolicitudGastoDetService.TarifaGastoViaje
                    Dim Destino As New SolicitudGastoDetService.DestinosViaje
                    Dim SubRubro As New SolicitudGastoDetService.SubRubroViaje
                    Dim Moneda As New SolicitudGastoDetService.Moneda
                    Dim Rubro As New SolicitudGastoDetService.RubroViaje

                    Destino.IdDestino = cmbDestinoViaje.Value
                    registro.DestinosViaje = Destino
                    SubRubro.IdSubRubro = cmbSubRubroViaje.Value
                    Rubro.IdRubro = cmbRubroViaje.Value
                    SubRubro.RubroViaje = Rubro
                    registro.SubRubroViaje = SubRubro
                    registro.Dias = txtDias.Value
                    Moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = Moneda
                    registro.Monto = txtMonto.Value
                    registro.Activo = cbActivo.Checked

                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR TARIFA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub cmbRubroViaje_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubroViaje.ValueChanged
        LlenarSubRubroViaje()
    End Sub

    Private Sub cmbDestinoViaje_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDestinoViaje.ValueChanged
        LlenarSubRubroViaje()
    End Sub
End Class