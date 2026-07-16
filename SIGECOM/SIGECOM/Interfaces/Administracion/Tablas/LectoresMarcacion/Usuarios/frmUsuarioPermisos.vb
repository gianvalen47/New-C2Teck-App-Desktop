Imports System.ServiceModel
Public Class frmUsuarioPermisos

    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public CodUsu As String
    Private dtPerfil As DataTable
    Public state_button As Boolean

    Private Sub frmUsuarioPermisos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmUsuarioPermisos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuarioPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        If state_button Then
            ObtenerRegistro()
        Else
            cmbPerfil.Focus()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            dtPerfil = oSeguridadService.MostrarPerfiles.Tables(0)
            cmbPerfil.DataSource = dtPerfil
            cmbPerfil.DropDownList.DataMember = dtPerfil.Columns("Nombre").ToString
            cmbPerfil.DropDownList.DisplayMember = dtPerfil.Columns("Nombre").ToString
            cmbPerfil.DropDownList.ValueMember = dtPerfil.Columns("CodPerfil").ToString
            cmbPerfil.DropDownList.Columns(0).DataMember = dtPerfil.Columns("CodPerfil").ToString
            cmbPerfil.DropDownList.Columns(1).DataMember = dtPerfil.Columns("Nombre").ToString
            cmbPerfil.SelectedIndex = 0
            dtPerfil = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim permiso As SeguridadService.PermisoUsuario
            permiso = oSeguridadService.MostrarPermisos(CodUsu)

            cmbPerfil.Value = permiso.Perfil.CodPerfil
            ckTipCam.Checked = permiso.TipCam
            ckCartera.Checked = permiso.Cartera
            ckPerPrecio.Checked = permiso.Precio
            ckPerPrecioFOB.Checked = permiso.PrecioFob
            ckPrecioFlete.Checked = permiso.Flete
            ckGastoGerencia.Checked = permiso.GastoGerencia
            ckVendeOficina.Checked = permiso.VendeOficina
            ckVerPrecios.Checked = permiso.VerPrecios
            ckVerGastos.Checked = permiso.VerGastos
            ckExportarDatos.Checked = permiso.ExpDatos
            ckAprobacionUnica.Checked = permiso.AprobacionUnica
            ckLibreLicencia.Checked = permiso.LibreLicencia
            If permiso.TipFac = "2" Then
                rbTipFacCon.Checked = True
            ElseIf permiso.TipFac = "1" Then
                rbTipFacCre.Checked = True
            ElseIf permiso.TipFac = "0" Then
                rbTipFacTodos.Checked = True
            End If            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SeguridadService.PermisoUsuario)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.InsertarPermisoUsuario(registro)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub Modificar(ByVal registro As SeguridadService.PermisoUsuario)
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.ActualizarPermisoUsuario(registro)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los permisos? ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim registro As New SeguridadService.PermisoUsuario
                Dim perfil As New SeguridadService.Perfil
                Dim usuario As New SeguridadService.Usuario

                perfil.CodPerfil = cmbPerfil.Value
                registro.Perfil = perfil
                registro.TipCam = ckTipCam.Checked
                registro.Cartera = ckCartera.Checked
                registro.Precio = ckPerPrecio.Checked
                registro.PrecioFob = ckPerPrecioFOB.Checked
                registro.Flete = ckPrecioFlete.Checked
                registro.GastoGerencia = ckGastoGerencia.Checked
                registro.VendeOficina = ckVendeOficina.Checked
                registro.VerPrecios = ckVerPrecios.Checked
                registro.VerGastos = ckVerGastos.Checked
                registro.ExpDatos = ckExportarDatos.Checked
                registro.AprobacionUnica = ckAprobacionUnica.Checked
                registro.TipFac = IIf(rbTipFacTodos.Checked = True, "0", IIf(rbTipFacCre.Checked = True, "1", "2"))
                registro.LibreLicencia = ckLibreLicencia.Checked
                usuario.CodUsu = CodUsu
                usuario.CodUsuTrans = Session.sCodUsu
                registro.Usuario = usuario
                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class