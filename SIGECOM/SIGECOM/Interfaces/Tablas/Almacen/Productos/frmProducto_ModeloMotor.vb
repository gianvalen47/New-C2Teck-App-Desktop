Imports System.ServiceModel

Public Class frmProducto_ModeloMotor

    Private oProductoService As New ProductoService.ProductoServiceClient
    Private oModeloService As New ModelosProductoService.ModelosProductoServiceClient

    Private dtDatos As DataTable
    Public CodMer As String
    Public ModMer As String
    Public state_button As Boolean

    Private dtModelosMotor As DataTable

    Private Sub frmProducto_ModeloMotor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProductoService.Close()
        Catch ex As TimeoutException
            oProductoService.Abort()
        Catch ex As CommunicationException
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmProducto_ModeloMotor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProducto_ModeloMotor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then
            ObtenerRegistro()
            cmbModeloMer.ReadOnly = True
            cmbModeloMer.BackColor = System.Drawing.SystemColors.Control
            txtObserModMotor.Select()
        Else
            cmbModeloMer.ReadOnly = False
            cmbModeloMer.BackColor = System.Drawing.SystemColors.Window
            cmbModeloMer.Select()
        End If

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro2 As ProductoService.ProductosModelos
            oProductoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro2 = oProductoService.ObtenerModelo(CodMer, Session.sCodEmp, ModMer)

            cmbModeloMer.Value = registro2.ModelosProducto.ModMer
            txtObserModMotor.Text = registro2.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MODELOS ================================================
            dtModelosMotor = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            cmbModeloMer.DataSource = dtModelosMotor
            cmbModeloMer.DropDownList.DataMember = dtModelosMotor.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.DisplayMember = dtModelosMotor.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.ValueMember = dtModelosMotor.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.Columns(0).DataMember = dtModelosMotor.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.Columns(1).DataMember = dtModelosMotor.Columns("Descripcion").ToString
            cmbModeloMer.SelectedIndex = 0
            dtModelosMotor = dtModelosMotor

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        If state_button Then
            ModificarModelo()
        Else
            GuardarModelo()
        End If

    End Sub

    Private Sub GuardarModelo()

        Dim registro As New ProductoService.ProductosModelos
        Dim modelomotor As New ProductoService.ModelosProducto
        Dim producto As New ProductoService.Producto
        Dim empresa As New ProductoService.Empresa
        'Dim extension As New CodigoBarraService.

        modelomotor.ModMer = cmbModeloMer.Value
        modelomotor.Descripcion = cmbModeloMer.DropDownList.GetRow.Cells(1).Text   'cmbModeloMer.Text

        '
        'modelomotor.Empresa = empresa

        registro.ModelosProducto = modelomotor

        producto.CodMer = CodMer

        empresa.CodEmp = Session.sCodEmp
        producto.Empresa = empresa
        registro.Producto = producto

        registro.CodUsu = Session.sCodUsu
        registro.NomPc = Session.sNomPc
        registro.DirIp = Session.sDirIp

        registro.Observacion = txtObserModMotor.Text

        InsertarModeloMotor(registro)

    End Sub

    Private Sub InsertarModeloMotor(ByVal registro As ProductoService.ProductosModelos)

        Try
            Dim estado_process As Boolean

            estado_process = oProductoService.InsertarModelo(registro)

            If estado_process = True Then

                MsgBox("Se inserto el modelo correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Barra")
        End Try

    End Sub

    Private Sub ModificarModelo()

        Dim registro As New ProductoService.ProductosModelos
        Dim modelomotor As New ProductoService.ModelosProducto
        Dim producto As New ProductoService.Producto
        Dim empresa As New ProductoService.Empresa
        'Dim extension As New CodigoBarraService.

        modelomotor.ModMer = cmbModeloMer.Value
        modelomotor.Descripcion = cmbModeloMer.DropDownList.GetRow.Cells(1).Text   'cmbModeloMer.Text

        registro.ModelosProducto = modelomotor

        producto.CodMer = CodMer

        empresa.CodEmp = Session.sCodEmp
        producto.Empresa = empresa
        registro.Producto = producto

        registro.CodUsu = Session.sCodUsu
        registro.NomPc = Session.sNomPc
        registro.DirIp = Session.sDirIp

        registro.Observacion = txtObserModMotor.Text

        ActualizarModeloMotor(registro)

    End Sub

    Private Sub ActualizarModeloMotor(ByVal registro As ProductoService.ProductosModelos)

        Try
            Dim estado_process As Boolean

            estado_process = oProductoService.ActualizarModelo(registro)

            If estado_process = True Then
                MsgBox("Se actualizo el modelo correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Barra")
        End Try

    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtObserModMotor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObserModMotor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            Else
                'dgvDatos.Select()
            End If
        End If
    End Sub

End Class