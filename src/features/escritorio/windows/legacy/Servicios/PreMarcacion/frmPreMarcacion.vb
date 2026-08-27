Imports System.ServiceModel
Public Class frmPreMarcacion

    '===========================Servicios====================================================
    Private oPreMarcacionJobService As New PreMarcacionJobService.PreMarcacionJobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private IdPreMarca As Integer
    Private iEnviado As Boolean
    Private iAprobado As Boolean
    Private dtDatos As DataTable

    '==========================Evento Load===================================================
    Private Sub frmPreMarcacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 151)
        '/*************************************************************************************/

        chkPersona.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkPersona, "Limpiar Colaborador")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Colaborador")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_Search = False
        IdPersona = 0
        txtSolicitante.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()
        ObtenerColaborador()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      txtSolicitante.KeyPress _
                    , txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed=============================================
    Private Sub frmPreMarcacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPreMarcacionJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPreMarcacionJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPreMarcacionJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmPreMarcacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            ' cmbEstado.Value = ""
            ' txtIdGasto.Text = nro_Orden
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAprobar.Enabled = False
            biEnviar.Enabled = False
            biRechazar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAprobar.Enabled = False
            miEnviar.Enabled = False
            miRechazar.Enabled = False
        Else
            iEnviado = CBool(dgvDatos.CurrentRow.Cells("Enviado").Value)
            iAprobado = CBool(dgvDatos.CurrentRow.Cells("Aprobado").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(Not iEnviado, True, False)
            biAprobarMasivo.Enabled = True
            biAprobar.Enabled = IIf(iEnviado And Not iAprobado And (Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24"), True, False)
            biEnviar.Enabled = IIf(Not iEnviado And Not iAprobado, True, False)
            biAprobarMasivo.Enabled = IIf(Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24", True, False)
            biRechazar.Enabled = IIf(iEnviado And Not iAprobado And (Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24"), True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(Not iEnviado, True, False)
            miAprobarMasivo.Enabled = True
            miAprobar.Enabled = IIf(iEnviado And Not iAprobado And (Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24"), True, False)
            miEnviar.Enabled = IIf(Not iEnviado And Not iAprobado, True, False)
            miAprobarMasivo.Enabled = IIf(Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24", True, False)
            miRechazar.Enabled = IIf(iEnviado And Not iAprobado And (Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "24"), True, False)
        End If        
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
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPreMarca").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub ObtenerColaborador()
        'Se agrega el perfil 27 (Asistente de Recursos Humanos) 26/09/2014
        If Session.CodPerfil = "17" Or Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "38" Or Session.CodPerfil = "27" Or Session.CodPerfil = "24" Or Session.CodPerfil = "15" Then
            IdPersona = 0
            txtSolicitante.Text = "(Todos)"
            btnBuscarPersona.Enabled = True
        Else
            Dim usuario As New SeguridadService.Usuario
            usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            IdPersona = usuario.Persona.IdPer
            txtSolicitante.Text = usuario.Persona.ApeNom
            btnBuscarPersona.Enabled = False
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmPreMarcacion_Nuevo            
            iEnviado = CBool(dgvDatos.CurrentRow.Cells("Enviado").Value)
            frm.state_button = True
            frm.IdPreMarca = dgvDatos.CurrentRow.Cells("IdPreMarca").Value
            frm.editable = IIf(iEnviado, False, True)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.IdPreMarca.ToString)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdPreMarca)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PRE MARCACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Pre Marcación Nº " + dgvDatos.CurrentRow.Cells("IdPreMarca").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oPreMarcacionJobService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdPreMarca").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA PRE MARCACIÓN :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmPreMarcacion_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdPreMarca)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA PRE MARCACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
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
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then                
                dtDatos = oPreMarcacionJobService.Filtrar(IdPersona, txtNumJob.Text).Tables(0)         
                dgvDatos.DataSource = dtDatos                
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtSolicitante.TextChanged, txtNumJob.TextChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Esta seguro de APROBAR la Pre Marcación N° " & dgvDatos.CurrentRow.Cells("IdPreMarca").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPreMarcacionJobService.Aprobar(dgvDatos.CurrentRow.Cells("IdPreMarca").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Aprobó la Pre Marcación correctamente")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR la Pre Marcación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Esta seguro de ENVIAR la Pre Marcación N° " & dgvDatos.CurrentRow.Cells("IdPreMarca").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPreMarcacionJobService.Enviar(dgvDatos.CurrentRow.Cells("IdPreMarca").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Envió la Pre Marcación correctamente ")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPreMarca").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                                miAprobar.MouseLeave, biAprobar.MouseLeave, miAprobarMasivo.MouseLeave, _
                                biAprobarMasivo.MouseLeave, miRechazar.MouseLeave, biRechazar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Pre Marcación actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Pre Marcación."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Pre Marcación actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Pre Marcación actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar Pre Marcación Actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar Pre Marcación actual."
    End Sub
    Private Sub Rechazar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.MouseEnter, miRechazar.MouseEnter
        sslError.Text = "Rechazar Pre Marcación actual."
    End Sub
    Private Sub AprobarMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobarMasivo.MouseEnter, miAprobarMasivo.MouseEnter
        sslError.Text = "Aprobar Pre Marcación actual."
    End Sub
    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()

    End Sub

    Private Sub biAprobarMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobarMasivo.Click, miAprobarMasivo.Click
        Try
            Dim frm As New frmPreMarcacion_Aprobar
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR MASIVO la Pre Marcación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitante.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub biRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biRechazar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Esta seguro de RECHAZAR la Pre Marcación N° " & dgvDatos.CurrentRow.Cells("IdPreMarca").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oPreMarcacionJobService.Rechazar(dgvDatos.CurrentRow.Cells("IdPreMarca").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Rechazó la Pre Marcación correctamente")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al RECHAZAR la Pre Marcación : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class