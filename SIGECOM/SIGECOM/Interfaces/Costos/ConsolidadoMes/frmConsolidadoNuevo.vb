Imports System.ServiceModel
Imports System.Net
Imports System.Net.Sockets
Public Class frmConsolidadoNuevo
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjConsolidado As New ConsolidadoMesService.ConsolidadoMesServiceClient
    Private dtOficina, dtAlmacen, dtMes As New DataTable
    Public IdLocacion As Integer
    Public IdConsolidado As Integer

    Private Sub frmConsolidadoNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtPeriodo.KeyPress _
       , cbMes.KeyPress _
        , cbOficina.KeyPress _
        , clFecIni.KeyPress
        ' , clFecFin.KeyPress _
        ' , cbAlmacen.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmConsolidadoNuevo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjConsolidado.Close()
            ObjMaestro.Close()
        Catch ex As TimeoutException
            ObjConsolidado.Abort()
            ObjMaestro.Abort()
        Catch ex As CommunicationException
            ObjConsolidado.Abort()
            ObjMaestro.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub


    Private Sub frmConsolidadoNuevo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub frmConsolidadoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        rbUno.Checked = True
        lblMensaje.Visible = False
        ProgressBar1.Visible = False
    End Sub
    Private Sub LlenarCombos()
        Try
            txtPeriodo.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))


            dtMes = ObjMaestro.MostrarMeses
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            MostrarFecIni()
            MostrarFecFin()

            'dtOficina = ObjMaestro.MostrarOficinas().Tables(0)
            'cbOficina.DataSource = dtOficina
            'cbOficina.DisplayMember = "DesOfi"
            'cbOficina.ValueMember = "CodOfi"
            'cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            'cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            'cbOficina.SelectedIndex = 0
            'dtOficina = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarFecIni() Handles txtPeriodo.ValueChanged, cbMes.ValueChanged
        If cbMes.Value > 0 Then
            clFecIni.Value = "01/" & IIf(cbMes.Value > 9, cbMes.Value, "0" & cbMes.Value) & "/" & txtPeriodo.Value
        End If
    End Sub
    Private Sub MostrarFecFin() Handles txtPeriodo.ValueChanged, cbMes.ValueChanged
        If cbMes.Value > 0 Then
            clFecFin.Text = DateSerial(txtPeriodo.Value, cbMes.Value + 1, 0)
        End If
    End Sub
    'Private Sub Finalizar()
    '    ObjMaestro.Close()
    '    ObjConsolidado.Close()
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        If cbOficina.Value <> 0 Then
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        End If
    End Sub

    Private Sub rbUno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUno.CheckedChanged
        If rbUno.Checked Then
            cbOficina.Enabled = True
            cbAlmacen.Enabled = True
            dtOficina = ObjMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing
        Else
            cbOficina.DataSource = Nothing
            cbAlmacen.DataSource = Nothing
            cbOficina.Value = Nothing
            cbAlmacen.Value = Nothing
            cbOficina.Enabled = False
            cbAlmacen.Enabled = False
        End If
    End Sub

    Private Sub rbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked Then
            cbOficina.Enabled = False
            cbAlmacen.Enabled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        lblMensaje.Visible = False
        lblMensaje.Enabled = False
        If MsgBox("¿Está seguro de REALIZAR el Proceso?", MsgBoxStyle.YesNo, "Procesar") = MsgBoxResult.Yes Then
            Try
                ' Dim NomPc As String = Dns.GetHostName
                ' Dim DirIp As IPAddress = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(f) f.AddressFamily.Equals(AddressFamily.InterNetwork))
                Dim Registro As New ConsolidadoMesService.ConsolidadoMes
                Dim Locacion As New ConsolidadoMesService.Locacion

                Registro.Periodo = txtPeriodo.Value
                Registro.Mes = cbMes.Value
                lblMensaje.Visible = True
                lblMensaje.Enabled = True
                Locacion.IdLocacion = IIf(rbUno.Checked, cbAlmacen.Value, 0)
                Registro.Locacion = Locacion
                IdLocacion = IIf(rbUno.Checked, cbAlmacen.Value, 0)
                Registro.FecIni = clFecIni.Value
                Registro.FecFin = clFecFin.Value
                Registro.CodUsu = Session.sCodUsu
                Registro.NomPC = Session.sNomPc  'NomPc
                Registro.DirIp = Session.sDirIp   'DirIp.ToString

                Insertar(Registro)
                'btnCancelar_Click(sender, e)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Procesar")
            End Try
        Else
            lblMensaje.Text = ""
            lblProgreso.Text = ""
            lblMensaje.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub
    Private Sub Insertar(ByVal Registro)
        Try
            Dim estado_process As Integer
            ObjConsolidado.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
            estado_process = ObjConsolidado.Insertar(Registro)
            Timer1.Start()
            If estado_process > 0 Then
                IdConsolidado = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub rbTodos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbTodos.KeyPress, rbUno.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPeriodo.Select()
        End If
    End Sub

    Private Sub clFecFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles clFecFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If rbTodos.Checked Then
                btnAceptar.Focus()
            ElseIf rbUno.Checked Then
                cbOficina.Focus()
            End If
        End If
    End Sub
    Private Sub cbAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblMensaje.Visible = False
        ProgressBar1.Visible = True
        ProgressBar1.Value += 20
        lblProgreso.Text = CLng((ProgressBar1.Value * 100) / ProgressBar1.Maximum) & "%"
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Value = 0
            lblProgreso.Text = ""
            ProgressBar1.Visible = False
            MsgBox("Se Realizó el proceso con éxito", MsgBoxStyle.Information, "Final Exitoso")
        End If
    End Sub
End Class