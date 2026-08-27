Imports System.ServiceModel
Public Class frmGastoViaje_InformacionUsuario

    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    Public IdPersona As Integer

    Private Sub frmGastoViaje_InformacionUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPersonaService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmGastoViaje_InformacionUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoViaje_InformacionUsuario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ObtenerDatos()
    End Sub

    Protected Sub ObtenerDatos()
        Try

            Persona = oPersonaService.Obtener(IdPersona)

            txtCodigo.Text = Persona.CodPer
            txtCarnet.Text = Persona.Carnet
            txtNumDoc.Text = Persona.NumDoc
            txtNombre.Text = Persona.ApeNom
            If Persona.Sexo = 1 Then
                rbMasculino.Checked = True
                rbFemenino.Checked = False
            ElseIf Persona.Sexo = 2 Then
                rbFemenino.Checked = True
                rbMasculino.Checked = False
            End If
            txtEstCivil.Text = Persona.EstadoCivil.DesEstado
            txtTipoVia.Text = Persona.TipoVia.DesVia
            txtNomVia.Text = Persona.NomVia
            txtNroVia.Text = Persona.NumVia
            txtTipoZona.Text = Persona.TipoZona.DesZona
            txtNomZona.Text = Persona.NomZona
            txtReferencia.Text = Persona.Referencia
            txtInterior.Text = Persona.Interior
            txtUbigeo.Text = Persona.Ubigeo.Departamento.NomDpto
            txtTelefonos.Text = Persona.Telefonos
            txtEmail.Text = Persona.Email
            txtEmpresa.Text = Persona.Empresa.DesEmp
            txtArea.Text = Persona.CentroCosto.Area.DesArea
            txtClase.Text = Persona.Clase.DesClas
            txtCargo.Text = Persona.Cargo.DesCargo
            chkVigente.Checked = Persona.Vigente
            chkMarcaTarjeta.Checked = Persona.Marca
            txtFechaIngreso.Text = Persona.FecIngreso.ToString
            txtFecIngContrato.Text = Persona.FecIniContrato.ToString
            txtFecIngEstable.Text = Persona.FecIniEstable.ToString
            txtFechaCese.Text = Persona.FecCese.ToString
            txtFecCeseContrato.Text = Persona.FecFinContrato.ToString
            txtFecIniPlanilla.Text = Persona.FecIniPlanilla.ToString

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub
End Class