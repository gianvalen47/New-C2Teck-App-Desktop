Imports System.ServiceModel

Public Class frmEquipoTelefonia

    '=========================== Servicios ===================================================
    Private oLineasService As New LineasService.LineasServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdEquipo As Integer
    Public IdMarca As Integer
    Private dtModelo As DataTable
    Private dtMarca As DataTable

    Private Sub frmEquipoTelefonia_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmEquipoTelefonia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEquipoTelefonia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        LlenarCombos()

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

            ''======================================= MODELO ================================================
            'dtModelo = oLineasService.MostrarModelos(cmbMarca.Value).Tables(0)
            ''dtModelo.Rows.InsertAt(getRowTodos(dtModelo), 0)
            'cmbModelo.DataSource = dtModelo
            'cmbModelo.DropDownList.DataMember = dtModelo.Columns("IdModelo").ToString
            'cmbModelo.DropDownList.DisplayMember = dtModelo.Columns("DesModelo").ToString
            'cmbModelo.DropDownList.ValueMember = dtModelo.Columns("IdModelo").ToString
            'cmbModelo.DropDownList.Columns(0).DataMember = dtModelo.Columns("IdModelo").ToString
            'cmbModelo.DropDownList.Columns(1).DataMember = dtModelo.Columns("DesModelo").ToString
            'cmbModelo.SelectedIndex = 0
            'dtModelo = Nothing


            '======================================= MARCA ================================================
            dtMarca = oLineasService.MostrarMarcas().Tables(0)
            'dtMarca.Rows.InsertAt(getRowTodos(dtMarca), 0)
            cmbMarca.DataSource = dtMarca
            cmbMarca.DropDownList.DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.DisplayMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.ValueMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(0).DataMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(1).DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.SelectedIndex = 0
            dtMarca = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As LineasService.Equipos
            registro = oLineasService.ObtenerEquipo(IdEquipo)

            txtIdEquipo.Text = registro.IdEquipo
            txtDesEquipo.Text = registro.DesEquipo
            cmbMarca.Value = registro.Modelos.Marcas.IdMarca
            'LlenarCombos()
            cmbModelo.Value = registro.Modelos.IdModelo
            txtFechaCambio.Value = registro.FechaCambio
            txtNumSerie.Text = registro.NumSerie
            txtImeiEquipo.Text = registro.ImeiEquipo
            txtImeiChip.Text = registro.ImeiChip
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        'txtDesEquipo.ReadOnly = True
        'txtDesEquipo.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        'txtDesEquipo.ReadOnly = False
        'txtDesEquipo.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New LineasService.Equipos
                Dim modelo As New LineasService.Modelos

                registro.IdEquipo = IdEquipo
                registro.DesEquipo = txtDesEquipo.Text
                modelo.IdModelo = utils.toNumber(cmbModelo.Value)
                registro.Modelos = modelo
                registro.FechaCambio = txtFechaCambio.Text
                registro.NumSerie = txtNumSerie.Text
                registro.ImeiEquipo = txtImeiEquipo.Text
                registro.ImeiChip = txtImeiChip.Text
                registro.Activo = cbActivo.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As LineasService.Equipos)
        Try
            Dim estado_process As Integer
            estado_process = oLineasService.InsertarEquipo(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdEquipo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LineasService.Equipos)
        Try
            Dim estado_process As Boolean
            estado_process = oLineasService.ActualizarEquipo(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesEquipo.Text) = "" Then
                MsgBox("Debe ingresar la descripción del equipo", MsgBoxStyle.Information, "Información")
                txtDesEquipo.Focus()
                Return False
            ElseIf toBlank(cmbModelo.Value) = "" Then
                MsgBox("Debe ingresar el modelo", MsgBoxStyle.Information, "Información")
                cmbModelo.Focus()
                Return False
            ElseIf toBlank(txtFechaCambio.Text) = "" Then
                MsgBox("Debe ingresar la fecha de cambio", MsgBoxStyle.Information, "Información")
                txtFechaCambio.Focus()
                Return False
            ElseIf toBlank(txtNumSerie.Text) = "" Then
                MsgBox("Debe ingresar el numero de serie", MsgBoxStyle.Information, "Información")
                txtNumSerie.Focus()
                Return False
            ElseIf toBlank(txtImeiEquipo.Text) = "" Then
                MsgBox("Debe ingresar el imei del equipo", MsgBoxStyle.Information, "Información")
                txtImeiEquipo.Focus()
                Return False
            ElseIf toBlank(txtImeiChip.Text) = "" Then
                MsgBox("Debe ingresar el imei del chip", MsgBoxStyle.Information, "Información")
                txtImeiChip.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub cmbMarca_ValueChanged(sender As Object, e As EventArgs) Handles cmbMarca.ValueChanged
        Try

            '======================================= MODELO ================================================
            dtModelo = oLineasService.MostrarModelos(cmbMarca.Value).Tables(0)
            'dtModelo.Rows.InsertAt(getRowTodos(dtModelo), 0)
            cmbModelo.DataSource = dtModelo
            cmbModelo.DropDownList.DataMember = dtModelo.Columns("IdModelo").ToString
            cmbModelo.DropDownList.DisplayMember = dtModelo.Columns("DesModelo").ToString
            cmbModelo.DropDownList.ValueMember = dtModelo.Columns("IdModelo").ToString
            cmbModelo.DropDownList.Columns(0).DataMember = dtModelo.Columns("IdModelo").ToString
            cmbModelo.DropDownList.Columns(1).DataMember = dtModelo.Columns("DesModelo").ToString
            cmbModelo.SelectedIndex = 0
            dtModelo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class