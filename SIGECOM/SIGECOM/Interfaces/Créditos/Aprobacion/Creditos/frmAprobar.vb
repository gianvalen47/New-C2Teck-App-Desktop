'Imports System.Windows.Forms
'Imports System.ServiceModel
Imports System.Net
Public Class frmAprobar
    Public pIdVenta As Int64
    Public pTipDoc As Int16
    Public pIdSugerido As Integer
    Public pIdCliente As Integer
    Private ObjDocumento As New AprobarVentaService.AprobarVentaServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private oCondicionPagoClienteService As New CondicionPagoClienteService.CondicionPagoClienteServiceClient

    Private DocumentoVenta As New AprobarVentaService.DocumentoVenta
    Private SugeridoCabecera As New AprobarVentaService.SugeridoCabecera
    Private dtCondicionPago As New DataTable

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

  
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            OK_Button.Focus()
        End If
    End Sub
    Private Sub txtCondicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cbCondicion.Focus()
        End If
    End Sub
    Private Sub cbCondicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub frmAprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(oCondicionPagoClienteService) = False Then
                oCondicionPagoClienteService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAprobar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        'txtCondicion.Text = "00"
    End Sub

    Private Sub LlenarCombos()
        Try
            'dtCondicionPago = ObjMaestro.MostrarCondicionPago().Tables(0) 
            'cbCondicion.DataSource = dtCondicionPago
            'cbCondicion.DisplayMember = "DesPag"
            'cbCondicion.ValueMember = "CodPag"
            'cbCondicion.DropDownList.Columns(0).DataMember = "CodPag"
            'cbCondicion.DropDownList.Columns(1).DataMember = "DesPag"
            'cbCondicion.SelectedIndex = 0
            'dtCondicionPago = Nothing

            dtCondicionPago = oCondicionPagoClienteService.Mostrar(pIdCliente).Tables(0)

            If dtCondicionPago.Rows.Count > 0 Then
                cbCondicion.DataSource = dtCondicionPago
                cbCondicion.DropDownList.DataMember = dtCondicionPago.Columns("DesPag").ToString
                cbCondicion.DropDownList.DisplayMember = dtCondicionPago.Columns("DesPag").ToString
                cbCondicion.DropDownList.ValueMember = dtCondicionPago.Columns("CodPag").ToString
                cbCondicion.DropDownList.Columns(0).DataMember = dtCondicionPago.Columns("CodPag").ToString
                cbCondicion.DropDownList.Columns(1).DataMember = dtCondicionPago.Columns("DesPag").ToString
                cbCondicion.DropDownList.Columns(2).DataMember = dtCondicionPago.Columns("DesRub").ToString
                cbCondicion.SelectedIndex = 0
                cbCondicion.ReadOnly = False
                cbCondicion.BackColor = System.Drawing.SystemColors.Window
            Else
                dtCondicionPago = ObjMaestro.MostrarCondicionPago.Tables(0)
                'dtCondicionesPago.Rows.InsertAt(getRowTodos(dtCondicionesPago), 0)
                cbCondicion.DataSource = dtCondicionPago
                cbCondicion.DropDownList.DataMember = dtCondicionPago.Columns("DesPag").ToString
                cbCondicion.DropDownList.DisplayMember = dtCondicionPago.Columns("DesPag").ToString
                cbCondicion.DropDownList.ValueMember = dtCondicionPago.Columns("CodPag").ToString
                cbCondicion.DropDownList.Columns(0).DataMember = dtCondicionPago.Columns("CodPag").ToString
                cbCondicion.DropDownList.Columns(1).DataMember = dtCondicionPago.Columns("DesPag").ToString
                cbCondicion.SelectedIndex = 0
                txtCondicion.Text = "00"
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub rbRechazar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRechazar.CheckedChanged
        cbCondicion.Enabled = False
        txtCondicion.Enabled = False
        cbCondicion.Clear()
        txtCondicion.Clear()
        txtObservacion.Focus()
    End Sub

    Private Sub rbAprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAprobar.CheckedChanged
        cbCondicion.Enabled = True
        txtCondicion.Enabled = True
        txtCondicion.Select()
    End Sub

    Private Sub txtCondicion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCondicion.Validating
        Try
            If Len(Trim(txtCondicion.Text)) > 0 Then
                Dim CodPago As String
                CodPago = ObjMaestro.MostrarDato("Maestro.CondicionPago", "CodPag", "CodPag", Trim(txtCondicion.Text))
                If CodPago <> "" Then
                    cbCondicion.Value = CodPago
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCondicion.Clear()
                    cbCondicion.Clear()
                    txtCondicion.Select()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If MsgBox("¿Está seguro de APROBAR/RECHAZAR el documento de Venta?", MsgBoxStyle.YesNo, "Aprobar/Rechazar") = MsgBoxResult.Yes Then
            'Dim NomPc As String = Dns.GetHostName
            'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
            Try
                If rbAprobar.Checked Then
                    ObjDocumento.Aprobar(pIdSugerido, pTipDoc, pIdVenta, cbCondicion.Value, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, ckTotal.Checked)

                ElseIf rbRechazar.Checked Then
                    ObjDocumento.Rechazar(pTipDoc, pIdVenta, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Grabar")
            End Try
        End If
    End Sub

    Private Sub cbCondicion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCondicion.ValueChanged
        Try
            txtCondicion.Text = cbCondicion.Value
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
