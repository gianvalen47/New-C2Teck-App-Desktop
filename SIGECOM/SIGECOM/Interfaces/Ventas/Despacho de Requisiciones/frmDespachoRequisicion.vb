Imports System.Windows.Forms

Public Class frmDespachoRequisicion

  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
  Private oRequisicionService As New RequisicionService.RequisicionServiceClient
  Private oRequisicionDetService As New RequisicionDetService.RequisicionDetServiceClient
  Private dtDatos As DataTable
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Public IdRequisicion As Integer
  Public IdLocacion As Integer
  Private IdCliente As Integer

  Private dtMonedas As DataTable
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
  Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          txtObservacion.KeyPress _
                        , txtIgv.KeyPress _
                        , cmbCodMon.KeyPress _
                        , txtTipoCambio.KeyPress _
                        , txtCliente.KeyPress _
                        , txtalmacen.KeyPress _
                        , txtFecDoc.KeyPress _
                        , txtNumOrden.KeyPress _
                        , txtTotalNeto.KeyPress _
                        , txtTotalIGV.KeyPress _
                        , txtTotalPrecio.KeyPress _
                        , txtTotalDescuento.KeyPress _
                        , txtTotal.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{TAB}")
    End If
    End Sub

    Private Sub frmDespachoRequisicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.CancelButton = Me.btnCancelar

    Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
    If state_button Then    'Modificar
      ObtenerRegistro()
      gbEstado.Visible = True
            listaDatos()
      txtNumOrden.ReadOnly = True
      Me.Text = "Despacho de Requisiciones Nº " + Chr(34) + txtNumOrden.Text.ToString + Chr(34)
    End If
  End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oRequisicionService) = False Then
        oRequisicionService.Close()
      End If
      If isClosed(oRequisicionDetService) = False Then
        oRequisicionDetService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                          txtObservacion.KeyUp _
                        , txtIgv.KeyUp _
                        , txtTipoCambio.KeyUp _
                        , txtCliente.KeyUp _
                        , txtalmacen.KeyUp _
                        , txtFecDoc.KeyUp _
                        , txtNumOrden.KeyUp _
                        , txtTotalNeto.KeyUp _
                        , txtTotalIGV.KeyUp _
                        , txtTotalPrecio.KeyUp _
                        , txtTotalDescuento.KeyUp _
                        , txtTotal.KeyUp
    Try
      Dim campo As New Object
      If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
        campo = New Janus.Windows.GridEX.EditControls.EditBox
      ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
        campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
      ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
        campo = New TextBox
      End If
      campo = sender
      If campo.readonly = False Then
        If campo.Text.Trim.Length > 0 Then
          campo.BackColor = Color.White
        Else
          campo.BackColor = Color.Red
        End If
      End If
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub
  Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumOrden.KeyPress
    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
      e.KeyChar = Chr(0)
    End If
  End Sub
  Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
    Try
      tabla.DefaultView.Sort = nombreCampo
      lista.Row = dtDatos.DefaultView.Find(codigo)
    Catch ex As Exception
      MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
    End Try
  End Sub
  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Sub ObtenerRegistro()
    Try
      Dim registro As RequisicionService.Requisicion
      registro = oRequisicionService.MostrarPorId(IdRequisicion)

      IdRequisicion = registro.IdRequisicion
      IdLocacion = registro.Locacion.IdLocacion
      txtalmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
      txtFecDoc.Text = registro.FecDoc
      txtNumOrden.Text = registro.NumOrden
      IdCliente = registro.Cliente.IdCliente
      txtCliente.Text = registro.Cliente.DesCli
      cmbCodMon.Value = registro.Moneda.CodMon
      txtIgv.Text = registro.Igv
      txtObservacion.Text = registro.Observacion
      lblEstado.Text = registro.Estado

    Catch ex As Exception
      MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub llenarCombos()
    Try
      '======================================= MONEDAS ================================================
      dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
      cmbCodMon.DataSource = dtMonedas
      cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
      cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
      cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
      cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
      cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
      dtMonedas = Nothing
    Catch ex As Exception
      MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub listaDatos()
    Try
      dtDatos = oRequisicionDetService.Mostrar(toNumber(IdRequisicion)).Tables(0)
      dgvDatos.SetDataBinding(dtDatos, 0)

      txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Requisicion", "TotBruto", "IdRequisicion", IdRequisicion)
      txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Requisicion", "TotDscto", "IdRequisicion", IdRequisicion)
      txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Requisicion", "TotVenta", "IdRequisicion", IdRequisicion)
      txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Requisicion", "TotIgv", "IdRequisicion", IdRequisicion)
      txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Requisicion", "TotNeto", "IdRequisicion", IdRequisicion)
      lblTotal.Text = "SUB TOTALES"
      lbltotalIGV.Text = "IGV"
      lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Ventas.Requisicion", "CodMon", "IdRequisicion", IdRequisicion)) + ")"

    Catch ex As Exception
      MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub mostrarDetalle()
    Try
      Dim frm As New frmDespachoRequisicion_Detalle
      frm.state_button = True
      frm.IdRequisicionDet = dgvDatos.CurrentRow.Cells("IdRequisicionDet").Text
      frm.IdRequisicion = IdRequisicion

      If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        dtDatos = Nothing
        listaDatos()
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Function ValidaCodigoSeleccionado() As Boolean
    Try
      If dgvDatos.RowCount < 1 Then
        MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
        Return False
      ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
        MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
        Return False
      ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
        MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
        Return False
      Else
        Return True
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("Item").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, dtDatos, "Item", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ====================================================
  '====================================================================================================================
  Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
  End Sub
 
    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
  Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
    actualizar()
  End Sub
  Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
    txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text))
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumOrden.Select()
        End If

    End Sub
    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

End Class
