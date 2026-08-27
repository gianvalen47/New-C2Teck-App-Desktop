Imports System.ServiceModel

Public Class frmMonitor

    '=========================== Servicios ===================================================
    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    'Public IdLinea As Integer                        'Linea Telefonica
    Public IdMonitor As Integer
    Public IdComputadora As Integer

    Private dtTipoMonitor As DataTable

    Private dtTipoDispositivo As DataTable
    Private dtMarca As DataTable

    Private Sub frmMonitor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub

    Private Sub frmMonitor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            'txtFecha.TabStop = False

        Else                                      'Nuevo            
            activar()
            cbVigente.Checked = True
            txtFecIniUso.Text = Today
            'cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub LlenarCombos()
        Try
            '======================================= TIPOMONITOR ================================================
            dtTipoMonitor = oComputadoraService.MostrarTipoMonitor().Tables(0)
            cmbTipoMonitor.DataSource = dtTipoMonitor
            cmbTipoMonitor.DropDownList.DataMember = dtTipoMonitor.Columns("DesTipoMonitor").ToString
            cmbTipoMonitor.DropDownList.DisplayMember = dtTipoMonitor.Columns("DesTipoMonitor").ToString
            cmbTipoMonitor.DropDownList.ValueMember = dtTipoMonitor.Columns("IdTipoMonitor").ToString
            cmbTipoMonitor.DropDownList.Columns(0).DataMember = dtTipoMonitor.Columns("IdTipoMonitor").ToString
            cmbTipoMonitor.DropDownList.Columns(1).DataMember = dtTipoMonitor.Columns("DesTipoMonitor").ToString
            cmbTipoMonitor.SelectedIndex = 0
            dtTipoMonitor = Nothing

            '======================================= TIPO DISPOSITIVO ================================================
            dtTipoDispositivo = oComputadoraService.MostrarTipoDispositivo().Tables(0)
            'dtTipoSoftware.Rows.InsertAt(getRowTodos(dtTipoSoftware), 0)
            cmbTipoDispositivo.DataSource = dtTipoDispositivo
            cmbTipoDispositivo.DropDownList.DataMember = dtTipoDispositivo.Columns("DesTipoDispositivo").ToString
            cmbTipoDispositivo.DropDownList.DisplayMember = dtTipoDispositivo.Columns("DesTipoDispositivo").ToString
            cmbTipoDispositivo.DropDownList.ValueMember = dtTipoDispositivo.Columns("IdTipoDispositivo").ToString
            cmbTipoDispositivo.DropDownList.Columns(0).DataMember = dtTipoDispositivo.Columns("IdTipoDispositivo").ToString
            cmbTipoDispositivo.DropDownList.Columns(1).DataMember = dtTipoDispositivo.Columns("DesTipoDispositivo").ToString
            cmbTipoDispositivo.SelectedIndex = 0
            dtTipoDispositivo = Nothing

            '======================================= MARCA ================================================
            dtMarca = oComputadoraService.MostrarMarcas().Tables(0)
            'dtTipoSoftware.Rows.InsertAt(getRowTodos(dtTipoSoftware), 0)
            cmbMarca.DataSource = dtMarca
            cmbMarca.DropDownList.DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.DisplayMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.ValueMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(0).DataMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(1).DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.SelectedIndex = 0
            dtMarca = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ComputadoraService.Monitor
            registro = oComputadoraService.ObtenerMonitor(IdMonitor)

            IdMonitor = registro.IdMonitor
            txtIdMonitor.Text = registro.IdMonitor
            txtDesMonitor.Text = registro.DesMonitor
            cmbTipoDispositivo.Value = registro.TipoDispositivo.IdTipoDispositivo
            cmbMarca.Value = registro.Marca.IdMarca
            txtModelo.Text = registro.Modelo
            txtSerie.Text = registro.Serie
            cmbTipoMonitor.Value = registro.TipoMonitor.IdTipoMonitor
            txtDispositivos.Text = registro.Dispositivos
            txtObservacion.Text = registro.Observacion
            'txtFecIniUso.Value = registro.FecIniUso
            'txtFecFinUso.Value = registro.FecFinUso
            If Not (registro.FecIniUso.ToString = "") Then
                txtFecIniUso.Value = CDate(registro.FecIniUso)
                txtFecIniUso.Text = registro.FecIniUso.ToString
            End If
            If Not (registro.FecFinUso.ToString = "") Then
                txtFecFinUso.Value = CDate(registro.FecFinUso)
                txtFecFinUso.Text = registro.FecFinUso.ToString
            End If
            txtMotivoFinUso.Text = registro.MotivoFinUso
            If Not (registro.FecFinGarantia.ToString = "") Then
                txtFecFinGarantia.Value = CDate(registro.FecFinGarantia)
                txtFecFinGarantia.Text = registro.FecFinGarantia.ToString
            End If

            cbVigente.Checked = registro.Vigente

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        'txtNumLinea.ReadOnly = True
        'txtNumLinea.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        'txtNumLinea.ReadOnly = False
        'txtNumLinea.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New ComputadoraService.Monitor
                Dim tipomonitor As New ComputadoraService.TipoMonitor
                Dim marca As New ComputadoraService.MarcaComputo
                Dim tipodisp As New ComputadoraService.TipoDispositivo
                Dim computadora As New ComputadoraService.Computadora

                computadora.IdComputadora = IdComputadora
                registro.Computadora = computadora

                registro.IdMonitor = IdMonitor
                registro.DesMonitor = txtDesMonitor.Text

                tipodisp.IdTipoDispositivo = cmbTipoDispositivo.Value
                registro.TipoDispositivo = tipodisp

                marca.IdMarca = cmbMarca.Value
                registro.Marca = marca

                registro.Modelo = txtModelo.Text
                registro.Serie = txtSerie.Text
                tipomonitor.IdTipoMonitor = cmbTipoMonitor.Value
                registro.TipoMonitor = tipomonitor
                registro.Dispositivos = txtDispositivos.Text
                registro.Observacion = txtObservacion.Text
                registro.FecIniUso = IIf(txtFecIniUso.Text = "", Nothing, txtFecIniUso.Value)
                registro.FecFinUso = IIf(txtFecFinUso.Text = "", Nothing, txtFecFinUso.Value)

                registro.MotivoFinUso = txtMotivoFinUso.Text

                registro.FecFinGarantia = IIf(txtFecFinGarantia.Text = "", Nothing, txtFecFinGarantia.Value)

                registro.Vigente = cbVigente.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL MONITOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ComputadoraService.Monitor)
        Try
            Dim estado_process As Integer
            estado_process = oComputadoraService.InsertarMonitor(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMonitor = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL MONITOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ComputadoraService.Monitor)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.ActualizarMonitor(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL MONITOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesMonitor.Text) = "" Then
                MsgBox("Debe ingresar la descripción del monitor", MsgBoxStyle.Information, "Información")
                txtDesMonitor.Focus()
                Return False
            ElseIf toBlank(cmbMarca.Value) = "" Then
                MsgBox("Debe ingresar la marca", MsgBoxStyle.Information, "Información")
                cmbMarca.Focus()
                Return False
            ElseIf toBlank(txtModelo.Text) = "" Then
                MsgBox("Debe ingresar el modelo", MsgBoxStyle.Information, "Información")
                txtModelo.Focus()
                Return False
            ElseIf toBlank(txtSerie.Text) = "" Then
                MsgBox("Debe ingresar la serie", MsgBoxStyle.Information, "Información")
                txtSerie.Focus()
                Return False
            ElseIf toBlank(cmbTipoMonitor.text) = "" Then
                MsgBox("Debe ingresar el tipo de monitor", MsgBoxStyle.Information, "Información")
                cmbTipoMonitor.Focus()
                Return False
            ElseIf toBlank(txtDispositivos.Text) = "" Then
                MsgBox("Debe ingresar los dispositivos", MsgBoxStyle.Information, "Información")
                txtDispositivos.Focus()
                Return False
            ElseIf toBlank(txtFecIniUso.Text) = "" Then
                MsgBox("Debe ingresar la fecha de inicio de uso", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False
            ElseIf (toBlank(txtFecFinUso.Text) <> "" And toblank(txtMotivoFinUso.Text) = "") Then
                MsgBox("Debe ingresar el motivo de fin de uso", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False
            ElseIf (toBlank(txtFecFinUso.Text) = "" And toblank(txtMotivoFinUso.Text) <> "") Then
                MsgBox("Debe ingresar la fecha de fin de uso", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False
                'ElseIf toBlank(txtObservacion.text) = "" Then
                '    MsgBox("Debe ingresar la nota", MsgBoxStyle.Information, "Información")
                '    txtObservacion.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                 txtDesMonitor.KeyPress _
 _
               , txtModelo.KeyPress _
               , txtSerie.KeyPress _
               , cmbTipoMonitor.KeyPress _
               , txtDispositivos.KeyPress _
               , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class