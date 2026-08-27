Imports System.ServiceModel

Public Class frmProgramacionJob_DetalleAct

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    Public type_process As String            'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public edicionNuevo As Boolean = False
    Private dtAtraso As DataTable
    Private dtDatos As DataTable
    Private IdAtraso As Integer
    Public IdProgramacion As Integer
    Public IdProgramacionDet As Integer
    Private IdPersona As Integer
    Public DesActividad As String
    Public IdActividadDet As String
    Public CodMantenimiento As String
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Private Atraso As Boolean

    Public TipoMot As String

    Private Sub frmProgramacionJob_DetalleAct_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
        End Try
    End Sub

    Private Sub frmProgramacionJob_DetalleAct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProgramacionJob_DetalleAct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        txtDesActividad.Text = DesActividad        

        LlenarCombos()
        listaDatos()
        desactivar()

    End Sub

    Private Sub LlenarCombos()
        '======================================= TIPO MANTENIMIENTO ================================================
        dtAtraso = oIndicadoresServicioService.MostrarAtraso().Tables(0)
        dtAtraso.Rows.InsertAt(getRowTodos(dtAtraso), 0)
        cmbAtraso.DataSource = dtAtraso
        cmbAtraso.DropDownList.DataMember = dtAtraso.Columns("DesAtraso").ToString
        cmbAtraso.DropDownList.DisplayMember = dtAtraso.Columns("DesAtraso").ToString
        cmbAtraso.DropDownList.ValueMember = dtAtraso.Columns("IdAtraso").ToString
        cmbAtraso.DropDownList.Columns(0).DataMember = dtAtraso.Columns("IdAtraso").ToString
        cmbAtraso.DropDownList.Columns(1).DataMember = dtAtraso.Columns("DesAtraso").ToString
        cmbAtraso.SelectedIndex = 0
        dtAtraso = Nothing
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
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
        Return fila
    End Function

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.FiltrarReal(IdProgramacionDet).Tables(0)
            dgvDatos.DataSource = dtDatos

            EnableOptions()
            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvDatos.RowCount < 1 Then
                miMostrar.Enabled = False
                biEditar.Enabled = False
            Else
                miMostrar.Enabled = True
                biEditar.Enabled = Not edicion
            End If

            'biEditarr.Enabled = Not edicion
            btnCerrar.Enabled = Not edicion
            biGrabar.Enabled = edicion
            'biNuevo.Enabled = edicion
            biDeshacer.Enabled = edicion
            dgvDatos.Enabled = Not edicion
            cmbOpciones.Enabled = Not edicion

        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES : " + ex.Message)
        End Try
    End Sub

    'Private Sub enableOpciones()
    '    If dgvDatos.RowCount < 1 Then
    '         miMostrar.Enabled = False
    '        biEditar.Enabled = False
    '    Else
    '        miMostrar.Enabled = True
    '        biEditar.Enabled = Not edicion
    '    End If
    '    biNuevo.Enabled = edicion

    '    btnCerrar.Enabled = Not edicion
    '    biGrabar.Enabled = edicion
    '    biDeshacer.Enabled = edicion
    '    dgvDatos.Enabled = Not edicion
    '    gb.Enabled = IIf(Not edicion, True, False)
    'End Sub


    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If ValidaCampos() Then

                Dim registro As New IndicadoresServicioService.ProgramacionJobDetReal
                Dim Persona As New IndicadoresServicioService.Persona
                Dim ProgramacionJobDet As New IndicadoresServicioService.ProgramacionJobDet
                Dim ProgramacionJob As New IndicadoresServicioService.ProgramacionJob

                ProgramacionJob.IdProgramacion = IdProgramacion
                ProgramacionJobDet.ProgramacionJob = ProgramacionJob
                ProgramacionJobDet.IdProgramacionDet = IdProgramacionDet
                registro.ProgramacionJobDet = ProgramacionJobDet
                registro.Ejecutado = cbEjecutado.Checked
                registro.IdAtraso = IIf(cmbAtraso.SelectedIndex = 0, Nothing, utils.toNumber(cmbAtraso.Value))
                registro.DesAtraso = utils.toNull(txtDesAtraso.Text)
                registro.FecFinReal = txtFecFinReal.Value                
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If edicionNuevo = True Then
                    Insertar(registro)
                Else
                    Modificar(registro)
                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtFecFinReal.Text) = "" Then
                MsgBox("Debe ingresar la fecha fin real")
                txtFecFinReal.Focus()
                Return False
            ElseIf utils.toNumber(cmbAtraso.Value) <> 0 And txtDesAtraso.Text = "" Then
                MsgBox("Debe ingresar el motivo del atraso")
                txtDesAtraso.Focus()
                Return False
            ElseIf utils.toNumber(cmbAtraso.Value) = 0 And txtDesAtraso.Text <> "" Then
                MsgBox("Debe ingresar el atraso")
                cmbAtraso.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.ProgramacionJobDetReal)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.InsertarReal(registro)

            If estado_process Then
                MsgBox("Se ingresó la programación real correctamente")
                listaDatos()
                'LimpiarDatos()
                'btnBuscarPersonaS.Focus()
                type_process = "update"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                biNuevo.Enabled = True
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As IndicadoresServicioService.ProgramacionJobDetReal)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarReal(registro)
            type_process = "update"

            If estado_process Then
                MsgBox("Se modificó la programación real correctamente.")
                listaDatos()
                desactivar()
                ObtenerRegistroDetalle()
                biNuevo.Enabled = True
            Else
                MsgBox("Error en el Proceso, Comunicarse con el Administrador del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub


    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If dgvDatos.RowCount > 0 Then
            Mostrar()
        End If
    End Sub

    Private Sub activar()

        If edicionNuevo = True Then
            txtFecFinReal.Enabled = True
            txtFecFinReal.BackColor = System.Drawing.SystemColors.Window
        Else
            txtFecFinReal.Enabled = False
            txtFecFinReal.BackColor = System.Drawing.SystemColors.Control
        End If

        cbEjecutado.Enabled = True
        cmbAtraso.Enabled = True
        cmbAtraso.BackColor = System.Drawing.SystemColors.Window
        txtDesAtraso.Enabled = True
        txtDesAtraso.BackColor = System.Drawing.SystemColors.Window
        edicion = True
        EnableOptions()
        'enableOpciones()
    End Sub

    Private Sub desactivar()

        txtFecFinReal.Enabled = False
        txtFecFinReal.BackColor = System.Drawing.SystemColors.Control
        cbEjecutado.Enabled = False
        cmbAtraso.Enabled = False
        cmbAtraso.BackColor = System.Drawing.SystemColors.Control
        txtDesAtraso.Enabled = False
        txtDesAtraso.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        EnableOptions()
        'enableOpciones()
    End Sub

    Private Sub ObtenerRegistroDetalle()
        Try
            If dgvDatos.RowCount > 0 Then
                Dim registro As IndicadoresServicioService.ProgramacionJobDetReal
                registro = oIndicadoresServicioService.MostrarPorIdReal(IdProgramacionDet, dgvDatos.CurrentRow.Cells("FecFinReal").Text)

                IdProgramacionDet = registro.ProgramacionJobDet.IdProgramacionDet
                txtFecFinReal.Value = registro.FecFinReal
                cbEjecutado.Checked = registro.Ejecutado
                cmbAtraso.Value = registro.IdAtraso
                txtDesAtraso.Text = registro.DesAtraso
            End If


        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmProgramacionJob_Persona

            frm.DesActividad = DesActividad
            frm.CodMantenimiento = CodMantenimiento
            frm.TipoMot = TipoMot
            frm.IdActividadDet = IdActividadDet
            frm.FecFinReal = dgvDatos.CurrentRow.Cells("FecFinReal").Text
            frm.IdProgramacionDet = dgvDatos.CurrentRow.Cells("IdProgramacionDet").Text
            frm.IdProgramacion = IdProgramacion



            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()

            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PROGRAMACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdPer").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 2
            End If
        Next
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then
                'If MsgBox("¿Estas seguro de ELIMINAR la Programación Persona N° " & dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If MsgBox("¿Está seguro de ELIMINAR la programación real?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oIndicadoresServicioService.BorrarReal(dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value, dgvDatos.CurrentRow.Cells("FecFinReal").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        'MsgBox("Se elimino correctamente el registro ")
                        listaDatos()
                        'type_process = "update"
                        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                    End If
                    'listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Eliminar" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub actualizar()
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

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        listaDatos()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If dgvDatos.RowCount > 0 Then
            Mostrar()
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        ObtenerRegistroDetalle()
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        edicionNuevo = False
        activar()
        biNuevo.Enabled = False
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        edicionNuevo = True
        activar()
        LimpiarTodo()
        biNuevo.Enabled = False
        txtFecFinReal.Focus()
    End Sub

    Private Sub LimpiarTodo()

        cbEjecutado.Checked = False
        cmbAtraso.SelectedIndex = 0
        txtDesAtraso.Text = ""

    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        desactivar()
        biNuevo.Enabled = True
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class