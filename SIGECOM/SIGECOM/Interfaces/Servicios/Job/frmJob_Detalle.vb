Imports System.ServiceModel
Public Class frmJob_Detalle

    '============================Servicios===================================
    Private oJobDetalleService As New JobDetalleService.JobDetalleServiceClient
    Private oCotizacionServicioDetService As New CotizacionServicioDetService.CotizacionServicioDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'Update     insert      delete
    Public CodJob As String
    Public IdRubro As Integer
    Public estado As Integer
    Private dtRubro As DataTable

    Private Sub frmJob_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            cmbRubro.Focus()
        Else                          'Nuevo
            activar()   'desactivar()
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
                          txtMontoVenta.KeyPress _
                        , txtMontoDscto.KeyPress _
                        , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oJobDetalleService.Close()
            oCotizacionServicioDetService.Close()
        Catch ex As TimeoutException
            oJobDetalleService.Abort()
            oCotizacionServicioDetService.Abort()
        Catch ex As CommunicationException
            oJobDetalleService.Abort()
            oCotizacionServicioDetService.Abort()
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function ValidaCampos() As Boolean
        'Try
        '    If toNumber(IdOrden) = 0 Then
        '        MsgBox("Debe Ingresar el código de la Orden. ", MsgBoxStyle.Information, "Información")
        '        Return False
        '    Else
        Return True
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Function

    Private Sub EnableOptions()
        If estado = 6 Then
            activar()
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()    
        If state_button Then
            If estado <> 6 Then
                desactivar()
            Else
                cmbRubro.ReadOnly = True
                cmbRubro.BackColor = System.Drawing.SystemColors.Control
                txtMontoVenta.ReadOnly = False
                txtMontoVenta.BackColor = System.Drawing.SystemColors.Window
                txtMontoDscto.ReadOnly = False
                txtMontoDscto.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
            End If
        Else
            cmbRubro.ReadOnly = False
            cmbRubro.BackColor = System.Drawing.SystemColors.Window
            txtMontoVenta.ReadOnly = False
            txtMontoVenta.BackColor = System.Drawing.SystemColors.Window
            txtMontoDscto.ReadOnly = False
            txtMontoDscto.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        txtMontoVenta.ReadOnly = True
        txtMontoVenta.BackColor = System.Drawing.SystemColors.Control
        txtMontoDscto.ReadOnly = True
        txtMontoDscto.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As JobDetalleService.JobDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oJobDetalleService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                IdRubro = cmbRubro.Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As JobDetalleService.JobDetalle)
        Try
            Dim estado_process As Boolean
            estado_process = oJobDetalleService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As JobDetalleService.JobDetalle
            registro = oJobDetalleService.Obtener(CodJob, IdRubro)

            IdRubro = registro.RubroServicios.IdRubro
            CodJob = registro.Job.CodJob

            cmbRubro.Value = registro.RubroServicios.IdRubro
            txtMontoVenta.Value = registro.MontoVenta
            txtMontoCosto.Value = registro.MontoCosto
            txtMontoDscto.Value = registro.MontoDscto
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New JobDetalleService.JobDetalle
            Dim Job As New JobDetalleService.Job
            Dim Rubro As New JobDetalleService.RubroServicios

            Job.CodJob = CodJob
            registro.Job = Job
            Rubro.IdRubro = cmbRubro.Value
            registro.RubroServicios = Rubro

            registro.MontoVenta = txtMontoVenta.Value
            registro.MontoDscto = txtMontoDscto.Value
            registro.MontoCosto = txtMontoCosto.Value
            registro.Observacion = txtObservacion.Text

            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.FecReg = Today
            registro.NomPc = Session.sNomPc

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
End Class