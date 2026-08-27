Imports System.ServiceModel
Public Class frmQuintaCategoria
    '===========================Servicios====================================================
    Private oQuintaCategoriaDetService As New QuintaCategoriaDetService.QuintaCategoriaDetServiceClient
    'Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oQuintaCategoriaCabService As New QuintaCategoriaCabService.QuintaCategoriaCabServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient



    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Public Periodo As Integer

    Private dtDatos As DataTable

    Public ApeNom As String

    Private Sub frmCronogramaMinasLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Quinta Categoria Periodo " & Periodo.ToString & " De " & ApeNom

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()

        state_Search = True


        listaDatos()
        dgvDatos.Select()
    End Sub
    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed=============================================
    Private Sub frmFaltasPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            'oMaestroService.Close()
            'oSeguridadService.Close()
            oQuintaCategoriaDetService.Close()
            oQuintaCategoriaCabService.Close()
        Catch ex As TimeoutException
            'oMaestroService.Abort()
            'oSeguridadService.Abort()
            oQuintaCategoriaDetService.Abort()
            oQuintaCategoriaCabService.Abort()
        Catch ex As CommunicationException
            'oMaestroService.Abort()
            'oSeguridadService.Abort()
            oQuintaCategoriaDetService.Abort()
            oQuintaCategoriaCabService.Abort()

        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmFaltasPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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


                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
            Else


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
            If row.Cells("Mes").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmQuintaCategoriaNuevoDetalle
            frm.state_button = True
            frm.periodo = Periodo
            frm.IdPersona = IdPersona
            frm.mes = dgvDatos.CurrentRow.Cells("Mes").Text
            frm.idTipo = dgvDatos.CurrentRow.Cells("IdTipoQuinta").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.mes)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.mes)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL CRONOGRAMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Cronograma seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oQuintaCategoriaDetService.Borrar(Periodo, dgvDatos.CurrentRow.Cells("Mes").Value, IdPersona, dgvDatos.CurrentRow.Cells("IdTipoQuinta").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()

                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL CRONOGRAMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmQuintaCategoriaNuevoDetalle
                frm.state_button = False
                frm.IdPersona = IdPersona
                frm.periodo = Periodo
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()

                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.mes)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub Obtener()
        Try
            Dim Registro As New QuintaCategoriaCabService.QuintaCategoriaCab
            Registro = oQuintaCategoriaCabService.Obtener(IdPersona, Periodo)
            txtColaborador.Text = Registro.Persona.ApeNom
            txtPeriodo.Text = Registro.Periodo
            txtIngresos.Text = Registro.TotalIngresosGeneral
            txtTotalImpuestos.Text = Registro.TotalImpuesto
            txtTotalRetenido.Text = Registro.TotalRetencion
            txtTotalPendiente.Text = Registro.TotalPendiente

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oQuintaCategoriaDetService.Mostrar(IdPersona, Periodo).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
                Obtener()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click, biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("Mes").Text
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




    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, miImportarIngresosPlanilla.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, biActualizar.MouseLeave, miSalir.MouseLeave,
        miEliminar.MouseLeave, biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter
        sslError.Text = "Imprimir Quinta del periodo actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo tipo de quinta."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Mostrar Quinta del Mes actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Quinta del Mes actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter, biActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.MouseEnter, biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub CrnogramaMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImportarIngresosPlanilla.MouseEnter
        sslError.Text = "Importar Quinta Categoria de planilla de sueldos Masivo."
    End Sub



    Private Sub miImportarIngresosPlanilla_Click(sender As Object, e As EventArgs) Handles miImportarIngresosPlanilla.Click
        Try
            Dim frm As New frmQuintaCategoriaImportar
            frm.iIdPersona = IdPersona
            frm.periodo = Periodo
            frm.idTipo = dgvDatos.CurrentRow.Cells("IdTipoQuinta").Text
            frm.mes = dgvDatos.CurrentRow.Cells("Mes").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Importar ingresos de planilla MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miProcesarRetencion_Click(sender As Object, e As EventArgs) Handles miProcesarRetencion.Click
        Try
            Dim frm As New frmQuintaCategoriaProcesar
            frm.iIdPersona = IdPersona
            frm.periodo = Periodo
            frm.idTipo = dgvDatos.CurrentRow.Cells("IdTipoQuinta").Text
            frm.mes = dgvDatos.CurrentRow.Cells("Mes").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Importar ingresos de planilla MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miExportarRetencion_Click(sender As Object, e As EventArgs) Handles miExportarRetencion.Click
        Try
            Dim frm As New frmQuintaCategoriaExportar
            frm.iIdPersona = IdPersona
            frm.periodo = Periodo
            frm.idTipo = dgvDatos.CurrentRow.Cells("IdTipoQuinta").Text
            frm.mes = dgvDatos.CurrentRow.Cells("Mes").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Importar ingresos de planilla MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
