Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmSepOrdenCompra

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean                   'True: Edición      False: Vista
    Public editable As Boolean                  'True: Editable     False: No Editable
    Public AprOrden As Boolean                  'True: Aprobacion    False: No necesita Aprobacion
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOrden As Integer
    Public IdLocacion As Integer
    Private IdCliente As Integer
    Public IdSugerido As Integer
    Private dtCotizaciones As DataTable
    Private dtMonedas As DataTable
    Private IdSugeridoCab As Integer

    Private Sub frmSepOrdenCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oOrdenCompraService.Close()
            oOrdenCompraDetService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
        End Try
    End Sub

    Private Sub frmSepOrdenCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSepOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()

        Desactivar()
        ObtenerRegistro()
        gbEstado.Visible = True
        actualizarDetalles()
        Me.Text = "ORDEN DE COMPRA Nº " + Chr(34) + txtNumOrden.Text.ToString + Chr(34)
        dgvDatos.Select()
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOrdenCompraDetService.Mostrar(toNumber(IdOrden)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSepararOrdenItem.Enabled = False
            biSepararOrden.Enabled = False
        Else
            'miSepararOrdenItem.Enabled = IIf((lblEstado.Text = "PARCIAL" Or lblEstado.Text = "GENERADO") And Session.CodPerfil = "14", True, False)
            miSepararOrdenItem.Enabled = IIf((lblEstado.Text = "PARCIAL" Or lblEstado.Text = "GENERADO"), True, False)
            'biSepararOrden.Enabled = IIf(lblEstado.Text = "GENERADO" And (Session.CodPerfil = "02" Or Session.CodPerfil = "14"), True, False)
            biSepararOrden.Enabled = IIf(lblEstado.Text = "GENERADO", True, False)
        End If
        'If state_button = True And (lblEstado.Text = "GENERADO" And Session.CodPerfil <> "02") Then
        '    miSepararOrdenItem.Visible = False
        'ElseIf state_button = True And lblEstado.Text = "GENERADO" And Session.CodPerfil = "02" Then
        '    miSepararOrdenItem.Visible = False
        'ElseIf state_button = True And lblEstado.Text = "ENVIADO" And Session.CodPerfil <> "02" Then
        '    miSepararOrdenItem.Visible = False
        'ElseIf state_button = True And lblEstado.Text = "ENVIADO" And Session.CodPerfil = "02" Then
        '    miSepararOrdenItem.Visible = False
        'ElseIf state_button = True And lblEstado.Text = "APROBADO" And Session.CodPerfil = "02" Then
        '    miSepararOrdenItem.Visible = True
        'ElseIf state_button = True And lblEstado.Text = "ATENDIDO" Or lblEstado.Text = "RECHAZADO" Then
        '    miSepararOrdenItem.Visible = False
        'ElseIf state_button = True And lblEstado.Text = "PARCIAL" And Session.CodPerfil <> "02" Then
        '    miSepararOrdenItem.Visible = IIf(Session.CodPerfil = "14", True, False)
        'Else
        '    miSepararOrdenItem.Visible = True
        'End If

        If state_button = True And lblEstado.Text = "GENERADO" Then
            miSepararOrdenItem.Visible = False
        ElseIf state_button = True And lblEstado.Text = "ENVIADO" Then
            miSepararOrdenItem.Visible = False
        ElseIf state_button = True And lblEstado.Text = "APROBADO" Then
            miSepararOrdenItem.Visible = True
        ElseIf state_button = True And lblEstado.Text = "ATENDIDO" Or lblEstado.Text = "RECHAZADO" Then
            miSepararOrdenItem.Visible = False
        ElseIf state_button = True And lblEstado.Text = "PARCIAL" Then
            miSepararOrdenItem.Visible = True
        Else
            miSepararOrdenItem.Visible = True
        End If

        If state_button = True And lblEstado.Text = "GENERADO" Then
            miSepararOrdenItem.Visible = True
        End If

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        txtNumOrden.ReadOnly = True
        txtNumOrden.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtFecRec.ReadOnly = True
        txtFecRec.BackColor = System.Drawing.SystemColors.Control
        txtFecEnt.ReadOnly = True
        txtFecEnt.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        ' *****************************************************
        cmbIdCotizacion.ReadOnly = True
        cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        txtObsOrden.ReadOnly = True
        txtObsOrden.BackColor = System.Drawing.SystemColors.Control
        'edicion = False
        'enableOpciones()
        dgvDatos.Select()
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenCompraService.OrdenCompra
            registro = oOrdenCompraService.MostrarPorId(IdOrden)

            IdOrden = registro.IdOrden
            IdLocacion = registro.Locacion.IdLocacion

            txtNumOrden.Text = registro.NumOrden
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            listarCotizaciones()
            txtFecha.Text = registro.Fecha
            txtFecRec.Text = registro.FecRec
            'If IsDBNull(registro.FecEnt) = Nothing Then
            '    txtFecEnt.IsNullDate = True
            'Else
            txtFecEnt.Text = registro.FecEnt
            'End If
            cmbCodMon.Value = registro.Moneda.CodMon
            txtIgv.Text = registro.Igv
            txtObsOrden.Text = toBlank(registro.ObsOrden)
            cmbIdCotizacion.Value = IIf(registro.Cotizacion.IdCotizacion Is Nothing, 0, registro.Cotizacion.IdCotizacion)
            lblEstado.Text = registro.Estado
            txtVendedor.Text = registro.Persona.ApeNom

            Me.Text = "Orden de Compra Nº " + registro.NumOrden.ToString
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listarCotizaciones()
        '======================================= CONTACTOS ================================================
        dtCotizaciones = oOrdenCompraService.MostrarCotizacion(IdCliente).Tables(0)
        dtCotizaciones.Rows.InsertAt(getRowTodos(dtCotizaciones), 0)
        cmbIdCotizacion.DataSource = dtCotizaciones
        cmbIdCotizacion.DropDownList.DataMember = dtCotizaciones.Columns("NumCot").ToString
        cmbIdCotizacion.DropDownList.DisplayMember = dtCotizaciones.Columns("NumCot").ToString
        cmbIdCotizacion.DropDownList.ValueMember = dtCotizaciones.Columns("IdCotizacion").ToString
        cmbIdCotizacion.DropDownList.Columns(0).DataMember = dtCotizaciones.Columns("IdCotizacion").ToString
        cmbIdCotizacion.DropDownList.Columns(1).DataMember = dtCotizaciones.Columns("NumCot").ToString
        dtCotizaciones = Nothing
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub miSepararOrdenItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSepararOrdenItem.Click
        Try
            If state_button Then

                miSepararOrdenItem.Visible = True
                Dim frm As New frmSepOrdenCompra_Separar

                'frm.state_button = True
                frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
                'frm.IdOrden = IdOrden
                'frm.IdLocacion = IdLocacion
                'frm.IdCliente = IdCliente
                'frm.CodMon = cmbCodMon.Value
                frm.estado = toBlank(lblEstado.Text)
                frm.lseparar = True
                '/////////////////////////////////////////////
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "update" Then
                        RowPossesion(dgvDatos, frm.IdOrdenDet)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdOrdenDet").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biSepararOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSepararOrden.Click
        Try
            If toNumber(IdOrden) > 0 Then
                Dim frm As New frmSepararOrdCompra
                frm.IdOrden = IdOrden
                frm.AprOrden = AprOrden
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [SEPAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmSepOrdenCompra_MostrarDetalle
            frm.state_button = True
            frm.IdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text
            frm.IdOrden = IdOrden
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.estado = toBlank(lblEstado.Text)
            'frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'IdSugerido = frm.IdSugerido
                'dtDatos = Nothing
                'listaDatos()
                'If frm.type_process = "update" Then
                '    RowPossesion(dgvDatos, frm.IdOrdenDet)
                'Else
                '    MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub biSeparar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSepararOrden.MouseEnter
        sslError.Text = "Separar toda la Orden de Compra"
    End Sub

    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Orden de Compra."
    End Sub

    Private Sub miSepararOrdenItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSepararOrdenItem.MouseEnter
        sslError.Text = "Actualizar detalles del Formulario Orden de Compra."
    End Sub

    Private Sub miMostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = " Mostrar Detalle de la Orden Compra."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                      biSalir.MouseLeave, miMostrar.MouseLeave, miSepararOrdenItem.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAnularSeparacion_Click(sender As Object, e As EventArgs) Handles biAnularSeparacion.Click
        Try
            If MsgBox("¿Está seguro de ANULAR la separación de toda la Orden?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim resul As Boolean = False
                'Dim pIdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text

                For Each fila As DataRow In dtDatos.Rows
                    resul = oOrdenCompraDetService.AnularSeparacion(IdOrden, fila.Item("IdOrdenDet"), Session.sCodUsu, Session.sNomPc, Session.sDireccion)
                Next

                If resul Then
                    MsgBox("La anulación de la separación de toda la orden fue exitosa ...!!!", MsgBoxStyle.Information, "Exito")
                    listaDatos()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miAnularSeparacion_Click(sender As Object, e As EventArgs) Handles miAnularSeparacion.Click

        Try
            If MsgBox("¿Está seguro de ANULAR separación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim resul As Boolean = False
                Dim pIdOrdenDet = dgvDatos.CurrentRow.Cells("IdOrdenDet").Text

                resul = oOrdenCompraDetService.AnularSeparacion(IdOrden, pIdOrdenDet, Session.sCodUsu, Session.sNomPc, Session.sDireccion)
                If resul Then
                    MsgBox("La anulación fue exitosa ...!!!", MsgBoxStyle.Information, "Exito")
                    listaDatos()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub
End Class