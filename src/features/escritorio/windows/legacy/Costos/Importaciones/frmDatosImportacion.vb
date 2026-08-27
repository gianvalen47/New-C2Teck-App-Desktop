Imports System.ServiceModel
Imports System.Windows.Forms
Public Class frmDatosImportacion
    Public pIdImportacion As Int64 = Nothing
    Public pEstado As String = ""
    Public pCodPais As String = Nothing
    Private ObjImportacion As New ImportacionService.ImportacionServiceClient
    Private ObjImportadionDet As New ImportacionDetService.ImportacionDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private Importacion As New ImportacionService.Importacion
    Private IdProveedorAduana As Integer = 0
    Private dtDetalle As New DataTable

    Private Sub frmDatosImportacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjImportacion.Close()
            ObjImportadionDet.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            ObjImportacion.Abort()
            ObjImportadionDet.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            ObjImportacion.Abort()
            ObjImportadionDet.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Close()
        GC.SuppressFinalize(Me)

    End Sub


    Private Sub frmDatosImportacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtAduana.KeyPress _
        , txtFactura.KeyPress _
        , txtFecDoc.KeyPress _
        , txtGuia.KeyPress _
        , txtIngreso.KeyPress _
        , txtNumDoc.KeyPress _
        , txtOrigen.KeyPress _
        , txtPoliza.KeyPress _
        , txtProveedor.KeyPress _
        , mkAdvalorem.KeyPress _
        , mkCambio.KeyPress _
 _
        , mkDerAduDol.KeyPress _
        , mkFactorDol.KeyPress _
        , mkFactorSol.KeyPress _
        , mkFleIntDol.KeyPress _
        , mkFleIntSol.KeyPress _
 _
        , mkGescomDol.KeyPress _
        , mkGescomSol.KeyPress _
        , mkIgv.KeyPress _
        , mkIgvAdu.KeyPress _
        , mkIpm.KeyPress _
        , mkNucleoDol.KeyPress _
        , mkNucleoSol.KeyPress _
        , mkOtroGastoDol.KeyPress _
        , mkOtroGastoSol.KeyPress _
        , mkSeguro.KeyPress _
        , mkServicio.KeyPress _
        , mkSobretasa.KeyPress _
 _
 _
        , mkTotalIgv.KeyPress _
        , mkTotFacturaDol.KeyPress _
        , mkTotFacturaSol.KeyPress _
        , mkTotFleteDol.KeyPress _
        , mkTotFleteSol.KeyPress _
        , mkTotFobDol.KeyPress _
        , mkTotFobGenDol.KeyPress _
        , mkTotFobGenSol.KeyPress _
        , mkTotFobSol.KeyPress _

        ', txtTransporte.KeyPress _
        ', mkPeso.KeyPress _
        ', , mkOtroGastos.KeyPress _
        ', mkDerAduSol.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub frmDatosImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnSalir_Click(sender, e)
        End If
    End Sub

    Private Sub txtTransporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransporte.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscarPais.Select()
        End If
    End Sub
    'Private Sub mkOtroGastos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mkOtroGastos.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        mkFleIntDol.Focus()
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub mkPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mkPeso.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPoliza.Focus()
        End If
    End Sub
    Private Sub mkDerAduSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mkDerAduSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmDatosImportacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pEstado = ObjImportacion.ObtenerEstado(pIdImportacion)
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgDetalle)
        dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgDetalle.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Deshabilitar()
        LlenarDatos()
        MostrarDetalles()
        dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]

    End Sub
    Private Sub CalcularImpuestos()

        Dim igv As Decimal
        Dim adu As Decimal
        Dim ipm As Decimal
        Dim totaligv As Decimal

        igv = mkIgv.Text
        adu = mkIgvAdu.Text
        ipm = mkIpm.Text
        totaligv = igv + adu + ipm
        mkTotalIgv.Text = ""
        mkTotalIgv.Text = totaligv

    End Sub

    Private Sub CalcularTotalGastos()

        Dim carga As Decimal
        Dim terminal As Decimal
        Dim gasto As Decimal
        Dim tranplocal As Decimal
        Dim otro As Decimal
        Dim totalAgencia As Decimal
        Dim resguardo As Decimal
        Dim pagoexterior As Decimal
        Dim Handling As Decimal
        Dim OtrosServicios As Decimal

        carga = mkCarga.Text
        terminal = mkTerminal.Text
        gasto = mkGastoAgencia.Text
        tranplocal = mkTranspLocal.Text
        otro = mkOtroGastos.Text
        resguardo = mkResguardo.Text
        pagoexterior = mkPagosExt.Text
        Handling = mkHandling.Text
        OtrosServicios = mkOtrosServ.Text

        totalAgencia = carga + terminal + gasto + tranplocal + otro + resguardo + pagoexterior + Handling + OtrosServicios
        mkTotalAgencia.Text = ""
        mkTotalAgencia.Text = totalAgencia

    End Sub

    Private Sub CalcularTotal()

        Dim totfobdol As Decimal
        Dim fleintdol As Decimal
        Dim gescomdol As Decimal
        Dim nucleodol As Decimal
        Dim otrogasdol As Decimal
        Dim totfobgendol As Decimal
        '////////////////////////////////
        'Dim totfobsol As Decimal
        'Dim fleintsol As Decimal
        'Dim gescomsol As Decimal
        'Dim nucleosol As Decimal
        'Dim otrogassol As Decimal
        Dim totfobgensol As Decimal
        '////////////////////////////////
        Dim deradudol As Decimal
        Dim totfletedol As Decimal
        Dim totfacturadol As Decimal
        '////////////////////////////////
        Dim deradusol As Decimal
        Dim totfletesol As Decimal
        Dim totfacturasol As Decimal

        totfobdol = mkTotFobDol.Text
        fleintdol = mkFleIntDol.Text
        gescomdol = mkGescomDol.Text
        nucleodol = mkNucleoDol.Text
        otrogasdol = mkOtroGastoDol.Text
        totfobgendol = totfobdol + fleintdol + gescomdol + nucleodol + otrogasdol
        mkTotFobGenDol.Text = ""
        mkTotFobGenDol.Text = totfobgendol

        'totfobsol = mkTotFobSol.Text
        'fleintsol = mkFleIntSol.Text
        'gescomsol = mkGescomSol.Text
        'nucleosol = mkNucleoSol.Text
        'otrogassol = mkOtroGastoSol.Text
        'totfobgensol = totfobsol + fleintsol + gescomsol + nucleosol + otrogassol
        'mkTotFobGenSol.Text = ""
        'mkTotFobGenSol.Text = totfobgensol
        totfobgensol = totfobgendol * mkCambio.Text
        mkTotFobGenSol.Text = ""
        mkTotFobGenSol.Text = totfobgensol


        deradudol = mkDerAduDol.Text
        totfletedol = mkTotFleteDol.Text
        totfacturadol = deradudol + totfletedol + totfobgendol
        mkTotFacturaDol.Text = ""
        mkTotFacturaDol.Text = totfacturadol

        deradusol = mkDerAduSol.Text
        totfletesol = mkTotFleteSol.Text
        totfacturasol = deradusol + totfletesol + totfobgensol
        mkTotFacturaSol.Text = ""
        mkTotFacturaSol.Text = totfacturasol

        'mkTotFobGenDol.Text = mkTotFobDol.Text + mkFleIntDol.Text + mkGescomDol.Text + mkNucleoDol.Text + mkOtroGastoDol.Text
        'mkTotFobGenSol.Text = mkTotFobSol.Text + mkFleIntSol.Text + mkGescomSol.Text + mkNucleoSol.Text + mkOtroGastoSol.Text

        'mkTotFacturaDol.Text = mkTotFobGenDol.Text + mkTotFleteDol.Text + mkDerAduDol.Text
        'mkTotFacturaSol.Text = mkTotFobGenSol.Text + mkTotFleteSol.Text + mkDerAduSol.Text

    End Sub

    Private Sub CalcularSoles()
        mkTotFobDol.Text = mkTotFobDol.Text
        mkTotFobSol.Text = mkTotFobDol.Text * mkCambio.Text
        mkFleIntDol.Text = mkFleIntDol.Text
        mkFleIntSol.Text = mkFleIntDol.Text * mkCambio.Text
        mkGescomDol.Text = mkGescomDol.Text
        mkGescomSol.Text = mkGescomDol.Text * mkCambio.Text
        mkNucleoDol.Text = mkNucleoDol.Text
        mkNucleoSol.Text = mkNucleoDol.Text * mkCambio.Text
        mkOtroGastoDol.Text = mkOtroGastoDol.Text
        mkOtroGastoSol.Text = mkOtroGastoDol.Text * mkCambio.Text
        mkTotFobGenDol.Text = mkTotFobGenDol.Text
        mkTotFobGenSol.Text = mkTotFobGenDol.Text * mkCambio.Text
        mkTotFleteDol.Text = mkTotFleteDol.Text
        mkTotFleteSol.Text = mkTotFleteDol.Text * mkCambio.Text
        'mkDerAduDol.Text = mkDerAduDol.Text
        'mkDerAduSol.Text = mkDerAduSol.Text
        'mkTotFacturaDol.Text = mkTotFacturaDol.Text
        'mkTotFacturaSol.Text = mkTotFacturaSol.Text
        CalcularTotal()

    End Sub

    Private Sub LlenarDatos()
        Try
            Importacion = ObjImportacion.MostrarPorId(pIdImportacion)
            txtNumDoc.Text = Importacion.NumDoc
            txtFecDoc.Text = Importacion.FecDoc
            txtProveedor.Text = Importacion.Proveedor.DesProv
            txtIngreso.Text = Importacion.NroIng
            IdProveedorAduana = Importacion.ProveedorAgeAdu.IdProveedor
            txtAduana.Text = Importacion.ProveedorAgeAdu.DesProv
            txtTransporte.Text = Importacion.AgeTra
            pCodPais = Importacion.Pais.CodPais
            txtOrigen.Text = Importacion.Pais.DesPais
            txtFactura.Text = Importacion.FacAdu
            'mkFecEmb.Text = IIf(Importacion.FecEmb Is Nothing, Today, Importacion.FecEmb)
            'mkFecLle.Text = IIf(Importacion.FecLle Is Nothing, Today, Importacion.FecLle)
            mkVia.Text = Importacion.Medio
            mkPtoEmb.Text = Importacion.PtoEmbarque
            mkCambio.Text = Importacion.TipCam
            mkPeso.Text = Importacion.PesBru

            mkTotFobDol.Text = Importacion.TotFob
            mkTotFobSol.Text = Importacion.TotFob * Importacion.TipCam
            mkFleIntDol.Text = Importacion.TotPreFle
            mkFleIntSol.Text = Importacion.TotPreFle * Importacion.TipCam
            mkGescomDol.Text = Importacion.TotPreGes
            mkGescomSol.Text = Importacion.TotPreGes * Importacion.TipCam
            mkNucleoDol.Text = Importacion.TotDptoNucleo
            mkNucleoSol.Text = Importacion.TotDptoNucleo * Importacion.TipCam
            mkOtroGastoDol.Text = Importacion.TotOtroGasto
            mkOtroGastoSol.Text = Importacion.TotOtroGasto * Importacion.TipCam
            mkTotFobGenDol.Text = Importacion.TotFobGen
            mkTotFobGenSol.Text = Importacion.TotFobGen * Importacion.TipCam
            mkTotFleteDol.Text = Importacion.TotFlete
            mkTotFleteSol.Text = Importacion.TotFlete * Importacion.TipCam
            mkDerAduDol.Text = Importacion.TotDerAduDol
            mkDerAduSol.Text = Importacion.TotDerAduSol
            mkTotFacturaDol.Text = Importacion.TotalNeto
            mkTotFacturaSol.Text = Importacion.TotalNetoSol

            txtPoliza.Text = Importacion.Poliza
            mkIgv.Text = Importacion.Igv
            mkIpm.Text = Importacion.Ipm
            mkIgvAdu.Text = Importacion.IgvAdu
            mkTotalIgv.Text = Importacion.TotalIgv
            mkAdvalorem.Text = Importacion.AdValorem
            mkServicio.Text = Importacion.Servicio
            mkSobretasa.Text = Importacion.SobTasa
            mkSeguro.Text = Importacion.Seguro
            txtGuia.Text = Importacion.Guia
            mkCarga.Text = Importacion.CarDes
            mkTerminal.Text = Importacion.TerAlm
            mkGastoAgencia.Text = Importacion.GasAdu
            mkTranspLocal.Text = Importacion.TraLoc
            mkOtroGastos.Text = Importacion.OtroGasto
            mkResguardo.Text = Importacion.Resguardo
            mkPagosExt.Text = Importacion.PagosExterior
            mkHandling.Text = Importacion.Handling
            mkOtrosServ.Text = Importacion.OtrosServicios
            mkTotalAgencia.Text = Importacion.CarDes + Importacion.TerAlm + Importacion.GasAdu + Importacion.TraLoc + Importacion.OtroGasto + Importacion.Resguardo + Importacion.Handling
            ' Aumentado el Seguro
            ckApliSeg.Checked = Importacion.ApliSeguro
            txtSeguro.Text = Importacion.PorApliSeguro
            lblEstado.Text = Importacion.Estado
            mkPercepcion.Text = Importacion.Percepcion
            mkMultas.Text = Importacion.Multas

            If pEstado = "CH" Or pEstado = "TR" Then
                btnModificar.Enabled = True
                btnRecostear.Enabled = True
                btnRecalcular.Enabled = True
                cmRecalcular.Enabled = True
                cmModificar.Enabled = True
            Else
                btnModificar.Enabled = False
                btnRecostear.Enabled = False
                btnRecalcular.Enabled = False
                cmRecalcular.Enabled = False
                cmModificar.Enabled = False
            End If
            mkFactorDol.Text = Importacion.FactorDol
            mkFactorSol.Text = Importacion.FactorSol
            txtObservacion.Text = Importacion.Observacion
            'MostrarDetalles()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub MostrarDetalles()
        Try
            dgDetalle.DataSource = Nothing
            dtDetalle = ObjImportadionDet.Mostrar(pIdImportacion).Tables(0)
            dgvDatos.DataSource = dtDetalle
            Me.dgDetalle.SetDataBinding(dtDetalle, 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgDetalle.RowCount > 0 Then
            codigo = dgDetalle.CurrentRow.Cells("IdDetImportacion").Text
        End If
        dtDetalle = Nothing
        MostrarDetalles()
        If dgDetalle.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgDetalle, codigo)
        End If
        ' enableOpciones()
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdDetImportacion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Habilitar()
        txtIngreso.ReadOnly = False
        'txtAduana.ReadOnly = False
        btnBuscarProveedor.Enabled = True
        txtTransporte.ReadOnly = False
        txtFactura.ReadOnly = False
        'mkFecEmb.Enabled = True
        'mkFecLle.Enabled = True
        mkVia.Enabled = True
        mkPtoEmb.ReadOnly = False
        mkCambio.Enabled = True
        mkPeso.Enabled = True
        mkFleIntDol.Enabled = True
        mkGescomDol.Enabled = True
        'mkNucleoDol.Enabled = True
        mkOtroGastoDol.Enabled = True
        mkTotFleteDol.Enabled = True
        mkDerAduDol.Enabled = True
        mkDerAduSol.Enabled = True
        txtPoliza.ReadOnly = False
        mkIgv.Enabled = True
        mkIpm.Enabled = True
        mkIgvAdu.Enabled = True
        mkAdvalorem.Enabled = True
        mkServicio.Enabled = True
        mkSobretasa.Enabled = True
        mkSeguro.Enabled = True
        txtGuia.ReadOnly = False
        mkCarga.Enabled = True
        mkTerminal.Enabled = True
        mkGastoAgencia.Enabled = True
        mkTranspLocal.Enabled = True
        mkOtroGastos.Enabled = True
        mkResguardo.Enabled = True
        mkPagosExt.Enabled = True
        mkHandling.Enabled = True
        mkOtrosServ.Enabled = True
        mkPercepcion.Enabled = True
        mkMultas.Enabled = True
        btnBuscarPais.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnCancelar.Enabled = True
        btnRecostear.Enabled = False
        btnRecalcular.Enabled = False
        dgDetalle.Enabled = False
        '
        ckApliSeg.Enabled = True
        txtSeguro.ReadOnly = False
    End Sub

    Private Sub Deshabilitar()
        txtIngreso.ReadOnly = True
        'txtAduana.ReadOnly = True
        btnBuscarProveedor.Enabled = False
        txtTransporte.ReadOnly = True
        txtFactura.ReadOnly = True
        'mkFecEmb.Enabled = False
        'mkFecLle.Enabled = False
        mkVia.Enabled = False
        mkPtoEmb.ReadOnly = True
        mkCambio.Enabled = False
        mkPeso.Enabled = False
        mkFleIntDol.Enabled = False
        mkGescomDol.Enabled = False
        mkNucleoDol.Enabled = False
        mkOtroGastoDol.Enabled = False
        mkTotFleteDol.Enabled = False
        mkDerAduDol.Enabled = False
        mkDerAduSol.Enabled = False
        txtPoliza.ReadOnly = True
        mkIgv.Enabled = False
        mkIpm.Enabled = False
        mkIgvAdu.Enabled = False
        mkAdvalorem.Enabled = False
        mkServicio.Enabled = False
        mkSobretasa.Enabled = False
        mkSeguro.Enabled = False
        txtGuia.ReadOnly = True
        mkCarga.Enabled = False
        mkTerminal.Enabled = False
        mkGastoAgencia.Enabled = False
        mkTranspLocal.Enabled = False
        mkOtroGastos.Enabled = False
        mkResguardo.Enabled = False
        mkPagosExt.Enabled = False
        mkHandling.Enabled = False
        mkOtrosServ.Enabled = False
        mkPercepcion.Enabled = False
        mkMultas.Enabled = False
        btnBuscarPais.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnCancelar.Enabled = False
        btnRecostear.Enabled = True
        btnRecalcular.Enabled = True
        dgDetalle.Enabled = True
        ckApliSeg.Enabled = False
        txtSeguro.ReadOnly = True
    End Sub

    Private Sub btnBuscarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPais.Click
        ''Dim forma As New frmBuscarPais
        ''forma.MdiParent = Me.MdiParent
        ''forma.Show()

        'frmBuscarOrigen.Owner = Me
        'frmBuscarOrigen.ShowInTaskbar = False
        'frmBuscarOrigen.ShowDialog()
        'txtOrigen.Select()
        Dim frm As New frmBuscarPais
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtOrigen.Text = frm.descripcion
            txtOrigen.BackColor = System.Drawing.SystemColors.Control
            pCodPais = frm.codigo

        End If
        txtOrigen.Select()
    End Sub

    Private Sub cmMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmMostrar.Click, dgDetalle.DoubleClick
        If dtDetalle.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmImportacionDet
            forma.pIdDetImportacion = dgDetalle.CurrentRow.Cells(0).Text()
            forma.ShowDialog(Me)
        End If
    End Sub

    Private Sub cmRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmRefrescar.Click
        Actualizar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If pEstado = "CH" Or pEstado = "TR" Then
            Habilitar()
        Else
            MsgBox("No se puede modificar la factura", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
            Try
                Dim Registro As New ImportacionService.Importacion
                Dim Proveedor As New ImportacionService.Proveedor
                Dim ProveedorAduana As New ImportacionService.Proveedor
                Dim SerieDoc As New ImportacionService.SerieDocumento
                Dim Pais As New ImportacionService.Pais

                Registro.IdImportacion = pIdImportacion
                SerieDoc.IdSerieDoc = Importacion.SerieDocumento.IdSerieDoc
                Registro.SerieDocumento = SerieDoc
                Registro.NumDoc = txtNumDoc.Text
                Registro.FecDoc = txtFecDoc.Text
                Proveedor.IdProveedor = Importacion.Proveedor.IdProveedor
                Registro.Proveedor = Proveedor
                Registro.NroIng = txtIngreso.Text

                ProveedorAduana.IdProveedor = IIf(IdProveedorAduana = 0, Nothing, IdProveedorAduana)
                Registro.ProveedorAgeAdu = ProveedorAduana
                Registro.AgeTra = txtTransporte.Text
                Pais.CodPais = pCodPais
                Registro.Pais = Pais
                Registro.FacAdu = txtFactura.Text
                Registro.FecEmb = CDate(DateAdd("m", -1, txtFecDoc.Text))
                'Registro.FecEmb = CDate(Mid(txtFecDoc.Text, 1, 2) & "/" & IIf((Month(CDate(txtFecDoc.Text)) = 1), "12", (Month(CDate(txtFecDoc.Text)) - 1)) & "/" & IIf((Month(CDate(txtFecDoc.Text)) = 1), Year(CDate(txtFecDoc.Text)) - 1, Year(CDate(txtFecDoc.Text))))
                Registro.FecEmb = txtFecDoc.Text
                Registro.FecLle = txtFecDoc.Text
                Registro.Medio = mkVia.Text
                Registro.PtoEmbarque = mkPtoEmb.Text
                Registro.TipCam = mkCambio.Text
                Registro.PesBru = mkPeso.Text
                Registro.TotFob = mkTotFobDol.Text
                Registro.TotPreFle = mkFleIntDol.Text
                Registro.TotPreGes = mkGescomDol.Text
                Registro.TotDptoNucleo = mkNucleoDol.Text
                Registro.TotOtroGasto = mkOtroGastoDol.Text
                Registro.TotFobGen = mkTotFobGenDol.Text
                Registro.TotFlete = mkTotFleteDol.Text
                Registro.TotDerAduDol = mkDerAduDol.Text
                Registro.TotDerAduSol = mkDerAduSol.Text
                Registro.Poliza = txtPoliza.Text
                Registro.Igv = mkIgv.Text
                Registro.Ipm = mkIpm.Text
                Registro.IgvAdu = mkIgvAdu.Text
                Registro.AdValorem = mkAdvalorem.Text
                Registro.Servicio = mkServicio.Text
                Registro.SobTasa = mkSobretasa.Text
                Registro.Seguro = mkSeguro.Text
                Registro.Guia = txtGuia.Text
                Registro.CarDes = mkCarga.Text
                Registro.TerAlm = mkTerminal.Text
                Registro.GasAdu = mkGastoAgencia.Text
                Registro.TraLoc = mkTranspLocal.Text
                Registro.OtroGasto = mkOtroGastos.Text
                Registro.Resguardo = mkResguardo.Text
                Registro.PagosExterior = mkPagosExt.Text
                Registro.Handling = mkHandling.Text
                Registro.OtrosServicios = mkOtrosServ.Text
                Registro.Percepcion = mkPercepcion.Text
                Registro.Multas = mkMultas.Text

                Registro.CodUsu = Session.sCodUsu
                Registro.NomPc = Session.sNomPc
                Registro.DirIp = Session.sDirIp

                Registro.Observacion = txtObservacion.Text

                If ckApliSeg.Checked = True Then
                    If txtSeguro.Text <> 0 Then
                        Registro.ApliSeguro = True
                        Registro.PorApliSeguro = txtSeguro.Text
                    Else
                        MsgBox("Debe ingresar el porcentaje del Seguro a aplicar", MsgBoxStyle.Information)
                    End If
                Else
                    Registro.ApliSeguro = False
                    txtSeguro.Text = 0.0
                End If
                ObjImportacion.Actualizar(Registro)
                Deshabilitar()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                MostrarDetalles()
                LlenarDatos()
                MsgBox("Se Grabó correctamente", MsgBoxStyle.Information)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub rbCambio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckApliSeg.CheckedChanged
        'If ckApliSeg.Checked = True Then
        '    If ckApliSeg.Enabled = True Then
        '        txtSeguro.Enabled = True
        '    Else
        '        txtSeguro.Enabled = False
        '    End If

        'End If
        'If ckApliSeg.Checked = False Then
        '    If ckApliSeg.Enabled = False Then
        '        txtSeguro.Enabled = False
        '    Else
        '        txtSeguro.Enabled = True
        '    End If
        'End If
        If ckApliSeg.Checked = True Then
            txtSeguro.Select()
            txtSeguro.Enabled = True
        End If
        If ckApliSeg.Checked = False Then
            txtSeguro.Enabled = False
            txtSeguro.Text = 0.0
        End If
    End Sub
    Private Sub btnRecostear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecostear.Click
        If MsgBox("¿Está seguro de CERRAR el costo de la Factura?", MsgBoxStyle.YesNo, "Recostear Factura") = MsgBoxResult.Yes Then
            Try
                ObjImportacion.Recostear(pIdImportacion, Session.sCodUsu)
                MsgBox("Se Cerró el Costo de la factura correctamente", MsgBoxStyle.Information, "Final Exitoso")
                LlenarDatos()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Deshabilitar()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmModificar.Click
        If dtDetalle.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmImportacionDet
            forma.pIdDetImportacion = dgDetalle.CurrentRow.Cells(0).Text()
            If pEstado = "CH" Or pEstado = "TR" Then
                forma.Habilitar()
                forma.btnGuardar.Enabled = True
                forma.btnGuardar.Visible = True
                'forma.ShowDialog(Me)
                If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    LlenarDatos()
                    Actualizar()
                End If
            Else
                MsgBox("No se puede modificar, tenga cuidado.!!!!", MsgBoxStyle.Information, "No esta Modificable")
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpFacturaImport
            Dim dtReporte As New DataTable
            dtReporte = ObjImportacion.ReporteFactura(pIdImportacion).Tables(0)
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

                forma.Text = "Reporte de Factura de Importación"
                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtFactura.WriteXmlSchema("D:\Proyecto\Codigo\SIGECOM\Cliente\Reportes\OrigenDatos\Importaciones.xml")
                'reporte.SetParameterValue("NumDoc", Importacion.NumDoc)
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub mkDerAduDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkDerAduDol.Validating
        mkDerAduSol.Text = mkDerAduDol.Text * mkCambio.Text
        CalcularTotal()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub mkNucleoDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkNucleoDol.Validating
        mkNucleoSol.Text = mkNucleoDol.Text * mkCambio.Text
        CalcularTotal()
    End Sub

    Private Sub mkOtroGastoDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkOtroGastoDol.Validating
        mkOtroGastoSol.Text = mkOtroGastoDol.Text * mkCambio.Text
        CalcularTotal()
    End Sub

    Private Sub mkGescomDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkGescomDol.Validating
        mkGescomSol.Text = mkGescomDol.Text * mkCambio.Text
        CalcularTotal()
    End Sub

    Private Sub mkFleIntDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkFleIntDol.Validating
        mkFleIntSol.Text = mkFleIntDol.Text * mkCambio.Text
        CalcularTotal()
    End Sub

    Private Sub mkTotFleteDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkTotFleteDol.Validating
        mkTotFleteSol.Text = mkTotFleteDol.Text * mkCambio.Text
        CalcularTotal()
    End Sub

    Private Sub mkIgv_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkIgv.Validating
        CalcularImpuestos()
    End Sub

    Private Sub mkIpm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkIpm.Validating
        CalcularImpuestos()
    End Sub

    Private Sub mkIgvAdu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkIgvAdu.Validating
        CalcularImpuestos()
    End Sub

    Private Sub btnRecalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalcular.Click, cmRecalcular.Click
        Try
            If MsgBox("¿Está seguro de hacer un recalculo previo de costos a la Factura?", MsgBoxStyle.YesNo, "Recalcular") = MsgBoxResult.Yes Then
                If ObjImportacion.Recalcular(pIdImportacion) Then
                    'MostrarDetalles()
                    Actualizar()
                    MsgBox("Se Realizó el recalculo previo de los costos", MsgBoxStyle.Information, "Recalculo Exitoso")
                Else
                    MsgBox("Hubo Problemas en el recalculo, comunicarse con sistemas", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Recalculo")
        End Try
    End Sub

    Private Sub mkCarga_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        CalcularTotalGastos()
    End Sub

    Private Sub mkTerminal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        CalcularTotalGastos()
    End Sub

    Private Sub mkGastoAgencia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        CalcularTotalGastos()
    End Sub

    Private Sub mkTranspLocal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        CalcularTotalGastos()
    End Sub

    Private Sub mkOtroGastos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        CalcularTotalGastos()
    End Sub

    Private Sub mkCambio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mkCambio.Validating
        CalcularSoles()
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim Export As Boolean
        If dtDetalle.Rows.Count > 0 Then
            Export = ExportarExcel(dgvDatos)
            If Export Then
                MsgBox("Se realizó la exportación correctamente ")
            End If
        Else
            MsgBox("No hay datos que exportar. Verifique!!!")
        End If

    End Sub

    Private Sub dgDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            cmMostrar_Click(sender, e)
        End If
    End Sub

    Private Sub mkOtrosServ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            mkFleIntDol.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedorAduana = frm.codigo
                    txtAduana.Text = frm.descripcion
                    'cmbCondPago.Focus()
                Else
                    IdProveedorAduana = 0
                    txtAduana.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnMostrarGastos_Click(sender As Object, e As EventArgs) Handles btnMostrarGastos.Click
        Try



            Dim frm As New frmImportacion_GastosImportacion
            frm.idImportacion = pIdImportacion
            frm.Text = "Gastos de Importación de la factura : " & txtNumDoc.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class