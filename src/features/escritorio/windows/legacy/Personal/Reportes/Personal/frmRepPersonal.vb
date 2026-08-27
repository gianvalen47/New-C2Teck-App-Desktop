Imports System.ServiceModel
Public Class frmRepPersonal

    '===========================Servicios====================================================
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtClase As DataTable
    Private dtColumnas As DataTable

    Private Sub frmRepPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPersonaService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRepPersonal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 224)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvColumnas)
        rbPrincipal.Checked = True
        cmbArea.Focus()
        llenarCombos()
        ListarColumnas()

        'Solicitud de Marlene Moreno Habilitar solo el reporte principal al Perfil Entrenador (Sr. Josep Mata)
        If Session.CodPerfil = "46" Then
            rbDinamico.Enabled = False
        Else
            rbDinamico.Enabled = True
        End If
    End Sub

    Private Sub Reporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                rbPrincipal.KeyPress _
                              , rbDinamico.KeyPress _
                              , cmbArea.KeyPress _
                              , cmbCentroCosto.KeyPress _
                              , cmbClase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
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

    Private Sub llenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtArea.Rows.InsertAt(getRowTodos(dtArea), 0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================== CLASE ================================================
            dtClase = oPersonaService.MostrarClases.Tables(0)
            dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ==========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            dtCentroCosto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarColumnas()
        Try

            dtColumnas = oPersonaService.MostrarAtributos(Session.sCodUsu)
            dgvColumnas.DataSource = dtColumnas

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR COLUMNAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If txtFecInicio.Value > txtFecFinal.Value Then
            '    MsgBox("La fecha de inicio no debe ser mayor a la fecha final.", MsgBoxStyle.Information, "Información")
            '    txtFecInicio.Focus()
            '    Return False
            'Else
            Return True
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarP.Click
        Try
            If ValidaCampos() Then

                oSeguridadService.RegistrarVisitaOpciones(224, "SYSTECK", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                If rbPrincipal.Checked = True Then

                    Dim forma As New frmReportes
                    Dim reporte As New rptRepPersonal
                    Dim dtReporte As New DataTable

                    dtReporte = oPersonaService.Reporte(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), IIf(cbVigente.Checked = True, True, False)).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte
                        'forma.crvReportes.DisplayGroupTree = False
                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        forma.Text = "Reporte de Personal"
                        reporte.SetParameterValue("pEstado", IIf(cbVigente.Checked = True, "PERSONAL VIGENTE", "PERSONAL NO VIGENTE"))
                        forma.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnAceptarD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarD.Click
        Try
            If ValidaCampos() Then
                If rbDinamico.Checked = True Then

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = False Then
                        MsgBox("No tienes permiso para descargar datos!!!!!")
                        Return
                    End If

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim Cadena As String = ""
                    rows = dgvColumnas.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow
                    Dim dtDatosExcel As DataTable

                    If rows.Count > 0 Then
                        For Each row In rows
                            If Cadena = "" Then
                                Cadena = row.Cells("Columna").Text
                            Else
                                Cadena = Cadena + "," + row.Cells("Columna").Text
                            End If
                        Next

                        dtDatosExcel = oPersonaService.ReporteDinamico(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value),
                                                                                                toBlank(cmbClase.Value), IIf(cbVigente.Checked = True, True, False), Cadena).Tables(0)
                        dgvDatosExcel.DataSource = dtDatosExcel

                        Dim Export As Boolean = ExportarExcel(dgvDatosExcel)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If

                    Else
                        MsgBox("Debe seleccionar alguna de las columnas", MsgBoxStyle.Critical, "Error de datos")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub rbPrincipal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbPrincipal.CheckedChanged
        If rbPrincipal.Checked = True Then
            dgvColumnas.Visible = False
            gbDatos.Size = New System.Drawing.Size(459, 173)
            Me.Size = New System.Drawing.Size(480, 252)
            btnAceptarP.Visible = True
            btnAceptarD.Visible = False
        ElseIf rbDinamico.Checked = True Then
            dgvColumnas.Visible = True
            gbDatos.Size = New System.Drawing.Size(640, 173)
            Me.Size = New System.Drawing.Size(662, 252)
            btnAceptarP.Visible = False
            btnAceptarD.Visible = True
        End If
    End Sub
End Class