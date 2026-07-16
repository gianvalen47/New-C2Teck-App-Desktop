Imports System.ServiceModel
Public Class frmModeloTelefonia

    '=========================== Servicios ===================================================
    Private oLineasService As New LineasService.LineasServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdLinea As Integer                        'Linea Telefonica
    Public IdModelo As Integer
    Private dtMarca As DataTable
    'Private dtTipoServicio As DataTable

    Private Sub frmModeloTelefonia_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmModeloTelefonia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmModeloTelefonia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

    Private Sub llenarCombos()
        Try

            '======================================= MARCA ================================================
            dtMarca = oLineasService.MostrarMarcas().Tables(0)
            'dtOperadores.Rows.InsertAt(getRowTodos(dtOperadores), 0)
            cmbMarca.DataSource = dtMarca
            cmbMarca.DropDownList.DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.DisplayMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.DropDownList.ValueMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(0).DataMember = dtMarca.Columns("IdMarca").ToString
            cmbMarca.DropDownList.Columns(1).DataMember = dtMarca.Columns("DesMarca").ToString
            cmbMarca.SelectedIndex = 0
            dtMarca = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As LineasService.Modelos
            registro = oLineasService.ObtenerModelo(IdModelo)

            txtIdModelo.Text = registro.IdModelo
            txtDesModelo.Text = registro.DesModelo
            cmbMarca.Value = registro.Marcas.IdMarca
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        'txtDesModelo.ReadOnly = True
        'txtDesModelo.BackColor = System.Drawing.SystemColors.Control
        'cmbMarca.Enabled = False
        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        'txtDesModelo.ReadOnly = False
        'txtDesModelo.BackColor = System.Drawing.SystemColors.Window
        'cmbMarca.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New LineasService.Modelos
                Dim marca As New LineasService.Marcas
                Dim tiposervicio As New LineasService.TipoServicio

                registro.IdModelo = IdModelo
                registro.DesModelo = txtDesModelo.Text

                marca.IdMarca = toNumber(cmbMarca.Value)
                registro.Marcas = marca

                registro.Activo = cbActivo.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL PLAN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As LineasService.Modelos)
        Try
            Dim estado_process As Integer
            estado_process = oLineasService.InsertarModelo(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLinea = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL MODELO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LineasService.Modelos)
        Try
            Dim estado_process As Boolean
            estado_process = oLineasService.ActualizarModelo(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL MODELO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesModelo.Text) = "" Then
                MsgBox("Debe ingresar el modelo", MsgBoxStyle.Information, "Información")
                txtDesModelo.Focus()
                Return False
            ElseIf toBlank(cmbMarca.Value) = "" Then
                MsgBox("Debe ingresar la marca", MsgBoxStyle.Information, "Información")
                cmbMarca.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


End Class