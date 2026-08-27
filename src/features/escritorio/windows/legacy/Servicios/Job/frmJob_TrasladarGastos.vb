Imports System.ServiceModel

Public Class frmJob_TrasladarGastos

    Private dtRubros As DataTable
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oJobService As New JobService.JobServiceClient
    Public CodJob As String


    Private Sub frmJobTrasladarGastos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oGastoRealService.Close()

        Catch ex As TimeoutException
            oGastoRealService.Abort()

        Catch ex As CommunicationException
            oGastoRealService.Abort()
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try

        Return fila
    End Function

    Private Sub frmJob_TrasladarGastos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtCodJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodJob.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Len(Trim(txtCodJob.Text)) > 0 Then

                    If Not (oJobService.Buscar(txtCodJob.Text)) Then
                        MsgBox("Número de OT no existente, Verifique")
                        txtCodJob.Text = ""
                        txtCodJob.Focus()
                    ElseIf oJobService.Estado(txtCodJob.Text) = 16 Or oJobService.Estado(txtCodJob.Text) = 25 Then
                        MsgBox("Número de OT Liquidado o  Facturado, Verifique")
                        txtCodJob.Text = ""
                        txtCodJob.Focus()
                    End If

                Else
                    MsgBox("Ingrese un N° de OT")
                    txtCodJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ValidaR Busqueda de la OT" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmTrasladarGastos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCodJob.KeyPress _
            , cmbRubro.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmTrasladarGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        lblCodJob.Text = CodJob
        Me.Text = "Trasladar Gastos de la OT"
    End Sub

    Private Sub txtCodJob_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodJob.Validating

    End Sub

    Private Sub llenarCombos()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox("Error al llenar los combos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean

        Try
            If toBlank(CodJob) = "" Then
                MsgBox("Debe ingresar la OT que se va a trasladar")
                Return False
            ElseIf toBlank(txtCodJob.Text) = "" Then
                MsgBox("Debe ingresar la OT a donde se va a trasladar los gastos")
                txtCodJob.Focus()
                Return False
            ElseIf toBlank(txtMotivo.Text) = "" Then
                MsgBox("Debe ingresar el motivo del traslado de los gastos")
                txtMotivo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar los campos")
        End Try

    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try

            If MsgBox("¿Estás seguro de Trasladar los Gastos a la OT N°" & txtCodJob.Text & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim estado_process As Boolean
                oGastoRealService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                estado_process = oGastoRealService.TrasladarGastos(CodJob, toBlank(txtCodJob.Text), toBlank(cmbRubro.Value), toBlank(txtMotivo.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If estado_process Then
                    MsgBox("Se traslado correctamente los gastos.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else
                    MsgBox("Error en el proceso , Comunicarse con el Administrador del Sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Trasladar los Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtCodJob.Text = frm.cod_job
            Else
                txtCodJob.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Error al buscar la OT : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class