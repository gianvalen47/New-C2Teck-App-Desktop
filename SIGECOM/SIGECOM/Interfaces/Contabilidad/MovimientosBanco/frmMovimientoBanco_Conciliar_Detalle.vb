Imports System.ServiceModel

Public Class frmMovimientoBanco_Conciliar_Detalle

    '===========================Servicios====================================================
    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient

    Private dtTipoMov As DataTable
    Public IdConciliacion As Integer
    Private IdMovimiento As Integer
    Private IdMovimientoDet As Integer



    Private Sub frmMovimientoBanco_Conciliar_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMovimientoBancosService.Close()
        Catch ex As TimeoutException
            oMovimientoBancosService.Abort()
        Catch ex As CommunicationException
            oMovimientoBancosService.Abort()
        End Try
    End Sub

    Private Sub frmMovimientoBanco_Conciliar_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimientoBanco_Conciliar_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'llenarCombos()
        ObtenerRegistro()

    End Sub

    'Private Sub llenarCombos()

    '    Try
    '        '======================================= MESES ================================================
    '        dtTipoMov = oMovimientoBancosService.MostrarTipoMovBanco().Tables(0)
    '        'dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
    '        cmbTipMov.DataSource = dtTipoMov
    '        cmbTipMov.DropDownList.DataMember = dtTipoMov.Columns("Descripcion").ToString
    '        cmbTipMov.DropDownList.DisplayMember = dtTipoMov.Columns("Descripcion").ToString
    '        cmbTipMov.DropDownList.ValueMember = dtTipoMov.Columns("CodTipo").ToString
    '        cmbTipMov.DropDownList.Columns(0).DataMember = dtTipoMov.Columns("CodTipo").ToString
    '        cmbTipMov.DropDownList.Columns(1).DataMember = dtTipoMov.Columns("Descripcion").ToString
    '        cmbTipMov.DropDownList.Columns(2).DataMember = dtTipoMov.Columns("TipMov").ToString
    '        cmbTipMov.SelectedIndex = 0
    '        dtTipoMov = Nothing

    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub


    Private Sub ObtenerRegistro()

        Try
            Dim registro As MovimientoBancosService.ConciliacionBanco
            registro = oMovimientoBancosService.ObtenerConciliacion(IdConciliacion)

            IdMovimiento = registro.MovimientoBancosDet.MovimientoBancos.IdMovimiento
            IdMovimientoDet = registro.MovimientoBancosDet.IdMovimientoDet
            txtTipo.Text = registro.MovimientoBancosDet.TipoMovBanco.Descripcion
            txtMonto.Text = registro.MovimientoBancosDet.Monto
            txtFecha.Text = registro.Fecha
            txtObservacion.Text = registro.Observacion


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then


            Dim registro As New MovimientoBancosService.ConciliacionBanco
            Dim MovBanco As New MovimientoBancosService.MovimientoBancos
            Dim MovBancodet As New MovimientoBancosService.MovimientoBancosDet

            MovBanco.IdMovimiento = IdMovimiento

            MovBancodet.MovimientoBancos = MovBanco
            MovBancodet.IdMovimientoDet = CInt(IdMovimientoDet)

            registro.MovimientoBancosDet = MovBancodet
            registro.IdConciliacion = IdConciliacion

            registro.Fecha = CDate(txtFecha.Value)
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp


            Actualizar(registro)

        End If
    End Sub

    Private Sub Actualizar(ByVal registro As MovimientoBancosService.ConciliacionBanco)

        Try
            Dim estado_process As Boolean
            estado_process = oMovimientoBancosService.ActualizarConciliacion(registro)
            'type_process = "insert"

            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR CONCILIACION : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class