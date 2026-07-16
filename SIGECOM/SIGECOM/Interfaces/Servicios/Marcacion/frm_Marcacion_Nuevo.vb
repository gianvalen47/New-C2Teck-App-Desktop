Imports System.ServiceModel
Public Class frm_Marcacion_Nuevo

    '===========================Servicios====================================
    Private oMarcacionJobService As New MarcacionJobService.MarcacionJobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oHorarioService As New HorarioService.HorarioServiceClient
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient

    '======================Declaración de Variables==============================
    Public IdMarca As Integer
    Public Actualizar As Boolean
    Public Nuevo As Boolean

    Public IdPersona As Integer
    Private TipoCalculo As Integer
    Private Oficinas As String
    Private dtDetalles As New DataTable
    Private dtHorarios As DataTable


    Private Sub frm_Marcacion_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacionJobService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oHorarioService.Close()
            oAsignacionHorarioService.Close()
        Catch ex As TimeoutException
            oMarcacionJobService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oHorarioService.Abort()
            oAsignacionHorarioService.Abort()
        Catch ex As CommunicationException
            oMarcacionJobService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oHorarioService.Abort()
            oAsignacionHorarioService.Abort()
        End Try
    End Sub

    Private Sub frm_Marcacion_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frm_Marcacion_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim IdMarca2 As Integer
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarcombos()

        If Actualizar = True Then
            ''IdMarca2 recoge el valor para el Row Possition antes de que cambie en listaDatos
            IdMarca2 = IdMarca
            ObtenerRegistro()
            Desactivar()
            listaDatos()
            RowPossesion(dgvDatos, IdMarca2)
        Else
            cbHorarioAsignado.Checked = True
            Activar()
        End If
        biDeshacer.Enabled = False
        'listaDatos()
    End Sub

    Private Sub llenarcombos()
        Try

            '================================= HORARIOS ===================================
            dtHorarios = oHorarioService.Mostrar(Session.sCodEmp).Tables(0)
            cmbHorario.DataSource = dtHorarios
            cmbHorario.DropDownList.DataMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.DropDownList.DisplayMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.DropDownList.ValueMember = dtHorarios.Columns("CodHor").ToString
            cmbHorario.DropDownList.Columns(0).DataMember = dtHorarios.Columns("CodHor").ToString
            cmbHorario.DropDownList.Columns(1).DataMember = dtHorarios.Columns("DesHor").ToString
            cmbHorario.SelectedIndex = 0
            dtHorarios = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub Desactivar()
        Try
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False
            txtSolicitante.ReadOnly = True
            txtSolicitante.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = False
            gbOpciones.Enabled = False
            cmbHorario.ReadOnly = True
            cmbHorario.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            txtHoraIng.ReadOnly = True
            txtHoraIng.BackColor = System.Drawing.SystemColors.Control
            txtHoraSal.ReadOnly = True
            txtHoraSal.BackColor = System.Drawing.SystemColors.Control
            txtIngReal.ReadOnly = True
            txtIngReal.BackColor = System.Drawing.SystemColors.Control
            txtSalReal.ReadOnly = True
            txtSalReal.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

            btnGuardar.Enabled = False
            biNuevo.Enabled = True
            biEditar.Enabled = True
            biDeshacer.Enabled = False
            biVerHoras.Enabled = True
            biSalir.Enabled = True
            dgvDatos.Enabled = True

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Activar()
        Try
            If Actualizar Then

                txtNumJob.ReadOnly = True
                txtNumJob.BackColor = System.Drawing.SystemColors.Control
                btnBuscarJob.Enabled = False
                txtSolicitante.ReadOnly = True
                txtSolicitante.BackColor = System.Drawing.SystemColors.Control
                btnBuscarPersona.Enabled = False
                gbOpciones.Enabled = True
                cmbHorario.ReadOnly = False
                cmbHorario.BackColor = System.Drawing.SystemColors.Window
                txtFecha.ReadOnly = True
                txtFecha.BackColor = System.Drawing.SystemColors.Control
                txtHoraIng.ReadOnly = True
                txtHoraIng.BackColor = System.Drawing.SystemColors.Control
                txtHoraSal.ReadOnly = True
                txtHoraSal.BackColor = System.Drawing.SystemColors.Control
                txtIngReal.ReadOnly = False
                txtIngReal.BackColor = System.Drawing.SystemColors.Window
                txtSalReal.ReadOnly = False
                txtSalReal.BackColor = System.Drawing.SystemColors.Window
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                btnGuardar.Enabled = True
                biNuevo.Enabled = False
                biEditar.Enabled = False
                biDeshacer.Enabled = True
                biVerHoras.Enabled = True
                dgvDatos.Enabled = False


            Else
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                txtSolicitante.ReadOnly = True
                txtSolicitante.BackColor = System.Drawing.SystemColors.Control
                btnBuscarPersona.Enabled = True
                gbOpciones.Enabled = True
                cmbHorario.ReadOnly = False
                cmbHorario.BackColor = System.Drawing.SystemColors.Window
                txtFecha.ReadOnly = False
                txtFecha.BackColor = System.Drawing.SystemColors.Window
                txtFecha.Value = Today()
                txtHoraIng.ReadOnly = False
                txtHoraIng.BackColor = System.Drawing.SystemColors.Window
                txtHoraSal.ReadOnly = False
                txtHoraSal.BackColor = System.Drawing.SystemColors.Window
                txtIngReal.ReadOnly = True
                txtIngReal.BackColor = System.Drawing.SystemColors.Window
                txtSalReal.ReadOnly = True
                txtSalReal.BackColor = System.Drawing.SystemColors.Window
                txtHoraIng.Text = Now().ToString("HH:mm:ss")
                txtIngReal.Text = txtHoraIng.Text
                txtHoraSal.Text = Now().ToString("HH:mm:ss")
                txtSalReal.Text = txtHoraSal.Text
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                btnGuardar.Enabled = True
                dgvDatos.Enabled = True

                biNuevo.Enabled = False
                biEditar.Enabled = False
                biDeshacer.Enabled = True
                biVerHoras.Enabled = True

            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtNumJob.Text) = "" Then
                MsgBox("Debe ingresar el OT")
                txtNumJob.Focus()
                Return False
            ElseIf utils.toNumber(IdPersona) = 0 Then
                MsgBox("Debe ingresar el Colaborador")
                txtSolicitante.Focus()
                Return False
            ElseIf utils.toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha")
                txtFecha.Focus()
                Return False
            ElseIf utils.toBlank(txtHoraIng.Text) = "" Then
                MsgBox("Debe ingresar la fecha de ingreso")
                txtHoraIng.Focus()
                Return False
            ElseIf utils.toBlank(txtIngReal.Text) = "" Then
                MsgBox("Debe ingresar la fecha real de ingreso")
                txtIngReal.Focus()
            ElseIf cbHorarioAsignado.Checked = True And utils.toBlank(cmbHorario.Value) = "" Then
                MsgBox("Debe ingresar el Horario")
                cmbHorario.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            If IdMarca <> 0 Then
                Dim registro As New MarcacionJobService.MarcacionJob
                registro = oMarcacionJobService.Obtener(IdMarca)

                txtFecha.Value = registro.Fecha
                txtNumJob.Text = registro.Job.CodJob
                IdPersona = registro.Persona.IdPer
                txtSolicitante.Text = registro.Persona.ApeNom
                txtHoraIng.Text = registro.HorIngMarca.ToLongTimeString
                txtIngReal.Text = registro.HorIngReal.ToLongTimeString
                txtHoraSal.Text = registro.HorSalMarca.ToLongTimeString
                txtSalReal.Text = registro.HorSalReal.ToLongTimeString
                txtObservacion.Text = registro.Observacion
                'cmbOficinas.Value = registro.Oficina.CodOfi
                'cmbOficinas1.Value = registro.Oficina.CodOfi
                cmbHorario.Value = registro.Horario.CodHor
                If registro.TipoCalculo = 1 Then
                    cbHorarioAsignado.Checked = True
                ElseIf registro.TipoCalculo = 2 Then
                    cbCalcularViaje.Checked = True
                ElseIf registro.TipoCalculo = 3 Then
                    cbCalcular100.Checked = True
                ElseIf registro.TipoCalculo = 4 Then
                    cbCalcularNormal.Checked = True
                ElseIf registro.TipoCalculo = 5 Then
                    cbCalcular35.Checked = True
                ElseIf registro.TipoCalculo = 6 Then
                    cbCalcular25.Checked = True
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al obtener registro : " + ex.Message)
        End Try
    End Sub

    Protected Sub enableOpciones()
        'Try
        '    If Actualizar = False Then
        '        btnGuardar.Enabled = True
        '        biNuevo.Enabled = False
        '        biEditar.Enabled = False
        '        biDeshacer.Enabled = True
        '        biVerHoras.Enabled = False

        '    Else
        '        btnGuardar.Enabled = True
        '        biNuevo.Enabled = True
        '        biEditar.Enabled = True
        '        biVerHoras.Enabled = True

        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR AL VALIDAR LAS OPCIONES : " + ex.Message)
        'End Try
    End Sub

    Protected Sub CambiarOpciones()
        btnGuardar.Enabled = True
        biNuevo.Enabled = False
        biEditar.Enabled = False
        biDeshacer.Enabled = True
        biVerHoras.Enabled = False
    End Sub

    Protected Sub Insertar(ByVal registro As MarcacionJobService.MarcacionJob)
        Try
            Dim codigo As String = ""
            Dim estado_process As Integer
            estado_process = oMarcacionJobService.Insertar(registro)
            If estado_process > 0 Then
                IdMarca = estado_process
                MsgBox("Se guardaron los datos correctamente")
                Actualizar = False
                Activar()
                'IdPersona = oMarcacionJobService.Obtener(IdMarca).Persona.IdPer
                'txtSolicitante.Text = oMarcacionJobService.Obtener(IdMarca).Persona.ApeNom
                txtNumJob.Text = oMarcacionJobService.Obtener(IdMarca).Job.CodJob
                'txtObservacion.Text = ""
                codigo = IdMarca
                'ObtenerRegistro()
                listaDatos()
                RowPossesion(dgvDatos, codigo)
                Remostrar()
                IdMarca = codigo
                ObtenerRegistro()
                biNuevo.Enabled = True
                biEditar.Enabled = True
                biDeshacer.Enabled = False
                'dgvDatos.Enabled = True
                Actualizar = True
                If Nuevo = True Then
                    Desactivar()
                End If
            Else
                MsgBox("Error en el proceso, comunicarse con el departamento de TI...")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Remostrar()

        cbHorarioAsignado.Checked = True
        cbCalcularViaje.Checked = False
        cbCalcular100.Checked = False
        cbCalcular25.Checked = False
        cbCalcular35.Checked = False
        gbOpciones.Enabled = True        
        cmbHorario.SelectedIndex = 0
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        IdMarca = 0
        txtHoraIng.ReadOnly = False
        txtHoraIng.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtHoraSal.ReadOnly = False
        txtHoraSal.BackColor = System.Drawing.SystemColors.Window
        txtIngReal.ReadOnly = True
        txtIngReal.BackColor = System.Drawing.SystemColors.Control
        txtSalReal.ReadOnly = True
        txtSalReal.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = True
        btnBuscarPersona.Enabled = True
        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        txtSolicitante.ReadOnly = True
        txtSolicitante.BackColor = System.Drawing.SystemColors.Control
        txtFecha.Value = Today()
        txtHoraIng.Text = Now().ToString("HH:mm:ss")
        txtIngReal.Text = txtHoraIng.Text
        txtHoraSal.Text = Now().ToString("HH:mm:ss")
        txtSalReal.Text = txtHoraSal.Text
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window                
        Actualizar = False

    End Sub

    Protected Sub Modificar(ByVal registro As MarcacionJobService.MarcacionJob)
        Try
            Dim codigo As String = ""
            Dim estado_process As Boolean
            estado_process = oMarcacionJobService.Actualizar(registro)
            If estado_process Then
                MsgBox("Se modifico el registro correctamente")
                'ObtenerRegistro()
                codigo = dgvDatos.CurrentRow.Cells("IdMarca").Value
                listaDatos()
                RowPossesion(dgvDatos, codigo)
                ObtenerRegistro()
                Desactivar()
                dgvDatos.Enabled = True
            Else
                MsgBox("Error en el Proceso Comunicarse con el Administrador del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdMarca").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
        End If
    End Sub

    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New MarcacionJobService.MarcacionJob
                Dim job As New MarcacionJobService.Job
                Dim persona As New MarcacionJobService.Persona
                Dim Horario As New MarcacionJobService.Horario
                Dim empresa As New MarcacionJobService.Empresa

                empresa.CodEmp = Session.sCodEmp
                registro.IdMarca = IdMarca
                job.CodJob = txtNumJob.Text
                registro.Job = job
                persona.IdPer = IdPersona
                registro.Persona = persona
                Horario.CodHor = cmbHorario.Value
                registro.Horario = Horario
                registro.Horario.Empresa = empresa
                registro.Fecha = txtFecha.Value
                registro.HorIngMarca = txtHoraIng.Text
                registro.HorSalMarca = txtHoraSal.Text
                registro.HorIngReal = txtIngReal.Text
                registro.HorSalReal = txtSalReal.Text
                registro.Observacion = utils.toNull(txtObservacion.Text)
                ''registro.Viaje = Nothing
                registro.TipoCalculo = TipoCalculo
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If Actualizar Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub TipoCalculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCalcular100.CheckedChanged, cbCalcularViaje.CheckedChanged, _
                                                                                                                                                                              cbHorarioAsignado.CheckedChanged, cbCalcularNormal.CheckedChanged, _
                                                                                                                                                                              cbCalcular25.CheckedChanged, cbCalcular35.CheckedChanged
        If cbHorarioAsignado.Checked Then
            TipoCalculo = 1
            lblHorario.Visible = True
            cmbHorario.Visible = True
        ElseIf cbCalcularViaje.Checked Then
            TipoCalculo = 2
            lblHorario.Visible = False
            cmbHorario.Visible = False
        ElseIf cbCalcular100.Checked Then
            TipoCalculo = 3
            lblHorario.Visible = False
           cmbHorario.Visible=False
        ElseIf cbCalcularNormal.Checked Then
            TipoCalculo = 4
            lblHorario.Visible = False
           cmbHorario.Visible=False
        ElseIf cbCalcular35.Checked Then
            TipoCalculo = 5
            lblHorario.Visible = False
            cmbHorario.Visible=False
        ElseIf cbCalcular25.Checked Then
            TipoCalculo = 6
            lblHorario.Visible = False
            cmbHorario.Visible=False
        End If
    End Sub

    Private Sub txtHoraIng_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHoraIng.TextChanged
        txtIngReal.Text = txtHoraIng.Text
    End Sub

    Private Sub txtHoraSal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHoraSal.TextChanged
        txtSalReal.Text = txtHoraSal.Text
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click, miModificar.Click
        Actualizar = True
        Activar()
        CambiarOpciones()
        ObtenerRegistro()
    End Sub


    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = ""
                    IdPersona = 0
                End If
                'listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub LimpiarTodo()
        'txtNumJob.Text = ""
        IdMarca = 0
        'IdPersona = 0
        'txtSolicitante.Text = ""
        txtSolicitante.ReadOnly = True
        txtSolicitante.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersona.Enabled = True
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False

        gbOpciones.Enabled = True
        cmbHorario.ReadOnly = False
        cmbHorario.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window        
        txtHoraIng.ReadOnly = False
        txtHoraIng.BackColor = System.Drawing.SystemColors.Window
        txtHoraSal.ReadOnly = False
        txtHoraSal.BackColor = System.Drawing.SystemColors.Window
        txtIngReal.ReadOnly = True
        txtIngReal.BackColor = System.Drawing.SystemColors.Control
        txtSalReal.ReadOnly = True
        txtSalReal.BackColor = System.Drawing.SystemColors.Control
        btnGuardar.Enabled = True

        txtFecha.Value = Today()

        txtHoraIng.Text = Now().ToString("HH:mm:ss")
        txtIngReal.Text = txtHoraIng.Text
        txtHoraSal.Text = Now().ToString("HH:mm:ss")
        txtSalReal.Text = txtHoraSal.Text

        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.Text = ""

        Actualizar = False
        dgvDatos.Enabled = True
        biDeshacer.Enabled = True

    End Sub

    Protected Sub listaDatos()
        Try
            dtDetalles = oMarcacionJobService.Filtrar(0, Nothing, txtNumJob.Text, "", "").Tables(0)
            'dtDetalles = oMarcacionJobService.Filtrar(0, "20/09/2011", "0229/11").Tables(0)
            dgvDatos.DataSource = dtDetalles

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES : " + ex.Message)
        End Try
    End Sub

    ''Private Sub cmbOficinas_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged, cmbOficinas1.ValueChanged
    ''    'Agregado el 16-12-13 por problemas a guardar en combo Oficina
    ''    If OficinaModif = True Then
    ''        ObtenerRegistro()
    ''    End If
    ''    '---
    ''    If cbCalcularViaje.Checked Then
    ''        Oficinas = CStr(cmbOficinas.Value)
    ''    ElseIf cbCalcularNormal.Checked Then
    ''        Oficinas = CStr(cmbOficinas1.Value)
    ''    End If

    ''End Sub

    ''Private Sub cmbOficinasCambio()
    ''    'Agregado el 16-12-13 por problemas a guardar en combo Oficina
    ''    If OficinaModif = True Then
    ''        ObtenerRegistro()
    ''    End If
    ''    '---
    ''    If cbCalcularViaje.Checked Then
    ''        Oficinas = CStr(cmbOficinas.Value)
    ''    ElseIf cbCalcularNormal.Checked Then
    ''        Oficinas = CStr(cmbOficinas1.Value)
    ''    End If
    ''End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    If Actualizar = True Then
                        listaDatos()
                        txtNumJob.Focus()
                        Desactivar()
                    Else
                        listaDatos()
                        LimpiarMarca()
                        LimpiarTodo()
                        txtNumJob.ReadOnly = False
                        txtNumJob.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarJob.Enabled = True
                    End If
                End If
            Else
                MsgBox("Ingrese un N° de OT")
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    MsgBox("Número de OT Liquidado o Facturado, Verifique")
                    listaDatos()
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    If Actualizar = True Then
                        listaDatos()
                        txtNumJob.Focus()
                        Desactivar()
                    Else
                        listaDatos()
                        LimpiarMarca()
                        LimpiarTodo()
                        txtNumJob.ReadOnly = False
                        txtNumJob.BackColor = System.Drawing.SystemColors.Window
                        btnBuscarJob.Enabled = True
                    End If
                End If
            Else
                MsgBox("Ingrese un N° de OT")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub

    Private Sub biVerHoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerHoras.Click
        Try
            If dgvDatos.RowCount > 0 Then
                Dim frm As New frmJobConsulta_Mostrar_ManoObra
                frm.CodJob = txtNumJob.Text.Trim
                frm.CodRubro = "1"
                frm.ShowDialog()
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then
                If MsgBox("¿Está seguro de ELIMINAR la Marcación N° " & dgvDatos.CurrentRow.Cells("IdMarca").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oMarcacionJobService.Borrar(dgvDatos.CurrentRow.Cells("IdMarca").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                    If estado_process Then
                        MsgBox("Se eliminó la Marcación correctamente ")
                        listaDatos()
                        btnGuardar.Enabled = False
                        biNuevo.Enabled = True
                        biEditar.Enabled = True
                        biDeshacer.Enabled = False
                        biVerHoras.Enabled = True
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        If Actualizar = False Then
            'LimpiarTodo()
            LimpiarMarca()
            If dgvDatos.RowCount <> 0 Then
                IdMarca = dgvDatos.CurrentRow.Cells("IdMarca").Value
                'ObtenerRegistro()
            End If
        Else
            IdMarca = dgvDatos.CurrentRow.Cells("IdMarca").Value
            ObtenerRegistro()
        End If
    End Sub

    Private Sub LimpiarMarca()
        IdMarca = 0
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        If Nuevo = True Then
            If Actualizar = True Then
                LimpiarTodo()
                Activar()
                CambiarOpciones()
            Else
                LimpiarTodo()
                Activar()
                CambiarOpciones()
            End If
        Else
            Actualizar = False
            'If Actualizar = True Then
            '    'LimpiarTodo()
            '    Activar()
            '    CambiarOpciones()
            'Else
            LimpiarTodo()
            Activar()
            CambiarOpciones()
            'cmbOficinasCambio()
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If txtNumJob.Text <> "" Then
            Desactivar()
            listaDatos()
            Actualizar = True
            ObtenerRegistro()
        End If
    End Sub
End Class