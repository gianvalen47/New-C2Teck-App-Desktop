Imports System.ServiceModel

Public Class frmSoftware


    '=========================== Servicios ===================================================
    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    'Public IdLinea As Integer                        'Linea Telefonica
    Public IdSoftware As Integer
    Public IdComputadora As Integer
    Private dtTipoSoftware As DataTable

    Private Sub frmSoftware_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            'txtFecha.TabStop = False

        Else                                      'Nuevo            
            activar()
            cbVigente.Checked = True
            cbLicenciaAplica.Checked = False
            txtFecIniLic.ReadOnly = True
            txtFecIniLic.BackColor = System.Drawing.SystemColors.Control
            txtFecFinLic.ReadOnly = True
            txtFecFinLic.BackColor = System.Drawing.SystemColors.Control
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub frmSoftware_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSoftware_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= TIPO SOFTWARE ================================================
            dtTipoSoftware = oComputadoraService.MostrarTipoSoftware().Tables(0)
            'dtTipoSoftware.Rows.InsertAt(getRowTodos(dtTipoSoftware), 0)
            cmbTipoSoftware.DataSource = dtTipoSoftware
            cmbTipoSoftware.DropDownList.DataMember = dtTipoSoftware.Columns("DesTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.DisplayMember = dtTipoSoftware.Columns("DesTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.ValueMember = dtTipoSoftware.Columns("IdTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.Columns(0).DataMember = dtTipoSoftware.Columns("IdTipoSoftware").ToString
            cmbTipoSoftware.DropDownList.Columns(1).DataMember = dtTipoSoftware.Columns("DesTipoSoftware").ToString
            cmbTipoSoftware.SelectedIndex = 0
            dtTipoSoftware = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ComputadoraService.Software
            registro = oComputadoraService.ObtenerSoftware(IdSoftware)

            IdSoftware = registro.IdSoftware
            cmbTipoSoftware.Value = registro.TipoSoftware.IdTipoSoftware
            txtNomAplicacion.Text = registro.NomAplicacion
            cbLicenciaAplica.Checked = registro.LicenciaAplica
            If Not (registro.FecIniLic.ToString = "") Then
                txtFecIniLic.Value = CDate(registro.FecIniLic)
                txtFecIniLic.Text = registro.FecIniLic.ToString
            End If
            If Not (registro.FecFinLic.ToString = "") Then
                txtFecFinLic.Value = CDate(registro.FecFinLic)
                txtFecFinLic.Text = registro.FecFinLic.ToString
            End If
            'txtFecIniLic.Value = registro.FecIniLic
            'txtFecFinLic.Value = registro.FecFinLic
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
            If ValidaCampos() Then 'MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                'And ValidaCampos() Then
                Dim registro As New ComputadoraService.Software
                Dim tiposoftware As New ComputadoraService.TipoSoftware
                Dim computadora As New ComputadoraService.Computadora
                'Dim plan As New LineasService.Planes

                registro.IdSoftware = IdSoftware

                tiposoftware.IdTipoSoftware = cmbTipoSoftware.Value
                registro.TipoSoftware = tiposoftware

                registro.NomAplicacion = txtNomAplicacion.Text
                registro.LicenciaAplica = cbLicenciaAplica.Checked
                registro.FecIniLic = IIf(txtFecIniLic.Text = "", Nothing, txtFecIniLic.Value) 'txtFecIniLic.Value
                registro.FecFinLic = IIf(txtFecFinLic.Text = "", Nothing, txtFecFinLic.Value) ' txtFecFinLic.Value
                registro.Vigente = cbVigente.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ComputadoraService.Software)
        Try
            Dim estado_process As Integer
            estado_process = oComputadoraService.InsertarSoftware(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdSoftware = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ComputadoraService.Software)
        Try
            Dim estado_process As Boolean
            estado_process = oComputadoraService.ActualizarSoftware(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL SOFTWARE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNomAplicacion.Text) = "" Then
                MsgBox("Debe ingresar el nombre de la aplicación", MsgBoxStyle.Information, "Información")
                txtNomAplicacion.Focus()
                Return False
            ElseIf toBlank(cmbTipoSoftware.Value) = "" Then
                MsgBox("Debe ingresar el tipo de software", MsgBoxStyle.Information, "Información")
                cmbTipoSoftware.Focus()
                Return False
                'ElseIf toBlank(txtModelo.Text) = "" Then
                '    MsgBox("Debe ingresar el modelo", MsgBoxStyle.Information, "Información")
                '    txtModelo.Focus()
                '    Return False
                'ElseIf toBlank(txtSerie.Text) = "" Then
                '    MsgBox("Debe ingresar la serie", MsgBoxStyle.Information, "Información")
                '    txtSerie.Focus()
                '    Return False
                'ElseIf toBlank(txtTipoProcesador.text) = "" Then
                '    MsgBox("Debe ingresar el tipo de procesador", MsgBoxStyle.Information, "Información")
                '    txtTipoProcesador.Focus()
                '    Return False
                'ElseIf toBlank(txtVelocidadProcesador.text) = "" Then
                '    MsgBox("Debe ingresar la velocidad del procesador", MsgBoxStyle.Information, "Información")
                '    txtVelocidadProcesador.Focus()
                '    Return False
                'ElseIf toBlank(txtGeneracionProcesador.text) = "" Then
                '    MsgBox("Debe ingresar la generacion del procesador", MsgBoxStyle.Information, "Información")
                '    txtGeneracionProcesador.Focus()
                '    Return False
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
                 txtNomAplicacion.KeyPress _
               , cmbTipoSoftware.KeyPress _
               , txtFecIniLic.KeyPress _
               , txtFecFinLic.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbLicenciaAplica_CheckedChanged(sender As Object, e As EventArgs) Handles cbLicenciaAplica.CheckedChanged
        If cbLicenciaAplica.Checked Then
            txtFecIniLic.ReadOnly = False
            txtFecIniLic.BackColor = System.Drawing.SystemColors.Window
            txtFecFinLic.ReadOnly = False
            txtFecFinLic.BackColor = System.Drawing.SystemColors.Window
        Else
            txtFecIniLic.ReadOnly = True
            txtFecIniLic.BackColor = System.Drawing.SystemColors.Control
            txtFecIniLic.Text = ""
            txtFecFinLic.ReadOnly = True
            txtFecFinLic.BackColor = System.Drawing.SystemColors.Control
            txtFecFinLic.Text = ""
        End If
    End Sub
End Class