Imports System.ServiceModel
Public Class frmReporteImport
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New ImportacionService.ImportacionServiceClient
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable
    Private dtMes As New DataTable

    Private Sub frmReporteImport_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumero.KeyPress _
        , txtPeriodo.KeyPress _
        , cbMes.KeyPress _
        , cbOficina.KeyPress
        ', cbAlmacen.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmReporteImport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmReporteImport_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmReporteImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        rbRegistro.Select()
    End Sub
    Private Sub LlenarCombos()
        Try
            txtPeriodo.Value = IIf(Month(Today) = 1, Year(Today) - 1, Year(Today))
            dtMes = ObjMaestro.MostrarMeses
            cbMes.DataSource = dtMes
            cbMes.DataMember = "Descripcion"
            cbMes.DisplayMember = "Descripcion"
            cbMes.ValueMember = "Codigo"
            cbMes.DropDownList.Columns(0).DataMember = "Codigo"
            cbMes.DropDownList.Columns(1).DataMember = "Descripcion"
            cbMes.SelectedIndex = IIf(Month(Today) = 1, 11, Month(Today) - 2)
            dtMes = Nothing

            dtOficina = ObjMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            Dim row As DataRow = dtOficina.NewRow
            row(0) = ""
            row(1) = "(Todos)"
            dtOficina.Rows.InsertAt(row, 0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
        Dim row As DataRow = dtAlmacen.NewRow
        row(0) = 0
        row("DesAlm") = "(Todos)"
        dtAlmacen.Rows.InsertAt(row, 0)
        cbAlmacen.DataSource = dtAlmacen
        cbAlmacen.DisplayMember = "DesAlm"
        cbAlmacen.ValueMember = "IdLocacion"
        cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
        cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
        cbAlmacen.SelectedIndex = 0
        dtAlmacen = Nothing
    End Sub

    'Private Sub Finalizar()
    '    Try
    '        ObjMaestro.Close()
    '        ObjDocumento.Close()
    '    Catch ex As TimeoutException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '    Catch ex As CommunicationException
    '        ObjMaestro.Abort()
    '        ObjDocumento.Abort()
    '    End Try
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim dtReporte As New DataTable
        Dim forma As New frmReportes
        If rbRegistro.Checked Then
            dtReporte = ObjDocumento.RegistroImportacion(cbAlmacen.Value, cbMes.Value, txtPeriodo.Value).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                txtPeriodo.Select()
                Exit Sub
            Else
                Dim reporte As New rpRegistroImportacion
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("Titulo", IIf(cbAlmacen.Value = 0, "R E G I S T R O  G E N E R A L  D E  I M P O R T A C I O N E S", "R E G I S T R O  D E  I M P O R T A C I O N E S"))
                reporte.SetParameterValue("Almacen", IIf(cbAlmacen.Value = 0, "", cbOficina.Text & " - " & cbAlmacen.Text))
                reporte.SetParameterValue("Mes", cbMes.Text & "  " & txtPeriodo.Value)
            End If
        ElseIf rbResumen.Checked Then
            If txtNumero.Text = "" Then
                MsgBox("Ingrese el numero de la factura", MsgBoxStyle.Information, "Ingrese Numero")
                txtNumero.Select()
                Exit Sub
            End If
            dtReporte = ObjDocumento.ResumenImportacion(cbAlmacen.Value, txtNumero.Text).Tables(0)
            'dtReporte.WriteXmlSchema("D:\Proyecto\Codigo\SIGECOM\Cliente\Reportes\OrigenDatos\ResumenImportacion.xml")
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
                txtNumero.Select()
                Exit Sub
            Else
                Dim reporte As New rpResumenImportacion
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                reporte.SetParameterValue("Almacen", IIf(cbAlmacen.Value = 0, "", cbOficina.Text & " - " & cbAlmacen.Text))
            End If
        End If
        forma.crvReportes.DisplayGroupTree = False
        forma.Text = "Reporte de Importaciones"
        forma.ShowDialog()
    End Sub

    Private Sub rbRegistro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRegistro.CheckedChanged
        gbPeriodo.Visible = True
        gbNumero.Visible = False
    End Sub

    Private Sub rbResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbResumen.CheckedChanged
        gbPeriodo.Visible = False
        gbNumero.Visible = True
        gbNumero.Location = New Point(6, 68)
        txtNumero.Focus()
    End Sub

    Private Sub rbRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPeriodo.Select()
        End If
    End Sub

    Private Sub cbAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub

End Class