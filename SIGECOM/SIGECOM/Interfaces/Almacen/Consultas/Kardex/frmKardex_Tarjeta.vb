Imports System.Windows.Forms

Public Class frmKardex_Tarjeta

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oPedidoImportDetService As New PedidoImportDetService.PedidoImportDetServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oValeDetService As New ValeMaterialDetService.ValeMaterialDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient         '------- Agregado el 27/02/2012 -------
    Private oDocumentoTransitoDetService As New DocumentoTransitoDetService.DocumentoTransitoDetServiceClient   '-- Agregado el 23/05/2014 para ver la cantidad que se encuentra en documentos en transito
    Private oListaFabrica As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient

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
                , txtSLP.KeyPress _
                , txtMostradorSoles.KeyPress _
                , txtMostradorDolares.KeyPress _
                , txtPrecioOferta.KeyPress _
                , txtDisponible.KeyPress _
                , txtComprometido.KeyPress _
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

            Case Keys.F6
                Me.Comprometidos()
                e.Handled = True

            Case Keys.F7
                Me.Transito()
                e.Handled = True

            Case Keys.F8
                Me.MovimientoVales()
                e.Handled = True

            Case Keys.Escape
                Me.Dispose()
                'e.Handled = True
        End Select
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
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
            If isClosed(oValeDetService) = False Then
                oValeDetService.Close()
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
            Dim mercaderia As ProductoService.Producto  'MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp) 'oMercaderiaService.MostrarPorCodigo(txtCodMer.Text)


            txtCodMer.Text = toBlank(registro.Mercaderia.CodMer)
            lblUbiMer.Text = toBlank(registro.UbiMer)
            lblUniMed.Text = toBlank(mercaderia.UnidadMedida.Nombre)
            lblClase.Text = toBlank(mercaderia.ClaseMerca.NomClas)
            lblDesMer1.Text = toBlank(mercaderia.DesMer1)
            lblDesMer2.Text = toBlank(mercaderia.DesMer2)
            lblrubro.Text = toBlank(mercaderia.Rubro.DesRub)
            lblPeso.Text = toBlank(mercaderia.PesMer)
            lblUniPeso.Text = toBlank(mercaderia.UnidadMedidaPeso.CodUniMedPeso)
            'lblGrupo.Text = toBlank(mercaderia.GrupoMerca.CodGru)
            lblCodPartida.Text = toBlank(mercaderia.Partida.CodPar)
            lblPartida.Text = toBlank(mercaderia.Partida.DesPar)
            lblTipoMotor.Text = toBlank(mercaderia.TipoMotor.TipMot)
            lblTipoMovi.Text = toBlank(mercaderia.Movimiento.DesMov)
            lblAplicacion.Text = toBlank(mercaderia.AplicacionMerca.DesApl)
            lblCodApli.Text = toBlank(mercaderia.AplicacionMerca.CodApl)
            lblMarca.Text = toBlank(mercaderia.Marca.DesMar)
            lblCodigoAntiguo.Text = toBlank(registro.Mercaderia.AntMer)
            lblcodigonuevo.Text = toBlank(registro.Mercaderia.NueMer)
            lblFactorSPCC.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Partidas", "FacPar", "CodPar", mercaderia.Partida.CodPar))

            '---------------- Se agregó a pedido de Carlos Rios 18/01/2019 ---------------
            lblListaPrecioNombre.Text = mercaderia.ListaPrecios.DesListaPre
            '----------------------------------------------------------------------------------------------------

            txtDeaMer.Text = oListaFabrica.ObtenerPrecioExWorkVigente(Session.sCodEmp, mercaderia.ListaPrecios.IdListaPre, txtCodMer.Text) 'oListaFabrica.ObtenerPrecioFobVigente(Session.sCodEmp, mercaderia.ListaPrecios.IdListaPre, txtCodMer.Text) 'mercaderia.DeaMer
            txtCorMerSol.Text = oPrecioService.PrecioCore(IdLocacion, txtCodMer.Text, "NS", Date.Today)
            txtCorMerDol.Text = oPrecioService.PrecioCore(IdLocacion, txtCodMer.Text, "US", Date.Today)
            txtPrecioOferta.Text = oPrecioService.PrecioOferta(IdLocacion, txtCodMer.Text, "NS")

            '------------- Se valida que si el código presenta Lista Precio no se sume el Core--------------
            If oPrecioService.BuscarListaPrecio(Session.sCodEmp, txtCodMer.Text) Then
                txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US")
                txtMostradorSoles.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "NS")
            Else
                txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US") + txtCorMerDol.Text
                txtMostradorSoles.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "NS") + txtCorMerSol.Text
            End If
            '------------------------------------------------------------------------------------------------------------------------------

            'txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US") + txtCorMer.Text
            txtSLP.Text = oListaFabrica.ObtenerPrecioFobVigente(Session.sCodEmp, mercaderia.ListaPrecios.IdListaPre, txtCodMer.Text) 'oPrecioService.PrecioSPCCEmpresa(txtCodMer.Text, Session.sCodEmp)


            'txtDeaMer.Text = mercaderia.DeaMer
            'txtCorMer.Text = mercaderia.CorMer
            'txtPrecioOferta.Text = oPrecioService.PrecioOferta(IdLocacion, txtCodMer.Text)
            'txtMostradorDolares.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "US")
            'txtMostradorSoles.Text = oPrecioService.PrecioMostrador(IdLocacion, txtCodMer.Text, "NS")
            'txtSPCC.Text = oPrecioService.PrecioSPCC(txtCodMer.Text)

            txtStock.Text = registro.Stock
            txtComprometido.Text = oValeDetService.ObtenerCantidadComprometido(IdLocacion, txtCodMer.Text)
            txtDisponible.Text = registro.Stock - toNumber(txtComprometido.Text)
            txtSeparado.Text = oOrdenCompraDetService.CantidadSeparada(IdLocacion, txtCodMer.Text)

            '------------- Mensaje de Precio cuando el disponible es 0 -------------
            If toNumber(txtDisponible.Text) = 0 Then
                lblMensajePrecio.Visible = True
                lblMensajePrecio2.Visible = True
                lblMensajePrecio3.Visible = True
            Else
                lblMensajePrecio.Visible = False
                lblMensajePrecio2.Visible = False
                lblMensajePrecio3.Visible = False
            End If
            '--------------------------------------------------------------------------------------------

            '------ SE COMENTA A PEDIDO DE SR. CHIPA 13/01/2016 -------
            'If txtDisponible.Text < 0 Then
            '    txtDisponible.Text = 0
            'End If
            '---------------------------------------------------------------------------------------------
            txtIngreso.Text = oLocacionMercaderiaService.TotalIngresos(IdLocacion, toBlank(txtCodMer.Text), Today)
            txtEgreso.Text = oLocacionMercaderiaService.TotalEgresos(IdLocacion, toBlank(txtCodMer.Text), Today)
            'txtCantidadPedida.Text = oPedidoImportDetService.CantidadPedida(txtCodMer.Text)
            txtCantidadPedida.Text = oPedidoImportDetService.CantidadPedidaEmpresa(Session.sCodEmp, txtCodMer.Text)
            txtMinimo.Text = registro.MinMer
            txtMaximo.Text = registro.MaxMer

            '--------------- Agregado el 23/05/2014 para ver la cantidad que se encuentra en documentos en transito ---------------
            txtTransito.Text = oDocumentoTransitoDetService.TotalPendiente(IdLocacion, toBlank(txtCodMer.Text))
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------

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
                    txtSLP.Visible = False
                    lblCorMerSol.Visible = False
                    txtCorMerSol.Visible = False
                    lblCorMerDol.Visible = False
                    txtCorMerDol.Visible = False

                    If oPrecioService.BuscarListaPrecio(Session.sCodEmp, txtCodMer.Text) Then
                        lblListaPrecio.Visible = True

                        lblIncluyeCore.Visible = False
                        lblIncluyeUS.Visible = False
                        lblIncluyeNS.Visible = False

                    Else
                        lblListaPrecio.Visible = False

                        If txtCorMerSol.Text = 0 Then
                            lblIncluyeCore.Visible = False
                            lblIncluyeUS.Visible = False
                            lblIncluyeNS.Visible = False
                        Else
                            lblIncluyeCore.Visible = True
                            lblIncluyeUS.Visible = True
                            lblIncluyeNS.Visible = True
                        End If
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
                    txtSLP.Visible = False
                    lblCorMerSol.Visible = False
                    txtCorMerSol.Visible = False
                    lblCorMerDol.Visible = False
                    txtCorMerDol.Visible = False
                    'lblIncluyeUS.Visible = False

                    If oPrecioService.BuscarListaPrecio(Session.sCodEmp, txtCodMer.Text) Then
                        lblListaPrecio.Visible = True

                        lblIncluyeCore.Visible = False
                        lblIncluyeUS.Visible = False
                        lblIncluyeNS.Visible = False

                    Else
                        lblListaPrecio.Visible = False

                        If txtCorMerSol.Text = 0 Then
                            lblIncluyeCore.Visible = False
                            lblIncluyeUS.Visible = False
                            lblIncluyeNS.Visible = False
                        Else
                            lblIncluyeCore.Visible = True
                            lblIncluyeUS.Visible = False
                            lblIncluyeNS.Visible = True
                        End If
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
    Private Sub Comprometidos()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerComprometidos
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Transito()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerTransito
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub MovimientoVales()
        If toBlank(txtCodMer.Text) <> "" Then
            Dim frm As New frmKardex_VerMovVales
            frm.IdLocacion = IdLocacion
            frm.CodMer = txtCodMer.Text
            frm.txtanio.Value = Today.Year
            frm.ShowDialog()
        Else
            MsgBox("Debe de ingresar el código de la mercaderia", MsgBoxStyle.Information)
        End If
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
    Private Sub btnTransito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransito.Click
        Transito()
    End Sub
    Private Sub btnMovVales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovVales.Click
        MovimientoVales()
    End Sub
    Private Sub btnComprometidos_Click(sender As Object, e As EventArgs) Handles btnComprometidos.Click
        Comprometidos()
    End Sub
End Class
