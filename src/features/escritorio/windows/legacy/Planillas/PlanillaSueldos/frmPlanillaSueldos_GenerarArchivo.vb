Imports System.ServiceModel
Public Class frmPlanillaSueldos_GenerarArchivo

    '===========================Servicios====================================================
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oPlanillaService As New PlanillaService.PlanillaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================    


    Public IdPlanilla As Integer
    Private dtBancos As DataTable
    Private dtCuentas As DataTable


    Private Sub frmPlanillaSueldos_dsctos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaService.Close()
            oPlanillaSueldosService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oPlanillaService.Abort()
            oPlanillaSueldosService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oPlanillaService.Abort()
            oPlanillaSueldosService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmPlanillaSueldos_GenerarArchivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar



        llenarCombos()


    End Sub

    Private Sub frmPlanillaSueldos_GenerarArchivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================= BANCOS ===============================================

            dtBancos = oPlanillaService.MostrarBancos.Tables(0)
            cmbBancos.DataSource = dtBancos
            cmbBancos.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBancos.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBancos.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBancos.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBancos.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBancos.SelectedIndex = 0
            dtBancos = Nothing




        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub




    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbBancos.Value) = "" Then
                MsgBox("Debe Ingresar el banco", MsgBoxStyle.Information, "Información")
                cmbBancos.Focus()
                Return False
            ElseIf toBlank(cmbCuentas.Value) = "" Then
                MsgBox("Debe Ingresar la cuenta", MsgBoxStyle.Information, "Información")
                cmbCuentas.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try

            ValidaCampos()

            Dim Seleccion As New SaveFileDialog
            Seleccion.Title = "Guardar archivo para el pago de haberes masivo en el banco"
            Seleccion.Filter = "Archivos de texto |*.txt"
            If Seleccion.ShowDialog() = DialogResult.OK Then
                Dim Ruta As String = Seleccion.FileName


                Dim dtdetalle As New DataTable
                dtdetalle = oPlanillaSueldosService.GenerarArchivo(IdPlanilla, cbFecha.Value, cmbBancos.Value, cmbCuentas.Value).Tables(0)

                Dim fichero As String = Ruta
                Dim texto As String = dtdetalle.Rows(0).Item("Cabecera")
                Dim a As New System.IO.StreamWriter(fichero)
                a.WriteLine(texto)
                For Each Fila As DataRow In dtdetalle.Rows
                    texto = Fila.Item("Detalle")
                    a.WriteLine(texto)
                Next
                a.Close()

                MsgBox("Se descargo exitosamente")

                Finalizar()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub





    Private Sub cmbBancos_ValueChanged(sender As Object, e As EventArgs) Handles cmbBancos.ValueChanged
        ''========================================== CUENTAS ===============================================
        dtCuentas = oPlanillaService.MostrarCuentasEmpresa(cmbBancos.Value, Session.sCodEmp).Tables(0)
        cmbCuentas.DataSource = dtCuentas
        cmbCuentas.DropDownList.DataMember = dtCuentas.Columns("NumCta").ToString
        cmbCuentas.DropDownList.DisplayMember = dtCuentas.Columns("NumCta").ToString
        cmbCuentas.DropDownList.ValueMember = dtCuentas.Columns("NumCta").ToString
        cmbCuentas.DropDownList.Columns(0).DataMember = dtCuentas.Columns("NumCta").ToString
        cmbCuentas.DropDownList.Columns(1).DataMember = dtCuentas.Columns("CodMon").ToString
        cmbCuentas.SelectedIndex = 0
        dtCuentas = Nothing


     


    End Sub
End Class