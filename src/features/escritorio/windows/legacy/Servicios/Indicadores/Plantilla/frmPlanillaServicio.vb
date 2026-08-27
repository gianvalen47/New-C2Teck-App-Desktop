Imports System.ServiceModel
Public Class frmPlanillaServicio

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 

    Public IdActividadDet As String
    Public CodMantenimiento As String
    Public DesMantenimiento As String

    Private dtCargos As DataTable

    'Public Predecesor As Integer

    Public TipoMot As String
    Public DesTipoMot As String

    Private dtDatos As DataTable


    Private Sub frmPlanillaServicio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            'oCotizacionServicioService.Close()
            oPersonaService.Close()
            'oTipoMotorService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            'oCotizacionServicioService.Abort()
            oPersonaService.Abort()
            'oTipoMotorService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            'oCotizacionServicioService.Abort()
            oPersonaService.Abort()
            'oTipoMotorService.Abort()
        End Try
    End Sub

    Private Sub frmPlanillaServicio_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMantenimiento.Text = DesMantenimiento
        lblTipoMotor.Text = TipoMot

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "Plantilla - Actividad: " + txtActividad.Text
            dgvDatos.Select()
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(700, 258)
            gbDetalle.Visible = False
            Me.Text = "Registrar nueva Plantilla"
            activar()
            btnBuscarPlantilla.Select()
        End If

    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodCar").Text
                End If
            End If
            dtDatos = Nothing
            ListarCargos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As IndicadoresServicioService.Plantilla
            registro = oIndicadoresServicioService.MostrarPorIdPlantilla(CodMantenimiento, TipoMot, utils.toNumber(IdActividadDet))

            txtActividad.Text = registro.ActividadServicioDet.DesActividad
            txtDuracion.Value = registro.Duracion
            txtPosicion.Value = registro.Posicion
            txtNumPer.Value = registro.NumPer
            txtDurTotal.Value = registro.DurTotal
            txtNumDias.Value = registro.NumDia
            txtTotalDias.Value = registro.TotalDias

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub activar()

        txtActividad.ReadOnly = True
        txtActividad.BackColor = System.Drawing.SystemColors.Control
        txtDuracion.ReadOnly = True
        txtDuracion.BackColor = System.Drawing.SystemColors.Control
        txtPosicion.ReadOnly = False
        txtPosicion.BackColor = System.Drawing.SystemColors.Window
        txtNumPer.ReadOnly = True
        txtNumPer.BackColor = System.Drawing.SystemColors.Control
        txtDurTotal.ReadOnly = True
        txtDurTotal.BackColor = System.Drawing.SystemColors.Control
        txtNumDias.ReadOnly = False
        txtNumDias.BackColor = System.Drawing.SystemColors.Window
        txtTotalDias.ReadOnly = False
        txtTotalDias.BackColor = System.Drawing.SystemColors.Window
        edicion = True
        enableOpciones()

    End Sub

    Private Sub desactivar()

        txtActividad.ReadOnly = True
        txtActividad.BackColor = System.Drawing.SystemColors.Control
        txtDuracion.ReadOnly = True
        txtDuracion.BackColor = System.Drawing.SystemColors.Control
        txtPosicion.ReadOnly = True
        txtPosicion.BackColor = System.Drawing.SystemColors.Control
        txtNumPer.ReadOnly = True
        txtNumPer.BackColor = System.Drawing.SystemColors.Control
        txtDurTotal.ReadOnly = True
        txtDurTotal.BackColor = System.Drawing.SystemColors.Control
        txtNumDias.ReadOnly = True
        txtNumDias.BackColor = System.Drawing.SystemColors.Control
        txtTotalDias.ReadOnly = True
        txtTotalDias.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()

    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrarCargo.Enabled = False
            miEliminarCargo.Enabled = False
        Else
            miMostrarCargo.Enabled = True
            miEliminarCargo.Enabled = True
        End If
        miNuevoCargo.Enabled = IIf(editable, True, False)
        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(editable, Not edicion, False)
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("CodCar").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnBuscarPlantilla_Click(sender As Object, e As EventArgs) Handles btnBuscarPlantilla.Click
        Dim frm1 As New frmPlantillaServicios_BuscarAct

        If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtActividad.Text = frm1.descripcion
            IdActividadDet = frm1.IdActividadDet
            txtDuracion.Focus()
        End If
    End Sub

    Private Sub ListarCargos()
        Try
            dtDatos = oIndicadoresServicioService.MostrarCargo(CodMantenimiento, TipoMot, utils.toNumber(IdActividadDet)).Tables(0)
            dgvDatos.DataSource = dtDatos

            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvDatos.RowCount > 0 Then
                miMostrarCargo.Enabled = True
            Else
                miMostrarCargo.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If ValidaCampos() Then

                Dim registro As New IndicadoresServicioService.Plantilla
                Dim Actividad As New IndicadoresServicioService.ActividadServicio
                Dim ActividadDet As New IndicadoresServicioService.ActividadServicioDet
                Dim TipoMantenimiento As New IndicadoresServicioService.TipoMantenimiento
                Dim TipoMotor As New IndicadoresServicioService.TipoMotor         '------ Agregado el 04/04/2013 (cambios en la plantilla project)

                ActividadDet.IdActividadDet = IdActividadDet
                ActividadDet.DesActividad = txtActividad.Text
                registro.ActividadServicioDet = ActividadDet
                TipoMantenimiento.CodMantenimiento = CodMantenimiento
                registro.TipoMantenimiento = TipoMantenimiento

                '----------- Agregado el 04/04/2013 (cambios en la plantilla project)----------
                TipoMotor.TipMot = TipoMot
                registro.TipoMotor = TipoMotor
                '------------------------------------------------------------------------------------------------------
                registro.Posicion = txtPosicion.Value

                registro.Duracion = txtDuracion.Value
                registro.NumPer = txtNumPer.Value
                registro.DurTotal = txtDurTotal.Value
                registro.NumDia = txtNumDias.Value
                registro.TotalDias = txtTotalDias.Value

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.Plantilla)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.InsertarPlantilla(registro)

            If estado_process Then
                'IdActividadDet = 'estado_process
                'type_process = "insert"
                MsgBox("Se ingresó la Actividad a la plantilla correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As IndicadoresServicioService.Plantilla)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarPlantilla(registro)
            If estado_process Then
                MsgBox("Se modificó la plantilla correctamente.")
                type_process = "update"
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Me.Close()
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el Proceso, Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtPosicion.Value = 1 Then
                txtPredecesor.Text = ""
                If utils.toBlank(txtActividad.Text) = "" Then
                    MsgBox("Debe ingresar la Actividad ")
                    txtActividad.Focus()
                    Return False
                ElseIf txtPosicion.Value = 0 Then
                    MsgBox("Debe ingresar la Posición")
                    txtPosicion.Focus()
                    Return False
                    'ElseIf utils.toBlank(txtDuracion.Value) = 0 Then
                    '    MsgBox("Debe ingresar la Duración")
                    '    txtDuracion.Focus()
                    '    Return False
                    'ElseIf utils.toBlank(txtNumPer.Value) = 0 Then
                    '    MsgBox("Debe ingresar el N° de Personas")
                    '    txtNumPer.Focus()
                    '    Return False
                    'ElseIf utils.toBlank(txtPredecesor.Text) = "" Then
                    '    MsgBox("Debe Ingresar el Predecesor")
                    '    txtPredecesor.Focus()
                    '    Return False
                    'ElseIf utils.toBlank(CadenaIdCargo) = "" Then
                    '    MsgBox("Debe ingresar los Cargos")
                    '    txtDesCargo.Focus()
                    '    Return False
                Else
                    Return True
                End If
            Else
                If utils.toBlank(txtActividad.Text) = "" Then
                    MsgBox("Debe ingresar la Actividad ")
                    txtActividad.Focus()
                    Return False
                ElseIf txtPosicion.Value = 0 Then
                    MsgBox("Debe ingresar la posición")
                    txtPosicion.Focus()
                    Return False
                    'ElseIf utils.toBlank(txtDuracion.Value) = 0 Then
                    '    MsgBox("Debe ingresar la duración")
                    '    txtDuracion.Focus()
                    '    Return False
                    'ElseIf utils.toBlank(txtNumPer.Value) = 0 Then
                    '    MsgBox("Debe ingresar el N° de Personas")
                    '    txtNumPer.Focus()
                    '    Return False
                    'ElseIf utils.toBlank(txtPredecesor.Text) = "" Then
                    '    MsgBox("Debe ingresar el predecesor")
                    '    txtPredecesor.Focus()
                    '    Return False
                    'ElseIf utils.toBlank(CadenaIdCargo) = "" Then
                    '    MsgBox("Debe ingresar los Cargos")
                    '    txtDesCargo.Focus()
                    '    Return False
                Else
                    Return True
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub txtDuracion_Click(sender As Object, e As EventArgs) Handles txtDuracion.Click
        txtDurTotal.Value = (txtDuracion.Value * txtNumPer.Value)
    End Sub

    Private Sub txtNumPer_Click(sender As Object, e As EventArgs) Handles txtNumPer.Click
        txtDurTotal.Value = (txtDuracion.Value * txtNumPer.Value)
    End Sub

    Private Sub biEditar_Click(sender As Object, e As EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(sender As Object, e As EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario...?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
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

    Private Sub miNuevoCargo_Click(sender As Object, e As EventArgs) Handles miNuevoCargo.Click

        Try
            Dim frm As New frmPlanillaServicio_Cargo
            frm.state_button = False

            frm.CodMantenimiento = CodMantenimiento
            frm.TipoMot = TipoMot
            frm.IdActividadDet = IdActividadDet

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarCargos()
                ObtenerRegistro()
                'If frm.type_process = "insert" Then
                '    RowPossesion(dgvDatos, frm.IdCargo)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miMostrarCargo_Click(sender As Object, e As EventArgs) Handles miMostrarCargo.Click, dgvDatos.DoubleClick

        Try
            Dim frm As New frmPlanillaServicio_Cargo

            frm.state_button = True

            frm.CodMantenimiento = CodMantenimiento
            frm.TipoMot = TipoMot
            frm.IdActividadDet = dgvDatos.CurrentRow.Cells("IdActividadDet").Text
            frm.IdCargo = dgvDatos.CurrentRow.Cells("IdCargo").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarCargos()
                ObtenerRegistro()
                'If frm.type_process = "insert" Then
                '    RowPossesion(dgvDatos, frm.IdCargo)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miEliminarCargo_Click(sender As Object, e As EventArgs) Handles miEliminarCargo.Click
        If ValidaCodigoSeleccionado() Then
            EliminarCargo()
        End If
    End Sub

    Private Sub EliminarCargo()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el cargo?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oIndicadoresServicioService.BorrarCargo(dgvDatos.CurrentRow.Cells("IdCargo").Value, CodMantenimiento, TipoMot, dgvDatos.CurrentRow.Cells("IdActividadDet").Value)
                If estado_process Then
                    'MsgBox("Se elimino correctamente el registro ")
                    ListarCargos()
                    ObtenerRegistro()
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                End If
                ListarCargos()
            End If

        Catch ex As Exception
            MsgBox("Error al Eliminar : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class