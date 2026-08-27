Imports System.ServiceModel
Public Class frmLineaTelefonia

    '=========================== Servicios ===================================================
    Private oLineasService As New LineasService.LineasServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdLinea As Integer                        'Linea Telefonica
    Public IdPlan As Integer
    Private dtRegion As DataTable

    Private Sub frmLineaTelefonia_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmLineaTelefonia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmLineaTelefonia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            'txtFecha.TabStop = False

        Else                                      'Nuevo            
            activar()
            cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If

    End Sub

    Private Sub LlenarCombos()
        Try
            '======================================= ESTADOS ================================================
            dtRegion = oLineasService.MostrarRegiones().Tables(0)
            'dtRegion.Rows.InsertAt(getRowTodos(dtRegion), 0)
            cmbRegion.DataSource = dtRegion
            cmbRegion.DropDownList.DataMember = dtRegion.Columns("DesRegion").ToString
            cmbRegion.DropDownList.DisplayMember = dtRegion.Columns("DesRegion").ToString
            cmbRegion.DropDownList.ValueMember = dtRegion.Columns("CodRegion").ToString
            cmbRegion.DropDownList.Columns(0).DataMember = dtRegion.Columns("CodRegion").ToString
            cmbRegion.DropDownList.Columns(1).DataMember = dtRegion.Columns("DesRegion").ToString
            cmbRegion.SelectedIndex = 0
            dtRegion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As LineasService.Lineas
            registro = oLineasService.Obtener(IdLinea)

            txtIdLinea.Text = registro.IdLinea
            txtNumLinea.Text = registro.NumLinea
            cmbRegion.Value = registro.Regiones.CodRegion
            IdPlan = registro.Planes.IdPlan
            txtPlan.Text = registro.Planes.DesPlan
            txtFecha.Value = registro.Fecha
            txtObservacion.Text = registro.Observacion
            cbActivo.Checked = registro.Activo


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        txtNumLinea.ReadOnly = True
        txtNumLinea.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        txtNumLinea.ReadOnly = False
        txtNumLinea.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub


    Private Sub btnBuscarPlan_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPlan.Click
        Try
            Dim frm As New frmBuscarPlan
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If toNull(frm.codigo) <> Nothing Then
                    txtPlan.Text = frm.descripcion
                    IdPlan = frm.codigo
                Else
                    txtPlan.Text = ""
                    IdPlan = 0
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New LineasService.Lineas
                Dim region As New LineasService.Regiones
                Dim plan As New LineasService.Planes

                registro.IdLinea = IdLinea
                registro.NumLinea = txtNumLinea.Text
                region.CodRegion = cmbRegion.Value
                registro.Regiones = region

                plan.IdPlan = toNumber(IdPlan)
                registro.Planes = plan

                registro.Fecha = txtFecha.Value
                registro.Observacion = txtObservacion.Text
                registro.Activo = cbActivo.Checked


                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA LINEA TELEFONICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As LineasService.Lineas)
        Try
            Dim estado_process As Integer
            estado_process = oLineasService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLinea = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LINEA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LineasService.Lineas)
        Try
            Dim estado_process As Boolean
            estado_process = oLineasService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LINEA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumLinea.Text) = "" Then
                MsgBox("Debe ingresar el numero de linea", MsgBoxStyle.Information, "Información")
                txtNumLinea.Focus()
                Return False
            ElseIf toBlank(cmbRegion.Value) = "" Then
                MsgBox("Debe ingresar la region", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(txtPlan.Text) = "" Then
                MsgBox("Debe ingresar el plan", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumLinea.KeyPress _
                       , cmbRegion.KeyPress _
                       , txtPlan.KeyPress _
                       , txtFecha.KeyPress _
                       , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAgregarPlan_Click(sender As Object, e As EventArgs) Handles btnAgregarPlan.Click
        Try
            Dim frm As New frmPlanTelefonia
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdPlan = frm.IdPlan
                txtPlan.Text = frm.DesPlan
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el plan telefonico : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class