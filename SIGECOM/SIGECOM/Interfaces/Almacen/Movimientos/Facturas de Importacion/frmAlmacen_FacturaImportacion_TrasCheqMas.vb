Imports System.ServiceModel
Public Class frmAlmacen_FacturaImportacion_TrasCheqMas

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oImportacionDetService As New ImportacionDetService.ImportacionDetServiceClient

    '======================Declaración de Variables==============================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtDatos As DataTable
    Public Opcion As Boolean      'True = TrasladarMasivo, False = ChequearMasivo
    Public Seleccion As Boolean     'Si llegaron todos los detalles conformes 

    Private Sub frmAlmacen_FacturaImportacion_TrasCheqMas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        LlenarCombos()
        If Seleccion = True Then
            Me.Text = "Facturas de Importación - Detalles Conformes"
            btnTrasladar.Visible = False
            btnChequear.Visible = False
            btnAceptar.Visible = True
        Else
            If Opcion = True Then
                Me.Text = "Facturas de Importación - Trasladar Masivo"
                btnTrasladar.Visible = True
                btnChequear.Visible = False
            Else
                Me.Text = "Facturas de Importación - Chequear Masivo"
                btnTrasladar.Visible = False
                btnChequear.Visible = True
            End If
            btnAceptar.Visible = False
        End If
        
        txtFecha.Value = Today
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_TrasCheqMas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_TrasCheqMas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()
            oMaestroService.Close()
            oImportacionDetService.Close()
        Catch ex As TimeoutException
            oImportacionService.Abort()
            oMaestroService.Abort()
            oImportacionDetService.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try

            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oImportacionService.MostrarLocacionImportacion(Session.sCodEmp, cmbOficinas.Value).Tables(0) 'oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub listaDatos()
        Try
            '===================================== LISTA FACTURAS ======================================
            If Seleccion = True Then
                dtDatos = oImportacionService.FiltrarChequeoMasivo(IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), 0, txtFecha.Value, txtFecha.Value, txtNumDoc.Text, "", txtCodEmbarque.Text).Tables(0) ''''
            Else
                dtDatos = oImportacionService.Filtrar(IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), 0, txtFecha.Value, txtFecha.Value, txtNumDoc.Text, IIf(Opcion = True, "GN", "TR"), "", txtCodEmbarque.Text).Tables(0)
            End If

            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbIdLocacion.ValueChanged, txtFecha.ValueChanged, txtNumDoc.TextChanged, txtCodEmbarque.TextChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      cmbOficinas.KeyPress _
                    , cmbIdLocacion.KeyPress _
                    , txtFecha.KeyPress _
                    , txtNumDoc.KeyPress _
                    , txtCodEmbarque.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("No hay datos a procesar", MsgBoxStyle.Information, "Información")
                cmbOficinas.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnTrasladar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrasladar.Click
        Try
            If MsgBox("¿Está seguro de TRASLADAR las facturas seleccionadas?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim Ingresado As Integer = 0
                    Dim rows() As Janus.Windows.GridEX.GridEXRow

                    rows = dgvDatos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow
                    Dim IdImportacion As Integer

                    If rows.Count <> 0 Then
                        For Each row In rows
                            IdImportacion = toNumber(row.Cells("IdImportacion").Value)

                            If ValidaCantidades(IdImportacion) Then
                                If (oImportacionService.TransferirStock(IdImportacion, Session.sCodUsu)) Then
                                    Ingresado = Ingresado + 1
                                Else
                                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                                End If
                            Else
                                If MsgBox("Las cantidades recibidas estan en cero. ¿Está seguro de Trasladar la Factura Nº " + row.Cells("NumDoc").Value.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                                    If (oImportacionService.TransferirStock(IdImportacion, Session.sCodUsu)) Then
                                        Ingresado = Ingresado + 1
                                    Else
                                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                                    End If
                                End If
                                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                            End If
                        Next

                        If Ingresado > 0 Then
                            MsgBox("Se trasladó las facturas de importación correctamente")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    Else
                        MsgBox("Debe seleccionar alguna de las facturas de importación")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL TRASLADAR FACTURAS DE IMPORTACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCantidades(ByVal IdImportacion As Integer) As Boolean
        Try
            Dim dtDetalles As New DataTable
            dtDetalles = oImportacionDetService.Mostrar(IdImportacion).Tables(0)

            Dim Contador As Integer = 0
            For Each Fila As DataRow In dtDetalles.Rows
                Contador = Contador + Fila.Item("CanMer")
            Next
            If Contador > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR [VALIDAR CANTIDADES]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnChequear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChequear.Click
        Try
            If MsgBox("¿Está seguro de CHEQUEAR las facturas seleccionadas?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim Ingresado As Integer = 0
                    Dim rows() As Janus.Windows.GridEX.GridEXRow

                    rows = dgvDatos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow
                    Dim IdImportacion As Integer

                    If rows.Count <> 0 Then
                        For Each row In rows
                            Dim estado_process As Boolean
                            IdImportacion = toNumber(row.Cells("IdImportacion").Value)

                            estado_process = oImportacionService.ChequearFactura(IdImportacion, Session.sCodUsu)

                            If estado_process = True Then
                                Ingresado = Ingresado + 1
                            End If
                        Next

                        If Ingresado > 0 Then
                            MsgBox("Se Chequeó las facturas de importación correctamente")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    Else
                        MsgBox("Debe seleccionar alguna de las facturas de importación")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CHEQUEAR FACTURAS DE IMPORTACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de CHEQUEAR los Detalles de las facturas seleccionadas como CONFORME?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim Ingresado As Integer = 0
                    Dim rows() As Janus.Windows.GridEX.GridEXRow

                    rows = dgvDatos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow
                    Dim IdImportacion As Integer

                    Dim dtDetalles As New DataTable

                    If rows.Count <> 0 Then
                        For Each row In rows
                            Dim estado_process As Boolean
                            IdImportacion = toNumber(row.Cells("IdImportacion").Value)

                            dtDetalles = oImportacionDetService.Mostrar(IdImportacion).Tables(0)
                            dgvDetalles.DataSource = dtDetalles

                            For i As Integer = 0 To dtDetalles.Rows.Count - 1                                                                
                                If dgvDetalles.GetRow(i).Cells("CanFac").Text >= 0 Then                                
                                    estado_process = oImportacionDetService.ChequearCantidad(dgvDetalles.GetRow(i).Cells("IdDetImportacion").Value, dgvDetalles.GetRow(i).Cells("CanFac").Value)
                                End If

                                If estado_process = True Then
                                    Ingresado = Ingresado + 1
                                End If
                            Next
                        Next

                        If Ingresado > 0 Then
                            MsgBox("Se Chequeó las facturas de importación correctamente")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    Else
                        MsgBox("Debe seleccionar alguna de las facturas de importación")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class