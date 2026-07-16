Imports System.Net
Imports System.ServiceModel

Public Class frmGarantias

    Private objDocumento As New AprobarVentaService.AprobarVentaServiceClient
    Private objFactura As New FacturaService.FacturaServiceClient
    Private objMaestro As New MaestroService.MaestroClient
    Private objGuiaDevolucion As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private ObjJob As New JobService.JobServiceClient
    Private dtDocumento As New DataTable
    Private dtlistar As New DataTable
    Dim NumDoc As Integer
    Private bDocVenta As Boolean
    Private estado_process As Boolean
    Private state_button As Boolean = True

    Private Sub frmGarantias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            objDocumento.Close()
            ObjMaestro.Close()
            objFactura.Close()
            objGuiaDevolucion.Close()
            ObjJob.Close()
        Catch ex As TimeoutException
            objDocumento.Abort()
            objMaestro.Abort()
            objFactura.Abort()
            objGuiaDevolucion.Abort()
            ObjJob.Abort()
        Catch ex As CommunicationException
            objDocumento.Abort()
            objMaestro.Abort()
            objFactura.Abort()
            objGuiaDevolucion.Abort()
            ObjJob.Abort()
        End Try
    End Sub
    Private Sub frmGarantias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'btnBuscarJob.Select()
        txtNroJob.Select()
        'listaDatos()
        llenarCombos()

    End Sub
    Private Sub frmGarantias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNroJob.KeyPress _
                         , btnBuscarJob.KeyPress _
                         , rbtnFacturar.KeyPress _
                         , txtCondicion.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            state_button = False
            listaDatos()
        End If
        'If txtNroFactura.TabIndex = 5 Then
        '    MsgBox("aaa!", MsgBoxStyle.Information)
        'End If
    End Sub

    Private Sub frmGarantias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If txtNroJob.Text = "" Then
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'txtNroJob.BackColor = System.Drawing.SystemColors.Control
                txtNroJob.Text = frm.cod_job
                state_button = False
                listaDatos()
                cbDocumento.Focus()
            Else
                txtNroJob.Text = ""
            End If
        Else
            listaDatos()
        End If
        'If dtlistar.Columns.Count <> 0 Then
        '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '        'txtNroJob.BackColor = System.Drawing.SystemColors.Control
        '        txtNroJob.Text = frm.cod_job
        '        listaDatos()
        '        cbDocumento.Focus()
        '    End If
        'End If
    End Sub
    Private Sub listaDatos()
        Try
            If state_button = False Then

                If txtNroJob.Text = "" Then
                    MsgBox("Debe colocar un Nro de OT!", MsgBoxStyle.Information)
                Else
                    If rbGR.Checked = True Then
                        dtlistar = objFactura.MostrarGuiasPorJob(txtNroJob.Text, 0).Tables(0)
                    ElseIf rbGD.Checked = True Then
                        dtlistar = objGuiaDevolucion.MostrarGuiasDevolucionPorJob(txtNroJob.Text).Tables(0)
                    End If

                    'DataGridView1.SetDataBinding(dtlistar, 0)
                    'DataGridView1.DataSource = dtlistar
                    DataGridView1.DataSource = dtlistar

                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function VerificarDatos() As Boolean
        Dim resul As Boolean = True
        If cbDocumento.Value <> 169 Then
            bDocVenta = objFactura.BuscarDocumentoVenta(cbDocumento.Value, toNumber(txtNroFactura.Text))
            If bDocVenta = False Then
                resul = False
            End If
        End If 
        Return resul
    End Function
    Private Function ValidarGrilla() As Boolean
        Dim resul As Boolean = False
        Dim i As Integer = 0
        If dtlistar.Rows.Count() > 0 Then
            For Each row As DataRow In dtlistar.Rows
                If row.Item("Proceso") Then
                    i = i + 1
                End If
            Next
            If i = 0 Then
                MsgBox("Debe seleccionar las Guías a Facturar", MsgBoxStyle.Information)
                resul = True
            End If
        End If 
        Return resul
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= TIPO DE DOCUMENTO ================================================
            dtDocumento = objFactura.MostrarSerieFacturarJob(Session.sCodEmp).Tables(0)
            'Dim rowd As DataRow = dtDocumento.NewRow
            'rowd(0) = 0
            'rowd(1) = "(Todos)"
            'dtDocumento.Rows.InsertAt(rowd, 0)

            'dtDocumento = New DataTable
            'dtDocumento.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            'dtDocumento.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtDocumento.Rows.Add(New Object() {"1", "Facturas"})
            'dtDocumento.Rows.Add(New Object() {"2", "Boletas"})

            cbDocumento.DataSource = dtDocumento
            'cbDocumento.DropDownList.DataMember = dtDocumento.Columns("nombre").ToString
            'cbDocumento.DropDownList.DisplayMember = dtDocumento.Columns("nombre").ToString
            'cbDocumento.DropDownList.ValueMember = dtDocumento.Columns("codigo").ToString
            'cbDocumento.DropDownList.Columns(0).DataMember = dtDocumento.Columns("codigo").ToString
            'cbDocumento.DropDownList.Columns(1).DataMember = dtDocumento.Columns("nombre").ToString
            'cbDocumento.SelectedIndex = 0
            'cbDocumento = Nothing

            cbDocumento.DisplayMember = "Descripcion"
            cbDocumento.ValueMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(1).DataMember = "Descripcion"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing

            'cmbTipoDocumento.DataSource = dtTipoDocumentos
            'cmbTipoDocumento.DropDownList.DataMember = dtTipoDocumentos.Columns("nombre").ToString
            'cmbTipoDocumento.DropDownList.DisplayMember = dtTipoDocumentos.Columns("nombre").ToString
            'cmbTipoDocumento.DropDownList.ValueMember = dtTipoDocumentos.Columns("codigo").ToString
            'cmbTipoDocumento.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("codigo").ToString
            'cmbTipoDocumento.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("nombre").ToString
            'cmbTipoDocumento.SelectedIndex = 0
            'dtTipoDocumentos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [GEN-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            'Dim NomPc As String = Dns.GetHostName
            'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)

            If ObjJob.Buscar(txtNroJob.Text) = False Then
                MsgBox("La OT ingresada no existe, ingrese bien!!!!!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If


            If ValidarGrilla() = False Then

                If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    If rbtnFacturar.Checked = True Then
                        If VerificarDatos() = True Then
                            Try
                                estado_process = objFactura.FacturarGuias(cbDocumento.Value, txtNroFactura.Text, dtlistar, 1, _
                                                                    txtObservacion.Text, txtNroJob.Text, Session.sCodUsu, _
                                                                 Session.sNomPc, Session.sDirIp)
                            Catch ex As Exception
                                MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
                            End Try

                            'Dim state_process As Boolean
                            If estado_process = True Then
                                MsgBox("Se Facturó las Guias exitosamente.")
                            Else
                                MsgBox("No se Facturo las Guias, verificar.")
                            End If
                        Else
                            MsgBox("Nro de Documento no exite.Verifique!", MsgBoxStyle.Information)
                            txtNroFactura.Select()
                        End If

                    End If

                    If rbtnProcesar.Checked = True Then
                        Try
                            If rbGR.Checked = True Then
                                estado_process = objFactura.FacturarGuias(0, 0, dtlistar, 2, _
                                                         txtObservacion.Text, txtNroJob.Text, Session.sCodUsu, _
                                                         Session.sNomPc, Session.sDirIp)
                            ElseIf rbGD.Checked = True Then
                                estado_process = objGuiaDevolucion.ProcesarGuias(dtlistar, toNull(txtObservacion.Text), toNull(txtNroJob.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                            End If

                        Catch ex As Exception
                            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)

                        End Try

                        If estado_process = True Then
                            MsgBox("Se Procesó las Guias exitosamente.")
                        Else
                            MsgBox("No se Proceso las Guias, verificar.")
                        End If
                    End If

                End If
            Else
                MsgBox("Nro de Documento no existe.Verifique!", MsgBoxStyle.Information)
                txtNroFactura.Select()
            End If
            limpiarDatos()
        Catch ex As Exception
            MsgBox("ERROR [GEN-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
  
    Private Sub limpiarDatos()
        Try
            txtNroJob.Clear()
            txtObservacion.Clear()
            txtNroFactura.Clear()
            cbDocumento.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al limpiar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtNroFactura_keyPress(ByVal sender As Object, _
                              ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                              Handles txtNroFactura.KeyPress _
                              , btnAceptar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'ValidarGrilla()
            'VerificarDatos()
        End If
    End Sub
    Private Sub txtCondicion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCondicion.Validating
        Try
            If Len(Trim(txtCondicion.Text)) > 0 Then
                Dim TipoDoc As String
                Dim desc As Integer
                TipoDoc = ObjMaestro.MostrarDato("Maestro.SerieDocumento", "IdSerieDoc", "IdSerieDoc", Trim(txtCondicion.Text))
                desc = TipoDoc
                If TipoDoc <> "" Then
                    cbDocumento.Value = desc
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCondicion.Clear()
                    cbDocumento.Clear()
                    txtCondicion.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub cbDocumento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDocumento.ValueChanged
        Try
            txtCondicion.Text = cbDocumento.Value
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub rbtnProcesar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProcesar.CheckedChanged, rbtnFacturar.CheckedChanged
        If rbtnProcesar.Checked Then
            txtNroFactura.Enabled = False
            cbDocumento.Enabled = False
            txtCondicion.Enabled = False
            If rbGD.Checked = True Then
                rbtnFacturar.Enabled = False
            ElseIf rbGR.Checked = True Then
                rbtnFacturar.Enabled = True
            End If

        Else
            txtNroFactura.Enabled = True
            cbDocumento.Enabled = True
            txtCondicion.Enabled = True
        End If
    End Sub

    Private Sub rbGR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGR.CheckedChanged, rbGD.CheckedChanged
        Try
            If rbGR.Checked = True Then
                rbtnFacturar.Checked = True
                rbtnFacturar.Enabled = True
                listaDatos()

            ElseIf rbGD.Checked = True Then
                rbtnProcesar.Checked = True
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox("Error al validar el tipo de proceso : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    
End Class