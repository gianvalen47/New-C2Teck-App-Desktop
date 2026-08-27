Imports System.ServiceModel
Public Class frmEmbarqueValorizar

    '===========================Servicios====================================================
    Private oImportacionService As New EmbarqueService.EmbarqueServiceClient
    Private oImportacionDetService As New EmbarqueDetService.EmbarqueDetServiceClient
    'Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtFacturas As DataTable

    Private dtProveedores As DataTable
    Private dtVia As DataTable
    Private dtEstados As DataTable

    Private IdImportacion As Integer
    Private IdSerieDoc As Integer    
    Private IdLocacion As Integer
    Private NumDoc As String
    Private DesAlm As String
    Private FecDoc As Date
    Private IdProveedor As Integer
    Private DesProv As String
    Private CodMon As String
    Private DesMon As String
    Private TipCam As Double
    Private Observacion As String
    Private TotFobGen As Double
    Private TotFobGenSol As Double
    Private TotalNeto As Double
    Private TotalNetoSol As Double
    Private Estado As String
    Private IdProveedorAduana As Integer = 0

    Public pCodPais As String = Nothing

    Private Sub frmValorizarFIMasivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarCombos()



    End Sub

    Private Sub frmValorizarFIMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmValorizarFIMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()
            '       oPedidoImportService.Close()
            oImportacionDetService.Close()
        Catch ex As TimeoutException
            oImportacionService.Abort()
            '      oPedidoImportService.Abort()
            oImportacionDetService.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            '     oPedidoImportService.Abort()
            oImportacionDetService.Abort()
        End Try
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
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
           
         
            '============================================ VÍA =====================================================
            dtVia = New DataTable
            dtVia.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtVia.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtVia.Rows.Add(New Object() {"1", "Maritima"})
            dtVia.Rows.Add(New Object() {"2", "Aerea"})

            cmbVia.DataSource = dtVia
            cmbVia.DropDownList.DataMember = dtVia.Columns("nombre").ToString
            cmbVia.DropDownList.DisplayMember = dtVia.Columns("nombre").ToString
            cmbVia.DropDownList.ValueMember = dtVia.Columns("nombre").ToString
            cmbVia.DropDownList.Columns(0).DataMember = dtVia.Columns("codigo").ToString
            cmbVia.DropDownList.Columns(1).DataMember = dtVia.Columns("nombre").ToString
            cmbVia.SelectedIndex = 0
            dtVia = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Public Sub listaDatos()
        Try

            '===================================== LISTA FACTURAS ======================================
            dtFacturas = oImportacionDetService.Mostrar(txtCodEmbarque.Text).Tables(0)
            dgvFacturas.DataSource = dtFacturas


            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dtFacturas.Rows.Count() > 0 Then
                btnAceptar.Enabled = True

            Else
                btnAceptar.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) ''Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvFacturas.RowCount < 1 Then
                MsgBox("No hay Facturas que valorizar", MsgBoxStyle.Information, "Información")
                dgvFacturas.Focus()
                Return False
            ElseIf toBlank(txtNumRegistro.Text) = "" Then
                MsgBox("Debe Ingresar el número de registro.", MsgBoxStyle.Information, "Información")
                txtNumRegistro.Focus()
                Return False
            ElseIf toBlank(txtCodEmbarque.Text) = "" Then
                MsgBox("Debe Ingresar el numero de embarque.", MsgBoxStyle.Information, "Información")
                txtCodEmbarque.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPais.Click
        Dim frm As New frmBuscarPais
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtOrigen.Text = frm.descripcion
            txtOrigen.BackColor = System.Drawing.SystemColors.Control
            pCodPais = frm.codigo
        End If
        txtOrigen.Select()
    End Sub

    Private Sub frmImportacionDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              txtNumRegistro.KeyPress _
            , txtAduana.KeyPress _
            , txtTransporte.KeyPress _
            , txtOrigen.KeyPress _
            , txtFactura.KeyPress _
            , cmbVia.KeyPress _
            , txtPtoEmb.KeyPress _
            , txtGuia.KeyPress _
            , txtPoliza.KeyPress _
            , txtTipCambio.KeyPress _
            , txtIgv.KeyPress _
            , txtIPM.KeyPress _
        , txtPercepcion.KeyPress _
        , txtMultas.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de VALORIZAR la(s) Factura(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim Registro As New EmbarqueService.Importacion
                Dim ProveedorAduana As New EmbarqueService.Proveedor
                Dim SerieDoc As New EmbarqueService.SerieDocumento
                Dim Pais As New EmbarqueService.Pais

                Registro.IdImportacion = IdImportacion
                Registro.NroIng = txtNumRegistro.Text

                ProveedorAduana.IdProveedor = IdProveedorAduana
                Registro.ProveedorAgeAdu = ProveedorAduana

                Registro.AgeTra = txtTransporte.Text
                Pais.CodPais = pCodPais
                Registro.Pais = Pais
                Registro.FacAdu = txtFactura.Text
                Registro.Medio = cmbVia.Text
                Registro.PtoEmbarque = txtPtoEmb.Text
                Registro.Poliza = txtPoliza.Text
                Registro.TipCam = txtTipCambio.Text

                Registro.Guia = txtGuia.Text

                Registro.Igv = txtIgv.Value
                Registro.IgvAdu = 0
                Registro.Servicio = 0
                Registro.Ipm = txtIPM.Value
                'Registro.CarDes = txtCarga.Value
                'Registro.TerAlm = txtTerminal.Value
                'Registro.GasAdu = txtGastoAgencia.Value
                'Registro.TraLoc = txtTranspLocal.Value
                'Registro.OtroGasto = txtOtroGastos.Value
                'Registro.Resguardo = txtResguardo.Value
                'Registro.Handling = txtHandling.Value
                'Registro.TotOtroGasto = txtTotOtrosGastos.Value

                Registro.Percepcion = txtPercepcion.Value
                Registro.Multas = txtMultas.Value

                Registro.TotFlete = txtTotFleteSol.Value
                Registro.CodUsu = Session.sCodUsu
                Registro.NomPc = Session.sNomPc
                Registro.DirIp = Session.sDirIp

                oImportacionService.ValorizarFactura(Registro, txtCodEmbarque.Text)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK


            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALORIZAR FACTURAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

            If toBlank(txtCodEmbarque.Text) = "" Then
                MsgBox("Debe Ingresar el numero de embarque.", MsgBoxStyle.Information, "Información")
                txtCodEmbarque.Focus()
                Return
            End If

            Dim frm As New frmEmbarque_GastosImportacion
            frm.CodEmbarque = txtCodEmbarque.Text
            frm.Text = "Gastos de Importación del Embarque : " & txtCodEmbarque.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class