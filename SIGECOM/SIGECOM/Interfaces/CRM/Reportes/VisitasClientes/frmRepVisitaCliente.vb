Imports System.ServiceModel
Public Class frmRepVisitaCliente
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient
    Private oVisitaOportunidadService As New VisitaOportunidadService.VisitaOportunidadServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Dim dtReporte As DataTable
    Private dtUnidades As DataTable
    Public IdPersona As Integer
    Public IdCliente As Integer
    Private dtTipoVisita As DataTable
    Private dtEstados As DataTable

    Private Sub frmRepVisitaCliente_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oVisitaOportunidadService.Close()
            oVisitaClienteService.Close()
            oCentroCostoService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oVisitaOportunidadService.Abort()
            oVisitaClienteService.Abort()
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVisitaOportunidadService.Abort()
            oVisitaClienteService.Abort()
            oCentroCostoService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepVisitaCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub
    Private Sub frmRepVisitaCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 294)
        '/*************************************************************************************/

        txtFecInicio.Value = CDate("01/" & toBlank(Month(Today)) & "/" & toBlank(Year(Today)))
        txtFecFinal.Value = Today
        llenarCombos()
        ObtenerSolicitante()
        chkColaborador.Enabled = True
        rbBuscarCliente.Enabled = False
    End Sub

    Private Sub ObtenerSolicitante()
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        txtColaborador.Text = usuario.Persona.ApeNom
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                               txtFecInicio.KeyPress,
                               txtFecFinal.KeyPress,
                               txtCliente.KeyPress,
                               txtColaborador.KeyPress,
                               cmbUnidad.KeyPress,
                               cmbTipoVisita.KeyPress,
                               cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            ''===================================== TIPO DE VISITA ============================================
            dtTipoVisita = oVisitaOportunidadService.MostrarTipoVisita().Tables(0)
            dtTipoVisita.Rows.InsertAt(getRowTodos(dtTipoVisita), 0)
            cmbTipoVisita.DataSource = dtTipoVisita
            cmbTipoVisita.DropDownList.DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.DisplayMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.ValueMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(0).DataMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(1).DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.SelectedIndex = 0
            dtTipoVisita = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

            '======================================= ESTADO ================================================
            dtEstados = oVisitaClienteService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
        Else
            chkColaborador.Enabled = True
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            rbBuscarCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        Else
            rbBuscarCliente.Enabled = True
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo                    
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                rbBuscarCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtFecInicio.Value > txtFecFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor a la fecha final.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rptRepVisitaCliente
            Dim dtReporte As New DataTable

            dtReporte = oVisitaClienteService.Reporte(Session.sCodEmp, toNumber(cmbUnidad.Value), IdPersona, IdCliente, txtFecInicio.Value, txtFecFinal.Value, toNumber(cmbTipoVisita.Value), toNumber(cmbEstado.Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte Consolidado de Tardanzas"
                reporte.SetParameterValue("pFechaInicio", txtFecInicio.Value)
                reporte.SetParameterValue("pFechaFin", txtFecFinal.Value)
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class