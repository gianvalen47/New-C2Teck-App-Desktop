Imports System.ServiceModel
Public Class frmSerieDocumentos

    Private oSerieDocumentos As New SerieDocumentoService.SerieDocumentoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtTipoMovimientos As DataTable

    Private Sub frmSerieDocumentos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSerieDocumentos.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSerieDocumentos.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSerieDocumentos.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmSerieDocumentos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSerieDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        LlenarCombos()
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub LlenarCombos()

        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oSerieDocumentos.MostrarTipoDocumentoGeneral.Tables(0)
            'Dim row As DataRow = dtTipoDocumentos.NewRow
            'row(0) = 0
            'row(1) = "(Todos)"
            'dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocu.SelectedIndex = 0
            dtTipoDocumentos = Nothing

            '======================================= TIPO DE MOVIMIENTO ================================================
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"H", "Ingreso"})
            dtTipoMovimientos.Rows.Add(New Object() {"D", "Salida"})
            dtTipoMovimientos.Rows.Add(New Object() {"C", "Costo"})
            dtTipoMovimientos.Rows.Add(New Object() {"O", "Otros"})

            cmbTipMov.DataSource = dtTipoMovimientos
            cmbTipMov.DropDownList.DataMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.DropDownList.DisplayMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.DropDownList.ValueMember = dtTipoMovimientos.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(0).DataMember = dtTipoMovimientos.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(1).DataMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.SelectedIndex = 1
            dtTipoMovimientos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listaDatos()
        Try
            'dtDatos = oSerieDocumentos.Filtrar(Session.sCodEmp, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), toNumber(cmbDocu.Value), "").Tables(0)
            dtDatos = oSerieDocumentos.Filtrar(Session.sCodEmp, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), toNumber(cmbDocu.Value), cmbTipMov.Value).Tables(0)
            'dtDatos = oSerieDocumentos.Filtrar(Session.sCodEmp, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), 0, cmbTipMov.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(sender As Object, e As EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.Columns(2).DataMember = dtAlmacenes.Columns("AproDoc").ToString
            cmbIdLocacion.DropDownList.Columns(3).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, cmbIdLocacion.ValueChanged, cmbOficinas.ValueChanged, cmbDocu.ValueChanged, cmbTipMov.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmSerieDocumentos_Nuevo
            frm.state_button = False
            'frm.CodEmp = ""
            'frm.btnEditar.Enabled = False
            'frm.btnCancelar.Enabled = False
            frm.CodOfi = cmbOficinas.Value
            frm.DesOfi = cmbOficinas.Text
            frm.CodAlm = cmbIdLocacion.Value
            frm.DesAlm = cmbIdLocacion.Text
            frm.IdLocacion = cmbIdLocacion.Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.IdProveedor)
                listaDatos()
                If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, frm.CodEmp)
                    mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR UN SERIE DOCUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        mostrar()
    End Sub

    Private Sub mostrar()

        Try
            Dim frm As New frmSerieDocumentos_Nuevo
            frm.state_button = True
            frm.IdSerieDoc = dgvDatos.CurrentRow.Cells("IdSerieDoc").Text
            frm.CodOfi = cmbOficinas.Value
            frm.DesOfi = cmbOficinas.Text
            frm.CodAlm = cmbIdLocacion.Value
            frm.DesAlm = cmbIdLocacion.Text
            frm.IdLocacion = cmbIdLocacion.Value
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA SERIE DOCUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()

        Try
            If MsgBox("¿Está seguro de ELIMINAR la Serie Documento seleccionada?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oSerieDocumentos.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdSerieDoc").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA SERIE DOCUMENTO:" + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click, miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
End Class