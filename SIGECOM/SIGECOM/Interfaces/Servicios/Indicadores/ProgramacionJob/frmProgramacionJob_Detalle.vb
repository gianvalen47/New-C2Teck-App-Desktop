Imports System.ServiceModel

Public Class frmProgramacionJob_Detalle

    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public IdProgramacion As Integer
    Private dtTiposMotores As DataTable
    Private dtTipoMantenimiento As DataTable
    Private dtDatos As DataTable
    Private CodMantenimiento As String
    Private dtPlan As DataTable
    Public CodMon As String

    Private Sub frmProgramacionJob_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            oTipoMotorService.Close()
            oJobService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            oTipoMotorService.Abort()
            oJobService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            oTipoMotorService.Abort()
            oJobService.Abort()
            oCotizacionServicioService.Abort()
        End Try
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cmbTipMot.KeyPress _
                       , txtFecInicioRep.KeyPress
        ', txtObsDet.KeyPress _
        ', txtFecha.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub frmProgramacionJob_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProgramacionJob_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        'listaDatos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            'actualizarDetalles()
            Me.Size = New System.Drawing.Size(914, 520)
            Me.Text = "Programación OT"
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            gbDetalle.Visible = True
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(914, 158)
            Me.Text = "Registrar Nueva Programacion"
            activar()
            gbDetalle.Visible = False
        End If

        listaDatos()

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As IndicadoresServicioService.ProgramacionJob
            registro = oIndicadoresServicioService.ObtenerProgramacion(utils.toNumber(IdProgramacion))

            IdProgramacion = registro.IdProgramacion
            txtNumJob.Text = registro.Job.CodJob
            LlenarTipoMotores()
            cmbTipMot.Value = registro.TipoMotor.TipMot
            txtFecInicioRep.Value = registro.FecIniRep
            'dtpFecFinRep.Value = utils.toBlank(registro.FecFinRep)

            'Me.Text = "Solicitud de Gasto Nº " + registro.IdGasto.ToString
            CodMon = registro.Job.Moneda.CodMon



        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()

        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbTipMot.ReadOnly = True
        cmbTipMot.BackColor = System.Drawing.SystemColors.Control
        'cmbMoneda.ReadOnly = True
        'cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtFecInicioRep.ReadOnly = True
        txtFecInicioRep.BackColor = System.Drawing.SystemColors.Control
        'txtFecFinRep.Enabled = False
        'txtFecFinRep.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        EnableOptions()

    End Sub

    Private Sub llenarCombos()
        Try
            ''======================================= TIPO MANTENIMIENTO ================================================
            'dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            'dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            'cmbMantenimiento.DataSource = dtTipoMantenimiento
            'cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            'cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            'cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            'cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            'cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            ''cmbMantenimiento.SelectedIndex = 0
            'dtTipoMantenimiento = Nothing

            ''======================================= TIPOS DE MOTORES =========================================
            'dtTiposMotores = oIndicadoresServicioService.MostrarTipoMotor(CodMantenimiento).Tables(0)
            ''dtTiposMotores.Rows.InsertAt(getRowTodos(dtTiposMotores), 0)
            'cmbTipMot.DataSource = dtTiposMotores
            'cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            'cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            'cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            'cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            'cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            'cmbTipMot.SelectedIndex = 0
            'dtTiposMotores = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message)
        End Try
    End Sub

    Private Sub LlenarTipoMotores()
        Try

            '======================================= TIPOS DE MOTORES =========================================
            dtTiposMotores = oIndicadoresServicioService.MostrarTipoMotor(CodMantenimiento).Tables(0)
            'dtTiposMotores.Rows.InsertAt(getRowTodos(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("DesMantenimiento").ToString
            If dtTiposMotores.Rows.Count > 0 Then
                cmbTipMot.SelectedIndex = 0
            Else
                cmbTipMot.Value = ""
            End If

            dtTiposMotores = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR TIPO MOTORES: " + ex.Message)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try

        Return fila
    End Function

    Private Sub ObtenerFecha()
        Try
            'Comentado el 22-07-13
            'Dim registro As JobService.Job
            'registro = oJobService.Obtener(txtNumJob.Text)

            'txtFecInicioRep.Value = registro.FecInicio

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER FECHA DEL OT: " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                    ObtenerMantenimientoJob()
                    LlenarTipoMotores()
                    ObtenerFecha()
                    cmbTipMot.Focus()
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Len(Trim(txtNumJob.Text)) > 0 Then
                    If Not (oJobService.Buscar(txtNumJob.Text)) Then
                        MsgBox("Número de OT no existente, Verifique.")
                        txtNumJob.Text = ""
                        txtNumJob.Focus()
                    Else
                        ObtenerMantenimientoJob()
                        LlenarTipoMotores()
                        ObtenerFecha()
                        cmbTipMot.Focus()
                    End If
                Else
                    'cmbTipMot.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT: " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique.")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    ObtenerMantenimientoJob()
                    LlenarTipoMotores()
                    ObtenerFecha()
                    cmbTipMot.Focus()
                End If
            Else
                'cmbTipMot.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT: " + ex.Message)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If ValidaCampos() Then

                ObtenerMantenimientoJob()

                Dim registro As New IndicadoresServicioService.ProgramacionJob
                Dim Job As New IndicadoresServicioService.Job
                Dim TipoMotor As New IndicadoresServicioService.TipoMotor
                Dim TipoMantenimiento As New IndicadoresServicioService.TipoMantenimiento

                registro.IdProgramacion = IdProgramacion
                Job.CodJob = txtNumJob.Text.Trim
                Job.TipoMantenimiento = TipoMantenimiento
                TipoMantenimiento.CodMantenimiento = CodMantenimiento
                registro.Job = Job
                TipoMotor.TipMot = cmbTipMot.Value
                registro.TipoMotor = TipoMotor
                registro.FecIniRep = txtFecInicioRep.Value
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.CodUsu = Session.sCodUsu

                Insertar(registro)

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS: " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerMantenimientoJob()
        Try
            Dim registro As JobService.Job
            registro = oJobService.Obtener(Trim(txtNumJob.Text))

            CodMantenimiento = registro.TipoMantenimiento.CodMantenimiento

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL MANTENIMIENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.ProgramacionJob)
        Try
            Dim estado_process As Integer
            estado_process = oIndicadoresServicioService.InsertarProgramacion(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdProgramacion = estado_process
                MsgBox("Se ingresó la programación correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el Proceso, Comunicarse con el Administrador del TI.")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS: " + ex.Message)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvDatos.RowCount < 1 Then
                miMostrar.Enabled = False
            Else
                miMostrar.Enabled = True
            End If

            biEditarr.Enabled = Not edicion
            biCerrar.Enabled = Not edicion
            biGuardar.Enabled = edicion
            biDeshacerr.Enabled = edicion

            cmbOpciones.Enabled = Not edicion

        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES : " + ex.Message)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.MostrarProgramacionDet(IdProgramacion).Tables(0)
            dgvDatos.DataSource = dtDatos


            dtPlan = oIndicadoresServicioService.CalcularHorasPlaneadas(IdProgramacion).Tables(0)
            lblCostoPlan.Text = "Total Costo Planeado " & CodMon
            txtCostoPlan.Text = dtPlan.Rows(0).Item("CostoPlaneado")
            lblCostoReal.Text = "Total Costo Real " & CodMon
            txtCostoReal.Text = dtPlan.Rows(0).Item("CostoReal")
            txtHoraPlan.Text = dtPlan.Rows(0).Item("HorasPlan")
            txtHoraReal.Text = dtPlan.Rows(0).Item("HorasReal")

            EnableOptions()
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtNumJob.Text) = "" Then
                MsgBox("Debe ingresar el numero de OT ")
                txtNumJob.Focus()
                Return False
            ElseIf utils.toBlank(cmbTipMot.Text) = "" Then
                MsgBox("Debe ingresar el tipo de motor")
                cmbTipMot.Focus()
                Return False
            ElseIf utils.toBlank(txtFecInicioRep.Text) = "" Then
                MsgBox("Debe ingresar la fecha de inicio de reparación")
                txtFecInicioRep.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "ProgPersona" Then
                Dim frm As New frmProgramacionJob_DetalleAct
                frm.IdProgramacion = CInt(dgvDatos.CurrentRow.Cells("IdProgramacion").Value)
                frm.IdProgramacionDet = CInt(dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value)
                frm.DesActividad = dgvDatos.CurrentRow.Cells("DesActividad").Value
                frm.TipoMot = dgvDatos.CurrentRow.Cells("TipMot").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar la gráfica" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditarr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub activar()

        If state_button Then
            txtFecInicioRep.ReadOnly = True
            txtFecInicioRep.BackColor = System.Drawing.SystemColors.Control
        Else
            txtFecInicioRep.ReadOnly = False
            txtFecInicioRep.BackColor = System.Drawing.SystemColors.Window
        End If
        edicion = True
        EnableOptions()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, miMostrar.Click
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmProgramacionJob_DetalleAct
                frm.IdProgramacion = CInt(dgvDatos.CurrentRow.Cells("IdProgramacion").Value)
                frm.IdProgramacionDet = CInt(dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value)
                frm.IdActividadDet = CInt(dgvDatos.CurrentRow.Cells("IdActividadDet").Value)
                frm.CodMantenimiento = CInt(dgvDatos.CurrentRow.Cells("CodMantenimiento").Value)
                frm.DesActividad = dgvDatos.CurrentRow.Cells("DesActividad").Value
                frm.TipoMot = dgvDatos.CurrentRow.Cells("TipMot").Value
                frm.editable = True
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    'ObtenerRegistro()
                    'If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdProgramacionDet)
                    'End If
                Else
                    Actualizar()
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdProgramacionDet").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        EnableOptions()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdProgramacionDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        Try
            Dim lLog As Boolean = True

            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    While lLog
                        Dim frm As New frmProgramacionJob_DetalleAct
                        frm.IdProgramacion = CInt(dgvDatos.CurrentRow.Cells("IdProgramacion").Value)
                        frm.IdProgramacionDet = CInt(dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value)
                        frm.IdActividadDet = CInt(dgvDatos.CurrentRow.Cells("IdActividadDet").Value)
                        frm.CodMantenimiento = CInt(dgvDatos.CurrentRow.Cells("CodMantenimiento").Value)
                        frm.DesActividad = dgvDatos.CurrentRow.Cells("DesActividad").Value
                        frm.TipoMot = dgvDatos.CurrentRow.Cells("TipMot").Value
                        e.Handled = True
                        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                            dtDatos = Nothing
                            listaDatos()
                            'ObtenerRegistro()
                            If frm.type_process = "update" Then
                                RowPossesion(dgvDatos, frm.IdProgramacionDet)
                            End If
                        Else
                            lLog = False
                        End If
                    End While
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        Actualizar()
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub miActualizarFecha_Click(sender As Object, e As EventArgs) Handles miActualizarFecha.Click
        Try
            Dim frm As New frmProgramacionJob_ActFecha
            frm.IdProgramacionDet = dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value
            frm.DesActividad = dgvDatos.CurrentRow.Cells("DesActividad").Value
            frm.txtFecInicio.Value = dgvDatos.CurrentRow.Cells("FecIniPla").Value
            frm.txtFecFin.Value = dgvDatos.CurrentRow.Cells("FecFinPla").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                miActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR la Fecha: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class