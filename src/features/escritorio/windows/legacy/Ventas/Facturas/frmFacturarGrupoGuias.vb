Imports System.ServiceModel

Public Class frmFacturarGrupoGuias

    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private dtDatos As DataTable
    Private dtSeleccion As DataTable

    Private IdCliente As Integer
    Public IdLocacion As Integer
    Private dtMonedas As DataTable
    Private dtMotivos As DataTable


    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            'listarCombosPorCliente()
            txtCliente.Select()
            ListaDatos()
        End If
    End Sub


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cmbCodMot.KeyPress _
                      , txtNumDoc.KeyPress _
                      , txtFecDoc.KeyPress _
                      , cmbCodPag.KeyPress _
                      , cmbCodMon.KeyPress _
                      , txtCliente.KeyPress
        ', btnBuscarCliente.KeyPress _
        ', txtTotEmbarque.KeyPress _
        ', cmbCodMon.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub LlenarCombos()
        Try

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '======================================= CONDICIONES DE PAGO ================================================
            dtMotivos = oMaestroService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtMotivos
            cmbCodPag.DropDownList.DataMember = dtMotivos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtMotivos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtMotivos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesPag").ToString
            dtMotivos = Nothing

            '======================================= MOTIVOS ================================================
            dtMotivos = oReporteVentaService.MostrarMotivosVenta.Tables(0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oFacturaService.MostrarGuiasPorJob("", IdCliente).Tables(0)

            dgvDatos.DataSource = dtDatos
            'dgvDatos2.SetDataBinding(dtDatos, 0)

            dtSeleccion = dtDatos.Copy
            dtSeleccion.Clear()
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            'EnableOpciones()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de Data")
        End Try
    End Sub

    Private Function ValidarData() As Boolean
        Try
            If utils.toBlank(cmbCodPag.Value) = "" Then
                MsgBox("Debe ingresar la Forma de Pago")
                cmbCodPag.Focus()
                Return False
            ElseIf utils.toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe ingresar el Tipo de Moneda")
                cmbCodMon.Focus()
                Return False
            ElseIf utils.toBlank(cmbCodMot.Value) = "" Then
                MsgBox("Debe ingresar el Motivo")
                cmbCodMot.Focus()
                Return False
            ElseIf utils.toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el Numero de Doc ")
                txtNumDoc.Focus()
                Return False

            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try

            Dim FacturarGuias As Boolean
            'Dim x As Integer
            Dim row As DataRow
            'dtDatos = ObjFactura.FacturarGrupoGuias("", IdCliente).Tables(0)
            'dgvDatos.SetDataBinding(dtDatos, 0)

            'sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            'EnableOpciones()

            If MsgBox("¿Está seguro de FACTURAR las Guias seleccionadas?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidarData() = True Then

                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    If dgvDatos.Rows(i).Cells("Proceso").Value = True Then
                        'If dgvDatos = True Then
                        row = dtSeleccion.NewRow
                        row(0) = dtDatos.Rows(i).Item(0)
                        row(1) = dtDatos.Rows(i).Item(1)
                        row(2) = dtDatos.Rows(i).Item(2)
                        row(3) = dtDatos.Rows(i).Item(3)
                        row(4) = dtDatos.Rows(i).Item(4)
                        row(5) = dtDatos.Rows(i).Item(5)
                        row(6) = dtDatos.Rows(i).Item(6)

                        dtSeleccion.Rows.Add(row)
                    End If
                Next


                'Dim rows() As Janus.Windows.GridEX.GridEXRow
                'rows = dgvDatos2.GetCheckedRows()

                'Dim row As Janus.Windows.GridEX.GridEXRow

                'For Each row In rows

                '    dtSeleccion.R.Add(row)
                'If row.Cells("Selector").Value = True Then
                '    dtDatos.Rows(i).Item(0)
                'End If
                'row = dtSeleccion.NewRow
                'row(0) = dtDatos.Rows(i).Item(0)
                'row(1) = dtDatos.Rows(i).Item(1)
                'row(2) = dtDatos.Rows(i).Item(2)
                'row(3) = dtDatos.Rows(i).Item(3)
                'row(4) = dtDatos.Rows(i).Item(4)

                '        dtSeleccion.Rows.Add(row)
                'Dim registro As New SolicitudJobService.DestinoSolicitudJob
                'Dim persona As New SolicitudJobService.Persona
                'Dim area As New SolicitudJobService.Area
                'Dim solicitud As New SolicitudJobService.SolicitudJob

                'solicitud.IdSolicitud = IdSolicitud
                'registro.SolicitudJob = solicitud
                'area.CodArea = row.Cells("CodArea").Text
                'registro.Area = area
                'persona.IdPer = row.Cells("IdPer").Value
                'registro.Persona = persona
                'registro.Correo = row.Cells("Email").Text

                'Insertar(registro)
                'row = dtTable2.NewRow
                'row(0) = AnioAcort
                'row(1) = posicion
                'row(2) = dtReporte.Rows(x).Item(2)
                'row(3) = dtReporte.Rows(x).Item(3)
                'dtSeleccion.Clear()
                'dtSeleccion.Rows.Add(row)

                'Next
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK

                FacturarGuias = oFacturaService.FacturarGrupoGuias(IdLocacion, txtNumDoc.Text, txtFecDoc.Value, IdCliente, cmbCodPag.Value, cmbCodMot.Value, cmbCodMon.Value, dtSeleccion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If FacturarGuias = True Then
                    MsgBox("Se Facturaron el Grupo de Guias Satisfactoriamente ...!")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al Facturar las guias")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmFacturarGrupoGuias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaService.Close()
            oMaestroService.Close()
            oReporteVentaService.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oMaestroService.Abort()
            oReporteVentaService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oMaestroService.Abort()
            oReporteVentaService.Abort()
        End Try
    End Sub

    Private Sub frmFacturarGrupoGuias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFacturarGrupoGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCliente.Focus()
        txtCliente.Select()
        txtFecDoc.Value = Session.sFecha
        LlenarCombos()
        cmbCodMon.Value = "US"
        cmbCodMot.Value = "1"
    End Sub
End Class