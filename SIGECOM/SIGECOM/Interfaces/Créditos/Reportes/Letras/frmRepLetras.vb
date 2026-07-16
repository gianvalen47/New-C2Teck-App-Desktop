Imports System.ServiceModel
Public Class frmRepLetras
    Private oLetraService As New LetraService.LetraServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtUnidades As DataTable
    Private IdCliente As String

    Private Sub frmRepLetras_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oLetraService.Close()
            oCentroCostoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oLetraService.Abort()
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oLetraService.Abort()
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepLetras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub frmRepLetras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                 cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRepLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 48)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date
        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        llenarCombos()
    End Sub

    Private Sub llenarCombos()
        Try

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

          
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

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

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepLetraAceptada

            dtReporte = oLetraService.RepLetrasAceptadas(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(txtCliente.Text = "", 0, IdCliente)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                forma.Text = "Reporte de Letras Aceptadas"
                reporte.SetParameterValue("FecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("FecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)
                'dtReporte.WriteXmlSchema("C:\DocumentoEmitido.xml")

                forma.ShowDialog()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

   
    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo

        End If
    End Sub


    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(48, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub rcCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rcCliente.CheckedChanged
        If rcCliente.Checked Then
            lblCliente.Enabled = False
            txtCliente.Enabled = False
            btnCliente.Enabled = False
            txtCliente.Text = ""
            IdCliente = 0
        Else
            lblCliente.Enabled = True
            txtCliente.Enabled = True
            btnCliente.Enabled = True
        End If
    End Sub
End Class