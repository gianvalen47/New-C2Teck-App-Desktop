Imports System.ServiceModel

Public Class frmComOrdenCompra_ActMasivo

    'Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    'Private oPersonaService As New PersonaService.PersonaServiceClient

    Private Solicitud As Boolean
    Public IdOrden As Integer
    Public IdOrdenDet As Integer
    Public estado As Integer
    Public state_button As Boolean
    Public dtDetalles As DataTable
    Public Masivo As Boolean
    'Public CodArea As String                        'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014

    'Private dtAreas As DataTable                   'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014
    Private dtRubros As DataTable
    Private dtPlaca As DataTable
    Private dtCentroCosto As DataTable         'Se comenta ya que se ingresará los centros de costo en el modulo de facturación 05/05/2014

    Private Sub frmComOrdenCompra_ActMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraDetService.Close()
            oGastoRealService.Close()
            oJobService.Close()
            oVehiculoService.Close()
            'oMaestroService.Close()
            'oPersonaService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
            oGastoRealService.Abort()
            oJobService.Abort()
            oVehiculoService.Abort()
            'oMaestroService.Abort()
            'oPersonaService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
            oGastoRealService.Abort()
            oJobService.Abort()
            oVehiculoService.Abort()
            'oMaestroService.Abort()
            'oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmComOrdenCompra_ActMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_ActMasivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lblIdGasto.Text = CStr(IdGasto)
        Me.Text = "Actualizar Masivamente"
        Solicitud = oOrdenesCompraDetService.BuscarSolicitud(IdOrden, IdOrdenDet)
        LlenarCombos()
        txtNumJob.Focus()
        'cmbCentroCosto.Focus()
        'cmbCentroCosto.DroppedDown = True
        'cmbArea.Value = CodArea
        'ObtenerRegistro()
        activar()
    End Sub

    Private Sub activar()
        If Solicitud Then
            desactivar()
            If estado = 1 Then          'se cambio para modificar el Job '17/01/2012
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbRubro.ReadOnly = False
                cmbRubro.BackColor = System.Drawing.SystemColors.Window
            End If
        Else
            If state_button Then
                If estado <> 1 Then
                    desactivar()
                Else
                    txtNumJob.ReadOnly = False
                    txtNumJob.BackColor = System.Drawing.SystemColors.Window
                    btnBuscarJob.Enabled = True
                    cmbRubro.ReadOnly = False
                    cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    'cmbArea.ReadOnly = False
                    'cmbArea.BackColor = System.Drawing.SystemColors.Window
                    'cmbCentroCosto.ReadOnly = False
                    'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                    cmbPlaca.ReadOnly = False
                    cmbPlaca.BackColor = System.Drawing.SystemColors.Window
                End If
            Else

                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbRubro.ReadOnly = False
                cmbRubro.BackColor = System.Drawing.SystemColors.Window
                'cmbArea.ReadOnly = False
                'cmbArea.BackColor = System.Drawing.SystemColors.Window
                'cmbCentroCosto.ReadOnly = False
                'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
                cmbPlaca.ReadOnly = False
                cmbPlaca.BackColor = System.Drawing.SystemColors.Window
            End If
        End If
    End Sub

    Private Sub desactivar()
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbRubro.ReadOnly = True
        cmbRubro.BackColor = System.Drawing.SystemColors.Control
        'cmbArea.ReadOnly = True
        'cmbArea.BackColor = System.Drawing.SystemColors.Control
        'cmbCentroCosto.ReadOnly = True
        'cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        cmbPlaca.ReadOnly = True
        cmbPlaca.BackColor = System.Drawing.SystemColors.Control
    End Sub

    'Private Sub ObtenerRegistro()
    '    Try
    '        Dim registro As OrdenesCompraDetService.OrdenesCompraDet
    '        registro = oOrdenesCompraDetService.Obtener(toNumber(IdOrdenDet))

    '        txtNumJob.Text = registro.Job.CodJob
    '        cmbArea.Value = registro.CentroCosto.Area.CodArea
    '        cmbCentroCosto.Value = registro.CentroCosto.CodCentro

    '        If CStr(registro.RubroGasto.CodRubro) <> "" Then
    '            cmbRubro.Value = registro.RubroGasto.CodRubro
    '        Else
    '            cmbRubro.SelectedIndex = 0
    '        End If

    '        If registro.Unidad.Placa = Nothing Or registro.Unidad.Placa = "" Then
    '            cmbPlaca.SelectedIndex = 0
    '        Else
    '            cmbPlaca.Value = registro.Unidad.Placa
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub LlenarCombos()
        Try

            ''========================================== AREAS ===============================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'dtAreas = Nothing

            ''========================================== RUBROS ===============================================
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '========================================== PLACA ===============================================
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos1(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
    '    Try
    '        'If cmbArea.Value <> "" Then
    '        '====================================== CENTRO COSTO ===========================================
    '        dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
    '        'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
    '        cmbCentroCosto.DataSource = dtCentroCosto
    '        cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
    '        cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '        cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
    '        'If cmbArea.Value <> "" Then
    '        '    cmbCentroCosto.SelectedIndex = 1
    '        'Else
    '        cmbCentroCosto.SelectedIndex = 0
    '        'End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim estado_process As Boolean
            If Masivo = True Then
                estado_process = oOrdenesCompraDetService.ActualizarMasivo(IdOrden, toNull(txtNumJob.Text), toNull(cmbRubro.Value), IIf(cmbPlaca.Value = "(Ninguno)", Nothing, cmbPlaca.Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se actualizo masivamente correctamente", MsgBoxStyle.Information, "Información")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar Masivamente : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Len(Trim(txtNumJob.Text)) > 0 Then
                    If Not (oJobService.Buscar(txtNumJob.Text)) Then
                        MsgBox("Número de OT no existente, Verifique")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()
                    ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                        MsgBox("Número de OT Liquidado, Verifique")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()
                    Else
                        If txtNumJob.Enabled = True Then
                            cmbRubro.Enabled = True
                            cmbRubro.BackColor = System.Drawing.SystemColors.Window
                        End If
                        cmbRubro.Focus()
                    End If
                Else
                    cmbRubro.Enabled = False
                    cmbRubro.BackColor = System.Drawing.SystemColors.Control
                    cmbRubro.SelectedIndex = 0
                    cmbPlaca.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumJob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.TextChanged
        If txtNumJob.Text <> "" Then
            If txtNumJob.Enabled = True Then
                cmbRubro.Enabled = True
                cmbRubro.BackColor = System.Drawing.SystemColors.Window
            Else
                cmbRubro.Enabled = False
                cmbRubro.BackColor = System.Drawing.SystemColors.Control
            End If
        Else
            cmbRubro.Enabled = False
            cmbRubro.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    If txtNumJob.Enabled = True Then
                        cmbRubro.Enabled = True
                        cmbRubro.BackColor = System.Drawing.SystemColors.Window
                    End If
                    cmbRubro.Focus()
                End If
            Else
                cmbRubro.Enabled = False
                cmbRubro.BackColor = System.Drawing.SystemColors.Control
                cmbRubro.SelectedIndex = 0
                cmbPlaca.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub
End Class