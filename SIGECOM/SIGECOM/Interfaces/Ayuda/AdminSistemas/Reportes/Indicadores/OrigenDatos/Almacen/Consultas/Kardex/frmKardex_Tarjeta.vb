Imports System.Windows.Forms

Public Class frmKardex_Tarjeta

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient         '-------Agregado el 27/02/2012-------

    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdLocacion As String        '---- IdLocacion (Almacen) de Tarjeta seleccionada ----

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                  txtObservacion.KeyPress _
                , txtCorMerSol.KeyPress _
                , txtDeaMer.KeyPress _
                , txtCodMer.KeyPress _
                , txtSPCC.KeyPress _
                , txtMostradorSoles.KeyPress _
                , txtMostradorDolares.KeyPress _
                , txtPrecioOferta.KeyPress _
                , txtDisponible.KeyPress _
                , txtSeparado.KeyPress _
                , txtStock.KeyPress _
                , txtMaximo.KeyPress _
                , txtMinimo.KeyPress _
                , txtCantidadPedida.KeyPress _
                , txtCostoSoles.KeyPress _
                , txtCostoDolares.KeyPress _
                , txtOserbacionLocacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmKardex_Tarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode

            Case Keys.F2

                Me.Pedidos()
                e.Handled = True

            Case Keys.F3
                Me.VerKardex()
                e.Handled = True

            Case Keys.F4
                Me.VerStock()
                e.Handled = True

            Case Keys.F5
                Me.Separaciones()
                e.Handled = True

            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        ObtenerRegistro()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
            If isClosed(oPrecioService) = False Then
                oPrecioService.Close()
            End If
            If isClosed(oPedidoImportDetService) = False Then
                oPedidoImportDetService.Close()
            End If
            If isClosed(oOrdenCompraDetService) = False Then
                oOrdenCompraDetService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub ObtenerRegistro()
        Try

            Dim registro As LocacionMercaderiaService.LocacionMercaderia
            registro = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, toBlank(txtCodMer.Text))
            Dim mercaderia As MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)


            txtCodMer.Text = toBlank(registro.Mercaderia.CodMer)
            lblUbiMer.Text = toBlank(registro.UbiMer)
            lblUniMed.Text = toBlank(mercaderia.UnidadMedida.Nombre)
            lblClase.Text = toBlank(mercaderia.ClaseMerca.NomClas)
            lblDesMer1.Text = toBlank(mercaderia.DesMer1)
            lblDesMer2.Text = toBlank(mercaderia.DesMer2)
            lblrubro.Text = toBlank(mercaderia.Rubro.DesRub)
            lblPeso.Text = toBlank(mercaderia.PesMer)
            lblUniPeso.Text = toBlank(mercaderia.UnidadMedidaPeso.CodUniMedPeso)
            lblGrupo.Text = toBlank(mercaderia.GrupoMerca.CodGru)
            lblCodPartida.Text = toBlank(mercaderia.Partida.CodPar)
            lblPartida.Text = toBlank(mercaderia.Partida.DesPar)
            lblTipoMotor.Text = toBlank(mercaderia.TipoMotor.TipMot)
            lblTipoMovi.Text = toBlank(mercaderia.Movimiento.DesMov)
            lblAplicacion.Text = toBlank(mercaderia.AplicacionMerca.DesApl)
            lblCodApli.Text = toBlank(mercaderia.AplicacionMerca.CodApl)
            lblMarca.Text = toBlank(mercaderia.Marca.DesMar)
            lblCodigoAntiguo.Text = toBlank(registro.Mercaderia.AntMer)
            lblCodigonuevo.Text = toBlank(registro.Mercaderia.NueMer)
            lblFactorSPCC.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Partidas", "FacPar", "CodPar", mercaderia.Partida.CodPar))


            txtDeaMer.Text = mercaderia.DeaMer
            txtCorMerSol.Text = oPrecioService.PrecioCore(IdLocacion, txtCodMer.Text, "NS", Date.Today)
            txtCorMerDol.Text = oPrecioService.PrecioCore(IdLocacion, txtCodMer.Text, "US", Date.Today)
            txtPrecioOferta.Text = oPrecioService.PrecioOferta(IdLocacion, txtCodMer.Text, "NS")
            txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US") + txtCorMerDol.Text
            'txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US") + txtCorMer.Text
            txtMostradorSoles.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "NS") + txtCorMerSol.Text
            txtSPCC.Text = oPrecioService.PrecioSPCC(txtCodMer.Text)


            'txtDeaMer.Text = mercaderia.DeaMer
            'txtCorMer.Text = mercaderia.CorMer
            'txtPrecioOferta.Text = oPrecioService.PrecioOferta(IdLocacion, txtCodMer.Text)
            'txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US")
            'txtMostradorSoles.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "NS")
            'txtSPCC.Text = oPrecioService.PrecioSPCC(txtCodMer.Text)

            txtStock.Text = registro.Stock
            txtSeparado.Text = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)
            txtDisponible.Text = registro.Stock - toNumber(txtSeparado.Text)
            If txtDisponible.Text < 0 Then
                txtDisponible.Text = 0
            End If

            txtIngreso.Text = oLocacionMercaderiaService.TotalIngresos(IdLocacion, toBlank(txtCodMer.Text), Today)
            txtEgreso.Text = oLocacionMercaderiaService.TotalEgresos(IdLocacion, toBlank(txtCodMer.Text), Today)
            txtCantidadPedida.Text = oPedidoImportDetService.CantidadPedida(txtCodMer.Text)
            txtMinimo.Text = registro.MinMer
            txtMaximo.Text = registro.MaxMer
            If txtStock.Text = 0 Then
                txtCostoDolares.Text = 0
            Else
                txtCostoDolares.Text = registro.CosDol
            End If
            If txtStock.Text = 0 Then
                txtCostoSoles.Text = 0
            Else
                txtCostoSoles.Text = registro.CosSol
            End If
            txtObservacion.Text = mercaderia.ObsMer
            txtOserbacionLocacion.Text = registro.ObsMer


            '*** 27/02/2012 Se comenta ya que se validara por la Variable "VerPrecios" de oSeguridadService.PermisoUsuario ****
            'If Session.CodPerfil = "03" Then
            '    lblPrecioFOB.Visible = False
            '    txtDeaMer.Visible = False
            '    lblMostradorUS.Visible = False
            '    txtMostradorDolares.Visible = False
            'Else
            '    lblPrecioFOB.Visible = True
            '    txtDeaMer.Visible = True
            '    lblMostradorUS.Visible = True
            '    txtMostradorDolares.Visible = True
            'End If
            '*****************************************************************************************************************************************

            '==================Agregado el 27/02/2012 ====================
            If IdLocacion = 4 Then
                gbPrecios.Visible = False
            Else
                gbPrecios.Visible = True

                Dim permiso As SeguridadService.PermisoUsuario
                Dim VerPrecios As Boolean
                permiso = oSeguridadService.MostrarPermisos(Session.sCodUsu)
                VerPrecios = permiso.VerPrecios

                If VerPrecios Then
                    lblPrecioFOB.Visible = True
                    txtDeaMer.Visible = True
                    lblPrecioOfertaNS.Visible = True
                    txtPrecioOferta.Visible = True
                    lblMostradorNS.Visible = True
                    txtMostradorSoles.Visible = True
                    lblMostradorUS.Visible = True
                    txtMostradorDolares.Visible = True
                    'SPCC Visible False para todos 03-07-13
                    lblSPCC.Visible = False
                    txtSPCC.Visible = False
                    lblCorMerSol.Visible = True
                    txtCorMerSol.Visible = True
                    lblCorMerDol.Visible = True
                    txtCorMerDol.Visible = True
                    If txtCorMerSol.Text = 0 Then
                        lblIncluyeCore.Visible = False
                        lblIncluyeUS.Visible = False
                        lblIncluyeNS.Visible = False
                    Else
                        lblIncluyeCore.Visible = True
                        lblIncluyeUS.Visible = True
                        lblIncluyeNS.Visible = True
                    End If
                    'lblCorMerSol.Visible = True
                    'txtCorMerSol.Visible = True
                    'txtCorMerDol.Visible = True
                Else
                    lblPrecioFOB.Visible = False
                    txtDeaMer.Visible = False
                    lblPrecioOfertaNS.Visible = False
                    txtPrecioOferta.Visible = False
                    lblMostradorNS.Visible = True
                    txtMostradorSoles.Visible = True
                    'Mostrador Dolares visible para todos 03-07-13
                    lblMostradorUS.Visible = True
                    txtMostradorDolares.Visible = True
                    'SPCC Visible False para todos 03-07-13
                    lblSPCC.Visible = False
                    txtSPCC.Visible = False
                    lblCorMerSol.Visible = False
                    txtCorMerSol.Visible = False
                    lblCorMerDol.Visible = False
                    txtCorMerDol.Visible = False
                    'lblIncluyeUS.Visible = False
                    If txtCorMerSol.Text = 0 Then
                        lblIncluyeCore.Visible = False
                        lblIncluyeUS.Visible = False
                        lblIncluyeNS.Visible = False
                    Else
                        lblIncluyeCore.Visible = True
                        lblIncluyeUS.Visible = False
                        lblIncluyeNS.Visible = True
                    End If
                    'lblCorMerSol.Visible = False
                    'txtCorMerSol.Visible = False
                    'txtCorMerDol.Visible = False
                End If
                End If
            '========================================================
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub VerKardex()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerKardex
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.txtanio.Value = Today.Year
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Pedidos()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerPedidos
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub VerStock()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerStock
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Separaciones()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerSeparacion
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnVerKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerKardex.Click
        VerKardex()
    End Sub
    Private Sub btnPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPedidos.Click
        Pedidos()
    End Sub
    Private Sub btnVerStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerStock.Click
        VerStock()
    End Sub
    Private Sub btnSeparaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeparaciones.Click
        Separaciones()
    End Sub

    Private Sub UiGroupBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbPrecios.Click

    End Sub
End Class
