Imports System.ServiceModel

Public Class frmPlantillaServicios

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oIndicadoresServicioService As New IndicadoresServicioService.IndicadoresServicioServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient           '------- Agregado el 04/04/2013 (cambios en la plantilla project)
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private CadenaIdCargo As String = ""
    Private CadenaDesCargo As String = ""
    Private dtTipoMantenimiento As DataTable
    Private dtCargo As DataTable
    Private IdCargos As String
    Private IdActividad As Integer
    Private IdActividadDet As Integer
    Private dtDatos As DataTable
    Private ContarComasPrede As Integer
    Private ContarComasCargo As Integer

    Private dtTiposMotores As DataTable          '------- Agregado el 04/04/2013 (cambios en la plantilla project)

    Private Sub frmPlantillaServicios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oIndicadoresServicioService.Close()
            oCotizacionServicioService.Close()
            oPersonaService.Close()
            oTipoMotorService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oIndicadoresServicioService.Abort()
            oCotizacionServicioService.Abort()
            oPersonaService.Abort()
            oTipoMotorService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oIndicadoresServicioService.Abort()
            oCotizacionServicioService.Abort()
            oPersonaService.Abort()
            oTipoMotorService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmPlantillaServicios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlantillaServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 184)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        cmbMantenimiento.Value = "104"
        cmbTipMot.Value = "16V4000"
        listaDatos()
        'ObtenerPosicion()

    End Sub

    'Private Sub ObtenerPosicion()
    '    If dgvDatos.RowCount > 0 Then
    '        txtPosicion.Value = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Posicion").Text) + 1
    '    Else
    '        txtPosicion.Value = 1
    '    End If
    'End Sub

    Private Sub llenarCombos()
        Try

            '======================================= TIPO MANTENIMIENTO ================================================
            dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            'dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            'cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            ''======================================= CARGO ================================================
            'dtCargo = oPersonaService.MostrarCargos("05").Tables(0)
            'cmbCargo.DataSource = dtCargo
            'cmbCargo.DropDownList.DataMember = dtCargo.Columns("DesCargo").ToString
            'cmbCargo.DropDownList.DisplayMember = dtCargo.Columns("DesCargo").ToString
            'cmbCargo.DropDownList.ValueMember = dtCargo.Columns("CodCargo").ToString
            'cmbCargo.DropDownList.Columns(0).DataMember = dtCargo.Columns("CodCargo").ToString
            'cmbCargo.DropDownList.Columns(1).DataMember = dtCargo.Columns("DesCargo").ToString
            ''cmbMantenimiento.SelectedIndex = 0
            'dtCargo = Nothing

            '======================================= TIPOS DE MOTORES =========================================
            dtTiposMotores = oTipoMotorService.Mostrar.Tables(0)
            'dtTiposMotores.Rows.InsertAt(getRowMotores(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            dtTiposMotores = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try      
    End Sub

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
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oIndicadoresServicioService.MostrarPlantilla(cmbMantenimiento.Value, cmbTipMot.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

            EnableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdActividadDet").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub Mostrar()
        Try
            'Dim frm As New frmPlantillaServicios_NuevoDetalle
            Dim frm As New frmPlanillaServicio

            frm.state_button = True
            frm.editable = True '-- se descomento 10/05/2012 se valido que solo en estado GN se pueda Editar los datos            
            frm.edicion = False


            frm.CodMantenimiento = dgvDatos.CurrentRow.Cells("CodMantenimiento").Text
            frm.DesMantenimiento = cmbMantenimiento.Text
            frm.TipoMot = dgvDatos.CurrentRow.Cells("TipMot").Value              '------ Agregado el 04/04/2013 (cambios en la plantilla project)

            frm.IdActividadDet = dgvDatos.CurrentRow.Cells("IdActividadDet").Text
            'If dgvDatos.CurrentRow.Cells("Posicion").Text = 1 Then
            '    frm.Predecesor = 1
            'End If

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdActividadDet)
            Else
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdActividadDet)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub btnBuscarPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm1 As New frmPlantillaServicios_BuscarAct

    '    If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        txtActividad.Text = frm1.descripcion
    '        IdActividadDet = frm1.IdActividadDet
    '        txtDuracion.Focus()
    '    End If
    'End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click, cmbMantenimiento.ValueChanged, cmbTipMot.ValueChanged
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdActividadDet").Value
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        'ObtenerPosicion()
    End Sub

    'Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If ValidaCampos() Then

    '            Dim registro As New IndicadoresServicioService.Plantilla
    '            Dim Actividad As New IndicadoresServicioService.ActividadServicio
    '            Dim ActividadDet As New IndicadoresServicioService.ActividadServicioDet
    '            Dim TipoMantenimiento As New IndicadoresServicioService.TipoMantenimiento
    '            Dim TipoMotor As New IndicadoresServicioService.TipoMotor         '------ Agregado el 04/04/2013 (cambios en la plantilla project)

    '            ActividadDet.IdActividadDet = IdActividadDet
    '            ActividadDet.DesActividad = txtActividad.Text
    '            registro.ActividadServicioDet = ActividadDet
    '            TipoMantenimiento.CodMantenimiento = cmbMantenimiento.Value
    '            registro.TipoMantenimiento = TipoMantenimiento

    '            '----------- Agregado el 04/04/2013 (cambios en la plantilla project)----------
    '            TipoMotor.TipMot = cmbTipMot.Value
    '            registro.TipoMotor = TipoMotor
    '            '------------------------------------------------------------------------------------------------------

    '            If dgvDatos.RowCount > 0 Then
    '                registro.Posicion = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Posicion").Text) + 1
    '            Else
    '                registro.Posicion = 1
    '            End If
    '            registro.Duracion = txtDuracion.Value
    '            registro.NumPer = txtNumPer.Value
    '            registro.DurTotal = txtDurTotal.Value
    '            Insertar(registro)
    '        End If

    '    Catch ex As Exception
    '        MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
    '    End Try
    'End Sub

    Private Sub Insertar(ByVal registro As IndicadoresServicioService.Plantilla)
        Try
            Dim estado_process As Boolean
            estado_process = oIndicadoresServicioService.InsertarPlantilla(registro)

            If estado_process Then
                'If dgvDatos.RowCount <> 0 Then
                '    InsertarPredecesor()
                'End If
                'InsertarCargo()
                'listaDatos()
                'limpiarDatos()
                'btnBuscarPlantilla.Focus()
                MsgBox("Se ingresó la Actividad a la plantilla correctamente ")
            Else
                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    'Private Sub InsertarPredecesor()
    '    Try
    '        If txtPredecesor.Text <> "" Then
    '            Dim estado_process As Boolean
    '            'Dim V() As String
    '            'Dim Cadena As String
    '            'ContarComasPrede = ContarCoinc(txtPredecesor.Text, ",")

    '            'Cadena = txtPredecesor.Text.Trim
    '            'V = Split(Cadena, ",")
    '            'For x = 0 To ContarComasPrede
    '            estado_process = oIndicadoresServicioService.InsertarPredecesor(cmbMantenimiento.Value, cmbTipMot.Value, utils.toNumber(IdActividadDet), Trim(txtPredecesor.Text))

    '            If estado_process Then
    '                'MsgBox("Se Ingreso Correctamente la Actividad a la Plantilla")
    '            Else
    '                MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
    '            End If
    '            'Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INSERTAR EL PREDECESOR: " + ex.Message)
    '    End Try

    'End Sub

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
    '            estado_process = oIndicadoresServicioService.InsertarCargo(cmbMantenimiento.Value, cmbTipMot.Value, utils.toNumber(IdActividadDet), CadenaIdCargo)

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

    'Private Sub limpiarDatos()
    '    txtActividad.Text = ""
    '    txtDuracion.Value = 0
    '    ObtenerPosicion()
    '    txtNumPer.Value = 0
    '    txtDurTotal.Value = 0
    '    cmbCargo.SelectedIndex = 0
    '    txtPredecesor.Text = ""
    '    txtDesCargo.Text = ""
    '    CadenaIdCargo = ""
    '    CadenaDesCargo = ""
    'End Sub

    'Private Function ValidaCampos() As Boolean
    '    Try
    '        If txtPosicion.Value = 1 Then
    '            txtPredecesor.Text = ""
    '            If utils.toBlank(txtActividad.Text) = "" Then
    '                MsgBox("Debe ingresar la Actividad ")
    '                txtActividad.Focus()
    '                Return False
    '            ElseIf txtPosicion.Value = 0 Then
    '                MsgBox("Debe ingresar la Posición")
    '                txtPosicion.Focus()
    '                Return False
    '            ElseIf utils.toBlank(txtDuracion.Value) = 0 Then
    '                MsgBox("Debe ingresar la Duración")
    '                txtDuracion.Focus()
    '                Return False
    '            ElseIf utils.toBlank(txtNumPer.Value) = 0 Then
    '                MsgBox("Debe ingresar el N° de Personas")
    '                txtNumPer.Focus()
    '                Return False
    '                'ElseIf utils.toBlank(txtPredecesor.Text) = "" Then
    '                '    MsgBox("Debe Ingresar el Predecesor")
    '                '    txtPredecesor.Focus()
    '                '    Return False
    '            ElseIf utils.toBlank(CadenaIdCargo) = "" Then
    '                MsgBox("Debe ingresar los Cargos")
    '                txtDesCargo.Focus()
    '                Return False
    '            Else
    '                Return True
    '            End If
    '        Else
    '            If utils.toBlank(txtActividad.Text) = "" Then
    '                MsgBox("Debe ingresar la Actividad ")
    '                txtActividad.Focus()
    '                Return False
    '            ElseIf txtPosicion.Value = 0 Then
    '                MsgBox("Debe ingresar la posición")
    '                txtPosicion.Focus()
    '                Return False
    '            ElseIf utils.toBlank(txtDuracion.Value) = 0 Then
    '                MsgBox("Debe ingresar la duración")
    '                txtDuracion.Focus()
    '                Return False
    '            ElseIf utils.toBlank(txtNumPer.Value) = 0 Then
    '                MsgBox("Debe ingresar el N° de Personas")
    '                txtNumPer.Focus()
    '                Return False
    '            ElseIf utils.toBlank(txtPredecesor.Text) = "" Then
    '                MsgBox("Debe ingresar el predecesor")
    '                txtPredecesor.Focus()
    '                Return False
    '            ElseIf utils.toBlank(CadenaIdCargo) = "" Then
    '                MsgBox("Debe ingresar los Cargos")
    '                txtDesCargo.Focus()
    '                Return False
    '            Else
    '                Return True
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
    '    End Try
    'End Function

    'Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick

    'End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, biMostrar.Click, miMostrar.Click
        If dgvDatos.RowCount > 0 Then
            Mostrar()
        End If
    End Sub

    'Private Sub txtDuracion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtDurTotal.Value = (txtDuracion.Value * txtNumPer.Value)
    'End Sub

    'Private Sub txtNumPer_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtDurTotal.Value = (txtDuracion.Value * txtNumPer.Value)
    'End Sub

    Function ContarCoinc(ByVal Origen As String, ByVal Buscar As String) As Long
        ContarCoinc = Len(Replace(Origen, Buscar, Buscar & "*")) - Len(Origen)
    End Function

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Dim ContarComas As Integer
    '    'ContarComas = ContarCoinc(txtPredecesor.Text, ",")
    '    Try
    '        Dim estado_process As String
    '        Dim V() As String
    '        Dim Cadena As String

    '        Cadena = txtPredecesor.Text.Trim
    '        V = Split(Cadena, ",")

    '        For x = 0 To 2
    '            estado_process = V(x)

    '            'If estado_process Then
    '            '    MsgBox("Se Ingreso Correctamente la Actividad a la Plantilla")
    '            '    InsertarCargo()
    '            '    'listaDatos()
    '            '    'limpiarDatos()
    '            '    'btnBuscarPlantilla.Focus()
    '            'Else
    '            '    MsgBox("Error en el Proceso , Comunicarse con el Administrador del Sistema")
    '            'End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INSERTAR EL PREDECESOR" + ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnPasarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If CadenaIdCargo = "" Then
    '        CadenaIdCargo = cmbCargo.Value
    '    Else
    '        CadenaIdCargo = CadenaIdCargo + "," + cmbCargo.Value
    '    End If

    '    If CadenaDesCargo = "" Then
    '        CadenaDesCargo = cmbCargo.Text.Trim
    '    Else
    '        CadenaDesCargo = CadenaDesCargo + ";" + cmbCargo.Text.Trim
    '    End If

    '    txtDesCargo.Text = CadenaDesCargo

    '    cmbCargo.Focus()
    'End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub btnLimpiarCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CadenaIdCargo = ""
    '    CadenaDesCargo = ""
    '    txtDesCargo.Text = ""
    'End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Eliminar()
        End If
    End Sub

    Private Sub Eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR la Sub Actividad de la Plantilla?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oIndicadoresServicioService.BorrarPlantilla(cmbMantenimiento.Value, cmbTipMot.Value, dgvDatos.CurrentRow.Cells("IdActividadDet").Value, dgvDatos.CurrentRow.Cells("Posicion").Value)
                If estado_process Then
                    MsgBox("Se elimino correctamente el registro ")
                    listaDatos()
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                End If
                listaDatos()
            End If

        Catch ex As Exception
            MsgBox("Error al Eliminar : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                Mostrar()
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ', txtObsDet.KeyPress _
        ', txtFecha.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click

        Try
            Dim frm As New frmPlanillaServicio

            frm.state_button = False
            frm.edicion = True
            frm.editable = True

            frm.CodMantenimiento = cmbMantenimiento.Value
            frm.DesMantenimiento = cmbMantenimiento.Text
            frm.TipoMot = cmbTipMot.Value              '------ Agregado el 04/04/2013 (cambios en la plantilla project)

            frm.IdActividadDet = 0
            'If dgvDatos.CurrentRow.Cells("Posicion").Text = 1 Then
            '    frm.Predecesor = 1
            'End If

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                'If frm.type_process = "insert" Then
                '    RowPossesion(dgvDatos, frm.IdActividadDet)
                '    Mostrar()
                'End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA ACTIVIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub



End Class