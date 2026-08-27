Imports System.ServiceModel

Public Class frmUnidadPersonal

    Private oVehiculoService As New VehiculoService.VehiculoServiceClient

    Public IdPersona As Integer
    Public Placa As String

    Public type_process As String                'update     insert      delete

    Public state_button As Boolean

    Private Sub frmUnidadPersonal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVehiculoService.Close()
        Catch ex As TimeoutException
            oVehiculoService.Abort()
        Catch ex As CommunicationException
            oVehiculoService.Abort()
        End Try
    End Sub

    Private Sub frmUnidadPersonal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUnidadPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar            
            ObtenerRegistro()
        Else                    'Nuevo
            cbActivo.Checked = True
        End If
    End Sub

    Private Sub ObtenerRegistro()

        Try

            Dim registro As VehiculoService.UnidadAsignada
            registro = oVehiculoService.ObtenerUnidadAsignada(Placa, IdPersona)

            txtColaborador.Text = registro.Persona.ApeNom
            cbActivo.Checked = registro.Activo

            If Not (registro.FecInicio.ToString = "") Then
                txtFecInicio.Value = CDate(registro.FecInicio)
                txtFecInicio.Text = registro.FecInicio.ToString
            End If
            If Not (registro.FecFinal.ToString = "") Then
                txtFecFinal.Value = CDate(registro.FecFinal)
                txtFecFinal.Text = registro.FecFinal.ToString
            End If

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(sender As Object, e As EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtFecInicio.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New VehiculoService.UnidadAsignada
                Dim persona As New VehiculoService.Persona
                Dim unidad As New VehiculoService.Unidad

                persona.IdPer = IdPersona
                registro.Persona = persona

                unidad.Placa = Placa
                registro.Unidad = unidad

                registro.FecInicio = IIf(txtFecInicio.Text = "", Nothing, txtFecInicio.Value)
                registro.FecFinal = IIf(txtFecFinal.Text = "", Nothing, txtFecFinal.Value)

                registro.Activo = cbActivo.Checked

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc


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

    Private Sub Insertar(ByVal registro As VehiculoService.UnidadAsignada)
        Try
            Dim estado_process As Boolean
            estado_process = oVehiculoService.InsertarUnidadAsignada(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la Unidad Asignada correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I. ....!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA UNIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As VehiculoService.UnidadAsignada)
        Try
            Dim estado_process As Boolean
            estado_process = oVehiculoService.ActualizarUnidadAsignada(registro)
            type_process = "update"
            If estado_process = True Then
                'ObtenerRegistro()
                'desactivar()
                MsgBox("Se modifico la Unidad Asignada correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA UNIDAD ASIGNADA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Tipo de el colaborador", MsgBoxStyle.Information, "Información")
                btnBuscarColaborador.Focus()
                Return False
            ElseIf txtFecInicio.Text = "" Then
                MsgBox("Debe Ingresar la fecha de inicio", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf txtFecInicio.Text = "" Then
                MsgBox("Debe Ingresar la fecha final", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

End Class