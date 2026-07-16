Imports System.ServiceModel

Public Class frmProgramacionJob_Persona

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient

    Public type_process As String            'update     insert      delete
    Private dtAtraso As DataTable
    Private dtDatos As DataTable
    Private IdAtraso As Integer
    Public IdProgramacion As Integer
    Public IdProgramacionDet As Integer
    Private IdPer As Integer
    Public DesActividad As String
    Public IdActividadDet As String
    Public CodMantenimiento As String
    'Public IdPer As Integer
    Public FecFinReal As Date
    Private Atraso As Boolean

    Public TipoMot As String           '------- Agregado el 04/04/2013 (cambios en la plantilla project)

    Private Sub frmProgramacionJob_Persona_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            'oTipoMotorService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            'oTipoMotorService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            'oTipoMotorService.Abort()
        End Try
    End Sub

    Private Sub frmProgramacionJob_Persona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProgramacionJob_Persona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        ''llenarCombos()
        txtDesActividad.Text = DesActividad
        txtFecFinReal.Value = FecFinReal
        ObtenerHoraPlaneada()
        'CalcularAtraso()
        listaDatos()
        btnBuscarPersonaS.Focus()
        'ObtenerRegistro()
    End Sub


    Private Sub ObtenerHoraPlaneada()
        Try
            Dim registro As IndicadoresServicioService.Plantilla
            registro = oIndicadoresServicioService.MostrarPorIdPlantilla(CodMantenimiento, TipoMot, utils.toNumber(IdActividadDet))

            txtHoraPlaneada.Value = registro.Duracion
            txtNumPersonas.Value = registro.NumPer
            txtHoraPlaneadaTotal.Value = registro.DurTotal

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try

    End Sub

    'Private Sub ObtenerRegistro()
    'Try
    '    Dim registro As IndicadoresServicioService.ProgramacionPersona
    '    registro = oIndicadoresServicioService.MostrarProgramacionPersona()

    '    cmbAtraso.Value = registro.IdAtraso
    '    txtDesAtraso.Text = registro.DesAtraso
    '    cbEjecutado.Checked = registro.Ejecutado

    '    txtHoraReal.Text = registro.HorReal
    '    txtHoraPlaneada.Text = registro.HorPla
    '    txtHoraExtra.Text = registro.HorExt

    'Catch ex As Exception
    '    MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
    'End Try
    'End Sub

    Private Sub EnableOptions()
        Try
            If dgvDatos.RowCount > 0 Then
                miMostrar.Enabled = True
                biMostrar.Enabled = True
            Else
                miMostrar.Enabled = False
                biMostrar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES : " + ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If ValidaCampos() Then
                Dim registro As New IndicadoresServicioService.ProgramacionPersona
                Dim Persona As New IndicadoresServicioService.Persona
                Dim ProgramacionJobDet As New IndicadoresServicioService.ProgramacionJobDet
                Dim ProgramacionJob As New IndicadoresServicioService.ProgramacionJob

                Persona.IdPer = IdPer
                registro.Persona = Persona

                ProgramacionJob.IdProgramacion = IdProgramacion
                ProgramacionJobDet.ProgramacionJob = ProgramacionJob
                ProgramacionJobDet.IdProgramacionDet = IdProgramacionDet
                registro.ProgramacionJobDet = ProgramacionJobDet
                registro.FecReg = Today
                registro.FecFinReal = FecFinReal
                registro.HorReal = txtHoraReal.Value
                registro.HorPla = txtHoraPlaneada.Value
                registro.HorExt = txtHoraExtra.Value
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                Insertar(registro)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.ProgramacionPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.InsertarProgramacionPersona(registro)

            If estado_process Then
                MsgBox("Se ingresó la programación correctamente")
                listaDatos()
                LimpiarDatos()
                'btnBuscarPersonaS.Focus()
                'type_process = "update"
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub LimpiarDatos()

        txtHoraReal.Value = 0
        'txtHoraPlaneada.Value = 0
        txtHoraExtra.Value = 0
        IdPer = 0
        txtPersona.Text = ""

    End Sub


    Private Function ValidaCampos() As Boolean
        Try
            If utils.toNumber(IdPer) = 0 Then
                MsgBox("Debe ingresar el personal")
                btnBuscarPersonaS.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, dgvDatos.DoubleClick, miMostrar.Click
        If dgvDatos.RowCount > 0 Then
            Mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.MostrarProgramacionPersona(IdProgramacionDet, FecFinReal).Tables(0)
            dgvDatos.DataSource = dtDatos

            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub Mostrar()
        Try
            Dim frm As New frmProgramacionJob_ActPersona

            frm.FecFinReal = dgvDatos.CurrentRow.Cells("FecFinReal").Text
            frm.IdProgramacionDet = dgvDatos.CurrentRow.Cells("IdProgramacionDet").Text
            frm.IdProgramacion = IdProgramacion
            frm.IdPer = dgvDatos.CurrentRow.Cells("IdPer").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPer)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA PROGRAMACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Eliminar" Then
                'If MsgBox("¿Estas seguro de ELIMINAR la Programación Persona N° " & dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If MsgBox("¿Está seguro de ELIMINAR la programación persona?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oIndicadoresServicioService.BorrarProgramacionPersona(dgvDatos.CurrentRow.Cells("IdProgramacionDet").Value, FecFinReal, dgvDatos.CurrentRow.Cells("IdPer").Value)

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

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtHoraReal.KeyPress _
                          , txtHoraPlaneada.KeyPress
        ', txtObsDet.KeyPress _
        ', txtFecha.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub btnBuscarPersonaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            frm.codigoArea = "05"
            frm.cmbCodArea.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPer = frm.codigo
                    txtPersona.Text = frm.descripcion
                Else
                    IdPer = 0
                    txtPersona.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtHoraReal_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHoraReal.ValueChanged
        CalcularHoraAdic()
    End Sub

    Private Sub CalcularHoraAdic()
        If txtHoraReal.Value >= txtHoraPlaneada.Value Then
            txtHoraExtra.Value = txtHoraReal.Value - txtHoraPlaneada.Value
        Else
            txtHoraExtra.Value = 0
        End If
    End Sub


End Class