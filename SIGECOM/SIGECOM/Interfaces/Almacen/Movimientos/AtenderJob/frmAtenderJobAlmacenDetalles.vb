Imports System.ServiceModel
Public Class frmAtenderJobAlmacenDetalles

    Private oMaestro As New MaestroService.MaestroClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private oMoviAlmacen As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oJobService As New JobService.JobServiceClient

    Private state_Search As Boolean
    Private dtAlmacenes As DataTable
    'Public IdOficina As Integer
    Public NumJob As String
    Public IdCliente As String
    Private dtDatos As DataTable
    Private dtTipos As DataTable
    Private loNuevoDataTable As DataTable
    Private IdPersona As String
    Private idserieDoc As Integer
    Private CodOfi As String
    'Private data As DataTable

    Private Sub frmAtenderJob_Detalles_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oTransferenciaService.Close()
            oValeMaterialService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oTransferenciaService.Abort()
            oValeMaterialService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oTransferenciaService.Abort()
            oValeMaterialService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oJobService.Abort()
        End Try
    End Sub
    Private Sub frmAtenderJob_Detalles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmAtenderJob_Detalles_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmAtenderJob_Detalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False

        ' llenarCombos()
        state_Search = True
        'listaDatos()
        enableOpciones()
        txtNumero.ReadOnly = True
        txtFecha.ReadOnly = True
        cmbAlmacen.ReadOnly = True
        'gbTipo.Enabled = False
        gbVale.Enabled = False
        'Cambio pedido por Camacho 
        'cmbAlmacen.Value = 3
        'rbVale.Checked = True
        'ObtenerSolicitante()
        ObtenerOficinaOT()

    End Sub

    Private Sub ObtenerOficinaOT()

        Try
            Dim registro As JobService.Job
            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro = oJobService.Obtener(NumJob)

            CodOfi = registro.Oficina.CodOfi

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS DE LA OT : " + ex.Message)
        End Try
    End Sub


    Private Sub ObtenerSolicitante()
        If cmbAlmacen.Value = 3 Then
            Dim Persona As New PersonaService.Persona
            Persona = oPersonaService.Obtener(57)
            IdPersona = Persona.IdPer
            txtPersonal.Text = Persona.ApeNom

        ElseIf cmbAlmacen.Value = 54 Then
            Dim Persona As New PersonaService.Persona
            Persona = oPersonaService.Obtener(464)
            IdPersona = Persona.IdPer
            txtPersonal.Text = Persona.ApeNom
        End If
    End Sub

    Private Sub llenarCombos()
        '======================================= ALMACENES ================================================
        dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, CodOfi, Session.sCodUsu).Tables(0)
        'dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, "01", Session.sCodUsu).Tables(0)
        cmbAlmacen.DataSource = dtAlmacenes
        'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
        cmbAlmacen.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
        cmbAlmacen.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.SelectedIndex = 0
        If dtAlmacenes.Rows.Count > 0 Then
            cmbAlmacen.SelectedIndex = 0
        Else
            cmbAlmacen.Value = ""
        End If
        dtAlmacenes = Nothing
    End Sub

    Private Sub llenarCombosUsuVale()
        '======================================= ALMACENES ================================================ 
        dtAlmacenes = oValeMaterialService.MostrarLocacionUsaVale(Session.sCodEmp, CodOfi, Session.sCodUsu).Tables(0)
        'dtAlmacenes = oValeMaterialService.MostrarLocacionUsaVale(Session.sCodEmp, "01", Session.sCodUsu).Tables(0)
        cmbAlmacen.DataSource = dtAlmacenes
        cmbAlmacen.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
        cmbAlmacen.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
        cmbAlmacen.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
        cmbAlmacen.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
        If dtAlmacenes.Rows.Count > 0 Then
            cmbAlmacen.SelectedIndex = 0
        Else
            cmbAlmacen.Value = ""
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount <= 0 Then
            biGenerarTransferencia.Enabled = False
            biImprimir.Enabled = False
        Else
            biGenerarTransferencia.Enabled = True
            biImprimir.Enabled = True
        End If
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If IdCliente = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf cmbAlmacen.Value = 0 Then
                MsgBox("Debe Ingresar la locación.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtNumero.Text) = "" Then
                MsgBox("Debe Ingresar el número de la Transferencia.", MsgBoxStyle.Information, "Información")
                txtNumero.BackColor = Color.Red
                txtNumero.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub activar()
        biGenerarTransferencia.Enabled = True
        biImprimir.Enabled = False
        rbSeleccionrTodos.Enabled = True
        btnPreSeleccionar.Enabled = True
        txtNumero.ReadOnly = False
        txtFecha.ReadOnly = False
        cmbAlmacen.ReadOnly = False
        'gbTipo.Enabled = True
        gbVale.Enabled = True
        'rbVale.Checked = True
        btnBuscarPersonal.Enabled = True
    End Sub
    Private Sub desactivar()
        biGenerarTransferencia.Enabled = False
        biImprimir.Enabled = True
        rbSeleccionrTodos.Enabled = False
        btnPreSeleccionar.Enabled = False
        txtNumero.ReadOnly = True
        'txtNumero.Text = ""
        txtFecha.ReadOnly = True
        cmbAlmacen.ReadOnly = True
        rbSeleccionrTodos.Checked = False
        'gbTipo.Enabled = False
        gbVale.Enabled = False
        btnBuscarPersonal.Enabled = False
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, CodOfi, cmbAlmacen.Value, NumJob).Tables(0)
                'dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, "01", cmbAlmacen.Value, NumJob).Tables(0)
                dgvDatos.DataSource = dtDatos

                cCodMer.DataPropertyName = dtDatos.Columns("CodMer").ColumnName
                cDesMer.DataPropertyName = dtDatos.Columns("DesMer").ColumnName
                cCanPed.DataPropertyName = dtDatos.Columns("CanMer").ColumnName
                cCanAte.DataPropertyName = dtDatos.Columns("CanAte").ColumnName
                cCanPen.DataPropertyName = dtDatos.Columns("CanPen").ColumnName
                cAtender.DataPropertyName = dtDatos.Columns("Despachar").ColumnName
                cStock.DataPropertyName = dtDatos.Columns("Stock").ColumnName
                cPreSeleccion.DataPropertyName = dtDatos.Columns("PreSeleccion").ColumnName
                CTransito.DataPropertyName = dtDatos.Columns("Transito").ColumnName

                enableOpciones()
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub PreSeleccionar(ByVal dgvDatos As DataGridView)
        Try
            If dgvDatos.RowCount <> 0 Then
                For Each fila As DataGridViewRow In dgvDatos.Rows
                    If toBoolean(fila.Cells("cPreSeleccion").Value) = True Then
                        If fila.Cells("cStock").Value > 0 Then
                            If fila.Cells("cStock").Value >= fila.Cells("cCanPen").Value Then
                                fila.Cells("cAtender").Value = fila.Cells("cCanPen").Value
                            ElseIf fila.Cells("cStock").Value < fila.Cells("cCanPen").Value Then
                                fila.Cells("cAtender").Value = fila.Cells("cStock").Value
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("ERROR AL PRESELECCIONAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDespachar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        activar()
        'txtNumero.Text = oTransferenciaService.SugerirNumero(cmbAlmacen.Value)
        dgvDatos.Columns("cAtender").ReadOnly = False
        txtNumero.Select()

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub biGenerarTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarTransferencia.Click
        Try
            If MsgBox("¿Está seguro de despachar la mercaderia?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                'FiltrarDatatable()
                Dim dtTable As DataTable
                Dim row As DataRow

                dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, CodOfi, cmbAlmacen.Value, NumJob).Tables(0)
                'dtDatos = oTransferenciaService.MostrarJobRepPendientes(Session.sCodEmp, "01", cmbAlmacen.Value, NumJob).Tables(0)

                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    If dgvDatos.Rows(i).Cells(5).Value.ToString > "0" Then
                        row = dtTable.NewRow
                        row(0) = dtDatos.Rows(i).Item(0)
                        row(1) = dtDatos.Rows(i).Item(1)
                        row(2) = dtDatos.Rows(i).Item(2)
                        row(3) = dtDatos.Rows(i).Item(3)
                        row(4) = dtDatos.Rows(i).Item(4)
                        row(5) = dtDatos.Rows(i).Item(5)
                        row(6) = dtDatos.Rows(i).Item(6)
                        row(7) = dtDatos.Rows(i).Item(7)
                        row(8) = dtDatos.Rows(i).Item(8)
                        row(9) = dtDatos.Rows(i).Item(9)
                        row(10) = dgvDatos.Item(5, i).Value
                        row(11) = dtDatos.Rows(i).Item(11)
                        row(12) = dtDatos.Rows(i).Item(12)
                        row(13) = dtDatos.Rows(i).Item(13)
                        row(14) = dtDatos.Rows(i).Item(14)
                        row(15) = dtDatos.Rows(i).Item(15)
                        row(16) = dtDatos.Rows(i).Item(16)
                        row(17) = dtDatos.Rows(i).Item(17)
                        row(18) = dtDatos.Rows(i).Item(18)
                        row(19) = dtDatos.Rows(i).Item(19)

                        dtTable.Rows.Add(row)
                    End If
                Next

                Dim estado_process As Boolean

                If rbTransInt.Checked Then

                    estado_process = oTransferenciaService.GenerarAtencionJob(cmbAlmacen.Value, IdCliente, txtNumero.Text, txtFecha.Text, NumJob, dtTable, Session.sCodUsu)

                ElseIf rbVale.Checked Then

                    If ValidaValeAlmacen() Then
                        estado_process = oValeMaterialService.GenerarAtencionJob(cmbAlmacen.Value, IdCliente, idserieDoc, txtNumero.Text, txtFecha.Text, NumJob, dtTable, IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If

                End If

                If estado_process Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK

                Else
                    MsgBox("No se despacho correctamente")
                    desactivar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaValeAlmacen() As Boolean
        Try
            If txtNumero.Text = "" Then
                MsgBox("Debe de ingresar un documento, verifique.!!!!!!", MsgBoxStyle.Information, "Ingrese un Personal")
                Return False
            ElseIf IdPersona = 0 Then
                MsgBox("Debe de ingresar un personal, verifique.!!!!!!", MsgBoxStyle.Information, "Ingrese un Personal")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub rbSeleccionrTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSeleccionrTodos.CheckedChanged
        seleccionaTodos(rbSeleccionrTodos.Checked)
    End Sub

    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        Try
            Dim contador As Integer

            contador = 0
            For i As Integer = 0 To dtDatos.Rows.Count - 1
                If contador = 30 Then
                    GoTo 2
                Else
                    If condicion = True Then
                        If dgvDatos.Item("cStock", i).Value < dgvDatos.Item("cCanPen", i).Value Then
                            If dgvDatos.Item("cStock", i).Value <> 0 Then
                                dgvDatos.Item("cAtender", i).Value = dgvDatos.Item("cStock", i).Value
                                contador = contador + 1
                            Else
                                dgvDatos.Item("cAtender", i).Value = 0
                            End If
                        Else
                            dgvDatos.Item("cAtender", i).Value = dgvDatos.Item("cCanPen", i).Value
                            contador = contador + 1
                        End If
                    Else
                        dgvDatos.Item("cAtender", i).Value = 0
                    End If

                End If

            Next
2:          dgvDatos.Select()
            dtDatos.AcceptChanges()
        Catch ex As Exception
            MsgBox("ERROR " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub cmbAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
        ObtenerSolicitante()
    End Sub

    Private Sub dgvDatos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDatos.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvDatos.CurrentCell.ColumnIndex
        If columna = 5 Or columna = 6 Then
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            Else
                Dim campo As TextBox = sender
                If (e.KeyChar <> ChrW(Keys.Back)) Then
                    Dim porAtender As Integer = 0
                    Try
                        porAtender = CInt(campo.Text + e.KeyChar.ToString)
                    Catch ex As Exception
                        porAtender = toNumber(campo.Text)
                    End Try

                    Dim margen As Integer
                    Dim stock As Integer
                    margen = toNumber(dgvDatos.Item("cCanPen", dgvDatos.CurrentRow.Index).Value.ToString)
                    stock = toNumber(dgvDatos.Item("cStock", dgvDatos.CurrentRow.Index).Value.ToString)
                    If porAtender > margen Then
                        MsgBox("La cantidad a despachar es mayor a la cantidad pendiente", MsgBoxStyle.Exclamation)
                        e.KeyChar = Chr(0)
                    Else
                        If porAtender > stock Then
                            MsgBox("La cantidad a despachar no puede ser mayor al stock")
                            e.KeyChar = Chr(0)
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgvDatos.Columns("cAtender").ReadOnly = False
        listaDatos()
        desactivar()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpAtenderJob

            If dtDatos.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtDatos)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("NumJob", NumJob)
                forma.Text = "Reporte de Pedidos de la OT"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub rbTransInt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTransInt.CheckedChanged

        If rbTransInt.Checked Then
            llenarCombos()
            'cmbAlmacen.Value = 3
            txtNumero.Text = oTransferenciaService.SugerirNumero(cmbAlmacen.Value)
            IdPersona = 0
            txtPersonal.ReadOnly = True
            txtPersonal.Text = ""
            activar()
            enableOpciones()
            btnBuscarPersonal.Enabled = False
            dgvDatos.Columns("cAtender").ReadOnly = False
            txtNumero.Select()
        Else
            desactivar()
        End If
    End Sub

    Private Sub rbVale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVale.CheckedChanged
        If rbVale.Checked Then
            llenarCombosUsuVale()
            idserieDoc = oMaestro.ObtenerIdSerieDoc(cmbAlmacen.Value, 13)
            If idserieDoc = 0 Then
                MsgBox("Este almacen no esta habilitado para emitir vales de almacen, Comunicarse con TI", MsgBoxStyle.Exclamation)
                txtNumero.Text = ""
            Else
                txtNumero.Text = oValeMaterialService.SugerirNumero(idserieDoc)
                btnBuscarPersonal.Enabled = True
            End If
            activar()
            'ObtenerSolicitante()
            enableOpciones()
            dgvDatos.Columns("cAtender").ReadOnly = False
            txtNumero.Select()
        Else
            desactivar()
            llenarCombos()
        End If
    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtPersonal.Text = frm.descripcion
                    IdPersona = frm.codigo

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnPreSeleccionar_Click(sender As Object, e As System.EventArgs) Handles btnPreSeleccionar.Click
        PreSeleccionar(dgvDatos)
    End Sub

    Private Sub cmbAlmacen_ValueChanged_1(sender As Object, e As EventArgs) Handles cmbAlmacen.ValueChanged
        If rbVale.Checked Then
            idserieDoc = oMaestro.ObtenerIdSerieDoc(cmbAlmacen.Value, 13)
            If idserieDoc = 0 Then
                MsgBox("Este almacen no esta habilitado para emitir vales de almacen, Comunicarse con TI", MsgBoxStyle.Exclamation)
                txtNumero.Text = ""
            Else
                txtNumero.Text = oValeMaterialService.SugerirNumero(idserieDoc)
                'btnBuscarPersonal.Enabled = True
            End If
            'activar()
            ''ObtenerSolicitante()
            'enableOpciones()
            'dgvDatos.Columns("cAtender").ReadOnly = False
        ElseIf rbTransInt.Checked
            txtNumero.Text = oTransferenciaService.SugerirNumero(cmbAlmacen.Value)
            'IdPersona = 0
            'txtPersonal.ReadOnly = True
            'txtPersonal.Text = ""
            'activar()
            'enableOpciones()
            'btnBuscarPersonal.Enabled = False
            'dgvDatos.Columns("cAtender").ReadOnly = False
            'txtNumero.Select()
        End If

        txtNumero.Select()
        listaDatos()
    End Sub
End Class