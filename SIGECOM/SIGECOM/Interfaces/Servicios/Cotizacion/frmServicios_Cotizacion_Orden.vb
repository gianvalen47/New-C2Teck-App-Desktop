Public Class frmServicios_Cotizacion_Orden

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Public IdCotizacionSer As Integer
    Private dtMedioAprobacion As DataTable

    Private Sub frmServicios_Cotizacion_Orden_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Orden_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Orden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()

        Dim registro As CotizacionServicioService.CotizacionServicio
        registro = oCotizacionServicioService.Obtener(IdCotizacionSer)

        If toBlank(cmbMedios.Value) = "" Then
            cmbMedios.Value = 1
        Else
            cmbMedios.Value = registro.MedioAprobacion.IdMedio
        End If

        txtNumOrden.Text = registro.NumOrden
    End Sub

    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception
    '    End Try
    '    'Try
    '    '    fila(1) = ""
    '    'Catch ex As Exception
    '    '    fila(2) = ""
    '    'End Try

    '    Return fila
    'End Function

    Private Sub llenarCombos()
        Try

            '======================================= MEDIO APROBACION ================================================
            dtMedioAprobacion = oCotizacionServicioService.MostrarMedioAprobacion.Tables(0)
            ' dtMedioAprobacion.Rows.InsertAt(getRowTodos(dtMedioAprobacion), 0)
            cmbMedios.DataSource = dtMedioAprobacion
            cmbMedios.DropDownList.DataMember = dtMedioAprobacion.Columns("DesMedio").ToString
            cmbMedios.DropDownList.DisplayMember = dtMedioAprobacion.Columns("DesMedio").ToString
            cmbMedios.DropDownList.ValueMember = dtMedioAprobacion.Columns("IdMedio").ToString
            cmbMedios.DropDownList.Columns(0).DataMember = dtMedioAprobacion.Columns("IdMedio").ToString
            cmbMedios.DropDownList.Columns(1).DataMember = dtMedioAprobacion.Columns("DesMedio").ToString
            ' cmbSubMarca.SelectedIndex = 0
            dtMedioAprobacion = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbMedios.Value) = "" Then
                MsgBox("Debe ingresar el medio de aprobación", MsgBoxStyle.Information)
                cmbMedios.Focus()
                Return False
            ElseIf toBlank(txtNumOrden.Text) = "" Then
                MsgBox("Debe ingresar la orden de compra", MsgBoxStyle.Information)
                txtNumOrden.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de AGREGAR la Orden?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim estado_process As Boolean
                estado_process = oCotizacionServicioService.AprobadoPorCliente(IdCotizacionSer, txtNumOrden.Text, cmbMedios.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se agregó la orden de compra correctamente ", MsgBoxStyle.Exclamation)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comunicarse con el administrador del sistema")

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class