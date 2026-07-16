Imports System.ServiceModel
Public Class frmMotivoFalta

    '=========================== Servicios ====================================
    Private oTablasPersonalService As New TablasPersonalService.TablasPersonalServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public CodMotivo As String                  'Código de Cargo seleccionado
    Private dtValorTiempo As DataTable
    Private dtTipo As DataTable

    Private Sub frmCargo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtCodMotivo.TabStop = False
            cmbValorTiempo.Focus()
        Else                                      'Nuevo            
            activar()
            txtCodMotivo.TabStop = True
            txtCodMotivo.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmCargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oTablasPersonalService.Close()
        Catch ex As TimeoutException
            oTablasPersonalService.Abort()
        Catch ex As CommunicationException
            oTablasPersonalService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMotivo.Text) = "" Then
                MsgBox("Debe ingresar le código del Motivo", MsgBoxStyle.Information, "Información")
                txtCodMotivo.Focus()
                Return False
            ElseIf oTablasPersonalService.BuscarMotivoFaltas(txtCodMotivo.Text) And state_button = False Then
                MsgBox("Esté código ya fue ingresado, ¡Verificar...!. ", MsgBoxStyle.Information, "Información")
                txtCodMotivo.Focus()
                Return False
            ElseIf toBlank(cmbValorTiempo.Value) = "" Then
                MsgBox("Debe ingresar la Clase de cargo", MsgBoxStyle.Information, "Información")
                cmbValorTiempo.Focus()
                Return False
            ElseIf toBlank(txtDesMotivo.Text) = "" Then
                MsgBox("Debe ingresar la Descripción del Motivo", MsgBoxStyle.Information, "Información")
                txtDesMotivo.Focus()
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
        txtCodMotivo.ReadOnly = False
        txtCodMotivo.BackColor = System.Drawing.SystemColors.Window
        cmbValorTiempo.ReadOnly = False
        cmbValorTiempo.BackColor = System.Drawing.SystemColors.Window
        txtDesMotivo.ReadOnly = False
        txtDesMotivo.BackColor = System.Drawing.SystemColors.Window
        cbAplicaAsistencia.Enabled = True
        cbAplicaDscto.Enabled = True
        cbPermisoArea.Enabled = True
        btnGuardar.Enabled = True
        cbActivo.Visible = False
    End Sub

    Private Sub desactivar()
        txtCodMotivo.ReadOnly = True
        txtCodMotivo.BackColor = System.Drawing.SystemColors.Control
        cmbValorTiempo.ReadOnly = False
        cmbValorTiempo.BackColor = System.Drawing.SystemColors.Window
        txtDesMotivo.ReadOnly = False
        txtDesMotivo.BackColor = System.Drawing.SystemColors.Window
        cbAplicaAsistencia.Enabled = True
        cbAplicaDscto.Enabled = True
        cbPermisoArea.Enabled = True
        btnGuardar.Enabled = True
        cbActivo.Visible = True
    End Sub

    Private Sub Insertar(ByVal registro As TablasPersonalService.MotivoFaltas)
        Try
            Dim estado_process As String
            estado_process = oTablasPersonalService.InsertarMotivoFaltas(registro)
            type_process = "insert"
            If estado_process = True Then
                CodMotivo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MOTIVO DE FALTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As TablasPersonalService.MotivoFaltas)
        Try
            Dim estado_process As Boolean
            estado_process = oTablasPersonalService.ActualizarMotivoFaltas(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR MOTIVO DE FALTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As TablasPersonalService.MotivoFaltas
            registro = oTablasPersonalService.ObtenerMotivoFaltas(CodMotivo)

            CodMotivo = registro.CodMotivo
            txtCodMotivo.Text = registro.CodMotivo
            txtDesMotivo.Text = registro.DesMotivo
            cmbValorTiempo.Value = registro.ValorTiempo
            cbAplicaAsistencia.Checked = registro.AplicaAsistencia
            cbAplicaDscto.Checked = registro.AplicaDscto
            cbPermisoArea.Checked = registro.PermisoArea
            cbActivo.Checked = registro.Activo
            cmbMotivo.Value = registro.TipoSuspension.CodSuspension
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= VALOR TIEMPO =============================================
            dtValorTiempo = New DataTable
            dtValorTiempo.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtValorTiempo.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtValorTiempo.Rows.Add(New Object() {"1", "Dias"}) ', New DateTime(2008, 2, 5)
            dtValorTiempo.Rows.Add(New Object() {"2", "Horas"})

            cmbValorTiempo.DataSource = dtValorTiempo
            cmbValorTiempo.DropDownList.DataMember = dtValorTiempo.Columns("nombre").ToString
            cmbValorTiempo.DropDownList.DisplayMember = dtValorTiempo.Columns("nombre").ToString
            cmbValorTiempo.DropDownList.ValueMember = dtValorTiempo.Columns("nombre").ToString
            cmbValorTiempo.DropDownList.Columns(0).DataMember = dtValorTiempo.Columns("codigo").ToString
            cmbValorTiempo.DropDownList.Columns(1).DataMember = dtValorTiempo.Columns("nombre").ToString
            cmbValorTiempo.SelectedIndex = 0
            dtValorTiempo = Nothing

            '======================================== TIPO SUSPENSION ================================================
            dtTipo = oTablasPersonalService.MostrarTipoSuspension().Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbMotivo.DataSource = dtTipo
            cmbMotivo.DropDownList.DataMember = dtTipo.Columns("DesSuspension").ToString
            cmbMotivo.DropDownList.DisplayMember = dtTipo.Columns("DesSuspension").ToString
            cmbMotivo.DropDownList.ValueMember = dtTipo.Columns("CodSuspension").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtTipo.Columns("CodSuspension").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesSuspension").ToString
            cmbMotivo.SelectedIndex = 0
            dtTipo = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New TablasPersonalService.MotivoFaltas
                Dim tipoSuspension As New TablasPersonalService.TipoSuspension

                registro.CodMotivo = txtCodMotivo.Text                
                registro.DesMotivo = txtDesMotivo.Text
                registro.ValorTiempo = cmbValorTiempo.Value
                registro.AplicaAsistencia = cbAplicaAsistencia.Checked
                registro.AplicaDscto = cbAplicaDscto.Checked
                registro.PermisoArea = cbPermisoArea.Checked
                registro.Activo = cbActivo.Checked
                tipoSuspension.CodSuspension = cmbMotivo.Value
                registro.TipoSuspension = tipoSuspension
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
            MsgBox("ERROR AL GUARDAR MOTIVO DE FALTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtCodMotivo.KeyPress _
                           , cmbValorTiempo.KeyPress _
                           , txtDesMotivo.KeyPress _
                           , cbAplicaAsistencia.KeyPress _
                           , cbAplicaDscto.KeyPress _
                           , cbPermisoArea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class