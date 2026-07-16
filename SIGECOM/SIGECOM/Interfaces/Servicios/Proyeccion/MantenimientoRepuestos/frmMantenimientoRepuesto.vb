Imports System.ServiceModel

Public Class frmMantenimientoRepuesto


    Private oMantenimientoRepuestosService As New MantenimientoRepuestosService.MantenimientoRepuestosServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete

    Public CodUbicacion As String
    Public DesMantenimiento As String
    '  Public DesModeloMer As String
    Public CodMantenimiento As String
    '  Public ModMer As String
    Public CodMer As String
    ' Public IdCliente As Integer
    Private dtUbicacion As New DataTable
    Private oJobService As New JobService.JobServiceClient
    Private Sub frmMantenimientoRepuesto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMantenimientoRepuestosService.Close()
            oMercaderiaService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oMantenimientoRepuestosService.Abort()
            oMercaderiaService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oMantenimientoRepuestosService.Abort()
            oMercaderiaService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmMantenimientoRepuesto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMantenimientoRepuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.Select()
        Else                    'Nuevo
            txtMantenimiento.Text = DesMantenimiento
            'txtModeloMotor.Text = DesModeloMer

            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtCodMer.Select()
        End If

    End Sub

    Private Sub llenarCombos()
        Try

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As MantenimientoRepuestosService.MantenimientoRepuestos
            registro = oMantenimientoRepuestosService.Obtener(CodUbicacion, CodMantenimiento, CodMer, Session.sCodEmp)

            cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion
            txtMantenimiento.Text = DesMantenimiento
            'txtModeloMotor.Text = ModMer
            txtCodMer.Text = registro.Producto.CodMer
            txtDescripcion.Text = registro.Descripcion
            txtItem.Value = registro.Item
            txtCanMer.Value = registro.CanMer
            txtObservacion.Text = registro.Observacion
            'lblCliente.Text = registro.Cliente.DesCli
            'IdCliente = registro.Cliente.IdCliente

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDescripcion.Text = frm.descripcion
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtCodMer.Select()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR la mercaderia?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim registro As New MantenimientoRepuestosService.MantenimientoRepuestos
                Dim mercaderia As New MantenimientoRepuestosService.Producto
                Dim ubicacionEquipo As New MantenimientoRepuestosService.UbicacionEquipo
                Dim empresa As New MantenimientoRepuestosService.Empresa
                Dim tipomantenimiento As New MantenimientoRepuestosService.TipoMantenimiento

                ubicacionEquipo.CodUbicacion = cmbUbicacion.Value
                registro.UbicacionEquipo = ubicacionEquipo
                'cliente.IdCliente = IdCliente
                'registro.Cliente = cliente
                mercaderia.CodMer = txtCodMer.Text
                empresa.CodEmp = Session.sCodEmp
                mercaderia.Empresa = empresa
                'mercaderia.DesMer1 = txtDescripcion.Text
                registro.Descripcion = txtDescripcion.Text
                tipomantenimiento.CodMantenimiento = CodMantenimiento
                registro.TipoMantenimiento = tipomantenimiento
                registro.Producto = mercaderia
                registro.Item = txtItem.Value
                registro.CanMer = txtCanMer.Value
                registro.Observacion = txtObservacion.Text

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As MantenimientoRepuestosService.MantenimientoRepuestos)
        Try
            Dim estado_process As Boolean
            estado_process = oMantenimientoRepuestosService.Insertar(registro)

            If estado_process = True Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As MantenimientoRepuestosService.MantenimientoRepuestos)
        Try
            Dim estado_process As Boolean
            estado_process = oMantenimientoRepuestosService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe ingresar el código de la mercaderia")
                txtCodMer.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe ingresar la descripción de la mercaderia")
                txtDescripcion.Focus()
                Return False
            ElseIf oMantenimientoRepuestosService.Buscar(cmbUbicacion.Value, CodMantenimiento, txtCodMer.Text, Session.sCodEmp) And state_button = False Then
                MsgBox("No se puede guardar porque el código " & txtCodMer.Text & " ya existe para estas opciones")
                txtCodMer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        If Len(Trim(txtCodMer.Text)) > 0 Then
            If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) And state_button = False Then
                Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                txtCodMer.Text = Mercaderia.CodMer
                txtDescripcion.Text = Mercaderia.DesMer1
            End If
        End If
    End Sub
End Class