Imports System.ServiceModel
Public Class frmVisitaOportunidad

    '============================Servicios===================================
    Private oVisitaOportunidadService As New VisitaOportunidadService.VisitaOportunidadServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdOportunidad As Integer
    Public IdVisita As Integer
    Public IdCliente As Integer
    Public iEtapa As Integer
    Private dtContactos As DataTable
    Private dtTipoVisita As DataTable

    Private Sub frmVisitaOportunidad_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            activar()
            cmbIdContacto.Select()
        Else                          'Nuevo            
            desactivar()
            cmbIdContacto.Select()
        End If        
        EnableOptions()
    End Sub

    '==========================Evento KeyDown==================================
    Private Sub frmVisitaOportunidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '==========================Evento KeyPress==================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdContacto.KeyPress _
                          , txtFecha.KeyPress _
                          , cmbTipoVisita.KeyPress _
                          , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oVisitaOportunidadService.Close()
            oContactoService.Close()
        Catch ex As TimeoutException
            oVisitaOportunidadService.Abort()
            oContactoService.Abort()
        Catch ex As CommunicationException
            oVisitaOportunidadService.Abort()
            oContactoService.Abort()
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
        Try
            If toNumber(IdOportunidad) = 0 Then
                MsgBox("Debe Ingresar el código de la Oportunidad de Negocio. ", MsgBoxStyle.Information, "Información")
                Return False                
            ElseIf toNumber(cmbIdContacto.Value) = 0 Then
                MsgBox("Debe Ingresar el Contacto de la Visita.", MsgBoxStyle.Information, "Información")                
                cmbIdContacto.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha de la Visita.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toNumber(cmbTipoVisita.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Visita.", MsgBoxStyle.Information, "Información")                
                cmbTipoVisita.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        If Not (iEtapa = 1 Or iEtapa = 7) Then
            activar()
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()   
        If state_button Then
            If Not (iEtapa = 1 Or iEtapa = 7) Then
                cmbIdContacto.ReadOnly = False
                cmbIdContacto.BackColor = System.Drawing.SystemColors.Window
                btnAgregarContacto.Enabled = True
                txtFecha.ReadOnly = False
                txtFecha.BackColor = System.Drawing.SystemColors.Window
                cmbTipoVisita.ReadOnly = False
                cmbTipoVisita.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
            Else
                desactivar()
            End If
        Else
            cmbIdContacto.ReadOnly = False
            cmbIdContacto.BackColor = System.Drawing.SystemColors.Window
            btnAgregarContacto.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbTipoVisita.ReadOnly = False
            cmbTipoVisita.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub desactivar()
        cmbIdContacto.ReadOnly = True
        cmbIdContacto.BackColor = System.Drawing.SystemColors.Control
        btnAgregarContacto.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbTipoVisita.ReadOnly = True
        cmbTipoVisita.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As VisitaOportunidadService.VisitaOportunidad)
        Try
            Dim estado_process As Integer
            estado_process = oVisitaOportunidadService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdVisita = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR VISITA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As VisitaOportunidadService.VisitaOportunidad)
        Try
            Dim estado_process As Boolean
            estado_process = oVisitaOportunidadService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR VISITA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As VisitaOportunidadService.VisitaOportunidad
            registro = oVisitaOportunidadService.Obtener(toNumber(IdVisita))

            IdVisita = registro.IdVisita
            IdOportunidad = registro.OportunidadNegocio.IdOportunidad
            cmbIdContacto.Value = registro.Contacto.IdContacto
            txtFecha.Value = registro.Fecha
            cmbTipoVisita.Value = registro.TipoVisita.IdTipoVisita
            txtObservacion.Text = registro.Observacion            
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''===================================== TIPO DE VISITA ============================================
            dtTipoVisita = oVisitaOportunidadService.MostrarTipoVisita().Tables(0)
            'dtTipoVisita.Rows.InsertAt(getRowTodos(dtTipoVisita), 0)
            cmbTipoVisita.DataSource = dtTipoVisita
            cmbTipoVisita.DropDownList.DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.DisplayMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.ValueMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(0).DataMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(1).DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.SelectedIndex = 0
            dtTipoVisita = Nothing

            listarContactos()
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listarContactos()
        Try

            '======================================= CONTACTOS ================================================
            dtContactos = oContactoService.Mostrar(IdCliente).Tables(0)
            cmbIdContacto.DataSource = dtContactos
            cmbIdContacto.DropDownList.DataMember = dtContactos.Columns("Apellidos").ToString
            cmbIdContacto.DropDownList.DisplayMember = dtContactos.Columns("Apellidos").ToString
            cmbIdContacto.DropDownList.ValueMember = dtContactos.Columns("IdContacto").ToString
            cmbIdContacto.DropDownList.Columns(0).DataMember = dtContactos.Columns("IdContacto").ToString
            cmbIdContacto.DropDownList.Columns(1).DataMember = dtContactos.Columns("Apellidos").ToString
            cmbIdContacto.DropDownList.Columns(2).DataMember = dtContactos.Columns("Nombres").ToString
            dtContactos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CONTACTOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

            Dim registro As New VisitaOportunidadService.VisitaOportunidad
            Dim oportunidad As New VisitaOportunidadService.OportunidadNegocio
            Dim contacto As New VisitaOportunidadService.Contacto            
            Dim tipovisita As New VisitaOportunidadService.TipoVisita
            
            registro.IdVisita = IdVisita
            oportunidad.IdOportunidad = IdOportunidad
            registro.OportunidadNegocio = oportunidad
            contacto.IdContacto = cmbIdContacto.Value
            registro.Contacto = contacto
            registro.Fecha = txtFecha.Value
            tipovisita.IdTipoVisita = cmbTipoVisita.Value
            registro.TipoVisita = tipovisita            
            registro.Observacion = txtObservacion.Text

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                registro.FecRegistro = Today
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarContacto
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarContactos()
                cmbIdContacto.Value = toNumber(forma.txtIdContacto.Text)
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                cmbIdContacto.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdContacto.Select()
    End Sub
End Class