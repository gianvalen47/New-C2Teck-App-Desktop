Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmContratos

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oContratoPersonaService As New ContratoPersonaService.ContratoPersonaServiceClient
    Private oAumentosService As New AumentosService.AumentosServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As New DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As DataTable
    Private state_Search As Boolean
    Private IdPersona As Integer
    Private dtAFPs As DataTable
    Private dtIngresos As DataTable
    Private dtPeriodosContrato As DataTable
    Private dtModalidad As DataTable
    Private dtBancosCTS As DataTable
    Private dtBancosAbono As DataTable
    Private dtMonedas As DataTable
    Private dtMonedasCTS As DataTable
    Private dtAumentos As DataTable
    Private dtNoAporte As DataTable
    Private dtOtroEmpleador As DataTable
    Private dtOtroSueldoEmpleador As DataTable
    Private dtDHMayores As DataTable

    Public state_button As Boolean                      'True: Modificar    False: nuevo
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True                   'True: Editable     False: No Editable 

    Private Sub frmContPlanillas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmContPlanillas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 209)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvAfps)
        dgvAfps.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvIngresos)
        dgvIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvPeriodoContrato)
        dgvPeriodoContrato.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvAumentos)
        dgvAumentos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvOtroEmpleador)
        dgvOtroEmpleador.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvOtrosSueldos)
        dgvOtrosSueldos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvDHMayores)
        dgvDHMayores.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both


        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
        dgvDatos.Select()

        txtanioOtroSueldo.Value = Today.Year
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oPersonaService.Close()
            oContratoPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oPersonaService.Abort()
            oContratoPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oPersonaService.Abort()
            oContratoPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub Activar()
        Try
            If state_button Then
                txtFecInicio.ReadOnly = False
                txtFecInicio.BackColor = System.Drawing.SystemColors.Window
                txtFecFinal.ReadOnly = False
                txtFecFinal.BackColor = System.Drawing.SystemColors.Window
                cmbModalidad.ReadOnly = False
                cmbModalidad.BackColor = System.Drawing.SystemColors.Window
                txtNumSeguro.ReadOnly = False
                txtNumSeguro.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
                txtMovilidad.ReadOnly = False
                txtMovilidad.BackColor = System.Drawing.SystemColors.Window
                cbSaludVida.Enabled = True
                cbAsignacionFamiliar.Enabled = True
                cbJubilacion.Enabled = True

                cbEPS.Enabled = True
                cbSCTR.Enabled = True


                cmbBancoCTS.ReadOnly = False
                cmbBancoCTS.BackColor = System.Drawing.SystemColors.Window
                txtNumCuentaCTS.ReadOnly = False
                txtNumCuentaCTS.BackColor = System.Drawing.SystemColors.Window
                cmbMonedaCTS.ReadOnly = False
                cmbMonedaCTS.BackColor = System.Drawing.SystemColors.Window
                'cmbNoAporte.ReadOnly = False
                'cmbNoAporte.BackColor = System.Drawing.SystemColors.Window


                cmbBancoAbono.ReadOnly = False
                cmbBancoAbono.BackColor = System.Drawing.SystemColors.Window
                txtNumCuentaAbono.ReadOnly = False
                txtNumCuentaAbono.BackColor = System.Drawing.SystemColors.Window

                txtCantidadDH.ReadOnly = False
                txtCantidadDH.BackColor = System.Drawing.SystemColors.Window
                txtMontoEPS.ReadOnly = False
                txtMontoEPS.BackColor = System.Drawing.SystemColors.Window
            Else
                txtFecInicio.ReadOnly = False
                txtFecInicio.BackColor = System.Drawing.SystemColors.Window
                txtFecFinal.ReadOnly = False
                txtFecFinal.BackColor = System.Drawing.SystemColors.Window
                cmbModalidad.ReadOnly = False
                cmbModalidad.BackColor = System.Drawing.SystemColors.Window
                txtNumSeguro.ReadOnly = False
                txtNumSeguro.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
                txtMovilidad.ReadOnly = False
                txtMovilidad.BackColor = System.Drawing.SystemColors.Window
                cbSaludVida.Enabled = True
                cbAsignacionFamiliar.Enabled = True
                cbEPS.Enabled = True
                cbSCTR.Enabled = True


                cmbBancoCTS.ReadOnly = False
                cmbBancoCTS.BackColor = System.Drawing.SystemColors.Window
                txtNumCuentaCTS.ReadOnly = False
                txtNumCuentaCTS.BackColor = System.Drawing.SystemColors.Window
                cmbMonedaCTS.ReadOnly = False
                cmbMonedaCTS.BackColor = System.Drawing.SystemColors.Window
                'cmbNoAporte.ReadOnly = False
                'cmbNoAporte.BackColor = System.Drawing.SystemColors.Window

                cmbBancoAbono.ReadOnly = False
                cmbBancoAbono.BackColor = System.Drawing.SystemColors.Window
                txtNumCuentaAbono.ReadOnly = False
                txtNumCuentaAbono.BackColor = System.Drawing.SystemColors.Window

                txtCantidadDH.ReadOnly = False
                txtCantidadDH.BackColor = System.Drawing.SystemColors.Window
                txtMontoEPS.ReadOnly = False
                txtMontoEPS.BackColor = System.Drawing.SystemColors.Window

            End If

            edicion = True
            EnableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        Try

            txtFecInicio.ReadOnly = True
            txtFecInicio.BackColor = Color.Gainsboro
            txtFecFinal.ReadOnly = True
            txtFecFinal.BackColor = Color.Gainsboro
            cmbModalidad.ReadOnly = True
            cmbModalidad.BackColor = Color.Gainsboro
            txtNumSeguro.ReadOnly = True
            txtNumSeguro.BackColor = Color.Gainsboro
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = Color.Gainsboro
            txtMovilidad.ReadOnly = True
            txtMovilidad.BackColor = Color.Gainsboro
            cbSaludVida.Enabled = False
            cbAsignacionFamiliar.Enabled = False
            cbJubilacion.Enabled = False
            cbEPS.Enabled = False
            cbSCTR.Enabled = False

            cmbBancoCTS.ReadOnly = True
            cmbBancoCTS.BackColor = Color.Gainsboro
            txtNumCuentaCTS.ReadOnly = True
            txtNumCuentaCTS.BackColor = Color.Gainsboro
            cmbMonedaCTS.ReadOnly = True
            cmbMonedaCTS.BackColor = Color.Gainsboro

            cmbNoAporte.ReadOnly = True
            cmbNoAporte.BackColor = Color.Gainsboro
            cmbBancoAbono.ReadOnly = True
            cmbBancoAbono.BackColor = Color.Gainsboro
            txtNumCuentaAbono.ReadOnly = True
            txtNumCuentaAbono.BackColor = Color.Gainsboro

            txtCantidadDH.ReadOnly = True
            txtCantidadDH.BackColor = Color.Gainsboro
            txtMontoEPS.ReadOnly = True
            txtMontoEPS.BackColor = Color.Gainsboro

            edicion = False
            EnableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOpciones()
        If dgvDatos.RowCount > 0 Then
            Dim contrato As Boolean
            contrato = oContratoPersonaService.Buscar(dgvDatos.CurrentRow.Cells("IdPer").Value)

            btnEditar.Enabled = IIf(editable, Not edicion And ValidaCodigoPersona(), False)
            btnEliminar.Enabled = IIf(Not edicion And ValidaCodigoPersona(), True, False)
            btnGuardar.Enabled = edicion
            btnDeshacer.Enabled = IIf(state_button And edicion, True, False)
            cmOpcionesIngresos.Enabled = IIf(contrato, True, False)
            dgvIngresos.Enabled = IIf(contrato, True, False)
            cmOpcionesAumentos.Enabled = IIf(contrato, True, False)
            cmOpcionesPerContrato.Enabled = IIf(contrato, True, False)
            cmOpcionesOtroEmpleador.Enabled = IIf(contrato, True, False)
            'cmOpcionesOtroSueldo.Enabled = IIf(contrato, True, False)
            If cmOpcionesIngresos.Enabled = True Then
                If dgvIngresos.RowCount > 0 Then
                    miMostrarIng.Enabled = True
                    miEliminarIng.Enabled = True
                Else
                    miMostrarIng.Enabled = False
                    miEliminarIng.Enabled = False
                End If
            End If

            cmOpcionesAfp.Enabled = True
            If dgvAfps.RowCount > 0 Then
                miMostrarAFP.Enabled = True
                miEliminarAFP.Enabled = True
            Else
                miMostrarAFP.Enabled = False
                miEliminarAFP.Enabled = False
            End If

            If cmOpcionesAumentos.Enabled = True Then
                If dgvAumentos.RowCount > 0 Then
                    miMostrarAumento.Enabled = True
                    miEliminarAumento.Enabled = True
                Else
                    miMostrarAumento.Enabled = False
                    miEliminarAumento.Enabled = False
                End If
            End If

            If cmOpcionesPerContrato.Enabled = True Then
                If dgvPeriodoContrato.RowCount > 0 Then
                    miMostrarPerContrato.Enabled = True
                    miEliminarPerContrato.Enabled = True
                Else
                    miMostrarPerContrato.Enabled = False
                    miEliminarPerContrato.Enabled = False
                End If
            End If

            If cmOpcionesOtroEmpleador.Enabled = True Then
                If dgvOtroEmpleador.RowCount > 0 Then
                    miMostrarEmpleador.Enabled = True
                    miEliminarEmpleador.Enabled = True
                Else
                    miMostrarEmpleador.Enabled = False
                    miEliminarEmpleador.Enabled = False
                End If
            End If

            If cmOpcionesOtroSueldo.Enabled = True Then
                If dgvOtrosSueldos.RowCount > 0 Then
                    miMostraOtroSueldo.Enabled = True
                    miBorrarOtroSueldo.Enabled = True
                Else
                    miMostraOtroSueldo.Enabled = False
                    miBorrarOtroSueldo.Enabled = False
                End If
            End If

            If cmOpcionesDHMayores.Enabled = True Then
                If dgvDHMayores.RowCount > 0 Then
                    miMostrarDHMayor.Enabled = True
                    miEliminarDHMayor.Enabled = True
                Else
                    miMostrarDHMayor.Enabled = False
                    miEliminarDHMayor.Enabled = False
                End If
            End If


        Else
            btnEditar.Enabled = False
            btnEliminar.Enabled = False
            btnGuardar.Enabled = False
            btnDeshacer.Enabled = False
            cmOpcionesIngresos.Enabled = False
            cmOpcionesAfp.Enabled = False
            cmOpcionesAumentos.Enabled = False
            cmOpcionesPerContrato.Enabled = False
            cmOpcionesOtroEmpleador.Enabled = False
            cmOpcionesOtroSueldo.Enabled = False
            cmOpcionesDHMayores.Enabled = False
        End If
        dgvDatos.Enabled = IIf(state_button And edicion, False, True)
        tpPerContratos.Enabled = IIf(state_button = True And edicion = False, True, False)
        tpAumentosMovAFPs.Enabled = IIf(state_button = True And edicion = False, True, False)
        tpOtroEmpleador.Enabled = IIf(state_button = True And edicion = False, True, False)
        tpDHMayores.Enabled = IIf(state_button = True And edicion = False, True, False)
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '----------------------------------------------------------------------------- FILTRAR -----------------------------------------------------------------------------------------------
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------- CONTRATO --------------------------------------------------------------------------------------------
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '===================================== MODALIDAD =============================================
            dtModalidad = oContratoPersonaService.MostrarModalidad.Tables(0)
            'dtModalidad.Rows.InsertAt(getRowTodos(dtModalidad), 0)
            cmbModalidad.DataSource = dtModalidad
            cmbModalidad.DropDownList.DataMember = dtModalidad.Columns("DesMod").ToString
            cmbModalidad.DropDownList.DisplayMember = dtModalidad.Columns("DesMod").ToString
            cmbModalidad.DropDownList.ValueMember = dtModalidad.Columns("IdModalidad").ToString
            cmbModalidad.DropDownList.Columns(0).DataMember = dtModalidad.Columns("IdModalidad").ToString
            cmbModalidad.DropDownList.Columns(1).DataMember = dtModalidad.Columns("DesMod").ToString
            cmbModalidad.SelectedIndex = 0
            dtModalidad = Nothing

            '======================================= MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '====================================== BANCOS CTS =============================================
            dtBancosCTS = oMaestroService.MostrarBancos.Tables(0)
            'dtBancosCTS.Rows.InsertAt(getRowTodos(dtBancosCTS), 0)
            cmbBancoCTS.DataSource = dtBancosCTS
            cmbBancoCTS.DropDownList.DataMember = dtBancosCTS.Columns("DesBan").ToString
            cmbBancoCTS.DropDownList.DisplayMember = dtBancosCTS.Columns("DesBan").ToString
            cmbBancoCTS.DropDownList.ValueMember = dtBancosCTS.Columns("CodBan").ToString
            cmbBancoCTS.DropDownList.Columns(0).DataMember = dtBancosCTS.Columns("CodBan").ToString
            cmbBancoCTS.DropDownList.Columns(1).DataMember = dtBancosCTS.Columns("DesBan").ToString
            cmbBancoCTS.SelectedIndex = 0
            dtBancosCTS = Nothing

            '====================================== BANCOS CTS =============================================
            dtBancosAbono = oMaestroService.MostrarBancos.Tables(0)
            'dtBancosAbono.Rows.InsertAt(getRowTodos(dtBancosAbono), 0)
            cmbBancoAbono.DataSource = dtBancosAbono
            cmbBancoAbono.DropDownList.DataMember = dtBancosAbono.Columns("DesBan").ToString
            cmbBancoAbono.DropDownList.DisplayMember = dtBancosAbono.Columns("DesBan").ToString
            cmbBancoAbono.DropDownList.ValueMember = dtBancosAbono.Columns("CodBan").ToString
            cmbBancoAbono.DropDownList.Columns(0).DataMember = dtBancosAbono.Columns("CodBan").ToString
            cmbBancoAbono.DropDownList.Columns(1).DataMember = dtBancosAbono.Columns("DesBan").ToString
            cmbBancoAbono.SelectedIndex = 0
            dtBancosAbono = Nothing

            '================================== MONEDAS CTS =============================================
            dtMonedasCTS = oMaestroService.MostrarMonedas.Tables(0)
            cmbMonedaCTS.DataSource = dtMonedasCTS
            cmbMonedaCTS.DropDownList.DataMember = dtMonedasCTS.Columns("AbrMon").ToString
            cmbMonedaCTS.DropDownList.DisplayMember = dtMonedasCTS.Columns("AbrMon").ToString
            cmbMonedaCTS.DropDownList.ValueMember = dtMonedasCTS.Columns("CodMon").ToString
            cmbMonedaCTS.DropDownList.Columns(0).DataMember = dtMonedasCTS.Columns("CodMon").ToString
            cmbMonedaCTS.DropDownList.Columns(1).DataMember = dtMonedasCTS.Columns("AbrMon").ToString
            dtMonedasCTS = Nothing

            '================================== CODIGOS NO APORTE =============================================
            dtNoAporte = oContratoPersonaService.MostrarCodigosNoAportar
            cmbNoAporte.DataSource = dtNoAporte
            cmbNoAporte.DropDownList.DataMember = dtNoAporte.Columns("Codigo").ToString
            cmbNoAporte.DropDownList.DisplayMember = dtNoAporte.Columns("Codigo").ToString
            cmbNoAporte.DropDownList.ValueMember = dtNoAporte.Columns("Codigo").ToString
            cmbNoAporte.DropDownList.Columns(0).DataMember = dtNoAporte.Columns("Codigo").ToString
            cmbNoAporte.DropDownList.Columns(1).DataMember = dtNoAporte.Columns("Codigo").ToString
            dtNoAporte = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try
            'If cmbArea.Value <> "" Then
            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, "").Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            If cmbCodArea.Value <> "" Then
                cmbCentroCosto.SelectedIndex = 1
            Else
                cmbCentroCosto.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oPersonaService.Filtrar(Session.sCodEmp, toBlank(cmbCodArea.Value), toBlank(cmbCentroCosto.Value), "", txtColaborador.Text, IIf(cbVigente.Checked = True, True, False)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslError.Text = "Registros : " + dgvDatos.RowCount.ToString
                EnableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCodArea.ValueChanged, cmbCentroCosto.ValueChanged, txtColaborador.TextChanged, cbVigente.CheckedChanged
        listaDatos()
    End Sub

    Private Sub ObtenerContrato()
        Try
            IdPersona = toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value)

            '==================================================
            '-----------------------------------------CONTRATOS---------------------------------------
            '==================================================
            If oContratoPersonaService.Buscar(IdPersona) Then
                editable = True
                EnableOpciones()

                Dim registro As New ContratoPersonaService.ContratoPersona
                registro = oContratoPersonaService.Obtener(toNumber(IdPersona))

                txtFecInicio.Value = registro.FecInicio
                txtFecInicio.Text = registro.FecInicio.ToString
                txtFecFinal.Value = registro.FecFinal
                txtFecFinal.Text = registro.FecFinal.ToString
                cmbModalidad.Value = registro.Modalidad.IdModalidad
                txtNumSeguro.Text = registro.NumSeguro
                cmbMoneda.Value = registro.Moneda.CodMon
                txtTotalIngresos.Value = registro.TotalIngresos
                txtMovilidad.Value = registro.Movilidad
                cbSaludVida.Checked = registro.SaludVida
                cbAsignacionFamiliar.Checked = registro.AsigFamiliar

                ListarRubroIngreso()

                cmbBancoCTS.Value = registro.BancoCTS.CodBan
                txtNumCuentaCTS.Text = registro.NumCuentaCTS
                cmbMonedaCTS.Value = registro.MonedaCTS.CodMon

                cmbBancoAbono.Value = registro.BancoAbono.CodBan
                txtNumCuentaAbono.Text = registro.NumCuentaAbono

                cbJubilacion.Checked = registro.JubilacionAnticipada

                cbEPS.Checked = registro.TieneEPS
                cbSCTR.Checked = registro.TieneSCTR
                cmbNoAporte.Value = registro.CodNoAporte
                txtCantidadDH.Value = registro.CantidadDH
                txtMontoEPS.Value = registro.MontoEPS

                ListarPeriodoContrato()
            Else
                editable = False
                EnableOpciones()
                LimpiarContrato()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerPersona()
        Try
            IdPersona = toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value)
            Dim registro As New PersonaService.Persona
            registro = oPersonaService.Obtener(toNumber(IdPersona))

            '==================================================
            '------------------------------------------ CONTRATO ---------------------------------------
            '==================================================
            txtNombreContrato.Text = registro.ApeNom
            txtAreaContrato.Text = registro.CentroCosto.Area.DesArea
            txtcentroCostoContrato.Text = registro.CentroCosto.DesCentro

            '==================================================
            '--------------------------------- PERIODOS CONTRATO ------------------------------
            '==================================================
            txtNombrePerContrato.Text = registro.ApeNom
            txtAreaPerContrato.Text = registro.CentroCosto.Area.DesArea
            txtCentroCostoPerContrato.Text = registro.CentroCosto.DesCentro
            dtPeriodosContrato = Nothing
            ListarPeriodoContrato()

            '==================================================
            '----------------------------------------- MOV. AFPs ---------------------------------------
            '==================================================
            txtNombreAfp.Text = registro.ApeNom
            txtAreaAfp.Text = registro.CentroCosto.Area.DesArea
            txtCentroCostoAfp.Text = registro.CentroCosto.DesCentro
            dtAFPs = Nothing
            ListarAFPs()

            dtAumentos = Nothing
            ListarAumentos()


            '==================================================
            '--------------------------------- OTROS EMPLEADORES ------------------------------
            '==================================================
            txtPersonaOtro.Text = registro.ApeNom
            txtAreaOtro.Text = registro.CentroCosto.Area.DesArea
            txtCentroOtro.Text = registro.CentroCosto.DesCentro
            dtOtroEmpleador = Nothing
            ListarOtroEmpleador()


            '==================================================
            '--------------------------------- OTROS SUELDOS EMPLEADORES ------------------------------
            '==================================================
            txtPersonaOtro.Text = registro.ApeNom
            txtAreaOtro.Text = registro.CentroCosto.Area.DesArea
            txtCentroOtro.Text = registro.CentroCosto.DesCentro
            dtOtroSueldoEmpleador = Nothing
            ListarOtroSueldoEmpleador()

            '==================================================
            '--------------------------------- DERECHO HABIENTES MAYORES ------------------------------
            '==================================================
            dtDHMayores = Nothing
            ListarDHMayores()

            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        If dgvDatos.RowCount > 0 Then
            If ValidaCodigoPersona() Then
                ObtenerPersona()
                If oContratoPersonaService.Buscar(toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value)) Then
                    ObtenerContrato()
                    state_button = True
                    edicion = False
                    Desactivar()
                Else
                    LimpiarContrato()
                    state_button = False
                    edicion = True
                    Activar()
                End If
                EnableOpciones()
            End If
        Else
            Desactivar()
            txtNombreContrato.Text = ""
            txtAreaContrato.Text = ""
            txtcentroCostoContrato.Text = ""
            LimpiarPersona()
            LimpiarContrato()
        End If
    End Sub

    Private Sub LimpiarContrato()
        Try
            'txtNombreContrato.Text = ""
            'txtAreaContrato.Text = ""

            txtFecInicio.IsNullDate = True
            txtFecInicio.Text = ""
            txtFecFinal.IsNullDate = True
            txtFecFinal.Text = ""
            cmbModalidad.Value = ""
            txtNumSeguro.Text = ""
            cmbMoneda.Value = ""
            txtTotalIngresos.Value = 0
            txtMovilidad.Value = 0
            cbSaludVida.Checked = False
            cbAsignacionFamiliar.Checked = False

            cmbBancoCTS.Value = ""
            txtNumCuentaCTS.Text = ""
            cmbMonedaCTS.Value = ""
            cmbBancoAbono.Value = ""
            txtNumCuentaAbono.Text = ""

            dgvIngresos.DataSource = Nothing
            dgvPeriodoContrato.DataSource = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarPersona()
        Try
            IdPersona = 0

            txtNombrePerContrato.Text = ""
            txtAreaPerContrato.Text = ""
            txtCentroCostoPerContrato.Text = ""
            dgvPeriodoContrato.DataSource = Nothing

            txtNombreAfp.Text = ""
            txtAreaAfp.Text = ""
            txtCentroCostoAfp.Text = ""
            dgvAfps.DataSource = Nothing

            dgvAumentos.DataSource = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR PERSONA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Activar()
    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        ObtenerContrato()
        Desactivar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If ValidaCodigoPersona() Then
            eliminar()
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecInicio.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Inicio.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf toBlank(txtFecFinal.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Termino.", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
                Return False
            ElseIf toBlank(cmbModalidad.Value) = "" Then
                MsgBox("Debe Ingresar la Modalidad.", MsgBoxStyle.Information, "Información")
                cmbModalidad.Focus()
                Return False
            ElseIf toBlank(txtNumSeguro.Text) = "" Then
                MsgBox("Debe Ingresar el Número de Seguro.", MsgBoxStyle.Information, "Información")
                txtNumSeguro.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toBlank(cmbBancoCTS.Value) = "" Then
                MsgBox("Debe Ingresar la Entidad CTS.", MsgBoxStyle.Information, "Información")
                cmbBancoCTS.Focus()
                Return False
            ElseIf toBlank(txtNumCuentaCTS.Text) = "" Then
                MsgBox("Debe Ingresar el Número de Cuenta CTS.", MsgBoxStyle.Information, "Información")
                txtNumCuentaCTS.Focus()
                Return False
            ElseIf toBlank(cmbMonedaCTS.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda de CTS.", MsgBoxStyle.Information, "Información")
                cmbMonedaCTS.Focus()
                Return False
            ElseIf toBlank(cmbMonedaCTS.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda de CTS.", MsgBoxStyle.Information, "Información")
                cmbMonedaCTS.Focus()
                Return False
            ElseIf toBlank(cmbBancoAbono.Value) = "" Then
                MsgBox("Debe Ingresar la Entidad Abono.", MsgBoxStyle.Information, "Información")
                cmbBancoAbono.Focus()
                Return False
            ElseIf toBlank(txtNumCuentaAbono.Text) = "" Then
                MsgBox("Debe Ingresar el Número de Cuenta Abono.", MsgBoxStyle.Information, "Información")
                txtNumCuentaAbono.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As ContratoPersonaService.ContratoPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.Insertar(registro)
            If estado_process = True Then
                MsgBox("Se insertó el Contrato Correctamente.")
                state_button = True
                edicion = False
                Desactivar()
                ObtenerContrato()
                ListarRubroIngreso()
                ListarPeriodoContrato()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR REGISTRO CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContratoPersonaService.ContratoPersona)
        Try
            Dim estado_process As Boolean
            estado_process = oContratoPersonaService.Actualizar(registro)
            If estado_process = True Then
                ObtenerContrato()
                ListarRubroIngreso()
                ListarPeriodoContrato()
                edicion = False
                state_button = True
                Desactivar()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR REGISTRO CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el Contrato del Colaborador : " + dgvDatos.CurrentRow.Cells("ApeNom").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdPer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    LimpiarContrato()
                    state_button = False
                    Activar()
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL CONTRATO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoPersona() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                And ValidaCampos() Then
                Dim registro As New ContratoPersonaService.ContratoPersona
                Dim BancoAbono As New ContratoPersonaService.Banco
                Dim BancoCTS As New ContratoPersonaService.Banco
                Dim Modalidad As New ContratoPersonaService.Modalidad
                Dim Moneda As New ContratoPersonaService.Moneda
                Dim MonedaCTS As New ContratoPersonaService.Moneda
                Dim Persona As New ContratoPersonaService.Persona

                Persona.IdPer = IdPersona
                registro.Persona = Persona

                registro.FecInicio = txtFecInicio.Value
                registro.FecFinal = txtFecFinal.Value
                Modalidad.IdModalidad = cmbModalidad.Value
                registro.Modalidad = Modalidad
                registro.NumSeguro = txtNumSeguro.Text
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.TotalIngresos = txtTotalIngresos.Value
                registro.Movilidad = txtMovilidad.Value
                registro.SaludVida = cbSaludVida.Checked
                registro.AsigFamiliar = cbAsignacionFamiliar.Checked

                BancoCTS.CodBan = cmbBancoCTS.Value
                registro.BancoCTS = BancoCTS
                registro.NumCuentaCTS = txtNumCuentaCTS.Text
                MonedaCTS.CodMon = cmbMonedaCTS.Value
                registro.MonedaCTS = MonedaCTS

                BancoAbono.CodBan = cmbBancoAbono.Value
                registro.BancoAbono = BancoAbono
                registro.NumCuentaAbono = txtNumCuentaAbono.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.JubilacionAnticipada = cbJubilacion.Checked
                registro.CodNoAporte = cmbNoAporte.Value
                registro.TieneEPS = cbEPS.Checked
                registro.TieneSCTR = cbSCTR.Checked
                registro.CantidadDH = txtCantidadDH.Value
                registro.MontoEPS = txtMontoEPS.Value

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtFecInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecInicio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFecFinal.Focus()
        End If
    End Sub

    Private Sub txtFecFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbModalidad.Focus()
        End If
    End Sub

    Private Sub cmbModalidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbModalidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNumSeguro.Focus()
        End If
    End Sub

    Private Sub txtNumSeguro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSeguro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMovilidad.Focus()
        End If
    End Sub

    Private Sub txtMovilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMovilidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbAsignacionFamiliar.Focus()
        End If
    End Sub

    Private Sub cbAsignacionFamiliar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAsignacionFamiliar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbSaludVida.Focus()
        End If
    End Sub

    Private Sub cbSaludVida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSaludVida.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbBancoCTS.Focus()
        End If
    End Sub

    Private Sub cmbBancoCTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBancoCTS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNumCuentaCTS.Focus()
        End If
    End Sub

    Private Sub txtNumCuentaCTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCuentaCTS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMonedaCTS.Focus()
        End If
    End Sub

    Private Sub cmbMonedaCTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMonedaCTS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbBancoAbono.Focus()
        End If
    End Sub

    Private Sub cmbBancoAbono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBancoAbono.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNumCuentaAbono.Focus()
        End If
    End Sub

    Private Sub txtNumCuentaAbono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCuentaAbono.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '========================================== PERIODOS CONTRATO ==========================================
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarPeriodoContrato()
        Try
            dtPeriodosContrato = oContratoPersonaService.FiltrarPeriodosContrato(IdPersona).Tables(0)
            dgvPeriodoContrato.DataSource = dtPeriodosContrato
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR PERIODOS CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionPerContrato(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdContrato").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] PERIODO CONTRATO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoPerContrato()
        Try
            Dim frm As New frmContPerContrato_Det
            frm.state_button = False
            frm.IdPersona = IdPersona
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPeriodosContrato = Nothing
                ListarPeriodoContrato()
                If frm.type_process = "insert" Then
                    RowPossesionPerContrato(dgvPeriodoContrato, frm.IdCon)
                End If
            End If
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO PERIODO CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarPerContrato()
        Try
            Dim frm As New frmContPerContrato_Det
            frm.state_button = True
            frm.IdCon = dgvPeriodoContrato.CurrentRow.Cells("IdContrato").Value
            frm.IdPersona = dgvPeriodoContrato.CurrentRow.Cells("IdPer").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPeriodosContrato = Nothing
                ListarPeriodoContrato()
                If frm.type_process = "update" Then
                    RowPossesionPerContrato(dgvPeriodoContrato, frm.IdCon)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionPerContrato(dgvPeriodoContrato, frm.IdCon)
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR PERIODO CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarPerContrato()
        Try
            cmOpcionesPerContrato.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.BorrarPeriodosContrato(toNumber(dgvPeriodoContrato.CurrentRow.Cells("IdContrato").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtPeriodosContrato = Nothing
                    ListarPeriodoContrato()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR PERIODO CONTRATO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarPerContratos()
        Try
            Dim codigo As String = ""
            If dgvPeriodoContrato.RowCount > 0 Then
                If IsDBNull(dgvPeriodoContrato.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvPeriodoContrato.CurrentRow.Cells("IdContrato").Text
                End If
            End If
            dtPeriodosContrato = Nothing
            ListarPeriodoContrato()
            If dgvPeriodoContrato.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionPerContrato(dgvPeriodoContrato, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR PERIODOS CONTRATO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoPerContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoPerContrato.Click
        NuevoPerContrato()
    End Sub

    Private Sub miMostrarPerContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarPerContrato.Click, dgvPeriodoContrato.DoubleClick
        MostrarPerContrato()
    End Sub

    Private Sub miEliminarPerContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarPerContrato.Click
        EliminarPerContrato()
    End Sub

    Private Sub miActualizarPerContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarPerContrato.Click
        ActualizarPerContratos()
    End Sub

    Private Sub dgvPeriodoContrato_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPeriodoContrato.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvPeriodoContrato.RowCount > 0 Then
                miMostrarPerContrato_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvPeriodoContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvPeriodoContrato.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================================== MOV. AFPs ===============================================
    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarAFPs()
        Try
            dtAFPs = oContratoPersonaService.MostrarAfpPersona(IdPersona).Tables(0)
            dgvAfps.DataSource = dtAFPs
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR AFPs: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionAfp(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdAfp").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] AFP: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoAFP()
        Try
            Dim frm As New frmContAfp_Det
            frm.state_button = False
            frm.IdPersona = IdPersona
            If dgvAfps.RowCount > 0 Then
                frm.NumCuenta = dgvAfps.CurrentRow.Cells("NumCuenta").Value
            Else
                frm.NumCuenta = ""
            End If
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtAFPs = Nothing
                ListarAFPs()
                If frm.type_process = "insert" Then
                    RowPossesionAfp(dgvAfps, frm.IdAfp)
                End If
            End If
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO AFP: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarAFP()
        Try
            Dim frm As New frmContAfp_Det
            frm.state_button = True
            frm.IdAfp = dgvAfps.CurrentRow.Cells("IdAfp").Value
            frm.IdPersona = dgvAfps.CurrentRow.Cells("IdPer").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtAFPs = Nothing
                ListarAFPs()
                If frm.type_process = "update" Then
                    RowPossesionAfp(dgvAfps, frm.IdAfp)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionAfp(dgvAfps, frm.IdAfp)
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR AFP: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarAFP()
        Try
            cmOpcionesAfp.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.BorrarAfpPersona(toNumber(dgvAfps.CurrentRow.Cells("IdAfp").Value), toNumber(dgvAfps.CurrentRow.Cells("IdPer").Value))
                If estado_process = True Then
                    dtAFPs = Nothing
                    ListarAFPs()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR AFP:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarAFPs()
        Try
            Dim codigo As String = ""
            If dgvAfps.RowCount > 0 Then
                If IsDBNull(dgvAfps.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvAfps.CurrentRow.Cells("IdAfp").Text
                End If
            End If
            dtAFPs = Nothing
            ListarAFPs()
            If dgvAfps.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionAfp(dgvAfps, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR AFPs: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoAFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoAFP.Click
        NuevoAFP()
    End Sub

    Private Sub miMostrarAFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarAFP.Click, dgvAfps.DoubleClick
        MostrarAFP()
    End Sub

    Private Sub miEliminarAFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarAFP.Click
        EliminarAFP()
    End Sub

    Private Sub miActualizarAFP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarAFP.Click
        ActualizarAFPs()
    End Sub

    Private Sub dgvAfps_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAfps.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvAfps.RowCount > 0 Then
                miMostrarAFP_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvAfps_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvAfps.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================================== AUMENTOS ===============================================
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarAumentos()
        Try
            dtAumentos = oAumentosService.Mostrar(IdPersona).Tables(0)
            dgvAumentos.DataSource = dtAumentos
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR AUMENTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionAumentos(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdAumento").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoAumento()
        Try
            Dim frm As New frmContAumento_Det
            frm.state_button = False
            frm.IdPersona = IdPersona
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerContrato()
                ObtenerPersona()
                If frm.type_process = "insert" Then
                    RowPossesionAumentos(dgvAumentos, frm.IdAumento)
                End If
            End If
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO AUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarAumento()
        Try
            Dim frm As New frmContAumento_Det
            frm.state_button = True
            frm.IdAumento = dgvAumentos.CurrentRow.Cells("IdAumento").Value
            frm.IdPersona = dgvAumentos.CurrentRow.Cells("IdPer").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerContrato()
                ObtenerPersona()
                If frm.type_process = "update" Then
                    RowPossesionAumentos(dgvAumentos, frm.IdAumento)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionAumentos(dgvAumentos, frm.IdAumento)
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR AUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarAumento()
        Try
            cmOpcionesAumentos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oAumentosService.Borrar(toNumber(dgvAumentos.CurrentRow.Cells("IdAumento").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    ObtenerContrato()
                    ObtenerPersona()
                    dtAumentos = Nothing
                    ListarAumentos()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR AUMENTO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarAumento()
        Try
            Dim codigo As String = ""
            If dgvAumentos.RowCount > 0 Then
                If IsDBNull(dgvAumentos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvAumentos.CurrentRow.Cells("IdAumento").Text
                End If
            End If
            dtAumentos = Nothing
            ListarAumentos()
            If dgvAumentos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionAumentos(dgvAumentos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR AUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoAumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoAumento.Click
        NuevoAumento()
    End Sub

    Private Sub miMostrarAumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarAumento.Click, dgvAumentos.DoubleClick
        MostrarAumento()
    End Sub

    Private Sub miEliminarAumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarAumento.Click
        EliminarAumento()
    End Sub

    Private Sub miActualizarAumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarAumento.Click
        ActualizarAumento()
    End Sub

    Private Sub dgvAumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAumentos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvAumentos.RowCount > 0 Then
                miMostrarAumento_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvAumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvAumentos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '============================================== INGRESOS ===============================================
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarRubroIngreso()
        Try
            dtIngresos = oContratoPersonaService.MostrarRubroIngreso(IdPersona).Tables(0)
            dgvIngresos.DataSource = dtIngresos
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR RUBRO INGRESO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionIngresos(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubroIng").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoIngreso()
        Try
            Dim frm As New frmContIngreso_Det
            frm.state_button = False
            frm.IdPersona = IdPersona
            frm.CodMon = cmbMoneda.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtIngresos = Nothing
                ObtenerContrato()
                ListarRubroIngreso()
                EnableOpciones()
                If frm.type_process = "insert" Then
                    RowPossesionIngresos(dgvIngresos, frm.IdRubroIng)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO RUBRO INGRESO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarIngreso()
        Try
            Dim frm As New frmContIngreso_Det
            frm.state_button = True
            frm.IdRubroIng = dgvIngresos.CurrentRow.Cells("IdRubroIng").Value
            frm.IdPersona = dgvIngresos.CurrentRow.Cells("IdPer").Value
            frm.CodMon = cmbMoneda.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtIngresos = Nothing
                ObtenerContrato()
                ListarRubroIngreso()
                EnableOpciones()
                If frm.type_process = "update" Then
                    RowPossesionIngresos(dgvIngresos, frm.IdRubroIng)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionIngresos(dgvIngresos, frm.IdRubroIng)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR RUBRO INGRESO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarIngreso()
        Try
            cmOpcionesIngresos.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.BorrarRubroIngreso(toNumber(dgvIngresos.CurrentRow.Cells("IdPer").Value), toNumber(dgvIngresos.CurrentRow.Cells("IdRubroIng").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtIngresos = Nothing
                    ObtenerContrato()
                    ListarRubroIngreso()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR INGRESO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoIng.Click
        NuevoIngreso()
    End Sub

    Private Sub miMostrarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarIng.Click, dgvIngresos.DoubleClick
        MostrarIngreso()
    End Sub

    Private Sub miEliminarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarIng.Click
        EliminarIngreso()
    End Sub

    Private Sub actualizarIngresos()
        Try
            Dim codigo As String = ""
            If dgvIngresos.RowCount > 0 Then
                If IsDBNull(dgvIngresos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvIngresos.CurrentRow.Cells("IdRubroIng").Text
                End If
            End If
            dtIngresos = Nothing
            ListarRubroIngreso()
            If dgvIngresos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionIngresos(dgvIngresos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR INGRESOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizarIng_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarIng.Click
        actualizarIngresos()
    End Sub

    Private Sub dgvIngresos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIngresos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvIngresos.RowCount > 0 Then
                miMostrarIng_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvIngresos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvIngresos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           cmbCodArea.KeyPress _
                         , txtColaborador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbJubilacion_CheckedChanged(sender As Object, e As EventArgs) Handles cbJubilacion.CheckedChanged
        If cbJubilacion.Checked = True Then
            cmbNoAporte.ReadOnly = False
            cmbNoAporte.BackColor = System.Drawing.SystemColors.Window
        Else
            cmbNoAporte.ReadOnly = True
            cmbNoAporte.BackColor = System.Drawing.SystemColors.Control
            cmbNoAporte.Value = ""
        End If


    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '========================================== OTROS EMPLEADORES ==========================================
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarOtroEmpleador()
        Try
            dtOtroEmpleador = oContratoPersonaService.MostrarOtroEmpleador(IdPersona).Tables(0)
            dgvOtroEmpleador.DataSource = dtOtroEmpleador
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR OTROS EMPLEADORES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionOtroEmpleador(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("RucEmp").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] PERIODO CONTRATO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoOtroEmpleador()
        Try
            Dim frm As New frmContPerOtroEmpleador
            frm.state_button = False
            frm.IdPersona = IdPersona
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtOtroEmpleador = Nothing
                ListarOtroEmpleador()
                If frm.type_process = "insert" Then
                    RowPossesionOtroEmpleador(dgvOtroEmpleador, frm.rucEmp)
                End If
            End If
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO EMPLEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarOtroEmpleador()
        Try
            Dim frm As New frmContPerOtroEmpleador
            frm.state_button = True
            frm.rucEmp = dgvOtroEmpleador.CurrentRow.Cells("RucEmp").Value
            frm.IdPersona = dgvOtroEmpleador.CurrentRow.Cells("IdPer").Value
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtOtroEmpleador = Nothing
                ListarOtroEmpleador()
                If frm.type_process = "update" Then
                    RowPossesionOtroEmpleador(dgvOtroEmpleador, frm.rucEmp)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionOtroEmpleador(dgvOtroEmpleador, frm.rucEmp)
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR OTRO EMPLEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarOtroEmpleador()
        Try
            cmOpcionesOtroEmpleador.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.BorrarOtroEmpleador(dgvOtroEmpleador.CurrentRow.Cells("IdPer").Value, dgvOtroEmpleador.CurrentRow.Cells("RucEmp").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtOtroEmpleador = Nothing
                    ListarOtroEmpleador()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR OTRO EMPLEADOR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarOtroEmpleador()
        Try
            Dim codigo As String = ""
            If dgvOtroEmpleador.RowCount > 0 Then
                If IsDBNull(dgvOtroEmpleador.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvOtroEmpleador.CurrentRow.Cells("RucEmp").Text
                End If
            End If
            dtOtroEmpleador = Nothing
            ListarOtroEmpleador()
            If dgvOtroEmpleador.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionOtroEmpleador(dgvOtroEmpleador, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR OTRO EMPLEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvOtroEmpleador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOtroEmpleador.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvOtroEmpleador.RowCount > 0 Then
                miMostrarEmpleador_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvOtroEmpleador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvOtroEmpleador.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub miNuevoEmpleador_Click(sender As Object, e As EventArgs) Handles miNuevoEmpleador.Click
        NuevoOtroEmpleador()
    End Sub

    Private Sub miMostrarEmpleador_Click(sender As Object, e As EventArgs) Handles miMostrarEmpleador.Click, dgvOtroEmpleador.DoubleClick
        MostrarOtroEmpleador()
    End Sub

    Private Sub miEliminarEmpleador_Click(sender As Object, e As EventArgs) Handles miEliminarEmpleador.Click
        EliminarOtroEmpleador()
    End Sub

    Private Sub miActualizarEmpleador_Click(sender As Object, e As EventArgs) Handles miActualizarEmpleador.Click
        ActualizarOtroEmpleador()
    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '========================================== OTROS SUELDOS DE EMPLEADORES ==========================================
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarOtroSueldoEmpleador()
        Try
            If dtOtroEmpleador.Rows.Count > 0 Then
                dtOtroSueldoEmpleador = oContratoPersonaService.FiltrarOtroEmpleadorSueldo(IdPersona, dgvOtroEmpleador.CurrentRow.Cells("RucEmp").Value, txtanioOtroSueldo.Value).Tables(0)
                dgvOtrosSueldos.DataSource = dtOtroSueldoEmpleador
                cmOpcionesOtroSueldo.Enabled = True
            Else
                dtOtroSueldoEmpleador = Nothing
                dgvOtrosSueldos.DataSource = Nothing
                cmOpcionesOtroSueldo.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR OTROS EMPLEADORES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionOtroSueldoEmpleador(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("Mes").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] SUELDO OTRO EMPLEADOR: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoOtroSueldoEmpleador()
        Try
            Dim frm As New frmContPerOtroSueldoEmpleador
            frm.state_button = False
            frm.IdPersona = IdPersona
            frm.rucEmp = dgvOtroEmpleador.CurrentRow.Cells("RucEmp").Value
            frm.desEmp = dgvOtroEmpleador.CurrentRow.Cells("DesEmp").Value
            frm.periodo = txtanioOtroSueldo.Value
            'frm.mes = Today.Month
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtOtroSueldoEmpleador = Nothing
                ListarOtroSueldoEmpleador()
                If frm.type_process = "insert" Then
                    RowPossesionOtroSueldoEmpleador(dgvOtrosSueldos, frm.mes)
                End If
            End If
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO SUELDO EMPLEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarOtroSueldoEmpleador()
        Try
            Dim frm As New frmContPerOtroSueldoEmpleador
            frm.state_button = True
            frm.rucEmp = dgvOtrosSueldos.CurrentRow.Cells("RucEmp").Value
            frm.IdPersona = dgvOtrosSueldos.CurrentRow.Cells("IdPer").Value
            frm.periodo = dgvOtrosSueldos.CurrentRow.Cells("Periodo").Value
            frm.mes = dgvOtrosSueldos.CurrentRow.Cells("Mes").Value
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtOtroSueldoEmpleador = Nothing
                ListarOtroSueldoEmpleador()
                If frm.type_process = "update" Then
                    RowPossesionOtroSueldoEmpleador(dgvOtrosSueldos, frm.mes)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionOtroSueldoEmpleador(dgvOtrosSueldos, frm.mes)
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR OTRO EMPLEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarOtroSueldoEmpleador()
        Try
            cmOpcionesOtroSueldo.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.BorrarOtroEmpleadorSueldo(dgvOtrosSueldos.CurrentRow.Cells("IdPer").Value, dgvOtrosSueldos.CurrentRow.Cells("RucEmp").Value, dgvOtrosSueldos.CurrentRow.Cells("Periodo").Value, dgvOtrosSueldos.CurrentRow.Cells("Mes").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtOtroSueldoEmpleador = Nothing
                    ListarOtroSueldoEmpleador()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR OTRO EMPLEADOR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarOtroSueldoEmpleador()
        Try
            Dim codigo As String = ""
            If dgvOtrosSueldos.RowCount > 0 Then
                If IsDBNull(dgvOtrosSueldos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvOtrosSueldos.CurrentRow.Cells("Mes").Text
                End If
            End If
            dtOtroEmpleador = Nothing
            ListarOtroSueldoEmpleador()
            If dgvOtrosSueldos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionOtroSueldoEmpleador(dgvOtrosSueldos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR OTRO EMPLEADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvOtroSueldoEmpleador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOtrosSueldos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvOtrosSueldos.RowCount > 0 Then
                miMostraOtroSueldo_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvOtroSueldoEmpleador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvOtrosSueldos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub miNuevoOtroSueldo_Click(sender As Object, e As EventArgs) Handles miNuevoOtroSueldo.Click
        NuevoOtroSueldoEmpleador()
    End Sub

    Private Sub miMostraOtroSueldo_Click(sender As Object, e As EventArgs) Handles miMostraOtroSueldo.Click, dgvOtrosSueldos.DoubleClick
        MostrarOtroSueldoEmpleador()
    End Sub

    Private Sub miBorrarOtroSueldo_Click(sender As Object, e As EventArgs) Handles miBorrarOtroSueldo.Click
        EliminarOtroSueldoEmpleador()
    End Sub

    Private Sub miActualizarOtroSueldo_Click(sender As Object, e As EventArgs) Handles miActualizarOtroSueldo.Click
        ActualizarOtroSueldoEmpleador()
    End Sub

    Private Sub cbEPS_CheckedChanged(sender As Object, e As EventArgs) Handles cbEPS.CheckedChanged
        If cbEPS.Checked Then
            txtCantidadDH.ReadOnly = False
            txtMontoEPS.ReadOnly = False
        Else
            txtCantidadDH.ReadOnly = True
            txtMontoEPS.ReadOnly = True
            txtCantidadDH.Value = 0
            txtMontoEPS.Value = 0
        End If

    End Sub


    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '========================================== DERECHO HABIENTES MAYORES DE EDAD ==========================================
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub ListarDHMayores()
        Try

            dtDHMayores = oContratoPersonaService.MostrarDH(IdPersona).Tables(0)
            dgvDHMayores.DataSource = dtDHMayores
            cmOpcionesDHMayores.Enabled = True

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR OTROS EMPLEADORES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionDHMayores(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("IdDH").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] Derecho habiente mayores: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub NuevoDHMayores()
        Try
            Dim frm As New frmContPerDHMayores
            frm.state_button = False
            frm.IdPersona = IdPersona
            frm.IdDH = 0

            'frm.mes = Today.Month
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDHMayores = Nothing
                ListarDHMayores()
                If frm.type_process = "insert" Then
                    RowPossesionDHMayores(dgvDHMayores, frm.IdDH)
                End If
            End If
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DH: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarDHMayores()
        Try
            Dim frm As New frmContPerDHMayores
            frm.state_button = True
            frm.IdDH = dgvDHMayores.CurrentRow.Cells("IdDH").Value
            frm.IdPersona = dgvDHMayores.CurrentRow.Cells("IdPer").Value
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDHMayores = Nothing
                ListarDHMayores()
                If frm.type_process = "update" Then
                    RowPossesionDHMayores(dgvDHMayores, frm.IdDH)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesionDHMayores(dgvDHMayores, frm.IdDH)
            EnableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR OTRO DH: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarDHMayores()
        Try
            cmOpcionesDHMayores.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oContratoPersonaService.BorrarDH(dgvDHMayores.CurrentRow.Cells("IdDH").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDHMayores = Nothing
                    ListarDHMayores()
                    EnableOpciones()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR OTRO DH:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDHMayores()
        Try
            Dim codigo As String = ""
            If dgvDHMayores.RowCount > 0 Then
                If IsDBNull(dgvDHMayores.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDHMayores.CurrentRow.Cells("IdDH").Text
                End If
            End If
            dtDHMayores = Nothing
            ListarDHMayores()
            If dgvDHMayores.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionDHMayores(dgvDHMayores, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR OTRO DH: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevoDHMayor_Click(sender As Object, e As EventArgs) Handles miNuevoDHMayor.Click
        NuevoDHMayores()
    End Sub

    Private Sub miMostrarDHMayor_Click(sender As Object, e As EventArgs) Handles miMostrarDHMayor.Click
        MostrarDHMayores()
    End Sub

    Private Sub miEliminarDHMayor_Click(sender As Object, e As EventArgs) Handles miEliminarDHMayor.Click
        EliminarDHMayores()
    End Sub

    Private Sub miActualizarDHMayor_Click(sender As Object, e As EventArgs) Handles miActualizarDHMayor.Click
        ActualizarDHMayores()
    End Sub

    Private Sub dgvDHMayores_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDHMayores.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDHMayores.RowCount > 0 Then
                miMostrarDHMayor_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDHMayores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvDHMayores.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub


    Private Sub dgvDHMayores_DoubleClick(sender As Object, e As EventArgs) Handles dgvDHMayores.DoubleClick
        MostrarDHMayores()
    End Sub
End Class