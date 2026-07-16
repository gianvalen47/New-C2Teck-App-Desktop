Imports System.ServiceModel

Public Class frmJob_AgregarPlantilla

    Private oJobRepuestoService As New JobRepuestoService.JobRepuestoServiceClient

    'Private oCotizacionDetalleService As New CotizacionDetalleService.CotizacionDetalleServiceClient
    Private oModeloService As New ModeloService.ModeloServiceClient
    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient
    Private oRepuestoServicioService As New RepuestoServicioService.RepuestoServicioServiceClient
    Private oRepuestoServicioClienteService As New RepuestoServicioClienteService.RepuestoServicioClienteServiceClient
    'Private oPrecioService As New PrecioService.PrecioServiceClient

    Private dtDatos As DataTable
    Private dtModelos As DataTable
    Private dtTiposMotores As DataTable
    Private dtCodServicio As DataTable


    Public CodJob As String
    Public IdCliente As Integer
    'Public IdLocacion As Integer
    'Public IdCotizacion As Integer


    Private Sub frmJob_AgregarPlantilla_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobRepuestoService.Close()
            oModeloService.Close()
            oTipoMotorService.Close()
            oRepuestoServicioService.Close()
            oRepuestoServicioClienteService.Close()
        Catch ex As TimeoutException
            oJobRepuestoService.Abort()
            oModeloService.Abort()
            oTipoMotorService.Abort()
            oRepuestoServicioService.Abort()
            oRepuestoServicioClienteService.Abort()
        Catch ex As CommunicationException
            oJobRepuestoService.Abort()
            oModeloService.Abort()
            oTipoMotorService.Abort()
            oRepuestoServicioService.Abort()
            oRepuestoServicioClienteService.Abort()
        End Try
    End Sub

    Private Sub frmJob_AgregarPlantilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmJob_AgregarPlantilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Esta seguro de agregar las mercaderias?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If dgvDatos.RowCount < 1 Then
                    MsgBox("La lista esta vacia,no puede ingresar la plantilla", MsgBoxStyle.Exclamation)
                Else
                    If oRepuestoServicioClienteService.BuscarCliente(IdCliente) Then
                        Dim estado_process As Boolean
                        estado_process = oJobRepuestoService.IngresarPlantilla(CodJob, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value, IdCliente, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se agregaron correctamente las Mercaderias", MsgBoxStyle.Exclamation)
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                        End If
                    Else
                        Dim estado_process As Boolean
                        estado_process = oJobRepuestoService.IngresarPlantilla(CodJob, cmbCodServicio.Value, cmbTipMot.Value, cmbModMer.Value, 0, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se agregaron correctamente las Mercaderias", MsgBoxStyle.Exclamation)
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                        End If
                    End If

                    
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCodServicio.ValueChanged, cmbModMer.ValueChanged, cmbTipMot.ValueChanged
        listaDatos()
    End Sub
End Class