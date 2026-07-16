Imports System.ServiceModel

Public Class frmCalendarioDetalle_Actualizar

    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    Private oLocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderiaServiceClient

    Private dtMotivo As New DataTable
    Public IdProcesoAct As String
    Public IdLocacionAct As String
    Public CodMer As String
    Public Fecha As DateTime

    Private Sub frmCalendarioDetalle_Actualizar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresAlmacenService.Close()
        Catch ex As TimeoutException
            oIndicadoresAlmacenService.Abort()
        Catch ex As CommunicationException
            oIndicadoresAlmacenService.Abort()
        End Try
    End Sub

    Private Sub frmCalendarioDetalle_Actualizar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCalendarioDetalle_Actualizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        ObtenerRegistro()
        ActivarMotivo()
        txtStock.Select()
    End Sub

    Private Sub ActivarMotivo()
        If txtStock.Value <> txtFisico.Value Then
            lblMotivo.Visible = True
            cmbMotivo.Visible = True
            If cmbMotivo.Value Is Nothing Then
                cmbMotivo.Text = ""
            End If
        Else
            lblMotivo.Visible = False
            cmbMotivo.Visible = False
            cmbMotivo.Text = "Diferente"
        End If
    End Sub

    Private Sub llenarCombos()

        '======================================= MOTIVO ================================================
        dtMotivo = oIndicadoresAlmacenService.MostrarMotivos.Tables(0)
        'DataGridView1.DataSource = dtMotivo
        'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
        cmbMotivo.DataSource = dtMotivo
        cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("DesMotivo").ToString
        cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("DesMotivo").ToString
        cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("IdMotivo").ToString
        cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("IdMotivo").ToString
        cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("DesMotivo").ToString
        cmbMotivo.SelectedIndex = 0
        dtMotivo = Nothing
    End Sub

    Private Sub ObtenerRegistro()
        Try
            'Dim locacion As String
            Dim registro As IndicadoresAlmacenService.AbcMercaderiaCalendario
            Dim Mercaderia As LocacionMercaderiaService.LocacionMercaderia

            registro = oIndicadoresAlmacenService.ObtenerCalendario(IdProcesoAct, CodMer, Fecha)

            txtCodigo.Text = CodMer
            txtAbcConsumo.Text = registro.AbcConsumo
            'txtStock.Text = registro.Stock
            'locacion = registro.Locacion.IdLocacion

            Mercaderia = oLocacionMercaderia.MostrarPorCodigo(IdLocacionAct, CodMer)

            'txtStock.Text = Mercaderia.Stock       'Comentado para que no obtenga la mercaderia actual 19/03/15
            txtStock.Text = registro.Stock

            txtFisico.Text = registro.Fisico
            cmbMotivo.Value = registro.MotivoCalendario.IdMotivo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim registro As New IndicadoresAlmacenService.AbcMercaderiaCalendario
            Dim Mercaderia As New IndicadoresAlmacenService.Mercaderia
            Dim Motivo As New IndicadoresAlmacenService.MotivoCalendario
            'Dim Locacion As New IndicadoresAlmacenService.Locacion

            If cmbMotivo.Text = "" Then
                MsgBox("Debe Seleccionar un Motivo", MsgBoxStyle.Information)
            Else
                registro.IdProceso = IdProcesoAct
                Mercaderia.CodMer = CodMer
                'Locacion.IdLocacion = IdLocacionAct
                'registro.Locacion = Locacion
                registro.Mercaderia = Mercaderia
                registro.AbcConsumo = txtAbcConsumo.Text
                registro.Stock = utils.toNumber(txtStock.Text)
                registro.Fisico = utils.toNumber(txtFisico.Text)
                registro.Fecha = Fecha
                If txtStock.Text = txtFisico.Text Then
                    registro.Evaluacion = 0
                    Motivo.IdMotivo = Nothing
                    registro.MotivoCalendario = Motivo
                Else : registro.Evaluacion = 1
                    Motivo.IdMotivo = cmbMotivo.Value
                    registro.MotivoCalendario = Motivo
                End If
                'Motivo.IdMotivo = cmbMotivo.Value
                'registro.MotivoCalendario = Motivo

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today

                Modificar(registro)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As IndicadoresAlmacenService.AbcMercaderiaCalendario)
        Try
            Dim estado_process As Boolean

            estado_process = oIndicadoresAlmacenService.ActualizarCalendario(registro)

            If estado_process Then
                CodMer = txtCodigo.Text
                MsgBox("Se modificó correctamente la Mercaderia")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS " + ex.Message)
        End Try

    End Sub

    Private Sub txtStock_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStock.ValueChanged
        ActivarMotivo()
    End Sub

    Private Sub txtFisico_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFisico.ValueChanged
        ActivarMotivo()
    End Sub

End Class