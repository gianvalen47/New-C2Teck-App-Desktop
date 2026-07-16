Public Class frmPrecios

    Private oMarcaService As New MarcaService.MarcaServiceClient
    Private oPrecioService As New PrecioService.PrecioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPrecioFabricanteService As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDetServiceClient
    Private dtDatos As DataTable
    Private Sub frmPrecios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If rtCambios.Visible = True Then
                rtCambios.Visible = False
                txtCodMer.Select()
                txtCodMer.Clear()
                txtCountry.Text = ""
                txtDesMer.Text = ""
                txtFunctional.Text = ""
                txtGroupCode.Text = ""
                txtMustBuy.Text = ""
                txtPrecioCore.Text = ""
                txtPrecioDealer.Text = ""
                txtPrecioVentaDol.Text = ""
                txtPrecioVentaSol.Text = ""
                txtPublication.Text = ""
                txtRecord.Text = ""
                txtSeries.Text = ""
                txtSupercession.Text = ""
                txtWeight.Text = ""
                txtUnitWeight.Text = ""
                txtCubes.Text = ""
                txtUnitCubes.Text = ""
                txtPrecioDistDom.Text = ""
                txtExWork.Text = ""
                txtCodMer.ReadOnly = False
            Else
                If txtCodMer.Text = "" Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()
                Else
                    txtCodMer.Text = ""
                    txtCountry.Text = ""
                    txtDesMer.Text = ""
                    txtFunctional.Text = ""
                    txtGroupCode.Text = ""
                    txtMustBuy.Text = ""
                    txtPrecioCore.Text = ""
                    txtPrecioDealer.Text = ""
                    txtPrecioVentaDol.Text = ""
                    txtPrecioVentaSol.Text = ""
                    txtPublication.Text = ""
                    txtRecord.Text = ""
                    txtSeries.Text = ""
                    txtSupercession.Text = ""
                    txtWeight.Text = ""
                    txtUnitWeight.Text = ""
                    txtCubes.Text = ""
                    txtUnitCubes.Text = ""
                    txtPrecioDistDom.Text = ""
                    txtExWork.Text = ""
                    txtCodMer.Select()
                    txtCodMer.ReadOnly = False
                End If

            End If

        End If
    End Sub

    Private Sub frmPrecios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbMarca.KeyPress _
            , txtCountry.KeyPress _
            , txtDesMer.KeyPress _
            , txtFunctional.KeyPress _
            , txtMustBuy.KeyPress _
            , txtPublication.KeyPress _
            , txtRecord.KeyPress _
            , txtSeries.KeyPress _
            , txtSupercession.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub Precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 28)
        '/*************************************************************************************/

        llenarCombos()
        'cmbMarca.Value = 1
    End Sub
    Private Sub llenarCombos()
        Try
            dtDatos = oPrecioService.MostrarListaPreciosVigentes.Tables(0)  'oMarcaService.MostrarMarcasListaPrecio.Tables(0)
            cmbMarca.DataSource = dtDatos
            'cmbMarca.DropDownList.DataMember = dtDatos.Columns("DesMar").ToString
            'cmbMarca.DropDownList.DisplayMember = dtDatos.Columns("DesMar").ToString
            'cmbMarca.DropDownList.ValueMember = dtDatos.Columns("CodMar").ToString
            'cmbMarca.DropDownList.Columns(0).DataMember = dtDatos.Columns("CodMar").ToString
            'cmbMarca.DropDownList.Columns(1).DataMember = dtDatos.Columns("DesMar").ToString
            cmbMarca.DropDownList.DataMember = dtDatos.Columns("IdListaPre").ToString
            cmbMarca.DropDownList.DisplayMember = dtDatos.Columns("DesListaPre").ToString
            cmbMarca.DropDownList.ValueMember = dtDatos.Columns("IdListaPre").ToString
            cmbMarca.DropDownList.Columns(0).DataMember = dtDatos.Columns("IdListaPre").ToString
            cmbMarca.DropDownList.Columns(1).DataMember = dtDatos.Columns("DesListaPre").ToString
            cmbMarca.SelectedIndex = 0
            dtDatos = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtCodMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try

                If Len(Trim(txtCodMer.Text)) > 0 Then
                    'If oPrecioService.BuscarPrecioFabrica(cmbMarca.Value, txtCodMer.Text) Then
                    'If oPrecioService.BuscarListaPrecioFabrica(cmbMarca.Value, txtCodMer.Text) Then
                    If oPrecioFabricanteService.BuscarPrecioCodigoVigente(Session.sCodEmp, cmbMarca.Value, txtCodMer.Text) Then
                        ' Select Case oPrecioService.ObtenerTipoPrecioFabrica(cmbMarca.Value, txtCodMer.Text)
                        '   Case "1"
                        Dim registro As New ListaPrecioFabricanteDetService.ListaPrecioFabricanteDet   'PrecioService.PrecioFabrica
                        registro = oPrecioFabricanteService.ObtenerPrecioCodigoVigente(Session.sCodEmp, cmbMarca.Value, txtCodMer.Text)  'oPrecioService.ObtenerListaPrecioFabrica(cmbMarca.Value, txtCodMer.Text) 'oPrecioService.ObtenerPrecioFabrica(cmbMarca.Value, txtCodMer.Text)
                        txtDesMer.Text = registro.DesMer  'registro.Mercaderia.DesMer2
                        txtRecord.Text = "" 'registro.RecTyp
                        txtSupercession.Text = "" 'registro.CodSup
                        txtPublication.Text = "" 'registro.CodPub
                        txtSeries.Text = "" 'registro.CodSer
                        txtFunctional.Text = "" 'registro.CodCom
                        txtCountry.Text = "" 'registro.Pais.CodPais
                        txtPrecioCore.Text = "" 'registro.PreCore
                        txtMustBuy.Text = "" 'registro.CanMer
                        txtGroupCode.Text = "" 'registro.NumGru
                        txtWeight.Text = "" 'registro.Weight
                        txtUnitWeight.Text = "" 'registro.UnitWeight
                        txtCubes.Text = "" 'registro.Cubes
                        txtUnitCubes.Text = "" 'registro.UnitCubes
                        txtPrecioDealer.Text = registro.PrecioSLP   'registro.Dealer
                        txtPrecioVentaDol.Text = registro.PreVenDol
                        txtPrecioVentaSol.Text = registro.PreVenSol
                        txtExWork.Text = registro.PreLista  'registro.DistInt
                        txtPrecioDistDom.Text = "" 'registro.DistDom
                        txtCodMer.ReadOnly = True
                        'oPrecioService.ObtenerPrecioFabrica("", "")
                        '     Case "2"

                        'rtCambios.Text = oPrecioService.ObtenerCambiosFabrica(cmbMarca.Value, txtCodMer.Text)
                        'rtCambios.Visible = True
                        'txtCodMer.ReadOnly = True
                        ' oPrecioService.ObtenerCambiosFabrica("", "")
                        ' End Select
                    Else
                        MsgBox("No existe mercadería de dicha LISTA")
                        txtCodMer.Clear()
                        txtCountry.Text = ""
                        txtDesMer.Text = ""
                        txtFunctional.Text = ""
                        txtGroupCode.Text = ""
                        txtMustBuy.Text = ""
                        txtPrecioCore.Text = ""
                        txtPrecioDealer.Text = ""
                        txtPrecioVentaDol.Text = ""
                        txtPrecioVentaSol.Text = ""
                        txtPublication.Text = ""
                        txtRecord.Text = ""
                        txtSeries.Text = ""
                        txtSupercession.Text = ""
                        txtWeight.Text = ""
                        txtUnitWeight.Text = ""
                        txtCubes.Text = ""
                        txtUnitCubes.Text = ""
                        txtExWork.Text = ""
                        txtPrecioDistDom.Text = ""
                        txtCodMer.ReadOnly = False
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub txtCodMer_ContextMenuChanged(sender As Object, e As EventArgs) Handles txtCodMer.ContextMenuChanged

    End Sub
End Class