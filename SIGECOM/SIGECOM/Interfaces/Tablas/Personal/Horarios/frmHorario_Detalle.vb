Imports System.ServiceModel
Public Class frmHorario_Detalle

    '============================Servicios===================================
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private oHorarioDetService As New HorarioDetService.HorarioDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public CodHor As String
    Public DiaHor As String
    Private dtDias As DataTable


    Private Sub frmHorario_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmHorario_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtHoraIngreso.Focus()
        Else                                      'Nuevo
            txtHoraIngreso.Text = Now().ToString("HH:mm:ss")
            txtHoraSalida.Text = Now().ToString("HH:mm:ss")
            txtIngresoRefrig.Text = Now().ToString("HH:mm:ss")
            txtSalidaRefrig.Text = Now().ToString("HH:mm:ss")
            activar()
            cmbDias.Focus()           
        End If
        EnableOptions()
    End Sub

    Private Sub frmHorario_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oHorarioService.Close()
            oHorarioDetService.Close()
        Catch ex As TimeoutException
            oHorarioService.Abort()
            oHorarioDetService.Abort()
        Catch ex As CommunicationException
            oHorarioService.Abort()
            oHorarioDetService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbDias.Value) = "" Then
                MsgBox("Debe ingresar el día.", MsgBoxStyle.Information, "Información")
                cmbDias.Focus()
                Return False
            ElseIf Not (txtHoraIngreso.MaskFull) Then
                MsgBox("Debe Ingresar la hora de ingreso.", MsgBoxStyle.Information, "Información")
                txtHoraIngreso.Focus()
                Return False
            ElseIf Not (txtHoraSalida.MaskFull) Then
                MsgBox("Debe Ingresar la hora de salida.", MsgBoxStyle.Information, "Información")
                txtHoraSalida.Focus()
                Return False
            ElseIf Not (txtIngresoRefrig.MaskFull) Then
                MsgBox("Debe Ingresar la hora de ingreso de refrigerio.", MsgBoxStyle.Information, "Información")
                txtIngresoRefrig.Focus()
                Return False
            ElseIf Not (txtSalidaRefrig.MaskFull) Then
                MsgBox("Debe Ingresar la hora de salida de refrigerio.", MsgBoxStyle.Information, "Información")
                txtSalidaRefrig.Focus()
                Return False
            ElseIf state_button = False And oHorarioDetService.Buscar(CodHor, Session.sCodEmp, toNumber(cmbDias.Value)) = True Then
                MsgBox("Este día ya fue ingresado en el horario.", MsgBoxStyle.Information, "Información")
                cmbDias.Focus()
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
        cmbDias.ReadOnly = False
        cmbDias.BackColor = System.Drawing.SystemColors.Window
        txtHoraIngreso.ReadOnly = False
        txtHoraIngreso.BackColor = System.Drawing.SystemColors.Window
        txtHoraSalida.ReadOnly = False
        txtHoraSalida.BackColor = System.Drawing.SystemColors.Window
        txtIngresoRefrig.ReadOnly = False
        txtIngresoRefrig.BackColor = System.Drawing.SystemColors.Window
        txtSalidaRefrig.ReadOnly = False
        txtSalidaRefrig.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        cmbDias.ReadOnly = True
        cmbDias.BackColor = System.Drawing.SystemColors.Control
        txtHoraIngreso.ReadOnly = False
        txtHoraIngreso.BackColor = System.Drawing.SystemColors.Window
        txtHoraSalida.ReadOnly = False
        txtHoraSalida.BackColor = System.Drawing.SystemColors.Window
        txtIngresoRefrig.ReadOnly = False
        txtIngresoRefrig.BackColor = System.Drawing.SystemColors.Window
        txtSalidaRefrig.ReadOnly = False
        txtSalidaRefrig.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As HorarioDetService.HorarioDet)
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioDetService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                CodHor = CodHor
                DiaHor = cmbDias.value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As HorarioDetService.HorarioDet)
        Try
            Dim estado_process As Boolean
            estado_process = oHorarioDetService.Actualizar(registro)
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
            Dim registro As HorarioDetService.HorarioDet
            registro = oHorarioDetService.Obtener(CodHor, Session.sCodEmp, DiaHor)

            CodHor = registro.Horario.CodHor
            DiaHor = registro.DiaHor
            cmbDias.Value = CStr(registro.DiaHor)
            txtHoraIngreso.Text = registro.HorIng.ToString("HH:mm:ss")
            txtHoraSalida.Text = registro.HorSal.ToString("HH:mm:ss")
            txtIngresoRefrig.Text = registro.IngRef.ToString("HH:mm:ss")
            txtSalidaRefrig.Text = registro.SalRef.ToString("HH:mm:ss")

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '==================================== DÍAS =============================================
            dtDias = New DataTable
            dtDias.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtDias.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))            
            dtDias.Rows.Add(New Object() {"1", "LUNES"})
            dtDias.Rows.Add(New Object() {"2", "MARTES"})
            dtDias.Rows.Add(New Object() {"3", "MIÉRCOLES"})
            dtDias.Rows.Add(New Object() {"4", "JUEVES"})
            dtDias.Rows.Add(New Object() {"5", "VIERNES"})
            dtDias.Rows.Add(New Object() {"6", "SÁBADO"})
            dtDias.Rows.Add(New Object() {"7", "DOMINGO"})

            cmbDias.DataSource = dtDias
            cmbDias.DropDownList.DataMember = dtDias.Columns("nombre").ToString
            cmbDias.DropDownList.DisplayMember = dtDias.Columns("nombre").ToString
            cmbDias.DropDownList.ValueMember = dtDias.Columns("codigo").ToString
            cmbDias.DropDownList.Columns(0).DataMember = dtDias.Columns("codigo").ToString
            cmbDias.DropDownList.Columns(1).DataMember = dtDias.Columns("nombre").ToString
            cmbDias.SelectedIndex = 0
            dtDias = Nothing

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
            Dim registro As New HorarioDetService.HorarioDet
            Dim Horario As New HorarioDetService.Horario
            Dim empresa As New HorarioDetService.Empresa

            empresa.CodEmp = Session.sCodEmp
            Horario.CodHor = CodHor
            Horario.Empresa = empresa
            registro.Horario = Horario
            registro.DiaHor = toNumber(cmbDias.Value)
            registro.DesDia = cmbDias.Text
            registro.HorIng = txtHoraIngreso.Text
            registro.HorSal = txtHoraSalida.Text
            registro.IngRef = txtIngresoRefrig.Text
            registro.SalRef = txtSalidaRefrig.Text

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

    '==================================== Evento KeyPress ============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbDias.KeyPress, _
                            txtHoraIngreso.KeyPress, _
                            txtHoraSalida.KeyPress, _
                            txtIngresoRefrig.KeyPress, _
                            txtSalidaRefrig.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub txtIngresoRefrig_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class