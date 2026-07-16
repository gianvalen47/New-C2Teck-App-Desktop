Imports System.ServiceModel
Public Class frmOportunidadNegocio_Gastos_Mostrar

    '===========================Servicios====================================================
    'Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public IdOportunidad As Integer
    Public IdProveedor As Integer
    Public IdOportunidadGasto As Integer
    Private dtMonedas As DataTable

    Private dtTipDoc As DataTable

    Private Sub frmOportunidadNegocio_Gastos_Mostrar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oOportunidadNegocioService.Close()
            oOrdenesCompraService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oOportunidadNegocioService.Abort()
            oOrdenesCompraService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oOportunidadNegocioService.Abort()
            oOrdenesCompraService.Abort()
        End Try
    End Sub

    Private Sub frmOportunidadNegocio_Gastos_Mostrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_Gastos_Mostrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cmbTipoDoc.Select()
        LlenarCombos()
        ObtenerRegistro()
        desactivar()

    End Sub


    Private Sub LlenarCombos()
        Try
            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("AplicaIgv").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OportunidadNegocioService.OportunidadNegocioGastos
            registro = oOportunidadNegocioService.ObtenerGastos(IdOportunidadGasto)

            IdOportunidad = registro.OportunidadNegocio.IdOportunidad
            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            txtSerieDoc.Text = registro.SerDoc
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Text = registro.FecDoc
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMonto.Value = registro.Monto
            txtDescripcion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()

        txtProveedor.ReadOnly = True
        txtProveedor.BackColor = System.Drawing.SystemColors.Control
        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtMonto.ReadOnly = True
        txtMonto.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control

    End Sub


    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class