Imports System.ServiceModel

Public Class frmRutaRuteador

    Private oRondasService As New RondasService.RondasServiceClient

    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete

    Private dtRuteador As DataTable
    Private dtRutas As DataTable

    Public IdRuteador As Integer
    Public CodRuta As String

    Private Sub frmRutaRuteador_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRondasService.Close()
        Catch ex As TimeoutException
            oRondasService.Abort()
        Catch ex As CommunicationException
            oRondasService.Abort()
        End Try
    End Sub

    Private Sub frmRutaRuteador_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRutaRuteador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Modificar

            ObtenerRegistro()
            desactivar()
            Me.Text = "Ruteador Ruta "
        Else                    'Nuevo
            'Me.Size = New System.Drawing.Size(677, 365)
            Me.Text = "Registrar nuevo Ruteador x Ruta"
            txtCantRutasDia.Text = 0
        End If

    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= RUTEADOR ================================================
            dtRuteador = oRondasService.MostrarRuteador().Tables(0)
            cmbRuteador.DataSource = dtRuteador
            cmbRuteador.DropDownList.DataMember = dtRuteador.Columns("ApePat").ToString
            cmbRuteador.DropDownList.DisplayMember = dtRuteador.Columns("ApePat").ToString
            cmbRuteador.DropDownList.ValueMember = dtRuteador.Columns("IdRuteador").ToString
            cmbRuteador.DropDownList.Columns(0).DataMember = dtRuteador.Columns("IdRuteador").ToString
            cmbRuteador.DropDownList.Columns(1).DataMember = dtRuteador.Columns("ApePat").ToString
            cmbRuteador.DropDownList.Columns(2).DataMember = dtRuteador.Columns("ApeMat").ToString
            cmbRuteador.DropDownList.Columns(3).DataMember = dtRuteador.Columns("Nombres").ToString
            cmbRuteador.SelectedIndex = 0
            dtRuteador = Nothing


            '======================================= RUTAS ================================================
            dtRutas = oRondasService.MostrarRutas().Tables(0)
            cmbRuta.DataSource = dtRutas
            cmbRuta.DropDownList.DataMember = dtRutas.Columns("DesRuta").ToString
            cmbRuta.DropDownList.DisplayMember = dtRutas.Columns("DesRuta").ToString
            cmbRuta.DropDownList.ValueMember = dtRutas.Columns("CodRuta").ToString
            cmbRuta.DropDownList.Columns(0).DataMember = dtRutas.Columns("CodRuta").ToString
            cmbRuta.DropDownList.Columns(1).DataMember = dtRutas.Columns("DesRuta").ToString
            cmbRuta.SelectedIndex = 0
            dtRutas = Nothing


        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As RondasService.RuteadorRutas
            registro = oRondasService.ObtenerRuteadorRutas(IdRuteador, CodRuta)

            IdRuteador = registro.Ruteador.IdRuteador
            cmbRuteador.Value = registro.Ruteador.IdRuteador
            CodRuta = registro.Ruta.CodRuta
            cmbRuta.Value = registro.Ruta.CodRuta
            txtCantRutasDia.Text = registro.CanRutasDias


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub desactivar()
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

        cmbRuteador.Enabled = False
        cmbRuta.Enabled = False
        txtCantRutasDia.ReadOnly = True
        txtCantRutasDia.BackColor = System.Drawing.SystemColors.Control


    End Sub

    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        cmbRuteador.Enabled = False
        cmbRuta.Enabled = False

        txtCantRutasDia.ReadOnly = False
        txtCantRutasDia.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New RondasService.RuteadorRutas
                Dim ruteador As New RondasService.Ruteador
                Dim rutas As New RondasService.Ruta

                ruteador.IdRuteador = toNumber(cmbRuteador.Value)
                registro.Ruteador = ruteador

                rutas.CodRuta = toNull(cmbRuta.Value)
                registro.Ruta = rutas

                registro.CanRutasDias = toNumber(txtCantRutasDia.Text)

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

    Private Sub Insertar(ByVal registro As RondasService.RuteadorRutas)
        Try
            Dim estado_process As Boolean
            estado_process = oRondasService.InsertarRuteadorRutas(registro)
            type_process = "insert"
            If estado_process Then
                IdRuteador = estado_process
                MsgBox("Se insertó el Ruteador x Rutas correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR RUTEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RondasService.RuteadorRutas)
        Try
            Dim estado_process As Boolean
            estado_process = oRondasService.ActualizarRuteadorRutas(registro)
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

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        activar()
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


    Private Function ValidaCampos() As Boolean
        Try

            If txtCantRutasDia.Text = "" Then
                MsgBox("Debe Ingresar la cantidad de rutas x dia", MsgBoxStyle.Information, "Información")
                txtCantRutasDia.BackColor = Color.Red
                txtCantRutasDia.Focus()
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