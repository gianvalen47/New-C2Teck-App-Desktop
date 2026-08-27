Public Class frmAprobarServicios_Aprobar

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Public IdCotizacionSer As Integer
    Public NumCotizacion As String
    Public IdCliente As Integer
    Public Fecha As Date
    Private dtCondicionesPago As DataTable

   
    Private Sub frmServicios_Cotizacion_Rechazar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub frmServicios_Cotizacion_Aprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        txtNumDoc.Text = NumCotizacion
        txtFecha.Text = Fecha
        cmbCodPag.Value = "00"

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= CONDICIONES DE PAGO ================================================
            dtCondicionesPago = oMaestroService.MostrarCondicionPago.Tables(0)
            'dtCondicionesPago.Rows.InsertAt(getRowTodos(dtCondicionesPago), 0)
            cmbCodPag.DataSource = dtCondicionesPago
            cmbCodPag.DropDownList.DataMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtCondicionesPago.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtCondicionesPago.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtCondicionesPago.Columns("DesPag").ToString
            dtCondicionesPago = Nothing

            '=====================================Porcentaje===================================================
            Dim dtPorcentaje As New DataTable("Porcentaje")
            'Añadimos las columnas codigo y descripcion
            dtPorcentaje.Columns.Add("Codigo", GetType(Integer))
            'dsMeses.Columns.Add("Porcentaje", GetType(String))
            'Añadimos los m al dataset
            dtPorcentaje.Rows.Add(New Object() {10})
            dtPorcentaje.Rows.Add(New Object() {20})
            dtPorcentaje.Rows.Add(New Object() {30})
            dtPorcentaje.Rows.Add(New Object() {40})
            dtPorcentaje.Rows.Add(New Object() {50})
            dtPorcentaje.Rows.Add(New Object() {60})
            dtPorcentaje.Rows.Add(New Object() {70})
            dtPorcentaje.Rows.Add(New Object() {80})
            dtPorcentaje.Rows.Add(New Object() {90})
            dtPorcentaje.Rows.Add(New Object() {100})
            dtPorcentaje.AcceptChanges()

            'Establecemos la datatable como la fuente de datos de nuestro combo.
            cmbPorcentaje.DataSource = dtPorcentaje
            cmbPorcentaje.ValueMember = "Codigo"
            'cmbPorcentaje.DisplayMember = "Porcentaje "
            'Seleccionamos el mes actual.
            cmbPorcentaje.SelectedValue = Date.Now.Month
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If rbRechazar.Checked = True And toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe ingresar la observación!!!!!")
                txtObservacion.Select()
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

            If MsgBox("¿Esta seguro de " & IIf(rbAprobar.Checked = True, "Aprobar", "Rechazar") & " la cotización Nº " & NumCotizacion, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim estado_process As Boolean
                If rbAprobar.Checked = True Then
                    estado_process = oCotizacionServicioService.Aprobar(IdCotizacionSer, cmbCodPag.Value, toNumber(cmbPorcentaje.Text), IIf(txtMonto.Text = "", 0, txtMonto.Text), txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("La aprobación se realizo con éxito")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("No se realizó la aprobación")
                    End If

                ElseIf rbRechazar.Checked = True Then

                    estado_process = oCotizacionServicioService.Rechazar(IdCotizacionSer, txtObservacion.Text, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                    If estado_process = True Then
                        MsgBox("El rechazó se realizo con éxito")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("No se realizo el rechazo")
                    End If

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rcAdelanto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rcAdelanto.CheckedChanged
        If rcAdelanto.Checked Then
            gbAdelanto.Enabled = True
        Else
            gbAdelanto.Enabled = False
            cmbPorcentaje.Text = ""
            txtMonto.Clear()
            rbMonto.Checked = False
            rbPorcentaje.Checked = False
        End If
    End Sub

    Private Sub rbPorcentaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPorcentaje.CheckedChanged
        If rbPorcentaje.Checked Then
            cmbPorcentaje.Enabled = True
            txtMonto.Enabled = False
            txtMonto.Clear()
        ElseIf rbMonto.Checked Then
            txtMonto.Enabled = True
            cmbPorcentaje.Enabled = False
            cmbPorcentaje.Text = ""
        End If
    End Sub

    Private Sub rbAprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAprobar.CheckedChanged, rbRechazar.CheckedChanged
        If rbAprobar.Checked = True Then
            lblCondPago.Enabled = True
            cmbCodPag.Enabled = True
            gbAdelanto.Enabled = True
            rcAdelanto.Enabled = True

        ElseIf rbRechazar.Checked = True Then
            lblCondPago.Enabled = False
            cmbCodPag.Enabled = False
            gbAdelanto.Enabled = False
            rcAdelanto.Enabled = False
            txtObservacion.Select()
        End If
    End Sub
End Class