Imports System.ServiceModel
Public Class frmReciboHonorario_Detalle

    '===========================Servicios====================================
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oReciboHonorarioService As New ReciboHonorarioService.ReciboHonorarioServiceClient
    Private oReciboHonorarioDetService As New ReciboHonorarioDetService.ReciboHonorarioDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    'Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================   
    Public IdHonorarioDet As Integer
    Public IdHonorario As Integer
    'Public Masivo As Boolean
    Public AfectoIR As Boolean
    Public CodMon As String
    Public TipoCambio As Double

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    'Private IdCuenta

    Private dtDatos As DataTable
    Public IR As Double
    Private idcuen As String

    Private Calcular As Boolean = True

    Private Sub frmReciboHonorario_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        lblDesCuenta.Text = ""
        ObtenerIR()

        If state_button Then                'Modificar
            Calcular = False
            ObtenerRegistro()
            Calcular = True

            desactivar()
            gbCentroCosto.Visible = True
            actualizarDetalles()
            Me.Text = "Recibo por Honorario Detalle"
            dgvDatos.Select()

        Else                                      'Nuevo
            Me.Size = New System.Drawing.Size(604, 298)
            gbCentroCosto.Visible = False
            Me.Text = "Registrar nuevo Recibo por Honorario Detalle"
            activar()

            'ObtenerAreaCentroCosto()

        End If

    End Sub

    Private Sub ObtenerIR()

        Try

            'IR = oReciboHonorarioService.ObtenerIR(Session.sCodEmp)

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmReciboHonorario_Detalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oCuentaContableService.Close()
            oReciboHonorarioService.Close()
            oReciboHonorarioDetService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oCuentaContableService.Abort()
            oReciboHonorarioService.Abort()
            oReciboHonorarioDetService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oCuentaContableService.Abort()
            oReciboHonorarioService.Abort()
            oReciboHonorarioDetService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmReciboHonorario_Detalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub desactivar()

        txtCodCuenta.ReadOnly = True
        txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
        btnBuscarNroCuenta.Enabled = False

        txtMontoSol.ReadOnly = True
        txtMontoSol.BackColor = System.Drawing.SystemColors.Control
        txtMontoIRSol.ReadOnly = True
        txtMontoIRSol.BackColor = System.Drawing.SystemColors.Control

        txtMontoDol.ReadOnly = True
        txtMontoDol.BackColor = System.Drawing.SystemColors.Control
        txtMontoIRDol.ReadOnly = True
        txtMontoIRDol.BackColor = System.Drawing.SystemColors.Control

        txtObservación.ReadOnly = True
        txtObservación.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
        biAsignar.Focus()

    End Sub

    Private Sub activar()

        If state_button Then    '////////////////////////////////////////////////// ACTUALIZAR ////////////////////////////////////////////////////////////

            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            btnBuscarNroCuenta.Enabled = True

            txtMontoSol.ReadOnly = False
            txtMontoSol.BackColor = System.Drawing.SystemColors.Window
            txtMontoIRSol.ReadOnly = False
            txtMontoIRSol.BackColor = System.Drawing.SystemColors.Window

            txtMontoDol.ReadOnly = False
            txtMontoDol.BackColor = System.Drawing.SystemColors.Window
            txtMontoIRDol.ReadOnly = False
            txtMontoIRDol.BackColor = System.Drawing.SystemColors.Window

            txtObservación.ReadOnly = False
            txtObservación.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtCodCuenta.Focus()

        Else
            txtCodCuenta.ReadOnly = False
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
            btnBuscarNroCuenta.Enabled = True

            txtMontoSol.ReadOnly = False
            txtMontoSol.BackColor = System.Drawing.SystemColors.Window
            txtMontoIRSol.ReadOnly = False
            txtMontoIRSol.BackColor = System.Drawing.SystemColors.Window

            txtMontoDol.ReadOnly = False
            txtMontoDol.BackColor = System.Drawing.SystemColors.Window
            txtMontoIRDol.ReadOnly = False
            txtMontoIRDol.BackColor = System.Drawing.SystemColors.Window

            txtObservación.ReadOnly = False
            txtObservación.BackColor = System.Drawing.SystemColors.Window

            edicion = True
            enableOpciones()
            txtCodCuenta.Focus()

        End If

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ReciboHonorarioDetService.ReciboHonorarioDet
            registro = oReciboHonorarioDetService.Obtener(toNumber(IdHonorarioDet))

            IdHonorarioDet = registro.IdHonorarioDet
            IdHonorario = registro.ReciboHonorario.IdHonorario

            idcuen = registro.CuentaContable.IdCuenta
            txtCodCuenta.Text = registro.CuentaContable.CodCuenta
            lblDesCuenta.Text = registro.CuentaContable.Descripcion
            txtObservación.Text = registro.Observacion

            txtMontoSol.Text = registro.MontoSol
            txtMontoIRSol.Text = registro.MontoIRSol
            txtMontoNetoSol.Text = registro.TotalFilaSol

            txtMontoDol.Text = registro.MontoDol
            txtMontoIRDol.Text = registro.MontoIRDol
            txtMontoNetoDol.Text = registro.TotalFilaDol


            '---------------------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    'Private Sub ActualizarDetallesCentroCosto()

    '    Try
    '        Dim codigo As String = ""
    '        If dgvDatos.RowCount > 0 Then
    '            If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
    '                codigo = dgvDatos.CurrentRow.Cells("CodCentro").Text
    '            End If
    '        End If
    '        dtCentrosCosto = Nothing
    '        listaDatosCentroCosto()
    '        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
    '            RowPossesionCentroCosto(dgvDatos, codigo)
    '        End If
    '        enableOpciones()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL ACTUALIZAR DETALLES CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

    'Private Sub listaDatosCentroCosto()
    '    Try
    '        dtCentrosCosto = oReciboHonorarioDetService.MostrarCentroCosto(IdHonorarioDet).Tables(0)
    '        dgvDatos.DataSource = dtCentrosCosto
    '        enableOpciones()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LISTAR DATOS CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("CodCentro").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oReciboHonorarioDetService.MostrarCentroCosto(IdHonorarioDet).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodCentro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] CENTRO COSTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Private Sub enableOpciones()
    '    If dgvDatos.RowCount < 1 Then
    '        miAsignar.Enabled = False
    '    Else
    '        miAsignar.Enabled = True
    '    End If

    '    miAsignar.Enabled = True 'IIf(Not edicion And editable, True, False) 'Se agrega el perfiles Solicitud de Usuario 65887,65888

    '    biEditar.Enabled = IIf(editable, Not edicion, False)
    '    biCerrar.Enabled = Not edicion
    '    biGuardar.Enabled = edicion
    '    biDeshacer.Enabled = edicion
    '    'cmOpcionesCentrosCosto.Enabled = IIf(Not edicion, True, False)

    'End Sub

    Private Sub enableOpciones()
        miAsignar.Enabled = IIf(editable, True, False)
        'miAsignar.Enabled = IIf(editable And iSolicitud = False, True, False)'(Se comenta para que el Sr. Jesus pueda realizar cambios)
        biAsignar.Enabled = IIf(editable, True, False)
        'biAsignar.Enabled = IIf(editable, True And iSolicitud = False, False)'(Se comenta para que el Sr. Jesus pueda realizar cambios)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub


    Private Sub btnBuscarNroCuenta_Click(sender As Object, e As EventArgs) Handles btnBuscarNroCuenta.Click
        Dim frm As New frmBuscarCuentaContable
        'frm.txtCodCuenta.Text = "10"
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                idcuen = frm.id
                txtCodCuenta.Text = frm.codigo
                lblDesCuenta.Text = frm.descripcion
                'idcuenta = frm.id
                'txtCodCuenta.Text = frm.codigo
                If CodMon = "NS" Then
                    txtMontoSol.Focus()
                ElseIf CodMon = "US"
                    txtMontoDol.Focus()
                End If
            Else
                'txtCodCuentaDest.Text = ""
                'lblDesCuentaDest.Text = ""
                txtCodCuenta.Text = ""
                lblDesCuenta.Text = ""
            End If
        End If
    End Sub


    Private Sub txtCodCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarNroCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarNroCuenta_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuenta.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                    txtCodCuenta.Focus()
                Else

                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                    idcuen = IdCuenta
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuenta.Text = registro.NomCuenta
                    If CodMon = "NS" Then
                        txtMontoSol.Focus()
                    ElseIf CodMon = "US"
                        txtMontoDol.Focus()
                    End If

                End If
            Else
                If CodMon = "NS" Then
                    txtMontoSol.Focus()
                ElseIf CodMon = "US" Then
                    txtMontoDol.Focus()
                End If
                'txtObservación.Focus()
            End If
        End If
    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New ReciboHonorarioDetService.ReciboHonorarioDet
                    Dim recibohonorario As New ReciboHonorarioDetService.ReciboHonorario
                    '-----------------------------------------------------------------------------------------------------
                    Dim cuentacontable As New ReciboHonorarioDetService.CuentaContable         '--- Se agregó el 09/07/2014 Importaciones (Sra. Mori)


                    registro.IdHonorarioDet = IdHonorarioDet
                    recibohonorario.IdHonorario = IdHonorario
                    registro.ReciboHonorario = recibohonorario
                    registro.Observacion = txtObservación.Text

                    registro.MontoSol = txtMontoSol.Value
                    registro.MontoIRSol = txtMontoIRSol.Value
                    registro.TotalFilaSol = txtMontoNetoSol.Value

                    registro.MontoDol = txtMontoDol.Value
                    registro.MontoIRDol = txtMontoIRDol.Value
                    registro.TotalFilaDol = txtMontoNetoDol.Value

                    cuentacontable.IdCuenta = idcuen
                    cuentacontable.CodCuenta = txtCodCuenta.Text
                    registro.CuentaContable = cuentacontable

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp



                    If state_button Then        'Modificar
                        Modificar(registro)
                    Else                        'Nuevo
                        Insertar(registro)
                    End If


                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ReciboHonorarioDetService.ReciboHonorarioDet)
        Try
            Dim estado_process As Integer
            estado_process = oReciboHonorarioDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdHonorarioDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ReciboHonorarioDetService.ReciboHonorarioDet)
        Try
            Dim estado_process As Boolean
            estado_process = oReciboHonorarioDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtCodCuenta.Text = "" Then
                MsgBox("Debe Ingresar la cuenta contable. ", MsgBoxStyle.Information, "Información")
                txtObservación.Focus()
                Return False
                'ElseIf txtObservación.Text = "" Then
                '    MsgBox("Debe Ingresar la Observacion. ", MsgBoxStyle.Information, "Información")
                '    txtObservación.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditar_Click(sender As Object, e As EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(sender As Object, e As EventArgs) Handles biDeshacer.Click
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

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        If ValidarMontos() = False Then
            MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
            biAsignar.Focus()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
            dgvDatos.Focus()
        End If
    End Sub

    Private Function ValidarMontos() As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                'Dim MontoSoles As Double = 0.0
                'Dim MontoIgvSol As Double = 0.0
                'Dim MontoNoAfectoSol As Double = 0.0
                'Dim TotalSoles As Double = 0.0

                'Dim MontoDolares As Double = 0.0
                'Dim MontoIgvDol As Double = 0.0
                'Dim MontoNoAfectoDol As Double = 0.0
                'Dim TotalDolares As Double = 0.0

                'Dim row As Janus.Windows.GridEX.GridEXRow
                'For i = 0 To Me.dgvDatos.RowCount - 1
                '    Me.dgvDatos.Row = i
                '    row = Me.dgvDatos.GetRow()
                '    MontoSoles = MontoSoles + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoSol").Value)
                '    MontoIgvSol = MontoIgvSol + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoIgvSol").Value)
                '    MontoNoAfectoSol = MontoNoAfectoSol + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoNoAfectoSol").Value)

                '    MontoDolares = MontoDolares + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoDol").Value)
                '    MontoIgvDol = MontoIgvDol + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoIgvDol").Value)
                '    MontoNoAfectoDol = MontoNoAfectoDol + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoNoAfectoDol").Value)
                'Next

                'If (txtMontoSol.Value = Math.Round(MontoSoles, 2) And txtMontoDol.Value = Math.Round(MontoDolares, 2)) _
                'And (txtMontoIgvSol.Value = Math.Round(MontoIgvSol, 2) And txtMontoIgvDol.Value = Math.Round(MontoIgvDol, 2)) _
                'And (txtMontoNoAfectoSol.Value = Math.Round(MontoNoAfectoSol, 2) And txtMontoNoAfectoDol.Value = Math.Round(MontoNoAfectoDol, 2)) _
                'And (txtTotalFilaSol.Value = Math.Round((MontoSoles + MontoIgvSol + MontoNoAfectoSol), 2) And txtTotalFilaDol.Value = Math.Round((MontoDolares + MontoIgvDol + MontoNoAfectoDol), 2)) Then
                Return True
                'Else
                '    Return False
                'End If

            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error al sumar Montos" + ex.Message)
        End Try
    End Function

    Private Sub txtMontoSol_Click(sender As Object, e As EventArgs) Handles txtMontoSol.ValueChanged

        If Calcular = True Then

            If CodMon = "NS" Then
                If AfectoIR = True Then
                    txtMontoIRSol.Value = Math.Round(txtMontoSol.Value * (IR / 100), 2)
                    'Else
                    '    txtMontoIRSol.Value = 0
                End If
                txtMontoDol.Value = Math.Round((txtMontoSol.Value / TipoCambio), 2)
            End If
            'txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            txtMontoNetoSol.Value = txtMontoSol.Value - txtMontoIRSol.Value

        End If

    End Sub

    Private Sub txtMontoIRSol_Click(sender As Object, e As EventArgs) Handles txtMontoIRSol.ValueChanged
        If Calcular = True Then
            If CodMon = "NS" Then
                txtMontoIRDol.Value = Math.Round((txtMontoIRSol.Value / TipoCambio), 2)
                'ElseIf CodMon = "US" Then
                '    txtMontoIgvSol.Value = Math.Round((txtMontoIgvDol.Value * TipoCambio), 2)
            End If
            txtMontoNetoSol.Value = txtMontoSol.Value - txtMontoIRSol.Value
            'txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
    End Sub

    Private Sub txtMontoDol_Click(sender As Object, e As EventArgs) Handles txtMontoDol.ValueChanged

        If Calcular = True Then

            If CodMon = "US" Then
                If AfectoIR = True Then
                    txtMontoIRDol.Value = Math.Round(txtMontoDol.Value * (IR / 100), 2)
                    'Else
                    '    txtMontoIRDol.Value = 0
                End If
                txtMontoSol.Value = Math.Round((txtMontoDol.Value * TipoCambio), 2)
            End If
            'txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            txtMontoNetoDol.Value = txtMontoDol.Value - txtMontoIRDol.Value
        End If

    End Sub

    Private Sub txtMontoIRDol_Click(sender As Object, e As EventArgs) Handles txtMontoIRDol.ValueChanged
        If Calcular = True Then
            'If CodMon = "NS" Then
            '    txtMontoIgvDol.Value = Math.Round((txtMontoIgvSol.Value / TipoCambio), 2)
            If CodMon = "US" Then
                txtMontoIRSol.Value = Math.Round((txtMontoIRDol.Value * TipoCambio), 2)
            End If
            'txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            txtMontoNetoDol.Value = txtMontoDol.Value - txtMontoIRDol.Value
        End If

        'CalcularMontosDol()
    End Sub

    'Private Sub CalcularMontosDol()

    '    Dim montoIR As Double = 0
    '    montoIR = IIf(AfectoIR = True, Math.Round(txtMontoDol.Value * (IR / 100), 2), 0)

    '    txtMontoIRDol.Value = montoIR
    '    txtMontoNetoDol.Value = txtMontoDol.Value - montoIR


    'End Sub

    Private Sub miAsignarCentroCosto_Click(sender As Object, e As EventArgs)
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miActualizarCentroCosto_Click(sender As Object, e As EventArgs)
        actualizarDetalles()
    End Sub

    Private Sub biAsignar_Click(sender As Object, e As EventArgs) Handles biAsignar.Click, miAsignar.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub NuevoDetalle()

        Try
            Dim frm As New frmReciboHonorario_AgregarCC
            frm.IdHonorarioDet = IdHonorarioDet
            frm.IdHonorario = IdHonorario
            frm.MontoSoles = txtMontoSol.Value
            frm.MontoIRSol = txtMontoIRSol.Value
            frm.TotalSoles = txtMontoNetoSol.Value

            frm.MontoDolares = txtMontoDol.Value
            frm.MontoIRDol = txtMontoIRDol.Value
            frm.TotalDolares = txtMontoNetoDol.Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                enableOpciones()
                actualizarDetalles()
            Else
                ObtenerRegistro()
                actualizarDetalles()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR CENTROS DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub txtCodCuenta_Validated(sender As Object, e As EventArgs) Handles txtCodCuenta.Validated
        If Len(Trim(txtCodCuenta.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCuenta.Text = ""
                lblDesCuenta.Text = ""
                txtCodCuenta.Focus()
            Else
                Dim IdCuenta As Integer
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                Dim registro As New CuentaContableService.CuentaContable
                registro = oCuentaContableService.Obtener(IdCuenta)
                lblDesCuenta.Text = registro.NomCuenta
                'txtNumJob.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub txtMontoSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoIRSol.Focus()
        End If
    End Sub

    Private Sub txtMontoIgvSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoIRSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservación.Focus()
        End If
    End Sub

    Private Sub txtMontoDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoDol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoIRDol.Focus()
        End If
    End Sub

    Private Sub txtMontoIgvDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoIRDol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservación.Focus()
        End If
    End Sub



End Class