
Imports System.ServiceModel

Public Class frmPuntoRuta

    Private oRondasService As New RondasService.RondasServiceClient

    Public state_button As Boolean              'True: Modificar    False: Nuevo
    Public type_process As String                'Update     Insert      Delete

    Private dtPuntos As DataTable
    Private dtRutas As DataTable

    Public CodPunto As String
    Public CodRuta As String

    Private Sub frmPuntoRuta_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRondasService.Close()
        Catch ex As TimeoutException
            oRondasService.Abort()
        Catch ex As CommunicationException
            oRondasService.Abort()
        End Try
    End Sub

    Private Sub frmPuntoRuta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPuntoRuta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        If state_button Then    'Modificar

            ObtenerRegistro()
            desactivar()
            Me.Text = "Puntos x Ruta"
        Else                    'Nuevo
            'Me.Size = New System.Drawing.Size(677, 365)
            Me.Text = "Registrar nuevo Puntos x Ruta"
            txtOrden.Text = 0
        End If
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= PUNTOS ================================================
            dtPuntos = oRondasService.MostrarPuntos().Tables(0)
            cmbPunto.DataSource = dtPuntos
            cmbPunto.DropDownList.DataMember = dtPuntos.Columns("DesPunto").ToString
            cmbPunto.DropDownList.DisplayMember = dtPuntos.Columns("DesPunto").ToString
            cmbPunto.DropDownList.ValueMember = dtPuntos.Columns("CodPunto").ToString
            cmbPunto.DropDownList.Columns(0).DataMember = dtPuntos.Columns("CodPunto").ToString
            cmbPunto.DropDownList.Columns(1).DataMember = dtPuntos.Columns("DesPunto").ToString
            cmbPunto.SelectedIndex = 0
            dtPuntos = Nothing


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
            Dim registro As RondasService.PuntosControlRutas
            registro = oRondasService.ObtenerPuntosRuta(CodRuta, CodPunto)

            cmbRuta.Value = registro.Ruta.CodRuta
            cmbPunto.Value = registro.PuntosControl.CodPunto

            txtOrden.Text = registro.Orden


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub desactivar()
        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False

        cmbPunto.Enabled = False
        cmbRuta.Enabled = False
        txtOrden.ReadOnly = True
        txtOrden.BackColor = System.Drawing.SystemColors.Control


    End Sub

    Private Sub activar()

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

        cmbPunto.Enabled = False
        cmbRuta.Enabled = False

        txtOrden.ReadOnly = False
        txtOrden.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New RondasService.PuntosControlRutas
                Dim rutas As New RondasService.Ruta
                Dim punto As New RondasService.PuntosControl

                punto.CodPunto = toNull(cmbPunto.Value)
                registro.PuntosControl = punto

                rutas.CodRuta = toNull(cmbRuta.Value)
                registro.Ruta = rutas

                registro.Orden = toNull(txtOrden.Text)

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

    Private Sub Insertar(ByVal registro As RondasService.PuntosControlRutas)
        Try
            Dim estado_process As Boolean
            estado_process = oRondasService.InsertarPuntosRuta(registro)
            type_process = "insert"
            If estado_process Then
                CodRuta = estado_process
                MsgBox("Se insertó el Punto x Rutas correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR PUNTOS X RUTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RondasService.PuntosControlRutas)
        Try
            Dim estado_process As Boolean
            estado_process = oRondasService.ActualizarPuntosRuta(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR PUNTOS X RUTA: " + ex.Message, MsgBoxStyle.Exclamation)
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
            If txtOrden.Text = "" Then
                MsgBox("Debe Ingresar el Orden", MsgBoxStyle.Information, "Información")
                txtOrden.BackColor = Color.Red
                txtOrden.Focus()
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