Imports System.ServiceModel
Imports System.Net

Public Class frmDespachos

    Private oDespachoCabService As New DespachoCabService.DespachoCabServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private dtEstados As DataTable
    Private state_Search As Boolean
    Public IdChofer As Integer
    Private iEstado As String

    Private Sub frmDespachos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDespachoCabService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oDespachoCabService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oDespachoCabService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmDespachos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False

        Dim Fecha As Date
        Fecha = Today

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Fecha

        llenarCombos()

        IdChofer = 0
        txtSolicitante.Text = "(Todos)"
        'state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= ESTADOS ================================================
            dtEstados = oDespachoCabService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub listaDatos()
        Try
            'If state_Search = True Then
            dtDatos = oDespachoCabService.Filtrar(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IdChofer, cmbEstado.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biTrasladar.Enabled = False
            biCerrar.Enabled = False
            biVerEstados.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miTrasladar.Enabled = False
            miCerrar.Enabled = False
            miCancelar.Enabled = False
            miVerEstados.Enabled = False
        Else
            iEstado = dgvDatos.CurrentRow.Cells("DesEstado").Value
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = "Generado", True, False)
            biTrasladar.Enabled = IIf(iEstado = "Generado", True, False)
            biCerrar.Enabled = IIf(iEstado = "Transito", True, False)
            biCancelar.Enabled = IIf(iEstado = "Transito", True, False)
            biVerEstados.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = "Generado", True, False)
            miTrasladar.Enabled = IIf(iEstado = "Generado", True, False)
            miCerrar.Enabled = IIf(iEstado = "Transito", True, False)
            miCancelar.Enabled = IIf(iEstado = "Transito", True, False)
            miVerEstados.Enabled = True
        End If
    End Sub


    Private Sub btnBuscarPersona_Click(sender As Object, e As EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdChofer = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdChofer = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biactualizar_Click(sender As Object, e As EventArgs) Handles biactualizar.Click
        listaDatos()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmDespacho
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    'cmbUbicacion.Value = frm.iUbicacion
                    RowPossesion(dgvDatos, frm.IdDespachoCab)
                    Mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO DESPACHO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdDespachoCab").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        Mostrar()
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmDespacho
            frm.state_button = True
            frm.IdDespachoCab = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
            'frm.editable = IIf(lEstado = "Generado", True, False)
            frm.editable = False
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdDespachoCab)
                Else
                    listaDatos()
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DESPACHO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
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

    Private Sub eliminar()
        Try
            Dim estado As String = dgvDatos.CurrentRow.Cells("DesEstado").Text.ToString

            If estado = "Generado" Then

                If MsgBox("¿Está seguro de ELIMINAR el Despacho Nº " + dgvDatos.CurrentRow.Cells("IdDespachoCab").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oDespachoCabService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdDespachoCab").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If

            Else
                MsgBox("En este estado no se puede eliminar el despacho", MsgBoxStyle.Exclamation)
            End If


        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL DESPACHO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        Mostrar()
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click, miCerrar.Click

        Dim frm As New frmDespachoCierre
        frm.IdDespachoCab = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'biactualizar_Click(sender, e)
            Actualizar()
        End If

        'Try
        '    If ValidaCodigoSeleccionado() Then

        '        If MsgBox("¿Está seguro de CERRAR el Despacho Nº " + dgvDatos.CurrentRow.Cells("IdDespachoCab").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

        '            Dim cerrar As Boolean
        '            Dim iddespacho As String = toNumber(dgvDatos.CurrentRow.Cells("IdDespachoCab").Text)
        '            cerrar = oDespachoCabService.CerrarRuta(iddespacho, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

        '            If cerrar = True Then
        '                MsgBox("Se cerro el despacho correctamente.", MsgBoxStyle.Information)
        '                listaDatos()
        '                RowPossesion(dgvDatos, iddespacho)
        '            End If
        '        End If
        '        '    Dim frm As New frmDespacho_Cierre
        '        '    frm.IdDespachoCab = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
        '        '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
        '        '        biactualizar_Click(sender, e)
        '        '    End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al CERRAR el Despacho : " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged, txtSolicitante.TextChanged, cmbEstado.ValueChanged
        listaDatos()
    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click, miImprimir.Click
        mostrarReporte()
    End Sub

    Private Sub mostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptDespacho_Detalle
            If dgvDatos.RowCount > 0 Then
                dtReporte = oDespachoCabService.Imprimir(dgvDatos.CurrentRow.Cells("IdDespachoCab").Value).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
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
                    forma.Text = "Impresión de Despacho Nº" + dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
                    forma.ShowDialog()
                End If
            Else
                MsgBox("!No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biVerEstados_Click(sender As Object, e As EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmDespachoEstados
                frm.IdDespachoCab = dgvDatos.CurrentRow.Cells("IdDespachoCab").Value
                frm.Text = "Estados del Despacho Nº " & dgvDatos.CurrentRow.Cells("IdDespachoCab").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biTrasladar_Click(sender As Object, e As EventArgs) Handles biTrasladar.Click, miTrasladar.Click
        Dim frm As New frmDespachoTraslado
        frm.IdDespachoCab = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'biactualizar_Click(sender, e)
            Actualizar()
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biCancelar_Click(sender As Object, e As EventArgs) Handles biCancelar.Click, miCancelar.Click

        Dim frm As New frmDespachoCancelar
        frm.IdDespachoCab = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'biactualizar_Click(sender, e)
            Actualizar()
        End If

    End Sub

    'Private Sub Actualizar()
    '    Dim codigo As String = ""
    '    If dgvDatos.RowCount > 0 Then
    '        codigo = dgvDatos.CurrentRow.Cells("IdDespachoCab").Text
    '    End If
    '    dtDatos = Nothing
    '    listaDatos()
    '    If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
    '        RowPossesion(dgvDatos, codigo)
    '    End If
    'End Sub

End Class