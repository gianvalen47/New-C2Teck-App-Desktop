Imports System.ServiceModel

Public Class frmPlantillaServicios_NuevoDetalle

    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    Private CadenaIdCargo As String = ""
    Private CadenaDesCargo As String = ""
    Public IdActividadDet As String
    Public CodMantenimiento As String
    Private dtCargo As DataTable
    Private dtPredecesor As DataTable
    Private dtCargos As DataTable
    Private ContarComasPrede As Integer
    Private ContarComasCargo As Integer
    Public Predecesor As Integer

    Public TipoMot As String           '------- Agregado el 04/04/2013 (cambios en la plantilla project)

    Private Sub frmPlantillaServicios_NuevoDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmPlantillaServicios_NuevoDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlantillaServicios_NuevoDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        ObtenerRegistro()
        btnBuscarPlantilla.Focus()

    End Sub

    Private Sub llenarCombos()

        '======================================= CARGO ================================================
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
            Dim registro As IndicadoresServicioService.Plantilla
            registro = oIndicadoresServicioService.MostrarPorIdPlantilla(CodMantenimiento, TipoMot, utils.toNumber(IdActividadDet))

            txtActividad.Text = registro.ActividadServicioDet.DesActividad
            txtDuracion.Value = registro.Duracion
            txtPosicion.Value = registro.Posicion
            txtNumPer.Value = registro.NumPer
            txtDurTotal.Value = registro.DurTotal

            ObtenerPredecesor()
            ObtenerCargos()

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerPredecesor()
        Try
            Dim CadenaPredecesor As String = ""

            dtPredecesor = oIndicadoresServicioService.MostrarPredecesor(CodMantenimiento, TipoMot, IdActividadDet).Tables(0)
            dgvPredecesor.DataSource = dtPredecesor

            For x = 0 To dtPredecesor.Rows.Count - 1
                If CadenaPredecesor = "" Then
                    If Predecesor = 1 Then
                        CadenaPredecesor = ""
                    Else
                        CadenaPredecesor = Trim(dgvPredecesor.Item("Predecesor".ToLower, x).Value)
                    End If
                Else
                    CadenaPredecesor = CadenaPredecesor + "," + CStr(dgvPredecesor.Item("Predecesor".ToLower, x).Value)
                End If
            Next

            txtPredecesor.Text = CadenaPredecesor

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER PREDECESOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerCargos()
        Try
            Dim cad1 As String = ""
            Dim cad2 As String = ""

            dtCargos = oIndicadoresServicioService.MostrarCargo(CodMantenimiento, TipoMot, IdActividadDet).Tables(0)
            dgvCargos.DataSource = dtCargos

            For x = 0 To dtCargos.Rows.Count - 1
                If CadenaIdCargo = "" Then
                    CadenaIdCargo = Trim(dgvCargos.Item("CodCar".ToLower, x).Value)
                Else
                    CadenaIdCargo = CadenaIdCargo + "," + Trim(dgvCargos.Item("CodCar".ToLower, x).Value)
                End If

                If CadenaDesCargo = "" Then
                    CadenaDesCargo = Trim(dgvCargos.Item("DesCar".ToLower, x).Value)
                Else
                    CadenaDesCargo = CadenaDesCargo + ";" + Trim(dgvCargos.Item("DesCar".ToLower, x).Value)
                End If
            Next
            txtDesCargo.Text = CadenaDesCargo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER CARGOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If ValidaCampos() Then

                Dim registro As New IndicadoresServicioService.Plantilla
                Dim Actividad As New IndicadoresServicioService.ActividadServicio
                Dim ActividadDet As New IndicadoresServicioService.ActividadServicioDet
                Dim TipoMantenimiento As New IndicadoresServicioService.TipoMantenimiento
                Dim TipoMotor As New IndicadoresServicioService.TipoMotor          '------ Agregado el 04/04/2013 (cambios en la plantilla project)

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

                Modificar(registro)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As IndicadoresServicioService.Plantilla)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.ActualizarPlantilla(registro)
            If estado_process Then
                MsgBox("Se modificó la plantilla correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Error en el Proceso, Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub InsertarPredecesor()
        Try
            If txtPredecesor.Text <> "" Then
                Dim estado_process As Boolean
                'Dim V() As String
                'Dim Cadena As String
                'ContarComasPrede = ContarCoinc(txtPredecesor.Text, ",")
                'Cadena = txtPredecesor.Text.Trim
                'V = Split(Cadena, ",")
                'For x = 0 To ContarComasPrede
                estado_process = oIndicadoresServicioService.InsertarPredecesor(CodMantenimiento, TipoMot, utils.toNumber(IdActividadDet), Trim(txtPredecesor.Text))

                If estado_process Then
                    'MsgBox("Se Ingreso Correctamente la Actividad a la Plantilla")
                Else
                    MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
                End If
                'Next
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL PREDECESOR" + ex.Message)
        End Try
    End Sub

    'Private Sub InsertarCargo()
    '    Try
    '        If CadenaIdCargo <> "" Then
    '            Dim estado_process As Boolean
    '            'Dim Z() As String
    '            'Dim Cadena As String
    '            'ContarComasCargo = ContarCoinc(CadenaIdCargo, ",")
    '            'Cadena = CadenaIdCargo
    '            'Z = Split(CadenaIdCargo, ",")
    '            'For x = 0 To ContarComasCargo
    '            estado_process = oIndicadoresServicioService.InsertarCargo(CodMantenimiento, TipoMot, utils.toNumber(IdActividadDet), CadenaIdCargo)

    '            If estado_process Then
    '                'MsgBox("Se Ingreso Correctamente la Actividad a la Plantilla")
    '            Else
    '                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
    '            End If
    '            'Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INSERTAR EL CARGO" + ex.Message)
    '    End Try
    'End Sub

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
                ElseIf utils.toBlank(txtDuracion.Value) = 0 Then
                    MsgBox("Debe ingresar la duración")
                    txtDuracion.Focus()
                    Return False
                ElseIf utils.toBlank(txtNumPer.Value) = 0 Then
                    MsgBox("Debe ingresar el N° de Personas")
                    txtNumPer.Focus()
                    Return False
                    'ElseIf utils.toBlank(txtPredecesor.Text) = "" Then
                    '    MsgBox("Debe Ingresar el Predecesor")
                    '    txtPredecesor.Focus()
                    '    Return False
                ElseIf utils.toBlank(CadenaIdCargo) = "" Then
                    MsgBox("Debe ingresar los Cargos")
                    txtDesCargo.Focus()
                    Return False
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
                ElseIf utils.toBlank(txtDuracion.Value) = 0 Then
                    MsgBox("Debe ingresar la duración")
                    txtDuracion.Focus()
                    Return False
                ElseIf utils.toBlank(txtNumPer.Value) = 0 Then
                    MsgBox("Debe ingresar el N° de personas")
                    txtNumPer.Focus()
                    Return False
                ElseIf utils.toBlank(txtPredecesor.Text) = "" Then
                    MsgBox("Debe ingresar el predecesor")
                    txtPredecesor.Focus()
                    Return False
                ElseIf utils.toBlank(CadenaIdCargo) = "" Then
                    MsgBox("Debe ingresar los cargos")
                    txtDesCargo.Focus()
                    Return False
                Else
                    Return True
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub txtDuracion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDuracion.ValueChanged
        txtDurTotal.Value = (txtDuracion.Value * txtNumPer.Value)
    End Sub

    Private Sub txtNumPer_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumPer.ValueChanged
        txtDurTotal.Value = (txtDuracion.Value * txtNumPer.Value)
    End Sub

    Function ContarCoinc(ByVal Origen As String, ByVal Buscar As String) As Long
        ContarCoinc = Len(Replace(Origen, Buscar, Buscar & "*")) - Len(Origen)
    End Function

    Private Sub btnPasarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasarCargo.Click
        If CadenaIdCargo = "" Then
            CadenaIdCargo = cmbCargo.Value
        Else
            CadenaIdCargo = CadenaIdCargo + "," + cmbCargo.Value
        End If

        If CadenaDesCargo = "" Then
            CadenaDesCargo = cmbCargo.Text.Trim
        Else
            CadenaDesCargo = CadenaDesCargo + ";" + cmbCargo.Text.Trim
        End If
        txtDesCargo.Text = CadenaDesCargo
    End Sub

    Private Sub btnLimpiarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCargo.Click
        CadenaIdCargo = ""
        CadenaDesCargo = ""
        txtDesCargo.Text = ""
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtActividad.KeyPress _
                          , txtPosicion.KeyPress _
                          , txtDuracion.KeyPress _
                          , txtNumPer.KeyPress _
                          , txtPredecesor.KeyPress _
                          , txtDesCargo.KeyPress
        ', txtObsDet.KeyPress _
        ', txtFecha.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class