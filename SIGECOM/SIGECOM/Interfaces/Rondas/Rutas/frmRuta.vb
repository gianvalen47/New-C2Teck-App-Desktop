Imports System.ServiceModel

Public Class frmRuta

    Private oRondasService As New RondasService.RondasServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete
    Private dtOficinas As DataTable
    Public CodRuta As String

    Private Sub frmRuta_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRondasService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oRondasService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oRondasService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmRuta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRuta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Modificar

            ObtenerRegistro()
            desactivar()

            Me.Text = "Ruteador: " + Chr(34) + txtCodRuta.Text.ToString
        Else                    'Nuevo
            Me.Text = "Registrar nueva Ruta"
            txtDesRuta.Focus()
            cbVigente.Checked = True
        End If

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As RondasService.Ruta
            registro = oRondasService.ObtenerRutas(CodRuta)

            CodRuta = registro.CodRuta
            txtCodRuta.Text = registro.CodRuta
            txtDesRuta.Text = registro.DesRuta
            cmbOficinas.Value = registro.Oficina.CodOfi
            cbVigente.Checked = registro.Vigente


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub desactivar()

        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

        txtCodRuta.ReadOnly = True
        txtCodRuta.BackColor = System.Drawing.SystemColors.Control
        txtDesRuta.ReadOnly = True
        txtDesRuta.BackColor = System.Drawing.SystemColors.Control
        cmbOficinas.Enabled = False
        cbVigente.Enabled = False

    End Sub


    Private Sub activar()
        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        'txtCodRuta.ReadOnly = False
        'txtCodRuta.BackColor = System.Drawing.SystemColors.Window
        txtDesRuta.ReadOnly = False
        txtDesRuta.BackColor = System.Drawing.SystemColors.Window
        cmbOficinas.Enabled = True
        cbVigente.Enabled = True

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesRuta.KeyPress, cmbOficinas.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnDeshacer_Click(sender As System.Object, e As System.EventArgs) Handles btnDeshacer.Click
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

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New RondasService.Ruta
                Dim Oficina As New RondasService.Oficina

                registro.CodRuta = txtCodRuta.Text
                registro.DesRuta = txtDesRuta.Text
                Oficina.CodOfi = cmbOficinas.Value
                registro.Oficina = Oficina
                registro.Vigente = cbVigente.Checked

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


    Private Sub Insertar(ByVal registro As RondasService.Ruta)
        Try
            Dim estado_process As String
            estado_process = oRondasService.InsertarRutas(registro)
            type_process = "insert"
            If estado_process <> "" Then
                CodRuta = estado_process
                MsgBox("Se insertó la Ruta correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR RUTEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RondasService.Ruta)
        Try
            Dim estado_process As Boolean
            estado_process = oRondasService.ActualizarRutas(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR RUTEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtDesRuta.Text = "" Then
                MsgBox("Debe Ingresar la descripción de la ruta", MsgBoxStyle.Information, "Información")
                txtDesRuta.BackColor = Color.Red
                txtDesRuta.Focus()
                Return False
            ElseIf txtCodRuta.Text = "" Then
                MsgBox("Debe Ingresar la descripción de la ruta", MsgBoxStyle.Information, "Información")
                txtDesRuta.BackColor = Color.Red
                txtDesRuta.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class