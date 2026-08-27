Imports System.ServiceModel
Public Class frmConsultaCompra_CtaxPagar

    '===========================Servicios====================================
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oPagosCtasPorPagarService As New PagosCtasPorPagarService.PagosCtasPorPagarServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient

    '======================Declaración de Variables==============================   
    Public IdCuenta As Integer
    Private dtTipDoc As DataTable
    Private dtCondPago As DataTable
    Private dtMonedas As DataTable
    Private dtDatos As DataTable
    Private dtPersonaPosesion As DataTable

    Private Sub frmConsultaCompra_CtaxPagar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCtasPorPagarService.Close()
            oPagosCtasPorPagarService.Close()
            oMaestroService.Close()
            oOrdenesCompraService.Close()
            oProveedorService.Close()
        Catch ex As TimeoutException
            oCtasPorPagarService.Abort()
            oPagosCtasPorPagarService.Abort()
            oMaestroService.Abort()
            oOrdenesCompraService.Abort()
            oProveedorService.Abort()
        Catch ex As CommunicationException
            oCtasPorPagarService.Abort()
            oPagosCtasPorPagarService.Abort()
            oMaestroService.Abort()
            oOrdenesCompraService.Abort()
            oProveedorService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsultaCompra_CtaxPagar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                cmMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmConsultaCompra_CtaxPagar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        LlenarCombos()

        ObtenerCuenta()
        actualizarDetalles()
      
        If dgvDatos.RowCount = 0 Then
            miMostrar.Enabled = False
        Else
            miMostrar.Enabled = True
            dgvDatos.Select()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowTodos3(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
        End Try
        Try
            fila(3) = ""
        Catch ex As Exception
        End Try
        Try
            fila(4) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("Nombre").ToString
            dtTipDoc = Nothing

            '================================CONDICION DE PAGO PROVEEDOR===================================
            dtCondPago = oProveedorService.MostrarCondicionPago.Tables(0)
            cmbCodPago.DataSource = dtCondPago
            cmbCodPago.DropDownList.DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.DisplayMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.ValueMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCodPago.DropDownList.Columns(0).DataMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCodPago.DropDownList.Columns(1).DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.Columns(2).DataMember = dtCondPago.Columns("DiasPago").ToString
            dtCondPago = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '====================================PERSONA POSESIÓN===========================================
            dtPersonaPosesion = oCtasPorPagarService.MostrarPosesion(Session.sCodEmp).Tables(0)
            dtPersonaPosesion.Rows.InsertAt(getRowTodos3(dtPersonaPosesion), 0)
            cmbPersonaPosesion.DisplayMember = dtPersonaPosesion.Columns("ApeNom").ToString()
            cmbPersonaPosesion.ValueMember = dtPersonaPosesion.Columns("IdPer").ToString
            cmbPersonaPosesion.DataSource = dtPersonaPosesion
            cmbPersonaPosesion.SelectedIndex = 0
            dtPersonaPosesion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerCuenta()
        Try
            Dim registro As CtasPorPagarService.CtasPorPagar
            registro = oCtasPorPagarService.Obtener(IdCuenta)

            IdCuenta = registro.IdCuenta
            txtIdCuenta.Text = registro.IdCuenta
            txtFecEmision.Value = registro.FecEmision
            txtFecRecepcion.Value = registro.FecRecepcion
            txtFecVencimiento.Value = registro.FecVencimiento
            txtFecVencimiento.Text = registro.FecVencimiento.ToString
            txtTipoCambio.Value = registro.TipCam
            cmbMoneda.Value = toNull(registro.Moneda.CodMon)
            txtTotal.Value = registro.Total
            txtTotalPago.Value = registro.TotalPago
            txtObservacion.Text = registro.Observacion
            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            txtNumDoc.Text = registro.NumDoc
            txtSerieDoc.Text = registro.SerDoc
            txtProveedor.Text = registro.Proveedor.DesProv
            cmbCodPago.Value = registro.CondicionPagoProveedor.IdCondicion
            cbRecibioCheque.Checked = registro.RecibioCheque
            cbPagoCaja.Checked = registro.PagoCaja
            If registro.Persona.IdPer = Nothing Then
                cmbPersonaPosesion.SelectedIndex = 0
            Else
                cmbPersonaPosesion.SelectedValue = registro.Persona.IdPer
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Cuenta Por Pagar")
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdCuentaDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPagosCtasPorPagarService.Mostrar(toNumber(txtIdCuenta.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCuentaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, miMostrar.Click
        If dgvDatos.RecordCount > 0 Then
            Dim frm As New frmCuentasPorPagar_Detalle
            frm.state_button = True
            frm.IdCuentaDet = dgvDatos.CurrentRow.Cells("IdCuentaDet").Text
            frm.IdCuenta = IdCuenta
            frm.iEstado = "CA"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerCuenta()
                listaDatos()
            End If
            RowPossesion(dgvDatos, frm.IdCuentaDet)
        End If
    End Sub

    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Mostrar Detalles del Formulario."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biSalir.MouseLeave, _
                                    miSalir.MouseLeave, miMostrar.MouseLeave
        sslError.Text = ""
    End Sub
End Class