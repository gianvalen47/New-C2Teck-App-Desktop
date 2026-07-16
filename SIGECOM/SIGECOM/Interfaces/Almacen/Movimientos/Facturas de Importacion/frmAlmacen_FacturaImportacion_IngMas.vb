Imports Janus.Windows.GridEX
Imports System.ServiceModel
Public Class frmAlmacen_FacturaImportacion_IngMas

    '===========================Servicios====================================================
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    '======================Declaración de Variables==============================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtDatos As DataTable

    'Dim CodOfi As String
    'Dim IdLocacion As Integer

    Private Sub frmAlmacen_FacturaImportacion_IngMas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ListaDatos()

        txtFecDoc.Value = Today
        llenarCombos()
        cmbIdLocacion.Focus()
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_IngMas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_IngMas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oFacturaImportService.Close()
            oImportacionService.Close()
            'oMaestroService.Close()
        Catch ex As TimeoutException
            oFacturaImportService.Abort()
            oImportacionService.Abort()
            'oMaestroService.Abort()
        Catch ex As CommunicationException
            oFacturaImportService.Abort()
            oImportacionService.Abort()
            'oMaestroService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= OFICINAS ================================================
            'dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            'cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            'cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            'cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            'cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            'cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            'cmbOficinas.SelectedIndex = 0
            'dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        'If toBlank(cmbOficinas.Value) <> "" Then
        '    '======================================= ALMACENES ================================================
        '    dtAlmacenes = oImportacionService.MostrarLocacionImportacion(Session.sCodEmp, cmbOficinas.Value).Tables(0) 'oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
        '    cmbIdLocacion.DataSource = dtAlmacenes
        '    cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
        '    cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
        '    cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
        '    cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
        '    cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
        '    If dtAlmacenes.Rows.Count > 0 Then
        '        cmbIdLocacion.SelectedIndex = 0
        '    Else
        '        cmbIdLocacion.Value = ""
        '    End If
        '    dtAlmacenes = Nothing
        'Else
        '    cmbIdLocacion.Value = ""
        'End If
    End Sub

    Private Sub ListaDatos()
        Try
            '-------- Se comenta el 11/11/2014 (Sr Camacho y Sra. Mori) ya que se usuará otro metodo para mostrar --------------
            '-------- las facturas de importación pendientes filtradas por locación y codembarque -------------------------------------------
            'Dim registro As New FacturaImportService.FacturaImport
            'Dim serieImp As New FacturaImportService.SerieImportacion
            'Dim clienteSold As New FacturaImportService.Cliente
            'Dim clienteShip As New FacturaImportService.Cliente

            'serieImp.IdSerieImp = 1     'facturas de importacion
            'registro.SerieImportacion = serieImp
            'clienteSold.IdCliente = 0
            'registro.ClienteSold = clienteSold
            'registro.NumDoc = ""            
            'registro.FecIni = Nothing
            'registro.FecFin = Nothing
            'registro.Estado = "GN"

            'dtDatos = oFacturaImportService.Filtrar(registro, "").Tables(0)
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------

            'dtDatos = oFacturaImportService.MostrarFacturasPendientes(cmbIdLocacion.Value, txtCodEmbarque.Text).Tables(0)  '--------- Se agregó el 11/11/2014 solicitud de usuario 4314 -------
            dtDatos = oFacturaImportService.MostrarFacturasPendientes(Session.sCodEmp, txtCodEmbarque.Text).Tables(0)  '--------- Se modifca a filtrar solo por embarque el 19/10/2018 solicitud de usuario 65542 -------
            dgvDatos.SetDataBinding(dtDatos, 0)

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim Ingresado As Integer = 0
                    Dim rows() As Janus.Windows.GridEX.GridEXRow

                    rows = dgvDatos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow

                    'CodOfi = toBlank(cmbOficinas.Value)
                    'IdLocacion = toNumber(cmbIdLocacion.Value)

                    If rows.Count <> 0 Then
                        For Each row In rows                        
                            Dim estado_process As Integer
                            Dim IdProveedor As Integer = toNumber(row.Cells("IdProveedor").Value)
                            Dim IdFactura As Integer = toNumber(row.Cells("IdFactura").Value)
                            Dim NumDoc As String = row.Cells("NumDoc").Text
                            Dim IdLocacion As Integer = toNumber(row.Cells("IdLocacion").Value)

                            estado_process = oImportacionService.IngresarFacturaImportacion(IdLocacion, IdProveedor, _
                                                                                                                             txtFecDoc.Text, NumDoc, txtObservacion.Text, IdFactura, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            If estado_process > 0 Then
                                Ingresado = Ingresado + 1
                            End If
                        Next

                        If Ingresado > 0 Then
                            MsgBox("Facturas de Importación ingresadas correctamente")
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

    Private Function ValidaCampos() As Boolean
        Try           
            If toNull(txtFecDoc.Text) = Nothing Then
                MsgBox("Debe Ingresar la fecha de la factura", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
                'ElseIf toBlank(cmbOficinas.Value) = "" Then
                '    MsgBox("Debe Ingresar la Oficina", MsgBoxStyle.Information, "Información")
                '    cmbOficinas.Focus()
                '    Return False
                'ElseIf toBlank(cmbIdLocacion.Value) = "" Then
                '    MsgBox("Debe Ingresar la Almacen", MsgBoxStyle.Information, "Información")
                '    cmbIdLocacion.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                       txtFecDoc.KeyPress _
                       , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCodEmbarque.TextChanged
        ListaDatos()
    End Sub
End Class