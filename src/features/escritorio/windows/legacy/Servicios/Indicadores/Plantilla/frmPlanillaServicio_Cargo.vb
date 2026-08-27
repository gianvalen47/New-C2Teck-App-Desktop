Imports System.ServiceModel

Public Class frmPlanillaServicio_Cargo

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo

    Public IdActividadDet As String
    Public CodMantenimiento As String
    Public DesMantenimiento As String

    Private dtCargo As DataTable
    Public IdCargo As Integer

    'Public Predecesor As Integer

    Public TipoMot As String
    Public DesTipoMot As String

    Private dtDatos As DataTable

    Private Sub frmPlanillaServicio_Cargo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmPlanillaServicio_Cargo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaServicio_Cargo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
        Else                          'Nuevo
            activar()
        End If

    End Sub

    Private Sub llenarCombos()

        ''======================================= CARGO ================================================
        dtCargo = oPersonaService.MostrarCargos(Session.sCodEmp, "05").Tables(0)
        cmbCargo.DataSource = dtCargo
        cmbCargo.DropDownList.DataMember = dtCargo.Columns("DesCargo").ToString
        cmbCargo.DropDownList.DisplayMember = dtCargo.Columns("DesCargo").ToString
        cmbCargo.DropDownList.ValueMember = dtCargo.Columns("CodCargo").ToString
        cmbCargo.DropDownList.Columns(0).DataMember = dtCargo.Columns("CodCargo").ToString
        cmbCargo.DropDownList.Columns(1).DataMember = dtCargo.Columns("DesCargo").ToString
        'cmbMantenimiento.SelectedIndex = 0
        dtCargo = Nothing


    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As IndicadoresServicioService.CargosPlantilla
            registro = oIndicadoresServicioService.ObtenerCargo(IdCargo)

            cmbCargo.Value = registro.CargoColaborador.CodCar
            txtCanHoras.Value = registro.CanHoras

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try


    End Sub

    Private Sub desactivar()

        cmbCargo.ReadOnly = True
        cmbCargo.BackColor = System.Drawing.SystemColors.Control
        txtCanHoras.ReadOnly = False
        txtCanHoras.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub activar()

        cmbCargo.ReadOnly = False
        cmbCargo.BackColor = System.Drawing.SystemColors.Window
        txtCanHoras.ReadOnly = False
        txtCanHoras.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.Close()
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If ValidaCampos() Then

                Dim registro As New IndicadoresServicioService.CargosPlantilla
                Dim Plantilla As New IndicadoresServicioService.Plantilla
                Dim Actividad As New IndicadoresServicioService.ActividadServicio
                Dim ActividadDet As New IndicadoresServicioService.ActividadServicioDet
                Dim TipoMantenimiento As New IndicadoresServicioService.TipoMantenimiento
                Dim TipoMotor As New IndicadoresServicioService.TipoMotor         '------ Agregado el 04/04/2013 (cambios en la plantilla project)
                Dim CargoColaborador As New IndicadoresServicioService.CargoColaborador

                ActividadDet.IdActividadDet = IdActividadDet
                Plantilla.ActividadServicioDet = ActividadDet
                TipoMantenimiento.CodMantenimiento = CodMantenimiento
                Plantilla.TipoMantenimiento = TipoMantenimiento

                '----------- Agregado el 04/04/2013 (cambios en la plantilla project)----------
                TipoMotor.TipMot = TipoMot
                Plantilla.TipoMotor = TipoMotor
                '------------------------------------------------------------------------------------------------------
                registro.Plantilla = Plantilla
                registro.IdCargo = IdCargo
                CargoColaborador.ClasCar = ""
                CargoColaborador.CodCar = cmbCargo.Value
                CargoColaborador.DesCar = cmbCargo.Text
                registro.CargoColaborador = CargoColaborador
                registro.CanHoras = txtCanHoras.Value

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

    Private Function ValidaCampos() As Boolean
        Try

            If txtCanHoras.Value = 0 Then
                MsgBox("Debe ingresar la Cantidad de Horas")
                txtCanHoras.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.CargosPlantilla)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.InsertarCargo(registro)

            If estado_process Then
                'IdActividadDet = estado_process
                'type_process = "insert"
                'MsgBox("Se ingresó la Actividad a la plantilla correctamente ")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As IndicadoresServicioService.CargosPlantilla)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarCargo(registro)
            If estado_process Then
                'MsgBox("Se modificó la plantilla correctamente.")
                'type_process = "update"
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Me.Close()
            Else
                MsgBox("Error en el Proceso, Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

End Class