Imports System.Net
Imports System.ServiceModel

Public Class frmVisitaCobrador

    Private oMaestroService As New MaestroService.MaestroClient
    Private oVisitaCobradorService As New VisitaCobradorService.VisitaCobradorServiceClient
    Private IdCliente As Integer
    Private dtCobrador As DataTable
    Private dtActividad As DataTable
    Private dtResultado As DataTable
    Private dtMonedas As DataTable
    Public IdVisita As Integer
    Public IdPer As Integer
    Public state_button As Boolean

    Private Sub frmVisitaCobrador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oVisitaCobradorService) = False Then
                oVisitaCobradorService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub frmVisitaCobrador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
        End If
    End Sub
    Private Sub cmbCobrador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCobrador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Focus()
            End If
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cmbCobrador.Enabled = True Then
                cmbCobrador.Focus()
            Else
                btnBuscarCliente.Focus()

            End If
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            End If
        End If
    End Sub


    Private Sub frmVisitaCobrador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCliente.KeyPress _
         , cmbActividad.KeyPress _
          , cmbResultado.KeyPress _
          , cmbCodMon.KeyPress _
          , txtImporte.KeyPress
        ', cmbCobrador.KeyPress _
        ',txtFecha.KeyPress _
        ' , txtObservacion.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmVisitaCobrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Ver/Modificar
            ObtenerRegistro()
            desactivar()
            enableOpciones()
            biEditar.Enabled = False

        Else  'Nuevo
            txtFecha.Text = Today
            cmbCodMon.Value = "NS"
            If Session.CodPerfil = 10 Then
                cmbCobrador.Value = IdPer
            End If
            enableOpciones()

            Me.Text = "Registrar nueva Visita"
        End If
        
    End Sub
    Private Sub enableOpciones()
        If state_button Then
            biGrabar.Enabled = False
            biEditar.Enabled = True
            biDeshacer.Enabled = False
        Else
            biGrabar.Enabled = True
            biEditar.Enabled = False
            biDeshacer.Enabled = True
            biSalir.Enabled = False
        End If
      
    End Sub

    Private Sub llenarCombos()
        '==================================COBRADOR======================================================
        dtCobrador = oMaestroService.MostrarCobradores.Tables(0)
        cmbCobrador.DataSource = dtCobrador
        cmbCobrador.DisplayMember = "ApeNom"
        cmbCobrador.ValueMember = "IdPer"
        cmbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
        cmbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
        'cmbCobrador.SelectedIndex = 0
        dtCobrador = Nothing
        '======================================= MONEDAS ================================================
        dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
        cmbCodMon.DataSource = dtMonedas
        cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
        cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
        cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
        cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
        cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
        dtMonedas = Nothing

        '==================================ACTIVIDAD=======================================================
        dtActividad = oVisitaCobradorService.MostrarActividad.Tables(0)
        'dtActividad.Rows.InsertAt(getRowTodos(dtActividad), 0)
        cmbActividad.DataSource = dtActividad
        cmbActividad.DisplayMember = "DesActividad"
        cmbActividad.ValueMember = "IdActividad"
        cmbActividad.DropDownList.Columns(0).DataMember = "IdActividad"
        cmbActividad.DropDownList.Columns(1).DataMember = "DesActividad"
        'cbCobrador.SelectedIndex = 0
        dtActividad = Nothing
        '=================================RESULTADO ======================================================
        dtResultado = oVisitaCobradorService.MostrarResultado.Tables(0)
        'dtResultado.Rows.InsertAt(getRowTodos(dtResultado), 0)
        cmbResultado.DataSource = dtResultado
        cmbResultado.DisplayMember = "DesResultado"
        cmbResultado.ValueMember = "IdResultado"
        cmbResultado.DropDownList.Columns(0).DataMember = "IdResultado"
        cmbResultado.DropDownList.Columns(1).DataMember = "DesResultado"
        'cbCobrador.SelectedIndex = 0
        dtResultado = Nothing

    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As New VisitaCobradorService.VisitaCobrador
            registro = oVisitaCobradorService.Obtener(IdVisita)

            txtFecha.Text = registro.Fecha
            cmbCodMon.Value = registro.Moneda.CodMon
            cmbCobrador.Value = registro.Persona.IdPer
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbActividad.Value = registro.ActividadVisita.IdActividad
            txtObservacion.Text = registro.Observacion
            cmbResultado.Value = registro.ResultadoVisita.IdResultado
            txtImporte.Text = registro.Movilidad

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()

        cmbActividad.ReadOnly = False
        If Session.CodPerfil <> 10 Then
            cmbCobrador.Enabled = True
        Else
            cmbCobrador.Enabled = False
        End If
        cmbCobrador.ReadOnly = False
        cmbCodMon.ReadOnly = False
        cmbResultado.ReadOnly = False
        txtFecha.ReadOnly = False
        txtImporte.ReadOnly = False
        txtObservacion.ReadOnly = False
        btnBuscarCliente.Enabled = True
        biDeshacer.Enabled = True
        biEditar.Enabled = False
        biGrabar.Enabled = True

        cmbActividad.BackColor = System.Drawing.SystemColors.Window
        cmbCobrador.BackColor = System.Drawing.SystemColors.Window
        cmbResultado.BackColor = System.Drawing.SystemColors.Window
        cmbCodMon.BackColor = System.Drawing.SystemColors.Window
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtImporte.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.BackColor = System.Drawing.SystemColors.Window

    End Sub
    Private Sub desactivar()

        cmbActividad.ReadOnly = True
        cmbCobrador.Enabled = False
        cmbResultado.ReadOnly = True
        cmbCodMon.ReadOnly = True
        cmbResultado.ReadOnly = True
        txtFecha.ReadOnly = True
        txtImporte.ReadOnly = True
        txtObservacion.ReadOnly = True
        btnBuscarCliente.Enabled = False
        biDeshacer.Enabled = False
        biEditar.Enabled = True
        biGrabar.Enabled = False

        cmbActividad.BackColor = System.Drawing.SystemColors.Control
        cmbCobrador.BackColor = System.Drawing.SystemColors.Control
        cmbResultado.BackColor = System.Drawing.SystemColors.Control
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtImporte.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.BackColor = System.Drawing.SystemColors.Control

    End Sub
    Private Function ValidarCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe de ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe de ingresar el Tipo de Moneda .", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
            ElseIf toNumber(cmbActividad.Value) = 0 Then
                MsgBox("Debe de ingresar la actividad de la visita.", MsgBoxStyle.Information, "Información")
                cmbActividad.BackColor = Color.Red
                cmbActividad.Focus()
            ElseIf toNumber(cmbCobrador.Value) = 0 Then
                MsgBox("Debe de ingresar el Cobrador  .", MsgBoxStyle.Information, "Información")
                cmbCobrador.BackColor = Color.Red
                cmbCobrador.Focus()
            ElseIf toNumber(cmbResultado.Value) = 0 Then
                MsgBox("Debe de ingresar el resultado de la visita  .", MsgBoxStyle.Information, "Información")
                cmbResultado.BackColor = Color.Red
                cmbResultado.Focus()
                'ElseIf toBlank(txtImporte.Text) = "" Or toBlank(txtImporte.Text) = 0 Then
                '    MsgBox("Debe de ingresar el Monto por Movilidad  .", MsgBoxStyle.Information, "Información")
                '    txtImporte.BackColor = Color.Red
                '    txtImporte.Focus()
            ElseIf toBlank(txtCliente.Text) = "" Then
                MsgBox("Debe de ingresar el Cliente  .", MsgBoxStyle.Information, "Información")
                'btnBuscarCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click

        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidarCampos() Then

            Dim registro As New VisitaCobradorService.VisitaCobrador
            Dim moneda As New VisitaCobradorService.Moneda
            Dim cliente As New VisitaCobradorService.Cliente
            Dim actividad As New VisitaCobradorService.ActividadVisita
            Dim resultado As New VisitaCobradorService.ResultadoVisita
            Dim cobrador As New VisitaCobradorService.Persona
            Dim empresa As New VisitaCobradorService.Empresa
            Dim NomPc As String = Dns.GetHostName
            'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)

            registro.IdVisita = IdVisita
            moneda.CodMon = cmbCodMon.Value
            registro.Moneda = moneda
            registro.Fecha = txtFecha.Text
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            actividad.IdActividad = cmbActividad.Value
            registro.ActividadVisita = actividad
            resultado.IdResultado = cmbResultado.Value
            registro.ResultadoVisita = resultado
            cobrador.IdPer = cmbCobrador.Value
            registro.Persona = cobrador
            registro.Movilidad = txtImporte.Text
            registro.Observacion = txtObservacion.Text
            registro.DirIp = Session.sDirIp 'DirIp.AddressList(0).ToString
            registro.NomPc = NomPc
            registro.CodUsu = Session.sCodUsu
            empresa.CodEmp = Session.sCodEmp
            registro.Empresa = empresa
            Insertar(registro)

        End If
    End Sub
    Private Sub Insertar(ByVal registro As VisitaCobradorService.VisitaCobrador)
        Try

            Dim estado_process As Integer
            estado_process = oVisitaCobradorService.Insertar(registro)
            If estado_process > 0 Then
                IdVisita = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INSERTAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
  
    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
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

End Class