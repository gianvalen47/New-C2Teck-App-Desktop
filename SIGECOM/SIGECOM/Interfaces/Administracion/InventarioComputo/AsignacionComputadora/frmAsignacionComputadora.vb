Imports System.ServiceModel

Public Class frmAsignacionComputadora

    '=========================== Servicios ===================================================
    Private oAsignacionComputadoraService As New AsignacionComputadoraService.AsignacionComputadoraServiceClient

    '======================Declaración de Variables==============================================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public state_Search As Boolean
    Private dtDatos As New DataTable
    Public IdPersona As Integer
    Public IdComputadora As Integer

    Private Sub frmAsignacionComputadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            'txtFecha.TabStop = False
        Else                                      'Nuevo            
            activar()
            'cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub frmAsignacionComputadora_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAsignacionComputadora_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oAsignacionComputadoraService.Close()
        Catch ex As TimeoutException
            oAsignacionComputadoraService.Abort()
        Catch ex As CommunicationException
            oAsignacionComputadoraService.Abort()
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AsignacionComputadoraService.AsignacionComputadora
            registro = oAsignacionComputadoraService.Obtener(IdPersona, IdComputadora)

            IdPersona = registro.Persona.IdPer
            txtPersona.Text = registro.Persona.ApeNom

            IdComputadora = registro.Computadora.IdComputadora
            txtComputadora.Text = registro.Computadora.NomPc

            If Not (registro.FecIniAsignacion.ToString = "") Then
                txtFecIniAsig.Value = CDate(registro.FecIniAsignacion)
                txtFecIniAsig.Text = registro.FecIniAsignacion.ToString
            End If

            If Not (registro.FecFinAsignacion.ToString = "") Then
                txtFecFinAsig.Value = CDate(registro.FecFinAsignacion)
                txtFecFinAsig.Text = registro.FecFinAsignacion.ToString
            End If

            'txtFecIniAsig.Value = registro.FecIniAsignacion
            'txtFecFinAsig.Value = registro.FecFinAsignacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        btnBuscarPersonaS.Enabled = False
        btnBuscarComputadora.Enabled = False

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        btnBuscarPersonaS.Enabled = True
        btnBuscarComputadora.Enabled = True

        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New AsignacionComputadoraService.AsignacionComputadora
                Dim persona As New AsignacionComputadoraService.Persona
                Dim computadora As New AsignacionComputadoraService.Computadora

                persona.IdPer = IdPersona
                registro.Persona = persona

                computadora.IdComputadora = IdComputadora
                registro.Computadora = computadora

                registro.FecIniAsignacion = IIf(txtFecIniAsig.Text = "", Nothing, txtFecIniAsig.Value)
                registro.FecFinAsignacion = IIf(txtFecFinAsig.Text = "", Nothing, txtFecFinAsig.Value)

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA ASIGNACION X COMPUTADORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As AsignacionComputadoraService.AsignacionComputadora)
        Try
            If oAsignacionComputadoraService.Buscar(IdPersona, IdComputadora) = True Then
                MsgBox("La computadora ya se encuentra asignada a un personal, tenga cuidado.", MsgBoxStyle.Information, "Información")
                txtComputadora.Focus()
            Else
                Dim estado_process As Boolean
                estado_process = oAsignacionComputadoraService.Insertar(registro)
                type_process = "insert"
                If estado_process = True Then
                    IdComputadora = estado_process
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA ASIGNACION X COMPUTADORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AsignacionComputadoraService.AsignacionComputadora)
        Try
            Dim estado_process As Boolean
            estado_process = oAsignacionComputadoraService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA ASIGNACION X COMPUTADORA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtPersona.Text) = "" Then
                MsgBox("Debe ingresar el personal", MsgBoxStyle.Information, "Información")
                txtPersona.Focus()
                Return False
            ElseIf toBlank(txtComputadora.Text) = "" Then
                MsgBox("Debe ingresar la computadora", MsgBoxStyle.Information, "Información")
                txtComputadora.Focus()
                Return False
            ElseIf toBlank(txtFecIniAsig.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio de Asignacion", MsgBoxStyle.Information, "Información")
                txtFecIniAsig.Focus()
                Return False
                'ElseIf toBlank(txtFecFinAsig.Text) = "" Then
                '    MsgBox("Debe ingresar la Fecha de Fin de Asignacion", MsgBoxStyle.Information, "Información")
                '    txtFecFinAsig.Focus()
                '    Return False
                'ElseIf oAsignacionLineaService.Buscar(IdPer, IdLinea) = True Then
                '    MsgBox("La linea ya se encuentra asignada a un personal, tenga cuidado.", MsgBoxStyle.Information, "Información")
                '    txtLinea.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscarPersonaS_Click(sender As Object, e As EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtPersona.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtPersona.Text = "(Todos)"
                    IdPersona = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarComputadora_Click(sender As Object, e As EventArgs) Handles btnBuscarComputadora.Click
        Try
            Dim frm As New frmBuscarComputadora
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtComputadora.Text = frm.descripcion
                    IdComputadora = frm.codigo
                Else
                    txtComputadora.Text = "(Todos)"
                    IdComputadora = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub
End Class