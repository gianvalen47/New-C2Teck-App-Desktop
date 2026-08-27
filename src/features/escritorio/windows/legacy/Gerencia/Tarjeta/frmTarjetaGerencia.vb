Imports System.ServiceModel

Public Class frmTarjetaGerencia
    Private oMercaderiaService As New ProductoService.ProductoServiceClient   'MercaderiaService.MercaderiaServiceClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private state_button As Boolean = False


    Private Sub frmTarjetaGerencia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMercaderiaService.Close()
            oLocacionMercaderiaService.Close()
            oPrecioService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMercaderiaService.Abort()
            oLocacionMercaderiaService.Abort()
            oPrecioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMercaderiaService.Abort()
            oLocacionMercaderiaService.Abort()
            oPrecioService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    'Private Sub frmTarjetaGerencia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Try
    '        oMercaderiaService.Close()
    '        oLocacionMercaderiaService.Close()
    '        oPrecioService.Close()

    '    Catch ex As TimeoutException
    '        oMercaderiaService.Abort()
    '        oLocacionMercaderiaService.Abort()
    '        oPrecioService.Abort()

    '    Catch ex As Exception
    '        oMercaderiaService.Abort()
    '        oLocacionMercaderiaService.Abort()
    '        oPrecioService.Abort()

    '    End Try
    'End Sub

    Private Sub frmTarjetaGerencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If txtCodigo.Text = "" Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                LimpiarDatos()
            End If

        End If
    End Sub

    Private Sub frmTarjetaGerencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 101)
        '/*************************************************************************************/

        txtCodigo.ReadOnly = False
        txtCodigo.BackColor = System.Drawing.SystemColors.Window
        txtanio.ReadOnly = True
        txtanio.BackColor = System.Drawing.SystemColors.Control
        txtanio.Value = Today.Year
        oSeguridadService.RegistrarVisitaOpciones(101, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
    End Sub

    Private Sub LimpiarDatos()
        state_button = False
        txtCodigo.Clear()
        txtCodigo.ReadOnly = False
        txtCodigo.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.Clear()
        txtDescripcion2.Clear()
        txtCodPartida.Clear()
        txtPartida.Clear()
        txtCodRubro.Clear()
        txtRubro.Clear()
        txtCodTipMov.Clear()
        txtTipMov.Clear()
        txtCostoDol.Value = 0
        txtCostoSol.Value = 0
        txtCostoUSA.Value = 0
        txtFabricaUSA.Value = 0
        txtMostradorNS.Value = 0
        txtMostradorUSA.Value = 0
        txtPeso.Value = 0
        txtStock.Value = 0
        txtanio.Value = Today.Year
        txtanio.ReadOnly = True
        txtanio.BackColor = System.Drawing.SystemColors.Control
        txtCodigo.Select()

        If dtDatos.Rows.Count > 0 Then
            dtDatos.Clear()
        End If

    End Sub


    Private Sub listaDatos()
        Try
            If toBlank(txtCodigo.Text) <> "" And state_button = True Then
                dtDatos = oLocacionMercaderiaService.MostrarStockGeneral(1, txtCodigo.Text, toNumber(txtanio.Value)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
            Else
                MsgBox("Debe ingresar el código de la mercaderia...", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'If oMercaderiaService.Buscar(txtCodigo.Text) Then
            e.Handled = True
            dgvDatos.Focus()
            'End If
        End If
    End Sub

    Private Sub txtCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigo.Validating
        ObtenerRegistro()

    End Sub

    Private Sub ObtenerRegistro()
        Try
            If Len(Trim(txtCodigo.Text)) > 0 Then

                If oMercaderiaService.Buscar(txtCodigo.Text, Session.sCodEmp) Then
                    Dim Mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia

                    Mercaderia = oMercaderiaService.obtener(txtCodigo.Text, Session.sCodEmp)

                    txtCodPartida.Text = Mercaderia.Partida.CodPar
                    txtCodRubro.Text = Mercaderia.Rubro.CodRub
                    txtCodTipMov.Text = Mercaderia.Movimiento.CodMov
                    txtCostoUSA.Text = Mercaderia.CosDol
                    txtDescripcion.Text = Mercaderia.DesMer1
                    txtDescripcion2.Text = Mercaderia.DesMer2
                    txtFabricaUSA.Text = Mercaderia.DeaMer
                    txtMostradorNS.Text = toDouble(oPrecioService.PrecioMostrador(1, txtCodigo.Text, "NS"))
                    txtMostradorUSA.Text = toDouble(oPrecioService.PrecioMostrador(1, txtCodigo.Text, "US"))
                    txtPartida.Text = Mercaderia.Partida.ParPar
                    txtPeso.Text = Mercaderia.PesMer
                    txtRubro.Text = Mercaderia.Rubro.DesRub
                    txtTipMov.Text = Mercaderia.Movimiento.DesMov
                    txtStock.Text = toNumber(oLocacionMercaderiaService.MostrarStockEmpresa(Session.sCodEmp, txtCodigo.Text))
                    txtCostoDol.Text = toDouble(oLocacionMercaderiaService.MostrarCostoEmpresa(Session.sCodEmp, txtCodigo.Text, "US"))
                    txtCostoSol.Text = toDouble(oLocacionMercaderiaService.MostrarCostoEmpresa(Session.sCodEmp, txtCodigo.Text, "NS"))
                    txtCodigo.ReadOnly = True
                    txtCodigo.BackColor = System.Drawing.SystemColors.Control

                    txtanio.ReadOnly = False
                    txtanio.BackColor = System.Drawing.SystemColors.Window

                    state_button = True
                    listaDatos()
                    dgvDatos.Focus()
                Else
                    MsgBox("No existe esta Mercaderia...")
                    txtCodigo.Clear()
                    txtCodigo.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderiaGerencia

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            state_button = True
            txtCodigo.Text = frm.codigo
            ObtenerRegistro()
            listaDatos()

        End If
    End Sub

    Private Sub txtanio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtanio.ValueChanged
        Try
            If state_button = True Then
                listaDatos()

            End If
        Catch ex As Exception
            MsgBox("Error al validar el año : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        Try
            MostrarKardex()

        Catch ex As Exception
            MsgBox("Error al mostrar el kardex : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarKardex()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmKardex_VerKardex
                frm.IdLocacion = dgvDatos.CurrentRow.Cells("IdLocacion").Text
                frm.CodMer = txtCodigo.Text
                frm.txtanio.Value = txtanio.Value
                frm.ShowDialog()
            Else
                MsgBox("No existen datos que mostrar, Verifique ...")
            End If

        Catch ex As Exception
            MsgBox("Error al mostrar el Kardex : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpTarjetaGerencial

            If dtDatos.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtDatos)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("CodMer", txtCodigo.Text)
                reporte.SetParameterValue("CodPartida", txtCodPartida.Text)
                reporte.SetParameterValue("Partida", txtPartida.Text)
                reporte.SetParameterValue("CodRubro", txtCodRubro.Text)
                reporte.SetParameterValue("Rubro", txtRubro.Text)
                reporte.SetParameterValue("Descripcion1", txtDescripcion.Text)
                reporte.SetParameterValue("Descripcion2", txtDescripcion2.Text)
                reporte.SetParameterValue("Peso", txtPeso.Text)
                reporte.SetParameterValue("TipMov", txtTipMov.Text)
                reporte.SetParameterValue("TipCodMov", txtCodTipMov.Text)
                reporte.SetParameterValue("FabricaUSA", txtFabricaUSA.Text)
                reporte.SetParameterValue("MostradorUS", txtMostradorUSA.Text)
                reporte.SetParameterValue("MostradorNS", txtMostradorNS.Text)
                reporte.SetParameterValue("CostoDol", txtCostoDol.Text)
                reporte.SetParameterValue("CostoSol", txtCostoSol.Text)
                reporte.SetParameterValue("Stock", txtStock.Text)
                reporte.SetParameterValue("Anio", txtanio.Value)
                reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))

                forma.Text = "Reporte de Tarjetas"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            MostrarKardex()
        End If
    End Sub


End Class