Imports System.ServiceModel
Public Class frmReembolso_Det

    '============================Servicios===================================
    Private oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    Private oReembolsoCajaService As New ReembolsoCajaService.ReembolsoCajaServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdReembolsoDet As Integer
    Public IdReembolso As Integer
    Public estado As String
    Public iArea As String
    Private dtAreas As DataTable
    Private dtUnidad As DataTable
    Private dtTipoGasto As DataTable
    Private dtDatos As DataTable

    Private IdGasto As Integer                  'IdGasto del ObtenerDet de Reembolso
    Private IdGastoDet As Integer             'IdGastoDet del ObtenerDet de Reembolso

    Private Sub frmComReembolso_Det_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComReembolso_Det_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        estado = oReembolsoCajaService.ObtenerEstado(toNumber(IdReembolso))
        llenarCombos()
        cmbArea.Focus()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            cmbArea.Focus()
        Else                          'Nuevo
            activar()
            cmbArea.Focus()
            If iArea <> "" Then
                cmbArea.Value = iArea
            End If
            txtItem.Focus()
        End If
            EnableOptions()
        'cmbArea.Focus()        
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      cmbPlaca.KeyPress _
                    , cmbTipoGasto.KeyPress _
                    , cmbArea.KeyPress _
                    , txtItem.KeyPress _
                    , txtDescripcion.KeyPress _
                    , txtImporte.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComReembolso_Det_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oReembolsoCajaDetService.Close()
            oReembolsoCajaService.Close()
            oVehiculoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaDetService.Abort()
            oReembolsoCajaService.Abort()
            oVehiculoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaDetService.Abort()
            oReembolsoCajaService.Abort()
            oVehiculoService.Abort()
            oMaestroService.Abort()
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
        Return fila
    End Function

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbArea.Value) = "" Then
                MsgBox("Debe Ingresar el Area. ", MsgBoxStyle.Information, "Información")
                cmbArea.Focus()
                Return False
            ElseIf toBlank(cmbTipoGasto.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Gasto", MsgBoxStyle.Information, "Información")
                cmbTipoGasto.Focus()
                Return False
            ElseIf cmbTipoGasto.Value = 0 Then
                MsgBox("Debe Ingresar el Tipo de Gasto", MsgBoxStyle.Information, "Información")
                cmbTipoGasto.Focus()
                Return False
                'ElseIf oReembolsoCajaDetService.BuscarTipoVehiculo(cmbTipoGasto.Value) And cmbPlaca.SelectedIndex = 0 Then
                '    MsgBox("Debe Ingresar la Placa", MsgBoxStyle.Information, "Información")
                '    cmbPlaca.Focus()
                '    Return False            
            ElseIf toDouble(txtImporte.Value) = 0 Then
                MsgBox("Debe Ingresar el Importe", MsgBoxStyle.Information, "Información")
                txtImporte.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        If estado = "GN" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        '-----------Se inhabilita ya que este dato vendrá de Solicitud de Gasto---------
        cmbArea.ReadOnly = True
        cmbArea.BackColor = System.Drawing.SystemColors.Control
        txtImporte.ReadOnly = True
        txtImporte.BackColor = System.Drawing.SystemColors.Control
        '----------------------------------------------------------------------------------------------------------
        cmbTipoGasto.ReadOnly = False
        cmbTipoGasto.BackColor = System.Drawing.SystemColors.Window
        cmbPlaca.ReadOnly = False
        cmbPlaca.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub desactivar()
        estado = oReembolsoCajaService.ObtenerEstado(toNumber(IdReembolso))
        If estado = "GN" Then
            activar()
        Else
            cmbArea.ReadOnly = True
            cmbArea.BackColor = System.Drawing.SystemColors.Control
            cmbTipoGasto.ReadOnly = True
            cmbTipoGasto.BackColor = System.Drawing.SystemColors.Control
            cmbPlaca.ReadOnly = True
            cmbPlaca.BackColor = System.Drawing.SystemColors.Control
            txtImporte.ReadOnly = True
            txtImporte.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub Insertar(ByVal registro As ReembolsoCajaDetService.ReembolsoCajaDet)
        Try
            Dim estado_process As Integer
            Dim frm As New frmReembolso_Nuevo
            estado_process = oReembolsoCajaDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdReembolsoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ReembolsoCajaDetService.ReembolsoCajaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oReembolsoCajaDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ReembolsoCajaDetService.ReembolsoCajaDet
            registro = oReembolsoCajaDetService.Obtener(IdReembolsoDet)

            IdReembolso = registro.ReembolsoCaja.IdReembolso
            IdReembolsoDet = registro.IdReembolsoDet
            txtItem.Value = registro.Item
            cmbArea.Value = registro.Area.CodArea
            cmbTipoGasto.Value = registro.TipoGasto.IdTipoGasto
            If registro.Unidad.Placa = Nothing Then
                cmbPlaca.SelectedIndex = 0
            Else
                cmbPlaca.Value = registro.Unidad.Placa
            End If
            txtImporte.Value = registro.Importe
            txtObservacion.Text = registro.Observacion
            txtDescripcion.Text = registro.Descripcion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= PLACA ===============================================
            dtUnidad = oVehiculoService.MostrarUnidades.Tables(0)
            dtUnidad.Rows.InsertAt(getRowTodos(dtUnidad), 0)
            cmbPlaca.DataSource = dtUnidad
            cmbPlaca.DropDownList.DataMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtUnidad.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtUnidad = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

            ''===================================== TIPO DE GASTO ============================================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            dtTipoGasto.Rows.InsertAt(getRowTodos(dtTipoGasto), 0)
            cmbTipoGasto.DataSource = dtTipoGasto
            cmbTipoGasto.DropDownList.DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.DisplayMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.DropDownList.ValueMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(0).DataMember = dtTipoGasto.Columns("IdTipoGasto").ToString
            cmbTipoGasto.DropDownList.Columns(1).DataMember = dtTipoGasto.Columns("DesTipo").ToString
            cmbTipoGasto.SelectedIndex = 0
            dtTipoGasto = Nothing

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

        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If ValidaCampos() Then
                Dim registro As New ReembolsoCajaDetService.ReembolsoCajaDet
                Dim Reembolso As New ReembolsoCajaDetService.ReembolsoCaja
                Dim Area As New ReembolsoCajaDetService.Area
                Dim TipoGasto As New ReembolsoCajaDetService.TipoGasto
                Dim Unidad As New ReembolsoCajaDetService.Unidad
                Dim SolicitudGasto As New ReembolsoCajaDetService.SolicitudGasto
                Dim SolicitudGastoDet As New ReembolsoCajaDetService.SolicitudGastoDet

                registro.IdReembolsoDet = IdReembolsoDet
                Reembolso.IdReembolso = IdReembolso
                registro.ReembolsoCaja = Reembolso

                SolicitudGasto.IdGasto = Nothing
                SolicitudGastoDet.IdGastoDet = Nothing
                SolicitudGastoDet.SolicitudGasto = SolicitudGasto
                registro.SolicitudGastoDet = SolicitudGastoDet

                registro.Item = txtItem.Value
                Area.CodArea = cmbArea.Value
                registro.Area = Area
                TipoGasto.IdTipoGasto = cmbTipoGasto.Value
                registro.TipoGasto = TipoGasto
                If cmbPlaca.SelectedIndex = 0 Then
                    Unidad.Placa = Nothing
                    registro.Unidad = Unidad
                Else
                    Unidad.Placa = toNull(cmbPlaca.Value)
                    registro.Unidad = Unidad
                End If
                registro.Importe = txtImporte.Value
                registro.Descripcion = txtDescripcion.Text
                registro.Observacion = txtObservacion.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub cmbTipoGasto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoGasto.ValueChanged
        If state_button = False Then
            txtDescripcion.Text = cmbTipoGasto.Text
        End If
    End Sub
End Class