Imports System.ServiceModel
Public Class frmGenerarAsientoDUA

    '===========================Servicios====================================================
    Private oImportacionService As New ImportacionService.ImportacionServiceClient


    '======================Declaración de Variables==============================================


    Private dtMeses As DataTable


    Private IdProveedor As Integer
    Private DesProv As String
    Public dtDetalles As DataTable


    Private Sub frmValorizarFIMasivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        LlenarCombos()
        txtAnio.Value = Today.Year
        Dim mesactual As String
        'Dim mesactualint As Integer
        If Len(CStr(Today.Month)) = 1 Then
            mesactual = "0" & Today.Month
        Else
            mesactual = Today.Month
        End If
        cmbMes.Value = mesactual
        txtFecha.Value = Today
        txtCodEmbarque.Select()

    End Sub

    Private Sub frmValorizarFIMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmValorizarFIMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()

        Catch ex As TimeoutException
            oImportacionService.Abort()

        Catch ex As CommunicationException
            oImportacionService.Abort()

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


            dtMeses = New DataTable
            dtMeses.Columns.Add(New DataColumn("Codigo", Type.GetType("System.String")))
            dtMeses.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            dtMeses.Rows.Add(New Object() {"01", "ENERO"})
            dtMeses.Rows.Add(New Object() {"02", "FEBRERO"})
            dtMeses.Rows.Add(New Object() {"03", "MARZO"})
            dtMeses.Rows.Add(New Object() {"04", "ABRIL"})
            dtMeses.Rows.Add(New Object() {"05", "MAYO"})
            dtMeses.Rows.Add(New Object() {"06", "JUNIO"})
            dtMeses.Rows.Add(New Object() {"07", "JULIO"})
            dtMeses.Rows.Add(New Object() {"08", "AGOSTO"})
            dtMeses.Rows.Add(New Object() {"09", "SETIEMBRE"})
            dtMeses.Rows.Add(New Object() {"10", "OCTUBRE"})
            dtMeses.Rows.Add(New Object() {"11", "NOVIEMBRE"})
            dtMeses.Rows.Add(New Object() {"12", "DICIEMBRE"})



            '======================================= MESES ================================================
            'dtMeses = oMaestroService.MostrarMeses
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            dtDetalles = oImportacionService.MostrarDUA(txtCodEmbarque.Text).Tables(0)
            txtTipCambio.Value = dtDetalles.Rows(0).Item("TipCam")
            txtDerechosAduDol.Value = dtDetalles.Rows(0).Item("TotAduanaDol")
            txtDerechosSol.Value = dtDetalles.Rows(0).Item("TotAduanaSol")
            txtAdvaloremDol.Value = dtDetalles.Rows(0).Item("TotAdvaloremDol")
            txtAdvaloremSol.Value = dtDetalles.Rows(0).Item("TotAdvaloremSol")
            txtImpuestosDol.Value = dtDetalles.Rows(0).Item("TotalIgvDol")
            txtImpuestosSol.Value = dtDetalles.Rows(0).Item("TotalIgvSol")
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub frmImportacionDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtSerDoc.KeyPress _
            , txtNumDoc.KeyPress _
            , txtTipCambio.KeyPress _
            , txtDerechosAduDol.KeyPress _
            , txtDerechosSol.KeyPress _
            , txtAdvaloremDol.KeyPress _
            , txtAdvaloremSol.KeyPress _
            , txtImpuestosDol.KeyPress _
            , txtImpuestosSol.KeyPress _
        , btnBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtCodEmbarque.Text = "" Then
                MsgBox("Debe Ingresar el Código de Embarque.", MsgBoxStyle.Information, "Información")
                txtCodEmbarque.Focus()
                Return False
            ElseIf txtSerDoc.Text = "" Then
                MsgBox("Debe Ingresar la serie del documento.", MsgBoxStyle.Information, "Información")
                txtSerDoc.Focus()
                Return False
            ElseIf txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar el numero del documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toDouble(txtDerechosAduDol.Value) <= 0 Then
                MsgBox("El Monto Dolares no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtDerechosAduDol.Focus()
                Return False
            ElseIf toDouble(txtImpuestosDol.Value) <= 0 Then
                MsgBox("El Monto IGV Dolares no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtImpuestosDol.Focus()
                Return False
            ElseIf toDouble(txtAdvaloremDol.Value) <= 0 Then
                MsgBox("El Monto de advalorem no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtAdvaloremDol.Focus()
                Return False
            ElseIf IdProveedor = 0 Then
                MsgBox("Debe Ingresar el proveedor.", MsgBoxStyle.Information, "Información")
                btnBuscarProveedor.Focus()
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

            If MsgBox("¿Desea Generar el Asiento DUA... ?", MsgBoxStyle.YesNo, "Generar") = MsgBoxResult.Yes And ValidaCampos() Then
                Dim m As New ImportacionService.RegistroCompra
                Dim empresa As New ImportacionService.Empresa
                Dim condicion As New ImportacionService.CondicionPagoProveedor
                Dim proveedor As New ImportacionService.Proveedor
                Dim moneda As New ImportacionService.Moneda
                Dim tipoDocumento As New ImportacionService.TipoDocumento
                empresa.CodEmp = Session.sCodEmp
                m.Empresa = empresa
                m.Periodo = txtAnio.Value
                m.Mes = cmbMes.Value
                'm.NumRegistro = "000001"
                m.Fecha = txtFecha.Value
                m.FecDoc = txtFecha.Value
                condicion.IdCondicion = 1
                m.CondicionPagoProveedor = condicion
                m.FecVen = txtFecha.Value
                tipoDocumento.IdDocumento = 47
                m.TipoDocumento = tipoDocumento
                m.SerDoc = txtSerDoc.Text
                m.NumDoc = txtNumDoc.Text
                m.TipCam = txtTipCambio.Value
                moneda.CodMon = "US"
                m.Moneda = moneda
                proveedor.IdProveedor = IdProveedor
                m.Proveedor = proveedor
                m.AfectoIgv = True
                m.Proveedor.DesProv = txtProveedor.Text
                m.Glosa = txtGlosa.Text
                m.CodUsu = Session.sCodUsu
                m.NomPc = Session.sNomPc
                m.DirIp = Session.sDirIp

                If oImportacionService.GenerarAsientoDUA(m, txtCodEmbarque.Text, txtDerechosAduDol.Value, txtDerechosSol.Value, txtAdvaloremDol.Value, txtAdvaloremSol.Value, txtImpuestosDol.Value, txtImpuestosSol.Value) > 0 Then
                    MsgBox("Se genero el asiento correctamente", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
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
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    'cmbCondPago.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumDoc_Validated(sender As Object, e As EventArgs) Handles txtNumDoc.Validated
        If Len(Trim(txtNumDoc.Text)) > 0 Then
            Dim cant As Integer = Len(txtNumDoc.Text)
            Do While cant < 8
                txtNumDoc.Text = "0" & txtNumDoc.Text
                cant = cant + 1
            Loop

        End If
    End Sub

    Private Sub txtDerechosAduDol_ValueChanged(sender As Object, e As EventArgs) Handles txtDerechosAduDol.ValueChanged

        txtDerechosSol.Value = Math.Round((txtDerechosAduDol.Value * txtTipCambio.Value), 2)

    End Sub

    Private Sub txtImpuestosDol_ValueChanged(sender As Object, e As EventArgs) Handles txtImpuestosDol.ValueChanged
        txtImpuestosSol.Value = Math.Round((txtImpuestosDol.Value * txtTipCambio.Value), 2)

    End Sub

    Private Sub txtAdvaloremDol_ValueChanged(sender As Object, e As EventArgs) Handles txtAdvaloremDol.ValueChanged
        txtAdvaloremSol.Value = Math.Round((txtAdvaloremDol.Value * txtTipCambio.Value), 2)

    End Sub

    Private Sub txtSerDoc_Validated(sender As Object, e As EventArgs) Handles txtSerDoc.Validated
        If Len(Trim(txtSerDoc.Text)) > 0 Then
            Dim cant As Integer = Len(txtSerDoc.Text)
            Do While cant < 4
                txtSerDoc.Text = "0" & txtSerDoc.Text
                cant = cant + 1
            Loop
            txtNumDoc.Focus()
        End If

    End Sub

    Private Sub txtCodEmbarque_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodEmbarque.KeyUp
        If e.KeyCode = Keys.Enter Then
            'e.Handled = True
            'SendKeys.Send("{TAB}")
            btnBuscar.Select()
        End If
    End Sub
End Class