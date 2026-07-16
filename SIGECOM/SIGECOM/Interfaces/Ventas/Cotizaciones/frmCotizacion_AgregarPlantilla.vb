Public Class frmCotizacion_AgregarPlantilla

    Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oModeloService As New ModeloService.ModeloServiceClient
    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient
    Private oRepuestoServicioService As New RepuestoServicioService.RepuestoServicioServiceClient
    Private oRepuestoServicioClienteService As New RepuestoServicioClienteService.RepuestoServicioClienteServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient

    Public IdCliente As Integer
    Public IdLocacion As Integer
    Public IdCotizacion As Integer

    Private dtModelos As DataTable
    Private dtTiposMotores As DataTable
    Private dtCodServicio As DataTable
    Private dtDatos As DataTable


    Private Sub frmCotizacion_AgregarPlantilla_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionDetalleService) = False Then
                oCotizacionDetalleService.Close()
            End If
            If isClosed(oModeloService) = False Then
                oModeloService.Close()
            End If
            If isClosed(oTipoMotorService) = False Then
                oTipoMotorService.Close()
            End If
            If isClosed(oRepuestoServicioService) = False Then
                oRepuestoServicioService.Close()
            End If
            If isClosed(oRepuestoServicioClienteService) = False Then
                oRepuestoServicioClienteService.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCotizacion_AgregarPlantilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_AgregarPlantilla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbCodServicio.KeyPress _
            , cmbModMer.KeyPress _
            , cmbTipMot.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmCotizacion_AgregarPlantilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        llenarCombos()
        llenarCombosTipoServicio()
        listaDatos()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MODELOS ================================================
            dtModelos = oModeloService.Mostrar.Tables(0)
            ' dtModelos.Rows.InsertAt(getRowTodos(dtModelos), 0)
            cmbModMer.DataSource = dtModelos
            cmbModMer.DropDownList.DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.DisplayMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.ValueMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(0).DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(1).DataMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.SelectedIndex = 0
            dtModelos = Nothing

            '======================================= TIPOS DE MOTORES =========================================
            dtTiposMotores = oTipoMotorService.Mostrar.Tables(0)
            'dtTiposMotores.Rows.InsertAt(getRowTodos(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            dtTiposMotores = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
      
    End Sub
    Private Sub llenarCombosTipoServicio()
        Try

            If oRepuestoServicioClienteService.BuscarCliente(IdCliente) Then
                dtCodServicio = oRepuestoServicioService.MostrarTipoServicioCliente(IdCliente).Tables(0)
                cmbCodServicio.DataSource = dtCodServicio
                cmbCodServicio.DropDownList.DataMember = dtCodServicio.Columns("Nombre").ToString
                cmbCodServicio.DropDownList.DisplayMember = dtCodServicio.Columns("Nombre").ToString
                cmbCodServicio.DropDownList.ValueMember = dtCodServicio.Columns("CodServicio").ToString
                cmbCodServicio.DropDownList.Columns(0).DataMember = dtCodServicio.Columns("CodServicio").ToString
                cmbCodServicio.DropDownList.Columns(1).DataMember = dtCodServicio.Columns("Nombre").ToString
                cmbCodServicio.SelectedIndex = 0
                dtCodServicio = Nothing
            Else
                dtCodServicio = oRepuestoServicioService.MostrarTipoServicio(Session.sCodEmp).Tables(0)
                cmbCodServicio.DataSource = dtCodServicio
                cmbCodServicio.DataSource = dtCodServicio
                cmbCodServicio.DropDownList.DataMember = dtCodServicio.Columns("Nombre").ToString
                cmbCodServicio.DropDownList.DisplayMember = dtCodServicio.Columns("Nombre").ToString
                cmbCodServicio.DropDownList.ValueMember = dtCodServicio.Columns("CodServicio").ToString
                cmbCodServicio.DropDownList.Columns(0).DataMember = dtCodServicio.Columns("CodServicio").ToString
                cmbCodServicio.DropDownList.Columns(1).DataMember = dtCodServicio.Columns("Nombre").ToString
                cmbCodServicio.SelectedIndex = 0
                dtCodServicio = Nothing
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If oRepuestoServicioClienteService.BuscarCliente(IdCliente) Then
                dtDatos = oRepuestoServicioClienteService.Mostrar(Session.sCodEmp, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value, IdCliente).Tables(0)
            Else
                dtDatos = oRepuestoServicioService.Mostrar(Session.sCodEmp, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value).Tables(0)
            End If
            dgvDatos.SetDataBinding(dtDatos, 0)

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de AGREGAR las mercaderias?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If dgvDatos.RowCount < 1 Then
                    MsgBox("La lista esta vacia,no puede ingresar la plantilla", MsgBoxStyle.Exclamation)
                Else
                    Dim estado_process As Boolean
                    oCotizacionDetalleService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
                    estado_process = oCotizacionDetalleService.IngresarPlantilla(IdCotizacion, dtDatos, Session.sCodUsu)
                    If estado_process Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If

                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCodServicio.ValueChanged, cmbModMer.ValueChanged, cmbTipMot.ValueChanged
        listaDatos()
    End Sub
End Class