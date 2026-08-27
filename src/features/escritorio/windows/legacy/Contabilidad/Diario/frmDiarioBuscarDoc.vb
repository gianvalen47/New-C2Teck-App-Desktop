Imports System.ServiceModel
Public Class frmDiarioBuscarDoc

    '===========================Servicios====================================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oContabilidadDetService As New ContabilidadDetService.ContabilidadDetServiceClient

    '======================Declaración de Variables==============================   
    Public IdContabilidad As Integer

    Public dtDetalles As DataTable 'Documentos Seleccionados

    Private state_Search As Boolean
    Private dtDatos As DataTable
    Private dtTipDoc As DataTable
    Private dtTipDocumento As DataTable

    Private Sub frmBuscarPendientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmBuscarPendientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.ScrollBars = ScrollBars.Both
        dgvDatos.AutoGenerateColumns = False
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        txtPeriodo.Value = Today.Year
        cmbTipoLibro.Value = 14
        cmbTipoDoc.Value = 3
        txtPeriodo.Select()
    End Sub

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
            oContabilidadDetService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
        End Try
    End Sub




    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.ValueChanged, txtCodCuenta.TextChanged, cmbTipoLibro.ValueChanged, cmbTipoDoc.ValueChanged, txtSerieDoc.TextChanged, txtNumDoc.TextChanged, txtProveedor.TextChanged
        listaDatos()
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
            fila(4) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oContabilidadDetService.MostrarTipoDocumentoConta().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            dtTipDoc = Nothing


            '===================================TIPO DE LIBRO ===========================================
            dtTipDocumento = oContabilidadService.MostrarTipoLibros.Tables(0)
            'dtTipDocumento.Rows.InsertAt(getRowTodos1(dtMonedas), 0)            
            cmbTipoLibro.DataSource = dtTipDocumento
            cmbTipoLibro.DropDownList.DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.DisplayMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.ValueMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoLibro.DropDownList.Columns(0).DataMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoLibro.DropDownList.Columns(1).DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.Columns(2).DataMember = dtTipDocumento.Columns("DesLibro").ToString
            cmbTipoLibro.SelectedIndex = 0
            dtTipDocumento = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                oContabilidadService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(400)
                dtDatos = oContabilidadService.MostrarDocumentoLibros(Session.sCodEmp, cmbTipoLibro.Value, txtPeriodo.Value, txtCodCuenta.Text, cmbTipoDoc.Value, txtSerieDoc.Text, txtNumDoc.Text, txtProveedor.Text).Tables(0)
                dgvDatos.DataSource = dtDatos

                cIdContabilidadDet.DataPropertyName = dtDatos.Columns("IdContabilidadDet").ColumnName
                cIdCuenta.DataPropertyName = dtDatos.Columns("IdCuenta").ColumnName
                cCodCuenta.DataPropertyName = dtDatos.Columns("CodCuenta").ColumnName
                cIdDocumento.DataPropertyName = dtDatos.Columns("IdDocumento").ColumnName
                cSerDoc.DataPropertyName = dtDatos.Columns("SerDoc").ColumnName
                cTipMov.DataPropertyName = dtDatos.Columns("TipMov").ColumnName
                cNumDoc.DataPropertyName = dtDatos.Columns("NumDoc").ColumnName
                cIdProveedor.DataPropertyName = dtDatos.Columns("IdProveedor").ColumnName
                cDocumento.DataPropertyName = dtDatos.Columns("Documento").ColumnName
                cDesProv.DataPropertyName = dtDatos.Columns("Proveedor").ColumnName
                cFecDoc.DataPropertyName = dtDatos.Columns("Fecha").ColumnName
                cCodMon.DataPropertyName = dtDatos.Columns("CodMon").ColumnName
                cMontoSol.DefaultCellStyle.Format = "N2"
                cMontoSol.DataPropertyName = dtDatos.Columns("MontoSol").ColumnName
                cMontoDol.DefaultCellStyle.Format = "N2"
                cMontoDol.DataPropertyName = dtDatos.Columns("MontoDol").ColumnName
                'cFecVen.DataPropertyName = dtDatos.Columns("FecVen").ColumnName
                cSeleccion.DataPropertyName = dtDatos.Columns("Seleccion").ColumnName
                cIdCliente.DataPropertyName = dtDatos.Columns("IdCliente").ColumnName
                cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
                cCodJob.DataPropertyName = dtDatos.Columns("Codjob").ColumnName
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                CalcularAcumulado()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        'TextBox1.Select()
        dgvDatos.EndEdit()
        CalcularAcumulado()
    End Sub

    Private Sub CalcularAcumulado()
        Try

            Dim TotalSaldoUS As Double = 0
            Dim TotalSaldoNS As Double = 0

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbInsertar"), DataGridViewCheckBoxCell)

                If toBoolean(cellSelecion.Value) = True Then
                    TotalSaldoUS = TotalSaldoUS + toDouble(dgvDatos.Rows(i).Cells("cMontoDol").Value)
                    TotalSaldoNS = TotalSaldoNS + toDouble(dgvDatos.Rows(i).Cells("cMontoSol").Value)
                End If
            Next

            sslTotalSaldoNS.Text = "Total Monto Soles: " + TotalSaldoNS.ToString
            sslTotalSaldoUS.Text = "Total Monto Dolares: " + TotalSaldoUS.ToString
        Catch ex As Exception
            MsgBox("ERROR CALCULAR MONTOS ACUMULADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Insertar()
        Try
            If MsgBox("¿Está seguro de INSERTAR el(los) Doc(s) seleccionado(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvDatos.EndEdit()
                dgvDatos.Update()
                Dim dtTable As DataTable
                Dim rows As DataRow

                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1

                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbInsertar"), DataGridViewCheckBoxCell)

                    If toBoolean(cellSelecion.Value) = True Then
                        rows = dtTable.NewRow
                        rows(1) = dgvDatos.Rows(i).Cells("cIdContabilidadDet").Value
                        rows(2) = dgvDatos.Rows(i).Cells("cIdCuenta").Value
                        rows(3) = dgvDatos.Rows(i).Cells("cCodCuenta").Value
                        rows(4) = dgvDatos.Rows(i).Cells("cTipMov").Value
                        rows(5) = dgvDatos.Rows(i).Cells("cCodJob").Value
                        rows(6) = dgvDatos.Rows(i).Cells("cFecDoc").Value
                        rows(7) = dgvDatos.Rows(i).Cells("cIdDocumento").Value
                        rows(9) = dgvDatos.Rows(i).Cells("cSerDoc").Value
                        rows(10) = dgvDatos.Rows(i).Cells("cNumDoc").Value
                        rows(11) = dgvDatos.Rows(i).Cells("cIdProveedor").Value
                        rows(12) = dgvDatos.Rows(i).Cells("cIdCliente").Value
                        rows(13) = dgvDatos.Rows(i).Cells("cIdPer").Value
                        rows(14) = dgvDatos.Rows(i).Cells("cDocumento").Value
                        rows(15) = dgvDatos.Rows(i).Cells("cDesProv").Value
                        rows(16) = dgvDatos.Rows(i).Cells("cCodMon").Value
                        rows(17) = dgvDatos.Rows(i).Cells("cMontoDol").Value
                        rows(18) = dgvDatos.Rows(i).Cells("cMontoSol").Value
                        rows(19) = dgvDatos.Rows(i).Cells("cSeleccion").Value

                        dtTable.Rows.Add(rows)
                    End If
                Next
                If dtTable.Rows.Count = 0 Then
                    MsgBox("¡Debe seleccionar alguno de los Documentos...!", MsgBoxStyle.Information, "No hay datos")
                Else

                    Dim IdProveedor As Int64
                    Dim IdPersona As Int64
                    Dim IdCliente As Int64
                    Dim IdContabilidadDet As Int64
                    Dim dtCentroCosto As DataTable
                    For Each Fila As DataRow In dtTable.Rows
                        Dim registro As New ContabilidadDetService.ContabilidadDet
                        Dim Contabilidad As New ContabilidadDetService.Contabilidad
                        Dim CuentaContable As New ContabilidadDetService.CuentaContable
                        Dim CuentaContableDest As New ContabilidadDetService.CuentaContable
                        'Dim CentroCosto As New ContabilidadDetService.CentroCosto
                        'Dim Area As New ContabilidadDetService.Area
                        Dim Job As New ContabilidadDetService.Job
                        Dim Proveedor As New ContabilidadDetService.Proveedor
                        Dim Persona As New ContabilidadDetService.Persona
                        Dim TipoDocumento As New ContabilidadDetService.TipoDocumento
                        Dim cliente As New ContabilidadDetService.Cliente

                        registro.IdContabilidadDet = 0
                        Contabilidad.IdContabilidad = IdContabilidad
                        registro.Contabilidad = Contabilidad

                        CuentaContable.IdCuenta = Fila.Item("IdCuenta")  'oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                        CuentaContable.CodCuenta = Fila.Item("CodCuenta")
                        registro.CuentaContable = CuentaContable

                        Job.CodJob = IIf(IsDBNull(Fila.Item("CodJob")), Nothing, Fila.Item("CodJob"))
                        registro.Job = Job
                        'Area.CodArea = cmbArea.Value
                        'CentroCosto.CodCentro = cmbCentroCosto.Value
                        'CentroCosto.Area = Area
                        'registro.CentroCosto = CentroCosto

                        registro.TipMov = IIf(Fila.Item("TipMov") = "D", "H", "D") 'cmbTipoMov.Value
                        CuentaContableDest.IdCuenta = Nothing
                        CuentaContableDest.CodCuenta = Nothing  'IIf(txtCodCuentaDest.Text = "", Nothing, txtCodCuentaDest.Text)
                        registro.CuentaContableDest = CuentaContableDest

                        TipoDocumento.IdDocumento = Fila.Item("IdDocumento")
                        registro.TipoDocumento = TipoDocumento
                        registro.SerDoc = IIf(Fila.Item("SerDoc") = "", Nothing, Fila.Item("SerDoc"))
                        registro.NumDoc = Fila.Item("NumDoc")
                        IdProveedor = IIf(IsDBNull(Fila.Item("IdProveedor")), 0, Fila.Item("IdProveedor"))
                        Proveedor.IdProveedor = IIf(toNumber(IdProveedor) = 0, Nothing, IdProveedor)
                        registro.Proveedor = Proveedor

                        IdCliente = IIf(IsDBNull(Fila.Item("IdCliente")), 0, Fila.Item("IdCliente"))
                        cliente.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
                        registro.Cliente = cliente

                        IdPersona = IIf(IsDBNull(Fila.Item("IdPer")), 0, Fila.Item("IdPer"))
                        Persona.IdPer = IIf(toNumber(IdPersona) = 0, Nothing, IdPersona)
                        registro.Persona = Persona
                        registro.MontoSol = Fila.Item("MontoSol")
                        registro.MontoDol = Fila.Item("MontoDol")

                        registro.Observacion = Nothing

                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.NomPc = Session.sNomPc
                        registro.FecReg = Today

                        IdContabilidadDet = oContabilidadDetService.Insertar(registro)

                        '/////////////INSERTAR CENTRO DE COSTO////////////
                        dtCentroCosto = oContabilidadDetService.MostrarCentroCosto(Fila.Item("IdContabilidadDet")).Tables(0)
                        oContabilidadDetService.InsertarCentroCosto(IdContabilidadDet, IdContabilidad, dtCentroCosto, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        '/////////////////////////////////////////////////

                    Next


                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Finalizar()
                    Me.Close()

                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionarTodos.Enabled = False
            cbSeleccionarTodos.Enabled = False
            miNinguno.Enabled = False
            miInsertar.Enabled = False
            biInsertar.Enabled = False
        Else
            miSeleccionarTodos.Enabled = True
            cbSeleccionarTodos.Enabled = True
            miNinguno.Enabled = True
            miInsertar.Enabled = True
            biInsertar.Enabled = True
        End If
    End Sub



    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtPeriodo.KeyPress _
                       , txtCodCuenta.KeyPress _
                       , txtSerieDoc.KeyPress _
                       , txtNumDoc.KeyPress _
                       , cmbTipoDoc.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            frm.txtCodCuenta.Text = txtCodCuenta.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta.Text = frm.codigo
                    'lblDesCuenta.Text = frm.descripcion
                Else
                    txtCodCuenta.Text = ""
                    'lblDesCuenta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(15).Value = True
        Next
        CalcularAcumulado()
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(15).Value = False
        Next
        CalcularAcumulado()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        listaDatos()
    End Sub

    Private Sub biInsertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biInsertar.Click, miInsertar.Click
        Insertar()
    End Sub

    Private Sub miSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSalir.Click, biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbSeleccionarTodos.CheckedChanged
        If cbSeleccionarTodos.Checked = True Then
            For Each fila As DataGridViewRow In dgvDatos.Rows
                fila.Cells(15).Value = True
            Next
        Else
            For Each fila As DataGridViewRow In dgvDatos.Rows
                fila.Cells(15).Value = False
            Next
        End If
        CalcularAcumulado()
    End Sub
End Class
