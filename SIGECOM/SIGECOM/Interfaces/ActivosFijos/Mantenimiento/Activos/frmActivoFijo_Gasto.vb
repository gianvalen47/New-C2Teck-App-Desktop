Imports Janus.Windows.GridEX
Imports System.ServiceModel
Public Class frmActivoFijo_Gasto

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Public CodActivo As String
    Public IdGasto As Integer
    Private dtDatos As DataTable
    Private dtMonedas As DataTable

    Private Sub frmActivoFijo_Gasto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        dgvDatos.RowHeaders = InheritableBoolean.False
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        txtIdGasto.Focus()
        Me.Text = "INGRESAR GASTOS AL ACTIVO FIJO: " + CodActivo
    End Sub

    Private Sub frmActivoFijo_Gasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmActivoFijo_Gasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oActivoFijoService.Close()
            oSolicitudGastoService.Close()
            oSolicitudGastoDetService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
            oSolicitudGastoService.Abort()
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
            oSolicitudGastoService.Abort()
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub ListarDetallesGasto()
        Try
            dtDatos = oSolicitudGastoDetService.MostrarNoContabilizado(toNumber(txtIdGasto.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES DE GASTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidarCodigo() As Boolean
        Try
            If Len(Trim(txtIdGasto.Text)) > 0 Then
                If Not (oSolicitudGastoService.Buscar(toNumber(txtIdGasto.Text))) Then
                    MsgBox("Número de Solicitud de Gasto inexistente, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                ElseIf oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 5 And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 7 _
                    And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 3 And oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 10 Then                    
                    MsgBox("Número de Solicitud de Gasto aún no ha sido aprobada, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                ElseIf (oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) = 1 Or oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) = 8) Then
                    MsgBox("Número de Solicitud de Gasto en estado Generado o Enviado, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                Else
                    Return True
                End If
            Else
                MsgBox("Ingrese un N° de Solicitud de Gasto")
                txtIdGasto.Text = ""
                txtIdGasto.Focus()
                Limpiar()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL GASTO : " + ex.Message)
        End Try
    End Function

    Private Sub Limpiar()
        txtIdGasto.Text = ""
        txtFecha.IsNullDate = True
        txtArea.Text = ""
        cmbMoneda.Text = ""
        txtPersonaSolicita.Text = ""
        txtPersonaAutoriza.Text = ""
        txtObservacion.Text = ""
        lblEstado.Text = ""
        dtDatos = Nothing
        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoService.SolicitudGasto
            registro = oSolicitudGastoService.Obtener(toNumber(txtIdGasto.Text))

            IdGasto = registro.IdGasto
            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtArea.Text = registro.Area.DesArea
            cmbMoneda.Value = registro.Moneda.CodMon
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.PersonaJefe.ApeNom
            lblEstado.Text = registro.EstadoSolicitudGasto.DesEstado
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtIdGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdGasto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If ValidarCodigo() Then
                ObtenerRegistro()
                ListarDetallesGasto()
            End If
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidarCodigo() Then
                    If dgvDatos.RowCount > 0 Then

                        Dim row As Janus.Windows.GridEX.GridEXRow
                        Dim Seleccionado As Integer = 0    'Valor de CheckBox                        
                        Dim DetIngresados As Integer         'Número de Detalles ingresados

                        '========== Recorrido para contabilizar cuantos detalles estan seleccionados ========
                        For i = 0 To Me.dgvDatos.RowCount - 1
                            Me.dgvDatos.Row = i
                            row = Me.dgvDatos.GetRow()
                            If toBoolean(row.Cells("Procesar").Value) = True Then
                                Seleccionado = Seleccionado + 1
                            End If
                        Next
                        '==================================================================

                        If Seleccionado > 0 Then
                            '============ Recorrido para ingresar detalle validando que este seleccionado===========

                            Dim IdGasto As Integer           'IdGasto del Detalle
                            Dim IdGastoDet As Integer      'IdGastoDet del Detalle
                            Dim Procesar As Boolean

                            For i = 0 To Me.dgvDatos.RowCount - 1
                                Me.dgvDatos.Row = i
                                row = Me.dgvDatos.GetRow()
                                Procesar = toBoolean(row.Cells("Procesar").Value)
                                If Procesar = True Then

                                    row = Me.dgvDatos.GetRow()
                                    IdGasto = toNumber(txtIdGasto.Text)
                                    IdGastoDet = row.Cells("IdGastoDet").Value                           

                                    If Not (oActivoFijoService.BuscarGasto(IdGastoDet)) Then
                                        Dim registro As New ActivoFijoService.ActivoFijoGastos
                                        Dim activo As New ActivoFijoService.ActivoFijo
                                        Dim SolicitudGasto As New ActivoFijoService.SolicitudGasto
                                        Dim SolicitudGastoDet As New ActivoFijoService.SolicitudGastoDet
                                        Dim empresa As New ActivoFijoService.Empresa

                                        empresa.CodEmp = Session.sCodEmp
                                        activo.CodActivo = CodActivo
                                        activo.Empresa = empresa
                                        registro.ActivoFijo = activo

                                        SolicitudGasto.IdGasto = IdGasto
                                        SolicitudGastoDet.IdGastoDet = IdGastoDet
                                        SolicitudGastoDet.SolicitudGasto = SolicitudGasto
                                        registro.SolicitudGastoDet = SolicitudGastoDet
                                        registro.Observaciones = txtObservacion.Text

                                        registro.CodUsu = Session.sCodUsu
                                        registro.NomPc = Session.sNomPc
                                        registro.DirIp = Session.sDirIp

                                        If oActivoFijoService.InsertarGasto(registro) = True Then
                                            DetIngresados = DetIngresados + 1
                                        End If
                                    End If
                                    '====================================================================                                     
                                End If
                            Next

                            If DetIngresados > 0 Then
                                MsgBox("Detalle(s) Ingresado(s) al Activo Fijo: Nº " + CodActivo.ToString)
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Else
                                MsgBox("Los Detalles seleccionados ya fueron ingresados a un activo fijo.")
                            End If


                        Else
                            MsgBox("Debe seleccionar alguno de los detalles")
                        End If
                    Else
                        MsgBox("No se presentan Detalles que ingresar, Verificar")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DETALLES EN ACTIVO FIJO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnObservacion_Click(sender As Object, e As EventArgs) Handles btnObservacion.Click
        Dim frm As New frmActivoFijo_Obrsv
        frm.Text = "Observación :"
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()
    End Sub

End Class