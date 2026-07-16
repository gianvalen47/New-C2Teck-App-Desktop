Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmJob_ListadoRepuestos

    Public CodJob As String
    Public DesCli As String
    Public ModMer As String
    Public IdCliente As String
    Private dtDatos As DataTable
    Private dtCotizacion As DataTable
    Private dtRubro As DataTable
    Private oJobService As New JobService.JobServiceClient
    Private oJobRepuestoService As New JobRepuestoService.JobRepuestoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient


    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer

    Private Sub frmJob_ListadoRepuestos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oJobRepuestoService.Close()
            oMercaderiaService.Close()
            oSeguridadService.Close()

        Catch ex As TimeoutException
            oJobService.Abort()
            oJobRepuestoService.Abort()
            oMercaderiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oJobRepuestoService.Abort()
            oMercaderiaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmJob_ListadoRepuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_ListadoRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        lblNumJob.Text = CodJob
        lblCliente.Text = DesCli
        lblMotor.Text = ModMer
        llenarCombos()
        If oJobService.Estado(lblNumJob.Text) = 6 Or oJobService.Regularizar(CodJob) = True Then
            Activar()
        Else
            Desactivar()
        End If
        listaDatos()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= RUBRO ==============================================
            dtRubro = oJobRepuestoService.MostrarRubros.Tables(0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubro = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub Activar()
        btnBuscarMercaderia.Enabled = True
        btnGuardar.Enabled = True

        txtCodMer.ReadOnly = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        txtCantidad.ReadOnly = False
        txtCantidad.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window

        txtCodMer.Focus()
    End Sub

    Private Sub Desactivar()
        btnBuscarMercaderia.Enabled = False
        btnGuardar.Enabled = False

        txtCodMer.ReadOnly = True
        txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtCantidad.ReadOnly = True
        txtCantidad.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar el Codigo de la Mercaderia ")
                txtCodMer.Focus()
                Return False
            ElseIf utils.toBlank(lblCliente.Text) = "" Then
                MsgBox("Debe ingresar la OT")
                Return (False)
            ElseIf utils.toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción de la Mercaderia")
                txtDescripcion.Focus()
                Return False
            ElseIf utils.toNumber(txtCantidad.Text) = 0 Then
                MsgBox("Debe Ingresar la Cantidad no puede ser Cero ")
                txtCantidad.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        'Try
        Dim frm1 As New frmBuscarMercaderia
        frm1.CodRub = "04"
        If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm1.codigo
            txtDescripcion.Text = frm1.descripcion
            txtCodMer_KeyDown(sender, New System.Windows.Forms.KeyEventArgs(13))

        End If
        'txtCodMer.Select()
        'Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If ValidaCampos() Then
                Dim registro As New JobRepuestoService.JobRepuesto
                Dim job As New JobRepuestoService.Job
                Dim rubro As New JobRepuestoService.RubroServicios

                rubro.IdRubro = cmbRubro.Value
                job.CodJob = lblNumJob.Text
                registro.Job = job
                registro.CodMer = txtCodMer.Text
                registro.RubroServicios = rubro
                registro.DesMer = txtDescripcion.Text
                registro.CanMer = txtCantidad.Value
                'registro.CanAte = 0
                'registro.CanPen = 5
                registro.Activo = cbActivo.Checked
                registro.FecReg = Today
                registro.Observacion = utils.toNull(txtObservacion.Text)
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                Insertar(registro)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As JobRepuestoService.JobRepuesto)
        Try
            Dim estado_process As Boolean
            estado_process = oJobRepuestoService.Insertar(registro)

            If estado_process Then
                MsgBox("Se Ingreso el Repuesto Correctamente ")

                listaDatos()
                limpiarDatos()
                txtCodMer.Focus()
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador de TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL AGREGAR LOS REPUESTOS : " + ex.Message)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            'dtDatos = oJobService.MostrarRepuestos(CodJob).Tables(0)
            dtDatos = oJobRepuestoService.MostrarPorRubro(CodJob, cmbRubro.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            EnableOptions()
            lblcontador.Text = dgvDatos.RowCount
            lblSumaAtend.Text = ""
            If dgvDatos.RowCount <> 0 Then
                SumatoriaAtendido()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub SumatoriaAtendido()
        lblSumaAtend.Text = ""
        Dim SumaAten As Integer = 0
        For Each Fila As DataRow In dtDatos.Rows
            If (Fila.Item("Canate")) = 0 Then
                SumaAten = SumaAten + 1
            End If
        Next
        lblSumaAtend.Text = SumaAten
    End Sub

    Private Sub EnableOptions()
        If dgvDatos.RowCount <> 0 Then
            btnAgregarPlantilla.Enabled = False
            miPlantilla.Enabled = False
            miMostrar.Enabled = True
            biImprimir.Enabled = True
            miBuscar.Enabled = True
            biFormatoExcel.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miFormatoExcel.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miListaRepuestos.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
        Else
            btnAgregarPlantilla.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miPlantilla.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miPlantillaMateriales.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miMostrar.Enabled = False
            biImprimir.Enabled = False
            miBuscar.Enabled = False
            biFormatoExcel.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miFormatoExcel.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
            miListaRepuestos.Enabled = IIf(oJobService.Estado(lblNumJob.Text) = 6, True, False)
        End If
    End Sub

    Private Sub limpiarDatos()
        Try
            txtCodMer.Text = ""
            txtDescripcion.Text = ""
            txtCantidad.Text = ""
            cbActivo.Checked = True
            txtObservacion.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows
            If row.Cells("CodMer").Value = codigo Then
                'If row.Cells("CodMer").Value.ToString = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
            dgvDatos.Select()
        Next
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then
                Dim CodMerImp As String
                CodMerImp = dgvDatos.CurrentRow.Cells("CodMer").Value

                If MsgBox("¿Estás Seguro de ELIMINAR el Detalle Seleccionado?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim estado_process As Boolean
                    estado_process = oJobRepuestoService.Borrar(Trim(lblNumJob.Text), CodMerImp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Elimino Correctamente")
                        listaDatos()
                    Else
                        MsgBox("Error en el Proceso, Comunicarse con el Admninistrador del Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles dgvDatos.RowDoubleClick
        Modificar()
    End Sub

    Private Sub Modificar()

        Dim frm As New frmJob_ModificarRepuestos
        frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
        frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Value
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            listaDatos()
            RowPossesion(dgvDatos, frm.CodMer)
        End If

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPlantilla.Click, miPlantilla.Click
        Dim frm As New frmJob_AgregarPlantilla

        If dgvDatos.RowCount < 1 Then

            frm.CodJob = CodJob
            frm.IdCliente = IdCliente

            'frm.IdLocacion = 
            'frm.Text = "Agregar Plantilla a la cotización Nº" & txtNumCot.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
        Else
            MsgBox("No puede haber ninguna Mercaderia en la grilla")
        End If
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        Dim codigo As String = ""
        Try
            If e.KeyCode = Keys.Enter Then
                If oMercaderiaService.Buscar(txtCodMer.Text, Session.sCodEmp) Then
                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                    Mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)

                    txtCodMer.Text = Mercaderia.CodMer
                    txtDescripcion.Text = Mercaderia.DesMer1
                    txtDescripcion.Focus()
                    'MsgBox("El Código Ingresado existe en Almacén, Verifique")

                    'Dim i As Integer
                    'For i = 0 To dgvDatos.RowCount - 1
                    '    If txtCodMer.Text = dgvDatos.CurrentRow.Cells("CodMer").Value Then
                    '        MsgBox("El Código Ingresado existe en la Lista")
                    '        If dgvDatos.RowCount <> 0 Then
                    '            codigo = txtCodMer.Text
                    '            RowPossesion(dgvDatos, codigo)
                    '        End If
                    '    Else
                    '        txtCantidad.Focus()
                    '    End If
                    'Next
                Else
                    MsgBox("El Código Ingresado no existe en Almacén, Verifique")
                    txtCodMer.Text = ""
                    txtDescripcion.Text = ""
                    txtCantidad.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA MERCADERIA : " + ex.Message)
        End Try
    End Sub

    Private Sub miBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miBuscar.Click
        BuscarDetalle()
    End Sub

    Private Sub BuscarDetalle()
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows

                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then

                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1

                        Exit For
                    End If
                Next
                'RowPossesion(dgvDatos, dtDatos, "CodMer", frm.codigoDetalle)
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, btnActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim CodMerAct As String = ""
        If dgvDatos.RowCount > 0 Then
            CodMerAct = dgvDatos.CurrentRow.Cells("CodMer").Value
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And CodMerAct.Trim.Length > 0 Then
            RowPossesion(dgvDatos, CodMerAct)
        End If
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        Modificar()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJobRepuestos

            dtReporte = oJobService.MostrarRepuestos(CodJob).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("pMotor", lblMotor.Text)
                reporte.SetParameterValue("pCliente", lblCliente.Text)

                forma.Text = "Listado de Repuestos"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub cmbRubro_ValueChanged(sender As Object, e As EventArgs) Handles cmbRubro.ValueChanged
        listaDatos()
    End Sub

    Private Sub miPlantillaMateriales_Click(sender As Object, e As EventArgs) Handles miPlantillaMateriales.Click

        Dim frm As New frmJob_AgregarPlantillaMateriales
        If dgvDatos.RowCount < 1 Then

            frm.CodJob = CodJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If
        Else
            MsgBox("No puede haber ninguna Mercaderia en la grilla")
        End If
    End Sub

    Private Sub biFormatoExcel_Click(sender As Object, e As EventArgs) Handles biFormatoExcel.Click, miFormatoExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cant", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodRubro", Type.GetType("System.String")))

        'dtExcel.Rows.Add(New Object() {"", "", "", Date.Today, "", "", "", "0", "0", "0", "0.00", Date.Today, ""})
        dtExcel.Rows.Add(New Object() {"", "", "0", "", ""})
        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If

    End Sub

    Private Sub miListaRepuestos_Click(sender As Object, e As EventArgs) Handles miListaRepuestos.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If

    End Sub

    Private Sub CargadoFinal()


        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            'If dgvDatos.RowCount >= 280 Then
            '    MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            'Else
            InsertarMasivo()
            'End If
        End If

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    'Private Sub InsertarMasivo()
    '    Try
    '        'Dim contador As String = ""

    '        For i As Integer = 0 To DataGridView1.Rows.Count - 2
    '            If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

    '                Dim registro As New JobRepuestoService.JobRepuesto
    '                Dim job As New JobRepuestoService.Job
    '                Dim rubro As New JobRepuestoService.RubroServicios

    '                rubro.IdRubro = DataGridView1.Item(4, i).Value
    '                job.CodJob = lblNumJob.Text
    '                registro.Job = job
    '                registro.CodMer = Trim(DataGridView1.Item(0, i).Value)
    '                registro.RubroServicios = rubro

    '                If oMercaderiaService.Buscar(DataGridView1.Item(0, i).Value, Session.sCodEmp) Then
    '                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
    '                    Mercaderia = oMercaderiaService.Obtener(DataGridView1.Item(0, i).Value, Session.sCodEmp)

    '                    If Mercaderia.DesMer1 = "" Then
    '                        registro.DesMer = DataGridView1.Item(1, i).Value
    '                    Else
    '                        registro.DesMer = Mercaderia.DesMer1
    '                    End If
    '                Else
    '                    registro.DesMer = DataGridView1.Item(1, i).Value
    '                End If

    '                registro.CanMer = toNumber(DataGridView1.Item(2, i).Value)
    '                registro.Activo = True
    '                registro.FecReg = Today

    '                Dim observacion As String = ""
    '                If IsDBNull(DataGridView1.Item(3, i).Value) Then
    '                    observacion = ""
    '                Else observacion = CStr(DataGridView1.Item(3, i).Value)
    '                End If

    '                registro.Observacion = observacion
    '                registro.CodUsu = Session.sCodUsu
    '                registro.NomPc = Session.sNomPc
    '                registro.DirIp = Session.sDirIp

    '                Dim estado_process As Integer
    '                estado_process = oJobRepuestoService.Insertar(registro)
    '                'contador = "paso"

    '                If estado_process > 0 Then

    '                End If

    '            End If
    '        Next

    '        'If contador = "" Then
    '        MsgBox("Se inserto el listado correctamente", MsgBoxStyle.Information)
    '        'End If
    '        listaDatos()

    '    Catch ex As Exception
    '        MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
    '        listaDatos()
    '    End Try
    'End Sub

    Private Sub InsertarMasivo()
        Try
            'Dim contador As String = ""

            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim registro As New JobRepuestoService.JobRepuesto
                    Dim job As New JobRepuestoService.Job
                    Dim rubro As New JobRepuestoService.RubroServicios

                    'Dim dtDatosTemp As DataTable
                    'dtDatosTemp = oJobRepuestoService.MostrarPorRubro(CodJob, 1).Tables(0)



                    rubro.IdRubro = DataGridView1.Item(4, i).Value
                    job.CodJob = lblNumJob.Text
                    registro.Job = job
                    registro.CodMer = Trim(DataGridView1.Item(0, i).Value)
                    registro.RubroServicios = rubro

                    If oMercaderiaService.Buscar(DataGridView1.Item(0, i).Value, Session.sCodEmp) Then
                        Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                        Mercaderia = oMercaderiaService.Obtener(DataGridView1.Item(0, i).Value, Session.sCodEmp)

                        If Mercaderia.DesMer1 = "" Then
                            registro.DesMer = DataGridView1.Item(1, i).Value
                        Else
                            registro.DesMer = Mercaderia.DesMer1
                        End If
                    Else
                        registro.DesMer = DataGridView1.Item(1, i).Value
                    End If

                    registro.CanMer = toNumber(DataGridView1.Item(2, i).Value)
                    registro.Activo = True
                    registro.FecReg = Today

                    Dim observacion As String = ""
                    If IsDBNull(DataGridView1.Item(3, i).Value) Then
                        observacion = ""
                    Else observacion = CStr(DataGridView1.Item(3, i).Value)
                    End If

                    registro.Observacion = observacion
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    Dim estado_process As Integer

                    'If dtDatos.Rows.Count > 0 Then

                    '    For Each row As DataRow In dtDatos.Rows

                    '        If Trim(DataGridView1.Item(0, i).Value) = row("CodMer").ToString Then

                    '            registro.CanMer = toNumber(row("CanMer").ToString) + toNumber(DataGridView1.Item(2, i).Value)
                    '            estado_process = oJobRepuestoService.Actualizar(registro)

                    '        Else

                    'estado_process = oJobRepuestoService.Insertar(registro)

                    '        End If

                    '    Next

                    If VerificarRepetido(Trim(DataGridView1.Item(0, i).Value), toNumber(DataGridView1.Item(4, i).Value)) = False Then

                        estado_process = oJobRepuestoService.Insertar(registro)
                        'contador = "paso"
                    Else

                        registro.CanMer = toNumber(DataGridView1.Item(2, i).Value) + ObtenerCantidad(Trim(DataGridView1.Item(0, i).Value), toNumber(DataGridView1.Item(4, i).Value))

                        estado_process = oJobRepuestoService.Actualizar(registro)

                    End If

                    If estado_process > 0 Then

                        End If

                    End If
            Next

            'If contador = "" Then
            MsgBox("Se inserto el listado correctamente", MsgBoxStyle.Information)
            'End If
            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
            listaDatos()
        End Try
    End Sub


    Private Function VerificarRepetido(codigo As String, idrubro As Integer) As Boolean
        Try

            Dim contador As Integer = 0
            dtDatos = oJobRepuestoService.MostrarPorRubro(CodJob, idrubro).Tables(0)

            If dtDatos.Rows.Count > 0 Then

                For Each row As DataRow In dtDatos.Rows

                    If Trim(codigo) = row("CodMer").ToString Then
                        contador = +1
                    Else
                        'contador = 0
                    End If
                Next

                If contador > 0 Then
                    Return True
                Else
                    Return False
                End If

            Else
                Return False

            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Function ObtenerCantidad(codigo As String, idrubro As Integer) As Integer
        Try

            dtDatos = oJobRepuestoService.MostrarPorRubro(CodJob, idrubro).Tables(0)

            For Each row As DataRow In dtDatos.Rows

                If Trim(codigo) = row("CodMer").ToString Then

                    Return toNumber(row("CanMer").ToString)

                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function


End Class