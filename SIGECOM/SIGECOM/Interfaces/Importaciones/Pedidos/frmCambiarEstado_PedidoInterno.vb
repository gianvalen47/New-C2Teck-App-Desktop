Imports System.Windows.Forms

Public Class frmCambiarEstado_PedidoInterno

  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
    Private oPedidoService As New PedidoService.PedidoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    Private empresaUsuario As New EmpresaUsuarioService.EmpresaUsuario

    Private Persona As New PersonaService.Persona
    Private dtDatos As DataTable
    Private dtCorreos As DataTable
    Public iCentroCosto As String
    Public IdPersonaSolicita As Integer
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Public IdPedido As String
  Public estado As String
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
  Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtObservacion.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{TAB}")
    End If
    End Sub

    Private Sub frmCambiarEstado_PedidoInterno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.CancelButton = Me.btnCancelar
    Me.Size = New System.Drawing.Size(578, 150)
    ObtenerRegistro()
    EnabledOptions()

    Dim estilo As New Estilo
    estilo.cargaEstiloDataDrid(dgvDatos)

    'listamos los estados
        'Me.Size = New System.Drawing.Size(578, 501)
        'Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        'btnVerDetalle.Text = "Ocultar Detalle"
        'btnVerDetalle.Size = New System.Drawing.Size(102, 25)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        listaDatos()
        listaCorreos()

  End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oPedidoService) = False Then
        oPedidoService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub RowPossesion(ByVal lista As DataGridView, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
    Try
      tabla.DefaultView.Sort = nombreCampo
      lista.FirstDisplayedScrollingRowIndex = dtDatos.DefaultView.Find(codigo)
      lista.Rows(dtDatos.DefaultView.Find(codigo)).Selected = True
      lista.CurrentCell = lista.Rows(dtDatos.DefaultView.Find(codigo)).Cells(1)
    Catch ex As Exception
      MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
    End Try
    End Sub

    Private Sub listaCorreos()
        Try

            empresaUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)

            'Dim usuario As New SeguridadService.Usuario
            'usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            IdPersonaSolicita = empresaUsuario.Persona.IdPer  'usuario.Persona.IdPer
            'txtPersonaSolicita.Text = usuario.Persona.ApeNom

            Persona = oPersonaService.Obtener(IdPersonaSolicita)
            'cmbArea.Value = Persona.CentroCosto.Area.CodArea
            iCentroCosto = Persona.CentroCosto.CodCentro

            If toBlank(estado) = "GENERADO" Then

                dtCorreos = oAsignacionJefesService.MostrarJefeArea(iCentroCosto).Tables(0)
                dgvCorreos.DataSource = dtCorreos

            ElseIf toBlank(estado) = "ENVIADO" Then

                'dtCorreos = oAsignacionJefesService.MostrarAprobarCompra(Session.sCodEmp).Tables(0)
                dtCorreos = oAsignacionJefesService.MostrarAprobarCompra(iCentroCosto).Tables(0)
                dgvCorreos.DataSource = dtCorreos

            End If


        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnabledOptions()
        If toBlank(estado) = "PEDIDO" Or toBlank(estado) = "RECHAZADO" Or toBlank(estado) = "VISUALIZADO" Then
            btnCambiarEstado.Enabled = False
        Else
            btnCambiarEstado.Enabled = True
        End If

        If toBlank(estado) = "GENERADO" Or toBlank(estado) = "ENVIADO" Then
            'gbCorreos.Visible = False
            'Correos visible = false el dia 26-11 por Orden de Elizabeth

            'Correo visible true 15-01-15 - Cesar
            gbCorreos.Visible = True
        Else
            gbCorreos.Visible = False
        End If

        If toBlank(estado) = "GENERADO" Then
            btnCambiarEstado.Text = "Enviar"
        ElseIf toBlank(estado) = "APROBADO" Then
            btnCambiarEstado.Text = "Visualizar"
        Else
            btnCambiarEstado.Text = "Aprobar"
        End If

        If toBlank(estado) = "ENVIADO" Or toBlank(estado) = "APROBADO X JEFE AREA" Or toBlank(estado) = "APROBADO" Then
            btnRechazarPedido.Visible = True
        Else
            btnRechazarPedido.Visible = False
        End If

        If toBlank(estado) = "APROBADO" Or toBlank(estado) = "APROBADO X JEFE AREA" Then
            GroupBox1.Location = New System.Drawing.Point(10, 118)
            Me.Size = New System.Drawing.Size(578, 355)
        Else
            ' 'Agregado el 26-11-13 para ocultar correos 
            GroupBox1.Location = New System.Drawing.Point(10, 118)
            'Me.Size = New System.Drawing.Size(578, 355)

            'Ventana Maximinazada 15-01-15 Cesar
            Me.Size = New System.Drawing.Size(578, 460)
        End If


    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPedido) = 0 Then
                MsgBox("Debe Ingresar el número del Pedido", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [CAES-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar()
        Try
            If estado = "GENERADO" Or estado = "ENVIADO" Then

                If dgvDatos.RowCount > 0 Then
                    'If MsgBox("¿Está seguro de ENVIAR la Solicitud de Gasto Nº" & txtNumGasto.Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim Cadena As String = ""

                    rows = dgvCorreos.GetCheckedRows()

                    Dim row As Janus.Windows.GridEX.GridEXRow

                    'Comentado para correo vacio If rows.Count <> 0 
                    If rows.Count <> 0 Then

                        For Each row In rows
                            If Cadena = "" Then
                                Cadena = row.Cells("Email").Text
                            Else
                                Cadena = Cadena + ";" + row.Cells("Email").Text
                            End If
                        Next
                        '=================================Enviar a Correos Seleccionados=================================
                        Dim estado_process As Boolean
                        'Cambiar estado a enviado y aprobado x jefe de area vuelve a pedir correo 15-01-15
                        estado_process = oPedidoService.CambiarEstado(toNull(IdPedido), Cadena, toNull(txtObservacion.Text), toNull(Session.sCodUsu))
                        'estado_process = oPedidoService.CambiarEstado(toNull(IdPedido), "", toNull(txtObservacion.Text), toNull(Session.sCodUsu))


                        If estado_process Then
                            listaDatos()
                            ''RowPossesion(dgvDatos, dtDatos, "Estado", txtEstado.Text)
                            estado = getDescripcionEstado(oMaestroService.MostrarDato("SIGECOM.Importaciones.Pedidos", "Estado", "IdPedido", IdPedido))
                            EnabledOptions()
                            ObtenerRegistro()
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                        End If
                    Else
                        MsgBox("Debe seleccionar alguno de los correos")
                    End If
                    'End if
                Else
                    MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
                End If


                Else
                    Dim estado_process As Boolean
                    estado_process = oPedidoService.CambiarEstado(toNull(IdPedido), "", toNull(txtObservacion.Text), toNull(Session.sCodUsu))
                    If estado_process = True Then
                        ''MsgBox("Se Cambio de estado correctamente.!", MsgBoxStyle.Information)
                        listaDatos()
                        ''RowPossesion(dgvDatos, dtDatos, "Estado", txtEstado.Text)
                        estado = getDescripcionEstado(oMaestroService.MostrarDato("SIGECOM.Importaciones.Pedidos", "Estado", "IdPedido", IdPedido))
                        EnabledOptions()
                        ObtenerRegistro()
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If

                End If

        Catch ex As Exception
            MsgBox("ERROR [CAES-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Rechazar()
        Try
            Dim estado_process As Boolean
            estado_process = oPedidoService.Rechazar(toNull(IdPedido), toNull(txtObservacion.Text), toNull(Session.sCodUsu))
            If estado_process = True Then
                listaDatos()
                RowPossesion(dgvDatos, dtDatos, "Estado", "RECHAZADO")
                estado = getDescripcionEstado(oMaestroService.MostrarDato("SIGECOM.Importaciones.Pedidos", "Estado", "IdPedido", IdPedido))
                EnabledOptions()
                ObtenerRegistro()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [CAES-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            txtUsuario.Text = Session.sCodUsu
            If toBlank(estado) = "GENERADO" Then
                txtEstado.Text = "ENVIADO"
            ElseIf toBlank(estado) = "ENVIADO" Then
                txtEstado.Text = "APROBADO X JEFE AREA"
            ElseIf toBlank(estado) = "APROBADO X JEFE AREA" Then
                txtEstado.Text = "APROBADO"
            ElseIf toBlank(estado) = "APROBADO" Then
                txtEstado.Text = "VISUALIZADO"
            ElseIf toBlank(estado) = "VISUALIZADO" Then
                txtEstado.Text = "PEDIDO"
            ElseIf toBlank(estado) = "PEDIDO" Then
                txtEstado.Text = "PEDIDO YA CULMINO SUS PROCESOS"
            End If
            txtObservacion.Text = ""
        Catch ex As Exception
            MsgBox("ERROR [CAES-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oPedidoService.MostrarEstados(toNumber(IdPedido)).Tables(0)
            dgvDatos.DataSource = dtDatos
            cEstado.DataPropertyName = dtDatos.Columns("Estado").ColumnName
            cFecha.DataPropertyName = dtDatos.Columns("Fecha1").ColumnName
            cObservacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName
            cCodUsu.DataPropertyName = dtDatos.Columns("CodUsu").ColumnName
        Catch ex As Exception
            MsgBox("ERROR [CAES-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.Item("cEstado", dgvDatos.CurrentRow.Index).Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, dtDatos, "Estado", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [CAES-05]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function getDescripcionEstado(ByVal codigo As String) As String
        Dim descripcion As String = ""
        If toBlank(codigo) = "GN" Then
            descripcion = "GENERADO"
        ElseIf toBlank(codigo) = "EN" Then
            descripcion = "ENVIADO"
        ElseIf toBlank(codigo) = "AP" Then
            descripcion = "APROBADO X JEFE AREA"
        ElseIf toBlank(codigo) = "GE" Then
            descripcion = "APROBADO"
        ElseIf toBlank(codigo) = "VS" Then
            descripcion = "VISUALIZADO"
        ElseIf toBlank(codigo) = "PE" Then
            descripcion = "PEDIDO"
        End If
        Return descripcion
    End Function
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    'Private Sub btnVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDetalle.Click
    '  If btnVerDetalle.Text = "Ver Detalle" Then
    '    Me.Size = New System.Drawing.Size(578, 348)
    '    Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Derecha
    '    btnVerDetalle.Text = "Ocultar Detalle"
    '    btnVerDetalle.Size = New System.Drawing.Size(102, 25)

    '    listaDatos()
    '  Else
    '    Me.Size = New System.Drawing.Size(578, 150)
    '    Me.btnVerDetalle.Image = Global.SIGECOM.My.Resources.Resources.Derecha
    '    btnVerDetalle.Text = "Ver Detalle"
    '    btnVerDetalle.Size = New System.Drawing.Size(85, 25)

    '    dtDatos = Nothing
    '    dgvDatos.DataSource = Nothing
    '  End If
    'End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub
    Private Sub btnCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarEstado.Click
        If toBlank(estado) = "GENERADO" Then
            If MsgBox("¿Está seguro de ENVIAR el pedido?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                   And ValidaCampos() Then
                Insertar()
            End If
        ElseIf toBlank(estado) = "APROBADO" Then
            If MsgBox("¿Está seguro de VISUALIZAR el pedido?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                   And ValidaCampos() Then
                Insertar()
            End If

        Else
            If MsgBox("¿Está seguro de APROBAR el pedido?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                               And ValidaCampos() Then
                Insertar()
            End If
        End If

    End Sub
    Private Sub btnRechazarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazarPedido.Click
        If MsgBox("¿Está seguro de RECHAZAR el Pedido ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                   And ValidaCampos() Then
            Rechazar()
        End If
    End Sub
End Class
