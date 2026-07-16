Imports System.ServiceModel
Public Class frmEvaluacion_Detalle

    '============================Servicios===================================
    Private oEvaluacionService As New EvaluacionService.EvaluacionServiceClient
    Private oEvaluacionDetService As New EvaluacionDetService.EvaluacionDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: modificar    False: nuevo
    Public type_process As String            'update     insert      delete    
    Public IdEvaluacionDet As Integer
    Public IdEvaluacion As Integer

    Public iEstado As Integer
    Private dtCompetencia As DataTable
    Private dtNivel As DataTable
    Public idper As Integer

    Private Sub frmEvaluacion_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmEvaluacion_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtRecomendacion.Focus()
        Else                                      'Nuevo
            activar()
            cmbCompetencia.TabStop = True
            cmbCompetencia.Focus()
        End If

        EnableOptions()
    End Sub


    Private Sub frmEvaluacion_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oEvaluacionService.Close()
            oEvaluacionDetService.Close()            
        Catch ex As TimeoutException
            oEvaluacionService.Abort()
            oEvaluacionDetService.Abort()            
        Catch ex As CommunicationException
            oEvaluacionService.Abort()
            oEvaluacionDetService.Abort()            
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbCompetencia.Value) = "" Then
                MsgBox("Debe ingresar la competencia.", MsgBoxStyle.Information, "Información")
                cmbCompetencia.Focus()
                Return False
            ElseIf toBlank(cmbNivel.Value) = "" Then
                MsgBox("Debe Ingresar el nivel.", MsgBoxStyle.Information, "Información")
                cmbNivel.Focus()
                Return False
            ElseIf (toBlank(cmbNivel.Value) = "C" Or toBlank(cmbNivel.Value) = "D") And toBlank(txtRecomendacion.Text) = "" Then
                MsgBox("Debe Ingresar la recomendación del Evaluador.", MsgBoxStyle.Information, "Información")
                txtRecomendacion.Focus()
                Return False
            ElseIf (toBlank(cmbNivel.Value) = "C" Or toBlank(cmbNivel.Value) = "D") And toBlank(txtCompromiso.Text) = "" Then
                MsgBox("Debe Ingresar el compromiso del Evaluado.", MsgBoxStyle.Information, "Información")
                txtCompromiso.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        'If iPagado = False Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub activar()
        cmbCompetencia.ReadOnly = False
        cmbCompetencia.BackColor = System.Drawing.SystemColors.Window
        cmbNivel.ReadOnly = False
        cmbNivel.BackColor = System.Drawing.SystemColors.Window
        txtRecomendacion.ReadOnly = False
        txtRecomendacion.BackColor = System.Drawing.SystemColors.Window
        txtCompromiso.ReadOnly = False
        txtCompromiso.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        iEstado = oEvaluacionService.ObtenerEstado(IdEvaluacion)
        If iEstado = 2 Then
            cmbCompetencia.ReadOnly = True
            cmbCompetencia.BackColor = System.Drawing.SystemColors.Control
            cmbNivel.ReadOnly = True
            cmbNivel.BackColor = System.Drawing.SystemColors.Control
            txtRecomendacion.ReadOnly = True
            txtRecomendacion.BackColor = System.Drawing.SystemColors.Control
            txtCompromiso.ReadOnly = True
            txtCompromiso.BackColor = System.Drawing.SystemColors.Control
            btnGuardar.Enabled = False
        Else
            cmbCompetencia.ReadOnly = True
            cmbCompetencia.BackColor = System.Drawing.SystemColors.Control
            cmbNivel.ReadOnly = False
            cmbNivel.BackColor = System.Drawing.SystemColors.Window
            txtRecomendacion.ReadOnly = False
            txtRecomendacion.BackColor = System.Drawing.SystemColors.Window
            txtCompromiso.ReadOnly = False
            txtCompromiso.BackColor = System.Drawing.SystemColors.Window
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub Insertar(ByVal registro As EvaluacionDetService.EvaluacionDet)
        Try
            Dim estado_process As Integer
            estado_process = oEvaluacionDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdEvaluacionDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EvaluacionDetService.EvaluacionDet)
        Try
            Dim estado_process As Boolean
            estado_process = oEvaluacionDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EvaluacionDetService.EvaluacionDet
            registro = oEvaluacionDetService.Obtener(IdEvaluacionDet)

            IdEvaluacionDet = registro.IdEvaluacionDet            
            IdEvaluacion = registro.Evaluacion.IdEvaluacion
            cmbCompetencia.Value = registro.Competencia.IdCompetencia
            cmbNivel.Value = IIf(toBlank(registro.NivelCompetencia.CodNivel) = "", cmbNivel.SelectedIndex = 0, registro.NivelCompetencia.CodNivel)
            txtPuntaje.Value = registro.Puntaje            
            txtRecomendacion.Text = registro.Recomendacion
            txtCompromiso.Text = registro.Compromiso

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= COMPETENCIAS ===========================================
            dtCompetencia = oEvaluacionDetService.MostrarCompetenciasPersona(idper).Tables(0)
            cmbCompetencia.DataSource = dtCompetencia
            cmbCompetencia.DropDownList.DataMember = dtCompetencia.Columns("NomCompetencia").ToString
            cmbCompetencia.DropDownList.DisplayMember = dtCompetencia.Columns("NomCompetencia").ToString
            cmbCompetencia.DropDownList.ValueMember = dtCompetencia.Columns("IdCompetencia").ToString
            cmbCompetencia.DropDownList.Columns(0).DataMember = dtCompetencia.Columns("IdCompetencia").ToString
            cmbCompetencia.DropDownList.Columns(1).DataMember = dtCompetencia.Columns("NomCompetencia").ToString
            cmbCompetencia.DropDownList.Columns(2).DataMember = dtCompetencia.Columns("DesCompetencia").ToString
            cmbCompetencia.SelectedIndex = 0
            dtCompetencia = Nothing


            ''======================================= NIVEL ===========================================
            dtNivel = oEvaluacionDetService.MostrarNivelCompetencia().Tables(0)
            cmbNivel.DataSource = dtNivel
            cmbNivel.DropDownList.DataMember = dtNivel.Columns("NomNivel").ToString
            cmbNivel.DropDownList.DisplayMember = dtNivel.Columns("NomNivel").ToString
            cmbNivel.DropDownList.ValueMember = dtNivel.Columns("CodNivel").ToString
            cmbNivel.DropDownList.Columns(0).DataMember = dtNivel.Columns("CodNivel").ToString
            cmbNivel.DropDownList.Columns(1).DataMember = dtNivel.Columns("NomNivel").ToString
            cmbNivel.DropDownList.Columns(2).DataMember = dtNivel.Columns("DesNivel").ToString
            cmbNivel.DropDownList.Columns(3).DataMember = dtNivel.Columns("Puntaje").ToString
            cmbNivel.SelectedIndex = 0
            dtNivel = Nothing

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
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New EvaluacionDetService.EvaluacionDet
            Dim Evaluacion As New EvaluacionDetService.Evaluacion
            Dim Competencia As New EvaluacionDetService.Competencia
            Dim Nivel As New EvaluacionDetService.NivelCompetencia

            registro.IdEvaluacionDet = IdEvaluacionDet
            Evaluacion.IdEvaluacion = IdEvaluacion
            registro.Evaluacion = Evaluacion
            Competencia.IdCompetencia = toNumber(cmbCompetencia.Value)
            registro.Competencia = Competencia
            Nivel.CodNivel = toBlank(cmbNivel.Value)
            registro.NivelCompetencia = Nivel
            registro.Puntaje = txtPuntaje.Value            
            registro.Recomendacion = IIf(txtRecomendacion.Text = "", Nothing, txtRecomendacion.Text)
            registro.Compromiso = IIf(txtCompromiso.Text = "", Nothing, txtCompromiso.Text)

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo                
                Insertar(registro)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbCompetencia.KeyPress _
                           , cmbNivel.KeyPress
        ', txtRecomendacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    'Private Sub txtCompromiso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCompromiso.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        btnGuardar.Focus()
    '    End If
    'End Sub

    Private Sub cmbNivel_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbNivel.ValueChanged
        'If cmbNivel.SelectedIndex <> 0 Then
        txtPuntaje.Value = toNumber(cmbNivel.DropDownList.GetRow.Cells(3).Text)    'Obtiene el Texto de la 4 columna del Combo Nivel
        lblDesNivel.Text = "*" & toBlank(cmbNivel.DropDownList.GetRow.Cells(2).Text)
        'Else
        'txtPuntaje.Value = 0
        'End If
    End Sub

    Private Sub cmbCompetencia_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbCompetencia.ValueChanged
        lblDesCompetencia.Text = "*" & toBlank(cmbCompetencia.DropDownList.GetRow.Cells(2).Text)
    End Sub
End Class