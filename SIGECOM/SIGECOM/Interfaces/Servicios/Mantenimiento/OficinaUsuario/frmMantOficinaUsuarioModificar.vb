Imports System.ServiceModel
Public Class frmMantOficinaUsuarioModificar

    '=========================== Servicios ====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient

    '====================== Declaración de Variables ==============================
    Private dtOficinas As DataTable
    Private dtAreas As DataTable
    Private dtHorarios As DataTable
    Public CodUsu As String
    Public Actualizar As Boolean

    Private Sub frmUsuarioModificar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oHorarioService.Close()
            oAsignacionHorarioService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oHorarioService.Abort()
            oAsignacionHorarioService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oHorarioService.Abort()
            oAsignacionHorarioService.Abort()
        End Try
    End Sub

    Private Sub frmUsuarioModificar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuarioModificar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        If Actualizar = True Then
            ObtenerRegistro()
            Desactivar()
        Else
            ObtenerRegistro()
            Activar()
        End If
        cmbLocacion.Focus()
        enableOpciones()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub frmCapacitaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtUsuario.KeyPress _
                            , txtColaborador.KeyPress _
                            , cmbArea.KeyPress _
                            , txtEmail.KeyPress _
                            , cmbLocacion.KeyPress _
                            , cmbHorario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim usuario As SeguridadService.Usuario
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(CodUsu)

            txtUsuario.Text = usuario.CodUsu
            txtColaborador.Text = usuario.Persona.ApeNom
            txtEmail.Text = usuario.Email
            cmbArea.Value = usuario.Persona.CentroCosto.Area.CodArea
            cmbLocacion.Value = usuario.Oficina.CodOfi
            cmbHorario.Value = oAsignacionHorarioService.ObtenerCodHor(usuario.Persona.IdPer)
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try
            txtEmail.ReadOnly = True
            txtEmail.BackColor = System.Drawing.SystemColors.Control
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            txtUsuario.ReadOnly = True
            txtUsuario.BackColor = System.Drawing.SystemColors.Control
            cmbArea.ReadOnly = True
            cmbArea.BackColor = System.Drawing.SystemColors.Control
            cmbLocacion.ReadOnly = True
            cmbLocacion.BackColor = System.Drawing.SystemColors.Control
            cmbHorario.ReadOnly = True
            cmbHorario.BackColor = System.Drawing.SystemColors.Control
            biGuardar.Enabled = False
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Activar()
        Try
            txtEmail.ReadOnly = True
            txtEmail.BackColor = System.Drawing.SystemColors.Control
            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            txtUsuario.ReadOnly = True
            txtUsuario.BackColor = System.Drawing.SystemColors.Control
            cmbArea.ReadOnly = True
            cmbArea.BackColor = System.Drawing.SystemColors.Control
            cmbLocacion.ReadOnly = False
            cmbLocacion.BackColor = System.Drawing.SystemColors.Window
            cmbHorario.ReadOnly = False
            cmbHorario.BackColor = System.Drawing.SystemColors.Window
            biGuardar.Enabled = True
            biEditar.Enabled = False
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(cmbLocacion.Value) = "" Then
                MsgBox("Debe ingresar la oficina")
                cmbLocacion.Focus()
                Return False
            ElseIf utils.toBlank(cmbHorario.Value) = "" Then
                MsgBox("Debe ingresar el Horario")
                cmbHorario.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub enableOpciones()
        Try
            If Actualizar = False Then
                biGuardar.Enabled = True
                biEditar.Enabled = False
            Else
                biGuardar.Enabled = False
                biEditar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL HABILITAR LAS OPCIONES : " + ex.Message)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '================================= OFICINAS ====================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbLocacion.DataSource = dtOficinas
            cmbLocacion.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 0

            '================================== AREAS =====================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

            '================================= HORARIOS ===================================
            dtHorarios = oHorarioService.Mostrar(Session.sCodEmp).Tables(0)
            cmbHorario.DataSource = dtHorarios
            cmbHorario.DropDownList.DataMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.DropDownList.DisplayMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.DropDownList.ValueMember = dtHorarios.Columns("CodHor").ToString
            cmbHorario.DropDownList.Columns(0).DataMember = dtHorarios.Columns("CodHor").ToString
            cmbHorario.DropDownList.Columns(1).DataMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.SelectedIndex = 0
            dtHorarios = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR LOS COMBOS :" + ex.Message)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                Dim actualiza As Boolean
                actualiza = oSeguridadService.ActualizarOficina(txtUsuario.Text, utils.toBlank(cmbLocacion.Value), toBlank(cmbHorario.Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If actualiza Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comunicarse con el departamento de TI...")
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class