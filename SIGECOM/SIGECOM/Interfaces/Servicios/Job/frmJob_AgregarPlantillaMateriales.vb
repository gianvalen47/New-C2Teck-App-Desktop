Imports System.ServiceModel

Public Class frmJob_AgregarPlantillaMateriales

    Private oJobRepuestoService As New JobRepuestoService.JobRepuestoServiceClient
    Private dtDatos As DataTable
    Public CodJob As String

    Private Sub frmJob_AgregarPlantilla_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobRepuestoService.Close()

        Catch ex As TimeoutException
            oJobRepuestoService.Abort()

        Catch ex As CommunicationException
            oJobRepuestoService.Abort()

        End Try
    End Sub

    Private Sub frmJob_AgregarPlantilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmJob_AgregarPlantilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        listaDatos()


    End Sub


    Private Sub listaDatos()
        Try

            dtDatos = oJobRepuestoService.MostrarPlantillaMateriales(Session.sCodEmp).Tables(0)

            dgvDatos.SetDataBinding(dtDatos, 0)


        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Esta seguro de agregar los materiales?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If dgvDatos.RowCount < 1 Then
                    MsgBox("La lista esta vacia,no puede ingresar la plantilla", MsgBoxStyle.Exclamation)
                Else
                    Dim registro As New JobRepuestoService.JobRepuesto
                    Dim job As New JobRepuestoService.Job
                    Dim rubro As New JobRepuestoService.RubroServicios
                    For Each Fila As DataRow In dtDatos.Rows
                        rubro.IdRubro = 3
                        job.CodJob = CodJob
                        registro.Job = job
                        registro.CodMer = Fila.Item("CodMer")
                        registro.RubroServicios = rubro
                        registro.DesMer = Fila.Item("Descripcion")
                        registro.CanMer = Fila.Item("Cantidad")
                        registro.Activo = True
                        registro.FecReg = Today
                        registro.Observacion = Nothing
                        registro.CodUsu = Session.sCodUsu
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        oJobRepuestoService.Insertar(registro)
                    Next
                    MsgBox("Se agregaron correctamente los Materiales", MsgBoxStyle.Exclamation)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
End Class