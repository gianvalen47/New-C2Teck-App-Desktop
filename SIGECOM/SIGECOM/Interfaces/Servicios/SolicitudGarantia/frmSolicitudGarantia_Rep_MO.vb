Imports System.ServiceModel
Public Class frmSolicitudGarantia_Rep_MO

    '============================Servicios===================================
    Private oSolicitudGarantiaHorasService As New SolicitudGarantiaHorasService.SolicitudGarantiaHorasServiceClient
    Private oSolicitudGarantiaAtencionService As New SolicitudGarantiaAtencionService.SolicitudGarantiaAtencionServiceClient
    Private oSolicitudGarantiaService As New SolicitudGarantiaService.SolicitudGarantiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================
    Private dtDatosRep As DataTable
    Private dtDatosMO As DataTable
    Public IdAfa As Integer
    Public estado As Integer


    Private Sub frmSolicitudGarantia_Rep_MO_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub


    Private Sub frmSolicitudGarantia_HrsTrabajo_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvRepuestos)
        dgvRepuestos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvManoObra)
        dgvManoObra.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        Me.Text = "Repuestos y Mano de Obra de ORDEN DE REPARACIÓN N°:" & IdAfa

        ListaDatosRepuestos()
        ListaDatosManoObra()

        If estado = 1 Or estado = 2 Or estado = 3 Then
            dgvRepuestos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
        Else
            dgvRepuestos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        End If

        dgvRepuestos.Select()

    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGarantiaHorasService.Close()
            oSolicitudGarantiaAtencionService.Close()
            oSolicitudGarantiaService.Close()
            oSeguridadService.Close()

        Catch ex As TimeoutException
            oSolicitudGarantiaHorasService.Abort()
            oSolicitudGarantiaAtencionService.Abort()
            oSolicitudGarantiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSolicitudGarantiaHorasService.Abort()
            oSolicitudGarantiaAtencionService.Abort()
            oSolicitudGarantiaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudGarantia_Rep_MO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            TabOpciones.SelectedIndex = "0"
        ElseIf e.KeyCode = Keys.F3 Then
            TabOpciones.SelectedIndex = "1"
        End If
    End Sub

    Private Sub ListaDatosRepuestos()
        Try
            dtDatosRep = oSolicitudGarantiaAtencionService.MostrarRepuestos(IdAfa).Tables(0)
            dgvRepuestos.DataSource = dtDatosRep
            'Se agrega el perfil de Supervisor de Servicios 25/06/2021
            If Session.CodPerfil = "01" Or Session.CodPerfil = "26" Or Session.CodPerfil = "24" Or Session.CodPerfil = "34" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17" Then
                dgvRepuestos.RootTable.Columns(8).EditType = Janus.Windows.GridEX.EditType.TextBox
                dgvRepuestos.RootTable.Columns(9).EditType = Janus.Windows.GridEX.EditType.TextBox
                dgvRepuestos.RootTable.Columns(10).EditType = Janus.Windows.GridEX.EditType.TextBox
            Else
                dgvRepuestos.RootTable.Columns(8).EditType = Janus.Windows.GridEX.EditType.NoEdit
                dgvRepuestos.RootTable.Columns(9).EditType = Janus.Windows.GridEX.EditType.NoEdit
                dgvRepuestos.RootTable.Columns(10).EditType = Janus.Windows.GridEX.EditType.NoEdit
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR REPUESTOS: " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub ListaDatosManoObra()
        Try
            dtDatosMO = oSolicitudGarantiaHorasService.Mostrar(IdAfa).Tables(0)
            dgvManoObra.DataSource = dtDatosMO
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR MANO DE OBRA: " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvRepuestos.RowCount < 1 Then
            miEliminarRep.Enabled = False
            miCantAtendidaOk.Enabled = False
            miPrecFabricaOk.Enabled = False
        Else
            miEliminarRep.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
            miCantAtendidaOk.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
            miPrecFabricaOk.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
        End If
        miNuevoRep.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)

        If dgvManoObra.RowCount > 0 Then
            miEliminarMO.Enabled = True
            miMostrarMO.Enabled = True
            miEliminarMO.Enabled = True
            miImprimirMO.Enabled = True
        Else
            miEliminarMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
            miMostrarMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
            miImprimirMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
            miImprimirMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
        End If
        miNuevoMO.Enabled = IIf((estado = 1 Or estado = 2 Or estado = 3), True, False)
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------
    '============================ REPUESTOS ============================
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionRepuestos(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdGuiaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] REPUESTOS: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub eliminarRepuesto()
        Try
            cmOpRepuestos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Guía con CÓDIGO = " + dgvRepuestos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean                
                estado_process = oSolicitudGarantiaAtencionService.BorrarGuia(toNumber(dgvRepuestos.CurrentRow.Cells("IdAfa").Value), toNumber(dgvRepuestos.CurrentRow.Cells("IdGuia").Value), Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                If estado_process = True Then
                    dtDatosRep = Nothing
                    actualizarDetallesRepuestos()                    
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR GUIA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub actualizarDetallesRepuestos()
        Try
            Dim codigo As String = ""
            If dgvRepuestos.RowCount > 0 Then
                If IsDBNull(dgvRepuestos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvRepuestos.CurrentRow.Cells("CodMer").Text
                End If
            End If
            dtDatosRep = Nothing
            ListaDatosRepuestos()
            If dgvRepuestos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionRepuestos(dgvRepuestos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR REPUESTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoRep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoRep.Click
        Try
            Dim frm As New frmBuscarGuias
            Dim registro As New SolicitudGarantiaService.SolicitudGarantia
            registro = oSolicitudGarantiaService.Obtener(IdAfa)
            frm.CodJob = registro.Job.CodJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If oSolicitudGarantiaAtencionService.BuscarGuia(IdAfa, frm.IdGuia) Then
                    MsgBox("Esta Guía ya fue ingresada tenga cuidado...!!!")
                Else
                    Dim estado_process As Boolean
                    estado_process = oSolicitudGarantiaAtencionService.InsertarGuia(IdAfa, frm.IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        miActualizarRep_Click(sender, e)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al AGREGAR Guía  : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminarRep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarRep.Click
        eliminarRepuesto()
    End Sub

    Private Sub miActualizarRep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarRep.Click
        actualizarDetallesRepuestos()
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------
    '=============================== MANO DE OBRA '===============================
    '--------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub RowPossesionManoObra(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdHoraExtra").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] MANO DE OBRA: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub miNuevoMO_Click(sender As Object, e As EventArgs) Handles miNuevoMO.Click
        NuevoMO()
    End Sub

    Private Sub NuevoMO()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmSolicitudGarantia_ManoObra
                frm.IdAfa = IdAfa
                frm.Fecha = Today() 'txtFecha.Value
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatosMO = Nothing
                    ListaDatosManoObra()
                    If frm.type_process = "insert" Then
                        RowPossesionManoObra(dgvManoObra, frm.IdHoraExtra)
                        actualizarDetallesMO()
                    End If
                    enableOpciones()
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetallesMO()
        Try
            Dim codigo As String = ""
            If dgvManoObra.RowCount > 0 Then
                If IsDBNull(dgvManoObra.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvManoObra.CurrentRow.Cells("IdHoraExtra").Text
                End If
            End If
            dtDatosMO = Nothing
            ListaDatosManoObra()
            If dgvManoObra.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionManoObra(dgvManoObra, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES MANO DE OBRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrarMO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarMO.Click, dgvManoObra.DoubleClick
        mostrarMO()
    End Sub

    Private Sub mostrarMO()
        Try
            Dim frm As New frmSolicitudGarantia_ManoObra
            frm.state_button = True
            frm.IdAfa = dgvManoObra.CurrentRow.Cells("IdAfa").Text
            frm.IdPer = dgvManoObra.CurrentRow.Cells("IdPer").Text
            frm.Fecha = dgvManoObra.CurrentRow.Cells("Fecha").Text
            frm.IdHoraExtra = dgvManoObra.CurrentRow.Cells("IdHoraExtra").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatosMO = Nothing
                ListaDatosManoObra()
            End If
            RowPossesionManoObra(dgvManoObra, frm.IdHoraExtra)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE DE MANO DE OBRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionadoMO() As Boolean
        Try
            If dgvManoObra.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvManoObra.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvManoObra.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miEliminarMO_Click(sender As Object, e As EventArgs) Handles miEliminarMO.Click
        If ValidaCodigoSeleccionadoMO() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmbOpManoObra.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudGarantiaHorasService.Borrar(toNumber(dgvManoObra.CurrentRow.Cells("IdAfa").Value), toNumber(dgvManoObra.CurrentRow.Cells("IdPer").Value), Convert.ToDateTime(dgvManoObra.CurrentRow.Cells("Fecha").Value), toNumber(dgvManoObra.CurrentRow.Cells("IdHoraExtra").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatosMO = Nothing
                    ListaDatosManoObra()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA MANO DE OBRA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarMO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarMO.Click
        actualizarDetallesMO()
    End Sub

    Private Sub dgvManoObra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvManoObra.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvManoObra.RowCount > 0 Then
                miMostrarMO_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miImprimirMO_Click(sender As Object, e As EventArgs) Handles miImprimirMO.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim tothorastrabajo As Double
            Dim tothorasviaje As Double
            Dim tothoras25 As Double
            Dim tothoras35 As Double
            Dim tothoras100 As Double
            Dim reporte As New rptSolicitudGarantiaDetalleMO

            If dgvManoObra.RowCount > 0 Then
                dtReporte = oSolicitudGarantiaHorasService.ImprimirHoras(dgvManoObra.CurrentRow.Cells("IdAfa").Value, dgvManoObra.CurrentRow.Cells("IdPer").Value).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    Dim idhoraex As Double = 0
                    Dim canthoras As Double = 0
                    Dim totalkm As Double = 0

                    Dim hortrabajo As Double = 0
                    Dim horviaje As Double = 0
                    Dim sum0 As Double = 0
                    Dim sumextra As Double = 0
                    Dim sum25 As Double = 0
                    Dim sum35 As Double = 0
                    Dim sum100 As Double = 0

                    For i = 0 To dtReporte.Rows.Count - 1
                        idhoraex = dtReporte.Rows(i).Item("IdHoraExtra")
                        canthoras = dtReporte.Rows(i).Item("CantHoras")
                        totalkm = dtReporte.Rows(i).Item("TotalKm")

                        If idhoraex = 9 Then
                            sum0 += dtReporte.Rows(i).Item("CantHoras")
                            horviaje += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 1 Then
                            sumextra += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 2 Then
                            sum25 += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 3 Then
                            sum35 += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        ElseIf idhoraex = 4 Then
                            sum100 += dtReporte.Rows(i).Item("CantHoras")
                            hortrabajo += dtReporte.Rows(i).Item("CantHoras")
                        End If
                    Next

                    tothorastrabajo = hortrabajo
                    tothorasviaje = horviaje
                    tothoras25 = sum25
                    tothoras35 = sum35
                    tothoras100 = sum100

                    reporte.SetDataSource(dtReporte)
                    reporte.SetParameterValue("tothorastrabajo", tothorastrabajo)
                    reporte.SetParameterValue("tothorasviaje", tothorasviaje)
                    reporte.SetParameterValue("tothoras25", tothoras25)
                    reporte.SetParameterValue("tothoras35", tothoras35)
                    reporte.SetParameterValue("tothoras100", tothoras100)

                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If

                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de ORDEN DE REPARACION"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub miCantAtendidaOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCantAtendidaOk.Click
        Try
            Dim estado_process As Boolean
            Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaRepuestos
            Dim SolicitudGarantia As New SolicitudGarantiaAtencionService.SolicitudGarantia
            Dim GuiaRemisionDetalle As New SolicitudGarantiaAtencionService.GuiaRemisionDet
            Dim GuiaRemision As New SolicitudGarantiaAtencionService.GuiaRemision

            For Each row In Me.dgvRepuestos.GetRows
                SolicitudGarantia.IdAfa = row.Cells("IdAfa").Value
                registro.SolicitudGarantia = SolicitudGarantia                
                GuiaRemision.IdGuia = toNumber(row.Cells("IdGuia").Value)
                GuiaRemisionDetalle.GuiaRemision = GuiaRemision
                GuiaRemisionDetalle.IdGuiaDet = toNumber(row.Cells("IdGuiaDet").Value)
                registro.GuiaRemisionDet = GuiaRemisionDetalle
                registro.CanAte = toNumber(row.Cells("CanMer").Value)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.PreCompensado = toDouble(row.Cells("PreCompensado").Value)
                registro.PreFabrica = toDouble(row.Cells("PreFabrica").Value)

                estado_process = oSolicitudGarantiaAtencionService.ActualizarRepuesto(registro)
            Next

            actualizarDetallesRepuestos()
        Catch ex As Exception
            MsgBox("Error al actualizar Cantidad Atendida Ok: " + ex.Message)
        End Try
    End Sub

    Private Sub miPrecFabricaOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miPrecFabricaOk.Click
        Try
            Dim estado_process As Boolean
            Dim registro As New SolicitudGarantiaAtencionService.SolicitudGarantiaRepuestos
            Dim SolicitudGarantia As New SolicitudGarantiaAtencionService.SolicitudGarantia
            Dim GuiaRemisionDetalle As New SolicitudGarantiaAtencionService.GuiaRemisionDet
            Dim GuiaRemision As New SolicitudGarantiaAtencionService.GuiaRemision

            For Each row In Me.dgvRepuestos.GetRows
                SolicitudGarantia.IdAfa = row.Cells("IdAfa").Value
                registro.SolicitudGarantia = SolicitudGarantia                
                GuiaRemision.IdGuia = toNumber(row.Cells("IdGuia").Value)
                GuiaRemisionDetalle.GuiaRemision = GuiaRemision
                GuiaRemisionDetalle.IdGuiaDet = toNumber(row.Cells("IdGuiaDet").Value)
                registro.GuiaRemisionDet = GuiaRemisionDetalle
                registro.CanAte = toNumber(row.Cells("CanAte").Value)
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.PreFabrica = toDouble(row.Cells("DeaMer").Value)
                registro.PreCompensado = toDouble(row.Cells("PreCompensado").Value)

                estado_process = oSolicitudGarantiaAtencionService.ActualizarRepuesto(registro)
            Next

            actualizarDetallesRepuestos()
        Catch ex As Exception
            MsgBox("Error al actualizar Precio Fabrica Ok: " + ex.Message)
        End Try
    End Sub
End Class