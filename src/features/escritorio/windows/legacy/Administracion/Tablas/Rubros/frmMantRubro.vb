Imports System.ServiceModel
Public Class frmMantRubro

    Private oRubrosService As New RubrosService.RubrosServiceClient
    Private dtOficinas As DataTable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public CodRub As String
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMetodos As DataTable
    Private dtCentroCosto As New DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmMantRubro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRubrosService.Close()
        Catch ex As TimeoutException
            oRubrosService.Abort()
        Catch ex As CommunicationException
            oRubrosService.Abort()
        End Try
    End Sub

    Private Sub frmMantRubro_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub frmMantRubro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            'Me.Text = "Rubro :  " + Chr(34) + .Text.ToString + Chr(34)
        Else 'Nuevo
            activar()
            Me.Size = New System.Drawing.Size(471, 298)
            Me.Text = "Registrar nuevo Rubro"
            SugerirCodRub()
            'cbActivo.Checked = True
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try
            dtMetodos = New DataTable
            dtMetodos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtMetodos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtMetodos.Rows.Add(New Object() {"", ""})
            dtMetodos.Rows.Add(New Object() {"1", "PROMEDIO"}) ', New DateTime(2008, 2, 5)
            dtMetodos.Rows.Add(New Object() {"5", "IDENTIFICACION ESPECIFICA"})

            cmbMetodo.DataSource = dtMetodos
            cmbMetodo.DropDownList.DataMember = dtMetodos.Columns("nombre").ToString
            cmbMetodo.DropDownList.DisplayMember = dtMetodos.Columns("nombre").ToString
            cmbMetodo.DropDownList.ValueMember = dtMetodos.Columns("codigo").ToString
            cmbMetodo.DropDownList.Columns(0).DataMember = dtMetodos.Columns("codigo").ToString
            cmbMetodo.DropDownList.Columns(1).DataMember = dtMetodos.Columns("nombre").ToString
            cmbMetodo.SelectedIndex = 0
            dtMetodos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As RubrosService.Rubro
            registro = oRubrosService.Obtener(CodRub)

            txtCodRub.Text = registro.CodRub
            txtDesRub.Text = registro.DesRub
            txtAbrvRub.Text = registro.AbrRub
            cmbMetodo.Value = registro.CodMetodo
            'txtMetodo.Text = registro.Metodo
            txtFacVenta.Text = registro.FacVen
            txtFacCosto.Text = registro.FacCos
            txtDscto.Text = registro.Dscto
            txtOrden.Text = registro.Orden

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        txtCodRub.ReadOnly = True
        txtCodRub.BackColor = System.Drawing.SystemColors.Control
        txtDesRub.ReadOnly = True
        txtDesRub.BackColor = System.Drawing.SystemColors.Control
        txtAbrvRub.ReadOnly = True
        txtAbrvRub.BackColor = System.Drawing.SystemColors.Control
        cmbMetodo.ReadOnly = True
        cmbMetodo.BackColor = System.Drawing.SystemColors.Control
        'txtMetodo.ReadOnly = True
        'txtMetodo.BackColor = System.Drawing.SystemColors.Control
        'cbActivo.Enabled = True
        txtDscto.ReadOnly = True
        txtDscto.BackColor = System.Drawing.SystemColors.Control
        txtFacVenta.ReadOnly = True
        txtFacVenta.BackColor = System.Drawing.SystemColors.Control
        txtFacCosto.ReadOnly = True
        txtFacCosto.BackColor = System.Drawing.SystemColors.Control

        txtDscto.ReadOnly = True
        txtDscto.BackColor = System.Drawing.SystemColors.Control
        txtOrden.ReadOnly = True
        txtOrden.BackColor = System.Drawing.SystemColors.Control


    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        txtCodRub.ReadOnly = True
        txtCodRub.BackColor = System.Drawing.SystemColors.Control
        txtDesRub.ReadOnly = False
        txtDesRub.BackColor = System.Drawing.SystemColors.Window
        txtAbrvRub.ReadOnly = False
        txtAbrvRub.BackColor = System.Drawing.SystemColors.Window
        cmbMetodo.ReadOnly = False
        cmbMetodo.BackColor = System.Drawing.SystemColors.Window
        'txtMetodo.ReadOnly = False
        'txtMetodo.BackColor = System.Drawing.SystemColors.Window
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window
        txtFacVenta.ReadOnly = False
        txtFacVenta.BackColor = System.Drawing.SystemColors.Window

        txtFacCosto.ReadOnly = False
        txtFacCosto.BackColor = System.Drawing.SystemColors.Window
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window
        txtOrden.ReadOnly = False
        txtOrden.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub SugerirCodRub()

        Dim numsug As Integer
        numsug = oRubrosService.SugerirCodigo().ToString()
        txtCodRub.Text = numsug

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New RubrosService.Rubro
                'Dim metodo As New RubrosService

                registro.CodRub = txtCodRub.Text
                registro.DesRub = txtDesRub.Text
                registro.AbrRub = txtAbrvRub.Text
                registro.CodMetodo = cmbMetodo.Value
                registro.Metodo = cmbMetodo.Text
                registro.FacVen = toDouble(txtFacVenta.Text)
                registro.FacCos = toDouble(txtFacCosto.Text)
                registro.Dscto = toDouble(txtDscto.Text)
                registro.Orden = txtOrden.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then    'Modificar
                    Modificar(registro)
                Else                    'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As RubrosService.Rubro)
        Try
            Dim estado_process As Boolean
            estado_process = oRubrosService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el rubro correctamente")
                CodRub = txtCodRub.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL RUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RubrosService.Rubro)
        Try
            Dim estado_process As Boolean
            estado_process = oRubrosService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modifico el rubro correctamente")
                ObtenerRegistro()
                desactivar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de T.I...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL RUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodRub.Text) = "" Then
                MsgBox("Debe Ingresar el Codigo", MsgBoxStyle.Information, "Información")
                txtCodRub.BackColor = Color.Red
                txtCodRub.Focus()
                Return False
                'ElseIf toBlank(txtCodAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar el Codigo del Almacen", MsgBoxStyle.Information, "Información")
                '    txtCodAlm.BackColor = Color.Red
                '    txtCodAlm.Focus()
                '    Return False
                'ElseIf toBlank(txtDesAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar la Descripción del Almacen", MsgBoxStyle.Information, "Información")
                '    txtDesAlm.BackColor = Color.Red
                '    txtDesAlm.Focus()
                '    Return False
                'ElseIf toBlank(txtAbrAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar la Abreviatura del Almacen", MsgBoxStyle.Information, "Información")
                '    txtAbrAlm.BackColor = Color.Red
                '    txtAbrAlm.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub



End Class