Imports System.IO
Imports System.ServiceModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmQuintaCategorias
    '===========================Servicios====================================================
    Private oQuintaCategoriaCabService As New QuintaCategoriaCabService.QuintaCategoriaCabServiceClient
    Private oQuintaCategoriaDetService As New QuintaCategoriaDetService.QuintaCategoriaDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient



    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer

    Private dtDatos As DataTable

    Private UbicPers As String

    Private Sub frmCronogramaMinasLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 323)
        '/*************************************************************************************/

        chkPersona.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkPersona, "Limpiar Colaborador")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Colaborador")


        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()

        state_Search = True
        txtAnio.Value = Today.Year

        listaDatos()
        dgvDatos.Select()
    End Sub
    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtAnio.KeyPress _
 _
 _
                            , txtSolicitante.KeyPress

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
    Private Sub frmFaltasPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oQuintaCategoriaCabService.Close()
            oQuintaCategoriaDetService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oQuintaCategoriaCabService.Abort()
            oQuintaCategoriaDetService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oQuintaCategoriaCabService.Abort()
            oQuintaCategoriaDetService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmFaltasPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount < 1 Then
                biImprimir.Enabled = False
                biMostrar.Enabled = False
                biEliminar.Enabled = False
                biImportarMasivo.Enabled = False
                biProcesarRetencion.Enabled = False
                biExportarRetencion.Enabled = False
                biProcesarImpuestoMasivo.Enabled = False
                biInsertarTipoMasivo.Enabled = False

                miProcesarImpuesto.Enabled = False
                miImportarMasivo.Enabled = False
                miProcesarRetencionMasivo.Enabled = False
                miExportarRetencion.Enabled = False


                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
            Else

                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = True 'IIf(iPagado = True, False, True)
                biImportarMasivo.Enabled = True
                biProcesarRetencion.Enabled = True
                biExportarRetencion.Enabled = True
                biProcesarImpuestoMasivo.Enabled = True
                biInsertarTipoMasivo.Enabled = True

                miProcesarImpuesto.Enabled = True
                miImportarMasivo.Enabled = True
                miProcesarRetencionMasivo.Enabled = True
                miExportarRetencion.Enabled = True

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True 'IIf(iPagado = True, False, True)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPer").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmQuintaCategoria
            'frm.state_button = True
            frm.IdPersona = dgvDatos.CurrentRow.Cells("IdPer").Text
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Text
            frm.Periodo = txtAnio.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                'If frm.type_process = "update" Then
                RowPossesion(dgvDatos, frm.IdPersona)
            Else
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPersona)
                'MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
            End If


        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL CRONOGRAMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Periodo seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oQuintaCategoriaCabService.Borrar(toNumber(txtAnio.Text), dgvDatos.CurrentRow.Cells("IdPer").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL PERIODO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmQuintaCategoriaNuevo
                'frm.state_button = False
                frm.IdPersona = IdPersona
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    'If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdPersona)
                    'End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO CRONOGRAMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
                dtDatos = oQuintaCategoriaCabService.Filtrar(Session.sCodEmp, txtAnio.Value, IdPersona).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtAnio.ValueChanged, txtSolicitante.TextChanged
        listaDatos()
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
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPer").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub


    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                             biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave,
                             biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave,
                             biEliminar.MouseLeave, miEliminar.MouseLeave,
                             biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave,
                             biIngresarPeriodoMasivo.MouseLeave, miIngresarPeriodoMasivo.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Cronograma de Mina actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Cronograma de Mina."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Cronograma de Mina actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Cronograma de Mina actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub CrnogramaMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresarPeriodoMasivo.MouseEnter, miIngresarPeriodoMasivo.MouseEnter
        sslError.Text = "Ingresar Cronogramas de Mina Masivo."
    End Sub

    Private Sub biIngresarCronogramaMinaMasivo_Click(sender As System.Object, e As System.EventArgs) Handles biIngresarPeriodoMasivo.Click, miIngresarPeriodoMasivo.Click
        Try
            Dim frm As New frmQuintaCategoriaNuevoMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al ingresar PERIDO EN MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImportarMasivo_Click(sender As Object, e As EventArgs) Handles biImportarMasivo.Click, miImportarMasivo.Click
        Try
            Dim frm As New frmQuintaCategoriaImportarMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Importar ingresos de planilla MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biProcesarRetencion_Click(sender As Object, e As EventArgs) Handles biProcesarRetencion.Click, miProcesarRetencionMasivo.Click
        Try
            Dim frm As New frmQuintaCategoriaProcesarMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Procesar Retención en MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biExportarRetencion_Click(sender As Object, e As EventArgs) Handles biExportarRetencion.Click, miExportarRetencion.Click
        Try
            Dim frm As New frmQuintaCategoriaExportarMasivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Exportar Retención a planilla en MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biProcesarImpuestoMasivo_Click(sender As Object, e As EventArgs) Handles biProcesarImpuestoMasivo.Click
        Try

            If MsgBox("¿Está seguro de Calcular Impuestos Masivamente del periodo seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oQuintaCategoriaDetService.ProcesarImpuestosMasivo(Session.sCodEmp, toNumber(txtAnio.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se Calculo Impuestos exitosamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CALCULAR IMPUESTOS DEL PERIODO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biInsertarTipoMasivo_Click(sender As Object, e As EventArgs) Handles biInsertarTipoMasivo.Click
        Try
            Dim frm As New frmQuintaCategoriaInsertarTipoMasivo
            'frm.iIdPersona = dgvDatos.CurrentRow.Cells("IdPer").Value
            frm.periodo = toNumber(txtAnio.Text)
            frm.idTipo = 1
            ' frm.mes = dgvDatos.CurrentRow.Cells("Mes").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Importar ingresos de planilla MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miProcesarImpuesto_Click(sender As Object, e As EventArgs) Handles miProcesarImpuesto.Click
        Try

            If MsgBox("¿Está seguro de Calcular Impuestos del periodo y personal seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oQuintaCategoriaDetService.ProcesarImpuestos(Session.sCodEmp, toNumber(txtAnio.Text), dgvDatos.CurrentRow.Cells("IdPer").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se Calculo Impuestos exitosamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CALCULAR IMPUESTOS DEL PERIODO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable

            Dim reporte As New rptCertificadoQuinta
            Dim reporteEquimap As New rptCertificadoQuintaEquimap
            Dim reporteAmazonica As New rptCertificadoQuintaAmazonica

            dtReporte = oQuintaCategoriaCabService.Imprimir(Session.sCodEmp, txtAnio.Value, toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else


                If Session.sCodEmp = "02" Then
                    reporteAmazonica.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteAmazonica
                ElseIf Session.sCodEmp = "05"
                    reporteEquimap.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteEquimap
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                End If


                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte Quinta de Categoria"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biEnviarCorreoMasivo_Click(sender As Object, e As EventArgs) Handles biEnviarCorreoMasivo.Click
        Try
            If dgvDatos.RowCount() > 0 Then
                Dim frm As New frmQuintaCategoriaEnviarCorreoMasivo

                frm.periodo = txtAnio.Value


                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    MsgBox("Se envio los certificados masivamente por correo, Exitosamente", MsgBoxStyle.Information, "Exito")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL ENVIAR CORREO MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEnviarCorreo_Click(sender As Object, e As EventArgs) Handles miEnviarCorreo.Click
        CrearCarpeta()
        GenerarPDF()
        EnviarCorreo()
    End Sub

    Private Sub CrearCarpeta()
        Try
            Dim idcodigo As String = dgvDatos.CurrentRow.Cells("IdPer").Value
            If Not Directory.Exists("D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & txtAnio.Value.ToString() & "\" & idcodigo) Then
                Directory.CreateDirectory("D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & txtAnio.Value.ToString() & "\" & idcodigo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear la carpeta")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try

    End Sub

    Private Sub GenerarPDF()

        Dim forma As New frmReportes
        Dim reporte As New rptCertificadoQuinta
        Dim reporteEquimap As New rptCertificadoQuintaEquimap
        Dim reporteAmazonica As New rptCertificadoQuintaAmazonica
        Dim dtReporte As DataTable

        dtReporte = oQuintaCategoriaCabService.Imprimir(Session.sCodEmp, txtAnio.Value, toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value)).Tables(0)

        If dtReporte.Rows.Count = 0 Then
            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        Else

            If Session.sCodEmp = "02" Then
                reporteAmazonica.SetDataSource(dtReporte)
            ElseIf Session.sCodEmp = "05"
                reporteEquimap.SetDataSource(dtReporte)
            Else
                reporte.SetDataSource(dtReporte)
            End If

            'forma.crvReportes.ReportSource = reporte
            ''  forma.crvReportes.DisplayGroupTree = False
            'forma.Text = "Reporte Boleta de Pago"
            'forma.ShowDialog()
            ExportToPDF(reporte, "miReporte.pdf", "118")
        End If
    End Sub

    Public Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, codigo As String) As String
        Dim vFileName As String = Nothing
        Dim diskOpts As New DiskFileDestinationOptions()

        Try

            Dim idcodigo As String = dgvDatos.CurrentRow.Cells("IdPer").Value

            diskOpts.DiskFileName = "D:\QuintaCategoriaElectronicas\" & Session.sDesEmp & "\" & txtAnio.Value.ToString() & "\" & idcodigo & "\" & txtAnio.Text & idcodigo & ".pdf"

            rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            'Este es la ruta donde se guardara tu archivo.

            If File.Exists(vFileName) Then
                File.Delete(vFileName)
            End If
            'diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()
        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function

    Private Sub EnviarCorreo()



        Try
            If dgvDatos.RowCount() > 0 Then
                Dim frm As New frmQuintaCategoriaEnviarCorreo

                frm.idPer = dgvDatos.CurrentRow.Cells("IdPer").Value
                frm.periodo = txtAnio.Text


                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub


End Class
