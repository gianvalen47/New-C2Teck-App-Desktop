Imports Janus.Windows.GridEX
Imports System.ServiceModel
Public Class frmReembolso_Gasto

    '===========================Servicios====================================================
    Dim oReembolsoCajaDetService As New ReembolsoCajaDetService.ReembolsoCajaDetServiceClient
    Dim oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Dim oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Public IdReembolso As Integer
    Public IdGasto As Integer
    Public NumReembolso As String
    Private dtDatos As DataTable
    Private dtTipoGasto As DataTable
    Private dtMonedas As DataTable
    Public CodOficina As String


    Private Sub frmReembolso_Gasto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        dgvDatos.RowHeaders = InheritableBoolean.False
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        txtIdGasto.Focus()
        Me.Text = "INGRESAR GASTOS AL REEEMBOLSO Nº " + NumReembolso
    End Sub

    Private Sub frmReembolso_Gasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmReembolso_Gasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oReembolsoCajaDetService.Close()
            oSolicitudGastoService.Close()
            oSolicitudGastoDetService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oReembolsoCajaDetService.Abort()
            oSolicitudGastoService.Abort()
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oReembolsoCajaDetService.Abort()
            oSolicitudGastoService.Abort()
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub ListarDetallesGasto()
        Try
            dtDatos = oSolicitudGastoDetService.MostrarNoContabilizado(toNumber(txtIdGasto.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos

            LlenarTipoGasto()

            If cmbMoneda.Value = "NS" Then
                dgvDatos.RootTable.Columns(9).EditType = Janus.Windows.GridEX.EditType.NoEdit
            Else
                dgvDatos.RootTable.Columns(9).EditType = Janus.Windows.GridEX.EditType.TextBox
            End If

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES DE GASTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LlenarTipoGasto()
        Try

            ''======================== TIPO GASTO (COMBO) =========================
            dtTipoGasto = oReembolsoCajaDetService.MostrarTipoGasto().Tables(0)
            Dim column As GridEXColumn

            column = dgvDatos.RootTable.Columns("IdTipoGasto")
            column.ValueList.PopulateValueList(dtTipoGasto.DefaultView, "IdTipoGasto", "DesTipo")

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR TIPO DE GASTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidarCodigo() As Boolean
        Try
            If Len(Trim(txtIdGasto.Text)) > 0 Then
                If Not (oSolicitudGastoService.Buscar(toNumber(txtIdGasto.Text))) Then
                    MsgBox("Número de Solicitud de Gasto inexistente, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                ElseIf CodOficina = "01" And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 5 And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 7 _
                    And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 3 And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 10 Then
                    'MsgBox("Número de Solicitud de Gasto aún no ha sido aprobada por Mesa de Control, Verifique")
                    MsgBox("Número de Solicitud de Gasto aún no ha sido aprobada, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                ElseIf CodOficina <> "01" And (oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) = 1 Or oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) = 8) Then
                    MsgBox("Número de Solicitud de Gasto en estado Generado o Enviado, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                ElseIf CodOficina <> "02" And oSolicitudGastoDetService.BuscarCuentasVacias(toNumber(txtIdGasto.Text)) Then
                    MsgBox("Número de Solicitud de Gasto con detalles sin cuenta contable, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                Else
                    Return True
                End If
            Else
                MsgBox("Ingrese un N° de Solicitud de Gasto")
                txtIdGasto.Text = ""
                txtIdGasto.Focus()
                Limpiar()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL GASTO : " + ex.Message)
        End Try
    End Function

    Private Sub Limpiar()
        txtIdGasto.Text = ""
        txtFecha.IsNullDate = True
        txtArea.Text = ""
        cmbMoneda.Text = ""
        txtPersonaSolicita.Text = ""
        txtPersonaAutoriza.Text = ""
        lblEstado.Text = ""       
        dtDatos = Nothing
        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoService.SolicitudGasto
            registro = oSolicitudGastoService.Obtener(toNumber(txtIdGasto.Text))

            IdGasto = registro.IdGasto
            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtArea.Text = registro.Area.DesArea
            cmbMoneda.Value = registro.Moneda.CodMon
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.PersonaJefe.ApeNom
            lblEstado.Text = registro.EstadoSolicitudGasto.DesEstado
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtIdGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdGasto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If ValidarCodigo() Then
                ObtenerRegistro()
                ListarDetallesGasto()
            End If
        End If
    End Sub

    Private Sub llenarCombos()
        Try
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

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    'Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    '    Try 
    '        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
    '        And ValidarCodigo() Then

    '            Dim Vacio As Integer = 0 'Número de detalles con Tipo de gasto vacio
    '            Dim row As Janus.Windows.GridEX.GridEXRow
    '            Dim TipoGasto1 As Integer 'Valor de Tipo de Gasto

    '            If dgvDatos.RowCount > 0 Then

    '                '=================Recorrido para verificar que todos los detalles tengan Tipo de Gasto=========
    '                For i = 0 To Me.dgvDatos.RowCount - 1
    '                    Me.dgvDatos.Row = i
    '                    row = Me.dgvDatos.GetRow()
    '                    TipoGasto1 = IIf(row.Cells("IdTipoGasto").Text = "", 0, row.Cells("IdTipoGasto").Value)
    '                    If TipoGasto1 = 0 Then
    '                        Vacio = Vacio + 1
    '                    End If
    '                Next
    '                '===========================================================================

    '                If Vacio > 0 Then 'Validamos si no hay algun detalle sin Tipo de Gasto
    '                    MsgBox("Debe ingresar los datos, Verificar")
    '                Else

    '                    Dim IdGasto As Integer           'IdGato del Detalle
    '                    Dim IdGastoDet As Integer      'IdGastoDet del Detalle
    '                    Dim CodArea As String           'CodArea del Detalle
    '                    Dim IdTipoGasto As Integer     'IdTipoGasto del Detalle
    '                    Dim Placa As String               'Placa del Detalle
    '                    Dim Item As Integer                'Item del Detalle
    '                    Dim TotalFila As Double          'TotalFila del Detalle
    '                    Dim Descripcion As String       'Descripcion del Detalle
    '                    Dim Observacion As String      'Observacion del Detalle

    '                    '===========Recorrido para ingresar detalles de Solicitud a Reembolso============      
    '                    For i = 0 To Me.dgvDatos.RowCount - 1
    '                        Me.dgvDatos.Row = i
    '                        row = Me.dgvDatos.GetRow()
    '                        IdGasto = row.Cells("IdGasto").Value
    '                        IdGastoDet = row.Cells("IdGastoDet").Value
    '                        CodArea = row.Cells("CodArea").Value
    '                        IdTipoGasto = row.Cells("IdTipoGasto").Value
    '                        Placa = row.Cells("Placa").Text
    '                        Item = CInt(row.Cells("Item").Text)
    '                        TotalFila = row.Cells("TotalFila").Value
    '                        Descripcion = row.Cells("Descripcion").Text
    '                        Observacion = row.Cells("Justificacion").Text

    '                        If Not (oReembolsoCajaDetService.BuscarGasto(IdGasto, IdGastoDet)) Then

    '                            Dim registro As New ReembolsoCajaDetService.ReembolsoCajaDet
    '                            Dim Reembolso As New ReembolsoCajaDetService.ReembolsoCaja
    '                            Dim Area As New ReembolsoCajaDetService.Area
    '                            Dim TipoGasto As New ReembolsoCajaDetService.TipoGasto
    '                            Dim Unidad As New ReembolsoCajaDetService.Unidad
    '                            Dim SolicitudGasto As New ReembolsoCajaDetService.SolicitudGasto
    '                            Dim SolicitudGastoDet As New ReembolsoCajaDetService.SolicitudGastoDet

    '                            registro.IdReembolsoDet = 0
    '                            Reembolso.IdReembolso = IdReembolso
    '                            registro.ReembolsoCaja = Reembolso

    '                            SolicitudGasto.IdGasto = IdGasto
    '                            SolicitudGastoDet.IdGastoDet = IdGastoDet
    '                            SolicitudGastoDet.SolicitudGasto = SolicitudGasto
    '                            registro.SolicitudGastoDet = SolicitudGastoDet

    '                            registro.Item = Item
    '                            Area.CodArea = CodArea
    '                            registro.Area = Area
    '                            TipoGasto.IdTipoGasto = IdTipoGasto
    '                            registro.TipoGasto = TipoGasto

    '                            Unidad.Placa = IIf(Placa = "", Nothing, Placa)
    '                            registro.Unidad = Unidad

    '                            registro.Importe = TotalFila
    '                            registro.Descripcion = IIf(Trim(Descripcion) = "", Nothing, Trim(Descripcion))
    '                            registro.Observacion = IIf(Trim(Observacion) = "", Nothing, Trim(Observacion))

    '                            registro.CodUsu = Session.sCodUsu
    '                            registro.NomPc = Session.sNomPc
    '                            registro.DirIp = Session.sDirIp

    '                            oReembolsoCajaDetService.Insertar(registro)
    '                        End If
    '                    Next
    '                    MsgBox("Detalles Ingresados al Rembolso Nº :" + NumReembolso)
    '                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                End If
    '            Else
    '                MsgBox("No se presentan Detalles que ingresar, Verificar")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL GUARDAR DETALLES EN REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try      
    'End Sub

    'Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    '    Try
    '        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '            If ValidarCodigo() Then

    '                If dgvDatos.RowCount > 0 Then
    '                    Dim rows() As Janus.Windows.GridEX.GridEXRow
    '                    Dim Vacio As Integer = 0                'Número de detalles con Tipo de gasto vacio
    '                    Dim TipoGasto1 As Integer             'Valor de Tipo de Gasto
    '                    Dim DetIngresados As Integer = 0   'Cantidad de detalles ingresados

    '                    rows = dgvDatos.GetCheckedRows()
    '                    Dim row As Janus.Windows.GridEX.GridEXRow

    '                    If rows.Count > 0 Then

    '                        '=================Recorrido para verificar que todos los detalles tengan Tipo de Gasto=========
    '                        For Each row In rows
    '                            TipoGasto1 = IIf(row.Cells("IdTipoGasto").Text = "", 0, row.Cells("IdTipoGasto").Value)
    '                            If TipoGasto1 = 0 Then
    '                                Vacio = Vacio + 1
    '                            End If
    '                        Next
    '                        '===========================================================================

    '                        If Vacio > 0 Then 'Validamos si no hay algun detalle sin Tipo de Gasto
    '                            MsgBox("Debe ingresar los datos, Verificar")
    '                        Else

    '                            Dim IdGasto As Integer           'IdGato del Detalle
    '                            Dim IdGastoDet As Integer      'IdGastoDet del Detalle
    '                            Dim CodArea As String           'CodArea del Detalle
    '                            Dim IdTipoGasto As Integer     'IdTipoGasto del Detalle
    '                            Dim Placa As String               'Placa del Detalle
    '                            Dim Item As Integer                'Item del Detalle
    '                            Dim TotalFila As Double          'TotalFila del Detalle
    '                            Dim Descripcion As String       'Descripcion del Detalle
    '                            Dim Observacion As String      'Observacion del Detalle

    '                            '============== Recorrido para ingresar detalles de Solicitud a Reembolso ===============
    '                            For Each row In rows

    '                                IdGasto = row.Cells("IdGasto").Value
    '                                IdGastoDet = row.Cells("IdGastoDet").Value
    '                                CodArea = row.Cells("CodArea").Value
    '                                IdTipoGasto = row.Cells("IdTipoGasto").Value
    '                                Placa = row.Cells("Placa").Text
    '                                Item = CInt(row.Cells("Item").Text)
    '                                TotalFila = row.Cells("TotalFila").Value
    '                                Descripcion = row.Cells("Descripcion").Text
    '                                Observacion = row.Cells("Justificacion").Text

    '                                If Not (oReembolsoCajaDetService.BuscarGasto(IdGasto, IdGastoDet)) Then

    '                                    Dim registro As New ReembolsoCajaDetService.ReembolsoCajaDet
    '                                    Dim Reembolso As New ReembolsoCajaDetService.ReembolsoCaja
    '                                    Dim Area As New ReembolsoCajaDetService.Area
    '                                    Dim TipoGasto As New ReembolsoCajaDetService.TipoGasto
    '                                    Dim Unidad As New ReembolsoCajaDetService.Unidad
    '                                    Dim SolicitudGasto As New ReembolsoCajaDetService.SolicitudGasto
    '                                    Dim SolicitudGastoDet As New ReembolsoCajaDetService.SolicitudGastoDet

    '                                    registro.IdReembolsoDet = 0
    '                                    Reembolso.IdReembolso = IdReembolso
    '                                    registro.ReembolsoCaja = Reembolso

    '                                    SolicitudGasto.IdGasto = IdGasto
    '                                    SolicitudGastoDet.IdGastoDet = IdGastoDet
    '                                    SolicitudGastoDet.SolicitudGasto = SolicitudGasto
    '                                    registro.SolicitudGastoDet = SolicitudGastoDet

    '                                    registro.Item = Item
    '                                    Area.CodArea = CodArea
    '                                    registro.Area = Area
    '                                    TipoGasto.IdTipoGasto = IdTipoGasto
    '                                    registro.TipoGasto = TipoGasto

    '                                    Unidad.Placa = IIf(Placa = "", Nothing, Placa)
    '                                    registro.Unidad = Unidad

    '                                    registro.Importe = TotalFila
    '                                    registro.Descripcion = IIf(Trim(Descripcion) = "", Nothing, Trim(Descripcion))
    '                                    registro.Observacion = IIf(Trim(Observacion) = "", Nothing, Trim(Observacion))

    '                                    registro.CodUsu = Session.sCodUsu
    '                                    registro.NomPc = Session.sNomPc
    '                                    registro.DirIp = Session.sDirIp

    '                                    oReembolsoCajaDetService.Insertar(registro)

    '                                    DetIngresados = DetIngresados + 1
    '                                End If
    '                            Next
    '                            '========================================================================
    '                            If DetIngresados > 0 Then
    '                                MsgBox("Detalle(s) Ingresado(s) al Rembolso Nº :" + NumReembolso)
    '                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '                            End If
    '                        End If
    '                    Else
    '                        MsgBox("Debe seleccionar alguno de los detalles")
    '                    End If
    '                Else
    '                    MsgBox("No se presentan Detalles que ingresar, Verificar")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL GUARDAR DETALLES EN REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidarCodigo() Then
                    If dgvDatos.RowCount > 0 Then

                        Dim row As Janus.Windows.GridEX.GridEXRow
                        Dim Seleccionado As Integer = 0    'Valor de CheckBox
                        Dim TipoGasto1 As Integer             'Valor de Tipo de Gasto
                        Dim Vacio As Integer = 0                'Número de detalles con Tipo de gasto vacio
                        Dim PlacaVacio As Integer              'Número de detalles con Tipo de gasto Vehiculo que no tienen Placa
                        Dim CuentaVacio As Integer            'Número de detalles con Cuneta Contable vacio
                        Dim DetIngresados As Integer         'Número de Detalles ingresados


                        '========== Recorrido para contabilizar cuantos detalles estan seleccionados ========
                        For i = 0 To Me.dgvDatos.RowCount - 1
                            Me.dgvDatos.Row = i
                            row = Me.dgvDatos.GetRow()
                            If toBoolean(row.Cells("Procesar").Value) = True Then
                                Seleccionado = Seleccionado + 1
                            End If
                        Next
                        '==================================================================


                        If Seleccionado > 0 Then

                            '======= Recorrido para contabilizar cuantos detalles seleccionados no tienen tipo de gasto ======
                            For i = 0 To Me.dgvDatos.RowCount - 1
                                Me.dgvDatos.Row = i
                                row = Me.dgvDatos.GetRow()
                                TipoGasto1 = IIf(row.Cells("IdTipoGasto").Text = "", 0, row.Cells("IdTipoGasto").Value)
                                If toBoolean(row.Cells("Procesar").Value) = True And TipoGasto1 = 0 Then
                                    Vacio = Vacio + 1
                                End If
                            Next
                            '=========================================================================


                            '======= Recorrido para contabilizar cuantos detalles seleccionados no tienen Placa  y tienen tipo de gasto vehiculo ======
                            For i = 0 To Me.dgvDatos.RowCount - 1
                                Me.dgvDatos.Row = i
                                row = Me.dgvDatos.GetRow()
                                TipoGasto1 = IIf(row.Cells("IdTipoGasto").Text = "", 0, row.Cells("IdTipoGasto").Value)
                                If toBoolean(row.Cells("Procesar").Value) = True Then
                                    If (IsDBNull(row.Cells("Placa").Value) = True And oReembolsoCajaDetService.BuscarTipoVehiculo(TipoGasto1) = True) Then
                                        PlacaVacio = PlacaVacio + 1
                                    End If
                                End If
                            Next
                            '=========================================================================



                            If Vacio > 0 Then
                                MsgBox("Debe ingresar el Tipo de Gasto para todos los detalles, Verificar")
                            ElseIf PlacaVacio > 0 Then
                                MsgBox("Debe ingresar el nro. de Placa para los detalles con Tipo de Gasto Vehículo, Verificar")
                            Else
                                '============ Recorrido para ingresar detalle validando que este seleccionado===========

                                Dim IdGasto As Integer           'IdGasto del Detalle
                                Dim IdGastoDet As Integer      'IdGastoDet del Detalle
                                Dim CodArea As String           'CodArea del Detalle
                                Dim IdTipoGasto As Integer     'IdTipoGasto del Detalle
                                Dim Placa As String               'Placa del Detalle
                                Dim Item As Integer                'Item del Detalle
                                Dim TotalFila As Double          'TotalFila del Detalle
                                Dim Descripcion As String       'Descripcion del Detalle
                                Dim Observacion As String      'Observacion del Detalle
                                Dim Procesar As Boolean

                                For i = 0 To Me.dgvDatos.RowCount - 1
                                    Me.dgvDatos.Row = i
                                    row = Me.dgvDatos.GetRow()
                                    Procesar = toBoolean(row.Cells("Procesar").Value)
                                    If Procesar = True Then

                                        row = Me.dgvDatos.GetRow()
                                        IdGasto = toNumber(txtIdGasto.Text)
                                        IdGastoDet = row.Cells("IdGastoDet").Value
                                        CodArea = row.Cells("CodArea").Value
                                        IdTipoGasto = row.Cells("IdTipoGasto").Value
                                        Placa = row.Cells("Placa").Text
                                        Item = CInt(row.Cells("Item").Text)
                                        TotalFila = row.Cells("TotalFila").Value
                                        Descripcion = row.Cells("Descripcion").Text
                                        Observacion = row.Cells("Justificacion").Text

                                        If Not (oReembolsoCajaDetService.BuscarGasto(IdGasto, IdGastoDet)) Then
                                            Dim registro As New ReembolsoCajaDetService.ReembolsoCajaDet
                                            Dim Reembolso As New ReembolsoCajaDetService.ReembolsoCaja
                                            Dim Area As New ReembolsoCajaDetService.Area
                                            Dim TipoGasto As New ReembolsoCajaDetService.TipoGasto
                                            Dim Unidad As New ReembolsoCajaDetService.Unidad
                                            Dim SolicitudGasto As New ReembolsoCajaDetService.SolicitudGasto
                                            Dim SolicitudGastoDet As New ReembolsoCajaDetService.SolicitudGastoDet

                                            registro.IdReembolsoDet = 0
                                            Reembolso.IdReembolso = IdReembolso
                                            registro.ReembolsoCaja = Reembolso

                                            SolicitudGasto.IdGasto = IdGasto
                                            SolicitudGastoDet.IdGastoDet = IdGastoDet
                                            SolicitudGastoDet.SolicitudGasto = SolicitudGasto
                                            registro.SolicitudGastoDet = SolicitudGastoDet

                                            registro.Item = Item
                                            Area.CodArea = CodArea
                                            registro.Area = Area
                                            TipoGasto.IdTipoGasto = IdTipoGasto
                                            registro.TipoGasto = TipoGasto

                                            Unidad.Placa = IIf(Placa = "", Nothing, Placa)
                                            registro.Unidad = Unidad

                                            registro.Importe = TotalFila
                                            registro.Descripcion = IIf(Trim(Descripcion) = "", Nothing, Trim(Descripcion))
                                            registro.Observacion = IIf(Trim(Observacion) = "", Nothing, Trim(Observacion))

                                            registro.CodUsu = Session.sCodUsu
                                            registro.NomPc = Session.sNomPc
                                            registro.DirIp = Session.sDirIp

                                            If oReembolsoCajaDetService.Insertar(registro) > 0 Then
                                                DetIngresados = DetIngresados + 1
                                            End If

                                        End If
                                        '====================================================================                                     
                                    End If
                                Next

                                If DetIngresados > 0 Then
                                    MsgBox("Detalle(s) Ingresado(s) al Rembolso: Nº " + NumReembolso)
                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Else
                                    MsgBox("Los Detalles seleccionados ya fueron ingresados a un reembolso.")
                                End If

                            End If
                        Else
                            MsgBox("Debe seleccionar alguno de los detalles")
                        End If
                    Else
                        MsgBox("No se presentan Detalles que ingresar, Verificar")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DETALLES EN REEMBOLSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtIdGasto_TextChanged(sender As Object, e As EventArgs) Handles txtIdGasto.TextChanged

    End Sub
End Class