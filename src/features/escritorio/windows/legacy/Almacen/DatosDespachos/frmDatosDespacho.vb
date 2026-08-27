Imports System.ServiceModel

Public Class frmDatosDespacho

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public IdCliente As Integer
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable


    Private Sub frmDatosDespacho_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDespachoCabService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oDespachoCabService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oDespachoCabService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmDatosDespacho_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDatosDespacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            Me.Text = "Despacho :  " + Chr(34) + txtIdCliente.Text
            'Me.Text = "Plan :  " + Chr(34) + lblOficina.Text.ToString + " - " + lblLocacion.Text.ToString + Chr(34)
        Else 'Nuevo
            activar()

            Me.Size = New System.Drawing.Size(491, 458)
            Me.Text = "Registrar nuevo Plan"
            'SugerirIdPlan()
            cmbPrioridad.Text = "Alta"
            cmbTipo.Text = "Propia"
            btnBuscarCliente.Focus()
            btnBuscarCliente.Select()

        End If

    End Sub

    Private Sub llenarCombos()
        Try
            'Dim dt As DataTable = New DataTable("Tabla")

            'dt.Columns.Add("Codigo")
            'dt.Columns.Add("Descripcion")

            'Dim dr As DataRow

            'dr = dt.NewRow()
            'dr("Codigo") = "1"
            'dr("Descripcion") = "Propio"
            'dt.Rows.Add(dr)

            'dr = dt.NewRow()
            'dr("Codigo") = "2"
            'dr("Descripcion") = "Agencia"
            'dt.Rows.Add(dr)

            'cmbTipo.DataSource = dt
            'cmbTipo.DropDownList.DataMember = dt.Columns("Descripcion").ToString
            'cmbTipo.DropDownList.DisplayMember = dt.Columns("Descripcion").ToString
            'cmbTipo.DropDownList.ValueMember = dt.Columns("Codigo").ToString
            'cmbTipo.DropDownList.Columns(0).DataMember = dt.Columns("Codigo").ToString
            'cmbTipo.DropDownList.Columns(1).DataMember = dt.Columns("Descripcion").ToString

            ''==============================================================

            'Dim dt1 As DataTable = New DataTable("Tabla")

            'dt1.Columns.Add("Codigo")
            'dt1.Columns.Add("Descripcion")

            'Dim dr1 As DataRow

            'dr1 = dt1.NewRow()
            'dr1("Codigo") = "1"
            'dr1("Descripcion") = "Alta"
            'dt1.Rows.Add(dr1)

            'dr1 = dt1.NewRow()
            'dr1("Codigo") = "2"
            'dr1("Descripcion") = "Media"
            'dt1.Rows.Add(dr1)

            'dr1 = dt1.NewRow()
            'dr1("Codigo") = "3"
            'dr1("Descripcion") = "Baja"
            'dt1.Rows.Add(dr1)

            'cmbPrioridad.DataSource = dt1
            'cmbPrioridad.DropDownList.DataMember = dt1.Columns("Descripcion").ToString
            'cmbPrioridad.DropDownList.DisplayMember = dt1.Columns("Descripcion").ToString
            'cmbPrioridad.DropDownList.ValueMember = dt1.Columns("Codigo").ToString
            'cmbPrioridad.DropDownList.Columns(0).DataMember = dt1.Columns("Codigo").ToString
            'cmbPrioridad.DropDownList.Columns(1).DataMember = dt1.Columns("Descripcion").ToString


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As DespachoCabService.DatosDespacho
            registro = oDespachoCabService.ObtenerDatosDespacho(IdCliente)

            IdCliente = registro.Cliente.IdCliente
            txtIdCliente.Text = registro.Cliente.DesCli

            txtLugarEntrega.Text = registro.LugarEntrega
            cbAplicaCita.Checked = registro.AplicaCita

            txtTiempoAtencion.Text = registro.TiempoAtencion
            cmbTipo.Text = registro.TipoAlmacen

            cbAplicaDoc.Checked = registro.AplicaDoc
            txtHorarioAtencion.Text = registro.HorarioAtencion
            txtDiaAtencion.Text = registro.DiaAtencion

            txtContactoAtencion.Text = registro.ContactoAte
            txtZona.Text = registro.Zona
            cmbPrioridad.Text = registro.Prioridad
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS DESPACHO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click

        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                'chkCliente.Checked = False
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            'cmbEstado.Select()
            'listaDatos()
        End If

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New DespachoCabService.DatosDespacho
                Dim cliente As New DespachoCabService.Cliente

                cliente.IdCliente = IdCliente
                cliente.DesCli = txtIdCliente.Text
                registro.Cliente = cliente
                registro.LugarEntrega = txtLugarEntrega.Text
                registro.AplicaCita = cbAplicaCita.Checked
                registro.TiempoAtencion = txtTiempoAtencion.Text
                registro.TipoAlmacen = cmbTipo.Text
                registro.AplicaDoc = cbAplicaDoc.Checked
                registro.HorarioAtencion = txtHorarioAtencion.Text
                registro.DiaAtencion = txtDiaAtencion.Text
                registro.ContactoAte = txtContactoAtencion.Text
                registro.Zona = txtZona.Text
                registro.Prioridad = cmbPrioridad.Text
                registro.Observacion = txtObservacion.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(txtLugarEntrega.Text) = "" Then
                MsgBox("Debe Ingresar el Lugar de Entrega", MsgBoxStyle.Information, "Información")
                txtLugarEntrega.BackColor = Color.Red
                txtLugarEntrega.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As DespachoCabService.DatosDespacho)
        Try
            Dim estado_process As Boolean
            estado_process = oDespachoCabService.InsertarDatosDespacho(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el dato despacho correctamente")
                'IdLocacion = txtIdLocacion.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL DATO DESPACHO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As DespachoCabService.DatosDespacho)
        Try
            Dim estado_process As Boolean
            estado_process = oDespachoCabService.ActualizarDatosDespacho(registro)
            type_process = "update"
            If estado_process = True Then
                'ObtenerRegistro()
                desactivar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL DATO DESPACHO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        If state_button = False Then

            txtIdCliente.ReadOnly = True
            txtIdCliente.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCliente.Enabled = True
            biEditarr.Enabled = False

        Else
            txtIdCliente.ReadOnly = True
            txtIdCliente.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCliente.Enabled = False

        End If

        txtLugarEntrega.ReadOnly = False
        txtLugarEntrega.BackColor = System.Drawing.SystemColors.Window
        cbAplicaCita.Enabled = True
        txtTiempoAtencion.ReadOnly = False
        txtTiempoAtencion.BackColor = System.Drawing.SystemColors.Window
        cmbTipo.Enabled = True
        'cmbTipo.BackColor = System.Drawing.SystemColors.Window
        cbAplicaDoc.Enabled = True

        txtHorarioAtencion.ReadOnly = False
        txtHorarioAtencion.BackColor = System.Drawing.SystemColors.Window
        txtDiaAtencion.ReadOnly = False
        txtDiaAtencion.BackColor = System.Drawing.SystemColors.Window

        txtContactoAtencion.ReadOnly = False
        txtContactoAtencion.BackColor = System.Drawing.SystemColors.Window

        txtZona.ReadOnly = False
        txtZona.BackColor = System.Drawing.SystemColors.Window

        cmbPrioridad.Enabled = True
        'cmbPrioridad.BackColor = System.Drawing.SystemColors.Window

        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        txtIdCliente.ReadOnly = True
        txtIdCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False


        txtLugarEntrega.ReadOnly = True
        txtLugarEntrega.BackColor = System.Drawing.SystemColors.Control
        cbAplicaCita.Enabled = False
        txtTiempoAtencion.ReadOnly = True
        txtTiempoAtencion.BackColor = System.Drawing.SystemColors.Control
        cmbTipo.Enabled = False
        'cmbTipo.BackColor = System.Drawing.SystemColors.Control
        cbAplicaDoc.Enabled = False

        txtHorarioAtencion.ReadOnly = True
        txtHorarioAtencion.BackColor = System.Drawing.SystemColors.Control
        txtDiaAtencion.ReadOnly = True
        txtDiaAtencion.BackColor = System.Drawing.SystemColors.Control

        txtContactoAtencion.ReadOnly = True
        txtContactoAtencion.BackColor = System.Drawing.SystemColors.Control

        txtZona.ReadOnly = True
        txtZona.BackColor = System.Drawing.SystemColors.Control

        cmbPrioridad.Enabled = False
        'cmbPrioridad.BackColor = System.Drawing.SystemColors.Control

        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control

    End Sub

End Class