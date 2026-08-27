Imports System.ServiceModel
Public Class frmServicios_Cotizacion_Costo

    '============================Servicios===================================
    Private oCotizacionServicioDetService As New CotizacionServicioDetService.CotizacionServicioDetServiceClient

    '======================Declaración de Variables==============================
    Public IdCotizacionSerDet As Integer
    Public IdCotizacionSer As Integer
    Public IdRubro As Integer
    Public codMon As String
    Public idCliente As Int64

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public estado As Integer
    Private dtRubro As DataTable

    Private Sub frmServicios_Cotizacion_Costo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            txtMonto.Focus()
        Else
            desactivar()
            cmbRubro.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmComOrdenCompraDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           cmbRubro.KeyPress _
                         , txtMonto.KeyPress _
                         , txtDescuento.KeyPress _
                         , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oCotizacionServicioDetService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioDetService.Abort()
        Catch ex As CommunicationException
            oCotizacionServicioDetService.Abort()
        End Try
    End Sub

    Private Sub EnableOptions()
        If estado = 1 Then
            activar()
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        If state_button Then
            If estado <> 1 Then
                desactivar()
            Else
                cmbRubro.ReadOnly = True
                cmbRubro.BackColor = System.Drawing.SystemColors.Control
                txtMonto.ReadOnly = False
                txtMonto.BackColor = System.Drawing.SystemColors.Window
                txtCosto.ReadOnly = False
                txtCosto.BackColor = System.Drawing.SystemColors.Window
                txtDescuento.ReadOnly = False
                txtDescuento.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window             
            End If
        Else
            cmbRubro.ReadOnly = False
            cmbRubro.BackColor = System.Drawing.SystemColors.Window
            txtMonto.ReadOnly = False
            txtMonto.BackColor = System.Drawing.SystemColors.Window
            txtCosto.ReadOnly = False
            txtCosto.BackColor = System.Drawing.SystemColors.Window
            txtDescuento.ReadOnly = False
            txtDescuento.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control
        txtCosto.ReadOnly = True
        txtCosto.BackColor = System.Drawing.SystemColors.Control
        txtDescuento.ReadOnly = True
        txtDescuento.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As CotizacionServicioDetService.CotizacionServicioDetCostos)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionServicioDetService.InsertarCosto(registro)
            type_process = "insert"
            If estado_process = True Then                
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CotizacionServicioDetService.CotizacionServicioDetCostos)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionServicioDetService.ActualizarCosto(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionServicioDetService.CotizacionServicioDetCostos
            registro = oCotizacionServicioDetService.ObtenerCosto(IdCotizacionSerDet, IdCotizacionSer, IdRubro)

            IdCotizacionSer = registro.CotizacionServicioDet.CotizacionServicio.IdCotizacionSer
            IdCotizacionSerDet = registro.CotizacionServicioDet.IdCotizacionSerDet
            IdRubro = registro.RubroServicios.IdRubro
            cmbRubro.Value = registro.RubroServicios.IdRubro
            txtMonto.Value = registro.Monto
            txtCosto.Value = registro.MontoCosto
            txtDescuento.Value = registro.MontoDscto
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= RUBRO ==============================================
            dtRubro = oCotizacionServicioDetService.MostrarRubros.Tables(0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubro = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCotizacionSer) = 0 Then
                MsgBox("Debe Ingresar el código de la Cotización.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(IdCotizacionSerDet) = 0 Then
                MsgBox("Debe Ingresar el código de detalle de la Cotización.", MsgBoxStyle.Information, "Información")                
                Return False
            ElseIf toBlank(cmbRubro.Value) = "" Then
                MsgBox("Debe ingresar el código del Rubro.", MsgBoxStyle.Information, "Información")                
                cmbRubro.Focus()
                Return False            
            ElseIf toDouble(txtMonto.Value) = 0 Then
                MsgBox("El Monto debe mayor a cero.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New CotizacionServicioDetService.CotizacionServicioDetCostos
            Dim CotizacionSerDet As New CotizacionServicioDetService.CotizacionServicioDet
            Dim CotizacionSer As New CotizacionServicioDetService.CotizacionServicio
            Dim RubroServicio As New CotizacionServicioDetService.RubroServicios

            CotizacionSerDet.IdCotizacionSerDet = IdCotizacionSerDet
            CotizacionSer.IdCotizacionSer = IdCotizacionSer

            CotizacionSerDet.CotizacionServicio = CotizacionSer
            registro.CotizacionServicioDet = CotizacionSerDet

            RubroServicio.IdRubro = cmbRubro.Value
            registro.RubroServicios = RubroServicio

            registro.Monto = txtMonto.Value
            registro.MontoDscto = txtDescuento.Value
            registro.MontoCosto = txtCosto.Value
            registro.Observacion = txtObservacion.Text
            
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.FecReg = Today

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnSugerirCosto_Click(sender As Object, e As EventArgs) Handles btnSugerirCosto.Click
        Try

            txtCosto.Value = oCotizacionServicioDetService.ObtenerCostoSugerido(codMon, idCliente, cmbRubro.Value)

            MsgBox("Se muestra el ultimo costo mas alto aplicado en un servicio para el presente cliente", MsgBoxStyle.Information, "Información")


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class