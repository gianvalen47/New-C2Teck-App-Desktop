Imports System.ServiceModel
Public Class frmSobregiro
    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumento As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim dtOficina As DataTable
    Dim dtAlmacen As DataTable
    Dim dtDocumento As DataTable
    Private Sub frmSobregiro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oDocumento.Close()

        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oDocumento.Abort()

        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oDocumento.Abort()

        End Try
    End Sub
    Private Sub frmSobregiro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 98)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        txtInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        txtFin.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        llenarCombos()

        ' dtDocumento = oDocumento.ReporteSobregiro(cbFecInicio.Value, cbFecFinal.Value, cbAlmacen.Value).Tables(0)
        'DataGridView1.DataSource = dtDocumento
        'cbOficina.Focus()
    End Sub
    Private Sub llenarCombos()
        Try
            dtOficina = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtOficina.Rows.InsertAt(getRowTodos(dtOficina), 0)
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub frmSobregiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub cbOficina_ValueChanged_(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = oMaestroService.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            dtAlmacen.Rows.InsertAt(getRowTodos(dtAlmacen), 0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Almacenes")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            oSeguridadService.RegistrarVisitaOpciones(98, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            Dim forma As New frmReportes
            Dim reporte As New rpSobregiro
            dtDocumento = oDocumento.ReporteSobregiro(txtInicio.Text, txtFin.Text, cbAlmacen.Value).Tables(0)
            If dtDocumento.Rows.Count <= 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtDocumento)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("FecInicio", txtInicio.Text)
                reporte.SetParameterValue("FecFin", txtFin.Text)
                forma.Text = "Reporte de Sobregiros"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Consulta")
        End Try
    End Sub
End Class