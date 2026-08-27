Imports System.Windows.Forms

Public Class frmBuscarJob

    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtAnios As DataTable
    Private dtLocaciones As DataTable
    Private dtTiposJob As DataTable
    Private dtClientes As DataTable

    Public cod_job As String

    Public idlocacion As String = ""
    Public tipo As Integer = 0
    Public IdCliente As Integer
    Public DesCli As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtcod_job.KeyPress _
                        , cmbLocacion.KeyPress _
                        , cmbTipo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtcod_job.KeyPress _
                        , txtanio.KeyPress _
                        , cmbLocacion.KeyPress _
                        , cmbTipo.KeyPress _
                        , btnBuscar.KeyPress _
                        , dgvDatos.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmBuscarJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = False
        llenarCombos()
        state_Search = True
        txtanio.Value = Today.Year
        If idlocacion <> "" And tipo <> 0 Then
            cmbLocacion.Value = idlocacion
            cmbTipo.Value = tipo
        Else
            cmbLocacion.SelectedIndex = 0
            cmbTipo.SelectedIndex = 0
        End If
        listaDatos()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oClienteService.Close()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
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

        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try
       
        Try
            fila(6) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub Seleccionar()
        Try
            cod_job = dgvDatos.CurrentRow.Cells("CodJob").Text
            IdCliente = dgvDatos.CurrentRow.Cells("IdClienteBeneficiado").Text
            DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oJobService.FiltrarBuscador(Session.sCodEmp, txtanio.Value, cmbLocacion.Value, utils.toNumber(cmbTipo.Value), 0, toBlank(txtcod_job.Text)).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("CodJob").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
          
            dtLocaciones = oMaestroService.MostrarOficinas("").Tables(0)
            dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbLocacion.DataSource = dtLocaciones
            cmbLocacion.DropDownList.DataMember = dtLocaciones.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtLocaciones.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtLocaciones.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 1
            dtLocaciones = Nothing
            '======================================= TIPOS DE JOB ===========================================
            dtTiposJob = oJobService.MostrarTipo.Tables(0)
            dtTiposJob.Rows.InsertAt(getRowTodos(dtTiposJob), 0)
            cmbTipo.DataSource = dtTiposJob
            cmbTipo.DropDownList.DataMember = dtTiposJob.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTiposJob.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTiposJob.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTiposJob.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTiposJob.Columns("AbrTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTiposJob = Nothing

            ''======================================= CLIENTES ================================================
            'dtClientes = oClienteService.Filtrar(Session.sCodEmp, New ClienteService.Cliente).Tables(0)
            'dtClientes.Rows.InsertAt(getRowTodos(dtClientes), 0)
            'cmbCliente.DataSource = dtClientes
            'cmbCliente.DropDownList.DataMember = dtClientes.Columns("DesCli").ToString
            'cmbCliente.DropDownList.DisplayMember = dtClientes.Columns("DesCli").ToString
            'cmbCliente.DropDownList.ValueMember = dtClientes.Columns("IdCliente").ToString
            'cmbCliente.DropDownList.Columns(0).DataMember = dtClientes.Columns("IdCliente").ToString
            'cmbCliente.DropDownList.Columns(1).DataMember = dtClientes.Columns("DesCli").ToString
            'cmbCliente.SelectedIndex = 0
            'dtClientes = Nothing

        Catch ex As Exception
            MsgBox("ERROR [BUSC-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtcod_job.TextChanged, cmbTipo.ValueChanged, cmbLocacion.ValueChanged, txtanio.ValueChanged
        listaDatos()
    End Sub
    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodJob").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "CodJob", codigo)
        End If
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   cmbTipo.ValueChanged _
                                 , txtanio.ValueChanged _
                                 , cmbLocacion.ValueChanged

        listaDatos()
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        cod_job = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

   
End Class
