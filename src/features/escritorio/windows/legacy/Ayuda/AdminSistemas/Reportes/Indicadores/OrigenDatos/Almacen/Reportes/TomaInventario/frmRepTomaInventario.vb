Imports System.Data.OleDb
Imports System.IO
Imports System.IO.FileInfo
Imports System.ServiceModel

Public Class frmRepTomaInventario
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient
    Private oModeloService As New ModeloService.ModeloServiceClient

    Private dtAlmacenes As DataTable
    Private dtoficinas As DataTable
    Private dtMovimientos As DataTable
    Private dtTiposMotores As DataTable
    Private dtClases As DataTable
    Private dtRubros As DataTable
    Private dtModelos As DataTable
    Private dtExpCodBar As DataTable
    Private codMar As String
    Private codApl As String
    Private TipUbic As String


    Private Sub frmRepTomaInventario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oMaestro.Close()
            oTipoMotorService.Close()
            oModeloService.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
            oTipoMotorService.Abort()
            oModeloService.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
            oTipoMotorService.Abort()
            oModeloService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepTomaInventario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmRepTomaInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function
    Private Function getRowMotores(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ===============================================
            dtoficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtoficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtoficinas = Nothing
            '======================================= CLASES ================================================
            dtClases = oMaestro.MostrarClaseMerca.Tables(0)
            dtClases.Rows.InsertAt(getRowTodos(dtClases), 0)
            cmbIdClase.DataSource = dtClases
            cmbIdClase.DropDownList.DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.DisplayMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.ValueMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(0).DataMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(1).DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.SelectedIndex = 0
            dtClases = Nothing
            '======================================= RUBROS ================================================
            dtRubros = oMaestro.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing
            '======================================= MODELOS ================================================
            dtModelos = oModeloService.Mostrar.Tables(0)
            dtModelos.Rows.InsertAt(getRowMotores(dtModelos), 0)
            cmbModMer.DataSource = dtModelos
            cmbModMer.DropDownList.DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.DisplayMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.ValueMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(0).DataMember = dtModelos.Columns("ModMer").ToString
            cmbModMer.DropDownList.Columns(1).DataMember = dtModelos.Columns("Descripcion").ToString
            cmbModMer.SelectedIndex = 0
            cmbModMer.Text = "(Todos)"
            dtModelos = Nothing
            '====================================== Tipo Motor =======================================================
            dtTiposMotores = oTipoMotorService.Mostrar.Tables(0)
            dtTiposMotores.Rows.InsertAt(getRowMotores(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            cmbTipMot.Text = "(Todos)"
            dtTiposMotores = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepTomaInventario
            Dim dtReporte As New DataView

            dtReporte = oLocacionMercaderiaService.ReporteTomaInventario(txtFecha.Text, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), txtUbiMer.Text, cmbIdClase.Value, TipUbic, IIf(cmbCodRub.Value = "(Todos)", "", cmbCodRub.Value), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), IIf(cmbModMer.Text = "(Todos)", "", cmbModMer.Value), IIf(cbUbicacion.Checked = True, 2, 1), IIf(rbReman.Checked = True, "1", "0")).Tables(0).DefaultView
            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        dtReporte.RowFilter = "Stock <> 0"
                    ElseIf rbceros.Checked Then
                        dtReporte.RowFilter = "Stock = 0"
                    ElseIf rbpositivos.Checked Then
                        dtReporte.RowFilter = "Stock > 0"
                    ElseIf rbnegativos.Checked Then
                        dtReporte.RowFilter = "Stock < 0"
                    ElseIf rbbajominimo.Checked Then
                        dtReporte.RowFilter = "Stock < MinMer"
                    ElseIf rbbajomaximo.Checked Then
                        dtReporte.RowFilter = "Stock < MaxMer"
                    ElseIf rbSobFal.Checked Then
                        'dtReporte.RowFilter = ""
                    End If
                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizo la exportación correctamente")
                    End If
                ElseIf rbExportarCodBarra.Checked Then
                    If cmbOficinas.Value = 0 Then
                        MsgBox("Selecccione una  Locación, tenga cuidado ...!!!")
                    Else
                        dtExpCodBar = oLocacionMercaderiaService.MostrarCodigoBarras(cmbOficinas.Value).Tables(0)
                        If dtExpCodBar.Rows.Count = 0 Then
                            MsgBox("No hay Datos para Exportar ...!!!")
                        Else
                            ExportaDT_DBF(dtExpCodBar)
                        End If
                    End If
                Else
                    'If cbUbicacion.Checked Then
                    '    dtReporte.Sort = "UbiMer Asc "
                    'End If
                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        dtReporte.RowFilter = "Stock <> 0"
                    ElseIf rbceros.Checked Then
                        dtReporte.RowFilter = "Stock = 0"
                    ElseIf rbpositivos.Checked Then
                        dtReporte.RowFilter = "Stock > 0"
                    ElseIf rbnegativos.Checked Then
                        dtReporte.RowFilter = "Stock < 0"
                    ElseIf rbbajominimo.Checked Then
                        dtReporte.RowFilter = "Stock < MinMer"
                    ElseIf rbbajomaximo.Checked Then
                        dtReporte.RowFilter = "Stock < MaxMer"
                    ElseIf rbSobFal.Checked Then
                        'dtReporte.RowFilter = ""
                    End If

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Toma de Inventario"
                    If rbSinStock.Checked Then
                        reporte.SetParameterValue("Stock", "")
                        reporte.SetParameterValue("Fecha", txtFecha.Text)
                        reporte.SetParameterValue("Marca", txtMarca.Text)
                        reporte.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    ElseIf rbConStock.Checked Then
                        reporte.SetParameterValue("Stock", "a")
                        reporte.SetParameterValue("Fecha", txtFecha.Text)
                        reporte.SetParameterValue("Marca", txtMarca.Text)
                        reporte.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    End If
                    reporte.SetParameterValue("Clase", cmbIdClase.Text)
                    reporte.SetParameterValue("Fecha", txtFecha.Text)
                    reporte.SetParameterValue("Marca", txtMarca.Text)
                    reporte.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    reporte.SetParameterValue("Modelo", cmbModMer.Value)
                    reporte.SetParameterValue("TipoMotor", cmbTipMot.Value)
                    reporte.SetParameterValue("Ubicacion", txtUbiMer.Text)

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepTomaInventario.xml")
                    forma.ShowDialog()
                    End If              
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
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
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged

    End Sub

    Private Sub btnBuscaMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbMarca.Checked = False
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            codMar = frm.codigo
        End If
    End Sub

    Private Sub btnBuscarAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAplicacion.Click
        Dim frm As New frmBuscarAplicacion
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbAplicacion.Checked = False
            txtAplicacion.Text = frm.descripcion
            txtAplicacion.BackColor = System.Drawing.SystemColors.Control
            codApl = frm.codigo
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        MostrarReporte()
    End Sub

    Private Sub rbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMarca.CheckedChanged
        txtMarca.Text = ""
    End Sub

    Private Sub rbAplicacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAplicacion.CheckedChanged
        txtAplicacion.Text = ""
    End Sub

    Private Sub rbTodosUbi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodosUbi.CheckedChanged, rbSinUbi.CheckedChanged, rbUbi.CheckedChanged
        If rbTodosUbi.Checked Then
            TipUbic = 1
            txtUbiMer.Text = ""
            txtUbiMer.ReadOnly = True
            txtUbiMer.BackColor = System.Drawing.SystemColors.Control
        ElseIf rbSinUbi.Checked Then
            TipUbic = 2
            txtUbiMer.Text = ""
            txtUbiMer.ReadOnly = True
            txtUbiMer.BackColor = System.Drawing.SystemColors.Control
        ElseIf rbUbi.Checked Then
            TipUbic = 3
            txtUbiMer.ReadOnly = False
            txtUbiMer.BackColor = System.Drawing.SystemColors.Window
            txtUbiMer.Select()
        End If
    End Sub

    Public Function ExportaDT_DBF(ByVal dt As DataTable) As Integer
        ' Comprobación de parámetros
        If (dt Is Nothing) Then _
            Throw New ArgumentNullException()
        ' Indicamos el atributo 'añadido' a todos los registros
        ' del objeto DataTable.
        For Each row As DataRow In dt.Rows
            row.SetAdded()
        Next

        Try
            Dim cnn As New OleDbConnection( _
                "Provider=VFPOLEDB.1;" & "Data Source=D:\PSION;" & _
                "Extended Properties='dBASE IV;'")

            'Otra cadena de Conexion que no sirve porque deja los campos Int a Numeric(20,5)

            'Dim cnn As New OleDbConnection( _
            '    "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=D:\PSION;" & _
            '    "Extended Properties='dBASE IV;'")


            Dim n As Integer = CreateDbf(dt, dt.TableName, cnn)

            If n > 0 Then
                MsgBox("Se realizó la exportación correctamente ")
            End If

            Return n

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Exportar los Datos")
        End Try

    End Function

    Private Sub DeleteTable()
        Dim FileToDelete As String
        FileToDelete = "D:\PSION\MERCA.DBF"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
    End Sub

    Private Function CreateDbf(ByVal dt As DataTable, _
                                  ByVal tableName As String, _
                                  ByVal cnn As OleDbConnection) As Integer
        ' Verifico los valores pasados.

        If (dt Is Nothing) Then _
            Throw New ArgumentNullException("dt", _
                "El objeto no es válido")

        If (String.IsNullOrEmpty(tableName)) Then _
            Throw New ArgumentNullException("tableName", _
                "No se ha especificado el nombre de la tabla.")

        If (cnn Is Nothing) Then _
            Throw New ArgumentNullException("cnn", _
                "El objeto Connection no es válido.")

        Dim sql As New System.Text.StringBuilder(256)

        Try
            '' ''sql.Append("CREATE TABLE " & tableName & "(")

            '' ''For Each dc As DataColumn In dt.Columns
            '' ''    ' obtenemos el tipo de dato de la columna
            '' ''    sql.Append(GetDataTypeSql(dc))
            '' ''Next
            ' '' '' Reemplazo la última coma por el cierre de paréntesis
            ' '' ''
            '' ''sql.Replace(","c, ")"c, sql.Length - 1, 1)

            ''sql.Append("CREATE TABLE DESCARGAR([CODIGO] bigint, [CONCEPTO] int, [IMPORTE] Double)")

            DeleteTable()

            Using cnn

                Dim cmd As OleDbCommand = cnn.CreateCommand()

                cmd.CommandText = ("CREATE TABLE MERCA([Codigo] char(22), [CodMer] char(22), [DesMer1] char(28), [UbiMer] char(18), [SalAct] Numeric )")

                cnn.Open()

                cmd.ExecuteNonQuery()

                'cmd.CommandText = String.Format("SELECT * FROM [{0}]", tableName)

                cmd.CommandText = String.Format("SELECT * FROM MERCA")

                Dim da As New OleDbDataAdapter(cmd)

                Dim cb As New OleDbCommandBuilder(da)

                cb.QuotePrefix = "["
                cb.QuoteSuffix = "]"

                da.InsertCommand = cb.GetInsertCommand()

                Return da.Update(dt)

            End Using

        Catch ex As Exception
            Throw

        Finally
            sql = Nothing

        End Try

    End Function

    Private Function GetDataTypeSql(ByVal dc As DataColumn) As String

        Dim columnName As String = dc.ColumnName
        Dim dataType As String
        Dim maxLength As Int32

        Select Case dc.DataType.Name
            Case "Boolean"
                dataType = "bit"

            Case "Byte", "SByte"
                dataType = "tinyint"

            Case "Char"
                dataType = "char"
                maxLength = 30
                'maxLength = dc.MaxLength

            Case "DateTime"
                dataType = "datetime"

            Case "Decimal"
                dataType = "decimal (18, 2)"

            Case "Double"
                dataType = "real"

            Case "Int16", "UInt16"
                dataType = "smallint"

            Case "Numeric"
                dataType = "NUMERIC (10,0)"

            Case "Int32", "UInt32"
                dataType = "int"

            Case "Int64", "UInt64"
                dataType = "bigint"

            Case "Object", "Byte[]"
                dataType = "image"

            Case "Single"
                dataType = "float"

            Case Else   ' String
                If (dc.MaxLength = 536870910) Then
                    dataType = "memo"
                Else
                    dataType = "nvarchar"
                    maxLength = dc.MaxLength
                End If

        End Select

        If (maxLength > 0) Then
            Return String.Format("[{0}] {1} ({2}),", columnName, dataType, maxLength)
        Else
            Return String.Format("[{0}] {1},", columnName, dataType)
        End If
    End Function    
End Class
